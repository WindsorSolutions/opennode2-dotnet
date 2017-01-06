package com.windsor.node.service.converter;

import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.edit.EditNotificationBean;
import com.windsor.node.domain.edit.EditNotificationsBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Notification;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.service.AccountService;
import com.windsor.node.service.ExchangeService;

@Transactional(readOnly = true)
@Service
public class EditNotificationsBeanServiceImpl implements EditNotificationsBeanService {

    @Autowired
    private ExchangeService exchangeService;

    @Autowired
    private AccountService accountService;

    @Override
    public EditNotificationsBean toBean(Account account) {
        List<String> existingExchangeIds = account.getNotificationsStream()
                .map(Notification::getExchange)
                .map(Exchange::getId)
                .collect(Collectors.toList());

        Stream<EditNotificationBean> existingExchanges = account.getNotificationsStream()
                .map(n -> new EditNotificationBean(n));

        Stream<EditNotificationBean> nonExistingExchanges = exchangeService.find(new ExchangeSearchCriteria()
                .notIds(existingExchangeIds.isEmpty() ? null : existingExchangeIds),
                ExchangeSorts.NAME)
                .map(x -> new EditNotificationBean().exchangeId(x.getId()).exchangeName(x.getName()));

        List<EditNotificationBean> notifications = Stream.concat(existingExchanges, nonExistingExchanges)
                .sorted((b1, b2) -> b1.getExchangeName().compareTo(b2.getExchangeName()))
                        .collect(Collectors.toList());

        EditNotificationsBean bean = new EditNotificationsBean();
        bean.setAccountId(account.getId());
        bean.setNotifications(notifications);

        return bean;
    }

    @Transactional(readOnly = false)
    @Override
    public Account save(EditNotificationsBean bean) {
        Account account = accountService.load(bean.getAccountId());

        // delete empty ones
        List<String> idsToDelete = bean.getNotifications().stream()
                .filter(EditNotificationBean::isEmpty)
                .map(EditNotificationBean::getExchangeId)
                .collect(Collectors.toList());
        account.getNotifications().removeIf(x -> idsToDelete.contains(x.getExchange().getId()));

        // update existing ones
        Map<String, EditNotificationBean> map = bean.getNotifications().stream()
                .filter(b -> !b.isEmpty())
                .collect(Collectors.toMap(EditNotificationBean::getExchangeId, Function.identity()));
        account.getNotifications().forEach(n -> {
            EditNotificationBean y = map.get(n.getExchange().getId());
            if (y != null) {
                y.merge(n);
            }
        });

        // add new ones
        Map<String, Notification> mm = account.getNotificationsStream()
                .collect(Collectors.toMap(x -> x.getExchange().getId(), x -> x));
        account.getNotifications().addAll(bean.getNotifications().stream()
                .filter(b -> !b.isEmpty())
                .filter(b -> !mm.containsKey(b.getExchangeId()))
                .map(b -> {
                    Notification n = b.newNotification();
                    n.setExchange(exchangeService.load(b.getExchangeId()));
                    n.setAccount(account);
                    return n;
                })
                .collect(Collectors.toList()));

        return accountService.save(account);
    }

}
