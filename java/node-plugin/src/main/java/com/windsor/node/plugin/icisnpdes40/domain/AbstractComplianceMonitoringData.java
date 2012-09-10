package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.ComplianceMonitoring;

/**
 * {@link MappedSuperclass} for nulling out the address if there are no
 * associated address objects using a {@link PostLoad} handler.
 *
 */
@MappedSuperclass
public abstract class AbstractComplianceMonitoringData extends AbstractAddressContactEntity {

	@Transient
	public abstract ComplianceMonitoring getComplianceMonitoring();

	@Override
	@Transient
	public IContactList getContactList() {
		final ComplianceMonitoring monitoring = getComplianceMonitoring();
		IContactList contactList = null;
		if (monitoring != null) {
			contactList = monitoring.getInspectionContact();
		}
		return contactList;
	}

	@Override
	public void nullContact() {
		final ComplianceMonitoring monitoring = getComplianceMonitoring();
		if (monitoring != null) {
			monitoring.setInspectionContact(null);
		}
	}

}
