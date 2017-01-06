package com.windsor.node.web.content.home;

import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.web.content.activity.ActivityDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;

public class DashboardPanel extends Panel {

    public DashboardPanel(String id, IModel<Account> model) {
        super(id, model);
        add(new ActivityDataTablePanel("transactions",
                Model.of(new ActivitySearchCriteria()
                		.types(ActivityType.EXCHANGE_ACTIVITY_TYPES)
                		.hasExchange()),
                15L,
                false,
                new WindsorDataTableConfiguration()
                    .filteringToolbarVisible(false)
                    .bottomToolbarAlwaysVisible(false)
                    .bottomToolbarVisibleOnlyIfNecessary(false)));
        add(new HeartbeatPanel("heartbeats"));
        add(new NodeNewsPanel("news"));
    }

}
