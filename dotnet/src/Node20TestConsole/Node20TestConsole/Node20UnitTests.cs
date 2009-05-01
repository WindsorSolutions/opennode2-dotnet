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

//#define USE_SOLICIT_FOR_DOWNLOAD
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Net;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Threading;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.NodeEndpointClient;
using Windsor.Node2008.Client2;
using Windsor.Commons.Core;

using NUnit.Framework;

namespace Node20TestConsole
{

    public class UnitTestHelper : DisposableBase
    {
        public INodeEndpointClient _client;
        protected List<string> _tempCompressedSmallFileList;
        protected string _tempCompressedFileLarge;
        protected ICompressionHelper _compressionHelper;
        public const string QUERY_XML_FORMAT_PARAM =
            "<?xml version=\"1.0\"?>" +
            "<SolicitParam xmlns=\"http://www.exchangenetwork.net/schema/NCT/1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                "{0}" +
            "</SolicitParam>";
        public UnitTestHelper()
        {
            Init();
        }
        public string NodeUsername
        {
            get { return Settings.NodeUsername; }
        }
        public string NodePassword
        {
            get { return Settings.NodePassword; }
        }
        public string TestSubmitService
        {
            get { return Settings.TestSubmitService; }
        }
        public string TestFlowName
        {
            get { return Settings.TestFlowName; }
        }
        public string TestQueryService
        {
            get { return Settings.TestQueryService; }
        }
        public string TestExecuteService
        {
            get { return Settings.TestExecuteService; }
        }
        public string TestSolicitService
        {
            get { return Settings.TestSolicitService; }
        }
        protected void Init()
        {
            if (_client == null)
            {
                LogDebug("Enter Init()");

                EndpointVersionType endpointType = (EndpointVersionType)
                    Enum.Parse(typeof(EndpointVersionType),
                    Settings.NodeEndpointType);

                INodeEndpointClientFactory factory =
                    NodeEndpointClientProvider.CreateClientFactory(new AuthenticationCredentials(NodeUsername, NodePassword));

                LogDebug("ENClientFactory: " + factory);

                LogDebug("Creating node client helper: nodeUrl({0}), endpointType({1}), username({2}), password({3})",
                          Settings.NodeWebServiceUrl,
                          endpointType,
                          NodeUsername,
                          NodePassword);

                _client = factory.Make(Settings.NodeWebServiceUrl, endpointType);
                LogDebug("Exit Init()");
            }
        }
        public bool WaitForTransaction(string transactionId)
        {
            return WaitForTransaction(transactionId, TimeSpan.FromMinutes(1));
        }
        public bool WaitForTransaction(string transactionId, TimeSpan waitDuration)
        {
            CommonTransactionStatusCode status;
            long timeoutTicks = DateTime.Now.Ticks + waitDuration.Ticks;
            do
            {
                if (DateTime.Now.Ticks > timeoutTicks)
                {
                    if (Settings.ThrowTransactionWaitException)
                    {
                        throw new TimeoutException(string.Format("Timeout occurred waiting for transaction {0}",
                                                                 transactionId));
                    }
                    else
                    {
                        return false;
                    }
                }
                Thread.Sleep(1000);
                status = _client.GetStatus(transactionId);
                Assert.IsTrue(status != CommonTransactionStatusCode.Unknown);
            } while (!((status == CommonTransactionStatusCode.Processed) || (status == CommonTransactionStatusCode.Completed) ||
                       (status == CommonTransactionStatusCode.Failed) || (status == CommonTransactionStatusCode.Approved)));
            return true;
        }
        #region Private Helper Methods

        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                DisposableBase.SafeDispose(ref _client);
            }
        }

        public void LogDebug(string message)
        {
            Console.WriteLine(message);
        }
        public void LogDebug(string format, params object[] parameters)
        {
            Console.WriteLine(format, parameters);
        }
        public void LogDebugArguments(string message, params object[] parameters)
        {
            string result = string.Format(message, parameters);
            Console.WriteLine(result);
        }

        /// <summary>
        /// GetTempFilePath
        /// </summary>
        /// <returns></returns>
        public string GetTempFilePath(string extension)
        {
            if (!Directory.Exists(Settings.TestTempDir))
            {
                Directory.CreateDirectory(Settings.TestTempDir);
            }
            string path = Path.Combine(Settings.TestTempDir,
                                       Guid.NewGuid().ToString());
            if (!string.IsNullOrEmpty(extension))
            {
                path = Path.ChangeExtension(path, extension);
            }
            return path;
        }
        public string GetTempFilePath()
        {
            return GetTempFilePath(null);
        }
        public string GetTempZipFilePath()
        {
            return GetTempFilePath(".zip");
        }
        public string GetTempXmlFilePath()
        {
            return GetTempFilePath(".xml");
        }

        protected string CreateTempCompressedFile(string originalPath)
        {
            string path = GetTempZipFilePath();
            CompressionHelper.CompressFile(originalPath, path);
            return path;
        }
        public IList<string> GetTempXmlSmallFileList()
        {
            string path = GetTempXmlFilePath();
            byte[] bytes = CreateRandomXMLSubmitDocument(true);
            File.WriteAllBytes(path, bytes);
            return new string[] { path };
        }
        public IList<string> GetTempCompressedSmallFileList()
        {
            if (_tempCompressedSmallFileList == null)
            {
                string path = GetTempZipFilePath();
                byte[] bytes = CreateRandomXMLSubmitDocument(true);
                File.WriteAllBytes(path, bytes);
                _tempCompressedSmallFileList = new List<string>();
                _tempCompressedSmallFileList.Add(path);
            }
            else
            {
                string path = GetTempZipFilePath();
                File.Move(_tempCompressedSmallFileList[0], path);
                _tempCompressedSmallFileList[0] = path;
            }
            return _tempCompressedSmallFileList;
        }
        protected string GetTempCompressedFileLarge()
        {
            if (_tempCompressedFileLarge == null)
            {
                if (File.Exists(Settings.TestZipFileLarge))
                {
                    _tempCompressedFileLarge = Settings.TestZipFileLarge;
                }
                else
                {
                    _tempCompressedFileLarge = CreateTempCompressedFile(Settings.TestXmlFileLarge);
                }
            }
            return _tempCompressedFileLarge;
        }

        private static Node20TestConsole.Properties.Settings Settings
        {
            get { return Node20TestConsole.Properties.Settings.Default; }
        }

        protected byte[] CreateRandomXMLSubmitDocument(bool doCompress)
        {
            int actualCount;
            bool isLast;
            return CreateRandomXMLSubmitDocument(doCompress, 0, -1, out actualCount, out isLast);
        }
        protected byte[] CreateRandomXMLSubmitDocument(bool doCompress, int start, int count,
                                                     out int actualCount, out bool isLast)
        {
            string QUERY_XML_HEADER =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<hdr:Document xmlns:hdr=\"http://www.exchangenetwork.net/schema/v1.0/ExchangeNetworkDocument.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" Id=\"E626B418-2D09-4CCE-918C-BF72CF5D2044\">" +
                "<hdr:Header>" +
                "<hdr:Author>Windsor Solutions, Inc</hdr:Author>" +
                "<hdr:Organization>AR DEQ</hdr:Organization>" +
                "<hdr:Title>PointSource</hdr:Title>" +
                "<hdr:CreationTime>2008-05-21T10:01:01-05:00</hdr:CreationTime>" +
                "<hdr:Comment>NEI 2006 Point Submission</hdr:Comment>" +
                "<hdr:DataService>GetNEIPointDataByYear</hdr:DataService>" +
                "<hdr:ContactInfo>503.675.7833:207</hdr:ContactInfo>" +
                "<hdr:Sensitivity>Unclassified</hdr:Sensitivity>" +
                "<hdr:Property>" +
                "<hdr:name>GeographicCoverage</hdr:name>" +
                "<hdr:value>05</hdr:value>" +
                "</hdr:Property>" +
                "<hdr:Property>" +
                "<hdr:name>InventoryYear</hdr:name>" +
                "<hdr:value>2006</hdr:value>" +
                "</hdr:Property>" +
                "</hdr:Header>" +
                "<hdr:Payload Operation=\"Point|Original\">" +
                "<PointSourceSubmissionGroup xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://www.epa.gov/exchangenetwork\" xsi:schemaLocation=\"http://www.epa.gov/exchangenetwork EN_NEI_Point_v3_0.xsd\" schemaVersion=\"3.0\">" +
                "<SystemRecordCountValues schemaVersion=\"3.0\"><SystemRecordCountTransmittalValue>{0}</SystemRecordCountTransmittalValue><SystemRecordCountSiteValue>0</SystemRecordCountSiteValue><SystemRecordCountEmissionUnitValue>0</SystemRecordCountEmissionUnitValue><SystemRecordCountEmissionReleasePointValue>0</SystemRecordCountEmissionReleasePointValue><SystemRecordCountEmissionProcessValue>0</SystemRecordCountEmissionProcessValue><SystemRecordCountEmissionPeriodValue>0</SystemRecordCountEmissionPeriodValue><SystemRecordCountEmissionValue>0</SystemRecordCountEmissionValue><SystemRecordCountControlEquipmentValue>0</SystemRecordCountControlEquipmentValue></SystemRecordCountValues>";
            string QUERY_XML_BODY_ROW =
                "<TransmittalSubmissionGroup schemaVersion=\"3.0\"><TransmittalRecordTypeCode>TR</TransmittalRecordTypeCode><CountyStateFIPSCode>05001</CountyStateFIPSCode><OrganizationFormalName>Arkansas DEQ</OrganizationFormalName><TransactionTypeCode>00</TransactionTypeCode><InventoryYear>2006</InventoryYear><InventoryTypeCode>CRITHAP</InventoryTypeCode><TransactionCreationDate>20080430</TransactionCreationDate><SubmissionNumber>1</SubmissionNumber><IndividualFullName>Scot Stinson</IndividualFullName><TelephoneNumber>501-682-0538</TelephoneNumber><TelephoneNumberTypeName>Office</TelephoneNumberTypeName><ElectronicAddressText>stinson@adeq.state.ar.us</ElectronicAddressText><ElectronicAddressTypeName>Email</ElectronicAddressTypeName><SourceTypeCode>POINT</SourceTypeCode><AffiliationTypeText>Report Certifier</AffiliationTypeText><FormatVersionNumber>3.0</FormatVersionNumber><TribalCode>000</TribalCode></TransmittalSubmissionGroup>";
            string QUERY_XML_FOOTER =
                "</PointSourceSubmissionGroup>" +
                "</hdr:Payload>" +
                "</hdr:Document>";

            int randCount = new Random().Next(10, 600);

            if (count == -1)
            {
                if (start != 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Start");
                }
                actualCount = randCount;
                isLast = true;
            }
            else
            {
                if (start < 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Start");
                }
                if (count <= 0)
                {
                    throw new ArgumentException("Invalid Arguments", "Paging.Count");
                }
                actualCount = Math.Min(randCount, count);
                isLast = (randCount <= actualCount);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(QUERY_XML_HEADER, actualCount);
            for (int i = 0; i < actualCount; ++i)
            {
                sb.Append(QUERY_XML_BODY_ROW);
            }
            sb.Append(QUERY_XML_FOOTER);
            byte[] rtnArray = StringUtils.UTF8.GetBytes(sb.ToString()); ;
            if (doCompress)
            {
                rtnArray = CompressionHelper.Compress(Guid.NewGuid().ToString() + ".xml",
                                                      rtnArray);
            }
            return rtnArray;
        }
        protected ICompressionHelper CompressionHelper
        {
            get
            {
                if (_compressionHelper == null)
                {
                    _compressionHelper = new Windsor.Node2008.WNOSProviders.Implementation.CompressionHelper();
                }
                return _compressionHelper;
            }
        }
        #endregion // Private Helper Methods
    }
    [TestFixture]
    public class NCTUnitTests : DisposableBase
    {

        protected UnitTestHelper _unitTestHelper;
        public NCTUnitTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                DisposableBase.SafeDispose(ref _unitTestHelper);
            }
        }

        #region Tests

        /// <summary>
        /// NCT_TestCase13_NodePing
        /// </summary>
        [Test]
        public void NCT_TestCase13_NodePing()
        {
            try
            {
                // Test case #11
                _unitTestHelper.LogDebug("TestCase13_NodePing() enter");
                string pingResponse = _unitTestHelper._client.NodePing();
                _unitTestHelper.LogDebug("TestCase13_NodePing() exit: " + pingResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// TestCase1_Authenticating_A_User
        /// </summary>
        [Test]
        public void NCT_TestCase01_Authenticating_A_User()
        {
            _unitTestHelper.LogDebugArguments("TestCase01_Authenticating_A_User() enter", "_unitTestHelper.NodeUsername",
                              _unitTestHelper.NodeUsername, "_unitTestHelper.NodePassword", _unitTestHelper.NodePassword);

            string securityToken = _unitTestHelper._client.Authenticate(_unitTestHelper.NodeUsername,
                                                        _unitTestHelper.NodePassword);
            //try
            //{
            //    string securityToken2 = _unitTestHelper._client.Authenticate("runtime@ndep.nv.gov", "NVtunt1me05");  //??
            //}
            //catch (Exception)
            //{
            //}
            //try
            //{
            //    string securityToken3 = _unitTestHelper._client.Authenticate("node@ndep.nv.gov", "Nv20050428"); //??
            //}
            //catch (Exception)
            //{
            //}

            Assert.IsNotEmpty(securityToken);
            _unitTestHelper.LogDebugArguments("TestCase1_Authenticating_A_User() exit", "securityToken", securityToken);
        }

        /// <summary>
        /// TestCase1_Authenticating_A_User
        /// </summary>
        [Test]
        public void NCT_TestCase01_Authenticating_With_InvalidUser()
        {
            try
            {
                string securityToken = _unitTestHelper._client.Authenticate("Bogus username", "Bogus password");
                Assert.Fail("Authenticate should throw an exception");
            }
            catch (SoapException)
            {
            }
        }

        /// <summary>
        /// TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation
        /// </summary>
        [Test]
        public void NCT_TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation()
        {
            _unitTestHelper.LogDebugArguments("TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "Settings.TestOperationName", _unitTestHelper.TestSubmitService);

            string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                  _unitTestHelper.TestSubmitService,
                                                  string.Empty,
                                                  _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation() exit",
                              "transactionID", transactionID);
        }

        /// <summary>
        /// TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation
        /// </summary>
        [Test]
        public void NCT_TestCase02d_Submit_Xml_With_Valid_Dataflow_And_FlowOperation()
        {
            _unitTestHelper.LogDebugArguments("TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "Settings.TestOperationName", _unitTestHelper.TestSubmitService);

            string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                  _unitTestHelper.TestSubmitService,
                                                  string.Empty,
                                                  _unitTestHelper.GetTempXmlSmallFileList());
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase02_Submit_With_Valid_Dataflow_And_FlowOperation() exit",
                              "transactionID", transactionID);
        }
        /// <summary>
        /// TestCase15_Submit_With_NotificationURI_Email_Address()
        /// </summary>
        [Test]
        public void NCT_TestCase15_Submit_With_NotificationURI_Email_Address()
        {
            _unitTestHelper.LogDebugArguments("TestCase15_Submit_With_NotificationURI_Email_Address() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "Settings.TestOperationName", _unitTestHelper.TestSubmitService);

            string[] emailAddresses = new string[] { "baker@adeq.state.ar.us" };
//            string[] emailAddresses = new string[] { "tedsmorris@gmail.com" };

            string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                  _unitTestHelper.TestSubmitService,
                                                  string.Empty,
                                                  emailAddresses,
                                                  _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase15_Submit_With_NotificationURI_Email_Address() exit",
                              "transactionID", transactionID);
        }

        /// <summary>
        /// TestCase08_Submit_Additional_Document_For_Existing_Transaction
        /// </summary>
        [Test]
        public void NCT_TestCase08_Submit_Additional_Document_For_Existing_Transaction()
        {
            _unitTestHelper.LogDebugArguments("TestCase08_Submit_Additional_Document_For_Existing_Transaction() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "Settings.TestOperationName", _unitTestHelper.TestSubmitService);

            string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                  _unitTestHelper.TestSubmitService,
                                                  string.Empty,
                                                  _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsNotEmpty(transactionID);

            string transactionID2 = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                   _unitTestHelper.TestSubmitService,
                                                   transactionID,
                                                   _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsTrue(transactionID == transactionID2);
            _unitTestHelper.LogDebugArguments("TestCase08_Submit_Additional_Document_For_Existing_Transaction() exit",
                              "transactionID", transactionID);
        }

        /// <summary>
        /// TestCase02a_Submit_With_Valid_Dataflow_And_No_FlowOperation()
        /// </summary>
        [Test]
        public void NCT_TestCase02a_Submit_With_Valid_Dataflow_And_No_FlowOperation()
        {
            _unitTestHelper.LogDebugArguments("TestCase02a_Submit_With_Valid_Dataflow_And_No_FlowOperation() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

            string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                  string.Empty,
                                                  _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase02a_Submit_With_Valid_Dataflow_And_No_FlowOperation() exit",
                              "transactionID", transactionID);
        }

        /// <summary>
        /// TestCase02b_Submit_With_Invalid_FlowOperation()
        /// </summary>
        [Test]
        public void NCT_TestCase02b_Submit_With_Invalid_FlowOperation()
        {
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                // Flow operation is not supported at all
                _unitTestHelper.LogDebugArguments("TestCase02b_Submit_With_Invalid_FlowOperation() enter");

                string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                      "Bogus flow operation",
                                                      string.Empty,
                                                      _unitTestHelper.GetTempCompressedSmallFileList());
                Assert.IsNotEmpty(transactionID);

                _unitTestHelper.LogDebugArguments("TestCase02b_Submit_With_Invalid_FlowOperation() exit",
                                  "transactionID", transactionID);
            }
            else
            {
                try
                {
                    _unitTestHelper.LogDebugArguments("TestCase02b_Submit_With_Invalid_FlowOperation() enter");

                    string transactionID = _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName,
                                                          "Bogus flow operation",
                                                          string.Empty,
                                                          _unitTestHelper.GetTempCompressedSmallFileList());
                    Assert.IsNotEmpty(transactionID);

                    _unitTestHelper.LogDebugArguments("TestCase02b_Submit_With_Invalid_FlowOperation() exit",
                                      "transactionID", transactionID);

                    Assert.Fail("This should have thrown a SoapException");
                }
                catch (SoapException)
                {
                }
            }
        }

        /// <summary>
        /// TestCase02c_Submit_With_Invalid_Dataflow()
        /// </summary>
        [Test]
        public void NCT_TestCase02c_Submit_With_Invalid_Dataflow()
        {
            _unitTestHelper.LogDebugArguments("TestCase02c_Submit_With_Invalid_Dataflow() enter");

            try
            {
                string transactionID = _unitTestHelper._client.Submit("Bogus flow name",
                                                      _unitTestHelper.TestSubmitService,
                                                      string.Empty,
                                                      _unitTestHelper.GetTempCompressedSmallFileList());
                Assert.IsNotEmpty(transactionID);

                _unitTestHelper.LogDebugArguments("TestCase02c_Submit_With_Invalid_Dataflow() exit",
                                  "transactionID", transactionID);
                Assert.Fail("This should have thrown a SoapException");
            }
            catch (SoapException)
            {
            }
        }

        /// <summary>
        /// TestCase03_Query()
        /// </summary>
        [Test]
        public void NCT_TestCase03_Query()
        {
            _unitTestHelper.LogDebugArguments("TestCase03_Query() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestQueryService", _unitTestHelper.TestQueryService);

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "unzipped");
            }

            // Test case #3
            XmlDocument doc = _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                                            parameters);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 0, -1, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase03_Query() exit");
        }

        [Test]
        public void NCT_TestCase20_Execute()
        {
            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                return; // No Execute on 1.1
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringExecParameter", "unzippedExec");
            }

            string transactionID;
            XmlDocument doc = _unitTestHelper._client.Execute(_unitTestHelper.TestFlowName, _unitTestHelper.TestExecuteService,
                                              parameters, out transactionID);

            _unitTestHelper.LogDebugArguments("TestCase20_Execute() exit");
        }

        /// <summary>
        /// TestCase03a_Query_With_XML_Parameters()
        /// </summary>
        [Test]
        public void NCT_TestCase03a_Query_With_XML_Parameters()
        {
            _unitTestHelper.LogDebugArguments("TestCase03a_Query_With_XML_Parameters() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestQueryService", _unitTestHelper.TestQueryService);

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add(string.Format(UnitTestHelper.QUERY_XML_FORMAT_PARAM, "unzipped"));
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("xmlParameter", string.Format(UnitTestHelper.QUERY_XML_FORMAT_PARAM, "unzipped"));
            }

            XmlDocument doc = _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                                            parameters);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 0, -1, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase03a_Query_With_XML_Parameters() exit");
        }

        /// <summary>
        /// TestCase03b_Query_With_XML_Parameters_Zip()
        /// </summary>
        [Test]
        public void NCT_TestCase03b_Query_With_XML_Parameters_Zip()
        {
            _unitTestHelper.LogDebugArguments("TestCase03b_Query_With_XML_Parameters_Zip() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestQueryService", _unitTestHelper.TestQueryService);

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add(string.Format(UnitTestHelper.QUERY_XML_FORMAT_PARAM, "zipped"));
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("xmlParameter", string.Format(UnitTestHelper.QUERY_XML_FORMAT_PARAM, "zipped"));
            }
            XmlDocument doc = _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                                            parameters);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 0, -1, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase03b_Query_With_XML_Parameters_Zip() exit");
        }

        /// <summary>
        /// TestCase03c_Query_With_String_Parameter_Zip()
        /// </summary>
        [Test]
        public void NCT_TestCase03c_Query_With_String_Parameter_Zip()
        {
            _unitTestHelper.LogDebugArguments("TestCase03c_Query_With_String_Parameter_Zip() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestQueryService", _unitTestHelper.TestQueryService);

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "zipped");
            }

            XmlDocument doc = _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                                            parameters);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 0, -1, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase03c_Query_With_String_Parameter_Zip() exit");
        }

        /// <summary>
        /// TestCase17a_Query_With_Paging_String_Parameter_Zip()
        /// </summary>
        [Test]
        public void NCT_TestCase17a_Query_With_Paging_String_Parameter_Zip()
        {
            _unitTestHelper.LogDebugArguments("TestCase17a_Query_With_Paging_String_Parameter_Zip() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestQueryService", _unitTestHelper.TestQueryService);

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped"); // 1.1 does not support zipped
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "zipped");
            }

            XmlDocument doc = _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                                            parameters, 2, 8);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 2, 8, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase17a_Query_With_Paging_String_Parameter_Zip() exit");
        }

        /// <summary>
        /// TestCase04_Solicit()
        /// </summary>
        [Test]
        public void NCT_TestCase04_SolicitWithEmailNotification()
        {
            _unitTestHelper.LogDebugArguments("TestCase04_Solicit() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestSolicitService", _unitTestHelper.TestSolicitService);

            _unitTestHelper.LogDebug("TestSolicit() enter");

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "unzipped");
            }

            List<string> notificationUris = new List<string>();
            notificationUris.Add("ted_morris@windsorsolutions.com");

            // Test case #4, 14
            string transactionID = _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName,
                                                   _unitTestHelper.TestSolicitService,
                                                   parameters, notificationUris);
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase04_Solicit() exit");
        }

        /// <summary>
        /// TestCase04_Solicit()
        /// </summary>
        [Test]
        public void NCT_TestCase04_SolicitWithNodeNotification()
        {
            _unitTestHelper.LogDebugArguments("TestCase04_Solicit() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestSolicitService", _unitTestHelper.TestSolicitService);

            _unitTestHelper.LogDebug("TestSolicit() enter");

            ByIndexOrNameDictionary<string> parameters;
            List<string> notificationUris = new List<string>();
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped");
                notificationUris.Add("http://localhost:1208/ENService11.asmx");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "unzipped");
                notificationUris.Add("http://localhost:4609/ENService20.asmx");
            }

            // Test case #4, 14
            string transactionID = _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName,
                                                   _unitTestHelper.TestSolicitService,
                                                   parameters, notificationUris);
            Assert.IsNotEmpty(transactionID);

            _unitTestHelper.LogDebugArguments("TestCase04_Solicit() exit");
        }

        /// <summary>
        /// TestCase05_GetStatus()
        /// </summary>
        [Test]
        public void NCT_TestCase05_GetStatus()
        {
            _unitTestHelper.LogDebugArguments("TestCase05_GetStatus() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName,
                              "_unitTestHelper.TestSolicitService", _unitTestHelper.TestSolicitService);

            _unitTestHelper.LogDebug("TestSolicit() enter");

            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("unzipped");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("stringParameter", "unzipped");
            }

            // Test case #4, 14
            string transactionID = _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName,
                                                   _unitTestHelper.TestSolicitService,
                                                   parameters);
            Assert.IsNotEmpty(transactionID);

            CommonTransactionStatusCode status = _unitTestHelper._client.GetStatus(transactionID);
            Assert.IsTrue(status != CommonTransactionStatusCode.Unknown);

            _unitTestHelper.LogDebugArguments("TestCase05_GetStatus() exit");
        }

        /// <summary>
        /// TestCase05_GetStatus()
        /// </summary>
