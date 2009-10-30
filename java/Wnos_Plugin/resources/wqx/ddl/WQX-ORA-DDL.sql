CREATE TABLE WQX_ACTATTACHEDBINARYOBJECT ( 
	RECORDID                	VARCHAR2(50) NOT NULL,
	PARENTID                	VARCHAR2(50) NOT NULL,
	BINARYOBJECTFILE        	VARCHAR2(255) NOT NULL,
	BINARYOBJECTFILETYPECODE	VARCHAR2(6) NOT NULL,
	BINARYOBJECTCONTENT     	BLOB NULL 
	)
/

CREATE TABLE WQX_ACTIVITY ( 
	RECORDID                      	VARCHAR2(50) NOT NULL,
	PARENTID                      	VARCHAR2(50) NOT NULL,
	ACTIVITYID                    	VARCHAR2(35) NOT NULL,
	ACTIVITYTYPECODE              	VARCHAR2(70) NOT NULL,
	ACTIVITYMEDIA                 	VARCHAR2(20) NOT NULL,
	ACTIVITYMEDIASUBDIVISION      	VARCHAR2(45) NULL,
	ACTIVITYSTARTDATE             	DATE NOT NULL,
	STARTTIME                     	VARCHAR2(20) NULL,
	STARTTIMEZONE                 	VARCHAR2(4) NULL,
	ACTIVITYENDDATE               	DATE NULL,
	ENDTIME                       	VARCHAR2(20) NULL,
	ENDTIMEZONE                   	VARCHAR2(4) NULL,
	RELATIVEDEPTH                 	VARCHAR2(15) NULL,
	DEPTHHEIGHTMEASURE            	VARCHAR2(12) NULL,
	DEPTHHEIGHTMEASUREUNIT        	VARCHAR2(12) NULL,
	TOPDEPTHHEIGHTMEASURE         	VARCHAR2(12) NULL,
	TOPDEPTHHEIGHTMEASUREUNIT     	VARCHAR2(12) NULL,
	BOTTOMDEPTHHEIGHTMEASURE      	VARCHAR2(12) NULL,
	BOTTOMDEPTHHEIGHTMEASUREUNIT  	VARCHAR2(12) NULL,
	DEPTHALTITUDEREFPOINT         	VARCHAR2(125) NULL,
	MONLOCID                      	VARCHAR2(35) NULL,
	ACTIVITYCOMMENT               	VARCHAR2(4000) NULL,
	LATITUDEMEASURE               	VARCHAR2(30) NULL,
	LONGITUDEMEASURE              	VARCHAR2(30) NULL,
	SOURCEMAPSCALE                	VARCHAR2(12) NULL,
	HORIZACCURACYMEASURE          	VARCHAR2(12) NULL,
	HORIZACCURACYMEASUREUNIT      	VARCHAR2(12) NULL,
	HORIZCOLLMETHOD               	VARCHAR2(150) NULL,
	HORIZCOORDREFSYSDATUM         	VARCHAR2(6) NULL,
	BIOACTIVITYASSEMBLAGESAMPD    	VARCHAR2(50) NULL,
	BIOHABCOLLDURATIONMEASURE     	VARCHAR2(12) NULL,
	BIOHABCOLLDURATIONMEASUREUNIT 	VARCHAR2(12) NULL,
	BIOHABSAMPCOMP                	VARCHAR2(15) NULL,
	BIOHABSAMPCOMPPLACEINSERIES   	VARCHAR2(12) NULL,
	BIOHABREACHLENGTHMEASURE      	VARCHAR2(12) NULL,
	BIOHABREACHLENGTHMEASUREUNIT  	VARCHAR2(12) NULL,
	BIOHABREACHWIDTHMEASURE       	VARCHAR2(12) NULL,
	BIOHABREACHWIDTHMEASUREUNIT   	VARCHAR2(12) NULL,
	BIOHABPASSCOUNT               	VARCHAR2(12) NULL,
	BIOHABNETTYPE                 	VARCHAR2(30) NULL,
	BIOHABNETSURFACEAREAMEASURE   	VARCHAR2(12) NULL,
	BIOHABNETSURFACEMEASUREUNIT   	VARCHAR2(12) NULL,
	BIOHABNETMESHSIZEMEASURE      	VARCHAR2(12) NULL,
	BIOHABNETMESHMEASUREUNIT      	VARCHAR2(12) NULL,
	BIOHABNETBOATSPEEDMEASURE     	VARCHAR2(12) NULL,
	BIOHABNETBOATSPEEDMEASUREUNIT 	VARCHAR2(12) NULL,
	BIOHABNETCURRSPEEDMEASURE     	VARCHAR2(12) NULL,
	BIOHABNETCURRSPEEDMEASUREUNIT 	VARCHAR2(12) NULL,
	BIOACTIVITYTOXICITYTESTTYPE   	VARCHAR2(7) NULL,
	SAMPCOLLMETHODID              	VARCHAR2(20) NULL,
	SAMPCOLLMETHODIDCONTEXT       	VARCHAR2(120) NULL,
	SAMPCOLLMETHOD                	VARCHAR2(120) NULL,
	SAMPCOLLMETHODQUALIFIER       	VARCHAR2(25) NULL,
	SAMPCOLLMETHODDESC            	VARCHAR2(500) NULL,
	SAMPCOLLEQUIPMENT             	VARCHAR2(40) NULL,
	SAMPCOLLEQUIPMENTCOMMENT      	VARCHAR2(4000) NULL,
	SAMPPREPID                    	VARCHAR2(20) NULL,
	SAMPPREPIDCONTEXT             	VARCHAR2(120) NULL,
	SAMPPREP                      	VARCHAR2(120) NULL,
	SAMPPREPQUALIFIERTYPE         	VARCHAR2(25) NULL,
	SAMPPREPDESC                  	VARCHAR2(500) NULL,
	SAMPPREPCONTTYPE              	VARCHAR2(35) NULL,
	SAMPPREPCONTCOLOR             	VARCHAR2(15) NULL,
	SAMPPREPCONTCHEMPRESERVUSED   	VARCHAR2(250) NULL,
	SAMPPREPCONTTHERMALPRESERVUSED	VARCHAR2(25) NULL,
	SAMPPREPCONTSAMPTRANSSTORDESC 	VARCHAR2(250) NULL,
	RESULTCOUNT                   	VARCHAR2(255) NULL,
	WQXUPDATEDATE                 	DATE NOT NULL,
	TMPPROJECTID			VARCHAR(50) NULL
	)
