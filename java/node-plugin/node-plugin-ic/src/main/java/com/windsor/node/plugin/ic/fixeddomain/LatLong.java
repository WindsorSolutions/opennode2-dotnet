package com.windsor.node.plugin.ic.fixeddomain;

import java.io.Serializable;
import java.math.BigDecimal;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Inheritance;
import javax.persistence.InheritanceType;
import javax.persistence.Table;
import javax.persistence.Transient;

@Entity(name = "LatLong")
@Table(name = "IC_LAT_LON_POLYGON")
@Inheritance(strategy = InheritanceType.JOINED)
public class LatLong implements Serializable
{
    private static final long serialVersionUID = 1L;
    protected BigDecimal lattitude;
    protected BigDecimal longitude;
    protected String dbid;

    @Basic
    @Column(name = "LAT", precision = 19, scale = 14)
    public BigDecimal getLattitude()
    {
        return lattitude;
    }
    public void setLattitude(BigDecimal lattitude)
    {
        this.lattitude = lattitude;
    }
    @Transient
    public boolean isSetLattitude()
    {
        return lattitude != null;
    }
    @Basic
    @Column(name = "LON", precision = 19, scale = 14)
    public BigDecimal getLongitude()
    {
        return longitude;
    }
    public void setLongitude(BigDecimal longitude)
    {
        this.longitude = longitude;
    }
    @Transient
    public boolean isSetLongitude()
    {
        return longitude != null;
    }
    @Id
    @Column(name = "IC_LAT_LON_POLYGON_ID")
    public String getDbid()
    {
        return dbid;
    }
    public void setDbid(String dbid)
    {
        this.dbid = dbid;
    }
    @Override
    public int hashCode()
    {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((dbid == null) ? 0 : dbid.hashCode());
        result = prime * result + ((lattitude == null) ? 0 : lattitude.hashCode());
        result = prime * result + ((longitude == null) ? 0 : longitude.hashCode());
        return result;
    }
    @Override
    public boolean equals(Object obj)
    {
        if(this == obj)
            return true;
        if(obj == null)
            return false;
        if(getClass() != obj.getClass())
            return false;
        LatLong other = (LatLong)obj;
        if(dbid == null)
        {
            if(other.dbid != null)
                return false;
        }
        else if(!dbid.equals(other.dbid))
            return false;
        if(lattitude == null)
        {
            if(other.lattitude != null)
                return false;
        }
        else if(!lattitude.equals(other.lattitude))
            return false;
        if(longitude == null)
        {
            if(other.longitude != null)
                return false;
        }
        else if(!longitude.equals(other.longitude))
            return false;
        return true;
    }
}
