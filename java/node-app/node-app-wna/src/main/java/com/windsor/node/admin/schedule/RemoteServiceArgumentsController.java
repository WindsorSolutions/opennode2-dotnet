package com.windsor.node.admin.schedule;

import java.util.ArrayList;
import java.util.List;
import javax.servlet.http.HttpServletRequest;
import org.apache.commons.collections.FactoryUtils;
import org.apache.commons.collections.list.LazyList;
import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.ScheduleArgument;
import com.windsor.node.common.domain.ScheduledItem;
import com.windsor.node.common.service.admin.ScheduleService;

@Controller
public class RemoteServiceArgumentsController
{
    private ScheduleService scheduleService;
    private String formView;

    @RequestMapping(method = RequestMethod.GET)
    public ModelAndView get(@RequestParam String scheduleId, Model model, HttpServletRequest request)
    {
        NodeVisit visit = VisitUtils.getVisit(request);
        @SuppressWarnings("unchecked")
        List<ScheduleArgument> scheduleArguments = (List<ScheduleArgument>)LazyList.decorate(new ArrayList<ScheduleArgument>(),
                                                                                             FactoryUtils.instantiateFactory(ScheduleArgument.class));
        if(StringUtils.isNotEmpty(scheduleId))
        {
            ScheduledItem item = getScheduleService().get(scheduleId, visit);
            scheduleArguments.addAll(item.getScheduleArguments());
        }

        model.addAttribute("scheduleArguments", scheduleArguments);
        return new ModelAndView(getFormView());
    }

    //No POST is necessary as the form is part of the EditScheduleController
    /*@RequestMapping(method = RequestMethod.POST)
    public ModelAndView post(@ModelAttribute BatchAddressUploadFile commandModel model, HttpServletRequest request)
    {
        //model.
        return null;
    }*/

    public ScheduleService getScheduleService()
    {
        return scheduleService;
    }

    public void setScheduleService(ScheduleService scheduleService)
    {
        this.scheduleService = scheduleService;
    }

    public String getFormView()
    {
        return formView;
    }

    public void setFormView(String formView)
    {
        this.formView = formView;
    }
}
