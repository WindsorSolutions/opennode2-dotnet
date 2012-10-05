package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import com.windsor.node.plugin.facid3.domain.generated.SICListDataType;

@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractFacilityDetailsDataType {

	@Transient
	public abstract com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType getNaicsList();

	public abstract void setNaicsList(com.windsor.node.plugin.facid3.domain.generated.NAICSListDataType naicsList);

	@Transient
	public abstract SICListDataType getSicList();

	public abstract void setSicList(SICListDataType sicList);

	@PostLoad
	public void nullEmptyEmbeddedFields() {

	}

}
