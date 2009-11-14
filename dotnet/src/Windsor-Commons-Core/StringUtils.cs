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
	public static class StringUtils {

        // Encoder that does not output byte marker (BOM) at start of encoding
        public static readonly UTF8Encoding UTF8 = new UTF8Encoding(false, true);
		
        /// <summary>
        /// Join the input string values using the separator and return the resulting string.
        /// </summary>
		public static string Join<T>(string separator, IEnumerable<T> values) {
			if ( values == null ) {
				return string.Empty;
			}
			StringBuilder sb = new StringBuilder();
			bool addedFirst = false;
			foreach(T value in values) {
				if ( addedFirst ) {
					sb.Append(separator);
				}
                if (value != null)
                {
                    sb.Append(value.ToString());
                }
                else
                {
                    sb.Append(string.Empty);
                }
				addedFirst = true;
			}
			return sb.ToString();
		}
        /// <summary>
        /// Return the character index of findChar within text, starting from the end of text
        /// and working backwards until the n-th occurance is found (specified by 1-based lastNthCount).
        /// </summary>
        public static int LastNthIndexOf(string text, char findChar, int lastNthCount)
        {
            if (lastNthCount <= 0)
            {
                throw new ArgumentException("lastNthCount must be greater than 0");
            }
            int index = text.Length - 1;
            while ( index > 0 ) {
                index = text.LastIndexOf(findChar, index - 1);
                if (index >= 0)
                {
                    --lastNthCount;
                    if (lastNthCount == 0)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Return the character index of findChar within text, starting from the beginning of text
        /// and working forwards until the n-th occurance is found (specified by 1-based nthCount).
        /// </summary>
        public static int NthIndexOf(string text, char findChar, int nthCount)
        {
            if (nthCount <= 0)
            {
                throw new ArgumentException("nthCount must be greater than 0");
            }
            int index = -1;
            while (index < text.Length - 1)
            {
                index = text.IndexOf(findChar, index + 1);
                if (index >= 0)
                {
                    --nthCount;
                    if (nthCount == 0)
                    {
                        return index;
                    }
                }
            }
            return -1;
        }
        public static bool ContainsLowercaseChars(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                foreach (char chr in text)
                {
                    if (char.IsLower(chr))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool IsWord(string text, int offset, int length)
        {
            return IsWord(text, offset, length, char.IsLetterOrDigit);
        }
        public static bool Contains(string sourceString, string checkSubString,
                                    StringComparison comparison)
        {
            if (string.IsNullOrEmpty(sourceString) || string.IsNullOrEmpty(checkSubString))
            {
                return false;
            }
            return (sourceString.IndexOf(checkSubString, comparison) >= 0);
        }
        public static bool Contains(string checkString, IEnumerable<string> strings,
                                    StringComparison comparison)
        {
            return (IndexOf(checkString, strings, comparison) >= 0);
        }
        public static int LastIndexOf(string checkString, IEnumerable strings,
                                      int startIndex, int count, StringComparison comparison)
        {
            foreach (string str in strings)
            {
                int index = checkString.LastIndexOf(str, startIndex, count, comparison);
                if (index >= 0)
                {
                    return index;
                }
            }
            return -1;
        }
        public static int IndexOf(string checkString, IEnumerable strings, 
                                  StringComparison comparison)
        {
            if (strings != null)
            {
                int i = 0;
                IEnumerable<string> genericCollection = strings as IEnumerable<string>;
                if (genericCollection != null)
                {
                    foreach (string str in genericCollection)
                    {
                        if (string.Equals(checkString, str, comparison))
                        {
                            return i;
                        }
                        ++i;
                    }
                }
                else
                {
                    foreach (object obj in strings)
                    {
                        if (string.Equals(checkString, obj.ToString(), comparison))
                        {
                            return i;
                        }
                        ++i;
                    }
                }
            }
            return -1;
        }

        public delegate bool IsWordCharacter(char c);
        public static bool IsWord(string text, int offset, int length, IsWordCharacter isChar)
        {
            if (string.IsNullOrEmpty(text) || (length <= 0) || (offset < 0) || (offset >= text.Length))
            {
                return false;
            }
            if (offset > 0)
            {
                if ((offset + length) < text.Length)
                {
                    return (!isChar(text[offset - 1]) && !char.IsLetterOrDigit(text[offset + length]));
                }
                else
                {
                    return !isChar(text[offset - 1]);
                }
            }
            else if ((offset + length) < text.Length)
            {
                return !isChar(text[offset + length]);
            }
            else
            {
                return true;
            }
        }
        public static string ReplaceAllChars(string text, string replaceString)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            if ( string.IsNullOrEmpty(replaceString))
            {
                throw new ArgumentException("replaceString cannot be empty");
            }
            StringBuilder sb = new StringBuilder(text.Length * replaceString.Length);
            foreach (char chr in text)
            {
                sb.Append(replaceString);
            }
            return sb.ToString();
        }
        public static string SplitCamelCaseName(string camelCaseName, char separator)
        {
            ExceptionUtils.ThrowIfEmptyString(camelCaseName, "camelCaseName");

            StringBuilder sb = new StringBuilder((camelCaseName.Length * 3) / 2);
            sb.Append(camelCaseName[0]);
            bool lastCharWasLower = false;
            bool lastCharWasNumber = false;
            bool twoOrMoreUpperChars = false;
            for (int i = 1; i < camelCaseName.Length; ++i)
            {
                char curChar = camelCaseName[i];
                if (char.IsLetter(curChar))
                {
                    lastCharWasNumber = false;
                    if (char.IsUpper(curChar))
                    {
                        if (lastCharWasLower)
                        {
                            if (sb[sb.Length - 1] != separator)
                            {
                                sb.Append(separator);
                            }
                            twoOrMoreUpperChars = false;
                        }
                        else
                        {
                            twoOrMoreUpperChars = true;
                        }
                        sb.Append(curChar);
                        lastCharWasLower = false;
                    }
                    else
                    {
                        if (twoOrMoreUpperChars)
                        {
                            sb.Insert(sb.Length - 1, separator);
                            twoOrMoreUpperChars = false;
                        }
                        sb.Append(curChar);
                        lastCharWasLower = true;
                    }
                }
                else if (char.IsDigit(curChar))
                {
                    if (!lastCharWasNumber)
                    {
                        if (sb[sb.Length - 1] != separator)
                        {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(curChar);
                    lastCharWasNumber = true;
                    lastCharWasLower = true;
                    twoOrMoreUpperChars = false;
                }
                else
                {
                    sb.Append(curChar);
                    lastCharWasLower = true;
                    lastCharWasNumber = false;
                    twoOrMoreUpperChars = false;
                }
            }
            return sb.ToString();
        }
        public static bool IsNullOrEmpty(object value)
        {
            if (value == null)
            {
                return true;
            }
            string valueStr = value.ToString();
            return string.IsNullOrEmpty(valueStr);
        }
        public static string BreakUpText(string text, int numBreakChars, string breakString)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            StringBuilder sb = null;
            int currentNonWhitepaceCount = 0, currentCharIndex = 0;
            foreach (char currentChar in text)
            {
                if (char.IsWhiteSpace(currentChar) || (currentChar == '-'))
                {
                    currentNonWhitepaceCount = 0;
                }
                else {
                    if (++currentNonWhitepaceCount > numBreakChars)
                    {
                        if (sb == null)
                        {
                            sb = new StringBuilder(text);
                        }
                        sb.Insert(currentCharIndex, breakString);
                        currentCharIndex += breakString.Length;
                        currentNonWhitepaceCount = 1;
                    }
                }
                ++currentCharIndex;
            }
            return (sb == null) ? text : sb.ToString();
        }

        [System.Runtime.InteropServices.DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out Guid guid);

        public static string CreateSequentialGuid()
        {
            const int RPC_S_OK = 0;
            Guid guid;
            int hr = UuidCreateSequential(out guid);
            if (hr != RPC_S_OK)
            {
                throw new ApplicationException("UuidCreateSequential failed: " + hr);
            }
            return guid.ToString();
        }
        //public static string WrapText(string text, int numBreakChars)
        //{
        //    text = BreakUpText(text, numBreakChars, Environment.NewLine);
        //    if (string.IsNullOrEmpty(text))
        //    {
        //        return text;
        //    }
        //    StringBuilder sb = null;
        //    int currentDestCharIndex = 0, currentSrcCharIndex = 0;
        //    while (currentSrcCharIndex < text.Length)
        //    {
        //        int srcIndex = text.IndexOf(Environment.NewLine, currentSrcCharIndex);
        //        int deltaChars = (srcIndex < 0) ? (text.Length - currentSrcCharIndex) : (srcIndex - currentSrcCharIndex);
        //        if (deltaChars > numBreakChars)
        //        {
        //            if (sb == null)
        //            {
        //                sb = new StringBuilder(text);
        //            }
        //            do
        //            {
        //                currentDestCharIndex += numBreakChars;
        //                sb.Insert(currentDestCharIndex, Environment.NewLine);
        //                currentDestCharIndex += Environment.NewLine.Length;
        //                deltaChars -= numBreakChars;
        //            } while (deltaChars > numBreakChars);
        //        }
        //        currentDestCharIndex += deltaChars + Environment.NewLine.Length;
        //        if (srcIndex < 0)
        //        {
        //            break;
        //        }
        //        currentSrcCharIndex = srcIndex + Environment.NewLine.Length;
        //    }
        //    return (sb == null) ? text : sb.ToString();
        //}
    }
}
