package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:decimal types.
 *
 */
public class DoubleAdapter extends XmlAdapter<String, Double> {

	@Override
	public Double unmarshal(final String s) throws Exception {
		return Double.parseDouble(s);
	}

	@Override
	public String marshal(final Double value) throws Exception {
		return value == null ? null : new BigDecimal(value).toPlainString();
	}

}
