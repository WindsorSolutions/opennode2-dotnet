package com.windsor.node.domain.entity.converter;

import javax.persistence.AttributeConverter;
import javax.persistence.Converter;

import com.windsor.node.domain.entity.ScheduleTargetType;

/**
 * Provides a converter for Hibernate for the ScheduleTargetType.
 */
@Converter(autoApply = true)
public class ScheduleTargetTypeConverter implements AttributeConverter<ScheduleTargetType, String> {

    @Override
    public String convertToDatabaseColumn(ScheduleTargetType scheduleTargetType) {
        return scheduleTargetType.getCode();
    }

    @Override
    public ScheduleTargetType convertToEntityAttribute(String code) {
        return ScheduleTargetType.fromString(code);
    }
}
