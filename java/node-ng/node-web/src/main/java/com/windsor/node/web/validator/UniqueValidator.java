package com.windsor.node.web.validator;

import org.apache.wicket.validation.IValidatable;
import org.apache.wicket.validation.IValidator;
import org.apache.wicket.validation.ValidationError;

import com.windsor.stack.domain.util.ISerializableFunction;

public class UniqueValidator<T> implements IValidator<T>{

    private ISerializableFunction<T, Boolean> isUniqueFunction;

    public UniqueValidator(ISerializableFunction<T, Boolean> isUniqueFunction) {
        this.isUniqueFunction = isUniqueFunction;
    }

    @Override
    public void validate(IValidatable<T> validatable) {
        T t = validatable.getValue();
        boolean isUnique = isUniqueFunction.apply(t);
        if (!isUnique) {
            validatable.error(new ValidationError(this));
        }
    }

}
