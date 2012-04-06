using System;
using System.Text;
using System.Xml;
using System.IO;
using Common.Logging;

namespace Windsor.Node2008.WNOSPlugin.TRI4
{

    public interface IXmlUtility
    {
        string RemoveXmlNamespaceReferances(string file);
    }

    public class XmlUtility : IXmlUtility
    {

        private static readonly ILog LOG = LogManager.GetLogger(typeof(XmlUtility));

        /// <summary>
        /// RemoveXmlNamespaceReferances
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string RemoveXmlNamespaceReferances(string file)
        {

            if (!File.Exists(file))
            {
                throw new FileNotFoundException(file);
            }

            LOG.Info("Cleaning: " + file);



            string newFile = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".clean");

            LOG.Info("Traget File: " + newFile);

            try
            {
                using (TextWriter wr = new StreamWriter(newFile))
                {
                    using (XmlTextReader reader = new XmlTextReader(file))
                    {
                        using (XmlNoNamespaceWriter writer = new XmlNoNamespaceWriter(wr))
                        {
                            writer.WriteNode(reader, true);
                            writer.Flush();
                        }
                    }
                }
            }
            catch (Exception)
            {
                SafeDeleteFile(newFile);
                throw;
            }

            LOG.Info("File Cleaned: " + newFile);

            return newFile;

        }

        private static void SafeDeleteFile(string filePath)
        {
            try { File.Delete(filePath); }
            catch (Exception) { }
        }
    }


    public class XmlNoNamespaceWriter : XmlTextWriter
    {
        bool skipAttribute = false;

        public XmlNoNamespaceWriter(TextWriter writer)
            : base(writer)
        {
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(null, localName, null);
        }


        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            //If the prefix or localname are "xmlns", don't write it. 
            if (prefix.CompareTo("xmlns") == 0 || 
				localName.CompareTo("xmlns") == 0 || 
				prefix.CompareTo("schemaLocation") == 0 || 
				localName.CompareTo("schemaLocation") == 0 ||
                localName.CompareTo("Operation") == 0 ||
                localName.CompareTo("FacilitySiteIdentifierContext") == 0)
            {
                skipAttribute = true;
            }
            else
            {
                base.WriteStartAttribute(null, localName, null);
            }
        }

        public override void WriteString(string text)
        {
            //If we are writing an attribute, the text for the xmlns
            //or xmlns:prefix declaration would occur here.  Skip
            //it if this is the case.
            if (!skipAttribute)
            {
                base.WriteString(text);
            }
        }

        public override void WriteEndAttribute()
        {
            //If we skipped the WriteStartAttribute call, we have to
            //skip the WriteEndAttribute call as well or else the XmlWriter
            //will have an invalid state.
            if (!skipAttribute)
            {
                base.WriteEndAttribute();
            }
            //reset the boolean for the next attribute.
            skipAttribute = false;
        }


        public override void WriteQualifiedName(string localName, string ns)
        {
            //Always write the qualified name using only the
            //localname.
            base.WriteQualifiedName(localName, null);
        }
    }
}
