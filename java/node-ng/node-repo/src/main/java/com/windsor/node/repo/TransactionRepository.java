package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.Transaction;

/**
 * Provides a repository for managing Transaction instances.
 */
public interface TransactionRepository extends JpaRepository<Transaction, String> {

}
