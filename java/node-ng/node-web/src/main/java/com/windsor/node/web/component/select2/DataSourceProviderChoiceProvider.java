package com.windsor.node.web.component.select2;

import com.windsor.node.domain.entity.DataSourceProvider;
import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

/**
 * Provides a provider for DataSourceProvider instances.
 */
public class DataSourceProviderChoiceProvider extends LambdaChoiceProvider<DataSourceProvider, DataSourceProvider> {

    private static final int PAGE_SIZE = 4;

    public DataSourceProviderChoiceProvider() {
        super(PAGE_SIZE,
                DataSourceProvider::getDescription,
                DataSourceProvider::ordinal,
                (term, size) -> DataSourceProvider.getMatches(term),
                s -> DataSourceProvider.values()[Integer.parseInt(s)],
                ids -> ids);
    }
}
