package com.windsor.node.web.behavior;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.model.IModel;
import org.apache.wicket.util.resource.AbstractResourceStream;
import org.apache.wicket.util.resource.IResourceStream;
import org.apache.wicket.util.resource.ResourceStreamNotFoundException;

import com.windsor.stack.web.wicket.behavior.AjaxDownload;

public class DownloadTempFileBehavior extends AjaxDownload {

    private IModel<File> model;

    public DownloadTempFileBehavior() {
        super(Boolean.TRUE);
    }

    public void initiate(AjaxRequestTarget target, IModel<File> model) {
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
                try {
                    return new FileInputStream(model.getObject());
                } catch (FileNotFoundException e) {
                    throw new ResourceStreamNotFoundException(e);
                }
            }

            @Override
            public void close() throws IOException {
                model.getObject().delete();
            }

        };
    }

    @Override
    protected String getFileName() {
        return model.getObject().getName();
    }

}
