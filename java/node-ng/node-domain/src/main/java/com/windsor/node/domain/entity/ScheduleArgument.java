package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.GenericGenerator;

import com.windsor.stack.domain.IEntity;

/**
 * Models an argument to a Service.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NScheduleSourceArg")
public class ScheduleArgument implements IEntity<String> {

    @Id
    @Column(name = "Id", nullable = false)
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    @GeneratedValue(generator = "uuid")
    private String id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "ScheduleId", nullable = false)
    private Schedule schedule;

    @Column(name = "ArgKey", nullable = false)
    private String key;

    @Column(name = "ArgValue", nullable = false)
    private String value;

    public ScheduleArgument() {
        this(null, null, null);
    }

    public ScheduleArgument(Schedule schedule, String key, String value) {
        super();
        this.schedule = schedule;
        this.key = key;
        this.value = value;
    }

    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Schedule getSchedule() {
        return schedule;
    }

    public void setSchedule(Schedule schedule) {
        this.schedule = schedule;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public ScheduleArgument value(String value) {
        setValue(value);
        return this;
    }

    @Override
    public boolean isNew() {
        return id == null;
    }
}
