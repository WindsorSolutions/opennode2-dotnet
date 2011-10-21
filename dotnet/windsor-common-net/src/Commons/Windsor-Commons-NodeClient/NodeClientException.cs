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
using System.Web.Services.Protocols;
using System.Runtime.Serialization;
using Windsor.Commons.NodeDomain;
using Windsor.Commons.Core;

namespace Windsor.Commons.NodeClient
{
    [Serializable]
    public class NodeClientException : SoapException
    {
        public NodeClientException(string endpointUrl, EndpointVersionType endpointVersion, string endpointMethod, SoapException e) :
            base(GetNodeClientExceptionMessage(endpointUrl, endpointVersion, endpointMethod, e), e.Code, e.Actor, e.Role, e.Lang, e.Detail, e.SubCode, null)
        {
        }
        protected NodeClientException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
        public static string GetNodeClientExceptionMessage(string endpointUrl, EndpointVersionType endpointVersion, string endpointMethod, SoapException e)
        {
            try
            {
                string message = e.Message;

                if ((e.Detail != null) && !string.IsNullOrEmpty(e.Detail.InnerXml))
                {
                    string innerXml = e.Detail.InnerXml;
                    string errorCodeElemName, descriptionElemName;
                    if (endpointVersion == EndpointVersionType.EN11)
                    {
                        errorCodeElemName = "<errorcode>";
                        descriptionElemName = "<description>";
                    }
                    else
                    {
                        errorCodeElemName = "<errorCode>";
                        descriptionElemName = "<description>";
                    }
                    string errorCode = null;
                    int errorCodeIndex = innerXml.IndexOf(errorCodeElemName);
                    if (errorCodeIndex > 0)
                    {
                        errorCodeIndex += errorCodeElemName.Length;
                        int errorCodeEndIndex = innerXml.IndexOf(errorCodeElemName.Replace("<", "</"), errorCodeIndex);
                        if (errorCodeEndIndex > 0)
                        {
                            errorCode = innerXml.Substring(errorCodeIndex, errorCodeEndIndex - errorCodeIndex);
                        }
                    }
                    string description = null;
                    int descriptionCodeIndex = innerXml.IndexOf(descriptionElemName);
                    if (descriptionCodeIndex > 0)
                    {
                        descriptionCodeIndex += descriptionElemName.Length;
                        int descriptionCodeEndIndex = innerXml.IndexOf(descriptionElemName.Replace("<", "</"), descriptionCodeIndex);
                        if (descriptionCodeEndIndex > 0)
                        {
                            description = innerXml.Substring(descriptionCodeIndex, descriptionCodeEndIndex - descriptionCodeIndex);
                        }
                    }
                    if ((errorCode != null) && (description != null))
                    {
                        message = string.Format("Error Code: {0}, Description: {1}", errorCode, description);
                    }
                    else if (errorCode != null)
                    {
                        message = string.Format("Error Code: {0}", errorCode);
                    }
                    else if (description != null)
                    {
                        message = string.Format("Description: {0}", description);
                    }
                }
                return string.Format("An error occurred communicating with the \"{0}\" remote node at url \"{1}\" using method \"{2}\": {3}",
                                      EnumUtils.ToDescription(endpointVersion), endpointUrl, endpointMethod, message);
            }
            catch (Exception)
            {
             return e.Message;
           }
        }
    }
}
