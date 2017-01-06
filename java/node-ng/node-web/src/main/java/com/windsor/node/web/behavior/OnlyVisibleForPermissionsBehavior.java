package com.windsor.node.web.behavior;

import java.util.stream.Stream;

import com.windsor.node.domain.NodePermission;
import com.windsor.node.web.model.HasPermissionsModel;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;

public class OnlyVisibleForPermissionsBehavior extends VisibleModelBehavior {

    public OnlyVisibleForPermissionsBehavior(NodePermission... permissions) {
        super(new HasPermissionsModel(permissions));
    }

    public OnlyVisibleForPermissionsBehavior(Stream<NodePermission> permissions) {
        super(new HasPermissionsModel(permissions));
    }

}
