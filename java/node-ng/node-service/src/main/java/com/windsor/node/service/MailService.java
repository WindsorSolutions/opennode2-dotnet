package com.windsor.node.service;

import java.util.Map;

import com.windsor.node.domain.MailTemplate;
import com.windsor.node.domain.entity.Account;

public interface MailService {

	void send(Account account, MailTemplate template, Map<String, String> properties);
	
}
