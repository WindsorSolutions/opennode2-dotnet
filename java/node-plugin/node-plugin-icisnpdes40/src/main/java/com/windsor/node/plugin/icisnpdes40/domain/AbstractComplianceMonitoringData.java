package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.ComplianceMonitoring;

/**
 * Specifies how to access contact info for {@link ComplianceMonitoring} data.
 *
 */
@MappedSuperclass
public abstract class AbstractComplianceMonitoringData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link ComplianceMonitoring} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link ComplianceMonitoring} object
	 */
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
