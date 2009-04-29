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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Text;


namespace Windsor.Node.Flow.RCRA.CS
{
	/// <summary>
	/// Summary description for Loader.
	/// </summary>
	public class Loader
	{

		#region Local Members
		private ExchangeNetworkDocument m_exchangeNetworkDocument;
		private ArrayList m_notifications;
		private ArrayList m_properties;
		private ArrayList m_payloads;
		#endregion

		#region Public Properties
		public string ContactInfo 
		{
			set { m_exchangeNetworkDocument.Header.ContactInfo = value; }
		}
		public string DataService 
		{
			set { m_exchangeNetworkDocument.Header.DataService = value; }
		}
		public SensitivityType Sensitivity 
		{
			set { m_exchangeNetworkDocument.Header.Sensitivity = value.ToString(); }
		}
		#endregion



		/// <summary>
		/// Loader - Must provide the required properties
		/// </summary>
		/// <param name="Organization"></param>
		/// <param name="Author"></param>
		/// <param name="Title"></param>
		public Loader(string Organization, string Author, string Title)
		{
			m_exchangeNetworkDocument = new ExchangeNetworkDocument();
			m_exchangeNetworkDocument.Header = new DocHeader();

			m_exchangeNetworkDocument.Header.Author = Author;
			m_exchangeNetworkDocument.Header.Organization = Organization;
			m_exchangeNetworkDocument.Header.Title = Title;
			m_exchangeNetworkDocument.Header.CreationTime = DateTime.Now;

			m_exchangeNetworkDocument.Id = Guid.NewGuid().ToString();

		}

		#region Public Methods


		/// <summary>
		/// Serialize
		/// </summary>
		/// <param name="path"></param>
		public void Serialize(string path)
		{

			m_exchangeNetworkDocument.Payload = (Payload[])m_payloads.ToArray(typeof(Payload));
			if ((m_properties != null) && (m_properties.Count > 0))
			{
				m_exchangeNetworkDocument.Header.Property = (NameValuePair[])m_properties.ToArray(typeof(NameValuePair));
			}
			if ((m_notifications != null) && (m_notifications.Count > 0))
			{
				m_exchangeNetworkDocument.Header.Notification = (string[])m_notifications.ToArray(typeof(string));
			}

			XmlSerializer ser = new XmlSerializer(typeof(ExchangeNetworkDocument));
			TextWriter tw = new StreamWriter(path);
			ser.Serialize(tw, m_exchangeNetworkDocument);
			tw.Close();
		}

		/// <summary>
		/// GetXmlString
		/// </summary>
		/// <returns>XML String</returns>
		public string GetXmlString()
		{
			m_exchangeNetworkDocument.Payload = (Payload[])m_payloads.ToArray(typeof(Payload));
			if ((m_properties != null) && (m_properties.Count > 0))
			{
				m_exchangeNetworkDocument.Header.Property = (NameValuePair[])m_properties.ToArray(typeof(NameValuePair));
			}
			if ((m_notifications != null) && (m_notifications.Count > 0))
			{
				m_exchangeNetworkDocument.Header.Notification = (string[])m_notifications.ToArray(typeof(string));
			}

			MemoryStream ms = null;
			XmlTextWriter tw = null;
			StreamReader sr = null;

			try 
			{

				ms = new MemoryStream();
				tw = new XmlTextWriter(ms,Encoding.UTF8);
				tw.Formatting = Formatting.None;
				XmlSerializer saveXML = new XmlSerializer(typeof(ExchangeNetworkDocument));
				saveXML.Serialize(tw,m_exchangeNetworkDocument);
				ms.Seek(0,System.IO.SeekOrigin.Begin);

				//Convert to string
				sr = new StreamReader(ms);

				//Return string w/o validation ValidateXMLString()
				return sr.ReadToEnd();

			}
			catch 
			{
                
			}
			finally
			{
				if (tw != null) 
				{
					tw.Close();
				}
				if (sr != null)
				{
					sr.Close(); 
				}
			}

			return string.Empty;

		}

		/// <summary>
		/// AddPayload
		/// </summary>
		/// <param name="operationType"></param>
		/// <param name="element"></param>
		public void AddPayload(OperationType operationType, string xmlString)
		{
			if (m_payloads == null) 
			{
				m_payloads = new ArrayList();
			}

			Payload payload = new Payload();
			payload.Operation = operationType.ToString();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xmlString);
			XmlElement root = doc.DocumentElement;
			payload.Any = root;

			m_payloads.Add(payload);
		}

		public void AddPayloadFromFile(OperationType operationType, string xmlPath)
		{
			if (m_payloads == null) 
			{
				m_payloads = new ArrayList();
			}

			Payload payload = new Payload();
			payload.Operation = operationType.ToString();

			XmlDocument doc = new XmlDocument();
			doc.Load(xmlPath);
			XmlElement root = doc.DocumentElement;
			payload.Any = root;

			m_payloads.Add(payload);
		}

		/// <summary>
		/// AddProperty
		/// </summary>
		/// <param name="property"></param>
		public void AddProperty(string propertyName, string propertyValue)
		{
			if (m_properties == null) 
			{
				m_properties = new ArrayList();
			}
			NameValuePair valPair = new NameValuePair();
			valPair.name = propertyName;
			valPair.value = propertyValue;

			m_properties.Add(valPair);
		}

		/// <summary>
		/// AddNotification
		/// </summary>
		/// <param name="notification"></param>
		public void AddNotification(string notification)
		{
			if (m_notifications == null) 
			{
				m_notifications = new ArrayList();
			}
			m_notifications.Add(notification);
		}

		#endregion


		#region Enums

		public enum OperationType 
		{
			Add, Delete, Refresh, Unspecified, Update
		}

		public enum SensitivityType 
		{
			Confidential, Secret, TopSecret, Unclassified
		}

		#endregion

	}
}
