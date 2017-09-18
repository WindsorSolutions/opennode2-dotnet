using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Windsor.Node2008.WNOSProviders
{

    public interface IHeaderDocument2Helper
    {
        void AddNotification(string notification);
        void AddNotifications(string commaSeparatedNotifications);
        void AddNotifications(System.Collections.Generic.IEnumerable<string> notifications);
        void AddPayload(string id, string operation, System.Xml.XmlElement payloadContent);
        void AddPayload(string operation, System.Xml.XmlElement payloadContent);
        void AddPropery(string key, string value);
        string GetHeaderPropery(string key);
        void Configure(string authorName,
            string organizationName,
            string documentTitle,
            string dataFlowName,
            string dataServiceName,
            string senderContact,
            string applicationUserIdentifier,
            string keywords);
        void Configure(string authorName, 
            string organizationName, 
            string documentTitle, 
            string dataFlowName, 
            string dataServiceName, 
            string senderContact, 
            string applicationUserIdentifier);
        void Configure(string authorName,
            string organizationName,
            string documentTitle,
            string dataFlowName,
            string dataServiceName,
            string senderContact);
        void Serialize(string filePath);
        byte[] Serialize();
        void Load(string serializeFilePath);
        void Load(byte[] content);
        bool TryLoad(string serializeFilePath);
        bool TryLoad(byte[] content);
        XmlElement GetPayload(string operation);
        XmlElement GetFirstPayload(out string operation);
        XmlSerializerNamespaces SerializerNamespaces { get; set; }
    }
}
