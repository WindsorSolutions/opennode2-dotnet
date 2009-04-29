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
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSProviders
{
    /// <summary>
    /// This interface defines a factory pattern for creating instances that implement the <see cref="INodeEndpointClient"/> interface.
    /// INodeEndpointClient instances are used to access and communicate with a specific Exchange node endpoint.
    /// </summary>
    public interface INodeEndpointClientFactory
    {
        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  The
        /// default credentials assigned to this INodeEndpointClientFactory instance are used when creating the returned INodeEndpointClient 
        /// instance.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="credentials">The credentials used to authenticate with the Exchange node endpoint.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="naasUserToken">A valid NAAS user token that will be used for validating this endpoint.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, string naasUserToken);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="credentials">The credentials used to authenticate with the Exchange node endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials,
                                 string tempDirectoryPath);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
        /// </summary>
        /// <param name="targetEndpointUrl">The url for the Exchange node endpoint.</param>
        /// <param name="type">The version of the Exchange node endpoint.</param>
        /// <param name="naasUserToken">A valid NAAS user token that will be used for validating this endpoint.</param>
        /// <param name="tempDirectoryPath">A local directory path used for creating temporary files during INodeEndpointClient method 
        /// execution.  This value can be null, in which case the dafault system temp directory will be used.</param>
        /// <returns>A new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.  Dispose()
        /// should be called on the returned instance when the caller is finished using the instance.</returns>
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, string naasUserToken,
                                 string tempDirectoryPath);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
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
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, AuthenticationCredentials credentials,
                                 string tempDirectoryPath, IWebProxy proxy);

        /// <summary>
        /// Create a new <see cref="INodeEndpointClient"/> instance for accessing and communicating with a specific Exchange node.
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
        INodeEndpointClient Make(string targetEndpointUrl, EndpointVersionType type, string naasUserToken,
                                 string tempDirectoryPath, IWebProxy proxy);
    }
}
