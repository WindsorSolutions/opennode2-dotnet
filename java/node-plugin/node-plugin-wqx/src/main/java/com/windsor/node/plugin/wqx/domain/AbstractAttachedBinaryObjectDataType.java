package com.windsor.node.plugin.wqx.domain;

import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.FetchType;
import javax.persistence.Lob;
import javax.persistence.MappedSuperclass;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlTransient;

/**
 * Provides access to the binary file data.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public class AbstractAttachedBinaryObjectDataType {

	/**
	 * Contents of the attached file.
	 */
	@XmlTransient
	private byte[] fileContents;

	/**
	 * Returns the content of the attached file.
	 *
	 * @return the content of the attached file
	 */
	@Lob
	@Basic(fetch = FetchType.LAZY)
	@Column(name = "BINARYOBJECTCONTENT")
	public byte[] getFileContents() {
		return fileContents;
	}

	/**
	 * Sets the content of the attached file.
	 *
	 * @param fileContents
	 *            the content of the attached file
	 */
	public void setFileContents(final byte[] fileContents) {
		this.fileContents = fileContents;
	}

}
