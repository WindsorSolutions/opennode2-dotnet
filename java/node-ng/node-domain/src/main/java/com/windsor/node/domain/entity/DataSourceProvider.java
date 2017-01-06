package com.windsor.node.domain.entity;

import com.windsor.stack.domain.IIdentifiable;

import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

/**
 * An enumeration of DataSource provider instances.
 */
public enum DataSourceProvider implements IIdentifiable<String> {

    MYSQL("com.mysql.jdbc.Driver", "MySQL"),
    ORACLE("oracle.jdbc.OracleDriver", "Oracle"),
    SQL_SERVER("com.microsoft.sqlserver.jdbc.SQLServerDriver", "MS SQL Server");

    private static final Map<String, DataSourceProvider> ID_MAP = Stream.of(DataSourceProvider.values())
            .collect(Collectors.toMap(DataSourceProvider::getId, e -> e));

    private String id;
    private String description;

    DataSourceProvider(String id, String description) {
        this.id = id;
        this.description = description;
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public static Stream<DataSourceProvider> getMatches(String term) {
        return Stream.of(values())
                .filter(dsp -> dsp.getDescription().toLowerCase().contains(term.toLowerCase()));
    }

    public static Optional<DataSourceProvider> findById(long id) {
        return Optional.ofNullable(ID_MAP.get(id));
    }

    public static DataSourceProvider fromString(String id) {

        DataSourceProvider dataSourceProvider = null;

        for(DataSourceProvider providerThis : DataSourceProvider.values()){
            if(providerThis.getId().equals(id)) {
                dataSourceProvider = providerThis;
                break;
            }
        }

        return dataSourceProvider;
    }

    @Override
    public String toString() {
        return getDescription();
    }
}
