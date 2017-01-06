package com.windsor.node.service.converter;

import java.util.List;

import com.windsor.node.domain.edit.EditExchangeServiceBean;
import com.windsor.node.domain.edit.EditServiceArgumentBean;

public interface EditExchangeServiceBeanService {

    EditExchangeServiceBean toBean(com.windsor.node.domain.entity.ExchangeService exchangeService);

    public List<EditServiceArgumentBean> updateArguments(EditExchangeServiceBean bean);

    com.windsor.node.domain.entity.ExchangeService save(EditExchangeServiceBean bean);

}
