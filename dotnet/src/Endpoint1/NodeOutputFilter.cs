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
using Microsoft.Web.Services;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using Common.Logging;
using System.Reflection;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.Endpoint1
{
	public class NodeOutputFilter: SoapOutputFilter
	{


        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

		public override void ProcessMessage(SoapEnvelope envelope)
		{
			SoapContext reqContext = envelope.Context;

			if (reqContext !=null) 
			{
				//now we need to extract href hash from the context 
                Dictionary<string, string> table = reqContext["hrefs"] as Dictionary<string, string>;

				if (table != null)
				{
					XmlElement element = envelope.DocumentElement;

					XmlNodeList list = 
						element.GetElementsByTagName("NodeDocument", 
                            "http://www.ExchangeNetwork.net/schema/v1.0/node.xsd");

					foreach(XmlNode node in list)
					{
						XmlElement nameElement= node["name"];
                        LOG.Debug("NameElement: " + nameElement);

						//now lets check in the table to get the href for that name
                        String id = table[nameElement.InnerText];
                        LOG.Debug("Id: " + id);

						//lets create the content tag
						XmlNode newNode = envelope.CreateNode(XmlNodeType.Element, 
                            "content", "http://xml.apache.org/xml-soap");

						XmlAttribute attrib = envelope.CreateAttribute("href");
						attrib.Value = id;
                        LOG.Debug("Attrib: " + attrib);

						newNode.Attributes.Append(attrib);
						node.AppendChild(newNode);

					}
				}
			}
		}	
	}
}
