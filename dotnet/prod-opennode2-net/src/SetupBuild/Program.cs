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

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using Windsor.Node2008.WNOSPlugin;
using Windsor.Commons.Compression;
using Windsor.Commons.Core;

namespace CopyPlugins
{
    class Program
    {
        const string BUILD_FOLDER_NAME = "BUILD";
        static private bool CreateZipPackages;
        static private string DBScriptsParentFolderPath;
        static private string PackagesFolderPath;
        static private string BuildFolderPath;

        static int Main(string[] args)
        {
            try
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string trunkFolder = Path.GetFullPath(assemblyPath + @"\..\..\..\..");

                CreateZipPackages = (args.Length > 0) && (args[0] == "/CreatePackages");
                string trunkParent = Path.GetDirectoryName(trunkFolder);
                DBScriptsParentFolderPath = Path.Combine(trunkParent, "database-scripts");
                PackagesFolderPath = Path.Combine(trunkFolder, "Packages");
                BuildFolderPath = Path.Combine(trunkFolder, BUILD_FOLDER_NAME);

                if (CreateZipPackages)
                {
                    FileUtils.SafeDeleteDirectory(PackagesFolderPath);
                    Directory.CreateDirectory(PackagesFolderPath);
                }

                CopyPluginsToBuildFolder(trunkFolder);

                CopyConfigFilesToBuildFolder(trunkFolder);

                CreateDefaultFolders(trunkFolder);

                if (CreateZipPackages)
                {
                    BuildDeployPackage();
                }

                return 0;
            }
            catch (Exception e)
            {
                DebugUtils.CheckDebuggerBreak();
                Console.WriteLine(ExceptionUtils.ToShortString(e));
                Console.ReadKey();
                return 1;
            }
        }
        static void CreateDefaultFolders(string trunkFolder)
        {
            if (CreateZipPackages)
            {
                FileUtils.SafeDeleteDirectory(Path.Combine(BuildFolderPath, "Temp"));
                FileUtils.SafeDeleteDirectory(Path.Combine(BuildFolderPath, "Repository"));
                FileUtils.SafeDeleteDirectory(Path.Combine(BuildFolderPath, "Logs"));
                FileUtils.SafeDeleteDirectory(Path.Combine(BuildFolderPath, "Sql"));
            }
            Directory.CreateDirectory(Path.Combine(BuildFolderPath, "Temp"));
            Directory.CreateDirectory(Path.Combine(BuildFolderPath, "Repository"));
            Directory.CreateDirectory(Path.Combine(BuildFolderPath, "Logs"));
            Directory.CreateDirectory(Path.Combine(BuildFolderPath, "Sql"));
            if (CreateZipPackages)
            {
                xDirectory.Copy(Path.Combine(DBScriptsParentFolderPath, @"OPENNODE\2.0\DotNet"),
                                Path.Combine(BuildFolderPath, "Sql"), false, true, "*.sql");
            }
        }
        static void CopyPlugin(string flowName, string packageName, string fileVersion,
                               string pluginPath, string wnosPluginFolder, List<string> sqlDdlFilePaths)
        {
            FileUtils.SafeDeleteDirectory(wnosPluginFolder);
            Directory.CreateDirectory(wnosPluginFolder);
            pluginPath = Path.ChangeExtension(pluginPath, ".dll");
            string dllPluginPath = Path.Combine(wnosPluginFolder, Path.GetFileName(pluginPath));
            File.Copy(pluginPath, dllPluginPath, true);
            pluginPath = Path.ChangeExtension(pluginPath, ".pdb");
            string pdbPluginPath = Path.Combine(wnosPluginFolder, Path.GetFileName(pluginPath));
            File.Copy(pluginPath, pdbPluginPath, true);
            if (CreateZipPackages && !string.IsNullOrEmpty(packageName))
            {
                DotNetZipHelper zipHelper = new DotNetZipHelper();
                string pluginParentDir = Path.GetDirectoryName(Path.GetDirectoryName(dllPluginPath));
                string zipFilePath = Path.Combine(PackagesFolderPath, flowName + "_Plugin.zip");
                if (File.Exists(zipFilePath))
                    File.Delete(zipFilePath);
                string versionMinusSvnVersion = fileVersion.Substring(0, fileVersion.LastIndexOf('.'));
                string packageFileName = string.Format("DotNET {0} Plugin v{1}.zip", packageName, versionMinusSvnVersion);
                packageFileName = AdjustDeploymentName(packageFileName);
                string packageFilePath = Path.Combine(PackagesFolderPath, packageFileName);
                if (File.Exists(packageFilePath))
                    File.Delete(packageFilePath);
                try
                {
                    zipHelper.CompressFiles(zipFilePath, new string[] { dllPluginPath, pdbPluginPath });
                    List<string> packageFiles = new List<string>();
                    packageFiles.Add(zipFilePath);
                    CollectionUtils.ForEach(sqlDdlFilePaths, delegate(string filePath)
                    {
                        string sqlFilePath = Path.Combine(DBScriptsParentFolderPath, filePath);
                        if (!File.Exists(sqlFilePath))
                        {
                            if (!DebugUtils.IsDebugging)
                            {
                                throw new FileNotFoundException(string.Format("Could not find the file: {0}", sqlFilePath));
                            }
                        }
                        else
                        {
                            packageFiles.Add(sqlFilePath);
                        }
                    });
                    zipHelper.CompressFiles(packageFilePath, packageFiles);
                }
                catch (Exception)
                {
                    FileUtils.SafeDeleteFile(packageFilePath);
                    throw;
                }
                finally
                {
                    FileUtils.SafeDeleteFile(zipFilePath);
                }
            }
        }
        static void CopyPluginsToBuildFolder(string trunkFolder)
        {
            const string pluginsFolderName = "Plugins";
            string pluginsSrcFolder = Path.Combine(trunkFolder, pluginsFolderName);
            string[] pluginPaths = Directory.GetFiles(pluginsSrcFolder, "Windsor.Node2008.WNOSPlugin.*.dll",
                                                      SearchOption.AllDirectories);
            string pluginsSrcFolder2 = Path.Combine(trunkFolder, "Private");
            if (Directory.Exists(pluginsSrcFolder2))
            {
                string[] pluginPaths2 = Directory.GetFiles(pluginsSrcFolder2, "Windsor.Node2008.WNOSPlugin.*.dll",
                                                           SearchOption.AllDirectories);
                List<string> tempPaths = new List<string>(pluginPaths2);
                tempPaths.AddRange(pluginPaths);
                pluginPaths = tempPaths.ToArray();
            }

            string wnosPluginFolder = Path.Combine(BuildFolderPath, pluginsFolderName);
            FileUtils.SafeDeleteDirectory(wnosPluginFolder);
            Directory.CreateDirectory(wnosPluginFolder);
#if DEBUG
            const string matchFolderPath = @"bin\Debug\";
#else // DEBUG
                const string matchFolderPath = @"bin\Release\";
#endif // DEBUG
            foreach (string pluginPath in pluginPaths)
            {
                int index = pluginPath.IndexOf(matchFolderPath, StringComparison.InvariantCultureIgnoreCase);
                if (index > 0)
                {
                    int flowNameStart = pluginPath.LastIndexOf('\\', index - 2);
                    if (flowNameStart > 0)
                    {
                        ICollection<string> flowNames = new List<string>();
                        flowNames.Add(pluginPath.Substring(flowNameStart + 1, index - flowNameStart - 2));
                        string packageName = null;
                        List<string> sqlDdlFilePaths = null;
                        try
                        {
                            Assembly loadedAssembly = Assembly.LoadFile(pluginPath);
                            Attribute[] customAttributes = Attribute.GetCustomAttributes(loadedAssembly);
                            if ((customAttributes != null) && (customAttributes.Length > 0))
                            {
                                foreach (Attribute attribute in customAttributes)
                                {
                                    PluginDefaultFlowAttribute defaultFlowAttribute = attribute as PluginDefaultFlowAttribute;
                                    if (defaultFlowAttribute != null)
                                    {
                                        flowNames = defaultFlowAttribute.DefaultFlowNames;
                                    }
                                    else
                                    {
                                        PluginPackageNameAttribute packageNameAttribute = attribute as PluginPackageNameAttribute;
                                        if (packageNameAttribute != null)
                                        {
                                            packageName = packageNameAttribute.Name;
                                        }
                                        else
                                        {
                                            PluginSqlDdlFilePaths sqlDdlFilePathsAttribute = attribute as PluginSqlDdlFilePaths;
                                            if (sqlDdlFilePathsAttribute != null)
                                            {
                                                sqlDdlFilePaths = sqlDdlFilePathsAttribute.FilePaths;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        foreach (string flowName in flowNames)
                        {
                            string pluginDestPath = Path.Combine(wnosPluginFolder, flowName);
                            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(pluginPath);
                            pluginDestPath = Path.Combine(pluginDestPath, versionInfo.FileVersion);
                            CopyPlugin(flowName, packageName, versionInfo.FileVersion, pluginPath, pluginDestPath,
                                       sqlDdlFilePaths);
                        }
                    }
                }
            }
        }
        static void CopyConfigFilesToBuildFolder(string trunkFolder)
        {
            const string configFolderName = "Config";
            string configSrcFolder = Path.Combine(trunkFolder, configFolderName);
            string[] configPaths = Directory.GetFiles(configSrcFolder, "*.config",
                                                      SearchOption.TopDirectoryOnly);
            string wnosConfigFolder = Path.Combine(BuildFolderPath, configFolderName);
            FileUtils.SafeDeleteDirectory(wnosConfigFolder);
            Directory.CreateDirectory(wnosConfigFolder);
            foreach (string configPath in configPaths)
            {
                string dstPath = Path.Combine(wnosConfigFolder, Path.GetFileName(configPath));
                File.Copy(configPath, dstPath, true);
            }
            string privateDeploymentPath = Path.Combine(wnosConfigFolder, "Deployment_private.config");
            if (File.Exists(privateDeploymentPath))
            {
                if (!CreateZipPackages)
                {
                    string deploymentPath = Path.Combine(wnosConfigFolder, "Deployment.config");
                    FileUtils.SafeDeleteFile(deploymentPath);
                    File.Move(privateDeploymentPath, deploymentPath);
                }
                else
                {
                    FileUtils.SafeDeleteFile(privateDeploymentPath);
                }
            }
        }
        static string AdjustDeploymentName(string name)
        {
            return name.Replace(' ', '_');
        }
        static void RemoveVSHostFiles(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.vshost.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                FileUtils.SafeDeleteFile(file);
            }
        }
        static void UpdateMaxNumConcurrentThreads()
        {
            var serverConfigFilePath = Path.Combine(Path.Combine(BuildFolderPath, "Config"), "Server.config");
            var fileString = File.ReadAllText(serverConfigFilePath);
            fileString = fileString.Replace("<property name=\"MaxNumConcurrentThreads\" value=\"1\" />",
                                            "<property name=\"MaxNumConcurrentThreads\" value=\"3\" />");
            File.WriteAllText(serverConfigFilePath, fileString);
        }
        static void BuildDeployPackage()
        {
            string versionMinusSvnVersion =
                Windsor.Commons.AssemblyInfo.AssemblyInfo.cAssemblyVersion.Substring(0,
                Windsor.Commons.AssemblyInfo.AssemblyInfo.cAssemblyVersion.LastIndexOf('.'));
            string zipFile = Path.Combine(PackagesFolderPath, "DotNET OpenNode2 v" +
                versionMinusSvnVersion + ".zip");
            zipFile = AdjustDeploymentName(zipFile);
            RemoveVSHostFiles(Path.Combine(BuildFolderPath, "Server"));
            UpdateMaxNumConcurrentThreads();
            FileUtils.SafeDeleteFile(zipFile);
            DotNetZipHelper zipHelper = new DotNetZipHelper();
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Config"), "Config");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Logs"), "Logs");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Repository"), "Repository");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Server"), "Server");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Sql"), "Sql");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "Temp"), "Temp");
            zipHelper.CompressDirectory(zipFile, Path.Combine(BuildFolderPath, "www"), "www");

            string pluginsFolder = Path.Combine(BuildFolderPath, "Plugins");
            string[] pluginFilePaths = Directory.GetFiles(pluginsFolder, "*.dll", SearchOption.AllDirectories);
            CollectionUtils.ForEach(pluginFilePaths, delegate(string pluginFilePath)
            {
                try
                {
                    Assembly loadedAssembly = Assembly.LoadFile(pluginFilePath);
                    Attribute[] customAttributes = Attribute.GetCustomAttributes(loadedAssembly, typeof(StandardPluginAttribute));
                    if (!CollectionUtils.IsNullOrEmpty(customAttributes))
                    {
                        // This is a standard plugin that is included with the default deployment package
                        string includeFolder = Path.GetDirectoryName(pluginFilePath);
                        string zipFolderName = includeFolder.Substring(includeFolder.LastIndexOf("Plugins\\", StringComparison.InvariantCultureIgnoreCase));
                        zipHelper.CompressDirectory(zipFile, includeFolder, zipFolderName);
                    }
                }
                catch (BadImageFormatException)
                {
                    DebugUtils.CheckDebuggerBreak();
                    throw;
                }
                catch (Exception)
                {
                    DebugUtils.CheckDebuggerBreak();
                    throw;
                }
            });
        }
    }
}
