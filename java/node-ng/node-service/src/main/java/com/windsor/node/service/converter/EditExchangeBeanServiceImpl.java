package com.windsor.node.service.converter;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Plugin;
import com.windsor.node.repo.PluginRepository;
import com.windsor.node.service.ExchangeService;

@Transactional(readOnly = true)
@Service
public class EditExchangeBeanServiceImpl implements EditExchangeBeanService {

    @Autowired
    private ExchangeService exchangeService;

    @Autowired
    private PluginRepository pluginRepo;

    @Override
    public EditExchangeBean toBean(Exchange exchange) {
        return new EditExchangeBean(exchange);
    }

    @Transactional(readOnly = false)
    @Override
    public Exchange save(EditExchangeBean bean) {
        Exchange exchange = bean.getId() == null ? Exchange.defaultExchange() : exchangeService.load(bean.getId());
        exchange.setContact(bean.getContact());
        exchange.setDescription(bean.getDescription());
        exchange.setName(bean.getName());
        exchange.setSecure(bean.isSecure());
        exchange.setTargetExchangeName(bean.getTargetExchangeName());
        exchange.setUrl(bean.getUrl());

        exchange = exchangeService.save(exchange);

        byte[] pluginContent = bean.getPluginContent();
        if (pluginContent != null) {
            Plugin plugin = new Plugin();
            plugin.setContent(pluginContent);
            plugin.setExchange(exchange);
            pluginRepo.save(plugin);
        }

        return exchange;

    }

}
