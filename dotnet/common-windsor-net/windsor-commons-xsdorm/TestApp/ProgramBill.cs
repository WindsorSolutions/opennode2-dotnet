#define USE_WINDSOR_XSDORM_CLASSES
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSPlugin.P2R;
using System.Reflection;
using springdata = Spring.Data.Common;
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

namespace Windsor.Commons.XsdOrm.TestApp
{
    class ProgramBill
    {
        static void Main(string[] args)
        {
            DoICISNPDES_3_Bill();
        }

        static void DoICISNPDES_3_Bill()
        {
            SerializationUtils serializationUtils = new SerializationUtils();
            IObjectsFromDatabase objectsFromDatabase = new ObjectsFromDatabase();

            springdata.IDbProvider dbProvider;
            dbProvider = springdata.DbProviderFactory.GetDbProvider("System.Data.OracleClient");
            dbProvider.ConnectionString = @"data source= (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = ORA11G)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)  (SID = orcl)));user id=ICS_FLOW_ICIS_WA; password=zRitE6giwvtO87r6mv2P;";

            SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

            string tempPath = @"C:\DOWNLOAD\TEST_XSD_ORM";

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            List<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.BasicPermitData> list =
                objectsFromDatabase.LoadFromDatabase<Windsor.Node2008.WNOSPlugin.ICISNPDES_31.BasicPermitData>(springBaseDao, selectClauses);

            foreach (Windsor.Node2008.WNOSPlugin.ICISNPDES_31.BasicPermitData item in list)
            {
                string name = "icis.xml";
                string path;
                byte[] serializedXml;

                path = Path.Combine(tempPath, name);

                Windsor.Node2008.WNOSPlugin.ICISNPDES_31.BiosolidsPermitData data =
                               new Windsor.Node2008.WNOSPlugin.ICISNPDES_31.BiosolidsPermitData();

                serializedXml = serializationUtils.Serialize(data);

                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                fs.Write(serializedXml, 0, serializedXml.Length);
                fs.Close();

                
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
    }
}
