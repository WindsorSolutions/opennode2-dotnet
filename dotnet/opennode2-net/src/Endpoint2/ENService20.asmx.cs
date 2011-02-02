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
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Caching;
using System.ComponentModel;
using Spring.Context;
using Spring.Context.Support;
using System.IO;
using System.Web.Configuration;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Security.Authentication;

using Common.Logging;
using Spring.Objects.Factory;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;

//Windsor.Node2008.Endpoint2.ENService20
namespace Windsor.Node2008.Endpoint2
{

    //??[WebService(Namespace = "http://www.exchangenetwork.net/wsdl/node/2")]
    [WebService(Namespace = "http://www.exchangenetwork.net/schema/node/2")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [Microsoft.Web.Services3.Messaging.SoapActor("*")]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class ENService20 : Microsoft.Web.Services3.Messaging.SoapService, INetworkNodeBinding2
    {

        // System.Web.Services.WebService

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private const string SERVICE_PROVIDER_NAME = "ServiceProvider";

        #region Members
        private ENService20Provider _service20Provider;
        #endregion

        private void Init()
        {
            _service20Provider = HttpContext.Current.Cache[SERVICE_PROVIDER_NAME] as ENService20Provider;
            if (_service20Provider == null)
            {
                // Not quite thread-perfect here (slight chance of allocating more than once in here),
                // but not a big deal.
                LOG.Debug("Configuring service provider...");
                IApplicationContext ctx = ContextRegistry.GetContext();
                _service20Provider = ctx.GetObject("serviceProvider") as ENService20Provider;

                if (_service20Provider == null)
                {
                    throw new ArgumentException("Unable to find ENService20Provider reference");
                }

                long serviceProviderCacheDurationInMinutes = (long)
                    long.Parse(WebConfigurationManager.AppSettings["ServiceProviderCacheDurationInMinutes"]);
                HttpContext.Current.Cache.Insert(SERVICE_PROVIDER_NAME, _service20Provider, null,
                                     Cache.NoAbsoluteExpiration,
                                     TimeSpan.FromMinutes(serviceProviderCacheDurationInMinutes),
                                     CacheItemPriority.NotRemovable, null);
                LOG.Debug("Service Provider configured");


            }
        }

        #region IENService20 Members
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <remarks>Args
        /// userId: the user ID of the person or system. It is recommended that an email address be used as the user ID in the Exchange Network. The value of 
        /// Credential: the user’s credential for accessing the network services.  It could be a password, a password digest, or a secure authentication key. The credential could be an empty string in case of certificate authentication where the credential, the X.509 certificate, is provided inside the signature.
        /// domain:  this parameter is optional. It is used for supporting multiple user identity stores or federated identity management systems. The default domain is the current node user domain. A node that supports multi-domain authentication should provide the name of the domain to Exchange Network Partners if appropriate.
        /// authenticationMethod: specifies which authentication methods are to be used.  The authenticationMethod parameter could contain one of the following values: Password, Digest, Certificate, Token
        /// </remarks>
        /// <param name="authArg">Authenticate</param>
        /// <returns>AuthenticateResponse</returns>
        AuthenticateResponse INetworkNodeBinding2.Authenticate(Authenticate authArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Authenticate(): {0}", ReflectionUtils.GetPublicPropertiesString(authArg));

            #region Validate

            if (authArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Authenticate argument");
            }
            if (!string.IsNullOrEmpty(authArg.domain) && (authArg.domain != "default"))
            {
                // TODO: Need to allow other valid domains in the future
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_UnknownUser, "The specified domain is not valid");
            }

            #endregion

            try
            {
                AuthEndpointVisit visit = _service20Provider.VisitProvider.GetVisit(authArg.userId,
                                                                  authArg.credential,
                                                                  authArg.domain,
                                                                  authArg.authenticationMethod);

                LOG.Debug("Authenticating using visit: " + visit);
                string token = _service20Provider.SecurityService.Authenticate(visit);

                LOG.Debug("Token: " + token);
                AuthenticateResponse authResp = new AuthenticateResponse();
                authResp.securityToken = token;

                return authResp;

            }
            catch (InvalidCredentialException invalidEx)
            {
                LOG.Error("Error while authenticating", invalidEx);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidCredential,
                                                                invalidEx.Message);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while authenticating", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }

        }

        /// <summary>
        /// Submit
        /// </summary>
        /// <remarks>The Submit method accepts six (6) top-level arguments:
        ///     securityToken: A security ticket issued by the service provider or a trusted service provider.
        ///     transactionId:  A transaction ID for the submission if the operation is a result of an asynchronous operation or a previous transaction (process report from a backend processor, for instance).
        ///     dataflow: The name of target dataflow. A dataflow identifier may contain sub-dataflow name if needed. The format of the dataflow with sub-dataflow should be: dataflow.sub-dataflow. For example, a sub-dataflow Handler in the RCRA dataflow could be represented as: RCRA_v1_0.Handler
        ///     flowOperation: A flow specific operation identifier. It indicates the specific processing for the document, as defined in the Data Exchange Flow Configuration Document (FCD).
        ///     recipient : An array of zero or more URIs representing the ultimate receivers of the submission.  Each recipient item in the array should contain one node address URI or one email address URI.  If recipient is a Node URI, the processed  submission package must be sent to the recipient Node using the Submit method.  Specific details on how the Submit request to the recipient should be constructed is determined by dataflows and documented in the relevant Flow Configuration Document. If the recipient parameter contains a valid email URI, then the receiving Node must send an email containing at minimum: the transactionID of the submission, the receiving Node address, and the originating Node address.  Additional details may be included, but are determined by dataflows and specified in the relevant Flow Configuration Document.  This information must allow a properly authorized person to download the submission documents after receiving a valid transactionID via email.  
        ///     notificationURI: An array of zero or more URIs to which a status notification containing the processing status of a submission can be sent when the status of the transaction changes.  The notificationURI parameter must contain either a valid email URI or a valid node address.  An optional notificationType attribute may be specified to indicate the situations in which a notification message must be sent to the specified URI.  If no notificationType attribute is specified, all messages relating to the transaction must be sent. If the value of this parameter is an email URI, the processing Node must attempt to send an email message which contains the ID, statusCode, and statusDetail of the transaction.  If the value of this parameter is a Node URI, the Notify method will be called on the URI, including the transaction ID and the transaction status information.
        ///     documents: One or more documents of type NodeDocumentType as described in section 3.3. Each document structure contains a single payload.
        /// </remarks>
        /// <param name="submitArg">Submit</param>
        /// <returns>StatusResponseType</returns>
        StatusResponseType INetworkNodeBinding2.Submit(Submit submitArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Submit(): {0}", ReflectionUtils.GetPublicPropertiesString(submitArg));

            #region Validate

            if (submitArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter,
                    "NULL Submit argument");
            }

            if (string.IsNullOrEmpty(submitArg.dataflow))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter,
                    "NULL DataFlow argument");
            }

            if (submitArg.documents == null || submitArg.documents.Length == 0)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter,
                    "NULL or 0 Documents argument");
            }
            if (!CollectionUtils.IsNullOrEmpty(submitArg.recipient))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_RecipientNotSupported,
                    "Recipients are not supported for the Submit operation for this version of the node.");
            }
            #endregion

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit = _service20Provider.VisitProvider.GetVisit(submitArg.securityToken);

                AsyncComplexContent content = new AsyncComplexContent();
                content.Documents = new List<Document>(submitArg.documents.Length);
                content.Flow = new OperationDataFlow(submitArg.dataflow, submitArg.flowOperation);
                content.Transaction = new SimpleId(submitArg.transactionId);

                LOG.Debug("Spooling documents");
                foreach (NodeDocumentType wsdlDoc in submitArg.documents)
                {
                    Document doc = new Document();

                    doc.Content = wsdlDoc.documentContent.Value;
                    doc.Type = CommonContentAndFormatProvider.Convert(wsdlDoc.documentFormat.ToString());
                    doc.DocumentId = wsdlDoc.documentId;
                    doc.DocumentName = wsdlDoc.documentName;

                    LOG.Debug("   doc:" + doc);

                    content.Documents.Add(doc);
                }

                content.Notifications = CreateNotifications(submitArg.notificationURI);
                content.Recipients = (submitArg.recipient != null) ?
                    new List<string>(submitArg.recipient) : new List<string>();


                LOG.Debug("Submitting: " + content);
                TransactionStatus status = _service20Provider.ContentService.Submit(content, visit);

                LOG.Debug("Status: " + status);
                return StatusResponseTypeFromTransactionStatus(status);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while submitting", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <remarks>
        /// GetStatus is a method for transaction tracking.  Once initiated, a transaction enters into 
        /// different processing stages.  The GetStatus method offers the client a way of querying 
        /// the current state of the transaction. Note that GetStatus is used for querying the status 
        /// of both asynchronous and synchronous transactions. A service provider must 
        /// persistently store (log) transactional information for the following methods: Submit, 
        /// Download, Query, Solicit, Notify and Execute.
        /// 
        /// The GetStatus method requires two (2) mandatory parameters: securityToken and 
        /// transactionId.  transactionId is a transaction identification returned by the Submit, Solicit 
        /// or Notify method. 
        /// </remarks>
        /// <param name="submitArg">GetStatus</param>
        /// <returns>StatusResponseType</returns>
        StatusResponseType INetworkNodeBinding2.GetStatus(GetStatus getStatusArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.GetStatus(): {0}", ReflectionUtils.GetPublicPropertiesString(getStatusArg));

            #region Validate

            if (getStatusArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL GetStatus argument");
            }

            if (string.IsNullOrEmpty(getStatusArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }

            if (string.IsNullOrEmpty(getStatusArg.transactionId))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL TransactionId argument");
            }

            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(getStatusArg.securityToken);

                SimpleId transaction = new SimpleId(getStatusArg.transactionId);

                LOG.Debug("Getting status: " + transaction);
                TransactionStatus status =
                    _service20Provider.TransactionService.GetStatus(transaction, visit);

                LOG.Debug("Status: " + status);
                return StatusResponseTypeFromTransactionStatus(status);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while getting status", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <remarks>
        /// The Notify method has three (3) intended uses: document notification, event notification, 
        /// and status notification described as follows: 
        ///		
        ///		Document notification: A node or client notifies a service provider about 
        ///			availability of some documents (soliciting).  The service provider can retrieve the 
        ///			documents anytime.  
        /// 	 
        ///		Event notification: A node sends, or possibly broadcasts, an event that is of 
        ///			interest to other parties.  Event messages can be security alerts, shutdown 
        ///			notices, and other network management notes. This specification does not define 
        ///			the semantics of events, as they are operation specific.  Service providers are 
        ///			free to state the specific meaning of network events.   
        ///    
        ///		Status notification: A service provider sends a message to a requester to 
        ///			provide the current status of a submission or service request. 
        /// 
        /// The request message has the following arguments: 
        ///	  
        ///		securityToken: A security ticket issued by the service provider or a trusted 
        ///			security provider. 
        ///		
        ///		nodeAddress: For document notification, the parameter contains a network node 
        ///			address where the document can be downloaded. It should contain the initiator's 
        ///			node address, or be empty if not applicable, for event and status notifications. 
        ///	  
        ///		dataflow:  The target dataflow that identifies the notification messages.   
        ///			
        ///		messages: An array of notification messages. All messages contained in a single 
        ///			Notify message must originate from the same dataflow.
        /// </remarks>
        /// <param name="notifyArg">Notify</param>
        /// <returns>StatusResponseType</returns>
        StatusResponseType INetworkNodeBinding2.Notify(Notify notifyArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Notify(): {0}", ReflectionUtils.GetPublicPropertiesString(notifyArg));

            #region Validate

            if (notifyArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Notify argument");
            }

            if (string.IsNullOrEmpty(notifyArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }

            if (string.IsNullOrEmpty(notifyArg.dataflow))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Dataflow argument");
            }

            if (notifyArg.messages == null || notifyArg.messages.Length == 0)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL or 0 Messages argument");
            }
            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(notifyArg.securityToken);

                ComplexNotification notification = new ComplexNotification();
                notification.FlowName = notifyArg.dataflow;
                notification.Uri = notifyArg.nodeAddress;

                notification.Notifications = new List<Notification>(notifyArg.messages.Length);
                foreach (NotificationMessageType notificationMessageType in notifyArg.messages)
                {

                    Notification newNotification = new Notification(notificationMessageType.objectId);
                    newNotification.Category = Convert(notificationMessageType.messageCategory);
                    newNotification.Name = notificationMessageType.messageName;
                    newNotification.Status = new TransactionStatus();
                    newNotification.Status.Status = 
						CommonTransactionStatusCodeProvider.Convert(notificationMessageType.status.ToString());
                    newNotification.Status.Description = notificationMessageType.statusDetail;
                    if (newNotification.Category ==
                        Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType.Status)
                    {
                        newNotification.Status.Id = newNotification.Id;
                    }
                    notification.Notifications.Add(newNotification);
                    LOG.Debug("Adding notification: " + newNotification);
                }

                LOG.Debug("Notifying: " + notification);
                TransactionStatus status =
                    _service20Provider.TransactionService.Notify(notification, visit);

                LOG.Debug("Status: " + status);
                return StatusResponseTypeFromTransactionStatus(status);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while notifying", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <remarks>
        /// The Download method provides a means for retrieving documents associated with a 
        /// transaction from a Node. In a typical asynchronous transaction, such as those 
        /// associated with Solicit or Submit, the Download method is used to obtain results from a 
        /// service request. 
        /// 
        /// The ability to download documents makes mutual data exchanges possible.  Any node 
        /// in the Exchange Network can be a service provider and, at the same time, a service 
        /// consumer.  From the requester's point of view, submitting is an operation of sending 
        /// documents to a remote node, while downloading is an operation of receiving documents 
        /// from a remote node. 
        /// 
        /// Unlike the Submit method, however, the Download method gives the requester access 
        /// to documents. Generally, the Download method should only be available to users who 
        /// have been given explicit permissions to invoke the service.  Additionally, documents 
        /// available through the Download method should have user and group level permissions 
        /// that allow for granular security.
        /// 
        /// The Download method takes the following parameters: 
        /// 
        ///		securityToken: A security ticket issued by the service provider or a trusted 
        ///			security provider. 
        /// 
        ///		dataflow: The dataflow identifier for the download operation. 
        /// 
        ///		transactionId:  A transaction ID for the submission.  It must be the same 
        ///			transaction ID issued by the node (See the Notify method.)  
        /// 
        ///		documents: An array of NodeDocumentType structures as described in section 
        ///			3.3.  This structure is used to specify what documents to download, using the 
        ///			DocumentName and documented attributes.  The DocumentContents element 
        ///			must be empty in the request message, and should be ignored by service 
        ///			providers.  
        /// 
        /// When the documents parameter is empty, the Node must return all documents 
        /// associated with the supplied transactionId.  When a document ID is specified within the 
        /// documents parameter, the node must return only the associated document. 
        /// 
        /// For any valid transaction ID, the following predefined DocumentName attributes can be 
        /// used to retrieve transaction reports, original documents, or some processed documents 
        /// associated with the transaction.  Nodes must have the capability to generate these four 
        /// types of documents for all Data Exchanges. However if the specified DocumentName 
        /// cannot be found, or does not exist for the transaction ID, the E_FileNotFound error must 
        /// be returned.  The specific content and formatting of each document is determined by 
        /// each Data Exchange and should be documented in the relevant Flow Configuration 
        /// Document. 
        /// </remarks>
        /// <param name="downloadArg">Download</param>
        /// <returns>NodeDocumentType[]</returns>
        NodeDocumentType[] INetworkNodeBinding2.Download(Download downloadArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Download(): {0}", ReflectionUtils.GetPublicPropertiesString(downloadArg));

            #region Validate
            if (downloadArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Download argument");
            }
            if (string.IsNullOrEmpty(downloadArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }
            if (string.IsNullOrEmpty(downloadArg.transactionId))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL TransactionId argument");
            }
            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(downloadArg.securityToken);

                ComplexContent content = new ComplexContent();
                content.Documents = new List<Document>();
                if (!string.IsNullOrEmpty(downloadArg.dataflow))
                {
                    content.Flow = new OperationDataFlow(downloadArg.dataflow);
                }
                content.Transaction = new SimpleId(downloadArg.transactionId);

                if (downloadArg.documents != null)
                {
                    LOG.Debug("Creating document array");
                    foreach (NodeDocumentType wsdlDoc in downloadArg.documents)
                    {
                        Document doc = new Document();

                        doc.DocumentId = wsdlDoc.documentId;
                        doc.DocumentName = wsdlDoc.documentName;

                        LOG.Debug("   doc:" + doc);

                        content.Documents.Add(doc);
                    }
                }

                LOG.Debug("Downloading: " + content);
                IList<Document> documents =
                    _service20Provider.ContentService.Download(content, visit);

                if ((documents != null) && (documents.Count > 0))
                {
                    NodeDocumentType[] rtnDocuments = new NodeDocumentType[documents.Count];
                    for (int i = 0; i < documents.Count; ++i)
                    {
                        Document doc = documents[i];
                        NodeDocumentType wsdlDoc = new NodeDocumentType();
                        wsdlDoc.documentName = doc.DocumentName;
                        wsdlDoc.documentId = doc.DocumentId;
                        wsdlDoc.documentFormat = Convert(doc.Type);
                        wsdlDoc.documentContent = new AttachmentType();
						wsdlDoc.documentContent.contentType = CommonContentAndFormatProvider.ConvertToMimeType(doc.Type);
                        wsdlDoc.documentContent.Value = doc.Content;
                        rtnDocuments[i] = wsdlDoc;
                    }
                    LOG.Debug(rtnDocuments.Length.ToString() + " documents returned");
                    return rtnDocuments;
                }
                else
                {
                    LOG.Debug("No documents returned");
                    return new NodeDocumentType[0];
                }

            }
            catch (Exception ex)
            {
                LOG.Error("Error while notifying", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <remarks>
        /// The Query method is a function in the Data Publishing interface. The method is 
        /// intended to run one of a series of predefined information requests that return data in an 
        /// XML instance document that conforms to a predefined standard schema.  Many 
        /// predefined information requests will be standard across the network, and some may be 
        /// unique to a particular node. 
        /// 
        /// Another case where positioned-fetch must be important is when the result set is so 
        /// large that the network connection between the requester and the provider will likely 
        /// timeout.  Positioned-fetch allows requesters to partition the whole result set into smaller 
        /// chunks and thus avoid possible network problems. Nodes are encouraged to support 
        /// positioned-fetches (paged queries); however, due to varying system capabilities, some 
        /// nodes may not be able to support this functionality.  If a node cannot support positioned 
        /// fetches, it must return a SOAP fault with an error code of E_FeatureUnsupported when 
        /// rowId is greater than 0. 
        /// 
        /// One of the new features introduced in the version 2.0 Query method is the dataflow 
        /// parameter, which provides additional semantics to the data services requests and 
        /// further limits possible data service name collisions. 
        /// 
        /// Another change in the node 2.0 Query method is that query parameters are defined as 
        /// elements with Name, Type, and Encoding attribute. This allows service providers to 
        /// perform parameter binding without ambiguities. However, it should be noted that 
        /// parameters with encoding types other than type string and XML may not be supported 
        /// in all nodes, and thus should not be used for core business processes unless a Trading 
        /// Partner Agreement (TPA) is established.   
        /// 
        /// The successful response message contains a ResultSetType structure, which not only 
        /// contains the actual result XML document, but also the description of the result set.
        /// 
        /// The Query method requires the following arguments: 
        /// 
        ///		securityToken: A security ticket issued by the service provider or a trusted 
        ///			security provider. 
        /// 
        ///		dataflow: The name of the dataflow. 
        /// 
        ///		request: The database query to be processed.  This should be defined for each 
        ///			data exchange and listed in the corresponding Flow Configuration Document 
        ///			(FCD). 
        /// 
        ///		rowId: The starting row for the result set - it is a zero based index to the current 
        ///			result set. The value of rowId must be 0 if paging is not requested.  
        /// 
        ///		maxRow: The maximum number of rows to be returned. Valid values are any 
        ///			number greater than 0, and -1.  If maxRow is -1, the service provider must return 
        ///			the entire result set (and indicates that paging is not requested).  If the request 
        ///			maxRow parameter is too large, or the maxRow parameter is -1 and the result set 
        ///			is too large for a node to process synchronously, a SOAP fault message with an 
        ///			error code of E_QueryReturnSetTooBig must be returned.  A node may return 
        ///			fewer results if the complete result set is smaller than the value specified in 
        ///			maxRows. 
        /// 
        ///		parameters: An array of zero or more ParameterType structures (see section 3.6) 
        ///			for the information request.  Note that Nodes are only required to support 
        ///			parameters of encoding type String and XML.  All other encoding types are 
        ///			optional, and it is the responsibility of the requestor to verify that other parameter 
        ///			encoding types are supported by the receiving Node.
        /// </remarks>
        /// <param name="queryArg">Query</param>
        /// <returns>ResultSetType</returns>
        ResultSetType INetworkNodeBinding2.Query(Query queryArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Query(): {0}", ReflectionUtils.GetPublicPropertiesString(queryArg));

            #region Validate
            if (queryArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Query argument");
            }
            if (string.IsNullOrEmpty(queryArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }
            if (string.IsNullOrEmpty(queryArg.dataflow))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Dataflow argument");
            }
            if (string.IsNullOrEmpty(queryArg.request))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Request argument");
            }
            int rowIdValue;
            if (!int.TryParse(queryArg.rowId, out rowIdValue) || (rowIdValue < 0))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "Invalid RowId argument");
            }
            int maxRowsValue;
            if (!int.TryParse(queryArg.maxRows, out maxRowsValue) ||
                 !((maxRowsValue == -1) || (maxRowsValue > 0)))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "Invalid MaxRows argument");
            }
            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(queryArg.securityToken);

                PaginatedContentRequest request = new PaginatedContentRequest();
                request.FlowName = queryArg.dataflow;
                request.OperationName = queryArg.request;
                request.Paging = new PaginationIndicator();
                request.Paging.Start = rowIdValue;
                request.Paging.Count = maxRowsValue;

                request.Parameters = CreateParameters(queryArg.parameters);

                LOG.Debug("Querying: " + request);
                PaginatedContentResult resultSet =
                    _service20Provider.TransactionService.Query(request, visit);

                LOG.Debug("ResultSet: " + resultSet);
                ResultSetType wsdlResultSet = new ResultSetType();
                wsdlResultSet.lastSet = resultSet.Paging.IsLast;
                wsdlResultSet.results = NewGenericXmlType(resultSet.Content);
                wsdlResultSet.rowCount = resultSet.Paging.Count.ToString();
                wsdlResultSet.rowId = resultSet.Paging.Start.ToString();
                return wsdlResultSet;
            }
            catch (Exception ex)
            {
                LOG.Error("Error while querying", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// Solicit
        /// </summary>
        /// <param name="solicitArg"></param>
        /// <returns></returns>
        StatusResponseType INetworkNodeBinding2.Solicit(Solicit solicitArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Solicit(): {0}", ReflectionUtils.GetPublicPropertiesString(solicitArg));

            #region Validate
            if (solicitArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Solicit argument");
            }
            if (string.IsNullOrEmpty(solicitArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }
            if (string.IsNullOrEmpty(solicitArg.dataflow))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Dataflow argument");
            }
            if (string.IsNullOrEmpty(solicitArg.request))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Request argument");
            }
            #endregion Validate

            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(solicitArg.securityToken);

                AsyncContentRequest request = new AsyncContentRequest();

                request.FlowName = solicitArg.dataflow;
                request.OperationName = solicitArg.request;
                request.Parameters = CreateParameters(solicitArg.parameters);
                request.Recipients = (solicitArg.recipient != null) ?
                    new List<string>(solicitArg.recipient) : new List<string>();
                request.Notifications = CreateNotifications(solicitArg.notificationURI);

                LOG.Debug("Soliciting: " + request);
                TransactionStatus status =
                    _service20Provider.TransactionService.Solicit(request, visit);

                LOG.Debug("Status: " + status);
                return StatusResponseTypeFromTransactionStatus(status);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while soliciting", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }


        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="executeArg"></param>
        /// <returns></returns>
        ExecuteResponse INetworkNodeBinding2.Execute(Execute executeArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.Execute(): {0}", ReflectionUtils.GetPublicPropertiesString(executeArg));

            #region Validate
            if (executeArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL Execute argument");
            }
            if (string.IsNullOrEmpty(executeArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }
            if (string.IsNullOrEmpty(executeArg.methodName))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL MethodName argument");
            }
            if (string.IsNullOrEmpty(executeArg.interfaceName))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL InterfaceName argument");
            }
            #endregion Validate
            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(executeArg.securityToken);

                ServiceContentRequest request = new ServiceContentRequest();

                request.Interface = executeArg.interfaceName;
                request.OperationName = executeArg.methodName;
                request.Parameters = CreateParameters(executeArg.parameters);

                LOG.Debug("Executing: " + request);
                ExecuteContentResultEx result =
                    _service20Provider.TransactionService.Execute(request, visit);

                LOG.Debug("Result: " + result);
                return ExecuteResponseFromExecuteContentResult(result);
            }
            catch (Exception ex)
            {
                LOG.Error("Error while executing", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }


        /// <summary>
        /// NodePing
        /// </summary>
        /// <param name="nodePingArg"></param>
        /// <returns></returns>
        NodePingResponse INetworkNodeBinding2.NodePing(NodePing nodePingArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.NodePing(): {0}", ReflectionUtils.GetPublicPropertiesString(nodePingArg));
            #region Validate
            if (nodePingArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL NodePing argument");
            }
            #endregion Validate
            try
            {
                NodePingResponse response = new NodePingResponse();
                response.nodeStatus = NodeStatusCode.Ready;
                response.statusDetail = "The service is up and running.";
                return response;
            }
            catch (Exception ex)
            {
                LOG.Error("Error while pinging", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        /// <summary>
        /// GetServices
        /// </summary>
        GenericXmlType INetworkNodeBinding2.GetServices(GetServices getServicesArg)
        {
            Init();
            LOG.Debug("INetworkNodeBinding2.GetServices(): {0}", ReflectionUtils.GetPublicPropertiesString(getServicesArg));
            #region Validate
            if (getServicesArg == null)
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL GetServices argument");
            }
            if (string.IsNullOrEmpty(getServicesArg.securityToken))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL SecurityToken argument");
            }
            if (string.IsNullOrEmpty(getServicesArg.serviceCategory))
            {
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ENExceptionCodeType.E_InvalidParameter, "NULL ServiceCategory argument");
            }
            #endregion Validate
            try
            {
                LOG.Debug("Getting visit");
                NamedEndpointVisit visit =
                    _service20Provider.VisitProvider.GetVisit(getServicesArg.securityToken);

                LOG.Debug("Calling GetMetaData(): " + getServicesArg.serviceCategory);
                SimpleContent simpleContent =
                    _service20Provider.ContentService.GetMetaData(getServicesArg.serviceCategory, visit);

                GenericXmlType genericXmlType = NewGenericXmlType(simpleContent);

                LOG.Debug("Returning GenericXmlType: " + genericXmlType);
                return genericXmlType;
            }
            catch (Exception ex)
            {
                LOG.Error("Error while getting services", ex);
                throw _service20Provider.FaultProvider.GetFault(EndpointVersionType.EN20, ex);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// StatusResponseTypeFromTransactionStatus
        /// </summary>
        /// <param name="inStatus"></param>
        /// <returns></returns>
        private static StatusResponseType StatusResponseTypeFromTransactionStatus(TransactionStatus inStatus)
        {
            CommonTransactionStatusCode statusCode = inStatus.Status;
            if (statusCode == CommonTransactionStatusCode.ReceivedUnprocessed)
            {
                statusCode = CommonTransactionStatusCode.Received;
            }
            StatusResponseType statusResponseType = new StatusResponseType();
            statusResponseType.status =
                EnumUtils.ParseEnum<TransactionStatusCode>(statusCode.ToString());
            statusResponseType.statusDetail = string.IsNullOrEmpty(inStatus.Description) ? statusCode.ToString() : inStatus.Description;
            statusResponseType.transactionId = inStatus.Id;
            return statusResponseType;
        }

        /// <summary>
        /// ExecuteResponseFromExecuteContentResult
        /// </summary>
        /// <param name="inStatus"></param>
        /// <returns></returns>
        private static ExecuteResponse ExecuteResponseFromExecuteContentResult(ExecuteContentResultEx inResult)
        {
            ExecuteResponse executeResponse = new ExecuteResponse();
            executeResponse.status =
                EnumUtils.ParseEnum<TransactionStatusCode>(inResult.Status.ToString());
            executeResponse.transactionId = inResult.Id;
            executeResponse.results = NewGenericXmlType(inResult.Content);
            return executeResponse;
        }

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType
            Convert(Windsor.Node2008.Endpoint2.NotificationMessageCategoryType code)
        {
            switch (code)
            {
                case Windsor.Node2008.Endpoint2.NotificationMessageCategoryType.Document:
                    return Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType.Document;

                case Windsor.Node2008.Endpoint2.NotificationMessageCategoryType.Event:
                    return Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType.Event;

                case Windsor.Node2008.Endpoint2.NotificationMessageCategoryType.Status:
                    return Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType.Status;

                default:
                    return Windsor.Node2008.WNOSDomain.NotificationMessageCategoryType.None;
            }
        }

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static DocumentFormatType Convert(CommonContentType type)
        {
            switch (type)
            {
                case CommonContentType.XML:
                    return DocumentFormatType.XML;

                case CommonContentType.Flat:
                    return DocumentFormatType.FLAT;

                case CommonContentType.Bin:
                    return DocumentFormatType.BIN;

                case CommonContentType.ZIP:
                    return DocumentFormatType.ZIP;

                case CommonContentType.ODF:
                    return DocumentFormatType.ODF;

                default:
                    return DocumentFormatType.OTHER;
            }
        }

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static CommonContentType Convert(DocumentFormatType type)
        {
            switch (type)
            {
                case DocumentFormatType.XML:
                    return CommonContentType.XML;

                case DocumentFormatType.FLAT:
                    return CommonContentType.Flat;

                case DocumentFormatType.BIN:
                    return CommonContentType.Bin;

                case DocumentFormatType.ZIP:
                    return CommonContentType.ZIP;

                case DocumentFormatType.ODF:
                    return CommonContentType.ODF;

                default:
                    return CommonContentType.OTHER;
            }
        }

        /// <summary>
        /// CreateParametersByName
        /// </summary>
        /// <param name="inParams"></param>
        /// <returns></returns>
        private static ByIndexOrNameDictionary<string> CreateParameters(ParameterType[] inParams)
        {
            ByIndexOrNameDictionary<string> parameters = new ByIndexOrNameDictionary<string>(true);
            if ((inParams != null) && (inParams.Length > 0))
            {
                foreach (ParameterType wsdlParameter in inParams)
                {
                    LOG.Info(string.Format("CreateParameters(): {0}", ReflectionUtils.GetPublicPropertiesString(wsdlParameter)));
                    parameters.Add(wsdlParameter.parameterName, wsdlParameter.Value);
                }
            }
            return parameters;
        }

        /// <summary>
        /// CreateNotifications
        /// </summary>
        /// <param name="inWsdlNotifications"></param>
        /// <returns></returns>
        private static Dictionary<string, TransactionNotificationType> CreateNotifications(NotificationURIType[] inWsdlNotifications)
        {
            Dictionary<string, TransactionNotificationType> notifs = new Dictionary<string, TransactionNotificationType>();
            if ((inWsdlNotifications != null) && (inWsdlNotifications.Length > 0))
            {
                foreach (NotificationURIType wsdlNotif in inWsdlNotifications)
                {
                    if (!string.IsNullOrEmpty(wsdlNotif.Value))
                    {
                        TransactionNotificationType notificationType;
                        if (wsdlNotif.notificationTypeSpecified)
                        {
                            notificationType = EnumUtils.ParseEnum<TransactionNotificationType>(wsdlNotif.notificationType.ToString());
                        }
                        else
                        {
                            notificationType = TransactionNotificationType.All;
                        }
                        notifs.Add(wsdlNotif.Value, notificationType);
                    }
                }
            }
            return notifs;
        }
        
        private static GenericXmlType NewGenericXmlType(SimpleContent simpleContent) {
            return NewGenericXmlType(Convert(simpleContent.Type), simpleContent.Content);
        }
        private static GenericXmlType NewGenericXmlType(DocumentFormatType type, 
														byte[] content) {
            GenericXmlType genericXmlType = new GenericXmlType();
            genericXmlType.format = type;
            if ( genericXmlType.format == DocumentFormatType.ZIP ) {
				XmlDocument xmlDoc = new XmlDocument();
				string base64String = (content == null) ?
					string.Empty : System.Convert.ToBase64String(content);
				genericXmlType.Any = new XmlNode[] { xmlDoc.CreateTextNode(base64String) };
            } else {
				XmlDocument xmlDoc = new XmlDocument();
                using (XmlTextReader reader = new XmlTextReader(new MemoryStream(content)))
                {
                    xmlDoc.Load(reader);
                }
				genericXmlType.Any = new XmlNode[] { xmlDoc.DocumentElement };
            }
            return genericXmlType;
        }
        #endregion
    }
}
