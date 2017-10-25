/******************************************************************************************************************************
 ** ObjectName: WQX_2.1-SQL-DDL.sql
 **
 ** Author: Windsor Solutions, Inc.
 **
 ** Company Name: Windsor Solutions, Inc
 **
 ** Description: Creates the WQX staging tables and views needed to support the OpenNode2 WQX plugin.
 **
 ** Notes: 
 **
 **
 ** Revision History:      
 ** ----------------------------------------------------------------------------------------------------------------------------
 **  Date         Name        Description
 ** ----------------------------------------------------------------------------------------------------------------------------
 ** 08/24/2016  BRensmith     Baseline v2.1 based on existing WQX v2.0 script
 ** 08/24/2016  BRensmith     Changes for v2.1: 
 **                           Increased ResourceSubjectText maxlength from 500 to 4000
 **                           Increased MonitoringLocationDescriptionText maxlength from 1999 to 4000
 **                           Increased ProjectDescriptionText maxlength from 1999 to 4000
 **                           Increased ResultParticleSizeBasisText maxlength from 15 to 40
 **                           Increased MethodDescriptionText maxlength from 500 to 4000
 **                           Increased SampleTransportStorageDescription maxlength from 250 to 1999
 ** 09/28/2016  BRensmith     Fixed VARBINARY to VARBINARY(MAX)
 **
 ******************************************************************************************************************************/
