package com.windsor.node.service;

import java.util.stream.Stream;

import com.windsor.node.domain.LoginInfo;
import com.windsor.node.domain.NaasSyncInfo;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.domain.search.ActivitySort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Argument instances.
 */
public interface ActivityService extends ICrudService<Activity, String, ActivitySearchCriteria, ActivitySort> {

	NaasSyncInfo findLastNaasSyncActivity();
	
	LoginInfo findLastSuccessfulLoginActivity(Account account);
	
	Stream<LoginInfo> findLatestLoginActivity(int count);
	
	void loginFailed(String emailAddress, String ipAddress);
	
	void loginSuccessful(String emailAddress, String ipAddress);
	
	void passwordChanged(String emailAddress, String result);
	
	void passwordChanged(String emailAddress, String result, Account adminAccount);
	
	void userAdded(String emailAddress, String result, Account adminAccount);
	
}
