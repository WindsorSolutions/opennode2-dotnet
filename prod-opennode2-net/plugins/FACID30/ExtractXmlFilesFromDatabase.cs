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
    public class ExtractXmlFilesFromDatabase : QuerySolicitProcessorBase, ITaskProcessor
    {
        protected const string PARAM_XML_FOLDER_PATH = "XmlFolderPath";
        protected const string PARAM_ADD_HEADER = "AddHeader";
        protected string _xmlFolderPath;

        public ExtractXmlFilesFromDatabase()
        {
        }

        protected override void LazyInit()
        {
            base.LazyInit();
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            GetParameter<string>(_dataRequest, PARAM_XML_FOLDER_PATH, 0, out _xmlFolderPath);
        }
        public void ProcessTask(string requestId)
        {
            ProcessRequestInit(requestId);

            if (!Directory.Exists(_xmlFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The folder \"{0}\" does not exist", _xmlFolderPath));
            }

            AppendAuditLogEvent("Extracting files from the staging database into the folder \"{0}\" ", _xmlFolderPath);

            ExtractXmlFiles<FacilityDetailsDataType>();
            ExtractXmlFiles<FacilityInterestDataType>();
            ExtractXmlFiles<FacilityIndexDataType>();
        }
        protected void ExtractXmlFiles<T>()
        {
            try
            {
                List<T> objects = _objectsFromDatabase.LoadFromDatabase<T>(_baseDao, null);
                if (CollectionUtils.IsNullOrEmpty(objects))
                {
                    AppendAuditLogEvent("Didn't find any objects of type \"{0}\" in the staging database", typeof(T).Name);
                    return;
                }
                AppendAuditLogEvent("Found {0} object(s) of type \"{1}\" in the staging database", objects.Count.ToString(),
                                    typeof(T).Name);

                foreach (T obj in objects)
                {
                    try
                    {
                        string pk = ReflectionUtils.GetFieldOrPropertyValueByName<string>(obj, "PK");
                        string fileName = string.Format("{0}_{1}.xml", typeof(T).Name, pk);
                        AppendAuditLogEvent("Serializing content to file \"{0}\"", fileName);

                        string filePath = Path.Combine(_xmlFolderPath, fileName);
                        SaveHeaderDocument(obj, filePath);
                    }
                    catch (Exception e)
                    {
                        AppendAuditLogEvent("Failed to serialize content: {0}", 
                                            ExceptionUtils.GetDeepExceptionMessage(e));
                    }
                }
            }
            catch (Exception e2)
            {
                AppendAuditLogEvent("Failed to load objects of type \"{0}\" from the staging database: {1}",
                                    typeof(T).Name, ExceptionUtils.GetDeepExceptionMessage(e2));
            }
        }
    }
}
