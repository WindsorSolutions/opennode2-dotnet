package com.windsor.node.web.content.exchange;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.AddButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a side panel.
 */
public class ExchangeSidePanel extends AbstractBasePanel<ExchangeSearchCriteria> {

    public ExchangeSidePanel(String id, IModel<ExchangeSearchCriteria> model, IModel<String> contentModel) {
        super(id, model);

        add(new Label("actions", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));

        Form<?> form = new Form<>("form", model);
        add(form);

        form.add(new AddButton("add",
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_ADD_EXCHANGE),
                Exchange.class)
                .sendSameEventOnError(true));

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", contentModel)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));
    }

}