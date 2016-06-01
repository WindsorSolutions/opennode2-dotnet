/*************************************************************************************************
** ObjectName: TRIDEX 5.0 Migration to 6.0-SQL.sql
**
** Author: Windsor Solutions, Inc.
**
** Company Name: Windsor Solutions, Inc.
**
** Description:  This script will update an existing TRIDEX 5.0 database to support the TRIDEX 6.0 viewer
**               application.  This script can be run multiple times without issue.
**
** Revision History:
** ------------------------------------------------------------------------------------------------
** Date          Name        Description
** ------------------------------------------------------------------------------------------------
** 10/09/2015    Windsor     Created
** 10/13/2015    TK Conrad   Commented out references to the V_TRI_PAGE5_CMT_ONE_LN view (unneeded).
** 10/16/2015    TK Conrad   Moved EPARecon changes here, should not have been in main TRI migration script.
** 12/07/2015    TK Conrad   Updated all views to the latest versions (per WA Ecology revisions).
*************************************************************************************************/
SET NOCOUNT ON

/* ************************************************************************
 *
 *     TABLES  TABLES  TABLES  TABLES  TABLES  TABLES
 *
 **************************************************************************/

/* Alter EPARecon, add column BIA Code */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'EPARecon'
                    AND columns.name = 'BIA Code')
    BEGIN

      ALTER TABLE EPARecon
        ADD "BIA Code" nvarchar(255) NULL;
        
      PRINT 'The field BIA Code was added to the table EPARecon!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field BIA Code already existed on EPARecon, schema alteration bypassed!';
    END;

/* Alter EPARecon, add column Tribe Name */
  IF NOT EXISTS (SELECT 1
                   FROM sys.schemas
                   JOIN sys.tables
                     ON tables.schema_id = schemas.schema_id
                   JOIN sys.columns
                     ON columns.object_id = tables.object_id
                  WHERE schemas.name = 'dbo'
                    AND tables.name = 'EPARecon'
                    AND columns.name = 'Tribe Name')
    BEGIN

      ALTER TABLE EPARecon
        ADD "Tribe Name" nvarchar(255) NULL;
        
      PRINT 'The field Tribe Name was added to the table EPARecon!';
      
    END
  ELSE
    BEGIN
      PRINT 'The field Tribe Name already existed on EPARecon, schema alteration bypassed!';
    END;


/* ************************************************************************
 *
 *     FUNCTIONS  FUNCTIONS  FUNCTIONS  FUNCTIONS  FUNCTIONS  FUNCTIONS
 *
 **************************************************************************/


/* 
 * Function:  "CleanAndTrim"
 */
IF  EXISTS (SELECT * 
              FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'dbo."CleanAndTrim"') 
               AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.CleanAndTrim
GO

-- =============================================
-- Description: TRIMs a string 'for real' - removes standard whitespace from ends,
-- and replaces ASCII-char's 9-13, which are tab, line-feed, vert tab,
-- form-feed, & carriage-return (respectively), with a whitespace
-- (and then trims that off if it's still at the beginning or end, of course).
-- =============================================
CREATE FUNCTION dbo.CleanAndTrim (
       @Str nvarchar(max)
)
RETURNS nvarchar(max) AS
BEGIN
       DECLARE @Result nvarchar(max)

       SET @Result = LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(
              LTRIM(RTRIM(@Str)), CHAR(9), ' '), CHAR(10), ' '), CHAR(11), ' '), CHAR(12), ' '), CHAR(13), ' ')))

       RETURN @Result
END
GO

/* 
 * Function:  "udf_FormatPhone"
 */
IF  EXISTS (SELECT * 
              FROM sys.objects 
             WHERE object_id = OBJECT_ID(N'dbo."udf_FormatPhone"') 
               AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION dbo.udf_FormatPhone
GO

CREATE FUNCTION dbo.udf_FormatPhone
(@PhoneNumber VARCHAR(32))
RETURNS VARCHAR(32)
AS
  BEGIN
    DECLARE  @Phone CHAR(32)

    SET @Phone = @PhoneNumber

    -- cleanse phone number string
    WHILE PATINDEX('%^0-9%',@PhoneNumber) > 0
      SET @PhoneNumber = REPLACE(@PhoneNumber,
               SUBSTRING(@PhoneNumber,PATINDEX('%^0-9%',@PhoneNumber),1),'')

    -- skip foreign phones
    IF (SUBSTRING(@PhoneNumber,1,1) = '1'
         OR SUBSTRING(@PhoneNumber,1,1) = '+'
         OR SUBSTRING(@PhoneNumber,1,1) = '0')
       AND LEN(@PhoneNumber) > 11
      RETURN @Phone

    -- build US standard phone number
    SET @Phone = @PhoneNumber

    SET @PhoneNumber = '(' + SUBSTRING(@PhoneNumber,1,3) + ') ' +
             SUBSTRING(@PhoneNumber,4,3) + '-' + SUBSTRING(@PhoneNumber,7,4)

    IF LEN(@Phone) - 10 > 1
      SET @PhoneNumber = @PhoneNumber + ' x' + SUBSTRING(@Phone,11,LEN(@Phone) - 10)

    RETURN @PhoneNumber
  END
GO

/************************************************************************************************************

 VIEWS  VIEWS  VIEWS
 
************************************************************************************************************/

-- Remove old views from TRIDex that are no longer used by the extract generator
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_MASTER_D')
BEGIN
DROP VIEW dbo.V_EXT_MASTER_D
PRINT 'V_EXT_MASTER_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_MASTER_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_DETAIL_D')
BEGIN
DROP VIEW dbo.V_EXT_DETAIL_D
PRINT 'V_EXT_DETAIL_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_DETAIL_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_OFF_WT_D')
BEGIN
DROP VIEW dbo.V_EXT_OFF_WT_D
PRINT 'V_EXT_OFF_WT_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_OFF_WT_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_STR_D')
BEGIN
DROP VIEW dbo.V_EXT_STR_D
PRINT 'V_EXT_STR_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_STR_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_W_MGMT_D')
BEGIN
DROP VIEW dbo.V_EXT_W_MGMT_D
PRINT 'V_EXT_W_MGMT_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_W_MGMT_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_CONTACT_D')
BEGIN
DROP VIEW dbo.V_EXT_CONTACT_D
PRINT 'V_EXT_CONTACT_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_CONTACT_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_DIOXIN_OFF_WT_D')
BEGIN
DROP VIEW dbo.V_EXT_DIOXIN_OFF_WT_D
PRINT 'V_EXT_DIOXIN_OFF_WT_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_DIOXIN_OFF_WT_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_DIOXIN_D')
BEGIN
DROP VIEW dbo.V_EXT_DIOXIN_D
PRINT 'V_EXT_DIOXIN_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_DIOXIN_D not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_DIOXIN')
BEGIN
DROP VIEW dbo.V_EXT_DIOXIN
PRINT 'V_EXT_DIOXIN successfully dropped!'
END
ELSE
PRINT 'V_EXT_DIOXIN not found, schema alteration bypassed!'

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_EXT_P2_FEE_D')
BEGIN
DROP VIEW dbo.V_EXT_P2_FEE_D
PRINT 'V_EXT_P2_FEE_D successfully dropped!'
END
ELSE
PRINT 'V_EXT_P2_FEE_D not found, schema alteration bypassed!'

/****** Object:  View [dbo].[V_TRI_PG2_53]    Script Date: 6/12/2015 1:42:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PG2_53]
(FK_GUID, STREAM, A, B, C, 
 SRC, NUM)
AS
SELECT   FK_GUID,
         STREAM,
         COALESCE (WASTE_Q_RANGE_CODE, WASTE_Q_ME) A,
         Q_BASIS_EST_CD B,
         RELEASE_STORM_WATER C,
		 STREAM_REACH_CODE SRC,
         (SELECT COUNT (*)
            FROM TRI_ONSITE_RELEASE_Q REL2
           WHERE REL2.EI_MEDIUM_CODE = 'WATER'
             AND REL2.FK_GUID = REL.FK_GUID
             AND REL2.PK_GUID <= REL.PK_GUID) NUM
    FROM TRI_ONSITE_RELEASE_Q REL
   WHERE EI_MEDIUM_CODE = 'WATER'

GO


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_TRI_PAGE5_COMMENT')
DROP VIEW dbo.V_TRI_PAGE5_COMMENT
GO

CREATE VIEW dbo.V_TRI_PAGE5_COMMENT
AS
SELECT
     R.FK_GUID PK_GUID_SUB
	,R.PK_GUID PK_GUID_REP
	,CAST('8.11' AS varchar(50)) COMMENT_SECTION
	,CAST(0 AS INT) COMMENT_SEQ
	,COALESCE(R.OPT_INF_CATG, 'N/A') COMMENT_TYPE_DESC
	,R.OPT_INF_TXT COMMENT_TEXT
	,CAST('N/A' AS varchar(100)) COMMENT_P2_CLASS

FROM TRI_REPORT R
WHERE R.OPT_INF_TXT IS NOT NULL

UNION ALL

SELECT
     R.FK_GUID PK_GUID_SUB
	,R.PK_GUID PK_GUID_REP
	,CAST('9.1' AS varchar(50)) COMMENT_SECTION
	,CAST(0 AS INT) COMMENT_SEQ
	,COALESCE(R.MISC_INF_CATG, 'N/A') COMMENT_TYPE_DESC
	,R.MISC_INF_TXT COMMENT_TEXT
	,CAST('N/A' AS varchar(100)) COMMENT_P2_CLASS

FROM TRI_REPORT R
WHERE R.MISC_INF_TXT IS NOT NULL

UNION ALL

SELECT
     R.FK_GUID PK_GUID_SUB
	,R.PK_GUID PK_GUID_REP
	,C.COMMENT_SECTION
	,C.COMMENT_SEQ
	,C.COMMENT_TYPE_DESC
	,C.COMMENT_TEXT
	,C.COMMENT_P2_CLASS
FROM TRI_REPORT R
JOIN TRI_COMMENT C
  ON C.FK_GUID = R.PK_GUID

GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'V_TRI_PAGE5_CMT_ONE_LN')
DROP VIEW dbo.V_TRI_PAGE5_CMT_ONE_LN
GO

CREATE VIEW dbo.V_TRI_PAGE5_CMT_ONE_LN
AS
SELECT [PK_GUID_SUB]
      ,[PK_GUID_REP]
      ,[COMMENT_SECTION]
      ,[COMMENT_SEQ]
      ,[COMMENT_TYPE_DESC]
      ,[COMMENT_TEXT]
      ,[COMMENT_P2_CLASS]
  FROM [dbo].[V_TRI_PAGE5_COMMENT] V1

WHERE COMMENT_SEQ =
(
SELECT MIN(V2.COMMENT_SEQ)
FROM [dbo].[V_TRI_PAGE5_COMMENT] V2
WHERE V2.PK_GUID_REP = V1.PK_GUID_REP
  AND V2.COMMENT_SECTION = V1.COMMENT_SECTION
)

GO


/****** Object:  View [dbo].[V_EXT_CONTACT]    Script Date: 6/15/2015 12:23:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_EXT_CONTACT]
AS
SELECT FI.fs_id                                                    AS FSID, 
       FI.epa_id                                                   AS [EPA ID], 
       Upper(F.fac_id)                                             AS [TRI Facility Id], 
       F.fac_site                                                  AS [Facility Name], 
--       T.agencyname                                                AS AKA, 
       F.loc_add_txt                                               AS [Address 1], 
       F.supp_loc_txt                                              AS [Address 2], 
       F.locality                                                  AS City, 
       F.county, 
       F.add_postal_code                                           AS Zip, 
       F.mail_fac_site                                             AS [Mail Name], 
       F.mail_add_txt                                              AS [Mail Add 1], 
       F.supp_mail_add                                             AS [Mail Add 2], 
       F.mail_add_city                                             AS [Mail City], 
       F.mail_add_state                                            AS [Mail State], 
       F.mail_add_postal_code                                      AS [Mail Zip], 
       F.province_txt                                              AS [Mail Province], 
       F.mail_add_country                                          AS [Mail Country], 
       F.mail_add_country_code                                     AS [Mail Country Code], 
       R.pub_cont                                                  AS [Pub Contact], 
       R.pub_cont_phone_txt                                        AS [Pub Phone], 
       R.pub_cont_phone_ext_txt                                    AS [Pub Phone Ext],
       Lower(R.pub_cont_email_addres)                              AS [Pub Email], 
       R.tech_cont                                                 AS [Tech Contact], 
       R.tech_cont_phone_txt                                       AS [Tech Phone], 
       R.tech_cont_phone_ext_txt                                   AS [Tech Phone Ext],
       Lower(R.tech_cont_email_addres)                             AS [Tech Email], 
       CTYREG.ecologyregion                                        AS [ECY Region], 
       Max(R.sub_rep_year)                                         AS Year, 
       CONVERT(VARCHAR, Cast(R.cert_signed_date AS DATETIME), 101) AS Received, 
       F.pk_guid                                                   AS PK_GUID_FAC, 
       F.fk_guid                                                   AS FK_GUID_FAC, 
       Upper(F.fac_id)                                             AS TRIFID, 
       Max(R.sub_rep_year)                                         AS SUBMISSION_REPORTING_YEAR, 
       Cast(NULL AS VARCHAR(255))                                  AS CHEMICAL_NAME_TEXT, 
       CTYREG.ecologyregion                                        AS [ECOLOGY_REGION], 
       CTYREG.County                                        AS [COUNTY_NM], 
       FI.epa_id                                                   AS [EPA_ID], 
	   F.FAC_SITE AS FAC_NAME,
	   FI.fs_id                                                    AS FS_ID, 
       CASE C.cas_clber 
         WHEN 'N150' THEN 1 
         ELSE 0 
       END                                                         AS DIOXIN_IND 
FROM   dbo.tri_report AS R 
       INNER JOIN dbo.tri_sub AS S 
               ON R.fk_guid = S.pk_guid 
       INNER JOIN dbo.tri_fac AS F 
               ON F.fk_guid = S.pk_guid 
       INNER JOIN dbo.tri_chem AS C 
               ON C.fk_guid = R.pk_guid 
       LEFT OUTER JOIN dbo.v_fac_ident AS FI 
                    ON Upper(F.fac_id) = FI.trifid 
       LEFT OUTER JOIN dbo.tri_fac_naics AS N 
                    ON F.pk_guid = N.fk_guid 
                       AND N.naics_primary_ind = 'Primary' 
       LEFT OUTER JOIN dbo.app_lookup_cty_reg AS CTYREG 
                    ON CTYREG.county = F.county 
       LEFT OUTER JOIN dbo.app_fi_trifid AS T 
                    ON F.fac_id = T.trifid 
       LEFT OUTER JOIN dbo.app_fi_trifid_delete_chem AS D 
                    ON D.tri_report_id = r.pk_guid 
WHERE  S.inserted_date = (SELECT Max(S2.inserted_date) 
                          FROM   tri_report R2 
                                 JOIN tri_chem C2 
                                   ON C2.fk_guid = R2.pk_guid 
                                 JOIN tri_sub S2 
                                   ON S2.pk_guid = R2.fk_guid 
                                 JOIN tri_fac F2 
                                   ON F2.fk_guid = S2.pk_guid 
                          WHERE  F2.fac_id = F.fac_id 
                                 AND R2.sub_rep_year = R.sub_rep_year 
                                 AND C2.chem_txt = C.chem_txt) 
GROUP  BY F.pk_guid, 
          F.fk_guid, 
          Upper(F.fac_id), 
          FI.epa_id, 
          FI.fs_id, 
          T.agencyname, 
          F.fac_site, 
          F.loc_add_txt, 
          F.supp_loc_txt, 
          F.locality, 
          F.county, 
          F.add_postal_code, 
          F.province_txt, 
          F.mail_add_country, 
          F.mail_add_country_code, 
          F.mail_add_txt, 
          F.supp_mail_add, 
          F.mail_add_city, 
          F.mail_add_postal_code, 
          F.mail_add_state, 
          R.pub_cont, 
          R.pub_cont_phone_txt, 
          Lower(R.pub_cont_email_addres), 
          R.tech_cont, 
          R.tech_cont_phone_txt, 
          Lower(R.tech_cont_email_addres), 
          F.mail_fac_site, 
          CONVERT(VARCHAR, Cast(R.cert_signed_date AS DATETIME), 101), 
          CTYREG.ecologyregion, 
          C.cas_clber,
		  R.pub_cont_phone_ext_txt,
		  R.tech_cont_phone_ext_txt,
		  CTYREG.County
GO


PRINT 'V_EXT_CONTACT was altered!'

/****** Object:  View [dbo].[V_EXT_DETAIL]    Script Date: 6/15/2015 1:59:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* =============================================
 Full Name:		V_EXTRACT_TRI_DETAIL
 Condensed Name:	V_EXT_DETAIL
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the TRI Detail extract in the TRI Application as well as provides source information for other extacts. Results in pounds.*/
ALTER VIEW [dbo].[V_EXT_DETAIL]
AS
SELECT
	FI.FS_ID AS FSID
,	FI.EPA_ID AS [EPA ID]
,	UPPER(F.FAC_ID) AS [TRI Facility Id]
,	R.SUB_REP_YEAR AS Year
,	CASE dbo.TRI_CalculateRevisionIndicator(R.PK_GUID)
		WHEN 1 THEN 'Y'
		ELSE 'N'
	END AS Revision
,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
,	F.FAC_SITE AS [Facility Name]
--,	T.AgencyName AS AKA
,	F.LOC_ADD_TXT AS [Address 1]
,	F.SUPP_LOC_TXT AS [Address 2]
,	F.LOCALITY AS City
,	F.COUNTY AS County
,	F.ADD_POSTAL_CODE AS Zip
,	N.FAC_NAICS AS NAICS
,	C.CHEM_TXT AS Chemical
,	C.CAS_CLBER AS [CAS #]
,	F.PK_GUID AS PK_GUID_FAC
,	C.PK_GUID AS PK_GUID_CHEM
,	F.FK_GUID AS FK_GUID_FAC
,	R.PK_GUID AS PK_GUID_REPORT
,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'air fug')) AS [51 Fugitive Air],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'air stack')) AS [52 Stack Air],
                          (SELECT     CONVERT(VARCHAR(100), SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END))) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'water')) AS [53 Water],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'uninj i')) AS [541 UG INJ Class I],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'uninj iiv')) AS [542 UG INJ Class II-V],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'rcra c')) AS [551A RCRA C Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'oth landf')) AS [551B Other Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'land trea')) AS [552 Land Treatment],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'si 5.5.3a')) AS [553A RCRA C SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'si 5.5.3b')) AS [553B Other SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = 'oth disp')) AS [554 Other Disposal],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = 'Y' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID)) AS [Onsite Release Total],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN OFSR.WASTE_Q_NA_IND = 'Y' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(OFSR.WASTE_Q_ME, OFSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_TRANSFER_Q AS OFSR INNER JOIN
                                                   dbo.TRI_TRANSFER_LOC AS TL ON OFSR.FK_GUID = TL.PK_GUID
                            WHERE      (TL.FK_GUID = R.PK_GUID)) AS [Total Offsite Waste Quantity]
,	R.ONE_TIME_RELEASE_Q AS [One Time Release]
,	R.PRODUCTION_RATIO_TYPE AS [Production Ratio Type]
,	R.PRODUCTION_RATIO_ME AS [Production Ratio]
,	R.PK_GUID AS FK_GUID_REPORT
,	C.FK_GUID AS FK_GUID_CHEM
,	CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS Signed
,	S.INSERTED_DATE AS Received
,	R.FK_GUID AS REPORT_FK
,	C.FK_GUID AS CHEM_FK
,	CTYREG.EcologyRegion AS [ECY Region]
,	R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,	CTYREG.EcologyRegion AS ECOLOGY_REGION
,	FI.FS_ID
,	FI.EPA_ID
,	UPPER(F.FAC_ID) AS TRIFID
,	F.COUNTY AS COUNTY_NM
,	F.FAC_SITE AS FAC_NAME
,	T.AgencyName
,	C.CHEM_TXT AS CHEMICAL_NAME_TEXT
, CASE C.CAS_CLBER 
    WHEN 'N150' THEN 1
    ELSE 0
  END AS DIOXIN_IND
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = 'Primary' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete_chem AS D ON D.tri_report_id = r.pk_guid

