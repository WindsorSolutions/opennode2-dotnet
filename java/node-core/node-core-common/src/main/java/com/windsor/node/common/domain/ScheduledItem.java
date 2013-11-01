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

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Random;
import org.apache.commons.lang3.builder.EqualsBuilder;
import org.apache.commons.lang3.builder.HashCodeBuilder;
import org.apache.commons.lang3.builder.ToStringBuilder;
import com.windsor.node.common.util.ByIndexOrNameMap;

public class ScheduledItem extends AuditableIdentity {

    private static final long serialVersionUID = 1;
    private String name;
    private String flowId;
    private Timestamp startOn;
    private Timestamp endOn;
    private ScheduledItemSourceType sourceType = ScheduledItemSourceType.None;
    private String sourceId;
    private String sourceOperation;
    private List<ScheduleArgument> scheduleArguments;
    private ScheduledItemTargetType targetType = ScheduledItemTargetType.None;
    private String targetId;
    private String lastExecutionInfo;
    private Timestamp lastExecutedOn;
    private Timestamp nextRunOn;
    private ScheduleFrequencyType frequencyType = ScheduleFrequencyType.Never;
    private int frequency = 0;
    private boolean active = true;
    private boolean runNow = false;
    private ScheduleExecuteStatus executeStatus = ScheduleExecuteStatus.Success;

    //Added on 2013-04-30
    private Activity lastExecutionActivity;
    private String sourceFlow;
    private String targetFlow;
    private String targetOperation;

    /**
     * Map of service id's & names associated with a flow id.
     * <p>
     * Used only by web UI - this is inelegant but expedient.
     * </p>
     * 
     */
    private transient Map<String, String> services;

    public ScheduledItem() {

        long now = System.currentTimeMillis();
        startOn = new Timestamp(now);
        endOn = new Timestamp(now);
        this.scheduleArguments = new ArrayList<ScheduleArgument>();
    }

