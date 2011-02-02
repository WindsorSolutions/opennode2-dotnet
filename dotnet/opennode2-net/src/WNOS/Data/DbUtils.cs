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

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Helper class for dealing with database operations.
    /// </summary>
    public static class DbUtils
    {
        public const string DB_TRUE = "Y";
        public const string DB_FALSE = "N";
        public static readonly DateTime DB_MIN_DATE = new DateTime(1800, 1, 1);
        public static readonly DateTime DB_MAX_DATE = new DateTime(2999, 1, 1);

        /// <summary>
        /// Convert a bool value to a database column value.
        /// </summary>
        public static string ToDbBool(bool val)
        {
            return (val) ? DB_TRUE : DB_FALSE;
        }

        /// <summary>
        /// Convert a database column value to a bool value.
        /// </summary>
        public static bool ToBool(string val)
        {
            return val != null && val.Trim().ToUpper() == DB_TRUE;
        }
        public static DateTime ToDbDate(DateTime val)
        {
            if (val == DateTime.MinValue)
            {
                return DB_MIN_DATE;
            }
            else if (val == DateTime.MaxValue)
            {
                return DB_MAX_DATE;
            }
            else
            {
                return val;
            }
        }
        public static DateTime ConstrainDate(DateTime date)
        {
            if (date < DB_MIN_DATE)
            {
                return DB_MIN_DATE;
            }
            else if (date > DB_MAX_DATE)
            {
                return DB_MAX_DATE;
            }
            else
            {
                return date;
            }
        }

        /// <summary>
        /// Constrain the input date to a valid database range.
        /// </summary>
        public static DateTime ToDate(DateTime val)
        {
            if (val == DB_MIN_DATE)
            {
                return DateTime.MinValue;
            }
            else if (val == DB_MAX_DATE)
            {
                return DateTime.MaxValue;
            }
            else
            {
                return val;
            }
        }
    }
}