WHERE
ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '') <> '5'
AND
T.Inactive_DT IS NULL
AND d.TRIFID_DELETE_CHEM_ID IS NULL
AND (R.CHEM_RPT_WD_CD_1 IS NULL AND R.CHEM_RPT_WD_CD_2 IS NULL)
AND
(
R.SUB_PARTIAL_FAC_ID = 'Y'
OR
	(
	R.SUB_PARTIAL_FAC_ID = 'N'
	AND
	S.INSERTED_DATE =
							  (SELECT     MAX(S2.INSERTED_DATE)
								FROM          dbo.TRI_SUB AS S2 INNER JOIN
													   dbo.TRI_FAC AS F2 ON F2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_REPORT AS R2 ON R2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_CHEM AS C2 ON C2.FK_GUID = R2.PK_GUID
								WHERE      (F2.FAC_ID = F.FAC_ID) AND (R2.SUB_REP_YEAR = R.SUB_REP_YEAR) AND (C2.CAS_CLBER = C.CAS_CLBER) AND 
													   (C2.CHEM_TXT = C.CHEM_TXT) AND R2.SUB_PARTIAL_FAC_ID = 'N'
							   )
	AND
			(
			dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 1
			OR
				(
				dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 0
				AND NOT EXISTS
					(
					SELECT * FROM TRI_REPORT R3
					JOIN TRI_CHEM C3 ON C3.FK_GUID = R3.PK_GUID
					WHERE
					C3.CHEM_TXT = C.CHEM_TXT
					AND
					R3.FK_GUID = R.FK_GUID
					AND
					dbo.TRI_CalculateRevisionIndicator(R3.PK_GUID) = 1
					)
				)
			)
	)
)

GO


PRINT 'V_EXT_DETAIL was altered!'

/****** Object:  View [dbo].[V_EXT_DIOXIN_OFF_WT]    Script Date: 6/30/2015 1:57:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/* =============================================
 Full Name:		V_EXTRACT_DIOXIN_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2009-02-22
 Description:		Supports the Dioxin Waste Transfers extract in the TRI Application.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> 'A'*/
ALTER VIEW [dbo].[V_EXT_DIOXIN_OFF_WT]
AS
 SELECT
	TL.PK_GUID
,	TL.FK_GUID
,	TD.FS_ID AS FSID
,	TD.EPA_ID AS [EPA ID]
,	TD.TRIFID AS [TRI Facility Id]
,	TD.SUBMISSION_REPORTING_YEAR AS Year
,	TD.FAC_NAME AS [Facility Name]
--,	TD.AgencyName AS AKA
,	TD.LOC_ADD_LINE_1_DS AS [Address 1]
,	TD.LOC_ADD_LINE_2_DS AS [Address 2]
,	TD.CITY_NM AS City
,	TD.COUNTY_NM AS County
,	TD.ZIP_CD AS Zip
,	TD.CHEMICAL_NAME_TEXT AS Chemical
,	TL.RCRA_ID_CLBER AS [Trans RCRA ID]
,	TL.FAC_SITE AS [Trans Facility Name]
,	TL.LOC_ADD_TXT AS [Trans Address]
,	TL.LOCALITY AS [Trans City]
,	TL.STATE AS [Trans State]
,	CASE
		WHEN TLQ.WASTE_Q_NA_IND = 'Y' THEN NULL
		ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, TLQ.WASTE_Q_RANGE_CODE)
	END AS [Trans Waste Total]
,	TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code]
,	TLQ.TOX_EQ_VAL1 AS [TEQ_01]
,	TLQ.TOX_EQ_VAL2 AS [TEQ_02]
,	TLQ.TOX_EQ_VAL3 AS [TEQ_03]
,	TLQ.TOX_EQ_VAL4 AS [TEQ_04]
,	TLQ.TOX_EQ_VAL5 AS [TEQ_05]
,	TLQ.TOX_EQ_VAL6 AS [TEQ_06]
,	TLQ.TOX_EQ_VAL7 AS [TEQ_07]
,	TLQ.TOX_EQ_VAL8 AS [TEQ_08]
,	TLQ.TOX_EQ_VAL9 AS [TEQ_09]
,	TLQ.TOX_EQ_VAL10 AS [TEQ_10]
,	TLQ.TOX_EQ_VAL11 AS [TEQ_11]
,	TLQ.TOX_EQ_VAL12 AS [TEQ_12]
,	TLQ.TOX_EQ_VAL13 AS [TEQ_13]
,	TLQ.TOX_EQ_VAL14 AS [TEQ_14]
,	TLQ.TOX_EQ_VAL15 AS [TEQ_15]
,	TLQ.TOX_EQ_VAL16 AS [TEQ_16]
,	TLQ.TOX_EQ_VAL17 AS [TEQ_17]
,	TLQ.TOX_EQ_NA_IND AS [TEQ_NA]
,	TD.ECOLOGY_REGION AS [ECY Region]
,	TD.SUBMISSION_REPORTING_YEAR
,	TD.ECOLOGY_REGION
,	TD.FS_ID
,	TD.EPA_ID
,	TD.COUNTY_NM
,	TD.FAC_NAME
,	TD.AgencyName
,	TD.CHEMICAL_NAME_TEXT
,	TD.TRIFID
, POTW.POTW_SEQ_NO
, POTW.WASTE_Q_ME
, POTW.WASTE_Q_CATASTROPHIC_MEASURE
, POTW.WASTE_Q_RANGE_CODE
, POTW.WASTE_Q_RANGE_NUM_BASIS_VALUE
, POTW.WASTE_Q_ME_NA_IND
, POTW.Q_BASIS_EST_CODE
, POTW.Q_BASIS_EST_NA_IND
, POTW.TOX_EQ_VAL1
, POTW.TOX_EQ_VAL2
, POTW.TOX_EQ_VAL3
, POTW.TOX_EQ_VAL4
, POTW.TOX_EQ_VAL5
, POTW.TOX_EQ_VAL6
, POTW.TOX_EQ_VAL7
, POTW.TOX_EQ_VAL8
, POTW.TOX_EQ_VAL9
, POTW.TOX_EQ_VAL10
, POTW.TOX_EQ_VAL11
, POTW.TOX_EQ_VAL12
, POTW.TOX_EQ_VAL13
, POTW.TOX_EQ_VAL14
, POTW.TOX_EQ_VAL15
, POTW.TOX_EQ_VAL16
, POTW.TOX_EQ_VAL17
, POTW.TOX_EQ_NA_IND
, POTW.Q_DISP_LANDFILL_PERCENT_VALUE
, POTW.Q_DISP_OTHER_PERCENT_VALUE
, POTW.Q_TREATED_PERCENT_VALUE
, TD.DIOXIN_IND AS DIOXIN_IND
FROM dbo.TRI_TRANSFER_LOC AS TL
JOIN dbo.V_EXT_MASTER AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT
JOIN dbo.TRI_POTW_WASTE_QUANTITY POTW ON POTW.FK_GUID = TD.PK_GUID_REPORT
JOIN dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
WHERE TD.REPORT_TYPE = 'TRI_FORM_R'
  AND TD.CAS_NUMBER = 'N150';

GO