/

CREATE TABLE WQX_ACTIVITYACTIVITYGROUP ( 
	RECORDID             	VARCHAR2(50) NOT NULL,
	ACTIVITYPARENTID     	VARCHAR2(50) NOT NULL,
	ACTIVITYGROUPPARENTID	VARCHAR2(50) NOT NULL 
	)
/

CREATE TABLE WQX_ACTIVITYCONDUCTINGORG ( 
	RECORDID             	VARCHAR2(50) NOT NULL,
	PARENTID             	VARCHAR2(50) NOT NULL,
	ACTIVITYID           	VARCHAR2(35) NOT NULL,
	ACTIVITYCONDUCTINGORG	VARCHAR2(120) NOT NULL 
	)
/

CREATE TABLE WQX_ACTIVITYGROUP ( 
	RECORDID             	VARCHAR2(50) NOT NULL,
	PARENTID             	VARCHAR2(50) NOT NULL,
	ACTIVITYGROUPID      	VARCHAR2(35) NOT NULL,
	ACTIVITYGROUPNAME    	VARCHAR2(50) NOT NULL,
	ACTIVITYGROUPTYPECODE	VARCHAR2(50) NOT NULL,
	WQXUPDATEDATE        	DATE NOT NULL 
	)
/

CREATE TABLE WQX_ACTIVITYMETRIC ( 
	RECORDID                 	VARCHAR2(50) NOT NULL,
	PARENTID                 	VARCHAR2(50) NOT NULL,
	METRICTYPEID             	VARCHAR2(35) NOT NULL,
	METRICTYPEIDCONTEXT      	VARCHAR2(50) NOT NULL,
	METRICTYPENAME           	VARCHAR2(50) NULL,
	CITATIONRESOURCETITLE    	VARCHAR2(120) NULL,
	CITATIONRESOURCECREATOR  	VARCHAR2(120) NULL,
	CITATIONRESOURCESUBJECT  	VARCHAR2(500) NULL,
	CITATIONRESOURCEPUBLISHER	VARCHAR2(60) NULL,
	CITATIONRESOURCEDATE     	DATE NULL,
	CITATIONRESOURCEID       	VARCHAR2(255) NULL,
	METRICTYPESCALE          	VARCHAR2(50) NULL,
	METRICTYPEFORMULADESC    	VARCHAR2(50) NULL,
	METRICVALUEMEASURE       	VARCHAR2(12) NULL,
	METRICVALUEMEASUREUNIT   	VARCHAR2(12) NULL,
	METRICSCORE              	VARCHAR2(10) NOT NULL,
	METRICCOMMENT            	VARCHAR2(4000) NULL,
	METRICINDEXID            	VARCHAR2(35) NULL 
	)
/

CREATE TABLE WQX_ALTMONLOC ( 
	RECORDID       	VARCHAR2(50) NOT NULL,
	PARENTID       	VARCHAR2(50) NOT NULL,
	MONLOCID       	VARCHAR2(35) NOT NULL,
	MONLOCIDCONTEXT	VARCHAR2(120) NOT NULL 
	)
/

