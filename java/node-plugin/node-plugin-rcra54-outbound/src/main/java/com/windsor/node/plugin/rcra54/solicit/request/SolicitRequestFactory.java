package com.windsor.node.plugin.rcra54.solicit.request;

import net.exchangenetwork.schema.node._2.ParameterType;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * Provides a factory for creating new RCRAInfo solicit requests.
 */
public class SolicitRequestFactory {

    private String endpoint;
    private String securityToken;
    private String recipient;


    public SolicitRequestFactory(String endpoint, String securityToken) {
       this(endpoint, securityToken, null);
    }

    public SolicitRequestFactory(String endpoint, String securityToken, String recipient) {
        this.endpoint = endpoint;
        this.securityToken = securityToken;
        this.recipient = recipient;
    }

    public SolicitRequest getCAByHandler(String handlerId, Date changeDate) {
        return createForHandler(SolicitRequestType.CA_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getCAByHandler(String handlerId, String changeDate) {
        return createForHandler(SolicitRequestType.CA_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getCAByState(String state, Date changeDate) {
        return createForState(SolicitRequestType.CA_BY_STATE, state, changeDate);
    }

    public SolicitRequest getCAByState(String state, String changeDate) {
        return createForState(SolicitRequestType.CA_BY_STATE, state, changeDate);
    }

    public SolicitRequest getCEDataByHandler(String handlerId, String state, String agency, Date changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createAgency(agency));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.CE_BY_HANDLER, parameters);
    }

    public SolicitRequest getCEDataByHandler(String handlerId, String state, String agency, String changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createAgency(agency));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.CE_BY_HANDLER, parameters);
    }

    public SolicitRequest getCEByState(String state, Date changeDate) {
        return createForState(SolicitRequestType.CE_BY_STATE, state, changeDate);
    }

    public SolicitRequest getCEByState(String state, String changeDate) {
        return createForState(SolicitRequestType.CE_BY_STATE, state, changeDate);
    }

