package com.windsor.node.web.model;

import static com.windsor.node.web.app.NodeResourceModelKeys.LABEL_NO;
import static com.windsor.node.web.app.NodeResourceModelKeys.LABEL_YES;

import org.apache.wicket.model.IModel;

import com.windsor.stack.web.wicket.model.BooleanResourceModel;

public class YesNoModel extends BooleanResourceModel {

        public YesNoModel(IModel<Boolean> model) {
            super(model, LABEL_NO, LABEL_YES);
        }

}