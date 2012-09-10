package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.SWMS4LargePermit;

/**
 * Specifies how to access address and contact info for {@link SWMS4LargePermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractSWMS4LargePermitData extends AbstractAddressContactEntity {

	@Transient
	public abstract SWMS4LargePermit getSWMS4LargePermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final SWMS4LargePermit permit = getSWMS4LargePermit();
		if (permit != null) {
			list = permit.getStormWaterAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final SWMS4LargePermit permit = getSWMS4LargePermit();
		if (permit != null) {
			permit.setStormWaterAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final SWMS4LargePermit permit = getSWMS4LargePermit();
		if (permit != null) {
			list = permit.getStormWaterContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final SWMS4LargePermit permit = getSWMS4LargePermit();
		if (permit != null) {
			permit.setStormWaterContact(null);
		}
	}

}
