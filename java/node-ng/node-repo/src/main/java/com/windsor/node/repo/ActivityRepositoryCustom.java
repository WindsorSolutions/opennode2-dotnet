package com.windsor.node.repo;

import java.util.stream.Stream;

import com.windsor.node.domain.LoginInfo;
import com.windsor.node.domain.NaasSyncInfo;

public interface ActivityRepositoryCustom {

	NaasSyncInfo findLastNaasSyncActivity();
	
	Stream<LoginInfo> findLatestLoginInfo(int count, String email, Boolean successful);
	
}
