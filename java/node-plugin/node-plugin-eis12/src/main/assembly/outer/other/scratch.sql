select * from CERS_CERS

update CERS_CERS set data_category ='OnAndNonRoad' where cers_id = '5'

select * from cers_fac_site where cers_id = 'ec52e262-d0b1-11de-8254-0013203bbd98'

SELECT * FROM cers_affl_org

select * from cers_event

select ATCH_FILE_NAME from CERS_EVENT where CERS_ID in (select CERS_ID from CERS_CERS where DATA_CATEGORY = 'Event' and EMIS_YEAR = '2008')

select ATCH_FILE_NAME from CERS_LOC where CERS_ID in (select CERS_ID from CERS_CERS where DATA_CATEGORY = 'OnAndNonRoad' and EMIS_YEAR = '2008')

update CERS_EVENT set ATCH_FILE_NAME = 'EventAttachment.txt' where CERS_ID = 'f3b512e6-ca4e-11de-8254-0013203bbd98'

update CERS_LOC set ATCH_FILE_NAME = 'OnAndNonRoadAttachment.txt' where CERS_ID = '5'