package com.windsor.node.plugin.rcra54.solicit;

import com.windsor.node.common.domain.*;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.rcra54.Rcra54OutboundException;
import com.windsor.node.plugin.rcra54.domain.generated.SolicitHistory;
import com.windsor.node.plugin.rcra54.download.DownloadRequest;
import com.windsor.node.plugin.rcra54.outbound.BaseRcra54Plugin;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra54.solicit.request.SolicitRequestType;
import com.windsor.node.plugin.rcra54.status.GetStatusRequest;
import com.windsor.node.service.helper.client.NodeClientFactory;
import net.exchangenetwork.schema.node._2.DownloadResponse;
import net.exchangenetwork.schema.node._2.NodeDocumentType;
import net.exchangenetwork.schema.node._2.StatusResponseType;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;

import javax.persistence.Query;
import javax.xml.bind.*;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import static java.lang.String.format;

/**
 * Provides the plugin operation for soliciting data from RCRAInfo.
 *
 * T is the type of submission returned by RCRA Info
 */
public abstract class SolicitOperation extends BaseRcra54Plugin {

    /**
     * Flag indicating that we'll be using/recording the solicit history.
     */
    private Boolean useHistory;

    private String partnerName;

    /**
     * The plugin service implementor description for this plugin.
     * @return Plugin service implementor description instance
     */
    @Override
    public abstract PluginServiceImplementorDescriptor getPluginServiceImplementorDescription();

    /**
     * Returns the solicit request type.
     * @return The solicit request type
     */
    public abstract SolicitRequestType getRequestType();

    @Override
    public void afterPropertiesSet() {
        super.afterPropertiesSet();
        if (StringUtils.isBlank(partnerName)) {
            partnerName = getRequiredConfigValueAsString(ARG_PARTNER_NAME);
        }
        debug("partnerName: " + partnerName);
    }

    protected PartnerIdentity getPartner() {

        logger.debug("Looking for partner named " + partnerName);

        List<?> partners = getPartnerDao().get();

        PartnerIdentity partner = null;

        for (int i = 0; i < partners.size(); i++) {

            PartnerIdentity testPartner = (PartnerIdentity) partners.get(i);
            logger.debug("Found partner named " + testPartner.getName());

            if (testPartner.getName().equals(partnerName)) {

                logger.debug("Found partner match");
                partner = testPartner;
                break;
            }
        }

        if (null == partner) {
            throw new RuntimeException("No partner named " + partnerName
                    + " exists in partner configuration.");
        }

        return partner;

    }

    public String getPartnerName() {
        return partnerName;
    }

    public void setPartnerName(String partnerName) {
        this.partnerName = partnerName;
    }

