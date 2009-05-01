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
using System.Text.RegularExpressions;
using System.Text;

namespace Windsor.Commons.Core
{
    public static class ValidationHelper
    {

        public const string DEFAULT_URL_PATTERN = @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&%\$#\=~_\-]*)*$";
        public const string DEFAULT_EMAIL_PATTERN = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*";
        public const string DEFAULT_PASSWORD_PATTERN = "^(?![0-9]{6,12})[0-9a-zA-Z]{6,12}$";
        public const string DEFAULT_SINGLE_EMAIL_PATTERN = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        public const string STRICT_SINGLE_EMAIL_PATTERN = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";

        /// <summary>
        /// Checks if the URL is valid format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidUrl(string input)
        {
            return IsValidFormat(DEFAULT_URL_PATTERN, input, false);
        }

        /// <summary>
        /// Checks if the email is valid format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string input)
        {
            return IsValidFormat(DEFAULT_EMAIL_PATTERN, input, false);
        }

        /// <summary>
        /// Checks if the email is valid format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidSingleEmail(string input)
        {
            return IsValidFormat(DEFAULT_SINGLE_EMAIL_PATTERN, input, false);
        }

        /// <summary>
        /// Checks if the email is valid format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidSingleEmailStrict(string input)
        {
            return IsValidFormat(STRICT_SINGLE_EMAIL_PATTERN, input.ToUpper(), false);
        }

        /// <summary>
        /// Checks if the Password is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string input)
        {
            return IsValidFormat(DEFAULT_PASSWORD_PATTERN, input, false);
        }

        /// <summary>
        /// Checks if the value is valid format based on the reged
        /// </summary>
        /// <param name="regexp"></param>
        /// <param name="input"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>
        public static bool IsValidFormat(string regexp, string input, bool allowNull)
        {
            if (string.IsNullOrEmpty(input))
            {
                return allowNull;
            }

            Regex regExpObj = new Regex(regexp);
            return regExpObj.IsMatch(input);
        }
    
    }

}
