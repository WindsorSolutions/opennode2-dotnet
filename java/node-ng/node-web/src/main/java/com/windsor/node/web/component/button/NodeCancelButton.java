package com.windsor.node.web.component.button;

import com.windsor.stack.web.wicket.event.CancelEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;
import com.windsor.stack.web.wicket.model.GenericResourceKeys;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons.Type;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.GlyphIconType;
import org.apache.wicket.model.IModel;

public class NodeCancelButton extends AbstractButton {
    public NodeCancelButton(String id) {
        this(id, new IdentifiableResourceModel(GenericResourceKeys.LABEL_BUTTON_CANCEL));
    }

    public NodeCancelButton(String id, IModel<String> buttonLabel) {
        super(id, buttonLabel, Type.Default, (target, form) -> {
            return new CancelEvent(target);
        });
        this.setIconType(GlyphIconType.asterisk);
        this.setDefaultFormProcessing(false);
    }
}
