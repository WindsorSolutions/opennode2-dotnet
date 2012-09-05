package com.windsor.node.hyperjaxb3;

import java.util.Collection;

import javax.persistence.Embeddable;
import javax.persistence.Id;
import javax.persistence.JoinColumn;

import org.jvnet.hyperjaxb3.ejb.strategy.mapping.ElementCollectionMapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;

import com.sun.java.xml.ns.persistence.orm.CollectionTable;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Customization of {@link ElementCollectionMapping} to not suppress
 * {@link JoinColumn} annotations if the containing class does not have an
 * {@link Id}, as is the case for an {@link Embeddable} class. This particular
 * problem has been reported here: http://jira.highsource.org/browse/HJIII-98.
 * When it is fixed, this class may be removed (it will also need to be removed
 * from the applicationContext.xml).
 *
 */
public class NodeElementCollectionMapping extends ElementCollectionMapping {

	/*
	 * Code copied from {@link ElementCollectionMapping}. However, the logic to
	 * clear the join column if the class does not have an id has been commented
	 * out.
	 *
	 * (non-Javadoc)
	 *
	 * @see org.jvnet.hyperjaxb3.ejb.strategy.mapping.ElementCollectionMapping#
	 * createElementCollection$CollectionTable$JoinColumn
	 * (org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping,
	 * com.sun.tools.xjc.outline.FieldOutline,
	 * com.sun.java.xml.ns.persistence.orm.CollectionTable)
	 */
	@Override
	public void createElementCollection$CollectionTable$JoinColumn(final Mapping context,
			final FieldOutline fieldOutline, final CollectionTable collectionTable) {

		final Collection<FieldOutline> idFieldsOutline = context.getAssociationMapping()
				.getSourceIdFieldsOutline(context, fieldOutline);
		/*
		 * Commented out to allow a @JoinColumn annotation to be associated with
		 * a @CollectionTable annotation for an @Embeddable class which does not
		 * have an id.
		 */
		// if (idFieldsOutline.isEmpty()) {
		// collectionTable.getJoinColumn().clear();
		// }
		context.getAssociationMapping().createElementCollection$CollectionTable$JoinColumns(
				context, fieldOutline, idFieldsOutline, collectionTable.getJoinColumn());
	}

}
