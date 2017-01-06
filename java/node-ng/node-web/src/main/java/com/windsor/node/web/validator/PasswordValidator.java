package com.windsor.node.web.validator;

import org.apache.wicket.validation.CompoundValidator;
import org.apache.wicket.validation.validator.StringValidator;


public class PasswordValidator extends CompoundValidator<String> {

	public PasswordValidator() {
		super();
		add(new PasswordComplexityValidator());
		add(new StringValidator(8, 20));
	}

}
