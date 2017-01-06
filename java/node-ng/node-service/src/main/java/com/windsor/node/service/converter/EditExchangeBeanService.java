package com.windsor.node.service.converter;

import com.windsor.node.domain.edit.EditExchangeBean;
import com.windsor.node.domain.entity.Exchange;

public interface EditExchangeBeanService {

    EditExchangeBean toBean(Exchange exchange);

    Exchange save(EditExchangeBean bean);

}
