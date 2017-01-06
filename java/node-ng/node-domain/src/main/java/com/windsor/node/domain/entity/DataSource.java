package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.validation.constraints.Size;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;

/**
 * Models a data source in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NConnection")
public class DataSource extends AbstractBaseEntity {

    @Size(min = 3, max = 255)
    @Column(name = "Code")
    private String name;

    @Column(name = "Provider")
    private DataSourceProvider provider;

    @Size(min = 3, max = 500)
    @Column(name = "ConnectionString")
    private String connection;

    public DataSource() {

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public DataSourceProvider getProvider() {
        return provider;
    }

    public void setProvider(DataSourceProvider provider) {
        this.provider = provider;
    }

    public String getConnection() {
        return connection;
    }

    public void setConnection(String connection) {
        this.connection = connection;
    }

    @Override
    public String toString() {
        return "DataSource{" +
                "name='" + name + '\'' +
                ", provider=" + provider +
                ", connection='" + connection + '\'' +
                '}';
    }
}
