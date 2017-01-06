package com.windsor.node.domain.entity;

import java.util.Arrays;
import java.util.Collection;
import java.util.stream.Stream;

public enum ActivityType {

    Info("Info"),
    ServiceAuth("Serivce Authentication"),
    Error("Error"),
    Audit("Audit"),
    AdminAuth("Admin Authentication");

    public static final Collection<ActivityType> EXCHANGE_ACTIVITY_TYPES = Arrays.asList(Info, Error);

    private String description;

    ActivityType(String description) {
        this.description = description;
    }

    public String getDescription() {
        return description;
    }

    public static Stream<ActivityType> getMatches(String term) {
        return Stream.of(values())
                .filter(dsp -> dsp.getDescription().toLowerCase().contains(term.toLowerCase()));
    }

    @Override
    public String toString() {
        return description;
    }

}
