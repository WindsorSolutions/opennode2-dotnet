package com.windsor.node.plugin.common;

/**
 * Implementation of {@link ITranformer}.
 *
 * @param <IN>
 *            type to be transformed from
 * @param <OUT>
 *            type to be tranformed into
 */
public abstract class AbstractTransformer<IN, OUT> implements ITransformer<IN, OUT> {

	@SuppressWarnings("unchecked")
	@Override
	public Object transform(final Object input) {
		return typedTransform((IN) input);
	}

	/**
	 * Transforms a {@link String} into an upper-case {@link String}.
	 *
	 */
	static class UpperCaseTransformer extends AbstractTransformer<String, String> {

		@Override
		public String typedTransform(final String in) {
			return in == null ? null : in.toUpperCase();
		}

	}
	public static final UpperCaseTransformer UPPER_CASE_TRANSFORMER = new UpperCaseTransformer();

	/**
	 * Transforms a {@link String} into a {@link String} of no more than maxLength.
	 *
	 */
	public static class LengthTransformer extends AbstractTransformer<String, String> {

		private final int maxLength;

		public LengthTransformer(final int maxLength) {
			this.maxLength = maxLength;
		}

		@Override
		public String typedTransform(final String in) {
			return in == null ? null : (in.length() > maxLength ? in.substring(0,
					maxLength) : in);
		}

	}

	/**
	 * Adds a suffix to a {@link String}.
	 *
	 */
	public static class SuffixAppenderTransformer extends
			AbstractTransformer<String, String> {

		private final String suffix;

		public SuffixAppenderTransformer(final String suffix) {
			this.suffix = suffix;
		}

		@Override
		public String typedTransform(final String in) {
			return in == null ? null : in + suffix;
		}

	}

}
