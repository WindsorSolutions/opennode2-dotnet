#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

// ZipFile.CreateSelfExtractor.cs
// ------------------------------------------------------------------
//
// ZipFile is set up as a "partial class" - defined in multiple .cs source modules.
//
// This is a the source module that implements the stuff for saving to a
// self-extracting Zip archive.
// 
// Here's the design: The self-extracting zip file is just a regular managed EXE
// file, with embedded resources.  The managed code logic instantiates a ZipFile, and
// then extracts each entry.  The embedded resources include the zip archive content,
// as well as the Zip library itself.  The latter is required so that self-extracting
// can work on any machine, whether or not it has the DotNetZip library installed on
// it.
// 
// What we need to do is create the animal I just described, within a method on the
// ZipFile class.  This source module provides that capability. The method is
// SaveSelfExtractor().
//
// The way the method works: it uses the programmatic interface to the csc.exe
// compiler, Microsoft.CSharp.CSharpCodeProvider, to compile "boilerplate" extraction
// logic into a new assembly.  As part of that compile, we embed within that assembly the zip archive
// itself, as well as the Zip library. 
//
// Therefore we need to first save to a temporary zip file, then produce the exe.  
//
// There are a few twists.  
//
// The Visual Studio Project structure is a little weird.  There are code files that ARE NOT compiled
// during a normal build of the VS Solution.  They are marked as embedded resources.  These
// are the various "boilerplate" modules that are used in the self-extractor. These modules are:
//   WinFormsSelfExtractorStub.cs
//   WinFormsSelfExtractorStub.Designer.cs
//   CommandLineSelfExtractorStub.cs
//   PasswordDialog.cs
//   PasswordDialog.Designer.cs
//
// At design time, if you want to modify the way the GUI looks, you have to mark those modules
// to have a "compile" build action.  Then tweak em, test, etc.  Then again mark them as 
// "Embedded resource". 
//
// ------------------------------------------------------------------
//
// Copyright (c) 2008 by Dino Chiesa
// All rights reserved!
// 
// ------------------------------------------------------------------

using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;


namespace Ionic.Zip
{
#if !NO_SFX
    /// <summary>
    /// An enum that provides the different self-extractor flavors
    /// </summary>
    public enum SelfExtractorFlavor
    {
        /// <summary>
        /// A self-extracting zip archive that runs from the console or command line. 
        /// </summary>
        ConsoleApplication = 0,

        /// <summary>
        /// A self-extracting zip archive that presents a graphical user interface when it is executed.. 
        /// </summary>
        WinFormsApplication,
    }


    partial class ZipFile
    {
        class ExtractorSettings
        {
            public SelfExtractorFlavor Flavor;
            public List<string> ReferencedAssemblies;
            public List<string> CopyThroughResources;
            public List<string> ResourcesToCompile;
        }


        private static ExtractorSettings[] SettingsList = {
            new ExtractorSettings() {
                Flavor = SelfExtractorFlavor.WinFormsApplication,
                ReferencedAssemblies= new List<string>{
                    "System.Windows.Forms.dll", "System.dll", "System.Drawing.dll"},
                CopyThroughResources = new List<string>{
                    "Ionic.Zip.WinFormsSelfExtractorStub.resources",
                    "Ionic.Zip.PasswordDialog.resources",
                    "Ionic.Zip.ZipContentsDialog.resources"},
                ResourcesToCompile = new List<string>{
                    "Ionic.Zip.Resources.WinFormsSelfExtractorStub.cs",
                    "Ionic.Zip.WinFormsSelfExtractorStub", // .Designer.cs
                    "Ionic.Zip.Resources.PasswordDialog.cs",
                    "Ionic.Zip.PasswordDialog",             //.Designer.cs"
                    "Ionic.Zip.Resources.ZipContentsDialog.cs",
                    "Ionic.Zip.ZipContentsDialog"             //.Designer.cs"
                }
            },
            new ExtractorSettings() {
                Flavor = SelfExtractorFlavor.ConsoleApplication,
                ReferencedAssemblies= null,
                CopyThroughResources = null,
                ResourcesToCompile = new List<string>{"Ionic.Zip.Resources.CommandLineSelfExtractorStub.cs"}
            }
        };


