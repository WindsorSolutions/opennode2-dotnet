package com.windsor.node.plugin.beachnotif21.dao;

import javax.sql.DataSource;
import com.windsor.node.plugin.common.dao.BaseJdbcDao;

public class BeachNotificationDao extends BaseJdbcDao
{
    private final String UPDATE_BEACH_SENTTOEPA_SQL = "UPDATE NOTIF_BEACHACTIVITY SET SENTTOEPA = 'Y' WHERE SENTTOEPA='N'";

    public BeachNotificationDao(DataSource dataSource)
    {
        super.setDataSource(dataSource);
    }

    public void updateSentToEPAFlag()
    {
        getJdbcTemplate().update(UPDATE_BEACH_SENTTOEPA_SQL);
    }
}
