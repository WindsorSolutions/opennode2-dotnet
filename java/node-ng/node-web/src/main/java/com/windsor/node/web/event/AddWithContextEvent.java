package com.windsor.node.web.event;

import java.util.Arrays;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.wicketstuff.event.annotation.AbstractTypedEvent;

public class AddWithContextEvent<T> extends AbstractTypedEvent<T> {

    public AddWithContextEvent(AjaxRequestTarget target, T payload, Class<?> context) {
        super(target, payload, Arrays.asList(context, payload.getClass()));
    }

}
