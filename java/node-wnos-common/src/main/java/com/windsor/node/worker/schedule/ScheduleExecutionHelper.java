package com.windsor.node.worker.schedule;

import org.apache.commons.lang.StringUtils;

public final class ScheduleExecutionHelper {

    private ScheduleExecutionHelper() {
    }

    protected static boolean shouldWeRunHere(String machineId,
            String executionMachineName) {

        boolean shouldWe = false;

        if (StringUtils.isBlank(executionMachineName)
                || machineId.equalsIgnoreCase(executionMachineName)) {

            shouldWe = true;
        }

        return shouldWe;
    }
}
