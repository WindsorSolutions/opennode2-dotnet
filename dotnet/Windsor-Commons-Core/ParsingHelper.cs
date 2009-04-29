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
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
    public static class ParsingHelper
    {
        /// <summary>
        /// CheckForAlpha
        /// </summary>
        /// <param name="value"></param>
        public static void CheckForAlpha(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ApplicationException("Null value");
            }

            foreach (char c in value.ToCharArray())
            {
                if (!Char.IsLetter(c))
                {
                    throw new ApplicationException("Value contains non-alpha characters");
                }
            }
        }

        /// <summary>
        /// Silent parse of string to int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToIntSilent(string value, int defaultValue)
        {
            if (IsEmpty(value))
            {
                return 0;
            }
            else
            {
                int result = defaultValue;
                int.TryParse(value, out result);
                return result;
            }
        }

        /// <summary>
        /// Convert array of string to a qualified string using "," deliminator and "'" qualifier
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToQualifiedString<T>(IList<T> values)
        {
            if (values == null || values.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("'{0}'", StringUtils.Join("','", values));
            }
        }

        /// <summary>
        /// Convert array of string to a qualified string using "," deliminator and "'" qualifier
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToQualifiedString(IEnumerable<string> values)
        {
            return string.Format("'{0}'", StringUtils.Join("','", values));
        }

        /// <summary>
        /// Indicates whether the object is NULL or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(object value)
        {
            return (value == DBNull.Value ||
                    value == null ||
                    value.ToString().Trim().Equals(String.Empty));
        }

        public static void ValidateKey(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Code cannot be empty.");
            }

            foreach (char c in value)
            {
                if (!(Char.IsLetterOrDigit(c) || (c == ' ') || (c == '_')))
                {
                    throw new ArgumentException("Code can contain only letters, digits, or underscore characters.");
                }
            }
        }
    }
}
