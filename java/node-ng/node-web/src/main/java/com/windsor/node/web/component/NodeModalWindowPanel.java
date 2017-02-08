package com.windsor.node.web.component;

import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import org.apache.wicket.model.Model;

public class NodeModalWindowPanel extends WindsorModalWindowPanel {

    public NodeModalWindowPanel(String id) {
        super(id);
        getModal().setCloseOnEscapeKeyModel(Model.of(true));
    }

}
