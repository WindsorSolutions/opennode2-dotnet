package com.windsor.node.web.component.page;

import org.apache.wicket.Page;
import org.apache.wicket.PageReference;
import org.apache.wicket.RestartResponseException;
import org.apache.wicket.markup.head.CssHeaderItem;
import org.apache.wicket.markup.head.IHeaderResponse;
import org.apache.wicket.markup.head.OnDomReadyHeaderItem;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.AccountService;
import com.windsor.node.web.event.PasswordEnteredEvent;
import com.windsor.node.web.model.LoggedInAccountModel;
import com.windsor.stack.web.wicket.event.PreviousEvent;
import com.windsor.stack.web.wicket.page.login.LogoutPage;
import com.windsor.stack.web.wicket.page.viewport.HeaderFooterPage;

import de.agilecoders.wicket.core.markup.html.bootstrap.navbar.Navbar;
import de.agilecoders.wicket.extensions.markup.html.bootstrap.icon.FontAwesomeCssReference;

/**
 * Provides the foundation for most application pages.
 */
public class NodeBasePage<T> extends HeaderFooterPage<T> {

    /**
     * Parameter used to indicate previous page.
     */
    public static final String PARAM_PREV_PAGE_ID = "ppid";

    @SpringBean
    private AccountService accountService;

    /**
     * Model with the logged in account.
     */
    private IModel<Account> loggedInAccountModel = new LoggedInAccountModel();

    /**
     * Reference to the previous page.
     */
    private PageReference previousPageReference;

    public NodeBasePage() {
        this(new PageParameters());
    }

    public NodeBasePage(IModel<T> model) {
        super(model);
    }

    public NodeBasePage(PageParameters pageParameters) {
        this(pageParameters, null);
    }

    public NodeBasePage(PageParameters pageParameters, PageReference previousPageReference) {
        super(pageParameters);
        this.previousPageReference = previousPageReference;
        if (previousPageReference == null && (!pageParameters.get(PARAM_PREV_PAGE_ID).isEmpty())) {
            this.previousPageReference = new PageReference(pageParameters.get(PARAM_PREV_PAGE_ID).toInt());
        }
    }

    @Override
    protected String getMainContentAnchor() {
        return "#contentStart";
    }

    @Override
    protected void onDetach() {
        super.onDetach();
        loggedInAccountModel.detach();
    }

    protected IModel<Account> getUserModel() {
        return loggedInAccountModel;
    }

    public boolean hasPreviousPage() {

        return getPreviousPageReference() != null;
    }

    public static PageParameters newPageParameters(PageReference previousPageReference) {
        PageParameters pageParameters = new PageParameters();
        if (previousPageReference != null) {
            pageParameters.add(PARAM_PREV_PAGE_ID, previousPageReference.getPageId());
        }
        return pageParameters;
    }

    @Override
    protected Navbar getGlobalNavBar(String cid) {
        return new GlobalNavBar(cid);
    }

    @Override
    protected Navbar getAppNavBar(String cid) {
        return new ApplicationNavBar(cid);
    }

    @Override
    protected Panel getFooterPanel(String cid) {
        return new FooterPanel(cid);
    }

    protected PageReference getPreviousPageReference() {
        return previousPageReference;
    }

    protected PageReference getPreviousPageReference(PageReference previousPageReference) {
        return previousPageReference;
    }

    @OnEvent
    public void onPreviousEvent(PreviousEvent target) {
        PageReference pageRef = getPreviousPageReference();
        if (pageRef != null) {
            Page page = pageRef.getPage();
            setResponsePage(page);
        }
    }

    @OnEvent
    public void handlePasswordEnteredEvent(PasswordEnteredEvent event) {

        Account account = getUserModel().getObject();

        if (account != null) {

            if (!event.isCorrect()) {

                if (!account.isActive()) {

                    throw new RestartResponseException(LogoutPage.class);
                }
            }
        }
    }

    @Override
    public void renderHead(IHeaderResponse response) {
        super.renderHead(response);
        response.render(CssHeaderItem.forReference(FontAwesomeCssReference.instance()));

        String moveDebugLink = "$(function() { if((typeof Wicket.Ajax.DebugWindow !== 'undefined') && Wicket.Ajax.DebugWindow.enabled) { setTimeout(function() { $('#wicketDebugLink').css('bottom', '50px'); }, 500); }});";

        response.render(OnDomReadyHeaderItem.forScript(moveDebugLink));
    }
}
