package com.windsor.node.plugin.common.persistence;

import static com.windsor.node.plugin.common.AbstractTransformer.UPPER_CASE_TRANSFORMER;
import static com.windsor.node.plugin.common.IterableUtils.toIterable;
import static com.windsor.node.plugin.common.IterableUtils.transform;

import java.util.ArrayList;
import java.util.Collection;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.Expression;
import javax.persistence.criteria.Predicate;

import com.windsor.node.plugin.common.AbstractTransformer;
import com.windsor.node.plugin.common.AbstractTransformer.SuffixAppenderTransformer;
import com.windsor.node.plugin.common.ITransformer;
import com.windsor.node.plugin.common.IterableUtils;

/**
 * Utilities for programmatically building queries using the JPA2 metamodel.
 *
 */
public class QueryUtils {

	private static final SuffixAppenderTransformer LIKE_TRANSFORMER = new SuffixAppenderTransformer(
			"%");

	/*
	 * Like methods.
	 */

	/**
	 * Returns a disjunction of like-clause {@link Predicate}s built from the
	 * {@code values} referencing the {@code paths}.
	 *
	 * @param values
	 *            like values
	 * @param cb
	 *            {@link CriteriaBuilder} for creating expressions
	 * @param paths
	 *            properties against which to create the like clauses
	 * @return disjunction of like-clause {@link Predicate}s built from the
	 *         {@code values} referencing the {@code paths}.
	 */
	public static Predicate createLike(final Iterable<String> values, final CriteriaBuilder cb,
			final Iterable<? extends Expression<String>> paths) {
		final Collection<Predicate> disjunctions = new ArrayList<Predicate>();
		for (final String s : values) {
			if (s != null) {
				for (final Expression<String> path : paths) {
					disjunctions.add(cb.like(path, s));
				}
			}
		}
		return cb.or(disjunctions.toArray(new Predicate[disjunctions.size()]));
	}

	/**
	 * Returns a disjunction of like-clause {@link Predicate}s built from the
	 * {@code values}, where the values and paths are capitalized, and the
	 * values have a "%" appended to them.
	 *
	 * @param values
	 * @param cb
	 * @param paths
	 * @return
	 */
	public static <T extends Expression<String>> Predicate startsWithIgnoreCase(final Iterable<String> values,
			final CriteriaBuilder cb, final Iterable<T> paths) {
		final ITransformer<T, Expression<String>> uct = new UpperCaseExpressionTransformer<T>(cb);
		final Iterable<Expression<String>> it = transform(paths, uct);
		return createLike(transform(transform(values, UPPER_CASE_TRANSFORMER), LIKE_TRANSFORMER),
				cb, it);
	}

	public static Predicate startsWithIgnoreCase(final Iterable<String> values,
			final CriteriaBuilder cb, final Expression<String> path) {
		return startsWithIgnoreCase(values, cb, toIterable(path));
	}

	public static Predicate startsWithIgnoreCase(final String value, final CriteriaBuilder cb,
			final Expression<String> path) {
		return startsWithIgnoreCase(toIterable(value), cb, toIterable(path));
	}

	/*
	 * In methods.
	 */

	public static Predicate in(final Iterable<String> col, final CriteriaBuilder cb,
			final Iterable<Expression<String>> paths) {
		final Collection<Predicate> predicates = new ArrayList<Predicate>();
		for (final Expression<String> exp : paths) {
			predicates.add(in(col, cb, exp));
		}
		return cb.or(predicates.toArray(new Predicate[predicates.size()]));
	}

	public static Predicate in(final Iterable<String> col, final CriteriaBuilder cb,
			final Expression<String> path) {
		final Collection<String> col2 = IterableUtils.toCollection(col);
		return path.in((Object[]) col2.toArray(new String[col2.size()]));
	}

	public static Predicate inIgnoreCase(final Collection<String> values, final CriteriaBuilder cb,
			final Expression<String> path) {
		return in(transform(values, AbstractTransformer.UPPER_CASE_TRANSFORMER), cb,
				transform(toIterable(path), new UpperCaseExpressionTransformer<Expression<String>>(cb)));
	}

	/*
	 * Helper classes.
	 */

	/**
	 * Simple transformer for turning a path into an upper-case path.
	 *
	 */
	static class UpperCaseExpressionTransformer<IN extends Expression<String>> extends
			AbstractTransformer<IN, Expression<String>> {

		private final CriteriaBuilder criteriaBuilder;

		public UpperCaseExpressionTransformer(final CriteriaBuilder criteriaBuilder) {
			this.criteriaBuilder = criteriaBuilder;
		}

		public CriteriaBuilder getCriteriaBuilder() {
			return criteriaBuilder;
		}

		@Override
		public Expression<String> typedTransform(final IN in) {
			return getCriteriaBuilder().upper(in);
		}
	}

}
