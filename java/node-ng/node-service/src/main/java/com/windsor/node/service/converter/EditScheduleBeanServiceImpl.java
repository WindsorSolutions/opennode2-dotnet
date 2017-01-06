package com.windsor.node.service.converter;

import java.io.IOException;
import java.sql.Timestamp;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.function.Function;
import java.util.stream.Collectors;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.data.dao.ParameterSpecifiedPlugin;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.domain.edit.EditScheduleArgumentBean;
import com.windsor.node.domain.edit.EditScheduleBean;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleArgument;
import com.windsor.node.domain.entity.ScheduleTargetType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.repo.ScheduleRepository;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.service.PartnerService;
import com.windsor.node.service.PluginService;
import com.windsor.node.worker.util.ScheduleUtil;

@Service
@Transactional(readOnly = false)
public class EditScheduleBeanServiceImpl implements EditScheduleBeanService {

    private static final Logger LOGGER = LoggerFactory.getLogger(EditScheduleBeanServiceImpl.class);

    @Autowired
    private PartnerService partnerService;

    @Autowired
    private PluginService pluginService;

    @Autowired
    private ExchangeService exchangeService;

    @Autowired
    private ExchangeServiceService exchangeServiceService;

    @Autowired
    private ScheduleRepository scheduleRepo;

    @Override
    public EditScheduleBean toBean(Schedule schedule) {
        EditScheduleBean bean = new EditScheduleBean();

        bean.setActive(schedule.getActive());
        LocalDateTime end = schedule.getEnd();
        bean.setEnd(end == null ? null : Date.from(end.atZone(ZoneId.systemDefault()).toInstant()));
        bean.setExchangeId(schedule.getExchange().getId());
        bean.setFrequency(schedule.getFrequency());
        bean.setFrequencyType(schedule.getScheduleFrequencyType());
        bean.setId(schedule.getId());
        bean.setName(schedule.getName());
        LocalDateTime start = schedule.getStart();
        bean.setStart(start == null ? null : Date.from(start.atZone(ZoneId.systemDefault()).toInstant()));

        setBeanSourceInfo(schedule, bean);
        setBeanTargetInfo(schedule, bean);

        return bean;
    }

    private List<PluginServiceParameterDescriptor> getParameters(Exchange exchange, String implementor) {
        List<PluginServiceParameterDescriptor> parameters = Collections.emptyList();
        BaseWnosPlugin plugin;
        try {
            plugin = pluginService.getPlugin(exchange, implementor);
            parameters = ((ParameterSpecifiedPlugin) plugin).getParameters();
        } catch (IOException e) {
            LOGGER.error("Error getting plugin: " + exchange.getName() + " - " + implementor, e);
        }
        return parameters;
    }

    private void setScheduleSourceInfo(EditScheduleBean bean, Schedule schedule) {
        schedule.setSourceType(bean.getSourceType());
        String dataSource = null;
        List<ScheduleArgument> arguments = Collections.emptyList();
        switch (bean.getSourceType()) {
        case FILE:
            dataSource = bean.getSourceFilePath();
            break;
        case LOCAL_SERVICE:
            dataSource = bean.getExchangeService().getId();
            arguments = toScheduleArguments(bean.getArguments(), schedule);
            break;
        case NONE:
            break;
        case WEB_SERVICE_QUERY:
            break;
        case WEB_SERVICE_SOLICIT:
            break;
        }
        List<ScheduleArgument> list = schedule.getArguments();
        if (list == null) {
            list = new ArrayList<>();
            schedule.setArguments(list);
        } else {
            list.clear();
        }
        list.addAll(arguments);
        schedule.setDataSource(dataSource);
    }

    private List<ScheduleArgument> toScheduleArguments(List<EditScheduleArgumentBean> beanArgs, Schedule schedule) {
        Map<String, ScheduleArgument> map = schedule.getArgumentsStream()
                .collect(Collectors.toMap(ScheduleArgument::getKey, Function.identity()));
        return beanArgs.stream()
                .filter(EditScheduleArgumentBean::hasValue)
                .map(b -> map.getOrDefault(b.getKey(), new ScheduleArgument(schedule, b.getKey(), b.getValue()))
                        .value(b.getValue()))
                .collect(Collectors.toList());
    }

    private List<EditScheduleArgumentBean> toBeanArguments(Schedule schedule) {
        Map<String, ScheduleArgument> map = schedule.getArgumentsStream().collect(Collectors.toMap(ScheduleArgument::getKey, Function.identity()));
        com.windsor.node.domain.entity.ExchangeService exchangeService = exchangeServiceService.load(schedule.getDataSource());
        return getParameters(schedule.getExchange(), exchangeService.getImplementor())
            .stream()
            .map(d -> new EditScheduleArgumentBean(d.getName(),
                        map.getOrDefault(d.getName(), new ScheduleArgument(schedule, d.getName(), d.getDefaultValue())).getValue(),
                        d.getRequired()))
            .collect(Collectors.toList());
    }

    private void setBeanSourceInfo(Schedule schedule, EditScheduleBean bean) {
        bean.setSourceType(schedule.getSourceType());
        String dataSource = schedule.getDataSource();
        switch(schedule.getSourceType()) {
        case FILE:
            bean.setSourceFilePath(dataSource);
            break;
        case LOCAL_SERVICE:
            bean.setExchangeService(exchangeServiceService.load(dataSource));
            bean.setArguments(toBeanArguments(schedule));
            break;
        case NONE:
            break;
        case WEB_SERVICE_QUERY:
            break;
        case WEB_SERVICE_SOLICIT:
            break;
        }
    }

