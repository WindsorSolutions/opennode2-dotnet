package com.windsor.node.domain.entity;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Cacheable;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;
import org.hibernate.annotations.NotFound;
import org.hibernate.annotations.NotFoundAction;

/**
 * Models an activity in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NActivity")
public class Activity extends AbstractBaseEntity {

    @Enumerated(EnumType.STRING)
    @Column(name = "ActivityType", nullable = false)
    private ActivityType type;

    @NotFound(action = NotFoundAction.IGNORE)
    @ManyToOne
    @JoinColumn(name = "TransactionId")
    private Transaction transaction;

    @Column(name = "IP")
    private String ipAddress;

    @OneToMany(mappedBy = "activity", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ActivityDetail> details;

    public Activity() {
        super();
    }
    
    public Activity(ActivityType type, String ipAddress, List<String> details) {
        super();
        this.type = type;
        this.ipAddress = ipAddress;
        this.details = new ArrayList<>();
        if (details != null) {
        	for (int i = 0; i < details.size(); i++) {
        		this.details.add(new ActivityDetail(this, i + 1, details.get(i)));
        	}
        }
    }

    public ActivityType getType() {
        return type;
    }

    public void setType(ActivityType type) {
        this.type = type;
    }

    public Transaction getTransaction() {
        return transaction;
    }

    public void setTransaction(Transaction transaction) {
        this.transaction = transaction;
    }

    public String getIpAddress() {
        return ipAddress;
    }

    public void setIpAddress(String ipAddress) {
        this.ipAddress = ipAddress;
    }

    public List<ActivityDetail> getDetails() {
        return details;
    }

    public void setDetails(List<ActivityDetail> details) {
        this.details = details;
    }

    public boolean hasDocuments() {
        return transaction != null && getTransaction().hasDocuments();
    }
}
