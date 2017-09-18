--------------------------------------------------------
--  File created - Wednesday-May-26-2010   
--------------------------------------------------------
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
	"FUEL_CODE" VARCHAR2(100), 
	"ASSIGN_CODE" VARCHAR2(100), 
	"RIN_YEAR" NUMBER(10,0), 
	"BUY_RSN_CODE" VARCHAR2(100), 
	"RIN_PRICE_AMT" NUMBER(5,2), 
	"GALLON_PRICE_AMT" NUMBER(5,2), 
	"TRANS_DATE" DATE, 
	"PTD_NUM" VARCHAR2(100), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_PART_ORG_IDEN" IS 'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using either the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_PART_ORG_NAME" IS 'The name of the organization trading partner. (TransactionPartnerOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."ASSIGN_CODE" IS 'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BUY_RSN_CODE" IS 'This code identifies the reason for a buy transaction. (BuyReasonCode)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."RIN_PRICE_AMT" IS 'Price paid per RIN. (RINPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GALLON_PRICE_AMT" IS 'Price paid per gallon of renewable fuel. (GallonPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_DATE" IS 'The date of the RIN transaction. (TransactionDate)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."PTD_NUM" IS 'The PTD number associated with the transaction. (PTDNumber)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQREg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_BUY_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_BUY_TRANS_DETAIL"  IS 'Schema element: BuyTransactionDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_CO_PROD_DETAIL" 
   (	"CO_PROD_DETAIL_ID" VARCHAR2(40), 
	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"CO_PROD_CODE" VARCHAR2(3), 
	"CO_PROD_DETAIL_CMNT_TXT" VARCHAR2(400)
   ) ;
 

   COMMENT ON COLUMN "EMTS_CO_PROD_DETAIL"."CO_PROD_CODE" IS 'A code that identifies the co-product created fro the renewable fuel process. (CoProductCode)';
 
   COMMENT ON COLUMN "EMTS_CO_PROD_DETAIL"."CO_PROD_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the CoProduct. (CoProductDetailCommentText)';
 
   COMMENT ON TABLE "EMTS_CO_PROD_DETAIL"  IS 'Schema element: CoProductDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_EMTS
--------------------------------------------------------

  CREATE TABLE "EMTS_EMTS" 
   (	"EMTS_ID" VARCHAR2(40), 
	"USER_LOGIN_TXT" VARCHAR2(100), 
	"SUBM_CRTN_DATE" DATE, 
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
	"FDSTK_CODE" VARCHAR2(3), 
	"RENEW_BIOMASS_IND" CHAR(1), 
	"FDSTK_VOL" NUMBER(10,1), 
	"FDSTK_MEAS_CODE" VARCHAR2(3), 
	"FDSTK_DETAIL_CMNT_TXT" VARCHAR2(400)
   ) ;
 

   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_CODE" IS 'AA code that identifies the feedstock used to produce the renewable fuel associated with the batch number. (FeedstockCode)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."RENEW_BIOMASS_IND" IS 'An indicator whether the feedstock used qualifies as renewable biomass. (RenewableBiomassIndicator)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_VOL" IS 'Total volume of feedstock used in the production of the fuel. (FeedstockVolume)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_MEAS_CODE" IS 'The unit of measure associated with the volume of feedstock used in the production of renewable fuel. (FeedstockMeasureCode)';
 
   COMMENT ON COLUMN "EMTS_FDSTK_DETAIL"."FDSTK_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the Feedstock. (FeedstockDetailCommentText)';
 
   COMMENT ON TABLE "EMTS_FDSTK_DETAIL"  IS 'Schema element: FeedstockDetailDataType';
