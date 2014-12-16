using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;
using Wintellect.PowerCollections;


using System.Linq;
using System.Threading;
using Spring.Transaction;
using Spring.Data;
using Spring.Data.Support;
using Spring.Dao;
using System.Data.SqlClient;

namespace Windsor.Node2008.WNOSPlugin.WQX_20
{
    public static class DatabaseHelper
    {
        public static WQXDataType GenerateWqxQueryFromDatabase(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase, SpringBaseDao baseDao,
                                                       string organizationIdentifier)
        {
            ExceptionUtils.ThrowIfNull(objectsFromDatabase);
            ExceptionUtils.ThrowIfNull(baseDao);
            ExceptionUtils.ThrowIfEmptyString(organizationIdentifier);

            appendAuditLogEvent.AppendAuditLogEvent("Querying database for WQX results ...");

            Dictionary<string, DbAppendSelectWhereClause> selectClauses = new Dictionary<string, DbAppendSelectWhereClause>();

            selectClauses.Add("WQX_ORGANIZATION",
                new DbAppendSelectWhereClause(baseDao, "ORGID = ?", organizationIdentifier));


            List<WQXDataType> dataList = objectsFromDatabase.LoadFromDatabase<WQXDataType>(baseDao, selectClauses);

            if (CollectionUtils.IsNullOrEmpty(dataList))
            {
                return new WQXDataType();
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of data was found for WQX organization '{0}'", organizationIdentifier));
            }
            else
            {
                WQXDataType data = dataList[0];
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} Projects, {1} Activities, {2} Biological Habitat Indexes, {3} Monitoring Locations, {4} Activity Groups, and {5} Results that matched the query",
                                    CollectionUtils.Count(data.Organization.Project).ToString(),
                                    CollectionUtils.Count(data.Organization.Activity).ToString(),
                                    CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                    CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),
                                    CollectionUtils.Count(data.Organization.ActivityGroup).ToString(),
                                    TotalResultCount(data).ToString());
                return data;
            }
            
        }
        public static string GenerateAndValidateWqxQueryFile(IAppendAuditLogEvent appendAuditLogEvent, IObjectsFromDatabase objectsFromDatabase, SpringBaseDao baseDao, 
                                                             string queryOrganizationIdentifier, string sysTempFolderPath, 
                                                             Assembly xmlSchemaZippedResourceAssembly, string xmlSchemaZippedQualifiedResourceName,
                                                             string xmlSchemaRootFileName, ISerializationHelper serializationHelper, ICompressionHelper compressionHelper,
                                                             out string validationErrorsFile)
        {
            validationErrorsFile = null;

            WQXDataType wqx = GenerateWqxQueryFromDatabase(appendAuditLogEvent, objectsFromDatabase, baseDao, queryOrganizationIdentifier);
            
            appendAuditLogEvent.AppendAuditLogEvent("Generating WQX xml file from query results ...");
            string tempFolderPath = Path.Combine(sysTempFolderPath, Guid.NewGuid().ToString());

            string fileName = Guid.NewGuid().ToString();
            string tempXmlFilePath = Path.Combine(tempFolderPath, WQX_FILE_PREFIX + fileName + ".xml");
            string zipXmlFilePath = Path.ChangeExtension(Path.Combine(sysTempFolderPath, fileName), ".zip");
            Directory.CreateDirectory(tempFolderPath);

            try
            {
                serializationHelper.Serialize(wqx, tempXmlFilePath);

                appendAuditLogEvent.AppendAuditLogEvent("Generated WQX xml file from query results");

                validationErrorsFile =
                    BaseWNOSPlugin.ValidateXmlFile(tempXmlFilePath, xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
                                                   xmlSchemaRootFileName, sysTempFolderPath, appendAuditLogEvent, compressionHelper);

                if (validationErrorsFile != null)
                {
                    compressionHelper.CompressFile(tempXmlFilePath, zipXmlFilePath);
                    return zipXmlFilePath;
                }

                try
                {
                    appendAuditLogEvent.AppendAuditLogEvent("Writing attachment files to temp folder ...");

                    DatabaseHelper.WriteAttachmentFilesToFolder(baseDao, wqx, tempFolderPath);

                    appendAuditLogEvent.AppendAuditLogEvent("Compressing WQX xml data file and attachments ...");

                    compressionHelper.CompressDirectory(zipXmlFilePath, tempFolderPath);
                }
                catch (Exception)
                {
                    FileUtils.SafeDeleteFile(zipXmlFilePath);
                    throw;
                }
                finally
                {
                    FileUtils.SafeDeleteDirectory(tempFolderPath);
                }

                return zipXmlFilePath;
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
                throw;
            }
        }

        public static void WriteAttachmentFilesToFolder(SpringBaseDao baseDao, WQXDataType data, string folderPath)
        {
            OrganizationDataType org = data.Organization;

            CollectionUtils.ForEach(org.Activity, delegate(ActivityDataType activity)
            {
                if (activity.AttachedBinaryObject != null)
                {
                    CollectionUtils.ForEach(activity.AttachedBinaryObject, delegate(ActivityAttachedBinaryObjectDataType attachment)
                    {

                        if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                        {
                            throw new ArgException("An attachment for the activity \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                        activity.ActivityDescription, activity.RecordId);
                        }
                        string fileName = MakeEmbeddedNameForAttachedFile(activity.RecordId, attachment.BinaryObjectFileName);
                        string filePath = Path.Combine(folderPath, fileName);
                        if (File.Exists(filePath))
                        {
                            throw new ArgException("Failed to write the attachment \"{0}\" for the activity \"{1}\" with id \"{2}\" because another file with the same name already exists in the temporary folder: \"{3}\"",
                                                   attachment.BinaryObjectFileName, activity.ActivityDescription, activity.RecordId, filePath);
                        }
                        byte[] content = null;
                        baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT BINARYOBJECTCONTENT FROM WQX_ACTATTACHEDBINARYOBJECT WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                     delegate(IDataReader dataReader)
                                                     {
                                                         content = (byte[])dataReader.GetValue(0);
                                                     }, activity.RecordId, attachment.BinaryObjectFileName);

                        if (content == null)
                        {
                            throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the activity \"{1}\" with id \"{2}\"",
                                                   attachment.BinaryObjectFileName, activity.ActivityDescription, activity.RecordId);
                        }
                        File.WriteAllBytes(filePath, content);
                    });
                }
            }); 

            CollectionUtils.ForEach(org.Project, delegate(ProjectDataType project)
            {
                if (project.AttachedBinaryObject != null)
                {
                    CollectionUtils.ForEach(project.AttachedBinaryObject, delegate(ProjectAttachedBinaryObjectDataType attachment)
                    {

                        if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                        {
                            throw new ArgException("An attachment for the project \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                        project.ProjectName, project.ProjectIdentifier);
                        }
                        string fileName = MakeEmbeddedNameForAttachedFile(project.ProjectIdentifier, attachment.BinaryObjectFileName);
                        string filePath = Path.Combine(folderPath, fileName);
                        if (File.Exists(filePath))
                        {
                            throw new ArgException("Failed to write the attachment \"{0}\" for the project \"{1}\" with id \"{2}\" because another file with the same name already exists in the temporary folder: \"{3}\"",
                                                    attachment.BinaryObjectFileName, project.ProjectName, project.ProjectIdentifier, filePath);
                        }
                        byte[] content = null;
                        baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT BINARYOBJECTCONTENT FROM WQX_PROJATTACHEDBINARYOBJECT WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                        delegate(IDataReader dataReader)
                                                        {
                                                            content = (byte[])dataReader.GetValue(0);
                                                        }, project.ProjectIdentifier, attachment.BinaryObjectFileName);

                        if (content == null)
                        {
                            throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the project \"{1}\" with id \"{2}\"",
                                                    attachment.BinaryObjectFileName, project.ProjectName, project.ProjectIdentifier);
                        }
                        File.WriteAllBytes(filePath, content);
                    });
                }
            });

            CollectionUtils.ForEach(org.MonitoringLocation, delegate(MonitoringLocationDataType monitoringLocation)
            {
                if (monitoringLocation.AttachedBinaryObject != null)
                {
                    CollectionUtils.ForEach(monitoringLocation.AttachedBinaryObject, delegate(MonitoringLocationAttachedBinaryObjectDataType attachment)
                    {

                        if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                        {
                            throw new ArgException("An attachment for the monitoring location \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                        monitoringLocation.WellInformation, monitoringLocation.RecordId);
                        }
                        string fileName = MakeEmbeddedNameForAttachedFile(monitoringLocation.RecordId, attachment.BinaryObjectFileName);
                        string filePath = Path.Combine(folderPath, fileName);
                        if (File.Exists(filePath))
                        {
                            throw new ArgException("Failed to write the attachment \"{0}\" for the monitoring location \"{1}\" with id \"{2}\" because another file with the same name already exists in the temporary folder: \"{3}\"",
                                                   attachment.BinaryObjectFileName, monitoringLocation.WellInformation, monitoringLocation.RecordId, filePath);
                        }
                        byte[] content = null;
                        baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT BINARYOBJECTCONTENT FROM WQX_MONLOCATTACHEDBINARYOBJECT WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                     delegate(IDataReader dataReader)
                                                     {
                                                         content = (byte[])dataReader.GetValue(0);
                                                     }, monitoringLocation.RecordId, attachment.BinaryObjectFileName);

                        if (content == null)
                        {
                            throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the monitoring location \"{1}\" with id \"{2}\"",
                                                   attachment.BinaryObjectFileName, monitoringLocation.WellInformation, monitoringLocation.RecordId);
                        }
                        File.WriteAllBytes(filePath, content);
                    });
                }
            }); 
            
        }

        public static string MakeEmbeddedNameForAttachedFile(string parentId, string attachedFileName)
        {
            string name = string.Format("{0}_{1}", parentId, attachedFileName);
            name = FileUtils.ReplaceInvalidFilenameChars(name, "%%%");
            return name;
        }

        public static int TotalResultCount(WQXDataType data)
        {
            int count = 0;
            if ((data != null) && (data.Organization != null) && (data.Organization.Activity != null))
            {
                foreach (Windsor.Node2008.WNOSPlugin.WQX2XsdOrm.ActivityDataType activity in data.Organization.Activity)
                {
                    count += (activity.Result == null) ? 0 : activity.Result.Length;
                }
            }
            return count;
        }

        public static string WQX_FILE_PREFIX = "__";
        
    }
}
