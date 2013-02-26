package com.windsor.node.plugin.wqx.service;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;

import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.common.file.FileCreator;
import com.windsor.node.plugin.common.file.XmlFileCreator;
import com.windsor.node.plugin.common.xml.document.ElementWriteHandler;
import com.windsor.node.plugin.common.xml.document.ElementsDataProvider;
import com.windsor.node.plugin.common.xml.document.StreamXmlFileGenerator;
import com.windsor.node.plugin.common.xml.stream.ElementWriter;
import com.windsor.node.plugin.wqx.dao.OrganizationNotFoundException;
import com.windsor.node.plugin.wqx.document.CompressingExchangeNetworkDocumentFactory;
import com.windsor.node.plugin.wqx.document.ExchangeNetworkDocumentFactory;
import com.windsor.node.plugin.wqx.domain.Header;
import com.windsor.node.plugin.wqx.domain.OperationType;
import com.windsor.node.service.helper.zip.ZipCompressionService;

public abstract class AbstractSubmittingWqxService<L extends List<T>, T> extends AbstractWqxService implements ElementsDataProvider<List<T>>, ElementWriteHandler<T> {

    private ScheduleParameters scheduleParameters;

    protected abstract OperationType submissionType();

    protected abstract List<List<T>> getSubmissionData(ScheduleParameters parameters);

    protected abstract ElementWriter getJaxbElementWriter(ScheduleParameters parameters, Header headerData);

    protected abstract void writeElement(ElementWriter writer, Object t);

    @Override
    public Iterable<List<T>> elements() {
        return getSubmissionData(scheduleParameters);
    }

    @Override
    public void handle(ElementWriter writer, T t) {

        List<?> list = (List<?>) t;

        for (int index = 0 ; index < list.size() ; index++) {
            writeElement(writer, list.get(index));
        }
    }

