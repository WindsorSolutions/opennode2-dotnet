package com.windsor.node.domain.entity;

import java.time.LocalDateTime;

import javax.persistence.Column;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.MappedSuperclass;

import org.hibernate.annotations.GenericGenerator;
import org.hibernate.annotations.NotFound;
import org.hibernate.annotations.NotFoundAction;
import org.springframework.data.annotation.LastModifiedBy;
import org.springframework.data.annotation.LastModifiedDate;

import com.windsor.stack.domain.IEntity;

/**
 * Base class for all database entities; these fields and methods are common to all entities.
 */
@MappedSuperclass
public class AbstractBaseEntity implements IEntity<String> {

    public static final String FIELD_ID = "id";

    @Id
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    @GeneratedValue(generator = "uuid")
    @Column(name = "Id")
    private String id;

    @NotFound(action = NotFoundAction.IGNORE)
    @LastModifiedBy
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "ModifiedBy")
    private Account modifiedBy;

    @LastModifiedDate
    @Column(name = "ModifiedOn")
    private LocalDateTime modifiedOn;

    public AbstractBaseEntity() {
        super();
    }

    public AbstractBaseEntity(String id) {
        this();
        this.id = id;
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Account getModifiedBy() {
        return modifiedBy;
    }

    public void setModifiedBy(Account modifiedBy) {
        this.modifiedBy = modifiedBy;
    }

    public LocalDateTime getModifiedOn() {
        return modifiedOn;
    }

    public void setModifiedOn(LocalDateTime modifiedOn) {
        this.modifiedOn = modifiedOn;
    }

    @Override
    public boolean isNew() {
        return id == null;
    }

    @Override
    public boolean equals(Object obj) {

        if (this == obj) {
            return true;
        }

        if (obj == null || (!getClass().isAssignableFrom(obj.getClass()))) {
            return false;
        }

        AbstractBaseEntity other = (AbstractBaseEntity) obj;
        return getId() != null && getId().equals(other.getId());
    }

    @Override
    public int hashCode() {
        return getId() == null ? 0 : getId().hashCode();
    }
}
