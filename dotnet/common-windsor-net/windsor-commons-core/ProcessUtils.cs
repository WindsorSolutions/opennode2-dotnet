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
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Management;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with windows processes.
    /// </summary>
    public static class ProcessUtils
    {
        /// <summary>
        /// Run a command and return results.
        /// </summary>
        public static Exception ExecuteCmd(string arguments, out string standardOutput, out string standardError)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd", @"/C " + arguments);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            standardOutput = null;
            standardError = null;
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = psi;
                    process.Start();
                    standardOutput = process.StandardOutput.ReadToEnd();
                    standardError = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                }
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        public static string GetProcessCommandLine(Process process)
        {
            return GetProcessCommandLine(process.Id);
        }
        public static string GetProcessCommandLine(int processId)
        {
            string result = null;
            try
            {
                ObjectQuery query = new ObjectQuery("Select CommandLine from Win32_Process Where ProcessID = '" + processId + "'");
                using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query))
                {
                    ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                    if (managementObjectCollection.Count == 0)
                    {
                        return result;
                    }
                    using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            ManagementObject managementObject = (ManagementObject)enumerator.Current;
                            result = managementObject["CommandLine"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
        public static string GetCurrentExeFilePath()
        {
            return Assembly.GetEntryAssembly().Location;
        }
        public static string GetCurrentExeConfigFilePath()
        {
            string exeFilePath = GetCurrentExeFilePath();
            string configName = Path.GetFileName(exeFilePath) + ".config";
            return Path.Combine(Path.GetDirectoryName(exeFilePath), configName);
        }
    }
}
