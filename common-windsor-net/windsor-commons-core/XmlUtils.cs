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
        private bool _groupErrors;
        private LinkedDictionary<string, int> _groupedErrors;

        public XmlValidationUtils()
        {
        }
        public XmlValidationUtils(bool groupErrors)
        {
            _groupErrors = groupErrors;
        }

        /// <summary>
        /// Called for each error found in the xml file
        /// </summary>
        public delegate void ValidationErrorDelegate(string validationErrorText);

        public IList<string> Validate(string xmlPath)
        {
            List<string> errors = null;
            Validate(xmlPath, delegate(string error)
            {
                CollectionUtils.Add(error, ref errors);
            });
            return errors;
        }

        public void Validate(string xmlPath, ValidationErrorDelegate validationErrorDelegate)
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
            _groupedErrors = null;

            using (XmlTextReader textReader = new XmlTextReader(xmlPath))
            {
                rs.ValidationEventHandler +=
                    delegate(object sender, ValidationEventArgs args)
                    {
                        AppendError(textReader, args, validationErrorDelegate);
                    };
                using (XmlReader reader = XmlReader.Create(textReader, rs))
                {
                    while (reader.Read()) { /*Empty loop*/}
                }
            }
            OutputGroupedErrors(validationErrorDelegate);
        }

        /// <summary>
        /// Return true if the file validates, otherwise return false and output validation
        /// errors to errorsFilePath.
        /// </summary>
        public bool Validate(string xmlPath, string xsdPath, string errorsFilePath)
        {
            StreamWriter writer = null;
            try
            {
                Validate(xmlPath, xsdPath, delegate(string error)
                {
                    if (writer == null)
                    {
                        writer = FileUtils.CreateFileAndTextWriter(errorsFilePath);
                    }
                    writer.WriteLine(error);
                    if (GroupErrors)
                    {
                        writer.WriteLine();
                    }
                });
                return (writer == null);
            }
            catch (Exception)
            {
                DisposableBase.SafeDispose(writer);
                FileUtils.SafeDeleteFile(errorsFilePath);
                throw;
            }
            finally 
            {
                DisposableBase.SafeDispose(writer);
            }
        }
        public IList<string> Validate(Stream xmlStream, Stream xsdStream)
        {
            List<string> errors = null;
            Validate(xmlStream, xsdStream, delegate(string error)
            {
                CollectionUtils.Add(error, ref errors);
            });
            return errors;
        }

        public void Validate(Stream xmlStream, Stream xsdStream, ValidationErrorDelegate validationErrorDelegate)
        {
            _groupedErrors = null;
            XmlSchema schema = new XmlSchema();
            using (StreamReader schemaReader = new StreamReader(xsdStream))
            {
                schema = XmlSchema.Read(schemaReader,
                    delegate(object sender, ValidationEventArgs args)
                    {
                        AppendError(args, validationErrorDelegate);
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
                        AppendError(textReader, args, validationErrorDelegate);
                    };
                using (XmlReader reader = XmlReader.Create(textReader, readerSettings))
                {
                    while (reader.Read()) { /*Empty loop*/}
                }
            }
            OutputGroupedErrors(validationErrorDelegate);
        }
        public IList<string> Validate(string xmlPath, string xsdPath)
        {
            List<string> errors = null;
            Validate(xmlPath, xsdPath, delegate(string error)
            {
                CollectionUtils.Add(error, ref errors);
            });
            return errors;
        }
        public void Validate(string xmlPath, string xsdPath,
                             ValidationErrorDelegate validationErrorDelegate)
        {
            using (Stream xmlStream = File.OpenRead(xmlPath))
            {
                using (Stream xsdStream = File.OpenRead(xsdPath))
                {
                    string startDirectory = Environment.CurrentDirectory;
                    Environment.CurrentDirectory = Path.GetDirectoryName(xsdPath);

                    try
                    {
                        Validate(xmlStream, xsdStream, validationErrorDelegate);
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
            List<string> errors = null;
            Validate(xmlPath, xsdStream, delegate(string error)
            {
                CollectionUtils.Add(error, ref errors);
            });
            return errors;
        }
        public void Validate(string xmlPath, Stream xsdStream,
                             ValidationErrorDelegate validationErrorDelegate)
        {
            using (Stream stream = File.OpenRead(xmlPath))
            {
                Validate(stream, xsdStream, validationErrorDelegate);
            }
        }
        public IList<string> Validate(byte[] xmlContent, Stream xsdStream)
        {
            List<string> errors = null;
            Validate(xmlContent, xsdStream, delegate(string error)
            {
                CollectionUtils.Add(error, ref errors);
            });
            return errors;
        }
        public void Validate(byte[] xmlContent, Stream xsdStream, 
                             ValidationErrorDelegate validationErrorDelegate)
        {
            using (Stream stream = new MemoryStream(xmlContent, false))
            {
                Validate(stream, xsdStream, validationErrorDelegate);
            }
        }
        private void AppendError(XmlTextReader reader, ValidationEventArgs args, 
                                 ValidationErrorDelegate validationErrorDelegate)
        {
            if (GroupErrors)
            {
                AppendGroupedError(args.Message);
            }
            else
            {
                validationErrorDelegate(string.Format("Line: {0} - Position: {1} - {2}", reader.LineNumber,
                                                      reader.LinePosition, args.Message));
            }
        }
        private void AppendError(ValidationEventArgs args, ValidationErrorDelegate validationErrorDelegate)
        {
            if (GroupErrors)
            {
                AppendGroupedError(args.Message);
            }
            else
            {
                validationErrorDelegate(args.Message);
            }
        }
        private void AppendGroupedError(string message)
        {
            if (_groupedErrors == null)
            {
                _groupedErrors = new LinkedDictionary<string, int>();
            }
            if (_groupedErrors.ContainsKey(message))
            {
                int currentCount = _groupedErrors[message];
                _groupedErrors[message] = currentCount + 1;
            }
            else
            {
                _groupedErrors[message] = 1;
            }
        }
        private void OutputGroupedErrors(ValidationErrorDelegate validationErrorDelegate)
        {
            if (GroupErrors)
            {
                if (_groupedErrors != null)
                {
                    foreach (KeyValuePair<string, int> pair in _groupedErrors)
                    {
                        string message = string.Format("{0} {1}{2}{3}", pair.Value.ToString(), (pair.Value == 1) ? "occurrences:" : "occurrences:",
                                                       Environment.NewLine, pair.Key);
                        validationErrorDelegate(message);
                    }
                }
            }
        }

        public bool GroupErrors
        {
            get { return _groupErrors; }
            set { _groupErrors = value; }
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
