package com.windsor.node.domain.entity;

import java.util.List;

import javax.persistence.Cacheable;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.Type;

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NService")
public class ExchangeService extends AbstractBaseEntity {

    @Column(name = "Name", nullable = false)
    private String name;

    @ManyToOne(optional = false)
    @JoinColumn(name = "FlowId", nullable = false)
    private Exchange exchange;

    @Column(name = "IsActive", nullable = false)
    @Type(type = "yes_no")
    private boolean active;

    @Enumerated(EnumType.STRING)
    @Column(name = "ServiceType", nullable = false)
    private ServiceType type;

    @Column(name = "Implementor", nullable = false)
    private String implementor;

    @Enumerated(EnumType.STRING)
    @Column(name = "AuthLevel")
    private ServiceAuthorizationLevel authorization;

    @Column(name = "AuthRequired", columnDefinition = "varchar2")
    @Type(type = "yes_no")
    private Boolean secure;

    @OneToMany(mappedBy = "service", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ServiceArgument> arguments;

    @OneToMany(mappedBy = "service", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ServiceConnection> connections;

    public ExchangeService() {
        super();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public ServiceType getType() {
        return type;
    }

    public void setType(ServiceType type) {
        this.type = type;
    }

    public String getImplementor() {
        return implementor;
    }

    public void setImplementor(String implementor) {
        this.implementor = implementor;
    }

    public ServiceAuthorizationLevel getAuthorization() {
        return authorization;
    }

    public void setAuthorization(ServiceAuthorizationLevel authorization) {
        this.authorization = authorization;
    }

    public Boolean getSecure() {
        return secure;
    }

    public void setSecure(Boolean secure) {
        this.secure = secure;
    }

    public List<ServiceArgument> getArguments() {
        return arguments;
    }

    public void setArguments(List<ServiceArgument> arguments) {
        this.arguments = arguments;
    }

    public List<ServiceConnection> getConnections() {
        return connections;
    }

    public void setConnections(List<ServiceConnection> connections) {
        this.connections = connections;
    }
}
