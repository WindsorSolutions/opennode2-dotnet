package com.windsor.node.plugin.icisnpdes.results.xml;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.transform.Source;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerException;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.stream.StreamResult;
import javax.xml.transform.stream.StreamSource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.windsor.node.common.domain.ActivityEntry;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes.generated.SubmissionResultList;

/**
 * Parses the ICIS processing results XML document to {@link SubmissionResultList}.
 *
 */
public class IcisProcessingResultsXmlParser implements ResultsParser {

    /**
     * Path to the XSLT file to transform the processing results from ICIS.
     */
    private static final String RELATIVE_RESULTS_XSLT_PATH = "xsd" + File.separator + "MappingMapToSubmissionResults.xslt";

    protected Logger logger = LoggerFactory.getLogger(IcisProcessingResultsXmlParser.class);

    private final JAXBContext jaxbContext;

    public IcisProcessingResultsXmlParser() throws JAXBException {

        /**
         * JAXBContext is thread safe, however Marshallers, UnMarshallers, and Validators are not.
         */
        jaxbContext = JAXBContext.newInstance("com.windsor.node.plugin.icisnpdes.generated",
                IcisProcessingResultsXmlParser.class.getClassLoader());

    }
    /**
     * {@inheritDoc}
     */
    @Override
    public SubmissionResultList parse(ProcessContentResult result, byte[] fileBytes, BaseWnosJaxbPlugin caller) throws JAXBException {

        try {

            File xsltFile = getXsltFile(caller);

            File transformedResultsFile = transform(result, fileBytes, xsltFile);

            SubmissionResultList returnResults = null;

            if (transformedResultsFile != null) {

                returnResults = unmarshall(transformedResultsFile);

                if (transformedResultsFile.exists()) {
                    transformedResultsFile.delete();
                }
            }

            return returnResults;

        } catch(Exception e) {
            logger.debug("Caught Exception:", e);
            throw new WinNodeException(e.getLocalizedMessage(), e);
        }
    }

    /**
     * Transform the XML results from ICIS to another form of XML that has a
     * more of flat data structure.
     *
     * @param icisProcessingResultsXmlAsBytes
     *            The ICIS processing results XML.
     * @param xsltFile
     *            The XSLT file to transform the ICIS processing results XML.
     * @return A new file of the results of the transformation.
     * @throws IOException
     * @throws TransformerException
     */
    private File transform(ProcessContentResult result, byte [] icisProcessingResultsXmlAsBytes, File xsltFile) throws IOException, TransformerException {

        /**
         * Doing it this way implicitly sets the systemId
         */
        result.getAuditEntries().add(new ActivityEntry("Xslt transformation source files verified."));

        Source xsltSource = new StreamSource(xsltFile);

        /**
         * Create an InputStream of the bytes.
         */
        ByteArrayInputStream icisProcessingResultsXmlAsStream = new ByteArrayInputStream(icisProcessingResultsXmlAsBytes);

        Source xmlSource = new StreamSource(icisProcessingResultsXmlAsStream);

        result.getAuditEntries().add(new ActivityEntry("Transforming xml document using the xslt source files."));

        /**
         * The factory pattern supports different XSLT processors
         */
        TransformerFactory transformerFactory = TransformerFactory.newInstance(
                "org.apache.xalan.processor.TransformerFactoryImpl",
                IcisProcessingResultsXmlParser.class.getClassLoader());

        Transformer transformer = transformerFactory.newTransformer(xsltSource);

        /**
         * Create a file to transform the file to.
         */
        File transformedResultsFile = File.createTempFile("icis_processing_results_", ".xml");

        /**
         * Execute the transformation.
         */
        transformer.transform(xmlSource, new StreamResult(transformedResultsFile));

        result.getAuditEntries().add(new ActivityEntry("Successfully transformed the xml document using the xslt source files."));

        return transformedResultsFile;
    }

    /**
     * Unmarshall the ICIS processing results File to
     * {@link SubmissionResultList} object. May return null.
     *
     * @param transformedResultsFile
     * @return
     * @throws JAXBException
     * @throws FileNotFoundException
     */
    private SubmissionResultList unmarshall(File transformedResultsFile) throws JAXBException, FileNotFoundException {

        FileInputStream transformedIn = new FileInputStream(transformedResultsFile);

        Unmarshaller u = jaxbContext.createUnmarshaller();

        Object o = u.unmarshal(transformedIn);

        if (o != null) {
            return (SubmissionResultList)o;
        } else {
            return null;
        }
    }

    /**
     * Returns the XSLT file used to transform the ICIS processing results XML.
     *
     * @param caller
     * @return
     * @throws FileNotFoundException
     */
    private File getXsltFile(BaseWnosJaxbPlugin caller) throws FileNotFoundException {

        String xsltFilePath = caller.getPluginSourceDir().getAbsolutePath()
                + File.separator + RELATIVE_RESULTS_XSLT_PATH;

        return new File(xsltFilePath);
    }
}
