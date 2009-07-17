ALTER TABLE THROW_AWAY.WQX_TELEPHONIC
    DROP CONSTRAINT FK_ORG_TELEPHONIC
/
ALTER TABLE THROW_AWAY.WQX_SUBMISSIONHISTORY
    DROP CONSTRAINT FK_WQX_SUBMISSIONHIST_WQX_ORG
/
ALTER TABLE THROW_AWAY.WQX_RESULTDETECTQUANTLIMIT
    DROP CONSTRAINT FK_RESULT_RESULTDETQUANTLIMIT
/
ALTER TABLE THROW_AWAY.WQX_RESULTATTACHEDBINARYOBJECT
    DROP CONSTRAINT FK_RESULT_RESULTATTBINOBJ
/
ALTER TABLE THROW_AWAY.WQX_RESULT
    DROP CONSTRAINT FK_ACTIVITY_RESULT
/
ALTER TABLE THROW_AWAY.WQX_PROJECTMONLOC
    DROP CONSTRAINT FK_PROJECT_PROJECTMONLOC
/
ALTER TABLE THROW_AWAY.WQX_PROJECTACTIVITY
    DROP CONSTRAINT FK_PROJECT_PROJECTACTIVITY
/
ALTER TABLE THROW_AWAY.WQX_PROJECTACTIVITY
    DROP CONSTRAINT FK_ACTIVITY_PROJECTACTIVITY
/
ALTER TABLE THROW_AWAY.WQX_PROJECT
    DROP CONSTRAINT FK_ORG_PROJECT
/
ALTER TABLE THROW_AWAY.WQX_PROJATTACHEDBINARYOBJECT
    DROP CONSTRAINT FK_PROJECT_PROJATTBINOBJ
/
ALTER TABLE THROW_AWAY.WQX_ORGADDRESS
    DROP CONSTRAINT FK_ORG_ORGADDRESS
/
ALTER TABLE THROW_AWAY.WQX_MONLOCATTACHEDBINARYOBJECT
    DROP CONSTRAINT FK_MONLOC_MONLOCATTBINOBJ
/
ALTER TABLE THROW_AWAY.WQX_MONITORINGLOCATION
    DROP CONSTRAINT FK_ORG_MONITORINGLOCATION
/
ALTER TABLE THROW_AWAY.WQX_LABSAMPLEPREP
    DROP CONSTRAINT FK_RESULT_LABSAMPLEPREP
/
ALTER TABLE THROW_AWAY.WQX_ELECTRONICADDRESS
    DROP CONSTRAINT FK_ORG_ELECTRONICADDRESS
/
ALTER TABLE THROW_AWAY.WQX_DELETES
    DROP CONSTRAINT FK_WQX_DELETES_WQX_ORG
/
ALTER TABLE THROW_AWAY.WQX_BIOLOGICALHABITATINDEX
    DROP CONSTRAINT FK_ORG_BIOLOGICALHABITATINDEX
/
ALTER TABLE THROW_AWAY.WQX_ALTMONLOC
    DROP CONSTRAINT FK_MONLOC_ALTMONLOC
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYMETRIC
    DROP CONSTRAINT FK_ACTIVITY_ACTIVITYMETRIC
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYGROUP
    DROP CONSTRAINT FK_ORG_ACTIVITYGROUP
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYCONDUCTINGORG
    DROP CONSTRAINT FK_ACTIVITY_ACTCONDUCTINGORG
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP
    DROP CONSTRAINT FK_ACTIVITY_ACTACTGROUP
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP
    DROP CONSTRAINT FK_ACTIVITYGROUP_ACTACTGROUP
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITY
    DROP CONSTRAINT FK_ORG_ACTIVITY
/
ALTER TABLE THROW_AWAY.WQX_ACTATTACHEDBINARYOBJECT
    DROP CONSTRAINT FK_ACTIVITY_ACTATTBINOBJ
/
ALTER TABLE THROW_AWAY.WQX_TELEPHONIC
    DROP CONSTRAINT PK_WQX_TELEPHONIC
/
ALTER TABLE THROW_AWAY.WQX_SUBMISSIONHISTORY
    DROP CONSTRAINT PK_WQX_SUBMISSIONHISTORY
/
ALTER TABLE THROW_AWAY.WQX_RESULTDETECTQUANTLIMIT
    DROP CONSTRAINT PK_WQX_RESULTDETECTQUANTLIMIT
/
ALTER TABLE THROW_AWAY.WQX_RESULTATTACHEDBINARYOBJECT
    DROP CONSTRAINT PK_WQX_RESULTATTBINARYOBJECT
