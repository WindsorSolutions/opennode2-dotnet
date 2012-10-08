package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.util.Date;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:int types.
 *
 */
public class IntegerAdapter extends XmlAdapter<String, Integer> {

	@Override
	public Integer unmarshal(final String s) throws Exception {
		return Integer.parseInt(s);
	}

	@Override
	public String marshal(final Integer value) throws Exception {
		return value == null ? null : value.toString();
	}

}
