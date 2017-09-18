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

namespace Windsor.Node.Proxy11
{
    using System;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using Windsor.Node.Proxy11.WSDL;

    public interface INodeRequestor11
    {
        event NodeDownloadEventHandler AsyncDownloadCompletedEvent;

        event NodeQueryEventHandler AsyncQueryCompletedEvent;

        event NodeSubmitEventHandler AsyncSubmitCompletedEvent;

        event RequestorEventHandler RequestorEvent;

        string Authenticate(string userId, string password);
        void Configure(string url);
        void Configure(string url, IWebProxy httpProxy);
        void Download(string securityToken, string transactionId, string dataflow, ref NodeDocument[] documents);
        string[] Download(string securityToken, string transactionId, string dataflow, string directoryPath,
                          bool overwriteExistingFiles);
        void DownloadAsync(string securityToken, string transactionId, string dataflow, string directoryPath);
        string GetEndpointURL();
        string[] GetServices(string securityToken, string serviceType);
        string GetStatus(string securityToken, string transactionId);
        string Notify(string securityToken, string nodeAddress, string dataflow, NodeDocument[] documents);
        string Notify(string securityToken, string nodeAddress, string dataflow, string name, string type, string message);
        string NotifyEvent(string securityToken, string nodeAddress, string eventName, string eventType, string eventDescription);
        string NotifyStatus(string securityToken, string nodeAddress, string transactionId, string statusCode, string statusDescription);
        string Ping();
        string Ping(string helloMessage);
        string Query(string securityToken, string request, string[] parameters);
        string Query(string securityToken, string request, int rowId, int maxRows, string[] parameters);
        void Query(string securityToken, string request, int rowId, int maxRows, string[] parameters, string filePath);
        void Query(string securityToken, string request, int rowId, int maxRows, string[] parameters, ref XmlDocument doc);
        void QueryAsync(string securityToken, string request, int rowId, int maxRows, string[] parameters, string filePath);
        void SetEndpointURL(string url);
        string Solicit(string securityToken, string request, string[] parameters);
        string Solicit(string securityToken, string returnURL, string request, string[] parameters);
        string Submit(string securityToken, string dataflow, string[] filePaths);
        string Submit(string securityToken, string dataflow, NodeDocument[] documents);
        string Submit(string securityToken, string transactionId, string dataflow, string[] filePaths);
        string Submit(string securityToken, string transactionId, string dataflow, NodeDocument[] documents);
        void SubmitAsync(string securityToken, string transactionId, string dataflow, string[] filePaths);
        int Timeout { get; set; }
    }
}

