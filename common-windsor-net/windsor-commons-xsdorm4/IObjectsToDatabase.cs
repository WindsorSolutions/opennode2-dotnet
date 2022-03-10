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
using Windsor.Commons.XsdOrm4.Implementations;

namespace Windsor.Commons.XsdOrm4
{
    public interface IObjectsToDatabase
    {
        void BuildDatabase(Type objectToSaveType, SpringBaseDao baseDao, Type mappingAttributesType);

        void BuildDatabase(Type objectToSaveType, Type mappingAttributesType);

        Dictionary<string, int> BuildAndSaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                          bool deleteAllBeforeSave, Type mappingAttributesType);

        /// <summary>
        /// Save the input object to the database.  Returns a list of table names and 
        /// insert row counts for each table.
        /// </summary>
        Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao, Type mappingAttributesType);

        Dictionary<string, int> SaveToDatabase(object objectToSave, SpringBaseDao baseDao,
                                               bool deleteAllBeforeSave, Type mappingAttributesType);

        Dictionary<string, int> SaveToDatabase(object objectToSave, bool deleteAllBeforeSave,
                                               Type mappingAttributesType);
        Dictionary<string, int> SaveToDatabase(object objectToSave, Type mappingAttributesType);

        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, bool deleteAllBeforeSave, Type mappingAttributesType);

        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                  bool deleteAllBeforeSave, Type mappingAttributesType);

        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                  bool deleteAllBeforeSave, Type mappingAttributesType,
                                                  bool checkToBuildDatabase);
        Dictionary<string, int> SaveToDatabase<T>(IEnumerable<T> objectsToSave, SpringBaseDao baseDao,
                                                  bool deleteAllBeforeSave, IMappingContext mappingContext,
                                                  bool checkToBuildDatabase);

        int DeleteAllFromDatabase(Type objectType, SpringBaseDao baseDao, Type mappingAttributesType);

        int DeleteAllFromDatabase(Type objectType, Type mappingAttributesType);

        string GetTableNameForType(Type objectType, Type mappingAttributesType);

        object GetPrimaryKeyValueForObject(object obj, MappingContext mappingContext);

        string GetPrimaryKeyNameForType(Type objectType, Type mappingAttributesType);

        object GetPrimaryKeyValueForObject(object obj, Type mappingAttributesType);
    }

    public interface IBeforeSaveToDatabase
    {
        void BeforeSaveToDatabase(IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao, IMappingContext mappingContext);
    }
    public interface ISaveInfoProvider
    {
        bool IsUpdateSave(SpringBaseDao baseDao, IMappingContext mappingContext);
    }
    public interface IBuildDatabaseInitValueProvider
    {
        IList<object> GetBuildInitValues(SpringBaseDao baseDao, IMappingContext mappingContext,
                                         out bool deleteAllBeforeInit);
    }
}
