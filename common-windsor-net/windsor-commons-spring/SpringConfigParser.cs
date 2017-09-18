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
using System.Xml;
using System.Diagnostics;
using Windsor.Commons.Core;

namespace Windsor.Commons.Spring
{
    /// <summary>
    /// Improves PropertyPlaceholderConfigurer by storing the property values for access at a later time 
    /// (i.e., after they have been assigned during the Spring context initialization process).
    /// </summary>
    public static class SpringConfigParser
    {
        public static IDictionary<string, string> ParseFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            Dictionary<string, string> configItems = new Dictionary<string, string>();
            foreach (XmlNode xmlConfigNode in doc.GetElementsByTagName("spring-config"))
            {
                foreach (XmlNode xmlAddNode in doc.GetElementsByTagName("add"))
                {
                    configItems.Add(xmlAddNode.Attributes["key"].Value, xmlAddNode.Attributes["value"].Value);
                }
            }

            return configItems;
        }
        public static string ResolveDictionaryReferencesInValue(string key, string value, IDictionary<string, string> dictionary)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            int curIndex = 0;
            string rtnValue = value;
            bool didResolveAny;
            int recursionCount = 0;
            const int maxRecursionCount = 20;
            do
            {
                ++recursionCount;
                if (recursionCount == maxRecursionCount)
                {
                    throw new ArgException("The configuration key \"" + key + "\" with value \"" + value + "\" exceeded the maximum recursion count to resolve.");
                }
                didResolveAny = false;
                for (; ; )
                {
                    if (curIndex > (rtnValue.Length - 1))
                    {
                        break;
                    }
                    int startIndex = rtnValue.IndexOf("${", curIndex);
                    if (startIndex < 0)
                    {
                        break;
                    }
                    int endIndex = rtnValue.IndexOf("}", startIndex + 2);
                    if (endIndex < 0)
                    {
                        throw new ArgException("The configuration key \"" + key + "\" with value \"" + value + "\" is missing a closing '}'.");
                    }
                    int origLen = endIndex - startIndex + 1;
                    string curKey = rtnValue.Substring(startIndex + 2, origLen - 3);
                    if (string.IsNullOrEmpty(curKey))
                    {
                        throw new ArgException("The configuration key \"" + key + "\" with value \"" + value + "\" has an empty key reference.");
                    }
                    if (curKey == key)
                    {
                        throw new ArgException("The configuration key \"" + key + "\" with value \"" + value + "\" references itself; this is not allowed.");
                    }
                    string curValue;
                    if (!dictionary.TryGetValue(curKey, out curValue))
                    {
                        throw new ArgException("The configuration key \"" + key + "\" with value \"" + value + "\" has a key reference that cannot be found: " + curKey + ".");
                    }
                    curIndex = endIndex + 1;
                    curIndex += (curValue.Length - origLen);

                    string endSubstring = null;
                    if ((endIndex + 1) <= (rtnValue.Length - 1))
                    {
                        endSubstring = rtnValue.Substring(endIndex + 1);
                    }
                    rtnValue = rtnValue.Substring(0, startIndex) + curValue + (endSubstring ?? string.Empty);
                    didResolveAny = true;
                }
            } while (didResolveAny);

            return rtnValue;
        }
    }
}
