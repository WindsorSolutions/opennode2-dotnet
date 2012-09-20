package com.windsor.node.plugin.icisnpdes40.results.xml;

import javax.xml.bind.JAXBException;

import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes40.generated.SubmissionResultList;

public interface ResultsParser
{

    public SubmissionResultList parse(byte[] fileBytes, BaseWnosJaxbPlugin caller) throws JAXBException;

}