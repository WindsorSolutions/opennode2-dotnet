package com.windsor.node.plugin.icisnpdes40.results.xml;

import java.util.List;
import javax.xml.bind.JAXBException;
import com.windsor.node.plugin.icisnpdes40.results.IcisStatusResult;

public interface ResultsParser
{

    public List<IcisStatusResult> parse(byte[] fileBytes) throws JAXBException;

}