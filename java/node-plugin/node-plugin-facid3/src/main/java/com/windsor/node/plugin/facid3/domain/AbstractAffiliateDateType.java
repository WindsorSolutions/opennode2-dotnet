package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import com.windsor.node.plugin.facid3.domain.generated.TelephonicListDataType;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractAffiliateDateType {

	public abstract TelephonicListDataType getTelephonicList();

    public abstract void setTelephonicList(TelephonicListDataType telephonicList);

    @PostLoad
    public void nullEmptyEmbeddedObjects() {
    	TelephonicListDataType telephonicList = getTelephonicList();
    	if (telephonicList != null && (telephonicList.getTelephonic() == null || telephonicList.getTelephonic().isEmpty())) {
    		setTelephonicList(null);
    	}
    }

}
