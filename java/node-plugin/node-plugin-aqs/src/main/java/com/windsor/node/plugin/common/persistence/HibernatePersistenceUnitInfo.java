/*     */ package com.windsor.node.plugin.common.persistence;
/*     */ 
/*     */ import java.io.File;
/*     */ import java.io.IOException;
/*     */ import java.lang.annotation.Annotation;
/*     */ import java.net.MalformedURLException;
/*     */ import java.net.URL;
/*     */ import java.net.URLDecoder;
/*     */ import java.util.ArrayList;
/*     */ import java.util.Enumeration;
/*     */ import java.util.List;
/*     */ import java.util.Properties;
/*     */ import java.util.TreeSet;
/*     */ import java.util.zip.ZipEntry;
/*     */ import java.util.zip.ZipInputStream;
/*     */ import javax.persistence.Embeddable;
/*     */ import javax.persistence.Entity;
/*     */ import javax.persistence.MappedSuperclass;
/*     */ import javax.persistence.SharedCacheMode;
/*     */ import javax.persistence.ValidationMode;
/*     */ import javax.persistence.spi.ClassTransformer;
/*     */ import javax.persistence.spi.PersistenceUnitInfo;
/*     */ import javax.persistence.spi.PersistenceUnitTransactionType;
/*     */ import javax.sql.DataSource;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class HibernatePersistenceUnitInfo
/*     */   implements PersistenceUnitInfo
/*     */ {
/*     */   private final Properties jpaProperties;
/*     */   private final String entityPackageName;
/*     */   private final ClassLoader classLoader;
/*     */   
/*     */   public HibernatePersistenceUnitInfo(Properties jpaProperties, PluginPersistenceConfig config)
/*     */   {
/*  38 */     this.jpaProperties = jpaProperties;
/*  39 */     this.entityPackageName = config.getRootEntityPackage();
/*  40 */     this.classLoader = config.getClassLoader();
/*     */   }
/*     */   
/*     */   public ValidationMode getValidationMode()
/*     */   {
/*  45 */     return ValidationMode.NONE;
/*     */   }
/*     */   
/*     */   public PersistenceUnitTransactionType getTransactionType()
/*     */   {
/*  50 */     return PersistenceUnitTransactionType.RESOURCE_LOCAL;
/*     */   }
/*     */   
/*     */   public SharedCacheMode getSharedCacheMode()
/*     */   {
/*  55 */     return SharedCacheMode.ENABLE_SELECTIVE;
/*     */   }
/*     */   
/*     */   public Properties getProperties()
/*     */   {
/*  60 */     return this.jpaProperties;
/*     */   }
/*     */   
/*     */   public String getPersistenceXMLSchemaVersion()
/*     */   {
/*  65 */     return null;
/*     */   }
/*     */   
/*     */   public URL getPersistenceUnitRootUrl()
/*     */   {
/*  70 */     return null;
/*     */   }
/*     */   
/*     */   public String getPersistenceUnitName()
/*     */   {
/*  75 */     return null;
/*     */   }
/*     */   
/*     */   public String getPersistenceProviderClassName()
/*     */   {
/*  80 */     return "org.hibernate.ejb.HibernatePersistence";
/*     */   }
/*     */   
/*     */   public DataSource getNonJtaDataSource()
/*     */   {
/*  85 */     return null;
/*     */   }
/*     */   
/*     */   public ClassLoader getNewTempClassLoader()
/*     */   {
/*  90 */     return null;
/*     */   }
/*     */   
/*     */   public List<String> getMappingFileNames()
/*     */   {
/*  95 */     return null;
/*     */   }
/*     */   
/*     */ 
/*     */   public List<String> getManagedClassNames()
/*     */   {
/*     */     try
/*     */     {
/* 103 */       List<String> classes = new ArrayList();
/*     */       
/* 105 */       for (Class<?> k : listEntitiesInPackage(this.entityPackageName)) {
/* 106 */         classes.add(k.getCanonicalName());
/*     */       }
/*     */       
/* 109 */       return classes;
/*     */     }
/*     */     catch (Exception e) {
/* 112 */       throw new RuntimeException("Unable to build list of Entity classes.", e);
/*     */     }
/*     */   }
/*     */   
/*     */   private List<Class<?>> listEntitiesInPackage(String packageName) throws ClassNotFoundException, IOException
/*     */   {
/* 118 */     ClassLoader classLoader = this.classLoader;
/*     */     
/* 120 */     if (classLoader == null)
/*     */     {
/* 122 */       classLoader = Thread.currentThread().getContextClassLoader();
/*     */     }
/*     */     
/* 125 */     assert (classLoader != null);
/*     */     
/* 127 */     String path = packageName.replace('.', '/');
/*     */     
/* 129 */     Enumeration<URL> resources = classLoader.getResources(path);
/*     */     
/* 131 */     List<String> dirs = new ArrayList();
/*     */     
/* 133 */     while (resources.hasMoreElements()) {
/* 134 */       URL resource = (URL)resources.nextElement();
/* 135 */       dirs.add(URLDecoder.decode(resource.getFile(), "UTF-8"));
/*     */     }
/*     */     
/* 138 */     TreeSet<String> classes = new TreeSet();
/*     */     
/* 140 */     for (String directory : dirs) {
/* 141 */       classes.addAll(findClasses(directory, packageName));
/*     */     }
/*     */     
/* 144 */     ArrayList<Class<?>> classList = new ArrayList();
/*     */     
/* 146 */     for (String clazz : classes)
/*     */     {
/* 148 */       Class<?> k = Class.forName(clazz);
/*     */       
/* 150 */       for (Annotation a : k.getAnnotations()) {
/* 151 */         if ((a.annotationType().equals(Entity.class)) || (a.annotationType().equals(Embeddable.class)) || (a.annotationType().equals(MappedSuperclass.class))) {
/* 152 */           classList.add(k);
/*     */         }
/*     */       }
/*     */     }
/*     */     
/* 157 */     return classList;
/*     */   }
/*     */   
/*     */   private TreeSet<String> findClasses(String path, String packageName) throws MalformedURLException, IOException
/*     */   {
/* 162 */     TreeSet<String> classes = new TreeSet();
/*     */     
/* 164 */     if ((path.startsWith("file:")) && (path.contains("!"))) {
/* 165 */       String[] split = path.split("!");
/* 166 */       URL jar = new URL(split[0]);
/* 167 */       ZipInputStream zip = new ZipInputStream(jar.openStream());
/*     */       ZipEntry entry;
/* 169 */       while ((entry = zip.getNextEntry()) != null) {
/* 170 */         if (entry.getName().endsWith(".class")) {
/* 171 */           String className = entry.getName().replaceAll("[$].*", "").replaceAll("[.]class", "").replace('/', '.');
/* 172 */           if (className.startsWith(packageName)) {
/* 173 */             classes.add(className);
/*     */           }
/*     */         }
/*     */       }
/*     */     }
/* 178 */     File dir = new File(path);
/* 179 */     if (!dir.exists()) {
/* 180 */       return classes;
/*     */     }
/* 182 */     File[] files = dir.listFiles();
/* 183 */     for (File file : files) {
/* 184 */       if (file.isDirectory()) {
/* 185 */         assert (!file.getName().contains("."));
/* 186 */         classes.addAll(findClasses(file.getAbsolutePath(), packageName + "." + file.getName()));
/* 187 */       } else if (file.getName().endsWith(".class")) {
/* 188 */         String className = packageName + '.' + file.getName().substring(0, file.getName().length() - 6);
/* 189 */         classes.add(className);
/*     */       }
/*     */     }
/* 192 */     return classes;
/*     */   }
/*     */   
/*     */   public DataSource getJtaDataSource()
/*     */   {
/* 197 */     return null;
/*     */   }
/*     */   
/*     */   public List<URL> getJarFileUrls()
/*     */   {
/* 202 */     List<URL> jars = new ArrayList();
/* 203 */     return jars;
/*     */   }
/*     */   
/*     */   public ClassLoader getClassLoader()
/*     */   {
/* 208 */     return getClass().getClassLoader();
/*     */   }
/*     */   
/*     */   public boolean excludeUnlistedClasses()
/*     */   {
/* 213 */     return false;
/*     */   }
/*     */   
/*     */   public void addTransformer(ClassTransformer transformer) {}
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\HibernatePersistenceUnitInfo.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */