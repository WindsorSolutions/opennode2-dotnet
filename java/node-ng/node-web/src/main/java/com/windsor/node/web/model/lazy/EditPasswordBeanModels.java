package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditPasswordBean;

/**
 * Provides lazy models for the EditPasswordBean object.
 */
public final class EditPasswordBeanModels {

    public static final LazyModel<String> NAAS_ACCOUNT = model(from(EditPasswordBean.class).getNaasAccount());
    public static final LazyModel<String> OLD_PASSWORD = model(from(EditPasswordBean.class).getOldPassword());
    public static final LazyModel<String> NEW_PASSWORD = model(from(EditPasswordBean.class).getNewPassword());

    private EditPasswordBeanModels() {

    }

    public static IModel<String> bindNaasAccount(IModel<EditPasswordBean> model) {
        return NAAS_ACCOUNT.bind(model);
    }

    public static IModel<String> bindOldPassword(IModel<EditPasswordBean> model) {
        return OLD_PASSWORD.bind(model);
    }

    public static IModel<String> bindNewPassword(IModel<EditPasswordBean> model) {
        return NEW_PASSWORD.bind(model);
    }

}
