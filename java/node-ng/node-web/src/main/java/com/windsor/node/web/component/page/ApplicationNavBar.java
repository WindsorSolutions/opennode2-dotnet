package com.windsor.node.web.component.page;

import java.util.ArrayList;
import java.util.List;

import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.markup.html.TransparentWebMarkupContainer;
import org.apache.wicket.markup.html.link.AbstractLink;
import org.apache.wicket.model.Model;

import com.windsor.node.domain.NodePermission;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.behavior.OnlyVisibleForPermissionsBehavior;
import com.windsor.node.web.component.NodeDropDownButton;
import com.windsor.node.web.content.account.AccountListPage;
import com.windsor.node.web.content.activity.ActivityPage;
import com.windsor.node.web.content.argument.ArgumentPage;
import com.windsor.node.web.content.datasource.DataSourcePage;
import com.windsor.node.web.content.exchange.ExchangePage;
import com.windsor.node.web.content.home.HomePage;
import com.windsor.node.web.content.partner.PartnerPage;
import com.windsor.node.web.content.profile.AccountProfilePage;
import com.windsor.node.web.content.schedule.SchedulePage;
import com.windsor.stack.web.wicket.behavior.CssClassNameAppender;
import com.windsor.stack.web.wicket.behavior.OnlyVisibleIfLoggedInBehavior;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.ButtonList;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.Navbar;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarAjaxLink;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarButton;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarComponents;
import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.NavbarDropDownButton;
import de.agilecoders.wicket.extensions.markup.html.bootstrap.icon.FontAwesomeIconType;

/**
 * Provides an more specific navigation bar for the application.
 */
public class ApplicationNavBar extends Navbar {

    public ApplicationNavBar(String componentId) {
        super(componentId);

        setPosition(Position.STATIC_TOP);
        setInverted(true);

        addComponents(NavbarComponents.transform(Navbar.ComponentPosition.LEFT,
                dashboard(),
                configuration(),
                security(),
                exchange(),
                schedule(),
                activity()));

        addComponents(NavbarComponents.transform(ComponentPosition.RIGHT,
                profile()));

    }

    @Override
    protected void onInitialize() {
        super.onInitialize();
    }

    @Override
    protected TransparentWebMarkupContainer newContainer(String componentId) {
        TransparentWebMarkupContainer container = super.newContainer(componentId);
        container.add(new CssClassNameAppender(Model.of("container-full")));
        return container;
    }

    private NavbarButton<?> dashboard() {
        NavbarButton<String> button = new NavbarButton<>(HomePage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACCOUNT_HOME_PAGE));
        button.add(new OnlyVisibleIfLoggedInBehavior());
        return button;
    }

    private NavbarDropDownButton configuration() {
        NodeDropDownButton dd =
                new NodeDropDownButton(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_CONFIGURATION)) {

            @Override
            protected List<AbstractLink> newSubMenuButtons(String buttonMarkupId) {

                List<AbstractLink> links = new ArrayList<>();

                links.add(new NavbarAjaxLink<String>(ButtonList.getButtonMarkupId(),
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_CONFIGURATION_ARGUMENTS)) {

                    @Override
                    public void onClick(AjaxRequestTarget target) {
                        setResponsePage(ArgumentPage.class);
                    }

                });

                links.add(new NavbarAjaxLink<String>(ButtonList.getButtonMarkupId(),
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_CONFIGURATION_SOURCES)) {

                    @Override
                    public void onClick(AjaxRequestTarget target) {
                        setResponsePage(DataSourcePage.class);
                    }

                });

                links.add(new NavbarAjaxLink<String>(ButtonList.getButtonMarkupId(),
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_CONFIGURATION_PARTNERS)) {

                    @Override
                    public void onClick(AjaxRequestTarget target) {
                        setResponsePage(PartnerPage.class);
                    }

                });

                return links;
            }
        };
        dd.add(new OnlyVisibleForPermissionsBehavior(NodePermission.ADMIN_USER));
        return dd;
    }

    private NavbarButton<?> security() {
        NavbarButton<String> button = new NavbarButton<>(AccountListPage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_SECURITY));
        button.add(new OnlyVisibleForPermissionsBehavior(NodePermission.ADMIN_USER));
        return button;

    }

    private NavbarButton<?> exchange() {
        NavbarButton<String> button = new NavbarButton<>(ExchangePage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_EXCHANGE));
        button.add(new OnlyVisibleForPermissionsBehavior(NodePermission.ADMIN_USER));
        return button;
    }

    private NavbarButton<?> schedule() {
        NavbarButton<String> button = new NavbarButton<>(SchedulePage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_SCHEDULE));
        button.add(new OnlyVisibleIfLoggedInBehavior());
        return button;
    }

    private NavbarButton<?> activity() {
        NavbarButton<String> button = new NavbarButton<>(ActivityPage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_ACTIVITY));
        button.add(new OnlyVisibleIfLoggedInBehavior());
        return button;
    }

    private Component profile() {
        NavbarButton<String> button = new NavbarButton<>(AccountProfilePage.class,
                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PAGE_PROFILE));
        button.add(new OnlyVisibleIfLoggedInBehavior());
        button.setIconType(FontAwesomeIconType.cog);
        button.add(new AttributeAppender("title", "Go to account profile"));
        return button;
    }
}
