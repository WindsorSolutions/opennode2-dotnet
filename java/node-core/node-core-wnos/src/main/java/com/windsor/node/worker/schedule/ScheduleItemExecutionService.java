package com.windsor.node.worker.schedule;

import com.windsor.node.common.domain.ScheduledItem;

public interface ScheduleItemExecutionService
{
    /**
     * Runs a ScheduledItem regardless of the timer or isRunNow status, will only refuse if the ScheduledItem is currently running or the
     * machineId is set to not run schedules 
     * @param schedule The ScheduledItem to run, may not be null
     */
    void run(ScheduledItem schedule);

    void run(String scheduleId);
}
