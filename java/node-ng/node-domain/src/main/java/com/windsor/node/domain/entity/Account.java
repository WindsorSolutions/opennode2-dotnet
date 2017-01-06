package com.windsor.node.domain.entity;

import java.util.List;
import java.util.stream.Stream;

import javax.persistence.Cacheable;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Size;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.Type;

import com.windsor.node.domain.NodePermission;
import com.windsor.stack.domain.util.ISerializableBiFunction;

/**
 * Models an account in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NAccount")
public class Account extends AbstractBaseEntity {

    public static final ISerializableBiFunction<Account, NodePermission, Boolean> HAS_PERMISSION = (account, perm) ->
            account.getSystemRoleType().getPermissions().stream()
                    .anyMatch(permission -> permission.equals(perm));

    @Size(min = 3, max = 50)
    @Column(name = "NAASAccount")
    private String naasAccount;

    @Type(type = "yes_no")
    @Column(name = "IsActive", columnDefinition = "varchar2(1)", nullable = false)
    private boolean active;

    @Enumerated(EnumType.STRING)
    @Column(name = "SystemRole", nullable = false)
    private SystemRoleType systemRoleType;

    @Size(max = 50)
    @Column(name = "Affiliation", nullable = false)
    private String affiliation;

    @Type(type = "yes_no")
    @Column(name = "IsDeleted", columnDefinition = "varchar2(1)")
    private Boolean deleted;

    @Type(type = "yes_no")
    @Column(name = "IsDemoUser", columnDefinition = "varchar2(1)")
    private Boolean demoUser;

    @Size(max = 50)
    @Column(name = "PasswordHash")
    private String passwordHash;

    @OneToMany(mappedBy = "account", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<AccountPolicy> accountPolicies;

    @OneToMany(mappedBy = "account", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<Notification> notifications;

    public Account() {
        super();
    }

    public String getNaasAccount() {
        return naasAccount;
    }

    public void setNaasAccount(String naasAccount) {
        this.naasAccount = naasAccount;
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

    public String getAffiliation() {
        return affiliation;
    }

    public void setAffiliation(String affiliation) {
        this.affiliation = affiliation;
    }

    public Boolean getDeleted() {
        return deleted;
    }

    public void setDeleted(Boolean deleted) {
        this.deleted = deleted;
    }

    public Boolean getDemoUser() {
        return demoUser;
    }

    public void setDemoUser(Boolean demoUser) {
        this.demoUser = demoUser;
    }

    public String getPasswordHash() {
        return passwordHash;
    }

    public void setPasswordHash(String passwordHash) {
        this.passwordHash = passwordHash;
    }

    public boolean hasPermission(NodePermission permission) {
        return HAS_PERMISSION.apply(this, permission);
    }

    public List<AccountPolicy> getAccountPolicies() {
        return accountPolicies;
    }

    public void setAccountPolicies(List<AccountPolicy> accountPolicies) {
        this.accountPolicies = accountPolicies;
    }

    public Stream<AccountPolicy> getAccountPoliciesStream() {
        return accountPolicies == null ? Stream.empty() : accountPolicies.stream();
    }

    public List<Notification> getNotifications() {
        return notifications;
    }

    public void setNotifications(List<Notification> notifications) {
        this.notifications = notifications;
    }

    public Stream <Notification> getNotificationsStream() {
        return notifications == null ? Stream.empty() : notifications.stream();
    }

    @Override
    public String toString() {
        return getNaasAccount();
    }
}