/*  
ALTER TABLE [dbo].[WQX_TELEPHONIC]
	DROP CONSTRAINT [FK_ORG_TELEPHONIC]
GO

ALTER TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT]
	DROP CONSTRAINT [FK_RESULT_RESULTDETQUANTLIMIT]
GO

ALTER TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [FK_RESULT_RESULTATTBINOBJ]
GO

ALTER TABLE [dbo].[WQX_RESULT]
	DROP CONSTRAINT [FK_ACTIVITY_RESULT]
GO

ALTER TABLE [dbo].[WQX_PROJECTMONLOC]
	DROP CONSTRAINT [FK_PROJECT_PROJECTMONLOC]
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	DROP CONSTRAINT [FK_PROJECT_PROJECTACTIVITY]
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	DROP CONSTRAINT [FK_ACTIVITY_PROJECTACTIVITY]
GO

ALTER TABLE [dbo].[WQX_PROJECT]
	DROP CONSTRAINT [FK_ORG_PROJECT]
GO

ALTER TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [FK_PROJECT_PROJATTBINOBJ]
GO

ALTER TABLE [dbo].[WQX_ORGADDRESS]
	DROP CONSTRAINT [FK_ORG_ORGADDRESS]
GO

ALTER TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [FK_MONLOC_MONLOCATTBINOBJ]
GO

ALTER TABLE [dbo].[WQX_MONITORINGLOCATION]
	DROP CONSTRAINT [FK_ORG_MONITORINGLOCATION]
GO

ALTER TABLE [dbo].[WQX_LABSAMPLEPREP]
	DROP CONSTRAINT [FK_RESULT_LABSAMPLEPREP]
GO

ALTER TABLE [dbo].[WQX_ELECTRONICADDRESS]
	DROP CONSTRAINT [FK_ORG_ELECTRONICADDRESS]
GO

ALTER TABLE [dbo].[WQX_DELETES]
	DROP CONSTRAINT [FK_WQX_DELETES_WQX_ORGANIZATION]
GO

ALTER TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX]
	DROP CONSTRAINT [FK_ORG_BIOLOGICALHABITATINDEX]
GO

ALTER TABLE [dbo].[WQX_ALTMONLOC]
	DROP CONSTRAINT [FK_MONLOC_ALTMONLOC]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYMETRIC]
	DROP CONSTRAINT [FK_ACTIVITY_ACTIVITYMETRIC]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYGROUP]
	DROP CONSTRAINT [FK_ORG_ACTIVITYGROUP]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG]
	DROP CONSTRAINT [FK_ACTIVITY_ACTCONDUCTINGORG]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	DROP CONSTRAINT [FK_ACTIVITY_ACTACTGROUP]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	DROP CONSTRAINT [FK_ACTIVITYGROUP_ACTACTGROUP]
GO

ALTER TABLE [dbo].[WQX_ACTIVITY]
	DROP CONSTRAINT [FK_ORG_ACTIVITY]
GO

ALTER TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [FK_ACTIVITY_ACTATTBINOBJ]
GO

ALTER TABLE [dbo].[WQX_TELEPHONIC]
	DROP CONSTRAINT [PK_WQX_TELEPHONIC]
GO

ALTER TABLE [dbo].[WQX_SUBMISSIONHISTORY]
	DROP CONSTRAINT [PK_WQX_SUBMISSIONHISTORY]
GO

ALTER TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT]
	DROP CONSTRAINT [PK_WQX_RESULTDETECTQUANTLIMIT]
GO

ALTER TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [PK_WQX_RESULTATTBINARYOBJECT]
GO

ALTER TABLE [dbo].[WQX_RESULT]
	DROP CONSTRAINT [PK_WQX_RESULT]
GO

ALTER TABLE [dbo].[WQX_PROJECTMONLOC]
	DROP CONSTRAINT [PK_WQX_PROJECTMONLOC]
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	DROP CONSTRAINT [PK_WQX_PROJECTACTIVITY]
GO

ALTER TABLE [dbo].[WQX_PROJECT]
	DROP CONSTRAINT [PK_WQX_PROJECT]
GO

ALTER TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [PK_WQX_PROJATTBINARYOBJECT]
GO

ALTER TABLE [dbo].[WQX_ORGANIZATION]
	DROP CONSTRAINT [PK_WQX_ORGANIZATION]
GO

ALTER TABLE [dbo].[WQX_ORGADDRESS]
	DROP CONSTRAINT [PK_WQX_ORGADDRESS]
GO

ALTER TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [PK_WQX_MONLOCATTBINARYOBJECT]
GO

ALTER TABLE [dbo].[WQX_MONITORINGLOCATION]
	DROP CONSTRAINT [PK_WQX_MONITORINGLOCATION]
GO

ALTER TABLE [dbo].[WQX_LABSAMPLEPREP]
	DROP CONSTRAINT [PK_WQX_LABSAMPLEPREP]
GO

ALTER TABLE [dbo].[WQX_ELECTRONICADDRESS]
	DROP CONSTRAINT [PK_WQX_ELECTRONICADDRESS]
GO

ALTER TABLE [dbo].[WQX_DELETES]
	DROP CONSTRAINT [PK_WQX_DELETES]
GO

ALTER TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX]
	DROP CONSTRAINT [PK_WQX_BIOLOGICALHABITATINDEX]
GO

ALTER TABLE [dbo].[WQX_ALTMONLOC]
	DROP CONSTRAINT [PK_WQX_ALTMONLOC]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYMETRIC]
	DROP CONSTRAINT [PK_WQX_ACTIVITYMETRIC]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYGROUP]
	DROP CONSTRAINT [PK_WQX_ACTIVITYGROUP]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG]
	DROP CONSTRAINT [PK_WQX_ACTIVITYCONDUCTINGORG]
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	DROP CONSTRAINT [PK_WQX_ACTIVITYACTIVITYGROUP]
GO

ALTER TABLE [dbo].[WQX_ACTIVITY]
	DROP CONSTRAINT [PK_WQX_ACTIVITY]
GO

ALTER TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT]
	DROP CONSTRAINT [PK_WQX_ACTATTBINARYOBJECT]
GO

DROP INDEX [dbo].[WQX_TELEPHONIC].[IX_WQX_TLPHN_PRNTD]
GO

DROP INDEX [dbo].[WQX_SUBMISSIONHISTORY].[IX_WQX_SBMSS_WQXPD]
GO

DROP INDEX [dbo].[WQX_SUBMISSIONHISTORY].[IX_WQX_SBMSS_PRNTD]
GO

DROP INDEX [dbo].[WQX_RESULTDETECTQUANTLIMIT].[IX_WQX_RSLTD_PRNTD]
GO

DROP INDEX [dbo].[WQX_RESULTATTACHEDBINARYOBJECT].[IX_WQX_RSLTT_PRNTD]
GO

DROP INDEX [dbo].[WQX_RESULT].[IX_WQX_RSLT_PRNTID]
GO

DROP INDEX [dbo].[WQX_PROJECTMONLOC].[IX_WQX_PRJCT_PRN02]
GO

DROP INDEX [dbo].[WQX_PROJECTACTIVITY].[IX_WQX_PRJCT_ACTVT]
GO

DROP INDEX [dbo].[WQX_PROJECTACTIVITY].[IX_WQX_PRJCT_PRJ02]
GO

DROP INDEX [dbo].[WQX_PROJECT].[IX_WQX_PRJCT_WQXPD]
GO

DROP INDEX [dbo].[WQX_PROJECT].[IX_WQX_PRJCT_PRNTD]
GO

DROP INDEX [dbo].[WQX_PROJECT].[IX_WQX_PRJCT_PRJCT]
GO

DROP INDEX [dbo].[WQX_PROJATTACHEDBINARYOBJECT].[IX_WQX_PRJTT_PRNTD]
GO

DROP INDEX [dbo].[WQX_ORGANIZATION].[IX_WQX_ORGNZT_ORGD]
GO

DROP INDEX [dbo].[WQX_ORGADDRESS].[IX_WQX_ORGDD_PRNTD]
GO

DROP INDEX [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT].[IX_WQX_MNLCT_PRNTD]
GO

DROP INDEX [dbo].[WQX_MONITORINGLOCATION].[IX_WQX_MNTRN_MNTRN]
GO

DROP INDEX [dbo].[WQX_MONITORINGLOCATION].[IX_WQX_MNTRN_WQXPD]
GO

DROP INDEX [dbo].[WQX_MONITORINGLOCATION].[IX_WQX_MNTRN_PRNTD]
GO

DROP INDEX [dbo].[WQX_LABSAMPLEPREP].[IX_WQX_LBSMP_PRNTD]
GO

DROP INDEX [dbo].[WQX_ELECTRONICADDRESS].[IX_WQX_ELCTR_PRNTD]
GO

DROP INDEX [dbo].[WQX_DELETES].[IX_WQX_DELTS_PRNTD]
GO

DROP INDEX [dbo].[WQX_DELETES].[IX_WQX_DLTS_WQXPDT]
GO

DROP INDEX [dbo].[WQX_BIOLOGICALHABITATINDEX].[IX_WQX_BLGCL_WQXPD]
GO

DROP INDEX [dbo].[WQX_BIOLOGICALHABITATINDEX].[IX_WQX_BLGCL_PRNTD]
GO

DROP INDEX [dbo].[WQX_BIOLOGICALHABITATINDEX].[IX_WQX_BLGCL_MNLCD]
GO

DROP INDEX [dbo].[WQX_ALTMONLOC].[IX_WQX_ALTMN_PRNTD]
GO

DROP INDEX [dbo].[WQX_ACTIVITYMETRIC].[IX_WQX_ACTVT_PRN03]
GO

DROP INDEX [dbo].[WQX_ACTIVITYGROUP].[IX_WQX_ACTVT_PRN04]
GO

DROP INDEX [dbo].[WQX_ACTIVITYGROUP].[IX_WQX_ACTVT_WQX02]
GO

DROP INDEX [dbo].[WQX_ACTIVITYCONDUCTINGORG].[IX_WQX_ACTVT_PRN02]
GO

DROP INDEX [dbo].[WQX_ACTIVITYACTIVITYGROUP].[IX_WQX_ACTVT_ACT04]
GO

DROP INDEX [dbo].[WQX_ACTIVITYACTIVITYGROUP].[IX_WQX_ACTVT_ACT03]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTIV_AIDINC]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTVT_ACTVT]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTVT_MNLCD]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTVT_WQXPD]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTVT_PRNTD]
GO

DROP INDEX [dbo].[WQX_ACTIVITY].[IX_WQX_ACTVT_ACT02]
GO

DROP INDEX [dbo].[WQX_ACTATTACHEDBINARYOBJECT].[IX_WQX_ACTTT_PRNTD]
GO

DROP VIEW [dbo].[WQX_V_PROJECTACTIVITYID_HIB]
GO

DROP VIEW [dbo].[WQX_V_ATTACHEDBINARYOBJECT_HIB]
GO

DROP VIEW [dbo].[WQX_V_ACTIVITYGROUPID_HIB]
GO

DROP TABLE [dbo].[WQX_TELEPHONIC]
GO

DROP TABLE [dbo].[WQX_SUBMISSIONHISTORY]
GO

DROP TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT]
GO

DROP TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]
GO

DROP TABLE [dbo].[WQX_RESULT]
GO

DROP TABLE [dbo].[WQX_PROJECTMONLOC]
GO

DROP TABLE [dbo].[WQX_PROJECTACTIVITY]
GO

DROP TABLE [dbo].[WQX_PROJECT]
GO

DROP TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT]
GO

DROP TABLE [dbo].[WQX_ORGANIZATION]
GO

DROP TABLE [dbo].[WQX_ORGADDRESS]
GO

DROP TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]
GO

DROP TABLE [dbo].[WQX_MONITORINGLOCATION]
GO

DROP TABLE [dbo].[WQX_LABSAMPLEPREP]
GO

DROP TABLE [dbo].[WQX_ELECTRONICADDRESS]
GO

DROP TABLE [dbo].[WQX_DELETES]
GO

DROP TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX]
GO

DROP TABLE [dbo].[WQX_ALTMONLOC]
GO

DROP TABLE [dbo].[WQX_ACTIVITYMETRIC]
GO

DROP TABLE [dbo].[WQX_ACTIVITYGROUP]
GO

DROP TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG]
GO

DROP TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
GO

DROP TABLE [dbo].[WQX_ACTIVITY]
GO

DROP TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT]
GO
*/


