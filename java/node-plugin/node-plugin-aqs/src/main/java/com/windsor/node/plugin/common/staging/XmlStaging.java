package com.windsor.node.plugin.common.staging;

import com.windsor.node.plugin.common.dao.TextLoader;
import java.util.List;
import java.util.Map;

public abstract interface XmlStaging
{
  public abstract void execute(StringBuffer paramStringBuffer, boolean paramBoolean);
  
  public abstract int getBatchSize();
  
  public abstract void setBatchSize(int paramInt);
  
  public abstract List getListNames();
  
  public abstract Map getListElementMap();
  
  public abstract String getDocumentOpen();
  
  public abstract String getDocumentClose();
  
  public abstract String getStartTag(String paramString);
  
  public abstract String getEndTag(String paramString);
  
  public abstract void setTextLoader(TextLoader paramTextLoader);
  
  public abstract TextLoader getTextLoader();
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\staging\XmlStaging.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */