package com.windsor.node.domain.edit;

import java.io.Serializable;

public class EditPasswordBean implements Serializable {

    private String id;
    private String naasAccount;
    private String oldPassword;
    private String newPassword;

    public EditPasswordBean() {
        this(null, null);
    }

    public EditPasswordBean(String id, String naasAccount) {
        super();
        this.id = id;
        this.naasAccount = naasAccount;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNaasAccount() {
        return naasAccount;
    }

    public void setNaasAccount(String naasAccount) {
        this.naasAccount = naasAccount;
    }

    public String getOldPassword() {
        return oldPassword;
    }

    public void setOldPassword(String oldPassword) {
        this.oldPassword = oldPassword;
    }

    public String getNewPassword() {
        return newPassword;
    }

    public void setNewPassword(String newPassword) {
        this.newPassword = newPassword;
    }

}
