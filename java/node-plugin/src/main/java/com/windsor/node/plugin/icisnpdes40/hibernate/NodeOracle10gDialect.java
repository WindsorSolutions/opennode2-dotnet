package com.windsor.node.plugin.icisnpdes40.hibernate;

import java.sql.Types;

import org.hibernate.dialect.Oracle10gDialect;
import org.hibernate.type.StandardBasicTypes;

/**
 * Extension of the standard Oracle 10g Hibernate dialect which allows DB
 * char(1) columns to be mapped to Strings.
 *
 */
public class NodeOracle10gDialect extends Oracle10gDialect {

	/**
	 * Constructor.
	 */
	public NodeOracle10gDialect() {
		super();
		registerHibernateType(Types.CHAR, StandardBasicTypes.STRING.getName());
		registerHibernateType(Types.VARCHAR, StandardBasicTypes.CHARACTER.getName() );
		registerHibernateType(Types.VARCHAR, 1, StandardBasicTypes.CHARACTER.getName() );
	}

}
