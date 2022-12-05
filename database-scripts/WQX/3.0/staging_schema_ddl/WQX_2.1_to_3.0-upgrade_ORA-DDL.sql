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
 ** ObjectName: WQX_2.1_to_3.0-upgrade_ORA-DDL.sql
 **
 ** Author: Windsor Solutions, Inc.
 **
 ** Company Name: Windsor Solutions, Inc
 **
 ** Description: Updates the Oracle WQX 2.1 staging tables and views needed to support the OpenNode2 WQX 3.0 plugin.
 **
 ** Notes: 
 **
 **
 ** Revision History:      
 ** ----------------------------------------------------------------------------------------------------------------------------
 **  Date         Name        Description
 ** ----------------------------------------------------------------------------------------------------------------------------
 ** 05/12/2021    Windsor    Upgrade v2.1 to v3.0 WQX Oracle script.
 **
 ******************************************************************************************************************************/

---------------------------
--Changed TABLE
--WQX_TELEPHONIC
---------------------------
ALTER TABLE "WQX_TELEPHONIC" DROP CONSTRAINT "FK_ORG_TELEPHONIC";
ALTER TABLE "WQX_TELEPHONIC" ADD CONSTRAINT "FK_WQX_TELEPHON_WQX_ORGANIZATI" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--New TABLE
--WQX_RESULTMEASUREQUALIFIER
---------------------------
  CREATE TABLE "WQX_RESULTMEASUREQUALIFIER" 
   ( "RECORDID" VARCHAR2(50 CHAR) NOT NULL ENABLE,
 "PARENTID" VARCHAR2(50 CHAR) NOT NULL ENABLE,
 "MEASUREQUALIFIERCODE" VARCHAR2(35 CHAR) NOT NULL ENABLE,
 CONSTRAINT "PK_WQX_RESULTMEASUREQUALIFIER" PRIMARY KEY ("RECORDID") ENABLE,
 CONSTRAINT "FK_WQX_RESULTMEASURE_WQX_RESUL" FOREIGN KEY ("PARENTID")
  REFERENCES "WQX_RESULT" ("RECORDID") ENABLE
   );
