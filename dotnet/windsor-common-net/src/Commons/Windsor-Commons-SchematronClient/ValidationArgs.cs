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
using System.Text;
using System.Net;
using Windsor.Commons.Core;

namespace Windsor.Commons.SchematronClient
{
    public class ValidationRequestArgs
    {
        private readonly string _documentPath;
        private readonly NetworkCredential _credential;
        private readonly string[] _notificationEmails;


        public ValidationRequestArgs(string documentPath, 
            NetworkCredential credential, params string[] notificationEmails)
        {
            _documentPath = documentPath;
            _credential = credential;
            _notificationEmails = notificationEmails;
        }


        public string DocumentPath
        {
            get { return _documentPath; }
        }

        public NetworkCredential Credential
        {
            get { return _credential; }
        }

        public string[] NotificationEmails
        {
            get { return _notificationEmails; }
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }


    public class ValidationResultArgs : EventArgs
    {

        private readonly string _transactionId;
        private readonly ValidationRequestArgs _requestArgs;
        private readonly Exception _error;

        public ValidationResultArgs(string transactionId, ValidationRequestArgs requestArgs)
        {
            _transactionId = transactionId;
            _requestArgs = requestArgs;
        }

        public ValidationResultArgs(Exception error, ValidationRequestArgs requestArgs)
        {
            _error = error;
            _requestArgs = requestArgs;
        }

        public ValidationResultArgs(Exception error)
        {
            _error = error;
        }


        public ValidationRequestArgs RequestArgs
        {
            get { return _requestArgs; }
        }

        public string TransactionId
        {
            get { return _transactionId; }
        }

        public Exception Error
        {
            get { return _error; }
        }
    }


    public class ValidationReportRequest
    {
        private readonly string _transactionId;
        private readonly NetworkCredential _credential;

        public ValidationReportRequest(NetworkCredential credential, string transactionId)
        {
            _transactionId = transactionId;
            _credential = credential;
        }

        public string TransactionId
        {
            get { return _transactionId; }
        }

        public NetworkCredential Credential
        {
            get { return _credential; }
        }


        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }


    public class ValidationReportResult
    {

        private readonly string _transactionId;
        private string _validationType;
        private readonly ProcessStatus _processStatus;
        private string _documentStatus;
        private DateTime _timeStamp;
        private string _results;
        private Exception _error;

        public enum ProcessStatus
        {
            None,
            Pending,
            Processing,
            Finished,
            Failed
        }

        public ValidationReportResult(string transactionId, ProcessStatus processStatus)
        {
            _transactionId = transactionId;
            _processStatus = processStatus;
        }


        public string TransactionId
        {
            get { return _transactionId; }
        }

        public string ValidationType
        {
            get { return _validationType; }
            set { _validationType = value; }
        }

        public ProcessStatus Status
        {
            get { return _processStatus; }
        }

        public string DocumentStatus
        {
            get { return _documentStatus; }
            set { _documentStatus = value; }
        }

        public System.DateTime Time
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        public string Detail
        {
            get { return _results; }
            set { _results = value; }
        }

        public Exception Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
