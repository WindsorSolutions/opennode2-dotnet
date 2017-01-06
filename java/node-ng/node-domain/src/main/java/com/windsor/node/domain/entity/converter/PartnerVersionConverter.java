package com.windsor.node.domain.entity.converter;

import javax.persistence.AttributeConverter;
import javax.persistence.Converter;

import com.windsor.node.domain.entity.PartnerVersion;

/**
 * Provides a converter for Hibernate for the PartnerVersion.
 */
@Converter(autoApply = true)
public class PartnerVersionConverter implements AttributeConverter<PartnerVersion, String> {

    @Override
    public String convertToDatabaseColumn(PartnerVersion partnerVersion) {
        return partnerVersion.getId();
    }

    @Override
    public PartnerVersion convertToEntityAttribute(String s) {
        return PartnerVersion.fromString(s);
    }
}
