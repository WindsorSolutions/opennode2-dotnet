package com.windsor.node.plugin.aqs;

import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQSXmlResultData;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Date;
import java.util.GregorianCalendar;

public class AqsResultHandlerImpl extends AqsResultHandler {

    protected Logger logger = LoggerFactory.getLogger(AqsResultHandlerImpl.class);

    public AqsResultHandlerImpl(String outputDirectory) {
        super(outputDirectory);
    }

    public File handle(AQSXmlResultData results) throws IOException {
        File file = null;

        if ((results != null) && (results.getAQSXmlDocumentText() != null)
                && (results.getAQSXmlDocumentText().getValue() != null)) {

            file = createPathname();
            FileOutputStream out = new FileOutputStream(file);
            out.write(((String) results.getAQSXmlDocumentText().getValue()).getBytes());
            out.close();
        }
        return file;
    }

    private File createPathname() throws IOException {

        GregorianCalendar gc = new GregorianCalendar();
        gc.setTime(new Date());
        StringBuffer filename = new StringBuffer();

        filename.append("aqs").append("-").append(gc.get(1)).append("-").append(gc.get(2) + 1).append("-").append(gc.get(5));
        filename.append("-").append(gc.get(11)).append("-").append(gc.get(12)).append("-").append(gc.get(13));
        filename.append(".xml");

        File file = new File(getOutputDirectory() + File.separator + filename.toString());
        this.logger.info("Trying to create file at location:  " + file.getAbsolutePath());
        if (file.exists()) {
            file.delete();
        }

        return file;
    }
}