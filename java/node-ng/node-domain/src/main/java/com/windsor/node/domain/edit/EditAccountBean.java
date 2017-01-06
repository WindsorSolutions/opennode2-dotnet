package com.windsor.node.domain.edit;

import java.io.Serializable;
import java.util.List;
import java.util.stream.Stream;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.SystemRoleType;

public class EditAccountBean implements Serializable {

    private String id;
    private String naasAccount;
    private String affiliation;
    private boolean active;
    private SystemRoleType systemRoleType;
    private List<Exchange> exchanges;

    public EditAccountBean() {
        super();
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

    public String getAffiliation() {
        return affiliation;
    }

    public void setAffiliation(String affiliation) {
        this.affiliation = affiliation;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public SystemRoleType getSystemRoleType() {
        return systemRoleType;
    }

    public void setSystemRoleType(SystemRoleType systemRoleType) {
        this.systemRoleType = systemRoleType;
    }

    public List<Exchange> getExchanges() {
        return exchanges;
    }

    public void setExchanges(List<Exchange> exchanges) {
        this.exchanges = exchanges;
    }

    public Stream<Exchange> getExchangesStream() {
        return exchanges == null ? Stream.empty() : exchanges.stream();
    }

}
