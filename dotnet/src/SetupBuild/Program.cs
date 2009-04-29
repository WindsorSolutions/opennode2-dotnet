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

namespace CopyPlugins
{
    class Program
    {
        const string BUILD_FOLDER_NAME = "BUILD";

        static int Main(string[] args)
        {
            try
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string trunkFolder = Path.GetFullPath(assemblyPath + @"\..\..\..\..\");

                CopyPluginsToBuildFolder(trunkFolder);

                CopyConfigFilesToBuildFolder(trunkFolder);

                CreateDefaultFolders(trunkFolder);

                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }
        }
        static void CreateDefaultFolders(string trunkFolder)
        {
            string buildFolder = Path.Combine(trunkFolder, BUILD_FOLDER_NAME);
            Directory.CreateDirectory(Path.Combine(buildFolder, "Temp"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "Repository"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "Logs"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "Sql"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "www\\Admin"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "www\\Endpoint1"));
            Directory.CreateDirectory(Path.Combine(buildFolder, "www\\Endpoint2"));
        }
        static void CopyPlugin(string pluginPath, string wnosPluginFolder)
        {
            if (Directory.Exists(wnosPluginFolder))
            {
                Directory.Delete(wnosPluginFolder, true);
            }
            Directory.CreateDirectory(wnosPluginFolder);
            pluginPath = Path.ChangeExtension(pluginPath, ".dll");
            string dstPath = Path.Combine(wnosPluginFolder, Path.GetFileName(pluginPath));
            File.Copy(pluginPath, dstPath, true);
            pluginPath = Path.ChangeExtension(pluginPath, ".pdb");
            dstPath = Path.Combine(wnosPluginFolder, Path.GetFileName(pluginPath));
            File.Copy(pluginPath, dstPath, true);
        }
        static void CopyPluginsToBuildFolder(string trunkFolder)
        {
            const string pluginsFolderName = "Plugins";
            string buildFolder = Path.Combine(trunkFolder, BUILD_FOLDER_NAME);
            string pluginsSrcFolder = Path.Combine(trunkFolder, pluginsFolderName);
            string[] pluginPaths = Directory.GetFiles(pluginsSrcFolder, "Windsor.Node2008.WNOSPlugin.*.dll",
                                                      SearchOption.AllDirectories);
            string wnosPluginFolder = Path.Combine(buildFolder, pluginsFolderName);
            if (Directory.Exists(wnosPluginFolder))
            {
                Directory.Delete(wnosPluginFolder, true);
            }
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
                        try
                        {
                            Assembly loadedAssembly = Assembly.LoadFile(pluginPath);
                            Attribute[] customAttributes = 
                                Attribute.GetCustomAttributes(loadedAssembly, typeof(PluginDefaultFlowAttribute));
                            if ((customAttributes != null) && (customAttributes.Length > 0))
                            {
                                foreach (Attribute attribute in customAttributes)
                                {
                                    PluginDefaultFlowAttribute defaultFlowAttribute = attribute as PluginDefaultFlowAttribute;
                                    if (defaultFlowAttribute != null)
                                    {
                                        flowNames = defaultFlowAttribute.DefaultFlowNames;
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
                            CopyPlugin(pluginPath, pluginDestPath);
                        }
                    }
                }
            }
        }
        static void CopyConfigFilesToBuildFolder(string trunkFolder)
        {
            const string configFolderName = "Config";
            string buildFolder = Path.Combine(trunkFolder, BUILD_FOLDER_NAME);
            string configSrcFolder = Path.Combine(trunkFolder, configFolderName);
            string[] configPaths = Directory.GetFiles(configSrcFolder, "*.config",
                                                      SearchOption.TopDirectoryOnly);
            string wnosConfigFolder = Path.Combine(buildFolder, configFolderName);
            if (Directory.Exists(wnosConfigFolder))
            {
                Directory.Delete(wnosConfigFolder, true);
            }
            Directory.CreateDirectory(wnosConfigFolder);
            foreach (string configPath in configPaths)
            {
                string dstPath = Path.Combine(wnosConfigFolder, Path.GetFileName(configPath));
                File.Copy(configPath, dstPath, true);
            }
        }
    }
}
