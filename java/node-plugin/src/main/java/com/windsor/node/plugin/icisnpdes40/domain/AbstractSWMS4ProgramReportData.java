package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.SWMS4ProgramReport;

/**
 * Specifies how to access address and contact info for {@link SWMS4ProgramReport}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractSWMS4ProgramReportData extends AbstractAddressContactEntity {

	@Transient
	public abstract SWMS4ProgramReport getSWMS4ProgramReport();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final SWMS4ProgramReport data = getSWMS4ProgramReport();
		if (data != null) {
			list = data.getStormWaterAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final SWMS4ProgramReport data = getSWMS4ProgramReport();
		if (data != null) {
			data.setStormWaterAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final SWMS4ProgramReport data = getSWMS4ProgramReport();
		if (data != null) {
			list = data.getStormWaterContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final SWMS4ProgramReport data = getSWMS4ProgramReport();
		if (data != null) {
			data.setStormWaterContact(null);
		}
	}

}
