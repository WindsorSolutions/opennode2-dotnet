package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.util.Date;

import javax.xml.bind.DatatypeConverter;
import javax.xml.bind.annotation.adapters.XmlAdapter;

import org.apache.commons.lang3.time.DateFormatUtils;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:date types and not appending any TZ info.
 *
 */
public class DateNoTimeZoneAdapter extends XmlAdapter<String, Date> {

	/**
	 * Format of an xs:date value in XML with no TZ.
	 */
	private static final String DATE_FORMAT = "yyyy-MM-dd";

	@Override
	public Date unmarshal(final String s) throws Exception {
		return DatatypeConverter.parseDate(s).getTime();
	}

	@Override
	public String marshal(final Date date) throws Exception {
		return DateFormatUtils.format(date, DATE_FORMAT);
	}

}
