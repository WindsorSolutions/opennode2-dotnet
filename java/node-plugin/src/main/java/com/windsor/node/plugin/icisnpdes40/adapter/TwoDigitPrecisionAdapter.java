package com.windsor.node.plugin.icisnpdes40.adapter;

import java.math.BigDecimal;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for {@link BigDecimal} with two digits of precision.
 *
 */
public class TwoDigitPrecisionAdapter extends AbstractBigDecimalFormatAdapter {

	/**
	 * How to format the number as a string.
	 */
	private static final String NUMBER_FORMAT = "0.00";

	@Override
	protected String getNumberFormatString() {
		return NUMBER_FORMAT;
	}

}
