--------------------------------------------------------
--  File created - Monday-November-28-2011   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table EMTS_BUY_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" 
   (	"BUY_PUB_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"BUY_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_BUY_PUB_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_BUY_PUB_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL"  IS 'Schema element: BuyPublicSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" 
   (	"BUY_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"BUY_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_BUY_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_BUY_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_BUY_SUPRT_DOC_DETAIL"  IS 'Schema element: BuySupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_BUY_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_BUY_TRANS_DETAIL" 
   (	"BUY_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"TRANS_PART_ORG_IDEN" VARCHAR2(12), 
	"TRANS_PART_ORG_NAME" VARCHAR2(125), 
	"RIN_QNTY" NUMBER(10,0), 
	"BATCH_VOL" NUMBER(10,0), 
	"FUEL_CODE" VARCHAR2(4), 
	"ASSIGN_CODE" NUMBER(10,0), 
	"RIN_YEAR" NUMBER(10,0), 
	"BUY_RSN_CODE" VARCHAR2(4), 
	"RIN_PRICE_AMT" NUMBER(5,2), 
	"GALLON_PRICE_AMT" NUMBER(5,2), 
	"TRANSFER_DATE" TIMESTAMP (6), 
	"PTD_NUM" VARCHAR2(100), 
	"MATCHING_TRANS_IDEN" VARCHAR2(100), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_PART_ORG_IDEN" IS 'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_PART_ORG_NAME" IS 'The name of the organization trading partner. (TransactionPartnerOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."ASSIGN_CODE" IS 'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BUY_RSN_CODE" IS 'This code identifies the reason for a buy transaction. (BuyReasonCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_PRICE_AMT" IS 'Price paid per RIN. (RINPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GALLON_PRICE_AMT" IS 'Price paid per gallon of renewable fuel. (GallonPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANSFER_DATE" IS 'The date of the RIN transaction. (TransferDate)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."PTD_NUM" IS 'The PTD number associated with the transaction. (PTDNumber)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."MATCHING_TRANS_IDEN" IS 'The EMTS transaction identification number that matches the submitted buy or sell transaction. (MatchingTransactionIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_BUY_TRANS_DETAIL"  IS 'Schema element: BuyTransactionDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_CO_PROD_DETAIL" 
   (	"CO_PROD_DETAIL_ID" VARCHAR2(40), 
	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"CO_PROD_CODE" VARCHAR2(4), 
	"CO_PROD_DETAIL_CMNT_TXT" VARCHAR2(400)
   ) ;
 

   COMMENT ON COLUMN "EMTS_CO_PROD_DETAIL"."CO_PROD_CODE" IS 'A code that identifies the co-product created for the renewable fuel process. (CoProductCode)';
 
   COMMENT ON COLUMN "EMTS_CO_PROD_DETAIL"."CO_PROD_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the CoProduct. (CoProductDetailCommentText)';
 
   COMMENT ON TABLE "EMTS_CO_PROD_DETAIL"  IS 'Schema element: CoProductDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_EMTS
--------------------------------------------------------

  CREATE TABLE "EMTS_EMTS" 
   (	"EMTS_ID" VARCHAR2(40), 
	"USER_LOGIN_TXT" VARCHAR2(100), 
	"SUBM_CRTN_DATE" TIMESTAMP (6), 
	"ORG_IDEN" VARCHAR2(12), 
	"SUBM_CMNT_TXT" VARCHAR2(400)
   ) ;
 

   COMMENT ON COLUMN "EMTS_EMTS"."USER_LOGIN_TXT" IS 'The CDX user login of the party responsible for preparing the submission file. (UserLoginText)';
 
   COMMENT ON COLUMN "EMTS_EMTS"."SUBM_CRTN_DATE" IS 'The date that the submission file was created. (SubmittalCreationDate)';
 
   COMMENT ON COLUMN "EMTS_EMTS"."ORG_IDEN" IS 'The public identification number for the organization as designated by OTAQReg.  This must be reported if a OrganizationRINPin is not supplied. (OrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_EMTS"."SUBM_CMNT_TXT" IS 'Comment provided by the user on submission file. (SubmittalCommentText)';
 
   COMMENT ON TABLE "EMTS_EMTS"  IS 'Schema element: EMTSDataType';
--------------------------------------------------------
--  DDL for Table EMTS_FDSTK_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_FDSTK_DETAIL" 
   (	"FDSTK_DETAIL_ID" VARCHAR2(40), 
	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"FDSTK_CODE" VARCHAR2(4), 
	"RENEW_BIOMASS_IND" CHAR(1), 
	"FDSTK_QNTY" NUMBER(5,2), 
	"FDSTK_MEAS_CODE" VARCHAR2(3), 
	"FDSTK_DETAIL_CMNT_TXT" VARCHAR2(400)
   ) ;
 

   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_CODE" IS 'A code that identifies the feedstock used to produce the renewable fuel associated with the batch number. (FeedstockCode)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."RENEW_BIOMASS_IND" IS 'An indicator of whether the feedstock used qualifies as renewable biomass. (RenewableBiomassIndicator)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_QNTY" IS 'Total amount of feedstock used in the production of the fuel. (FeedstockQuantity)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_MEAS_CODE" IS 'The unit of measure associated with the volume of feedstock used in the production of renewable fuel. (FeedstockMeasureCode)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the Feedstock. (FeedstockDetailCommentText)';
 
   COMMENT ON TABLE "EMTS_FDSTK_DETAIL"  IS 'Schema element: FeedstockDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_GENR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" 
   (	"GENR_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_GENR_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_GENR_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_GENR_SUPRT_DOC_DETAIL"  IS 'Schema element: GenerateSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_GENR_TRANS_DETAIL" 
   (	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"RIN_QNTY" NUMBER(10,0), 
	"BATCH_VOL" NUMBER(10,0), 
	"FUEL_CODE" VARCHAR2(4), 
	"FUEL_CATG_CODE" VARCHAR2(4), 
	"PROD_DATE" TIMESTAMP (6), 
	"PROC_CODE" VARCHAR2(4), 
	"DENATURANT_VOL" NUMBER(10,0), 
	"EQUIVALENCE_VAL" NUMBER(5,2), 
	"IMPORT_FAC_IDEN" VARCHAR2(12), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."FUEL_CATG_CODE" IS 'The renewable fuel type as described in section 80.1426. (FuelCategoryCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."PROD_DATE" IS 'The date the renewable fuel was produced as designated by the producing facility. (ProductionDate)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."PROC_CODE" IS 'A code that identifies the process used for producing the renewable fuel. (ProcessCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."DENATURANT_VOL" IS 'The volume of non-renewable fuel added to a volume of ethanol to create the BatchVolume for a given BatchNumber of renewable fuel. (DenaturantVolume)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."EQUIVALENCE_VAL" IS 'A multiplier applied to BatchVolume to determine the number of RINs that will be generated per gallon of renewable fuel produced.  The EquivalenceValue is directly related to FuelCategoryCode as defined in Section 80.1415. (EquivalenceValue)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."IMPORT_FAC_IDEN" IS 'The public facility identifier of the plant where the fuel was imported. (ImportFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_GENR_TRANS_DETAIL"  IS 'Schema element: GenerateTransactionDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" 
   (	"RETIRE_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"RETIRE_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_RETIRE_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL"  IS 'Schema element: RetireSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_RETIRE_TRANS_DETAIL" 
   (	"RETIRE_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"RIN_QNTY" NUMBER(10,0), 
	"BATCH_VOL" NUMBER(10,0), 
	"FUEL_CODE" VARCHAR2(4), 
	"ASSIGN_CODE" NUMBER(10,0), 
	"RIN_YEAR" NUMBER(10,0), 
	"RETIRE_RSN_CODE" VARCHAR2(4), 
	"TRANS_DATE" TIMESTAMP (6), 
	"COMPL_YEAR" NUMBER(10,0), 
	"COMPL_LEVEL_CODE" VARCHAR2(3), 
	"COMPL_FAC_IDEN" VARCHAR2(12), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."ASSIGN_CODE" IS 'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."RETIRE_RSN_CODE" IS 'This code identifies the reason for a retire transaction. (RetireReasonCode)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."TRANS_DATE" IS 'The date of the RIN transaction. (TransactionDate)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_YEAR" IS 'The compliance year for which the transaction is applied. (ComplianceYear)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_LEVEL_CODE" IS 'The compliance basis for the submitting organization: Facility, Aggregated Importer, Aggregated Refiner, Aggregated Exporter, Non-Obligated Party. (ComplianceLevelCode)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_FAC_IDEN" IS 'The The facility identifier, as registered in OTAQReg, for the facility that has a compliance obligation. (ComplianceFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_RETIRE_TRANS_DETAIL"  IS 'Schema element: RetireTransactionDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_SELL_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" 
   (	"SELL_PUB_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"SELL_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SELL_PUB_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_SELL_PUB_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL"  IS 'Schema element: SellPublicSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" 
   (	"SELL_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"SELL_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SELL_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_SELL_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_SELL_SUPRT_DOC_DETAIL"  IS 'Schema element: SellSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_SELL_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_SELL_TRANS_DETAIL" 
   (	"SELL_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"TRANS_PART_ORG_IDEN" VARCHAR2(12), 
	"TRANS_PART_ORG_NAME" VARCHAR2(125), 
	"RIN_QNTY" NUMBER(10,0), 
	"BATCH_VOL" NUMBER(10,0), 
	"FUEL_CODE" VARCHAR2(4), 
	"ASSIGN_CODE" NUMBER(10,0), 
	"RIN_YEAR" NUMBER(10,0), 
	"SELL_RSN_CODE" VARCHAR2(4), 
	"RIN_PRICE_AMT" NUMBER(5,2), 
	"GALLON_PRICE_AMT" NUMBER(5,2), 
	"TRANSFER_DATE" TIMESTAMP (6), 
	"PTD_NUM" VARCHAR2(100), 
	"MATCHING_TRANS_IDEN" VARCHAR2(100), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_PART_ORG_IDEN" IS 'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_PART_ORG_NAME" IS 'The name of the organization trading partner. (TransactionPartnerOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."ASSIGN_CODE" IS 'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."SELL_RSN_CODE" IS 'This code identifies the reason for a sell transaction. (SellReasonCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_PRICE_AMT" IS 'Price paid per RIN. (RINPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."GALLON_PRICE_AMT" IS 'Price paid per gallon of renewable fuel. (GallonPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANSFER_DATE" IS 'The date of the RIN transaction. (TransferDate)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."PTD_NUM" IS 'The PTD number associated with the transaction. (PTDNumber)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."MATCHING_TRANS_IDEN" IS 'The EMTS transaction identification number that matches the submitted buy or sell transaction. (MatchingTransactionIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_SELL_TRANS_DETAIL"  IS 'Schema element: SellTransactionDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" 
   (	"SEPR_SUPRT_DOC_DETAIL_ID" VARCHAR2(40), 
	"SEPR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"SUPRT_DOC_TXT" VARCHAR2(100), 
	"SUPRT_DOC_NUM_TXT" VARCHAR2(100)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SEPR_SUPRT_DOC_DETAIL"."SUPRT_DOC_TXT" IS 'The type of document to which the document number applies.   (SupportingDocumentText)';
 
   COMMENT ON COLUMN "EMTS_SEPR_SUPRT_DOC_DETAIL"."SUPRT_DOC_NUM_TXT" IS 'The identification number for the supporting document. (SupportingDocumentNumberText)';
 
   COMMENT ON TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL"  IS 'Schema element: SeparateSupportingDocumentDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_SEPR_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_SEPR_TRANS_DETAIL" 
   (	"SEPR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"RIN_QNTY" NUMBER(10,0), 
	"BATCH_VOL" NUMBER(10,0), 
	"FUEL_CODE" VARCHAR2(4), 
	"RIN_YEAR" NUMBER(10,0), 
	"SEPR_RSN_CODE" VARCHAR2(4), 
	"TRANS_DATE" TIMESTAMP (6), 
	"BLENDER_ORG_IDEN" VARCHAR2(12), 
	"BLENDER_ORG_NAME" VARCHAR2(125), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."SEPR_RSN_CODE" IS 'This code identifies the reason for a separate transaction. (SeparateReasonCode)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."TRANS_DATE" IS 'The date of the RIN transaction. (TransactionDate)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BLENDER_ORG_IDEN" IS 'The public organization identifier of the small Blender. (BlenderOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BLENDER_ORG_NAME" IS 'The name of the small blender that is blending the fuel.  (BlenderOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQReg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_SEPR_TRANS_DETAIL"  IS 'Schema element: SeparateTransactionDetailDataType';
--------------------------------------------------------
--  Constraints for Table EMTS_SELL_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_SELL_PUB_SUPRT_DOC_DETAIL" PRIMARY KEY ("SELL_PUB_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" MODIFY ("SELL_PUB_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" MODIFY ("SELL_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_CO_PROD_DETAIL" ADD CONSTRAINT "PK_CO_PROD_DETAIL" PRIMARY KEY ("CO_PROD_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("CO_PROD_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("CO_PROD_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_FDSTK_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_FDSTK_DETAIL" ADD CONSTRAINT "PK_FDSTK_DETAIL" PRIMARY KEY ("FDSTK_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("RENEW_BIOMASS_IND" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_MEAS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" ADD CONSTRAINT "PK_RETIRE_TRANS_DETAIL" PRIMARY KEY ("RETIRE_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RETIRE_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RETIRE_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("TRANS_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SEPR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" ADD CONSTRAINT "PK_SEPR_TRANS_DETAIL" PRIMARY KEY ("SEPR_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("SEPR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("SEPR_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("TRANS_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_RETIRE_SUPRT_DOC_DETAIL" PRIMARY KEY ("RETIRE_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("RETIRE_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("RETIRE_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" ADD CONSTRAINT "PK_GENR_TRANS_DETAIL" PRIMARY KEY ("GENR_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("FUEL_CATG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("PROD_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("PROC_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_BUY_SUPRT_DOC_DETAIL" PRIMARY KEY ("BUY_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("BUY_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("BUY_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_EMTS
--------------------------------------------------------

  ALTER TABLE "EMTS_EMTS" ADD CONSTRAINT "PK_EMTS" PRIMARY KEY ("EMTS_ID") ENABLE;
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("USER_LOGIN_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("SUBM_CRTN_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("ORG_IDEN" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SELL_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" ADD CONSTRAINT "PK_SELL_TRANS_DETAIL" PRIMARY KEY ("SELL_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("SELL_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("SELL_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANSFER_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_SELL_SUPRT_DOC_DETAIL" PRIMARY KEY ("SELL_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SELL_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SELL_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_BUY_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" ADD CONSTRAINT "PK_BUY_TRANS_DETAIL" PRIMARY KEY ("BUY_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("BUY_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("BUY_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANSFER_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_GENR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_GENR_SUPRT_DOC_DETAIL" PRIMARY KEY ("GENR_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" MODIFY ("GENR_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_SEPR_SUPRT_DOC_DETAIL" PRIMARY KEY ("SEPR_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SEPR_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SEPR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_BUY_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_BUY_PUB_SUPRT_DOC_DETAIL" PRIMARY KEY ("BUY_PUB_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" MODIFY ("BUY_PUB_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" MODIFY ("BUY_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_CO_PROD_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CO_PROD_DETAIL" ON "EMTS_CO_PROD_DETAIL" ("CO_PROD_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FDSTK_DTIL_GNR_TRNS_DTIL_ID
--------------------------------------------------------

  CREATE INDEX "IX_FDSTK_DTIL_GNR_TRNS_DTIL_ID" ON "EMTS_FDSTK_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RTR_SPR_DC_DTL_RTR_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_RTR_SPR_DC_DTL_RTR_TR_DT_ID" ON "EMTS_RETIRE_SUPRT_DOC_DETAIL" ("RETIRE_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BY_SPR_DC_DTL_BY_TRN_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_BY_SPR_DC_DTL_BY_TRN_DTL_ID" ON "EMTS_BUY_SUPRT_DOC_DETAIL" ("BUY_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RETIRE_SUPRT_DOC_DETAIL" ON "EMTS_RETIRE_SUPRT_DOC_DETAIL" ("RETIRE_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SELL_SUPRT_DOC_DETAIL" ON "EMTS_SELL_SUPRT_DOC_DETAIL" ("SELL_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_BUY_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_BUY_PUB_SUPRT_DOC_DETAIL" ON "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" ("BUY_PUB_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_GENR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GENR_SUPRT_DOC_DETAIL" ON "EMTS_GENR_SUPRT_DOC_DETAIL" ("GENR_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_BUY_TRANS_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_BUY_TRANS_DETAIL" ON "EMTS_BUY_TRANS_DETAIL" ("BUY_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SPR_SPR_DC_DTL_SPR_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_SPR_SPR_DC_DTL_SPR_TR_DT_ID" ON "EMTS_SEPR_SUPRT_DOC_DETAIL" ("SEPR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_FDSTK_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FDSTK_DETAIL" ON "EMTS_FDSTK_DETAIL" ("FDSTK_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RETIRE_TRANS_DETAIL_EMTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_RETIRE_TRANS_DETAIL_EMTS_ID" ON "EMTS_RETIRE_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SELL_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SELL_PUB_SUPRT_DOC_DETAIL" ON "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" ("SELL_PUB_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RETIRE_TRANS_DETAIL" ON "EMTS_RETIRE_TRANS_DETAIL" ("RETIRE_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SELL_TRANS_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SELL_TRANS_DETAIL" ON "EMTS_SELL_TRANS_DETAIL" ("SELL_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SEPR_TRANS_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SEPR_TRANS_DETAIL" ON "EMTS_SEPR_TRANS_DETAIL" ("SEPR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BUY_TRANS_DETAIL_EMTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_BUY_TRANS_DETAIL_EMTS_ID" ON "EMTS_BUY_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SELL_TRANS_DETAIL_EMTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_SELL_TRANS_DETAIL_EMTS_ID" ON "EMTS_SELL_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_BUY_SUPRT_DOC_DETAIL" ON "EMTS_BUY_SUPRT_DOC_DETAIL" ("BUY_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SLL_PB_SP_DC_DT_SL_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_SLL_PB_SP_DC_DT_SL_TR_DT_ID" ON "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" ("SELL_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SLL_SPR_DC_DTL_SLL_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_SLL_SPR_DC_DTL_SLL_TR_DT_ID" ON "EMTS_SELL_SUPRT_DOC_DETAIL" ("SELL_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GENR_TRANS_DETAIL_EMTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_GENR_TRANS_DETAIL_EMTS_ID" ON "EMTS_GENR_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GNR_SPR_DC_DTL_GNR_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_GNR_SPR_DC_DTL_GNR_TR_DT_ID" ON "EMTS_GENR_SUPRT_DOC_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMTS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMTS" ON "EMTS_EMTS" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SEPR_SUPRT_DOC_DETAIL" ON "EMTS_SEPR_SUPRT_DOC_DETAIL" ("SEPR_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BY_PB_SPR_DC_DT_BY_TR_DT_ID
--------------------------------------------------------

  CREATE INDEX "IX_BY_PB_SPR_DC_DT_BY_TR_DT_ID" ON "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" ("BUY_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_GENR_TRANS_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GENR_TRANS_DETAIL" ON "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CO_PRD_DTIL_GNR_TRNS_DTL_ID
--------------------------------------------------------

  CREATE INDEX "IX_CO_PRD_DTIL_GNR_TRNS_DTL_ID" ON "EMTS_CO_PROD_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SEPR_TRANS_DETAIL_EMTS_ID
--------------------------------------------------------

  CREATE INDEX "IX_SEPR_TRANS_DETAIL_EMTS_ID" ON "EMTS_SEPR_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_BUY_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_PUB_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_BY_PB_SPR_DC_DTL_BY_TRN_DTL" FOREIGN KEY ("BUY_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_BUY_TRANS_DETAIL" ("BUY_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_BY_SPRT_DC_DTIL_BY_TRNS_DTL" FOREIGN KEY ("BUY_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_BUY_TRANS_DETAIL" ("BUY_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_BUY_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" ADD CONSTRAINT "FK_BUY_TRANS_DETAIL_EMTS" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_CO_PROD_DETAIL" ADD CONSTRAINT "FK_CO_PRD_DETIL_GNR_TRNS_DETIL" FOREIGN KEY ("GENR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table EMTS_FDSTK_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_FDSTK_DETAIL" ADD CONSTRAINT "FK_FDSTK_DETAIL_GNR_TRNS_DETIL" FOREIGN KEY ("GENR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_GENR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_GNR_SPRT_DC_DTL_GNR_TRN_DTL" FOREIGN KEY ("GENR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" ADD CONSTRAINT "FK_GENR_TRANS_DETAIL_EMTS" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_RTRE_SPR_DC_DTL_RTR_TRN_DTL" FOREIGN KEY ("RETIRE_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_RETIRE_TRANS_DETAIL" ("RETIRE_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" ADD CONSTRAINT "FK_RETIRE_TRANS_DETAIL_EMTS" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SELL_PUB_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_PUB_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_SLL_PB_SPR_DC_DTL_SLL_TR_DT" FOREIGN KEY ("SELL_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_SELL_TRANS_DETAIL" ("SELL_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_SLL_SPRT_DC_DTL_SLL_TRN_DTL" FOREIGN KEY ("SELL_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_SELL_TRANS_DETAIL" ("SELL_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SELL_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" ADD CONSTRAINT "FK_SELL_TRANS_DETAIL_EMTS" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_SPR_SPRT_DC_DTL_SPR_TRN_DTL" FOREIGN KEY ("SEPR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_SEPR_TRANS_DETAIL" ("SEPR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SEPR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" ADD CONSTRAINT "FK_SEPR_TRANS_DETAIL_EMTS" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
