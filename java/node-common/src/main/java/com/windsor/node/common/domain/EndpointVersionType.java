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
 * We take this non-standard approach to a Java 5 enum type for backward
 * compatilbility with earlier versions based on
 * org.apache.commons.lang.enums.Enum.
 * 
 * @author jniski
 * 
 */
public enum EndpointVersionType {

    UNDEFINED("Undefined"), EN11("EN11"), EN20("EN2.0");

    private static final long serialVersionUID = 2;

    private String type;

    private EndpointVersionType(String type) {
        this.type = type;
    }

    @Override
    public String toString() {
        return this.type;
    }

    public static EndpointVersionType fromString(String s)
    {
        EndpointVersionType version;
        if(EN11.toString().equalsIgnoreCase(s))
        {
            version = EN11;
        }
        else if(EN20.toString().equalsIgnoreCase(s))
        {
            version = EN20;
        }
        else
        {
            version = UNDEFINED;
        }

        return version;
    }
}
