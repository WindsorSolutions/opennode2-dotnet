package com.windsor.node.web.converter;

import java.util.Locale;

import com.windsor.node.domain.entity.Account;
import com.windsor.stack.web.wicket.util.convert.WindsorAbstractConverter;

public class AccountConverter extends WindsorAbstractConverter<Account> {

    @Override
    public String convertToString(Account value, Locale locale) {
        return value.getNaasAccount();
    }

}
