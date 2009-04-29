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

import org.apache.commons.lang.enums.ValuedEnum;

public final class ServiceType extends ValuedEnum {

    public static final ServiceType NONE = new ServiceType("None", 0x00);
    public static final ServiceType QUERY = new ServiceType("Query", 0x02);
    public static final ServiceType SOLICIT = new ServiceType("Solicit", 0x04);
    public static final ServiceType SUBMIT = new ServiceType("Submit", 0x08);
    public static final ServiceType NOTIFY = new ServiceType("Notify", 0x10);
    public static final ServiceType EXECUTE = new ServiceType("Execute", 0x20);
    public static final ServiceType QUERY_OR_SOLICIT = new ServiceType(
            "QueryOrSolicit", 0x40);
    public static final ServiceType QUERY_OR_SOLICIT_OR_EXECUTE = new ServiceType(
            "QueryOrSolicitOrExecute", 0x80);

    private static final long serialVersionUID = 1;

    private ServiceType(String s, int i) {
        super(s, i);
    }

    public static Map getEnumMap() {
        return getEnumMap(ServiceType.class);
    }

    public static List getEnumList() {
        return getEnumList(ServiceType.class);
    }

    public static Iterator iterator() {
        return iterator(ServiceType.class);
    }
}