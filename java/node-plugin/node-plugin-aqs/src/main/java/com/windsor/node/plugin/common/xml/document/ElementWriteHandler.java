package com.windsor.node.plugin.common.xml.document;

import com.windsor.node.plugin.common.xml.stream.ElementWriter;

public abstract interface ElementWriteHandler<T>
{
  public abstract void handle(ElementWriter paramElementWriter, T paramT);
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\document\ElementWriteHandler.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */