package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.ActivityType;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for DataSourceProvider instances.
 */
public class ActivityTypeProviderChoiceProvider extends LambdaChoiceProvider<ActivityType, ActivityType> {

    private static final int PAGE_SIZE = 4;

    public ActivityTypeProviderChoiceProvider() {
        super(PAGE_SIZE,
                ActivityType::getDescription,
                ActivityType::ordinal,
                (term, size) -> ActivityType.getMatches(term),
                s -> ActivityType.values()[Integer.parseInt(s)],
                ids -> ids);
    }
}
