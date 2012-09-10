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

	/**
	 * Returns the facility address object.
	 *
	 * @return the facility address object
	 */
	@Transient
	public abstract FacilityAddress getFacilityAddress();

	/**
	 * Sets the facility address object.
	 *
	 * @param address
	 *            facility address to set
	 */
	public abstract void setFacilityAddress(FacilityAddress address);

	/**
	 * Returns the facility contact object.
	 *
	 * @return the facility contact object
	 */
	@Transient
	public abstract FacilityContact getFacilityContact();

	/**
	 * Sets the facility contact object.
	 *
	 * @param contact
	 *            facility contact object to set
	 */
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
