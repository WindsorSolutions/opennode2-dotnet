package com.windsor.node.hyperjaxb3;

import java.util.Collection;

import javax.persistence.Embeddable;
import javax.persistence.Id;
import javax.persistence.JoinTable;

import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.OneToManyMapping;

import com.sun.java.xml.ns.persistence.orm.JoinColumn;
import com.sun.java.xml.ns.persistence.orm.OneToMany;
import com.sun.tools.xjc.Options;
import com.sun.tools.xjc.model.CCustomizations;
import com.sun.tools.xjc.model.CPluginCustomization;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Customization of {@link OneToManyMapping} to not suppress {@link JoinColumn}
 * and {@link JoinTable} annotations if the containing class does not have an
 * {@link Id}, as is the case for an {@link Embeddable} class. This particular
 * problem has been fixed in version 0.5.7-SNAPSHOT of the hyperjaxb3 plugin,
 * but version 0.5.7-SNAPSHOT is not available in a public repo. When it is,
 * this class may be removed (it will also need to be removed from the
 * applicationContext.xml).
 *
 */
public class NodeOneToManyMapping extends OneToManyMapping {

	@Override
	public OneToMany process(final Mapping context, final FieldOutline fieldOutline,
			final Options options) {
		final CCustomizations customizations = fieldOutline.getPropertyInfo().getCustomizations();
		if (customizations != null && (!customizations.isEmpty())) {
			final CPluginCustomization customization = customizations.get(0);
			if ("element-collection".equals(customization.element.getNodeName())) {
				// add the customizations
				// the problem is that we can't return a OneToMany...
			}
		}
		// if there is an @ElementCollection customization, then just add it; otherwise, do the default
		return super.process(context, fieldOutline, options);
	}

	/*
	 * Code copied from {@link OneToManyMapping}. However, the logic to clear the
	 * join column/table if the class does not have an id has been commented
	 * out.
	 *
	 * (non-Javadoc)
	 *
	 * @see org.jvnet.hyperjaxb3.ejb.strategy.mapping.OneToManyMapping#
	 * createOneToMany$JoinTableOrJoinColumn
	 * (org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping,
	 * com.sun.tools.xjc.outline.FieldOutline,
	 * com.sun.java.xml.ns.persistence.orm.OneToMany)
	 */
	@Override
	public void createOneToMany$JoinTableOrJoinColumn(final Mapping context,
			final FieldOutline fieldOutline, final OneToMany oneToMany) {

		if (!oneToMany.getJoinColumn().isEmpty()) {
			final Collection<FieldOutline> idFieldsOutline = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			/*
			 * Commented out to allow a @JoinColumn annotation to be associated
			 * with a @OneToMany annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (idFieldsOutline.isEmpty()) {
			// oneToMany.getJoinColumn().clear();
			// }
			context.getAssociationMapping().createJoinColumns(context, fieldOutline,
					idFieldsOutline, oneToMany.getJoinColumn());
		} else if (oneToMany.getJoinTable() != null) {
			final Collection<FieldOutline> sourceIdFieldOutlines = context.getAssociationMapping()
					.getSourceIdFieldsOutline(context, fieldOutline);
			final Collection<FieldOutline> targetIdFieldOutlines = context.getAssociationMapping()
					.getTargetIdFieldsOutline(context, fieldOutline);

			/*
			 * Commented out to allow a @JoinTable annotation to be associated
			 * with a @OneToMany annotation for an @Embeddable class which does
			 * not have an id.
			 */
			// if (sourceIdFieldOutlines.isEmpty()) {
			// oneToMany.setJoinTable(null);
			// } else {
			context.getAssociationMapping().createJoinTable(context, fieldOutline,
					sourceIdFieldOutlines, targetIdFieldOutlines, oneToMany.getJoinTable());
			// }
		}
	}

}
