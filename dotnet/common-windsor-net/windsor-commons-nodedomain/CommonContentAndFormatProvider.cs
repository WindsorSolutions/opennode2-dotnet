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
using System.Reflection;
using System.IO;
using Windsor.Commons.Core;

namespace Windsor.Commons.NodeDomain
{
    #region Enums

    public enum CommonContentType
    {
        OTHER,
        XML,
        Flat,
        Bin,
        ZIP,
        ODF,
        HTML,
        PDF,
    }

    #endregion

    [Serializable]
    public static class CommonContentAndFormatProvider
    {
        private enum Wsdl11ContentType
        {
            OTHER,
            XML,
            Flat,
            Bin,
            ZIP
        }

        #region Members

        private static readonly Dictionary<CommonContentType, string> _commonContentToFormatMap;

        #endregion

        /// <summary>
        /// Initializes the default object state
        /// </summary>
        static CommonContentAndFormatProvider()
        {
            _commonContentToFormatMap = new Dictionary<CommonContentType, string>();
            _commonContentToFormatMap.Add(CommonContentType.OTHER, "application/x");
            _commonContentToFormatMap.Add(CommonContentType.XML, "text/xml");
            _commonContentToFormatMap.Add(CommonContentType.Flat, "text/plain");
            _commonContentToFormatMap.Add(CommonContentType.Bin, "application/octet-stream");
            _commonContentToFormatMap.Add(CommonContentType.ZIP, "application/zip");
            _commonContentToFormatMap.Add(CommonContentType.HTML, "text/html");
            _commonContentToFormatMap.Add(CommonContentType.PDF, "application/pdf");
        }

        public static CommonContentType Convert(string text)
        {
            return EnumUtils.ParseEnum<CommonContentType>(text);
        }
        public static string ConvertToMimeType(CommonContentType type)
        {
            return _commonContentToFormatMap.ContainsKey(type) ? _commonContentToFormatMap[type] :
                _commonContentToFormatMap[CommonContentType.OTHER];
        }
        public static string ConvertTo11Enum(CommonContentType type)
        {
            return EnumUtils.ParseEnum<Wsdl11ContentType>(type.ToString()).ToString();
        }
        public static string GetFileExtension(CommonContentType type)
        {
            switch (type)
            {
                case CommonContentType.Bin:
                    return ".bin";
                case CommonContentType.Flat:
                    return ".txt";
                case CommonContentType.ODF:
                    return ".odf";
                case CommonContentType.OTHER:
                    return ".dat";
                case CommonContentType.XML:
                    return ".xml";
                case CommonContentType.ZIP:
                    return ".zip";
                case CommonContentType.HTML:
                    return ".html";
                case CommonContentType.PDF:
                    return ".pdf";
                default:
                    return ".unknown";
            }
        }
        public static CommonContentType GetFileTypeFromName(string fileName)
        {
            return GetFileTypeFromExtension(Path.GetExtension(fileName));
        }
        public static string ConvertContentBytesToString(byte[] content)
        {
            if (content == null)
            {
                return null;
            }
            if (content.Length == 0)
            {
                return string.Empty;
            }
            using (StreamReader reader = new StreamReader(new MemoryStream(content)))
            {
                return reader.ReadToEnd();
            }
        }
        public static CommonContentType GetFileTypeFromExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                return CommonContentType.OTHER;
            }
            if (extension[0] == '.')
            {
                extension = extension.Substring(1).ToLower();
            }
            else
            {
                extension = extension.ToLower();
            }
            switch (extension)
            {
                case "bin":
                    return CommonContentType.Bin;
                case "txt":
                    return CommonContentType.Flat;
                case "odf":
                    return CommonContentType.ODF;
                case "dat":
                    return CommonContentType.OTHER;
                case "xml":
                    return CommonContentType.XML;
                case "zip":
                    return CommonContentType.ZIP;
                case "html":
                    return CommonContentType.HTML;
                case "pdf":
                    return CommonContentType.PDF;
                default:
                    return CommonContentType.OTHER;
            }
        }
        public static CommonContentType? GetFileTypeFromContent(string filePath)
        {
            return FileTypeIdentifier.GetFileTypeFromContent(filePath);
        }
    }
}
