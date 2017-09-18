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
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using System.ComponentModel;
using Windsor.Commons.Spring;
using Spring.Data;
using Spring.Data.Common;
using Spring.Core;
using Spring.Data.Support;
using System.Collections;

namespace Windsor.Commons.Velocity
{
    public class DaoTemplateHelper : SpringBaseDao, IDaoTemplateHelper
    {

        
        private DateTime _startTime;
        private readonly string _name;
        private object _result;


        public DaoTemplateHelper(IDbProvider provider, string name)
            : base(provider, typeof(RealNullDataMapper))
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), provider, name);
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            if (name.Contains(" ") || !Char.IsLetter(name.ToCharArray()[0]))
            {
                throw new FormatException("name must start with a letter and it can't have spaces");
            }
            _name = name;
        }

        #region IDaoTemplateHelper Members


        public string Name
        {
            get { return _name; }
        }


        public void StartStopWatch()
        {
            _startTime = DateTime.Now;
            LOG.Debug("Start: " + _startTime);
        }

        public void PrintElapsedTime()
        {
            TimeSpan span = DateTime.Now - _startTime;
            LOG.Debug("Elapsed: " + span);
        }

        public void Print(params object[] val)
        {
            if (val != null)
            {
                foreach (object obj in val)
                {
                    LOG.Debug(obj);
                }
            }
        }

        public void Print(string pattern, params object[] val)
        {
            LOG.Debug(pattern, val);
        }

        public IList<IDynamicClass> GetList(string sql, params object[] args)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), sql, args);


            IDbParameters pars = null;

            sql = LoadGenericParameters(sql, out pars, args);

            IList<IDynamicClass> list = new List<IDynamicClass>();

            AdoTemplate.QueryWithRowCallbackDelegate(CommandType.Text, sql,
                delegate(IDataReader reader)
                {

                    DynamicClass dic = new DynamicClass();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dic.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    list.Add(dic);

                }, pars);

            return list;

        }



        public IDynamicClass GetObject(string sql, params object[] args)
        {
            LOG.DebugEnter(MethodBase.GetCurrentMethod(), sql, args);

            IList<IDynamicClass> list = GetList(sql, args);

            if (list == null || list.Count == 0)
            {
                return null;
            }

            if (list.Count > 1)
            {
                throw new ApplicationException("More than one row returned");
            }

            return list[0];

        }

        #endregion


        public class RealNullDataMapper : NullMappingDataReader
        {
            public override string GetString(int i)
            {
                if (base.IsDBNull(i))
                {
                    return null;
                }
                else
                {
                    return base.GetString(i);
                }
            }
        }





        #region IDaoTemplateHelper Members


        public void SetResult(object val)
        {
            _result = val;
        }

        public object GetResult()
        {
            return _result;
        }

        #endregion
    }
}
