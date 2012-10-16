package com.windsor.node.plugin.common;

import org.apache.commons.collections.Transformer;

/**
 * Extension of the Apache {@link Transformer} to provide a type safety.
 *
 * @param <IN>
 *            Type being transformed from
 * @param <OUT>
 *            Type being transformed into
 */
public interface ITransformer<IN, OUT> extends Transformer {

	/**
	 * Transforms {@code IN} into {@code OUT} in a type-safe way.
	 *
	 * @param in
	 *            Value to be transformed
	 * @return Transformed value
	 */
	OUT typedTransform(IN in);

}
