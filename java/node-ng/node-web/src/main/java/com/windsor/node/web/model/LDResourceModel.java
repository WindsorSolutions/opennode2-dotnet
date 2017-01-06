package com.windsor.node.web.model;

import org.apache.wicket.Application;
import org.apache.wicket.model.LoadableDetachableModel;

import com.windsor.stack.domain.IIdentifiable;
import com.windsor.stack.domain.util.ISerializableSupplier;

public class LDResourceModel<II> extends LoadableDetachableModel<String> {

    private ISerializableSupplier<IIdentifiable<String>> resourceSupplier;

    public LDResourceModel(ISerializableSupplier<IIdentifiable<String>> resourceSupplier) {
        super();
        this.resourceSupplier = resourceSupplier;
    }

    @Override
    protected String load() {
        return Application.get()
                .getResourceSettings()
                .getLocalizer()
                .getString(resourceSupplier.get().getId(), null);
    }

}
