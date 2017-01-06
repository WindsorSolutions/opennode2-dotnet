package com.windsor.node.web.component.button;

import org.apache.wicket.model.Model;

import com.windsor.node.web.event.ToggleEvent;
import com.windsor.stack.domain.util.ISerializableSupplier;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons.Type;

public class ToggleButton extends AbstractButton {

    public ToggleButton(String componentId, ISerializableSupplier<?> eventPayloadFactory) {
        super(componentId, Model.of("Toggle"), Type.Default,
                (target, form) -> new ToggleEvent<>(target, eventPayloadFactory.get()));
    }

}
