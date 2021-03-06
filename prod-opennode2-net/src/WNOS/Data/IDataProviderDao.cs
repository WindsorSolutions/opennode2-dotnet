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
using System.Data;
using Windsor.Node2008.WNOSDomain;
using System.Collections.Generic;
using Windsor.Node2008.WNOSUtility;
namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Data provider DAO interface.  The data provider DAO provides access to persistent data providers used by WNOS.
    /// </summary>
    public interface IDataProviderDao
    {
        /// <summary>
        /// Get a list of all data providers registered with WNOS.
        /// </summary>
        ICollection<DataProviderInfo> Get();

        /// <summary>
        /// Get a list of all user-defined, friendly data provider names.
        /// </summary>
        ICollection<string> GetAllDataSourceNames();

        /// <summary>
        /// Get a data provider instance by name.
        /// </summary>
        DataProviderInfo GetByName(string name);

        /// <summary>
        /// Get a data provider instance by id.
        /// </summary>
        DataProviderInfo GetById(string id);

        /// <summary>
        /// Persist the data provider.
        /// </summary>
        void Save(DataProviderInfo item);

        /// <summary>
        /// Delete the data provider.
        /// </summary>
        void Delete(DataProviderInfo item);

        /// <summary>
        /// Get the name of the root table where data providers are persisted.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Get the semicolon delimited list of data provider columns used for mapping column values
        /// to a data provider instance.
        /// </summary>
        string MapDataProviderColumns { get; }

        /// <summary>
        /// Mapping column values to a data provider instance.
        /// </summary>
        DataProviderInfo MapDataProvider(IDataReader reader);
    }
}
