package com.windsor.node.web.model;

import org.apache.wicket.model.IModel;

import com.windsor.node.web.app.Icons;
import com.windsor.node.web.component.IconInfo;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class SuccessErrorIconInfoModel extends LoadableDetachableWrappedModel<IconInfo, Boolean> {

	public SuccessErrorIconInfoModel(IModel<Boolean> wrappedModel) {
		super(wrappedModel);
	}

	@Override
	protected IconInfo load() {
		Boolean b = getWrappedModel().getObject();
		return b == null ? null : 
			b ? new IconInfo(Icons.ICON_OK, IconInfo.IconStyle.SUCCESS) 
					: new IconInfo(Icons.ICON_ERROR, IconInfo.IconStyle.WARNING); 
	}

}
