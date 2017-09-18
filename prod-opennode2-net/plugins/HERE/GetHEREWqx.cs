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
using Windsor.Node2008.WNOSPlugin.HERE.FACID30;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.HERE
{
    [Serializable]
    public class GetHEREWqx : HEREBaseService, ISolicitProcessor
    {

        private const string FLOW_NAME = "HERE-WQX";

        protected const string PARAM_FILE_PATH = "WQXFilePath";

        public GetHEREWqx()
        {
            DataProviders.Remove(DataSourceParameterType.SourceDatabaseDataSource.ToString());
        }

        protected override string ServiceName { get { return "GetHEREWqx"; } }

        public override void ProcessSolicit(string requestId)
        {
            base.ProcessSolicit(requestId);

            string resultPath;
            GetParameter(_dataRequest, PARAM_FILE_PATH, 1, out resultPath);

            if (!File.Exists(resultPath))
            {
                throw new FileNotFoundException(string.Format("The WQX file was not found: \"{0}\"", resultPath));
            }

            SaveResults(_numOfDays);
            _documentManager.AddDocument(_dataRequest.TransactionId, CommonTransactionStatusCode.Completed,
                                         null, resultPath);
        }
    }
    [Serializable]
    public class GetHEREWqxDelete : GetHEREWqx
    {

        private const string FLOW_NAME = "HERE-WQX-DELETE";

        public GetHEREWqxDelete()
        {
        }

        protected override string ServiceName
        {
            get
            {
                return "GetHEREWqxDelete";
            }
        }
    }
}
