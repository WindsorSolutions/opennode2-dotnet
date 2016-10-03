package com.windsor.node.plugin.rcra52.solicit.request;

/**
 * Provides an enumeration of valid RCRAInfo solicit request types.
 */
public enum SolicitRequestType {

    CA_BY_HANDLER("GetCADataByHandler"),
    CA_BY_STATE("GetCADataByState"),
    CE_BY_HANDLER("GetCEDataByHandler"),
    CE_BY_STATE("GetCEDataByState"),
    CE_EVALUATION_BY_HANDLER("GetCEEvaluationDataByHandler"),
    FA_BY_HANDLER("GetFADataByHandler"),
    FA_BY_STATE("GetFADataByState"),
    GS_BY_HANDLER("GetGSDataByHandler"),
    GS_BY_STATE("GetGSDataByState"),
    HD_BY_HANDLER("GetHDDataByHandler"),
    HD_BY_STATE("GetHDDataByState"),
    PM_BY_HANDLER("GetPMDataByHandler"),
    PM_BY_STATE("GetPMDataByState"),
    HD_MAX_SEQUENCE("GetHDMaxSequence");

    /**
     * The code for this request type.
     */
    private String code;

    /**
     * Creates a new solicit request type.
     *
     * @param code The code for this request type
     */
    SolicitRequestType(String code) {
        this.code = code;
    }

    @Override
    public String toString() {
        return code;
    }
}
