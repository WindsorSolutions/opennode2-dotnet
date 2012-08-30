package com.windsor.node.hyperjaxb3;

import org.jvnet.hyperjaxb3.ejb.jpa2.strategy.mapping.EmbeddableAttributesMapping;
import org.jvnet.hyperjaxb3.ejb.strategy.mapping.Mapping;

import com.sun.java.xml.ns.persistence.orm.Attributes;
import com.sun.java.xml.ns.persistence.orm.EmbeddableAttributes;
import com.sun.tools.xjc.Options;
import com.sun.tools.xjc.outline.ClassOutline;

public class NodeEmbeddableAttributesMapping extends EmbeddableAttributesMapping {

	@Override
	public EmbeddableAttributes process(final Mapping context, final ClassOutline classOutline,
			final Options options) {

		//final Entity entity = context.getCustomizing().getEntity(classOutline);

		final Attributes attributes = context.getAttributesMapping().process(context, classOutline,
				options);

//		final ClassOutlineMapping c = context.getAttributesMapping();
//		System.out.println("** " + context.getAttributesMapping());
//		System.out.println("-->" + classOutline.target.shortName + ", attributes class="
//				+ attributes.getClass() + ", c=" + c + ", classOutline=" + classOutline +
//				", context=" + context);
//		for (final ElementCollection ec : attributes.getElementCollection()) {
//			System.out.println("--->" + ec.getName());
//			for (final JoinColumn jc : ec.getCollectionTable().getJoinColumn()) {
//				System.out.println("---->" + jc.getName());
//			}
//		}

		final EmbeddableAttributes embeddableAttributes = new EmbeddableAttributes();

		embeddableAttributes.getBasic().addAll(attributes.getBasic());
		embeddableAttributes.getManyToOne().addAll(attributes.getManyToOne());
		embeddableAttributes.getOneToMany().addAll(attributes.getOneToMany());
		embeddableAttributes.getOneToOne().addAll(attributes.getOneToOne());
		embeddableAttributes.getManyToMany().addAll(attributes.getManyToMany());
		embeddableAttributes.getElementCollection().addAll(attributes.getElementCollection());
		embeddableAttributes.getEmbedded().addAll(attributes.getEmbedded());
		embeddableAttributes.getTransient().addAll(attributes.getTransient());

		// TODO Report errors
		// for (Id id : attributes.getId()) {
		// final Basic basic = new Basic();
		// basic.setName(id.getName());
		// basic.setAccess(id.getAccess());
		// basic.setColumn(id.getColumn());
		// basic.setTemporal(id.getTemporal());
		// embeddableAttributes.getBasic().add(basic);
		// }
		// for (Version version : attributes.getVersion()) {
		// final Basic basic = new Basic();
		// basic.setName(version.getName());
		// basic.setAccess(version.getAccess());
		// basic.setColumn(version.getColumn());
		// basic.setTemporal(version.getTemporal());
		// embeddableAttributes.getBasic().add(basic);
		// }
		// if (attributes.getEmbeddedId() != null) {
		// final EmbeddedId embeddedId = attributes.getEmbeddedId();
		// final Embedded embedded = new Embedded();
		// embedded.setName(embeddedId.getName());
		// embedded.setAccess(embeddedId.getAccess());
		// embedded.getAttributeOverride().addAll(
		// embeddedId.getAttributeOverride());
		// embeddableAttributes.getEmbedded().add(embedded);
		// }
		return embeddableAttributes;
	}
}
