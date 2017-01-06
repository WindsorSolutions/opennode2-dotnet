package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.NotFound;
import org.hibernate.annotations.NotFoundAction;
import org.hibernate.annotations.Type;

/**
 * Models a notification in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NNotification")
public class Notification extends AbstractBaseEntity {

    @NotFound(action = NotFoundAction.IGNORE)
    @ManyToOne
    @JoinColumn(name = "FlowId")
    private Exchange exchange;

    @NotFound(action = NotFoundAction.IGNORE)
    @ManyToOne
    @JoinColumn(name = "AccountId")
    private Account account;

    @Type(type = "yes_no")
    @Column(name = "OnSolicit", nullable = false)
    private boolean solicit;

    @Type(type = "yes_no")
    @Column(name = "OnQuery", nullable = false)
    private boolean query;

    @Type(type = "yes_no")
    @Column(name = "OnSubmit", nullable = false)
    private boolean submit;

    @Type(type = "yes_no")
    @Column(name = "OnNotify", nullable = false)
    private boolean notify;

    @Type(type = "yes_no")
    @Column(name = "OnSchedule", nullable = false)
    private boolean schedule;

    @Type(type = "yes_no")
    @Column(name = "OnDownload", nullable = false)
    private boolean download;

    @Type(type = "yes_no")
    @Column(name = "OnExecute", nullable = false)
    private boolean execute;

    public Notification() {
        super();
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public Account getAccount() {
        return account;
    }

    public void setAccount(Account account) {
        this.account = account;
    }

    public boolean isSolicit() {
        return solicit;
    }

    public void setSolicit(boolean solicit) {
        this.solicit = solicit;
    }

    public boolean isQuery() {
        return query;
    }

    public void setQuery(boolean query) {
        this.query = query;
    }

    public boolean isSubmit() {
        return submit;
    }

    public void setSubmit(boolean submit) {
        this.submit = submit;
    }

    public boolean isNotify() {
        return notify;
    }

    public void setNotify(boolean notify) {
        this.notify = notify;
    }

    public boolean isSchedule() {
        return schedule;
    }

    public void setSchedule(boolean schedule) {
        this.schedule = schedule;
    }

    public boolean isDownload() {
        return download;
    }

    public void setDownload(boolean download) {
        this.download = download;
    }

    public boolean isExecute() {
        return execute;
    }

    public void setExecute(boolean execute) {
        this.execute = execute;
    }

}
