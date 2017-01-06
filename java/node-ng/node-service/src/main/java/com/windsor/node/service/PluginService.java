package com.windsor.node.service;

import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;

import java.io.IOException;
import java.util.List;

/**
 * Provides a service for managing plugins.
 */
public interface PluginService {

    List<ServiceType> transform(List<com.windsor.node.common.domain.ServiceType> serviceTypes);

    BaseWnosPlugin getPlugin(Exchange exchange, String implementorClass) throws IOException;

    PluginMetaData getPluginMetadata(Exchange exchange) throws IOException;

    List<PluginServiceImplementorDescriptor> getImplementors(Exchange exchange) throws IOException;
}
