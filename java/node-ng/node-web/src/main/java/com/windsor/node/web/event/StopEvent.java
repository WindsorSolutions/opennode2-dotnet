package com.windsor.node.web.event;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractPayloadTypedEvent;

/**
 * Provides an even indicating that stop has been requested.
 */
public class StopEvent<T> extends AbstractPayloadTypedEvent<T> {
    public StopEvent(AjaxRequestTarget target, T payload) {
        super(target, payload);
    }
}
