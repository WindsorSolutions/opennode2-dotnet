SELECT * FROM CAFO_ADD WHERE FK in 
	(SELECT * FROM CAFO_FAC WHERE STATEFACILITYID IN 
	    (SELECT ST_FAC_IND FROM CHANGED_FACILITIES 
            WHERE FLOW_TYPE = 'HERE-CAFO' 
            AND IS_DELETED = 0 AND UPDATE_DATE >= '2002-01-01 00:00:00' ))
            
SELECT * FROM CAFO_GEO

SELECT * FROM CAFO_PERMIT
--OLD/DB2
SELECT DISTINCT R.REPORTIDENTIFIER, R.REPORTDUEDATE, R.REPORTRECEIVEDDATE, R.REPORTRECIPIENTNAME, R.REPORTINGPERIODSTARTDATE, R.REPORTINGPERIODENDDATE,
    R.REVISIONINDICATOR, R.REPLACEDREPORTIDENTIFIER, R.REPORTCREATEBYNAME, R.REPORTCREATEDATE, R.REPORTCREATETIME, R.REPORTTYPE, F.PK_GUID, F.FK_GUID, 
    F.FACILITYSITEIDENTIFIER, F.FACILITYSITENAME, F.FACILITYSTATUS, F.LOCATIONADDRESSTEXT, F.SUPPLEMENTALLOCATIONTEXT, F.LOCALITYNAME, F.STATECODE, 
    F.STATECODELISTIDENTIFIER, F.STATENAME, F.ADDRESSPOSTALCODE, F.COUNTRYCODE, F.COUNTRYCODELISTIDENTIFIER, F.COUNTRYNAME, F.COUNTYCODE, 
    F.COUNTYCODELISTIDENTIFIER, F.COUNTYNAME, F.TRIBALCODE, F.TRIBALCODELISTIDENTIFIER, F.TRIBALNAME, F.TRIBALLANDNAME, F.TRIBALLANDINDICATOR, 
    F.LOCATIONDESCRIPTIONTEXT, F.MAILINGFACILITYSITENAME, F.MAILINGADDRESSTEXT, F.MAILINGSUPPLEMENTALADDRESSTEXT, 
    F.MAILINGADDRESSCITYNAME, F.MAILINGSTATECODE, F.MAILINGSTATECODELISTIDENTIFIER, F.MAILINGSTATENAME, F.MAILINGADDRESSPOSTALCODE, F.MAILINGCOUNTRYCODE, 
    F.MAILINGCOUNTRYCODELISTIDENTIF1, F.MAILINGCOUNTRYNAME, F.PARENTCOMPANYNAMENAINDICATOR, F.PARENTCOMPANYNAMETEXT, F.PARENTDUNBRADSTREETCODE 
    FROM  T2_REPORT R 
    INNER JOIN T2_FAC_SITE F ON R.PK_GUID = F.FK_GUID INNER JOIN CHANGED_FACILITIES C ON F.FACILITYSITEIDENTIFIER = C.ST_FAC_IND 
    WHERE C.FLOW_TYPE = 'HERE-TIER2' AND C.IS_DELETED = 0 AND C.UPDATE_DATE >= '2002-01-01 00:00:00'
    
    
SELECT DISTINCT R.REPORTIDENTIFIER, R.REPORTDUEDATE, R.REPORTRECEIVEDDATE, R.REPORTRECIPIENTNAME, R.REPORTINGPERIODSTARTDATE, R.REPORTINGPERIODENDDATE, R.REVISIONINDICATOR, R.REPLACEDREPORTIDENTIFIER, R.REPORTCREATEBYNAME, R.REPORTCREATEDATE, R.REPORTCREATETIME, R.REPORTTYPE, F.PK_GUID, F.FK_GUID, F.FACILITYSITEIDENTIFIER, F.FACILITYSITENAME, F.FACILITYSTATUS, F.LOCATIONADDRESSTEXT, F.SUPPLEMENTALLOCATIONTEXT, F.LOCALITYNAME, F.STATECODE, F.STATECODELISTIDENTIFIER, F.STATENAME, F.ADDRESSPOSTALCODE, F.COUNTRYCODE, F.COUNTRYCODELISTIDENTIFIER, F.COUNTRYNAME, F.COUNTYCODE, F.COUNTYCODELISTIDENTIFIER, F.COUNTYNAME, F.TRIBALCODE, F.TRIBALCODELISTIDENTIFIER, F.TRIBALNAME, F.TRIBALLANDNAME, F.TRIBALLANDINDICATOR, F.LOCATIONDESCRIPTIONTEXT, F.MAILINGFACILITYSITENAME, F.MAILINGADDRESSTEXT, F.MAILINGSUPPLEMENTALADDRESSTEXT, F.MAILINGADDRESSCITYNAME, F.MAILINGSTATECODE, F.MAILINGSTATECODELISTIDENTIFIER, F.MAILINGSTATENAME, F.MAILINGADDRESSPOSTALCODE, F.MAILINGCOUNTRYCODE, F.MAILINGCOUNTRYCODELISTIDENTIF1, F.MAILINGCOUNTRYNAME, F.PARENTCOMPANYNAMENAINDICATOR, F.PARENTCOMPANYNAMETEXT, F.PARENTDUNBRADSTREETCODE FROM  T2_REPORT R INNER JOIN T2_FAC_SITE F ON R.PK_GUID = F.FK_GUID INNER JOIN CHANGED_FACILITIES C ON F.FACILITYSITEIDENTIFIER = C.ST_FAC_IND WHERE C.FLOW_TYPE = 'HERE-TIER2' AND C.IS_DELETED = 0 AND C.UPDATE_DATE >= '2002-01-01 00:00:00'
select distinct r.reportidentifier, r.reportduedate, r.reportreceiveddate, r.reportrecipientname, r.reportingperiodstartdate, r.reportingperiodenddate, r.revisionindicator, r.replacedreportidentifier, r.reportcreatebyname, r.reportcreatedate, r.reportcreatetime, r.reporttype, f.pk_guid, f.fk_guid, f.facilitysiteidentifier, f.facilitysitename, f.facilitystatus, f.locationaddresstext, f.supplementallocationtext, f.localityname, f.statecode, f.statecodelistidentifier, f.statename, f.addresspostalcode, f.countrycode, f.countrycodelistidentifier, f.countryname, f.countycode, f.countycodelistidentifier, f.countyname, f.tribalcode, f.tribalcodelistidentifier, f.tribalname, f.triballandname, f.triballandindicator, f.locationdescriptiontext, f.mailingfacilitysitename, f.mailingaddresstext, f.mailingsupplementaladdresstext, f.mailingaddresscityname, f.mailingstatecode, f.mailingstatecodelistidentifier, f.mailingstatename, f.mailingaddresspostalcode, f.mailingcountrycode, f.mailingcountrycodelistidentif1, f.mailingcountryname, f.parentcompanynamenaindicator, f.parentcompanynametext, f.parentdunbradstreetcode from  t2_report r inner join t2_fac_site f on r.pk_guid = f.fk_guid inner join changed_facilities c on f.facilitysiteidentifier = c.st_fac_ind where c.flow_type = 'here-tier2' and c.is_deleted = 0 and c.update_date >= '2002-01-01 00:00:00'
    
