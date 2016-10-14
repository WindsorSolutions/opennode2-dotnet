package com.windsor.node.plugin.aqs.wsdl;

import java.net.URL;
import javax.xml.rpc.Service;
import javax.xml.rpc.ServiceException;

public abstract interface AQDEData
  extends Service
{
  public abstract String getAQDEDataSoap12Address();
  
  public abstract AQDEDataSoap getAQDEDataSoap12()
    throws ServiceException;
  
  public abstract AQDEDataSoap getAQDEDataSoap12(URL paramURL)
    throws ServiceException;
  
  public abstract String getAQDEDataSoapAddress();
  
  public abstract AQDEDataSoap getAQDEDataSoap()
    throws ServiceException;
  
  public abstract AQDEDataSoap getAQDEDataSoap(URL paramURL)
    throws ServiceException;
}


/* Location:              C:\Users\cmiles\Documents\Java Projects\AQS\AQS\_25C455FD-A159-4216-8911-704D52B3739C\aqs.jar!\com\windsor\node\plugin\aqs\wsdl\AQDEData.class
 * Java compiler version: 7 (51.0)
 * JD-Core Version:       0.7.1
 */