        private string SfxSaveTemporary()
        {
            var tempFileName = System.IO.Path.Combine(TempFileFolder, System.IO.Path.GetRandomFileName() + ".zip");
            Stream outstream = null;
            try
            {
                bool save_contentsChanged = _contentsChanged;
                outstream = new System.IO.FileStream(tempFileName, System.IO.FileMode.CreateNew);
                if (outstream == null)
                    throw new BadStateException(String.Format("Cannot open the temporary file ({0}) for writing.", tempFileName));
                if (Verbose) StatusMessageTextWriter.WriteLine("Saving temp zip file....");
                // write an entry in the zip for each file
                int n = 0;
                foreach (ZipEntry e in _entries)
                {
                    OnSaveEntry(n, e, true);
                    e.Write(outstream);
                    n++;
                    OnSaveEntry(n, e, false);
                    if (_saveOperationCanceled)
                        break;
                }

                if (!_saveOperationCanceled)
                {
                    WriteCentralDirectoryStructure(outstream);
                    outstream.Close();
                    outstream = null;
                }
                _contentsChanged = save_contentsChanged;
            }

            finally
            {
                if (outstream != null)
                {
                    try { outstream.Close(); }
                    catch { }
                    try { outstream.Dispose(); }
                    catch { }
                }
            }
            return tempFileName;
        }


        string _defaultExtractLocation = null;
//         string _SetDefaultLocationCode =
//         "namespace Ionic.Zip { public partial class WinFormsSelfExtractorStub { partial void _SetDefaultExtractLocation() {" +
//         " txtExtractDirectory.Text = \"@@VALUE\"; } }}";

        /// <summary>
        /// Saves the ZipFile instance to a self-extracting zip archive, using the specified 
        /// default extract directory. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method saves a self extracting archive, 
        /// with a specified default extracting location.  Actually, the 
	/// default extract directory applies only if the flavor is 
	///  <see cref="SelfExtractorFlavor.WinFormsApplication"/>.  
	/// See the documentation for 
        /// <see cref="SaveSelfExtractor(string , SelfExtractorFlavor)"/>
        /// for more details.  
        /// </para>
        /// <para>
        /// The user who runs the SFX will have the opportunity to change the extract
        /// directory before extracting. 
        /// If at the time of extraction, the specified directory does not exist, 
        /// the SFX will create the directory before extracting the files. 
        /// </para>
        /// </remarks>
        /// <param name="exeToGenerate">The name of the EXE to generate.</param>
        /// <param name="flavor">Indicates whether a Winforms or Console self-extractor is desired.</param>
        /// <param name="defaultExtractDirectory">
	/// The default extract directory the user will see when running the self-extracting 
	/// archive. Passing null (or Nothing in VB) here will cause the Self Extractor to 
	/// use the the user's personal directory 
        /// (<see cref="Environment.SpecialFolder.Personal"/>) for the default extract 
	/// location.
	/// </param>
        public void SaveSelfExtractor(string exeToGenerate, SelfExtractorFlavor flavor, string defaultExtractDirectory)
        {
            this._defaultExtractLocation = defaultExtractDirectory;
            SaveSelfExtractor(exeToGenerate, flavor);
            this._defaultExtractLocation = null;
        }


