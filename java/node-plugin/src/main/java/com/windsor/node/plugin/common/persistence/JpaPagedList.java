package com.windsor.node.plugin.common.persistence;

import java.io.Serializable;
import java.util.AbstractList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;
import javax.persistence.Query;

/**
 * {@link List} implementation, backed by JPA data and count queries, where the
 * data is materialized a page at a time. The class provides a method, which can
 * be overridden by a sub-class, that is called before a new page of data is
 * loaded into memory.
 *
 * @param <T>
 *            type of entities returned by the {@code dataQuery}
 */
public class JpaPagedList<T extends Serializable> extends AbstractList<T> {

	/**
	 * JPA {@link EntityManager} to use to execute queries.
	 */
	private final EntityManager em;

	/**
	 * JPA query that returns a {@List} of entities of type {@link T}.
	 */
	private String dataQuery;

	/**
	 * JPA count query that returns the number of items in the {@code dataQuery}
	 * .
	 */
	private String countQuery;

	/**
	 * Page of the data query currently in memory.
	 */
	private List<T> cache;

	/**
	 * The first index in the cache.
	 */
	private int cacheStart;

	/**
	 * Maximum cache size.
	 */
	private final int cacheSize;

	/**
	 * Total size of the list.
	 */
	private Integer size;

	/**
	 * Type of entity returned by the {@code dataQuery}.
	 */
	private final Class<T> entityClass;

    private final Map<String, Object> namedParameters = new HashMap<String, Object>();

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
	public JpaPagedList(final Class<T> entityClass, final EntityManager em, final String dataQuery,
			final String countQuery, final int cacheSize) {
		this.entityClass = entityClass;
		this.em = em;
		this.dataQuery = dataQuery;
		this.countQuery = countQuery;
		this.cacheSize = cacheSize;
	}

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
    public JpaPagedList(final Class<T> entityClass, final EntityManager em, final int cacheSize) {
        this.entityClass = entityClass;
        this.em = em;
        this.cacheSize = cacheSize;
    }

	@Override
	public final T get(final int index) {
		if (index > size()) {
			throw new IndexOutOfBoundsException();
		} else if (!(cache != null && index >= cacheStart && index < cacheStart + cache.size())) {
            cacheStart = (index / cacheSize) * cacheSize;

            Query q = em.createQuery(getDataQuery()).setFirstResult(cacheStart)
                    .setMaxResults(cacheSize);

            setNamedParameters(q);

            cache = q.getResultList();
		}
		return cache.get(index - cacheStart);
	}

	@Override
	public final int size() {
		if (size == null) {
		    Query q = em.createQuery(getCountQuery(), Long.class);
		    setNamedParameters (q);
		    size = ((Long) q.getSingleResult()).intValue();
		}
		return size;
	}

	private final Query setNamedParameters(Query q) {

	    if (!getNamedParameters().isEmpty()) {
	        for(String key : getNamedParameters().keySet()) {
	            q.setParameter(key, getNamedParameters().get(key));
	        }
	    }
	    return q;
	}

	protected String getDataQuery() {
	    return this.dataQuery;
	}

	protected String getCountQuery() {
	    return this.countQuery;
	}

	protected final void addNamedParameter(String name, Object value) {
	    this.namedParameters.put(name, value);
	}

	private Map<String, Object> getNamedParameters() {
	    return this.namedParameters;
	}

	protected final Class<T> getEntityClass() {
	    return this.entityClass;
	}

	/**
	 * Executed before the next page of data is loaded from the DB.
	 */
	protected void beforePageLoaded() { }

	/**
	 * Returns the {@link EntityManager} used to execute the queries.
	 *
	 * @return the {@link EntityManager} used to execute the queries
	 */
	protected EntityManager getEm() {
		return em;
	}

}
