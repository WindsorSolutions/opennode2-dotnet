package com.windsor.node.web.component.radio;

import com.windsor.node.domain.entity.ScheduleSourceType;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.radio.DefaultRadioChoiceRenderer;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

/**
 * Provides a radio button choice renderer for ScheduleSourceType instances.
 */
public class ScheduleSourceTypeRadioChoiceRenderer extends DefaultRadioChoiceRenderer<ScheduleSourceType> {

    public ScheduleSourceTypeRadioChoiceRenderer(Buttons.Type type) {
        super(type, null);
    }

    @Override
    public IModel<String> lableOf(ScheduleSourceType sourceType) {
        return Model.of(sourceType != null ? sourceType.getTitle() : "");
    }
}