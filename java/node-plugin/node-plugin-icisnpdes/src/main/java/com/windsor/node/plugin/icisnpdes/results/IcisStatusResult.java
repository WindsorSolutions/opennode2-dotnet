package com.windsor.node.plugin.icisnpdes.results;

import java.io.Serializable;
import java.util.Date;

public class IcisStatusResult implements Serializable
{
    private static final long serialVersionUID = 758661500084982106L;
    private String trasnactionIdentifier;
    private Date submissionDate;
    private Date processedDate;
    private String submittingPartyUserId;
    private String submissionTypeName;
    private String permitIdentifier;
    private String permittedFeatureIdentifier;
    private String submissionTransactionTypeCode;
    private String errorCode;
    private String errorTypeCode;
    private String errorDescription;

    public String getTrasnactionIdentifier()
    {
        return trasnactionIdentifier;
    }
    public void setTrasnactionIdentifier(String trasnactionIdentifier)
    {
        this.trasnactionIdentifier = trasnactionIdentifier;
    }
    public Date getSubmissionDate()
    {
        return submissionDate;
    }
    public void setSubmissionDate(Date submissionDate)
    {
        this.submissionDate = submissionDate;
    }
    public Date getProcessedDate()
    {
        return processedDate;
    }
    public void setProcessedDate(Date processedDate)
    {
        this.processedDate = processedDate;
    }
    public String getSubmittingPartyUserId()
    {
        return submittingPartyUserId;
    }
    public void setSubmittingPartyUserId(String submittingPartyUserId)
    {
        this.submittingPartyUserId = submittingPartyUserId;
    }
    public String getSubmissionTypeName()
    {
        return submissionTypeName;
    }
    public void setSubmissionTypeName(String submissionTypeName)
    {
        this.submissionTypeName = submissionTypeName;
    }
    public String getPermitIdentifier()
    {
        return permitIdentifier;
    }
    public void setPermitIdentifier(String permitIdentifier)
    {
        this.permitIdentifier = permitIdentifier;
    }
    public String getPermittedFeatureIdentifier()
    {
        return permittedFeatureIdentifier;
    }
    public void setPermittedFeatureIdentifier(String permittedFeatureIdentifier)
    {
        this.permittedFeatureIdentifier = permittedFeatureIdentifier;
    }
    public String getSubmissionTransactionTypeCode()
    {
        return submissionTransactionTypeCode;
    }
    public void setSubmissionTransactionTypeCode(String submissionTransactionTypeCode)
    {
        this.submissionTransactionTypeCode = submissionTransactionTypeCode;
    }
    public String getErrorCode()
    {
        return errorCode;
    }
    public void setErrorCode(String errorCode)
    {
        this.errorCode = errorCode;
    }
    public String getErrorTypeCode()
    {
        return errorTypeCode;
    }
    public void setErrorTypeCode(String errorTypeCode)
    {
        this.errorTypeCode = errorTypeCode;
    }
    public String getErrorDescription()
    {
        return errorDescription;
    }
    public void setErrorDescription(String errorDescription)
    {
        this.errorDescription = errorDescription;
    }
}
