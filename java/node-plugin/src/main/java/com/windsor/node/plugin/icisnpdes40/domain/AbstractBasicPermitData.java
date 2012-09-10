package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.BasicPermit;

/**
 * Specifies how to access address and contact info for {@link BasicPermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractBasicPermitData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link BasicPermit} object. The generated class will override
	 * this method.
	 *
	 * @return the {@link BasicPermit} object
	 */
	@Transient
	public abstract BasicPermit getBasicPermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final BasicPermit permit = getBasicPermit();
		if (permit != null) {
			list = permit.getPermitAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final BasicPermit permit = getBasicPermit();
		if (permit != null) {
			permit.setPermitAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final BasicPermit permit = getBasicPermit();
		if (permit != null) {
			list = permit.getPermitContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final BasicPermit permit = getBasicPermit();
		if (permit != null) {
			permit.setPermitContact(null);
		}
	}

}
