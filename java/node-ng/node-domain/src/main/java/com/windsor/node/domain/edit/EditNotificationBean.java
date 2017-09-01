package com.windsor.node.domain.edit;

import java.io.Serializable;

import com.windsor.node.domain.entity.Notification;

public class EditNotificationBean implements Serializable {

    private String exchangeId;
    private String exchangeName;
    private boolean solicit;
    private boolean query;
    private boolean submit;
    private boolean notify;
    private boolean schedule;
    private boolean download;
    private boolean execute;
    private boolean error;

    public EditNotificationBean() {

    }

    public EditNotificationBean(Notification notification) {
        this.exchangeId = notification.getExchange().getId();
        this.exchangeName = notification.getExchange().getName();
        solicit = notification.isSolicit();
        query = notification.isQuery();
        submit = notification.isSubmit();
        notify = notification.isNotify();
        schedule = notification.isSchedule();
        download = notification.isDownload();
        execute = notification.isExecute();
        error = notification.isError();
    }

    public void merge(Notification notification) {
        notification.setDownload(download);
        notification.setExecute(execute);
        notification.setNotify(notify);
        notification.setQuery(query);
        notification.setSchedule(schedule);
        notification.setSolicit(solicit);
        notification.setSubmit(submit);
        notification.setError(error);
    }

    public Notification newNotification() {
        Notification n = new Notification();
        merge(n);
        return n;
    }

    public boolean isEmpty() {
        return (!(solicit || query || submit || notify || schedule || download || execute || error));
    }

    public String getExchangeId() {
        return exchangeId;
    }

    public void setExchangeId(String exchangeId) {
        this.exchangeId = exchangeId;
    }

    public EditNotificationBean exchangeId(String exchangeId) {
        setExchangeId(exchangeId);
        return this;
    }

    public String getExchangeName() {
        return exchangeName;
    }

    public void setExchangeName(String exchangeName) {
        this.exchangeName = exchangeName;
    }

    public EditNotificationBean exchangeName(String exchangeName) {
        setExchangeName(exchangeName);
        return this;
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

    public boolean isError() {
        return error;
    }

    public void setError(boolean error) {
        this.error = error;
    }

    public void setAll(boolean value) {
        solicit = value;
        query = value;
        submit = value;
        notify = value;
        schedule = value;
        download = value;
        execute = value;
        error = value;
    }

}
