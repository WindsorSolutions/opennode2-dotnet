package com.windsor.node.plugin.rcra54.solicit.request;

import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Stream;

/**
 * Provides an enumeration of valid RCRAInfo solicit request types.
 */
public enum SolicitRequestType {

    CA_BY_HANDLER("GetCADataByHandler", DbInfo.CA),
    CA_BY_STATE("GetCADataByState", DbInfo.CA),
    CE_BY_HANDLER("GetCEDataByHandler", DbInfo.CE),
    CE_BY_STATE("GetCEDataByState", DbInfo.CE),
    CE_EVALUATION_BY_HANDLER("GetCEEvaluationDataByHandler", DbInfo.CE),
    FA_BY_HANDLER("GetFADataByHandler", DbInfo.FA),
    FA_BY_STATE("GetFADataByState", DbInfo.FA),
    GS_BY_HANDLER("GetGSDataByHandler", DbInfo.GS),
    GS_BY_STATE("GetGSDataByState", DbInfo.GS),
    HD_BY_HANDLER("GetHDDataByHandler", DbInfo.HD),
    HD_BY_STATE("GetHDDataByState", DbInfo.HD),
    PM_BY_HANDLER("GetPMDataByHandler", DbInfo.PM),
    PM_BY_STATE("GetPMDataByState", DbInfo.PM),
    HD_MAX_SEQUENCE("GetHDMaxSequence", DbInfo.HD);

    private static final Map<String, SolicitRequestType> MAP;

    static {
        MAP = new HashMap<>();
        for (SolicitRequestType type : SolicitRequestType.values()) {
            MAP.put(type.code, type);
        }
    }

    /**
     * The code for this request type.
     */
    private String code;

    /**
     * Database-related info about the solicit request.
     */
    private DbInfo dbInfo;

    /**
     * Creates a new solicit request type.
     *
     * @param code The code for this request type
     * @param dbInfo The database-realted info about this solicit request
     */
    SolicitRequestType(String code, DbInfo dbInfo) {
        this.code = code;
        this.dbInfo = dbInfo;
    }

    @Override
    public String toString() {
        return code;
    }

    public DbInfo getDbInfo() {
        return dbInfo;
    }

    public static SolicitRequestType getByCode(String code) {
        return MAP.get(code);
    }

}
