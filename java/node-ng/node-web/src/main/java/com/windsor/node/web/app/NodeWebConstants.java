package com.windsor.node.web.app;

import java.time.LocalDate;
import java.util.Arrays;

import com.windsor.stack.domain.search.LocalDateRange;
import com.windsor.stack.web.wicket.component.daterange.LocalDateRangeTextFieldSettings;
import com.windsor.stack.web.wicket.component.daterange.NamedLocalDateRange;

/**
 * Provides constants for the application.
 */
public class NodeWebConstants {

    public static final String SCHEDULE_DATE_TIME_FORMAT = "yyyy-MM-dd hh:mm:ss a";

    public static final LocalDateRangeTextFieldSettings DATERANGE_DEFAULT_SETTINGS = new LocalDateRangeTextFieldSettings()
            .namedDateRanges(Arrays.asList(
                    new NamedLocalDateRange("This Year", new LocalDateRange(LocalDate.of(LocalDate.now().getYear(), 1, 1),
                            LocalDate.now().withYear(LocalDate.now().getYear())
                                    .withMonth(12).withDayOfMonth(LocalDate.now().withMonth(12).lengthOfMonth()))),
                    new NamedLocalDateRange("Last Year", new LocalDateRange(LocalDate.of(LocalDate.now().getYear() - 1, 1, 1),
                            LocalDate.now().withYear(LocalDate.now().getYear())
                                    .withMonth(12).withDayOfMonth(LocalDate.now().withMonth(12).lengthOfMonth()))),
                    new NamedLocalDateRange("Last 5 Years", new LocalDateRange(LocalDate.of(LocalDate.now().getYear() - 5, 1, 1),
                            LocalDate.now().withYear(LocalDate.now().getYear())
                                    .withMonth(12).withDayOfMonth(LocalDate.now().withMonth(12).lengthOfMonth()))),
                    new NamedLocalDateRange("Last 10 Years", new LocalDateRange(LocalDate.of(LocalDate.now().getYear() - 10, 1, 1),
                            LocalDate.now().withYear(LocalDate.now().getYear())
                                    .withMonth(12).withDayOfMonth(LocalDate.now().withMonth(12).lengthOfMonth()))),
                    new NamedLocalDateRange("Last 20 Years", new LocalDateRange(LocalDate.of(LocalDate.now().getYear() - 20, 1, 1),
                            LocalDate.now().withYear(LocalDate.now().getYear())
                                    .withMonth(12).withDayOfMonth(LocalDate.now().withMonth(12).lengthOfMonth()))),
                    new NamedLocalDateRange("Before 1989", new LocalDateRange(LocalDate.of(1788, 2, 6),
                            LocalDate.of(1988, 12, 31)))));

}
