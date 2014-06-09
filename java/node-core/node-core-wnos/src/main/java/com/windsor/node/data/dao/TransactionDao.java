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

package com.windsor.node.data.dao;

import java.util.List;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeMethodType;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduledItem;

public interface TransactionDao extends DeletableDao, ListableDao<NodeTransaction> {

    /**
     * @param transaction
     * @return
     */
    NodeTransaction save(NodeTransaction transaction);

    /**
     * 
     * @param dataFlow
     * @param visit
     * @param callingMethodType
     * @param initialStatus
     * @return
     */
    NodeTransaction make(DataFlow dataFlow, NodeVisit visit, NodeMethodType callingMethodType, CommonTransactionStatusCode initialStatus);

    /**
     * 
     * @param schedule
     * @param method
     * @param status
     * @return
     */
    NodeTransaction make(ScheduledItem schedule, NodeMethodType method, CommonTransactionStatusCode status);

    /**
     * @param id
     * @param useNetworkId
     * @return List<NodeTransaction>
     */
    NodeTransaction get(String id, boolean useNetworkId);

    /**
     * @param status
     * @param method
     * @return List<NodeTransaction>
     */
    List<NodeTransaction> get(CommonTransactionStatusCode status, NodeMethodType method);

    /**
     * @param method
     * @return
     */
    List<NodeTransaction> get(NodeMethodType method);

    /**
     * @param method
     * @return
     */
    NodeTransaction getNextReceived(NodeMethodType method);

    /**
     * @param transactionId
     * @param instance
     * @return
     */
    Document addDocument(String transactionId, Document instance);

    /**
     * @param transactionId
     * @param documentId
     * @return
     * @deprecated
     */
    @Deprecated
    Document getDocument(String transactionId, String documentId);

    /**
     * Replacement for Document getDocument(String transactionId, String documentId)
     * @param transactionId
     * @param documentId
     * @return
     */
    Document getDocumentByTransactionIdAndDocumentId(String transactionId, String documentId);

    /**
     * documentId the NDocument DocumentId field value, not the id PK field 
     * @param transactionId
     * @param id NDocument id PK field value 
     * @return
     */
    Document getDocumentByTransactionIdAndId(String transactionId, String id);

    /**
     * getDocumentByName
     * 
     * @param transactionId
     * @param documentName
     * @return
     */
    Document getDocumentByName(String transactionId, String documentName);

    /**
     * @param transactionId
     * @param useNetworkId
     * @return
     */
    List<Document> getDocuments(String transactionId, boolean useNetworkId,
            boolean loadDocContent);

    /**
     * @param transactionId
     * @param status
     */
    void updateStatus(String transactionId, CommonTransactionStatusCode status);

    /**
     * @param transactionId
     * @param networkId
     */
    void updateNetworkId(String transactionId, String networkId);

    /**
     * @return
     */
    List<NodeTransaction> getSubmittedDocumentTransactions();
}