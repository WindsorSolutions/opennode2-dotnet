package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import java.sql.Timestamp;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import javax.xml.bind.DatatypeConverter;
import javax.xml.bind.annotation.adapters.XmlAdapter;

/**
 * {@link XmlAdapter} for mapping {@link Date} objects for xs:date types.
 *
 */
public class TimestampAdapter extends XmlAdapter<String, Timestamp> {

	@Override
	public Timestamp unmarshal(final String s) throws Exception {
		return new Timestamp(DatatypeConverter.parseDate(s).getTime().getTime());
	}

	@Override
	public String marshal(final Timestamp timestamp) throws Exception {
		final Calendar cal = new GregorianCalendar();
		cal.setTime(timestamp);
		return DatatypeConverter.printDate(cal);
	}

}
