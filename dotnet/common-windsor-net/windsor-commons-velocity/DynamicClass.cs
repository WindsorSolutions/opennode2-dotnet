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

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Windsor.Commons.Velocity
{
    public class DynamicClass : Dictionary<string, object>, IDynamicClass
    {

        private string MakeCleanKey(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                return null;
            }
            else
            {
                return key.Trim().ToLower();
            }
        }

        public new void Add(string key, object value)
        {
            base.Add(MakeCleanKey(key), value);
        }


        #region IDynamicClass Members



        public string GetClean(string key, params string[] badStrings)
        {
            string result = String.Format("{0}", Get(key));

            if (!String.IsNullOrEmpty(result) && badStrings != null)
            {
                foreach (string s in badStrings)
                {
                    result = result.Replace(s, String.Empty);
                }
            }

            return result;
        }

        public object Get(string key)
        {
            string cleanKey = MakeCleanKey(key);
            if (String.IsNullOrEmpty(cleanKey) || !ContainsKey(cleanKey))
            {
                return null;
            }
            else
            {
                object val = base[cleanKey];

                if (val != null && val.GetType().Equals(typeof(string)))
                {
                    val = HttpUtility.HtmlEncode(val.ToString());
                }

                return val;
            }
        }

        #endregion
    }
}
