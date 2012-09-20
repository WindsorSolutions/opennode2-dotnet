package com.windsor.node.plugin.icisnpdes40.results.xml;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.transform.Source;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.stream.StreamResult;
import javax.xml.transform.stream.StreamSource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionAcceptedDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionErrorDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionErrorsDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionResponseDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionResultList;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionTypeDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionsAcceptedDataType;
import com.windsor.node.plugin.icisnpdes40.generated.SubmittingPartyDataType;
import com.windsor.node.plugin.icisnpdes40.results.IcisStatusResult;

public class JaxbResultsParser implements ResultsParser
{
    private static final String RELATIVE_RESULTS_XSLT_PATH = "xsd" + File.separator + "MappingMapToSubmissionResults.xslt";
    protected Logger logger = LoggerFactory.getLogger(JaxbResultsParser.class);

    /*
     * (non-Javadoc)
     * @see com.windsor.node.plugin.icisnpdes40.results.xml.ResultsParser#parse(byte[])
     */
    @Override
    public SubmissionResultList parse(byte[] fileBytes, BaseWnosJaxbPlugin caller) throws JAXBException
    {
        try
        {
            //First transform the file with the XSLT
            ByteArrayInputStream in = new ByteArrayInputStream(fileBytes);
            File xsltIn = getXsltFileInputStream(caller);
            Source xmlSource = new StreamSource(in);
            Source xsltSource = new StreamSource(xsltIn);//Doing it this way implicitly sets the systemId

            // the factory pattern supports different XSLT processors
            TransformerFactory transFact = TransformerFactory.newInstance("org.apache.xalan.processor.TransformerFactoryImpl", JaxbResultsParser.class.getClassLoader());
            Transformer trans = transFact.newTransformer(xsltSource);

            File transformedResultFile = File.createTempFile("resultsin", ".xml"); // /tmp directory FIXME Hack
            trans.transform(xmlSource, new StreamResult(transformedResultFile));
            /*Templates template = getTemplate(xsltIn, factory);
            Transformer transformer = getTransformer(template);
            Source source = new StreamSource(in);
            File transformedResultFile = File.createTempFile("resultsin", ".xml");
            Result result = new StreamResult(new FileOutputStream(transformedResultFile));
            transformer.transform(source, result);*/

            //Now marshal it with JAXB
            FileInputStream transformedIn = new FileInputStream(transformedResultFile);
            JAXBContext jaxbCtxt = JAXBContext.newInstance("com.windsor.node.plugin.icisnpdes40.generated",
                                                           JaxbResultsParser.class.getClassLoader());
            Unmarshaller u = jaxbCtxt.createUnmarshaller();

            Object o = u.unmarshal(transformedIn);

            if (o != null) {
                return (SubmissionResultList)o;
            } else {
                return null;
            }

        }
        catch(Exception e)
        {
            logger.debug("Caught Exception:", e);
            throw new WinNodeException(e.getLocalizedMessage(), e);
        }
    }

    /*private Transformer getTransformer(Templates template) throws TransformerConfigurationException
    {
        return template.newTransformer();
    }

    private Templates getTemplate(FileInputStream xsltIn, TransformerFactory factory) throws TransformerConfigurationException
    {
        return factory.newTemplates(new StreamSource(xsltIn));
    }*/

    //private FileInputStream getXsltFileInputStream(BaseWnosJaxbPlugin caller) throws FileNotFoundException
    private File getXsltFileInputStream(BaseWnosJaxbPlugin caller) throws FileNotFoundException
    {
        String xsltFilePath = caller.getPluginSourceDir().getAbsolutePath() + File.separator + RELATIVE_RESULTS_XSLT_PATH;
        //return new FileInputStream(new File(xsltFilePath));
        return new File(xsltFilePath);
    }

    private List<IcisStatusResult> deserializeXml(Object value)
    {
        List<IcisStatusResult> results = new ArrayList<IcisStatusResult>();
        if(value instanceof SubmissionResponseDataType)
        {
            SubmissionResponseDataType response = (SubmissionResponseDataType)value;
            for(int i = 0; response.getSubmittingParty() != null && i < response.getSubmittingParty().size(); i++)
            {
                SubmittingPartyDataType submittingParty = response.getSubmittingParty().get(i);
                results.addAll(createIcisStatusResultsFromSubmittingParty(submittingParty, response));
            }
        }
        else
        {
            // Xml was wrong type, log and possible error?
        }
        return results;
    }

