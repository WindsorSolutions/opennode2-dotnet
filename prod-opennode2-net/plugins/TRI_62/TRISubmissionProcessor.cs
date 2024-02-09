using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.TRI62
{
    public class TRISubmissionProcessor : BaseWNOSPlugin, ISubmitProcessor
	{

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected int _commandTimeoutInSeconds = 20 * 60;

        protected SpringBaseDao _baseDao;
        protected string _postProcessingStoredProcName; // "TRI_PROCESSPOST_TRI_LOADER"
        protected bool _deleteExistingDataBeforeInsert = true;

//        private const string TRI_XML_NAMESPACE = "http://www.exchangenetwork.net/schema/TRI/4";
        private const string TRI_XML_NAMESPACE = "";

        protected enum TRIConfigParams
        {
            None,
            [Description("Delete Existing Data Before Insert (True or False)")]
            DeleteExistingDataBeforeInsert,
            [Description("Post Processing Stored Proc")]
            PostProcessingStoredProc,
        }
        protected enum TRIDataSourceParams
        {
            None,
            [Description("Data Destination")]
            DataDestination,
        }

        public TRISubmissionProcessor()
        {
            AppendConfigArguments<TRIConfigParams>();

            AppendDataProviders<TRIDataSourceParams>();
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", typeof(TRISubmissionProcessor).Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);

            GetConfigParameter(EnumUtils.ToDescription(TRIConfigParams.DeleteExistingDataBeforeInsert), 
                               out _deleteExistingDataBeforeInsert);
            TryGetConfigParameter(EnumUtils.ToDescription(TRIConfigParams.PostProcessingStoredProc), 
                                  ref _postProcessingStoredProcName);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(TRIDataSourceParams.DataDestination), 
                                          typeof(NamedNullMappingDataReader));
        }

        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            string tempXmlFilePath = _settingsProvider.NewTempFilePath();
            try
            {
                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);

                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    AppendAuditLogEvent("Decompressing document to temporary file");
                    _compressionHelper.UncompressDeep(document.Content, tempXmlFilePath);
                }
                else
                {
                    AppendAuditLogEvent("Writing document data to temporary file");
                    File.WriteAllBytes(tempXmlFilePath, document.Content);
                }

                XmlElement loadElement = null;
                try
                {
                    AppendAuditLogEvent("Attempting to load document with Exchange Header");
                    headerDocumentHelper.Load(tempXmlFilePath);
                    string operation;
                    loadElement = headerDocumentHelper.GetFirstPayload(out operation);
                    if (loadElement == null)
                    {
                        throw new ArgumentException("The submitted document does not contain a payload");
                    }
                }
                catch (Exception)
                {
                    AppendAuditLogEvent("Document does not contain an Exchange Header");
                    // Assume, for now, that document does not have a header
                }

                AppendAuditLogEvent("Deserializing document data to TRI data");
                XmlReader reader;

                if (loadElement != null)
                {
                    reader = new NamespaceSpecifiedXmlNodeReader(TRI_XML_NAMESPACE, loadElement);
                }
                else
                {
                    reader = new NamespaceSpecifiedXmlTextReader(TRI_XML_NAMESPACE, tempXmlFilePath);
                }
                TRIDataType data = _serializationHelper.Deserialize<TRIDataType>(reader);
                
                AppendAuditLogEvent("Setting TRI transaction id to \"{0}\"", transactionId);
                data.TransactionID = transactionId;

                try
                {
                    AppendAuditLogEvent("Storing TRI data into database");

                    TRIData triDataLoader = new TRIData();
                    triDataLoader.Load(data, _baseDao, _deleteExistingDataBeforeInsert, _commandTimeoutInSeconds);

                    AppendAuditLogEvent("Stored TRI data into database");
                }
                catch (Exception ex)
                {
                    AppendAuditLogEvent("Failed to store TRI data into database: {0}",
                                        ExceptionUtils.GetDeepExceptionMessage(ex));
                    throw;
                }

                if (!string.IsNullOrEmpty(_postProcessingStoredProcName))
                {
                    try
                    {
                        AppendAuditLogEvent("Calling TRI post processing stored proc: \"{0}\"", _postProcessingStoredProcName);

                        _baseDao.DoStoredProc(_postProcessingStoredProcName);

                        AppendAuditLogEvent("Successfully called TRI post processing stored proc");
                    }
                    catch (Exception ex)
                    {
                        AppendAuditLogEvent("Failed to call TRI post processing stored proc: {0}",
                                            ExceptionUtils.GetDeepExceptionMessage(ex));
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}",
                                    docId.ToString(), ExceptionUtils.ToShortString(e));
                throw;
            }
            finally
            {
                FileUtils.SafeDeleteFile(tempXmlFilePath);
            }
        }

        public void ProcessSubmit(string transactionId)
        {
            LazyInit();

            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);

            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process.");
                return;
            }
            else if (documentIds.Count > 1)
            {
                throw new InvalidOperationException(string.Format("More than one TRI document was attached to the transaction: {0}",
                                                                  documentIds.Count.ToString()));
            }
            AppendAuditLogEvent("Found one TRI document to process.");

            ProcessSubmitDocument(transactionId, documentIds[0]);
        }
    }
}
