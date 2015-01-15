package com.windsor.node.plugin.icisnpdes.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes.generated.PretreatmentPermit;

/**
 * Specifies how to access contact info for {@link PretreatmentPermit} data.
 *
 */
@MappedSuperclass
public abstract class AbstractPretreatmentPermitData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link PretreatmentPermit} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link PretreatmentPermit} object
	 */
	@Transient
	public abstract PretreatmentPermit getPretreatmentPermit();

	@Override
	@Transient
	public IContactList getContactList() {
		final PretreatmentPermit permit = getPretreatmentPermit();
		IContactList contactList = null;
		if (permit != null) {
			contactList = permit.getPretreatmentContact();
		}
		return contactList;
	}

	@Override
	public void nullContact() {
		final PretreatmentPermit permit = getPretreatmentPermit();
		if (permit != null) {
			permit.setPretreatmentContact(null);
		}
	}

}
