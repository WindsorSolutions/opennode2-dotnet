package com.windsor.node.plugin.common.persistence;

import java.io.Serializable;
import java.util.List;

import javax.persistence.EntityManager;

/**
 * Extension of {@link JpaPagedList}, which only keeps a single page of data in
 * the cache at a time.
 *
 * @param <T>
 *            type of entity returned by the {@code dataQuery}
 */
public class ClearingJpaPagedList<T extends Serializable> extends JpaPagedList<T> {

	/**
	 * Constructor.
	 *
	 * @param entityClass
	 *            type of entity returned by the {@code dataQuery}
	 * @param em
	 *            {@link EntityManager} to use to execute the queries
	 * @param dataQuery
	 *            JPA query which returns the entities in the {@link List}
	 * @param countQuery
	 *            JPA query which returns the total number of entities in the
	 *            {@link List}
	 * @param cacheSize
	 *            maximum number of entities to load at a time
	 */
	public ClearingJpaPagedList(final Class<T> entityClass, final EntityManager em,
			final String dataQuery, final String countQuery, final int cacheSize) {
		super(entityClass, em, dataQuery, countQuery, cacheSize);
	}

	/*
	 * Clears the {@link EntityManager} first-level cache. (non-Javadoc)
	 *
	 * @see
	 * com.windsor.node.plugin.common.persistence.JpaPagedList#beforePageLoaded
	 * ()
	 */
	@Override
	protected void beforePageLoaded() {
		getEm().clear();
	}

}
