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

﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSProviders
{
    /// <summary>
    /// This interface provides common client Exchange node functionality for the v1.1 and v2.0 node endpoints.
    /// </summary>
    public interface INodeEndpointClient : IDisposable
    {
        #region Properties
        /// <summary>
        /// Return the Exchange node version. 
        /// </summary>
        EndpointVersionType Version { get; }

        /// <summary>
        /// Return the Exchange node url. 
        /// </summary>
        string Url { get; }

        /// <summary>
        /// The cached NAAS authentication security token set for this node proxy client.
        /// </summary>
        string NaasToken { get; }

        event NodeStatusMessageEventHandler StatusMessageEvent;

        #endregion // Properties

        #region Methods
        /// <summary>
        /// Autheticate the current credentials specified for this endpoint against the node.
        /// </summary>
        /// <returns>NAAS authentication security token.</returns>
        string Authenticate();

        /// <summary>
        /// Autheticate the input user against the node.
        /// </summary>
        /// <param name="userID">NAAS username for the user to authenticate.</param>
        /// <param name="credential">NAAS credential/password for the user to authenticate.</param>
        /// <returns>NAAS authentication security token.</returns>
        string Authenticate(string userID, string credential);

        /// <summary>
        /// Download documents associated with the input transaction.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="documentIds">One or more document ids associated with the transaction.</param>
        /// <returns>Array of temporary file paths for each downloaded document in the same order as the 
        /// input document id parameters.</returns>
        string[] DownloadById(string flow, string transactionId, params string[] documentIds);

        /// <summary>
        /// Download all documents associated with the input transaction.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <returns>Array of temporary file paths for each downloaded document.</returns>
        string[] Download(string flow, string transactionId);

        /// <summary>
        /// Download all documents associated with the input transaction to the specified directory.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="directoryPath">Full path to the directory to place the downloaded documents.
        /// This directory will be created if it does not exist.  All downloaded documents are given
        /// unique names.</param>
        /// <returns>Array of file paths for each downloaded document.</returns>
        string[] DownloadToDirectory(string flow, string transactionId, string directoryPath);

        /// <summary>
        /// Download documents associated with the input transaction.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="documentNames">One or more document names associated with the transaction.</param>
        /// <returns>Array of temporary file paths for each downloaded document, in the same order as the 
        /// input document name parameters.</returns>
        string[] DownloadByName(string flow, string transactionId, params string[] documentNames);

        /// <summary>
        /// Download all documents associated with the input transaction, and return
        /// a list of the document ids associated with each downloaded document.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="documentIds">Array of document ids associated with each downloaded 
        /// document, in the same order as the returned document file paths.</param>
        /// <returns>Array of temporary file paths for each downloaded document.</returns>
        string[] DownloadWithDocumentIds(string flow, string transactionId,
                                         out IList<string> documentIds);

        /// <summary>
        /// Download all documents associated with the input transaction, and return
        /// a list of the document names associated with each downloaded document.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the transaction.</param>
        /// <param name="transactionId">Id of the transaction.</param>
        /// <param name="documentNames">Array of document names associated with each downloaded 
        /// document, in the same order as the returned document file paths.</param>
        /// <returns>Array of temporary file paths for each downloaded document.</returns>
        string[] DownloadWithDocumentNames(string flow, string transactionId,
                                           out IList<string> documentNames);

        /// <summary>
        /// Ping the node to ensure that it is accessible.  This method will raise an exception
        /// if the node is not accessible.
        /// </summary>
        /// <returns>Ready string returned by node.</returns>
        string NodePing();

        /// <summary>
        /// The GetServices method allows requesters to find out the service capabilities of a node and 
        /// discover how the services can be invoked. 
        /// </summary>
        /// <param name="filter">The filter to use for the returned services.</param>
        /// <returns></returns>
        XmlDocument GetServices(string filter);

        /// <summary>
        /// Get the status of the input transaction.
        /// </summary>
        /// <param name="transactionId">Id of the transaction to check.</param>
        /// <returns>The current status of the transaction.</returns>
        CommonTransactionStatusCode GetStatus(string transactionId);

        /// <summary>
        /// Send a status notification to a v2.0 node.  This method should only be called if Version == EndpointVersionType.EN20.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="transactionId">Id of the transaction associated with the notification.</param>
        /// <param name="status">Status of the transaction associated with the notification.</param>
        /// <param name="description">Description of the status of the transaction associated with the notification.</param>
        /// <returns>The current status of the processing of the notification by the remote node.</returns>
        CommonTransactionStatusCode NotifyStatus20(string nodeEndpoint, string flow, string transactionId,
                                                   CommonTransactionStatusCode status, string description);
        /// <summary>
        /// Send an event notification to a v2.0 node.  This method should only be called if Version == EndpointVersionType.EN20.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="flow">Name of the flow associated with the notification.</param>
        /// <param name="messageName">Name of the message associated with the notification.</param>
        /// <param name="status">Status of the event associated with the notification.</param>
        /// <param name="description">Description of the status of the transaction associated with the notification.</param>
        /// <param name="eventName">Name of the event associated with the notification.</param>
        /// <returns>The current status of the processing of the notification by the remote node.</returns>
        CommonTransactionStatusCode NotifyEvent20(string nodeEndpoint, string flow, string messageName,
                                                  CommonTransactionStatusCode status, string description,
                                                  string eventName);

        /// <summary>
        /// Send an event notification to a v1.1 node.  This method should only be called if Version == EndpointVersionType.EN11.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="eventName">Name of the event associated with the notification.</param>
        /// <param name="eventType">Type of the event associated with the notification.</param>
        /// <param name="eventDescription">Description of the event associated with the notification.</param>
        /// <returns>The current status of the processing of the notification by the remote node.</returns>
        CommonTransactionStatusCode NotifyEvent11(string nodeEndpoint, string eventName,
                                                  string eventType, string eventDescription);

        /// <summary>
        /// Send a document notification to a v2.0 node.  This method should only be called if Version == EndpointVersionType.EN20.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="flow">Name of the flow associated with the notification.</param>
        /// <param name="status">Status of the documents associated with the notification.</param>
        /// <param name="description">Description of the status of the documents associated with the notification.</param>
        /// <param name="documentIds">One or more document ids associated with the notification.</param>
        /// <returns>The current status of the processing of the notification by the remote node.</returns>
        string NotifyDocument20(string nodeEndpoint, string flow, CommonTransactionStatusCode status,
                                string description, params string[] documentIds);

        /// <summary>
        /// Send a document notification to a v1.1 node.  This method should only be called if Version == EndpointVersionType.EN11.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="flow">Name of the flow associated with the notification.</param>
        /// <param name="documentFilePaths">One or more document file paths associated with the notification.  The
        /// types of the documents (CommonContentType) will be determined from each document's file extension.</param>
        /// <returns>The transaction id of the notification from the remote node.</returns>
        string NotifyDocument11(string nodeEndpoint, string flow, params string[] documentFilePaths);

        /// <summary>
        /// Send a document notification to a v1.1 node.  This method should only be called if Version == EndpointVersionType.EN11.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="flow">Name of the flow associated with the notification.</param>
        /// <param name="name">Name of the document associated with the notification.</param>
        /// <param name="type">Type of the document associated with the notification.</param>
        /// <param name="content">Content of the document associated with the notification.</param>
        /// <returns>The transaction id of the notification from the remote node.</returns>
        string NotifyDocument11(string nodeEndpoint, string flow, string name, CommonContentType type, string content);

        /// <summary>
        /// Send a status notification to a v1.1 node.  This method should only be called if Version == EndpointVersionType.EN11.
        /// </summary>
        /// <param name="nodeEndpoint">Url of the node that is submitting the notification.</param>
        /// <param name="transactionId">Id of the transaction associated with the notification.</param>
        /// <param name="status">Status of the transaction associated with the notification.</param>
        /// <param name="description">Description of the status of the transaction associated with the notification.</param>
        /// <returns>The current status of the processing of the notification by the remote node.</returns>
        CommonTransactionStatusCode NotifyStatus11(string nodeEndpoint, string transactionId,
                                                   CommonTransactionStatusCode status, string description);

        /// <summary>
        /// Perform a query operation on the node.
        /// </summary>
        /// <param name="request">Name of the flow request associated with the query.</param>
        /// <param name="arguments">Arguments associated with the query (may be null).</param>
        /// <returns>Results of the query.</returns>
        XmlDocument Query(string request, ByIndexOrNameDictionary<string> arguments);
        string QueryXmlString(string request, ByIndexOrNameDictionary<string> arguments);

        /// <summary>
        /// Perform a query operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the query.</param>
        /// <param name="request">Name of the flow request associated with the query.</param>
        /// <param name="arguments">Arguments associated with the query (may be null).</param>
        /// <returns>Results of the query.</returns>
        XmlDocument Query(string flow, string request, ByIndexOrNameDictionary<string> arguments);
        string QueryXmlString(string flow, string request, ByIndexOrNameDictionary<string> arguments);

        /// <summary>
        /// Perform a query operation on the node and return a subset of results.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the query.</param>
        /// <param name="request">Name of the flow request associated with the query.</param>
        /// <param name="arguments">Arguments associated with the query (may be null).</param>
        /// <param name="startRow">The starting row for the query.</param>
        /// <param name="pageSize">The number of items to return for the query.</param>
        /// <returns>Results of the query.</returns>
        XmlDocument Query(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                          Int32 startRow, Int32 pageSize);
        string QueryXmlString(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                              Int32 startRow, Int32 pageSize);

        /// <summary>
        /// Perform a query operation on the node and return a subset of results.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the query.</param>
        /// <param name="request">Name of the flow request associated with the query.</param>
        /// <param name="arguments">Arguments associated with the query (may be null).</param>
        /// <param name="startRow">The starting row for the query.</param>
        /// <param name="pageSize">The number of items to return for the query.</param>
        /// <param name="targetPath">The location to save the query results as a file.</param>
        /// <returns>The type of result file saved to targetPath</returns>
        CommonContentType Query(string flow, string request, ByIndexOrNameDictionary<string> arguments,
                                Int32 startRow, Int32 pageSize, string targetPath);

        /// <summary>
        /// Perform a solicit operation on the node.
        /// </summary>
        /// <param name="request">Name of the flow request associated with the solicit.</param>
        /// <param name="arguments">Arguments associated with the solicit (may be null).</param>
        /// <returns>Transaction id of the solicit operation.</returns>
        string Solicit(string request, ByIndexOrNameDictionary<string> arguments);

        /// <summary>
        /// Perform a solicit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the solicit.</param>
        /// <param name="request">Name of the flow request associated with the solicit.</param>
        /// <param name="arguments">Arguments associated with the solicit (may be null).</param>
        /// <returns>Transaction id of the solicit operation.</returns>
        string Solicit(string flow, string request, ByIndexOrNameDictionary<string> arguments);

        /// <summary>
        /// Perform a solicit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the solicit.</param>
        /// <param name="request">Name of the flow request associated with the solicit.</param>
        /// <param name="arguments">Arguments associated with the solicit (may be null).</param>
        /// <param name="notificationURIs">A list of notification emails or node endpoint urls for transaction status notification.</param>
        /// <returns>Transaction id of the solicit operation.</returns>
        string Solicit(string flow, string request, ByIndexOrNameDictionary<string> arguments, IList<string> notificationURIs);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="documentPaths">A list of documents for submission.  The extension of each file will be used to
        /// determine the file type.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string transactionId, IList<string> documentPaths);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="documents">A list of documents for submission.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string transactionId, IList<EndpointDocument> documents);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="operation">Name of the flow operation associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="documentPaths">A list of documents for submission.  The extension of each file will be used to
        /// determine the file type.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string operation, string transactionId, IList<string> documentPaths);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="operation">Name of the flow operation associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="documents">A list of documents for submission.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string operation, string transactionId, IList<EndpointDocument> documents);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="operation">Name of the flow operation associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="notificationURIs">A list of notification emails or node endpoint urls for transaction status notification.</param>
        /// <param name="documentPaths">A list of documents for submission.  The extension of each file will be used to
        /// determine the file type.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string operation, string transactionId, IList<string> notificationURIs,
                      IList<string> documentPaths);

        /// <summary>
        /// Perform a submit operation on the node.
        /// </summary>
        /// <param name="flow">Name of the flow associated with the submit.</param>
        /// <param name="operation">Name of the flow operation associated with the submit.</param>
        /// <param name="transactionId">Transaction id of previous submission, or null if this is a new submission.</param>
        /// <param name="notificationURIs">A list of notification emails or node endpoint urls for transaction status notification.</param>
        /// <param name="documents">A list of documents for submission.</param>
        /// <returns>Transaction id of the submit operation.</returns>
        string Submit(string flow, string operation, string transactionId, IList<string> notificationURIs,
                      IList<EndpointDocument> documents);

        /// <summary>
        /// Perform an execute operation on the node.
        /// </summary>
        /// <param name="interfaceName">Name of the interface associated with the execute operation.</param>
        /// <param name="methodName">Name of the method associated with the execute operation.</param>
        /// <param name="arguments">Arguments associated with the execute operation (may be null).</param>
        /// <param name="transactionId">Returned transaction id of the execute operation.</param>
        /// <returns>Results of the execute operation.</returns>
        XmlDocument Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments,
                            out string transactionId);

        /// <summary>
        /// Perform an execute operation on the node.
        /// </summary>
        /// <param name="interfaceName">Name of the interface associated with the execute operation.</param>
        /// <param name="methodName">Name of the method associated with the execute operation.</param>
        /// <param name="arguments">Arguments associated with the execute operation (may be null).</param>
        /// <param name="targetPath">The location to save the execute results as a file.</param>
        /// <returns>Transaction id of the execute operation.</returns>
        string Execute(string interfaceName, string methodName, ByIndexOrNameDictionary<string> arguments,
                       string targetPath);

        #endregion Methods
    }
    [Serializable]
    public class NodeStatusMessageEventArgs : EventArgs
    {
        private string _message;

        public NodeStatusMessageEventArgs(string message)
        {
            _message = message;
        }
        public string Message
        {
            get
            {
                return this._message;
            }
        }
    }
    public delegate void NodeStatusMessageEventHandler(INodeEndpointClient sender,
                                                       NodeStatusMessageEventArgs message);
}
