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

package com.windsor.node.admin.domain;

import java.util.Random;

import org.apache.commons.lang3.builder.EqualsBuilder;
import org.apache.commons.lang3.builder.HashCodeBuilder;
import org.apache.commons.lang3.builder.ReflectionToStringBuilder;

import com.windsor.node.common.domain.DomainStringStyle;

public class UserActivityCount implements Comparable<Object> {

    private String naasId;
    private int activityCount;

    public UserActivityCount(String naasUserName, int count) {
        naasId = naasUserName;
        activityCount = count;
    }

    public int compareTo(Object obj) {
        UserActivityCount uac = (UserActivityCount) obj;
        int retval;

        if (this.activityCount == uac.getActivityCount()) {
            retval = this.naasId.compareTo(uac.getNaasId());
        } else if (this.activityCount < uac.getActivityCount()) {
            retval = -1;
        } else {
            retval = 1;
        }

        return retval;
    }

    public String getNaasId() {
        return naasId;
    }

    public void setNaasId(String naasId) {
        this.naasId = naasId;
    }

    public int getActivityCount() {
        return activityCount;
    }

    public void setActivityCount(int activityCount) {
        this.activityCount = activityCount;
    }

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).append(naasId).append(
                activityCount).toHashCode();
    }

    public boolean equals(Object obj) {
        return EqualsBuilder.reflectionEquals(this, obj);
    }

}
