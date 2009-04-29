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

		/// <summary>
		/// Deserialize
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xml"></param>
		/// <param name="unknownElementHandler"></param>
		/// <returns></returns>
		public T Deserialize<T>(byte[] bytes) {
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
        public T Deserialize<T>(XmlElement element, XmlElementEventHandler unknownElementHandler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            if (unknownElementHandler != null)
            {
                serializer.UnknownElement += unknownElementHandler;
            }

            using (XmlNodeReader reader = new XmlNodeReader(element))
            {
                return (T)serializer.Deserialize(reader);
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


            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.UnknownElement += new XmlElementEventHandler(DefaultUnknownElementHandler);

            if (unknownElementHandler != null)
            {
                serializer.UnknownElement += unknownElementHandler;
            }
            using (XmlReader reader = XmlReader.Create(sourceFile))
            {
                if (deleteAfterDeserialization)
                {
                    T result = (T) serializer.Deserialize(reader);
                    File.Delete(sourceFile);
                    return result;
                }
                else
                {
                    return (T) serializer.Deserialize(reader);
                }
            }
        }


        public void Serialize(object obj, string targetPath)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            using (XmlWriter writer = new XmlTextWriter(targetPath, StringUtils.UTF8))
            {
                serializer.Serialize(writer, obj);
            }
        }


        public byte[] Serialize(object obj)
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
                    tw.Formatting = Formatting.None;
                    XmlSerializer saveXML = new XmlSerializer(obj.GetType());
                    saveXML.Serialize(tw, obj);
                    ms.Flush();
                }

                ms.Close();
                result = ms.ToArray();
            }

            return result;

        }


        public string ToXml(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new StreamReader(new MemoryStream(Serialize(obj))).ReadToEnd();
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
                new BinaryFormatter().Serialize(stream, obj);
                stream.Close();
                byte[] buffer = stream.ToArray();
                return buffer;
            }
        }
        public T BinaryDeserialize<T>(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }
        #endregion
    }
}
