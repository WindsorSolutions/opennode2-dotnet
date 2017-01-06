package com.windsor.node.web.model.lazy;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.model.LoadableDetachableModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.service.props.NaasProperties;

public class NaasPropertiesModel extends LoadableDetachableModel<NaasProperties> {

    @SpringBean
    private NaasProperties naasProperties;

    public NaasPropertiesModel() {
        super();
        Injector.get().inject(this);
    }

    @Override
    protected NaasProperties load() {
        return naasProperties;
    }

}
