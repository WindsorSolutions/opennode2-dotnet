package com.windsor.node.plugin.attains.dao.jdbc;

import java.util.ArrayList;
import java.util.List;
import org.springframework.jdbc.core.support.JdbcDaoSupport;
import com.windsor.node.plugin.attains.dao.AttainsValidationDao;

public class JdbcAttainsValidationDao extends JdbcDaoSupport implements AttainsValidationDao
{
    private String countStateAssessmentDetailsSql = "select count(*) from OWIR_STATE_ASMT_DTLS";

    @Override
    public List<String> validateDataState()
    {
        List<String> errors = new ArrayList<String>();
        Long count = getJdbcTemplate().queryForObject(countStateAssessmentDetailsSql, Long.class);
        if(count != null && count < 1)
        {
            errors.add("DATA VALIDATION ERROR: At least one StateAssessmentDetails object must be present in the OWIR_STATE_ASMT_DTLS table.");
        }
        return errors;
    }
}