    // TODO this is a bit of a work around as named arguments don't get ordered as they should coming out of the
    // database, allows Controllers to fix this for display, determine whether there is a better solution
    public List<ScheduleArgument> getScheduleArgumentsByNameOrder(List<String> names)
    {
        if(names == null || names.size() < scheduleArguments.size())
        {
            throw new IllegalArgumentException("ScheduledItem method getScheduleArgumentsByNameOrder param List<String> names did not match the scheduleArguments List.");
        }
        List<ScheduleArgument> orderedList = new ArrayList<ScheduleArgument>();
        for(int i = 0; i < names.size(); i++)
        {
            String currentName = names.get(i);
            boolean found = false;
            for(int j = 0; j < scheduleArguments.size(); j++)
            {
                if(currentName.equalsIgnoreCase(scheduleArguments.get(j).getArgumentKey()))
                {
                    orderedList.add(scheduleArguments.get(j));
                    found = true;
                }
            }
            if(!found)
            {
                ScheduleArgument blankArg = new ScheduleArgument();
                blankArg.setArgumentKey(currentName);
                blankArg.setArgumentValue("");
                orderedList.add(blankArg);
            }
        }
        return orderedList;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFlowId() {
        return flowId;
    }

    public void setFlowId(String flowId) {
        this.flowId = flowId;
    }

    public Timestamp getStartOn() {
        return startOn;
    }

    public void setStartOn(Timestamp startOn) {
        this.startOn = startOn;
    }

    public Timestamp getEndOn() {
        return endOn;
    }

    public void setEndOn(Timestamp endOn) {
        this.endOn = endOn;
    }

    public ScheduledItemSourceType getSourceType() {
        return sourceType;
    }

    public void setSourceType(ScheduledItemSourceType sourceType) {
        this.sourceType = sourceType;
    }

    public String getSourceId() {
        return sourceId;
    }

    public void setSourceId(String sourceId) {
        this.sourceId = sourceId;
    }

    public String getSourceOperation() {
        return sourceOperation;
    }

    public void setSourceOperation(String sourceOperation) {
        this.sourceOperation = sourceOperation;
    }

    //FIXME get rid of this entirely, currently simply converts the actual domain object to this kludgey ByIndexOrNameMap object
    public ByIndexOrNameMap getSourceArgs() {
        ByIndexOrNameMap notAnActualMap = new ByIndexOrNameMap();
        for(int i = 0; i < getScheduleArguments().size(); i++)
        {
            ScheduleArgument currentArg = getScheduleArguments().get(i);
            if(currentArg.getArgumentValue() == null)
            {
                notAnActualMap.put(currentArg.getArgumentKey(), "");
            }
            else
            {
                notAnActualMap.put(currentArg.getArgumentKey(), currentArg.getArgumentValue());
            }
        }
        return notAnActualMap;
    }

    public void setSourceArgs(ByIndexOrNameMap sourceArgs) {
        //do nothing, midway through removal of this kludge
    }

    public ScheduledItemTargetType getTargetType() {
        return targetType;
    }

    public void setTargetType(ScheduledItemTargetType targetType) {
        this.targetType = targetType;
    }

    public String getTargetId() {
        return targetId;
    }

    public void setTargetId(String targetId) {
        this.targetId = targetId;
    }

    public String getLastExecutionInfo() {
        return lastExecutionInfo;
    }

    public void setLastExecutionInfo(String lastExecutionInfo) {
        this.lastExecutionInfo = lastExecutionInfo;
    }

    public Timestamp getLastExecutedOn() {
        return lastExecutedOn;
    }

    public void setLastExecutedOn(Timestamp lastExecutedOn) {
        this.lastExecutedOn = lastExecutedOn;
    }

    public Timestamp getNextRunOn() {
        return nextRunOn;
    }

    public void setNextRunOn(Timestamp nextRunOn) {
        this.nextRunOn = nextRunOn;
    }

    public ScheduleFrequencyType getFrequencyType() {
        return frequencyType;
    }

    public void setFrequencyType(ScheduleFrequencyType frequencyType) {
        this.frequencyType = frequencyType;
        if(this.frequencyType == ScheduleFrequencyType.Never)
        {
            setNextRunOn(null);
        }
    }

    public int getFrequency() {
        return frequency;
    }

    public void setFrequency(int frequency) {
        this.frequency = frequency;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean isActive) {
        this.active = isActive;
    }

    public boolean isRunNow() {
        return runNow;
    }

    public void setRunNow(boolean runNow) {
        this.runNow = runNow;
    }

    public ScheduleExecuteStatus getExecuteStatus() {
        return executeStatus;
    }

    public void setExecuteStatus(ScheduleExecuteStatus executeStatus) {
        this.executeStatus = executeStatus;
    }

    public String toString() {
        return new ToStringBuilder(this, new DomainStringStyle()).appendSuper(
                super.toString()).append("name", name).append("flowId", flowId)
                .append("startOn", startOn).append("endOn", endOn).append(
                        "sourceType", sourceType).append("sourceId", sourceId)
                .append("sourceOperation", sourceOperation).append(
                        "serviceArguments", scheduleArguments).append("targetType",
                        targetType).append("targetId", targetId).append(
                        "lastExecutionInfo", lastExecutionInfo).append(
                        "lastExecutedOn", lastExecutedOn).append("nextRunOn",
                        nextRunOn).append("frequencyType", frequencyType)
                .append("frequency", frequency).append("active", active)
                .append("runNow", runNow)
                .append("executeStatus", executeStatus)
                .append("lastExecutionActivity", lastExecutionActivity)
                .append("sourceFlow", sourceFlow)
                .append("targetFlow", targetFlow)
                .append("targetOperation", targetOperation).toString();
    }

    public int hashCode() {
        Random r = new Random();
        int n = r.nextInt();
        if (n % 2 == 0) {
            n++;
        }
        return new HashCodeBuilder(n, n + 2).appendSuper(super.hashCode())
                .append(name).append(flowId).append(startOn).append(endOn)
                .append(sourceType).append(sourceId).append(sourceOperation)
                .append(scheduleArguments).append(targetType).append(targetId).append(
                        lastExecutionInfo).append(lastExecutedOn).append(
                        nextRunOn).append(frequencyType).append(frequency)
                .append(active).append(runNow).append(executeStatus)
                .append(lastExecutionActivity).append(sourceFlow).append(targetFlow).append(targetOperation)
                .toHashCode();
    }

    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (obj == this) {
            return true;
        }
        if (obj.getClass() != getClass()) {
            return false;
        }
        ScheduledItem item = (ScheduledItem) obj;
        return new EqualsBuilder().appendSuper(super.equals(obj)).append(name,
                item.name).append(flowId, item.flowId).append(startOn,
                item.startOn).append(endOn, item.endOn).append(sourceType,
                item.sourceType).append(sourceId, item.sourceId).append(
                sourceOperation, item.sourceOperation).append(scheduleArguments,
                item.scheduleArguments).append(targetType, item.targetType).append(
                targetId, item.targetId).append(lastExecutionInfo,
                item.lastExecutionInfo).append(lastExecutedOn,
                item.lastExecutedOn).append(nextRunOn, item.nextRunOn).append(
                frequencyType, item.frequencyType).append(frequency,
                item.frequency).append(active, item.active).append(runNow,
                item.runNow).append(executeStatus, item.executeStatus)
                .append(lastExecutionActivity, item.lastExecutionActivity)
                .append(sourceFlow, item.sourceFlow)
                .append(targetFlow, item.targetFlow)
                .append(targetOperation, item.targetOperation)
                .isEquals();
    }

    public Map<String, String> getServices() {
        return services;
    }

    public void setServices(Map<String, String> services) {
        this.services = services;
    }

    public List<ScheduleArgument> getScheduleArguments()
    {
        return scheduleArguments;
    }

    public void setScheduleArguments(List<ScheduleArgument> scheduleArguments)
    {
        this.scheduleArguments = scheduleArguments;
    }

    public String getSourceFlow()
    {
        return sourceFlow;
    }

    public void setSourceFlow(String sourceFlow)
    {
        this.sourceFlow = sourceFlow;
    }

    public String getTargetFlow()
    {
        return targetFlow;
    }

    public void setTargetFlow(String targetFlow)
    {
        this.targetFlow = targetFlow;
    }

    public String getTargetOperation()
    {
        return targetOperation;
    }

    public void setTargetOperation(String targetOperation)
    {
        this.targetOperation = targetOperation;
    }

    public Activity getLastExecutionActivity()
    {
        return lastExecutionActivity;
    }

    public void setLastExecutionActivity(Activity lastExecutionActivity)
    {
        this.lastExecutionActivity = lastExecutionActivity;
    }
}