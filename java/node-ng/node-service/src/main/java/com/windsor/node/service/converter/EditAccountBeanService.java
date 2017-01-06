package com.windsor.node.service.converter;

import com.windsor.node.domain.edit.EditAccountBean;
import com.windsor.node.domain.entity.Account;

public interface EditAccountBeanService {

    EditAccountBean toBean(Account account);

    Account save(EditAccountBean bean);

}
