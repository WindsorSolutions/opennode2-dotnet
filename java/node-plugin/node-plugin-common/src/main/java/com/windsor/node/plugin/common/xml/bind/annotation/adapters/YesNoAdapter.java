package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping "Y"/"N" Strings to xs:boolean types.
 *
 */
public class YesNoAdapter extends XmlAdapter<String, String> {

	/**
	 * Java String value which indicates true.
	 */
	private static final String JAVA_TRUE_VALUE = "Y";

	/**
	 * XML true value.
	 */
	private static final String XML_TRUE_VALUE = "true";

	/**
	 * XML false value.
	 */
	private static final String XML_FALSE_VALUE = "false";

	@Override
	public String unmarshal(final String s) throws Exception {
		return s;
	}

	@Override
	public String marshal(final String value) throws Exception {
		return value == null ? null : (JAVA_TRUE_VALUE.equals(value) ? XML_TRUE_VALUE
				: XML_FALSE_VALUE);
	}

}
