package com.windsor.node.plugin.icisnpdes40.adapter;

import java.math.BigDecimal;
import java.math.MathContext;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link BigDecimal} objects for xs:decimal
 * types where the representation is defined by the total number of characters
 * in the representation and the max amount of precision.
 *
 */
public abstract class AbstractBigDecimalLengthAdapter extends XmlAdapter<String, BigDecimal> {

	/**
	 * Returns the number of characters that can be in the XML representation of
	 * the value.
	 *
	 * @return the number of characters that can be in the XML representation of
	 *         the value
	 */
	protected abstract int totalNumberOfCharacters();

	/**
	 * Returns the number of characters that can be after the decimal point.
	 *
	 * @return the number of characters that can be after the decimal point
	 */
	protected int maxPrecision() {
		return totalNumberOfCharacters() - 1;
	}

	@Override
	public BigDecimal unmarshal(final String s) throws Exception {
		return new BigDecimal(s);
	}

	@Override
	public String marshal(final BigDecimal value) throws Exception {
		return value == null ? null : toString(value);
	}

	/**
	 * Returns a string representation of the {@code value}, given the
	 * constraints of total number of characters and max amount of precision.
	 *
	 * @param value
	 *            {@link BigDecimal} value for which to generate a String value
	 * @return string representation of the {@code value}
	 */
	protected String toString(final BigDecimal value) {
		final int amtOfPrecision = totalNumberOfCharacters()
				- value.toBigInteger().toString().length();
		final BigDecimal bd = new BigDecimal(value.toString(), new MathContext(
				amtOfPrecision > maxPrecision() ? maxPrecision() : amtOfPrecision))
				.stripTrailingZeros();
		return bd.toPlainString();
	}

}
