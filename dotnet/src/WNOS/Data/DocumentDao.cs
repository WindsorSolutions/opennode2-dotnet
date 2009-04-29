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
using System.Data.Common;
using System.Reflection;
using System.IO;

using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Transaction.Support;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class DocumentDao : BaseDao, IDocumentDao
    {
        public const string TABLE_NAME = "NDocument";

        #region Init

        new public void Init()
        {
            base.Init();
		}

        #endregion

        #region Methods

		/// <summary>
		/// Create the input list of documents in the DB as a transaction.
		/// </summary>
        public void CreateDocuments(string transactionId, IList<Document> documents)
        {
			TransactionTemplate.Execute(delegate {
				for (int i = 0; i < documents.Count; ++i) {
					CreateDocument(transactionId, documents[i]);
				}
				return null;
			});
        }

		public void CreateDocument(string transactionId, CommonTransactionStatusCode documentStatus,
								   string documentStatusDetail, Document document)
        {

            CreateDocument(transactionId, document.Id, document.Type, document.DocumentName,
                           document.DocumentId, documentStatus, documentStatusDetail);
        }
		public void CreateDocument(string transactionId, string id, CommonContentType documentType,
								   string documentName, string documentId, CommonTransactionStatusCode documentStatus,
								   string documentStatusDetail)
		{
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException("document id");
                }
                DoInsert(TABLE_NAME,
                         "Id;TransactionId;DocumentName;Type;DocumentId;Status;StatusDetail",
                         id, transactionId, documentName ?? string.Empty,
                         documentType.ToString(), documentId ?? string.Empty,
                         documentStatus.ToString(), documentStatusDetail ?? string.Empty);
            }
            catch (Spring.Dao.DataIntegrityViolationException e)
            {
                throw new ArgumentException(string.Format("The document \"{0}\" already exists for the transaction \"{1}\"",
                                                          documentName ?? string.Empty, transactionId), e);
            }
		}
		public void CreateDocument(string transactionId, Document document)
        {
			CreateDocument(transactionId, CommonTransactionStatusCode.Received,
						   string.Empty, document);
        }
        public void DeleteDocuments(string transactionId, IList<string> ids)
        {
			DoDeleteWhereIn(TABLE_NAME, "Id", ids);
        }
        public void DeleteAllDocuments(string transactionId)
        {
            DoDeleteWhereIn(TABLE_NAME, "TransactionId", new object[] { transactionId });
        }
        public void DeleteDocument(string transactionId, string id)
		{
			DeleteDocuments(transactionId, new string[] { id });
		}
        public IList<Document> GetDocuments(string transactionId, IList<Document> requestedDocs)
        {

			if ( CollectionUtils.IsNullOrEmpty(requestedDocs) ) {
				return GetAllDocuments(transactionId);
			}
			List<Document> rtnDocuments = new List<Document>();
			foreach (Document document in requestedDocs) {
				Document rtnDoc;
				if ( !string.IsNullOrEmpty(document.DocumentId) ) {
					rtnDoc = GetDocumentByDocumentId(transactionId, document.DocumentId);
					if ( rtnDoc == null ) {
						throw new FileNotFoundException(string.Format("The document was not found with the id \"{0}\" for the transaction \"{1}\"",
                                                                      document.DocumentId, transactionId), document.DocumentId);
					}
				} else if ( !string.IsNullOrEmpty(document.DocumentName) ) {
					rtnDoc = GetDocumentByDocumentName(transactionId, document.DocumentName);
					if ( rtnDoc == null ) {
						throw new FileNotFoundException(string.Format("The document was not found with the name \"{0}\" for the transaction \"{1}\"",
                                                                      document.DocumentName, transactionId), document.DocumentName);
					}
				} else {
					throw new ArgumentException(string.Format("Input document does not have a valid id or name: {0}", document));
				}
				rtnDocuments.Add(rtnDoc);
			}
			return rtnDocuments;
        }
        public IList<Document> GetAllDocuments(string transactionId) {
			List<Document> documents = null;
			DoSimpleQueryWithRowCallbackDelegate(
				TABLE_NAME, "TransactionId", transactionId,
				null, MAP_DOCUMENT_COLUMNS,
				delegate(IDataReader reader) 
				{
					Document document = MapDocument(reader);
					if ( documents == null ) {
						documents = new List<Document>();
					}
					documents.Add(document);
				});
			return documents;
        }
        public Document GetDocumentByDocumentId(string transactionId, string documentId) {
			try {
				Document document = 
					DoSimpleQueryForObjectDelegate<Document>(
						TABLE_NAME, "TransactionId;DocumentId",
						new object[] { transactionId, documentId }, MAP_DOCUMENT_COLUMNS,
						delegate(IDataReader reader, int rowNum) 
						{
							return MapDocument(reader);
						});
				return document;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }
        public Document GetDocumentByDocumentName(string transactionId, string documentName) {
			try {
				Document document = 
					DoSimpleQueryForObjectDelegate<Document>(
						TABLE_NAME, "TransactionId;DocumentName",
						new object[] { transactionId, documentName }, MAP_DOCUMENT_COLUMNS,
						delegate(IDataReader reader, int rowNum) 
						{
							return MapDocument(reader);
						});
				return document;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }
        public IList<string> GetDocumentIds(string transactionId)
        {
            List<string> ids = null;
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, "TransactionId",
                new object[] { transactionId },
                null, "Id",
                delegate(IDataReader reader)
                {
                    if (ids == null)
                    {
                        ids = new List<string>();
                    }
                    ids.Add(reader.GetString(0));
                });
            return ids;
        }
        public Document GetDocumentByDbId(string transactionId, string id)
        {
			try {
				Document document = 
					DoSimpleQueryForObjectDelegate<Document>(
						TABLE_NAME, "TransactionId;Id",
						new object[] { transactionId, id }, MAP_DOCUMENT_COLUMNS,
						delegate(IDataReader reader, int rowNum) 
						{
							return MapDocument(reader);
						});
				return document;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }
        public CommonTransactionStatusCode GetDocumentStatus(string transactionId, string id,
                                                             out string statusDetail)
        {
            string statusDetailPriv = string.Empty;
            CommonTransactionStatusCode statusPriv = CommonTransactionStatusCode.Unknown;
            DoSimpleQueryForObjectDelegate<object>(
                    TABLE_NAME, "TransactionId;Id",
                    new object[] { transactionId, id }, "Status;StatusDetail",
                    delegate(IDataReader reader, int rowNum)
                    {
                        statusPriv = EnumUtils.ParseEnum<CommonTransactionStatusCode>(reader.GetString(0));
                        statusDetailPriv = reader.GetString(1);
                        return null;
                    });
            statusDetail = statusDetailPriv;
            return statusPriv;
        }
        public void SetDocumentStatus(string transactionID, string id, CommonTransactionStatusCode status, 
                                      string statusDetail)
        {
            DoSimpleUpdateOne(TABLE_NAME, "TransactionId;Id", new object[] { transactionID, id },
                        "Status;StatusDetail",
                        status.ToString(), statusDetail ?? string.Empty);
        }
        public IList<Document> GetDocumentsByStatus(string transactionId, CommonTransactionStatusCode returnDocsWithStatus) {
            
			List<Document> documents = null;
            string whereColumns = "TransactionId;" + GetDbInGroupFromFlagsEnum("Status", returnDocsWithStatus);
			DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, whereColumns, 
				new object[] { transactionId },
				null, MAP_DOCUMENT_COLUMNS,
				delegate(IDataReader reader) 
				{
					Document document = MapDocument(reader);
					if ( documents == null ) {
						documents = new List<Document>();
					}
					documents.Add(document);
				});
			return documents;
        }

        private const string MAP_DOCUMENT_COLUMNS = "Id;DocumentName;Type;DocumentId";
		private Document MapDocument(IDataReader reader)
		{
			Document document = new Document();
            document.Id = reader.GetString(0);
			document.DocumentName = reader.GetString(1);
			document.Type = EnumUtils.ParseEnum<CommonContentType>(reader.GetString(2));
			document.DocumentId = reader.GetString(3);
			return document;
		}
        #endregion

        #region Properties

        #endregion
    }
}
