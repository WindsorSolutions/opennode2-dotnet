select count (*) from RCRA_HD_HBASIC

-- Oracle
select * from RCRA_HD_HBASIC WHERE row_number <= 10

-- DB2
select * from RCRA_HD_HBASIC FETCH FIRST 10 ROWS ONLY

SELECT handler_id FROM RCRA_HD_HBASIC WHERE handler_id <= 'MO0000011445'

SELECT count(handler_id) FROM RCRA_HD_HBASIC

SELECT handler_id FROM RCRA_HD_HBASIC WHERE handler_id <>  '' fetch first 10 rows only
