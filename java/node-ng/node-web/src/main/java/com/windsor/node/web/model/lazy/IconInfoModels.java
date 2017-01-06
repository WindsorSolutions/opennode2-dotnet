package com.windsor.node.web.model.lazy;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.IconInfo.IconStyle;

import de.agilecoders.wicket.core.markup.html.bootstrap.image.IconType;

public class IconInfoModels {

    public static final LazyModel<IconType> ICON_TYPE = LazyModel.model(LazyModel.from(IconInfo.class).getIcon());
    public static final LazyModel<IconStyle> ICON_STYLE = LazyModel.model(LazyModel.from(IconInfo.class).getStyle());

    private IconInfoModels() {
        super();
    }

    public static LazyModel<IconType> bindIconType(IModel<IconInfo> model) {
        return ICON_TYPE.bind(model);
    }

    public static LazyModel<IconStyle> bindIconStyle(IModel<IconInfo> model) {
        return ICON_STYLE.bind(model);
    }

}
