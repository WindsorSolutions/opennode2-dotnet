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

/**
 * We take this non-standard approach to a Java 5 enum name for backward
 * compatilbility with earlier versions based on
 * org.apache.commons.lang.enums.Enum.
 * 
 * @author jniski
 * 
 */
public enum ServiceType {

    NONE("None"), QUERY("Query"), SOLICIT("Solicit"), SUBMIT("Submit"), NOTIFY(
            "Notify"), EXECUTE("Execute"), QUERY_OR_SOLICIT("QueryOrSolicit"), QUERY_OR_SOLICIT_OR_EXECUTE(
            "QueryOrSolicitOrExecute"), TASK("Task");

    private static final long serialVersionUID = 2;

    private String name;

    private ServiceType(String typeName) {
        this.name = typeName;
    }

    @Override
    public String toString() {
        return this.name;
    }

    public static ServiceType fromString(String s) {

        ServiceType serviceType = null;

        if (s.equalsIgnoreCase(NONE.toString())) {

            serviceType = NONE;

        } else if (s.equalsIgnoreCase(QUERY.toString())) {

            serviceType = QUERY;

        } else if (s.equalsIgnoreCase(SOLICIT.toString())) {

            serviceType = SOLICIT;

        } else if (s.equalsIgnoreCase(SUBMIT.toString())) {

            serviceType = SUBMIT;

        } else if (s.equalsIgnoreCase(NOTIFY.toString())) {

            serviceType = NOTIFY;

        } else if (s.equalsIgnoreCase(EXECUTE.toString())) {

            serviceType = EXECUTE;

        } else if (s.equalsIgnoreCase(QUERY_OR_SOLICIT.toString())) {

            serviceType = QUERY_OR_SOLICIT;

        } else if (s.equalsIgnoreCase(QUERY_OR_SOLICIT_OR_EXECUTE.toString())) {

            serviceType = QUERY_OR_SOLICIT_OR_EXECUTE;

        } else if (s.equalsIgnoreCase(TASK.toString())) {

            serviceType = TASK;

        }

        return serviceType;
    }

}