//        [Test]
        public void NCT_TestCase05_GetParticularStatus()
        {
            CommonTransactionStatusCode status = _unitTestHelper._client.GetStatus("_db8e0155-e38a-4172-a448-40b812c63cc0");
            Assert.IsTrue(status != CommonTransactionStatusCode.Unknown);

            _unitTestHelper.LogDebugArguments("TestCase05_GetStatus() exit");
        }

        /// <summary>
        /// TestCase05a_GetStatus_Invalid_Transaction_Id()
        /// </summary>
        [Test]
        [ExpectedException(typeof(SoapException))]
        public void NCT_TestCase05a_GetStatus_Invalid_Transaction_Id()
        {
            _unitTestHelper.LogDebugArguments("TestCase05a_GetStatus_Invalid_Transaction_Id() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

            _unitTestHelper.LogDebug("TestCase05a_GetStatus_Invalid_Transaction_Id() enter");

            CommonTransactionStatusCode status = _unitTestHelper._client.GetStatus("Bogus transaction id");
            Assert.IsTrue(status != CommonTransactionStatusCode.Unknown);

            _unitTestHelper.LogDebugArguments("TestCase05a_GetStatus_Invalid_Transaction_Id() exit");
        }

        /// <summary>
        /// TestCase06_Download_All_Documents()
        /// </summary>
        [Test]
        public void NCT_TestCase06_Download_All_Documents()
        {
            _unitTestHelper.LogDebugArguments("TestCase06_Download_All_Documents() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

            { // USE_SOLICIT_FOR_DOWNLOAD
                ByIndexOrNameDictionary<string> parameters;
                if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
                {
                    parameters = new ByIndexOrNameDictionary<string>(false);
                    parameters.Add("unzipped");
                }
                else
                {
                    parameters = new ByIndexOrNameDictionary<string>(true);
                    parameters.Add("stringParameter", "unzipped");
                }

                string transactionID =
                    _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSolicitService,
                                    parameters);
                Assert.IsNotEmpty(transactionID);
                if (_unitTestHelper.WaitForTransaction(transactionID))
                {

                    string[] fileSubmitPaths = _unitTestHelper._client.Download(_unitTestHelper.TestFlowName,
                                                                                transactionID);
                    Assert.IsTrue(fileSubmitPaths.Length > 0);
                }
            }
            { // !USE_SOLICIT_FOR_DOWNLOAD
                IList<string> fileList = _unitTestHelper.GetTempCompressedSmallFileList();

                string transactionID =
                    _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSubmitService,
                                   string.Empty, fileList);
                Assert.IsNotEmpty(transactionID);

                string[] fileSubmitPaths = _unitTestHelper._client.Download(_unitTestHelper.TestFlowName,
                                                                            transactionID);
                Assert.IsTrue(fileList.Count <= fileSubmitPaths.Length);
            }

            _unitTestHelper.LogDebugArguments("TestCase06_Download_All_Documents() exit");
        }

        /// <summary>
        /// TestCase07_Download_By_DocumentId()
        /// </summary>
        [Test]
        public void NCT_TestCase07_Download_By_DocumentId()
        {
            _unitTestHelper.LogDebugArguments("TestCase07_Download_By_DocumentId() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

            { // USE_SOLICIT_FOR_DOWNLOAD
                ByIndexOrNameDictionary<string> parameters;
                if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
                {
                    parameters = new ByIndexOrNameDictionary<string>(false);
                    parameters.Add("unzipped");
                }
                else
                {
                    parameters = new ByIndexOrNameDictionary<string>(true);
                    parameters.Add("stringParameter", "unzipped");
                }

                string transactionID =
                    _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSolicitService,
                                    parameters);
                Assert.IsNotEmpty(transactionID);
                if (_unitTestHelper.WaitForTransaction(transactionID))
                {
                    IList<string> documentIds;
                    string[] fileSubmitPaths =
                        _unitTestHelper._client.DownloadWithDocumentIds(_unitTestHelper.TestFlowName, transactionID,
                                                        out documentIds);
                    Assert.IsTrue(fileSubmitPaths.Length > 0);
                    if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
                    {
                        Assert.AreEqual(fileSubmitPaths.Length, documentIds.Count);

                        fileSubmitPaths =
                            _unitTestHelper._client.DownloadById(_unitTestHelper.TestFlowName, transactionID, documentIds[0]);
                        Assert.IsTrue(fileSubmitPaths.Length == 1);
                    }
                }
            }
            { // !USE_SOLICIT_FOR_DOWNLOAD
                IList<string> fileList = _unitTestHelper.GetTempCompressedSmallFileList();

                string transactionID =
                    _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSubmitService,
                                   string.Empty, fileList);

                Assert.IsNotEmpty(transactionID);
                IList<string> documentIds;
                string[] fileSubmitPaths =
                    _unitTestHelper._client.DownloadWithDocumentIds(_unitTestHelper.TestFlowName, transactionID,
                                                    out documentIds);
                Assert.IsTrue(fileList.Count <= fileSubmitPaths.Length);
                if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
                {
                    Assert.AreEqual(fileSubmitPaths.Length, documentIds.Count);

                    fileSubmitPaths =
                        _unitTestHelper._client.DownloadById(_unitTestHelper.TestFlowName, transactionID, documentIds[0]);
                    Assert.IsTrue(fileSubmitPaths.Length == 1);
                }
            }
            _unitTestHelper.LogDebugArguments("TestCase07_Download_By_DocumentId() exit");
        }

        /// <summary>
        /// TestCase07a_Download_By_DocumentName()
        /// </summary>
        [Test]
        public void NCT_TestCase07a_Download_By_DocumentName()
        {
            _unitTestHelper.LogDebugArguments("TestCase07a_Download_By_DocumentName() enter",
                              "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

            { // USE_SOLICIT_FOR_DOWNLOAD
                ByIndexOrNameDictionary<string> parameters;
                if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
                {
                    parameters = new ByIndexOrNameDictionary<string>(false);
                    parameters.Add("unzipped");
                }
                else
                {
                    parameters = new ByIndexOrNameDictionary<string>(true);
                    parameters.Add("stringParameter", "unzipped");
                }

                string transactionID =
                    _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSolicitService,
                                    parameters);
                Assert.IsNotEmpty(transactionID);
                if (_unitTestHelper.WaitForTransaction(transactionID))
                {
                    IList<string> documentNames;
                    string[] fileSubmitPaths =
                        _unitTestHelper._client.DownloadWithDocumentNames(_unitTestHelper.TestFlowName, transactionID,
                                                          out documentNames);
                    Assert.IsTrue(fileSubmitPaths.Length > 0);
                    if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
                    {
                        Assert.AreEqual(fileSubmitPaths.Length, documentNames.Count);

                        fileSubmitPaths =
                            _unitTestHelper._client.DownloadByName(_unitTestHelper.TestFlowName, transactionID, documentNames[0]);
                        Assert.IsTrue(fileSubmitPaths.Length == 1);
                    }
                }
            }
            { // !USE_SOLICIT_FOR_DOWNLOAD
                IList<string> fileList = _unitTestHelper.GetTempCompressedSmallFileList();

                string transactionID =
                    _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSubmitService,
                                   string.Empty, fileList);

                Assert.IsNotEmpty(transactionID);
                IList<string> documentNames;
                string[] fileSubmitPaths =
                    _unitTestHelper._client.DownloadWithDocumentNames(_unitTestHelper.TestFlowName, transactionID,
                                                      out documentNames);
                Assert.IsTrue(fileList.Count <= fileSubmitPaths.Length);
                if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
                {
                    Assert.AreEqual(fileSubmitPaths.Length, documentNames.Count);

                    fileSubmitPaths =
                        _unitTestHelper._client.DownloadByName(_unitTestHelper.TestFlowName, transactionID, documentNames[0]);
                    Assert.IsTrue(fileSubmitPaths.Length == 1);
                }
            }
            _unitTestHelper.LogDebugArguments("TestCase07a_Download_By_DocumentName() exit");
        }

        /// <summary>
        /// TestCase07b_Download_Invalid_Document_Name()
        /// </summary>
        [Test]
        public void NCT_TestCase07b_Download_Invalid_Document_Name()
        {
            if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
            {
                _unitTestHelper.LogDebugArguments("TestCase07b_Download_Invalid_Document_Name() enter",
                                  "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);
                try
                {

                    { // USE_SOLICIT_FOR_DOWNLOAD
                        ByIndexOrNameDictionary<string> parameters;
                        if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
                        {
                            parameters = new ByIndexOrNameDictionary<string>(false);
                            parameters.Add("unzipped");
                        }
                        else
                        {
                            parameters = new ByIndexOrNameDictionary<string>(true);
                            parameters.Add("stringParameter", "unzipped");
                        }

                        string transactionID =
                            _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSolicitService,
                                            parameters);
                        Assert.IsNotEmpty(transactionID);
                        if (_unitTestHelper.WaitForTransaction(transactionID))
                        {
                            string[] fileSubmitPaths =
                                _unitTestHelper._client.DownloadByName(_unitTestHelper.TestFlowName, transactionID, "Bogus file name");
                            Assert.IsTrue(fileSubmitPaths.Length == 1);
                            Assert.Fail("Should have thrown a SoapException");
                        }

                    }
                    { // !USE_SOLICIT_FOR_DOWNLOAD
                        IList<string> fileList = _unitTestHelper.GetTempCompressedSmallFileList();

                        string transactionID =
                            _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSubmitService,
                                           string.Empty, fileList);

                        Assert.IsNotEmpty(transactionID);
                        string[] fileSubmitPaths =
                           _unitTestHelper._client.DownloadByName(_unitTestHelper.TestFlowName, transactionID, "Bogus file name");
                        Assert.IsTrue(fileSubmitPaths.Length == 1);
                        Assert.Fail("Should have thrown a SoapException");
                    }
                }
                catch (SoapException)
                {
                }
                _unitTestHelper.LogDebugArguments("TestCase07b_Download_Invalid_Document_Name() exit");
            }
        }

        /// <summary>
        /// TestCase07b_Download_Invalid_Document_Id()
        /// </summary>
        [Test]
        public void NCT_TestCase07b_Download_Invalid_Document_Id()
        {
            if (_unitTestHelper._client.Version != EndpointVersionType.EN11)
            {
                _unitTestHelper.LogDebugArguments("TestCase07b_Download_Invalid_Document_Id() enter",
                                  "_unitTestHelper.TestFlowName", _unitTestHelper.TestFlowName);

                try
                {
                    { // USE_SOLICIT_FOR_DOWNLOAD
                        ByIndexOrNameDictionary<string> parameters;
                        if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
                        {
                            parameters = new ByIndexOrNameDictionary<string>(false);
                            parameters.Add("unzipped");
                        }
                        else
                        {
                            parameters = new ByIndexOrNameDictionary<string>(true);
                            parameters.Add("stringParameter", "unzipped");
                        }

                        string transactionID =
                            _unitTestHelper._client.Solicit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSolicitService,
                                            parameters);
                        Assert.IsNotEmpty(transactionID);
                        if (_unitTestHelper.WaitForTransaction(transactionID))
                        {
                            string[] fileSubmitPaths =
                                _unitTestHelper._client.DownloadById(_unitTestHelper.TestFlowName, transactionID, "Bogus file id");
                            Assert.IsTrue(fileSubmitPaths.Length == 1);

                            Assert.Fail("Should have thrown a SoapException");
                        }
                    }
                    { // !USE_SOLICIT_FOR_DOWNLOAD
                        IList<string> fileList = _unitTestHelper.GetTempCompressedSmallFileList();

                        string transactionID =
                            _unitTestHelper._client.Submit(_unitTestHelper.TestFlowName, _unitTestHelper.TestSubmitService,
                                           string.Empty, fileList);
                        Assert.IsNotEmpty(transactionID);
                        string[] fileSubmitPaths =
                            _unitTestHelper._client.DownloadById(_unitTestHelper.TestFlowName, transactionID, "Bogus file id");
                        Assert.IsTrue(fileSubmitPaths.Length == 1);

                        Assert.Fail("Should have thrown a SoapException");
                    }
                }
                catch (SoapException)
                {
                }
                _unitTestHelper.LogDebugArguments("TestCase07b_Download_Invalid_Document_Id() exit");
            }
        }

        /// <summary>
        /// TestCase9_GetServices()
        /// </summary>
        [Test]
        public void NCT_TestCase9_GetServices()
        {
            _unitTestHelper.LogDebugArguments("TestCase9_GetServices() enter");

            XmlDocument doc = _unitTestHelper._client.GetServices("AllServices");

            _unitTestHelper.LogDebugArguments("TestCase9_GetServices() exit");
        }
        /// <summary>
        /// TestCase03b_Query_With_XML_Parameters_Zip()
        /// </summary>
        [Test]
        public void NCT_TestCase_NotifyEvent()
        {
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
            }
            else
            {
                _unitTestHelper._client.NotifyEvent20(string.Empty, _unitTestHelper.TestFlowName, "Message Name",
                                                      CommonTransactionStatusCode.Completed, "Event Description",
                                                      "Event Name");
            }
        }
        //[Test]
        public void TryAuthenticationRequestDownload()
        {
            string[] paths =
                _unitTestHelper._client.DownloadByName("Flow-Security", "_81bea7aa-3441-42c4-92d0-a26125c34804", "AuthorizationResponse.zip");
        }

        /// <summary>
        /// TestCase9_GetServices()
        /// </summary>
        //[Test]
        public void TryAuthenticationRequest()
        {
            Windsor.HERE.CentralServer.Message.AuthorizationRequest request =
                new Windsor.HERE.CentralServer.Message.AuthorizationRequest();

            int randomInt = new Random((int) DateTime.Now.Ticks).Next();
            request.GeneratedOn = DateTime.Now;
            request.RequestType = "HERE data access request";
            request.NaasUsername = string.Format("ted{0}@windsorsolutions.com", randomInt.ToString());
            //request.NaasUsername = "ted@windsorsolutions.com";  //??
            request.FullName = string.Format("Ted{0} Morris", randomInt.ToString());
            request.OrganizationAffiliation = "Windsor Solutions, Inc.";
            request.TelephoneNumber = "503-544-1515";
            request.EmailAddress = request.NaasUsername;
            request.AffiliatedNodeId = "WA";
            request.AffiliatedCounty = "County";
            request.PurposeDescription = "I need node access!";
            request.RequestedDataSourceNames = new string[] { "here", "HERE-CAFO", "HERE_TIER2", "Bogus" };
//            request.RequestedDataSourceNames = new string[] { "Bogus" };
            request.RequestedNodeIds = new string[] { "WA", "NV", "ND" };

            SerializationUtils serializationUtils = new SerializationUtils();
            byte[] content = serializationUtils.Serialize(request);

            EndpointDocument document = new EndpointDocument(content, null, CommonContentType.XML);
            string transId = _unitTestHelper._client.Submit("Flow-Security", "AuthorizationRequest",
                                                            null, new EndpointDocument[] { document });
        }
        #endregion // Tests

        /// <summary>
        /// NCT_TestCaseFRS_QueryGetFacilityByName()
        /// </summary>
