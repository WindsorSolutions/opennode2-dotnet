package com.windsor.node.plugin.icisnpdes40.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.Transient;

import com.windsor.node.plugin.icisnpdes40.generated.BiosolidsPermit;
import com.windsor.node.plugin.icisnpdes40.generated.PermittedFeature;

/**
 * Specifies how to access address and contact info for {@link BiosolidsPermit}
 * data.
 *
 */
@MappedSuperclass
public abstract class AbstractPermittedFeatureData extends AbstractAddressContactEntity {

	@Transient
	public abstract PermittedFeature getPermittedFeature();

	@Override
	@Transient
	public IAddressList getAddressList() {
		IAddressList list = null;
		final PermittedFeature feature = getPermittedFeature();
		if (feature != null) {
			list = feature.getSiteOwnerAddress();
		}
		return list;
	}

	@Override
	public void nullAddress() {
		final PermittedFeature feature = getPermittedFeature();
		if (feature != null) {
			feature.setSiteOwnerAddress(null);
		}
	}

	@Override
	@Transient
	public IContactList getContactList() {
		IContactList list = null;
		final PermittedFeature feature = getPermittedFeature();
		if (feature != null) {
			list = feature.getSiteOwnerContact();
		}
		return list;
	}

	@Override
	public void nullContact() {
		final PermittedFeature feature = getPermittedFeature();
		if (feature != null) {
			feature.setSiteOwnerContact(null);
		}
	}

}
