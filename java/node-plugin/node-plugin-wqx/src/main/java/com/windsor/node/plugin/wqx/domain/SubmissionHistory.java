package com.windsor.node.plugin.wqx.domain;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity(name = "SubmissionHistory")
@Table(name = "WQX_SUBMISSIONHISTORY")
public class SubmissionHistory {

    @Id
    @Column(name = "RECORDID", length = 50)
    private String id;

    @Column(name = "PARENTID", length = 50)
    private String parentId;

    @Column(name = "ORGID", length = 30)
    private String organizationId;

    @Column(name = "SCHEDULERUNDATE")
    private Date scheduleRunDateTime;

    @Column(name = "WQXUPDATEDATE")
    private Date wqxDateTime;

    @Column(name = "SUBMISSIONTYPE", length = 13)
    private String submissionType;

    // TODO PARENTID

    @Column(name = "LOCALTRANSACTIONID", length = 50)
    private String localTransactionId;

    @Column(name = "CDXPROCESSINGSTATUS", length = 50)
    private String cdxProcessingStatus;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getParentId() {
        return parentId;
    }

    public void setParentId(String parentId) {
        this.parentId = parentId;
    }

    public String getOrganizationId() {
        return organizationId;
    }

    public void setOrganizationId(String organizationId) {
        this.organizationId = organizationId;
    }

    public Date getScheduleRunDateTime() {
        return scheduleRunDateTime;
    }

    public void setScheduleRunDateTime(Date scheduleRunDateTime) {
        this.scheduleRunDateTime = scheduleRunDateTime;
    }

    public Date getWqxDateTime() {
        return wqxDateTime;
    }

    public void setWqxDateTime(Date wqxDateTime) {
        this.wqxDateTime = wqxDateTime;
    }

    public String getSubmissionType() {
        return submissionType;
    }

    public void setSubmissionType(String submissionType) {
        this.submissionType = submissionType;
    }

    public String getLocalTransactionId() {
        return localTransactionId;
    }

    public void setLocalTransactionId(String localTransactionId) {
        this.localTransactionId = localTransactionId;
    }

    public String getCdxProcessingStatus() {
        return cdxProcessingStatus;
    }

    public void setCdxProcessingStatus(String cdxProcessingStatus) {
        this.cdxProcessingStatus = cdxProcessingStatus;
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((id == null) ? 0 : id.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        SubmissionHistory other = (SubmissionHistory) obj;
        if (id == null) {
            if (other.id != null)
                return false;
        } else if (!id.equals(other.id))
            return false;
        return true;
    }
}
