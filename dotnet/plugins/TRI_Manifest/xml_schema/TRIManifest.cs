using System;
using System.Data;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace Windsor.Node.Flow.TRI_Manifest
{
	[Serializable]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.windsorsolutions.biz/xsd/TRI_v4.0/SubmittedDocuments.xsd")]
	[System.Xml.Serialization.XmlRootAttribute("SubmittedDocumentList", Namespace="http://www.windsorsolutions.biz/xsd/TRI_v4.0/SubmittedDocuments.xsd", IsNullable=false)]
	public class SubmittedDocumentList
	{
        public SubmittedDocument[] SubmittedDocuments;
	}

	[Serializable]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.windsorsolutions.biz/xsd/TRI_v4.0/SubmittedDocuments.xsd")]
	[System.Xml.Serialization.XmlRootAttribute("SubmittedDocument", Namespace="http://www.windsorsolutions.biz/xsd/TRI_v4.0/SubmittedDocuments.xsd", IsNullable=false)]
	public class SubmittedDocument
	{
		public string TransactionID;
		
        public DateTime ReceivedDate;
	}
}
