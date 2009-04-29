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
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Client2;
using System.Web.Services.Protocols;
using Windsor.Commons.Core;

namespace Windsor.Node2008.NodeEndpointClient
{
    /// <summary>
    /// A static class that contains the top-level methods for accessing functionality within this assembly.
    /// </summary>
    public static class NodeEndpointClientProvider
    {
        /// <summary>
        /// Create a node endpoint client factory instance that can be used to create node client endpoint accessors.
        /// </summary>
        /// <returns>The <see cref="INodeEndpointClientFactory"/> instance that can be used to create <see cref="INodeEndpointClient"/> 
        /// node client endpoint accessors.</returns>
        public static INodeEndpointClientFactory CreateClientFactory()
        {
            NodeEndpointClientFactory factory = new NodeEndpointClientFactory();
            return factory;
        }
        /// <summary>
        /// Create a node endpoint client factory instance that can be used to create node client endpoint accessors.  Use this
        /// method instead of CreateClientFactory() if you want to call INodeEndpointClientFactory.Make() without having to pass
        /// in the NAAS authentication credentials each time.
        /// </summary>
        /// <param name="defaultCredentials">The NAAS default authentication credentials to assign (unless specified otherwise) to 
        /// the node client endpoint accessors returned from INodeEndpointClientFactory.Make().</param>
        /// <returns>The <see cref="INodeEndpointClientFactory"/> instance that can be used to create <see cref="INodeEndpointClient"/> node client 
        /// endpoint accessors.</returns>
        public static INodeEndpointClientFactory CreateClientFactory(AuthenticationCredentials defaultCredentials)
        {
            NodeEndpointClientFactory factory = new NodeEndpointClientFactory();
            factory.DefaultAuthenticationCredentials = defaultCredentials;
            factory.Init();
            return factory;
        }

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// The input credentials are authenticated against the client node before this method returns.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="credentials">The credentials used to authenticate with the Exchange node endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <param name="proxy">Proxy information for accessing the Exchange node endpoint.  This value can be null if
        /// no proxy is required.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        public static INodeEndpointClient CreateClientAndAuthenticate(string targetEndpointUrl, EndpointVersionType type, 
                                                                      AuthenticationCredentials credentials,
                                                                      string tempDirectoryPath, IWebProxy proxy)
        {
            INodeEndpointClient client = new NodeEndpointClientFactory().Make(targetEndpointUrl, type, credentials,
                                                                              tempDirectoryPath, proxy);
            try
            {
                client.Authenticate();
            }
            catch (Exception)
            {
                DisposableBase.SafeDispose(client);
                throw;
            }
            return client;
        }

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// The input credentials are authenticated against the client node before this method returns.  This method will attempt
        /// to connect to BOTH v1.1 and v2.0 endpoints and return the first connection that succeeds.  Note that you
        /// can access INodeEndpointClient.Version to determine the version of the returned endpoint.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="credentials">The credentials used to authenticate with the Exchange node endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <param name="proxy">Proxy information for accessing the Exchange node endpoint.  This value can be null if
        /// no proxy is required.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        public static INodeEndpointClient CreateClientAndAuthenticate(string targetEndpointUrl, AuthenticationCredentials credentials,
                                                                      string tempDirectoryPath, IWebProxy proxy)
        {
            INodeEndpointClient client = null;
            try
            {
                client = CreateClientAndAuthenticate(targetEndpointUrl, EndpointVersionType.EN11, credentials, 
                                                     tempDirectoryPath, proxy);
            }
            catch (SoapException e)
            {
                if (string.Equals(e.Code.Name, "VersionMismatch", StringComparison.InvariantCultureIgnoreCase))
                {
                    client = CreateClientAndAuthenticate(targetEndpointUrl, EndpointVersionType.EN20, credentials,
                                                         tempDirectoryPath, proxy);
                }
                else
                {
                    throw;
                }
            }
            return client;
        }

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// The node is pinged after is it created to ensure it can be accessed.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="naasUserToken">A valid NAAS user token that will be used for validating this endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <param name="proxy">Proxy information for accessing the Exchange node endpoint.  This value can be null if
        /// no proxy is required.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        public static INodeEndpointClient CreateClientAndPing(string targetEndpointUrl, EndpointVersionType type,
                                                              string naasUserToken, string tempDirectoryPath, 
                                                              IWebProxy proxy)
        {
            INodeEndpointClient client = new NodeEndpointClientFactory().Make(targetEndpointUrl, type, naasUserToken,
                                                                              tempDirectoryPath, proxy);
            try
            {
                client.NodePing();
            }
            catch (Exception)
            {
                DisposableBase.SafeDispose(client);
                throw;
            }
            return client;
        }

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// The node is pinged after is it created to ensure it can be accessed.  This method will attempt
        /// to connect to BOTH v1.1 and v2.0 endpoints and return the first connection that succeeds.  Note that you
        /// can access INodeEndpointClient.Version to determine the version of the returned endpoint.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="naasUserToken">A valid NAAS user token that will be used for validating this endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <param name="proxy">Proxy information for accessing the Exchange node endpoint.  This value can be null if
        /// no proxy is required.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        public static INodeEndpointClient CreateClientAndPing(string targetEndpointUrl, string naasUserToken, 
                                                              string tempDirectoryPath, IWebProxy proxy)
        {
            INodeEndpointClient client = null;
            try
            {
                client = CreateClientAndPing(targetEndpointUrl, EndpointVersionType.EN11, naasUserToken,
                                             tempDirectoryPath, proxy);
            }
            catch (SoapException e)
            {
                if (string.Equals(e.Code.Name, "VersionMismatch", StringComparison.InvariantCultureIgnoreCase))
                {
                    client = CreateClientAndPing(targetEndpointUrl, EndpointVersionType.EN20, naasUserToken,
                                                 tempDirectoryPath, proxy);
                }
            }
            return client;
        }

        /// <summary>
        /// Create a node endpoint client factory instance that can be used to create node client endpoint accessors.  Use this
        /// method instead of CreateClientFactory() if you want to call INodeEndpointClientFactory.Make() without having to pass
        /// in the NAAS authentication credentials each time.
        /// </summary>
        /// <param name="defaultUsername">The NAAS default authentication username to assign (unless specified otherwise) to 
        /// the node client endpoint accessors returned from INodeEndpointClientFactory.Make().</param>
        /// <param name="defaultPassword">The NAAS default authentication password to assign (unless specified otherwise) to 
        /// the node client endpoint accessors returned from INodeEndpointClientFactory.Make().</param>
        /// <returns>The <see cref="INodeEndpointClientFactory"/> instance that can be used to create <see cref="INodeEndpointClient"/> node client 
        /// endpoint accessors.</returns>
        public static INodeEndpointClientFactory CreateClientFactory(string defaultUsername, string defaultPassword)
        {
            NodeEndpointClientFactory factory = new NodeEndpointClientFactory();
            factory.DefaultAuthenticationCredentials = new AuthenticationCredentials(defaultUsername, defaultPassword);
            factory.Init();
            return factory;
        }
    }
}
