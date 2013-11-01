package com.windsor.node.plugin.wqx.service;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.apache.commons.lang3.StringUtils;

import com.windsor.node.common.domain.NodeTransaction;

/**
 * A class to wrap the parameters defined in the WQX schedule.
 *
 */
public class ScheduleParameters {

    protected static final int PARAM_INDEX_ORGID = 0;
    protected static final int PARAM_INDEX_USE_HISTORY = 1;
    protected static final int PARAM_INDEX_START_DATE = 2;
    protected static final int PARAM_INDEX_END_DATE = 3;
    protected static final int PARAM_INDEX_SUBMISSION_PARTNER_NAME = 4;

    private final NodeTransaction transaction;

    private final SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");

    public ScheduleParameters(NodeTransaction transaction) {
        this.transaction = transaction;
    }

    public boolean isUseSubmissionHistory() {
        if(transaction.getRequest().getParameters().get(AbstractWqxService.USE_SUBMISSION_HISTORY.getName()) != null)
        {
            return Boolean.parseBoolean((String)transaction.getRequest().getParameters().get(AbstractWqxService.USE_SUBMISSION_HISTORY.getName()));
        }
        return booleanValue(PARAM_INDEX_USE_HISTORY);
    }

    public String getOrgId() {
        if(transaction.getRequest().getParameters().get(AbstractWqxService.ORG_ID.getName()) != null)
        {
            return (String)transaction.getRequest().getParameters().get(AbstractWqxService.ORG_ID.getName());
        }
        return stringValue(PARAM_INDEX_ORGID);
    }

    public String getSubmissionPartnerName() {
        if(transaction.getRequest().getParameters().get(AbstractWqxService.SUBMISSION_PARTNER_NAME.getName()) != null)
        {
            return (String)transaction.getRequest().getParameters().get(AbstractWqxService.SUBMISSION_PARTNER_NAME.getName());
        }
        return stringValue(PARAM_INDEX_SUBMISSION_PARTNER_NAME);
    }

    public Date getStartDate() {
        if(transaction.getRequest().getParameters().get(AbstractWqxService.START_DATE.getName()) != null)
        {
            return dateValue((String)transaction.getRequest().getParameters().get(AbstractWqxService.START_DATE.getName()));
        }
        return dateValue((String)transaction.getRequest().getParameters().get(PARAM_INDEX_START_DATE));
    }

    public Date getEndDate() {
        if(transaction.getRequest().getParameters().get(AbstractWqxService.END_DATE.getName()) != null)
        {
            return dateValue((String)transaction.getRequest().getParameters().get(AbstractWqxService.END_DATE.getName()));
        }
        return dateValue((String)transaction.getRequest().getParameters().get(PARAM_INDEX_END_DATE));
    }

    private boolean booleanValue(int index) {
        return Boolean.parseBoolean((String) transaction.getRequest().getParameters().get(index));
    }

    protected final String stringValue(int index) {
        return (String) transaction.getRequest().getParameters().get(index);
    }

    protected final Date dateValue(String dateString) {

        try {

            if (StringUtils.isNotEmpty(dateString)) {
                return sdf.parse(dateString);
            } else {
                return null;
            }

        } catch (ParseException e) {
            return null;
        }
    }
}