/
ALTER TABLE THROW_AWAY.WQX_RESULT
    DROP CONSTRAINT PK_WQX_RESULT
/
ALTER TABLE THROW_AWAY.WQX_PROJECTMONLOC
    DROP CONSTRAINT PK_WQX_PROJECTMONLOC
/
ALTER TABLE THROW_AWAY.WQX_PROJECTACTIVITY
    DROP CONSTRAINT PK_WQX_PROJECTACTIVITY
/
ALTER TABLE THROW_AWAY.WQX_PROJECT
    DROP CONSTRAINT PK_WQX_PROJECT
/
ALTER TABLE THROW_AWAY.WQX_PROJATTACHEDBINARYOBJECT
    DROP CONSTRAINT PK_WQX_PROJATTBINARYOBJECT
/
ALTER TABLE THROW_AWAY.WQX_ORGANIZATION
    DROP CONSTRAINT PK_WQX_ORGANIZATION
/
ALTER TABLE THROW_AWAY.WQX_ORGADDRESS
    DROP CONSTRAINT PK_WQX_ORGADDRESS
/
ALTER TABLE THROW_AWAY.WQX_MONLOCATTACHEDBINARYOBJECT
    DROP CONSTRAINT PK_WQX_MONLOCATTBINARYOBJECT
/
ALTER TABLE THROW_AWAY.WQX_MONITORINGLOCATION
    DROP CONSTRAINT PK_WQX_MONITORINGLOCATION
/
ALTER TABLE THROW_AWAY.WQX_LABSAMPLEPREP
    DROP CONSTRAINT PK_WQX_LABSAMPLEPREP
/
ALTER TABLE THROW_AWAY.WQX_ELECTRONICADDRESS
    DROP CONSTRAINT PK_WQX_ELECTRONICADDRESS
/
ALTER TABLE THROW_AWAY.WQX_DELETES
    DROP CONSTRAINT PK_WQX_DELETES
/
ALTER TABLE THROW_AWAY.WQX_BIOLOGICALHABITATINDEX
    DROP CONSTRAINT PK_WQX_BIOLOGICALHABITATINDEX
/
ALTER TABLE THROW_AWAY.WQX_ALTMONLOC
    DROP CONSTRAINT PK_WQX_ALTMONLOC
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYMETRIC
    DROP CONSTRAINT PK_WQX_ACTIVITYMETRIC
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYGROUP
    DROP CONSTRAINT PK_WQX_ACTIVITYGROUP
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYCONDUCTINGORG
    DROP CONSTRAINT PK_WQX_ACTIVITYCONDUCTINGORG
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP
    DROP CONSTRAINT PK_WQX_ACTIVITYACTIVITYGROUP
/
ALTER TABLE THROW_AWAY.WQX_ACTIVITY
    DROP CONSTRAINT PK_WQX_ACTIVITY
/
ALTER TABLE THROW_AWAY.WQX_ACTATTACHEDBINARYOBJECT
    DROP CONSTRAINT PK_WQX_ACTATTBINARYOBJECT
/
DROP TABLE THROW_AWAY.WQX_TELEPHONIC
/
DROP TABLE THROW_AWAY.WQX_SUBMISSIONHISTORY
/
DROP TABLE THROW_AWAY.WQX_RESULTDETECTQUANTLIMIT
/
DROP TABLE THROW_AWAY.WQX_RESULTATTACHEDBINARYOBJECT
/
DROP TABLE THROW_AWAY.WQX_RESULT
/
DROP TABLE THROW_AWAY.WQX_PROJECTMONLOC
/
DROP TABLE THROW_AWAY.WQX_PROJECTACTIVITY
/
DROP TABLE THROW_AWAY.WQX_PROJECT
/
DROP TABLE THROW_AWAY.WQX_PROJATTACHEDBINARYOBJECT
/
DROP TABLE THROW_AWAY.WQX_ORGANIZATION
/
DROP TABLE THROW_AWAY.WQX_ORGADDRESS
/
DROP TABLE THROW_AWAY.WQX_MONLOCATTACHEDBINARYOBJECT
/
DROP TABLE THROW_AWAY.WQX_MONITORINGLOCATION
/
DROP TABLE THROW_AWAY.WQX_LABSAMPLEPREP
/
DROP TABLE THROW_AWAY.WQX_ELECTRONICADDRESS
/
DROP TABLE THROW_AWAY.WQX_DELETES
/
DROP TABLE THROW_AWAY.WQX_BIOLOGICALHABITATINDEX
/
DROP TABLE THROW_AWAY.WQX_ALTMONLOC
/
DROP TABLE THROW_AWAY.WQX_ACTIVITYMETRIC
/
DROP TABLE THROW_AWAY.WQX_ACTIVITYGROUP
/
DROP TABLE THROW_AWAY.WQX_ACTIVITYCONDUCTINGORG
/
DROP TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP
/
DROP TABLE THROW_AWAY.WQX_ACTIVITY
/
DROP TABLE THROW_AWAY.WQX_ACTATTACHEDBINARYOBJECT
/





