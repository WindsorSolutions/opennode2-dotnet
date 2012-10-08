package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.math.BigDecimal;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for {@link BigDecimal} with one digit of precision.
 *
 */
public class OneDigitPrecisionAdapter extends AbstractBigDecimalFormatAdapter {

	/**
	 * How to format the number as a string.
	 */
	private static final String NUMBER_FORMAT = "0.0";

	@Override
	protected String getNumberFormatString() {
		return NUMBER_FORMAT;
	}

}
