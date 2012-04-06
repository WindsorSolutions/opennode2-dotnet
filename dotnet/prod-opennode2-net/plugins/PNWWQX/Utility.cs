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

            private bool m_isValid;
            private DateTime m_minDate;
            private DateTime m_maxDate;

            /// <summary>
            /// MinMaxDate
            /// </summary>
            /// <param name="minDate"></param>
            /// <param name="maxDate"></param>
            public MinMaxDate(string minDate, string maxDate)
            {

                try 
                {

                    if (minDate.Equals(string.Empty))
                    {
                        m_minDate = DateTime.Parse("1/1/1753");
                    } 
                    else
                    {
                        m_minDate = DateTime.Parse(minDate);
                    }

                    if (maxDate.Equals(string.Empty))
                    {
                        m_maxDate = DateTime.Parse("12/31/9999");
                    } 
                    else
                    {
                        m_maxDate = DateTime.Parse(maxDate);
                    }

                    m_isValid = true;

                }
                catch
                {
                    m_isValid = false;
                    throw new Exception("One of the provided dates is not valid. "
                        + "Dates must be valid or omitted.");
                }

            }

            public bool isValid 
            {
                get { return m_isValid; }
            }

            public DateTime minDate 
            {
                get { return m_minDate; }
            }

            public DateTime maxDate 
            {
                get { return m_maxDate; }
            }

        }



	

        /// <summary>
        /// LatLong
        /// </summary>
        public class LatLong 
        {

            private bool m_isValid;
            private decimal m_minLat;
            private decimal m_minLong;
            private decimal m_maxLat;
            private decimal m_maxLong;

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

                    //Asssumes all or none value must be provided
                    if (
                        (minLat.Equals(string.Empty)) &&
                        (minLong.Equals(string.Empty)) &&
                        (maxLat.Equals(string.Empty)) &&
                        (maxLong.Equals(string.Empty))
                        )
                    {
                        //These should be inclusve of all db
                        //select  
                        //    Min(LatitudeMeasure) AS minLat,
                        //    Min(LongitudeMeasure) AS minLong,
                        //    Max(LatitudeMeasure) AS maxLat,
                        //    Max(LongitudeMeasure) AS maxLong
                        //from PNWWQX_XtraJoinTable
                        m_isValid = true;
                        m_minLat = 0;
                        m_minLong = 0;
                        m_maxLat = 0;
                        m_maxLong = 0;
                    } 
                    else
                    {
                        m_minLat = decimal.Parse(minLat);
                        m_minLong = decimal.Parse(minLong);
                        m_maxLat = decimal.Parse(maxLat);
                        m_maxLong = decimal.Parse(maxLong);
                        m_isValid = true;
                    }

                }
                catch
                {
                    m_isValid = false;
                    throw new Exception("Either both min and max Lat/Longs must "
                        + "be provided or all four values must be omitted.");
                }

            }

            public bool isValid 
            {
                get { return m_isValid; }
            }

            public decimal minLat 
            {
                get { return m_minLat; }
            }

            public decimal minLong 
            {
                get { return m_minLong; }
            }

            public decimal maxLat 
            {
                get { return m_maxLat; }
            }

            public decimal maxLong 
            {
                get { return m_maxLong; }
            }
        }

        #endregion
	}
}
