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

/* SQL Server

 This script updates an existing RCRA v5.2 staging database to v5.4.
 Created: 2/4/2016
 Last Updated: 12/8/2016
 
*/

--Added element: NonNotifierIndicatorText - this element is used for publishing
IF (SELECT COUNT(1) FROM sys.columns where name = 'NON_NOTIFIER_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD NON_NOTIFIER_TEXT VARCHAR(255) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing Notification source (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NON_NOTIFIER_TEXT';
END

--Added element: AccessibilityCodeText - this element is used for publishing
IF (SELECT COUNT(1) FROM sys.columns where name = 'ACCESSIBILITY_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD ACCESSIBILITY_TEXT VARCHAR(255) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing reason facility is not accessible (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'ACCESSIBILITY_TEXT';
END

--Added element: LocationAddressNumberText - this element is used for publishing
IF (SELECT COUNT(1) FROM sys.columns where name = 'LOCATION_STREET_NUMBER') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD LOCATION_STREET_NUMBER VARCHAR(12) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'LOCATION_STREET_NUMBER';
END

--Added element: MailingAddressNumberText - this is to sync up abilities between direct data entry and xml translation 
IF (SELECT COUNT(1) FROM sys.columns where name = 'MAIL_STREET_NUMBER') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD MAIL_STREET_NUMBER VARCHAR(12) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mailing Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'MAIL_STREET_NUMBER';
END

--Added 11/15/2016 BGR
IF (SELECT COUNT(1) FROM sys.columns where name = 'CONTACT_STREET_NUMBER') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD CONTACT_STREET_NUMBER VARCHAR(12) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'CONTACT_STREET_NUMBER';
END

--Added 11/15/2016 BGR
IF (SELECT COUNT(1) FROM sys.columns where name = 'PCONTACT_STREET_NUMBER') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD PCONTACT_STREET_NUMBER VARCHAR(12) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permit Contact Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'PCONTACT_STREET_NUMBER';
END

--Added element: StateDistrictCodeText - this element is used for publishing
IF (SELECT COUNT(1) FROM sys.columns where name = 'STATE_DISTRICT_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD STATE_DISTRICT_TEXT VARCHAR(255) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the code indicating the state-designated legislative district(s) in which the site is located (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'STATE_DISTRICT_TEXT';
END

--Added element: LandBasedUnitIndicatorText - this element is used for publishing
IF (SELECT COUNT(1) FROM sys.columns where name = 'LAND_BASED_UNIT_IND_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_SEC_MATERIAL_ACTIVITY
    ADD LAND_BASED_UNIT_IND_TEXT VARCHAR(255) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descriptive text describing the code to indicate if the HSM is being managed in a Land Based Unit (Data publishing only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_SEC_MATERIAL_ACTIVITY', @level2type=N'COLUMN',@level2name=N'LAND_BASED_UNIT_IND_TEXT';
END

--Increased length of field for OwnerOperatorSupplementalInformationText from 240 to 2000

ALTER TABLE RCRA_HD_OWNEROP
ALTER COLUMN NOTES VARCHAR(2000) NULL;


--Increased length of field EnvironmentalPermitDescription from 20 to 80

ALTER TABLE RCRA_HD_ENV_PERMIT
ALTER COLUMN ENV_PERMIT_DESC VARCHAR(80) NOT NULL;


--Added new element RecyclingIndicator in support of new DSW regulation
IF (SELECT COUNT(1) FROM sys.columns where name = 'RECYCLING_IND') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD RECYCLING_IND CHAR(1) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the facility has a recycling process which the product has levels of hazardous constituents that are not comparable to or unable to be compared to a legitimate product or intermediate but that the recycling is still legitimate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'RECYCLING_IND';
END

--Added 11/15/2016 BGR, from RCRA v5.3
IF (SELECT COUNT(1) FROM sys.columns where name = 'MAIL_ADDR_NUM_TXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_OWNEROP
    ADD MAIL_ADDR_NUM_TXT VARCHAR(12) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Owner/Operator Address Street Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_OWNEROP', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_NUM_TXT';
END

/* SQL Server
 This script updates an existing RCRA v5.3 staging database to v5.4
 Created 3/17/2016
*/

--RCRA_FacilityOwnerOperator_v5.4
--Increased length of element OwnerOperatorSupplementalInformationText to 4000

    ALTER TABLE RCRA_HD_OWNEROP
    ALTER COLUMN NOTES VARCHAR(4000) NULL;

--Increased length of element HandlerSupplementalInformationText to 4000 (undocumented change)

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN NOTES VARCHAR(4000) NULL;

--RCRA_LocationAddress_v5.4.xsd
--Increase length of element LocationAddressText to 50

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN LOCATION_STREET1 VARCHAR(50) NULL;

--Increase length of element SupplementalLocationText to 50

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN LOCATION_STREET2 VARCHAR(50) NULL;

--RCRA_MailingAddress_v5.4.xsd
--Increase length of element MailingAddressText to 50

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN MAIL_STREET1 VARCHAR(50) NULL;

--Increase length of element SupplementalAddressText to 50

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN MAIL_STREET2 VARCHAR(50) NULL;

--RCRA_Shared_v5.4.xsd
--Increase length of element FirstName to 38

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN CONTACT_FIRST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN PCONTACT_FIRST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_CERTIFICATION
    ALTER COLUMN CERT_FIRST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_OWNEROP
    ALTER COLUMN FIRST_NAME VARCHAR(38) NULL;

--Increase length of element LastName to 38

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN CONTACT_LAST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN PCONTACT_LAST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_CERTIFICATION
    ALTER COLUMN CERT_LAST_NAME VARCHAR(38) NULL;

    ALTER TABLE RCRA_HD_OWNEROP
    ALTER COLUMN LAST_NAME VARCHAR(38) NULL;

--RCRA_Handler_v5.4.xsd
--Added optional element: HandlerInternalSupplementalInformationText to capture internal notes

IF (SELECT COUNT(1) FROM sys.columns where name = 'INTRNL_NOTES') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD INTRNL_NOTES VARCHAR(4000) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Internal notes regarding the Handler' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'INTRNL_NOTES';
END

--RCRA_OtherID_v5.4
--Increased length of element OtherIDSupplementalInformationText to 4000

    ALTER TABLE RCRA_HD_OTHER_ID
    ALTER COLUMN NOTES VARCHAR(4000) NULL;

--RCRA_v5.4
--Added optional element: CertificationEmailText to capture email (added 12/8/2016)

IF (SELECT COUNT(1) FROM sys.columns where name = 'CERT_EMAIL_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_CERTIFICATION
    ADD CERT_EMAIL_TEXT VARCHAR(80) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: CertificationEmailText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_CERTIFICATION', @level2type=N'COLUMN',@level2name=N'CERT_EMAIL_TEXT';
END
--Shortened EmailAddressTextDataType from 240 to 80 align with RCRAInfo database (1 of 3) (added 12/8/2016)

    ALTER TABLE RCRA_HD_OWNEROP
    ALTER COLUMN EMAIL_ADDRESS VARCHAR(80) NULL;

--Shortened EmailAddressTextDataType from 240 to 80 align with RCRAInfo database (2 of 3) (added 12/8/2016)

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN CONTACT_EMAIL_ADDRESS VARCHAR(80) NULL;

--Shortened EmailAddressTextDataType from 240 to 80 align with RCRAInfo database (3 of 3) (added 12/8/2016)

    ALTER TABLE RCRA_HD_HANDLER
    ALTER COLUMN PCONTACT_EMAIL_ADDRESS VARCHAR(80) NULL;

--Added optional element: ShortTermSupplementalInformationText to capture notes (added 12/8/2016)

IF (SELECT COUNT(1) FROM sys.columns where name = 'SHORT_TERM_INTRNL_NOTES') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD SHORT_TERM_INTRNL_NOTES VARCHAR(4000) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schema element: ShortTermSupplementalInformationText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'SHORT_TERM_INTRNL_NOTES';
END

--Added optional element: NatureOfBusinessText to capture Part A notes (added 12/8/2016)
IF (SELECT COUNT(1) FROM sys.columns where name = 'NATURE_OF_BUSINESS_TEXT') = 0
BEGIN
    ALTER TABLE RCRA_HD_HANDLER
    ADD NATURE_OF_BUSINESS_TEXT VARCHAR(4000) NULL;

    EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notes regarding Handler Part-A submissions. (NatureOfBusinessText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RCRA_HD_HANDLER', @level2type=N'COLUMN',@level2name=N'NATURE_OF_BUSINESS_TEXT';
END

--Other Fixes to staging tables unrelated to EPA schema change

UPDATE RCRA_HD_HANDLER SET SHORT_TERM_GEN_IND = LEFT(SHORT_TERM_GEN_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN SHORT_TERM_GEN_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET TRANSFER_FACILITY_IND = LEFT(TRANSFER_FACILITY_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN TRANSFER_FACILITY_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET COLLEGE_IND = LEFT(COLLEGE_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN COLLEGE_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET HOSPITAL_IND = LEFT(HOSPITAL_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN HOSPITAL_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET NON_PROFIT_IND = LEFT(NON_PROFIT_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN NON_PROFIT_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET WITHDRAWAL_IND = LEFT(WITHDRAWAL_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN WITHDRAWAL_IND CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET TRANS_CODE = LEFT(TRANS_CODE, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN TRANS_CODE CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET NOTIFICATION_RSN_CODE = LEFT(NOTIFICATION_RSN_CODE, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN NOTIFICATION_RSN_CODE CHAR(1) NULL
GO

UPDATE RCRA_HD_HANDLER SET FINANCIAL_ASSURANCE_IND = LEFT(FINANCIAL_ASSURANCE_IND, 1)

ALTER TABLE RCRA_HD_HANDLER
ALTER COLUMN FINANCIAL_ASSURANCE_IND CHAR(1) NULL
GO

--Adjust decimal data types to match schema
ALTER TABLE RCRA_GIS_GEO_INFORMATION	
ALTER COLUMN AREA_ACREAGE_MEAS [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_FA_COST_EST
ALTER COLUMN COST_ESTIMATE_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_CME_PNLTY
ALTER COLUMN CASH_CIVIL_PNLTY_SOUGHT_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_FA_MECHANISM_DETAIL
ALTER COLUMN FACE_VAL_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_CME_SUPP_ENVR_PRJT
ALTER COLUMN SEP_EXPND_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_CME_PYMT
ALTER COLUMN SCHD_PYMT_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_CME_PYMT
ALTER COLUMN ACTL_PAID_AMOUNT [decimal](13, 2) NULL
GO

ALTER TABLE RCRA_PRM_UNIT_DETAIL
ALTER COLUMN PERMIT_UNIT_CAP_QNTY [decimal](14, 3) NULL
GO
