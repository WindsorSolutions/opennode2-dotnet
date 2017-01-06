package com.windsor.node.web.content.login;

import org.apache.commons.lang.StringUtils;
import org.apache.wicket.Application;
import org.apache.wicket.Component;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.markup.head.IHeaderResponse;
import org.apache.wicket.markup.head.OnDomReadyHeaderItem;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.PasswordTextField;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.image.Image;
import org.apache.wicket.model.Model;
import org.apache.wicket.protocol.http.servlet.ServletWebRequest;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.request.resource.PackageResourceReference;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.LockedException;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.web.WebAttributes;
import org.springframework.web.util.WebUtils;

import com.windsor.node.service.NodeSystemInfoService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.page.NodeBasePage;
import com.windsor.node.web.theme.NodeTheme;
import com.windsor.stack.web.wicket.component.feedback.WindsorFeedbackPanel;
import com.windsor.stack.web.wicket.markup.html.form.ValidationForm;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.button.BootstrapButton;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.FormGroup;
import de.agilecoders.wicket.core.markup.html.bootstrap.form.InputBehavior;

/**
 * Provides the sign-in page for the application.
 */
public class LoginPage extends NodeBasePage<Void> {

    @SpringBean
    private NodeSystemInfoService nodeSystemInfoService;

    private final TextField<String> accountName;

    public LoginPage(PageParameters pageParameters) {
        super();

        Form<?> form = new ValidationForm<>("form");
        add(form);

        Component feedback = new WindsorFeedbackPanel("feedback");

        accountName = new TextField<String>("field", Model.of("")) {

            @Override
            public String getInputName() {
                return "username";
            }

        };
        accountName.setOutputMarkupId(true);
        accountName.setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EMAIL));
        accountName.add(new InputBehavior());

        form.add(
                feedback,

                new Image("image", new PackageResourceReference(NodeTheme.class, "img/logo.png"))
                        .add(new AttributeAppender("height", "60"))
                        .add(new AttributeAppender("alt", "OpenNode2")),

                new FormGroup("usernameGroup")
                        .add(accountName),

                new FormGroup("passwordGroup")
                        .add(new PasswordTextField("field", Model.of("")) {

                            @Override
                            public String getInputName() {
                                return "password";
                            }

                        }.setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PASSWORD))
                                .add(new InputBehavior())),

                new BootstrapButton("login",
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SIGNIN), Buttons.Type.Primary)

        );

        if (pageParameters.getNamedKeys().contains("error")) {
            String errorMessage = getErrorMessage();
            if (StringUtils.isNotBlank(errorMessage)) {
                error(errorMessage);
            }
        }
    }

    @Override
    public void renderHead(IHeaderResponse response) {
        super.renderHead(response);
        response.render(OnDomReadyHeaderItem.forScript(String.format("document.getElementById('%s').focus();",
                accountName.getMarkupId())));
    }

    private String getErrorMessage() {
        AuthenticationException authenticationException =
                (AuthenticationException) WebUtils.getSessionAttribute(((ServletWebRequest)getRequest())
                        .getContainerRequest(), WebAttributes.AUTHENTICATION_EXCEPTION);

        String msg = null;
        if (authenticationException != null) {
            String key = getErrorMessageKey(authenticationException);
            msg = Application.get()
                    .getResourceSettings()
                    .getLocalizer()
                    .getString(key, this, "Authentication error");
        }
        return msg;
    }

    private static String getErrorMessageKey(AuthenticationException e) {
        String key = null;
        if (e instanceof LockedException) {
            key = "msg.accountLocked";
        } else if (e instanceof DisabledException) {
            key = "msg.accountDisabled";
        } else if (e instanceof BadCredentialsException || e instanceof UsernameNotFoundException) {
            key = "msg.badCredentials";
        } else {
            key = "msg.loginError";
        }
        return key;
    }
}
