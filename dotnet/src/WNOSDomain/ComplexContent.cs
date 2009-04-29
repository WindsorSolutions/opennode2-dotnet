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
using Windsor.Commons.Core;

using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class ComplexContent
    {
        private OperationDataFlow _flow;
        private List<Document> _documents;
        private SimpleId _transaction;

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }

        public SimpleId Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public List<Document> Documents
        {
            get { return _documents; }
            set { _documents = value; }
        }

        public OperationDataFlow Flow
        {
            get { return _flow; }
            set { _flow = value; }
        }
    }

    [Serializable]
    public class AsyncComplexContent : ComplexContent
    {
        private IList<string> _recipients;
        private IDictionary<string, TransactionNotificationType> _notifications;

        public IDictionary<string, TransactionNotificationType> Notifications
        {
            get { return _notifications; }
            set { _notifications = value; }
        }

        public IList<string> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }
    }
}
