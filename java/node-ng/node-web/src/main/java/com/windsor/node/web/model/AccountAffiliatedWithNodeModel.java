package com.windsor.node.web.model;

import org.apache.wicket.injection.Injector;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Account;
import com.windsor.node.service.props.NaasProperties;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class AccountAffiliatedWithNodeModel extends LoadableDetachableWrappedModel<Boolean, Account>{

    @SpringBean
    private NaasProperties naasProps;

    public AccountAffiliatedWithNodeModel(IModel<Account> wrappedModel) {
        super(wrappedModel);
        Injector.get().inject(this);
    }

    @Override
    protected Boolean load() {
        String node = naasProps.getNodeId();
        Account account = getWrappedModel().getObject();
        return account.getAffiliation().equals(node);
    }

}
