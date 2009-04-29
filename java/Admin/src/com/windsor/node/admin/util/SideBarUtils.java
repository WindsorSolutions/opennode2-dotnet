/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

package com.windsor.node.admin.util;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;

import com.windsor.node.admin.domain.SideBar;

public final class SideBarUtils {
    
    private static final String ZERO = "0";
    private static final String ONE = "1";
    private static final String TWO = "2";

    private SideBarUtils() {
    }

    public static List getScheduleBars(HttpServletRequest request,
            int activeBarIndex) {

        List bars = new ArrayList();
        bars.add(new SideBar("schedule.htm?bi=0", "Manage Schedules",
                QueryStringUtils.hasPageViewIndex(request, ZERO,
                        activeBarIndex == 0)));

        return bars;

    }

    public static List getExchangeBars(HttpServletRequest request,
            int activeBarIndex) {

        List bars = new ArrayList();
        bars.add(new SideBar("flow.htm", "Manage Exchanges", QueryStringUtils
                .hasPageViewIndex(request, ZERO, activeBarIndex == 0)));

        bars.add(new SideBar("plugin-upload.htm", "Upload Plugin",
                QueryStringUtils.hasPageViewIndex(request, ONE,
                        activeBarIndex == 1)));

        return bars;

    }

    public static List getConfigBars(HttpServletRequest request,
            int activeBarIndex) {

        List bars = new ArrayList();
        bars.add(new SideBar("config.htm?bi=0", "Global Arguments",
                QueryStringUtils.hasPageViewIndex(request, ZERO,
                        activeBarIndex == 0)));

        bars.add(new SideBar("config.htm?bi=1", "Data Sources",
                QueryStringUtils.hasPageViewIndex(request, ONE,
                        activeBarIndex == 1)));

        bars.add(new SideBar("config.htm?bi=2", "Network Partners",
                QueryStringUtils.hasPageViewIndex(request, TWO,
                        activeBarIndex == 2)));

        return bars;

    }

    public static List getProfileBars(HttpServletRequest request,
            int activeBarIndex) {

        List bars = new ArrayList();
        bars.add(new SideBar("profile.htm?bi=0", "Account Profile",
                QueryStringUtils.hasPageViewIndex(request, ZERO,
                        activeBarIndex == 0)));

        bars.add(new SideBar("profile.htm?bi=1", "Change Password",
                QueryStringUtils.hasPageViewIndex(request, ONE,
                        activeBarIndex == 1)));

        bars.add(new SideBar("profile.htm?bi=2", "Edit Notifications",
                QueryStringUtils.hasPageViewIndex(request, TWO,
                        activeBarIndex == 2)));

        return bars;

    }

    public static List getSecurityBars(HttpServletRequest request,
            int activeBarIndex) {

        List bars = new ArrayList();
        bars.add(new SideBar("security.htm?bi=0", "Manage Accounts",
                QueryStringUtils.hasPageViewIndex(request, ZERO,
                        activeBarIndex == 0)));

        bars.add(new SideBar("security.htm?bi=1", "Manage Policies",
                QueryStringUtils.hasPageViewIndex(request, ONE,
                        activeBarIndex == 1)));

        return bars;

    }

}