CREATE TABLE WQX_BIOLOGICALHABITATINDEX ( 
	RECORDID           	VARCHAR2(50) NOT NULL,
	PARENTID           	VARCHAR2(50) NOT NULL,
	INDEXID            	VARCHAR2(35) NOT NULL,
	INDEXTYPEID        	VARCHAR2(35) NOT NULL,
	INDEXTYPEIDCONTEXT 	VARCHAR2(50) NOT NULL,
	INDEXTYPENAME      	VARCHAR2(50) NOT NULL,
	RESOURCETITLE      	VARCHAR2(120) NULL,
	RESOURCECREATOR    	VARCHAR2(120) NULL,
	RESOURCESUBJECT    	VARCHAR2(500) NULL,
	RESOURCEPUBLISHER  	VARCHAR2(60) NULL,
	RESOURCEDATE       	VARCHAR2(10) NULL,
	RESOURCEID         	VARCHAR2(255) NULL,
	INDEXTYPESCALE     	VARCHAR2(50) NULL,
	INDEXSCORE         	VARCHAR2(10) NOT NULL,
	INDEXQUALIFIERCODE 	VARCHAR2(5) NULL,
	INDEXCOMMENT       	VARCHAR2(4000) NULL,
	INDEXCALCULATEDDATE	VARCHAR2(10) NULL,
	MONLOCID           	VARCHAR2(35) NOT NULL,
	WQXUPDATEDATE      	DATE NOT NULL 
	)
/

CREATE TABLE WQX_DELETES ( 
	RECORDID     	VARCHAR2(50) NOT NULL,
	PARENTID     	VARCHAR2(50) NOT NULL,
	COMPONENT    	VARCHAR2(50) NOT NULL,
	IDENTIFIER   	VARCHAR2(50) NOT NULL,
	WQXUPDATEDATE	DATE NOT NULL 
	)
/

CREATE TABLE WQX_ELECTRONICADDRESS ( 
	RECORDID             	VARCHAR2(50) NOT NULL,
	PARENTID             	VARCHAR2(50) NOT NULL,
	ELECTRONICADDRESS    	VARCHAR2(120) NOT NULL,
	ELECTRONICADDRESSTYPE	VARCHAR2(8) NULL 
	)
/

CREATE TABLE WQX_LABSAMPLEPREP ( 
	RECORDID               	VARCHAR2(50) NOT NULL,
	PARENTID               	VARCHAR2(50) NOT NULL,
	METHODID               	VARCHAR2(20) NOT NULL,
	METHODIDCONTEXT        	VARCHAR2(120) NOT NULL,
	METHODNAME             	VARCHAR2(120) NOT NULL,
	METHODQUALIFIERTYPE    	VARCHAR2(25) NULL,
	METHODDESC             	VARCHAR2(500) NULL,
	PREPSTARTDATE          	DATE NULL,
	PREPSTARTTIME          	VARCHAR2(20) NULL,
	PREPSTARTTIMEZONECODE  	VARCHAR2(4) NULL,
	PREPENDDATE            	DATE NULL,
	PREPENDTIME            	VARCHAR2(20) NULL,
	PREPENDTIMEZONECODE    	VARCHAR2(4) NULL,
	SUBSTANCEDILUTIONFACTOR	VARCHAR2(10) NULL 
	)
/

CREATE TABLE WQX_MONITORINGLOCATION ( 
	RECORDID                	VARCHAR2(50) NOT NULL,
	PARENTID                	VARCHAR2(50) NOT NULL,
	MONITORINGLOCATIONID    	VARCHAR2(35) NOT NULL,
	MONLOCNAME              	VARCHAR2(255) NOT NULL,
	MONLOCTYPE              	VARCHAR2(45) NOT NULL,
	MONLOCDESC              	VARCHAR2(1999) NULL,
	HUCEIGHTDIGITCODE       	VARCHAR2(8) NULL,
	HUCTWELVEDIGITCODE      	VARCHAR2(12) NULL,
	TRIBALLANDIND           	CHAR(1) NULL,
	TRIBALLANDNAME          	VARCHAR2(200) NULL,
	LATITUDEMEASURE         	VARCHAR2(30) NOT NULL,
	LONGITUDEMEASURE        	VARCHAR2(30) NOT NULL,
	SOURCEMAPSCALE          	NUMBER NULL,
	HORIZACCURACYMEASURE    	VARCHAR2(12) NULL,
	HORIZACCURACYMEASUREUNIT	VARCHAR2(12) NULL,
	HORIZCOLLMETHOD         	VARCHAR2(150) NOT NULL,
	HORIZCOORDREFSYSDATUM   	VARCHAR2(6) NOT NULL,
	VERTICALMEASURE         	VARCHAR2(12) NULL,
	VERTICALMEASUREUNIT     	VARCHAR2(12) NULL,
	VERTICALCOLLMETHOD      	VARCHAR2(50) NULL,
	VERTICALCOORDREFSYSDATUM	VARCHAR2(10) NULL,
	COUNTRYCODE             	VARCHAR2(2) NULL,
	STATECODE               	VARCHAR2(2) NULL,
	COUNTYCODE              	VARCHAR2(3) NULL,
	WELLTYPE                	VARCHAR2(255) NULL,
	AQUIFERNAME             	VARCHAR2(120) NULL,
	FORMATIONTYPE           	VARCHAR2(50) NULL,
	WELLHOLEDEPTHMEASURE    	VARCHAR2(12) NULL,
	WELLHOLEDEPTHMEASUREUNIT	VARCHAR2(12) NULL,
	WQXUPDATEDATE           	DATE NOT NULL 
	)