    /**
     * Handles the creation of the initial solicit request.
     * @param requestFactory Factory that can create request for any solicit type
     * @param namedParams Map of parameters for the schedule
     * @return A new SolicitRequest instance
     */
    public abstract SolicitRequest handleGetRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams)
            throws Rcra54OutboundException;

    public SolicitRequest getRequest(SolicitRequestFactory requestFactory, ByIndexOrNameMap namedParams) throws Rcra54OutboundException {

        String useHistoryString = null;
        if(namedParams.get(SolicitOperation.PARAM_USE_SOLICIT_HISTORY.getName()) != null) {
            useHistoryString = namedParams.get(SolicitOperation.PARAM_USE_SOLICIT_HISTORY.getName()).toString();
        }

        if (useHistoryString != null && useHistoryString.trim() != null) {
            if (useHistoryString.trim().toLowerCase().equals("true") ||
                    useHistoryString.trim().toLowerCase().equals("yes") ||
                    useHistoryString.trim().toLowerCase().equals("on")) {
                useHistory = true;
            }
        }

        return handleGetRequest(requestFactory, namedParams);
    };

    /**
     * Returns true if the solicity history is in use.
     * @return Flag indiciating if solicity history is in use
     */
    public Boolean getUseHistory() {
        return useHistory;
    }

    /**
     * If the solicit history is in use, returns the last successful solicit
     * history record or null if there has not yet been a successful solicit.
     * @return Last successful solicit history record
     */
    public SolicitHistory getSolicitHistoryLast() {
        SolicitHistory solicitHistoryMostRecent = null;

        // query for the most recent successful solicit complete for this function type
        Query query = getTargetEntityManager().createQuery(
                "from SolicitHistory where solicitType = :solicitType and status = :status order by runDate desc");
        query.setParameter("solicitType", getRcraServiceName());
        query.setParameter("status", SolicitHistory.Status.COMPLETE.getName());
        @SuppressWarnings("unchecked")
		List<SolicitHistory> results = query.getResultList();

        if(results != null && results.size() > 0) {
            solicitHistoryMostRecent = results.get(0);
        }

        return solicitHistoryMostRecent;
    }

    /**
     * Returns the RCRA service name for this plugin.
     * @return String with the RCRA service name
     */
    public String getRcraServiceName() {
        return getRequestType().toString();
    }

    /**
     * Creates a new solicit operation.
     */
    public SolicitOperation() {
        super();

        debug("Setting service types");
        getSupportedPluginTypes().add(ServiceType.TASK);
        debug(getRcraServiceName() + " instantiated");
    }

    /**
     * Returns the set of plugin service parameters for this plugin.
     * @return List of plugin service parameters
     */
    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> parameters = new ArrayList<>();
        parameters.addAll(Arrays.asList(ParameterSet.getByName(getRcraServiceName()).getParameterDescriptors()));
        return parameters;
    }

    /**
     * Persist a data object to the database.
     * @param object
     */
    public void persistData(Object object) {
        boolean merge = false;
        if (object instanceof SolicitHistory) {
            SolicitHistory solicitHistory = (SolicitHistory) object;
            merge = solicitHistory.getId() != null;
        }
        getTargetEntityManager().getTransaction().begin();
        if (merge) {
            getTargetEntityManager().merge(object);
        } else {
            getTargetEntityManager().persist(object);
        }
        getTargetEntityManager().getTransaction().commit();
    }

    /**
     * Returns the service request parameters specs for the plugin. This
     * implementation does not return any such parameters.
     * @param serviceName
     *            in case a singe plugin implementation class implements more
     *            than one service
     * @return Null, this plugin doesn't implement them
     */
    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName) {
        return null;
    }


    /**
     * Begins the solicit and download process.
     *
     * @param transaction
     *            typically created by the Node
     * @return ProcessContentResult instance with details of the transaction
     */
    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        // FIXME: if there is an outstanding request of the given type -- don't make another request

        // flag indicating our data is okay for processing
        boolean preProcessSuccessful = true;

        // setup our result
        transaction.setOperation(getRcraServiceName());
        transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Pending));
        getTransactionDao().save(transaction);
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Pending);
        result.getAuditEntries().add(new ActivityEntry("RCRA Solicit Operation process is starting..."));

        // setup our endpoint
        PartnerIdentity partner = getPartner();
        info("Endpoint: " + partner.getUrl());
        result.getAuditEntries().add(new ActivityEntry("Sending " + getRcraServiceName() + " solicit request to "
                + partner.getName() + " at " + partner.getUrl()));

        // schedule parameters
        ByIndexOrNameMap namedParams = transaction.getRequest().getParameters();
        ParameterSet parameterSet = ParameterSet.getByName(getRcraServiceName());
        for(PluginServiceParameterDescriptor parameterDescriptor : parameterSet.getParameterDescriptors()) {
            info(parameterDescriptor.getName() + ": " + namedParams.get(parameterDescriptor.getName()));
        }

        // setup our node client
        NodeClientFactory clientFactory =
                (NodeClientFactory) getServiceFactory().makeService(NodeClientFactory.class);
        NodeClientService clientService = clientFactory.makeAndConfigure(partner);

        // setup our query request
        SolicitRequestFactory requestFactory = new SolicitRequestFactory(partner.getUrl().toString(),
                clientService.authenticate());
        SolicitRequest request = null;

        try {
            request = getRequest(requestFactory, namedParams);
        } catch(Rcra54OutboundException exception) {
            logger.warn("Caught RCRA exception! " + exception.getMessage(), exception);
            error(exception.getMessage(), exception);
            result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                    "creating the solicit request for the partner service. This usually indicates that the " +
                    "schedule is not configured correctly, perhaps there is some data missing that is required. " +
                    "The exception was: " + exception.getMessage()));
            preProcessSuccessful = false;
        }

        // Current solicit history record
        SolicitHistory solicitHistory = null;

        if(preProcessSuccessful) {
            try {

                // execute our query request against our endpoint
                StatusResponseType queryResponseType = request.execute();
                info("Response: " + queryResponseType.getTransactionId());
                info("Response: " + queryResponseType.getStatus());
                info("Response: " + queryResponseType.getStatusDetail());
                result.getAuditEntries().add(
                        new ActivityEntry("Received response: " +
                                queryResponseType.getStatus() + " with detail \"" +
                                queryResponseType.getStatusDetail() + "\""));
                result.getAuditEntries().add(
                        new ActivityEntry("Solicit request transaction id: " +
                                queryResponseType.getTransactionId()));

                // save our pending transaction id
                transaction.setNetworkId(queryResponseType.getTransactionId());
                transaction.setNetworkEndpointUrl(partner.getUrl());
                transaction.setNetworkEndpointVersion(partner.getVersion());
                getTransactionDao().save(transaction);

                // save our solicit history record
                solicitHistory = new SolicitHistory(transaction.getId(), getRcraServiceName());
                persistData(solicitHistory);

                if (useHistory != null && useHistory) {
                    result.getAuditEntries().add(new ActivityEntry("Using submission history..."));
                    if (getSolicitHistoryLast() != null) {
                        result.getAuditEntries().add(new ActivityEntry("Submission history change date: "
                                + getSolicitHistoryLast().getRunDateFormatted()));
                    }
                } else {
                    String changeDate = (String) namedParams.get(SolicitOperation.PARAM_CHANGE_DATE.getName().toString());
                    result.getAuditEntries().add(new ActivityEntry("Using change date: "
                            + changeDate));
                }

            } catch (Exception exception) {
                error("Exception while communicating with " + partner.getName() + ": " + exception.getMessage(), exception);
                result.getAuditEntries().add(new ActivityEntry("There was a problem " +
                        "communicating with " + partner.getName() + " , this could " +
                        "be due to a network issue or downtime at " + partner.getName() +
                        "If you were querying the EPA, please contact " +
                        "nodehelpdesk@epacdx.net for more detailed information. The " +
                        "exception was: " + exception.getMessage()));
                setTransactionFailed(result, transaction, solicitHistory);
            }
        } else {

            // pre-processing for this transaction has failed
            error("Pre-processing for this transaction failed, required data for the plugin or schedule is missing " +
                    "or incorrect, transaction has been aborted.");
            result.getAuditEntries().add(new ActivityEntry("There was a problem processing the settings for the " +
                    "schedule and the plugin, some required data was missing. Please consult the activity log for more " +
                    "information on what was missing and update the exchange and schedule accordingly."));
            setTransactionFailed(result, transaction, solicitHistory);
        }

        // save our transaction
        getTransactionDao().save(transaction);

        result.setSuccess(true);
        result.getAuditEntries().add(new ActivityEntry("RCRA Solicit Operation process complete."));
        return result;
    }

    /**
     * Performs a "status" request to the partnet against the provided
     * transaction identifier and returns the response from that endpoint.
     *
     * @param partner The partner endpoint
     * @param clientService Node client service instance to use
     * @param transactionId The transaction id whose status will be checked
     * @return The status of the transaction
     * @throws NodeFaultMessage On any exception from the partner endpoint
     */
    private StatusResponseType getTransactionStatus(PartnerIdentity partner,
                                      NodeClientService clientService,
                                      String transactionId)
            throws NodeFaultMessage {

        String token = clientService.authenticate();
        logger.info("Received new authentication token: " + token);
        GetStatusRequest getStatusRequest = new GetStatusRequest(partner.getUrl().toString(), token,
                transactionId);
        StatusResponseType responseType = getStatusRequest.execute();
        info(transactionId + " Response: " + responseType.getStatus());
        info(transactionId + " Response: " + responseType.getStatusDetail());

        return responseType;
    }

    /**
     * Sets the provided transaction to "failed" and updates the solicit
     * history record, if present.
     *
     * @param result The processing result that failed
     * @param transaction The transaction that failed
     * @param solicitHistory The solicit history instance
     */
    private void setTransactionFailed(ProcessContentResult result,
                                      NodeTransaction transaction,
                                      SolicitHistory solicitHistory) {
        result.setSuccess(false);
        result.setStatus(CommonTransactionStatusCode.Failed);
        transaction.setStatus(new TransactionStatus(CommonTransactionStatusCode.Failed));

        if(useHistory != null && useHistory && solicitHistory != null) {
            solicitHistory.setStatus(SolicitHistory.Status.FAILED);
        }
    }

}
