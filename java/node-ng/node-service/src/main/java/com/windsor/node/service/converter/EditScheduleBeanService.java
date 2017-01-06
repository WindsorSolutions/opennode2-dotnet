package com.windsor.node.service.converter;

import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.Schedule;

public interface EditScheduleBeanService {

    EditScheduleBean toBean(Schedule schedule);

    EditScheduleBean refreshBeanArguments(EditScheduleBean bean);

    Schedule save(EditScheduleBean bean);

}
