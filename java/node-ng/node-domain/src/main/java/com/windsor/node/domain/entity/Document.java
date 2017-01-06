package com.windsor.node.domain.entity;

import javax.persistence.Basic;
import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;

import com.windsor.stack.domain.IEntity;

/**
 * Models an activity in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NDocument")
public class Document implements IEntity<String> {

    @Id
    @Column(name = "Id")
    private String id;

    @ManyToOne
    @JoinColumn(name = "TransactionId")
    private Transaction transaction;

    @Column(name = "DocumentName")
    private String name;

    @Enumerated(EnumType.STRING)
    @Column(name = "DocumentType", nullable = false)
    private DocumentType type;

    @Column(name = "DocumentId", nullable = false)
    private String documentId;

    @Enumerated(EnumType.STRING)
    @Column(name = "Status", nullable = false)
    private DocumentStatus status;

    @Column(name = "StatusDetail")
    private String statusDetail;

    @Lob
    @Basic(fetch = FetchType.LAZY)
    @Column(name = "DocumentContent")
    private byte[] content;

    public Document() {
        super();
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Transaction getTransaction() {
        return transaction;
    }

    public void setTransaction(Transaction transaction) {
        this.transaction = transaction;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public DocumentType getType() {
        return type;
    }

    public void setType(DocumentType type) {
        this.type = type;
    }

    public String getDocumentId() {
        return documentId;
    }

    public void setDocumentId(String documentId) {
        this.documentId = documentId;
    }

    public DocumentStatus getStatus() {
        return status;
    }

    public void setStatus(DocumentStatus status) {
        this.status = status;
    }

    public String getStatusDetail() {
        return statusDetail;
    }

    public void setStatusDetail(String statusDetail) {
        this.statusDetail = statusDetail;
    }

    public byte[] getContent() {
        return content;
    }

    public void setContent(byte[] content) {
        this.content = content;
    }

    @Override
    public boolean isNew() {
        return id == null;
    }

}
