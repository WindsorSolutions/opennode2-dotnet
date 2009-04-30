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
using System.Data;

namespace Windsor.Node2008.WNOSPlugin.NEI_DB
{

    public class Util
    {

        public static bool IsValidDateTime(object val, DateTime mustBeGreaterThanDate)
        {
            try
            {
                if (object.ReferenceEquals(val, DBNull.Value))
                {
                    return false;
                }
                else
                {
                    if (mustBeGreaterThanDate == DateTime.MinValue)
                    {
                        return false;
                    }
                    else
                    {
                        return (DateTime.Parse(val.ToString()) >= mustBeGreaterThanDate);
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidBool(object field)
        {
            if (object.ReferenceEquals(field, DBNull.Value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ToBool(object field)
        {
            if (object.ReferenceEquals(field, DBNull.Value))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(field);
            }
        }


        private static string CleanStr(string field)
        {
            //Clean for Xml
            string strClean = null;
            foreach (char c in field.ToCharArray())
            {
                if (char.IsControl(c))
                {
                }
                //Do nothing
                else
                {
                    strClean += c;
                }
            }
            return strClean;
        }

        public static string ToStr(object field)
        {
            if ((object.ReferenceEquals(field, DBNull.Value)) | (field.ToString() == ""))
            {
                return null;
            }
            else
            {
                return CleanStr(field.ToString());
            }
        }

        public static bool IsValidInt(object field, bool isAbs)
	{

		if ((object.ReferenceEquals(field, DBNull.Value)) | (field.ToString().Equals(string.Empty))) {
			return false;
		}
		else {
			foreach ( char c in field.ToString().ToCharArray()) {
				if (!char.IsNumber(c)) {
					return false;
				}
			}
		}
		return true;
	}

        public static DateTime ToDateTime(object field)
        {
            if (object.ReferenceEquals(field, DBNull.Value))
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(field);
            }
        }

        public static bool isValidDecimal(object field)
        {
            if ((object.ReferenceEquals(field, DBNull.Value)) | (field.ToString().Equals(string.Empty)))
            {
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDouble(field);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static double ToDecimal(object field)
        {
            if (object.ReferenceEquals(field, DBNull.Value))
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(field);
            }
        }

        public static string ToDecimal(object field, Int32 maxLen)
        {
            if (object.ReferenceEquals(field, DBNull.Value))
            {
                return "0";
            }
            else
            {
                string val = ToStr(field);
                if ((val.Length > maxLen))
                {
                    val = val.Substring(0, 10);
                }
                return val;
            }
        }

    }

}
