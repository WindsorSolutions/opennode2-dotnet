package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.math.BigDecimal;
import java.text.DecimalFormat;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link BigDecimal} objects for xs:decimal
 * types using a {@link DecimalFormat}.
 *
 */
public abstract class AbstractBigDecimalFormatAdapter extends XmlAdapter<String, BigDecimal> {

	/**
	 * Returns a string suitable for using with {@link DecimalFormat} for
	 * formatting a number.
	 *
	 * @return string suitable for using with {@link DecimalFormat}
	 */
	protected abstract String getNumberFormatString();

	@Override
	public BigDecimal unmarshal(final String s) throws Exception {
		return new BigDecimal(s);
	}

	@Override
	public String marshal(final BigDecimal value) throws Exception {
		return value == null ? null : new DecimalFormat(getNumberFormatString()).format(value);
	}

}