    private void setBeanTargetInfo(Schedule schedule, EditScheduleBean bean) {
        String dataTarget = schedule.getDataTarget();
        bean.setTargetType(schedule.getTargetType());
        switch (schedule.getTargetType()) {
        case EMAIL:
            bean.setTargetEmail(dataTarget);
            break;
        case FILE:
            bean.setSourceFilePath(dataTarget);
            break;
        case NONE:
            break;
        case PARTNER:
            bean.setTargetPartner(partnerService.load(dataTarget));
            break;
        case SCHEMATRON:
            break;
        }
    }

    private void setScheduleTargetInfo(EditScheduleBean bean, Schedule schedule) {
        ScheduleTargetType targetType = bean.getTargetType();
        schedule.setTargetType(targetType);
        String dataTarget = null;
        switch (targetType) {
        case EMAIL:
            dataTarget = bean.getTargetEmail();
            break;
        case FILE:
            dataTarget = bean.getTargetFilePath();
            break;
        case NONE:
            break;
        case PARTNER:
            dataTarget = bean.getTargetPartner().getId();
            break;
        case SCHEMATRON:
            break;
        }
        schedule.setDataTarget(dataTarget);
    }

    @Override
    public EditScheduleBean refreshBeanArguments(EditScheduleBean bean) {
        List<EditScheduleArgumentBean> arguments = Collections.emptyList();
        if (bean.getExchangeService() != null) {
            Map<String, EditScheduleArgumentBean> map = bean.getArguments() == null
                    ? Collections.emptyMap()
                    : bean.getArguments().stream()
                        .collect(Collectors.toMap(EditScheduleArgumentBean::getKey, Function.identity()));
            arguments = getParameters(exchangeService.load(bean.getExchangeId()), bean.getExchangeService().getImplementor())
                .stream()
                .map(d -> map.getOrDefault(d.getName(),
                        new EditScheduleArgumentBean(d.getName(), d.getDefaultValue(), d.getRequired()))
                        .required(d.getRequired()))
                .collect(Collectors.toList());

        }
        bean.setArguments(arguments);
        return bean;
    }

    @Transactional(readOnly = false)
    @Override
    public Schedule save(EditScheduleBean bean) {
        String scheduleId = bean.getId();
        Schedule schedule = null;
        if (scheduleId != null) {
            schedule = scheduleRepo.findOne(scheduleId);
        } else {
            Exchange exchange = exchangeService.load(bean.getExchangeId());
            schedule = Schedule.newDefault(exchange);
        }
        
        LocalDateTime newStart = toLocalDateTime(bean.getStart());
        LocalDateTime newEnd = toLocalDateTime(bean.getEnd());
        
        boolean recalculateNextRunDate = 
        		!(Objects.equals(newStart, schedule.getStart()) 
        				&& Objects.equals(newEnd, schedule.getEnd())
        				&& Objects.equals(bean.getFrequency(), schedule.getFrequency())
        				&& Objects.equals(bean.getFrequencyType(), schedule.getScheduleFrequencyType())
        				&& Objects.equals(bean.isActive(), schedule.getActive()));
        
        schedule.setActive(bean.isActive());
        schedule.setStart(newStart);
        schedule.setEnd(newEnd);

        schedule.setFrequency(bean.getFrequency());
        schedule.setScheduleFrequencyType(bean.getFrequencyType());
        schedule.setName(bean.getName());

        setScheduleSourceInfo(bean, schedule);
        setScheduleTargetInfo(bean, schedule);
        
        /*
         * If either the start or end date has changed, recalculate the next run date.
         */
        if (recalculateNextRunDate) {
        	schedule = setNextRun(schedule);
        }

        return scheduleRepo.save(schedule);
    }
    
    private static LocalDateTime toLocalDateTime(Date date) {
    	return date == null ? null : LocalDateTime.ofInstant(date.toInstant(), ZoneId.systemDefault());
    }
    
    private Schedule setNextRun(Schedule schedule) {
        Timestamp next = null;

        ScheduledItem scheduledItem = new ScheduledItem();
        if(schedule.getStart() != null) {
            scheduledItem.setStartOn(Timestamp.valueOf(schedule.getStart()));
        }
        if(schedule.getEnd() != null) {
            scheduledItem.setEndOn(Timestamp.valueOf(schedule.getEnd()));
        }
        if(schedule.getLastExecution() != null) {
            scheduledItem.setLastExecutedOn(Timestamp.valueOf(schedule.getLastExecution()));
        }
        if(schedule.getNextStart() != null) {
            scheduledItem.setNextRunOn(Timestamp.valueOf(schedule.getNextStart()));
        }

        scheduledItem.setFrequency(schedule.getFrequency());
        scheduledItem.setFrequencyType(
                com.windsor.node.common.domain.ScheduleFrequencyType.valueOf(schedule.getScheduleFrequencyType().name()));

        next = ScheduleUtil.calculateNextRun(scheduledItem);

        if(schedule.getLastExecution() != null && (schedule.getLastExecution().isAfter(LocalDateTime.now()))) {
            schedule.setLastExecution(LocalDateTime.now());
        }

        if(next != null) {
            schedule.setNextStart(next.toLocalDateTime());
        } else {
            schedule.setNextStart(null);
        }

        return schedule;
    }

}
