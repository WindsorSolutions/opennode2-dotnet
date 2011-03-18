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
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSProviders
{
    /// <summary>
    /// Document manager interface.
    /// </summary>
    public interface IDocumentManager
    {
        /// <summary>
        /// Get the content of a single document
        /// </summary>
        byte[] GetContent(string transactionId, string id);

        /// <summary>
        /// Get the uncompressed content of a single document
        /// </summary>
        byte[] GetUncompressedContent(string transactionId, string id);

        /// <summary>
        /// Gets the content size (in bytes) of a single document
        /// </summary>
        int GetContentSize(string transactionId, string id);

		/// <summary>
		/// Gets an instance of a document given the input transaction and document id.
		/// </summary>
        Document GetDocument(string transactionId, string id, bool loadContent);

        /// <summary>
        /// Gets an instance of a document given the input transaction and document name.
        /// </summary>
        Document GetDocumentByName(string transactionId, string documentName, bool loadContent);

        /// <summary>
        /// Gets db ids for all documents in the transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        IList<Document> GetDocuments(string transactionId, bool loadContent);

        /// <summary>
        /// Gets all documents in the transaction with the input status.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        IList<Document> GetDocumentsByStatus(string transactionId,
                                             CommonTransactionStatusCode returnDocsWithStatus);
        /// <summary>
        /// Gets all documents in the transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        IList<Document> GetAllDocuments(string transactionId);
        /// <summary>
        /// Gets db ids for all documents in the transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        IList<string> GetDocumentIds(string transactionId);

        /// <summary>
        /// GetTransactionDocumentStatus
        /// </summary>
        CommonTransactionStatusCode GetDocumentStatus(string transactionID, string docDbId,
                                                      out string statusDetail);
        /// <summary>
        /// SetTransactionDocumentStatus
        /// </summary>
        void SetDocumentStatus(string transactionID, string docDbId,
                               CommonTransactionStatusCode status, string statusDetail);
        /// <summary>
        /// Deletes all documents for particular transaction
        /// </summary>
        void Delete(string transactionId);
        
        /// <summary>
        /// Delete the specified physical document for the given transaction.
        /// </summary>
        void DeleteDocument(string transactionId, string id);

        /// <summary>
        /// Adds the specified documents to the repository and DB, and returns
		/// a list of document ids.
        /// </summary>
		IList<string> AddDocuments(string transactionId, IList<Document> documents);

		/// <summary>
		/// Adds the specified document to the repository and DB, and returns
		/// a document id.
		/// </summary>
		string AddDocument(string transactionId, CommonTransactionStatusCode status,
						   string statusDetail, Document document);

        /// <summary>
        /// Adds the specified document to the repository and DB, and returns
        /// a document id.
        /// </summary>
        string AddDocument(string transactionId, CommonTransactionStatusCode status,
                           string statusDetail, PaginatedContentResult result);

        /// <summary>
        /// Adds the specified document to the repository and DB, and returns
        /// a document id.
        /// </summary>
        string AddDocument(string transactionId, CommonTransactionStatusCode status,
                           string statusDetail, string filePath);
        /// <summary>
        /// Adds the specified document to the repository and DB, and returns
        /// a document id.
        /// </summary>
        string AddDocumentDontAutoCompress(string transactionId, CommonTransactionStatusCode status,
                                           string statusDetail, string filePath);

        /// <summary>
        /// Adds the specified document to the repository and DB, and returns
        /// a document id.
        /// </summary>
        string AddDocument(string transactionId, ExecuteContentResult result);

        /// <summary>
        /// Rollback (delete) the specified physical documents and document DB entries 
		/// for the given transaction.
        /// </summary>
		void RollbackDocuments(string transactionId, IList<string> ids);
		
        /// <summary>
        /// Rollback (delete) the specified physical document and document DB entry
		/// for the given transaction.
        /// </summary>
		void RollbackDocument(string transactionId, string id);

        IList<string> GetAllDocumentNames(string transactionId);
    }
}
