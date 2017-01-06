package de.agilecoders.wicket.core.markup.html.bootstrap.form.radio;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.form.AjaxFormChoiceComponentUpdatingBehavior;
import org.apache.wicket.markup.ComponentTag;
import org.apache.wicket.markup.head.IHeaderResponse;
import org.apache.wicket.markup.head.OnDomReadyHeaderItem;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Radio;
import org.apache.wicket.markup.html.form.RadioGroup;
import org.apache.wicket.markup.html.panel.GenericPanel;
import org.apache.wicket.markup.repeater.RepeatingView;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.util.lang.Args;

/**
 * Allows to quickly build radio options as in
 *
 * http://getbootstrap.com/javascript/#buttons
 *
 *
 * @author Ernesto Reinaldo Barreiro (reiern70@gmail.com)
 *
 */
public class BootstrapRadioGroup<T extends Serializable> extends GenericPanel<T> {

    private List<IModel<T>> options;

    private IRadioChoiceRenderer<T> choiceRenderer;

    private RadioGroup<T> radioGroup;

    /**
     * Callback to be added to receive AJAX notification when selection change.
     *
     * @author reiern70
     *
     * @param <T>
     */
    public interface ISelectionChangeHandler<T>  extends Serializable {

        void onSelectionChanged(AjaxRequestTarget target, T bean);
    }

    /**
     * If set an AjaxFormChoiceComponentUpdatingBehavior will be added to inner
     * {@link RadioGroup} and the interface will be notified about changes on
     * selected radio on client.
     *
     */
    private ISelectionChangeHandler<T> changeHandler;

    public BootstrapRadioGroup(String id, List<T> options) {
        this(id, null, options, null);
    }

    public BootstrapRadioGroup(String id, List<T> options, IRadioChoiceRenderer<T> choiceRenderer) {
        this(id, null, options, choiceRenderer);
    }

    public BootstrapRadioGroup(String id, IModel<T> model, List<T> options) {
        this(id, model, options, null);
    }

    public BootstrapRadioGroup(String id, IModel<T> model, List<T> options, IRadioChoiceRenderer<T> choiceRenderer) {
        super(id, model);
        this.choiceRenderer = choiceRenderer;
        Args.notEmpty(options, "options");
        this.options = new ArrayList<IModel<T>>();
        for(T t: options) {
            this.options.add(choiceRenderer != null? choiceRenderer.modelOf(t): Model.of(t));
        }
    }

    @Override
    protected void detachModel() {
        super.detachModel();
        for(IModel<? extends T> model: options) {
            model.detach();
        }
        choiceRenderer.detach();
    }

    @Override
    protected void onInitialize() {
        super.onInitialize();
        radioGroup = newRadioGroup("radioGroup", getModel());
        radioGroup.setRenderBodyOnly(false);
        radioGroup.setOutputMarkupId(true);
        add(radioGroup);
        if (changeHandler != null) {
            radioGroup.add(new AjaxFormChoiceComponentUpdatingBehavior() {

                @Override
                protected void onUpdate(AjaxRequestTarget target) {
                    changeHandler.onSelectionChanged(target, radioGroup.getModel().getObject());
                }
            });
        }
        RepeatingView radios = new RepeatingView("radios");
        radioGroup.add(radios);
        for (final IModel<T> model: options) {
            WebMarkupContainer wm = new WebMarkupContainer(radios.newChildId()) {
                @Override
                protected void onComponentTag(ComponentTag tag) {
                    super.onComponentTag(tag);
                    // TODO: use model comparator?
                    boolean active = model.getObject().equals(BootstrapRadioGroup.this.getModel().getObject());
                    tag.put("class", "btn "+ choiceRenderer.getButtonClass(model.getObject())+ (active?" active":""));
                }
            };
            radios.add(wm);
            Radio<T> radio = newRadio("radio", model, radioGroup);
            wm.add(radio);
            wm.add(new Label("label", choiceRenderer.lableOf(model.getObject())).setRenderBodyOnly(true));
        }
    }

    @Override
    public void renderHead(IHeaderResponse response) {
        response.render(OnDomReadyHeaderItem.forScript("$('#" + radioGroup.getMarkupId() + " .btn').button()"));
    }


    protected RadioGroup<T> newRadioGroup(String id, IModel<T> model) {
        return new RadioGroup<T>(id, model);
    }

    protected  Radio<T> newRadio(String id, IModel<T> model, RadioGroup<T> radioGroup) {
        return  new Radio<T>(id, model, radioGroup);
    }

    public void setChoiceRenderer(IRadioChoiceRenderer<T> choiceRenderer) {
        this.choiceRenderer = choiceRenderer;
    }


    public void setChangeHandler(ISelectionChangeHandler<T> handler) {
        this.changeHandler = handler;
    }
}