/

CREATE TABLE WQX_MONLOCATTACHEDBINARYOBJECT ( 
	RECORDID                	VARCHAR2(50) NOT NULL,
	PARENTID                	VARCHAR2(50) NOT NULL,
	BINARYOBJECTFILE        	VARCHAR2(255) NOT NULL,
	BINARYOBJECTFILETYPECODE	VARCHAR2(6) NOT NULL,
	BINARYOBJECTCONTENT     	BLOB NULL 
	)
/

CREATE TABLE WQX_ORGADDRESS ( 
	RECORDID           	VARCHAR2(50) NOT NULL,
	PARENTID           	VARCHAR2(50) NOT NULL,
	ADDRESSTYPE        	VARCHAR2(8) NULL,
	ADDRESS            	VARCHAR2(50) NOT NULL,
	SUPPLEMENTALADDRESS	VARCHAR2(120) NULL,
	LOCALITY           	VARCHAR2(30) NULL,
	STATECODE          	VARCHAR2(2) NULL,
	POSTALCODE         	VARCHAR2(10) NULL,
	COUNTRYCODE        	VARCHAR2(2) NULL,
	COUNTYCODE         	VARCHAR2(3) NULL 
	)
/

CREATE TABLE WQX_ORGANIZATION ( 
	RECORDID     	VARCHAR2(50) NOT NULL,
	ORGID        	VARCHAR2(30) NOT NULL,
	ORGFORMALNAME	VARCHAR2(120) NOT NULL,
	ORGDESC      	VARCHAR2(500) NULL,
	TRIBALCODE   	VARCHAR2(3) NULL 
	)
/

CREATE TABLE WQX_PROJATTACHEDBINARYOBJECT ( 
	RECORDID                	VARCHAR2(50) NOT NULL,
	PARENTID                	VARCHAR2(50) NOT NULL,
	BINARYOBJECTFILE        	VARCHAR2(255) NOT NULL,
	BINARYOBJECTFILETYPECODE	VARCHAR2(6) NOT NULL,
	BINARYOBJECTCONTENT     	BLOB NULL 
	)
/

CREATE TABLE WQX_PROJECT ( 
	RECORDID              	VARCHAR2(50) NOT NULL,
	PARENTID              	VARCHAR2(50) NOT NULL,
	PROJECTID             	VARCHAR2(35) NOT NULL,
	PROJECTNAME           	VARCHAR2(120) NOT NULL,
	PROJECTDESC           	VARCHAR2(1999) NULL,
	SAMPLINGDESIGNTYPECODE	VARCHAR2(20) NULL,
	QAPPAPPROVEDIND       	CHAR(1) NULL,
	QAPPAPPROVALAGENCYNAME	VARCHAR2(50) NULL,
	WQXUPDATEDATE         	DATE NOT NULL 
	)
/

CREATE TABLE WQX_PROJECTACTIVITY ( 
	RECORDID        	VARCHAR2(50) NOT NULL,
	PROJECTPARENTID 	VARCHAR2(50) NOT NULL,
	ACTIVITYPARENTID	VARCHAR2(50) NOT NULL 
	)
/

CREATE TABLE WQX_PROJECTMONLOC ( 
	RECORDID                  	VARCHAR2(50) NOT NULL,
	PARENTID                  	VARCHAR2(50) NOT NULL,
	MONLOCID                  	VARCHAR2(35) NOT NULL,
	LOCWEIGHTINGFACMEASURE    	VARCHAR2(12) NOT NULL,
	LOCWEIGHTINGFACMEASUREUNIT	VARCHAR2(12) NOT NULL,
	STATISTICALSTRATUM        	VARCHAR2(15) NULL,
	LOCATIONCATERY            	VARCHAR2(50) NULL,
	LOCATIONSTATUS            	VARCHAR2(15) NULL,
	REFLOCATIONTYPECODE       	VARCHAR2(20) NULL,
	REFLOCATIONSTARTDATE      	DATE NULL,
	REFLOCATIONENDDATE        	DATE NULL,
	RESOURCETITLE             	VARCHAR2(120) NULL,
	RESOURCECREATOR           	VARCHAR2(120) NULL,
	RESOURCESUBJECT           	VARCHAR2(500) NULL,
	RESOURCEPUBLISHER         	VARCHAR2(60) NULL,
	RESOURCEDATE              	DATE NULL,
	RESOURCEID                	VARCHAR2(255) NULL,
	PROJMONLOCCOMMENT         	VARCHAR2(4000) NULL 
	)
/

