package com.windsor.node.web.component;

import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;

import com.windsor.node.web.component.IconInfo.IconStyle;
import com.windsor.node.web.model.lazy.IconInfoModels;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.behavior.CssClassNameAppender;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.Icon;

public class StyledIcon extends Panel {

    public StyledIcon(String id, IModel<IconInfo> model) {
        super(id, model);
        add(new Icon("icon", IconInfoModels.bindIconType(model)));
        add(new CssClassNameAppender(new CssClassNameModel(IconInfoModels.bindIconStyle(model))));
    }

    private static final class CssClassNameModel extends LoadableDetachableWrappedModel<String, IconStyle> {

        public CssClassNameModel(IModel<IconStyle> wrappedModel) {
            super(wrappedModel);
        }

        @Override
        protected String load() {
            IconStyle iconStyle = getWrappedModel().getObject();
            return iconStyle == null ? null : iconStyle.getCssClass();
        }

    }

}