CREATE TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT] ( 
	[RECORDID]                	varchar(50) NOT NULL,
	[PARENTID]                	varchar(50) NOT NULL,
	[BINARYOBJECTFILE]        	varchar(255) NOT NULL,
	[BINARYOBJECTFILETYPECODE]	varchar(6) NOT NULL,
	[BINARYOBJECTCONTENT]     	VARBINARY(MAX) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ACTIVITY] ( 
	[RECORDID]                      	varchar(50) NOT NULL,
	[PARENTID]                      	varchar(50) NOT NULL,
	[ACTIVITYID]                    	varchar(35) NOT NULL,
	[ACTIVITYTYPECODE]              	varchar(70) NOT NULL,
	[ACTIVITYMEDIA]                 	varchar(20) NOT NULL,
	[ACTIVITYMEDIASUBDIVISION]      	varchar(45) NULL,
	[ACTIVITYSTARTDATE]             	datetime NOT NULL,
	[STARTTIME]                     	varchar(20) NULL,
	[STARTTIMEZONE]                 	varchar(4) NULL,
	[ACTIVITYENDDATE]               	datetime NULL,
	[ENDTIME]                       	varchar(20) NULL,
	[ENDTIMEZONE]                   	varchar(4) NULL,
	[RELATIVEDEPTH]                 	varchar(15) NULL,
	[DEPTHHEIGHTMEASURE]            	varchar(12) NULL,
	[DEPTHHEIGHTMEASUREUNIT]        	varchar(12) NULL,
	[TOPDEPTHHEIGHTMEASURE]         	varchar(12) NULL,
	[TOPDEPTHHEIGHTMEASUREUNIT]     	varchar(12) NULL,
	[BOTTOMDEPTHHEIGHTMEASURE]      	varchar(12) NULL,
	[BOTTOMDEPTHHEIGHTMEASUREUNIT]  	varchar(12) NULL,
	[DEPTHALTITUDEREFPOINT]         	varchar(125) NULL,
	[MONLOCID]                      	varchar(35) NULL,
	[ACTIVITYCOMMENT]               	varchar(4000) NULL,
	[LATITUDEMEASURE]               	varchar(30) NULL,
	[LONGITUDEMEASURE]              	varchar(30) NULL,
	[SOURCEMAPSCALE]                	varchar(12) NULL,
	[HORIZACCURACYMEASURE]          	varchar(12) NULL,
	[HORIZACCURACYMEASUREUNIT]      	varchar(12) NULL,
	[HORIZCOLLMETHOD]               	varchar(150) NULL,
	[HORIZCOORDREFSYSDATUM]         	varchar(6) NULL,
	[BIOACTIVITYASSEMBLAGESAMPD]    	varchar(50) NULL,
	[BIOHABCOLLDURATIONMEASURE]     	varchar(12) NULL,
	[BIOHABCOLLDURATIONMEASUREUNIT] 	varchar(12) NULL,
	[BIOHABSAMPCOMP]                	varchar(15) NULL,
	[BIOHABSAMPCOMPPLACEINSERIES]   	varchar(12) NULL,
	[BIOHABREACHLENGTHMEASURE]      	varchar(12) NULL,
	[BIOHABREACHLENGTHMEASUREUNIT]  	varchar(12) NULL,
	[BIOHABREACHWIDTHMEASURE]       	varchar(12) NULL,
	[BIOHABREACHWIDTHMEASUREUNIT]   	varchar(12) NULL,
	[BIOHABPASSCOUNT]               	varchar(12) NULL,
	[BIOHABNETTYPE]                 	varchar(30) NULL,
	[BIOHABNETSURFACEAREAMEASURE]   	varchar(12) NULL,
	[BIOHABNETSURFACEMEASUREUNIT]   	varchar(12) NULL,
	[BIOHABNETMESHSIZEMEASURE]      	varchar(12) NULL,
	[BIOHABNETMESHMEASUREUNIT]      	varchar(12) NULL,
	[BIOHABNETBOATSPEEDMEASURE]     	varchar(12) NULL,
	[BIOHABNETBOATSPEEDMEASUREUNIT] 	varchar(12) NULL,
	[BIOHABNETCURRSPEEDMEASURE]     	varchar(12) NULL,
	[BIOHABNETCURRSPEEDMEASUREUNIT] 	varchar(12) NULL,
	[BIOACTIVITYTOXICITYTESTTYPE]   	varchar(7) NULL,
	[SAMPCOLLMETHODID]              	varchar(20) NULL,
	[SAMPCOLLMETHODIDCONTEXT]       	varchar(120) NULL,
	[SAMPCOLLMETHOD]                	varchar(120) NULL,
	[SAMPCOLLMETHODQUALIFIER]       	varchar(25) NULL,
	[SAMPCOLLMETHODDESC]            	varchar(500) NULL,
	[SAMPCOLLEQUIPMENT]             	varchar(40) NULL,
	[SAMPCOLLEQUIPMENTCOMMENT]      	varchar(4000) NULL,
	[SAMPPREPID]                    	varchar(20) NULL,
	[SAMPPREPIDCONTEXT]             	varchar(120) NULL,
	[SAMPPREP]                      	varchar(120) NULL,
	[SAMPPREPQUALIFIERTYPE]         	varchar(25) NULL,
	[SAMPPREPDESC]                  	varchar(500) NULL,
	[SAMPPREPCONTTYPE]              	varchar(35) NULL,
	[SAMPPREPCONTCOLOR]             	varchar(15) NULL,
	[SAMPPREPCONTCHEMPRESERVUSED]   	varchar(250) NULL,
	[SAMPPREPCONTTHERMALPRESERVUSED]	varchar(25) NULL,
	[SAMPPREPCONTSAMPTRANSSTORDESC] 	varchar(1999) NULL,
	[RESULTCOUNT]                   	varchar(255) NULL,
	[WQXUPDATEDATE]                 	datetime NOT NULL,
	[TMPPROJECTID]                  	varchar(50) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP] ( 
	[RECORDID]             	varchar(50) NOT NULL,
	[ACTIVITYPARENTID]     	varchar(50) NOT NULL,
	[ACTIVITYGROUPPARENTID]	varchar(50) NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG] ( 
	[RECORDID]             	varchar(50) NOT NULL,
	[PARENTID]             	varchar(50) NOT NULL,
	[ACTIVITYID]           	varchar(35) NOT NULL,
	[ACTIVITYCONDUCTINGORG]	varchar(120) NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ACTIVITYGROUP] ( 
	[RECORDID]             	varchar(50) NOT NULL,
	[PARENTID]             	varchar(50) NOT NULL,
	[ACTIVITYGROUPID]      	varchar(35) NOT NULL,
	[ACTIVITYGROUPNAME]    	varchar(50) NOT NULL,
	[ACTIVITYGROUPTYPECODE]	varchar(50) NOT NULL,
	[WQXUPDATEDATE]        	datetime NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ACTIVITYMETRIC] ( 
	[RECORDID]                 	varchar(50) NOT NULL,
	[PARENTID]                 	varchar(50) NOT NULL,
	[METRICTYPEID]             	varchar(35) NOT NULL,
	[METRICTYPEIDCONTEXT]      	varchar(50) NOT NULL,
	[METRICTYPENAME]           	varchar(50) NULL,
	[CITATIONRESOURCETITLE]    	varchar(120) NULL,
	[CITATIONRESOURCECREATOR]  	varchar(120) NULL,
	[CITATIONRESOURCESUBJECT]  	varchar(4000) NULL,
	[CITATIONRESOURCEPUBLISHER]	varchar(60) NULL,
	[CITATIONRESOURCEDATE]     	datetime NULL,
	[CITATIONRESOURCEID]       	varchar(255) NULL,
	[METRICTYPESCALE]          	varchar(50) NULL,
	[METRICTYPEFORMULADESC]    	varchar(50) NULL,
	[METRICVALUEMEASURE]       	varchar(12) NULL,
	[METRICVALUEMEASUREUNIT]   	varchar(12) NULL,
	[METRICSCORE]              	varchar(10) NOT NULL,
	[METRICCOMMENT]            	varchar(4000) NULL,
	[METRICINDEXID]            	varchar(35) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ALTMONLOC] ( 
	[RECORDID]       	varchar(50) NOT NULL,
	[PARENTID]       	varchar(50) NOT NULL,
	[MONLOCID]       	varchar(35) NOT NULL,
	[MONLOCIDCONTEXT]	varchar(120) NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX] ( 
	[RECORDID]           	varchar(50) NOT NULL,
	[PARENTID]           	varchar(50) NOT NULL,
	[INDEXID]            	varchar(35) NOT NULL,
	[INDEXTYPEID]        	varchar(35) NOT NULL,
	[INDEXTYPEIDCONTEXT] 	varchar(50) NOT NULL,
	[INDEXTYPENAME]      	varchar(50) NOT NULL,
	[RESOURCETITLE]      	varchar(120) NULL,
	[RESOURCECREATOR]    	varchar(120) NULL,
	[RESOURCESUBJECT]    	varchar(500) NULL,
	[RESOURCEPUBLISHER]  	varchar(60) NULL,
	[RESOURCEDATE]       	varchar(10) NULL,
	[RESOURCEID]         	varchar(255) NULL,
	[INDEXTYPESCALE]     	varchar(50) NULL,
	[INDEXSCORE]         	varchar(10) NOT NULL,
	[INDEXQUALIFIERCODE] 	varchar(5) NULL,
	[INDEXCOMMENT]       	varchar(4000) NULL,
	[INDEXCALCULATEDDATE]	varchar(10) NULL,
	[MONLOCID]           	varchar(35) NOT NULL,
	[WQXUPDATEDATE]      	datetime NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_DELETES] ( 
	[RECORDID]     	varchar(50) NOT NULL,
	[PARENTID]     	varchar(50) NOT NULL,
	[COMPONENT]    	varchar(50) NOT NULL,
	[IDENTIFIER]   	varchar(50) NOT NULL,
	[WQXUPDATEDATE]	datetime NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ELECTRONICADDRESS] ( 
	[RECORDID]             	varchar(50) NOT NULL,
	[PARENTID]             	varchar(50) NOT NULL,
	[ELECTRONICADDRESS]    	varchar(120) NOT NULL,
	[ELECTRONICADDRESSTYPE]	varchar(8) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_LABSAMPLEPREP] ( 
	[RECORDID]               	varchar(50) NOT NULL,
	[PARENTID]               	varchar(50) NOT NULL,
	[METHODID]               	varchar(20) NOT NULL,
	[METHODIDCONTEXT]        	varchar(120) NOT NULL,
	[METHODNAME]             	varchar(120) NOT NULL,
	[METHODQUALIFIERTYPE]    	varchar(25) NULL,
	[METHODDESC]             	varchar(500) NULL,
	[PREPSTARTDATE]          	datetime NULL,
	[PREPSTARTTIME]          	varchar(20) NULL,
	[PREPSTARTTIMEZONECODE]  	varchar(4) NULL,
	[PREPENDDATE]            	datetime NULL,
	[PREPENDTIME]            	varchar(20) NULL,
	[PREPENDTIMEZONECODE]    	varchar(4) NULL,
	[SUBSTANCEDILUTIONFACTOR]	varchar(10) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_MONITORINGLOCATION] ( 
	[RECORDID]                	varchar(50) NOT NULL,
	[PARENTID]                	varchar(50) NOT NULL,
	[MONITORINGLOCATIONID]    	varchar(35) NOT NULL,
	[MONLOCNAME]              	varchar(255) NOT NULL,
	[MONLOCTYPE]              	varchar(45) NOT NULL,
	[MONLOCDESC]              	varchar(4000) NULL,
	[HUCEIGHTDIGITCODE]       	varchar(8) NULL,
	[HUCTWELVEDIGITCODE]      	varchar(12) NULL,
	[TRIBALLANDIND]           	char(1) NULL,
	[TRIBALLANDNAME]          	varchar(200) NULL,
	[LATITUDEMEASURE]         	varchar(30) NOT NULL,
	[LONGITUDEMEASURE]        	varchar(30) NOT NULL,
	[SOURCEMAPSCALE]          	int NULL,
	[HORIZACCURACYMEASURE]    	varchar(12) NULL,
	[HORIZACCURACYMEASUREUNIT]	varchar(12) NULL,
	[HORIZCOLLMETHOD]         	varchar(150) NOT NULL,
	[HORIZCOORDREFSYSDATUM]   	varchar(6) NOT NULL,
	[VERTICALMEASURE]         	varchar(12) NULL,
	[VERTICALMEASUREUNIT]     	varchar(12) NULL,
	[VERTICALCOLLMETHOD]      	varchar(50) NULL,
	[VERTICALCOORDREFSYSDATUM]	varchar(10) NULL,
	[COUNTRYCODE]             	varchar(2) NULL,
	[STATECODE]               	varchar(2) NULL,
	[COUNTYCODE]              	varchar(3) NULL,
	[WELLTYPE]                	varchar(255) NULL,
	[AQUIFERNAME]             	varchar(120) NULL,
	[FORMATIONTYPE]           	varchar(50) NULL,
	[WELLHOLEDEPTHMEASURE]    	varchar(12) NULL,
	[WELLHOLEDEPTHMEASUREUNIT]	varchar(12) NULL,
	[WQXUPDATEDATE]           	datetime NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT] ( 
	[RECORDID]                	varchar(50) NOT NULL,
	[PARENTID]                	varchar(50) NOT NULL,
	[BINARYOBJECTFILE]        	varchar(255) NOT NULL,
	[BINARYOBJECTFILETYPECODE]	varchar(6) NOT NULL,
	[BINARYOBJECTCONTENT]     	VARBINARY(MAX) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ORGADDRESS] ( 
	[RECORDID]           	varchar(50) NOT NULL,
	[PARENTID]           	varchar(50) NOT NULL,
	[ADDRESSTYPE]        	varchar(8) NULL,
	[ADDRESS]            	varchar(50) NOT NULL,
	[SUPPLEMENTALADDRESS]	varchar(120) NULL,
	[LOCALITY]           	varchar(30) NULL,
	[STATECODE]          	varchar(2) NULL,
	[POSTALCODE]         	varchar(10) NULL,
	[COUNTRYCODE]        	varchar(2) NULL,
	[COUNTYCODE]         	varchar(3) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_ORGANIZATION] ( 
	[RECORDID]     	varchar(50) NOT NULL,
	[ORGID]        	varchar(30) NOT NULL,
	[ORGFORMALNAME]	varchar(120) NOT NULL,
	[ORGDESC]      	varchar(500) NULL,
	[TRIBALCODE]   	varchar(3) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT] ( 
	[RECORDID]                	varchar(50) NOT NULL,
	[PARENTID]                	varchar(50) NOT NULL,
	[BINARYOBJECTFILE]        	varchar(255) NOT NULL,
	[BINARYOBJECTFILETYPECODE]	varchar(6) NOT NULL,
	[BINARYOBJECTCONTENT]     	VARBINARY(MAX) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_PROJECT] ( 
	[RECORDID]              	varchar(50) NOT NULL,
	[PARENTID]              	varchar(50) NOT NULL,
	[PROJECTID]             	varchar(35) NOT NULL,
	[PROJECTNAME]           	varchar(120) NOT NULL,
	[PROJECTDESC]           	varchar(4000) NULL,
	[SAMPLINGDESIGNTYPECODE]	varchar(20) NULL,
	[QAPPAPPROVEDIND]       	char(1) NULL,
	[QAPPAPPROVALAGENCYNAME]	varchar(50) NULL,
	[WQXUPDATEDATE]         	datetime NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_PROJECTACTIVITY] ( 
	[RECORDID]        	varchar(50) NOT NULL,
	[PROJECTPARENTID] 	varchar(50) NOT NULL,
	[ACTIVITYPARENTID]	varchar(50) NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_PROJECTMONLOC] ( 
	[RECORDID]                  	varchar(50) NOT NULL,
	[PARENTID]                  	varchar(50) NOT NULL,
	[MONLOCID]                  	varchar(35) NOT NULL,
	[LOCWEIGHTINGFACMEASURE]    	varchar(12) NOT NULL,
	[LOCWEIGHTINGFACMEASUREUNIT]	varchar(12) NOT NULL,
	[STATISTICALSTRATUM]        	varchar(15) NULL,
	[LOCATIONCATERY]            	varchar(50) NULL,
	[LOCATIONSTATUS]            	varchar(15) NULL,
	[REFLOCATIONTYPECODE]       	varchar(20) NULL,
	[REFLOCATIONSTARTDATE]      	datetime NULL,
	[REFLOCATIONENDDATE]        	datetime NULL,
	[RESOURCETITLE]             	varchar(120) NULL,
	[RESOURCECREATOR]           	varchar(120) NULL,
	[RESOURCESUBJECT]           	varchar(500) NULL,
	[RESOURCEPUBLISHER]         	varchar(60) NULL,
	[RESOURCEDATE]              	datetime NULL,
	[RESOURCEID]                	varchar(255) NULL,
	[PROJMONLOCCOMMENT]         	varchar(4000) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_RESULT] ( 
	[RECORDID]                      	varchar(50) NOT NULL,
	[PARENTID]                      	varchar(50) NOT NULL,
	[DATALOGGERLINENAME]            	varchar(15) NULL,
	[RESULTDETECTIONCONDITION]      	varchar(35) NULL,
	[CHARACTERISTICNAME]            	varchar(120) NULL,
	[METHODSPECIATIONNAME]          	varchar(20) NULL,
	[RESULTSAMPFRACTION]            	varchar(25) NULL,
	[RESULTMEASURE]                 	varchar(60) NULL,
	[RESULTMEASUREUNIT]             	varchar(12) NULL,
	[RESULTMEASUREQUALIFIERCODE]    	varchar(5) NULL,
	[STATUSID]                      	varchar(12) NULL,
	[STATISTICALBASECODE]           	varchar(25) NULL,
	[VALUETYPE]                     	varchar(20) NULL,
	[WEIGHTBASIS]                   	varchar(15) NULL,
	[TIMEBASIS]                     	varchar(12) NULL,
	[TEMPERATUREBASIS]              	varchar(12) NULL,
	[PARTICLESIZEBASIS]             	varchar(40) NULL,
	[PRECISIONVALUE]                	varchar(60) NULL,
	[BIASVALUE]                     	varchar(60) NULL,
	[CONFIDENCEINTERVALVALUE]       	varchar(15) NULL,
	[UPPERCONFIDENCELIMITVALUE]     	varchar(15) NULL,
	[LOWERCONFIDENCELIMITVALUE]     	varchar(15) NULL,
	[RESULTCOMMENT]                 	varchar(4000) NULL,
	[DEPTHHEIGHTMEASURE]            	varchar(12) NULL,
	[DEPTHHEIGHTMEASUREUNIT]        	varchar(12) NULL,
	[DEPTHALTITUDEREFPOINT]         	varchar(125) NULL,
	[RESULTSAMPPOINT]               	varchar(12) NULL,
	[BIORESULTINTENT]               	varchar(35) NULL,
	[BIORESULTINDIVIDUALID]         	varchar(4) NULL,
	[BIORESULTSUBJECTTAXONOMIC]     	varchar(120) NULL,
	[BIORESULTUNIDENTIFIEDSPECIESID]	varchar(120) NULL,
	[BIORESULTSAMPTISSUEANATOMY]    	varchar(30) NULL,
	[GRPSUMMCOUNTWEIGHTMEASURE]     	varchar(12) NULL,
	[GRPSUMMCOUNTWEIGHTMEASUREUNIT] 	varchar(12) NULL,
	[TAXDETAILSCELLFORM]            	varchar(11) NULL,
	[TAXDETAILSCELLSHAPE]           	varchar(18) NULL,
	[TAXDETAILSHABITNAME]           	varchar(50) NULL,
	[TAXDETAILSVOLTINISM]           	varchar(25) NULL,
	[TAXDETAILSPOLLTOLERANCE]       	varchar(4) NULL,
	[TAXDETAILSPOLLTOLERANCESCALE]  	varchar(50) NULL,
	[TAXDETAILSTROPHICLEVEL]        	varchar(4) NULL,
	[TAXDETAILSFUNCFEEDINGGROUP]    	varchar(125) NULL,
	[CITATIONRESOURCETITLE]         	varchar(120) NULL,
	[CITATIONRESOURCECREATOR]       	varchar(120) NULL,
	[CITATIONRESOURCESUBJECT]       	varchar(500) NULL,
	[CITATIONRESOURCEPUBLISHER]     	varchar(60) NULL,
	[CITATIONRESOURCEDATE]          	datetime NULL,
	[CITATIONRESOURCEID]            	varchar(255) NULL,
	[FREQCLASSDESCCODE]             	varchar(50) NULL,
	[FREQCLASSDESCUNITCODE]         	varchar(12) NULL,
	[FREQCLASSLOWERBOUNDVALUE]      	varchar(8) NULL,
	[FREQCLASSUPPERBOUNDVALUE]      	varchar(8) NULL,
	[ANALYTICALMETHODID]            	varchar(20) NULL,
	[ANALYTICALMETHODIDCONTEXT]     	varchar(120) NULL,
	[ANALYTICALMETHODNAME]          	varchar(120) NULL,
	[ANALYTICALMETHODQUALIFIERTYPE] 	varchar(25) NULL,
	[ANALYTICALMETHODDESC]          	varchar(4000) NULL,
	[LABNAME]                       	varchar(60) NULL,
	[LABANALYSISSTARTDATE]          	datetime NULL,
	[LABANALYSISSTARTTIME]          	varchar(20) NULL,
	[LABANALYSISSTARTTIMEZONECODE]  	varchar(4) NULL,
	[LABANALYSISENDDATE]            	datetime NULL,
	[LABANALYSISENDTIME]            	varchar(20) NULL,
	[LABANALYSISENDTIMEZONECODE]    	varchar(4) NULL,
	[RESULTLABCOMMENTCODE]          	varchar(3) NULL,
	[LABACCIND]                     	char(1) NULL,
	[LABACCAUTHORITYNAME]           	varchar(20) NULL,
	[LABTAXACCIND]                  	char(1) NULL,
	[LABTAXACCAUTHORITYNAME]        	varchar(20) NULL,
	[TMPACTIVITYID]                 	varchar(35) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT] ( 
	[RECORDID]                	varchar(50) NOT NULL,
	[PARENTID]                	varchar(50) NOT NULL,
	[BINARYOBJECTFILE]        	varchar(255) NOT NULL,
	[BINARYOBJECTFILETYPECODE]	varchar(6) NOT NULL,
	[BINARYOBJECTCONTENT]     	VARBINARY(MAX) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT] ( 
	[RECORDID]                    	varchar(50) NOT NULL,
	[PARENTID]                    	varchar(50) NOT NULL,
	[DETECTQUANTLIMITTYPE]        	varchar(35) NOT NULL,
	[DETECTQUANTLIMITMEASURE]     	varchar(12) NULL,
	[DETECTQUANTLIMITMEASUNITCODE]	varchar(12) NULL 
	)
