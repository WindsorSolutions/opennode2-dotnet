package com.windsor.node.service;

import java.util.Arrays;
import java.util.stream.Stream;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.LoginInfo;
import com.windsor.node.domain.NaasSyncInfo;
import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.domain.search.ActivitySort;
import com.windsor.node.repo.ActivityRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Activity service.
 */
@Service
@Transactional(readOnly = true)
public class ActivityServiceImpl extends AbstractCrudService<Activity, String, ActivitySearchCriteria, ActivitySort>
        implements ActivityService {

    @Autowired
    private ActivityRepository repository;

    @Override
    protected ICrudRepository<Activity, String, ActivitySearchCriteria, ActivitySort> getRepo() {
        return repository;
    }

	@Override
	public NaasSyncInfo findLastNaasSyncActivity() {
		return repository.findLastNaasSyncActivity();
	}

	@Override
	public LoginInfo findLastSuccessfulLoginActivity(Account account) {
		return repository.findLatestLoginInfo(1, account.getNaasAccount(), true)
				.findFirst()
				.orElse(null);
	}

	@Override
	public Stream<LoginInfo> findLatestLoginActivity(int count) {
		return repository.findLatestLoginInfo(count, null, null);
	}
	
	@Transactional(readOnly = false)
	@Override
	public void loginFailed(String emailAddress, String ipAddress) {
		Activity activity = new Activity(ActivityType.Error, ipAddress, Arrays.asList(
				String.format("Authentication attempt by: %s", emailAddress),
				"Error while authenticating: NAAS Error: Unable to authenticate the user"));
		repository.save(activity);
	}

	@Transactional(readOnly = false)
	@Override
	public void loginSuccessful(String emailAddress, String ipAddress) {
		Activity activity = new Activity(ActivityType.AdminAuth, ipAddress, Arrays.asList(
				String.format("Authentication attempt by: %s", emailAddress),
				"Result: Success"));
		repository.save(activity);
	}
	
	@Transactional(readOnly = false)
	@Override
	public void passwordChanged(String emailAddress, String result) {
		Activity activity = new Activity(ActivityType.Audit, null, Arrays.asList(
				String.format("User %s changed their password", emailAddress),
				String.format("Result: %s", result)));
		repository.save(activity);
	}

	@Transactional(readOnly = false)
	@Override
	public void userAdded(String emailAddress, String result, Account adminAccount) {
		Activity activity = new Activity(ActivityType.Audit, null, Arrays.asList(
				String.format("Admin user %s added user %s", adminAccount.getNaasAccount(), emailAddress),
				String.format("Result: %s", result)));
		repository.save(activity);
	}

	@Override
	public void passwordChanged(String emailAddress, String result, Account adminAccount) {
		Activity activity = new Activity(ActivityType.Audit, null, Arrays.asList(
				String.format("Admin user %s changed the password of user %s", adminAccount.getNaasAccount(), emailAddress),
				String.format("Result: %s", result)));
		repository.save(activity);
	}
	
}
