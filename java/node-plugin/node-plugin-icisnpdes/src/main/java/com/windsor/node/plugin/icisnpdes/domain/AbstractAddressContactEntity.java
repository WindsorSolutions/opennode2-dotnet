package com.windsor.node.plugin.icisnpdes.domain;

import java.util.List;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

/**
 * Class for handling nulling out the address or contact fields when their lists
 * are null or empty.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractAddressContactEntity {

	/**
	 * Returns the address list.
	 *
	 * @return the address list.
	 */
	@Transient
	public IAddressList getAddressList() {
		return null;
	}

	/**
	 * Sets the address field to null.
	 */
	public void nullAddress() {

	}

	/**
	 * Returns the contact list.
	 *
	 * @return the contact list
	 */
	@Transient
	public IContactList getContactList() {
		return null;
	}

	/**
	 * Sets the contact field to null.
	 */
	public void nullContact() {

	}

	/**
	 * After the data is loaded, checks whether the contact and/or address field
	 * needs to be nulled out, based on the whether there are indeed any
	 * addresses or contacts.
	 */
	@PostLoad
	public void handlePostLoad() {
		handleAddressPostLoad();
		handleContactPostLoad();
	}

	/**
	 * Nulls out the address field if there are no addresses in the list.
	 */
	protected void handleAddressPostLoad() {
		final IAddressList addresses = getAddressList();
		if (addresses != null) {
			final List<?> list = addresses.getAddress();
			if (list == null || list.isEmpty()) {
				nullAddress();
			}
		}
	}

	/**
	 * Nulls out the contact field if there are no contacts in the list.
	 */
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
