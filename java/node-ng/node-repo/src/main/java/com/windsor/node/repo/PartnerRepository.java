package com.windsor.node.repo;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSort;
import com.windsor.stack.domain.repo.ICrudRepository;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Provides a repository for managing Partner instances.
 */
public interface PartnerRepository extends JpaRepository<Partner, String>,
        ICrudRepository<Partner, String, PartnerSearchCriteria, PartnerSort> {

}
