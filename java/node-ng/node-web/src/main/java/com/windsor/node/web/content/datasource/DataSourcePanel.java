package com.windsor.node.web.content.datasource;

import org.apache.wicket.feedback.ErrorLevelFeedbackMessageFilter;
import org.apache.wicket.feedback.FeedbackMessage;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;

/**
 * Provides a panel for managing DataSource instances.
 */
public class DataSourcePanel extends AbstractBasePanel<DataSourceSearchCriteria> {

    public DataSourcePanel(String cid, IModel<DataSourceSearchCriteria> model) {
        super(cid, model);
        add(new WindsorFeedbackPanel("feedback",
                new ErrorLevelFeedbackMessageFilter(FeedbackMessage.WARNING)));
        add(new DataSourceDataTable("table", model));
    }

}
