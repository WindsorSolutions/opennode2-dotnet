package com.windsor.node.domain.edit;

import java.io.Serializable;
import java.util.List;

public class EditNotificationsBean implements Serializable {

    private String accountId;
    private List<EditNotificationBean> notifications;

    public EditNotificationsBean() {
        super();
    }

    public String getAccountId() {
        return accountId;
    }

    public void setAccountId(String accountId) {
        this.accountId = accountId;
    }

    public List<EditNotificationBean> getNotifications() {
        return notifications;
    }

    public void setNotifications(List<EditNotificationBean> notifications) {
        this.notifications = notifications;
    }

}