select * from t2_report

SELECT count(*) FROM T2_FAC_RCRA_ID

SELECT * FROM T2_FAC_NPDES_ID
SELECT * FROM T2_FAC_UIC_ID
SELECT * FROM T2_FAC_IND
SELECT * FROM T2_FAC_IND_PHONE
SELECT * FROM T2_FAC_IND_TYPE
SELECT * FROM T2_FAC_IND_EMAIL
SELECT * FROM T2_CHEM_INV
SELECT * FROM T2_CHEM_INV_PHYS
SELECT * FROM T2_CHEM_INV_HLTH
SELECT * FROM T2_CHEM_INV_HAZ
SELECT * FROM T2_CHEM_INV_DTLS
SELECT * FROM T2_CHEM_LOC

SELECT pk_guid, domainlistname, originatingpartnername FROM HERE_DOMAINLIST WHERE changedate >= '1990-01-01 00:00:00.001'

-- NEW/ORACLE
SELECT DISTINCT R.REPORTIDENTIFIER, R.REPORTDUEDATE, R.REPORTRECEIVEDDATE, R.REPORTRECIPIENTNAME, R.REPORTINGPERIODSTARTDATE, R.REPORTINGPERIODENDDATE,
    R.REVISIONINDICATOR, R.REPLACEDREPORTIDENTIFIER, R.REPORTCREATEBYNAME, R.REPORTCREATEDATE, R.REPORTCREATETIME, R.REPORTTYPE, F.PK_GUID, F.FK_GUID, 
    F.FACILITYSITEIDENTIFIER, F.FACILITYSITENAME, F.FACILITYSTATUS, F.LOCATIONADDRESSTEXT, F.SUPPLEMENTALLOCATIONTEXT, F.LOCALITYNAME, F.STATECODE, 
    F.STATECODELISTIDENTIFIER, F.STATENAME, F.ADDRESSPOSTALCODE, F.COUNTRYCODE, F.COUNTRYCODELISTIDENTIFIER, F.COUNTRYNAME, F.COUNTYCODE, 
    F.COUNTYCODELISTIDENTIFIER, F.COUNTYNAME, F.TRIBALCODE, F.TRIBALCODELISTIDENTIFIER, F.TRIBALNAME, F.TRIBALLANDNAME, F.TRIBALLANDINDICATOR, 
    F.LOCATIONDESCRIPTIONTEXT, F.MAILFACILITYSITENAME, F.MAILADDRESSTEXT, F.MAILSUPPLEMENTALADDRESSTEXT, 
    F.MAILADDRESSCITYNAME, F.MAILSTATECODE, F.MAILSTATECODELISTIDENTIFIER, F.MAILSTATENAME, F.MAILADDRESSPOSTALCODE, F.MAILCOUNTRYCODE, 
    F.MAILCOUNTRYCODELISTIDENTIFIER, F.MAILCOUNTRYNAME, F.PARENTCOMPANYNAMENAINDICATOR, F.PARENTCOMPANYNAMETEXT, F.PARENTDUNBRADSTREETCODE 
    FROM  T2_REPORT R 
    INNER JOIN T2_FAC_SITE F ON R.PK_GUID = F.FK_GUID INNER JOIN CHANGED_FACILITIES C ON F.FACILITYSITEIDENTIFIER = C.ST_FAC_IND 
    WHERE C.FLOW_TYPE = 'HERE-TIER2' AND C.IS_DELETED = 0 AND C.UPDATE_DATE >= to_date('2008-01-01 00:00:00')
    
    
--------------------------------------------

SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-FRS' AND IS_DELETED = 1 AND UPDATE_DATE >= '2008-01-01 00:00:00'

select *  FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-FRS' AND IS_DELETED = 1 AND UPDATE_DATE >= '2000-01-01'

SELECT * FROM CHANGED_FACILITIES 

SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-FACID' AND IS_DELETED = 1 AND UPDATE_DATE >= '2000-01-01 00:00:00'

SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE IS_DELETED = 1


SELECT * FROM HERE_MANIFEST