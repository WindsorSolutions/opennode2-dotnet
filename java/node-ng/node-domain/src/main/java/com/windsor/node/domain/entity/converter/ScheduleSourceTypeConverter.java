package com.windsor.node.domain.entity.converter;

import javax.persistence.AttributeConverter;
import javax.persistence.Converter;

import com.windsor.node.domain.entity.ScheduleSourceType;

/**
 * Provides a converter for Hibernate for the ScheduleServiceSourceType.
 */
@Converter(autoApply = true)
public class ScheduleSourceTypeConverter implements AttributeConverter<ScheduleSourceType, String> {

    @Override
    public String convertToDatabaseColumn(ScheduleSourceType scheduleSourceType) {
        return scheduleSourceType.getCode();
    }

    @Override
    public ScheduleSourceType convertToEntityAttribute(String code) {
        return ScheduleSourceType.fromString(code);
    }
}
