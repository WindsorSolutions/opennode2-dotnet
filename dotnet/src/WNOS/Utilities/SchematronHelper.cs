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
using Common.Logging;
using System.Net;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSUtility;
using System.Reflection;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOS.Utilities
{
    public class SchematronHelper : ISchematronHelper
    {

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private readonly Windsor.Node.Schematron.ISchematronHelper _schematronClient;
        private readonly Dictionary<string, string> _flowSchemaMap;


        /// <summary>
        /// SchematronHelper
        /// </summary>
        /// <param name="schematronEndpoint">Endpoint Url. Either the test or prod instance</param>
        /// <param name="credential">NAAS Credentials. Must correspond to the schematronEndpoint environment</param>
        /// <param name="flowSchemaMap">Collection of Flow to Schema Version mappings</param>
        /// <param name="proxy">Web Proxy in case we are behind one</param>
        public SchematronHelper(string schematronEndpoint, AuthenticationCredentials credential, 
								Dictionary<string, string> flowSchemaMap, IWebProxy proxy)
        {
            LOG.Debug("Configuring SchematronHelper with: " + schematronEndpoint);
            LOG.Debug("   credential: " + credential);
            LOG.Debug("   proxy: " + proxy);

            if (string.IsNullOrEmpty(schematronEndpoint))
            {
                throw new ArgumentNullException("documentPath");
            }

            if (credential == null)
            {
                throw new ArgumentNullException("credential");
            }

            if (flowSchemaMap == null || flowSchemaMap.Count == 0)
            {
                throw new ArgumentException("FlowSchemaMap not configured");
            }

            _schematronClient = new Windsor.Node.Schematron.SchematronHelper();
            _schematronClient.Configure(schematronEndpoint, credential.UserName, credential.Password, proxy);

            _flowSchemaMap = flowSchemaMap;

        }

        /// <summary>
        /// SchematronHelper
        /// </summary>
        /// <param name="schematronEndpoint">Endpoint Url. Either the test or prod instance</param>
        /// <param name="credential">NAAS Credentials. Must correspond to the schematronEndpoint environment</param>
        /// <param name="flowSchemaMap"></param>
        public SchematronHelper(string schematronEndpoint, AuthenticationCredentials credential, Dictionary<string, string> flowSchemaMap)
            : this(schematronEndpoint, credential, flowSchemaMap, null)
        {

        }

        public IList<string> GetValidFlowCodes()
        {
            List<string> list = new List<string>(_flowSchemaMap.Keys);
            list.Sort();
            return list;
        }

        /// <summary>
        /// Submits a specific document to EPA Schematron for validation
        /// </summary>
        /// <param name="documentPath">fully qualifed path to the documents. Zip or XML are fine</param>
        /// <param name="flowCode">Code for the flow. will be used to derive the schema version</param>
        /// <param name="emailNotifications">list of emails to send the notifications to</param>
        /// <returns>validation token</returns>
        public string Validate(string documentPath, string flowCode, params string[] emailNotifications)
        {

            if (string.IsNullOrEmpty(documentPath))
            {
                throw new ArgumentNullException("documentPath");
            }

            if (string.IsNullOrEmpty(flowCode))
            {
                throw new ArgumentNullException("flowCode");
            }

            if (!_flowSchemaMap.ContainsKey(flowCode))
            {
                throw new ArgumentException("flowCode not mapped to schema");
            }

            LOG.Debug("Validating");
            LOG.Debug("   documentPath: " + documentPath);
            LOG.Debug("   flowCode: " + flowCode);
            if (emailNotifications != null)
            {
                LOG.Debug("   emailNotifications: " + string.Join(",", emailNotifications));
            }

            string schemaType = _flowSchemaMap[flowCode];

            LOG.Debug("   schemaType: " + schemaType);

            string result = _schematronClient.SchematronValidate(documentPath, schemaType, emailNotifications);

            LOG.Debug("Validation result: " + result);

            return result;

        }

    }

}
