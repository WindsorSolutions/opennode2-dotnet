package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDateTime;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.NaasSyncInfo;

public class NaasSyncInfoModel {

	public static final LazyModel<String> ACTIVITY_ID = model(from(NaasSyncInfo.class).getActivityId());
	public static final LazyModel<LocalDateTime> DATE = model(from(NaasSyncInfo.class).getSyncDate());
	public static final LazyModel<Boolean> SUCCESSFUL = model(from(NaasSyncInfo.class).isSuccessful());
	
	private NaasSyncInfoModel() {
		super();
	}
	
	public static IModel<String> bindActivityId(IModel<NaasSyncInfo> model) {
		return ACTIVITY_ID.bind(model);
	}
	
	public static IModel<LocalDateTime> bindDate(IModel<NaasSyncInfo> model) {
		return DATE.bind(model);
	}
	
	public static IModel<Boolean> bindSuccessful(IModel<NaasSyncInfo> model) {
		return SUCCESSFUL.bind(model);
	}
	
}
