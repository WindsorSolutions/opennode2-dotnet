/*
Copyright (c) 2016, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/

/* Oracle

 This script updates an existing RCRA v5.4 staging database to v5.6.
 Created: 1/23/2018
 Last Updated: 2/6/2018

*/

ALTER TABLE RCRA_HD_OWNEROP MODIFY NOTES VARCHAR2(4000);
ALTER TABLE RCRA_HD_OWNEROP MODIFY STREET1 VARCHAR2(50);
ALTER TABLE RCRA_HD_OWNEROP MODIFY STREET2 VARCHAR2(50);

ALTER TABLE RCRA_HD_HANDLER ADD RECYCLER_NOTES VARCHAR2(4000) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.RECYCLER_NOTES IS 'Notes for recycling hazardous waste. (RecyclerNotes)';

ALTER TABLE RCRA_HD_HANDLER ADD RECOGNIZED_TRADER_IMPORTER_IND CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.RECOGNIZED_TRADER_IMPORTER_IND IS 'Indicates that the Handler is participating in Import Trading activity. (RecognizedTraderImporterIndicator)';

ALTER TABLE RCRA_HD_HANDLER ADD RECOGNIZED_TRADER_EXPORTER_IND CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.RECOGNIZED_TRADER_EXPORTER_IND IS 'Indicates that the Handler is participating in Export Trading activity. (RecognizedTraderExporterIndicator)';

ALTER TABLE RCRA_HD_HANDLER ADD SLAB_IMPORTER_IND CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.SLAB_IMPORTER_IND IS 'Indicates that the Handler is participating in Slab Import activity. (SlabImporterIndicator)';

ALTER TABLE RCRA_HD_HANDLER ADD SLAB_EXPORTER_IND CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.SLAB_EXPORTER_IND IS 'Indicates that the Handler is participating in Slab Export activity. (SlabExporterIndicator)';

ALTER TABLE RCRA_HD_HANDLER ADD RECYCLER_ACT_NONSTORAGE CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.RECYCLER_ACT_NONSTORAGE IS 'Identifies that Handler participates in Nonstorage Recycler Activity. (RecyclerActivityNonstorage)';

ALTER TABLE RCRA_HD_HANDLER ADD MANIFEST_BROKER CHAR(1) NULL;

COMMENT ON COLUMN RCRA_HD_HANDLER.MANIFEST_BROKER IS 'Identifies that Handler is ManifestBroker. (ManifestBroker)';

ALTER TABLE RCRA_CME_EVAL ADD NOC_DATE DATE NULL;

COMMENT ON COLUMN RCRA_CME_EVAL.NOC_DATE IS 'NOC Date. (NOCDate)';

ALTER TABLE RCRA_CME_ENFRC_ACT ADD FA_REQUIRED CHAR(1) NULL;

COMMENT ON COLUMN RCRA_CME_ENFRC_ACT.FA_REQUIRED IS 'Whether financial responsibility is required. (FinancialAssuranceReqD)';

/****** Object:  Table RCRA_HD_LQG_CLOSURE    Script Date: 11/3/2017 4:03:18 PM ******/

CREATE TABLE RCRA_HD_LQG_CLOSURE(
	HD_LQG_CLOSURE_ID varchar2(40) NOT NULL,
	HD_HANDLER_ID varchar2(40) NOT NULL,
	TRANSACTION_CODE char(1) NULL,
	CLOSURE_TYPE char(1) NULL,
	EXPECTED_CLOSURE_DATE DATE NULL,
	NEW_CLOSURE_DATE DATE NULL,
	DATE_CLOSED DATE NULL,
	IN_COMPLIANCE_IND char(1) NULL,
	CONSTRAINT PK_HD_LQG_CLOSURE PRIMARY KEY
		(
			HD_LQG_CLOSURE_ID
		)
);

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.HD_LQG_CLOSURE_ID IS 'Parent: LQG closure info for a Handler';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.CLOSURE_TYPE IS 'Type of the closure. (ClosureType)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.EXPECTED_CLOSURE_DATE IS 'Date of expected closure. (ExpectedClosureDate)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.NEW_CLOSURE_DATE IS 'New closure date. (NewClosureDate)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.DATE_CLOSED IS 'Date of closed. (DateClosed)';

