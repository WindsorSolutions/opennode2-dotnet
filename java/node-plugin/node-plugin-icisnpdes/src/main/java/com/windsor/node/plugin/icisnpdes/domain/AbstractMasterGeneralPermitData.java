package com.windsor.node.plugin.icisnpdes.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes.generated.MasterGeneralPermit;

/**
 * Specifies how to access contact info for {@link MasterGeneralPermit} data.
 *
 */
@MappedSuperclass
public abstract class AbstractMasterGeneralPermitData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link MasterGeneralPermit} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link MasterGeneralPermit} object
	 */
	@Transient
	public abstract MasterGeneralPermit getMasterGeneralPermit();

	@Override
	@Transient
	public IContactList getContactList() {
		final MasterGeneralPermit permit = getMasterGeneralPermit();
		IContactList contactList = null;
		if (permit != null) {
			contactList = permit.getPermitContact();
		}
		return contactList;
	}

	@Override
	public void nullContact() {
		final MasterGeneralPermit permit = getMasterGeneralPermit();
		if (permit != null) {
			permit.setPermitContact(null);
		}
	}

}
