delete from DW_NODE_UTILITY;

select * from DW_SERVICE_AREA;

select * from DW_TREATMENT_UNIT;

select * from DW_NODE_UTILITY;

select * from DW_NODE_UTILITY  where DW_NODE_UTILITY.DW_NODE_UTILITY_ID = 110;

update DW_NODE_UTILITY set DW_NODE_UTILITY.KEY_VALUE = 'VALID';

update DW_NODE_UTILITY set DW_NODE_UTILITY.KEY_VALUE = 'VALID' where DW_NODE_UTILITY.DW_NODE_UTILITY_ID = 110;

update DW_NODE_UTILITY set DW_NODE_UTILITY.KEY_VALUE = 'RESET' where DW_NODE_UTILITY.RECORD_TYPE = 'WQ' AND DW_NODE_UTILITY.COMMENTS = 'Windsor Node NY_DWQExchange.xml';
-------------------------------------------------
select d.DW_ANALYTE_GROUP_ID, 
    d.DW_GROUP_ID, 
    d.DW_ANALYTE_ID
from DW_ANALYTE_GROUP d 
where d.DW_GROUP_ID IS NOT NULL;

select * from DW_GROUP
WHERE ANALYTE_GROUP_CODE IS NOT NULL AND ANALYTE_GROUP_VALUE IS NOT NULL;

select * from DW_MCL_VALUE;
select * from DW_ANALYTE;

select count(*) from DW_MCL_VALUE;
select count(*) from DW_ANALYTE;

select a.DW_ANALYTE_ID, 
    a.ANALYTE_CODE, 
    a.ANALYTE_NAME, 
    a.ANALYTE_TYPE_CODE, 
    a.UPDATE_DATE,
    m.DW_ANALYTE_ID,
    m.DW_MCL_VALUE_ID,
    m.MEASURE,
    m.MEASURE_TEXT,
    m.MEASURE_UNIT_CODE,
    m.START_DATE,
    m.END_DATE,
    m.COMPLIANCE_METHOD_CODE,
    m.UPDATE_DATE
from DW_ANALYTE a
left outer join DW_MCL_VALUE m on (a.DW_ANALYTE_ID = m.DW_ANALYTE_ID)
order by a.ANALYTE_CODE;


select count(*) from DW_ANALYTE a left outer join DW_MCL_VALUE m on (a.DW_ANALYTE_ID = m.DW_ANALYTE_ID);

SELECT DW_ANALYTE_ID, ANALYTE_CODE, ANALYTE_NAME, ANALYTE_TYPE_CODE, UPDATE_DATE FROM  DW_ANALYTE ORDER BY DW_ANALYTE_ID;

SELECT DW_ANALYTE_ID, 
    DW_MCL_VALUE_ID, 
	MEASURE, 
	MEASURE_TEXT, 
	MEASURE_UNIT_CODE, 
	START_DATE, 
	END_DATE, 
	COMPLIANCE_METHOD_CODE, 
	UPDATE_DATE 
FROM  DW_MCL_VALUE 
WHERE DW_ANALYTE_ID = 1;


select * from DW_ANNUAL_OPERATING_PERIOD;

select * from DW_ANNUAL_OPERATING_PERIOD where DW_WATER_SYSTEM_ID = '169';

select DW_WATER_SYSTEM_ID FROM DW_WATER_SYSTEM;


select * FROM DW_WATER_SYSTEM where DW_WATER_SYSTEM.DW_WATER_SYSTEM_ID = '16867'

select max(DW_WATER_SYSTEM.TOTAL_DESIGN_CAPACITY) from DW_WATER_SYSTEM

select * from DW_WATER_SYSTEM where DW_WATER_SYSTEM.TOTAL_DESIGN_CAPACITY > (35000000000/100)

SELECT r.DW_SAMPLE_RESULT_ID, r.DW_SAMPLE_ID, r.DW_VIOLATION_ID, r.DW_ANALYTE_ID, r.CONCENTRATION, r.CONCENTRATION_UOM, 
    r.DATA_QUALITY_CODE, r.DETECTION_LIMIT, r.DETECTION_LIMIT_UOM, r.LESS_THAN_CODE, r.LESS_THAN_IND, 
    r.STANDARD_METHOD_CODE, r.STANDARD_METHOD_NAME, r.CREATE_DATE, r.UPDATE_DATE, a.ANALYTE_CODE as ANALYTE_CODE
