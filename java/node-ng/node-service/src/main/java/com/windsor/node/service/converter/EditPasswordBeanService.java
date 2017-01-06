package com.windsor.node.service.converter;

import com.windsor.node.domain.NaasException;
import com.windsor.node.domain.edit.EditPasswordBean;
import com.windsor.node.domain.entity.Account;

public interface EditPasswordBeanService {

    void changePassword(EditPasswordBean bean, Account adminAccount) throws NaasException;

}
