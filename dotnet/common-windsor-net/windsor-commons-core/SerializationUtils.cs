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
using System.Runtime.Serialization.Formatters.Binary;

namespace Windsor.Commons.Core
{
    [Serializable]
    public class SerializationUtils
    {
        #region ISerializationHelper Members

        private readonly XmlSerializerNamespaces _unqualifiedNamespace;
        private readonly XmlWriterSettings _omitXmlDeclarationWriterSettings;
        private XmlSerializerNamespaces _serializerNamespaces;

        public SerializationUtils()
        {
            _unqualifiedNamespace = new XmlSerializerNamespaces();
            _unqualifiedNamespace.Add("", "");
            _omitXmlDeclarationWriterSettings = new XmlWriterSettings();
            _omitXmlDeclarationWriterSettings.OmitXmlDeclaration = true;

            ServiceStack.Text.JsConfig.EmitCamelCaseNames = true;
            ServiceStack.Text.JsConfig.DateHandler = ServiceStack.Text.JsonDateHandler.ISO8601;
            ServiceStack.Text.JsConfig.ThrowOnDeserializationError = true;
            ServiceStack.Text.JsConfig.IncludeNullValues = true;
            ServiceStack.Text.JsConfig.IncludePublicFields = false;
            ServiceStack.Text.JsConfig.ExcludeTypeInfo = true;
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(string xml, XmlElementEventHandler unknownElementHandler)
        {
            return Deserialize<T>(StringUtils.UTF8.GetBytes(xml));
        }
        public T FromXml<T>(string xml)
        {
            return Deserialize<T>(xml, null);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bytes)
        {
            return Deserialize<T>(bytes, null);
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bytes, XmlElementEventHandler unknownElementHandler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            if (unknownElementHandler != null)
            {
                serializer.UnknownElement += unknownElementHandler;
            }

            using (XmlReader reader = XmlReader.Create(new MemoryStream(bytes)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(XmlReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            return (T)serializer.Deserialize(reader);
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(XmlElement element)
        {
            return Deserialize<T>(element, null);
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public object Deserialize(XmlElement element, Type elementType)
        {
            return Deserialize(element, elementType, null);
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public T Deserialize<T>(XmlElement element, XmlElementEventHandler unknownElementHandler)
        {
            return (T)Deserialize(element, typeof(T), unknownElementHandler);
        }
        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="unknownElementHandler"></param>
        /// <returns></returns>
        public object Deserialize(XmlElement element, Type elementType, XmlElementEventHandler unknownElementHandler)
        {
            XmlSerializer serializer = new XmlSerializer(elementType);
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            if (unknownElementHandler != null)
            {
                serializer.UnknownElement += unknownElementHandler;
            }

            using (XmlNodeReader reader = new XmlNodeReader(element))
            {
                return serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Default 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DefaultUnknownElementHandler(object sender, XmlElementEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceFile"></param>
        /// <param name="deleteAfterDeserialization"></param>
        /// <returns></returns>
        public T Deserialize<T>(string sourceFile)
        {
            return Deserialize<T>(sourceFile, null, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceFile"></param>
        /// <param name="deleteAfterDeserialization"></param>
        /// <returns></returns>
        public T Deserialize<T>(string sourceFile, bool deleteAfterDeserialization)
        {
            return Deserialize<T>(sourceFile, null, deleteAfterDeserialization);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceFile"></param>
        /// <param name="unknownElementHandler"></param>
        /// <param name="deleteAfterDeserialization"></param>
        /// <returns></returns>
        public T Deserialize<T>(string sourceFile, XmlElementEventHandler unknownElementHandler,
                                bool deleteAfterDeserialization)
        {
            return (T)Deserialize(sourceFile, typeof(T), unknownElementHandler, deleteAfterDeserialization);
        }
        public object Deserialize(string sourceFile, Type type)
        {
            return Deserialize(sourceFile, type, null, false);
        }
        public object Deserialize(string sourceFile, Type type, XmlElementEventHandler unknownElementHandler,
                                  bool deleteAfterDeserialization)
        {


            XmlSerializer serializer = new XmlSerializer(type);
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            if (unknownElementHandler != null)
            {
                serializer.UnknownElement += unknownElementHandler;
            }
            using (XmlReader reader = XmlReader.Create(sourceFile))
            {
                if (deleteAfterDeserialization)
                {
                    object result = serializer.Deserialize(reader);
                    File.Delete(sourceFile);
                    return result;
                }
                else
                {
                    return serializer.Deserialize(reader);
                }
            }
        }


        public void Serialize(object obj, string targetPath)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (XmlWriter writer = new XmlTextWriter(targetPath, StringUtils.UTF8))
            {
                if (_serializerNamespaces != null)
                {
                    serializer.Serialize(writer, obj, _serializerNamespaces);
                }
                else
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public void SerializeWithLineBreaks(object obj, string targetPath)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (XmlTextWriter writer = new XmlTextWriter(targetPath, StringUtils.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                if (_serializerNamespaces != null)
                {
                    serializer.Serialize(writer, obj, _serializerNamespaces);
                }
                else
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public byte[] SerializeWithLineBreaks(object obj)
        {
            return Serialize(obj, true);
        }
        public byte[] Serialize(object obj)
        {

            return Serialize(obj, false);
        }
        private byte[] Serialize(object obj, bool includeLineBreaks)
        {

            if (obj == null)
            {
                return null;
            }

            byte[] result = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (XmlTextWriter tw = new XmlTextWriter(ms, StringUtils.UTF8))
                {
                    if (includeLineBreaks)
                    {
                        tw.Formatting = Formatting.Indented;
                    }
                    else
                    {
                        tw.Formatting = Formatting.None;
                    }
                    XmlSerializer saveXML = new XmlSerializer(obj.GetType());
                    if (_serializerNamespaces != null)
                    {
                        saveXML.Serialize(tw, obj, _serializerNamespaces);
                    }
                    else
                    {
                        saveXML.Serialize(tw, obj);
                    }
                    ms.Flush();
                }

                ms.Close();
                result = ms.ToArray();
            }

            return result;

        }
        public XmlSerializerNamespaces SerializerNamespaces
        {
            get { return _serializerNamespaces; }
            set { _serializerNamespaces = value; }
        }

        public string ToXml(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            using (MemoryStream memStream = new MemoryStream(Serialize(obj)))
            {
                using (StreamReader reader = new StreamReader(memStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        public string SerializeToBase64String(object obj)
        {

            return Convert.ToBase64String(Serialize(obj));

        }
        public T DeserializeFromBase64String<T>(string text, XmlElementEventHandler unknownElementHandler)
        {

            return Deserialize<T>(Convert.FromBase64String(text));

        }

        public byte[] BinarySerialize<T>(T obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinarySerialize(obj, stream);
                stream.Close();
                byte[] buffer = stream.ToArray();
                return buffer;
            }
        }
        public void BinarySerialize<T>(T obj, string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                BinarySerialize(obj, stream);
            }
        }
        public void BinarySerialize<T>(T obj, Stream streamOut)
        {
            new BinaryFormatter().Serialize(streamOut, obj);
        }
        public T BinaryDeserialize<T>(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return BinaryDeserialize<T>(stream);
            }
        }
        public T BinaryDeserialize<T>(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                return BinaryDeserialize<T>(stream);
            }
        }
        public T BinaryDeserialize<T>(Stream streamIn)
        {
            return (T)new BinaryFormatter().Deserialize(streamIn);
        }
        public string BinarySerializeToString<T>(T obj)
        {
            byte[] buffer = BinarySerialize<T>(obj);
            return Convert.ToBase64String(buffer);
        }
        public T BinaryDeserializeFromString<T>(string str)
        {
            byte[] buffer = Convert.FromBase64String(str);
            return BinaryDeserialize<T>(buffer);
        }
        public string ToLiteXml(object obj)
        {
            return ToLiteXml(obj, false);
        }
        public string ToLiteXmlWithLineBreaks(object obj)
        {
            return ToLiteXml(obj, true);
        }
        public string ToLiteXml(object obj, bool includeLineBreaks)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                _omitXmlDeclarationWriterSettings.Indent = includeLineBreaks;
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, _omitXmlDeclarationWriterSettings))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(xmlWriter, obj, _unqualifiedNamespace);
                    string xmlText = stringWriter.ToString();
                    return xmlText;
                }
            }
        }
        public void ToLiteXml(object obj, string targetPath)
        {
            ToLiteXml(obj, targetPath, false);
        }
        public void ToLiteXmlWithLineBreaks(object obj, string targetPath)
        {
            ToLiteXml(obj, targetPath, true);
        }
        public void ToLiteXml(object obj, string targetPath, bool includeLineBreaks)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                _omitXmlDeclarationWriterSettings.Indent = includeLineBreaks;
                using (XmlWriter xmlWriter = XmlWriter.Create(targetPath, _omitXmlDeclarationWriterSettings))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(xmlWriter, obj, _unqualifiedNamespace);
                }
            }
        }
        public T SerializeClone<T>(T objectToClone)
        {
            byte[] bytes = this.BinarySerialize(objectToClone);
            return this.BinaryDeserialize<T>(bytes);
        } 
        #endregion
        public void JsonSerialize(object obj, string targetPath)
        {
            using (FileStream stream = File.OpenWrite(targetPath))
            {
                ServiceStack.Text.JsonSerializer.SerializeToStream(obj, stream);
            }
        }
        public byte[] JsonSerialize(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ServiceStack.Text.JsonSerializer.SerializeToStream(obj, stream);
                return stream.ToArray();
            }
        }
    }
    public class NamespaceSpecifiedXmlTextReader : XmlTextReader
    {
        public NamespaceSpecifiedXmlTextReader(string namespaceUrl, System.IO.TextReader reader) : base(reader)
        { _namespaceUrl = namespaceUrl;  }
        public NamespaceSpecifiedXmlTextReader(string namespaceUrl, Stream stream) : base(stream)
        { _namespaceUrl = namespaceUrl;  }
        public NamespaceSpecifiedXmlTextReader(string namespaceUrl, string filePath) : base(filePath)
        { _namespaceUrl = namespaceUrl;  }

        public override string NamespaceURI
        {
            get { return _namespaceUrl; }
        }
        private string _namespaceUrl;
    }
    public class NamespaceSpecifiedXmlNodeReader : XmlNodeReader
    {
        public NamespaceSpecifiedXmlNodeReader(string namespaceUrl, XmlNode node)
            : base(node)
        { _namespaceUrl = namespaceUrl; }

        public override string NamespaceURI
        {
            get { return _namespaceUrl; }
        }
        private string _namespaceUrl;
    }
}
