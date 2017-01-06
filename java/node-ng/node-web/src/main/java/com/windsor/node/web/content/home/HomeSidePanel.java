package com.windsor.node.web.content.home;

import java.util.stream.Collectors;

import org.apache.wicket.AttributeModifier;
import org.apache.wicket.ajax.markup.html.AjaxLink;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.LoginInfo;
import com.windsor.node.domain.NaasSyncInfo;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.ActivityService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.StyledIcon;
import com.windsor.node.web.component.ViewAjaxLink;
import com.windsor.node.web.model.FormattedTemporalAccessorModel;
import com.windsor.node.web.model.LoggedInAccountModel;
import com.windsor.node.web.model.SuccessErrorIconInfoModel;
import com.windsor.node.web.model.lazy.LoginInfoModels;
import com.windsor.node.web.model.lazy.NaasSyncInfoModel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

/**
 * Provides a side panel.
 */
public class HomeSidePanel extends AbstractBasePanel<String> {

	@SpringBean
	private ActivityService service;
	
    public HomeSidePanel(String id, IModel<String> model) {
        super(id, model);

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_WELCOME)));
        add(new MultiLineLabel("content", model)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));
        
        /*
         * NAAS sync info.
         */
		IModel<NaasSyncInfo> lastNaasSyncActivityModel = new LDModel<>(() -> service.findLastNaasSyncActivity());
		AjaxLink<?> lastNaasSyncLink = new ViewAjaxLink<>("lastNaasSyncLink", lastNaasSyncActivityModel);
		add(lastNaasSyncLink);
		lastNaasSyncLink.add(new Label("lastNaasSyncDate", NaasSyncInfoModel.bindDate(lastNaasSyncActivityModel)));
		add(new StyledIcon("lastNaasSyncIcon", new SuccessErrorIconInfoModel(NaasSyncInfoModel.bindSuccessful(lastNaasSyncActivityModel))));
		
		/*
		 * Last login info.
		 */
		IModel<Account> accountModel = new LoggedInAccountModel();
		IModel<LoginInfo> lastLoginModel = new LDModel<>(() -> service.findLastSuccessfulLoginActivity(accountModel.getObject()));
		add(new Label("lastLoginDate", LoginInfoModels.bindDate(lastLoginModel)));
		
		/*
		 * Recent logins.
		 */
		add(new ListView<LoginInfo>("login", new LDModel<>(() -> service.findLatestLoginActivity(5).collect(Collectors.toList()))) {

			@Override
			protected void populateItem(ListItem<LoginInfo> item) {
				IModel<LoginInfo> m = item.getModel();
				IModel<String> dateModel = new FormattedTemporalAccessorModel<>(LoginInfoModels.bindDate(m), "MMM d, YY K:mm a");
				IModel<String> emailModel = LoginInfoModels.bindName(m);
				item.add(new StyledIcon("icon", new SuccessErrorIconInfoModel(LoginInfoModels.bindSuccessful(m))));
				item.add(new Label("date", dateModel).add(new AttributeModifier("title", dateModel)));
				item.add(new Label("email", LoginInfoModels.bindName(m)).add(new AttributeModifier("title", emailModel)));
			}
			
		});
		
    }

}