/****** Object:  View [dbo].[V_EXT_DIOXIN_ONSITE_RELEASE]    Script Date: 6/30/2015 2:13:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_EXT_DIOXIN_ONSITE_RELEASE]
AS
SELECT V_FORM_S1_PG1.PK_GUID_SUB
     , V_FORM_S1_PG1.PK_GUID_REP
     ,	T.AgencyID AS FSID
     ,	T.EPAID AS [EPA ID]
     ,	UPPER(F.FAC_ID) AS [TRI Facility Id]
     ,	R.SUB_REP_YEAR AS Year
     , CASE dbo.TRI_CalculateRevisionIndicator(r.pk_guid)
		       WHEN 1 
           THEN 'Y'
		       ELSE 'N'
	      END  AS Revision
     ,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
     ,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
     ,	F.FAC_SITE AS [Facility Name]
--     ,	T.AgencyName AS AKA
     ,	F.LOC_ADD_TXT AS [Address 1]
     ,	F.SUPP_LOC_TXT AS [Address 2]
     ,	F.LOCALITY AS City
     ,	F.COUNTY AS County
     ,	F.ADD_POSTAL_CODE AS Zip
     ,	C.CHEM_TXT AS Chemical
     ,	C.CAS_CLBER AS [CAS #]
,     V_FORM_S1_PG1.S151NA AS [51 Fugitive Air - TEQ_NAInd]
,     V_FORM_S1_PG1.S151T1 AS [51 Fugitive Air - TEQ_01]
,     V_FORM_S1_PG1.S151T2 AS [51 Fugitive Air - TEQ_02]
,     V_FORM_S1_PG1.S151T3 AS [51 Fugitive Air - TEQ_03]
,     V_FORM_S1_PG1.S151T4 AS [51 Fugitive Air - TEQ_04]
,     V_FORM_S1_PG1.S151T5 AS [51 Fugitive Air - TEQ_05]
,     V_FORM_S1_PG1.S151T6 AS [51 Fugitive Air - TEQ_06]
,     V_FORM_S1_PG1.S151T7 AS [51 Fugitive Air - TEQ_07]
,     V_FORM_S1_PG1.S151T8 AS [51 Fugitive Air - TEQ_08]
,     V_FORM_S1_PG1.S151T9 AS [51 Fugitive Air - TEQ_09]
,     V_FORM_S1_PG1.S151T10 AS [51 Fugitive Air - TEQ_10]
,     V_FORM_S1_PG1.S151T11 AS [51 Fugitive Air - TEQ_11]
,     V_FORM_S1_PG1.S151T12 AS [51 Fugitive Air - TEQ_12]
,     V_FORM_S1_PG1.S151T13 AS [51 Fugitive Air - TEQ_13]
,     V_FORM_S1_PG1.S151T14 AS [51 Fugitive Air - TEQ_14]
,     V_FORM_S1_PG1.S151T15 AS [51 Fugitive Air - TEQ_15]
,     V_FORM_S1_PG1.S151T16 AS [51 Fugitive Air - TEQ_16]
,     V_FORM_S1_PG1.S151T17 AS [51 Fugitive Air - TEQ_17]
,     V_FORM_S1_PG1.S152NA AS [52 Stack Air - TEQ_NAInd]
,     V_FORM_S1_PG1.S152T1 AS [52 Stack Air - TEQ_01]
,     V_FORM_S1_PG1.S152T2 AS [52 Stack Air - TEQ_02]
,     V_FORM_S1_PG1.S152T3 AS [52 Stack Air - TEQ_03]
,     V_FORM_S1_PG1.S152T4 AS [52 Stack Air - TEQ_04]
,     V_FORM_S1_PG1.S152T5 AS [52 Stack Air - TEQ_05]
,     V_FORM_S1_PG1.S152T6 AS [52 Stack Air - TEQ_06]
,     V_FORM_S1_PG1.S152T7 AS [52 Stack Air - TEQ_07]
,     V_FORM_S1_PG1.S152T8 AS [52 Stack Air - TEQ_08]
,     V_FORM_S1_PG1.S152T9 AS [52 Stack Air - TEQ_09]
,     V_FORM_S1_PG1.S152T10 AS [52 Stack Air - TEQ_10]
,     V_FORM_S1_PG1.S152T11 AS [52 Stack Air - TEQ_11]
,     V_FORM_S1_PG1.S152T12 AS [52 Stack Air - TEQ_12]
,     V_FORM_S1_PG1.S152T13 AS [52 Stack Air - TEQ_13]
,     V_FORM_S1_PG1.S152T14 AS [52 Stack Air - TEQ_14]
,     V_FORM_S1_PG1.S152T15 AS [52 Stack Air - TEQ_15]
,     V_FORM_S1_PG1.S152T16 AS [52 Stack Air - TEQ_16]
,     V_FORM_S1_PG1.S152T17 AS [52 Stack Air - TEQ_17]
,     V_FORM_S1_PG1.S1531NA AS [531 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1531T1 AS [531 Water - TEQ_01]
,     V_FORM_S1_PG1.S1531T2 AS [531 Water - TEQ_02]
,     V_FORM_S1_PG1.S1531T3 AS [531 Water - TEQ_03]
,     V_FORM_S1_PG1.S1531T4 AS [531 Water - TEQ_04]
,     V_FORM_S1_PG1.S1531T5 AS [531 Water - TEQ_05]
,     V_FORM_S1_PG1.S1531T6 AS [531 Water - TEQ_06]
,     V_FORM_S1_PG1.S1531T7 AS [531 Water - TEQ_07]
,     V_FORM_S1_PG1.S1531T8 AS [531 Water - TEQ_08]
,     V_FORM_S1_PG1.S1531T9 AS [531 Water - TEQ_09]
,     V_FORM_S1_PG1.S1531T10 AS [531 Water - TEQ_10]
,     V_FORM_S1_PG1.S1531T11 AS [531 Water - TEQ_11]
,     V_FORM_S1_PG1.S1531T12 AS [531 Water - TEQ_12]
,     V_FORM_S1_PG1.S1531T13 AS [531 Water - TEQ_13]
,     V_FORM_S1_PG1.S1531T14 AS [531 Water - TEQ_14]
,     V_FORM_S1_PG1.S1531T15 AS [531 Water - TEQ_15]
,     V_FORM_S1_PG1.S1531T16 AS [531 Water - TEQ_16]
,     V_FORM_S1_PG1.S1531T17 AS [531 Water - TEQ_17]
,     V_FORM_S1_PG1.S1532NA AS [532 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1532T1 AS [532 Water - TEQ_01]
,     V_FORM_S1_PG1.S1532T2 AS [532 Water - TEQ_02]
,     V_FORM_S1_PG1.S1532T3 AS [532 Water - TEQ_03]
,     V_FORM_S1_PG1.S1532T4 AS [532 Water - TEQ_04]
,     V_FORM_S1_PG1.S1532T5 AS [532 Water - TEQ_05]
,     V_FORM_S1_PG1.S1532T6 AS [532 Water - TEQ_06]
,     V_FORM_S1_PG1.S1532T7 AS [532 Water - TEQ_07]
,     V_FORM_S1_PG1.S1532T8 AS [532 Water - TEQ_08]
,     V_FORM_S1_PG1.S1532T9 AS [532 Water - TEQ_09]
,     V_FORM_S1_PG1.S1532T10 AS [532 Water - TEQ_10]
,     V_FORM_S1_PG1.S1532T11 AS [532 Water - TEQ_11]
,     V_FORM_S1_PG1.S1532T12 AS [532 Water - TEQ_12]
,     V_FORM_S1_PG1.S1532T13 AS [532 Water - TEQ_13]
,     V_FORM_S1_PG1.S1532T14 AS [532 Water - TEQ_14]
,     V_FORM_S1_PG1.S1532T15 AS [532 Water - TEQ_15]
,     V_FORM_S1_PG1.S1532T16 AS [532 Water - TEQ_16]
,     V_FORM_S1_PG1.S1532T17 AS [532 Water - TEQ_17]
,     V_FORM_S1_PG1.S1533NA AS [533 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1533T1 AS [533 Water - TEQ_01]
,     V_FORM_S1_PG1.S1533T2 AS [533 Water - TEQ_02]
,     V_FORM_S1_PG1.S1533T3 AS [533 Water - TEQ_03]
,     V_FORM_S1_PG1.S1533T4 AS [533 Water - TEQ_04]
,     V_FORM_S1_PG1.S1533T5 AS [533 Water - TEQ_05]
,     V_FORM_S1_PG1.S1533T6 AS [533 Water - TEQ_06]
,     V_FORM_S1_PG1.S1533T7 AS [533 Water - TEQ_07]
,     V_FORM_S1_PG1.S1533T8 AS [533 Water - TEQ_08]
,     V_FORM_S1_PG1.S1533T9 AS [533 Water - TEQ_09]
,     V_FORM_S1_PG1.S1533T10 AS [533 Water - TEQ_10]
,     V_FORM_S1_PG1.S1533T11 AS [533 Water - TEQ_11]
,     V_FORM_S1_PG1.S1533T12 AS [533 Water - TEQ_12]
,     V_FORM_S1_PG1.S1533T13 AS [533 Water - TEQ_13]
,     V_FORM_S1_PG1.S1533T14 AS [533 Water - TEQ_14]
,     V_FORM_S1_PG1.S1533T15 AS [533 Water - TEQ_15]
,     V_FORM_S1_PG1.S1533T16 AS [533 Water - TEQ_16]
,     V_FORM_S1_PG1.S1533T17 AS [533 Water - TEQ_17]
,     V_FORM_S1_PG2.S1541NA AS [541 UG INJ Class I - TEQ_NAInd]
,     V_FORM_S1_PG2.S1541T1 AS [541 UG INJ Class I - TEQ_01]
,     V_FORM_S1_PG2.S1541T2 AS [541 UG INJ Class I - TEQ_02]
,     V_FORM_S1_PG2.S1541T3 AS [541 UG INJ Class I - TEQ_03]
,     V_FORM_S1_PG2.S1541T4 AS [541 UG INJ Class I - TEQ_04]
,     V_FORM_S1_PG2.S1541T5 AS [541 UG INJ Class I - TEQ_05]
,     V_FORM_S1_PG2.S1541T6 AS [541 UG INJ Class I - TEQ_06]
,     V_FORM_S1_PG2.S1541T7 AS [541 UG INJ Class I - TEQ_07]
,     V_FORM_S1_PG2.S1541T8 AS [541 UG INJ Class I - TEQ_08]
,     V_FORM_S1_PG2.S1541T9 AS [541 UG INJ Class I - TEQ_09]
,     V_FORM_S1_PG2.S1541T10 AS [541 UG INJ Class I - TEQ_10]
,     V_FORM_S1_PG2.S1541T11 AS [541 UG INJ Class I - TEQ_11]
,     V_FORM_S1_PG2.S1541T12 AS [541 UG INJ Class I - TEQ_12]
,     V_FORM_S1_PG2.S1541T13 AS [541 UG INJ Class I - TEQ_13]
,     V_FORM_S1_PG2.S1541T14 AS [541 UG INJ Class I - TEQ_14]
,     V_FORM_S1_PG2.S1541T15 AS [541 UG INJ Class I - TEQ_15]
,     V_FORM_S1_PG2.S1541T16 AS [541 UG INJ Class I - TEQ_16]
,     V_FORM_S1_PG2.S1541T17 AS [541 UG INJ Class I - TEQ_17]
,     V_FORM_S1_PG2.S1542NA AS [542 UG INJ Class II-V - TEQ_NAInd]
,     V_FORM_S1_PG2.S1542T1 AS [542 UG INJ Class II-V - TEQ_01]
,     V_FORM_S1_PG2.S1542T2 AS [542 UG INJ Class II-V - TEQ_02]
,     V_FORM_S1_PG2.S1542T3 AS [542 UG INJ Class II-V - TEQ_03]
,     V_FORM_S1_PG2.S1542T4 AS [542 UG INJ Class II-V - TEQ_04]
,     V_FORM_S1_PG2.S1542T5 AS [542 UG INJ Class II-V - TEQ_05]
,     V_FORM_S1_PG2.S1542T6 AS [542 UG INJ Class II-V - TEQ_06]
,     V_FORM_S1_PG2.S1542T7 AS [542 UG INJ Class II-V - TEQ_07]
,     V_FORM_S1_PG2.S1542T8 AS [542 UG INJ Class II-V - TEQ_08]
,     V_FORM_S1_PG2.S1542T9 AS [542 UG INJ Class II-V - TEQ_09]
,     V_FORM_S1_PG2.S1542T10 AS [542 UG INJ Class II-V - TEQ_10]
,     V_FORM_S1_PG2.S1542T11 AS [542 UG INJ Class II-V - TEQ_11]
,     V_FORM_S1_PG2.S1542T12 AS [542 UG INJ Class II-V - TEQ_12]
,     V_FORM_S1_PG2.S1542T13 AS [542 UG INJ Class II-V - TEQ_13]
,     V_FORM_S1_PG2.S1542T14 AS [542 UG INJ Class II-V - TEQ_14]
,     V_FORM_S1_PG2.S1542T15 AS [542 UG INJ Class II-V - TEQ_15]
,     V_FORM_S1_PG2.S1542T16 AS [542 UG INJ Class II-V - TEQ_16]
,     V_FORM_S1_PG2.S1542T17 AS [542 UG INJ Class II-V - TEQ_17]
,     V_FORM_S1_PG2.S1551ANA AS [551A RCRA C Landfill - TEQ_NAInd]
,     V_FORM_S1_PG2.S1551AT1 AS [551A RCRA C Landfill - TEQ_01]
,     V_FORM_S1_PG2.S1551AT2 AS [551A RCRA C Landfill - TEQ_02]
,     V_FORM_S1_PG2.S1551AT3 AS [551A RCRA C Landfill - TEQ_03]
,     V_FORM_S1_PG2.S1551AT4 AS [551A RCRA C Landfill - TEQ_04]
,     V_FORM_S1_PG2.S1551AT5 AS [551A RCRA C Landfill - TEQ_05]
,     V_FORM_S1_PG2.S1551AT6 AS [551A RCRA C Landfill - TEQ_06]
,     V_FORM_S1_PG2.S1551AT7 AS [551A RCRA C Landfill - TEQ_07]
,     V_FORM_S1_PG2.S1551AT8 AS [551A RCRA C Landfill - TEQ_08]
,     V_FORM_S1_PG2.S1551AT9 AS [551A RCRA C Landfill - TEQ_09]
,     V_FORM_S1_PG2.S1551AT10 AS [551A RCRA C Landfill - TEQ_10]
,     V_FORM_S1_PG2.S1551AT11 AS [551A RCRA C Landfill - TEQ_11]
,     V_FORM_S1_PG2.S1551AT12 AS [551A RCRA C Landfill - TEQ_12]
,     V_FORM_S1_PG2.S1551AT13 AS [551A RCRA C Landfill - TEQ_13]
,     V_FORM_S1_PG2.S1551AT14 AS [551A RCRA C Landfill - TEQ_14]
,     V_FORM_S1_PG2.S1551AT15 AS [551A RCRA C Landfill - TEQ_15]
,     V_FORM_S1_PG2.S1551AT16 AS [551A RCRA C Landfill - TEQ_16]
,     V_FORM_S1_PG2.S1551AT17 AS [551A RCRA C Landfill - TEQ_17]
,     V_FORM_S1_PG2.S1551BNA AS [551B Other Landfill - TEQ_NAInd]
,     V_FORM_S1_PG2.S1551BT1 AS [551B Other Landfill - TEQ_01]
,     V_FORM_S1_PG2.S1551BT2 AS [551B Other Landfill - TEQ_02]
,     V_FORM_S1_PG2.S1551BT3 AS [551B Other Landfill - TEQ_03]
,     V_FORM_S1_PG2.S1551BT4 AS [551B Other Landfill - TEQ_04]
,     V_FORM_S1_PG2.S1551BT5 AS [551B Other Landfill - TEQ_05]
,     V_FORM_S1_PG2.S1551BT6 AS [551B Other Landfill - TEQ_06]
,     V_FORM_S1_PG2.S1551BT7 AS [551B Other Landfill - TEQ_07]
,     V_FORM_S1_PG2.S1551BT8 AS [551B Other Landfill - TEQ_08]
,     V_FORM_S1_PG2.S1551BT9 AS [551B Other Landfill - TEQ_09]
,     V_FORM_S1_PG2.S1551BT10 AS [551B Other Landfill - TEQ_10]
,     V_FORM_S1_PG2.S1551BT11 AS [551B Other Landfill - TEQ_11]
,     V_FORM_S1_PG2.S1551BT12 AS [551B Other Landfill - TEQ_12]
,     V_FORM_S1_PG2.S1551BT13 AS [551B Other Landfill - TEQ_13]
,     V_FORM_S1_PG2.S1551BT14 AS [551B Other Landfill - TEQ_14]
,     V_FORM_S1_PG2.S1551BT15 AS [551B Other Landfill - TEQ_15]
,     V_FORM_S1_PG2.S1551BT16 AS [551B Other Landfill - TEQ_16]
,     V_FORM_S1_PG2.S1551BT17 AS [551B Other Landfill - TEQ_17]
,     V_FORM_S1_PG2.S1552NA AS [552 Land Treatment - TEQ_NAInd]
,     V_FORM_S1_PG2.S1552T1 AS [552 Land Treatment - TEQ_01]
,     V_FORM_S1_PG2.S1552T2 AS [552 Land Treatment - TEQ_02]
,     V_FORM_S1_PG2.S1552T3 AS [552 Land Treatment - TEQ_03]
,     V_FORM_S1_PG2.S1552T4 AS [552 Land Treatment - TEQ_04]
,     V_FORM_S1_PG2.S1552T5 AS [552 Land Treatment - TEQ_05]
,     V_FORM_S1_PG2.S1552T6 AS [552 Land Treatment - TEQ_06]
,     V_FORM_S1_PG2.S1552T7 AS [552 Land Treatment - TEQ_07]
,     V_FORM_S1_PG2.S1552T8 AS [552 Land Treatment - TEQ_08]
,     V_FORM_S1_PG2.S1552T9 AS [552 Land Treatment - TEQ_09]
,     V_FORM_S1_PG2.S1552T10 AS [552 Land Treatment - TEQ_10]
,     V_FORM_S1_PG2.S1552T11 AS [552 Land Treatment - TEQ_11]
,     V_FORM_S1_PG2.S1552T12 AS [552 Land Treatment - TEQ_12]
,     V_FORM_S1_PG2.S1552T13 AS [552 Land Treatment - TEQ_13]
,     V_FORM_S1_PG2.S1552T14 AS [552 Land Treatment - TEQ_14]
,     V_FORM_S1_PG2.S1552T15 AS [552 Land Treatment - TEQ_15]
,     V_FORM_S1_PG2.S1552T16 AS [552 Land Treatment - TEQ_16]
,     V_FORM_S1_PG2.S1552T17 AS [552 Land Treatment - TEQ_17]
,     V_FORM_S1_PG2.S1553ANA AS [553A RCRA C SI - TEQ_NAInd]
,     V_FORM_S1_PG2.S1553AT1 AS [553A RCRA C SI - TEQ_01]
,     V_FORM_S1_PG2.S1553AT2 AS [553A RCRA C SI - TEQ_02]
,     V_FORM_S1_PG2.S1553AT3 AS [553A RCRA C SI - TEQ_03]
,     V_FORM_S1_PG2.S1553AT4 AS [553A RCRA C SI - TEQ_04]
,     V_FORM_S1_PG2.S1553AT5 AS [553A RCRA C SI - TEQ_05]
,     V_FORM_S1_PG2.S1553AT6 AS [553A RCRA C SI - TEQ_06]
,     V_FORM_S1_PG2.S1553AT7 AS [553A RCRA C SI - TEQ_07]
,     V_FORM_S1_PG2.S1553AT8 AS [553A RCRA C SI - TEQ_08]
,     V_FORM_S1_PG2.S1553AT9 AS [553A RCRA C SI - TEQ_09]
,     V_FORM_S1_PG2.S1553AT10 AS [553A RCRA C SI - TEQ_10]
,     V_FORM_S1_PG2.S1553AT11 AS [553A RCRA C SI - TEQ_11]
,     V_FORM_S1_PG2.S1553AT12 AS [553A RCRA C SI - TEQ_12]
,     V_FORM_S1_PG2.S1553AT13 AS [553A RCRA C SI - TEQ_13]
,     V_FORM_S1_PG2.S1553AT14 AS [553A RCRA C SI - TEQ_14]
,     V_FORM_S1_PG2.S1553AT15 AS [553A RCRA C SI - TEQ_15]
,     V_FORM_S1_PG2.S1553AT16 AS [553A RCRA C SI - TEQ_16]
,     V_FORM_S1_PG2.S1553AT17 AS [553A RCRA C SI - TEQ_17]
,     V_FORM_S1_PG2.S1553BNA AS [553B Other SI - TEQ_NAInd]
,     V_FORM_S1_PG2.S1553BT1 AS [553B Other SI - TEQ_01]
,     V_FORM_S1_PG2.S1553BT2 AS [553B Other SI - TEQ_02]
,     V_FORM_S1_PG2.S1553BT3 AS [553B Other SI - TEQ_03]
,     V_FORM_S1_PG2.S1553BT4 AS [553B Other SI - TEQ_04]
,     V_FORM_S1_PG2.S1553BT5 AS [553B Other SI - TEQ_05]
,     V_FORM_S1_PG2.S1553BT6 AS [553B Other SI - TEQ_06]
,     V_FORM_S1_PG2.S1553BT7 AS [553B Other SI - TEQ_07]
,     V_FORM_S1_PG2.S1553BT8 AS [553B Other SI - TEQ_08]
,     V_FORM_S1_PG2.S1553BT9 AS [553B Other SI - TEQ_09]
,     V_FORM_S1_PG2.S1553BT10 AS [553B Other SI - TEQ_10]
,     V_FORM_S1_PG2.S1553BT11 AS [553B Other SI - TEQ_11]
,     V_FORM_S1_PG2.S1553BT12 AS [553B Other SI - TEQ_12]
,     V_FORM_S1_PG2.S1553BT13 AS [553B Other SI - TEQ_13]
,     V_FORM_S1_PG2.S1553BT14 AS [553B Other SI - TEQ_14]
,     V_FORM_S1_PG2.S1553BT15 AS [553B Other SI - TEQ_15]
,     V_FORM_S1_PG2.S1553BT16 AS [553B Other SI - TEQ_16]
,     V_FORM_S1_PG2.S1553BT17 AS [553B Other SI - TEQ_17]
,     V_FORM_S1_PG2.S1554NA AS [554 Other Disposal - TEQ_NAInd]
,     V_FORM_S1_PG2.S1554T1 AS [554 Other Disposal - TEQ_01]
,     V_FORM_S1_PG2.S1554T2 AS [554 Other Disposal - TEQ_02]
,     V_FORM_S1_PG2.S1554T3 AS [554 Other Disposal - TEQ_03]
,     V_FORM_S1_PG2.S1554T4 AS [554 Other Disposal - TEQ_04]
,     V_FORM_S1_PG2.S1554T5 AS [554 Other Disposal - TEQ_05]
,     V_FORM_S1_PG2.S1554T6 AS [554 Other Disposal - TEQ_06]
,     V_FORM_S1_PG2.S1554T7 AS [554 Other Disposal - TEQ_07]
,     V_FORM_S1_PG2.S1554T8 AS [554 Other Disposal - TEQ_08]
,     V_FORM_S1_PG2.S1554T9 AS [554 Other Disposal - TEQ_09]
,     V_FORM_S1_PG2.S1554T10 AS [554 Other Disposal - TEQ_10]
,     V_FORM_S1_PG2.S1554T11 AS [554 Other Disposal - TEQ_11]
,     V_FORM_S1_PG2.S1554T12 AS [554 Other Disposal - TEQ_12]
,     V_FORM_S1_PG2.S1554T13 AS [554 Other Disposal - TEQ_13]
,     V_FORM_S1_PG2.S1554T14 AS [554 Other Disposal - TEQ_14]
,     V_FORM_S1_PG2.S1554T15 AS [554 Other Disposal - TEQ_15]
,     V_FORM_S1_PG2.S1554T16 AS [554 Other Disposal - TEQ_16]
,     V_FORM_S1_PG2.S1554T17 AS [554 Other Disposal - TEQ_17]
,     R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,     CTYREG.EcologyRegion AS ECOLOGY_REGION
,     CTYREG.EcologyRegion AS [ECY Region]
,     T.AgencyID AS FS_ID
,     T.EPAID AS EPA_ID
,     F.COUNTY AS COUNTY_NM
,     F.FAC_SITE AS FAC_NAME
,     T.AgencyName
,     C.CHEM_TXT AS CHEMICAL_NAME_TEXT
     ,	UPPER(F.FAC_ID) AS TRIFID
,     CASE C.CAS_CLBER 
        WHEN 'N150' THEN 1
        ELSE 0
      END AS [DIOXIN_IND]
FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
LEFT JOIN dbo.App_Lookup_Cty_Reg CTYREG ON CTYREG.County = F.COUNTY
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN dbo.App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
JOIN [dbo].[V_FORM_S1_PG1] ON [dbo].[V_FORM_S1_PG1].PK_GUID_REP = R.PK_GUID
JOIN [dbo].[V_FORM_S1_PG2] ON [dbo].[V_FORM_S1_PG2].PK_GUID_REP = R.PK_GUID
LEFT JOIN APP_FI_TRIFID_DELETE_CHEM ON APP_FI_TRIFID_DELETE_CHEM.TRI_REPORT_ID = r.PK_GUID
WHERE APP_FI_TRIFID_DELETE_CHEM.TRIFID_DELETE_CHEM_ID IS NULL
AND S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	  FROM TRI_REPORT R2
		 JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		 JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		 JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE F2.FAC_ID = F.FAC_ID
		  AND R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		  AND C2.CHEM_TXT = C.CHEM_TXT)
 AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL
 AND C.CAS_CLBER = 'N150';

GO


PRINT 'V_EXT_DIOXIN_ONSITE_RELEASE was altered!'

/****** Object:  View [dbo].[V_EXT_DIOXIN_SECTION_8]    Script Date: 6/30/2015 2:15:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_EXT_DIOXIN_SECTION_8]
AS
SELECT V_FORM_S1_PG1.PK_GUID_SUB
,     V_FORM_S1_PG1.PK_GUID_REP
,	T.AgencyID AS FSID
,	T.EPAID AS [EPA ID]
,	UPPER(F.FAC_ID) AS [TRI Facility Id]
,	R.SUB_REP_YEAR AS Year
,	CASE dbo.TRI_CalculateRevisionIndicator(r.pk_guid)
		       WHEN 1 
           THEN 'Y'
		       ELSE 'N'
	      END AS Revision
,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
,	F.FAC_SITE AS [Facility Name]
-- ,	T.AgencyName AS AKA
,	F.LOC_ADD_TXT AS [Address 1]
,	F.SUPP_LOC_TXT AS [Address 2]
,	F.LOCALITY AS City
,	F.COUNTY AS County
,	F.ADD_POSTAL_CODE AS Zip
,	C.CHEM_TXT AS Chemical
,	C.CAS_CLBER AS [CAS #]
,     V_FORM_S1_PG4.S181ANA AS [81A Ons Disp UG INJ C1 - TEQ_NAInd]
,     V_FORM_S1_PG4.S181AT1 AS [81A Ons Disp UG INJ C1 - TEQ_01]
,     V_FORM_S1_PG4.S181AT2 AS [81A Ons Disp UG INJ C1 - TEQ_02]
,     V_FORM_S1_PG4.S181AT3 AS [81A Ons Disp UG INJ C1 - TEQ_03]
,     V_FORM_S1_PG4.S181AT4 AS [81A Ons Disp UG INJ C1 - TEQ_04]
,     V_FORM_S1_PG4.S181AT5 AS [81A Ons Disp UG INJ C1 - TEQ_05]
,     V_FORM_S1_PG4.S181AT6 AS [81A Ons Disp UG INJ C1 - TEQ_06]
,     V_FORM_S1_PG4.S181AT7 AS [81A Ons Disp UG INJ C1 - TEQ_07]
,     V_FORM_S1_PG4.S181AT8 AS [81A Ons Disp UG INJ C1 - TEQ_08]
,     V_FORM_S1_PG4.S181AT9 AS [81A Ons Disp UG INJ C1 - TEQ_09]
,     V_FORM_S1_PG4.S181AT10 AS [81A Ons Disp UG INJ C1 - TEQ_10]
,     V_FORM_S1_PG4.S181AT11 AS [81A Ons Disp UG INJ C1 - TEQ_11]
,     V_FORM_S1_PG4.S181AT12 AS [81A Ons Disp UG INJ C1 - TEQ_12]
,     V_FORM_S1_PG4.S181AT13 AS [81A Ons Disp UG INJ C1 - TEQ_13]
,     V_FORM_S1_PG4.S181AT14 AS [81A Ons Disp UG INJ C1 - TEQ_14]
,     V_FORM_S1_PG4.S181AT15 AS [81A Ons Disp UG INJ C1 - TEQ_15]
,     V_FORM_S1_PG4.S181AT16 AS [81A Ons Disp UG INJ C1 - TEQ_16]
,     V_FORM_S1_PG4.S181AT17 AS [81A Ons Disp UG INJ C1 - TEQ_17]
,     V_FORM_S1_PG4.S181BNA AS [81B Ons Disp Other - TEQ_NAInd]
,     V_FORM_S1_PG4.S181BT1 AS [81B Ons Disp Other - TEQ_01]
,     V_FORM_S1_PG4.S181BT2 AS [81B Ons Disp Other - TEQ_02]
,     V_FORM_S1_PG4.S181BT3 AS [81B Ons Disp Other - TEQ_03]
,     V_FORM_S1_PG4.S181BT4 AS [81B Ons Disp Other - TEQ_04]
,     V_FORM_S1_PG4.S181BT5 AS [81B Ons Disp Other - TEQ_05]
,     V_FORM_S1_PG4.S181BT6 AS [81B Ons Disp Other - TEQ_06]
,     V_FORM_S1_PG4.S181BT7 AS [81B Ons Disp Other - TEQ_07]
,     V_FORM_S1_PG4.S181BT8 AS [81B Ons Disp Other - TEQ_08]
,     V_FORM_S1_PG4.S181BT9 AS [81B Ons Disp Other - TEQ_09]
,     V_FORM_S1_PG4.S181BT10 AS [81B Ons Disp Other - TEQ_10]
,     V_FORM_S1_PG4.S181BT11 AS [81B Ons Disp Other - TEQ_11]
,     V_FORM_S1_PG4.S181BT12 AS [81B Ons Disp Other - TEQ_12]
,     V_FORM_S1_PG4.S181BT13 AS [81B Ons Disp Other - TEQ_13]
,     V_FORM_S1_PG4.S181BT14 AS [81B Ons Disp Other - TEQ_14]
,     V_FORM_S1_PG4.S181BT15 AS [81B Ons Disp Other - TEQ_15]
,     V_FORM_S1_PG4.S181BT16 AS [81B Ons Disp Other - TEQ_16]
,     V_FORM_S1_PG4.S181BT17 AS [81B Ons Disp Other - TEQ_17]
,     V_FORM_S1_PG4.S181CNA AS [81C Off Disp UG INJ C1 - TEQ_NAInd]
,     V_FORM_S1_PG4.S181CT1 AS [81C Off Disp UG INJ C1 - TEQ_01]
,     V_FORM_S1_PG4.S181CT2 AS [81C Off Disp UG INJ C1 - TEQ_02]
,     V_FORM_S1_PG4.S181CT3 AS [81C Off Disp UG INJ C1 - TEQ_03]
,     V_FORM_S1_PG4.S181CT4 AS [81C Off Disp UG INJ C1 - TEQ_04]
,     V_FORM_S1_PG4.S181CT5 AS [81C Off Disp UG INJ C1 - TEQ_05]
,     V_FORM_S1_PG4.S181CT6 AS [81C Off Disp UG INJ C1 - TEQ_06]
,     V_FORM_S1_PG4.S181CT7 AS [81C Off Disp UG INJ C1 - TEQ_07]
,     V_FORM_S1_PG4.S181CT8 AS [81C Off Disp UG INJ C1 - TEQ_08]
,     V_FORM_S1_PG4.S181CT9 AS [81C Off Disp UG INJ C1 - TEQ_09]
,     V_FORM_S1_PG4.S181CT10 AS [81C Off Disp UG INJ C1 - TEQ_10]
,     V_FORM_S1_PG4.S181CT11 AS [81C Off Disp UG INJ C1 - TEQ_11]
,     V_FORM_S1_PG4.S181CT12 AS [81C Off Disp UG INJ C1 - TEQ_12]
,     V_FORM_S1_PG4.S181CT13 AS [81C Off Disp UG INJ C1 - TEQ_13]
,     V_FORM_S1_PG4.S181CT14 AS [81C Off Disp UG INJ C1 - TEQ_14]
,     V_FORM_S1_PG4.S181CT15 AS [81C Off Disp UG INJ C1 - TEQ_15]
,     V_FORM_S1_PG4.S181CT16 AS [81C Off Disp UG INJ C1 - TEQ_16]
,     V_FORM_S1_PG4.S181CT17 AS [81C Off Disp UG INJ C1 - TEQ_17]
,     V_FORM_S1_PG4.S181DNA AS [81D Off Disp Other - TEQ_NAInd]
,     V_FORM_S1_PG4.S181DT1 AS [81D Off Disp Other - TEQ_01]
,     V_FORM_S1_PG4.S181DT2 AS [81D Off Disp Other - TEQ_02]
,     V_FORM_S1_PG4.S181DT3 AS [81D Off Disp Other - TEQ_03]
,     V_FORM_S1_PG4.S181DT4 AS [81D Off Disp Other - TEQ_04]
,     V_FORM_S1_PG4.S181DT5 AS [81D Off Disp Other - TEQ_05]
,     V_FORM_S1_PG4.S181DT6 AS [81D Off Disp Other - TEQ_06]
,     V_FORM_S1_PG4.S181DT7 AS [81D Off Disp Other - TEQ_07]
,     V_FORM_S1_PG4.S181DT8 AS [81D Off Disp Other - TEQ_08]
,     V_FORM_S1_PG4.S181DT9 AS [81D Off Disp Other - TEQ_09]
,     V_FORM_S1_PG4.S181DT10 AS [81D Off Disp Other - TEQ_10]
,     V_FORM_S1_PG4.S181DT11 AS [81D Off Disp Other - TEQ_11]
,     V_FORM_S1_PG4.S181DT12 AS [81D Off Disp Other - TEQ_12]
,     V_FORM_S1_PG4.S181DT13 AS [81D Off Disp Other - TEQ_13]
,     V_FORM_S1_PG4.S181DT14 AS [81D Off Disp Other - TEQ_14]
,     V_FORM_S1_PG4.S181DT15 AS [81D Off Disp Other - TEQ_15]
,     V_FORM_S1_PG4.S181DT16 AS [81D Off Disp Other - TEQ_16]
,     V_FORM_S1_PG4.S181DT17 AS [81D Off Disp Other - TEQ_17]
,     V_FORM_S1_PG4.S182NA AS [82 Ons Eng Rec - TEQ_NAInd]
,     V_FORM_S1_PG4.S182T1 AS [82 Ons Eng Rec - TEQ_01]
,     V_FORM_S1_PG4.S182T2 AS [82 Ons Eng Rec - TEQ_02]
,     V_FORM_S1_PG4.S182T3 AS [82 Ons Eng Rec - TEQ_03]
,     V_FORM_S1_PG4.S182T4 AS [82 Ons Eng Rec - TEQ_04]
,     V_FORM_S1_PG4.S182T5 AS [82 Ons Eng Rec - TEQ_05]
,     V_FORM_S1_PG4.S182T6 AS [82 Ons Eng Rec - TEQ_06]
,     V_FORM_S1_PG4.S182T7 AS [82 Ons Eng Rec - TEQ_07]
,     V_FORM_S1_PG4.S182T8 AS [82 Ons Eng Rec - TEQ_08]
,     V_FORM_S1_PG4.S182T9 AS [82 Ons Eng Rec - TEQ_09]
,     V_FORM_S1_PG4.S182T10 AS [82 Ons Eng Rec - TEQ_10]
,     V_FORM_S1_PG4.S182T11 AS [82 Ons Eng Rec - TEQ_11]
,     V_FORM_S1_PG4.S182T12 AS [82 Ons Eng Rec - TEQ_12]
,     V_FORM_S1_PG4.S182T13 AS [82 Ons Eng Rec - TEQ_13]
,     V_FORM_S1_PG4.S182T14 AS [82 Ons Eng Rec - TEQ_14]
,     V_FORM_S1_PG4.S182T15 AS [82 Ons Eng Rec - TEQ_15]
,     V_FORM_S1_PG4.S182T16 AS [82 Ons Eng Rec - TEQ_16]
,     V_FORM_S1_PG4.S182T17 AS [82 Ons Eng Rec - TEQ_17]
,     V_FORM_S1_PG4.S183NA AS [83 Off Eng Rec - TEQ_NAInd]
,     V_FORM_S1_PG4.S183T1 AS [83 Off Eng Rec - TEQ_01]
,     V_FORM_S1_PG4.S183T2 AS [83 Off Eng Rec - TEQ_02]
,     V_FORM_S1_PG4.S183T3 AS [83 Off Eng Rec - TEQ_03]
,     V_FORM_S1_PG4.S183T4 AS [83 Off Eng Rec - TEQ_04]
,     V_FORM_S1_PG4.S183T5 AS [83 Off Eng Rec - TEQ_05]
,     V_FORM_S1_PG4.S183T6 AS [83 Off Eng Rec - TEQ_06]
,     V_FORM_S1_PG4.S183T7 AS [83 Off Eng Rec - TEQ_07]
,     V_FORM_S1_PG4.S183T8 AS [83 Off Eng Rec - TEQ_08]
,     V_FORM_S1_PG4.S183T9 AS [83 Off Eng Rec - TEQ_09]
,     V_FORM_S1_PG4.S183T10 AS [83 Off Eng Rec - TEQ_10]
,     V_FORM_S1_PG4.S183T11 AS [83 Off Eng Rec - TEQ_11]
,     V_FORM_S1_PG4.S183T12 AS [83 Off Eng Rec - TEQ_12]
,     V_FORM_S1_PG4.S183T13 AS [83 Off Eng Rec - TEQ_13]
,     V_FORM_S1_PG4.S183T14 AS [83 Off Eng Rec - TEQ_14]
,     V_FORM_S1_PG4.S183T15 AS [83 Off Eng Rec - TEQ_15]
,     V_FORM_S1_PG4.S183T16 AS [83 Off Eng Rec - TEQ_16]
,     V_FORM_S1_PG4.S183T17 AS [83 Off Eng Rec - TEQ_17]
,     V_FORM_S1_PG4.S184NA AS [84 Ons Recycle - TEQ_NAInd]
,     V_FORM_S1_PG4.S184T1 AS [84 Ons Recycle - TEQ_01]
,     V_FORM_S1_PG4.S184T2 AS [84 Ons Recycle - TEQ_02]
,     V_FORM_S1_PG4.S184T3 AS [84 Ons Recycle - TEQ_03]
,     V_FORM_S1_PG4.S184T4 AS [84 Ons Recycle - TEQ_04]
,     V_FORM_S1_PG4.S184T5 AS [84 Ons Recycle - TEQ_05]
,     V_FORM_S1_PG4.S184T6 AS [84 Ons Recycle - TEQ_06]
,     V_FORM_S1_PG4.S184T7 AS [84 Ons Recycle - TEQ_07]
,     V_FORM_S1_PG4.S184T8 AS [84 Ons Recycle - TEQ_08]
,     V_FORM_S1_PG4.S184T9 AS [84 Ons Recycle - TEQ_09]
,     V_FORM_S1_PG4.S184T10 AS [84 Ons Recycle - TEQ_10]
,     V_FORM_S1_PG4.S184T11 AS [84 Ons Recycle - TEQ_11]
,     V_FORM_S1_PG4.S184T12 AS [84 Ons Recycle - TEQ_12]
,     V_FORM_S1_PG4.S184T13 AS [84 Ons Recycle - TEQ_13]
,     V_FORM_S1_PG4.S184T14 AS [84 Ons Recycle - TEQ_14]
,     V_FORM_S1_PG4.S184T15 AS [84 Ons Recycle - TEQ_15]
,     V_FORM_S1_PG4.S184T16 AS [84 Ons Recycle - TEQ_16]
,     V_FORM_S1_PG4.S184T17 AS [84 Ons Recycle - TEQ_17]
,     V_FORM_S1_PG4.S185NA AS [85 Off Recycle - TEQ_NAInd]
,     V_FORM_S1_PG4.S185T1 AS [85 Off Recycle - TEQ_01]
,     V_FORM_S1_PG4.S185T2 AS [85 Off Recycle - TEQ_02]
,     V_FORM_S1_PG4.S185T3 AS [85 Off Recycle - TEQ_03]
,     V_FORM_S1_PG4.S185T4 AS [85 Off Recycle - TEQ_04]
,     V_FORM_S1_PG4.S185T5 AS [85 Off Recycle - TEQ_05]
,     V_FORM_S1_PG4.S185T6 AS [85 Off Recycle - TEQ_06]
,     V_FORM_S1_PG4.S185T7 AS [85 Off Recycle - TEQ_07]
,     V_FORM_S1_PG4.S185T8 AS [85 Off Recycle - TEQ_08]
,     V_FORM_S1_PG4.S185T9 AS [85 Off Recycle - TEQ_09]
,     V_FORM_S1_PG4.S185T10 AS [85 Off Recycle - TEQ_10]
,     V_FORM_S1_PG4.S185T11 AS [85 Off Recycle - TEQ_11]
,     V_FORM_S1_PG4.S185T12 AS [85 Off Recycle - TEQ_12]
,     V_FORM_S1_PG4.S185T13 AS [85 Off Recycle - TEQ_13]
,     V_FORM_S1_PG4.S185T14 AS [85 Off Recycle - TEQ_14]
,     V_FORM_S1_PG4.S185T15 AS [85 Off Recycle - TEQ_15]
,     V_FORM_S1_PG4.S185T16 AS [85 Off Recycle - TEQ_16]
,     V_FORM_S1_PG4.S185T17 AS [85 Off Recycle - TEQ_17]
,     V_FORM_S1_PG4.S186NA AS [86 Ons Treated - TEQ_NAInd]
,     V_FORM_S1_PG4.S186T1 AS [86 Ons Treated - TEQ_01]
,     V_FORM_S1_PG4.S186T2 AS [86 Ons Treated - TEQ_02]
,     V_FORM_S1_PG4.S186T3 AS [86 Ons Treated - TEQ_03]
,     V_FORM_S1_PG4.S186T4 AS [86 Ons Treated - TEQ_04]
,     V_FORM_S1_PG4.S186T5 AS [86 Ons Treated - TEQ_05]
,     V_FORM_S1_PG4.S186T6 AS [86 Ons Treated - TEQ_06]
,     V_FORM_S1_PG4.S186T7 AS [86 Ons Treated - TEQ_07]
,     V_FORM_S1_PG4.S186T8 AS [86 Ons Treated - TEQ_08]
,     V_FORM_S1_PG4.S186T9 AS [86 Ons Treated - TEQ_09]
,     V_FORM_S1_PG4.S186T10 AS [86 Ons Treated - TEQ_10]
,     V_FORM_S1_PG4.S186T11 AS [86 Ons Treated - TEQ_11]
,     V_FORM_S1_PG4.S186T12 AS [86 Ons Treated - TEQ_12]
,     V_FORM_S1_PG4.S186T13 AS [86 Ons Treated - TEQ_13]
,     V_FORM_S1_PG4.S186T14 AS [86 Ons Treated - TEQ_14]
,     V_FORM_S1_PG4.S186T15 AS [86 Ons Treated - TEQ_15]
,     V_FORM_S1_PG4.S186T16 AS [86 Ons Treated - TEQ_16]
,     V_FORM_S1_PG4.S186T17 AS [86 Ons Treated - TEQ_17]
,     V_FORM_S1_PG4.S187NA AS [87 Off Treated - TEQ_NAInd]
,     V_FORM_S1_PG4.S187T1 AS [87 Off Treated - TEQ_01]
,     V_FORM_S1_PG4.S187T2 AS [87 Off Treated - TEQ_02]
,     V_FORM_S1_PG4.S187T3 AS [87 Off Treated - TEQ_03]
,     V_FORM_S1_PG4.S187T4 AS [87 Off Treated - TEQ_04]
,     V_FORM_S1_PG4.S187T5 AS [87 Off Treated - TEQ_05]
,     V_FORM_S1_PG4.S187T6 AS [87 Off Treated - TEQ_06]
,     V_FORM_S1_PG4.S187T7 AS [87 Off Treated - TEQ_07]
,     V_FORM_S1_PG4.S187T8 AS [87 Off Treated - TEQ_08]
,     V_FORM_S1_PG4.S187T9 AS [87 Off Treated - TEQ_09]
,     V_FORM_S1_PG4.S187T10 AS [87 Off Treated - TEQ_10]
,     V_FORM_S1_PG4.S187T11 AS [87 Off Treated - TEQ_11]
,     V_FORM_S1_PG4.S187T12 AS [87 Off Treated - TEQ_12]
,     V_FORM_S1_PG4.S187T13 AS [87 Off Treated - TEQ_13]
,     V_FORM_S1_PG4.S187T14 AS [87 Off Treated - TEQ_14]
,     V_FORM_S1_PG4.S187T15 AS [87 Off Treated - TEQ_15]
,     V_FORM_S1_PG4.S187T16 AS [87 Off Treated - TEQ_16]
,     V_FORM_S1_PG4.S187T17 AS [87 Off Treated - TEQ_17]
,     V_FORM_S1_PG4.S188NA AS [88 Remed One-Time - TEQ_NAInd]
,     V_FORM_S1_PG4.S188T1 AS [88 Remed One-Time - TEQ_01]
,     V_FORM_S1_PG4.S188T2 AS [88 Remed One-Time - TEQ_02]
,     V_FORM_S1_PG4.S188T3 AS [88 Remed One-Time - TEQ_03]
,     V_FORM_S1_PG4.S188T4 AS [88 Remed One-Time - TEQ_04]
,     V_FORM_S1_PG4.S188T5 AS [88 Remed One-Time - TEQ_05]
,     V_FORM_S1_PG4.S188T6 AS [88 Remed One-Time - TEQ_06]
,     V_FORM_S1_PG4.S188T7 AS [88 Remed One-Time - TEQ_07]
,     V_FORM_S1_PG4.S188T8 AS [88 Remed One-Time - TEQ_08]
,     V_FORM_S1_PG4.S188T9 AS [88 Remed One-Time - TEQ_09]
,     V_FORM_S1_PG4.S188T10 AS [88 Remed One-Time - TEQ_10]
,     V_FORM_S1_PG4.S188T11 AS [88 Remed One-Time - TEQ_11]
,     V_FORM_S1_PG4.S188T12 AS [88 Remed One-Time - TEQ_12]
,     V_FORM_S1_PG4.S188T13 AS [88 Remed One-Time - TEQ_13]
,     V_FORM_S1_PG4.S188T14 AS [88 Remed One-Time - TEQ_14]
,     V_FORM_S1_PG4.S188T15 AS [88 Remed One-Time - TEQ_15]
,     V_FORM_S1_PG4.S188T16 AS [88 Remed One-Time - TEQ_16]
,     V_FORM_S1_PG4.S188T17 AS [88 Remed One-Time - TEQ_17]
,     R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,     CTYREG.EcologyRegion AS [ECY Region]
,     CTYREG.EcologyRegion AS ECOLOGY_REGION
,     T.AgencyID AS FS_ID
,     T.EPAID AS EPA_ID
,     F.COUNTY AS COUNTY_NM
,     F.FAC_SITE AS FAC_NAME
,     T.AgencyName
,     C.CHEM_TXT AS CHEMICAL_NAME_TEXT
,	UPPER(F.FAC_ID) AS TRIFID
, CASE C.CAS_CLBER 
    WHEN 'N150' THEN 1
    ELSE 0
  END AS [DIOXIN_IND]
FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
LEFT JOIN dbo.App_Lookup_Cty_Reg CTYREG ON CTYREG.County = F.COUNTY
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN dbo.App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
JOIN [dbo].[V_FORM_S1_PG1] ON [dbo].[V_FORM_S1_PG1].PK_GUID_REP = R.PK_GUID
JOIN [dbo].[V_FORM_S1_PG4] ON [dbo].[V_FORM_S1_PG4].PK_GUID_REP = R.PK_GUID
LEFT JOIN APP_FI_TRIFID_DELETE_CHEM ON APP_FI_TRIFID_DELETE_CHEM.TRI_REPORT_ID = r.PK_GUID
WHERE APP_FI_TRIFID_DELETE_CHEM.TRIFID_DELETE_CHEM_ID IS NULL
AND S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM TRI_REPORT R2
		JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE
			F2.FAC_ID = F.FAC_ID
		AND
			R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
			C2.CHEM_TXT = C.CHEM_TXT
	)
 AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL
 AND C.CAS_CLBER = 'N150'
;

GO


PRINT 'V_EXT_DIOXIN_SECTION_8 was altered!'

/****** Object:  View [dbo].[V_EXT_EPA_MISSING_REPORTS]    Script Date: 6/30/2015 7:51:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:	Windsor Solutions, Inc.
-- Create date: 2012-11-13
-- Description:	[V_EXT_EPA_MISSING_REPORTS]
-- =============================================
ALTER  VIEW [dbo].[V_EXT_EPA_MISSING_REPORTS] AS 
SELECT DISTINCT r.sub_rep_year AS [Year]
     , f.fac_id AS [TRI Facility Id]
     , f.fac_site AS [Facility Name]
     , f.loc_add_txt AS [Street Address]
     , f.LOCALITY AS [City]
     , f.STATE AS [State]
     , f.COUNTY AS [County]
     , f.ADD_POSTAL_CODE AS [Zip Code]
     , r.pub_cont AS [Public Contact]
     , r.pub_cont_phone_txt AS [Phone Contact Phone]
     , r.tech_cont AS [Technical Contact]
     , r.tech_cont_phone_txt AS [Technical Contact Phone]
     , r.tech_cont_email_addres AS [Technical Contact Email]
     , c.CAS_CLBER AS [Chemical Num or Category Code]
     , c.CHEM_TXT AS [Chemical Name]
     , r.report_type_code AS [Reporting Form Type]
--     , r.report_post_date AS [Postmark Date]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , C.CHEM_TXT AS [CHEMICAL_NAME_TEXT]
     , CASE C.CAS_CLBER 
         WHEN 'N150' THEN 1
         ELSE 0
       END AS [DIOXIN_IND]
     , f.fac_id AS [TRIFID]
	 , T.EPAID AS [EPA_ID]
	 , f.FAC_SITE AS [FAC_NAME]
FROM TRI_SUB S
  JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
  JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
  LEFT JOIN App_Lookup_Cty_Reg LCR ON LCR.County = F.COUNTY
  JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
  JOIN TRI_CHEM C ON c.FK_GUID = r.pk_guid
  LEFT OUTER JOIN EPARecon EPA ON
		(Replace(EPA.[Chemical Number or Cat. Code],'-','')  = Replace(CAS_CLBER,'-','') 
				OR EPA.[Chemical Name] = CHEM_TXT
				OR (EPA.[Chemical Name] IN ('NA','MIXTURE') AND CHEM_TXT IN ('NA','MIXTURE'))) 
		  AND EPA.[TRI Facility ID] = TRIFID 
          AND EPA.Year = SUB_REP_YEAR
          AND EPA.[Reporting Form Type] = UPPER(COALESCE (RIGHT(R.REPORT_TYPE_CODE, 1), ''))
  LEFT JOIN dbo.APP_FI_TRIFID_DELETE_CHEM D ON D.TRI_REPORT_ID = R.PK_GUID   
  LEFT JOIN dbo.App_FI_TRIFID FT ON F.FAC_ID = T.TRIFID       
WHERE	EPA.[TRI Facility ID] IS NULL AND CHEM_RPT_REV_CD_1 IS NULL 
		AND EXISTS (SELECT 1 FROM EPARecon WHERE EPARecon.Year = R.SUB_REP_YEAR)
		AND D.TRIFID_DELETE_CHEM_ID IS NULL
		AND FT.Inactive_DT IS NULL;		

GO


PRINT 'V_EXT_EPA_MISSING_REPORTS was altered!'

/****** Object:  View [dbo].[V_EXT_EPA_REPORTS_WITHDRAWN]    Script Date: 6/30/2015 7:54:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:	Windsor Solutions, Inc.
-- Create date: 2012-11-13
-- Description:	[V_EXT_EPA_REPORTS_WITHDRAWN]
-- =============================================
ALTER   VIEW [dbo].[V_EXT_EPA_REPORTS_WITHDRAWN] AS 
SELECT DISTINCT r.sub_rep_year AS [Year]
     , f.fac_id AS [TRI Facility Id]
     , f.fac_site AS [Facility Name]
     , f.loc_add_txt AS [Street Address]
     , f.LOCALITY AS [City]
     , f.STATE AS [State]
     , f.COUNTY AS [County]
     , f.ADD_POSTAL_CODE AS [Zip Code]
     , r.pub_cont AS [Public Contact]
     , r.pub_cont_phone_txt AS [Phone Contact Phone]
     , r.tech_cont AS [Technical Contact]
     , r.tech_cont_phone_txt AS [Technical Contact Phone]
     , r.tech_cont_email_addres AS [Technical Contact Email]
     , c.CAS_CLBER AS [Chemical Num or Category Code]
     , c.CHEM_TXT AS [Chemical Name]
     , r.report_type_code AS [Reporting Form Type]
--     , r.report_post_date AS [Postmark Date]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , C.CHEM_TXT AS [CHEMICAL_NAME_TEXT]
	 , T.EPAID AS [EPA_ID]
	 , F.FAC_SITE AS [FAC_NAME]
     , CASE C.CAS_CLBER 
         WHEN 'N150' THEN 1
         ELSE 0
       END AS [DIOXIN_IND]
     , f.fac_id AS [TRIFID]
FROM TRI_SUB S
  JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
  JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
  LEFT JOIN App_Lookup_Cty_Reg LCR ON LCR.County = F.COUNTY
  JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
  JOIN TRI_CHEM C ON c.FK_GUID = r.pk_guid
  JOIN EPARecon EPA ON
		(Replace(EPA.[Chemical Number or Cat. Code],'-','')  = Replace(CAS_CLBER,'-','') 
				OR EPA.[Chemical Name] = CHEM_TXT
				OR (EPA.[Chemical Name] IN ('NA','MIXTURE') AND CHEM_TXT IN ('NA','MIXTURE'))) 
		  AND EPA.[TRI Facility ID] = TRIFID 
          AND EPA.Year = SUB_REP_YEAR
          AND EPA.[Reporting Form Type] = UPPER(COALESCE (RIGHT(R.REPORT_TYPE_CODE, 1), ''))
  LEFT JOIN dbo.APP_FI_TRIFID_DELETE_CHEM D ON D.TRI_REPORT_ID = R.PK_GUID   
  LEFT JOIN dbo.App_FI_TRIFID FT ON F.FAC_ID = T.TRIFID       
WHERE	EPA.[TRI Facility ID] IS NULL AND LEN(CHEM_RPT_REV_CD_1) > 1 
		AND EXISTS (SELECT 1 FROM EPARecon WHERE EPARecon.Year = R.SUB_REP_YEAR)
		AND D.TRIFID_DELETE_CHEM_ID IS NULL
		AND FT.Inactive_DT IS NULL;

GO


PRINT 'V_EXT_EPA_REPORTS_WITHDRAWN was altered!'

/****** Object:  View [dbo].[V_EXT_EPA_RESPONSE]    Script Date: 6/30/2015 7:55:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_EXT_EPA_RESPONSE] 
AS 
SELECT r.sub_rep_year AS [Year]
     , f.fac_id AS [TRI Facility Id]
     , f.fac_site AS [Facility Name]
     , f.loc_add_txt AS [Street Address]
     , f.LOCALITY AS [City]
     , f.STATE AS [State]
     , f.COUNTY AS [County]
     , f.ADD_POSTAL_CODE AS [Zip Code]
     , r.pub_cont AS [Public Contact]
     , r.pub_cont_phone_txt AS [Phone Contact Phone]
     , r.tech_cont AS [Technical Contact]
     , r.tech_cont_phone_txt AS [Technical Contact Phone]
     , r.tech_cont_email_addres AS [Technical Contact Email]
     , c.CAS_CLBER AS [Chemical Num or Category Code]
     , c.CHEM_TXT AS [Chemical Name]
     , r.report_type_code AS [Reporting Form Type]
--     , r.report_post_date AS [Postmark Date]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , C.CHEM_TXT AS [CHEMICAL_NAME_TEXT]
     , CASE C.CAS_CLBER 
         WHEN 'N150' THEN 1
         ELSE 0
       END AS [DIOXIN_IND]
     , f.fac_id AS [TRIFID]
	 , T.EPAID AS [EPA_ID]
	 , f.FAC_SITE AS [FAC_NAME]
  FROM TRI_SUB S
  JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
  JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
  LEFT JOIN App_Lookup_Cty_Reg LCR ON LCR.County = F.COUNTY
  JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
  JOIN TRI_CHEM C ON c.FK_GUID = r.pk_guid
WHERE S.INSERTED_DATE = (SELECT MAX(S2.INSERTED_DATE)
	                          FROM TRI_REPORT R2
		                         JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		                         JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		                         JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		                        WHERE F2.FAC_ID = F.FAC_ID
		                          AND R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		                          AND C2.CHEM_TXT = C.CHEM_TXT)
  AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL;

GO


PRINT 'V_EXT_EPA_RESPONSE was altered!'

/****** Object:  View [dbo].[V_EXT_OFF_WT]    Script Date: 6/30/2015 4:20:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* =============================================
 Full Name:		V_EXTRACT_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the Waste Transfers extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> 'A'*/
