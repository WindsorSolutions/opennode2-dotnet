package com.windsor.node.plugin.test;

import java.sql.SQLException;

import javax.sql.DataSource;

import oracle.jdbc.pool.OracleDataSource;

public abstract class ExistingOracleDbIT extends AbstractExistingDbIT {

	@Override
	protected DataSource getDataSource() {
		OracleDataSource dataSource;
		try {
			dataSource = new OracleDataSource();
		} catch (final SQLException e) {
			throw new RuntimeException(e);
		}
		dataSource.setUser(getUsername());
		dataSource.setPassword(getPassword());
		dataSource.setURL(getUrl());
		return dataSource;
	}

}
