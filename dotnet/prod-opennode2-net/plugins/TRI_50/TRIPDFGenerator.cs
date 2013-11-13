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
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.TRI5
{
    [Serializable]
    public class TRIPDFGenerator : BaseWNOSPlugin, ITaskProcessor
    {
        protected const string CONFIG_OUTPUT_FOLDER_PATH = "Output Folder Path";
        protected const string CONFIG_TRI_VIEWER_BASE_URL = "TRI Viewer Base Url";

        protected const string CONFIG_DATA_SOURCE = "Data Source";

        protected const string PARAM_MAX_NUMBER_OF_FILES_TO_GENERATE = "MaxFilesToGenerate";
        protected const string PARAM_SCALE_PERCENTAGE = "ScalePercentage";
        protected const string PARAM_PAGE_TYPE = "PageType";

        protected const string ID_COLUMN_NAME = "ID";
        protected const string VW_TRI_FILE_CSV_DEFINITION_NAME = "VW_TRI_FILE_CSV_DEFINITION";
        protected const string VW_TRI_PDF_METADATA_NAME = "VW_TRI_PDF_METADATA";
        protected const string App_GeneratedPDF_NAME = "App_GeneratedPDF";

        protected IRequestManager _requestManager;
        protected ISettingsProvider _settingsProvider;

        protected DataRequest _dataRequest;
        protected string _outputFolderPath;
        protected string _viewerBaseUri;
        protected string _pdfGeneratorExePath;
        protected SpringBaseDao _baseDao;
        List<VW_TRI_PDF_METADATA> _pdfMetadataList;
        List<string> _csvColumnNames;
        int _maxFilesToGenerate = int.MaxValue;
        int _scalePercentage = 100;
        string _pageType = "Letter";

        public TRIPDFGenerator()
        {
            ConfigurationArguments.Add(CONFIG_OUTPUT_FOLDER_PATH, null);
            ConfigurationArguments.Add(CONFIG_TRI_VIEWER_BASE_URL, null);

            DataProviders.Add(CONFIG_DATA_SOURCE, null);
        }

        public virtual void ProcessTask(string requestId)
        {
            LazyInit();

            ValidateRequest(requestId);

            _pdfMetadataList = GetPDFMetadataList();

            _csvColumnNames = GetCSVColumnNames();

            if (CollectionUtils.IsNullOrEmpty(_pdfMetadataList))
            {
                return;
            }

            _viewerBaseUri = ValidateHttpUrlConfigParameter(CONFIG_TRI_VIEWER_BASE_URL, 15);
            if (_viewerBaseUri.EndsWith("/"))
            {
                _viewerBaseUri = _viewerBaseUri.Substring(0, _viewerBaseUri.Length - 1);
            }

            _pdfGeneratorExePath = ExtractPDFGeneratorExe();

            int currentFileIndex = 1, maxFileIndex = _pdfMetadataList.Count;
            foreach (var metadata in _pdfMetadataList)
            {
                GeneratePDF(metadata, currentFileIndex++, maxFileIndex);
            }

        }
        protected virtual void LazyInit()
        {
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _settingsProvider);

            _outputFolderPath = ValidateExistingFolderConfigParameter(CONFIG_OUTPUT_FOLDER_PATH);

            _baseDao = ValidateDBProvider(CONFIG_DATA_SOURCE, typeof(NamedNullMappingDataReader));
        }
        protected virtual void ValidateRequest(string requestId)
        {
            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);

            if (TryGetParameter(_dataRequest, PARAM_MAX_NUMBER_OF_FILES_TO_GENERATE, 0, ref _maxFilesToGenerate))
            {
                AppendAuditLogEvent("Maximum number of files to generate: {0}", _maxFilesToGenerate.ToString());
            }
            if (TryGetParameter(_dataRequest, PARAM_SCALE_PERCENTAGE, 1, ref _scalePercentage))
            {
                if ((_scalePercentage < 20) || (_scalePercentage > 200))
                {
                    throw new ArgumentException("The \"{0}\" parameter must be between 20 and 200", PARAM_SCALE_PERCENTAGE);
                }
                AppendAuditLogEvent("Scaling percentage: {0}", _scalePercentage.ToString());
            }
            string pageType = null;
            if (TryGetParameter(_dataRequest, PARAM_PAGE_TYPE, 2, ref pageType))
            {
                if (string.Equals(pageType, "Letter", StringComparison.OrdinalIgnoreCase))
                {
                    _pageType = "Letter";
                }
                else if (string.Equals(pageType, "Legal", StringComparison.OrdinalIgnoreCase))
                {
                    _pageType = "Legal";
                }
                else
                {
                    throw new ArgumentException("The \"{0}\" parameter must be either \"Letter\" or \"Legal\"", PARAM_PAGE_TYPE);
                }
                AppendAuditLogEvent("Page type: {0}", _pageType);
            }
        }
        protected virtual void GeneratePDF(VW_TRI_PDF_METADATA metadata, int currentFileIndex, int maxFileIndex)
        {
            AppendAuditLogEvent("*** Starting PDF generation for file \"{0}\" ({1} of {2} total files)",
                                metadata.PDFFilename, currentFileIndex.ToString(), maxFileIndex.ToString());
            string outputPDFFilePath = null, outputCSVFilePath = null;
            string app_GeneratedPDF_ID = StringUtils.CreateSequentialGuid();
            try
            {
                string documentUri = _viewerBaseUri;
                if (!metadata.FormURL.StartsWith("/"))
                {
                    documentUri += "/";
                }
                documentUri += metadata.FormURL;

                outputPDFFilePath = Path.Combine(_outputFolderPath, metadata.PDFFilename);
                outputCSVFilePath = Path.Combine(_outputFolderPath, metadata.CSVFilename);

                // See http://madalgo.au.dk/~jakobt/wkhtmltoxdoc/wkhtmltopdf-0.9.9-doc.html for command line params

                string commandParams = "-O Portrait -q --disable-external-links --disable-internal-links ";

                commandParams += string.Format("-s {0} ", _pageType);
                if (_scalePercentage != 100)
                {
                    commandParams += string.Format("--zoom {0} ", ((float)_scalePercentage / 100f).ToString());
                }
                commandParams += string.Format("\"{0}\" \"{1}\"", documentUri, outputPDFFilePath);

                int retryAttempts = 2;
                do
                {
                    try
                    {
                        // Delete files if they already exist since they need to be regenerated anyway:
                        FileUtils.SafeDeleteFile(outputPDFFilePath);
                        FileUtils.SafeDeleteFile(outputCSVFilePath);

                        using (Process process = new Process())
                        {
                            process.StartInfo.FileName = _pdfGeneratorExePath;
                            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                            process.StartInfo.Arguments = commandParams;

                            process.Start();

                            if (!process.WaitForExit(5 * 60 * 1000))
                            {
                                try
                                {
                                    process.Kill();
                                }
                                catch (Exception)
                                {
                                }
                                throw new ArgumentException("The PDF generation process did not finish in a reasonable amount of time, so the process has been aborted.");
                            }
                            if (process.ExitCode != 0)
                            {
                                throw new ArgumentException(string.Format("The PDF generation process exited with an error code: {0}.", process.ExitCode.ToString()));
                            }
                        }
                        if (!File.Exists(outputPDFFilePath))
                        {
                            throw new ArgumentException("The PDF generation process did not produce an output file, aborting export!");
                        }
                        break;
                    }
                    catch (Exception ex2)
                    {
                        if (retryAttempts > 0)
                        {
                            AppendAuditLogEvent("The PDF generation process failed, will pause then retry again.  Error: {0}",
                                                ExceptionUtils.GetDeepExceptionMessage(ex2));
                            Thread.Sleep(TimeSpan.FromSeconds(10));
                        }
                    }
                } while (retryAttempts-- > 0);

                string columnNamesString = StringUtils.Join(";", _csvColumnNames);
                _baseDao.DoSimpleQueryWithRowCallbackDelegate(VW_TRI_FILE_CSV_DEFINITION_NAME, ID_COLUMN_NAME, metadata.ID, columnNamesString,
                    delegate(IDataReader reader)
                    {
                        CsvExporter.ExportSingleCsvRow(_csvColumnNames, reader, outputCSVFilePath);
                    });

                if (!File.Exists(outputCSVFilePath))
                {
                    throw new ArgumentException("The CSV generation process did not produce an output file, aborting export!");
                }
                
                _baseDao.DoSimpleInsertOrUpdateOne(App_GeneratedPDF_NAME, "repId;repType", new object[] { metadata.repId, metadata.repType },
                                                   "App_GeneratedPDF_ID;repId;repType;Filename;IsGenerated;ErrorMsg", app_GeneratedPDF_ID,
                                                   metadata.repId, metadata.repType, outputPDFFilePath, true, null);

                AppendAuditLogEvent("*** Successfully finished PDF generation for file \"{0}\" ({1} of {2} total files)",
                                    metadata.PDFFilename, currentFileIndex.ToString(), maxFileIndex.ToString());

            }
            catch (Exception ex)
            {
                FileUtils.SafeDeleteFile(outputPDFFilePath);
                FileUtils.SafeDeleteFile(outputCSVFilePath);
                string errorMessage = string.Format("Failed PDF generation for file \"{0}\" ({1} of {2} total files) with error: {3}",
                                                    metadata.PDFFilename, currentFileIndex.ToString(), maxFileIndex.ToString(),
                                                    ExceptionUtils.GetDeepExceptionMessage(ex));
                AppendAuditLogEvent("*** " + errorMessage);
                if (errorMessage.Length > 4000)
                {
                    errorMessage = errorMessage.Substring(0, 4000);
                }
                try
                {
                    _baseDao.DoSimpleInsertOrUpdateOne(App_GeneratedPDF_NAME, "repId;repType", new object[] { metadata.repId, metadata.repType },
                                                       "App_GeneratedPDF_ID;repId;repType;Filename;IsGenerated;ErrorMsg", app_GeneratedPDF_ID,
                                                       metadata.repId, metadata.repType, null, false, errorMessage);
                }
                catch (Exception)
                {
                }
            }
        }
        protected virtual string ExtractPDFGeneratorExe()
        {
            string folderPath = null;
            try
            {
                AppendAuditLogEvent("Extracting the PDF generator files to temporary folder ...");
                folderPath = ExtractZippedResourceToTempFolder("wkhtmltopdf.zip");
                string exeFilePath = Path.Combine(folderPath, "wkhtmltopdf.exe");
                if (!File.Exists(exeFilePath))
                {
                    throw new ArgumentException(string.Format("An error occurred extracting the PDF generator files: the PDF generator program could not be found in the extracted folder!"));
                }
                AppendAuditLogEvent("Successfully extracted the PDF generator files to a temporary folder");
                return exeFilePath;
            }
            catch (Exception ex)
            {
                FileUtils.SafeDeleteDirectory(folderPath);
                throw new ArgumentException(string.Format("An error occurred extracting the PDF generator files: {0}",
                                                          ExceptionUtils.GetDeepExceptionMessage(ex)));
            }
        }
        protected virtual List<string> GetCSVColumnNames()
        {
            AppendAuditLogEvent("Loading CSV column names from \"{0}\" ...", VW_TRI_FILE_CSV_DEFINITION_NAME);

            List<string> columnNames = _baseDao.GetTableColumnNames(VW_TRI_FILE_CSV_DEFINITION_NAME);
            int idIndex = columnNames.FindIndex(s => s.Equals(ID_COLUMN_NAME, StringComparison.OrdinalIgnoreCase));
            if ( idIndex < 0 )
            {
                throw new ArgumentException(string.Format("The view \"{0}\" does not contain the required \"{1}\" column",
                                                          VW_TRI_FILE_CSV_DEFINITION_NAME, ID_COLUMN_NAME));
            }
            columnNames.RemoveAt(idIndex); // ID_COLUMN_NAME is not exported

            AppendAuditLogEvent("Found {0} CSV column names in \"{1}\" ...", columnNames.Count.ToString(),
                                VW_TRI_FILE_CSV_DEFINITION_NAME);
            return columnNames;
        }
        protected virtual List<VW_TRI_PDF_METADATA> GetPDFMetadataList()
        {
            AppendAuditLogEvent("Loading PDF generation metadata from the view \"{0}\" ...", VW_TRI_PDF_METADATA_NAME);
            List<VW_TRI_PDF_METADATA> list = new List<VW_TRI_PDF_METADATA>(100);
            _baseDao.DoJDBCQueryWithRowCallbackDelegate(string.Format("SELECT * FROM {0}", VW_TRI_PDF_METADATA_NAME), 
                delegate(IDataReader reader)
                {
                    NamedNullMappingDataReader dataReader = reader as NamedNullMappingDataReader;
                    VW_TRI_PDF_METADATA m = new VW_TRI_PDF_METADATA();
                    m.ID = dataReader.GetString(ID_COLUMN_NAME);
                    m.DocumentType = dataReader.GetString("DocumentType");
                    m.Confidential = dataReader.GetString("Confidential");
                    m.DocumentDate = dataReader.GetString("DocumentDate");
                    m.IISFacilityNumber = dataReader.GetString("IISFacilityNumber");
                    m.ProgramNumber = dataReader.GetString("ProgramNumber");
                    m.Recipient = dataReader.GetString("Recipient");
                    m.DocumentDescription = dataReader.GetString("DocumentDescription");
                    m.Originator = dataReader.GetString("Originator");
                    m.FileLocation = dataReader.GetString("FileLocation");
                    m.SubFileID = dataReader.GetString("SubFileID");
                    m.repType = dataReader.GetString("repType");
                    m.subId = dataReader.GetString("subId");
                    m.repId = dataReader.GetString("repId");
                    m.SubmissionYear = dataReader.GetString("SubmissionYear");
                    m.CASNumber = dataReader.GetString("CASNumber");
                    m.ChemicalName = dataReader.GetString("ChemicalName");
                    m.Revision = dataReader.GetString("Revision");
                    m.Program = dataReader.GetString("Program");
                    m.FiledDate = dataReader.GetString("FiledDate");
                    m.OriginatorType = dataReader.GetString("OriginatorType");
                    m.RecipientType = dataReader.GetString("RecipientType");
                    m.FormURL = dataReader.GetString("FormURL");
                    m.CSVFilename = dataReader.GetString("CSVFilename");
                    m.PDFFilename = dataReader.GetString("PDFFilename");
                    m.FileType = dataReader.GetString("FileType");
                    list.Add(m);
                });
            if (list.Count == 0)
            {
                AppendAuditLogEvent("The view \"{0}\" did not contain any records", VW_TRI_PDF_METADATA_NAME);
            }
            else
            {
                if ((_maxFilesToGenerate < int.MaxValue) && (list.Count > _maxFilesToGenerate))
                {
                    AppendAuditLogEvent("Found {0} PDF generation metadata records in the view \"{1}\", but the number of files processed will be limited to the maximum number specified of {2} ...",
                                        list.Count.ToString(), VW_TRI_PDF_METADATA_NAME, _maxFilesToGenerate.ToString());
                    list.RemoveRange(_maxFilesToGenerate, list.Count - _maxFilesToGenerate);
                }
                else
                {
                    AppendAuditLogEvent("Found {0} PDF generation metadata records in the view \"{1}\" ...",
                                        list.Count.ToString(), VW_TRI_PDF_METADATA_NAME);
                }
            }
            return list;
        }
        protected class VW_TRI_PDF_METADATA
        {
            public string ID;
            public string DocumentType;
            public string Confidential;
            public string DocumentDate;
            public string IISFacilityNumber;
            public string ProgramNumber;
            public string Recipient;
            public string DocumentDescription;
            public string Originator;
            public string FileLocation;
            public string SubFileID;
            public string repType;
            public string subId;
            public string repId;
            public string SubmissionYear;
            public string CASNumber;
            public string ChemicalName;
            public string Revision;
            public string Program;
            public string FiledDate;
            public string OriginatorType;
            public string RecipientType;
            public string FormURL;
            public string CSVFilename;
            public string PDFFilename;
            public string FileType;
        }
    }
}
