package com.windsor.node.admin.schedule;

import javax.servlet.http.HttpServletRequest;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

@Controller
@RequestMapping("/schedule-angular.htm")
public class AngularScheduleController
{
    @RequestMapping(method = RequestMethod.GET)
    public ModelAndView get(@RequestParam String scheduleId, Model model, HttpServletRequest request)
    {
        return null;
    }

    @RequestMapping(method = RequestMethod.POST)
    public ModelAndView post(@RequestParam String scheduleId, Model model, HttpServletRequest request)
    {
        return null;
    }
}
