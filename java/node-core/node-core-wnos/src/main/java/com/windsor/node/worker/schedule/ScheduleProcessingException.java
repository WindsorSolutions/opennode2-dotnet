package com.windsor.node.worker.schedule;

import com.windsor.node.common.domain.ActivityEntry;

import java.util.List;

/**
 * Provides an object that provides an exception that indicates a problem during schedule processing.
 */
public class ScheduleProcessingException extends Exception {

    private List<ActivityEntry> activityEntries;

    public ScheduleProcessingException(String message, Throwable cause, List<ActivityEntry> activityEntries) {
        super(message, cause);
        this.activityEntries = activityEntries;
    }

    public ScheduleProcessingException(String message, List<ActivityEntry> activityEntries) {
        super(message, null);
        this.activityEntries = activityEntries;
    }

    public List<ActivityEntry> getActivityEntries() {
        return activityEntries;
    }
}
