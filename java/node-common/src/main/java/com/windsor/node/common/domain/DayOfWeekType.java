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

package com.windsor.node.common.domain;

import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Calendar;

import org.apache.commons.lang.enums.ValuedEnum;

public final class DayOfWeekType extends ValuedEnum {

    public static final DayOfWeekType MONDAY = new DayOfWeekType("Monday",
            Calendar.MONDAY);
    public static final DayOfWeekType TUESDAY = new DayOfWeekType("Tuesday",
            Calendar.TUESDAY);
    public static final DayOfWeekType WEDNESDAY = new DayOfWeekType(
            "Wednesday", Calendar.WEDNESDAY);
    public static final DayOfWeekType THURSDAY = new DayOfWeekType("Thursday",
            Calendar.THURSDAY);

    private static final long serialVersionUID = 1;
    
    private DayOfWeekType(String type, int i) {
        super(type, i);
    }

    public static Map getEnumMap() {
        return getEnumMap(DayOfWeekType.class);
    }

    public static List getEnumList() {
        return getEnumList(DayOfWeekType.class);
    }

    public static Iterator iterator() {
        return iterator(DayOfWeekType.class);
    }
}