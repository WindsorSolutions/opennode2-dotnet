package com.windsor.node.web.component.select2;

import com.windsor.stack.domain.IEntity;
import com.windsor.stack.domain.IIdentifiable;
import com.windsor.stack.domain.service.ILoaderService;
import com.windsor.stack.domain.util.ISerializableBiFunction;
import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

import java.util.stream.Stream;

/**
 * Provides a base provider for all Node entities.
 */
public class NodeEntityChoiceProvider<T extends IEntity<String>> extends LambdaChoiceProvider<T, String> {
    public NodeEntityChoiceProvider(int pageSize, ISerializableFunction<T, String> displayFunction,
                                    ISerializableBiFunction<String, Integer, Stream<T>> queryFunction,
                                    ILoaderService<T, String> loaderService) {
        super(pageSize, displayFunction, IIdentifiable::getId, queryFunction, String::toString, loaderService::load);
    }
}
