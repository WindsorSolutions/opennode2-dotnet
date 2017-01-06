package com.windsor.node.domain.search;

import com.windsor.stack.domain.search.IEntityRelated;

/**
 * Provides an enunmeration of Plugin fields that may be sorted.
 */
public enum PluginSort implements IEntityRelated {

    ID(EntityAlias.PLUGIN),
    EXCHANGE(EntityAlias.PLUGIN),
    VERSION(EntityAlias.PLUGIN);

    private Object entityAlias;

    PluginSort(Object entityAlias) {
        this.entityAlias = entityAlias;
    }

    @Override
    public Object getEntityAlias() {
        return entityAlias;
    }
}
