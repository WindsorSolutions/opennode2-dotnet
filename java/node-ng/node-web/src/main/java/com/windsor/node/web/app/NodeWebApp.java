package com.windsor.node.web.app;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.web.app.config.SecurityConfig;
import com.windsor.node.web.content.account.AccountListPage;
import com.windsor.node.web.content.activity.ActivityPage;
import com.windsor.node.web.content.argument.ArgumentPage;
import com.windsor.node.web.content.datasource.DataSourcePage;
import com.windsor.node.web.content.error.ErrorPage;
import com.windsor.node.web.content.exchange.ExchangePage;
import com.windsor.node.web.content.home.HomePage;
import com.windsor.node.web.content.login.LoginPage;
import com.windsor.node.web.content.partner.PartnerPage;
import com.windsor.node.web.content.profile.AccountProfilePage;
import com.windsor.node.web.content.schedule.SchedulePage;
import com.windsor.node.web.converter.AccountConverter;
import com.windsor.node.web.converter.ExchangeConverter;
import com.windsor.node.web.theme.NodeTheme;
import com.windsor.stack.domain.search.LocalDateRange;
import com.windsor.stack.domain.search.LocalDateTimeRange;
import com.windsor.stack.domain.security.ISecurityUser;
import com.windsor.stack.web.wicket.app.WindsorWebApplication;
import com.windsor.stack.web.wicket.component.daterange.LocalDateRangeConverter;
import com.windsor.stack.web.wicket.component.daterange.LocalDateTimeRangeConverter;
import com.windsor.stack.web.wicket.security.SpringAuthenticatedWebSession;
import com.windsor.stack.web.wicket.security.authorization.AuthorizationStrategy;
import com.windsor.stack.web.wicket.util.convert.LocalDateConverter;
import com.windsor.stack.web.wicket.util.convert.LocalDateTimeConverter;
import de.agilecoders.wicket.core.Bootstrap;
import de.agilecoders.wicket.core.settings.BootstrapSettings;
import de.agilecoders.wicket.core.settings.SingleThemeProvider;
import de.agilecoders.wicket.less.BootstrapLess;
import de.agilecoders.wicket.webjars.WicketWebjars;
import de.agilecoders.wicket.webjars.request.resource.WebjarsCssResourceReference;
import de.agilecoders.wicket.webjars.request.resource.WebjarsJavaScriptResourceReference;
import org.apache.wicket.ConverterLocator;
import org.apache.wicket.IConverterLocator;
import org.apache.wicket.Page;
import org.apache.wicket.authroles.authorization.strategies.role.RoleAuthorizationStrategy;
import org.springframework.security.authentication.AnonymousAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.wicketstuff.select2.ApplicationSettings;

import java.time.LocalDate;
import java.time.LocalDateTime;

/**
 * Provides our web application.
 */
public class NodeWebApp extends WindsorWebApplication {

    @Override
    public Class<? extends Page> getHomePage() {
        return HomePage.class;
    }

    @Override
    protected void init() {
        super.init();
        configureAuthorizationStrategy();
        configureBootstrap();
        configureWebJars();
        configureSelect2();
        mountPages();
    }

    @Override
    protected IConverterLocator newConverterLocator() {
        ConverterLocator locator = (ConverterLocator) super.newConverterLocator();
        locator.set(LocalDate.class, new LocalDateConverter("M/d/yyyy"));
        locator.set(LocalDateTime.class, new LocalDateTimeConverter("M/d/yyyy hh:mm:ss a"));
        locator.set(LocalDateRange.class, new LocalDateRangeConverter());
        locator.set(LocalDateTimeRange.class, new LocalDateTimeRangeConverter());
        locator.set(Exchange.class, new ExchangeConverter());
        locator.set(Account.class, new AccountConverter());
        return locator;
    }

    private void mountPages() {

        // secured pages
        mountPage("/configuration/arguments", ArgumentPage.class);
        mountPage("/configuration/data", DataSourcePage.class);
        mountPage("/configuration/partners", PartnerPage.class);
        mountPage("/security", AccountListPage.class);
        mountPage("/exchanges", ExchangePage.class);
        mountPage("/activity", ActivityPage.class);
        mountPage("/schedules", SchedulePage.class);
        mountPage("/profile", AccountProfilePage.class);

        // open pages
        mountPage(SecurityConfig.PATH_LOGIN, LoginPage.class);
        mountPage(SecurityConfig.PATH_APP_ERROR, ErrorPage.class);
        mountPage(SecurityConfig.PATH_404_ERROR, ErrorPage.class);
        mountPage(SecurityConfig.PATH_500_ERROR, ErrorPage.class);
        mountPage(SecurityConfig.PATH_401_ERROR, ErrorPage.class);
        mountPage(SecurityConfig.PATH_EXPIRED_ERROR, ErrorPage.class);
    }

    private void configureBootstrap() {
        BootstrapSettings settings = new BootstrapSettings();
        settings.setThemeProvider(new SingleThemeProvider(new NodeTheme()));
        Bootstrap.install(this, settings);
        BootstrapLess.install(this);
    }

    private void configureWebJars() {
        WicketWebjars.settings().useCdnResources();
    }

    private void configureSelect2() {
        ApplicationSettings applicationSettings = ApplicationSettings.get();
        applicationSettings.setCssReference(new WebjarsCssResourceReference("select2/current/select2.css"));
        applicationSettings.setJavaScriptReference(new WebjarsJavaScriptResourceReference("select2/current/select2.js"));
    }

    private void configureAuthorizationStrategy() {
        RoleAuthorizationStrategy as = (RoleAuthorizationStrategy) getSecuritySettings().getAuthorizationStrategy();
        as.add(new AuthorizationStrategy<>(() -> {
            ISecurityUser<Account> su = null;
            Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
            if (authentication != null && (!(authentication instanceof AnonymousAuthenticationToken))) {
                SpringAuthenticatedWebSession<Account> session = SpringAuthenticatedWebSession.getCurrent();
                su = session.getSecurityUser().get();
            }
            return su;
        }));
    }
}
