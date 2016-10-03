package com.windsor.node.plugin.common.persistence;


public class PluginPersistenceConfig {

    private String rootEntityPackage;
    private ClassLoader classLoader;
    private String hibernateDialect; //Should rarely be used
    private String[] additionalEntityPackages;

    private boolean debugSql = Boolean.FALSE;

    private Integer batchFetchSize;

    public Integer getBatchFetchSize() {
        return batchFetchSize;
    }

    public PluginPersistenceConfig setBatchFetchSize(Integer batchFetchSize) {
        this.batchFetchSize = batchFetchSize;
        return this;
    }

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

    public String[] getAdditionalEntityPackages() {
        return additionalEntityPackages;
    }

    public void setAdditionalEntityPackages(String[] additionalEntityPackages) {
        this.additionalEntityPackages = additionalEntityPackages;
    }

    public PluginPersistenceConfig additionalEntityPackages(String... additionalEntityPackages) {
        setAdditionalEntityPackages(additionalEntityPackages);
        return this;
    }

    public PluginPersistenceConfig hibernateDialect(String hibernateDialect) {
        this.hibernateDialect = hibernateDialect;
        return this;
    }

    public PluginPersistenceConfig classLoader(ClassLoader classLoader) {
        this.classLoader = classLoader;
        return this;
    }

    public ClassLoader getClassLoader()
    {
        return classLoader;
    }

    public PluginPersistenceConfig debugSql(boolean debugSql) {
        this.debugSql = debugSql;
        return this;
    }

    public String getHibernateDialect()
    {
        return hibernateDialect;
    }
}

