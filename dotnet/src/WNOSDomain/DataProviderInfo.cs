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

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object representing a named data provider (e.g., database connection).
    /// </summary>
    [Serializable]
    public class DataProviderInfo : AuditableIdentity
    {
        private string _name;
        private string _providerType;
        private string _connectionString;
        
        public DataProviderInfo() { }

        public DataProviderInfo(string code, string providerType, string connectionString)
        {
            _name = code;
            _providerType = providerType;
            _connectionString = connectionString;
        }
        /// <summary>
        /// The user-specified, friendly name for the data provider.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The connection string for the data provider.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// The type of the data provider (e.g., System.Data.SqlClient, OracleClient-2.0, etc.).
        /// </summary>
        public string ProviderType
        {
            get { return _providerType; }
            set { _providerType = value; }
        }
    }
}
