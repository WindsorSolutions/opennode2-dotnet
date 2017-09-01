package com.windsor.node.web.component.button;

import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.event.StopEvent;
import com.windsor.stack.domain.util.ISerializableBiFunction;
import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.markup.html.form.button.AbstractButton;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.IconType;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.model.IModel;

import static com.windsor.node.web.app.Icons.ICON_STOP;

/**
 * Provides a button for stopping something.
 */
public class StopButton extends AbstractButton {

    private static final ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> DEFAULT_EVENT_GENERATOR =
            (target, form) -> {
                return new StopEvent<>(target, form.getDefaultModelObject());
            };

    public StopButton(String id) {
        this(id, true);
    }

    public StopButton(String id, IconType iconType) {
        this(id, GenericModels.MODEL_EMPTY, Buttons.Type.Default, DEFAULT_EVENT_GENERATOR, iconType);
    }

    public StopButton(String id, boolean emptyLabel) {
        this(id, emptyLabel ? GenericModels.MODEL_EMPTY : new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_STOP));
    }

    public StopButton(String id, IModel<String> labelModel) {
        this(id, labelModel, Buttons.Type.Default);
    }

    public StopButton(String id, boolean emptyLabel, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator) {
        this(id, emptyLabel ? GenericModels.MODEL_EMPTY : new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_STOP), Buttons.Type.Default, newEventGenerator);
    }

    public StopButton(String id, IModel<String> labelModel, Buttons.Type type) {
        this(id, labelModel, type, DEFAULT_EVENT_GENERATOR);
    }

    public StopButton(String id, IModel<String> labelModel, Buttons.Type type, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator) {
        this(id, labelModel, type, newEventGenerator, ICON_STOP);
    }

    public StopButton(String id, IModel<String> labelModel, IconType iconType, ISerializableFunction<Form<?>, ?> newEventGenerator) {
        this(id, labelModel, Buttons.Type.Default, (target, form) -> new StopEvent<>(target, newEventGenerator.apply(form)), iconType);
    }

    public StopButton(String id, IModel<String> labelModel, Buttons.Type type, ISerializableBiFunction<AjaxRequestTarget, Form<?>, ?> newEventGenerator, IconType iconType) {
        super(id, labelModel, type, (Form<?>) null, newEventGenerator, new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_BUTTON_STOP));
        this.setIconType(iconType);
    }
}