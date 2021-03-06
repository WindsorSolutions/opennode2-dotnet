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

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class DataFlow : AuditableIdentity
    {
        private string _infoUrl;
        private string _contactUserId;
        private string _name;
        private string _description;
        private IList<DataService> _services;
        private bool _isProtected;

        public DataFlow()
        {
            _services = new List<DataService>();
        }
        public DataFlow(string name, string infoUrl, string contactUserId, string description,
                        bool isProtected)
        {
            _services = new List<DataService>();
            FlowName = name;
            InfoUrl = infoUrl;
            ContactUserId = contactUserId;
            Description = description;
            IsProtected = isProtected;
        }

        public bool IsProtected
        {
            get { return _isProtected; }
            set { _isProtected = value; }
        }

        public string ContactUserId
        {
            get { return _contactUserId; }
            set { _contactUserId = value; }
        }

        public string InfoUrl
        {
            get { return _infoUrl; }
            set { _infoUrl = value; }
        }

        
        public string FlowName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public IList<DataService> Services
        {
            get { return _services; }
            set { _services = value; }
        }
    }
}
