create sequence SEQ_RCRA_CA_AREA
/

create sequence SEQ_RCRA_CA_AREA_REL_EVENT
/

create sequence SEQ_RCRA_CA_AUTHORITY
/

create sequence SEQ_RCRA_CA_AUTH_REL_EVENT
/

create sequence SEQ_RCRA_CA_EVENT
/

create sequence SEQ_RCRA_CA_EVENT_COMMITMENT
/

create sequence SEQ_RCRA_CA_FAC_SUBM
/

create sequence SEQ_RCRA_CA_REL_PERMIT_UNIT
/

create sequence SEQ_RCRA_CA_STATUTORY_CITATION
/

create sequence SEQ_RCRA_CME_CITATION
/

create sequence SEQ_RCRA_CME_CSNY_DATE
/

create sequence SEQ_RCRA_CME_ENFRC_ACT
/

create sequence SEQ_RCRA_CME_EVAL
/

create sequence SEQ_RCRA_CME_EVAL_COMMIT
/

create sequence SEQ_RCRA_CME_EVAL_VIOL
/

create sequence SEQ_RCRA_CME_FAC_SUBM
/

create sequence SEQ_RCRA_CME_MEDIA
/

create sequence SEQ_RCRA_CME_MILESTONE
/

create sequence SEQ_RCRA_CME_PNLTY
/

create sequence SEQ_RCRA_CME_PYMT
/

create sequence SEQ_RCRA_CME_RQST
/

create sequence SEQ_RCRA_CME_SUPP_ENVR_PRJT
/

create sequence SEQ_RCRA_CME_VIOL
/

create sequence SEQ_RCRA_CME_VIOL_ENFRC
/

create sequence SEQ_RCRA_FA_COST_EST
/

create sequence SEQ_RCRA_FA_COST_EST_REL_MECH
/

create sequence SEQ_RCRA_FA_FAC_SUBM
/

create sequence SEQ_RCRA_FA_MECHANISM
/

create sequence SEQ_RCRA_FA_MECHANISM_DETAIL
/

create sequence SEQ_RCRA_GIS_FAC_SUBM
/

create sequence SEQ_RCRA_GIS_GEO_INFORMATION
/

create sequence SEQ_RCRA_HD_CERTIFICATION
/

create sequence SEQ_RCRA_HD_ENV_PERMIT
/

create sequence SEQ_RCRA_HD_HANDLER
/

create sequence SEQ_RCRA_HD_HBASIC
/

create sequence SEQ_RCRA_HD_NAICS
/

create sequence SEQ_RCRA_HD_OTHER_ID
/

create sequence SEQ_RCRA_HD_OWNEROP
/

create sequence SEQ_RCRA_HD_SEC_MATERIAL_ACT
/

create sequence SEQ_RCRA_HD_SEC_WASTE_CODE
/

create sequence SEQ_RCRA_HD_STATE_ACTIVITY
/

create sequence SEQ_RCRA_HD_UNIVERSAL_WASTE
/

create sequence SEQ_RCRA_HD_WASTE_CODE
/

create sequence SEQ_RCRA_PRM_EVENT
/

create sequence SEQ_RCRA_PRM_EVENT_COMMITMENT
/

create sequence SEQ_RCRA_PRM_FAC_SUBM
/

create sequence SEQ_RCRA_PRM_RELATED_EVENT
/

create sequence SEQ_RCRA_PRM_SERIES
/

create sequence SEQ_RCRA_PRM_UNIT
/

create sequence SEQ_RCRA_PRM_UNIT_DETAIL
/

create sequence SEQ_RCRA_PRM_WASTE_CODE
/

create sequence SEQ_RCRA_SUBMISSIONHISTORY
/

create sequence SEQ_RCRA_RU_REPORT_UNIV
/

create sequence SEQ_RCRA_HD_LQG_CLOSURE
/

create sequence SEQ_RCRA_HD_LQG_CONSOLIDATION
/

create sequence SEQ_RCRA_HD_EPISODIC_EVENT
/

create sequence SEQ_RCRA_HD_EPISODIC_WASTE
/

create sequence SEQ_RCRA_HD_EPISODIC_WASTE_CD
/

create sequence SEQ_ETL_RUN
/

create sequence SEQ_RCRA_EM_SUBM
/

create sequence SEQ_RCRA_EM_EMANIFEST
/

create sequence SEQ_RCRA_EM_EMANIFEST_COMMENT
/

create sequence SEQ_RCRA_EM_WASTE
/

create sequence SEQ_RCRA_EM_WASTE_CD_GEN
/

create sequence SEQ_RCRA_EM_WASTE_CD_TRANS
/

create sequence SEQ_RCRA_EM_WASTE_COMMENT
/

create sequence SEQ_RCRA_EM_WASTE_PCB
/

create sequence SEQ_RCRA_PRM_MOD_EVENT
/

create sequence SEQ_RCRA_HD_EPISODIC_PRJT
/

create sequence SEQ_RCRA_EM_TRANSPORTER
/

create sequence SEQ_EM_FED_WASTE_CODE_DESC_ID
/

create sequence SEQ_EM_STATE_WASTE_CODE_DESC
/

create table RCRA_CA_FAC_SUBM
(
    CA_FAC_SUBM_ID NUMBER(10)   not null
        constraint PK_CA_FAC_SUBM
            primary key,
    HANDLER_ID     VARCHAR2(12) not null
)
/

comment on table RCRA_CA_FAC_SUBM is 'Schema element: CorrectiveActionFacilitySubmissionDataType'
/

comment on column RCRA_CA_FAC_SUBM.CA_FAC_SUBM_ID is 'Parent: Supplies all of the relevant Corrective Action Data for a given Handler (_PK)'
/

comment on column RCRA_CA_FAC_SUBM.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

create table RCRA_CA_AREA
(
    CA_AREA_ID                     NUMBER(10) not null
        constraint PK_CA_AREA
            primary key,
    CA_FAC_SUBM_ID                 NUMBER(10) not null
        constraint FK_CA_ARA_CA_FC_SB
            references RCRA_CA_FAC_SUBM
                on delete cascade,
    TRANS_CODE                     CHAR,
    AREA_SEQ_NUM                   NUMBER(10) not null,
    FAC_WIDE_IND                   CHAR,
    AREA_NAME                      VARCHAR2(40),
    AIR_REL_IND                    CHAR,
    GROUNDWATER_REL_IND            CHAR,
    SOIL_REL_IND                   CHAR,
    SURFACE_WATER_REL_IND          CHAR,
    REGULATED_UNIT_IND             CHAR,
    EPA_RESP_PERSON_DATA_OWNER_CDE CHAR(2),
    EPA_RESP_PERSON_ID             VARCHAR2(5),
    STA_RESP_PERSON_DATA_OWNER_CDE CHAR(2),
    STA_RESP_PERSON_ID             VARCHAR2(5),
    SUPP_INFO_TXT                  VARCHAR2(2000),
    CREATED_BY_USERID              VARCHAR2(255),
    A_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_CA_AREA is 'Schema element: CorrectiveActionAreaDataType'
/

comment on column RCRA_CA_AREA.CA_AREA_ID is 'Parent: A list of Correction Action Areas for a particluar Handler (_PK)'
/

comment on column RCRA_CA_AREA.CA_FAC_SUBM_ID is 'Parent: A list of Correction Action Areas for a particluar Handler (_FK)'
/

comment on column RCRA_CA_AREA.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_AREA.AREA_SEQ_NUM is 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)'
/

comment on column RCRA_CA_AREA.FAC_WIDE_IND is 'Indicates that the corrective action applies to the entire facility. (FacilityWideIndicator)'
/

comment on column RCRA_CA_AREA.AREA_NAME is 'The name of the Corrective Action area. (AreaName)'
/

comment on column RCRA_CA_AREA.AIR_REL_IND is 'Indicates that there has been a release to air (either within or beyond the facility boundary) from the unit/area. This may include releases of subsurface gas. (AirReleaseIndicator)'
/

comment on column RCRA_CA_AREA.GROUNDWATER_REL_IND is 'Indicates that there has been a release to groundwater from the unit/area. (GroundwaterReleaseIndicator)'
/

comment on column RCRA_CA_AREA.SOIL_REL_IND is 'Indicates that there has been a release to soil (either within or beyond the facility boundary) from the unit/area. This may include subsoil contamination beneath the unit/area. (SoilReleaseIndicator)'
/

comment on column RCRA_CA_AREA.SURFACE_WATER_REL_IND is 'Indicates that there has been a release to surface water (either within or beyond the facility boundary) from the unit/area. (SurfaceWaterReleaseIndicator)'
/

comment on column RCRA_CA_AREA.REGULATED_UNIT_IND is 'Indicates that the corrective action applies to a regulated unit. (RegulatedUnitIndicator)'
/

comment on column RCRA_CA_AREA.EPA_RESP_PERSON_DATA_OWNER_CDE is 'Indicates the agency that defines the person identifier. (EPAResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_CA_AREA.EPA_RESP_PERSON_ID is 'The person currently responsible for the permit at the EPA level. (EPAResponsiblePersonID)'
/

comment on column RCRA_CA_AREA.STA_RESP_PERSON_DATA_OWNER_CDE is 'Indicates the agency that defines the person identifier. (StateResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_CA_AREA.STA_RESP_PERSON_ID is 'The state person currently responsible for overseeing the corrective action area. (StateResponsiblePersonID)'
/

comment on column RCRA_CA_AREA.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_CA_AREA.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CA_AREA.A_CREATED_DATE is 'Creation Date (ACreatedDate)'
/

comment on column RCRA_CA_AREA.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_CA_AR_CA_FC_SB
    on RCRA_CA_AREA (CA_FAC_SUBM_ID)
/

create table RCRA_CA_AREA_REL_EVENT
(
    CA_AREA_REL_EVENT_ID           NUMBER(10)  not null
        constraint PK_CA_AREA_RL_EVNT
            primary key,
    CA_AREA_ID                     NUMBER(10)  not null
        constraint FK_CA_AR_RL_EV_CA
            references RCRA_CA_AREA
                on delete cascade,
    TRANS_CODE                     CHAR,
    ACT_LOC_CODE                   CHAR(2)     not null,
    CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2)     not null,
    CORCT_ACT_EVENT_CODE           VARCHAR2(7) not null,
    EVENT_AGN_CODE                 CHAR        not null,
    EVENT_SEQ_NUM                  NUMBER(10)  not null
)
/

comment on table RCRA_CA_AREA_REL_EVENT is 'Schema element: CorrectiveActionAreaRelatedEventDataType'
/

comment on column RCRA_CA_AREA_REL_EVENT.CA_AREA_REL_EVENT_ID is 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)'
/

comment on column RCRA_CA_AREA_REL_EVENT.CA_AREA_ID is 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)'
/

comment on column RCRA_CA_AREA_REL_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_AREA_REL_EVENT.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_CA_AREA_REL_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE is 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)'
/

comment on column RCRA_CA_AREA_REL_EVENT.CORCT_ACT_EVENT_CODE is 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)'
/

comment on column RCRA_CA_AREA_REL_EVENT.EVENT_AGN_CODE is 'Agency responsible for the event. (EventAgencyCode)'
/

comment on column RCRA_CA_AREA_REL_EVENT.EVENT_SEQ_NUM is 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)'
/

create index IX_CA_AR_RL_EV_CA
    on RCRA_CA_AREA_REL_EVENT (CA_AREA_ID)
/

create table RCRA_CA_AUTHORITY
(
    CA_AUTHORITY_ID                NUMBER(10) not null
        constraint PK_CA_AUTHORITY
            primary key,
    CA_FAC_SUBM_ID                 NUMBER(10) not null
        constraint FK_CA_ATH_CA_FC_SB
            references RCRA_CA_FAC_SUBM
                on delete cascade,
    TRANS_CODE                     CHAR,
    ACT_LOC_CODE                   CHAR(2)    not null,
    AUTHORITY_DATA_OWNER_CODE      CHAR(2)    not null,
    AUTHORITY_TYPE_CODE            CHAR       not null,
    AUTHORITY_AGN_CODE             CHAR       not null,
    AUTHORITY_EFFC_DATE            DATE       not null,
    ISSUE_DATE                     DATE,
    END_DATE                       DATE,
    ESTABLISHED_REPOSITORY_CODE    CHAR,
    RESP_LEAD_PROG_IDEN            CHAR,
    AUTHORITY_SUBORG_DATA_OWNR_CDE CHAR(2),
    AUTHORITY_SUBORG_CODE          VARCHAR2(10),
    RESP_PERSON_DATA_OWNER_CODE    CHAR(2),
    RESP_PERSON_ID                 VARCHAR2(5),
    SUPP_INFO_TXT                  VARCHAR2(2000),
    CREATED_BY_USERID              VARCHAR2(255),
    A_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_CA_AUTHORITY is 'Schema element: CorrectiveActionAuthorityDataType'
/

comment on column RCRA_CA_AUTHORITY.CA_AUTHORITY_ID is 'Parent: A list of Correction Action Authorities for a particluar Handler (_PK)'
/

comment on column RCRA_CA_AUTHORITY.CA_FAC_SUBM_ID is 'Parent: A list of Correction Action Authorities for a particluar Handler (_FK)'
/

comment on column RCRA_CA_AUTHORITY.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_AUTHORITY.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_DATA_OWNER_CODE is 'Indicates the agency that defines the authority. (AuthorityDataOwnerCode)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_TYPE_CODE is 'A code used to indicate whether a permit, administrative order, or other authority has been issued to implement the corrective action process. (AuthorityTypeCode)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_AGN_CODE is 'Agency responsible for the Authority. (AuthorityAgencyCode)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_EFFC_DATE is 'Date that the authority became effective. (AuthorityEffectiveDate)'
/

comment on column RCRA_CA_AUTHORITY.ISSUE_DATE is 'Date the authorized agency official signs the order, permit, or permit modification. (IssueDate)'
/

comment on column RCRA_CA_AUTHORITY.END_DATE is 'The date when the corrective action authority is revoked or ended. (EndDate)'
/

comment on column RCRA_CA_AUTHORITY.ESTABLISHED_REPOSITORY_CODE is 'The action by which the Director requires the owner/operator to establish and maintain an information repository at a location near the facility for the purpose of making accessible to interested parties documents, reports, and other public information relevant to public understanding of the activities, findings, and plans for such corrective action initiatives. (EstablishedRepositoryCode)'
/

comment on column RCRA_CA_AUTHORITY.RESP_LEAD_PROG_IDEN is 'Code indicating the program in which the organization establishes the applicable guidance that the authority should be issued. (ResponsibleLeadProgramIdentifier)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_SUBORG_DATA_OWNR_CDE is 'Authority responsible suborganization owner. (AuthoritySuborganizationDataOwnerCode)'
/

comment on column RCRA_CA_AUTHORITY.AUTHORITY_SUBORG_CODE is 'Authority responsible suborganization. (AuthoritySuborganizationCode)'
/

comment on column RCRA_CA_AUTHORITY.RESP_PERSON_DATA_OWNER_CODE is 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_CA_AUTHORITY.RESP_PERSON_ID is 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)'
/

comment on column RCRA_CA_AUTHORITY.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_CA_AUTHORITY.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CA_AUTHORITY.A_CREATED_DATE is 'Creation Date (ACreatedDate)'
/

comment on column RCRA_CA_AUTHORITY.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_CA_AT_CA_FC_SB
    on RCRA_CA_AUTHORITY (CA_FAC_SUBM_ID)
/

create table RCRA_CA_AUTH_REL_EVENT
(
    CA_AUTH_REL_EVENT_ID           NUMBER(10)  not null
        constraint PK_CA_AUTH_RL_EVNT
            primary key,
    CA_AUTHORITY_ID                NUMBER(10)  not null
        constraint FK_CA_AT_RL_EV_CA
            references RCRA_CA_AUTHORITY
                on delete cascade,
    TRANS_CODE                     CHAR,
    ACT_LOC_CODE                   CHAR(2)     not null,
    CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2)     not null,
    CORCT_ACT_EVENT_CODE           VARCHAR2(7) not null,
    EVENT_AGN_CODE                 CHAR        not null,
    EVENT_SEQ_NUM                  NUMBER(10)  not null
)
/

comment on table RCRA_CA_AUTH_REL_EVENT is 'Schema element: CorrectiveActionAuthorityRelatedEventDataType'
/

comment on column RCRA_CA_AUTH_REL_EVENT.CA_AUTH_REL_EVENT_ID is 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_PK)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.CA_AUTHORITY_ID is 'Parent: Linking Data for Corrective Action Areas and Events or Authorities and Events (_FK)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE is 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.CORCT_ACT_EVENT_CODE is 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.EVENT_AGN_CODE is 'Agency responsible for the event. (EventAgencyCode)'
/

comment on column RCRA_CA_AUTH_REL_EVENT.EVENT_SEQ_NUM is 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)'
/

create index IX_CA_AT_RL_EV_CA
    on RCRA_CA_AUTH_REL_EVENT (CA_AUTHORITY_ID)
/

create table RCRA_CA_EVENT
(
    CA_EVENT_ID                    NUMBER(10)  not null
        constraint PK_CA_EVENT
            primary key,
    CA_FAC_SUBM_ID                 NUMBER(10)  not null
        constraint FK_CA_EVN_CA_FC_SB
            references RCRA_CA_FAC_SUBM
                on delete cascade,
    TRANS_CODE                     CHAR,
    ACT_LOC_CODE                   CHAR(2)     not null,
    CORCT_ACT_EVENT_DATA_OWNER_CDE CHAR(2)     not null,
    CORCT_ACT_EVENT_CODE           VARCHAR2(7) not null,
    EVENT_AGN_CODE                 CHAR        not null,
    EVENT_SEQ_NUM                  NUMBER(10)  not null,
    ACTL_DATE                      DATE,
    ORIGINAL_SCHEDULE_DATE         DATE,
    NEW_SCHEDULE_DATE              DATE,
    EVENT_SUBORG_DATA_OWNER_CODE   CHAR(2),
    EVENT_SUBORG_CODE              VARCHAR2(10),
    RESP_PERSON_DATA_OWNER_CODE    CHAR(2),
    RESP_PERSON_ID                 VARCHAR2(5),
    SUPP_INFO_TXT                  VARCHAR2(2000),
    PUBLIC_SUPP_INFO_TXT           VARCHAR2(4000),
    CREATED_BY_USERID              VARCHAR2(255),
    A_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_CA_EVENT is 'Schema element: CorrectiveActionEventDataType'
/

comment on column RCRA_CA_EVENT.CA_EVENT_ID is 'Parent: A list of Correction Action Events for a particluar Handler (_PK)'
/

comment on column RCRA_CA_EVENT.CA_FAC_SUBM_ID is 'Parent: A list of Correction Action Events for a particluar Handler (_FK)'
/

comment on column RCRA_CA_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_EVENT.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_CA_EVENT.CORCT_ACT_EVENT_DATA_OWNER_CDE is 'Indicates the agency that defines the corrective action event. (CorrectiveActionEventDataOwnerCode)'
/

comment on column RCRA_CA_EVENT.CORCT_ACT_EVENT_CODE is 'A code which corresponds to a specific event or event type. The first two characters indicate the event category and the last three characters the numeric event number. (CorrectiveActionEventCode)'
/

comment on column RCRA_CA_EVENT.EVENT_AGN_CODE is 'Agency responsible for the event. (EventAgencyCode)'
/

comment on column RCRA_CA_EVENT.EVENT_SEQ_NUM is 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)'
/

comment on column RCRA_CA_EVENT.ACTL_DATE is 'Date on which actual completion of an event occurs. (ActualDate)'
/

comment on column RCRA_CA_EVENT.ORIGINAL_SCHEDULE_DATE is 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)'
/

comment on column RCRA_CA_EVENT.NEW_SCHEDULE_DATE is 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)'
/

comment on column RCRA_CA_EVENT.EVENT_SUBORG_DATA_OWNER_CODE is 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)'
/

comment on column RCRA_CA_EVENT.EVENT_SUBORG_CODE is 'Event responsible suborganization. (EventSuborganizationCode)'
/

comment on column RCRA_CA_EVENT.RESP_PERSON_DATA_OWNER_CODE is 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_CA_EVENT.RESP_PERSON_ID is 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)'
/

comment on column RCRA_CA_EVENT.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_CA_EVENT.PUBLIC_SUPP_INFO_TXT is 'Public notes providing more information (PublicSupplementalInformationText)'
/

comment on column RCRA_CA_EVENT.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CA_EVENT.A_CREATED_DATE is 'Creation Date (ACreatedDate)'
/

comment on column RCRA_CA_EVENT.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_CA_EV_CA_FC_SB
    on RCRA_CA_EVENT (CA_FAC_SUBM_ID)
/

create table RCRA_CA_EVENT_COMMITMENT
(
    CA_EVENT_COMMITMENT_ID NUMBER(10) not null
        constraint PK_CA_EVNT_CMMTMNT
            primary key,
    CA_EVENT_ID            NUMBER(10) not null
        constraint FK_CA_EVN_CM_CA_EV
            references RCRA_CA_EVENT
                on delete cascade,
    TRANS_CODE             CHAR,
    COMMIT_LEAD            CHAR(2)    not null,
    COMMIT_SEQ_NUM         NUMBER(10) not null
)
/

comment on table RCRA_CA_EVENT_COMMITMENT is 'Schema element: EventEventCommitmentDataType'
/

comment on column RCRA_CA_EVENT_COMMITMENT.CA_EVENT_COMMITMENT_ID is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)'
/

comment on column RCRA_CA_EVENT_COMMITMENT.CA_EVENT_ID is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)'
/

comment on column RCRA_CA_EVENT_COMMITMENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_EVENT_COMMITMENT.COMMIT_LEAD is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)'
/

comment on column RCRA_CA_EVENT_COMMITMENT.COMMIT_SEQ_NUM is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)'
/

create index IX_CA_EV_CM_CA_EV
    on RCRA_CA_EVENT_COMMITMENT (CA_EVENT_ID)
/

create table RCRA_CA_REL_PERMIT_UNIT
(
    CA_REL_PERMIT_UNIT_ID NUMBER(10) not null
        constraint PK_CA_RL_PRMIT_UNT
            primary key,
    CA_AREA_ID            NUMBER(10) not null
        constraint FK_CA_RL_PR_UN_CA
            references RCRA_CA_AREA
                on delete cascade,
    TRANS_CODE            CHAR,
    PERMIT_UNIT_SEQ_NUM   NUMBER(10) not null
)
/

comment on table RCRA_CA_REL_PERMIT_UNIT is 'Schema element: CorrectiveActionRelatedPermitUnitDataType'
/

comment on column RCRA_CA_REL_PERMIT_UNIT.CA_REL_PERMIT_UNIT_ID is 'Parent: A permitted unit related to a corrective action area. (_PK)'
/

comment on column RCRA_CA_REL_PERMIT_UNIT.CA_AREA_ID is 'Parent: A permitted unit related to a corrective action area. (_FK)'
/

comment on column RCRA_CA_REL_PERMIT_UNIT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_REL_PERMIT_UNIT.PERMIT_UNIT_SEQ_NUM is 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)'
/

create index IX_CA_RL_PR_UN_CA
    on RCRA_CA_REL_PERMIT_UNIT (CA_AREA_ID)
/

create table RCRA_CA_STATUTORY_CITATION
(
    CA_STATUTORY_CITATION_ID       NUMBER(10) not null
        constraint PK_CA_STTTRY_CTTON
            primary key,
    CA_AUTHORITY_ID                NUMBER(10) not null
        constraint FK_CA_STT_CT_CA_AT
            references RCRA_CA_AUTHORITY
                on delete cascade,
    TRANS_CODE                     CHAR,
    STATUTORY_CITTION_DTA_OWNR_CDE CHAR(2)    not null,
    STATUTORY_CITATION_IDEN        CHAR       not null
)
/

comment on table RCRA_CA_STATUTORY_CITATION is 'Schema element: CorrectiveActionStatutoryCitationDataType'
/

comment on column RCRA_CA_STATUTORY_CITATION.CA_STATUTORY_CITATION_ID is 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_PK)'
/

comment on column RCRA_CA_STATUTORY_CITATION.CA_AUTHORITY_ID is 'Parent: Linking Data for Corrective Action Authorities and Statutory Citations (_FK)'
/

comment on column RCRA_CA_STATUTORY_CITATION.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CA_STATUTORY_CITATION.STATUTORY_CITTION_DTA_OWNR_CDE is 'Orgnaization responsible for the Statutory Citation (use two-digit postal code) (StatutoryCitationDataOwnerCode)'
/

comment on column RCRA_CA_STATUTORY_CITATION.STATUTORY_CITATION_IDEN is 'Identifier that identifies the statutory authority under which the corrective action event occured (StatutoryCitationIdentifier)'
/

create index IX_CA_ST_CT_CA_AT
    on RCRA_CA_STATUTORY_CITATION (CA_AUTHORITY_ID)
/

create table RCRA_CME_FAC_SUBM
(
    CME_FAC_SUBM_ID NUMBER(10) not null
        constraint PK_CME_FAC_SUBM
            primary key,
    EPA_HDLR_ID     CHAR(12)   not null
)
/

comment on table RCRA_CME_FAC_SUBM is 'Schema element: CMEFacilitySubmissionDataType'
/

comment on column RCRA_CME_FAC_SUBM.CME_FAC_SUBM_ID is 'Parent: This contains Hbasic Data (_PK)'
/

comment on column RCRA_CME_FAC_SUBM.EPA_HDLR_ID is 'Number that uniquely identifies the EPA handler. (EPAHandlerID)'
/

create table RCRA_CME_ENFRC_ACT
(
    CME_ENFRC_ACT_ID              NUMBER(10)  not null
        constraint PK_CME_ENFRC_ACT
            primary key,
    CME_FAC_SUBM_ID               NUMBER(10)  not null
        constraint FK_CM_EN_AC_CM_FC
            references RCRA_CME_FAC_SUBM
                on delete cascade,
    TRANS_CODE                    CHAR,
    ENFRC_AGN_LOC_NAME            CHAR(2)     not null,
    ENFRC_ACT_IDEN                VARCHAR2(3) not null,
    ENFRC_ACT_DATE                DATE        not null,
    ENFRC_AGN_NAME                CHAR        not null,
    ENFRC_DOCKET_NUM              VARCHAR2(15),
    ENFRC_ATTRY                   VARCHAR2(5),
    CORCT_ACT_COMPT               CHAR,
    CNST_AGMT_FINAL_ORDER_SEQ_NUM NUMBER(10),
    APPEAL_INIT_DATE              DATE,
    APPEAL_RSLN_DATE              DATE,
    DISP_STAT_DATE                DATE,
    DISP_STAT_OWNER               CHAR(2),
    DISP_STAT                     CHAR(2),
    ENFRC_OWNER                   CHAR(2),
    ENFRC_TYPE                    CHAR(3),
    ENFRC_RESP_PERSON_OWNER       CHAR(2),
    ENFRC_RESP_PERSON_IDEN        VARCHAR2(5),
    ENFRC_RESP_SUBORG_OWNER       CHAR(2),
    ENFRC_RESP_SUBORG             VARCHAR2(10),
    NOTES                         VARCHAR2(4000),
    FA_REQUIRED                   CHAR,
    CREATED_BY_USERID             VARCHAR2(255),
    C_CREATED_DATE                TIMESTAMP(6),
    DATA_ORIG                     CHAR(2),
    LAST_UPDT_BY                  VARCHAR2(255),
    LAST_UPDT_DATE                DATE
)
/

comment on table RCRA_CME_ENFRC_ACT is 'Schema element: EnforcementActionDataType'
/

comment on column RCRA_CME_ENFRC_ACT.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enforcement Data (_PK)'
/

comment on column RCRA_CME_ENFRC_ACT.CME_FAC_SUBM_ID is 'Parent: Compliance Monitoring and Enforcement Data (_FK)'
/

comment on column RCRA_CME_ENFRC_ACT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_AGN_LOC_NAME is 'The U.S.Postal Service alphabetic code that represents the U.S.State or territory in which a state or local government enforcement agency operates. (EnforcementAgencyLocationName)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_ACT_IDEN is 'The unique alphanumeric identifier used in the applicable database to identify a specific enforcement action pertaining to a regulated entity or facility. (EnforcementActionIdentifier)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_ACT_DATE is 'The calendar date the enforcement action was issued or filed. (EnforcementActionDate)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_AGN_NAME is 'The full name of the agency, department, or organization that submitted the enforcement action data to EPA. (EnforcementAgencyName)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_DOCKET_NUM is 'Notes the relevant docket number which enforcement staff have assigned for tracking of enforcement actions. (EnforcementDocketNumber)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_ATTRY is 'Identifies the attorney within the agency responsible for issuing the enforcement action. (EnforcementAttorney)'
/

comment on column RCRA_CME_ENFRC_ACT.CORCT_ACT_COMPT is 'Parent: Compliance Monitoring and Enforcement Data (CorrectiveActionComponent)'
/

comment on column RCRA_CME_ENFRC_ACT.CNST_AGMT_FINAL_ORDER_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Data (ConsentAgreementFinalOrderSequenceNumber)'
/

comment on column RCRA_CME_ENFRC_ACT.APPEAL_INIT_DATE is 'Parent: Compliance Monitoring and Enforcement Data (AppealInitiatedDate)'
/

comment on column RCRA_CME_ENFRC_ACT.APPEAL_RSLN_DATE is 'Parent: Compliance Monitoring and Enforcement Data (AppealResolutionDate)'
/

comment on column RCRA_CME_ENFRC_ACT.DISP_STAT_DATE is 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusDate)'
/

comment on column RCRA_CME_ENFRC_ACT.DISP_STAT_OWNER is 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatusOwner)'
/

comment on column RCRA_CME_ENFRC_ACT.DISP_STAT is 'Parent: Compliance Monitoring and Enforcement Data (DispositionStatus)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_OWNER is 'State Postal Code (EnforcementOwner)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_TYPE is 'A code that identifies the type of action being taken against a handler. (EnforcementType)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_RESP_PERSON_OWNER is 'Indicates the agency that defines the person identifier. (EnforcementResponsiblePersonOwner)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_RESP_PERSON_IDEN is 'Code indicating the person within the agency responsible for conducting the enforcement. (EnforcementResponsiblePersonIdentifier)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_RESP_SUBORG_OWNER is 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganizationOwner)'
/

comment on column RCRA_CME_ENFRC_ACT.ENFRC_RESP_SUBORG is 'Parent: Compliance Monitoring and Enforcement Data (EnforcementResponsibleSuborganization)'
/

comment on column RCRA_CME_ENFRC_ACT.NOTES is 'Parent: Compliance Monitoring and Enforcement Data (Notes)'
/

comment on column RCRA_CME_ENFRC_ACT.FA_REQUIRED is 'Whether financial responsibility is required. (FinancialAssuranceReqD)'
/

comment on column RCRA_CME_ENFRC_ACT.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CME_ENFRC_ACT.C_CREATED_DATE is 'Creation Date (CCreatedDate)'
/

comment on column RCRA_CME_ENFRC_ACT.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_CM_EN_AC_CM_FC
    on RCRA_CME_ENFRC_ACT (CME_FAC_SUBM_ID)
/

create table RCRA_CME_CSNY_DATE
(
    CME_CSNY_DATE_ID NUMBER(10) not null
        constraint PK_CME_CSNY_DATE
            primary key,
    CME_ENFRC_ACT_ID NUMBER(10) not null
        constraint FK_CM_CS_DT_CM_EN
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE       CHAR,
    SNY_DATE         DATE       not null
)
/

comment on table RCRA_CME_CSNY_DATE is 'Schema element: CSNYDateDataType'
/

comment on column RCRA_CME_CSNY_DATE.CME_CSNY_DATE_ID is 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_PK)'
/

comment on column RCRA_CME_CSNY_DATE.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enforcement Significant Non-Complier Date Data (_FK)'
/

comment on column RCRA_CME_CSNY_DATE.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_CSNY_DATE.SNY_DATE is 'Date of the SNY that the Action is Addressing (SNYDate)'
/

create index IX_CM_CS_DT_CM_EN
    on RCRA_CME_CSNY_DATE (CME_ENFRC_ACT_ID)
/

create table RCRA_CME_EVAL
(
    CME_EVAL_ID                 NUMBER(10)  not null
        constraint PK_CME_EVAL
            primary key,
    CME_FAC_SUBM_ID             NUMBER(10)  not null
        constraint FK_CME_EV_CM_FC_SB
            references RCRA_CME_FAC_SUBM
                on delete cascade,
    TRANS_CODE                  CHAR,
    EVAL_ACT_LOC                CHAR(2)     not null,
    EVAL_IDEN                   VARCHAR2(3) not null,
    EVAL_START_DATE             DATE        not null,
    EVAL_RESP_AGN               CHAR        not null,
    DAY_ZERO                    DATE,
    FOUND_VIOL                  CHAR,
    CTZN_CPLT_IND               CHAR,
    MULTIMEDIA_IND              CHAR,
    SAMPL_IND                   CHAR,
    NOT_SUBTL_C_IND             CHAR,
    EVAL_TYPE_OWNER             CHAR(2),
    EVAL_TYPE                   VARCHAR2(3),
    FOCUS_AREA_OWNER            CHAR(2),
    FOCUS_AREA                  VARCHAR2(3),
    EVAL_RESP_PERSON_IDEN_OWNER CHAR(2),
    EVAL_RESP_PERSON_IDEN       VARCHAR2(5),
    EVAL_RESP_SUBORG_OWNER      CHAR(2),
    EVAL_RESP_SUBORG            VARCHAR2(10),
    NOTES                       VARCHAR2(4000),
    NOC_DATE                    DATE,
    CREATED_BY_USERID           VARCHAR2(255),
    C_CREATED_DATE              TIMESTAMP(6),
    DATA_ORIG                   CHAR(2),
    LAST_UPDT_BY                VARCHAR2(255),
    LAST_UPDT_DATE              DATE
)
/

comment on table RCRA_CME_EVAL is 'Schema element: EvaluationDataType'
/

comment on column RCRA_CME_EVAL.CME_EVAL_ID is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_PK)'
/

comment on column RCRA_CME_EVAL.CME_FAC_SUBM_ID is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (_FK)'
/

comment on column RCRA_CME_EVAL.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_EVAL.EVAL_ACT_LOC is 'Indicates the location of the agency regulating the EPA handler. (EvaluationActivityLocation)'
/

comment on column RCRA_CME_EVAL.EVAL_IDEN is 'Name or number assigned by the implementing agency to identify an evaluation. (EvaluationIdentifier)'
/

comment on column RCRA_CME_EVAL.EVAL_START_DATE is 'The first day of the inspection or record review regardless of the duration of the inspection. (EvaluationStartDate)'
/

comment on column RCRA_CME_EVAL.EVAL_RESP_AGN is 'Code indicating the agency responsible for conducting the evaluation. (EvaluationResponsibleAgency)'
/

comment on column RCRA_CME_EVAL.DAY_ZERO is 'Date fo the Last Non-Followup Evaluation (Applies to SNY/SNN Evaluations Only) (DayZero)'
/

comment on column RCRA_CME_EVAL.FOUND_VIOL is 'Flag indicating if a violation was found. (FoundViolation)'
/

comment on column RCRA_CME_EVAL.CTZN_CPLT_IND is 'The inspection or record review was initiated because of a tip/complaint (CitizenComplaintIndicator)'
/

comment on column RCRA_CME_EVAL.MULTIMEDIA_IND is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (MultimediaIndicator)'
/

comment on column RCRA_CME_EVAL.SAMPL_IND is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (SamplingIndicator)'
/

comment on column RCRA_CME_EVAL.NOT_SUBTL_C_IND is 'The inspection conducted pursuant to RCRA 3007 or State equivalent; determiniation made: sit is Non-Hazardous Waste. (NotSubtitleCIndicator)'
/

comment on column RCRA_CME_EVAL.EVAL_TYPE_OWNER is 'Indicates the agency that defines the type of evaluation. (EvaluationTypeOwner)'
/

comment on column RCRA_CME_EVAL.EVAL_TYPE is 'Code to report the type of evaluation conducted at the handler. (EvaluationType)'
/

comment on column RCRA_CME_EVAL.FOCUS_AREA_OWNER is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusAreaOwner)'
/

comment on column RCRA_CME_EVAL.FOCUS_AREA is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (FocusArea)'
/

comment on column RCRA_CME_EVAL.EVAL_RESP_PERSON_IDEN_OWNER is 'Indicates the agency that defines the person identifier. (EvaluationResponsiblePersonIdentifierOwner)'
/

comment on column RCRA_CME_EVAL.EVAL_RESP_PERSON_IDEN is 'Code indicating the person within the agency responsible for conducting the evaluation. (EvaluationResponsiblePersonIdentifier)'
/

comment on column RCRA_CME_EVAL.EVAL_RESP_SUBORG_OWNER is 'Indicates the agency that defines the suborganization identifier. (EvaluationResponsibleSuborganizationOwner)'
/

comment on column RCRA_CME_EVAL.EVAL_RESP_SUBORG is 'Code indicating the branch/district within the agency responsible for conducting the evaluation. (EvaluationResponsibleSuborganization)'
/

comment on column RCRA_CME_EVAL.NOTES is 'Parent: Compliance Monitoring and Enforcement Evaluation Data (Notes)'
/

comment on column RCRA_CME_EVAL.NOC_DATE is 'NOC Date. (NOCDate)'
/

comment on column RCRA_CME_EVAL.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CME_EVAL.C_CREATED_DATE is 'Creation Date (CCreatedDate)'
/

comment on column RCRA_CME_EVAL.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_CM_EV_CM_FC_SB
    on RCRA_CME_EVAL (CME_FAC_SUBM_ID)
/

create table RCRA_CME_EVAL_COMMIT
(
    CME_EVAL_COMMIT_ID NUMBER(10) not null
        constraint PK_CME_EVAL_COMMIT
            primary key,
    CME_EVAL_ID        NUMBER(10) not null
        constraint FK_CME_EV_CM_CM_EV
            references RCRA_CME_EVAL
                on delete cascade,
    TRANS_CODE         CHAR,
    COMMIT_LEAD        CHAR(2)    not null,
    COMMIT_SEQ_NUM     NUMBER(10) not null
)
/

comment on table RCRA_CME_EVAL_COMMIT is 'Schema element: EvaluationCommitmentDataType'
/

comment on column RCRA_CME_EVAL_COMMIT.CME_EVAL_COMMIT_ID is 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_PK)'
/

comment on column RCRA_CME_EVAL_COMMIT.CME_EVAL_ID is 'Parent: Linking Data for Commitment/Initiative and Evaluation. (_FK)'
/

comment on column RCRA_CME_EVAL_COMMIT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_EVAL_COMMIT.COMMIT_LEAD is 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentLead)'
/

comment on column RCRA_CME_EVAL_COMMIT.COMMIT_SEQ_NUM is 'Parent: Linking Data for Commitment/Initiative and Evaluation. (CommitmentSequenceNumber)'
/

create index IX_CM_EV_CM_CM_EV
    on RCRA_CME_EVAL_COMMIT (CME_EVAL_ID)
/

create table RCRA_CME_EVAL_VIOL
(
    CME_EVAL_VIOL_ID    NUMBER(10) not null
        constraint PK_CME_EVAL_VIOL
            primary key,
    CME_EVAL_ID         NUMBER(10) not null
        constraint FK_CME_EV_VL_CM_EV
            references RCRA_CME_EVAL
                on delete cascade,
    TRANS_CODE          CHAR,
    VIOL_ACT_LOC        CHAR(2)    not null,
    VIOL_SEQ_NUM        NUMBER(10) not null,
    AGN_WHICH_DTRM_VIOL CHAR       not null
)
/

comment on table RCRA_CME_EVAL_VIOL is 'Schema element: EvaluationViolationDataType'
/

comment on column RCRA_CME_EVAL_VIOL.CME_EVAL_VIOL_ID is 'Parent: Linking Data for Evaluation and Violation (_PK)'
/

comment on column RCRA_CME_EVAL_VIOL.CME_EVAL_ID is 'Parent: Linking Data for Evaluation and Violation (_FK)'
/

comment on column RCRA_CME_EVAL_VIOL.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_EVAL_VIOL.VIOL_ACT_LOC is 'Parent: Linking Data for Evaluation and Violation (ViolationActivityLocation)'
/

comment on column RCRA_CME_EVAL_VIOL.VIOL_SEQ_NUM is 'Parent: Linking Data for Evaluation and Violation (ViolationSequenceNumber)'
/

comment on column RCRA_CME_EVAL_VIOL.AGN_WHICH_DTRM_VIOL is 'Parent: Linking Data for Evaluation and Violation (AgencyWhichDeterminedViolation)'
/

create index IX_CM_EV_VL_CM_EV
    on RCRA_CME_EVAL_VIOL (CME_EVAL_ID)
/

create table RCRA_CME_MEDIA
(
    CME_MEDIA_ID          NUMBER(10)  not null
        constraint PK_CME_MEDIA
            primary key,
    CME_ENFRC_ACT_ID      NUMBER(10)  not null
        constraint FK_CME_MD_CM_EN_AC
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE            CHAR,
    MULTIMEDIA_CODE_OWNER CHAR(2)     not null,
    MULTIMEDIA_CODE       VARCHAR2(3) not null,
    NOTES                 VARCHAR2(4000)
)
/

comment on table RCRA_CME_MEDIA is 'Schema element: MediaDataType'
/

comment on column RCRA_CME_MEDIA.CME_MEDIA_ID is 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_PK)'
/

comment on column RCRA_CME_MEDIA.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enfocement Multimedia Data (_FK)'
/

comment on column RCRA_CME_MEDIA.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_MEDIA.MULTIMEDIA_CODE_OWNER is 'Indicates the agency that defines the multimedia code. (MultimediaCodeOwner)'
/

comment on column RCRA_CME_MEDIA.MULTIMEDIA_CODE is 'Code which indicates the medium or program other than RCRA participating in the enforcement action. (MultimediaCode)'
/

comment on column RCRA_CME_MEDIA.NOTES is 'Parent: Compliance Monitoring and Enfocement Multimedia Data (Notes)'
/

create index IX_CM_MD_CM_EN_AC
    on RCRA_CME_MEDIA (CME_ENFRC_ACT_ID)
/

create table RCRA_CME_MILESTONE
(
    CME_MILESTONE_ID         NUMBER(10) not null
        constraint PK_CME_MILESTONE
            primary key,
    CME_ENFRC_ACT_ID         NUMBER(10) not null
        constraint FK_CME_ML_CM_EN_AC
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE               CHAR,
    MILESTONE_SEQ_NUM        NUMBER(10) not null,
    TECH_RQMT_IDEN           VARCHAR2(50),
    TECH_RQMT_DESC           VARCHAR2(200),
    MILESTONE_SCHD_COMP_DATE DATE,
    MILESTONE_ACTL_COMP_DATE DATE,
    MILESTONE_DFLT_DATE      DATE,
    NOTES                    VARCHAR2(4000)
)
/

comment on table RCRA_CME_MILESTONE is 'Schema element: MilestoneDataType'
/

comment on column RCRA_CME_MILESTONE.CME_MILESTONE_ID is 'Parent: Compliance Monitoring and Enforcement Milestone Data (_PK)'
/

comment on column RCRA_CME_MILESTONE.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enforcement Milestone Data (_FK)'
/

comment on column RCRA_CME_MILESTONE.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_MILESTONE.MILESTONE_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneSequenceNumber)'
/

comment on column RCRA_CME_MILESTONE.TECH_RQMT_IDEN is 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementIdentifier)'
/

comment on column RCRA_CME_MILESTONE.TECH_RQMT_DESC is 'Parent: Compliance Monitoring and Enforcement Milestone Data (TechnicalRequirementDescription)'
/

comment on column RCRA_CME_MILESTONE.MILESTONE_SCHD_COMP_DATE is 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneScheduledCompletionDate)'
/

comment on column RCRA_CME_MILESTONE.MILESTONE_ACTL_COMP_DATE is 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneActualCompletionDate)'
/

comment on column RCRA_CME_MILESTONE.MILESTONE_DFLT_DATE is 'Parent: Compliance Monitoring and Enforcement Milestone Data (MilestoneDefaultedDate)'
/

comment on column RCRA_CME_MILESTONE.NOTES is 'Parent: Compliance Monitoring and Enforcement Milestone Data (Notes)'
/

create index IX_CM_ML_CM_EN_AC
    on RCRA_CME_MILESTONE (CME_ENFRC_ACT_ID)
/

create table RCRA_CME_PNLTY
(
    CME_PNLTY_ID                   NUMBER(10)  not null
        constraint PK_CME_PNLTY
            primary key,
    CME_ENFRC_ACT_ID               NUMBER(10)  not null
        constraint FK_CME_PN_CM_EN_AC
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE                     CHAR,
    PNLTY_TYPE_OWNER               CHAR(2)     not null,
    PNLTY_TYPE                     VARCHAR2(3) not null,
    CASH_CIVIL_PNLTY_SOUGHT_AMOUNT NUMBER(13, 2),
    NOTES                          VARCHAR2(4000)
)
/

comment on table RCRA_CME_PNLTY is 'Schema element: PenaltyDataType'
/

comment on column RCRA_CME_PNLTY.CME_PNLTY_ID is 'Parent: Compliance Monitoring and Enforcement Penalty Data (_PK)'
/

comment on column RCRA_CME_PNLTY.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enforcement Penalty Data (_FK)'
/

comment on column RCRA_CME_PNLTY.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_PNLTY.PNLTY_TYPE_OWNER is 'Indicates the agency that defines the penalty type (PenaltyTypeOwner)'
/

comment on column RCRA_CME_PNLTY.PNLTY_TYPE is 'Code which indicates the type of penalty associated with the penalty amount. (PenaltyType)'
/

comment on column RCRA_CME_PNLTY.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT is 'The dollar amount of any proposed cash civil penalty set forth in a Complaint/Proposed Order. (CashCivilPenaltySoughtAmount)'
/

comment on column RCRA_CME_PNLTY.NOTES is 'Parent: Compliance Monitoring and Enforcement Penalty Data (Notes)'
/

create index IX_CM_PN_CM_EN_AC
    on RCRA_CME_PNLTY (CME_ENFRC_ACT_ID)
/

create table RCRA_CME_PYMT
(
    CME_PYMT_ID      NUMBER(10) not null
        constraint PK_CME_PYMT
            primary key,
    CME_PNLTY_ID     NUMBER(10) not null
        constraint FK_CME_PYM_CME_PNL
            references RCRA_CME_PNLTY
                on delete cascade,
    TRANS_CODE       CHAR,
    PYMT_SEQ_NUM     NUMBER(10) not null,
    PYMT_DFLT_DATE   DATE,
    SCHD_PYMT_DATE   DATE,
    SCHD_PYMT_AMOUNT NUMBER(13, 2),
    ACTL_PYMT_DATE   DATE,
    ACTL_PAID_AMOUNT NUMBER(13, 2),
    NOTES            VARCHAR2(4000)
)
/

comment on table RCRA_CME_PYMT is 'Schema element: PaymentDataType'
/

comment on column RCRA_CME_PYMT.CME_PYMT_ID is 'Parent: Compliance Monitoring and Enforcement Payment Data (_PK)'
/

comment on column RCRA_CME_PYMT.CME_PNLTY_ID is 'Parent: Compliance Monitoring and Enforcement Payment Data (_FK)'
/

comment on column RCRA_CME_PYMT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_PYMT.PYMT_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentSequenceNumber)'
/

comment on column RCRA_CME_PYMT.PYMT_DFLT_DATE is 'Parent: Compliance Monitoring and Enforcement Payment Data (PaymentDefaultedDate)'
/

comment on column RCRA_CME_PYMT.SCHD_PYMT_DATE is 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentDate)'
/

comment on column RCRA_CME_PYMT.SCHD_PYMT_AMOUNT is 'Parent: Compliance Monitoring and Enforcement Payment Data (ScheduledPaymentAmount)'
/

comment on column RCRA_CME_PYMT.ACTL_PYMT_DATE is 'Parent: Compliance Monitoring and Enforcement Payment Data (ActualPaymentDate)'
/

comment on column RCRA_CME_PYMT.ACTL_PAID_AMOUNT is 'The dollar amount of any cost recovery required to be paid pursuant to a Final Order. (ActualPaidAmount)'
/

comment on column RCRA_CME_PYMT.NOTES is 'Parent: Compliance Monitoring and Enforcement Payment Data (Notes)'
/

create index IX_CME_PY_CM_PN_ID
    on RCRA_CME_PYMT (CME_PNLTY_ID)
/

create table RCRA_CME_RQST
(
    CME_RQST_ID    NUMBER(10) not null
        constraint PK_CME_RQST
            primary key,
    CME_EVAL_ID    NUMBER(10) not null
        constraint FK_CME_RQS_CME_EVL
            references RCRA_CME_EVAL
                on delete cascade,
    TRANS_CODE     CHAR,
    RQST_SEQ_NUM   NUMBER(10) not null,
    DATE_OF_RQST   DATE,
    DATE_RESP_RCVD DATE,
    RQST_AGN       CHAR,
    NOTES          VARCHAR2(4000)
)
/

comment on table RCRA_CME_RQST is 'Schema element: RequestDataType'
/

comment on column RCRA_CME_RQST.CME_RQST_ID is 'Parent: Compliance Monitoring and Enforcement Request Data (_PK)'
/

comment on column RCRA_CME_RQST.CME_EVAL_ID is 'Parent: Compliance Monitoring and Enforcement Request Data (_FK)'
/

comment on column RCRA_CME_RQST.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_RQST.RQST_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Request Data (RequestSequenceNumber)'
/

comment on column RCRA_CME_RQST.DATE_OF_RQST is 'Parent: Compliance Monitoring and Enforcement Request Data (DateOfRequest)'
/

comment on column RCRA_CME_RQST.DATE_RESP_RCVD is 'Parent: Compliance Monitoring and Enforcement Request Data (DateResponseReceived)'
/

comment on column RCRA_CME_RQST.RQST_AGN is 'Parent: Compliance Monitoring and Enforcement Request Data (RequestAgency)'
/

comment on column RCRA_CME_RQST.NOTES is 'Parent: Compliance Monitoring and Enforcement Request Data (Notes)'
/

create index IX_CME_RQ_CM_EV_ID
    on RCRA_CME_RQST (CME_EVAL_ID)
/

create table RCRA_CME_SUPP_ENVR_PRJT
(
    CME_SUPP_ENVR_PRJT_ID NUMBER(10) not null
        constraint PK_CME_SPP_ENV_PRJ
            primary key,
    CME_ENFRC_ACT_ID      NUMBER(10) not null
        constraint FK_CM_SP_EN_PR_CM
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE            CHAR,
    SEP_SEQ_NUM           NUMBER(10) not null,
    SEP_EXPND_AMOUNT      NUMBER(13, 2),
    SEP_SCHD_COMP_DATE    DATE,
    SEP_ACTL_DATE         DATE,
    SEP_DFLT_DATE         DATE,
    SEP_CODE_OWNER        CHAR(2),
    SEP_DESC_TXT          VARCHAR2(3),
    NOTES                 VARCHAR2(4000)
)
/

comment on table RCRA_CME_SUPP_ENVR_PRJT is 'Schema element: SupplementalEnvironmentalProjectDataType'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.CME_SUPP_ENVR_PRJT_ID is 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_PK)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.CME_ENFRC_ACT_ID is 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (_FK)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_SEQ_NUM is 'SEP Sequence Number allowed value 01-99 (SEPSequenceNumber)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_EXPND_AMOUNT is 'Expenditure Amount (SEPExpenditureAmount)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_SCHD_COMP_DATE is 'Valid date greater than or equal to the Date of Enforcement Action. (SEPScheduledCompletionDate)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_ACTL_DATE is 'SEP actual completion date (SEPActualDate)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_DFLT_DATE is 'Date the SEP defaulted (SEPDefaultedDate)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_CODE_OWNER is 'State postal code (SEPCodeOwner)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.SEP_DESC_TXT is 'The narrative text describing any Supplemental Environmental Projects required to be performed pursuant to a Final Order. (SEPDescriptionText)'
/

comment on column RCRA_CME_SUPP_ENVR_PRJT.NOTES is 'Parent: Compliance Monitoring and Enforcement Supplemental Environmental Project Data (Notes)'
/

create index IX_CM_SP_EN_PR_CM
    on RCRA_CME_SUPP_ENVR_PRJT (CME_ENFRC_ACT_ID)
/

create table RCRA_CME_VIOL
(
    CME_VIOL_ID          NUMBER(10) not null
        constraint PK_CME_VIOL
            primary key,
    CME_FAC_SUBM_ID      NUMBER(10) not null
        constraint FK_CME_VL_CM_FC_SB
            references RCRA_CME_FAC_SUBM
                on delete cascade,
    TRANS_CODE           CHAR,
    VIOL_ACT_LOC         CHAR(2)    not null,
    VIOL_SEQ_NUM         NUMBER(10) not null,
    AGN_WHICH_DTRM_VIOL  CHAR       not null,
    VIOL_TYPE_OWNER      CHAR(2),
    VIOL_TYPE            VARCHAR2(10),
    FORMER_CITATION_NAME VARCHAR2(35),
    VIOL_DTRM_DATE       DATE,
    RTN_COMPL_ACTL_DATE  DATE,
    RTN_TO_COMPL_QUAL    CHAR,
    VIOL_RESP_AGN        CHAR,
    NOTES                VARCHAR2(4000),
    CREATED_BY_USERID    VARCHAR2(255),
    C_CREATED_DATE       TIMESTAMP(6),
    LAST_UPDT_BY         VARCHAR2(255),
    LAST_UPDT_DATE       DATE
)
/

comment on table RCRA_CME_VIOL is 'Schema element: ViolationDataType'
/

comment on column RCRA_CME_VIOL.CME_VIOL_ID is 'Parent: Compliance Monitoring and Enforcement Violation Data (_PK)'
/

comment on column RCRA_CME_VIOL.CME_FAC_SUBM_ID is 'Parent: Compliance Monitoring and Enforcement Violation Data (_FK)'
/

comment on column RCRA_CME_VIOL.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_VIOL.VIOL_ACT_LOC is 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationActivityLocation)'
/

comment on column RCRA_CME_VIOL.VIOL_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationSequenceNumber)'
/

comment on column RCRA_CME_VIOL.AGN_WHICH_DTRM_VIOL is 'Parent: Compliance Monitoring and Enforcement Violation Data (AgencyWhichDeterminedViolation)'
/

comment on column RCRA_CME_VIOL.VIOL_TYPE_OWNER is 'Allowed value HQ (ViolationTypeOwner)'
/

comment on column RCRA_CME_VIOL.VIOL_TYPE is 'Violation Type (ViolationType)'
/

comment on column RCRA_CME_VIOL.FORMER_CITATION_NAME is 'Parent: Compliance Monitoring and Enforcement Violation Data (FormerCitationName)'
/

comment on column RCRA_CME_VIOL.VIOL_DTRM_DATE is 'The calendar date the Responsible Authority determines that a regulated entity is in violation of a legally enforceable obligation. (ViolationDeterminedDate)'
/

comment on column RCRA_CME_VIOL.RTN_COMPL_ACTL_DATE is 'The calendar date, determined by the Responsible Authority, on which the regulated entity actually returned to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceActualDate)'
/

comment on column RCRA_CME_VIOL.RTN_TO_COMPL_QUAL is 'Parent: Compliance Monitoring and Enforcement Violation Data (ReturnToComplianceQualifier)'
/

comment on column RCRA_CME_VIOL.VIOL_RESP_AGN is 'Parent: Compliance Monitoring and Enforcement Violation Data (ViolationResponsibleAgency)'
/

comment on column RCRA_CME_VIOL.NOTES is 'Parent: Compliance Monitoring and Enforcement Violation Data (Notes)'
/

comment on column RCRA_CME_VIOL.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_CME_VIOL.C_CREATED_DATE is 'Creation Date (CCreatedDate)'
/

create index IX_CM_VL_CM_FC_SB
    on RCRA_CME_VIOL (CME_FAC_SUBM_ID)
/

create table RCRA_CME_CITATION
(
    CME_CITATION_ID       NUMBER(10) not null
        constraint PK_CME_CITATION
            primary key,
    CME_VIOL_ID           NUMBER(10) not null
        constraint FK_CME_CTTN_CME_VL
            references RCRA_CME_VIOL
                on delete cascade,
    TRANS_CODE            CHAR,
    CITATION_NAME_SEQ_NUM NUMBER(10) not null,
    CITATION_NAME         VARCHAR2(80),
    CITATION_NAME_OWNER   CHAR(2),
    CITATION_NAME_TYPE    CHAR(2),
    NOTES                 VARCHAR2(4000)
)
/

comment on table RCRA_CME_CITATION is 'Schema element: CitationDataType'
/

comment on column RCRA_CME_CITATION.CME_CITATION_ID is 'Parent: Compliance Monitoring and Enforcement Citation Data (_PK)'
/

comment on column RCRA_CME_CITATION.CME_VIOL_ID is 'Parent: Compliance Monitoring and Enforcement Citation Data (_FK)'
/

comment on column RCRA_CME_CITATION.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_CITATION.CITATION_NAME_SEQ_NUM is 'Parent: Compliance Monitoring and Enforcement Citation Data (CitationNameSequenceNumber)'
/

comment on column RCRA_CME_CITATION.CITATION_NAME is 'The citation(s) of the violations alleged (CME) or of the Authority used (CA). (CitationName)'
/

comment on column RCRA_CME_CITATION.CITATION_NAME_OWNER is 'State postal code (CitationNameOwner)'
/

comment on column RCRA_CME_CITATION.CITATION_NAME_TYPE is 'Existing nationally defined values: FR, FS, OC, PC,SR,SS,V3 (CitationNameType)'
/

comment on column RCRA_CME_CITATION.NOTES is 'Parent: Compliance Monitoring and Enforcement Citation Data (Notes)'
/

create index IX_CME_CT_CM_VL_ID
    on RCRA_CME_CITATION (CME_VIOL_ID)
/

create table RCRA_CME_VIOL_ENFRC
(
    CME_VIOL_ENFRC_ID   NUMBER(10) not null
        constraint PK_CME_VIOL_ENFRC
            primary key,
    CME_ENFRC_ACT_ID    NUMBER(10) not null
        constraint FK_CM_VL_EN_CM_EN
            references RCRA_CME_ENFRC_ACT
                on delete cascade,
    TRANS_CODE          CHAR,
    VIOL_SEQ_NUM        NUMBER(10) not null,
    AGN_WHICH_DTRM_VIOL CHAR       not null,
    RTN_COMPL_SCHD_DATE DATE
)
/

comment on table RCRA_CME_VIOL_ENFRC is 'Schema element: ViolationEnforcementDataType'
/

comment on column RCRA_CME_VIOL_ENFRC.CME_VIOL_ENFRC_ID is 'Parent: Linking Data for Violation and Enforcement (_PK)'
/

comment on column RCRA_CME_VIOL_ENFRC.CME_ENFRC_ACT_ID is 'Parent: Linking Data for Violation and Enforcement (_FK)'
/

comment on column RCRA_CME_VIOL_ENFRC.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_CME_VIOL_ENFRC.VIOL_SEQ_NUM is 'Parent: Linking Data for Violation and Enforcement (ViolationSequenceNumber)'
/

comment on column RCRA_CME_VIOL_ENFRC.AGN_WHICH_DTRM_VIOL is 'Parent: Linking Data for Violation and Enforcement (AgencyWhichDeterminedViolation)'
/

comment on column RCRA_CME_VIOL_ENFRC.RTN_COMPL_SCHD_DATE is 'The calendar date, specified in the Compliance Schedule (if any), on which the regulated entity is scheduled to return to compliance with respect to the legal obligation that is the subject of the Violation Determined Date. (ReturnComplianceScheduledDate)'
/

create index IX_CM_VL_EN_CM_EN
    on RCRA_CME_VIOL_ENFRC (CME_ENFRC_ACT_ID)
/

create table RCRA_FA_FAC_SUBM
(
    FA_FAC_SUBM_ID NUMBER(10)   not null
        constraint PK_FA_FAC_SUBM
            primary key,
    HANDLER_ID     VARCHAR2(12) not null
)
/

comment on table RCRA_FA_FAC_SUBM is 'Schema element: FinancialAssuranceFacilitySubmissionDataType'
/

comment on column RCRA_FA_FAC_SUBM.FA_FAC_SUBM_ID is 'Parent: Supplies all of the relevant Financial Assurance Data for a given Handler (_PK)'
/

comment on column RCRA_FA_FAC_SUBM.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

create table RCRA_FA_COST_EST
(
    FA_COST_EST_ID              NUMBER(10) not null
        constraint PK_FA_COST_EST
            primary key,
    FA_FAC_SUBM_ID              NUMBER(10) not null
        constraint FK_FA_CS_ES_FA_FC
            references RCRA_FA_FAC_SUBM
                on delete cascade,
    TRANS_CODE                  CHAR,
    ACT_LOC_CODE                CHAR(2)    not null,
    COST_ESTIMATE_TYPE_CODE     CHAR       not null,
    COST_ESTIMATE_AGN_CODE      CHAR       not null,
    COST_ESTIMATE_SEQ_NUM       NUMBER(10) not null,
    RESP_PERSON_DATA_OWNER_CODE CHAR(2),
    RESP_PERSON_ID              VARCHAR2(5),
    COST_ESTIMATE_AMOUNT        NUMBER(13, 2),
    COST_ESTIMATE_DATE          DATE,
    COST_ESTIMATE_RSN_CODE      CHAR,
    AREA_UNIT_NOTES_TXT         VARCHAR2(240),
    SUPP_INFO_TXT               VARCHAR2(2000),
    CREATED_BY_USERID           VARCHAR2(255),
    F_CREATED_DATE              TIMESTAMP(6),
    DATA_ORIG                   CHAR(2),
    UPDATE_DUE_DATE             DATE,
    CURRENT_COST_ESTIMATE_IND   CHAR,
    LAST_UPDT_BY                VARCHAR2(255),
    LAST_UPDT_DATE              DATE
)
/

comment on table RCRA_FA_COST_EST is 'Schema element: CostEstimateDataType'
/

comment on column RCRA_FA_COST_EST.FA_COST_EST_ID is 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_PK)'
/

comment on column RCRA_FA_COST_EST.FA_FAC_SUBM_ID is 'Parent: Estimates of the Financial liability costs associated with a given Handler. (_FK)'
/

comment on column RCRA_FA_COST_EST.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_FA_COST_EST.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_TYPE_CODE is 'Indicates what type of Financial Assurance is Required. (CostEstimateTypeCode)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_AGN_CODE is 'Code indicating the agency responsible for overseeing the review of the cost estimate. (CostEstimateAgencyCode)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_SEQ_NUM is 'Unique number that identifies the cost estimate. (CostEstimateSequenceNumber)'
/

comment on column RCRA_FA_COST_EST.RESP_PERSON_DATA_OWNER_CODE is 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_FA_COST_EST.RESP_PERSON_ID is 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_AMOUNT is 'The dollar amount of the cost estimate for a given financial assurance type. (CostEstimateAmount)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_DATE is 'The date when the cost estimate for a given financial assurance type was submitted, adjusted, approved, or required to be in place. (CostEstimateDate)'
/

comment on column RCRA_FA_COST_EST.COST_ESTIMATE_RSN_CODE is 'The reason the cost estimate for a financial assurance type is being reported. (CostEstimateReasonCode)'
/

comment on column RCRA_FA_COST_EST.AREA_UNIT_NOTES_TXT is 'Notes regarding the corrective action area or permit unit that this cost estimate applies. (AreaUnitNotesText)'
/

comment on column RCRA_FA_COST_EST.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_FA_COST_EST.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_FA_COST_EST.F_CREATED_DATE is 'Creation Date (FCreatedDate)'
/

comment on column RCRA_FA_COST_EST.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_FA_CS_ES_FA_FC
    on RCRA_FA_COST_EST (FA_FAC_SUBM_ID)
/

create table RCRA_FA_COST_EST_REL_MECHANISM
(
    FA_COST_EST_REL_MECHANISM_ID NUMBER(10) not null
        constraint PK_FA_CST_ES_RL_MC
            primary key,
    FA_COST_EST_ID               NUMBER(10) not null
        constraint FK_FA_CS_ES_RL_MC
            references RCRA_FA_COST_EST
                on delete cascade,
    TRANS_CODE                   CHAR,
    ACT_LOC_CODE                 CHAR(2)    not null,
    MECHANISM_AGN_CODE           CHAR       not null,
    MECHANISM_SEQ_NUM            NUMBER(10) not null,
    MECHANISM_DETAIL_SEQ_NUM     NUMBER(10) not null
)
/

comment on table RCRA_FA_COST_EST_REL_MECHANISM is 'Schema element: CostEstimateRelatedMechanismDataType'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.FA_COST_EST_REL_MECHANISM_ID is 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_PK)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.FA_COST_EST_ID is 'Parent: Linking Data for Cost Estimates and Related Mechanisms (_FK)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_AGN_CODE is 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_SEQ_NUM is 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)'
/

comment on column RCRA_FA_COST_EST_REL_MECHANISM.MECHANISM_DETAIL_SEQ_NUM is 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)'
/

create index IX_FA_CS_ES_RL_MC
    on RCRA_FA_COST_EST_REL_MECHANISM (FA_COST_EST_ID)
/

create table RCRA_FA_MECHANISM
(
    FA_MECHANISM_ID                NUMBER(10) not null
        constraint PK_FA_MECHANISM
            primary key,
    FA_FAC_SUBM_ID                 NUMBER(10) not null
        constraint FK_FA_MCH_FA_FC_SB
            references RCRA_FA_FAC_SUBM
                on delete cascade,
    TRANS_CODE                     CHAR,
    ACT_LOC_CODE                   CHAR(2)    not null,
    MECHANISM_AGN_CODE             CHAR       not null,
    MECHANISM_SEQ_NUM              NUMBER(10) not null,
    MECHANISM_TYPE_DATA_OWNER_CODE CHAR(2),
    MECHANISM_TYPE_CODE            CHAR,
    PROVIDER_TXT                   VARCHAR2(80),
    PROVIDER_FULL_CONTACT_NAME     VARCHAR2(33),
    TELE_NUM_TXT                   VARCHAR2(15),
    SUPP_INFO_TXT                  VARCHAR2(2000),
    CREATED_BY_USERID              VARCHAR2(255),
    F_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    PROVIDER_CONTACT_EMAIL         VARCHAR2(80),
    ACTIVE_MECHANISM_IND           CHAR,
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_FA_MECHANISM is 'Schema element: MechanismDataType'
/

comment on column RCRA_FA_MECHANISM.FA_MECHANISM_ID is 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_PK)'
/

comment on column RCRA_FA_MECHANISM.FA_FAC_SUBM_ID is 'Parent: Mechanisms used to address cost estimates of the Financial liability associated with a given Handler. (_FK)'
/

comment on column RCRA_FA_MECHANISM.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_FA_MECHANISM.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_FA_MECHANISM.MECHANISM_AGN_CODE is 'The agency responsible for overseeing the review of the mechanism. (MechanismAgencyCode)'
/

comment on column RCRA_FA_MECHANISM.MECHANISM_SEQ_NUM is 'Unique numerical identier for the mechanism. (MechanismSequenceNumber)'
/

comment on column RCRA_FA_MECHANISM.MECHANISM_TYPE_DATA_OWNER_CODE is 'Indicates the agency that defined the mechanism type. (MechanismTypeDataOwnerCode)'
/

comment on column RCRA_FA_MECHANISM.MECHANISM_TYPE_CODE is 'The type of mechanism that addresses the cost estimate. (MechanismTypeCode)'
/

comment on column RCRA_FA_MECHANISM.PROVIDER_TXT is 'The name of the financial institution with which the financial assurance mechanism is held, such as a bank (letter of credit) or a surety (surety bond); also identifies a facility (financial test), or a guarantor (corporate guarantee). (ProviderText)'
/

comment on column RCRA_FA_MECHANISM.PROVIDER_FULL_CONTACT_NAME is 'Contact Name of the provider. (ProviderFullContactName)'
/

comment on column RCRA_FA_MECHANISM.TELE_NUM_TXT is 'Telephone Number data (TelephoneNumberText)'
/

comment on column RCRA_FA_MECHANISM.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_FA_MECHANISM.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_FA_MECHANISM.F_CREATED_DATE is 'Creation Date (FCreatedDate)'
/

comment on column RCRA_FA_MECHANISM.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_FA_MC_FA_FC_SB
    on RCRA_FA_MECHANISM (FA_FAC_SUBM_ID)
/

create table RCRA_FA_MECHANISM_DETAIL
(
    FA_MECHANISM_DETAIL_ID       NUMBER(10) not null
        constraint PK_FA_MCHNISM_DTIL
            primary key,
    FA_MECHANISM_ID              NUMBER(10) not null
        constraint FK_FA_MCH_DT_FA_MC
            references RCRA_FA_MECHANISM
                on delete cascade,
    TRANS_CODE                   CHAR,
    MECHANISM_DETAIL_SEQ_NUM     NUMBER(10) not null,
    MECHANISM_IDEN_TXT           VARCHAR2(40),
    FACE_VAL_AMOUNT              NUMBER(13, 2),
    EFFC_DATE                    DATE,
    EXPIRATION_DATE              DATE,
    SUPP_INFO_TXT                VARCHAR2(2000),
    CURRENT_MECHANISM_DETAIL_IND CHAR,
    CREATED_BY_USERID            VARCHAR2(255),
    F_CREATED_DATE               TIMESTAMP(6),
    DATA_ORIG                    CHAR(2),
    FAC_FACE_VAL_AMOUNT          NUMBER(14, 6),
    ALT_IND                      CHAR,
    LAST_UPDT_BY                 VARCHAR2(255),
    LAST_UPDT_DATE               DATE
)
/

comment on table RCRA_FA_MECHANISM_DETAIL is 'Schema element: MechanismDetailDataType'
/

comment on column RCRA_FA_MECHANISM_DETAIL.FA_MECHANISM_DETAIL_ID is 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_PK)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.FA_MECHANISM_ID is 'Parent: Details of the mechanism used to address cost estimates of the Financial liability associated with a given Handler. (_FK)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.MECHANISM_DETAIL_SEQ_NUM is 'Unique numerical code identifying the mechanism detail. (MechanismDetailSequenceNumber)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.MECHANISM_IDEN_TXT is 'The number assigned to the mechanism, such as a bond number or insurance policy number. (MechanismIdentificationText)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.FACE_VAL_AMOUNT is 'The total dollar value of the financial assurance mechanism. (FaceValueAmount)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.EFFC_DATE is 'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.EXPIRATION_DATE is 'The date the instrument terminates, such as the end of the term of an insurance policy. (ExpirationDate)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.CURRENT_MECHANISM_DETAIL_IND is 'Indicates if the mechanism detail is current. Possible values are: Y/N (CurrentMechanismDetailIndicator)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.F_CREATED_DATE is 'Creation Date (FCreatedDate)'
/

comment on column RCRA_FA_MECHANISM_DETAIL.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_FA_MC_DT_FA_MC
    on RCRA_FA_MECHANISM_DETAIL (FA_MECHANISM_ID)
/

create table RCRA_GIS_FAC_SUBM
(
    GIS_FAC_SUBM_ID NUMBER(10)   not null
        constraint PK_GIS_FAC_SUBM
            primary key,
    HANDLER_ID      VARCHAR2(12) not null
)
/

comment on table RCRA_GIS_FAC_SUBM is 'Schema element: GISFacilitySubmissionDataType'
/

comment on column RCRA_GIS_FAC_SUBM.GIS_FAC_SUBM_ID is 'Parent: Supplies all of the relevant GIS Data for a given Handler (_PK)'
/

comment on column RCRA_GIS_FAC_SUBM.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

create table RCRA_GIS_GEO_INFORMATION
(
    GIS_GEO_INFORMATION_ID         NUMBER(10) not null
        constraint PK_GS_GO_INFORMTON
            primary key,
    GIS_FAC_SUBM_ID                NUMBER(10) not null
        constraint FK_GS_GO_IN_GS_FC
            references RCRA_GIS_FAC_SUBM
                on delete cascade,
    TRANS_CODE                     CHAR,
    GEO_INFO_OWNER                 CHAR(2)    not null,
    GEO_INFO_SEQ_NUM               NUMBER(10) not null,
    PERMIT_UNIT_SEQ_NUM            NUMBER(10),
    AREA_SEQ_NUM                   NUMBER(10),
    LOC_COMM_TXT                   VARCHAR2(2000),
    AREA_ACREAGE_MEAS              NUMBER(13, 2),
    AREA_MEAS_SRC_DATA_OWNER_CODE  CHAR(2),
    AREA_MEAS_SRC_CODE             VARCHAR2(4),
    AREA_MEAS_DATE                 DATE,
    DATA_COLL_DATE                 DATE       not null,
    HORZ_ACC_MEAS                  NUMBER(10),
    SRC_MAP_SCALE_NUM              NUMBER(10),
    COORD_DATA_SRC_DATA_OWNER_CODE CHAR(2),
    COORD_DATA_SRC_CODE            VARCHAR2(3),
    GEO_REF_PT_DATA_OWNER_CODE     CHAR(2),
    GEO_REF_PT_CODE                VARCHAR2(3),
    GEOM_TYPE_DATA_OWNER_CODE      CHAR(2),
    GEOM_TYPE_CODE                 VARCHAR2(3),
    HORZ_COLL_METH_DATA_OWNER_CODE CHAR(2),
    HORZ_COLL_METH_CODE            VARCHAR2(3),
    HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE CHAR(2),
    HORZ_COORD_REF_SYS_DATUM_CODE  VARCHAR2(3),
    VERF_METH_DATA_OWNER_CODE      CHAR(2),
    VERF_METH_CODE                 VARCHAR2(3),
    LATITUDE                       NUMBER(19, 14),
    LONGITUDE                      NUMBER(19, 14),
    ELEVATION                      NUMBER(19, 14),
    CREATED_BY_USERID              VARCHAR2(255),
    G_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_GIS_GEO_INFORMATION is 'Schema element: GeographicInformationDataType'
/

comment on column RCRA_GIS_GEO_INFORMATION.GIS_GEO_INFORMATION_ID is 'Parent: Used to define the geographic coordinates of the Handler. (_PK)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GIS_FAC_SUBM_ID is 'Parent: Used to define the geographic coordinates of the Handler. (_FK)'
/

comment on column RCRA_GIS_GEO_INFORMATION.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEO_INFO_OWNER is 'Owner of Geographic Information.  Should match state code (i.e. KS). (GeographicInformationOwner)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEO_INFO_SEQ_NUM is 'Unique identifier for the geographic information. (GeographicInformationSequenceNumber)'
/

comment on column RCRA_GIS_GEO_INFORMATION.PERMIT_UNIT_SEQ_NUM is 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)'
/

comment on column RCRA_GIS_GEO_INFORMATION.AREA_SEQ_NUM is 'Code used for administrative purposes to uniquely designate a group of units (or a single unit) with a common history and projection of corrective action requirements. (AreaSequenceNumber)'
/

comment on column RCRA_GIS_GEO_INFORMATION.LOC_COMM_TXT is 'The text that provides additional informaiton about the geographic coordinates. (LocationCommentsText)'
/

comment on column RCRA_GIS_GEO_INFORMATION.AREA_ACREAGE_MEAS is 'The number of acres associated with the handler or area. (AreaAcreageMeasure)'
/

comment on column RCRA_GIS_GEO_INFORMATION.AREA_MEAS_SRC_DATA_OWNER_CODE is 'Indicates the agency that defined the AreaMeasureSource. (AreaMeasureSourceDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.AREA_MEAS_SRC_CODE is 'The source of information used to determine the number of acres associated with the handler or area. (AreaMeasureSourceCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.AREA_MEAS_DATE is 'The date acreage information for the handler or area was collected. (AreaMeasureDate)'
/

comment on column RCRA_GIS_GEO_INFORMATION.DATA_COLL_DATE is 'The calender date when data were collected (DataCollectionDate)'
/

comment on column RCRA_GIS_GEO_INFORMATION.HORZ_ACC_MEAS is 'The horizontal measure, in meters, of the relative accuracy of the latitude and longitude coordinates. (HorizontalAccuracyMeasure)'
/

comment on column RCRA_GIS_GEO_INFORMATION.SRC_MAP_SCALE_NUM is 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumeric)'
/

comment on column RCRA_GIS_GEO_INFORMATION.COORD_DATA_SRC_DATA_OWNER_CODE is 'The owner of the code.  If provided, it should be HQ. (CoordinateDataSourceDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.COORD_DATA_SRC_CODE is 'The code that represents the party responsible for proiding the latitude and longitude coordinates. (CoordinateDataSourceCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEO_REF_PT_DATA_OWNER_CODE is 'The owner of the code.  If provided, it should be HQ. (GeographicReferencePointDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEO_REF_PT_CODE is 'The code that represents the place for which the geographic codes were established (GeographicReferencePointCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEOM_TYPE_DATA_OWNER_CODE is 'The owner of the code.  If provided, it should be HQ. (GeometricTypeDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.GEOM_TYPE_CODE is 'The code that represents the geometric entity represented by one point or a sequence of points (GeometricTypeCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.HORZ_COLL_METH_DATA_OWNER_CODE is 'The owner of the code.  If provided, it should be HQ. (HorizontalCollectionMethodDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.HORZ_COLL_METH_CODE is 'The code that represents the method used to deterimine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE is 'The owner of the code.  If provided, it should be HQ. (HorizontalCoordinateReferenceSystemDatumDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.HORZ_COORD_REF_SYS_DATUM_CODE is 'The code that represents the datum used in determining latitude and longitude coordinates (HorizontalCoordinateReferenceSystemDatumCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.VERF_METH_DATA_OWNER_CODE is 'The owner of the code.  If provided, it should be HQ. (VerificationMethodDataOwnerCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.VERF_METH_CODE is 'The code that represents the process used to verify the latitude and longitude coordinates. (VerificationMethodCode)'
/

comment on column RCRA_GIS_GEO_INFORMATION.LATITUDE is 'Parent: Geometry property element of a GeoRSS GML instance (Latitude)'
/

comment on column RCRA_GIS_GEO_INFORMATION.LONGITUDE is 'Parent: Geometry property element of a GeoRSS GML instance (Longitude)'
/

comment on column RCRA_GIS_GEO_INFORMATION.ELEVATION is 'Parent: Geometry property element of a GeoRSS GML instance (Elevation)'
/

comment on column RCRA_GIS_GEO_INFORMATION.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_GIS_GEO_INFORMATION.G_CREATED_DATE is 'Creation Date (GCreatedDate)'
/

comment on column RCRA_GIS_GEO_INFORMATION.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_GS_GO_IN_GS_FC
    on RCRA_GIS_GEO_INFORMATION (GIS_FAC_SUBM_ID)
/

create table RCRA_HD_HBASIC
(
    HD_HBASIC_ID        NUMBER(10)   not null
        constraint PK_HD_HBASIC
            primary key,
    TRANSACTION_CODE    CHAR,
    HANDLER_ID          VARCHAR2(12) not null,
    EXTRACT_FLAG        CHAR,
    FACILITY_IDENTIFIER VARCHAR2(12)
)
/

comment on table RCRA_HD_HBASIC is 'Schema element: FacilitySubmissionDataType'
/

comment on column RCRA_HD_HBASIC.HD_HBASIC_ID is 'Parent: Details of facility submission. (_PK)'
/

comment on column RCRA_HD_HBASIC.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_HBASIC.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

comment on column RCRA_HD_HBASIC.EXTRACT_FLAG is 'Designates that data is available for extract for public use. (PublicUseExtractIndicator)'
/

comment on column RCRA_HD_HBASIC.FACILITY_IDENTIFIER is 'Computer-generated primary facility-level key in the EPA FINDS data system used as an identifier to cross-reference entities regulated under different environmental programs. The Agency Facility Identification Data Standard (FIDS) requires that program offices store this key in their data systems. (FacilityRegistryID)'
/

create table RCRA_HD_HANDLER
(
    HD_HANDLER_ID                  NUMBER(10) not null
        constraint PK_HD_HANDLER
            primary key,
    HD_HBASIC_ID                   NUMBER(10) not null
        constraint FK_HD_HAND_HD_HBAS
            references RCRA_HD_HBASIC
                on delete cascade,
    TRANSACTION_CODE               CHAR,
    ACTIVITY_LOCATION              CHAR(2)    not null,
    SOURCE_TYPE                    CHAR       not null,
    SEQ_NUMBER                     NUMBER(10) not null,
    HANDLER_NAME                   VARCHAR2(80),
    ACKNOWLEDGE_DATE               VARCHAR2(10),
    NON_NOTIFIER                   CHAR,
    TSD_DATE                       VARCHAR2(10),
    OFF_SITE_RECEIPT               CHAR,
    ACCESSIBILITY                  CHAR,
    COUNTY_CODE_OWNER              CHAR(2),
    COUNTY_CODE                    VARCHAR2(5),
    NOTES                          VARCHAR2(4000),
    ACKNOWLEDGE_FLAG               CHAR,
    LOCATION_STREET1               VARCHAR2(50),
    LOCATION_STREET2               VARCHAR2(50),
    LOCATION_CITY                  VARCHAR2(25),
    LOCATION_STATE                 CHAR(2),
    LOCATION_COUNTRY               CHAR(2),
    LOCATION_ZIP                   VARCHAR2(14),
    MAIL_STREET1                   VARCHAR2(50),
    MAIL_STREET2                   VARCHAR2(50),
    MAIL_CITY                      VARCHAR2(25),
    MAIL_STATE                     CHAR(2),
    MAIL_COUNTRY                   CHAR(2),
    MAIL_ZIP                       VARCHAR2(14),
    CONTACT_FIRST_NAME             VARCHAR2(38),
    CONTACT_MIDDLE_INITIAL         CHAR,
    CONTACT_LAST_NAME              VARCHAR2(38),
    CONTACT_ORG_NAME               VARCHAR2(80),
    CONTACT_TITLE                  VARCHAR2(80),
    CONTACT_EMAIL_ADDRESS          VARCHAR2(80),
    CONTACT_PHONE                  VARCHAR2(15),
    CONTACT_PHONE_EXT              VARCHAR2(6),
    CONTACT_FAX                    VARCHAR2(15),
    CONTACT_STREET_NUMBER          VARCHAR2(12),
    CONTACT_STREET1                VARCHAR2(50),
    CONTACT_STREET2                VARCHAR2(50),
    CONTACT_CITY                   VARCHAR2(25),
    CONTACT_STATE                  CHAR(2),
    CONTACT_COUNTRY                CHAR(2),
    CONTACT_ZIP                    VARCHAR2(14),
    PCONTACT_FIRST_NAME            VARCHAR2(38),
    PCONTACT_MIDDLE_NAME           CHAR,
    PCONTACT_LAST_NAME             VARCHAR2(38),
    PCONTACT_ORG_NAME              VARCHAR2(80),
    PCONTACT_TITLE                 VARCHAR2(80),
    PCONTACT_EMAIL_ADDRESS         VARCHAR2(80),
    PCONTACT_PHONE                 VARCHAR2(15),
    PCONTACT_PHONE_EXT             VARCHAR2(6),
    PCONTACT_FAX                   VARCHAR2(15),
    PCONTACT_STREET_NUMBER         VARCHAR2(12),
    PCONTACT_STREET1               VARCHAR2(50),
    PCONTACT_STREET2               VARCHAR2(50),
    PCONTACT_CITY                  VARCHAR2(25),
    PCONTACT_STATE                 CHAR(2),
    PCONTACT_COUNTRY               CHAR(2),
    PCONTACT_ZIP                   VARCHAR2(14),
    USED_OIL_BURNER                CHAR,
    USED_OIL_PROCESSOR             CHAR,
    USED_OIL_REFINER               CHAR,
    USED_OIL_MARKET_BURNER         CHAR,
    USED_OIL_SPEC_MARKETER         CHAR,
    USED_OIL_TRANSFER_FACILITY     CHAR,
    USED_OIL_TRANSPORTER           CHAR,
    LAND_TYPE                      CHAR,
    STATE_DISTRICT_OWNER           CHAR(2),
    STATE_DISTRICT                 VARCHAR2(10),
    IMPORTER_ACTIVITY              CHAR,
    MIXED_WASTE_GENERATOR          CHAR,
    RECYCLER_ACTIVITY              CHAR,
    TRANSPORTER_ACTIVITY           CHAR,
    TSD_ACTIVITY                   CHAR,
    UNDERGROUND_INJECTION_ACTIVITY CHAR,
    UNIVERSAL_WASTE_DEST_FACILITY  CHAR,
    ONSITE_BURNER_EXEMPTION        CHAR,
    FURNACE_EXEMPTION              CHAR,
    SHORT_TERM_GEN_IND             CHAR,
    TRANSFER_FACILITY_IND          CHAR,
    STATE_WASTE_GENERATOR_OWNER    CHAR(2),
    STATE_WASTE_GENERATOR          CHAR,
    FED_WASTE_GENERATOR_OWNER      CHAR(2),
    FED_WASTE_GENERATOR            CHAR,
    COLLEGE_IND                    CHAR,
    HOSPITAL_IND                   CHAR,
    NON_PROFIT_IND                 CHAR,
    WITHDRAWAL_IND                 CHAR,
    TRANS_CODE                     CHAR,
    NOTIFICATION_RSN_CODE          CHAR,
    EFFC_DATE                      TIMESTAMP(6),
    FINANCIAL_ASSURANCE_IND        CHAR,
    RECYCLING_IND                  CHAR,
    MAIL_STREET_NUMBER             VARCHAR2(12),
    LOCATION_STREET_NUMBER         VARCHAR2(12),
    NON_NOTIFIER_TEXT              VARCHAR2(255),
    ACCESSIBILITY_TEXT             VARCHAR2(255),
    STATE_DISTRICT_TEXT            VARCHAR2(255),
    INTRNL_NOTES                   VARCHAR2(4000),
    SHORT_TERM_INTRNL_NOTES        VARCHAR2(4000),
    NATURE_OF_BUSINESS_TEXT        VARCHAR2(4000),
    RECOGNIZED_TRADER_IMPORTER_IND CHAR,
    RECOGNIZED_TRADER_EXPORTER_IND CHAR,
    SLAB_IMPORTER_IND              CHAR,
    SLAB_EXPORTER_IND              CHAR,
    RECYCLER_ACT_NONSTORAGE        CHAR,
    MANIFEST_BROKER                CHAR,
    ACKNOWLEDGE_FLAG_IND           CHAR,
    INCLUDE_IN_NATIONAL_REPORT_IND CHAR,
    LQHUW_IND                      CHAR,
    HD_REPORT_CYCLE_YEAR           NUMBER,
    HEALTHCARE_FAC                 CHAR,
    REVERSE_DISTRIBUTOR            CHAR,
    SUBPART_P_WITHDRAWAL           CHAR,
    RECYCLER_IND                   CHAR,
    RECEIVE_DATE                   VARCHAR2(10),
    CURRENT_RECORD                 CHAR,
    CREATED_BY_USERID              VARCHAR2(255),
    H_CREATED_DATE                 TIMESTAMP(6),
    DATA_ORIG                      CHAR(2),
    LOCATION_LATITUDE              NUMBER(19, 14),
    LOCATION_LONGITUDE             NUMBER(19, 14),
    LOCATION_GIS_PRIM              CHAR,
    LOCATION_GIS_ORIG              CHAR(2),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE,
    BR_EXEMPT_IND                  CHAR
)
/

comment on table RCRA_HD_HANDLER is 'Schema element: HandlerDataType'
/

comment on column RCRA_HD_HANDLER.HD_HANDLER_ID is 'Parent: Top level of all information about the handler. (_PK)'
/

comment on column RCRA_HD_HANDLER.HD_HBASIC_ID is 'Parent: Top level of all information about the handler. (_FK)'
/

comment on column RCRA_HD_HANDLER.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_HANDLER.ACTIVITY_LOCATION is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_HD_HANDLER.SOURCE_TYPE is 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)'
/

comment on column RCRA_HD_HANDLER.SEQ_NUMBER is 'Sequence number for each source record about a handler. (SourceRecordSequenceNumber)'
/

comment on column RCRA_HD_HANDLER.HANDLER_NAME is 'Name of the Handler (HandlerName)'
/

comment on column RCRA_HD_HANDLER.ACKNOWLEDGE_DATE is 'Date information was received for the handler. (AcknowledgeReceiptDate)'
/

comment on column RCRA_HD_HANDLER.NON_NOTIFIER is 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)'
/

comment on column RCRA_HD_HANDLER.TSD_DATE is 'The date that operation of the facility commenced, the date construction on the facility commenced, or the date that operation is expected to begin. (TreatmentStorageDisposalDate)'
/

comment on column RCRA_HD_HANDLER.OFF_SITE_RECEIPT is 'Code indicating that the handler, whether public or private, currently accepts hazardous waste from another site (site identified by a different EPA ID). If information is also available on the specific processes and wastes which are accepted, it is indicated by a flag at the process unit level (Process Unit Group Commercial Status). (OffsiteWasteReceiptCode)'
/

comment on column RCRA_HD_HANDLER.ACCESSIBILITY is 'Code indicating the reason why the handler is not accessible for normal RCRA tracking and processing (previously called Bankrupt Indicator). (AccessibilityCode)'
/

comment on column RCRA_HD_HANDLER.COUNTY_CODE_OWNER is 'Indicates the agency that defines the county code. (CountyCodeOwner)'
/

comment on column RCRA_HD_HANDLER.COUNTY_CODE is 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)'
/

comment on column RCRA_HD_HANDLER.NOTES is 'Notes regarding the Handler. (HandlerSupplementalInformationText)'
/

comment on column RCRA_HD_HANDLER.ACKNOWLEDGE_FLAG is 'Parent: Top level of all information about the handler. (AcknowledgeFlag)'
/

comment on column RCRA_HD_HANDLER.LOCATION_STREET1 is 'Parent: Location address information. (LocationAddressText)'
/

comment on column RCRA_HD_HANDLER.LOCATION_STREET2 is 'Parent: Location address information. (SupplementalLocationText)'
/

comment on column RCRA_HD_HANDLER.LOCATION_CITY is 'Parent: Location address information. (LocalityName)'
/

comment on column RCRA_HD_HANDLER.LOCATION_STATE is 'Parent: Location address information. (StateUSPSCode)'
/

comment on column RCRA_HD_HANDLER.LOCATION_COUNTRY is 'Parent: Location address information. (CountryName)'
/

comment on column RCRA_HD_HANDLER.LOCATION_ZIP is 'Parent: Location address information. (LocationZIPCode)'
/

comment on column RCRA_HD_HANDLER.MAIL_STREET1 is 'Parent: Mailing address information. (MailingAddressText)'
/

comment on column RCRA_HD_HANDLER.MAIL_STREET2 is 'Parent: Mailing address information. (SupplementalAddressText)'
/

comment on column RCRA_HD_HANDLER.MAIL_CITY is 'Parent: Mailing address information. (MailingAddressCityName)'
/

comment on column RCRA_HD_HANDLER.MAIL_STATE is 'Parent: Mailing address information. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_HD_HANDLER.MAIL_COUNTRY is 'Parent: Mailing address information. (MailingAddressCountryName)'
/

comment on column RCRA_HD_HANDLER.MAIL_ZIP is 'Parent: Mailing address information. (MailingAddressZIPCode)'
/

comment on column RCRA_HD_HANDLER.CONTACT_FIRST_NAME is 'Parent: Contact information. (FirstName)'
/

comment on column RCRA_HD_HANDLER.CONTACT_MIDDLE_INITIAL is 'Parent: Contact information. (MiddleInitial)'
/

comment on column RCRA_HD_HANDLER.CONTACT_LAST_NAME is 'Parent: Contact information. (LastName)'
/

comment on column RCRA_HD_HANDLER.CONTACT_ORG_NAME is 'Parent: Contact information. (OrganizationFormalName)'
/

comment on column RCRA_HD_HANDLER.CONTACT_TITLE is 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_EMAIL_ADDRESS is 'Email address data (EmailAddressText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_PHONE is 'Telephone Number data (TelephoneNumberText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_PHONE_EXT is 'Telephone number extension (PhoneExtensionText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_FAX is 'Contact fax number (FaxNumberText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_STREET_NUMBER is 'Contact Address Street Number'
/

comment on column RCRA_HD_HANDLER.CONTACT_STREET1 is 'Parent: Mailing address information. (MailingAddressText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_STREET2 is 'Parent: Mailing address information. (SupplementalAddressText)'
/

comment on column RCRA_HD_HANDLER.CONTACT_CITY is 'Parent: Mailing address information. (MailingAddressCityName)'
/

comment on column RCRA_HD_HANDLER.CONTACT_STATE is 'Parent: Mailing address information. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_HD_HANDLER.CONTACT_COUNTRY is 'Parent: Mailing address information. (MailingAddressCountryName)'
/

comment on column RCRA_HD_HANDLER.CONTACT_ZIP is 'Parent: Mailing address information. (MailingAddressZIPCode)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_FIRST_NAME is 'Parent: Contact information. (FirstName)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_MIDDLE_NAME is 'Parent: Contact information. (MiddleInitial)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_LAST_NAME is 'Parent: Contact information. (LastName)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_ORG_NAME is 'Parent: Contact information. (OrganizationFormalName)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_TITLE is 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_EMAIL_ADDRESS is 'Email address data (EmailAddressText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_PHONE is 'Telephone Number data (TelephoneNumberText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_PHONE_EXT is 'Telephone number extension (PhoneExtensionText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_FAX is 'Contact fax number (FaxNumberText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_STREET_NUMBER is 'Permit Contact Address Street Number'
/

comment on column RCRA_HD_HANDLER.PCONTACT_STREET1 is 'Parent: Mailing address information. (MailingAddressText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_STREET2 is 'Parent: Mailing address information. (SupplementalAddressText)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_CITY is 'Parent: Mailing address information. (MailingAddressCityName)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_STATE is 'Parent: Mailing address information. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_COUNTRY is 'Parent: Mailing address information. (MailingAddressCountryName)'
/

comment on column RCRA_HD_HANDLER.PCONTACT_ZIP is 'Parent: Mailing address information. (MailingAddressZIPCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_BURNER is 'Code indicating that the handler is engaged in the burning of used oil fuel. (FuelBurnerCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_PROCESSOR is 'Code indicating that the handler is engaged in processing used oil activities. (ProcessorCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_REFINER is 'Code indicating that the handler is engaged in re-refining used oil activities. (RefinerCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_MARKET_BURNER is 'Code indicating that the handler directs shipments of used oil to burners. (MarketBurnerCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_SPEC_MARKETER is 'Code indicating that the handler is a marketer who first claims the used oil meets the specifications. (SpecificationMarketerCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_TRANSFER_FACILITY is 'Code indicating that the handler owns or operates a used oil transfer facility. (TransferFacilityCode)'
/

comment on column RCRA_HD_HANDLER.USED_OIL_TRANSPORTER is 'Code indicating that the handler is engaged in used oil transportation and/or transfer facility activities. (TransporterCode)'
/

comment on column RCRA_HD_HANDLER.LAND_TYPE is 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)'
/

comment on column RCRA_HD_HANDLER.STATE_DISTRICT_OWNER is 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)'
/

comment on column RCRA_HD_HANDLER.STATE_DISTRICT is 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)'
/

comment on column RCRA_HD_HANDLER.IMPORTER_ACTIVITY is 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)'
/

comment on column RCRA_HD_HANDLER.MIXED_WASTE_GENERATOR is 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)'
/

comment on column RCRA_HD_HANDLER.RECYCLER_ACTIVITY is 'Code indicating that the handler is engaged in recycling hazardous waste. (RecyclerActivityCode)'
/

comment on column RCRA_HD_HANDLER.TRANSPORTER_ACTIVITY is 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)'
/

comment on column RCRA_HD_HANDLER.TSD_ACTIVITY is 'Code indicating that the handler is engaged in the treatment, storage, or disposal of hazardous waste. (TreatmentStorageDisposalActivityCode)'
/

comment on column RCRA_HD_HANDLER.UNDERGROUND_INJECTION_ACTIVITY is 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)'
/

comment on column RCRA_HD_HANDLER.UNIVERSAL_WASTE_DEST_FACILITY is 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)'
/

comment on column RCRA_HD_HANDLER.ONSITE_BURNER_EXEMPTION is 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)'
/

comment on column RCRA_HD_HANDLER.FURNACE_EXEMPTION is 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)'
/

comment on column RCRA_HD_HANDLER.SHORT_TERM_GEN_IND is 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)'
/

comment on column RCRA_HD_HANDLER.TRANSFER_FACILITY_IND is 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)'
/

comment on column RCRA_HD_HANDLER.STATE_WASTE_GENERATOR_OWNER is 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)'
/

comment on column RCRA_HD_HANDLER.STATE_WASTE_GENERATOR is 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)'
/

comment on column RCRA_HD_HANDLER.FED_WASTE_GENERATOR_OWNER is 'Indicates the agency that defines the generator status type. (WasteGeneratorOwnerName)'
/

comment on column RCRA_HD_HANDLER.FED_WASTE_GENERATOR is 'Code indicating that the handler is engaged in the generation of hazardous waste. (WasteGeneratorStatusCode)'
/

comment on column RCRA_HD_HANDLER.COLLEGE_IND is 'Indicates whether or not the Handler is a College or University opting into SubPart K. (CollegeIndicator)'
/

comment on column RCRA_HD_HANDLER.HOSPITAL_IND is 'Indicates whether or not the Handler is a Hospital opting into SubPart K. (HospitalIndicator)'
/

comment on column RCRA_HD_HANDLER.NON_PROFIT_IND is 'Indicates whether or not the Handler is a Non-Profit opting into SubPart K. (NonProfitIndicator)'
/

comment on column RCRA_HD_HANDLER.WITHDRAWAL_IND is 'Indicates whether or not the Handler is withdrawing from SubPart K. (WithdrawalIndicator)'
/

comment on column RCRA_HD_HANDLER.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_HANDLER.NOTIFICATION_RSN_CODE is 'Indicates the reason for notifying Hazardous Secondary Material (NotificationReasonCode)'
/

comment on column RCRA_HD_HANDLER.EFFC_DATE is 'The Effective Date of the action: 1. Hazardous Secondary Material notification in Handler, 2. Corrective Action Authority, 3. Financial Assurance Mechanism.  (EffectiveDate)'
/

comment on column RCRA_HD_HANDLER.FINANCIAL_ASSURANCE_IND is 'Indicates whether or not the facility has provided Financial Assurance for the HSM Activities (FinancialAssuranceIndicator)'
/

comment on column RCRA_HD_HANDLER.RECYCLING_IND is 'Indicates the facility has a recycling process which the product has levels of hazardous constituents that are not comparable to or unable to be compared to a legitimate product or intermediate but that the recycling is still legitimate'
/

comment on column RCRA_HD_HANDLER.MAIL_STREET_NUMBER is 'Mailing Address Street Number'
/

comment on column RCRA_HD_HANDLER.LOCATION_STREET_NUMBER is 'Location Address Street Number'
/

comment on column RCRA_HD_HANDLER.NON_NOTIFIER_TEXT is 'Descriptive text describing Notification source (Data publishing only)'
/

comment on column RCRA_HD_HANDLER.ACCESSIBILITY_TEXT is 'Descriptive text describing reason facility is not accessible (Data publishing only)'
/

comment on column RCRA_HD_HANDLER.STATE_DISTRICT_TEXT is 'Descriptive text describing the code indicating the state-designated legislative district(s) in which the site is located (Data publishing only)'
/

comment on column RCRA_HD_HANDLER.INTRNL_NOTES is '(HandlerSupplementalInformationText)'
/

comment on column RCRA_HD_HANDLER.SHORT_TERM_INTRNL_NOTES is '(ShortTermSupplementalInformationText)'
/

comment on column RCRA_HD_HANDLER.NATURE_OF_BUSINESS_TEXT is 'Notes regarding Handler Part-A submissions. (NatureOfBusinessText)'
/

comment on column RCRA_HD_HANDLER.RECOGNIZED_TRADER_IMPORTER_IND is 'Indicates that the Handler is participating in Import Trading activity. (RecognizedTraderImporterIndicator)'
/

comment on column RCRA_HD_HANDLER.RECOGNIZED_TRADER_EXPORTER_IND is 'Indicates that the Handler is participating in Export Trading activity. (RecognizedTraderExporterIndicator)'
/

comment on column RCRA_HD_HANDLER.SLAB_IMPORTER_IND is 'Indicates that the Handler is participating in Slab Import activity. (SlabImporterIndicator)'
/

comment on column RCRA_HD_HANDLER.SLAB_EXPORTER_IND is 'Indicates that the Handler is participating in Slab Export activity. (SlabExporterIndicator)'
/

comment on column RCRA_HD_HANDLER.RECYCLER_ACT_NONSTORAGE is 'Identifies that Handler participates in Nonstorage Recycler Activity. (RecyclerActivityNonstorage)'
/

comment on column RCRA_HD_HANDLER.MANIFEST_BROKER is 'Identifies that Handler is ManifestBroker. (ManifestBroker)'
/

comment on column RCRA_HD_HANDLER.CURRENT_RECORD is 'Flag indicating if it is current record (CurrentRecord)'
/

comment on column RCRA_HD_HANDLER.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_HD_HANDLER.H_CREATED_DATE is 'Creation Date (HCreatedDate)'
/

comment on column RCRA_HD_HANDLER.DATA_ORIG is 'Indicates data origination information (DataOrig)'
/

create index IX_HD_HAN_HD_HB_ID
    on RCRA_HD_HANDLER (HD_HBASIC_ID)
/

create table RCRA_HD_CERTIFICATION
(
    HD_CERTIFICATION_ID NUMBER(10) not null
        constraint PK_HD_CERTIFICATIO
            primary key,
    HD_HANDLER_ID       NUMBER(10) not null
        constraint FK_HD_CERT_HD_HAND
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE    CHAR,
    CERT_SEQ            NUMBER(10) not null,
    CERT_SIGNED_DATE    VARCHAR2(10),
    CERT_TITLE          VARCHAR2(45),
    CERT_FIRST_NAME     VARCHAR2(38),
    CERT_MIDDLE_INITIAL CHAR,
    CERT_LAST_NAME      VARCHAR2(38),
    CERT_EMAIL_TEXT     VARCHAR2(80)
)
/

comment on table RCRA_HD_CERTIFICATION is 'Schema element: CertificationDataType'
/

comment on column RCRA_HD_CERTIFICATION.HD_CERTIFICATION_ID is 'Parent: Certification information for the person who certified report to the authorizing agency. (_PK)'
/

comment on column RCRA_HD_CERTIFICATION.HD_HANDLER_ID is 'Parent: Certification information for the person who certified report to the authorizing agency. (_FK)'
/

comment on column RCRA_HD_CERTIFICATION.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_SEQ is 'Sequence number for each certification for the handler. (CertificationSequenceNumber)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_SIGNED_DATE is 'Date on which the handler information was certified by the reporting site. (SignedDate)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_TITLE is 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_FIRST_NAME is 'First name of a person. (FirstName)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_MIDDLE_INITIAL is 'Middle initial of a person. (MiddleInitial)'
/

comment on column RCRA_HD_CERTIFICATION.CERT_LAST_NAME is 'Last name of a person. (LastName)'
/

create index IX_HD_CER_HD_HA_ID
    on RCRA_HD_CERTIFICATION (HD_HANDLER_ID)
/

create table RCRA_HD_ENV_PERMIT
(
    HD_ENV_PERMIT_ID  NUMBER(10)   not null
        constraint PK_HD_ENV_PERMIT
            primary key,
    HD_HANDLER_ID     NUMBER(10)   not null
        constraint FK_HD_ENV_PE_HD_HA
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE  CHAR,
    ENV_PERMIT_NUMBER VARCHAR2(13) not null,
    ENV_PERMIT_OWNER  CHAR(2),
    ENV_PERMIT_TYPE   CHAR,
    ENV_PERMIT_DESC   VARCHAR2(80) not null
)
/

comment on table RCRA_HD_ENV_PERMIT is 'Schema element: EnvironmentalPermitDataType'
/

comment on column RCRA_HD_ENV_PERMIT.HD_ENV_PERMIT_ID is 'Parent: Information about environmental permits issued to the handler. (_PK)'
/

comment on column RCRA_HD_ENV_PERMIT.HD_HANDLER_ID is 'Parent: Information about environmental permits issued to the handler. (_FK)'
/

comment on column RCRA_HD_ENV_PERMIT.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_ENV_PERMIT.ENV_PERMIT_NUMBER is 'Identification number of an effective environmental permit issued to the handler, or the number of a filed application for which an environmental permit has not yet been issued. (EnvironmentalPermitID)'
/

comment on column RCRA_HD_ENV_PERMIT.ENV_PERMIT_OWNER is 'Indicates the agency that defines the other permit type. (EnvironmentalPermitOwnerName)'
/

comment on column RCRA_HD_ENV_PERMIT.ENV_PERMIT_TYPE is 'Code indicating the environmental program and/or jurisdictional authority under which an environmental permit was issued to the facility, or under which an application has been filed for which a permit has not yet been issued. This data element is applicable to TSD facilities only. (EnvironmentalPermitTypeCode)'
/

comment on column RCRA_HD_ENV_PERMIT.ENV_PERMIT_DESC is 'Description of any permit type indicated as O (Other) in the Permit Type field. (EnvironmentalPermitDescription)'
/

create index IX_HD_EN_PE_HD_HA
    on RCRA_HD_ENV_PERMIT (HD_HANDLER_ID)
/

create table RCRA_HD_NAICS
(
    HD_NAICS_ID      NUMBER(10)  not null
        constraint PK_HD_NAICS
            primary key,
    HD_HANDLER_ID    NUMBER(10)  not null
        constraint FK_HD_NAIC_HD_HAND
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE CHAR,
    NAICS_SEQ        VARCHAR2(4) not null,
    NAICS_OWNER      CHAR(2),
    NAICS_CODE       VARCHAR2(6)
)
/

comment on table RCRA_HD_NAICS is 'Schema element: NAICSIdentityDataType'
/

comment on column RCRA_HD_NAICS.HD_NAICS_ID is 'Parent: North American Industry Classification Status codes reported for the handler. (_PK)'
/

comment on column RCRA_HD_NAICS.HD_HANDLER_ID is 'Parent: North American Industry Classification Status codes reported for the handler. (_FK)'
/

comment on column RCRA_HD_NAICS.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_NAICS.NAICS_SEQ is 'Sequence number for each NAICS code for the handler. (NAICSSequenceNumber)'
/

comment on column RCRA_HD_NAICS.NAICS_OWNER is 'Indicates the agency that defines the NAICS Code. (NAICSOwnerCode)'
/

comment on column RCRA_HD_NAICS.NAICS_CODE is 'The North American Industry Classification System Code that identifies the business activities of the facility. (NAICSCode)'
/

create index IX_HD_NAI_HD_HA_ID
    on RCRA_HD_NAICS (HD_HANDLER_ID)
/

create table RCRA_HD_OTHER_ID
(
    HD_OTHER_ID_ID     NUMBER(10)   not null
        constraint PK_HD_OTHER_ID
            primary key,
    HD_HBASIC_ID       NUMBER(10)   not null
        constraint FK_HD_OTH_ID_HD_HB
            references RCRA_HD_HBASIC
                on delete cascade,
    TRANSACTION_CODE   CHAR,
    OTHER_ID           VARCHAR2(12) not null,
    RELATIONSHIP_OWNER CHAR(2),
    RELATIONSHIP_TYPE  CHAR,
    SAME_FACILITY      CHAR,
    NOTES              VARCHAR2(4000)
)
/

comment on table RCRA_HD_OTHER_ID is 'Schema element: OtherIDDataType'
/

comment on column RCRA_HD_OTHER_ID.HD_OTHER_ID_ID is 'Parent: Contains alternative identifiers for the facility. (_PK)'
/

comment on column RCRA_HD_OTHER_ID.HD_HBASIC_ID is 'Parent: Contains alternative identifiers for the facility. (_FK)'
/

comment on column RCRA_HD_OTHER_ID.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_OTHER_ID.OTHER_ID is 'Alternate facility identifier. (OtherHandlerID)'
/

comment on column RCRA_HD_OTHER_ID.RELATIONSHIP_OWNER is 'Indicates the agency that owns the Relationship. (RelationshipOwnerName)'
/

comment on column RCRA_HD_OTHER_ID.RELATIONSHIP_TYPE is 'Indicates the type of the relationship. (RelationshipTypeCode)'
/

comment on column RCRA_HD_OTHER_ID.SAME_FACILITY is 'Indicates whether the alternate Id references the same facility. (SameFacilityIndicator)'
/

comment on column RCRA_HD_OTHER_ID.NOTES is 'Notes regarding the alternative facility identifier. (OtherIDSupplementalInformationText)'
/

create index IX_HD_OT_ID_HD_HB
    on RCRA_HD_OTHER_ID (HD_HBASIC_ID)
/

create table RCRA_HD_OWNEROP
(
    HD_OWNEROP_ID       NUMBER(10) not null
        constraint PK_HD_OWNEROP
            primary key,
    HD_HANDLER_ID       NUMBER(10) not null
        constraint FK_HD_OWNE_HD_HAND
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE    CHAR,
    OWNER_OP_SEQ        NUMBER(10) not null,
    OWNER_OP_IND        CHAR(2),
    OWNER_OP_TYPE       CHAR,
    DATE_BECAME_CURRENT VARCHAR2(10),
    DATE_ENDED_CURRENT  VARCHAR2(10),
    NOTES               VARCHAR2(4000),
    FIRST_NAME          VARCHAR2(38),
    MIDDLE_INITIAL      CHAR,
    LAST_NAME           VARCHAR2(38),
    ORG_NAME            VARCHAR2(80),
    TITLE               VARCHAR2(80),
    EMAIL_ADDRESS       VARCHAR2(80),
    PHONE               VARCHAR2(15),
    PHONE_EXT           VARCHAR2(6),
    FAX                 VARCHAR2(15),
    MAIL_ADDR_NUM_TXT   VARCHAR2(12),
    STREET1             VARCHAR2(50),
    STREET2             VARCHAR2(50),
    CITY                VARCHAR2(25),
    STATE               CHAR(2),
    COUNTRY             CHAR(2),
    ZIP                 VARCHAR2(14)
)
/

comment on table RCRA_HD_OWNEROP is 'Schema element: FacilityOwnerOperatorDataType'
/

comment on column RCRA_HD_OWNEROP.HD_OWNEROP_ID is 'Parent: Handler owner and operator information. (_PK)'
/

comment on column RCRA_HD_OWNEROP.HD_HANDLER_ID is 'Parent: Handler owner and operator information. (_FK)'
/

comment on column RCRA_HD_OWNEROP.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_OWNEROP.OWNER_OP_SEQ is 'Sequential number used to order multiple occurrences of owners and operators. (OwnerOperatorSequenceNumber)'
/

comment on column RCRA_HD_OWNEROP.OWNER_OP_IND is 'Code indicating whether the data is associated with a current or previous owner or operator. The system will allow multiple current owners and operators. (OwnerOperatorIndicator)'
/

comment on column RCRA_HD_OWNEROP.OWNER_OP_TYPE is 'Code indicating the owner/operator type. (OwnerOperatorTypeCode)'
/

comment on column RCRA_HD_OWNEROP.DATE_BECAME_CURRENT is 'Date indicating when the owner/operator became current. (CurrentStartDate)'
/

comment on column RCRA_HD_OWNEROP.DATE_ENDED_CURRENT is 'Date indicating when the owner/operator changed to a different owner/operator. (CurrentEndDate)'
/

comment on column RCRA_HD_OWNEROP.NOTES is 'Notes for the facility Owner Operator. (OwnerOperatorSupplementalInformationText)'
/

comment on column RCRA_HD_OWNEROP.FIRST_NAME is 'Parent: Contact information. (FirstName)'
/

comment on column RCRA_HD_OWNEROP.MIDDLE_INITIAL is 'Parent: Contact information. (MiddleInitial)'
/

comment on column RCRA_HD_OWNEROP.LAST_NAME is 'Parent: Contact information. (LastName)'
/

comment on column RCRA_HD_OWNEROP.ORG_NAME is 'Parent: Contact information. (OrganizationFormalName)'
/

comment on column RCRA_HD_OWNEROP.TITLE is 'Title of the contact person or the title of the person who certified the handler information reported to the authorizing agency. (IndividualTitleText)'
/

comment on column RCRA_HD_OWNEROP.EMAIL_ADDRESS is 'Email address data (EmailAddressText)'
/

comment on column RCRA_HD_OWNEROP.PHONE is 'Telephone Number data (TelephoneNumberText)'
/

comment on column RCRA_HD_OWNEROP.PHONE_EXT is 'Telephone number extension (PhoneExtensionText)'
/

comment on column RCRA_HD_OWNEROP.FAX is 'Contact fax number (FaxNumberText)'
/

comment on column RCRA_HD_OWNEROP.MAIL_ADDR_NUM_TXT is 'Owner/Operator Address Street Number'
/

comment on column RCRA_HD_OWNEROP.STREET1 is 'Parent: Mailing address information. (MailingAddressText)'
/

comment on column RCRA_HD_OWNEROP.STREET2 is 'Parent: Mailing address information. (SupplementalAddressText)'
/

comment on column RCRA_HD_OWNEROP.CITY is 'Parent: Mailing address information. (MailingAddressCityName)'
/

comment on column RCRA_HD_OWNEROP.STATE is 'Parent: Mailing address information. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_HD_OWNEROP.COUNTRY is 'Parent: Mailing address information. (MailingAddressCountryName)'
/

comment on column RCRA_HD_OWNEROP.ZIP is 'Parent: Mailing address information. (MailingAddressZIPCode)'
/

create index IX_HD_OWN_HD_HA_ID
    on RCRA_HD_OWNEROP (HD_HANDLER_ID)
/

create table RCRA_HD_SEC_MATERIAL_ACTIVITY
(
    HD_SEC_MATERIAL_ACTIVITY_ID NUMBER(10)  not null
        constraint PK_HD_SEC_MATE_ACT
            primary key,
    HD_HANDLER_ID               NUMBER(10)  not null
        constraint FK_HD_SE_MA_AC_HD
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANS_CODE                  CHAR,
    HSM_SEQ_NUM                 VARCHAR2(4) not null,
    FAC_CODE_OWNER_NAME         CHAR(2),
    FAC_TYPE_CODE               CHAR(2),
    ESTIMATED_SHORT_TONS_QNTY   NUMBER(10),
    ACTL_SHORT_TONS_QNTY        NUMBER(10),
    LAND_BASED_UNIT_IND         CHAR(2),
    LAND_BASED_UNIT_IND_TEXT    VARCHAR2(255)
)
/

comment on table RCRA_HD_SEC_MATERIAL_ACTIVITY is 'Schema element: HazardousSecondaryMaterialActivityDataType'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.HD_SEC_MATERIAL_ACTIVITY_ID is 'Parent: Hazardous Secondary Material activity of the Handler (_PK)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.HD_HANDLER_ID is 'Parent: Hazardous Secondary Material activity of the Handler (_FK)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.HSM_SEQ_NUM is 'Unique number identifying the HSM Activity for the Handler (HSMSequenceNumber)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.FAC_CODE_OWNER_NAME is 'Owner of the Facility Code.  Shoule be HQ or the state code (i.e. KS) (FacilityCodeOwnerName)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.FAC_TYPE_CODE is 'Type of facility generating Hazardous Secondary Material (FacilityTypeCode)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.ESTIMATED_SHORT_TONS_QNTY is 'The estimated amount of HSM generated by the Handler (EstimatedShortTonsQuantity)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.ACTL_SHORT_TONS_QNTY is 'The actual amount of HSM generated by the Handler (ActualShortTonsQuantity)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.LAND_BASED_UNIT_IND is 'Code to indicate if the HSM is being managed in a Land Based Unit (LandBasedUnitIndicator)'
/

comment on column RCRA_HD_SEC_MATERIAL_ACTIVITY.LAND_BASED_UNIT_IND_TEXT is 'Descriptive text describing the code to indicate if the HSM is being managed in a Land Based Unit (Data publishing only)'
/

create index IX_HD_SE_MA_AC_HD
    on RCRA_HD_SEC_MATERIAL_ACTIVITY (HD_HANDLER_ID)
/

create table RCRA_HD_SEC_WASTE_CODE
(
    HD_SEC_WASTE_CODE_ID        NUMBER(10) not null
        constraint PK_HD_SEC_WAST_COD
            primary key,
    HD_SEC_MATERIAL_ACTIVITY_ID NUMBER(10) not null
        constraint FK_HD_SE_WA_CO_HD
            references RCRA_HD_SEC_MATERIAL_ACTIVITY
                on delete cascade,
    TRANSACTION_CODE            CHAR,
    WASTE_CODE_OWNER            CHAR(2),
    WASTE_CODE_TYPE             VARCHAR2(6)
)
/

comment on table RCRA_HD_SEC_WASTE_CODE is 'Schema element: SecondaryHandlerWasteCodeDataType'
/

comment on column RCRA_HD_SEC_WASTE_CODE.HD_SEC_WASTE_CODE_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)'
/

comment on column RCRA_HD_SEC_WASTE_CODE.HD_SEC_MATERIAL_ACTIVITY_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)'
/

comment on column RCRA_HD_SEC_WASTE_CODE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_OWNER is 'Indicates the agency that owns the data record. (WasteCodeOwnerName)'
/

comment on column RCRA_HD_SEC_WASTE_CODE.WASTE_CODE_TYPE is 'Code used to describe hazardous waste. (WasteCode)'
/

create index IX_HD_SE_WA_CO_HD
    on RCRA_HD_SEC_WASTE_CODE (HD_SEC_MATERIAL_ACTIVITY_ID)
/

create table RCRA_HD_STATE_ACTIVITY
(
    HD_STATE_ACTIVITY_ID NUMBER(10)  not null
        constraint PK_HD_STATE_ACTIVI
            primary key,
    HD_HANDLER_ID        NUMBER(10)  not null
        constraint FK_HD_STA_AC_HD_HA
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE     CHAR,
    STATE_ACTIVITY_OWNER CHAR(2)     not null,
    STATE_ACTIVITY_TYPE  VARCHAR2(5) not null
)
/

comment on table RCRA_HD_STATE_ACTIVITY is 'Schema element: StateActivityDataType'
/

comment on column RCRA_HD_STATE_ACTIVITY.HD_STATE_ACTIVITY_ID is 'Parent: State waste activity of the handler. (_PK)'
/

comment on column RCRA_HD_STATE_ACTIVITY.HD_HANDLER_ID is 'Parent: State waste activity of the handler. (_FK)'
/

comment on column RCRA_HD_STATE_ACTIVITY.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_OWNER is 'Indicates the agency that defines the state activity type. (StateActivityOwnerName)'
/

comment on column RCRA_HD_STATE_ACTIVITY.STATE_ACTIVITY_TYPE is 'Code indicating the type of state activity. (StateActivityTypeCode)'
/

create index IX_HD_ST_AC_HD_HA
    on RCRA_HD_STATE_ACTIVITY (HD_HANDLER_ID)
/

create table RCRA_HD_UNIVERSAL_WASTE
(
    HD_UNIVERSAL_WASTE_ID NUMBER(10) not null
        constraint PK_HD_UNIVER_WASTE
            primary key,
    HD_HANDLER_ID         NUMBER(10) not null
        constraint FK_HD_UNI_WA_HD_HA
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE      CHAR,
    UNIVERSAL_WASTE_OWNER CHAR(2),
    UNIVERSAL_WASTE_TYPE  CHAR,
    ACCUMULATED           CHAR,
    GENERATED             CHAR
)
/

comment on table RCRA_HD_UNIVERSAL_WASTE is 'Schema element: UniversalWasteActivityDataType'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.HD_UNIVERSAL_WASTE_ID is 'Parent: Information about universal waste generated by the handler. (_PK)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.HD_HANDLER_ID is 'Parent: Information about universal waste generated by the handler. (_FK)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.UNIVERSAL_WASTE_OWNER is 'Indicates the agency that defines the universal waste type. (UniversalWasteOwnerName)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.UNIVERSAL_WASTE_TYPE is 'Code indicating the type of universal waste. (UniversalWasteTypeCode)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.ACCUMULATED is 'Code indicating that the handler is engaged in accumulating waste on site. (AccumulatedWasteCode)'
/

comment on column RCRA_HD_UNIVERSAL_WASTE.GENERATED is 'Code indicating that the handler is engaged in generating waste on site. (GeneratedHandlerCode)'
/

create index IX_HD_UN_WA_HD_HA
    on RCRA_HD_UNIVERSAL_WASTE (HD_HANDLER_ID)
/

create table RCRA_HD_WASTE_CODE
(
    HD_WASTE_CODE_ID NUMBER(10) not null
        constraint PK_HD_WASTE_CODE
            primary key,
    HD_HANDLER_ID    NUMBER(10) not null
        constraint FK_HD_WAS_CO_HD_HA
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE CHAR,
    WASTE_CODE_OWNER CHAR(2),
    WASTE_CODE_TYPE  VARCHAR2(6)
)
/

comment on table RCRA_HD_WASTE_CODE is 'Schema element: HandlerWasteCodeDataType'
/

comment on column RCRA_HD_WASTE_CODE.HD_WASTE_CODE_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)'
/

comment on column RCRA_HD_WASTE_CODE.HD_HANDLER_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)'
/

comment on column RCRA_HD_WASTE_CODE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_WASTE_CODE.WASTE_CODE_OWNER is 'Indicates the agency that owns the data record. (WasteCodeOwnerName)'
/

comment on column RCRA_HD_WASTE_CODE.WASTE_CODE_TYPE is 'Code used to describe hazardous waste. (WasteCode)'
/

create index IX_HD_WA_CO_HD_HA
    on RCRA_HD_WASTE_CODE (HD_HANDLER_ID)
/

create table RCRA_PRM_FAC_SUBM
(
    PRM_FAC_SUBM_ID NUMBER(10)   not null
        constraint PK_PRM_FAC_SUBM
            primary key,
    HANDLER_ID      VARCHAR2(12) not null
)
/

comment on table RCRA_PRM_FAC_SUBM is 'Schema element: PermitFacilitySubmissionDataType'
/

comment on column RCRA_PRM_FAC_SUBM.PRM_FAC_SUBM_ID is 'Parent:
	This is the root element for this flow XML Schema.
	 (_PK)'
/

comment on column RCRA_PRM_FAC_SUBM.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

create table RCRA_PRM_SERIES
(
    PRM_SERIES_ID               NUMBER(10) not null
        constraint PK_PRM_SERIES
            primary key,
    PRM_FAC_SUBM_ID             NUMBER(10) not null
        constraint FK_PRM_SR_PR_FC_SB
            references RCRA_PRM_FAC_SUBM
                on delete cascade,
    TRANS_CODE                  CHAR,
    PERMIT_SERIES_SEQ_NUM       NUMBER(10) not null,
    PERMIT_SERIES_NAME          VARCHAR2(40),
    RESP_PERSON_DATA_OWNER_CODE CHAR(2),
    RESP_PERSON_ID              VARCHAR2(5),
    SUPP_INFO_TXT               VARCHAR2(2000),
    ACTIVE_SERIES_IND           CHAR,
    CREATED_BY_USERID           VARCHAR2(255),
    P_CREATED_DATE              TIMESTAMP(6),
    LAST_UPDT_BY                VARCHAR2(255),
    LAST_UPDT_DATE              DATE
)
/

comment on table RCRA_PRM_SERIES is 'Schema element: PermitSeriesDataType'
/

comment on column RCRA_PRM_SERIES.PRM_SERIES_ID is 'Parent: Permit series Data (_PK)'
/

comment on column RCRA_PRM_SERIES.PRM_FAC_SUBM_ID is 'Parent: Permit series Data (_FK)'
/

comment on column RCRA_PRM_SERIES.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_SERIES.PERMIT_SERIES_SEQ_NUM is 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)'
/

comment on column RCRA_PRM_SERIES.PERMIT_SERIES_NAME is 'Name or number assigned by the implementing agency. (PermitSeriesName)'
/

comment on column RCRA_PRM_SERIES.RESP_PERSON_DATA_OWNER_CODE is 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_PRM_SERIES.RESP_PERSON_ID is 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)'
/

comment on column RCRA_PRM_SERIES.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_PRM_SERIES.ACTIVE_SERIES_IND is 'Indicates if the permit series is active. Possible values are: Y/N (ActiveSeriesIndicator)'
/

comment on column RCRA_PRM_SERIES.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_PRM_SERIES.P_CREATED_DATE is 'Creation date (PCreatedDate)'
/

create index IX_PR_SR_PR_FC_SB
    on RCRA_PRM_SERIES (PRM_FAC_SUBM_ID)
/

create table RCRA_PRM_EVENT
(
    PRM_EVENT_ID                 NUMBER(10)  not null
        constraint PK_PRM_EVENT
            primary key,
    PRM_SERIES_ID                NUMBER(10)  not null
        constraint FK_PRM_EVN_PRM_SRS
            references RCRA_PRM_SERIES
                on delete cascade,
    TRANS_CODE                   CHAR,
    ACT_LOC_CODE                 CHAR(2)     not null,
    PERMIT_EVENT_DATA_OWNER_CODE CHAR(2)     not null,
    PERMIT_EVENT_CODE            VARCHAR2(7) not null,
    EVENT_AGN_CODE               CHAR        not null,
    EVENT_SEQ_NUM                NUMBER(10)  not null,
    ACTL_DATE                    DATE,
    ORIGINAL_SCHEDULE_DATE       DATE,
    NEW_SCHEDULE_DATE            DATE,
    RESP_PERSON_DATA_OWNER_CODE  CHAR(2),
    RESP_PERSON_ID               VARCHAR2(5),
    EVENT_SUBORG_DATA_OWNER_CODE CHAR(2),
    EVENT_SUBORG_CODE            VARCHAR2(10),
    SUPP_INFO_TXT                VARCHAR2(2000),
    CREATED_BY_USERID            VARCHAR2(255),
    P_CREATED_DATE               TIMESTAMP(6),
    LAST_UPDT_BY                 VARCHAR2(255),
    LAST_UPDT_DATE               DATE
)
/

comment on table RCRA_PRM_EVENT is 'Schema element: PermitEventDataType'
/

comment on column RCRA_PRM_EVENT.PRM_EVENT_ID is 'Parent: Permit event Data (_PK)'
/

comment on column RCRA_PRM_EVENT.PRM_SERIES_ID is 'Parent: Permit event Data (_FK)'
/

comment on column RCRA_PRM_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_EVENT.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_PRM_EVENT.PERMIT_EVENT_DATA_OWNER_CODE is 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)'
/

comment on column RCRA_PRM_EVENT.PERMIT_EVENT_CODE is 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)'
/

comment on column RCRA_PRM_EVENT.EVENT_AGN_CODE is 'Agency responsible for the event. (EventAgencyCode)'
/

comment on column RCRA_PRM_EVENT.EVENT_SEQ_NUM is 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)'
/

comment on column RCRA_PRM_EVENT.ACTL_DATE is 'Date on which actual completion of an event occurs. (ActualDate)'
/

comment on column RCRA_PRM_EVENT.ORIGINAL_SCHEDULE_DATE is 'The original scheduled completion date for an event. This date cannot be changed once entered. Slippage of the scheduled completion date is recorded in the NewScheduleDate Data Element. (OriginalScheduleDate)'
/

comment on column RCRA_PRM_EVENT.NEW_SCHEDULE_DATE is 'Revised scheduled completion date of the event. This date is used in conjunction with the Original Scheduled Event Date to allow tracking scheduled date slippage. As the scheduled date changes, this field is updated with the new date and the Original Scheduled Event Date is not changed. (NewScheduleDate)'
/

comment on column RCRA_PRM_EVENT.RESP_PERSON_DATA_OWNER_CODE is 'Indicates the agency that defines the person identifier. (ResponsiblePersonDataOwnerCode)'
/

comment on column RCRA_PRM_EVENT.RESP_PERSON_ID is 'Code indicating the person within the agency responsible for conducting the evaluation or who is the responsible Authority. (ResponsiblePersonID)'
/

comment on column RCRA_PRM_EVENT.EVENT_SUBORG_DATA_OWNER_CODE is 'Event responsible suborganization owner. (EventSuborganizationDataOwnerCode)'
/

comment on column RCRA_PRM_EVENT.EVENT_SUBORG_CODE is 'Event responsible suborganization. (EventSuborganizationCode)'
/

comment on column RCRA_PRM_EVENT.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_PRM_EVENT.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_PRM_EVENT.P_CREATED_DATE is 'Creation date (PCreatedDate)'
/

create index IX_PRM_EV_PR_SR_ID
    on RCRA_PRM_EVENT (PRM_SERIES_ID)
/

create table RCRA_PRM_EVENT_COMMITMENT
(
    PRM_EVENT_COMMITMENT_ID NUMBER(10) not null
        constraint PK_PRM_EVNT_CMMTMN
            primary key,
    PRM_EVENT_ID            NUMBER(10) not null
        constraint FK_PRM_EV_CM_PR_EV
            references RCRA_PRM_EVENT
                on delete cascade,
    TRANS_CODE              CHAR,
    COMMIT_LEAD             CHAR(2)    not null,
    COMMIT_SEQ_NUM          NUMBER(10) not null
)
/

comment on table RCRA_PRM_EVENT_COMMITMENT is 'Schema element: PermitEventCommitmentDataType'
/

comment on column RCRA_PRM_EVENT_COMMITMENT.PRM_EVENT_COMMITMENT_ID is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_PK)'
/

comment on column RCRA_PRM_EVENT_COMMITMENT.PRM_EVENT_ID is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (_FK)'
/

comment on column RCRA_PRM_EVENT_COMMITMENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_EVENT_COMMITMENT.COMMIT_LEAD is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentLead)'
/

comment on column RCRA_PRM_EVENT_COMMITMENT.COMMIT_SEQ_NUM is 'Parent: Linking Data for Commitment/Initiative and Corrective Action or Permitting Events. (CommitmentSequenceNumber)'
/

create index IX_PR_EV_CM_PR_EV
    on RCRA_PRM_EVENT_COMMITMENT (PRM_EVENT_ID)
/

create table RCRA_PRM_UNIT
(
    PRM_UNIT_ID         NUMBER(10) not null
        constraint PK_PRM_UNIT
            primary key,
    PRM_FAC_SUBM_ID     NUMBER(10) not null
        constraint FK_PRM_UN_PR_FC_SB
            references RCRA_PRM_FAC_SUBM
                on delete cascade,
    TRANS_CODE          CHAR,
    PERMIT_UNIT_SEQ_NUM NUMBER(10) not null,
    PERMIT_UNIT_NAME    VARCHAR2(40),
    SUPP_INFO_TXT       VARCHAR2(2000),
    ACTIVE_UNIT_IND     CHAR,
    CREATED_BY_USERID   VARCHAR2(255),
    P_CREATED_DATE      TIMESTAMP(6),
    LAST_UPDT_BY        VARCHAR2(255),
    LAST_UPDT_DATE      DATE
)
/

comment on table RCRA_PRM_UNIT is 'Schema element: PermitUnitDataType'
/

comment on column RCRA_PRM_UNIT.PRM_UNIT_ID is 'Parent: Permit Unit Data (_PK)'
/

comment on column RCRA_PRM_UNIT.PRM_FAC_SUBM_ID is 'Parent: Permit Unit Data (_FK)'
/

comment on column RCRA_PRM_UNIT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_UNIT.PERMIT_UNIT_SEQ_NUM is 'System-generated value used to uniquely identify a process unit. (PermitUnitSequenceNumber)'
/

comment on column RCRA_PRM_UNIT.PERMIT_UNIT_NAME is 'Name or number assigned by the implementing agency to identify a process unit group. (PermitUnitName)'
/

comment on column RCRA_PRM_UNIT.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_PRM_UNIT.ACTIVE_UNIT_IND is 'Indicates if the permit unit is active. Possible values are: Y/N (ActiveUnitIndicator)'
/

comment on column RCRA_PRM_UNIT.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_PRM_UNIT.P_CREATED_DATE is 'Creation date (PCreatedDate)'
/

create index IX_PR_UN_PR_FC_SB
    on RCRA_PRM_UNIT (PRM_FAC_SUBM_ID)
/

create table RCRA_PRM_UNIT_DETAIL
(
    PRM_UNIT_DETAIL_ID             NUMBER(10) not null
        constraint PK_PRM_UNIT_DETAIL
            primary key,
    PRM_UNIT_ID                    NUMBER(10) not null
        constraint FK_PRM_UN_DT_PR_UN
            references RCRA_PRM_UNIT
                on delete cascade,
    TRANS_CODE                     CHAR,
    PERMIT_UNIT_DETAIL_SEQ_NUM     NUMBER(10) not null,
    PROC_UNIT_DATA_OWNER_CODE      CHAR(2),
    PROC_UNIT_CODE                 VARCHAR2(3),
    PERMIT_STAT_EFFC_DATE          DATE,
    PERMIT_UNIT_CAP_QNTY           NUMBER(14, 3),
    CAP_TYPE_CODE                  CHAR,
    COMMER_STAT_CODE               CHAR,
    LEGAL_OPER_STAT_DATA_OWNER_CDE CHAR(2),
    LEGAL_OPER_STAT_CODE           VARCHAR2(4),
    MEASUREMENT_UNIT_DATA_OWNR_CDE CHAR(2),
    MEASUREMENT_UNIT_CODE          CHAR,
    NUM_OF_UNITS_COUNT             NUMBER(10),
    STANDARD_PERMIT_IND            CHAR,
    SUPP_INFO_TXT                  VARCHAR2(2000),
    CURRENT_UNIT_DETAIL_IND        CHAR,
    CREATED_BY_USERID              VARCHAR2(255),
    P_CREATED_DATE                 TIMESTAMP(6),
    LAST_UPDT_BY                   VARCHAR2(255),
    LAST_UPDT_DATE                 DATE
)
/

comment on table RCRA_PRM_UNIT_DETAIL is 'Schema element: PermitUnitDetailDataType'
/

comment on column RCRA_PRM_UNIT_DETAIL.PRM_UNIT_DETAIL_ID is 'Parent: Permit Unit Detail Data (_PK)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PRM_UNIT_ID is 'Parent: Permit Unit Detail Data (_FK)'
/

comment on column RCRA_PRM_UNIT_DETAIL.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_DETAIL_SEQ_NUM is 'System-generated value used to uniquely identify a process unit detail. (PermitUnitDetailSequenceNumber)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PROC_UNIT_DATA_OWNER_CODE is 'Indicates the agency that defines the process code. (ProcessUnitDataOwnerCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PROC_UNIT_CODE is 'Code specifying the unit group''s current waste treatment, storage, or disposal process. (ProcessUnitCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PERMIT_STAT_EFFC_DATE is 'Date specifying when the other information in the process detail data record (i.e., process, capacity, and operating and legal status) became effective. (PermitStatusEffectiveDate)'
/

comment on column RCRA_PRM_UNIT_DETAIL.PERMIT_UNIT_CAP_QNTY is 'Permitted capacity of the unit (PermitUnitCapacityQuantity)'
/

comment on column RCRA_PRM_UNIT_DETAIL.CAP_TYPE_CODE is 'Code indicating the type of capacity. (CapacityTypeCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.COMMER_STAT_CODE is 'Code indicating that the facility, whether public or private, accepts hazardous waste for the process unit group from a third party. (CommercialStatusCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.LEGAL_OPER_STAT_DATA_OWNER_CDE is 'Indicates the agency that defines the legal/operating status code. (LegalOperatingStatusDataOwnerCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.LEGAL_OPER_STAT_CODE is 'Code used to indicate programmatic (operating and legal status) conditions that reflect RCRA program activity requirements of a unit. (LegalOperatingStatusCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.MEASUREMENT_UNIT_DATA_OWNR_CDE is 'Indicates the agency that defines the unit of measure. (MeasurementUnitDataOwnerCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.MEASUREMENT_UNIT_CODE is 'Indicates the unit of measure. (MeasurementUnitCode)'
/

comment on column RCRA_PRM_UNIT_DETAIL.NUM_OF_UNITS_COUNT is 'Total number of units of the same process grouped together to form a single process unit group. (NumberOfUnitsCount)'
/

comment on column RCRA_PRM_UNIT_DETAIL.STANDARD_PERMIT_IND is 'Indicates whether or not the permit is a standardized permit. (StandardPermitIndicator)'
/

comment on column RCRA_PRM_UNIT_DETAIL.SUPP_INFO_TXT is 'Notes providing more information. (SupplementalInformationText)'
/

comment on column RCRA_PRM_UNIT_DETAIL.CURRENT_UNIT_DETAIL_IND is 'Indicates if the unit detail is current. Possible values are: Y/N (CurrentUnitDetailIndicator)'
/

comment on column RCRA_PRM_UNIT_DETAIL.CREATED_BY_USERID is 'User id of record creation (CreatedByUserid)'
/

comment on column RCRA_PRM_UNIT_DETAIL.P_CREATED_DATE is 'Creation date (PCreatedDate)'
/

create index IX_PR_UN_DT_PR_UN
    on RCRA_PRM_UNIT_DETAIL (PRM_UNIT_ID)
/

create table RCRA_PRM_RELATED_EVENT
(
    PRM_RELATED_EVENT_ID         NUMBER(10)  not null
        constraint PK_PRM_RELTED_EVNT
            primary key,
    PRM_UNIT_DETAIL_ID           NUMBER(10)  not null
        constraint FK_PR_RL_EV_PR_UN
            references RCRA_PRM_UNIT_DETAIL
                on delete cascade,
    TRANS_CODE                   CHAR,
    ACT_LOC_CODE                 CHAR(2)     not null,
    PERMIT_SERIES_SEQ_NUM        NUMBER(10)  not null,
    PERMIT_EVENT_DATA_OWNER_CODE CHAR(2)     not null,
    PERMIT_EVENT_CODE            VARCHAR2(7) not null,
    EVENT_AGN_CODE               CHAR        not null,
    EVENT_SEQ_NUM                NUMBER(10)  not null
)
/

comment on table RCRA_PRM_RELATED_EVENT is 'Schema element: PermitRelatedEventDataType'
/

comment on column RCRA_PRM_RELATED_EVENT.PRM_RELATED_EVENT_ID is 'Parent: Linking Data for Permitted Units and Permitting Events (_PK)'
/

comment on column RCRA_PRM_RELATED_EVENT.PRM_UNIT_DETAIL_ID is 'Parent: Linking Data for Permitted Units and Permitting Events (_FK)'
/

comment on column RCRA_PRM_RELATED_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_RELATED_EVENT.ACT_LOC_CODE is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_PRM_RELATED_EVENT.PERMIT_SERIES_SEQ_NUM is 'System-generated value used to uniquely identify a permit series. (PermitSeriesSequenceNumber)'
/

comment on column RCRA_PRM_RELATED_EVENT.PERMIT_EVENT_DATA_OWNER_CODE is 'Indicates the agency that defines the event. (PermitEventDataOwnerCode)'
/

comment on column RCRA_PRM_RELATED_EVENT.PERMIT_EVENT_CODE is 'Code used to indicate a specific permitting/closure program event and status that has actually occurred or is scheduled to occur. (PermitEventCode)'
/

comment on column RCRA_PRM_RELATED_EVENT.EVENT_AGN_CODE is 'Agency responsible for the event. (EventAgencyCode)'
/

comment on column RCRA_PRM_RELATED_EVENT.EVENT_SEQ_NUM is 'System-generated value used to uniquely identify multiple occurrences of a corrective action event. (EventSequenceNumber)'
/

create index IX_PR_RL_EV_PR_UN
    on RCRA_PRM_RELATED_EVENT (PRM_UNIT_DETAIL_ID)
/

create table RCRA_PRM_WASTE_CODE
(
    PRM_WASTE_CODE_ID  NUMBER(10) not null
        constraint PK_PRM_WASTE_CODE
            primary key,
    PRM_UNIT_DETAIL_ID NUMBER(10) not null
        constraint FK_PR_WS_CD_PR_UN
            references RCRA_PRM_UNIT_DETAIL
                on delete cascade,
    TRANSACTION_CODE   CHAR,
    WASTE_CODE_OWNER   CHAR(2),
    WASTE_CODE_TYPE    VARCHAR2(6)
)
/

comment on table RCRA_PRM_WASTE_CODE is 'Schema element: PermitHandlerWasteCodeDataType'
/

comment on column RCRA_PRM_WASTE_CODE.PRM_WASTE_CODE_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_PK)'
/

comment on column RCRA_PRM_WASTE_CODE.PRM_UNIT_DETAIL_ID is 'Parent: Hazardous waste codes describing the handler''s hazardous waste streams. (_FK)'
/

comment on column RCRA_PRM_WASTE_CODE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_WASTE_CODE.WASTE_CODE_OWNER is 'Indicates the agency that owns the data record. (WasteCodeOwnerName)'
/

comment on column RCRA_PRM_WASTE_CODE.WASTE_CODE_TYPE is 'Code used to describe hazardous waste. (WasteCode)'
/

create index IX_PR_WS_CD_PR_UN
    on RCRA_PRM_WASTE_CODE (PRM_UNIT_DETAIL_ID)
/

create table RCRA_SUBMISSIONHISTORY
(
    SUBMISSIONHISTORY_ID NUMBER(10)   not null
        constraint PK_SUBMISSIONHISTO
            primary key,
    SCHEDULERUNDATE      DATE         not null,
    TRANSACTIONID        VARCHAR2(50) not null,
    PROCESSINGSTATUS     VARCHAR2(50) not null,
    SUBMISSIONTYPE       VARCHAR2(50) not null
)
/

comment on table RCRA_SUBMISSIONHISTORY is 'Schema element: SubmissionHistoryDataType'
/

create table RCRA_HD_LQG_CLOSURE
(
    HD_LQG_CLOSURE_ID     NUMBER(10) not null
        constraint PK_HD_LQG_CLOSURE
            primary key,
    HD_HANDLER_ID         NUMBER(10) not null
        constraint FK_HD_LQG_CLOS_HANDLER_ID
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE      CHAR,
    CLOSURE_TYPE          CHAR,
    EXPECTED_CLOSURE_DATE DATE,
    NEW_CLOSURE_DATE      DATE,
    DATE_CLOSED           DATE,
    IN_COMPLIANCE_IND     CHAR
)
/

comment on column RCRA_HD_LQG_CLOSURE.HD_LQG_CLOSURE_ID is 'Parent: LQG closure info for a Handler'
/

comment on column RCRA_HD_LQG_CLOSURE.HD_HANDLER_ID is 'Parent: Handler data (_FK)'
/

comment on column RCRA_HD_LQG_CLOSURE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_LQG_CLOSURE.CLOSURE_TYPE is 'Type of the closure. (ClosureType)'
/

comment on column RCRA_HD_LQG_CLOSURE.EXPECTED_CLOSURE_DATE is 'Date of expected closure. (ExpectedClosureDate)'
/

comment on column RCRA_HD_LQG_CLOSURE.NEW_CLOSURE_DATE is 'New closure date. (NewClosureDate)'
/

comment on column RCRA_HD_LQG_CLOSURE.DATE_CLOSED is 'Date of closed. (DateClosed)'
/

comment on column RCRA_HD_LQG_CLOSURE.IN_COMPLIANCE_IND is 'Type of in compliance. (InComplianceIndicator)'
/

create table RCRA_HD_LQG_CONSOLIDATION
(
    HD_LQG_CONSOLIDATION_ID NUMBER(10) not null
        constraint PK_HD_LQG_CONSOLIDATION
            primary key,
    HD_HANDLER_ID           NUMBER(10) not null
        constraint FK_HD_LQG_CONSOL_HANDLER_ID
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE        CHAR,
    SEQ_NUMBER              NUMBER     not null,
    HANDLER_ID              VARCHAR2(12),
    HANDLER_NAME            VARCHAR2(80),
    MAIL_STREET_NUMBER      VARCHAR2(12),
    MAIL_STREET1            VARCHAR2(50),
    MAIL_STREET2            VARCHAR2(50),
    MAIL_CITY               VARCHAR2(25),
    MAIL_STATE              CHAR(2),
    MAIL_COUNTRY            CHAR(2),
    MAIL_ZIP                VARCHAR2(14),
    CONTACT_FIRST_NAME      VARCHAR2(38),
    CONTACT_MIDDLE_INITIAL  CHAR,
    CONTACT_LAST_NAME       VARCHAR2(38),
    CONTACT_ORG_NAME        VARCHAR2(80),
    CONTACT_TITLE           VARCHAR2(80),
    CONTACT_EMAIL_ADDRESS   VARCHAR2(80),
    CONTACT_PHONE           VARCHAR2(15),
    CONTACT_PHONE_EXT       VARCHAR2(6),
    CONTACT_FAX             VARCHAR2(15)
)
/

comment on column RCRA_HD_LQG_CONSOLIDATION.HD_LQG_CONSOLIDATION_ID is 'Parent: LQG consolidation info for a Handler'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.HD_HANDLER_ID is 'Parent: Handler data (_FK)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.SEQ_NUMBER is 'Unique number that identifies the Consolidation. (ConsolidationSequenceNumber)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerID)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.HANDLER_NAME is 'Name of the Handler (HandlerName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET_NUMBER is 'Parent: Mailing address information. (MailingAddressNumberText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET1 is 'Parent: Mailing address information. (MailingAddressText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_STREET2 is 'Parent: Mailing address information. (SupplementalAddressText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_CITY is 'Parent: Mailing address information. (MailingAddressCityName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_STATE is 'Parent: Mailing address information. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_COUNTRY is 'Parent: Mailing address information. (MailingAddressCountryName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.MAIL_ZIP is 'Parent: Mailing address information. (MailingAddressZIPCode)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_FIRST_NAME is 'Parent: First name of the contact. (FirstName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_MIDDLE_INITIAL is 'Parent: Middle initial of the contact. (MiddleInitial)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_LAST_NAME is 'Parent: Last name of the contact. (LastName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_ORG_NAME is 'Parent: Name of the contact organization. (OrganizationFormalName)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_TITLE is 'Title of the contact person (IndividualTitleText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_EMAIL_ADDRESS is 'Email address data (EmailAddressText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE is 'Telephone Number data (TelephoneNumberText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_PHONE_EXT is 'Telephone number extension (PhoneExtensionText)'
/

comment on column RCRA_HD_LQG_CONSOLIDATION.CONTACT_FAX is 'Contact fax number (FaxNumberText)'
/

create table RCRA_HD_EPISODIC_EVENT
(
    HD_EPISODIC_EVENT_ID   NUMBER(10) not null
        constraint PK_HD_EPISODIC_EVENT
            primary key,
    HD_HANDLER_ID          NUMBER(10) not null
        constraint FK_HD_EPIS_EVT_HANDLER_ID
            references RCRA_HD_HANDLER
                on delete cascade,
    TRANSACTION_CODE       CHAR,
    EVENT_OWNER            CHAR(2),
    EVENT_TYPE             VARCHAR2(3),
    CONTACT_FIRST_NAME     VARCHAR2(38),
    CONTACT_MIDDLE_INITIAL CHAR,
    CONTACT_LAST_NAME      VARCHAR2(38),
    CONTACT_ORG_NAME       VARCHAR2(80),
    CONTACT_TITLE          VARCHAR2(80),
    CONTACT_EMAIL_ADDRESS  VARCHAR2(80),
    CONTACT_PHONE          VARCHAR2(15),
    CONTACT_PHONE_EXT      VARCHAR2(6),
    CONTACT_FAX            VARCHAR2(15),
    START_DATE             DATE,
    END_DATE               DATE
)
/

comment on column RCRA_HD_EPISODIC_EVENT.HD_EPISODIC_EVENT_ID is 'Parent: Episodic event info for a Handler'
/

comment on column RCRA_HD_EPISODIC_EVENT.HD_HANDLER_ID is 'Parent: Handler data (_FK)'
/

comment on column RCRA_HD_EPISODIC_EVENT.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_EPISODIC_EVENT.EVENT_OWNER is 'Owner of the episodic event. (EpisodicEventOwner)'
/

comment on column RCRA_HD_EPISODIC_EVENT.EVENT_TYPE is 'Type of the episodic event. (EpisodicEventType)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_FIRST_NAME is 'First name of the contact. (FirstName)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_MIDDLE_INITIAL is 'Middle initial of the contact. (MiddleInitial)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_LAST_NAME is 'Last name of the contact. (LastName)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_ORG_NAME is 'Contact organization name. (OrganizationFormalName)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_TITLE is 'Title of the contact. (IndividualTitleText)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_EMAIL_ADDRESS is 'Email address of the contact. (EmailAddressText)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE is 'Telephone number of the contact. (TelephoneNumberText)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_PHONE_EXT is 'Phone extension of the contact. (PhoneExtensionText)'
/

comment on column RCRA_HD_EPISODIC_EVENT.CONTACT_FAX is 'Fax number of the contact. (FaxNumberText)'
/

comment on column RCRA_HD_EPISODIC_EVENT.START_DATE is 'Episodic event start event. (EpisodicEventStartDate)'
/

comment on column RCRA_HD_EPISODIC_EVENT.END_DATE is 'Episodic event end event. (EpisodicEventEndDate)'
/

create table RCRA_HD_EPISODIC_WASTE
(
    HD_EPISODIC_WASTE_ID NUMBER(10) not null
        constraint PK_HD_EPISODIC_WASTE
            primary key,
    HD_EPISODIC_EVENT_ID NUMBER(10) not null
        constraint FK_HD_EPIS_WASTE_EVT_ID
            references RCRA_HD_EPISODIC_EVENT
                on delete cascade,
    TRANSACTION_CODE     CHAR,
    SEQ_NUMBER           NUMBER,
    WASTE_DESC           VARCHAR2(4000),
    EST_QNTY             NUMBER
)
/

comment on column RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_WASTE_ID is 'Parent: Episodic waste info for a Handler Episodic Event'
/

comment on column RCRA_HD_EPISODIC_WASTE.HD_EPISODIC_EVENT_ID is 'Parent: Episode event data (_FK)'
/

comment on column RCRA_HD_EPISODIC_WASTE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_EPISODIC_WASTE.SEQ_NUMBER is 'Unique number that identifies the episodic waste. (EpisodicWasteSequenceNumber)'
/

comment on column RCRA_HD_EPISODIC_WASTE.WASTE_DESC is 'Waste description. (WasteDescription)'
/

comment on column RCRA_HD_EPISODIC_WASTE.EST_QNTY is 'The quantity of waste that is handled by each process code. This element pertains only to Part A submissions. (EstimatedQuantity)'
/

create table RCRA_HD_EPISODIC_WASTE_CODE
(
    HD_EPISODIC_WASTE_CODE_ID NUMBER(10) not null
        constraint PK_HD_EPISODIC_WASTE_CODE
            primary key,
    HD_EPISODIC_WASTE_ID      NUMBER(10) not null
        constraint FK_HD_EPIS_WASTE_CD_WASTE_ID
            references RCRA_HD_EPISODIC_WASTE
                on delete cascade,
    TRANSACTION_CODE          CHAR,
    WASTE_CODE_OWNER          CHAR(2),
    WASTE_CODE                VARCHAR2(6),
    WASTE_CODE_TEXT           VARCHAR2(4000)
)
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_CODE_ID is 'Parent: Episodic waste code details for Handler Episodic Waste'
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.HD_EPISODIC_WASTE_ID is 'Parent: Episodic waste data (_FK)'
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.TRANSACTION_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_OWNER is 'Owner and definer of the waste code. (WasteCodeOwnerName)'
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE is 'Code used to describe hazardous waste. (WasteCode)'
/

comment on column RCRA_HD_EPISODIC_WASTE_CODE.WASTE_CODE_TEXT is 'Descriptive text describing the Waste Code (Data publishing only). (WasteCodeText)'
/

create table RCRA_RU_REPORT_UNIV
(
    RU_REPORT_UNIV_ID              NUMBER(10)   not null
        constraint PK_RU_REPORT_UNIV
            primary key,
    HANDLER_ID                     VARCHAR2(12) not null,
    ACTIVITY_LOCATION              CHAR(2)      not null,
    SOURCE_TYPE                    CHAR,
    SEQ_NUMBER                     NUMBER,
    RECEIVE_DATE                   DATE,
    HANDLER_NAME                   VARCHAR2(80),
    NON_NOTIFIER_IND               CHAR,
    ACCESSIBILITY                  CHAR,
    REPORT_CYCLE                   NUMBER,
    REGION                         CHAR(2),
    STATE                          CHAR(2),
    EXTRACT_FLAG                   CHAR,
    ACTIVE_SITE                    VARCHAR2(5),
    COUNTY_CODE                    VARCHAR2(5),
    COUNTY_NAME                    VARCHAR2(80),
    LOCATION_STREET_NUMBER         VARCHAR2(12),
    LOCATION_STREET1               VARCHAR2(50),
    LOCATION_STREET2               VARCHAR2(50),
    LOCATION_CITY                  VARCHAR2(25),
    LOCATION_STATE                 CHAR(2),
    LOCATION_COUNTRY               CHAR(2),
    LOCATION_ZIP                   VARCHAR2(14),
    MAIL_STREET_NUMBER             VARCHAR2(12),
    MAIL_STREET1                   VARCHAR2(50),
    MAIL_STREET2                   VARCHAR2(50),
    MAIL_CITY                      VARCHAR2(25),
    MAIL_STATE                     CHAR(2),
    MAIL_COUNTRY                   CHAR(2),
    MAIL_ZIP                       VARCHAR2(14),
    CONTACT_STREET_NUMBER          VARCHAR2(12),
    CONTACT_STREET1                VARCHAR2(50),
    CONTACT_STREET2                VARCHAR2(50),
    CONTACT_CITY                   VARCHAR2(25),
    CONTACT_STATE                  CHAR(2),
    CONTACT_COUNTRY                CHAR(2),
    CONTACT_ZIP                    VARCHAR2(14),
    CONTACT_NAME                   VARCHAR2(80),
    CONTACT_PHONE                  VARCHAR2(22),
    CONTACT_FAX                    VARCHAR2(15),
    CONTACT_EMAIL                  VARCHAR2(80),
    CONTACT_TITLE                  VARCHAR2(45),
    OWNER_NAME                     VARCHAR2(80),
    OWNER_TYPE                     CHAR,
    OWNER_SEQ_NUM                  NUMBER,
    OPER_NAME                      VARCHAR2(80),
    OPER_TYPE                      CHAR,
    OPER_SEQ_NUM                   NUMBER,
    NAIC1_CODE                     VARCHAR2(6),
    NAIC2_CODE                     VARCHAR2(6),
    NAIC3_CODE                     VARCHAR2(6),
    NAIC4_CODE                     VARCHAR2(6),
    IN_HANDLER_UNIVERSE            CHAR,
    IN_A_UNIVERSE                  CHAR,
    FED_WASTE_GENERATOR_OWNER      CHAR(2),
    FED_WASTE_GENERATOR            CHAR,
    STATE_WASTE_GENERATOR_OWNER    CHAR(2),
    STATE_WASTE_GENERATOR          CHAR,
    GEN_STATUS                     VARCHAR2(3),
    UNIV_WASTE                     CHAR,
    LAND_TYPE                      CHAR,
    STATE_DISTRICT_OWNER           CHAR(2),
    STATE_DISTRICT                 VARCHAR2(10),
    SHORT_TERM_GEN_IND             CHAR,
    IMPORTER_ACTIVITY              CHAR,
    MIXED_WASTE_GENERATOR          CHAR,
    TRANSPORTER_ACTIVITY           CHAR,
    TRANSFER_FACILITY_IND          CHAR,
    RECYCLER_ACTIVITY              CHAR,
    ONSITE_BURNER_EXEMPTION        CHAR,
    FURNACE_EXEMPTION              CHAR,
    UNDERGROUND_INJECTION_ACTIVITY CHAR,
    UNIVERSAL_WASTE_DEST_FACILITY  CHAR,
    OFFSITE_WASTE_RECEIPT          CHAR,
    USED_OIL                       VARCHAR2(7),
    FEDERAL_UNIVERSAL_WASTE        CHAR,
    AS_FEDERAL_REGULATED_TSDF      VARCHAR2(6),
    AS_CONVERTED_TSDF              VARCHAR2(6),
    AS_STATE_REGULATED_TSDF        VARCHAR2(9),
    FEDERAL_IND                    VARCHAR2(3),
    HSM                            CHAR(2),
    SUBPART_K                      VARCHAR2(4),
    COMMERCIAL_TSD                 CHAR,
    TSD                            VARCHAR2(5),
    GPRA_PERMIT                    CHAR,
    GPRA_RENEWAL                   CHAR,
    PERMIT_RENEWAL_WRKLD           VARCHAR2(6),
    PERM_WRKLD                     VARCHAR2(6),
    PERM_PROG                      VARCHAR2(6),
    PC_WRKLD                       VARCHAR2(6),
    CLOS_WRKLD                     VARCHAR2(6),
    GPRACA                         CHAR,
    CA_WRKLD                       CHAR,
    SUBJ_CA                        CHAR,
    SUBJ_CA_NON_TSD                CHAR,
    SUBJ_CA_TSD_3004               CHAR,
    SUBJ_CA_DISCRETION             CHAR,
    NCAPS                          CHAR,
    EC_IND                         CHAR,
    IC_IND                         CHAR,
    CA_725_IND                     CHAR,
    CA_750_IND                     CHAR,
    OPERATING_TSDF                 VARCHAR2(6),
    FULL_ENFORCEMENT               VARCHAR2(6),
    SNC                            CHAR,
    BOY_SNC                        CHAR,
    BOY_STATE_UNADDRESSED_SNC      CHAR,
    STATE_UNADDRESSED              CHAR,
    STATE_ADDRESSED                CHAR,
    BOY_STATE_ADDRESSED            CHAR,
    STATE_SNC_WITH_COMP_SCHED      CHAR,
    BOY_STATE_SNC_WITH_COMP_SCHED  CHAR,
    EPA_UNADDRESSED                CHAR,
    BOY_EPA_UNADDRESSED            CHAR,
    EPA_ADDRESSED                  CHAR,
    BOY_EPA_ADDRESSED              CHAR,
    EPA_SNC_WITH_COMP_SCHED        CHAR,
    BOY_EPA_SNC_WITH_COMP_SCHED    CHAR,
    FA_REQUIRED                    VARCHAR2(5),
    HHANDLER_LAST_CHANGE_DATE      DATE,
    PUBLIC_NOTES                   VARCHAR2(4000),
    NOTES                          VARCHAR2(4000),
    RECOGNIZED_TRADER_IMPORTER_IND CHAR,
    RECOGNIZED_TRADER_EXPORTER_IND CHAR,
    SLAB_IMPORTER_IND              CHAR,
    SLAB_EXPORTER_IND              CHAR,
    RECYCLER_NON_STORAGE_IND       CHAR,
    MANIFEST_BROKER_IND            CHAR,
    RECYCLER_NOTES                 VARCHAR2(4000),
    SUBPART_P_IND                  CHAR,
    LOCATION_LATITUDE              NUMBER(19, 14),
    LOCATION_LONGITUDE             NUMBER(19, 14),
    LOCATION_GIS_PRIM              CHAR,
    LOCATION_GIS_ORIG              CHAR(2)
)
/

comment on column RCRA_RU_REPORT_UNIV.RU_REPORT_UNIV_ID is 'Parent: Universal waste report details'
/

comment on column RCRA_RU_REPORT_UNIV.HANDLER_ID is 'Code that uniquely identifies the handler. (HandlerIdCode)'
/

comment on column RCRA_RU_REPORT_UNIV.ACTIVITY_LOCATION is 'Indicates the location of the agency regulating the handler. (ActivityLocationCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SOURCE_TYPE is 'Code indicating the source of information for the associated data (activity, wastes, etc.). (SourceTypeCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SEQ_NUMBER is 'Sequence number for each source record about a handler. (SequenceNumber)'
/

comment on column RCRA_RU_REPORT_UNIV.RECEIVE_DATE is 'Date that the form (indicated by the associated Source) was received from the handler by the appropriate authority. (ReceiveDate)'
/

comment on column RCRA_RU_REPORT_UNIV.HANDLER_NAME is 'Name of the Handler (HandlerName)'
/

comment on column RCRA_RU_REPORT_UNIV.NON_NOTIFIER_IND is 'Flag indicating that the handler has been identified through a source other than Notification and is suspected of conducting RCRA-regulated activities without proper authority. (NonNotifierIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.ACCESSIBILITY is 'Reason why the handler is not accessible for normal processing (Bankrupt Indicator). (Accessibility)'
/

comment on column RCRA_RU_REPORT_UNIV.REPORT_CYCLE is 'Report cycle. (ReportCycle)'
/

comment on column RCRA_RU_REPORT_UNIV.REGION is 'Region (Region)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE is 'State (State)'
/

comment on column RCRA_RU_REPORT_UNIV.EXTRACT_FLAG is 'Extract flag (ExtractFlag)'
/

comment on column RCRA_RU_REPORT_UNIV.ACTIVE_SITE is 'Active site (ActiveSite)'
/

comment on column RCRA_RU_REPORT_UNIV.COUNTY_CODE is 'The Federal Information Processing Standard (FIPS) code for the county in which the facility is located (Ref: FIPS Publication, 6-3, "Counties and County Equivalents of the States of the United States"). (CountyCode)'
/

comment on column RCRA_RU_REPORT_UNIV.COUNTY_NAME is 'Descriptive text describing the County Name(Data publishing only). (CountyName)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_STREET_NUMBER is 'Number portion of the location street address of the handler. (LocationAddressNumberText)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_STREET1 is 'Street address of the handler. (LocationAddressText)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_STREET2 is 'Supplemental address of the handler. (SupplementalLocationText)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_CITY is 'City in which the handler is located. (LocalityName)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_STATE is 'State in which the handler is located. (StateUSPSCode)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_COUNTRY is 'Country in which the handler is located. (CountryName)'
/

comment on column RCRA_RU_REPORT_UNIV.LOCATION_ZIP is 'ZIP code in which the handler is located. (LocationZIPCode)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_STREET_NUMBER is 'Number portion of the mailing address of the handler. (MailingAddressNumberText)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_STREET1 is 'Street address of the handler mailing address. (MailingAddressText)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_STREET2 is 'Supplemental address of the handler mailing address. (SupplementalLocationText)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_CITY is 'City of the handler mailing address. (MailingAddressCityName)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_STATE is 'State of the handler mailing address. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_COUNTRY is 'Country of the handler mailing address. (MailingAddressCountryName)'
/

comment on column RCRA_RU_REPORT_UNIV.MAIL_ZIP is 'ZIP code of the handler mailing address. (MailingAddressZIPCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_STREET_NUMBER is 'Number portion of the mailing address of the handler contact. (MailingAddressNumberText)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_STREET1 is 'Street address of the handler contact mailing address. (MailingAddressText)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_STREET2 is 'Supplemental address of the handler contact mailing address. (SupplementalLocationText)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_CITY is 'City of the handler contact mailing address. (MailingAddressCityName)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_STATE is 'State of the handler contact mailing address. (MailingAddressStateUSPSCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_COUNTRY is 'Country of the handler contact mailing address. (MailingAddressCountryName)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_ZIP is 'ZIP code of the handler contact mailing address. (MailingAddressZIPCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_NAME is 'Handler contact name (first + last). (ContactNameCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_PHONE is 'Handler contact phone number. (ContactPhoneCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_FAX is 'Handler contact fax number. (ContactFaxCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_EMAIL is 'Handler contact email address. (ContactEmailCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CONTACT_TITLE is 'Handler contact title. (ContactTitleCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OWNER_NAME is 'Handler owner name. (OwnerNameCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OWNER_TYPE is 'Handler owner type. (OwnerTypeCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OWNER_SEQ_NUM is 'Handler owner sequence number. (OwnerSeqCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OPER_NAME is 'Handler operator name. (OperatorNameCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OPER_TYPE is 'Handler operator type. (OperatorTypeCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OPER_SEQ_NUM is 'Handler operator sequence number. (OperatorSeqCode)'
/

comment on column RCRA_RU_REPORT_UNIV.NAIC1_CODE is 'NAIC 1 code (NAIC1Code)'
/

comment on column RCRA_RU_REPORT_UNIV.NAIC2_CODE is 'NAIC 2 code (NAIC2Code)'
/

comment on column RCRA_RU_REPORT_UNIV.NAIC3_CODE is 'NAIC 3 code (NAIC3Code)'
/

comment on column RCRA_RU_REPORT_UNIV.NAIC4_CODE is 'NAIC 4 code (NAIC4Code)'
/

comment on column RCRA_RU_REPORT_UNIV.IN_HANDLER_UNIVERSE is 'In handler universe (InHandlerUniverseCode)'
/

comment on column RCRA_RU_REPORT_UNIV.IN_A_UNIVERSE is 'In a universe (InAUniverseCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR_OWNER is 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorOwner)'
/

comment on column RCRA_RU_REPORT_UNIV.FED_WASTE_GENERATOR is 'Federal code indicating that the handler is engaged in the generation of hazardous waste. (FederalWasteGeneratorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR_OWNER is 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorOwner)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_WASTE_GENERATOR is 'State code indicating that the handler is engaged in the generation of hazardous waste. (StateWasteGeneratorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.GEN_STATUS is 'Gen status (GENSTATUS)'
/

comment on column RCRA_RU_REPORT_UNIV.UNIV_WASTE is 'Univ waste (UNIVWASTE)'
/

comment on column RCRA_RU_REPORT_UNIV.LAND_TYPE is 'Code indicating current ownership status of the land on which the facility is located. (LandTypeCode)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_DISTRICT_OWNER is 'Owner of the state district code.  Usually 2-digit postal code (i.e. KS). (StateDistrictOwnerName)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_DISTRICT is 'Code indicating the state-designated legislative district(s) in which the site is located. (StateDistrictCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SHORT_TERM_GEN_IND is 'Code indicating that the handler is engaged in short-term hazardous waste generation activities. (ShortTermGeneratorIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.IMPORTER_ACTIVITY is 'Code indicating that the handler is engaged in importing hazardous waste into the United States. (ImporterActivityCode)'
/

comment on column RCRA_RU_REPORT_UNIV.MIXED_WASTE_GENERATOR is 'Code indicating that the handler is engaged in generating mixed waste (waste that is both hazardous and radioactive). (MixedWasteGeneratorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.TRANSPORTER_ACTIVITY is 'Code indicating that the handler is engaged in the transportation of hazardous waste. (TransporterActivityCode)'
/

comment on column RCRA_RU_REPORT_UNIV.TRANSFER_FACILITY_IND is 'Code indicating that the handler is a Hazardous Waste Transfer Facility (not to be confused with a used oil transfer facility). (TransferFacilityIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.RECYCLER_ACTIVITY is 'Code for recycling hazardous waste. (RecyclerActivityCode)'
/

comment on column RCRA_RU_REPORT_UNIV.ONSITE_BURNER_EXEMPTION is 'Code indicating that the handler qualifies for the Small Quantity Onsite Burner Exemption. (OnsiteBurnerExemptionCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FURNACE_EXEMPTION is 'Code indicating that the handler qualifies for the Smelting, Melting, and Refining Furnace Exemption. (FurnaceExemptionCode)'
/

comment on column RCRA_RU_REPORT_UNIV.UNDERGROUND_INJECTION_ACTIVITY is 'Code indicating that the handler generates and or treats, stores, or disposes of hazardous waste and has an injection well located at the installation. (UndergroundInjectionActivityCode)'
/

comment on column RCRA_RU_REPORT_UNIV.UNIVERSAL_WASTE_DEST_FACILITY is 'Code indicating that the handler treats, disposes of, or recycles hazardous waste on site. (UniversalWasteDestinationFacilityIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.OFFSITE_WASTE_RECEIPT is 'Off site waste receipt (OffSiteWasteReceiptCode)'
/

comment on column RCRA_RU_REPORT_UNIV.USED_OIL is 'Used oil code (UsedOilCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FEDERAL_UNIVERSAL_WASTE is 'Federal universal waste (FederalUniversalWasteCode)'
/

comment on column RCRA_RU_REPORT_UNIV.AS_FEDERAL_REGULATED_TSDF is 'As federal regulated TSDF (AsFederalRegulatedTSDFCode)'
/

comment on column RCRA_RU_REPORT_UNIV.AS_CONVERTED_TSDF is 'As converter TSDF (AsConverterTSDFCode)'
/

comment on column RCRA_RU_REPORT_UNIV.AS_STATE_REGULATED_TSDF is 'As state regulated TSDF (AsStateRegulatedTSDFCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FEDERAL_IND is 'Federal indicator (FederalIndicatorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.HSM is 'HSM code (HSMCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBPART_K is 'Subpart K code (SubpartKCode)'
/

comment on column RCRA_RU_REPORT_UNIV.COMMERCIAL_TSD is 'Commercial TSD code (CommercialTSDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.TSD is 'TSD type (TSDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.GPRA_PERMIT is 'GPRA permit (GPRAPermitCode)'
/

comment on column RCRA_RU_REPORT_UNIV.GPRA_RENEWAL is 'GPRA renewal code (GPRARenewalCode)'
/

comment on column RCRA_RU_REPORT_UNIV.PERMIT_RENEWAL_WRKLD is 'Permit renewal WRKLD (PermitRenewalWRKLDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.PERM_WRKLD is 'Perm WRKLD (PermWRKLDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.PERM_PROG is 'Perm PROG (PermPROGCode)'
/

comment on column RCRA_RU_REPORT_UNIV.PC_WRKLD is 'PC WRKLD (PCWRKLDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CLOS_WRKLD is 'Clos WRKLD (ClosWRKLDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.GPRACA is 'GPRACA (GPRACACode)'
/

comment on column RCRA_RU_REPORT_UNIV.CA_WRKLD is 'CAWRKLD (CAWRKLDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBJ_CA is 'Subj CA (SubjCACode)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBJ_CA_NON_TSD is 'Subj CA non TSD (SubjCANonTSDCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBJ_CA_TSD_3004 is 'Subj CA TSD 3004 (SubjCATSD3004Code)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBJ_CA_DISCRETION is 'Subj CA discretion (SubjCADiscretionCode)'
/

comment on column RCRA_RU_REPORT_UNIV.NCAPS is 'NCAPS (NCAPSCode)'
/

comment on column RCRA_RU_REPORT_UNIV.EC_IND is 'EC indicator (ECIndicatorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.IC_IND is 'IC indicator (ICIndicatorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CA_725_IND is 'CA 725 indicator (CA725IndicatorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.CA_750_IND is 'CA 750 indicator (CA750IndicatorCode)'
/

comment on column RCRA_RU_REPORT_UNIV.OPERATING_TSDF is 'Operating TSDF (OperatingTSDFCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FULL_ENFORCEMENT is 'Full enforcement (FullEnforcementCode)'
/

comment on column RCRA_RU_REPORT_UNIV.SNC is 'SNC (SNCCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_SNC is 'BOY SNC (BOYSNCCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_STATE_UNADDRESSED_SNC is 'BOY state unaddressed SNC (BOYStateUnaddressedSNCCode)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_UNADDRESSED is 'State unaddressed (StateUnaddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_ADDRESSED is 'State addressed (StateAddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_STATE_ADDRESSED is 'BOY state addressed (BOYStateAddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.STATE_SNC_WITH_COMP_SCHED is 'State SNC with comp sched (StateSNCWithCompSchedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_STATE_SNC_WITH_COMP_SCHED is 'BOY state SNC with comp sched (BOYStateSNCWithCompSchedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.EPA_UNADDRESSED is 'EPA unaddressed (EPAUnaddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_EPA_UNADDRESSED is 'BOY EPA unaddressed (BOYEPAUnaddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.EPA_ADDRESSED is 'EPA addressed (EPAAddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_EPA_ADDRESSED is 'BOY EPA addressed (BOYEPAAddressedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.EPA_SNC_WITH_COMP_SCHED is 'EPA SNC with comp sched (EPASNCWithcompSchedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.BOY_EPA_SNC_WITH_COMP_SCHED is 'BOY EPA SNC with comp sched (BOYEPASNCWithcompSchedCode)'
/

comment on column RCRA_RU_REPORT_UNIV.FA_REQUIRED is 'FA required (FARequiredCode)'
/

comment on column RCRA_RU_REPORT_UNIV.HHANDLER_LAST_CHANGE_DATE is 'HHandler last change date (HHandlerLastChangeDate)'
/

comment on column RCRA_RU_REPORT_UNIV.PUBLIC_NOTES is 'Notes (PublicNotesCode)'
/

comment on column RCRA_RU_REPORT_UNIV.NOTES is 'Notes (NotesCode)'
/

comment on column RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_IMPORTER_IND is 'Indicates that the Handler is participating in Import Trading activity. Possible values are: Y/N (RecognizedTraderImporterIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.RECOGNIZED_TRADER_EXPORTER_IND is 'Indicates that the Handler is participating in Export Trading activity. Possible values are: Y/N (RecognizedTraderExporterIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.SLAB_IMPORTER_IND is 'Indicates that the Handler is participating in Slab Import activity. Possible values are: Y/N (SlabImporterIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.SLAB_EXPORTER_IND is 'Indicates that the Handler is participating in Slab Export activity. Possible values are: Y/N (SlabExporterIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.RECYCLER_NON_STORAGE_IND is 'Recycle non storage (RecyclerNonStorageIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.MANIFEST_BROKER_IND is 'Manifest broker (ManifestBrokerIndicator)'
/

comment on column RCRA_RU_REPORT_UNIV.SUBPART_P_IND is 'Subpart P code (SubpartPIndicator)'
/

create table ETL_RUN
(
    ETL_RUN_ID NUMBER       not null
        primary key,
    RUN_DATE   TIMESTAMP(6) not null,
    ETL_TYPE   CHAR(2)      not null,
    SUBM_ID    VARCHAR2(40)
)
/

create table ETL_RUN_HANDLER
(
    ETL_RUN_ID  NUMBER       not null
        references ETL_RUN,
    HANDLER_ID  VARCHAR2(12) not null,
    STATUS_TYPE CHAR         not null
)
/

create index IX_ETL_RUN_HANDLER_ETL_RUN_ID
    on ETL_RUN_HANDLER (ETL_RUN_ID)
/

create index IX_ETL_RUN_HANDLER_HANDLER_ID
    on ETL_RUN_HANDLER (HANDLER_ID)
/

create table RCRA_EM_SUBM
(
    EM_SUBM_ID NUMBER not null
        constraint PK_RCRA_EM_SUBM
            primary key
)
/

create table RCRA_EM_EMANIFEST
(
    EM_EMANIFEST_ID                NUMBER not null
        constraint PK_EM_EMANIFEST
            primary key,
    EM_SUBM_ID                     NUMBER,
    CREATED_DATE                   TIMESTAMP(6),
    UPDATED_DATE                   TIMESTAMP(6),
    MAN_TRACKING_NUM               VARCHAR2(12),
    STATUS                         VARCHAR2(17),
    SUBM_TYPE                      VARCHAR2(14),
    ORIGIN_TYPE                    VARCHAR2(7),
    SHIPPED_DATE                   TIMESTAMP(6),
    RECEIVED_DATE                  TIMESTAMP(6),
    CERT_DATE                      TIMESTAMP(6),
    REJ_IND                        CHAR,
    RESIDUE                        CHAR,
    IMPORT                         CHAR,
    TRANSPORTER_ON_SITE            CHAR,
    REJECTION_TYPE                 VARCHAR2(13),
    ALTERNATE_DESIGNATED_FAC_TYPE  VARCHAR2(9),
    FOREIGN_GENERATOR_NAME         VARCHAR2(80),
    FOREIGN_GENERATOR_STREET       VARCHAR2(50),
    FOREIGN_GENERATOR_CITY         VARCHAR2(25),
    FOREIGN_GENERATOR_POST_CODE    VARCHAR2(50),
    FOREIGN_GENERATOR_PROVINCE     VARCHAR2(50),
    FOREIGN_GENERATOR_CTRY_CODE    CHAR(2),
    FOREIGN_GENERATOR_CTRY_NAME    VARCHAR2(100),
    PORT_OF_ENTRY_CITY             VARCHAR2(100),
    PORT_OF_ENTRY_STA              CHAR(2),
    MANIFEST_HANDLING_INSTR        VARCHAR2(4000),
    GENERATOR_ID                   VARCHAR2(15),
    GENERATOR_NAME                 VARCHAR2(80),
    GENERATOR_MAIL_STREET_NUM      VARCHAR2(12),
    GENERATOR_MAIL_STREET_1        VARCHAR2(50),
    GENERATOR_MAIL_STREET_2        VARCHAR2(50),
    GENERATOR_MAIL_CITY            VARCHAR2(35),
    GENERATOR_MAIL_CTRY            CHAR(2),
    GENERATOR_MAIL_STA             CHAR(2),
    GENERATOR_MAIL_ZIP             VARCHAR2(50),
    GENERATOR_LOC_STREET_NUM       VARCHAR2(12),
    GENERATOR_LOC_STREET_1         VARCHAR2(50),
    GENERATOR_LOC_STREET_2         VARCHAR2(50),
    GENERATOR_LOC_CITY             VARCHAR2(35),
    GENERATOR_LOC_STA              CHAR(2),
    GENERATOR_LOC_ZIP              VARCHAR2(25),
    GENERATOR_CONTACT_FIRST_NAME   VARCHAR2(38),
    GENERATOR_CONTACT_LAST_NAME    VARCHAR2(38),
    GENERATOR_CONTACT_COMPANY_NAME VARCHAR2(80),
    GENERATOR_CONTACT_EMAIL        VARCHAR2(80),
    GENERATOR_CONTACT_PHONE_NUM    VARCHAR2(15),
    GENERATOR_CONTACT_PHONE_EXT    VARCHAR2(6),
    GENERATOR_PRINTED_NAME         VARCHAR2(80),
    GENERATOR_SIGNATURE_DATE       DATE,
    GENERATOR_ESIG_FIRST_NAME      VARCHAR2(38),
    GENERATOR_ESIG_LAST_NAME       VARCHAR2(38),
    GENERATOR_ESIG_SIGNATURE_DATE  DATE,
    GENERATOR_REGISTERED           CHAR,
    GENERATOR_MODIFIED             CHAR,
    DES_FAC_ID                     VARCHAR2(15),
    DES_FAC_NAME                   VARCHAR2(80),
    DES_FAC_MAIL_STREET_NUM        VARCHAR2(12),
    DES_FAC_MAIL_STREET_1          VARCHAR2(50),
    DES_FAC_MAIL_STREET_2          VARCHAR2(50),
    DES_FAC_MAIL_CITY              VARCHAR2(35),
    DES_FAC_MAIL_CTRY              CHAR(2),
    DES_FAC_MAIL_STA               CHAR(2),
    DES_FAC_MAIL_ZIP               VARCHAR2(25),
    DES_FAC_LOC_STREET_NUM         VARCHAR2(12),
    DES_FAC_LOC_STREET_1           VARCHAR2(50),
    DES_FAC_LOC_STREET_2           VARCHAR2(50),
    DES_FAC_LOC_CITY               VARCHAR2(35),
    DES_FAC_LOC_STA                CHAR(2),
    DES_FAC_LOC_ZIP                VARCHAR2(25),
    DES_FAC_CONTACT_FIRST_NAME     VARCHAR2(38),
    DES_FAC_CONTACT_LAST_NAME      VARCHAR2(38),
    DES_FAC_CONTACT_COMPANY_NAME   VARCHAR2(80),
    DES_FAC_CONTACT_PHONE_NUM      VARCHAR2(15),
    DES_FAC_CONTACT_PHONE_EXT      VARCHAR2(6),
    DES_FAC_CONTACT_EMAIL          VARCHAR2(80),
    DES_FAC_PRINTED_NAME           VARCHAR2(80),
    DES_FAC_SIGNATURE_DATE         DATE,
    DES_FAC_ESIG_FIRST_NAME        VARCHAR2(38),
    DES_FAC_ESIG_LAST_NAME         VARCHAR2(38),
    DES_FAC_ESIG_SIGNATURE_DATE    DATE,
    DES_FAC_REGISTERED             CHAR,
    DES_FAC_MODIFIED               CHAR,
    ALT_FAC_ID                     VARCHAR2(12),
    ALT_FAC_NAME                   VARCHAR2(80),
    ALT_FAC_MAIL_STREET_NUM        VARCHAR2(12),
    ALT_FAC_MAIL_STREET_1          VARCHAR2(50),
    ALT_FAC_MAIL_STREET_2          VARCHAR2(50),
    ALT_FAC_MAIL_CITY              VARCHAR2(25),
    ALT_FAC_MAIL_STA               CHAR(2),
    ALT_FAC_MAIL_ZIP               VARCHAR2(14),
    ALT_FAC_LOC_STREET_NUM         VARCHAR2(12),
    ALT_FAC_LOC_STREET_1           VARCHAR2(50),
    ALT_FAC_LOC_STREET_2           VARCHAR2(50),
    ALT_FAC_LOC_CITY               VARCHAR2(25),
    ALT_FAC_LOC_STA                CHAR(2),
    ALT_FAC_LOC_ZIP                VARCHAR2(14),
    ALT_FAC_CONTACT_FIRST_NAME     VARCHAR2(38),
    ALT_FAC_CONTACT_LAST_NAME      VARCHAR2(38),
    ALT_FAC_CONTACT_COMPANY_NAME   VARCHAR2(80),
    ALT_FAC_CONTACT_PHONE_NO       VARCHAR2(15),
    ALT_FAC_CONTACT_PHONE_EXT      VARCHAR2(6),
    ALT_FAC_CONTACT_EMAIL          VARCHAR2(80),
    ALT_FAC_PRINTED_NAME           VARCHAR2(80),
    ALT_FAC_SIGNATURE_DATE         DATE,
    ALT_FAC_ESIG_FIRST_NAME        VARCHAR2(38),
    ALT_FAC_ESIG_LAST_NAME         VARCHAR2(38),
    ALT_FAC_ESIG_SIGNATURE_DATE    DATE,
    ALT_FAC_REGISTERED             CHAR,
    ALT_FAC_MODIFIED               CHAR,
    EMERGENCY_PHONE_NUM            VARCHAR2(15),
    EMERGENCY_PHONE_EXT            VARCHAR2(6),
    ORIG_SUBM_TYPE                 VARCHAR2(14),
    COI_ONLY                       CHAR,
    BROKER_ID                      VARCHAR2(15),
    LAST_EM_UPDT_DATE              DATE
)
/

create table RCRA_EM_EMANIFEST_COMMENT
(
    EM_EMANIFEST_COMMENT_ID NUMBER not null
        constraint PK_EM_EMANIFEST_COMMENT
            primary key,
    EM_EMANIFEST_ID         NUMBER not null
        constraint FK_EM_EMANIFEST_COMMENT_PARENT
            references RCRA_EM_EMANIFEST
                on delete cascade,
    CMNT_DESC               VARCHAR2(4000),
    CMNT_LABEL              VARCHAR2(255)
)
/

create table RCRA_EM_WASTE
(
    EM_WASTE_ID                NUMBER not null
        constraint PK_RCRA_EM_WASTE
            primary key,
    EM_EMANIFEST_ID            NUMBER not null
        constraint FK_RCRA_EM_WASTE_PARENT
            references RCRA_EM_EMANIFEST
                on delete cascade,
    DOT_HAZRD                  CHAR   not null,
    NON_HAZ_WASTE_DESC         VARCHAR2(500),
    PCB                        CHAR   not null,
    LINE_NUM                   NUMBER(10),
    EPA_WASTE                  CHAR,
    DOT_ID_NUM_DESC            VARCHAR2(6),
    DOT_PRINTED_INFO           VARCHAR2(500),
    CONTAINER_NUM              NUMBER,
    QNTY_VAL                   NUMBER(14, 6),
    CONTAINER_TYPE_CODE        VARCHAR2(255),
    CONTAINER_TYPE_DESC        VARCHAR2(255),
    QTY_UNIT_OF_MEAS_CODE      CHAR,
    QTY_UNIT_OF_MEAS_DESC      VARCHAR2(28),
    BR_DENSITY                 NUMBER(14, 6),
    BR_DENSITY_UOM_CODE        CHAR,
    BR_DENSITY_UOM_DESC        VARCHAR2(240),
    BR_FORM_CODE               VARCHAR2(4),
    BR_FORM_CODE_DESC          VARCHAR2(240),
    BR_SRC_CODE                VARCHAR2(3),
    BR_SRC_CODE_DESC           VARCHAR2(240),
    BR_WASTE_MIN_CODE          CHAR,
    BR_WASTE_MIN_DESC          VARCHAR2(240),
    QNTY_DISCREPANCY           CHAR,
    WASTE_TYPE_DISCREPANCY     CHAR,
    DISCREPANCY_COMM           VARCHAR2(257),
    WASTE_RESIDUE              CHAR,
    WASTE_RESIDUE_COMM         VARCHAR2(257),
    MANAGEMENT_METH_CODE       VARCHAR2(4),
    MANAGEMENT_METH_DESC       VARCHAR2(240),
    CNST_NUM                   VARCHAR2(255),
    HANDLING_INSTRUCTIONS      VARCHAR2(4000),
    COI_ONLY                   CHAR,
    QNTY_ACUTE_KG              NUMBER(14, 6),
    QNTY_ACUTE_TONS            NUMBER(14, 6),
    QNTY_NON_ACUTE_KG          NUMBER(14, 6),
    QNTY_NON_ACUTE_TONS        NUMBER(14, 6),
    QNTY_TONS                  NUMBER(14, 6),
    BR_MIXED_RADIOACTIVE_WASTE CHAR,
    QNTY_KG                    NUMBER(14, 6)
)
/

create table RCRA_EM_WASTE_CD_TRANS
(
    EM_WASTE_CD_TRANS_ID NUMBER       not null
        constraint PK_RCRA_EM_WASTE_CD_TRANS
            primary key,
    EM_WASTE_ID          NUMBER       not null
        constraint FK_RCRA_EM_WASTE_CD_TRANS_PAR
            references RCRA_EM_WASTE
                on delete cascade,
    WASTE_CODE           VARCHAR2(12) not null
)
/

create table RCRA_EM_WASTE_COMMENT
(
    EM_WASTE_COMMENT_ID NUMBER not null
        constraint PK_RCRA_EM_WASTE_COMMENT
            primary key,
    EM_WASTE_ID         NUMBER not null
        constraint FK_RCRA_EM_WASTE_COMMENT_PAR
            references RCRA_EM_WASTE
                on delete cascade,
    CMNT_DESC           VARCHAR2(4000),
    CMNT_LABEL          VARCHAR2(255)
)
/

create table RCRA_EM_WASTE_PCB
(
    EM_WASTE_PCB_ID     NUMBER not null
        constraint PK_RCRA_EM_WASTE_PCB
            primary key,
    EM_WASTE_ID         NUMBER not null
        constraint FK_RCRA_EM_WASTE_PCB_PAR
            references RCRA_EM_WASTE
                on delete cascade,
    PCB_LOAD_TYPE_CODE  VARCHAR2(25),
    PCB_ARTICLE_CONT_ID VARCHAR2(255),
    PCB_REMOVAL_DATE    TIMESTAMP(6),
    PCB_WEIGHT          NUMBER(14, 6),
    PCB_WASTE_TYPE      VARCHAR2(150),
    PCB_BULK_IDENTITY   VARCHAR2(255),
    LOAD_TYPE_DESC      VARCHAR2(25)
)
/

create table RCRA_PRM_MOD_EVENT
(
    PRM_MOD_EVENT_ID          NUMBER(10)   not null
        constraint PK_RCRA_PRM_MOD_EVENT
            primary key,
    PRM_EVENT_ID              NUMBER(10)   not null
        constraint FK_RCRA_PRM_MOD_EVENT_PARENT
            references RCRA_PRM_EVENT
                on delete cascade,
    TRANS_CODE                CHAR,
    MOD_HANDLER_ID            VARCHAR2(12) not null,
    MOD_ACT_LOC_CODE          CHAR(2)      not null,
    MOD_SERIES_SEQ_NUM        NUMBER       not null,
    MOD_EVENT_SEQ_NUM         NUMBER       not null,
    MOD_EVENT_AGN_CODE        CHAR         not null,
    MOD_EVENT_DATA_OWNER_CODE CHAR(2)      not null,
    MOD_EVENT_CODE            VARCHAR2(7)  not null
)
/

comment on table RCRA_PRM_MOD_EVENT is 'Linking mod event for Permitting Events (PermitModEventDataType)'
/

comment on column RCRA_PRM_MOD_EVENT.PRM_MOD_EVENT_ID is 'Id of the mod event record (PK)'
/

comment on column RCRA_PRM_MOD_EVENT.PRM_EVENT_ID is 'Id of the parent PRM_EVENT record (FK)'
/

comment on column RCRA_PRM_MOD_EVENT.TRANS_CODE is 'Transaction code used to define the add, update, or delete. (TransactionCode)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_HANDLER_ID is 'Handler id (ModHandlerId)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_ACT_LOC_CODE is 'Permit event activity location (ModActivityLocationCode)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_SERIES_SEQ_NUM is 'Permit series sequence number (ModSeriesSequenceNumber)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_EVENT_SEQ_NUM is 'Permit event sequence number (ModEventSequenceNumber)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_EVENT_AGN_CODE is 'Permit event owner (ModEventAgencyCode)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_EVENT_DATA_OWNER_CODE is 'Permit event owner (ModEventDataOwnerCode)'
/

comment on column RCRA_PRM_MOD_EVENT.MOD_EVENT_CODE is 'Permit event code (ModEventCode)'
/

create table RCRA_HD_EPISODIC_PRJT
(
    HD_EPISODIC_PRJT_ID  NUMBER  not null
        constraint PK_HD_EPISODIC_PRJT
            primary key,
    HD_EPISODIC_EVENT_ID NUMBER  not null
        constraint FK_HD_EPISO_PRJT_HD_EPISO_EVEN
            references RCRA_HD_EPISODIC_EVENT
                on delete cascade,
    TRANSACTION_CODE     CHAR,
    PRJT_CODE_OWNER      CHAR(2) not null,
    PRJT_CODE            CHAR(3) not null,
    OTHER_PRJT_DESC      VARCHAR2(255)
)
/

create index IX_HD_EPIS_PRJT_HD_EPIS_EVE_ID
    on RCRA_HD_EPISODIC_PRJT (HD_EPISODIC_EVENT_ID)
/

create table RCRA_EM_FED_WASTE_CODE_DESC
(
    EM_FED_WASTE_CODE_DESC_ID NUMBER      not null
        constraint PK_EM_FED_WASTE_CODE_DESC
            primary key,
    EM_WASTE_ID               NUMBER      not null
        constraint FK_RCRA_EM_FED_WS_CD_EM_WS_ID
            references RCRA_EM_WASTE
                on delete cascade,
    FED_MANIFEST_WASTE_CODE   VARCHAR2(6) not null,
    MANIFEST_WASTE_DESC       VARCHAR2(2000),
    COI_IND                   CHAR
)
/

create index IX_EM_FD_WST_CDE_DSC_EM_WST_ID
    on RCRA_EM_FED_WASTE_CODE_DESC (EM_WASTE_ID)
/

create table RCRA_EM_STATE_WASTE_CODE_DESC
(
    EM_STATE_WASTE_CODE_DESC_ID NUMBER      not null
        constraint PK_EM_STATE_WASTE_CODE_DESC
            primary key,
    EM_WASTE_ID                 NUMBER      not null
        constraint FK_EM_ST_WST_CD_DESC_EM_WST_ID
            references RCRA_EM_WASTE
                on delete cascade,
    STA_MANIFEST_WASTE_CODE     VARCHAR2(8) not null,
    MANIFEST_WASTE_DESC         VARCHAR2(2000)
)
/

create index IX_EM_STT_WST_CDE_DSC_EM_WS_ID
    on RCRA_EM_STATE_WASTE_CODE_DESC (EM_WASTE_ID)
/

create table RCRA_EM_TRANSPORTER
(
    EM_TRANSPORTER_ID           NUMBER not null
        constraint PK_EM_TRANSPORTER
            primary key,
    EM_EMANIFEST_ID             NUMBER not null
        constraint FK_RCRA_EM_TRANS_EM_EM_ID
            references RCRA_EM_EMANIFEST
                on delete cascade,
    TRANSPORTER_ID              VARCHAR2(15),
    TRANSPORTER_NAME            VARCHAR2(80),
    TRANSPORTER_PRINTED_NAME    VARCHAR2(80),
    TRANSPORTER_SIGNATURE_DATE  DATE,
    TRANSPORTER_ESIG_FIRST_NAME VARCHAR2(38),
    TRANSPORTER_ESIG_LAST_NAME  VARCHAR2(38),
    TRANS_ESIG_SIGNATURE_DATE   DATE,
    TRANSPORTER_LINE_NUM        VARCHAR2(19),
    TRANSPORTER_REGISTERED      CHAR
)
/

create index IX_EM_TRNSPORTER_EM_EMNIFST_ID
    on RCRA_EM_TRANSPORTER (EM_EMANIFEST_ID)
/

create view RCRA_CA_REL_EVENT_VW as
(
SELECT CA_AREA_REL_EVENT_ID CA_REL_EVENT_ID,
       CA_AREA_ID,
       NULL                 CA_AUTHORITY_ID,
       TRANS_CODE,
       ACT_LOC_CODE,
       CORCT_ACT_EVENT_DATA_OWNER_CDE,
       CORCT_ACT_EVENT_CODE,
       EVENT_AGN_CODE,
       EVENT_SEQ_NUM
FROM RCRA_CA_AREA_REL_EVENT
UNION ALL
SELECT CA_AUTH_REL_EVENT_ID,
       NULL,
       CA_AUTHORITY_ID,
       TRANS_CODE,
       ACT_LOC_CODE,
       CORCT_ACT_EVENT_DATA_OWNER_CDE,
       CORCT_ACT_EVENT_CODE,
       EVENT_AGN_CODE,
       EVENT_SEQ_NUM
FROM RCRA_CA_AUTH_REL_EVENT
    )
/

create view RCRA_EVENT_COMMITMENT_VW as
(
SELECT CA_EVENT_COMMITMENT_ID EVENT_COMMITMENT_ID,
       CA_EVENT_ID,
       NULL                   PRM_EVENT_ID,
       TRANS_CODE,
       COMMIT_LEAD,
       COMMIT_SEQ_NUM
FROM RCRA_CA_EVENT_COMMITMENT
UNION ALL
SELECT PRM_EVENT_COMMITMENT_ID,
       NULL,
       PRM_EVENT_ID,
       TRANS_CODE,
       COMMIT_LEAD,
       COMMIT_SEQ_NUM
FROM RCRA_PRM_EVENT_COMMITMENT
    )
/

create view RCRA_WASTE_CODE_VW as
(
SELECT HD_SEC_WASTE_CODE_ID WASTE_CODE_ID,
       HD_SEC_MATERIAL_ACTIVITY_ID,
       NULL                 HD_HANDLER_ID,
       NULL                 PRM_UNIT_DETAIL_ID,
       TRANSACTION_CODE     TRANS_CODE,
       WASTE_CODE_OWNER,
       WASTE_CODE_TYPE
FROM RCRA_HD_SEC_WASTE_CODE
UNION ALL
SELECT HD_WASTE_CODE_ID,
       NULL,
       HD_HANDLER_ID,
       NULL PRM_UNIT_DETAIL_ID,
       TRANSACTION_CODE,
       WASTE_CODE_OWNER,
       WASTE_CODE_TYPE
FROM RCRA_HD_WASTE_CODE
UNION ALL
SELECT PRM_WASTE_CODE_ID,
       NULL,
       NULL,
       PRM_UNIT_DETAIL_ID,
       TRANSACTION_CODE,
       WASTE_CODE_OWNER,
       WASTE_CODE_TYPE
FROM RCRA_PRM_WASTE_CODE
    )
/

create view WH_TABLE_COUNTS as
SELECT 'RCRA_CA_AREA' table_name,
       count(*)       cnt
FROM RCRA_CA_AREA
UNION ALL
SELECT 'RCRA_CA_AREA_REL_EVENT' table_name,
       count(*)                 cnt
FROM RCRA_CA_AREA_REL_EVENT
UNION ALL
SELECT 'RCRA_CA_AUTH_REL_EVENT' table_name,
       count(*)                 cnt
FROM RCRA_CA_AUTH_REL_EVENT
UNION ALL
SELECT 'RCRA_CA_AUTHORITY' table_name,
       count(*)            cnt
FROM RCRA_CA_AUTHORITY
UNION ALL
SELECT 'RCRA_CA_EVENT' table_name,
       count(*)        cnt
FROM RCRA_CA_EVENT
UNION ALL
SELECT 'RCRA_CA_EVENT_COMMITMENT' table_name,
       count(*)                   cnt
FROM RCRA_CA_EVENT_COMMITMENT
UNION ALL
SELECT 'RCRA_CA_FAC_SUBM' table_name,
       count(*)           cnt
FROM RCRA_CA_FAC_SUBM
UNION ALL
SELECT 'RCRA_CA_REL_PERMIT_UNIT' table_name,
       count(*)                  cnt
FROM RCRA_CA_REL_PERMIT_UNIT
UNION ALL
SELECT 'RCRA_CA_STATUTORY_CITATION' table_name,
       count(*)                     cnt
FROM RCRA_CA_STATUTORY_CITATION
UNION ALL
SELECT 'RCRA_CME_CITATION' table_name,
       count(*)            cnt
FROM RCRA_CME_CITATION
UNION ALL
SELECT 'RCRA_CME_CSNY_DATE' table_name,
       count(*)             cnt
FROM RCRA_CME_CSNY_DATE
UNION ALL
SELECT 'RCRA_CME_ENFRC_ACT' table_name,
       count(*)             cnt
FROM RCRA_CME_ENFRC_ACT
UNION ALL
SELECT 'RCRA_CME_EVAL' table_name,
       count(*)        cnt
FROM RCRA_CME_EVAL
UNION ALL
SELECT 'RCRA_CME_EVAL_COMMIT' table_name,
       count(*)               cnt
FROM RCRA_CME_EVAL_COMMIT
UNION ALL
SELECT 'RCRA_CME_EVAL_VIOL' table_name,
       count(*)             cnt
FROM RCRA_CME_EVAL_VIOL
UNION ALL
SELECT 'RCRA_CME_FAC_SUBM' table_name,
       count(*)            cnt
FROM RCRA_CME_FAC_SUBM
UNION ALL
SELECT 'RCRA_CME_MEDIA' table_name,
       count(*)         cnt
FROM RCRA_CME_MEDIA
UNION ALL
SELECT 'RCRA_CME_MILESTONE' table_name,
       count(*)             cnt
FROM RCRA_CME_MILESTONE
UNION ALL
SELECT 'RCRA_CME_PNLTY' table_name,
       count(*)         cnt
FROM RCRA_CME_PNLTY
UNION ALL
SELECT 'RCRA_CME_PYMT' table_name,
       count(*)        cnt
FROM RCRA_CME_PYMT
UNION ALL
SELECT 'RCRA_CME_RQST' table_name,
       count(*)        cnt
FROM RCRA_CME_RQST
UNION ALL
SELECT 'RCRA_CME_SUPP_ENVR_PRJT' table_name,
       count(*)                  cnt
FROM RCRA_CME_SUPP_ENVR_PRJT
UNION ALL
SELECT 'RCRA_CME_VIOL' table_name,
       count(*)        cnt
FROM RCRA_CME_VIOL
UNION ALL
SELECT 'RCRA_CME_VIOL_ENFRC' table_name,
       count(*)              cnt
FROM RCRA_CME_VIOL_ENFRC
UNION ALL
SELECT 'RCRA_FA_COST_EST' table_name,
       count(*)           cnt
FROM RCRA_FA_COST_EST
UNION ALL
SELECT 'RCRA_FA_COST_EST_REL_MECHANISM' table_name,
       count(*)                         cnt
FROM RCRA_FA_COST_EST_REL_MECHANISM
UNION ALL
SELECT 'RCRA_FA_FAC_SUBM' table_name,
       count(*)           cnt
FROM RCRA_FA_FAC_SUBM
UNION ALL
SELECT 'RCRA_FA_MECHANISM' table_name,
       count(*)            cnt
FROM RCRA_FA_MECHANISM
UNION ALL
SELECT 'RCRA_FA_MECHANISM_DETAIL' table_name,
       count(*)                   cnt
FROM RCRA_FA_MECHANISM_DETAIL
UNION ALL
SELECT 'RCRA_GIS_FAC_SUBM' table_name,
       count(*)            cnt
FROM RCRA_GIS_FAC_SUBM
UNION ALL
SELECT 'RCRA_GIS_GEO_INFORMATION' table_name,
       count(*)                   cnt
FROM RCRA_GIS_GEO_INFORMATION
UNION ALL
SELECT 'RCRA_HD_CERTIFICATION' table_name,
       count(*)                cnt
FROM RCRA_HD_CERTIFICATION
UNION ALL
SELECT 'RCRA_HD_ENV_PERMIT' table_name,
       count(*)             cnt
FROM RCRA_HD_ENV_PERMIT
UNION ALL
SELECT 'RCRA_HD_EPISODIC_EVENT' table_name,
       count(*)                 cnt
FROM RCRA_HD_EPISODIC_EVENT
UNION ALL
SELECT 'RCRA_HD_EPISODIC_WASTE' table_name,
       count(*)                 cnt
FROM RCRA_HD_EPISODIC_WASTE
UNION ALL
SELECT 'RCRA_HD_EPISODIC_WASTE_CODE' table_name,
       count(*)                      cnt
FROM RCRA_HD_EPISODIC_WASTE_CODE
UNION ALL
SELECT 'RCRA_HD_HANDLER' table_name,
       count(*)          cnt
FROM RCRA_HD_HANDLER
UNION ALL
SELECT 'RCRA_HD_HBASIC' table_name,
       count(*)         cnt
FROM RCRA_HD_HBASIC
UNION ALL
SELECT 'RCRA_HD_LQG_CLOSURE' table_name,
       count(*)              cnt
FROM RCRA_HD_LQG_CLOSURE
UNION ALL
SELECT 'RCRA_HD_LQG_CONSOLIDATION' table_name,
       count(*)                    cnt
FROM RCRA_HD_LQG_CONSOLIDATION
UNION ALL
SELECT 'RCRA_HD_NAICS' table_name,
       count(*)        cnt
FROM RCRA_HD_NAICS
UNION ALL
SELECT 'RCRA_HD_OTHER_ID' table_name,
       count(*)           cnt
FROM RCRA_HD_OTHER_ID
UNION ALL
SELECT 'RCRA_HD_OWNEROP' table_name,
       count(*)          cnt
FROM RCRA_HD_OWNEROP
UNION ALL
SELECT 'RCRA_HD_SEC_MATERIAL_ACTIVITY' table_name,
       count(*)                        cnt
FROM RCRA_HD_SEC_MATERIAL_ACTIVITY
UNION ALL
SELECT 'RCRA_HD_SEC_WASTE_CODE' table_name,
       count(*)                 cnt
FROM RCRA_HD_SEC_WASTE_CODE
UNION ALL
SELECT 'RCRA_HD_STATE_ACTIVITY' table_name,
       count(*)                 cnt
FROM RCRA_HD_STATE_ACTIVITY
UNION ALL
SELECT 'RCRA_HD_UNIVERSAL_WASTE' table_name,
       count(*)                  cnt
FROM RCRA_HD_UNIVERSAL_WASTE
UNION ALL
SELECT 'RCRA_HD_WASTE_CODE' table_name,
       count(*)             cnt
FROM RCRA_HD_WASTE_CODE
UNION ALL
SELECT 'RCRA_PRM_EVENT' table_name,
       count(*)         cnt
FROM RCRA_PRM_EVENT
UNION ALL
SELECT 'RCRA_PRM_EVENT_COMMITMENT' table_name,
       count(*)                    cnt
FROM RCRA_PRM_EVENT_COMMITMENT
UNION ALL
SELECT 'RCRA_PRM_FAC_SUBM' table_name,
       count(*)            cnt
FROM RCRA_PRM_FAC_SUBM
UNION ALL
SELECT 'RCRA_PRM_RELATED_EVENT' table_name,
       count(*)                 cnt
FROM RCRA_PRM_RELATED_EVENT
UNION ALL
SELECT 'RCRA_PRM_SERIES' table_name,
       count(*)          cnt
FROM RCRA_PRM_SERIES
UNION ALL
SELECT 'RCRA_PRM_UNIT' table_name,
       count(*)        cnt
FROM RCRA_PRM_UNIT
UNION ALL
SELECT 'RCRA_PRM_UNIT_DETAIL' table_name,
       count(*)               cnt
FROM RCRA_PRM_UNIT_DETAIL
UNION ALL
SELECT 'RCRA_PRM_WASTE_CODE' table_name,
       count(*)              cnt
FROM RCRA_PRM_WASTE_CODE
UNION ALL
SELECT 'RCRA_RU_REPORT_UNIV' table_name,
       count(*)              cnt
FROM RCRA_RU_REPORT_UNIV
UNION ALL
SELECT 'RCRA_SUBMISSIONHISTORY' table_name,
       count(*)                 cnt
FROM RCRA_SUBMISSIONHISTORY
UNION ALL
SELECT 'RCRA_EM_EMANIFEST' table_name,
       count(*)            cnt
FROM RCRA_EM_EMANIFEST
UNION ALL
SELECT 'RCRA_EM_EMANIFEST_COMMENT' table_name,
       count(*)                    cnt
FROM RCRA_EM_EMANIFEST_COMMENT
UNION ALL
SELECT 'RCRA_EM_HANDLER' table_name,
       count(*)          cnt
FROM RCRA_EM_HANDLER
UNION ALL
SELECT 'RCRA_EM_SUBM' table_name,
       count(*)       cnt
FROM RCRA_EM_SUBM
UNION ALL
SELECT 'RCRA_EM_TR_NUM_ORIG' table_name,
       count(*)              cnt
FROM RCRA_EM_TR_NUM_ORIG
UNION ALL
SELECT 'RCRA_EM_TR_NUM_REJ' table_name,
       count(*)             cnt
FROM RCRA_EM_TR_NUM_REJ
UNION ALL
SELECT 'RCRA_EM_TR_NUM_RESIDUE_NEW' table_name,
       count(*)                     cnt
FROM RCRA_EM_TR_NUM_RESIDUE_NEW
UNION ALL
SELECT 'RCRA_EM_TR_NUM_WASTE' table_name,
       count(*)               cnt
FROM RCRA_EM_TR_NUM_WASTE
UNION ALL
SELECT 'RCRA_EM_WASTE' table_name,
       count(*)        cnt
FROM RCRA_EM_WASTE
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_FED' table_name,
       count(*)               cnt
FROM RCRA_EM_WASTE_CD_FED
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_GEN' table_name,
       count(*)               cnt
FROM RCRA_EM_WASTE_CD_GEN
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_TRANS' table_name,
       count(*)                 cnt
FROM RCRA_EM_WASTE_CD_TRANS
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_TSDF' table_name,
       count(*)                cnt
FROM RCRA_EM_WASTE_CD_TSDF
UNION ALL
SELECT 'RCRA_EM_WASTE_COMMENT' table_name,
       count(*)                cnt
FROM RCRA_EM_WASTE_COMMENT
UNION ALL
SELECT 'RCRA_EM_WASTE_PCB' table_name,
       count(*)            cnt
FROM RCRA_EM_WASTE_PCB
UNION ALL
SELECT 'ETL_RUN' table_name,
       count(*)
FROM ETL_RUN
UNION ALL
SELECT 'ETL_RUN_HANDLER' table_name,
       count(*)
FROM ETL_RUN_HANDLER
/

create view HD_HANDLER as
(
SELECT HD_HANDLER_ID,
       HD_HBASIC_ID,
       TRANSACTION_CODE,
       ACTIVITY_LOCATION,
       SOURCE_TYPE,
       SEQ_NUMBER,
       TO_DATE(RECEIVE_DATE, 'YYYY-MM-DD') RECEIVE_DATE,
       HANDLER_NAME,
       ACKNOWLEDGE_DATE,
       NON_NOTIFIER,
       TSD_DATE,
       OFF_SITE_RECEIPT,
       ACCESSIBILITY,
       COUNTY_CODE_OWNER,
       COUNTY_CODE,
       NOTES,
       ACKNOWLEDGE_FLAG,
       LOCATION_STREET1,
       LOCATION_STREET2,
       LOCATION_CITY,
       LOCATION_STATE,
       LOCATION_COUNTRY,
       LOCATION_ZIP,
       MAIL_STREET1,
       MAIL_STREET2,
       MAIL_CITY,
       MAIL_STATE,
       MAIL_COUNTRY,
       MAIL_ZIP,
       CONTACT_FIRST_NAME,
       CONTACT_MIDDLE_INITIAL,
       CONTACT_LAST_NAME,
       CONTACT_ORG_NAME,
       CONTACT_TITLE,
       CONTACT_EMAIL_ADDRESS,
       CONTACT_PHONE,
       CONTACT_PHONE_EXT,
       CONTACT_FAX,
       CONTACT_STREET_NUMBER,
       CONTACT_STREET1,
       CONTACT_STREET2,
       CONTACT_CITY,
       CONTACT_STATE,
       CONTACT_COUNTRY,
       CONTACT_ZIP,
       PCONTACT_FIRST_NAME,
       PCONTACT_MIDDLE_NAME,
       PCONTACT_LAST_NAME,
       PCONTACT_ORG_NAME,
       PCONTACT_TITLE,
       PCONTACT_EMAIL_ADDRESS,
       PCONTACT_PHONE,
       PCONTACT_PHONE_EXT,
       PCONTACT_FAX,
       PCONTACT_STREET_NUMBER,
       PCONTACT_STREET1,
       PCONTACT_STREET2,
       PCONTACT_CITY,
       PCONTACT_STATE,
       PCONTACT_COUNTRY,
       PCONTACT_ZIP,
       USED_OIL_BURNER,
       USED_OIL_PROCESSOR,
       USED_OIL_REFINER,
       USED_OIL_MARKET_BURNER,
       USED_OIL_SPEC_MARKETER,
       USED_OIL_TRANSFER_FACILITY,
       USED_OIL_TRANSPORTER,
       LAND_TYPE,
       STATE_DISTRICT_OWNER,
       STATE_DISTRICT,
       IMPORTER_ACTIVITY,
       MIXED_WASTE_GENERATOR,
       RECYCLER_ACTIVITY,
       TRANSPORTER_ACTIVITY,
       TSD_ACTIVITY,
       UNDERGROUND_INJECTION_ACTIVITY,
       UNIVERSAL_WASTE_DEST_FACILITY,
       ONSITE_BURNER_EXEMPTION,
       FURNACE_EXEMPTION,
       SHORT_TERM_GEN_IND,
       TRANSFER_FACILITY_IND,
       STATE_WASTE_GENERATOR_OWNER,
       STATE_WASTE_GENERATOR,
       FED_WASTE_GENERATOR_OWNER,
       FED_WASTE_GENERATOR,
       COLLEGE_IND,
       HOSPITAL_IND,
       NON_PROFIT_IND,
       WITHDRAWAL_IND,
       TRANS_CODE,
       NOTIFICATION_RSN_CODE,
       EFFC_DATE,
       FINANCIAL_ASSURANCE_IND,
       RECYCLING_IND,
       MAIL_STREET_NUMBER,
       LOCATION_STREET_NUMBER,
       NON_NOTIFIER_TEXT,
       ACCESSIBILITY_TEXT,
       STATE_DISTRICT_TEXT,
       INTRNL_NOTES,
       SHORT_TERM_INTRNL_NOTES,
       NATURE_OF_BUSINESS_TEXT,
       RECOGNIZED_TRADER_IMPORTER_IND,
       RECOGNIZED_TRADER_EXPORTER_IND,
       SLAB_IMPORTER_IND,
       SLAB_EXPORTER_IND,
       RECYCLER_ACT_NONSTORAGE,
       MANIFEST_BROKER,
       ACKNOWLEDGE_FLAG_IND,
       INCLUDE_IN_NATIONAL_REPORT_IND,
       LQHUW_IND,
       HD_REPORT_CYCLE_YEAR,
       HEALTHCARE_FAC,
       REVERSE_DISTRIBUTOR,
       SUBPART_P_WITHDRAWAL,
       RECYCLER_IND
from RCRA_HD_HANDLER
    )
/

create PACKAGE RCRAINFO_ETL AS
    PROCEDURE MERGE_DATA(TRANS_TYPE varchar);
END RCRAINFO_ETL;
/

create synonym NODE_RCRA_SUBMISSIONHISTORY for NODE_FLOW_RCRA.RCRA_SUBMISSIONHISTORY
/

create synonym NODE_RCRA_PRM_SUBM for NODE_FLOW_RCRA.RCRA_PRM_SUBM
/

create synonym NODE_RCRA_HD_SUBM for NODE_FLOW_RCRA.RCRA_HD_SUBM
/

create synonym NODE_RCRA_GIS_SUBM for NODE_FLOW_RCRA.RCRA_GIS_SUBM
/

create synonym NODE_RCRA_FA_SUBM for NODE_FLOW_RCRA.RCRA_FA_SUBM
/

create synonym NODE_RCRA_CME_SUBM for NODE_FLOW_RCRA.RCRA_CME_SUBM
/

create synonym NODE_RCRA_CA_SUBM for NODE_FLOW_RCRA.RCRA_CA_SUBM
/

create synonym NODE_RCRA_CME_FAC_SUBM for NODE_FLOW_RCRA.RCRA_CME_FAC_SUBM
/

create view ETL_CME_FAC_SUBM_VW as
(
SELECT WH.CME_FAC_SUBM_ID WH_CME_FAC_SUBM_ID,
       NODE."CME_FAC_SUBM_ID",
       NODE."CME_SUBM_ID",
       NODE."EPA_HDLR_ID"
FROM NODE_RCRA_CME_FAC_SUBM NODE
         LEFT OUTER JOIN RCRA_CME_FAC_SUBM WH ON WH.EPA_HDLR_ID = NODE.EPA_HDLR_ID
    )
/

create synonym NODE_RCRA_CA_FAC_SUBM for NODE_FLOW_RCRA.RCRA_CA_FAC_SUBM
/

create view ETL_CA_FAC_SUBM_VW as
(
SELECT WH.CA_FAC_SUBM_ID WH_CA_FAC_SUBM_ID,
       NODE."CA_FAC_SUBM_ID",
       NODE."CA_SUBM_ID",
       NODE."HANDLER_ID"
FROM NODE_RCRA_CA_FAC_SUBM NODE
         LEFT OUTER JOIN RCRA_CA_FAC_SUBM WH ON WH.HANDLER_ID = NODE.HANDLER_ID
    )
/

create synonym NODE_RCRA_GIS_FAC_SUBM for NODE_FLOW_RCRA.RCRA_GIS_FAC_SUBM
/

create view ETL_GIS_FAC_SUBM_VW as
(
SELECT WH.GIS_FAC_SUBM_ID WH_GIS_FAC_SUBM_ID,
       NODE."GIS_FAC_SUBM_ID",
       NODE."GIS_SUBM_ID",
       NODE."HANDLER_ID"
FROM NODE_RCRA_GIS_FAC_SUBM NODE
         LEFT OUTER JOIN RCRA_GIS_FAC_SUBM WH ON NODE.HANDLER_ID = WH.HANDLER_ID
    )
/

create synonym NODE_RCRA_FA_FAC_SUBM for NODE_FLOW_RCRA.RCRA_FA_FAC_SUBM
/

create view ETL_FA_FAC_SUBM_VW as
(
SELECT WH.FA_FAC_SUBM_ID WH_FA_FAC_SUBM_ID,
       NODE."FA_FAC_SUBM_ID",
       NODE."FA_SUBM_ID",
       NODE."HANDLER_ID"
FROM NODE_RCRA_FA_FAC_SUBM NODE
         LEFT OUTER JOIN RCRA_FA_FAC_SUBM WH ON WH.HANDLER_ID = NODE.HANDLER_ID
    )
/

create synonym NODE_RCRA_HD_HBASIC for NODE_FLOW_RCRA.RCRA_HD_HBASIC
/

create view ETL_HD_BASIC_VW as
(
SELECT WH.HD_HBASIC_ID WH_HD_HBASIC_ID,
       NODE."HD_HBASIC_ID",
       NODE."HD_SUBM_ID",
       NODE."TRANSACTION_CODE",
       NODE."HANDLER_ID",
       NODE."EXTRACT_FLAG",
       NODE."FACILITY_IDENTIFIER"
FROM NODE_RCRA_HD_HBASIC NODE
         LEFT OUTER JOIN RCRA_HD_HBASIC WH ON WH.HANDLER_ID = NODE.HANDLER_ID
    )
/

create synonym NODE_RCRA_PRM_FAC_SUBM for NODE_FLOW_RCRA.RCRA_PRM_FAC_SUBM
/

create view ETL_PRM_FAC_SUBM_VW as
(
SELECT WH.PRM_FAC_SUBM_ID WH_PRM_FAC_SUBM_ID,
       NODE."PRM_FAC_SUBM_ID",
       NODE."PRM_SUBM_ID",
       NODE."HANDLER_ID"
FROM NODE_RCRA_PRM_FAC_SUBM NODE
         LEFT OUTER JOIN RCRA_PRM_FAC_SUBM WH ON WH.HANDLER_ID = NODE.HANDLER_ID
    )
/

create synonym NODE_RCRA_PRM_SERIES for NODE_FLOW_RCRA.RCRA_PRM_SERIES
/

create view ETL_PRM_SERIES_VW as
(
SELECT WH.PRM_SERIES_ID WH_PRM_SERIES_ID,
       ETL.WH_PRM_FAC_SUBM_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_SERIES_ID",
       NODE."PRM_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."PERMIT_SERIES_SEQ_NUM",
       NODE."PERMIT_SERIES_NAME",
       NODE."RESP_PERSON_DATA_OWNER_CODE",
       NODE."RESP_PERSON_ID",
       NODE."SUPP_INFO_TXT",
       NODE."ACTIVE_SERIES_IND",
       NODE."CREATED_BY_USERID",
       NODE."P_CREATED_DATE",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_PRM_SERIES NODE
         INNER JOIN ETL_PRM_FAC_SUBM_VW ETL ON ETL.PRM_FAC_SUBM_ID = NODE.PRM_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_PRM_SERIES WH ON WH.PRM_FAC_SUBM_ID = ETL.WH_PRM_FAC_SUBM_ID
    AND WH.PERMIT_SERIES_SEQ_NUM = NODE.PERMIT_SERIES_SEQ_NUM
    )
/

create synonym NODE_RCRA_PRM_UNIT for NODE_FLOW_RCRA.RCRA_PRM_UNIT
/

create view ETL_PRM_UNIT_VW as
(
SELECT WH.PRM_UNIT_ID WH_PRM_UNIT_ID,
       ETL.WH_PRM_FAC_SUBM_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_UNIT_ID",
       NODE."PRM_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."PERMIT_UNIT_SEQ_NUM",
       NODE."PERMIT_UNIT_NAME",
       NODE."SUPP_INFO_TXT",
       NODE."ACTIVE_UNIT_IND",
       NODE."CREATED_BY_USERID",
       NODE."P_CREATED_DATE",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_PRM_UNIT NODE
         INNER JOIN ETL_PRM_FAC_SUBM_VW ETL ON ETL.PRM_FAC_SUBM_ID = NODE.PRM_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_PRM_UNIT WH ON WH.PRM_FAC_SUBM_ID = ETL.WH_PRM_FAC_SUBM_ID
    AND WH.PERMIT_UNIT_SEQ_NUM = NODE.PERMIT_UNIT_SEQ_NUM
    )
/

create synonym NODE_RCRA_GIS_GEO_INFORMATION for NODE_FLOW_RCRA.RCRA_GIS_GEO_INFORMATION
/

create view ETL_GIS_GEO_INFORMATION_VW as
(
SELECT WH.GIS_GEO_INFORMATION_ID WH_GIS_GEO_INFORMATION_ID,
       ETL.WH_GIS_FAC_SUBM_ID,
       ETL.GIS_SUBM_ID,
       NODE."GIS_GEO_INFORMATION_ID",
       NODE."GIS_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."GEO_INFO_OWNER",
       NODE."GEO_INFO_SEQ_NUM",
       NODE."PERMIT_UNIT_SEQ_NUM",
       NODE."AREA_SEQ_NUM",
       NODE."LOC_COMM_TXT",
       NODE."AREA_ACREAGE_MEAS",
       NODE."AREA_MEAS_SRC_DATA_OWNER_CODE",
       NODE."AREA_MEAS_SRC_CODE",
       NODE."AREA_MEAS_DATE",
       NODE."DATA_COLL_DATE",
       NODE."HORZ_ACC_MEAS",
       NODE."SRC_MAP_SCALE_NUM",
       NODE."COORD_DATA_SRC_DATA_OWNER_CODE",
       NODE."COORD_DATA_SRC_CODE",
       NODE."GEO_REF_PT_DATA_OWNER_CODE",
       NODE."GEO_REF_PT_CODE",
       NODE."GEOM_TYPE_DATA_OWNER_CODE",
       NODE."GEOM_TYPE_CODE",
       NODE."HORZ_COLL_METH_DATA_OWNER_CODE",
       NODE."HORZ_COLL_METH_CODE",
       NODE."HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE",
       NODE."HORZ_COORD_REF_SYS_DATUM_CODE",
       NODE."VERF_METH_DATA_OWNER_CODE",
       NODE."VERF_METH_CODE",
       NODE."LATITUDE",
       NODE."LONGITUDE",
       NODE."ELEVATION",
       NODE."CREATED_BY_USERID",
       NODE."G_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_GIS_GEO_INFORMATION NODE
         JOIN ETL_GIS_FAC_SUBM_VW ETL ON ETL.GIS_FAC_SUBM_ID = NODE.GIS_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_GIS_GEO_INFORMATION WH ON WH.GIS_FAC_SUBM_ID = ETL.WH_GIS_FAC_SUBM_ID
    AND WH.GEO_INFO_SEQ_NUM = NODE.GEO_INFO_SEQ_NUM
    )
/

create synonym NODE_RCRA_HD_OTHER_ID for NODE_FLOW_RCRA.RCRA_HD_OTHER_ID
/

create view ETL_HD_OTHER_ID_VW as
(
SELECT WH.HD_OTHER_ID_ID WH_HD_OTHER_ID_ID,
       ETL.WH_HD_HBASIC_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_OTHER_ID_ID",
       NODE."HD_HBASIC_ID",
       NODE."TRANSACTION_CODE",
       NODE."OTHER_ID",
       NODE."RELATIONSHIP_OWNER",
       NODE."RELATIONSHIP_TYPE",
       NODE."SAME_FACILITY",
       NODE."NOTES"
FROM NODE_RCRA_HD_OTHER_ID NODE
         INNER JOIN ETL_HD_BASIC_VW ETL ON ETL.HD_HBASIC_ID = NODE.HD_HBASIC_ID
         LEFT OUTER JOIN RCRA_HD_OTHER_ID WH ON WH.HD_HBASIC_ID = ETL.WH_HD_HBASIC_ID
    AND (
                                                            WH.RELATIONSHIP_OWNER = NODE.RELATIONSHIP_OWNER
                                                        OR
                                                            (WH.RELATIONSHIP_OWNER IS NULL AND NODE.RELATIONSHIP_OWNER IS NULL)
                                                    )
    AND WH.RELATIONSHIP_TYPE = NODE.RELATIONSHIP_TYPE
    AND WH.OTHER_ID = NODE.OTHER_ID
    )
/

create synonym NODE_RCRA_HD_HANDLER for NODE_FLOW_RCRA.RCRA_HD_HANDLER
/

create view ETL_HD_HANDLER_ID_VW as
(
SELECT WH.HD_HANDLER_ID    WH_HD_HANDLER_ID,
       ETL.WH_HD_HBASIC_ID WH_HD_HBASIC_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_HANDLER_ID",
       NODE."HD_HBASIC_ID",
       NODE."TRANSACTION_CODE",
       NODE."ACTIVITY_LOCATION",
       NODE."SOURCE_TYPE",
       NODE."SEQ_NUMBER",
       NODE."RECEIVE_DATE",
       NODE."HANDLER_NAME",
       NODE."ACKNOWLEDGE_DATE",
       NODE."NON_NOTIFIER",
       NODE."NON_NOTIFIER_TEXT",
       NODE."TSD_DATE",
       NODE."NATURE_OF_BUSINESS_TEXT",
       NODE."OFF_SITE_RECEIPT",
       NODE."ACCESSIBILITY",
       NODE."ACCESSIBILITY_TEXT",
       NODE."COUNTY_CODE_OWNER",
       NODE."COUNTY_CODE",
       NODE."NOTES",
       NODE."INTRNL_NOTES",
       NODE."SHORT_TERM_INTRNL_NOTES",
       NODE."ACKNOWLEDGE_FLAG_IND",
       NODE."INCLUDE_IN_NATIONAL_REPORT_IND",
       NODE."LQHUW_IND",
       NODE."HD_REPORT_CYCLE_YEAR",
       NODE."HEALTHCARE_FAC",
       NODE."REVERSE_DISTRIBUTOR",
       NODE."SUBPART_P_WITHDRAWAL",
       NODE."ACKNOWLEDGE_FLAG",
       NODE."LOCATION_STREET_NUMBER",
       NODE."LOCATION_STREET1",
       NODE."LOCATION_STREET2",
       NODE."LOCATION_CITY",
       NODE."LOCATION_STATE",
       NODE."LOCATION_COUNTRY",
       NODE."LOCATION_ZIP",
       NODE."MAIL_STREET_NUMBER",
       NODE."MAIL_STREET1",
       NODE."MAIL_STREET2",
       NODE."MAIL_CITY",
       NODE."MAIL_STATE",
       NODE."MAIL_COUNTRY",
       NODE."MAIL_ZIP",
       NODE."CONTACT_FIRST_NAME",
       NODE."CONTACT_MIDDLE_INITIAL",
       NODE."CONTACT_LAST_NAME",
       NODE."CONTACT_ORG_NAME",
       NODE."CONTACT_TITLE",
       NODE."CONTACT_EMAIL_ADDRESS",
       NODE."CONTACT_PHONE",
       NODE."CONTACT_PHONE_EXT",
       NODE."CONTACT_FAX",
       NODE."CONTACT_STREET_NUMBER",
       NODE."CONTACT_STREET1",
       NODE."CONTACT_STREET2",
       NODE."CONTACT_CITY",
       NODE."CONTACT_STATE",
       NODE."CONTACT_COUNTRY",
       NODE."CONTACT_ZIP",
       NODE."PCONTACT_FIRST_NAME",
       NODE."PCONTACT_MIDDLE_NAME",
       NODE."PCONTACT_LAST_NAME",
       NODE."PCONTACT_ORG_NAME",
       NODE."PCONTACT_TITLE",
       NODE."PCONTACT_EMAIL_ADDRESS",
       NODE."PCONTACT_PHONE",
       NODE."PCONTACT_PHONE_EXT",
       NODE."PCONTACT_FAX",
       NODE."PCONTACT_STREET_NUMBER",
       NODE."PCONTACT_STREET1",
       NODE."PCONTACT_STREET2",
       NODE."PCONTACT_CITY",
       NODE."PCONTACT_STATE",
       NODE."PCONTACT_COUNTRY",
       NODE."PCONTACT_ZIP",
       NODE."USED_OIL_BURNER",
       NODE."USED_OIL_PROCESSOR",
       NODE."USED_OIL_REFINER",
       NODE."USED_OIL_MARKET_BURNER",
       NODE."USED_OIL_SPEC_MARKETER",
       NODE."USED_OIL_TRANSFER_FACILITY",
       NODE."USED_OIL_TRANSPORTER",
       NODE."LAND_TYPE",
       NODE."STATE_DISTRICT_OWNER",
       NODE."STATE_DISTRICT",
       NODE."STATE_DISTRICT_TEXT",
       NODE."IMPORTER_ACTIVITY",
       NODE."MIXED_WASTE_GENERATOR",
       NODE."RECYCLER_ACTIVITY",
       NODE."TRANSPORTER_ACTIVITY",
       NODE."TSD_ACTIVITY",
       NODE."UNDERGROUND_INJECTION_ACTIVITY",
       NODE."UNIVERSAL_WASTE_DEST_FACILITY",
       NODE."ONSITE_BURNER_EXEMPTION",
       NODE."FURNACE_EXEMPTION",
       NODE."SHORT_TERM_GEN_IND",
       NODE."TRANSFER_FACILITY_IND",
       NODE."RECOGNIZED_TRADER_IMPORTER_IND",
       NODE."RECOGNIZED_TRADER_EXPORTER_IND",
       NODE."SLAB_IMPORTER_IND",
       NODE."SLAB_EXPORTER_IND",
       NODE."RECYCLER_ACT_NONSTORAGE",
       NODE."MANIFEST_BROKER",
       NODE."STATE_WASTE_GENERATOR_OWNER",
       NODE."STATE_WASTE_GENERATOR",
       NODE."FED_WASTE_GENERATOR_OWNER",
       NODE."FED_WASTE_GENERATOR",
       NODE."COLLEGE_IND",
       NODE."HOSPITAL_IND",
       NODE."NON_PROFIT_IND",
       NODE."WITHDRAWAL_IND",
       NODE."TRANS_CODE",
       NODE."NOTIFICATION_RSN_CODE",
       NODE."EFFC_DATE",
       NODE."FINANCIAL_ASSURANCE_IND",
       NODE."RECYCLER_IND",
       NODE."RECYCLER_NOTES",
       NODE."RECYCLING_IND"
FROM NODE_RCRA_HD_HANDLER NODE
         JOIN ETL_HD_BASIC_VW ETL ON ETL.HD_HBASIC_ID = NODE.HD_HBASIC_ID
         LEFT OUTER JOIN RCRA_HD_HANDLER WH ON WH.HD_HBASIC_ID = ETL.WH_HD_HBASIC_ID
    AND WH.SEQ_NUMBER = NODE.SEQ_NUMBER
    AND WH.SOURCE_TYPE = NODE.SOURCE_TYPE
    )
/

create view ETL_HD_HANDLER_VW as
(
SELECT WH.HD_HANDLER_ID WH_HD_HANDLER_ID,
       ETL.WH_HD_HBASIC_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_HANDLER_ID",
       NODE."HD_HBASIC_ID",
       NODE."TRANSACTION_CODE",
       NODE."ACTIVITY_LOCATION",
       NODE."SOURCE_TYPE",
       NODE."SEQ_NUMBER",
       NODE."RECEIVE_DATE",
       NODE."HANDLER_NAME",
       NODE."ACKNOWLEDGE_DATE",
       NODE."NON_NOTIFIER",
       NODE."TSD_DATE",
       NODE."OFF_SITE_RECEIPT",
       NODE."ACCESSIBILITY",
       NODE."COUNTY_CODE_OWNER",
       NODE."COUNTY_CODE",
       NODE."NOTES",
       NODE."ACKNOWLEDGE_FLAG",
       NODE."LOCATION_STREET1",
       NODE."LOCATION_STREET2",
       NODE."LOCATION_CITY",
       NODE."LOCATION_STATE",
       NODE."LOCATION_COUNTRY",
       NODE."LOCATION_ZIP",
       NODE."MAIL_STREET1",
       NODE."MAIL_STREET2",
       NODE."MAIL_CITY",
       NODE."MAIL_STATE",
       NODE."MAIL_COUNTRY",
       NODE."MAIL_ZIP",
       NODE."CONTACT_FIRST_NAME",
       NODE."CONTACT_MIDDLE_INITIAL",
       NODE."CONTACT_LAST_NAME",
       NODE."CONTACT_ORG_NAME",
       NODE."CONTACT_TITLE",
       NODE."CONTACT_EMAIL_ADDRESS",
       NODE."CONTACT_PHONE",
       NODE."CONTACT_PHONE_EXT",
       NODE."CONTACT_FAX",
       NODE."CONTACT_STREET_NUMBER",
       NODE."CONTACT_STREET1",
       NODE."CONTACT_STREET2",
       NODE."CONTACT_CITY",
       NODE."CONTACT_STATE",
       NODE."CONTACT_COUNTRY",
       NODE."CONTACT_ZIP",
       NODE."PCONTACT_FIRST_NAME",
       NODE."PCONTACT_MIDDLE_NAME",
       NODE."PCONTACT_LAST_NAME",
       NODE."PCONTACT_ORG_NAME",
       NODE."PCONTACT_TITLE",
       NODE."PCONTACT_EMAIL_ADDRESS",
       NODE."PCONTACT_PHONE",
       NODE."PCONTACT_PHONE_EXT",
       NODE."PCONTACT_FAX",
       NODE."PCONTACT_STREET_NUMBER",
       NODE."PCONTACT_STREET1",
       NODE."PCONTACT_STREET2",
       NODE."PCONTACT_CITY",
       NODE."PCONTACT_STATE",
       NODE."PCONTACT_COUNTRY",
       NODE."PCONTACT_ZIP",
       NODE."USED_OIL_BURNER",
       NODE."USED_OIL_PROCESSOR",
       NODE."USED_OIL_REFINER",
       NODE."USED_OIL_MARKET_BURNER",
       NODE."USED_OIL_SPEC_MARKETER",
       NODE."USED_OIL_TRANSFER_FACILITY",
       NODE."USED_OIL_TRANSPORTER",
       NODE."LAND_TYPE",
       NODE."STATE_DISTRICT_OWNER",
       NODE."STATE_DISTRICT",
       NODE."IMPORTER_ACTIVITY",
       NODE."MIXED_WASTE_GENERATOR",
       NODE."RECYCLER_ACTIVITY",
       NODE."TRANSPORTER_ACTIVITY",
       NODE."TSD_ACTIVITY",
       NODE."UNDERGROUND_INJECTION_ACTIVITY",
       NODE."UNIVERSAL_WASTE_DEST_FACILITY",
       NODE."ONSITE_BURNER_EXEMPTION",
       NODE."FURNACE_EXEMPTION",
       NODE."SHORT_TERM_GEN_IND",
       NODE."TRANSFER_FACILITY_IND",
       NODE."STATE_WASTE_GENERATOR_OWNER",
       NODE."STATE_WASTE_GENERATOR",
       NODE."FED_WASTE_GENERATOR_OWNER",
       NODE."FED_WASTE_GENERATOR",
       NODE."COLLEGE_IND",
       NODE."HOSPITAL_IND",
       NODE."NON_PROFIT_IND",
       NODE."WITHDRAWAL_IND",
       NODE."TRANS_CODE",
       NODE."NOTIFICATION_RSN_CODE",
       NODE."EFFC_DATE",
       NODE."FINANCIAL_ASSURANCE_IND",
       NODE."RECYCLING_IND",
       NODE."MAIL_STREET_NUMBER",
       NODE."LOCATION_STREET_NUMBER",
       NODE."NON_NOTIFIER_TEXT",
       NODE."ACCESSIBILITY_TEXT",
       NODE."STATE_DISTRICT_TEXT",
       NODE."INTRNL_NOTES",
       NODE."SHORT_TERM_INTRNL_NOTES",
       NODE."NATURE_OF_BUSINESS_TEXT",
       NODE."RECOGNIZED_TRADER_IMPORTER_IND",
       NODE."RECOGNIZED_TRADER_EXPORTER_IND",
       NODE."SLAB_IMPORTER_IND",
       NODE."SLAB_EXPORTER_IND",
       NODE."RECYCLER_ACT_NONSTORAGE",
       NODE."MANIFEST_BROKER",
       NODE."RECYCLER_NOTES",
       NODE."ACKNOWLEDGE_FLAG_IND",
       NODE."INCLUDE_IN_NATIONAL_REPORT_IND",
       NODE."LQHUW_IND",
       NODE."HD_REPORT_CYCLE_YEAR",
       NODE."HEALTHCARE_FAC",
       NODE."REVERSE_DISTRIBUTOR",
       NODE."SUBPART_P_WITHDRAWAL",
       NODE."RECYCLER_IND",
       NODE."CURRENT_RECORD",
       NODE."CREATED_BY_USERID",
       NODE."H_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LOCATION_LATITUDE",
       NODE."LOCATION_LONGITUDE",
       NODE."LOCATION_GIS_PRIM",
       NODE."LOCATION_GIS_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE",
       NODE."BR_EXEMPT_IND"
FROM NODE_RCRA_HD_HANDLER NODE
         INNER JOIN ETL_HD_BASIC_VW ETL ON ETL.HD_HBASIC_ID = NODE.HD_HBASIC_ID
         LEFT OUTER JOIN RCRA_HD_HANDLER WH ON WH.HD_HBASIC_ID = ETL.WH_HD_HBASIC_ID
    AND WH.ACTIVITY_LOCATION = NODE.ACTIVITY_LOCATION
    AND WH.SEQ_NUMBER = NODE.SEQ_NUMBER
    AND WH.SOURCE_TYPE = NODE.SOURCE_TYPE
    )
/

create synonym NODE_RCRA_CA_AREA for NODE_FLOW_RCRA.RCRA_CA_AREA
/

create view ETL_CA_AREA_VW as
(
SELECT WH.CA_AREA_ID WH_CA_AREA_ID,
       ETL.WH_CA_FAC_SUBM_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_AREA_ID",
       NODE."CA_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."AREA_SEQ_NUM",
       NODE."FAC_WIDE_IND",
       NODE."AREA_NAME",
       NODE."AIR_REL_IND",
       NODE."GROUNDWATER_REL_IND",
       NODE."SOIL_REL_IND",
       NODE."SURFACE_WATER_REL_IND",
       NODE."REGULATED_UNIT_IND",
       NODE."EPA_RESP_PERSON_DATA_OWNER_CDE",
       NODE."EPA_RESP_PERSON_ID",
       NODE."STA_RESP_PERSON_DATA_OWNER_CDE",
       NODE."STA_RESP_PERSON_ID",
       NODE."SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."A_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CA_AREA NODE
         INNER JOIN ETL_CA_FAC_SUBM_VW ETL ON ETL.CA_FAC_SUBM_ID = NODE.CA_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CA_AREA WH ON WH.CA_FAC_SUBM_ID = ETL.WH_CA_FAC_SUBM_ID
    AND WH.AREA_SEQ_NUM = NODE.AREA_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_VIOL for NODE_FLOW_RCRA.RCRA_CME_VIOL
/

create view ETL_CME_VIOL_VW as
(
SELECT WH.CME_VIOL_ID WH_CME_VIOL_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_VIOL_ID",
       NODE."CME_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."VIOL_ACT_LOC",
       NODE."VIOL_SEQ_NUM",
       NODE."AGN_WHICH_DTRM_VIOL",
       NODE."VIOL_TYPE_OWNER",
       NODE."VIOL_TYPE",
       NODE."FORMER_CITATION_NAME",
       NODE."VIOL_DTRM_DATE",
       NODE."RTN_COMPL_ACTL_DATE",
       NODE."RTN_TO_COMPL_QUAL",
       NODE."VIOL_RESP_AGN",
       NODE."NOTES",
       NODE."CREATED_BY_USERID",
       NODE."C_CREATED_DATE",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CME_VIOL NODE
         JOIN ETL_CME_FAC_SUBM_VW ETL ON ETL.CME_FAC_SUBM_ID = NODE.CME_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CME_VIOL WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.VIOL_SEQ_NUM = NODE.VIOL_SEQ_NUM
    AND WH.VIOL_ACT_LOC = NODE.VIOL_ACT_LOC
    AND WH.AGN_WHICH_DTRM_VIOL = NODE.AGN_WHICH_DTRM_VIOL
    )
/

create synonym NODE_RCRA_FA_MECHANISM for NODE_FLOW_RCRA.RCRA_FA_MECHANISM
/

create view ETL_FA_MECHANISM_VW as
(
SELECT WH.FA_MECHANISM_ID WH_FA_MECHANISM_ID,
       ETL.WH_FA_FAC_SUBM_ID,
       ETL.FA_SUBM_ID,
       NODE."FA_MECHANISM_ID",
       NODE."FA_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."MECHANISM_AGN_CODE",
       NODE."MECHANISM_SEQ_NUM",
       NODE."MECHANISM_TYPE_DATA_OWNER_CODE",
       NODE."MECHANISM_TYPE_CODE",
       NODE."PROVIDER_TXT",
       NODE."PROVIDER_FULL_CONTACT_NAME",
       NODE."TELE_NUM_TXT",
       NODE."SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."F_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."PROVIDER_CONTACT_EMAIL",
       NODE."ACTIVE_MECHANISM_IND",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_FA_MECHANISM NODE
         INNER JOIN ETL_FA_FAC_SUBM_VW ETL ON ETL.FA_FAC_SUBM_ID = NODE.FA_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_FA_MECHANISM WH ON WH.FA_FAC_SUBM_ID = ETL.WH_FA_FAC_SUBM_ID
    AND WH.MECHANISM_SEQ_NUM = NODE.MECHANISM_SEQ_NUM
    AND WH.MECHANISM_AGN_CODE = NODE.MECHANISM_AGN_CODE
    )
/

create synonym NODE_RCRA_FA_COST_EST for NODE_FLOW_RCRA.RCRA_FA_COST_EST
/

create view ETL_FA_COST_EST_VW as
(
SELECT WH.FA_COST_EST_ID WH_FA_COST_EST_ID,
       ETL.WH_FA_FAC_SUBM_ID,
       ETL.FA_SUBM_ID,
       NODE."FA_COST_EST_ID",
       NODE."FA_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."COST_ESTIMATE_TYPE_CODE",
       NODE."COST_ESTIMATE_AGN_CODE",
       NODE."COST_ESTIMATE_SEQ_NUM",
       NODE."RESP_PERSON_DATA_OWNER_CODE",
       NODE."RESP_PERSON_ID",
       NODE."COST_ESTIMATE_AMOUNT",
       NODE."COST_ESTIMATE_DATE",
       NODE."COST_ESTIMATE_RSN_CODE",
       NODE."AREA_UNIT_NOTES_TXT",
       NODE."SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."F_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."UPDATE_DUE_DATE",
       NODE."CURRENT_COST_ESTIMATE_IND",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_FA_COST_EST NODE
         INNER JOIN ETL_FA_FAC_SUBM_VW ETL ON ETL.FA_FAC_SUBM_ID = NODE.FA_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_FA_COST_EST WH
                         ON WH.FA_FAC_SUBM_ID = ETL.WH_FA_FAC_SUBM_ID
                             AND WH.ACT_LOC_CODE = NODE.ACT_LOC_CODE
                             AND WH.COST_ESTIMATE_TYPE_CODE = NODE.COST_ESTIMATE_TYPE_CODE
                             AND WH.COST_ESTIMATE_AGN_CODE = NODE.COST_ESTIMATE_AGN_CODE
                             AND WH.COST_ESTIMATE_SEQ_NUM = NODE.COST_ESTIMATE_SEQ_NUM
    )
/

create synonym NODE_RCRA_CA_EVENT for NODE_FLOW_RCRA.RCRA_CA_EVENT
/

create view ETL_CA_EVENT_VW as
(
SELECT WH.CA_EVENT_ID WH_CA_EVENT_ID,
       ETL.WH_CA_FAC_SUBM_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_EVENT_ID",
       NODE."CA_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."CORCT_ACT_EVENT_DATA_OWNER_CDE",
       NODE."CORCT_ACT_EVENT_CODE",
       NODE."EVENT_AGN_CODE",
       NODE."EVENT_SEQ_NUM",
       NODE."ACTL_DATE",
       NODE."ORIGINAL_SCHEDULE_DATE",
       NODE."NEW_SCHEDULE_DATE",
       NODE."EVENT_SUBORG_DATA_OWNER_CODE",
       NODE."EVENT_SUBORG_CODE",
       NODE."RESP_PERSON_DATA_OWNER_CODE",
       NODE."RESP_PERSON_ID",
       NODE."SUPP_INFO_TXT",
       NODE."PUBLIC_SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."A_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CA_EVENT NODE
         INNER JOIN ETL_CA_FAC_SUBM_VW ETL ON ETL.CA_FAC_SUBM_ID = NODE.CA_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CA_EVENT WH ON WH.CA_FAC_SUBM_ID = ETL.WH_CA_FAC_SUBM_ID
    AND WH.EVENT_SEQ_NUM = NODE.EVENT_SEQ_NUM
    AND WH.EVENT_AGN_CODE = NODE.EVENT_AGN_CODE
    AND WH.CORCT_ACT_EVENT_CODE = NODE.CORCT_ACT_EVENT_CODE
    )
/

create synonym NODE_RCRA_CA_AUTHORITY for NODE_FLOW_RCRA.RCRA_CA_AUTHORITY
/

create view ETL_CA_AUTHORITY_VW as
(
SELECT WH.CA_AUTHORITY_ID WH_CA_AUTHORITY_ID,
       ETL.WH_CA_FAC_SUBM_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_AUTHORITY_ID",
       NODE."CA_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."AUTHORITY_DATA_OWNER_CODE",
       NODE."AUTHORITY_TYPE_CODE",
       NODE."AUTHORITY_AGN_CODE",
       NODE."AUTHORITY_EFFC_DATE",
       NODE."ISSUE_DATE",
       NODE."END_DATE",
       NODE."ESTABLISHED_REPOSITORY_CODE",
       NODE."RESP_LEAD_PROG_IDEN",
       NODE."AUTHORITY_SUBORG_DATA_OWNR_CDE",
       NODE."AUTHORITY_SUBORG_CODE",
       NODE."RESP_PERSON_DATA_OWNER_CODE",
       NODE."RESP_PERSON_ID",
       NODE."SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."A_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CA_AUTHORITY NODE
         INNER JOIN ETL_CA_FAC_SUBM_VW ETL ON ETL.CA_FAC_SUBM_ID = NODE.CA_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CA_AUTHORITY WH ON WH.CA_FAC_SUBM_ID = ETL.WH_CA_FAC_SUBM_ID
    AND WH.ACT_LOC_CODE = NODE.ACT_LOC_CODE
    AND WH.AUTHORITY_AGN_CODE = NODE.AUTHORITY_AGN_CODE
    AND WH.AUTHORITY_EFFC_DATE = NODE.AUTHORITY_EFFC_DATE
    AND WH.AUTHORITY_DATA_OWNER_CODE = NODE.AUTHORITY_DATA_OWNER_CODE
    AND WH.AUTHORITY_TYPE_CODE = NODE.AUTHORITY_TYPE_CODE
    )
/

create synonym NODE_RCRA_CME_EVAL for NODE_FLOW_RCRA.RCRA_CME_EVAL
/

create view ETL_CME_EVAL_VW as
(
SELECT WH.CME_EVAL_ID WH_CME_EVAL_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_EVAL_ID",
       NODE."CME_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."EVAL_ACT_LOC",
       NODE."EVAL_IDEN",
       NODE."EVAL_START_DATE",
       NODE."EVAL_RESP_AGN",
       NODE."DAY_ZERO",
       NODE."FOUND_VIOL",
       NODE."CTZN_CPLT_IND",
       NODE."MULTIMEDIA_IND",
       NODE."SAMPL_IND",
       NODE."NOT_SUBTL_C_IND",
       NODE."EVAL_TYPE_OWNER",
       NODE."EVAL_TYPE",
       NODE."FOCUS_AREA_OWNER",
       NODE."FOCUS_AREA",
       NODE."EVAL_RESP_PERSON_IDEN_OWNER",
       NODE."EVAL_RESP_PERSON_IDEN",
       NODE."EVAL_RESP_SUBORG_OWNER",
       NODE."EVAL_RESP_SUBORG",
       NODE."NOTES",
       NODE."NOC_DATE",
       NODE."CREATED_BY_USERID",
       NODE."C_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CME_EVAL NODE
         JOIN ETL_CME_FAC_SUBM_VW ETL ON ETL.CME_FAC_SUBM_ID = NODE.CME_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CME_EVAL WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.EVAL_ACT_LOC = NODE.EVAL_ACT_LOC
    AND WH.EVAL_IDEN = NODE.EVAL_IDEN
    AND WH.EVAL_RESP_AGN = NODE.EVAL_RESP_AGN
    AND WH.EVAL_START_DATE = NODE.EVAL_START_DATE
    )
/

create synonym NODE_RCRA_CME_ENFRC_ACT for NODE_FLOW_RCRA.RCRA_CME_ENFRC_ACT
/

create view ETL_CME_ENFRC_ACT_VW as
(
SELECT WH.CME_ENFRC_ACT_ID WH_CME_ENFR_ACT_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_ENFRC_ACT_ID",
       NODE."CME_FAC_SUBM_ID",
       NODE."TRANS_CODE",
       NODE."ENFRC_AGN_LOC_NAME",
       NODE."ENFRC_ACT_IDEN",
       NODE."ENFRC_ACT_DATE",
       NODE."ENFRC_AGN_NAME",
       NODE."ENFRC_DOCKET_NUM",
       NODE."ENFRC_ATTRY",
       NODE."CORCT_ACT_COMPT",
       NODE."CNST_AGMT_FINAL_ORDER_SEQ_NUM",
       NODE."APPEAL_INIT_DATE",
       NODE."APPEAL_RSLN_DATE",
       NODE."DISP_STAT_DATE",
       NODE."DISP_STAT_OWNER",
       NODE."DISP_STAT",
       NODE."ENFRC_OWNER",
       NODE."ENFRC_TYPE",
       NODE."ENFRC_RESP_PERSON_OWNER",
       NODE."ENFRC_RESP_PERSON_IDEN",
       NODE."ENFRC_RESP_SUBORG_OWNER",
       NODE."ENFRC_RESP_SUBORG",
       NODE."NOTES",
       NODE."FA_REQUIRED",
       NODE."CREATED_BY_USERID",
       NODE."C_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_CME_ENFRC_ACT NODE
         INNER JOIN ETL_CME_FAC_SUBM_VW ETL ON ETL.CME_FAC_SUBM_ID = NODE.CME_FAC_SUBM_ID
         LEFT OUTER JOIN RCRA_CME_ENFRC_ACT WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.ENFRC_ACT_IDEN = NODE.ENFRC_ACT_IDEN
    AND WH.ENFRC_ACT_DATE = NODE.ENFRC_ACT_DATE
    AND WH.ENFRC_AGN_NAME = NODE.ENFRC_AGN_NAME
    )
/

create synonym NODE_RCRA_CME_CSNY_DATE for NODE_FLOW_RCRA.RCRA_CME_CSNY_DATE
/

create view ETL_CME_CSNY_DATE_VW as
(
SELECT WH.CME_CSNY_DATE_ID WH_CME_CSNY_DATE_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_CSNY_DATE_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."SNY_DATE"
FROM NODE_RCRA_CME_CSNY_DATE NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_CSNY_DATE WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.SNY_DATE = NODE.SNY_DATE
    )
/

create synonym NODE_RCRA_CME_CITATION for NODE_FLOW_RCRA.RCRA_CME_CITATION
/

create view ETL_CME_CITATION_VW as
(
SELECT WH.CME_CITATION_ID WH_CME_CITATION_ID,
       ETL.WH_CME_VIOL_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_CITATION_ID",
       NODE."CME_VIOL_ID",
       NODE."TRANS_CODE",
       NODE."CITATION_NAME_SEQ_NUM",
       NODE."CITATION_NAME",
       NODE."CITATION_NAME_OWNER",
       NODE."CITATION_NAME_TYPE",
       NODE."NOTES"
FROM NODE_RCRA_CME_CITATION NODE
         INNER JOIN ETL_CME_VIOL_VW ETL ON ETL.CME_VIOL_ID = NODE.CME_VIOL_ID
         LEFT OUTER JOIN RCRA_CME_CITATION WH ON WH.CME_VIOL_ID = ETL.WH_CME_VIOL_ID
    AND WH.CITATION_NAME_SEQ_NUM = NODE.CITATION_NAME_SEQ_NUM
    )
/

create synonym NODE_RCRA_CA_EVENT_COMMITMENT for NODE_FLOW_RCRA.RCRA_CA_EVENT_COMMITMENT
/

create view ETL_CA_EVENT_COMMITMENT_VW as
(
SELECT WH.CA_EVENT_COMMITMENT_ID WH_CA_EVENT_COMMITMENT_ID,
       ETL.WH_CA_EVENT_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_EVENT_COMMITMENT_ID",
       NODE."CA_EVENT_ID",
       NODE."TRANS_CODE",
       NODE."COMMIT_LEAD",
       NODE."COMMIT_SEQ_NUM"
FROM NODE_RCRA_CA_EVENT_COMMITMENT NODE
         INNER JOIN ETL_CA_EVENT_VW ETL ON ETL.CA_EVENT_ID = NODE.CA_EVENT_ID
         LEFT OUTER JOIN RCRA_CA_EVENT_COMMITMENT WH ON WH.CA_EVENT_ID = ETL.WH_CA_EVENT_ID
    AND WH.COMMIT_SEQ_NUM = NODE.COMMIT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CA_AUTH_REL_EVENT for NODE_FLOW_RCRA.RCRA_CA_AUTH_REL_EVENT
/

create view ETL_CA_AUTH_REL_EVENT_VW as
(
SELECT WH.CA_AUTH_REL_EVENT_ID WH_CA_AUTH_REL_EVENT_ID,
       ETL.WH_CA_AUTHORITY_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_AUTH_REL_EVENT_ID",
       NODE."CA_AUTHORITY_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."CORCT_ACT_EVENT_DATA_OWNER_CDE",
       NODE."CORCT_ACT_EVENT_CODE",
       NODE."EVENT_AGN_CODE",
       NODE."EVENT_SEQ_NUM"
FROM NODE_RCRA_CA_AUTH_REL_EVENT NODE
         INNER JOIN ETL_CA_AUTHORITY_VW ETL ON ETL.CA_AUTHORITY_ID = NODE.CA_AUTHORITY_ID
         LEFT OUTER JOIN RCRA_CA_AUTH_REL_EVENT WH ON WH.CA_AUTHORITY_ID = ETL.WH_CA_AUTHORITY_ID
    AND
                                                      WH.CORCT_ACT_EVENT_DATA_OWNER_CDE = NODE.CORCT_ACT_EVENT_DATA_OWNER_CDE
    AND WH.CORCT_ACT_EVENT_CODE = NODE.CORCT_ACT_EVENT_CODE
    AND WH.EVENT_AGN_CODE = NODE.EVENT_AGN_CODE
    AND WH.EVENT_SEQ_NUM = NODE.EVENT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CA_AREA_REL_EVENT for NODE_FLOW_RCRA.RCRA_CA_AREA_REL_EVENT
/

create view ETL_CA_AREA_REL_EVENT_VW as
(
SELECT WH.CA_AREA_REL_EVENT_ID WH_CA_AREA_REL_EVENT_ID,
       ETL.WH_CA_AREA_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_AREA_REL_EVENT_ID",
       NODE."CA_AREA_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."CORCT_ACT_EVENT_DATA_OWNER_CDE",
       NODE."CORCT_ACT_EVENT_CODE",
       NODE."EVENT_AGN_CODE",
       NODE."EVENT_SEQ_NUM"
FROM NODE_RCRA_CA_AREA_REL_EVENT NODE
         INNER JOIN ETL_CA_AREA_VW ETL ON ETL.CA_AREA_ID = NODE.CA_AREA_ID
         LEFT OUTER JOIN RCRA_CA_AREA_REL_EVENT WH ON WH.CA_AREA_ID = ETL.WH_CA_AREA_ID
    AND
                                                      WH.CORCT_ACT_EVENT_DATA_OWNER_CDE = NODE.CORCT_ACT_EVENT_DATA_OWNER_CDE
    AND WH.CORCT_ACT_EVENT_CODE = NODE.CORCT_ACT_EVENT_CODE
    AND WH.EVENT_AGN_CODE = NODE.EVENT_AGN_CODE
    AND WH.EVENT_SEQ_NUM = NODE.EVENT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_EVAL_VIOL for NODE_FLOW_RCRA.RCRA_CME_EVAL_VIOL
/

create view ETL_CME_EVAL_VIOL_VW as
(
SELECT WH.CME_EVAL_VIOL_ID WH_CME_EVAL_VIOL_ID,
       ETL.WH_CME_EVAL_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_EVAL_VIOL_ID",
       NODE."CME_EVAL_ID",
       NODE."TRANS_CODE",
       NODE."VIOL_ACT_LOC",
       NODE."VIOL_SEQ_NUM",
       NODE."AGN_WHICH_DTRM_VIOL"
FROM NODE_RCRA_CME_EVAL_VIOL NODE
         INNER JOIN ETL_CME_EVAL_VW ETL ON ETL.CME_EVAL_ID = NODE.CME_EVAL_ID
         LEFT OUTER JOIN RCRA_CME_EVAL_VIOL WH ON WH.CME_EVAL_ID = ETL.WH_CME_EVAL_ID
    AND WH.VIOL_ACT_LOC = NODE.VIOL_ACT_LOC
    AND WH.VIOL_SEQ_NUM = NODE.VIOL_SEQ_NUM
    AND WH.AGN_WHICH_DTRM_VIOL = NODE.AGN_WHICH_DTRM_VIOL
    )
/

create synonym NODE_RCRA_CME_EVAL_COMMIT for NODE_FLOW_RCRA.RCRA_CME_EVAL_COMMIT
/

create view ETL_CME_EVAL_COMMIT_VW as
(
SELECT WH.CME_EVAL_COMMIT_ID WH_CME_EVAL_COMMIT_ID,
       ETL.WH_CME_EVAL_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_EVAL_COMMIT_ID",
       NODE."CME_EVAL_ID",
       NODE."TRANS_CODE",
       NODE."COMMIT_LEAD",
       NODE."COMMIT_SEQ_NUM"
FROM NODE_RCRA_CME_EVAL_COMMIT NODE
         INNER JOIN ETL_CME_EVAL_VW ETL ON ETL.CME_EVAL_ID = NODE.CME_EVAL_ID
         LEFT OUTER JOIN RCRA_CME_EVAL_COMMIT WH ON WH.CME_EVAL_ID = ETL.WH_CME_EVAL_ID
    AND WH.COMMIT_SEQ_NUM = NODE.COMMIT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CA_REL_PERMIT_UNIT for NODE_FLOW_RCRA.RCRA_CA_REL_PERMIT_UNIT
/

create view ETL_CA_REL_PERMIT_UNIT_VW as
(
SELECT WH.CA_REL_PERMIT_UNIT_ID WH_CA_REL_PERMIT_UNIT_ID,
       ETL.WH_CA_AREA_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_REL_PERMIT_UNIT_ID",
       NODE."CA_AREA_ID",
       NODE."TRANS_CODE",
       NODE."PERMIT_UNIT_SEQ_NUM"
FROM NODE_RCRA_CA_REL_PERMIT_UNIT NODE
         INNER JOIN ETL_CA_AREA_VW ETL ON ETL.CA_AREA_ID = NODE.CA_AREA_ID
         LEFT OUTER JOIN RCRA_CA_REL_PERMIT_UNIT WH ON WH.CA_AREA_ID = ETL.WH_CA_AREA_ID
    AND WH.PERMIT_UNIT_SEQ_NUM = NODE.PERMIT_UNIT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_PNLTY for NODE_FLOW_RCRA.RCRA_CME_PNLTY
/

create view ETL_CME_PNLTY_VW as
(
SELECT WH.CME_PNLTY_ID WH_CME_PNLTY_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_PNLTY_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."PNLTY_TYPE_OWNER",
       NODE."PNLTY_TYPE",
       NODE."CASH_CIVIL_PNLTY_SOUGHT_AMOUNT",
       NODE."NOTES"
FROM NODE_RCRA_CME_PNLTY NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_PNLTY WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.PNLTY_TYPE_OWNER = NODE.PNLTY_TYPE_OWNER
    AND WH.PNLTY_TYPE = NODE.PNLTY_TYPE
    )
/

create synonym NODE_RCRA_CME_MILESTONE for NODE_FLOW_RCRA.RCRA_CME_MILESTONE
/

create view ETL_CME_MILESTONE_VW as
(
SELECT WH.CME_MILESTONE_ID WH_CME_MILESTONE_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_MILESTONE_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."MILESTONE_SEQ_NUM",
       NODE."TECH_RQMT_IDEN",
       NODE."TECH_RQMT_DESC",
       NODE."MILESTONE_SCHD_COMP_DATE",
       NODE."MILESTONE_ACTL_COMP_DATE",
       NODE."MILESTONE_DFLT_DATE",
       NODE."NOTES"
FROM NODE_RCRA_CME_MILESTONE NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_MILESTONE WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.MILESTONE_SEQ_NUM = NODE.MILESTONE_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_MEDIA for NODE_FLOW_RCRA.RCRA_CME_MEDIA
/

create view ETL_CME_MEDIA_VW as
(
SELECT WH.CME_MEDIA_ID WH_CME_MEDIA_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_MEDIA_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."MULTIMEDIA_CODE_OWNER",
       NODE."MULTIMEDIA_CODE",
       NODE."NOTES"
FROM NODE_RCRA_CME_MEDIA NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_MEDIA WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.MULTIMEDIA_CODE_OWNER = NODE.MULTIMEDIA_CODE_OWNER
    AND WH.MULTIMEDIA_CODE = NODE.MULTIMEDIA_CODE
    )
/

create synonym NODE_RCRA_CME_RQST for NODE_FLOW_RCRA.RCRA_CME_RQST
/

create view ETL_CME_RQST_VW as
(
SELECT WH.CME_RQST_ID WH_CME_RQST_ID,
       ETL.WH_CME_EVAL_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_RQST_ID",
       NODE."CME_EVAL_ID",
       NODE."TRANS_CODE",
       NODE."RQST_SEQ_NUM",
       NODE."DATE_OF_RQST",
       NODE."DATE_RESP_RCVD",
       NODE."RQST_AGN",
       NODE."NOTES"
FROM NODE_RCRA_CME_RQST NODE
         INNER JOIN ETL_CME_EVAL_VW ETL ON ETL.CME_EVAL_ID = NODE.CME_EVAL_ID
         LEFT OUTER JOIN RCRA_CME_RQST WH ON WH.CME_EVAL_ID = ETL.WH_CME_EVAL_ID
    AND WH.RQST_SEQ_NUM = NODE.RQST_SEQ_NUM
    )
/

create synonym NODE_RCRA_FA_MECHANISM_DETAIL for NODE_FLOW_RCRA.RCRA_FA_MECHANISM_DETAIL
/

create view ETL_FA_MECHANISM_DETAIL_VW as
(
SELECT WH.FA_MECHANISM_DETAIL_ID WH_FA_MECHANISM_DETAIL_ID,
       ETL.WH_FA_MECHANISM_ID,
       ETL.FA_SUBM_ID,
       NODE."FA_MECHANISM_DETAIL_ID",
       NODE."FA_MECHANISM_ID",
       NODE."TRANS_CODE",
       NODE."MECHANISM_DETAIL_SEQ_NUM",
       NODE."MECHANISM_IDEN_TXT",
       NODE."FACE_VAL_AMOUNT",
       NODE."EFFC_DATE",
       NODE."EXPIRATION_DATE",
       NODE."SUPP_INFO_TXT",
       NODE."CURRENT_MECHANISM_DETAIL_IND",
       NODE."CREATED_BY_USERID",
       NODE."F_CREATED_DATE",
       NODE."DATA_ORIG",
       NODE."FAC_FACE_VAL_AMOUNT",
       NODE."ALT_IND",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_FA_MECHANISM_DETAIL NODE
         INNER JOIN ETL_FA_MECHANISM_VW ETL ON ETL.FA_MECHANISM_ID = NODE.FA_MECHANISM_ID
         LEFT OUTER JOIN RCRA_FA_MECHANISM_DETAIL WH ON WH.FA_MECHANISM_ID = ETL.WH_FA_MECHANISM_ID
    AND WH.MECHANISM_DETAIL_SEQ_NUM = NODE.MECHANISM_DETAIL_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_VIOL_ENFRC for NODE_FLOW_RCRA.RCRA_CME_VIOL_ENFRC
/

create view ETL_CME_VIOL_ENFRC_VW as
(
SELECT WH.CME_VIOL_ENFRC_ID WH_CME_VIOL_ENFRC_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_VIOL_ENFRC_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."VIOL_SEQ_NUM",
       NODE."AGN_WHICH_DTRM_VIOL",
       NODE."RTN_COMPL_SCHD_DATE"
FROM NODE_RCRA_CME_VIOL_ENFRC NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_VIOL_ENFRC WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.VIOL_SEQ_NUM = NODE.VIOL_SEQ_NUM
    AND WH.AGN_WHICH_DTRM_VIOL = NODE.AGN_WHICH_DTRM_VIOL
    )
/

create synonym NODE_RCRA_CME_SUPP_ENVR_PRJT for NODE_FLOW_RCRA.RCRA_CME_SUPP_ENVR_PRJT
/

create view ETL_CME_SUPP_ENVR_PRJT_VW as
(
SELECT WH.CME_SUPP_ENVR_PRJT_ID WH_CME_SUPP_ENVR_PRJT_ID,
       ETL.WH_CME_ENFR_ACT_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_SUPP_ENVR_PRJT_ID",
       NODE."CME_ENFRC_ACT_ID",
       NODE."TRANS_CODE",
       NODE."SEP_SEQ_NUM",
       NODE."SEP_EXPND_AMOUNT",
       NODE."SEP_SCHD_COMP_DATE",
       NODE."SEP_ACTL_DATE",
       NODE."SEP_DFLT_DATE",
       NODE."SEP_CODE_OWNER",
       NODE."SEP_DESC_TXT",
       NODE."NOTES"
FROM NODE_RCRA_CME_SUPP_ENVR_PRJT NODE
         INNER JOIN ETL_CME_ENFRC_ACT_VW ETL ON ETL.CME_ENFRC_ACT_ID = NODE.CME_ENFRC_ACT_ID
         LEFT OUTER JOIN RCRA_CME_SUPP_ENVR_PRJT WH ON WH.CME_ENFRC_ACT_ID = ETL.WH_CME_ENFR_ACT_ID
    AND WH.SEP_SEQ_NUM = NODE.SEP_SEQ_NUM
    )
/

create synonym NODE_RCRA_HD_ENV_PERMIT for NODE_FLOW_RCRA.RCRA_HD_ENV_PERMIT
/

create view ETL_HD_ENV_PERMIT_VW as
(
SELECT WH.HD_ENV_PERMIT_ID WH_HD_ENV_PERMIT_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_ENV_PERMIT_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."ENV_PERMIT_NUMBER",
       NODE."ENV_PERMIT_OWNER",
       NODE."ENV_PERMIT_TYPE",
       NODE."ENV_PERMIT_DESC"
FROM NODE_RCRA_HD_ENV_PERMIT NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_ENV_PERMIT WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.ENV_PERMIT_NUMBER = NODE.ENV_PERMIT_NUMBER
    )
/

create synonym NODE_RCRA_HD_CERTIFICATION for NODE_FLOW_RCRA.RCRA_HD_CERTIFICATION
/

create view ETL_HD_CERT_VW as
(
SELECT WH.HD_CERTIFICATION_ID WH_HD_CERTIFICATION_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_CERTIFICATION_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."CERT_SEQ",
       NODE."CERT_SIGNED_DATE",
       NODE."CERT_TITLE",
       NODE."CERT_FIRST_NAME",
       NODE."CERT_MIDDLE_INITIAL",
       NODE."CERT_LAST_NAME",
       NODE."CERT_EMAIL_TEXT"
FROM NODE_RCRA_HD_CERTIFICATION NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_CERTIFICATION WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.CERT_SEQ = NODE.CERT_SEQ
    )
/

create synonym NODE_RCRA_HD_NAICS for NODE_FLOW_RCRA.RCRA_HD_NAICS
/

create view ETL_HD_NAICS_VW as
(
SELECT WH.HD_NAICS_ID WH_HD_NAICS_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_NAICS_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."NAICS_SEQ",
       NODE."NAICS_OWNER",
       NODE."NAICS_CODE"
FROM NODE_RCRA_HD_NAICS NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_NAICS WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.NAICS_SEQ = NODE.NAICS_SEQ
    )
/

create synonym NODE_RCRA_HD_STATE_ACTIVITY for NODE_FLOW_RCRA.RCRA_HD_STATE_ACTIVITY
/

create view ETL_HD_STATE_ACT_VW as
(
SELECT WH.HD_STATE_ACTIVITY_ID WH_HD_STATE_ACTIVITY_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_STATE_ACTIVITY_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."STATE_ACTIVITY_OWNER",
       NODE."STATE_ACTIVITY_TYPE"
FROM NODE_RCRA_HD_STATE_ACTIVITY NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_STATE_ACTIVITY WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.STATE_ACTIVITY_OWNER = NODE.STATE_ACTIVITY_OWNER
    AND WH.STATE_ACTIVITY_TYPE = NODE.STATE_ACTIVITY_TYPE
    )
/

create synonym NODE_RCRA_PRM_EVENT for NODE_FLOW_RCRA.RCRA_PRM_EVENT
/

create view ETL_PRM_EVENT_VW as
(
SELECT WH.PRM_EVENT_ID WH_PRM_EVENT_ID,
       ETL.WH_PRM_SERIES_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_EVENT_ID",
       NODE."PRM_SERIES_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."PERMIT_EVENT_DATA_OWNER_CODE",
       NODE."PERMIT_EVENT_CODE",
       NODE."EVENT_AGN_CODE",
       NODE."EVENT_SEQ_NUM",
       NODE."ACTL_DATE",
       NODE."ORIGINAL_SCHEDULE_DATE",
       NODE."NEW_SCHEDULE_DATE",
       NODE."RESP_PERSON_DATA_OWNER_CODE",
       NODE."RESP_PERSON_ID",
       NODE."EVENT_SUBORG_DATA_OWNER_CODE",
       NODE."EVENT_SUBORG_CODE",
       NODE."SUPP_INFO_TXT",
       NODE."CREATED_BY_USERID",
       NODE."P_CREATED_DATE",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_PRM_EVENT NODE
         INNER JOIN ETL_PRM_SERIES_VW ETL ON ETL.PRM_SERIES_ID = NODE.PRM_SERIES_ID
         LEFT OUTER JOIN RCRA_PRM_EVENT WH ON WH.PRM_SERIES_ID = ETL.WH_PRM_SERIES_ID
    AND WH.EVENT_SEQ_NUM = NODE.EVENT_SEQ_NUM
    AND WH.PERMIT_EVENT_CODE = NODE.PERMIT_EVENT_CODE
    )
/

create synonym NODE_RCRA_HD_WASTE_CODE for NODE_FLOW_RCRA.RCRA_HD_WASTE_CODE
/

create view ETL_HD_WASTE_CODE_VW as
(
SELECT WH.HD_WASTE_CODE_ID WH_HD_WASTE_CODE_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_WASTE_CODE_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."WASTE_CODE_OWNER",
       NODE."WASTE_CODE_TYPE"
FROM NODE_RCRA_HD_WASTE_CODE NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_WASTE_CODE WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.WASTE_CODE_OWNER = NODE.WASTE_CODE_OWNER
    AND WH.WASTE_CODE_TYPE = NODE.WASTE_CODE_TYPE
    )
/

create synonym NODE_RCRA_HD_UNIVERSAL_WASTE for NODE_FLOW_RCRA.RCRA_HD_UNIVERSAL_WASTE
/

create view ETL_HD_UNIV_WASTE_VW as
(
SELECT WH.HD_UNIVERSAL_WASTE_ID WH_HD_UNIVERSAL_WASTE_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_UNIVERSAL_WASTE_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."UNIVERSAL_WASTE_OWNER",
       NODE."UNIVERSAL_WASTE_TYPE",
       NODE."ACCUMULATED",
       NODE."GENERATED"
FROM NODE_RCRA_HD_UNIVERSAL_WASTE NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_UNIVERSAL_WASTE WH
                         ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
                             AND WH.UNIVERSAL_WASTE_OWNER = NODE.UNIVERSAL_WASTE_OWNER
                             AND WH.UNIVERSAL_WASTE_TYPE = NODE.UNIVERSAL_WASTE_TYPE
    )
/

create synonym NODE_RCRA_HD_OWNEROP for NODE_FLOW_RCRA.RCRA_HD_OWNEROP
/

create view ETL_HD_OWNEROP_VW as
(
SELECT WH.HD_OWNEROP_ID WH_HD_OWNEROP_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_OWNEROP_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."OWNER_OP_SEQ",
       NODE."OWNER_OP_IND",
       NODE."OWNER_OP_TYPE",
       NODE."DATE_BECAME_CURRENT",
       NODE."DATE_ENDED_CURRENT",
       NODE."NOTES",
       NODE."FIRST_NAME",
       NODE."MIDDLE_INITIAL",
       NODE."LAST_NAME",
       NODE."ORG_NAME",
       NODE."TITLE",
       NODE."EMAIL_ADDRESS",
       NODE."PHONE",
       NODE."PHONE_EXT",
       NODE."FAX",
       NODE."MAIL_ADDR_NUM_TXT",
       NODE."STREET1",
       NODE."STREET2",
       NODE."CITY",
       NODE."STATE",
       NODE."COUNTRY",
       NODE."ZIP"
FROM NODE_RCRA_HD_OWNEROP NODE
         INNER JOIN ETL_HD_HANDLER_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_OWNEROP WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.OWNER_OP_SEQ = NODE.OWNER_OP_SEQ
    )
/

create synonym NODE_RCRA_PRM_UNIT_DETAIL for NODE_FLOW_RCRA.RCRA_PRM_UNIT_DETAIL
/

create view ETL_PRM_UNIT_DETAIL_VW as
(
SELECT WH.PRM_UNIT_DETAIL_ID WH_PRM_UNIT_DETAIL_ID,
       ETL.WH_PRM_UNIT_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_UNIT_DETAIL_ID",
       NODE."PRM_UNIT_ID",
       NODE."TRANS_CODE",
       NODE."PERMIT_UNIT_DETAIL_SEQ_NUM",
       NODE."PROC_UNIT_DATA_OWNER_CODE",
       NODE."PROC_UNIT_CODE",
       NODE."PERMIT_STAT_EFFC_DATE",
       NODE."PERMIT_UNIT_CAP_QNTY",
       NODE."CAP_TYPE_CODE",
       NODE."COMMER_STAT_CODE",
       NODE."LEGAL_OPER_STAT_DATA_OWNER_CDE",
       NODE."LEGAL_OPER_STAT_CODE",
       NODE."MEASUREMENT_UNIT_DATA_OWNR_CDE",
       NODE."MEASUREMENT_UNIT_CODE",
       NODE."NUM_OF_UNITS_COUNT",
       NODE."STANDARD_PERMIT_IND",
       NODE."SUPP_INFO_TXT",
       NODE."CURRENT_UNIT_DETAIL_IND",
       NODE."CREATED_BY_USERID",
       NODE."P_CREATED_DATE",
       NODE."LAST_UPDT_BY",
       NODE."LAST_UPDT_DATE"
FROM NODE_RCRA_PRM_UNIT_DETAIL NODE
         INNER JOIN ETL_PRM_UNIT_VW ETL ON ETL.PRM_UNIT_ID = NODE.PRM_UNIT_ID
         LEFT OUTER JOIN RCRA_PRM_UNIT_DETAIL WH ON WH.PRM_UNIT_ID = ETL.WH_PRM_UNIT_ID
    AND WH.PERMIT_UNIT_DETAIL_SEQ_NUM = NODE.PERMIT_UNIT_DETAIL_SEQ_NUM
    )
/

create synonym NODE_RCRA_PRM_WASTE_CODE for NODE_FLOW_RCRA.RCRA_PRM_WASTE_CODE
/

create view ETL_PRM_WASTE_CODE_VW as
(
SELECT WH.PRM_WASTE_CODE_ID WH_PRM_WASTE_CODE_ID,
       ETL.WH_PRM_UNIT_DETAIL_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_WASTE_CODE_ID",
       NODE."PRM_UNIT_DETAIL_ID",
       NODE."TRANSACTION_CODE",
       NODE."WASTE_CODE_OWNER",
       NODE."WASTE_CODE_TYPE"
FROM NODE_RCRA_PRM_WASTE_CODE NODE
         INNER JOIN ETL_PRM_UNIT_DETAIL_VW ETL ON ETL.PRM_UNIT_DETAIL_ID = NODE.PRM_UNIT_DETAIL_ID
         LEFT OUTER JOIN RCRA_PRM_WASTE_CODE WH ON WH.PRM_UNIT_DETAIL_ID = ETL.WH_PRM_UNIT_DETAIL_ID
    AND WH.WASTE_CODE_OWNER = NODE.WASTE_CODE_OWNER
    AND WH.WASTE_CODE_TYPE = NODE.WASTE_CODE_TYPE
    )
/

create synonym NODE_RCRA_PRM_RELATED_EVENT for NODE_FLOW_RCRA.RCRA_PRM_RELATED_EVENT
/

create view ETL_PRM_REL_EVENT_VW as
(
SELECT WH.PRM_RELATED_EVENT_ID WH_PRM_RELATED_EVENT_ID,
       ETL.WH_PRM_UNIT_DETAIL_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_RELATED_EVENT_ID",
       NODE."PRM_UNIT_DETAIL_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."PERMIT_SERIES_SEQ_NUM",
       NODE."PERMIT_EVENT_DATA_OWNER_CODE",
       NODE."PERMIT_EVENT_CODE",
       NODE."EVENT_AGN_CODE",
       NODE."EVENT_SEQ_NUM"
FROM NODE_RCRA_PRM_RELATED_EVENT NODE
         INNER JOIN ETL_PRM_UNIT_DETAIL_VW ETL ON ETL.PRM_UNIT_DETAIL_ID = NODE.PRM_UNIT_DETAIL_ID
         LEFT OUTER JOIN RCRA_PRM_RELATED_EVENT WH ON WH.PRM_UNIT_DETAIL_ID = ETL.WH_PRM_UNIT_DETAIL_ID
    AND WH.EVENT_SEQ_NUM = NODE.EVENT_SEQ_NUM
    AND WH.PERMIT_EVENT_CODE = NODE.PERMIT_EVENT_CODE
    AND WH.PERMIT_SERIES_SEQ_NUM = NODE.PERMIT_SERIES_SEQ_NUM
    AND WH.EVENT_AGN_CODE = NODE.EVENT_AGN_CODE
    )
/

create synonym NODE_RCRA_PRM_EVENT_COMMITMENT for NODE_FLOW_RCRA.RCRA_PRM_EVENT_COMMITMENT
/

create view ETL_PRM_EVENT_COMM_VW as
(
SELECT WH.PRM_EVENT_COMMITMENT_ID WH_PRM_EVENT_COMMITMENT_ID,
       ETL.WH_PRM_EVENT_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_EVENT_COMMITMENT_ID",
       NODE."PRM_EVENT_ID",
       NODE."TRANS_CODE",
       NODE."COMMIT_LEAD",
       NODE."COMMIT_SEQ_NUM"
FROM NODE_RCRA_PRM_EVENT_COMMITMENT NODE
         INNER JOIN ETL_PRM_EVENT_VW ETL ON ETL.PRM_EVENT_ID = NODE.PRM_EVENT_ID
         LEFT OUTER JOIN RCRA_PRM_EVENT_COMMITMENT WH ON WH.PRM_EVENT_ID = ETL.WH_PRM_EVENT_ID
    AND WH.COMMIT_SEQ_NUM = NODE.COMMIT_SEQ_NUM
    )
/

create synonym NODE_RCRA_HD_SEC_WASTE_CODE for NODE_FLOW_RCRA.RCRA_HD_SEC_WASTE_CODE
/

create synonym NODE_RCRA_CME_PYMT for NODE_FLOW_RCRA.RCRA_CME_PYMT
/

create view ETL_CME_PYMT_VW as
(
SELECT WH.CME_PYMT_ID WH_CME_PYMT_ID,
       ETL.WH_CME_PNLTY_ID,
       ETL.CME_SUBM_ID,
       NODE."CME_PYMT_ID",
       NODE."CME_PNLTY_ID",
       NODE."TRANS_CODE",
       NODE."PYMT_SEQ_NUM",
       NODE."PYMT_DFLT_DATE",
       NODE."SCHD_PYMT_DATE",
       NODE."SCHD_PYMT_AMOUNT",
       NODE."ACTL_PYMT_DATE",
       NODE."ACTL_PAID_AMOUNT",
       NODE."NOTES"
FROM NODE_RCRA_CME_PYMT NODE
         INNER JOIN ETL_CME_PNLTY_VW ETL ON ETL.CME_PNLTY_ID = NODE.CME_PNLTY_ID
         LEFT OUTER JOIN RCRA_CME_PYMT WH ON WH.CME_PNLTY_ID = ETL.WH_CME_PNLTY_ID
    AND WH.PYMT_SEQ_NUM = NODE.PYMT_SEQ_NUM
    )
/

create synonym NODE_RCRA_HD_LQG_CLOSURE for NODE_FLOW_RCRA.RCRA_HD_LQG_CLOSURE
/

create view ETL_HD_LQG_CLOSURE as
(
SELECT WH.HD_LQG_CLOSURE_ID WH_HD_LQG_CLOSURE_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_LQG_CLOSURE_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."CLOSURE_TYPE",
       NODE."EXPECTED_CLOSURE_DATE",
       NODE."NEW_CLOSURE_DATE",
       NODE."DATE_CLOSED",
       NODE."IN_COMPLIANCE_IND"
FROM NODE_RCRA_HD_LQG_CLOSURE NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_LQG_CLOSURE WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    )
/

create synonym NODE_RCRA_HD_LQG_CONSOLIDATION for NODE_FLOW_RCRA.RCRA_HD_LQG_CONSOLIDATION
/

create view ETL_HD_LQG_CONSOLIDATION_VW as
(
SELECT WH.HD_LQG_CONSOLIDATION_ID WH_HD_LQG_CONSOLIDATION_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_LQG_CONSOLIDATION_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."SEQ_NUMBER",
       NODE."HANDLER_ID",
       NODE."HANDLER_NAME",
       NODE."MAIL_STREET_NUMBER",
       NODE."MAIL_STREET1",
       NODE."MAIL_STREET2",
       NODE."MAIL_CITY",
       NODE."MAIL_STATE",
       NODE."MAIL_COUNTRY",
       NODE."MAIL_ZIP",
       NODE."CONTACT_FIRST_NAME",
       NODE."CONTACT_MIDDLE_INITIAL",
       NODE."CONTACT_LAST_NAME",
       NODE."CONTACT_ORG_NAME",
       NODE."CONTACT_TITLE",
       NODE."CONTACT_EMAIL_ADDRESS",
       NODE."CONTACT_PHONE",
       NODE."CONTACT_PHONE_EXT",
       NODE."CONTACT_FAX"
FROM NODE_RCRA_HD_LQG_CONSOLIDATION NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_LQG_CONSOLIDATION WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.SEQ_NUMBER = NODE.SEQ_NUMBER
    )
/

create synonym NODE_RCRA_HD_EPISODIC_EVENT for NODE_FLOW_RCRA.RCRA_HD_EPISODIC_EVENT
/

create view ETL_HD_EPISODIC_EVENT as
(
SELECT WH.HD_EPISODIC_EVENT_ID WH_HD_EPISODIC_EVENT_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_EPISODIC_EVENT_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANSACTION_CODE",
       NODE."EVENT_OWNER",
       NODE."EVENT_TYPE",
       NODE."CONTACT_FIRST_NAME",
       NODE."CONTACT_MIDDLE_INITIAL",
       NODE."CONTACT_LAST_NAME",
       NODE."CONTACT_ORG_NAME",
       NODE."CONTACT_TITLE",
       NODE."CONTACT_EMAIL_ADDRESS",
       NODE."CONTACT_PHONE",
       NODE."CONTACT_PHONE_EXT",
       NODE."CONTACT_FAX",
       NODE."START_DATE",
       NODE."END_DATE"
FROM NODE_RCRA_HD_EPISODIC_EVENT NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_EPISODIC_EVENT WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    )
/

create synonym NODE_RCRA_HD_EPISODIC_WASTE for NODE_FLOW_RCRA.RCRA_HD_EPISODIC_WASTE
/

create view ETL_HD_EPISODIC_WASTE as
(
SELECT WH.HD_EPISODIC_WASTE_ID WH_HD_EPISODIC_WASTE_ID,
       ETL.WH_HD_EPISODIC_EVENT_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_EPISODIC_WASTE_ID",
       NODE."HD_EPISODIC_EVENT_ID",
       NODE."TRANSACTION_CODE",
       NODE."SEQ_NUMBER",
       NODE."WASTE_DESC",
       NODE."EST_QNTY"
FROM NODE_RCRA_HD_EPISODIC_WASTE NODE
         INNER JOIN ETL_HD_EPISODIC_EVENT ETL ON ETL.HD_EPISODIC_EVENT_ID = NODE.HD_EPISODIC_EVENT_ID
         LEFT OUTER JOIN RCRA_HD_EPISODIC_WASTE WH ON WH.HD_EPISODIC_EVENT_ID = ETL.WH_HD_EPISODIC_EVENT_ID
    AND WH.SEQ_NUMBER = NODE.SEQ_NUMBER
    )
/

create synonym NODE_RCRA_RU_SUBM for NODE_FLOW_RCRA.RCRA_RU_SUBM
/

create synonym NODE_RCRA_RU_REPORT_UNIV_SUBM for NODE_FLOW_RCRA.RCRA_RU_REPORT_UNIV_SUBM
/

create synonym NODE_RCRA_RU_REPORT_UNIV for NODE_FLOW_RCRA.RCRA_RU_REPORT_UNIV
/

create view ETL_RU_REPORT_UNIV_VW as
(
SELECT SUBM.RU_SUBM_ID      WH_RU_SUBM_ID,
       WH.RU_REPORT_UNIV_ID WH_RU_REPORT_UNIV_ID,
       NODE."RU_REPORT_UNIV_ID",
       NODE."RU_REPORT_UNIV_SUBM_ID",
       NODE."HANDLER_ID",
       NODE."ACTIVITY_LOCATION",
       NODE."SOURCE_TYPE",
       NODE."SEQ_NUMBER",
       NODE."RECEIVE_DATE",
       NODE."HANDLER_NAME",
       NODE."NON_NOTIFIER_IND",
       NODE."ACCESSIBILITY",
       NODE."REPORT_CYCLE",
       NODE."REGION",
       NODE."STATE",
       NODE."EXTRACT_FLAG",
       NODE."ACTIVE_SITE",
       NODE."COUNTY_CODE",
       NODE."COUNTY_NAME",
       NODE."LOCATION_STREET_NUMBER",
       NODE."LOCATION_STREET1",
       NODE."LOCATION_STREET2",
       NODE."LOCATION_CITY",
       NODE."LOCATION_STATE",
       NODE."LOCATION_COUNTRY",
       NODE."LOCATION_ZIP",
       NODE."MAIL_STREET_NUMBER",
       NODE."MAIL_STREET1",
       NODE."MAIL_STREET2",
       NODE."MAIL_CITY",
       NODE."MAIL_STATE",
       NODE."MAIL_COUNTRY",
       NODE."MAIL_ZIP",
       NODE."CONTACT_STREET_NUMBER",
       NODE."CONTACT_STREET1",
       NODE."CONTACT_STREET2",
       NODE."CONTACT_CITY",
       NODE."CONTACT_STATE",
       NODE."CONTACT_COUNTRY",
       NODE."CONTACT_ZIP",
       NODE."CONTACT_NAME",
       NODE."CONTACT_PHONE",
       NODE."CONTACT_FAX",
       NODE."CONTACT_EMAIL",
       NODE."CONTACT_TITLE",
       NODE."OWNER_NAME",
       NODE."OWNER_TYPE",
       NODE."OWNER_SEQ_NUM",
       NODE."OPER_NAME",
       NODE."OPER_TYPE",
       NODE."OPER_SEQ_NUM",
       NODE."NAIC1_CODE",
       NODE."NAIC2_CODE",
       NODE."NAIC3_CODE",
       NODE."NAIC4_CODE",
       NODE."IN_HANDLER_UNIVERSE",
       NODE."IN_A_UNIVERSE",
       NODE."FED_WASTE_GENERATOR_OWNER",
       NODE."FED_WASTE_GENERATOR",
       NODE."STATE_WASTE_GENERATOR_OWNER",
       NODE."STATE_WASTE_GENERATOR",
       NODE."GEN_STATUS",
       NODE."UNIV_WASTE",
       NODE."LAND_TYPE",
       NODE."STATE_DISTRICT_OWNER",
       NODE."STATE_DISTRICT",
       NODE."SHORT_TERM_GEN_IND",
       NODE."IMPORTER_ACTIVITY",
       NODE."MIXED_WASTE_GENERATOR",
       NODE."TRANSPORTER_ACTIVITY",
       NODE."TRANSFER_FACILITY_IND",
       NODE."RECYCLER_ACTIVITY",
       NODE."ONSITE_BURNER_EXEMPTION",
       NODE."FURNACE_EXEMPTION",
       NODE."UNDERGROUND_INJECTION_ACTIVITY",
       NODE."UNIVERSAL_WASTE_DEST_FACILITY",
       NODE."OFFSITE_WASTE_RECEIPT",
       NODE."USED_OIL",
       NODE."FEDERAL_UNIVERSAL_WASTE",
       NODE."AS_FEDERAL_REGULATED_TSDF",
       NODE."AS_CONVERTED_TSDF",
       NODE."AS_STATE_REGULATED_TSDF",
       NODE."FEDERAL_IND",
       NODE."HSM",
       NODE."SUBPART_K",
       NODE."COMMERCIAL_TSD",
       NODE."TSD",
       NODE."GPRA_PERMIT",
       NODE."GPRA_RENEWAL",
       NODE."PERMIT_RENEWAL_WRKLD",
       NODE."PERM_WRKLD",
       NODE."PERM_PROG",
       NODE."PC_WRKLD",
       NODE."CLOS_WRKLD",
       NODE."GPRACA",
       NODE."CA_WRKLD",
       NODE."SUBJ_CA",
       NODE."SUBJ_CA_NON_TSD",
       NODE."SUBJ_CA_TSD_3004",
       NODE."SUBJ_CA_DISCRETION",
       NODE."NCAPS",
       NODE."EC_IND",
       NODE."IC_IND",
       NODE."CA_725_IND",
       NODE."CA_750_IND",
       NODE."OPERATING_TSDF",
       NODE."FULL_ENFORCEMENT",
       NODE."SNC",
       NODE."BOY_SNC",
       NODE."BOY_STATE_UNADDRESSED_SNC",
       NODE."STATE_UNADDRESSED",
       NODE."STATE_ADDRESSED",
       NODE."BOY_STATE_ADDRESSED",
       NODE."STATE_SNC_WITH_COMP_SCHED",
       NODE."BOY_STATE_SNC_WITH_COMP_SCHED",
       NODE."EPA_UNADDRESSED",
       NODE."BOY_EPA_UNADDRESSED",
       NODE."EPA_ADDRESSED",
       NODE."BOY_EPA_ADDRESSED",
       NODE."EPA_SNC_WITH_COMP_SCHED",
       NODE."BOY_EPA_SNC_WITH_COMP_SCHED",
       NODE."FA_REQUIRED",
       NODE."HHANDLER_LAST_CHANGE_DATE",
       NODE."PUBLIC_NOTES",
       NODE."NOTES",
       NODE."RECOGNIZED_TRADER_IMPORTER_IND",
       NODE."RECOGNIZED_TRADER_EXPORTER_IND",
       NODE."SLAB_IMPORTER_IND",
       NODE."SLAB_EXPORTER_IND",
       NODE."RECYCLER_NON_STORAGE_IND",
       NODE."MANIFEST_BROKER_IND",
       NODE."SUBPART_P_IND",
       NODE."LOCATION_LATITUDE",
       NODE."LOCATION_LONGITUDE",
       NODE."LOCATION_GIS_PRIM",
       NODE."LOCATION_GIS_ORIG"
FROM NODE_RCRA_RU_REPORT_UNIV NODE
         JOIN NODE_RCRA_RU_REPORT_UNIV_SUBM SUBM ON SUBM.RU_REPORT_UNIV_SUBM_ID = NODE.RU_REPORT_UNIV_SUBM_ID
         LEFT OUTER JOIN RCRA_RU_REPORT_UNIV WH ON WH.HANDLER_ID = NODE.HANDLER_ID
    )
/

create synonym NODE_RCRA_EM_EMANIFEST for NODE_FLOW_RCRA.RCRA_EM_EMANIFEST
/

create view ETL_EM_EMANIFEST_VW as
select WH.EM_EMANIFEST_ID WH_EM_EMANIFEST_ID,
       NODE."EM_EMANIFEST_ID",NODE."EM_SUBM_ID",NODE."CREATED_DATE",NODE."UPDATED_DATE",NODE."MAN_TRACKING_NUM",NODE."STATUS",NODE."DES_FAC_MODIFIED",NODE."SUBM_TYPE",NODE."GENERATOR_MODIFIED",NODE."ORIGIN_TYPE",NODE."SHIPPED_DATE",NODE."RECEIVED_DATE",NODE."CERT_DATE",NODE."REJ_IND",NODE."DES_FAC_REGISTERED",NODE."IMPORT",NODE."GENERATOR_CONTACT_FIRST_NAME",NODE."GENERATOR_CONTACT_LAST_NAME",NODE."GENERATOR_REGISTERED",NODE."REJECTION_TYPE",NODE."ALTERNATE_DESIGNATED_FAC_TYPE",NODE."GENERATOR_NAME",NODE."DES_FAC_SIGNATURE_DATE",NODE."GENERATOR_ESIG_SIGNATURE_DATE",NODE."DES_FAC_LOC_STREET_1",NODE."ALT_FAC_MAIL_STREET_2",NODE."DES_FAC_CONTACT_FIRST_NAME",NODE."DES_FAC_CONTACT_LAST_NAME",NODE."GENERATOR_LOC_STREET_2",NODE."GENERATOR_CONTACT_EMAIL",NODE."DES_FAC_MAIL_STREET_1",NODE."PORT_OF_ENTRY_CITY",NODE."GENERATOR_MAIL_ZIP",NODE."DES_FAC_MAIL_STREET_2",NODE."GENERATOR_MAIL_STA",NODE."FOREIGN_GENERATOR_CTRY_NAME",NODE."GENERATOR_MAIL_CTRY",NODE."GENERATOR_MAIL_STREET_1",NODE."GENERATOR_MAIL_STREET_2",NODE."MANIFEST_HANDLING_INSTR",NODE."RESIDUE",NODE."GENERATOR_ID",NODE."GENERATOR_SIGNATURE_DATE",NODE."DES_FAC_LOC_STREET_2",NODE."ALT_FAC_MAIL_STREET_1",NODE."GENERATOR_ESIG_FIRST_NAME",NODE."GENERATOR_ESIG_LAST_NAME",NODE."GENERATOR_LOC_STREET_1",NODE."GENERATOR_MAIL_STREET_NUM",NODE."GENERATOR_MAIL_CITY",NODE."GENERATOR_LOC_STREET_NUM",NODE."GENERATOR_LOC_CITY",NODE."GENERATOR_LOC_STA",NODE."GENERATOR_LOC_ZIP",NODE."GENERATOR_CONTACT_PHONE_NUM",NODE."GENERATOR_CONTACT_PHONE_EXT",NODE."GENERATOR_CONTACT_COMPANY_NAME",NODE."EMERGENCY_PHONE_NUM",NODE."EMERGENCY_PHONE_EXT",NODE."GENERATOR_PRINTED_NAME",NODE."DES_FAC_ID",NODE."DES_FAC_NAME",NODE."DES_FAC_MAIL_STREET_NUM",NODE."DES_FAC_MAIL_CITY",NODE."DES_FAC_MAIL_CTRY",NODE."DES_FAC_MAIL_STA",NODE."DES_FAC_MAIL_ZIP",NODE."DES_FAC_LOC_STREET_NUM",NODE."DES_FAC_LOC_CITY",NODE."DES_FAC_LOC_STA",NODE."DES_FAC_LOC_ZIP",NODE."DES_FAC_CONTACT_PHONE_NUM",NODE."DES_FAC_CONTACT_PHONE_EXT",NODE."DES_FAC_CONTACT_EMAIL",NODE."DES_FAC_CONTACT_COMPANY_NAME",NODE."DES_FAC_PRINTED_NAME",NODE."DES_FAC_ESIG_FIRST_NAME",NODE."DES_FAC_ESIG_LAST_NAME",NODE."DES_FAC_ESIG_SIGNATURE_DATE",NODE."ORIG_SUBM_TYPE",NODE."COI_ONLY",NODE."BROKER_ID",NODE."LAST_EM_UPDT_DATE",NODE."TRANSPORTER_ON_SITE",NODE."ALT_FAC_PRINTED_NAME",NODE."ALT_FAC_SIGNATURE_DATE",NODE."ALT_FAC_ESIG_FIRST_NAME",NODE."ALT_FAC_ESIG_LAST_NAME",NODE."ALT_FAC_ESIG_SIGNATURE_DATE",NODE."ALT_FAC_ID",NODE."ALT_FAC_NAME",NODE."ALT_FAC_MAIL_STREET_NUM",NODE."ALT_FAC_MAIL_CITY",NODE."ALT_FAC_MAIL_STA",NODE."ALT_FAC_MAIL_ZIP",NODE."ALT_FAC_LOC_STREET_NUM",NODE."ALT_FAC_LOC_STREET_1",NODE."ALT_FAC_LOC_STREET_2",NODE."ALT_FAC_LOC_CITY",NODE."ALT_FAC_LOC_STA",NODE."ALT_FAC_LOC_ZIP",NODE."ALT_FAC_CONTACT_FIRST_NAME",NODE."ALT_FAC_CONTACT_LAST_NAME",NODE."ALT_FAC_CONTACT_PHONE_NO",NODE."ALT_FAC_CONTACT_PHONE_EXT",NODE."ALT_FAC_CONTACT_EMAIL",NODE."ALT_FAC_CONTACT_COMPANY_NAME",NODE."ALT_FAC_REGISTERED",NODE."ALT_FAC_MODIFIED",NODE."FOREIGN_GENERATOR_NAME",NODE."FOREIGN_GENERATOR_STREET",NODE."FOREIGN_GENERATOR_CITY",NODE."FOREIGN_GENERATOR_CTRY_CODE",NODE."FOREIGN_GENERATOR_POST_CODE",NODE."FOREIGN_GENERATOR_PROVINCE",NODE."PORT_OF_ENTRY_STA"
from NODE_RCRA_EM_EMANIFEST NODE
         left join RCRA_EM_EMANIFEST WH on WH.MAN_TRACKING_NUM = NODE.MAN_TRACKING_NUM
/

create synonym NODE_RCRA_EM_EMANIFEST_COMMENT for NODE_FLOW_RCRA.RCRA_EM_EMANIFEST_COMMENT
/

create view ETL_EM_EMANIFEST_COMMENT_VW as
select ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_EMANIFEST_COMMENT_ID",NODE."EM_EMANIFEST_ID",NODE."CMNT_LABEL",NODE."CMNT_DESC"
from NODE_RCRA_EM_EMANIFEST_COMMENT NODE
         join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID
/

create synonym NODE_RCRA_EM_SUBM for NODE_FLOW_RCRA.RCRA_EM_SUBM
/

create synonym NODE_RCRA_EM_WASTE for NODE_FLOW_RCRA.RCRA_EM_WASTE
/

create view ETL_EM_WASTE_VW as
select WH.EM_WASTE_ID WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_WASTE_ID",NODE."EM_EMANIFEST_ID",NODE."NON_HAZ_WASTE_DESC",NODE."DOT_HAZRD",NODE."LINE_NUM",NODE."BR_MIXED_RADIOACTIVE_WASTE",NODE."DOT_PRINTED_INFO",NODE."CONTAINER_NUM",NODE."QNTY_VAL",NODE."QTY_UNIT_OF_MEAS_CODE",NODE."QTY_UNIT_OF_MEAS_DESC",NODE."BR_DENSITY",NODE."BR_DENSITY_UOM_CODE",NODE."BR_DENSITY_UOM_DESC",NODE."BR_FORM_CODE",NODE."BR_FORM_CODE_DESC",NODE."BR_SRC_CODE",NODE."BR_SRC_CODE_DESC",NODE."BR_WASTE_MIN_CODE",NODE."BR_WASTE_MIN_DESC",NODE."QNTY_DISCREPANCY",NODE."WASTE_TYPE_DISCREPANCY",NODE."WASTE_RESIDUE_COMM",NODE."PCB",NODE."MANAGEMENT_METH_CODE",NODE."MANAGEMENT_METH_DESC",NODE."HANDLING_INSTRUCTIONS",NODE."DOT_ID_NUM_DESC",NODE."CONTAINER_TYPE_CODE",NODE."CONTAINER_TYPE_DESC",NODE."DISCREPANCY_COMM",NODE."WASTE_RESIDUE",NODE."CNST_NUM",NODE."EPA_WASTE",NODE."COI_ONLY",NODE."QNTY_ACUTE_KG",NODE."QNTY_ACUTE_TONS",NODE."QNTY_KG",NODE."QNTY_NON_ACUTE_KG",NODE."QNTY_NON_ACUTE_TONS",NODE."QNTY_TONS"
from NODE_RCRA_EM_WASTE NODE
         join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID
         left join RCRA_EM_WASTE WH
                   on WH.EM_EMANIFEST_ID = ETL.WH_EM_EMANIFEST_ID
                       and WH.LINE_NUM = NODE.LINE_NUM
/

create synonym NODE_RCRA_EM_WASTE_CD_TRANS for NODE_FLOW_RCRA.RCRA_EM_WASTE_CD_TRANS
/

create view ETL_EM_WASTE_CD_TRANS_VW as
select ETL.WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_WASTE_CD_TRANS_ID",NODE."EM_WASTE_ID",NODE."WASTE_CODE"
from NODE_RCRA_EM_WASTE_CD_TRANS NODE
         join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID
/

create synonym NODE_RCRA_EM_WASTE_COMMENT for NODE_FLOW_RCRA.RCRA_EM_WASTE_COMMENT
/

create view ETL_EM_WASTE_COMMENT_VW as
select ETL.WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_WASTE_COMMENT_ID",NODE."EM_WASTE_ID",NODE."CMNT_LABEL",NODE."CMNT_DESC"
from NODE_RCRA_EM_WASTE_COMMENT NODE
         join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID
/

create synonym NODE_RCRA_EM_WASTE_PCB for NODE_FLOW_RCRA.RCRA_EM_WASTE_PCB
/

create view ETL_EM_WASTE_PCB_VW as
select ETL.WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_WASTE_PCB_ID",NODE."EM_WASTE_ID",NODE."PCB_LOAD_TYPE_CODE",NODE."PCB_ARTICLE_CONT_ID",NODE."PCB_REMOVAL_DATE",NODE."PCB_WEIGHT",NODE."PCB_WASTE_TYPE",NODE."PCB_BULK_IDENTITY",NODE."LOAD_TYPE_DESC"
from NODE_RCRA_EM_WASTE_PCB NODE
         join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID
/

create synonym NODE_RCRA_CA_STATUTORY_CITAT for NODE_FLOW_RCRA.RCRA_CA_STATUTORY_CITATION
/

create view ETL_CA_STATUTORY_CITATION_VW as
(
SELECT WH.CA_STATUTORY_CITATION_ID WH_CA_STATUTORY_CITATION_ID,
       ETL.WH_CA_AUTHORITY_ID,
       ETL.CA_SUBM_ID,
       NODE."CA_STATUTORY_CITATION_ID",
       NODE."CA_AUTHORITY_ID",
       NODE."TRANS_CODE",
       NODE."STATUTORY_CITTION_DTA_OWNR_CDE",
       NODE."STATUTORY_CITATION_IDEN"
FROM NODE_RCRA_CA_STATUTORY_CITAT NODE
         INNER JOIN ETL_CA_AUTHORITY_VW ETL ON ETL.CA_AUTHORITY_ID = NODE.CA_AUTHORITY_ID
         LEFT OUTER JOIN RCRA_CA_STATUTORY_CITATION WH ON WH.CA_AUTHORITY_ID = ETL.WH_CA_AUTHORITY_ID
    AND WH.STATUTORY_CITTION_DTA_OWNR_CDE =
        NODE.STATUTORY_CITTION_DTA_OWNR_CDE
    AND WH.STATUTORY_CITATION_IDEN = NODE.STATUTORY_CITATION_IDEN
    )
/

create synonym NODE_RCRA_FA_COST_EST_REL_MECH for NODE_FLOW_RCRA.RCRA_FA_COST_EST_REL_MECHANISM
/

create view ETL_FA_COST_EST_REL_MECH_VW as
(
SELECT WH.FA_COST_EST_REL_MECHANISM_ID WH_FA_COST_EST_REL_MECH_ID,
       ETL.WH_FA_COST_EST_ID,
       ETL.FA_SUBM_ID,
       NODE."FA_COST_EST_REL_MECHANISM_ID",
       NODE."FA_COST_EST_ID",
       NODE."TRANS_CODE",
       NODE."ACT_LOC_CODE",
       NODE."MECHANISM_AGN_CODE",
       NODE."MECHANISM_SEQ_NUM",
       NODE."MECHANISM_DETAIL_SEQ_NUM"
FROM NODE_RCRA_FA_COST_EST_REL_MECH NODE
         INNER JOIN ETL_FA_COST_EST_VW ETL ON ETL.FA_COST_EST_ID = NODE.FA_COST_EST_ID
         LEFT OUTER JOIN RCRA_FA_COST_EST_REL_MECHANISM WH ON WH.FA_COST_EST_ID = ETL.WH_FA_COST_EST_ID
    AND WH.MECHANISM_SEQ_NUM = NODE.MECHANISM_SEQ_NUM
    AND WH.MECHANISM_DETAIL_SEQ_NUM = NODE.MECHANISM_DETAIL_SEQ_NUM
    )
/

create synonym NODE_RCRA_HD_SEC_MATERIAL_ACT for NODE_FLOW_RCRA.RCRA_HD_SEC_MATERIAL_ACTIVITY
/

create view ETL_HD_SEC_MAT_ACT_VW as
(
SELECT WH.HD_SEC_MATERIAL_ACTIVITY_ID WH_HD_SEC_MATERIAL_ACTIVITY_ID,
       ETL.WH_HD_HANDLER_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_SEC_MATERIAL_ACTIVITY_ID",
       NODE."HD_HANDLER_ID",
       NODE."TRANS_CODE",
       NODE."HSM_SEQ_NUM",
       NODE."FAC_CODE_OWNER_NAME",
       NODE."FAC_TYPE_CODE",
       NODE."ESTIMATED_SHORT_TONS_QNTY",
       NODE."ACTL_SHORT_TONS_QNTY",
       NODE."LAND_BASED_UNIT_IND",
       NODE."LAND_BASED_UNIT_IND_TEXT"
FROM NODE_RCRA_HD_SEC_MATERIAL_ACT NODE
         INNER JOIN ETL_HD_HANDLER_ID_VW ETL ON ETL.HD_HANDLER_ID = NODE.HD_HANDLER_ID
         LEFT OUTER JOIN RCRA_HD_SEC_MATERIAL_ACTIVITY WH ON WH.HD_HANDLER_ID = ETL.WH_HD_HANDLER_ID
    AND WH.HSM_SEQ_NUM = NODE.HSM_SEQ_NUM
    )
/

create view ETL_HD_SEC_WASTE_CD_VW as
(
SELECT WH.HD_SEC_WASTE_CODE_ID WH_HD_SEC_WASTE_CODE_ID,
       ETL.WH_HD_SEC_MATERIAL_ACTIVITY_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_SEC_WASTE_CODE_ID",
       NODE."HD_SEC_MATERIAL_ACTIVITY_ID",
       NODE."TRANSACTION_CODE",
       NODE."WASTE_CODE_OWNER",
       NODE."WASTE_CODE_TYPE"
FROM NODE_RCRA_HD_SEC_WASTE_CODE NODE
         INNER JOIN ETL_HD_SEC_MAT_ACT_VW ETL ON ETL.HD_SEC_MATERIAL_ACTIVITY_ID = NODE.HD_SEC_MATERIAL_ACTIVITY_ID
         LEFT OUTER JOIN RCRA_HD_SEC_WASTE_CODE WH
                         ON WH.HD_SEC_MATERIAL_ACTIVITY_ID = ETL.WH_HD_SEC_MATERIAL_ACTIVITY_ID
                             AND WH.WASTE_CODE_OWNER = NODE.WASTE_CODE_OWNER
                             AND WH.WASTE_CODE_TYPE = NODE.WASTE_CODE_TYPE
    )
/

create synonym NODE_RCRA_HD_EPISODIC_WASTE_CD for NODE_FLOW_RCRA.RCRA_HD_EPISODIC_WASTE_CODE
/

create view ETL_HD_EPISODIC_WASTE_CODE as
(
SELECT WH.HD_EPISODIC_WASTE_CODE_ID WH_HD_EPISODIC_WASTE_CODE_ID,
       ETL.WH_HD_EPISODIC_WASTE_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_EPISODIC_WASTE_CODE_ID",
       NODE."HD_EPISODIC_WASTE_ID",
       NODE."TRANSACTION_CODE",
       NODE."WASTE_CODE_OWNER",
       NODE."WASTE_CODE",
       NODE."WASTE_CODE_TEXT"
FROM NODE_RCRA_HD_EPISODIC_WASTE_CD NODE
         INNER JOIN ETL_HD_EPISODIC_WASTE ETL ON ETL.HD_EPISODIC_WASTE_ID = NODE.HD_EPISODIC_WASTE_ID
         LEFT OUTER JOIN RCRA_HD_EPISODIC_WASTE_CODE WH ON WH.HD_EPISODIC_WASTE_ID = ETL.WH_HD_EPISODIC_WASTE_ID
    AND WH.WASTE_CODE_OWNER = NODE.WASTE_CODE_OWNER
    AND WH.WASTE_CODE = NODE.WASTE_CODE
    )
/

create view NODE_TABLE_COUNTS as
SELECT 'RCRA_CA_AREA' table_name,
       count(*)       cnt
FROM NODE_RCRA_CA_AREA
UNION ALL
SELECT 'RCRA_CA_AREA_REL_EVENT' table_name,
       count(*)                 cnt
FROM NODE_RCRA_CA_AREA_REL_EVENT
UNION ALL
SELECT 'RCRA_CA_AUTH_REL_EVENT' table_name,
       count(*)                 cnt
FROM NODE_RCRA_CA_AUTH_REL_EVENT
UNION ALL
SELECT 'RCRA_CA_AUTHORITY' table_name,
       count(*)            cnt
FROM NODE_RCRA_CA_AUTHORITY
UNION ALL
SELECT 'RCRA_CA_EVENT' table_name,
       count(*)        cnt
FROM NODE_RCRA_CA_EVENT
UNION ALL
SELECT 'RCRA_CA_EVENT_COMMITMENT' table_name,
       count(*)                   cnt
FROM NODE_RCRA_CA_EVENT_COMMITMENT
UNION ALL
SELECT 'RCRA_CA_FAC_SUBM' table_name,
       count(*)           cnt
FROM NODE_RCRA_CA_FAC_SUBM
UNION ALL
SELECT 'RCRA_CA_REL_PERMIT_UNIT' table_name,
       count(*)                  cnt
FROM NODE_RCRA_CA_REL_PERMIT_UNIT
UNION ALL
SELECT 'RCRA_CA_STATUTORY_CITATION' table_name,
       count(*)                     cnt
FROM NODE_RCRA_CA_STATUTORY_CITAT
UNION ALL
SELECT 'RCRA_CA_SUBM' table_name,
       count(*)       cnt
FROM NODE_RCRA_CA_SUBM
UNION ALL
SELECT 'RCRA_CME_CITATION' table_name,
       count(*)            cnt
FROM NODE_RCRA_CME_CITATION
UNION ALL
SELECT 'RCRA_CME_CSNY_DATE' table_name,
       count(*)             cnt
FROM NODE_RCRA_CME_CSNY_DATE
UNION ALL
SELECT 'RCRA_CME_ENFRC_ACT' table_name,
       count(*)             cnt
FROM NODE_RCRA_CME_ENFRC_ACT
UNION ALL
SELECT 'RCRA_CME_EVAL' table_name,
       count(*)        cnt
FROM NODE_RCRA_CME_EVAL
UNION ALL
SELECT 'RCRA_CME_EVAL_COMMIT' table_name,
       count(*)               cnt
FROM NODE_RCRA_CME_EVAL_COMMIT
UNION ALL
SELECT 'RCRA_CME_EVAL_VIOL' table_name,
       count(*)             cnt
FROM NODE_RCRA_CME_EVAL_VIOL
UNION ALL
SELECT 'RCRA_CME_FAC_SUBM' table_name,
       count(*)            cnt
FROM NODE_RCRA_CME_FAC_SUBM
UNION ALL
SELECT 'RCRA_CME_MEDIA' table_name,
       count(*)         cnt
FROM NODE_RCRA_CME_MEDIA
UNION ALL
SELECT 'RCRA_CME_MILESTONE' table_name,
       count(*)             cnt
FROM NODE_RCRA_CME_MILESTONE
UNION ALL
SELECT 'RCRA_CME_PNLTY' table_name,
       count(*)         cnt
FROM NODE_RCRA_CME_PNLTY
UNION ALL
SELECT 'RCRA_CME_PYMT' table_name,
       count(*)        cnt
FROM NODE_RCRA_CME_PYMT
UNION ALL
SELECT 'RCRA_CME_RQST' table_name,
       count(*)        cnt
FROM NODE_RCRA_CME_RQST
UNION ALL
SELECT 'RCRA_CME_SUBM' table_name,
       count(*)        cnt
FROM NODE_RCRA_CME_SUBM
UNION ALL
SELECT 'RCRA_CME_SUPP_ENVR_PRJT' table_name,
       count(*)                  cnt
FROM NODE_RCRA_CME_SUPP_ENVR_PRJT
UNION ALL
SELECT 'RCRA_CME_VIOL' table_name,
       count(*)        cnt
FROM NODE_RCRA_CME_VIOL
UNION ALL
SELECT 'RCRA_CME_VIOL_ENFRC' table_name,
       count(*)              cnt
FROM NODE_RCRA_CME_VIOL_ENFRC
UNION ALL
SELECT 'RCRA_FA_COST_EST' table_name,
       count(*)           cnt
FROM NODE_RCRA_FA_COST_EST
UNION ALL
SELECT 'RCRA_FA_COST_EST_REL_MECHANISM' table_name,
       count(*)                         cnt
FROM NODE_RCRA_FA_COST_EST_REL_MECH
UNION ALL
SELECT 'RCRA_FA_FAC_SUBM' table_name,
       count(*)           cnt
FROM NODE_RCRA_FA_FAC_SUBM
UNION ALL
SELECT 'RCRA_FA_MECHANISM' table_name,
       count(*)            cnt
FROM NODE_RCRA_FA_MECHANISM
UNION ALL
SELECT 'RCRA_FA_MECHANISM_DETAIL' table_name,
       count(*)                   cnt
FROM NODE_RCRA_FA_MECHANISM_DETAIL
UNION ALL
SELECT 'RCRA_FA_SUBM' table_name,
       count(*)       cnt
FROM NODE_RCRA_FA_SUBM
UNION ALL
SELECT 'RCRA_GIS_FAC_SUBM' table_name,
       count(*)            cnt
FROM NODE_RCRA_GIS_FAC_SUBM
UNION ALL
SELECT 'RCRA_GIS_GEO_INFORMATION' table_name,
       count(*)                   cnt
FROM NODE_RCRA_GIS_GEO_INFORMATION
UNION ALL
SELECT 'RCRA_GIS_SUBM' table_name,
       count(*)        cnt
FROM NODE_RCRA_GIS_SUBM
UNION ALL
SELECT 'RCRA_HD_CERTIFICATION' table_name,
       count(*)                cnt
FROM NODE_RCRA_HD_CERTIFICATION
UNION ALL
SELECT 'RCRA_HD_ENV_PERMIT' table_name,
       count(*)             cnt
FROM NODE_RCRA_HD_ENV_PERMIT
UNION ALL
SELECT 'RCRA_HD_EPISODIC_EVENT' table_name,
       count(*)                 cnt
FROM NODE_RCRA_HD_EPISODIC_EVENT
UNION ALL
SELECT 'RCRA_HD_EPISODIC_WASTE' table_name,
       count(*)                 cnt
FROM NODE_RCRA_HD_EPISODIC_WASTE
UNION ALL
SELECT 'RCRA_HD_EPISODIC_WASTE_CODE' table_name,
       count(*)                      cnt
FROM NODE_RCRA_HD_EPISODIC_WASTE_CD
UNION ALL
SELECT 'RCRA_HD_HANDLER' table_name,
       count(*)          cnt
FROM NODE_RCRA_HD_HANDLER
UNION ALL
SELECT 'RCRA_HD_HBASIC' table_name,
       count(*)         cnt
FROM NODE_RCRA_HD_HBASIC
UNION ALL
SELECT 'RCRA_HD_LQG_CLOSURE' table_name,
       count(*)              cnt
FROM NODE_RCRA_HD_LQG_CLOSURE
UNION ALL
SELECT 'RCRA_HD_LQG_CONSOLIDATION' table_name,
       count(*)                    cnt
FROM NODE_RCRA_HD_LQG_CONSOLIDATION
UNION ALL
SELECT 'RCRA_HD_NAICS' table_name,
       count(*)        cnt
FROM NODE_RCRA_HD_NAICS
UNION ALL
SELECT 'RCRA_HD_OTHER_ID' table_name,
       count(*)           cnt
FROM NODE_RCRA_HD_OTHER_ID
UNION ALL
SELECT 'RCRA_HD_OWNEROP' table_name,
       count(*)          cnt
FROM NODE_RCRA_HD_OWNEROP
UNION ALL
SELECT 'RCRA_HD_SEC_MATERIAL_ACTIVITY' table_name,
       count(*)                        cnt
FROM NODE_RCRA_HD_SEC_MATERIAL_ACT
UNION ALL
SELECT 'RCRA_HD_SEC_WASTE_CODE' table_name,
       count(*)                 cnt
FROM NODE_RCRA_HD_SEC_WASTE_CODE
UNION ALL
SELECT 'RCRA_HD_STATE_ACTIVITY' table_name,
       count(*)                 cnt
FROM NODE_RCRA_HD_STATE_ACTIVITY
UNION ALL
SELECT 'RCRA_HD_SUBM' table_name,
       count(*)       cnt
FROM NODE_RCRA_HD_SUBM
UNION ALL
SELECT 'RCRA_HD_UNIVERSAL_WASTE' table_name,
       count(*)                  cnt
FROM NODE_RCRA_HD_UNIVERSAL_WASTE
UNION ALL
SELECT 'RCRA_HD_WASTE_CODE' table_name,
       count(*)             cnt
FROM NODE_RCRA_HD_WASTE_CODE
UNION ALL
SELECT 'RCRA_PRM_EVENT' table_name,
       count(*)         cnt
FROM NODE_RCRA_PRM_EVENT
UNION ALL
SELECT 'RCRA_PRM_EVENT_COMMITMENT' table_name,
       count(*)                    cnt
FROM NODE_RCRA_PRM_EVENT_COMMITMENT
UNION ALL
SELECT 'RCRA_PRM_FAC_SUBM' table_name,
       count(*)            cnt
FROM NODE_RCRA_PRM_FAC_SUBM
UNION ALL
SELECT 'RCRA_PRM_RELATED_EVENT' table_name,
       count(*)                 cnt
FROM NODE_RCRA_PRM_RELATED_EVENT
UNION ALL
SELECT 'RCRA_PRM_SERIES' table_name,
       count(*)          cnt
FROM NODE_RCRA_PRM_SERIES
UNION ALL
SELECT 'RCRA_PRM_SUBM' table_name,
       count(*)        cnt
FROM NODE_RCRA_PRM_SUBM
UNION ALL
SELECT 'RCRA_PRM_UNIT' table_name,
       count(*)        cnt
FROM NODE_RCRA_PRM_UNIT
UNION ALL
SELECT 'RCRA_PRM_UNIT_DETAIL' table_name,
       count(*)               cnt
FROM NODE_RCRA_PRM_UNIT_DETAIL
UNION ALL
SELECT 'RCRA_PRM_WASTE_CODE' table_name,
       count(*)              cnt
FROM NODE_RCRA_PRM_WASTE_CODE
UNION ALL
SELECT 'RCRA_RU_REPORT_UNIV' table_name,
       count(*)              cnt
FROM NODE_RCRA_RU_REPORT_UNIV
UNION ALL
SELECT 'RCRA_RU_REPORT_UNIV_SUBM' table_name,
       count(*)                   cnt
FROM NODE_RCRA_RU_REPORT_UNIV_SUBM
UNION ALL
SELECT 'RCRA_RU_SUBM' table_name,
       count(*)       cnt
FROM NODE_RCRA_RU_SUBM
UNION ALL
SELECT 'RCRA_EM_EMANIFEST' table_name,
       count(*)            cnt
FROM NODE_RCRA_EM_EMANIFEST
UNION ALL
SELECT 'RCRA_EM_EMANIFEST_COMMENT' table_name,
       count(*)                    cnt
FROM NODE_RCRA_EM_EMANIFEST_COMMENT
UNION ALL
SELECT 'RCRA_EM_HANDLER' table_name,
       count(*)          cnt
FROM NODE_RCRA_EM_HANDLER
UNION ALL
SELECT 'RCRA_EM_SUBM' table_name,
       count(*)       cnt
FROM NODE_RCRA_EM_SUBM
UNION ALL
SELECT 'RCRA_EM_TR_NUM_ORIG' table_name,
       count(*)              cnt
FROM NODE_RCRA_EM_TR_NUM_ORIG
UNION ALL
SELECT 'RCRA_EM_TR_NUM_REJ' table_name,
       count(*)             cnt
FROM NODE_RCRA_EM_TR_NUM_REJ
UNION ALL
SELECT 'RCRA_EM_TR_NUM_RES_NEW' table_name,
       count(*)                 cnt
FROM NODE_RCRA_EM_TR_NUM_RES_NEW
UNION ALL
SELECT 'RCRA_EM_TR_NUM_WASTE' table_name,
       count(*)               cnt
FROM NODE_RCRA_EM_TR_NUM_WASTE
UNION ALL
SELECT 'RCRA_EM_WASTE' table_name,
       count(*)        cnt
FROM NODE_RCRA_EM_WASTE
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_FED' table_name,
       count(*)               cnt
FROM NODE_RCRA_EM_WASTE_CD_FED
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_GEN' table_name,
       count(*)               cnt
FROM NODE_RCRA_EM_WASTE_CD_GEN
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_TRANS' table_name,
       count(*)                 cnt
FROM NODE_RCRA_EM_WASTE_CD_TRANS
UNION ALL
SELECT 'RCRA_EM_WASTE_CD_TSDF' table_name,
       count(*)                cnt
FROM NODE_RCRA_EM_WASTE_CD_TSDF
UNION ALL
SELECT 'RCRA_EM_WASTE_COMMENT' table_name,
       count(*)                cnt
FROM NODE_RCRA_EM_WASTE_COMMENT
UNION ALL
SELECT 'RCRA_EM_WASTE_PCB' table_name,
       count(*)            cnt
FROM NODE_RCRA_EM_WASTE_PCB
UNION ALL
SELECT 'RCRA_SUBMISSIONHISTORY' table_name,
       count(*)                 cnt
FROM NODE_RCRA_SUBMISSIONHISTORY
/

create synonym NODE_RCRA_HANDLER for NODE_FLOW_RCRA.RCRA_HANDLER
/

create synonym NODE_RCRA_LOCADDRESS for NODE_FLOW_RCRA.RCRA_LOCADDRESS
/

create synonym NODE_RCRA_MAILINGADDRESS for NODE_FLOW_RCRA.RCRA_MAILINGADDRESS
/

create synonym NODE_RCRA_CONTACTADDRESS for NODE_FLOW_RCRA.RCRA_CONTACTADDRESS
/

create synonym NODE_RCRA_CONTACT for NODE_FLOW_RCRA.RCRA_CONTACT
/

create synonym NODE_RCRA_FACSUB for NODE_FLOW_RCRA.RCRA_FACSUB
/

create synonym NODE_RCRA_USEDOIL for NODE_FLOW_RCRA.RCRA_USEDOIL
/

create synonym NODE_RCRA_LABHZRDWASTE for NODE_FLOW_RCRA.RCRA_LABHZRDWASTE
/

create synonym NODE_RCRA_SITEWASTEACT for NODE_FLOW_RCRA.RCRA_SITEWASTEACT
/

create synonym NODE_RCRA_HZRDSECONDARYMTRL for NODE_FLOW_RCRA.RCRA_HZRDSECONDARYMTRL
/

create synonym NODE_RCRA_NAICS for NODE_FLOW_RCRA.RCRA_NAICS
/

create synonym NODE_RCRA_CERT for NODE_FLOW_RCRA.RCRA_CERT
/

create synonym NODE_RCRA_ENVPERMIT for NODE_FLOW_RCRA.RCRA_ENVPERMIT
/

create synonym NODE_RCRA_HANDLERWASTECODE for NODE_FLOW_RCRA.RCRA_HANDLERWASTECODE
/

create synonym NODE_RCRA_UNVWASTEACT for NODE_FLOW_RCRA.RCRA_UNVWASTEACT
/

create synonym NODE_RCRA_STATEACT for NODE_FLOW_RCRA.RCRA_STATEACT
/

create synonym NODE_RCRA_FACOWNROPER for NODE_FLOW_RCRA.RCRA_FACOWNROPER
/

create synonym NODE_RCRA_HZRDSECONDARYMTRLACT for NODE_FLOW_RCRA.RCRA_HZRDSECONDARYMTRLACT
/

create synonym NODE_RCRA_OTHERID for NODE_FLOW_RCRA.RCRA_OTHERID
/

create synonym NODE_RCRA_WASTEGENRTR for NODE_FLOW_RCRA.RCRA_WASTEGENRTR
/

create synonym NODE_RCRA_PERMITFACSUB for NODE_FLOW_RCRA.RCRA_PERMITFACSUB
/

create synonym NODE_RCRA_PERMITSERIES for NODE_FLOW_RCRA.RCRA_PERMITSERIES
/

create synonym NODE_RCRA_PERMITUNIT for NODE_FLOW_RCRA.RCRA_PERMITUNIT
/

create synonym NODE_RCRA_PERMITUNITDETAIL for NODE_FLOW_RCRA.RCRA_PERMITUNITDETAIL
/

create synonym NODE_RCRA_PERMITEVENT for NODE_FLOW_RCRA.RCRA_PERMITEVENT
/

create synonym NODE_RCRA_EVENTCOMMIT for NODE_FLOW_RCRA.RCRA_EVENTCOMMIT
/

create synonym NODE_RCRA_PERMITRELEVENT for NODE_FLOW_RCRA.RCRA_PERMITRELEVENT
/

create synonym NODE_RCRA_FINASSURFACSUB for NODE_FLOW_RCRA.RCRA_FINASSURFACSUB
/

create synonym NODE_RCRA_MECH for NODE_FLOW_RCRA.RCRA_MECH
/

create synonym NODE_RCRA_MECHDETAIL for NODE_FLOW_RCRA.RCRA_MECHDETAIL
/

create synonym NODE_RCRA_COSTEST for NODE_FLOW_RCRA.RCRA_COSTEST
/

create synonym NODE_RCRA_COSTESTRELMECH for NODE_FLOW_RCRA.RCRA_COSTESTRELMECH
/

create synonym NODE_RCRA_CORRACTFACSUB for NODE_FLOW_RCRA.RCRA_CORRACTFACSUB
/

create synonym NODE_RCRA_CORRACTEVENT for NODE_FLOW_RCRA.RCRA_CORRACTEVENT
/

create synonym NODE_RCRA_CORRACTAREA for NODE_FLOW_RCRA.RCRA_CORRACTAREA
/

create synonym NODE_RCRA_CORRACTAUTH for NODE_FLOW_RCRA.RCRA_CORRACTAUTH
/

create synonym NODE_RCRA_CORRACTRELEVENT for NODE_FLOW_RCRA.RCRA_CORRACTRELEVENT
/

create synonym NODE_RCRA_CORRACTSTATCITN for NODE_FLOW_RCRA.RCRA_CORRACTSTATCITN
/

create synonym NODE_RCRA_CORRACTRELPERMITUNIT for NODE_FLOW_RCRA.RCRA_CORRACTRELPERMITUNIT
/

create synonym NODE_RCRA_CMEFACSUB for NODE_FLOW_RCRA.RCRA_CMEFACSUB
/

create synonym NODE_RCRA_VIO for NODE_FLOW_RCRA.RCRA_VIO
/

create synonym NODE_RCRA_EVAL for NODE_FLOW_RCRA.RCRA_EVAL
/

create synonym NODE_RCRA_ENFRCACT for NODE_FLOW_RCRA.RCRA_ENFRCACT
/

create synonym NODE_RCRA_EVALCOMMIT for NODE_FLOW_RCRA.RCRA_EVALCOMMIT
/

create synonym NODE_RCRA_EVALVIO for NODE_FLOW_RCRA.RCRA_EVALVIO
/

create synonym NODE_RCRA_CITN for NODE_FLOW_RCRA.RCRA_CITN
/

create synonym NODE_RCRA_CSNYDATE for NODE_FLOW_RCRA.RCRA_CSNYDATE
/

create synonym NODE_RCRA_MEDIA for NODE_FLOW_RCRA.RCRA_MEDIA
/

create synonym NODE_RCRA_MLSTN for NODE_FLOW_RCRA.RCRA_MLSTN
/

create synonym NODE_RCRA_REQUEST for NODE_FLOW_RCRA.RCRA_REQUEST
/

create synonym NODE_RCRA_SUPPENVPROJ for NODE_FLOW_RCRA.RCRA_SUPPENVPROJ
/

create synonym NODE_RCRA_VIOENFRC for NODE_FLOW_RCRA.RCRA_VIOENFRC
/

create synonym NODE_RCRA_PENALTY for NODE_FLOW_RCRA.RCRA_PENALTY
/

create synonym NODE_RCRA_PAYMNT for NODE_FLOW_RCRA.RCRA_PAYMNT
/

create synonym NODE_RCRA_GISFACSUB for NODE_FLOW_RCRA.RCRA_GISFACSUB
/

create synonym NODE_RCRA_GEOGINF for NODE_FLOW_RCRA.RCRA_GEOGINF
/

create synonym NODE_RCRA_GEOGMETA for NODE_FLOW_RCRA.RCRA_GEOGMETA
/

create synonym NODE_RCRA_WHERETYPE for NODE_FLOW_RCRA.RCRA_WHERETYPE
/

create synonym NODE_RCRA_AREAACREAGE for NODE_FLOW_RCRA.RCRA_AREAACREAGE
/

create synonym NODE_RCRA_REPORTUNIV for NODE_FLOW_RCRA.RCRA_REPORTUNIV
/

create synonym NODE_RCRA_HANDLERLQGCLOSURE for NODE_FLOW_RCRA.RCRA_HANDLERLQGCLOSURE
/

create synonym NODE_RCRA_HANDLERLQGCONSOLID for NODE_FLOW_RCRA.RCRA_HANDLERLQGCONSOLIDATION
/

create synonym NODE_RCRA_EPISODICWASTE for NODE_FLOW_RCRA.RCRA_EPISODICWASTE
/

create synonym NODE_RCRA_HANDLEREPISODICEVENT for NODE_FLOW_RCRA.RCRA_HANDLEREPISODICEVENT
/

create synonym NODE_RCRA_PRM_MOD_EVENT for NODE_FLOW_RCRA.RCRA_PRM_MOD_EVENT
/

create view ETL_PRM_MOD_EVENT_VW as
(
SELECT WH.PRM_MOD_EVENT_ID WH_PRM_MOD_EVENT_ID,
       ETL.WH_PRM_EVENT_ID,
       ETL.PRM_SUBM_ID,
       NODE."PRM_MOD_EVENT_ID",
       NODE."PRM_EVENT_ID",
       NODE."TRANS_CODE",
       NODE."MOD_HANDLER_ID",
       NODE."MOD_ACT_LOC_CODE",
       NODE."MOD_SERIES_SEQ_NUM",
       NODE."MOD_EVENT_SEQ_NUM",
       NODE."MOD_EVENT_AGN_CODE",
       NODE."MOD_EVENT_DATA_OWNER_CODE",
       NODE."MOD_EVENT_CODE"
FROM NODE_RCRA_PRM_MOD_EVENT NODE
         INNER JOIN ETL_PRM_EVENT_VW ETL ON ETL.PRM_EVENT_ID = NODE.PRM_EVENT_ID
         LEFT OUTER JOIN RCRA_PRM_MOD_EVENT WH ON WH.PRM_EVENT_ID = ETL.WH_PRM_EVENT_ID
    AND WH.MOD_EVENT_SEQ_NUM = NODE.MOD_EVENT_SEQ_NUM
    )
/

create synonym NODE_RCRA_CME_SUBM_DEL for NODE_FLOW_RCRA.RCRA_CME_SUBM_DEL
/

create synonym NODE_RCRA_CME_FAC_SUBM_DEL for NODE_FLOW_RCRA.RCRA_CME_FAC_SUBM_DEL
/

create view ETL_CME_FAC_SUBM_DEL_VW as
(
SELECT WH.CME_FAC_SUBM_ID WH_CME_FAC_SUBM_ID,
       NODE."CME_FAC_SUBM_DEL_ID",
       NODE."CME_SUBM_DEL_ID",
       NODE."EPA_HDLR_ID"
FROM NODE_RCRA_CME_FAC_SUBM_DEL NODE
         LEFT OUTER JOIN RCRA_CME_FAC_SUBM WH ON WH.EPA_HDLR_ID = NODE.EPA_HDLR_ID
    )
/

create synonym NODE_RCRA_CME_ENFRC_ACT_DEL for NODE_FLOW_RCRA.RCRA_CME_ENFRC_ACT_DEL
/

create view ETL_CME_ENFRC_ACT_DEL_VW as
(
SELECT WH.CME_ENFRC_ACT_ID WH_CME_ENFR_ACT_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_DEL_ID,
       NODE."CME_ENFRC_ACT_DEL_ID",
       NODE."CME_FAC_SUBM_DEL_ID",
       NODE."ENFRC_AGN_LOC_NAME",
       NODE."ENFRC_ACT_IDEN",
       NODE."ENFRC_ACT_DATE",
       NODE."ENFRC_AGN_NAME",
       NODE."NOTES"
FROM NODE_RCRA_CME_ENFRC_ACT_DEL NODE
         INNER JOIN ETL_CME_FAC_SUBM_DEL_VW ETL ON ETL.CME_FAC_SUBM_DEL_ID = NODE.CME_FAC_SUBM_DEL_ID
         LEFT OUTER JOIN RCRA_CME_ENFRC_ACT WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.ENFRC_ACT_IDEN = NODE.ENFRC_ACT_IDEN
    AND WH.ENFRC_ACT_DATE = NODE.ENFRC_ACT_DATE
    AND WH.ENFRC_AGN_NAME = NODE.ENFRC_AGN_NAME
    )
/

create synonym NODE_RCRA_CME_EVAL_DEL for NODE_FLOW_RCRA.RCRA_CME_EVAL_DEL
/

create view ETL_CME_EVAL_DEL_VW as
(
SELECT WH.CME_EVAL_ID WH_CME_EVAL_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_DEL_ID,
       NODE."CME_EVAL_DEL_ID",
       NODE."CME_FAC_SUBM_DEL_ID",
       NODE."EVAL_ACT_LOC",
       NODE."EVAL_IDEN",
       NODE."EVAL_START_DATE",
       NODE."EVAL_RESP_AGN",
       NODE."NOTES"
FROM NODE_RCRA_CME_EVAL_DEL NODE
         JOIN ETL_CME_FAC_SUBM_DEL_VW ETL ON ETL.CME_FAC_SUBM_DEL_ID = NODE.CME_FAC_SUBM_DEL_ID
         LEFT OUTER JOIN RCRA_CME_EVAL WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.EVAL_ACT_LOC = NODE.EVAL_ACT_LOC
    AND WH.EVAL_IDEN = NODE.EVAL_IDEN
    AND WH.EVAL_RESP_AGN = NODE.EVAL_RESP_AGN
    AND WH.EVAL_START_DATE = NODE.EVAL_START_DATE
    )
/

create synonym NODE_RCRA_CME_VIOL_DEL for NODE_FLOW_RCRA.RCRA_CME_VIOL_DEL
/

create view ETL_CME_VIOL_DEL_VW as
(
SELECT WH.CME_VIOL_ID WH_CME_VIOL_ID,
       ETL.WH_CME_FAC_SUBM_ID,
       ETL.CME_SUBM_DEL_ID,
       NODE."CME_VIOL_DEL_ID",
       NODE."CME_FAC_SUBM_DEL_ID",
       NODE."VIOL_ACT_LOC",
       NODE."VIOL_SEQ_NUM",
       NODE."AGN_WHICH_DTRM_VIOL",
       NODE."NOTES"
FROM NODE_RCRA_CME_VIOL_DEL NODE
         JOIN ETL_CME_FAC_SUBM_DEL_VW ETL ON ETL.CME_FAC_SUBM_DEL_ID = NODE.CME_FAC_SUBM_DEL_ID
         LEFT OUTER JOIN RCRA_CME_VIOL WH ON WH.CME_FAC_SUBM_ID = ETL.WH_CME_FAC_SUBM_ID
    AND WH.VIOL_SEQ_NUM = NODE.VIOL_SEQ_NUM
    AND WH.VIOL_ACT_LOC = NODE.VIOL_ACT_LOC
    AND WH.AGN_WHICH_DTRM_VIOL = NODE.AGN_WHICH_DTRM_VIOL
    )
/

create synonym NODE_RCRA_HD_EPISODIC_PRJT for NODE_FLOW_RCRA.RCRA_HD_EPISODIC_PRJT
/

create view ETL_HD_EPISODIC_PRJT as
(
SELECT WH.HD_EPISODIC_PRJT_ID WH_HD_EPISODIC_PRJT_ID,
       ETL.WH_HD_EPISODIC_EVENT_ID,
       ETL.HD_SUBM_ID,
       NODE."HD_EPISODIC_PRJT_ID",
       NODE."HD_EPISODIC_EVENT_ID",
       NODE."TRANSACTION_CODE",
       NODE."PRJT_CODE_OWNER",
       NODE."PRJT_CODE",
       NODE."OTHER_PRJT_DESC"
FROM NODE_RCRA_HD_EPISODIC_PRJT NODE
         INNER JOIN ETL_HD_EPISODIC_EVENT ETL ON ETL.HD_EPISODIC_EVENT_ID = NODE.HD_EPISODIC_EVENT_ID
         LEFT OUTER JOIN RCRA_HD_EPISODIC_PRJT WH ON WH.HD_EPISODIC_EVENT_ID = ETL.WH_HD_EPISODIC_EVENT_ID
    AND WH.PRJT_CODE_OWNER = NODE.PRJT_CODE_OWNER
    AND WH.PRJT_CODE = NODE.PRJT_CODE
    )
/

create synonym NODE_RCRA_EM_FED_WASTE_CODE for NODE_FLOW_RCRA.RCRA_EM_FED_WASTE_CODE_DESC
/

create view ETL_EM_FED_WASTE_CODE_DESC_VW as
select ETL.WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_FED_WASTE_CODE_DESC_ID",NODE."EM_WASTE_ID",NODE."FED_MANIFEST_WASTE_CODE",NODE."MANIFEST_WASTE_DESC",NODE."COI_IND"
from NODE_RCRA_EM_FED_WASTE_CODE NODE
         join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID
/

create synonym NODE_RCRA_EM_STATE_WASTE_CODE for NODE_FLOW_RCRA.RCRA_EM_STATE_WASTE_CODE_DESC
/

create view ETL_EM_STATE_WASTE_CODE_VW as
select ETL.WH_EM_WASTE_ID,
       ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_STATE_WASTE_CODE_DESC_ID",NODE."EM_WASTE_ID",NODE."STA_MANIFEST_WASTE_CODE",NODE."MANIFEST_WASTE_DESC"
from NODE_RCRA_EM_STATE_WASTE_CODE NODE
         join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID
/

create synonym NODE_RCRA_EM_TRANSPORTER for NODE_FLOW_RCRA.RCRA_EM_TRANSPORTER
/

create view ETL_EM_TRANSPORTER_VW as
select ETL.WH_EM_EMANIFEST_ID,
       ETL.EM_SUBM_ID,
       NODE."EM_TRANSPORTER_ID",NODE."EM_EMANIFEST_ID",NODE."TRANSPORTER_ID",NODE."TRANSPORTER_NAME",NODE."TRANSPORTER_PRINTED_NAME",NODE."TRANSPORTER_SIGNATURE_DATE",NODE."TRANSPORTER_ESIG_FIRST_NAME",NODE."TRANSPORTER_ESIG_LAST_NAME",NODE."TRANS_ESIG_SIGNATURE_DATE",NODE."TRANSPORTER_LINE_NUM",NODE."TRANSPORTER_REGISTERED"
from NODE_RCRA_EM_TRANSPORTER NODE
         join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID
/

create PACKAGE BODY RCRAINFO_ETL AS

    -- EM
    PROCEDURE EM_LOG_HANDLER AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN (ETL_RUN_ID, RUN_DATE, ETL_TYPE)
        VALUES (ETL_ID, CURRENT_TIMESTAMP, 'EM');
    END;

    PROCEDURE EM_MERGE_EMANIFEST AS
    BEGIN
        merge into RCRA_EM_EMANIFEST D
        using (select *
               from ETL_EM_EMANIFEST_VW) S
        on (D.EM_EMANIFEST_ID = S.WH_EM_EMANIFEST_ID)
        when matched then
            update
            set D.CREATED_DATE                   = S.CREATED_DATE,
                D.UPDATED_DATE                   = S.UPDATED_DATE,
                D.MAN_TRACKING_NUM               = S.MAN_TRACKING_NUM,
                D.STATUS                         = S.STATUS,
                D.DES_FAC_MODIFIED               = S.DES_FAC_MODIFIED,
                D.SUBM_TYPE                      = S.SUBM_TYPE,
                D.GENERATOR_MODIFIED             = S.GENERATOR_MODIFIED,
                D.ORIGIN_TYPE                    = S.ORIGIN_TYPE,
                D.SHIPPED_DATE                   = S.SHIPPED_DATE,
                D.RECEIVED_DATE                  = S.RECEIVED_DATE,
                D.CERT_DATE                      = S.CERT_DATE,
                D.REJ_IND                        = S.REJ_IND,
                D.DES_FAC_REGISTERED             = S.DES_FAC_REGISTERED,
                D.IMPORT                         = S.IMPORT,
                D.GENERATOR_CONTACT_FIRST_NAME   = S.GENERATOR_CONTACT_FIRST_NAME,
                D.GENERATOR_CONTACT_LAST_NAME    = S.GENERATOR_CONTACT_LAST_NAME,
                D.GENERATOR_REGISTERED           = S.GENERATOR_REGISTERED,
                D.REJECTION_TYPE                 = S.REJECTION_TYPE,
                D.ALTERNATE_DESIGNATED_FAC_TYPE  = S.ALTERNATE_DESIGNATED_FAC_TYPE,
                D.GENERATOR_NAME                 = S.GENERATOR_NAME,
                D.DES_FAC_SIGNATURE_DATE         = S.DES_FAC_SIGNATURE_DATE,
                D.GENERATOR_ESIG_SIGNATURE_DATE  = S.GENERATOR_ESIG_SIGNATURE_DATE,
                D.DES_FAC_LOC_STREET_1           = S.DES_FAC_LOC_STREET_1,
                D.ALT_FAC_MAIL_STREET_2          = S.ALT_FAC_MAIL_STREET_2,
                D.DES_FAC_CONTACT_FIRST_NAME     = S.DES_FAC_CONTACT_FIRST_NAME,
                D.DES_FAC_CONTACT_LAST_NAME      = S.DES_FAC_CONTACT_LAST_NAME,
                D.GENERATOR_LOC_STREET_2         = S.GENERATOR_LOC_STREET_2,
                D.GENERATOR_CONTACT_EMAIL        = S.GENERATOR_CONTACT_EMAIL,
                D.DES_FAC_MAIL_STREET_1          = S.DES_FAC_MAIL_STREET_1,
                D.PORT_OF_ENTRY_CITY             = S.PORT_OF_ENTRY_CITY,
                D.GENERATOR_MAIL_ZIP             = S.GENERATOR_MAIL_ZIP,
                D.DES_FAC_MAIL_STREET_2          = S.DES_FAC_MAIL_STREET_2,
                D.GENERATOR_MAIL_STA             = S.GENERATOR_MAIL_STA,
                D.FOREIGN_GENERATOR_CTRY_NAME    = S.FOREIGN_GENERATOR_CTRY_NAME,
                D.GENERATOR_MAIL_CTRY            = S.GENERATOR_MAIL_CTRY,
                D.GENERATOR_MAIL_STREET_1        = S.GENERATOR_MAIL_STREET_1,
                D.GENERATOR_MAIL_STREET_2        = S.GENERATOR_MAIL_STREET_2,
                D.MANIFEST_HANDLING_INSTR        = S.MANIFEST_HANDLING_INSTR,
                D.RESIDUE                        = S.RESIDUE,
                D.GENERATOR_ID                   = S.GENERATOR_ID,
                D.GENERATOR_SIGNATURE_DATE       = S.GENERATOR_SIGNATURE_DATE,
                D.DES_FAC_LOC_STREET_2           = S.DES_FAC_LOC_STREET_2,
                D.ALT_FAC_MAIL_STREET_1          = S.ALT_FAC_MAIL_STREET_1,
                D.GENERATOR_ESIG_FIRST_NAME      = S.GENERATOR_ESIG_FIRST_NAME,
                D.GENERATOR_ESIG_LAST_NAME       = S.GENERATOR_ESIG_LAST_NAME,
                D.GENERATOR_LOC_STREET_1         = S.GENERATOR_LOC_STREET_1,
                D.GENERATOR_MAIL_STREET_NUM      = S.GENERATOR_MAIL_STREET_NUM,
                D.GENERATOR_MAIL_CITY            = S.GENERATOR_MAIL_CITY,
                D.GENERATOR_LOC_STREET_NUM       = S.GENERATOR_LOC_STREET_NUM,
                D.GENERATOR_LOC_CITY             = S.GENERATOR_LOC_CITY,
                D.GENERATOR_LOC_STA              = S.GENERATOR_LOC_STA,
                D.GENERATOR_LOC_ZIP              = S.GENERATOR_LOC_ZIP,
                D.GENERATOR_CONTACT_PHONE_NUM    = S.GENERATOR_CONTACT_PHONE_NUM,
                D.GENERATOR_CONTACT_PHONE_EXT    = S.GENERATOR_CONTACT_PHONE_EXT,
                D.GENERATOR_CONTACT_COMPANY_NAME = S.GENERATOR_CONTACT_COMPANY_NAME,
                D.EMERGENCY_PHONE_NUM            = S.EMERGENCY_PHONE_NUM,
                D.EMERGENCY_PHONE_EXT            = S.EMERGENCY_PHONE_EXT,
                D.GENERATOR_PRINTED_NAME         = S.GENERATOR_PRINTED_NAME,
                D.DES_FAC_ID                     = S.DES_FAC_ID,
                D.DES_FAC_NAME                   = S.DES_FAC_NAME,
                D.DES_FAC_MAIL_STREET_NUM        = S.DES_FAC_MAIL_STREET_NUM,
                D.DES_FAC_MAIL_CITY              = S.DES_FAC_MAIL_CITY,
                D.DES_FAC_MAIL_CTRY              = S.DES_FAC_MAIL_CTRY,
                D.DES_FAC_MAIL_STA               = S.DES_FAC_MAIL_STA,
                D.DES_FAC_MAIL_ZIP               = S.DES_FAC_MAIL_ZIP,
                D.DES_FAC_LOC_STREET_NUM         = S.DES_FAC_LOC_STREET_NUM,
                D.DES_FAC_LOC_CITY               = S.DES_FAC_LOC_CITY,
                D.DES_FAC_LOC_STA                = S.DES_FAC_LOC_STA,
                D.DES_FAC_LOC_ZIP                = S.DES_FAC_LOC_ZIP,
                D.DES_FAC_CONTACT_PHONE_NUM      = S.DES_FAC_CONTACT_PHONE_NUM,
                D.DES_FAC_CONTACT_PHONE_EXT      = S.DES_FAC_CONTACT_PHONE_EXT,
                D.DES_FAC_CONTACT_EMAIL          = S.DES_FAC_CONTACT_EMAIL,
                D.DES_FAC_CONTACT_COMPANY_NAME   = S.DES_FAC_CONTACT_COMPANY_NAME,
                D.DES_FAC_PRINTED_NAME           = S.DES_FAC_PRINTED_NAME,
                D.DES_FAC_ESIG_FIRST_NAME        = S.DES_FAC_ESIG_FIRST_NAME,
                D.DES_FAC_ESIG_LAST_NAME         = S.DES_FAC_ESIG_LAST_NAME,
                D.DES_FAC_ESIG_SIGNATURE_DATE    = S.DES_FAC_ESIG_SIGNATURE_DATE,
                D.ORIG_SUBM_TYPE                 = S.ORIG_SUBM_TYPE,
                D.COI_ONLY                       = S.COI_ONLY,
                D.BROKER_ID                      = S.BROKER_ID,
                D.LAST_EM_UPDT_DATE              = S.LAST_EM_UPDT_DATE,
                D.TRANSPORTER_ON_SITE            = S.TRANSPORTER_ON_SITE,
                D.ALT_FAC_PRINTED_NAME           = S.ALT_FAC_PRINTED_NAME,
                D.ALT_FAC_SIGNATURE_DATE         = S.ALT_FAC_SIGNATURE_DATE,
                D.ALT_FAC_ESIG_FIRST_NAME        = S.ALT_FAC_ESIG_FIRST_NAME,
                D.ALT_FAC_ESIG_LAST_NAME         = S.ALT_FAC_ESIG_LAST_NAME,
                D.ALT_FAC_ESIG_SIGNATURE_DATE    = S.ALT_FAC_ESIG_SIGNATURE_DATE,
                D.ALT_FAC_ID                     = S.ALT_FAC_ID,
                D.ALT_FAC_NAME                   = S.ALT_FAC_NAME,
                D.ALT_FAC_MAIL_STREET_NUM        = S.ALT_FAC_MAIL_STREET_NUM,
                D.ALT_FAC_MAIL_CITY              = S.ALT_FAC_MAIL_CITY,
                D.ALT_FAC_MAIL_STA               = S.ALT_FAC_MAIL_STA,
                D.ALT_FAC_MAIL_ZIP               = S.ALT_FAC_MAIL_ZIP,
                D.ALT_FAC_LOC_STREET_NUM         = S.ALT_FAC_LOC_STREET_NUM,
                D.ALT_FAC_LOC_STREET_1           = S.ALT_FAC_LOC_STREET_1,
                D.ALT_FAC_LOC_STREET_2           = S.ALT_FAC_LOC_STREET_2,
                D.ALT_FAC_LOC_CITY               = S.ALT_FAC_LOC_CITY,
                D.ALT_FAC_LOC_STA                = S.ALT_FAC_LOC_STA,
                D.ALT_FAC_LOC_ZIP                = S.ALT_FAC_LOC_ZIP,
                D.ALT_FAC_CONTACT_FIRST_NAME     = S.ALT_FAC_CONTACT_FIRST_NAME,
                D.ALT_FAC_CONTACT_LAST_NAME      = S.ALT_FAC_CONTACT_LAST_NAME,
                D.ALT_FAC_CONTACT_PHONE_NO       = S.ALT_FAC_CONTACT_PHONE_NO,
                D.ALT_FAC_CONTACT_PHONE_EXT      = S.ALT_FAC_CONTACT_PHONE_EXT,
                D.ALT_FAC_CONTACT_EMAIL          = S.ALT_FAC_CONTACT_EMAIL,
                D.ALT_FAC_CONTACT_COMPANY_NAME   = S.ALT_FAC_CONTACT_COMPANY_NAME,
                D.ALT_FAC_REGISTERED             = S.ALT_FAC_REGISTERED,
                D.ALT_FAC_MODIFIED               = S.ALT_FAC_MODIFIED,
                D.FOREIGN_GENERATOR_NAME         = S.FOREIGN_GENERATOR_NAME,
                D.FOREIGN_GENERATOR_STREET       = S.FOREIGN_GENERATOR_STREET,
                D.FOREIGN_GENERATOR_CITY         = S.FOREIGN_GENERATOR_CITY,
                D.FOREIGN_GENERATOR_CTRY_CODE    = S.FOREIGN_GENERATOR_CTRY_CODE,
                D.FOREIGN_GENERATOR_POST_CODE    = S.FOREIGN_GENERATOR_POST_CODE,
                D.FOREIGN_GENERATOR_PROVINCE     = S.FOREIGN_GENERATOR_PROVINCE,
                D.PORT_OF_ENTRY_STA              = S.PORT_OF_ENTRY_STA
        when not matched then
            insert (EM_EMANIFEST_ID,
                    CREATED_DATE,
                    UPDATED_DATE,
                    MAN_TRACKING_NUM,
                    STATUS,
                    DES_FAC_MODIFIED,
                    SUBM_TYPE,
                    GENERATOR_MODIFIED,
                    ORIGIN_TYPE,
                    SHIPPED_DATE,
                    RECEIVED_DATE,
                    CERT_DATE,
                    REJ_IND,
                    DES_FAC_REGISTERED,
                    IMPORT,
                    GENERATOR_CONTACT_FIRST_NAME,
                    GENERATOR_CONTACT_LAST_NAME,
                    GENERATOR_REGISTERED,
                    REJECTION_TYPE,
                    ALTERNATE_DESIGNATED_FAC_TYPE,
                    GENERATOR_NAME,
                    DES_FAC_SIGNATURE_DATE,
                    GENERATOR_ESIG_SIGNATURE_DATE,
                    DES_FAC_LOC_STREET_1,
                    ALT_FAC_MAIL_STREET_2,
                    DES_FAC_CONTACT_FIRST_NAME,
                    DES_FAC_CONTACT_LAST_NAME,
                    GENERATOR_LOC_STREET_2,
                    GENERATOR_CONTACT_EMAIL,
                    DES_FAC_MAIL_STREET_1,
                    PORT_OF_ENTRY_CITY,
                    GENERATOR_MAIL_ZIP,
                    DES_FAC_MAIL_STREET_2,
                    GENERATOR_MAIL_STA,
                    FOREIGN_GENERATOR_CTRY_NAME,
                    GENERATOR_MAIL_CTRY,
                    GENERATOR_MAIL_STREET_1,
                    GENERATOR_MAIL_STREET_2,
                    MANIFEST_HANDLING_INSTR,
                    RESIDUE,
                    GENERATOR_ID,
                    GENERATOR_SIGNATURE_DATE,
                    DES_FAC_LOC_STREET_2,
                    ALT_FAC_MAIL_STREET_1,
                    GENERATOR_ESIG_FIRST_NAME,
                    GENERATOR_ESIG_LAST_NAME,
                    GENERATOR_LOC_STREET_1,
                    GENERATOR_MAIL_STREET_NUM,
                    GENERATOR_MAIL_CITY,
                    GENERATOR_LOC_STREET_NUM,
                    GENERATOR_LOC_CITY,
                    GENERATOR_LOC_STA,
                    GENERATOR_LOC_ZIP,
                    GENERATOR_CONTACT_PHONE_NUM,
                    GENERATOR_CONTACT_PHONE_EXT,
                    GENERATOR_CONTACT_COMPANY_NAME,
                    EMERGENCY_PHONE_NUM,
                    EMERGENCY_PHONE_EXT,
                    GENERATOR_PRINTED_NAME,
                    DES_FAC_ID,
                    DES_FAC_NAME,
                    DES_FAC_MAIL_STREET_NUM,
                    DES_FAC_MAIL_CITY,
                    DES_FAC_MAIL_CTRY,
                    DES_FAC_MAIL_STA,
                    DES_FAC_MAIL_ZIP,
                    DES_FAC_LOC_STREET_NUM,
                    DES_FAC_LOC_CITY,
                    DES_FAC_LOC_STA,
                    DES_FAC_LOC_ZIP,
                    DES_FAC_CONTACT_PHONE_NUM,
                    DES_FAC_CONTACT_PHONE_EXT,
                    DES_FAC_CONTACT_EMAIL,
                    DES_FAC_CONTACT_COMPANY_NAME,
                    DES_FAC_PRINTED_NAME,
                    DES_FAC_ESIG_FIRST_NAME,
                    DES_FAC_ESIG_LAST_NAME,
                    DES_FAC_ESIG_SIGNATURE_DATE,
                    ORIG_SUBM_TYPE,
                    COI_ONLY,
                    BROKER_ID,
                    LAST_EM_UPDT_DATE,
                    TRANSPORTER_ON_SITE,
                    ALT_FAC_PRINTED_NAME,
                    ALT_FAC_SIGNATURE_DATE,
                    ALT_FAC_ESIG_FIRST_NAME,
                    ALT_FAC_ESIG_LAST_NAME,
                    ALT_FAC_ESIG_SIGNATURE_DATE,
                    ALT_FAC_ID,
                    ALT_FAC_NAME,
                    ALT_FAC_MAIL_STREET_NUM,
                    ALT_FAC_MAIL_CITY,
                    ALT_FAC_MAIL_STA,
                    ALT_FAC_MAIL_ZIP,
                    ALT_FAC_LOC_STREET_NUM,
                    ALT_FAC_LOC_STREET_1,
                    ALT_FAC_LOC_STREET_2,
                    ALT_FAC_LOC_CITY,
                    ALT_FAC_LOC_STA,
                    ALT_FAC_LOC_ZIP,
                    ALT_FAC_CONTACT_FIRST_NAME,
                    ALT_FAC_CONTACT_LAST_NAME,
                    ALT_FAC_CONTACT_PHONE_NO,
                    ALT_FAC_CONTACT_PHONE_EXT,
                    ALT_FAC_CONTACT_EMAIL,
                    ALT_FAC_CONTACT_COMPANY_NAME,
                    ALT_FAC_REGISTERED,
                    ALT_FAC_MODIFIED,
                    FOREIGN_GENERATOR_NAME,
                    FOREIGN_GENERATOR_STREET,
                    FOREIGN_GENERATOR_CITY,
                    FOREIGN_GENERATOR_CTRY_CODE,
                    FOREIGN_GENERATOR_POST_CODE,
                    FOREIGN_GENERATOR_PROVINCE,
                    PORT_OF_ENTRY_STA)
            values (SEQ_RCRA_EM_EMANIFEST.NEXTVAL,
                    S.CREATED_DATE,
                    S.UPDATED_DATE,
                    S.MAN_TRACKING_NUM,
                    S.STATUS,
                    S.DES_FAC_MODIFIED,
                    S.SUBM_TYPE,
                    S.GENERATOR_MODIFIED,
                    S.ORIGIN_TYPE,
                    S.SHIPPED_DATE,
                    S.RECEIVED_DATE,
                    S.CERT_DATE,
                    S.REJ_IND,
                    S.DES_FAC_REGISTERED,
                    S.IMPORT,
                    S.GENERATOR_CONTACT_FIRST_NAME,
                    S.GENERATOR_CONTACT_LAST_NAME,
                    S.GENERATOR_REGISTERED,
                    S.REJECTION_TYPE,
                    S.ALTERNATE_DESIGNATED_FAC_TYPE,
                    S.GENERATOR_NAME,
                    S.DES_FAC_SIGNATURE_DATE,
                    S.GENERATOR_ESIG_SIGNATURE_DATE,
                    S.DES_FAC_LOC_STREET_1,
                    S.ALT_FAC_MAIL_STREET_2,
                    S.DES_FAC_CONTACT_FIRST_NAME,
                    S.DES_FAC_CONTACT_LAST_NAME,
                    S.GENERATOR_LOC_STREET_2,
                    S.GENERATOR_CONTACT_EMAIL,
                    S.DES_FAC_MAIL_STREET_1,
                    S.PORT_OF_ENTRY_CITY,
                    S.GENERATOR_MAIL_ZIP,
                    S.DES_FAC_MAIL_STREET_2,
                    S.GENERATOR_MAIL_STA,
                    S.FOREIGN_GENERATOR_CTRY_NAME,
                    S.GENERATOR_MAIL_CTRY,
                    S.GENERATOR_MAIL_STREET_1,
                    S.GENERATOR_MAIL_STREET_2,
                    S.MANIFEST_HANDLING_INSTR,
                    S.RESIDUE,
                    S.GENERATOR_ID,
                    S.GENERATOR_SIGNATURE_DATE,
                    S.DES_FAC_LOC_STREET_2,
                    S.ALT_FAC_MAIL_STREET_1,
                    S.GENERATOR_ESIG_FIRST_NAME,
                    S.GENERATOR_ESIG_LAST_NAME,
                    S.GENERATOR_LOC_STREET_1,
                    S.GENERATOR_MAIL_STREET_NUM,
                    S.GENERATOR_MAIL_CITY,
                    S.GENERATOR_LOC_STREET_NUM,
                    S.GENERATOR_LOC_CITY,
                    S.GENERATOR_LOC_STA,
                    S.GENERATOR_LOC_ZIP,
                    S.GENERATOR_CONTACT_PHONE_NUM,
                    S.GENERATOR_CONTACT_PHONE_EXT,
                    S.GENERATOR_CONTACT_COMPANY_NAME,
                    S.EMERGENCY_PHONE_NUM,
                    S.EMERGENCY_PHONE_EXT,
                    S.GENERATOR_PRINTED_NAME,
                    S.DES_FAC_ID,
                    S.DES_FAC_NAME,
                    S.DES_FAC_MAIL_STREET_NUM,
                    S.DES_FAC_MAIL_CITY,
                    S.DES_FAC_MAIL_CTRY,
                    S.DES_FAC_MAIL_STA,
                    S.DES_FAC_MAIL_ZIP,
                    S.DES_FAC_LOC_STREET_NUM,
                    S.DES_FAC_LOC_CITY,
                    S.DES_FAC_LOC_STA,
                    S.DES_FAC_LOC_ZIP,
                    S.DES_FAC_CONTACT_PHONE_NUM,
                    S.DES_FAC_CONTACT_PHONE_EXT,
                    S.DES_FAC_CONTACT_EMAIL,
                    S.DES_FAC_CONTACT_COMPANY_NAME,
                    S.DES_FAC_PRINTED_NAME,
                    S.DES_FAC_ESIG_FIRST_NAME,
                    S.DES_FAC_ESIG_LAST_NAME,
                    S.DES_FAC_ESIG_SIGNATURE_DATE,
                    S.ORIG_SUBM_TYPE,
                    S.COI_ONLY,
                    S.BROKER_ID,
                    S.LAST_EM_UPDT_DATE,
                    S.TRANSPORTER_ON_SITE,
                    S.ALT_FAC_PRINTED_NAME,
                    S.ALT_FAC_SIGNATURE_DATE,
                    S.ALT_FAC_ESIG_FIRST_NAME,
                    S.ALT_FAC_ESIG_LAST_NAME,
                    S.ALT_FAC_ESIG_SIGNATURE_DATE,
                    S.ALT_FAC_ID,
                    S.ALT_FAC_NAME,
                    S.ALT_FAC_MAIL_STREET_NUM,
                    S.ALT_FAC_MAIL_CITY,
                    S.ALT_FAC_MAIL_STA,
                    S.ALT_FAC_MAIL_ZIP,
                    S.ALT_FAC_LOC_STREET_NUM,
                    S.ALT_FAC_LOC_STREET_1,
                    S.ALT_FAC_LOC_STREET_2,
                    S.ALT_FAC_LOC_CITY,
                    S.ALT_FAC_LOC_STA,
                    S.ALT_FAC_LOC_ZIP,
                    S.ALT_FAC_CONTACT_FIRST_NAME,
                    S.ALT_FAC_CONTACT_LAST_NAME,
                    S.ALT_FAC_CONTACT_PHONE_NO,
                    S.ALT_FAC_CONTACT_PHONE_EXT,
                    S.ALT_FAC_CONTACT_EMAIL,
                    S.ALT_FAC_CONTACT_COMPANY_NAME,
                    S.ALT_FAC_REGISTERED,
                    S.ALT_FAC_MODIFIED,
                    S.FOREIGN_GENERATOR_NAME,
                    S.FOREIGN_GENERATOR_STREET,
                    S.FOREIGN_GENERATOR_CITY,
                    S.FOREIGN_GENERATOR_CTRY_CODE,
                    S.FOREIGN_GENERATOR_POST_CODE,
                    S.FOREIGN_GENERATOR_PROVINCE,
                    S.PORT_OF_ENTRY_STA);
    END;

    PROCEDURE EM_MERGE_EMANIFEST_COMMENT AS
    BEGIN
        delete
        from RCRA_EM_EMANIFEST_COMMENT
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_EMANIFEST_COMMENT (EM_EMANIFEST_COMMENT_ID, EM_EMANIFEST_ID, CMNT_LABEL, CMNT_DESC)
        select SEQ_RCRA_EM_EMANIFEST_COMMENT.NEXTVAL,
               WH_EM_EMANIFEST_ID,
               CMNT_LABEL,
               CMNT_DESC
        from ETL_EM_EMANIFEST_COMMENT_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE AS
    BEGIN
        delete
        from RCRA_EM_WASTE
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_WASTE (EM_WASTE_ID, EM_EMANIFEST_ID, NON_HAZ_WASTE_DESC, DOT_HAZRD, LINE_NUM,
                                   BR_MIXED_RADIOACTIVE_WASTE, DOT_PRINTED_INFO, CONTAINER_NUM, QNTY_VAL,
                                   QTY_UNIT_OF_MEAS_CODE, QTY_UNIT_OF_MEAS_DESC, BR_DENSITY, BR_DENSITY_UOM_CODE,
                                   BR_DENSITY_UOM_DESC, BR_FORM_CODE, BR_FORM_CODE_DESC, BR_SRC_CODE,
                                   BR_SRC_CODE_DESC, BR_WASTE_MIN_CODE, BR_WASTE_MIN_DESC, QNTY_DISCREPANCY,
                                   WASTE_TYPE_DISCREPANCY, WASTE_RESIDUE_COMM, PCB, MANAGEMENT_METH_CODE,
                                   MANAGEMENT_METH_DESC, HANDLING_INSTRUCTIONS, DOT_ID_NUM_DESC, CONTAINER_TYPE_CODE,
                                   CONTAINER_TYPE_DESC, DISCREPANCY_COMM, WASTE_RESIDUE, CNST_NUM, EPA_WASTE,
                                   COI_ONLY, QNTY_ACUTE_KG, QNTY_ACUTE_TONS, QNTY_KG, QNTY_NON_ACUTE_KG,
                                   QNTY_NON_ACUTE_TONS, QNTY_TONS)
        select SEQ_RCRA_EM_EMANIFEST.NEXTVAL,
               WH_EM_EMANIFEST_ID,
               NON_HAZ_WASTE_DESC,
               DOT_HAZRD,
               LINE_NUM,
               BR_MIXED_RADIOACTIVE_WASTE,
               DOT_PRINTED_INFO,
               CONTAINER_NUM,
               QNTY_VAL,
               QTY_UNIT_OF_MEAS_CODE,
               QTY_UNIT_OF_MEAS_DESC,
               BR_DENSITY,
               BR_DENSITY_UOM_CODE,
               BR_DENSITY_UOM_DESC,
               BR_FORM_CODE,
               BR_FORM_CODE_DESC,
               BR_SRC_CODE,
               BR_SRC_CODE_DESC,
               BR_WASTE_MIN_CODE,
               BR_WASTE_MIN_DESC,
               QNTY_DISCREPANCY,
               WASTE_TYPE_DISCREPANCY,
               WASTE_RESIDUE_COMM,
               PCB,
               MANAGEMENT_METH_CODE,
               MANAGEMENT_METH_DESC,
               HANDLING_INSTRUCTIONS,
               DOT_ID_NUM_DESC,
               CONTAINER_TYPE_CODE,
               CONTAINER_TYPE_DESC,
               DISCREPANCY_COMM,
               WASTE_RESIDUE,
               CNST_NUM,
               EPA_WASTE,
               COI_ONLY,
               QNTY_ACUTE_KG,
               QNTY_ACUTE_TONS,
               QNTY_KG,
               QNTY_NON_ACUTE_KG,
               QNTY_NON_ACUTE_TONS,
               QNTY_TONS
        from ETL_EM_WASTE_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_FED_WASTE_CODE_DESC AS
    BEGIN
        delete
        from RCRA_EM_FED_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_FED_WASTE_CODE_DESC (EM_FED_WASTE_CODE_DESC_ID, EM_WASTE_ID, FED_MANIFEST_WASTE_CODE,
                                                 MANIFEST_WASTE_DESC, COI_IND)
        select SEQ_EM_FED_WASTE_CODE_DESC_ID.nextval,
               WH_EM_WASTE_ID,
               FED_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC,
               COI_IND
        from ETL_EM_FED_WASTE_CODE_DESC_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_STATE_WASTE_CODE_DESC AS
    BEGIN
        delete
        from RCRA_EM_STATE_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_STATE_WASTE_CODE_DESC (EM_STATE_WASTE_CODE_DESC_ID, EM_WASTE_ID, STA_MANIFEST_WASTE_CODE,
                                                   MANIFEST_WASTE_DESC)
        select SEQ_EM_STATE_WASTE_CODE_DESC.nextval,
               WH_EM_WASTE_ID,
               STA_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC
        from ETL_EM_STATE_WASTE_CODE_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_CD_TRANS AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_CD_TRANS
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_CD_TRANS (EM_WASTE_CD_TRANS_ID, EM_WASTE_ID, WASTE_CODE)
        SELECT SEQ_RCRA_EM_WASTE_CD_TRANS.NEXTVAL, WH_EM_WASTE_ID, WASTE_CODE
        FROM ETL_EM_WASTE_CD_TRANS_VW
        WHERE EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_COMMENT AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_COMMENT
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_COMMENT (EM_WASTE_COMMENT_ID, EM_WASTE_ID, CMNT_DESC, CMNT_LABEL)
        SELECT SEQ_RCRA_EM_WASTE_COMMENT.NEXTVAL, WH_EM_WASTE_ID, CMNT_DESC, CMNT_LABEL
        FROM ETL_EM_WASTE_COMMENT_VW
        WHERE EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_PCB AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_PCB
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_PCB (EM_WASTE_PCB_ID, EM_WASTE_ID, PCB_LOAD_TYPE_CODE, PCB_ARTICLE_CONT_ID,
                                       PCB_REMOVAL_DATE,
                                       PCB_WEIGHT, PCB_WASTE_TYPE, PCB_BULK_IDENTITY, LOAD_TYPE_DESC)
        SELECT SEQ_RCRA_EM_WASTE_PCB.NEXTVAL,
               WH_EM_WASTE_ID,
               PCB_LOAD_TYPE_CODE,
               PCB_ARTICLE_CONT_ID,
               PCB_REMOVAL_DATE,
               PCB_WEIGHT,
               PCB_WASTE_TYPE,
               PCB_BULK_IDENTITY,
               LOAD_TYPE_DESC
        FROM ETL_EM_WASTE_PCB_VW
        WHERE EM_WASTE_ID IN (select x.EM_WASTE_ID
                              from ETL_EM_WASTE_VW x
                              where x.EM_WASTE_ID is not null);
    END;

    PROCEDURE EM_MERGE_TRANSPORTER AS
    BEGIN
        delete
        from RCRA_EM_TRANSPORTER
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_TRANSPORTER (EM_TRANSPORTER_ID, EM_EMANIFEST_ID, TRANSPORTER_ID, TRANSPORTER_NAME,
                                         TRANSPORTER_PRINTED_NAME,
                                         TRANSPORTER_SIGNATURE_DATE, TRANSPORTER_ESIG_FIRST_NAME,
                                         TRANSPORTER_ESIG_LAST_NAME, TRANS_ESIG_SIGNATURE_DATE, TRANSPORTER_LINE_NUM,
                                         TRANSPORTER_REGISTERED)
        select SEQ_RCRA_EM_TRANSPORTER.nextval,
               WH_EM_EMANIFEST_ID,
               TRANSPORTER_ID,
               TRANSPORTER_NAME,
               TRANSPORTER_PRINTED_NAME,
               TRANSPORTER_SIGNATURE_DATE,
               TRANSPORTER_ESIG_FIRST_NAME,
               TRANSPORTER_ESIG_LAST_NAME,
               TRANS_ESIG_SIGNATURE_DATE,
               TRANSPORTER_LINE_NUM,
               TRANSPORTER_REGISTERED
        from ETL_EM_TRANSPORTER_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

-- CH

    PROCEDURE CH_LOG_HANDLER AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CH');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       RU_REPORT_UNIV_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_RU_REPORT_UNIV_VW;
    END;

    PROCEDURE CH_MERGE_REPORT_UNIV AS
    BEGIN
        MERGE INTO RCRA_RU_REPORT_UNIV D
        USING (SELECT *
               FROM ETL_RU_REPORT_UNIV_VW) S
        ON (D.RU_REPORT_UNIV_ID = S.WH_RU_REPORT_UNIV_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.HANDLER_ID                     = S.HANDLER_ID,
                D.ACTIVITY_LOCATION              = S.ACTIVITY_LOCATION,
                D.SOURCE_TYPE                    = S.SOURCE_TYPE,
                D.SEQ_NUMBER                     = S.SEQ_NUMBER,
                D.RECEIVE_DATE                   = S.RECEIVE_DATE,
                D.HANDLER_NAME                   = S.HANDLER_NAME,
                D.NON_NOTIFIER_IND               = S.NON_NOTIFIER_IND,
                D.ACCESSIBILITY                  = S.ACCESSIBILITY,
                D.REPORT_CYCLE                   = S.REPORT_CYCLE,
                D.REGION                         = S.REGION,
                D.STATE                          = S.STATE,
                D.EXTRACT_FLAG                   = S.EXTRACT_FLAG,
                D.ACTIVE_SITE                    = S.ACTIVE_SITE,
                D.COUNTY_CODE                    = S.COUNTY_CODE,
                D.COUNTY_NAME                    = S.COUNTY_NAME,
                D.LOCATION_STREET_NUMBER         = S.LOCATION_STREET_NUMBER,
                D.LOCATION_STREET1               = S.LOCATION_STREET1,
                D.LOCATION_STREET2               = S.LOCATION_STREET2,
                D.LOCATION_CITY                  = S.LOCATION_CITY,
                D.LOCATION_STATE                 = S.LOCATION_STATE,
                D.LOCATION_COUNTRY               = S.LOCATION_COUNTRY,
                D.LOCATION_ZIP                   = S.LOCATION_ZIP,
                D.MAIL_STREET_NUMBER             = S.MAIL_STREET_NUMBER,
                D.MAIL_STREET1                   = S.MAIL_STREET1,
                D.MAIL_STREET2                   = S.MAIL_STREET2,
                D.MAIL_CITY                      = S.MAIL_CITY,
                D.MAIL_STATE                     = S.MAIL_STATE,
                D.MAIL_COUNTRY                   = S.MAIL_COUNTRY,
                D.MAIL_ZIP                       = S.MAIL_ZIP,
                D.CONTACT_STREET_NUMBER          = S.CONTACT_STREET_NUMBER,
                D.CONTACT_STREET1                = S.CONTACT_STREET1,
                D.CONTACT_STREET2                = S.CONTACT_STREET2,
                D.CONTACT_CITY                   = S.CONTACT_CITY,
                D.CONTACT_STATE                  = S.CONTACT_STATE,
                D.CONTACT_COUNTRY                = S.CONTACT_COUNTRY,
                D.CONTACT_ZIP                    = S.CONTACT_ZIP,
                D.CONTACT_NAME                   = S.CONTACT_NAME,
                D.CONTACT_PHONE                  = S.CONTACT_PHONE,
                D.CONTACT_FAX                    = S.CONTACT_FAX,
                D.CONTACT_EMAIL                  = S.CONTACT_EMAIL,
                D.CONTACT_TITLE                  = S.CONTACT_TITLE,
                D.OWNER_NAME                     = S.OWNER_NAME,
                D.OWNER_TYPE                     = S.OWNER_TYPE,
                D.OWNER_SEQ_NUM                  = S.OWNER_SEQ_NUM,
                D.OPER_NAME                      = S.OPER_NAME,
                D.OPER_TYPE                      = S.OPER_TYPE,
                D.OPER_SEQ_NUM                   = S.OPER_SEQ_NUM,
                D.NAIC1_CODE                     = S.NAIC1_CODE,
                D.NAIC2_CODE                     = S.NAIC2_CODE,
                D.NAIC3_CODE                     = S.NAIC3_CODE,
                D.NAIC4_CODE                     = S.NAIC4_CODE,
                D.IN_HANDLER_UNIVERSE            = S.IN_HANDLER_UNIVERSE,
                D.IN_A_UNIVERSE                  = S.IN_A_UNIVERSE,
                D.FED_WASTE_GENERATOR_OWNER      = S.FED_WASTE_GENERATOR_OWNER,
                D.FED_WASTE_GENERATOR            = S.FED_WASTE_GENERATOR,
                D.STATE_WASTE_GENERATOR_OWNER    = S.STATE_WASTE_GENERATOR_OWNER,
                D.STATE_WASTE_GENERATOR          = S.STATE_WASTE_GENERATOR,
                D.GEN_STATUS                     = S.GEN_STATUS,
                D.UNIV_WASTE                     = S.UNIV_WASTE,
                D.LAND_TYPE                      = S.LAND_TYPE,
                D.STATE_DISTRICT_OWNER           = S.STATE_DISTRICT_OWNER,
                D.STATE_DISTRICT                 = S.STATE_DISTRICT,
                D.SHORT_TERM_GEN_IND             = S.SHORT_TERM_GEN_IND,
                D.IMPORTER_ACTIVITY              = S.IMPORTER_ACTIVITY,
                D.MIXED_WASTE_GENERATOR          = S.MIXED_WASTE_GENERATOR,
                D.TRANSPORTER_ACTIVITY           = S.TRANSPORTER_ACTIVITY,
                D.TRANSFER_FACILITY_IND          = S.TRANSFER_FACILITY_IND,
                D.RECYCLER_ACTIVITY              = S.RECYCLER_ACTIVITY,
                D.ONSITE_BURNER_EXEMPTION        = S.ONSITE_BURNER_EXEMPTION,
                D.FURNACE_EXEMPTION              = S.FURNACE_EXEMPTION,
                D.UNDERGROUND_INJECTION_ACTIVITY = S.UNDERGROUND_INJECTION_ACTIVITY,
                D.UNIVERSAL_WASTE_DEST_FACILITY  = S.UNIVERSAL_WASTE_DEST_FACILITY,
                D.OFFSITE_WASTE_RECEIPT          = S.OFFSITE_WASTE_RECEIPT,
                D.USED_OIL                       = S.USED_OIL,
                D.FEDERAL_UNIVERSAL_WASTE        = S.FEDERAL_UNIVERSAL_WASTE,
                D.AS_FEDERAL_REGULATED_TSDF      = S.AS_FEDERAL_REGULATED_TSDF,
                D.AS_CONVERTED_TSDF              = S.AS_CONVERTED_TSDF,
                D.AS_STATE_REGULATED_TSDF        = S.AS_STATE_REGULATED_TSDF,
                D.FEDERAL_IND                    = S.FEDERAL_IND,
                D.HSM                            = S.HSM,
                D.SUBPART_K                      = S.SUBPART_K,
                D.COMMERCIAL_TSD                 = S.COMMERCIAL_TSD,
                D.TSD                            = S.TSD,
                D.GPRA_PERMIT                    = S.GPRA_PERMIT,
                D.GPRA_RENEWAL                   = S.GPRA_RENEWAL,
                D.PERMIT_RENEWAL_WRKLD           = S.PERMIT_RENEWAL_WRKLD,
                D.PERM_WRKLD                     = S.PERM_WRKLD,
                D.PERM_PROG                      = S.PERM_PROG,
                D.PC_WRKLD                       = S.PC_WRKLD,
                D.CLOS_WRKLD                     = S.CLOS_WRKLD,
                D.GPRACA                         = S.GPRACA,
                D.CA_WRKLD                       = S.CA_WRKLD,
                D.SUBJ_CA                        = S.SUBJ_CA,
                D.SUBJ_CA_NON_TSD                = S.SUBJ_CA_NON_TSD,
                D.SUBJ_CA_TSD_3004               = S.SUBJ_CA_TSD_3004,
                D.SUBJ_CA_DISCRETION             = S.SUBJ_CA_DISCRETION,
                D.NCAPS                          = S.NCAPS,
                D.EC_IND                         = S.EC_IND,
                D.IC_IND                         = S.IC_IND,
                D.CA_725_IND                     = S.CA_725_IND,
                D.CA_750_IND                     = S.CA_750_IND,
                D.OPERATING_TSDF                 = S.OPERATING_TSDF,
                D.FULL_ENFORCEMENT               = S.FULL_ENFORCEMENT,
                D.SNC                            = S.SNC,
                D.BOY_SNC                        = S.BOY_SNC,
                D.BOY_STATE_UNADDRESSED_SNC      = S.BOY_STATE_UNADDRESSED_SNC,
                D.STATE_UNADDRESSED              = S.STATE_UNADDRESSED,
                D.STATE_ADDRESSED                = S.STATE_ADDRESSED,
                D.BOY_STATE_ADDRESSED            = S.BOY_STATE_ADDRESSED,
                D.STATE_SNC_WITH_COMP_SCHED      = S.STATE_SNC_WITH_COMP_SCHED,
                D.BOY_STATE_SNC_WITH_COMP_SCHED  = S.BOY_STATE_SNC_WITH_COMP_SCHED,
                D.EPA_UNADDRESSED                = S.EPA_UNADDRESSED,
                D.BOY_EPA_UNADDRESSED            = S.BOY_EPA_UNADDRESSED,
                D.EPA_ADDRESSED                  = S.EPA_ADDRESSED,
                D.BOY_EPA_ADDRESSED              = S.BOY_EPA_ADDRESSED,
                D.EPA_SNC_WITH_COMP_SCHED        = S.EPA_SNC_WITH_COMP_SCHED,
                D.BOY_EPA_SNC_WITH_COMP_SCHED    = S.BOY_EPA_SNC_WITH_COMP_SCHED,
                D.FA_REQUIRED                    = S.FA_REQUIRED,
                D.HHANDLER_LAST_CHANGE_DATE      = S.HHANDLER_LAST_CHANGE_DATE,
                D.PUBLIC_NOTES                   = S.PUBLIC_NOTES,
                D.NOTES                          = S.NOTES,
                D.RECOGNIZED_TRADER_IMPORTER_IND = S.RECOGNIZED_TRADER_IMPORTER_IND,
                D.RECOGNIZED_TRADER_EXPORTER_IND = S.RECOGNIZED_TRADER_EXPORTER_IND,
                D.SLAB_IMPORTER_IND              = S.SLAB_IMPORTER_IND,
                D.SLAB_EXPORTER_IND              = S.SLAB_EXPORTER_IND,
                D.RECYCLER_NON_STORAGE_IND       = S.RECYCLER_NON_STORAGE_IND,
                D.MANIFEST_BROKER_IND            = S.MANIFEST_BROKER_IND,
                D.SUBPART_P_IND                  = S.SUBPART_P_IND,
                D.LOCATION_LATITUDE              = S.LOCATION_LATITUDE,
                D.LOCATION_LONGITUDE             = S.LOCATION_LONGITUDE,
                D.LOCATION_GIS_PRIM              = S.LOCATION_GIS_PRIM,
                D.LOCATION_GIS_ORIG              = S.LOCATION_GIS_ORIG
            WHERE DECODE(D.RU_REPORT_UNIV_ID, S.RU_REPORT_UNIV_ID, 0, 1) = 1
               OR DECODE(D.HANDLER_ID, S.HANDLER_ID, 0, 1) = 1
               OR DECODE(D.ACTIVITY_LOCATION, S.ACTIVITY_LOCATION, 0, 1) = 1
               OR DECODE(D.SOURCE_TYPE, S.SOURCE_TYPE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.RECEIVE_DATE, S.RECEIVE_DATE, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER_IND, S.NON_NOTIFIER_IND, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY, S.ACCESSIBILITY, 0, 1) = 1
               OR DECODE(D.REPORT_CYCLE, S.REPORT_CYCLE, 0, 1) = 1
               OR DECODE(D.REGION, S.REGION, 0, 1) = 1
               OR DECODE(D.STATE, S.STATE, 0, 1) = 1
               OR DECODE(D.EXTRACT_FLAG, S.EXTRACT_FLAG, 0, 1) = 1
               OR DECODE(D.ACTIVE_SITE, S.ACTIVE_SITE, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE, S.COUNTY_CODE, 0, 1) = 1
               OR DECODE(D.COUNTY_NAME, S.COUNTY_NAME, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET_NUMBER, S.LOCATION_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET1, S.LOCATION_STREET1, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET2, S.LOCATION_STREET2, 0, 1) = 1
               OR DECODE(D.LOCATION_CITY, S.LOCATION_CITY, 0, 1) = 1
               OR DECODE(D.LOCATION_STATE, S.LOCATION_STATE, 0, 1) = 1
               OR DECODE(D.LOCATION_COUNTRY, S.LOCATION_COUNTRY, 0, 1) = 1
               OR DECODE(D.LOCATION_ZIP, S.LOCATION_ZIP, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_COUNTRY, S.MAIL_COUNTRY, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET_NUMBER, S.CONTACT_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET1, S.CONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET2, S.CONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.CONTACT_CITY, S.CONTACT_CITY, 0, 1) = 1
               OR DECODE(D.CONTACT_STATE, S.CONTACT_STATE, 0, 1) = 1
               OR DECODE(D.CONTACT_COUNTRY, S.CONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.CONTACT_ZIP, S.CONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_NAME, S.CONTACT_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL, S.CONTACT_EMAIL, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.OWNER_NAME, S.OWNER_NAME, 0, 1) = 1
               OR DECODE(D.OWNER_TYPE, S.OWNER_TYPE, 0, 1) = 1
               OR DECODE(D.OWNER_SEQ_NUM, S.OWNER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.OPER_NAME, S.OPER_NAME, 0, 1) = 1
               OR DECODE(D.OPER_TYPE, S.OPER_TYPE, 0, 1) = 1
               OR DECODE(D.OPER_SEQ_NUM, S.OPER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.NAIC1_CODE, S.NAIC1_CODE, 0, 1) = 1
               OR DECODE(D.NAIC2_CODE, S.NAIC2_CODE, 0, 1) = 1
               OR DECODE(D.NAIC3_CODE, S.NAIC3_CODE, 0, 1) = 1
               OR DECODE(D.NAIC4_CODE, S.NAIC4_CODE, 0, 1) = 1
               OR DECODE(D.IN_HANDLER_UNIVERSE, S.IN_HANDLER_UNIVERSE, 0, 1) = 1
               OR DECODE(D.IN_A_UNIVERSE, S.IN_A_UNIVERSE, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR_OWNER, S.FED_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR, S.FED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR_OWNER, S.STATE_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR, S.STATE_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.GEN_STATUS, S.GEN_STATUS, 0, 1) = 1
               OR DECODE(D.UNIV_WASTE, S.UNIV_WASTE, 0, 1) = 1
               OR DECODE(D.LAND_TYPE, S.LAND_TYPE, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_OWNER, S.STATE_DISTRICT_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT, S.STATE_DISTRICT, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_GEN_IND, S.SHORT_TERM_GEN_IND, 0, 1) = 1
               OR DECODE(D.IMPORTER_ACTIVITY, S.IMPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.MIXED_WASTE_GENERATOR, S.MIXED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.TRANSPORTER_ACTIVITY, S.TRANSPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TRANSFER_FACILITY_IND, S.TRANSFER_FACILITY_IND, 0, 1) = 1
               OR DECODE(D.RECYCLER_ACTIVITY, S.RECYCLER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.ONSITE_BURNER_EXEMPTION, S.ONSITE_BURNER_EXEMPTION, 0, 1) = 1
               OR DECODE(D.FURNACE_EXEMPTION, S.FURNACE_EXEMPTION, 0, 1) = 1
               OR DECODE(D.UNDERGROUND_INJECTION_ACTIVITY, S.UNDERGROUND_INJECTION_ACTIVITY, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_DEST_FACILITY, S.UNIVERSAL_WASTE_DEST_FACILITY, 0, 1) = 1
               OR DECODE(D.OFFSITE_WASTE_RECEIPT, S.OFFSITE_WASTE_RECEIPT, 0, 1) = 1
               OR DECODE(D.USED_OIL, S.USED_OIL, 0, 1) = 1
               OR DECODE(D.FEDERAL_UNIVERSAL_WASTE, S.FEDERAL_UNIVERSAL_WASTE, 0, 1) = 1
               OR DECODE(D.AS_FEDERAL_REGULATED_TSDF, S.AS_FEDERAL_REGULATED_TSDF, 0, 1) = 1
               OR DECODE(D.AS_CONVERTED_TSDF, S.AS_CONVERTED_TSDF, 0, 1) = 1
               OR DECODE(D.AS_STATE_REGULATED_TSDF, S.AS_STATE_REGULATED_TSDF, 0, 1) = 1
               OR DECODE(D.FEDERAL_IND, S.FEDERAL_IND, 0, 1) = 1
               OR DECODE(D.HSM, S.HSM, 0, 1) = 1
               OR DECODE(D.SUBPART_K, S.SUBPART_K, 0, 1) = 1
               OR DECODE(D.COMMERCIAL_TSD, S.COMMERCIAL_TSD, 0, 1) = 1
               OR DECODE(D.TSD, S.TSD, 0, 1) = 1
               OR DECODE(D.GPRA_PERMIT, S.GPRA_PERMIT, 0, 1) = 1
               OR DECODE(D.GPRA_RENEWAL, S.GPRA_RENEWAL, 0, 1) = 1
               OR DECODE(D.PERMIT_RENEWAL_WRKLD, S.PERMIT_RENEWAL_WRKLD, 0, 1) = 1
               OR DECODE(D.PERM_WRKLD, S.PERM_WRKLD, 0, 1) = 1
               OR DECODE(D.PERM_PROG, S.PERM_PROG, 0, 1) = 1
               OR DECODE(D.PC_WRKLD, S.PC_WRKLD, 0, 1) = 1
               OR DECODE(D.CLOS_WRKLD, S.CLOS_WRKLD, 0, 1) = 1
               OR DECODE(D.GPRACA, S.GPRACA, 0, 1) = 1
               OR DECODE(D.CA_WRKLD, S.CA_WRKLD, 0, 1) = 1
               OR DECODE(D.SUBJ_CA, S.SUBJ_CA, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_NON_TSD, S.SUBJ_CA_NON_TSD, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_TSD_3004, S.SUBJ_CA_TSD_3004, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_DISCRETION, S.SUBJ_CA_DISCRETION, 0, 1) = 1
               OR DECODE(D.NCAPS, S.NCAPS, 0, 1) = 1
               OR DECODE(D.EC_IND, S.EC_IND, 0, 1) = 1
               OR DECODE(D.IC_IND, S.IC_IND, 0, 1) = 1
               OR DECODE(D.CA_725_IND, S.CA_725_IND, 0, 1) = 1
               OR DECODE(D.CA_750_IND, S.CA_750_IND, 0, 1) = 1
               OR DECODE(D.OPERATING_TSDF, S.OPERATING_TSDF, 0, 1) = 1
               OR DECODE(D.FULL_ENFORCEMENT, S.FULL_ENFORCEMENT, 0, 1) = 1
               OR DECODE(D.SNC, S.SNC, 0, 1) = 1
               OR DECODE(D.BOY_SNC, S.BOY_SNC, 0, 1) = 1
               OR DECODE(D.BOY_STATE_UNADDRESSED_SNC, S.BOY_STATE_UNADDRESSED_SNC, 0, 1) = 1
               OR DECODE(D.STATE_UNADDRESSED, S.STATE_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.STATE_ADDRESSED, S.STATE_ADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_STATE_ADDRESSED, S.BOY_STATE_ADDRESSED, 0, 1) = 1
               OR DECODE(D.STATE_SNC_WITH_COMP_SCHED, S.STATE_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.BOY_STATE_SNC_WITH_COMP_SCHED, S.BOY_STATE_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.EPA_UNADDRESSED, S.EPA_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_UNADDRESSED, S.BOY_EPA_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.EPA_ADDRESSED, S.EPA_ADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_ADDRESSED, S.BOY_EPA_ADDRESSED, 0, 1) = 1
               OR DECODE(D.EPA_SNC_WITH_COMP_SCHED, S.EPA_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_SNC_WITH_COMP_SCHED, S.BOY_EPA_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.FA_REQUIRED, S.FA_REQUIRED, 0, 1) = 1
               OR DECODE(D.HHANDLER_LAST_CHANGE_DATE, S.HHANDLER_LAST_CHANGE_DATE, 0, 1) = 1
               OR DECODE(D.PUBLIC_NOTES, S.PUBLIC_NOTES, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_IMPORTER_IND, S.RECOGNIZED_TRADER_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_EXPORTER_IND, S.RECOGNIZED_TRADER_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_IMPORTER_IND, S.SLAB_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_EXPORTER_IND, S.SLAB_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECYCLER_NON_STORAGE_IND, S.RECYCLER_NON_STORAGE_IND, 0, 1) = 1
               OR DECODE(D.MANIFEST_BROKER_IND, S.MANIFEST_BROKER_IND, 0, 1) = 1
               OR DECODE(D.SUBPART_P_IND, S.SUBPART_P_IND, 0, 1) = 1
               OR DECODE(D.LOCATION_LATITUDE, S.LOCATION_LATITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_LONGITUDE, S.LOCATION_LONGITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_PRIM, S.LOCATION_GIS_PRIM, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_ORIG, S.LOCATION_GIS_ORIG, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (RU_REPORT_UNIV_ID,
                    HANDLER_ID,
                    ACTIVITY_LOCATION,
                    SOURCE_TYPE,
                    SEQ_NUMBER,
                    RECEIVE_DATE,
                    HANDLER_NAME,
                    NON_NOTIFIER_IND,
                    ACCESSIBILITY,
                    REPORT_CYCLE,
                    REGION,
                    STATE,
                    EXTRACT_FLAG,
                    ACTIVE_SITE,
                    COUNTY_CODE,
                    COUNTY_NAME,
                    LOCATION_STREET_NUMBER,
                    LOCATION_STREET1,
                    LOCATION_STREET2,
                    LOCATION_CITY,
                    LOCATION_STATE,
                    LOCATION_COUNTRY,
                    LOCATION_ZIP,
                    MAIL_STREET_NUMBER,
                    MAIL_STREET1,
                    MAIL_STREET2,
                    MAIL_CITY,
                    MAIL_STATE,
                    MAIL_COUNTRY,
                    MAIL_ZIP,
                    CONTACT_STREET_NUMBER,
                    CONTACT_STREET1,
                    CONTACT_STREET2,
                    CONTACT_CITY,
                    CONTACT_STATE,
                    CONTACT_COUNTRY,
                    CONTACT_ZIP,
                    CONTACT_NAME,
                    CONTACT_PHONE,
                    CONTACT_FAX,
                    CONTACT_EMAIL,
                    CONTACT_TITLE,
                    OWNER_NAME,
                    OWNER_TYPE,
                    OWNER_SEQ_NUM,
                    OPER_NAME,
                    OPER_TYPE,
                    OPER_SEQ_NUM,
                    NAIC1_CODE,
                    NAIC2_CODE,
                    NAIC3_CODE,
                    NAIC4_CODE,
                    IN_HANDLER_UNIVERSE,
                    IN_A_UNIVERSE,
                    FED_WASTE_GENERATOR_OWNER,
                    FED_WASTE_GENERATOR,
                    STATE_WASTE_GENERATOR_OWNER,
                    STATE_WASTE_GENERATOR,
                    GEN_STATUS,
                    UNIV_WASTE,
                    LAND_TYPE,
                    STATE_DISTRICT_OWNER,
                    STATE_DISTRICT,
                    SHORT_TERM_GEN_IND,
                    IMPORTER_ACTIVITY,
                    MIXED_WASTE_GENERATOR,
                    TRANSPORTER_ACTIVITY,
                    TRANSFER_FACILITY_IND,
                    RECYCLER_ACTIVITY,
                    ONSITE_BURNER_EXEMPTION,
                    FURNACE_EXEMPTION,
                    UNDERGROUND_INJECTION_ACTIVITY,
                    UNIVERSAL_WASTE_DEST_FACILITY,
                    OFFSITE_WASTE_RECEIPT,
                    USED_OIL,
                    FEDERAL_UNIVERSAL_WASTE,
                    AS_FEDERAL_REGULATED_TSDF,
                    AS_CONVERTED_TSDF,
                    AS_STATE_REGULATED_TSDF,
                    FEDERAL_IND,
                    HSM,
                    SUBPART_K,
                    COMMERCIAL_TSD,
                    TSD,
                    GPRA_PERMIT,
                    GPRA_RENEWAL,
                    PERMIT_RENEWAL_WRKLD,
                    PERM_WRKLD,
                    PERM_PROG,
                    PC_WRKLD,
                    CLOS_WRKLD,
                    GPRACA,
                    CA_WRKLD,
                    SUBJ_CA,
                    SUBJ_CA_NON_TSD,
                    SUBJ_CA_TSD_3004,
                    SUBJ_CA_DISCRETION,
                    NCAPS,
                    EC_IND,
                    IC_IND,
                    CA_725_IND,
                    CA_750_IND,
                    OPERATING_TSDF,
                    FULL_ENFORCEMENT,
                    SNC,
                    BOY_SNC,
                    BOY_STATE_UNADDRESSED_SNC,
                    STATE_UNADDRESSED,
                    STATE_ADDRESSED,
                    BOY_STATE_ADDRESSED,
                    STATE_SNC_WITH_COMP_SCHED,
                    BOY_STATE_SNC_WITH_COMP_SCHED,
                    EPA_UNADDRESSED,
                    BOY_EPA_UNADDRESSED,
                    EPA_ADDRESSED,
                    BOY_EPA_ADDRESSED,
                    EPA_SNC_WITH_COMP_SCHED,
                    BOY_EPA_SNC_WITH_COMP_SCHED,
                    FA_REQUIRED,
                    HHANDLER_LAST_CHANGE_DATE,
                    PUBLIC_NOTES,
                    NOTES,
                    RECOGNIZED_TRADER_IMPORTER_IND,
                    RECOGNIZED_TRADER_EXPORTER_IND,
                    SLAB_IMPORTER_IND,
                    SLAB_EXPORTER_IND,
                    RECYCLER_NON_STORAGE_IND,
                    MANIFEST_BROKER_IND,
                    SUBPART_P_IND,
                    LOCATION_LATITUDE,
                    LOCATION_LONGITUDE,
                    LOCATION_GIS_PRIM,
                    LOCATION_GIS_ORIG)
            VALUES (SEQ_RCRA_GIS_GEO_INFORMATION.NEXTVAL,
                    S.HANDLER_ID,
                    S.ACTIVITY_LOCATION,
                    S.SOURCE_TYPE,
                    S.SEQ_NUMBER,
                    S.RECEIVE_DATE,
                    S.HANDLER_NAME,
                    S.NON_NOTIFIER_IND,
                    S.ACCESSIBILITY,
                    S.REPORT_CYCLE,
                    S.REGION,
                    S.STATE,
                    S.EXTRACT_FLAG,
                    S.ACTIVE_SITE,
                    S.COUNTY_CODE,
                    S.COUNTY_NAME,
                    S.LOCATION_STREET_NUMBER,
                    S.LOCATION_STREET1,
                    S.LOCATION_STREET2,
                    S.LOCATION_CITY,
                    S.LOCATION_STATE,
                    S.LOCATION_COUNTRY,
                    S.LOCATION_ZIP,
                    S.MAIL_STREET_NUMBER,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_STREET_NUMBER,
                    S.CONTACT_STREET1,
                    S.CONTACT_STREET2,
                    S.CONTACT_CITY,
                    S.CONTACT_STATE,
                    S.CONTACT_COUNTRY,
                    S.CONTACT_ZIP,
                    S.CONTACT_NAME,
                    S.CONTACT_PHONE,
                    S.CONTACT_FAX,
                    S.CONTACT_EMAIL,
                    S.CONTACT_TITLE,
                    S.OWNER_NAME,
                    S.OWNER_TYPE,
                    S.OWNER_SEQ_NUM,
                    S.OPER_NAME,
                    S.OPER_TYPE,
                    S.OPER_SEQ_NUM,
                    S.NAIC1_CODE,
                    S.NAIC2_CODE,
                    S.NAIC3_CODE,
                    S.NAIC4_CODE,
                    S.IN_HANDLER_UNIVERSE,
                    S.IN_A_UNIVERSE,
                    S.FED_WASTE_GENERATOR_OWNER,
                    S.FED_WASTE_GENERATOR,
                    S.STATE_WASTE_GENERATOR_OWNER,
                    S.STATE_WASTE_GENERATOR,
                    S.GEN_STATUS,
                    S.UNIV_WASTE,
                    S.LAND_TYPE,
                    S.STATE_DISTRICT_OWNER,
                    S.STATE_DISTRICT,
                    S.SHORT_TERM_GEN_IND,
                    S.IMPORTER_ACTIVITY,
                    S.MIXED_WASTE_GENERATOR,
                    S.TRANSPORTER_ACTIVITY,
                    S.TRANSFER_FACILITY_IND,
                    S.RECYCLER_ACTIVITY,
                    S.ONSITE_BURNER_EXEMPTION,
                    S.FURNACE_EXEMPTION,
                    S.UNDERGROUND_INJECTION_ACTIVITY,
                    S.UNIVERSAL_WASTE_DEST_FACILITY,
                    S.OFFSITE_WASTE_RECEIPT,
                    S.USED_OIL,
                    S.FEDERAL_UNIVERSAL_WASTE,
                    S.AS_FEDERAL_REGULATED_TSDF,
                    S.AS_CONVERTED_TSDF,
                    S.AS_STATE_REGULATED_TSDF,
                    S.FEDERAL_IND,
                    S.HSM,
                    S.SUBPART_K,
                    S.COMMERCIAL_TSD,
                    S.TSD,
                    S.GPRA_PERMIT,
                    S.GPRA_RENEWAL,
                    S.PERMIT_RENEWAL_WRKLD,
                    S.PERM_WRKLD,
                    S.PERM_PROG,
                    S.PC_WRKLD,
                    S.CLOS_WRKLD,
                    S.GPRACA,
                    S.CA_WRKLD,
                    S.SUBJ_CA,
                    S.SUBJ_CA_NON_TSD,
                    S.SUBJ_CA_TSD_3004,
                    S.SUBJ_CA_DISCRETION,
                    S.NCAPS,
                    S.EC_IND,
                    S.IC_IND,
                    S.CA_725_IND,
                    S.CA_750_IND,
                    S.OPERATING_TSDF,
                    S.FULL_ENFORCEMENT,
                    S.SNC,
                    S.BOY_SNC,
                    S.BOY_STATE_UNADDRESSED_SNC,
                    S.STATE_UNADDRESSED,
                    S.STATE_ADDRESSED,
                    S.BOY_STATE_ADDRESSED,
                    S.STATE_SNC_WITH_COMP_SCHED,
                    S.BOY_STATE_SNC_WITH_COMP_SCHED,
                    S.EPA_UNADDRESSED,
                    S.BOY_EPA_UNADDRESSED,
                    S.EPA_ADDRESSED,
                    S.BOY_EPA_ADDRESSED,
                    S.EPA_SNC_WITH_COMP_SCHED,
                    S.BOY_EPA_SNC_WITH_COMP_SCHED,
                    S.FA_REQUIRED,
                    S.HHANDLER_LAST_CHANGE_DATE,
                    S.PUBLIC_NOTES,
                    S.NOTES,
                    S.RECOGNIZED_TRADER_IMPORTER_IND,
                    S.RECOGNIZED_TRADER_EXPORTER_IND,
                    S.SLAB_IMPORTER_IND,
                    S.SLAB_EXPORTER_IND,
                    S.RECYCLER_NON_STORAGE_IND,
                    S.MANIFEST_BROKER_IND,
                    S.SUBPART_P_IND,
                    S.LOCATION_LATITUDE,
                    S.LOCATION_LONGITUDE,
                    S.LOCATION_GIS_PRIM,
                    S.LOCATION_GIS_ORIG);
    END;

-- GIS

    PROCEDURE GIS_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'GS');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       GIS_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_GIS_FAC_SUBM_VW;
    END;

    PROCEDURE GIS_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_GIS_FAC_SUBM D
        USING (SELECT *
               FROM ETL_GIS_FAC_SUBM_VW) S
        ON (D.GIS_FAC_SUBM_ID = S.WH_GIS_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (GIS_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_GIS_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

    PROCEDURE GIS_MERGE_RCRA_GIS_GEO_INFO AS
    BEGIN
        MERGE INTO RCRA_GIS_GEO_INFORMATION D
        USING (SELECT *
               FROM ETL_GIS_GEO_INFORMATION_VW) S
        ON (D.GIS_GEO_INFORMATION_ID = S.WH_GIS_GEO_INFORMATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.GEO_INFO_OWNER                 = S.GEO_INFO_OWNER,
                D.GEO_INFO_SEQ_NUM               = S.GEO_INFO_SEQ_NUM,
                D.PERMIT_UNIT_SEQ_NUM            = S.PERMIT_UNIT_SEQ_NUM,
                D.AREA_SEQ_NUM                   = S.AREA_SEQ_NUM,
                D.LOC_COMM_TXT                   = S.LOC_COMM_TXT,
                D.AREA_ACREAGE_MEAS              = S.AREA_ACREAGE_MEAS,
                D.AREA_MEAS_SRC_DATA_OWNER_CODE  = S.AREA_MEAS_SRC_DATA_OWNER_CODE,
                D.AREA_MEAS_SRC_CODE             = S.AREA_MEAS_SRC_CODE,
                D.AREA_MEAS_DATE                 = S.AREA_MEAS_DATE,
                D.DATA_COLL_DATE                 = S.DATA_COLL_DATE,
                D.HORZ_ACC_MEAS                  = S.HORZ_ACC_MEAS,
                D.SRC_MAP_SCALE_NUM              = S.SRC_MAP_SCALE_NUM,
                D.COORD_DATA_SRC_DATA_OWNER_CODE = S.COORD_DATA_SRC_DATA_OWNER_CODE,
                D.COORD_DATA_SRC_CODE            = S.COORD_DATA_SRC_CODE,
                D.GEO_REF_PT_DATA_OWNER_CODE     = S.GEO_REF_PT_DATA_OWNER_CODE,
                D.GEO_REF_PT_CODE                = S.GEO_REF_PT_CODE,
                D.GEOM_TYPE_DATA_OWNER_CODE      = S.GEOM_TYPE_DATA_OWNER_CODE,
                D.GEOM_TYPE_CODE                 = S.GEOM_TYPE_CODE,
                D.HORZ_COLL_METH_DATA_OWNER_CODE = S.HORZ_COLL_METH_DATA_OWNER_CODE,
                D.HORZ_COLL_METH_CODE            = S.HORZ_COLL_METH_CODE,
                D.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE = S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                D.HORZ_COORD_REF_SYS_DATUM_CODE  = S.HORZ_COORD_REF_SYS_DATUM_CODE,
                D.VERF_METH_DATA_OWNER_CODE      = S.VERF_METH_DATA_OWNER_CODE,
                D.VERF_METH_CODE                 = S.VERF_METH_CODE,
                D.LATITUDE                       = S.LATITUDE,
                D.LONGITUDE                      = S.LONGITUDE,
                D.ELEVATION                      = S.ELEVATION,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.G_CREATED_DATE                 = S.G_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.GEO_INFO_OWNER, S.GEO_INFO_OWNER, 0, 1) = 1
               OR DECODE(D.GEO_INFO_SEQ_NUM, S.GEO_INFO_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AREA_SEQ_NUM, S.AREA_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.LOC_COMM_TXT, S.LOC_COMM_TXT, 0, 1) = 1
               OR DECODE(D.AREA_ACREAGE_MEAS, S.AREA_ACREAGE_MEAS, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_SRC_DATA_OWNER_CODE, S.AREA_MEAS_SRC_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_SRC_CODE, S.AREA_MEAS_SRC_CODE, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_DATE, S.AREA_MEAS_DATE, 0, 1) = 1
               OR DECODE(D.DATA_COLL_DATE, S.DATA_COLL_DATE, 0, 1) = 1
               OR DECODE(D.HORZ_ACC_MEAS, S.HORZ_ACC_MEAS, 0, 1) = 1
               OR DECODE(D.SRC_MAP_SCALE_NUM, S.SRC_MAP_SCALE_NUM, 0, 1) = 1
               OR DECODE(D.COORD_DATA_SRC_DATA_OWNER_CODE, S.COORD_DATA_SRC_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.COORD_DATA_SRC_CODE, S.COORD_DATA_SRC_CODE, 0, 1) = 1
               OR DECODE(D.GEO_REF_PT_DATA_OWNER_CODE, S.GEO_REF_PT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.GEO_REF_PT_CODE, S.GEO_REF_PT_CODE, 0, 1) = 1
               OR DECODE(D.GEOM_TYPE_DATA_OWNER_CODE, S.GEOM_TYPE_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.GEOM_TYPE_CODE, S.GEOM_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.HORZ_COLL_METH_DATA_OWNER_CODE, S.HORZ_COLL_METH_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.HORZ_COLL_METH_CODE, S.HORZ_COLL_METH_CODE, 0, 1) = 1
               OR DECODE(D.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE, S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE, 0, 1) = 1
               OR DECODE(D.HORZ_COORD_REF_SYS_DATUM_CODE, S.HORZ_COORD_REF_SYS_DATUM_CODE, 0, 1) = 1
               OR DECODE(D.VERF_METH_DATA_OWNER_CODE, S.VERF_METH_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.VERF_METH_CODE, S.VERF_METH_CODE, 0, 1) = 1
               OR DECODE(D.LATITUDE, S.LATITUDE, 0, 1) = 1
               OR DECODE(D.LONGITUDE, S.LONGITUDE, 0, 1) = 1
               OR DECODE(D.ELEVATION, S.ELEVATION, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.G_CREATED_DATE, S.G_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (GIS_GEO_INFORMATION_ID,
                    GIS_FAC_SUBM_ID,
                    TRANS_CODE,
                    GEO_INFO_OWNER,
                    GEO_INFO_SEQ_NUM,
                    PERMIT_UNIT_SEQ_NUM,
                    AREA_SEQ_NUM,
                    LOC_COMM_TXT,
                    AREA_ACREAGE_MEAS,
                    AREA_MEAS_SRC_DATA_OWNER_CODE,
                    AREA_MEAS_SRC_CODE,
                    AREA_MEAS_DATE,
                    DATA_COLL_DATE,
                    HORZ_ACC_MEAS,
                    SRC_MAP_SCALE_NUM,
                    COORD_DATA_SRC_DATA_OWNER_CODE,
                    COORD_DATA_SRC_CODE,
                    GEO_REF_PT_DATA_OWNER_CODE,
                    GEO_REF_PT_CODE,
                    GEOM_TYPE_DATA_OWNER_CODE,
                    GEOM_TYPE_CODE,
                    HORZ_COLL_METH_DATA_OWNER_CODE,
                    HORZ_COLL_METH_CODE,
                    HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                    HORZ_COORD_REF_SYS_DATUM_CODE,
                    VERF_METH_DATA_OWNER_CODE,
                    VERF_METH_CODE,
                    LATITUDE,
                    LONGITUDE,
                    ELEVATION,
                    CREATED_BY_USERID,
                    G_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_GIS_GEO_INFORMATION.NEXTVAL,
                    S.WH_GIS_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.GEO_INFO_OWNER,
                    S.GEO_INFO_SEQ_NUM,
                    S.PERMIT_UNIT_SEQ_NUM,
                    S.AREA_SEQ_NUM,
                    S.LOC_COMM_TXT,
                    S.AREA_ACREAGE_MEAS,
                    S.AREA_MEAS_SRC_DATA_OWNER_CODE,
                    S.AREA_MEAS_SRC_CODE,
                    S.AREA_MEAS_DATE,
                    S.DATA_COLL_DATE,
                    S.HORZ_ACC_MEAS,
                    S.SRC_MAP_SCALE_NUM,
                    S.COORD_DATA_SRC_DATA_OWNER_CODE,
                    S.COORD_DATA_SRC_CODE,
                    S.GEO_REF_PT_DATA_OWNER_CODE,
                    S.GEO_REF_PT_CODE,
                    S.GEOM_TYPE_DATA_OWNER_CODE,
                    S.GEOM_TYPE_CODE,
                    S.HORZ_COLL_METH_DATA_OWNER_CODE,
                    S.HORZ_COLL_METH_CODE,
                    S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                    S.HORZ_COORD_REF_SYS_DATUM_CODE,
                    S.VERF_METH_DATA_OWNER_CODE,
                    S.VERF_METH_CODE,
                    S.LATITUDE,
                    S.LONGITUDE,
                    S.ELEVATION,
                    S.CREATED_BY_USERID,
                    S.G_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

-- CME Delete

    PROCEDURE CME_DELETE_VIOL AS
    BEGIN
        DELETE
        FROM RCRA_CME_VIOL
        WHERE CME_VIOL_ID IN (SELECT WH_CME_VIOL_ID FROM ETL_CME_VIOL_DEL_VW WHERE WH_CME_VIOL_ID IS NOT NULL);
    END;

    PROCEDURE CME_DELETE_EVAL AS
    BEGIN
        DELETE
        FROM RCRA_CME_EVAL
        WHERE CME_EVAL_ID IN (SELECT WH_CME_EVAL_ID FROM ETL_CME_EVAL_DEL_VW WHERE WH_CME_EVAL_ID IS NOT NULL);
    END;

    PROCEDURE CME_DELETE_ENFRC_ACT AS
    BEGIN
        DELETE
        FROM RCRA_CME_ENFRC_ACT
        WHERE CME_ENFRC_ACT_ID IN
              (SELECT WH_CME_ENFR_ACT_ID FROM ETL_CME_ENFRC_ACT_DEL_VW WHERE WH_CME_ENFR_ACT_ID IS NOT NULL);
    END;

-- CME

    PROCEDURE CME_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CE');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               EPA_HDLR_ID,
               CASE
                   WHEN
                       CME_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_CME_FAC_SUBM_VW;
    END;

    PROCEDURE CME_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_CME_FAC_SUBM D
        USING (SELECT *
               FROM ETL_CME_FAC_SUBM_VW) S
        ON (D.CME_FAC_SUBM_ID = S.WH_CME_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (CME_FAC_SUBM_ID,
                    EPA_HDLR_ID)
            VALUES (SEQ_RCRA_CME_FAC_SUBM.NEXTVAL,
                    S.EPA_HDLR_ID);
    END;

    PROCEDURE CME_MERGE_VIOL AS
    BEGIN
        MERGE INTO RCRA_CME_VIOL D
        USING (SELECT *
               FROM ETL_CME_VIOL_VW) S
        ON (D.CME_VIOL_ID = S.WH_CME_VIOL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE           = S.TRANS_CODE,
                D.VIOL_ACT_LOC         = S.VIOL_ACT_LOC,
                D.VIOL_SEQ_NUM         = S.VIOL_SEQ_NUM,
                D.AGN_WHICH_DTRM_VIOL  = S.AGN_WHICH_DTRM_VIOL,
                D.VIOL_TYPE_OWNER      = S.VIOL_TYPE_OWNER,
                D.VIOL_TYPE            = S.VIOL_TYPE,
                D.FORMER_CITATION_NAME = S.FORMER_CITATION_NAME,
                D.VIOL_DTRM_DATE       = S.VIOL_DTRM_DATE,
                D.RTN_COMPL_ACTL_DATE  = S.RTN_COMPL_ACTL_DATE,
                D.RTN_TO_COMPL_QUAL    = S.RTN_TO_COMPL_QUAL,
                D.VIOL_RESP_AGN        = S.VIOL_RESP_AGN,
                D.NOTES                = S.NOTES,
                D.CREATED_BY_USERID    = S.CREATED_BY_USERID,
                D.C_CREATED_DATE       = S.C_CREATED_DATE,
                D.LAST_UPDT_BY         = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE       = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_ACT_LOC, S.VIOL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
               OR DECODE(D.VIOL_TYPE_OWNER, S.VIOL_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.VIOL_TYPE, S.VIOL_TYPE, 0, 1) = 1
               OR DECODE(D.FORMER_CITATION_NAME, S.FORMER_CITATION_NAME, 0, 1) = 1
               OR DECODE(D.VIOL_DTRM_DATE, S.VIOL_DTRM_DATE, 0, 1) = 1
               OR DECODE(D.RTN_COMPL_ACTL_DATE, S.RTN_COMPL_ACTL_DATE, 0, 1) = 1
               OR DECODE(D.RTN_TO_COMPL_QUAL, S.RTN_TO_COMPL_QUAL, 0, 1) = 1
               OR DECODE(D.VIOL_RESP_AGN, S.VIOL_RESP_AGN, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_VIOL_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    VIOL_ACT_LOC,
                    VIOL_SEQ_NUM,
                    AGN_WHICH_DTRM_VIOL,
                    VIOL_TYPE_OWNER,
                    VIOL_TYPE,
                    FORMER_CITATION_NAME,
                    VIOL_DTRM_DATE,
                    RTN_COMPL_ACTL_DATE,
                    RTN_TO_COMPL_QUAL,
                    VIOL_RESP_AGN,
                    NOTES,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_VIOL.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.VIOL_ACT_LOC,
                    S.VIOL_SEQ_NUM,
                    S.AGN_WHICH_DTRM_VIOL,
                    S.VIOL_TYPE_OWNER,
                    S.VIOL_TYPE,
                    S.FORMER_CITATION_NAME,
                    S.VIOL_DTRM_DATE,
                    S.RTN_COMPL_ACTL_DATE,
                    S.RTN_TO_COMPL_QUAL,
                    S.VIOL_RESP_AGN,
                    S.NOTES,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_EVAL AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL D
        USING (SELECT *
               FROM ETL_CME_EVAL_VW) S
        ON (D.CME_EVAL_ID = S.WH_CME_EVAL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.EVAL_ACT_LOC                = S.EVAL_ACT_LOC,
                D.EVAL_IDEN                   = S.EVAL_IDEN,
                D.EVAL_START_DATE             = S.EVAL_START_DATE,
                D.EVAL_RESP_AGN               = S.EVAL_RESP_AGN,
                D.DAY_ZERO                    = S.DAY_ZERO,
                D.FOUND_VIOL                  = S.FOUND_VIOL,
                D.CTZN_CPLT_IND               = S.CTZN_CPLT_IND,
                D.MULTIMEDIA_IND              = S.MULTIMEDIA_IND,
                D.SAMPL_IND                   = S.SAMPL_IND,
                D.NOT_SUBTL_C_IND             = S.NOT_SUBTL_C_IND,
                D.EVAL_TYPE_OWNER             = S.EVAL_TYPE_OWNER,
                D.EVAL_TYPE                   = S.EVAL_TYPE,
                D.FOCUS_AREA_OWNER            = S.FOCUS_AREA_OWNER,
                D.FOCUS_AREA                  = S.FOCUS_AREA,
                D.EVAL_RESP_PERSON_IDEN_OWNER = S.EVAL_RESP_PERSON_IDEN_OWNER,
                D.EVAL_RESP_PERSON_IDEN       = S.EVAL_RESP_PERSON_IDEN,
                D.EVAL_RESP_SUBORG_OWNER      = S.EVAL_RESP_SUBORG_OWNER,
                D.EVAL_RESP_SUBORG            = S.EVAL_RESP_SUBORG,
                D.NOTES                       = S.NOTES,
                D.NOC_DATE                    = S.NOC_DATE,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.C_CREATED_DATE              = S.C_CREATED_DATE,
                D.DATA_ORIG                   = S.DATA_ORIG,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.EVAL_ACT_LOC, S.EVAL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.EVAL_IDEN, S.EVAL_IDEN, 0, 1) = 1
               OR DECODE(D.EVAL_START_DATE, S.EVAL_START_DATE, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_AGN, S.EVAL_RESP_AGN, 0, 1) = 1
               OR DECODE(D.DAY_ZERO, S.DAY_ZERO, 0, 1) = 1
               OR DECODE(D.FOUND_VIOL, S.FOUND_VIOL, 0, 1) = 1
               OR DECODE(D.CTZN_CPLT_IND, S.CTZN_CPLT_IND, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_IND, S.MULTIMEDIA_IND, 0, 1) = 1
               OR DECODE(D.SAMPL_IND, S.SAMPL_IND, 0, 1) = 1
               OR DECODE(D.NOT_SUBTL_C_IND, S.NOT_SUBTL_C_IND, 0, 1) = 1
               OR DECODE(D.EVAL_TYPE_OWNER, S.EVAL_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_TYPE, S.EVAL_TYPE, 0, 1) = 1
               OR DECODE(D.FOCUS_AREA_OWNER, S.FOCUS_AREA_OWNER, 0, 1) = 1
               OR DECODE(D.FOCUS_AREA, S.FOCUS_AREA, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_PERSON_IDEN_OWNER, S.EVAL_RESP_PERSON_IDEN_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_PERSON_IDEN, S.EVAL_RESP_PERSON_IDEN, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_SUBORG_OWNER, S.EVAL_RESP_SUBORG_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_SUBORG, S.EVAL_RESP_SUBORG, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.NOC_DATE, S.NOC_DATE, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    EVAL_ACT_LOC,
                    EVAL_IDEN,
                    EVAL_START_DATE,
                    EVAL_RESP_AGN,
                    DAY_ZERO,
                    FOUND_VIOL,
                    CTZN_CPLT_IND,
                    MULTIMEDIA_IND,
                    SAMPL_IND,
                    NOT_SUBTL_C_IND,
                    EVAL_TYPE_OWNER,
                    EVAL_TYPE,
                    FOCUS_AREA_OWNER,
                    FOCUS_AREA,
                    EVAL_RESP_PERSON_IDEN_OWNER,
                    EVAL_RESP_PERSON_IDEN,
                    EVAL_RESP_SUBORG_OWNER,
                    EVAL_RESP_SUBORG,
                    NOTES,
                    NOC_DATE,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_EVAL.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.EVAL_ACT_LOC,
                    S.EVAL_IDEN,
                    S.EVAL_START_DATE,
                    S.EVAL_RESP_AGN,
                    S.DAY_ZERO,
                    S.FOUND_VIOL,
                    S.CTZN_CPLT_IND,
                    S.MULTIMEDIA_IND,
                    S.SAMPL_IND,
                    S.NOT_SUBTL_C_IND,
                    S.EVAL_TYPE_OWNER,
                    S.EVAL_TYPE,
                    S.FOCUS_AREA_OWNER,
                    S.FOCUS_AREA,
                    S.EVAL_RESP_PERSON_IDEN_OWNER,
                    S.EVAL_RESP_PERSON_IDEN,
                    S.EVAL_RESP_SUBORG_OWNER,
                    S.EVAL_RESP_SUBORG,
                    S.NOTES,
                    S.NOC_DATE,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_EVAL_COMMIT AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL_COMMIT D
        USING (SELECT *
               FROM ETL_CME_EVAL_COMMIT_VW) S
        ON (D.CME_EVAL_COMMIT_ID = S.WH_CME_EVAL_COMMIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_COMMIT_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CME_EVAL_COMMIT.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE CME_MERGE_EVAL_VIOL AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL_VIOL D
        USING (SELECT *
               FROM ETL_CME_EVAL_VIOL_VW) S
        ON (D.CME_EVAL_VIOL_ID = S.WH_CME_EVAL_VIOL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.VIOL_SEQ_NUM        = S.VIOL_SEQ_NUM,
                D.VIOL_ACT_LOC        = S.VIOL_ACT_LOC,
                D.AGN_WHICH_DTRM_VIOL = S.AGN_WHICH_DTRM_VIOL
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.VIOL_ACT_LOC, S.VIOL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_VIOL_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    VIOL_SEQ_NUM,
                    VIOL_ACT_LOC,
                    AGN_WHICH_DTRM_VIOL)
            VALUES (SEQ_RCRA_CME_EVAL_VIOL.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.VIOL_SEQ_NUM,
                    S.VIOL_ACT_LOC,
                    S.AGN_WHICH_DTRM_VIOL);
    END;

    PROCEDURE CME_MERGE_CITATION AS
    BEGIN
        MERGE INTO RCRA_CME_CITATION D
        USING (SELECT *
               FROM ETL_CME_CITATION_VW) S
        ON (D.CME_CITATION_ID = S.WH_CME_CITATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE            = S.TRANS_CODE,
                D.CITATION_NAME_SEQ_NUM = S.CITATION_NAME_SEQ_NUM,
                D.CITATION_NAME         = S.CITATION_NAME,
                D.CITATION_NAME_OWNER   = S.CITATION_NAME_OWNER,
                D.CITATION_NAME_TYPE    = S.CITATION_NAME_TYPE,
                D.NOTES                 = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_SEQ_NUM, S.CITATION_NAME_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.CITATION_NAME, S.CITATION_NAME, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_OWNER, S.CITATION_NAME_OWNER, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_TYPE, S.CITATION_NAME_TYPE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_CITATION_ID,
                    CME_VIOL_ID,
                    TRANS_CODE,
                    CITATION_NAME_SEQ_NUM,
                    CITATION_NAME,
                    CITATION_NAME_OWNER,
                    CITATION_NAME_TYPE,
                    NOTES)
            VALUES (SEQ_RCRA_CME_CITATION.NEXTVAL,
                    S.WH_CME_VIOL_ID,
                    S.TRANS_CODE,
                    S.CITATION_NAME_SEQ_NUM,
                    S.CITATION_NAME,
                    S.CITATION_NAME_OWNER,
                    S.CITATION_NAME_TYPE,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_ENFRC_ACT AS
    BEGIN
        MERGE INTO RCRA_CME_ENFRC_ACT D
        USING (SELECT *
               FROM ETL_CME_ENFRC_ACT_VW) S
        ON (D.CME_ENFRC_ACT_ID = S.WH_CME_ENFR_ACT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                    = S.TRANS_CODE,
                D.ENFRC_AGN_LOC_NAME            = S.ENFRC_AGN_LOC_NAME,
                D.ENFRC_ACT_IDEN                = S.ENFRC_ACT_IDEN,
                D.ENFRC_ACT_DATE                = S.ENFRC_ACT_DATE,
                D.ENFRC_AGN_NAME                = S.ENFRC_AGN_NAME,
                D.ENFRC_DOCKET_NUM              = S.ENFRC_DOCKET_NUM,
                D.ENFRC_ATTRY                   = S.ENFRC_ATTRY,
                D.CORCT_ACT_COMPT               = S.CORCT_ACT_COMPT,
                D.CNST_AGMT_FINAL_ORDER_SEQ_NUM = S.CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                D.APPEAL_INIT_DATE              = S.APPEAL_INIT_DATE,
                D.APPEAL_RSLN_DATE              = S.APPEAL_RSLN_DATE,
                D.DISP_STAT_DATE                = S.DISP_STAT_DATE,
                D.DISP_STAT_OWNER               = S.DISP_STAT_OWNER,
                D.DISP_STAT                     = S.DISP_STAT,
                D.ENFRC_OWNER                   = S.ENFRC_OWNER,
                D.ENFRC_TYPE                    = S.ENFRC_TYPE,
                D.ENFRC_RESP_PERSON_OWNER       = S.ENFRC_RESP_PERSON_OWNER,
                D.ENFRC_RESP_PERSON_IDEN        = S.ENFRC_RESP_PERSON_IDEN,
                D.ENFRC_RESP_SUBORG_OWNER       = S.ENFRC_RESP_SUBORG_OWNER,
                D.ENFRC_RESP_SUBORG             = S.ENFRC_RESP_SUBORG,
                D.NOTES                         = S.NOTES,
                D.CREATED_BY_USERID             = S.CREATED_BY_USERID,
                D.C_CREATED_DATE                = S.C_CREATED_DATE,
                D.DATA_ORIG                     = S.DATA_ORIG,
                D.LAST_UPDT_BY                  = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ENFRC_AGN_LOC_NAME, S.ENFRC_AGN_LOC_NAME, 0, 1) = 1
               OR DECODE(D.ENFRC_ACT_IDEN, S.ENFRC_ACT_IDEN, 0, 1) = 1
               OR DECODE(D.ENFRC_ACT_DATE, S.ENFRC_ACT_DATE, 0, 1) = 1
               OR DECODE(D.ENFRC_AGN_NAME, S.ENFRC_AGN_NAME, 0, 1) = 1
               OR DECODE(D.ENFRC_DOCKET_NUM, S.ENFRC_DOCKET_NUM, 0, 1) = 1
               OR DECODE(D.ENFRC_ATTRY, S.ENFRC_ATTRY, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_COMPT, S.CORCT_ACT_COMPT, 0, 1) = 1
               OR DECODE(D.CNST_AGMT_FINAL_ORDER_SEQ_NUM, S.CNST_AGMT_FINAL_ORDER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.APPEAL_INIT_DATE, S.APPEAL_INIT_DATE, 0, 1) = 1
               OR DECODE(D.APPEAL_RSLN_DATE, S.APPEAL_RSLN_DATE, 0, 1) = 1
               OR DECODE(D.DISP_STAT_DATE, S.DISP_STAT_DATE, 0, 1) = 1
               OR DECODE(D.DISP_STAT_OWNER, S.DISP_STAT_OWNER, 0, 1) = 1
               OR DECODE(D.DISP_STAT, S.DISP_STAT, 0, 1) = 1
               OR DECODE(D.ENFRC_OWNER, S.ENFRC_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_TYPE, S.ENFRC_TYPE, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_PERSON_OWNER, S.ENFRC_RESP_PERSON_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_PERSON_IDEN, S.ENFRC_RESP_PERSON_IDEN, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_SUBORG_OWNER, S.ENFRC_RESP_SUBORG_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_SUBORG, S.ENFRC_RESP_SUBORG, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_ENFRC_ACT_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    ENFRC_AGN_LOC_NAME,
                    ENFRC_ACT_IDEN,
                    ENFRC_ACT_DATE,
                    ENFRC_AGN_NAME,
                    ENFRC_DOCKET_NUM,
                    ENFRC_ATTRY,
                    CORCT_ACT_COMPT,
                    CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                    APPEAL_INIT_DATE,
                    APPEAL_RSLN_DATE,
                    DISP_STAT_DATE,
                    DISP_STAT_OWNER,
                    DISP_STAT,
                    ENFRC_OWNER,
                    ENFRC_TYPE,
                    ENFRC_RESP_PERSON_OWNER,
                    ENFRC_RESP_PERSON_IDEN,
                    ENFRC_RESP_SUBORG_OWNER,
                    ENFRC_RESP_SUBORG,
                    NOTES,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_ENFRC_ACT.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ENFRC_AGN_LOC_NAME,
                    S.ENFRC_ACT_IDEN,
                    S.ENFRC_ACT_DATE,
                    S.ENFRC_AGN_NAME,
                    S.ENFRC_DOCKET_NUM,
                    S.ENFRC_ATTRY,
                    S.CORCT_ACT_COMPT,
                    S.CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                    S.APPEAL_INIT_DATE,
                    S.APPEAL_RSLN_DATE,
                    S.DISP_STAT_DATE,
                    S.DISP_STAT_OWNER,
                    S.DISP_STAT,
                    S.ENFRC_OWNER,
                    S.ENFRC_TYPE,
                    S.ENFRC_RESP_PERSON_OWNER,
                    S.ENFRC_RESP_PERSON_IDEN,
                    S.ENFRC_RESP_SUBORG_OWNER,
                    S.ENFRC_RESP_SUBORG,
                    S.NOTES,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_CSNY_DATE AS
    BEGIN
        MERGE INTO RCRA_CME_CSNY_DATE D
        USING (SELECT *
               FROM ETL_CME_CSNY_DATE_VW) S
        ON (D.CME_CSNY_DATE_ID = S.WH_CME_CSNY_DATE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE = S.TRANS_CODE,
                D.SNY_DATE   = S.SNY_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.SNY_DATE, S.SNY_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_CSNY_DATE_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    SNY_DATE)
            VALUES (SEQ_RCRA_CME_CSNY_DATE.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.SNY_DATE);
    END;

    PROCEDURE CME_MERGE_MEDIA AS
    BEGIN
        MERGE INTO RCRA_CME_MEDIA D
        USING (SELECT *
               FROM ETL_CME_MEDIA_VW) S
        ON (D.CME_MEDIA_ID = S.WH_CME_MEDIA_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE            = S.TRANS_CODE,
                D.MULTIMEDIA_CODE_OWNER = S.MULTIMEDIA_CODE_OWNER,
                D.MULTIMEDIA_CODE       = S.MULTIMEDIA_CODE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_CODE_OWNER, S.MULTIMEDIA_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_CODE, S.MULTIMEDIA_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_MEDIA_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    MULTIMEDIA_CODE_OWNER,
                    MULTIMEDIA_CODE)
            VALUES (SEQ_RCRA_CME_MEDIA.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.MULTIMEDIA_CODE_OWNER,
                    S.MULTIMEDIA_CODE);
    END;

    PROCEDURE CME_MERGE_MILESTONE AS
    BEGIN
        MERGE INTO RCRA_CME_MILESTONE D
        USING (SELECT *
               FROM ETL_CME_MILESTONE_VW) S
        ON (D.CME_MILESTONE_ID = S.WH_CME_MILESTONE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE               = S.TRANS_CODE,
                D.MILESTONE_SEQ_NUM        = S.MILESTONE_SEQ_NUM,
                D.TECH_RQMT_IDEN           = S.TECH_RQMT_IDEN,
                D.TECH_RQMT_DESC           = S.TECH_RQMT_DESC,
                D.MILESTONE_SCHD_COMP_DATE = S.MILESTONE_SCHD_COMP_DATE,
                D.MILESTONE_ACTL_COMP_DATE = S.MILESTONE_ACTL_COMP_DATE,
                D.MILESTONE_DFLT_DATE      = S.MILESTONE_DFLT_DATE,
                D.NOTES                    = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MILESTONE_SEQ_NUM, S.MILESTONE_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.TECH_RQMT_IDEN, S.TECH_RQMT_IDEN, 0, 1) = 1
               OR DECODE(D.TECH_RQMT_DESC, S.TECH_RQMT_DESC, 0, 1) = 1
               OR DECODE(D.MILESTONE_SCHD_COMP_DATE, S.MILESTONE_SCHD_COMP_DATE, 0, 1) = 1
               OR DECODE(D.MILESTONE_ACTL_COMP_DATE, S.MILESTONE_ACTL_COMP_DATE, 0, 1) = 1
               OR DECODE(D.MILESTONE_DFLT_DATE, S.MILESTONE_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_MILESTONE_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    MILESTONE_SEQ_NUM,
                    TECH_RQMT_IDEN,
                    TECH_RQMT_DESC,
                    MILESTONE_SCHD_COMP_DATE,
                    MILESTONE_ACTL_COMP_DATE,
                    MILESTONE_DFLT_DATE,
                    NOTES)
            VALUES (SEQ_RCRA_CME_MILESTONE.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.MILESTONE_SEQ_NUM,
                    S.TECH_RQMT_IDEN,
                    S.TECH_RQMT_DESC,
                    S.MILESTONE_SCHD_COMP_DATE,
                    S.MILESTONE_ACTL_COMP_DATE,
                    S.MILESTONE_DFLT_DATE,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_RQST AS
    BEGIN
        MERGE INTO RCRA_CME_RQST D
        USING (SELECT *
               FROM ETL_CME_RQST_VW) S
        ON (D.CME_RQST_ID = S.WH_CME_RQST_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.RQST_SEQ_NUM   = S.RQST_SEQ_NUM,
                D.DATE_OF_RQST   = S.DATE_OF_RQST,
                D.DATE_RESP_RCVD = S.DATE_RESP_RCVD,
                D.RQST_AGN       = S.RQST_AGN,
                D.NOTES          = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.RQST_SEQ_NUM, S.RQST_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.DATE_OF_RQST, S.DATE_OF_RQST, 0, 1) = 1
               OR DECODE(D.DATE_RESP_RCVD, S.DATE_RESP_RCVD, 0, 1) = 1
               OR DECODE(D.RQST_AGN, S.RQST_AGN, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_RQST_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    RQST_SEQ_NUM,
                    DATE_OF_RQST,
                    DATE_RESP_RCVD,
                    RQST_AGN,
                    NOTES)
            VALUES (SEQ_RCRA_CME_RQST.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.RQST_SEQ_NUM,
                    S.DATE_OF_RQST,
                    S.DATE_RESP_RCVD,
                    S.RQST_AGN,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_SUPP_ENVR_PRJT AS
    BEGIN
        MERGE INTO RCRA_CME_SUPP_ENVR_PRJT D
        USING (SELECT *
               FROM ETL_CME_SUPP_ENVR_PRJT_VW) S
        ON (D.CME_SUPP_ENVR_PRJT_ID = S.WH_CME_SUPP_ENVR_PRJT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE         = S.TRANS_CODE,
                D.SEP_SEQ_NUM        = S.SEP_SEQ_NUM,
                D.SEP_EXPND_AMOUNT   = S.SEP_EXPND_AMOUNT,
                D.SEP_SCHD_COMP_DATE = S.SEP_SCHD_COMP_DATE,
                D.SEP_ACTL_DATE      = S.SEP_ACTL_DATE,
                D.SEP_DFLT_DATE      = S.SEP_DFLT_DATE,
                D.SEP_CODE_OWNER     = S.SEP_CODE_OWNER,
                D.SEP_DESC_TXT       = S.SEP_DESC_TXT,
                D.NOTES              = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.SEP_SEQ_NUM, S.SEP_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.SEP_EXPND_AMOUNT, S.SEP_EXPND_AMOUNT, 0, 1) = 1
               OR DECODE(D.SEP_SCHD_COMP_DATE, S.SEP_SCHD_COMP_DATE, 0, 1) = 1
               OR DECODE(D.SEP_ACTL_DATE, S.SEP_ACTL_DATE, 0, 1) = 1
               OR DECODE(D.SEP_DFLT_DATE, S.SEP_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.SEP_CODE_OWNER, S.SEP_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.SEP_DESC_TXT, S.SEP_DESC_TXT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_SUPP_ENVR_PRJT_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    SEP_SEQ_NUM,
                    SEP_EXPND_AMOUNT,
                    SEP_SCHD_COMP_DATE,
                    SEP_ACTL_DATE,
                    SEP_DFLT_DATE,
                    SEP_CODE_OWNER,
                    SEP_DESC_TXT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_SUPP_ENVR_PRJT.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.SEP_SEQ_NUM,
                    S.SEP_EXPND_AMOUNT,
                    S.SEP_SCHD_COMP_DATE,
                    S.SEP_ACTL_DATE,
                    S.SEP_DFLT_DATE,
                    S.SEP_CODE_OWNER,
                    S.SEP_DESC_TXT,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_VIOL_ENFRC AS
    BEGIN
        MERGE INTO RCRA_CME_VIOL_ENFRC D
        USING (SELECT *
               FROM ETL_CME_VIOL_ENFRC_VW) S
        ON (D.CME_VIOL_ENFRC_ID = S.WH_CME_VIOL_ENFRC_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.VIOL_SEQ_NUM        = S.VIOL_SEQ_NUM,
                D.AGN_WHICH_DTRM_VIOL = S.AGN_WHICH_DTRM_VIOL,
                D.RTN_COMPL_SCHD_DATE = S.RTN_COMPL_SCHD_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
               OR DECODE(D.RTN_COMPL_SCHD_DATE, S.RTN_COMPL_SCHD_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_VIOL_ENFRC_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    VIOL_SEQ_NUM,
                    AGN_WHICH_DTRM_VIOL,
                    RTN_COMPL_SCHD_DATE)
            VALUES (SEQ_RCRA_CME_VIOL_ENFRC.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.VIOL_SEQ_NUM,
                    S.AGN_WHICH_DTRM_VIOL,
                    S.RTN_COMPL_SCHD_DATE);
    END;

    PROCEDURE CME_MERGE_PNLTY AS
    BEGIN
        MERGE INTO RCRA_CME_PNLTY D
        USING (SELECT *
               FROM ETL_CME_PNLTY_VW) S
        ON (D.CME_PNLTY_ID = S.WH_CME_PNLTY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.PNLTY_TYPE_OWNER               = S.PNLTY_TYPE_OWNER,
                D.PNLTY_TYPE                     = S.PNLTY_TYPE,
                D.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT = S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                D.NOTES                          = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PNLTY_TYPE_OWNER, S.PNLTY_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.PNLTY_TYPE, S.PNLTY_TYPE, 0, 1) = 1
               OR DECODE(D.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT, S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_PNLTY_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    PNLTY_TYPE_OWNER,
                    PNLTY_TYPE,
                    CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_PNLTY.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.PNLTY_TYPE_OWNER,
                    S.PNLTY_TYPE,
                    S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                    S.NOTES);
    END;

-- ETL_CME_PYMT_VW
    PROCEDURE CME_MERGE_PYMT AS
    BEGIN
        MERGE INTO RCRA_CME_PYMT D
        USING (SELECT *
               FROM ETL_CME_PYMT_VW) S
        ON (D.CME_PYMT_ID = S.WH_CME_PYMT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE       = S.TRANS_CODE,
                D.PYMT_SEQ_NUM     = S.PYMT_SEQ_NUM,
                D.PYMT_DFLT_DATE   = S.PYMT_DFLT_DATE,
                D.SCHD_PYMT_DATE   = S.SCHD_PYMT_DATE,
                D.SCHD_PYMT_AMOUNT = S.SCHD_PYMT_AMOUNT,
                D.ACTL_PYMT_DATE   = S.ACTL_PYMT_DATE,
                D.ACTL_PAID_AMOUNT = S.ACTL_PAID_AMOUNT,
                D.NOTES            = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PYMT_SEQ_NUM, S.PYMT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PYMT_DFLT_DATE, S.PYMT_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.SCHD_PYMT_DATE, S.SCHD_PYMT_DATE, 0, 1) = 1
               OR DECODE(D.SCHD_PYMT_AMOUNT, S.SCHD_PYMT_AMOUNT, 0, 1) = 1
               OR DECODE(D.ACTL_PYMT_DATE, S.ACTL_PYMT_DATE, 0, 1) = 1
               OR DECODE(D.ACTL_PAID_AMOUNT, S.ACTL_PAID_AMOUNT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_PYMT_ID,
                    CME_PNLTY_ID,
                    TRANS_CODE,
                    PYMT_SEQ_NUM,
                    PYMT_DFLT_DATE,
                    SCHD_PYMT_DATE,
                    SCHD_PYMT_AMOUNT,
                    ACTL_PYMT_DATE,
                    ACTL_PAID_AMOUNT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_PYMT.NEXTVAL,
                    S.WH_CME_PNLTY_ID,
                    S.TRANS_CODE,
                    S.PYMT_SEQ_NUM,
                    S.PYMT_DFLT_DATE,
                    S.SCHD_PYMT_DATE,
                    S.SCHD_PYMT_AMOUNT,
                    S.ACTL_PYMT_DATE,
                    S.ACTL_PAID_AMOUNT,
                    S.NOTES);
    END;

-- CA

    PROCEDURE CA_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CA');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       CA_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_CA_FAC_SUBM_VW;
    END;

    PROCEDURE CA_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_CA_FAC_SUBM D
        USING (SELECT *
               FROM ETL_CA_FAC_SUBM_VW) S
        ON (D.CA_FAC_SUBM_ID = S.WH_CA_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (D.CA_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_CA_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

    PROCEDURE CA_MERGE_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_EVENT D
        USING (SELECT *
               FROM ETL_CA_EVENT_VW) S
        ON (D.CA_EVENT_ID = S.WH_CA_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM,
                D.ACTL_DATE                      = S.ACTL_DATE,
                D.ORIGINAL_SCHEDULE_DATE         = S.ORIGINAL_SCHEDULE_DATE,
                D.NEW_SCHEDULE_DATE              = S.NEW_SCHEDULE_DATE,
                D.EVENT_SUBORG_DATA_OWNER_CODE   = S.EVENT_SUBORG_DATA_OWNER_CODE,
                D.EVENT_SUBORG_CODE              = S.EVENT_SUBORG_CODE,
                D.RESP_PERSON_DATA_OWNER_CODE    = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID                 = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.PUBLIC_SUPP_INFO_TXT           = S.PUBLIC_SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.ACTL_DATE, S.ACTL_DATE, 0, 1) = 1
               OR DECODE(D.ORIGINAL_SCHEDULE_DATE, S.ORIGINAL_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.NEW_SCHEDULE_DATE, S.NEW_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_DATA_OWNER_CODE, S.EVENT_SUBORG_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_CODE, S.EVENT_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.PUBLIC_SUPP_INFO_TXT, S.PUBLIC_SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_EVENT_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM,
                    ACTL_DATE,
                    ORIGINAL_SCHEDULE_DATE,
                    NEW_SCHEDULE_DATE,
                    EVENT_SUBORG_DATA_OWNER_CODE,
                    EVENT_SUBORG_CODE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    PUBLIC_SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_EVENT.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM,
                    S.ACTL_DATE,
                    S.ORIGINAL_SCHEDULE_DATE,
                    S.NEW_SCHEDULE_DATE,
                    S.EVENT_SUBORG_DATA_OWNER_CODE,
                    S.EVENT_SUBORG_CODE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.PUBLIC_SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

--
    PROCEDURE CA_MERGE_EVENT_COMMITMENT AS
    BEGIN
        MERGE INTO RCRA_CA_EVENT_COMMITMENT D
        USING (SELECT *
               FROM ETL_CA_EVENT_COMMITMENT_VW) S
        ON (D.CA_EVENT_COMMITMENT_ID = S.WH_CA_EVENT_COMMITMENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_EVENT_COMMITMENT_ID,
                    CA_EVENT_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_EVENT_COMMITMENT.NEXTVAL,
                    S.WH_CA_EVENT_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_AREA AS
    BEGIN
        MERGE INTO RCRA_CA_AREA D
        USING (SELECT *
               FROM ETL_CA_AREA_VW) S
        ON (D.CA_AREA_ID = S.WH_CA_AREA_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.AREA_SEQ_NUM                   = S.AREA_SEQ_NUM,
                D.FAC_WIDE_IND                   = S.FAC_WIDE_IND,
                D.AREA_NAME                      = S.AREA_NAME,
                D.AIR_REL_IND                    = S.AIR_REL_IND,
                D.GROUNDWATER_REL_IND            = S.GROUNDWATER_REL_IND,
                D.SOIL_REL_IND                   = S.SOIL_REL_IND,
                D.SURFACE_WATER_REL_IND          = S.SURFACE_WATER_REL_IND,
                D.REGULATED_UNIT_IND             = S.REGULATED_UNIT_IND,
                D.EPA_RESP_PERSON_DATA_OWNER_CDE = S.EPA_RESP_PERSON_DATA_OWNER_CDE,
                D.EPA_RESP_PERSON_ID             = S.EPA_RESP_PERSON_ID,
                D.STA_RESP_PERSON_DATA_OWNER_CDE = S.STA_RESP_PERSON_DATA_OWNER_CDE,
                D.STA_RESP_PERSON_ID             = S.STA_RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.AREA_SEQ_NUM, S.AREA_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.FAC_WIDE_IND, S.FAC_WIDE_IND, 0, 1) = 1
               OR DECODE(D.AREA_NAME, S.AREA_NAME, 0, 1) = 1
               OR DECODE(D.AIR_REL_IND, S.AIR_REL_IND, 0, 1) = 1
               OR DECODE(D.GROUNDWATER_REL_IND, S.GROUNDWATER_REL_IND, 0, 1) = 1
               OR DECODE(D.SOIL_REL_IND, S.SOIL_REL_IND, 0, 1) = 1
               OR DECODE(D.SURFACE_WATER_REL_IND, S.SURFACE_WATER_REL_IND, 0, 1) = 1
               OR DECODE(D.REGULATED_UNIT_IND, S.REGULATED_UNIT_IND, 0, 1) = 1
               OR DECODE(D.EPA_RESP_PERSON_DATA_OWNER_CDE, S.EPA_RESP_PERSON_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.EPA_RESP_PERSON_ID, S.EPA_RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.STA_RESP_PERSON_DATA_OWNER_CDE, S.STA_RESP_PERSON_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.STA_RESP_PERSON_ID, S.STA_RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AREA_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    AREA_SEQ_NUM,
                    FAC_WIDE_IND,
                    AREA_NAME,
                    AIR_REL_IND,
                    GROUNDWATER_REL_IND,
                    SOIL_REL_IND,
                    SURFACE_WATER_REL_IND,
                    REGULATED_UNIT_IND,
                    EPA_RESP_PERSON_DATA_OWNER_CDE,
                    EPA_RESP_PERSON_ID,
                    STA_RESP_PERSON_DATA_OWNER_CDE,
                    STA_RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_AREA.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.AREA_SEQ_NUM,
                    S.FAC_WIDE_IND,
                    S.AREA_NAME,
                    S.AIR_REL_IND,
                    S.GROUNDWATER_REL_IND,
                    S.SOIL_REL_IND,
                    S.SURFACE_WATER_REL_IND,
                    S.REGULATED_UNIT_IND,
                    S.EPA_RESP_PERSON_DATA_OWNER_CDE,
                    S.EPA_RESP_PERSON_ID,
                    S.STA_RESP_PERSON_DATA_OWNER_CDE,
                    S.STA_RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CA_MERGE_AREA_REL_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_AREA_REL_EVENT D
        USING (SELECT *
               FROM ETL_CA_AREA_REL_EVENT_VW) S
        ON (D.CA_AREA_REL_EVENT_ID = S.WH_CA_AREA_REL_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AREA_REL_EVENT_ID,
                    CA_AREA_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_AREA_REL_EVENT.NEXTVAL,
                    S.WH_CA_AREA_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_REL_PERMIT_UNIT AS
    BEGIN
        MERGE INTO RCRA_CA_REL_PERMIT_UNIT D
        USING (SELECT *
               FROM ETL_CA_REL_PERMIT_UNIT_VW) S
        ON (D.CA_REL_PERMIT_UNIT_ID = S.WH_CA_REL_PERMIT_UNIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.PERMIT_UNIT_SEQ_NUM = S.PERMIT_UNIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_REL_PERMIT_UNIT_ID,
                    CA_AREA_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_REL_PERMIT_UNIT.NEXTVAL,
                    S.WH_CA_AREA_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_AUTHORITY AS
    BEGIN
        MERGE INTO RCRA_CA_AUTHORITY D
        USING (SELECT *
               FROM ETL_CA_AUTHORITY_VW) S
        ON (D.CA_AUTHORITY_ID = S.WH_CA_AUTHORITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.AUTHORITY_DATA_OWNER_CODE      = S.AUTHORITY_DATA_OWNER_CODE,
                D.AUTHORITY_TYPE_CODE            = S.AUTHORITY_TYPE_CODE,
                D.AUTHORITY_AGN_CODE             = S.AUTHORITY_AGN_CODE,
                D.AUTHORITY_EFFC_DATE            = S.AUTHORITY_EFFC_DATE,
                D.ISSUE_DATE                     = S.ISSUE_DATE,
                D.END_DATE                       = S.END_DATE,
                D.ESTABLISHED_REPOSITORY_CODE    = S.ESTABLISHED_REPOSITORY_CODE,
                D.RESP_LEAD_PROG_IDEN            = S.RESP_LEAD_PROG_IDEN,
                D.AUTHORITY_SUBORG_DATA_OWNR_CDE = S.AUTHORITY_SUBORG_DATA_OWNR_CDE,
                D.AUTHORITY_SUBORG_CODE          = S.AUTHORITY_SUBORG_CODE,
                D.RESP_PERSON_DATA_OWNER_CODE    = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID                 = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_DATA_OWNER_CODE, S.AUTHORITY_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_TYPE_CODE, S.AUTHORITY_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_AGN_CODE, S.AUTHORITY_AGN_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_EFFC_DATE, S.AUTHORITY_EFFC_DATE, 0, 1) = 1
               OR DECODE(D.ISSUE_DATE, S.ISSUE_DATE, 0, 1) = 1
               OR DECODE(D.END_DATE, S.END_DATE, 0, 1) = 1
               OR DECODE(D.ESTABLISHED_REPOSITORY_CODE, S.ESTABLISHED_REPOSITORY_CODE, 0, 1) = 1
               OR DECODE(D.RESP_LEAD_PROG_IDEN, S.RESP_LEAD_PROG_IDEN, 0, 1) = 1
               OR DECODE(D.AUTHORITY_SUBORG_DATA_OWNR_CDE, S.AUTHORITY_SUBORG_DATA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_SUBORG_CODE, S.AUTHORITY_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AUTHORITY_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    AUTHORITY_DATA_OWNER_CODE,
                    AUTHORITY_TYPE_CODE,
                    AUTHORITY_AGN_CODE,
                    AUTHORITY_EFFC_DATE,
                    ISSUE_DATE,
                    END_DATE,
                    ESTABLISHED_REPOSITORY_CODE,
                    RESP_LEAD_PROG_IDEN,
                    AUTHORITY_SUBORG_DATA_OWNR_CDE,
                    AUTHORITY_SUBORG_CODE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_AUTHORITY.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.AUTHORITY_DATA_OWNER_CODE,
                    S.AUTHORITY_TYPE_CODE,
                    S.AUTHORITY_AGN_CODE,
                    S.AUTHORITY_EFFC_DATE,
                    S.ISSUE_DATE,
                    S.END_DATE,
                    S.ESTABLISHED_REPOSITORY_CODE,
                    S.RESP_LEAD_PROG_IDEN,
                    S.AUTHORITY_SUBORG_DATA_OWNR_CDE,
                    S.AUTHORITY_SUBORG_CODE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CA_MERGE_AUTH_REL_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_AUTH_REL_EVENT D
        USING (SELECT *
               FROM ETL_CA_AUTH_REL_EVENT_VW) S
        ON (D.CA_AUTH_REL_EVENT_ID = S.WH_CA_AUTH_REL_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AUTH_REL_EVENT_ID,
                    CA_AUTHORITY_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_AUTH_REL_EVENT.NEXTVAL,
                    S.WH_CA_AUTHORITY_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_STATUTORY_CITATION AS
    BEGIN
        MERGE INTO RCRA_CA_STATUTORY_CITATION D
        USING (SELECT *
               FROM ETL_CA_STATUTORY_CITATION_VW) S
        ON (D.CA_STATUTORY_CITATION_ID = S.WH_CA_STATUTORY_CITATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.STATUTORY_CITTION_DTA_OWNR_CDE = S.STATUTORY_CITTION_DTA_OWNR_CDE,
                D.STATUTORY_CITATION_IDEN        = S.STATUTORY_CITATION_IDEN
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.STATUTORY_CITTION_DTA_OWNR_CDE, S.STATUTORY_CITTION_DTA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.STATUTORY_CITATION_IDEN, S.STATUTORY_CITATION_IDEN, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_STATUTORY_CITATION_ID,
                    CA_AUTHORITY_ID,
                    TRANS_CODE,
                    STATUTORY_CITTION_DTA_OWNR_CDE,
                    STATUTORY_CITATION_IDEN)
            VALUES (SEQ_RCRA_CA_STATUTORY_CITATION.NEXTVAL,
                    S.WH_CA_AUTHORITY_ID,
                    S.TRANS_CODE,
                    S.STATUTORY_CITTION_DTA_OWNR_CDE,
                    S.STATUTORY_CITATION_IDEN);
    END;

-- FA

    PROCEDURE FA_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'FA');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       FA_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_FA_FAC_SUBM_VW;
    END;

    PROCEDURE FA_MERGE_COST_EST_REL_MECH AS
    BEGIN
        MERGE INTO RCRA_FA_COST_EST_REL_MECHANISM D
        USING (SELECT *
               FROM ETL_FA_COST_EST_REL_MECH_VW) S
        ON (D.FA_COST_EST_REL_MECHANISM_ID = S.WH_FA_COST_EST_REL_MECH_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE               = S.TRANS_CODE,
                D.ACT_LOC_CODE             = S.ACT_LOC_CODE,
                D.MECHANISM_AGN_CODE       = S.MECHANISM_AGN_CODE,
                D.MECHANISM_SEQ_NUM        = S.MECHANISM_SEQ_NUM,
                D.MECHANISM_DETAIL_SEQ_NUM = S.MECHANISM_DETAIL_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_AGN_CODE, S.MECHANISM_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_SEQ_NUM, S.MECHANISM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_DETAIL_SEQ_NUM, S.MECHANISM_DETAIL_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_COST_EST_REL_MECHANISM_ID,
                    FA_COST_EST_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    MECHANISM_AGN_CODE,
                    MECHANISM_SEQ_NUM,
                    MECHANISM_DETAIL_SEQ_NUM)
            VALUES (SEQ_RCRA_FA_COST_EST_REL_MECH.NEXTVAL,
                    S.WH_FA_COST_EST_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.MECHANISM_AGN_CODE,
                    S.MECHANISM_SEQ_NUM,
                    S.MECHANISM_DETAIL_SEQ_NUM);
    END;

    PROCEDURE FA_MERGE_COST_EST AS
    BEGIN
        MERGE INTO RCRA_FA_COST_EST D
        USING (SELECT *
               FROM ETL_FA_COST_EST_VW) S
        ON (D.FA_COST_EST_ID = S.WH_FA_COST_EST_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.ACT_LOC_CODE                = S.ACT_LOC_CODE,
                D.COST_ESTIMATE_TYPE_CODE     = S.COST_ESTIMATE_TYPE_CODE,
                D.COST_ESTIMATE_AGN_CODE      = S.COST_ESTIMATE_AGN_CODE,
                D.COST_ESTIMATE_SEQ_NUM       = S.COST_ESTIMATE_SEQ_NUM,
                D.RESP_PERSON_DATA_OWNER_CODE = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID              = S.RESP_PERSON_ID,
                D.COST_ESTIMATE_AMOUNT        = S.COST_ESTIMATE_AMOUNT,
                D.COST_ESTIMATE_DATE          = S.COST_ESTIMATE_DATE,
                D.COST_ESTIMATE_RSN_CODE      = S.COST_ESTIMATE_RSN_CODE,
                D.AREA_UNIT_NOTES_TXT         = S.AREA_UNIT_NOTES_TXT,
                D.SUPP_INFO_TXT               = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.F_CREATED_DATE              = S.F_CREATED_DATE,
                D.DATA_ORIG                   = S.DATA_ORIG,
                D.UPDATE_DUE_DATE             = S.UPDATE_DUE_DATE,
                D.CURRENT_COST_ESTIMATE_IND   = S.CURRENT_COST_ESTIMATE_IND,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_TYPE_CODE, S.COST_ESTIMATE_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_AGN_CODE, S.COST_ESTIMATE_AGN_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_SEQ_NUM, S.COST_ESTIMATE_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_AMOUNT, S.COST_ESTIMATE_AMOUNT, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_DATE, S.COST_ESTIMATE_DATE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_RSN_CODE, S.COST_ESTIMATE_RSN_CODE, 0, 1) = 1
               OR DECODE(D.AREA_UNIT_NOTES_TXT, S.AREA_UNIT_NOTES_TXT, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.UPDATE_DUE_DATE, S.UPDATE_DUE_DATE, 0, 1) = 1
               OR DECODE(D.CURRENT_COST_ESTIMATE_IND, S.CURRENT_COST_ESTIMATE_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_COST_EST_ID,
                    FA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    COST_ESTIMATE_TYPE_CODE,
                    COST_ESTIMATE_AGN_CODE,
                    COST_ESTIMATE_SEQ_NUM,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    COST_ESTIMATE_AMOUNT,
                    COST_ESTIMATE_DATE,
                    COST_ESTIMATE_RSN_CODE,
                    AREA_UNIT_NOTES_TXT,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    UPDATE_DUE_DATE,
                    CURRENT_COST_ESTIMATE_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_COST_EST.NEXTVAL,
                    S.WH_FA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.COST_ESTIMATE_TYPE_CODE,
                    S.COST_ESTIMATE_AGN_CODE,
                    S.COST_ESTIMATE_SEQ_NUM,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.COST_ESTIMATE_AMOUNT,
                    S.COST_ESTIMATE_DATE,
                    S.COST_ESTIMATE_RSN_CODE,
                    S.AREA_UNIT_NOTES_TXT,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.UPDATE_DUE_DATE,
                    S.CURRENT_COST_ESTIMATE_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_MECHANISM_DETAIL AS
    BEGIN
        MERGE INTO RCRA_FA_MECHANISM_DETAIL D
        USING (SELECT *
               FROM ETL_FA_MECHANISM_DETAIL_VW) S
        ON (D.FA_MECHANISM_DETAIL_ID = S.WH_FA_MECHANISM_DETAIL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.MECHANISM_DETAIL_SEQ_NUM     = S.MECHANISM_DETAIL_SEQ_NUM,
                D.MECHANISM_IDEN_TXT           = S.MECHANISM_IDEN_TXT,
                D.FACE_VAL_AMOUNT              = S.FACE_VAL_AMOUNT,
                D.EFFC_DATE                    = S.EFFC_DATE,
                D.EXPIRATION_DATE              = S.EXPIRATION_DATE,
                D.SUPP_INFO_TXT                = S.SUPP_INFO_TXT,
                D.CURRENT_MECHANISM_DETAIL_IND = S.CURRENT_MECHANISM_DETAIL_IND,
                D.CREATED_BY_USERID            = S.CREATED_BY_USERID,
                D.F_CREATED_DATE               = S.F_CREATED_DATE,
                D.DATA_ORIG                    = S.DATA_ORIG,
                D.FAC_FACE_VAL_AMOUNT          = S.FAC_FACE_VAL_AMOUNT,
                D.ALT_IND                      = S.ALT_IND,
                D.LAST_UPDT_BY                 = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE               = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_DETAIL_SEQ_NUM, S.MECHANISM_DETAIL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_IDEN_TXT, S.MECHANISM_IDEN_TXT, 0, 1) = 1
               OR DECODE(D.FACE_VAL_AMOUNT, S.FACE_VAL_AMOUNT, 0, 1) = 1
               OR DECODE(D.EFFC_DATE, S.EFFC_DATE, 0, 1) = 1
               OR DECODE(D.EXPIRATION_DATE, S.EXPIRATION_DATE, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CURRENT_MECHANISM_DETAIL_IND, S.CURRENT_MECHANISM_DETAIL_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.FAC_FACE_VAL_AMOUNT, S.FAC_FACE_VAL_AMOUNT, 0, 1) = 1
               OR DECODE(D.ALT_IND, S.ALT_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_MECHANISM_DETAIL_ID,
                    FA_MECHANISM_ID,
                    TRANS_CODE,
                    MECHANISM_DETAIL_SEQ_NUM,
                    MECHANISM_IDEN_TXT,
                    FACE_VAL_AMOUNT,
                    EFFC_DATE,
                    EXPIRATION_DATE,
                    SUPP_INFO_TXT,
                    CURRENT_MECHANISM_DETAIL_IND,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    FAC_FACE_VAL_AMOUNT,
                    ALT_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_MECHANISM_DETAIL.NEXTVAL,
                    S.WH_FA_MECHANISM_ID,
                    S.TRANS_CODE,
                    S.MECHANISM_DETAIL_SEQ_NUM,
                    S.MECHANISM_IDEN_TXT,
                    S.FACE_VAL_AMOUNT,
                    S.EFFC_DATE,
                    S.EXPIRATION_DATE,
                    S.SUPP_INFO_TXT,
                    S.CURRENT_MECHANISM_DETAIL_IND,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.FAC_FACE_VAL_AMOUNT,
                    S.ALT_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_MECHANISM AS
    BEGIN
        MERGE INTO RCRA_FA_MECHANISM D
        USING (SELECT *
               FROM ETL_FA_MECHANISM_VW) S
        ON (D.FA_MECHANISM_ID = S.WH_FA_MECHANISM_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.MECHANISM_AGN_CODE             = S.MECHANISM_AGN_CODE,
                D.MECHANISM_SEQ_NUM              = S.MECHANISM_SEQ_NUM,
                D.MECHANISM_TYPE_DATA_OWNER_CODE = S.MECHANISM_TYPE_DATA_OWNER_CODE,
                D.MECHANISM_TYPE_CODE            = S.MECHANISM_TYPE_CODE,
                D.PROVIDER_TXT                   = S.PROVIDER_TXT,
                D.PROVIDER_FULL_CONTACT_NAME     = S.PROVIDER_FULL_CONTACT_NAME,
                D.TELE_NUM_TXT                   = S.TELE_NUM_TXT,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.F_CREATED_DATE                 = S.F_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.PROVIDER_CONTACT_EMAIL         = S.PROVIDER_CONTACT_EMAIL,
                D.ACTIVE_MECHANISM_IND           = S.ACTIVE_MECHANISM_IND,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_AGN_CODE, S.MECHANISM_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_SEQ_NUM, S.MECHANISM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_TYPE_DATA_OWNER_CODE, S.MECHANISM_TYPE_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_TYPE_CODE, S.MECHANISM_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.PROVIDER_TXT, S.PROVIDER_TXT, 0, 1) = 1
               OR DECODE(D.PROVIDER_FULL_CONTACT_NAME, S.PROVIDER_FULL_CONTACT_NAME, 0, 1) = 1
               OR DECODE(D.TELE_NUM_TXT, S.TELE_NUM_TXT, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.PROVIDER_CONTACT_EMAIL, S.PROVIDER_CONTACT_EMAIL, 0, 1) = 1
               OR DECODE(D.ACTIVE_MECHANISM_IND, S.ACTIVE_MECHANISM_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_MECHANISM_ID,
                    FA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    MECHANISM_AGN_CODE,
                    MECHANISM_SEQ_NUM,
                    MECHANISM_TYPE_DATA_OWNER_CODE,
                    MECHANISM_TYPE_CODE,
                    PROVIDER_TXT,
                    PROVIDER_FULL_CONTACT_NAME,
                    TELE_NUM_TXT,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    PROVIDER_CONTACT_EMAIL,
                    ACTIVE_MECHANISM_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_MECHANISM.NEXTVAL,
                    S.WH_FA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.MECHANISM_AGN_CODE,
                    S.MECHANISM_SEQ_NUM,
                    S.MECHANISM_TYPE_DATA_OWNER_CODE,
                    S.MECHANISM_TYPE_CODE,
                    S.PROVIDER_TXT,
                    S.PROVIDER_FULL_CONTACT_NAME,
                    S.TELE_NUM_TXT,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.PROVIDER_CONTACT_EMAIL,
                    S.ACTIVE_MECHANISM_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_FA_FAC_SUBM D
        USING (SELECT *
               FROM ETL_FA_FAC_SUBM_VW) S
        ON (D.FA_FAC_SUBM_ID = S.WH_FA_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (D.FA_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_FA_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

-- PRM

    PROCEDURE PRM_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'PM');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       PRM_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_PRM_FAC_SUBM_VW;
    END;

    PROCEDURE PRM_MERGE_RELATED_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_RELATED_EVENT D
        USING (SELECT *
               FROM ETL_PRM_REL_EVENT_VW) S
        ON (D.PRM_RELATED_EVENT_ID = S.WH_PRM_RELATED_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.ACT_LOC_CODE                 = S.ACT_LOC_CODE,
                D.PERMIT_SERIES_SEQ_NUM        = S.PERMIT_SERIES_SEQ_NUM,
                D.PERMIT_EVENT_DATA_OWNER_CODE = S.PERMIT_EVENT_DATA_OWNER_CODE,
                D.PERMIT_EVENT_CODE            = S.PERMIT_EVENT_CODE,
                D.EVENT_AGN_CODE               = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_SEQ_NUM, S.PERMIT_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_DATA_OWNER_CODE, S.PERMIT_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_CODE, S.PERMIT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_RELATED_EVENT_ID,
                    PRM_UNIT_DETAIL_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    PERMIT_SERIES_SEQ_NUM,
                    PERMIT_EVENT_DATA_OWNER_CODE,
                    PERMIT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_PRM_RELATED_EVENT.NEXTVAL,
                    S.WH_PRM_UNIT_DETAIL_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.PERMIT_SERIES_SEQ_NUM,
                    S.PERMIT_EVENT_DATA_OWNER_CODE,
                    S.PERMIT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE PRM_MERGE_EVENT_COMMITMENT AS
    BEGIN
        MERGE INTO RCRA_PRM_EVENT_COMMITMENT D
        USING (SELECT *
               FROM ETL_PRM_EVENT_COMM_VW) S
        ON (D.PRM_EVENT_COMMITMENT_ID = S.WH_PRM_EVENT_COMMITMENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_EVENT_COMMITMENT_ID,
                    PRM_EVENT_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_PRM_EVENT_COMMITMENT.NEXTVAL,
                    S.WH_PRM_EVENT_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE PRM_MERGE_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_EVENT D
        USING (SELECT *
               FROM ETL_PRM_EVENT_VW) S
        ON (D.PRM_EVENT_ID = S.WH_PRM_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.ACT_LOC_CODE                 = S.ACT_LOC_CODE,
                D.PERMIT_EVENT_DATA_OWNER_CODE = S.PERMIT_EVENT_DATA_OWNER_CODE,
                D.PERMIT_EVENT_CODE            = S.PERMIT_EVENT_CODE,
                D.EVENT_AGN_CODE               = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                = S.EVENT_SEQ_NUM,
                D.ACTL_DATE                    = S.ACTL_DATE,
                D.ORIGINAL_SCHEDULE_DATE       = S.ORIGINAL_SCHEDULE_DATE,
                D.NEW_SCHEDULE_DATE            = S.NEW_SCHEDULE_DATE,
                D.RESP_PERSON_DATA_OWNER_CODE  = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID               = S.RESP_PERSON_ID,
                D.EVENT_SUBORG_DATA_OWNER_CODE = S.EVENT_SUBORG_DATA_OWNER_CODE,
                D.EVENT_SUBORG_CODE            = S.EVENT_SUBORG_CODE,
                D.SUPP_INFO_TXT                = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID            = S.CREATED_BY_USERID,
                D.P_CREATED_DATE               = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                 = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE               = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_DATA_OWNER_CODE, S.PERMIT_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_CODE, S.PERMIT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.ACTL_DATE, S.ACTL_DATE, 0, 1) = 1
               OR DECODE(D.ORIGINAL_SCHEDULE_DATE, S.ORIGINAL_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.NEW_SCHEDULE_DATE, S.NEW_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_DATA_OWNER_CODE, S.EVENT_SUBORG_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_CODE, S.EVENT_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_EVENT_ID,
                    PRM_SERIES_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    PERMIT_EVENT_DATA_OWNER_CODE,
                    PERMIT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM,
                    ACTL_DATE,
                    ORIGINAL_SCHEDULE_DATE,
                    NEW_SCHEDULE_DATE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    EVENT_SUBORG_DATA_OWNER_CODE,
                    EVENT_SUBORG_CODE,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_EVENT.NEXTVAL,
                    S.WH_PRM_SERIES_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.PERMIT_EVENT_DATA_OWNER_CODE,
                    S.PERMIT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM,
                    S.ACTL_DATE,
                    S.ORIGINAL_SCHEDULE_DATE,
                    S.NEW_SCHEDULE_DATE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.EVENT_SUBORG_DATA_OWNER_CODE,
                    S.EVENT_SUBORG_CODE,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_MOD_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_MOD_EVENT D
        USING (SELECT *
               FROM ETL_PRM_MOD_EVENT_VW) S
        ON (D.PRM_MOD_EVENT_ID = S.WH_PRM_MOD_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                = S.TRANS_CODE,
                D.MOD_HANDLER_ID            = S.MOD_HANDLER_ID,
                D.MOD_ACT_LOC_CODE          = S.MOD_ACT_LOC_CODE,
                D.MOD_SERIES_SEQ_NUM        = S.MOD_SERIES_SEQ_NUM,
                D.MOD_EVENT_SEQ_NUM         = S.MOD_EVENT_SEQ_NUM,
                D.MOD_EVENT_AGN_CODE        = S.MOD_EVENT_AGN_CODE,
                D.MOD_EVENT_DATA_OWNER_CODE = S.MOD_EVENT_DATA_OWNER_CODE,
                D.MOD_EVENT_CODE            = S.MOD_EVENT_CODE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MOD_HANDLER_ID, S.MOD_HANDLER_ID, 0, 1) = 1
               OR DECODE(D.MOD_ACT_LOC_CODE, S.MOD_ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MOD_SERIES_SEQ_NUM, S.MOD_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_SEQ_NUM, S.MOD_EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_AGN_CODE, S.MOD_EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_DATA_OWNER_CODE, S.MOD_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_CODE, S.MOD_EVENT_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_MOD_EVENT_ID,
                    PRM_EVENT_ID,
                    TRANS_CODE,
                    MOD_HANDLER_ID,
                    MOD_ACT_LOC_CODE,
                    MOD_SERIES_SEQ_NUM,
                    MOD_EVENT_SEQ_NUM,
                    MOD_EVENT_AGN_CODE,
                    MOD_EVENT_DATA_OWNER_CODE,
                    MOD_EVENT_CODE)
            VALUES (SEQ_RCRA_PRM_MOD_EVENT.NEXTVAL,
                    S.WH_PRM_EVENT_ID,
                    S.TRANS_CODE,
                    S.MOD_HANDLER_ID,
                    S.MOD_ACT_LOC_CODE,
                    S.MOD_SERIES_SEQ_NUM,
                    S.MOD_EVENT_SEQ_NUM,
                    S.MOD_EVENT_AGN_CODE,
                    S.MOD_EVENT_DATA_OWNER_CODE,
                    S.MOD_EVENT_CODE);
    END;

    PROCEDURE PRM_MERGE_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_PRM_WASTE_CODE D
        USING (SELECT *
               FROM ETL_PRM_WASTE_CODE_VW) S
        ON (D.PRM_WASTE_CODE_ID = S.WH_PRM_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_WASTE_CODE_ID,
                    PRM_UNIT_DETAIL_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE_TYPE)
            VALUES (SEQ_RCRA_PRM_WASTE_CODE.NEXTVAL,
                    S.WH_PRM_UNIT_DETAIL_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE_TYPE);
    END;

    PROCEDURE PRM_MERGE_UNIT_DETAIL AS
    BEGIN
        MERGE INTO RCRA_PRM_UNIT_DETAIL D
        USING (SELECT *
               FROM ETL_PRM_UNIT_DETAIL_VW) S
        ON (D.PRM_UNIT_DETAIL_ID = S.WH_PRM_UNIT_DETAIL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.PROC_UNIT_DATA_OWNER_CODE      = S.PROC_UNIT_DATA_OWNER_CODE,
                D.PROC_UNIT_CODE                 = S.PROC_UNIT_CODE,
                D.PERMIT_STAT_EFFC_DATE          = S.PERMIT_STAT_EFFC_DATE,
                D.PERMIT_UNIT_CAP_QNTY           = S.PERMIT_UNIT_CAP_QNTY,
                D.CAP_TYPE_CODE                  = S.CAP_TYPE_CODE,
                D.COMMER_STAT_CODE               = S.COMMER_STAT_CODE,
                D.LEGAL_OPER_STAT_DATA_OWNER_CDE = S.LEGAL_OPER_STAT_DATA_OWNER_CDE,
                D.LEGAL_OPER_STAT_CODE           = S.LEGAL_OPER_STAT_CODE,
                D.MEASUREMENT_UNIT_DATA_OWNR_CDE = S.MEASUREMENT_UNIT_DATA_OWNR_CDE,
                D.MEASUREMENT_UNIT_CODE          = S.MEASUREMENT_UNIT_CODE,
                D.NUM_OF_UNITS_COUNT             = S.NUM_OF_UNITS_COUNT,
                D.STANDARD_PERMIT_IND            = S.STANDARD_PERMIT_IND,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CURRENT_UNIT_DETAIL_IND        = S.CURRENT_UNIT_DETAIL_IND,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.P_CREATED_DATE                 = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_DETAIL_SEQ_NUM, S.PERMIT_UNIT_DETAIL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PROC_UNIT_DATA_OWNER_CODE, S.PROC_UNIT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PROC_UNIT_CODE, S.PROC_UNIT_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_STAT_EFFC_DATE, S.PERMIT_STAT_EFFC_DATE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_CAP_QNTY, S.PERMIT_UNIT_CAP_QNTY, 0, 1) = 1
               OR DECODE(D.CAP_TYPE_CODE, S.CAP_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.COMMER_STAT_CODE, S.COMMER_STAT_CODE, 0, 1) = 1
               OR DECODE(D.LEGAL_OPER_STAT_DATA_OWNER_CDE, S.LEGAL_OPER_STAT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.LEGAL_OPER_STAT_CODE, S.LEGAL_OPER_STAT_CODE, 0, 1) = 1
               OR DECODE(D.MEASUREMENT_UNIT_DATA_OWNR_CDE, S.MEASUREMENT_UNIT_DATA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.MEASUREMENT_UNIT_CODE, S.MEASUREMENT_UNIT_CODE, 0, 1) = 1
               OR DECODE(D.NUM_OF_UNITS_COUNT, S.NUM_OF_UNITS_COUNT, 0, 1) = 1
               OR DECODE(D.STANDARD_PERMIT_IND, S.STANDARD_PERMIT_IND, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CURRENT_UNIT_DETAIL_IND, S.CURRENT_UNIT_DETAIL_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_UNIT_DETAIL_ID,
                    PRM_UNIT_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_DETAIL_SEQ_NUM,
                    PROC_UNIT_DATA_OWNER_CODE,
                    PROC_UNIT_CODE,
                    PERMIT_STAT_EFFC_DATE,
                    PERMIT_UNIT_CAP_QNTY,
                    CAP_TYPE_CODE,
                    COMMER_STAT_CODE,
                    LEGAL_OPER_STAT_DATA_OWNER_CDE,
                    LEGAL_OPER_STAT_CODE,
                    MEASUREMENT_UNIT_DATA_OWNR_CDE,
                    MEASUREMENT_UNIT_CODE,
                    NUM_OF_UNITS_COUNT,
                    STANDARD_PERMIT_IND,
                    SUPP_INFO_TXT,
                    CURRENT_UNIT_DETAIL_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_UNIT_DETAIL.NEXTVAL,
                    S.WH_PRM_UNIT_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_DETAIL_SEQ_NUM,
                    S.PROC_UNIT_DATA_OWNER_CODE,
                    S.PROC_UNIT_CODE,
                    S.PERMIT_STAT_EFFC_DATE,
                    S.PERMIT_UNIT_CAP_QNTY,
                    S.CAP_TYPE_CODE,
                    S.COMMER_STAT_CODE,
                    S.LEGAL_OPER_STAT_DATA_OWNER_CDE,
                    S.LEGAL_OPER_STAT_CODE,
                    S.MEASUREMENT_UNIT_DATA_OWNR_CDE,
                    S.MEASUREMENT_UNIT_CODE,
                    S.NUM_OF_UNITS_COUNT,
                    S.STANDARD_PERMIT_IND,
                    S.SUPP_INFO_TXT,
                    S.CURRENT_UNIT_DETAIL_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_UNIT AS
    BEGIN
        MERGE INTO RCRA_PRM_UNIT D
        USING (SELECT *
               FROM ETL_PRM_UNIT_VW) S
        ON (D.PRM_UNIT_ID = S.WH_PRM_UNIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.PERMIT_UNIT_SEQ_NUM = S.PERMIT_UNIT_SEQ_NUM,
                D.PERMIT_UNIT_NAME    = S.PERMIT_UNIT_NAME,
                D.SUPP_INFO_TXT       = S.SUPP_INFO_TXT,
                D.ACTIVE_UNIT_IND     = S.ACTIVE_UNIT_IND,
                D.CREATED_BY_USERID   = S.CREATED_BY_USERID,
                D.P_CREATED_DATE      = S.P_CREATED_DATE,
                D.LAST_UPDT_BY        = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE      = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_NAME, S.PERMIT_UNIT_NAME, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.ACTIVE_UNIT_IND, S.ACTIVE_UNIT_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_UNIT_ID,
                    PRM_FAC_SUBM_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_SEQ_NUM,
                    PERMIT_UNIT_NAME,
                    SUPP_INFO_TXT,
                    ACTIVE_UNIT_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_UNIT.NEXTVAL,
                    S.WH_PRM_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_SEQ_NUM,
                    S.PERMIT_UNIT_NAME,
                    S.SUPP_INFO_TXT,
                    S.ACTIVE_UNIT_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_SERIES AS
    BEGIN
        MERGE INTO RCRA_PRM_SERIES D
        USING (SELECT *
               FROM ETL_PRM_SERIES_VW) S
        ON (D.PRM_SERIES_ID = S.WH_PRM_SERIES_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.PERMIT_SERIES_SEQ_NUM       = S.PERMIT_SERIES_SEQ_NUM,
                D.PERMIT_SERIES_NAME          = S.PERMIT_SERIES_NAME,
                D.RESP_PERSON_DATA_OWNER_CODE = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID              = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT               = S.SUPP_INFO_TXT,
                D.ACTIVE_SERIES_IND           = S.ACTIVE_SERIES_IND,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.P_CREATED_DATE              = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_SEQ_NUM, S.PERMIT_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_NAME, S.PERMIT_SERIES_NAME, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.ACTIVE_SERIES_IND, S.ACTIVE_SERIES_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_SERIES_ID,
                    PRM_FAC_SUBM_ID,
                    TRANS_CODE,
                    PERMIT_SERIES_SEQ_NUM,
                    PERMIT_SERIES_NAME,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    ACTIVE_SERIES_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_SERIES.NEXTVAL,
                    S.WH_PRM_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.PERMIT_SERIES_SEQ_NUM,
                    S.PERMIT_SERIES_NAME,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.ACTIVE_SERIES_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_PRM_FAC_SUBM D
        USING (SELECT *
               FROM ETL_PRM_FAC_SUBM_VW) S
        ON (D.PRM_FAC_SUBM_ID = S.WH_PRM_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (PRM_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_PRM_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

-- HD

    PROCEDURE HD_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'HD');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       HD_HBASIC_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_HD_BASIC_VW;
    END;

    PROCEDURE HD_MERGE_HBASIC AS
    BEGIN
        MERGE INTO RCRA_HD_HBASIC D
        USING (SELECT *
               FROM ETL_HD_BASIC_VW) S
            --INNER JOIN NODE_RCRA_HD_HBASIC ON NODE_RCRA_HD_HBASIC.HANDLER_ID = ETL_HD_BASIC_VW.HANDLER_ID) S
        ON (D.HD_HBASIC_ID = S.WH_HD_HBASIC_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.FACILITY_IDENTIFIER = S.FACILITY_IDENTIFIER,
                D.EXTRACT_FLAG        = S.EXTRACT_FLAG,
                D.TRANSACTION_CODE    = S.TRANSACTION_CODE
            WHERE DECODE(D.FACILITY_IDENTIFIER, S.FACILITY_IDENTIFIER, 0, 1) = 1
               OR DECODE(D.EXTRACT_FLAG, S.EXTRACT_FLAG, 0, 1) = 1
               OR DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT
            (HD_HBASIC_ID,
             TRANSACTION_CODE,
             HANDLER_ID,
             EXTRACT_FLAG,
             FACILITY_IDENTIFIER)
            VALUES (SEQ_RCRA_HD_HBASIC.NEXTVAL,
                    S.TRANSACTION_CODE,
                    S.HANDLER_ID,
                    S.EXTRACT_FLAG,
                    S.FACILITY_IDENTIFIER);
    END;

    PROCEDURE HD_MERGE_HANDLER AS
    BEGIN
        MERGE INTO RCRA_HD_HANDLER D
        USING (SELECT *
               FROM ETL_HD_HANDLER_VW) S
        ON (D.HD_HANDLER_ID = S.WH_HD_HANDLER_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE               = S.TRANSACTION_CODE,
                D.ACTIVITY_LOCATION              = S.ACTIVITY_LOCATION,
                D.SOURCE_TYPE                    = S.SOURCE_TYPE,
                D.RECEIVE_DATE                   = S.RECEIVE_DATE,
                D.HANDLER_NAME                   = S.HANDLER_NAME,
                D.ACKNOWLEDGE_DATE               = S.ACKNOWLEDGE_DATE,
                D.NON_NOTIFIER                   = S.NON_NOTIFIER,
                D.OFF_SITE_RECEIPT               = S.OFF_SITE_RECEIPT,
                D.ACCESSIBILITY                  = S.ACCESSIBILITY,
                D.COUNTY_CODE_OWNER              = S.COUNTY_CODE_OWNER,
                D.COUNTY_CODE                    = S.COUNTY_CODE,
                D.NOTES                          = S.NOTES,
                D.ACKNOWLEDGE_FLAG               = S.ACKNOWLEDGE_FLAG,
                D.LOCATION_STREET1               = S.LOCATION_STREET1,
                D.LOCATION_STREET2               = S.LOCATION_STREET2,
                D.LOCATION_CITY                  = S.LOCATION_CITY,
                D.LOCATION_STATE                 = S.LOCATION_STATE,
                D.LOCATION_COUNTRY               = S.LOCATION_COUNTRY,
                D.LOCATION_ZIP                   = S.LOCATION_ZIP,
                D.MAIL_STREET1                   = S.MAIL_STREET1,
                D.MAIL_STREET2                   = S.MAIL_STREET2,
                D.MAIL_CITY                      = S.MAIL_CITY,
                D.MAIL_STATE                     = S.MAIL_STATE,
                D.MAIL_COUNTRY                   = S.MAIL_COUNTRY,
                D.MAIL_ZIP                       = S.MAIL_ZIP,
                D.CONTACT_FIRST_NAME             = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL         = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME              = S.CONTACT_LAST_NAME,
                D.CONTACT_ORG_NAME               = S.CONTACT_ORG_NAME,
                D.CONTACT_TITLE                  = D.CONTACT_TITLE,
                D.CONTACT_EMAIL_ADDRESS          = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE                  = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT              = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX                    = S.CONTACT_FAX,
                D.CONTACT_STREET1                = S.CONTACT_STREET1,
                D.CONTACT_STREET2                = S.CONTACT_STREET2,
                D.CONTACT_CITY                   = S.CONTACT_CITY,
                D.CONTACT_STATE                  = S.CONTACT_STATE,
                D.CONTACT_COUNTRY                = S.CONTACT_COUNTRY,
                D.CONTACT_ZIP                    = S.CONTACT_ZIP,
                D.PCONTACT_FIRST_NAME            = S.PCONTACT_FIRST_NAME,
                D.PCONTACT_MIDDLE_NAME           = S.PCONTACT_MIDDLE_NAME,
                D.PCONTACT_LAST_NAME             = S.PCONTACT_LAST_NAME,
                D.PCONTACT_ORG_NAME              = S.PCONTACT_ORG_NAME,
                D.PCONTACT_TITLE                 = D.PCONTACT_TITLE,
                D.PCONTACT_EMAIL_ADDRESS         = S.PCONTACT_EMAIL_ADDRESS,
                D.PCONTACT_PHONE                 = S.PCONTACT_PHONE,
                D.PCONTACT_PHONE_EXT             = S.PCONTACT_PHONE_EXT,
                D.PCONTACT_FAX                   = S.PCONTACT_FAX,
                D.PCONTACT_STREET1               = S.PCONTACT_STREET1,
                D.PCONTACT_STREET2               = S.PCONTACT_STREET2,
                D.PCONTACT_CITY                  = S.PCONTACT_CITY,
                D.PCONTACT_STATE                 = S.PCONTACT_STATE,
                D.PCONTACT_COUNTRY               = S.PCONTACT_COUNTRY,
                D.PCONTACT_ZIP                   = S.PCONTACT_ZIP,
                D.USED_OIL_BURNER                = S.USED_OIL_BURNER,
                D.USED_OIL_PROCESSOR             = S.USED_OIL_PROCESSOR,
                D.USED_OIL_REFINER               = S.USED_OIL_REFINER,
                D.USED_OIL_MARKET_BURNER         = S.USED_OIL_MARKET_BURNER,
                D.USED_OIL_SPEC_MARKETER         = S.USED_OIL_SPEC_MARKETER,
                D.USED_OIL_TRANSFER_FACILITY     = S.USED_OIL_TRANSFER_FACILITY,
                D.USED_OIL_TRANSPORTER           = S.USED_OIL_TRANSPORTER,
                D.LAND_TYPE                      = S.LAND_TYPE,
                D.STATE_DISTRICT_OWNER           = S.STATE_DISTRICT_OWNER,
                D.STATE_DISTRICT                 = S.STATE_DISTRICT,
                D.IMPORTER_ACTIVITY              = S.IMPORTER_ACTIVITY,
                D.MIXED_WASTE_GENERATOR          = S.MIXED_WASTE_GENERATOR,
                D.RECYCLER_ACTIVITY              = S.RECYCLER_ACTIVITY,
                D.TRANSPORTER_ACTIVITY           = S.TRANSPORTER_ACTIVITY,
                D.TSD_ACTIVITY                   = S.TSD_ACTIVITY,
                D.UNDERGROUND_INJECTION_ACTIVITY = S.UNDERGROUND_INJECTION_ACTIVITY,
                D.ONSITE_BURNER_EXEMPTION        = S.ONSITE_BURNER_EXEMPTION,
                D.FURNACE_EXEMPTION              = S.FURNACE_EXEMPTION,
                D.SHORT_TERM_GEN_IND             = S.SHORT_TERM_GEN_IND,
                D.TRANSFER_FACILITY_IND          = S.TRANSFER_FACILITY_IND,
                D.COLLEGE_IND                    = S.COLLEGE_IND,
                D.HOSPITAL_IND                   = S.HOSPITAL_IND,
                D.NON_PROFIT_IND                 = S.NON_PROFIT_IND,
                D.WITHDRAWAL_IND                 = S.WITHDRAWAL_IND,
                D.TRANS_CODE                     = S.TRANS_CODE,
                D.NOTIFICATION_RSN_CODE          = S.NOTIFICATION_RSN_CODE,
                D.EFFC_DATE                      = S.EFFC_DATE,
                D.FINANCIAL_ASSURANCE_IND        = S.FINANCIAL_ASSURANCE_IND,
                D.RECYCLING_IND                  = S.RECYCLING_IND,
                D.MAIL_STREET_NUMBER             = S.MAIL_STREET_NUMBER,
                D.LOCATION_STREET_NUMBER         = S.LOCATION_STREET_NUMBER,
                D.NON_NOTIFIER_TEXT              = S.NON_NOTIFIER_TEXT,
                D.ACCESSIBILITY_TEXT             = S.ACCESSIBILITY_TEXT,
                D.STATE_DISTRICT_TEXT            = S.STATE_DISTRICT_TEXT,
                D.INTRNL_NOTES                   = S.INTRNL_NOTES,
                D.SHORT_TERM_INTRNL_NOTES        = S.SHORT_TERM_INTRNL_NOTES,
                D.NATURE_OF_BUSINESS_TEXT        = S.NATURE_OF_BUSINESS_TEXT,
                D.SLAB_EXPORTER_IND              = S.SLAB_EXPORTER_IND,
                D.SLAB_IMPORTER_IND              = S.SLAB_IMPORTER_IND,
                D.RECOGNIZED_TRADER_EXPORTER_IND = S.RECOGNIZED_TRADER_EXPORTER_IND,
                D.RECOGNIZED_TRADER_IMPORTER_IND = S.RECOGNIZED_TRADER_IMPORTER_IND,
                D.TSD_DATE                       = S.TSD_DATE,
                D.UNIVERSAL_WASTE_DEST_FACILITY  = S.UNIVERSAL_WASTE_DEST_FACILITY,
                D.STATE_WASTE_GENERATOR_OWNER    = S.STATE_WASTE_GENERATOR_OWNER,
                D.STATE_WASTE_GENERATOR          = S.STATE_WASTE_GENERATOR,
                D.FED_WASTE_GENERATOR_OWNER      = S.FED_WASTE_GENERATOR_OWNER,
                D.FED_WASTE_GENERATOR            = S.FED_WASTE_GENERATOR,
                D.ACKNOWLEDGE_FLAG_IND           = S.ACKNOWLEDGE_FLAG_IND,
                D.INCLUDE_IN_NATIONAL_REPORT_IND = S.INCLUDE_IN_NATIONAL_REPORT_IND,
                D.LQHUW_IND                      = S.LQHUW_IND,
                D.HD_REPORT_CYCLE_YEAR           = S.HD_REPORT_CYCLE_YEAR,
                D.HEALTHCARE_FAC                 = S.HEALTHCARE_FAC,
                D.REVERSE_DISTRIBUTOR            = S.REVERSE_DISTRIBUTOR,
                D.SUBPART_P_WITHDRAWAL           = S.SUBPART_P_WITHDRAWAL,
                D.RECYCLER_IND                   = S.RECYCLER_IND,
                D.CURRENT_RECORD                 = S.CURRENT_RECORD,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.H_CREATED_DATE                 = S.H_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LOCATION_LATITUDE              = S.LOCATION_LATITUDE,
                D.LOCATION_LONGITUDE             = S.LOCATION_LONGITUDE,
                D.LOCATION_GIS_PRIM              = S.LOCATION_GIS_PRIM,
                D.LOCATION_GIS_ORIG              = S.LOCATION_GIS_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE,
                D.BR_EXEMPT_IND                  = S.BR_EXEMPT_IND
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.ACTIVITY_LOCATION, S.ACTIVITY_LOCATION, 0, 1) = 1
               OR DECODE(D.SOURCE_TYPE, S.SOURCE_TYPE, 0, 1) = 1
               OR DECODE(D.RECEIVE_DATE, S.RECEIVE_DATE, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_DATE, S.ACKNOWLEDGE_DATE, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER, S.NON_NOTIFIER, 0, 1) = 1
               OR DECODE(D.OFF_SITE_RECEIPT, S.OFF_SITE_RECEIPT, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY, S.ACCESSIBILITY, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE_OWNER, S.COUNTY_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE, S.COUNTY_CODE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_FLAG, S.ACKNOWLEDGE_FLAG, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET1, S.LOCATION_STREET1, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET2, S.LOCATION_STREET2, 0, 1) = 1
               OR DECODE(D.LOCATION_CITY, S.LOCATION_CITY, 0, 1) = 1
               OR DECODE(D.LOCATION_STATE, S.LOCATION_STATE, 0, 1) = 1
               OR DECODE(D.LOCATION_COUNTRY, S.LOCATION_COUNTRY, 0, 1) = 1
               OR DECODE(D.LOCATION_ZIP, S.LOCATION_ZIP, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_COUNTRY, S.MAIL_COUNTRY, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_ORG_NAME, S.CONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET1, S.CONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET2, S.CONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.CONTACT_CITY, S.CONTACT_CITY, 0, 1) = 1
               OR DECODE(D.CONTACT_STATE, S.CONTACT_STATE, 0, 1) = 1
               OR DECODE(D.CONTACT_COUNTRY, S.CONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.CONTACT_ZIP, S.CONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.PCONTACT_FIRST_NAME, S.PCONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_MIDDLE_NAME, S.PCONTACT_MIDDLE_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_LAST_NAME, S.PCONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_ORG_NAME, S.PCONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_TITLE, S.PCONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.PCONTACT_EMAIL_ADDRESS, S.PCONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.PCONTACT_PHONE, S.PCONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.PCONTACT_PHONE_EXT, S.PCONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.PCONTACT_FAX, S.PCONTACT_FAX, 0, 1) = 1
               OR DECODE(D.PCONTACT_STREET1, S.PCONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.PCONTACT_STREET2, S.PCONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.PCONTACT_CITY, S.PCONTACT_CITY, 0, 1) = 1
               OR DECODE(D.PCONTACT_STATE, S.PCONTACT_STATE, 0, 1) = 1
               OR DECODE(D.PCONTACT_COUNTRY, S.PCONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.PCONTACT_ZIP, S.PCONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.USED_OIL_BURNER, S.USED_OIL_BURNER, 0, 1) = 1
               OR DECODE(D.USED_OIL_PROCESSOR, S.USED_OIL_PROCESSOR, 0, 1) = 1
               OR DECODE(D.USED_OIL_REFINER, S.USED_OIL_REFINER, 0, 1) = 1
               OR DECODE(D.USED_OIL_MARKET_BURNER, S.USED_OIL_MARKET_BURNER, 0, 1) = 1
               OR DECODE(D.USED_OIL_SPEC_MARKETER, S.USED_OIL_SPEC_MARKETER, 0, 1) = 1
               OR DECODE(D.USED_OIL_TRANSFER_FACILITY, S.USED_OIL_TRANSFER_FACILITY, 0, 1) = 1
               OR DECODE(D.USED_OIL_TRANSPORTER, S.USED_OIL_TRANSPORTER, 0, 1) = 1
               OR DECODE(D.LAND_TYPE, S.LAND_TYPE, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_OWNER, S.STATE_DISTRICT_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT, S.STATE_DISTRICT, 0, 1) = 1
               OR DECODE(D.IMPORTER_ACTIVITY, S.IMPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.MIXED_WASTE_GENERATOR, S.MIXED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.RECYCLER_ACTIVITY, S.RECYCLER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TRANSPORTER_ACTIVITY, S.TRANSPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TSD_ACTIVITY, S.TSD_ACTIVITY, 0, 1) = 1
               OR DECODE(D.UNDERGROUND_INJECTION_ACTIVITY, S.UNDERGROUND_INJECTION_ACTIVITY, 0, 1) = 1
               OR DECODE(D.ONSITE_BURNER_EXEMPTION, S.ONSITE_BURNER_EXEMPTION, 0, 1) = 1
               OR DECODE(D.FURNACE_EXEMPTION, S.FURNACE_EXEMPTION, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_GEN_IND, S.SHORT_TERM_GEN_IND, 0, 1) = 1
               OR DECODE(D.TRANSFER_FACILITY_IND, S.TRANSFER_FACILITY_IND, 0, 1) = 1
               OR DECODE(D.COLLEGE_IND, S.COLLEGE_IND, 0, 1) = 1
               OR DECODE(D.HOSPITAL_IND, S.HOSPITAL_IND, 0, 1) = 1
               OR DECODE(D.NON_PROFIT_IND, S.NON_PROFIT_IND, 0, 1) = 1
               OR DECODE(D.WITHDRAWAL_IND, S.WITHDRAWAL_IND, 0, 1) = 1
               OR DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.NOTIFICATION_RSN_CODE, S.NOTIFICATION_RSN_CODE, 0, 1) = 1
               OR DECODE(D.EFFC_DATE, S.EFFC_DATE, 0, 1) = 1
               OR DECODE(D.FINANCIAL_ASSURANCE_IND, S.FINANCIAL_ASSURANCE_IND, 0, 1) = 1
               OR DECODE(D.RECYCLING_IND, S.RECYCLING_IND, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET_NUMBER, S.LOCATION_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER_TEXT, S.NON_NOTIFIER_TEXT, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY_TEXT, S.ACCESSIBILITY_TEXT, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_TEXT, S.STATE_DISTRICT_TEXT, 0, 1) = 1
               OR DECODE(D.INTRNL_NOTES, S.STATE_DISTRICT_TEXT, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_INTRNL_NOTES, S.SHORT_TERM_INTRNL_NOTES, 0, 1) = 1
               OR DECODE(D.NATURE_OF_BUSINESS_TEXT, S.NATURE_OF_BUSINESS_TEXT, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_EXPORTER_IND, S.RECOGNIZED_TRADER_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_IMPORTER_IND, S.RECOGNIZED_TRADER_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_EXPORTER_IND, S.SLAB_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_IMPORTER_IND, S.SLAB_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.TSD_DATE, S.TSD_DATE, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_DEST_FACILITY, S.UNIVERSAL_WASTE_DEST_FACILITY, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR_OWNER, S.STATE_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR, S.STATE_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR_OWNER, S.FED_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR, S.FED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_FLAG_IND, S.ACKNOWLEDGE_FLAG_IND, 0, 1) = 1
               OR DECODE(D.INCLUDE_IN_NATIONAL_REPORT_IND, S.INCLUDE_IN_NATIONAL_REPORT_IND, 0, 1) = 1
               OR DECODE(D.LQHUW_IND, S.LQHUW_IND, 0, 1) = 1
               OR DECODE(D.HD_REPORT_CYCLE_YEAR, S.HD_REPORT_CYCLE_YEAR, 0, 1) = 1
               OR DECODE(D.HEALTHCARE_FAC, S.HEALTHCARE_FAC, 0, 1) = 1
               OR DECODE(D.REVERSE_DISTRIBUTOR, S.REVERSE_DISTRIBUTOR, 0, 1) = 1
               OR DECODE(D.SUBPART_P_WITHDRAWAL, S.SUBPART_P_WITHDRAWAL, 0, 1) = 1
               OR DECODE(D.RECYCLER_IND, S.RECYCLER_IND, 0, 1) = 1
               OR DECODE(D.CURRENT_RECORD, S.CURRENT_RECORD, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.H_CREATED_DATE, S.H_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LOCATION_LATITUDE, S.LOCATION_LATITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_LONGITUDE, S.LOCATION_LONGITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_PRIM, S.LOCATION_GIS_PRIM, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_ORIG, S.LOCATION_GIS_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
               OR DECODE(D.BR_EXEMPT_IND, S.BR_EXEMPT_IND, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT
            (HD_HANDLER_ID,
             HD_HBASIC_ID,
             TRANSACTION_CODE,
             ACTIVITY_LOCATION,
             SEQ_NUMBER,
             SOURCE_TYPE,
             RECEIVE_DATE,
             HANDLER_NAME,
             ACKNOWLEDGE_DATE,
             NON_NOTIFIER,
             OFF_SITE_RECEIPT,
             ACCESSIBILITY,
             COUNTY_CODE_OWNER,
             COUNTY_CODE,
             NOTES,
             ACKNOWLEDGE_FLAG,
             LOCATION_STREET1,
             LOCATION_STREET2,
             LOCATION_CITY,
             LOCATION_STATE,
             LOCATION_COUNTRY,
             LOCATION_ZIP,
             MAIL_STREET1,
             MAIL_STREET2,
             MAIL_CITY,
             MAIL_STATE,
             MAIL_COUNTRY,
             MAIL_ZIP,
             CONTACT_FIRST_NAME,
             CONTACT_MIDDLE_INITIAL,
             CONTACT_LAST_NAME,
             CONTACT_ORG_NAME,
             CONTACT_TITLE,
             CONTACT_EMAIL_ADDRESS,
             CONTACT_PHONE,
             CONTACT_PHONE_EXT,
             CONTACT_FAX,
             CONTACT_STREET1,
             CONTACT_STREET2,
             CONTACT_CITY,
             CONTACT_STATE,
             CONTACT_COUNTRY,
             CONTACT_ZIP,
             PCONTACT_FIRST_NAME,
             PCONTACT_MIDDLE_NAME,
             PCONTACT_LAST_NAME,
             PCONTACT_ORG_NAME,
             PCONTACT_TITLE,
             PCONTACT_EMAIL_ADDRESS,
             PCONTACT_PHONE,
             PCONTACT_PHONE_EXT,
             PCONTACT_FAX,
             PCONTACT_STREET1,
             PCONTACT_STREET2,
             PCONTACT_CITY,
             PCONTACT_STATE,
             PCONTACT_COUNTRY,
             PCONTACT_ZIP,
             USED_OIL_BURNER,
             USED_OIL_PROCESSOR,
             USED_OIL_REFINER,
             USED_OIL_MARKET_BURNER,
             USED_OIL_SPEC_MARKETER,
             USED_OIL_TRANSFER_FACILITY,
             USED_OIL_TRANSPORTER,
             LAND_TYPE,
             STATE_DISTRICT_OWNER,
             STATE_DISTRICT,
             IMPORTER_ACTIVITY,
             MIXED_WASTE_GENERATOR,
             RECYCLER_ACTIVITY,
             TRANSPORTER_ACTIVITY,
             TSD_ACTIVITY,
             UNDERGROUND_INJECTION_ACTIVITY,
             ONSITE_BURNER_EXEMPTION,
             FURNACE_EXEMPTION,
             SHORT_TERM_GEN_IND,
             TRANSFER_FACILITY_IND,
             COLLEGE_IND,
             HOSPITAL_IND,
             NON_PROFIT_IND,
             WITHDRAWAL_IND,
             TRANS_CODE,
             NOTIFICATION_RSN_CODE,
             EFFC_DATE,
             FINANCIAL_ASSURANCE_IND,
             RECYCLING_IND,
             MAIL_STREET_NUMBER,
             LOCATION_STREET_NUMBER,
             NON_NOTIFIER_TEXT,
             ACCESSIBILITY_TEXT,
             STATE_DISTRICT_TEXT,
             INTRNL_NOTES,
             SHORT_TERM_INTRNL_NOTES,
             NATURE_OF_BUSINESS_TEXT,
             RECOGNIZED_TRADER_EXPORTER_IND,
             RECOGNIZED_TRADER_IMPORTER_IND,
             SLAB_EXPORTER_IND,
             SLAB_IMPORTER_IND,
             TSD_DATE,
             UNIVERSAL_WASTE_DEST_FACILITY,
             STATE_WASTE_GENERATOR_OWNER,
             STATE_WASTE_GENERATOR,
             FED_WASTE_GENERATOR_OWNER,
             FED_WASTE_GENERATOR,
             ACKNOWLEDGE_FLAG_IND,
             INCLUDE_IN_NATIONAL_REPORT_IND,
             LQHUW_IND,
             HD_REPORT_CYCLE_YEAR,
             HEALTHCARE_FAC,
             REVERSE_DISTRIBUTOR,
             SUBPART_P_WITHDRAWAL,
             RECYCLER_IND,
             CURRENT_RECORD,
             CREATED_BY_USERID,
             H_CREATED_DATE,
             DATA_ORIG,
             LOCATION_LATITUDE,
             LOCATION_LONGITUDE,
             LOCATION_GIS_PRIM,
             LOCATION_GIS_ORIG,
             LAST_UPDT_BY,
             LAST_UPDT_DATE,
             BR_EXEMPT_IND)
            VALUES (SEQ_RCRA_HD_HANDLER.NEXTVAL,
                    S.WH_HD_HBASIC_ID,
                    S.TRANSACTION_CODE,
                    S.ACTIVITY_LOCATION,
                    S.SEQ_NUMBER,
                    S.SOURCE_TYPE,
                    S.RECEIVE_DATE,
                    S.HANDLER_NAME,
                    S.ACKNOWLEDGE_DATE,
                    S.NON_NOTIFIER,
                    S.OFF_SITE_RECEIPT,
                    S.ACCESSIBILITY,
                    S.COUNTY_CODE_OWNER,
                    S.COUNTY_CODE,
                    S.NOTES,
                    S.ACKNOWLEDGE_FLAG,
                    s.LOCATION_STREET1,
                    S.LOCATION_STREET2,
                    S.LOCATION_CITY,
                    S.LOCATION_STATE,
                    S.LOCATION_COUNTRY,
                    S.LOCATION_ZIP,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_ORG_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX,
                    S.CONTACT_STREET1,
                    S.CONTACT_STREET2,
                    S.CONTACT_CITY,
                    S.CONTACT_STATE,
                    S.CONTACT_COUNTRY,
                    S.CONTACT_ZIP,
                    S.PCONTACT_FIRST_NAME,
                    S.PCONTACT_MIDDLE_NAME,
                    S.PCONTACT_LAST_NAME,
                    S.PCONTACT_ORG_NAME,
                    S.PCONTACT_TITLE,
                    S.PCONTACT_EMAIL_ADDRESS,
                    S.PCONTACT_PHONE,
                    S.PCONTACT_PHONE_EXT,
                    S.PCONTACT_FAX,
                    S.PCONTACT_STREET1,
                    S.PCONTACT_STREET2,
                    S.PCONTACT_CITY,
                    S.PCONTACT_STATE,
                    S.PCONTACT_COUNTRY,
                    S.PCONTACT_ZIP,
                    S.USED_OIL_BURNER,
                    S.USED_OIL_PROCESSOR,
                    S.USED_OIL_REFINER,
                    S.USED_OIL_MARKET_BURNER,
                    S.USED_OIL_SPEC_MARKETER,
                    S.USED_OIL_TRANSFER_FACILITY,
                    S.USED_OIL_TRANSPORTER,
                    S.LAND_TYPE,
                    S.STATE_DISTRICT_OWNER,
                    S.STATE_DISTRICT,
                    S.IMPORTER_ACTIVITY,
                    S.MIXED_WASTE_GENERATOR,
                    S.RECYCLER_ACTIVITY,
                    S.TRANSPORTER_ACTIVITY,
                    S.TSD_ACTIVITY,
                    S.UNDERGROUND_INJECTION_ACTIVITY,
                    S.ONSITE_BURNER_EXEMPTION,
                    S.FURNACE_EXEMPTION,
                    S.SHORT_TERM_GEN_IND,
                    S.TRANSFER_FACILITY_IND,
                    S.COLLEGE_IND,
                    S.HOSPITAL_IND,
                    S.NON_PROFIT_IND,
                    S.WITHDRAWAL_IND,
                    S.TRANS_CODE,
                    S.NOTIFICATION_RSN_CODE,
                    S.EFFC_DATE,
                    S.FINANCIAL_ASSURANCE_IND,
                    S.RECYCLING_IND,
                    S.MAIL_STREET_NUMBER,
                    S.LOCATION_STREET_NUMBER,
                    S.NON_NOTIFIER_TEXT,
                    S.ACCESSIBILITY_TEXT,
                    S.STATE_DISTRICT_TEXT,
                    S.INTRNL_NOTES,
                    S.SHORT_TERM_INTRNL_NOTES,
                    S.NATURE_OF_BUSINESS_TEXT,
                    S.RECOGNIZED_TRADER_EXPORTER_IND,
                    S.RECOGNIZED_TRADER_IMPORTER_IND,
                    S.SLAB_EXPORTER_IND,
                    S.SLAB_IMPORTER_IND,
                    S.TSD_DATE,
                    S.UNIVERSAL_WASTE_DEST_FACILITY,
                    S.STATE_WASTE_GENERATOR_OWNER,
                    S.STATE_WASTE_GENERATOR,
                    S.FED_WASTE_GENERATOR_OWNER,
                    S.FED_WASTE_GENERATOR,
                    S.ACKNOWLEDGE_FLAG_IND,
                    S.INCLUDE_IN_NATIONAL_REPORT_IND,
                    S.LQHUW_IND,
                    S.HD_REPORT_CYCLE_YEAR,
                    S.HEALTHCARE_FAC,
                    S.REVERSE_DISTRIBUTOR,
                    S.SUBPART_P_WITHDRAWAL,
                    S.RECYCLER_IND,
                    S.CURRENT_RECORD,
                    S.CREATED_BY_USERID,
                    S.H_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LOCATION_LATITUDE,
                    S.LOCATION_LONGITUDE,
                    S.LOCATION_GIS_PRIM,
                    S.LOCATION_GIS_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE,
                    S.BR_EXEMPT_IND);
    END;

    PROCEDURE HD_MERGE_OTHER_ID AS
    BEGIN
        MERGE INTO RCRA_HD_OTHER_ID D
        USING (SELECT *
               FROM ETL_HD_OTHER_ID_VW) S
        ON (D.HD_OTHER_ID_ID = S.WH_HD_OTHER_ID_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE   = S.TRANSACTION_CODE,
                D.RELATIONSHIP_OWNER = S.RELATIONSHIP_OWNER,
                D.RELATIONSHIP_TYPE  = S.RELATIONSHIP_TYPE,
                D.SAME_FACILITY      = S.SAME_FACILITY,
                D.NOTES              = S.NOTES
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.RELATIONSHIP_OWNER, S.RELATIONSHIP_OWNER, 0, 1) = 1
               OR DECODE(D.RELATIONSHIP_TYPE, S.RELATIONSHIP_TYPE, 0, 1) = 1
               OR DECODE(D.SAME_FACILITY, S.SAME_FACILITY, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_OTHER_ID_ID,
                    HD_HBASIC_ID,
                    TRANSACTION_CODE,
                    OTHER_ID,
                    RELATIONSHIP_OWNER,
                    RELATIONSHIP_TYPE,
                    SAME_FACILITY,
                    NOTES)
            VALUES (SEQ_RCRA_HD_OTHER_ID.NEXTVAL,
                    S.WH_HD_HBASIC_ID,
                    S.TRANSACTION_CODE,
                    S.OTHER_ID,
                    S.RELATIONSHIP_OWNER,
                    S.RELATIONSHIP_TYPE,
                    S.SAME_FACILITY,
                    S.NOTES);
    END;

    PROCEDURE HD_MERGE_LQG_CLOSURE AS
    BEGIN
        MERGE INTO RCRA_HD_LQG_CLOSURE D
        USING (SELECT *
               FROM ETL_HD_LQG_CLOSURE) S
        ON (D.HD_LQG_CLOSURE_ID = S.WH_HD_LQG_CLOSURE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE      = S.TRANSACTION_CODE,
                D.CLOSURE_TYPE          = S.CLOSURE_TYPE,
                D.EXPECTED_CLOSURE_DATE = S.EXPECTED_CLOSURE_DATE,
                D.NEW_CLOSURE_DATE      = S.NEW_CLOSURE_DATE,
                D.DATE_CLOSED           = S.DATE_CLOSED,
                D.IN_COMPLIANCE_IND     = s.IN_COMPLIANCE_IND
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.CLOSURE_TYPE, S.CLOSURE_TYPE, 0, 1) = 1
               OR DECODE(D.EXPECTED_CLOSURE_DATE, S.EXPECTED_CLOSURE_DATE, 0, 1) = 1

               OR DECODE(D.NEW_CLOSURE_DATE, S.NEW_CLOSURE_DATE, 0, 1) = 1
               OR DECODE(D.DATE_CLOSED, S.DATE_CLOSED, 0, 1) = 1
               OR DECODE(D.IN_COMPLIANCE_IND, S.IN_COMPLIANCE_IND, 0, 1) = 1

        WHEN NOT MATCHED THEN
            INSERT (HD_LQG_CLOSURE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    CLOSURE_TYPE,
                    EXPECTED_CLOSURE_DATE,
                    NEW_CLOSURE_DATE,
                    DATE_CLOSED,
                    IN_COMPLIANCE_IND)
            VALUES (SEQ_RCRA_HD_LQG_CLOSURE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.CLOSURE_TYPE,
                    S.EXPECTED_CLOSURE_DATE,
                    S.NEW_CLOSURE_DATE,
                    S.DATE_CLOSED,
                    S.IN_COMPLIANCE_IND);
    END;

    PROCEDURE HD_MERGE_LQG_CONSOLIDATION AS
    BEGIN
        MERGE INTO RCRA_HD_LQG_CONSOLIDATION D
        USING (SELECT *
               FROM ETL_HD_LQG_CONSOLIDATION_VW) S
        ON (D.HD_LQG_CONSOLIDATION_ID = S.WH_HD_LQG_CONSOLIDATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE       = S.TRANSACTION_CODE,
                D.SEQ_NUMBER             = S.SEQ_NUMBER,
                D.HANDLER_ID             = S.HANDLER_ID,
                D.HANDLER_NAME           = S.HANDLER_NAME,
                D.MAIL_STREET_NUMBER     = S.MAIL_STREET_NUMBER,
                D.MAIL_STREET1           = S.MAIL_STREET1,
                D.MAIL_STREET2           = S.MAIL_STREET2,
                D.MAIL_CITY              = S.MAIL_CITY,
                D.MAIL_STATE             = S.MAIL_STATE,
                D.MAIL_COUNTRY           = S.MAIL_COUNTRY,
                D.MAIL_ZIP               = S.MAIL_ZIP,
                D.CONTACT_TITLE          = S.CONTACT_TITLE,
                D.CONTACT_FIRST_NAME     = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME      = S.CONTACT_LAST_NAME,
                D.CONTACT_EMAIL_ADDRESS  = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE          = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT      = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX            = S.CONTACT_FAX
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.HANDLER_ID, S.HANDLER_ID, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_LQG_CONSOLIDATION_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    SEQ_NUMBER,
                    HANDLER_ID,
                    HANDLER_NAME,
                    MAIL_STREET_NUMBER,
                    MAIL_STREET1,
                    MAIL_STREET2,
                    MAIL_CITY,
                    MAIL_STATE,
                    MAIL_COUNTRY,
                    MAIL_ZIP,
                    CONTACT_FIRST_NAME,
                    CONTACT_MIDDLE_INITIAL,
                    CONTACT_LAST_NAME,
                    CONTACT_TITLE,
                    CONTACT_EMAIL_ADDRESS,
                    CONTACT_PHONE,
                    CONTACT_PHONE_EXT,
                    CONTACT_FAX)
            VALUES (SEQ_RCRA_HD_LQG_CONSOLIDATION.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.SEQ_NUMBER,
                    S.HANDLER_ID,
                    S.HANDLER_NAME,
                    S.MAIL_STREET_NUMBER,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX);
    END;

    PROCEDURE HD_MERGE_EPISODIC_EVENT AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_EVENT D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_EVENT) S
        ON (D.HD_EPISODIC_EVENT_ID = S.WH_HD_EPISODIC_EVENT_ID)
        WHEN MATCHED
            THEN
            UPDATE
            SET D.TRANSACTION_CODE       = S.TRANSACTION_CODE,
                D.EVENT_OWNER            = S.EVENT_OWNER,
                D.EVENT_TYPE             = S.EVENT_TYPE,
                D.CONTACT_FIRST_NAME     = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME      = S.CONTACT_LAST_NAME,
                D.CONTACT_ORG_NAME       = S.CONTACT_ORG_NAME,
                D.CONTACT_TITLE          = S.CONTACT_TITLE,
                D.CONTACT_EMAIL_ADDRESS  = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE          = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT      = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX            = S.CONTACT_FAX,
                D.START_DATE             = S.START_DATE,
                D.END_DATE               = S.END_DATE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_OWNER, S.EVENT_OWNER, 0, 1) = 1
               OR DECODE(D.EVENT_TYPE, S.EVENT_TYPE, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_ORG_NAME, S.CONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.START_DATE, S.START_DATE, 0, 1) = 1
               OR DECODE(D.END_DATE, S.END_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_EVENT_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    EVENT_OWNER,
                    EVENT_TYPE,
                    CONTACT_FIRST_NAME,
                    CONTACT_MIDDLE_INITIAL,
                    CONTACT_LAST_NAME,
                    CONTACT_ORG_NAME,
                    CONTACT_TITLE,
                    CONTACT_EMAIL_ADDRESS,
                    CONTACT_PHONE,
                    CONTACT_PHONE_EXT,
                    CONTACT_FAX,
                    START_DATE,
                    END_DATE)
            VALUES (SEQ_RCRA_HD_EPISODIC_EVENT.nextval,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.EVENT_OWNER,
                    S.EVENT_TYPE,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_ORG_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX,
                    S.START_DATE,
                    S.END_DATE);
    END;

    PROCEDURE HD_MERGE_EPISODIC_WASTE AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_WASTE D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_WASTE) S
        ON (D.HD_EPISODIC_WASTE_ID = S.WH_HD_EPISODIC_WASTE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.SEQ_NUMBER       = S.SEQ_NUMBER,
                D.WASTE_DESC       = S.WASTE_DESC,
                D.EST_QNTY         = S.EST_QNTY
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.WASTE_DESC, S.WASTE_DESC, 0, 1) = 1
               OR DECODE(D.EST_QNTY, S.EST_QNTY, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_WASTE_ID,
                    HD_EPISODIC_EVENT_ID,
                    TRANSACTION_CODE,
                    SEQ_NUMBER,
                    WASTE_DESC,
                    EST_QNTY)
            VALUES (SEQ_RCRA_HD_EPISODIC_WASTE.nextval,
                    S.WH_HD_EPISODIC_EVENT_ID,
                    S.TRANSACTION_CODE,
                    S.SEQ_NUMBER,
                    S.WASTE_DESC,
                    S.EST_QNTY);
    END;

    PROCEDURE HD_MERGE_EPISODIC_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_WASTE_CODE) S
        ON (D.HD_EPISODIC_WASTE_CODE_ID = S.WH_HD_EPISODIC_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE       = S.WASTE_CODE,
                D.WASTE_CODE_TEXT  = S.WASTE_CODE_TEXT
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE, S.WASTE_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TEXT, S.WASTE_CODE_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_WASTE_CODE_ID,
                    HD_EPISODIC_WASTE_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE,
                    WASTE_CODE_TEXT)
            VALUES (SEQ_RCRA_HD_EPISODIC_WASTE_CD.nextval,
                    S.WH_HD_EPISODIC_WASTE_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE,
                    S.WASTE_CODE_TEXT);
    END;

    PROCEDURE HD_MERGE_SEC_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_SEC_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_SEC_WASTE_CD_VW) S
        ON (D.HD_SEC_WASTE_CODE_ID = S.WH_HD_SEC_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_SEC_WASTE_CODE_ID,
                    HD_SEC_MATERIAL_ACTIVITY_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE_TYPE)
            VALUES (SEQ_RCRA_HD_SEC_WASTE_CODE.NEXTVAL,
                    S.WH_HD_SEC_MATERIAL_ACTIVITY_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE_TYPE);
    END;

    PROCEDURE HD_MERGE_SEC_MATERIAL_ACTIVITY AS
    BEGIN
        MERGE INTO RCRA_HD_SEC_MATERIAL_ACTIVITY D
        USING (SELECT *
               FROM ETL_HD_SEC_MAT_ACT_VW) S
        ON (D.HD_SEC_MATERIAL_ACTIVITY_ID = S.WH_HD_SEC_MATERIAL_ACTIVITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                = S.TRANS_CODE,
                D.HSM_SEQ_NUM               = S.HSM_SEQ_NUM,
                D.FAC_CODE_OWNER_NAME       = S.FAC_CODE_OWNER_NAME,
                D.FAC_TYPE_CODE             = S.FAC_TYPE_CODE,
                D.ESTIMATED_SHORT_TONS_QNTY = S.ESTIMATED_SHORT_TONS_QNTY,
                D.ACTL_SHORT_TONS_QNTY      = S.ACTL_SHORT_TONS_QNTY,
                D.LAND_BASED_UNIT_IND       = S.LAND_BASED_UNIT_IND,
                D.LAND_BASED_UNIT_IND_TEXT  = S.LAND_BASED_UNIT_IND_TEXT
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.HSM_SEQ_NUM, S.HSM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.FAC_CODE_OWNER_NAME, S.FAC_CODE_OWNER_NAME, 0, 1) = 1
               OR DECODE(D.FAC_TYPE_CODE, S.FAC_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.ESTIMATED_SHORT_TONS_QNTY, S.ESTIMATED_SHORT_TONS_QNTY, 0, 1) = 1
               OR DECODE(D.ACTL_SHORT_TONS_QNTY, S.ACTL_SHORT_TONS_QNTY, 0, 1) = 1
               OR DECODE(D.LAND_BASED_UNIT_IND, S.LAND_BASED_UNIT_IND, 0, 1) = 1
               OR DECODE(D.LAND_BASED_UNIT_IND_TEXT, S.LAND_BASED_UNIT_IND_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_SEC_MATERIAL_ACTIVITY_ID,
                    HD_HANDLER_ID,
                    TRANS_CODE,
                    HSM_SEQ_NUM,
                    FAC_CODE_OWNER_NAME,
                    FAC_TYPE_CODE,
                    ESTIMATED_SHORT_TONS_QNTY,
                    ACTL_SHORT_TONS_QNTY,
                    LAND_BASED_UNIT_IND,
                    LAND_BASED_UNIT_IND_TEXT)
            VALUES (SEQ_RCRA_HD_SEC_MATERIAL_ACT.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANS_CODE,
                    S.HSM_SEQ_NUM,
                    S.FAC_CODE_OWNER_NAME,
                    S.FAC_TYPE_CODE,
                    S.ESTIMATED_SHORT_TONS_QNTY,
                    S.ACTL_SHORT_TONS_QNTY,
                    S.LAND_BASED_UNIT_IND,
                    S.LAND_BASED_UNIT_IND_TEXT);
    END;

    PROCEDURE HD_MERGE_OWNEROP AS
    BEGIN
        MERGE INTO RCRA_HD_OWNEROP D
        USING (SELECT *
               FROM ETL_HD_OWNEROP_VW) S
        ON (D.HD_OWNEROP_ID = S.WH_HD_OWNEROP_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE    = S.TRANSACTION_CODE,
                D.OWNER_OP_IND        = S.OWNER_OP_IND,
                D.OWNER_OP_TYPE       = S.OWNER_OP_TYPE,
                D.DATE_BECAME_CURRENT = S.DATE_BECAME_CURRENT,
                D.DATE_ENDED_CURRENT  = S.DATE_ENDED_CURRENT,
                D.NOTES               = S.NOTES,
                D.FIRST_NAME          = S.FIRST_NAME,
                D.MIDDLE_INITIAL      = S.MIDDLE_INITIAL,
                D.LAST_NAME           = S.LAST_NAME,
                D.ORG_NAME            = S.ORG_NAME,
                D.TITLE               = S.TITLE,
                D.EMAIL_ADDRESS       = S.EMAIL_ADDRESS,
                D.PHONE               = S.PHONE,
                D.PHONE_EXT           = S.PHONE_EXT,
                D.FAX                 = S.FAX,
                D.MAIL_ADDR_NUM_TXT   = S.MAIL_ADDR_NUM_TXT,
                D.STREET1             = S.STREET1,
                D.STREET2             = S.STREET2,
                D.CITY                = S.CITY,
                D.STATE               = S.STATE,
                D.COUNTRY             = S.COUNTRY,
                D.ZIP                 = S.ZIP
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.OWNER_OP_SEQ, S.OWNER_OP_SEQ, 0, 1) = 1
               OR DECODE(D.OWNER_OP_IND, S.OWNER_OP_IND, 0, 1) = 1
               OR DECODE(D.OWNER_OP_TYPE, S.OWNER_OP_TYPE, 0, 1) = 1
               OR DECODE(D.DATE_BECAME_CURRENT, S.DATE_BECAME_CURRENT, 0, 1) = 1
               OR DECODE(D.DATE_ENDED_CURRENT, S.DATE_ENDED_CURRENT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.FIRST_NAME, S.FIRST_NAME, 0, 1) = 1
               OR DECODE(D.MIDDLE_INITIAL, S.MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.LAST_NAME, S.LAST_NAME, 0, 1) = 1
               OR DECODE(D.ORG_NAME, S.ORG_NAME, 0, 1) = 1
               OR DECODE(D.TITLE, S.TITLE, 0, 1) = 1
               OR DECODE(D.EMAIL_ADDRESS, S.EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.PHONE, S.PHONE, 0, 1) = 1
               OR DECODE(D.PHONE_EXT, S.PHONE_EXT, 0, 1) = 1
               OR DECODE(D.FAX, S.FAX, 0, 1) = 1
               OR DECODE(D.MAIL_ADDR_NUM_TXT, S.MAIL_ADDR_NUM_TXT, 0, 1) = 1
               OR DECODE(D.STREET1, S.STREET1, 0, 1) = 1
               OR DECODE(D.STREET2, S.STREET2, 0, 1) = 1
               OR DECODE(D.CITY, S.CITY, 0, 1) = 1
               OR DECODE(D.STATE, S.STATE, 0, 1) = 1
               OR DECODE(D.COUNTRY, S.COUNTRY, 0, 1) = 1
               OR DECODE(D.ZIP, S.ZIP, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_OWNEROP_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    OWNER_OP_SEQ,
                    OWNER_OP_IND,
                    OWNER_OP_TYPE,
                    DATE_BECAME_CURRENT,
                    DATE_ENDED_CURRENT,
                    NOTES,
                    FIRST_NAME,
                    MIDDLE_INITIAL,
                    LAST_NAME,
                    ORG_NAME,
                    TITLE,
                    EMAIL_ADDRESS,
                    PHONE,
                    PHONE_EXT,
                    FAX,
                    MAIL_ADDR_NUM_TXT,
                    STREET1,
                    STREET2,
                    CITY,
                    STATE,
                    COUNTRY,
                    ZIP)
            VALUES (SEQ_RCRA_HD_OWNEROP.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.OWNER_OP_SEQ,
                    S.OWNER_OP_IND,
                    S.OWNER_OP_TYPE,
                    S.DATE_BECAME_CURRENT,
                    S.DATE_ENDED_CURRENT,
                    S.NOTES,
                    S.FIRST_NAME,
                    S.MIDDLE_INITIAL,
                    S.LAST_NAME,
                    S.ORG_NAME,
                    S.TITLE,
                    S.EMAIL_ADDRESS,
                    S.PHONE,
                    S.PHONE_EXT,
                    S.FAX,
                    S.MAIL_ADDR_NUM_TXT,
                    S.STREET1,
                    S.STREET2,
                    S.CITY,
                    S.STATE,
                    S.COUNTRY,
                    S.ZIP);
    END;

    PROCEDURE HD_MERGE_STATE_ACTIVITY AS
    BEGIN
        MERGE INTO RCRA_HD_STATE_ACTIVITY D
        USING (SELECT *
               FROM ETL_HD_STATE_ACT_VW) S
        ON (D.HD_STATE_ACTIVITY_ID = S.WH_HD_STATE_ACTIVITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE     = S.TRANSACTION_CODE,
                D.STATE_ACTIVITY_OWNER = S.STATE_ACTIVITY_OWNER,
                D.STATE_ACTIVITY_TYPE  = S.STATE_ACTIVITY_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.STATE_ACTIVITY_OWNER, S.STATE_ACTIVITY_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_ACTIVITY_TYPE, S.STATE_ACTIVITY_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_STATE_ACTIVITY_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    STATE_ACTIVITY_OWNER,
                    STATE_ACTIVITY_TYPE)
            VALUES (SEQ_RCRA_HD_STATE_ACTIVITY.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.STATE_ACTIVITY_OWNER,
                    S.STATE_ACTIVITY_TYPE);
    END;

    PROCEDURE HD_MERGE_UNIVERSAL_WASTE AS
    BEGIN
        MERGE INTO RCRA_HD_UNIVERSAL_WASTE D
        USING (SELECT *
               FROM ETL_HD_UNIV_WASTE_VW) S
        ON (D.HD_UNIVERSAL_WASTE_ID = S.WH_HD_UNIVERSAL_WASTE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE      = S.TRANSACTION_CODE,
                D.UNIVERSAL_WASTE_OWNER = S.UNIVERSAL_WASTE_OWNER,
                D.UNIVERSAL_WASTE_TYPE  = S.UNIVERSAL_WASTE_TYPE,
                D.ACCUMULATED           = S.ACCUMULATED,
                D.GENERATED             = S.GENERATED
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_OWNER, S.UNIVERSAL_WASTE_OWNER, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_TYPE, S.UNIVERSAL_WASTE_TYPE, 0, 1) = 1
               OR DECODE(D.ACCUMULATED, S.ACCUMULATED, 0, 1) = 1
               OR DECODE(D.GENERATED, S.GENERATED, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_UNIVERSAL_WASTE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    UNIVERSAL_WASTE_OWNER,
                    UNIVERSAL_WASTE_TYPE,
                    ACCUMULATED,
                    GENERATED)
            VALUES (SEQ_RCRA_HD_UNIVERSAL_WASTE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.UNIVERSAL_WASTE_OWNER,
                    S.UNIVERSAL_WASTE_TYPE,
                    S.ACCUMULATED,
                    S.GENERATED);
    END;

    PROCEDURE HD_MERGE_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_WASTE_CODE_VW) S
        ON (D.HD_WASTE_CODE_ID = S.WH_HD_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_WASTE_CODE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_TYPE,
                    WASTE_CODE_OWNER)
            VALUES (SEQ_RCRA_HD_WASTE_CODE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_TYPE,
                    S.WASTE_CODE_OWNER);
    END;

    PROCEDURE HD_MERGE_ENV_PERMIT AS
    BEGIN
        MERGE INTO RCRA_HD_ENV_PERMIT D
        USING (SELECT *
               FROM ETL_HD_ENV_PERMIT_VW) S
        ON (D.HD_ENV_PERMIT_ID = S.WH_HD_ENV_PERMIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE  = S.TRANSACTION_CODE,
                D.ENV_PERMIT_NUMBER = S.ENV_PERMIT_NUMBER,
                D.ENV_PERMIT_OWNER  = S.ENV_PERMIT_OWNER,
                D.ENV_PERMIT_TYPE   = S.ENV_PERMIT_TYPE,
                D.ENV_PERMIT_DESC   = S.ENV_PERMIT_DESC
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_NUMBER, S.ENV_PERMIT_NUMBER, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_OWNER, S.ENV_PERMIT_OWNER, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_TYPE, S.ENV_PERMIT_TYPE, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_DESC, S.ENV_PERMIT_DESC, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_ENV_PERMIT_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    ENV_PERMIT_NUMBER,
                    ENV_PERMIT_OWNER,
                    ENV_PERMIT_TYPE,
                    ENV_PERMIT_DESC)
            VALUES (SEQ_RCRA_HD_ENV_PERMIT.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.ENV_PERMIT_NUMBER,
                    S.ENV_PERMIT_OWNER,
                    S.ENV_PERMIT_TYPE,
                    S.ENV_PERMIT_DESC);
    END;

    PROCEDURE HD_MERGE_CERTIFICATION AS
    BEGIN
        MERGE INTO RCRA_HD_CERTIFICATION D
        USING (SELECT *
               FROM ETL_HD_CERT_VW) S
        ON (D.HD_CERTIFICATION_ID = S.WH_HD_CERTIFICATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE    = S.TRANSACTION_CODE,
                D.CERT_SIGNED_DATE    = S.CERT_SIGNED_DATE,
                D.CERT_TITLE          = S.CERT_TITLE,
                D.CERT_FIRST_NAME     = S.CERT_FIRST_NAME,
                D.CERT_MIDDLE_INITIAL = S.CERT_MIDDLE_INITIAL,
                D.CERT_LAST_NAME      = S.CERT_LAST_NAME,
                D.CERT_EMAIL_TEXT     = S.CERT_EMAIL_TEXT
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.CERT_SIGNED_DATE, S.CERT_SIGNED_DATE, 0, 1) = 1
               OR DECODE(D.CERT_TITLE, S.CERT_TITLE, 0, 1) = 1
               OR DECODE(D.CERT_FIRST_NAME, S.CERT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CERT_MIDDLE_INITIAL, S.CERT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CERT_LAST_NAME, S.CERT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CERT_EMAIL_TEXT, S.CERT_EMAIL_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_CERTIFICATION_ID,
                    CERT_SEQ,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    CERT_SIGNED_DATE,
                    CERT_TITLE,
                    CERT_FIRST_NAME,
                    CERT_MIDDLE_INITIAL,
                    CERT_LAST_NAME,
                    CERT_EMAIL_TEXT)
            VALUES (SEQ_RCRA_HD_CERTIFICATION.NEXTVAL,
                    S.CERT_SEQ,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.CERT_SIGNED_DATE,
                    S.CERT_TITLE,
                    S.CERT_FIRST_NAME,
                    S.CERT_MIDDLE_INITIAL,
                    S.CERT_LAST_NAME,
                    S.CERT_EMAIL_TEXT);
    END;

    PROCEDURE HD_MERGE_NAICS AS
    BEGIN
        MERGE INTO RCRA_HD_NAICS D
        USING (SELECT *
               FROM ETL_HD_NAICS_VW) S
        ON (D.HD_NAICS_ID = S.WH_HD_NAICS_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.NAICS_OWNER      = S.NAICS_OWNER,
                D.NAICS_CODE       = S.NAICS_CODE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.NAICS_OWNER, S.NAICS_OWNER, 0, 1) = 1
               OR DECODE(D.NAICS_CODE, S.NAICS_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_NAICS_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    NAICS_SEQ,
                    NAICS_OWNER,
                    NAICS_CODE)
            VALUES (SEQ_RCRA_HD_NAICS.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.NAICS_SEQ,
                    S.NAICS_OWNER,
                    S.NAICS_CODE);
    END;

    PROCEDURE HD_MERGE_EPISODIC_PRJT AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_PRJT D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_PRJT) S
        ON (D.HD_EPISODIC_PRJT_ID = S.WH_HD_EPISODIC_PRJT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.PRJT_CODE_OWNER  = S.PRJT_CODE_OWNER,
                D.PRJT_CODE        = S.PRJT_CODE,
                D.OTHER_PRJT_DESC  = S.OTHER_PRJT_DESC
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.PRJT_CODE_OWNER, S.PRJT_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.PRJT_CODE, S.PRJT_CODE, 0, 1) = 1
               OR DECODE(D.OTHER_PRJT_DESC, S.OTHER_PRJT_DESC, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_PRJT_ID,
                    HD_EPISODIC_EVENT_ID,
                    TRANSACTION_CODE,
                    PRJT_CODE_OWNER,
                    PRJT_CODE,
                    OTHER_PRJT_DESC)
            VALUES (SEQ_RCRA_HD_EPISODIC_PRJT.NEXTVAL,
                    S.WH_HD_EPISODIC_EVENT_ID,
                    S.TRANSACTION_CODE,
                    S.PRJT_CODE_OWNER,
                    S.PRJT_CODE,
                    S.OTHER_PRJT_DESC);
    END;

    PROCEDURE HD_MERGE_DATA AS
    BEGIN
        HD_LOG_HANDLERS;
        HD_MERGE_HBASIC;
        HD_MERGE_HANDLER;
        HD_MERGE_NAICS;
        HD_MERGE_CERTIFICATION;
        HD_MERGE_ENV_PERMIT;
        HD_MERGE_WASTE_CODE;
        HD_MERGE_UNIVERSAL_WASTE;
        HD_MERGE_STATE_ACTIVITY;
        HD_MERGE_OWNEROP;
        HD_MERGE_SEC_MATERIAL_ACTIVITY;
        HD_MERGE_SEC_WASTE_CODE;
        HD_MERGE_OTHER_ID;
        HD_MERGE_LQG_CLOSURE;
        HD_MERGE_LQG_CONSOLIDATION;
        HD_MERGE_EPISODIC_EVENT;
        HD_MERGE_EPISODIC_WASTE;
        HD_MERGE_EPISODIC_WASTE_CODE;
        HD_MERGE_EPISODIC_WASTE_CODE;
        HD_MERGE_EPISODIC_PRJT;
    END;

    PROCEDURE PRM_MERGE_DATA AS
    BEGIN
        PRM_LOG_HANDLERS;
        PRM_MERGE_FAC_SUBM;
        PRM_MERGE_SERIES;
        PRM_MERGE_UNIT;
        PRM_MERGE_UNIT_DETAIL;
        PRM_MERGE_WASTE_CODE;
        PRM_MERGE_EVENT;
        PRM_MERGE_EVENT_COMMITMENT;
        PRM_MERGE_RELATED_EVENT;
        PRM_MERGE_MOD_EVENT;
    END;

    PROCEDURE FA_MERGE_DATA AS
    BEGIN
        FA_LOG_HANDLERS;
        FA_MERGE_FAC_SUBM;
        FA_MERGE_MECHANISM;
        FA_MERGE_MECHANISM_DETAIL;
        FA_MERGE_COST_EST;
        FA_MERGE_COST_EST_REL_MECH;
    END;

    PROCEDURE CA_MERGE_DATA AS
    BEGIN
        CA_LOG_HANDLERS;
        CA_MERGE_FAC_SUBM;
        CA_MERGE_EVENT;
        CA_MERGE_EVENT_COMMITMENT;
        CA_MERGE_AREA;
        CA_MERGE_AREA_REL_EVENT;
        CA_MERGE_REL_PERMIT_UNIT;
        CA_MERGE_AUTHORITY;
        CA_MERGE_AUTH_REL_EVENT;
        CA_MERGE_STATUTORY_CITATION;
    END;

    PROCEDURE CME_DELETE_DATA AS
    BEGIN
        CME_DELETE_VIOL;
        CME_DELETE_ENFRC_ACT;
        CME_DELETE_EVAL;
    END;

    PROCEDURE CME_MERGE_DATA AS
    BEGIN
        CME_LOG_HANDLERS;
        CME_MERGE_FAC_SUBM;
        CME_MERGE_VIOL;
        CME_MERGE_CITATION;
        CME_MERGE_EVAL;
        CME_MERGE_EVAL_COMMIT;
        CME_MERGE_EVAL_VIOL;
        CME_MERGE_RQST;
        CME_MERGE_ENFRC_ACT;
        CME_MERGE_CSNY_DATE;
        CME_MERGE_MEDIA;
        CME_MERGE_MILESTONE;
        CME_MERGE_SUPP_ENVR_PRJT;
        CME_MERGE_VIOL_ENFRC;
        CME_MERGE_PNLTY;
        CME_MERGE_PYMT;
    END;

    PROCEDURE GIS_MERGE_DATA AS
    BEGIN
        GIS_LOG_HANDLERS;
        GIS_MERGE_FAC_SUBM;
        GIS_MERGE_RCRA_GIS_GEO_INFO;
    END;

    PROCEDURE CH_MERGE_DATA AS
    BEGIN
        CH_LOG_HANDLER;
        CH_MERGE_REPORT_UNIV;
    END;

    PROCEDURE EM_MERGE_DATA AS
    BEGIN
        EM_LOG_HANDLER;
        EM_MERGE_EMANIFEST;
        EM_MERGE_EMANIFEST_COMMENT;
        EM_MERGE_WASTE;
        EM_MERGE_STATE_WASTE_CODE_DESC;
        EM_MERGE_FED_WASTE_CODE_DESC;
        EM_MERGE_WASTE_COMMENT;
        EM_MERGE_TRANSPORTER;
        EM_MERGE_WASTE_CD_TRANS;
        EM_MERGE_WASTE_PCB; --- HERE
    END;

    PROCEDURE MERGE_DATA(TRANS_TYPE varchar) AS
    BEGIN
        CASE TRANS_TYPE
            WHEN 'CA'
                THEN CA_MERGE_DATA;
            WHEN 'CE'
                THEN CME_MERGE_DATA;
            WHEN 'FA'
                THEN FA_MERGE_DATA;
            WHEN 'GS'
                THEN GIS_MERGE_DATA;
            WHEN 'HD'
                THEN HD_MERGE_DATA;
            WHEN 'PM'
                THEN PRM_MERGE_DATA;
            WHEN 'CH'
                THEN CH_MERGE_DATA;
            WHEN 'EM'
                THEN EM_MERGE_DATA;
            WHEN 'CD'
                THEN CME_DELETE_DATA;
            ELSE DBMS_OUTPUT.PUT_LINE('No handler for transaction type: ' || TRANS_TYPE);
            END CASE;
    END;

END RCRAINFO_ETL;
/

