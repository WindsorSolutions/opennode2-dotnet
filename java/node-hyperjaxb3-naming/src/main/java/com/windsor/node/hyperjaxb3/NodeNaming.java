package com.windsor.node.hyperjaxb3;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.Properties;
import java.util.Set;

import org.apache.commons.lang3.StringUtils;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;
import org.jvnet.hyperjaxb3.ejb.strategy.naming.Naming;
import org.jvnet.hyperjaxb3.ejb.strategy.naming.impl.DefaultNaming;

import com.sun.tools.xjc.model.CClass;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Naming strategy for the node that maps XML names to DB names.
 *
 */
public class NodeNaming extends DefaultNaming {

	private static final Set<String> TABLE_SUFFIXES_TO_REMOVED = new HashSet();
	static {
		TABLE_SUFFIXES_TO_REMOVED.add("Data");
		TABLE_SUFFIXES_TO_REMOVED.add("Code");
	}

	/**
	 * Mapping of XML names to DB names.
	 */
	private Properties xmlToDbNameMappings;

	/**
	 * Separator to use between words for DB names.
	 */
	private String dbWordSeparator;

	/**
	 * Prefix to use for DB PK columns.
	 */
	private String pkColumnNamePrefix;

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

	/**
	 * Called before an XML name is split into words. This allows the words to
	 * be changed before the split occurs. Currently, the only example of this
	 * is "StormWater", so the implementation is being left simple. If more
	 * cases come up, a property file could be used to handle it.
	 *
	 * @param xmlName
	 *            Name of the XML element
	 * @return mapped name for the XML element
	 */
	protected String mapXmlName(final String xmlName) {
		final String newString = xmlName.replaceAll("StormWater", "Stormwater");
		logger.debug("mapXmlName(): Mapping " + xmlName + " to " + newString);
		return newString;
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
			for (final String part : splitXmlNameIntoWords(mapXmlName(draftName))) {
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

	protected String getEntityTableName(final String baseName) {
		return getTableNamePrefix() + baseName;
	}

	@Override
	public String getEntityTableName(final CClass classInfo) {
		final String entityTableName = getEntityTableName(super.getEntityTableName(classInfo));
		logger.debug("getEntityTableName(): Mapping " + classInfo.getType().fullName() + " to "
				+ entityTableName);
		return entityTableName;
	}

	@Override
	public String getTableName(final String qualifiedName) {
		final String shortName = stripTableSuffix(qualifiedName.substring(qualifiedName
				.lastIndexOf(".") + 1));
		logger.debug("getTableName(): Mapping " + qualifiedName + " to " + shortName);
		return shortName;
	}

	protected String stripTableSuffix(final String shortClassName) {
		String newName = shortClassName;
		final String[] parts = StringUtils.splitByCharacterTypeCamelCase(shortClassName);
		if (parts.length > 0) {
			final String lastPart = parts[parts.length - 1];
			if (TABLE_SUFFIXES_TO_REMOVED.contains(lastPart)) {
				newName = shortClassName.substring(0, shortClassName.length() - lastPart.length());
			}
			logger.debug("stripTableSuffix(): Removing the trailing " + lastPart
					+ " from the short class name: " + shortClassName + " to " + newName);
		}
		return newName;
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
		if (getDefaultPkColumnName().equalsIgnoreCase(propertyName)) {
			// FIXME: are we ever coming in here?
			columnName = getPkColumnNamePrefix()
					+ getName(getTableName(fieldOutline.parent().target.shortName))
					+ getPkColumnNameSuffix();
			logger.debug("getColumn$Name(): PK mapping " + propertyName + " to " + columnName);
		} else {
			columnName = super.getColumn$Name(context, fieldOutline);
			logger.debug("getColumn$Name(): Regular mapping " + propertyName + " to " + columnName);
		}

		return columnName;
	}

	@Override
	public String getElementCollection$OrderColumn$Name(final Mapping context,
			final FieldOutline fieldOutline) {
		return null;
	}

	@Override
	public Naming createEmbeddedNaming(final FieldOutline fieldOutline) {
		return this;
	}

	@Override
	public String getJoinColumn$Name(final Mapping context, final FieldOutline fieldOutline,
			final FieldOutline idFieldOutline) {
		final String entityTableName = getEntityTable$Name(context, fieldOutline.parent());
		final String columnName = getName(entityTableName) + getPkColumnNameSuffix();
		logger.debug("getJoinColumn$Name(): Mapping join column for property "
				+ fieldOutline.getPropertyInfo().getName(true) + " to " + columnName);
		return columnName;
	}

	@Override
	public String getElementCollection$CollectionTable$Name(final Mapping context,
			final FieldOutline fieldOutline) {
		final String name = fieldOutline.getPropertyInfo().getName(true);
		final String columnName = getEntityTableName(getName(getTableName(name)));
		logger.debug("getElementCollection$CollectionTable$Name(): Mapping collection table name for property "
				+ name + " to " + columnName);
		return columnName;
	}

	@Override
	public String getElementCollection$CollectionTable$JoinColumn$Name(final Mapping context,
			final FieldOutline fieldOutline, final FieldOutline idFieldOutline) {
		return getJoinColumn$Name(context, fieldOutline, idFieldOutline);
	}

	@Override
	public String getElementCollection$Column$Name(final Mapping context,
			final FieldOutline fieldOutline) {
		final String columnName = getName(fieldOutline.getPropertyInfo().getName(true));
		logger.debug("getElementCollection$Column$Name(): Mapping element collection column for property "
				+ fieldOutline.getPropertyInfo().getName(true) + " to " + columnName);
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
	 * Returns the DB PK column prefix.
	 *
	 * @return the DB PK column prefix
	 */
	public String getPkColumnNamePrefix() {
		return pkColumnNamePrefix;
	}

	/**
	 * Sets the DB PK column prefix
	 *
	 * @param pkColumnNamePrefix
	 *            the DB PK column prefix
	 */
	public void setPkColumnNamePrefix(final String pkColumnNamePrefix) {
		this.pkColumnNamePrefix = pkColumnNamePrefix;
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