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
using System.Collections.Specialized;
using System.Text;
using System.IO;

using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSConnector.Logic
{
	/// <summary>
	/// Interface for managing node notifications.
	/// </summary>
    public interface INotificationManager
    {

		/// <summary>
		/// DoSubmitNotifications
		/// </summary>
		void DoSubmitNotifications(TransactionStatus status, string flowId, string flowName,
								   string operation, string username);
        /// <summary>
        /// DoRemoteTransactionStatusNotifications
        /// </summary>
        void DoRemoteTransactionStatusNotifications(NodeMethod transactionMethod, string filePath,
                                                    TransactionStatus status,
                                                    string flowName, string operation,
                                                    string emailAddresses);
        /// <summary>
		/// DoDownloadNotifications
		/// </summary>
		void DoDownloadNotifications(string transactionId, string flowId, string flowName,
								     string username);
		/// <summary>
		/// DoQueryNotifications
		/// </summary>
		void DoQueryNotifications(string flowId, string transactionId, string flowName, string username, string serviceName, 
								  int startRow, int maxRows, ByIndexOrNameDictionary<string> parameters);
		/// <summary>
		/// DoSolicitNotifications
		/// </summary>
		void DoSolicitNotifications(TransactionStatus status, string flowId, string flowName, string username, 
									string serviceName, ByIndexOrNameDictionary<string> parameters);
		/// <summary>
		/// DoNotifyNotifications
		/// </summary>
		void DoNotifyNotifications(TransactionStatus status, string flowId, string flowName,
								   string username);
        /// <summary>
        /// DoExecuteNotifications
        /// </summary>
        void DoExecuteNotifications(string transactionId, CommonTransactionStatusCode status,
                                    string flowId, string interfaceName, string username,
                                    string methodName, ByIndexOrNameDictionary<string> parameters);

        /// <summary>
        /// DoScheduleNotifications
        /// </summary>
        void DoScheduleNotifications(TransactionStatus status, string emailAddresses,
                                     string scheduleName, Stream attachmentContent,
                                     string attachmentName);

        /// <summary>
        /// DoScheduleNotifications
        /// </summary>
        void DoScheduleNotifications(TransactionStatus status, string emailAddresses,
                                     string scheduleName, string attachmentFile,
                                     string attachmentName);

        /// <summary>
        /// DoScheduleNotifications
        /// </summary>
        void DoScheduleNotifications(TransactionStatus status, string flowId, string scheduleName);

        /// <summary>
        /// DoChangePasswordNotifications
        /// </summary>
        void DoChangePasswordNotifications(string username, string password);

        /// <summary>
        /// DoNewNaasAccountNotifications
        /// </summary>
        void DoNewNaasAccountNotifications(string username, string password);

        /// <summary>
        /// DoNewNodeAccountNotifications
        /// </summary>
        void DoNewNodeAccountNotifications(string username);
    }
}
