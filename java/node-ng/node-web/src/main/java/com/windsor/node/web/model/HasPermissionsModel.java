package com.windsor.node.web.model;

import java.util.stream.Stream;

import com.windsor.node.domain.NodePermission;
import com.windsor.stack.web.wicket.model.HasRoleModel;

public class HasPermissionsModel extends HasRoleModel {

    public HasPermissionsModel(NodePermission... permissions) {
        super(Stream.of(permissions).map(NodePermission::getId));
    }

    public HasPermissionsModel(Stream<NodePermission> permissions) {
        super(permissions.map(NodePermission::getId));
    }

}