//        [Test]
        public void NCT_TestCaseFRS_QueryGetFacilityByName()
        {
            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("WA");
                parameters.Add("Gas");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("Param1", "WA");
                parameters.Add("Param2", "Gas");
            }

            // Test case #3
            XmlDocument doc = _unitTestHelper._client.Query("FRS", "GetFacilityByName",
                                                            parameters);

            string path = _unitTestHelper.GetTempFilePath();

            _unitTestHelper._client.Query(_unitTestHelper.TestFlowName, _unitTestHelper.TestQueryService,
                          parameters, 0, -1, _unitTestHelper.GetTempFilePath());

            _unitTestHelper.LogDebugArguments("TestCase03_Query() exit");
        }

        /// <summary>
        /// USGS_Submit()
        /// </summary>
//        [Test]
        public void USGS_Submit()
        {
            string transactionID =
                _unitTestHelper._client.Submit("NHDUpdate", "ProcessNHDDocument",
                                               string.Empty, _unitTestHelper.GetTempCompressedSmallFileList());
            Assert.IsNotEmpty(transactionID);
        }
//        [Test]
        public void USGS_Solicit()
        {
            ByIndexOrNameDictionary<string> parameters;
            if (_unitTestHelper._client.Version == EndpointVersionType.EN11)
            {
                parameters = new ByIndexOrNameDictionary<string>(false);
                parameters.Add("");
                parameters.Add("0");
                parameters.Add("10/01/2008");
            }
            else
            {
                parameters = new ByIndexOrNameDictionary<string>(true);
                parameters.Add("StateId", "ted@windsorsolutions.com");
                parameters.Add("DocumentCount", "1");
                parameters.Add("DocumentsNewerThan", "10/01/2008");
            }
            parameters = null;

            string transactionID =
                _unitTestHelper._client.Solicit("NHDUpdate", "GetNHDData", parameters, null);
            Assert.IsNotEmpty(transactionID);
        }
            #region Private Helper Methods
        #endregion // Private Helper Methods
    }
}
