package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.Type;

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NAccountPolicy")
public class AccountPolicy extends AbstractBaseEntity {

    @ManyToOne(optional = false)
    @JoinColumn(name = "AccountId", nullable = false)
    private Account account;

    @Column(name = "PolicyType", nullable = false)
    @Enumerated(EnumType.STRING)
    private PolicyType type;

    @ManyToOne(optional = false)
    @JoinColumn(name = "Qualifier", nullable = false)
    private Exchange exchange;

    @Column(name = "IsAllowed", nullable = false)
    @Type(type = "yes_no")
    private boolean allowed;

    public AccountPolicy() {
        super();
    }

    public AccountPolicy(Account account, Exchange exchange) {
        this();
        this.account = account;
        this.exchange = exchange;
        this.type = PolicyType.Flow;
        this.allowed = true;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }

    public PolicyType getType() {
        return type;
    }

    public void setType(PolicyType type) {
        this.type = type;
    }

    public boolean isAllowed() {
        return allowed;
    }

    public void setAllowed(boolean allowed) {
        this.allowed = allowed;
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

}
