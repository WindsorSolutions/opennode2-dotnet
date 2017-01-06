package com.windsor.node.domain.entity;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.stream.Stream;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;

import org.hibernate.annotations.Type;

@Entity
//@Cacheable
//@Cache(usage = CacheConcurrencyStrategy.NONSTRICT_READ_WRITE)
@Table(name = "NSchedule")
public class Schedule extends AbstractBaseEntity {

    @Column(name = "Name", nullable = false)
    private String name;

    @ManyToOne(optional = false)
    @JoinColumn(name = "FlowId")
    private Exchange exchange;

    @Column(name = "SourceId", nullable = false)
    private String dataSource;

    @Column(name = "TargetId")
    private String dataTarget;

    @Column(name = "StartOn", nullable = false)
    private LocalDateTime start;

    @Transient
    private Date startDate;

    @Column(name = "EndOn", nullable = false)
    private LocalDateTime end;

    @Transient
    private Date endDate;

    @Column(name = "NextRun")
    private LocalDateTime nextStart;

    @Column(name = "SourceType", nullable = false)
    private ScheduleSourceType sourceType;

    @Column(name = "TargetType", nullable = false)
    private ScheduleTargetType targetType;

    @Column(name = "LastExecutionInfo")
    private String lastExecutionInfo;

    @Column(name = "LastExecutedOn")
    private LocalDateTime lastExecution;

    @Column(name = "SourceOperation")
    private String sourceOperation;

    @Column(name = "TargetOperation")
    private String targetOperation;

    @Enumerated(EnumType.STRING)
    @Column(name = "FrequencyType", nullable = false)
    private ScheduleFrequencyType scheduleFrequencyType;

    @Column(name = "Frequency", nullable = false)
    private Integer frequency;

    @Type(type = "yes_no")
    @Column(name = "IsActive", columnDefinition = "varchar2(1)", nullable = false)
    private Boolean active;

    @Type(type = "yes_no")
    @Column(name = "IsRunNow", columnDefinition = "varchar2(1)", nullable = false)
    private Boolean runNow;

    @Enumerated(EnumType.STRING)
    @Column(name = "ExecuteStatus", nullable = false)
    private ScheduleExecuteStatus scheduleExecuteStatus;

    @OneToMany(mappedBy = "schedule", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<ScheduleArgument> arguments;

    @ManyToOne(optional = true)
    @JoinColumn(name = "LastExecuteActivityId")
    private Activity activity;

    public Schedule() {
        super();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Exchange getExchange() {
        return exchange;
    }

    public void setExchange(Exchange exchange) {
        this.exchange = exchange;
    }

    public LocalDateTime getStart() {
        return start;
    }

    public void setStart(LocalDateTime start) {
        this.start = start;
    }

    public LocalDateTime getEnd() {
        return end;
    }

    public void setEnd(LocalDateTime end) {
        this.end = end;
    }

    public ScheduleSourceType getSourceType() {
        return sourceType;
    }

    public void setSourceType(ScheduleSourceType sourceType) {
        this.sourceType = sourceType;
    }

    public String getLastExecutionInfo() {
        return lastExecutionInfo;
    }

    public void setLastExecutionInfo(String lastExecutionInfo) {
        this.lastExecutionInfo = lastExecutionInfo;
    }

    public LocalDateTime getLastExecution() {
        return lastExecution;
    }

    public void setLastExecution(LocalDateTime lastExecution) {
        this.lastExecution = lastExecution;
    }

    public String getDataSource() {
        return dataSource;
    }

    public void setDataSource(String dataSource) {
        this.dataSource = dataSource;
    }

    public String getDataTarget() {
        return dataTarget;
    }

    public void setDataTarget(String dataTarget) {
        this.dataTarget = dataTarget;
    }

    public LocalDateTime getNextStart() {
        return nextStart;
    }

    public void setNextStart(LocalDateTime nextStart) {
        this.nextStart = nextStart;
    }

    public ScheduleTargetType getTargetType() {
        return targetType;
    }

    public void setTargetType(ScheduleTargetType targetType) {
        this.targetType = targetType;
    }

    public String getSourceOperation() {
        return sourceOperation;
    }

    public void setSourceOperation(String sourceOperation) {
        this.sourceOperation = sourceOperation;
    }

    public String getTargetOperation() {
        return targetOperation;
    }

    public void setTargetOperation(String targetOperation) {
        this.targetOperation = targetOperation;
    }

    public ScheduleFrequencyType getScheduleFrequencyType() {
        return scheduleFrequencyType;
    }

    public void setScheduleFrequencyType(ScheduleFrequencyType scheduleFrequencyType) {
        this.scheduleFrequencyType = scheduleFrequencyType;
    }

    public Integer getFrequency() {
        return frequency;
    }

    public void setFrequency(Integer frequency) {
        this.frequency = frequency;
    }

    public Boolean getActive() {
        return active;
    }

    public void setActive(Boolean active) {
        this.active = active;
    }

    public Boolean getRunNow() {
        return runNow;
    }

    public void setRunNow(Boolean runNow) {
        this.runNow = runNow;
    }

    public ScheduleExecuteStatus getScheduleExecuteStatus() {
        return scheduleExecuteStatus;
    }

    public void setScheduleExecuteStatus(ScheduleExecuteStatus scheduleExecuteStatus) {
        this.scheduleExecuteStatus = scheduleExecuteStatus;
    }

    public Activity getActivity() {
        return activity;
    }

    public void setActivity(Activity activity) {
        this.activity = activity;
    }

    public List<ScheduleArgument> getArguments() {
        return arguments;
    }

    public void setArguments(List<ScheduleArgument> arguments) {
        this.arguments = arguments;
    }

    public Stream<ScheduleArgument> getArgumentsStream() {
        return arguments == null ? Stream.empty() : arguments.stream();
    }

    public boolean isTransactionAssociated() {
        return activity != null && activity.getTransaction() != null;
    }

    public static Schedule newDefault(Exchange exchange) {
        Schedule schedule = new Schedule();
        schedule.setExchange(exchange);
        schedule.setSourceType(ScheduleSourceType.LOCAL_SERVICE);
        schedule.setTargetType(ScheduleTargetType.NONE);
        schedule.setScheduleFrequencyType(ScheduleFrequencyType.Never);
        schedule.setFrequency(0);
        schedule.setRunNow(false);
        schedule.setActive(false);
        schedule.setScheduleExecuteStatus(ScheduleExecuteStatus.Success);
        return schedule;
    }
}