    public SolicitRequest getCEEvaluationDataByHandler(String handlerId, String state, String agency,
                                                              Date fromDate, Date toDate, Date changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createAgency(agency));
        parameters.add(SolicitParameterFactory.createFromDate(fromDate));
        parameters.add(SolicitParameterFactory.createToDate(toDate));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.CE_EVALUATION_BY_HANDLER,
                parameters);
    }

    public SolicitRequest getCEEvaluationDataByHandler(String handlerId, String state, String agency,
                                                       String fromDate, String toDate, String changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createAgency(agency));
        parameters.add(SolicitParameterFactory.createFromDate(fromDate));
        parameters.add(SolicitParameterFactory.createToDate(toDate));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.CE_EVALUATION_BY_HANDLER,
                parameters);
    }

    public SolicitRequest getFADataByHandler(String handlerId, Date changeDate) {
        return createForHandler(SolicitRequestType.FA_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getFADataByHandler(String handlerId, String changeDate) {
        return createForHandler(SolicitRequestType.FA_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getFADataByState(String state, Date changeDate) {
        return createForHandler(SolicitRequestType.FA_BY_STATE, state, changeDate);
    }

    public SolicitRequest getFADataByState(String state, String changeDate) {
        return createForState(SolicitRequestType.FA_BY_STATE, state, changeDate);
    }

    public SolicitRequest getGSDataByHandler(String handlerId, String owner, Long sequenceNumber,
                                                    Date changeDate) {
        List<ParameterType> parameters = createParametersForHandler(handlerId, changeDate);
        parameters.add(SolicitParameterFactory.createOwner(owner));
        parameters.add(SolicitParameterFactory.createSequenceNumber(sequenceNumber));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.GS_BY_HANDLER, parameters);
    }

    public SolicitRequest getGSDataByHandler(String handlerId, String owner, String sequenceNumber,
                                             String changeDate) {
        List<ParameterType> parameters = createParametersForHandler(handlerId, changeDate);
        parameters.add(SolicitParameterFactory.createOwner(owner));
        parameters.add(SolicitParameterFactory.createSequenceNumber(sequenceNumber));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.GS_BY_HANDLER, parameters);
    }

    public SolicitRequest getGSDataByState(String state, Date changeDate) {
        return createForState(SolicitRequestType.GS_BY_STATE, state, changeDate);
    }

    public SolicitRequest getGSDataByState(String state, String changeDate) {
        return createForState(SolicitRequestType.GS_BY_STATE, state, changeDate);
    }

    public SolicitRequest getHDDataByHandler(String handlerId, String state, String sourceType, Long sequenceNumber,
                                             Date changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createSourceType(sourceType));
        parameters.add(SolicitParameterFactory.createSequenceNumber(sequenceNumber));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.HD_BY_HANDLER, parameters);
    }

    public SolicitRequest getHDDataByHandler(String handlerId, String state, String sourceType, String sequenceNumber,
                                             String changeDate) {
        List<ParameterType> parameters = createParametersForHandlerState(handlerId, state, changeDate);
        parameters.add(SolicitParameterFactory.createSourceType(sourceType));
        parameters.add(SolicitParameterFactory.createSequenceNumber(sequenceNumber));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.HD_BY_HANDLER, parameters);
    }

    public SolicitRequest getHDDataByState(String state, Date changeDate) {
        return createForState(SolicitRequestType.HD_BY_STATE, state, changeDate);
    }

    public SolicitRequest getHDDataByState(String state, String changeDate) {
        return createForState(SolicitRequestType.HD_BY_STATE, state, changeDate);
    }

    public SolicitRequest getPMDataByHandler(String handlerId, Date changeDate) {
        return createForHandler(SolicitRequestType.PM_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getPMDataByHandler(String handlerId, String changeDate) {
        return createForHandler(SolicitRequestType.PM_BY_HANDLER, handlerId, changeDate);
    }

    public SolicitRequest getPMDataByState(String state, Date changeDate) {
        return createForState(SolicitRequestType.PM_BY_STATE, state, changeDate);
    }

    public SolicitRequest getPMDataByState(String state, String changeDate) {
        return createForState(SolicitRequestType.PM_BY_STATE, state, changeDate);
    }

    public SolicitRequest getHDMaxSequence(String handlerId, String sourceType, String stateId) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createHandlerId(handlerId));
        parameters.add(SolicitParameterFactory.createSourceType(sourceType));
        parameters.add(SolicitParameterFactory.createStateId(stateId));
        return new SolicitRequest(endpoint, securityToken, recipient, SolicitRequestType.HD_MAX_SEQUENCE, parameters);
    }

    /*
     * Methods for generating parameter type lists.
     */

    private List<ParameterType> createParametersForHandler(String handlerId, Date changeDate) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createHandlerId(handlerId));
        parameters.add(SolicitParameterFactory.createChangeDate(changeDate));
        return parameters;
    }

    private List<ParameterType> createParametersForHandler(String handlerId, String changeDate) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createHandlerId(handlerId));
        parameters.add(SolicitParameterFactory.createChangeDate(changeDate));
        return parameters;
    }

    private List<ParameterType> createParametersForState(String state, Date changeDate) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createState(state));
        parameters.add(SolicitParameterFactory.createChangeDate(changeDate));
        return parameters;
    }

    private List<ParameterType> createParametersForState(String state, String changeDate) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createState(state));
        parameters.add(SolicitParameterFactory.createChangeDate(changeDate));
        return parameters;
    }

    private List<ParameterType> createParametersForHandlerState(String handlerId, String state, Date changeDate) {
        List<ParameterType> parameters = createParametersForHandler(handlerId, changeDate);
        parameters.add(SolicitParameterFactory.createState(state));
        return parameters;
    }

    private List<ParameterType> createParametersForHandlerState(String handlerId, String state, String changeDate) {
        List<ParameterType> parameters = new ArrayList<>();
        parameters.add(SolicitParameterFactory.createHandlerId(handlerId));
        parameters.add(SolicitParameterFactory.createChangeDate(changeDate));
        parameters.add(SolicitParameterFactory.createState(state));
        return parameters;
    }

    /*
     * Methods for generating solicit requests.
     */

    private SolicitRequest createForHandler(SolicitRequestType type, String handlerId, Date changeDate) {
        return new SolicitRequest(endpoint, securityToken, recipient, type, createParametersForHandler(handlerId,
                changeDate));
    }

    private SolicitRequest createForHandler(SolicitRequestType type, String handlerId, String changeDate) {
        return new SolicitRequest(endpoint, securityToken, recipient, type, createParametersForHandler(handlerId,
                changeDate));
    }

    private SolicitRequest createForState(SolicitRequestType type, String state, Date changeDate) {
        return new SolicitRequest(endpoint, securityToken, recipient, type, createParametersForState(state,
                changeDate));
    }

    private SolicitRequest createForState(SolicitRequestType type, String state, String changeDate) {
        return new SolicitRequest(endpoint, securityToken, recipient, type, createParametersForState(state,
                changeDate));
    }
}