CREATE TABLE WQX_RESULT ( 
	RECORDID                      	VARCHAR2(50) NOT NULL,
	PARENTID                      	VARCHAR2(50) NOT NULL,
	DATALOGGERLINENAME            	VARCHAR2(15) NULL,
	RESULTDETECTIONCONDITION      	VARCHAR2(35) NULL,
	CHARACTERISTICNAME            	VARCHAR2(120) NULL,
	METHODSPECIATIONNAME          	VARCHAR2(20) NULL,
	RESULTSAMPFRACTION            	VARCHAR2(25) NULL,
	RESULTMEASURE                 	VARCHAR2(60) NULL,
	RESULTMEASUREUNIT             	VARCHAR2(12) NULL,
	RESULTMEASUREQUALIFIERCODE    	VARCHAR2(5) NULL,
	STATUSID                      	VARCHAR2(12) NULL,
	STATISTICALBASECODE           	VARCHAR2(25) NULL,
	VALUETYPE                     	VARCHAR2(20) NULL,
	WEIGHTBASIS                   	VARCHAR2(15) NULL,
	TIMEBASIS                     	VARCHAR2(12) NULL,
	TEMPERATUREBASIS              	VARCHAR2(12) NULL,
	PARTICLESIZEBASIS             	VARCHAR2(15) NULL,
	PRECISIONVALUE                	VARCHAR2(60) NULL,
	BIASVALUE                     	VARCHAR2(60) NULL,
	CONFIDENCEINTERVALVALUE       	VARCHAR2(15) NULL,
	UPPERCONFIDENCELIMITVALUE     	VARCHAR2(15) NULL,
	LOWERCONFIDENCELIMITVALUE     	VARCHAR2(15) NULL,
	RESULTCOMMENT                 	VARCHAR2(4000) NULL,
	DEPTHHEIGHTMEASURE            	VARCHAR2(12) NULL,
	DEPTHHEIGHTMEASUREUNIT        	VARCHAR2(12) NULL,
	DEPTHALTITUDEREFPOINT         	VARCHAR2(125) NULL,
	RESULTSAMPPOINT               	VARCHAR2(12) NULL,
	BIORESULTINTENT               	VARCHAR2(35) NULL,
	BIORESULTINDIVIDUALID         	VARCHAR2(4) NULL,
	BIORESULTSUBJECTTAXONOMIC     	VARCHAR2(120) NULL,
	BIORESULTUNIDENTIFIEDSPECIESID	VARCHAR2(120) NULL,
	BIORESULTSAMPTISSUEANATOMY    	VARCHAR2(30) NULL,
	GRPSUMMCOUNTWEIGHTMEASURE     	VARCHAR2(12) NULL,
	GRPSUMMCOUNTWEIGHTMEASUREUNIT 	VARCHAR2(12) NULL,
	TAXDETAILSCELLFORM            	VARCHAR2(11) NULL,
	TAXDETAILSCELLSHAPE           	VARCHAR2(18) NULL,
	TAXDETAILSHABITNAME           	VARCHAR2(15) NULL,
	TAXDETAILSVOLTINISM           	VARCHAR2(25) NULL,
	TAXDETAILSPOLLTOLERANCE       	VARCHAR2(4) NULL,
	TAXDETAILSPOLLTOLERANCESCALE  	VARCHAR2(50) NULL,
	TAXDETAILSTROPHICLEVEL        	VARCHAR2(4) NULL,
	TAXDETAILSFUNCFEEDINGGROUP    	VARCHAR2(6) NULL,
	CITATIONRESOURCETITLE         	VARCHAR2(120) NULL,
	CITATIONRESOURCECREATOR       	VARCHAR2(120) NULL,
	CITATIONRESOURCESUBJECT       	VARCHAR2(500) NULL,
	CITATIONRESOURCEPUBLISHER     	VARCHAR2(60) NULL,
	CITATIONRESOURCEDATE          	DATE NULL,
	CITATIONRESOURCEID            	VARCHAR2(255) NULL,
	FREQCLASSDESCCODE             	VARCHAR2(50) NULL,
	FREQCLASSDESCUNITCODE         	VARCHAR2(12) NULL,
	FREQCLASSLOWERBOUNDVALUE      	VARCHAR2(8) NULL,
	FREQCLASSUPPERBOUNDVALUE      	VARCHAR2(8) NULL,
	ANALYTICALMETHODID            	VARCHAR2(20) NULL,
	ANALYTICALMETHODIDCONTEXT     	VARCHAR2(120) NULL,
	ANALYTICALMETHODNAME          	VARCHAR2(120) NULL,
	ANALYTICALMETHODQUALIFIERTYPE 	VARCHAR2(25) NULL,
	ANALYTICALMETHODDESC          	VARCHAR2(500) NULL,
	LABNAME                       	VARCHAR2(60) NULL,
	LABANALYSISSTARTDATE          	DATE NULL,
	LABANALYSISSTARTTIME          	VARCHAR2(20) NULL,
	LABANALYSISSTARTTIMEZONECODE  	VARCHAR2(4) NULL,
	LABANALYSISENDDATE            	DATE NULL,
	LABANALYSISENDTIME            	VARCHAR2(20) NULL,
	LABANALYSISENDTIMEZONECODE    	VARCHAR2(4) NULL,
	RESULTLABCOMMENTCODE          	VARCHAR2(3) NULL,
	LABACCIND                     	CHAR(1) NULL,
	LABACCAUTHORITYNAME           	VARCHAR2(20) NULL,
	LABTAXACCIND                  	CHAR(1) NULL,
	LABTAXACCAUTHORITYNAME        	VARCHAR2(20) NULL,
	TMPACTIVITYID			VARCHAR(35) NULL
	)
