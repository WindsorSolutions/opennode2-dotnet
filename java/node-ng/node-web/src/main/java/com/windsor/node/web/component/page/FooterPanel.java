package com.windsor.node.web.component.page;

import java.time.LocalDate;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.service.NodeSystemInfoService;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.NaasPropertiesModel;
import com.windsor.node.web.model.lazy.NaasPropertiesModels;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.link.EmailLink;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

/**
 * Provides a footer for the application.
 */
public class FooterPanel extends AbstractBasePanel<Void> {

    @SpringBean
    private NodeSystemInfoService service;

    @SpringBean
    private NaasProperties naasProperties;

    public FooterPanel(String id){
        super(id);
        IModel<NaasProperties> naasPropertiesModel = new NaasPropertiesModel();
        add(new EmailLink("support", NaasPropertiesModels.bindAdminUsername(naasPropertiesModel), 
        		new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SUPPORT)));
        add(new Label("buildInfo", service.getBuildInfo()));
        add(new Label("buildNumber", service.getBuildNumber()));
        add(new Label("buildTimestamp", service.getBuildTimestamp()));
        add(new Label("naasEnv", new NaasEnvironmentModel(NaasPropertiesModels.bindAuthUrl(naasPropertiesModel))));
        add(new Label("year", LocalDate.now().getYear()));
    }

    private static class NaasEnvironmentModel extends LoadableDetachableWrappedModel<String, String> {

        private static final String TEST = "https://naas.epacdxnode.net/";
        private static final String PROD = "https://cdxnodenaas.epa.gov/";

        public NaasEnvironmentModel(IModel<String> authUrlModel) {
            super(authUrlModel);
            Injector.get().inject(this);
        }

        @Override
        protected String load() {
            String auth = getWrappedModel().getObject();
            return auth.startsWith(TEST) ? "test" : auth.startsWith(PROD) ? "prod" : "???";
        }

    }

}
