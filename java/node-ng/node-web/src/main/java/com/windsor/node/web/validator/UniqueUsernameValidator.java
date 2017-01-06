package com.windsor.node.web.validator;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.validation.IValidatable;
import org.apache.wicket.validation.IValidator;
import org.apache.wicket.validation.ValidationError;

import com.windsor.node.service.AccountService;

public class UniqueUsernameValidator implements IValidator<String> {

    @SpringBean
    private AccountService service;

    public UniqueUsernameValidator() {
        super();
        Injector.get().inject(this);
    }

    @Override
    public void validate(IValidatable<String> validatable) {
        String username = validatable.getValue();
        if (service.findByName(username).isPresent()) {
            validatable.error(new ValidationError(this));
        }
    }

}