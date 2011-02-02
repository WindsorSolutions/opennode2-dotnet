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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.IO;
using Windsor.Commons.Core;

using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object representing an auditable activity that can be used for WNOS activity reporting.  
    /// Each activity contains 0 or more activity message entries.
    /// </summary>
    [Serializable]
    public class Activity : AuditableIdentity
    {
        private ActivityType _type;
        private List<ActivityEntry> _entries;
        private string _transactionId;
        private string _ip;
        private NodeMethod _method;
        private string _flowName;
        private string _flowOperation;

        public Activity()
        {
        }
        public Activity(NodeMethod nodeMethod, string flowName, string operation, ActivityType type, 
                        string transactionId, string Ip, string message, params object[] args)
        {
            _type = type;
            _transactionId = transactionId;
            _ip = Ip;
            _method = nodeMethod;
            _flowName = flowName;
            _flowOperation = operation;
            if (!string.IsNullOrEmpty(message))
            {
                AppendFormat(message, args);
            }
        }


        public List<ActivityEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        /// <summary>
        /// Append the specified message to this activity as a new activity entry.
        /// </summary>
        public void Append(string message)
        {
            if (_entries == null) _entries = new List<ActivityEntry>();
            _entries.Add(new ActivityEntry(message));
        }

        /// <summary>
        /// Append the specified message to this activity as a new activity entry.
        /// </summary>
        public void AppendFormat(string message, params object[] args)
        {
            if (_entries == null) _entries = new List<ActivityEntry>();
            _entries.Add(new ActivityEntry(string.Format(message, args)));
        }

        /// <summary>
        /// Append the specified messages to this activity as new activity entries.
        /// </summary>
        public void Append(IEnumerable<ActivityEntry> messages)
        {
            if (messages != null)
            {
                if (_entries == null) _entries = new List<ActivityEntry>();
                _entries.AddRange(messages);
            }
        }

        /// <summary>
        /// Return a reporting string that represents "Who" this activity is associated with.
        /// </summary>
        [ToStringQualifier(Ignore = true)]
        public string Who
        {
            get
            {
                if (!string.IsNullOrEmpty(_ip))
                {
                    return string.Format("{0} ({1})", ModifiedById, _ip);
                }
                else
                {
                    return ModifiedById;
                }
            }
        }

        /// <summary>
        /// Return a reporting string that represents "What" this activity is associated with.
        /// </summary>
        [ToStringQualifier(Ignore = true)]
        public string What
        {
            get
            {
                string typeString = EnumUtils.ToDescription(_type);
                if (_method != NodeMethod.None)
                {
                    return string.Format("{0} ({1})", typeString, _method.ToString());
                }
                else
                {
                    return typeString;
                }
            }
        }

        /// <summary>
        /// Return a string that represents the data flow that this activity is associated with.
        /// </summary>
        public string FlowName
        {
            get { return _flowName; }
            set { _flowName = value; }
        }

        public string Operation
        {
            get { return _flowOperation; }
            set { _flowOperation = value; }
        }

        /// <summary>
        /// Return a string that represents the ip address (if any) that this activity is associated with.
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        /// <summary>
        /// Return a string that represents the transaction id (if any) that this activity is associated with.
        /// </summary>
        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        /// <summary>
        /// Return the type of this activity
        /// </summary>
        public ActivityType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Return the node method that this activity is associated with.
        /// </summary>
        public NodeMethod Method
        {
            get { return _method; }
            set { _method = value; }
        }
    }
}
