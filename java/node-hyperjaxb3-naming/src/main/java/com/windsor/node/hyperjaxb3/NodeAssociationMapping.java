package com.windsor.node.hyperjaxb3;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import javax.persistence.Embeddable;

import org.jvnet.hyperjaxb3.ejb.strategy.mapping.DefaultAssociationMapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;

import com.sun.java.xml.ns.persistence.orm.AssociationOverride;
import com.sun.java.xml.ns.persistence.orm.JoinColumn;
import com.sun.tools.xjc.outline.FieldOutline;

/**
 * Overrides the {@link DefaultAssociationMapping} to ensure that a default
 * {@link JoinColumn} annotation has a name attribute. This is necessary for
 * classes that don't define PKs (e.g., {@link Embeddable}). Also removes empty
 * {@link AssociationOverride} annotations which lead to the undoing of the
 * annotations on the {@link Embeddable} class.
 *
 */
public class NodeAssociationMapping extends DefaultAssociationMapping {

	@Override
	public void createAssociationOverride(final Mapping context, final FieldOutline fieldOutline,
			final List<AssociationOverride> associationOverrides) {
		super.createAssociationOverride(context, fieldOutline, associationOverrides);
		/*
		 * Remove empty @AssociationOverride annotations.
		 */
		final Collection<AssociationOverride> emptyOverrides = new ArrayList<AssociationOverride>();
		for (final AssociationOverride associationOverride : associationOverrides) {
			if (associationOverride.getJoinColumn().isEmpty()
					&& associationOverride.getJoinTable() == null) {
				emptyOverrides.add(associationOverride);
			}
		}
		associationOverrides.removeAll(emptyOverrides);
	}

	@Override
	public void createJoinColumns(final Mapping context, final FieldOutline fieldOutline,
			final Collection<FieldOutline> idFieldOutlines, final List<JoinColumn> joinColumns) {
		super.createJoinColumns(context, fieldOutline, idFieldOutlines, joinColumns);
		postJoinColumnCreation(context, fieldOutline, idFieldOutlines, joinColumns);
	}

	@Override
	public void createElementCollection$CollectionTable$JoinColumns(final Mapping context,
			final FieldOutline fieldOutline, final Collection<FieldOutline> idFieldOutlines,
			final List<JoinColumn> joinColumns) {
		super.createElementCollection$CollectionTable$JoinColumns(context, fieldOutline,
				idFieldOutlines, joinColumns);
		postJoinColumnCreation(context, fieldOutline, idFieldOutlines, joinColumns);
	}

	/**
	 * Called after {@link JoinColumn} annotations have been created. Ensures
	 * that every {@link JoinColumn} has a name.
	 *
	 * @param context
	 * @param fieldOutline
	 * @param idFieldOutlines
	 * @param joinColumns
	 */
	protected void postJoinColumnCreation(final Mapping context, final FieldOutline fieldOutline,
			final Collection<FieldOutline> idFieldOutlines, final List<JoinColumn> joinColumns) {
		if (joinColumns.size() == 1 && joinColumns.get(0).getName() == null) {
			joinColumns.get(0).setName(
					context.getNaming().getJoinColumn$Name(context, fieldOutline, null));
		}
	}

}
