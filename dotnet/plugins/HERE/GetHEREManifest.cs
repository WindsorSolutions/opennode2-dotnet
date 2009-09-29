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
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using System.Configuration;
using Windsor.Node2008.WNOSPlugin.HERE.HERE10;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOSPlugin.HERE
{
    [Serializable]
    public class GetHEREManifest : HEREBaseService, IQueryProcessor
    {

        private const string FLOW_NAME = "HERE";

        public GetHEREManifest()
        {

            ConfigurationArguments.Clear();

            DataProviders.Clear();

            DataProviders.Add(DataSourceParameterType.SourceDatabaseDataSource.ToString(), null);
        }


        protected override string ServiceName { get { return "GetHEREManifest"; } }

        public override PaginatedContentResult ProcessQuery(string requestId)
        {
            base.ProcessQuery(requestId);

            string requestingUsername = _transactionManager.GetTransactionUsername(_dataRequest.TransactionId);

            ICollection<string> allFlowList = _flowManager.GetDataFlowNames();
            ICollection<string> protectedFlowList = _flowManager.GetProtectedFlowNames();
            ICollection<string> userProtectedFlowList = _flowManager.GetProtectedFlowNamesForUser(requestingUsername);

            HEREData data = new HEREData(ValidateDBProvider(DataSourceParameterType.SourceDatabaseDataSource.ToString()));
            HEREManifestService service = new HEREManifestService(data);

            return GetXmlPaginatedContentResult(service.Execute(allFlowList, protectedFlowList, userProtectedFlowList,
                                                                _argDate, _serializationHelper, this), 
                                                                _dataRequest.RowIndex, _dataRequest.MaxRowCount, 
                                                                true);
        }

#if TEST_CODE
        static void Main(string[] args)
        {

            try
            {


                //Configure Data Sources
                FileConfigurationSource configSource = new FileConfigurationSource(@"..\..\..\DataSources.config");
                DatabaseProviderFactory providerFactory = new DatabaseProviderFactory(configSource);

                GetHEREManifest service = new GetHEREManifest();

                service.DataSources[DataSourceParameterType.SourceDatabaseDataSource.ToString()] = providerFactory.Create("HEREFLOW");

                service.CurrentTransaction = Guid.NewGuid().ToString();
                service.ExecutingBy = "guy@windsorsolutions.com";


                File.WriteAllBytes(@"..\..\..\temp\GetHEREManifest.xml", service.Execute(new string[] { "1900-01-01" }, 0, Int64.MaxValue));


            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                Console.WriteLine("Done");
                Console.ReadLine();
            }
        }
#endif // TEST_CODE
    }
}
