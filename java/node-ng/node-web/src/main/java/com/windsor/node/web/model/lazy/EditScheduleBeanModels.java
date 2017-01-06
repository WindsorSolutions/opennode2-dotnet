package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.util.Date;
import java.util.List;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.edit.EditScheduleArgumentBean;
import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.ScheduleFrequencyType;
import com.windsor.node.domain.entity.ScheduleSourceType;
import com.windsor.node.domain.entity.ScheduleTargetType;

public class EditScheduleBeanModels {

    public static final LazyModel<ExchangeService> EXCHANGE_SERVICE = model(from(EditScheduleBean.class).getExchangeService());

    public static final LazyModel<String> NAME = model(from(EditScheduleBean.class).getName());
    public static final LazyModel<Boolean> ACTIVE = model(from(EditScheduleBean.class).isActive());
    public static final LazyModel<Date> START = model(from(EditScheduleBean.class).getStart());
    public static final LazyModel<Date> END = model(from(EditScheduleBean.class).getEnd());
    public static final LazyModel<Integer> FREQUENCY = model(from(EditScheduleBean.class).getFrequency());
    public static final LazyModel<ScheduleFrequencyType> FREQUENCY_TYPE = model(from(EditScheduleBean.class).getFrequencyType());

    public static final LazyModel<ScheduleTargetType> TARGET_TYPE = model(from(EditScheduleBean.class).getTargetType());
    public static final LazyModel<String> TARGET_TYPE_HELP = model(from(EditScheduleBean.class).getTargetTypeHelpText());
    public static final LazyModel<Partner> TARGET_PARTNER = model(from(EditScheduleBean.class).getTargetPartner());
    public static final LazyModel<String> TARGET_EMAIL = model(from(EditScheduleBean.class).getTargetEmail());
    public static final LazyModel<String> TARGET_PATH = model(from(EditScheduleBean.class).getTargetFilePath());

    public static final LazyModel<ScheduleSourceType> SOURCE_TYPE = model(from(EditScheduleBean.class).getSourceType());
    public static final LazyModel<String> SOURCE_TYPE_HELP = model(from(EditScheduleBean.class).getSourceTypeHelpText());
    public static final LazyModel<String> SOURCE_PATH = model(from(EditScheduleBean.class).getSourceFilePath());

    public static final LazyModel<List<EditScheduleArgumentBean>> ARGUMENTS = model(from(EditScheduleBean.class).getArguments());

    private EditScheduleBeanModels() {
        super();
    }

    public static IModel<ExchangeService> bindExchangeService(IModel<EditScheduleBean> model) {
        return EXCHANGE_SERVICE.bind(model);
    }

    public static IModel<String> bindName(IModel<EditScheduleBean> model) {
        return NAME.bind(model);
    }

    public static IModel<Boolean> bindActive(IModel<EditScheduleBean> model) {
        return ACTIVE.bind(model);
    }

    public static IModel<Date> bindStart(IModel<EditScheduleBean> model) {
        return START.bind(model);
    }

    public static IModel<Date> bindEnd(IModel<EditScheduleBean> model) {
        return END.bind(model);
    }

    public static IModel<Integer> bindFrequency(IModel<EditScheduleBean> model) {
        return FREQUENCY.bind(model);
    }

    public static IModel<ScheduleFrequencyType> bindFrequencyType(IModel<EditScheduleBean> model) {
        return FREQUENCY_TYPE.bind(model);
    }

    public static IModel<ScheduleTargetType> bindTargetType(IModel<EditScheduleBean> model) {
        return TARGET_TYPE.bind(model);
    }

    public static IModel<String> bindTargetTypeHelpText(IModel<EditScheduleBean> model) {
        return TARGET_TYPE_HELP.bind(model);
    }

    public static IModel<Partner> bindTargetPartner(IModel<EditScheduleBean> model) {
        return TARGET_PARTNER.bind(model);
    }

    public static IModel<String> bindTargetEmail(IModel<EditScheduleBean> model) {
        return TARGET_EMAIL.bind(model);
    }

    public static IModel<String> bindTargetPath(IModel<EditScheduleBean> model) {
        return TARGET_PATH.bind(model);
    }

    public static IModel<ScheduleSourceType> bindSourceType(IModel<EditScheduleBean> model) {
        return SOURCE_TYPE.bind(model);
    }

    public static IModel<String> bindSourceTypeHelpText(IModel<EditScheduleBean> model) {
        return SOURCE_TYPE_HELP.bind(model);
    }

    public static IModel<String> bindSourcePath(IModel<EditScheduleBean> model) {
        return SOURCE_PATH.bind(model);
    }

    public static IModel<List<EditScheduleArgumentBean>> bindArguments(IModel<EditScheduleBean> model) {
        return ARGUMENTS.bind(model);
    }

}
