package com.windsor.node.web.component.radio;

import com.windsor.node.domain.entity.ScheduleSourceType;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.BootstrapRadioGroup;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.model.IModel;

import java.util.List;

/**
 * Provides a group of radio choices for the ScheduleSourceType.
 */
public class ScheduleSourceTypeRadioGroup extends BootstrapRadioGroup<ScheduleSourceType> {

    public ScheduleSourceTypeRadioGroup(String cid, IModel<ScheduleSourceType> model) {
        this(cid, model, ScheduleSourceType.validOptions());
    }

    public ScheduleSourceTypeRadioGroup(String cid, IModel<ScheduleSourceType> model,
                                        BootstrapRadioGroup.ISelectionChangeHandler<ScheduleSourceType> changeHandler) {
        this(cid, model, ScheduleSourceType.validOptions(), changeHandler);
    }

    public ScheduleSourceTypeRadioGroup(String cid, IModel<ScheduleSourceType> model,
                                        List<ScheduleSourceType> options) {
        this(cid, model, options, null);
    }

    public ScheduleSourceTypeRadioGroup(String cid, IModel<ScheduleSourceType> model,
                                        List<ScheduleSourceType> options,
                                        ISelectionChangeHandler<ScheduleSourceType> changeHandler) {
        super(cid, model, options, new ScheduleSourceTypeRadioChoiceRenderer(Buttons.Type.Default));

        setOutputMarkupId(true);

        setChangeHandler(new ISelectionChangeHandler<ScheduleSourceType>() {
            @Override
            public void onSelectionChanged(AjaxRequestTarget ajaxRequestTarget, ScheduleSourceType sourceType) {
                model.setObject(sourceType);
                ajaxRequestTarget.add(ScheduleSourceTypeRadioGroup.this);

                if(changeHandler != null) {
                    changeHandler.onSelectionChanged(ajaxRequestTarget, sourceType);
                }
            }
        });
    }
}
