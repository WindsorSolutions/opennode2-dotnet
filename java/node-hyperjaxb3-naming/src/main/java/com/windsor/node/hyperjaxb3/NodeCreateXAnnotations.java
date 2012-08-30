package com.windsor.node.hyperjaxb3;

import java.util.Collection;
import java.util.Collections;

import javax.persistence.JoinColumn;

import org.jvnet.annox.model.XAnnotation;
import org.jvnet.hyperjaxb3.annotation.util.AnnotationUtils;
import org.jvnet.hyperjaxb3.ejb.jpa2.strategy.annotate.CreateXAnnotations;

import com.sun.java.xml.ns.persistence.orm.CollectionTable;
import com.sun.java.xml.ns.persistence.orm.ElementCollection;

public class NodeCreateXAnnotations extends CreateXAnnotations {

	@Override
	public Collection<XAnnotation> createElementCollectionAnnotations(
			final ElementCollection source) {
		return source == null ? Collections.<XAnnotation> emptyList()
				:
				//
				annotations(
				//
						createElementCollection(source),
						//
						createOrderBy(source.getOrderBy()),
						//
						// FIXME: explicitly commented this out
						// createOrderColumn(source.getOrderColumn()),

						//
						createMapKey(source.getMapKey()),
						//
						createMapKeyClass(source.getMapKeyClass()),
						//
						createMapKeyTemporal(source.getMapKeyTemporal()),
						//
						createMapKeyEnumerated(source.getMapKeyEnumerated()),
						//
						createAttributeOverrides(source
								.getMapKeyAttributeOverride()),
						//
						createMapKeyColumn(source.getMapKeyColumn()),
						//
						createMapKeyJoinColumns(source.getMapKeyJoinColumn()),
						//
						createColumn(source.getColumn()),
						//
						createTemporal(source.getTemporal()),
						//
						createEnumerated(source.getEnumerated()),
						//
						createLob(source.getLob()),
						//
						createAttributeOverrides(source.getAttributeOverride()),
						//
						createAssociationOverrides(source
								.getAssociationOverride()),
						//
						createCollectionTable(source.getCollectionTable()),
						//
						createAccess(source.getAccess())
				//
				);
	}

	@Override
	public XAnnotation createCollectionTable(final CollectionTable source) {
		return source == null ? null :
		//
				new XAnnotation(javax.persistence.CollectionTable.class,
				//
						AnnotationUtils.create("name", source.getName()),
						//
						AnnotationUtils.create("catalog", source.getCatalog()),
						//
						AnnotationUtils.create("schema", source.getSchema()),
						//
						AnnotationUtils.create("joinColumns",
								createJoinColumn(source.getJoinColumn()),
								JoinColumn.class),
						//
						AnnotationUtils.create("uniqueConstraints",
								createUniqueConstraint(source
										.getUniqueConstraint()),
								javax.persistence.UniqueConstraint.class)
				//
				);

	}

}
