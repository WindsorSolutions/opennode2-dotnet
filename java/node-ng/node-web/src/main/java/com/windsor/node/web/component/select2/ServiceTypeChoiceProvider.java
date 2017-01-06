package com.windsor.node.web.component.select2;

import java.util.Arrays;
import java.util.List;

import org.apache.wicket.model.IModel;
import org.apache.wicket.model.util.ListModel;

import com.windsor.node.domain.entity.ServiceType;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;


/**
 * Provides a provider for ServiceType instances.
 */
public class ServiceTypeChoiceProvider extends LambdaChoiceProvider<ServiceType, ServiceType> {

    private static final int PAGE_SIZE = 4;

    public ServiceTypeChoiceProvider() {
        this(new ListModel<>(Arrays.asList(ServiceType.values())));
    }

    public ServiceTypeChoiceProvider(IModel<List<ServiceType>> choicesModel) {
        super(PAGE_SIZE,
                ServiceType::toString,
                ServiceType::name,
                (term, size) ->  choicesModel.getObject().stream()
                        .filter(t -> t.toString().toLowerCase().contains(term.toLowerCase())),
                s -> ServiceType.valueOf(s),
                ids -> ids);
    }

}
