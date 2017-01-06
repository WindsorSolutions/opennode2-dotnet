package com.windsor.node.web.content.schedule;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a side panel.
 */
public class ScheduleSidePanel extends AbstractBasePanel<ScheduleSearchCriteria> {


    public ScheduleSidePanel(String id, IModel<ScheduleSearchCriteria> model, IModel<String> contentModel) {
        super(id, model);

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", contentModel)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));
    }
}
