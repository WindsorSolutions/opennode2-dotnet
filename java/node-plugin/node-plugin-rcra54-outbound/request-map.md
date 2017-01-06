# Mapping of RCRA Info Solicit Functions to Database Tables

Listed below are a mapping of RCRA Info solicit functions and the database
tables that they populate.

## Hazardous Waste Corrective Action Submission (CA)

Root Class: HazardousWasteCorrectiveActionDataType
Root Table: rcra_hzrdwastecorract

+ rcra_corractfacsub, CorrectiveActionFacilitySubmissionDataType
  + rcra_corractarea, CorrectiveActionAreaDataType
    + rcra_corractrelevent, CorrectiveActionRelatedEventDataType
    + rcra_corractrelpermitunit, CorrectiveActionRelatedPermitUnitDataType
  + rcra_corractauth, CorrectiveActionAuthorityDataType
    + rcra_correactstatcitn, CorrectiveActionStatutoryCitationDataType
    + rcra_corractrelevent, CorrectiveActionRelatedEventDataType
  + rcra_corractevent, CorrectiveActionEventDataType
    + rcra_eventcommit, EventCommitmentDataType
    
## Hazardous Waste CME Submission (CE)

Root Class: HazardousWasteCMESubmission
Root Table: rcra_hzedwastecmesub

+ rcra_cmefacsub, CMEFacilitySubmissionDataType
  + rcra_enfract, EnforcementActionDataType
    + rcra_csnydate, CSNYDateDataType
    + rcra_penalty, PenaltyDataType
      + rcra_paymnt, PaymentDataType
    + rcra_mlstn, MilestoneDataType
    + rcra_vioenfrc, ViolationEnforcementDataType
    + rcra_suppenvproj, SupplementalEnvironmentalProjectDataType
    + rcra_media, MediaDataType
  + rcra_eval, EvaluationDataType
    + rcra_request, RequestDataType
    + rcra_evalcommit, EvaluationCommitmentDataType
    + rcra_evalio, EvaluationViolationDataType
  + rcra_vio, ViolationDataType
    + rcra_citn, CitationDataType
  
## Financial Assurance Submission (FA)

Root Class: FinancialAssuranceSubmissionDataType
Root Table: rcra_finassursub

+ rcra_finassurfacsub, FinancialAssuranceFacilitySubmissionDataType
  + rcra_costest, CostEstimateDataType
    + rcra_costestrelmech, CostEstimateRelatedMechanismDataType
  + rcra_mech, MechanismDataType
    + rcra_mechdetail, MechanismDetailDataType
    
## Geographic Information Submission (GS)

Root Class: GeographicInformationSubmissionDataType
Root Table: rcra_geoginfsub

+ rcra_gisfacsub, GISFacilitySubmissionDataType
  + rcra_geoginf, GeographicInformationDataType
    + rcra_areaacreage, AreaAcreageDataType
    + rcra_geogmeta, GeographicMetaDataType
    + rcra_wheretype, WhereType
    
## Hazardouse Waste Handler Submission (HD)

Root Class: HazardousWasteHandlerSubmissionDataType
Root Table: rcra_hzrdwastehandlersub

+ rcra_facsub, FacilitySubmissionDataType
  + rcra_handler, HandlerDataType
    + rcra_locaddress, LocationAddressDataType
    + rcra_mailingaddress, MailingAddressDataType
    + rcra_contactaddress, ContactAddressDataType
    + rcra_usedoil, UsedOilDataType
    + rcra_sitewasteact, SiteWasteActivityDataType
    + rcra_wastegenrtr, WasteGeneratorDataType
    + rcra_labhzrdwaste, LaboratoryHazardousWasteDataType
    + rcra_hzrdsecondarymtrl, HazardousSecondaryMaterialDataType
      + rcra_hzrdsecondarymtrlact, HazardousSecondaryMaterialActivityDataType
        + rcra_handlerwastecode, HandlerWasteCodeDataType
    + rcra_cert, CertificationDataType
    + rcra_naics, NAICSIdentityDataType
    + rcra_facownroper, FacilityOwnerOperatorDataType
      + rcra_contactaddress, ContactAddressDataType
    + rcra_envpermit, EnvironmentalPermitDataType
    + rcra_stateact, StateActivityDataType
    + rcra_unvwasteact, UniversalwasteActivityDataType
    + rcra_handlerwastecode, HandlerWasteCodeDataType
  + rcra_otherid, OtherIDDataType

## Hazardous Waste Permit Submission (PM)

Root Class: HazardouseWastePermitDataType
Root Table: rcra_hzrdwastepermit

+ rcra_permitfacsub, PermitFacilitySubmissionDataType
  + rcra_permitseries, PermitSeriesDataType
    + rcra_permitevent, PermitEventDataType
      + rcra_eventcommit, EventCommitmentDataType
  + rcra_permitunit, PermitUnitDataType
    + rcra_permitunitdetail, PermitUnitDetailDataType
      + rcra_permitrelevent, PermitRelatedEventDataType
      + rcra_handlerwastecode, HandlerWasteCodeDataType
      
# Notes

The rcra_handlerwastecode table is populated by both the HD and PM functions.
After running an HD and then a PM, we see duplicate rows in this table.

The rcra_eventcommit table is populated by both the CA and PM functions. After
running a CA and then a PM, we see duplicate data in this table.

A mapping of Hanlder IDs to the actual Handler record can be generated with the
following query:

  select * from rcra_facsub, rcra_handler
  where rcra_facsub.id = rcra_handler.facsubid

