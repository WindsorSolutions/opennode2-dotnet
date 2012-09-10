package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.CAFOPermit;

@MappedSuperclass
public abstract class AbstractCAFOPermitData extends AbstractAddressContactEntity {

	@Transient
	public abstract CAFOPermit getCAFOPermit();

	@Override
	@Transient
	public IAddressList getAddressList() {
		final CAFOPermit permit = getCAFOPermit();
		IAddressList addressList = null;
		if (permit != null) {
			addressList = permit.getCAFOAddress();
		}
		return addressList;
	}

	@Override
	public void nullAddress() {
		final CAFOPermit permit = getCAFOPermit();
		if (permit != null) {
			permit.setCAFOAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		final CAFOPermit permit = getCAFOPermit();
		IContactList contactList = null;
		if (permit != null) {
			contactList = permit.getCAFOContact();
		}
		return contactList;
	}

	@Override
	public void nullContact() {
		final CAFOPermit permit = getCAFOPermit();
		if (permit != null) {
			permit.setCAFOContact(null);
		}
	}

}
