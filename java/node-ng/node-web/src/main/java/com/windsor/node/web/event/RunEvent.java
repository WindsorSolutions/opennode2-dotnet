package com.windsor.node.web.event;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractPayloadTypedEvent;

/**
 * Provides an even indicating that run has been requested.
 */
public class RunEvent<T> extends AbstractPayloadTypedEvent<T> {
    public RunEvent(AjaxRequestTarget target, T payload) {
        super(target, payload);
    }
}
