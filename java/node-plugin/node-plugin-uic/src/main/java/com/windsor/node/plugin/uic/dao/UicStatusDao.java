package com.windsor.node.plugin.uic.dao;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.plugin.common.dao.BaseJdbcDao;
import com.windsor.node.plugin.uic.UicOperationType;
import java.sql.Timestamp;
import java.util.List;
import javax.sql.DataSource;
import org.slf4j.Logger;
import org.springframework.jdbc.core.JdbcTemplate;

public class UicStatusDao extends BaseJdbcDao
{
    public static final String TABLE_NAME = "UIC_SUBMISSIONHISTORY";
    public static final String ORG_TABLE_NAME = "UIC_ORGANIZATION";
    public static final String RECORD_ID = "RECORDID";
    public static final String PARENT_ID = "PARENTID";
    public static final String SUBMISSION_TYPE = "SUBMISSIONTYPE";
    public static final String STATUS = "CDXPROCESSINGSTATUS";
    public static final String UICUPDATEDATE = "UICUPDATEDATE";
    public static final String TRAN_ID = "LOCALTRANSACTIONID";
    public static final String ORG_ID = "ORGID";
    public static final String RESET = "Reset";
    public static final String NO_NEW_STATUS_WHEN_PENDING = "Can't create \"Pending\"  or \"Processing\" status when a transaction for that Organization and Operation type is already Pending or Processing.";
    public static final String NO_PENDING_FOUND = "No Pending or Processing transactions found for orgId ";
    private static final String SQL_SELECT_ORG_PK_BY_ORG_ID = " SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? ";
    private static final String ORG_PK_FROM_ORG_ID = "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";
    private static final String SQL_INSERT = " INSERT INTO UIC_SUBMISSIONHISTORY VALUES( ?, ?, ?, ?, ?, ?, ? )";
    private static final String SQL_UPDATE_STATUS = " UPDATE UIC_SUBMISSIONHISTORY SET CDXPROCESSINGSTATUS = ?  WHERE LOCALTRANSACTIONID = ? ";
    private static final String STATUS_PENDING_OR_PROCESSING = "((CDXPROCESSINGSTATUS = '" + CommonTransactionStatusCode.Pending.name() + "'" + ")" + " OR "
                    + "(" + "CDXPROCESSINGSTATUS" + " = " + "'" + CommonTransactionStatusCode.Processing.name() + "'" + ")" + ")";

    private static final String SQL_RESET_STATUS = " UPDATE UIC_SUBMISSIONHISTORY SET CDXPROCESSINGSTATUS = 'Reset' WHERE " + STATUS_PENDING_OR_PROCESSING
                    + " AND " + "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";

    private static final String SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE = " SELECT max(UICUPDATEDATE) FROM  UIC_SUBMISSIONHISTORY WHERE SUBMISSIONTYPE = ?  AND "
                    + STATUS_PENDING_OR_PROCESSING + " AND " + "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";

    private static final String SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID = " SELECT  COUNT(*) FROM  UIC_SUBMISSIONHISTORY WHERE "
                    + STATUS_PENDING_OR_PROCESSING + " AND " + "SUBMISSIONTYPE" + " = ? " + " AND "
                    + "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";

    private static final String SQL_SELECT_PENDING_TRAN = " SELECT LOCALTRANSACTIONID FROM  UIC_SUBMISSIONHISTORY WHERE " + STATUS_PENDING_OR_PROCESSING
                    + " AND " + "SUBMISSIONTYPE" + " = ? " + " AND " + "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";

    private static final String SQL_SELECT_ALL_PENDING_TRANS = " SELECT LOCALTRANSACTIONID FROM  UIC_SUBMISSIONHISTORY WHERE " + STATUS_PENDING_OR_PROCESSING
                    + " AND " + "PARENTID IN ( SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? )";
    private static final String OPERATION_TYPE_EQUALS = ", operationType = ";
    private static final String SQL = "sql: ";
    private int[] argTypes = { 12, 12, 93, 93, 12, 12, 12 };

    public UicStatusDao(DataSource dataSource)
    {
        super.setDataSource(dataSource);
    }

    protected void checkDaoConfig()
    {
        super.checkDaoConfig();
    }

