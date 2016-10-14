/*     */ package com.windsor.node.plugin.common.persistence;
/*     */ 
/*     */ import com.windsor.node.plugin.common.AbstractTransformer;
/*     */ import com.windsor.node.plugin.common.AbstractTransformer.SuffixAppenderTransformer;
/*     */ import com.windsor.node.plugin.common.ITransformer;
/*     */ import com.windsor.node.plugin.common.IterableUtils;
/*     */ import java.util.ArrayList;
/*     */ import java.util.Collection;
/*     */ import java.util.Iterator;
/*     */ import javax.persistence.criteria.CriteriaBuilder;
/*     */ import javax.persistence.criteria.Expression;
/*     */ import javax.persistence.criteria.Predicate;
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
/*     */ public class QueryUtils
/*     */ {
/*  25 */   private static final AbstractTransformer.SuffixAppenderTransformer LIKE_TRANSFORMER = new AbstractTransformer.SuffixAppenderTransformer("%");
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
/*     */   public static Predicate createLike(Iterable<String> values, CriteriaBuilder cb, Iterable<? extends Expression<String>> paths)
/*     */   {
/*  47 */     Collection<Predicate> disjunctions = new ArrayList();
/*  48 */     for (Iterator i$ = values.iterator(); i$.hasNext();) {
                String s = (String)i$.next();
/*  49 */       if (s != null) {
/*  50 */         for (Expression<String> path : paths)
/*  51 */           disjunctions.add(cb.like(path, s));
/*     */       }
/*     */     }
/*     */     String s;
/*  55 */     return cb.or((Predicate[])disjunctions.toArray(new Predicate[disjunctions.size()]));
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
/*     */   public static <T extends Expression<String>> Predicate startsWithIgnoreCase(Iterable<String> values, CriteriaBuilder cb, Iterable<T> paths)
/*     */   {
/*  70 */     ITransformer<T, Expression<String>> uct = new UpperCaseExpressionTransformer(cb);
/*  71 */     Iterable<Expression<String>> it = IterableUtils.transform(paths, uct);
/*  72 */     return createLike(IterableUtils.transform(IterableUtils.transform(values, AbstractTransformer.UPPER_CASE_TRANSFORMER), LIKE_TRANSFORMER), cb, it);
/*     */   }
/*     */   
/*     */ 
/*     */   public static Predicate startsWithIgnoreCase(Iterable<String> values, CriteriaBuilder cb, Expression<String> path)
/*     */   {
/*  78 */     return startsWithIgnoreCase(values, cb, IterableUtils.toIterable(path));
/*     */   }
/*     */   
/*     */   public static Predicate startsWithIgnoreCase(String value, CriteriaBuilder cb, Expression<String> path)
/*     */   {
/*  83 */     return startsWithIgnoreCase(IterableUtils.toIterable(value), cb, IterableUtils.toIterable(path));
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public static Predicate in(Iterable<String> col, CriteriaBuilder cb, Iterable<Expression<String>> paths)
/*     */   {
/*  92 */     Collection<Predicate> predicates = new ArrayList();
/*  93 */     for (Expression<String> exp : paths) {
/*  94 */       predicates.add(in(col, cb, exp));
/*     */     }
/*  96 */     return cb.or((Predicate[])predicates.toArray(new Predicate[predicates.size()]));
/*     */   }
/*     */   
/*     */   public static Predicate in(Iterable<String> col, CriteriaBuilder cb, Expression<String> path)
/*     */   {
/* 101 */     Collection<String> col2 = IterableUtils.toCollection(col);
/* 102 */     return path.in((Object[])col2.toArray(new String[col2.size()]));
/*     */   }
/*     */   
/*     */   public static Predicate inIgnoreCase(Collection<String> values, CriteriaBuilder cb, Expression<String> path)
/*     */   {
/* 107 */     return in(IterableUtils.transform(values, AbstractTransformer.UPPER_CASE_TRANSFORMER), cb, IterableUtils.transform(IterableUtils.toIterable(path), new UpperCaseExpressionTransformer(cb)));
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   static class UpperCaseExpressionTransformer<IN extends Expression<String>>
/*     */     extends AbstractTransformer<IN, Expression<String>>
/*     */   {
/*     */     private final CriteriaBuilder criteriaBuilder;
/*     */     
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */     public UpperCaseExpressionTransformer(CriteriaBuilder criteriaBuilder)
/*     */     {
/* 125 */       this.criteriaBuilder = criteriaBuilder;
/*     */     }
/*     */     
/*     */     public CriteriaBuilder getCriteriaBuilder() {
/* 129 */       return this.criteriaBuilder;
/*     */     }
/*     */     
/*     */     public Expression<String> typedTransform(IN in)
/*     */     {
/* 134 */       return getCriteriaBuilder().upper(in);
/*     */     }
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\QueryUtils.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */