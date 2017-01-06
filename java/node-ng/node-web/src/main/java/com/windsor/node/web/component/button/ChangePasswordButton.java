package com.windsor.node.web.component.button;

import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.event.ChangePasswordEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons.Type;

public class ChangePasswordButton extends AbstractButton {

    public ChangePasswordButton(String id) {
        super(id, new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CHANGE_PASSWORD),
                Type.Default,
                (target, form) -> new ChangePasswordEvent<>(target, form.getDefaultModelObject()));
    }

}