COMMENT ON COLUMN RCRA_HD_LQG_CLOSURE.IN_COMPLIANCE_IND IS 'Type of in compliance. (InComplianceIndicator)';

/****** Object:  Table RCRA_HD_LQG_CONSOLIDATION    Script Date: 11/3/2017 4:03:59 PM ******/

CREATE TABLE RCRA_HD_LQG_CONSOLIDATION(
	HD_LQG_CONSOLIDATION_ID varchar2(40) NOT NULL,
	HD_HANDLER_ID varchar2(40) NOT NULL,
	TRANSACTION_CODE char(1) NULL,
	SEQ_NUMBER int NOT NULL,
	HANDLER_ID varchar2(12) NOT NULL,
	HANDLER_NAME varchar2(80) NULL,
	MAIL_STREET_NUMBER varchar2(12) NULL,
	MAIL_STREET1 varchar2(50) NULL,
	MAIL_STREET2 varchar2(50) NULL,
	MAIL_CITY varchar2(25) NULL,
	MAIL_STATE char(2) NULL,
	MAIL_COUNTRY char(2) NULL,
	MAIL_ZIP varchar2(14) NULL,
	CONTACT_FIRST_NAME varchar2(38) NULL,
	CONTACT_MIDDLE_INITIAL char(1) NULL,
	CONTACT_LAST_NAME varchar2(38) NULL,
	CONTACT_ORG_NAME varchar2(80) NULL,
	CONTACT_TITLE varchar2(80) NULL,
	CONTACT_EMAIL_ADDRESS varchar2(80) NULL,
	CONTACT_PHONE varchar2(15) NULL,
	CONTACT_PHONE_EXT varchar2(6) NULL,
	CONTACT_FAX varchar2(15) NULL,
	CONSTRAINT PK_HD_LQG_CONSOLIDATION PRIMARY KEY
		(
			HD_LQG_CONSOLIDATION_ID
		)
);

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HD_LQG_CONSOLIDATION_ID IS 'Parent: LQG consolidation info for a Handler';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.SEQ_NUMBER IS 'Unique number that identifies the Consolidation. (ConsolidationSequenceNumber)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerID)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.HANDLER_NAME IS 'Name of the Handler (HandlerName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET_NUMBER IS 'Parent: Mailing address information. (MailingAddressNumberText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET1 IS 'Parent: Mailing address information. (MailingAddressText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET2 IS 'Parent: Mailing address information. (SupplementalAddressText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_CITY IS 'Parent: Mailing address information. (MailingAddressCityName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_STATE IS 'Parent: Mailing address information. (MailingAddressStateUSPSCode)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_COUNTRY IS 'Parent: Mailing address information. (MailingAddressCountryName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.MAIL_ZIP IS 'Parent: Mailing address information. (MailingAddressZIPCode)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_FIRST_NAME IS 'Parent: First name of the contact. (FirstName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_MIDDLE_INITIAL IS 'Parent: Middle initial of the contact. (MiddleInitial)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_LAST_NAME IS 'Parent: Last name of the contact. (LastName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_ORG_NAME IS 'Parent: Name of the contact organization. (OrganizationFormalName)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_TITLE IS 'Title of the contact person (IndividualTitleText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_EMAIL_ADDRESS IS 'Email address data (EmailAddressText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE IS 'Telephone Number data (TelephoneNumberText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE_EXT IS 'Telephone number extension (PhoneExtensionText)';

COMMENT ON COLUMN RCRA_HD_LQG_CONSOLIDATION.CONTACT_FAX IS 'Contact fax number (FaxNumberText)';

/****** Object:  Table RCRA_HD_EPISODIC_EVENT    Script Date: 11/3/2017 3:54:39 PM ******/

CREATE TABLE RCRA_HD_EPISODIC_EVENT(
	HD_EPISODIC_EVENT_ID varchar2(40) NOT NULL,
	HD_HANDLER_ID varchar2(40) NOT NULL,
	TRANSACTION_CODE char(1) NULL,
	EVENT_OWNER char(2) NULL,
	EVENT_TYPE varchar2(3) NULL,
	EVENT_OTHER_DESC varchar2(80) NULL,
	CONTACT_FIRST_NAME varchar2(38) NULL,
	CONTACT_MIDDLE_INITIAL char(1) NULL,
	CONTACT_LAST_NAME varchar2(38) NULL,
	CONTACT_ORG_NAME varchar2(80) NULL,
	CONTACT_TITLE varchar2(80) NULL,
	CONTACT_EMAIL_ADDRESS varchar2(80) NULL,
	CONTACT_PHONE varchar2(15) NULL,
	CONTACT_PHONE_EXT varchar2(6) NULL,
	CONTACT_FAX varchar2(15) NULL,
	START_DATE DATE NULL,
	END_DATE DATE NULL,
	CONSTRAINT PK_HD_EPISODIC_EVENT PRIMARY KEY
		(
			HD_EPISODIC_EVENT_ID
		)
);

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.HD_EPISODIC_EVENT_ID IS 'Parent: Episodic event info for a Handler';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.HD_HANDLER_ID IS 'Parent: Handler data (_FK)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_OWNER IS 'Owner of the episodic event. (EpisodicEventOwner)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_TYPE IS 'Type of the episodic event. (EpisodicEventType)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.EVENT_OTHER_DESC IS 'Other description of the episodic event. (EpisodicEventOtherDescription)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_FIRST_NAME IS 'First name of the contact. (FirstName)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_MIDDLE_INITIAL IS 'Middle initial of the contact. (MiddleInitial)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_LAST_NAME IS 'Last name of the contact. (LastName)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_ORG_NAME IS 'Contact organization name. (OrganizationFormalName)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_TITLE IS 'Title of the contact. (IndividualTitleText)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_EMAIL_ADDRESS IS 'Email address of the contact. (EmailAddressText)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE IS 'Telephone number of the contact. (TelephoneNumberText)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE_EXT IS 'Phone extension of the contact. (PhoneExtensionText)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.CONTACT_FAX IS 'Fax number of the contact. (FaxNumberText)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.START_DATE IS 'Episodic event start event. (EpisodicEventStartDate)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_EVENT.END_DATE IS 'Episodic event end event. (EpisodicEventEndDate)';

/****** Object:  Table RCRA_HD_EPISODIC_WASTE    Script Date: 11/3/2017 3:57:52 PM ******/

CREATE TABLE RCRA_HD_EPISODIC_WASTE(
	HD_EPISODIC_WASTE_ID varchar2(40) NOT NULL,
	HD_EPISODIC_EVENT_ID varchar2(40) NOT NULL,
	TRANSACTION_CODE char(1) NULL,
	SEQ_NUMBER int NULL,
	WASTE_DESC varchar2(4000) NULL,
	EST_QNTY int NULL,
	CONSTRAINT PK_HD_EPISODIC_WASTE PRIMARY KEY
		(
			HD_EPISODIC_WASTE_ID
		)
);

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_WASTE_ID IS 'Parent: Episodic waste info for a Handler Episodic Event';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_EVENT_ID IS 'Parent: Episode event data (_FK)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.SEQ_NUMBER IS 'Unique number that identifies the episodic waste. (EpisodicWasteSequenceNumber)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.WASTE_DESC IS 'Waste description. (WasteDescription)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE.EST_QNTY IS 'The quantity of waste that is handled by each process code. This element pertains only to Part A submissions. (EstimatedQuantity)';

/****** Object:  Table RCRA_HD_EPISODIC_WASTE_CODE    Script Date: 11/3/2017 3:59:31 PM ******/

CREATE TABLE RCRA_HD_EPISODIC_WASTE_CODE(
	HD_EPISODIC_WASTE_CODE_ID varchar2(40) NOT NULL,
	HD_EPISODIC_WASTE_ID varchar2(40) NOT NULL,
	TRANSACTION_CODE char(1) NULL,
	WASTE_CODE_OWNER char(2) NULL,
	WASTE_CODE varchar2(6) NULL,
	WASTE_CODE_TEXT varchar2(80) NULL,
	CONSTRAINT PK_HD_EPISODIC_WASTE_CODE PRIMARY KEY
		(
			HD_EPISODIC_WASTE_CODE_ID
		)
);

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_CODE_ID IS 'Parent: Episodic waste code details for Handler Episodic Waste';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_ID IS 'Parent: Episodic waste data (_FK)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.TRANSACTION_CODE IS 'Transaction code used to define the add, update, or delete. (TransactionCode)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_OWNER IS 'Owner and definer of the waste code. (WasteCodeOwnerName)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE IS 'Code used to describe hazardous waste. (WasteCode)';

COMMENT ON COLUMN RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_TEXT IS 'Descriptive text describing the Waste Code (Data publishing only). (WasteCodeText)';

/****** Object:  Table RCRA_RU_SUBM    Script Date: 11/3/2017 4:00:19 PM ******/

CREATE TABLE RCRA_RU_SUBM(
	RU_SUBM_ID varchar2(40) NOT NULL,
	DATA_ACCESS varchar2(10),
	CONSTRAINT PK_RU_SUBM PRIMARY KEY
		(
			RU_SUBM_ID
		)
);

COMMENT ON COLUMN RCRA_RU_SUBM.RU_SUBM_ID IS 'Parent: Universal waste report submission';

/****** Object:  Table RCRA_RU_REPORT_UNIV_SUBM    Script Date: 11/3/2017 4:00:19 PM ******/

CREATE TABLE RCRA_RU_REPORT_UNIV_SUBM(
	RU_REPORT_UNIV_SUBM_ID varchar2(40) NOT NULL,
	RU_SUBM_ID varchar2(40) NOT NULL,
	CONSTRAINT PK_RU_REPORT_UNIV_SUBM PRIMARY KEY
		(
			RU_REPORT_UNIV_SUBM_ID
		)
);

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV_SUBM.RU_REPORT_UNIV_SUBM_ID IS 'Parent: Universal waste report submission. (_PK)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV_SUBM.RU_SUBM_ID IS 'Parent: Universal waste report submission. (_FK)';

/****** Object:  Table RCRA_RU_REPORT_UNIV    Script Date: 11/3/2017 4:00:11 PM ******/

CREATE TABLE RCRA_RU_REPORT_UNIV(
	RU_REPORT_UNIV_ID varchar2(40) NOT NULL,
	RU_REPORT_UNIV_SUBM_ID varchar2(40) NOT NULL,
	HANDLER_ID varchar2(12) NOT NULL,
	ACTIVITY_LOCATION char(2) NOT NULL,
	SOURCE_TYPE char(1) NULL,
	SEQ_NUMBER int NULL,
	RECEIVE_DATE DATE NULL,
	HANDLER_NAME varchar2(80) NULL,
	NON_NOTIFIER_IND char(1) NULL,
	ACCESSIBILITY char(1) NULL,
	REPORT_CYCLE int NULL,
	REGION char(2) NULL,
	STATE char(2) NULL,
	EXTRACT_FLAG char(1) NULL,
	ACTIVE_SITE varchar2(5) NULL,
	COUNTY_CODE varchar2(5) NULL,
	COUNTY_NAME varchar2(80) NULL,
	LOCATION_STREET_NUMBER varchar2(12) NULL,
	LOCATION_STREET1 varchar2(50) NULL,
	LOCATION_STREET2 varchar2(50) NULL,
	LOCATION_CITY varchar2(25) NULL,
	LOCATION_STATE char(2) NULL,
	LOCATION_COUNTRY char(2) NULL,
	LOCATION_ZIP char(14) NULL,
	MAIL_STREET_NUMBER varchar2(12) NULL,
	MAIL_STREET1 varchar2(50) NULL,
	MAIL_STREET2 varchar2(50) NULL,
	MAIL_CITY varchar2(25) NULL,
	MAIL_STATE char(2) NULL,
	MAIL_COUNTRY char(2) NULL,
	MAIL_ZIP varchar2(14) NULL,
	CONTACT_STREET_NUMBER varchar2(12) NULL,
	CONTACT_STREET1 varchar2(50) NULL,
	CONTACT_STREET2 varchar2(50) NULL,
	CONTACT_CITY varchar2(25) NULL,
	CONTACT_STATE char(2) NULL,
	CONTACT_COUNTRY char(2) NULL,
	CONTACT_ZIP varchar2(14) NULL,
	CONTACT_NAME varchar2(80) NULL,
	CONTACT_PHONE varchar2(22) NULL,
	CONTACT_FAX varchar2(15) NULL,
	CONTACT_EMAIL varchar2(80) NULL,
	CONTACT_TITLE varchar2(45) NULL,
	OWNER_NAME varchar2(80) NULL,
	OWNER_TYPE char(1) NULL,
	OWNER_SEQ_NUM int NULL,
	OPER_NAME varchar2(80) NULL,
	OPER_TYPE char(1) NULL,
	OPER_SEQ_NUM int NULL,
	NAIC1_CODE varchar2(6) NULL,
	NAIC2_CODE varchar2(6) NULL,
	NAIC3_CODE varchar2(6) NULL,
	NAIC4_CODE varchar2(6) NULL,
	IN_HANDLER_UNIVERSE char(1) NULL,
	IN_A_UNIVERSE char(1) NULL,
	FED_WASTE_GENERATOR_OWNER char(2) NULL,
	FED_WASTE_GENERATOR char(1) NULL,
	STATE_WASTE_GENERATOR_OWNER char(2) NULL,
	STATE_WASTE_GENERATOR char(1) NULL,
	GEN_STATUS varchar2(3) NULL,
	UNIV_WASTE char(1) NULL,
	LAND_TYPE char(1) NULL,
	STATE_DISTRICT_OWNER char(2) NULL,
	STATE_DISTRICT varchar2(10) NULL,
	SHORT_TERM_GEN_IND char(1) NULL,
	IMPORTER_ACTIVITY char(1) NULL,
	MIXED_WASTE_GENERATOR char(1) NULL,
	TRANSPORTER_ACTIVITY char(1) NULL,
	TRANSFER_FACILITY_IND char(1) NULL,
	RECYCLER_ACTIVITY char(1) NULL,
	ONSITE_BURNER_EXEMPTION char(1) NULL,
	FURNACE_EXEMPTION char(1) NULL,
	UNDERGROUND_INJECTION_ACTIVITY char(1) NULL,
	UNIVERSAL_WASTE_DEST_FACILITY char(1) NULL,
	OFFSITE_WASTE_RECEIPT char(1) NULL,
	USED_OIL varchar(7) NULL,
	FEDERAL_UNIVERSAL_WASTE char(1) NULL,
	AS_FEDERAL_REGULATED_TSDF varchar2(6) NULL,
	AS_CONVERTED_TSDF varchar2(6) NULL,
	AS_STATE_REGULATED_TSDF varchar2(9) NULL,
	FEDERAL_IND varchar2(3) NULL,
	HSM char(2) NULL,
	SUBPART_K varchar2(4) NULL,
	COMMERCIAL_TSD char(1) NULL,
	TSD varchar2(5) NULL,
	GPRA_PERMIT char(1) NULL,
	GPRA_RENEWAL char(1) NULL,
	PERMIT_RENEWAL_WRKLD varchar2(6) NULL,
	PERM_WRKLD varchar2(6) NULL,
	PERM_PROG varchar2(6) NULL,
	PC_WRKLD varchar2(6) NULL,
	CLOS_WRKLD varchar2(6) NULL,
	GPRACA char(1) NULL,
	CA_WRKLD char(1) NULL,
	SUBJ_CA char(1) NULL,
	SUBJ_CA_NON_TSD char(1) NULL,
	SUBJ_CA_TSD_3004 char(1) NULL,
	SUBJ_CA_DISCRETION char(1) NULL,
	NCAPS char(1) NULL,
	EC_IND char(1) NULL,
	IC_IND char(1) NULL,
	CA_725_IND char(1) NULL,
	CA_750_IND char(1) NULL,
	OPERATING_TSDF varchar2(6) NULL,
	FULL_ENFORCEMENT varchar2(6) NULL,
	SNC char(1) NULL,
	BOY_SNC char(1) NULL,
	BOY_STATE_UNADDRESSED_SNC char(1) NULL,
	STATE_UNADDRESSED char(1) NULL,
	STATE_ADDRESSED char(1) NULL,
	BOY_STATE_ADDRESSED char(1) NULL,
	STATE_SNC_WITH_COMP_SCHED char(1) NULL,
	BOY_STATE_SNC_WITH_COMP_SCHED char(1) NULL,
	EPA_UNADDRESSED char(1) NULL,
	BOY_EPA_UNADDRESSED char(1) NULL,
	EPA_ADDRESSED char(1) NULL,
	BOY_EPA_ADDRESSED char(1) NULL,
	EPA_SNC_WITH_COMP_SCHED char(1) NULL,
	BOY_EPA_SNC_WITH_COMP_SCHED char(1) NULL,
	FA_REQUIRED varchar(5) NULL,
	HHANDLER_LAST_CHANGE_DATE DATE NULL,
	PUBLIC_NOTES varchar2(4000) NULL,
	NOTES varchar2(4000) NULL,
	RECOGNIZED_TRADER_IMPORTER_IND char(1) NULL,
	RECOGNIZED_TRADER_EXPORTER_IND char(1) NULL,
	SLAB_IMPORTER_IND char(1) NULL,
	SLAB_EXPORTER_IND char(1) NULL,
	RECYCLER_NON_STORAGE_IND char(1) NULL,
	MANIFEST_BROKER_IND char(1) NULL,
	CONSTRAINT PK_RU_REPORT_UNIV PRIMARY KEY
		(
			RU_REPORT_UNIV_ID
		)
);

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RU_REPORT_UNIV_ID IS 'Parent: Universal waste report details';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RU_REPORT_UNIV_SUBM_ID IS 'Parent: Universal waste report submission. (_FK)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HANDLER_ID IS 'Code that uniquely identifies the handler. (HandlerIdCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACTIVITY_LOCATION IS 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SOURCE_TYPE IS 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SEQ_NUMBER IS 'Sequence number for each source record about a handler. (SequenceNumber)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECEIVE_DATE IS 'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HANDLER_NAME IS 'Name of the Handler (HandlerName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NON_NOTIFIER_IND IS 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACCESSIBILITY IS 'Reason why the handler is not accessible for normal processing (Bankrupt Indicator). (Accessibility)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.REPORT_CYCLE IS 'Report cycle. (ReportCycle)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.REGION IS 'Region (Region)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE IS 'State (State)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EXTRACT_FLAG IS 'Extract flag (ExtractFlag)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ACTIVE_SITE IS 'Active site (ActiveSite)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COUNTY_CODE IS 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COUNTY_NAME IS 'Descriptive text describing the County Name(Data publishing only). (CountyName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET_NUMBER IS 'Number portion of the location street address of the handler. (LocationAddressNumberText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET1 IS 'Street address of the handler. (LocationAddressText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STREET2 IS 'Supplemental address of the handler. (SupplementalLocationText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_CITY IS 'City in which the handler is located. (LocalityName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_STATE IS 'State in which the handler is located. (StateUSPSCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_COUNTRY IS 'Country in which the handler is located. (CountryName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LOCATION_ZIP IS 'ZIP code in which the handler is located. (LocationZIPCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET_NUMBER IS 'Number portion of the mailing address of the handler. (MailingAddressNumberText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET1 IS 'Street address of the handler mailing address. (MailingAddressText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STREET2 IS 'Supplemental address of the handler mailing address. (SupplementalLocationText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_CITY IS 'City of the handler mailing address. (MailingAddressCityName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_STATE IS 'State of the handler mailing address. (MailingAddressStateUSPSCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_COUNTRY IS 'Country of the handler mailing address. (MailingAddressCountryName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MAIL_ZIP IS 'ZIP code of the handler mailing address. (MailingAddressZIPCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET_NUMBER IS 'Number portion of the mailing address of the handler contact. (MailingAddressNumberText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET1 IS 'Street address of the handler contact mailing address. (MailingAddressText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STREET2 IS 'Supplemental address of the handler contact mailing address. (SupplementalLocationText)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_CITY IS 'City of the handler contact mailing address. (MailingAddressCityName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_STATE IS 'State of the handler contact mailing address. (MailingAddressStateUSPSCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_COUNTRY IS 'Country of the handler contact mailing address. (MailingAddressCountryName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_ZIP IS 'ZIP code of the handler contact mailing address. (MailingAddressZIPCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_NAME IS 'Handler contact name (first + last). (ContactNameCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_PHONE IS 'Handler contact phone number. (ContactPhoneCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_FAX IS 'Handler contact fax number. (ContactFaxCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_EMAIL IS 'Handler contact email address. (ContactEmailCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CONTACT_TITLE IS 'Handler contact title. (ContactTitleCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_NAME IS 'Handler owner name. (OwnerNameCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_TYPE IS 'Handler owner type. (OwnerTypeCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OWNER_SEQ_NUM IS 'Handler owner sequence number. (OwnerSeqCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_NAME IS 'Handler operator name. (OperatorNameCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_TYPE IS 'Handler operator type. (OperatorTypeCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPER_SEQ_NUM IS 'Handler operator sequence number. (OperatorSeqCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC1_CODE IS 'NAIC 1 code (NAIC1Code)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC2_CODE IS 'NAIC 2 code (NAIC2Code)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC3_CODE IS 'NAIC 3 code (NAIC3Code)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NAIC4_CODE IS 'NAIC 4 code (NAIC4Code)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IN_HANDLER_UNIVERSE IS 'In handler universe (InHandlerUniverseCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IN_A_UNIVERSE IS 'In a universe (InAUniverseCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR_OWNER IS 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorOwner)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR IS 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR_OWNER IS 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorOwner)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR IS 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GEN_STATUS IS 'Gen status (GENSTATUS)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNIV_WASTE IS 'Univ waste (UNIVWASTE)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.LAND_TYPE IS 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_DISTRICT_OWNER IS 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_DISTRICT IS 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SHORT_TERM_GEN_IND IS 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IMPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MIXED_WASTE_GENERATOR IS 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TRANSPORTER_ACTIVITY IS 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TRANSFER_FACILITY_IND IS 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECYCLER_ACTIVITY IS 'Code for recycling hazardous waste. (RecyclerActivityCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.ONSITE_BURNER_EXEMPTION IS 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FURNACE_EXEMPTION IS 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNDERGROUND_INJECTION_ACTIVITY IS 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.UNIVERSAL_WASTE_DEST_FACILITY IS 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OFFSITE_WASTE_RECEIPT IS 'Off site waste receipt (OffSiteWasteReceiptCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.USED_OIL IS 'Used oil code (UsedOilCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FEDERAL_UNIVERSAL_WASTE IS 'Federal universal waste (FederalUniversalWasteCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_FEDERAL_REGULATED_TSDF IS 'As federal regulated TSDF (AsFederalRegulatedTSDFCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_CONVERTED_TSDF IS 'As converter TSDF (AsConverterTSDFCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.AS_STATE_REGULATED_TSDF IS 'As state regulated TSDF (AsStateRegulatedTSDFCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FEDERAL_IND IS 'Federal indicator (FederalIndicatorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HSM IS 'HSM code (HSMCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBPART_K IS 'Subpart K code (SubpartKCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.COMMERCIAL_TSD IS 'Commercial TSD code (CommercialTSDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.TSD IS 'TSD type (TSDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRA_PERMIT IS 'GPRA permit (GPRAPermitCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRA_RENEWAL IS 'GPRA renewal code (GPRARenewalCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERMIT_RENEWAL_WRKLD IS 'Permit renewal WRKLD (PermitRenewalWRKLDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERM_WRKLD IS 'Perm WRKLD (PermWRKLDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PERM_PROG IS 'Perm PROG (PermPROGCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PC_WRKLD IS 'PC WRKLD (PCWRKLDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CLOS_WRKLD IS 'Clos WRKLD (ClosWRKLDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.GPRACA IS 'GPRACA (GPRACACode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_WRKLD IS 'CAWRKLD (CAWRKLDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA IS 'Subj CA (SubjCACode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_NON_TSD IS 'Subj CA non TSD (SubjCANonTSDCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_TSD_3004 IS 'Subj CA TSD 3004 (SubjCATSD3004Code)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SUBJ_CA_DISCRETION IS 'Subj CA discretion (SubjCADiscretionCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NCAPS IS 'NCAPS (NCAPSCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EC_IND IS 'EC indicator (ECIndicatorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.IC_IND IS 'IC indicator (ICIndicatorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_725_IND IS 'CA 725 indicator (CA725IndicatorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.CA_750_IND IS 'CA 750 indicator (CA750IndicatorCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.OPERATING_TSDF IS 'Operating TSDF (OperatingTSDFCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FULL_ENFORCEMENT IS 'Full enforcement (FullEnforcementCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SNC IS 'SNC (SNCCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_SNC IS 'BOY SNC (BOYSNCCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_UNADDRESSED_SNC IS 'BOY state unaddressed SNC (BOYStateUnaddressedSNCCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_UNADDRESSED IS 'State unaddressed (StateUnaddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_ADDRESSED IS 'State addressed (StateAddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_ADDRESSED IS 'BOY state addressed (BOYStateAddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.STATE_SNC_WITH_COMP_SCHED IS 'State SNC with comp sched (StateSNCWithCompSchedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_STATE_SNC_WITH_COMP_SCHED IS 'BOY state SNC with comp sched (BOYStateSNCWithCompSchedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_UNADDRESSED IS 'EPA unaddressed (EPAUnaddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_UNADDRESSED IS 'BOY EPA unaddressed (BOYEPAUnaddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_ADDRESSED IS 'EPA addressed (EPAAddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_ADDRESSED IS 'BOY EPA addressed (BOYEPAAddressedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.EPA_SNC_WITH_COMP_SCHED IS 'EPA SNC with comp sched (EPASNCWithcompSchedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.BOY_EPA_SNC_WITH_COMP_SCHED IS 'BOY EPA SNC with comp sched (BOYEPASNCWithcompSchedCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.FA_REQUIRED IS 'FA required (FARequiredCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.HHANDLER_LAST_CHANGE_DATE IS 'HHandler last change date (HHandlerLastChangeDate)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.PUBLIC_NOTES IS 'Notes (PublicNotesCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.NOTES IS 'Notes (NotesCode)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_IMPORTER_IND IS 'Indicates that the Handler is participating in Import Trading activity. Possible values are: Y/N (RecognizedTraderImporterIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_EXPORTER_IND IS 'Indicates that the Handler is participating in Export Trading activity. Possible values are: Y/N (RecognizedTraderExporterIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SLAB_IMPORTER_IND IS 'Indicates that the Handler is participating in Slab Import activity. Possible values are: Y/N (SlabImporterIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.SLAB_EXPORTER_IND IS 'Indicates that the Handler is participating in Slab Export activity. Possible values are: Y/N (SlabExporterIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.RECYCLER_NON_STORAGE_IND IS 'Recycle non storage (RecyclerNonStorageIndicator)';

COMMENT ON COLUMN RCRA_RU_REPORT_UNIV.MANIFEST_BROKER_IND IS 'Manifest broker (ManifestBrokerIndicator)';

ALTER TABLE RCRA_HD_LQG_CONSOLIDATION  ADD  CONSTRAINT FK_HD_LQG_CONSOL_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_HD_LQG_CLOSURE  ADD  CONSTRAINT FK_HD_LQG_CLOS_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_HD_EPISODIC_EVENT  ADD  CONSTRAINT FK_HD_EPIS_EVT_HANDLER_ID FOREIGN KEY(HD_HANDLER_ID)
REFERENCES RCRA_HD_HANDLER (HD_HANDLER_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_HD_EPISODIC_WASTE  ADD  CONSTRAINT FK_HD_EPIS_WASTE_EVT_ID FOREIGN KEY(HD_EPISODIC_EVENT_ID)
REFERENCES RCRA_HD_EPISODIC_EVENT (HD_EPISODIC_EVENT_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_HD_EPISODIC_WASTE_CODE  ADD  CONSTRAINT FK_HD_EPIS_WASTE_CD_WASTE_ID FOREIGN KEY(HD_EPISODIC_WASTE_ID)
REFERENCES RCRA_HD_EPISODIC_WASTE (HD_EPISODIC_WASTE_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_RU_REPORT_UNIV_SUBM  ADD CONSTRAINT FK_RU_REPORT_UNIV_SUBM_PAR_ID FOREIGN KEY(RU_SUBM_ID)
REFERENCES RCRA_RU_SUBM (RU_SUBM_ID)
	ON DELETE CASCADE;

ALTER TABLE RCRA_RU_REPORT_UNIV ADD CONSTRAINT FK_RU_REPORT_UNIV_PARENT_ID FOREIGN KEY(RU_REPORT_UNIV_SUBM_ID)
REFERENCES RCRA_RU_REPORT_UNIV_SUBM (RU_REPORT_UNIV_SUBM_ID)
	ON DELETE CASCADE;
