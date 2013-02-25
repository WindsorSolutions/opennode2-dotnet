package com.windsor.node.plugin.wqx.domain;

import java.io.Serializable;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.persistence.Transient;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import org.apache.commons.lang3.StringUtils;

import com.windsor.node.plugin.wqx.domain.generated.ResultLabInformationDataType;
import com.windsor.node.plugin.wqx.domain.generated.WQXTimeDataType;

/**
 * Handles nulling out the resultLabInformation.analysisEndTime field if the TZ
 * is set but the time is not.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractResultDataType implements Serializable {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	/**
	 * Returns the result lab information.
	 *
	 * @return the result lab information
	 */
	@Transient
	public abstract ResultLabInformationDataType getResultLabInformation();

	/**
	 * Null out the result lab information end time field if the time is blank
	 * but the time-zone is not.
	 */
	@PostLoad
	public void fixAnalysisEndTime() {
		final ResultLabInformationDataType resultLabInformation = getResultLabInformation();
		if (resultLabInformation != null) {
			final WQXTimeDataType endTime = resultLabInformation.getAnalysisEndTime();
			if (endTime != null) {
				if (StringUtils.isBlank(endTime.getTime()) && endTime.getTimeZoneCode() != null) {
					resultLabInformation.setAnalysisEndTime(null);
				}
			}
		}
	}
}
