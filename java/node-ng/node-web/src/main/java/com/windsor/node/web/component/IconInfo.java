package com.windsor.node.web.component;

import de.agilecoders.wicket.core.markup.html.bootstrap.image.IconType;

public class IconInfo {

    public enum IconStyle {

        WARNING("text-warning"),
        INFO("text-info"),
        SUCCESS("text-success");

        private String cssClass;

        IconStyle(String cssClass) {
            this.cssClass = cssClass;
        }

        public String getCssClass() {
            return cssClass;
        }

    }

    private IconType icon;
    private IconStyle style;

    public IconInfo(IconType icon, IconStyle style) {
        this.icon = icon;
        this.style = style;
    }

    public IconType getIcon() {
        return icon;
    }

    public IconStyle getStyle() {
        return style;
    }

}
