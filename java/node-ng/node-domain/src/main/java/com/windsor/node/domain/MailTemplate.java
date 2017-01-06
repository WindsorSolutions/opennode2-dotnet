package com.windsor.node.domain;

public enum MailTemplate {

	PASSWORD_CHANGED("Node Password Reset", "new_password.ftl"),
	NEW_USER("Node Account Creation", "new_user.ftl");
	
	private String subject;
	private String bodyTemplateName;
	
	MailTemplate(String subject, String bodyTemplateName) {
		this.subject = subject;
		this.bodyTemplateName = bodyTemplateName;
	}

	public String getSubject() {
		return subject;
	}

	public String getBodyTemplateName() {
		return bodyTemplateName;
	}
	
}
