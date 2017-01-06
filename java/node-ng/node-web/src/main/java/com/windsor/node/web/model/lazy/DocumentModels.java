package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.entity.DocumentType;

/**
 * Provides lazy models for the Document object.
 */
public class DocumentModels {

    public static final LazyModel<String> NAME = model(from(Document.class).getName());
    public static final LazyModel<DocumentType> TYPE = model(from(Document.class).getType());

    private DocumentModels() {

    }

    public static IModel<String> bindName(IModel<Document> model) {
        return NAME.bind(model);
    }

    public static IModel<DocumentType> bindType(IModel<Document> model) {
        return TYPE.bind(model);
    }

}
