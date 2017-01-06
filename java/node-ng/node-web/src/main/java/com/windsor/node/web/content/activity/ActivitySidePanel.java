package com.windsor.node.web.content.activity;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.ActivitySearchCriteriaModels;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ResetButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SearchButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.FormGroup;

/**
 * Provides a side panel.
 */
public class ActivitySidePanel extends AbstractBasePanel<ActivitySearchCriteria> {

    public ActivitySidePanel(String id, IModel<ActivitySearchCriteria> model, IModel<String> contentModel) {
        super(id, model);

        add(new Label("advancedSearch", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ADVANCED_SEARCH)));

        Form<ActivitySearchCriteria> form = new Form<>("form", model);
        add(form);

        form.add(new FormGroup("detailGroup")
                .add(new TextField<>("field", ActivitySearchCriteriaModels.bindDetails(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONTENT))));

        form.add(new FormGroup("ipGroup")
                .add(new TextField<>("field", ActivitySearchCriteriaModels.bindIpAddress(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_IP_ADDRESS))));

        form.add(new SearchButton("search", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SEARCH)));
        form.add(new ResetButton("reset"));

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", contentModel)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));
    }

}