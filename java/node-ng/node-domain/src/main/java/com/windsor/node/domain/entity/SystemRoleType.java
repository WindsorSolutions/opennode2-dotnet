package com.windsor.node.domain.entity;

import java.util.Arrays;
import java.util.Collection;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import com.windsor.node.domain.NodeConstants;
import com.windsor.node.domain.NodePermission;
import com.windsor.stack.domain.IIdentifiable;

/**
 * Provides an enumeration of valid System Role Types.
 */
public enum SystemRoleType implements IIdentifiable<String> {
    None("None", true, NodeConstants.ROLE_TYPE_NONE, "Unprivileged Account",
            Arrays.asList(NodePermission.NONE_USER)),
    Authed("Authed", true, NodeConstants.ROLE_TYPE_NONE, "Authenticated Account",
            Arrays.asList(NodePermission.AUTHED_USER)),
    Program("Program", true, NodeConstants.ROLE_TYPE_NONE, "Program User",
            Arrays.asList(NodePermission.PROGRAM_USER)),
    Admin("Admin", true, NodeConstants.ROLE_TYPE_NONE, "System Administrator",
            Arrays.asList(NodePermission.ADMIN_USER)),
    Anonymous("Anonymous", true, NodeConstants.ROLE_TYPE_NONE, "Anonymous Account",
            Arrays.asList(NodePermission.ANONYMOUS_USER));

    public static final List<SystemRoleType> LOCAL_ROLES = Arrays.asList(Program, Admin);
    public static final Collection<SystemRoleType> NON_LOCAL_ROLES = Arrays.asList(Authed, None, Anonymous);

    public static final Comparator<SystemRoleType> ROLE_TYPE_NAME_COMPARATOR =
            (rt1, rt2) -> rt1.getName().compareTo(rt2.getName());

    private static final Map<String, SystemRoleType> ID_MAP = Stream.of(SystemRoleType.values())
            .collect(Collectors.toMap(SystemRoleType::getId, e -> e));

    private String id;
    private String name;
    private String description;
    private List<NodePermission> permissions;
    private boolean internal;

    SystemRoleType(String id, boolean internal, String name, String description, List<NodePermission> permissions) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.permissions = permissions;
        this.internal = internal;
    }

    @Override
    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getDescription() {
        return description;
    }

    public List<NodePermission> getPermissions() {
        return permissions;
    }

    public boolean isInternal() {
        return internal;
    }

    @Override
    public String toString() {
        return description;
    }

    public static Optional<SystemRoleType> findById(long id) {
        return Optional.ofNullable(ID_MAP.get(id));
    }

    public static Stream<SystemRoleType> getMatches(String term) {
        return Stream.of(values())
                .filter(dsp -> dsp.getDescription().toLowerCase().contains(term.toLowerCase()));
    }

    public boolean isLocalUser() {
        return LOCAL_ROLES.contains(this);
    }

    public boolean isAdmin() {
        return Admin.equals(this);
    }

}
