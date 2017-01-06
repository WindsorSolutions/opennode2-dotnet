package com.windsor.node.domain.edit;

import java.io.Serializable;
import java.util.List;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.ServiceType;

public class EditExchangeServiceBean implements Serializable {

    private String id;
    private String exchangeId;
    private String name;
    private boolean active;
    private ServiceType type;
    private PluginServiceImplementorDescriptor implementorDescriptor;
    private DataSource dataSource;
    private List<EditServiceArgumentBean> arguments;

    public EditExchangeServiceBean(String exchangeId) {
        this.exchangeId = exchangeId;
        this.active = true;
    }

    public EditExchangeServiceBean(ExchangeService exchangeService) {
        super();
        this.id = exchangeService.getId();
        this.exchangeId = exchangeService.getExchange().getId();
        this.name = exchangeService.getName();
        this.active = exchangeService.isActive();
        this.type = exchangeService.getType();
        this.dataSource = exchangeService.getConnections() == null
                || exchangeService.getConnections().isEmpty()
                ? null
                : exchangeService.getConnections().iterator().next().getDataSource();
    }
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public String getExchangeId() {
        return exchangeId;
    }

    public void setExchangeId(String exchangeId) {
        this.exchangeId = exchangeId;
    }

    public void setName(String name) {
        this.name = name;
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

    public List<EditServiceArgumentBean> getArguments() {
        return arguments;
    }

    public void setArguments(List<EditServiceArgumentBean> arguments) {
        this.arguments = arguments;
    }

    public PluginServiceImplementorDescriptor getImplementorDescriptor() {
        return implementorDescriptor;
    }

    public void setImplementorDescriptor(PluginServiceImplementorDescriptor implementoDescriptor) {
        this.implementorDescriptor = implementoDescriptor;
    }

    public DataSource getDataSource() {
        return dataSource;
    }

    public void setDataSource(DataSource dataSource) {
        this.dataSource = dataSource;
    }

}
