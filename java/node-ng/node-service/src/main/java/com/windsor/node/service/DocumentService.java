package com.windsor.node.service;

import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.search.DocumentSearchCriteria;
import com.windsor.node.domain.search.DocumentSort;
import com.windsor.stack.domain.service.ICrudService;

/**
 * Provides a service for managing Document instances.
 */
public interface DocumentService extends ICrudService<Document, String, DocumentSearchCriteria, DocumentSort> {

}
