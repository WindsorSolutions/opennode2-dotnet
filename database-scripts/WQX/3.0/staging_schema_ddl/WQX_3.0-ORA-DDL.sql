/*

 Copyright (c) 2012, The Environmental Council of the States (ECOS)
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

/******************************************************************************************************************************
 ** ObjectName: WQX_3.0-ORA-DDL.sql
 **
 ** Author: Windsor Solutions, Inc.
 **
 ** Company Name: Windsor Solutions, Inc
 **
 ** Description: Creates the Oracle WQX staging tables and views needed to support the OpenNode2 WQX 3.0 plugin.
 **
 ** Notes: 
 **
 **
 ** Revision History:      
 ** ----------------------------------------------------------------------------------------------------------------------------
 **  Date         Name        Description
 ** ----------------------------------------------------------------------------------------------------------------------------
 ** 05/12/2021    Windsor    Baseline v3.0 WQX script
 **
 ******************************************************************************************************************************/

PROMPT Creating Table WQX_ACTATTACHEDBINARYOBJECT ...
CREATE TABLE WQX_ACTATTACHEDBINARYOBJECT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  BINARYOBJECTFILE VARCHAR2(255 CHAR) NOT NULL,
  BINARYOBJECTFILETYPECODE VARCHAR2(6 CHAR) NOT NULL,
  BINARYOBJECTCONTENT BLOB
);


COMMENT ON TABLE WQX_ACTATTACHEDBINARYOBJECT IS 'Schema element: ActivityAttachedBinaryObjectDataType'
;

COMMENT ON COLUMN WQX_ACTATTACHEDBINARYOBJECT.RECORDID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTATTACHEDBINARYOBJECT.PARENTID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (ParentId)'
;

COMMENT ON COLUMN WQX_ACTATTACHEDBINARYOBJECT.BINARYOBJECTFILE IS 'The text describing the descriptive name used to represent the file, including file extension. (BinaryObjectFileName)'
;

COMMENT ON COLUMN WQX_ACTATTACHEDBINARYOBJECT.BINARYOBJECTFILETYPECODE IS 'The text or acronym describing the binary content type of a file. (BinaryObjectFileTypeCode)'
;

COMMENT ON COLUMN WQX_ACTATTACHEDBINARYOBJECT.BINARYOBJECTCONTENT IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (BinaryContent)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTATTACHEDBINARYOBJECT on table WQX_ACTATTACHEDBINARYOBJECT ... 
ALTER TABLE WQX_ACTATTACHEDBINARYOBJECT
ADD CONSTRAINT PK_WQX_ACTATTACHEDBINARYOBJECT PRIMARY KEY
(
  RECORDID
)
ENABLE
;

---- GRANT ALL ON WQXACTATTACHEDBINARYOBJECT TO ROLE_WQX_30;
--DROP TABLE WQX_ACTIVITY CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ACTIVITY ...
CREATE TABLE WQX_ACTIVITY (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  WQXUPDATEDATE DATE NOT NULL,
  ACTIVITYID VARCHAR2(55 CHAR) NOT NULL,
  ACTIVITYIDUSERSUPPLIED VARCHAR2(55 CHAR),
  ACTIVITYTYPECODE VARCHAR2(70 CHAR) NOT NULL,
  ACTIVITYMEDIA VARCHAR2(20 CHAR) NOT NULL,
  ACTIVITYMEDIASUBDIVISION VARCHAR2(60 CHAR),
  ACTIVITYSTARTDATE DATE NOT NULL,
  ACTIVITYENDDATE DATE,
  RELATIVEDEPTH VARCHAR2(30 CHAR),
  DEPTHALTITUDEREFPOINT VARCHAR2(125 CHAR),
  MONLOCID VARCHAR2(55 CHAR),
  SAMPLINGCOMPONENTNAME VARCHAR2(120 CHAR),
  ACTIVITYCOMMENT VARCHAR2(4000 CHAR),
  TMPPROJECTID VARCHAR2(55 CHAR),
  STARTTIME VARCHAR2(20 CHAR),
  STARTTIMEZONE VARCHAR2(4 CHAR),
  ENDTIME VARCHAR2(20 CHAR),
  ENDTIMEZONE VARCHAR2(4 CHAR),
  DEPTHHEIGHTMEASURE VARCHAR2(60 CHAR),
  DEPTHHEIGHTMEASUREUNIT VARCHAR2(12 CHAR),
  TOPDEPTHHEIGHTMEASURE VARCHAR2(60 CHAR),
  TOPDEPTHHEIGHTMEASUREUNIT VARCHAR2(12 CHAR),
  BOTTOMDEPTHHEIGHTMEASURE VARCHAR2(60 CHAR),
  BOTTOMDEPTHHEIGHTMEASUREUNIT VARCHAR2(12 CHAR),
  LATITUDEMEASURE VARCHAR2(30 CHAR),
  LONGITUDEMEASURE VARCHAR2(30 CHAR),
  SOURCEMAPSCALE VARCHAR2(60 CHAR),
  HORIZCOLLMETHOD VARCHAR2(150 CHAR),
  HORIZCOORDREFSYSDATUM VARCHAR2(6 CHAR),
  ACTIVITYLOCATIONDESCRIPTION VARCHAR2(4000 CHAR),
  HORIZACCURACYMEASURE VARCHAR2(60 CHAR),
  HORIZACCURACYMEASUREUNIT VARCHAR2(12 CHAR),
  BIOACTIVITYASSEMBLAGESAMPD VARCHAR2(50 CHAR),
  BIOACTIVITYTOXICITYTESTTYPE VARCHAR2(30 CHAR),
  HABITATSELECTIONMETHOD VARCHAR2(35 CHAR),
  COLLECTIONDESCRIPTION VARCHAR2(4000 CHAR),
  BIOHABPASSCOUNT VARCHAR2(60 CHAR),
  BIOHABCOLLDURATIONMEASURE VARCHAR2(60 CHAR),
  BIOHABCOLLDURATIONMEASUREUNIT VARCHAR2(12 CHAR),
  COLLECTIONAREAMEASURE VARCHAR2(60 CHAR),
  COLLECTIONAREAMEASUREUNIT VARCHAR2(12 CHAR),
  COLLECEFFORTMEASUREVALUE VARCHAR2(60 CHAR),
  COLLECEFFORTGEARPROCEDUREUNIT VARCHAR2(35 CHAR),
  BIOHABREACHLENGTHMEASURE VARCHAR2(60 CHAR),
  BIOHABREACHLENGTHMEASUREUNIT VARCHAR2(12 CHAR),
  BIOHABREACHWIDTHMEASURE VARCHAR2(60 CHAR),
  BIOHABREACHWIDTHMEASUREUNIT VARCHAR2(12 CHAR),
  BIOHABNETTYPE VARCHAR2(60 CHAR),
  BIOHABNETSURFACEAREAMEASURE VARCHAR2(60 CHAR),
  BIOHABNETSURFACEMEASUREUNIT VARCHAR2(12 CHAR),
  BIOHABNETMESHSIZEMEASURE VARCHAR2(60 CHAR),
  BIOHABNETMESHMEASUREUNIT VARCHAR2(12 CHAR),
  BIOHABNETBOATSPEEDMEASURE VARCHAR2(60 CHAR),
  BIOHABNETBOATSPEEDMEASUREUNIT VARCHAR2(12 CHAR),
  BIOHABNETCURRSPEEDMEASURE VARCHAR2(60 CHAR),
  BIOHABNETCURRSPEEDMEASUREUNIT VARCHAR2(12 CHAR),
  SAMPCOLLEQUIPMENT VARCHAR2(60 CHAR),
  SAMPCOLLEQUIPMENTCOMMENT VARCHAR2(4000 CHAR),
  HYDROLOGICCONDITION VARCHAR2(60 CHAR),
  HYDROLOGICEVENT VARCHAR2(60 CHAR),
  SAMPCOLLMETHODID VARCHAR2(35 CHAR),
  SAMPCOLLMETHODIDCONTEXT VARCHAR2(120 CHAR),
  SAMPCOLLMETHOD VARCHAR2(250 CHAR),
  SAMPCOLLMETHODQUALIFIER VARCHAR2(25 CHAR),
  SAMPCOLLMETHODDESC VARCHAR2(4000 CHAR),
  SAMPPREPCONTLABEL VARCHAR2(60 CHAR),
  SAMPPREPCONTTYPE VARCHAR2(60 CHAR),
  SAMPPREPCONTCOLOR VARCHAR2(60 CHAR),
  SAMPPREPCONTCHEMPRESERVUSED VARCHAR2(250 CHAR),
  SAMPPREPCONTTHERMALPRESERVUSED VARCHAR2(250 CHAR),
  SAMPPREPCONTSAMPTRANSSTORDESC VARCHAR2(1999 CHAR),
  SAMPPREPID VARCHAR2(35 CHAR),
  SAMPPREPIDCONTEXT VARCHAR2(120 CHAR),
  SAMPPREP VARCHAR2(250 CHAR),
  SAMPPREPQUALIFIERTYPE VARCHAR2(25 CHAR),
  SAMPPREPDESC VARCHAR2(4000 CHAR)
);


COMMENT ON TABLE WQX_ACTIVITY IS 'Schema element: ActivityDataType'
;

COMMENT ON COLUMN WQX_ACTIVITY.RECORDID IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTIVITY.PARENTID IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (ParentId)'
;

