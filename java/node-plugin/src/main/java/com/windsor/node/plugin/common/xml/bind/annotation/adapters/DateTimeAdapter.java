package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

import javax.xml.bind.DatatypeConverter;
import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:dateTime types.
 *
 */
public class DateTimeAdapter extends XmlAdapter<String, Date> {

	@Override
	public Date unmarshal(final String s) throws Exception {
		return DatatypeConverter.parseDateTime(s).getTime();
	}

	@Override
	public String marshal(final Date date) throws Exception {
		final Calendar cal = new GregorianCalendar();
		cal.setTime(date);
		return DatatypeConverter.printDateTime(cal);
	}

}
