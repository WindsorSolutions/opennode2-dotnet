package com.windsor.node.web.component.button;

import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

import com.windsor.node.web.app.Icons;
import com.windsor.node.web.event.ChangePasswordEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons.Type;

public class ResetPasswordButton extends AbstractButton {

    public ResetPasswordButton(String componentId, IModel<?> model) {
        super(componentId, Model.of(""), Type.Default, (target, form) -> new ChangePasswordEvent<>(target, model.getObject()));
        setIconType(Icons.ICON_LOCK);
    }

    @Override
    protected IModel<String> getTitleModel() {
        return Model.of("Change password");
    }

}