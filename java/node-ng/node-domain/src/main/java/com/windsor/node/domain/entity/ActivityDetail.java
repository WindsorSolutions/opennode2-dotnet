package com.windsor.node.domain.entity;

import java.time.LocalDateTime;

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
import org.springframework.data.annotation.LastModifiedDate;

import com.windsor.stack.domain.IEntity;

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NActivityDetail")
public class ActivityDetail implements IEntity<String> {

    @Id
    @GenericGenerator(name = "uuid", strategy = "uuid2")
    @GeneratedValue(generator = "uuid")
    @Column(name = "Id")
    private String id;

    @ManyToOne(optional = false)
    @JoinColumn(name = "ActivityId", nullable = false)
    private Activity activity;

    @Column(name = "Detail", nullable = false)
    private String detail;

    @Column(name = "OrderIndex")
    private Integer order;

    @LastModifiedDate
    @Column(name = "ModifiedOn")
    private LocalDateTime modifiedOn;

    public ActivityDetail() {
        super();
    }
    
    public ActivityDetail(Activity activity, Integer order, String detail) {
        super();
        this.activity = activity;
        this.order = order;
        this.detail = detail;
    }


    @Override
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Activity getActivity() {
        return activity;
    }

    public void setActivity(Activity activity) {
        this.activity = activity;
    }

    public String getDetail() {
        return detail;
    }

    public void setDetail(String detail) {
        this.detail = detail;
    }

    public Integer getOrder() {
        return order;
    }

    public void setOrder(Integer order) {
        this.order = order;
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

}
