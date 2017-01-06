package com.windsor.node.web.content.schedule;

import java.util.List;
import java.util.stream.Collectors;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.LoadableDetachableModel;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.AccountPolicySearchCriteria;
import com.windsor.node.domain.search.AccountPolicySorts;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.service.AccountPolicyService;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.NodeUser;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;

/**
 * Provides a list of Exchange instances
 */
public class ScheduleExchangeListPanel extends AbstractBasePanel<ScheduleSearchCriteria> {

    @SpringBean
    private ExchangeService exchangeService;

    public ScheduleExchangeListPanel(String cid, IModel<ScheduleSearchCriteria> model) {
        super(cid, model);

        add(new ListView<Exchange>("exchanges", new AccountExchangeListModel()) {

            @Override
            protected void populateItem(ListItem<Exchange> listItem) {
                listItem.add(new ScheduleExchangeDetailPanel("exchange", listItem.getModel()));
            }

        });
    }

    private static class AccountExchangeListModel extends LoadableDetachableModel<List<Exchange>> {

        @SpringBean
        private ExchangeService exchangeService;

        @SpringBean
        private AccountPolicyService accountPolicyService;

        public AccountExchangeListModel() {
            super();
            Injector.get().inject(this);
        }

        @Override
        protected List<Exchange> load() {
            Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
            @SuppressWarnings("unchecked")
            NodeUser<Account> nodeUser = (NodeUser<Account>) authentication.getPrincipal();
            Account account = nodeUser.getUser();
            ExchangeSearchCriteria criteria = new ExchangeSearchCriteria();
            if (!account.getSystemRoleType().isAdmin()) {
                AccountPolicySearchCriteria c = new AccountPolicySearchCriteria();
                c.setAccountId(account.getId());
                List<String> secureExchangeIds = accountPolicyService.find(c, AccountPolicySorts.ACCOUNT_NAME)
                        .map(AccountPolicy::getExchange)
                        .map(Exchange::getId)
                        .collect(Collectors.toList());
                if (secureExchangeIds.isEmpty()) {
                    criteria.setSecure(false);
                } else {
                    criteria.setNotSecureOrIds(secureExchangeIds);
                }
            }
            return exchangeService.find(criteria, ExchangeSorts.NAME)
                    .collect(Collectors.toList());
        }

    }

}
