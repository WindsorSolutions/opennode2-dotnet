package com.windsor.node.web.theme;

import de.agilecoders.wicket.less.LessResourceReference;

/**
 * Provides customized LESS references for the application.
 */
public class NodeLessReference extends LessResourceReference {

    public NodeLessReference() {
        super(NodeTheme.class, "less/theme.less");
    }

    private static final class Holder {
        private static final NodeLessReference INSTANCE = new NodeLessReference();
    }

    public static NodeLessReference instance() {
        return Holder.INSTANCE;
    }
}
