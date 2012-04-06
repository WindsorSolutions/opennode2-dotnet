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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.FACID30
{
    [Serializable]
    public class LoadXmlFileIntoDatabase : FACIDPluginBase, ITaskProcessor
    {
        protected const string PARAM_XML_FILE_PATH = "XmlFilePath";
        protected string _xmlFilePath;

        protected IObjectsToDatabase _objectsToDatabase;

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _objectsToDatabase);
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter<string>(_dataRequest, PARAM_XML_FILE_PATH, 0, out _xmlFilePath);
        }
        public void ProcessTask(string requestId)
        {
            ProcessRequestInit(requestId);

            if (!File.Exists(_xmlFilePath))
            {
                throw new FileNotFoundException(string.Format("The file \"{0}\" was not found", _xmlFilePath));
            }

            AppendAuditLogEvent("Loading file \"{0}\" into the database", _xmlFilePath);

            XmlElement element = null;
            XmlDocument doc = new XmlDocument();
            using (Stream fileStream = File.OpenRead(_xmlFilePath))
            {
                using (XmlReader reader = new XmlTextReader(fileStream))
                {
                    doc.Load(reader);
                    XmlNodeList list = doc.GetElementsByTagName("Payload");
                    if (!CollectionUtils.IsNullOrEmpty(list))
                    {
                        XmlNode node = list.Item(0);
                        element = node.FirstChild as XmlElement;
                    }
                    if (element == null)
                    {
                        element = doc.DocumentElement;
                    }
                }
            }

            object objectToSave = TryLoadObject<FacilityDetailsDataType>(element);
            if (objectToSave == null)
            {
                throw new InvalidDataException(string.Format("The file \"{0}\" does not contain any valid FACID30 types", _xmlFilePath));
            }

            AppendAuditLogEvent("Loaded object of type \"{0}\" from xml file", objectToSave.GetType().Name);

            AppendAuditLogEvent("Validating database staging tables ...");
            _objectsToDatabase.BuildDatabase(objectToSave.GetType(), _baseDao);

            AppendAuditLogEvent("Loading object into database staging tables ...");
            Dictionary<string, int> insertCounts = _objectsToDatabase.SaveToDatabase(objectToSave, _baseDao);

            AppendAuditLogEvent(GetRowCountsAuditString(insertCounts));

            AppendAuditLogEvent("Success, primary key: {0}!", ReflectionUtils.GetFieldOrPropertyValueByName<string>(objectToSave, "PK"));
        }
        protected object TryLoadObject<T>(XmlElement element)
        {
            try
            {
                T obj = _serializationHelper.Deserialize<T>(element);
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
       }
    }
}
