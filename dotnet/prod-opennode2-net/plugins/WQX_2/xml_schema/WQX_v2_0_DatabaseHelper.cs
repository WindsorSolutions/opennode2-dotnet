using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Windsor.Commons.Compression;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSPlugin.WQX2XsdOrm;


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

            if (CollectionUtils.IsNullOrEmpty(dataList) || dataList.Count == 0)
            {
                return null;
            }
            else if (dataList.Count > 1)
            {
                throw new ArgumentException(string.Format("More than one set of data was found for WQX organization '{0}'", organizationIdentifier));
            }
            else
            {
                WQXDataType data = dataList[0];
                appendAuditLogEvent.AppendAuditLogEvent("Found {0} Projects, {1} Monitoring Locations, {2} Biological Habitat Indexes, {3} Activities, {4} Activity Groups, and {5} Results that matched the query",
                                    CollectionUtils.Count(data.Organization.Project).ToString(),
                                    CollectionUtils.Count(data.Organization.MonitoringLocation).ToString(),                                    
                                    CollectionUtils.Count(data.Organization.BiologicalHabitatIndex).ToString(),
                                    CollectionUtils.Count(data.Organization.Activity).ToString(),
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

            if (wqx == null)
                return null;

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
                    appendAuditLogEvent.AppendAuditLogEvent("Wrote attachment files to temp folder.");

                    appendAuditLogEvent.AppendAuditLogEvent("Compressing WQX xml data file and attachments ...");
                    compressionHelper.CompressDirectory(zipXmlFilePath, tempFolderPath);
                    appendAuditLogEvent.AppendAuditLogEvent("Compressed WQX xml data file and attachments.");

                }
                catch (Exception ex)
                {
                    FileUtils.SafeDeleteFile(zipXmlFilePath);
                    throw ex;
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

            if (org.Activity != null) {

                CollectionUtils.ForEach(org.Activity, delegate(ActivityDataType activity)
                {
                    if (activity.AttachedBinaryObject != null)
                    {
                        CollectionUtils.ForEach(activity.AttachedBinaryObject, delegate(ActivityAttachedBinaryObjectDataType attachment)
                        {

                            if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                            {
                                throw new ArgException("An attachment for the activity with id \"{0}\" does not have an attachment name.",
                                                            activity.ActivityDescription.ActivityIdentifier);
                            }
                            string fileName = MakeEmbeddedNameForAttachedFile(activity.ActivityDescription.ActivityIdentifier, attachment.BinaryObjectFileName);
                            string filePath = Path.Combine(folderPath, fileName);
                            if (File.Exists(filePath))
                            {
                                throw new ArgException("Failed to write the attachment \"{0}\" for the activity with id \"{1}\" because another file with the same name already exists in the temporary folder: \"{2}\"",
                                                       attachment.BinaryObjectFileName, activity.ActivityDescription.ActivityIdentifier, filePath);
                            }
                            byte[] content = null;
                            baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT BINARYOBJECTCONTENT FROM WQX_ACTATTACHEDBINARYOBJECT WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                         delegate(IDataReader dataReader)
                                                         {
                                                             content = (byte[])dataReader.GetValue(0);
                                                         }, activity.ActivityDescription.ActivityIdentifier, attachment.BinaryObjectFileName);

                            if (content == null)
                            {
                                throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the activity with id \"{1}\"",
                                                       attachment.BinaryObjectFileName, activity.ActivityDescription.ActivityIdentifier);
                            }
                            UncompressFile(content, filePath);                           
                        });
                    }
                });
            };

            if (org.Project != null)
            {
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
                            UncompressFile(content, filePath);
                        });
                    }
                });
            }

            if (org.MonitoringLocation != null)
            {
                CollectionUtils.ForEach(org.MonitoringLocation, delegate(MonitoringLocationDataType monitoringLocation)
                {
                    if (monitoringLocation.AttachedBinaryObject != null)
                    {
                        CollectionUtils.ForEach(monitoringLocation.AttachedBinaryObject, delegate(MonitoringLocationAttachedBinaryObjectDataType attachment)
                        {

                            if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                            {
                                throw new ArgException("An attachment for the monitoring location \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                            monitoringLocation.WellInformation, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier);
                            }
                            string fileName = MakeEmbeddedNameForAttachedFile(monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier, attachment.BinaryObjectFileName);
                            string filePath = Path.Combine(folderPath, fileName);
                            if (File.Exists(filePath))
                            {
                                throw new ArgException("Failed to write the attachment \"{0}\" for the monitoring location \"{1}\" with id \"{2}\" because another file with the same name already exists in the temporary folder: \"{3}\"",
                                                       attachment.BinaryObjectFileName, monitoringLocation.WellInformation, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier, filePath);
                            }
                            byte[] content = null;
                            baseDao.DoJDBCQueryWithRowCallbackDelegate("SELECT BINARYOBJECTCONTENT FROM WQX_MONLOCATTACHEDBINARYOBJECT WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                         delegate(IDataReader dataReader)
                                                         {
                                                             content = (byte[])dataReader.GetValue(0);
                                                         }, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier, attachment.BinaryObjectFileName);

                            if (content == null)
                            {
                                throw new ArgException("Failed to load attachment content for the file \"{0}\" from the database for the monitoring location \"{1}\" with id \"{2}\"",
                                                       attachment.BinaryObjectFileName, monitoringLocation.WellInformation, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier);
                            }
                            UncompressFile(content, filePath);
                        });
                    }
                });
            }
            
        }

        public static string MakeEmbeddedNameForAttachedFile(string parentId, string attachedFileName)
        {
            string name = string.Format("{0}_{1}", parentId, attachedFileName);
            name = FileUtils.ReplaceInvalidFilenameChars(name, "%");
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

        public static WQXDataType GenerateWqxObjectsFromSubmissionFile(IAppendAuditLogEvent appendAuditLogEvent, string submissionFilePath,
                                                               string sysTempFolderPath, ISerializationHelper serializationHelper,
                                                               ICompressionHelper compressionHelper, out string attachmentsFolderPath)
        {
            string validationErrorsFile;
            return GenerateWqxObjectsFromSubmissionFile(appendAuditLogEvent, submissionFilePath, sysTempFolderPath, null, null, null,
                                                        serializationHelper, compressionHelper, out attachmentsFolderPath,
                                                        out validationErrorsFile);
        }
        public static WQXDataType GenerateWqxObjectsFromSubmissionFile(IAppendAuditLogEvent appendAuditLogEvent, string submissionFilePath,
                                                               string sysTempFolderPath, Assembly xmlSchemaZippedResourceAssembly,
                                                               string xmlSchemaZippedQualifiedResourceName, string xmlSchemaRootFileName,
                                                               ISerializationHelper serializationHelper, ICompressionHelper compressionHelper,
                                                               out string attachmentsFolderPath, out string validationErrorsFile)
        {
            WQXDataType data = null;
            attachmentsFolderPath = null;
            string wqxFilePath = null;
            validationErrorsFile = null;            

            try
            {
                attachmentsFolderPath = Path.Combine(sysTempFolderPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(attachmentsFolderPath);

                appendAuditLogEvent.AppendAuditLogEvent("Decompressing the WQX data to a temporary folder ...");
                try
                {
                    compressionHelper.UncompressDirectory(submissionFilePath, attachmentsFolderPath);
                }
                catch (Exception ex)
                {
                    throw new ArgException("An error occurred decompressing the WQX data: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
                }
                string[] xmlFiles = Directory.GetFiles(attachmentsFolderPath, "*.xml");
                if (xmlFiles.Length == 0)
                {
                    throw new ArgException("Failed to locate an WQX xml file in the WQX data");
                }
                else if (xmlFiles.Length > 1)
                {
                    throw new ArgException("More than one xml file was found in the WQX data");
                }
                wqxFilePath = xmlFiles[0];

                if (!string.IsNullOrEmpty(xmlSchemaZippedQualifiedResourceName))
                {
                    validationErrorsFile =
                        BaseWNOSPlugin.ValidateXmlFile(wqxFilePath, xmlSchemaZippedResourceAssembly, xmlSchemaZippedQualifiedResourceName,
                                                       xmlSchemaRootFileName, sysTempFolderPath, appendAuditLogEvent, compressionHelper);

                    if (validationErrorsFile != null)
                    {
                        FileUtils.SafeDeleteDirectory(attachmentsFolderPath);
                        return null;
                    }
                }

                appendAuditLogEvent.AppendAuditLogEvent("Deserializing the WQX data xml file ...");
                try
                {
                    data = serializationHelper.Deserialize<WQXDataType>(wqxFilePath);
                }
                catch (Exception ex)
                {
                    appendAuditLogEvent.AppendAuditLogEvent("Failed to deserialize the WQX data xml file: {0}", ExceptionUtils.GetDeepExceptionMessage(ex));
                    throw;
                }
                if (data == null)
                {
                    appendAuditLogEvent.AppendAuditLogEvent("The WQX data does not contain any organizations, so no elements will be stored in the database.");
                    return null;
                }                
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteDirectory(attachmentsFolderPath);
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(wqxFilePath);
            }
            
            return data;
        }

        public static void DeleteFromStagingTables(SpringBaseDao baseDao)
        {
            int count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_RESULTDETECTQUANTLIMIT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_RESULTATTACHEDBINARYOBJECT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_LABSAMPLEPREP WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_RESULT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_PROJECTACTIVITY WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTATTACHEDBINARYOBJECT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTIVITYACTIVITYGROUP WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTIVITYCONDUCTINGORG WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTIVITYGROUP WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTIVITYMETRIC WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ACTIVITY WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_BIOLOGICALHABITATINDEX WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_PROJECTMONLOC WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_PROJATTACHEDBINARYOBJECT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_PROJECT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_MONLOCATTACHEDBINARYOBJECT WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ALTMONLOC WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_MONITORINGLOCATION WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ORGADDRESS WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_TELEPHONIC WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ELECTRONICADDRESS WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_DELETES WHERE 1=1 ");
                count = baseDao.DoJDBCExecuteNonQuery("	DELETE FROM WQX_ORGANIZATION WHERE 1=1 ");
        }
        
        public static string StoreWqxDataToDatabase(IAppendAuditLogEvent appendAuditLogEvent, WQXDataType data, IObjectsToDatabase objectsToDatabase,
                                                    SpringBaseDao baseDao, string attachmentsFolderPath)
        {
            appendAuditLogEvent.AppendAuditLogEvent("Storing WQX data into the database ...");

            string countsString = string.Empty;

            baseDao.TransactionTemplate.Execute(delegate(Spring.Transaction.ITransactionStatus status)
            {
                OrganizationDataType org = data.Organization;
                                
                appendAuditLogEvent.AppendAuditLogEvent("Storing WQX data into database for organization \"{0}\" ...", org.OrganizationDescription.OrganizationFormalName);

                appendAuditLogEvent.AppendAuditLogEvent(DatabaseHelper.GetWqxOrgCountsString(org));

                Dictionary<string, int> insertCounts = objectsToDatabase.SaveToDatabase(data, baseDao);

                DatabaseHelper.StoreAttachmentFilesFromFolder(objectsToDatabase, baseDao, data.Organization, attachmentsFolderPath);

                countsString += string.Format("Stored WQX data for organization \"{0}\" into the database with the following table row counts:{1}{2}",
                                                  org.OrganizationDescription.OrganizationFormalName, Environment.NewLine, CreateTableRowCountsString(insertCounts));

                appendAuditLogEvent.AppendAuditLogEvent(countsString);
                
                return null;
            });
            return countsString;
        }

        public static void StoreAttachmentFilesFromFolder(IObjectsToDatabase objectsToDatabase, SpringBaseDao baseDao, OrganizationDataType data, string folderPath)
        {
            if (data.Activity != null)
            {
                foreach (ActivityDataType activity in data.Activity)
                {
                    if (activity.AttachedBinaryObject != null)
                    {
                        foreach (AttachedBinaryObjectDataType attachment in activity.AttachedBinaryObject)
                        {
                            if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                            {
                                throw new ArgException("An attachment for the activity with id \"{0}\" does not have an attachment name.",
                                                            activity.ActivityDescription.ActivityIdentifier);
                            }

                            string fileName = MakeEmbeddedNameForAttachedFile(activity.ActivityDescription.ActivityIdentifier, attachment.BinaryObjectFileName);
                            string filePath = Path.Combine(folderPath, fileName);
                            if (!File.Exists(filePath))
                            {
                                throw new ArgException("Failed to locate an attachment with the name \"{0}\" for the activity \"{1}\" with id \"{2}\" in the temporary folder: \"{3}\"",
                                                       fileName, attachment.BinaryObjectFileName, activity.ActivityDescription.ActivityIdentifier, filePath);
                            }

                            byte[] content = File.ReadAllBytes(filePath);

                            int updateCount = baseDao.DoJDBCExecuteNonQuery("UPDATE WQX_ACTATTACHEDBINARYOBJECT SET BINARYOBJECTCONTENT = ? WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                                            content, activity.RecordId, attachment.BinaryObjectFileName);
                            if (updateCount == 0)
                            {
                                throw new ArgException("Failed to update the content for an attachment with the name \"{0}\" for the activity with id \"{1}\"",
                                                        attachment.BinaryObjectFileName, activity.ActivityDescription.ActivityIdentifier);
                            }
                            
                        }
                    }
                }
            }

            if (data.MonitoringLocation != null)
            {
                foreach (MonitoringLocationDataType monitoringLocation in data.MonitoringLocation)
                {
                    if (monitoringLocation.AttachedBinaryObject != null)
                    {
                        foreach (AttachedBinaryObjectDataType attachment in monitoringLocation.AttachedBinaryObject)
                        {
                            if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                            {
                                throw new ArgException("An attachment for the monitoring location \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                        monitoringLocation.WellInformation, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier);
                            }

                            string fileName = MakeEmbeddedNameForAttachedFile(monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier, attachment.BinaryObjectFileName);
                            string filePath = Path.Combine(folderPath, fileName);
                            if (!File.Exists(filePath))
                            {
                                throw new ArgException("Failed to locate an attachment with the name \"{0}\" for the monitoring location \"{1}\" with id \"{2}\" in the temporary folder: \"{3}\"",
                                                       fileName, monitoringLocation.WellInformation, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier, filePath);
                            }

                            byte[] content = File.ReadAllBytes(filePath);

                            int updateCount = baseDao.DoJDBCExecuteNonQuery("UPDATE WQX_MONLOCATTACHEDBINARYOBJECT SET BINARYOBJECTCONTENT = ? WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                                            content, monitoringLocation.RecordId, attachment.BinaryObjectFileName);
                            if (updateCount == 0)
                            {
                                throw new ArgException("Failed to update the content for an attachment with the name \"{0}\" for the monitoring location \"{1}\" with id \"{2}\"",
                                                        fileName, attachment.BinaryObjectFileName, monitoringLocation.MonitoringLocationIdentity.MonitoringLocationIdentifier);
                            }
                        }
                    }
                }
            }

            if (data.Project != null)
            {
                foreach (ProjectDataType project in data.Project)
                {
                    if (project.AttachedBinaryObject != null)
                    {
                        foreach (AttachedBinaryObjectDataType attachment in project.AttachedBinaryObject)
                        {
                            if (string.IsNullOrEmpty(attachment.BinaryObjectFileName))
                            {
                                throw new ArgException("An attachment for the project \"{0}\" with id \"{1}\" does not have an attachment name.",
                                                        project.ProjectDescriptionText, project.ProjectIdentifier);
                            }

                            string fileName = MakeEmbeddedNameForAttachedFile(project.ProjectIdentifier, attachment.BinaryObjectFileName);
                            string filePath = Path.Combine(folderPath, fileName);
                            if (!File.Exists(filePath))
                            {
                                throw new ArgException("Failed to locate an attachment with the name \"{0}\" for the project \"{1}\" with id \"{2}\" in the temporary folder: \"{3}\"",
                                                       fileName, project.ProjectDescriptionText, project.ProjectIdentifier, filePath);
                            }

                            byte[] content = File.ReadAllBytes(filePath);

                            int updateCount = baseDao.DoJDBCExecuteNonQuery("UPDATE WQX_PROJATTACHEDBINARYOBJECT SET BINARYOBJECTCONTENT = ? WHERE PARENTID = ? AND BINARYOBJECTFILE = ?",
                                                                            content, project.RecordId, attachment.BinaryObjectFileName);
                            if (updateCount == 0)
                            {
                                throw new ArgException("Failed to update the content for an attachment with the name \"{0}\" for the project \"{1}\" with id \"{2}\"",
                                                        fileName, attachment.BinaryObjectFileName, project.ProjectIdentifier);
                            }
                        }
                    }
                }
            }            
        }

        private static void AppendCountString(StringBuilder sb, int count, string countName, string countsName, ref int addCount, ref int commaIndex)
        {
            if (count > 0)
            {
                if (addCount > 0)
                {
                    commaIndex = sb.Length;
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} {1}", count.ToString(), (count == 1) ? countName : ((countsName == null) ? countName : countsName));
                ++addCount;
            }
        }

        public static string GetWqxOrgCountsString(OrganizationDataType org)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("WQX data for organization \"{0}\" contains ", org.OrganizationDescription.OrganizationFormalName);

            int collectionActivityCount = CollectionUtils.Count(org.Activity);
            int biologicalHabitatCount = CollectionUtils.Count(org.BiologicalHabitatIndex);            

            int addCount = 0, commaIndex = -1;
            AppendCountString(sb, collectionActivityCount, "Collection Activities", null, ref addCount, ref commaIndex);
            AppendCountString(sb, biologicalHabitatCount, "Biological Habitat Indices", null, ref addCount, ref commaIndex);            

            if (addCount == 0)
            {
                sb.Append("no collection activites or biological habitat indices");
            }
            else if (addCount > 1)
            {
                sb.Replace(", ", " and ", commaIndex, sb.Length - commaIndex);
            }

            return sb.ToString();
        }

        public static string CreateTableRowCountsString(Dictionary<string, int> tableRowCounts)
        {
            if (CollectionUtils.IsNullOrEmpty(tableRowCounts))
            {
                return "None";
            }
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in tableRowCounts)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }
                sb.AppendFormat("{0} ({1})", pair.Key, pair.Value.ToString());
            }
            return sb.ToString();
        }

        public static void UncompressFile(byte[] compressedDocContent, string saveFilePath)
        {
            DotNetZipHelper compressionHelper = new DotNetZipHelper();
            compressionHelper.Uncompress(compressedDocContent, saveFilePath);
        }

        public static string WQX_FILE_PREFIX = "__";

        public const string PARAM_ORGANIZATION_ID_KEY = "OrganizationIdentifier";        
        public const string PARAM_START_DATE_KEY = "StartDate";
        public const string PARAM_END_DATE_KEY = "EndDate";
    }
}
