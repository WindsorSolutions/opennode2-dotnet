
package net.exchangenetwork.schema.node._2;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the net.exchangenetwork.schema.node._2 package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _SubmitResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "SubmitResponse");
    private final static QName _QueryResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "QueryResponse");
    private final static QName _NotifyResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "NotifyResponse");
    private final static QName _GetServicesResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "GetServicesResponse");
    private final static QName _GetStatusResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "GetStatusResponse");
    private final static QName _SolicitResponse_QNAME = new QName("http://www.exchangenetwork.net/schema/node/2", "SolicitResponse");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: net.exchangenetwork.schema.node._2
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link AuthenticateResponse }
     * 
     */
    public AuthenticateResponse createAuthenticateResponse() {
        return new AuthenticateResponse();
    }

    /**
     * Create an instance of {@link StatusResponseType }
     * 
     */
    public StatusResponseType createStatusResponseType() {
        return new StatusResponseType();
    }

    /**
     * Create an instance of {@link Query }
     * 
     */
    public Query createQuery() {
        return new Query();
    }

    /**
     * Create an instance of {@link ParameterType }
     * 
     */
    public ParameterType createParameterType() {
        return new ParameterType();
    }

    /**
     * Create an instance of {@link Execute }
     * 
     */
    public Execute createExecute() {
        return new Execute();
    }

    /**
     * Create an instance of {@link Notify }
     * 
     */
    public Notify createNotify() {
        return new Notify();
    }

    /**
     * Create an instance of {@link NotificationMessageType }
     * 
     */
    public NotificationMessageType createNotificationMessageType() {
        return new NotificationMessageType();
    }

    /**
     * Create an instance of {@link Solicit }
     * 
     */
    public Solicit createSolicit() {
        return new Solicit();
    }

    /**
     * Create an instance of {@link NotificationURIType }
     * 
     */
    public NotificationURIType createNotificationURIType() {
        return new NotificationURIType();
    }

    /**
     * Create an instance of {@link DownloadResponse }
     * 
     */
    public DownloadResponse createDownloadResponse() {
        return new DownloadResponse();
    }

    /**
     * Create an instance of {@link NodeDocumentType }
     * 
     */
    public NodeDocumentType createNodeDocumentType() {
        return new NodeDocumentType();
    }

    /**
     * Create an instance of {@link ExecuteResponse }
     * 
     */
    public ExecuteResponse createExecuteResponse() {
        return new ExecuteResponse();
    }

    /**
     * Create an instance of {@link GenericXmlType }
     * 
     */
    public GenericXmlType createGenericXmlType() {
        return new GenericXmlType();
    }

    /**
     * Create an instance of {@link GetServices }
     * 
     */
    public GetServices createGetServices() {
        return new GetServices();
    }

    /**
     * Create an instance of {@link Authenticate }
     * 
     */
    public Authenticate createAuthenticate() {
        return new Authenticate();
    }

    /**
     * Create an instance of {@link NodeFaultDetailType }
     * 
     */
    public NodeFaultDetailType createNodeFaultDetailType() {
        return new NodeFaultDetailType();
    }

    /**
     * Create an instance of {@link ResultSetType }
     * 
     */
    public ResultSetType createResultSetType() {
        return new ResultSetType();
    }

    /**
     * Create an instance of {@link NodePingResponse }
     * 
     */
    public NodePingResponse createNodePingResponse() {
        return new NodePingResponse();
    }

    /**
     * Create an instance of {@link Submit }
     * 
     */
    public Submit createSubmit() {
        return new Submit();
    }

    /**
     * Create an instance of {@link Download }
     * 
     */
    public Download createDownload() {
        return new Download();
    }

    /**
     * Create an instance of {@link NodePing }
     * 
     */
    public NodePing createNodePing() {
        return new NodePing();
    }

    /**
     * Create an instance of {@link GetStatus }
     * 
     */
    public GetStatus createGetStatus() {
        return new GetStatus();
    }

    /**
     * Create an instance of {@link AttachmentType }
     * 
     */
    public AttachmentType createAttachmentType() {
        return new AttachmentType();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link StatusResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "SubmitResponse")
    public JAXBElement<StatusResponseType> createSubmitResponse(StatusResponseType value) {
        return new JAXBElement<StatusResponseType>(_SubmitResponse_QNAME, StatusResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link ResultSetType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "QueryResponse")
    public JAXBElement<ResultSetType> createQueryResponse(ResultSetType value) {
        return new JAXBElement<ResultSetType>(_QueryResponse_QNAME, ResultSetType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link StatusResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "NotifyResponse")
    public JAXBElement<StatusResponseType> createNotifyResponse(StatusResponseType value) {
        return new JAXBElement<StatusResponseType>(_NotifyResponse_QNAME, StatusResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link GenericXmlType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "GetServicesResponse")
    public JAXBElement<GenericXmlType> createGetServicesResponse(GenericXmlType value) {
        return new JAXBElement<GenericXmlType>(_GetServicesResponse_QNAME, GenericXmlType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link StatusResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "GetStatusResponse")
    public JAXBElement<StatusResponseType> createGetStatusResponse(StatusResponseType value) {
        return new JAXBElement<StatusResponseType>(_GetStatusResponse_QNAME, StatusResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link StatusResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "http://www.exchangenetwork.net/schema/node/2", name = "SolicitResponse")
    public JAXBElement<StatusResponseType> createSolicitResponse(StatusResponseType value) {
        return new JAXBElement<StatusResponseType>(_SolicitResponse_QNAME, StatusResponseType.class, null, value);
    }

}
