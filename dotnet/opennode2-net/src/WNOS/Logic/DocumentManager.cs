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
using System.Reflection;
using Common.Logging;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Logic
{
    public class DocumentManager : IDocumentManagerEx
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

		private IIdProvider _idProvider;
        private IDocumentDao _documentDao;
		IDocumentContentManager _documentContentManager;
        ICompressionHelper _compressionHelper;

        public ICompressionHelper CompressionHelper
        {
            get { return _compressionHelper; }
            set { _compressionHelper = value; }
        }
        private bool _alwaysCompressDocumentContents = true;

        public bool AlwaysCompressDocumentContents
        {
            get { return _alwaysCompressDocumentContents; }
            set { _alwaysCompressDocumentContents = value; }
        }

		public IDocumentContentManager DocumentContentManager
		{
			get { return _documentContentManager; }
			set { _documentContentManager = value; }
		}

        public IDocumentDao DocumentDao
        {
			get {
				return _documentDao;
			}
			set {
				_documentDao = value;
			}
		}

		public IIdProvider IdProvider {
			get {
				return _idProvider;
			}
			set {
				_idProvider = value;
			}
		}

        public void Init()
        {
			FieldNotInitializedException.ThrowIfNull(this, ref _documentContentManager);
			FieldNotInitializedException.ThrowIfNull(this, ref _idProvider);
			FieldNotInitializedException.ThrowIfNull(this, ref _documentDao);
            FieldNotInitializedException.ThrowIfNull(this, ref _compressionHelper);
        }

        #region IDocumentProvider Members

        protected Document ValidateNotNull(Document document)
        {
            if (document == null) throw new FileNotFoundException();
            return document;
        }
        public byte[] GetContent(string transactionId, string id)
        {
            return _documentContentManager.GetDocumentContent(transactionId, id);
        }
        public byte[] GetUncompressedContent(string transactionId, string id)
        {
            byte[] content = GetContent(transactionId, id);
            if (content != null)
            {
                if (_compressionHelper.IsCompressed(content))
                {
                    content = _compressionHelper.UncompressDeep(content);
                }
            }
            return content;
        }

        public int GetContentSize(string transactionId, string id)
        {
            return _documentContentManager.GetDocumentContentSize(transactionId, id);
        }
        public Document GetDocument(string transactionId, string id, bool loadContent)
		{

            Document document = ValidateNotNull(_documentDao.GetDocumentByDbId(transactionId, id));
            if (loadContent)
            {
                document.Content = GetContent(transactionId, id);
            }
            else
            {
                document.ContentByteSize = GetContentSize(transactionId, id);
            }
			return document;
        }
        public Document GetDocumentByName(string transactionId, string documentName, bool loadContent)
        {

            Document document = ValidateNotNull(_documentDao.GetDocumentByDocumentName(transactionId, documentName));
            if (loadContent)
            {
                document.Content = GetContent(transactionId, document.Id);
            }
            else
            {
                document.ContentByteSize = GetContentSize(transactionId, document.Id);
            }
            return document;
        }
        public IList<Document> GetDocuments(string transactionId, IList<Document> requestedDocs,
                                            bool loadContent)
		{
			IList<Document> documents = _documentDao.GetDocuments(transactionId, requestedDocs);
            if (loadContent)
            {
                LoadContent(transactionId, documents);
            }
            else
            {
                GetContentSizes(transactionId, documents);
            }
			return documents;
		}
        public IList<string> GetAllDocumentNames(string transactionId)
        {
            return _documentDao.GetAllDocumentNames(transactionId);
        }
        public IList<Document> GetDocumentsByStatus(string transactionId,
                                                    CommonTransactionStatusCode returnDocsWithStatus)
        {
            IList<Document> documents = _documentDao.GetDocumentsByStatus(transactionId, returnDocsWithStatus);
            GetContentSizes(transactionId, documents);
            return documents;
        }
        public IList<Document> GetAllDocuments(string transactionId)
        {
            IList<Document> documents = _documentDao.GetAllDocuments(transactionId);
            GetContentSizes(transactionId, documents);
            return documents;
        }
        public IList<Document> GetDocuments(string transactionId, bool loadContent)
        {
            IList<Document> documents = _documentDao.GetDocuments(transactionId, null);
            if (loadContent)
            {
                LoadContent(transactionId, documents);
            }
            else
            {
                GetContentSizes(transactionId, documents);
            }
            return documents;
        }
        public IList<string> GetDocumentIds(string transactionId)
        {
            return _documentDao.GetDocumentIds(transactionId);
        }

        public void SetDocumentStatus(string transactionId, string docDbId,
                                      CommonTransactionStatusCode status, string statusDetail)
        {
            _documentDao.SetDocumentStatus(transactionId, docDbId, status, statusDetail);
        }
        public CommonTransactionStatusCode GetDocumentStatus(string transactionId, string docDbId,
                                                             out string statusDetail)
        {
            return _documentDao.GetDocumentStatus(transactionId, docDbId, out statusDetail);
        }
        public void Delete(string transactionId)
        {
            _documentDao.DeleteAllDocuments(transactionId);
            _documentContentManager.DeleteAllDocuments(transactionId);
        }
        
        public void DeleteDocument(string transactionId, string id)
        {
            _documentDao.DeleteDocument(transactionId, id);
            _documentContentManager.DeleteDocument(transactionId, id);
        }
        
		/// <summary>
        /// Add all the input documents to the node.
        /// </summary>
		public IList<string> AddDocuments(string transactionId, IList<Document> documents) {
		
			if ( CollectionUtils.IsNullOrEmpty(documents) ) {
				return null;
			}
			List<string> newDocumentIds = new List<string>(documents.Count);
			try {
				LOG.Debug("Saving documents");
                // First, generate ids for new documents
				foreach(Windsor.Node2008.WNOSDomain.Document document in documents)
                {
					if ( CollectionUtils.IsNullOrEmpty(document.Content) ) {
						throw new ArgumentException(string.Format("Document does not contain any content: \"{0}\".", document));
					}
                    document.Id = IdProvider.Get();
					if ( string.IsNullOrEmpty(document.DocumentId) ) {
                        document.DocumentId = document.Id;	// If not specified, set this to DB id
					}
                    if (string.IsNullOrEmpty(document.DocumentName))
                    {
                        // If not specified, set this to DB id + extension
                        document.DocumentName =
                            Path.ChangeExtension(document.Id, CommonContentAndFormatProvider.GetFileExtension(document.Type));
                    }
                    newDocumentIds.Add(document.Id);
                    CheckToCompressDocument(document);
                }
                // Next, save the new documents to the DB
                _documentDao.CreateDocuments(transactionId, documents);
                // Finally, save document content to repository
                int index = 0;
				foreach(Windsor.Node2008.WNOSDomain.Document document in documents) {
					LOG.Debug("Saving document: \"{0}\"", document);
                    _documentContentManager.SaveDocumentContent(transactionId, newDocumentIds[index++], 
                                                                document.Content, false);
				}
				
				return newDocumentIds;
			}
			catch(Exception) {
				RollbackDocuments(transactionId, newDocumentIds);
				throw;
			}
		}
		/// <summary>
		/// Add the input document to the node.
		/// </summary>
		public string AddDocument(string transactionId, CommonTransactionStatusCode status,
								  string statusDetail, Document document)
		{
			if (CollectionUtils.IsNullOrEmpty(document.Content))
			{
				throw new ArgumentException(string.Format("Document does not contain any content: \"{0}\".", document));
			}
			string newId = IdProvider.Get();
			try
			{
                document.Id = newId;
				// First, attempt to save all the documents to the repository
				if (string.IsNullOrEmpty(document.DocumentId))
				{
					document.DocumentId = newId;	// If not specified, set this to DB id
				}
                if (string.IsNullOrEmpty(document.DocumentName))
                {
                    // If not specified, set this to DB id + extension
                    document.DocumentName =
                        Path.ChangeExtension(newId, CommonContentAndFormatProvider.GetFileExtension(document.Type));
                }
                CheckToCompressDocument(document);
                LOG.Debug("Saving document: \"{0}\"", document);
                _documentDao.CreateDocument(transactionId, status, statusDetail, document);
                _documentContentManager.SaveDocumentContent(transactionId, newId, document.Content, false);
				return newId;
			}
			catch (Exception)
			{
				RollbackDocument(transactionId, newId);
				throw;
			}
		}
        private bool CheckToCompressDocument(Document ioDocument)
        {
            if (_alwaysCompressDocumentContents)
            {
                if (!ioDocument.DontAutoCompress && !ioDocument.IsZipFile)
                {
                    if (!string.IsNullOrEmpty(ioDocument.DocumentName))
                    {
                        if ((ioDocument.DocumentName == "Node20.Report") ||
                            (ioDocument.DocumentName == "Node20.Error") ||
                            (ioDocument.DocumentName == "Node20.Original"))
                        {
                            // Don't compress these special files
                            return false;
                        }
                    }
                    else
                    {
                        ioDocument.DocumentName = Guid.NewGuid().ToString();
                    }
                    string originalDocumentName = ioDocument.DocumentName;
                    ioDocument.DocumentName += ".zip";
                    ioDocument.Type = CommonContentType.ZIP;
                    if (!CollectionUtils.IsNullOrEmpty(ioDocument.Content))
                    {
                        ioDocument.Content = _compressionHelper.Compress(originalDocumentName, ioDocument.Content);
                    }
                    return true;
                }
            }
            return false;
        }
        public string AddDocument(string transactionId, CommonTransactionStatusCode status,
                                  string statusDetail, PaginatedContentResult result)
        {
            string docName =
                Path.ChangeExtension(Guid.NewGuid().ToString(),
                                     CommonContentAndFormatProvider.GetFileExtension(result.Content.Type));
            Document doc = new Document(docName, result.Content.Type, result.Content.Content);
            return AddDocument(transactionId, status, statusDetail, doc);
        }
        public string AddDocument(string transactionId, ExecuteContentResult result)
        {
            string docName =
                Path.ChangeExtension(Guid.NewGuid().ToString(),
                                     CommonContentAndFormatProvider.GetFileExtension(result.Content.Type));
            Document doc = new Document(docName, result.Content.Type, result.Content.Content);
            return AddDocument(transactionId, result.Status, null, doc);
        }
        public string AddDocument(string transactionId, CommonTransactionStatusCode status,
                                  string statusDetail, string filePath)
        {
            return AddDocument(transactionId, status, statusDetail, filePath, false);
        }
        public string AddDocumentDontAutoCompress(string transactionId, CommonTransactionStatusCode status,
                                                  string statusDetail, string filePath)
        {
            return AddDocument(transactionId, status, statusDetail, filePath, true);
        }
        protected virtual string AddDocument(string transactionId, CommonTransactionStatusCode status,
                                             string statusDetail, string filePath, bool dontAutoCompress)
        {
            string docName = Path.GetFileName(filePath);
            Document doc =
                new Document(docName, CommonContentAndFormatProvider.GetFileTypeFromName(docName),
                             File.ReadAllBytes(filePath));
            doc.DontAutoCompress = dontAutoCompress;
            return AddDocument(transactionId, status, statusDetail, doc);
        }

		public void RollbackDocuments(string transactionId, IList<string> ids) {
			foreach (string id in ids) {
                RollbackDocument(transactionId, id);
			}
		}
		public void RollbackDocument(string transactionId, string id)
		{
			try
			{
				DeleteDocument(transactionId, id);
			}
			catch (Exception ex)
			{
				LOG.Error("Failed to DeleteDocument({0}, {1})", ex,
						  transactionId, id);
			}
		}
		#endregion


        #region Private Methods

        private void LoadContent(string transactionId, IList<Document> documents)
        {
            if (!CollectionUtils.IsNullOrEmpty(documents))
            {
                for (int i = 0; i < documents.Count; ++i)
                {
                    Document document = documents[i];
                    document.Content = GetContent(transactionId, document.Id);
                }
            }
        }
        private void GetContentSizes(string transactionId, IList<Document> documents)
        {
            if (!CollectionUtils.IsNullOrEmpty(documents))
            {
                for (int i = 0; i < documents.Count; ++i)
                {
                    Document document = documents[i];
                    document.ContentByteSize = GetContentSize(transactionId, document.Id);
                }
            }
        }
        #endregion
    }
}
