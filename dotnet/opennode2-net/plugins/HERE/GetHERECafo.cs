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
using Windsor.Node2008.WNOSPlugin.HERE.CAFO11;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.HERE
{
    [Serializable]
    public class GetHERECafo : HEREBaseService, ISolicitProcessor
    {

        private const string FLOW_NAME = "HERE-CAFO";

        public GetHERECafo()
        {
        
        }

        protected override string ServiceName { get { return "GetHERECafo"; } }

        public override void ProcessSolicit(string requestId)
        {
            base.ProcessSolicit(requestId);

            //Configure
            CAFOData data = new CAFOData(ValidateDBProvider(DataSourceParameterType.SourceDatabaseDataSource.ToString()));
            CAFOService service = new CAFOService(data);

            //Execute
            string resultPath = service.Execute(_argDate, TargetXmlFilePath, _serializationHelper,
                                                _compressionHelper, this);

            //Save results
            if (!string.IsNullOrEmpty(resultPath))
            {
                SaveResults(_numOfDays);
                _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                             null, resultPath);
            }
        }




#if TEST_CODE
        static void Main(string[] args)
        {

            try
            {


                //Configure Data Sources
                FileConfigurationSource configSource = new FileConfigurationSource(@"..\..\..\DataSources.config");
                DatabaseProviderFactory providerFactory = new DatabaseProviderFactory(configSource);

                GetHERECafo service = new GetHERECafo();

                service.DataSources[DataSourceParameterType.SourceDatabaseDataSource.ToString()] = providerFactory.Create("HEREFLOW");
                service.DataSources[DataSourceParameterType.TargetDatabaseDataSource.ToString()] = providerFactory.Create("HEREFLOW");

                service.RunTimeArguments[HERERunTimeArgs.EndpointUri.ToString()] = "https://ne.node.state.gov";
                service.RunTimeArguments[HERERunTimeArgs.IsFacilitySourceIndicator.ToString()] = "True";
                service.RunTimeArguments[HERERunTimeArgs.SourceSystemName.ToString()] = "NE-IIS";

                service.CurrentTransaction = Guid.NewGuid().ToString();
                service.ExecutingBy = "test@windsorsolutions.com";


                Console.WriteLine("GetHEREFacility: " + service.Execute(new string[] { "100" }, @"..\..\..\temp"));


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
