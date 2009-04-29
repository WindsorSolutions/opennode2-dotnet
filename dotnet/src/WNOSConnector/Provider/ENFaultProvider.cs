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
using System.Web.Services.Protocols;
using System.Runtime.Remoting;
using System.Reflection;
using Common.Logging;
using Spring.Dao;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSConnector.Provider
{

    public enum ENExceptionCodeType
    {
        E_UnknownUser,
        E_InvalidCredential,
        E_TransactionId,
        E_UnknownMethod,
        E_ServiceUnavailable,
        E_AccessDenied,
        E_InvalidToken,
        E_FileNotFound,
        E_TokenExpired,
        E_ValidationFailed,
        E_ServerBusy,
        E_RowIdOutofRange,
        E_FeatureUnsupported,
        E_VersionMismatch,
        E_InvalidFileName,
        E_InvalidFileType,
        E_InvalidDataflow,
        E_InvalidParameter,
        E_AuthMethod,
        E_Unknown,
        E_QueryReturnSetTooBig,
        E_DBMSError,
        E_RecipientNotSupported,
        E_NotificationURINotSupported,
    }

    public interface IFaultProvider
    {
        SoapException GetFault(EndpointVersionType endpointVersion, ENExceptionCodeType code, string descr);
        SoapException GetFault(EndpointVersionType endpointVersion, ENExceptionCodeType code, string format, params object[] args);
        SoapException GetFault(EndpointVersionType endpointVersion, Exception re);
    }

    /// <summary>
    /// Windsor.Node2008.Endpoint2.Provider.ENFaultProvider
    /// </summary>
    public class ENFaultProvider : IFaultProvider
    {

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        #region Members
        private string _defaultErrorCode;
        private string _defaultErrorDescription;
        #endregion

        #region Init

        public void Init()
        {

            if (string.IsNullOrEmpty(_defaultErrorCode))
            {
                throw new ArgumentException("DefaultErrorCode property not set");
            }

            if (string.IsNullOrEmpty(_defaultErrorDescription))
            {
                throw new ArgumentException("DefaultErrorDescription property not set");
            }
        }

        #endregion

        #region Methods


        public SoapException GetFault(EndpointVersionType endpointVersion, Exception ex)
        {

            LOG.Error(ex.Message, ex);

            ENExceptionCodeType code = ENExceptionCodeType.E_Unknown;

            if (!string.IsNullOrEmpty(ex.HelpLink))
            {
                try
                {
                    code = (ENExceptionCodeType)Enum.Parse(typeof(ENExceptionCodeType), ex.HelpLink, true);
                }
                catch (Exception enumEx)
                {
                    LOG.Error("Invalid eror code: " + ex.HelpLink, enumEx);
                }
            }

            return GetFault(endpointVersion, code, CleanseExceptionMessage(ex));
        }

        public SoapException GetFault(EndpointVersionType endpointVersion, ENExceptionCodeType code, string format, params object[] args)
        {
            return GetFault(endpointVersion, code, string.Format(format, args));
        }
        
        public SoapException GetFault(EndpointVersionType endpointVersion, ENExceptionCodeType code, string descr)
        {

            if (string.IsNullOrEmpty(descr))
            {
                descr = _defaultErrorDescription;
            }

            string detailName, detailNamespaceUri, errorCodeName, faultName, namespaceUri;
            if (endpointVersion == EndpointVersionType.EN20)
            {
                detailName = "soap:Detail";
                detailNamespaceUri = "http://www.w3.org/2003/05/soap-envelope";
                errorCodeName = "errorCode";
                faultName = "NodeFaultDetailType";
                namespaceUri = "http://www.exchangenetwork.net/schema/node/2";
            }
            else
            {
                detailName = SoapException.DetailElementName.Name;
                errorCodeName = "errorcode";
                faultName = "faultdetail";
                namespaceUri = detailNamespaceUri = string.Empty;
            }

            XmlDocument doc = new XmlDocument();
            XmlNode node = doc.CreateNode(
                XmlNodeType.Element,
                detailName,
                detailNamespaceUri);

            System.Xml.XmlNode details = doc.CreateNode(
                XmlNodeType.Element,
                faultName,
                namespaceUri);

            System.Xml.XmlNode errorCode = doc.CreateNode(
                XmlNodeType.Element,
                errorCodeName,
                namespaceUri);

            errorCode.InnerText = code.ToString();
            details.AppendChild(errorCode);

            System.Xml.XmlNode desc = doc.CreateNode(
                XmlNodeType.Element,
                "description",
                namespaceUri);

            desc.InnerText = string.Format("{0}{1}{2}", code.ToString(), Environment.NewLine, descr);
            details.AppendChild(desc);

            // Append the two child elements to the detail node.
            node.AppendChild(details);

            string errorUri = null;

            if (System.Web.HttpContext.Current != null &&
                System.Web.HttpContext.Current.Request != null)
            {
                errorUri = System.Web.HttpContext.Current.Request.RawUrl.ToString();
            }

            //Throw the exception.
  
            SoapException soapException =
                new SoapException(descr, SoapException.ServerFaultCode, errorUri, node);
            soapException.HelpLink = code.ToString();
            return soapException;
        }
        
        /// <summary>
        /// Remove confidential information from an exception message for public
		/// display.
        /// </summary>
		public static string CleanseExceptionMessage(Exception ex)
		{
			if ( ex is DataAccessException ) {
				return string.Format("A database exception of type \"{0}\" occurred.",
									 ex.GetType().Name);
			}
			return ex.Message;
		}

        #endregion

        #region Properties


        public string DefaultErrorDescription
        {
            get { return _defaultErrorDescription; }
            set { _defaultErrorDescription = value; }
        }



        public string DefaultErrorCode
        {
            get { return _defaultErrorCode; }
            set { _defaultErrorCode = value; }
        }

        #endregion
    }
}
