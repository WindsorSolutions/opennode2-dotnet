package com.windsor.node.domain.entity;

import java.util.List;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.OrderBy;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.Type;

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NFlow")
public class Exchange extends AbstractBaseEntity {

    @Column(name = "InfoUrl")
    private String url;

    @ManyToOne(optional = false)
    @JoinColumn(name = "Contact")
    private Account contact;

    @Column(name = "IsProtected", nullable = false)
    @Type(type = "yes_no")
    private boolean secure;

    @Column(name = "Code", nullable = false)
    private String name;

    @Column(name = "TargetExchangeName")
    private String targetExchangeName;

    @Column(name = "Description")
    private String description;

    @OneToMany(mappedBy = "exchange")
    private List<AccountPolicy> accountPolicies;

    @OneToMany(mappedBy = "exchange")
    private List<ExchangeService> services;

    @OneToMany(mappedBy = "exchange")
    @OrderBy("ModifiedOn DESC")
    private List<Plugin> plugins;

    @OneToMany(mappedBy = "exchange")
    private List<Notification> notifications;
//
//    @Transient
//    private PluginUpload pluginUpload;

    public Exchange() {
        super();
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public Account getContact() {
        return contact;
    }

    public void setContact(Account contact) {
        this.contact = contact;
    }

    public boolean isSecure() {
        return secure;
    }

    public void setSecure(boolean secure) {
        this.secure = secure;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getTargetExchangeName() {
        return targetExchangeName;
    }

    public void setTargetExchangeName(String targetExchangeName) {
        this.targetExchangeName = targetExchangeName;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public List<AccountPolicy> getAccountPolicies() {
        return accountPolicies;
    }

    public void setAccountPolicies(List<AccountPolicy> accountPolicies) {
        this.accountPolicies = accountPolicies;
    }

    public List<ExchangeService> getServices() {
        return services;
    }

    public void setServices(List<ExchangeService> services) {
        this.services = services;
    }

    public List<Plugin> getPlugins() {
        return plugins;
    }

    public void setPlugins(List<Plugin> plugins) {
        this.plugins = plugins;
    }

    public List<Notification> getNotifications() {
        return notifications;
    }

    public void setNotifications(List<Notification> notifications) {
        this.notifications = notifications;
    }
//
//    public PluginUpload getPluginUpload() {
//        return pluginUpload;
//    }
//
//    public void setPluginUpload(PluginUpload pluginUpload) {
//        this.pluginUpload = pluginUpload;
//    }

    public Plugin getCurrentPlugin() {

        Plugin plugin = null;

        if(getPlugins() != null && !getPlugins().isEmpty()) {
            plugin = plugins.get(0);
        }

        return plugin;
    }

    public boolean hasTargetExchange() {
        return targetExchangeName != null;
    }

    public static Exchange defaultExchange() {
        Exchange exchange = new Exchange();
        exchange.setSecure(true);
        return exchange;
    }

    @Override
    public String toString() {
        return "Exchange{" +
                "url='" + url + '\'' +
                ", contact=" + contact +
                ", secure=" + secure +
                ", name='" + name + '\'' +
                ", targetExchangeName='" + targetExchangeName + '\'' +
                ", description='" + description + '\'' +
                '}';
    }
}
