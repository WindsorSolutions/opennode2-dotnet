package com.windsor.node.web.content.partner;

import org.apache.wicket.feedback.ErrorLevelFeedbackMessageFilter;
import org.apache.wicket.feedback.FeedbackMessage;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;

/**
 * Provides a panel for managing Partner instances.
 */
public class PartnerPanel extends AbstractBasePanel<PartnerSearchCriteria> {

    public PartnerPanel(String cid, IModel<PartnerSearchCriteria> model) {
        super(cid, model);
        add(new WindsorFeedbackPanel("feedback",
                new ErrorLevelFeedbackMessageFilter(FeedbackMessage.WARNING)));
        add(new PartnerDataTable("table", getModel()));
    }

}
