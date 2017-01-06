package com.windsor.node.web.component.select2;

import java.util.stream.Stream;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.stack.domain.service.ILoaderService;
import com.windsor.stack.domain.util.ISerializableBiFunction;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

public class ExchangeChoiceProvider extends LambdaChoiceProvider<Exchange, String> {

    public <T extends ILoaderService<Exchange, String>> ExchangeChoiceProvider(T loaderService,
            ISerializableBiFunction<String, Integer, Stream<Exchange>> queryFunction) {
        super(10, Exchange::getName, Exchange::getId, queryFunction, x -> x, loaderService::load);
    }

}
