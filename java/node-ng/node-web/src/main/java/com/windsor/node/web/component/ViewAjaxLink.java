package com.windsor.node.web.component;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.markup.html.AjaxLink;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.model.IModel;

import com.windsor.stack.web.wicket.event.ViewEvent;

public class ViewAjaxLink<T> extends AjaxLink<T> {

	public ViewAjaxLink(String id, IModel<T> model) {
		super(id, model);
	}

	@Override
	public void onClick(AjaxRequestTarget target) {
		send(this, Broadcast.BUBBLE, new ViewEvent<>(target, getModelObject()));
	}

}
