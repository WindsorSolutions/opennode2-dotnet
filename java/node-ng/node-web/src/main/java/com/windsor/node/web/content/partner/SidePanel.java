package com.windsor.node.web.content.partner;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.AddButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a side panel
 */
public class SidePanel extends AbstractBasePanel<String> {

    public SidePanel(String id, IModel<String> model) {
        super(id, model);

        add(new Label("actions", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));

        Form<?>form = new Form<>("form");
        add(form);

        form.add(new AddButton("add", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_ADD_PARTNER),
                Partner.class).sendSameEventOnError(true));

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", model)
            .setEscapeModelStrings(false)
            .setOutputMarkupId(true));
    }

}