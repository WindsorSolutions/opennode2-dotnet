package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for PartnerVersion instances.
 */
public class PartnerVersionChoiceProvider extends LambdaChoiceProvider<PartnerVersion, PartnerVersion> {

    private static final int PAGE_SIZE = 4;

    public PartnerVersionChoiceProvider() {
        super(PAGE_SIZE,
                PartnerVersion::getDescription,
                PartnerVersion::ordinal,
                (term, size) -> PartnerVersion.getMatches(term),
                s -> PartnerVersion.values()[Integer.parseInt(s)],
                ids -> ids);
    }
}
