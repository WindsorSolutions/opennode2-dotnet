package com.windsor.node.web.content.home;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.HeartbeatInfo;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.IconInfo.IconStyle;
import com.windsor.node.web.component.StyledIcon;
import com.windsor.node.web.model.lazy.HeartbeatInfoModels;
import com.windsor.stack.web.wicket.model.LDModel;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class HeartbeatStatusPanel extends Panel {

    public HeartbeatStatusPanel(String id, IModel<HeartbeatInfo> model) {
    	this(id, model, HeartbeatInfoModels.bindEndpoint(model));
    }
	
    public HeartbeatStatusPanel(String id, IModel<HeartbeatInfo> model, IModel<String> endpointUrlModel) {
        super(id, model);
        add(new Label("endpoint", endpointUrlModel));
        add(new Label("version", new LDModel<>(() -> model.getObject().getPartnerVersion().getDescription())));
        add(new StyledIcon("validated", new StatusIconModel(HeartbeatInfoModels.bindValidated(model))));
    }

    private static class StatusIconModel extends LoadableDetachableWrappedModel<IconInfo, Boolean> {

        public StatusIconModel(IModel<Boolean> wrappedModel) {
            super(wrappedModel);
        }

        @Override
        protected IconInfo load() {
            return getWrappedModel().getObject()
                    ? new IconInfo(Icons.ICON_OK, IconStyle.SUCCESS)
                    : new IconInfo(Icons.ICON_FAIL, IconStyle.WARNING);
        }

    }

}
