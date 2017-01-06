package com.windsor.node.web.component.radio;

import com.windsor.node.domain.entity.ScheduleTargetType;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.BootstrapRadioGroup;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.model.IModel;

import java.util.Arrays;
import java.util.List;

/**
 * Provides a group of radio choices for the ScheduleTargetType.
 */
public class ScheduleTargetTypeRadioGroup extends BootstrapRadioGroup<ScheduleTargetType> {

    public ScheduleTargetTypeRadioGroup(String cid, IModel<ScheduleTargetType> model) {
        this(cid, model, null);
    }

    public ScheduleTargetTypeRadioGroup(String cid, IModel<ScheduleTargetType> model,
                                        ISelectionChangeHandler<ScheduleTargetType> changeHandler) {
        this(cid, model, Arrays.asList(ScheduleTargetType.values()), changeHandler);
    }

    public ScheduleTargetTypeRadioGroup(String cid, IModel<ScheduleTargetType> model,
                                        List<ScheduleTargetType> options,
                                        ISelectionChangeHandler<ScheduleTargetType> changeHandler) {
        super(cid, model, options, new ScheduleTargetTypeRadioChoiceRenderer(Buttons.Type.Default));

        setOutputMarkupId(true);

        setChangeHandler(new ISelectionChangeHandler<ScheduleTargetType>() {
            @Override
            public void onSelectionChanged(AjaxRequestTarget ajaxRequestTarget, ScheduleTargetType sourceType) {
                model.setObject(sourceType);
                ajaxRequestTarget.add(ScheduleTargetTypeRadioGroup.this);

                if(changeHandler != null) {
                    changeHandler.onSelectionChanged(ajaxRequestTarget, sourceType);
                }
            }
        });
    }
}
