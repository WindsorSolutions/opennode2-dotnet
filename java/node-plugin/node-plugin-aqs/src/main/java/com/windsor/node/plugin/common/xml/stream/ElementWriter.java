package com.windsor.node.plugin.common.xml.stream;

import java.io.OutputStream;
import javax.xml.bind.JAXBElement;

public abstract interface ElementWriter
{
  public abstract void open(OutputStream paramOutputStream)
    throws ElementWriterException;
  
  public abstract void write(JAXBElement<?> paramJAXBElement)
    throws ElementWriterException;
  
  public abstract void close()
    throws ElementWriterException;
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\common\xml\stream\ElementWriter.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */