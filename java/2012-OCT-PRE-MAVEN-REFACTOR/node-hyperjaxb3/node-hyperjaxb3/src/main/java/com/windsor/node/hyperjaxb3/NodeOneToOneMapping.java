package com.windsor.node.hyperjaxb3;

import java.util.Collection;

import javax.persistence.Embeddable;
import javax.persistence.Id;
import javax.persistence.JoinTable;

import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.OneToOneMapping;

import com.sun.java.xml.ns.persistence.orm.JoinColumn;
import com.sun.java.xml.ns.persistence.orm.OneToOne;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Customization of {@link OneToOneMapping} to not suppress {@link JoinColumn}
 * and {@link JoinTable} annotations if the containing class does not have an
 * {@link Id}, as is the case for an {@link Embeddable} class. This particular
 * problem has been fixed in version 0.5.7-SNAPSHOT of the hyperjaxb3 plugin,
 * but version 0.5.7-SNAPSHOT is not available in a public repo. When it is,
 * this class may be removed (it will also need to be removed from the
 * applicationContext.xml).
 *
 */
public class NodeOneToOneMapping extends OneToOneMapping {

	/*
	 * Code copied from {@link OneToOneMapping}. However, the logic to clear the
	 * join column/table if the class does not have an id has been commented
	 * out.
	 *
	 * (non-Javadoc)
	 * @see org.jvnet.hyperjaxb3.ejb.strategy.mapping.OneToOneMapping#createOneToOne$JoinTableOrJoinColumnOrPrimaryKeyJoinColumn(org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping, com.sun.tools.xjc.outline.FieldOutline, com.sun.java.xml.ns.persistence.orm.OneToOne)
	 */
	@Override
	public void createOneToOne$JoinTableOrJoinColumnOrPrimaryKeyJoinColumn(final Mapping context,
			final FieldOutline fieldOutline, final OneToOne oneToOne) {
		if (!oneToOne.getPrimaryKeyJoinColumn().isEmpty()) {

			final Collection<FieldOutline> idFieldOutlines = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @PrimaryKeyJoinColumn annotation to be associated
			 * with a @OneToOne annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (idFieldOutlines.isEmpty()) {
			// oneToOne.getPrimaryKeyJoinColumn().clear();
			// } else {
			context.getAssociationMapping().createPrimaryKeyJoinColumns(context, fieldOutline,
					idFieldOutlines, oneToOne.getPrimaryKeyJoinColumn());
			// }
		} else if (!oneToOne.getJoinColumn().isEmpty()) {
			final Collection<FieldOutline> idFieldsOutline = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @JoinColumn annotation to be associated
			 * with a @OneToOne annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (idFieldsOutline.isEmpty()) {
			// oneToOne.getJoinColumn().clear();
			// }
			context.getAssociationMapping().createJoinColumns(context, fieldOutline,
					idFieldsOutline, oneToOne.getJoinColumn());
		} else if (oneToOne.getJoinTable() != null) {
			final Collection<FieldOutline> sourceIdFieldOutlines = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			final Collection<FieldOutline> targetIdFieldOutlines = context.getAssociationMapping()
					.getTargetIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @JoinTable annotation to be associated
			 * with a @OneToOne annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (sourceIdFieldOutlines.isEmpty()) {
			// oneToOne.setJoinTable(null);
			// } else {
			context.getAssociationMapping().createJoinTable(context, fieldOutline,
					sourceIdFieldOutlines, targetIdFieldOutlines, oneToOne.getJoinTable());
			// }
		}
	}

}
