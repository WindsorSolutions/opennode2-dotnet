package com.windsor.node.plugin.icisnpdes.results.xml;

import javax.xml.bind.JAXBException;

import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;
import com.windsor.node.plugin.icisnpdes.generated.SubmissionResultList;

public interface ResultsParser
{

    public SubmissionResultList parse(ProcessContentResult result, byte[] fileBytes, BaseWnosJaxbPlugin caller) throws JAXBException;

}