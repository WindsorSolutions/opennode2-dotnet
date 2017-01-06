package com.windsor.node.web.validator;

import java.util.Arrays;
import java.util.regex.Pattern;

import com.windsor.stack.web.wicket.validation.PatternsValidator;


public class PasswordComplexityValidator extends PatternsValidator {

	public PasswordComplexityValidator() {
		super(Arrays.asList(
				Pattern.compile("[0-9]"),
		        Pattern.compile("[A-Z]"),
                Pattern.compile("[a-z]")));
	}

}
