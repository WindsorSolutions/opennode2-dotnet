package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.GenericGenerator;

import com.windsor.stack.domain.IEntity;

/**
 * Models a data connection for a Service.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NServiceConn")
public class ServiceConnection implements IEntity<String> {

    @Id
    @Column(name = "Id", nullable = false)
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    @GeneratedValue(generator = "uuid")
    private String id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "ServiceId", nullable = false)
    private ExchangeService service;

    @ManyToOne(optional = false)
    @JoinColumn(name = "ConnectionId", nullable = false)
    private DataSource dataSource;

    @Column(name = "keyname", nullable = false)
    private String key;

    public ServiceConnection() {

    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public ExchangeService getService() {
        return service;
    }

    public void setService(ExchangeService service) {
        this.service = service;
    }

    public DataSource getDataSource() {
        return dataSource;
    }

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    @Override
    public boolean isNew() {
        return false;
    }
}
