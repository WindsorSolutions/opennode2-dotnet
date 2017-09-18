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

namespace Windsor.Commons.Core
{
    public static class DateTimeUtils
    {
        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 0);
        }
        public static bool TryParseNowDate(string value, out DateTime dateTime, out string dateFormatString)
        {
            dateFormatString = null;
            if (DateTime.TryParse(value, out dateTime))
            {
                return true;
            }
            else
            {
                return TryParseNowDateExact(value, out dateTime, out dateFormatString);
            }
        }
        public static bool TryParseNowDateExact(string value, out DateTime dateTime, out string dateFormatString)
        {
            dateFormatString = null;
            const string NOW_PREFIX = "NOW";
            string trimmedValue = value.Trim();
            string valueUpper = trimmedValue.ToUpper();
            if (valueUpper.StartsWith(NOW_PREFIX))
            {
                const string NOW_UNDERSCORE_PREFIX = NOW_PREFIX + "_";
                if (valueUpper.StartsWith(NOW_UNDERSCORE_PREFIX))
                {
                    dateFormatString = trimmedValue.Substring(NOW_UNDERSCORE_PREFIX.Length);
                    var endIndex = dateFormatString.IndexOfAny(new char[] { ' ', '-', '+' });
                    if (endIndex < 0)
                    {
                        endIndex = dateFormatString.Length;
                    }
                    dateFormatString = dateFormatString.Substring(0, endIndex);
                    valueUpper = valueUpper.Remove(NOW_PREFIX.Length, endIndex + 1);
                }
                if (valueUpper == NOW_PREFIX)
                {
                    dateTime = DateTime.Now;
                    return true;
                }
                string[] tokens = value.Split('-');
                int subtractDays;
                if ((tokens.Length == 2) && int.TryParse(tokens[1], out subtractDays))
                {
                    dateTime = DateTime.Now.AddDays(-subtractDays);
                    return true;
                }
                tokens = value.Split('+');
                int addDays;
                if ((tokens.Length == 2) && int.TryParse(tokens[1], out addDays))
                {
                    dateTime = DateTime.Now.AddDays(addDays);
                    return true;
                }
            }
            dateTime = DateTime.MinValue;
            return false;
        }
    }
}
