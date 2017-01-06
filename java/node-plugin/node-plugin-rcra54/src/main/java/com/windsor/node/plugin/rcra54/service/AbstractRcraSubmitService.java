package com.windsor.node.plugin.rcra54.service;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.xml.bind.JAXBElement;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.exception.ExceptionUtils;

import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.RequestType;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.common.xml.validation.ValidationResult;
import com.windsor.node.plugin.common.xml.validation.Validator;
import com.windsor.node.plugin.common.xml.validation.jaxb.JaxbXmlValidator;
import com.windsor.node.plugin.rcra54.domain.ObjectFactory;
import com.windsor.node.plugin.rcra54.domain.OperationType;
import com.windsor.node.plugin.rcra54.domain.PluginParameters;
import com.windsor.node.plugin.rcra54.domain.ScheduleParameters;

public abstract class AbstractRcraSubmitService<T> extends AbstractRcraService {
	
	private static final String ARG_HEADER_STORED_PROCEDURE = "Stored Procedure";
	private static final String ARG_HEADER_RCRA_INFO_STATE_CODE = "RCRAInfoStateCode";
	private static final String ARG_HEADER_RCRA_INFO_USER_ID = "RCRAInfoUserID";
	private static final String ARG_HEADER_NOTIFICATION_URI = "notificationURI";
	private static final String XSD_RELATIVE_FILE_PATH = "xsd/ExchangeNetworkDocument_RCRA_V5.4.xsd";
	
	private static final List<String> HEADERS = Arrays.asList(
			ARG_ADD_HEADER,
			ARG_HEADER_AUTHOR,
            ARG_HEADER_CONTACT_INFO,
            ARG_HEADER_STORED_PROCEDURE,
            ARG_HEADER_NOTIFS,
            ARG_HEADER_ORG_NAME,
            ARG_HEADER_PAYLOAD_OP,
            ARG_HEADER_RCRA_INFO_STATE_CODE,
            ARG_HEADER_RCRA_INFO_USER_ID,
            ARG_HEADER_NOTIFICATION_URI,
            ARG_HEADER_TITLE
    );

    private ScheduleParameters scheduleParameters;
    private ObjectFactory objectFactory;

    public AbstractRcraSubmitService(OperationType operationType) {
        super(operationType);
        this.objectFactory = new ObjectFactory();
        debug("Setting internal runtime argument list");
        for (String config : HEADERS) {
            getConfigurationArguments().put(config, "");
        }
        getConfigurationArguments().put(ARG_HEADER_PAYLOAD_OP, operationType.getPayloadOperation());
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters() {
        List<PluginServiceParameterDescriptor> params = new ArrayList<>();
        for (PluginParameters p : PluginParameters.values()) {
            params.add(p.getParameterDescriptor());
        }
        return params;
    }

    @Override
    public ProcessContentResult process(NodeTransaction transaction) {
    	transaction.setOperation("");
        ProcessContentResult result = new ProcessContentResult();
        result.setStatus(CommonTransactionStatusCode.Failed);
        result.setSuccess(Boolean.FALSE);
        recordActivity(result, "RCRA \"%s\" process starting.", getOperationType());
        validateTransaction(transaction);
        recordActivity(result, "Creating process parameters from transaction.");
        scheduleParameters = new ScheduleParameters(transaction);
        recordActivity(result,
                String.format("Schedule parameters: ", scheduleParameters));

        try {
            final String documentId = getIdGenerator().createId();
            final String documentName = "RCRA_" + getOperationType().name() + documentId + ".xml";
            final String directory = getSettingService().getTempDir().getAbsolutePath();

            String storedProcedure = getConfigValueAsStringNoFail(ARG_HEADER_STORED_PROCEDURE);
            if(StringUtils.isNotBlank(storedProcedure)) {
                recordActivity(result, "Calling stored procedure \"%s\" to populate staging tables.", storedProcedure);
                getRcraDao().callStoredProcedure(storedProcedure);
            } else {
            	recordActivity(result, "No stored procedure defined -- assuming the staging tables are already populated.");
            }
            
            recordActivity(result, "Preparing XML file creator with file name %s", documentName);

            String docPath = directory + "/" + documentName;
            Document doc = generateNodeDocument(result, transaction, documentId, docPath);

            result.getDocuments().add(doc);
            transaction.getDocuments().add(doc);
            
            if (scheduleParameters.isValidateXml()) {
            	recordActivity(result, "Starting XML validation.");
            	if (isXmlPayloadDocumentNotValid(result, transaction, docPath)) {
            		recordActivity(result, "XML validation failed -- check the attached documents for more info.");
            		getTransactionDao().save(transaction);
            		return result;
            	} else {
            		recordActivity(result, "XML validation successful.");	
            	}
            } else {
            	recordActivity(result, "Skipping XML validation.");
            }
            
            recordActivity(result, "Preparing exchange for delivery. Completed.");

            recordActivity(result, "Saving exchange network transaction.");
            getTransactionDao().save(transaction);
            recordActivity(result, "Saving exchange network transaction. Completed.");

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Pending);
            recordActivity(result, "RCRA \"%s\" process completed successfully.", getOperationType());
            
            if (scheduleParameters.isUseSubmissionHistory()) {
            	recordActivity(result, "Adding a submission history record");
            	getRcraDao().saveHistory(transaction, result, getOperationType());
            } else {
            	recordActivity(result, "Not adding a submission history record");
            }
        } catch (Exception e) {
            result.setSuccess(Boolean.FALSE);
            result.setStatus(CommonTransactionStatusCode.Failed);
            recordActivity(result, e.getLocalizedMessage() + ", root cause: " + ExceptionUtils.getRootCauseMessage(e));
        }
        return result;
    }

