using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using System.Threading;

namespace Windsor.Commons.Core
{
    public enum XmlValidationHelperStatus
    {
        Undefined = 0,
        ResolvingSchema = 1,    // Currently resolving/downloading xml schema
        ValidationError = 2,    // Found a validation error, XMLValidationHelperInfo.Error contains error
        PercentProgress = 3,    // Progress percentage, XMLValidationHelperInfo.ProgressPercentage contains progress
    }

    public class XmlValidationHelperProgressInfo
    {
        private XmlValidationHelperStatus _status;
        private XmlSchemaException _error;
        private int _progressPercentage;

        public XmlValidationHelperProgressInfo(XmlValidationHelperStatus status)
        {
            _status = status;
        }
        public XmlValidationHelperProgressInfo(XmlSchemaException error)
        {
            _status = XmlValidationHelperStatus.ValidationError;
            _error = error;
        }
        public XmlValidationHelperProgressInfo(int progressPercentage)
        {
            _status = XmlValidationHelperStatus.PercentProgress;
            _progressPercentage = progressPercentage;
        }
        public XmlValidationHelperStatus Status
        {
            get { return _status; }
        }
        public XmlSchemaException Error
        {
            get { return _error; }
        }
        /// <summary>
        /// Returns value 0..100
        /// </summary>
        public int ProgressPercentage
        {
            get { return _progressPercentage; }
        }

    }

    public delegate bool XmlValidationHelperProgressHandler(XmlValidationHelperProgressInfo info);

    public class XmlValidationHelper
    {
        private List<string> _errors;

        public event XmlValidationHelperProgressHandler ProgressHandlerEvent;

        public List<string> Validate(string xmlPath)
        {
            return Validate(xmlPath, null);
        }
        public List<string> Validate(string xmlPath, string schemaFilePath)
        {
            try
            {
                string schemaUrl;
                if (schemaFilePath == null)
                {
                    schemaUrl = GetXmlSchemaPath(xmlPath);
                }
                else
                {
                    string checkFileScheme = Uri.UriSchemeFile + "://";
                    if (!schemaFilePath.StartsWith(checkFileScheme, StringComparison.InvariantCultureIgnoreCase))
                    {
                        schemaFilePath = checkFileScheme + schemaFilePath;
                    }
                    schemaUrl = schemaFilePath;
                }

                using (FileStream stream = File.OpenRead(xmlPath))
                {
                    using (XmlTextReader textReader = new XmlTextReader(stream))
                    {
                        long streamLength = stream.Length;
                        if (ProgressHandlerEvent == null)
                        {
                            _errors = new List<string>();
                        }

                        XmlUrlResolver xmlResolver = new XmlUrlResolver();
                        xmlResolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

                        XmlReaderSettings rs = new XmlReaderSettings();
                        rs.ValidationType = ValidationType.Schema;
                        //rs.IgnoreComments = true;
                        //rs.IgnoreWhitespace = true;
                        //rs.IgnoreProcessingInstructions = true;
                        rs.XmlResolver = xmlResolver;
                        if (ProgressHandlerEvent != null)
                        {
                            if ( !ProgressHandlerEvent(new XmlValidationHelperProgressInfo(XmlValidationHelperStatus.ResolvingSchema)) )
                            {
                                throw new OperationCanceledException();
                            }
                        }
                        rs.Schemas.Add(null, schemaUrl);

                        rs.ValidationEventHandler +=
                            new ValidationEventHandler(ReaderValidationEventHandler);

                        // 9- Create a new instance of XmlReader object
                        XmlReader reader = XmlReader.Create(textReader, rs);

                        // 10- Read XML content in a loop
                        int lastPercentage = -1;
                        while (reader.Read())
                        {
                            int newPercentage = (int) ((stream.Position * 100.0) / streamLength);
                            if (newPercentage > lastPercentage)
                            {
                                if (ProgressHandlerEvent != null)
                                {
                                    if (!ProgressHandlerEvent(new XmlValidationHelperProgressInfo(newPercentage)))
                                    {
                                        throw new OperationCanceledException();
                                    }
                                }
                                lastPercentage = newPercentage;
                            }
                        }
                    }
                }

            }//try
            catch (Exception)
            {
                throw;
            }//catch

            return _errors;
        }
        private string GetXmlSchemaPath(string xmlFilePath)
        {
            string schemaPath = null;
            using (XmlTextReader reader = new XmlTextReader(xmlFilePath))
            {
                bool finished = false;
                while (!finished && reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.XmlDeclaration:
                            break;
                        case XmlNodeType.Element:
                            schemaPath = reader.GetAttribute("xmlns");
                            if ( string.IsNullOrEmpty(schemaPath)) {
                                schemaPath = reader.GetAttribute("xsi:schemaLocation");
                                int index = schemaPath.IndexOf(' ');
                                if (index >= 0)
                                {
                                    schemaPath = schemaPath.Substring(0, index);
                                }
                            }
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (string.IsNullOrEmpty(schemaPath))
            {
                throw new XmlException("Could not locate the schema url in the xml file");
            }
            if (schemaPath[schemaPath.Length - 1] != '/')
            {
                schemaPath = schemaPath + '/';
            }
            return schemaPath;
        }

        private void ReaderValidationEventHandler(object sender,
            ValidationEventArgs args)
        {
            if (ProgressHandlerEvent != null)
            {
                if (ProgressHandlerEvent != null)
                {
                    if (!ProgressHandlerEvent(new XmlValidationHelperProgressInfo(args.Exception)))
                    {
                        throw new OperationCanceledException();
                    }
                }
            }
            if (_errors != null)
            {
                _errors.Add(string.Format(
                    "Line {0}, Pos {1}: {2}",
                    args.Exception.LineNumber,
                    args.Exception.LinePosition,
                    args.Message));
            }
        }

    }
}