FROM DW_SAMPLE_RESULT r, DW_ANALYTE a 
WHERE r.DW_SAMPLE_ID = '31925' AND a.DW_ANALYTE_ID = r.DW_ANALYTE_ID ORDER BY r.DW_SAMPLE_RESULT_ID;

select max(UPDATE_DATE) as FIRST, min(UPDATE_DATE) as LAST from DW_SAMPLE;

select count(*) from DW_SAMPLE where UPDATE_DATE > to_date('2008-01-01', 'YYYY-MM-DD');

select count(*) from DW_PURCHASE; where SELL_DW_WATER_SYSTEM_ID = '6200';
 
select p.DW_PURCHASE_ID, 
    p.BUY_DW_WATER_SYSTEM_ID, 
    p.SELL_DW_WATER_SYSTEM_ID, 
    p.CREATE_DATE, 
    p.UPDATE_DATE, 
    b.PWS_IDENTIFIER as BUY_PWS,
    s.PWS_IDENTIFIER as SELL_PWS
from DW_PURCHASE p, DW_WATER_SYSTEM b, DW_WATER_SYSTEM s 
where b.DW_WATER_SYSTEM_ID = p.BUY_DW_WATER_SYSTEM_ID 
    and s.DW_WATER_SYSTEM_ID = p.SELL_DW_WATER_SYSTEM_ID 
    and p.BUY_DW_WATER_SYSTEM_ID = '10084'; 

select * from DW_NODE_UTILITY;

SELECT v.DW_VIOLATION_ID, 
        v.DW_WATER_SYSTEM_ID, v.DW_ANALYTE_ID, v.VIOLATION_SEQ, v.VIOLATION_TYPE_CODE, 
        v.VIOLATION_TYPE_NAME, v.SEVERITY_LEVEL_CODE, v.STATUS_TYPE_CODE, v.ANALYSIS_RESULT_MEASURE, 
        v.ANALYSIS_RESULT_UOM, v.MCL_VIOLATED_TEXT, v.MCL_VIOLATED_UOM, 
        v.DETERMINATION_DATE, v.FEDERAL_PERIOD_BEGIN_DATE, v.FEDERAL_PERIOD_END_DATE, 
        v.STATE_PERIOD_BEGIN_DATE, v.STATE_PERIOD_END_DATE, v.TIER_LEVEL, 
        v.FISCAL_YEAR, v.CREATE_DATE, v.UPDATE_DATE, a.ANALYTE_CODE 
FROM DW_VIOLATION v, DW_ANALYTE a 
WHERE v.DW_WATER_SYSTEM_ID = '100' 
    AND v.UPDATE_DATE >  to_date('2001-03-10', 'YYYY-MM-DD')  
    AND a.DW_ANALYTE_ID = v.DW_ANALYTE_ID 
ORDER BY v.DW_VIOLATION_ID;

INSERT INTO DW_NODE_UTILITY (RECORD_TYPE, SUCCESS_IND, CREATE_DATE, COMMENTS) VALUES ('WQ', 1, to_date('2008-10-01', 'YYYY-MM-DD'), 'Windsor Node NY_DWQExchange.xml');

SELECT MAX(CREATE_DATE) FROM DW_NODE_UTILITY WHERE RECORD_TYPE = 'WQ' AND SUCCESS_IND = 0 AND COMMENTS = 'Windsor Node NY_DWQExchange.xml';

INSERT INTO DW_NODE_UTILITY (RECORD_TYPE, SUCCESS_IND, CREATE_DATE, COMMENTS) VALUES ('WQ', 0, sysdate, 'Windsor Node NY_DWQExchange.xml');

select * from DW_WATER_SYSTEM where rowNum <= 10 order by DW_WATER_SYSTEM_ID;

select * from DW_NODE_UTILITY;

select distinct DW_SAMPLING_POINT_ID from DW_SAMPLE where UPDATE_DATE > to_date('2008-01-01', 'YYYY-MM-DD');


select count(*) from DW_SAMPLE where DW_SAMPLING_POINT_ID = '290' and UPDATE_DATE > to_date('2008-01-01', 'YYYY-MM-DD');


