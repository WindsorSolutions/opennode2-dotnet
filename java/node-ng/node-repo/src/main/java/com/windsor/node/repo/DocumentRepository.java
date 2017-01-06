package com.windsor.node.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.search.DocumentSearchCriteria;
import com.windsor.node.domain.search.DocumentSort;
import com.windsor.stack.domain.repo.ICrudRepository;

/**
 * Provides a repository for managing Document instances.
 */
public interface DocumentRepository extends JpaRepository<Document, String>,
        ICrudRepository<Document, String, DocumentSearchCriteria, DocumentSort> {

}
