package com.windsor.node.domain;

import java.io.Serializable;
import java.time.LocalDateTime;

public class LoginInfo implements Serializable {

	private String activityId;
	private String email;
	private LocalDateTime loginDate;
	private boolean successful;
	
	public LoginInfo(String activityId, String email, LocalDateTime loginDate, boolean successful) {
		super();
		this.activityId = activityId;
		this.email = email;
		this.loginDate = loginDate;
		this.successful = successful;
	}
	
	public String getActivityId() {
		return activityId;
	}
	
	public String getEmail() {
		return email;
	}
	
	public LocalDateTime getLoginDate() {
		return loginDate;
	}
	
	public boolean isSuccessful() {
		return successful;
	}
	
}
