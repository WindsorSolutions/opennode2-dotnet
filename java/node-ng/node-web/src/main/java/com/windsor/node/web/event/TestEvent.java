package com.windsor.node.web.event;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractPayloadTypedEvent;

/**
 * Provides an event indicating that a test has been requested.
 */
public class TestEvent<T>  extends AbstractPayloadTypedEvent<T> {
    public TestEvent(AjaxRequestTarget target, T payload){
        super(target, payload);
    }
}