GO

CREATE TABLE [dbo].[WQX_SUBMISSIONHISTORY] ( 
	[RECORDID]           	varchar(50) NOT NULL,
	[PARENTID]           	varchar(50) NOT NULL,
	[SCHEDULERUNDATE]    	datetime NOT NULL,
	[WQXUPDATEDATE]      	datetime NOT NULL,
	[SUBMISSIONTYPE]     	varchar(13) NOT NULL,
	[LOCALTRANSACTIONID] 	varchar(50) NOT NULL,
	[CDXPROCESSINGSTATUS]	varchar(50) NOT NULL,
	[ORGID]              	varchar(30) NOT NULL 
	)
GO

CREATE TABLE [dbo].[WQX_TELEPHONIC] ( 
	[RECORDID]           	varchar(50) NOT NULL,
	[PARENTID]           	varchar(50) NOT NULL,
	[TELEPHONENUMBER]    	varchar(15) NOT NULL,
	[TELEPHONENUMBERTYPE]	varchar(6) NULL,
	[TELEPHONEEXT]       	varchar(6) NULL 
	)
GO


CREATE VIEW [dbo].[WQX_V_ACTIVITYGROUPID_HIB] AS
SELECT WQX_ACTIVITYACTIVITYGROUP.ACTIVITYGROUPPARENTID
     , WQX_ACTIVITY.ACTIVITYID 
  FROM WQX_ACTIVITYACTIVITYGROUP 
  JOIN WQX_ACTIVITY 
    ON WQX_ACTIVITYACTIVITYGROUP.ACTIVITYPARENTID = WQX_ACTIVITY.RECORDID

