package com.windsor.node.web.theme;

import de.agilecoders.wicket.core.settings.Theme;
import org.apache.wicket.request.cycle.RequestCycle;
import org.apache.wicket.request.handler.resource.ResourceReferenceRequestHandler;
import org.apache.wicket.request.resource.PackageResourceReference;
import org.apache.wicket.request.resource.ResourceReference;

/**
 * A Bootstrap theme for the Node application.
 */
public class NodeTheme extends Theme {

    public NodeTheme() {
        this("node");
    }

    public NodeTheme(final String theme) {
        super(theme, NodeLessReference.instance());
    }

    public static ResourceReference getLargeImage() {
        return new PackageResourceReference(NodeTheme.class, "img/windsor-brand-mark-solid-lg.png");
    }

    public static ResourceReference getMediumImage() {
        return new PackageResourceReference(NodeTheme.class, "img/windsor-brand-mark-solid-med.png");
    }

    public static ResourceReference getSmallImage() {
        return new PackageResourceReference(NodeTheme.class, "img/windsor-brand-mark-solid-sm.png");
    }

    public static ResourceReference getTankIcon() {
        return new PackageResourceReference(NodeTheme.class, "img/tank.png");
    }

    public static ResourceReference getFacilityIcon() {
        return new PackageResourceReference(NodeTheme.class, "img/facility.png");
    }

    public static String getResourceUrl(ResourceReference resourceReference) {
        return RequestCycle.get().urlFor(new ResourceReferenceRequestHandler(resourceReference)).toString();
    }
}
