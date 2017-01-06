package com.windsor.node.web.content.error;

import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;

import com.windsor.node.web.component.page.NodeBasePage;

/**
 * Provides the error page for the application.
 */
public class ErrorPage extends NodeBasePage<Void> {

    public ErrorPage() {
        this(Model.of("An Error Has Occurred..."), Model.of("An unexpected application error has occurred"));
    }

    public ErrorPage(IModel<String> titleModel, IModel<String> descriptionModel) {
        super();
        add(new ErrorPagePanel("panel", titleModel, descriptionModel));
    }
}