ALTER VIEW [dbo].[V_EXT_OFF_WT]
AS
SELECT TL.PK_GUID
     , TL.FK_GUID
     , TD.FS_ID AS FSID
     , TD.EPA_ID AS [EPA ID]
     , TD.TRIFID AS [TRI Facility Id]
     , TD.SUBMISSION_REPORTING_YEAR AS Year
     ,  TD.FAC_NAME AS [Facility Name]
--     , TD.AgencyName AS AKA
     , TD.LOC_ADD_LINE_1_DS AS [Address 1]
     , TD.LOC_ADD_LINE_2_DS AS [Address 2]
     , TD.CITY_NM AS City
     , TD.COUNTY_NM AS County
     , TD.ZIP_CD AS Zip
     , TD.CHEMICAL_NAME_TEXT AS Chemical
     , TL.RCRA_ID_CLBER AS [Trans RCRA ID]
     , TL.FAC_SITE AS [Trans Facility Name]
     , TL.LOC_ADD_TXT AS [Trans Address]
     , TL.LOCALITY AS [Trans City]
     , TL.STATE AS [Trans State]
     , CASE WHEN TLQ.WASTE_Q_NA_IND = 'Y' 
         THEN NULL 
         ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, TLQ.WASTE_Q_RANGE_CODE) 
       END AS [Trans Waste Total]
     , TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code]
     , TD.ECOLOGY_REGION AS [ECY Region]
     , TD.SUBMISSION_REPORTING_YEAR
     , TD.ECOLOGY_REGION
     , TD.FS_ID
     , TD.EPA_ID
     , TD.COUNTY_NM
     , TD.FAC_NAME
     , TD.AgencyName
     , TD.CHEMICAL_NAME_TEXT                      
     , POTW.POTW_SEQ_NO
     , POTW.WASTE_Q_ME
     , POTW.WASTE_Q_CATASTROPHIC_MEASURE
     , POTW.WASTE_Q_RANGE_CODE
     , POTW.WASTE_Q_RANGE_NUM_BASIS_VALUE
     , POTW.WASTE_Q_ME_NA_IND
     , POTW.Q_BASIS_EST_CODE
     , POTW.Q_BASIS_EST_NA_IND
     , POTW.TOX_EQ_VAL1
     , POTW.TOX_EQ_VAL2
     , POTW.TOX_EQ_VAL3
     , POTW.TOX_EQ_VAL4
     , POTW.TOX_EQ_VAL5
     , POTW.TOX_EQ_VAL6
     , POTW.TOX_EQ_VAL7
     , POTW.TOX_EQ_VAL8
     , POTW.TOX_EQ_VAL9
     , POTW.TOX_EQ_VAL10
     , POTW.TOX_EQ_VAL11
     , POTW.TOX_EQ_VAL12
     , POTW.TOX_EQ_VAL13
     , POTW.TOX_EQ_VAL14
     , POTW.TOX_EQ_VAL15
     , POTW.TOX_EQ_VAL16
     , POTW.TOX_EQ_VAL17
     , POTW.TOX_EQ_NA_IND
     , POTW.Q_DISP_LANDFILL_PERCENT_VALUE
     , POTW.Q_DISP_OTHER_PERCENT_VALUE
     , POTW.Q_TREATED_PERCENT_VALUE 
     , TD.TRIFID
     , TD.DIOXIN_IND                
  FROM dbo.TRI_TRANSFER_LOC AS TL 
  JOIN dbo.V_EXT_MASTER AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT 
  JOIN dbo.TRI_POTW_WASTE_QUANTITY POTW ON POTW.FK_GUID = TD.PK_GUID_REPORT
  JOIN dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
 WHERE (TD.REPORT_TYPE = 'TRI_FORM_R')

