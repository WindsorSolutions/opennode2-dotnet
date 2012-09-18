package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.util.Date;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:int types such
 * that leading zeroes are prepended to make the width exactly two characters
 * wide.
 *
 */
public class TwoDigitIntegerAdapter extends XmlAdapter<String, Integer> {

	@Override
	public Integer unmarshal(final String s) throws Exception {
		return Integer.parseInt(s);
	}

	@Override
	public String marshal(final Integer value) throws Exception {
		return value == null ? null : String.format("%02d", value);
	}

}
