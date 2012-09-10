package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.BiosolidsPermit;
import com.windsor.node.plugin.icisnpdes40.generated.UnpermittedFacility;

/**
 * Specifies how to access address and contact info for {@link BiosolidsPermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractUnpermittedFacilityData extends AbstractAddressContactEntity {

	@Transient
	public abstract UnpermittedFacility getUnpermittedFacility();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final UnpermittedFacility facility = getUnpermittedFacility();
		if (facility != null) {
			list = facility.getFacilityAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final UnpermittedFacility facility = getUnpermittedFacility();
		if (facility != null) {
			facility.setFacilityAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final UnpermittedFacility facility = getUnpermittedFacility();
		if (facility != null) {
			list = facility.getFacilityContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final UnpermittedFacility facility = getUnpermittedFacility();
		if (facility != null) {
			facility.setFacilityContact(null);
		}
	}

}