-- get all sample ids for a given sampling point whose results have been updated since 2008-09-01
select distinct r.DW_SAMPLE_ID from DW_SAMPLE_RESULT r where r.DW_SAMPLE_ID in 
    (select s.DW_SAMPLE_ID from DW_SAMPLE s where s.DW_SAMPLING_POINT_ID = '290')
    and r.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') order by r.DW_SAMPLE_ID;

-- get all sample ids for a given sampling point whose samples have been updated since 2008-09-01
select s.DW_SAMPLE_ID from DW_SAMPLE s 
    where s.DW_SAMPLING_POINT_ID = '290'  
    and s.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') 
    order by s.DW_SAMPLE_ID;

-- do it all at once, given a sampling point id    
select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE 
    where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290'  
    and (DW_SAMPLE.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') or DW_SAMPLE.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'))
    union
    select DW_SAMPLE_RESULT.DW_SAMPLE_ID from DW_SAMPLE_RESULT where DW_SAMPLE_RESULT.DW_SAMPLE_ID in 
    (select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290')
    and (DW_SAMPLE_RESULT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')or DW_SAMPLE_RESULT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'));
    
select DW_SAMPLE.DW_SAMPLE_ID, DW_SAMPLE.DW_SAMPLING_POINT_ID, DW_SAMPLE.DW_LABORATORY_ID, 
    DW_SAMPLE.TSALAB_IS_NUMBER, DW_SAMPLE.SAMPLE_TYPE_CODE, DW_SAMPLE.SAMPLE_PURPOSE_CODE,
    DW_SAMPLE.COLLECTION_END_DATE, DW_SAMPLE.TSASAMPL_IS_NUMBER, DW_SAMPLE.CREATE_DATE, DW_SAMPLE.UPDATE_DATE 
    from DW_SAMPLE 
    where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290'  
    and (DW_SAMPLE.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') or DW_SAMPLE.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'))
    union
    select DW_SAMPLE_RESULT.DW_SAMPLE_ID, null, null, null, null, null, null, null, null, null
    from DW_SAMPLE_RESULT where DW_SAMPLE_RESULT.DW_SAMPLE_ID in 
    (select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290')
    and (DW_SAMPLE_RESULT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')or DW_SAMPLE_RESULT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'));
    
select DW_SAMPLE.DW_SAMPLE_ID 
    from DW_SAMPLE 
    where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290'  
    and (DW_SAMPLE.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') or DW_SAMPLE.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'))
    union
    select DW_SAMPLE_RESULT.DW_SAMPLE_ID
    from DW_SAMPLE_RESULT where DW_SAMPLE_RESULT.DW_SAMPLE_ID in 
    (select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE where DW_SAMPLE.DW_SAMPLING_POINT_ID = '290')
    and (DW_SAMPLE_RESULT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')or DW_SAMPLE_RESULT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'));
    


----------------

select DW_SITE_VISIT.DW_SITE_VISIT_ID 
    from DW_SITE_VISIT 
    where DW_SITE_VISIT.DW_WATER_SYSTEM_ID = '1427'  
    and (DW_SITE_VISIT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') or DW_SITE_VISIT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'))
    union
    select DW_DEFICIENCY.DW_SITE_VISIT_ID
    from DW_DEFICIENCY where DW_DEFICIENCY.DW_SITE_VISIT_ID in 
    (select DW_SITE_VISIT.DW_SITE_VISIT_ID from DW_SITE_VISIT where DW_SITE_VISIT.DW_WATER_SYSTEM_ID = '1427')
    and (DW_DEFICIENCY.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')or DW_DEFICIENCY.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'));
    
    
SELECT * FROM DW_SITE_VISIT WHERE (DW_SITE_VISIT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') or DW_SITE_VISIT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD'))
----------------
    