    public void createStatus(String id, String orgId, UicOperationType operationType, String localTransactionId, CommonTransactionStatusCode status)
    {
        checkDaoConfig();
        this.logger.debug("createStatus");
        this.logger.debug("id = " + id);
        this.logger.debug("orgId = " + orgId);
        this.logger.debug("operationType = " + operationType);
        this.logger.debug("localTransactionId = " + localTransactionId);
        this.logger.debug("status = " + status);

        if(null != getPendingTransactionId(orgId, operationType))
        {
            throw new UnsupportedOperationException(
                            "Can't create \"Pending\"  or \"Processing\" status when a transaction for that Organization and Operation type is already Pending or Processing.");
        }

        String orgPk = getPrimaryKeyForOrgId(orgId);

        Object[] args = { id, orgPk, new Timestamp(System.currentTimeMillis()), new Timestamp(System.currentTimeMillis()), operationType.toString(),
                        localTransactionId, status.name() };

        this.logger.debug("args: ");
        for (int i = 0; i < args.length; i++)
        {
            if(args[i] != null)
            {
                this.logger.debug(args[i].toString());
            }
            else
            {
                this.logger.debug("null");
            }
        }

        this.logger.debug("sql:  INSERT INTO UIC_SUBMISSIONHISTORY VALUES( ?, ?, ?, ?, ?, ?, ? )");
        getJdbcTemplate().update(" INSERT INTO UIC_SUBMISSIONHISTORY VALUES( ?, ?, ?, ?, ?, ?, ? )", args, this.argTypes);
    }

    public String getPendingTransactionId(String orgId, UicOperationType operationType)
    {
        String tranId = null;

        checkDaoConfig();
        this.logger.debug("getPendingTransactionId: orgId = " + orgId + ", operationType = " + operationType);

        if(countPending(orgId, operationType) > 0)
        {
            tranId = (String) getJdbcTemplate().queryForObject(SQL_SELECT_PENDING_TRAN, new Object[]{ operationType.toString(), orgId }, String.class);
        }

        return tranId;
    }

    public List<String> getPendingTransactionIds(String orgId)
    {
        List idList = null;

        checkDaoConfig();
        this.logger.debug("getPendingTransactionIds for orgId " + orgId);

        this.logger.debug("sql: " + SQL_SELECT_ALL_PENDING_TRANS);
        idList = getJdbcTemplate().queryForList(SQL_SELECT_ALL_PENDING_TRANS, new Object[]{ orgId }, String.class);

        return idList;
    }

    public Timestamp getLatestProcessedTimestamp(String orgId, UicOperationType operationType)
    {
        Timestamp ts = null;

        this.logger.debug("getLatestProcessedTimestamp: orgId = " + orgId + ", operationType = " + operationType);

        checkDaoConfig();

        this.logger.debug("sql: " + SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE);

        ts = (Timestamp) getJdbcTemplate().queryForObject(SQL_SELECT_LATEST_PROCESSED_BY_ORG_ID_AND_OPERATION_TYPE,
                        new Object[]{ operationType.toString(), orgId }, Timestamp.class);

        return ts;
    }

    public void updateStatus(String tranId, CommonTransactionStatusCode newStatus)
    {
        checkDaoConfig();
        this.logger.debug("updateStatus: tranId = " + tranId + ", newStatus = " + newStatus);

        this.logger.debug("sql:  UPDATE UIC_SUBMISSIONHISTORY SET CDXPROCESSINGSTATUS = ?  WHERE LOCALTRANSACTIONID = ? ");
        getJdbcTemplate().update(" UPDATE UIC_SUBMISSIONHISTORY SET CDXPROCESSINGSTATUS = ?  WHERE LOCALTRANSACTIONID = ? ",
                        new Object[]{ newStatus.name(), tranId });
    }

    public int resetStatus(String orgId)
    {
        checkDaoConfig();
        this.logger.debug("resetStatus");

        this.logger.debug("sql: " + SQL_RESET_STATUS);
        int rowCount = getJdbcTemplate().update(SQL_RESET_STATUS, new Object[]{ orgId });

        this.logger.debug("Reset " + rowCount + " rows for OrgId " + orgId);
        return rowCount;
    }

    public String getPrimaryKeyForOrgId(String orgId)
    {
        checkDaoConfig();
        this.logger.debug("getPrimaryKeyForOrgId");

        this.logger.debug("sql:  SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? ");
        return (String) getJdbcTemplate().queryForObject(" SELECT RECORDID FROM  UIC_ORGANIZATION WHERE ORGID = ? ", new Object[]{ orgId }, String.class);
    }

    private int countPending(String orgId, UicOperationType operationType)
    {
        checkDaoConfig();

        this.logger.debug("sql: " + SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID);
        return getJdbcTemplate().queryForInt(SQL_COUNT_PENDING_BY_OPERATION_TYPE_AND_ORG_ID, new Object[]{ operationType.toString(), orgId });
    }
}