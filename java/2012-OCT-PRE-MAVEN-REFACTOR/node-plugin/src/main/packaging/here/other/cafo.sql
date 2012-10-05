select * FROM HERE_MANIFEST where createddate >= '2008-03-05 00:00:00'

SELECT transactionid, endpointurl, dataexchangename, isfacilitysourceindicator, sourcesystemname, fullreplaceindicator, createddate FROM HERE_MANIFEST 

SELECT * FROM CAFO_FAC WHERE STATEFACILITYID IN (SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-CAFO' AND IS_DELETED = 0 AND UPDATE_DATE >= ? )

SELECT * FROM CAFO_FAC WHERE STATEFACILITYID IN (SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-CAFO' AND IS_DELETED = 0) 

select update_date from CHANGED_FACILITIES order by update_date desc

select count(*) from CHANGED_FACILITIES where UPDATE_DATE >= '2008-01-01 00:00:00'

SELECT pk, facilityregistryid, statefacilityid, facilitysitename, facilityaltname, facilityinfourl 
FROM CAFO_FAC 
WHERE STATEFACILITYID IN (SELECT ST_FAC_IND FROM CHANGED_FACILITIES WHERE FLOW_TYPE = 'HERE-CAFO' AND IS_DELETED = 0 AND UPDATE_DATE >= '2002-10-01 00:00:00.001')

select * from here_manifest