GO


PRINT 'V_EXT_OFF_WT was altered!'

/****** Object:  View [dbo].[V_EXT_OPT_MISC_INF_TXT]    Script Date: 6/15/2015 2:13:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
ALTER VIEW [dbo].[V_EXT_OPT_MISC_INF_TXT] 
AS 

WITH Facility_CTE
AS
(
SELECT R.PK_GUID
     , T.TRIFID
	 , ISNULL(CASE WHEN ISNULL(T.AgencyName,'') = '' THEN NULL ELSE T.AgencyName END, F.FAC_SITE)	[Facility Name]
     , R.SUB_REP_YEAR		[Report Submission Year]
     , C.CHEM_TXT			[Chemical Name]
     , C.CAS_CLBER			[CAS No]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , C.CHEM_TXT AS [CHEMICAL_NAME_TEXT]
     , CASE C.CAS_CLBER 
         WHEN 'N150' THEN 1
         ELSE 0
       END AS [DIOXIN_IND]
	 , R.OPT_INF_CATG
	 , REPLACE([dbo].[CleanAndTrim](R.OPT_INF_TXT),CHAR(34),'') OPT_INF_TXT
	 , R.MISC_INF_CATG
	 , REPLACE([dbo].[CleanAndTrim](R.MISC_INF_TXT),CHAR(34),'') MISC_INF_TXT
	 , T.EPAID AS [EPA_ID]
	 , F.FAC_SITE AS [FAC_NAME]
FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
LEFT JOIN App_Lookup_Cty_Reg LCR ON LCR.County = F.COUNTY
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM c on c.FK_GUID = r.PK_GUID
LEFT JOIN APP_FI_TRIFID_DELETE_CHEM
  ON APP_FI_TRIFID_DELETE_CHEM.TRI_REPORT_ID = r.PK_GUID
WHERE APP_FI_TRIFID_DELETE_CHEM.TRIFID_DELETE_CHEM_ID IS NULL
  AND S.INSERTED_DATE = (SELECT MAX(S2.INSERTED_DATE)
	                          FROM TRI_REPORT R2
		                         JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		                         JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		                         JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		                        WHERE F2.FAC_ID = F.FAC_ID
		                          AND R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		                          AND C2.CHEM_TXT = C.CHEM_TXT)
  AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL
)

SELECT [PK_GUID]
      ,[FS_ID] AS [FSID]
	  ,EPA_ID AS [EPA ID]
      ,TRIFID AS [TRI Facility Id]
      ,[Facility Name]
      ,[Report Submission Year]
      ,[Chemical Name]
      ,[CAS No]
	  ,CAST(NULL AS INT) [Comment Seq No]
	  ,CAST('Optional Info (8.11)' AS varchar(255)) [Comment Section]
	  ,COALESCE([OPT_INF_CATG], 'N/A') [Comment Type]
	  ,[OPT_INF_TXT] [Comment Text]
	  ,CAST(NULL AS varchar(100)) [Comment P2 Classification]
      ,[SUBMISSION_REPORTING_YEAR]
      ,[ECOLOGY_REGION] AS [ECY Region]
      ,[ECOLOGY_REGION]
      ,[FS_ID]
      ,[COUNTY_NM] AS [County]
      ,[COUNTY_NM]
      ,[AgencyName]
      ,[CHEMICAL_NAME_TEXT]
      ,[DIOXIN_IND]
	  ,TRIFID
	  ,EPA_ID
	  ,FAC_NAME
FROM Facility_CTE
WHERE [OPT_INF_TXT] IS NOT NULL

UNION ALL

SELECT [PK_GUID]
      ,[FS_ID] AS [FSID]
	  ,EPA_ID AS [EPA ID]
      ,TRIFID AS [TRI Facility Id]
      ,[Facility Name]
      ,[Report Submission Year]
      ,[Chemical Name]
      ,[CAS No]
	  ,CAST(NULL AS INT) [Comment Seq No]
	  ,CAST('Misc. Info (9.1)' AS varchar(255)) [Comment Section]
	  ,COALESCE([MISC_INF_CATG], 'N/A') [Comment Type]
	  ,[MISC_INF_TXT] [Comment Text]
	  ,CAST(NULL AS varchar(100)) [Comment P2 Classification]
      ,[SUBMISSION_REPORTING_YEAR]
      ,[ECOLOGY_REGION] AS [ECY Region]
      ,[ECOLOGY_REGION]
      ,[FS_ID]
      ,[COUNTY_NM] AS [County]
      ,[COUNTY_NM]
      ,[AgencyName]
      ,[CHEMICAL_NAME_TEXT]
      ,[DIOXIN_IND]
	  ,TRIFID
	  ,EPA_ID
	  ,FAC_NAME
FROM Facility_CTE
WHERE [MISC_INF_TXT] IS NOT NULL

UNION ALL

SELECT f.[PK_GUID]
      ,[FS_ID] AS [FSID]
	  ,EPA_ID AS [EPA ID]
      ,TRIFID AS [TRI Facility Id]
      ,[Facility Name]
      ,[Report Submission Year]
      ,[Chemical Name]
      ,[CAS No]
	  ,C.COMMENT_SEQ [Comment Seq No]
	  ,CASE C.COMMENT_SECTION
		WHEN '8.11' THEN 'Optional Info (8.11)'
		WHEN '9.1' THEN 'Misc. Info (9.1)'
		ELSE 'N/A'
		END [Comment Section]
	  ,C.COMMENT_TYPE_DESC [Comment Type]
	  ,REPLACE([dbo].[CleanAndTrim](C.COMMENT_TEXT),CHAR(34),'') [Comment Text]
	  ,C.COMMENT_P2_CLASS [Comment P2 Classification]
      ,[SUBMISSION_REPORTING_YEAR]
      ,[ECOLOGY_REGION] AS [ECY Region]
      ,[ECOLOGY_REGION]
      ,[FS_ID]
      ,[COUNTY_NM] AS [County]
      ,[COUNTY_NM]
      ,[AgencyName]
      ,[CHEMICAL_NAME_TEXT]
      ,[DIOXIN_IND]
	  ,TRIFID
	  ,EPA_ID
	  ,FAC_NAME
FROM Facility_CTE f
JOIN TRI_COMMENT c
  ON c.FK_GUID = f.PK_GUID

GO


/****** Object:  View [dbo].[V_EXT_P2_FEE]    Script Date: 6/30/2015 8:22:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* =============================================
 Full Name:		V_EXTRACT_P2_FEES
 Condensed Name:	V_EXT_P2_FEE
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Pollution Prevention extract in the TRI Application. Includes dioxins, results in pounds.
 =============================================*/
ALTER VIEW [dbo].[V_EXT_P2_FEE]
AS
SELECT fs_id                                       AS FSID, 
       epa_id                                      AS [EPA ID], 
       trifid                                      AS [TRI Facility Id], 
       fac_name                                    AS [Facility Name], 
--       agencyname                                  AS AKA, 
       loc_add_line_1_ds                           AS [Address 1], 
       loc_add_line_2_ds                           AS [Address 2], 
       city_nm                                     AS City, 
       zip_cd                                      AS Zip, 
       county_nm                                   AS County, 
       mail_add_line_1_ds                          AS [Mail Address 1], 
       mail_add_line_2_ds                          AS [Mail Address 2], 
       mail_city_nm                                AS [Mail City], 
       mail_state_cd                               AS [Mail State], 
       mail_province_nm                            AS [Mail Province], 
       mail_zip_cd                                 AS [Mail Zip], 
       mail_country_cd                             AS [Mail Country], 
       fac_naics_primary                           AS [NAICS], 
       tech_contact_nm                             AS [Tech Contact], 
       tech_phone_nr                               AS [Tech Phone], 
       submission_reporting_year                   AS Year, 
       Sum(total)                                  AS [Sum of TRI], 
       ecology_region                              AS [ECY Region], 
       submission_reporting_year, 
       ecology_region, 
       fs_id, 
       epa_id, 
       county_nm, 
       fac_name, 
       agencyname, 
       trifid, 
       (SELECT Count(*) 
        FROM   dbo.v_ext_master AS TD2 
        WHERE  TD2.trifid = TD.trifid 
               AND TD2.submission_reporting_year = TD.submission_reporting_year 
               AND TD2.report_type = 'TRI_FORM_R') AS CountFormR, 
       (SELECT Count(*) 
        FROM   dbo.v_ext_master AS TD2 
        WHERE  TD2.trifid = TD.trifid 
               AND TD2.submission_reporting_year = TD.submission_reporting_year 
               AND TD2.report_type = 'TRI_FORM_A') AS CountFormA, 
       TD.dioxin_ind, 
       NULL                                        AS CHEMICAL_NAME_TEXT 
FROM   dbo.v_ext_master AS TD 
GROUP  BY fs_id, 
          epa_id, 
          agencyname, 
          fac_name, 
          loc_add_line_1_ds, 
          loc_add_line_2_ds, 
          city_nm, 
          county_nm, 
          zip_cd, 
          mail_province_nm, 
          mail_country_cd, 
          mail_add_line_1_ds, 
          mail_add_line_2_ds, 
          mail_city_nm, 
          mail_zip_cd, 
          mail_state_cd, 
          tech_contact_nm, 
          tech_phone_nr, 
          trifid, 
          submission_reporting_year, 
          ecology_region, 
          fac_naics_primary, 
          TD.dioxin_ind 

GO


PRINT 'V_EXT_P2_FEE was altered!'

/****** Object:  View [dbo].[V_EXT_SRC_RED_ACT]    Script Date: 6/15/2015 12:37:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_EXT_SRC_RED_ACT]
AS
SELECT  s.PK_GUID PK_GUID_SUB
     ,	r.PK_GUID PK_GUID_REP
     , T.AgencyID AS [FSID]
	 ,  t.EPAID AS [EPA ID]
     ,	f.FAC_ID	[TRI Facility Id]
     ,	f.FAC_SITE [Facility Name]
     ,	c.CAS_CLBER [CAS #]
     ,	c.CHEM_TXT [Chemical]
     , sra.SRC_RED_SEQ_CL
     , sra.SRC_RED_ACT_CODE
     , ISNULL(sra.SRC_RED_NA_IND,0) SRC_RED_ACT_NA_IND
     , sramc.SRC_RED_METH_CODE
     , ISNULL(sramc.SRC_RED_NA_IND,0) SRC_RED_MTHD_NA_IND
	 , sra.SRC_RED_EFF_CODE
     , R.SUB_REP_YEAR AS [Submission Year]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECY Region]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [County]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , C.CHEM_TXT AS [CHEMICAL_NAME_TEXT]
     , CASE C.CAS_CLBER 
         WHEN 'N150' THEN 1
         ELSE 0
       END AS [DIOXIN_IND]
     ,	f.FAC_ID	TRIFID
--     ,	f.FAC_SITE
     ,	c.CAS_CLBER
     ,	c.CHEM_TXT
	 ,  t.EPAID AS EPA_ID
	 ,  f.FAC_SITE AS FAC_NAME

FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
LEFT JOIN App_Lookup_Cty_Reg LCR ON LCR.County = F.COUNTY
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM c on c.FK_GUID = r.PK_GUID
JOIN TRI_SRC_RED_ACT SRA ON SRA.FK_GUID = R.PK_GUID
LEFT JOIN TRI_SRC_RED_METH_CD SRAMC ON SRAMC.FK_GUID = SRA.PK_GUID
LEFT JOIN APP_FI_TRIFID_DELETE_CHEM ON APP_FI_TRIFID_DELETE_CHEM.TRI_REPORT_ID = r.PK_GUID
WHERE sra.SRC_RED_ACT_CODE != 'NA'
  AND APP_FI_TRIFID_DELETE_CHEM.TRIFID_DELETE_CHEM_ID IS NULL
  AND S.INSERTED_DATE = (SELECT MAX(S2.INSERTED_DATE)
	                          FROM TRI_REPORT R2
		                         JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		                         JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		                         JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		                        WHERE F2.FAC_ID = F.FAC_ID
		                          AND R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		                          AND C2.CHEM_TXT = C.CHEM_TXT)
  AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL;

GO


PRINT 'V_EXT_SRC_RED_ACT was altered!'

/****** Object:  View [dbo].[V_EXT_STR]    Script Date: 6/15/2015 2:09:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* =============================================
 Full Name:		V_EXTRACT_STREAMS
 Condensed Name:	V_EXT_STR
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Streams extract in the TRI Application. Excludes dioxins, results in pounds.
 RIGHT(TD.REPORT_TYPE, 1) <> 'A'*/
