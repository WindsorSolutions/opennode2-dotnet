package com.windsor.node.web.component.radio;

import com.windsor.node.domain.entity.ScheduleTargetType;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.DefaultRadioChoiceRenderer;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

/**
 * Provides a radio button choice renderer for ScheduleTargetType instances.
 */
public class ScheduleTargetTypeRadioChoiceRenderer extends DefaultRadioChoiceRenderer<ScheduleTargetType> {

    public ScheduleTargetTypeRadioChoiceRenderer(Buttons.Type type) {
        super(type, null);
    }

    @Override
    public IModel<String> lableOf(ScheduleTargetType targetType) {
        return Model.of(targetType != null ? targetType.getTitle() : "");
    }
}