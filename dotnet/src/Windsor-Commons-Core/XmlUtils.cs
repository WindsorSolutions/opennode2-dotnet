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
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace Windsor.Commons.Core
{
    public class XmlValidationUtils
    {
        public IList<string> Validate(string xmlPath)
        {
            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            XmlReaderSettings rs = new XmlReaderSettings();
            rs.ValidationType = ValidationType.Schema;
            rs.IgnoreComments = true;
            rs.IgnoreWhitespace = true;
            rs.IgnoreProcessingInstructions = true;
            rs.XmlResolver = xmlResolver;

            List<string> errors = new List<string>();

            using (XmlTextReader textReader = new XmlTextReader(xmlPath))
            {
                rs.ValidationEventHandler +=
                    delegate(object sender, ValidationEventArgs args)
                    {
                        AppendError(textReader, args, errors);
                    };
                using (XmlReader reader = XmlReader.Create(textReader, rs))
                {
                    while (reader.Read()) { /*Empty loop*/}
                }
            }
            return errors;
        }

        public IList<string> Validate(Stream xmlStream, Stream xsdStream)
        {
            List<string> errors = new List<string>();

            XmlSchema schema = new XmlSchema();
            using (StreamReader schemaReader = new StreamReader(xsdStream))
            {
                schema = XmlSchema.Read(schemaReader,
                    delegate(object sender, ValidationEventArgs args)
                    {
                        AppendError(args, errors);
                    });
            }

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.ValidationType = ValidationType.Schema;
            readerSettings.Schemas.Add(schema);

            using (XmlTextReader textReader = new XmlTextReader(xmlStream))
            {
                readerSettings.ValidationEventHandler +=
                    delegate(object sender, ValidationEventArgs args)
                    {
                        AppendError(textReader, args, errors);
                    };
                using (XmlReader reader = XmlReader.Create(textReader, readerSettings))
                {
                    while (reader.Read()) { /*Empty loop*/}
                }
            }

            return errors;
        }
        public IList<string> Validate(string xmlPath, string xsdPath)
        {
            using (Stream xmlStream = File.OpenRead(xmlPath))
            {
                using (Stream xsdStream = File.OpenRead(xsdPath))
                {
                    string startDirectory = Environment.CurrentDirectory;
                    Environment.CurrentDirectory = Path.GetDirectoryName(xsdPath);

                    try
                    {
                        return Validate(xmlStream, xsdStream);
                    }
                    finally
                    {
                        Environment.CurrentDirectory = startDirectory;
                    }
                }
            }
        }
        public IList<string> Validate(string xmlPath, Stream xsdStream)
        {
            using (Stream stream = File.OpenRead(xmlPath))
            {
                return Validate(stream, xsdStream);
            }
        }
        public IList<string> Validate(byte[] xmlContent, Stream xsdStream)
        {
            using (Stream stream = new MemoryStream(xmlContent, false))
            {
                return Validate(stream, xsdStream);
            }
        }
        private static void AppendError(XmlTextReader reader, ValidationEventArgs args, List<string> errors)
        {
            errors.Add(string.Format("Line: {0} - Position: {1} - {2}", reader.LineNumber,
                                     reader.LinePosition, args.Message));

        }
        private static void AppendError(ValidationEventArgs args, List<string> errors)
        {
            errors.Add(args.Message);
        }

        public static string ParseOutElement(string xmlPath, string elementName, string newRootElementName)
        {
            if (!File.Exists(xmlPath))
            {
                throw new IOException("Xml File ([0]) does not exist: "
                    + xmlPath);
            }

            if (Path.GetExtension(xmlPath.ToLower()) != ".xml")
            {
                throw new ArgumentException("File not XML ([0]): "
                    + xmlPath);
            }

            string newFilePath = xmlPath.ToLower().Replace(".xml", "_new.xml");

            using (XmlWriter writer = XmlWriter.Create(newFilePath))
            {

                writer.WriteStartElement(newRootElementName);

                XPathDocument doc = new XPathDocument(xmlPath);
                XPathNavigator nav = doc.CreateNavigator();

                XPathExpression expr = nav.Compile("//*");
                XPathNodeIterator iterator = nav.Select(expr);

                while (iterator.MoveNext())
                {

                    if (iterator.Current.Name == elementName)
                    {
                        iterator.Current.WriteSubtree(writer);
                    }


                }

                writer.WriteEndElement();

            }



            return newFilePath;

        }


    }
}