        /// <summary>
        /// Saves the ZipFile instance to a self-extracting zip archive.
        /// </summary>
        /// 
        /// <remarks>
        /// 
        /// <para>
        /// The generated exe image will execute on any machine that has the .NET Framework 2.0
        /// installed on it.
        /// </para>
        /// 
        /// <para>
        /// There are two "flavors" of self-extracting archive.  The <c>WinFormsApplication</c>
        /// version will pop up a GUI and allow the user to select a target directory into which
        /// to extract. There's also a checkbox allowing the user to specify to overwrite
        /// existing files, and another checkbox to allow the user to request that Explorer be
        /// opened to see the extracted files after extraction.  The other flavor is
        /// <c>ConsoleApplication</c>.  A self-extractor generated with that flavor setting will
        /// run from the command line. It accepts command-line options to set the overwrite
        /// behavior, and to specify the target extraction directory.
        /// </para>
        /// 
        /// <para>
        /// There are a few temporary files created during the saving to a self-extracting zip. 
        /// These files are created in the directory pointed to by 
        /// <see cref="ZipFile.TempFileFolder"/>, which defaults to  <see cref="System.IO.Path.GetTempPath"/>.
        /// These temporary files are removed upon successful completion of this method. 
        /// </para>
        ///
        /// <para>
        /// When a user runs the SFX, the user's personal directory 
        /// (<see cref="Environment.SpecialFolder.Personal"/>) 
        /// will be used as the default extract location.
        /// The user who runs the SFX will have the opportunity to change the extract
        /// directory before extracting. 
        /// </para>
        ///
        /// <para>
        /// NB: This method is not available in the version of DotNetZip
        /// build for the .NET Compact Framework, nor in the "Reduced" DotNEtZip library.  
        /// </para>
        /// 
        /// </remarks>
        /// 
        /// <example>
        /// <code>
        /// string DirectoryPath = "c:\\Documents\\Project7";
        /// using (ZipFile zip = new ZipFile())
        /// {
        ///     zip.AddDirectory(DirectoryPath, System.IO.Path.GetFileName(DirectoryPath));
        ///     zip.Comment = "This will be embedded into a self-extracting console-based exe";
        ///     zip.SaveSelfExtractor("archive.exe", SelfExtractorFlavor.ConsoleApplication);
        /// }
        /// </code>
        /// <code lang="VB">
        /// Dim DirectoryPath As String = "c:\Documents\Project7"
        /// Using zip As New ZipFile()
        ///     zip.AddDirectory(DirectoryPath, System.IO.Path.GetFileName(DirectoryPath))
        ///     zip.Comment = "This will be embedded into a self-extracting console-based exe"
        ///     zip.SaveSelfExtractor("archive.exe", SelfExtractorFlavor.ConsoleApplication)
        /// End Using
        /// </code>
        /// </example>
        /// 
        /// <param name="exeToGenerate">a pathname, possibly fully qualified, to be created. Typically it will end in an .exe extension.</param>
        /// <param name="flavor">Indicates whether a Winforms or Console self-extractor is desired.</param>
        public void SaveSelfExtractor(string exeToGenerate, SelfExtractorFlavor flavor)
        {
            if (File.Exists(exeToGenerate))
            {
                if (Verbose) StatusMessageTextWriter.WriteLine("The existing file ({0}) will be overwritten.", exeToGenerate);
            }
            if (!exeToGenerate.EndsWith(".exe"))
            {
                if (Verbose) StatusMessageTextWriter.WriteLine("Warning: The generated self-extracting file will not have an .exe extension.");
            }

            string TempZipFile = SfxSaveTemporary();
            OnSaveEvent(ZipProgressEventType.Saving_AfterSaveTempArchive);

            if (TempZipFile == null)
                return; // cancelled

            // look for myself (ZipFile will be present in the Ionic.Utils.Zip assembly)
            Assembly a1 = typeof(ZipFile).Assembly;
            //Console.WriteLine("DotNetZip assembly loc: {0}", a1.Location);

            Microsoft.CSharp.CSharpCodeProvider csharp = new Microsoft.CSharp.CSharpCodeProvider();

            // Perfect opportunity for a linq query, but I cannot use it.
	    // The DotNetZip library can compile into 2.0, but needs to run on .NET 2.0.
	    // Using LINQ would break that. Here's what it would look like: 
	    // 
            // 	var settings = (from x in SettingsList
            // 			where x.Flavor == flavor
            // 			select x).First();

            ExtractorSettings settings = null;
            foreach (var x in SettingsList)
            {
                if (x.Flavor == flavor)
                {
                    settings = x;
                    break;
                }
            }

            if (settings == null)
                throw new BadStateException(String.Format("While saving a Self-Extracting Zip, Cannot find that flavor ({0})?", flavor));

            // This is the list of referenced assemblies.  Ionic.Utils.Zip is needed here.
            // Also if it is the winforms (gui) extractor, we need other referenced assemblies.
            System.CodeDom.Compiler.CompilerParameters cp = new System.CodeDom.Compiler.CompilerParameters();
            cp.ReferencedAssemblies.Add(a1.Location);
            if (settings.ReferencedAssemblies != null)
                foreach (string ra in settings.ReferencedAssemblies)
                    cp.ReferencedAssemblies.Add(ra);

            cp.GenerateInMemory = false;
            cp.GenerateExecutable = true;
            cp.IncludeDebugInformation = false;
            cp.OutputAssembly = exeToGenerate;

            Assembly a2 = Assembly.GetExecutingAssembly();

            string TempDir = GenerateUniquePathname("tmp", null);
            if ((settings.CopyThroughResources != null) && (settings.CopyThroughResources.Count != 0))
            {
                System.IO.Directory.CreateDirectory(TempDir);
                int n = 0;
                byte[] bytes = new byte[1024];
                foreach (string re in settings.CopyThroughResources)
                {
                    string filename = Path.Combine(TempDir, re);
                    using (Stream instream = a2.GetManifestResourceStream(re))
                    {
                        using (FileStream outstream = File.OpenWrite(filename))
                        {
                            do
                            {
                                n = instream.Read(bytes, 0, bytes.Length);
                                outstream.Write(bytes, 0, n);
                            } while (n > 0);
                        }
                    }
                    // add the embedded resource in our own assembly into the target assembly as an embedded resource
                    cp.EmbeddedResources.Add(filename);
                }
            }

            // add the zip file as an embedded resource
            cp.EmbeddedResources.Add(TempZipFile);

            // add the Ionic.Utils.Zip DLL as an embedded resource
            cp.EmbeddedResources.Add(a1.Location);

            //Console.WriteLine("Resources in this assembly:");
            //foreach (string rsrc in a2.GetManifestResourceNames())
            //{
            //    Console.WriteLine(rsrc);
            //}
            //Console.WriteLine();

            //Console.WriteLine("reading source code resources:");


            // concatenate all the source code resources into a single module
            var sb = new System.Text.StringBuilder();

            // set the default extract location if it is available
            bool wantCodeReplace = (flavor == SelfExtractorFlavor.WinFormsApplication && _defaultExtractLocation != null);
	    if (wantCodeReplace)
                _defaultExtractLocation = _defaultExtractLocation.Replace("\"", "");

            foreach (string rc in settings.ResourcesToCompile)
            {
                //Console.WriteLine("  trying to read stream: ({0})", rc);
                Stream s = a2.GetManifestResourceStream(rc);
                using (StreamReader sr = new StreamReader(s))
                {
                    while (sr.Peek() >= 0) 
		    {
			string line = sr.ReadLine();
			if (wantCodeReplace)
			    line= line.Replace("@@VALUE", _defaultExtractLocation);
                        sb.Append(line).Append("\n");
		    }
                }
                sb.Append("\n\n");
            }

            string LiteralSource = sb.ToString();

            System.CodeDom.Compiler.CompilerResults cr = csharp.CompileAssemblyFromSource(cp, LiteralSource);
            if (cr == null)
                throw new SfxGenerationException("Cannot compile the extraction logic!");

            if (Verbose)
                foreach (string output in cr.Output)
                    StatusMessageTextWriter.WriteLine(output);

            if (cr.Errors.Count != 0)
                throw new SfxGenerationException("Errors compiling the extraction logic!");

            OnSaveEvent(ZipProgressEventType.Saving_AfterCompileSelfExtractor);

            try
            {
                if (Directory.Exists(TempDir))
                {
                    try { Directory.Delete(TempDir, true); }
                    catch { }
                }

                if (File.Exists(TempZipFile))
                {
                    try { File.Delete(TempZipFile); }
                    catch { }
                }
            }
            catch { }

            OnSaveCompleted();

            if (Verbose) StatusMessageTextWriter.WriteLine("Created self-extracting zip file {0}.", cr.PathToAssembly);
            return;


            //       catch (Exception e1)
            //       {
            // 	StatusMessageTextWriter.WriteLine("****Exception: " + e1);
            // 	throw;
            //       }
            //       return;
        }


        internal static string GenerateUniquePathname(string extension, string ContainingDirectory)
        {
            string candidate = null;
            String AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            string parentDir = (ContainingDirectory == null) ?
                System.Environment.GetEnvironmentVariable("TEMP") : ContainingDirectory;

            if (parentDir == null) return null;

            int index = 0;
            do
            {
                index++;
                string Name = String.Format("{0}-{1}-{2}.{3}",
                        AppName, System.DateTime.Now.ToString("yyyyMMMdd-HHmmss"), index, extension);
                candidate = System.IO.Path.Combine(parentDir, Name);
            } while (System.IO.File.Exists(candidate) || System.IO.Directory.Exists(candidate));

            // this file/path does not exist.  It can now be created, as file or directory. 
            return candidate;
        }
    }
#endif
}
