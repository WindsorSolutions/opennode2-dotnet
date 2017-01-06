package com.windsor.node.plugin.rcra54.service;

import javax.xml.bind.JAXBElement;

import com.windsor.node.plugin.rcra54.domain.GeographicInformationSubmissionDataType;
import com.windsor.node.plugin.rcra54.domain.ObjectFactory;
import com.windsor.node.plugin.rcra54.domain.OperationType;

public class RCRAGisExtractAndSubmission extends AbstractRcraSubmitService<GeographicInformationSubmissionDataType> {

	public RCRAGisExtractAndSubmission() {
		super(OperationType.GIS);
	}

	@Override
	protected GeographicInformationSubmissionDataType getPayloadRootEntity() {
		return getRcraDao().getGisRoot();
	}

	@Override
	protected JAXBElement<GeographicInformationSubmissionDataType> getPayloadRootElement(ObjectFactory objectFactory,
			GeographicInformationSubmissionDataType rootEntity) {
		return objectFactory.createGeographicInformationSubmission(rootEntity);
	}

}
