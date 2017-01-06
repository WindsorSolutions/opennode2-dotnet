package com.windsor.node.web.component.select2;

import com.windsor.stack.web.wicket.markup.html.form.select2.LambdaChoiceProvider;

import java.util.List;

/**
 * Provides a provider for a list of String instances.
 */
public class NodeStringChoiceProvider extends LambdaChoiceProvider<String, String> {

    private static final int PAGE_SIZE = 4;

    public NodeStringChoiceProvider(List<String> choices) {
        super(PAGE_SIZE,
                String::toString,
                choices::indexOf,
                (term, size) -> choices.stream()
                        .filter(t -> t.toString().toLowerCase().contains(term.toLowerCase())),
                s -> choices.get(Integer.parseInt(s)),
                ids -> ids);
    }
}
