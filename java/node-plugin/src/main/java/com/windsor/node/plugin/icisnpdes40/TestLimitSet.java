package com.windsor.node.plugin.icisnpdes40;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;

import com.windsor.node.plugin.icisnpdes40.generated.Document;

public class TestLimitSet {

	/**
	 * @param args
	 * @throws JAXBException 
	 */
	public static void main(String[] args) throws JAXBException {
        
		TestLimitSet ls = new TestLimitSet();
		ls.doIt();
	}

	
	public void doIt() throws JAXBException {
		
		Document document = new Document();
		
		JAXBContext context = JAXBContext.newInstance(
        		"com.windsor.node.plugin.icisnpdes40.generated");
        
        Marshaller m = context.createMarshaller();
        m.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
        m.marshal(document, System.out);
	}
	
}
