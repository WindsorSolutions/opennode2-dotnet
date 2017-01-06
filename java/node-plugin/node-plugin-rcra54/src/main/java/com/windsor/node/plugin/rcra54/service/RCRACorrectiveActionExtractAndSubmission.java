package com.windsor.node.plugin.rcra54.service;

import javax.xml.bind.JAXBElement;

import com.windsor.node.plugin.rcra54.domain.HazardousWasteCorrectiveActionDataType;
import com.windsor.node.plugin.rcra54.domain.ObjectFactory;
import com.windsor.node.plugin.rcra54.domain.OperationType;

public class RCRACorrectiveActionExtractAndSubmission extends AbstractRcraSubmitService<HazardousWasteCorrectiveActionDataType> {

	public RCRACorrectiveActionExtractAndSubmission() {
		super(OperationType.CORRECTIVE_ACTION);
	}

	@Override
	protected HazardousWasteCorrectiveActionDataType getPayloadRootEntity() {
		return getRcraDao().getCorrectiveActionRoot();
	}

	@Override
	protected JAXBElement<HazardousWasteCorrectiveActionDataType> getPayloadRootElement(ObjectFactory objectFactory,
			HazardousWasteCorrectiveActionDataType rootEntity) {
		return objectFactory.createHazardousWasteCorrectiveActionSubmission(rootEntity);
	}

}