    private List<IcisStatusResult> createIcisStatusResultsFromSubmittingParty(SubmittingPartyDataType submittingParty,
                    SubmissionResponseDataType response)
    {
        List<IcisStatusResult> results = new ArrayList<IcisStatusResult>();
        for(int i = 0; submittingParty.getSubmissionType() != null && i < submittingParty.getSubmissionType().size(); i++)
        {
            SubmissionTypeDataType submissionType = submittingParty.getSubmissionType().get(i);
            for(int j = 0; submissionType.getSubmissionsAccepted() != null && j < submissionType.getSubmissionsAccepted().size(); j++)
            {
                SubmissionsAcceptedDataType submissionsAccepted = submissionType.getSubmissionsAccepted().get(j);

                // SubmissionsAccepted and SubmissionErrors are siblings in the same XSD structure, one or the other
                // will exist, so check both lists and add their crud
                for(int k = 0; submissionsAccepted.getSubmissionAccepted() != null
                                && k < submissionsAccepted.getSubmissionAccepted().size(); k++)
                {
                    IcisStatusResult result = createbaseIcisStatusResult(submittingParty, response, submissionType);
                    SubmissionAcceptedDataType submissionAccepted = submissionsAccepted.getSubmissionAccepted().get(k);
                    if(submissionAccepted != null && submissionAccepted.getSubmissionAcceptedKey() != null
                                    && submissionAccepted.getSubmissionAcceptedKey().getPermittedFeatureRecordIdentifier() != null)
                    {
                        result.setSubmissionTransactionTypeCode(submissionAccepted.getSubmissionAcceptedKey()
                                        .getSubmissionTransactionTypeCode().value());
                        result.setPermitIdentifier(submissionAccepted.getSubmissionAcceptedKey().getPermittedFeatureRecordIdentifier()
                                        .getPermitIdentifier());
                        result.setPermittedFeatureIdentifier(submissionAccepted.getSubmissionAcceptedKey()
                                        .getPermittedFeatureRecordIdentifier().getPermittedFeatureIdentifier());
                    }
                    results.add(result);
                }

                SubmissionErrorsDataType submissionErrors = submissionType.getSubmissionErrors().get(j);
                for(int l = 0; submissionErrors != null && l < submissionErrors.getSubmissionError().size(); l++)
                {
                    IcisStatusResult result = createbaseIcisStatusResult(submittingParty, response, submissionType);
                    SubmissionErrorDataType submissionError = submissionErrors.getSubmissionError().get(l);
                    if(submissionError != null && submissionError.getSubmissionErrorKey() != null
                                    && submissionError.getSubmissionErrorKey().getPermitRecordIdentifier() != null
                                    && submissionError.getErrorReport() != null && submissionError.getErrorReport().get(0) != null)
                    {
                        result.setPermitIdentifier(submissionError.getSubmissionErrorKey().getPermitRecordIdentifier()
                                        .getPermitIdentifier());
                        result.setSubmissionTransactionTypeCode(submissionError.getSubmissionErrorKey().getSubmissionTransactionTypeCode()
                                        .value());
                        // I'm making a big assumption that in practice, despite the XSD definition, there is always
                        // just one of these,
                        // no response file samples currently have more than one.
                        result.setErrorCode(submissionError.getErrorReport().get(0).getErrorCode());
                        result.setErrorTypeCode(submissionError.getErrorReport().get(0).getErrorTypeCode().value());
                        result.setErrorDescription(submissionError.getErrorReport().get(0).getErrorDescription());
                    }
                    results.add(result);
                }
            }
        }
        return results;
    }

    /**
     * Creates a base IcisStatusResult regardless of whether the XML being parsed is Accepted or Rejected (i.e. has
     * SubmissionErrors or SubmissionsAccepted)
     * @param submittingParty
     * @param response
     * @param submissionType
     * @return
     */
    private IcisStatusResult createbaseIcisStatusResult(SubmittingPartyDataType submittingParty, SubmissionResponseDataType response,
                    SubmissionTypeDataType submissionType)
    {
        IcisStatusResult result = new IcisStatusResult();

        // Set SubmissionResponse simple types
        result.setTrasnactionIdentifier(response.getTransactionIdentifier());
        result.setSubmissionDate(response.getSubmissionDate());
        result.setProcessedDate(response.getProcessedDate());

        // Set SubmittingParty simple types
        result.setSubmittingPartyUserId(submittingParty.getUserID());

        // Set SubmissionTypeDataType simple types
        result.setSubmissionTypeName(submissionType.getSubmissionTypeName());
        return result;
    }

}
