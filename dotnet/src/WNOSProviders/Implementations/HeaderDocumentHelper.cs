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
using System.Xml;
using System.Text;

using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSProviders.Implementation
{
    public class HeaderDocumentHelper : IHeaderDocumentHelper
    {

        private Docs.ExchangeNetworkDocument _hd = new Docs.ExchangeNetworkDocument();
        private readonly List<string> _notifs = new List<string>();
        private readonly List<Docs.NameValuePair> _properties = new List<Docs.NameValuePair>();
        private readonly List<Docs.Payload> _payloads = new List<Docs.Payload>();
        private ISerializationHelper _serializationHelper;
        private readonly IIdProvider _idProvider = new IdProvider();

        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
        }

        public void Configure(
            string author,
            string org,
            string title,
            string dataService,
            string contactInfo,
            string sensitivity)
        {
            _hd.Id = _idProvider.Get();
            _hd.Header = new Docs.DocHeader();
            _hd.Header.Author = author;
            _hd.Header.ContactInfo = contactInfo;
            _hd.Header.CreationTime = DateTime.Now;
            _hd.Header.DataService = dataService;
            _hd.Header.Organization = org;
            _hd.Header.Sensitivity = sensitivity;
            _hd.Header.Title = title;
        }



        public void AddNotification(string notification)
        {
            _notifs.Add(notification);
        }

        public void AddPayload(string operation, XmlElement payloadContent)
        {
            Docs.Payload p = new Docs.Payload();
            p.Any = payloadContent;
            p.Operation = operation;
            _payloads.Add(p);
        }

        public void AddPropery(string key, string value)
        {
            Docs.NameValuePair pair = new Docs.NameValuePair();
            pair.name = key;
            pair.value = value;
            _properties.Add(pair);
        }

        public void Serialize(string filePath)
        {
            _hd.Header.Notification = _notifs.ToArray();
            _hd.Header.Property = _properties.ToArray();
            _hd.Payload = _payloads.ToArray();

            _serializationHelper.Serialize(_hd, filePath);
        }

        public byte[] Serialize()
        {
            _hd.Header.Notification = _notifs.ToArray();
            _hd.Header.Property = _properties.ToArray();
            _hd.Payload = _payloads.ToArray();

            return _serializationHelper.Serialize(_hd);
        }

        public bool TryLoad(string serializeFilePath)
        {
            try
            {
                _hd = _serializationHelper.Deserialize<Docs.ExchangeNetworkDocument>(serializeFilePath);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Load(string serializeFilePath)
        {
            _hd = _serializationHelper.Deserialize<Docs.ExchangeNetworkDocument>(serializeFilePath);
        }

        public bool TryLoad(byte[] content)
        {
            try
            {
                _hd = _serializationHelper.Deserialize<Docs.ExchangeNetworkDocument>(content);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Load(byte[] content)
        {
            _hd = _serializationHelper.Deserialize<Docs.ExchangeNetworkDocument>(content);
        }
        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
        public string Author
        {
            get { return _hd.Header.Author; }
            set { _hd.Header.Author = value; }
        }
        public string ContactInfo
        {
            get { return _hd.Header.ContactInfo; }
            set { _hd.Header.ContactInfo = value; }
        }
        public DateTime CreationTime
        {
            get { return _hd.Header.CreationTime; }
            set { _hd.Header.CreationTime = value; }
        }
        public string DataService
        {
            get { return _hd.Header.DataService; }
            set { _hd.Header.DataService = value; }
        }
        public string Organization
        {
            get { return _hd.Header.Organization; }
            set { _hd.Header.Organization = value; }
        }
        public string Sensitivity
        {
            get { return _hd.Header.Sensitivity; }
            set { _hd.Header.Sensitivity = value; }
        }
        public string Title
        {
            get { return _hd.Header.Title; }
            set { _hd.Header.Title = value; }
        }
        public string GetProperty(string name)
        {
            if (_hd.Header.Property != null)
            {
                foreach (Docs.NameValuePair pair in _hd.Header.Property)
                {
                    if (pair.name == name)
                    {
                        return pair.value;
                    }
                }
            }
            return null;
        }
        public XmlElement GetPayload(string operation)
        {
            if (!CollectionUtils.IsNullOrEmpty(_hd.Payload))
            {
                foreach (Docs.Payload payload in _hd.Payload)
                {
                    if (payload.Operation == operation)
                    {
                        return payload.Any;
                    }
                }
            }
            return null;
        }
        public XmlElement GetFirstPayload(out string operation)
        {
            if (!CollectionUtils.IsNullOrEmpty(_hd.Payload))
            {
                operation = _hd.Payload[0].Operation;
                return _hd.Payload[0].Any;
            }
            operation = null;
            return null;
        }
    }
}
