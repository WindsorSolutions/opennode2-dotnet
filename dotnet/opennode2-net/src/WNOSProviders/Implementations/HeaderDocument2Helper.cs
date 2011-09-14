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
using System.Xml.Serialization;
using System.Text;

using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSProviders.Implementation.Doc2;

namespace Windsor.Node2008.WNOSProviders.Implementation
{
    /// <summary>
    /// This takes care of the writting part of Header v.2 only
    /// </summary>
    public class HeaderDocument2Helper : IHeaderDocument2Helper
    {
        private ExchangeNetworkDocumentType _hd = new ExchangeNetworkDocumentType();
        private readonly List<string> _senderAddresses = new List<string>();
        private readonly List<NameValuePair> _properties = new List<NameValuePair>();
        private readonly List<DocumentPayloadType> _payloads = new List<DocumentPayloadType>();
        private ISerializationHelper _serializationHelper;
        private readonly IIdProvider _idProvider = new IdProvider();

        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _serializationHelper);
        }

        public void Configure(
            string authorName,
            string organizationName,
            string documentTitle,
            string dataFlowName,
            string dataServiceName,
            string senderContact)
        {
            Configure(authorName,
             organizationName,
             documentTitle,
             dataFlowName,
             dataServiceName,
             senderContact,
             null);
        }

        public void Configure(
            string authorName,
            string organizationName,
            string documentTitle,
            string dataFlowName,
            string dataServiceName,
            string senderContact,
            string applicationUserIdentifier)
        {
            Configure(authorName,
                         organizationName,
                         documentTitle,
                         dataFlowName,
                         dataServiceName,
                         senderContact,
                         null, null);
        }

        public void Configure(
            string authorName,
            string organizationName,
            string documentTitle,
            string dataFlowName,
            string dataServiceName,
            string senderContact,
            string applicationUserIdentifier,
            string keywords)
        {
            _hd.id = _idProvider.Get();

            _hd.Header = new DocumentHeaderType();
            _hd.Header.AuthorName = authorName;
            _hd.Header.OrganizationName = organizationName;
            _hd.Header.DocumentTitle = documentTitle;
            _hd.Header.CreationDateTime = DateTime.Now;
            _hd.Header.DataFlowName = dataFlowName;
            _hd.Header.DataServiceName = dataServiceName;
            _hd.Header.SenderContact = senderContact;
            _hd.Header.ApplicationUserIdentifier = applicationUserIdentifier;
            _hd.Header.Keywords = keywords;
        }


        #region Notifications
        public void AddNotifications(string commaSeparatedNotifications)
        {
            if (!string.IsNullOrEmpty(commaSeparatedNotifications))
            {
                AddNotifications(commaSeparatedNotifications.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }
        public void AddNotifications(IEnumerable<string> notifications)
        {
            if (notifications != null)
            {
                foreach (string notification in notifications)
                {
                    AddNotification(notification);
                }
            }
        }
        public void AddNotification(string notification)
        {
            notification = notification.Trim();
            if (!string.IsNullOrEmpty(notification))
            {
                _senderAddresses.Add(notification);
            }
        }
        #endregion

        #region Payload
        public void AddPayload(string operation, XmlElement payloadContent)
        {
            AddPayload(_idProvider.Get(), operation, payloadContent);
        }

        public void AddPayload(string id, string operation, XmlElement payloadContent)
        {
            DocumentPayloadType p = new DocumentPayloadType();
            p.Any = payloadContent;
            p.operation = operation;
            p.id = id;
            _payloads.Add(p);
        }
        #endregion

        public void AddPropery(string key, string value)
        {
            NameValuePair pair = new NameValuePair();
            pair.PropertyName = key;
            pair.PropertyValue = value;
            _properties.Add(pair);
        }
        public string GetHeaderPropery(string key)
        {
            string value = null;
            CollectionUtils.ForEachBreak(_hd.Header.Property, delegate(NameValuePair pair)
            {
                if (string.Equals(key, pair.PropertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    value = (pair.PropertyValue == null) ? null : pair.PropertyValue.ToString();
                    return false;
                }
                return true;
            });
            return value;
        }

        public void Serialize(string filePath)
        {
            _hd.Header.SenderAddress = _senderAddresses.ToArray();
            _hd.Header.Property = _properties.ToArray();
            _hd.Payload = _payloads.ToArray();

            _serializationHelper.Serialize(_hd, filePath);
        }

        public byte[] Serialize()
        {
            _hd.Header.SenderAddress = _senderAddresses.ToArray();
            _hd.Header.Property = _properties.ToArray();
            _hd.Payload = _payloads.ToArray();

            return _serializationHelper.Serialize(_hd);
        }

        public ISerializationHelper SerializationHelper
        {
            get { return _serializationHelper; }
            set { _serializationHelper = value; }
        }
        public XmlSerializerNamespaces SerializerNamespaces
        {
            get { return _serializationHelper.SerializerNamespaces; }
            set { _serializationHelper.SerializerNamespaces = value; }
        }

        public bool TryLoad(string serializeFilePath)
        {
            try
            {
                _hd = _serializationHelper.Deserialize<ExchangeNetworkDocumentType>(serializeFilePath);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Load(string serializeFilePath)
        {
            _hd = _serializationHelper.Deserialize<ExchangeNetworkDocumentType>(serializeFilePath);
        }
        public bool TryLoad(byte[] content)
        {
            try
            {
                _hd = _serializationHelper.Deserialize<ExchangeNetworkDocumentType>(content);
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        public void Load(byte[] content)
        {
            _hd = _serializationHelper.Deserialize<ExchangeNetworkDocumentType>(content);
        }
        public XmlElement GetPayload(string operation)
        {
            if (!CollectionUtils.IsNullOrEmpty(_hd.Payload))
            {
                foreach (DocumentPayloadType payload in _hd.Payload)
                {
                    if (payload.operation == operation)
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
                operation = _hd.Payload[0].operation;
                return _hd.Payload[0].Any;
            }
            operation = null;
            return null;
        }
    }
}
