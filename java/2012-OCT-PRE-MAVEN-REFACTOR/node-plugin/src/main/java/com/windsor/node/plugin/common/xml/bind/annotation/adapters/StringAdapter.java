package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.util.Date;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:string types.
 *
 */
public class StringAdapter extends XmlAdapter<String, String> {

	@Override
	public String unmarshal(final String s) throws Exception {
		return s;
	}

	@Override
	public String marshal(final String value) throws Exception {
		return value;
	}

}
