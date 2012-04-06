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
using Windsor.Node2008.WNOSPlugin.CERS_12;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.NodeClient;

namespace Windsor.Node2008.WNOSPlugin.EIS_12
{
    [Serializable]
    public abstract class EISSubmissionProxy : EISProcessSubmission
    {
        protected string _authorName;
        protected string _organizationName;
        protected string _senderContactInfo;
        protected string _attachmentFolderPath;
        protected bool _isProductionSubmission;
        protected PartnerIdentity _epaPartnerNode;
        protected string _submitFlowName = "EIS_v1_0";
        protected string _submitFlowOperation;
        protected string _programSystemCode;

        protected ITransactionManager _transactionManager;
        protected INodeEndpointClientFactory _nodeEndpointClientFactory;
        protected IPartnerManager _partnerManager;

        protected enum EISConfigParams
        {
            None,
            [Description("Author Name")]
            AuthorName,
            [Description("Organization Name")]
            OrganizationName,
            [Description("Sender Contact Info")]
            SenderContactInfo,
            [Description("Submission Type (Production or QA)")]
            SubmissionType,
            [Description("Submission Partner Name")]
            SubmissionPartnerName,
            [Description("Submission Flow Name (EIS_v1_0)")]
            SubmissionFlowName,
            [Description("Submission Operation Name")]
            SubmissionOperationName,
            [Description("Submission Program System Code")]
            SubmissionProgramSystemCode,
        }

        public EISSubmissionProxy()
        {
            AppendConfigArguments<EISConfigParams>();
        }