ALTER VIEW [dbo].[V_EXT_STR]
AS
SELECT 
       TD.fs_id                     AS FSID, 
       TD.epa_id                    AS [EPA ID], 
       TD.trifid [TRI Facility Id],
       TD.submission_reporting_year AS Year, 
       TD.fac_name                  AS [Facility Name], 
--       TD.agencyname                AS AKA, 
       TD.loc_add_line_1_ds         AS [Address 1], 
       TD.loc_add_line_2_ds         AS [Address 2], 
       TD.city_nm                   AS City, 
       TD.county_nm                 AS County, 
       TD.zip_cd                    AS Zip, 
       TD.chemical_name_text        AS Chemical, 
       TD.cas_number                AS [CAS #], 
       ONSR.pk_guid, 
       ONSR.fk_guid, 
       CASE 
         WHEN ONSR.waste_q_na_ind = 'Y' THEN '0' 
         ELSE dbo.Tri_rangecodeconversion(ONSR.waste_q_me, 
              ONSR.waste_q_range_code) 
       END                          AS [Release Total], 
       ONSR.waste_q_range_code      AS [Release Range Code], 
       ONSR.q_basis_est_cd          AS [Basis of Estimate Code], 
       ONSR.water_seq_clber         AS [Water Body Sequence #], 
       ONSR.stream                  AS [Water Body Name], 
	   ONSR.stream_reach_code       AS [Stream Reach Code],
       ONSR.release_storm_water     AS [Release % from Stormwater], 
       TD.ecology_region            AS [ECY Region], 
       TD.submission_reporting_year, 
       TD.ecology_region, 
       TD.fs_id, 
       TD.epa_id, 
       TD.county_nm, 
       TD.fac_name, 
--       TD.agencyname, 
       TD.chemical_name_text, 
       TD.trifid,
       TD.dioxin_ind 
FROM   dbo.v_ext_master AS TD 
       INNER JOIN dbo.tri_onsite_release_q AS ONSR 
               ON TD.pk_guid_report = ONSR.fk_guid 
WHERE  ( CASE 
           WHEN ONSR.waste_q_na_ind = 'Y' THEN '0' 
           ELSE dbo.Tri_rangecodeconversion(ONSR.waste_q_me, 
                ONSR.waste_q_range_code) 
         END <> '0' ) 
       AND ( Isnull(ONSR.stream, 'NA') <> 'NA' ) 
       AND ( TD.report_type = 'TRI_FORM_R' ) 

GO


PRINT 'V_EXT_STR was altered!'

/****** Object:  View [dbo].[V_EXT_TRI_SUMMARY]    Script Date: 6/30/2015 7:58:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


 
ALTER VIEW [dbo].[V_EXT_TRI_SUMMARY] 
AS
SELECT DISTINCT tri_report.report_id                                 AS report_no 
                , app_link_tri_sub_filename.filenametxt              AS xml_file 
                , tri_sub.tri_sub_id                                 AS hard_copy 
                , tri_sub.tri_sub_id                                 AS trime_web 
                , tri_fac.fac_id                                     AS tri_id 
                , tri_fac.fac_site                                   AS facility 
                , tri_fac.loc_add_txt                                AS address 
                , tri_fac.county                                     AS county 
                , tri_fac.locality                                   AS city 
                , tri_fac.add_postal_code                            AS zip_code 
                , tri_fac.state_code                                 AS state 
                , tri_fac.mail_add_txt                               AS mailing_ad 
                , tri_fac.mail_add_city                              AS mailcity 
                , tri_fac.mail_add_state_code                        AS mailstate 
                , tri_fac.mail_add_postal_code                       AS mailzip 
                , tri_report.cert_signed_date                        AS formdate 
                , tri_fac_naics.fac_naics                            AS naics 
                , tri_report.sub_partial_fac_id                      AS part_fac 
                , tri_report.sub_federal_fac_id                      AS fed_flag 
                , tri_report.tech_cont                               AS tech_cont 
                , tri_report.tech_cont_phone_txt                     AS telephone 
                , tri_report.tech_cont_email_addres                  AS email 
                , tri_fac.parent_company_txt                         AS parent 
                , tri_chem.cas_clber                                 AS tri_chm_id 
                , tri_chem.chem_txt                                  AS chem_name 
                , CASE 
                    WHEN tri_chem.cas_clber = 'N150' THEN 'Y' 
                    ELSE 'N' 
                  END                                                AS dioxin 
                , tri_report.sub_rep_year                            AS rep_year 
                , CASE 
                    WHEN Substring(tri_report.report_type_code, Len(tri_report.report_type_code), 1) = 'R' THEN 'Y'
                    ELSE 'N' 
                  END                                                AS form_r10 
                , CASE 
                    WHEN Substring(tri_report.report_type_code, Len(tri_report.report_type_code), 1) = 'A' THEN 'Y'
                    ELSE 'N' 
                  END                                                AS form_a10 
                , v_tri_onsite_release_q.air_fug_51                  AS fug_air10 
                , v_tri_onsite_release_q.air_stack_52                AS stack_10 
                , v_tri_onsite_release_q.tot_air10                   AS tot_air10 
                , v_tri_onsite_release_q.water_10a                   AS water_10a 
                , v_tri_onsite_release_q.stream_a                    AS stream_a 
                , v_tri_onsite_release_q.water_10b                   AS water_10b 
                , v_tri_onsite_release_q.stream_b                    AS stream_b 
                , v_tri_onsite_release_q.water_10                    AS water_10 
                , v_tri_onsite_release_q.uninj_i_541                 AS inject10c1 
                , v_tri_onsite_release_q.uninj_iiv_542               AS inject10c2 
                , v_tri_onsite_release_q.inject_10                   AS inject_10 
                , v_tri_onsite_release_q.rcra_c_551a                 AS rcrasubc10 
                , v_tri_onsite_release_q.oth_landf_551b              AS otherlnd10 
                , v_tri_onsite_release_q.land_trea_552               AS landtrt_10 
                , v_tri_onsite_release_q.si_5_5_3_a                  AS surface_10 
                , v_tri_onsite_release_q.si_5_5_3_b                  AS s5_5_3b_10 
                , v_tri_onsite_release_q.oth_disp                    AS otherdis10 
                , v_tri_onsite_release_q.landtot_10                  AS landtot_10 
                , (SELECT Max(tri_transfer_loc.fac_site) 
                   FROM   tri_transfer_loc 
                   WHERE  tri_transfer_loc.fk_guid = tri_report.pk_guid 
                          AND tri_transfer_loc.fac_site IS NOT NULL 
                          AND tri_transfer_loc.potw_ind = 'Y')       AS potw_name 
                , CASE 
                    WHEN v_tri_potw_waste_quantity.waste_q_me IS NOT NULL THEN v_tri_potw_waste_quantity.waste_q_me
                    ELSE 
                      CASE v_tri_potw_waste_quantity.waste_q_range_code 
                        WHEN 'A' THEN '5' 
                        WHEN 'B' THEN '250' 
                        WHEN 'C' THEN '750' 
                        ELSE 0 
                      END 
                  END                                                AS potw_10 
                , tri_form_r_short_xfr.amt_lbs_1                     AS offsitea10 
                , tri_form_r_short_xfr.q_basis_est_code_1            AS code_a_10 
                , tri_form_r_short_xfr.amt_lbs_2                     AS offsiteb10 
                , tri_form_r_short_xfr.q_basis_est_code_2            AS code_b_10 
                , tri_form_r_short_xfr.amt_lbs_3                     AS offsitec10 
                , tri_form_r_short_xfr.q_basis_est_code_3            AS code_c_10 
                , tri_form_r_short_xfr.amt_lbs_4                     AS offsited10 
                , tri_form_r_short_xfr.q_basis_est_code_4            AS code_d_10 
                , tri_form_r_short_xfr.amt_lbs_5                     AS offsitee10 
                , tri_form_r_short_xfr.q_basis_est_code_5            AS code_e_10 
                , tri_form_r_short_xfr.amt_lbs_6                     AS offsitef10 
                , tri_form_r_short_xfr.q_basis_est_code_6            AS code_f_10 
                , tri_form_r_short_xfr.amt_lbs_7                     AS offsiteg10 
                , tri_form_r_short_xfr.q_basis_est_code_7            AS code_g_10 
                , tri_form_r_short_xfr.amt_lbs_8                     AS offsiteh10 
                , tri_form_r_short_xfr.q_basis_est_code_8            AS code_h_10 
                , tri_form_r_short_xfr.amt_lbs_9                     AS offsitei10 
                , tri_form_r_short_xfr.q_basis_est_code_9            AS code_i_10 
                , tri_form_r_short_xfr.amt_lbs_10                    AS offsitej10 
                , tri_form_r_short_xfr.q_basis_est_code_10           AS code_j_10 
                , tri_form_r_short_xfr.amt_lbs_11                    AS offsitek10 
                , tri_form_r_short_xfr.q_basis_est_code_11           AS code_k_10 
                , tri_form_r_short_xfr.amt_lbs_12                    AS offsitel10 
                , tri_form_r_short_xfr.q_basis_est_code_12           AS code_l_10 
                , tri_form_r_short_xfr.amt_lbs_13                    AS offsitem10 
                , tri_form_r_short_xfr.q_basis_est_code_13           AS code_m_10 
                , tri_form_r_short_xfr.amt_lbs_14                    AS offsiten10 
                , tri_form_r_short_xfr.q_basis_est_code_14           AS code_n_10 
                , tri_form_r_short_xfr.amt_lbs_15                    AS offsiteo10 
                , tri_form_r_short_xfr.q_basis_est_code_15           AS code_o_10 
                , tri_form_r_short_xfr.amt_lbs_16                    AS offsitep10 
                , tri_form_r_short_xfr.q_basis_est_code_16           AS code_p_10 
                , v_tri_onsite_rcv_proc.energy_rcv_meth_code_1       AS on_ene1_10 
                , v_tri_onsite_rcv_proc.energy_rcv_meth_code_2       AS on_ene2_10 
                , v_tri_onsite_rcv_proc.energy_rcv_meth_code_3       AS on_ene3_10 
                , v_tri_onsite_recycg_proc.onsite_recycg_meth_code_1 AS on_rec1_10 
                , v_tri_onsite_recycg_proc.onsite_recycg_meth_code_2 AS on_rec2_10 
                , v_tri_onsite_recycg_proc.onsite_recycg_meth_code_3 AS on_rec3_10 
                , v_tri_onsite_uic_disp_qty.sr_81a1                  AS s8_1aa_10 
                , v_tri_onsite_uic_disp_qty.sr_81a2                  AS s8_1ab_10 
                , v_tri_onsite_uic_disp_qty.sr_81a3                  AS s8_1ac_10 
                , v_tri_onsite_uic_disp_qty.sr_81a4                  AS s8_1ad_10 
                , v_tri_onsite_disp_qty.sr_81b1                      AS s8_1ba_10 
                , v_tri_onsite_disp_qty.sr_81b2                      AS s8_1bb_10 
                , v_tri_onsite_disp_qty.sr_81b3                      AS s8_1bc_10 
                , v_tri_onsite_disp_qty.sr_81b4                      AS s8_1bd_10 
                , v_tri_offsite_uic_disp_qty.sr_81c1                 AS s8_1ca_10 
                , v_tri_offsite_uic_disp_qty.sr_81c2                 AS s8_1cb_10 
                , v_tri_offsite_uic_disp_qty.sr_81c3                 AS s8_1cc_10 
                , v_tri_offsite_uic_disp_qty.sr_81c4                 AS s8_1cd_10 
                , v_tri_offsite_disp_qty.sr_81d1                     AS s8_1da_10 
                , v_tri_offsite_disp_qty.sr_81d2                     AS s8_1db_10 
                , v_tri_offsite_disp_qty.sr_81d3                     AS s8_1dc_10 
                , v_tri_offsite_disp_qty.sr_81d4                     AS s8_1dd_10 
                , v_tri_onsite_energy_rcv_qty.sr_821                 AS onene09_10 
                , v_tri_onsite_energy_rcv_qty.sr_822                 AS onene10_10 
                , v_tri_onsite_energy_rcv_qty.sr_823                 AS onene11_10 
                , v_tri_onsite_energy_rcv_qty.sr_824                 AS onene12_10 
                , v_tri_offsite_energy_rec_qty.sr_831                AS offne09_10 
                , v_tri_offsite_energy_rec_qty.sr_832                AS offne10_10 
                , v_tri_offsite_energy_rec_qty.sr_833                AS offne11_10 
                , v_tri_offsite_energy_rec_qty.sr_834                AS offne12_10 
                , v_tri_onsite_recycled_q.sr_841                     AS onrec09_10 
                , v_tri_onsite_recycled_q.sr_842                     AS onrec10_10 
                , v_tri_onsite_recycled_q.sr_843                     AS onrec11_10 
                , v_tri_onsite_recycled_q.sr_844                     AS onrec12_10 
                , v_tri_offsite_recycled_q.sr_851                    AS ofrec09_10 
                , v_tri_offsite_recycled_q.sr_852                    AS ofrec10_10 
                , v_tri_offsite_recycled_q.sr_853                    AS ofrec11_10 
                , v_tri_offsite_recycled_q.sr_854                    AS ofrec12_10 
                , v_tri_onsite_treated_q.sr_861                      AS ontrt09_10 
                , v_tri_onsite_treated_q.sr_862                      AS ontrt10_10 
                , v_tri_onsite_treated_q.sr_863                      AS ontrt11_10 
                , v_tri_onsite_treated_q.sr_864                      AS ontrt12_10 
                , v_tri_offsite_treated_q.sr_871                     AS oftrt09_10 
                , v_tri_offsite_treated_q.sr_872                     AS oftrt10_10 
                , v_tri_offsite_treated_q.sr_873                     AS oftrt11_10 
                , v_tri_offsite_treated_q.sr_874                     AS oftrt12_10 
                , tri_report.one_time_release_q                      AS onetime_10 
                , tri_report.production_ratio_me                     AS ratio_10 
                , v_tri_src_red_act.source1_10                       AS source1_10 
                , v_tri_src_red_act.method1a10                       AS method1a10 
                , v_tri_src_red_act.method1b10                       AS method1b10 
                , v_tri_src_red_act.method1c10                       AS method1c10 
                , v_tri_src_red_act.source2_10                       AS source2_10 
                , v_tri_src_red_act.method2a10                       AS method2a10 
                , v_tri_src_red_act.method2b10                       AS method2b10 
                , v_tri_src_red_act.method2c10                       AS method2c10 
                , v_tri_src_red_act.source3_10                       AS source3_10 
                , v_tri_src_red_act.method3a10                       AS method3a10 
                , v_tri_src_red_act.method3b10                       AS method3b10 
                , v_tri_src_red_act.method3c10                       AS method3c10 
                , v_tri_src_red_act.source4_10                       AS source4_10 
                , v_tri_src_red_act.method4a10                       AS method4a10 
                , v_tri_src_red_act.method4b10                       AS method4b10 
                , v_tri_src_red_act.method4c10                       AS method4c10 
                , NULL                                               AS processing --  More specification detail required. 
                , CASE dbo.Tri_calculaterevisionindicator(tri_report.pk_guid) 
                    WHEN 1 THEN 'Y' 
                    ELSE 'N' 
                  END                                                AS rev_flag 
                , NULL                                               AS dispose_10 
                , NULL                                               AS energy_10 
                , NULL                                               AS recycle_10 
                , NULL                                               AS treat_10 
                , NULL                                               AS othdistr10 
                , NULL                                               AS total_10 
                , v_tri_transfer_loc.rcra_1                          AS rcra_1 
                , v_tri_transfer_loc.offname1                        AS offname1 
                , v_tri_transfer_loc.offstr1                         AS offstr1 
                , v_tri_transfer_loc.offcity1                        AS offcity1 
                , v_tri_transfer_loc.offcount1                       AS offcount1 
                , v_tri_transfer_loc.offst1                          AS offst1 
                , v_tri_transfer_loc.rcra_2                          AS rcra_2 
                , v_tri_transfer_loc.offname2                        AS offname2 
                , v_tri_transfer_loc.offstr2                         AS offstr2 
                , v_tri_transfer_loc.offcity2                        AS offcity2 
                , v_tri_transfer_loc.offcount2                       AS offcount2 
                , v_tri_transfer_loc.offst2                          AS offst2 
                , v_tri_transfer_loc.rcra_3                          AS rcra_3 
                , v_tri_transfer_loc.offname3                        AS offname3 
                , v_tri_transfer_loc.offstr3                         AS offstr3 
                , v_tri_transfer_loc.offcity3                        AS offcity3 
                , v_tri_transfer_loc.offcount3                       AS offcount3 
                , v_tri_transfer_loc.offst3                          AS offst3 
                , v_tri_transfer_loc.rcra_4                          AS rcra_4 
                , v_tri_transfer_loc.offname4                        AS offname4 
                , v_tri_transfer_loc.offstr4                         AS offstr4 
                , v_tri_transfer_loc.offcity4                        AS offcity4 
                , v_tri_transfer_loc.offcount4                       AS offcount4 
                , v_tri_transfer_loc.offst4                          AS offst4 
                , v_tri_transfer_loc.rcra_5                          AS rcra_5 
                , v_tri_transfer_loc.offname5                        AS offname5 
                , v_tri_transfer_loc.offstr5                         AS offstr5 
                , v_tri_transfer_loc.offcity5                        AS offcity5 
                , v_tri_transfer_loc.offcount5                       AS offcount5 
                , v_tri_transfer_loc.offst5                          AS offst5 
                , v_tri_transfer_loc.rcra_6                          AS rcra_6 
                , v_tri_transfer_loc.offname6                        AS offname6 
                , v_tri_transfer_loc.offstr6                         AS offstr6 
                , v_tri_transfer_loc.offcity6                        AS offcity6 
                , v_tri_transfer_loc.offcount6                       AS offcount6 
                , v_tri_transfer_loc.offst6                          AS offst6 
                , v_tri_transfer_loc.rcra_7                          AS rcra_7 
                , v_tri_transfer_loc.offname7                        AS offname7 
                , v_tri_transfer_loc.offstr7                         AS offstr7 
                , v_tri_transfer_loc.offcity7                        AS offcity7 
                , v_tri_transfer_loc.offcount7                       AS offcount7 
                , v_tri_transfer_loc.offst7                          AS offst7 
                , v_tri_transfer_loc.rcra_8                          AS rcra_8 
                , v_tri_transfer_loc.offname8                        AS offname8 
                , v_tri_transfer_loc.offstr8                         AS offstr8 
                , v_tri_transfer_loc.offcity8                        AS offcity8 
                , v_tri_transfer_loc.offcount8                       AS offcount8 
                , v_tri_transfer_loc.offst8                          AS offst8 
                , v_tri_transfer_loc.rcra_9                          AS rcra_9 
                , v_tri_transfer_loc.offname9                        AS offname9 
                , v_tri_transfer_loc.offstr9                         AS offstr9 
                , v_tri_transfer_loc.offcity9                        AS offcity9 
                , v_tri_transfer_loc.offcount9                       AS offcount9 
                , v_tri_transfer_loc.offst9                          AS offst9 
                , v_tri_transfer_loc.rcra_10                         AS rcra_10 
                , v_tri_transfer_loc.offname10                       AS offname10 
                , v_tri_transfer_loc.offstr10                        AS offstr10 
                , v_tri_transfer_loc.offcity10                       AS offcity10 
                , v_tri_transfer_loc.offcount10                      AS offcount10 
                , v_tri_transfer_loc.offst10                         AS offst10 
                , v_tri_transfer_loc.rcra_11                         AS rcra_11 
                , v_tri_transfer_loc.offname11                       AS offname11 
                , v_tri_transfer_loc.offstr11                        AS offstr11 
                , v_tri_transfer_loc.offcity11                       AS offcity11 
                , v_tri_transfer_loc.offcount11                      AS offcount11 
                , v_tri_transfer_loc.offst11                         AS offst11 
                , v_tri_transfer_loc.rcra_12                         AS rcra_12 
                , v_tri_transfer_loc.offname12                       AS offname12 
                , v_tri_transfer_loc.offstr12                        AS offstr12 
                , v_tri_transfer_loc.offcity12                       AS offcity12 
                , v_tri_transfer_loc.offcount12                      AS offcount12 
                , v_tri_transfer_loc.offst12                         AS offst12 
                , v_tri_transfer_loc.rcra_13                         AS rcra_13 
                , v_tri_transfer_loc.offname13                       AS offname13 
                , v_tri_transfer_loc.offstr13                        AS offstr13 
                , v_tri_transfer_loc.offcity13                       AS offcity13 
                , v_tri_transfer_loc.offcount13                      AS offcount13 
                , v_tri_transfer_loc.offst13                         AS offst13 
                , v_tri_transfer_loc.rcra_14                         AS rcra_14 
                , v_tri_transfer_loc.offname14                       AS offname14 
                , v_tri_transfer_loc.offstr14                        AS offstr14 
                , v_tri_transfer_loc.offcity14                       AS offcity14 
                , v_tri_transfer_loc.offcount14                      AS offcount14 
                , v_tri_transfer_loc.offst14                         AS offst14 
                , v_tri_transfer_loc.rcra_15                         AS rcra_15 
                , v_tri_transfer_loc.offname15                       AS offname15 
                , v_tri_transfer_loc.offstr15                        AS offstr15 
                , v_tri_transfer_loc.offcity15                       AS offcity15 
                , v_tri_transfer_loc.offcount15                      AS offcount15 
                , v_tri_transfer_loc.offst15                         AS offst15 
                , v_tri_transfer_loc.rcra_16                         AS rcra_16 
                , v_tri_transfer_loc.offname16                       AS offname16 
                , v_tri_transfer_loc.offstr16                        AS offstr16 
                , v_tri_transfer_loc.offcity16                       AS offcity16 
                , v_tri_transfer_loc.offcount16                      AS offcount16 
                , v_tri_transfer_loc.offst16                         AS offst16 
                , tri_fac.fac_site                                   AS FAC10 
                , NULL                                               AS count 
                , NULL                                               AS rank_10 
                , NULL                                               AS no_r_10 
                , NULL                                               AS no_a_10 
                , NULL                                               AS rec_no 
                , tri_report.sub_rep_year                            AS [SUBMISSION_REPORTING_YEAR]
                , LCR.ecologyregion                                  AS [ECOLOGY_REGION] 
                , T.agencyid                                         AS [FS_ID] 
                , tri_fac.county                                     AS [COUNTY_NM] 
                , T.agencyname                                       AS [AgencyName] 
                , tri_chem.chem_txt                                  AS [CHEMICAL_NAME_TEXT] 
                , CASE tri_chem.cas_clber 
                    WHEN 'N150' THEN 1 
                    ELSE 0 
                  END                                                AS [DIOXIN_IND] 
                , tri_fac.fac_id                                     AS [TRIFID] 
                , tri_fac.fac_site                                   AS [FAC_NAME] 
                , T.epaid                                            AS [EPA_ID] 
FROM   tri_sub 
       INNER JOIN tri_fac 
               ON tri_sub.pk_guid = tri_fac.fk_guid 
       INNER JOIN app_fi_trifid T 
               ON T.trifid = tri_fac.fac_id 
       LEFT JOIN app_lookup_cty_reg LCR 
              ON LCR.county = tri_fac.county 
       INNER JOIN tri_report 
               ON tri_sub.pk_guid = tri_report.fk_guid 
       LEFT JOIN app_link_tri_sub_filename 
              ON app_link_tri_sub_filename.tri_sub_id = tri_sub.tri_sub_id 
       LEFT JOIN v_tri_potw_waste_quantity 
              ON v_tri_potw_waste_quantity.fk_guid = tri_report.pk_guid 
       INNER JOIN tri_chem 
               ON tri_chem.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_uic_disp_qty 
              ON v_tri_onsite_uic_disp_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_disp_qty 
              ON v_tri_onsite_disp_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_offsite_uic_disp_qty 
              ON v_tri_offsite_uic_disp_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_offsite_disp_qty 
              ON v_tri_offsite_disp_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_energy_rcv_qty 
              ON v_tri_onsite_energy_rcv_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_offsite_energy_rec_qty 
              ON v_tri_offsite_energy_rec_qty.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_recycled_q 
              ON v_tri_onsite_recycled_q.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_offsite_recycled_q 
              ON v_tri_offsite_recycled_q.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_treated_q 
              ON v_tri_onsite_treated_q.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_offsite_treated_q 
              ON v_tri_offsite_treated_q.fk_guid = tri_report.pk_guid 
       LEFT JOIN tri_transfer_loc 
              ON ( tri_transfer_loc.fk_guid = tri_report.pk_guid ) 
       -- AND tri_transfer_loc.potw_ind = 'Y')  -- Note:  removed POTW flag, used CASE statment above. 
       LEFT JOIN tri_fac_naics 
              ON tri_fac_naics.fk_guid = tri_fac.pk_guid 
                 AND tri_fac_naics.naics_primary_ind = 'Primary' 
       LEFT JOIN v_tri_form_r_short_xfr tri_form_r_short_xfr 
              ON tri_form_r_short_xfr.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_release_q 
              ON v_tri_onsite_release_q.fk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_rcv_proc 
              ON v_tri_onsite_rcv_proc.pk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_onsite_recycg_proc 
              ON v_tri_onsite_recycg_proc.pk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_src_red_act 
              ON v_tri_src_red_act.pk_guid = tri_report.pk_guid 
       LEFT JOIN v_tri_transfer_loc 
              ON v_tri_transfer_loc.pk_guid = tri_report.pk_guid 
       LEFT JOIN app_fi_trifid_delete_chem 
              ON app_fi_trifid_delete_chem.tri_report_id = tri_report.pk_guid 
WHERE  app_fi_trifid_delete_chem.trifid_delete_chem_id IS NULL 
       AND ( tri_report.sub_partial_fac_id = 'Y' 
              OR ( tri_report.sub_partial_fac_id = 'N' 
                   AND tri_sub.inserted_date = (SELECT Max(S2.inserted_date) 
                                                FROM   tri_report R2 
                                                       JOIN tri_chem C2 
                                                         ON C2.fk_guid = R2.pk_guid 
                                                       JOIN tri_sub S2 
                                                         ON S2.pk_guid = R2.fk_guid 
                                                       JOIN tri_fac F2 
                                                         ON F2.fk_guid = S2.pk_guid 
                                                WHERE  F2.fac_id = tri_fac.fac_id 
                                                       AND R2.sub_rep_year = tri_report.sub_rep_year
                                                       AND C2.chem_txt = tri_chem.chem_txt
													   AND R2.sub_partial_fac_id = 'N') 
                   /* Filter withdrawn chemicals */ 
                   AND COALESCE(tri_report.chem_rpt_wd_cd_1, tri_report.chem_rpt_wd_cd_2) IS NULL ) ); 
