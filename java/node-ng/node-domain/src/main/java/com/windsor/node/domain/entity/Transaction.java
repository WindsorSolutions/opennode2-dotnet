package com.windsor.node.domain.entity;

import java.util.List;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.NotFound;
import org.hibernate.annotations.NotFoundAction;

/**
 * Models a transaction in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NTransaction")
public class Transaction extends AbstractBaseEntity {

    @NotFound(action = NotFoundAction.IGNORE)
    @ManyToOne
    @JoinColumn(name = "FlowId")
    private Exchange exchange;

    @Enumerated(EnumType.STRING)
    @Column(name = "Status", nullable = false)
    private TransactionStatus status;

    @Column(name = "StatusDetail")
    private String detail;

    @Column(name = "Operation")
    private String operation;

    @Column(name = "WebMethod")
    private String webMethod;

    @Column(name = "NetworkId")
    private String remoteTransactionId;

    @Column(name = "NetworkEndpointUrl")
    private String remoteUrl;

    @Column(name = "NetworkEndpointVersion")
    private String remoteVersion;

    @Column(name = "NetworkEndpointStatus")
    private String remoteStatus;

    @OneToMany(mappedBy = "transaction")
    private List<Document> documents;

    public Transaction() {
        super();
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public String getRemoteTransactionId() {
        return remoteTransactionId;
    }

    public void setRemoteTransactionId(String remoteTransactionId) {
        this.remoteTransactionId = remoteTransactionId;
    }

    public TransactionStatus getStatus() {
        return status;
    }

    public void setStatus(TransactionStatus status) {
        this.status = status;
    }

    public String getDetail() {
        return detail;
    }

    public void setDetail(String detail) {
        this.detail = detail;
    }

    public String getOperation() {
        return operation;
    }

    public void setOperation(String operation) {
        this.operation = operation;
    }

    public String getWebMethod() {
        return webMethod;
    }

    public void setWebMethod(String webMethod) {
        this.webMethod = webMethod;
    }

    public String getRemoteUrl() {
        return remoteUrl;
    }

    public void setRemoteUrl(String networkEndpointUrl) {
        this.remoteUrl = networkEndpointUrl;
    }

    public String getRemoteVersion() {
        return remoteVersion;
    }

    public void setRemoteVersion(String remoteVersion) {
        this.remoteVersion = remoteVersion;
    }

    public String getRemoteStatus() {
        return remoteStatus;
    }

    public void setRemoteStatus(String remoteStatus) {
        this.remoteStatus = remoteStatus;
    }

    public List<Document> getDocuments() {
        return documents;
    }

    public void setDocuments(List<Document> documents) {
        this.documents = documents;
    }

    public boolean hasRemoteTransaction() {
        return remoteTransactionId != null;
    }

    public boolean hasDocuments() {
        return documents != null && (!documents.isEmpty());
    }

    public boolean hasTargetExchange() {
        return exchange != null && exchange.hasTargetExchange();
    }

    public boolean hasQueryableRemoteTransaction() {
        return remoteTransactionId != null
                && remoteUrl != null
                && remoteVersion != null;
    }

}