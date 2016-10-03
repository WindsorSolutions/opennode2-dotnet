package com.windsor.node.plugin.rcra52.solicit.request;

import net.exchangenetwork.schema.node._2.ObjectFactory;
import net.exchangenetwork.schema.node._2.ParameterType;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Provides an object for creating RCRAInfo solict request parameters
 */
public class SolicitParameterFactory {

    private final static DateFormat dateFormat = new SimpleDateFormat("MM/dd/yyyy");
    private final static ObjectFactory objectFactory = new ObjectFactory();

    public static ParameterType createHandlerId(String value) {
        return createParameter(SolicitParameterType.HANDLER_ID, value);
    }

    public static ParameterType createState(String value) {
        return createParameter(SolicitParameterType.STATE, value);
    }

    public static ParameterType createStateId(String value) {
        return createParameter(SolicitParameterType.STATE_ID, value);
    }

    public static ParameterType createAgency(String value) {
        return createParameter(SolicitParameterType.AGENCY, value);
    }

    public static ParameterType createOwner(String value) {
        return createParameter(SolicitParameterType.OWNER, value);
    }

    public static ParameterType createSourceType(String value) {
        return createParameter(SolicitParameterType.SOURCE_TYPE, value);
    }

    public static ParameterType createSequenceNumber(Long value) {
        return createParameter(SolicitParameterType.SEQUENCE_NUMBER, value);
    }

    public static ParameterType createSequenceNumber(String value) {
        return createParameter(SolicitParameterType.SEQUENCE_NUMBER, value);
    }

    public static ParameterType createChangeDate(Date value) {
        return createParameter(SolicitParameterType.CHANGE_DATE, value);
    }

    public static ParameterType createFromDate(Date value) {
        return createParameter(SolicitParameterType.FROM_DATE, value);
    }

    public static ParameterType createToDate(Date value) {
        return createParameter(SolicitParameterType.TO_DATE, value);
    }

    public static ParameterType createChangeDate(String value) {
        return createParameter(SolicitParameterType.CHANGE_DATE, value);
    }

    public static ParameterType createFromDate(String value) {
        return createParameter(SolicitParameterType.FROM_DATE, value);
    }

    public static ParameterType createToDate(String value) {
        return createParameter(SolicitParameterType.TO_DATE, value);
    }

    private static ParameterType createParameter(SolicitParameterType type, Date value) {
        return createParameter(type, dateFormat.format(value));
    }

    private static ParameterType createParameter(SolicitParameterType type, Long value) {
        return createParameter(type, value.toString());
    }

    private static ParameterType createParameter(SolicitParameterType type, String value) {
        ParameterType parameterType = objectFactory.createParameterType();
        parameterType.setParameterName(type.toString());
        parameterType.setValue(value);
        return parameterType;
    }
}