GO


PRINT 'V_EXT_TRI_SUMMARY was altered!'

/****** Object:  View [dbo].[V_EXT_UPDATE_FACILITY]    Script Date: 6/30/2015 8:00:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW  [dbo].[V_EXT_UPDATE_FACILITY] 
AS 
SELECT DISTINCT T.TRIFID AS [TRI Facility Id]
     , F.FAC_SITE		AS [Submitted Facility Name]
     , T.AgencyName		AS [Updated Facility Name]
     , T.AgencyID
     , T.EPAID
     , T_own.OWNER_NAME
     , TC.Comment_DS
     , t.Inactive_DT
     , R.SUB_REP_YEAR AS [Submission Year]
     , R.SUB_REP_YEAR AS [SUBMISSION_REPORTING_YEAR]
     , LCR.EcologyRegion AS [ECOLOGY_REGION]
     , T.AgencyID AS [FS_ID]
     , F.COUNTY AS [COUNTY_NM]
     , T.AgencyName	AS [AgencyName]
     , NULL AS [CHEMICAL_NAME_TEXT]
     , 0 AS [DIOXIN_IND]
	 , T.EPAID AS [EPA_ID]
	 , F.FAC_SITE AS [FAC_NAME]
	 , T.TRIFID
  FROM APP_FI_TRIFID T
  LEFT JOIN TRI_FAC F
       JOIN TRI_SUB S
         ON S.PK_GUID = F.FK_GUID
       JOIN TRI_REPORT R
         ON R.FK_GUID = S.PK_GUID
       JOIN TRI_CHEM C
         ON c.fk_guid = r.pk_guid
    ON F.FAC_ID = T.TRIFID
  LEFT JOIN App_Lookup_Cty_Reg LCR
    ON LCR.County = F.COUNTY
  LEFT JOIN APP_FI_OWNER T_OWN
    ON T_OWN.OWNER_ID = T.OWNER_ID
  LEFT JOIN App_FI_TRIFID_Comment TC 
    ON TC.TRIFID_ID_FK = T.TRIFID_ID
 WHERE S.INSERTED_DATE = (SELECT MAX(S2.INSERTED_DATE)
	                           FROM TRI_REPORT R2
		                          JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		                          JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		                          JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		                         WHERE F2.FAC_ID = F.FAC_ID
		                           AND R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		                           AND C2.CHEM_TXT = C.CHEM_TXT)
  AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL;

GO


/****** Object:  View [dbo].[V_EXT_W_MGMT]    Script Date: 6/30/2015 8:27:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/* =============================================
 Full Name:		V_EXTRACT_WASTE_MANAGEMENT
 Condensed Name:	V_EXT_W_MGMT
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Waste Management extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> 'A'*/
ALTER VIEW [dbo].[V_EXT_W_MGMT]
AS
SELECT pk_guid_report, 
       fs_id                                  AS FSID, 
       epa_id                                 AS [ECY ID], 
       trifid                                 AS [TRI Facility Id], 
       submission_reporting_year              AS [Year], 
       revision_indicator                     AS Revision, 
       submission_partial_facility_id         AS [Partial Sub], 
       fac_name                               AS [Facility Name], 
