package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.GeneralPermit;

/**
 * Specifies how to access address and contact info for {@link GeneralPermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractGeneralPermitData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link GeneralPermit} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link GeneralPermit} object
	 */
	@Transient
	public abstract GeneralPermit getGeneralPermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final GeneralPermit permit = getGeneralPermit();
		if (permit != null) {
			list = permit.getPermitAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final GeneralPermit permit = getGeneralPermit();
		if (permit != null) {
			permit.setPermitAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final GeneralPermit permit = getGeneralPermit();
		if (permit != null) {
			list = permit.getPermitContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final GeneralPermit permit = getGeneralPermit();
		if (permit != null) {
			permit.setPermitContact(null);
		}
	}

}
