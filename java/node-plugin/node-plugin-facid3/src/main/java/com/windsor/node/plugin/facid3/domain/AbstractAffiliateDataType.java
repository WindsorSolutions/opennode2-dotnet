package com.windsor.node.plugin.facid3.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import com.windsor.node.plugin.facid3.domain.generated.AffiliateDataType;
import com.windsor.node.plugin.facid3.domain.generated.TelephonicListDataType;

/**
 * Superclass for {@link AffiliateDataType}.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractAffiliateDataType {

	/**
	 * Returns the telephonic list info.
	 *
	 * @return the telephonic list info
	 */
	@Transient
	public abstract TelephonicListDataType getTelephonicList();

	/**
	 * Sets the telephonic list info.
	 *
	 * @param telephonicList
	 *            the telephonic list info
	 */
	public abstract void setTelephonicList(TelephonicListDataType telephonicList);

	/**
	 * Nulls out @Embedded fields where the nested @Embeddable fields are null
	 * or empty.
	 */
	@PostLoad
	public void nullEmptyEmbeddedObjects() {
		TelephonicListDataType telephonicList = getTelephonicList();
		if (telephonicList != null
				&& (telephonicList.getTelephonic() == null || telephonicList.getTelephonic()
						.isEmpty())) {
			setTelephonicList(null);
		}
	}

}
