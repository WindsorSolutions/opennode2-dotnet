package com.windsor.node.web.component.select2;

import java.util.Arrays;
import java.util.List;

import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for DataSourceProvider instances.
 */
public class SystemRoleTypeProviderChoiceProvider extends LambdaChoiceProvider<SystemRoleType, SystemRoleType> {

    private static final int PAGE_SIZE = 4;

    public SystemRoleTypeProviderChoiceProvider() {
        this(Arrays.asList(SystemRoleType.values()));
    }

    public SystemRoleTypeProviderChoiceProvider(List<SystemRoleType> roles) {
        super(PAGE_SIZE,
                SystemRoleType::getDescription,
                SystemRoleType::ordinal,
                (term, size) -> roles.stream()
                    .filter(dsp -> dsp.getDescription().toLowerCase().contains(term.toLowerCase())),
                s -> SystemRoleType.values()[Integer.parseInt(s)], ids -> ids);
    }

}
