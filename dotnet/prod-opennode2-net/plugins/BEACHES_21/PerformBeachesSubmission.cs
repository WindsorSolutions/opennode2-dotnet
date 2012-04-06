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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.BEACHES_21
{
    [Serializable]
    public class PerformBeachesSubmission : BasePerformBeachesSubmission
    {
        protected enum ConfigArgs
        {
            None,
            [Description("Submission Partner Name")]
            SubmissionPartnerName,
        }
        #region fields

        protected const string BEACHES_FLOW_NAME = "BEACHES";

        protected IPartnerManager _partnerManager;

        protected PartnerIdentity _epaPartnerNode;

        #endregion

        public PerformBeachesSubmission()
        {
            AppendConfigArguments<ConfigArgs>();
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _partnerManager);

            string epaPartnerName = GetConfigParameter(EnumUtils.ToDescription(ConfigArgs.SubmissionPartnerName));
            if (!string.IsNullOrEmpty(epaPartnerName))
            {
                _epaPartnerNode = _partnerManager.GetByName(epaPartnerName);
                if (_epaPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The node partner \"{0}\" with the name \"{1}\" specified for this service cannot be found",
                                                              EnumUtils.ToDescription(ConfigArgs.SubmissionPartnerName), epaPartnerName));
                }
            }
            else
            {
                AppendAuditLogEvent("WARNING: A {0} was not specified, so the generated BEACHES xml file will NOT be submitted, but it will be added to the transaction.",
                                    EnumUtils.ToDescription(ConfigArgs.SubmissionPartnerName));
            }
        }
        protected override void ValidateRequest(string requestId)
        {
            base.ValidateRequest(requestId);

            if (_epaPartnerNode == null)
            {
                // Cannot use submission history if there is no partner to submit to
                _useSubmissionHistoryTable = false;
            }
        }
        protected override void ProcessSubmissionFile(string submissionFile)
        {
            SubmitDataToEndpoint(submissionFile);
        }
        protected virtual string SubmitDataToEndpoint(string filePath)
        {
            if (_epaPartnerNode == null)
            {
                AppendAuditLogEvent("No node partner was specified for submission, so no Submit will be performed.");
                return null;
            }
            string transactionId;
            try
            {
                AppendAuditLogEvent("Submitting BEACHES data to endpoint \"{0}\"", _epaPartnerNode.Name);
                
                ITransactionManager transactionManager;
                GetServiceImplementation(out transactionManager);

                string networkFlowName = BEACHES_FLOW_NAME, networkFlowOperation = null;
                try
                {
                    INodeEndpointClientFactory nodeEndpointClientFactory;
                    GetServiceImplementation(out nodeEndpointClientFactory);

                    using (INodeEndpointClient endpointClient = nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            transactionId =
                                endpointClient.Submit(BEACHES_FLOW_NAME, "default",
                                                      string.Empty, new string[] { filePath });
                            networkFlowOperation = "default";
                        }
                        else
                        {
                            transactionId =
                                endpointClient.Submit(BEACHES_FLOW_NAME, null, new string[] { filePath });
                        }
                    }
                    AppendAuditLogEvent("Successfully submitted BEACHES data to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                         _epaPartnerNode.Name, transactionId);

                    UpdateStatusOfNetworkTransaction(_dataRequest.TransactionId, transactionId, 
                                                     _epaPartnerNode.Url, _epaPartnerNode.Version);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to submit BEACHES data to endpoint \"{0}\": {1}",
                                        _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                    throw;
                }
                transactionManager.SetNetworkId(_dataRequest.TransactionId, transactionId, _epaPartnerNode.Version,
                                                _epaPartnerNode.Url, networkFlowName, networkFlowOperation);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to submit BEACHES data to endpoint \"{0}\" with exception: {1}",
                                    _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(filePath);
            }
            return transactionId;
        }
    }
}
