package com.windsor.node.hyperjaxb3;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Properties;

import org.apache.commons.lang3.StringUtils;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;
import org.jvnet.hyperjaxb3.ejb.strategy.naming.impl.DefaultNaming;

import com.sun.tools.xjc.model.CClass;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Naming strategy for the node that maps XML names to DB names.
 *
 */
public class NodeNaming extends DefaultNaming {

	/**
	 * Mapping of XML names to DB names.
	 */
	private Properties xmlToDbNameMappings;

	/**
	 * Separator to use between words for DB names.
	 */
	private String dbWordSeparator;

	/**
	 * Suffix to use for DB PK columns.
	 */
	private String pkColumnNameSuffix;

	/**
	 * Prefix for table names.
	 */
	private String tableNamePrefix;

	/**
	 * Default name of the DB PK column name
	 */
	private String defaultPkColumnName;

	/**
	 * Splits an XML name into individual words.
	 *
	 * @return String array of the words in the XML name
	 */
	protected String[] splitXmlNameIntoWords(final String xmlName) {
		return StringUtils.splitByCharacterTypeCamelCase(xmlName);
	}

	@Override
	public String getName(final String draftName) {
		String name;

		/*
		 * If the incoming name contains the DB word separator, assume that the
		 * name has already been processed and don't process it again.
		 */
		if (draftName.contains(getDbWordSeparator())) {
			name = draftName;
		} else {
			/*
			 * Split the XML name into words, map each XML word to its DB
			 * equivalent and glue the words back together.
			 */
			final Collection<String> names = new ArrayList<String>();
			for (final String part : splitXmlNameIntoWords(draftName)) {
				String translation = part.toUpperCase();
				if (getXmlToDbNameMappings().containsKey(translation)) {
					translation = getXmlToDbNameMappings().getProperty(translation);
				}
				names.add(translation);
			}
			name = StringUtils.join(names, getDbWordSeparator());
		}
		logger.debug("getName(): Mapping " + draftName + " to " + name);
		return name;
	}

	@Override
	public String getEntityTableName(final CClass classInfo) {
		final String entityTableName = getTableNamePrefix() + super.getEntityTableName(classInfo);
		logger.debug("getEntityTableName(): Mapping " + classInfo.getType().fullName() + " to "
				+ entityTableName);
		return entityTableName;
	}

	@Override
	public String getTableName(final String qualifiedName) {
		final String shortName = qualifiedName.substring(qualifiedName.lastIndexOf(".") + 1);
		logger.debug("getTableName(): Mapping " + qualifiedName + " to " + shortName);
		return shortName;
	}

	@Override
	public String getColumn$Name(final Mapping context, final FieldOutline fieldOutline) {
		final String propertyName = fieldOutline.getPropertyInfo().getName(false);
		String columnName;
		/*
		 * This is a hack, but the only way I can tell if I'm mapping a DB PK
		 * column is to check if the incoming property name matches the default
		 * DB PK name. I would think that I can get default DB PK column name
		 * from the context...
		 */
		if (getDefaultPkColumnName().equals(propertyName)) {
			columnName = getName(fieldOutline.parent().target.shortName) + getPkColumnNameSuffix();
		} else {
			columnName = super.getColumn$Name(context, fieldOutline);
		}
		logger.debug("getColumn$Name(): Mapping " + propertyName + " to " + columnName);
		return columnName;
	}

	/**
	 * Returns the XML-to-DB mapping {@link Properties}.
	 *
	 * @return XML-to-DB mapping {@link Properties}
	 */
	public Properties getXmlToDbNameMappings() {
		return xmlToDbNameMappings;
	}

	/**
	 * Sets the XML-to-DB mapping {@link Properties}.
	 *
	 * @param xmlToDbNameMappings
	 *            XML-to-DB mapping {@link Properties}
	 */
	public void setXmlToDbNameMappings(final Properties xmlToDbNameMappings) {
		this.xmlToDbNameMappings = xmlToDbNameMappings;
	}

	/**
	 * Returns the String used to separate words in DB names.
	 *
	 * @return the String used to separate words in DB names
	 */
	public String getDbWordSeparator() {
		return dbWordSeparator;
	}

	/**
	 * Sets the String used to separate words in DB names
	 *
	 * @param dbWordSeparator
	 *            the String used to separate words in DB names
	 */
	public void setDbWordSeparator(final String dbWordSeparator) {
		this.dbWordSeparator = dbWordSeparator;
	}

	/**
	 * Returns the DB PK column suffix.
	 *
	 * @return the DB PK column suffix
	 */
	public String getPkColumnNameSuffix() {
		return pkColumnNameSuffix;
	}

	/**
	 * Sets the DB PK column suffix.
	 *
	 * @param pkColumnNameSuffix
	 *            the DB PK column suffix
	 */
	public void setPkColumnNameSuffix(final String pkColumnNameSuffix) {
		this.pkColumnNameSuffix = pkColumnNameSuffix;
	}

	/**
	 * Returns the DB table name prefix.
	 *
	 * @return the DB table name prefix
	 */
	public String getTableNamePrefix() {
		return tableNamePrefix;
	}

	/**
	 * Sets the DB table name prefix.
	 *
	 * @param tableNamePrefix
	 *            the DB table name prefix
	 */
	public void setTableNamePrefix(final String tableNamePrefix) {
		this.tableNamePrefix = tableNamePrefix;
	}

	/**
	 * Returns the name of the default PK column name as configured in
	 * Hyperjaxb3.
	 *
	 * @return the name of the default PK column name as configured in
	 *         Hyperjaxb3
	 */
	public String getDefaultPkColumnName() {
		return defaultPkColumnName;
	}

	/**
	 * Sets the name of the default PK column name as configured in Hyperjaxb3
	 *
	 * @param defaultPkColumnName
	 *            the name of the default PK column name as configured in
	 *            Hyperjaxb3
	 */
	public void setDefaultPkColumnName(final String defaultPkColumnName) {
		this.defaultPkColumnName = defaultPkColumnName;
	}

}