package com.windsor.node.repo;

import com.windsor.node.domain.entity.Plugin;
import com.windsor.node.domain.search.PluginSearchCriteria;
import com.windsor.node.domain.search.PluginSort;
import com.windsor.stack.domain.repo.ICrudRepository;
import org.springframework.data.jpa.repository.JpaRepository;

/**
 * Provides a repository for managing Plugin instances.
 */
public interface PluginRepository extends JpaRepository<Plugin, String>,
        ICrudRepository<Plugin, String, PluginSearchCriteria, PluginSort> {
}
