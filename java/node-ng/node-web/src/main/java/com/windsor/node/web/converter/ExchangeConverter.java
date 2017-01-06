package com.windsor.node.web.converter;

import java.util.Locale;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.stack.web.wicket.util.convert.WindsorAbstractConverter;

public class ExchangeConverter extends WindsorAbstractConverter<Exchange> {

    @Override
    public String convertToString(Exchange value, Locale locale) {
        return value.getName();
    }

}