/

CREATE TABLE WQX_RESULTATTACHEDBINARYOBJECT ( 
	RECORDID                	VARCHAR2(50) NOT NULL,
	PARENTID                	VARCHAR2(50) NOT NULL,
	BINARYOBJECTFILE        	VARCHAR2(255) NOT NULL,
	BINARYOBJECTFILETYPECODE	VARCHAR2(6) NOT NULL,
	BINARYOBJECTCONTENT     	BLOB NULL 
	)
/

CREATE TABLE WQX_RESULTDETECTQUANTLIMIT ( 
	RECORDID                    	VARCHAR2(50) NOT NULL,
	PARENTID                    	VARCHAR2(50) NOT NULL,
	DETECTQUANTLIMITTYPE        	VARCHAR2(35) NOT NULL,
	DETECTQUANTLIMITMEASURE     	VARCHAR2(12) NULL,
	DETECTQUANTLIMITMEASUNITCODE	VARCHAR2(12) NULL 
	)
/

CREATE TABLE WQX_SUBMISSIONHISTORY ( 
	RECORDID           	VARCHAR2(50) NOT NULL,
	PARENTID           	VARCHAR2(50) NOT NULL,
	SCHEDULERUNDATE    	DATE NOT NULL,
	WQXUPDATEDATE      	DATE NOT NULL,
	SUBMISSIONTYPE     	VARCHAR2(13) NOT NULL,
	LOCALTRANSACTIONID 	VARCHAR2(50) NOT NULL,
	CDXPROCESSINGSTATUS	VARCHAR2(50) NOT NULL 
	)
/

CREATE TABLE WQX_TELEPHONIC ( 
	RECORDID           	VARCHAR2(50) NOT NULL,
	PARENTID           	VARCHAR2(50) NOT NULL,
	TELEPHONENUMBER    	VARCHAR2(15) NOT NULL,
	TELEPHONENUMBERTYPE	VARCHAR2(6) NULL,
	TELEPHONEEXT       	VARCHAR2(6) NULL 
	)
/


CREATE UNIQUE INDEX PK_WQX_ACTATTBINARYOBJECT
	ON WQX_ACTATTACHEDBINARYOBJECT(RECORDID)
/

