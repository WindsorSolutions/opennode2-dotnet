package com.windsor.node.web.component;

import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import de.agilecoders.wicket.core.util.Components;
import org.apache.wicket.Component;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

/**
 * Provides a title for the workspace.
 */
public class WorkspaceTitlePanel <T> extends AbstractBasePanel<T> {

    private final IModel<String> primaryTitleModel;
    private final IModel<String> pageTitleModel;
    private final IModel<String> secondaryTitleModel;

    private final Component pageTitle;
    private final Component primaryTitle;
    private final Component secondaryTitle;
    private final Component additionalInfoPanel;

    public WorkspaceTitlePanel(String id, IModel<T> panelModel, IModel<String> primaryTitleModel,
                               IModel<String> pageTitleModel, IModel<String> secondaryTitleModel) {
        super(id, panelModel);

        this.primaryTitleModel = primaryTitleModel;
        this.pageTitleModel = pageTitleModel;
        this.secondaryTitleModel = secondaryTitleModel;

        add(pageTitle = newPageTitle("pageTitle", pageTitleModel));
        add(primaryTitle = newPrimaryTitle("primaryTitle", primaryTitleModel));
        add(secondaryTitle = newSecondaryTitle("secondaryTitle", secondaryTitleModel));
        add(additionalInfoPanel = newAdditionalInfoPanel("additionalInfoPanel", panelModel));
    }

    @Override
    protected void onInitialize() {
        super.onInitialize();
        Components.hideIfModelIsEmpty(pageTitle);
        Components.hideIfModelIsEmpty(primaryTitle);
        Components.hideIfModelIsEmpty(secondaryTitle);
        Components.hideIfModelIsEmpty(additionalInfoPanel);
    }

    protected Component newPageTitle(String cid, IModel<String> model) {
        return new Label(cid, model);
    }

    protected Component newPrimaryTitle(String cid, IModel<String> model) {
        return new Label(cid, model);
    }

    protected Component newSecondaryTitle(String cid, IModel<String> model) {
        return new Label(cid, model);
    }

    protected Component newAdditionalInfoPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    @Override
    protected void onDetach() {
        super.onDetach();
        if (primaryTitleModel != null) primaryTitleModel.detach();
        if (pageTitleModel != null) pageTitleModel.detach();
        if (secondaryTitleModel != null) secondaryTitleModel.detach();
    }
}
