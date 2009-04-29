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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Diagnostics;
using System.Data.Common;
using System.Reflection;

namespace Windsor.Commons.Core
{
    [Serializable]
    public class XsltUtils
    {

        private readonly Encoding _defaultEncoding = Encoding.UTF8;

        public XsltUtils()
        {

        }

        public XsltUtils(Encoding defaultEncoding)
        {
            _defaultEncoding = defaultEncoding;
        }

        private readonly SerializationUtils _serializationHelper = new SerializationUtils();

        /// <summary>
        /// Transforms an xml data using provided stylesheet to temp location
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="doc">Loaded Xml Document</param>
        /// <returns>Result path</returns>
        public string Transform(string xsltPath, XmlDataDocument doc)
        {
            return Transform(xsltPath, doc, null);
        }

        /// <summary>
        /// Transforms an object by serialization and using provided stylesheet
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="obj">Instance of an object</param>
        /// <param name="args">Dictionary of arguments expected by the stylesheet</param>
        /// <returns>Result path</returns>
        public string Transform(string xsltPath, XmlDataDocument doc, IDictionary<string, object> args)
        {
            string tempFile = Path.GetTempFileName();
            Transform(xsltPath, tempFile, doc, null);
            return tempFile;
        }

        /// <summary>
        /// Transforms an object by serialization and using provided stylesheet
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="obj">Instance of an object</param>
        /// <returns>Result path</returns>
        public string Transform(string xsltPath, object obj)
        {
            return Transform(xsltPath, obj, null);
        }

        /// <summary>
        /// Transforms an object by serialization and using provided stylesheet
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="obj">Instance of an object</param>
        /// <param name="args">Dictionary of arguments expected by the stylesheet</param>
        /// <returns>Result path</returns>
        public string Transform(string xsltPath, object obj, IDictionary<string, object> args)
        {

            if (obj == null)
            {
                throw new ArgumentNullException("Null Object");
            }

            string tempFile = Path.GetTempFileName();
            _serializationHelper.Serialize(obj, tempFile);
            XmlDataDocument doc = new XmlDataDocument();
            doc.Load(tempFile);
            string targetPath = Path.GetTempFileName();
            Transform(xsltPath, targetPath, doc, args);
            FileUtils.SafeDeleteFile(tempFile);
            return targetPath;
        }

        /// <summary>
        /// Transforms an xml data using provided stylesheet to a predefined location
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="targetPath">Path to a target file</param>
        /// <param name="doc">Loaded Xml Document</param>
        public void Transform(string xsltPath, string targetPath, XmlDataDocument doc)
        {
            Transform(xsltPath, targetPath, doc, null);
        }

        /// <summary>
        /// Transforms an object by serialization and using provided stylesheet to a predefined location
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="targetPath">Path to a target file</param>
        /// <param name="obj">Instance of an object</param>
        public void Transform(string xsltPath, string targetPath, object obj)
        {
            Transform(xsltPath, targetPath, obj, null);
        }

        /// <summary>
        /// Transforms an object by serialization and using provided stylesheet to a predefined location
        /// </summary>
        /// <param name="xsltPath">Path to Xslt</param>
        /// <param name="targetPath">Path to a target file</param>
        /// <param name="obj">Instance of an object</param>
        /// <param name="args">Dictionary of arguments expected by the stylesheet</param>
        public void Transform(string xsltPath, string targetPath, object obj, IDictionary<string, object> args)
        {

            if (obj == null)
            {
                throw new ArgumentNullException("Null Object");
            }

            string tempFile = Path.GetTempFileName();
            _serializationHelper.Serialize(obj, tempFile);
            XmlDataDocument doc = new XmlDataDocument();
            doc.Load(tempFile);
            Transform(xsltPath, targetPath, doc, args);
            FileUtils.SafeDeleteFile(tempFile);
        }

        /// <summary>
        /// Transforms an xml data using provided stylesheet to a predefined location
        /// </summary>
        /// <param name="xsltPath"></param>
        /// <param name="targetPath"></param>
        /// <param name="doc"></param>
        /// <param name="args"></param>
        public void Transform(string xsltPath, string targetPath, XmlDataDocument doc, IDictionary<string, object> args)
        {
            if (!File.Exists(xsltPath))
            {
                throw new IOException("Xslt does not exists: " + xsltPath);
            }

            if (String.IsNullOrEmpty(targetPath))
            {
                throw new ArgumentNullException("Null targetPath");
            }

            if (doc == null)
            {
                throw new ArgumentNullException("Null doc");
            }

            XslCompiledTransform xslTran = new XslCompiledTransform();
            xslTran.Load(xsltPath);

            XsltArgumentList xsltArgs = null;

            if (args != null && args.Count > 0)
            {
                xsltArgs = new XsltArgumentList();

                foreach (KeyValuePair<string, object> arg in args)
                {
                    xsltArgs.AddParam(arg.Key, String.Empty, arg.Value);
                }

            }

            using (XmlTextWriter writer = new XmlTextWriter(targetPath, _defaultEncoding))
            {
                xslTran.Transform(doc, xsltArgs, writer);
            }

        }



    }
}
