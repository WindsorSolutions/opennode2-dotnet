package com.windsor.node.service.converter;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.edit.EditServiceArgumentBean;
import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ServiceArgument;
import com.windsor.node.domain.entity.ServiceAuthorizationLevel;
import com.windsor.node.domain.entity.ServiceConnection;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.service.ArgumentService;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.service.PluginService;

@Service
@Transactional(readOnly = true)
public class EditExchangeServiceBeanServiceImpl implements EditExchangeServiceBeanService {

    private static final Logger LOGGER = LoggerFactory.getLogger(EditExchangeServiceBeanServiceImpl.class);

    @Autowired
    private ArgumentService argumentService;

    @Autowired
    private PluginService pluginService;

    @Autowired
    private ExchangeServiceService exchangeServiceService;

    @Autowired
    private ExchangeService exchangeService;

    @Override
    public EditExchangeServiceBean toBean(com.windsor.node.domain.entity.ExchangeService exchangeService) {
        EditExchangeServiceBean bean = new EditExchangeServiceBean(exchangeService);
        PluginServiceImplementorDescriptor descriptor = null;
        if (exchangeService.getImplementor() != null) {
            try {
                descriptor = pluginService.getImplementors(exchangeService.getExchange()).stream()
                .filter(d -> d.getClassName().equals(exchangeService.getImplementor()))
                .findAny()
                .orElse(null);
            } catch (IOException e) {
                LOGGER.error("Error getting plugin implementors for exchange: " + exchangeService.getExchange().getName(), e);
            }
        }
        bean.setImplementorDescriptor(descriptor);
        bean.setArguments(newEditServiceArgumentBeanList(getPlugin(exchangeService.getExchange(), exchangeService.getImplementor()), exchangeService.getArguments()));
        return bean;
    }

    @Override
    public List<EditServiceArgumentBean> updateArguments(EditExchangeServiceBean bean) {
        Exchange exchange = exchangeService.load(bean.getExchangeId());
        BaseWnosPlugin plugin = getPlugin(exchange, bean.getImplementorDescriptor().getClassName());
        List<EditServiceArgumentBean> beans = Collections.emptyList();
        if (plugin != null) {
            Map<String, EditServiceArgumentBean> map = bean.getArguments() == null ? Collections.emptyMap()
                    : bean.getArguments().stream().collect(Collectors.toMap(EditServiceArgumentBean::getKey, Function.identity()));
            beans = plugin.getConfigurationArguments().entrySet().stream()
                    .map(e -> map.getOrDefault(e.getKey(), new EditServiceArgumentBean(e.getKey(), e.getValue())))
                    .collect(Collectors.toList());
            List<ServiceType> types = plugin.getSupportedPluginTypes();
            if (types != null && types.size() == 1) {
            	bean.setType(com.windsor.node.domain.entity.ServiceType.valueOf(types.get(0).toString()));
            }
        }
        bean.setArguments(beans);
        return beans;
    }

    @Transactional(readOnly = false)
    @Override
    public com.windsor.node.domain.entity.ExchangeService save(EditExchangeServiceBean bean) {
        com.windsor.node.domain.entity.ExchangeService exchangeService = bean.getId() == null ?
                new com.windsor.node.domain.entity.ExchangeService()
                : exchangeServiceService.load(bean.getId());
        merge(bean, exchangeService);
        return exchangeServiceService.save(exchangeService);
    }

    private void merge(EditExchangeServiceBean bean, com.windsor.node.domain.entity.ExchangeService es) {
        String implementor = bean.getImplementorDescriptor().getClassName();
        es.setActive(bean.isActive());
        es.setImplementor(implementor);
        es.setName(bean.getName());
        es.setType(bean.getType());
        es.setAuthorization(ServiceAuthorizationLevel.Basic);
        es.setSecure(false);
        Exchange exchange = exchangeService.load(bean.getExchangeId());
        es.setExchange(exchange);
        handleConnections(bean.getDataSource(), exchange, implementor, es);
        handleArguments(bean.getArguments(), es);
    }

    private void handleArguments(List<EditServiceArgumentBean> argumentBeans, com.windsor.node.domain.entity.ExchangeService exchangeService) {
        List<ServiceArgument> arguments = exchangeService.getArguments();
        if (arguments == null) {
            arguments = new ArrayList<>();
            exchangeService.setArguments(arguments);
        }
        Map<String, ServiceArgument> map = arguments.stream()
                .collect(Collectors.toMap(ServiceArgument::getKey, Function.identity()));
        arguments.clear();
        arguments.addAll(argumentBeans.stream()
                .filter(EditServiceArgumentBean::hasValue)
                .map(b -> {
                    ServiceArgument arg = map.getOrDefault(b.getKey(), new ServiceArgument(b.getKey(), exchangeService));
                    arg.setValue(b.isUseGlobalArgument() && b.getArgument() != null ? "@" + b.getArgument().getId() : b.getValue());
                    return arg;
                })
                .collect(Collectors.toList()));
    }

    private BaseWnosPlugin getPlugin(Exchange exchange, String implementor) {
        BaseWnosPlugin plugin = null;
        try {
            plugin = pluginService.getPlugin(exchange, implementor);
        } catch (IOException e) {
            LOGGER.error("Error getting plugin: " + exchange.getName() + " - " + implementor, e);
        }
        return plugin;
    }

    private void handleConnections(DataSource dataSource, Exchange exchange, String implementor, com.windsor.node.domain.entity.ExchangeService exchangeService) {
    	if (dataSource == null) {
            List<ServiceConnection> connections = exchangeService.getConnections();
            if (connections != null) {
                connections.clear();
            }
        } else {
            List<ServiceConnection> connections = exchangeService.getConnections();
            String key = null;
            BaseWnosPlugin plugin = getPlugin(exchange, implementor);
            if (plugin != null) {
                Map<String, javax.sql.DataSource> m = plugin.getDataSources();
                key = m.keySet().iterator().next();
            }
            if (connections == null) {
                connections = new ArrayList<>();
                exchangeService.setConnections(connections);
            }
            if (connections.isEmpty()) {
                ServiceConnection c = new ServiceConnection();
                c.setService(exchangeService);
                connections.add(c);
            }
            ServiceConnection connection = connections.iterator().next();
            connection.setKey(key);
            connection.setDataSource(dataSource);
        }
    }

    private List<EditServiceArgumentBean> newEditServiceArgumentBeanList(BaseWnosPlugin plugin, List<ServiceArgument> arguments) {
        List<EditServiceArgumentBean> beans = Collections.emptyList();
        if (plugin != null) {
            Map<String, EditServiceArgumentBean> map = getBeanMap(arguments);
            beans = plugin.getConfigurationArguments().entrySet().stream()
                    .map(e -> map.getOrDefault(e.getKey(), new EditServiceArgumentBean(e.getKey(), e.getValue())))
                    .collect(Collectors.toList());
        }
        return beans;
    }

    private Map<String, EditServiceArgumentBean> getBeanMap(List<ServiceArgument> x) {
        return x.stream()
                .map(sa -> {
                    String value = sa.getValue();
                    Argument arg = null;
                    boolean global = false;
                    if (value != null && value.startsWith("@")) {
                        arg = argumentService.load(value.substring(1));
                        global = true;
                    }
                    return new EditServiceArgumentBean(sa.getKey(), sa.getValue(), global, arg);
                })
                .collect(Collectors.toMap(EditServiceArgumentBean::getKey, Function.identity()));
    }

}
