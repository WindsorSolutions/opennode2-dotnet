package com.windsor.node.service.converter;

import java.util.Set;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.google.common.collect.Sets;
import com.windsor.node.domain.edit.EditAccountBean;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.AccountPolicy;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.repo.AccountRepository;

@Transactional(readOnly = true)
@Service
public class EditAccountBeanServiceImpl implements EditAccountBeanService {

    @Autowired
    private AccountRepository repo;

    @Override
    public EditAccountBean toBean(Account account) {
        EditAccountBean bean = new EditAccountBean();
        if (account != null) {
            bean.setId(account.getId());
            bean.setNaasAccount(account.getNaasAccount());
            bean.setAffiliation(account.getAffiliation());
            bean.setActive(account.isActive());
            bean.setSystemRoleType(account.getSystemRoleType());
            bean.setExchanges(account.getAccountPoliciesStream()
                    .filter(AccountPolicy::isAllowed)
                    .map(AccountPolicy::getExchange)
                    .collect(Collectors.toList()));
        }
        return bean;
    }

    @Transactional(readOnly = false)
    @Override
    public Account save(EditAccountBean bean) {
        Account account = repo.findOne(bean.getId());
        merge(account, bean);
        return repo.save(account);
    }

    private void merge(Account account, EditAccountBean bean) {
        account.setActive(bean.isActive());
        account.setSystemRoleType(bean.getSystemRoleType());

        boolean localUser = account.getSystemRoleType().isLocalUser();
        account.setActive(localUser);
        account.setDeleted(!localUser);

        Set<Exchange> existingExchanges = account.getAccountPoliciesStream()
                .filter(AccountPolicy::isAllowed)
                .map(AccountPolicy::getExchange)
                .collect(Collectors.toSet());
        Set<Exchange> selectedExchanges = bean.getExchangesStream()
                .collect(Collectors.toSet());

        Set<Exchange> toDelete = Sets.difference(existingExchanges, selectedExchanges);

        toDelete.stream()
            .forEach(ex -> account.getAccountPolicies().removeIf(x -> x.getExchange().equals(ex)));

        account.getAccountPolicies().addAll(Sets.difference(selectedExchanges, existingExchanges).stream()
            .map(x -> new AccountPolicy(account, x)).collect(Collectors.toList()));
    }

}
