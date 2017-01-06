package com.windsor.node.web.content.error;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.link.BookmarkablePageLink;
import org.apache.wicket.model.IModel;

import com.windsor.node.web.component.NodeBasePanel;
import com.windsor.node.web.content.home.HomePage;

/**
 * Provides the error panel for the application
 */
public class ErrorPagePanel extends NodeBasePanel<Void> {

    public ErrorPagePanel(String id, IModel<String> titleModel, IModel<String> descriptionModel) {
        super(id, null);

        add(new Label("title", titleModel));
        add(new Label("description", descriptionModel));

        add(new BookmarkablePageLink<>("homeLink", HomePage.class));
    }

}
