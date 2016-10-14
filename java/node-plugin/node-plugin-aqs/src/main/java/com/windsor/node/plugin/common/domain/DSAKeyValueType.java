/*     */ package com.windsor.node.plugin.common.domain;
/*     */ 
/*     */ import javax.xml.bind.annotation.XmlAccessType;
/*     */ import javax.xml.bind.annotation.XmlAccessorType;
/*     */ import javax.xml.bind.annotation.XmlElement;
/*     */ import javax.xml.bind.annotation.XmlType;
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
/*     */ @XmlAccessorType(XmlAccessType.FIELD)
/*     */ @XmlType(name="DSAKeyValueType", propOrder={"p", "q", "g", "y", "j", "seed", "pgenCounter"})
/*     */ public class DSAKeyValueType
/*     */ {
/*     */   @XmlElement(name="P")
/*     */   protected byte[] p;
/*     */   @XmlElement(name="Q")
/*     */   protected byte[] q;
/*     */   @XmlElement(name="G")
/*     */   protected byte[] g;
/*     */   @XmlElement(name="Y", required=true)
/*     */   protected byte[] y;
/*     */   @XmlElement(name="J")
/*     */   protected byte[] j;
/*     */   @XmlElement(name="Seed")
/*     */   protected byte[] seed;
/*     */   @XmlElement(name="PgenCounter")
/*     */   protected byte[] pgenCounter;
/*     */   
/*     */   public byte[] getP()
/*     */   {
/*  81 */     return this.p;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setP(byte[] value)
/*     */   {
/*  92 */     this.p = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getQ()
/*     */   {
/* 103 */     return this.q;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setQ(byte[] value)
/*     */   {
/* 114 */     this.q = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getG()
/*     */   {
/* 125 */     return this.g;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setG(byte[] value)
/*     */   {
/* 136 */     this.g = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getY()
/*     */   {
/* 147 */     return this.y;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setY(byte[] value)
/*     */   {
/* 158 */     this.y = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getJ()
/*     */   {
/* 169 */     return this.j;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setJ(byte[] value)
/*     */   {
/* 180 */     this.j = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getSeed()
/*     */   {
/* 191 */     return this.seed;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setSeed(byte[] value)
/*     */   {
/* 202 */     this.seed = ((byte[])value);
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public byte[] getPgenCounter()
/*     */   {
/* 213 */     return this.pgenCounter;
/*     */   }
/*     */   
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */ 
/*     */   public void setPgenCounter(byte[] value)
/*     */   {
/* 224 */     this.pgenCounter = ((byte[])value);
/*     */   }
/*     */ }


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\domain\DSAKeyValueType.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */