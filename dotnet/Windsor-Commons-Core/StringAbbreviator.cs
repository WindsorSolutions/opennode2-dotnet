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
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Resources;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with strings.
    /// </summary>
    public static class StringAbbreviator
    {
        public static string AbbreviateEx(string text, int maxChars)
        {
            LoadWordAbbreviations();
            return AbbreviateEx(text, maxChars, true, s_WordAbbreviations);
        }
        public static string AbbreviateEx(string text, int maxChars, bool abbreviateAlways,
                                          Dictionary<string, string> abbreviations)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            if (!abbreviateAlways && (text.Length <= maxChars))
            {
                return text;
            }
            text = Abbreviate(text, maxChars, s_WordAbbreviations);
            if (text.Length <= maxChars)
            {
                return text;
            }
            StringBuilder sb = new StringBuilder(text);
            for (int i = sb.Length - 1; i >= 1; --i)
            {
                switch (char.ToUpper(sb[i]))
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        sb.Remove(i, 1);
                        if (sb.Length == maxChars)
                        {
                            return sb.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
            int removeSize = sb.Length - maxChars;
            return sb.Remove(sb.Length - removeSize, removeSize).ToString();
        }
        public static string Abbreviate(string text, Dictionary<string, string> abbreviations)
        {
            return Abbreviate(text, 0, abbreviations);
        }
        public static string Abbreviate(string text, int maxChars, 
                                        Dictionary<string, string> abbreviations)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            if (!CollectionUtils.IsNullOrEmpty(abbreviations))
            {
                foreach (KeyValuePair<string, string> abbreviation in abbreviations)
                {
                    int index = text.Length - 1;
                    do
                    {
                        index = text.LastIndexOf(abbreviation.Key, index);
                        if (index >= 0)
                        {
                            // Determine if this is really a word
                            if (StringUtils.IsWord(text, index, abbreviation.Key.Length, char.IsLetterOrDigit))
                            {
                                text = text.Remove(index, abbreviation.Key.Length).Insert(index, abbreviation.Value);
                            }
                            if (text.Length <= maxChars)
                            {
                                return text;
                            }
                            --index;
                        }
                    } while (index >= 0);
                }
            }
            return text;
        }

        private static void LoadWordAbbreviations()
        {
            if (s_WordAbbreviations == null)
            {
                Dictionary<string, string> abbreviations = new Dictionary<string, string>();
                try
                {
                    string resourceName = typeof(StringAbbreviator).Namespace + ".WordAbbreviations.txt";
                    using (Stream stream = typeof(StringAbbreviator).Assembly.GetManifestResourceStream(resourceName))
                    {
                        using (CommaSeparatedFileParser parser = new CommaSeparatedFileParser(stream))
                        {
                            while (parser.NextLine())
                            {
                                string word, abbreviation;
                                if (parser.GetValue("WORD", out word) && parser.GetValue("ABBREVIATION", out abbreviation))
                                {
                                    abbreviations.Add(word, abbreviation);
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    s_WordAbbreviations = abbreviations;
                }
            }
        }

        private static Dictionary<string, string> s_WordAbbreviations;
    }
}
