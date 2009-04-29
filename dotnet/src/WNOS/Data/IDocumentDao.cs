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

﻿using System;
using Windsor.Node2008.WNOSDomain;
using System.Collections.Generic;
using Windsor.Node2008.WNOSUtility;
namespace Windsor.Node2008.WNOS.Data
{
    public interface IDocumentDao
    {
        void CreateDocument(string transactionId, CommonTransactionStatusCode documentStatus, string documentStatusDetail, Document document);
        void CreateDocument(string transactionId, Document document);
        void CreateDocument(string transactionId, string id, CommonContentType documentType, string documentName, string documentId, CommonTransactionStatusCode documentStatus, string documentStatusDetail);
        void CreateDocuments(string transactionId, IList<Document> documents);
        void DeleteAllDocuments(string transactionId);
        void DeleteDocument(string transactionId, string id);
        void DeleteDocuments(string transactionId, IList<string> ids);
        IList<Document> GetAllDocuments(string transactionId);
        IList<string> GetDocumentIds(string transactionId);
        Document GetDocumentByDbId(string transactionId, string id);
        Document GetDocumentByDocumentId(string transactionId, string documentId);
        Document GetDocumentByDocumentName(string transactionId, string documentName);
        IList<Document> GetDocuments(string transactionId, IList<Document> requestedDocs);
        IList<Document> GetDocumentsByStatus(string transactionId, CommonTransactionStatusCode returnDocsWithStatus);
        CommonTransactionStatusCode GetDocumentStatus(string transactionId, string id, out string statusDetail);
        void SetDocumentStatus(string transactionID, string id, CommonTransactionStatusCode status, string statusDetail);
    }
}
