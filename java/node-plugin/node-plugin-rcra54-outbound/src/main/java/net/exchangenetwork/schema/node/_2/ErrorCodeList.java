
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlEnumValue;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for ErrorCodeList.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="ErrorCodeList">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="E_UnknownUser"/>
 *     &lt;enumeration value="E_InvalidCredential"/>
 *     &lt;enumeration value="E_TransactionId"/>
 *     &lt;enumeration value="E_UnknownMethod"/>
 *     &lt;enumeration value="E_ServiceUnavailable"/>
 *     &lt;enumeration value="E_AccessDenied"/>
 *     &lt;enumeration value="E_InvalidToken"/>
 *     &lt;enumeration value="E_FileNotFound"/>
 *     &lt;enumeration value="E_TokenExpired"/>
 *     &lt;enumeration value="E_ValidationFailed"/>
 *     &lt;enumeration value="E_ServerBusy"/>
 *     &lt;enumeration value="E_RowIdOutofRange"/>
 *     &lt;enumeration value="E_FeatureUnsupported"/>
 *     &lt;enumeration value="E_VersionMismatch"/>
 *     &lt;enumeration value="E_InvalidFileName"/>
 *     &lt;enumeration value="E_InvalidFileType"/>
 *     &lt;enumeration value="E_InvalidDataflow"/>
 *     &lt;enumeration value="E_InvalidParameter"/>
 *     &lt;enumeration value="E_AuthMethod"/>
 *     &lt;enumeration value="E_Unknown"/>
 *     &lt;enumeration value="E_QueryReturnSetTooBig"/>
 *     &lt;enumeration value="E_DBMSError"/>
 *     &lt;enumeration value="E_RecipientNotSupported"/>
 *     &lt;enumeration value="E_NotificationURINotSupported"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "ErrorCodeList")
@XmlEnum
public enum ErrorCodeList {

    @XmlEnumValue("E_UnknownUser")
    E_UNKNOWN_USER("E_UnknownUser"),
    @XmlEnumValue("E_InvalidCredential")
    E_INVALID_CREDENTIAL("E_InvalidCredential"),
    @XmlEnumValue("E_TransactionId")
    E_TRANSACTION_ID("E_TransactionId"),
    @XmlEnumValue("E_UnknownMethod")
    E_UNKNOWN_METHOD("E_UnknownMethod"),
    @XmlEnumValue("E_ServiceUnavailable")
    E_SERVICE_UNAVAILABLE("E_ServiceUnavailable"),
    @XmlEnumValue("E_AccessDenied")
    E_ACCESS_DENIED("E_AccessDenied"),
    @XmlEnumValue("E_InvalidToken")
    E_INVALID_TOKEN("E_InvalidToken"),
    @XmlEnumValue("E_FileNotFound")
    E_FILE_NOT_FOUND("E_FileNotFound"),
    @XmlEnumValue("E_TokenExpired")
    E_TOKEN_EXPIRED("E_TokenExpired"),
    @XmlEnumValue("E_ValidationFailed")
    E_VALIDATION_FAILED("E_ValidationFailed"),
    @XmlEnumValue("E_ServerBusy")
    E_SERVER_BUSY("E_ServerBusy"),
    @XmlEnumValue("E_RowIdOutofRange")
    E_ROW_ID_OUTOF_RANGE("E_RowIdOutofRange"),
    @XmlEnumValue("E_FeatureUnsupported")
    E_FEATURE_UNSUPPORTED("E_FeatureUnsupported"),
    @XmlEnumValue("E_VersionMismatch")
    E_VERSION_MISMATCH("E_VersionMismatch"),
    @XmlEnumValue("E_InvalidFileName")
    E_INVALID_FILE_NAME("E_InvalidFileName"),
    @XmlEnumValue("E_InvalidFileType")
    E_INVALID_FILE_TYPE("E_InvalidFileType"),
    @XmlEnumValue("E_InvalidDataflow")
    E_INVALID_DATAFLOW("E_InvalidDataflow"),
    @XmlEnumValue("E_InvalidParameter")
    E_INVALID_PARAMETER("E_InvalidParameter"),
    @XmlEnumValue("E_AuthMethod")
    E_AUTH_METHOD("E_AuthMethod"),
    @XmlEnumValue("E_Unknown")
    E_UNKNOWN("E_Unknown"),
    @XmlEnumValue("E_QueryReturnSetTooBig")
    E_QUERY_RETURN_SET_TOO_BIG("E_QueryReturnSetTooBig"),
    @XmlEnumValue("E_DBMSError")
    E_DBMS_ERROR("E_DBMSError"),
    @XmlEnumValue("E_RecipientNotSupported")
    E_RECIPIENT_NOT_SUPPORTED("E_RecipientNotSupported"),
    @XmlEnumValue("E_NotificationURINotSupported")
    E_NOTIFICATION_URI_NOT_SUPPORTED("E_NotificationURINotSupported");
    private final String value;

    ErrorCodeList(String v) {
        value = v;
    }

    public String value() {
        return value;
    }

    public static ErrorCodeList fromValue(String v) {
        for (ErrorCodeList c: ErrorCodeList.values()) {
            if (c.value.equals(v)) {
                return c;
            }
        }
        throw new IllegalArgumentException(v);
    }

}
