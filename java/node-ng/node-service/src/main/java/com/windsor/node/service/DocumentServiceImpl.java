package com.windsor.node.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.search.DocumentSearchCriteria;
import com.windsor.node.domain.search.DocumentSort;
import com.windsor.node.repo.DocumentRepository;
import com.windsor.stack.domain.repo.ICrudRepository;
import com.windsor.stack.domain.service.AbstractCrudService;

/**
 * Provides an implementation of the Document service.
 */
@Service
@Transactional(readOnly = true)
public class DocumentServiceImpl extends AbstractCrudService<Document, String, DocumentSearchCriteria, DocumentSort>
        implements DocumentService {

    @Autowired
    private DocumentRepository repository;

    @Override
    protected ICrudRepository<Document, String, DocumentSearchCriteria, DocumentSort> getRepo() {
        return repository;
    }
}