--------------------------------------------------------
--  DDL for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  CREATE TABLE "EMTS_GENR_TRANS_DETAIL" 
   (	"GENR_TRANS_DETAIL_ID" VARCHAR2(40), 
	"EMTS_ID" VARCHAR2(40), 
	"FUEL_CODE" VARCHAR2(100), 
	"PROC_CODE" VARCHAR2(3), 
	"PROD_DATE" DATE, 
	"FUEL_CATG_CODE" VARCHAR2(3), 
	"BATCH_VOL" NUMBER(10,0), 
	"DENATURANT_VOL" NUMBER(10,0), 
	"EQUIVALENCE_VAL" NUMBER(2,1), 
	"RIN_QNTY" NUMBER(10,0), 
	"IMPORT_FAC_IDEN" VARCHAR2(12), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."PROC_CODE" IS 'A code that identifies the process used for producing the renewable fuel. (ProcessCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."PROD_DATE" IS 'The date the renewable fuel was produced as designated by the producing facility. (ProductionDate)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."FUEL_CATG_CODE" IS 'The renewable fuel typeas described in section 80.1426. (FuelCategoryCode)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."DENATURANT_VOL" IS 'The volume of non-renewable fuel added to a volume of ethanol to create the BatchVolume for a given BatchNumber of renewable fuel. (DenaturantVolume)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."EQUIVALENCE_VAL" IS 'A multiplier applied to BatchVolume to determine the number of RINs that will be generated per gallon of renewable fuel produced.  The EquivalenceValue is directly related to FuelCode as defined in Section 80.1415. (EquivalenceValue)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."IMPORT_FAC_IDEN" IS 'The public facility identifier of the plant where the fuel was imported. (ImportFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_GENR_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQREg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
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
	"FUEL_CODE" VARCHAR2(100), 
	"ASSIGN_CODE" VARCHAR2(100), 
	"RIN_YEAR" NUMBER(10,0), 
	"RETIRE_RSN_CODE" VARCHAR2(100), 
	"COMPL_YEAR" NUMBER(10,0), 
	"COMPL_LEVEL_CODE" VARCHAR2(100), 
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
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_YEAR" IS 'The compliance year for which the transaction is applied. (ComplianceYear)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_LEVEL_CODE" IS 'The compliance basis for the submitting organization: Facility, Aggregated Importer, Aggregated Refiner, Aggregated Exporter, Non-Obligated Party. (ComplianceLevelCode)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."COMPL_FAC_IDEN" IS 'The The facility identifier, as registered in OTAQReg, for the facility that has a compliance obligation. (ComplianceFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQREg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_RETIRE_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_RETIRE_TRANS_DETAIL"  IS 'Schema element: RetireTransactionDetailDataType';
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
	"FUEL_CODE" VARCHAR2(100), 
	"ASSIGN_CODE" VARCHAR2(100), 
	"RIN_YEAR" NUMBER(10,0), 
	"SELL_RSN_CODE" VARCHAR2(100), 
	"RIN_PRICE_AMT" NUMBER(5,2), 
	"GALLON_PRICE_AMT" NUMBER(5,2), 
	"TRANS_DATE" DATE, 
	"PTD_NUM" VARCHAR2(100), 
	"TRANS_DETAIL_CMNT_TXT" VARCHAR2(400), 
	"GENR_ORG_IDEN" VARCHAR2(12), 
	"GENR_FAC_IDEN" VARCHAR2(12), 
	"BATCH_NUM_TXT" VARCHAR2(20)
   ) ;
 

   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_PART_ORG_IDEN" IS 'This identifies the buyer organization for a sell transaction or the selling organization for the buy transaction using either the OrganizationIdentifier designated by OTAQReg. (TransactionPartnerOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_PART_ORG_NAME" IS 'The name of the organization trading partner. (TransactionPartnerOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_QNTY" IS 'The total number of RINs specified in the transaction. (RINQuantity)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."BATCH_VOL" IS 'The volume, in gallons, of renewable fuel associated with a batch number designated by the producing facility. (BatchVolume)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."FUEL_CODE" IS 'The renewable fuel code for the batch as defined in Part M Section 80.1426. (FuelCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."ASSIGN_CODE" IS 'A code that indicates whether the RIN is transacting as an assigned RIN or a separated RIN. (AssignmentCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."SELL_RSN_CODE" IS 'This code identifies the reason for a sell transaction. (SellReasonCode)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."RIN_PRICE_AMT" IS 'Price paid per RIN. (RINPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."GALLON_PRICE_AMT" IS 'Price paid per gallon of renewable fuel. (GallonPriceAmount)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_DATE" IS 'The date of the RIN transaction. (TransactionDate)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."PTD_NUM" IS 'The PTD number associated with the transaction. (PTDNumber)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_SELL_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQREg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
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
	"FUEL_CODE" VARCHAR2(100), 
	"SEPR_RSN_CODE" VARCHAR2(100), 
	"RIN_YEAR" NUMBER(10,0), 
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
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."SEPR_RSN_CODE" IS 'This code identifies the reason for a separate transaction. (SeparateReasonCode)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."RIN_YEAR" IS 'The RINYear is the year in which the fuel is produced. (RINYear)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BLENDER_ORG_IDEN" IS 'The public organization identifer of the small Blender. (BlenderOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BLENDER_ORG_NAME" IS 'The name of the small blender that is blending the fuel.  (BlenderOrganizationName)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."TRANS_DETAIL_CMNT_TXT" IS 'Comment provided by the user on the transaction. (TransactionDetailCommentText)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."GENR_ORG_IDEN" IS 'The OTAQREg identifier for the organization that generated the fuel. (GenerateOrganizationIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."GENR_FAC_IDEN" IS 'The facility identifier, as registered in OTAQReg, for the facility that produced the fuel. (GenerateFacilityIdentifier)';
 
   COMMENT ON COLUMN "EMTS_SEPR_TRANS_DETAIL"."BATCH_NUM_TXT" IS 'The batch number for the renewable fuel as designated by the producing facility. (BatchNumberText)';
 
   COMMENT ON TABLE "EMTS_SEPR_TRANS_DETAIL"  IS 'Schema element: SeparateTransactionDetailDataType';

---------------------------------------------------
--   DATA FOR TABLE EMTS_BUY_SUPRT_DOC_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_BUY_SUPRT_DOC_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_BUY_SUPRT_DOC_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_BUY_TRANS_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_BUY_TRANS_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_BUY_TRANS_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_CO_PROD_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_CO_PROD_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_CO_PROD_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_EMTS
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_EMTS

---------------------------------------------------
--   END DATA FOR TABLE EMTS_EMTS
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_FDSTK_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_FDSTK_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_FDSTK_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_GENR_TRANS_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_GENR_TRANS_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_GENR_TRANS_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_RETIRE_SUPRT_DOC_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_RETIRE_SUPRT_DOC_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_RETIRE_SUPRT_DOC_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_RETIRE_TRANS_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_RETIRE_TRANS_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_RETIRE_TRANS_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_SELL_SUPRT_DOC_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_SELL_SUPRT_DOC_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_SELL_SUPRT_DOC_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_SELL_TRANS_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_SELL_TRANS_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_SELL_TRANS_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_SEPR_SUPRT_DOC_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_SEPR_SUPRT_DOC_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_SEPR_SUPRT_DOC_DETAIL
---------------------------------------------------


---------------------------------------------------
--   DATA FOR TABLE EMTS_SEPR_TRANS_DETAIL
--   FILTER = none used
---------------------------------------------------
REM INSERTING into EMTS_SEPR_TRANS_DETAIL

---------------------------------------------------
--   END DATA FOR TABLE EMTS_SEPR_TRANS_DETAIL
---------------------------------------------------

--------------------------------------------------------
--  Constraints for Table EMTS_SELL_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" ADD CONSTRAINT "PK_SELL_TRNS_DETIL" PRIMARY KEY ("SELL_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("SELL_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("SELL_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" MODIFY ("TRANS_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_BUY_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" ADD CONSTRAINT "PK_BUY_TRANS_DETIL" PRIMARY KEY ("BUY_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("BUY_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_IDEN" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANS_PART_ORG_NAME" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("BUY_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" MODIFY ("TRANS_DATE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_RTRE_SPR_DC_DTL" PRIMARY KEY ("RETIRE_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("RETIRE_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("RETIRE_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" ADD CONSTRAINT "PK_GENR_TRNS_DETIL" PRIMARY KEY ("GENR_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("PROC_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("PROD_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("FUEL_CATG_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("BATCH_VOL" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" ADD CONSTRAINT "PK_RTIRE_TRNS_DTIL" PRIMARY KEY ("RETIRE_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RETIRE_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("ASSIGN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" MODIFY ("RETIRE_RSN_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_SLL_SPRT_DC_DTL" PRIMARY KEY ("SELL_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SELL_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SELL_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_BY_SPRT_DC_DTIL" PRIMARY KEY ("BUY_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("BUY_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("BUY_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "PK_SPR_SPRT_DC_DTL" PRIMARY KEY ("SEPR_SUPRT_DOC_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SEPR_SUPRT_DOC_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SEPR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" MODIFY ("SUPRT_DOC_NUM_TXT" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_EMTS
--------------------------------------------------------

  ALTER TABLE "EMTS_EMTS" ADD CONSTRAINT "PK_EMTS" PRIMARY KEY ("EMTS_ID") ENABLE;
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("USER_LOGIN_TXT" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("SUBM_CRTN_DATE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_EMTS" MODIFY ("ORG_IDEN" NOT NULL ENABLE);
  
  ALTER TABLE "EMTS_EMTS" ADD CONSTRAINT "ORG_IDEN_UNIQUE" UNIQUE ("ORG_IDEN");
--------------------------------------------------------
--  Constraints for Table EMTS_FDSTK_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_FDSTK_DETAIL" ADD CONSTRAINT "PK_FDSTK_DETAIL" PRIMARY KEY ("FDSTK_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("RENEW_BIOMASS_IND" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_VOL" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_FDSTK_DETAIL" MODIFY ("FDSTK_MEAS_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_CO_PROD_DETAIL" ADD CONSTRAINT "PK_CO_PROD_DETAIL" PRIMARY KEY ("CO_PROD_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("CO_PROD_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("GENR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_CO_PROD_DETAIL" MODIFY ("CO_PROD_CODE" NOT NULL ENABLE);
--------------------------------------------------------
--  Constraints for Table EMTS_SEPR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" ADD CONSTRAINT "PK_SEPR_TRNS_DETIL" PRIMARY KEY ("SEPR_TRANS_DETAIL_ID") ENABLE;
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("SEPR_TRANS_DETAIL_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("EMTS_ID" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("RIN_QNTY" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("BATCH_VOL" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("FUEL_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("SEPR_RSN_CODE" NOT NULL ENABLE);
 
  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" MODIFY ("RIN_YEAR" NOT NULL ENABLE);
--------------------------------------------------------
--  DDL for Index PK_FDSTK_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_FDSTK_DETAIL" ON "EMTS_FDSTK_DETAIL" ("FDSTK_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_EMTS
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_EMTS" ON "EMTS_EMTS" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SPR_TR_DT_EM_ID
--------------------------------------------------------

  CREATE INDEX "IX_SPR_TR_DT_EM_ID" ON "EMTS_SEPR_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_GNR_TR_DT_EM_ID
--------------------------------------------------------

  CREATE INDEX "IX_GNR_TR_DT_EM_ID" ON "EMTS_GENR_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_RTRE_SPR_DC_DTL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RTRE_SPR_DC_DTL" ON "EMTS_RETIRE_SUPRT_DOC_DETAIL" ("RETIRE_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SLL_TR_DT_EM_ID
--------------------------------------------------------

  CREATE INDEX "IX_SLL_TR_DT_EM_ID" ON "EMTS_SELL_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RTR_TR_DT_EM_ID
--------------------------------------------------------

  CREATE INDEX "IX_RTR_TR_DT_EM_ID" ON "EMTS_RETIRE_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_BUY_TRANS_DETIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_BUY_TRANS_DETIL" ON "EMTS_BUY_TRANS_DETAIL" ("BUY_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SPR_SPRT_DC_DTL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SPR_SPRT_DC_DTL" ON "EMTS_SEPR_SUPRT_DOC_DETAIL" ("SEPR_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SLL_SPRT_DC_DTL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SLL_SPRT_DC_DTL" ON "EMTS_SELL_SUPRT_DOC_DETAIL" ("SELL_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SL_SP_DC_DT_SL
--------------------------------------------------------

  CREATE INDEX "IX_SL_SP_DC_DT_SL" ON "EMTS_SELL_SUPRT_DOC_DETAIL" ("SELL_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_CO_PR_DT_GN_TR
--------------------------------------------------------

  CREATE INDEX "IX_CO_PR_DT_GN_TR" ON "EMTS_CO_PROD_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SEPR_TRNS_DETIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SEPR_TRNS_DETIL" ON "EMTS_SEPR_TRANS_DETAIL" ("SEPR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BY_TRN_DT_EM_ID
--------------------------------------------------------

  CREATE INDEX "IX_BY_TRN_DT_EM_ID" ON "EMTS_BUY_TRANS_DETAIL" ("EMTS_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_BY_SP_DC_DT_BY
--------------------------------------------------------

  CREATE INDEX "IX_BY_SP_DC_DT_BY" ON "EMTS_BUY_SUPRT_DOC_DETAIL" ("BUY_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_GENR_TRNS_DETIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_GENR_TRNS_DETIL" ON "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_RT_SP_DC_DT_RT
--------------------------------------------------------

  CREATE INDEX "IX_RT_SP_DC_DT_RT" ON "EMTS_RETIRE_SUPRT_DOC_DETAIL" ("RETIRE_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_SELL_TRNS_DETIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_SELL_TRNS_DETIL" ON "EMTS_SELL_TRANS_DETAIL" ("SELL_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_FD_DT_GN_TR_DT
--------------------------------------------------------

  CREATE INDEX "IX_FD_DT_GN_TR_DT" ON "EMTS_FDSTK_DETAIL" ("GENR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index IX_SP_SP_DC_DT_SP
--------------------------------------------------------

  CREATE INDEX "IX_SP_SP_DC_DT_SP" ON "EMTS_SEPR_SUPRT_DOC_DETAIL" ("SEPR_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_CO_PROD_DETAIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_CO_PROD_DETAIL" ON "EMTS_CO_PROD_DETAIL" ("CO_PROD_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_RTIRE_TRNS_DTIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_RTIRE_TRNS_DTIL" ON "EMTS_RETIRE_TRANS_DETAIL" ("RETIRE_TRANS_DETAIL_ID") 
  ;
--------------------------------------------------------
--  DDL for Index PK_BY_SPRT_DC_DTIL
--------------------------------------------------------

  CREATE UNIQUE INDEX "PK_BY_SPRT_DC_DTIL" ON "EMTS_BUY_SUPRT_DOC_DETAIL" ("BUY_SUPRT_DOC_DETAIL_ID") 
  ;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_BUY_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_BY_SP_DC_DT_BY" FOREIGN KEY ("BUY_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_BUY_TRANS_DETAIL" ("BUY_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_BUY_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_BUY_TRANS_DETAIL" ADD CONSTRAINT "FK_BY_TRNS_DTL_EMT" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_CO_PROD_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_CO_PROD_DETAIL" ADD CONSTRAINT "FK_CO_PR_DT_GN_TR" FOREIGN KEY ("GENR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;

--------------------------------------------------------
--  Ref Constraints for Table EMTS_FDSTK_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_FDSTK_DETAIL" ADD CONSTRAINT "FK_FDS_DT_GN_TR_DT" FOREIGN KEY ("GENR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_GENR_TRANS_DETAIL" ("GENR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_GENR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_GENR_TRANS_DETAIL" ADD CONSTRAINT "FK_GNR_TRN_DTL_EMT" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_RETIRE_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_RT_SP_DC_DT_RT" FOREIGN KEY ("RETIRE_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_RETIRE_TRANS_DETAIL" ("RETIRE_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_RETIRE_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_RETIRE_TRANS_DETAIL" ADD CONSTRAINT "FK_RTR_TRN_DTL_EMT" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SELL_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_SL_SP_DC_DT_SL" FOREIGN KEY ("SELL_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_SELL_TRANS_DETAIL" ("SELL_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SELL_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SELL_TRANS_DETAIL" ADD CONSTRAINT "FK_SLL_TRN_DTL_EMT" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SEPR_SUPRT_DOC_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_SUPRT_DOC_DETAIL" ADD CONSTRAINT "FK_SP_SP_DC_DT_SP" FOREIGN KEY ("SEPR_TRANS_DETAIL_ID")
	  REFERENCES "EMTS_SEPR_TRANS_DETAIL" ("SEPR_TRANS_DETAIL_ID") ON DELETE CASCADE ENABLE;
--------------------------------------------------------
--  Ref Constraints for Table EMTS_SEPR_TRANS_DETAIL
--------------------------------------------------------

  ALTER TABLE "EMTS_SEPR_TRANS_DETAIL" ADD CONSTRAINT "FK_SPR_TRN_DTL_EMT" FOREIGN KEY ("EMTS_ID")
	  REFERENCES "EMTS_EMTS" ("EMTS_ID") ON DELETE CASCADE ENABLE;
