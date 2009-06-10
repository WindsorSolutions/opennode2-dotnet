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
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Reflection;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.SDWIS
{

    public enum SdwisServiceParameterType
    {
        SubmitEndpointUri
    }

    [Serializable]
    public class SdwisSubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private IDocumentManager _documentManager;
        private ISettingsProvider _settingsProvider;
        private ITransactionManager _transactionManager;
        #endregion

        public SdwisSubmissionProcessor()
        {
            //Load Parameters
            ConfigurationArguments.Add(SdwisServiceParameterType.SubmitEndpointUri.ToString(),
                "https://cdxnode.epa.gov/cdx/services/NetworkNodePortType_V10");
        }

        protected void LazyInit()
        {
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetServiceImplementation(out _transactionManager);
        }
        private void WriteOut(string message)
        {
            LOG.Debug(message);
            AppendAuditLogEvent(message);
        }

        private string WriteOut(string message, params object[] args)
        {
            string parsedMessgae = string.Format(message, args);
            LOG.Debug(parsedMessgae);
            AppendAuditLogEvent(parsedMessgae);
            return parsedMessgae;
        }

        /// <summary>
        /// Return the Query, Solicit, or Execute data service parameters for specified data service.
        /// This method should NOT call GetServiceImplementation().
        /// </summary>
        public override IList<TypedParameter> GetDataServiceParameters(string serviceName, out DataServicePublishFlags publishFlags)
        {
            publishFlags = DataServicePublishFlags.PublishToEndpointVersion11And20;
            return null;
        }

        /// <summary>
        /// ProcessSubmit
        /// </summary>
        /// <param name="transactionId"></param>
        public void ProcessSubmit(string transactionId)
        {
            try
            {
                LazyInit();

                WriteOut("Runtime arguments:");
                foreach (string param in Enum.GetNames(typeof(SdwisServiceParameterType)))
                {
                    WriteOut("{0} = {1}; ", param, ConfigurationArguments[param]);
                }

                WriteOut("Getting documents:");
                IList<Document> documents = _documentManager.GetDocuments(transactionId, true);
                List<string> documentPaths = new List<string>();

                string tempDirPath = Path.Combine(_settingsProvider.TempFolderPath, Guid.NewGuid().ToString());
                WriteOut("Creating temp. directory: " + tempDirPath);
                Directory.CreateDirectory(tempDirPath);

                foreach (Document doc in documents)
                {
                    WriteOut("Doc: {0} ({1}); ", doc.DocumentName, doc.Type);
                    string tempDocPath = Path.Combine(tempDirPath, doc.DocumentName);

                    WriteOut("Saving content: " + tempDocPath);
                    File.WriteAllBytes(tempDocPath, doc.Content);
                    documentPaths.Add(tempDocPath);
                }

                string endpointUrl = ConfigurationArguments[SdwisServiceParameterType.SubmitEndpointUri.ToString()];
                WriteOut("endpointUrl: {0}; ", endpointUrl);

                string resultTranId = null;

                EndpointVersionType endpointVersion;
                using (INodeEndpointClient client = _nodeEndpointClientFactory.Make(endpointUrl, EndpointVersionType.EN11))
                {
                    WriteOut("endpoint client created: {0}; ", client);


                    //Set up client and submit the comrpessed file
                    WriteOut("submitting documents...");
                    resultTranId = client.Submit("SDWIS", null, documentPaths);
                    endpointVersion = client.Version;
                }

                if (string.IsNullOrEmpty(resultTranId))
                {
                    throw new ApplicationException("Node client did not return any transaction!");
                }

                _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                    WriteOut("Submission to: {0} resulted in: {1}", endpointUrl, resultTranId), true);

                _transactionManager.SetNetworkId(transactionId, resultTranId, endpointVersion,
                                                 endpointUrl);

                WriteOut("Done processing submission");

            }
            catch (Exception ex)
            {
                LOG.Error("Error while processing submission:", ex);
                throw new ApplicationException("Error while processing submission:", ex);
            }


        }

    }
}