SELECT DISTINCT DW_SAMPLE.DW_SAMPLE_ID, DW_SAMPLE.DW_SAMPLING_POINT_ID, DW_SAMPLE.DW_LABORATORY_ID, 
    DW_SAMPLE.TSALAB_IS_NUMBER, DW_SAMPLE.SAMPLE_TYPE_CODE, DW_SAMPLE.SAMPLE_PURPOSE_CODE,
    DW_SAMPLE.COLLECTION_END_DATE, DW_SAMPLE.TSASAMPL_IS_NUMBER, DW_SAMPLE.CREATE_DATE, DW_SAMPLE.UPDATE_DATE

    FROM DW_SAMPLE LEFT OUTER JOIN DW_SAMPLE_RESULT ON (DW_SAMPLE_RESULT.DW_SAMPLE_ID = DW_SAMPLE.DW_SAMPLE_ID)

    WHERE DW_SAMPLE.dw_sampling_point_id = '19229'
   
    AND (
        (DW_SAMPLE.UPDATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        OR DW_SAMPLE.CREATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD'))
        
        OR
        
        (DW_SAMPLE_RESULT.UPDATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        OR DW_SAMPLE_RESULT.CREATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD'))

        )
     ORDER BY DW_SAMPLE.DW_SAMPLE_ID;
        
------------------------------  

select count(*) from DW_SAMPLE_RESULT where DW_SAMPLE_ID = '89337' and UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD');

select count(*) from DW_SAMPLE_RESULT where UPDATE_DATE > to_date('2008-10-01', 'YYYY-MM-DD');

select * from DW_SAMPLING_POINT  where UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD');

select count(*) from DW_SAMPLING_POINT where UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') order by DW_SAMPLING_POINT_ID;

select DW_SAMPLING_POINT_ID from DW_SAMPLING_POINT where UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD');

select count(*) from DW_SITE_VISIT;

select count(*) from DW_WATER_SYSTEM

select count(*) from DW_WATER_SYSTEM where UPDATE_DATE > TO_DATE('2008-09-01', 'YYYY-MM-DD')

----------------
    
SELECT DISTINCT DW_SITE_VISIT.DW_SITE_VISIT_ID, DW_SITE_VISIT.DW_WATER_SYSTEM_ID, DW_SITE_VISIT.COMMENT_TEXT, 
    DW_SITE_VISIT.FREQUENCY_NUMBER, DW_SITE_VISIT.FREQUENCY_PERIOD, DW_SITE_VISIT.NEXT_DUE_DATE, 
    DW_SITE_VISIT.REASON_CODE, DW_SITE_VISIT.STATUS,DW_SITE_VISIT.SITE_VISIT_DATE, DW_SITE_VISIT.NOTIFIED_DATE,
    DW_SITE_VISIT.DISTRIBTION_SYSTEM_IND, DW_SITE_VISIT.FINISHED_STORAGE_IND, DW_SITE_VISIT.OPERATOR_EVAL_IND,
    DW_SITE_VISIT.MR_DV_IND, DW_SITE_VISIT.PUMP_IND, DW_SITE_VISIT.SOURCE_IND, DW_SITE_VISIT.TREATMENT_IND,
    DW_SITE_VISIT.WATER_SYSTEM_MGMT_IND, DW_SITE_VISIT.OTHER_IND, TINVISIT_IS_NUMBER, DW_SITE_VISIT.CREATE_DATE,
    DW_SITE_VISIT.UPDATE_DATE

FROM DW_SITE_VISIT LEFT OUTER JOIN DW_DEFICIENCY ON (DW_DEFICIENCY.DW_SITE_VISIT_ID = DW_SITE_VISIT.DW_SITE_VISIT_ID)

WHERE DW_SITE_VISIT.DW_WATER_SYSTEM_ID = '2180'

AND (
        (
        DW_SITE_VISIT.UPDATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        OR DW_SITE_VISIT.CREATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        )
        OR
        (
        DW_DEFICIENCY.UPDATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        OR DW_DEFICIENCY.CREATE_DATE >  TO_DATE('2008-09-01', 'YYYY-MM-DD')
        )
    );


---------------------------------------------

SELECT * FROM DW_SITE_VISIT 
WHERE DW_WATER_SYSTEM_ID = '2180' 
AND UPDATE_DATE > TO_DATE('2008-09-01', 'YYYY-MM-DD')
OR CREATE_DATE > TO_DATE('2008-09-01', 'YYYY-MM-DD')

SELECT * FROM DW_SITE_VISIT WHERE DW_WATER_SYSTEM_ID = '2180'

SELECT * FROM DW_DEFICIENCY WHERE DW_SITE_VISIT_ID = '4118'


--------------- for auditing the output file, compare these counts to the results of
--------------- grep \<element_name\> file_name | wc -l

select count(*) from DW_WATER_SYSTEM;

select count(*) from DW_FACILITY;

select count(*) from DW_SAMPLING_POINT;

select count(*) from DW_SAMPLE where DW_SAMPLE.DW_SAMPLE_ID in 
( 
    select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE 
        where 
        (
            DW_SAMPLE.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
                or DW_SAMPLE.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') 
        )
        
    union
    
    select DW_SAMPLE_RESULT.DW_SAMPLE_ID from DW_SAMPLE_RESULT 
        where 
        (
            DW_SAMPLE_RESULT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
	           or DW_SAMPLE_RESULT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
	     )
);

select count(*) from DW_SAMPLE_RESULT where DW_SAMPLE_RESULT.DW_SAMPLE_ID in
(
    select DW_SAMPLE.DW_SAMPLE_ID from DW_SAMPLE 
        where 
        (
            DW_SAMPLE.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
                or DW_SAMPLE.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') 
        )
        
    union
    
    select DW_SAMPLE_RESULT.DW_SAMPLE_ID from DW_SAMPLE_RESULT 
        where 
        (
            DW_SAMPLE_RESULT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
               or DW_SAMPLE_RESULT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
         )
);
    

select count(*) from DW_SITE_VISIT where DW_SITE_VISIT.DW_SITE_VISIT_ID in 
( 
    select DW_SITE_VISIT.DW_SITE_VISIT_ID from DW_SITE_VISIT 
        where 
        (
            DW_SITE_VISIT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
                or DW_SITE_VISIT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') 
        )
        
    union
    
    select DW_DEFICIENCY.DW_SITE_VISIT_ID from DW_DEFICIENCY 
        where 
        (
            DW_DEFICIENCY.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
               or DW_DEFICIENCY.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
         )
);

select count(*) from DW_DEFICIENCY where DW_DEFICIENCY.DW_SITE_VISIT_ID in
(
    select DW_SITE_VISIT.DW_SITE_VISIT_ID from DW_SITE_VISIT 
        where 
        (
            DW_SITE_VISIT.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
                or DW_SITE_VISIT.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD') 
        )
        
    union
    
    select DW_DEFICIENCY.DW_SITE_VISIT_ID from DW_DEFICIENCY 
        where 
        (
            DW_DEFICIENCY.UPDATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
               or DW_DEFICIENCY.CREATE_DATE > to_date('2008-09-01', 'YYYY-MM-DD')
         )
);
    
---------------

select TINLGENT_IS_NUMBER from DW_WATER_SYSTEM_AFFIL;

select max(AVG_DAILY_PRODUCE_MEASURE) from DW_WATER_SYSTEM; 

select * from DW_WATER_SYSTEM_AFFIL where DW_WATER_SYSTEM_AFFIL.DW_WATER_SYSTEM_ID in (select DW_WATER_SYSTEM_ID from DW_WATER_SYSTEM where DW_WATER_SYSTEM.PWS_IDENTIFIER = 'NY0616496')

select * from DW_CASING where DW_FACILITY_ID in (select DW_FACILITY_ID from DW_FACILITY where FACILITY_IDENTIfIER = '000000081571')

select * from DW_FACILITY where FACILITY_IDENTIFIER = '000000081571'

select count(*) from DW_FACILITY where FACILITY_TYPE_CODE = 'WL'

select count(*) from DW_CASING

select count(*) from DW_SCREEN



delete from DW_CLOB_PROCESS

select length(CLOB_OBJECT) from DW_CLOB_PROCESS where CLOB_ID = '2DD78F98-30A3-4608-8721-B68FDEF67AB1'

select * from water_systems where TOTAL_DESIGN_CAPACITY=2000000000;

select * from (

select TOTAL_DESIGN_CAPACITY from water_systems

WHERE total_design_capacity IS NOT NULL

order by total_design_capacity desc

)

select DW_FACILITY.GEOMETRIC_TYPE_CODE from DW_FACILITY where DW_FACILITY.GEOMETRIC_TYPE_CODE is not null;
select DW_FACILITY.GEOMETRIC_TYPE_NAME from DW_FACILITY where DW_FACILITY.GEOMETRIC_TYPE_NAME is not null;

select * from  DW_SAMPLE_RESULT WHERE DW_SAMPLE_ID IN (263,127375,26033);
select * from  DW_SAMPLE WHERE DW_SAMPLE_ID IN (263,127375,26033);
select * from  DW_SAMPLING_POINT where DW_SAMPLING_POINT_ID in (28005, 14538, 21507)

select * from DW_NODE_UTILITY

update DW_NODE_UTILITY set KEY_VALUE = 'RESET'