package com.windsor.node.web.component.button;

import static com.windsor.node.web.app.Icons.ICON_RUN;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;

import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.event.RunEvent;
import com.windsor.stack.domain.util.ISerializableBiFunction;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.IconType;

/**
 * Provides a button for running something.
 */
public class RunButton extends AbstractButton {

    private static final ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> DEFAULT_EVENT_GENERATOR =
            (target, form) -> {
                return new RunEvent<>(target, form.getDefaultModelObject());
            };

    public RunButton(String id) {
        this(id, true);
    }

    public RunButton(String id, IconType iconType) {
        this(id, GenericModels.MODEL_EMPTY, Buttons.Type.Default, DEFAULT_EVENT_GENERATOR, iconType);
    }

    public RunButton(String id, boolean emptyLabel) {
        this(id, emptyLabel ? GenericModels.MODEL_EMPTY : new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_RUN));
    }

    public RunButton(String id, IModel<String> labelModel) {
        this(id, labelModel, Buttons.Type.Default);
    }

    public RunButton(String id, boolean emptyLabel, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator) {
        this(id, emptyLabel ? GenericModels.MODEL_EMPTY : new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_RUN), Buttons.Type.Default, newEventGenerator);
    }

    public RunButton(String id, IModel<String> labelModel, Buttons.Type type) {
        this(id, labelModel, type, DEFAULT_EVENT_GENERATOR);
    }

    public RunButton(String id, IModel<String> labelModel, Buttons.Type type, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator) {
        this(id, labelModel, type, newEventGenerator, ICON_RUN);
    }

    public RunButton(String id, IModel<String> labelModel, Buttons.Type type, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator, IconType iconType) {
        super(id, labelModel, type, (Form<?>) null, newEventGenerator, new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_RUN));
        this.setIconType(iconType);
    }
}