package com.windsor.node.plugin.wqx.domain;

import javax.persistence.MappedSuperclass;
import javax.persistence.PostLoad;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;

import com.windsor.node.plugin.wqx.domain.generated.ActivityDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.generated.WQXTimeDataType;

/**
 * Handles nulling out the activityDescription.activityEndTime field if the TZ
 * is set but the time is not.
 *
 */
@XmlAccessorType(XmlAccessType.FIELD)
@MappedSuperclass
public abstract class AbstractActivityDataType extends TopLevelEntity {

	/**
	 * Serialization version.
	 */
	private static final long serialVersionUID = 1L;

	/**
	 * Returns the description of the activity.
	 *
	 * @return the description of the activity
	 */
	public abstract ActivityDescriptionDataType getActivityDescription();

	/**
	 * Null out the activity description end time field if the time is null but
	 * the time-zone is not.
	 */
	@PostLoad
	public void fixActivityEndTime() {
		final ActivityDescriptionDataType activityDescription = getActivityDescription();
		if (activityDescription != null) {
			final WQXTimeDataType endTime = activityDescription.getActivityEndTime();
			if (endTime != null) {
				if (endTime.getTime() == null && endTime.getTimeZoneCode() != null) {
					activityDescription.setActivityEndTime(null);
				}
			}
		}
	}

}
