package com.windsor.node.plugin.icisnpdes.domain;

import java.io.Serializable;
import java.util.Date;

public class IcisWorkflow implements Serializable
{
    private static final long serialVersionUID = -4870692614450516349L;

    private String id;
    private Date etlCompletionDate;
    private Date detectionChangeCompletionDate;
    private Date submissionDate;
    private String submissionTransactionId;
    private String submissionTransactionStatus;
    private Date submissionStatusDate;
    private Date responseParseDate;
    private String workflowStatus;
    private String workflowStatusMessage;

    public String getId()
    {
        return id;
    }
    public void setId(String id)
    {
        this.id = id;
    }
    public Date getEtlCompletionDate()
    {
        return etlCompletionDate;
    }
    public void setEtlCompletionDate(Date etlCompletionDate)
    {
        this.etlCompletionDate = etlCompletionDate;
    }
    public Date getDetectionChangeCompletionDate()
    {
        return detectionChangeCompletionDate;
    }
    public void setDetectionChangeCompletionDate(Date detectionChangeCompletionDate)
    {
        this.detectionChangeCompletionDate = detectionChangeCompletionDate;
    }
    public Date getSubmissionDate()
    {
        return submissionDate;
    }
    public void setSubmissionDate(Date submissionDate)
    {
        this.submissionDate = submissionDate;
    }
    public String getSubmissionTransactionId()
    {
        return submissionTransactionId;
    }
    public void setSubmissionTransactionId(String submissionTransactionId)
    {
        this.submissionTransactionId = submissionTransactionId;
    }
    public String getSubmissionTransactionStatus()
    {
        return submissionTransactionStatus;
    }
    public void setSubmissionTransactionStatus(String submissionTransactionStatus)
    {
        this.submissionTransactionStatus = submissionTransactionStatus;
    }
    public Date getSubmissionStatusDate()
    {
        return submissionStatusDate;
    }
    public void setSubmissionStatusDate(Date submissionStatusDate)
    {
        this.submissionStatusDate = submissionStatusDate;
    }
    public Date getResponseParseDate()
    {
        return responseParseDate;
    }
    public void setResponseParseDate(Date responseParseDate)
    {
        this.responseParseDate = responseParseDate;
    }
    public String getWorkflowStatus()
    {
        return workflowStatus;
    }
    public void setWorkflowStatus(String workflowStatus)
    {
        this.workflowStatus = workflowStatus;
    }
    public String getShortWorkflowStatusMessage()
    {
        if(workflowStatusMessage != null && workflowStatusMessage.length() > 200)
        {
            return workflowStatusMessage.substring(0, 200);
        }
        return workflowStatusMessage;
    }
    public String getWorkflowStatusMessage()
    {
        if(workflowStatusMessage != null && workflowStatusMessage.length() > 3000)
        {
            return workflowStatusMessage.substring(0, 3000);
        }
        return workflowStatusMessage;
    }
    public void setWorkflowStatusMessage(String workflowStatusMessage)
    {
        this.workflowStatusMessage = workflowStatusMessage;
    }
}
