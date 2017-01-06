package com.windsor.node.domain.edit;

import java.io.Serializable;
import java.util.Objects;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;

public class EditExchangeBean implements Serializable {

    private String id;
    private String url;
    private Account contact;
    private boolean secure;
    private String name;
    private String originalName;
    private String targetExchangeName;
    private String description;
    private byte[] pluginContent;

    public EditExchangeBean() {
        super();
    }
    
    public EditExchangeBean(Exchange exchange) {
        setId(exchange.getId());
        setContact(exchange.getContact());
        setDescription(exchange.getDescription());
        setName(exchange.getName());
        setOriginalName(exchange.getName());
        setSecure(exchange.isSecure());
        setTargetExchangeName(exchange.getTargetExchangeName());
        setUrl(exchange.getUrl());
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
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

    public String getOrignalName() {
		return originalName;
	}

	public void setOriginalName(String originalName) {
		this.originalName = originalName;
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

    public byte[] getPluginContent() {
        return pluginContent;
    }

    public void setPluginContent(byte[] uploadBytes) {
        this.pluginContent = uploadBytes;
    }

    public boolean isNameChanged() {
    	return !Objects.equals(name, originalName);
    }
    
}
