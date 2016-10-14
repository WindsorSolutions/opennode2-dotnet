package com.windsor.node.plugin.common.persistence;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

public abstract interface CriteriaFactory<DATA, ROOT>
{
  public abstract Predicate create(Root<? extends ROOT> paramRoot, CriteriaQuery<?> paramCriteriaQuery, CriteriaBuilder paramCriteriaBuilder);
  
  public abstract void setData(DATA paramDATA);
  
  public abstract void setUntypedData(Object paramObject);
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\persistence\CriteriaFactory.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */