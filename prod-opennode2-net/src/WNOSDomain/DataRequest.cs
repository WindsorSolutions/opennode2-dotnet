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
using System.Reflection;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class DataRequest : AuditableIdentity
    {
        private string _transactionId;
        private DataService _service;
        private Uri _returnUrl;
        private RequestType _type;
        private int rowIndex;
        private int maxRowCount;
        private ByIndexOrNameDictionary<string> _parameters;

        public DataRequest()
        {
        }

        public string TransactionId
        {
            get
            {
                return _transactionId;
            }
            set
            {
                _transactionId = value;
            }
        }
        public DataService Service
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value;
            }
        }
        public Uri ReturnUrl
        {
            get
            {
                return _returnUrl;
            }
            set
            {
                _returnUrl = value;
            }
        }
        public RequestType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        public int RowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }
        public int MaxRowCount
        {
            get
            {
                return maxRowCount;
            }
            set
            {
                maxRowCount = value;
            }
        }
        public ByIndexOrNameDictionary<string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
