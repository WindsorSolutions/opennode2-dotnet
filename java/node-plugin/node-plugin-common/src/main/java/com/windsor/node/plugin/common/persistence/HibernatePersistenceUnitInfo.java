package com.windsor.node.plugin.common.persistence;

import java.io.File;
import java.io.IOException;
import java.lang.annotation.Annotation;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLDecoder;
import java.util.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.MappedSuperclass;
import javax.persistence.SharedCacheMode;
import javax.persistence.ValidationMode;
import javax.persistence.spi.ClassTransformer;
import javax.persistence.spi.PersistenceUnitInfo;
import javax.persistence.spi.PersistenceUnitTransactionType;
import javax.sql.DataSource;

/**
 * TODO Document me.
 *
 */
public class HibernatePersistenceUnitInfo implements PersistenceUnitInfo {

    private final Properties jpaProperties;
    private final String entityPackageName;
    private final String[] additionalEntityPackages;
    private final ClassLoader classLoader;

    public HibernatePersistenceUnitInfo(Properties jpaProperties, PluginPersistenceConfig config) {
        this.jpaProperties = jpaProperties;
        this.entityPackageName = config.getRootEntityPackage();
        this.classLoader = config.getClassLoader();
        this.additionalEntityPackages = config.getAdditionalEntityPackages();
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

        List<String> packageNames = new ArrayList<>();
        packageNames.add(entityPackageName);

        if(additionalEntityPackages != null) {
            for(String packageName : additionalEntityPackages) {
                packageNames.add(packageName);
            }
        }

        List<String> classes = new ArrayList<String>();
        for (String packageName : packageNames) {

            try {
                for (Class<?> k : listEntitiesInPackage(packageName)) {
                    classes.add(k.getCanonicalName());
                }

            } catch (Exception e) {
                throw new RuntimeException("Unable to build list of Entity classes.", e);
            }
        }

        return classes;
    }

    private List<Class<?>> listEntitiesInPackage(String packageName) throws ClassNotFoundException, IOException {

        ClassLoader classLoader = this.classLoader;

        if(classLoader == null)
        {
            classLoader = Thread.currentThread().getContextClassLoader();
        }

        assert classLoader != null;

        String path = packageName.replace('.', '/');

        Enumeration<URL> resources = classLoader.getResources(path);

        List<String> dirs = new ArrayList<String>();

        while (resources.hasMoreElements()) {
            URL resource = resources.nextElement();
            dirs.add(URLDecoder.decode(resource.getFile(), "UTF-8"));
        }

        TreeSet<String> classes = new TreeSet<String>();

        for (String directory : dirs) {
            classes.addAll(findClasses(directory, packageName));
        }

        ArrayList<Class<?>> classList = new ArrayList<Class<?>>();

        for (String clazz : classes) {

            Class<?> k = Class.forName(clazz);

            for (Annotation a : k.getAnnotations()) {
                if (a.annotationType().equals(Entity.class) || a.annotationType().equals(Embeddable.class) || a.annotationType().equals(MappedSuperclass.class)) {
                    classList.add(k);
                    continue;
                }
            }
        }
        return classList;
    }

    private TreeSet<String> findClasses(String path, String packageName) throws MalformedURLException, IOException {

        TreeSet<String> classes = new TreeSet<String>();

        if (path.startsWith("file:") && path.contains("!")) {
            String[] split = path.split("!");
            URL jar = new URL(split[0]);
            ZipInputStream zip = new ZipInputStream(jar.openStream());
            ZipEntry entry;
            while ((entry = zip.getNextEntry()) != null) {
                if (entry.getName().endsWith(".class")) {
                    String className = entry.getName().replaceAll("[$].*", "").replaceAll("[.]class", "").replace('/', '.');
                    if (className.startsWith(packageName)) {
                        classes.add(className);
                    }
                }
            }
        }
        File dir = new File(path);
        if (!dir.exists()) {
            return classes;
        }
        File[] files = dir.listFiles();
        for (File file : files) {
            if (file.isDirectory()) {
                assert !file.getName().contains(".");
                classes.addAll(findClasses(file.getAbsolutePath(), packageName + "." + file.getName()));
            } else if (file.getName().endsWith(".class")) {
                String className = packageName + '.' + file.getName().substring(0, file.getName().length() - 6);
                classes.add(className);
            }
        }
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
