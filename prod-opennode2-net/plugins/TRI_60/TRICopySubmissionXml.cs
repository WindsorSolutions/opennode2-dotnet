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
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.TRI6
{
    public class TRICopySubmissionXml : BaseWNOSPlugin, ISubmitProcessor
	{

        protected static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        protected const string DEFAULT_COPY_XML_STORED_PROC_NAME = "TRI_COPY_XML";
        protected const string STORED_PROC_PARAM_NAME_TRANSACTION_ID = "p_transaction_id";
        protected const string STORED_PROC_PARAM_NAME_USER_NAME = "p_user";

        protected IDocumentManager _documentManager;
        protected ITransactionManager _transactionManager;
        protected string _copyStoredProcName = DEFAULT_COPY_XML_STORED_PROC_NAME;

        protected readonly string CONFIG_XML_STORED_PROC_NAME = 
            string.Format("XML Copy Stored Procedure Name (default: {0})", DEFAULT_COPY_XML_STORED_PROC_NAME);
        protected SpringBaseDao _baseDao;

        protected enum TRIDataSourceParams
        {
            None,
            [Description("Data Source")]
            DataSource,
        }

        public TRICopySubmissionXml()
        {
            ConfigurationArguments.Add(CONFIG_XML_STORED_PROC_NAME, null);

            AppendDataProviders<TRIDataSourceParams>();
        }

        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _transactionManager);

            TryGetConfigParameter(CONFIG_XML_STORED_PROC_NAME, ref _copyStoredProcName);

            _baseDao = ValidateDBProvider(EnumUtils.ToDescription(TRIDataSourceParams.DataSource), 
                                          typeof(NamedNullMappingDataReader));
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

            string username = _transactionManager.GetTransactionUsername(transactionId);
            string docId = documentIds[0];

            try
            {
                AppendAuditLogEvent("Calling stored procedure \"{0}\" to copy the document id \"{1}\" associated with transaction id \"{2}\" and NAAS account \"{3}\" ...",
                                    _copyStoredProcName, docId, transactionId, username);

                _baseDao.DoStoredProcWithArgs(_copyStoredProcName, STORED_PROC_PARAM_NAME_TRANSACTION_ID + ";" + STORED_PROC_PARAM_NAME_USER_NAME,
                                              new object[] { transactionId, username });

                AppendAuditLogEvent("Successfully called stored procedure \"{0}\" to copy the document id \"{1}\" associated with transaction id \"{2}\"",
                                    _copyStoredProcName, docId, transactionId);

                _documentManager.SetDocumentStatus(transactionId, docId, CommonTransactionStatusCode.Processed,
                                                   "Copied using stored proc " + _copyStoredProcName);
            }
            catch (Exception ex)
            {
                AppendAuditLogEvent("Failed to call stored procedure \"{0}\" to copy the document id \"{1}\" associated with transaction id \"{2}\": {3}",
                                    _copyStoredProcName, docId, transactionId, ExceptionUtils.GetDeepExceptionMessage(ex));
                throw;
            }
        }
    }
}
