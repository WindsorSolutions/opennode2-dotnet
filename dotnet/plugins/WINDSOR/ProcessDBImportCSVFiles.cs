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
using System.IO;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSProviders;
using System.Diagnostics;
using System.Reflection;
using Spring.Data.Common;
using Microsoft.VisualBasic.FileIO;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.Windsor
{

    public static class ProcessDBImportCSVFiles
    {
        #region fields
        private const string COMMA = ",";
        private const string SEMICOLON = ";";
        #endregion

        public static string ProcessImportFile(string importFolder, string archiveFolder, string errorFolder,
                                               string importCSVFileSearchPattern, string importFileSearchToDBTableNamePattern,
                                               string cleanupTablesStoredProcName, string endProcessingStoredProcName, 
                                               SpringBaseDao baseDao, string tempFolderPath,
                                               ICompressionHelper compressionHelper, out bool success, out bool foundFile)
        {
            StringBuilder statusString = new StringBuilder();
            string tempOutputDir = null;
            success = false;
            foundFile = false;
            string importZipFile = null;
            try
            {
                ValidateFolder(importFolder, false);
                ValidateFolder(archiveFolder, true);
                ValidateFolder(errorFolder, true);

                importZipFile = FileUtils.GetOldestFile(importFolder, "*.zip", false);
                if (string.IsNullOrEmpty(importZipFile))
                {
                    OutputStatus(statusString, "Did not find any files to process within the import folder \"{0}\", stopping thread execution ...",
                                 importFolder);
                    success = true;
                    return statusString.ToString();
                }
                foundFile = true;

                OutputStatus(statusString, "Extracting import files from the zip file \"{0}\"", importZipFile);
                IList<string> importCSVFiles = GetImportFiles(importZipFile, importCSVFileSearchPattern, tempFolderPath,
                                                              compressionHelper);
                OutputStatus(statusString, "Extracted {0} import files", importCSVFiles.Count.ToString());
                tempOutputDir = Path.GetDirectoryName(importCSVFiles[0]);

                CallStoredProc(cleanupTablesStoredProcName, baseDao, statusString);

                baseDao.TransactionTemplate.Execute(delegate
                {
                    foreach (string importFilePath in importCSVFiles)
                    {
                        string fileName = Path.GetFileName(importFilePath);
                        OutputStatus(statusString, "Processing import file \"{0}\"", fileName);
                        string dbTableName = GetDBTableName(importFilePath, importCSVFileSearchPattern, importFileSearchToDBTableNamePattern);
                        OutputStatus(statusString, "Determined DB table name of \"{0}\" for input file \"{1}\"",
                                                              dbTableName, fileName);
                        using (TextFieldParser textFieldParser = new TextFieldParser(importFilePath))
                        {
                            textFieldParser.TextFieldType = FieldType.Delimited;
                            textFieldParser.Delimiters = new string[] { COMMA };
                            string[] columnNames = textFieldParser.ReadFields();
                            if (CollectionUtils.IsNullOrEmpty(columnNames))
                            {
                                throw new FileNotFoundException(string.Format("No column names were found in the CSV file \"{0}\"",
                                                                              fileName));
                            }
                            string semicolonSeparatedColumnNames = string.Join(SEMICOLON, columnNames);
                            OutputStatus(statusString, "Determined {0} insert column names as \"{1}\" for DB table \"{2}\"",
                                                                  columnNames.Length.ToString(), semicolonSeparatedColumnNames,
                                                                  dbTableName);
                            object[] insertValues = new object[columnNames.Length];
                            int totalRows = 0;
                            baseDao.DoBulkInsert(dbTableName, semicolonSeparatedColumnNames,
                                                 delegate(int currentInsertIndex)
                                                 {
                                                     if (textFieldParser.EndOfData)
                                                     {
                                                         return null;
                                                     }
                                                     string[] columnValues;
                                                     try
                                                     {
                                                         columnValues = textFieldParser.ReadFields();
                                                         if (columnValues.Length != insertValues.Length)
                                                         {
                                                             throw new InvalidDataException(string.Format("The CSV file \"{0}\" does not contain a valid number of column values at row {1}: {2} values expected and {3} values found",
                                                                                                           fileName, (currentInsertIndex + 1).ToString(),
                                                                                                           insertValues.Length.ToString(), columnValues.Length.ToString()));
                                                         }
                                                     }
                                                     catch (MalformedLineException)
                                                     {
                                                         // This may be caused by single quotes inside the value instead of double quotes.
                                                         // Try to fix up here:
                                                         columnValues = textFieldParser.ErrorLine.Split(',');
                                                         if (CollectionUtils.IsNullOrEmpty(columnValues) ||
                                                             (columnValues.Length != insertValues.Length))
                                                         {
                                                             throw;
                                                         }
                                                         for (int j = 0; j < columnValues.Length; ++j)
                                                         {
                                                             string curValue = columnValues[j];
                                                             if ((curValue.Length > 1) && (curValue[0] == '\"') &&
                                                                  (curValue[curValue.Length - 1] == '\"'))
                                                             {
                                                                 columnValues[j] = curValue.Substring(1, curValue.Length - 2);
                                                             }
                                                         }
                                                     }
                                                     for (int i = 0; i < insertValues.Length; ++i)
                                                     {
                                                         insertValues[i] = columnValues[i];
                                                     }
                                                     totalRows++;
                                                     return insertValues;
                                                 });
                            OutputStatus(statusString, "Inserted {0} rows into DB table \"{1}\"",
                                                                  totalRows.ToString(), dbTableName);
                        }
                    }
                    return null;
                });

                CallStoredProc(endProcessingStoredProcName, baseDao, statusString);

                // Finally, move the import zip file to the archive folder
                if (!string.IsNullOrEmpty(archiveFolder))
                {
                    string newFilePath = FileUtils.MoveFileToFolderAppendDateTimeTicksToName(importZipFile, archiveFolder);
                    OutputStatus(statusString, "Moved import file \"{0}\" to \"{1}\"",
                                                          importZipFile, newFilePath);
                }
                success = true;
                OutputStatus(statusString, "Successfully finished processing {0} import files",
                                          importCSVFiles.Count);
            }
            catch (Exception ex)
            {
                OutputStatus(statusString, "ERROR ********************* An error occurred processing the import files: {0}",
                                                      ExceptionUtils.ToLongString(ex));
            }
            finally
            {
                if (tempOutputDir != null)
                {
                    FileUtils.SafeDeleteDirectory(tempOutputDir);
                }
                // Finally, move the import zip file to the archive folder
                if (!success && (importZipFile != null) && !string.IsNullOrEmpty(errorFolder))
                {
                    try
                    {
                        string newFilePath = FileUtils.MoveFileToFolderAppendDateTimeTicksToName(importZipFile, errorFolder);
                        OutputStatus(statusString, "Moved import file \"{0}\" to \"{1}\"",
                                                              importZipFile, newFilePath);
                    }
                    catch (Exception ex3)
                    {
                        OutputStatus(statusString, "Failed to move import file \"{0}\" to folder \"{1}\": {2}",
                                                             importZipFile, errorFolder, ExceptionUtils.ToLongString(ex3));
                    }
                }
            }
            return statusString.ToString();
        }
        private static void CallStoredProc(string procName, SpringBaseDao baseDao, StringBuilder sb)
        {
            if (string.IsNullOrEmpty(procName))
            {
                OutputStatus(sb, "No stored procedure was specified");
            }
            else
            {
                OutputStatus(sb, "Calling stored procedure \"{0}\"", procName);
                try
                {
                    baseDao.DoStoredProc(procName);
                    OutputStatus(sb, "Successfully called stored procedure \"{0}\"", procName);
                }
                catch (Exception ex)
                {
                    OutputStatus(sb, "Failed to call stored procedure \"{0}\": {1}", procName,
                                 ExceptionUtils.ToLongString(ex));
                    throw;
                }
            }
        }
        private static IList<string> GetImportFiles(string importZipFile, string importCSVFileSearchPattern,
                                                    string tempFolderPath, ICompressionHelper compressionHelper)
        {
            if (string.IsNullOrEmpty(tempFolderPath)) tempFolderPath = Path.GetTempPath();
            if (!Directory.Exists(tempFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The node temporary folder does not exist: {0}",
                                                                   tempFolderPath));
            }
            string outputPath = Path.Combine(tempFolderPath, Guid.NewGuid().ToString());
            Directory.CreateDirectory(outputPath);
            try
            {
                compressionHelper.UncompressDirectory(importZipFile, outputPath);
                string[] fileList = Directory.GetFiles(outputPath, importCSVFileSearchPattern);
                if (CollectionUtils.IsNullOrEmpty(fileList))
                {
                    throw new FileNotFoundException(string.Format("No valid CSV import files were included in the input zip file \"{0}\"",
                                                                  importZipFile));
                }
                return fileList;
            }
            catch (Exception)
            {
                FileUtils.SafeDeleteDirectory(outputPath);
                throw;
            }
        }
        private static void ValidateFolder(string folderPath, bool createFolderIfNotExist)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                if (createFolderIfNotExist)
                {
                    Directory.CreateDirectory(folderPath);
                }
                else
                {
                    throw new DirectoryNotFoundException(string.Format("The folder \"{0}\" does not exist", folderPath));
                }
            }
        }

        /// <summary>
        /// Assumes importCSVFileSearchPattern is something like "Tier2*.mer" and importFileSearchToDBTableNamePattern
        /// is something like "CAMEO_*" so that, given importFile as "Tier2ChemInvMixtures.mer," the return value
        /// would be "CAMEO_ChemInvMixtures."
        /// </summary>
        private static string GetDBTableName(string importFile, string importCSVFileSearchPattern,
                                             string importFileSearchToDBTableNamePattern)
        {
            string fileName = Path.GetFileName(importFile);
            int fileNameWildcardIndex = importCSVFileSearchPattern.IndexOf('*');
            if (fileNameWildcardIndex < 0)
            {
                throw new ArgumentException(string.Format("Invalid CSV search pattern (missing '*' wildcard): {0}",
                                                          importCSVFileSearchPattern));
            }
            int startIndex, endIndex;
            startIndex = fileNameWildcardIndex;
            endIndex = fileName.Length - (importCSVFileSearchPattern.Length - fileNameWildcardIndex);
            if (endIndex < startIndex)
            {
                throw new ArgumentException(string.Format("Invalid filename \"{0}\" for file search pattern \"{1}\"",
                                                          fileName, importCSVFileSearchPattern));
            }
            string baseName = fileName.Substring(startIndex, endIndex - startIndex + 1);
            if (string.IsNullOrEmpty(importFileSearchToDBTableNamePattern))
            {
                return baseName;
            }
            int dbNameWildcardIndex = importFileSearchToDBTableNamePattern.IndexOf('*');
            if (dbNameWildcardIndex < 0)
            {
                throw new ArgumentException(string.Format("Invalid DB table name pattern (missing '*' wildcard): {0}",
                                                         importFileSearchToDBTableNamePattern));
            }
            baseName = string.Format(importFileSearchToDBTableNamePattern.Replace("*", "{0}"), baseName);
            return baseName;
        }
        public static void OutputStatus(StringBuilder sb, string messageFormat, params object[] args)
        {
            if (CollectionUtils.IsNullOrEmpty(args))
            {
                sb.Append(messageFormat + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                sb.AppendFormat(messageFormat + Environment.NewLine + Environment.NewLine, args);
            }
        }
    }
}
