using System;
using System.Xml;
using System.Collections.Generic;

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
    }
}
