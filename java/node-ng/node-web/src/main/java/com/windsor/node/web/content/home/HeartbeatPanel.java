package com.windsor.node.web.content.home;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.LoadableDetachableModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.HeartbeatInfo;
import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.node.service.NAASAuthenticationService;
import com.windsor.stack.web.wicket.model.LDModel;

public class HeartbeatPanel extends Panel {

    public HeartbeatPanel(String id) {
        super(id);
        IModel<HeartbeatInfo> restHearbeatInfoModel = new HeartbeatModel(PartnerVersion.REST);
        add(new HeartbeatStatusPanel("wne", new HeartbeatModel(PartnerVersion.ONE_DOT_ONE)));
        add(new HeartbeatStatusPanel("wne2", new HeartbeatModel(PartnerVersion.TWO_DOT_ONE)));
        add(new HeartbeatStatusPanel("wnrest", restHearbeatInfoModel, 
        		new LDModel<>(() -> restHearbeatInfoModel.getObject().getEndpoint().replaceFirst("/[^/]*$", "/{Query}"))));
    }

    private static class HeartbeatModel extends LoadableDetachableModel<HeartbeatInfo> {

        @SpringBean
        private NAASAuthenticationService service;

        private PartnerVersion partnerVersion;

        public HeartbeatModel(PartnerVersion partnerVersion) {
            this.partnerVersion = partnerVersion;
            Injector.get().inject(this);
        }

        @Override
        protected HeartbeatInfo load() {
            return service.getHeartbeatInfo(partnerVersion);
        }

    }

}