        protected override void LazyInit()
        {
            base.LazyInit();

            GetServiceImplementation(out _transactionManager);
            GetServiceImplementation(out _nodeEndpointClientFactory);
            GetServiceImplementation(out _partnerManager);
            
            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.AuthorName), out _authorName);
            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.OrganizationName), out _organizationName);
            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SubmissionProgramSystemCode), out _programSystemCode);
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SenderContactInfo), ref _senderContactInfo);
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SubmissionFlowName), ref _submitFlowName);
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SubmissionOperationName), ref _submitFlowOperation);
            string submissionType;
            GetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SubmissionType), out submissionType);
            if (string.Equals(submissionType, PRODUCTION_SUBMISSION_TYPE_NAME, StringComparison.InvariantCultureIgnoreCase))
            {
                _isProductionSubmission = true;
            }
            else if (string.Equals(submissionType, QA_SUBMISSION_TYPE_NAME, StringComparison.InvariantCultureIgnoreCase))
            {
                _isProductionSubmission = false;
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid {0} specified: {1}, must be either \"{2}\" or \"{3}\"",
                                            EnumUtils.ToDescription(EISConfigParams.SubmissionType),
                                            submissionType, PRODUCTION_SUBMISSION_TYPE_NAME, QA_SUBMISSION_TYPE_NAME));
            }

            string epaPartnerName = null;
            TryGetConfigParameter(EnumUtils.ToDescription(EISConfigParams.SubmissionPartnerName), ref epaPartnerName);
            if (!string.IsNullOrEmpty(epaPartnerName))
            {
                _epaPartnerNode = _partnerManager.GetByName(epaPartnerName);
                if (_epaPartnerNode == null)
                {
                    throw new ArgumentException(string.Format("The \"{0}\" with the name \"{1}\" specified for this service cannot be found",
                                                              EnumUtils.ToDescription(EISConfigParams.SubmissionPartnerName), epaPartnerName));
                }
                if (string.IsNullOrEmpty(_submitFlowName))
                {
                    throw new ArgumentException(string.Format("The \"{0}\" configuration parameter was not specified",
                                                              EnumUtils.ToDescription(EISConfigParams.SubmissionFlowName)));
                }
            }
            AppendAuditLogEvent("Config params: {0} ({1}), {2} ({3}), {4} ({5}), {6} ({7}), {8} ({9}), {10} ({11}, {12} ({13})", 
                                EnumUtils.ToDescription(EISConfigParams.AuthorName), _authorName, 
                                EnumUtils.ToDescription(EISConfigParams.OrganizationName), _organizationName,
                                EnumUtils.ToDescription(EISConfigParams.SenderContactInfo), _senderContactInfo ?? string.Empty,
                                EnumUtils.ToDescription(EISConfigParams.SubmissionType), submissionType,
                                EnumUtils.ToDescription(EISConfigParams.SubmissionPartnerName), epaPartnerName ?? string.Empty,
                                EnumUtils.ToDescription(EISConfigParams.SubmissionFlowName), _submitFlowName ?? string.Empty,
                                EnumUtils.ToDescription(EISConfigParams.SubmissionOperationName), _submitFlowOperation ?? string.Empty);
        }
        protected override void ProcessSubmitDocument(string transactionId, string docId)
        {
            string filePath = null;
            try
            {
                CERSDataType data = GetSubmitDocumentData(transactionId, docId);

                filePath = GenerateSubmissionFileAndAddToTransaction(data, transactionId, _authorName, _organizationName,
                                                                     _senderContactInfo, _isProductionSubmission,
                                                                     _attachmentFolderPath, null);

                if (_epaPartnerNode != null)
                {
                    SubmitData(transactionId, filePath);
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(filePath);
            }
        }
        protected string SubmitData(string transactionId, string submitFilePath)
        {
            string networkTransactionId;
            try
            {
                string networkFlowName = _submitFlowName, networkFlowOperation = null;
                AppendAuditLogEvent("Submitting results to endpoint \"{0}\"", _epaPartnerNode.Name);
                try
                {
                    using (INodeEndpointClient endpointClient = _nodeEndpointClientFactory.Make(_epaPartnerNode.Url, _epaPartnerNode.Version))
                    {
                        if (endpointClient.Version == EndpointVersionType.EN20)
                        {
                            networkTransactionId =
                                endpointClient.Submit(_submitFlowName, _submitFlowOperation,
                                                      string.Empty, new string[] { submitFilePath });
                            networkFlowOperation = _submitFlowOperation;
                        }
                        else
                        {
                            networkTransactionId =
                                endpointClient.Submit(_submitFlowName, null, new string[] { submitFilePath });
                        }
                    }
                    AppendAuditLogEvent("Successfully submitted results to endpoint \"{0}\" with returned transaction id \"{1}\"",
                                        _epaPartnerNode.Name, networkTransactionId);
                }
                catch (Exception e)
                {
                    AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\": {1}",
                                        _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                    throw;
                }
                _transactionManager.SetNetworkId(transactionId, networkTransactionId, _epaPartnerNode.Version,
                                                 _epaPartnerNode.Url, networkFlowName, networkFlowOperation);
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to submit results to endpoint \"{0}\" with exception: {1}",
                                          _epaPartnerNode.Name, ExceptionUtils.ToShortString(e));
                throw;
            }
            return networkTransactionId;
        }
    }
    [Serializable]
    public class EISSubmitFacilityInventory : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.FacilityInventory;
            }
        }
    }
    [Serializable]
    public class EISSubmitPointEmissions : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Point;
            }
        }
    }
    [Serializable]
    public class EISSubmitEventEmissions : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Event;
            }
        }
    }
    [Serializable]
    public class EISSubmitNonPointEmissions : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonpoint;
            }
        }
    }
    [Serializable]
    public class EISSubmitOnRoadMobileEmissions : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Onroad;
            }
        }
    }
    [Serializable]
    public class EISSubmitNonRoadMobileActivities : EISSubmissionProxy
    {
        protected override DataCategory DataCategory
        {
            get
            {
                return DataCategory.Nonroad;
            }
        }
        protected override CERSDataType GetSubmitDocumentData(string transactionId, string docId)
        {
            AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
            Windsor.Node2008.WNOSDomain.Document document = _documentManager.GetDocument(transactionId, docId, true);
            if (!document.IsZipFile)
            {
                throw new ArgumentException(string.Format("The submitted document \"{0}\" is not a zip file", document.DocumentName));
            }
            
            int submitYear;
            string docName = Path.GetFileNameWithoutExtension(document.DocumentName);
            if ( docName.Length < 10 )
            {
                throw new ArgumentException(string.Format("The submitted document's name \"{0}\" is not valid", document.DocumentName));
            }
            if ( !int.TryParse(docName.Substring(docName.Length - 4, 4), out submitYear) || (submitYear > DateTime.Now.AddYears(1).Year) ||
                 (submitYear < 1900) )
            {
                throw new ArgumentException(string.Format("The submitted document's name \"{0}\" does not contain a valid year", document.DocumentName));
            }
            int submitFIPSCode;
            if ( !int.TryParse(docName.Substring(docName.Length - 10, 5), out submitFIPSCode) )
            {
                throw new ArgumentException(string.Format("The submitted document's name \"{0}\" does not contain a valid FIPS code", document.DocumentName));
            }

            string submitFileName = submitFIPSCode.ToString("D5");

            CERSDataType data = new CERSDataType();
            data.DataCategory = DataCategory.OnroadNonroadActivity;
            data.EmissionsYear = submitYear.ToString();
            data.UserIdentifier = _senderContactInfo;
            data.ProgramSystemCode = _programSystemCode;

            data.Location = new LocationDataType[1];
            data.Location[0] = new LocationDataType();
            data.Location[0].StateAndCountyFIPSCode = submitFileName;

            AppendAuditLogEvent("Submitted document contains data for FIPS code \"{0}\" and emissions year \"{1}\"",
                                submitFileName, submitYear);

            submitFileName += ".zip";
            string parentFolderPath = Path.Combine(_settingsProvider.TempFolderPath, transactionId);
            Directory.CreateDirectory(parentFolderPath);
            _attachmentFolderPath = parentFolderPath;
            string tempZipFilePath = Path.Combine(parentFolderPath, submitFileName);
            File.WriteAllBytes(tempZipFilePath, document.Content);
            data.AttachmentFileNames = new string[] { submitFileName };

            return data;
        }
    }
}
