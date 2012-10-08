package com.windsor.node.plugin.wqx.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity
@Table(name = "WQX_DELETES")
public class DeleteComponentIdentifier extends TopLevelEntity implements Serializable {

    private static final long serialVersionUID = 1L;

    private String dbId;

    private String component;

    private String identifier;

    @Transient
    public Component getComponentAsEnum() {
        for (Component c : Component.values()) {
            if (c.componentName().equalsIgnoreCase(this.component)) {
                return c;
            }
        }
        return null;
    };

    @Id
    @Column(name = "RECORDID", length = 50)
    public String getDbId() {
        return dbId;
    }

    public void setDbId(String dbId) {
        this.dbId = dbId;
    }

    @Column(name = "COMPONENT", length = 50)
    public String getComponent() {
        return this.component;
    }

    public void setComponent(String component) {
        this.component = component;
    }

    @Column(name = "IDENTIFIER", length = 50)
    public String getIdentifier() {
        return this.identifier;
    }

    public void setIdentifier(String identifier) {
        this.identifier = identifier;
    }
}