COMMENT ON COLUMN WQX_ACTIVITY.WQXUPDATEDATE IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (WqxUpdateDate)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYID IS 'Designator that uniquely identifies an activity within an organization. (ActivityIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYIDUSERSUPPLIED IS 'User Supplied Sample ID that uniquely identifies an activity within an organization. (ActivityIdentifierUserSupplied)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYTYPECODE IS 'The text describing the type of activity. (ActivityTypeCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYMEDIA IS 'Name or code indicating the environmental medium where the sample was taken. (ActivityMediaName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYMEDIASUBDIVISION IS 'Name or code indicating the environmental matrix as a subdivision of the sample media. (ActivityMediaSubdivisionName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYSTARTDATE IS 'The calendar date on which the field activity was started. (ActivityStartDate)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYENDDATE IS 'The calendar date when the field activity was completed. (ActivityEndDate)'
;

COMMENT ON COLUMN WQX_ACTIVITY.RELATIVEDEPTH IS 'The name that indicates the approximate location within the water column at which the activity occurred. (ActivityRelativeDepthName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.DEPTHALTITUDEREFPOINT IS 'The reference used to indicate the datum or reference used to establish the depth/altitude of an activity. (ActivityDepthAltitudeReferencePointText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.MONLOCID IS 'A designator used to describe the unique name, number, or code assigned to identify the monitoring location. (MonitoringLocationIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPLINGCOMPONENTNAME IS 'Single entity within a sampling frame at which a collection procedure or protocol was performed (e.g. transect, plot point). (SamplingComponentName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYCOMMENT IS 'General comments concerning the activity. (ActivityCommentText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.TMPPROJECTID IS 'Parent: Basic identification information for an activity conducted within a project. (TmpProjectId)'
;

COMMENT ON COLUMN WQX_ACTIVITY.STARTTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_ACTIVITY.STARTTIMEZONE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ENDTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ENDTIMEZONE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.DEPTHHEIGHTMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.DEPTHHEIGHTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.TOPDEPTHHEIGHTMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.TOPDEPTHHEIGHTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BOTTOMDEPTHHEIGHTMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BOTTOMDEPTHHEIGHTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.LATITUDEMEASURE IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)'
;

COMMENT ON COLUMN WQX_ACTIVITY.LONGITUDEMEASURE IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SOURCEMAPSCALE IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScale)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HORIZCOLLMETHOD IS 'The name that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HORIZCOORDREFSYSDATUM IS 'The name that describes the reference datum used in determining latitude and longitude coordinates. (HorizontalCoordinateReferenceSystemDatumName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.ACTIVITYLOCATIONDESCRIPTION IS 'Text description of the activity location. (ActivityLocationDescriptionText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HORIZACCURACYMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HORIZACCURACYMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOACTIVITYASSEMBLAGESAMPD IS 'An association of interacting populations of organisms in a given waterbody. (AssemblageSampledName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOACTIVITYTOXICITYTESTTYPE IS 'Identifies the type of toxicity as either Acute or Chronic. (ToxicityTestType)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HABITATSELECTIONMETHOD IS 'The monitoring approach by which each habitat was chosen to sample. (e.g. random). (HabitatSelectionMethod)'
;

COMMENT ON COLUMN WQX_ACTIVITY.COLLECTIONDESCRIPTION IS 'Remark / Text description of the reach length. (CollectionDescriptionText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABPASSCOUNT IS 'The number of passes through the water from which the sample was collected. (PassCount)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABCOLLDURATIONMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABCOLLDURATIONMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.COLLECTIONAREAMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.COLLECTIONAREAMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.COLLECEFFORTMEASUREVALUE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.COLLECEFFORTGEARPROCEDUREUNIT IS 'The procedural code or equipment that represents the unit for measuring the effort. (GearProcedureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABREACHLENGTHMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABREACHLENGTHMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABREACHWIDTHMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABREACHWIDTHMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETTYPE IS 'The text describing the type of net. (NetTypeName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETSURFACEAREAMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETSURFACEMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETMESHSIZEMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETMESHMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETBOATSPEEDMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETBOATSPEEDMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETCURRSPEEDMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITY.BIOHABNETCURRSPEEDMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLEQUIPMENT IS 'The name for the equipment used in collecting the sample. (SampleCollectionEquipmentName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLEQUIPMENTCOMMENT IS 'Free text with general comments further describing the sample collection equipment. (SampleCollectionEquipmentCommentText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HYDROLOGICCONDITION IS 'Hydrologic condition is the hydrologic condition that is represented by the sample collected (i.e. ? normal, falling, rising, peak stage). (HydrologicCondition)'
;

COMMENT ON COLUMN WQX_ACTIVITY.HYDROLOGICEVENT IS 'A hydrologic event that is represented by the sample collected (i.e. - storm, drought, snowmelt). (HydrologicEvent)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLMETHODID IS 'The identification number or code assigned by the method publisher. (MethodIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLMETHODIDCONTEXT IS 'Identifies the source or data system that created or defined the identifier. (MethodIdentifierContext)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLMETHOD IS 'The title that appears on the method from the method publisher. (MethodName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLMETHODQUALIFIER IS 'Identifier of type of method that identifies it as reference, equivalent, or other. (MethodQualifierTypeName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPCOLLMETHODDESC IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTLABEL IS 'The identification number or code assigned by the LAB or data collector.. Sample Identification Codes and Labeling. (SampleContainerLabelName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTTYPE IS 'The text describing the sample container type. (SampleContainerTypeName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTCOLOR IS 'The text describing the sample container color. (SampleContainerColorName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTCHEMPRESERVUSED IS 'Information describing the chemical means to preserve the sample. (ChemicalPreservativeUsedName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTTHERMALPRESERVUSED IS 'Information describing the temperature means used to preserve the sample. (ThermalPreservativeUsedName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPCONTSAMPTRANSSTORDESC IS 'The text describing sample handling and transport procedures used. (SampleTransportStorageDescription)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPID IS 'The identification number or code assigned by the method publisher. (MethodIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPIDCONTEXT IS 'Identifies the source or data system that created or defined the identifier. (MethodIdentifierContext)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREP IS 'The title that appears on the method from the method publisher. (MethodName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPQUALIFIERTYPE IS 'Identifier of type of method that identifies it as reference, equivalent, or other. (MethodQualifierTypeName)'
;

COMMENT ON COLUMN WQX_ACTIVITY.SAMPPREPDESC IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTIVITY on table WQX_ACTIVITY ... 
ALTER TABLE WQX_ACTIVITY
ADD CONSTRAINT PK_WQX_ACTIVITY PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXACTIVITY TO ROLE_WQX_30;
--DROP TABLE WQX_ACTIVITYACTIVITYGROUP CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ACTIVITYACTIVITYGROUP ...
CREATE TABLE WQX_ACTIVITYACTIVITYGROUP (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  ACTIVITYGROUPPARENTID VARCHAR2(50 CHAR) NOT NULL,
  ACTIVITYPARENTID VARCHAR2(50 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_ACTIVITYACTIVITYGROUP IS 'Schema element: ActivityActivityGroupDataType'
;

COMMENT ON COLUMN WQX_ACTIVITYACTIVITYGROUP.RECORDID IS 'Parent: Allows for the grouping of activities. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTIVITYACTIVITYGROUP.ACTIVITYGROUPPARENTID IS 'Parent: Allows for the grouping of activities. (ActivityGroupParentId)'
;

COMMENT ON COLUMN WQX_ACTIVITYACTIVITYGROUP.ACTIVITYPARENTID IS 'Parent: Allows for the grouping of activities. (ActivityParentId)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTIVITYACTIVITYGROUP on table WQX_ACTIVITYACTIVITYGROUP ... 
ALTER TABLE WQX_ACTIVITYACTIVITYGROUP
ADD CONSTRAINT PK_WQX_ACTIVITYACTIVITYGROUP PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXACTIVITYACTIVITYGROUP TO ROLE_WQX_30;
--DROP TABLE WQX_ACTIVITYCONDUCTINGORG CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ACTIVITYCONDUCTINGORG ...
CREATE TABLE WQX_ACTIVITYCONDUCTINGORG (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  ACTIVITYID VARCHAR2(35 CHAR) NOT NULL,
  ACTIVITYCONDUCTINGORG VARCHAR2(120 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_ACTIVITYCONDUCTINGORG IS 'Schema element: ActivityConductingOrganizationDataType'
;

COMMENT ON COLUMN WQX_ACTIVITYCONDUCTINGORG.RECORDID IS 'Parent: Basic identification information for an activity conducted within a project. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTIVITYCONDUCTINGORG.PARENTID IS 'Parent: Basic identification information for an activity conducted within a project. (ParentId)'
;

COMMENT ON COLUMN WQX_ACTIVITYCONDUCTINGORG.ACTIVITYID IS 'Parent: Basic identification information for an activity conducted within a project. (ActivityId)'
;

COMMENT ON COLUMN WQX_ACTIVITYCONDUCTINGORG.ACTIVITYCONDUCTINGORG IS 'Parent: Basic identification information for an activity conducted within a project. (ActivityConductingOrganizationText)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTIVITYCONDUCTINGORG on table WQX_ACTIVITYCONDUCTINGORG ... 
ALTER TABLE WQX_ACTIVITYCONDUCTINGORG
ADD CONSTRAINT PK_WQX_ACTIVITYCONDUCTINGORG PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXACTIVITYCONDUCTINGORG TO ROLE_WQX_30;
--DROP TABLE WQX_ACTIVITYGROUP CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ACTIVITYGROUP ...
CREATE TABLE WQX_ACTIVITYGROUP (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  ACTIVITYGROUPID VARCHAR2(55 CHAR) NOT NULL,
  ACTIVITYGROUPNAME VARCHAR2(120 CHAR) NOT NULL,
  ACTIVITYGROUPTYPECODE VARCHAR2(50 CHAR) NOT NULL,
  REPLACEACTIVITIES CHAR(1 CHAR),
  WQXUPDATEDATE DATE NOT NULL
);


COMMENT ON TABLE WQX_ACTIVITYGROUP IS 'Schema element: ActivityGroupDataType'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.RECORDID IS 'Parent: Allows for the grouping of activities. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.PARENTID IS 'Parent: Allows for the grouping of activities. (ParentId)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.ACTIVITYGROUPID IS 'Designator that uniquely identifies a grouping of activities within an organization. (ActivityGroupIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.ACTIVITYGROUPNAME IS 'A name of an activity group. (ActivityGroupName)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.ACTIVITYGROUPTYPECODE IS 'Identifies the type of grouping of a set of activities. (ActivityGroupTypeCode)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.REPLACEACTIVITIES IS 'Parent: Allows for the grouping of activities. (ReplaceActivities)'
;

COMMENT ON COLUMN WQX_ACTIVITYGROUP.WQXUPDATEDATE IS 'Parent: Allows for the grouping of activities. (WqxUpdateDate)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTIVITYGROUP on table WQX_ACTIVITYGROUP ... 
ALTER TABLE WQX_ACTIVITYGROUP
ADD CONSTRAINT PK_WQX_ACTIVITYGROUP PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXACTIVITYGROUP TO ROLE_WQX_30;
--DROP TABLE WQX_ACTIVITYMETRIC CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ACTIVITYMETRIC ...
CREATE TABLE WQX_ACTIVITYMETRIC (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  METRICSCORE VARCHAR2(60 CHAR) NOT NULL,
  METRICSAMPPOINTPLACEINSERIES VARCHAR2(60 CHAR),
  METRICCOMMENT VARCHAR2(4000 CHAR),
  METRICINDEXID VARCHAR2(55 CHAR),
  METRICTYPEID VARCHAR2(50 CHAR) NOT NULL,
  METRICTYPEIDCONTEXT VARCHAR2(50 CHAR) NOT NULL,
  METRICTYPENAME VARCHAR2(100 CHAR),
  METRICTYPESCALE VARCHAR2(50 CHAR),
  METRICTYPEFORMULADESC VARCHAR2(4000 CHAR),
  CITATIONRESOURCETITLE VARCHAR2(120 CHAR),
  CITATIONRESOURCECREATOR VARCHAR2(120 CHAR),
  CITATIONRESOURCESUBJECT VARCHAR2(4000 CHAR),
  CITATIONRESOURCEPUBLISHER VARCHAR2(60 CHAR),
  CITATIONRESOURCEDATE DATE,
  CITATIONRESOURCEID VARCHAR2(255 CHAR),
  METRICVALUEMEASURE VARCHAR2(60 CHAR),
  METRICVALUEMEASUREUNIT VARCHAR2(12 CHAR)
);


COMMENT ON TABLE WQX_ACTIVITYMETRIC IS 'Schema element: ActivityMetricDataType'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.RECORDID IS 'Parent: This section allows for the reporting of metrics to support habitat or biotic integrity indices. (RecordId)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.PARENTID IS 'Parent: This section allows for the reporting of metrics to support habitat or biotic integrity indices. (ParentId)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICSCORE IS 'Provides the scaled or calculated score for the activity metric. (MetricScore)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICSAMPPOINTPLACEINSERIES IS 'The order in which a single point within a sampling frame was visited in relation to other components. (MetricSamplingPointPlaceInSeries)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICCOMMENT IS 'Free text with general comments concerning the metric. (MetricCommentText)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICINDEXID IS 'A unique designator used to identify a unique index record that the activity metric is associated with. (IndexIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICTYPEID IS 'A designator used to describe the unique name, number, or code assigned to identify the metric (Organization specific). (MetricTypeIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICTYPEIDCONTEXT IS 'Identifies the source or data system that created or defined the metric. (MetricTypeIdentifierContext)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICTYPENAME IS 'Name of the activity metric. (MetricTypeName)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICTYPESCALE IS 'Provides a description of the scale used for the activity metric. (MetricTypeScaleText)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICTYPEFORMULADESC IS 'Provides a description of the formula used to calculate the activity metric score. (FormulaDescriptionText)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCETITLE IS 'A name given to the resource. (ResourceTitleName)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCECREATOR IS 'An entity primarily responible for making the content of the resource. (ResourceCreatorName)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCESUBJECT IS 'A topic of the content of the resource. (ResourceSubjectText)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCEPUBLISHER IS 'An entity responsible for making the resource available. (ResourcePublisherName)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCEDATE IS 'A date of an event in the lifecycle of the resource. (ResourceDate)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.CITATIONRESOURCEID IS 'An unambiguous reference to the resource within a given context. (ResourceIdentifier)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICVALUEMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_ACTIVITYMETRIC.METRICVALUEMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ACTIVITYMETRIC on table WQX_ACTIVITYMETRIC ... 
ALTER TABLE WQX_ACTIVITYMETRIC
ADD CONSTRAINT PK_WQX_ACTIVITYMETRIC PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXACTIVITYMETRIC TO ROLE_WQX_30;
--DROP TABLE WQX_ALTMONLOC CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ALTMONLOC ...
CREATE TABLE WQX_ALTMONLOC (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  MONLOCID VARCHAR2(55 CHAR) NOT NULL,
  MONLOCIDCONTEXT VARCHAR2(120 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_ALTMONLOC IS 'Schema element: AlternateMonitoringLocationIdentityDataType'
;

COMMENT ON COLUMN WQX_ALTMONLOC.RECORDID IS 'Parent: Alternate identifications of a monitoring location. (RecordId)'
;

COMMENT ON COLUMN WQX_ALTMONLOC.PARENTID IS 'Parent: Alternate identifications of a monitoring location. (ParentId)'
;

COMMENT ON COLUMN WQX_ALTMONLOC.MONLOCID IS 'A designator used to describe the unique name, number, or code assigned to identify the monitoring location. (MonitoringLocationIdentifier)'
;

COMMENT ON COLUMN WQX_ALTMONLOC.MONLOCIDCONTEXT IS 'Identifies the source or data system that created or defined the monitoring location identifier. (MonitoringLocationIdentifierContext)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ALTMONLOC on table WQX_ALTMONLOC ... 
ALTER TABLE WQX_ALTMONLOC
ADD CONSTRAINT PK_WQX_ALTMONLOC PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXALTMONLOC TO ROLE_WQX_30;
--DROP TABLE WQX_BIOLOGICALHABITATINDEX CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_BIOLOGICALHABITATINDEX ...
CREATE TABLE WQX_BIOLOGICALHABITATINDEX (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  INDEXID VARCHAR2(55 CHAR) NOT NULL,
  INDEXSCORE VARCHAR2(60 CHAR) NOT NULL,
  INDEXQUALIFIERCODE VARCHAR2(35 CHAR),
  INDEXCOMMENT VARCHAR2(4000 CHAR),
  INDEXCALCULATEDDATE VARCHAR2(10 CHAR),
  MONLOCID VARCHAR2(55 CHAR) NOT NULL,
  WQXUPDATEDATE DATE NOT NULL,
  INDEXTYPEID VARCHAR2(50 CHAR) NOT NULL,
  INDEXTYPEIDCONTEXT VARCHAR2(50 CHAR) NOT NULL,
  INDEXTYPENAME VARCHAR2(100 CHAR) NOT NULL,
  INDEXTYPESCALE VARCHAR2(50 CHAR),
  RESOURCETITLE VARCHAR2(120 CHAR),
  RESOURCECREATOR VARCHAR2(120 CHAR),
  RESOURCESUBJECT VARCHAR2(4000 CHAR),
  RESOURCEPUBLISHER VARCHAR2(60 CHAR),
  RESOURCEDATE VARCHAR2(10 CHAR),
  RESOURCEID VARCHAR2(255 CHAR)
);


COMMENT ON TABLE WQX_BIOLOGICALHABITATINDEX IS 'Schema element: BiologicalHabitatIndexDataType'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RECORDID IS 'Parent: This section allows for the reporting of habitat and biotic integrity indices as a representation of water quality conditions. (RecordId)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.PARENTID IS 'Parent: This section allows for the reporting of habitat and biotic integrity indices as a representation of water quality conditions. (ParentId)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXID IS 'A unique designator used to identify a unique index record that the activity metric is associated with. (IndexIdentifier)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXSCORE IS 'Provides the score for the index. (IndexScore)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXQUALIFIERCODE IS 'A code used to identify any qualifying issues that affect the index. (IndexQualifierCode)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXCOMMENT IS 'Free text with general comments concerning the index. (IndexCommentText)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXCALCULATEDDATE IS 'Date on which the index was calcualted. (IndexCalculatedDate)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.MONLOCID IS 'A designator used to describe the unique name, number, or code assigned to identify the monitoring location. (MonitoringLocationIdentifier)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.WQXUPDATEDATE IS 'Parent: This section allows for the reporting of habitat and biotic integrity indices as a representation of water quality conditions. (WqxUpdateDate)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXTYPEID IS 'A designator used to describe the unique name, number, or code assigned to identify the index (Organization specific). (IndexTypeIdentifier)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXTYPEIDCONTEXT IS 'Identifies the source or data system that created or defined the index. (IndexTypeIdentifierContext)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXTYPENAME IS 'Name of the habitat or biotic integrity index. (IndexTypeName)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.INDEXTYPESCALE IS 'Provides a description of the scale used for the index. (IndexTypeScaleText)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCETITLE IS 'A name given to the resource. (ResourceTitleName)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCECREATOR IS 'An entity primarily responible for making the content of the resource. (ResourceCreatorName)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCESUBJECT IS 'A topic of the content of the resource. (ResourceSubjectText)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCEPUBLISHER IS 'An entity responsible for making the resource available. (ResourcePublisherName)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCEDATE IS 'A date of an event in the lifecycle of the resource. (ResourceDate)'
;

COMMENT ON COLUMN WQX_BIOLOGICALHABITATINDEX.RESOURCEID IS 'An unambiguous reference to the resource within a given context. (ResourceIdentifier)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_BIOLOGICALHABITATINDEX on table WQX_BIOLOGICALHABITATINDEX ... 
ALTER TABLE WQX_BIOLOGICALHABITATINDEX
ADD CONSTRAINT PK_WQX_BIOLOGICALHABITATINDEX PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXBIOLOGICALHABITATINDEX TO ROLE_WQX_30;
--DROP TABLE WQX_DELETES CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_DELETES ...
CREATE TABLE WQX_DELETES (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  COMPONENT VARCHAR2(50 CHAR) NOT NULL,
  IDENTIFIER VARCHAR2(50 CHAR) NOT NULL,
  WQXUPDATEDATE DATE NOT NULL
);


COMMENT ON TABLE WQX_DELETES IS 'Schema element: DeleteDataType'
;

COMMENT ON COLUMN WQX_DELETES.RECORDID IS 'Parent: Schema used to delete organization information. (RecordId)'
;

COMMENT ON COLUMN WQX_DELETES.PARENTID IS 'Parent: Schema used to delete organization information. (ParentId)'
;

COMMENT ON COLUMN WQX_DELETES.COMPONENT IS 'Parent: Schema used to delete organization information. (Component)'
;

COMMENT ON COLUMN WQX_DELETES.IDENTIFIER IS 'Parent: Schema used to delete organization information. (Identifier)'
;

COMMENT ON COLUMN WQX_DELETES.WQXUPDATEDATE IS 'Parent: Schema used to delete organization information. (WqxUpdateDate)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_DELETES on table WQX_DELETES ... 
ALTER TABLE WQX_DELETES
ADD CONSTRAINT PK_WQX_DELETES PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXDELETES TO ROLE_WQX_30;
--DROP TABLE WQX_ELECTRONICADDRESS CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ELECTRONICADDRESS ...
CREATE TABLE WQX_ELECTRONICADDRESS (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  ELECTRONICADDRESS VARCHAR2(120 CHAR) NOT NULL,
  ELECTRONICADDRESSTYPE VARCHAR2(8 CHAR)
);


COMMENT ON TABLE WQX_ELECTRONICADDRESS IS 'Schema element: ElectronicAddressDataType'
;

COMMENT ON COLUMN WQX_ELECTRONICADDRESS.RECORDID IS 'Parent: A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (RecordId)'
;

COMMENT ON COLUMN WQX_ELECTRONICADDRESS.PARENTID IS 'Parent: A location within a system of worldwide electronic communication where a computer user can access information or receive electronic mail. (ParentId)'
;

COMMENT ON COLUMN WQX_ELECTRONICADDRESS.ELECTRONICADDRESS IS 'A resource address, usually consisting of the access protocol, the domain name, and optionally, the path to a file or location. (ElectronicAddressText)'
;

COMMENT ON COLUMN WQX_ELECTRONICADDRESS.ELECTRONICADDRESSTYPE IS 'The name that describes the electronic address type. (ElectronicAddressTypeName)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ELECTRONICADDRESS on table WQX_ELECTRONICADDRESS ... 
ALTER TABLE WQX_ELECTRONICADDRESS
ADD CONSTRAINT PK_WQX_ELECTRONICADDRESS PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXELECTRONICADDRESS TO ROLE_WQX_30;
--DROP TABLE WQX_LABSAMPLEPREP CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_LABSAMPLEPREP ...
CREATE TABLE WQX_LABSAMPLEPREP (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  PREPSTARTDATE DATE,
  PREPENDDATE DATE,
  SUBSTANCEDILUTIONFACTOR VARCHAR2(60 CHAR),
  METHODID VARCHAR2(35 CHAR) NOT NULL,
  METHODIDCONTEXT VARCHAR2(120 CHAR) NOT NULL,
  METHODNAME VARCHAR2(250 CHAR) NOT NULL,
  METHODQUALIFIERTYPE VARCHAR2(25 CHAR),
  METHODDESC VARCHAR2(4000 CHAR),
  PREPSTARTTIME VARCHAR2(20 CHAR),
  PREPSTARTTIMEZONECODE VARCHAR2(4 CHAR),
  PREPENDTIME VARCHAR2(20 CHAR),
  PREPENDTIMEZONECODE VARCHAR2(4 CHAR)
);


COMMENT ON TABLE WQX_LABSAMPLEPREP IS 'Schema element: LabSamplePreparationDataType'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.RECORDID IS 'Parent: Describes Lab Sample Preparation procedures which may alter the original state of the Sample and produce Lab subsamples. These Lab Subsamples are analyized and reported by the Lab as Sample results. (RecordId)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PARENTID IS 'Parent: Describes Lab Sample Preparation procedures which may alter the original state of the Sample and produce Lab subsamples. These Lab Subsamples are analyized and reported by the Lab as Sample results. (ParentId)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPSTARTDATE IS 'The calendar date when the preparation/extraction of the sample for analysis began. (PreparationStartDate)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPENDDATE IS 'The calendar date when the preparation/extraction of the sample for analysis was finished. (PreparationEndDate)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.SUBSTANCEDILUTIONFACTOR IS 'The overall dilution of the substance subjected to this analysis. (SubstanceDilutionFactor)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.METHODID IS 'The identification number or code assigned by the method publisher. (MethodIdentifier)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.METHODIDCONTEXT IS 'Identifies the source or data system that created or defined the identifier. (MethodIdentifierContext)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.METHODNAME IS 'The title that appears on the method from the method publisher. (MethodName)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.METHODQUALIFIERTYPE IS 'Identifier of type of method that identifies it as reference, equivalent, or other. (MethodQualifierTypeName)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.METHODDESC IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPSTARTTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPSTARTTIMEZONECODE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPENDTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_LABSAMPLEPREP.PREPENDTIMEZONECODE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_LABSAMPLEPREP on table WQX_LABSAMPLEPREP ... 
ALTER TABLE WQX_LABSAMPLEPREP
ADD CONSTRAINT PK_WQX_LABSAMPLEPREP PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXLABSAMPLEPREP TO ROLE_WQX_30;
--DROP TABLE WQX_MONITORINGLOCATION CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_MONITORINGLOCATION ...
CREATE TABLE WQX_MONITORINGLOCATION (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  WQXUPDATEDATE DATE NOT NULL,
  MONITORINGLOCATIONID VARCHAR2(55 CHAR) NOT NULL,
  MONLOCNAME VARCHAR2(255 CHAR) NOT NULL,
  MONLOCTYPE VARCHAR2(45 CHAR) NOT NULL,
  MONLOCDESC VARCHAR2(4000 CHAR),
  HUCEIGHTDIGITCODE VARCHAR2(8 CHAR),
  HUCTWELVEDIGITCODE VARCHAR2(12 CHAR),
  TRIBALLANDIND CHAR(1 CHAR),
  TRIBALLANDNAME VARCHAR2(512 CHAR),
  DRAINAGEAREAMEASURE VARCHAR2(60 CHAR),
  DRAINAGEAREAMEASUREUNIT VARCHAR2(12 CHAR),
  CONTRDRAINAGEAREAMEASURE VARCHAR2(60 CHAR),
  CONTRDRAINAGEAREAMEASUREUNIT VARCHAR2(12 CHAR),
  LATITUDEMEASURE VARCHAR2(30 CHAR) NOT NULL,
  LONGITUDEMEASURE VARCHAR2(30 CHAR) NOT NULL,
  SOURCEMAPSCALE VARCHAR2(60 CHAR),
  HORIZCOLLMETHOD VARCHAR2(150 CHAR) NOT NULL,
  HORIZCOORDREFSYSDATUM VARCHAR2(6 CHAR) NOT NULL,
  VERTICALCOLLMETHOD VARCHAR2(50 CHAR),
  VERTICALCOORDREFSYSDATUM VARCHAR2(10 CHAR),
  COUNTRYCODE VARCHAR2(2 CHAR),
  STATECODE VARCHAR2(2 CHAR),
  COUNTYCODE VARCHAR2(3 CHAR),
  HORIZACCURACYMEASURE VARCHAR2(60 CHAR),
  HORIZACCURACYMEASUREUNIT VARCHAR2(12 CHAR),
  VERTICALACCURACYMEASURE VARCHAR2(60 CHAR),
  VERTICALACCURACYMEASUREUNIT VARCHAR2(12 CHAR),
  VERTICALMEASURE VARCHAR2(60 CHAR),
  VERTICALMEASUREUNIT VARCHAR2(12 CHAR),
  WELLTYPE VARCHAR2(255 CHAR),
  AQUIFERNAME VARCHAR2(255 CHAR),
  NATIONALAQUIFERCODE VARCHAR2(120 CHAR),
  FORMATIONTYPE VARCHAR2(50 CHAR),
  CONSTRUCTIONDATE DATE,
  LOCALAQUIFERCODE VARCHAR2(120 CHAR),
  LOCALAQUIFERCODECONTEXT VARCHAR2(35 CHAR),
  LOCALAQUIFERNAME VARCHAR2(255 CHAR),
  LOCALAQUIFERDESCRIPTION VARCHAR2(512 CHAR),
  WELLHOLEDEPTHMEASURE VARCHAR2(60 CHAR),
  WELLHOLEDEPTHMEASUREUNIT VARCHAR2(12 CHAR),
  WELLDEPTHMEASURE VARCHAR2(60 CHAR),
  WELLDEPTHMEASUREUNIT VARCHAR2(12 CHAR)
);


COMMENT ON TABLE WQX_MONITORINGLOCATION IS 'Schema element: MonitoringLocationDataType'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.RECORDID IS 'Parent: An identifiable location where an environmental sample, onsite measurement, and/or observation is determined. (RecordId)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.PARENTID IS 'Parent: An identifiable location where an environmental sample, onsite measurement, and/or observation is determined. (ParentId)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WQXUPDATEDATE IS 'Parent: An identifiable location where an environmental sample, onsite measurement, and/or observation is determined. (WqxUpdateDate)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.MONITORINGLOCATIONID IS 'A designator used to describe the unique name, number, or code assigned to identify the monitoring location. (MonitoringLocationIdentifier)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.MONLOCNAME IS 'The designator specified by the sampling organization for the site at which sampling or other activities are conducted. (MonitoringLocationName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.MONLOCTYPE IS 'The descriptive name for a type of monitoring location. (MonitoringLocationTypeName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.MONLOCDESC IS 'Text description of the monitoring location. (MonitoringLocationDescriptionText)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HUCEIGHTDIGITCODE IS 'The 8 digit federal code used to identify the hydrologic unit of the monitoring location to the cataloging unit level of precision. (HUCEightDigitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HUCTWELVEDIGITCODE IS 'The 12 digit federal code used to identify the hydrologic unit of the monitoring location to the subwatershed level of precision. (HUCTwelveDigitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.TRIBALLANDIND IS 'An indicator denoting whether the location is on a tribal land. (TribalLandIndicator)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.TRIBALLANDNAME IS 'The name of an American Indian or Alaskan native area where the location exists. (TribalLandName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.DRAINAGEAREAMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.DRAINAGEAREAMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.CONTRDRAINAGEAREAMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.CONTRDRAINAGEAREAMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LATITUDEMEASURE IS 'The measure of the angular distance on a meridian north or south of the equator. (LatitudeMeasure)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LONGITUDEMEASURE IS 'The measure of the angular distance on a meridian east or west of the prime meridian. (LongitudeMeasure)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.SOURCEMAPSCALE IS 'The number that represents the proportional distance on the ground for one unit of measure on the map or photo. (SourceMapScale)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HORIZCOLLMETHOD IS 'The name that identifies the method used to determine the latitude and longitude coordinates for a point on the earth. (HorizontalCollectionMethodName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HORIZCOORDREFSYSDATUM IS 'The name that describes the reference datum used in determining latitude and longitude coordinates. (HorizontalCoordinateReferenceSystemDatumName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALCOLLMETHOD IS 'The name that identifies the method used to collect the vertical measure (i.e. the altitude) of a reference point. (VerticalCollectionMethodName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALCOORDREFSYSDATUM IS 'The name of the reference datum used to determine the vertical measure (i.e., the altitude). (VerticalCoordinateReferenceSystemDatumName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.COUNTRYCODE IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.STATECODE IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.COUNTYCODE IS 'A code designator used to identify a U.S. county or county equivalent. (CountyCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HORIZACCURACYMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.HORIZACCURACYMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALACCURACYMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALACCURACYMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.VERTICALMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WELLTYPE IS 'Identifies the primary well type. (WellTypeText)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.AQUIFERNAME IS 'The type of aquifer, such as confined or unconfined. (AquiferTypeName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.NATIONALAQUIFERCODE IS 'Code of the aquifer in which the well is completed. (NationalAquiferCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.FORMATIONTYPE IS 'Name of the primary formation or soils unit, in which the well is completed. (FormationTypeText)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.CONSTRUCTIONDATE IS 'Date of construction when well was completed. (ConstructionDate)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LOCALAQUIFERCODE IS 'The identification number or code assigned by the aquifer publisher. (LocalAquiferCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LOCALAQUIFERCODECONTEXT IS 'The code that Identifies the source or data system that created or defined the identifier. (LocalAquiferCodeContext)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LOCALAQUIFERNAME IS 'The name associated with the aquifer from the aquifer publisher. (LocalAquiferName)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.LOCALAQUIFERDESCRIPTION IS 'Information that further describes an aquifer. (LocalAquiferDescriptionText)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WELLHOLEDEPTHMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WELLHOLEDEPTHMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WELLDEPTHMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_MONITORINGLOCATION.WELLDEPTHMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_MONITORINGLOCATION on table WQX_MONITORINGLOCATION ... 
ALTER TABLE WQX_MONITORINGLOCATION
ADD CONSTRAINT PK_WQX_MONITORINGLOCATION PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXMONITORINGLOCATION TO ROLE_WQX_30;
--DROP TABLE WQX_MONLOCATTACHEDBINARYOBJECT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_MONLOCATTACHEDBINARYOBJECT ...
CREATE TABLE WQX_MONLOCATTACHEDBINARYOBJECT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  BINARYOBJECTFILE VARCHAR2(255 CHAR) NOT NULL,
  BINARYOBJECTFILETYPECODE VARCHAR2(6 CHAR) NOT NULL,
  BINARYOBJECTCONTENT BLOB
);


COMMENT ON TABLE WQX_MONLOCATTACHEDBINARYOBJECT IS 'Schema element: MonitoringLocationAttachedBinaryObjectDataType'
;

COMMENT ON COLUMN WQX_MONLOCATTACHEDBINARYOBJECT.RECORDID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (RecordId)'
;

COMMENT ON COLUMN WQX_MONLOCATTACHEDBINARYOBJECT.PARENTID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (ParentId)'
;

COMMENT ON COLUMN WQX_MONLOCATTACHEDBINARYOBJECT.BINARYOBJECTFILE IS 'The text describing the descriptive name used to represent the file, including file extension. (BinaryObjectFileName)'
;

COMMENT ON COLUMN WQX_MONLOCATTACHEDBINARYOBJECT.BINARYOBJECTFILETYPECODE IS 'The text or acronym describing the binary content type of a file. (BinaryObjectFileTypeCode)'
;

COMMENT ON COLUMN WQX_MONLOCATTACHEDBINARYOBJECT.BINARYOBJECTCONTENT IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (BinaryContent)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_MONLOCATTACHEDBINARYOBJ on table WQX_MONLOCATTACHEDBINARYOBJECT ... 
ALTER TABLE WQX_MONLOCATTACHEDBINARYOBJECT
ADD CONSTRAINT PK_WQX_MONLOCATTACHEDBINARYOBJ PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXMONLOCATTACHEDBINARYOBJECT TO ROLE_WQX_30;
--DROP TABLE WQX_ORGADDRESS CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ORGADDRESS ...
CREATE TABLE WQX_ORGADDRESS (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  ADDRESSTYPE VARCHAR2(8 CHAR),
  ADDRESS VARCHAR2(50 CHAR) NOT NULL,
  SUPPLEMENTALADDRESS VARCHAR2(120 CHAR),
  LOCALITY VARCHAR2(30 CHAR),
  STATECODE VARCHAR2(2 CHAR),
  POSTALCODE VARCHAR2(10 CHAR),
  COUNTRYCODE VARCHAR2(2 CHAR),
  COUNTYCODE VARCHAR2(3 CHAR)
);


COMMENT ON TABLE WQX_ORGADDRESS IS 'Schema element: OrganizationAddressDataType'
;

COMMENT ON COLUMN WQX_ORGADDRESS.RECORDID IS 'Parent: The physical address of an organization. (RecordId)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.PARENTID IS 'Parent: The physical address of an organization. (ParentId)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.ADDRESSTYPE IS 'Categorizes an address as either location, shipping, or mailing address. (AddressTypeName)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.ADDRESS IS 'The address that describes the physical (geographic), shipping, or mailing location of an organization. (AddressText)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.SUPPLEMENTALADDRESS IS 'The text that provides additional information about an address, including a building name with its secondary unit and number, an industrial park name, an installation name or descriptive text where no formal address is available. (SupplementalAddressText)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.LOCALITY IS 'The name of a city, town, village or other locality. (LocalityName)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.STATECODE IS 'A code designator used to identify a principal administrative subdivision of the United States, Canada, or Mexico. (StateCode)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.POSTALCODE IS 'The combination of the 5-digit Zone Improvement Plan (ZIP) code and the four-digit extension code (if available) that represents the geographic segment that is a subunit of the ZIP Code, assigned by the U.S. Postal Service to a geographic location to facilitate mail delivery; or the postal zone specific to the country, other than the U.S., where the mail is delivered. (PostalCode)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.COUNTRYCODE IS 'A code designator used to identify a primary geopolitical unit of the world. (CountryCode)'
;

COMMENT ON COLUMN WQX_ORGADDRESS.COUNTYCODE IS 'A code designator used to identify a U.S. county or county equivalent. (CountyCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ORGADDRESS on table WQX_ORGADDRESS ... 
ALTER TABLE WQX_ORGADDRESS
ADD CONSTRAINT PK_WQX_ORGADDRESS PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXORGADDRESS TO ROLE_WQX_30;
--DROP TABLE WQX_ORGANIZATION CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ORGANIZATION ...
CREATE TABLE WQX_ORGANIZATION (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  ORGID VARCHAR2(35 CHAR) NOT NULL,
  ORGFORMALNAME VARCHAR2(255 CHAR) NOT NULL,
  ORGDESC VARCHAR2(500 CHAR),
  TRIBALCODE VARCHAR2(3 CHAR)
);


COMMENT ON TABLE WQX_ORGANIZATION IS 'Schema element: WQXDataType'
;

COMMENT ON COLUMN WQX_ORGANIZATION.ORGID IS 'A designator used to uniquely identify a unique business establishment within a context. (OrganizationIdentifier)'
;

COMMENT ON COLUMN WQX_ORGANIZATION.ORGFORMALNAME IS 'The legal designator (i.e. formal name) of an organization. (OrganizationFormalName)'
;

COMMENT ON COLUMN WQX_ORGANIZATION.ORGDESC IS 'Information that further describes an organization. (OrganizationDescriptionText)'
;

COMMENT ON COLUMN WQX_ORGANIZATION.TRIBALCODE IS 'The code that represents the American Indian tribe or Alaskan Native entity. (TribalCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_ORGANIZATION on table WQX_ORGANIZATION ... 
ALTER TABLE WQX_ORGANIZATION
ADD CONSTRAINT PK_WQX_ORGANIZATION PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXORGANIZATION TO ROLE_WQX_30;
--DROP TABLE WQX_PROJATTACHEDBINARYOBJECT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_PROJATTACHEDBINARYOBJECT ...
CREATE TABLE WQX_PROJATTACHEDBINARYOBJECT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  BINARYOBJECTFILE VARCHAR2(255 CHAR) NOT NULL,
  BINARYOBJECTFILETYPECODE VARCHAR2(6 CHAR) NOT NULL,
  BINARYOBJECTCONTENT BLOB
);


COMMENT ON TABLE WQX_PROJATTACHEDBINARYOBJECT IS 'Schema element: ProjectAttachedBinaryObjectDataType'
;

COMMENT ON COLUMN WQX_PROJATTACHEDBINARYOBJECT.RECORDID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (RecordId)'
;

COMMENT ON COLUMN WQX_PROJATTACHEDBINARYOBJECT.PARENTID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (ParentId)'
;

COMMENT ON COLUMN WQX_PROJATTACHEDBINARYOBJECT.BINARYOBJECTFILE IS 'The text describing the descriptive name used to represent the file, including file extension. (BinaryObjectFileName)'
;

COMMENT ON COLUMN WQX_PROJATTACHEDBINARYOBJECT.BINARYOBJECTFILETYPECODE IS 'The text or acronym describing the binary content type of a file. (BinaryObjectFileTypeCode)'
;

COMMENT ON COLUMN WQX_PROJATTACHEDBINARYOBJECT.BINARYOBJECTCONTENT IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (BinaryContent)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_PROJATTACHEDBINARYOBJEC on table WQX_PROJATTACHEDBINARYOBJECT ... 
ALTER TABLE WQX_PROJATTACHEDBINARYOBJECT
ADD CONSTRAINT PK_WQX_PROJATTACHEDBINARYOBJEC PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXPROJATTACHEDBINARYOBJECT TO ROLE_WQX_30;
--DROP TABLE WQX_PROJECT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_PROJECT ...
CREATE TABLE WQX_PROJECT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  PROJECTID VARCHAR2(55 CHAR) NOT NULL,
  PROJECTNAME VARCHAR2(512 CHAR) NOT NULL,
  PROJECTDESC VARCHAR2(4000 CHAR),
  SAMPLINGDESIGNTYPECODE VARCHAR2(20 CHAR),
  QAPPAPPROVEDIND CHAR(1 CHAR),
  QAPPAPPROVALAGENCYNAME VARCHAR2(50 CHAR),
  WQXUPDATEDATE DATE NOT NULL
);


COMMENT ON TABLE WQX_PROJECT IS 'Schema element: ProjectDataType'
;

COMMENT ON COLUMN WQX_PROJECT.RECORDID IS 'Parent: An environmental data collection effort that has a stated purpose and puts a series of samples and results into a meaningful context. (RecordId)'
;

COMMENT ON COLUMN WQX_PROJECT.PARENTID IS 'Parent: An environmental data collection effort that has a stated purpose and puts a series of samples and results into a meaningful context. (ParentId)'
;

COMMENT ON COLUMN WQX_PROJECT.PROJECTID IS 'A designator used to uniquely identify a data collection project within a context of an organization. (ProjectIdentifier)'
;

COMMENT ON COLUMN WQX_PROJECT.PROJECTNAME IS 'The name assigned by the Organization (project leader or principal investigator) to the project. (ProjectName)'
;

COMMENT ON COLUMN WQX_PROJECT.PROJECTDESC IS 'Project description, which may include a description of the project purpose, summary of the objectives, or brief summary of the results of the project. (ProjectDescriptionText)'
;

COMMENT ON COLUMN WQX_PROJECT.SAMPLINGDESIGNTYPECODE IS 'A code used to identify the type of sampling design employed for this project to ensure that sampling activities can support project objectives. (SamplingDesignTypeCode)'
;

COMMENT ON COLUMN WQX_PROJECT.QAPPAPPROVEDIND IS 'Indicates whether a Quality Assurance Project Plan (QAPP) has been approved for the submitted project. (QAPPApprovedIndicator)'
;

COMMENT ON COLUMN WQX_PROJECT.QAPPAPPROVALAGENCYNAME IS 'An outside approval authority identifier for the QAPP (e.g. EPA or State Organization). (QAPPApprovalAgencyName)'
;

COMMENT ON COLUMN WQX_PROJECT.WQXUPDATEDATE IS 'Parent: An environmental data collection effort that has a stated purpose and puts a series of samples and results into a meaningful context. (WqxUpdateDate)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_PROJECT on table WQX_PROJECT ... 
ALTER TABLE WQX_PROJECT
ADD CONSTRAINT PK_WQX_PROJECT PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXPROJECT TO ROLE_WQX_30;
--DROP TABLE WQX_PROJECTACTIVITY CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_PROJECTACTIVITY ...
CREATE TABLE WQX_PROJECTACTIVITY (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  ACTIVITYPARENTID VARCHAR2(50 CHAR) NOT NULL,
  PROJECTPARENTID VARCHAR2(50 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_PROJECTACTIVITY IS 'Schema element: ProjectActivityDataType'
;

COMMENT ON COLUMN WQX_PROJECTACTIVITY.RECORDID IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (RecordId)'
;

COMMENT ON COLUMN WQX_PROJECTACTIVITY.ACTIVITYPARENTID IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (ActivityParentId)'
;

COMMENT ON COLUMN WQX_PROJECTACTIVITY.PROJECTPARENTID IS 'Parent: Allows for the reporting of monitoring activities conducted at a Monitoring Location. (ProjectParentId)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_PROJECTACTIVITY on table WQX_PROJECTACTIVITY ... 
ALTER TABLE WQX_PROJECTACTIVITY
ADD CONSTRAINT PK_WQX_PROJECTACTIVITY PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXPROJECTACTIVITY TO ROLE_WQX_30;
--DROP TABLE WQX_PROJECTMONLOC CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_PROJECTMONLOC ...
CREATE TABLE WQX_PROJECTMONLOC (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  MONLOCID VARCHAR2(55 CHAR) NOT NULL,
  STATISTICALSTRATUM VARCHAR2(15 CHAR),
  LOCATIONCATERY VARCHAR2(50 CHAR),
  LOCATIONSTATUS VARCHAR2(15 CHAR),
  REFLOCATIONTYPECODE VARCHAR2(20 CHAR),
  REFLOCATIONSTARTDATE DATE,
  REFLOCATIONENDDATE DATE,
  PROJMONLOCCOMMENT VARCHAR2(4000 CHAR),
  LOCWEIGHTINGFACMEASURE VARCHAR2(60 CHAR) NOT NULL,
  LOCWEIGHTINGFACMEASUREUNIT VARCHAR2(12 CHAR) NOT NULL,
  RESOURCETITLE VARCHAR2(120 CHAR),
  RESOURCECREATOR VARCHAR2(120 CHAR),
  RESOURCESUBJECT VARCHAR2(4000 CHAR),
  RESOURCEPUBLISHER VARCHAR2(60 CHAR),
  RESOURCEDATE DATE,
  RESOURCEID VARCHAR2(255 CHAR)
);


COMMENT ON TABLE WQX_PROJECTMONLOC IS 'Schema element: ProjectMonitoringLocationWeightingDataType'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RECORDID IS 'Parent: Describes the probability weighting information for a given Project / Monitoring Location Assignment. (RecordId)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.PARENTID IS 'Parent: Describes the probability weighting information for a given Project / Monitoring Location Assignment. (ParentId)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.MONLOCID IS 'A designator used to describe the unique name, number, or code assigned to identify the monitoring location. (MonitoringLocationIdentifier)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.STATISTICALSTRATUM IS 'Identifies the statistical stratum applied to this site. (StatisticalStratumText)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.LOCATIONCATERY IS 'Free text describing a category of naturally similar site types, such as high-gradient. (LocationCategoryName)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.LOCATIONSTATUS IS 'Indicates whether this site is active and available for sampling. (LocationStatusName)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.REFLOCATIONTYPECODE IS 'Identifies whether this site is a reference or control site by specifying the reference location type. (ReferenceLocationTypeCode)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.REFLOCATIONSTARTDATE IS 'The calendar date on which the monitoring location started being used as a reference site. (ReferenceLocationStartDate)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.REFLOCATIONENDDATE IS 'The calendar date on which the monitoring location stopped being used as a reference site. (ReferenceLocationEndDate)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.PROJMONLOCCOMMENT IS 'Free text with general comments. (CommentText)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.LOCWEIGHTINGFACMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.LOCWEIGHTINGFACMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCETITLE IS 'A name given to the resource. (ResourceTitleName)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCECREATOR IS 'An entity primarily responible for making the content of the resource. (ResourceCreatorName)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCESUBJECT IS 'A topic of the content of the resource. (ResourceSubjectText)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCEPUBLISHER IS 'An entity responsible for making the resource available. (ResourcePublisherName)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCEDATE IS 'A date of an event in the lifecycle of the resource. (ResourceDate)'
;

COMMENT ON COLUMN WQX_PROJECTMONLOC.RESOURCEID IS 'An unambiguous reference to the resource within a given context. (ResourceIdentifier)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_PROJECTMONLOC on table WQX_PROJECTMONLOC ... 
ALTER TABLE WQX_PROJECTMONLOC
ADD CONSTRAINT PK_WQX_PROJECTMONLOC PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXPROJECTMONLOC TO ROLE_WQX_30;
--DROP TABLE WQX_RESULT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_RESULT ...
CREATE TABLE WQX_RESULT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  DATALOGGERLINENAME VARCHAR2(60 CHAR),
  RESULTDETECTIONCONDITION VARCHAR2(35 CHAR),
  CHARACTERISTICNAME VARCHAR2(255 CHAR),
  CHARACTERISTICNAMEUSERSUPPLIED VARCHAR2(255 CHAR),
  METHODSPECIATIONNAME VARCHAR2(20 CHAR),
  RESULTSAMPFRACTION VARCHAR2(25 CHAR),
  TARGETCOUNT VARCHAR2(35 CHAR),
  PROPORTIONSAMPLEPROCESSED VARCHAR2(30 CHAR),
  STATUSID VARCHAR2(12 CHAR),
  STATISTICALBASECODE VARCHAR2(25 CHAR),
  STATISTICALNVALUE NUMBER(10,0),
  VALUETYPE VARCHAR2(20 CHAR),
  WEIGHTBASIS VARCHAR2(60 CHAR),
  TIMEBASIS VARCHAR2(12 CHAR),
  TEMPERATUREBASIS VARCHAR2(12 CHAR),
  PARTICLESIZEBASIS VARCHAR2(40 CHAR),
  RESULTCOMMENT VARCHAR2(4000 CHAR),
  DEPTHALTITUDEREFPOINT VARCHAR2(125 CHAR),
  RESULTSAMPPOINT VARCHAR2(120 CHAR),
  RESULTSAMPPOINTTYPE VARCHAR2(60 CHAR),
  RESULTSAMPPOINTPLACEINSERIES VARCHAR2(60 CHAR),
  RESULTSAMPPOINTCOMMENT VARCHAR2(4000 CHAR),
  RECORDIDUSERSUPPLIED VARCHAR2(60 CHAR),
  TMPACTIVITYID VARCHAR2(55 CHAR),
  RESULTMEASURE VARCHAR2(60 CHAR),
  RESULTMEASUREUNIT VARCHAR2(12 CHAR),
  PRECISIONVALUE VARCHAR2(60 CHAR),
  BIASVALUE VARCHAR2(60 CHAR),
  CONFIDENCEINTERVALVALUE VARCHAR2(60 CHAR),
  UPPERCONFIDENCELIMITVALUE VARCHAR2(60 CHAR),
  LOWERCONFIDENCELIMITVALUE VARCHAR2(60 CHAR),
  DEPTHHEIGHTMEASURE VARCHAR2(60 CHAR),
  DEPTHHEIGHTMEASUREUNIT VARCHAR2(12 CHAR),
  BIORESULTINTENT VARCHAR2(35 CHAR),
  BIORESULTINDIVIDUALID VARCHAR2(60 CHAR),
  BIORESULTSUBJECTTAXONOMIC VARCHAR2(255 CHAR),
  BIORESULTSUBJECTTAXONOMICUS VARCHAR2(255 CHAR),
  BIORESULTSUBJECTTAXONOMICUSRT VARCHAR2(255 CHAR),
  BIORESULTUNIDENTIFIEDSPECIESID VARCHAR2(255 CHAR),
  BIORESULTSAMPTISSUEANATOMY VARCHAR2(50 CHAR),
  BIORESULTGROUPSUMMARYCOUNT VARCHAR2(60 CHAR),
  GRPSUMMCOUNTWEIGHTMEASURE VARCHAR2(60 CHAR),
  GRPSUMMCOUNTWEIGHTMEASUREUNIT VARCHAR2(12 CHAR),
  TAXDETAILSCELLFORM VARCHAR2(11 CHAR),
  TAXDETAILSCELLSHAPE VARCHAR2(18 CHAR),
  TAXDETAILSHABITNAME VARCHAR2(15 CHAR),
  TAXDETAILSVOLTINISM VARCHAR2(25 CHAR),
  TAXDETAILSPOLLTOLERANCE VARCHAR2(30 CHAR),
  TAXDETAILSPOLLTOLERANCESCALE VARCHAR2(50 CHAR),
  TAXDETAILSTROPHICLEVEL VARCHAR2(30 CHAR),
  TAXDETAILSFUNCFEEDINGGROUP VARCHAR2(30 CHAR),
  CITATIONRESOURCETITLE VARCHAR2(120 CHAR),
  CITATIONRESOURCECREATOR VARCHAR2(120 CHAR),
  CITATIONRESOURCESUBJECT VARCHAR2(4000 CHAR),
  CITATIONRESOURCEPUBLISHER VARCHAR2(60 CHAR),
  CITATIONRESOURCEDATE DATE,
  CITATIONRESOURCEID VARCHAR2(255 CHAR),
  FREQCLASSDESCCODE VARCHAR2(50 CHAR),
  FREQCLASSDESCUNITCODE VARCHAR2(12 CHAR),
  FREQCLASSLOWERBOUNDVALUE VARCHAR2(60 CHAR),
  FREQCLASSUPPERBOUNDVALUE VARCHAR2(60 CHAR),
  ANALYTICALMETHODID VARCHAR2(35 CHAR),
  ANALYTICALMETHODIDCONTEXT VARCHAR2(120 CHAR),
  ANALYTICALMETHODNAME VARCHAR2(250 CHAR),
  ANALYTICALMETHODQUALIFIERTYPE VARCHAR2(25 CHAR),
  ANALYTICALMETHODDESC VARCHAR2(4000 CHAR),
  METHODID VARCHAR2(35 CHAR),
  METHODIDCONTEXT VARCHAR2(120 CHAR),
  METHODMODIFICATION VARCHAR2(4000 CHAR),
  LABNAME VARCHAR2(60 CHAR),
  LABANALYSISSTARTDATE DATE,
  LABANALYSISENDDATE DATE,
  LABCOMMENT VARCHAR2(4000 CHAR),
  LABSAMPLESPLITRATIO VARCHAR2(60 CHAR),
  LABACCIND CHAR(1 CHAR),
  LABACCAUTHORITYNAME VARCHAR2(20 CHAR),
  LABTAXACCIND CHAR(1 CHAR),
  LABTAXACCAUTHORITYNAME VARCHAR2(20 CHAR),
  LABANALYSISSTARTTIME VARCHAR2(20 CHAR),
  LABANALYSISSTARTTIMEZONECODE VARCHAR2(4 CHAR),
  LABANALYSISENDTIME VARCHAR2(20 CHAR),
  LABANALYSISENDTIMEZONECODE VARCHAR2(4 CHAR)
);


COMMENT ON TABLE WQX_RESULT IS 'Schema element: ResultDataType'
;

COMMENT ON COLUMN WQX_RESULT.RECORDID IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (RecordId)'
;

COMMENT ON COLUMN WQX_RESULT.PARENTID IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (ParentId)'
;

COMMENT ON COLUMN WQX_RESULT.DATALOGGERLINENAME IS 'The unique line identifier from a data logger result text file, normally a date/time format but could be any user defined name, e.g. "surface", "midwinter", and or "bottom".) (DataLoggerLineName)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTDETECTIONCONDITION IS 'The textual descriptor of a result. (ResultDetectionConditionText)'
;

COMMENT ON COLUMN WQX_RESULT.CHARACTERISTICNAME IS 'The object, property, or substance which is evaluated or enumerated by either a direct field measurement, a direct field observation, or by laboratory analysis of material collected in the field. (CharacteristicName)'
;

COMMENT ON COLUMN WQX_RESULT.CHARACTERISTICNAMEUSERSUPPLIED IS 'The object, property, or substance which is evaluated or enumerated by either a direct field measurement, a direct field observation, or by laboratory analysis of material collected in the field. (CharacteristicNameUserSupplied)'
;

COMMENT ON COLUMN WQX_RESULT.METHODSPECIATIONNAME IS 'Identifies the chemical speciation in which the measured result is expressed. (MethodSpeciationName)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTSAMPFRACTION IS 'The text name of the portion of the sample associated with results obtained from a physically-partitioned sample. (ResultSampleFractionText)'
;

COMMENT ON COLUMN WQX_RESULT.TARGETCOUNT IS 'A code used to identify the intended count that the sorter was aiming for. (TargetCount)'
;

COMMENT ON COLUMN WQX_RESULT.PROPORTIONSAMPLEPROCESSED IS 'This field captures the proportion of the sample processed. Proportion is stored as a number between 0 and 1. Large/rare count would be documented as 1 (100%). (ProportionSampleProcessedNumeric)'
;

COMMENT ON COLUMN WQX_RESULT.STATUSID IS 'Indicates the acceptability of the result with respect to QA/QC criteria. (ResultStatusIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.STATISTICALBASECODE IS 'The code for the method used to calculate derived results. (StatisticalBaseCode)'
;

COMMENT ON COLUMN WQX_RESULT.STATISTICALNVALUE IS 'The number of repeated measurements taken to calculate the result value as an average. (StatisticalNValueNumeric)'
;

COMMENT ON COLUMN WQX_RESULT.VALUETYPE IS 'A name that qualifies the process which was used in the determination of the result value (e.g., actual, estimated, calculated). (ResultValueTypeName)'
;

COMMENT ON COLUMN WQX_RESULT.WEIGHTBASIS IS 'The name that represents the form of the sample or portion of the sample which is associated with the result value (e.g., wet weight, dry weight, ash-free dry weight). (ResultWeightBasisText)'
;

COMMENT ON COLUMN WQX_RESULT.TIMEBASIS IS 'The period of time (in days) over which a measurement was made. For example, BOD can be measured as 5 day or 20 day BOD. (ResultTimeBasisText)'
;

COMMENT ON COLUMN WQX_RESULT.TEMPERATUREBASIS IS 'The name that represents the controlled temperature at which the sample was maintained during analysis, e.g. 25 deg BOD analysis. (ResultTemperatureBasisText)'
;

COMMENT ON COLUMN WQX_RESULT.PARTICLESIZEBASIS IS 'User defined free text describing the particle size class for which the associated result is defined. (ResultParticleSizeBasisText)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTCOMMENT IS 'Free text with general comments concerning the result. (ResultCommentText)'
;

COMMENT ON COLUMN WQX_RESULT.DEPTHALTITUDEREFPOINT IS 'The reference used to indicate the datum or reference used to establish the depth/altitude of a result. (ResultDepthAltitudeReferencePointText)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTSAMPPOINT IS 'Single point name within a sampling frame or protocol that is associated with the reported result. (ResultSamplingPointName)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTSAMPPOINTTYPE IS 'Location of a Single point within a sampling frame or position that is associated with the reported result. (ResultSamplingPointType)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTSAMPPOINTPLACEINSERIES IS 'The order in which a single point within a sampling frame was visited in relation to other components. (ResultSamplingPointPlaceInSeries)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTSAMPPOINTCOMMENT IS 'Text description of a single point within a sampling frame for the result. (ResultSamplingPointCommentText)'
;

COMMENT ON COLUMN WQX_RESULT.RECORDIDUSERSUPPLIED IS 'The user supplied record identifier associated with data entered. (RecordIdentifierUserSupplied)'
;

COMMENT ON COLUMN WQX_RESULT.TMPACTIVITYID IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (TmpActivityId)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTMEASURE IS 'The reportable measure of the result for the chemical, microbiological or other characteristic being analyzed. (ResultMeasureValue)'
;

COMMENT ON COLUMN WQX_RESULT.RESULTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_RESULT.PRECISIONVALUE IS 'A measure of mutual agreement among individual measurements of the same property usually under prescribed similar conditions. (PrecisionValue)'
;

COMMENT ON COLUMN WQX_RESULT.BIASVALUE IS 'The systematic or persistent distortion of a measurement process which causes error in one direction. (BiasValue)'
;

COMMENT ON COLUMN WQX_RESULT.CONFIDENCEINTERVALVALUE IS 'A range of values constructed so that this range has a specified probability of including the true population mean. (ConfidenceIntervalValue)'
;

COMMENT ON COLUMN WQX_RESULT.UPPERCONFIDENCELIMITVALUE IS 'Value of the upper end of the confidence interval. (UpperConfidenceLimitValue)'
;

COMMENT ON COLUMN WQX_RESULT.LOWERCONFIDENCELIMITVALUE IS 'Value of the lower end of the confidence interval. (LowerConfidenceLimitValue)'
;

COMMENT ON COLUMN WQX_RESULT.DEPTHHEIGHTMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_RESULT.DEPTHHEIGHTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTINTENT IS 'The primary reason the biological monitoring has occurred. (BiologicalIntentName)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTINDIVIDUALID IS 'A number uniquely identifying the individual in accordance with the total number of individuals reported by the user. (BiologicalIndividualIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTSUBJECTTAXONOMIC IS 'The name of the organism sampled as part of a biological sample. (SubjectTaxonomicName)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTSUBJECTTAXONOMICUS IS 'The user supplied name of the organism sampled as part of a biological sample. (SubjectTaxonomicNameUserSupplied)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTSUBJECTTAXONOMICUSRT IS 'Identifies the source or data system that created or defined the identifier. (SubjectTaxonomicNameUserSuppliedReferenceText)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTUNIDENTIFIEDSPECIESID IS 'A number or name assigned as a part of a taxonomic identification. Used with a valid genus name to indicate a unique species has been observed but not taxonomically identified. (UnidentifiedSpeciesIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTSAMPTISSUEANATOMY IS 'The name of the anatomy from which a tissue sample was taken. (SampleTissueAnatomyName)'
;

COMMENT ON COLUMN WQX_RESULT.BIORESULTGROUPSUMMARYCOUNT IS 'Captures the total count for a Group Summary. (GroupSummaryCount)'
;

COMMENT ON COLUMN WQX_RESULT.GRPSUMMCOUNTWEIGHTMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_RESULT.GRPSUMMCOUNTWEIGHTMEASUREUNIT IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSCELLFORM IS 'The name of the cell form for phytoplankton organisms expressed as a result. A single phytoplankton species may have a result value for any or all of these cell forms. (CellFormName)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSCELLSHAPE IS 'The cell shape of the phytoplankton organism. (CellShapeName)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSHABITNAME IS 'Parent: This section allows for the further definition of user-defined details for taxa. (HabitNameDBValue)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSVOLTINISM IS 'The number of broods or generations of the characteristic in a year. (VoltinismName)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSPOLLTOLERANCE IS 'For entries representing taxa, a code representing the ability of the reported taxon to tolerate pollution. (TaxonomicPollutionTolerance)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSPOLLTOLERANCESCALE IS 'Provides a description of the scale used for the taxonomic pollution tolerance value. (TaxonomicPollutionToleranceScaleText)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSTROPHICLEVEL IS 'For entries representing taxa, a code representing the trophic level with which the reported taxon is typically assigned. (TrophicLevelName)'
;

COMMENT ON COLUMN WQX_RESULT.TAXDETAILSFUNCFEEDINGGROUP IS 'Parent: This section allows for the further definition of user-defined details for taxa. (FunctionalFeedingGroupNameDBValue)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCETITLE IS 'A name given to the resource. (ResourceTitleName)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCECREATOR IS 'An entity primarily responible for making the content of the resource. (ResourceCreatorName)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCESUBJECT IS 'A topic of the content of the resource. (ResourceSubjectText)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCEPUBLISHER IS 'An entity responsible for making the resource available. (ResourcePublisherName)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCEDATE IS 'A date of an event in the lifecycle of the resource. (ResourceDate)'
;

COMMENT ON COLUMN WQX_RESULT.CITATIONRESOURCEID IS 'An unambiguous reference to the resource within a given context. (ResourceIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.FREQCLASSDESCCODE IS 'A code that describes the frequency class, either as a life stage, abnormality, gender, or measurable characteristic (i.e. length, weight) used to categorize a biological population count. (FrequencyClassDescriptorCode)'
;

COMMENT ON COLUMN WQX_RESULT.FREQCLASSDESCUNITCODE IS 'The code that represents the unit for measuring the item. (FrequencyClassDescriptorUnitCode)'
;

COMMENT ON COLUMN WQX_RESULT.FREQCLASSLOWERBOUNDVALUE IS 'This described the lower bound for a frequency class descriptor. (LowerClassBoundValue)'
;

COMMENT ON COLUMN WQX_RESULT.FREQCLASSUPPERBOUNDVALUE IS 'This described the upper bound for a frequency class descriptor. (UpperClassBoundValue)'
;

COMMENT ON COLUMN WQX_RESULT.ANALYTICALMETHODID IS 'The identification number or code assigned by the method publisher. (MethodIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.ANALYTICALMETHODIDCONTEXT IS 'Identifies the source or data system that created or defined the identifier. (MethodIdentifierContext)'
;

COMMENT ON COLUMN WQX_RESULT.ANALYTICALMETHODNAME IS 'The title that appears on the method from the method publisher. (MethodName)'
;

COMMENT ON COLUMN WQX_RESULT.ANALYTICALMETHODQUALIFIERTYPE IS 'Identifier of type of method that identifies it as reference, equivalent, or other. (MethodQualifierTypeName)'
;

COMMENT ON COLUMN WQX_RESULT.ANALYTICALMETHODDESC IS 'A brief summary that provides general information about the method. (MethodDescriptionText)'
;

COMMENT ON COLUMN WQX_RESULT.METHODID IS 'The identification number or code assigned by the method publisher. (MethodIdentifier)'
;

COMMENT ON COLUMN WQX_RESULT.METHODIDCONTEXT IS 'Identifies the source or data system that created or defined the identifier. (MethodIdentifierContext)'
;

COMMENT ON COLUMN WQX_RESULT.METHODMODIFICATION IS 'A brief summary that provides general information about the modification of the method. (MethodModificationText)'
;

COMMENT ON COLUMN WQX_RESULT.LABNAME IS 'The name of Lab responsible for the result. (LaboratoryName)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISSTARTDATE IS 'The calendar date on which the analysis began. (AnalysisStartDate)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISENDDATE IS 'The calendar date on which the analysis was finished. (AnalysisEndDate)'
;

COMMENT ON COLUMN WQX_RESULT.LABCOMMENT IS 'Remarks which further describe the laboratory procedures which produced the result. (LaboratoryCommentText)'
;

COMMENT ON COLUMN WQX_RESULT.LABSAMPLESPLITRATIO IS 'The proportion of all of the material collected that was sent to lab for analysis. (LaboratorySampleSplitRatio)'
;

COMMENT ON COLUMN WQX_RESULT.LABACCIND IS 'Indicates whether the laboratory is accredited. (LaboratoryAccreditationIndicator)'
;

COMMENT ON COLUMN WQX_RESULT.LABACCAUTHORITYNAME IS 'An outside accreditation authority identifier. (LaboratoryAccreditationAuthorityName)'
;

COMMENT ON COLUMN WQX_RESULT.LABTAXACCIND IS 'Indicates whether the taxonomist is accredited. (TaxonomistAccreditationIndicator)'
;

COMMENT ON COLUMN WQX_RESULT.LABTAXACCAUTHORITYNAME IS 'An outside accreditation authority identifier for the taxonomist. (TaxonomistAccreditationAuthorityName)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISSTARTTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISSTARTTIMEZONECODE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISENDTIME IS 'The time of day that is reported. (Time)'
;

COMMENT ON COLUMN WQX_RESULT.LABANALYSISENDTIMEZONECODE IS 'The time zone for which the time of day is reported. Any of the longitudinal divisions of the earth''s surface in which a standard time is kept. (TimeZoneCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_RESULT on table WQX_RESULT ... 
ALTER TABLE WQX_RESULT
ADD CONSTRAINT PK_WQX_RESULT PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXRESULT TO ROLE_WQX_30;
--DROP TABLE WQX_RESULTATTACHEDBINARYOBJECT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_RESULTATTACHEDBINARYOBJECT ...
CREATE TABLE WQX_RESULTATTACHEDBINARYOBJECT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  BINARYOBJECTFILE VARCHAR2(255 CHAR) NOT NULL,
  BINARYOBJECTFILETYPECODE VARCHAR2(6 CHAR) NOT NULL,
  BINARYOBJECTCONTENT BLOB
);


COMMENT ON TABLE WQX_RESULTATTACHEDBINARYOBJECT IS 'Schema element: ResultAttachedBinaryObjectDataType'
;

COMMENT ON COLUMN WQX_RESULTATTACHEDBINARYOBJECT.RECORDID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (RecordId)'
;

COMMENT ON COLUMN WQX_RESULTATTACHEDBINARYOBJECT.PARENTID IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (ParentId)'
;

COMMENT ON COLUMN WQX_RESULTATTACHEDBINARYOBJECT.BINARYOBJECTFILE IS 'The text describing the descriptive name used to represent the file, including file extension. (BinaryObjectFileName)'
;

COMMENT ON COLUMN WQX_RESULTATTACHEDBINARYOBJECT.BINARYOBJECTFILETYPECODE IS 'The text or acronym describing the binary content type of a file. (BinaryObjectFileTypeCode)'
;

COMMENT ON COLUMN WQX_RESULTATTACHEDBINARYOBJECT.BINARYOBJECTCONTENT IS 'Parent: Reference document, image, photo, GIS data layer, laboratory material or other electronic object attached within a data exchange, as well as information used to describe the object. (BinaryContent)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_RESULTATTACHEDBINARYOBJ on table WQX_RESULTATTACHEDBINARYOBJECT ... 
ALTER TABLE WQX_RESULTATTACHEDBINARYOBJECT
ADD CONSTRAINT PK_WQX_RESULTATTACHEDBINARYOBJ PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXRESULTATTACHEDBINARYOBJECT TO ROLE_WQX_30;
--DROP TABLE WQX_RESULTDETECTQUANTLIMIT CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_RESULTDETECTQUANTLIMIT ...
CREATE TABLE WQX_RESULTDETECTQUANTLIMIT (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  DETECTQUANTLIMITTYPE VARCHAR2(35 CHAR) NOT NULL,
  DETECTQUANTLIMITCOMMENT VARCHAR2(4000 CHAR),
  DETECTQUANTLIMITMEASURE VARCHAR2(60 CHAR) NOT NULL,
  DETECTQUANTLIMITMEASUNITCODE VARCHAR2(12 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_RESULTDETECTQUANTLIMIT IS 'Schema element: DetectionQuantitationLimitDataType'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.RECORDID IS 'Parent: Information that describes one of a variety of detection or quantitation limits determined in a laboratory. (RecordId)'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.PARENTID IS 'Parent: Information that describes one of a variety of detection or quantitation limits determined in a laboratory. (ParentId)'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.DETECTQUANTLIMITTYPE IS 'Text describing the type of detection or quantitation level used in the analysis of a characteristic. (DetectionQuantitationLimitTypeName)'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.DETECTQUANTLIMITCOMMENT IS 'Text providing further description and comment on the detection and/or quantitation limits. (DetectionQuantitationLimitCommentText)'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.DETECTQUANTLIMITMEASURE IS 'The recorded dimension, capacity, quality, or amount of something ascertained by measuring or observing. (MeasureValue)'
;

COMMENT ON COLUMN WQX_RESULTDETECTQUANTLIMIT.DETECTQUANTLIMITMEASUNITCODE IS 'The code that represents the unit for measuring the item. (MeasureUnitCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_RESULTDETECTQUANTLIMIT on table WQX_RESULTDETECTQUANTLIMIT ... 
ALTER TABLE WQX_RESULTDETECTQUANTLIMIT
ADD CONSTRAINT PK_WQX_RESULTDETECTQUANTLIMIT PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXRESULTDETECTQUANTLIMIT TO ROLE_WQX_30;
--DROP TABLE WQX_RESULTMEASUREQUALIFIER CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_RESULTMEASUREQUALIFIER ...
CREATE TABLE WQX_RESULTMEASUREQUALIFIER (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  MEASUREQUALIFIERCODE VARCHAR2(35 CHAR) NOT NULL
);


COMMENT ON TABLE WQX_RESULTMEASUREQUALIFIER IS 'Schema element: ResultMeasureQualifierDataType'
;

COMMENT ON COLUMN WQX_RESULTMEASUREQUALIFIER.RECORDID IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (RecordId)'
;

COMMENT ON COLUMN WQX_RESULTMEASUREQUALIFIER.PARENTID IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (ParentId)'
;

COMMENT ON COLUMN WQX_RESULTMEASUREQUALIFIER.MEASUREQUALIFIERCODE IS 'Parent: Describes the results of a field measurement, observation, or laboratory analysis. (MeasureQualifierCode)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_RESULTMEASUREQUALIFIER on table WQX_RESULTMEASUREQUALIFIER ... 
ALTER TABLE WQX_RESULTMEASUREQUALIFIER
ADD CONSTRAINT PK_WQX_RESULTMEASUREQUALIFIER PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXRESULTMEASUREQUALIFIER TO ROLE_WQX_30;
--DROP TABLE WQX_TELEPHONIC CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_TELEPHONIC ...
CREATE TABLE WQX_TELEPHONIC (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  TELEPHONENUMBER VARCHAR2(15 CHAR) NOT NULL,
  TELEPHONENUMBERTYPE VARCHAR2(6 CHAR),
  TELEPHONEEXT VARCHAR2(6 CHAR)
);


COMMENT ON TABLE WQX_TELEPHONIC IS 'Schema element: TelephonicDataType'
;

COMMENT ON COLUMN WQX_TELEPHONIC.RECORDID IS 'Parent: An identification of a telephone connection. (RecordId)'
;

COMMENT ON COLUMN WQX_TELEPHONIC.PARENTID IS 'Parent: An identification of a telephone connection. (ParentId)'
;

COMMENT ON COLUMN WQX_TELEPHONIC.TELEPHONENUMBER IS 'The number that identifies a particular telephone connection. (TelephoneNumberText)'
;

COMMENT ON COLUMN WQX_TELEPHONIC.TELEPHONENUMBERTYPE IS 'The name that describes a telephone number type. (TelephoneNumberTypeName)'
;

COMMENT ON COLUMN WQX_TELEPHONIC.TELEPHONEEXT IS 'The number assigned within an organization to an individual telephone that extends the external telephone number. (TelephoneExtensionNumberText)'
;

PROMPT  Creating Primary Key Constraint PK_WQX_TELEPHONIC on table WQX_TELEPHONIC ... 
ALTER TABLE WQX_TELEPHONIC
ADD CONSTRAINT PK_WQX_TELEPHONIC PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXTELEPHONIC TO ROLE_WQX_30;
--DROP TABLE WQX_SUBMISSIONHISTORY CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_SUBMISSIONHISTORY ...
CREATE TABLE WQX_SUBMISSIONHISTORY (
  RECORDID VARCHAR2(50 CHAR) NOT NULL,
  PARENTID VARCHAR2(50 CHAR) NOT NULL,
  SCHEDULERUNDATE DATE NOT NULL,
  WQXUPDATEDATE DATE NOT NULL,
  SUBMISSIONTYPE VARCHAR2(13 CHAR) NOT NULL,
  LOCALTRANSACTIONID VARCHAR2(50 CHAR) NOT NULL,
  CDXPROCESSINGSTATUS VARCHAR2(50 CHAR) NOT NULL,
  ORGID VARCHAR2(30 CHAR) NOT NULL
);


PROMPT  Creating Primary Key Constraint PK_WQX_SUBMISSIONHISTORY on table WQX_SUBMISSIONHISTORY ... 
ALTER TABLE WQX_SUBMISSIONHISTORY
ADD CONSTRAINT PK_WQX_SUBMISSIONHISTORY PRIMARY KEY
(
  RECORDID
)
ENABLE
;

-- GRANT ALL ON WQXSUBMISSIONHISTORY TO ROLE_WQX_30;
--DROP TABLE WQX_ABOUT_DB CASCADE CONSTRAINTS;


PROMPT  Creating Table WQX_ABOUT_DB ...
CREATE TABLE WQX_ABOUT_DB (
  WQX_ABOUT_DB_ID VARCHAR2(36 CHAR) NOT NULL,
  DATA_KEY VARCHAR2(50) NOT NULL,
  DATA_VALUE VARCHAR2(4000)
);


PROMPT  Creating Primary Key Constraint PK_ABOUT_DB on table WQX_ABOUT_DB ... 
ALTER TABLE WQX_ABOUT_DB
ADD CONSTRAINT PK_ABOUT_DB PRIMARY KEY
(
  WQX_ABOUT_DB_ID
)
ENABLE
;

-- GRANT ALL ON WQXABOUT_DB TO ROLE_WQX_30;
PROMPT  Creating Index IX_WQX_DELETES_PARENTID on WQX_DELETES ...
CREATE INDEX IX_WQX_DELETES_PARENTID ON WQX_DELETES
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_DELETES_WQXUPDATEDATE on WQX_DELETES ...
CREATE INDEX IX_WQX_DELETES_WQXUPDATEDATE ON WQX_DELETES
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_ELECTRONICADDRES_PARENT on WQX_ELECTRONICADDRESS ...
CREATE INDEX IX_WQX_ELECTRONICADDRES_PARENT ON WQX_ELECTRONICADDRESS
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_MONITORING_MONITORINGLO on WQX_MONITORINGLOCATION ...
CREATE INDEX IX_WQX_MONITORING_MONITORINGLO ON WQX_MONITORINGLOCATION
(
  MONITORINGLOCATIONID
) 
;
PROMPT  Creating Index IX_WQX_MONITORINGLOCA_WQXUPDAT on WQX_MONITORINGLOCATION ...
CREATE INDEX IX_WQX_MONITORINGLOCA_WQXUPDAT ON WQX_MONITORINGLOCATION
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_MONITORINGLOCATI_PARENT on WQX_MONITORINGLOCATION ...
CREATE INDEX IX_WQX_MONITORINGLOCATI_PARENT ON WQX_MONITORINGLOCATION
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_MONLOCATTACHEDBIN_PAREN on WQX_MONLOCATTACHEDBINARYOBJECT ...
CREATE INDEX IX_WQX_MONLOCATTACHEDBIN_PAREN ON WQX_MONLOCATTACHEDBINARYOBJECT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ORGANIZATION_ORGID on WQX_ORGANIZATION ...
CREATE INDEX IX_WQX_ORGANIZATION_ORGID ON WQX_ORGANIZATION
(
  ORGID
) 
;
PROMPT  Creating Index IX_WQX_PROJATTACHEDBINAR_PAREN on WQX_PROJATTACHEDBINARYOBJECT ...
CREATE INDEX IX_WQX_PROJATTACHEDBINAR_PAREN ON WQX_PROJATTACHEDBINARYOBJECT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_PROJECTACTI_ACTIVITYPAR on WQX_PROJECTACTIVITY ...
CREATE INDEX IX_WQX_PROJECTACTI_ACTIVITYPAR ON WQX_PROJECTACTIVITY
(
  ACTIVITYPARENTID
) 
;
PROMPT  Creating Index IX_WQX_PROJECTACTI_PROJECTPARE on WQX_PROJECTACTIVITY ...
CREATE INDEX IX_WQX_PROJECTACTI_PROJECTPARE ON WQX_PROJECTACTIVITY
(
  PROJECTPARENTID
) 
;
PROMPT  Creating Index IX_WQX_RESULT_PARENTID on WQX_RESULT ...
CREATE INDEX IX_WQX_RESULT_PARENTID ON WQX_RESULT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_RESULTATTACHEDBIN_PAREN on WQX_RESULTATTACHEDBINARYOBJECT ...
CREATE INDEX IX_WQX_RESULTATTACHEDBIN_PAREN ON WQX_RESULTATTACHEDBINARYOBJECT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_RESULTMEASUREQUAL_PAREN on WQX_RESULTMEASUREQUALIFIER ...
CREATE INDEX IX_WQX_RESULTMEASUREQUAL_PAREN ON WQX_RESULTMEASUREQUALIFIER
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_TELEPHONIC_PARENTID on WQX_TELEPHONIC ...
CREATE INDEX IX_WQX_TELEPHONIC_PARENTID ON WQX_TELEPHONIC
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_SBMSS_PRNTD on WQX_SUBMISSIONHISTORY ...
CREATE INDEX IX_WQX_SBMSS_PRNTD ON WQX_SUBMISSIONHISTORY
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_SBMSS_WQXPD on WQX_SUBMISSIONHISTORY ...
CREATE INDEX IX_WQX_SBMSS_WQXPD ON WQX_SUBMISSIONHISTORY
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_ACTATTACHEDBINARY_PAREN on WQX_ACTATTACHEDBINARYOBJECT ...
CREATE INDEX IX_WQX_ACTATTACHEDBINARY_PAREN ON WQX_ACTATTACHEDBINARYOBJECT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVIT_ACTIVITYSTARTDA on WQX_ACTIVITY ...
CREATE INDEX IX_WQX_ACTIVIT_ACTIVITYSTARTDA ON WQX_ACTIVITY
(
  ACTIVITYSTARTDATE
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITY_ACTIVITYID on WQX_ACTIVITY ...
CREATE INDEX IX_WQX_ACTIVITY_ACTIVITYID ON WQX_ACTIVITY
(
  ACTIVITYID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITY_MONLOCID on WQX_ACTIVITY ...
CREATE INDEX IX_WQX_ACTIVITY_MONLOCID ON WQX_ACTIVITY
(
  MONLOCID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITY_PARENTID on WQX_ACTIVITY ...
CREATE INDEX IX_WQX_ACTIVITY_PARENTID ON WQX_ACTIVITY
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITY_WQXUPDATEDATE on WQX_ACTIVITY ...
CREATE INDEX IX_WQX_ACTIVITY_WQXUPDATEDATE ON WQX_ACTIVITY
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYACT_ACTIVITYGRO on WQX_ACTIVITYACTIVITYGROUP ...
CREATE INDEX IX_WQX_ACTIVITYACT_ACTIVITYGRO ON WQX_ACTIVITYACTIVITYGROUP
(
  ACTIVITYGROUPPARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYACTIVI_ACTIVITY on WQX_ACTIVITYACTIVITYGROUP ...
CREATE INDEX IX_WQX_ACTIVITYACTIVI_ACTIVITY ON WQX_ACTIVITYACTIVITYGROUP
(
  ACTIVITYPARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYCONDUCTIN_PAREN on WQX_ACTIVITYCONDUCTINGORG ...
CREATE INDEX IX_WQX_ACTIVITYCONDUCTIN_PAREN ON WQX_ACTIVITYCONDUCTINGORG
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYGRO_WQXUPDATEDA on WQX_ACTIVITYGROUP ...
CREATE INDEX IX_WQX_ACTIVITYGRO_WQXUPDATEDA ON WQX_ACTIVITYGROUP
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYGROUP_PARENTID on WQX_ACTIVITYGROUP ...
CREATE INDEX IX_WQX_ACTIVITYGROUP_PARENTID ON WQX_ACTIVITYGROUP
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ACTIVITYMETRIC_PARENTID on WQX_ACTIVITYMETRIC ...
CREATE INDEX IX_WQX_ACTIVITYMETRIC_PARENTID ON WQX_ACTIVITYMETRIC
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ALTMONLOC_PARENTID on WQX_ALTMONLOC ...
CREATE INDEX IX_WQX_ALTMONLOC_PARENTID ON WQX_ALTMONLOC
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_BIOLOGICALHABITA_WQXUPD on WQX_BIOLOGICALHABITATINDEX ...
CREATE INDEX IX_WQX_BIOLOGICALHABITA_WQXUPD ON WQX_BIOLOGICALHABITATINDEX
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_BIOLOGICALHABITAT_MONLO on WQX_BIOLOGICALHABITATINDEX ...
CREATE INDEX IX_WQX_BIOLOGICALHABITAT_MONLO ON WQX_BIOLOGICALHABITATINDEX
(
  MONLOCID
) 
;
PROMPT  Creating Index IX_WQX_BIOLOGICALHABITAT_PAREN on WQX_BIOLOGICALHABITATINDEX ...
CREATE INDEX IX_WQX_BIOLOGICALHABITAT_PAREN ON WQX_BIOLOGICALHABITATINDEX
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_LABSAMPLEPREP_PARENTID on WQX_LABSAMPLEPREP ...
CREATE INDEX IX_WQX_LABSAMPLEPREP_PARENTID ON WQX_LABSAMPLEPREP
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_ORGADDRESS_PARENTID on WQX_ORGADDRESS ...
CREATE INDEX IX_WQX_ORGADDRESS_PARENTID ON WQX_ORGADDRESS
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_PROJECT_PARENTID on WQX_PROJECT ...
CREATE INDEX IX_WQX_PROJECT_PARENTID ON WQX_PROJECT
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_PROJECT_PROJECTID on WQX_PROJECT ...
CREATE INDEX IX_WQX_PROJECT_PROJECTID ON WQX_PROJECT
(
  PROJECTID
) 
;
PROMPT  Creating Index IX_WQX_PROJECT_WQXUPDATEDATE on WQX_PROJECT ...
CREATE INDEX IX_WQX_PROJECT_WQXUPDATEDATE ON WQX_PROJECT
(
  WQXUPDATEDATE
) 
;
PROMPT  Creating Index IX_WQX_PROJECTMONLOC_PARENTID on WQX_PROJECTMONLOC ...
CREATE INDEX IX_WQX_PROJECTMONLOC_PARENTID ON WQX_PROJECTMONLOC
(
  PARENTID
) 
;
PROMPT  Creating Index IX_WQX_RESULTDETECTQUANT_PAREN on WQX_RESULTDETECTQUANTLIMIT ...
CREATE INDEX IX_WQX_RESULTDETECTQUANT_PAREN ON WQX_RESULTDETECTQUANTLIMIT
(
  PARENTID
) 
;
create or replace SYNONYM utils for "EMULATION".utils;



--set define on
--PROMPT  Connecting to WQX_30
--alter session set current_schema=WQX_30;
--set define off
PROMPT  Creating Foreign Key Constraint FK_WQX_ACTIVITYMETR_WQX_ACTIVI on table WQX_ACTIVITY...
ALTER TABLE WQX_ACTIVITYMETRIC
ADD CONSTRAINT FK_WQX_ACTIVITYMETR_WQX_ACTIVI FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ACTIVITY
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_RESULTDETECTQ_WQX_RESUL on table WQX_RESULT...
ALTER TABLE WQX_RESULTDETECTQUANTLIMIT
ADD CONSTRAINT FK_WQX_RESULTDETECTQ_WQX_RESUL FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_RESULT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_BIOLOGICALHAB_WQX_ORGAN on table WQX_ORGANIZATION...
ALTER TABLE WQX_BIOLOGICALHABITATINDEX
ADD CONSTRAINT FK_WQX_BIOLOGICALHAB_WQX_ORGAN FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_PROJECTMONLO_WQX_PROJEC on table WQX_PROJECT...
ALTER TABLE WQX_PROJECTMONLOC
ADD CONSTRAINT FK_WQX_PROJECTMONLO_WQX_PROJEC FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_PROJECT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_MONITORINGLO_WQX_ORGANI on table WQX_ORGANIZATION...
ALTER TABLE WQX_MONITORINGLOCATION
ADD CONSTRAINT FK_WQX_MONITORINGLO_WQX_ORGANI FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_RESULTMEASURE_WQX_RESUL on table WQX_RESULT...
ALTER TABLE WQX_RESULTMEASUREQUALIFIER
ADD CONSTRAINT FK_WQX_RESULTMEASURE_WQX_RESUL FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_RESULT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_LABSAMPLEPREP_WQX_RESUL on table WQX_RESULT...
ALTER TABLE WQX_LABSAMPLEPREP
ADD CONSTRAINT FK_WQX_LABSAMPLEPREP_WQX_RESUL FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_RESULT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ACTIVITYACTIV_WQX_ACTIV on table WQX_ACTIVITYGROUP...
ALTER TABLE WQX_ACTIVITYACTIVITYGROUP
ADD CONSTRAINT FK_WQX_ACTIVITYACTIV_WQX_ACTIV FOREIGN KEY
(
  ACTIVITYGROUPPARENTID
)
REFERENCES WQX_ACTIVITYGROUP
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ELECTRONICAD_WQX_ORGANI on table WQX_ORGANIZATION...
ALTER TABLE WQX_ELECTRONICADDRESS
ADD CONSTRAINT FK_WQX_ELECTRONICAD_WQX_ORGANI FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ACTIVITYCONDU_WQX_ACTIV on table WQX_ACTIVITY...
ALTER TABLE WQX_ACTIVITYCONDUCTINGORG
ADD CONSTRAINT FK_WQX_ACTIVITYCONDU_WQX_ACTIV FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ACTIVITY
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ALTMO_WQX_MONITORINGLOC on table WQX_MONITORINGLOCATION...
ALTER TABLE WQX_ALTMONLOC
ADD CONSTRAINT FK_WQX_ALTMO_WQX_MONITORINGLOC FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_MONITORINGLOCATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_TELEPHON_WQX_ORGANIZATI on table WQX_ORGANIZATION...
ALTER TABLE WQX_TELEPHONIC
ADD CONSTRAINT FK_WQX_TELEPHON_WQX_ORGANIZATI FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ACTIVIT_WQX_ORGANIZATIO on table WQX_ORGANIZATION...
ALTER TABLE WQX_ACTIVITY
ADD CONSTRAINT FK_WQX_ACTIVIT_WQX_ORGANIZATIO FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ORGADDRE_WQX_ORGANIZATI on table WQX_ORGANIZATION...
ALTER TABLE WQX_ORGADDRESS
ADD CONSTRAINT FK_WQX_ORGADDRE_WQX_ORGANIZATI FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_PROJECT_WQX_ORGANIZATIO on table WQX_ORGANIZATION...
ALTER TABLE WQX_PROJECT
ADD CONSTRAINT FK_WQX_PROJECT_WQX_ORGANIZATIO FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ACTIVITYGR_WQX_ORGANIZA on table WQX_ORGANIZATION...
ALTER TABLE WQX_ACTIVITYGROUP
ADD CONSTRAINT FK_WQX_ACTIVITYGR_WQX_ORGANIZA FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_RESULT_WQX_ACTIVITY on table WQX_ACTIVITY...
ALTER TABLE WQX_RESULT
ADD CONSTRAINT FK_WQX_RESULT_WQX_ACTIVITY FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ACTIVITY
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_PROJATTACHEDB_WQX_PROJE on table WQX_PROJECT...
ALTER TABLE WQX_PROJATTACHEDBINARYOBJECT
ADD CONSTRAINT FK_WQX_PROJATTACHEDB_WQX_PROJE FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_PROJECT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_DELETES_WQX_ORGANIZATIO on table WQX_ORGANIZATION...
ALTER TABLE WQX_DELETES
ADD CONSTRAINT FK_WQX_DELETES_WQX_ORGANIZATIO FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ORGANIZATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_PROJECTACTIVI_WQX_ACTIV on table WQX_ACTIVITY...
ALTER TABLE WQX_PROJECTACTIVITY
ADD CONSTRAINT FK_WQX_PROJECTACTIVI_WQX_ACTIV FOREIGN KEY
(
  ACTIVITYPARENTID
)
REFERENCES WQX_ACTIVITY
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_RESULTATTACHE_WQX_RESUL on table WQX_RESULT...
ALTER TABLE WQX_RESULTATTACHEDBINARYOBJECT
ADD CONSTRAINT FK_WQX_RESULTATTACHE_WQX_RESUL FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_RESULT
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_MONLOCATTACHE_WQX_MONIT on table WQX_MONITORINGLOCATION...
ALTER TABLE WQX_MONLOCATTACHEDBINARYOBJECT
ADD CONSTRAINT FK_WQX_MONLOCATTACHE_WQX_MONIT FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_MONITORINGLOCATION
(
  RECORDID
)
ENABLE
;

PROMPT  Creating Foreign Key Constraint FK_WQX_ACTATTACHEDBI_WQX_ACTIV on table WQX_ACTIVITY...
ALTER TABLE WQX_ACTATTACHEDBINARYOBJECT
ADD CONSTRAINT FK_WQX_ACTATTACHEDBI_WQX_ACTIV FOREIGN KEY
(
  PARENTID
)
REFERENCES WQX_ACTIVITY
(
  RECORDID
)
ENABLE
;


CREATE VIEW WQX_V_ACTIVITYGROUPID_HIB AS
SELECT WQX_ACTIVITYACTIVITYGROUP.ACTIVITYGROUPPARENTID
     , WQX_ACTIVITY.ACTIVITYID 
  FROM WQX_ACTIVITYACTIVITYGROUP 
  JOIN WQX_ACTIVITY 
    ON WQX_ACTIVITYACTIVITYGROUP.ACTIVITYPARENTID = WQX_ACTIVITY.RECORDID;

CREATE VIEW WQX_V_ATTACHEDBINARYOBJECT_HIB AS
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
FROM WQX_RESULTATTACHEDBINARYOBJECT;


CREATE VIEW WQX_V_PROJECTACTIVITYID_HIB AS
SELECT WQX_PROJECTACTIVITY.ACTIVITYPARENTID
     , WQX_PROJECT.PROJECTID 
  FROM WQX_PROJECTACTIVITY 
  JOIN WQX_ACTIVITY 
    ON WQX_PROJECTACTIVITY.ACTIVITYPARENTID = WQX_ACTIVITY.RECORDID
  JOIN WQX_PROJECT 
    ON WQX_PROJECTACTIVITY.PROJECTPARENTID = WQX_PROJECT.RECORDID;


CREATE TABLE WQX_ABOUT_DB
(
WQX_ABOUT_DB_ID varchar2 (36) NOT NULL,
DATA_KEY varchar2 (50)  NOT NULL,
DATA_VALUE varchar2 (4000) NULL
);


INSERT INTO WQX_ABOUT_DB
SELECT SYS_GUID() , 'WQX Version', '3.0' FROM DUAL
UNION
SELECT SYS_GUID(), 'Database', 'SQL Server' FROM DUAL;