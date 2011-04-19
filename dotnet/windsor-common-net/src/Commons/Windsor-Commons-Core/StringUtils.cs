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
    public static class StringUtils
    {

        // Encoder that does not output byte marker (BOM) at start of encoding
        public static readonly UTF8Encoding UTF8 = new UTF8Encoding(false, true);

        /// <summary>
        /// Join the input string values using the separator and return the resulting string.
        /// </summary>
        public static string Join<T>(string separator, IEnumerable<T> values)
        {
            if (values == null)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            bool addedFirst = false;
            foreach (T value in values)
            {
                if (addedFirst)
                {
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
        /// Join the input string values using a comma separator and English grammar.
        /// </summary>
        public static string JoinCommaEnglish<T>(IEnumerable<T> values)
        {
            if (values == null)
            {
                return string.Empty;
            }
            int numValues = CollectionUtils.Count(values);
            StringBuilder sb = new StringBuilder();
            int currentIndex = 0;
            foreach (T value in values)
            {
                if (currentIndex > 0)
                {
                    if (numValues == 2)
                    {
                        sb.Append(" and ");
                    }
                    else if (currentIndex == (numValues - 1))
                    {
                        sb.Append(", and ");
                    }
                    else
                    {
                        sb.Append(", ");
                    }
                }
                if (value != null)
                {
                    sb.Append(value.ToString());
                }
                else
                {
                    sb.Append(string.Empty);
                }
                ++currentIndex;
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
            while (index > 0)
            {
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
        public static string FirstWord(string text)
        {
            if (text == null)
            {
                return null;
            }
            text = text.Trim();
            int curIndex = 0;
            foreach(char curChar in text)
            {
                if (char.IsWhiteSpace(curChar) || char.IsPunctuation(curChar))
                {
                    break;
                }
                ++curIndex;
            }
            if (curIndex == 0)
            {
                return null;
            }
            return text.Substring(0, curIndex);
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
        public static string LastSubstringDelimitedBy(string text, string delimeter)
        {
            if (!string.IsNullOrEmpty(text))
            {
                int index = text.LastIndexOf(delimeter);
                if (index >= 0)
                {
                    if (index == (text.Length - 1))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return text.Substring(index + 1);
                    }
                }
            }
            return text;
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
            if (string.IsNullOrEmpty(replaceString))
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
        public static string GetStringOrNull(object value)
        {
            if (value == null)
            {
                return null;
            }
            string rtnVal = value.ToString();
            return string.IsNullOrEmpty(rtnVal) ? null : rtnVal;
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
        public static int IndexOfAny(string testString, string[] anyOf, out int anyOfIndex)
        {
            return IndexOfAny(testString, anyOf, 0, (testString == null) ? 0 : testString.Length,
                              StringComparison.CurrentCulture, out anyOfIndex);
        }
        public static int IndexOfAny(string testString, string[] anyOf, StringComparison comparisonType,
                                     out int anyOfIndex)
        {
            return IndexOfAny(testString, anyOf, 0, (testString == null) ? 0 : testString.Length,
                              comparisonType, out anyOfIndex);
        }
        public static int IndexOfAny(string testString, string[] anyOf, int startIndex, int count,
                                     StringComparison comparisonType, out int anyOfIndex)
        {
            anyOfIndex = -1;
            if (string.IsNullOrEmpty(testString) || CollectionUtils.IsNullOrEmpty(anyOf))
            {
                return -1;
            }
            int minIndex = int.MaxValue;
            int curAnyOfIndex = 0;
            foreach (string findString in anyOf)
            {
                int index = testString.IndexOf(findString, startIndex, count, comparisonType);
                if (index >= 0)
                {
                    if (minIndex > index)
                    {
                        minIndex = index;
                        anyOfIndex = curAnyOfIndex;
                    }
                }
                ++curAnyOfIndex;
            }
            return (minIndex == int.MaxValue) ? -1 : minIndex;
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
                else
                {
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
        public static bool HasUppercaseChar(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            foreach (char character in text)
            {
                if (char.IsUpper(character))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool HasNumericChar(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            foreach (char character in text)
            {
                if (char.IsNumber(character))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<string> SplitAndReallyRemoveEmptyEntries(string stringToSplit, params char[] separators)
        {
            stringToSplit = stringToSplit.Trim();
            if (string.IsNullOrEmpty(stringToSplit))
            {
                return new List<string>();
            }
            List<string> list =
                new List<string>(stringToSplit.Split(separators, StringSplitOptions.RemoveEmptyEntries));

            TrimAndRemoveEmptyEntries(list);

            return list;
        }
        /// <summary>
        /// Trim all strings in the list and remove any strings that are null or empty.
        /// </summary>
        /// <param name="list"></param>
        public static void TrimAndRemoveEmptyEntries(List<string> list)
        {
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                return;
            }
            for (int i = list.Count - 1; i >= 0; --i)
            {
                string value = list[i];
                if (value == null)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    value = value.Trim();
                    if (value.Length == 0)
                    {
                        list.RemoveAt(i);
                    }
                    else
                    {
                        list[i] = value;
                    }
                }
            }
        }
        public static bool HasRepetitiveChars(string text, int minRepetitiveCount)
        {
            if (string.IsNullOrEmpty(text) || (text.Length < minRepetitiveCount))
            {
                return false;
            }
            if (minRepetitiveCount < 2)
            {
                return true;
            }
            if (text.Length < 2)
            {
                return false;
            }
            int repetitionCount = 1;
            for (int i = 1; i < text.Length; ++i)
            {
                if (text[i] == text[i - 1])
                {
                    if (++repetitionCount >= minRepetitiveCount)
                    {
                        return true;
                    }
                }
                else
                {
                    repetitionCount = 1;
                }
            }
            return false;
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

        private static System.Security.Cryptography.SHA256 s_Hasher = new System.Security.Cryptography.SHA256Managed();
        public static Int64 HashCode64(string text)
        {
            Int64 hashCode = 0;
            if (!string.IsNullOrEmpty(text))
            {
                //Unicode Encode Covering all characterset
                byte[] byteContents = Encoding.UTF8.GetBytes(text);
                byte[] hashText = s_Hasher.ComputeHash(byteContents);
                Int64 h1 = BitConverter.ToInt64(hashText, 0);
                Int64 h2 = BitConverter.ToInt64(hashText, 8);
                Int64 h3 = BitConverter.ToInt64(hashText, 16);
                Int64 h4 = BitConverter.ToInt64(hashText, 24);
                hashCode = h1 ^ h2 ^ h3 ^ h4;
            }
            return (hashCode);
        }
    }
}