GO


CREATE VIEW [dbo].[WQX_V_ATTACHEDBINARYOBJECT_HIB] AS
SELECT RECORDID
     , PARENTID
     , BINARYOBJECTFILE
     , BINARYOBJECTFILETYPECODE
     , BINARYOBJECTCONTENT
  FROM WQX_ACTATTACHEDBINARYOBJECT
UNION ALL
SELECT RECORDID
     , PARENTID
     , BINARYOBJECTFILE
     , BINARYOBJECTFILETYPECODE
     , BINARYOBJECTCONTENT
  FROM WQX_MONLOCATTACHEDBINARYOBJECT
UNION ALL
SELECT RECORDID
     , PARENTID
     , BINARYOBJECTFILE
     , BINARYOBJECTFILETYPECODE
     , BINARYOBJECTCONTENT
FROM WQX_PROJATTACHEDBINARYOBJECT
UNION ALL
SELECT RECORDID
     , PARENTID
     , BINARYOBJECTFILE
     , BINARYOBJECTFILETYPECODE
     , BINARYOBJECTCONTENT
FROM WQX_RESULTATTACHEDBINARYOBJECT

GO


CREATE VIEW [dbo].[WQX_V_PROJECTACTIVITYID_HIB] AS
SELECT WQX_PROJECTACTIVITY.ACTIVITYPARENTID
     , WQX_PROJECT.PROJECTID 
  FROM WQX_PROJECTACTIVITY 
  JOIN WQX_ACTIVITY 
    ON WQX_PROJECTACTIVITY.ACTIVITYPARENTID = WQX_ACTIVITY.RECORDID
  JOIN WQX_PROJECT 
    ON WQX_PROJECTACTIVITY.PROJECTPARENTID = WQX_PROJECT.RECORDID

