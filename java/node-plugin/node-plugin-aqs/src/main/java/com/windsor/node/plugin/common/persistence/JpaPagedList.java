/*     */ package com.windsor.node.plugin.common.persistence;
/*     */ 
/*     */ import java.io.Serializable;
/*     */ import java.util.AbstractList;
/*     */ import java.util.HashMap;
/*     */ import java.util.List;
/*     */ import java.util.Map;
/*     */ import javax.persistence.EntityManager;
/*     */ import javax.persistence.Query;
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ public class JpaPagedList<T extends Serializable>
/*     */   extends AbstractList<T>
/*     */ {
/*     */   private final EntityManager em;
/*     */   private String dataQuery;
/*     */   private String countQuery;
/*     */   private List<T> cache;
/*     */   private int cacheStart;
/*     */   private final int cacheSize;
/*     */   private Integer size;
/*     */   private final Class<T> entityClass;
/*  64 */   private final Map<String, Object> namedParameters = new HashMap();
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JpaPagedList(Class<T> entityClass, EntityManager em, String dataQuery, String countQuery, int cacheSize)
/*     */   {
/*  83 */     this.entityClass = entityClass;
/*  84 */     this.em = em;
/*  85 */     this.dataQuery = dataQuery;
/*  86 */     this.countQuery = countQuery;
/*  87 */     this.cacheSize = cacheSize;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public JpaPagedList(Class<T> entityClass, EntityManager em, int cacheSize)
/*     */   {
/* 106 */     this.entityClass = entityClass;
/* 107 */     this.em = em;
/* 108 */     this.cacheSize = cacheSize;
/*     */   }
/*     */   
/*     */   public final T get(int index)
/*     */   {
/* 113 */     if (index > size())
/* 114 */       throw new IndexOutOfBoundsException();
/* 115 */     if ((this.cache == null) || (index < this.cacheStart) || (index >= this.cacheStart + this.cache.size())) {
/* 116 */       this.cacheStart = (index / this.cacheSize * this.cacheSize);
/*     */       
/* 118 */       Query q = this.em.createQuery(getDataQuery()).setFirstResult(this.cacheStart).setMaxResults(this.cacheSize);
/*     */       
/*     */ 
/* 121 */       setNamedParameters(q);
/*     */       
/* 123 */       this.cache = q.getResultList();
/*     */     }
/* 125 */     return this.cache.get(index - this.cacheStart);
/*     */   }
/*     */   
/*     */   public final int size()
/*     */   {
/* 130 */     if (this.size == null) {
/* 131 */       Query q = this.em.createQuery(getCountQuery(), Long.class);
/* 132 */       setNamedParameters(q);
/* 133 */       this.size = Integer.valueOf(((Long)q.getSingleResult()).intValue());
/*     */     }
/* 135 */     return this.size.intValue();
/*     */   }
/*     */   
/*     */   private final Query setNamedParameters(Query q)
/*     */   {
/* 140 */     if (!getNamedParameters().isEmpty()) {
/* 141 */       for (String key : getNamedParameters().keySet()) {
/* 142 */         q.setParameter(key, getNamedParameters().get(key));
/*     */       }
/*     */     }
/* 145 */     return q;
/*     */   }
/*     */   
/*     */   protected String getDataQuery() {
/* 149 */     return this.dataQuery;
/*     */   }
/*     */   
/*     */   protected String getCountQuery() {
/* 153 */     return this.countQuery;
/*     */   }
/*     */   
/*     */   protected final void addNamedParameter(String name, Object value) {
/* 157 */     this.namedParameters.put(name, value);
/*     */   }
/*     */   
/*     */   private Map<String, Object> getNamedParameters() {
/* 161 */     return this.namedParameters;
/*     */   }
/*     */   
/*     */   protected final Class<T> getEntityClass() {
/* 165 */     return this.entityClass;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   protected void beforePageLoaded() {}
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */   protected EntityManager getEm()
/*     */   {
/* 179 */     return this.em;
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\JpaPagedList.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */