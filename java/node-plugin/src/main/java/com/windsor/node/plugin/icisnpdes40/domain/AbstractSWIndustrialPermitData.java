package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.SWIndustrialPermit;

/**
 * Specifies how to access address and contact info for {@link SWIndustrialPermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractSWIndustrialPermitData extends AbstractAddressContactEntity {

	@Transient
	public abstract SWIndustrialPermit getSWIndustrialPermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final SWIndustrialPermit permit = getSWIndustrialPermit();
		if (permit != null) {
			list = permit.getStormWaterAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final SWIndustrialPermit permit = getSWIndustrialPermit();
		if (permit != null) {
			permit.setStormWaterAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final SWIndustrialPermit permit = getSWIndustrialPermit();
		if (permit != null) {
			list = permit.getStormWaterContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final SWIndustrialPermit permit = getSWIndustrialPermit();
		if (permit != null) {
			permit.setStormWaterContact(null);
		}
	}

}
