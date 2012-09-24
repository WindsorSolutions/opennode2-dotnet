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
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

// NOTE: This file requires System.Web, and so is not available in .NET 3.5 client profile

namespace Windsor.Commons.Core
{
    public static class SimpleConfigFileParser
    {
        public static CaseInsensitiveDictionary<string> ParseConfigFile(string configFilePath)
        {
            try
            {
                CaseInsensitiveDictionary<string> map = null;

                string[] lines = File.ReadAllLines(configFilePath);

                if (!CollectionUtils.IsNullOrEmpty(lines))
                {
                    map = new CaseInsensitiveDictionary<string>(lines.Length);
                    CollectionUtils.ForEach(lines, delegate(string line)
                    {
                        string evalLine = line.Trim();
                        if (!string.IsNullOrEmpty(evalLine))
                        {
                            if (!evalLine.StartsWith(@"//"))
                            {
                                int valueIndex = evalLine.IndexOf(':');
                                if (valueIndex < 0)
                                {
                                    throw new ArgException("This line is missing a \":\" delimeter: " + line);
                                }
                                string key = evalLine.Substring(0, valueIndex).Trim();
                                if (string.IsNullOrEmpty(key))
                                {
                                    throw new ArgException("This line is missing a valid key value: " + line);
                                }
                                if (map.ContainsKey(key))
                                {
                                    throw new ArgException("The key \"{0}\" was specified more than once", key);
                                }
                                string value = string.Empty;
                                ++valueIndex;
                                if (valueIndex < evalLine.Length)
                                {
                                    value = evalLine.Substring(valueIndex, evalLine.Length - valueIndex).Trim();
                                }
                                map.Add(key, value);
                            }
                        }
                    });
                }
                else
                {
                    map = new CaseInsensitiveDictionary<string>();
                }
                return map;
            }
            catch (Exception ex)
            {
                throw new ArgException("The settings file \"{0}\" failed to parse: {1}",
                                       configFilePath, ExceptionUtils.GetDeepExceptionMessage(ex));
            }
        }
    }
}
