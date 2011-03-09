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
using System.Data;
using System.ComponentModel;
using Spring.Context;
using Spring.Context.Support;
using System.IO;
using System.Text;

using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.Configuration;
using System.Web.Caching;
using System.Web.Services;
using System.Web.Services.Protocols;

using Common.Logging;
using Spring.Objects.Factory;
using System.Reflection;

using Microsoft.Web.Services;
using Microsoft.Web.Services.Dime;

using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.Endpoint1;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Endpoint1
{

    [WebService(Namespace = "http://www.ExchangeNetwork.net/schema/v1.0/node.wsdl")]
    [SoapRpcService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ENService11 : Microsoft.Web.Services.WebServicesExtension, INetworkNodeBinding
    {

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string SERVICE_PROVIDER_NAME = "serviceProvider";

        #region Members
        private ENService11Provider _service11Provider;
        #endregion

        private void Init()
        {


            _service11Provider = HttpContext.Current.Cache[SERVICE_PROVIDER_NAME] as ENService11Provider;

            if (_service11Provider == null)
            {

                LOG.Debug("Configuring service provider...");

                IApplicationContext ctx = ContextRegistry.GetContext();
                _service11Provider = ctx.GetObject(SERVICE_PROVIDER_NAME) as ENService11Provider;

                if (_service11Provider == null)
                {
                    throw new ArgumentException("Unable to find ENService20Provider reference");
                }

                HttpContext.Current.Cache.Insert(SERVICE_PROVIDER_NAME,
                                                 _service11Provider,
                                                 null,
                                                 Cache.NoAbsoluteExpiration,
                                                 TimeSpan.FromMinutes(20),
                                                 CacheItemPriority.NotRemovable,
                                                 null);

                LOG.Debug("Service Provider configured");
            }

        }

        #region INetworkNodeBinding Members

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="credential"></param>
        /// <param name="authenticationMethod"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Authenticate(string userId, string credential, string authenticationMethod)
        {
            Init();
            LOG.Debug("Authenticate");

            #region Validate

            if (string.IsNullOrEmpty(userId) ||
                string.IsNullOrEmpty(credential))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "NULL Authenticate argument");
            }

            #endregion

            try
            {
                LOG.Debug("Getting visit");
                AuthEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(userId,
                                                                                    credential,
                                                                                    null,
                                                                                    authenticationMethod);

                LOG.Debug("Authenticating using visit: " + visit);
                string token = _service11Provider.SecurityService.Authenticate(visit);

                LOG.Debug("Token: " + token);
                return token;

            }
            catch (Exception ex)
            {
                LOG.Error("Error while authenticating", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="transactionId"></param>
        /// <param name="dataflow"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Submit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents)
        {
            Init();
            LOG.Debug("Submit");

            if (documents == null || documents.Length == 0)
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                                "Document not provided");
            }

            SoapContext context = HttpSoapContext.RequestContext;

            bool useDimeAttachments = true;
            if (context == null ||
                context.Attachments == null ||
                context.Attachments.Count == 0)
            {
                // Check to see if the documents themselves contain the content
                foreach (NodeDocument document in documents)
                {
                    if ((document.content == null) || (document.content.Length == 0))
                    {
                        throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                        "Some documents do not contain any content.");
                    }
                }
                useDimeAttachments = false;
            }
            else if (context.Attachments.Count != documents.Length)
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                "DIME attachment count does not equal to the number of documents.");
            }

            try
            {



                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(securityToken);

                AsyncComplexContent content = new AsyncComplexContent();
                content.Documents = new List<Document>();
                content.Flow = new OperationDataFlow(dataflow);
                content.Transaction = new SimpleId(transactionId);

                int attachmentCounter = 0;

                LOG.Debug("Spooling documents");
                foreach (NodeDocument wsdlDoc in documents)
                {
                    Document doc = new Document();

                    doc.Content = useDimeAttachments ? GetContent(context.Attachments[attachmentCounter++].Stream) :
                        wsdlDoc.content;
                    doc.Type = CommonContentAndFormatProvider.Convert(wsdlDoc.type);
                    doc.DocumentId = string.Empty;
                    doc.DocumentName = wsdlDoc.name;
                    LOG.Debug("   doc:" + doc);

                    content.Documents.Add(doc);
                }

                LOG.Debug("Submitting: " + content);
                TransactionStatus status = _service11Provider.ContentService.Submit(content, visit);

                LOG.Debug("Status: " + status);
                return status.Id; //Status ID in this case is the transaction id

            }
            catch (Exception ex)
            {
                LOG.Error("Error while submitting", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        string INetworkNodeBinding.GetStatus(string securityToken, string transactionId)
        {
            Init();
            LOG.Debug("GetStatus");

            #region Validate

            if (string.IsNullOrEmpty(transactionId))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "NULL transactionId argument");
            }

            #endregion

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(securityToken);

                LOG.Debug("GetStatus using visit: " + visit);
                TransactionStatus tranStatus = _service11Provider.TransactionService.GetStatus(
                    new SimpleId(transactionId),
                    visit);

                LOG.Debug("TransactionStatus: " + tranStatus);
                return CommonTransactionStatusCodeProvider.ConvertTo11Enum(tranStatus.Status);

            }
            catch (Exception ex)
            {
                LOG.Error("Error while getting status", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="nodeAddress"></param>
        /// <param name="dataflow"></param>
        /// <param name="documents"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Notify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents)
        {
            Init();
            LOG.Debug("Notify");

            #region Validate

            if (documents == null || documents.Length == 0)
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "Document not provided");
            }

            if (documents.Length > 1)
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "Only one document per notification allowed");
            }

            SoapContext context = HttpSoapContext.RequestContext;
            if (context.Attachments != null && context.Attachments.Count > 0)
            {
                // TODO: Mark, why is this check here?  Calling Notify() from the endpoint client NotifyEvent(), NotifyStatus(), etc. methods fail here
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "Notify does not use DIME. Put content in the message.");
            }

            if (string.IsNullOrEmpty(dataflow))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "NULL dataflow argument");
            }



            #endregion

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(securityToken);


                NotificationMessageCategoryType messageCategory = NotificationMessageCategoryType.None;

                switch (dataflow.Trim().ToLower())
                {
                    case "http://www.exchangenetwork.net/node/event":
                        messageCategory = NotificationMessageCategoryType.Event;
                        break;

                    case "http://www.exchangenetwork.net/node/status":
                        messageCategory = NotificationMessageCategoryType.Status;
                        break;

                    case "other":
                        messageCategory = NotificationMessageCategoryType.Status;
                        break;

                    default:
                        throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                        "Invalid dataflow argument: " + dataflow);

                }

                ComplexNotification notif = new ComplexNotification();
                notif.FlowName = dataflow;
                notif.Uri = nodeAddress;
                notif.Notifications = new List<Notification>();


                LOG.Debug("Spooling documents");
                foreach (NodeDocument wsdlDoc in documents)
                {
                    Notification not = new Notification();

                    not.Category = messageCategory;
                    not.Name = wsdlDoc.name;
                    not.Status = new TransactionStatus();
                    not.Status.Status = CommonTransactionStatusCodeProvider.Convert(wsdlDoc.type);
                    not.Status.Description = Encoding.ASCII.GetString(wsdlDoc.content);

                    LOG.Debug("   Notification:" + not);

                    notif.Notifications.Add(not);
                }

                LOG.Debug("GetStatus using visit: " + visit);
                TransactionStatus tranStatus = _service11Provider.TransactionService.Notify(notif, visit);

                LOG.Debug("TransactionStatus: " + tranStatus);
                return CommonTransactionStatusCodeProvider.ConvertTo11Enum(tranStatus.Status);

            }
            catch (Exception ex)
            {
                LOG.Error("Error while fotifying", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }

        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="transactionId"></param>
        /// <param name="dataflow"></param>
        /// <param name="documents"></param>
        void INetworkNodeBinding.Download(string securityToken, string transactionId, string dataflow, ref NodeDocument[] documents)
        {
            Init();
            LOG.Debug("Download");

            if (string.IsNullOrEmpty(transactionId))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter,
                                                                "NULL Transaction Id");
            }

            try
            {
                SoapContext res = HttpSoapContext.ResponseContext;

                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(securityToken);

                ComplexContent content = new ComplexContent();
                if (!string.IsNullOrEmpty(dataflow))
                {
                    content.Flow = new OperationDataFlow(dataflow);
                }
                content.Transaction = new SimpleId(transactionId);

                LOG.Debug("Submitting: " + content);
                IList<Document> wnosDocs = _service11Provider.ContentService.Download(content, visit);


                List<NodeDocument> wsdlDocList = new List<NodeDocument>();
                Dictionary<string, string> docIdList = new Dictionary<string, string>();

                LOG.Debug("Spooling documents");
                foreach (Document wnosDoc in wnosDocs)
                {
                    NodeDocument doc = new NodeDocument();

                    doc.content = wnosDoc.Content;
                    doc.type = CommonContentAndFormatProvider.ConvertTo11Enum(wnosDoc.Type);
                    doc.name = wnosDoc.DocumentName;
                    LOG.Debug("   doc:" + doc);

                    DimeAttachment attachment = new DimeAttachment();
                    attachment.Stream = new MemoryStream(doc.content);
                    attachment.TypeFormat = TypeFormatEnum.MediaType;
                    attachment.Type = "application/x-gzip";
                    attachment.Id = Guid.NewGuid().ToString();

                    //Add to the the xref filter collection
                    docIdList.Add(doc.name, attachment.Id);

                    res.Attachments.Add(attachment);
                    wsdlDocList.Add(doc);

                }

                documents = wsdlDocList.ToArray();


                //Output filter specific
                res.Add("hrefs", docIdList);


            }
            catch (Exception ex)
            {
                LOG.Error("Error while downloading", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="request"></param>
        /// <param name="rowId"></param>
        /// <param name="maxRows"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Query(string securityToken, string request, string rowId, string maxRows, string[] parameters)
        {
            Init();
            LOG.Debug("Query");

            #region Validate

            if (string.IsNullOrEmpty(securityToken))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }

            if (string.IsNullOrEmpty(request))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "NULL Request argument");
            }

            int rowIdValue;
            if (!int.TryParse(rowId, out rowIdValue) || (rowIdValue < 0))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "Invalid RowId argument");
            }

            int maxRowsValue;
            if (!int.TryParse(maxRows, out maxRowsValue) || !((maxRowsValue == -1) || (maxRowsValue > 0)))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "Invalid MaxRows argument");
            }

            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service11Provider.VisitProvider.GetVisit(securityToken);

                PaginatedContentRequest pagRequest = new PaginatedContentRequest();
                pagRequest.FlowName = null; //TODO: use the name to derive it.
                pagRequest.OperationName = request;
                pagRequest.Paging = new PaginationIndicator();
                pagRequest.Paging.Start = rowIdValue;
                pagRequest.Paging.Count = maxRowsValue;

                pagRequest.Parameters = CreateParameters(parameters);

                LOG.Debug("Querying: " + pagRequest);

                PaginatedContentResult resultSet =
                    _service11Provider.TransactionService.Query(pagRequest, visit);

                LOG.Debug("ResultSet: " + resultSet);

                if (resultSet == null || resultSet.Content == null || resultSet.Content.Content == null)
                {
                    throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_Unknown, "NULL Content");
                }


                return ConvertBytesToString(resultSet.Content.Content);

            }
            catch (Exception ex)
            {
                LOG.Error("Error while querying", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// Solicit
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="returnURL"></param>
        /// <param name="request"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Solicit(string securityToken, string returnURL, string request, string[] parameters)
        {
            Init();
            LOG.Debug("Solicit");

            #region Validate
            if (string.IsNullOrEmpty(securityToken))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }

            if (string.IsNullOrEmpty(request))
            {
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_InvalidParameter, "NULL Request argument");
            }
            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service11Provider.VisitProvider.GetVisit(securityToken);

                AsyncContentRequest asyncRequest = new AsyncContentRequest();

                asyncRequest.FlowName = null; //TODO: Make sure the flow can't be derived from the Flow
                asyncRequest.OperationName = request;
                asyncRequest.Parameters = CreateParameters(parameters);
                asyncRequest.Notifications = CreateNotifications(returnURL);

                LOG.Debug("Soliciting: " + asyncRequest);

                TransactionStatus status =
                    _service11Provider.TransactionService.Solicit(asyncRequest, visit);

                LOG.Debug("Status: " + status.Id);
                return status.Id;

            }
            catch (Exception ex)
            {
                LOG.Error("Error while soliciting", ex);
                throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ex);
            }
        }

        /// <summary>
        /// Execute - DO NOT IMPLEMENT
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="request"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        string INetworkNodeBinding.Execute(string securityToken, string request, string[] parameters)
        {
            Init();
            throw _service11Provider.FaultProvider.GetFault(EndpointVersionType.EN11, ENExceptionCodeType.E_FeatureUnsupported, "Seriously, you did not expect this to work did you?");
        }

        /// <summary>
        /// NodePing
        /// </summary>
        /// <param name="Hello"></param>
        /// <returns></returns>
        string INetworkNodeBinding.NodePing(string Hello)
        {
            Init();
            return VersionInfo.NodeVersionString;
        }

        /// <summary>
        /// GetServices
        /// </summary>
        /// <param name="securityToken"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        string[] INetworkNodeBinding.GetServices(string securityToken, string serviceType)
        {
            Init();
            return _service11Provider.GetServicesResult;
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// CreateParametersByName
        /// </summary>
        /// <param name="inParams"></param>
        /// <returns></returns>
        private static ByIndexOrNameDictionary<string> CreateParameters(string[] inParams)
        {
            ByIndexOrNameDictionary<string> parameters = new ByIndexOrNameDictionary<string>(false);
            if ((inParams != null) && (inParams.Length > 0))
            {
                for (int i = 0; i < inParams.Length; i++)
                {
                    parameters.Add(inParams[i]);
                }
            }
            return parameters;
        }

        private static byte[] GetContent(Stream stream)
        {
            int size = (int)stream.Length;
            byte[] result = new byte[size];
            stream.Read(result, 0, size);
            stream.Close();
            return result;
        }


        private static string ConvertBytesToString(byte[] content)
        {
            using (StreamReader reader = new StreamReader(new MemoryStream(content)))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// CreateNotifications
        /// </summary>
        /// <param name="inWsdlNotifications"></param>
        /// <returns></returns>
        private static Dictionary<string, TransactionNotificationType> CreateNotifications(string inWsdlNotification)
        {
            Dictionary<string, TransactionNotificationType> notifs = new Dictionary<string, TransactionNotificationType>();
            if (!string.IsNullOrEmpty(inWsdlNotification))
            {
                notifs.Add(inWsdlNotification, TransactionNotificationType.All);
            }
            return notifs;
        }


        #endregion

    }
}
