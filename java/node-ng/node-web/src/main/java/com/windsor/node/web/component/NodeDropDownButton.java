package com.windsor.node.web.component;

import de.agilecoders.wicket.core.markup.html.bootstrap.image.IconType;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarDropDownButton;
import org.apache.wicket.AttributeModifier;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.model.IModel;

/**
 * Provides a drop down button for the application.
 */
public abstract class NodeDropDownButton extends NavbarDropDownButton {

    public NodeDropDownButton(IModel<String> model) {
        super(model);
    }

    @Override
    protected WebMarkupContainer newButton(String markupId, IModel<String> labelModel, IModel<IconType> iconTypeModel) {
        WebMarkupContainer c = super.newButton(markupId, labelModel, iconTypeModel);
        c.add(new AttributeModifier("aria-haspopup", "true"));
        return c;
    }
}