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

namespace Windsor.Commons.Core
{
	/// <summary>
	/// Basic helper functions for dealing with strings.
	/// </summary>
    public static class SystemUtils
    {
        public static bool IsVistaOrLater
        {
            get
            {
                return (Environment.OSVersion.Version.Major > 5);
            }
        }
        public static DateTime GetSystemStartTime()
        {
            long ticks = Environment.TickCount;
            if (ticks < 0)
            {
                return DateTime.Now.AddMilliseconds(-((long)Int32.MaxValue + (ticks - Int32.MinValue)));
            }
            else
            {
                return DateTime.Now.AddMilliseconds(-Environment.TickCount);
            }
        }
        public static string GetDotNetFrameworkFolderPath()
        {
            return System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
        }
        public static string GetNgenExePath()
        {
            return Path.Combine(GetDotNetFrameworkFolderPath(), "ngen.exe");
        }
        public static void RunNgen(string assemblyPath)
        {
            string ngenPath = GetNgenExePath();

            using (Process process = new Process())
            {
                process.StartInfo.FileName = ngenPath;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.StartInfo.Arguments = "install \"" + assemblyPath + "\" /silent /nologo";

                process.Start();
                process.WaitForExit();
            }
        }
    }
}
