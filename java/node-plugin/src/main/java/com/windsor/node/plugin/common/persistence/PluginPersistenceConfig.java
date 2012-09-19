package com.windsor.node.plugin.common.persistence;

public class PluginPersistenceConfig {

    private String rootEntityPackage;

    private boolean debugSql = Boolean.FALSE;

    public boolean isDebugSql() {
        return debugSql;
    }

    public String getRootEntityPackage() {
        return rootEntityPackage;
    }

    public PluginPersistenceConfig rootEntityPackage(String rootEntityPackage) {
        this.rootEntityPackage = rootEntityPackage;
        return this;
    }

    public PluginPersistenceConfig debugSql(boolean debugSql) {
        this.debugSql = debugSql;
        return this;
    }
}

