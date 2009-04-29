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

﻿// CommandLineSelfExtractorStub.cs
// ------------------------------------------------------------------
//
// Description goes here....
// 
// Author: Dinoch
// built on host: DINOCH-2
// Created Fri Jun 06 14:51:31 2008
//
// last saved: 
// Time-stamp: <Friday, June 06, 2008  17:44:24  (by dinoch)>
// ------------------------------------------------------------------
//
// Copyright (c) 2008 by Dino Chiesa
// All rights reserved!
// 

//
// ------------------------------------------------------------------

using System;
using System.Reflection;
using System.Resources;
using System.IO;
using Ionic.Utils.Zip;


namespace Ionic.Utils.Zip
{

    public class SelfExtractor
    {
        const string DllResourceName = "Ionic.Utils.Zip.dll";
        // ctor
        public SelfExtractor() { }

        static SelfExtractor()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Resolver);
        }

        static System.Reflection.Assembly Resolver(object sender, ResolveEventArgs args)
        {
            Assembly a1 = Assembly.GetExecutingAssembly();
            Assembly a2 = null;

            Stream s = a1.GetManifestResourceStream("Ionic.Utils.Zip.dll");
            int n = 0;
            int totalBytesRead = 0;
            byte[] bytes = new byte[1024];
            do
            {
                n = s.Read(bytes, 0, bytes.Length);
                totalBytesRead += n;
            }
            while (n > 0);

            byte[] block = new byte[totalBytesRead];
            s.Seek(0, System.IO.SeekOrigin.Begin);
            s.Read(block, 0, block.Length);

            a2 = Assembly.Load(block);

            return a2;
        }


        public void Run(string targetDirectory, bool WantOverwrite, string Password)
        {
            // There are only two embedded resources.
            // One of them is the zip dll.  The other is the zip archive.
            // We load the resouce that is NOT the DLL, as the zip archive.
            Assembly a = Assembly.GetExecutingAssembly();
            string[] x = a.GetManifestResourceNames();
            Stream s = null;
            foreach (string name in x)
            {
                if ((name != DllResourceName) && (name.EndsWith(".zip")))
                {
                    s = a.GetManifestResourceStream(name);
                    break;
                }
            }

            string currentPassword = null;
            if (s == null)
            {
                Console.WriteLine("No Zip archive found.");
                return;
            }

            try
            {
                using (global::Ionic.Utils.Zip.ZipFile zip = global::Ionic.Utils.Zip.ZipFile.Read(s))
                {
                    foreach (global::Ionic.Utils.Zip.ZipEntry entry in zip)
                    {
                        if (entry.Encryption == global::Ionic.Utils.Zip.EncryptionAlgorithm.None)
                            try
                            {
                                entry.Extract(targetDirectory, WantOverwrite);
                            }
                            catch (Exception ex1)
                            {
                                Console.WriteLine("Failed to extract entry {0} -- {1}", entry.FileName, ex1.ToString());

                            }
                        else
                        {
                            try
                            {
                                entry.ExtractWithPassword(Password, WantOverwrite, targetDirectory);
                            }
                            catch (Exception ex2)
                            {
                                // probably want a retry here in the case of bad password.
                                Console.WriteLine("Failed to extract entry {0} -- {1}", entry.FileName, ex2.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The self-extracting zip file is corrupted.");
                return;
            }

        }


        private static void Usage()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            string s = Path.GetFileName(a.Location);
            Console.WriteLine("DotNetZip Command-Line Self Extractor, see http://www.codeplex.com/DotNetZip");
            Console.WriteLine("usage:\n  {0} [-o] [-p password] <directory>", s);

            Environment.Exit(1);
        }



        public static void Main(string[] args)
        {
            try
            {
                string TargetDirectory = null;
                bool WantOverwrite = false;
                string Password = null;
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-p":
                            i++;
                            if (args.Length <= i) Usage();
                            if (Password != null) Usage();
                            Password = args[i];
                            break;
                        case "-o":
                            WantOverwrite = true;
                            break;
                        default:
                            // positional args
                            if (TargetDirectory == null)
                                TargetDirectory = args[i];
                            else
                                Usage();
                            break;
                    }
                }

                if (TargetDirectory == null)
                {
                    Console.WriteLine("No target directory specified.\n");
                    Usage();
                }

                SelfExtractor me = new SelfExtractor();
                me.Run(TargetDirectory, WantOverwrite, Password);
            }
            catch (System.Exception exc1)
            {
                Console.WriteLine("Exception while extracting: {0}", exc1.ToString());
            }
        }

    }
}
