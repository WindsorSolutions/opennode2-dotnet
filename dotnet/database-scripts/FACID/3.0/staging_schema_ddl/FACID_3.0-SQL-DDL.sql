/*  
 ****************************************************************************************************************************   
 *
 *  Script Name:  FACID_3.0-SQL-DDL.sql
 *
 *  Purpose:  This script will build the required objects to support the FACID data flow.
 *         
 *  Maintenance:
 *  
 *    Analyst         Date            Comment 
 *    ----------      ----------      --------------------------------------------
 *    KJames          01/28/2010      Created
 *    TK	      01/31/2010      The script was updated to rename the primary key for the FACID_AFFIL table.  The CERS schema 
 * 				      and the FACID schema were both using an identical primary key name fo their affiliation tables.
 *				      Without this modification the schemas would be incompatible in the same database.
 *    KJames          02/21/2012      Made FAC_SITE_IDEN_VAL not nullable.
 *
 ****************************************************************************************************************************   
 */



/****** Object:  ForeignKey [FK_AFFL_FAC_DTLS]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AFFL_FAC_DTLS]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]'))
ALTER TABLE [dbo].[FACID_AFFL] DROP CONSTRAINT [FK_AFFL_FAC_DTLS]
GO
/****** Object:  ForeignKey [FK_AFF_ELE_ADD_AFF]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AFF_ELE_ADD_AFF]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_AFFL_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_AFFL_ELEC_ADDR] DROP CONSTRAINT [FK_AFF_ELE_ADD_AFF]
GO
/****** Object:  ForeignKey [FK_ALT_NAME_FAC]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ALT_NAME_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ALT_NAME]'))
ALTER TABLE [dbo].[FACID_ALT_NAME] DROP CONSTRAINT [FK_ALT_NAME_FAC]
GO
/****** Object:  ForeignKey [FK_ENVR_INTR_FAC]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENVR_INTR_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR] DROP CONSTRAINT [FK_ENVR_INTR_FAC]
GO
/****** Object:  ForeignKey [FK_EN_IN_AL_ID_EN]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_AL_ID_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ALT_IDEN]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_ALT_IDEN] DROP CONSTRAINT [FK_EN_IN_AL_ID_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_EL_AD_EN]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_EL_AD_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_ELEC_ADDR] DROP CONSTRAINT [FK_EN_IN_EL_AD_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_AF_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_AF_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL] DROP CONSTRAINT [FK_EN_IN_FA_AF_EN]
GO
/****** Object:  ForeignKey [FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL] DROP CONSTRAINT [FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_NA_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_NA_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_NAICS]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_NAICS] DROP CONSTRAINT [FK_EN_IN_FA_NA_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_SI_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_SI_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_SIC]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_SIC] DROP CONSTRAINT [FK_EN_IN_FA_SI_EN]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_DTLS]    Script Date: 04/29/2010 10:24:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_DTLS]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC]'))
ALTER TABLE [dbo].[FACID_FAC] DROP CONSTRAINT [FK_FAC_FAC_DTLS]
GO
/****** Object:  ForeignKey [FK_FAC_ALT_IDE_FAC]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_ALT_IDE_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ALT_IDEN]'))
ALTER TABLE [dbo].[FACID_FAC_ALT_IDEN] DROP CONSTRAINT [FK_FAC_ALT_IDE_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_ELE_ADD_FAC]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_ELE_ADD_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_FAC_ELEC_ADDR] DROP CONSTRAINT [FK_FAC_ELE_ADD_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_AFF_FAC]    Script Date: 04/29/2010 10:24:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_AFF_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL] DROP CONSTRAINT [FK_FAC_FAC_AFF_FAC]
GO
/****** Object:  ForeignKey [FK_FACID_FAC_FAC_AFFL_FACID_AFFL]    Script Date: 04/29/2010 10:24:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACID_FAC_FAC_AFFL_FACID_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL] DROP CONSTRAINT [FK_FACID_FAC_FAC_AFFL_FACID_AFFL]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_NAI_FAC]    Script Date: 04/29/2010 10:24:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_NAI_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_NAICS]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_NAICS] DROP CONSTRAINT [FK_FAC_FAC_NAI_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_SIC_FAC]    Script Date: 04/29/2010 10:24:38 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_SIC_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_SIC]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_SIC] DROP CONSTRAINT [FK_FAC_FAC_SIC_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_GE_LO_DE_FA]    Script Date: 04/29/2010 10:24:40 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_GE_LO_DE_FA]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]'))
ALTER TABLE [dbo].[FACID_FAC_GEO_LOC_DESC] DROP CONSTRAINT [FK_FAC_GE_LO_DE_FA]
GO
/****** Object:  ForeignKey [FK_FA_PR_GE_LO_DE]    Script Date: 04/29/2010 10:24:42 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FA_PR_GE_LO_DE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]'))
ALTER TABLE [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] DROP CONSTRAINT [FK_FA_PR_GE_LO_DE]
GO
/****** Object:  ForeignKey [FK_POS_SHAPE]    Script Date: 04/29/2010 10:24:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_POS_SHAPE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_POS]'))
ALTER TABLE [dbo].[FACID_POS] DROP CONSTRAINT [FK_POS_SHAPE]
GO
/****** Object:  ForeignKey [FK_SHA_FA_GE_LO_DE]    Script Date: 04/29/2010 10:24:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SHA_FA_GE_LO_DE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_SHAPE]'))
ALTER TABLE [dbo].[FACID_SHAPE] DROP CONSTRAINT [FK_SHA_FA_GE_LO_DE]
GO
/****** Object:  ForeignKey [FK_TELEPHONIC_AFFL]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TELEPHONIC_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_TELEPHONIC]'))
ALTER TABLE [dbo].[FACID_TELEPHONIC] DROP CONSTRAINT [FK_TELEPHONIC_AFFL]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_FormatVarchar]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_FormatVarchar]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_FormatVarchar]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_DateOrTimeXML]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_DateOrTimeXML]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_DateOrTimeXML]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_LookupStateName]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_LookupStateName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_LookupStateName]
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_AFFL]    Script Date: 04/29/2010 10:24:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_FAC_AFFL]
GO
/****** Object:  Table [dbo].[FACID_TELEPHONIC]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_TELEPHONIC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_TELEPHONIC]
GO
/****** Object:  Table [dbo].[FACID_AFFL_ELEC_ADDR]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL_ELEC_ADDR]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_AFFL_ELEC_ADDR]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_AFFL]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_ELEC_ADDR]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ELEC_ADDR]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR_ELEC_ADDR]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_ALT_IDEN]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ALT_IDEN]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR_ALT_IDEN]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_SIC]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_SIC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR_FAC_SIC]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_NAICS]    Script Date: 04/29/2010 10:24:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_NAICS]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR_FAC_NAICS]
GO
/****** Object:  Table [dbo].[FACID_POS]    Script Date: 04/29/2010 10:24:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_POS]
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_SIC]    Script Date: 04/29/2010 10:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_SIC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_FAC_SIC]
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_NAICS]    Script Date: 04/29/2010 10:24:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_NAICS]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_FAC_NAICS]
GO
/****** Object:  Table [dbo].[FACID_FAC_ELEC_ADDR]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ELEC_ADDR]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_ELEC_ADDR]
GO
/****** Object:  Table [dbo].[FACID_FAC_ALT_IDEN]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ALT_IDEN]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_ALT_IDEN]
GO
/****** Object:  Table [dbo].[FACID_ALT_NAME]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ALT_NAME]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ALT_NAME]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_ConvertRefDatumToEPSG]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_ConvertRefDatumToEPSG]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_ConvertRefDatumToEPSG]
GO
/****** Object:  Table [dbo].[FACID_FAC_DEL]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_DEL]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_DEL]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_ZipPlus]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_ZipPlus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_ZipPlus]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_PadLeadingZeroes]    Script Date: 04/29/2010 10:24:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_PadLeadingZeroes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udfs_PadLeadingZeroes]
GO
/****** Object:  Table [dbo].[FACID_FAC_PRI_GEO_LOC_DESC]    Script Date: 04/29/2010 10:24:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_PRI_GEO_LOC_DESC]
GO
/****** Object:  Table [dbo].[FACID_AFFL]    Script Date: 04/29/2010 10:24:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_AFFL]
GO
/****** Object:  Table [dbo].[FACID_FAC]    Script Date: 04/29/2010 10:24:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC]
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR]    Script Date: 04/29/2010 10:24:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_ENVR_INTR]
GO
/****** Object:  Table [dbo].[FACID_FAC_GEO_LOC_DESC]    Script Date: 04/29/2010 10:24:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_GEO_LOC_DESC]
GO
/****** Object:  Table [dbo].[FACID_SHAPE]    Script Date: 04/29/2010 10:24:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_SHAPE]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_SHAPE]
GO
/****** Object:  Table [dbo].[FACID_FAC_DTLS]    Script Date: 04/29/2010 10:24:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_DTLS]') AND type in (N'U'))
DROP TABLE [dbo].[FACID_FAC_DTLS]
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_FormatVarchar]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_FormatVarchar]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-21
-- Description:	Strips out leading and trailing spaces and converts all empty strings to NULLs
-- =============================================
CREATE FUNCTION [dbo].[udfs_FormatVarchar]
(
	-- Add the parameters for the function here
	@InputStr varchar(8000)
)
RETURNS varchar(8000)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(8000)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN ISNULL(@InputStr, '''') = '''' THEN NULL
		ELSE LTRIM(RTRIM(@InputStr))
		END

	-- Return the result of the function
	RETURN @Result

END


' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_DateOrTimeXML]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_DateOrTimeXML]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-22
-- Description:	Converts dates to XML format for date or time
-- =============================================
CREATE FUNCTION [dbo].[udfs_DateOrTimeXML] 
(
	-- Add the parameters for the function here
	@DateValue datetime
	,@IsTime bit
)
RETURNS varchar(25)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(25)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN @IsTime = 1
		THEN SUBSTRING(CONVERT(VARCHAR, @DateValue, 126),CHARINDEX(''T'', CONVERT(VARCHAR, @DateValue, 126)) + 1, LEN(CONVERT(VARCHAR, @DateValue, 126)))
		ELSE SUBSTRING(CONVERT(VARCHAR, @DateValue, 126),1,CHARINDEX(''T'', CONVERT(VARCHAR, @DateValue, 126)) - 1)
	END
	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_LookupStateName]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_LookupStateName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2009-04-06
-- Description:	Returns the state name for a passed-in state code.
-- =============================================
CREATE FUNCTION [dbo].[udfs_LookupStateName] 
(
	-- Add the parameters for the function here
	@StateCode char(2)
)
RETURNS varchar(255)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(255)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE @StateCode

		WHEN ''AK'' THEN ''Alaska''
		WHEN ''AL'' THEN ''Alabama''
		WHEN ''AR'' THEN ''Arkansas''
		WHEN ''AS'' THEN ''American Samoa''
		WHEN ''AZ'' THEN ''Arizona''
		WHEN ''CA'' THEN ''California''
		WHEN ''CO'' THEN ''Colorado''
		WHEN ''CT'' THEN ''Connecticut''
		WHEN ''DC'' THEN ''District of Columbia''
		WHEN ''DE'' THEN ''Delaware''
		WHEN ''FL'' THEN ''Florida''
		WHEN ''FM'' THEN ''Federated States of Micronesia''
		WHEN ''GA'' THEN ''Georgia''
		WHEN ''GU'' THEN ''Guam''
		WHEN ''HI'' THEN ''Hawaii''
		WHEN ''IA'' THEN ''Iowa''
		WHEN ''ID'' THEN ''Idaho''
		WHEN ''IL'' THEN ''Illinois''
		WHEN ''IN'' THEN ''Indiana''
		WHEN ''KS'' THEN ''Kansas''
		WHEN ''KY'' THEN ''Kentucky''
		WHEN ''LA'' THEN ''Louisiana''
		WHEN ''MA'' THEN ''Massachusetts''
		WHEN ''ME'' THEN ''Maine''
		WHEN ''MD'' THEN ''Maryland''
		WHEN ''MH'' THEN ''Marshall Islands''
		WHEN ''MI'' THEN ''Michigan''
		WHEN ''MN'' THEN ''Minnesota''
		WHEN ''MO'' THEN ''Missouri''
		WHEN ''MP'' THEN ''Northern Mariana Islands''
		WHEN ''MS'' THEN ''Mississippi''
		WHEN ''MT'' THEN ''Montana''
		WHEN ''NC'' THEN ''North Carolina''
		WHEN ''ND'' THEN ''North Dakota''
		WHEN ''NE'' THEN ''Nebraska''
		WHEN ''NH'' THEN ''New Hampshire''
		WHEN ''NJ'' THEN ''New Jersey''
		WHEN ''NM'' THEN ''New Mexico''
		WHEN ''NV'' THEN ''Nevada''
		WHEN ''NY'' THEN ''New York''
		WHEN ''OH'' THEN ''Ohio''
		WHEN ''OK'' THEN ''Oklahoma''
		WHEN ''OR'' THEN ''Oregon''
		WHEN ''PA'' THEN ''Pennsylvania''
		WHEN ''PR'' THEN ''Puerto Rico''
		WHEN ''PW'' THEN ''Palau''
		WHEN ''RI'' THEN ''Rhode Island''
		WHEN ''SC'' THEN ''South Carolina''
		WHEN ''SD'' THEN ''South Dakota''
		WHEN ''TN'' THEN ''Tennessee''
		WHEN ''TX'' THEN ''Texas''
		WHEN ''UT'' THEN ''Utah''
		WHEN ''VI'' THEN ''Virgin Islands''
		WHEN ''VT'' THEN ''Vermont''
		WHEN ''VA'' THEN ''Virginia''
		WHEN ''WA'' THEN ''Washington''
		WHEN ''WI'' THEN ''Wisconsin''
		WHEN ''WV'' THEN ''West Virginia''
		WHEN ''WY'' THEN ''Wyoming''
		WHEN ''AB'' THEN ''Alberta''
		WHEN ''BC'' THEN ''British Columbia''
		WHEN ''MB'' THEN ''Manitoba''
		WHEN ''NB'' THEN ''New Brunswick''
		WHEN ''NL'' THEN ''Newfoundland and Labrador''
		WHEN ''NT'' THEN ''Northwest Territories''
		WHEN ''NS'' THEN ''Nova Scotia''
		WHEN ''NU'' THEN ''Nunavut''
		WHEN ''ON'' THEN ''Ontario''
		WHEN ''PE'' THEN ''Prince Edward Island''
		WHEN ''QC'' THEN ''Quebec''
		WHEN ''SK'' THEN ''Saskatchewan''
		WHEN ''YT'' THEN ''Yukon''

	ELSE ''Undetermined''
	END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  Table [dbo].[FACID_FAC_DTLS]    Script Date: 04/29/2010 10:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_DTLS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_DTLS](
	[FAC_DTLS_ID] [varchar](40) NOT NULL,
 CONSTRAINT [PK_FAC_DTLS] PRIMARY KEY CLUSTERED 
(
	[FAC_DTLS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_ConvertRefDatumToEPSG]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_ConvertRefDatumToEPSG]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2009-08-03
-- Description:	Converts reference datum to ESPG value
-- =============================================
CREATE FUNCTION [dbo].[udfs_ConvertRefDatumToEPSG] 
(
	-- Add the parameters for the function here
	@RefDatum varchar(255)
)
RETURNS varchar(255)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(255)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE @RefDatum
		WHEN ''NAD27'' THEN ''urn:ogc:def:crs:EPSG:4267''
		WHEN ''NAD83'' THEN ''urn:ogc:def:crs:EPSG:4269''
		WHEN ''WGS84'' THEN ''urn:ogc:def:crs:EPSG:7030''
		ELSE ''Unknown''
	END

	-- Return the result of the function
	RETURN @Result

END
' 
END
GO
/****** Object:  Table [dbo].[FACID_FAC_DEL]    Script Date: 04/29/2010 10:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_DEL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_DEL](
	[FAC_SITE_IDEN_VAL] [varchar](50) NOT NULL,
	[FAC_SITE_IDEN_CONT] [varchar](255) NULL,
	[FAC_SITE_NAME] [varchar](128) NULL,
	[INFO_SYS_ACRO_NAME] [varchar](128) NULL,
	[ORIG_PART_NAME] [varchar](128) NULL,
	[DELETED_ON_DATE] [datetime] NULL,
	[LAST_UPDT_DATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FAC_SITE_IDEN_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', N'COLUMN',N'FAC_SITE_IDEN_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PK for FACID_FAC_DEL and the unique identification number used by a governmental entity to identify a facility site. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', N'COLUMN',N'FAC_SITE_IDEN_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The unique identification number used by a governmental entity to identify a facility site. (FacilitySiteIdentifierContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', N'COLUMN',N'INFO_SYS_ACRO_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL', @level2type=N'COLUMN',@level2name=N'INFO_SYS_ACRO_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', N'COLUMN',N'ORIG_PART_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL', @level2type=N'COLUMN',@level2name=N'ORIG_PART_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', N'COLUMN',N'DELETED_ON_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date when the facility was found to have been deleted from the FACID source system.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL', @level2type=N'COLUMN',@level2name=N'DELETED_ON_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_DEL', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Facility deletes table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_DEL'
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_ZipPlus]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_ZipPlus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-21
-- Description:	Takes two parameters, Zipcode and Zipplus. Returns correctly-formatted zipcode
-- =============================================
CREATE FUNCTION [dbo].[udfs_ZipPlus] 
(
	-- Add the parameters for the function here
	 @Zipcode varchar(25) = NULL
	,@Zipplus varchar(25) = NULL
)
RETURNS varchar(25)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(25)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN ISNULL(@Zipcode, '''') = '''' THEN NULL
		WHEN ISNULL(@Zipplus, '''') = '''' THEN @Zipcode
		ELSE @Zipcode + ''-'' + @Zipplus
	END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[udfs_PadLeadingZeroes]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udfs_PadLeadingZeroes]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-07-19
-- Description:	Pads a character string with leading zeros
-- =============================================
CREATE FUNCTION [dbo].[udfs_PadLeadingZeroes] 
(
	-- Add the parameters for the function here
	@StringToPad varchar(255)
,	@NumberOfChars	int
)
RETURNS varchar(255)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(255)

	-- Add the T-SQL statements to compute the return value here

	declare @nIntLen		int
	declare @NumberToPad	int

	-- Remove any leading and trailing spaces from the string to be converted

	set @StringToPad = ltrim(rtrim(@StringToPad))

	set @nIntLen = len(@StringToPad)

	if @nIntLen > @NumberOfChars
		set @NumberToPad = @nIntLen
	else
		set @NumberToPad = @NumberOfChars - @nIntLen

	SELECT @Result = right(replicate(''0'', @NumberToPad) + @StringToPad, @NumberOfChars)

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  Table [dbo].[FACID_FAC]    Script Date: 04/29/2010 10:24:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC](
	[FAC_ID] [varchar](40) NOT NULL,
	[FAC_DTLS_ID] [varchar](40) NOT NULL,
	[CONG_DIST_NUM_CODE] [varchar](50) NULL,
	[LEGI_DIST_NUM_CODE] [varchar](50) NULL,
	[HUC_CODE] [varchar](50) NULL,
	[FAC_URL_TEXT] [varchar](255) NULL,
	[DELETED_ON_DATE] [datetime] NULL,
	[FAC_ACTIVE_INDI] [varchar](1) NULL,
	[FAC_SITE_NAME] [varchar](128) NULL,
	[FED_FAC_INDI] [varchar](4) NULL,
	[FAC_SITE_IDEN_CONT] [varchar](255) NULL,
	[FAC_SITE_IDEN_VAL] [varchar](50) NOT NULL,
	[FAC_SITE_TYPE_CODE] [varchar](50) NULL,
	[FAC_SITE_TYPE_NAME] [varchar](128) NULL,
	[CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERS_AGN_IDEN] [varchar](50) NULL,
	[CODE_LST_VER_VAL] [varchar](50) NULL,
	[LOC_ADDR_TEXT] [varchar](255) NULL,
	[SUPP_LOC_TEXT] [varchar](255) NULL,
	[LOCA_NAME] [varchar](128) NULL,
	[TRIB_LAND_NAME] [varchar](128) NULL,
	[TRIB_LAND_INDI] [varchar](4) NULL,
	[LOC_DESC_TEXT] [varchar](255) NULL,
	[STA_CODE] [varchar](50) NULL,
	[STA_NAME] [varchar](128) NULL,
	[LOC_ADDR_CODE_LST_VER_VAL] [varchar](50) NULL,
	[LOC_ADDR_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[LOC_ADDR_CODE_LIST_VER_AGN_IDE] [varchar](50) NULL,
	[ADDR_POST_CODE_VAL] [varchar](50) NULL,
	[ADDR_POST_CODE_CONT] [varchar](50) NULL,
	[CTRY_CODE] [varchar](50) NULL,
	[CTRY_NAME] [varchar](128) NULL,
	[LOC_ADDR_COD_LST_VER_VAL] [varchar](50) NULL,
	[LOC_ADDR_CODE_LIST_VERS_IDE] [varchar](50) NULL,
	[LOC_ADDR_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[CNTY_CODE] [varchar](50) NULL,
	[CNTY_NAME] [varchar](128) NULL,
	[LOC_ADDR_CODE_LIST_VER_IDE] [varchar](50) NULL,
	[LOC_ADDR_COD_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[LOC_ADD_COD_LST_VER_VAL] [varchar](50) NULL,
	[MAIL_ADDR_TEXT] [varchar](255) NULL,
	[SUPP_ADDR_TEXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_STA_CODE] [varchar](50) NULL,
	[MAIL_ADDR_STA_NAME] [varchar](128) NULL,
	[MAIL_ADDR_CODE_LST_VER_VAL] [varchar](50) NULL,
	[MAIL_ADDR_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[MAIL_ADDR_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[MAIL_ADDR_ADDR_POST_CODE_VAL] [varchar](50) NULL,
	[MAIL_ADDR_ADDR_POST_CODE_CONT] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_CODE] [varchar](50) NULL,
	[MAIL_ADDR_CTRY_NAME] [varchar](128) NULL,
	[MAIL_ADDR_COD_LST_VER_VAL] [varchar](50) NULL,
	[MAIL_ADDR_CODE_LIST_VERS_IDE] [varchar](50) NULL,
	[MAIL_ADDR_COD_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[ORIG_PART_NAME] [varchar](128) NULL,
	[INFO_SYS_ACRO_NAME] [varchar](128) NULL,
	[LAST_UPDT_DATE] [datetime] NULL,
 CONSTRAINT [PK_FACILITY_ID] PRIMARY KEY CLUSTERED 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FA_MA_AD_AD_PO')
CREATE NONCLUSTERED INDEX [IX_FA_MA_AD_AD_PO] ON [dbo].[FACID_FAC] 
(
	[MAIL_ADDR_ADDR_POST_CODE_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_AD_PO_CO_VA')
CREATE NONCLUSTERED INDEX [IX_FAC_AD_PO_CO_VA] ON [dbo].[FACID_FAC] 
(
	[ADDR_POST_CODE_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_CNTY_NAME')
CREATE NONCLUSTERED INDEX [IX_FAC_CNTY_NAME] ON [dbo].[FACID_FAC] 
(
	[CNTY_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_FA_SI_ID_VA')
CREATE NONCLUSTERED INDEX [IX_FAC_FA_SI_ID_VA] ON [dbo].[FACID_FAC] 
(
	[FAC_SITE_IDEN_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_FAC_DTLS_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_FAC_DTLS_ID] ON [dbo].[FACID_FAC] 
(
	[FAC_DTLS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_FAC_SIT_NAM')
CREATE NONCLUSTERED INDEX [IX_FAC_FAC_SIT_NAM] ON [dbo].[FACID_FAC] 
(
	[FAC_SITE_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_IN_SY_AC_NA')
CREATE NONCLUSTERED INDEX [IX_FAC_IN_SY_AC_NA] ON [dbo].[FACID_FAC] 
(
	[INFO_SYS_ACRO_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_LAS_UPD_DAT')
CREATE NONCLUSTERED INDEX [IX_FAC_LAS_UPD_DAT] ON [dbo].[FACID_FAC] 
(
	[LAST_UPDT_DATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_LOCA_NAME')
CREATE NONCLUSTERED INDEX [IX_FAC_LOCA_NAME] ON [dbo].[FACID_FAC] 
(
	[LOCA_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_MA_AD_ST_CO')
CREATE NONCLUSTERED INDEX [IX_FAC_MA_AD_ST_CO] ON [dbo].[FACID_FAC] 
(
	[MAIL_ADDR_STA_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_ORI_PAR_NAM')
CREATE NONCLUSTERED INDEX [IX_FAC_ORI_PAR_NAM] ON [dbo].[FACID_FAC] 
(
	[ORIG_PART_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FAC_STA_CODE')
CREATE NONCLUSTERED INDEX [IX_FAC_STA_CODE] ON [dbo].[FACID_FAC] 
(
	[STA_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC]') AND name = N'IX_FACID_FAC_FAC_SITE_IDEN_VAL')
CREATE UNIQUE NONCLUSTERED INDEX [IX_FACID_FAC_FAC_SITE_IDEN_VAL] ON [dbo].[FACID_FAC] 
(
	[FAC_SITE_IDEN_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility sites for a partner. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_DTLS_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility sites for a partner. (FacilityDetailsId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_DTLS_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CONG_DIST_NUM_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A number representing an area within a state that a member of the House of Representatives is elected. (CongressionalDistrictNumberCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CONG_DIST_NUM_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LEGI_DIST_NUM_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A number representing an area from which senators and General Assembly members are elected. (LegislativeDistrictNumberCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LEGI_DIST_NUM_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'HUC_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The hydrologic unit code (HUC) that represents a geographic area representing part or all of a surface drainage basin, a combination of drainage basins, or a distinct hydrologic feature. (HUCCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'HUC_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_URL_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The web address where a computer user can access information about the facility. (FacilityURLText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_URL_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'DELETED_ON_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date that this facility was deleted, or null if the facility has not been deleted. (DeletedOnDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'DELETED_ON_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_ACTIVE_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A designator that indicates whether the Facility is currently considered to active. (FacilityActiveIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_ACTIVE_INDI'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_SITE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public or commercial name of a facility site (i.e., the full name that commonly appears on invoices, signs, or other business documents, or as assigned by the state when the name is ambiguous). (FacilitySiteName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_SITE_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FED_FAC_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator identifying facilities owned or operated by a federal government unit. (FederalFacilityIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FED_FAC_INDI'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_SITE_IDEN_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The unique identification number used by a governmental entity to identify a facility site. (FacilitySiteIdentifierContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_SITE_IDEN_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The unique identification number used by a governmental entity to identify a facility site. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_SITE_IDEN_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_SITE_TYPE_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the type of site a facility occupies. (FacilitySiteTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_SITE_TYPE_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'FAC_SITE_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The descriptive name for the type of site the facility occupies. (FacilitySiteTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'FAC_SITE_TYPE_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CODE_LIST_VERS_AGN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_AGN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a facility site type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The address that describes the physical (geographic) location of the front door or main entrance of a facility site, including urban-style street address or rural address. (LocationAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'SUPP_LOC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about a place, including a building name with its secondary unit and number, an industrial park name, an installation name or descriptive text where no formal address is available. (SupplementalLocationText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'SUPP_LOC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOCA_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of a city, town, village or other locality. (LocalityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOCA_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'TRIB_LAND_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of an American Indian or Alaskan native area where the location address exists. (TribalLandName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'TRIB_LAND_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'TRIB_LAND_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An indicator denoting the location address is a tribal land (TribalLandIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'TRIB_LAND_INDI'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief explanation of a location, including navigational directions and/or more descriptive information. (LocationDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'STA_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'STA_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'STA_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'STA_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LIST_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LIST_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'ADDR_POST_CODE_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'ADDR_POST_CODE_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'ADDR_POST_CODE_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'ADDR_POST_CODE_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CTRY_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CTRY_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CTRY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a primary geopolitical unit of the world. (CountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CTRY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LIST_VERS_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LIST_VERS_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CNTY_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the county. (CountyCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CNTY_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'CNTY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the county code. (CountyName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'CNTY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_CODE_LIST_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_CODE_LIST_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADDR_COD_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADDR_COD_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LOC_ADD_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a county code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LOC_ADD_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'SUPP_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CITY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_STA_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_STA_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_STA_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_ADDR_POST_CODE_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_ADDR_POST_CODE_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_ADDR_POST_CODE_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_ADDR_POST_CODE_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CTRY_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CTRY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a primary geopolitical unit of the world. (CountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CTRY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_CODE_LIST_VERS_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CODE_LIST_VERS_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'MAIL_ADDR_COD_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_COD_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'ORIG_PART_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'ORIG_PART_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'INFO_SYS_ACRO_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'INFO_SYS_ACRO_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'COLUMN',N'LAST_UPDT_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'COLUMN',@level2name=N'LAST_UPDT_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC', N'INDEX',N'IX_FACID_FAC_FAC_SITE_IDEN_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensures that each facility identifier is unique.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC', @level2type=N'INDEX',@level2name=N'IX_FACID_FAC_FAC_SITE_IDEN_VAL'
GO
/****** Object:  Table [dbo].[FACID_AFFL]    Script Date: 04/29/2010 10:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_AFFL](
	[AFFL_ID] [varchar](40) NOT NULL,
	[FAC_DTLS_ID] [varchar](40) NOT NULL,
	[AFFL_IDEN] [varchar](255) NOT NULL,
	[INDV_TITLE_TEXT] [varchar](255) NULL,
	[NAME_PREFIX_TEXT] [varchar](255) NULL,
	[INDV_FULL_NAME] [varchar](255) NULL,
	[FIRST_NAME] [varchar](128) NULL,
	[MIDDLE_NAME] [varchar](128) NULL,
	[LAST_NAME] [varchar](128) NULL,
	[NAME_SUFFIX_TEXT] [varchar](255) NULL,
	[INDV_IDEN_CONT] [varchar](255) NULL,
	[INDV_IDEN_VAL] [varchar](50) NULL,
	[ORG_FORMAL_NAME] [varchar](128) NULL,
	[ORG_IDEN_CONT] [varchar](255) NULL,
	[ORG_IDEN_VAL] [varchar](50) NULL,
	[MAIL_ADDR_TEXT] [varchar](255) NULL,
	[SUPP_ADDR_TEXT] [varchar](255) NULL,
	[MAIL_ADDR_CITY_NAME] [varchar](128) NULL,
	[STA_CODE] [varchar](50) NULL,
	[STA_NAME] [varchar](128) NULL,
	[CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERS_AGN_IDEN] [varchar](50) NULL,
	[CODE_LST_VER_VAL] [varchar](50) NULL,
	[ADDR_POST_CODE_CONT] [varchar](50) NULL,
	[ADDR_POST_CODE_VAL] [varchar](50) NULL,
	[CTRY_CODE] [varchar](50) NULL,
	[CTRY_NAME] [varchar](128) NULL,
	[CTRY_IDEN_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CTRY_IDEN_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[CTRY_IDEN_CODE_LST_VER_VAL] [varchar](50) NULL,
 CONSTRAINT [PK__AFFL] PRIMARY KEY CLUSTERED 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND name = N'IX_AFF_AD_PO_CO_VA')
CREATE NONCLUSTERED INDEX [IX_AFF_AD_PO_CO_VA] ON [dbo].[FACID_AFFL] 
(
	[ADDR_POST_CODE_VAL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND name = N'IX_AFFL_FAC_DTL_ID')
CREATE NONCLUSTERED INDEX [IX_AFFL_FAC_DTL_ID] ON [dbo].[FACID_AFFL] 
(
	[FAC_DTLS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND name = N'IX_AFFL_STA_CODE')
CREATE NONCLUSTERED INDEX [IX_AFFL_STA_CODE] ON [dbo].[FACID_AFFL] 
(
	[STA_CODE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]') AND name = N'IX_FACID_AFFL')
CREATE UNIQUE NONCLUSTERED INDEX [IX_FACID_AFFL] ON [dbo].[FACID_AFFL] 
(
	[AFFL_IDEN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'AFFL_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (AffiliateId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'FAC_DTLS_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (FacilityDetailsId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'FAC_DTLS_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'AFFL_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'INDV_TITLE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title held by a person in an organization. (IndividualTitleText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'INDV_TITLE_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'NAME_PREFIX_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that describes the title that precedes an individual''s name. (NamePrefixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'NAME_PREFIX_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'INDV_FULL_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (IndividualFullName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'INDV_FULL_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'FIRST_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (FirstName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'FIRST_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'MIDDLE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (MiddleName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'MIDDLE_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'LAST_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliate for a partner. (LastName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'LAST_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'NAME_SUFFIX_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional title that indicates lineage or professional title. (NameSuffixText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'NAME_SUFFIX_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'INDV_IDEN_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator used to uniquely identify an individual within a context. (IndividualIdentifierContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'INDV_IDEN_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'INDV_IDEN_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator used to uniquely identify an individual within a context. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'INDV_IDEN_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'ORG_FORMAL_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The legal designator (i.e. formal name) of an organization. (OrganizationFormalName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'ORG_FORMAL_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'ORG_IDEN_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator used to uniquely identify a unique business establishment within a context. (OrganizationIdentifierContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'ORG_IDEN_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'ORG_IDEN_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator used to uniquely identify a unique business establishment within a context. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'ORG_IDEN_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'MAIL_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The exact address where a mail piece is intended to be delivered, including urban-style street address, rural route, and PO Box. (MailingAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'SUPP_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information to facilitate the delivery of a mail piece, including building name, secondary units, and mail stop or local box numbers not serviced by the U.S. Postal Service. (SupplementalAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'SUPP_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'MAIL_ADDR_CITY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the city, town, or village where the mail is delivered. (MailingAddressCityName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'MAIL_ADDR_CITY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'STA_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'STA_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'STA_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'STA_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CODE_LIST_VERS_AGN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_AGN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a state code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'ADDR_POST_CODE_CONT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (AddressPostalCodeContext)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'ADDR_POST_CODE_CONT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'ADDR_POST_CODE_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'ADDR_POST_CODE_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CTRY_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CTRY_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CTRY_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A name used to identify a primary geopolitical unit of the world. (CountryName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CTRY_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CTRY_IDEN_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CTRY_IDEN_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CTRY_IDEN_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CTRY_IDEN_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL', N'COLUMN',N'CTRY_IDEN_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a country code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL', @level2type=N'COLUMN',@level2name=N'CTRY_IDEN_CODE_LST_VER_VAL'
GO
/****** Object:  Table [dbo].[FACID_POS]    Script Date: 04/29/2010 10:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_POS](
	[POS_ID] [varchar](40) NOT NULL,
	[SHAPE_ID] [varchar](40) NOT NULL,
	[ORDER_INDEX] [int] NOT NULL,
	[LATITUDE] [decimal](19, 14) NULL,
	[LONGITUDE] [decimal](19, 14) NULL,
	[ELEVATION] [decimal](19, 14) NULL,
 CONSTRAINT [PK_POS] PRIMARY KEY CLUSTERED 
(
	[POS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND name = N'IX_POS_ELEVATION')
CREATE NONCLUSTERED INDEX [IX_POS_ELEVATION] ON [dbo].[FACID_POS] 
(
	[ELEVATION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND name = N'IX_POS_LATITUDE')
CREATE NONCLUSTERED INDEX [IX_POS_LATITUDE] ON [dbo].[FACID_POS] 
(
	[LATITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND name = N'IX_POS_LONGITUDE')
CREATE NONCLUSTERED INDEX [IX_POS_LONGITUDE] ON [dbo].[FACID_POS] 
(
	[LONGITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_POS]') AND name = N'IX_POS_SHAPE_ID')
CREATE NONCLUSTERED INDEX [IX_POS_SHAPE_ID] ON [dbo].[FACID_POS] 
(
	[SHAPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'POS_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (PositionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'POS_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'SHAPE_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (ShapeId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'SHAPE_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'ORDER_INDEX'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (OrderIndex)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'ORDER_INDEX'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'LATITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Latitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'LATITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'LONGITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Longitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'LONGITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_POS', N'COLUMN',N'ELEVATION'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Elevation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_POS', @level2type=N'COLUMN',@level2name=N'ELEVATION'
GO
/****** Object:  Table [dbo].[FACID_FAC_PRI_GEO_LOC_DESC]    Script Date: 04/29/2010 10:24:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_PRI_GEO_LOC_DESC](
	[FAC_PRI_GEO_LOC_DESC_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[SRC_MAP_SCALE_NUM] [varchar](20) NULL,
	[DATA_COLL_DATE] [datetime] NULL,
	[LOC_COMM_TEXT] [varchar](255) NULL,
	[SRS_NAME] [varchar](255) NULL,
	[SRS_DIM] [varchar](10) NULL,
	[LATITUDE] [decimal](19, 14) NULL,
	[LONGITUDE] [decimal](19, 14) NULL,
	[ELEVATION] [decimal](19, 14) NULL,
	[MEAS_VAL] [varchar](50) NULL,
	[MEAS_PREC_TEXT] [varchar](50) NULL,
	[MEAS_UNIT_CODE] [varchar](50) NULL,
	[MEAS_UNIT_NAME] [varchar](50) NULL,
	[CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERS_AGN_IDEN] [varchar](50) NULL,
	[CODE_LST_VER_VAL] [varchar](50) NULL,
	[RSLT_QUAL_CODE] [varchar](50) NULL,
	[RSLT_QUAL_NAME] [varchar](128) NULL,
	[RSLT_QUAL_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[RSLT_QUAL_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[RSLT_QUAL_CODE_LST_VER_VAL] [varchar](50) NULL,
	[METH_IDEN_CODE] [varchar](50) NULL,
	[METH_NAME] [varchar](128) NULL,
	[METH_DESC_TEXT] [varchar](255) NULL,
	[METH_DEVI_TEXT] [varchar](255) NULL,
	[HORZ_COLL_METH_COD_LIS_VER_IDE] [varchar](50) NULL,
	[HOR_COL_MET_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
	[HORZ_COLL_METH_COD_LST_VER_VAL] [varchar](50) NULL,
	[GEO_REF_PT_CODE] [varchar](50) NULL,
	[GEO_REF_PT_NAME] [varchar](128) NULL,
	[GEO_REF_PT_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[GEO_REF_PT_COD_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[GEO_REF_PT_CODE_LST_VER_VAL] [varchar](50) NULL,
	[VERT_COLL_METH_METH_IDEN_CODE] [varchar](50) NULL,
	[VERT_COLL_METH_METH_NAME] [varchar](128) NULL,
	[VERT_COLL_METH_METH_DESC_TEXT] [varchar](255) NULL,
	[VERT_COLL_METH_METH_DEVI_TEXT] [varchar](255) NULL,
	[VERT_COLL_METH_COD_LST_VER_VAL] [varchar](50) NULL,
	[VERT_COLL_METH_COD_LIS_VER_IDE] [varchar](50) NULL,
	[VER_COL_MET_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
	[VERF_METH_METH_IDEN_CODE] [varchar](50) NULL,
	[VERF_METH_METH_NAME] [varchar](128) NULL,
	[VERF_METH_METH_DESC_TEXT] [varchar](255) NULL,
	[VERF_METH_METH_DEVI_TEXT] [varchar](255) NULL,
	[VERF_METH_CODE_LST_VER_VAL] [varchar](50) NULL,
	[VERF_METH_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[VERF_METH_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[CORD_DATA_SRC_CODE] [varchar](50) NULL,
	[CORD_DATA_SRC_NAME] [varchar](128) NULL,
	[CORD_DATA_SRC_CODE_LIS_VER_IDE] [varchar](50) NULL,
	[COR_DAT_SRC_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
	[CORD_DATA_SRC_CODE_LST_VER_VAL] [varchar](50) NULL,
 CONSTRAINT [PK_FAC_PR_GE_LO_DE] PRIMARY KEY CLUSTERED 
(
	[FAC_PRI_GEO_LOC_DESC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND name = N'IX_FA_PR_GE_LO_02')
CREATE NONCLUSTERED INDEX [IX_FA_PR_GE_LO_02] ON [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] 
(
	[LATITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND name = N'IX_FA_PR_GE_LO_03')
CREATE NONCLUSTERED INDEX [IX_FA_PR_GE_LO_03] ON [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] 
(
	[LONGITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND name = N'IX_FA_PR_GE_LO_04')
CREATE NONCLUSTERED INDEX [IX_FA_PR_GE_LO_04] ON [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] 
(
	[ELEVATION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]') AND name = N'IX_FA_PR_GE_LO_DE')
CREATE NONCLUSTERED INDEX [IX_FA_PR_GE_LO_DE] ON [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'FAC_PRI_GEO_LOC_DESC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityPrimaryGeographicLocationDescriptionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'FAC_PRI_GEO_LOC_DESC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'SRC_MAP_SCALE_NUM'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'DATA_COLL_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date when data were collected. (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'LOC_COMM_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about the geographic coordinates. (LocationCommentsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LOC_COMM_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'SRS_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRS_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'SRS_DIM'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (srsDimension)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRS_DIM'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'LATITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Latitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LATITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'LONGITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Longitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LONGITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'ELEVATION'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: Single geographic element for a facility, intended to refer to a single location that defines the entire facility. Must be a location of type gml:Point. (Elevation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'ELEVATION'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'MEAS_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'MEAS_PREC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The precision of the recorded value. (MeasurePrecisionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_PREC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'MEAS_UNIT_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the unit for measuring the item. (MeasureUnitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_UNIT_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'MEAS_UNIT_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the unit of measure code. (MeasureUnitName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_UNIT_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CODE_LIST_VERS_AGN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_AGN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'HORZ_COLL_METH_COD_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_COD_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'HOR_COL_MET_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HOR_COL_MET_COD_LIS_VER_AGN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'HORZ_COLL_METH_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_COD_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_COD_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_COD_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_COD_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VER_COL_MET_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VER_COL_MET_COD_LIS_VER_AGN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'COR_DAT_SRC_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'COR_DAT_SRC_COD_LIS_VER_AGN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_PRI_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_PRI_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE_LST_VER_VAL'
GO
/****** Object:  Table [dbo].[FACID_FAC_GEO_LOC_DESC]    Script Date: 04/29/2010 10:24:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_GEO_LOC_DESC](
	[FAC_GEO_LOC_DESC_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[SRC_MAP_SCALE_NUM] [varchar](20) NULL,
	[DATA_COLL_DATE] [datetime] NULL,
	[LOC_COMM_TEXT] [varchar](255) NULL,
	[SRS_NAME] [varchar](255) NULL,
	[SRS_DIM] [varchar](10) NULL,
	[ELEVATION] [decimal](19, 14) NULL,
	[LATITUDE] [decimal](19, 14) NULL,
	[LONGITUDE] [decimal](19, 14) NULL,
	[MEAS_VAL] [varchar](50) NULL,
	[MEAS_PREC_TEXT] [varchar](50) NULL,
	[MEAS_UNIT_CODE] [varchar](50) NULL,
	[MEAS_UNIT_NAME] [varchar](50) NULL,
	[CODE_LST_VER_VAL] [varchar](50) NULL,
	[CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERS_AGN_IDEN] [varchar](50) NULL,
	[RSLT_QUAL_CODE] [varchar](50) NULL,
	[RSLT_QUAL_NAME] [varchar](128) NULL,
	[RSLT_QUAL_CODE_LST_VER_VAL] [varchar](50) NULL,
	[RSLT_QUAL_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[RSLT_QUAL_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[METH_IDEN_CODE] [varchar](50) NULL,
	[METH_NAME] [varchar](128) NULL,
	[METH_DESC_TEXT] [varchar](255) NULL,
	[METH_DEVI_TEXT] [varchar](255) NULL,
	[HORZ_COLL_METH_COD_LST_VER_VAL] [varchar](50) NULL,
	[HORZ_COLL_METH_COD_LIS_VER_IDE] [varchar](50) NULL,
	[HOR_COL_MET_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
	[GEO_REF_PT_CODE] [varchar](50) NULL,
	[GEO_REF_PT_NAME] [varchar](128) NULL,
	[GEO_REF_PT_CODE_LST_VER_VAL] [varchar](50) NULL,
	[GEO_REF_PT_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[GEO_REF_PT_COD_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[VERT_COLL_METH_METH_IDEN_CODE] [varchar](50) NULL,
	[VERT_COLL_METH_METH_NAME] [varchar](128) NULL,
	[VERT_COLL_METH_METH_DESC_TEXT] [varchar](255) NULL,
	[VERT_COLL_METH_METH_DEVI_TEXT] [varchar](255) NULL,
	[VERT_COLL_METH_COD_LST_VER_VAL] [varchar](50) NULL,
	[VERT_COLL_METH_COD_LIS_VER_IDE] [varchar](50) NULL,
	[VER_COL_MET_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
	[VERF_METH_METH_IDEN_CODE] [varchar](50) NULL,
	[VERF_METH_METH_NAME] [varchar](128) NULL,
	[VERF_METH_METH_DESC_TEXT] [varchar](255) NULL,
	[VERF_METH_METH_DEVI_TEXT] [varchar](255) NULL,
	[VERF_METH_CODE_LST_VER_VAL] [varchar](50) NULL,
	[VERF_METH_CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[VERF_METH_CODE_LIS_VER_AGN_IDE] [varchar](50) NULL,
	[CORD_DATA_SRC_CODE] [varchar](50) NULL,
	[CORD_DATA_SRC_NAME] [varchar](128) NULL,
	[CORD_DATA_SRC_CODE_LST_VER_VAL] [varchar](50) NULL,
	[CORD_DATA_SRC_CODE_LIS_VER_IDE] [varchar](50) NULL,
	[COR_DAT_SRC_COD_LIS_VER_AGN_ID] [varchar](50) NULL,
 CONSTRAINT [PK_FAC_GEO_LOC_DES] PRIMARY KEY CLUSTERED 
(
	[FAC_GEO_LOC_DESC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND name = N'IX_FA_GE_LO_DE_FA')
CREATE NONCLUSTERED INDEX [IX_FA_GE_LO_DE_FA] ON [dbo].[FACID_FAC_GEO_LOC_DESC] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND name = N'IX_FAC_GE_LO_DE_EL')
CREATE NONCLUSTERED INDEX [IX_FAC_GE_LO_DE_EL] ON [dbo].[FACID_FAC_GEO_LOC_DESC] 
(
	[ELEVATION] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND name = N'IX_FAC_GE_LO_DE_LA')
CREATE NONCLUSTERED INDEX [IX_FAC_GE_LO_DE_LA] ON [dbo].[FACID_FAC_GEO_LOC_DESC] 
(
	[LATITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]') AND name = N'IX_FAC_GE_LO_DE_LO')
CREATE NONCLUSTERED INDEX [IX_FAC_GE_LO_DE_LO] ON [dbo].[FACID_FAC_GEO_LOC_DESC] 
(
	[LONGITUDE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'FAC_GEO_LOC_DESC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'FAC_GEO_LOC_DESC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'SRC_MAP_SCALE_NUM'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScaleNumber)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRC_MAP_SCALE_NUM'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'DATA_COLL_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The calendar date when data were collected. (DataCollectionDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'DATA_COLL_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'LOC_COMM_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that provides additional information about the geographic coordinates. (LocationCommentsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LOC_COMM_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'SRS_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (srsName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRS_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'SRS_DIM'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (srsDimension)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'SRS_DIM'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'ELEVATION'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Elevation)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'ELEVATION'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'LATITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Latitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LATITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'LONGITUDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Longitude)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'LONGITUDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'MEAS_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'MEAS_PREC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The precision of the recorded value. (MeasurePrecisionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_PREC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'MEAS_UNIT_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the unit for measuring the item. (MeasureUnitCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_UNIT_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'MEAS_UNIT_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the unit of measure code. (MeasureUnitName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'MEAS_UNIT_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CODE_LIST_VERS_AGN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a measurement unit code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_AGN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A code used to identify any qualifying issues that affect the results. (ResultQualifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the result code of any qualifying issues that affect the results. (ResultQualifierName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'RSLT_QUAL_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a result qualifier code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'RSLT_QUAL_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'HORZ_COLL_METH_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'HORZ_COLL_METH_COD_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HORZ_COLL_METH_COD_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'HOR_COL_MET_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'HOR_COL_MET_COD_LIS_VER_AGN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the place for which geographic coordinates were established. (GeographicReferencePointCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The text that identifies the place for which geographic coordinates were established. (GeographicReferencePointName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'GEO_REF_PT_COD_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a geographic reference point code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'GEO_REF_PT_COD_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_COD_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_COD_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERT_COLL_METH_COD_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERT_COLL_METH_COD_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VER_COL_MET_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VER_COL_MET_COD_LIS_VER_AGN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_IDEN_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The identification number or code assigned by the method publisher. (MethodIdentifierCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_IDEN_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The title of the method that appears on the method from the organization that published it. (MethodName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_DESC_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A brief summary that provides general information about the method. (MethodDescriptionText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_DESC_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_METH_DEVI_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text that identifies any deviations from the published method reference. (MethodDeviationsText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_METH_DEVI_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'VERF_METH_CODE_LIS_VER_AGN_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a reference method code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'VERF_METH_CODE_LIS_VER_AGN_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the party responsible for providing the latitude and longitude coordinates. (CoordinateDataSourceName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE_LST_VER_VAL'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'CORD_DATA_SRC_CODE_LIS_VER_IDE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'CORD_DATA_SRC_CODE_LIS_VER_IDE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_GEO_LOC_DESC', N'COLUMN',N'COR_DAT_SRC_COD_LIS_VER_AGN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide a coordinate data source type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_GEO_LOC_DESC', @level2type=N'COLUMN',@level2name=N'COR_DAT_SRC_COD_LIS_VER_AGN_ID'
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_SIC]    Script Date: 04/29/2010 10:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_SIC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_FAC_SIC](
	[FAC_FAC_SIC_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[SIC_CODE] [varchar](50) NULL,
	[SIC_PRI_INDI] [varchar](9) NULL,
 CONSTRAINT [PK_FAC_FAC_SIC] PRIMARY KEY CLUSTERED 
(
	[FAC_FAC_SIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_SIC]') AND name = N'IX_FAC_FA_SI_FA_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_FA_SI_FA_ID] ON [dbo].[FACID_FAC_FAC_SIC] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_SIC', N'COLUMN',N'FAC_FAC_SIC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more SIC Codes. (FacilityFacilitySICId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_SIC', @level2type=N'COLUMN',@level2name=N'FAC_FAC_SIC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_SIC', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more SIC Codes. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_SIC', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_SIC', N'COLUMN',N'SIC_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the economic activity of a company. (SICCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_SIC', @level2type=N'COLUMN',@level2name=N'SIC_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_SIC', N'COLUMN',N'SIC_PRI_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_SIC', @level2type=N'COLUMN',@level2name=N'SIC_PRI_INDI'
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_NAICS]    Script Date: 04/29/2010 10:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_NAICS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_FAC_NAICS](
	[FAC_FAC_NAICS_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[FAC_NAICS_CODE] [varchar](50) NULL,
	[FAC_NAICS_PRI_INDI] [varchar](9) NULL,
 CONSTRAINT [PK_FAC_FAC_NAICS] PRIMARY KEY CLUSTERED 
(
	[FAC_FAC_NAICS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_NAICS]') AND name = N'IX_FAC_FA_NA_FA_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_FA_NA_FA_ID] ON [dbo].[FACID_FAC_FAC_NAICS] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_NAICS', N'COLUMN',N'FAC_FAC_NAICS_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more NAICS codes. (FacilityFacilityNAICSId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_FAC_NAICS_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_NAICS', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more NAICS codes. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_NAICS', N'COLUMN',N'FAC_NAICS_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_NAICS_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_NAICS', N'COLUMN',N'FAC_NAICS_PRI_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_NAICS_PRI_INDI'
GO
/****** Object:  Table [dbo].[FACID_FAC_ELEC_ADDR]    Script Date: 04/29/2010 10:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ELEC_ADDR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_ELEC_ADDR](
	[FAC_ELEC_ADDR_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[ELEC_ADDR_TEXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](8) NULL,
 CONSTRAINT [PK_FAC_ELEC_ADDR] PRIMARY KEY CLUSTERED 
(
	[FAC_ELEC_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ELEC_ADDR]') AND name = N'IX_FAC_EL_AD_FA_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_EL_AD_FA_ID] ON [dbo].[FACID_FAC_ELEC_ADDR] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ELEC_ADDR', N'COLUMN',N'FAC_ELEC_ADDR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (FacilityElectronicAddressId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'FAC_ELEC_ADDR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ELEC_ADDR', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
/****** Object:  Table [dbo].[FACID_FAC_ALT_IDEN]    Script Date: 04/29/2010 10:24:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ALT_IDEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_ALT_IDEN](
	[FAC_ALT_IDEN_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[ALT_IDEN_IDEN] [varchar](50) NULL,
	[ALT_IDEN_TYPE_TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_FAC_ALT_IDEN] PRIMARY KEY CLUSTERED 
(
	[FAC_ALT_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ALT_IDEN]') AND name = N'IX_FAC_AL_ID_FA_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_AL_ID_FA_ID] ON [dbo].[FACID_FAC_ALT_IDEN] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ALT_IDEN', N'COLUMN',N'FAC_ALT_IDEN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative identifiers. (FacilityAlternativeIdentificationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'FAC_ALT_IDEN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ALT_IDEN', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative identifiers. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ALT_IDEN', N'COLUMN',N'ALT_IDEN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ALT_IDEN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_ALT_IDEN', N'COLUMN',N'ALT_IDEN_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ALT_IDEN_TYPE_TEXT'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR]    Script Date: 04/29/2010 10:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR](
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_IDEN] [varchar](50) NOT NULL,
	[ENVR_INTR_TYPE_TEXT] [varchar](255) NOT NULL,
	[ENVR_INTR_START_DATE] [datetime] NULL,
	[ENVR_INTR_START_DATE_QUAL_TEXT] [varchar](255) NULL,
	[ENVR_INTR_END_DATE] [datetime] NULL,
	[ENVR_INTR_END_DATE_QUAL_TEXT] [varchar](255) NULL,
	[ENVR_INTR_ACTIVE_INDI] [varchar](1) NULL,
	[ENVR_INTR_URL_TEXT] [varchar](255) NULL,
	[LAST_UPDT_DATE] [datetime] NULL,
	[INFO_SYS_ACRO_NAME] [varchar](128) NULL,
	[ORIG_PART_NAME] [varchar](128) NULL,
	[AGN_TYPE_CODE] [varchar](50) NULL,
	[AGN_TYPE_NAME] [varchar](128) NULL,
	[CODE_LIST_VERS_IDEN] [varchar](50) NULL,
	[CODE_LIST_VERS_AGN_IDEN] [varchar](50) NULL,
	[CODE_LST_VER_VAL] [varchar](50) NULL,
 CONSTRAINT [PK_ENVR_INTR] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND name = N'IX_EN_IN_IN_SY_AC')
CREATE NONCLUSTERED INDEX [IX_EN_IN_IN_SY_AC] ON [dbo].[FACID_ENVR_INTR] 
(
	[INFO_SYS_ACRO_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND name = N'IX_ENV_IN_LA_UP_DA')
CREATE NONCLUSTERED INDEX [IX_ENV_IN_LA_UP_DA] ON [dbo].[FACID_ENVR_INTR] 
(
	[LAST_UPDT_DATE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND name = N'IX_ENV_IN_OR_PA_NA')
CREATE NONCLUSTERED INDEX [IX_ENV_IN_OR_PA_NA] ON [dbo].[FACID_ENVR_INTR] 
(
	[ORIG_PART_NAME] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]') AND name = N'IX_ENVR_INT_FAC_ID')
CREATE NONCLUSTERED INDEX [IX_ENVR_INT_FAC_ID] ON [dbo].[FACID_ENVR_INTR] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more environmental interests. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more environmental interests. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A designator, such as a permit number, assigned by an information management system that is used to identify an environmental interest (e.g. permit, etc.) for a partner. (EnvironmentalInterestIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The environmental permit or regulatory program that applies to the facility site. (EnvironmentalInterestTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_TYPE_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_START_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the agency became interested in the facility site for a particular environmental interest type. (EnvironmentalInterestStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_START_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_START_DATE_QUAL_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest start date. (EnvironmentalInterestStartDateQualifierText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_START_DATE_QUAL_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_END_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date the agency ceased to be interested in the facility site for a particular environmental interest type. (EnvironmentalInterestEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_END_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_END_DATE_QUAL_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The qualifier that specifies the meaning of  the date being used as an approximation for the environmental interest end date. (EnvironmentalInterestEndDateQualifierText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_END_DATE_QUAL_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_ACTIVE_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A designator that indicates whether the Environmental Interest is currently considered to active. (EnvironmentalInterestActiveIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ACTIVE_INDI'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ENVR_INTR_URL_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The web address where a computer user can access information about the facility. (EnvironmentalInterestURLText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_URL_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'LAST_UPDT_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A value corresponding to the date the facility site or environmental interest was added to the source system or the date the partner last recorded a change to the data. (LastUpdatedDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'LAST_UPDT_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'INFO_SYS_ACRO_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The abbreviated name that represents the name of an information management system for an environmental program. (InformationSystemAcronymName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'INFO_SYS_ACRO_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'ORIG_PART_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the partner that originally provided the exchanged facility site or environmental interest data. (OriginatingPartnerName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'ORIG_PART_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'AGN_TYPE_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a type of federal, state, or local agency. (AgencyTypeCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'AGN_TYPE_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'AGN_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A description of the agency type code. (AgencyTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'AGN_TYPE_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'CODE_LIST_VERS_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'CODE_LIST_VERS_AGN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (CodeListVersionAgencyIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'CODE_LIST_VERS_AGN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR', N'COLUMN',N'CODE_LST_VER_VAL'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A designator specifying the code set used to provide an agency type code. Can be used to identify the URL of a source that defines the set of currently approved permitted values. (Value)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR', @level2type=N'COLUMN',@level2name=N'CODE_LST_VER_VAL'
GO
/****** Object:  Table [dbo].[FACID_ALT_NAME]    Script Date: 04/29/2010 10:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ALT_NAME]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ALT_NAME](
	[ALT_NAME_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[ALT_NAME_TEXT] [varchar](255) NOT NULL,
	[ALT_NAME_TYPE_TEXT] [varchar](255) NOT NULL,
 CONSTRAINT [PK_ALT_NAME] PRIMARY KEY CLUSTERED 
(
	[ALT_NAME_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ALT_NAME]') AND name = N'IX_ALT_NAME_FAC_ID')
CREATE NONCLUSTERED INDEX [IX_ALT_NAME_FAC_ID] ON [dbo].[FACID_ALT_NAME] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ALT_NAME', N'COLUMN',N'ALT_NAME_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative names. (AlternativeNameId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ALT_NAME', @level2type=N'COLUMN',@level2name=N'ALT_NAME_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ALT_NAME', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative names. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ALT_NAME', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ALT_NAME', N'COLUMN',N'ALT_NAME_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An alternative, historic or program specific name for the facility site. (AlternativeNameText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ALT_NAME', @level2type=N'COLUMN',@level2name=N'ALT_NAME_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ALT_NAME', N'COLUMN',N'ALT_NAME_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the alternative, historical, or program-specific name for the facility site (e.g., primary, legal, historical, local). (AlternativeNameTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ALT_NAME', @level2type=N'COLUMN',@level2name=N'ALT_NAME_TYPE_TEXT'
GO
/****** Object:  Table [dbo].[FACID_FAC_FAC_AFFL]    Script Date: 04/29/2010 10:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_FAC_FAC_AFFL](
	[FAC_FAC_AFFL_ID] [varchar](40) NOT NULL,
	[FAC_ID] [varchar](40) NOT NULL,
	[AFFL_IDEN] [varchar](255) NOT NULL,
	[AFFL_TYPE_TEXT] [varchar](255) NULL,
	[AFFL_START_DATE] [datetime] NULL,
	[AFFL_END_DATE] [datetime] NULL,
	[AFFL_STAT_TEXT] [varchar](4) NULL,
	[AFFL_STAT_DETR_DATE] [datetime] NULL,
 CONSTRAINT [PK_FAC_FAC_AFFL] PRIMARY KEY CLUSTERED 
(
	[FAC_FAC_AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]') AND name = N'IX_FAC_FA_AF_FA_ID')
CREATE NONCLUSTERED INDEX [IX_FAC_FA_AF_FA_ID] ON [dbo].[FACID_FAC_FAC_AFFL] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'FAC_FAC_AFFL_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliations. (FacilityFacilityAffiliationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'FAC_FAC_AFFL_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'FAC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliations. (FacilityId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'FAC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_TYPE_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_START_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_START_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_END_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_END_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_STAT_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_STAT_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_FAC_FAC_AFFL', N'COLUMN',N'AFFL_STAT_DETR_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_FAC_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_STAT_DETR_DATE'
GO
/****** Object:  Table [dbo].[FACID_TELEPHONIC]    Script Date: 04/29/2010 10:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_TELEPHONIC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_TELEPHONIC](
	[TELEPHONIC_ID] [varchar](40) NOT NULL,
	[AFFL_ID] [varchar](40) NOT NULL,
	[TELE_NUM_TEXT] [varchar](20) NULL,
	[TELE_NUM_TYPE_NAME] [varchar](128) NULL,
	[TELE_EXT_NUM_TEXT] [varchar](20) NULL,
 CONSTRAINT [PK_TELEPHONIC] PRIMARY KEY CLUSTERED 
(
	[TELEPHONIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_TELEPHONIC]') AND name = N'IX_TELEPHO_AFFL_ID')
CREATE NONCLUSTERED INDEX [IX_TELEPHO_AFFL_ID] ON [dbo].[FACID_TELEPHONIC] 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_TELEPHONIC', N'COLUMN',N'TELEPHONIC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more telephone numbers. (TelephonicId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_TELEPHONIC', @level2type=N'COLUMN',@level2name=N'TELEPHONIC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_TELEPHONIC', N'COLUMN',N'AFFL_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more telephone numbers. (AffiliateId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_TELEPHONIC', @level2type=N'COLUMN',@level2name=N'AFFL_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_TELEPHONIC', N'COLUMN',N'TELE_NUM_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number that identifies a particular telephone connection. (TelephoneNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_TELEPHONIC', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_TELEPHONIC', N'COLUMN',N'TELE_NUM_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that describes a telephone number type. (TelephoneNumberTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_TELEPHONIC', @level2type=N'COLUMN',@level2name=N'TELE_NUM_TYPE_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_TELEPHONIC', N'COLUMN',N'TELE_EXT_NUM_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_TELEPHONIC', @level2type=N'COLUMN',@level2name=N'TELE_EXT_NUM_TEXT'
GO
/****** Object:  Table [dbo].[FACID_AFFL_ELEC_ADDR]    Script Date: 04/29/2010 10:24:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL_ELEC_ADDR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_AFFL_ELEC_ADDR](
	[AFFL_ELEC_ADDR_ID] [varchar](40) NOT NULL,
	[AFFL_ID] [varchar](40) NOT NULL,
	[ELEC_ADDR_TEXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](8) NULL,
 CONSTRAINT [PK_AFFL_ELEC_ADDR] PRIMARY KEY CLUSTERED 
(
	[AFFL_ELEC_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_AFFL_ELEC_ADDR]') AND name = N'IX_AFF_EL_AD_AF_ID')
CREATE NONCLUSTERED INDEX [IX_AFF_EL_AD_AF_ID] ON [dbo].[FACID_AFFL_ELEC_ADDR] 
(
	[AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL_ELEC_ADDR', N'COLUMN',N'AFFL_ELEC_ADDR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (AffiliateElectronicAddressId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'AFFL_ELEC_ADDR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL_ELEC_ADDR', N'COLUMN',N'AFFL_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (AffiliateId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'AFFL_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_AFFL_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_AFFL_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_AFFL]    Script Date: 04/29/2010 10:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL](
	[ENVR_INTR_FAC_AFFL_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[AFFL_IDEN] [varchar](255) NOT NULL,
	[AFFL_TYPE_TEXT] [varchar](255) NULL,
	[AFFL_START_DATE] [datetime] NULL,
	[AFFL_END_DATE] [datetime] NULL,
	[AFFL_STAT_TEXT] [varchar](4) NULL,
	[AFFL_STAT_DETR_DATE] [datetime] NULL,
 CONSTRAINT [PK_ENV_INT_FAC_AFF] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_FAC_AFFL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]') AND name = N'IX_EN_IN_FA_AF_EN')
CREATE NONCLUSTERED INDEX [IX_EN_IN_FA_AF_EN] ON [dbo].[FACID_ENVR_INTR_FAC_AFFL] 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'ENVR_INTR_FAC_AFFL_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliations. (EnvironmentalInterestFacilityAffiliationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_FAC_AFFL_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more affiliations. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A number used to uniquely identify a Affiliate, which contains data for one individual or organization. (AffiliateIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that describes the capacity or function that an organization or individual serves; or the relationship between an individual or organization and a project or action. (AffiliationTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_TYPE_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_START_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action began. (AffiliationStartDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_START_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_END_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the affiliation between the organization or individual and the facility, project, or action ended. (AffiliationEndDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_END_DATE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_STAT_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The status of an affiliation between an individual or organization and a facility, project, or action. (AffiliationStatusText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_STAT_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_AFFL', N'COLUMN',N'AFFL_STAT_DETR_DATE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date on which the status of an affiliation between an individual or organization and a facility, project, or action is determined. (AffiliationStatusDetermineDate)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_AFFL', @level2type=N'COLUMN',@level2name=N'AFFL_STAT_DETR_DATE'
GO
/****** Object:  Table [dbo].[FACID_SHAPE]    Script Date: 04/29/2010 10:24:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_SHAPE]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_SHAPE](
	[SHAPE_ID] [varchar](40) NOT NULL,
	[FAC_GEO_LOC_DESC_ID] [varchar](40) NOT NULL,
	[TYPE] [varchar](10) NOT NULL,
	[SRS_NAME] [varchar](255) NULL,
	[SRS_DIM] [varchar](10) NULL,
 CONSTRAINT [PK_SHAPE] PRIMARY KEY CLUSTERED 
(
	[SHAPE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_SHAPE]') AND name = N'IX_SH_FA_GE_LO_DE')
CREATE NONCLUSTERED INDEX [IX_SH_FA_GE_LO_DE] ON [dbo].[FACID_SHAPE] 
(
	[FAC_GEO_LOC_DESC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_SHAPE', N'COLUMN',N'SHAPE_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (ShapeId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_SHAPE', @level2type=N'COLUMN',@level2name=N'SHAPE_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_SHAPE', N'COLUMN',N'FAC_GEO_LOC_DESC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (FacilityGeographicLocationDescriptionId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_SHAPE', @level2type=N'COLUMN',@level2name=N'FAC_GEO_LOC_DESC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_SHAPE', N'COLUMN',N'TYPE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (Type)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_SHAPE', @level2type=N'COLUMN',@level2name=N'TYPE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_SHAPE', N'COLUMN',N'SRS_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (srsName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_SHAPE', @level2type=N'COLUMN',@level2name=N'SRS_NAME'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_SHAPE', N'COLUMN',N'SRS_DIM'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more facility locations. (srsDimension)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_SHAPE', @level2type=N'COLUMN',@level2name=N'SRS_DIM'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_ELEC_ADDR]    Script Date: 04/29/2010 10:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ELEC_ADDR]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR_ELEC_ADDR](
	[ENVR_INTR_ELEC_ADDR_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[ELEC_ADDR_TEXT] [varchar](255) NULL,
	[ELEC_ADDR_TYPE_NAME] [varchar](8) NULL,
 CONSTRAINT [PK_ENV_INT_ELE_ADD] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_ELEC_ADDR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ELEC_ADDR]') AND name = N'IX_EN_IN_EL_AD_EN')
CREATE NONCLUSTERED INDEX [IX_EN_IN_EL_AD_EN] ON [dbo].[FACID_ENVR_INTR_ELEC_ADDR] 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ELEC_ADDR', N'COLUMN',N'ENVR_INTR_ELEC_ADDR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (EnvironmentalInterestElectronicAddressId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ELEC_ADDR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ELEC_ADDR', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TEXT'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ELEC_ADDR', N'COLUMN',N'ELEC_ADDR_TYPE_NAME'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more electronic addresses. (ElectronicAddressTypeName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ELEC_ADDR', @level2type=N'COLUMN',@level2name=N'ELEC_ADDR_TYPE_NAME'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_ALT_IDEN]    Script Date: 04/29/2010 10:24:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ALT_IDEN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR_ALT_IDEN](
	[ENVR_INTR_ALT_IDEN_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[ALT_IDEN_IDEN] [varchar](50) NULL,
	[ALT_IDEN_TYPE_TEXT] [varchar](255) NULL,
 CONSTRAINT [PK_ENV_INT_ALT_IDE] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_ALT_IDEN_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ALT_IDEN]') AND name = N'IX_EN_IN_AL_ID_EN')
CREATE NONCLUSTERED INDEX [IX_EN_IN_AL_ID_EN] ON [dbo].[FACID_ENVR_INTR_ALT_IDEN] 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ALT_IDEN', N'COLUMN',N'ENVR_INTR_ALT_IDEN_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestAlternativeIdentificationId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ALT_IDEN_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ALT_IDEN', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more alternative identifiers. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ALT_IDEN', N'COLUMN',N'ALT_IDEN_IDEN'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'An alternative, historic or program specific identifier for the facility site or environmental interest. (AlternativeIdentificationIdentifier)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ALT_IDEN_IDEN'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_ALT_IDEN', N'COLUMN',N'ALT_IDEN_TYPE_TEXT'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The type of the alternative, historical, or program-specific identifier for the facility site or environmental interest.  (AlternativeIdentificationTypeText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_ALT_IDEN', @level2type=N'COLUMN',@level2name=N'ALT_IDEN_TYPE_TEXT'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_SIC]    Script Date: 04/29/2010 10:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_SIC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR_FAC_SIC](
	[ENVR_INTR_FAC_SIC_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[SIC_CODE] [varchar](50) NULL,
	[SIC_PRI_INDI] [varchar](9) NULL,
 CONSTRAINT [PK_ENV_INT_FAC_SIC] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_FAC_SIC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_SIC]') AND name = N'IX_EN_IN_FA_SI_EN')
CREATE NONCLUSTERED INDEX [IX_EN_IN_FA_SI_EN] ON [dbo].[FACID_ENVR_INTR_FAC_SIC] 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_SIC', N'COLUMN',N'ENVR_INTR_FAC_SIC_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more SIC Codes. (EnvironmentalInterestFacilitySICId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_SIC', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_FAC_SIC_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_SIC', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more SIC Codes. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_SIC', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_SIC', N'COLUMN',N'SIC_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents the economic activity of a company. (SICCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_SIC', @level2type=N'COLUMN',@level2name=N'SIC_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_SIC', N'COLUMN',N'SIC_PRI_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that indicates whether the associated SIC Code represents the primary activity occurring at the facility site. (SICPrimaryIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_SIC', @level2type=N'COLUMN',@level2name=N'SIC_PRI_INDI'
GO
/****** Object:  Table [dbo].[FACID_ENVR_INTR_FAC_NAICS]    Script Date: 04/29/2010 10:24:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_NAICS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FACID_ENVR_INTR_FAC_NAICS](
	[ENVR_INTR_FAC_NAICS_ID] [varchar](40) NOT NULL,
	[ENVR_INTR_ID] [varchar](40) NOT NULL,
	[FAC_NAICS_CODE] [varchar](50) NULL,
	[FAC_NAICS_PRI_INDI] [varchar](9) NULL,
 CONSTRAINT [PK_ENV_INT_FAC_NAI] PRIMARY KEY CLUSTERED 
(
	[ENVR_INTR_FAC_NAICS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_NAICS]') AND name = N'IX_EN_IN_FA_NA_EN')
CREATE NONCLUSTERED INDEX [IX_EN_IN_FA_NA_EN] ON [dbo].[FACID_ENVR_INTR_FAC_NAICS] 
(
	[ENVR_INTR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_NAICS', N'COLUMN',N'ENVR_INTR_FAC_NAICS_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more NAICS codes. (EnvironmentalInterestFacilityNAICSId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_FAC_NAICS_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_NAICS', N'COLUMN',N'ENVR_INTR_ID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent: A container for one or more NAICS codes. (EnvironmentalInterestId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'ENVR_INTR_ID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_NAICS', N'COLUMN',N'FAC_NAICS_CODE'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The code that represents a subdivision of an industry that accommodates user needs in the United States. (FacilityNAICSCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_NAICS_CODE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'FACID_ENVR_INTR_FAC_NAICS', N'COLUMN',N'FAC_NAICS_PRI_INDI'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name that indicates whether the associated NAICS Code represents the primary activity occurring at the facility site. (FacilityNAICSPrimaryIndicator)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FACID_ENVR_INTR_FAC_NAICS', @level2type=N'COLUMN',@level2name=N'FAC_NAICS_PRI_INDI'
GO
/****** Object:  ForeignKey [FK_AFFL_FAC_DTLS]    Script Date: 04/29/2010 10:24:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AFFL_FAC_DTLS]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_AFFL]'))
ALTER TABLE [dbo].[FACID_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_AFFL_FAC_DTLS] FOREIGN KEY([FAC_DTLS_ID])
REFERENCES [dbo].[FACID_FAC_DTLS] ([FAC_DTLS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_AFFL] CHECK CONSTRAINT [FK_AFFL_FAC_DTLS]
GO
/****** Object:  ForeignKey [FK_AFF_ELE_ADD_AFF]    Script Date: 04/29/2010 10:24:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AFF_ELE_ADD_AFF]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_AFFL_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_AFFL_ELEC_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_AFF_ELE_ADD_AFF] FOREIGN KEY([AFFL_ID])
REFERENCES [dbo].[FACID_AFFL] ([AFFL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_AFFL_ELEC_ADDR] CHECK CONSTRAINT [FK_AFF_ELE_ADD_AFF]
GO
/****** Object:  ForeignKey [FK_ALT_NAME_FAC]    Script Date: 04/29/2010 10:24:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ALT_NAME_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ALT_NAME]'))
ALTER TABLE [dbo].[FACID_ALT_NAME]  WITH CHECK ADD  CONSTRAINT [FK_ALT_NAME_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ALT_NAME] CHECK CONSTRAINT [FK_ALT_NAME_FAC]
GO
/****** Object:  ForeignKey [FK_ENVR_INTR_FAC]    Script Date: 04/29/2010 10:24:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ENVR_INTR_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR]  WITH CHECK ADD  CONSTRAINT [FK_ENVR_INTR_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR] CHECK CONSTRAINT [FK_ENVR_INTR_FAC]
GO
/****** Object:  ForeignKey [FK_EN_IN_AL_ID_EN]    Script Date: 04/29/2010 10:24:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_AL_ID_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ALT_IDEN]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_ALT_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_EN_IN_AL_ID_EN] FOREIGN KEY([ENVR_INTR_ID])
REFERENCES [dbo].[FACID_ENVR_INTR] ([ENVR_INTR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_ALT_IDEN] CHECK CONSTRAINT [FK_EN_IN_AL_ID_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_EL_AD_EN]    Script Date: 04/29/2010 10:24:30 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_EL_AD_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_ELEC_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_EN_IN_EL_AD_EN] FOREIGN KEY([ENVR_INTR_ID])
REFERENCES [dbo].[FACID_ENVR_INTR] ([ENVR_INTR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_ELEC_ADDR] CHECK CONSTRAINT [FK_EN_IN_EL_AD_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_AF_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_AF_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_EN_IN_FA_AF_EN] FOREIGN KEY([ENVR_INTR_ID])
REFERENCES [dbo].[FACID_ENVR_INTR] ([ENVR_INTR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL] CHECK CONSTRAINT [FK_EN_IN_FA_AF_EN]
GO
/****** Object:  ForeignKey [FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]    Script Date: 04/29/2010 10:24:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL] FOREIGN KEY([AFFL_IDEN])
REFERENCES [dbo].[FACID_AFFL] ([AFFL_IDEN])
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_AFFL] CHECK CONSTRAINT [FK_FACID_ENVR_INTR_FAC_AFFL_FACID_AFFL]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_NA_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_NA_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_NAICS]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_EN_IN_FA_NA_EN] FOREIGN KEY([ENVR_INTR_ID])
REFERENCES [dbo].[FACID_ENVR_INTR] ([ENVR_INTR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_NAICS] CHECK CONSTRAINT [FK_EN_IN_FA_NA_EN]
GO
/****** Object:  ForeignKey [FK_EN_IN_FA_SI_EN]    Script Date: 04/29/2010 10:24:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EN_IN_FA_SI_EN]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_ENVR_INTR_FAC_SIC]'))
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_SIC]  WITH CHECK ADD  CONSTRAINT [FK_EN_IN_FA_SI_EN] FOREIGN KEY([ENVR_INTR_ID])
REFERENCES [dbo].[FACID_ENVR_INTR] ([ENVR_INTR_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_ENVR_INTR_FAC_SIC] CHECK CONSTRAINT [FK_EN_IN_FA_SI_EN]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_DTLS]    Script Date: 04/29/2010 10:24:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_DTLS]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC]'))
ALTER TABLE [dbo].[FACID_FAC]  WITH CHECK ADD  CONSTRAINT [FK_FAC_FAC_DTLS] FOREIGN KEY([FAC_DTLS_ID])
REFERENCES [dbo].[FACID_FAC_DTLS] ([FAC_DTLS_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC] CHECK CONSTRAINT [FK_FAC_FAC_DTLS]
GO
/****** Object:  ForeignKey [FK_FAC_ALT_IDE_FAC]    Script Date: 04/29/2010 10:24:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_ALT_IDE_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ALT_IDEN]'))
ALTER TABLE [dbo].[FACID_FAC_ALT_IDEN]  WITH CHECK ADD  CONSTRAINT [FK_FAC_ALT_IDE_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_ALT_IDEN] CHECK CONSTRAINT [FK_FAC_ALT_IDE_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_ELE_ADD_FAC]    Script Date: 04/29/2010 10:24:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_ELE_ADD_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_ELEC_ADDR]'))
ALTER TABLE [dbo].[FACID_FAC_ELEC_ADDR]  WITH CHECK ADD  CONSTRAINT [FK_FAC_ELE_ADD_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_ELEC_ADDR] CHECK CONSTRAINT [FK_FAC_ELE_ADD_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_AFF_FAC]    Script Date: 04/29/2010 10:24:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_AFF_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_FAC_FAC_AFF_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL] CHECK CONSTRAINT [FK_FAC_FAC_AFF_FAC]
GO
/****** Object:  ForeignKey [FK_FACID_FAC_FAC_AFFL_FACID_AFFL]    Script Date: 04/29/2010 10:24:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACID_FAC_FAC_AFFL_FACID_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_AFFL]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL]  WITH CHECK ADD  CONSTRAINT [FK_FACID_FAC_FAC_AFFL_FACID_AFFL] FOREIGN KEY([AFFL_IDEN])
REFERENCES [dbo].[FACID_AFFL] ([AFFL_IDEN])
GO
ALTER TABLE [dbo].[FACID_FAC_FAC_AFFL] CHECK CONSTRAINT [FK_FACID_FAC_FAC_AFFL_FACID_AFFL]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_NAI_FAC]    Script Date: 04/29/2010 10:24:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_NAI_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_NAICS]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_FAC_FAC_NAI_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_FAC_NAICS] CHECK CONSTRAINT [FK_FAC_FAC_NAI_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_FAC_SIC_FAC]    Script Date: 04/29/2010 10:24:38 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_FAC_SIC_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_FAC_SIC]'))
ALTER TABLE [dbo].[FACID_FAC_FAC_SIC]  WITH CHECK ADD  CONSTRAINT [FK_FAC_FAC_SIC_FAC] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_FAC_SIC] CHECK CONSTRAINT [FK_FAC_FAC_SIC_FAC]
GO
/****** Object:  ForeignKey [FK_FAC_GE_LO_DE_FA]    Script Date: 04/29/2010 10:24:40 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_GE_LO_DE_FA]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_GEO_LOC_DESC]'))
ALTER TABLE [dbo].[FACID_FAC_GEO_LOC_DESC]  WITH CHECK ADD  CONSTRAINT [FK_FAC_GE_LO_DE_FA] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_GEO_LOC_DESC] CHECK CONSTRAINT [FK_FAC_GE_LO_DE_FA]
GO
/****** Object:  ForeignKey [FK_FA_PR_GE_LO_DE]    Script Date: 04/29/2010 10:24:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FA_PR_GE_LO_DE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_FAC_PRI_GEO_LOC_DESC]'))
ALTER TABLE [dbo].[FACID_FAC_PRI_GEO_LOC_DESC]  WITH CHECK ADD  CONSTRAINT [FK_FA_PR_GE_LO_DE] FOREIGN KEY([FAC_ID])
REFERENCES [dbo].[FACID_FAC] ([FAC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_FAC_PRI_GEO_LOC_DESC] CHECK CONSTRAINT [FK_FA_PR_GE_LO_DE]
GO
/****** Object:  ForeignKey [FK_POS_SHAPE]    Script Date: 04/29/2010 10:24:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_POS_SHAPE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_POS]'))
ALTER TABLE [dbo].[FACID_POS]  WITH CHECK ADD  CONSTRAINT [FK_POS_SHAPE] FOREIGN KEY([SHAPE_ID])
REFERENCES [dbo].[FACID_SHAPE] ([SHAPE_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_POS] CHECK CONSTRAINT [FK_POS_SHAPE]
GO
/****** Object:  ForeignKey [FK_SHA_FA_GE_LO_DE]    Script Date: 04/29/2010 10:24:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SHA_FA_GE_LO_DE]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_SHAPE]'))
ALTER TABLE [dbo].[FACID_SHAPE]  WITH CHECK ADD  CONSTRAINT [FK_SHA_FA_GE_LO_DE] FOREIGN KEY([FAC_GEO_LOC_DESC_ID])
REFERENCES [dbo].[FACID_FAC_GEO_LOC_DESC] ([FAC_GEO_LOC_DESC_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_SHAPE] CHECK CONSTRAINT [FK_SHA_FA_GE_LO_DE]
GO
/****** Object:  ForeignKey [FK_TELEPHONIC_AFFL]    Script Date: 04/29/2010 10:24:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TELEPHONIC_AFFL]') AND parent_object_id = OBJECT_ID(N'[dbo].[FACID_TELEPHONIC]'))
ALTER TABLE [dbo].[FACID_TELEPHONIC]  WITH CHECK ADD  CONSTRAINT [FK_TELEPHONIC_AFFL] FOREIGN KEY([AFFL_ID])
REFERENCES [dbo].[FACID_AFFL] ([AFFL_ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACID_TELEPHONIC] CHECK CONSTRAINT [FK_TELEPHONIC_AFFL]
GO
