package com.windsor.node.web.component.page;

import com.windsor.stack.web.wicket.page.viewport.WindsorWorkspacePanelNoFooter;
import org.apache.wicket.Component;
import org.apache.wicket.PageReference;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.mapper.parameter.PageParameters;

/**
 * Provides a detail page for the application.
 */
public class NodeDetailPage<T> extends NodeBasePage<T> {

    private WindsorWorkspacePanelNoFooter<?> workspace;

    /**
     * Creates a new instance.
     */
    public NodeDetailPage() {
        super();
    }

    /**
     * Creates a new instance.
     *
     * @param pageParameters        Page parameters
     * @param previousPageReference Reference to the previous page
     */
    public NodeDetailPage(PageParameters pageParameters, PageReference previousPageReference) {
        super(pageParameters, previousPageReference);
    }

    /**
     * Creates a new instance.
     *
     * @param pageParameters Page parameters
     */
    public NodeDetailPage(PageParameters pageParameters) {
        super(pageParameters, null);
    }

    /**
     * Returns the content panel for the page.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the panel
     * @return New instance
     */
    protected Component contentPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    /**
     * Returns the content for the right-hand panel.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the panel
     * @return New instance
     */
    protected Component rightPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    /**
     * Returns the panel to be used in the header.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the title
     * @return New instance
     */
    protected Component titlePanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    /**
     * Returns the component for the secondary title panel.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the panel
     * @return New instance
     */
    protected Component titleSecondaryPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    /**
     * Returns the component for the left-hand footer panel.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the panel
     * @return New instance
     */
    protected Component leftFooterPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    /**
     * Returns the component for the right-hand footer panel.
     *
     * @param cid   Wicket placeholder ID
     * @param model Backing model for the panel
     * @return New instance
     */
    protected Component rightFooterPanel(String cid, IModel<T> model) {
        return new Label(cid, Model.of(""));
    }

    @Override
    protected void onInitialize() {
        super.onInitialize();

        add(workspace = new WindsorWorkspacePanelNoFooter<T>("panel", getModel()) {
            @Override
            protected Component newContentPanel(String cid) {
                return contentPanel(cid, getModel());
            }

            @Override
            protected Component newRightPanel(String cid) {
                return rightPanel(cid, getModel());
            }

            @Override
            protected Component newTitlePanel(String cid) {
                return titlePanel(cid, getModel());
            }

            @Override
            protected Component newTitleSecondaryPanel(String cid) {
                return titleSecondaryPanel(cid, getModel());
            }

        });
    }

    public void refreshWorkspace(AjaxRequestTarget target) {
        target.add(workspace);
    }

    protected void sendEventToWorkspace(Object event) {
        send(workspace, Broadcast.EXACT, event);
    }
}
