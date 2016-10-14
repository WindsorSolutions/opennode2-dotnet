package com.windsor.node.plugin.aqs;

import org.datacontract.schemas._2004._07.airvision_common_services_webservices.AQSXmlResultData;

import java.io.File;
import java.io.IOException;

public abstract class AqsResultHandler {
    private String outputDirectory;

    public AqsResultHandler(String outputDirectory) {
        this.outputDirectory = outputDirectory;
    }

    public String getOutputDirectory() {
        return outputDirectory;
    }

    public abstract File handle(AQSXmlResultData paramAQSXmlResultData) throws IOException;
}
