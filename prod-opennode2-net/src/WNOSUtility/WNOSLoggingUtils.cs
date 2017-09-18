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
using System.IO;
using Windsor.Commons.Core;
using Common.Logging.Log4Net;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSUtility
{
    public class WNOSLoggerFactoryAdapter : Log4NetLoggerFactoryAdapter
    {
        public WNOSLoggerFactoryAdapter(System.Collections.Specialized.NameValueCollection properties) :
            base(new WNOSLoggerPropertiesCollection(properties))
        {
        }
    }
    public class WNOSLoggerPropertiesCollection : System.Collections.Specialized.NameValueCollection
    {
        public WNOSLoggerPropertiesCollection(System.Collections.Specialized.NameValueCollection properties)
        {
            if (properties.Count > 0)
            {
                if (string.Equals(properties["configType"], "FILE", StringComparison.InvariantCultureIgnoreCase))
                {
                    string location = properties["configFile"];
                    if (location == null)
                    {
                        throw new ArgumentNullException("WNOSLoggerPropertiesCollection: Missing \"configFile\" property");
                    }
                    if (location.IndexOf('~') == 0)
                    {
                        location = Path.GetFullPath(location.Replace("~", AppDomain.CurrentDomain.BaseDirectory));
                    }
                    else
                    {
                        location = Path.GetFullPath(location);
                    }
                    if (!File.Exists(location))
                    {
                        // Attempt to search for the file
                        string baseDir = Path.GetDirectoryName(Path.GetDirectoryName(location));
                        string relativePath = location.Substring(baseDir.Length + 1);

                        location = Path.Combine(Path.Combine(baseDir, "BUILD"), relativePath);
                        if (!File.Exists(location))
                        {
                            throw new FileNotFoundException(string.Format("WNOSLoggerPropertiesCollection: Could not find file \"{0}\"", relativePath));
                        }
                    }
                    properties["configFile"] = location;
                }
                foreach (string key in properties.AllKeys)
                {
                    this.Add(key, properties[key]);
                }
            }
        }
    }
    public class WNOSRollingFileAppender : log4net.Appender.RollingFileAppender
    {
        private static List<string> s_LogFilePaths = new List<string>();
        public WNOSRollingFileAppender()
            : base()
        {
        }
        public override string File
        {
            get
            {
                return base.File;
            }
            set
            {
                string loggingFilePath = null;

                string deploymentFilePath = ExposablePropertyPlaceholderConfigurer.GetDeploymentFilePathFromCommandLine();
                if (!string.IsNullOrEmpty(deploymentFilePath))
                {
                    IDictionary<string, string> configItems = SpringConfigParser.ParseFile(deploymentFilePath);
                    string wnosLogFilePath;
                    const string loggingKey = "wnos.log.file.path";
                    if (configItems.TryGetValue(loggingKey, out wnosLogFilePath) && !string.IsNullOrEmpty(wnosLogFilePath))
                    {
                        loggingFilePath = SpringConfigParser.ResolveDictionaryReferencesInValue(loggingKey, wnosLogFilePath, configItems);
                    }
                }
                if (loggingFilePath == null)
                {
                    loggingFilePath = value;
                    if (loggingFilePath.StartsWith(".\\")) // Assume this means relative to Node home folder
                    {
                        loggingFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\" + value));
                        if (!Directory.Exists(Path.GetDirectoryName(loggingFilePath)))
                        {
                            loggingFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\" + value));
                            if (!Directory.Exists(Path.GetDirectoryName(loggingFilePath)))
                            {
                                loggingFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\BUILD" + value));
                                if (!Directory.Exists(Path.GetDirectoryName(loggingFilePath)))
                                {
                                    throw new FileNotFoundException(string.Format("WNOSRollingFileAppender: Could not find file location \"{0}\"", value));
                                }
                            }
                        }
                    }
                }
                // Make sure the log file location is "writable"
                if (!FileUtils.IsWritableDirectory(Path.GetDirectoryName(loggingFilePath)))
                {
                    throw new UnauthorizedAccessException(string.Format("The log file location \"{0}\" is not writable", loggingFilePath));
                }
                base.File = loggingFilePath;
                if (!s_LogFilePaths.Contains(loggingFilePath))
                {
                    s_LogFilePaths.Add(loggingFilePath);
                }
            }
        }
        public static ICollection<string> LogFilePaths
        {
            get
            {
                return s_LogFilePaths;
            }
        }
    }
}

