package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.LoginInfo;

public class LoginInfoModels {

	public static final LazyModel<String> EMAIL = model(from(LoginInfo.class).getEmail());
	public static final LazyModel<LocalDateTime> DATE = model(from(LoginInfo.class).getLoginDate());
	public static final LazyModel<Boolean> SUCCESSFUL = model(from(LoginInfo.class).isSuccessful());
	
	private LoginInfoModels() {
		super();
	}
	
	public static IModel<String> bindName(IModel<LoginInfo> model) {
		return EMAIL.bind(model);
	}
	
	public static IModel<LocalDateTime> bindDate(IModel<LoginInfo> model) {
		return DATE.bind(model);
	}
	
	public static IModel<Boolean> bindSuccessful(IModel<LoginInfo> model) {
		return SUCCESSFUL.bind(model);
	}
	
}
