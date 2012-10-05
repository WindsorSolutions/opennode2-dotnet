package com.windsor.node.hyperjaxb3;

import org.jvnet.hyperjaxb3.ejb.jpa2.strategy.processor.PersistenceMarshaller;

import com.sun.codemodel.JCodeModel;
import com.sun.java.xml.ns.persistence.Persistence;

/**
 * The purpose of this class is to suppress the generation of a
 * META-INF/persistence file.
 *
 */
public class NoopPersistenceMarshaller extends PersistenceMarshaller {

	@Override
	public void marshallPersistence(final JCodeModel codeModel, final Persistence persistence)
			throws Exception {
	}

}
