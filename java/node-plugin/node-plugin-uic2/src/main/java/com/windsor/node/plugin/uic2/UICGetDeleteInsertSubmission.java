package com.windsor.node.plugin.uic2;

import com.windsor.node.plugin.uic2.domain.UICDataType;

public class UICGetDeleteInsertSubmission extends AbstractUicPlugin<UICDataType> {

    public UICGetDeleteInsertSubmission() {
        super(OperationType.DELETE_INSERT);
    }

}
