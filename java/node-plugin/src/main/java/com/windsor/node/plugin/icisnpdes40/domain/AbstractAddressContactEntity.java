package com.windsor.node.plugin.icisnpdes40.domain;

import java.util.List;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;

@MappedSuperclass
public abstract class AbstractAddressContactEntity {

	@Transient
	public IAddressList getAddressList() {
		return null;
	}

	public void nullAddress() {

	}

	@Transient
	public IContactList getContactList() {
		return null;
	}

	public void nullContact() {

	}


	@PostLoad
	public void handlePostLoad() {
		handleAddressPostLoad();
		handleContactPostLoad();
	}

	protected void handleAddressPostLoad() {
		final IAddressList addresses = getAddressList();
		if (addresses != null) {
			final List<?> list = addresses.getAddress();
			if (list == null || list.isEmpty()) {
				nullAddress();
			}
		}
	}

	protected void handleContactPostLoad() {
		final IContactList contacts = getContactList();
		if (contacts != null) {
			final List<?> list = contacts.getContact();
			if (list == null || list.isEmpty()) {
				nullContact();
			}
		}
	}

}
