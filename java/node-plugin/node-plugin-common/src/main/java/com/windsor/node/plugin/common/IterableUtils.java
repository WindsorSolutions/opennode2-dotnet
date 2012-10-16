package com.windsor.node.plugin.common;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;

import org.apache.commons.collections.IteratorUtils;

/**
 * Utilities for working with {@link Iterable}s.
 *
 */
public class IterableUtils {

	/**
	 * Returns an {@link Iterable} created from applying the transform
	 * {@code transform} to the {@link Iterable} {@code it}.
	 *
	 * @param it
	 *            {@link Iterable} to transform
	 * @param transformer
	 *            {@link ITransformer} transform
	 * @return {@link Iterable} created from applying the transform
	 *         {@code transform} to the {@link Iterable} {@code it}
	 */
	public static <IN, OUT> Iterable<OUT> transform(final Iterable<IN> it,
			final ITransformer<IN, OUT> transformer) {
		return new Iterable<OUT>() {
			@SuppressWarnings("unchecked")
			@Override
			public Iterator<OUT> iterator() {
				return IteratorUtils.transformedIterator(it.iterator(), transformer);
			}
		};

	}

	/**
	 * Returns a {@link Collection} of type {@code T} created from an
	 * {@link Iterable} of type {@code T}.
	 *
	 * @param it
	 *            {@link Iterable} to convert to a {@link Collection}
	 * @return {@link Collection} consisting of the elements in the
	 *         {@link Iterable}
	 */
	public static <T> Collection<T> toCollection(final Iterable<T> it) {
		final Collection<T> col = new ArrayList<T>();
		for (final T t : it) {
			col.add(t);
		}
		return col;
	}

	/**
	 * Returns an {@link Iterable} consisting of just element {@code t}.
	 *
	 * @param t
	 *            The element to be returned by the {@link Iterable}
	 * @return {@link Iterable} consisting of just element {@code t}
	 */
	public static <T> Iterable<T> toIterable(final T t) {
		final Collection<T> col = new ArrayList<T>();
		col.add(t);
		return col;
	}

}
