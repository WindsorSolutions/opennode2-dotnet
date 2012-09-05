package com.windsor.node.hyperjaxb3;

import java.util.Collection;

import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;

import org.jvnet.hyperjaxb3.ejb.strategy.mapping.ManyToOneMapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;

import com.sun.java.xml.ns.persistence.orm.Embeddable;
import com.sun.java.xml.ns.persistence.orm.ManyToOne;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Customization of {@link ManyToOneMapping} to not suppress {@link JoinColumn}
 * and {@link JoinTable} annotations if the containing class does not have an
 * {@link Id}, as is the case for an {@link Embeddable} class. This particular
 * problem has been fixed in version 0.5.7-SNAPSHOT of the hyperjaxb3 plugin,
 * but version 0.5.7-SNAPSHOT is not available in a public repo. When it is,
 * this class may be removed (it will also need to be removed from the
 * applicationContext.xml).
 *
 */
public class NodeManyToOneMapping extends ManyToOneMapping {

	/*
	 * Code copied from {@link ManyToOneMapping}. However, the logic to clear
	 * the join column/table if the class does not have an id has been commented
	 * out.
	 *
	 * (non-Javadoc)
	 *
	 * @see org.jvnet.hyperjaxb3.ejb.strategy.mapping.ManyToOneMapping#
	 * createManyToOne$JoinTableOrJoinColumn
	 * (org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping,
	 * com.sun.tools.xjc.outline.FieldOutline,
	 * com.sun.java.xml.ns.persistence.orm.ManyToOne)
	 */
	@Override
	public void createManyToOne$JoinTableOrJoinColumn(final Mapping context,
			final FieldOutline fieldOutline, final ManyToOne manyToOne) {

		if (manyToOne.getJoinColumn() != null && !manyToOne.getJoinColumn().isEmpty()) {
			final Collection<FieldOutline> idFieldsOutline = context.getAssociationMapping()
					.getTargetIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @JoinColumn annotation to be associated
			 * with a @ManyToOne annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (idFieldsOutline.isEmpty()) {
			// manyToOne.getJoinColumn().clear();
			// }
			context.getAssociationMapping().createJoinColumns(context, fieldOutline,
					idFieldsOutline, manyToOne.getJoinColumn());
		} else if (manyToOne.getJoinTable() != null) {
			final Collection<FieldOutline> sourceIdFieldOutlines = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			final Collection<FieldOutline> targetIdFieldOutlines = context.getAssociationMapping()
					.getTargetIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @JoinTable annotation to be associated
			 * with a @ManyToOne annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (sourceIdFieldOutlines.isEmpty()) {
			// manyToOne.setJoinTable(null);
			// } else {
			context.getAssociationMapping().createJoinTable(context, fieldOutline,
					sourceIdFieldOutlines, targetIdFieldOutlines, manyToOne.getJoinTable());
			// }
		}
	}

}