CREATE TABLE THROW_AWAY.WQX_ORGANIZATION(
    RECORDID varchar2(50) NOT NULL,
    ORGID varchar2(30) NOT NULL,
    ORGFORMALNAME varchar2(120) NOT NULL,
    ORGDESC varchar2(500) NULL,
    TRIBALCODE varchar2(3) NULL,
    CONSTRAINT PK_WQX_ORGANIZATION PRIMARY KEY  (RECORDID))
/





CREATE TABLE THROW_AWAY.WQX_PROJECTACTIVITY(
    RECORDID varchar2(50) NOT NULL,
    PROJECTPARENTID varchar2(50) NOT NULL,
    ACTIVITYPARENTID varchar2(50) NOT NULL,
 CONSTRAINT PK_WQX_PROJECTACTIVITY PRIMARY KEY  
(
    RECORDID 
))
/





CREATE TABLE THROW_AWAY.WQX_PROJECTMONLOC(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    MONLOCID varchar2(35) NOT NULL,
    LOCWEIGHTINGFACMEASURE varchar2(12) NOT NULL,
    LOCWEIGHTINGFACMEASUREUNIT varchar2(12) NOT NULL,
    STATISTICALSTRATUM varchar2(15) NULL,
    LOCATIONCATERY varchar2(50) NULL,
    LOCATIONSTATUS varchar2(15) NULL,
    REFLOCATIONTYPECODE varchar2(20) NULL,
    REFLOCATIONSTARTDATE date NULL,
    REFLOCATIONENDDATE date NULL,
    RESOURCETITLE varchar2(120) NULL,
    RESOURCECREATOR varchar2(120) NULL,
    RESOURCESUBJECT varchar2(500) NULL,
    RESOURCEPUBLISHER varchar2(60) NULL,
    RESOURCEDATE date NULL,
    RESOURCEID varchar2(255) NULL,
    PROJMONLOCCOMMENT varchar2(4000) NULL,
 CONSTRAINT PK_WQX_PROJECTMONLOC PRIMARY KEY  
(
    RECORDID ) )

/




CREATE TABLE THROW_AWAY.WQX_PROJATTACHEDBINARYOBJECT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    BINARYOBJECTFILE varchar2(255) NOT NULL,
    BINARYOBJECTFILETYPECODE varchar2(6) NOT NULL,
 CONSTRAINT PK_WQX_PROJATTBINARYOBJECT PRIMARY KEY  
(
    RECORDID 
)) 

/




CREATE TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP(
    RECORDID varchar2(50) NOT NULL,
    ACTIVITYPARENTID varchar2(50) NOT NULL,
    ACTIVITYGROUPPARENTID varchar2(50) NOT NULL,
    ACTIVITYID varchar2(35) NOT NULL,
 CONSTRAINT PK_WQX_ACTIVITYACTIVITYGROUP PRIMARY KEY  
(
    RECORDID 
))
/





