package com.windsor.node.plugin.uic2;

import com.windsor.node.common.domain.NodeTransaction;

public class TransactionParameters {

    private NodeTransaction transaction;

    public TransactionParameters(NodeTransaction transaction) {
        this.transaction = transaction;
    }

    public String getOrgId() {
        Object obj = transaction.getRequest().getParameters()
                .get(PluginParameters.ORG_ID.getParameterDescriptor().getName());
        return (String) (obj != null ? obj : transaction.getRequest()
                .getParameters().get(PluginParameters.ORG_ID.ordinal()));
    }

}
