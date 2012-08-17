package com.windsor.node.plugin.icisnpdes40.adapter;

import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

import javax.xml.bind.DatatypeConverter;
import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:date types.
 *
 */
public class DateAdapter extends XmlAdapter<String, Date> {

	@Override
	public Date unmarshal(final String s) throws Exception {
		return DatatypeConverter.parseDate(s).getTime();
	}

	@Override
	public String marshal(final Date date) throws Exception {
		final Calendar cal = new GregorianCalendar();
		cal.setTime(date);
		return DatatypeConverter.printDate(cal);
	}

}
