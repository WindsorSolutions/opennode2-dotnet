package com.windsor.node.domain.entity;

import java.util.stream.Stream;

/**
 * Provides an enumeration of schedule frequency types.
 */
public enum ScheduleFrequencyType {

    Never, Once, Minutes, Hours, Days, Weekdays, Weeks, Months;

    public static Stream<ScheduleFrequencyType> getMatches(String term) {
        return Stream.of(values())
                .filter(dsp -> dsp.toString().toLowerCase().contains(term.toLowerCase()));
    }
}
