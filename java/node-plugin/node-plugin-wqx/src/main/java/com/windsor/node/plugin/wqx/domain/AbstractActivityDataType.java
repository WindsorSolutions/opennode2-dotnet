package com.windsor.node.plugin.wqx.domain;

import javax.persistence.PostLoad;

import com.windsor.node.plugin.wqx.domain.generated.ActivityDescriptionDataType;
import com.windsor.node.plugin.wqx.domain.generated.WQXTimeDataType;

/**
 * Handles nulling out the activityDescription.activityEndTime field if the TZ
 * is set but the time is not.
 *
 */
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
	 * Sets the description of the activity.
	 *
	 * @param activityDescriptionType
	 *            the description of the activity
	 */
	public abstract void getActivityDescription(ActivityDescriptionDataType activityDescriptionType);

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
