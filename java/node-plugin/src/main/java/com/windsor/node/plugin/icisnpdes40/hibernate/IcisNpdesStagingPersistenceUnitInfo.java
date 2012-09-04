package com.windsor.node.plugin.icisnpdes40.hibernate;

import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

import javax.persistence.SharedCacheMode;
import javax.persistence.ValidationMode;
import javax.persistence.spi.ClassTransformer;
import javax.persistence.spi.PersistenceUnitInfo;
import javax.persistence.spi.PersistenceUnitTransactionType;
import javax.sql.DataSource;

public class IcisNpdesStagingPersistenceUnitInfo implements PersistenceUnitInfo {

	private Properties jpaProperties;

	public IcisNpdesStagingPersistenceUnitInfo(Properties jpaProperties) {
		this.jpaProperties = jpaProperties;
	}

	@Override
	public ValidationMode getValidationMode() {
		return ValidationMode.NONE;
	}
	
	@Override
	public PersistenceUnitTransactionType getTransactionType() {
		return PersistenceUnitTransactionType.RESOURCE_LOCAL;
	}
	
	@Override
	public SharedCacheMode getSharedCacheMode() {
		return SharedCacheMode.ENABLE_SELECTIVE;
	}
	
	@Override
	public Properties getProperties() {
		return jpaProperties;
	}
	
	@Override
	public String getPersistenceXMLSchemaVersion() {
		return null;
	}
	
	@Override
	public URL getPersistenceUnitRootUrl() {
		return null;
	}
	
	@Override
	public String getPersistenceUnitName() {
		return null;
	}
	
	@Override
	public String getPersistenceProviderClassName() {		
		return "org.hibernate.ejb.HibernatePersistence";
	}
	
	@Override
	public DataSource getNonJtaDataSource() {
		return null;
	}
	
	@Override
	public ClassLoader getNewTempClassLoader() {
		return null;
	}
	
	@Override
	public List<String> getMappingFileNames() {
		return null;
	}
	
	@Override
	public List<String> getManagedClassNames() {
		List<String> classes = new ArrayList<String>();
		
		/**
		 * Limit Set
		 */
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.LimitSetData");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.LimitSetSchedule");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.LimitSetStatus");
		
		/**
		 * Permitted Feature
		 */
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.PermittedFeatureData");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.GeographicCoordinates");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.Contact");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.Telephone");
		classes.add("com.windsor.node.plugin.icisnpdes40.generated.Address");
		
		/**
		 * ???
		 */
		
		
		return classes;
	}
	
	@Override
	public DataSource getJtaDataSource() {
		return null;
	}
	
	@Override
	public List<URL> getJarFileUrls() {
		List<URL> jars = new ArrayList<URL>();
		return jars;
	}
	
	@Override
	public ClassLoader getClassLoader() {
		return getClass().getClassLoader();
	}
	
	@Override
	public boolean excludeUnlistedClasses() {
		return false;
	}
	
	@Override
	public void addTransformer(ClassTransformer transformer) { }
}
