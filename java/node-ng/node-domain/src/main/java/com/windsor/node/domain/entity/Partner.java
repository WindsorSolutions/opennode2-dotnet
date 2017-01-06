package com.windsor.node.domain.entity;

import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.validation.constraints.Size;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;

/**
 * Models a network partner in the system.
 */
@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NPartner")
public class Partner extends AbstractBaseEntity {

    @Size(min = 3, max = 500)
    @Column(name = "Name")
    private String name;

    @Size(min = 3, max = 500)
    @Column(name = "Url")
    private String url;

    @Column(name = "Version")
    private PartnerVersion version;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public PartnerVersion getVersion() {
        return version;
    }

    public void setVersion(PartnerVersion version) {
        this.version = version;
    }
}
