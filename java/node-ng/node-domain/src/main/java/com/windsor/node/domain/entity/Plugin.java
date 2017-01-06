package com.windsor.node.domain.entity;

import javax.persistence.Basic;
import javax.persistence.Cacheable;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.hibernate.annotations.Cache;
import org.hibernate.annotations.CacheConcurrencyStrategy;

@Entity
@Cacheable
@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NPlugin")
public class Plugin extends AbstractBaseEntity {

    @ManyToOne(optional = false)
    @JoinColumn(name = "FlowId")
    private Exchange exchange;

    @Lob
    @Basic(fetch = FetchType.LAZY)
    @Column(name = "PluginContent", nullable = false)
    private byte[] content;

    @Column(name = "BinaryVersion")
    private String version;

    public Plugin() {
        super();
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public byte[] getContent() {
        return content;
    }

    public void setContent(byte[] content) {
        this.content = content;
    }

    public String getVersion() {
        return version;
    }

    public void setVersion(String version) {
        this.version = version;
    }

}