CREATE TABLE THROW_AWAY.WQX_RESULT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    DATALOGGERLINENAME varchar2(15) NULL,
    RESULTDETECTIONCONDITION varchar2(35) NULL,
    CHARACTERISTICNAME varchar2(120) NULL,
    METHODSPECIATIONNAME varchar2(20) NULL,
    RESULTSAMPFRACTION varchar2(25) NULL,
    RESULTMEASURE varchar2(60) NULL,
    RESULTMEASUREUNIT varchar2(12) NULL,
    RESULTMEASUREQUALIFIERCODE varchar2(5) NULL,
    STATUSID varchar2(12) NULL,
    STATISTICALBASECODE varchar2(25) NULL,
    VALUETYPE varchar2(20) NULL,
    WEIGHTBASIS varchar2(15) NULL,
    TIMEBASIS varchar2(12) NULL,
    TEMPERATUREBASIS varchar2(12) NULL,
    PARTICLESIZEBASIS varchar2(15) NULL,
    PRECISIONVALUE varchar2(60) NULL,
    BIASVALUE varchar2(60) NULL,
    CONFIDENCEINTERVALVALUE varchar2(15) NULL,
    UPPERCONFIDENCELIMITVALUE varchar2(15) NULL,
    LOWERCONFIDENCELIMITVALUE varchar2(15) NULL,
    RESULTCOMMENT varchar2(4000) NULL,
    DEPTHHEIGHTMEASURE varchar2(12) NULL,
    DEPTHHEIGHTMEASUREUNIT varchar2(12) NULL,
    DEPTHALTITUDEREFPOINT varchar2(125) NULL,
    RESULTSAMPPOINT varchar2(12) NULL,
    BIORESULTINTENT varchar2(35) NULL,
    BIORESULTINDIVIDUALID varchar2(4) NULL,
    BIORESULTSUBJECTTAXONOMIC varchar2(120) NULL,
    BIORESULTUNIDENTIFIEDSPECIESID varchar2(120) NULL,
    BIORESULTSAMPTISSUEANATOMY varchar2(30) NULL,
    GRPSUMMCOUNTWEIGHTMEASURE varchar2(12) NULL,
    GRPSUMMCOUNTWEIGHTMEASUREUNIT varchar2(12) NULL,
    TAXDETAILSCELLFORM varchar2(11) NULL,
    TAXDETAILSCELLSHAPE varchar2(18) NULL,
    TAXDETAILSHABITNAME varchar2(15) NULL,
    TAXDETAILSVOLTINISM varchar2(25) NULL,
    TAXDETAILSPOLLTOLERANCE varchar2(4) NULL,
    TAXDETAILSPOLLTOLERANCESCALE varchar2(50) NULL,
    TAXDETAILSTROPHICLEVEL varchar2(4) NULL,
    TAXDETAILSFUNCFEEDINGGROUP varchar2(6) NULL,
    CITATIONRESOURCETITLE varchar2(120) NULL,
    CITATIONRESOURCECREATOR varchar2(120) NULL,
    CITATIONRESOURCESUBJECT varchar2(500) NULL,
    CITATIONRESOURCEPUBLISHER varchar2(60) NULL,
    CITATIONRESOURCEDATE date NULL,
    CITATIONRESOURCEID varchar2(255) NULL,
    FREQCLASSDESCCODE varchar2(50) NULL,
    FREQCLASSDESCUNITCODE varchar2(12) NULL,
    FREQCLASSLOWERBOUNDVALUE varchar2(8) NULL,
    FREQCLASSUPPERBOUNDVALUE varchar2(8) NULL,
    ANALYTICALMETHODID varchar2(20) NULL,
    ANALYTICALMETHODIDCONTEXT varchar2(120) NULL,
    ANALYTICALMETHODNAME varchar2(120) NULL,
    ANALYTICALMETHODQUALIFIERTYPE varchar2(25) NULL,
    ANALYTICALMETHODDESC varchar2(500) NULL,
    LABNAME varchar2(60) NULL,
    LABANALYSISSTARTDATE date NULL,
    LABANALYSISSTARTTIME varchar2(20) NULL,
    LABANALYSISSTARTTIMEZONECODE varchar2(4) NULL,
    LABANALYSISENDDATE date NULL,
    LABANALYSISENDTIME varchar2(20) NULL,
    LABANALYSISENDTIMEZONECODE varchar2(4) NULL,
    RESULTLABCOMMENTCODE varchar2(3) NULL,
    LABACCIND char(1) NULL,
    LABACCAUTHORITYNAME varchar2(20) NULL,
    LABTAXACCIND char(1) NULL,
    LABTAXACCAUTHORITYNAME varchar2(20) NULL,
 CONSTRAINT PK_WQX_RESULT PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_ACTATTACHEDBINARYOBJECT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    BINARYOBJECTFILE varchar2(255) NOT NULL,
    BINARYOBJECTFILETYPECODE varchar2(6) NOT NULL,
 CONSTRAINT PK_WQX_ACTATTBINARYOBJECT PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_ACTIVITYCONDUCTINGORG(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    ACTIVITYID varchar2(35) NOT NULL,
    ACTIVITYCONDUCTINGORG varchar2(120) NOT NULL,
 CONSTRAINT PK_WQX_ACTIVITYCONDUCTINGORG PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_ACTIVITYMETRIC(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    METRICTYPEID varchar2(35) NOT NULL,
    METRICTYPEIDCONTEXT varchar2(50) NOT NULL,
    METRICTYPENAME varchar2(50) NULL,
    CITATIONRESOURCETITLE varchar2(120) NULL,
    CITATIONRESOURCECREATOR varchar2(120) NULL,
    CITATIONRESOURCESUBJECT varchar2(500) NULL,
    CITATIONRESOURCEPUBLISHER varchar2(60) NULL,
    CITATIONRESOURCEDATE date NULL,
    CITATIONRESOURCEID varchar2(255) NULL,
    METRICTYPESCALE varchar2(50) NULL,
    METRICTYPEFORMULADESC varchar2(50) NULL,
    METRICVALUEMEASURE varchar2(12) NULL,
    METRICVALUEMEASUREUNIT varchar2(12) NULL,
    METRICSCORE varchar2(10) NULL,
    METRICCOMMENT varchar2(4000) NULL,
    METRICINDEXID varchar2(35) NULL,
 CONSTRAINT PK_WQX_ACTIVITYMETRIC PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_RESULTATTACHEDBINARYOBJECT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    BINARYOBJECTFILE varchar2(255) NOT NULL,
    BINARYOBJECTFILETYPECODE varchar2(6) NOT NULL,
 CONSTRAINT PK_WQX_RESULTATTBINARYOBJECT PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_RESULTDETECTQUANTLIMIT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    DETECTQUANTLIMITTYPE varchar2(35) NOT NULL,
    DETECTQUANTLIMITMEASURE varchar2(12) NULL,
    DETECTQUANTLIMITMEASUNITCODE varchar2(12) NULL,
 CONSTRAINT PK_WQX_RESULTDETECTQUANTLIMIT PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_LABSAMPLEPREP(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    METHODID varchar2(20) NOT NULL,
    METHODIDCONTEXT varchar2(120) NOT NULL,
    METHODNAME varchar2(120) NOT NULL,
    METHODQUALIFIERTYPE varchar2(25) NULL,
    METHODDESC varchar2(500) NULL,
    PREPSTARTDATE date NULL,
    PREPSTARTTIME varchar2(20) NULL,
    PREPSTARTTIMEZONECODE varchar2(4) NULL,
    PREPENDDATE date NULL,
    PREPENDTIME varchar2(20) NULL,
    PREPENDTIMEZONECODE varchar2(4) NULL,
    SUBSTANCEDILUTIONFACTOR varchar2(10) NULL,
 CONSTRAINT PK_WQX_LABSAMPLEPREP PRIMARY KEY  
(
    RECORDID 
))
/





CREATE TABLE THROW_AWAY.WQX_ACTIVITY(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    ACTIVITYID varchar2(35) NOT NULL,
    ACTIVITYTYPECODE varchar2(70) NOT NULL,
    ACTIVITYMEDIA varchar2(20) NOT NULL,
    ACTIVITYMEDIASUBDIVISION varchar2(45) NULL,
    ACTIVITYSTARTDATE date NOT NULL,
    STARTTIME varchar2(20) NULL,
    STARTTIMEZONE varchar2(4) NULL,
    ACTIVITYENDDATE date NULL,
    ENDTIME varchar2(20) NULL,
    ENDTIMEZONE varchar2(4) NULL,
    RELATIVEDEPTH varchar2(15) NULL,
    DEPTHHEIGHTMEASURE varchar2(12) NULL,
    DEPTHHEIGHTMEASUREUNIT varchar2(12) NULL,
    TOPDEPTHHEIGHTMEASURE varchar2(12) NULL,
    TOPDEPTHHEIGHTMEASUREUNIT varchar2(12) NULL,
    BOTTOMDEPTHHEIGHTMEASURE varchar2(12) NULL,
    BOTTOMDEPTHHEIGHTMEASUREUNIT varchar2(12) NULL,
    DEPTHALTITUDEREFPOINT varchar2(125) NULL,
    MONLOCID varchar2(35) NULL,
    ACTIVITYCOMMENT varchar2(4000) NULL,
    LATITUDEMEASURE varchar2(30) NULL,
    LONGITUDEMEASURE varchar2(30) NULL,
    SOURCEMAPSCALE varchar2(12) NULL,
    HORIZACCURACYMEASURE varchar2(12) NULL,
    HORIZACCURACYMEASUREUNIT varchar2(12) NULL,
    HORIZCOLLMETHOD varchar2(150) NULL,
    HORIZCOORDREFSYSDATUM varchar2(6) NULL,
    BIOACTIVITYASSEMBLAGESAMPD varchar2(50) NULL,
    BIOHABCOLLDURATIONMEASURE varchar2(12) NULL,
    BIOHABCOLLDURATIONMEASUREUNIT varchar2(12) NULL,
    BIOHABSAMPCOMP varchar2(15) NULL,
    BIOHABSAMPCOMPPLACEINSERIES varchar2(12) NULL,
    BIOHABREACHLENGTHMEASURE varchar2(12) NULL,
    BIOHABREACHLENGTHMEASUREUNIT varchar2(12) NULL,
    BIOHABREACHWIDTHMEASURE varchar2(12) NULL,
    BIOHABREACHWIDTHMEASUREUNIT varchar2(12) NULL,
    BIOHABPASSCOUNT varchar2(12) NULL,
    BIOHABNETTYPE varchar2(30) NULL,
    BIOHABNETSURFACEAREAMEASURE varchar2(12) NULL,
    BIOHABNETSURFACEMEASUREUNIT varchar2(12) NULL,
    BIOHABNETMESHSIZEMEASURE varchar2(12) NULL,
    BIOHABNETMESHMEASUREUNIT varchar2(12) NULL,
    BIOHABNETBOATSPEEDMEASURE varchar2(12) NULL,
    BIOHABNETBOATSPEEDMEASUREUNIT varchar2(12) NULL,
    BIOHABNETCURRSPEEDMEASURE varchar2(12) NULL,
    BIOHABNETCURRSPEEDMEASUREUNIT varchar2(12) NULL,
    BIOACTIVITYTOXICITYTESTTYPE varchar2(7) NULL,
    SAMPCOLLMETHODID varchar2(20) NULL,
    SAMPCOLLMETHODIDCONTEXT varchar2(120) NULL,
    SAMPCOLLMETHOD varchar2(120) NULL,
    SAMPCOLLMETHODQUALIFIER varchar2(25) NULL,
    SAMPCOLLMETHODDESC varchar2(500) NULL,
    SAMPCOLLEQUIPMENT varchar2(40) NULL,
    SAMPCOLLEQUIPMENTCOMMENT varchar2(4000) NULL,
    SAMPPREPID varchar2(20) NULL,
    SAMPPREPIDCONTEXT varchar2(120) NULL,
    SAMPPREP varchar2(120) NULL,
    SAMPPREPQUALIFIERTYPE varchar2(25) NULL,
    SAMPPREPDESC varchar2(500) NULL,
    SAMPPREPCONTTYPE varchar2(35) NULL,
    SAMPPREPCONTCOLOR varchar2(15) NULL,
    SAMPPREPCONTCHEMPRESERVUSED varchar2(250) NULL,
    SAMPPREPCONTTHERMALPRESERVUSED varchar2(25) NULL,
    SAMPPREPCONTSAMPTRANSSTORDESC varchar2(250) NULL,
    RESULTCOUNT varchar2(255) NULL,
    WQXUPDATEDATE date NOT NULL,
    TMPACTIVITYTYPE varchar2(50) NULL,
    TMPPROJECTID varchar2(50) NULL,
 CONSTRAINT PK_WQX_ACTIVITY PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_MONITORINGLOCATION(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    MONITORINGLOCATIONID varchar2(35) NOT NULL,
    MONLOCNAME varchar2(255) NOT NULL,
    MONLOCTYPE varchar2(45) NOT NULL,
    MONLOCDESC varchar2(1999) NULL,
    HUCEIGHTDIGITCODE varchar2(8) NULL,
    HUCTWELVEDIGITCODE varchar2(12) NULL,
    TRIBALLANDIND char(1) NOT NULL,
    TRIBALLANDNAME varchar2(200) NULL,
    LATITUDEMEASURE varchar2(30) NOT NULL,
    LONGITUDEMEASURE varchar2(30) NOT NULL,
    SOURCEMAPSCALE int NULL,
    HORIZACCURACYMEASURE varchar2(12) NULL,
    HORIZACCURACYMEASUREUNIT varchar2(12) NULL,
    HORIZCOLLMETHOD varchar2(150) NOT NULL,
    HORIZCOORDREFSYSDATUM varchar2(6) NOT NULL,
    VERTICALMEASURE varchar2(12) NULL,
    VERTICALMEASUREUNIT varchar2(12) NULL,
    VERTICALCOLLMETHOD varchar2(50) NULL,
    VERTICALCOORDREFSYSDATUM varchar2(10) NULL,
    COUNTRYCODE varchar2(2) NULL,
    STATECODE varchar2(2) NULL,
    COUNTYCODE varchar2(3) NULL,
    WELLTYPE varchar2(255) NULL,
    AQUIFERNAME varchar2(120) NULL,
    FORMATIONTYPE varchar2(50) NULL,
    WELLHOLEDEPTHMEASURE varchar2(12) NULL,
    WELLHOLEDEPTHMEASUREUNIT varchar2(12) NULL,
    WQXUPDATEDATE date NOT NULL,
 CONSTRAINT PK_WQX_MONITORINGLOCATION PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_ORGADDRESS(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    ADDRESSTYPE varchar2(8) NULL,
    ADDRESS varchar2(50) NOT NULL,
    SUPPLEMENTALADDRESS varchar2(120) NULL,
    LOCALITY varchar2(30) NULL,
    STATECODE varchar2(2) NULL,
    POSTALCODE varchar2(10) NULL,
    COUNTRYCODE varchar2(2) NULL,
    COUNTYCODE varchar2(3) NULL,
 CONSTRAINT PK_WQX_ORGADDRESS PRIMARY KEY  
(
    RECORDID 
)) 
/





CREATE TABLE THROW_AWAY.WQX_DELETES(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    COMPONENT varchar2(50) NOT NULL,
    IDENTIFIER varchar2(50) NOT NULL,
    WQXUPDATEDATE date NOT NULL,
 CONSTRAINT PK_WQX_DELETES PRIMARY KEY  
(
    RECORDID 
)) 

/




CREATE TABLE THROW_AWAY.WQX_SUBMISSIONHISTORY(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    SCHEDULERUNDATE date NOT NULL,
    WQXUPDATEDATE date NOT NULL,
    SUBMISSIONTYPE varchar2(13) NOT NULL,
    LOCALTRANSACTIONID varchar2(50) NOT NULL,
    CDXPROCESSINGSTATUS varchar2(50) NOT NULL,
 CONSTRAINT PK_WQX_SUBMISSIONHISTORY PRIMARY KEY  
(
    RECORDID 
)) 
/

CREATE TABLE THROW_AWAY.WQX_TELEPHONIC(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    TELEPHONENUMBER varchar2(15) NOT NULL,
    TELEPHONENUMBERTYPE varchar2(6) NULL,
    TELEPHONEEXT varchar2(6) NULL,
 CONSTRAINT PK_WQX_TELEPHONIC PRIMARY KEY  
(
    RECORDID)) 
/

CREATE TABLE THROW_AWAY.WQX_BIOLOGICALHABITATINDEX(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    INDEXID varchar2(35) NOT NULL,
    INDEXTYPEID varchar2(35) NOT NULL,
    INDEXTYPEIDCONTEXT varchar2(50) NOT NULL,
    INDEXTYPENAME varchar2(50) NOT NULL,
    RESOURCETITLE varchar2(120) NULL,
    RESOURCECREATOR varchar2(120) NULL,
    RESOURCESUBJECT varchar2(500) NULL,
    RESOURCEPUBLISHER varchar2(60) NULL,
    RESOURCEDATE varchar2(10) NULL,
    RESOURCEID varchar2(255) NULL,
    INDEXTYPESCALE varchar2(50) NULL,
    INDEXSCORE varchar2(10) NOT NULL,
    INDEXQUALIFIERCODE varchar2(5) NULL,
    INDEXCOMMENT varchar2(4000) NULL,
    INDEXCALCULATEDDATE varchar2(10) NULL,
    MONLOCID varchar2(35) NOT NULL,
    WQXUPDATEDATE date NOT NULL,
 CONSTRAINT PK_WQX_BIOLOGICALHABITATINDEX PRIMARY KEY  
(
    RECORDID 
)) 
/

CREATE TABLE THROW_AWAY.WQX_ELECTRONICADDRESS(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    ELECTRONICADDRESS varchar2(120) NOT NULL,
    ELECTRONICADDRESSTYPE varchar2(8) NULL,
 CONSTRAINT PK_WQX_ELECTRONICADDRESS PRIMARY KEY  
(
    RECORDID)) 
/

CREATE TABLE THROW_AWAY.WQX_ACTIVITYGROUP(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    ACTIVITYGROUPID varchar2(35) NOT NULL,
    ACTIVITYGROUPNAME varchar2(50) NOT NULL,
    ACTIVITYGROUPTYPECODE varchar2(50) NOT NULL,
    ACTIVITYID varchar2(35) NOT NULL,
    WQXUPDATEDATE date NOT NULL,
 CONSTRAINT PK_WQX_ACTIVITYGROUP PRIMARY KEY  
(
    RECORDID)) 
/

CREATE TABLE THROW_AWAY.WQX_PROJECT(
    RECORDID varchar2(50) NOT NULL ,
    PARENTID varchar2(50) NOT NULL,
    PROJECTID varchar2(35) NOT NULL,
    PROJECTNAME varchar2(120) NOT NULL,
    PROJECTDESC varchar2(1999) NULL,
    SAMPLINGDESIGNTYPECODE varchar2(20) NULL,
    QAPPAPPROVEDIND char(1) NULL,
    QAPPAPPROVALAGENCYNAME varchar2(50) NULL,
    WQXUPDATEDATE date NOT NULL,
 CONSTRAINT PK_WQX_PROJECT PRIMARY KEY  
(
    RECORDID)) 
/

CREATE TABLE THROW_AWAY.WQX_MONLOCATTACHEDBINARYOBJECT(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    BINARYOBJECTFILE varchar2(255) NOT NULL,
    BINARYOBJECTFILETYPECODE varchar2(6) NOT NULL,
 CONSTRAINT PK_WQX_MONLOCATTBINARYOBJECT PRIMARY KEY  
(
    RECORDID)) 
/

CREATE TABLE THROW_AWAY.WQX_ALTMONLOC(
    RECORDID varchar2(50) NOT NULL,
    PARENTID varchar2(50) NOT NULL,
    MONLOCID varchar2(35) NOT NULL,
    MONLOCIDCONTEXT varchar2(120) NOT NULL,
 CONSTRAINT PK_WQX_ALTMONLOC PRIMARY KEY  
(
    RECORDID)) 
/

ALTER TABLE THROW_AWAY.WQX_PROJECTACTIVITY   ADD  CONSTRAINT FK_ACTIVITY_PROJECTACTIVITY FOREIGN KEY(ACTIVITYPARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
/

ALTER TABLE THROW_AWAY.WQX_PROJECTACTIVITY  ADD  CONSTRAINT FK_PROJECT_PROJECTACTIVITY FOREIGN KEY(PROJECTPARENTID)
REFERENCES THROW_AWAY.WQX_PROJECT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_PROJECTMONLOC   ADD  CONSTRAINT FK_PROJECT_PROJECTMONLOC FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_PROJECT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_PROJATTACHEDBINARYOBJECT  ADD  CONSTRAINT FK_PROJECT_PROJATTBINOBJ FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_PROJECT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP   ADD  CONSTRAINT FK_ACTIVITY_ACTACTGROUP FOREIGN KEY(ACTIVITYPARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITYACTIVITYGROUP   ADD  CONSTRAINT FK_ACTIVITYGROUP_ACTACTGROUP FOREIGN KEY(ACTIVITYGROUPPARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITYGROUP (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_RESULT   ADD  CONSTRAINT FK_ACTIVITY_RESULT FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTATTACHEDBINARYOBJECT  ADD  CONSTRAINT FK_ACTIVITY_ACTATTBINOBJ FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITYCONDUCTINGORG   ADD  CONSTRAINT FK_ACTIVITY_ACTCONDUCTINGORG FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITYMETRIC   ADD  CONSTRAINT FK_ACTIVITY_ACTIVITYMETRIC FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ACTIVITY (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_RESULTATTACHEDBINARYOBJECT  ADD  CONSTRAINT FK_RESULT_RESULTATTBINOBJ FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_RESULT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_RESULTDETECTQUANTLIMIT  ADD  CONSTRAINT FK_RESULT_RESULTDETQUANTLIMIT FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_RESULT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_LABSAMPLEPREP  ADD  CONSTRAINT FK_RESULT_LABSAMPLEPREP FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_RESULT (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITY  ADD  CONSTRAINT FK_ORG_ACTIVITY FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/
ALTER TABLE THROW_AWAY.WQX_MONITORINGLOCATION  ADD  CONSTRAINT FK_ORG_MONITORINGLOCATION FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ORGADDRESS  ADD  CONSTRAINT FK_ORG_ORGADDRESS FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_DELETES   ADD  CONSTRAINT FK_WQX_DELETES_WQX_ORG FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
/

ALTER TABLE THROW_AWAY.WQX_SUBMISSIONHISTORY   ADD  CONSTRAINT FK_WQX_SUBMISSIONHIST_WQX_ORG FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
/

ALTER TABLE THROW_AWAY.WQX_TELEPHONIC   ADD  CONSTRAINT FK_ORG_TELEPHONIC FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_BIOLOGICALHABITATINDEX   ADD  CONSTRAINT FK_ORG_BIOLOGICALHABITATINDEX FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ELECTRONICADDRESS  ADD  CONSTRAINT FK_ORG_ELECTRONICADDRESS FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ACTIVITYGROUP  ADD  CONSTRAINT FK_ORG_ACTIVITYGROUP FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
/

ALTER TABLE THROW_AWAY.WQX_PROJECT   ADD  CONSTRAINT FK_ORG_PROJECT FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_ORGANIZATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_MONLOCATTACHEDBINARYOBJECT  ADD  CONSTRAINT FK_MONLOC_MONLOCATTBINOBJ FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_MONITORINGLOCATION (RECORDID)
ON DELETE CASCADE
/

ALTER TABLE THROW_AWAY.WQX_ALTMONLOC   ADD  CONSTRAINT FK_MONLOC_ALTMONLOC FOREIGN KEY(PARENTID)
REFERENCES THROW_AWAY.WQX_MONITORINGLOCATION (RECORDID)
ON DELETE CASCADE
/