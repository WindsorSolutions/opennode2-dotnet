package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSorts;
import com.windsor.node.service.AccountService;
import com.windsor.stack.domain.util.ISerializableSupplier;

/**
 * Provides a provider for selecting an Account.
 */
public class AccountChoiceProvider extends NodeEntityChoiceProvider<Account> {

    private static final int PAGE_SIZE = 20;

    public AccountChoiceProvider(AccountService service) {
        this(service, AccountSearchCriteria::new);
    }

    public AccountChoiceProvider(AccountService service, ISerializableSupplier<AccountSearchCriteria> searchCriteriaFactory) {
        super(PAGE_SIZE, Account::getNaasAccount, (term, page) ->
                service.find(searchCriteriaFactory.get().name(term), AccountSorts.NAME, PAGE_SIZE * page, PAGE_SIZE), service);
    }

}
