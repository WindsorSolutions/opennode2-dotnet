
BEGIN

DELETE FROM BEACH_ACTIVITY;
DELETE FROM BEACH;

--Insert 2 Beaches
INSERT INTO BEACH
           (EPA_BEACH_ID,BEACH_NAME,BEACH_DESCRIPTION,STATE_CD,FIPS_CD,WATERBODY_NAME_CD,ACCESSIBILITY_TYPE_CD)
     VALUES('MI000286', 'Thompson Park', 'Thunder Bay' ,'MI' ,'32001', 'LAKE_HURON', 'PUB_PUB_ACC');

INSERT INTO BEACH
           (EPA_BEACH_ID,BEACH_NAME,BEACH_DESCRIPTION,STATE_CD,FIPS_CD,WATERBODY_NAME_CD,ACCESSIBILITY_TYPE_CD)
     VALUES('MI000309','Traverse City Park Beach','Traverse City','MI', '32002', 'LAKE_MCHGN', 'PUB_PUB_ACC');

--Insert 2 Closures for Thompson Park
INSERT INTO BEACH_ACTIVITY
           (ACTIVITY_ID,EPA_BEACH_ID,ACTIVITY_TYPE,ACTIVITY_NAME,START_DATE,REOPEN_DATE,REASON_TYPE_CD,POLLUTION_SOURCE_CD,INDICATOR_TYPE_CD)
     VALUES
           ('1111', 'MI000286','CLOSURE','Beach Closure',TO_DATE('2009/06/01','yyyy/mm/dd'),TO_DATE('2009/06/03','yyyy/mm/dd'),'ELEV_BACT','RUNOFF','ECOLI');

INSERT INTO BEACH_ACTIVITY
           (ACTIVITY_ID,EPA_BEACH_ID,ACTIVITY_TYPE,ACTIVITY_NAME,START_DATE,REOPEN_DATE,REASON_TYPE_CD,POLLUTION_SOURCE_CD,INDICATOR_TYPE_CD)
     VALUES
           ('2222', 'MI000286','CLOSURE','Beach Closure',TO_DATE('2009/06/06','yyyy/mm/dd'),TO_DATE('2009/06/07','yyyy/mm/dd'),'ELEV_BACT','RUNOFF','ECOLI');
           
END;