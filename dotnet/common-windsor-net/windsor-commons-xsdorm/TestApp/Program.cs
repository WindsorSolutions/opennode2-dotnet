//#define ADD_BASE_DATA_TYPES
//#define USE_WINDSOR_XSDORM_CLASSES
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
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.P2R;
using System.Reflection;
using Spring.Data.Common;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.XsdOrm.Implementations;
using Windsor.Node2008.WNOSPlugin.FACID30;
using Windsor.Node2008.WNOSPlugin.HERE.TANKS10;
using Windsor.Node2008.WNOSPlugin.CERS_12;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Windsor.Node2008.WNOSPlugin.TRI4;
using Windsor.Node2008.WNOSPlugin.RCRA_52;

using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.CodeDom;
using System.CodeDom.Compiler;

using Microsoft.CSharp;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //FlattenSchema(@"C:\Projects\opennode2-net\plugins\RCRA_52\xml_schema\2\RCRA_HazardousWasteHandlerSubmission_v5.2.xsd",
            //              @"C:\Download\RCRA_HazardousWasteHandlerSubmission_v5.2.xsd");

            //XsdToClassTest();

            //SerializationUtils serializationUtils = new SerializationUtils();

            //ValidateXml(@"C:\WINDSOR\NetDMR\_8e0a41e5-2f0d-4537-95de-f32de26f4dad_Response.xml", @"C:\Projects\prod-opennode2-net\plugins\NetDMR_10\xml_schema\index.xsd",
            //            @"C:\DOWNLOAD\ValidationErrors.txt");

            //var data =
            //    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(@"C:\WINDSOR\NetDMR\_8e0a41e5-2f0d-4537-95de-f32de26f4dad_Response.xml");
            //foreach (var permitScheduledDMRs in data.PermitScheduledDMRs)
            //{
            //    if ( permitScheduledDMRs.
            //}

            //var data =
            //    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_51.HazardousWasteHandlerSubmissionDataType>(@"C:\WINDSOR\CO\Handler.xml");

            //Spring.Data.Common.IDbProvider dbProvider;
            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_UIC";
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_JMX";

            //Spring.Data.Common.IDbProvider dbProvider;
            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_PCS";

            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_PCS;Password=memorial;";
            //dbProvider.ConnectionString = @"Data Source=ORA11G;User Id=PARIS_IDEF;Password=memorial;";

            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_FACID_ORIG;Password=memorial;";

            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_WQX_NEW";
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_WQX;Password=memorial;";
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_FACID_NEW";
            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_CERS11_ORIG";
            //dbProvider =
            //   Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_CERS11_ORIG;Password=memorial;";

            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_ICISNPDES";
            //dbProvider =
            //   Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_ICISNPDES;Password=memorial;";

            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_RCRA_50";
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_EMTS_10";
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_WQX";
            //dbProvider =
            //   Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_RCRA_50;Password=memorial;";
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_RCRA_41_ORIG;Password=memorial;";

            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_BEACHES_21";
            //dbProvider =
            //   Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_BEACHES_21;Password=memorial;";

            //////Spring.Data.Common.IDbProvider
            //////dbProvider = Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //////dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_OWIRATT";

            //////SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //////IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();

            //////objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType),
            //////                                       springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.WOGCC_10.WellsDataType), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.YearCompletionIndicatorDataType), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.SubmissionHistoryDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.FacilitySubmissionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.HazardousWasteCMESubmissionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.HazardousWasteCorrectiveActionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.HazardousWastePermitDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.FinancialAssuranceSubmissionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_51.GeographicInformationSubmissionDataType), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_41.FacilitySubmissionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_41.HazardousWasteCMESubmissionDataType), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_15.SubmissionHistoryDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_15.Document), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.WQX2XsdOrm.WQXDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.WQX2XsdOrm.WQXDeleteDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.WQX2XsdOrm.WQXSubmissionDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType), springBaseDao);

            //objectsToDatabase.BuildDatabase(typeof(FacilityDetailsDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(CERSDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(WQXDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(FacilityDetailsDataType), springBaseDao);

            //string crypt = new SimpleCryptographyProvider().Encrypt("Password1234");
            //FixFileSourceCodeLineEndings(@"C:\PROJECTS\opennode2-net\plugins\HERE\CAFO11\Copy of CAFOTransform.cs");
            //FixSourceCodeLineEndings(@"C:\PROJECTS\OpenNode2 - google");


            //IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();

            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_UIC_ORIG";
            //dbProvider =
            //   Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_UIC_ORIG;Password=memorial;";
            //SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.UIC_10.UICDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization), springBaseDao);

            //DoFACID30();

            //DoUIC();

            //DoP2R();

            //DoTANKS();

            //DoRCRA();

            //DoCERS();

            //DoWQX();

            //DoWQX1();

            //DoICISNPDES();

            //DoEIS();

            //DoTRI();

            DoBEACHES();

            //DoEMTS();

            //DoPCSIDEFBill();

            //DoJMX();

            //DoPCSIDEF();

            //DoOWIRATT();

            //DoNetDMR();

            //DoEMTS2();

            //DoICISNPDES_3();

            //DoSDWISeDWR();

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
        class FlattenInsertInfo
        {
            public int StartIndex;
            public int EndIndex;
            public string ReplaceText;
        }
        static void FlattenSchema(string baseFilePath, string outputFilePath)
        {
            string saveCurrentDirectory = Directory.GetCurrentDirectory();
            try
            {
                string newCurrentDirectory = Path.GetDirectoryName(baseFilePath);
                Directory.SetCurrentDirectory(newCurrentDirectory);

                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(null, baseFilePath);

                schemaSet.Compile();

                string schema = schemaSet.ToString();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Directory.SetCurrentDirectory(saveCurrentDirectory);
            }
            //string newSchemaText = FlattenSchema(baseFilePath, false);
            //File.WriteAllText(outputFilePath, newSchemaText);
        }
        static string FlattenSchema(string baseFilePath, bool removeSchemaHeader)
        {
            string saveCurrentDirectory = Directory.GetCurrentDirectory();
            try
            {
                string newCurrentDirectory = Path.GetDirectoryName(baseFilePath);
                Directory.SetCurrentDirectory(newCurrentDirectory);
                const string includePrefix = "<xsd:include schemaLocation=\"";
                const string includeSuffix = "\"/>";
                string currentText = File.ReadAllText(baseFilePath);
                if (removeSchemaHeader)
                {
                    const string xmlPrefix = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
                    if (currentText.StartsWith(xmlPrefix))
                    {
                        currentText = currentText.Remove(0, xmlPrefix.Length);
                    }
                    const string schemaPrefix = "<xsd:schema ";
                    const string schemaSuffix = "</xsd:schema>";
                    int index = currentText.IndexOf(schemaPrefix);
                    if (index >= 0)
                    {
                        int endIndex = currentText.IndexOf(">", index + schemaPrefix.Length);
                        index = endIndex + 1;
                        currentText = currentText.Substring(index);
                        index = currentText.LastIndexOf(schemaSuffix);
                        currentText = currentText.Substring(0, index - 1);
                    }
                }
                if (currentText.Contains(includePrefix))
                {
                    List<FlattenInsertInfo> insertStrings = new List<FlattenInsertInfo>();
                    int curIndex = currentText.Length - 1;
                    for (; ; )
                    {
                        if (curIndex < 1)
                        {
                            break;
                        }
                        int index = currentText.LastIndexOf(includePrefix, curIndex);
                        if (index < 0)
                        {
                            break;
                        }
                        FlattenInsertInfo insertInfo = new FlattenInsertInfo();
                        insertInfo.StartIndex = index;
                        insertInfo.EndIndex = currentText.IndexOf(includeSuffix, insertInfo.StartIndex + 1);
                        if (insertInfo.EndIndex < 0)
                        {
                            DebugUtils.CheckDebuggerBreak();
                            throw new ArgumentException();
                        }
                        int fileNameIndex = insertInfo.StartIndex + includePrefix.Length;
                        string insertFileName = currentText.Substring(fileNameIndex, insertInfo.EndIndex - fileNameIndex);
                        insertInfo.EndIndex += includeSuffix.Length - 1;
                        string filePath = Path.GetFullPath(insertFileName);
                        insertInfo.ReplaceText = FlattenSchema(filePath, true);
                        insertStrings.Add(insertInfo);
                        curIndex = insertInfo.StartIndex - 1;
                    }
                    StringBuilder sb = new StringBuilder(currentText);
                    foreach (FlattenInsertInfo insertInfo in insertStrings)
                    {
                        sb.Remove(insertInfo.StartIndex, insertInfo.EndIndex - insertInfo.StartIndex + 1);
                        sb.Insert(insertInfo.StartIndex, insertInfo.ReplaceText);
                    }
                    currentText = sb.ToString();
                }
                return currentText;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Directory.SetCurrentDirectory(saveCurrentDirectory);
            }
        }
        static void FixSourceCodeLineEndings(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);
            foreach (string filePath in files)
            {
                FixFileSourceCodeLineEndings(filePath);
            }
        }
        static void FixFileSourceCodeLineEndings(string filePath)
        {
            byte[] sourceBytes = File.ReadAllBytes(filePath);
            if (sourceBytes.Length > 0)
            {
                List<byte> fixedBytes = new List<byte>((sourceBytes.Length * 4) / 3);
                bool fixedAny = false;
                for (int i = 0; i < sourceBytes.Length; ++i)
                {
                    if (sourceBytes[i] == 0x0A)
                    {
                        if ((i == 0) || (sourceBytes[i - 1] != 0x0D))
                        {
                            if (!fixedAny)
                            {
                                for (int j = 0; j < i; ++j)
                                {
                                    fixedBytes.Add(sourceBytes[j]);
                                }
                            }
                            fixedBytes.Add(0x0D);
                            fixedAny = true;
                        }
                    }
                    if (fixedAny)
                    {
                        fixedBytes.Add(sourceBytes[i]);
                    }
                }
                if (fixedAny)
                {
                    File.WriteAllBytes(filePath, fixedBytes.ToArray());
                }
            }
        }
        static void DoTANKS()
        {
            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_TANKS_ORIG";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(TanksSubmissionDataType), springBaseDao);
        }
        static void DoRCRA()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\RCRA_52\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\RCRA_52\docs");
            string[] sampleNamesCME = new string[]
            {
                "CME_example_file_v5.2_NoHeader.xml",
            };
            string[] sampleNamesHandler = new string[]
            {
                "Handler_example_file_v5.2_NoHeader.xml",
            };
            string[] sampleNamesCA = new string[]
            {
                "CorrectiveAction_example_file_v5.2_NoHeader.xml",
            };
            string[] sampleNamesFA = new string[]
            {
                "FinancialAssurance_example_file_v5.2_NoHeader.xml",
            };
            string[] sampleNamesGIS = new string[]
            {
                "GIS_example_file_v5.2_NoHeader.xml",
            };
            string[] sampleNamesPermit = new string[]
            {
                "Permitting_example_file_v5.2_NoHeader.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCMESubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                           samplesFolderPath, sampleNamesCME);
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteHandlerSubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                               samplesFolderPath, sampleNamesHandler);
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCorrectiveActionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                               samplesFolderPath, sampleNamesCA);
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWastePermitDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                               samplesFolderPath, sampleNamesPermit);
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.FinancialAssuranceSubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                               samplesFolderPath, sampleNamesFA);
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.RCRA_52.GeographicInformationSubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                               samplesFolderPath, sampleNamesGIS);

            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_RCRA";

            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_RCRA_51;Password=memorial;";

            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.SubmissionHistoryDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteHandlerSubmissionDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCMESubmissionDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCorrectiveActionDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWastePermitDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.FinancialAssuranceSubmissionDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.RCRA_52.GeographicInformationSubmissionDataType), springBaseDao);

            foreach (string fileName in sampleNamesCME)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCMESubmissionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCMESubmissionDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCMESubmissionDataType>(springBaseDao, null);
            }

            foreach (string fileName in sampleNamesHandler)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteHandlerSubmissionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteHandlerSubmissionDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteHandlerSubmissionDataType>(springBaseDao, null);
            }

            foreach (string fileName in sampleNamesCA)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCorrectiveActionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCorrectiveActionDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWasteCorrectiveActionDataType>(springBaseDao, null);
            }

            foreach (string fileName in sampleNamesPermit)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWastePermitDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWastePermitDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.HazardousWastePermitDataType>(springBaseDao, null);
            }

            foreach (string fileName in sampleNamesFA)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.FinancialAssuranceSubmissionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.FinancialAssuranceSubmissionDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.FinancialAssuranceSubmissionDataType>(springBaseDao, null);
            }

            foreach (string fileName in sampleNamesGIS)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.RCRA_52.GeographicInformationSubmissionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.RCRA_52.GeographicInformationSubmissionDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.RCRA_52.GeographicInformationSubmissionDataType>(springBaseDao, null);
            }
        }
        static void UnitTestSerialization<T>(string tempFolderPath, string rootSchemaFilePath,
                                             string readerNamespace, string samplesFolderPath,
                                             IList<string> sampleNames)
        {
            Directory.CreateDirectory(tempFolderPath);

            foreach (string sampleName in sampleNames)
            {
                string filePath = Path.Combine(samplesFolderPath, sampleName);

                T data = TestSerialization<T>(filePath, rootSchemaFilePath, readerNamespace, tempFolderPath);
            }
        }
        delegate void ProcessBeforeSaveToDatabaseCallback<T>(T data);
        static void UnitTestDatabase<T>(string dbProviderString, string dbConnectionString, string samplesFolderPath, IList<string> sampleNames)
        {
            UnitTestDatabase<T>(dbProviderString, dbConnectionString, samplesFolderPath, sampleNames, null);
        }
        static void UnitTestDatabase<T>(string dbProviderString, string dbConnectionString, string samplesFolderPath, IList<string> sampleNames,
                                        ProcessBeforeSaveToDatabaseCallback<T> callback)
        {
            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider(dbProviderString);
            dbProvider.ConnectionString = dbConnectionString;
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(T), springBaseDao);

            string tableName = objectsToDatabase.GetTableNameForType(typeof(T));
            string primaryKeyName = objectsToDatabase.GetPrimaryKeyNameForType(typeof(T));
            MemberInfo memberInfo = ReflectionUtils.FindFirstPublicPropertyOrFieldWithAttribute(typeof(T), typeof(PrimaryKeyAttribute));
            if (memberInfo == null)
            {
                throw new ArgumentException(string.Format("Could not find PrimaryKey field for object \"{0}\"",
                                                          typeof(T).FullName));
            }
            string whereQueryFormat = primaryKeyName + " = '{0}'";
            Dictionary<string, DbAppendSelectWhereClause> whereDict = new Dictionary<string, DbAppendSelectWhereClause>();
            whereDict[tableName] = new DbAppendSelectWhereClause();
            if (sampleNames != null)
            {
                foreach (string sampleName in sampleNames)
                {
                    string filePath = Path.Combine(samplesFolderPath, sampleName);

                    T data = new SerializationUtils().Deserialize<T>(filePath);

                    if (callback != null)
                    {
                        callback(data);
                    }

                    Dictionary<string, int> counts = objectsToDatabase.SaveToDatabase(data, springBaseDao);

                    object primaryKeyValue = (memberInfo is FieldInfo) ? ((FieldInfo)memberInfo).GetValue(data) :
                                                                         ((PropertyInfo)memberInfo).GetValue(data, null);

                    whereDict[tableName].SelectWhereQuery = string.Format(whereQueryFormat, primaryKeyValue.ToString());
                    List<T> list = objectsFromDatabase.LoadFromDatabase<T>(springBaseDao, whereDict);

                    if (CollectionUtils.IsNullOrEmpty(list) || (list.Count != 1))
                    {
                        throw new ArgumentException("objectsFromDatabase.LoadFromDatabase() failed");
                    }
                }
            }
        }
        static void UnitTestDatabase2<T>(string dbProviderString, string dbConnectionString, string samplesFolderPath, IList<string> sampleNames,
                                         Type mappingAttributesType)
        {
            UnitTestDatabase2<T>(dbProviderString, dbConnectionString, samplesFolderPath, sampleNames, mappingAttributesType, null);
        }
        static void UnitTestDatabase2<T>(string dbProviderString, string dbConnectionString, string samplesFolderPath, IList<string> sampleNames,
                                         Type mappingAttributesType, ProcessBeforeSaveToDatabaseCallback<T> callback)
        {
            Windsor.Commons.XsdOrm2.IObjectsToDatabase objectsToDatabase = new Windsor.Commons.XsdOrm2.Implementations.ObjectsToDatabase();
            Windsor.Commons.XsdOrm2.IObjectsFromDatabase objectsFromDatabase = new Windsor.Commons.XsdOrm2.Implementations.ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider(dbProviderString);
            dbProvider.ConnectionString = dbConnectionString;
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //objectsToDatabase.BuildDatabase(typeof(T), springBaseDao);

            //string tableName = objectsToDatabase.GetTableNameForType(typeof(T));
            //string primaryKeyName = objectsToDatabase.GetPrimaryKeyNameForType(typeof(T));
            //MemberInfo memberInfo = ReflectionUtils.FindFirstPublicPropertyOrFieldWithAttribute(typeof(T), typeof(PrimaryKeyAttribute));
            //if (memberInfo == null)
            //{
            //    throw new ArgumentException(string.Format("Could not find PrimaryKey field for object \"{0}\"",
            //                                              typeof(T).FullName));
            //}
            //string whereQueryFormat = primaryKeyName + " = '{0}'";
            //Dictionary<string, DbAppendSelectWhereClause> whereDict = new Dictionary<string, DbAppendSelectWhereClause>();
            //whereDict[tableName] = new DbAppendSelectWhereClause();
            if (sampleNames != null)
            {
                foreach (string sampleName in sampleNames)
                {
                    string filePath = Path.Combine(samplesFolderPath, sampleName);

                    T data = new SerializationUtils().Deserialize<T>(filePath);

                    if (callback != null)
                    {
                        callback(data);
                    }

                    Dictionary<string, int> counts = objectsToDatabase.SaveToDatabase(data, springBaseDao, mappingAttributesType);

                    //object primaryKeyValue = (memberInfo is FieldInfo) ? ((FieldInfo)memberInfo).GetValue(data) :
                    //                                                     ((PropertyInfo)memberInfo).GetValue(data, null);

                    //whereDict[tableName].SelectWhereQuery = string.Format(whereQueryFormat, primaryKeyValue.ToString());
                    //List<T> list = objectsFromDatabase.LoadFromDatabase<T>(springBaseDao, whereDict);

                    //if (CollectionUtils.IsNullOrEmpty(list) || (list.Count != 1))
                    //{
                    //    throw new ArgumentException("objectsFromDatabase.LoadFromDatabase() failed");
                    //}
                }
            }
        }
        //static void DoBEACHES()
        //{
        //    string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
        //    string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\BEACHES_21\xml_schema\index.xsd");
        //    string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\BEACHES_21\docs");
        //    string[] sampleNames = new string[]
        //    {
        //        "Beach_ExampleXMLFile_v2.1.xml",
        //        "GetBeachesData_v2.1_NY_67361393-A449-4043-839A-329A047DC57F.xml",
        //        "MI_Notification_20090122c.xml",
        //        "OH_Notification_20090128.xml",
        //        "682b3f25-688d-4529-928f-d7af966200d1.xml",
        //    };

        //    UnitTestSerialization<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
        //                                                                                              samplesFolderPath, sampleNames);
        //    IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
        //    IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

        //    Spring.Data.Common.IDbProvider dbProvider =
        //        Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
        //    dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_BEACHES_21";
        //    //dbProvider =
        //    //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
        //    //Spring.Data.Common.DbProviderFactory.GetDbProvider("Oracle.DataAccess.Client");
        //    //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_BEACHES_21;Password=memorial;";
        //    SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

        //    objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType), springBaseDao);
        //    objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType), springBaseDao);
        //    objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType), springBaseDao);
        //    objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_21.YearCompletionIndicatorDataType), springBaseDao);

        //    SerializationUtils serializationUtils = new SerializationUtils();
        //    foreach (string fileName in sampleNames)
        //    {
        //        string xmlPath = Path.Combine(samplesFolderPath, fileName);
        //        Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType data =
        //            serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType>(xmlPath);

        //        springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_YEARCOMPLETION");
        //        springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_PROCEDURE");
        //        springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_BEACH");
        //        springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_ORGANIZATION");

        //        data.BeforeSaveToDatabase();
        //        CollectionUtils.ForEach(data.OrganizationDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType organizationDetailDataType)
        //        {
        //            objectsToDatabase.SaveToDatabase(organizationDetailDataType, springBaseDao);
        //        });
        //        CollectionUtils.ForEach(data.BeachDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType beachDetail)
        //        {
        //            objectsToDatabase.SaveToDatabase(beachDetail, springBaseDao);
        //        });
        //        CollectionUtils.ForEach(data.BeachProcedureDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType beachProcedureDetail)
        //        {
        //            objectsToDatabase.SaveToDatabase(beachProcedureDetail, springBaseDao);
        //        });
        //        if (data.YearCompletionIndicators != null)
        //        {
        //            objectsToDatabase.SaveToDatabase(data.YearCompletionIndicators, springBaseDao);
        //        }

        //        Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType data2 = new Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDataSubmissionDataType();
        //        List<Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType> organizationDetails =
        //            objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_21.OrganizationDetailDataType>(springBaseDao, null);
        //        List<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType> beachDetails =
        //            objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachDetailDataType>(springBaseDao, null);
        //        List<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType> beachProcedureDetails =
        //            objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_21.BeachProcedureDetailDataType>(springBaseDao, null);
        //        List<Windsor.Node2008.WNOSPlugin.BEACHES_21.YearCompletionIndicatorDataType> yearCompletionIndicators =
        //            objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_21.YearCompletionIndicatorDataType>(springBaseDao, null);
        //        data2.YearCompletionIndicators = CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) ? null : yearCompletionIndicators[0];
        //        data2.BeachDetail = CollectionUtils.IsNullOrEmpty(beachDetails) ? null : beachDetails.ToArray();
        //        data2.BeachProcedureDetail = CollectionUtils.IsNullOrEmpty(beachProcedureDetails) ? null : beachProcedureDetails.ToArray();
        //        data2.OrganizationDetail = CollectionUtils.IsNullOrEmpty(organizationDetails) ? null : organizationDetails.ToArray();
        //        data2.AfterLoadFromDatabase();

        //        string savePath = Path.Combine(tempFolderPath, Path.GetFileName(FileUtils.AppendToFileName(xmlPath, "_out")));
        //        serializationUtils.Serialize(data2, savePath);

        //        ValidateXml(savePath, rootSchemaFilePath);
        //    }
        //}
        static void DoBEACHES()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\BEACHES_22\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\BEACHES_22\docs");
            string[] sampleNames = new string[]
            {
                "Beach_ExampleXMLFile_v2.1.xml",
                "GetBeachesData_v2.1_NY_67361393-A449-4043-839A-329A047DC57F.xml",
                "MI_Notification_20090122c.xml",
                "OH_Notification_20090128.xml",
                "682b3f25-688d-4529-928f-d7af966200d1.xml",
                "BeachNotification_ExampleXMLFile_v2.2.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDataSubmissionDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                      samplesFolderPath, sampleNames);
            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_BEACHES_22";
            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //Spring.Data.Common.DbProviderFactory.GetDbProvider("Oracle.DataAccess.Client");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_BEACHES_21;Password=memorial;";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_22.OrganizationDetailDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDetailDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachProcedureDetailDataType), springBaseDao);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.BEACHES_22.YearCompletionIndicatorDataType), springBaseDao);

            SerializationUtils serializationUtils = new SerializationUtils();
            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDataSubmissionDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDataSubmissionDataType>(xmlPath);

                springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_YEARCOMPLETION");
                springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_PROCEDURE");
                springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_BEACH");
                springBaseDao.AdoTemplate.ExecuteNonQuery(CommandType.Text, "DELETE FROM NOTIF_ORGANIZATION");

                data.BeforeSaveToDatabase();
                CollectionUtils.ForEach(data.OrganizationDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_22.OrganizationDetailDataType organizationDetailDataType)
                {
                    objectsToDatabase.SaveToDatabase(organizationDetailDataType, springBaseDao);
                });
                CollectionUtils.ForEach(data.BeachDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDetailDataType beachDetail)
                {
                    objectsToDatabase.SaveToDatabase(beachDetail, springBaseDao);
                });
                CollectionUtils.ForEach(data.BeachProcedureDetail, delegate(Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachProcedureDetailDataType beachProcedureDetail)
                {
                    objectsToDatabase.SaveToDatabase(beachProcedureDetail, springBaseDao);
                });
                if (data.YearCompletionIndicators != null)
                {
                    objectsToDatabase.SaveToDatabase(data.YearCompletionIndicators, springBaseDao);
                }

                Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDataSubmissionDataType data2 = new Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDataSubmissionDataType();
                List<Windsor.Node2008.WNOSPlugin.BEACHES_22.OrganizationDetailDataType> organizationDetails =
                    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_22.OrganizationDetailDataType>(springBaseDao, null);
                List<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDetailDataType> beachDetails =
                    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachDetailDataType>(springBaseDao, null);
                List<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachProcedureDetailDataType> beachProcedureDetails =
                    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_22.BeachProcedureDetailDataType>(springBaseDao, null);
                List<Windsor.Node2008.WNOSPlugin.BEACHES_22.YearCompletionIndicatorDataType> yearCompletionIndicators =
                    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.BEACHES_22.YearCompletionIndicatorDataType>(springBaseDao, null);
                data2.YearCompletionIndicators = CollectionUtils.IsNullOrEmpty(yearCompletionIndicators) ? null : yearCompletionIndicators[0];
                data2.BeachDetail = CollectionUtils.IsNullOrEmpty(beachDetails) ? null : beachDetails.ToArray();
                data2.BeachProcedureDetail = CollectionUtils.IsNullOrEmpty(beachProcedureDetails) ? null : beachProcedureDetails.ToArray();
                data2.OrganizationDetail = CollectionUtils.IsNullOrEmpty(organizationDetails) ? null : organizationDetails.ToArray();
                data2.AfterLoadFromDatabase();

                string savePath = Path.Combine(tempFolderPath, Path.GetFileName(FileUtils.AppendToFileName(xmlPath, "_out")));
                serializationUtils.Serialize(data2, savePath);

                ValidateXml(savePath, rootSchemaFilePath);
            }
        }
        static void DoEIS()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\CERS_12\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\EIS_11\docs");
            string[] sampleNames = new string[]
            {
                "Architectural Coating Examples.xml",
                "Drycleaner Example.xml",
                "EGU Facility Emissions Example.xml",
                "EGU Facility Example.xml",
                "Landfill Emissions Example.xml",
                "Landfill Example.xml",
                "TCR Example.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.CERS_12.CERSDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();
            Windsor.Node2008.WNOSPlugin.CERS_12.DataCategory[] categories =
                (Windsor.Node2008.WNOSPlugin.CERS_12.DataCategory[])Enum.GetValues(typeof(Windsor.Node2008.WNOSPlugin.CERS_12.DataCategory));

            int categoryIndex = 0;

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_CERS11_ORIG";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.CERS_12.CERSDataType), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.CERS_12.CERSDataType data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.CERS_12.CERSDataType>(xmlPath);
                if (categoryIndex >= categories.Length)
                {
                    categoryIndex = 0;
                }
                data.DataCategory = categories[categoryIndex++];
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
        }

        static void DoPCSIDEFBill()
        {
            SerializationUtils serializationUtils = new SerializationUtils();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider;
            dbProvider = Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            dbProvider.ConnectionString = @"data source= (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = ORA11G)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)  (SID = orcl)));user id=PARIS_IDEF; password=memorial;";

            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            string tempPath = @"C:\DOWNLOAD\TEST_XSD_ORM";

            //build WHERE clause for submissions to build
            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();
            selectClauses.Add("NULLBLOB",
                new DbAppendSelectWhereClause(springBaseDao, "SUBM_FILE IS NULL"));

            //get the submissions to build
            List<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission>(springBaseDao, selectClauses);

            foreach (Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission item in list)
            {
                string name;
                string path;
                byte[] serializedXml;

                switch (item.Header_Data.Report_Type)
                {
                    case "PA1": //PermitFacility
                        if (item.Permit_Facility_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Permit_Facility_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Permit_Facility_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Permit_Facility_Data = item.Permit_Facility_Data;
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "PE1": //PermitTracking
                        if (item.Permit_Tracking_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Permit_Tracking_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Permit_Tracking_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Permit_Tracking_Data = item.Permit_Tracking_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "PF1": //PermitReissuance
                        if (item.Reissuance_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Reissuance_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Reissuance_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Reissuance_Data = item.Reissuance_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "PS1": //PipeSchedule
                        if (item.Pipe_Schedule_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Pipe_Schedule_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Pipe_Schedule_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Pipe_Schedule_Data = item.Pipe_Schedule_Data;
                            serializationUtils.Serialize(data, path);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "PL1": //ParameterLimit
                        if (item.Parameter_Limits_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Parameter_Limits_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Parameter_Limits_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Parameter_Limits_Data = item.Parameter_Limits_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "CS1": //ComplianceSchedule
                        if (item.Compliance_Schedule_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Compliance_Schedule_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Compliance_Schedule_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Compliance_Schedule_Data = item.Compliance_Schedule_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "CV1": //ComplianceScheduleViolation
                        if (item.Compliance_Schedule_Violation_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Compliance_Schedule_Violation_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Compliance_Schedule_Violation_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Compliance_Schedule_Violation_Data = item.Compliance_Schedule_Violation_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "SV1": //SingleEventViolation
                        if (item.Single_Event_Violation_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Single_Event_Violation_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Single_Event_Violation_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Single_Event_Violation_Data = item.Single_Event_Violation_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "EA1": //EnforcementAction
                        if (item.Enforcement_Action_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Enforcement_Action_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Enforcement_Action_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Enforcement_Action_Data = item.Enforcement_Action_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "EK1": //EnforcementActionViolationKey
                        if (item.Enforcement_Action_Violation_Key_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Enforcement_Action_Violation_Key_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Enforcement_Action_Violation_Key_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Enforcement_Action_Violation_Key_Data = item.Enforcement_Action_Violation_Key_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "IN1": //Inspection
                        if (item.Inspection_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Inspection_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Inspection_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Inspection_Data = item.Inspection_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "MV1": //MeasurementVilation
                        if (item.Measurement_Violation_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Measurement_Violation_Data = item.Measurement_Violation_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    case "SP1": //Pretreatment Performance Summary
                        if (item.Pretreatment_Performance_Summary_Data != null)
                        {
                            name = item.Header_Data.Batch_Identification + "_" + item.Header_Data.Report_Type + "_" + item._PK + ".xml";
                            path = Path.Combine(tempPath, name);

                            Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Pretreatment_Performance_Summary_Submission data =
                                new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Pretreatment_Performance_Summary_Submission();
                            data.Header_Data = item.Header_Data;
                            data.Pretreatment_Performance_Summary_Data = item.Pretreatment_Performance_Summary_Data;
                            //serializationUtils.Serialize(data, path);
                            serializedXml = serializationUtils.Serialize(data);
                            springBaseDao.DoSimpleUpdateOne("PCS_SUBM", "SUBM_ID", item._PK, "SUBM_FILE", serializedXml);
                        }
                        else
                        {
                            Console.WriteLine(string.Format("{0} submission {1} has no data", item.Header_Data.Report_Type, item._PK));
                        }
                        break;
                    default:
                        throw new Exception("Report Type " + item.Header_Data.Report_Type + " not found");
                }


            }
        }

        static void DoPCSIDEF()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\PCS_IDEF\xml_schema\IDEF.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\PCS_IDEF\docs");

            string[] mvFiles = new string[] { @"C:\Projects\opennode2-net\plugins\PCS_IDEF\docs\MN_MV_6586.XML" };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                            samplesFolderPath, mvFiles);

            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider;
            dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");

            dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_PCS";

            //Spring.Data.Common.IDbProvider dbProvider;
            //dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");

            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_PCS;Password=memorial";

            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission), springBaseDao);

            foreach (string fileName in mvFiles)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission>(xmlPath);
                Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission submission = new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission();
                submission.Header_Data = data.Header_Data;
                submission.Measurement_Violation_Data = data.Measurement_Violation_Data;
                submission.SubmissionType = "Type";
                submission.CreatedDate = DateTime.Now;
                objectsToDatabase.SaveToDatabase(submission, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission>(springBaseDao, null);

            List<string> mvSavedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Submission item in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                if (item.Measurement_Violation_Data != null)
                {
                    Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission data =
                        new Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission();
                    data.Header_Data = item.Header_Data;
                    data.Measurement_Violation_Data = item.Measurement_Violation_Data;
                    serializationUtils.Serialize(data, path);
                    mvSavedFiles.Add(name);
                }
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.PCS_IDEF_10.Measurement_Violation_Submission>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                            tempFolderPath, mvSavedFiles);
        }
        static void DoJMX()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\JMX_10\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\JMX_10\docs");
            string[] sampleNames = new string[]
            {
                "JMX v1.0 XML Sample Instance Document Final v1.4.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.JMX_10.JMX>(tempFolderPath, rootSchemaFilePath, null,
                                                                          samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_JMX";
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=JMX_CLIENT_DATABASE";
            //dbProvider.ConnectionString = @"Data Source=SQLDEV;Initial Catalog=NODE_FLOW_JMX;User=tmorris;Password=Password!";
            dbProvider.ConnectionString = @"server=(local);integrated security=true;database=JMX_QUERY_DATABASE";
            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_JMX;Password=memorial;";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase(springBaseDao);
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            //Dictionary<string, DbAppendSelectWhereClause> whereClause = new Dictionary<string, DbAppendSelectWhereClause>();

            //whereClause.Add("JMX_ORGANIZATION", new DbAppendSelectWhereClause(springBaseDao, "ORGANIZATION_IDENTIFIER = ?", "PGSTNATR_JMX"));
            //List<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization> list2 =
            //    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization>(springBaseDao, whereClause);

            //List<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization> list2 =
            //    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization>(springBaseDao, null);

            //List<Windsor.Node2008.WNOSPlugin.JMX_10.JMXLutWaterbodyType> list3 =
            //    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.JMX_10.JMXLutWaterbodyType>(springBaseDao, null);

            //if (!CollectionUtils.IsNullOrEmpty(list2))
            //{
            //    for (int i = 0; i < Math.Min(8, list2.Count); ++i)
            //    {
            //        Windsor.Node2008.WNOSPlugin.JMX_10.JMX data = new Windsor.Node2008.WNOSPlugin.JMX_10.JMX();
            //        data.Organization = new Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization[] { list2[i] };
            //        serializationUtils.Serialize(data, string.Format(@"C:\Download\JmxSample{0}.xml", (i + 1).ToString()));
            //    }
            //}


            Windsor.Node2008.WNOSPlugin.JMX_10.JmxHelper.AddLutsToDatabase(objectsToDatabase, springBaseDao);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization), springBaseDao);

            Windsor.Node2008.WNOSPlugin.JMX_10.JmxHelper.AddMetadataToDatabase(objectsToDatabase);

            //Windsor.Node2008.WNOSPlugin.JMX_10.Helper.AddAppTablesToDatabase(objectsToDatabase);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.JMX_10.JMX data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.JMX_10.JMX>(xmlPath);
                objectsToDatabase.DeleteAllFromDatabase(data.Organization[0].GetType(), springBaseDao);
                objectsToDatabase.SaveToDatabase(data.Organization[0], springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization org in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                Windsor.Node2008.WNOSPlugin.JMX_10.JMX data = new Windsor.Node2008.WNOSPlugin.JMX_10.JMX();
                data.Organization = new Windsor.Node2008.WNOSPlugin.JMX_10.JMXOrganization[] { org };
                serializationUtils.Serialize(data, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.JMX_10.JMX>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    tempFolderPath, savedFiles);
        }
        static void DoOWIRATT()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\OWIR_ATT_20\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\OWIR_ATT_20\docs");
            string[] sampleNames = new string[]
            {
                "ATT_Sample_XML_v2.0_NoHeader.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                          samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            Spring.Data.Common.IDbProvider dbProvider =
                //Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
                //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_OWIRATT;Password=memorial;";
                //Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_OWIRATT_NEW";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase(springBaseDao);
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType>(xmlPath);
                objectsToDatabase.DeleteAllFromDatabase(data.GetType(), springBaseDao);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType data in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                serializationUtils.Serialize(data, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.OWIR_ATT_20.StateAssessmentDetailsDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                   tempFolderPath, savedFiles);
        }
        static void DoNetDMR()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\NetDMR_10\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\NetDMR_10\docs");
            string[] sampleNames = new string[]
            {
                "Example_GetScheduledDMRsByX_Result.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                   samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            //try
            //{
            //    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(
            //        //@"C:\WINDSOR\CalEPA\6f786d24-aa53-4e26-8d52-92b6e453adb3_Valid.tmp"
            //        @"C:\WINDSOR\CalEPA\6f786d24-aa53-4e26-8d52-92b6e453adb3_Invalid.tmp"
            //        );
            //}
            //catch (Exception)
            //{
            //}

            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_DMR;Password=memorial;";
            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_DMR4";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase(springBaseDao);
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(xmlPath);
                objectsToDatabase.DeleteAllFromDatabase(data.GetType(), springBaseDao);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType data in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                serializationUtils.Serialize(data, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.NetDMR_10.PermitsScheduledDMRsDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                                   tempFolderPath, savedFiles);
        }
        static void DoEMTS()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\EMTS\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\EMTS\docs");
            string[] sampleNames = new string[]
            {
                "Sample_Generate_No_Header.xml",
                "Example_XML_File_Mulitple_Transactions_No_Header.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_EMTS_10";
            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=OPENNODE2_EMTS10;Password=memorial;";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType item in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                serializationUtils.Serialize(item, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.EMTS_10.EMTSDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    tempFolderPath, savedFiles);
        }
        static void DoSDWISeDWRXml()
        {
            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=SQLDEV;User=tmorris;Password=Password!;database=HI_SDWIS_EDWR";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.SDWIS_Sampling_20.eDWR), springBaseDao);

            List<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR> list2 =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR>(springBaseDao, null);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("EN", "urn:us:net:exchangenetwork");
            serializationUtils.SerializerNamespaces = ns;
            serializationUtils.Serialize(list2[1], @"C:\Download\EDWR_TEST.xml");
            //serializationUtils.ToLiteXml(list2[1], @"C:\Download\EDWR_TEST.xml");
        }
        static void DoSDWISeDWR()
        {
            DoSDWISeDWRXml();

            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\SDWIS_Sampling_20\xml_schema\2\SDWIS_eDWR_v2.0.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\SDWIS_Sampling_20\docs");
            string[] sampleNames = new string[]
            {
                "SamplesAndResults_ThisOne.xml",
            };

            //UnitTestSerialization<Windsor.Node2008.WNOSPlugin.SDWIS_Sampling_20.eDWR>(tempFolderPath, rootSchemaFilePath, null,
            //                                                                          samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_SDWIS_20_2";
            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_SDWIS_20;Password=memorial;";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.SDWIS_Sampling_20.eDWR), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR item in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                serializationUtils.Serialize(item, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.SDWIS_eDWR_20.eDWR>(tempFolderPath, rootSchemaFilePath, null,
                                                                                  tempFolderPath, savedFiles);
        }
        static void DoEMTS2()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\EMTS_20\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\EMTS_20\docs");
            string[] sampleNames = new string[]
            {
                "Example_XML_File_Mulitple_Transactions_2.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    samplesFolderPath, sampleNames);

            SerializationUtils serializationUtils = new SerializationUtils();

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_EMTS_20_2";
            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_EMTS_20;Password=memorial;";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType), springBaseDao);

            foreach (string fileName in sampleNames)
            {
                string xmlPath = Path.Combine(samplesFolderPath, fileName);
                Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType>(xmlPath);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);
            }
            List<Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType>(springBaseDao, null);

            List<string> savedFiles = new List<string>();
            foreach (Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType item in list)
            {
                string name = Guid.NewGuid().ToString() + ".xml";
                string path = Path.Combine(tempFolderPath, name);
                serializationUtils.Serialize(item, path);
                savedFiles.Add(name);
            }
            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.EMTS_20.EMTSDataType>(tempFolderPath, rootSchemaFilePath, null,
                                                                                    tempFolderPath, savedFiles);
        }
        static void DoTRI()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\TRI_40\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\TRI_40\docs");
            string[] sampleNames = new string[]
            {
                "TRI_ExampleInstanceDocument_v4.0.xml",
                "CDX_NODE_TRI_GetTRIData_20070425_16_50_38 PM.XML",
                "CDX_NODE_TRI_GetTRIData_20070525_17_48_42 PM.XML",
                "CDX_NODE_TRI_GetTRIData_20070501_17_15_44 PM.XML",
                "CDX_NODE_TRI_GetTRIData_20070430_18_47_54 PM.XML",
                "CDX_NODE_TRI_GetTRIData_20061020_12_48_50 PM.XML",
                "CDX_NODE_TRI_GetTRIData_20061020_12_49_15 PM.XML",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.TRI4.TRIDataType>(tempFolderPath, rootSchemaFilePath, "http://www.exchangenetwork.net/schema/TRI/4",
                                                                                samplesFolderPath, sampleNames);
        }
        static void DoICISNPDES()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\ICISNPDES_20\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\ICISNPDES_20\docs");
            string[] sampleNames = new string[]
            {
                "ICISAR20091016_0939-allen-daniel.xml",
                "Sample.xml",
            };

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.ICISNPDES_20.Document>(tempFolderPath, rootSchemaFilePath, null,
                                                                                     samplesFolderPath, sampleNames);


            string[] sampleNames2 = new string[]
            {
                "ICISAR20091016_0939-allen-daniel_NoHeader.xml",
                "Sample_NoHeader.xml",
            };
            int count = 0;
            //UnitTestDatabase<Windsor.Node2008.WNOSPlugin.ICISNPDES_15.Payload>("System.Data.OracleClient", @"Data Source=localhost/XE;User Id=NODE_FLOW_ICISNPDES;Password=memorial;",
            UnitTestDatabase<Windsor.Node2008.WNOSPlugin.ICISNPDES_20.Payload>("System.Data.SqlClient", @"server=(local);integrated security=true;database=NODE_FLOW_ICISNPDES",
                                           samplesFolderPath, sampleNames2, delegate(Windsor.Node2008.WNOSPlugin.ICISNPDES_20.Payload data)
                                           {
                                               data.UserId = "Test User " + count.ToString();
                                               ++count;
                                           });
        }
        static void DoICISNPDES_3()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\ICISNPDES_31\xml_schema\index.xsd");
            //string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\ICISNPDES_31\docs\Examples\FromEPA");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\ICISNPDES_31\docs\Examples");

            IList<string> sampleNames = FileUtils.GetFileNamesInFolder(samplesFolderPath);

            //string[] sampleNames = new string[]
            //{
            //    "BasicPermit_New.xml",
            //    //"CAFOPermit_New.xml",
            //    //"DischargeMonitoringReport_Change.xml",
            //    //"Limits_New.xml",
            //    //"LimitSet_Replace.xml",
            //    //"ParameterLimits_Replace.xml",
            //    //"PermitReissuance_Change.xml",
            //    //"PermittedFeature_Replace.xml",
            //    //"PermitTermination_Change.xml",
            //};

            UnitTestSerialization<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document>(tempFolderPath, rootSchemaFilePath, null,
                                                                                     samplesFolderPath, sampleNames);

            Windsor.Commons.XsdOrm2.IObjectsToDatabase objectsToDatabase = new Windsor.Commons.XsdOrm2.Implementations.ObjectsToDatabase();
            Windsor.Commons.XsdOrm2.IObjectsFromDatabase objectsFromDatabase = new Windsor.Commons.XsdOrm2.Implementations.ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_ICISNPDES_3";
            dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_ICISNPDES;Password=memorial;";
            //dbProvider.ConnectionString = @"Data Source=ORA2;User Id=NODE_FLOW_ICIS;Password=memorial;";
            //dbProvider.ConnectionString = @"user id=NODE_FLOW_ICIS; password=memorial; data source= (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST =10.0.3.7)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = ora2)))";
            dbProvider.ConnectionString = @"user id=ICS_FLOW_LOCAL_WA; password=zRitE6giwvtO87r6mv2P; data source= (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST =ORA11G)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = ORCL)))";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            Type mappingAttributesType = typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.MappingAttributes);
            SerializationUtils serializationUtils = new SerializationUtils();




            string savePath2 = @"C:\DOWNLOAD\Test.xml";
            List < Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData > payloads2 = 
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData>(springBaseDao, null, mappingAttributesType);
            Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document dataOut = new Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document();
            dataOut.Payload = payloads2.ToArray();
            dataOut.Header = new Windsor.Node2008.WNOSPlugin.ICISNPDES_31.HeaderData();
            dataOut.Header.Id = "iddasdadadasdasdaasds";
            serializationUtils.Serialize(dataOut, savePath2);
            ValidateXml(savePath2, rootSchemaFilePath, @"C:\DOWNLOAD\ValidationErrors.txt");



            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData), springBaseDao,
                                            mappingAttributesType);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.SubmissionTrackingDataType), springBaseDao,
                                            mappingAttributesType);
            objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.ICISNPDES_31.SubmissionResultsDataType), springBaseDao,
                                            mappingAttributesType);

            foreach (string sampleName in sampleNames)
            {
                string filePath = Path.Combine(samplesFolderPath, sampleName);

                Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document>(filePath);
                Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document data2 =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.Document>(filePath);

                //KellermanSoftware.CompareNetObjects.CompareObjects objectComparer = new KellermanSoftware.CompareNetObjects.CompareObjects();
                //objectComparer.CompareChildren = true;
                //objectComparer.CompareFields = true;
                //objectComparer.ComparePrivateFields = false;
                //objectComparer.CompareProperties = false;
                //objectComparer.CompareReadOnly = false;
                //objectComparer.CompareStaticFields = false;
                //objectComparer.CompareStaticProperties = false;
                //objectComparer.ComparePrivateProperties = false;
                //objectComparer.Compare(data, data2);

                foreach (Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData payload in data.Payload)
                {
                    try
                    {
                        objectsToDatabase.DeleteAllFromDatabase(payload.GetType(), springBaseDao, mappingAttributesType);
                        Dictionary<string, int> counts = objectsToDatabase.SaveToDatabase(payload, springBaseDao, mappingAttributesType);
                        System.Collections.IList payloads = objectsFromDatabase.LoadFromDatabase(payload.GetType(), springBaseDao, null, mappingAttributesType);
                        if (payloads.Count != 1)
                        {
                            throw new Windsor.Commons.XsdOrm2.MappingException("Wrong number of items loaded");
                        }
                        Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData payload2 = (Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData)payloads[0];

                        //objectComparer.Compare(payload, payload2);
                        //if (objectComparer.Differences.Count > 0)
                        //{
                        //    string diffString = objectComparer.DifferencesString;
                        //}

                        byte[] bytes = serializationUtils.Serialize(payload2);

                        Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData payload3 =
                            serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.PayloadData>(bytes);
                        payload3.BeforeSaveToDatabase();

                        //objectComparer.Compare(payload2, payload3);
                        //if (objectComparer.Differences.Count > 0)
                        //{
                        //    string diffString = objectComparer.DifferencesString;
                        //}
                    }
                    catch (Exception)
                    {
                        DebugUtils.CheckDebuggerBreak();
                        throw;
                    }
                }

                //object primaryKeyValue = (memberInfo is FieldInfo) ? ((FieldInfo)memberInfo).GetValue(data) :
                //                                                     ((PropertyInfo)memberInfo).GetValue(data, null);

                //whereDict[tableName].SelectWhereQuery = string.Format(whereQueryFormat, primaryKeyValue.ToString());
                //List<T> list = objectsFromDatabase.LoadFromDatabase<T>(springBaseDao, whereDict);

                //if (CollectionUtils.IsNullOrEmpty(list) || (list.Count != 1))
                //{
                //    throw new ArgumentException("objectsFromDatabase.LoadFromDatabase() failed");
                //}
            }
        }
        static void DoCERS()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\CERS_11\xml_schema\1\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\CERS_11\docs");
            string[] sampleNames = new string[]
            {
                "Architectural Coating Examples.xml",
                "Drycleaner Example.xml",
                "EGU Facility Emissions Example.xml",
                "EGU Facility Example.xml",
                "Landfill Emissions Example.xml",
                "Landfill Example.xml",
                "TCR Example.xml",
            };

            UnitTestSerialization<CERSDataType>(tempFolderPath, rootSchemaFilePath, null, samplesFolderPath, sampleNames);

            UnitTestDatabase<CERSDataType>("System.Data.OracleClient", @"Data Source=localhost/XE;User Id=NODE_FLOW_CERS11_ORIG;Password=memorial;",
                //UnitTestDatabase<CERSDataType>("System.Data.SqlClient", @"server=(local);integrated security=true;database=NODE_FLOW_CERS11_ORIG",
                                           samplesFolderPath, sampleNames);
        }
        static void DoWQX1()
        {
            try
            {
                IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
                Spring.Data.Common.IDbProvider saveDbProvider =
                    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
                saveDbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_WQX";
                SpringBaseDao saveSpringBaseDao = new SpringBaseDao(saveDbProvider);
                objectsToDatabase.BuildDatabase(typeof(Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType), saveSpringBaseDao);


                string filePath = @"C:\WINDSOR\WQX1_NoHeader.xml";
                SerializationUtils serializationUtils = new SerializationUtils();
                Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.WQX1XsdOrm.WQXDataType>(filePath);

                objectsToDatabase.SaveToDatabase(data, saveSpringBaseDao);
            }
            catch (Exception)
            {
            }
        }
        static void DoWQX()
        {
            //string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\WQX_2\xml_schema\0\WQX_WQX_v2.0.xsd");
            //string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\WQX_2\xml_schema\index.xsd");
            //string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\WQX_2\docs");
            //string[] sampleNames = new string[]
            //{
            //    "GetWQXActivity_XMLExample_v2.0.xml",
            //    "WQX_XMLExample20080627_v2.0.xml",
            //    "AR_WQX.xml",
            //    "ND_WQX.xml"
            //};

            //UnitTestSerialization<WQXDataType>(tempFolderPath, rootSchemaFilePath, null, samplesFolderPath, sampleNames);

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            Spring.Data.Common.IDbProvider saveDbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            saveDbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_WQX";
            //saveDbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            //saveDbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_WQX_ORIG;Password=memorial;";
            SpringBaseDao saveSpringBaseDao = new SpringBaseDao(saveDbProvider);
            objectsToDatabase.BuildDatabase(typeof(WQXDataType), saveSpringBaseDao);

            //Spring.Data.Common.IDbProvider deletesDbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //deletesDbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=wqx_test_extract";
            //SpringBaseDao deletesSpringBaseDao = new SpringBaseDao(deletesDbProvider);
            //List<WQXDeleteDataType> deletesList = objectsFromDatabase.LoadFromDatabase<WQXDeleteDataType>(deletesSpringBaseDao, null);
            //TestSerialization(deletesList, rootSchemaFilePath, tempFolderPath);

            //objectsToDatabase.BuildDatabase(typeof(WQXDeleteDataType), saveSpringBaseDao);
            //objectsToDatabase.SaveToDatabase(deletesList[0], saveSpringBaseDao);

            //Spring.Data.Common.IDbProvider dbProvider =
            //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_WQX_ORIG";
            //SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //objectsToDatabase.BuildDatabase(typeof(WQXDataType), springBaseDao);
            //objectsToDatabase.BuildDatabase(typeof(WQXDeleteDataType), springBaseDao);

            //dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_ND";
            //springBaseDao = new SpringBaseDao(dbProvider);
            List<WQXDataType> dataList = objectsFromDatabase.LoadFromDatabase<WQXDataType>(saveSpringBaseDao, null);

            if (!CollectionUtils.IsNullOrEmpty(dataList))
            {
                WQXDataType data = dataList[0];
                SerializationUtils serializationUtils = new SerializationUtils();
                string tempPath = Path.GetTempFileName();
                serializationUtils.Serialize(data, tempPath);

                WQXDataType data2 = serializationUtils.Deserialize<WQXDataType>(tempPath);
                objectsToDatabase.BuildDatabase(typeof(WQXDataType), saveSpringBaseDao);
                objectsToDatabase.SaveToDatabase(data2, saveSpringBaseDao);
            }
        }
        static void DoFACID30()
        {
            //string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\FACID30\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\FACID30\docs");
            string[] sampleNames = new string[]
            {
                "FacilityDetails(Facility_Centric)_Sample_Instance_Document_NoHeader.xml",
                "FacilityDetails(EI_Centric)_Sample_Instance_Document_NoHeader.xml",
                "FacilityDetails(Mix)_Sample_Instance_Document_NoHeader.xml",
                "GetFacility.xml"
            };

            IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();

            Spring.Data.Common.IDbProvider dbProvider =
                Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            dbProvider.ConnectionString = @"server=.\sqlexpress;integrated security=true;database=NODE_FLOW_FACID";
            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            objectsToDatabase.BuildDatabase(typeof(FacilityDetailsDataType), springBaseDao);

            //UnitTestSerialization<FacilityDetailsDataType>(tempFolderPath, rootSchemaFilePath, null, samplesFolderPath, sampleNames);

            //UnitTestDatabase<FacilityDetailsDataType>("System.Data.SqlClient", @"server=(local);integrated security=true;database=NODE_FLOW_FACID_ORIG",
            //                                          samplesFolderPath, sampleNames);
            UnitTestDatabase<FacilityDetailsDataType>("System.Data.OracleClient", @"Data Source=localhost/XE;User Id=NODE_FLOW_FACID_ORIG;Password=memorial;",
                                                      samplesFolderPath, sampleNames);
        }
        static void DoP2R()
        {
            string tempFolderPath = @"C:\DOWNLOAD\TEST_XSD_ORM";
            string rootSchemaFilePath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\P2R\xml_schema\index.xsd");
            string samplesFolderPath = Path.GetFullPath(@"..\..\..\..\..\prod-opennode2-net\plugins\P2R\docs\");
            string[] sampleNames = new string[]
            {
                "P2R_sample_instance_file_v1.0.xml",
            };

            UnitTestSerialization<ProgramListType>(tempFolderPath, rootSchemaFilePath, null, samplesFolderPath, sampleNames);

            int count = 0;
            UnitTestDatabase<ProgramListType>("System.Data.OracleClient", @"Data Source=localhost/XE;User Id=NODE_FLOW_P2R;Password=memorial;",
                //UnitTestDatabase<ProgramListType>("System.Data.SqlClient", @"server=(local);integrated security=true;database=NODE_FLOW_P2R",
                                              samplesFolderPath, sampleNames, delegate(ProgramListType data)
            {
                data.OrgId = "Test Org " + count.ToString();
                ++count;
            });

            //try
            //{
            //    SerializationUtils serializationUtils = new SerializationUtils();

            //    string tempPath = Path.GetTempFileName();
            //    ProgramListType data =
            //        serializationUtils.Deserialize<ProgramListType>(@"C:\PROJECTS\opennode2-net\plugins\P2R\docs\P2R_sample_instance_file_v1.0.xml");
            //    data.OrgId = "CO_DPHE";
            //    List<ProjectDetailsSectorDataType> myList = new List<ProjectDetailsSectorDataType>();
            //    ProjectDetailsSectorDataType dataType = new ProjectDetailsSectorDataType(); dataType.SectorText = SectorTextDataType.Agriculture; myList.Add(dataType);
            //    dataType = new ProjectDetailsSectorDataType(); dataType.SectorText = SectorTextDataType.Healthcare; myList.Add(dataType);
            //    data.ProgramDetails[0].ProjectDetails[0].SectorText = myList.ToArray();
            //    data.ProgramDetails[0].ProgramZipCode = "97231";
            //    serializationUtils.Serialize(data, tempPath);
            //    data = serializationUtils.Deserialize<ProgramListType>(tempPath);
            //    data.OrgId = "CO_DPHE";

            //    IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
            //    IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            //    Spring.Data.Common.IDbProvider dbProvider =
            //        Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
            //    dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_P2R_ORIG";
            //    SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            //    objectsToDatabase.BuildDatabase(data.GetType(), springBaseDao);
            //    springBaseDao.DoSimpleDelete("P2R_ORG", "ORG_ID", data.OrgId);
            //    objectsToDatabase.SaveToDatabase(data, springBaseDao);

            //    ICollection<ProgramListType> dataList =
            //        objectsFromDatabase.LoadFromDatabase<ProgramListType>(springBaseDao, null);

            //    tempPath = Path.GetTempFileName();
            //    serializationUtils.Serialize(CollectionUtils.FirstItem(dataList), tempPath);
            //    data = serializationUtils.Deserialize<ProgramListType>(tempPath);

            //    Console.WriteLine("Success");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("****EXCEPTION:");
            //    Console.WriteLine(ExceptionUtils.ToLongString(e));
            //}
        }
        static void DoUIC()
        {
            try
            {
                SerializationUtils serializationUtils = new SerializationUtils();

                string tempPath = Path.GetTempFileName();
                Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType data =
                    serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType>(@"C:\Projects\opennode2-net\plugins\UIC_20\docs\UIC_SampleXML_v2.0_NoHeader.xml");
                data.OrgId = "WYEQ";
                data.OrgName = "WYEQ Name";
                serializationUtils.Serialize(data, tempPath);
                data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType>(tempPath);
                data.OrgId = "WYEQ";

                IObjectsToDatabase objectsToDatabase = new ObjectsToDatabase();
                IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

                Spring.Data.Common.IDbProvider
                dbProvider =
                    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.SqlClient");
                dbProvider.ConnectionString = @"server=(local);integrated security=true;database=NODE_FLOW_UIC";
                //dbProvider =
                //    Spring.Data.Common.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
                //dbProvider.ConnectionString = @"Data Source=localhost/XE;User Id=NODE_FLOW_UIC;Password=memorial;";
                SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

                objectsToDatabase.BuildDatabase(data.GetType(), springBaseDao);
                springBaseDao.DoSimpleDelete("UIC_ORG", "ORG_ID", data.OrgId);
                objectsToDatabase.SaveToDatabase(data, springBaseDao);

                ICollection<Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType> dataList =
                    objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType>(springBaseDao, null);

                tempPath = Path.GetTempFileName();
                serializationUtils.Serialize(CollectionUtils.FirstItem(dataList), tempPath);
                data = serializationUtils.Deserialize<Windsor.Node2008.WNOSPlugin.UIC_20.UICDataType>(tempPath);

                Console.WriteLine("Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("****EXCEPTION:");
                Console.WriteLine(ExceptionUtils.ToLongString(e));
            }
        }
        static void ValidateXml(string xmlPath, string rootSchemaFilePath, string errorsFilePath)
        {
            if (rootSchemaFilePath == null)
            {
                return;
            }
            XmlValidationUtils xmlValidationUtils = new XmlValidationUtils(true);
            if (!xmlValidationUtils.Validate(xmlPath, rootSchemaFilePath, errorsFilePath))
            {
                throw new XmlSchemaValidationException("Failed to validate xml");
            }
        }
        static void ValidateXml(string xmlPath, string rootSchemaFilePath)
        {
            if (rootSchemaFilePath == null)
            {
                return;
            }
            XmlValidationUtils xmlValidationUtils = new XmlValidationUtils();
            IList<string> errors = xmlValidationUtils.Validate(xmlPath, rootSchemaFilePath);
            if (!CollectionUtils.IsNullOrEmpty(errors))
            {
                string errorString = StringUtils.Join(Environment.NewLine, errors);
                File.WriteAllText(@"C:\Temp\~XmlValidationErrors.txt", errorString);
                throw new XmlSchemaValidationException(errorString);
            }
        }
        static T TestSerialization<T>(T obj, string rootSchemaFilePath,
                                      string xmlTempFolderPath)
        {
            SerializationUtils serializationUtils = new SerializationUtils();
            string tempPath = Path.Combine(xmlTempFolderPath, Guid.NewGuid().ToString() + ".xml");
            serializationUtils.Serialize(obj, tempPath);
            ValidateXml(tempPath, rootSchemaFilePath);
            T obj2 = serializationUtils.Deserialize<T>(tempPath);
            return obj2;
        }
        static T TestSerialization<T>(string xmlPath, string xmlTempFolderPath, string readerNamespace)
        {
            return TestSerialization<T>(xmlPath, null, readerNamespace, xmlTempFolderPath);
        }
        static T TestSerialization<T>(string xmlPath, string rootSchemaFilePath,
                                      string readerNamespace, string xmlTempFolderPath)
        {
            ValidateXml(xmlPath, rootSchemaFilePath);

            SerializationUtils serializationUtils = new SerializationUtils();

            T data;
            if (readerNamespace == null)
            {
                data = serializationUtils.Deserialize<T>(xmlPath);
            }
            else
            {
                data = serializationUtils.Deserialize<T>(new NamespaceSpecifiedXmlTextReader(readerNamespace, xmlPath));
            }

            string tempPath = Path.Combine(xmlTempFolderPath, Path.GetFileName(xmlPath));
            serializationUtils.Serialize(data, tempPath);

            ValidateXml(tempPath, rootSchemaFilePath);

            data = serializationUtils.Deserialize<T>(tempPath);

            return data;
        }
        private class MinMaxPair
        {
            public MinMaxPair()
            {
                Min = Max = int.MinValue;
            }
            public MinMaxPair(int value)
            {
                Min = Max = value;
            }
            public MinMaxPair(int min, int max)
            {
                Min = min;
                Max = max;
            }
            public int Min;
            public int Max;
        }
        static public void XsdToClassTest()
        {
            // identify the path to the xsd
            string[] xsdPaths = new string[] {
                //@"C:\PROJECTS\opennode2-net\plugins\HERE\xml_schema\TANKS10\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\FACID30\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\FACID30\xml_schema\0\gmlgeorss12.xsd" 
                //@"C:\PROJECTS\opennode2-net\plugins\ENDS_2\xml_schema\GetServices_v2.0.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\RCRA_41\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\CERS_11\xml_schema\1\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\CERS_12\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\WQX_2\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\FRS_23\xml_schema\FACID_FacilitySiteAll_v2.3.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\WQX_2\xml_schema\v10\index.xsd"
                //@"C:\PROJECTS\opennode2-net\plugins\ICIS-NPDES_15\xml_schema\index.xsd"
                //@"C:\PROJECTS\opennode2-net\plugins\TRI_40\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\RCRA_50\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\BEACHES_21\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\EMTS\xml_schema\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\WQX_2\docs\ProcessingReport2.xsd",
                //@"C:\WINDSOR\NH DES\SDWIS 3.0\SDWA_DataFlowInventory_v3.0.xsd",
                //@"C:\WINDSOR\NH DES\SDWIS 3.4\SDWA_DataFlowInventory_v3.4.xsd",
                //@"C:\WINDSOR\NH DES\SDWIS 2.0\SDWA_DataFlowInventory_v2.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\WOGCC\xml_schema\schema.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\AQS2\xml_schema_v2.2\index.xsd",
                //@"C:\WINDSOR\NH DES\SDWIS 3.4\index.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\RCRA_51\xml_schema\index.xsd",
                //@"C:\Projects\opennode2-net-branch\src\WNOSDomain\TransactionTracking\TransactionTracking.xsd",
                //@"C:\Projects\opennode2-net-branch\plugins\eDWR_22\xml_schema\2\EDWR_eDWR_v2.2.xsd",
                //@"C:\DOWNLOAD\temp.xsd",
                //@"C:\PROJECTS\opennode2-net\plugins\ICISNPDES_20\xml_schema\index.xsd"
                //@"C:\Projects\opennode2-net\plugins\PCS_IDEF\xml_schema\IDEF.xsd"
                //@"C:\Projects\opennode2-net\plugins\UIC_20\xml_schema\index.xsd"
                //@"C:\Projects\opennode2-net\plugins\JMX_10\xml_schema\index.xsd"
                //@"C:\Projects\opennode2-net\plugins\JMX_10\xml_schema\JMX v1.0 Schema Final v1.2.xsd"
                //@"C:\Projects\opennode2-net\plugins\RCRA_52\xml_schema\index.xsd"
                //@"C:\DOWNLOAD\SanitarySurvey_v1.0_draft1\BSS_BSS_v1.0.xsd"
                //@"C:\Program Files (x86)\IIS Express\config\schema\IIS_schema.xml"
                //@"C:\Projects\opennode2-net\plugins\OWIR-ATT_20\xml_schema\index.xsd"
                //@"C:\Projects\prod-opennode2-net\plugins\NetDMR_10\xml_schema\index.xsd"
                //@"C:\Projects\prod-opennode2-net\plugins\EMTS_20\xml_schema\index.xsd"
                //@"C:\Projects\prod-opennode2-net\plugins\ICISNPDES_31\xml_schema\index.xsd"
                //@"C:\Projects\prod-opennode2-net\plugins\SDWIS_Sampling_20\xml_schema\2\SDWIS_eDWR_v2.0.xsd"
                @"C:\PROJECTS\OpenNode2-google\prod-opennode2-net\plugins\BEACHES_22\xml_schema\index.xsd"
            };

            const string NAMESPACE = "Windsor.Node2008.WNOSPlugin.BEACHES_22";
            //const string OUTPUT_PATH = @"C:\Download\SDWIS_eDWR_20.cs";
            const string OUTPUT_PATH = @"C:\Download\BEACHES_2_2.cs";

#if USE_WINDSOR_XSDORM_CLASSES
            const string WINDSOR_NAMESPACE = "Windsor.Commons.XsdOrm.";
            //const string WINDSOR_NAMESPACE = "Windsor.Commons.XsdOrm2.";
#endif // USE_WINDSOR_XSDORM_CLASSES

            string startDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = Path.GetDirectoryName(xsdPaths[0]);

            try
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();

                List<string> rootSourceUris = new List<string>();
                foreach (string xsdPath in xsdPaths)
                {
                    using (FileStream stream = new FileStream(xsdPath, FileMode.Open, FileAccess.Read))
                    {
                        XmlSchema xsd = XmlSchema.Read(stream, null);
                        schemaSet.Add(xsd);
                        foreach (XmlSchemaObject xmlSchemaObject in xsd.Includes)
                        {
                            XmlSchemaInclude xmlSchemaInclude = xmlSchemaObject as XmlSchemaInclude;
                            if (xmlSchemaInclude != null)
                            {
                                string parentDir = Path.GetDirectoryName(xsdPath);
                                string saveCurrentDirectory = Environment.CurrentDirectory;
                                Environment.CurrentDirectory = parentDir;
                                string uri = Path.GetFullPath(xmlSchemaInclude.SchemaLocation);
                                uri = uri.Replace('\\', '/');
                                rootSourceUris.Add(("file:///" + uri).ToUpper());
                                Environment.CurrentDirectory = saveCurrentDirectory;
                            }
                        }
                    }
                }

                schemaSet.Compile();

                XmlSchemas schemas = new XmlSchemas();
                XmlSchema[] schemaArray = new XmlSchema[schemaSet.Count];

                schemaSet.CopyTo(schemaArray, 0);
                foreach (XmlSchema xsd in schemaArray)
                {
                    schemas.Add(xsd);
                }

                XmlSchemaImporter schemaImporter = new XmlSchemaImporter(schemas, CodeGenerationOptions.GenerateOrder, null);

                // create the codedom
                CodeNamespace codeNamespace = new CodeNamespace(NAMESPACE);
                XmlCodeExporter codeExporter =
                    new XmlCodeExporter(codeNamespace, new CodeCompileUnit(), CodeGenerationOptions.None);

                List<XmlTypeMapping> maps = new List<XmlTypeMapping>();
                Dictionary<string, string> typeNameToDoc = new Dictionary<string, string>();
                Dictionary<string, bool?> nonNullElements = new Dictionary<string, bool?>();
                Dictionary<string, MinMaxPair> stringLengthElements = new Dictionary<string, MinMaxPair>();
                Dictionary<string, DbType> dbTypeElements = new Dictionary<string, DbType>();
                Dictionary<string, KeyValuePair<int, int>> dbScaleElements = new Dictionary<string, KeyValuePair<int, int>>();
                List<string> rootTypeNames = new List<string>();
                for (int i = 0; i < schemas.Count; ++i)
                {
                    XmlSchema xsd = schemas[i];
                    foreach (XmlSchemaElement schemaElement in xsd.Elements.Values)
                    {
                        if (rootSourceUris.Contains(schemaElement.SourceUri.ToUpper()))
                        {
                            rootTypeNames.Add(schemaElement.ElementSchemaType.Name);
                        }

                        XmlTypeMapping mapping = schemaImporter.ImportTypeMapping(schemaElement.QualifiedName);
                        if (mapping.ElementName != mapping.XsdElementName)
                        {
                        }
                        codeExporter.ExportTypeMapping(mapping);

                        maps.Add(mapping);

                        GetDocumentation(schemaElement, typeNameToDoc);
                        GetNonNullElements(schemaElement, nonNullElements, false);
                        GetStringLengthElements(schemaElement, stringLengthElements, dbTypeElements, dbScaleElements);
                    }
                }

                Dictionary<string, CodeTypeDeclaration> rootTypes, childTypes;
                GetRootAndChildTypes(codeNamespace, out rootTypes, out childTypes);

                foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
                {
                    for (int i = codeType.CustomAttributes.Count - 1; i >= 0; --i)
                    {
                        if ((codeType.CustomAttributes[i].Name == "System.CodeDom.Compiler.GeneratedCodeAttribute") ||
                            (codeType.CustomAttributes[i].Name == "System.ComponentModel.DesignerCategoryAttribute") ||
                            (codeType.CustomAttributes[i].Name == "System.Diagnostics.DebuggerStepThroughAttribute"))
                        {
                            codeType.CustomAttributes.RemoveAt(i);
                        }
                    }
                    foreach (CodeTypeMember member in codeType.Members)
                    {
                        string elementKey = member.Name;
                        //string elementKey = string.Format("{0}.{1}", codeType.Name, member.Name);
                        string docs;
                        if (TryGetDictValue(elementKey, typeNameToDoc, out docs) && (docs != null))
                        {
                            CodeAttributeArgument[] arguments = new CodeAttributeArgument[1];
                            arguments[0] = new CodeAttributeArgument(
                                new CodePrimitiveExpression(docs));
                            CodeAttributeDeclaration methodLevelAttribute = new CodeAttributeDeclaration(
                                new CodeTypeReference("System.ComponentModel.DescriptionAttribute"), arguments);
                            member.CustomAttributes.Add(methodLevelAttribute);
                        }
#if USE_WINDSOR_XSDORM_CLASSES
                        bool? isNonNull;
                        if (TryGetDictValue(elementKey, nonNullElements, out isNonNull) && (isNonNull != null) &&
                                (isNonNull.Value == true))
                        {
                            CodeAttributeDeclaration methodLevelAttribute = new CodeAttributeDeclaration(
                                new CodeTypeReference(WINDSOR_NAMESPACE + "DbNotNullAttribute"));
                            member.CustomAttributes.Add(methodLevelAttribute);
                        }
                        MinMaxPair minMaxPair;
                        if (TryGetDictValue(elementKey, stringLengthElements, out minMaxPair))
                        {
                            CodeAttributeArgument[] arguments = new CodeAttributeArgument[1];
                            arguments[0] = new CodeAttributeArgument(
                                new CodePrimitiveExpression(minMaxPair.Max));
                            CodeAttributeDeclaration methodLevelAttribute = new CodeAttributeDeclaration(
                                new CodeTypeReference((minMaxPair.Max > minMaxPair.Min) ? WINDSOR_NAMESPACE + "DbMaxColumnSizeAttribute" :
                                                                                            WINDSOR_NAMESPACE + "DbFixedColumnSizeAttribute"),
                                                        arguments);
                            member.CustomAttributes.Add(methodLevelAttribute);
                        }
                        DbType dbType;
                        if (TryGetDictValue(elementKey, dbTypeElements, out dbType))
                        {
                            CodeAttributeArgument[] arguments = new CodeAttributeArgument[1];
                            arguments[0] = new CodeAttributeArgument(
                                new CodePrimitiveExpression(dbType.ToString()));
                            CodeAttributeDeclaration methodLevelAttribute = new CodeAttributeDeclaration(
                                new CodeTypeReference(WINDSOR_NAMESPACE + "DbColumnTypeAttribute"),
                                                        arguments);
                            member.CustomAttributes.Add(methodLevelAttribute);
                        }
                        KeyValuePair<int, int> dbScale;
                        if (TryGetDictValue(elementKey, dbScaleElements, out dbScale))
                        {
                            CodeAttributeArgument[] arguments = new CodeAttributeArgument[2];
                            arguments[0] = new CodeAttributeArgument(
                                new CodePrimitiveExpression(dbScale.Key.ToString()));
                            arguments[1] = new CodeAttributeArgument(
                                new CodePrimitiveExpression(dbScale.Value.ToString()));
                            CodeAttributeDeclaration methodLevelAttribute = new CodeAttributeDeclaration(
                                new CodeTypeReference(WINDSOR_NAMESPACE + "DbColumnScaleAttribute"),
                                                        arguments);
                            member.CustomAttributes.Add(methodLevelAttribute);
                        }
#endif // USE_WINDSOR_XSDORM_CLASSES
                    }
                }

                // Check for invalid characters in identifiers
                CodeGenerator.ValidateIdentifiers(codeNamespace);

                // output the C# code
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();

                using (StreamWriter writer = new StreamWriter(OUTPUT_PATH))
                {
                    codeProvider.GenerateCodeFromNamespace(codeNamespace, writer, new CodeGeneratorOptions());
                }
            }
            finally
            {
                Environment.CurrentDirectory = startDirectory;
            }
        }

        private static bool TryGetDictValue<T>(string key, Dictionary<string, T> dict, out T value)
        {
            value = default(T);
            foreach (KeyValuePair<string, T> pair in dict)
            {
                if (key.Equals(pair.Key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            return false;
        }
        private static void GetRootAndChildTypes(CodeNamespace codeNamespace,
                                                 out Dictionary<string, CodeTypeDeclaration> rootClasses,
                                                 out Dictionary<string, CodeTypeDeclaration> childClasses)
        {
            rootClasses = new Dictionary<string, CodeTypeDeclaration>(codeNamespace.Types.Count);
            childClasses = new Dictionary<string, CodeTypeDeclaration>(codeNamespace.Types.Count);

            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                if (codeType.IsClass)
                {
                    rootClasses.Add(codeType.Name, codeType);
                }
            }
            List<string> removeRootClassNames = new List<string>(codeNamespace.Types.Count);
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                foreach (CodeTypeMember member in codeType.Members)
                {
                    CodeMemberField field = member as CodeMemberField;
                    if (field != null)
                    {
                        if (field.Type.ArrayElementType != null)
                        {
                            DebugUtils.AssertDebuggerBreak(field.Type.ArrayElementType.BaseType == field.Type.BaseType);
                            CodeTypeDeclaration childDeclaration;
                            if (rootClasses.TryGetValue(field.Type.BaseType, out childDeclaration))
                            {
                                childClasses[field.Type.BaseType] = childDeclaration;
                            }
                        }
                        CollectionUtils.InsertIntoSortedList(removeRootClassNames, field.Type.BaseType);
                    }
                }
            }
            foreach (string removeRootTypeName in removeRootClassNames)
            {
                rootClasses.Remove(removeRootTypeName);
            }
#if ADD_BASE_DATA_TYPES
            CodeTypeReference baseDataTypeRef = new CodeTypeReference(typeof(BaseDataType));
            foreach (CodeTypeDeclaration rootClass in rootClasses.Values)
            {
                //DebugUtils.AssertDebuggerBreak(rootClass.BaseTypes.Count == 0);
                if (rootClass.BaseTypes.Count == 0)
                {
                    rootClass.BaseTypes.Add(baseDataTypeRef);
                }
            }
            CodeTypeReference childDataTypeRef = new CodeTypeReference(typeof(BaseChildDataType));
            foreach (CodeTypeDeclaration childClass in childClasses.Values)
            {
                if (childClass.BaseTypes.Count == 0)
                {
                    childClass.BaseTypes.Add(childDataTypeRef);
                }
            }
#endif // ADD_BASE_DATA_TYPES
        }
        static CodeTypeDeclaration FindByName(CodeNamespace codeNamespace, string typeName)
        {
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                if (codeType.Name == typeName)
                {
                    return codeType;
                }
            }
            return null;
        }
        static void GetUsedTypeNames(CodeNamespace codeNamespace, CodeTypeDeclaration rootCodeType,
                                     List<string> usedTypeNames)
        {
            if (rootCodeType == null)
            {
                return;
            }
            if (!usedTypeNames.Contains(rootCodeType.Name))
            {
                usedTypeNames.Add(rootCodeType.Name);
            }
            foreach (CodeTypeReference baseType in rootCodeType.BaseTypes)
            {
                GetUsedTypeNames(codeNamespace, FindByName(codeNamespace, baseType.BaseType),
                                 usedTypeNames);
            }
            foreach (CodeTypeMember member in rootCodeType.Members)
            {
                CodeMemberField memberField = member as CodeMemberField;
                if (memberField != null)
                {
                    GetUsedTypeNames(codeNamespace, FindByName(codeNamespace, memberField.Type.BaseType),
                                     usedTypeNames);
                }
                else
                {
                    CodeMemberProperty memberProperty = member as CodeMemberProperty;
                    if (memberProperty != null)
                    {
                        GetUsedTypeNames(codeNamespace, FindByName(codeNamespace, memberProperty.Type.BaseType),
                                         usedTypeNames);
                    }
                }
                foreach (CodeAttributeDeclaration codeAttributeDeclaration in member.CustomAttributes)
                {
                    if (codeAttributeDeclaration.Name == "System.Xml.Serialization.XmlElementAttribute")
                    {
                        foreach (CodeAttributeArgument codeAttributeArgument in codeAttributeDeclaration.Arguments)
                        {
                            CodeTypeOfExpression typeOfExpression = codeAttributeArgument.Value as CodeTypeOfExpression;
                            if (typeOfExpression != null)
                            {
                                GetUsedTypeNames(codeNamespace, FindByName(codeNamespace, typeOfExpression.Type.BaseType),
                                                 usedTypeNames);
                            }
                        }
                    }
                }
            }
        }
        static void RemoveUnusedTypes(CodeNamespace codeNamespace, List<string> rootTypeNames)
        {
            List<string> usedTypeNames = new List<string>();
            foreach (string rootTypeName in rootTypeNames)
            {
                GetUsedTypeNames(codeNamespace, FindByName(codeNamespace, rootTypeName), usedTypeNames);
            }

            for (int i = codeNamespace.Types.Count - 1; i >= 0; --i)
            {
                CodeTypeDeclaration codeType = codeNamespace.Types[i];
                if (!usedTypeNames.Contains(codeType.Name))
                {
                    string name = codeType.Name;
                    codeNamespace.Types.RemoveAt(i);
                }
            }
            for (int i = codeNamespace.Types.Count - 1; i >= 0; --i)
            {
                CodeTypeDeclaration codeType = codeNamespace.Types[i];
                for (int j = codeType.CustomAttributes.Count - 1; j >= 0; --j)
                {
                    CodeAttributeDeclaration codeAttributeDeclaration = codeType.CustomAttributes[j];
                    if (codeAttributeDeclaration.Name == "System.Xml.Serialization.XmlIncludeAttribute")
                    {
                        for (int k = codeAttributeDeclaration.Arguments.Count - 1; k >= 0; --k)
                        {
                            CodeAttributeArgument codeAttributeArgument = codeAttributeDeclaration.Arguments[k];
                            CodeTypeOfExpression typeOfExpression = codeAttributeArgument.Value as CodeTypeOfExpression;
                            if (typeOfExpression != null)
                            {
                                if (FindByName(codeNamespace, typeOfExpression.Type.BaseType) == null)
                                {
                                    codeAttributeDeclaration.Arguments.RemoveAt(k);
                                }
                            }
                        }
                        if (codeAttributeDeclaration.Arguments.Count == 0)
                        {
                            codeType.CustomAttributes.RemoveAt(j);
                        }
                    }
                }
            }
        }
        static bool IsTypeReferencedByType(CodeTypeDeclaration codeType, CodeTypeDeclaration codeTypeToFind)
        {
            if (!codeTypeToFind.IsClass)
            {
                return true;
            }
            if (!codeType.IsClass)
            {
                return false;
            }
            foreach (CodeTypeMember member in codeType.Members)
            {
                CodeMemberField memberField = member as CodeMemberField;
                if (memberField != null)
                {
                    if (memberField.Type.BaseType == codeTypeToFind.Name)
                    {
                        return true;
                    }
                }
                else
                {
                    CodeMemberProperty memberProperty = member as CodeMemberProperty;
                    if (memberProperty != null)
                    {
                        if (memberProperty.Type.BaseType == codeTypeToFind.Name)
                        {
                            return true;
                        }
                    }
                }
                CodeTypeDeclaration typeDeclaration = member as CodeTypeDeclaration;
                if (typeDeclaration != null)
                {
                    if (IsTypeReferencedByType(typeDeclaration, codeTypeToFind))
                    {
                        return true;
                    }
                }
                foreach (CodeAttributeDeclaration codeAttributeDeclaration in member.CustomAttributes)
                {
                    if (codeAttributeDeclaration.Name == "System.Xml.Serialization.XmlElementAttribute")
                    {
                        foreach (CodeAttributeArgument codeAttributeArgument in codeAttributeDeclaration.Arguments)
                        {
                            CodeTypeOfExpression typeOfExpression = codeAttributeArgument.Value as CodeTypeOfExpression;
                            if (typeOfExpression != null)
                            {
                                if (typeOfExpression.Type.BaseType == codeTypeToFind.Name)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            foreach (CodeTypeReference baseType in codeType.BaseTypes)
            {
                if (baseType.BaseType == codeTypeToFind.Name)
                {
                    return true;
                }
            }
            foreach (CodeAttributeDeclaration codeAttributeDeclaration in codeType.CustomAttributes)
            {
                if (codeAttributeDeclaration.Name == "System.Xml.Serialization.XmlIncludeAttribute")
                {
                    foreach (CodeAttributeArgument codeAttributeArgument in codeAttributeDeclaration.Arguments)
                    {
                        CodeTypeOfExpression typeOfExpression = codeAttributeArgument.Value as CodeTypeOfExpression;
                        if (typeOfExpression != null)
                        {
                            if (typeOfExpression.Type.BaseType == codeTypeToFind.Name)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        static void GetDocumentation(XmlSchemaElement elem, Dictionary<string, string> typeNameToDoc)
        {
            XmlSchemaAnnotation anot = elem.Annotation;
            if (anot == null || anot.Items == null)
                return;

            foreach (object ob in anot.Items)
            {
                XmlSchemaDocumentation doc = ob as XmlSchemaDocumentation;
                if (doc != null && doc.Markup != null && doc.Markup.Length > 0)
                {
                    string documentation = null;
                    foreach (XmlNode node in doc.Markup)
                    {
                        if (documentation == null)
                        {
                            documentation = node.Value;
                        }
                        else
                        {
                            documentation += node.Value;
                        }
                    }
                    if (!string.IsNullOrEmpty(documentation))
                    {
                        if (!string.IsNullOrEmpty(elem.Name))
                        {
                            if (!typeNameToDoc.ContainsKey(elem.Name))
                            {
                                typeNameToDoc.Add(elem.Name, documentation);
                            }
                            else
                            {
                                string currentStr = typeNameToDoc[elem.Name];
                                if (currentStr != documentation)
                                {
                                    typeNameToDoc[elem.Name] = null;
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(elem.SchemaTypeName.Name))
                        {
                            if (!typeNameToDoc.ContainsKey(elem.SchemaTypeName.Name))
                            {
                                typeNameToDoc.Add(elem.SchemaTypeName.Name, documentation);
                            }
                            else
                            {
                                string currentStr = typeNameToDoc[elem.SchemaTypeName.Name];
                                if (currentStr != documentation)
                                {
                                    typeNameToDoc[elem.SchemaTypeName.Name] = null;
                                }
                            }
                        }
                    }
                }
            }
        }
        static string ElementKey(XmlSchemaElement member)
        {
            return member.QualifiedName.Name;
        }
        static void GetNonNullElementsForSimpleType(XmlSchemaElement simpleElement, Dictionary<string, bool?> nonNullElements)
        {
            string elementKey = ElementKey(simpleElement);
            bool isNotNull;
            if (simpleElement.MinOccurs > 0)
            {
                isNotNull = true;
            }
            else if (((simpleElement.MinOccursString != null) && (simpleElement.MinOccursString != "0")) ||
                ((simpleElement.MinOccursString == null) && (simpleElement.MaxOccursString != null)) ||
                ((simpleElement.MinOccursString == null) && (simpleElement.MaxOccursString == null)))
            {
                isNotNull = true;
            }
            else
            {
                isNotNull = false;
            }
            if (!nonNullElements.ContainsKey(elementKey))
            {
                nonNullElements.Add(elementKey, isNotNull);
            }
            else
            {
                if (nonNullElements[elementKey] != null)
                {
                    if (nonNullElements[elementKey].Value != isNotNull)
                    {
                        //nonNullElements[elementKey] = null;
                        nonNullElements[elementKey] = false;
                    }
                }
            }
        }
        static void GetNonNullElements(XmlSchemaElement elem, Dictionary<string, bool?> nonNullElements, bool withinComplexType)
        {
            XmlSchemaComplexType complexType = elem.ElementSchemaType as XmlSchemaComplexType;
            if (complexType != null)
            {
                XmlSchemaSequence sequence = complexType.Particle as XmlSchemaSequence;
                if (sequence != null)
                {
                    foreach (XmlSchemaObject schemaObj in sequence.Items)
                    {
                        XmlSchemaElement schemaElement = schemaObj as XmlSchemaElement;
                        if (schemaElement != null)
                        {
                            GetNonNullElements(schemaElement, nonNullElements, true);
                        }
                    }
                }
                else
                {
                    if (complexType.Particle != null)
                    {
                        //DebugUtils.CheckDebuggerBreak();
                    }
                }
                if ((complexType.ContentTypeParticle.MinOccurs == 0) ||
                    ((complexType.Particle != null) && (complexType.Particle.MinOccurs == 0)))
                {
                }
            }
            else if (withinComplexType)
            {
                XmlSchemaSimpleType simpleType = elem.ElementSchemaType as XmlSchemaSimpleType;
                if (simpleType != null)
                {
                    GetNonNullElementsForSimpleType(elem, nonNullElements);
                }
                else
                {
                    DebugUtils.CheckDebuggerBreak();
                }
            }
        }
        static void GetStringLengthElements(XmlSchemaElement elem, Dictionary<string, MinMaxPair> stringLengthElements,
                                            Dictionary<string, DbType> dbTypeElements, Dictionary<string, KeyValuePair<int, int>> dbScaleElements)
        {
            //if ( simpleType.Datatype.ValueType == typeof(string) ) {
            //    XmlSchemaSimpleTypeRestriction restriction = simpleType.Content as XmlSchemaSimpleTypeRestriction;
            //    if (restriction != null)
            //    {
            //        MinMaxPair pair = new MinMaxPair();
            //        string elementKey = string.Format("{0}.{1}", simpleType.QualifiedName.Name, elem.QualifiedName.Name);

            //        foreach (XmlSchemaObject facet in restriction.Facets)
            //        {
            //            XmlSchemaLengthFacet lengthFacet = facet as XmlSchemaLengthFacet;
            //            if (lengthFacet != null)
            //            {
            //                pair.Min = pair.Max = int.Parse(lengthFacet.Value);
            //            }
            //            else
            //            {
            //                XmlSchemaMinLengthFacet minLengthFacet = facet as XmlSchemaMinLengthFacet;
            //                if (minLengthFacet != null)
            //                {
            //                    pair.Min = int.Parse(minLengthFacet.Value);
            //                }
            //                else
            //                {
            //                    XmlSchemaMaxLengthFacet maxLengthFacet = facet as XmlSchemaMaxLengthFacet;
            //                    if (maxLengthFacet != null)
            //                    {
            //                        pair.Max = int.Parse(maxLengthFacet.Value);
            //                    }
            //                }
            //            }
            //        }
            //        if ((pair.Min != int.MinValue) && (pair.Max != int.MinValue))
            //        {
            //            stringLengthElements.Add(elementKey, pair);
            //        }
            //    }
            //}
            XmlSchemaComplexType complexType = elem.ElementSchemaType as XmlSchemaComplexType;
            if (complexType != null)
            {
                // Get the sequence particle of the complex type.
                XmlSchemaSequence sequence = complexType.ContentTypeParticle as XmlSchemaSequence;

                if (sequence == null)
                {
                    XmlSchemaChoice schemaChoice = complexType.ContentTypeParticle as XmlSchemaChoice;
                    if (schemaChoice == null)
                    {
                    }
                    else
                    {
                        GetAdditionalQualifiers(elem, schemaChoice.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                    }
                }
                else
                {
                    GetAdditionalQualifiers(elem, sequence.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                }
            }
            else
            {
            }
        }
        static MinMaxPair ProcessStringRestriction(string elementKey, XmlSchemaSimpleTypeRestriction restriction,
                                                   Dictionary<string, MinMaxPair> stringLengthElements)
        {
            MinMaxPair pair = ProcessStringRestriction(restriction);
            if (pair != null)
            {
                MinMaxPair presentPair;
                if (stringLengthElements.TryGetValue(elementKey, out presentPair))
                {
                    DebugUtils.AssertDebuggerBreak((presentPair.Max == pair.Max) &&
                                                   (presentPair.Min == pair.Min));
                }
                else
                {
                    stringLengthElements.Add(elementKey, pair);
                }
            }
            return pair;
        }
        static MinMaxPair ProcessStringRestriction(XmlSchemaSimpleTypeRestriction restriction)
        {
            MinMaxPair pair = new MinMaxPair();
            int minEnumLength = int.MaxValue, maxEnumLength = int.MinValue;

            foreach (XmlSchemaObject facet in restriction.Facets)
            {
                XmlSchemaLengthFacet lengthFacet = facet as XmlSchemaLengthFacet;
                if (lengthFacet != null)
                {
                    pair.Min = pair.Max = int.Parse(lengthFacet.Value);
                }
                else
                {
                    XmlSchemaMinLengthFacet minLengthFacet = facet as XmlSchemaMinLengthFacet;
                    if (minLengthFacet != null)
                    {
                        pair.Min = int.Parse(minLengthFacet.Value);
                        if (pair.Max == int.MinValue)
                        {
                            pair.Max = 255;
                        }
                    }
                    else
                    {
                        XmlSchemaMaxLengthFacet maxLengthFacet = facet as XmlSchemaMaxLengthFacet;
                        if (maxLengthFacet != null)
                        {
                            pair.Max = int.Parse(maxLengthFacet.Value);
                            if (pair.Min == int.MinValue)
                            {
                                pair.Min = 0;
                            }
                        }
                        else
                        {
                            XmlSchemaEnumerationFacet enumFacet = facet as XmlSchemaEnumerationFacet;
                            if (enumFacet != null)
                            {
                                if (enumFacet.Value != null)
                                {
                                    if (enumFacet.Value.Length > maxEnumLength)
                                    {
                                        maxEnumLength = enumFacet.Value.Length;
                                    }
                                    if (enumFacet.Value.Length < minEnumLength)
                                    {
                                        minEnumLength = enumFacet.Value.Length;
                                    }
                                }
                            }
                            else
                            {
                                XmlSchemaMinExclusiveFacet minExclusiveFacet = facet as XmlSchemaMinExclusiveFacet;
                                XmlSchemaMaxExclusiveFacet maxExclusiveFacet = facet as XmlSchemaMaxExclusiveFacet;
                                XmlSchemaMinInclusiveFacet minInclusiveFacet = facet as XmlSchemaMinInclusiveFacet;
                                XmlSchemaMaxInclusiveFacet maxInclusiveFacet = facet as XmlSchemaMaxInclusiveFacet;
                                if ((minInclusiveFacet != null) || (maxInclusiveFacet != null) || (minExclusiveFacet != null) || (maxExclusiveFacet != null))
                                {
                                    string valueString = null;
                                    if (minInclusiveFacet != null)
                                    {
                                        valueString = minInclusiveFacet.Value;
                                    }
                                    else if (maxInclusiveFacet != null)
                                    {
                                        valueString = maxInclusiveFacet.Value;
                                    }
                                    else if (minExclusiveFacet != null)
                                    {
                                        valueString = minExclusiveFacet.Value;
                                    }
                                    else if (maxExclusiveFacet != null)
                                    {
                                        valueString = maxExclusiveFacet.Value;
                                    }
                                    if (valueString != null)
                                    {
                                        if (valueString.Length > maxEnumLength)
                                        {
                                            maxEnumLength = valueString.Length;
                                        }
                                        if (valueString.Length < minEnumLength)
                                        {
                                            minEnumLength = valueString.Length;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ExceptionUtils.ThrowIfTrue((maxEnumLength != int.MinValue) && (pair.Min != int.MinValue) && (pair.Max != int.MinValue),
                                        "(maxEnumLength != int.MinValue) && (pair.Min != int.MinValue) && (pair.Max != int.MinValue)");

            if (maxEnumLength != int.MinValue)
            {
                pair.Min = minEnumLength;
                pair.Max = maxEnumLength;
                return pair;
            }
            if ((pair.Min != int.MinValue) && (pair.Max != int.MinValue))
            {
                return pair;
            }
            return null;
        }
        static bool ProcessDecimalRestriction(XmlSchemaSimpleTypeRestriction restriction, out int size, out int scale)
        {
            size = 0;
            scale = 0;
            foreach (XmlSchemaObject facet in restriction.Facets)
            {
                XmlSchemaMinInclusiveFacet minInclusiveFacet = facet as XmlSchemaMinInclusiveFacet;
                if (minInclusiveFacet != null)
                {
                    if ((minInclusiveFacet.Value != null) && (minInclusiveFacet.Value.Length > 1))
                    {
                        if (minInclusiveFacet.Value[0] == '-')
                        {
                            if (size < (minInclusiveFacet.Value.Length - 1))
                            {
                                size = minInclusiveFacet.Value.Length - 1;
                            }
                        }
                    }
                    continue;
                }
                XmlSchemaMaxInclusiveFacet maxInclusiveFacet = facet as XmlSchemaMaxInclusiveFacet;
                if (maxInclusiveFacet != null)
                {
                    if ((maxInclusiveFacet.Value != null) && (maxInclusiveFacet.Value.Length > 0))
                    {
                        if (maxInclusiveFacet.Value[0] != '-')
                        {
                            if (size < maxInclusiveFacet.Value.Length)
                            {
                                size = maxInclusiveFacet.Value.Length;
                            }
                        }
                    }
                    continue;
                }
                XmlSchemaFractionDigitsFacet fractionDigitsFacet = facet as XmlSchemaFractionDigitsFacet;
                if (fractionDigitsFacet != null)
                {
                    int fracDigits;
                    if (int.TryParse(fractionDigitsFacet.Value, out fracDigits) && (fracDigits > 0))
                    {
                        scale = fracDigits;
                    }
                    continue;
                }
            }
            if ((size != 0) && (scale != 0))
            {
                size += scale;
                return true;
            }
            return false;
        }
        static void GetAdditionalQualifiers(XmlSchemaElement parentElement, XmlSchemaObjectCollection sequence,
                                            Dictionary<string, MinMaxPair> stringLengthElements,
                                            Dictionary<string, DbType> dbTypeElements,
                                            Dictionary<string, KeyValuePair<int, int>> dbScaleElements)
        {
            // Iterate over each XmlSchemaElement in the Items collection.
            foreach (XmlSchemaObject item in sequence)
            {
                XmlSchemaElement childElement = item as XmlSchemaElement;
                if (childElement == null)
                {
                    XmlSchemaSequence childSequence = item as XmlSchemaSequence;
                    if (childSequence == null)
                    {
                        XmlSchemaChoice schemaChoice = item as XmlSchemaChoice;
                        if (schemaChoice == null)
                        {
                        }
                        else
                        {
                            GetAdditionalQualifiers(parentElement, schemaChoice.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                        }
                    }
                    else
                    {
                        GetAdditionalQualifiers(parentElement, childSequence.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                    }
                }
                else
                {
                    XmlSchemaSimpleType simpleType = childElement.ElementSchemaType as XmlSchemaSimpleType;
                    if (simpleType == null)
                    {
                        XmlSchemaComplexType complexType = childElement.ElementSchemaType as XmlSchemaComplexType;
                        if (complexType != null)
                        {
                            // Get the sequence particle of the complex type.
                            XmlSchemaSequence sequence2 = complexType.ContentTypeParticle as XmlSchemaSequence;

                            if (sequence2 == null)
                            {
                                XmlSchemaChoice schemaChoice2 = item as XmlSchemaChoice;
                                if (schemaChoice2 == null)
                                {
                                }
                                else
                                {
                                    GetAdditionalQualifiers(parentElement, schemaChoice2.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                                }
                            }
                            else
                            {
                                GetAdditionalQualifiers(childElement, sequence2.Items, stringLengthElements, dbTypeElements, dbScaleElements);
                            }
                        }
                    }
                    else
                    {
                        string elementKey = ElementKey(childElement);
                        XmlSchemaSimpleType useSimpleType = simpleType;
                        XmlSchemaSimpleTypeUnion union = simpleType.Content as XmlSchemaSimpleTypeUnion;
                        if (union != null)
                        {
                            if (union.BaseMemberTypes.Length == 2)
                            {
                                bool isAsteriskType = false;
                                XmlSchemaSimpleType simpleTypeToUse = null;
                                for (int i = 0; i < union.BaseMemberTypes.Length; ++i)
                                {
                                    XmlSchemaSimpleType simpleTypeCheck = union.BaseMemberTypes[i];
                                    if (simpleTypeCheck.Name == "AsteriskType")
                                    {
                                        isAsteriskType = true;
                                    }
                                    else
                                    {
                                        XmlSchemaSimpleTypeRestriction restrictionCheck = simpleTypeCheck.Content as XmlSchemaSimpleTypeRestriction;
                                        if (restrictionCheck != null)
                                        {
                                            simpleTypeToUse = simpleTypeCheck;
                                        }
                                    }
                                }
                                if (isAsteriskType && (simpleTypeToUse != null))
                                {
                                    if (simpleTypeToUse.Datatype.ValueType == typeof(string))
                                    {
                                        // Fall through to code below
                                        useSimpleType = simpleTypeToUse;
                                    }
                                    else if (simpleTypeToUse.Datatype.ValueType == typeof(decimal))
                                    {
                                        if ((simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.Int) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.Integer) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.NegativeInteger) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.NonNegativeInteger) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.NonPositiveInteger) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.PositiveInteger) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.UnsignedInt) ||
                                             (simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.GYear))
                                        {
                                            DbType presentType;
                                            if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                            {
                                                DebugUtils.AssertDebuggerBreak(presentType == DbType.Int32);
                                            }
                                            else
                                            {
                                                dbTypeElements.Add(elementKey, DbType.Int32);
                                            }
                                        }
                                        else
                                        {
                                            DbType presentType;
                                            if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                            {
                                                DebugUtils.AssertDebuggerBreak(presentType == DbType.Decimal);
                                            }
                                            else
                                            {
                                                dbTypeElements.Add(elementKey, DbType.Decimal);
                                            }
                                            XmlSchemaSimpleTypeRestriction restriction = simpleTypeToUse.Content as XmlSchemaSimpleTypeRestriction;

                                            if (restriction != null)
                                            {
                                                int size, scale;
                                                if (ProcessDecimalRestriction(restriction, out size, out scale))
                                                {
                                                    KeyValuePair<int, int> dbScale;
                                                    if (dbScaleElements.TryGetValue(elementKey, out dbScale))
                                                    {
                                                        DebugUtils.AssertDebuggerBreak(dbScale.Key == size);
                                                        DebugUtils.AssertDebuggerBreak(dbScale.Value == scale);
                                                    }
                                                    else
                                                    {
                                                        dbScale = new KeyValuePair<int, int>(size, scale);
                                                        dbScaleElements.Add(elementKey, dbScale);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else if (simpleTypeToUse.Datatype.ValueType == typeof(DateTime))
                                    {
                                        if ((simpleTypeToUse.Datatype.TypeCode == XmlTypeCode.GYear))
                                        {
                                            DbType presentType;
                                            if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                            {
                                                DebugUtils.AssertDebuggerBreak(presentType == DbType.Int32);
                                            }
                                            else
                                            {
                                                dbTypeElements.Add(elementKey, DbType.Int32);
                                            }
                                        }
                                        else
                                        {
                                            DbType presentType;
                                            if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                            {
                                                DebugUtils.AssertDebuggerBreak(presentType == DbType.Date);
                                            }
                                            else
                                            {
                                                dbTypeElements.Add(elementKey, DbType.Date);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (useSimpleType != null)
                        {
                            if (useSimpleType.Datatype.ValueType == typeof(string))
                            {
                                if ((useSimpleType.Datatype.TypeCode == XmlTypeCode.GYear))
                                {
                                    DbType presentType;
                                    if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                    {
                                        DebugUtils.AssertDebuggerBreak(presentType == DbType.Int32);
                                    }
                                    else
                                    {
                                        dbTypeElements.Add(elementKey, DbType.Int32);
                                    }
                                }
                                else
                                {
                                    XmlSchemaSimpleTypeRestriction restriction = useSimpleType.Content as XmlSchemaSimpleTypeRestriction;

                                    if (restriction != null)
                                    {
                                        ProcessStringRestriction(elementKey, restriction, stringLengthElements);
                                    }
                                }
                            }
                            else if (useSimpleType.Datatype.ValueType == typeof(decimal))
                            {
                                if ((useSimpleType.Datatype.TypeCode == XmlTypeCode.Int) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.Integer) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.NegativeInteger) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.NonNegativeInteger) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.NonPositiveInteger) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.PositiveInteger) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.UnsignedInt) ||
                                     (useSimpleType.Datatype.TypeCode == XmlTypeCode.GYear))
                                {
                                    DbType presentType;
                                    if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                    {
                                        DebugUtils.AssertDebuggerBreak(presentType == DbType.Int32);
                                    }
                                    else
                                    {
                                        dbTypeElements.Add(elementKey, DbType.Int32);
                                    }
                                }
                            }
                            else if (useSimpleType.Datatype.ValueType == typeof(DateTime))
                            {
                                if ((useSimpleType.Datatype.TypeCode == XmlTypeCode.GYear))
                                {
                                    DbType presentType;
                                    if (dbTypeElements.TryGetValue(elementKey, out presentType))
                                    {
                                        DebugUtils.AssertDebuggerBreak(presentType == DbType.Int32);
                                    }
                                    else
                                    {
                                        dbTypeElements.Add(elementKey, DbType.Int32);
                                    }
                                }
                            }
                            else if (useSimpleType.Datatype.ValueType == typeof(object))
                            {
                                //switch (useSimpleType.Name)
                                //{
                                //    case "Decimal10FloatingType":
                                //}
                            }
                        }
                    }
                }
            }
        }

        // Remove all the attributes from each type in the CodeNamespace, except
        // System.Xml.Serialization.XmlTypeAttribute
        private void RemoveAttributes(CodeNamespace codeNamespace)
        {
            foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
            {
                CodeAttributeDeclaration xmlTypeAttribute = null;
                foreach (CodeAttributeDeclaration codeAttribute in codeType.CustomAttributes)
                {
                    Console.WriteLine(codeAttribute.Name);
                    if (codeAttribute.Name == "System.Xml.Serialization.XmlTypeAttribute")
                    {
                        xmlTypeAttribute = codeAttribute;
                    }
                }
                codeType.CustomAttributes.Clear();
                if (xmlTypeAttribute != null)
                {
                    codeType.CustomAttributes.Add(xmlTypeAttribute);
                }
            }
        }
    }
}
