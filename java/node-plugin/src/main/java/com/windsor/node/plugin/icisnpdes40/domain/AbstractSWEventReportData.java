package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.SWEventReport;

/**
 * Specifies how to access address and contact info for {@link SWEventReport}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractSWEventReportData extends AbstractAddressContactEntity {

	/**
	 * Returns the {@link SWEventReport} object. The generated class will
	 * override this method.
	 *
	 * @return the {@link SWEventReport object
	 */
	@Transient
	public abstract SWEventReport getSWEventReport();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final SWEventReport report = getSWEventReport();
		if (report != null) {
			list = report.getStormWaterAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final SWEventReport report = getSWEventReport();
		if (report != null) {
			report.setStormWaterAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final SWEventReport report = getSWEventReport();
		if (report != null) {
			list = report.getStormWaterContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final SWEventReport report = getSWEventReport();
		if (report != null) {
			report.setStormWaterContact(null);
		}
	}

}
