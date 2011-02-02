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

using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class ActivitySearchParams
    {
        public static readonly DateTime MIN_DATETIME = DateTime.Parse("2/12/1970 6:15 AM");
        public static readonly DateTime MAX_DATETIME = DateTime.Parse("2/12/2050 6:15 AM");

        private ActivityType _type;
        private string _transactionId;
        private string _ip;
        private string _createdByUsername;
        private DateTime _createdFrom = MIN_DATETIME;
        private DateTime _createdTo = MAX_DATETIME;
        private string _detailContains;
        private string _flowName;
        private string _operationName;

        public string FlowName
        {
            get { return _flowName; }
            set { _flowName = value; }
        }
        public string OperationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }
        public DateTime CreatedTo
        {
            get { return _createdTo; }
            set { _createdTo = value; }
        }

        public DateTime CreatedFrom
        {
            get { return _createdFrom; }
            set { _createdFrom = value; }
        }
        public ActivityType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string CreatedByUsername
        {
            get { return _createdByUsername; }
            set { _createdByUsername = value; }
        }
        public string DetailContains
        {
            get { return _detailContains; }
            set { _detailContains = value; }
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }

        public static DateTime ConstrainDate(DateTime date)
        {
            if (date < MIN_DATETIME)
            {
                return MIN_DATETIME;
            }
            else if (date > MAX_DATETIME)
            {
                return MAX_DATETIME;
            }
            else
            {
                return date;
            }
        }
    }
}
