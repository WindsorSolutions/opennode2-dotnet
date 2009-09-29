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
using Spring.Data.Common;

namespace Windsor.Node2008.WNOSPlugin.SDWIS
{

    public enum SdwisRelayServiceParameterType
    {
        SubmitEndpointUri,
        SubmitUsername,
        SubmitPassword,
        HereEndpointUri,
        HereIsFacilitySource,
        HereSourceSystemName,
        HereFileNameFilter
    }

    public enum SdwisRelayServiceDataSourceType
    {
        HereDataSource
    }

    [Serializable]
    public class SdwisSubmissionRelayProcessor : BaseWNOSPlugin, ISubmitProcessor
    {
        public const string FLOW_NAME = "SDWIS";

        #region fields
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private INodeEndpointClientFactory _nodeEndpointClientFactory;
        private IDocumentManager _documentManager;
        private ISettingsProvider _settingsProvider;
        private ITransactionManager _transactionManager;
        #endregion

        public SdwisSubmissionRelayProcessor()
        {
            //Load Parameters
            ConfigurationArguments.Add(SdwisRelayServiceParameterType.SubmitEndpointUri.ToString(),
                "https://cdxnode.epa.gov/cdx/services/NetworkNodePortType_V10");

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.SubmitUsername.ToString(), null);

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.SubmitPassword.ToString(), null);

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.HereEndpointUri.ToString(), null);

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.HereIsFacilitySource.ToString(), null);

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.HereSourceSystemName.ToString(), null);

            ConfigurationArguments.Add(SdwisRelayServiceParameterType.HereFileNameFilter.ToString(), null);


            //Load Data Sources
            DataProviders.Add(SdwisRelayServiceDataSourceType.HereDataSource.ToString(), null);
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
                foreach (string param in Enum.GetNames(typeof(SdwisRelayServiceParameterType)))
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
                    WriteOut("Parsing document: {0} ({1}); ", doc.DocumentName, doc.Type);
                    string tempDocPath = Path.Combine(tempDirPath, doc.DocumentName);

                    WriteOut("Saving content: " + tempDocPath);
                    File.WriteAllBytes(tempDocPath, doc.Content);
                    documentPaths.Add(tempDocPath);
                }

                WriteOut("Parsing argument values...");
                
                string endpointUrl = GetConfigParameter(SdwisRelayServiceParameterType.SubmitEndpointUri.ToString());
                WriteOut(" endpoint url: {0}", endpointUrl);

                if (!string.IsNullOrEmpty(endpointUrl))
                {

                    string submitAsUser = GetConfigParameter(SdwisRelayServiceParameterType.SubmitUsername.ToString());
                    WriteOut(" submit user: {0}", submitAsUser);

                    string submitPassword = GetConfigParameter(SdwisRelayServiceParameterType.SubmitPassword.ToString());
                    WriteOut(" submit password: *********", submitPassword);

                    string resultTranId = null;

                    WriteOut("Creating endpoint client...");
                    INodeEndpointClient client = null;
                    if (!String.IsNullOrEmpty(submitAsUser) && !String.IsNullOrEmpty(submitPassword))
                    {
                        WriteOut("Using custom credentials");
                        client = _nodeEndpointClientFactory.Make(endpointUrl,
                            EndpointVersionType.EN11,
                            new AuthenticationCredentials(submitAsUser, submitPassword));
                    }
                    else
                    {
                        WriteOut("Using default credentials");
                        client = _nodeEndpointClientFactory.Make(endpointUrl,
                            EndpointVersionType.EN11);
                    }

                    WriteOut("Submitting documents...");
                    resultTranId = client.Submit(FLOW_NAME, null, documentPaths);

                    if (string.IsNullOrEmpty(resultTranId))
                    {
                        throw new ApplicationException("Node client did not return any transaction!");
                    }

                    _transactionManager.SetTransactionStatus(transactionId, CommonTransactionStatusCode.Completed,
                    WriteOut("Remote transaction Id: {1}", endpointUrl, resultTranId), true);

                    _transactionManager.SetNetworkId(transactionId, resultTranId, EndpointVersionType.EN11, endpointUrl);
                    WriteOut("Submission done...");
                }


                //*********************************************
                //HERE
                //*********************************************
                string hereEndpointUrl = GetConfigParameter(SdwisRelayServiceParameterType.HereEndpointUri.ToString());
                WriteOut("Here endpoint url: {0}", hereEndpointUrl);

                if (!string.IsNullOrEmpty(hereEndpointUrl))
                {

                    WriteOut("Initializing HERE process...");
                    WriteOut("Validating submitted file name...");
                    if (documentPaths.Count == 1)
                    {
                        string submittedFileName = Path.GetFileName(documentPaths[0]);
                        WriteOut("submittedFileName: {0}; ", submittedFileName);

                        string hereFileNameFilter = ValidateNonEmptyConfigParameter(SdwisRelayServiceParameterType.HereFileNameFilter.ToString());
                        WriteOut("hereFileNameFilter: {0}; ", hereFileNameFilter);

                        if (submittedFileName.IndexOf(hereFileNameFilter) > -1)
                        {

                            string hereIsFacilitySource = ValidateNonEmptyConfigParameter(SdwisRelayServiceParameterType.HereIsFacilitySource.ToString());
                            WriteOut("hereIsFacilitySource: {0}; ", hereIsFacilitySource);

                            bool isFacilitySource = false;
                            if (!bool.TryParse(hereIsFacilitySource, out isFacilitySource))
                            {
                                throw new ApplicationException(string.Format(
                                    "Unable to parse the {0} argument. Must be a valid bool expression.",
                                    hereIsFacilitySource));
                            }

                            string hereSourceSystemName = ValidateNonEmptyConfigParameter(SdwisRelayServiceParameterType.HereSourceSystemName.ToString());
                            WriteOut("hereSourceSystemName: {0}; ", hereSourceSystemName);

                            WriteOut("creating Here data access object...");
                            HereDao hereDao = new HereDao(ValidateDBProvider(SdwisRelayServiceDataSourceType.HereDataSource.ToString()));
                            WriteOut("hereDao: {0}; ", hereDao);

                            WriteOut("saving submission in Here...");
                            hereDao.SetResultData(transactionId, hereEndpointUrl, FLOW_NAME, isFacilitySource, hereSourceSystemName, true);

                        }
                        else
                        {
                            WriteOut("Submitted file name: {0} does match the filter: {1}",
                                submittedFileName, hereFileNameFilter);
                        }

                    }
                    else
                    {
                        WriteOut("Found more than one submission... HERE requires only one file!");
                    }
                }
                else if (string.IsNullOrEmpty(endpointUrl))
                {
                    throw new ArgumentException(string.Format("Please specify either \"{0}\" or \"{1}\" configuration parameters",
                                                              SdwisRelayServiceParameterType.SubmitEndpointUri.ToString(),
                                                              SdwisRelayServiceParameterType.HereEndpointUri.ToString()));
                }

            }
            catch (Exception ex)
            {
                LOG.Error("Error while processing submission:", ex);
                throw new ApplicationException("Error while processing submission:", ex);
            }


        }


    }
}