---------------------------
--Changed TABLE
--WQX_RESULTDETECTQUANTLIMIT
---------------------------
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" ADD ("DETECTQUANTLIMITCOMMENT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" MODIFY ("DETECTQUANTLIMITMEASUNITCODE" NOT NULL ENABLE);
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" MODIFY ("DETECTQUANTLIMITMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" MODIFY ("DETECTQUANTLIMITMEASURE" NOT NULL ENABLE);
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" DROP CONSTRAINT "FK_RESULT_RESULTDETQUANTLIMIT";
ALTER TABLE "WQX_RESULTDETECTQUANTLIMIT" ADD CONSTRAINT "FK_WQX_RESULTDETECTQ_WQX_RESUL" FOREIGN KEY ("PARENTID") REFERENCES "WQX_RESULT"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_RESULTATTACHEDBINARYOBJECT
---------------------------
ALTER TABLE "WQX_RESULTATTACHEDBINARYOBJECT" DROP CONSTRAINT "FK_RESULT_RESULTATTBINOBJ";
ALTER TABLE "WQX_RESULTATTACHEDBINARYOBJECT" ADD CONSTRAINT "FK_WQX_RESULTATTACHE_WQX_RESUL" FOREIGN KEY ("PARENTID") REFERENCES "WQX_RESULT"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_RESULT
---------------------------
ALTER TABLE "WQX_RESULT" ADD ("BIORESULTGROUPSUMMARYCOUNT" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("BIORESULTSUBJECTTAXONOMICUS" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("BIORESULTSUBJECTTAXONOMICUSRT" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("CHARACTERISTICNAMEUSERSUPPLIED" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("LABCOMMENT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("LABSAMPLESPLITRATIO" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("METHODID" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("METHODIDCONTEXT" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("METHODMODIFICATION" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("PROPORTIONSAMPLEPROCESSED" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("RECORDIDUSERSUPPLIED" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("RESULTSAMPPOINTCOMMENT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("RESULTSAMPPOINTPLACEINSERIES" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("RESULTSAMPPOINTTYPE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" ADD ("STATISTICALNVALUE" NUMBER(10,0));
ALTER TABLE "WQX_RESULT" ADD ("TARGETCOUNT" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_RESULT" DROP ("RESULTLABCOMMENTCODE");
ALTER TABLE "WQX_RESULT" DROP ("RESULTMEASUREQUALIFIERCODE");
ALTER TABLE "WQX_RESULT" MODIFY ("ANALYTICALMETHODID" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("ANALYTICALMETHODNAME" VARCHAR2(250 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("BIORESULTINDIVIDUALID" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("BIORESULTSAMPTISSUEANATOMY" VARCHAR2(50 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("BIORESULTSUBJECTTAXONOMIC" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("BIORESULTUNIDENTIFIEDSPECIESID" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("CHARACTERISTICNAME" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("CITATIONRESOURCESUBJECT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("CONFIDENCEINTERVALVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("DATALOGGERLINENAME" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("DEPTHHEIGHTMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("FREQCLASSLOWERBOUNDVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("FREQCLASSUPPERBOUNDVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("GRPSUMMCOUNTWEIGHTMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("LOWERCONFIDENCELIMITVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("RESULTSAMPPOINT" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("TAXDETAILSFUNCFEEDINGGROUP" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("TAXDETAILSHABITNAME" VARCHAR2(15 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("TAXDETAILSPOLLTOLERANCE" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("TAXDETAILSTROPHICLEVEL" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("TMPACTIVITYID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("UPPERCONFIDENCELIMITVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" MODIFY ("WEIGHTBASIS" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_RESULT" DROP CONSTRAINT "FK_ACTIVITY_RESULT";
ALTER TABLE "WQX_RESULT" ADD CONSTRAINT "FK_WQX_RESULT_WQX_ACTIVITY" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ACTIVITY"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_PROJECTMONLOC
---------------------------
ALTER TABLE "WQX_PROJECTMONLOC" MODIFY ("LOCWEIGHTINGFACMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_PROJECTMONLOC" MODIFY ("MONLOCID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_PROJECTMONLOC" MODIFY ("RESOURCESUBJECT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_PROJECTMONLOC" DROP CONSTRAINT "FK_PROJECT_PROJECTMONLOC";
ALTER TABLE "WQX_PROJECTMONLOC" ADD CONSTRAINT "FK_WQX_PROJECTMONLO_WQX_PROJEC" FOREIGN KEY ("PARENTID") REFERENCES "WQX_PROJECT"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_PROJECTACTIVITY
---------------------------
ALTER TABLE "WQX_PROJECTACTIVITY" DROP CONSTRAINT "FK_ACTIVITY_PROJECTACTIVITY";
ALTER TABLE "WQX_PROJECTACTIVITY" DROP CONSTRAINT "FK_PROJECT_PROJECTACTIVITY";
ALTER TABLE "WQX_PROJECTACTIVITY" ADD CONSTRAINT "FK_WQX_PROJECTACTIVI_WQX_ACTIV" FOREIGN KEY ("ACTIVITYPARENTID") REFERENCES "WQX_ACTIVITY"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_PROJECT
---------------------------
ALTER TABLE "WQX_PROJECT" MODIFY ("PROJECTDESC" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_PROJECT" MODIFY ("PROJECTID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_PROJECT" MODIFY ("PROJECTNAME" VARCHAR2(512 CHAR));
ALTER TABLE "WQX_PROJECT" DROP CONSTRAINT "FK_ORG_PROJECT";
ALTER TABLE "WQX_PROJECT" ADD CONSTRAINT "FK_WQX_PROJECT_WQX_ORGANIZATIO" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_PROJATTACHEDBINARYOBJECT
---------------------------
ALTER TABLE "WQX_PROJATTACHEDBINARYOBJECT" DROP CONSTRAINT "FK_PROJECT_PROJATTBINOBJ";
ALTER TABLE "WQX_PROJATTACHEDBINARYOBJECT" ADD CONSTRAINT "FK_WQX_PROJATTACHEDB_WQX_PROJE" FOREIGN KEY ("PARENTID") REFERENCES "WQX_PROJECT"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ORGANIZATION
---------------------------
ALTER TABLE "WQX_ORGANIZATION" MODIFY ("ORGFORMALNAME" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_ORGANIZATION" MODIFY ("ORGID" VARCHAR2(35 CHAR));

---------------------------
--Changed TABLE
--WQX_ORGADDRESS
---------------------------
ALTER TABLE "WQX_ORGADDRESS" DROP CONSTRAINT "FK_ORG_ORGADDRESS";
ALTER TABLE "WQX_ORGADDRESS" ADD CONSTRAINT "FK_WQX_ORGADDRE_WQX_ORGANIZATI" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_MONLOCATTACHEDBINARYOBJECT
---------------------------
ALTER TABLE "WQX_MONLOCATTACHEDBINARYOBJECT" DROP CONSTRAINT "FK_MONLOC_MONLOCATTBINOBJ";
ALTER TABLE "WQX_MONLOCATTACHEDBINARYOBJECT" ADD CONSTRAINT "FK_WQX_MONLOCATTACHE_WQX_MONIT" FOREIGN KEY ("PARENTID") REFERENCES "WQX_MONITORINGLOCATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_MONITORINGLOCATION
---------------------------
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("CONSTRUCTIONDATE" DATE);
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("CONTRDRAINAGEAREAMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("CONTRDRAINAGEAREAMEASUREUNIT" VARCHAR2(12 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("DRAINAGEAREAMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("DRAINAGEAREAMEASUREUNIT" VARCHAR2(12 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("LOCALAQUIFERCODE" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("LOCALAQUIFERCODECONTEXT" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("LOCALAQUIFERDESCRIPTION" VARCHAR2(512 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("LOCALAQUIFERNAME" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("NATIONALAQUIFERCODE" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("VERTICALACCURACYMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("VERTICALACCURACYMEASUREUNIT" VARCHAR2(12 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("WELLDEPTHMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" ADD ("WELLDEPTHMEASUREUNIT" VARCHAR2(12 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("AQUIFERNAME" VARCHAR2(255 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("HORIZACCURACYMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("MONITORINGLOCATIONID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("SOURCEMAPSCALE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("TRIBALLANDNAME" VARCHAR2(512 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("VERTICALMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" MODIFY ("WELLHOLEDEPTHMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_MONITORINGLOCATION" DROP CONSTRAINT "FK_ORG_MONITORINGLOCATION";
ALTER TABLE "WQX_MONITORINGLOCATION" ADD CONSTRAINT "FK_WQX_MONITORINGLO_WQX_ORGANI" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_LABSAMPLEPREP
---------------------------
ALTER TABLE "WQX_LABSAMPLEPREP" MODIFY ("METHODDESC" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_LABSAMPLEPREP" MODIFY ("METHODID" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_LABSAMPLEPREP" MODIFY ("METHODNAME" VARCHAR2(250 CHAR));
ALTER TABLE "WQX_LABSAMPLEPREP" MODIFY ("SUBSTANCEDILUTIONFACTOR" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_LABSAMPLEPREP" DROP CONSTRAINT "FK_RESULT_LABSAMPLEPREP";
ALTER TABLE "WQX_LABSAMPLEPREP" ADD CONSTRAINT "FK_WQX_LABSAMPLEPREP_WQX_RESUL" FOREIGN KEY ("PARENTID") REFERENCES "WQX_RESULT"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ELECTRONICADDRESS
---------------------------
ALTER TABLE "WQX_ELECTRONICADDRESS" DROP CONSTRAINT "FK_ORG_ELECTRONICADDRESS";
ALTER TABLE "WQX_ELECTRONICADDRESS" ADD CONSTRAINT "FK_WQX_ELECTRONICAD_WQX_ORGANI" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_DELETES
---------------------------
ALTER TABLE "WQX_DELETES" DROP CONSTRAINT "FK_WQX_DELETES_WQX_ORG";
ALTER TABLE "WQX_DELETES" ADD CONSTRAINT "FK_WQX_DELETES_WQX_ORGANIZATIO" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_BIOLOGICALHABITATINDEX
---------------------------
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("INDEXID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("INDEXQUALIFIERCODE" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("INDEXSCORE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("INDEXTYPEID" VARCHAR2(50 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("INDEXTYPENAME" VARCHAR2(100 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("MONLOCID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" MODIFY ("RESOURCESUBJECT" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" DROP CONSTRAINT "FK_ORG_BIOLOGICALHABITATINDEX";
ALTER TABLE "WQX_BIOLOGICALHABITATINDEX" ADD CONSTRAINT "FK_WQX_BIOLOGICALHAB_WQX_ORGAN" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ALTMONLOC
---------------------------
ALTER TABLE "WQX_ALTMONLOC" MODIFY ("MONLOCID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ALTMONLOC" DROP CONSTRAINT "FK_MONLOC_ALTMONLOC";
ALTER TABLE "WQX_ALTMONLOC" ADD CONSTRAINT "FK_WQX_ALTMO_WQX_MONITORINGLOC" FOREIGN KEY ("PARENTID") REFERENCES "WQX_MONITORINGLOCATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTIVITYMETRIC
---------------------------
ALTER TABLE "WQX_ACTIVITYMETRIC" ADD ("METRICSAMPPOINTPLACEINSERIES" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICINDEXID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICSCORE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICTYPEFORMULADESC" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICTYPEID" VARCHAR2(50 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICTYPENAME" VARCHAR2(100 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" MODIFY ("METRICVALUEMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITYMETRIC" DROP CONSTRAINT "FK_ACTIVITY_ACTIVITYMETRIC";
ALTER TABLE "WQX_ACTIVITYMETRIC" ADD CONSTRAINT "FK_WQX_ACTIVITYMETR_WQX_ACTIVI" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ACTIVITY"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTIVITYGROUP
---------------------------
ALTER TABLE "WQX_ACTIVITYGROUP" ADD ("REPLACEACTIVITIES" CHAR(1 CHAR));
ALTER TABLE "WQX_ACTIVITYGROUP" MODIFY ("ACTIVITYGROUPID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITYGROUP" MODIFY ("ACTIVITYGROUPNAME" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_ACTIVITYGROUP" DROP CONSTRAINT "FK_ORG_ACTIVITYGROUP";
ALTER TABLE "WQX_ACTIVITYGROUP" ADD CONSTRAINT "FK_WQX_ACTIVITYGR_WQX_ORGANIZA" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTIVITYCONDUCTINGORG
---------------------------
ALTER TABLE "WQX_ACTIVITYCONDUCTINGORG" DROP CONSTRAINT "FK_ACTIVITY_ACTCONDUCTINGORG";
ALTER TABLE "WQX_ACTIVITYCONDUCTINGORG" ADD CONSTRAINT "FK_WQX_ACTIVITYCONDU_WQX_ACTIV" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ACTIVITY"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTIVITYACTIVITYGROUP
---------------------------
ALTER TABLE "WQX_ACTIVITYACTIVITYGROUP" DROP CONSTRAINT "FK_ACTIVITYGROUP_ACTACTGROUP";
ALTER TABLE "WQX_ACTIVITYACTIVITYGROUP" DROP CONSTRAINT "FK_ACTIVITY_ACTACTGROUP";
ALTER TABLE "WQX_ACTIVITYACTIVITYGROUP" ADD CONSTRAINT "FK_WQX_ACTIVITYACTIV_WQX_ACTIV" FOREIGN KEY ("ACTIVITYGROUPPARENTID") REFERENCES "WQX_ACTIVITYGROUP"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTIVITY
---------------------------
ALTER TABLE "WQX_ACTIVITY" ADD ("ACTIVITYIDUSERSUPPLIED" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("ACTIVITYLOCATIONDESCRIPTION" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("COLLECEFFORTGEARPROCEDUREUNIT" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("COLLECEFFORTMEASUREVALUE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("COLLECTIONAREAMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("COLLECTIONAREAMEASUREUNIT" VARCHAR2(12 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("COLLECTIONDESCRIPTION" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("HABITATSELECTIONMETHOD" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("HYDROLOGICCONDITION" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("HYDROLOGICEVENT" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("SAMPLINGCOMPONENTNAME" VARCHAR2(120 CHAR));
ALTER TABLE "WQX_ACTIVITY" ADD ("SAMPPREPCONTLABEL" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" DROP ("BIOHABSAMPCOMP");
ALTER TABLE "WQX_ACTIVITY" DROP ("BIOHABSAMPCOMPPLACEINSERIES");
ALTER TABLE "WQX_ACTIVITY" DROP ("RESULTCOUNT");
ALTER TABLE "WQX_ACTIVITY" MODIFY ("ACTIVITYID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("ACTIVITYMEDIASUBDIVISION" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOACTIVITYTOXICITYTESTTYPE" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABCOLLDURATIONMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABNETBOATSPEEDMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABNETCURRSPEEDMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABNETMESHSIZEMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABNETSURFACEAREAMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABNETTYPE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABPASSCOUNT" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABREACHLENGTHMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BIOHABREACHWIDTHMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("BOTTOMDEPTHHEIGHTMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("DEPTHHEIGHTMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("HORIZACCURACYMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("MONLOCID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("RELATIVEDEPTH" VARCHAR2(30 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPCOLLEQUIPMENT" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPCOLLMETHOD" VARCHAR2(250 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPCOLLMETHODDESC" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPCOLLMETHODID" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREP" VARCHAR2(250 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREPCONTCOLOR" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREPCONTTHERMALPRESERVUSED" VARCHAR2(250 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREPCONTTYPE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREPDESC" VARCHAR2(4000 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SAMPPREPID" VARCHAR2(35 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("SOURCEMAPSCALE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("TMPPROJECTID" VARCHAR2(55 CHAR));
ALTER TABLE "WQX_ACTIVITY" MODIFY ("TOPDEPTHHEIGHTMEASURE" VARCHAR2(60 CHAR));
ALTER TABLE "WQX_ACTIVITY" DROP CONSTRAINT "FK_ORG_ACTIVITY";
ALTER TABLE "WQX_ACTIVITY" ADD CONSTRAINT "FK_WQX_ACTIVIT_WQX_ORGANIZATIO" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ORGANIZATION"("RECORDID") ENABLE;

---------------------------
--Changed TABLE
--WQX_ACTATTACHEDBINARYOBJECT
---------------------------
ALTER TABLE "WQX_ACTATTACHEDBINARYOBJECT" DROP CONSTRAINT "FK_ACTIVITY_ACTATTBINOBJ";
ALTER TABLE "WQX_ACTATTACHEDBINARYOBJECT" ADD CONSTRAINT "FK_WQX_ACTATTACHEDBI_WQX_ACTIV" FOREIGN KEY ("PARENTID") REFERENCES "WQX_ACTIVITY"("RECORDID") ENABLE;

---------------------------
--New INDEX
--IX_WQX_SBMSS_WQXPD
---------------------------
  CREATE INDEX "IX_WQX_SBMSS_WQXPD" ON "WQX_SUBMISSIONHISTORY" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_RESULTMEASUREQUAL_PAREN
---------------------------
  CREATE INDEX "IX_WQX_RESULTMEASUREQUAL_PAREN" ON "WQX_RESULTMEASUREQUALIFIER" ("PARENTID");
---------------------------
--New INDEX
--IX_WQX_PROJECT_WQXUPDATEDATE
---------------------------
  CREATE INDEX "IX_WQX_PROJECT_WQXUPDATEDATE" ON "WQX_PROJECT" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_PROJECT_PROJECTID
---------------------------
  CREATE INDEX "IX_WQX_PROJECT_PROJECTID" ON "WQX_PROJECT" ("PROJECTID");
---------------------------
--New INDEX
--IX_WQX_ORGANIZATION_ORGID
---------------------------
  CREATE INDEX "IX_WQX_ORGANIZATION_ORGID" ON "WQX_ORGANIZATION" ("ORGID");
---------------------------
--New INDEX
--IX_WQX_MONITORINGLOCA_WQXUPDAT
---------------------------
  CREATE INDEX "IX_WQX_MONITORINGLOCA_WQXUPDAT" ON "WQX_MONITORINGLOCATION" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_MONITORING_MONITORINGLO
---------------------------
  CREATE INDEX "IX_WQX_MONITORING_MONITORINGLO" ON "WQX_MONITORINGLOCATION" ("MONITORINGLOCATIONID");
---------------------------
--New INDEX
--IX_WQX_DELETES_WQXUPDATEDATE
---------------------------
  CREATE INDEX "IX_WQX_DELETES_WQXUPDATEDATE" ON "WQX_DELETES" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_DELETES_PARENTID
---------------------------
  CREATE INDEX "IX_WQX_DELETES_PARENTID" ON "WQX_DELETES" ("PARENTID");
---------------------------
--New INDEX
--IX_WQX_BIOLOGICALHABITAT_MONLO
---------------------------
  CREATE INDEX "IX_WQX_BIOLOGICALHABITAT_MONLO" ON "WQX_BIOLOGICALHABITATINDEX" ("MONLOCID");
---------------------------
--New INDEX
--IX_WQX_BIOLOGICALHABITA_WQXUPD
---------------------------
  CREATE INDEX "IX_WQX_BIOLOGICALHABITA_WQXUPD" ON "WQX_BIOLOGICALHABITATINDEX" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_ACTIVITYGRO_WQXUPDATEDA
---------------------------
  CREATE INDEX "IX_WQX_ACTIVITYGRO_WQXUPDATEDA" ON "WQX_ACTIVITYGROUP" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_ACTIVITY_WQXUPDATEDATE
---------------------------
  CREATE INDEX "IX_WQX_ACTIVITY_WQXUPDATEDATE" ON "WQX_ACTIVITY" ("WQXUPDATEDATE");
---------------------------
--New INDEX
--IX_WQX_ACTIVITY_MONLOCID
---------------------------
  CREATE INDEX "IX_WQX_ACTIVITY_MONLOCID" ON "WQX_ACTIVITY" ("MONLOCID");
---------------------------
--New INDEX
--IX_WQX_ACTIVITY_ACTIVITYID
---------------------------
  CREATE INDEX "IX_WQX_ACTIVITY_ACTIVITYID" ON "WQX_ACTIVITY" ("ACTIVITYID");
---------------------------
--New INDEX
--IX_WQX_ACTIVIT_ACTIVITYSTARTDA
---------------------------
  CREATE INDEX "IX_WQX_ACTIVIT_ACTIVITYSTARTDA" ON "WQX_ACTIVITY" ("ACTIVITYSTARTDATE");