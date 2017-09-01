package com.windsor.node.web.model.lazy;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditNotificationBean;

public class EditNotificationBeanModels {

    public static final LazyModel<String> EXCHANGE_NAME = LazyModel.model(LazyModel.from(EditNotificationBean.class).getExchangeName());
    public static final LazyModel<Boolean> DOWNLOAD = LazyModel.model(LazyModel.from(EditNotificationBean.class).isDownload());
    public static final LazyModel<Boolean> EXECUTE = LazyModel.model(LazyModel.from(EditNotificationBean.class).isExecute());
    public static final LazyModel<Boolean> NOTIFY = LazyModel.model(LazyModel.from(EditNotificationBean.class).isNotify());
    public static final LazyModel<Boolean> QUERY = LazyModel.model(LazyModel.from(EditNotificationBean.class).isQuery());
    public static final LazyModel<Boolean> SCHEDULE = LazyModel.model(LazyModel.from(EditNotificationBean.class).isSchedule());
    public static final LazyModel<Boolean> SOLICIT = LazyModel.model(LazyModel.from(EditNotificationBean.class).isSolicit());
    public static final LazyModel<Boolean> SUBMIT = LazyModel.model(LazyModel.from(EditNotificationBean.class).isSubmit());
    public static final LazyModel<Boolean> ERROR = LazyModel.model(LazyModel.from(EditNotificationBean.class).isError());

    private EditNotificationBeanModels() {

    }

    public static LazyModel<String> bindExchangeName(IModel<EditNotificationBean> model) {
        return EXCHANGE_NAME.bind(model);
    }

    public static LazyModel<Boolean> bindDownload(IModel<EditNotificationBean> model) {
        return DOWNLOAD.bind(model);
    }

    public static LazyModel<Boolean> bindExecute(IModel<EditNotificationBean> model) {
        return EXECUTE.bind(model);
    }

    public static LazyModel<Boolean> bindNotify(IModel<EditNotificationBean> model) {
        return NOTIFY.bind(model);
    }

    public static LazyModel<Boolean> bindQuery(IModel<EditNotificationBean> model) {
        return QUERY.bind(model);
    }

    public static LazyModel<Boolean> bindSchedule(IModel<EditNotificationBean> model) {
        return SCHEDULE.bind(model);
    }

    public static LazyModel<Boolean> bindSolicit(IModel<EditNotificationBean> model) {
        return SOLICIT.bind(model);
    }

    public static LazyModel<Boolean> bindSubmit(IModel<EditNotificationBean> model) {
        return SUBMIT.bind(model);
    }

    public static LazyModel<Boolean> bindError(IModel<EditNotificationBean> model) {
        return ERROR.bind(model);
    }

}
