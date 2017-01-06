package com.windsor.node.web.model;

import java.time.format.DateTimeFormatter;
import java.time.temporal.TemporalAccessor;

import org.apache.wicket.model.IModel;

import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class FormattedTemporalAccessorModel<T extends TemporalAccessor> extends LoadableDetachableWrappedModel<String, T> {

	private String format;
	
	public FormattedTemporalAccessorModel(IModel<T> wrappedModel, String format) {
		super(wrappedModel);
		this.format = format;
	}

	@Override
	protected String load() {
		T t = getWrappedModel().getObject();
		return t == null ? null : DateTimeFormatter.ofPattern(format).format(t);
	}

}