    @Override
    protected List<String> configurationArguments() {
        List<String> args = new ArrayList<String>();
        args.add(ARG_HEADER_AUTHOR);
        args.add(ARG_HEADER_ORG_NAME);
        args.add(ARG_HEADER_TITLE);
        args.add(ARG_HEADER_CONTACT_INFO);
        return args;
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {

        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();

        params.add(ORG_ID);                     // available @ index = 0
        params.add(USE_SUBMISSION_HISTORY);     // available @ index = 1
        params.add(START_DATE);                 // available @ index = 2
        params.add(END_DATE);                   // available @ index = 3
        params.add(SUBMISSION_PARTNER_NAME);    // available @ index = 4
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {

        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);

        recordAtivity(result, "WQX \"%s\" process starting.", submissionType());

        validateTransaction(transaction);

        recordAtivity(result, "Creating process parameters from transaction.");

        scheduleParameters = new ScheduleParameters(transaction);

        recordAtivity(result, "Creating process parameters from transaction. Completed.");

        recordAtivity(result, String.format("Service is configured for WQX organization \"%s\".", scheduleParameters.getOrgId()));

        try  {

            if (scheduleParameters.isUseSubmissionHistory()) {

                recordAtivity(result, "Using submission history.");

                recordAtivity(result, "Checking for pending submissions.");

                checkForPendingSubmissions(submissionType(), scheduleParameters.getOrgId());

                recordAtivity(result, "Checking for pending submissions. None found, continuing.");

            } else {
                recordAtivity(result, "Ignoring submission history.");
            }

            /**
             * XML file name & directory setup
             */
            final String documentId = getIdGenerator().createId();

            final String documentName = "WQX_" + submissionType().name() + documentId;

            final String directory = getPluginTempDirectory().getAbsolutePath();

            /**
             * FileCreator
             */
            recordAtivity(result, "Preparing XML file creator with file name %s", documentName);

            final FileCreator fileCreator = new XmlFileCreator(directory, documentName);

            recordAtivity(result, "Preparing XML file creator. Completed.");

            /**
             * Document generation setup
             */
            recordAtivity(result, "Preparing XML output stream writer.");

            final Header headerData = new Header(documentId, submissionType().operation(), getAuthor(), getOrganization(), getDocumentTitle(), "Windsor WQX Plugin", getContactInfo());

            ElementWriter elementWriter = getJaxbElementWriter(scheduleParameters, headerData);

            StreamXmlFileGenerator xmlGenerator = new StreamXmlFileGenerator(fileCreator, this, this, elementWriter);

            recordAtivity(result, "Preparing XML output stream writer. Completed.");

            /**
             * Generate XML file
             */
            recordAtivity(result, "Streaming WQX data to file.");

            File wqxXmlFile = xmlGenerator.generate();

            recordAtivity(result, "Streaming WQX data to file. Completed.");

            /**
             * Create exchange document
             */
            recordAtivity(result, "Preparing exchange for delivery.");

            ZipCompressionService zipService = new ZipCompressionService();

            zipService.setTempDir(getPluginTempDirectory());

            ExchangeNetworkDocumentFactory docFactory = new CompressingExchangeNetworkDocumentFactory(zipService, transaction);

            docFactory.add(wqxXmlFile);

            Document doc = docFactory.make(documentId);

            result.getDocuments().add(doc);
            transaction.getDocuments().add(doc);

            recordAtivity(result, "Preparing exchange for delivery. Completed.");

            /**
             * Try to create node client and submit document.
             */
            if (StringUtils.isNotBlank(getSubmissionPartnerName(scheduleParameters))) {

                try {

                    recordAtivity(result, "Preparing to submit document to \"%s\"", getSubmissionPartnerName(scheduleParameters));

                    NodeClientService client = getNodeClientService(scheduleParameters, transaction);

                    recordAtivity(result, "Preparing to submit document to \"%s\". Completed.", getSubmissionPartnerName(scheduleParameters));

                    recordAtivity(result, "Submitting document.");

                    transaction = client.submit(transaction);

                    recordAtivity(result, "Submitting document. Completed.");

                } catch (Exception e) {
                    recordAtivity(result, e.getLocalizedMessage());
                    return result;
                }

                recordAtivity(result, "Submission returned with transaction id \"%s\"", transaction.getNetworkId());

            } else {
                recordAtivity(result, "Submission Partner Name is not configured, process will not be submitting document to exchange network.");
            }

            /**
             * Save the node transaction.
             */
            recordAtivity(result, "Saving exchange network transaction.");

            getTransactionDao().save(transaction);

            recordAtivity(result, "Saving exchange network transaction. Completed.");

            /**
             * Create a new submission history record if configured to do so.
             */
            if(scheduleParameters.isUseSubmissionHistory()) {

                recordAtivity(result, "Creating WQX submission history record.");

                getEntityManager().getTransaction().begin();

                getSubmissionHistoryDao().createSubmissionHistoryRecord(
                        getIdGenerator().createId(),
                        scheduleParameters.getOrgId(),
                        submissionType().operation(),
                        transaction.getId(),
                        CommonTransactionStatusCode.Pending);

                getEntityManager().getTransaction().commit();

                recordAtivity(result, "Creating WQX submission history record. Completed.");
            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Pending);

            recordAtivity(result, "WQX \"%s\" process completed successfully.", submissionType());

        } catch (OrganizationNotFoundException onfe) {
            result.setSuccess(Boolean.FALSE);
            result.setStatus(CommonTransactionStatusCode.Failed);
            recordAtivity(result, onfe.getLocalizedMessage());

        } catch (Exception e) {
            result.setSuccess(Boolean.FALSE);
            result.setStatus(CommonTransactionStatusCode.Failed);
            recordAtivity(result, e.getLocalizedMessage() + ", root cause: " + ExceptionUtils.getRootCauseMessage(e));
        }
        return result;
    }

    private void checkForPendingSubmissions(OperationType operationType, String orgId) throws PendingSubmissionInProgressException {

        if (getSubmissionHistoryDao().pendingTransactionsExist(orgId, operationType.operation())) {
            throw new PendingSubmissionInProgressException(String.format("Found a pending \"%s\" operation for organization \"%s\". Exiting.", operationType.name(), orgId));
        }
    }

    protected final void validateTransaction(NodeTransaction transaction, ScheduleParameters scheduleParameters) {

        super.validateTransaction(transaction);

        if (null == scheduleParameters.getOrgId()) {
            throw new RuntimeException("Missing parameter: " + ORG_ID.getName() );
        }
    }

}
