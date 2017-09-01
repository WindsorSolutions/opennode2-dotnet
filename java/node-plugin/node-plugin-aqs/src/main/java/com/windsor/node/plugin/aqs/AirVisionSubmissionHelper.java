package com.windsor.node.plugin.aqs;

import com.windsor.node.common.domain.*;
import com.windsor.node.service.helper.CompressionService;
import com.windsor.node.service.helper.settings.SettingServiceProvider;
import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.io.IOUtils;

import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import javax.xml.datatype.XMLGregorianCalendar;
import java.io.*;
import java.sql.Timestamp;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.List;

/**
 * Provides helper functions used when formatting and submitting AirVision data
 * to a network partner.
 */
public class AirVisionSubmissionHelper {

    /**
     * Returns a GregorianCalendar instance initialized to date represented by the provided String.
     *
     * @param sqlDate String with valid SQL date
     * @return GregorianCalendar instance
     */
    public static GregorianCalendar parseSQLDate(String sqlDate) {
        Date date = null;

        if(sqlDate.length() > 10 && sqlDate.length()  < 17) {
            date = Timestamp.valueOf(sqlDate + ":00");
        } else if(sqlDate.length() > 16) {
            date = Timestamp.valueOf(sqlDate);
        } else {
            date = java.sql.Date.valueOf(sqlDate);
        }

        GregorianCalendar calendar = new GregorianCalendar();
        calendar.setTime(date);
        return calendar;
    }

    /**
     * Returns an XMLGregorianCalendar instance initialized to the date represented by the provided Java date.
     *
     * @param date Java Date
     * @return XMLGregorianCalendar instance
     * @throws DatatypeConfigurationException
     */
    public static  XMLGregorianCalendar convertToXmlGregorianCalendar(Date date) throws DatatypeConfigurationException {
        DatatypeFactory df = DatatypeFactory.newInstance();
        GregorianCalendar gc = new GregorianCalendar();
        gc.setTime(date);
        XMLGregorianCalendar cal = df.newXMLGregorianCalendar(gc);
        return cal;
    }

    public static String makeTemporaryFilename(SettingServiceProvider settingService, String docId) {
        return FilenameUtils.concat(settingService.getTempDir().getAbsolutePath(), "AQS_" +
                "AirVisionSubmissionService" + docId + "." + "xml");
    }

    public static List<String> removeXmlHeader(File exportFile) throws IOException {

        List<String> lines = null;
        FileInputStream in = new FileInputStream(exportFile);

        List<String> fileLines = IOUtils.readLines(in);

        if ((fileLines != null) && (fileLines.size() > 0)) {
            if (((String) fileLines.get(0)).startsWith("<?xml")) {
                fileLines.remove(0);
            }
        }
        lines = fileLines;

        return lines;
    }

    public static Document makeDocument(CompressionService compressionService, RequestType requestType, String documentId,
                                 String absolutefilePath)
            throws IOException {

        Document doc = new Document();
        doc.setDocumentId(documentId);
        doc.setId(documentId);

        if (!RequestType.Query.equals(requestType)) {

            String zippedFilePath = compressionService.zip(absolutefilePath);
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

    /**
     * makeEntry creates a new entry to the activity log and debug log
     *
     * @param message
     * @return
     */
    public static ActivityEntry makeEntry(String message) {
        return new ActivityEntry(message);
    }
}
