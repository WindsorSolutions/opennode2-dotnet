package com.windsor.node.domain.entity.converter;

import javax.persistence.AttributeConverter;
import javax.persistence.Converter;

import com.windsor.node.domain.entity.DataSourceProvider;

/**
 * Provides a converter for Hibernate for the DataSourceProvider.
 */
@Converter(autoApply = true)
public class DataSourceProviderConverter implements AttributeConverter<DataSourceProvider, String> {

    @Override
    public String convertToDatabaseColumn(DataSourceProvider dataSourceProvider) {
        return dataSourceProvider.getId();
    }

    @Override
    public DataSourceProvider convertToEntityAttribute(String s) {
        return DataSourceProvider.fromString(s);
    }
}
