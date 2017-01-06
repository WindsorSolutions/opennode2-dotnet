package com.windsor.node.web.component;

import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.model.IModel;

/**
 * Provides a right-handed help panel for the application workspace.
 */
public class RightHandHelpPanel extends AbstractBasePanel<String> {

    private final MultiLineLabel content;

    public RightHandHelpPanel(String id, IModel<String> model) {
        super(id, model);

        setOutputMarkupPlaceholderTag(false);

        Label label = new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP));
        add(label);

        add(content = new MultiLineLabel("content", model));
        content.setEscapeModelStrings(false);
        content.setOutputMarkupId(true);
    }
}