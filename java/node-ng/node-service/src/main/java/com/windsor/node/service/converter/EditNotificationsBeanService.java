package com.windsor.node.service.converter;

import com.windsor.node.domain.edit.EditNotificationsBean;
import com.windsor.node.domain.entity.Account;

public interface EditNotificationsBeanService {

    EditNotificationsBean toBean(Account account);

    Account save(EditNotificationsBean bean);

}