GO


CREATE INDEX [IX_WQX_ACTTT_PRNTD]
	ON [dbo].[WQX_ACTATTACHEDBINARYOBJECT]([PARENTID])
GO

CREATE INDEX [IX_WQX_ACTIV_AIDINC]
	ON [dbo].[WQX_ACTIVITY]([RECORDID], [PARENTID], [ACTIVITYID])
GO

CREATE INDEX [IX_WQX_ACTVT_ACTVT]
	ON [dbo].[WQX_ACTIVITY]([ACTIVITYID])
GO

CREATE INDEX [IX_WQX_ACTVT_MNLCD]
	ON [dbo].[WQX_ACTIVITY]([MONLOCID])
GO

CREATE INDEX [IX_WQX_ACTVT_WQXPD]
	ON [dbo].[WQX_ACTIVITY]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_ACTVT_PRNTD]
	ON [dbo].[WQX_ACTIVITY]([PARENTID])
GO

CREATE INDEX [IX_WQX_ACTVT_ACT02]
	ON [dbo].[WQX_ACTIVITY]([ACTIVITYSTARTDATE])
GO

CREATE INDEX [IX_WQX_ACTVT_ACT04]
	ON [dbo].[WQX_ACTIVITYACTIVITYGROUP]([ACTIVITYPARENTID])
