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
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{
    /// <summary>
    /// Summary description for Utility.
    /// </summary>
    public class Utility
    {

        #region Traps
        public static string toStr(object val)
        {
            return (val == DBNull.Value) ? null : val.ToString().Trim();
        }

        public static DateTime toDT(object val)
        {
            try
            {
                return DateTime.Parse(val.ToString());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static bool toBool(object val)
        {
            if ((val == null) || (val == DBNull.Value))
            {
                return false;
            }

            string valStr = val.ToString().ToLower().Trim();

            if ((valStr == "y") || (valStr == "1") || (valStr.StartsWith("t")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static decimal toDecimal(object val)
        {
            return (val == DBNull.Value) ? Decimal.Zero : System.Decimal.Parse(val.ToString());
        }

        public static int toInt(object val)
        {
            return (val == DBNull.Value) ? 0 : int.Parse(val.ToString());
        }


        public static int isInt(string val)
        {
            try
            {
                return int.Parse(val);
            }
            catch
            {
                return 0;
            }
        }

        #endregion



        #region Validators


        /// <summary>
        /// MinMaxDate
        /// </summary>
        public class MinMaxDate
        {

            private DateTime? m_minDate;
            private DateTime? m_maxDate;

            /// <summary>
            /// MinMaxDate
            /// </summary>
            /// <param name="minDate"></param>
            /// <param name="maxDate"></param>
            public MinMaxDate(string minDate, string maxDate)
            {

                try
                {
                    if (!string.IsNullOrEmpty(minDate))
                    {
                        m_minDate = DateTime.Parse(minDate);
                    }

                    if (!string.IsNullOrEmpty(maxDate))
                    {
                        m_maxDate = DateTime.Parse(maxDate);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Date parameter could not be parsed: {0}",
                                                      ExceptionUtils.GetDeepExceptionMessageOnly(ex)));
                }

            }

            public DateTime? minDate
            {
                get
                {
                    return m_minDate;
                }
            }

            public DateTime? maxDate
            {
                get
                {
                    return m_maxDate;
                }
            }

        }





        /// <summary>
        /// LatLong
        /// </summary>
        public class LatLong
        {

            private decimal? m_minLat;
            private decimal? m_minLong;
            private decimal? m_maxLat;
            private decimal? m_maxLong;

            /// <summary>
            /// LatLong
            /// </summary>
            /// <param name="minLat"></param>
            /// <param name="minLong"></param>
            /// <param name="maxLat"></param>
            /// <param name="maxLong"></param>
            public LatLong(string minLat, string minLong, string maxLat, string maxLong)
            {

                try
                {
                    if (!string.IsNullOrEmpty(minLat))
                    {
                        m_minLat = decimal.Parse(minLat);
                    }
                    if (!string.IsNullOrEmpty(minLong))
                    {
                        m_minLong = decimal.Parse(minLong);
                    }
                    if (!string.IsNullOrEmpty(maxLat))
                    {
                        m_maxLat = decimal.Parse(maxLat);
                    }
                    if (!string.IsNullOrEmpty(maxLong))
                    {
                        m_maxLong = decimal.Parse(maxLong);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Latitude or longitude parameter could not be parsed: {0}",
                                                      ExceptionUtils.GetDeepExceptionMessageOnly(ex)));
                }

            }

            public decimal? minLat
            {
                get
                {
                    return m_minLat;
                }
            }

            public decimal? minLong
            {
                get
                {
                    return m_minLong;
                }
            }

            public decimal? maxLat
            {
                get
                {
                    return m_maxLat;
                }
            }

            public decimal? maxLong
            {
                get
                {
                    return m_maxLong;
                }
            }
        }

        #endregion
    }
}
