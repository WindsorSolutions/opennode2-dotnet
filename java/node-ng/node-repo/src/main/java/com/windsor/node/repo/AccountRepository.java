package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.domain.search.AccountSearchCriteria;
import com.windsor.node.domain.search.AccountSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Account instances.
 */
public interface AccountRepository extends JpaRepository<Account, String>,
        ICrudRepository<Account, String, AccountSearchCriteria, AccountSort> {

	/*
	 * A new transaction is required to prevent Hibernate/Spring Data
	 * from going into an infinite loop when fetching the system user
	 * as the auditor in writitng a login failure activity.
	 * See http://stackoverflow.com/questions/14223649/how-to-implement-auditoraware-with-spring-data-jpa-and-spring-security 
	 */
	@Transactional(propagation = Propagation.REQUIRES_NEW)
	@Query("select account from Account account where account.naasAccount = ?1")
	Account findByEmail(String email);
	
}
