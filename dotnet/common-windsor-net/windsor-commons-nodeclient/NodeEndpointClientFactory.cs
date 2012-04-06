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
using System.Net;
using System.Xml;
using System.IO;
using System.Reflection;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Commons.NodeClient
{
    public class NodeEndpointClientFactory : INodeEndpointClientFactory
    {
        private AuthenticationCredentials _defaultAuthenticationCredentials;

        public NodeEndpointClientFactory()
        {
        }
        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _defaultAuthenticationCredentials);
        }

        public static Exception PingNode(string targetEndpointUrl, EndpointVersionType type)
        {
            try
            {
                using (INodeEndpointClient client =
                    new NodeEndpointClientFactory().Make(targetEndpointUrl, type, new AuthenticationCredentials("test", "test"),
                                                         null, null))
                {
                    client.Timeout = 8000;
                    client.NodePing();
                }
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type)
        {
            if (_defaultAuthenticationCredentials == null)
            {
                throw new InvalidOperationException("Please set DefaultAuthenticationCredentials before calling this method.");
            }
            // TODO: 
            return MakeClient(targetEndpointUrl, type, _defaultAuthenticationCredentials, null, null, null);
        }

        /// <summary>
        /// Makes EN Client using the temp directory as the target path
        /// </summary>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, string naasUserToken)
        {
            return MakeClient(targetEndpointUrl, type, null, naasUserToken, null, null);
        }

        /// <summary>
        /// Makes EN Client using the temp directory as the target path
        /// </summary>
        /// <param name="targetEndpointUrl"></param>
        /// <param name="type"></param>
        /// <param name="credentials"></param>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials)
        {
            return MakeClient(targetEndpointUrl, type, credentials, null, null, null);
        }

        /// <summary>
        /// Makes EN Client
        /// </summary>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type,
                                        string naasUserToken, 
                                        string path)
        {
            return MakeClient(targetEndpointUrl, type, null, naasUserToken, path, null);
        }

        /// <summary>
        /// Makes EN Client
        /// </summary>
        /// <param name="targetEndpointUrl"></param>
        /// <param name="type"></param>
        /// <param name="credentials"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type,
                                        AuthenticationCredentials credentials,
                                        string path)
        {
            return MakeClient(targetEndpointUrl, type, credentials, null, path, null);
        }

        /// <summary>
        /// Makes EN Client
        /// </summary>
        /// <param name="targetEndpointUrl"></param>
        /// <param name="type"></param>
        /// <param name="credentials"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials, 
                                        string path, IWebProxy proxy)
        {
            return MakeClient(targetEndpointUrl, type, credentials, null, path, proxy);
        }

        /// <summary>
        /// Makes EN Client
        /// </summary>
        /// <returns></returns>
        public INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, string naasUserToken,
                                        string path, IWebProxy proxy)
        {
            return MakeClient(targetEndpointUrl, type, null, naasUserToken, path, proxy);
        }
        
        /// <summary>
        /// Makes EN Client
        /// </summary>
        /// <returns></returns>
        private INodeEndpointClient MakeClient(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials,
                                               string naasUserToken, string tempDirectoryPath, IWebProxy proxy)
        {
            INodeEndpointClient client = null;

            if ((credentials != null) && (naasUserToken != null))
            {
                throw new ArgumentException("Must specify either credentials or naasUserToken, not both");
            }
            if (string.IsNullOrEmpty(tempDirectoryPath))
            {
                tempDirectoryPath = Path.GetTempPath();
            }

            // TSM: This is a fix to allow clients to work with older versions of OpenNode2 that have not been
            // upgraded to the node version 2.1 spec yet.
            bool compatibilityMode = false;
            if (type == EndpointVersionType.EN20CompatibilityMode)
            {
                compatibilityMode = true;
                type = EndpointVersionType.EN20;
            }

            switch (type)
            {
                case EndpointVersionType.EN11:
                    if (credentials != null)
                    {
                        client = new Client11(targetEndpointUrl, credentials, tempDirectoryPath, proxy);
                    }
                    else
                    {
                        client = new Client11(targetEndpointUrl, naasUserToken, tempDirectoryPath, proxy);
                    }
                    break;

                case EndpointVersionType.EN20:
                    if (credentials != null)
                    {
                        client = new Client20(targetEndpointUrl, credentials, tempDirectoryPath, proxy, compatibilityMode);
                    }
                    else
                    {
                        client = new Client20(targetEndpointUrl, naasUserToken, tempDirectoryPath, proxy, compatibilityMode);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid endpoint type");
            }

            return client;
        }
        public AuthenticationCredentials DefaultAuthenticationCredentials
        {
            get { return _defaultAuthenticationCredentials; }
            set { _defaultAuthenticationCredentials = value; }
        }
    }
}
