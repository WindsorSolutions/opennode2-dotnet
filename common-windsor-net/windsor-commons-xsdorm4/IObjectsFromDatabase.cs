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
using Spring.Data.Common;
using System.Data;
using Windsor.Commons.Spring;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm4
{
    public interface IObjectsFromDatabase
    {
        string GetTableNameForType(Type objectType, Type mappingAttributesType);
        string GetPrimaryKeyNameForType(Type objectType, Type mappingAttributesType);

        List<T> LoadFromDatabase<T>(SpringBaseDao baseDao, IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses, Type mappingAttributesType);
        IList LoadFromDatabase(Type typeToLoad, SpringBaseDao baseDao, IDictionary<string, DbAppendSelectWhereClause> appendSelectWhereClauses, Type mappingAttributesType);
    }
    public interface IAfterLoadFromDatabase
    {
        void AfterLoadFromDatabase(SpringBaseDao baseDao);
    }

    [Serializable]
    public class DbAppendSelectWhereClause
    {
        public DbAppendSelectWhereClause()
        {
        }
        public DbAppendSelectWhereClause(string selectWhereQuery, ICollection<IDataParameter> selectWhereParameters)
        {
            _selectWhereQuery = selectWhereQuery;
            _selectWhereParameters = selectWhereParameters;
        }
        public DbAppendSelectWhereClause(SpringBaseDao baseDao, string selectJDBCWhereQuery, params object[] queryValues)
        {
            ICollection<IDataParameter> parameters;
            _selectWhereQuery = baseDao.LoadGenericParameters(selectJDBCWhereQuery, out parameters, queryValues);
            _selectWhereParameters = parameters;
        }
        public DbAppendSelectWhereClause(SpringBaseDao baseDao, string selectJDBCWhereQuery, IList<object> queryValues)
        {
            ICollection<IDataParameter> parameters;
            _selectWhereQuery = baseDao.LoadGenericParametersFromList(selectJDBCWhereQuery, out parameters, queryValues);
            _selectWhereParameters = parameters;
        }
        public string SelectWhereQuery
        {
            get
            {
                return _selectWhereQuery;
            }
            set
            {
                _selectWhereQuery = value;
            }
        }
        public ICollection<IDataParameter> SelectWhereParameters
        {
            get
            {
                return _selectWhereParameters;
            }
            set
            {
                _selectWhereParameters = value;
            }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        private string _selectWhereQuery;
        private ICollection<IDataParameter> _selectWhereParameters;
    }
}
