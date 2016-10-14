package com.windsor.node.plugin.aqs;

import com.windsor.node.plugin.aqs.agilaire.AQSXmlResultData;

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