GO

CREATE INDEX [IX_WQX_ACTVT_ACT03]
	ON [dbo].[WQX_ACTIVITYACTIVITYGROUP]([ACTIVITYGROUPPARENTID])
GO

CREATE INDEX [IX_WQX_ACTVT_PRN02]
	ON [dbo].[WQX_ACTIVITYCONDUCTINGORG]([PARENTID])
GO

CREATE INDEX [IX_WQX_ACTVT_PRN04]
	ON [dbo].[WQX_ACTIVITYGROUP]([PARENTID])
GO

CREATE INDEX [IX_WQX_ACTVT_WQX02]
	ON [dbo].[WQX_ACTIVITYGROUP]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_ACTVT_PRN03]
	ON [dbo].[WQX_ACTIVITYMETRIC]([PARENTID])
GO

CREATE INDEX [IX_WQX_ALTMN_PRNTD]
	ON [dbo].[WQX_ALTMONLOC]([PARENTID])
GO

CREATE INDEX [IX_WQX_BLGCL_WQXPD]
	ON [dbo].[WQX_BIOLOGICALHABITATINDEX]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_BLGCL_PRNTD]
	ON [dbo].[WQX_BIOLOGICALHABITATINDEX]([PARENTID])
GO

CREATE INDEX [IX_WQX_BLGCL_MNLCD]
	ON [dbo].[WQX_BIOLOGICALHABITATINDEX]([MONLOCID])
GO

CREATE INDEX [IX_WQX_DELTS_PRNTD]
	ON [dbo].[WQX_DELETES]([PARENTID])
GO

CREATE INDEX [IX_WQX_DLTS_WQXPDT]
	ON [dbo].[WQX_DELETES]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_ELCTR_PRNTD]
	ON [dbo].[WQX_ELECTRONICADDRESS]([PARENTID])
GO

CREATE INDEX [IX_WQX_LBSMP_PRNTD]
	ON [dbo].[WQX_LABSAMPLEPREP]([PARENTID])
GO

CREATE INDEX [IX_WQX_MNTRN_MNTRN]
	ON [dbo].[WQX_MONITORINGLOCATION]([MONITORINGLOCATIONID])
GO

CREATE INDEX [IX_WQX_MNTRN_WQXPD]
	ON [dbo].[WQX_MONITORINGLOCATION]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_MNTRN_PRNTD]
	ON [dbo].[WQX_MONITORINGLOCATION]([PARENTID])
GO

CREATE INDEX [IX_WQX_MNLCT_PRNTD]
	ON [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]([PARENTID])
GO

CREATE INDEX [IX_WQX_ORGDD_PRNTD]
	ON [dbo].[WQX_ORGADDRESS]([PARENTID])
GO

CREATE INDEX [IX_WQX_ORGNZT_ORGD]
	ON [dbo].[WQX_ORGANIZATION]([ORGID])
GO

CREATE INDEX [IX_WQX_PRJTT_PRNTD]
	ON [dbo].[WQX_PROJATTACHEDBINARYOBJECT]([PARENTID])
GO

CREATE INDEX [IX_WQX_PRJCT_WQXPD]
	ON [dbo].[WQX_PROJECT]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_PRJCT_PRNTD]
	ON [dbo].[WQX_PROJECT]([PARENTID])
GO

CREATE INDEX [IX_WQX_PRJCT_PRJCT]
	ON [dbo].[WQX_PROJECT]([PROJECTID])
GO

CREATE INDEX [IX_WQX_PRJCT_ACTVT]
	ON [dbo].[WQX_PROJECTACTIVITY]([ACTIVITYPARENTID])
GO

CREATE INDEX [IX_WQX_PRJCT_PRJ02]
	ON [dbo].[WQX_PROJECTACTIVITY]([PROJECTPARENTID])
GO

CREATE INDEX [IX_WQX_PRJCT_PRN02]
	ON [dbo].[WQX_PROJECTMONLOC]([PARENTID])
GO

CREATE INDEX [IX_WQX_RSLT_PRNTID]
	ON [dbo].[WQX_RESULT]([PARENTID])
GO

