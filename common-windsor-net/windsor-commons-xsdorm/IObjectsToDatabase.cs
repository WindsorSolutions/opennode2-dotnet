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
using System.Reflection;
using Spring.Data.Common;
using Windsor.Commons.Spring;
using System.Collections;

namespace Windsor.Commons.XsdOrm
{
    public interface IObjectsToDatabase
    {
        void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao);

        void BuildDatabase(Type objectToSaveType);

        void BuildDatabaseForAllBaseDataTypes(Type referenceType);

        void BuildDatabaseForAllBaseDataTypes(Type referenceType, SpringBaseDao baseDao);

        /// <summary>
        /// Save the input object to the database.  Returns a list of table names and 
        /// insert row counts for each table.
        /// </summary>
        Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao);

        Dictionary<string, int> SaveToDatabase(object objectToSave);

        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, bool deleteAllBeforeSave);

        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                  bool deleteAllBeforeSave);

        Dictionary<string, int> SaveAllToDatabase(IEnumerable objectsToSave, SpringBaseDao baseDao);

        int DeleteAllFromDatabase(Type objectType, SpringBaseDao baseDao);

        int DeleteAllFromDatabase(Type objectType);

        string GetTableNameForType(Type objectType);

        string GetPrimaryKeyNameForType(Type objectType);

        object GetPrimaryKeyValueForObject(object obj);
    }

    public interface IBeforeSaveToDatabase
    {
        void BeforeSaveToDatabase();
    }
    public interface ICanSaveToDatabase
    {
        bool CanSaveToDatabase(IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao);
    }
}
