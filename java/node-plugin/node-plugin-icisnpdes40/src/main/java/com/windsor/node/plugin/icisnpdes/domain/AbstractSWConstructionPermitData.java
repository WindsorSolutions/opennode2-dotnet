package com.windsor.node.plugin.icisnpdes.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes.generated.SWConstructionPermit;

/**
 * Specifies how to access address and contact info for
 * {@link SWConstructionPermit} data.
 *
 */
@MappedSuperclass
public abstract class AbstractSWConstructionPermitData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link SWConstructionPermit} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link SWConstructionPermit} object
	 */
	@Transient
	public abstract SWConstructionPermit getSWConstructionPermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final SWConstructionPermit permit = getSWConstructionPermit();
		if (permit != null) {
			list = permit.getStormWaterAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final SWConstructionPermit permit = getSWConstructionPermit();
		if (permit != null) {
			permit.setStormWaterAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final SWConstructionPermit permit = getSWConstructionPermit();
		if (permit != null) {
			list = permit.getStormWaterContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final SWConstructionPermit permit = getSWConstructionPermit();
		if (permit != null) {
			permit.setStormWaterContact(null);
		}
	}

}
