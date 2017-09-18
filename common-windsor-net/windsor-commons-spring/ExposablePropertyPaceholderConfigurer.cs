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
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Config;
using Common.Logging;
using Spring.Aop.Support;
using Windsor.Commons.Core;
using System.Linq;
using Spring.Core.IO;

namespace Windsor.Commons.Spring
{
    /// <summary>
    /// Improves PropertyPlaceholderConfigurer by storing the property values for access at a later time 
    /// (i.e., after they have been assigned during the Spring context initialization process).
    /// </summary>
    [Obsolete("This class is mispelled and should not be used.  Use ExposablePropertyPlaceholderConfigurer instead")]
    public class ExposablePropertyPaceholderConfigurer : ExposablePropertyPlaceholderConfigurer
    {
    }

    /// <summary>
    /// Improves PropertyPlaceholderConfigurer by storing the property values for access at a later time 
    /// (i.e., after they have been assigned during the Spring context initialization process).
    /// </summary>
    public class ExposablePropertyPlaceholderConfigurer : PropertyPlaceholderConfigurer
    {
        private IDictionary<string, string> _exposedProperties = new Dictionary<string, string>();
        public ExposablePropertyPlaceholderConfigurer()
            : base()
        {
            this.IgnoreResourceNotFound = false;
            this.IgnoreUnresolvablePlaceholders = false;
            this.EnvironmentVariableMode = EnvironmentVariableMode.Fallback;
        }
        private string m_LocationString;
        public string LocationString
        {
            get
            {
                return m_LocationString;
            }
            set
            {
                try
                {
                    base.Location = new FileSystemResource(value);
                    m_LocationString = value;
                }
                catch (Exception e)
                {
                    throw new ArgException("Failed to set the ExposablePropertyPlaceholderConfigurer.LocationString property with exception: {1}",
                                            value, ExceptionUtils.GetDeepExceptionMessage(e));
                }
            }
        }
        public new IResource Location
        {
            set
            {
                string deploymentFilePath = GetDeploymentFilePathFromCommandLine();

                if (!string.IsNullOrEmpty(deploymentFilePath))
                {
                    deploymentFilePath = deploymentFilePath.Replace('\\', '/');
                    deploymentFilePath = "file://" + deploymentFilePath;
                    try
                    {
                        base.Location = new FileSystemResource(deploymentFilePath);
                    }
                    catch (Exception e)
                    {
                        throw new ArgException("Failed to set the deployment file path location specified on the command line, \"{0},\" with exception: {1}",
                                                deploymentFilePath, ExceptionUtils.GetDeepExceptionMessage(e));
                    }
                }
                else
                {
                    base.Location = value;
                }
            }
        }
        public static string GetDeploymentFilePathFromCommandLine()
        {
            // Use case for plugins and WNOS service
            string[] commandLineArgs = Environment.GetCommandLineArgs();

            if (commandLineArgs.Length > 1)
            {
                List<string> values = commandLineArgs.SkipWhile(s => !string.Equals(s, "-deployment", StringComparison.OrdinalIgnoreCase)).ToList();
                if (values.Count > 1)
                {
                    string deploymentFilePath = values[1];
                    deploymentFilePath = Path.GetFullPath(deploymentFilePath);
                    if (!File.Exists(deploymentFilePath))
                    {
                        throw new ArgException("The deployment file path specified on the command line cannot be found: {0}", deploymentFilePath);
                    }
                    return deploymentFilePath;
                }
            }

            // Use case for IIS apps
            string appPoolName = Environment.GetEnvironmentVariable("APP_POOL_ID", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(appPoolName))
            {
                string configDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (configDirectory.EndsWith("\\"))
                {
                    configDirectory = configDirectory.Substring(0, configDirectory.Length - 1);
                }
                configDirectory = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(configDirectory)), "Config");
                if (Directory.Exists(configDirectory))
                {
                    string[] configFiles = Directory.GetFiles(configDirectory, "Deployment*.config", SearchOption.TopDirectoryOnly);
                    string deploymentFilePath = null;
                    foreach (string configFile in configFiles)
                    {
                        try
                        {
                            IDictionary<string, string> configItems = SpringConfigParser.ParseFile(configFile);
                            string configAppPoolName;
                            if (configItems.TryGetValue("wnos.iis.app.pool.name", out configAppPoolName))
                            {
                                if (string.Equals(appPoolName, configAppPoolName, StringComparison.OrdinalIgnoreCase))
                                {
                                    deploymentFilePath = configFile;
                                    break;
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (deploymentFilePath != null)
                    {
                        return deploymentFilePath;
                    }
                }
            }

            return null;
        }
        protected override void ProcessProperties(IConfigurableListableObjectFactory factory,
                                                  NameValueCollection props)
        {
            base.ProcessProperties(factory, props);
            for (int i = 0; i < props.Count; ++i)
            {
                _exposedProperties.Add(props.GetKey(i), props.Get(i));
            }
        }
        public IDictionary<string, string> ExposedProps
        {
            get
            {
                return _exposedProperties;
            }
        }
        public string this[string key]
        {
            get
            {
                return _exposedProperties[key];
            }
        }
    }
}
