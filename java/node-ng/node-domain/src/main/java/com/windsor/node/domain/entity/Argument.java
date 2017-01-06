package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.validation.constraints.Size;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.Type;

/**
 * Models a "global" argument in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NConfig")
public class Argument extends AbstractBaseEntity {

    @Size(min = 3, max = 255)
    @Column(name = "Name")
    private String name;

    @Size(max = 4000)
    @Column(name = "ConfigValue")
    private String value;

    @Size(max = 500)
    @Column(name = "Description")
    private String description;

    @Type(type = "yes_no")
    @Column(name = "IsEditable")
    private Boolean editable;

    public Argument() {
        this.editable = false;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isEditable() {
        return editable;
    }

    public void setEditable(boolean editable) {
        this.editable = editable;
    }
}
