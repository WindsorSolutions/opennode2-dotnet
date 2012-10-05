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

import java.io.Serializable;

import org.apache.commons.lang3.builder.ReflectionToStringBuilder;

public class UserFlowNotification extends AuditableIdentity implements
        Serializable {

    private static final long serialVersionUID = 1;
    private DataFlow flow;
    private boolean onSolicit;
    private boolean onQuery;
    private boolean onSubmit;
    private boolean onNotify;
    private boolean onSchedule;
    private boolean onDownload;
    private boolean onExecute;

    public UserFlowNotification() {
    }

    public UserFlowNotification(DataFlow flow) {
        this.flow = flow;
    }

    public DataFlow getFlow() {
        return flow;
    }

    public void setFlow(DataFlow flow) {
        this.flow = flow;
    }

    public boolean isOnSolicit() {
        return onSolicit;
    }

    public void setOnSolicit(boolean onSolicit) {
        this.onSolicit = onSolicit;
    }

    public boolean isOnQuery() {
        return onQuery;
    }

    public void setOnQuery(boolean onQuery) {
        this.onQuery = onQuery;
    }

    public boolean isOnSubmit() {
        return onSubmit;
    }

    public void setOnSubmit(boolean onSubmit) {
        this.onSubmit = onSubmit;
    }

    public boolean isOnNotify() {
        return onNotify;
    }

    public void setOnNotify(boolean onNotify) {
        this.onNotify = onNotify;
    }

    public boolean isOnSchedule() {
        return onSchedule;
    }

    public void setOnSchedule(boolean onSchedule) {
        this.onSchedule = onSchedule;
    }

    public boolean isOnDownload() {
        return onDownload;
    }

    public void setOnDownload(boolean onDownload) {
        this.onDownload = onDownload;
    }

    public boolean isOnExecute() {
        return onExecute;
    }

    public void setOnExecute(boolean onExecute) {
        this.onExecute = onExecute;
    }

    public boolean isAll() {
        return isOnDownload() && isOnExecute() && isOnNotify() && isOnQuery()
                && isOnSchedule() && isOnSolicit() && isOnSubmit();
    }

    public boolean isNone() {
        return !(isOnDownload() && isOnExecute() && isOnNotify() && isOnQuery()
                && isOnSchedule() && isOnSolicit() && isOnSubmit());
    }

    public void setByNotificationType(NotificationType type) {
        if (type.equals(NotificationType.OnDownload)
                || type.equals(NotificationType.All)) {
            setOnDownload(true);
        }
        if (type.equals(NotificationType.OnExecute)
                || type.equals(NotificationType.All)) {
            setOnExecute(true);
        }
        if (type.equals(NotificationType.OnNotify)
                || type.equals(NotificationType.All)) {
            setOnNotify(true);
        }
        if (type.equals(NotificationType.OnQuery)
                || type.equals(NotificationType.All)) {
            setOnQuery(true);
        }
        if (type.equals(NotificationType.OnSchedule)
                || type.equals(NotificationType.All)) {
            setOnSchedule(true);
        }
        if (type.equals(NotificationType.OnSolicit)
                || type.equals(NotificationType.All)) {
            setOnSolicit(true);
        }
        if (type.equals(NotificationType.OnSubmit)
                || type.equals(NotificationType.All)) {
            setOnSubmit(true);
        }
        if (type.equals(NotificationType.None)) {
            setOnDownload(false);
            setOnExecute(false);
            setOnNotify(false);
            setOnQuery(false);
            setOnSchedule(false);
            setOnSolicit(false);
            setOnSubmit(false);
        }

    }

    public String toString() {
        ReflectionToStringBuilder rtsb = new ReflectionToStringBuilder(this,
                new DomainStringStyle());
        rtsb.setAppendStatics(false);
        rtsb.setAppendTransients(false);
        return rtsb.toString();
    }

    // CHECKSTYLE:OFF
    public int hashCode() {
        final int prime = 31;
        final int valIfTrue = 1231;
        final int valIfFalse = 1237;
        int result = super.hashCode();
        result = prime * result + ((flow == null) ? 0 : flow.hashCode());
        result = prime * result + (onDownload ? valIfTrue : valIfFalse);
        result = prime * result + (onExecute ? valIfTrue : valIfFalse);
        result = prime * result + (onNotify ? valIfTrue : valIfFalse);
        result = prime * result + (onQuery ? valIfTrue : valIfFalse);
        result = prime * result + (onSchedule ? valIfTrue : valIfFalse);
        result = prime * result + (onSolicit ? valIfTrue : valIfFalse);
        result = prime * result + (onSubmit ? valIfTrue : valIfFalse);
        return result;
    }
    // CHECKSTYLE:ON

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!super.equals(obj)) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final UserFlowNotification other = (UserFlowNotification) obj;
        if (flow == null) {
            if (other.flow != null) {
                return false;
            }
        } else if (!flow.equals(other.flow)) {
            return false;
        }
        if (onDownload != other.onDownload) {
            return false;
        }
        if (onExecute != other.onExecute) {
            return false;
        }
        if (onNotify != other.onNotify) {
            return false;
        }
        if (onQuery != other.onQuery) {
            return false;
        }
        if (onSchedule != other.onSchedule) {
            return false;
        }
        if (onSolicit != other.onSolicit) {
            return false;
        }
        if (onSubmit != other.onSubmit) {
            return false;
        }
        return true;
    }

}