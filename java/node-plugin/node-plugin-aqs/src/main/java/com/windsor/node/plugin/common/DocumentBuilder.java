package com.windsor.node.plugin.common;

import com.windsor.node.common.domain.ProcessContentResult;
import javax.sql.DataSource;

public abstract interface DocumentBuilder
{
  public abstract void buildDocument(DataSource paramDataSource, String paramString, ProcessContentResult paramProcessContentResult);
  
  public abstract void buildDocument(DataSource paramDataSource, String paramString, ProcessContentResult paramProcessContentResult, int paramInt);
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\DocumentBuilder.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */