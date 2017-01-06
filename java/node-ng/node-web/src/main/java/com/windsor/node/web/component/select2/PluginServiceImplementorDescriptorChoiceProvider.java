package com.windsor.node.web.component.select2;

import java.util.List;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

import org.apache.wicket.model.IModel;

import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for a List of PluginServiceImplementorDescriptiors.
 */
public class PluginServiceImplementorDescriptorChoiceProvider extends LambdaChoiceProvider<PluginServiceImplementorDescriptor, String> {

    private static final int PAGE_SIZE = 4;

    public PluginServiceImplementorDescriptorChoiceProvider(IModel<List<PluginServiceImplementorDescriptor>> model) {
        super(PAGE_SIZE,
                PluginServiceImplementorDescriptor::getName,
                PluginServiceImplementorDescriptor::getClassName,
                (term, size) -> model.getObject().stream(), // FIXME: make this filterable
                s -> s,
                ids -> {
                    Map<String, PluginServiceImplementorDescriptor> map = model.getObject().stream()
                            .collect(Collectors.toMap(PluginServiceImplementorDescriptor::getClassName, Function.identity()));
                    return ids.map(id -> map.get(id));
                });
    }

}