CREATE INDEX FK_ACTIVITY_ACTATTBINOBJ
	ON WQX_ACTATTACHEDBINARYOBJECT(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ACTIVITY
	ON WQX_ACTIVITY(RECORDID)
/

CREATE INDEX FK_ORG_ACTIVITY
	ON WQX_ACTIVITY(PARENTID)
/

CREATE INDEX FK_ACTIVITY_ACTACTGROUP
	ON WQX_ACTIVITYACTIVITYGROUP(ACTIVITYPARENTID)
/

CREATE INDEX FK_ACTIVITYGROUP_ACTACTGROUP
	ON WQX_ACTIVITYACTIVITYGROUP(ACTIVITYGROUPPARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ACTIVITYACTIVITYGROUP
	ON WQX_ACTIVITYACTIVITYGROUP(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_ACTIVITYCONDUCTINGORG
	ON WQX_ACTIVITYCONDUCTINGORG(RECORDID)
/

CREATE INDEX FK_ACTIVITY_ACTCONDUCTINGORG
	ON WQX_ACTIVITYCONDUCTINGORG(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ACTIVITYGROUP
	ON WQX_ACTIVITYGROUP(RECORDID)
/

CREATE INDEX FK_ORG_ACTIVITYGROUP
	ON WQX_ACTIVITYGROUP(PARENTID)
/

CREATE INDEX FK_ACTIVITY_ACTIVITYMETRIC
	ON WQX_ACTIVITYMETRIC(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ACTIVITYMETRIC
	ON WQX_ACTIVITYMETRIC(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_ALTMONLOC
	ON WQX_ALTMONLOC(RECORDID)
/

CREATE INDEX FK_MONLOC_ALTMONLOC
	ON WQX_ALTMONLOC(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_BIOLOGICALHABITATINDEX
	ON WQX_BIOLOGICALHABITATINDEX(RECORDID)
/

CREATE INDEX FK_ORG_BIOLOGICALHABITATINDEX
	ON WQX_BIOLOGICALHABITATINDEX(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_DELETES
	ON WQX_DELETES(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_ELECTRONICADDRESS
	ON WQX_ELECTRONICADDRESS(RECORDID)
/

CREATE INDEX FK_ORG_ELECTRONICADDRESS
	ON WQX_ELECTRONICADDRESS(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_LABSAMPLEPREP
	ON WQX_LABSAMPLEPREP(RECORDID)
/

CREATE INDEX FK_RESULT_LABSAMPLEPREP
	ON WQX_LABSAMPLEPREP(PARENTID)
/

CREATE INDEX FK_ORG_MONITORINGLOCATION
	ON WQX_MONITORINGLOCATION(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_MONITORINGLOCATION
	ON WQX_MONITORINGLOCATION(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_MONLOCATTBINARYOBJECT
	ON WQX_MONLOCATTACHEDBINARYOBJECT(RECORDID)
/

CREATE INDEX FK_MONLOC_MONLOCATTBINOBJ
	ON WQX_MONLOCATTACHEDBINARYOBJECT(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ORGADDRESS
	ON WQX_ORGADDRESS(RECORDID)
/

CREATE INDEX FK_ORG_ORGADDRESS
	ON WQX_ORGADDRESS(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_ORGANIZATION
	ON WQX_ORGANIZATION(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_PROJATTBINARYOBJECT
	ON WQX_PROJATTACHEDBINARYOBJECT(RECORDID)
/

CREATE INDEX FK_PROJECT_PROJATTBINOBJ
	ON WQX_PROJATTACHEDBINARYOBJECT(PARENTID)
/

CREATE INDEX FK_ORG_PROJECT
	ON WQX_PROJECT(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_PROJECT
	ON WQX_PROJECT(RECORDID)
/

CREATE INDEX FK_PROJECT_PROJECTACTIVITY
	ON WQX_PROJECTACTIVITY(PROJECTPARENTID)
/

CREATE UNIQUE INDEX PK_WQX_PROJECTACTIVITY
	ON WQX_PROJECTACTIVITY(RECORDID)
/

CREATE INDEX FK_ACTIVITY_PROJECTACTIVITY
	ON WQX_PROJECTACTIVITY(ACTIVITYPARENTID)
/

CREATE INDEX FK_PROJECT_PROJECTMONLOC
	ON WQX_PROJECTMONLOC(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_PROJECTMONLOC
	ON WQX_PROJECTMONLOC(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_RESULT
	ON WQX_RESULT(RECORDID)
/

CREATE INDEX FK_ACTIVITY_RESULT
	ON WQX_RESULT(PARENTID)
/

CREATE INDEX FK_RESULT_RESULTATTBINOBJ
	ON WQX_RESULTATTACHEDBINARYOBJECT(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_RESULTATTBINARYOBJECT
	ON WQX_RESULTATTACHEDBINARYOBJECT(RECORDID)
/

CREATE UNIQUE INDEX PK_WQX_RESULTDETECTQUANTLIMIT
	ON WQX_RESULTDETECTQUANTLIMIT(RECORDID)
/

CREATE INDEX FK_RESULT_RESULTDETQUANTLIMIT
	ON WQX_RESULTDETECTQUANTLIMIT(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_SUBMISSIONHISTORY
	ON WQX_SUBMISSIONHISTORY(RECORDID)
/

CREATE INDEX FK_WQX_SUBMISSIONHIST_WQX_ORG
	ON WQX_SUBMISSIONHISTORY(PARENTID)
/

CREATE UNIQUE INDEX PK_WQX_TELEPHONIC
	ON WQX_TELEPHONIC(RECORDID)
/

CREATE INDEX FK_ORG_TELEPHONIC
	ON WQX_TELEPHONIC(PARENTID)
/

ALTER TABLE WQX_ACTATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT PK_WQX_ACTATTBINARYOBJECT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTIVITY
	ADD ( CONSTRAINT PK_WQX_ACTIVITY
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTIVITYACTIVITYGROUP
	ADD ( CONSTRAINT PK_WQX_ACTIVITYACTIVITYGROUP
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTIVITYCONDUCTINGORG
	ADD ( CONSTRAINT PK_WQX_ACTIVITYCONDUCTINGORG
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTIVITYGROUP
	ADD ( CONSTRAINT PK_WQX_ACTIVITYGROUP
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTIVITYMETRIC
	ADD ( CONSTRAINT PK_WQX_ACTIVITYMETRIC
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ALTMONLOC
	ADD ( CONSTRAINT PK_WQX_ALTMONLOC
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_BIOLOGICALHABITATINDEX
	ADD ( CONSTRAINT PK_WQX_BIOLOGICALHABITATINDEX
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_DELETES
	ADD ( CONSTRAINT PK_WQX_DELETES
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ELECTRONICADDRESS
	ADD ( CONSTRAINT PK_WQX_ELECTRONICADDRESS
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_LABSAMPLEPREP
	ADD ( CONSTRAINT PK_WQX_LABSAMPLEPREP
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_MONITORINGLOCATION
	ADD ( CONSTRAINT PK_WQX_MONITORINGLOCATION
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_MONLOCATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT PK_WQX_MONLOCATTBINARYOBJECT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ORGADDRESS
	ADD ( CONSTRAINT PK_WQX_ORGADDRESS
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ORGANIZATION
	ADD ( CONSTRAINT PK_WQX_ORGANIZATION
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_PROJATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT PK_WQX_PROJATTBINARYOBJECT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_PROJECT
	ADD ( CONSTRAINT PK_WQX_PROJECT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_PROJECTACTIVITY
	ADD ( CONSTRAINT PK_WQX_PROJECTACTIVITY
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_PROJECTMONLOC
	ADD ( CONSTRAINT PK_WQX_PROJECTMONLOC
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_RESULT
	ADD ( CONSTRAINT PK_WQX_RESULT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_RESULTATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT PK_WQX_RESULTATTBINARYOBJECT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_RESULTDETECTQUANTLIMIT
	ADD ( CONSTRAINT PK_WQX_RESULTDETECTQUANTLIMIT
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_SUBMISSIONHISTORY
	ADD ( CONSTRAINT PK_WQX_SUBMISSIONHISTORY
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_TELEPHONIC
	ADD ( CONSTRAINT PK_WQX_TELEPHONIC
	PRIMARY KEY (RECORDID)
	NOT DEFERRABLE INITIALLY IMMEDIATE )
/

ALTER TABLE WQX_ACTATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT FK_ACTIVITY_ACTATTBINOBJ
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITY
	ADD ( CONSTRAINT FK_ORG_ACTIVITY
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITYACTIVITYGROUP
	ADD ( CONSTRAINT FK_ACTIVITY_ACTACTGROUP
	FOREIGN KEY(ACTIVITYPARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITYACTIVITYGROUP
	ADD ( CONSTRAINT FK_ACTIVITYGROUP_ACTACTGROUP
	FOREIGN KEY(ACTIVITYGROUPPARENTID)
	REFERENCES WQX_ACTIVITYGROUP(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITYCONDUCTINGORG
	ADD ( CONSTRAINT FK_ACTIVITY_ACTCONDUCTINGORG
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITYGROUP
	ADD ( CONSTRAINT FK_ORG_ACTIVITYGROUP
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE SET NULL NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ACTIVITYMETRIC
	ADD ( CONSTRAINT FK_ACTIVITY_ACTIVITYMETRIC
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ALTMONLOC
	ADD ( CONSTRAINT FK_MONLOC_ALTMONLOC
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_MONITORINGLOCATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_BIOLOGICALHABITATINDEX
	ADD ( CONSTRAINT FK_ORG_BIOLOGICALHABITATINDEX
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_DELETES
	ADD ( CONSTRAINT FK_WQX_DELETES_WQX_ORG
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE SET NULL NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ELECTRONICADDRESS
	ADD ( CONSTRAINT FK_ORG_ELECTRONICADDRESS
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_LABSAMPLEPREP
	ADD ( CONSTRAINT FK_RESULT_LABSAMPLEPREP
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_RESULT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_MONITORINGLOCATION
	ADD ( CONSTRAINT FK_ORG_MONITORINGLOCATION
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_MONLOCATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT FK_MONLOC_MONLOCATTBINOBJ
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_MONITORINGLOCATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_ORGADDRESS
	ADD ( CONSTRAINT FK_ORG_ORGADDRESS
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_PROJATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT FK_PROJECT_PROJATTBINOBJ
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_PROJECT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_PROJECT
	ADD ( CONSTRAINT FK_ORG_PROJECT
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_PROJECTACTIVITY
	ADD ( CONSTRAINT FK_PROJECT_PROJECTACTIVITY
	FOREIGN KEY(PROJECTPARENTID)
	REFERENCES WQX_PROJECT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_PROJECTACTIVITY
	ADD ( CONSTRAINT FK_ACTIVITY_PROJECTACTIVITY
	FOREIGN KEY(ACTIVITYPARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE SET NULL NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_PROJECTMONLOC
	ADD ( CONSTRAINT FK_PROJECT_PROJECTMONLOC
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_PROJECT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_RESULT
	ADD ( CONSTRAINT FK_ACTIVITY_RESULT
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ACTIVITY(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_RESULTATTACHEDBINARYOBJECT
	ADD ( CONSTRAINT FK_RESULT_RESULTATTBINOBJ
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_RESULT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_RESULTDETECTQUANTLIMIT
	ADD ( CONSTRAINT FK_RESULT_RESULTDETQUANTLIMIT
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_RESULT(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_SUBMISSIONHISTORY
	ADD ( CONSTRAINT FK_WQX_SUBMISSIONHIST_WQX_ORG
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE SET NULL NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

ALTER TABLE WQX_TELEPHONIC
	ADD ( CONSTRAINT FK_ORG_TELEPHONIC
	FOREIGN KEY(PARENTID)
	REFERENCES WQX_ORGANIZATION(RECORDID)
	ON DELETE CASCADE NOT DEFERRABLE INITIALLY IMMEDIATE VALIDATE )
/

