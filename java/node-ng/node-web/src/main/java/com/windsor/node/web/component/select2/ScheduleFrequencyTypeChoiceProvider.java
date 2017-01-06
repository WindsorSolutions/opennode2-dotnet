package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.ScheduleFrequencyType;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for ScheduleFrequencyType instances.
 */
public class ScheduleFrequencyTypeChoiceProvider extends LambdaChoiceProvider<ScheduleFrequencyType, ScheduleFrequencyType> {

    private static final int PAGE_SIZE = 4;

    public ScheduleFrequencyTypeChoiceProvider() {
        super(PAGE_SIZE,
                ScheduleFrequencyType::toString,
                ScheduleFrequencyType::ordinal,
                (term, size) -> ScheduleFrequencyType.getMatches(term),
                s -> ScheduleFrequencyType.values()[Integer.parseInt(s)],
                ids -> ids);
    }
}