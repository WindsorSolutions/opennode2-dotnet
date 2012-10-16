package com.windsor.node.plugin.common.persistence;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

/**
 * Patterned off of Spring Data <a
 * href="http://static.springsource.org/spring-data
 * /data-jpa/docs/current/api/org/
 * springframework/data/jpa/domain/Specification.html">Specification</a>.
 * <p/>
 *
 * The process of using a criteria factory has three steps:
 * <ol>
 * <li>Instantiate a criteria factory.</li>
 * <li>Set the data on the factory using either the {@code setData} or
 * {@code setUntypedData} methods.</li>
 * <li>Create a {@link Predicate} object from the factory using the
 * {@code create} method.</li>
 * </ol>
 *
 * @param <DATA>
 *            Type of the data being fed into the factory and which is used in
 *            some way for creating the {@link Predicate}
 * @param <ROOT>
 *            Type of the query root
 */
public interface CriteriaFactory<DATA, ROOT> {

	/**
	 * Creates a {@link Predicate} from the parameters and the data.
	 *
	 * @param root
	 *            {@link Root} of the query
	 * @param query
	 *            {@link CriteriaQuery} the {@link Predicate} will be used in
	 * @param cb
	 *            {@link CriteriaBuilder} for constructing the {@link Predicate}
	 * @return {@link Predicate} from the parameters and the data
	 */
	Predicate create(Root<? extends ROOT> root, CriteriaQuery<?> query, CriteriaBuilder cb);

	/**
	 * Sets the data to be used by the factory in a type-safe way.
	 *
	 * @param s
	 *            Data to be used by the factory
	 */
	void setData(DATA s);

	/**
	 * Sets the dat to be used by the factory in a non-type-safe way.
	 *
	 * @param data
	 *            Data to be used by the factory
	 */
	void setUntypedData(Object data);
}