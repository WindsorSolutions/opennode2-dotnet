package com.windsor.node.web.component.page;

import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.content.home.HomePage;
import com.windsor.node.web.content.login.LoginPage;
import com.windsor.node.web.theme.NodeTheme;
import com.windsor.stack.web.wicket.behavior.CssClassNameAppender;
import com.windsor.stack.web.wicket.behavior.OnlyVisibleIfLoggedInBehavior;
import com.windsor.stack.web.wicket.behavior.OnlyVisibleIfNotLoggedInBehavior;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.page.login.LogoutPage;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.Navbar;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarButton;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarComponents;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.markup.html.TransparentWebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.image.Image;
import org.apache.wicket.model.Model;
import org.apache.wicket.request.resource.PackageResourceReference;

/**
 * Provides the global navigation bar for the application.
 */
public class GlobalNavBar extends Navbar {

    public GlobalNavBar(final String cid) {
        super(cid);

        setPosition(Position.STATIC_TOP);
        addComponents(NavbarComponents.transform(ComponentPosition.RIGHT,
                home(),
                login(),
                logout()));
    }

    @Override
    protected void onInitialize() {
        super.onInitialize();

        if (!(getPage() instanceof HomePage)) {
            add(new CssClassNameAppender(Model.of("navbar-global")));
        }
    }

    @Override
    protected TransparentWebMarkupContainer newContainer(String componentId) {
        TransparentWebMarkupContainer container = super.newContainer(componentId);
        container.add(new CssClassNameAppender(Model.of("container-full")));
        return container;
    }

    @Override
    protected Image newBrandImage(String markupId) {
        Image image = new Image("brandImage", new PackageResourceReference(NodeTheme.class, "img/logo.png"));
        image.add(new AttributeAppender("height", "36"));
        image.add(new AttributeAppender("alt", "Return to Application Home"));
        image.add(new AttributeAppender("title", "Return to Application Home"));
        return image;
    }

    @Override
    protected Label newBrandLabel(String markupId) {
        return new Label(markupId, "");
    }

    private NavbarButton<String> home() {
        NavbarButton<String> home = new NavbarButton<>(getHomePage(),
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HOME));
        return home;
    }

    private NavbarButton<String> login() {
        NavbarButton<String> login = new NavbarButton<>(LoginPage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SIGNIN));
        login.add(new OnlyVisibleIfNotLoggedInBehavior());
        return login;
    }

    private NavbarButton<String> logout() {
        NavbarButton<String> logout = new NavbarButton<>(LogoutPage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SIGNOUT));
        logout.add(new OnlyVisibleIfLoggedInBehavior());
        return logout;
    }
}
