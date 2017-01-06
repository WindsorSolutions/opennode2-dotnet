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

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NServiceArg")
public class ServiceArgument implements IEntity<String> {

    @Id
    @Column(name = "Id", nullable = false)
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    @GeneratedValue(generator = "uuid")
    private String id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "ServiceId", nullable = false)
    private ExchangeService service;

    @Column(name = "ArgKey", nullable = false)
    private String key;

    @Column(name = "ArgValue", nullable = false)
    private String value;

    public ServiceArgument() {
        super();
    }

    public ServiceArgument(String key, ExchangeService service) {
        this.key = key;
        this.service = service;
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

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    @Override
    public boolean isNew() {
        return id == null;
    }
}
