package com.windsor.node.repo;

import java.sql.Types;

import org.hibernate.dialect.MySQL5Dialect;

public class NodeMySQLDialect extends MySQL5Dialect {

    @Override
    protected void registerVarcharTypes() {
        super.registerVarcharTypes();
        registerColumnType( Types.VARCHAR, 256, "text" );
        registerColumnType( Types.LONGVARCHAR, "text" );
    }

}