    protected abstract T getPayloadRootEntity();
    
    protected abstract JAXBElement<T> getPayloadRootElement(ObjectFactory objectFactory, T rootEntity);
    
    private boolean isXmlPayloadDocumentNotValid(ProcessContentResult result, NodeTransaction nodeTransaction, String xmlDocFilePath) throws Exception {

        String schemaFilePath = makeXsdFilePath();

        Validator validator = new JaxbXmlValidator(schemaFilePath);

        ValidationResult validationResult = validator.validate(new FileInputStream(xmlDocFilePath));

        if (validationResult.hasErrors()) {
        	String docId = getIdGenerator().createId();
             String filename = FilenameUtils.concat(
                     getSettingService().getTempDir().getAbsolutePath(),
                     "Validation_Errors_" + this.getClass().getSimpleName() + docId + ".txt");

             File errorsFile = new File(filename);
             FileUtils.writeLines(errorsFile, validationResult.errors());

             Document doc = new Document();
             doc.setDocumentId(docId);
             doc.setId(docId);
             doc.setDocumentName("Validation Errors.txt");
             doc.setType(CommonContentType.Flat);
             doc.setDocumentStatus(CommonTransactionStatusCode.Completed);
             doc.setContent(FileUtils.readFileToByteArray(errorsFile));
             nodeTransaction.getDocuments().add(doc);
             errorsFile.delete();
        }

        return validationResult.hasErrors();
    }
    
    private Document generateNodeDocument(ProcessContentResult result, NodeTransaction nodeTransaction, String docId, String tempFilePath) {
        try {
        	T rootEntity = getPayloadRootEntity();
            JAXBElement<T> payload = getPayloadRootElement(objectFactory, rootEntity);
            JAXBElement<?> header = processV1HeaderDirectives(payload, docId, nodeTransaction.getOperation(), nodeTransaction, true);
            writeDocument(header, tempFilePath);
            Document doc = makeDocument(nodeTransaction.getRequest().getType(), docId, tempFilePath);
            nodeTransaction.getDocuments().add(doc);
            return doc;
        } catch (Exception e) {
            throw new RuntimeException("Error while generating document: " + tempFilePath, e);
        }
    }

    protected Document makeDocument(RequestType requestType, String documentId, String absolutefilePath) throws IOException
    {
        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if(!RequestType.Submit.equals(requestType)) {
            String zippedFilePath = getCompressionService().zip(absolutefilePath);
            doc.setType(CommonContentType.ZIP);
            doc.setDocumentName(FilenameUtils.getName(zippedFilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(zippedFilePath)));
        } else {
            doc.setType(CommonContentType.XML);
            doc.setDocumentName(FilenameUtils.getName(absolutefilePath));
            doc.setContent(FileUtils.readFileToByteArray(new File(absolutefilePath)));
        }
        return doc;
    }
    
    @Override
	protected List<String> getAdditionalPropertyNames() {
    	return Arrays.asList(ARG_HEADER_RCRA_INFO_STATE_CODE, 
    			ARG_HEADER_RCRA_INFO_USER_ID, 
    			ARG_HEADER_NOTIFICATION_URI);
	}

	private String makeXsdFilePath() {
        return FilenameUtils.concat(getPluginSourceDir().getAbsolutePath(),
                XSD_RELATIVE_FILE_PATH);
    }
	
}
