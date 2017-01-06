package com.windsor.node.domain;

import java.io.Serializable;
import java.time.LocalDateTime;

public class NaasSyncInfo implements Serializable {

	private String activityId;
	private LocalDateTime syncDate;
	private boolean successful;
	
	public NaasSyncInfo(String activityId, LocalDateTime syncDate, boolean successful) {
		super();
		this.activityId = activityId;
		this.syncDate = syncDate;
		this.successful = successful;
	}

	public String getActivityId() {
		return activityId;
	}

	public LocalDateTime getSyncDate() {
		return syncDate;
	}

	public boolean isSuccessful() {
		return successful;
	}
	
}
