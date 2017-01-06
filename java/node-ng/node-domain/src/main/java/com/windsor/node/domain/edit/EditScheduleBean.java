package com.windsor.node.domain.edit;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.ScheduleFrequencyType;
import com.windsor.node.domain.entity.ScheduleSourceType;
import com.windsor.node.domain.entity.ScheduleTargetType;

public class EditScheduleBean implements Serializable {

    private String id;
    private String exchangeId;
    private String name;
    private boolean active;
    private Date start;
    private Date end;
    private int frequency;
    private ScheduleFrequencyType frequencyType;

    private ScheduleTargetType targetType;
    private Partner targetPartner;
    private String targetEmail;
    private String targetFilePath;

    private ScheduleSourceType sourceType;
    private String sourceFilePath;
    private ExchangeService exchangeService;

    private List<EditScheduleArgumentBean> arguments;

    public EditScheduleBean() {
        super();
    }

    public EditScheduleBean(String exchangeId) {
        setExchangeId(exchangeId);
        setSourceType(ScheduleSourceType.LOCAL_SERVICE);
        setTargetType(ScheduleTargetType.NONE);
        setFrequencyType(ScheduleFrequencyType.Never);
        setFrequency(0);
        setActive(true);
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getExchangeId() {
        return exchangeId;
    }

    public void setExchangeId(String exchangeId) {
        this.exchangeId = exchangeId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public Date getStart() {
        return start;
    }

    public void setStart(Date start) {
        this.start = start;
    }

    public Date getEnd() {
        return end;
    }

    public void setEnd(Date end) {
        this.end = end;
    }

    public ScheduleSourceType getSourceType() {
        return sourceType;
    }

    public void setSourceType(ScheduleSourceType sourceType) {
        this.sourceType = sourceType;
    }

    public ScheduleTargetType getTargetType() {
        return targetType;
    }

    public void setTargetType(ScheduleTargetType targetType) {
        this.targetType = targetType;
    }

    public int getFrequency() {
        return frequency;
    }

    public void setFrequency(int frequency) {
        this.frequency = frequency;
    }

    public ScheduleFrequencyType getFrequencyType() {
        return frequencyType;
    }

    public void setFrequencyType(ScheduleFrequencyType frequencyType) {
        this.frequencyType = frequencyType;
    }

    public Partner getTargetPartner() {
        return targetPartner;
    }

    public void setTargetPartner(Partner partner) {
        this.targetPartner = partner;
    }

    public String getTargetEmail() {
        return targetEmail;
    }

    public void setTargetEmail(String email) {
        this.targetEmail = email;
    }

    public String getTargetFilePath() {
        return targetFilePath;
    }

    public void setTargetFilePath(String path) {
        this.targetFilePath = path;
    }

    public String getSourceFilePath() {
        return sourceFilePath;
    }

    public void setSourceFilePath(String fileSource) {
        this.sourceFilePath = fileSource;
    }

    public List<EditScheduleArgumentBean> getArguments() {
        return arguments;
    }

    public void setArguments(List<EditScheduleArgumentBean> arguments) {
        this.arguments = arguments;
    }

    public String getTargetTypeHelpText() {
        return targetType == null ? null : targetType.getHelpText();
    }

    public String getSourceTypeHelpText() {
        return sourceType == null ? null : sourceType.getHelpText();
    }

    public ExchangeService getExchangeService() {
        return exchangeService;
    }

    public void setExchangeService(ExchangeService exchangeService) {
        this.exchangeService = exchangeService;
    }

}