--       agencyname                             AS AKA, 
       chemical_name_text                     AS Chemical, 
       cas_number                             AS [Cas #], 
       production_ratio_measure               AS [Prod Ratio], 
       one_time_release_quantity              AS [One Time Release], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_uic_disp_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS 
       [On Disp UG INJ Landfills PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_uic_disp_qty AS TRI_ONSITE_UIC_DISP_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS 
       [On Disp UG INJ Landfills CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_uic_disp_qty AS TRI_ONSITE_UIC_DISP_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS 
       [On Disp UG INJ Landfills FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_uic_disp_qty AS TRI_ONSITE_UIC_DISP_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS 
       [On Disp UG INJ Landfills 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_uic_disp_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS 
       [Off Disp UG INJ Landfills PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_uic_disp_qty AS TRI_OFFSITE_UIC_DISP_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS 
       [Off Disp UG INJ Landfills CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_uic_disp_qty AS TRI_OFFSITE_UIC_DISP_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS 
       [Off Disp UG INJ Landfills FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_uic_disp_qty AS TRI_OFFSITE_UIC_DISP_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS 
       [Off Disp UG INJ Landfills 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_disp_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [On Disp Other PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_disp_qty AS TRI_ONSITE_DISP_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [On Disp Other CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_disp_qty AS TRI_ONSITE_DISP_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [On Disp Other FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_disp_qty AS TRI_ONSITE_DISP_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [On Disp Other 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_disp_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [Off Disp Other PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_disp_qty AS TRI_OFFSITE_DISP_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [Off Disp Other CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_disp_qty AS TRI_OFFSITE_DISP_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [Off Disp Other FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_disp_qty AS TRI_OFFSITE_DISP_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [Off Disp Other 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_energy_rcv_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [On Energy Recovery PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_energy_rcv_qty AS TRI_ONSITE_ENERGY_RCV_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [On Energy Recovery CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_energy_rcv_qty AS TRI_ONSITE_ENERGY_RCV_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [On Energy Recovery FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_energy_rcv_qty AS TRI_ONSITE_ENERGY_RCV_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [On Energy Recovery 2ND FWL YR] 
       , 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_energy_rec_qty 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [Off Energy Recovery PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_energy_rec_qty AS TRI_OFFSITE_ENERGY_REC_QTY_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [Off Energy Recovery CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_energy_rec_qty AS TRI_OFFSITE_ENERGY_REC_QTY_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [Off Energy Recovery FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_energy_rec_qty AS TRI_OFFSITE_ENERGY_REC_QTY_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS 
       [Off Energy Recovery 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_recycled_q 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [On Recycled PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_recycled_q AS TRI_ONSITE_RECYCLED_Q_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [On Recycled CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_recycled_q AS TRI_ONSITE_RECYCLED_Q_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [On Recycled FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_recycled_q AS TRI_ONSITE_RECYCLED_Q_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [On Recycled 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_recycled_q 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [Off Recycled PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_recycled_q AS TRI_OFFSITE_RECYCLED_Q_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [Off Recycled CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_recycled_q AS TRI_OFFSITE_RECYCLED_Q_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [Off Recycled FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_recycled_q AS TRI_OFFSITE_RECYCLED_Q_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [Off Recycled 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_treated_q 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [On Treated PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_treated_q AS TRI_ONSITE_TREATED_Q_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [On Treated CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_treated_q AS TRI_ONSITE_TREATED_Q_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [On Treated FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_onsite_treated_q AS TRI_ONSITE_TREATED_Q_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [On Treated 2ND FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_treated_q 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '-1' )) AS [Off Treated PRI YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_treated_q AS TRI_OFFSITE_TREATED_Q_3 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '0' ))  AS [Off Treated CURR YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_treated_q AS TRI_OFFSITE_TREATED_Q_2 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '1' ))  AS [Off Treated FWL YR], 
       (SELECT CASE 
                 WHEN total_q_na_ind = 'Y' THEN NULL 
                 ELSE total_q 
               END AS Expr1 
        FROM   dbo.tri_offsite_treated_q AS TRI_OFFSITE_TREATED_Q_1 
        WHERE  ( fk_guid = TD.pk_guid_report ) 
               AND ( year_offset_me = '2' ))  AS [Off Treated 2ND FWL YR], 
       ecology_region                         AS [ECY Region], 
       submission_reporting_year, 
       ecology_region, 
       fs_id, 
       epa_id, 
       county_nm as [County], 
       county_nm, 
       fac_name, 
--       agencyname, 
       chemical_name_text, 
       TD.dioxin_ind,
       trifid
FROM   dbo.v_ext_master AS TD 
WHERE  ( report_type = 'TRI_FORM_R' ) 

GO

PRINT 'V_EXT_W_MGMT was altered!'

/****** Object:  View [dbo].[V_FORM_A_PG_1]    Script Date: 6/30/2015 6:56:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[V_FORM_A_PG_1]
-- =================================================================================
-- Full Name:		V_TRI_FORM_A_PAGE_1
-- Condensed Name:	V_FORM_A_PG_1
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the fields on Form "A", Page 1
-- Change History:
-- TKC 6/10/2008:	Changed the logic for display of A22 so that it is conditional
--					on whether or not CHEM_TRADE_SECRET_IND = 'Y'
-- TKC 6/30/2015:	Format phone numbers and include the extension.
-- =================================================================================
AS
SELECT DISTINCT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       UPPER(F.FAC_ID) FAC_ID,
       R.REVISION_IND A0,
       R.CHEM_RPT_REV_CD_1 A0REVCD1,
       R.CHEM_RPT_REV_CD_2 A0REVCD2,
       R.CHEM_RPT_WD_CD_1 A0WITHDCD1,
       R.CHEM_RPT_WD_CD_2 A0WITHDCD2,
       R.SUB_REP_YEAR A1,
       R.CHEM_TRADE_SECRET_IND A21,
       CASE R.CHEM_TRADE_SECRET_IND
            WHEN 'Y' THEN R.SUB_SANITIZED_IND
            ELSE NULL
       END A22,
       R.CERTIFIER + ' ' + R.CERTIFIER_TIT_TXT AS A31,
       R.CERT_SIGNED_DATE A33,
       UPPER(F.FAC_ID) A41TRI_ID,
       F.FAC_SITE A41NAME,
       ISNULL(F.LOC_ADD_TXT,'') + ' ' + ISNULL(F.SUPP_LOC_TXT,'') A41STREET,
       ISNULL(F.LOCALITY,'') + '/' + ISNULL(F.COUNTY,'') + '/' + ISNULL(F.STATE,'') + '/' + ISNULL(F.ADD_POSTAL_CODE,'') A41_CITYSTATE,
       F.MAIL_FAC_SITE A41MAIL_NAME,
       ISNULL(F.MAIL_ADD_TXT,'') + ' ' + ISNULL(F.SUPP_MAIL_ADD,'') A41MAIL_STREET,
       ISNULL(F.MAIL_ADD_CITY,'') + '/' + ISNULL(F.MAIL_ADD_STATE,'') + '/' + ISNULL(F.MAIL_ADD_POSTAL_CODE,'') A41MAILCITYSTATE,
       F.MAIL_ADD_COUNTRY A41MAILCOUNTRY,
       R.SUB_FEDERAL_FAC_ID A42C,
       R.SUB_CO_FAC_INDIC A42D,
       R.TECH_CONT A43NAME,
       CASE WHEN R.TECH_CONT_EMAIL_ADDRES = 'NA' THEN 'NA' ELSE LOWER(R.TECH_CONT_EMAIL_ADDRES) END A43EMAIL,
       dbo.udf_FormatPhone(R.TECH_CONT_PHONE_TXT) + ISNULL(' x' + R.TECH_CONT_PHONE_EXT_TXT,'') A43TEL,
       PUB_CONT A44NAME,
       dbo.udf_FormatPhone(PUB_CONT_PHONE_TXT) + ISNULL(' x' + R.PUB_CONT_PHONE_EXT_TXT,'') A44TEL,
       R.PUB_CONT_EMAIL_ADDRES A44EMAIL,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND = 'Primary'
           AND N.FK_GUID = F.PK_GUID) A45A,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> 'Primary') = 1) A45B,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> 'Primary') = 2) A45C,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> 'Primary') = 3) A45D,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> 'Primary') = 4) A45E,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> 'Primary') = 5) A45F,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) A47A,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) A47B,
       F.PARENT_COMPANY_TXT A51,
       F.PARENT_DUN_CODE A52
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

GO


/****** Object:  View [dbo].[V_TRI_PAGE1]    Script Date: 6/12/2015 1:16:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PAGE1]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R0REVCD1, R0REVCD2, R0WITHDCD1, R0WITHDCD2, R1, R21, 
 R22, R31, R33, R41TRI_ID, R41NAME, 
 R41STREET, R41_CITYSTATE, R41MAIL_NAME, R41MAIL_STREET, R41MAILCITYSTATE, R41MAILCOUNTRY, 
 R42A, R42B, R42C, R42D, R43NAME, 
 R43EMAIL, R43TEL, R44NAME, R44TEL, R44EMAIL, R45A, 
 R45B, R45C, R45D, R45E, R45F, 
R471, R472, 
R51, R52, R51NS)
-- =================================================================================
-- Name:			V_TRI_PAGE1
-- Author:			Mark Chmarny
-- Create date:		??
-- Description:		Fills the fields on Form "R", Page 1
-- Change History:
-- TKC 6/10/2008:	Changed the logic for display of R22 so that it is conditional
--					on whether or not CHEM_TRADE_SECRET_IND = 'Y'
-- TKC 6/12/2015:	Added Parent Facility Name Not Standard.
-- =================================================================================
AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       FAC_ID,
       CHEM_TXT,
       R.CHEM_RPT_REV_CD_1 R0REVCD1,
       R.CHEM_RPT_REV_CD_2 R0REVCD2,
       R.CHEM_RPT_WD_CD_1 R0WITHDCD1,
       R.CHEM_RPT_WD_CD_2 R0WITHDCD2,
       SUB_REP_YEAR R1,
       CHEM_TRADE_SECRET_IND R21,
       CASE CHEM_TRADE_SECRET_IND
           WHEN 'Y' THEN SUB_SANITIZED_IND
           ELSE NULL
       END R22,
       ISNULL(CERTIFIER,'') + ' ' + ISNULL(CERTIFIER_TIT_TXT,'') AS R31,
       CONVERT(VARCHAR(10), R.CERT_SIGNED_DATE, 101) R33,
       FAC_ID R41TRI_ID,
       FAC_SITE R41NAME,
       ISNULL(F.LOC_ADD_TXT,'') + ' ' + ISNULL(F.SUPP_LOC_TXT,'') R41STREET,
       ISNULL(F.LOCALITY,'') + '/' + ISNULL(F.COUNTY,'') + '/' + ISNULL(F.STATE,'') + '/' + ISNULL(F.ADD_POSTAL_CODE,'') R41_CITYSTATE,
       F.MAIL_FAC_SITE R41MAIL_NAME,
       ISNULL(F.MAIL_ADD_TXT,'') + ' ' + ISNULL(F.SUPP_MAIL_ADD,'') R41MAIL_STREET,
       ISNULL(F.MAIL_ADD_CITY + '/','') + ISNULL(F.MAIL_ADD_STATE + '/','') + ISNULL(F.MAIL_ADD_POSTAL_CODE,'') R41MAILCITYSTATE,
       MAIL_ADD_COUNTRY R41MAILCOUNTRY,
       CASE SUB_PARTIAL_FAC_ID WHEN 'N' THEN 'Y' ELSE 'N' END R42A,
       SUB_PARTIAL_FAC_ID R42B,
       SUB_FEDERAL_FAC_ID R42C,
       SUB_CO_FAC_INDIC R42D,
       TECH_CONT R43NAME,
       TECH_CONT_EMAIL_ADDRES R43EMAIL,
       [dbo].[udf_FormatPhone](TECH_CONT_PHONE_TXT) + ISNULL(' x' + TECH_CONT_PHONE_EXT_TXT,'') R43TEL,
       PUB_CONT R44NAME,
       [dbo].[udf_FormatPhone](PUB_CONT_PHONE_TXT) + ISNULL(' x' + PUB_CONT_PHONE_EXT_TXT,'') R44TEL,
       PUB_CONT_EMAIL_ADDRES R44EMAIL,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND = 'Primary'
           AND FK_GUID = F.PK_GUID) R45A,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> 'Primary') = 1) R45B,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> 'Primary') = 2) R45C,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> 'Primary') = 3) R45D,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> 'Primary') = 4) R45E,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> 'Primary'
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> 'Primary') = 5) R45F,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R471,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R472,
       PARENT_COMPANY_TXT R51,
       PARENT_DUN_CODE R52,
	   PARENT_COMPANY_NAME_N_S R51NS
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

GO


PRINT 'V_TRI_PAGE1 was altered!'

/****** Object:  View [dbo].[V_TRI_PAGE2]    Script Date: 6/12/2015 1:40:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PAGE2]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R11, R12, R13, DIOXIN_DIST1, 
 DIOXIN_DIST2, DIOXIN_DIST3, DIOXIN_DIST4, DIOXIN_DIST5, DIOXIN_DIST6, 
 DIOXIN_DIST7, DIOXIN_DIST8, DIOXIN_DIST9, DIOXIN_DIST10, DIOXIN_DIST11, 
 DIOXIN_DIST12, DIOXIN_DIST13, DIOXIN_DIST14, DIOXIN_DIST15, DIOXIN_DIST16, 
 DIOXIN_DIST17, R31A, R31B, R31C, R31D, 
 R31E, R31F, R32A, R32B, R32C, 
 R32D, R32E, R33A, R33B, R33C, 
 R41, R51A, R51B, R51C, R52A, 
 R52B, R52C, R531STREAM, R531A, R531B, 
 R531C, R532STREAM, R532A, R532B, R532C, 
 R533STREAM, R533A, R533B, R533C,
 R531RC, R532RC, R533RC)
AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       FAC_ID,
       CHEM_TXT,
       CAS_CLBER R11,
       CHEM_TXT R12,
       CHEM_MIXTURE_TXT R13,
       DIOXIN_DIST1,
       DIOXIN_DIST2,
       DIOXIN_DIST3,
       DIOXIN_DIST4,
       DIOXIN_DIST5,
       DIOXIN_DIST6,
       DIOXIN_DIST7,
       DIOXIN_DIST8,
       DIOXIN_DIST9,
       DIOXIN_DIST10,
       DIOXIN_DIST11,
       DIOXIN_DIST12,
       DIOXIN_DIST13,
       DIOXIN_DIST14,
       DIOXIN_DIST15,
       DIOXIN_DIST16,
       DIOXIN_DIST17,
       CHEM_PRODUCED_IND R31A,
       CHEM_IMPORTED_IND R31B,
       CHEM_USED_PROCED_ID R31C,
       CHEM_SALES_DIST_ID R31D,
       CHEM_BYPRODUCT_IND R31E,
       CHEM_MANUFACTURE_IMPURITY R31F,
       CHEM_REACTANT_IND R32A,
       CHEM_FORMULATION_COMP R32B,
       CHEM_ARTICLE_COMP_ID R32C,
       CHEM_REP_IND R32D,
       CHEM_PROC_IMPURITY_ID R32E,
       CHEM_PROCING_AID_ID R33A,
       CHEM_MANUFACTURE_AID_ID R33B,
       CHEM_ANC_USAGE_IND R33C,
       MAX_CHEM_AMOUNT_CODE R41,
       COALESCE (REL.WASTE_Q_RANGE_CODE, REL.WASTE_Q_ME) R51A,
       REL.Q_BASIS_EST_CD R51B,
       REL.RELEASE_STORM_WATER R51C,
       COALESCE (REL2.WASTE_Q_RANGE_CODE, REL2.WASTE_Q_ME) R52A,
       REL2.Q_BASIS_EST_CD R52B,
       REL2.RELEASE_STORM_WATER R52C,
	   R531.STREAM R531STREAM,
	   R531.A R531A,
	   R531.B R531B,
	   R531.C R531C,
   	   R532.STREAM R532STREAM,
	   R532.A R532A,
	   R532.B R532B,
	   R532.C R532C,
   	   R533.STREAM R533STREAM,
	   R533.A R533A,
	   R533.B R533B,
	   R533.C R533C,
	   R531.SRC R531SRC,
	   R532.SRC R532SRC,
	   R533.SRC R533SRC
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL ON REL.FK_GUID = R.PK_GUID
                                              AND REL.EI_MEDIUM_CODE = 'AIR FUG'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL2 ON REL2.FK_GUID = R.PK_GUID
                                               AND REL2.EI_MEDIUM_CODE = 'AIR STACK'
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C, SRC FROM V_TRI_PG2_53 WHERE NUM = 1) R531 ON R531.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C, SRC FROM V_TRI_PG2_53 WHERE NUM = 2) R532 ON R532.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C, SRC FROM V_TRI_PG2_53 WHERE NUM = 3) R533 ON R533.FK_GUID = R.PK_GUID

GO


/****** Object:  View [dbo].[V_TRI_PAGE3]    Script Date: 11/5/2015 3:29:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[V_TRI_PAGE3]
( PK_GUID_SUB
, PK_GUID_REP
, FAC_ID
, CHEM_TXT
, R541A
, R541B
, R542A
, R542B
, R551AA
 , R551AB
 , R551BA
 , R551BB
 , R552AA
 , R552AB
 , R5553AA
 , R5553AB
 , R553BA
 , R553BB
 , R554A
 , R554B
 , R621RCRAID
 , R621NAME
 , R621ADDRESS
 , R621CITY
 , R621STATE
 , R621COUNTY
 , R621ZIP
 , R621LOCATIONCONTROL
 , R621A1
 , R621B1
 , R621C1
 , R621A2
 , R621B2
 , R621C2
 , R621A3
 , R621B3
 , R621C3
 , R621A4
 , R621B4
 , R621C4
 , R622RCRAID
 , R622NAME
 , R622ADDRESS
 , R622CITY
 , R622STATE
 , R622COUNTY
 , R622ZIP
 , R622LOCATIONCONTROL
 , R622A1
 , R622B1
 , R622C1
 , R622A2
 , R622B2
 , R622C2
 , R622A3
 , R622B3
 , R622C3
 , R622A4
 , R622B4
 , R622C4)
AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       F.FAC_ID,
       C.CHEM_TXT,
       COALESCE (REL1.WASTE_Q_RANGE_CODE, REL1.WASTE_Q_ME) R541A,
       REL1.Q_BASIS_EST_CD R541B,
       COALESCE (REL2.WASTE_Q_RANGE_CODE, REL2.WASTE_Q_ME) R542A,
       REL2.Q_BASIS_EST_CD R542B,
       COALESCE (REL3.WASTE_Q_RANGE_CODE, REL3.WASTE_Q_ME) R551AA,
       REL3.Q_BASIS_EST_CD R551AB,
       COALESCE (REL4.WASTE_Q_RANGE_CODE, REL4.WASTE_Q_ME) R551BA,
       REL4.Q_BASIS_EST_CD R551BB,
       COALESCE (REL5.WASTE_Q_RANGE_CODE, REL5.WASTE_Q_ME) R552AA,
       REL5.Q_BASIS_EST_CD R552AB,
       COALESCE (REL6.WASTE_Q_RANGE_CODE, REL6.WASTE_Q_ME) R5553AA,
       REL6.Q_BASIS_EST_CD R5553AB,
       COALESCE (REL7.WASTE_Q_RANGE_CODE, REL7.WASTE_Q_ME) R553BA,
       REL7.Q_BASIS_EST_CD R553BB,
       COALESCE (REL8.WASTE_Q_RANGE_CODE, REL8.WASTE_Q_ME) R554A,
       REL8.Q_BASIS_EST_CD R554B,
       SITE1.RCRA_ID_CLBER R621RCRAID,
       SITE1.FAC_SITE R621NAME,
       SITE1.LOC_ADD_TXT R621ADDRESS,
       SITE1.LOCALITY R621CITY,
       SITE1.STATE R621STATE,
       SITE1.COUNTY R621COUNTY,
       SITE1.ADD_POSTAL_CODE R621ZIP,
       SITE1.CONTROLLED_LOC_IND R621LOCATIONCONTROL,
       R621A1,
       R621B1,
       R621C1,
       R621A2,
       R621B2,
       R621C2,
       R621A3,
       R621B3,
       R621C3,
       R621A4,
       R621B4,
       R621C4,
       SITE2.RCRA_ID_CLBER R622RCRAID,
       SITE2.FAC_SITE R622NAME,
       SITE2.LOC_ADD_TXT R622ADDRESS,
       SITE2.LOCALITY R622CITY,
       SITE2.STATE R622STATE,
       SITE2.COUNTY R622COUNTY,
       SITE2.ADD_POSTAL_CODE R622ZIP,
       SITE2.CONTROLLED_LOC_IND R622LOCATIONCONTROL,
       R622A1,
       R622B1,
       R622C1,
       R622A2,
       R622B2,
       R622C2,
       R622A3,
       R622B3,
       R622C3,
       R622A4,
       R622B4,
       R622C4
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               RCRA_ID_CLBER,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE,
                               CONTROLLED_LOC_IND,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621A1,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621B1,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621C1,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621A2,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621B2,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621C2,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621A3,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621B3,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621C3,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621A4,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621B4,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621C4
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = 'N'
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = 'N'
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 1) SITE1 ON SITE1.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               RCRA_ID_CLBER,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE,
                               CONTROLLED_LOC_IND,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622A1,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622B1,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622C1,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622A2,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622B2,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622C2,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622A3,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622B3,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622C3,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622A4,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622B4,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622C4
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = 'N'
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = 'N'
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 2) SITE2 ON SITE2.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL1 ON REL1.FK_GUID = R.PK_GUID
                                               AND REL1.EI_MEDIUM_CODE = 'UNINJ I'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL2 ON REL2.FK_GUID = R.PK_GUID
                                               AND REL2.EI_MEDIUM_CODE = 'UNINJ IIV'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL3 ON REL3.FK_GUID = R.PK_GUID
                                               AND REL3.EI_MEDIUM_CODE = 'RCRA C'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL4 ON REL4.FK_GUID = R.PK_GUID
                                               AND REL4.EI_MEDIUM_CODE = 'OTH LANDF'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL5 ON REL5.FK_GUID = R.PK_GUID
                                               AND REL5.EI_MEDIUM_CODE = 'LAND TREA'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL6 ON REL6.FK_GUID = R.PK_GUID
                                               AND REL6.EI_MEDIUM_CODE = 'SI 5.5.3A'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL7 ON REL7.FK_GUID = R.PK_GUID
                                               AND REL7.EI_MEDIUM_CODE = 'SI 5.5.3B'
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL8 ON REL8.FK_GUID = R.PK_GUID
                                               AND REL8.EI_MEDIUM_CODE = 'OTH DISP'

GO


/****** Object:  View [dbo].[V_TRI_PAGE3_XFR]    Script Date: 11/4/2015 5:34:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PAGE3_XFR]
AS
WITH Page3_XFR_CTE AS
(
SELECT -- TOP 100 PERCENT
	S.PK_GUID AS PK_GUID_SUB
,	R.PK_GUID AS PK_GUID_REP
,	TL.RCRA_ID_CLBER as R62RCRAID
,	TL.FAC_SITE as R62NAME
,	TL.LOC_ADD_TXT as R62ADDRESS
,	TL.LOCALITY as R62CITY
,	TL.STATE as R62STATE
,	TL.COUNTY as R62COUNTY
,	TL.ADD_POSTAL_CODE as R62ZIP
,	TL.CONTROLLED_LOC_IND as R62LOCATIONCONTROL
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62A ELSE '' END) AS R62A1
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62B ELSE '' END) AS R62B1
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62C ELSE '' END) AS R62C1
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62A ELSE '' END) AS R62A2
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62B ELSE '' END) AS R62B2
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62C ELSE '' END) AS R62C2
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62A ELSE '' END) AS R62A3
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62B ELSE '' END) AS R62B3
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62C ELSE '' END) AS R62C3
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62A ELSE '' END) AS R62A4
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62B ELSE '' END) AS R62B4
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62C ELSE '' END) AS R62C4
,	CAST(TL.TRANSFER_LOC_SEQ_CL AS INT) AS TRANSFER_LOC_SEQ_CL
FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN dbo.TRI_TRANSFER_LOC TL ON TL.FK_GUID = R.PK_GUID
LEFT JOIN
	(
	SELECT
		TQ.FK_GUID
	,	TQ.TRANSFER_SEQ_CLBER
	,	COALESCE(TQ.WASTE_Q_ME, TQ.WASTE_Q_RANGE_CODE) R62A
	,	TQ.Q_BASIS_EST_CODE R62B
	,	TQ.WASTE_MANAGEMENT_CODE R62C
	,	(
		SELECT COUNT(*)
		FROM dbo.TRI_TRANSFER_Q TQ2
		WHERE
			TQ2.FK_GUID = TQ.FK_GUID
		AND
			TQ2.PK_GUID <= TQ.PK_GUID
		) AS NUM
	FROM dbo.TRI_TRANSFER_Q TQ
	) AS XFR
ON XFR.FK_GUID = TL.PK_GUID
WHERE TL.POTW_IND = 'N'
GROUP BY
	S.PK_GUID
,	R.PK_GUID
,	CAST(TL.TRANSFER_LOC_SEQ_CL AS INT)
,	TL.RCRA_ID_CLBER
,	TL.FAC_SITE
,	TL.LOC_ADD_TXT
,	TL.LOCALITY
,	TL.STATE
,	TL.COUNTY
,	TL.ADD_POSTAL_CODE
,	TL.CONTROLLED_LOC_IND
)

SELECT PK_GUID_SUB
      ,PK_GUID_REP
      ,R62RCRAID
      ,R62NAME
      ,R62ADDRESS
      ,R62CITY
      ,R62STATE
      ,R62COUNTY
      ,R62ZIP
      ,R62LOCATIONCONTROL
      ,R62A1
      ,R62B1
      ,R62C1
      ,R62A2
      ,R62B2
      ,R62C2
      ,R62A3
      ,R62B3
      ,R62C3
      ,R62A4
      ,R62B4
      ,R62C4
	  ,TRANSFER_LOC_SEQ_CL
  FROM Page3_XFR_CTE t1

WHERE TRANSFER_LOC_SEQ_CL >
(
SELECT MIN(TRANSFER_LOC_SEQ_CL) FROM Page3_XFR_CTE t2
WHERE t2.PK_GUID_REP = t1.PK_GUID_REP
)

GO

PRINT 'V_TRI_PAGE3_XFR altered successfully!'

/****** Object:  View [dbo].[V_TRI_PAGE5]    Script Date: 6/1/2015 12:43:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PAGE5]
AS
SELECT
S.PK_GUID AS PK_GUID_SUB,
R.PK_GUID AS PK_GUID_REP,
F.FAC_ID,
C.CHEM_TXT,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R7B1,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R7B2,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 3 AND M.PK_GUID = R.PK_GUID) R7B3,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R7C1,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R7C2,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 3 AND M.PK_GUID = R.PK_GUID) R7C3,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 4 AND M.PK_GUID = R.PK_GUID) R7C4,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 5 AND M.PK_GUID = R.PK_GUID) R7C5,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 6 AND M.PK_GUID = R.PK_GUID) R7C6,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 7 AND M.PK_GUID = R.PK_GUID) R7C7,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 8 AND M.PK_GUID = R.PK_GUID) R7C8,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 9 AND M.PK_GUID = R.PK_GUID) R7C9,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 10 AND M.PK_GUID = R.PK_GUID) R7C10,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81AA,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81AB,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81AC,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81AD,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81BA,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81BB,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81BC,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81BD,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81CBA,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81CB,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81CC,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81CD,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81DA,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81DB,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81DC,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81DD,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R82A,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R82B,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R82C,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R82D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R83A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R83B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R83C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R83D,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R84A,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R84B,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R84C,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R84D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R85A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R85B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R85C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R85D,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R86A,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R86B,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R86C,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R86D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R87A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R87B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R87C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R87D,
ONE_TIME_RELEASE_Q R88,
PRODUCTION_RATIO_ME R89,
SUB_ADDITIONAL_DATA_ID R811,
R811.COMMENT_TYPE_DESC R811_COMMENT_TYPE,
R811.COMMENT_TEXT R811_TEXT,
R811.COMMENT_P2_CLASS R811_P2_CLASS,
R91.COMMENT_TYPE_DESC R91_COMMENT_TYPE,
R91.COMMENT_TEXT R91_TEXT,
R91.COMMENT_P2_CLASS R91_P2_CLASS,
CASE WHEN ISNULL(R.PRODUCTION_RATIO_TYPE,'PRODUCTION') = 'PRODUCTION' THEN 'Y' ELSE 'N' END R89PRODYN

FROM TRI_REPORT R
JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
LEFT JOIN V_TRI_PAGE5_CMT_ONE_LN R811
  ON R811.PK_GUID_REP = R.PK_GUID
 AND R811.COMMENT_SECTION = '8.11'
LEFT JOIN V_TRI_PAGE5_CMT_ONE_LN R91
  ON R91.PK_GUID_REP = R.PK_GUID
 AND R91.COMMENT_SECTION = '9.1'

GO


/****** Object:  View [dbo].[V_TRI_PAGE5_SRA]    Script Date: 6/12/2015 12:35:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[V_TRI_PAGE5_SRA] AS
SELECT TOP 100 PERCENT R.FK_GUID PK_GUID_SUB
     , R.PK_GUID PK_GUID_REP
     , SRC_RED_ACT_CODE R810VALUE
     , (SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 1)  R810A
     , (SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 2)  R810B
     , (SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 3) R810C
	 , SRC_RED_EFF_CODE R810ESTANNRED
     , (SELECT COUNT (*)
          FROM TRI_SRC_RED_ACT S2
         WHERE S2.FK_GUID = S.FK_GUID
           AND S2.PK_GUID <= S.PK_GUID) NUM
  FROM TRI_REPORT R 
 INNER JOIN TRI_SRC_RED_ACT S 
    ON S.FK_GUID = R.PK_GUID
 ORDER BY SRC_RED_SEQ_CL

GO


