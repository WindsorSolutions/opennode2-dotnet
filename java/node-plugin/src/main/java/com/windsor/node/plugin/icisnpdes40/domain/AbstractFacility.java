package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.Facility;
import com.windsor.node.plugin.icisnpdes40.generated.FacilityAddress;
import com.windsor.node.plugin.icisnpdes40.generated.FacilityContact;

/**
 * Specifies how to access address and contact info for {@link Facility} data.
 *
 */
@MappedSuperclass
public abstract class AbstractFacility extends AbstractAddressContactEntity {

	@Transient
	public abstract FacilityAddress getFacilityAddress();

	public abstract void setFacilityAddress(FacilityAddress address);

	@Transient
	public abstract FacilityContact getFacilityContact();

	public abstract void setFacilityContact(FacilityContact contact);

	@Override
	@Transient
	public IAddressList getAddressList() {
		return getFacilityAddress();
	}

	@Override
	public void nullAddress() {
		setFacilityAddress(null);
	}

	@Override
	@Transient
	public IContactList getContactList() {
		return getFacilityContact();
	}

	@Override
	public void nullContact() {
		setFacilityContact(null);
	}

}