CREATE INDEX [IX_WQX_RSLTT_PRNTD]
	ON [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]([PARENTID])
GO

CREATE INDEX [IX_WQX_RSLTD_PRNTD]
	ON [dbo].[WQX_RESULTDETECTQUANTLIMIT]([PARENTID])
GO

CREATE INDEX [IX_WQX_SBMSS_WQXPD]
	ON [dbo].[WQX_SUBMISSIONHISTORY]([WQXUPDATEDATE])
GO

CREATE INDEX [IX_WQX_SBMSS_PRNTD]
	ON [dbo].[WQX_SUBMISSIONHISTORY]([PARENTID])
GO

CREATE INDEX [IX_WQX_TLPHN_PRNTD]
	ON [dbo].[WQX_TELEPHONIC]([PARENTID])
GO

ALTER TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [PK_WQX_ACTATTBINARYOBJECT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTIVITY]
	ADD CONSTRAINT [PK_WQX_ACTIVITY]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	ADD CONSTRAINT [PK_WQX_ACTIVITYACTIVITYGROUP]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG]
	ADD CONSTRAINT [PK_WQX_ACTIVITYCONDUCTINGORG]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTIVITYGROUP]
	ADD CONSTRAINT [PK_WQX_ACTIVITYGROUP]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTIVITYMETRIC]
	ADD CONSTRAINT [PK_WQX_ACTIVITYMETRIC]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ALTMONLOC]
	ADD CONSTRAINT [PK_WQX_ALTMONLOC]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX]
	ADD CONSTRAINT [PK_WQX_BIOLOGICALHABITATINDEX]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_DELETES]
	ADD CONSTRAINT [PK_WQX_DELETES]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ELECTRONICADDRESS]
	ADD CONSTRAINT [PK_WQX_ELECTRONICADDRESS]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_LABSAMPLEPREP]
	ADD CONSTRAINT [PK_WQX_LABSAMPLEPREP]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_MONITORINGLOCATION]
	ADD CONSTRAINT [PK_WQX_MONITORINGLOCATION]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [PK_WQX_MONLOCATTBINARYOBJECT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ORGADDRESS]
	ADD CONSTRAINT [PK_WQX_ORGADDRESS]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ORGANIZATION]
	ADD CONSTRAINT [PK_WQX_ORGANIZATION]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [PK_WQX_PROJATTBINARYOBJECT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_PROJECT]
	ADD CONSTRAINT [PK_WQX_PROJECT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	ADD CONSTRAINT [PK_WQX_PROJECTACTIVITY]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_PROJECTMONLOC]
	ADD CONSTRAINT [PK_WQX_PROJECTMONLOC]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_RESULT]
	ADD CONSTRAINT [PK_WQX_RESULT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [PK_WQX_RESULTATTBINARYOBJECT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT]
	ADD CONSTRAINT [PK_WQX_RESULTDETECTQUANTLIMIT]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_SUBMISSIONHISTORY]
	ADD CONSTRAINT [PK_WQX_SUBMISSIONHISTORY]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_TELEPHONIC]
	ADD CONSTRAINT [PK_WQX_TELEPHONIC]
	PRIMARY KEY ([RECORDID])
GO

ALTER TABLE [dbo].[WQX_ACTATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [FK_ACTIVITY_ACTATTBINOBJ]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITY]
	ADD CONSTRAINT [FK_ORG_ACTIVITY]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	ADD CONSTRAINT [FK_ACTIVITY_ACTACTGROUP]
	FOREIGN KEY([ACTIVITYPARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITYACTIVITYGROUP]
	ADD CONSTRAINT [FK_ACTIVITYGROUP_ACTACTGROUP]
	FOREIGN KEY([ACTIVITYGROUPPARENTID])
	REFERENCES [dbo].[WQX_ACTIVITYGROUP]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITYCONDUCTINGORG]
	ADD CONSTRAINT [FK_ACTIVITY_ACTCONDUCTINGORG]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITYGROUP]
	ADD CONSTRAINT [FK_ORG_ACTIVITYGROUP]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ACTIVITYMETRIC]
	ADD CONSTRAINT [FK_ACTIVITY_ACTIVITYMETRIC]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ALTMONLOC]
	ADD CONSTRAINT [FK_MONLOC_ALTMONLOC]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_MONITORINGLOCATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_BIOLOGICALHABITATINDEX]
	ADD CONSTRAINT [FK_ORG_BIOLOGICALHABITATINDEX]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_DELETES]
	ADD CONSTRAINT [FK_WQX_DELETES_WQX_ORGANIZATION]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ELECTRONICADDRESS]
	ADD CONSTRAINT [FK_ORG_ELECTRONICADDRESS]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_LABSAMPLEPREP]
	ADD CONSTRAINT [FK_RESULT_LABSAMPLEPREP]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_RESULT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_MONITORINGLOCATION]
	ADD CONSTRAINT [FK_ORG_MONITORINGLOCATION]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_MONLOCATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [FK_MONLOC_MONLOCATTBINOBJ]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_MONITORINGLOCATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_ORGADDRESS]
	ADD CONSTRAINT [FK_ORG_ORGADDRESS]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_PROJATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [FK_PROJECT_PROJATTBINOBJ]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_PROJECT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_PROJECT]
	ADD CONSTRAINT [FK_ORG_PROJECT]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	ADD CONSTRAINT [FK_PROJECT_PROJECTACTIVITY]
	FOREIGN KEY([PROJECTPARENTID])
	REFERENCES [dbo].[WQX_PROJECT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_PROJECTACTIVITY]
	ADD CONSTRAINT [FK_ACTIVITY_PROJECTACTIVITY]
	FOREIGN KEY([ACTIVITYPARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE NO ACTION 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_PROJECTMONLOC]
	ADD CONSTRAINT [FK_PROJECT_PROJECTMONLOC]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_PROJECT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_RESULT]
	ADD CONSTRAINT [FK_ACTIVITY_RESULT]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ACTIVITY]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_RESULTATTACHEDBINARYOBJECT]
	ADD CONSTRAINT [FK_RESULT_RESULTATTBINOBJ]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_RESULT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_RESULTDETECTQUANTLIMIT]
	ADD CONSTRAINT [FK_RESULT_RESULTDETQUANTLIMIT]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_RESULT]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO

ALTER TABLE [dbo].[WQX_TELEPHONIC]
	ADD CONSTRAINT [FK_ORG_TELEPHONIC]
	FOREIGN KEY([PARENTID])
	REFERENCES [dbo].[WQX_ORGANIZATION]([RECORDID])
	ON DELETE CASCADE 
	ON UPDATE NO ACTION 
GO
