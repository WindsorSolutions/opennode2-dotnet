package com.windsor.node.web.behavior;

import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.InputStream;

import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.model.IModel;
import org.apache.wicket.util.resource.AbstractResourceStream;
import org.apache.wicket.util.resource.IResourceStream;
import org.apache.wicket.util.resource.ResourceStreamNotFoundException;

import com.windsor.node.domain.entity.Document;
import com.windsor.stack.web.wicket.behavior.AjaxDownload;

public class DownloadDocumentBehavior extends AjaxDownload {

    private IModel<Document> model;

    public DownloadDocumentBehavior() {
        super(Boolean.TRUE);
    }

    public void initiate(AjaxRequestTarget target, IModel<Document> model) {
        this.model = model;
        initiate(target);
    }

    @Override
    public void detach(Component component) {
        super.detach(component);
        if (model != null) {
            model.detach();
        }
    }

    @Override
    protected IResourceStream getResourceStream() {
        return new AbstractResourceStream() {

            @Override
            public InputStream getInputStream() throws ResourceStreamNotFoundException {
                return new ByteArrayInputStream(model.getObject().getContent());
            }

            @Override
            public void close() throws IOException {
            }


        };
    }

    @Override
    protected String getFileName() {
        return model.getObject().getName();
    }

}
