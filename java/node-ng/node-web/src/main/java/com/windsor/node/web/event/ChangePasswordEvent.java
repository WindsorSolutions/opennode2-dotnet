package com.windsor.node.web.event;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractPayloadTypedEvent;

public class ChangePasswordEvent<T> extends AbstractPayloadTypedEvent<T> {

    public ChangePasswordEvent(AjaxRequestTarget target, T payload) {
        super(target, payload);
    }

}
