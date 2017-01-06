package com.windsor.node.web.event;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractPayloadTypedEvent;

public class ToggleEvent<T> extends AbstractPayloadTypedEvent<T> {

    public ToggleEvent(AjaxRequestTarget target, T payload) {
        super(target, payload);
    }

}
