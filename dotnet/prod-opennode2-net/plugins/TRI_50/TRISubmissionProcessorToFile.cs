using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;

namespace Windsor.Node2008.WNOSPlugin.TRI5
{
    public class TRISubmissionProcessorToFile : BaseWNOSPlugin, ISubmitProcessor
    {
        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected string _dataDestinationPath;
        private const string TRI_XML_NAMESPACE = "";
        protected enum TRIConfigParams
        {
            None,
            [Description("Data Destination Path")]
            DataDestinationPath,
        }
        public TRISubmissionProcessorToFile()
        {
            AppendConfigArguments<TRIConfigParams>();
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", typeof(TRISubmissionProcessorToFile).Name);
            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);
            GetConfigParameter(EnumUtils.ToDescription(TRIConfigParams.DataDestinationPath), out _dataDestinationPath);
        }
        protected void ProcessSubmitDocument(string transactionId, string docId)
        {
            try
            {
                IHeaderDocumentHelper headerDocumentHelper;
                GetServiceImplementation(out headerDocumentHelper);
                AppendAuditLogEvent("Getting data for document with id \"{0}\"", docId);
                Document document = _documentManager.GetDocument(transactionId, docId, true);
                if (document.IsZipFile)
                {
                    AppendAuditLogEvent("Decompressing document to temporary file");
                    _compressionHelper.UncompressDeep(document.Content, _dataDestinationPath + document.DocumentName + ".xml");
                }
                else
                {
                    AppendAuditLogEvent("Writing document data to temporary file");
                    File.WriteAllBytes(_dataDestinationPath + document.DocumentName + ".xml", document.Content);
                }
            }
            catch (Exception e)
            {
                AppendAuditLogEvent("Failed to process document with id \"{0}.\"  EXCEPTION: {1}", docId.ToString(), ExceptionUtils.ToShortString(e)); throw;
            }
        }
        public void ProcessSubmit(string transactionId)
        {
            LazyInit();
            IList<string> documentIds = _documentManager.GetDocumentIds(transactionId);
            if (CollectionUtils.IsNullOrEmpty(documentIds))
            {
                AppendAuditLogEvent("Didn't find any submit documents to process."); return;
            }
            else if (documentIds.Count > 1)
            {
                throw new InvalidOperationException(string.Format("More than one TRI document was attached to the transaction: {0}", documentIds.Count.ToString()));
            }
            AppendAuditLogEvent("Found one TRI document to process.");
            ProcessSubmitDocument(transactionId, documentIds[0]);
        }
    }
}
