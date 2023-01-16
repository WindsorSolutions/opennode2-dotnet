-- set the SEQ_RCRA_EM_EMANIFEST next sequence number to be bigger than the current max value for

create or replace procedure handle_db_action(type_code varchar2,
                                             obj_name varchar2,
                                             obj_def varchar2,
                                             target_name varchar2,
                                             log_level int default 1) as

    query       varchar2(4000);
    error_code1 int;
    error_code2 int;
begin
    select case type_code
               when 'AC' then 'alter table ' || target_name || ' add ' || obj_name || ' ' || obj_def
               when 'CI' then 'create index ' || obj_name || ' on ' || target_name || ' (' || obj_def || ')'
               when 'CQ' then 'create sequence ' || obj_name
               when 'CS' then 'create synonym ' || obj_name || ' for ' || target_name
               when 'CT' then 'create table ' || obj_name || ' (' || obj_def || ')'
               when 'CV' then 'create or replace view ' || obj_name || ' as ' || obj_def
               when 'DC' then 'alter table ' || target_name || ' drop column ' || obj_name
               when 'DP' then 'drop procedure ' || obj_name
               when 'DQ' then 'drop sequence ' || obj_name
               when 'DS' then 'drop synonym ' || obj_name
               when 'DT' then 'drop table ' || obj_name
               when 'DV' then 'drop view ' || obj_name
               when 'MC' then 'alter table ' || target_name || ' modify ' || obj_name || ' ' || obj_def
               when 'RC' then 'alter table ' || target_name || ' rename column ' || obj_name || ' to ' || obj_def
               end
    into query
    from dual;

    select case type_code
               when 'AC' then -1430 -- -904
               when 'CI' then -955
               when 'CQ' then -955
               when 'CS' then -955
               when 'CV' then null
               when 'CT' then -955
               when 'DC' then -904
               when 'DP' then -4043
               when 'DQ' then -2289
               when 'DS' then -1434
               when 'DT' then -942
               when 'DV' then -942
               when 'MC' then -1451 -- -904
               when 'RC' then -957 -- -904
               end
    into error_code1
    from dual;

    select case type_code
               when 'AC' then -942
               when 'DC' then -942
               when 'MC' then -942
               when 'RC' then -942
               else error_code1
               end
    into error_code2
    from dual;

    dbms_output.put_line('query: ' || query);

    begin
        execute immediate query;
    exception
        when others then
            if error_code1 is null or (sqlcode != error_code1 and sqlcode != error_code2) then
                dbms_output.put_line('Unexpected error in "' || query || '": ' + sqlcode + ' - ' + sqlerrm);
                raise;
            else
                dbms_output.put_line('Skipped statement "' || query || '" ' ||
                                     'because the conditions to execute it are not met');
            end if;
    end;
end;

declare
    source_db   varchar2(100) := 'RCRA_REPORTING';
    target_db   varchar2(100) := 'NODE_FLOW_RCRA';
    type_code   varchar2(2);
    obj_name    varchar2(100);
    obj_def     varchar2(4000);
    target_name varchar2(100);
    exists_ind  number(1, 0);
    query       varchar2(32000);
    max_val     int;
    next_val    int;
    cursor x is
        with t( --
               sort_order, type_code, obj_name, obj_def, target_name) as ( --
            select 1,
                   'CT',
                   'RCRA_EM_FED_WASTE_CODE_DESC',
                   'EM_FED_WASTE_CODE_DESC_ID int 
                        constraint PK_EM_FED_WASTE_CODE_DESC primary key,
                    EM_WASTE_ID int NOT NULL
                        constraint FK_RCRA_EM_FED_WS_CD_EM_WS_ID references RCRA_EM_WASTE on delete cascade,
                    FED_MANIFEST_WASTE_CODE varchar2(6) NOT NULL,
                    MANIFEST_WASTE_DESC varchar2(2000) NULL,
                    COI_IND char(1) NULL',
                   null
            from dual
            union all
            select 2,
                   'CT',
                   'RCRA_EM_STATE_WASTE_CODE_DESC',
                   'EM_STATE_WASTE_CODE_DESC_ID int 
                        constraint PK_EM_STATE_WASTE_CODE_DESC primary key,
                    EM_WASTE_ID int NOT NULL
                        constraint FK_EM_ST_WST_CD_DESC_EM_WST_ID references RCRA_EM_WASTE on delete cascade,
                    STA_MANIFEST_WASTE_CODE varchar2(8) NOT NULL,
                    MANIFEST_WASTE_DESC varchar2(2000) NULL',
                   null
            from dual
            union all
            select 3,
                   'CT',
                   'RCRA_EM_TRANSPORTER',
                   'EM_TRANSPORTER_ID int 
                        constraint PK_EM_TRANSPORTER primary key,
                    EM_EMANIFEST_ID int NOT NULL
                        constraint FK_RCRA_EM_TRANS_EM_EM_ID references RCRA_EM_EMANIFEST on delete cascade,
                    TRANSPORTER_ID varchar2(15) NULL,
                    TRANSPORTER_NAME varchar2(80) NULL,
                    TRANSPORTER_PRINTED_NAME varchar2(80) NULL,
                    TRANSPORTER_SIGNATURE_DATE date null,
                    TRANSPORTER_ESIG_FIRST_NAME varchar2(38) NULL,
                    TRANSPORTER_ESIG_LAST_NAME varchar2(38) NULL,
                    TRANS_ESIG_SIGNATURE_DATE date null,
                    TRANSPORTER_LINE_NUM varchar2(19) NULL,
                    TRANSPORTER_REGISTERED char(1) NULL',
                   null
            from dual
            union all
            select 4,
                   'CI',
                   'IX_EM_FD_WST_CDE_DSC_EM_WST_ID',
                   'EM_WASTE_ID',
                   'RCRA_EM_FED_WASTE_CODE_DESC'
            from dual
            union all
            select 5,
                   'CI',
                   'IX_EM_STT_WST_CDE_DSC_EM_WS_ID',
                   'EM_WASTE_ID',
                   'RCRA_EM_STATE_WASTE_CODE_DESC'
            from dual
            union all
            select 6,
                   'CI',
                   'IX_EM_TRNSPORTER_EM_EMNIFST_ID',
                   'EM_EMANIFEST_ID',
                   'RCRA_EM_TRANSPORTER'
            from dual
            union all
            select 7, 'DS', 'NODE_RCRA_EM_WASTE_CD_TSDF', null, null
            from dual
            union all
            select 8, 'DS', 'NODE_RCRA_EM_WASTE_CD_GEN', null, null
            from dual
            union all
            select 9, 'DS', 'NODE_RCRA_EM_WASTE_CD_FED', null, null
            from dual
            union all
            select 10, 'DS', 'NODE_RCRA_EM_TR_NUM_WASTE', null, null
            from dual
            union all
            select 11, 'DS', 'NODE_RCRA_EM_TR_NUM_REJ', null, null
            from dual
            union all
            select 12, 'DS', 'NODE_RCRA_EM_TR_NUM_ORIG', null, null
            from dual
            union all
            select 13, 'DS', 'NODE_RCRA_EM_TR_NUM_RES_NEW', null, null
            from dual
            union all
            select 14, 'DS', 'NODE_RCRA_EM_HANDLER', null, null
            from dual
            union all
            select 15, 'DS', 'NODE_RCRA_EM_EMANIFEST', null, null
            from dual
            union all
            select 16, 'DS', 'NODE_RCRA_EM_EMANIFEST_COMMENT', null, null
            from dual
            union all
            select 17, 'DS', 'NODE_RCRA_EM_WASTE', null, null
            from dual
            union all
            select 18, 'DS', 'NODE_RCRA_EM_WASTE_COMMENT', null, null
            from dual
            union all
            select 19, 'DS', 'NODE_RCRA_EM_WASTE_PCB', null, null
            from dual
            union all
            select 20,
                   'CS',
                   'NODE_RCRA_EM_FED_WASTE_CODE',
                   null,
                   target_db || '.' || 'RCRA_EM_FED_WASTE_CODE_DESC'
            from dual
            union all
            select 21,
                   'CS',
                   'NODE_RCRA_EM_STATE_WASTE_CODE',
                   null,
                   target_db || '.' || 'RCRA_EM_STATE_WASTE_CODE_DESC'
            from dual
            union all
            select 22,
                   'CS',
                   'NODE_RCRA_EM_TRANSPORTER',
                   null,
                   target_db || '.' || 'RCRA_EM_TRANSPORTER'
            from dual
            union all
            select 23,
                   'CS',
                   'NODE_RCRA_EM_EMANIFEST',
                   null,
                   target_db || '.' || 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 24,
                   'CS',
                   'NODE_RCRA_EM_EMANIFEST_COMMENT',
                   null,
                   target_db || '.' || 'RCRA_EM_EMANIFEST_COMMENT'
            from dual
            union all
            select 25,
                   'CS',
                   'NODE_RCRA_EM_WASTE',
                   null,
                   target_db || '.' || 'RCRA_EM_WASTE'
            from dual
            union all
            select 26,
                   'CS',
                   'NODE_RCRA_EM_WASTE_COMMENT',
                   null,
                   target_db || '.' || 'RCRA_EM_WASTE_COMMENT'
            from dual
            union all
            select 27,
                   'CS',
                   'NODE_RCRA_EM_WASTE_PCB',
                   null,
                   target_db || '.' || 'RCRA_EM_WASTE_PCB'
            from dual
            union all
            select 28, 'AC', 'GENERATOR_ID', 'varchar2(15)', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 29,
                   'AC',
                   'GENERATOR_NAME',
                   'varchar2(80)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 30,
                   'AC',
                   'GENERATOR_MAIL_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 31,
                   'AC',
                   'GENERATOR_MAIL_STREET_1',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 32,
                   'AC',
                   'GENERATOR_MAIL_STREET_2',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 33,
                   'AC',
                   'GENERATOR_MAIL_CITY',
                   'varchar2(35) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 34,
                   'AC',
                   'GENERATOR_MAIL_CTRY',
                   'char(2)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 35,
                   'AC',
                   'GENERATOR_MAIL_STA',
                   'char(2)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 36,
                   'AC',
                   'GENERATOR_MAIL_ZIP',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 37,
                   'AC',
                   'GENERATOR_LOC_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 38,
                   'AC',
                   'GENERATOR_LOC_STREET_1',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 39,
                   'AC',
                   'GENERATOR_LOC_STREET_2',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 40,
                   'AC',
                   'GENERATOR_LOC_CITY',
                   'varchar2(35) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 41,
                   'AC',
                   'GENERATOR_LOC_STA',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 42,
                   'AC',
                   'GENERATOR_LOC_ZIP',
                   'varchar2(25) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 43,
                   'AC',
                   'GENERATOR_CONTACT_FIRST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 44,
                   'AC',
                   'GENERATOR_CONTACT_LAST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 45,
                   'AC',
                   'GENERATOR_CONTACT_COMPANY_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 46,
                   'AC',
                   'GENERATOR_CONTACT_EMAIL',
                   'varchar2(80)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 47,
                   'AC',
                   'GENERATOR_CONTACT_PHONE_NUM',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 48,
                   'AC',
                   'GENERATOR_CONTACT_PHONE_EXT',
                   'varchar2(6) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 49,
                   'AC',
                   'GENERATOR_PRINTED_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 50,
                   'AC',
                   'GENERATOR_SIGNATURE_DATE',
                   'date',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 51,
                   'AC',
                   'GENERATOR_ESIG_FIRST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 52,
                   'AC',
                   'GENERATOR_ESIG_LAST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 53,
                   'AC',
                   'GENERATOR_ESIG_SIGNATURE_DATE',
                   'date',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 54,
                   'AC',
                   'GENERATOR_REGISTERED',
                   'char(1)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 55,
                   'AC',
                   'GENERATOR_MODIFIED',
                   'char(1)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 56,
                   'AC',
                   'DES_FAC_ID',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 57,
                   'AC',
                   'DES_FAC_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 58,
                   'AC',
                   'DES_FAC_MAIL_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 59,
                   'AC',
                   'DES_FAC_MAIL_STREET_1',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 60,
                   'AC',
                   'DES_FAC_MAIL_STREET_2',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 61,
                   'AC',
                   'DES_FAC_MAIL_CITY',
                   'varchar2(35) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 62,
                   'AC',
                   'DES_FAC_MAIL_CTRY',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 63,
                   'AC',
                   'DES_FAC_MAIL_STA',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 64,
                   'AC',
                   'DES_FAC_MAIL_ZIP',
                   'varchar2(25) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 65,
                   'AC',
                   'DES_FAC_LOC_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 66,
                   'AC',
                   'DES_FAC_LOC_STREET_1',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 67,
                   'AC',
                   'DES_FAC_LOC_STREET_2',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 68,
                   'AC',
                   'DES_FAC_LOC_CITY',
                   'varchar2(35) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 69,
                   'AC',
                   'DES_FAC_LOC_STA',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 70,
                   'AC',
                   'DES_FAC_LOC_ZIP',
                   'varchar2(25) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 71,
                   'AC',
                   'DES_FAC_CONTACT_FIRST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 72,
                   'AC',
                   'DES_FAC_CONTACT_LAST_NAME',
                   'varchar2(38)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 73,
                   'AC',
                   'DES_FAC_CONTACT_COMPANY_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 74,
                   'AC',
                   'DES_FAC_CONTACT_PHONE_NUM',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 75,
                   'AC',
                   'DES_FAC_CONTACT_PHONE_EXT',
                   'varchar2(6) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 76,
                   'AC',
                   'DES_FAC_CONTACT_EMAIL',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 77,
                   'AC',
                   'DES_FAC_PRINTED_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 78,
                   'AC',
                   'DES_FAC_SIGNATURE_DATE',
                   'date',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 79,
                   'AC',
                   'DES_FAC_ESIG_FIRST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 80,
                   'AC',
                   'DES_FAC_ESIG_LAST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 81,
                   'AC',
                   'DES_FAC_ESIG_SIGNATURE_DATE',
                   'date null',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 82,
                   'AC',
                   'DES_FAC_REGISTERED',
                   'char(1)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 83, 'AC', 'DES_FAC_MODIFIED', 'char(1)', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 84,
                   'AC',
                   'ALT_FAC_ID',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 85,
                   'AC',
                   'ALT_FAC_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 86,
                   'AC',
                   'ALT_FAC_MAIL_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 87,
                   'AC',
                   'ALT_FAC_MAIL_STREET_1',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 88,
                   'AC',
                   'ALT_FAC_MAIL_STREET_2',
                   'varchar2(50)',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 89,
                   'AC',
                   'ALT_FAC_MAIL_CITY',
                   'varchar2(25) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 90,
                   'AC',
                   'ALT_FAC_MAIL_STA',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 91,
                   'AC',
                   'ALT_FAC_MAIL_ZIP',
                   'varchar2(14) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 92,
                   'AC',
                   'ALT_FAC_LOC_STREET_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 93,
                   'AC',
                   'ALT_FAC_LOC_STREET_1',
                   'varchar2(50) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 94,
                   'AC',
                   'ALT_FAC_LOC_STREET_2',
                   'varchar2(50) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 95,
                   'AC',
                   'ALT_FAC_LOC_CITY',
                   'varchar2(25) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 96,
                   'AC',
                   'ALT_FAC_LOC_STA',
                   'char(2) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 97,
                   'AC',
                   'ALT_FAC_LOC_ZIP',
                   'varchar2(14) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 98,
                   'AC',
                   'ALT_FAC_CONTACT_FIRST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 99,
                   'AC',
                   'ALT_FAC_CONTACT_LAST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 100,
                   'AC',
                   'ALT_FAC_CONTACT_COMPANY_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 101,
                   'AC',
                   'ALT_FAC_CONTACT_PHONE_NO',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 102,
                   'AC',
                   'ALT_FAC_CONTACT_PHONE_EXT',
                   'varchar2(6) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 103,
                   'AC',
                   'ALT_FAC_CONTACT_EMAIL',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 104,
                   'AC',
                   'ALT_FAC_PRINTED_NAME',
                   'varchar2(80) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 105,
                   'AC',
                   'ALT_FAC_SIGNATURE_DATE',
                   'date null',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 106,
                   'AC',
                   'ALT_FAC_ESIG_FIRST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 107,
                   'AC',
                   'ALT_FAC_ESIG_LAST_NAME',
                   'varchar2(38) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 108,
                   'AC',
                   'ALT_FAC_ESIG_SIGNATURE_DATE',
                   'date null',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 109,
                   'AC',
                   'ALT_FAC_REGISTERED',
                   'char(1) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 110,
                   'AC',
                   'ALT_FAC_MODIFIED',
                   'char(1) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 111,
                   'AC',
                   'EMERGENCY_PHONE_NUM',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 112,
                   'AC',
                   'EMERGENCY_PHONE_EXT',
                   'varchar2(6) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 113,
                   'AC',
                   'ORIG_SUBM_TYPE',
                   'varchar2(14) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 114, 'AC', 'COI_ONLY', 'char(1) NULL', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 115,
                   'AC',
                   'BROKER_ID',
                   'varchar2(15) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 116,
                   'AC',
                   'LAST_EM_UPDT_DATE',
                   'date null',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 117, 'AC', 'COI_ONLY', 'char(1) NULL', 'RCRA_EM_WASTE'
            from dual
            union all
            select 118,
                   'AC',
                   'QNTY_ACUTE_KG',
                   'decimal(14, 6) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 119,
                   'AC',
                   'QNTY_ACUTE_TONS',
                   'decimal(14, 6) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 120,
                   'AC',
                   'QNTY_NON_ACUTE_KG',
                   'decimal(14, 6) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 121,
                   'AC',
                   'QNTY_NON_ACUTE_TONS',
                   'decimal(14, 6) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 122,
                   'AC',
                   'QNTY_TONS',
                   'decimal(14, 6) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 124,
                   'AC',
                   'LOAD_TYPE_DESC',
                   'varchar2(25) NULL',
                   'RCRA_EM_WASTE_PCB'
            from dual
            union all
            select 125,
                   'AC',
                   'BR_MIXED_RADIOACTIVE_WASTE',
                   'char(1)',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 126, 'AC', 'QNTY_KG', 'decimal(14,6)', 'RCRA_EM_WASTE'
            from dual
            union all
            select 127,
                   'RC',
                   'ADD_INFO_CONSENT_NUM',
                   'CNST_NUM',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 128, 'RC', 'EPA_WASTE_IND', 'EPA_WASTE', 'RCRA_EM_WASTE'
            from dual
            union all
            select 129,
                   'RC',
                   'DISC_COMMENTS',
                   'DISCREPANCY_COMM',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 130,
                   'RC',
                   'QNT_CONT_TYPE_CODE',
                   'CONTAINER_TYPE_CODE',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 131,
                   'RC',
                   'QNT_CONT_TYPE_DESC',
                   'CONTAINER_TYPE_DESC',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 132, 'RC', 'DOT_ID_NUM', 'DOT_ID_NUM_DESC', 'RCRA_EM_WASTE'
            from dual
            union all
            select 133,
                   'RC',
                   'WASTES_DESC',
                   'NON_HAZ_WASTE_DESC',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 134, 'RC', 'QNT_CONT_NUM', 'CONTAINER_NUM', 'RCRA_EM_WASTE'
            from dual
            union all
            select 135, 'RC', 'QNT_VAL', 'QNTY_VAL', 'RCRA_EM_WASTE'
            from dual
            union all
            select 136,
                   'RC',
                   'QNT_UOM_CODE',
                   'QTY_UNIT_OF_MEAS_CODE',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 137,
                   'RC',
                   'QNT_UOM_DESC',
                   'QTY_UNIT_OF_MEAS_DESC',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 138,
                   'RC',
                   'BR_FORM_DESC',
                   'BR_FORM_CODE_DESC',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 139, 'RC', 'BR_SRC_DESC', 'BR_SRC_CODE_DESC', 'RCRA_EM_WASTE'
            from dual
            union all
            select 140, 'RC', 'BR_WM_CODE', 'BR_WASTE_MIN_CODE', 'RCRA_EM_WASTE'
            from dual
            union all
            select 141, 'RC', 'BR_WM_DESC', 'BR_WASTE_MIN_DESC', 'RCRA_EM_WASTE'
            from dual
            union all
            select 142, 'RC', 'PCB_IND', 'PCB', 'RCRA_EM_WASTE'
            from dual
            union all
            select 143,
                   'RC',
                   'DISC_RESIDUE_COMMENTS',
                   'WASTE_RESIDUE_COMM',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 144,
                   'RC',
                   'DISC_WASTE_QTY_IND',
                   'QNTY_DISCREPANCY',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 145,
                   'RC',
                   'DISC_WASTE_TYPE_IND',
                   'WASTE_TYPE_DISCREPANCY',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 146,
                   'RC',
                   'MGMT_METHOD_CODE',
                   'MANAGEMENT_METH_CODE',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 147,
                   'RC',
                   'MGMT_METHOD_DESC',
                   'MANAGEMENT_METH_DESC',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 148,
                   'RC',
                   'ADD_INFO_HAND_INSTR',
                   'HANDLING_INSTRUCTIONS',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 149,
                   'RC',
                   'COMMENT_LABEL',
                   'CMNT_LABEL',
                   'RCRA_EM_WASTE_COMMENT'
            from dual
            union all
            select 150,
                   'RC',
                   'REJ_TRANS_ON_SITE_IND',
                   'TRANSPORTER_ON_SITE',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 151,
                   'RC',
                   'IMP_GEN_NAME',
                   'FOREIGN_GENERATOR_NAME',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 152,
                   'RC',
                   'IMP_GEN_ADDRESS',
                   'FOREIGN_GENERATOR_STREET',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 153,
                   'RC',
                   'IMP_GEN_CITY',
                   'FOREIGN_GENERATOR_CITY',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 154,
                   'RC',
                   'IMP_GEN_CNTRY_CODE',
                   'FOREIGN_GENERATOR_CTRY_CODE',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 155,
                   'RC',
                   'IMP_GEN_POSTAL_CODE',
                   'FOREIGN_GENERATOR_POST_CODE',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 156,
                   'RC',
                   'IMP_GEN_PROVINCE',
                   'FOREIGN_GENERATOR_PROVINCE',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 157,
                   'RC',
                   'IMP_PORT_STATE_CODE',
                   'PORT_OF_ENTRY_STA',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 158, 'RC', 'RESIDUE_IND', 'RESIDUE', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 159, 'RC', 'IMP_IND', 'IMPORT', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 160,
                   'RC',
                   'COMMENT_DESC',
                   'CMNT_DESC',
                   'RCRA_EM_EMANIFEST_COMMENT'
            from dual
            union all
            select 161,
                   'RC',
                   'REJ_ALT_DES_FAC_TYPE',
                   'ALTERNATE_DESIGNATED_FAC_TYPE',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 162, 'RC', 'DOT_HAZ_IND', 'DOT_HAZRD', 'RCRA_EM_WASTE'
            from dual
            union all
            select 163,
                   'RC',
                   'ADD_INFO_HAND_INSTR',
                   'MANIFEST_HANDLING_INSTR',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 164, 'RC', 'REJ_TYPE', 'REJECTION_TYPE', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 165,
                   'RC',
                   'IMP_GEN_CNTRY_NAME',
                   'FOREIGN_GENERATOR_CTRY_NAME',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 166,
                   'RC',
                   'IMP_PORT_CITY',
                   'PORT_OF_ENTRY_CITY',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 167,
                   'RC',
                   'COMMENT_LABEL',
                   'CMNT_LABEL',
                   'RCRA_EM_EMANIFEST_COMMENT'
            from dual
            union all
            select 168,
                   'RC',
                   'DISC_RESIDUE_IND',
                   'WASTE_RESIDUE',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 169,
                   'MC',
                   'CREATED_DATE',
                   'date NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 170,
                   'MC',
                   'MAN_TRACKING_NUM',
                   'varchar2(12) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 171, 'MC', 'STATUS', 'varchar2(17) NULL', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 172,
                   'MC',
                   'ORIGIN_TYPE',
                   'varchar2(7) NULL',
                   'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 173, 'MC', 'REJ_IND', 'char(1) NULL', 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 174, 'MC', 'LINE_NUM', 'decimal(10, 0) NULL', 'RCRA_EM_WASTE'
            from dual
            union all
            select 175,
                   'MC',
                   'PCB_LOAD_TYPE_CODE',
                   'varchar2(25)',
                   'RCRA_EM_WASTE_PCB'
            from dual
            union all
            select 176,
                   'MC',
                   'PCB_WASTE_TYPE',
                   'varchar2(150)',
                   'RCRA_EM_WASTE_PCB'
            from dual
            union all
            select 177, 'MC', 'DOT_ID_NUM_DESC', 'varchar2(6)', 'RCRA_EM_WASTE'
            from dual
            union all
            select 178,
                   'MC',
                   'CONTAINER_TYPE_CODE',
                   'char(2) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 179,
                   'MC',
                   'CONTAINER_TYPE_DESC',
                   'varchar2(50) NULL',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 180,
                   'MC',
                   'WASTE_RESIDUE_COMM',
                   'varchar2(257)',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 181,
                   'MC',
                   'DISCREPANCY_COMM',
                   'varchar2(257)',
                   'RCRA_EM_WASTE'
            from dual
            union all
            select 182,
                   'MC',
                   'WASTE_CODE_TEXT',
                   'varchar2(4000)',
                   'RCRA_HD_EPISODIC_WASTE_CODE'
            from dual
            union all
            select 183,
                   'CV',
                   'ETL_EM_EMANIFEST_VW',
                   'select WH.EM_EMANIFEST_ID WH_EM_EMANIFEST_ID,
        NODE.*
        from NODE_RCRA_EM_EMANIFEST NODE
        left join RCRA_EM_EMANIFEST WH on WH.MAN_TRACKING_NUM = NODE.MAN_TRACKING_NUM',
                   null
            from dual
            union all
            select 184,
                   'CV',
                   'ETL_EM_WASTE_VW',
                   'select WH.EM_WASTE_ID WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_WASTE NODE
        join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID
        left join RCRA_EM_WASTE WH
        on WH.EM_EMANIFEST_ID = ETL.WH_EM_EMANIFEST_ID
        and WH.LINE_NUM = NODE.LINE_NUM',
                   null
            from dual
            union all
            select 185,
                   'CV',
                   'ETL_EM_WASTE_COMMENT_VW',
                   'select ETL.WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_WASTE_COMMENT NODE
        join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID',
                   null
            from dual
            union all
            select 186,
                   'CV',
                   'ETL_EM_WASTE_PCB_VW',
                   'select ETL.WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_WASTE_PCB NODE
        join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID',
                   null
            from dual
            union all
            select 187,
                   'CV',
                   'ETL_EM_EMANIFEST_COMMENT_VW',
                   'select ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_EMANIFEST_COMMENT NODE
        join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID',
                   null
            from dual
            union all
            select 188,
                   'CV',
                   'ETL_EM_TRANSPORTER_VW',
                   'select ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_TRANSPORTER NODE
        join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID',
                   null
            from dual
            union all
            select 189,
                   'CV',
                   'ETL_EM_WASTE_CD_TRANS_VW',
                   'select ETL.WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_WASTE_CD_TRANS NODE
        join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID',
                   null
            from dual
            union all
            select 190,
                   'CV',
                   'ETL_EM_FED_WASTE_CODE_DESC_VW',
                   'select ETL.WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_FED_WASTE_CODE NODE
        join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID',
                   null
            from dual
            union all
            select 191,
                   'CV',
                   'ETL_EM_STATE_WASTE_CODE_VW',
                   'select ETL.WH_EM_WASTE_ID,
        ETL.WH_EM_EMANIFEST_ID,
        ETL.EM_SUBM_ID,
        NODE.*
        from NODE_RCRA_EM_STATE_WASTE_CODE NODE
        join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID',
                   null
            from dual
            union all
            select 192, 'DV', 'ETL_EM_TR_NUM_ORIG_VW', null, null
            from dual
            union all
            select 193, 'DV', 'ETL_EM_TR_NUM_RESIDUE_NEW_VW', null, null
            from dual
            union all
            select 194, 'DV', 'ETL_EM_TR_NUM_REJ_VW', null, null
            from dual
            union all
            select 195, 'DV', 'ETL_EM_TR_NUM_WASTE_VW', null, null
            from dual
            union all
            select 196, 'DV', 'ETL_EM_WASTE_CD_FED_VW', null, null
            from dual
            union all
            select 197, 'DV', 'ETL_EM_WASTE_CD_GEN_VW', null, null
            from dual
            union all
            select 198, 'DV', 'ETL_EM_WASTE_CD_TSDF_VW', null, null
            from dual
            union all
            select 199, 'DV', 'ETL_EM_HANDLER_VW', null, null
            from dual
            union all
            select 200, 'CQ', 'SEQ_RCRA_EM_TRANSPORTER', null, null
            from dual
            union all
            select 201, 'CQ', 'SEQ_EM_FED_WASTE_CODE_DESC_ID', null, null
            from dual
            union all
            select 202, 'CQ', 'SEQ_EM_STATE_WASTE_CODE_DESC', null, null
            from dual
            union all
            select 203, 'DQ', 'SEQ_RCRA_EM_HANDLER', null, null
            from dual
            union all
            select 204, 'DQ', 'SEQ_RCRA_EM_TR_NUM_ORIG', null, null
            from dual
            union all
            select 205, 'DQ', 'SEQ_RCRA_EM_TR_NUM_REJ', null, null
            from dual
            union all
            select 206, 'DQ', 'SEQ_RCRA_EM_TR_NUM_RESIDUE_NEW', null, null
            from dual
            union all
            select 207, 'DQ', 'SEQ_RCRA_EM_TR_NUM_WASTE', null, null
            from dual
            union all
            select 208, 'DQ', 'SEQ_RCRA_EM_WASTE_CD_FED', null, null
            from dual
            union all
            select 209, 'DQ', 'SEQ_RCRA_EM_WASTE_CD_TSDF', null, null
            from dual
            union all
            select 210,
                   'RC',
                   'COMMENT_DESC',
                   'CMNT_DESC',
                   'RCRA_EM_WASTE_COMMENT'
            from dual)
        select t.type_code, t.obj_name, t.obj_def, t.target_name
        from t
        order by t.sort_order
    ;
begin
    open x;
    loop
        fetch x into type_code, obj_name, obj_def, target_name;
        exit when x%notfound;
        dbms_output.put_line('type_code=' || type_code || ', obj_name=' || obj_name || ', obj_def=' || obj_def
            || ', target_name=' || target_name);
        handle_db_action(
                type_code => type_code,
                obj_name => obj_name,
                obj_def => obj_def,
                target_name => target_name
            );
    end loop;
    close x;

    dbms_output.put_line('Deleting manifests with a null tracking number');
    delete
    from RCRA_EM_EMANIFEST
    where MAN_TRACKING_NUM is null;
    dbms_output.put_line('Count of manifests deleted with a null tracking number: ' || sql%rowcount);

    select count(*)
    into exists_ind
    from ALL_TAB_COLS x
    where x.OWNER = source_db
      and x.TABLE_NAME = 'RCRA_EM_EMANIFEST'
      and x.COLUMN_NAME = 'CORR_VERSION_NUM';

    if exists_ind = 1
    then
        query := 'delete
        from RCRA_EM_EMANIFEST
        where EM_EMANIFEST_ID in (
            with t as (
                select m.EM_EMANIFEST_ID,
                       row_number() over (partition by m.MAN_TRACKING_NUM order by m.CORR_VERSION_NUM desc) as RN
                from RCRA_EM_EMANIFEST m
            )
            select t.EM_EMANIFEST_ID
            from t
            where t.RN > 1)';
        execute immediate query;
        dbms_output.put_line('Count of non-current manifests deleted: ' || sql%rowcount);
    else
        dbms_output.put_line('Skipped deleting non-current manifest records because RCRA_EM_EMANIFEST.CORR_VERSION_NUM column does not exist');
    end if;

    select count(*)
    into exists_ind
    from ALL_TABLES x
    where x.OWNER = source_db
      and x.TABLE_NAME = 'RCRA_EM_HANDLER';

    if exists_ind = 1
    then
        query := 'merge into RCRA_EM_EMANIFEST d
        using (select m.EM_EMANIFEST_ID,
                      gen.EPA_SITE_ID           as GEN_EPA_SITE_ID,
                      gen.MANIFEST_NAME         as GEN_MANIFEST_NAME,
                      gen.REG_IND               as GEN_REG_IND,
                      gen.MOD_IND               as GEN_MOD_IND,
                      gen.MAIL_STREET_NUM       as GEN_MAIL_STREET_NUM,
                      gen.MAIL_STREET1          as GEN_MAIL_STREET1,
                      gen.MAIL_STREET2          as GEN_MAIL_STREET2,
                      gen.MAIL_CITY             as GEN_MAIL_CITY,
                      gen.MAIL_ZIP              as GEN_MAIL_ZIP,
                      gen.MAIL_STATE_CODE       as GEN_MAIL_STATE_CODE,
                      gen.SITE_STREET_NUM       as GEN_SITE_STREET_NUM,
                      gen.SITE_STREET1          as GEN_SITE_STREET1,
                      gen.SITE_STREET2          as GEN_SITE_STREET2,
                      gen.SITE_CITY             as GEN_SITE_CITY,
                      gen.SITE_STATE_CODE       as GEN_SITE_STATE_CODE,
                      gen.SITE_ZIP              as GEN_SITE_ZIP,
                      gen.CONTACT_FIRST_NAME    as GEN_CONTACT_FIRST_NAME,
                      gen.CONTACT_LAST_NAME     as GEN_CONTACT_LAST_NAME,
                      gen.CONTACT_EMAIL         as GEN_CONTACT_EMAIL,
                      gen.CONTACT_COMPANY_NAME  as GEN_CONTACT_COMPANY_NAME,
                      gen.CONTACT_PHONE_NUM     as GEN_CONTACT_PHONE_NUM,
                      gen.CONTACT_PHONE_EXT     as GEN_CONTACT_PHONE_EXT,
                      gen.PS_NAME               as GEN_PS_NAME,
                      gen.PS_DATE               as GEN_PS_DATE,
                      gen.ES_SIGN_DATE          as GEN_ES_SIGN_DATE,
                      gen.ES_SIGNER_FIRST_NAME  as GEN_ES_SIGNER_FIRST_NAME,
                      gen.ES_SIGNER_LAST_NAME   as GEN_ES_SIGNER_LAST_NAME,
                      gen.EMERG_PHONE_NUM       as GEN_EMERG_PHONE_NUM,
                      gen.EMERG_PHONE_EXT       as GEN_EMERG_PHONE_EXT,
                      tsdf.EPA_SITE_ID          as TSDF_EPA_SITE_ID,
                      tsdf.MANIFEST_NAME        as TSDF_MANIFEST_NAME,
                      tsdf.REG_IND              as TSDF_REG_IND,
                      tsdf.MOD_IND              as TSDF_MOD_IND,
                      tsdf.MAIL_STREET_NUM      as TSDF_MAIL_STREET_NUM,
                      tsdf.MAIL_STREET1         as TSDF_MAIL_STREET1,
                      tsdf.MAIL_STREET2         as TSDF_MAIL_STREET2,
                      tsdf.MAIL_CITY            as TSDF_MAIL_CITY,
                      tsdf.MAIL_ZIP             as TSDF_MAIL_ZIP,
                      tsdf.MAIL_STATE_CODE      as TSDF_MAIL_STATE_CODE,
                      tsdf.SITE_STREET_NUM      as TSDF_SITE_STREET_NUM,
                      tsdf.SITE_STREET1         as TSDF_SITE_STREET1,
                      tsdf.SITE_STREET2         as TSDF_SITE_STREET2,
                      tsdf.SITE_CITY            as TSDF_SITE_CITY,
                      tsdf.SITE_STATE_CODE      as TSDF_SITE_STATE_CODE,
                      tsdf.SITE_ZIP             as TSDF_SITE_ZIP,
                      tsdf.CONTACT_FIRST_NAME   as TSDF_CONTACT_FIRST_NAME,
                      tsdf.CONTACT_LAST_NAME    as TSDF_CONTACT_LAST_NAME,
                      tsdf.CONTACT_EMAIL        as TSDF_CONTACT_EMAIL,
                      tsdf.CONTACT_COMPANY_NAME as TSDF_CONTACT_COMPANY_NAME,
                      tsdf.CONTACT_PHONE_NUM    as TSDF_CONTACT_PHONE_NUM,
                      tsdf.CONTACT_PHONE_EXT    as TSDF_CONTACT_PHONE_EXT,
                      tsdf.PS_NAME              as TSDF_PS_NAME,
                      tsdf.PS_DATE              as TSDF_PS_DATE,
                      tsdf.ES_SIGN_DATE         as TSDF_ES_SIGN_DATE,
                      tsdf.ES_SIGNER_FIRST_NAME as TSDF_ES_SIGNER_FIRST_NAME,
                      tsdf.ES_SIGNER_LAST_NAME  as TSDF_ES_SIGNER_LAST_NAME,
                      tsdf.EMERG_PHONE_NUM      as TSDF_EMERG_PHONE_NUM,
                      tsdf.EMERG_PHONE_EXT      as TSDF_EMERG_PHONE_EXT,
                      alt.EPA_SITE_ID           as ALT_EPA_SITE_ID,
                      alt.MANIFEST_NAME         as ALT_MANIFEST_NAME,
                      alt.REG_IND               as ALT_REG_IND,
                      alt.MOD_IND               as ALT_MOD_IND,
                      alt.MAIL_STREET_NUM       as ALT_MAIL_STREET_NUM,
                      alt.MAIL_STREET1          as ALT_MAIL_STREET1,
                      alt.MAIL_STREET2          as ALT_MAIL_STREET2,
                      alt.MAIL_CITY             as ALT_MAIL_CITY,
                      alt.MAIL_ZIP              as ALT_MAIL_ZIP,
                      alt.MAIL_STATE_CODE       as ALT_MAIL_STATE_CODE,
                      alt.SITE_STREET_NUM       as ALT_SITE_STREET_NUM,
                      alt.SITE_STREET1          as ALT_SITE_STREET1,
                      alt.SITE_STREET2          as ALT_SITE_STREET2,
                      alt.SITE_CITY             as ALT_SITE_CITY,
                      alt.SITE_STATE_CODE       as ALT_SITE_STATE_CODE,
                      alt.SITE_ZIP              as ALT_SITE_ZIP,
                      alt.CONTACT_FIRST_NAME    as ALT_CONTACT_FIRST_NAME,
                      alt.CONTACT_LAST_NAME     as ALT_CONTACT_LAST_NAME,
                      alt.CONTACT_EMAIL         as ALT_CONTACT_EMAIL,
                      alt.CONTACT_COMPANY_NAME  as ALT_CONTACT_COMPANY_NAME,
                      alt.CONTACT_PHONE_NUM     as ALT_CONTACT_PHONE_NUM,
                      alt.CONTACT_PHONE_EXT     as ALT_CONTACT_PHONE_EXT,
                      alt.PS_NAME               as ALT_PS_NAME,
                      alt.PS_DATE               as ALT_PS_DATE,
                      alt.ES_SIGN_DATE          as ALT_ES_SIGN_DATE,
                      alt.ES_SIGNER_FIRST_NAME  as ALT_ES_SIGNER_FIRST_NAME,
                      alt.ES_SIGNER_LAST_NAME   as ALT_ES_SIGNER_LAST_NAME,
                      alt.EMERG_PHONE_NUM       as ALT_EMERG_PHONE_NUM,
                      alt.EMERG_PHONE_EXT       as ALT_EMERG_PHONE_EXT
               from RCRA_EM_EMANIFEST m
                        left join RCRA_EM_HANDLER gen
                                  on m.EM_EMANIFEST_ID = gen.EM_EMANIFEST_ID and gen.MANIFEST_HANDLER_TYPE = ''Generator''
                        left join RCRA_EM_HANDLER tsdf
                                  on m.EM_EMANIFEST_ID = tsdf.EM_EMANIFEST_ID and
                                     tsdf.MANIFEST_HANDLER_TYPE = ''DesignatedFacility''
                        left join RCRA_EM_HANDLER alt on m.EM_EMANIFEST_ID = alt.EM_EMANIFEST_ID and
                                                         alt.MANIFEST_HANDLER_TYPE in (''AlternateDesignatedFacility'', ''AlternateDesignateFacility'') s
        on (d.EM_EMANIFEST_ID = s.EM_EMANIFEST_ID)
        when matched then
            update
            set -- generator
                d.GENERATOR_ID                   = s.GEN_EPA_SITE_ID,
                d.GENERATOR_NAME                 = s.GEN_MANIFEST_NAME,
                d.GENERATOR_REGISTERED           = s.GEN_REG_IND,
                d.GENERATOR_MODIFIED             = s.GEN_MOD_IND,
                d.GENERATOR_MAIL_STREET_NUM      = s.GEN_MAIL_STREET_NUM,
                d.GENERATOR_MAIL_STREET_1        = s.GEN_MAIL_STREET1,
                d.GENERATOR_MAIL_STREET_2        = s.GEN_MAIL_STREET2,
                d.GENERATOR_MAIL_CITY            = s.GEN_MAIL_CITY,
                d.GENERATOR_MAIL_ZIP             = s.GEN_MAIL_ZIP,
                d.GENERATOR_MAIL_STA             = s.GEN_MAIL_STATE_CODE,
                d.GENERATOR_LOC_STREET_NUM       = s.GEN_SITE_STREET_NUM,
                d.GENERATOR_LOC_STREET_1         = s.GEN_SITE_STREET1,
                d.GENERATOR_LOC_STREET_2         = s.GEN_SITE_STREET2,
                d.GENERATOR_LOC_CITY             = s.GEN_SITE_CITY,
                d.GENERATOR_LOC_STA              = s.GEN_SITE_STATE_CODE,
                d.GENERATOR_LOC_ZIP              = s.GEN_SITE_ZIP,
                d.GENERATOR_CONTACT_FIRST_NAME   = s.GEN_CONTACT_FIRST_NAME,
                d.GENERATOR_CONTACT_LAST_NAME    = s.GEN_CONTACT_LAST_NAME,
                d.GENERATOR_CONTACT_EMAIL        = s.GEN_CONTACT_EMAIL,
                d.GENERATOR_CONTACT_COMPANY_NAME = s.GEN_CONTACT_COMPANY_NAME,
                d.GENERATOR_CONTACT_PHONE_NUM    = s.GEN_CONTACT_PHONE_NUM,
                d.GENERATOR_CONTACT_PHONE_EXT    = s.GEN_CONTACT_PHONE_EXT,
                d.GENERATOR_PRINTED_NAME         = s.GEN_PS_NAME,
                d.GENERATOR_SIGNATURE_DATE       = s.GEN_PS_DATE,
                d.GENERATOR_ESIG_SIGNATURE_DATE  = s.GEN_ES_SIGN_DATE,
                d.GENERATOR_ESIG_FIRST_NAME      = s.GEN_ES_SIGNER_FIRST_NAME,
                d.GENERATOR_ESIG_LAST_NAME       = s.GEN_ES_SIGNER_LAST_NAME,
                --- TSDF
                d.DES_FAC_ID                     = s.TSDF_EPA_SITE_ID,
                d.DES_FAC_NAME                   = s.TSDF_MANIFEST_NAME,
                d.DES_FAC_REGISTERED             = s.TSDF_REG_IND,
                d.DES_FAC_MODIFIED               = s.TSDF_MOD_IND,
                d.DES_FAC_MAIL_STREET_NUM        = s.TSDF_MAIL_STREET_NUM,
                d.DES_FAC_MAIL_STREET_1          = s.TSDF_MAIL_STREET1,
                d.DES_FAC_MAIL_STREET_2          = s.TSDF_MAIL_STREET2,
                d.DES_FAC_MAIL_CITY              = s.TSDF_MAIL_CITY,
                d.DES_FAC_MAIL_ZIP               = s.TSDF_MAIL_ZIP,
                d.DES_FAC_MAIL_STA               = s.TSDF_MAIL_STATE_CODE,
                d.DES_FAC_LOC_STREET_NUM         = s.TSDF_SITE_STREET_NUM,
                d.DES_FAC_LOC_STREET_1           = s.TSDF_SITE_STREET1,
                d.DES_FAC_LOC_STREET_2           = s.TSDF_SITE_STREET2,
                d.DES_FAC_LOC_CITY               = s.TSDF_SITE_CITY,
                d.DES_FAC_LOC_STA                = s.TSDF_SITE_STATE_CODE,
                d.DES_FAC_LOC_ZIP                = s.TSDF_SITE_ZIP,
                d.DES_FAC_CONTACT_FIRST_NAME     = s.TSDF_CONTACT_FIRST_NAME,
                d.DES_FAC_CONTACT_LAST_NAME      = s.TSDF_CONTACT_LAST_NAME,
                d.DES_FAC_CONTACT_EMAIL          = s.TSDF_CONTACT_EMAIL,
                d.DES_FAC_CONTACT_COMPANY_NAME   = s.TSDF_CONTACT_COMPANY_NAME,
                d.DES_FAC_CONTACT_PHONE_NUM      = s.TSDF_CONTACT_PHONE_NUM,
                d.DES_FAC_CONTACT_PHONE_EXT      = s.TSDF_CONTACT_PHONE_EXT,
                d.DES_FAC_PRINTED_NAME           = s.TSDF_PS_NAME,
                d.DES_FAC_SIGNATURE_DATE         = s.TSDF_PS_DATE,
                d.DES_FAC_ESIG_SIGNATURE_DATE    = s.TSDF_ES_SIGN_DATE,
                d.DES_FAC_ESIG_FIRST_NAME        = s.TSDF_ES_SIGNER_FIRST_NAME,
                d.DES_FAC_ESIG_LAST_NAME         = s.TSDF_ES_SIGNER_LAST_NAME,
                --- alt TSDF
                d.ALT_FAC_ID                     = s.ALT_EPA_SITE_ID,
                d.ALT_FAC_NAME                   = s.ALT_MANIFEST_NAME,
                d.ALT_FAC_REGISTERED             = s.ALT_REG_IND,
                d.ALT_FAC_MODIFIED               = s.ALT_MOD_IND,
                d.ALT_FAC_MAIL_STREET_NUM        = s.ALT_MAIL_STREET_NUM,
                d.ALT_FAC_MAIL_STREET_1          = s.ALT_MAIL_STREET1,
                d.ALT_FAC_MAIL_STREET_2          = s.ALT_MAIL_STREET2,
                d.ALT_FAC_MAIL_CITY              = s.ALT_MAIL_CITY,
                d.ALT_FAC_MAIL_ZIP               = s.ALT_MAIL_ZIP,
                d.ALT_FAC_MAIL_STA               = s.ALT_MAIL_STATE_CODE,
                d.ALT_FAC_LOC_STREET_NUM         = s.ALT_SITE_STREET_NUM,
                d.ALT_FAC_LOC_STREET_1           = s.ALT_SITE_STREET1,
                d.ALT_FAC_LOC_STREET_2           = s.ALT_SITE_STREET2,
                d.ALT_FAC_LOC_CITY               = s.ALT_SITE_CITY,
                d.ALT_FAC_LOC_STA                = s.ALT_SITE_STATE_CODE,
                d.ALT_FAC_LOC_ZIP                = s.ALT_SITE_ZIP,
                d.ALT_FAC_CONTACT_FIRST_NAME     = s.ALT_CONTACT_FIRST_NAME,
                d.ALT_FAC_CONTACT_LAST_NAME      = s.ALT_CONTACT_LAST_NAME,
                d.ALT_FAC_CONTACT_EMAIL          = s.ALT_CONTACT_EMAIL,
                d.ALT_FAC_CONTACT_COMPANY_NAME   = s.ALT_CONTACT_COMPANY_NAME,
                d.ALT_FAC_CONTACT_PHONE_NO       = s.ALT_CONTACT_PHONE_NUM,
                d.ALT_FAC_CONTACT_PHONE_EXT      = s.ALT_CONTACT_PHONE_EXT,
                d.ALT_FAC_PRINTED_NAME           = s.ALT_PS_NAME,
                d.ALT_FAC_SIGNATURE_DATE         = s.ALT_PS_DATE,
                d.ALT_FAC_ESIG_SIGNATURE_DATE    = s.ALT_ES_SIGN_DATE,
                d.ALT_FAC_ESIG_FIRST_NAME        = s.ALT_ES_SIGNER_FIRST_NAME,
                d.ALT_FAC_ESIG_LAST_NAME         = s.ALT_ES_SIGNER_LAST_NAME,
                d.EMERGENCY_PHONE_NUM            = coalesce(s.ALT_EMERG_PHONE_NUM, s.TSDF_EMERG_PHONE_NUM,
                                                            s.GEN_EMERG_PHONE_NUM),
                d.EMERGENCY_PHONE_EXT            = coalesce(s.ALT_EMERG_PHONE_EXT, s.TSDF_EMERG_PHONE_EXT,
                                                            s.GEN_EMERG_PHONE_EXT)';
        execute immediate query;
        dbms_output.put_line('Count of manifests updated: ' || sql%rowcount);
    else
        dbms_output.put_line('Skipped updating manifest records because the RCRA_EM_HANDLER table does not exist');
    end if;

    -- populate the transporter table
    select count(*)
    into exists_ind
    from ALL_TABLES x
    where x.OWNER = source_db
      and x.TABLE_NAME = 'RCRA_EM_HANDLER';
    if exists_ind = 1
    then
        query := 'insert into RCRA_EM_TRANSPORTER (EM_TRANSPORTER_ID, EM_EMANIFEST_ID, TRANSPORTER_ID, TRANSPORTER_NAME,
                                         TRANSPORTER_PRINTED_NAME,
                                         TRANSPORTER_SIGNATURE_DATE, TRANSPORTER_ESIG_FIRST_NAME,
                                         TRANSPORTER_ESIG_LAST_NAME, TRANS_ESIG_SIGNATURE_DATE,
                                         TRANSPORTER_LINE_NUM,
                                         TRANSPORTER_REGISTERED)
        select SEQ_RCRA_EM_TRANSPORTER.nextval,
               h.EM_EMANIFEST_ID,
               h.EPA_SITE_ID,
               h.MANIFEST_NAME,
               h.PS_NAME,
               h.PS_DATE,
               h.ES_SIGNER_FIRST_NAME,
               h.ES_SIGNER_LAST_NAME,
               h.ES_SIGN_DATE,
               h.ORDER_NUM,
               h.REG_IND
        from RCRA_EM_HANDLER h
        where h.MANIFEST_HANDLER_TYPE = ''Transporter''
          and not exists(
                select 1
                from RCRA_EM_TRANSPORTER t
                where t.EM_EMANIFEST_ID = h.EM_EMANIFEST_ID
                  and t.TRANSPORTER_LINE_NUM = h.ORDER_NUM
            )';
        execute immediate query;
        dbms_output.put_line('Count of transporters inserted: ' || sql%rowcount);
    else
        dbms_output.put_line('Skipped inserting transporters because the RCRA_EM_HANDLER table does not exist');
    end if;

    -- populate the RCRA_EM_FED_WASTE_CODE_DESC table
    select count(*)
    into exists_ind
    from ALL_TABLES x
    where x.OWNER = source_db
      and x.TABLE_NAME = 'RCRA_EM_WASTE_CD_FED';

    if exists_ind = 1
    then
        query := 'insert into RCRA_EM_FED_WASTE_CODE_DESC (EM_WASTE_ID, FED_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC, COI_IND)
        select f.EM_WASTE_ID, f.WASTE_CODE, f.WASTE_DESC, null
        from RCRA_EM_WASTE_CD_FED f
        where not exists(
                select 1
                from RCRA_EM_FED_WASTE_CODE_DESC fw
                where fw.EM_WASTE_ID = f.EM_WASTE_ID
                  and fw.FED_MANIFEST_WASTE_CODE = f.WASTE_CODE
            )';
        execute immediate query;
        dbms_output.put_line('Count of RCRA_EM_FED_WASTE_CODE_DESC rows inserted: ' || sql%rowcount);
    else
        dbms_output.put_line('Skipped inserting RCRA_EM_FED_WASTE_CODE_DESC rows because the RCRA_EM_WASTE_CD_FED table does not exist');
    end if;

    -- populate the RCRA_EM_STATE_WASTE_CODE_DESC table
    select count(*)
    into exists_ind
    from ALL_TABLES x
    where x.OWNER = source_db
      and x.TABLE_NAME in ('RCRA_EM_WASTE_CD_GEN', 'RCRA_EM_WASTE_CD_TSDF');
    if exists_ind = 2
    then
        query := 'insert
        into RCRA_EM_STATE_WASTE_CODE_DESC (EM_WASTE_ID, STA_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC)
        with x(WASTE_ID, WASTE_CODE, WASTE_DESC) as ( --
            select t.EM_WASTE_ID, t.WASTE_CODE, t.WASTE_DESC
            from RCRA_EM_WASTE_CD_TSDF t
            union all
            select g.EM_WASTE_ID, g.WASTE_CODE, g.WASTE_DESC
            from RCRA_EM_WASTE_CD_GEN g --
        )
        select WASTE_ID, WASTE_CODE, WASTE_DESC
        from x
        where not exists(
                select 1
                from RCRA_EM_STATE_WASTE_CODE_DESC sw
                where sw.EM_WASTE_ID = x.WASTE_ID
                  and sw.STA_MANIFEST_WASTE_CODE = x.WASTE_CODE
            )';
        execute immediate query;
        dbms_output.put_line('Count of RCRA_EM_STATE_WASTE_CODE_DESC rows inserted: ' || sql%rowcount);
    else
        dbms_output.put_line('Skipped inserting RCRA_EM_STATE_WASTE_CODE_DESC rows because the RCRA_EM_WASTE_CD_TSDF or RCRA_EM_WASTE_CD_GEN table does not exist');
    end if;

    select coalesce(max(m.EM_EMANIFEST_ID), 0)
    into max_val
    from RCRA_EM_EMANIFEST m;

    select SEQ_RCRA_EM_EMANIFEST.nextval
    into next_val
    from dual;

    dbms_output.put_line('Max RCRA_EM_EMANIFEST.EM_EMANIFEST_ID = ' || max_val ||
                         '; select SEQ_RCRA_EM_EMANIFEST.nextval = ' || next_val);

    if max_val > next_val then
        query := 'alter sequence SEQ_RCRA_EM_EMANIFEST increment by ' || (max_val - next_val + 1);
        dbms_output.put_line('Executing: ' || query);
        execute immediate query;
        select SEQ_RCRA_EM_EMANIFEST.nextval
        into next_val
        from dual;
        query := 'alter sequence SEQ_RCRA_EM_EMANIFEST increment by 1';
        execute immediate query;
    else
        dbms_output.put_line('Not updating the nextval of the SEQ_RCRA_EM_EMANIFEST sequence since it is bigger ' ||
                             'than the max value in the RCRA_EM_EMANIFEST.EM_EMANIFEST_ID column');
    end if;
end;

declare
    type_code   varchar2(2);
    obj_name    varchar2(100);
    obj_def     varchar2(4000);
    target_name varchar2(100);
    cursor x is
        with t( --
               sort_order, type_code, obj_name, obj_def, target_name) as ( --
            select 1, 'DT', 'RCRA_EM_WASTE_CD_TSDF', null, null
            from dual
            union all
            select 2, 'DT', 'RCRA_EM_WASTE_CD_GEN', null, null
            from dual
            union all
            select 3, 'DT', 'RCRA_EM_WASTE_CD_FED', null, null
            from dual
            union all
            select 4, 'DT', 'RCRA_EM_TR_NUM_WASTE', null, null
            from dual
            union all
            select 5, 'DT', 'RCRA_EM_TR_NUM_REJ', null, null
            from dual
            union all
            select 6, 'DT', 'RCRA_EM_TR_NUM_ORIG', null, null
            from dual
            union all
            select 7, 'DT', 'RCRA_EM_TR_NUM_RESIDUE_NEW', null, null
            from dual
            union all
            select 8, 'DT', 'RCRA_EM_HANDLER', null, null
            from dual
            union all
            -- drop columns
            select 9, 'DC', 'BR_IND', null, 'RCRA_EM_WASTE'
            from dual
            union all
            select 10, 'DC', 'DISCREPANCY_IND', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 11, 'DC', 'CERT_BY_USER_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 12, 'DC', 'REJ_COMMENTS', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 13, 'DC', 'REJ_GEN_ES_SIGNER_USER_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 14, 'DC', 'REJ_GEN_ES_DOC_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 15, 'DC', 'REJ_GEN_ES_DOC_SIZE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 16, 'DC', 'IMP_PORT_STATE_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 17, 'DC', 'PRINTED_DOC_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 18, 'DC', 'PRINTED_DOC_SIZE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 19, 'DC', 'FORM_DOC_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 20, 'DC', 'FORM_DOC_SIZE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 21, 'DC', 'ADD_INFO_NEW_MAN_DEST', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 22, 'DC', 'CORR_VERSION_NUM', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 23, 'DC', 'CORR_ES_SIGNER_USER_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 24, 'DC', 'CORR_ES_DOC_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 25, 'DC', 'CORR_ES_DOC_SIZE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 26, 'DC', 'HANDLER_ID', null, 'RCRA_EM_EMANIFEST_COMMENT'
            from dual
            union all
            select 27, 'DC', 'ADD_INFO_NEW_MAN_DEST', null, 'RCRA_EM_WASTE'
            from dual
            union all
            select 28, 'DC', 'HANDLER_ID', null, 'RCRA_EM_WASTE_COMMENT'
            from dual
            union all
            select 29, 'DC', 'ADD_INFO_CONSENT_NUM', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 30, 'DC', 'CERT_BY_FIRST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 31, 'DC', 'CERT_BY_LAST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 32, 'DC', 'CONT_PREV_REJ_RES_IND', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 33, 'DC', 'CORR_ACTIVE_IND', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 34, 'DC', 'CORR_EPA_SITE_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 35, 'DC', 'CORR_ES_CROMERR_ACT_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 36, 'DC', 'CORR_ES_CROMERR_DOC_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 37, 'DC', 'CORR_ES_DOC_MIME_TYPE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 38, 'DC', 'CORR_ES_SIGN_DATE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 39, 'DC', 'CORR_ES_SIGNER_FIRST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 40, 'DC', 'CORR_ES_SIGNER_LAST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 41, 'DC', 'FORM_DOC_MIME_TYPE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 42, 'DC', 'PRINTED_DOC_MIME_TYPE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 43, 'DC', 'PUBLIC_IND', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 44, 'DC', 'REJ_GEN_ES_CROMERR_ACT_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 45, 'DC', 'REJ_GEN_ES_CROMERR_DOC_ID', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 46, 'DC', 'REJ_GEN_ES_DOC_MIME_TYPE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 47, 'DC', 'REJ_GEN_ES_SIGN_DATE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 48, 'DC', 'REJ_GEN_ES_SIGNER_FIRST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 49, 'DC', 'REJ_GEN_ES_SIGNER_LAST_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 50, 'DC', 'REJ_GEN_PS_DATE', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 51, 'DC', 'REJ_GEN_PS_NAME', null, 'RCRA_EM_EMANIFEST'
            from dual
            union all
            select 52, 'DC', 'SIGN_STATUS_IND', null, 'RCRA_EM_EMANIFEST'
            from dual
            --
        )
        select t.type_code, t.obj_name, t.obj_def, t.target_name
        from t
        order by t.sort_order
    ;
begin
    open x;
    loop
        fetch x into type_code, obj_name, obj_def, target_name;
        exit when x%notfound;
        dbms_output.put_line('type_code=' || type_code || ', obj_name=' || obj_name || ', obj_def=' || obj_def
            || ', target_name=' || target_name);
        handle_db_action(
                type_code => type_code,
                obj_name => obj_name,
                obj_def => obj_def,
                target_name => target_name
            );
    end loop;
    close x;
end;

-- recreate the RCRAINFO_ETL package

create or replace PACKAGE RCRAINFO_ETL AS
    PROCEDURE MERGE_DATA(TRANS_TYPE varchar);
END RCRAINFO_ETL;
/

CREATE OR REPLACE PACKAGE BODY RCRAINFO_ETL AS

    -- EM
    PROCEDURE EM_LOG_HANDLER AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN (ETL_RUN_ID, RUN_DATE, ETL_TYPE)
        VALUES (ETL_ID, CURRENT_TIMESTAMP, 'EM');
    END;

    PROCEDURE EM_MERGE_EMANIFEST AS
    BEGIN
        merge into RCRA_EM_EMANIFEST D
        using (select *
               from ETL_EM_EMANIFEST_VW) S
        on (D.EM_EMANIFEST_ID = S.WH_EM_EMANIFEST_ID)
        when matched then
            update
            set D.CREATED_DATE                   = S.CREATED_DATE,
                D.UPDATED_DATE                   = S.UPDATED_DATE,
                D.MAN_TRACKING_NUM               = S.MAN_TRACKING_NUM,
                D.STATUS                         = S.STATUS,
                D.DES_FAC_MODIFIED               = S.DES_FAC_MODIFIED,
                D.SUBM_TYPE                      = S.SUBM_TYPE,
                D.GENERATOR_MODIFIED             = S.GENERATOR_MODIFIED,
                D.ORIGIN_TYPE                    = S.ORIGIN_TYPE,
                D.SHIPPED_DATE                   = S.SHIPPED_DATE,
                D.RECEIVED_DATE                  = S.RECEIVED_DATE,
                D.CERT_DATE                      = S.CERT_DATE,
                D.REJ_IND                        = S.REJ_IND,
                D.DES_FAC_REGISTERED             = S.DES_FAC_REGISTERED,
                D.IMPORT                         = S.IMPORT,
                D.GENERATOR_CONTACT_FIRST_NAME   = S.GENERATOR_CONTACT_FIRST_NAME,
                D.GENERATOR_CONTACT_LAST_NAME    = S.GENERATOR_CONTACT_LAST_NAME,
                D.GENERATOR_REGISTERED           = S.GENERATOR_REGISTERED,
                D.REJECTION_TYPE                 = S.REJECTION_TYPE,
                D.ALTERNATE_DESIGNATED_FAC_TYPE  = S.ALTERNATE_DESIGNATED_FAC_TYPE,
                D.GENERATOR_NAME                 = S.GENERATOR_NAME,
                D.DES_FAC_SIGNATURE_DATE         = S.DES_FAC_SIGNATURE_DATE,
                D.GENERATOR_ESIG_SIGNATURE_DATE  = S.GENERATOR_ESIG_SIGNATURE_DATE,
                D.DES_FAC_LOC_STREET_1           = S.DES_FAC_LOC_STREET_1,
                D.ALT_FAC_MAIL_STREET_2          = S.ALT_FAC_MAIL_STREET_2,
                D.DES_FAC_CONTACT_FIRST_NAME     = S.DES_FAC_CONTACT_FIRST_NAME,
                D.DES_FAC_CONTACT_LAST_NAME      = S.DES_FAC_CONTACT_LAST_NAME,
                D.GENERATOR_LOC_STREET_2         = S.GENERATOR_LOC_STREET_2,
                D.GENERATOR_CONTACT_EMAIL        = S.GENERATOR_CONTACT_EMAIL,
                D.DES_FAC_MAIL_STREET_1          = S.DES_FAC_MAIL_STREET_1,
                D.PORT_OF_ENTRY_CITY             = S.PORT_OF_ENTRY_CITY,
                D.GENERATOR_MAIL_ZIP             = S.GENERATOR_MAIL_ZIP,
                D.DES_FAC_MAIL_STREET_2          = S.DES_FAC_MAIL_STREET_2,
                D.GENERATOR_MAIL_STA             = S.GENERATOR_MAIL_STA,
                D.FOREIGN_GENERATOR_CTRY_NAME    = S.FOREIGN_GENERATOR_CTRY_NAME,
                D.GENERATOR_MAIL_CTRY            = S.GENERATOR_MAIL_CTRY,
                D.GENERATOR_MAIL_STREET_1        = S.GENERATOR_MAIL_STREET_1,
                D.GENERATOR_MAIL_STREET_2        = S.GENERATOR_MAIL_STREET_2,
                D.MANIFEST_HANDLING_INSTR        = S.MANIFEST_HANDLING_INSTR,
                D.RESIDUE                        = S.RESIDUE,
                D.GENERATOR_ID                   = S.GENERATOR_ID,
                D.GENERATOR_SIGNATURE_DATE       = S.GENERATOR_SIGNATURE_DATE,
                D.DES_FAC_LOC_STREET_2           = S.DES_FAC_LOC_STREET_2,
                D.ALT_FAC_MAIL_STREET_1          = S.ALT_FAC_MAIL_STREET_1,
                D.GENERATOR_ESIG_FIRST_NAME      = S.GENERATOR_ESIG_FIRST_NAME,
                D.GENERATOR_ESIG_LAST_NAME       = S.GENERATOR_ESIG_LAST_NAME,
                D.GENERATOR_LOC_STREET_1         = S.GENERATOR_LOC_STREET_1,
                D.GENERATOR_MAIL_STREET_NUM      = S.GENERATOR_MAIL_STREET_NUM,
                D.GENERATOR_MAIL_CITY            = S.GENERATOR_MAIL_CITY,
                D.GENERATOR_LOC_STREET_NUM       = S.GENERATOR_LOC_STREET_NUM,
                D.GENERATOR_LOC_CITY             = S.GENERATOR_LOC_CITY,
                D.GENERATOR_LOC_STA              = S.GENERATOR_LOC_STA,
                D.GENERATOR_LOC_ZIP              = S.GENERATOR_LOC_ZIP,
                D.GENERATOR_CONTACT_PHONE_NUM    = S.GENERATOR_CONTACT_PHONE_NUM,
                D.GENERATOR_CONTACT_PHONE_EXT    = S.GENERATOR_CONTACT_PHONE_EXT,
                D.GENERATOR_CONTACT_COMPANY_NAME = S.GENERATOR_CONTACT_COMPANY_NAME,
                D.EMERGENCY_PHONE_NUM            = S.EMERGENCY_PHONE_NUM,
                D.EMERGENCY_PHONE_EXT            = S.EMERGENCY_PHONE_EXT,
                D.GENERATOR_PRINTED_NAME         = S.GENERATOR_PRINTED_NAME,
                D.DES_FAC_ID                     = S.DES_FAC_ID,
                D.DES_FAC_NAME                   = S.DES_FAC_NAME,
                D.DES_FAC_MAIL_STREET_NUM        = S.DES_FAC_MAIL_STREET_NUM,
                D.DES_FAC_MAIL_CITY              = S.DES_FAC_MAIL_CITY,
                D.DES_FAC_MAIL_CTRY              = S.DES_FAC_MAIL_CTRY,
                D.DES_FAC_MAIL_STA               = S.DES_FAC_MAIL_STA,
                D.DES_FAC_MAIL_ZIP               = S.DES_FAC_MAIL_ZIP,
                D.DES_FAC_LOC_STREET_NUM         = S.DES_FAC_LOC_STREET_NUM,
                D.DES_FAC_LOC_CITY               = S.DES_FAC_LOC_CITY,
                D.DES_FAC_LOC_STA                = S.DES_FAC_LOC_STA,
                D.DES_FAC_LOC_ZIP                = S.DES_FAC_LOC_ZIP,
                D.DES_FAC_CONTACT_PHONE_NUM      = S.DES_FAC_CONTACT_PHONE_NUM,
                D.DES_FAC_CONTACT_PHONE_EXT      = S.DES_FAC_CONTACT_PHONE_EXT,
                D.DES_FAC_CONTACT_EMAIL          = S.DES_FAC_CONTACT_EMAIL,
                D.DES_FAC_CONTACT_COMPANY_NAME   = S.DES_FAC_CONTACT_COMPANY_NAME,
                D.DES_FAC_PRINTED_NAME           = S.DES_FAC_PRINTED_NAME,
                D.DES_FAC_ESIG_FIRST_NAME        = S.DES_FAC_ESIG_FIRST_NAME,
                D.DES_FAC_ESIG_LAST_NAME         = S.DES_FAC_ESIG_LAST_NAME,
                D.DES_FAC_ESIG_SIGNATURE_DATE    = S.DES_FAC_ESIG_SIGNATURE_DATE,
                D.ORIG_SUBM_TYPE                 = S.ORIG_SUBM_TYPE,
                D.COI_ONLY                       = S.COI_ONLY,
                D.BROKER_ID                      = S.BROKER_ID,
                D.LAST_EM_UPDT_DATE              = S.LAST_EM_UPDT_DATE,
                D.TRANSPORTER_ON_SITE            = S.TRANSPORTER_ON_SITE,
                D.ALT_FAC_PRINTED_NAME           = S.ALT_FAC_PRINTED_NAME,
                D.ALT_FAC_SIGNATURE_DATE         = S.ALT_FAC_SIGNATURE_DATE,
                D.ALT_FAC_ESIG_FIRST_NAME        = S.ALT_FAC_ESIG_FIRST_NAME,
                D.ALT_FAC_ESIG_LAST_NAME         = S.ALT_FAC_ESIG_LAST_NAME,
                D.ALT_FAC_ESIG_SIGNATURE_DATE    = S.ALT_FAC_ESIG_SIGNATURE_DATE,
                D.ALT_FAC_ID                     = S.ALT_FAC_ID,
                D.ALT_FAC_NAME                   = S.ALT_FAC_NAME,
                D.ALT_FAC_MAIL_STREET_NUM        = S.ALT_FAC_MAIL_STREET_NUM,
                D.ALT_FAC_MAIL_CITY              = S.ALT_FAC_MAIL_CITY,
                D.ALT_FAC_MAIL_STA               = S.ALT_FAC_MAIL_STA,
                D.ALT_FAC_MAIL_ZIP               = S.ALT_FAC_MAIL_ZIP,
                D.ALT_FAC_LOC_STREET_NUM         = S.ALT_FAC_LOC_STREET_NUM,
                D.ALT_FAC_LOC_STREET_1           = S.ALT_FAC_LOC_STREET_1,
                D.ALT_FAC_LOC_STREET_2           = S.ALT_FAC_LOC_STREET_2,
                D.ALT_FAC_LOC_CITY               = S.ALT_FAC_LOC_CITY,
                D.ALT_FAC_LOC_STA                = S.ALT_FAC_LOC_STA,
                D.ALT_FAC_LOC_ZIP                = S.ALT_FAC_LOC_ZIP,
                D.ALT_FAC_CONTACT_FIRST_NAME     = S.ALT_FAC_CONTACT_FIRST_NAME,
                D.ALT_FAC_CONTACT_LAST_NAME      = S.ALT_FAC_CONTACT_LAST_NAME,
                D.ALT_FAC_CONTACT_PHONE_NO       = S.ALT_FAC_CONTACT_PHONE_NO,
                D.ALT_FAC_CONTACT_PHONE_EXT      = S.ALT_FAC_CONTACT_PHONE_EXT,
                D.ALT_FAC_CONTACT_EMAIL          = S.ALT_FAC_CONTACT_EMAIL,
                D.ALT_FAC_CONTACT_COMPANY_NAME   = S.ALT_FAC_CONTACT_COMPANY_NAME,
                D.ALT_FAC_REGISTERED             = S.ALT_FAC_REGISTERED,
                D.ALT_FAC_MODIFIED               = S.ALT_FAC_MODIFIED,
                D.FOREIGN_GENERATOR_NAME         = S.FOREIGN_GENERATOR_NAME,
                D.FOREIGN_GENERATOR_STREET       = S.FOREIGN_GENERATOR_STREET,
                D.FOREIGN_GENERATOR_CITY         = S.FOREIGN_GENERATOR_CITY,
                D.FOREIGN_GENERATOR_CTRY_CODE    = S.FOREIGN_GENERATOR_CTRY_CODE,
                D.FOREIGN_GENERATOR_POST_CODE    = S.FOREIGN_GENERATOR_POST_CODE,
                D.FOREIGN_GENERATOR_PROVINCE     = S.FOREIGN_GENERATOR_PROVINCE,
                D.PORT_OF_ENTRY_STA              = S.PORT_OF_ENTRY_STA
        when not matched then
            insert (EM_EMANIFEST_ID,
                    CREATED_DATE,
                    UPDATED_DATE,
                    MAN_TRACKING_NUM,
                    STATUS,
                    DES_FAC_MODIFIED,
                    SUBM_TYPE,
                    GENERATOR_MODIFIED,
                    ORIGIN_TYPE,
                    SHIPPED_DATE,
                    RECEIVED_DATE,
                    CERT_DATE,
                    REJ_IND,
                    DES_FAC_REGISTERED,
                    IMPORT,
                    GENERATOR_CONTACT_FIRST_NAME,
                    GENERATOR_CONTACT_LAST_NAME,
                    GENERATOR_REGISTERED,
                    REJECTION_TYPE,
                    ALTERNATE_DESIGNATED_FAC_TYPE,
                    GENERATOR_NAME,
                    DES_FAC_SIGNATURE_DATE,
                    GENERATOR_ESIG_SIGNATURE_DATE,
                    DES_FAC_LOC_STREET_1,
                    ALT_FAC_MAIL_STREET_2,
                    DES_FAC_CONTACT_FIRST_NAME,
                    DES_FAC_CONTACT_LAST_NAME,
                    GENERATOR_LOC_STREET_2,
                    GENERATOR_CONTACT_EMAIL,
                    DES_FAC_MAIL_STREET_1,
                    PORT_OF_ENTRY_CITY,
                    GENERATOR_MAIL_ZIP,
                    DES_FAC_MAIL_STREET_2,
                    GENERATOR_MAIL_STA,
                    FOREIGN_GENERATOR_CTRY_NAME,
                    GENERATOR_MAIL_CTRY,
                    GENERATOR_MAIL_STREET_1,
                    GENERATOR_MAIL_STREET_2,
                    MANIFEST_HANDLING_INSTR,
                    RESIDUE,
                    GENERATOR_ID,
                    GENERATOR_SIGNATURE_DATE,
                    DES_FAC_LOC_STREET_2,
                    ALT_FAC_MAIL_STREET_1,
                    GENERATOR_ESIG_FIRST_NAME,
                    GENERATOR_ESIG_LAST_NAME,
                    GENERATOR_LOC_STREET_1,
                    GENERATOR_MAIL_STREET_NUM,
                    GENERATOR_MAIL_CITY,
                    GENERATOR_LOC_STREET_NUM,
                    GENERATOR_LOC_CITY,
                    GENERATOR_LOC_STA,
                    GENERATOR_LOC_ZIP,
                    GENERATOR_CONTACT_PHONE_NUM,
                    GENERATOR_CONTACT_PHONE_EXT,
                    GENERATOR_CONTACT_COMPANY_NAME,
                    EMERGENCY_PHONE_NUM,
                    EMERGENCY_PHONE_EXT,
                    GENERATOR_PRINTED_NAME,
                    DES_FAC_ID,
                    DES_FAC_NAME,
                    DES_FAC_MAIL_STREET_NUM,
                    DES_FAC_MAIL_CITY,
                    DES_FAC_MAIL_CTRY,
                    DES_FAC_MAIL_STA,
                    DES_FAC_MAIL_ZIP,
                    DES_FAC_LOC_STREET_NUM,
                    DES_FAC_LOC_CITY,
                    DES_FAC_LOC_STA,
                    DES_FAC_LOC_ZIP,
                    DES_FAC_CONTACT_PHONE_NUM,
                    DES_FAC_CONTACT_PHONE_EXT,
                    DES_FAC_CONTACT_EMAIL,
                    DES_FAC_CONTACT_COMPANY_NAME,
                    DES_FAC_PRINTED_NAME,
                    DES_FAC_ESIG_FIRST_NAME,
                    DES_FAC_ESIG_LAST_NAME,
                    DES_FAC_ESIG_SIGNATURE_DATE,
                    ORIG_SUBM_TYPE,
                    COI_ONLY,
                    BROKER_ID,
                    LAST_EM_UPDT_DATE,
                    TRANSPORTER_ON_SITE,
                    ALT_FAC_PRINTED_NAME,
                    ALT_FAC_SIGNATURE_DATE,
                    ALT_FAC_ESIG_FIRST_NAME,
                    ALT_FAC_ESIG_LAST_NAME,
                    ALT_FAC_ESIG_SIGNATURE_DATE,
                    ALT_FAC_ID,
                    ALT_FAC_NAME,
                    ALT_FAC_MAIL_STREET_NUM,
                    ALT_FAC_MAIL_CITY,
                    ALT_FAC_MAIL_STA,
                    ALT_FAC_MAIL_ZIP,
                    ALT_FAC_LOC_STREET_NUM,
                    ALT_FAC_LOC_STREET_1,
                    ALT_FAC_LOC_STREET_2,
                    ALT_FAC_LOC_CITY,
                    ALT_FAC_LOC_STA,
                    ALT_FAC_LOC_ZIP,
                    ALT_FAC_CONTACT_FIRST_NAME,
                    ALT_FAC_CONTACT_LAST_NAME,
                    ALT_FAC_CONTACT_PHONE_NO,
                    ALT_FAC_CONTACT_PHONE_EXT,
                    ALT_FAC_CONTACT_EMAIL,
                    ALT_FAC_CONTACT_COMPANY_NAME,
                    ALT_FAC_REGISTERED,
                    ALT_FAC_MODIFIED,
                    FOREIGN_GENERATOR_NAME,
                    FOREIGN_GENERATOR_STREET,
                    FOREIGN_GENERATOR_CITY,
                    FOREIGN_GENERATOR_CTRY_CODE,
                    FOREIGN_GENERATOR_POST_CODE,
                    FOREIGN_GENERATOR_PROVINCE,
                    PORT_OF_ENTRY_STA)
            values (SEQ_RCRA_EM_EMANIFEST.NEXTVAL,
                    S.CREATED_DATE,
                    S.UPDATED_DATE,
                    S.MAN_TRACKING_NUM,
                    S.STATUS,
                    S.DES_FAC_MODIFIED,
                    S.SUBM_TYPE,
                    S.GENERATOR_MODIFIED,
                    S.ORIGIN_TYPE,
                    S.SHIPPED_DATE,
                    S.RECEIVED_DATE,
                    S.CERT_DATE,
                    S.REJ_IND,
                    S.DES_FAC_REGISTERED,
                    S.IMPORT,
                    S.GENERATOR_CONTACT_FIRST_NAME,
                    S.GENERATOR_CONTACT_LAST_NAME,
                    S.GENERATOR_REGISTERED,
                    S.REJECTION_TYPE,
                    S.ALTERNATE_DESIGNATED_FAC_TYPE,
                    S.GENERATOR_NAME,
                    S.DES_FAC_SIGNATURE_DATE,
                    S.GENERATOR_ESIG_SIGNATURE_DATE,
                    S.DES_FAC_LOC_STREET_1,
                    S.ALT_FAC_MAIL_STREET_2,
                    S.DES_FAC_CONTACT_FIRST_NAME,
                    S.DES_FAC_CONTACT_LAST_NAME,
                    S.GENERATOR_LOC_STREET_2,
                    S.GENERATOR_CONTACT_EMAIL,
                    S.DES_FAC_MAIL_STREET_1,
                    S.PORT_OF_ENTRY_CITY,
                    S.GENERATOR_MAIL_ZIP,
                    S.DES_FAC_MAIL_STREET_2,
                    S.GENERATOR_MAIL_STA,
                    S.FOREIGN_GENERATOR_CTRY_NAME,
                    S.GENERATOR_MAIL_CTRY,
                    S.GENERATOR_MAIL_STREET_1,
                    S.GENERATOR_MAIL_STREET_2,
                    S.MANIFEST_HANDLING_INSTR,
                    S.RESIDUE,
                    S.GENERATOR_ID,
                    S.GENERATOR_SIGNATURE_DATE,
                    S.DES_FAC_LOC_STREET_2,
                    S.ALT_FAC_MAIL_STREET_1,
                    S.GENERATOR_ESIG_FIRST_NAME,
                    S.GENERATOR_ESIG_LAST_NAME,
                    S.GENERATOR_LOC_STREET_1,
                    S.GENERATOR_MAIL_STREET_NUM,
                    S.GENERATOR_MAIL_CITY,
                    S.GENERATOR_LOC_STREET_NUM,
                    S.GENERATOR_LOC_CITY,
                    S.GENERATOR_LOC_STA,
                    S.GENERATOR_LOC_ZIP,
                    S.GENERATOR_CONTACT_PHONE_NUM,
                    S.GENERATOR_CONTACT_PHONE_EXT,
                    S.GENERATOR_CONTACT_COMPANY_NAME,
                    S.EMERGENCY_PHONE_NUM,
                    S.EMERGENCY_PHONE_EXT,
                    S.GENERATOR_PRINTED_NAME,
                    S.DES_FAC_ID,
                    S.DES_FAC_NAME,
                    S.DES_FAC_MAIL_STREET_NUM,
                    S.DES_FAC_MAIL_CITY,
                    S.DES_FAC_MAIL_CTRY,
                    S.DES_FAC_MAIL_STA,
                    S.DES_FAC_MAIL_ZIP,
                    S.DES_FAC_LOC_STREET_NUM,
                    S.DES_FAC_LOC_CITY,
                    S.DES_FAC_LOC_STA,
                    S.DES_FAC_LOC_ZIP,
                    S.DES_FAC_CONTACT_PHONE_NUM,
                    S.DES_FAC_CONTACT_PHONE_EXT,
                    S.DES_FAC_CONTACT_EMAIL,
                    S.DES_FAC_CONTACT_COMPANY_NAME,
                    S.DES_FAC_PRINTED_NAME,
                    S.DES_FAC_ESIG_FIRST_NAME,
                    S.DES_FAC_ESIG_LAST_NAME,
                    S.DES_FAC_ESIG_SIGNATURE_DATE,
                    S.ORIG_SUBM_TYPE,
                    S.COI_ONLY,
                    S.BROKER_ID,
                    S.LAST_EM_UPDT_DATE,
                    S.TRANSPORTER_ON_SITE,
                    S.ALT_FAC_PRINTED_NAME,
                    S.ALT_FAC_SIGNATURE_DATE,
                    S.ALT_FAC_ESIG_FIRST_NAME,
                    S.ALT_FAC_ESIG_LAST_NAME,
                    S.ALT_FAC_ESIG_SIGNATURE_DATE,
                    S.ALT_FAC_ID,
                    S.ALT_FAC_NAME,
                    S.ALT_FAC_MAIL_STREET_NUM,
                    S.ALT_FAC_MAIL_CITY,
                    S.ALT_FAC_MAIL_STA,
                    S.ALT_FAC_MAIL_ZIP,
                    S.ALT_FAC_LOC_STREET_NUM,
                    S.ALT_FAC_LOC_STREET_1,
                    S.ALT_FAC_LOC_STREET_2,
                    S.ALT_FAC_LOC_CITY,
                    S.ALT_FAC_LOC_STA,
                    S.ALT_FAC_LOC_ZIP,
                    S.ALT_FAC_CONTACT_FIRST_NAME,
                    S.ALT_FAC_CONTACT_LAST_NAME,
                    S.ALT_FAC_CONTACT_PHONE_NO,
                    S.ALT_FAC_CONTACT_PHONE_EXT,
                    S.ALT_FAC_CONTACT_EMAIL,
                    S.ALT_FAC_CONTACT_COMPANY_NAME,
                    S.ALT_FAC_REGISTERED,
                    S.ALT_FAC_MODIFIED,
                    S.FOREIGN_GENERATOR_NAME,
                    S.FOREIGN_GENERATOR_STREET,
                    S.FOREIGN_GENERATOR_CITY,
                    S.FOREIGN_GENERATOR_CTRY_CODE,
                    S.FOREIGN_GENERATOR_POST_CODE,
                    S.FOREIGN_GENERATOR_PROVINCE,
                    S.PORT_OF_ENTRY_STA);
    END;

    PROCEDURE EM_MERGE_EMANIFEST_COMMENT AS
    BEGIN
        delete
        from RCRA_EM_EMANIFEST_COMMENT
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_EMANIFEST_COMMENT (EM_EMANIFEST_COMMENT_ID, EM_EMANIFEST_ID, CMNT_LABEL, CMNT_DESC)
        select SEQ_RCRA_EM_EMANIFEST_COMMENT.NEXTVAL,
               WH_EM_EMANIFEST_ID,
               CMNT_LABEL,
               CMNT_DESC
        from ETL_EM_EMANIFEST_COMMENT_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE AS
    BEGIN
        delete
        from RCRA_EM_WASTE
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_WASTE (EM_WASTE_ID, EM_EMANIFEST_ID, NON_HAZ_WASTE_DESC, DOT_HAZRD, LINE_NUM,
                                   BR_MIXED_RADIOACTIVE_WASTE, DOT_PRINTED_INFO, CONTAINER_NUM, QNTY_VAL,
                                   QTY_UNIT_OF_MEAS_CODE, QTY_UNIT_OF_MEAS_DESC, BR_DENSITY, BR_DENSITY_UOM_CODE,
                                   BR_DENSITY_UOM_DESC, BR_FORM_CODE, BR_FORM_CODE_DESC, BR_SRC_CODE,
                                   BR_SRC_CODE_DESC, BR_WASTE_MIN_CODE, BR_WASTE_MIN_DESC, QNTY_DISCREPANCY,
                                   WASTE_TYPE_DISCREPANCY, WASTE_RESIDUE_COMM, PCB, MANAGEMENT_METH_CODE,
                                   MANAGEMENT_METH_DESC, HANDLING_INSTRUCTIONS, DOT_ID_NUM_DESC, CONTAINER_TYPE_CODE,
                                   CONTAINER_TYPE_DESC, DISCREPANCY_COMM, WASTE_RESIDUE, CNST_NUM, EPA_WASTE,
                                   COI_ONLY, QNTY_ACUTE_KG, QNTY_ACUTE_TONS, QNTY_KG, QNTY_NON_ACUTE_KG,
                                   QNTY_NON_ACUTE_TONS, QNTY_TONS)
        select SEQ_RCRA_EM_EMANIFEST.NEXTVAL,
               WH_EM_EMANIFEST_ID,
               NON_HAZ_WASTE_DESC,
               DOT_HAZRD,
               LINE_NUM,
               BR_MIXED_RADIOACTIVE_WASTE,
               DOT_PRINTED_INFO,
               CONTAINER_NUM,
               QNTY_VAL,
               QTY_UNIT_OF_MEAS_CODE,
               QTY_UNIT_OF_MEAS_DESC,
               BR_DENSITY,
               BR_DENSITY_UOM_CODE,
               BR_DENSITY_UOM_DESC,
               BR_FORM_CODE,
               BR_FORM_CODE_DESC,
               BR_SRC_CODE,
               BR_SRC_CODE_DESC,
               BR_WASTE_MIN_CODE,
               BR_WASTE_MIN_DESC,
               QNTY_DISCREPANCY,
               WASTE_TYPE_DISCREPANCY,
               WASTE_RESIDUE_COMM,
               PCB,
               MANAGEMENT_METH_CODE,
               MANAGEMENT_METH_DESC,
               HANDLING_INSTRUCTIONS,
               DOT_ID_NUM_DESC,
               CONTAINER_TYPE_CODE,
               CONTAINER_TYPE_DESC,
               DISCREPANCY_COMM,
               WASTE_RESIDUE,
               CNST_NUM,
               EPA_WASTE,
               COI_ONLY,
               QNTY_ACUTE_KG,
               QNTY_ACUTE_TONS,
               QNTY_KG,
               QNTY_NON_ACUTE_KG,
               QNTY_NON_ACUTE_TONS,
               QNTY_TONS
        from ETL_EM_WASTE_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_FED_WASTE_CODE_DESC AS
    BEGIN
        delete
        from RCRA_EM_FED_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_FED_WASTE_CODE_DESC (EM_FED_WASTE_CODE_DESC_ID, EM_WASTE_ID, FED_MANIFEST_WASTE_CODE,
                                                 MANIFEST_WASTE_DESC, COI_IND)
        select SEQ_EM_FED_WASTE_CODE_DESC_ID.nextval,
               WH_EM_WASTE_ID,
               FED_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC,
               COI_IND
        from ETL_EM_FED_WASTE_CODE_DESC_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_STATE_WASTE_CODE_DESC AS
    BEGIN
        delete
        from RCRA_EM_STATE_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_STATE_WASTE_CODE_DESC (EM_STATE_WASTE_CODE_DESC_ID, EM_WASTE_ID, STA_MANIFEST_WASTE_CODE,
                                                   MANIFEST_WASTE_DESC)
        select SEQ_EM_STATE_WASTE_CODE_DESC.nextval,
               WH_EM_WASTE_ID,
               STA_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC
        from ETL_EM_STATE_WASTE_CODE_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_CD_TRANS AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_CD_TRANS
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_CD_TRANS (EM_WASTE_CD_TRANS_ID, EM_WASTE_ID, WASTE_CODE)
        SELECT SEQ_RCRA_EM_WASTE_CD_TRANS.NEXTVAL, WH_EM_WASTE_ID, WASTE_CODE
        FROM ETL_EM_WASTE_CD_TRANS_VW
        WHERE EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_COMMENT AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_COMMENT
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_COMMENT (EM_WASTE_COMMENT_ID, EM_WASTE_ID, CMNT_DESC, CMNT_LABEL)
        SELECT SEQ_RCRA_EM_WASTE_COMMENT.NEXTVAL, WH_EM_WASTE_ID, CMNT_DESC, CMNT_LABEL
        FROM ETL_EM_WASTE_COMMENT_VW
        WHERE EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where x.EM_WASTE_ID is not null --
        );
    END;

    PROCEDURE EM_MERGE_WASTE_PCB AS
    BEGIN
        DELETE
        FROM RCRA_EM_WASTE_PCB
        WHERE EM_WASTE_ID IN (select WH_EM_WASTE_ID
                              from ETL_EM_WASTE_VW
                              where WH_EM_WASTE_ID is not null);
        INSERT INTO RCRA_EM_WASTE_PCB (EM_WASTE_PCB_ID, EM_WASTE_ID, PCB_LOAD_TYPE_CODE, PCB_ARTICLE_CONT_ID,
                                       PCB_REMOVAL_DATE,
                                       PCB_WEIGHT, PCB_WASTE_TYPE, PCB_BULK_IDENTITY, LOAD_TYPE_DESC)
        SELECT SEQ_RCRA_EM_WASTE_PCB.NEXTVAL,
               WH_EM_WASTE_ID,
               PCB_LOAD_TYPE_CODE,
               PCB_ARTICLE_CONT_ID,
               PCB_REMOVAL_DATE,
               PCB_WEIGHT,
               PCB_WASTE_TYPE,
               PCB_BULK_IDENTITY,
               LOAD_TYPE_DESC
        FROM ETL_EM_WASTE_PCB_VW
        WHERE EM_WASTE_ID IN (select x.EM_WASTE_ID
                              from ETL_EM_WASTE_VW x
                              where x.EM_WASTE_ID is not null);
    END;

    PROCEDURE EM_MERGE_TRANSPORTER AS
    BEGIN
        delete
        from RCRA_EM_TRANSPORTER
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.WH_EM_EMANIFEST_ID is not null --
        );

        insert into RCRA_EM_TRANSPORTER (EM_TRANSPORTER_ID, EM_EMANIFEST_ID, TRANSPORTER_ID, TRANSPORTER_NAME,
                                         TRANSPORTER_PRINTED_NAME,
                                         TRANSPORTER_SIGNATURE_DATE, TRANSPORTER_ESIG_FIRST_NAME,
                                         TRANSPORTER_ESIG_LAST_NAME, TRANS_ESIG_SIGNATURE_DATE, TRANSPORTER_LINE_NUM,
                                         TRANSPORTER_REGISTERED)
        select SEQ_RCRA_EM_TRANSPORTER.nextval,
               WH_EM_EMANIFEST_ID,
               TRANSPORTER_ID,
               TRANSPORTER_NAME,
               TRANSPORTER_PRINTED_NAME,
               TRANSPORTER_SIGNATURE_DATE,
               TRANSPORTER_ESIG_FIRST_NAME,
               TRANSPORTER_ESIG_LAST_NAME,
               TRANS_ESIG_SIGNATURE_DATE,
               TRANSPORTER_LINE_NUM,
               TRANSPORTER_REGISTERED
        from ETL_EM_TRANSPORTER_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_EMANIFEST_ID is not null --
        );
    END;

-- CH

    PROCEDURE CH_LOG_HANDLER AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CH');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       RU_REPORT_UNIV_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_RU_REPORT_UNIV_VW;
    END;

    PROCEDURE CH_MERGE_REPORT_UNIV AS
    BEGIN
        MERGE INTO RCRA_RU_REPORT_UNIV D
        USING (SELECT *
               FROM ETL_RU_REPORT_UNIV_VW) S
        ON (D.RU_REPORT_UNIV_ID = S.WH_RU_REPORT_UNIV_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.HANDLER_ID                     = S.HANDLER_ID,
                D.ACTIVITY_LOCATION              = S.ACTIVITY_LOCATION,
                D.SOURCE_TYPE                    = S.SOURCE_TYPE,
                D.SEQ_NUMBER                     = S.SEQ_NUMBER,
                D.RECEIVE_DATE                   = S.RECEIVE_DATE,
                D.HANDLER_NAME                   = S.HANDLER_NAME,
                D.NON_NOTIFIER_IND               = S.NON_NOTIFIER_IND,
                D.ACCESSIBILITY                  = S.ACCESSIBILITY,
                D.REPORT_CYCLE                   = S.REPORT_CYCLE,
                D.REGION                         = S.REGION,
                D.STATE                          = S.STATE,
                D.EXTRACT_FLAG                   = S.EXTRACT_FLAG,
                D.ACTIVE_SITE                    = S.ACTIVE_SITE,
                D.COUNTY_CODE                    = S.COUNTY_CODE,
                D.COUNTY_NAME                    = S.COUNTY_NAME,
                D.LOCATION_STREET_NUMBER         = S.LOCATION_STREET_NUMBER,
                D.LOCATION_STREET1               = S.LOCATION_STREET1,
                D.LOCATION_STREET2               = S.LOCATION_STREET2,
                D.LOCATION_CITY                  = S.LOCATION_CITY,
                D.LOCATION_STATE                 = S.LOCATION_STATE,
                D.LOCATION_COUNTRY               = S.LOCATION_COUNTRY,
                D.LOCATION_ZIP                   = S.LOCATION_ZIP,
                D.MAIL_STREET_NUMBER             = S.MAIL_STREET_NUMBER,
                D.MAIL_STREET1                   = S.MAIL_STREET1,
                D.MAIL_STREET2                   = S.MAIL_STREET2,
                D.MAIL_CITY                      = S.MAIL_CITY,
                D.MAIL_STATE                     = S.MAIL_STATE,
                D.MAIL_COUNTRY                   = S.MAIL_COUNTRY,
                D.MAIL_ZIP                       = S.MAIL_ZIP,
                D.CONTACT_STREET_NUMBER          = S.CONTACT_STREET_NUMBER,
                D.CONTACT_STREET1                = S.CONTACT_STREET1,
                D.CONTACT_STREET2                = S.CONTACT_STREET2,
                D.CONTACT_CITY                   = S.CONTACT_CITY,
                D.CONTACT_STATE                  = S.CONTACT_STATE,
                D.CONTACT_COUNTRY                = S.CONTACT_COUNTRY,
                D.CONTACT_ZIP                    = S.CONTACT_ZIP,
                D.CONTACT_NAME                   = S.CONTACT_NAME,
                D.CONTACT_PHONE                  = S.CONTACT_PHONE,
                D.CONTACT_FAX                    = S.CONTACT_FAX,
                D.CONTACT_EMAIL                  = S.CONTACT_EMAIL,
                D.CONTACT_TITLE                  = S.CONTACT_TITLE,
                D.OWNER_NAME                     = S.OWNER_NAME,
                D.OWNER_TYPE                     = S.OWNER_TYPE,
                D.OWNER_SEQ_NUM                  = S.OWNER_SEQ_NUM,
                D.OPER_NAME                      = S.OPER_NAME,
                D.OPER_TYPE                      = S.OPER_TYPE,
                D.OPER_SEQ_NUM                   = S.OPER_SEQ_NUM,
                D.NAIC1_CODE                     = S.NAIC1_CODE,
                D.NAIC2_CODE                     = S.NAIC2_CODE,
                D.NAIC3_CODE                     = S.NAIC3_CODE,
                D.NAIC4_CODE                     = S.NAIC4_CODE,
                D.IN_HANDLER_UNIVERSE            = S.IN_HANDLER_UNIVERSE,
                D.IN_A_UNIVERSE                  = S.IN_A_UNIVERSE,
                D.FED_WASTE_GENERATOR_OWNER      = S.FED_WASTE_GENERATOR_OWNER,
                D.FED_WASTE_GENERATOR            = S.FED_WASTE_GENERATOR,
                D.STATE_WASTE_GENERATOR_OWNER    = S.STATE_WASTE_GENERATOR_OWNER,
                D.STATE_WASTE_GENERATOR          = S.STATE_WASTE_GENERATOR,
                D.GEN_STATUS                     = S.GEN_STATUS,
                D.UNIV_WASTE                     = S.UNIV_WASTE,
                D.LAND_TYPE                      = S.LAND_TYPE,
                D.STATE_DISTRICT_OWNER           = S.STATE_DISTRICT_OWNER,
                D.STATE_DISTRICT                 = S.STATE_DISTRICT,
                D.SHORT_TERM_GEN_IND             = S.SHORT_TERM_GEN_IND,
                D.IMPORTER_ACTIVITY              = S.IMPORTER_ACTIVITY,
                D.MIXED_WASTE_GENERATOR          = S.MIXED_WASTE_GENERATOR,
                D.TRANSPORTER_ACTIVITY           = S.TRANSPORTER_ACTIVITY,
                D.TRANSFER_FACILITY_IND          = S.TRANSFER_FACILITY_IND,
                D.RECYCLER_ACTIVITY              = S.RECYCLER_ACTIVITY,
                D.ONSITE_BURNER_EXEMPTION        = S.ONSITE_BURNER_EXEMPTION,
                D.FURNACE_EXEMPTION              = S.FURNACE_EXEMPTION,
                D.UNDERGROUND_INJECTION_ACTIVITY = S.UNDERGROUND_INJECTION_ACTIVITY,
                D.UNIVERSAL_WASTE_DEST_FACILITY  = S.UNIVERSAL_WASTE_DEST_FACILITY,
                D.OFFSITE_WASTE_RECEIPT          = S.OFFSITE_WASTE_RECEIPT,
                D.USED_OIL                       = S.USED_OIL,
                D.FEDERAL_UNIVERSAL_WASTE        = S.FEDERAL_UNIVERSAL_WASTE,
                D.AS_FEDERAL_REGULATED_TSDF      = S.AS_FEDERAL_REGULATED_TSDF,
                D.AS_CONVERTED_TSDF              = S.AS_CONVERTED_TSDF,
                D.AS_STATE_REGULATED_TSDF        = S.AS_STATE_REGULATED_TSDF,
                D.FEDERAL_IND                    = S.FEDERAL_IND,
                D.HSM                            = S.HSM,
                D.SUBPART_K                      = S.SUBPART_K,
                D.COMMERCIAL_TSD                 = S.COMMERCIAL_TSD,
                D.TSD                            = S.TSD,
                D.GPRA_PERMIT                    = S.GPRA_PERMIT,
                D.GPRA_RENEWAL                   = S.GPRA_RENEWAL,
                D.PERMIT_RENEWAL_WRKLD           = S.PERMIT_RENEWAL_WRKLD,
                D.PERM_WRKLD                     = S.PERM_WRKLD,
                D.PERM_PROG                      = S.PERM_PROG,
                D.PC_WRKLD                       = S.PC_WRKLD,
                D.CLOS_WRKLD                     = S.CLOS_WRKLD,
                D.GPRACA                         = S.GPRACA,
                D.CA_WRKLD                       = S.CA_WRKLD,
                D.SUBJ_CA                        = S.SUBJ_CA,
                D.SUBJ_CA_NON_TSD                = S.SUBJ_CA_NON_TSD,
                D.SUBJ_CA_TSD_3004               = S.SUBJ_CA_TSD_3004,
                D.SUBJ_CA_DISCRETION             = S.SUBJ_CA_DISCRETION,
                D.NCAPS                          = S.NCAPS,
                D.EC_IND                         = S.EC_IND,
                D.IC_IND                         = S.IC_IND,
                D.CA_725_IND                     = S.CA_725_IND,
                D.CA_750_IND                     = S.CA_750_IND,
                D.OPERATING_TSDF                 = S.OPERATING_TSDF,
                D.FULL_ENFORCEMENT               = S.FULL_ENFORCEMENT,
                D.SNC                            = S.SNC,
                D.BOY_SNC                        = S.BOY_SNC,
                D.BOY_STATE_UNADDRESSED_SNC      = S.BOY_STATE_UNADDRESSED_SNC,
                D.STATE_UNADDRESSED              = S.STATE_UNADDRESSED,
                D.STATE_ADDRESSED                = S.STATE_ADDRESSED,
                D.BOY_STATE_ADDRESSED            = S.BOY_STATE_ADDRESSED,
                D.STATE_SNC_WITH_COMP_SCHED      = S.STATE_SNC_WITH_COMP_SCHED,
                D.BOY_STATE_SNC_WITH_COMP_SCHED  = S.BOY_STATE_SNC_WITH_COMP_SCHED,
                D.EPA_UNADDRESSED                = S.EPA_UNADDRESSED,
                D.BOY_EPA_UNADDRESSED            = S.BOY_EPA_UNADDRESSED,
                D.EPA_ADDRESSED                  = S.EPA_ADDRESSED,
                D.BOY_EPA_ADDRESSED              = S.BOY_EPA_ADDRESSED,
                D.EPA_SNC_WITH_COMP_SCHED        = S.EPA_SNC_WITH_COMP_SCHED,
                D.BOY_EPA_SNC_WITH_COMP_SCHED    = S.BOY_EPA_SNC_WITH_COMP_SCHED,
                D.FA_REQUIRED                    = S.FA_REQUIRED,
                D.HHANDLER_LAST_CHANGE_DATE      = S.HHANDLER_LAST_CHANGE_DATE,
                D.PUBLIC_NOTES                   = S.PUBLIC_NOTES,
                D.NOTES                          = S.NOTES,
                D.RECOGNIZED_TRADER_IMPORTER_IND = S.RECOGNIZED_TRADER_IMPORTER_IND,
                D.RECOGNIZED_TRADER_EXPORTER_IND = S.RECOGNIZED_TRADER_EXPORTER_IND,
                D.SLAB_IMPORTER_IND              = S.SLAB_IMPORTER_IND,
                D.SLAB_EXPORTER_IND              = S.SLAB_EXPORTER_IND,
                D.RECYCLER_NON_STORAGE_IND       = S.RECYCLER_NON_STORAGE_IND,
                D.MANIFEST_BROKER_IND            = S.MANIFEST_BROKER_IND,
                D.SUBPART_P_IND                  = S.SUBPART_P_IND,
                D.LOCATION_LATITUDE              = S.LOCATION_LATITUDE,
                D.LOCATION_LONGITUDE             = S.LOCATION_LONGITUDE,
                D.LOCATION_GIS_PRIM              = S.LOCATION_GIS_PRIM,
                D.LOCATION_GIS_ORIG              = S.LOCATION_GIS_ORIG
            WHERE DECODE(D.RU_REPORT_UNIV_ID, S.RU_REPORT_UNIV_ID, 0, 1) = 1
               OR DECODE(D.HANDLER_ID, S.HANDLER_ID, 0, 1) = 1
               OR DECODE(D.ACTIVITY_LOCATION, S.ACTIVITY_LOCATION, 0, 1) = 1
               OR DECODE(D.SOURCE_TYPE, S.SOURCE_TYPE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.RECEIVE_DATE, S.RECEIVE_DATE, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER_IND, S.NON_NOTIFIER_IND, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY, S.ACCESSIBILITY, 0, 1) = 1
               OR DECODE(D.REPORT_CYCLE, S.REPORT_CYCLE, 0, 1) = 1
               OR DECODE(D.REGION, S.REGION, 0, 1) = 1
               OR DECODE(D.STATE, S.STATE, 0, 1) = 1
               OR DECODE(D.EXTRACT_FLAG, S.EXTRACT_FLAG, 0, 1) = 1
               OR DECODE(D.ACTIVE_SITE, S.ACTIVE_SITE, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE, S.COUNTY_CODE, 0, 1) = 1
               OR DECODE(D.COUNTY_NAME, S.COUNTY_NAME, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET_NUMBER, S.LOCATION_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET1, S.LOCATION_STREET1, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET2, S.LOCATION_STREET2, 0, 1) = 1
               OR DECODE(D.LOCATION_CITY, S.LOCATION_CITY, 0, 1) = 1
               OR DECODE(D.LOCATION_STATE, S.LOCATION_STATE, 0, 1) = 1
               OR DECODE(D.LOCATION_COUNTRY, S.LOCATION_COUNTRY, 0, 1) = 1
               OR DECODE(D.LOCATION_ZIP, S.LOCATION_ZIP, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_COUNTRY, S.MAIL_COUNTRY, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET_NUMBER, S.CONTACT_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET1, S.CONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET2, S.CONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.CONTACT_CITY, S.CONTACT_CITY, 0, 1) = 1
               OR DECODE(D.CONTACT_STATE, S.CONTACT_STATE, 0, 1) = 1
               OR DECODE(D.CONTACT_COUNTRY, S.CONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.CONTACT_ZIP, S.CONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_NAME, S.CONTACT_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL, S.CONTACT_EMAIL, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.OWNER_NAME, S.OWNER_NAME, 0, 1) = 1
               OR DECODE(D.OWNER_TYPE, S.OWNER_TYPE, 0, 1) = 1
               OR DECODE(D.OWNER_SEQ_NUM, S.OWNER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.OPER_NAME, S.OPER_NAME, 0, 1) = 1
               OR DECODE(D.OPER_TYPE, S.OPER_TYPE, 0, 1) = 1
               OR DECODE(D.OPER_SEQ_NUM, S.OPER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.NAIC1_CODE, S.NAIC1_CODE, 0, 1) = 1
               OR DECODE(D.NAIC2_CODE, S.NAIC2_CODE, 0, 1) = 1
               OR DECODE(D.NAIC3_CODE, S.NAIC3_CODE, 0, 1) = 1
               OR DECODE(D.NAIC4_CODE, S.NAIC4_CODE, 0, 1) = 1
               OR DECODE(D.IN_HANDLER_UNIVERSE, S.IN_HANDLER_UNIVERSE, 0, 1) = 1
               OR DECODE(D.IN_A_UNIVERSE, S.IN_A_UNIVERSE, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR_OWNER, S.FED_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR, S.FED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR_OWNER, S.STATE_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR, S.STATE_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.GEN_STATUS, S.GEN_STATUS, 0, 1) = 1
               OR DECODE(D.UNIV_WASTE, S.UNIV_WASTE, 0, 1) = 1
               OR DECODE(D.LAND_TYPE, S.LAND_TYPE, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_OWNER, S.STATE_DISTRICT_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT, S.STATE_DISTRICT, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_GEN_IND, S.SHORT_TERM_GEN_IND, 0, 1) = 1
               OR DECODE(D.IMPORTER_ACTIVITY, S.IMPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.MIXED_WASTE_GENERATOR, S.MIXED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.TRANSPORTER_ACTIVITY, S.TRANSPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TRANSFER_FACILITY_IND, S.TRANSFER_FACILITY_IND, 0, 1) = 1
               OR DECODE(D.RECYCLER_ACTIVITY, S.RECYCLER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.ONSITE_BURNER_EXEMPTION, S.ONSITE_BURNER_EXEMPTION, 0, 1) = 1
               OR DECODE(D.FURNACE_EXEMPTION, S.FURNACE_EXEMPTION, 0, 1) = 1
               OR DECODE(D.UNDERGROUND_INJECTION_ACTIVITY, S.UNDERGROUND_INJECTION_ACTIVITY, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_DEST_FACILITY, S.UNIVERSAL_WASTE_DEST_FACILITY, 0, 1) = 1
               OR DECODE(D.OFFSITE_WASTE_RECEIPT, S.OFFSITE_WASTE_RECEIPT, 0, 1) = 1
               OR DECODE(D.USED_OIL, S.USED_OIL, 0, 1) = 1
               OR DECODE(D.FEDERAL_UNIVERSAL_WASTE, S.FEDERAL_UNIVERSAL_WASTE, 0, 1) = 1
               OR DECODE(D.AS_FEDERAL_REGULATED_TSDF, S.AS_FEDERAL_REGULATED_TSDF, 0, 1) = 1
               OR DECODE(D.AS_CONVERTED_TSDF, S.AS_CONVERTED_TSDF, 0, 1) = 1
               OR DECODE(D.AS_STATE_REGULATED_TSDF, S.AS_STATE_REGULATED_TSDF, 0, 1) = 1
               OR DECODE(D.FEDERAL_IND, S.FEDERAL_IND, 0, 1) = 1
               OR DECODE(D.HSM, S.HSM, 0, 1) = 1
               OR DECODE(D.SUBPART_K, S.SUBPART_K, 0, 1) = 1
               OR DECODE(D.COMMERCIAL_TSD, S.COMMERCIAL_TSD, 0, 1) = 1
               OR DECODE(D.TSD, S.TSD, 0, 1) = 1
               OR DECODE(D.GPRA_PERMIT, S.GPRA_PERMIT, 0, 1) = 1
               OR DECODE(D.GPRA_RENEWAL, S.GPRA_RENEWAL, 0, 1) = 1
               OR DECODE(D.PERMIT_RENEWAL_WRKLD, S.PERMIT_RENEWAL_WRKLD, 0, 1) = 1
               OR DECODE(D.PERM_WRKLD, S.PERM_WRKLD, 0, 1) = 1
               OR DECODE(D.PERM_PROG, S.PERM_PROG, 0, 1) = 1
               OR DECODE(D.PC_WRKLD, S.PC_WRKLD, 0, 1) = 1
               OR DECODE(D.CLOS_WRKLD, S.CLOS_WRKLD, 0, 1) = 1
               OR DECODE(D.GPRACA, S.GPRACA, 0, 1) = 1
               OR DECODE(D.CA_WRKLD, S.CA_WRKLD, 0, 1) = 1
               OR DECODE(D.SUBJ_CA, S.SUBJ_CA, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_NON_TSD, S.SUBJ_CA_NON_TSD, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_TSD_3004, S.SUBJ_CA_TSD_3004, 0, 1) = 1
               OR DECODE(D.SUBJ_CA_DISCRETION, S.SUBJ_CA_DISCRETION, 0, 1) = 1
               OR DECODE(D.NCAPS, S.NCAPS, 0, 1) = 1
               OR DECODE(D.EC_IND, S.EC_IND, 0, 1) = 1
               OR DECODE(D.IC_IND, S.IC_IND, 0, 1) = 1
               OR DECODE(D.CA_725_IND, S.CA_725_IND, 0, 1) = 1
               OR DECODE(D.CA_750_IND, S.CA_750_IND, 0, 1) = 1
               OR DECODE(D.OPERATING_TSDF, S.OPERATING_TSDF, 0, 1) = 1
               OR DECODE(D.FULL_ENFORCEMENT, S.FULL_ENFORCEMENT, 0, 1) = 1
               OR DECODE(D.SNC, S.SNC, 0, 1) = 1
               OR DECODE(D.BOY_SNC, S.BOY_SNC, 0, 1) = 1
               OR DECODE(D.BOY_STATE_UNADDRESSED_SNC, S.BOY_STATE_UNADDRESSED_SNC, 0, 1) = 1
               OR DECODE(D.STATE_UNADDRESSED, S.STATE_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.STATE_ADDRESSED, S.STATE_ADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_STATE_ADDRESSED, S.BOY_STATE_ADDRESSED, 0, 1) = 1
               OR DECODE(D.STATE_SNC_WITH_COMP_SCHED, S.STATE_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.BOY_STATE_SNC_WITH_COMP_SCHED, S.BOY_STATE_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.EPA_UNADDRESSED, S.EPA_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_UNADDRESSED, S.BOY_EPA_UNADDRESSED, 0, 1) = 1
               OR DECODE(D.EPA_ADDRESSED, S.EPA_ADDRESSED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_ADDRESSED, S.BOY_EPA_ADDRESSED, 0, 1) = 1
               OR DECODE(D.EPA_SNC_WITH_COMP_SCHED, S.EPA_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.BOY_EPA_SNC_WITH_COMP_SCHED, S.BOY_EPA_SNC_WITH_COMP_SCHED, 0, 1) = 1
               OR DECODE(D.FA_REQUIRED, S.FA_REQUIRED, 0, 1) = 1
               OR DECODE(D.HHANDLER_LAST_CHANGE_DATE, S.HHANDLER_LAST_CHANGE_DATE, 0, 1) = 1
               OR DECODE(D.PUBLIC_NOTES, S.PUBLIC_NOTES, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_IMPORTER_IND, S.RECOGNIZED_TRADER_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_EXPORTER_IND, S.RECOGNIZED_TRADER_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_IMPORTER_IND, S.SLAB_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_EXPORTER_IND, S.SLAB_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECYCLER_NON_STORAGE_IND, S.RECYCLER_NON_STORAGE_IND, 0, 1) = 1
               OR DECODE(D.MANIFEST_BROKER_IND, S.MANIFEST_BROKER_IND, 0, 1) = 1
               OR DECODE(D.SUBPART_P_IND, S.SUBPART_P_IND, 0, 1) = 1
               OR DECODE(D.LOCATION_LATITUDE, S.LOCATION_LATITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_LONGITUDE, S.LOCATION_LONGITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_PRIM, S.LOCATION_GIS_PRIM, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_ORIG, S.LOCATION_GIS_ORIG, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (RU_REPORT_UNIV_ID,
                    HANDLER_ID,
                    ACTIVITY_LOCATION,
                    SOURCE_TYPE,
                    SEQ_NUMBER,
                    RECEIVE_DATE,
                    HANDLER_NAME,
                    NON_NOTIFIER_IND,
                    ACCESSIBILITY,
                    REPORT_CYCLE,
                    REGION,
                    STATE,
                    EXTRACT_FLAG,
                    ACTIVE_SITE,
                    COUNTY_CODE,
                    COUNTY_NAME,
                    LOCATION_STREET_NUMBER,
                    LOCATION_STREET1,
                    LOCATION_STREET2,
                    LOCATION_CITY,
                    LOCATION_STATE,
                    LOCATION_COUNTRY,
                    LOCATION_ZIP,
                    MAIL_STREET_NUMBER,
                    MAIL_STREET1,
                    MAIL_STREET2,
                    MAIL_CITY,
                    MAIL_STATE,
                    MAIL_COUNTRY,
                    MAIL_ZIP,
                    CONTACT_STREET_NUMBER,
                    CONTACT_STREET1,
                    CONTACT_STREET2,
                    CONTACT_CITY,
                    CONTACT_STATE,
                    CONTACT_COUNTRY,
                    CONTACT_ZIP,
                    CONTACT_NAME,
                    CONTACT_PHONE,
                    CONTACT_FAX,
                    CONTACT_EMAIL,
                    CONTACT_TITLE,
                    OWNER_NAME,
                    OWNER_TYPE,
                    OWNER_SEQ_NUM,
                    OPER_NAME,
                    OPER_TYPE,
                    OPER_SEQ_NUM,
                    NAIC1_CODE,
                    NAIC2_CODE,
                    NAIC3_CODE,
                    NAIC4_CODE,
                    IN_HANDLER_UNIVERSE,
                    IN_A_UNIVERSE,
                    FED_WASTE_GENERATOR_OWNER,
                    FED_WASTE_GENERATOR,
                    STATE_WASTE_GENERATOR_OWNER,
                    STATE_WASTE_GENERATOR,
                    GEN_STATUS,
                    UNIV_WASTE,
                    LAND_TYPE,
                    STATE_DISTRICT_OWNER,
                    STATE_DISTRICT,
                    SHORT_TERM_GEN_IND,
                    IMPORTER_ACTIVITY,
                    MIXED_WASTE_GENERATOR,
                    TRANSPORTER_ACTIVITY,
                    TRANSFER_FACILITY_IND,
                    RECYCLER_ACTIVITY,
                    ONSITE_BURNER_EXEMPTION,
                    FURNACE_EXEMPTION,
                    UNDERGROUND_INJECTION_ACTIVITY,
                    UNIVERSAL_WASTE_DEST_FACILITY,
                    OFFSITE_WASTE_RECEIPT,
                    USED_OIL,
                    FEDERAL_UNIVERSAL_WASTE,
                    AS_FEDERAL_REGULATED_TSDF,
                    AS_CONVERTED_TSDF,
                    AS_STATE_REGULATED_TSDF,
                    FEDERAL_IND,
                    HSM,
                    SUBPART_K,
                    COMMERCIAL_TSD,
                    TSD,
                    GPRA_PERMIT,
                    GPRA_RENEWAL,
                    PERMIT_RENEWAL_WRKLD,
                    PERM_WRKLD,
                    PERM_PROG,
                    PC_WRKLD,
                    CLOS_WRKLD,
                    GPRACA,
                    CA_WRKLD,
                    SUBJ_CA,
                    SUBJ_CA_NON_TSD,
                    SUBJ_CA_TSD_3004,
                    SUBJ_CA_DISCRETION,
                    NCAPS,
                    EC_IND,
                    IC_IND,
                    CA_725_IND,
                    CA_750_IND,
                    OPERATING_TSDF,
                    FULL_ENFORCEMENT,
                    SNC,
                    BOY_SNC,
                    BOY_STATE_UNADDRESSED_SNC,
                    STATE_UNADDRESSED,
                    STATE_ADDRESSED,
                    BOY_STATE_ADDRESSED,
                    STATE_SNC_WITH_COMP_SCHED,
                    BOY_STATE_SNC_WITH_COMP_SCHED,
                    EPA_UNADDRESSED,
                    BOY_EPA_UNADDRESSED,
                    EPA_ADDRESSED,
                    BOY_EPA_ADDRESSED,
                    EPA_SNC_WITH_COMP_SCHED,
                    BOY_EPA_SNC_WITH_COMP_SCHED,
                    FA_REQUIRED,
                    HHANDLER_LAST_CHANGE_DATE,
                    PUBLIC_NOTES,
                    NOTES,
                    RECOGNIZED_TRADER_IMPORTER_IND,
                    RECOGNIZED_TRADER_EXPORTER_IND,
                    SLAB_IMPORTER_IND,
                    SLAB_EXPORTER_IND,
                    RECYCLER_NON_STORAGE_IND,
                    MANIFEST_BROKER_IND,
                    SUBPART_P_IND,
                    LOCATION_LATITUDE,
                    LOCATION_LONGITUDE,
                    LOCATION_GIS_PRIM,
                    LOCATION_GIS_ORIG)
            VALUES (SEQ_RCRA_GIS_GEO_INFORMATION.NEXTVAL,
                    S.HANDLER_ID,
                    S.ACTIVITY_LOCATION,
                    S.SOURCE_TYPE,
                    S.SEQ_NUMBER,
                    S.RECEIVE_DATE,
                    S.HANDLER_NAME,
                    S.NON_NOTIFIER_IND,
                    S.ACCESSIBILITY,
                    S.REPORT_CYCLE,
                    S.REGION,
                    S.STATE,
                    S.EXTRACT_FLAG,
                    S.ACTIVE_SITE,
                    S.COUNTY_CODE,
                    S.COUNTY_NAME,
                    S.LOCATION_STREET_NUMBER,
                    S.LOCATION_STREET1,
                    S.LOCATION_STREET2,
                    S.LOCATION_CITY,
                    S.LOCATION_STATE,
                    S.LOCATION_COUNTRY,
                    S.LOCATION_ZIP,
                    S.MAIL_STREET_NUMBER,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_STREET_NUMBER,
                    S.CONTACT_STREET1,
                    S.CONTACT_STREET2,
                    S.CONTACT_CITY,
                    S.CONTACT_STATE,
                    S.CONTACT_COUNTRY,
                    S.CONTACT_ZIP,
                    S.CONTACT_NAME,
                    S.CONTACT_PHONE,
                    S.CONTACT_FAX,
                    S.CONTACT_EMAIL,
                    S.CONTACT_TITLE,
                    S.OWNER_NAME,
                    S.OWNER_TYPE,
                    S.OWNER_SEQ_NUM,
                    S.OPER_NAME,
                    S.OPER_TYPE,
                    S.OPER_SEQ_NUM,
                    S.NAIC1_CODE,
                    S.NAIC2_CODE,
                    S.NAIC3_CODE,
                    S.NAIC4_CODE,
                    S.IN_HANDLER_UNIVERSE,
                    S.IN_A_UNIVERSE,
                    S.FED_WASTE_GENERATOR_OWNER,
                    S.FED_WASTE_GENERATOR,
                    S.STATE_WASTE_GENERATOR_OWNER,
                    S.STATE_WASTE_GENERATOR,
                    S.GEN_STATUS,
                    S.UNIV_WASTE,
                    S.LAND_TYPE,
                    S.STATE_DISTRICT_OWNER,
                    S.STATE_DISTRICT,
                    S.SHORT_TERM_GEN_IND,
                    S.IMPORTER_ACTIVITY,
                    S.MIXED_WASTE_GENERATOR,
                    S.TRANSPORTER_ACTIVITY,
                    S.TRANSFER_FACILITY_IND,
                    S.RECYCLER_ACTIVITY,
                    S.ONSITE_BURNER_EXEMPTION,
                    S.FURNACE_EXEMPTION,
                    S.UNDERGROUND_INJECTION_ACTIVITY,
                    S.UNIVERSAL_WASTE_DEST_FACILITY,
                    S.OFFSITE_WASTE_RECEIPT,
                    S.USED_OIL,
                    S.FEDERAL_UNIVERSAL_WASTE,
                    S.AS_FEDERAL_REGULATED_TSDF,
                    S.AS_CONVERTED_TSDF,
                    S.AS_STATE_REGULATED_TSDF,
                    S.FEDERAL_IND,
                    S.HSM,
                    S.SUBPART_K,
                    S.COMMERCIAL_TSD,
                    S.TSD,
                    S.GPRA_PERMIT,
                    S.GPRA_RENEWAL,
                    S.PERMIT_RENEWAL_WRKLD,
                    S.PERM_WRKLD,
                    S.PERM_PROG,
                    S.PC_WRKLD,
                    S.CLOS_WRKLD,
                    S.GPRACA,
                    S.CA_WRKLD,
                    S.SUBJ_CA,
                    S.SUBJ_CA_NON_TSD,
                    S.SUBJ_CA_TSD_3004,
                    S.SUBJ_CA_DISCRETION,
                    S.NCAPS,
                    S.EC_IND,
                    S.IC_IND,
                    S.CA_725_IND,
                    S.CA_750_IND,
                    S.OPERATING_TSDF,
                    S.FULL_ENFORCEMENT,
                    S.SNC,
                    S.BOY_SNC,
                    S.BOY_STATE_UNADDRESSED_SNC,
                    S.STATE_UNADDRESSED,
                    S.STATE_ADDRESSED,
                    S.BOY_STATE_ADDRESSED,
                    S.STATE_SNC_WITH_COMP_SCHED,
                    S.BOY_STATE_SNC_WITH_COMP_SCHED,
                    S.EPA_UNADDRESSED,
                    S.BOY_EPA_UNADDRESSED,
                    S.EPA_ADDRESSED,
                    S.BOY_EPA_ADDRESSED,
                    S.EPA_SNC_WITH_COMP_SCHED,
                    S.BOY_EPA_SNC_WITH_COMP_SCHED,
                    S.FA_REQUIRED,
                    S.HHANDLER_LAST_CHANGE_DATE,
                    S.PUBLIC_NOTES,
                    S.NOTES,
                    S.RECOGNIZED_TRADER_IMPORTER_IND,
                    S.RECOGNIZED_TRADER_EXPORTER_IND,
                    S.SLAB_IMPORTER_IND,
                    S.SLAB_EXPORTER_IND,
                    S.RECYCLER_NON_STORAGE_IND,
                    S.MANIFEST_BROKER_IND,
                    S.SUBPART_P_IND,
                    S.LOCATION_LATITUDE,
                    S.LOCATION_LONGITUDE,
                    S.LOCATION_GIS_PRIM,
                    S.LOCATION_GIS_ORIG);
    END;

-- GIS

    PROCEDURE GIS_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'GS');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       GIS_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_GIS_FAC_SUBM_VW;
    END;

    PROCEDURE GIS_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_GIS_FAC_SUBM D
        USING (SELECT *
               FROM ETL_GIS_FAC_SUBM_VW) S
        ON (D.GIS_FAC_SUBM_ID = S.WH_GIS_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (GIS_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_GIS_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

    PROCEDURE GIS_MERGE_RCRA_GIS_GEO_INFO AS
    BEGIN
        MERGE INTO RCRA_GIS_GEO_INFORMATION D
        USING (SELECT *
               FROM ETL_GIS_GEO_INFORMATION_VW) S
        ON (D.GIS_GEO_INFORMATION_ID = S.WH_GIS_GEO_INFORMATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.GEO_INFO_OWNER                 = S.GEO_INFO_OWNER,
                D.GEO_INFO_SEQ_NUM               = S.GEO_INFO_SEQ_NUM,
                D.PERMIT_UNIT_SEQ_NUM            = S.PERMIT_UNIT_SEQ_NUM,
                D.AREA_SEQ_NUM                   = S.AREA_SEQ_NUM,
                D.LOC_COMM_TXT                   = S.LOC_COMM_TXT,
                D.AREA_ACREAGE_MEAS              = S.AREA_ACREAGE_MEAS,
                D.AREA_MEAS_SRC_DATA_OWNER_CODE  = S.AREA_MEAS_SRC_DATA_OWNER_CODE,
                D.AREA_MEAS_SRC_CODE             = S.AREA_MEAS_SRC_CODE,
                D.AREA_MEAS_DATE                 = S.AREA_MEAS_DATE,
                D.DATA_COLL_DATE                 = S.DATA_COLL_DATE,
                D.HORZ_ACC_MEAS                  = S.HORZ_ACC_MEAS,
                D.SRC_MAP_SCALE_NUM              = S.SRC_MAP_SCALE_NUM,
                D.COORD_DATA_SRC_DATA_OWNER_CODE = S.COORD_DATA_SRC_DATA_OWNER_CODE,
                D.COORD_DATA_SRC_CODE            = S.COORD_DATA_SRC_CODE,
                D.GEO_REF_PT_DATA_OWNER_CODE     = S.GEO_REF_PT_DATA_OWNER_CODE,
                D.GEO_REF_PT_CODE                = S.GEO_REF_PT_CODE,
                D.GEOM_TYPE_DATA_OWNER_CODE      = S.GEOM_TYPE_DATA_OWNER_CODE,
                D.GEOM_TYPE_CODE                 = S.GEOM_TYPE_CODE,
                D.HORZ_COLL_METH_DATA_OWNER_CODE = S.HORZ_COLL_METH_DATA_OWNER_CODE,
                D.HORZ_COLL_METH_CODE            = S.HORZ_COLL_METH_CODE,
                D.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE = S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                D.HORZ_COORD_REF_SYS_DATUM_CODE  = S.HORZ_COORD_REF_SYS_DATUM_CODE,
                D.VERF_METH_DATA_OWNER_CODE      = S.VERF_METH_DATA_OWNER_CODE,
                D.VERF_METH_CODE                 = S.VERF_METH_CODE,
                D.LATITUDE                       = S.LATITUDE,
                D.LONGITUDE                      = S.LONGITUDE,
                D.ELEVATION                      = S.ELEVATION,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.G_CREATED_DATE                 = S.G_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.GEO_INFO_OWNER, S.GEO_INFO_OWNER, 0, 1) = 1
               OR DECODE(D.GEO_INFO_SEQ_NUM, S.GEO_INFO_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AREA_SEQ_NUM, S.AREA_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.LOC_COMM_TXT, S.LOC_COMM_TXT, 0, 1) = 1
               OR DECODE(D.AREA_ACREAGE_MEAS, S.AREA_ACREAGE_MEAS, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_SRC_DATA_OWNER_CODE, S.AREA_MEAS_SRC_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_SRC_CODE, S.AREA_MEAS_SRC_CODE, 0, 1) = 1
               OR DECODE(D.AREA_MEAS_DATE, S.AREA_MEAS_DATE, 0, 1) = 1
               OR DECODE(D.DATA_COLL_DATE, S.DATA_COLL_DATE, 0, 1) = 1
               OR DECODE(D.HORZ_ACC_MEAS, S.HORZ_ACC_MEAS, 0, 1) = 1
               OR DECODE(D.SRC_MAP_SCALE_NUM, S.SRC_MAP_SCALE_NUM, 0, 1) = 1
               OR DECODE(D.COORD_DATA_SRC_DATA_OWNER_CODE, S.COORD_DATA_SRC_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.COORD_DATA_SRC_CODE, S.COORD_DATA_SRC_CODE, 0, 1) = 1
               OR DECODE(D.GEO_REF_PT_DATA_OWNER_CODE, S.GEO_REF_PT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.GEO_REF_PT_CODE, S.GEO_REF_PT_CODE, 0, 1) = 1
               OR DECODE(D.GEOM_TYPE_DATA_OWNER_CODE, S.GEOM_TYPE_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.GEOM_TYPE_CODE, S.GEOM_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.HORZ_COLL_METH_DATA_OWNER_CODE, S.HORZ_COLL_METH_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.HORZ_COLL_METH_CODE, S.HORZ_COLL_METH_CODE, 0, 1) = 1
               OR DECODE(D.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE, S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE, 0, 1) = 1
               OR DECODE(D.HORZ_COORD_REF_SYS_DATUM_CODE, S.HORZ_COORD_REF_SYS_DATUM_CODE, 0, 1) = 1
               OR DECODE(D.VERF_METH_DATA_OWNER_CODE, S.VERF_METH_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.VERF_METH_CODE, S.VERF_METH_CODE, 0, 1) = 1
               OR DECODE(D.LATITUDE, S.LATITUDE, 0, 1) = 1
               OR DECODE(D.LONGITUDE, S.LONGITUDE, 0, 1) = 1
               OR DECODE(D.ELEVATION, S.ELEVATION, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.G_CREATED_DATE, S.G_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (GIS_GEO_INFORMATION_ID,
                    GIS_FAC_SUBM_ID,
                    TRANS_CODE,
                    GEO_INFO_OWNER,
                    GEO_INFO_SEQ_NUM,
                    PERMIT_UNIT_SEQ_NUM,
                    AREA_SEQ_NUM,
                    LOC_COMM_TXT,
                    AREA_ACREAGE_MEAS,
                    AREA_MEAS_SRC_DATA_OWNER_CODE,
                    AREA_MEAS_SRC_CODE,
                    AREA_MEAS_DATE,
                    DATA_COLL_DATE,
                    HORZ_ACC_MEAS,
                    SRC_MAP_SCALE_NUM,
                    COORD_DATA_SRC_DATA_OWNER_CODE,
                    COORD_DATA_SRC_CODE,
                    GEO_REF_PT_DATA_OWNER_CODE,
                    GEO_REF_PT_CODE,
                    GEOM_TYPE_DATA_OWNER_CODE,
                    GEOM_TYPE_CODE,
                    HORZ_COLL_METH_DATA_OWNER_CODE,
                    HORZ_COLL_METH_CODE,
                    HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                    HORZ_COORD_REF_SYS_DATUM_CODE,
                    VERF_METH_DATA_OWNER_CODE,
                    VERF_METH_CODE,
                    LATITUDE,
                    LONGITUDE,
                    ELEVATION,
                    CREATED_BY_USERID,
                    G_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_GIS_GEO_INFORMATION.NEXTVAL,
                    S.WH_GIS_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.GEO_INFO_OWNER,
                    S.GEO_INFO_SEQ_NUM,
                    S.PERMIT_UNIT_SEQ_NUM,
                    S.AREA_SEQ_NUM,
                    S.LOC_COMM_TXT,
                    S.AREA_ACREAGE_MEAS,
                    S.AREA_MEAS_SRC_DATA_OWNER_CODE,
                    S.AREA_MEAS_SRC_CODE,
                    S.AREA_MEAS_DATE,
                    S.DATA_COLL_DATE,
                    S.HORZ_ACC_MEAS,
                    S.SRC_MAP_SCALE_NUM,
                    S.COORD_DATA_SRC_DATA_OWNER_CODE,
                    S.COORD_DATA_SRC_CODE,
                    S.GEO_REF_PT_DATA_OWNER_CODE,
                    S.GEO_REF_PT_CODE,
                    S.GEOM_TYPE_DATA_OWNER_CODE,
                    S.GEOM_TYPE_CODE,
                    S.HORZ_COLL_METH_DATA_OWNER_CODE,
                    S.HORZ_COLL_METH_CODE,
                    S.HRZ_CRD_RF_SYS_DTM_DTA_OWN_CDE,
                    S.HORZ_COORD_REF_SYS_DATUM_CODE,
                    S.VERF_METH_DATA_OWNER_CODE,
                    S.VERF_METH_CODE,
                    S.LATITUDE,
                    S.LONGITUDE,
                    S.ELEVATION,
                    S.CREATED_BY_USERID,
                    S.G_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

-- CME Delete

    PROCEDURE CME_DELETE_VIOL AS
    BEGIN
        DELETE
        FROM RCRA_CME_VIOL
        WHERE CME_VIOL_ID IN (SELECT WH_CME_VIOL_ID FROM ETL_CME_VIOL_DEL_VW WHERE WH_CME_VIOL_ID IS NOT NULL);
    END;

    PROCEDURE CME_DELETE_EVAL AS
    BEGIN
        DELETE
        FROM RCRA_CME_EVAL
        WHERE CME_EVAL_ID IN (SELECT WH_CME_EVAL_ID FROM ETL_CME_EVAL_DEL_VW WHERE WH_CME_EVAL_ID IS NOT NULL);
    END;

    PROCEDURE CME_DELETE_ENFRC_ACT AS
    BEGIN
        DELETE
        FROM RCRA_CME_ENFRC_ACT
        WHERE CME_ENFRC_ACT_ID IN
              (SELECT WH_CME_ENFR_ACT_ID FROM ETL_CME_ENFRC_ACT_DEL_VW WHERE WH_CME_ENFR_ACT_ID IS NOT NULL);
    END;

-- CME

    PROCEDURE CME_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CE');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               EPA_HDLR_ID,
               CASE
                   WHEN
                       CME_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_CME_FAC_SUBM_VW;
    END;

    PROCEDURE CME_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_CME_FAC_SUBM D
        USING (SELECT *
               FROM ETL_CME_FAC_SUBM_VW) S
        ON (D.CME_FAC_SUBM_ID = S.WH_CME_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (CME_FAC_SUBM_ID,
                    EPA_HDLR_ID)
            VALUES (SEQ_RCRA_CME_FAC_SUBM.NEXTVAL,
                    S.EPA_HDLR_ID);
    END;

    PROCEDURE CME_MERGE_VIOL AS
    BEGIN
        MERGE INTO RCRA_CME_VIOL D
        USING (SELECT *
               FROM ETL_CME_VIOL_VW) S
        ON (D.CME_VIOL_ID = S.WH_CME_VIOL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE           = S.TRANS_CODE,
                D.VIOL_ACT_LOC         = S.VIOL_ACT_LOC,
                D.VIOL_SEQ_NUM         = S.VIOL_SEQ_NUM,
                D.AGN_WHICH_DTRM_VIOL  = S.AGN_WHICH_DTRM_VIOL,
                D.VIOL_TYPE_OWNER      = S.VIOL_TYPE_OWNER,
                D.VIOL_TYPE            = S.VIOL_TYPE,
                D.FORMER_CITATION_NAME = S.FORMER_CITATION_NAME,
                D.VIOL_DTRM_DATE       = S.VIOL_DTRM_DATE,
                D.RTN_COMPL_ACTL_DATE  = S.RTN_COMPL_ACTL_DATE,
                D.RTN_TO_COMPL_QUAL    = S.RTN_TO_COMPL_QUAL,
                D.VIOL_RESP_AGN        = S.VIOL_RESP_AGN,
                D.NOTES                = S.NOTES,
                D.CREATED_BY_USERID    = S.CREATED_BY_USERID,
                D.C_CREATED_DATE       = S.C_CREATED_DATE,
                D.LAST_UPDT_BY         = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE       = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_ACT_LOC, S.VIOL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
               OR DECODE(D.VIOL_TYPE_OWNER, S.VIOL_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.VIOL_TYPE, S.VIOL_TYPE, 0, 1) = 1
               OR DECODE(D.FORMER_CITATION_NAME, S.FORMER_CITATION_NAME, 0, 1) = 1
               OR DECODE(D.VIOL_DTRM_DATE, S.VIOL_DTRM_DATE, 0, 1) = 1
               OR DECODE(D.RTN_COMPL_ACTL_DATE, S.RTN_COMPL_ACTL_DATE, 0, 1) = 1
               OR DECODE(D.RTN_TO_COMPL_QUAL, S.RTN_TO_COMPL_QUAL, 0, 1) = 1
               OR DECODE(D.VIOL_RESP_AGN, S.VIOL_RESP_AGN, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_VIOL_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    VIOL_ACT_LOC,
                    VIOL_SEQ_NUM,
                    AGN_WHICH_DTRM_VIOL,
                    VIOL_TYPE_OWNER,
                    VIOL_TYPE,
                    FORMER_CITATION_NAME,
                    VIOL_DTRM_DATE,
                    RTN_COMPL_ACTL_DATE,
                    RTN_TO_COMPL_QUAL,
                    VIOL_RESP_AGN,
                    NOTES,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_VIOL.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.VIOL_ACT_LOC,
                    S.VIOL_SEQ_NUM,
                    S.AGN_WHICH_DTRM_VIOL,
                    S.VIOL_TYPE_OWNER,
                    S.VIOL_TYPE,
                    S.FORMER_CITATION_NAME,
                    S.VIOL_DTRM_DATE,
                    S.RTN_COMPL_ACTL_DATE,
                    S.RTN_TO_COMPL_QUAL,
                    S.VIOL_RESP_AGN,
                    S.NOTES,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_EVAL AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL D
        USING (SELECT *
               FROM ETL_CME_EVAL_VW) S
        ON (D.CME_EVAL_ID = S.WH_CME_EVAL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.EVAL_ACT_LOC                = S.EVAL_ACT_LOC,
                D.EVAL_IDEN                   = S.EVAL_IDEN,
                D.EVAL_START_DATE             = S.EVAL_START_DATE,
                D.EVAL_RESP_AGN               = S.EVAL_RESP_AGN,
                D.DAY_ZERO                    = S.DAY_ZERO,
                D.FOUND_VIOL                  = S.FOUND_VIOL,
                D.CTZN_CPLT_IND               = S.CTZN_CPLT_IND,
                D.MULTIMEDIA_IND              = S.MULTIMEDIA_IND,
                D.SAMPL_IND                   = S.SAMPL_IND,
                D.NOT_SUBTL_C_IND             = S.NOT_SUBTL_C_IND,
                D.EVAL_TYPE_OWNER             = S.EVAL_TYPE_OWNER,
                D.EVAL_TYPE                   = S.EVAL_TYPE,
                D.FOCUS_AREA_OWNER            = S.FOCUS_AREA_OWNER,
                D.FOCUS_AREA                  = S.FOCUS_AREA,
                D.EVAL_RESP_PERSON_IDEN_OWNER = S.EVAL_RESP_PERSON_IDEN_OWNER,
                D.EVAL_RESP_PERSON_IDEN       = S.EVAL_RESP_PERSON_IDEN,
                D.EVAL_RESP_SUBORG_OWNER      = S.EVAL_RESP_SUBORG_OWNER,
                D.EVAL_RESP_SUBORG            = S.EVAL_RESP_SUBORG,
                D.NOTES                       = S.NOTES,
                D.NOC_DATE                    = S.NOC_DATE,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.C_CREATED_DATE              = S.C_CREATED_DATE,
                D.DATA_ORIG                   = S.DATA_ORIG,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.EVAL_ACT_LOC, S.EVAL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.EVAL_IDEN, S.EVAL_IDEN, 0, 1) = 1
               OR DECODE(D.EVAL_START_DATE, S.EVAL_START_DATE, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_AGN, S.EVAL_RESP_AGN, 0, 1) = 1
               OR DECODE(D.DAY_ZERO, S.DAY_ZERO, 0, 1) = 1
               OR DECODE(D.FOUND_VIOL, S.FOUND_VIOL, 0, 1) = 1
               OR DECODE(D.CTZN_CPLT_IND, S.CTZN_CPLT_IND, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_IND, S.MULTIMEDIA_IND, 0, 1) = 1
               OR DECODE(D.SAMPL_IND, S.SAMPL_IND, 0, 1) = 1
               OR DECODE(D.NOT_SUBTL_C_IND, S.NOT_SUBTL_C_IND, 0, 1) = 1
               OR DECODE(D.EVAL_TYPE_OWNER, S.EVAL_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_TYPE, S.EVAL_TYPE, 0, 1) = 1
               OR DECODE(D.FOCUS_AREA_OWNER, S.FOCUS_AREA_OWNER, 0, 1) = 1
               OR DECODE(D.FOCUS_AREA, S.FOCUS_AREA, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_PERSON_IDEN_OWNER, S.EVAL_RESP_PERSON_IDEN_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_PERSON_IDEN, S.EVAL_RESP_PERSON_IDEN, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_SUBORG_OWNER, S.EVAL_RESP_SUBORG_OWNER, 0, 1) = 1
               OR DECODE(D.EVAL_RESP_SUBORG, S.EVAL_RESP_SUBORG, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.NOC_DATE, S.NOC_DATE, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    EVAL_ACT_LOC,
                    EVAL_IDEN,
                    EVAL_START_DATE,
                    EVAL_RESP_AGN,
                    DAY_ZERO,
                    FOUND_VIOL,
                    CTZN_CPLT_IND,
                    MULTIMEDIA_IND,
                    SAMPL_IND,
                    NOT_SUBTL_C_IND,
                    EVAL_TYPE_OWNER,
                    EVAL_TYPE,
                    FOCUS_AREA_OWNER,
                    FOCUS_AREA,
                    EVAL_RESP_PERSON_IDEN_OWNER,
                    EVAL_RESP_PERSON_IDEN,
                    EVAL_RESP_SUBORG_OWNER,
                    EVAL_RESP_SUBORG,
                    NOTES,
                    NOC_DATE,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_EVAL.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.EVAL_ACT_LOC,
                    S.EVAL_IDEN,
                    S.EVAL_START_DATE,
                    S.EVAL_RESP_AGN,
                    S.DAY_ZERO,
                    S.FOUND_VIOL,
                    S.CTZN_CPLT_IND,
                    S.MULTIMEDIA_IND,
                    S.SAMPL_IND,
                    S.NOT_SUBTL_C_IND,
                    S.EVAL_TYPE_OWNER,
                    S.EVAL_TYPE,
                    S.FOCUS_AREA_OWNER,
                    S.FOCUS_AREA,
                    S.EVAL_RESP_PERSON_IDEN_OWNER,
                    S.EVAL_RESP_PERSON_IDEN,
                    S.EVAL_RESP_SUBORG_OWNER,
                    S.EVAL_RESP_SUBORG,
                    S.NOTES,
                    S.NOC_DATE,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_EVAL_COMMIT AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL_COMMIT D
        USING (SELECT *
               FROM ETL_CME_EVAL_COMMIT_VW) S
        ON (D.CME_EVAL_COMMIT_ID = S.WH_CME_EVAL_COMMIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_COMMIT_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CME_EVAL_COMMIT.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE CME_MERGE_EVAL_VIOL AS
    BEGIN
        MERGE INTO RCRA_CME_EVAL_VIOL D
        USING (SELECT *
               FROM ETL_CME_EVAL_VIOL_VW) S
        ON (D.CME_EVAL_VIOL_ID = S.WH_CME_EVAL_VIOL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.VIOL_SEQ_NUM        = S.VIOL_SEQ_NUM,
                D.VIOL_ACT_LOC        = S.VIOL_ACT_LOC,
                D.AGN_WHICH_DTRM_VIOL = S.AGN_WHICH_DTRM_VIOL
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.VIOL_ACT_LOC, S.VIOL_ACT_LOC, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_EVAL_VIOL_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    VIOL_SEQ_NUM,
                    VIOL_ACT_LOC,
                    AGN_WHICH_DTRM_VIOL)
            VALUES (SEQ_RCRA_CME_EVAL_VIOL.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.VIOL_SEQ_NUM,
                    S.VIOL_ACT_LOC,
                    S.AGN_WHICH_DTRM_VIOL);
    END;

    PROCEDURE CME_MERGE_CITATION AS
    BEGIN
        MERGE INTO RCRA_CME_CITATION D
        USING (SELECT *
               FROM ETL_CME_CITATION_VW) S
        ON (D.CME_CITATION_ID = S.WH_CME_CITATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE            = S.TRANS_CODE,
                D.CITATION_NAME_SEQ_NUM = S.CITATION_NAME_SEQ_NUM,
                D.CITATION_NAME         = S.CITATION_NAME,
                D.CITATION_NAME_OWNER   = S.CITATION_NAME_OWNER,
                D.CITATION_NAME_TYPE    = S.CITATION_NAME_TYPE,
                D.NOTES                 = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_SEQ_NUM, S.CITATION_NAME_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.CITATION_NAME, S.CITATION_NAME, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_OWNER, S.CITATION_NAME_OWNER, 0, 1) = 1
               OR DECODE(D.CITATION_NAME_TYPE, S.CITATION_NAME_TYPE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_CITATION_ID,
                    CME_VIOL_ID,
                    TRANS_CODE,
                    CITATION_NAME_SEQ_NUM,
                    CITATION_NAME,
                    CITATION_NAME_OWNER,
                    CITATION_NAME_TYPE,
                    NOTES)
            VALUES (SEQ_RCRA_CME_CITATION.NEXTVAL,
                    S.WH_CME_VIOL_ID,
                    S.TRANS_CODE,
                    S.CITATION_NAME_SEQ_NUM,
                    S.CITATION_NAME,
                    S.CITATION_NAME_OWNER,
                    S.CITATION_NAME_TYPE,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_ENFRC_ACT AS
    BEGIN
        MERGE INTO RCRA_CME_ENFRC_ACT D
        USING (SELECT *
               FROM ETL_CME_ENFRC_ACT_VW) S
        ON (D.CME_ENFRC_ACT_ID = S.WH_CME_ENFR_ACT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                    = S.TRANS_CODE,
                D.ENFRC_AGN_LOC_NAME            = S.ENFRC_AGN_LOC_NAME,
                D.ENFRC_ACT_IDEN                = S.ENFRC_ACT_IDEN,
                D.ENFRC_ACT_DATE                = S.ENFRC_ACT_DATE,
                D.ENFRC_AGN_NAME                = S.ENFRC_AGN_NAME,
                D.ENFRC_DOCKET_NUM              = S.ENFRC_DOCKET_NUM,
                D.ENFRC_ATTRY                   = S.ENFRC_ATTRY,
                D.CORCT_ACT_COMPT               = S.CORCT_ACT_COMPT,
                D.CNST_AGMT_FINAL_ORDER_SEQ_NUM = S.CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                D.APPEAL_INIT_DATE              = S.APPEAL_INIT_DATE,
                D.APPEAL_RSLN_DATE              = S.APPEAL_RSLN_DATE,
                D.DISP_STAT_DATE                = S.DISP_STAT_DATE,
                D.DISP_STAT_OWNER               = S.DISP_STAT_OWNER,
                D.DISP_STAT                     = S.DISP_STAT,
                D.ENFRC_OWNER                   = S.ENFRC_OWNER,
                D.ENFRC_TYPE                    = S.ENFRC_TYPE,
                D.ENFRC_RESP_PERSON_OWNER       = S.ENFRC_RESP_PERSON_OWNER,
                D.ENFRC_RESP_PERSON_IDEN        = S.ENFRC_RESP_PERSON_IDEN,
                D.ENFRC_RESP_SUBORG_OWNER       = S.ENFRC_RESP_SUBORG_OWNER,
                D.ENFRC_RESP_SUBORG             = S.ENFRC_RESP_SUBORG,
                D.NOTES                         = S.NOTES,
                D.CREATED_BY_USERID             = S.CREATED_BY_USERID,
                D.C_CREATED_DATE                = S.C_CREATED_DATE,
                D.DATA_ORIG                     = S.DATA_ORIG,
                D.LAST_UPDT_BY                  = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ENFRC_AGN_LOC_NAME, S.ENFRC_AGN_LOC_NAME, 0, 1) = 1
               OR DECODE(D.ENFRC_ACT_IDEN, S.ENFRC_ACT_IDEN, 0, 1) = 1
               OR DECODE(D.ENFRC_ACT_DATE, S.ENFRC_ACT_DATE, 0, 1) = 1
               OR DECODE(D.ENFRC_AGN_NAME, S.ENFRC_AGN_NAME, 0, 1) = 1
               OR DECODE(D.ENFRC_DOCKET_NUM, S.ENFRC_DOCKET_NUM, 0, 1) = 1
               OR DECODE(D.ENFRC_ATTRY, S.ENFRC_ATTRY, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_COMPT, S.CORCT_ACT_COMPT, 0, 1) = 1
               OR DECODE(D.CNST_AGMT_FINAL_ORDER_SEQ_NUM, S.CNST_AGMT_FINAL_ORDER_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.APPEAL_INIT_DATE, S.APPEAL_INIT_DATE, 0, 1) = 1
               OR DECODE(D.APPEAL_RSLN_DATE, S.APPEAL_RSLN_DATE, 0, 1) = 1
               OR DECODE(D.DISP_STAT_DATE, S.DISP_STAT_DATE, 0, 1) = 1
               OR DECODE(D.DISP_STAT_OWNER, S.DISP_STAT_OWNER, 0, 1) = 1
               OR DECODE(D.DISP_STAT, S.DISP_STAT, 0, 1) = 1
               OR DECODE(D.ENFRC_OWNER, S.ENFRC_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_TYPE, S.ENFRC_TYPE, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_PERSON_OWNER, S.ENFRC_RESP_PERSON_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_PERSON_IDEN, S.ENFRC_RESP_PERSON_IDEN, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_SUBORG_OWNER, S.ENFRC_RESP_SUBORG_OWNER, 0, 1) = 1
               OR DECODE(D.ENFRC_RESP_SUBORG, S.ENFRC_RESP_SUBORG, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.C_CREATED_DATE, S.C_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_ENFRC_ACT_ID,
                    CME_FAC_SUBM_ID,
                    TRANS_CODE,
                    ENFRC_AGN_LOC_NAME,
                    ENFRC_ACT_IDEN,
                    ENFRC_ACT_DATE,
                    ENFRC_AGN_NAME,
                    ENFRC_DOCKET_NUM,
                    ENFRC_ATTRY,
                    CORCT_ACT_COMPT,
                    CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                    APPEAL_INIT_DATE,
                    APPEAL_RSLN_DATE,
                    DISP_STAT_DATE,
                    DISP_STAT_OWNER,
                    DISP_STAT,
                    ENFRC_OWNER,
                    ENFRC_TYPE,
                    ENFRC_RESP_PERSON_OWNER,
                    ENFRC_RESP_PERSON_IDEN,
                    ENFRC_RESP_SUBORG_OWNER,
                    ENFRC_RESP_SUBORG,
                    NOTES,
                    CREATED_BY_USERID,
                    C_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CME_ENFRC_ACT.NEXTVAL,
                    S.WH_CME_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ENFRC_AGN_LOC_NAME,
                    S.ENFRC_ACT_IDEN,
                    S.ENFRC_ACT_DATE,
                    S.ENFRC_AGN_NAME,
                    S.ENFRC_DOCKET_NUM,
                    S.ENFRC_ATTRY,
                    S.CORCT_ACT_COMPT,
                    S.CNST_AGMT_FINAL_ORDER_SEQ_NUM,
                    S.APPEAL_INIT_DATE,
                    S.APPEAL_RSLN_DATE,
                    S.DISP_STAT_DATE,
                    S.DISP_STAT_OWNER,
                    S.DISP_STAT,
                    S.ENFRC_OWNER,
                    S.ENFRC_TYPE,
                    S.ENFRC_RESP_PERSON_OWNER,
                    S.ENFRC_RESP_PERSON_IDEN,
                    S.ENFRC_RESP_SUBORG_OWNER,
                    S.ENFRC_RESP_SUBORG,
                    S.NOTES,
                    S.CREATED_BY_USERID,
                    S.C_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CME_MERGE_CSNY_DATE AS
    BEGIN
        MERGE INTO RCRA_CME_CSNY_DATE D
        USING (SELECT *
               FROM ETL_CME_CSNY_DATE_VW) S
        ON (D.CME_CSNY_DATE_ID = S.WH_CME_CSNY_DATE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE = S.TRANS_CODE,
                D.SNY_DATE   = S.SNY_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.SNY_DATE, S.SNY_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_CSNY_DATE_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    SNY_DATE)
            VALUES (SEQ_RCRA_CME_CSNY_DATE.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.SNY_DATE);
    END;

    PROCEDURE CME_MERGE_MEDIA AS
    BEGIN
        MERGE INTO RCRA_CME_MEDIA D
        USING (SELECT *
               FROM ETL_CME_MEDIA_VW) S
        ON (D.CME_MEDIA_ID = S.WH_CME_MEDIA_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE            = S.TRANS_CODE,
                D.MULTIMEDIA_CODE_OWNER = S.MULTIMEDIA_CODE_OWNER,
                D.MULTIMEDIA_CODE       = S.MULTIMEDIA_CODE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_CODE_OWNER, S.MULTIMEDIA_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.MULTIMEDIA_CODE, S.MULTIMEDIA_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_MEDIA_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    MULTIMEDIA_CODE_OWNER,
                    MULTIMEDIA_CODE)
            VALUES (SEQ_RCRA_CME_MEDIA.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.MULTIMEDIA_CODE_OWNER,
                    S.MULTIMEDIA_CODE);
    END;

    PROCEDURE CME_MERGE_MILESTONE AS
    BEGIN
        MERGE INTO RCRA_CME_MILESTONE D
        USING (SELECT *
               FROM ETL_CME_MILESTONE_VW) S
        ON (D.CME_MILESTONE_ID = S.WH_CME_MILESTONE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE               = S.TRANS_CODE,
                D.MILESTONE_SEQ_NUM        = S.MILESTONE_SEQ_NUM,
                D.TECH_RQMT_IDEN           = S.TECH_RQMT_IDEN,
                D.TECH_RQMT_DESC           = S.TECH_RQMT_DESC,
                D.MILESTONE_SCHD_COMP_DATE = S.MILESTONE_SCHD_COMP_DATE,
                D.MILESTONE_ACTL_COMP_DATE = S.MILESTONE_ACTL_COMP_DATE,
                D.MILESTONE_DFLT_DATE      = S.MILESTONE_DFLT_DATE,
                D.NOTES                    = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MILESTONE_SEQ_NUM, S.MILESTONE_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.TECH_RQMT_IDEN, S.TECH_RQMT_IDEN, 0, 1) = 1
               OR DECODE(D.TECH_RQMT_DESC, S.TECH_RQMT_DESC, 0, 1) = 1
               OR DECODE(D.MILESTONE_SCHD_COMP_DATE, S.MILESTONE_SCHD_COMP_DATE, 0, 1) = 1
               OR DECODE(D.MILESTONE_ACTL_COMP_DATE, S.MILESTONE_ACTL_COMP_DATE, 0, 1) = 1
               OR DECODE(D.MILESTONE_DFLT_DATE, S.MILESTONE_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_MILESTONE_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    MILESTONE_SEQ_NUM,
                    TECH_RQMT_IDEN,
                    TECH_RQMT_DESC,
                    MILESTONE_SCHD_COMP_DATE,
                    MILESTONE_ACTL_COMP_DATE,
                    MILESTONE_DFLT_DATE,
                    NOTES)
            VALUES (SEQ_RCRA_CME_MILESTONE.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.MILESTONE_SEQ_NUM,
                    S.TECH_RQMT_IDEN,
                    S.TECH_RQMT_DESC,
                    S.MILESTONE_SCHD_COMP_DATE,
                    S.MILESTONE_ACTL_COMP_DATE,
                    S.MILESTONE_DFLT_DATE,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_RQST AS
    BEGIN
        MERGE INTO RCRA_CME_RQST D
        USING (SELECT *
               FROM ETL_CME_RQST_VW) S
        ON (D.CME_RQST_ID = S.WH_CME_RQST_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.RQST_SEQ_NUM   = S.RQST_SEQ_NUM,
                D.DATE_OF_RQST   = S.DATE_OF_RQST,
                D.DATE_RESP_RCVD = S.DATE_RESP_RCVD,
                D.RQST_AGN       = S.RQST_AGN,
                D.NOTES          = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.RQST_SEQ_NUM, S.RQST_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.DATE_OF_RQST, S.DATE_OF_RQST, 0, 1) = 1
               OR DECODE(D.DATE_RESP_RCVD, S.DATE_RESP_RCVD, 0, 1) = 1
               OR DECODE(D.RQST_AGN, S.RQST_AGN, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_RQST_ID,
                    CME_EVAL_ID,
                    TRANS_CODE,
                    RQST_SEQ_NUM,
                    DATE_OF_RQST,
                    DATE_RESP_RCVD,
                    RQST_AGN,
                    NOTES)
            VALUES (SEQ_RCRA_CME_RQST.NEXTVAL,
                    S.WH_CME_EVAL_ID,
                    S.TRANS_CODE,
                    S.RQST_SEQ_NUM,
                    S.DATE_OF_RQST,
                    S.DATE_RESP_RCVD,
                    S.RQST_AGN,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_SUPP_ENVR_PRJT AS
    BEGIN
        MERGE INTO RCRA_CME_SUPP_ENVR_PRJT D
        USING (SELECT *
               FROM ETL_CME_SUPP_ENVR_PRJT_VW) S
        ON (D.CME_SUPP_ENVR_PRJT_ID = S.WH_CME_SUPP_ENVR_PRJT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE         = S.TRANS_CODE,
                D.SEP_SEQ_NUM        = S.SEP_SEQ_NUM,
                D.SEP_EXPND_AMOUNT   = S.SEP_EXPND_AMOUNT,
                D.SEP_SCHD_COMP_DATE = S.SEP_SCHD_COMP_DATE,
                D.SEP_ACTL_DATE      = S.SEP_ACTL_DATE,
                D.SEP_DFLT_DATE      = S.SEP_DFLT_DATE,
                D.SEP_CODE_OWNER     = S.SEP_CODE_OWNER,
                D.SEP_DESC_TXT       = S.SEP_DESC_TXT,
                D.NOTES              = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.SEP_SEQ_NUM, S.SEP_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.SEP_EXPND_AMOUNT, S.SEP_EXPND_AMOUNT, 0, 1) = 1
               OR DECODE(D.SEP_SCHD_COMP_DATE, S.SEP_SCHD_COMP_DATE, 0, 1) = 1
               OR DECODE(D.SEP_ACTL_DATE, S.SEP_ACTL_DATE, 0, 1) = 1
               OR DECODE(D.SEP_DFLT_DATE, S.SEP_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.SEP_CODE_OWNER, S.SEP_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.SEP_DESC_TXT, S.SEP_DESC_TXT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_SUPP_ENVR_PRJT_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    SEP_SEQ_NUM,
                    SEP_EXPND_AMOUNT,
                    SEP_SCHD_COMP_DATE,
                    SEP_ACTL_DATE,
                    SEP_DFLT_DATE,
                    SEP_CODE_OWNER,
                    SEP_DESC_TXT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_SUPP_ENVR_PRJT.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.SEP_SEQ_NUM,
                    S.SEP_EXPND_AMOUNT,
                    S.SEP_SCHD_COMP_DATE,
                    S.SEP_ACTL_DATE,
                    S.SEP_DFLT_DATE,
                    S.SEP_CODE_OWNER,
                    S.SEP_DESC_TXT,
                    S.NOTES);
    END;

    PROCEDURE CME_MERGE_VIOL_ENFRC AS
    BEGIN
        MERGE INTO RCRA_CME_VIOL_ENFRC D
        USING (SELECT *
               FROM ETL_CME_VIOL_ENFRC_VW) S
        ON (D.CME_VIOL_ENFRC_ID = S.WH_CME_VIOL_ENFRC_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.VIOL_SEQ_NUM        = S.VIOL_SEQ_NUM,
                D.AGN_WHICH_DTRM_VIOL = S.AGN_WHICH_DTRM_VIOL,
                D.RTN_COMPL_SCHD_DATE = S.RTN_COMPL_SCHD_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.VIOL_SEQ_NUM, S.VIOL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.AGN_WHICH_DTRM_VIOL, S.AGN_WHICH_DTRM_VIOL, 0, 1) = 1
               OR DECODE(D.RTN_COMPL_SCHD_DATE, S.RTN_COMPL_SCHD_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_VIOL_ENFRC_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    VIOL_SEQ_NUM,
                    AGN_WHICH_DTRM_VIOL,
                    RTN_COMPL_SCHD_DATE)
            VALUES (SEQ_RCRA_CME_VIOL_ENFRC.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.VIOL_SEQ_NUM,
                    S.AGN_WHICH_DTRM_VIOL,
                    S.RTN_COMPL_SCHD_DATE);
    END;

    PROCEDURE CME_MERGE_PNLTY AS
    BEGIN
        MERGE INTO RCRA_CME_PNLTY D
        USING (SELECT *
               FROM ETL_CME_PNLTY_VW) S
        ON (D.CME_PNLTY_ID = S.WH_CME_PNLTY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.PNLTY_TYPE_OWNER               = S.PNLTY_TYPE_OWNER,
                D.PNLTY_TYPE                     = S.PNLTY_TYPE,
                D.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT = S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                D.NOTES                          = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PNLTY_TYPE_OWNER, S.PNLTY_TYPE_OWNER, 0, 1) = 1
               OR DECODE(D.PNLTY_TYPE, S.PNLTY_TYPE, 0, 1) = 1
               OR DECODE(D.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT, S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_PNLTY_ID,
                    CME_ENFRC_ACT_ID,
                    TRANS_CODE,
                    PNLTY_TYPE_OWNER,
                    PNLTY_TYPE,
                    CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_PNLTY.NEXTVAL,
                    S.WH_CME_ENFR_ACT_ID,
                    S.TRANS_CODE,
                    S.PNLTY_TYPE_OWNER,
                    S.PNLTY_TYPE,
                    S.CASH_CIVIL_PNLTY_SOUGHT_AMOUNT,
                    S.NOTES);
    END;

-- ETL_CME_PYMT_VW
    PROCEDURE CME_MERGE_PYMT AS
    BEGIN
        MERGE INTO RCRA_CME_PYMT D
        USING (SELECT *
               FROM ETL_CME_PYMT_VW) S
        ON (D.CME_PYMT_ID = S.WH_CME_PYMT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE       = S.TRANS_CODE,
                D.PYMT_SEQ_NUM     = S.PYMT_SEQ_NUM,
                D.PYMT_DFLT_DATE   = S.PYMT_DFLT_DATE,
                D.SCHD_PYMT_DATE   = S.SCHD_PYMT_DATE,
                D.SCHD_PYMT_AMOUNT = S.SCHD_PYMT_AMOUNT,
                D.ACTL_PYMT_DATE   = S.ACTL_PYMT_DATE,
                D.ACTL_PAID_AMOUNT = S.ACTL_PAID_AMOUNT,
                D.NOTES            = S.NOTES
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PYMT_SEQ_NUM, S.PYMT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PYMT_DFLT_DATE, S.PYMT_DFLT_DATE, 0, 1) = 1
               OR DECODE(D.SCHD_PYMT_DATE, S.SCHD_PYMT_DATE, 0, 1) = 1
               OR DECODE(D.SCHD_PYMT_AMOUNT, S.SCHD_PYMT_AMOUNT, 0, 1) = 1
               OR DECODE(D.ACTL_PYMT_DATE, S.ACTL_PYMT_DATE, 0, 1) = 1
               OR DECODE(D.ACTL_PAID_AMOUNT, S.ACTL_PAID_AMOUNT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CME_PYMT_ID,
                    CME_PNLTY_ID,
                    TRANS_CODE,
                    PYMT_SEQ_NUM,
                    PYMT_DFLT_DATE,
                    SCHD_PYMT_DATE,
                    SCHD_PYMT_AMOUNT,
                    ACTL_PYMT_DATE,
                    ACTL_PAID_AMOUNT,
                    NOTES)
            VALUES (SEQ_RCRA_CME_PYMT.NEXTVAL,
                    S.WH_CME_PNLTY_ID,
                    S.TRANS_CODE,
                    S.PYMT_SEQ_NUM,
                    S.PYMT_DFLT_DATE,
                    S.SCHD_PYMT_DATE,
                    S.SCHD_PYMT_AMOUNT,
                    S.ACTL_PYMT_DATE,
                    S.ACTL_PAID_AMOUNT,
                    S.NOTES);
    END;

-- CA

    PROCEDURE CA_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'CA');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       CA_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_CA_FAC_SUBM_VW;
    END;

    PROCEDURE CA_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_CA_FAC_SUBM D
        USING (SELECT *
               FROM ETL_CA_FAC_SUBM_VW) S
        ON (D.CA_FAC_SUBM_ID = S.WH_CA_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (D.CA_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_CA_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

    PROCEDURE CA_MERGE_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_EVENT D
        USING (SELECT *
               FROM ETL_CA_EVENT_VW) S
        ON (D.CA_EVENT_ID = S.WH_CA_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM,
                D.ACTL_DATE                      = S.ACTL_DATE,
                D.ORIGINAL_SCHEDULE_DATE         = S.ORIGINAL_SCHEDULE_DATE,
                D.NEW_SCHEDULE_DATE              = S.NEW_SCHEDULE_DATE,
                D.EVENT_SUBORG_DATA_OWNER_CODE   = S.EVENT_SUBORG_DATA_OWNER_CODE,
                D.EVENT_SUBORG_CODE              = S.EVENT_SUBORG_CODE,
                D.RESP_PERSON_DATA_OWNER_CODE    = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID                 = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.PUBLIC_SUPP_INFO_TXT           = S.PUBLIC_SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.ACTL_DATE, S.ACTL_DATE, 0, 1) = 1
               OR DECODE(D.ORIGINAL_SCHEDULE_DATE, S.ORIGINAL_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.NEW_SCHEDULE_DATE, S.NEW_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_DATA_OWNER_CODE, S.EVENT_SUBORG_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_CODE, S.EVENT_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.PUBLIC_SUPP_INFO_TXT, S.PUBLIC_SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_EVENT_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM,
                    ACTL_DATE,
                    ORIGINAL_SCHEDULE_DATE,
                    NEW_SCHEDULE_DATE,
                    EVENT_SUBORG_DATA_OWNER_CODE,
                    EVENT_SUBORG_CODE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    PUBLIC_SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_EVENT.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM,
                    S.ACTL_DATE,
                    S.ORIGINAL_SCHEDULE_DATE,
                    S.NEW_SCHEDULE_DATE,
                    S.EVENT_SUBORG_DATA_OWNER_CODE,
                    S.EVENT_SUBORG_CODE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.PUBLIC_SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

--
    PROCEDURE CA_MERGE_EVENT_COMMITMENT AS
    BEGIN
        MERGE INTO RCRA_CA_EVENT_COMMITMENT D
        USING (SELECT *
               FROM ETL_CA_EVENT_COMMITMENT_VW) S
        ON (D.CA_EVENT_COMMITMENT_ID = S.WH_CA_EVENT_COMMITMENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_EVENT_COMMITMENT_ID,
                    CA_EVENT_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_EVENT_COMMITMENT.NEXTVAL,
                    S.WH_CA_EVENT_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_AREA AS
    BEGIN
        MERGE INTO RCRA_CA_AREA D
        USING (SELECT *
               FROM ETL_CA_AREA_VW) S
        ON (D.CA_AREA_ID = S.WH_CA_AREA_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.AREA_SEQ_NUM                   = S.AREA_SEQ_NUM,
                D.FAC_WIDE_IND                   = S.FAC_WIDE_IND,
                D.AREA_NAME                      = S.AREA_NAME,
                D.AIR_REL_IND                    = S.AIR_REL_IND,
                D.GROUNDWATER_REL_IND            = S.GROUNDWATER_REL_IND,
                D.SOIL_REL_IND                   = S.SOIL_REL_IND,
                D.SURFACE_WATER_REL_IND          = S.SURFACE_WATER_REL_IND,
                D.REGULATED_UNIT_IND             = S.REGULATED_UNIT_IND,
                D.EPA_RESP_PERSON_DATA_OWNER_CDE = S.EPA_RESP_PERSON_DATA_OWNER_CDE,
                D.EPA_RESP_PERSON_ID             = S.EPA_RESP_PERSON_ID,
                D.STA_RESP_PERSON_DATA_OWNER_CDE = S.STA_RESP_PERSON_DATA_OWNER_CDE,
                D.STA_RESP_PERSON_ID             = S.STA_RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.AREA_SEQ_NUM, S.AREA_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.FAC_WIDE_IND, S.FAC_WIDE_IND, 0, 1) = 1
               OR DECODE(D.AREA_NAME, S.AREA_NAME, 0, 1) = 1
               OR DECODE(D.AIR_REL_IND, S.AIR_REL_IND, 0, 1) = 1
               OR DECODE(D.GROUNDWATER_REL_IND, S.GROUNDWATER_REL_IND, 0, 1) = 1
               OR DECODE(D.SOIL_REL_IND, S.SOIL_REL_IND, 0, 1) = 1
               OR DECODE(D.SURFACE_WATER_REL_IND, S.SURFACE_WATER_REL_IND, 0, 1) = 1
               OR DECODE(D.REGULATED_UNIT_IND, S.REGULATED_UNIT_IND, 0, 1) = 1
               OR DECODE(D.EPA_RESP_PERSON_DATA_OWNER_CDE, S.EPA_RESP_PERSON_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.EPA_RESP_PERSON_ID, S.EPA_RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.STA_RESP_PERSON_DATA_OWNER_CDE, S.STA_RESP_PERSON_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.STA_RESP_PERSON_ID, S.STA_RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AREA_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    AREA_SEQ_NUM,
                    FAC_WIDE_IND,
                    AREA_NAME,
                    AIR_REL_IND,
                    GROUNDWATER_REL_IND,
                    SOIL_REL_IND,
                    SURFACE_WATER_REL_IND,
                    REGULATED_UNIT_IND,
                    EPA_RESP_PERSON_DATA_OWNER_CDE,
                    EPA_RESP_PERSON_ID,
                    STA_RESP_PERSON_DATA_OWNER_CDE,
                    STA_RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_AREA.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.AREA_SEQ_NUM,
                    S.FAC_WIDE_IND,
                    S.AREA_NAME,
                    S.AIR_REL_IND,
                    S.GROUNDWATER_REL_IND,
                    S.SOIL_REL_IND,
                    S.SURFACE_WATER_REL_IND,
                    S.REGULATED_UNIT_IND,
                    S.EPA_RESP_PERSON_DATA_OWNER_CDE,
                    S.EPA_RESP_PERSON_ID,
                    S.STA_RESP_PERSON_DATA_OWNER_CDE,
                    S.STA_RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CA_MERGE_AREA_REL_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_AREA_REL_EVENT D
        USING (SELECT *
               FROM ETL_CA_AREA_REL_EVENT_VW) S
        ON (D.CA_AREA_REL_EVENT_ID = S.WH_CA_AREA_REL_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AREA_REL_EVENT_ID,
                    CA_AREA_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_AREA_REL_EVENT.NEXTVAL,
                    S.WH_CA_AREA_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_REL_PERMIT_UNIT AS
    BEGIN
        MERGE INTO RCRA_CA_REL_PERMIT_UNIT D
        USING (SELECT *
               FROM ETL_CA_REL_PERMIT_UNIT_VW) S
        ON (D.CA_REL_PERMIT_UNIT_ID = S.WH_CA_REL_PERMIT_UNIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.PERMIT_UNIT_SEQ_NUM = S.PERMIT_UNIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_REL_PERMIT_UNIT_ID,
                    CA_AREA_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_REL_PERMIT_UNIT.NEXTVAL,
                    S.WH_CA_AREA_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_AUTHORITY AS
    BEGIN
        MERGE INTO RCRA_CA_AUTHORITY D
        USING (SELECT *
               FROM ETL_CA_AUTHORITY_VW) S
        ON (D.CA_AUTHORITY_ID = S.WH_CA_AUTHORITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.AUTHORITY_DATA_OWNER_CODE      = S.AUTHORITY_DATA_OWNER_CODE,
                D.AUTHORITY_TYPE_CODE            = S.AUTHORITY_TYPE_CODE,
                D.AUTHORITY_AGN_CODE             = S.AUTHORITY_AGN_CODE,
                D.AUTHORITY_EFFC_DATE            = S.AUTHORITY_EFFC_DATE,
                D.ISSUE_DATE                     = S.ISSUE_DATE,
                D.END_DATE                       = S.END_DATE,
                D.ESTABLISHED_REPOSITORY_CODE    = S.ESTABLISHED_REPOSITORY_CODE,
                D.RESP_LEAD_PROG_IDEN            = S.RESP_LEAD_PROG_IDEN,
                D.AUTHORITY_SUBORG_DATA_OWNR_CDE = S.AUTHORITY_SUBORG_DATA_OWNR_CDE,
                D.AUTHORITY_SUBORG_CODE          = S.AUTHORITY_SUBORG_CODE,
                D.RESP_PERSON_DATA_OWNER_CODE    = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID                 = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.A_CREATED_DATE                 = S.A_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_DATA_OWNER_CODE, S.AUTHORITY_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_TYPE_CODE, S.AUTHORITY_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_AGN_CODE, S.AUTHORITY_AGN_CODE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_EFFC_DATE, S.AUTHORITY_EFFC_DATE, 0, 1) = 1
               OR DECODE(D.ISSUE_DATE, S.ISSUE_DATE, 0, 1) = 1
               OR DECODE(D.END_DATE, S.END_DATE, 0, 1) = 1
               OR DECODE(D.ESTABLISHED_REPOSITORY_CODE, S.ESTABLISHED_REPOSITORY_CODE, 0, 1) = 1
               OR DECODE(D.RESP_LEAD_PROG_IDEN, S.RESP_LEAD_PROG_IDEN, 0, 1) = 1
               OR DECODE(D.AUTHORITY_SUBORG_DATA_OWNR_CDE, S.AUTHORITY_SUBORG_DATA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.AUTHORITY_SUBORG_CODE, S.AUTHORITY_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.A_CREATED_DATE, S.A_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AUTHORITY_ID,
                    CA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    AUTHORITY_DATA_OWNER_CODE,
                    AUTHORITY_TYPE_CODE,
                    AUTHORITY_AGN_CODE,
                    AUTHORITY_EFFC_DATE,
                    ISSUE_DATE,
                    END_DATE,
                    ESTABLISHED_REPOSITORY_CODE,
                    RESP_LEAD_PROG_IDEN,
                    AUTHORITY_SUBORG_DATA_OWNR_CDE,
                    AUTHORITY_SUBORG_CODE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    A_CREATED_DATE,
                    DATA_ORIG,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_CA_AUTHORITY.NEXTVAL,
                    S.WH_CA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.AUTHORITY_DATA_OWNER_CODE,
                    S.AUTHORITY_TYPE_CODE,
                    S.AUTHORITY_AGN_CODE,
                    S.AUTHORITY_EFFC_DATE,
                    S.ISSUE_DATE,
                    S.END_DATE,
                    S.ESTABLISHED_REPOSITORY_CODE,
                    S.RESP_LEAD_PROG_IDEN,
                    S.AUTHORITY_SUBORG_DATA_OWNR_CDE,
                    S.AUTHORITY_SUBORG_CODE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.A_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE CA_MERGE_AUTH_REL_EVENT AS
    BEGIN
        MERGE INTO RCRA_CA_AUTH_REL_EVENT D
        USING (SELECT *
               FROM ETL_CA_AUTH_REL_EVENT_VW) S
        ON (D.CA_AUTH_REL_EVENT_ID = S.WH_CA_AUTH_REL_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.CORCT_ACT_EVENT_DATA_OWNER_CDE = S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                D.CORCT_ACT_EVENT_CODE           = S.CORCT_ACT_EVENT_CODE,
                D.EVENT_AGN_CODE                 = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                  = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_DATA_OWNER_CDE, S.CORCT_ACT_EVENT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.CORCT_ACT_EVENT_CODE, S.CORCT_ACT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_AUTH_REL_EVENT_ID,
                    CA_AUTHORITY_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    CORCT_ACT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_CA_AUTH_REL_EVENT.NEXTVAL,
                    S.WH_CA_AUTHORITY_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.CORCT_ACT_EVENT_DATA_OWNER_CDE,
                    S.CORCT_ACT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE CA_MERGE_STATUTORY_CITATION AS
    BEGIN
        MERGE INTO RCRA_CA_STATUTORY_CITATION D
        USING (SELECT *
               FROM ETL_CA_STATUTORY_CITATION_VW) S
        ON (D.CA_STATUTORY_CITATION_ID = S.WH_CA_STATUTORY_CITATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.STATUTORY_CITTION_DTA_OWNR_CDE = S.STATUTORY_CITTION_DTA_OWNR_CDE,
                D.STATUTORY_CITATION_IDEN        = S.STATUTORY_CITATION_IDEN
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.STATUTORY_CITTION_DTA_OWNR_CDE, S.STATUTORY_CITTION_DTA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.STATUTORY_CITATION_IDEN, S.STATUTORY_CITATION_IDEN, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (CA_STATUTORY_CITATION_ID,
                    CA_AUTHORITY_ID,
                    TRANS_CODE,
                    STATUTORY_CITTION_DTA_OWNR_CDE,
                    STATUTORY_CITATION_IDEN)
            VALUES (SEQ_RCRA_CA_STATUTORY_CITATION.NEXTVAL,
                    S.WH_CA_AUTHORITY_ID,
                    S.TRANS_CODE,
                    S.STATUTORY_CITTION_DTA_OWNR_CDE,
                    S.STATUTORY_CITATION_IDEN);
    END;

-- FA

    PROCEDURE FA_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'FA');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       FA_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_FA_FAC_SUBM_VW;
    END;

    PROCEDURE FA_MERGE_COST_EST_REL_MECH AS
    BEGIN
        MERGE INTO RCRA_FA_COST_EST_REL_MECHANISM D
        USING (SELECT *
               FROM ETL_FA_COST_EST_REL_MECH_VW) S
        ON (D.FA_COST_EST_REL_MECHANISM_ID = S.WH_FA_COST_EST_REL_MECH_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE               = S.TRANS_CODE,
                D.ACT_LOC_CODE             = S.ACT_LOC_CODE,
                D.MECHANISM_AGN_CODE       = S.MECHANISM_AGN_CODE,
                D.MECHANISM_SEQ_NUM        = S.MECHANISM_SEQ_NUM,
                D.MECHANISM_DETAIL_SEQ_NUM = S.MECHANISM_DETAIL_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_AGN_CODE, S.MECHANISM_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_SEQ_NUM, S.MECHANISM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_DETAIL_SEQ_NUM, S.MECHANISM_DETAIL_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_COST_EST_REL_MECHANISM_ID,
                    FA_COST_EST_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    MECHANISM_AGN_CODE,
                    MECHANISM_SEQ_NUM,
                    MECHANISM_DETAIL_SEQ_NUM)
            VALUES (SEQ_RCRA_FA_COST_EST_REL_MECH.NEXTVAL,
                    S.WH_FA_COST_EST_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.MECHANISM_AGN_CODE,
                    S.MECHANISM_SEQ_NUM,
                    S.MECHANISM_DETAIL_SEQ_NUM);
    END;

    PROCEDURE FA_MERGE_COST_EST AS
    BEGIN
        MERGE INTO RCRA_FA_COST_EST D
        USING (SELECT *
               FROM ETL_FA_COST_EST_VW) S
        ON (D.FA_COST_EST_ID = S.WH_FA_COST_EST_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.ACT_LOC_CODE                = S.ACT_LOC_CODE,
                D.COST_ESTIMATE_TYPE_CODE     = S.COST_ESTIMATE_TYPE_CODE,
                D.COST_ESTIMATE_AGN_CODE      = S.COST_ESTIMATE_AGN_CODE,
                D.COST_ESTIMATE_SEQ_NUM       = S.COST_ESTIMATE_SEQ_NUM,
                D.RESP_PERSON_DATA_OWNER_CODE = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID              = S.RESP_PERSON_ID,
                D.COST_ESTIMATE_AMOUNT        = S.COST_ESTIMATE_AMOUNT,
                D.COST_ESTIMATE_DATE          = S.COST_ESTIMATE_DATE,
                D.COST_ESTIMATE_RSN_CODE      = S.COST_ESTIMATE_RSN_CODE,
                D.AREA_UNIT_NOTES_TXT         = S.AREA_UNIT_NOTES_TXT,
                D.SUPP_INFO_TXT               = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.F_CREATED_DATE              = S.F_CREATED_DATE,
                D.DATA_ORIG                   = S.DATA_ORIG,
                D.UPDATE_DUE_DATE             = S.UPDATE_DUE_DATE,
                D.CURRENT_COST_ESTIMATE_IND   = S.CURRENT_COST_ESTIMATE_IND,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_TYPE_CODE, S.COST_ESTIMATE_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_AGN_CODE, S.COST_ESTIMATE_AGN_CODE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_SEQ_NUM, S.COST_ESTIMATE_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_AMOUNT, S.COST_ESTIMATE_AMOUNT, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_DATE, S.COST_ESTIMATE_DATE, 0, 1) = 1
               OR DECODE(D.COST_ESTIMATE_RSN_CODE, S.COST_ESTIMATE_RSN_CODE, 0, 1) = 1
               OR DECODE(D.AREA_UNIT_NOTES_TXT, S.AREA_UNIT_NOTES_TXT, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.UPDATE_DUE_DATE, S.UPDATE_DUE_DATE, 0, 1) = 1
               OR DECODE(D.CURRENT_COST_ESTIMATE_IND, S.CURRENT_COST_ESTIMATE_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_COST_EST_ID,
                    FA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    COST_ESTIMATE_TYPE_CODE,
                    COST_ESTIMATE_AGN_CODE,
                    COST_ESTIMATE_SEQ_NUM,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    COST_ESTIMATE_AMOUNT,
                    COST_ESTIMATE_DATE,
                    COST_ESTIMATE_RSN_CODE,
                    AREA_UNIT_NOTES_TXT,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    UPDATE_DUE_DATE,
                    CURRENT_COST_ESTIMATE_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_COST_EST.NEXTVAL,
                    S.WH_FA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.COST_ESTIMATE_TYPE_CODE,
                    S.COST_ESTIMATE_AGN_CODE,
                    S.COST_ESTIMATE_SEQ_NUM,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.COST_ESTIMATE_AMOUNT,
                    S.COST_ESTIMATE_DATE,
                    S.COST_ESTIMATE_RSN_CODE,
                    S.AREA_UNIT_NOTES_TXT,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.UPDATE_DUE_DATE,
                    S.CURRENT_COST_ESTIMATE_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_MECHANISM_DETAIL AS
    BEGIN
        MERGE INTO RCRA_FA_MECHANISM_DETAIL D
        USING (SELECT *
               FROM ETL_FA_MECHANISM_DETAIL_VW) S
        ON (D.FA_MECHANISM_DETAIL_ID = S.WH_FA_MECHANISM_DETAIL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.MECHANISM_DETAIL_SEQ_NUM     = S.MECHANISM_DETAIL_SEQ_NUM,
                D.MECHANISM_IDEN_TXT           = S.MECHANISM_IDEN_TXT,
                D.FACE_VAL_AMOUNT              = S.FACE_VAL_AMOUNT,
                D.EFFC_DATE                    = S.EFFC_DATE,
                D.EXPIRATION_DATE              = S.EXPIRATION_DATE,
                D.SUPP_INFO_TXT                = S.SUPP_INFO_TXT,
                D.CURRENT_MECHANISM_DETAIL_IND = S.CURRENT_MECHANISM_DETAIL_IND,
                D.CREATED_BY_USERID            = S.CREATED_BY_USERID,
                D.F_CREATED_DATE               = S.F_CREATED_DATE,
                D.DATA_ORIG                    = S.DATA_ORIG,
                D.FAC_FACE_VAL_AMOUNT          = S.FAC_FACE_VAL_AMOUNT,
                D.ALT_IND                      = S.ALT_IND,
                D.LAST_UPDT_BY                 = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE               = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_DETAIL_SEQ_NUM, S.MECHANISM_DETAIL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_IDEN_TXT, S.MECHANISM_IDEN_TXT, 0, 1) = 1
               OR DECODE(D.FACE_VAL_AMOUNT, S.FACE_VAL_AMOUNT, 0, 1) = 1
               OR DECODE(D.EFFC_DATE, S.EFFC_DATE, 0, 1) = 1
               OR DECODE(D.EXPIRATION_DATE, S.EXPIRATION_DATE, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CURRENT_MECHANISM_DETAIL_IND, S.CURRENT_MECHANISM_DETAIL_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.FAC_FACE_VAL_AMOUNT, S.FAC_FACE_VAL_AMOUNT, 0, 1) = 1
               OR DECODE(D.ALT_IND, S.ALT_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_MECHANISM_DETAIL_ID,
                    FA_MECHANISM_ID,
                    TRANS_CODE,
                    MECHANISM_DETAIL_SEQ_NUM,
                    MECHANISM_IDEN_TXT,
                    FACE_VAL_AMOUNT,
                    EFFC_DATE,
                    EXPIRATION_DATE,
                    SUPP_INFO_TXT,
                    CURRENT_MECHANISM_DETAIL_IND,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    FAC_FACE_VAL_AMOUNT,
                    ALT_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_MECHANISM_DETAIL.NEXTVAL,
                    S.WH_FA_MECHANISM_ID,
                    S.TRANS_CODE,
                    S.MECHANISM_DETAIL_SEQ_NUM,
                    S.MECHANISM_IDEN_TXT,
                    S.FACE_VAL_AMOUNT,
                    S.EFFC_DATE,
                    S.EXPIRATION_DATE,
                    S.SUPP_INFO_TXT,
                    S.CURRENT_MECHANISM_DETAIL_IND,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.FAC_FACE_VAL_AMOUNT,
                    S.ALT_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_MECHANISM AS
    BEGIN
        MERGE INTO RCRA_FA_MECHANISM D
        USING (SELECT *
               FROM ETL_FA_MECHANISM_VW) S
        ON (D.FA_MECHANISM_ID = S.WH_FA_MECHANISM_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.ACT_LOC_CODE                   = S.ACT_LOC_CODE,
                D.MECHANISM_AGN_CODE             = S.MECHANISM_AGN_CODE,
                D.MECHANISM_SEQ_NUM              = S.MECHANISM_SEQ_NUM,
                D.MECHANISM_TYPE_DATA_OWNER_CODE = S.MECHANISM_TYPE_DATA_OWNER_CODE,
                D.MECHANISM_TYPE_CODE            = S.MECHANISM_TYPE_CODE,
                D.PROVIDER_TXT                   = S.PROVIDER_TXT,
                D.PROVIDER_FULL_CONTACT_NAME     = S.PROVIDER_FULL_CONTACT_NAME,
                D.TELE_NUM_TXT                   = S.TELE_NUM_TXT,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.F_CREATED_DATE                 = S.F_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.PROVIDER_CONTACT_EMAIL         = S.PROVIDER_CONTACT_EMAIL,
                D.ACTIVE_MECHANISM_IND           = S.ACTIVE_MECHANISM_IND,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_AGN_CODE, S.MECHANISM_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_SEQ_NUM, S.MECHANISM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MECHANISM_TYPE_DATA_OWNER_CODE, S.MECHANISM_TYPE_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.MECHANISM_TYPE_CODE, S.MECHANISM_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.PROVIDER_TXT, S.PROVIDER_TXT, 0, 1) = 1
               OR DECODE(D.PROVIDER_FULL_CONTACT_NAME, S.PROVIDER_FULL_CONTACT_NAME, 0, 1) = 1
               OR DECODE(D.TELE_NUM_TXT, S.TELE_NUM_TXT, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.F_CREATED_DATE, S.F_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.PROVIDER_CONTACT_EMAIL, S.PROVIDER_CONTACT_EMAIL, 0, 1) = 1
               OR DECODE(D.ACTIVE_MECHANISM_IND, S.ACTIVE_MECHANISM_IND, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (FA_MECHANISM_ID,
                    FA_FAC_SUBM_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    MECHANISM_AGN_CODE,
                    MECHANISM_SEQ_NUM,
                    MECHANISM_TYPE_DATA_OWNER_CODE,
                    MECHANISM_TYPE_CODE,
                    PROVIDER_TXT,
                    PROVIDER_FULL_CONTACT_NAME,
                    TELE_NUM_TXT,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    F_CREATED_DATE,
                    DATA_ORIG,
                    PROVIDER_CONTACT_EMAIL,
                    ACTIVE_MECHANISM_IND,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_FA_MECHANISM.NEXTVAL,
                    S.WH_FA_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.MECHANISM_AGN_CODE,
                    S.MECHANISM_SEQ_NUM,
                    S.MECHANISM_TYPE_DATA_OWNER_CODE,
                    S.MECHANISM_TYPE_CODE,
                    S.PROVIDER_TXT,
                    S.PROVIDER_FULL_CONTACT_NAME,
                    S.TELE_NUM_TXT,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.F_CREATED_DATE,
                    S.DATA_ORIG,
                    S.PROVIDER_CONTACT_EMAIL,
                    S.ACTIVE_MECHANISM_IND,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE FA_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_FA_FAC_SUBM D
        USING (SELECT *
               FROM ETL_FA_FAC_SUBM_VW) S
        ON (D.FA_FAC_SUBM_ID = S.WH_FA_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (D.FA_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_FA_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

-- PRM

    PROCEDURE PRM_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'PM');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       PRM_FAC_SUBM_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_PRM_FAC_SUBM_VW;
    END;

    PROCEDURE PRM_MERGE_RELATED_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_RELATED_EVENT D
        USING (SELECT *
               FROM ETL_PRM_REL_EVENT_VW) S
        ON (D.PRM_RELATED_EVENT_ID = S.WH_PRM_RELATED_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.ACT_LOC_CODE                 = S.ACT_LOC_CODE,
                D.PERMIT_SERIES_SEQ_NUM        = S.PERMIT_SERIES_SEQ_NUM,
                D.PERMIT_EVENT_DATA_OWNER_CODE = S.PERMIT_EVENT_DATA_OWNER_CODE,
                D.PERMIT_EVENT_CODE            = S.PERMIT_EVENT_CODE,
                D.EVENT_AGN_CODE               = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                = S.EVENT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_SEQ_NUM, S.PERMIT_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_DATA_OWNER_CODE, S.PERMIT_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_CODE, S.PERMIT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_RELATED_EVENT_ID,
                    PRM_UNIT_DETAIL_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    PERMIT_SERIES_SEQ_NUM,
                    PERMIT_EVENT_DATA_OWNER_CODE,
                    PERMIT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM)
            VALUES (SEQ_RCRA_PRM_RELATED_EVENT.NEXTVAL,
                    S.WH_PRM_UNIT_DETAIL_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.PERMIT_SERIES_SEQ_NUM,
                    S.PERMIT_EVENT_DATA_OWNER_CODE,
                    S.PERMIT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM);
    END;

    PROCEDURE PRM_MERGE_EVENT_COMMITMENT AS
    BEGIN
        MERGE INTO RCRA_PRM_EVENT_COMMITMENT D
        USING (SELECT *
               FROM ETL_PRM_EVENT_COMM_VW) S
        ON (D.PRM_EVENT_COMMITMENT_ID = S.WH_PRM_EVENT_COMMITMENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE     = S.TRANS_CODE,
                D.COMMIT_LEAD    = S.COMMIT_LEAD,
                D.COMMIT_SEQ_NUM = S.COMMIT_SEQ_NUM
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.COMMIT_LEAD, S.COMMIT_LEAD, 0, 1) = 1
               OR DECODE(D.COMMIT_SEQ_NUM, S.COMMIT_SEQ_NUM, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_EVENT_COMMITMENT_ID,
                    PRM_EVENT_ID,
                    TRANS_CODE,
                    COMMIT_LEAD,
                    COMMIT_SEQ_NUM)
            VALUES (SEQ_RCRA_PRM_EVENT_COMMITMENT.NEXTVAL,
                    S.WH_PRM_EVENT_ID,
                    S.TRANS_CODE,
                    S.COMMIT_LEAD,
                    S.COMMIT_SEQ_NUM);
    END;

    PROCEDURE PRM_MERGE_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_EVENT D
        USING (SELECT *
               FROM ETL_PRM_EVENT_VW) S
        ON (D.PRM_EVENT_ID = S.WH_PRM_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                   = S.TRANS_CODE,
                D.ACT_LOC_CODE                 = S.ACT_LOC_CODE,
                D.PERMIT_EVENT_DATA_OWNER_CODE = S.PERMIT_EVENT_DATA_OWNER_CODE,
                D.PERMIT_EVENT_CODE            = S.PERMIT_EVENT_CODE,
                D.EVENT_AGN_CODE               = S.EVENT_AGN_CODE,
                D.EVENT_SEQ_NUM                = S.EVENT_SEQ_NUM,
                D.ACTL_DATE                    = S.ACTL_DATE,
                D.ORIGINAL_SCHEDULE_DATE       = S.ORIGINAL_SCHEDULE_DATE,
                D.NEW_SCHEDULE_DATE            = S.NEW_SCHEDULE_DATE,
                D.RESP_PERSON_DATA_OWNER_CODE  = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID               = S.RESP_PERSON_ID,
                D.EVENT_SUBORG_DATA_OWNER_CODE = S.EVENT_SUBORG_DATA_OWNER_CODE,
                D.EVENT_SUBORG_CODE            = S.EVENT_SUBORG_CODE,
                D.SUPP_INFO_TXT                = S.SUPP_INFO_TXT,
                D.CREATED_BY_USERID            = S.CREATED_BY_USERID,
                D.P_CREATED_DATE               = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                 = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE               = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.ACT_LOC_CODE, S.ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_DATA_OWNER_CODE, S.PERMIT_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_EVENT_CODE, S.PERMIT_EVENT_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_AGN_CODE, S.EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SEQ_NUM, S.EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.ACTL_DATE, S.ACTL_DATE, 0, 1) = 1
               OR DECODE(D.ORIGINAL_SCHEDULE_DATE, S.ORIGINAL_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.NEW_SCHEDULE_DATE, S.NEW_SCHEDULE_DATE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_DATA_OWNER_CODE, S.EVENT_SUBORG_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_SUBORG_CODE, S.EVENT_SUBORG_CODE, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_EVENT_ID,
                    PRM_SERIES_ID,
                    TRANS_CODE,
                    ACT_LOC_CODE,
                    PERMIT_EVENT_DATA_OWNER_CODE,
                    PERMIT_EVENT_CODE,
                    EVENT_AGN_CODE,
                    EVENT_SEQ_NUM,
                    ACTL_DATE,
                    ORIGINAL_SCHEDULE_DATE,
                    NEW_SCHEDULE_DATE,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    EVENT_SUBORG_DATA_OWNER_CODE,
                    EVENT_SUBORG_CODE,
                    SUPP_INFO_TXT,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_EVENT.NEXTVAL,
                    S.WH_PRM_SERIES_ID,
                    S.TRANS_CODE,
                    S.ACT_LOC_CODE,
                    S.PERMIT_EVENT_DATA_OWNER_CODE,
                    S.PERMIT_EVENT_CODE,
                    S.EVENT_AGN_CODE,
                    S.EVENT_SEQ_NUM,
                    S.ACTL_DATE,
                    S.ORIGINAL_SCHEDULE_DATE,
                    S.NEW_SCHEDULE_DATE,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.EVENT_SUBORG_DATA_OWNER_CODE,
                    S.EVENT_SUBORG_CODE,
                    S.SUPP_INFO_TXT,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_MOD_EVENT AS
    BEGIN
        MERGE INTO RCRA_PRM_MOD_EVENT D
        USING (SELECT *
               FROM ETL_PRM_MOD_EVENT_VW) S
        ON (D.PRM_MOD_EVENT_ID = S.WH_PRM_MOD_EVENT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                = S.TRANS_CODE,
                D.MOD_HANDLER_ID            = S.MOD_HANDLER_ID,
                D.MOD_ACT_LOC_CODE          = S.MOD_ACT_LOC_CODE,
                D.MOD_SERIES_SEQ_NUM        = S.MOD_SERIES_SEQ_NUM,
                D.MOD_EVENT_SEQ_NUM         = S.MOD_EVENT_SEQ_NUM,
                D.MOD_EVENT_AGN_CODE        = S.MOD_EVENT_AGN_CODE,
                D.MOD_EVENT_DATA_OWNER_CODE = S.MOD_EVENT_DATA_OWNER_CODE,
                D.MOD_EVENT_CODE            = S.MOD_EVENT_CODE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.MOD_HANDLER_ID, S.MOD_HANDLER_ID, 0, 1) = 1
               OR DECODE(D.MOD_ACT_LOC_CODE, S.MOD_ACT_LOC_CODE, 0, 1) = 1
               OR DECODE(D.MOD_SERIES_SEQ_NUM, S.MOD_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_SEQ_NUM, S.MOD_EVENT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_AGN_CODE, S.MOD_EVENT_AGN_CODE, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_DATA_OWNER_CODE, S.MOD_EVENT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.MOD_EVENT_CODE, S.MOD_EVENT_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_MOD_EVENT_ID,
                    PRM_EVENT_ID,
                    TRANS_CODE,
                    MOD_HANDLER_ID,
                    MOD_ACT_LOC_CODE,
                    MOD_SERIES_SEQ_NUM,
                    MOD_EVENT_SEQ_NUM,
                    MOD_EVENT_AGN_CODE,
                    MOD_EVENT_DATA_OWNER_CODE,
                    MOD_EVENT_CODE)
            VALUES (SEQ_RCRA_PRM_MOD_EVENT.NEXTVAL,
                    S.WH_PRM_EVENT_ID,
                    S.TRANS_CODE,
                    S.MOD_HANDLER_ID,
                    S.MOD_ACT_LOC_CODE,
                    S.MOD_SERIES_SEQ_NUM,
                    S.MOD_EVENT_SEQ_NUM,
                    S.MOD_EVENT_AGN_CODE,
                    S.MOD_EVENT_DATA_OWNER_CODE,
                    S.MOD_EVENT_CODE);
    END;

    PROCEDURE PRM_MERGE_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_PRM_WASTE_CODE D
        USING (SELECT *
               FROM ETL_PRM_WASTE_CODE_VW) S
        ON (D.PRM_WASTE_CODE_ID = S.WH_PRM_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_WASTE_CODE_ID,
                    PRM_UNIT_DETAIL_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE_TYPE)
            VALUES (SEQ_RCRA_PRM_WASTE_CODE.NEXTVAL,
                    S.WH_PRM_UNIT_DETAIL_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE_TYPE);
    END;

    PROCEDURE PRM_MERGE_UNIT_DETAIL AS
    BEGIN
        MERGE INTO RCRA_PRM_UNIT_DETAIL D
        USING (SELECT *
               FROM ETL_PRM_UNIT_DETAIL_VW) S
        ON (D.PRM_UNIT_DETAIL_ID = S.WH_PRM_UNIT_DETAIL_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                     = S.TRANS_CODE,
                D.PROC_UNIT_DATA_OWNER_CODE      = S.PROC_UNIT_DATA_OWNER_CODE,
                D.PROC_UNIT_CODE                 = S.PROC_UNIT_CODE,
                D.PERMIT_STAT_EFFC_DATE          = S.PERMIT_STAT_EFFC_DATE,
                D.PERMIT_UNIT_CAP_QNTY           = S.PERMIT_UNIT_CAP_QNTY,
                D.CAP_TYPE_CODE                  = S.CAP_TYPE_CODE,
                D.COMMER_STAT_CODE               = S.COMMER_STAT_CODE,
                D.LEGAL_OPER_STAT_DATA_OWNER_CDE = S.LEGAL_OPER_STAT_DATA_OWNER_CDE,
                D.LEGAL_OPER_STAT_CODE           = S.LEGAL_OPER_STAT_CODE,
                D.MEASUREMENT_UNIT_DATA_OWNR_CDE = S.MEASUREMENT_UNIT_DATA_OWNR_CDE,
                D.MEASUREMENT_UNIT_CODE          = S.MEASUREMENT_UNIT_CODE,
                D.NUM_OF_UNITS_COUNT             = S.NUM_OF_UNITS_COUNT,
                D.STANDARD_PERMIT_IND            = S.STANDARD_PERMIT_IND,
                D.SUPP_INFO_TXT                  = S.SUPP_INFO_TXT,
                D.CURRENT_UNIT_DETAIL_IND        = S.CURRENT_UNIT_DETAIL_IND,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.P_CREATED_DATE                 = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_DETAIL_SEQ_NUM, S.PERMIT_UNIT_DETAIL_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PROC_UNIT_DATA_OWNER_CODE, S.PROC_UNIT_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.PROC_UNIT_CODE, S.PROC_UNIT_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_STAT_EFFC_DATE, S.PERMIT_STAT_EFFC_DATE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_CAP_QNTY, S.PERMIT_UNIT_CAP_QNTY, 0, 1) = 1
               OR DECODE(D.CAP_TYPE_CODE, S.CAP_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.COMMER_STAT_CODE, S.COMMER_STAT_CODE, 0, 1) = 1
               OR DECODE(D.LEGAL_OPER_STAT_DATA_OWNER_CDE, S.LEGAL_OPER_STAT_DATA_OWNER_CDE, 0, 1) = 1
               OR DECODE(D.LEGAL_OPER_STAT_CODE, S.LEGAL_OPER_STAT_CODE, 0, 1) = 1
               OR DECODE(D.MEASUREMENT_UNIT_DATA_OWNR_CDE, S.MEASUREMENT_UNIT_DATA_OWNR_CDE, 0, 1) = 1
               OR DECODE(D.MEASUREMENT_UNIT_CODE, S.MEASUREMENT_UNIT_CODE, 0, 1) = 1
               OR DECODE(D.NUM_OF_UNITS_COUNT, S.NUM_OF_UNITS_COUNT, 0, 1) = 1
               OR DECODE(D.STANDARD_PERMIT_IND, S.STANDARD_PERMIT_IND, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.CURRENT_UNIT_DETAIL_IND, S.CURRENT_UNIT_DETAIL_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_UNIT_DETAIL_ID,
                    PRM_UNIT_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_DETAIL_SEQ_NUM,
                    PROC_UNIT_DATA_OWNER_CODE,
                    PROC_UNIT_CODE,
                    PERMIT_STAT_EFFC_DATE,
                    PERMIT_UNIT_CAP_QNTY,
                    CAP_TYPE_CODE,
                    COMMER_STAT_CODE,
                    LEGAL_OPER_STAT_DATA_OWNER_CDE,
                    LEGAL_OPER_STAT_CODE,
                    MEASUREMENT_UNIT_DATA_OWNR_CDE,
                    MEASUREMENT_UNIT_CODE,
                    NUM_OF_UNITS_COUNT,
                    STANDARD_PERMIT_IND,
                    SUPP_INFO_TXT,
                    CURRENT_UNIT_DETAIL_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_UNIT_DETAIL.NEXTVAL,
                    S.WH_PRM_UNIT_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_DETAIL_SEQ_NUM,
                    S.PROC_UNIT_DATA_OWNER_CODE,
                    S.PROC_UNIT_CODE,
                    S.PERMIT_STAT_EFFC_DATE,
                    S.PERMIT_UNIT_CAP_QNTY,
                    S.CAP_TYPE_CODE,
                    S.COMMER_STAT_CODE,
                    S.LEGAL_OPER_STAT_DATA_OWNER_CDE,
                    S.LEGAL_OPER_STAT_CODE,
                    S.MEASUREMENT_UNIT_DATA_OWNR_CDE,
                    S.MEASUREMENT_UNIT_CODE,
                    S.NUM_OF_UNITS_COUNT,
                    S.STANDARD_PERMIT_IND,
                    S.SUPP_INFO_TXT,
                    S.CURRENT_UNIT_DETAIL_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_UNIT AS
    BEGIN
        MERGE INTO RCRA_PRM_UNIT D
        USING (SELECT *
               FROM ETL_PRM_UNIT_VW) S
        ON (D.PRM_UNIT_ID = S.WH_PRM_UNIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE          = S.TRANS_CODE,
                D.PERMIT_UNIT_SEQ_NUM = S.PERMIT_UNIT_SEQ_NUM,
                D.PERMIT_UNIT_NAME    = S.PERMIT_UNIT_NAME,
                D.SUPP_INFO_TXT       = S.SUPP_INFO_TXT,
                D.ACTIVE_UNIT_IND     = S.ACTIVE_UNIT_IND,
                D.CREATED_BY_USERID   = S.CREATED_BY_USERID,
                D.P_CREATED_DATE      = S.P_CREATED_DATE,
                D.LAST_UPDT_BY        = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE      = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_SEQ_NUM, S.PERMIT_UNIT_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_UNIT_NAME, S.PERMIT_UNIT_NAME, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.ACTIVE_UNIT_IND, S.ACTIVE_UNIT_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_UNIT_ID,
                    PRM_FAC_SUBM_ID,
                    TRANS_CODE,
                    PERMIT_UNIT_SEQ_NUM,
                    PERMIT_UNIT_NAME,
                    SUPP_INFO_TXT,
                    ACTIVE_UNIT_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_UNIT.NEXTVAL,
                    S.WH_PRM_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.PERMIT_UNIT_SEQ_NUM,
                    S.PERMIT_UNIT_NAME,
                    S.SUPP_INFO_TXT,
                    S.ACTIVE_UNIT_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_SERIES AS
    BEGIN
        MERGE INTO RCRA_PRM_SERIES D
        USING (SELECT *
               FROM ETL_PRM_SERIES_VW) S
        ON (D.PRM_SERIES_ID = S.WH_PRM_SERIES_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                  = S.TRANS_CODE,
                D.PERMIT_SERIES_SEQ_NUM       = S.PERMIT_SERIES_SEQ_NUM,
                D.PERMIT_SERIES_NAME          = S.PERMIT_SERIES_NAME,
                D.RESP_PERSON_DATA_OWNER_CODE = S.RESP_PERSON_DATA_OWNER_CODE,
                D.RESP_PERSON_ID              = S.RESP_PERSON_ID,
                D.SUPP_INFO_TXT               = S.SUPP_INFO_TXT,
                D.ACTIVE_SERIES_IND           = S.ACTIVE_SERIES_IND,
                D.CREATED_BY_USERID           = S.CREATED_BY_USERID,
                D.P_CREATED_DATE              = S.P_CREATED_DATE,
                D.LAST_UPDT_BY                = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE              = S.LAST_UPDT_DATE
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_SEQ_NUM, S.PERMIT_SERIES_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.PERMIT_SERIES_NAME, S.PERMIT_SERIES_NAME, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_DATA_OWNER_CODE, S.RESP_PERSON_DATA_OWNER_CODE, 0, 1) = 1
               OR DECODE(D.RESP_PERSON_ID, S.RESP_PERSON_ID, 0, 1) = 1
               OR DECODE(D.SUPP_INFO_TXT, S.SUPP_INFO_TXT, 0, 1) = 1
               OR DECODE(D.ACTIVE_SERIES_IND, S.ACTIVE_SERIES_IND, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.P_CREATED_DATE, S.P_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (PRM_SERIES_ID,
                    PRM_FAC_SUBM_ID,
                    TRANS_CODE,
                    PERMIT_SERIES_SEQ_NUM,
                    PERMIT_SERIES_NAME,
                    RESP_PERSON_DATA_OWNER_CODE,
                    RESP_PERSON_ID,
                    SUPP_INFO_TXT,
                    ACTIVE_SERIES_IND,
                    CREATED_BY_USERID,
                    P_CREATED_DATE,
                    LAST_UPDT_BY,
                    LAST_UPDT_DATE)
            VALUES (SEQ_RCRA_PRM_SERIES.NEXTVAL,
                    S.WH_PRM_FAC_SUBM_ID,
                    S.TRANS_CODE,
                    S.PERMIT_SERIES_SEQ_NUM,
                    S.PERMIT_SERIES_NAME,
                    S.RESP_PERSON_DATA_OWNER_CODE,
                    S.RESP_PERSON_ID,
                    S.SUPP_INFO_TXT,
                    S.ACTIVE_SERIES_IND,
                    S.CREATED_BY_USERID,
                    S.P_CREATED_DATE,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE);
    END;

    PROCEDURE PRM_MERGE_FAC_SUBM AS
    BEGIN
        MERGE INTO RCRA_PRM_FAC_SUBM D
        USING (SELECT *
               FROM ETL_PRM_FAC_SUBM_VW) S
        ON (D.PRM_FAC_SUBM_ID = S.WH_PRM_FAC_SUBM_ID)
        WHEN NOT MATCHED THEN
            INSERT (PRM_FAC_SUBM_ID,
                    HANDLER_ID)
            VALUES (SEQ_RCRA_PRM_FAC_SUBM.NEXTVAL,
                    S.HANDLER_ID);
    END;

-- HD

    PROCEDURE HD_LOG_HANDLERS AS
        ETL_ID number;
    BEGIN
        ETL_ID := SEQ_ETL_RUN.NEXTVAL;
        INSERT INTO ETL_RUN
        (ETL_RUN_ID,
         RUN_DATE,
         ETL_TYPE)
        VALUES (ETL_ID,
                CURRENT_TIMESTAMP,
                'HD');
        INSERT INTO ETL_RUN_HANDLER
        (ETL_RUN_ID,
         HANDLER_ID,
         STATUS_TYPE)
        SELECT ETL_ID,
               HANDLER_ID,
               CASE
                   WHEN
                       HD_HBASIC_ID IS NULL
                       THEN
                       'I'
                   ELSE
                       'U'
                   END
        FROM ETL_HD_BASIC_VW;
    END;

    PROCEDURE HD_MERGE_HBASIC AS
    BEGIN
        MERGE INTO RCRA_HD_HBASIC D
        USING (SELECT *
               FROM ETL_HD_BASIC_VW) S
            --INNER JOIN NODE_RCRA_HD_HBASIC ON NODE_RCRA_HD_HBASIC.HANDLER_ID = ETL_HD_BASIC_VW.HANDLER_ID) S
        ON (D.HD_HBASIC_ID = S.WH_HD_HBASIC_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.FACILITY_IDENTIFIER = S.FACILITY_IDENTIFIER,
                D.EXTRACT_FLAG        = S.EXTRACT_FLAG,
                D.TRANSACTION_CODE    = S.TRANSACTION_CODE
            WHERE DECODE(D.FACILITY_IDENTIFIER, S.FACILITY_IDENTIFIER, 0, 1) = 1
               OR DECODE(D.EXTRACT_FLAG, S.EXTRACT_FLAG, 0, 1) = 1
               OR DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT
            (HD_HBASIC_ID,
             TRANSACTION_CODE,
             HANDLER_ID,
             EXTRACT_FLAG,
             FACILITY_IDENTIFIER)
            VALUES (SEQ_RCRA_HD_HBASIC.NEXTVAL,
                    S.TRANSACTION_CODE,
                    S.HANDLER_ID,
                    S.EXTRACT_FLAG,
                    S.FACILITY_IDENTIFIER);
    END;

    PROCEDURE HD_MERGE_HANDLER AS
    BEGIN
        MERGE INTO RCRA_HD_HANDLER D
        USING (SELECT *
               FROM ETL_HD_HANDLER_VW) S
        ON (D.HD_HANDLER_ID = S.WH_HD_HANDLER_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE               = S.TRANSACTION_CODE,
                D.ACTIVITY_LOCATION              = S.ACTIVITY_LOCATION,
                D.SOURCE_TYPE                    = S.SOURCE_TYPE,
                D.RECEIVE_DATE                   = S.RECEIVE_DATE,
                D.HANDLER_NAME                   = S.HANDLER_NAME,
                D.ACKNOWLEDGE_DATE               = S.ACKNOWLEDGE_DATE,
                D.NON_NOTIFIER                   = S.NON_NOTIFIER,
                D.OFF_SITE_RECEIPT               = S.OFF_SITE_RECEIPT,
                D.ACCESSIBILITY                  = S.ACCESSIBILITY,
                D.COUNTY_CODE_OWNER              = S.COUNTY_CODE_OWNER,
                D.COUNTY_CODE                    = S.COUNTY_CODE,
                D.NOTES                          = S.NOTES,
                D.ACKNOWLEDGE_FLAG               = S.ACKNOWLEDGE_FLAG,
                D.LOCATION_STREET1               = S.LOCATION_STREET1,
                D.LOCATION_STREET2               = S.LOCATION_STREET2,
                D.LOCATION_CITY                  = S.LOCATION_CITY,
                D.LOCATION_STATE                 = S.LOCATION_STATE,
                D.LOCATION_COUNTRY               = S.LOCATION_COUNTRY,
                D.LOCATION_ZIP                   = S.LOCATION_ZIP,
                D.MAIL_STREET1                   = S.MAIL_STREET1,
                D.MAIL_STREET2                   = S.MAIL_STREET2,
                D.MAIL_CITY                      = S.MAIL_CITY,
                D.MAIL_STATE                     = S.MAIL_STATE,
                D.MAIL_COUNTRY                   = S.MAIL_COUNTRY,
                D.MAIL_ZIP                       = S.MAIL_ZIP,
                D.CONTACT_FIRST_NAME             = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL         = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME              = S.CONTACT_LAST_NAME,
                D.CONTACT_ORG_NAME               = S.CONTACT_ORG_NAME,
                D.CONTACT_TITLE                  = D.CONTACT_TITLE,
                D.CONTACT_EMAIL_ADDRESS          = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE                  = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT              = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX                    = S.CONTACT_FAX,
                D.CONTACT_STREET1                = S.CONTACT_STREET1,
                D.CONTACT_STREET2                = S.CONTACT_STREET2,
                D.CONTACT_CITY                   = S.CONTACT_CITY,
                D.CONTACT_STATE                  = S.CONTACT_STATE,
                D.CONTACT_COUNTRY                = S.CONTACT_COUNTRY,
                D.CONTACT_ZIP                    = S.CONTACT_ZIP,
                D.PCONTACT_FIRST_NAME            = S.PCONTACT_FIRST_NAME,
                D.PCONTACT_MIDDLE_NAME           = S.PCONTACT_MIDDLE_NAME,
                D.PCONTACT_LAST_NAME             = S.PCONTACT_LAST_NAME,
                D.PCONTACT_ORG_NAME              = S.PCONTACT_ORG_NAME,
                D.PCONTACT_TITLE                 = D.PCONTACT_TITLE,
                D.PCONTACT_EMAIL_ADDRESS         = S.PCONTACT_EMAIL_ADDRESS,
                D.PCONTACT_PHONE                 = S.PCONTACT_PHONE,
                D.PCONTACT_PHONE_EXT             = S.PCONTACT_PHONE_EXT,
                D.PCONTACT_FAX                   = S.PCONTACT_FAX,
                D.PCONTACT_STREET1               = S.PCONTACT_STREET1,
                D.PCONTACT_STREET2               = S.PCONTACT_STREET2,
                D.PCONTACT_CITY                  = S.PCONTACT_CITY,
                D.PCONTACT_STATE                 = S.PCONTACT_STATE,
                D.PCONTACT_COUNTRY               = S.PCONTACT_COUNTRY,
                D.PCONTACT_ZIP                   = S.PCONTACT_ZIP,
                D.USED_OIL_BURNER                = S.USED_OIL_BURNER,
                D.USED_OIL_PROCESSOR             = S.USED_OIL_PROCESSOR,
                D.USED_OIL_REFINER               = S.USED_OIL_REFINER,
                D.USED_OIL_MARKET_BURNER         = S.USED_OIL_MARKET_BURNER,
                D.USED_OIL_SPEC_MARKETER         = S.USED_OIL_SPEC_MARKETER,
                D.USED_OIL_TRANSFER_FACILITY     = S.USED_OIL_TRANSFER_FACILITY,
                D.USED_OIL_TRANSPORTER           = S.USED_OIL_TRANSPORTER,
                D.LAND_TYPE                      = S.LAND_TYPE,
                D.STATE_DISTRICT_OWNER           = S.STATE_DISTRICT_OWNER,
                D.STATE_DISTRICT                 = S.STATE_DISTRICT,
                D.IMPORTER_ACTIVITY              = S.IMPORTER_ACTIVITY,
                D.MIXED_WASTE_GENERATOR          = S.MIXED_WASTE_GENERATOR,
                D.RECYCLER_ACTIVITY              = S.RECYCLER_ACTIVITY,
                D.TRANSPORTER_ACTIVITY           = S.TRANSPORTER_ACTIVITY,
                D.TSD_ACTIVITY                   = S.TSD_ACTIVITY,
                D.UNDERGROUND_INJECTION_ACTIVITY = S.UNDERGROUND_INJECTION_ACTIVITY,
                D.ONSITE_BURNER_EXEMPTION        = S.ONSITE_BURNER_EXEMPTION,
                D.FURNACE_EXEMPTION              = S.FURNACE_EXEMPTION,
                D.SHORT_TERM_GEN_IND             = S.SHORT_TERM_GEN_IND,
                D.TRANSFER_FACILITY_IND          = S.TRANSFER_FACILITY_IND,
                D.COLLEGE_IND                    = S.COLLEGE_IND,
                D.HOSPITAL_IND                   = S.HOSPITAL_IND,
                D.NON_PROFIT_IND                 = S.NON_PROFIT_IND,
                D.WITHDRAWAL_IND                 = S.WITHDRAWAL_IND,
                D.TRANS_CODE                     = S.TRANS_CODE,
                D.NOTIFICATION_RSN_CODE          = S.NOTIFICATION_RSN_CODE,
                D.EFFC_DATE                      = S.EFFC_DATE,
                D.FINANCIAL_ASSURANCE_IND        = S.FINANCIAL_ASSURANCE_IND,
                D.RECYCLING_IND                  = S.RECYCLING_IND,
                D.MAIL_STREET_NUMBER             = S.MAIL_STREET_NUMBER,
                D.LOCATION_STREET_NUMBER         = S.LOCATION_STREET_NUMBER,
                D.NON_NOTIFIER_TEXT              = S.NON_NOTIFIER_TEXT,
                D.ACCESSIBILITY_TEXT             = S.ACCESSIBILITY_TEXT,
                D.STATE_DISTRICT_TEXT            = S.STATE_DISTRICT_TEXT,
                D.INTRNL_NOTES                   = S.INTRNL_NOTES,
                D.SHORT_TERM_INTRNL_NOTES        = S.SHORT_TERM_INTRNL_NOTES,
                D.NATURE_OF_BUSINESS_TEXT        = S.NATURE_OF_BUSINESS_TEXT,
                D.SLAB_EXPORTER_IND              = S.SLAB_EXPORTER_IND,
                D.SLAB_IMPORTER_IND              = S.SLAB_IMPORTER_IND,
                D.RECOGNIZED_TRADER_EXPORTER_IND = S.RECOGNIZED_TRADER_EXPORTER_IND,
                D.RECOGNIZED_TRADER_IMPORTER_IND = S.RECOGNIZED_TRADER_IMPORTER_IND,
                D.TSD_DATE                       = S.TSD_DATE,
                D.UNIVERSAL_WASTE_DEST_FACILITY  = S.UNIVERSAL_WASTE_DEST_FACILITY,
                D.STATE_WASTE_GENERATOR_OWNER    = S.STATE_WASTE_GENERATOR_OWNER,
                D.STATE_WASTE_GENERATOR          = S.STATE_WASTE_GENERATOR,
                D.FED_WASTE_GENERATOR_OWNER      = S.FED_WASTE_GENERATOR_OWNER,
                D.FED_WASTE_GENERATOR            = S.FED_WASTE_GENERATOR,
                D.ACKNOWLEDGE_FLAG_IND           = S.ACKNOWLEDGE_FLAG_IND,
                D.INCLUDE_IN_NATIONAL_REPORT_IND = S.INCLUDE_IN_NATIONAL_REPORT_IND,
                D.LQHUW_IND                      = S.LQHUW_IND,
                D.HD_REPORT_CYCLE_YEAR           = S.HD_REPORT_CYCLE_YEAR,
                D.HEALTHCARE_FAC                 = S.HEALTHCARE_FAC,
                D.REVERSE_DISTRIBUTOR            = S.REVERSE_DISTRIBUTOR,
                D.SUBPART_P_WITHDRAWAL           = S.SUBPART_P_WITHDRAWAL,
                D.RECYCLER_IND                   = S.RECYCLER_IND,
                D.CURRENT_RECORD                 = S.CURRENT_RECORD,
                D.CREATED_BY_USERID              = S.CREATED_BY_USERID,
                D.H_CREATED_DATE                 = S.H_CREATED_DATE,
                D.DATA_ORIG                      = S.DATA_ORIG,
                D.LOCATION_LATITUDE              = S.LOCATION_LATITUDE,
                D.LOCATION_LONGITUDE             = S.LOCATION_LONGITUDE,
                D.LOCATION_GIS_PRIM              = S.LOCATION_GIS_PRIM,
                D.LOCATION_GIS_ORIG              = S.LOCATION_GIS_ORIG,
                D.LAST_UPDT_BY                   = S.LAST_UPDT_BY,
                D.LAST_UPDT_DATE                 = S.LAST_UPDT_DATE,
                D.BR_EXEMPT_IND                  = S.BR_EXEMPT_IND
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.ACTIVITY_LOCATION, S.ACTIVITY_LOCATION, 0, 1) = 1
               OR DECODE(D.SOURCE_TYPE, S.SOURCE_TYPE, 0, 1) = 1
               OR DECODE(D.RECEIVE_DATE, S.RECEIVE_DATE, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_DATE, S.ACKNOWLEDGE_DATE, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER, S.NON_NOTIFIER, 0, 1) = 1
               OR DECODE(D.OFF_SITE_RECEIPT, S.OFF_SITE_RECEIPT, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY, S.ACCESSIBILITY, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE_OWNER, S.COUNTY_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.COUNTY_CODE, S.COUNTY_CODE, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_FLAG, S.ACKNOWLEDGE_FLAG, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET1, S.LOCATION_STREET1, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET2, S.LOCATION_STREET2, 0, 1) = 1
               OR DECODE(D.LOCATION_CITY, S.LOCATION_CITY, 0, 1) = 1
               OR DECODE(D.LOCATION_STATE, S.LOCATION_STATE, 0, 1) = 1
               OR DECODE(D.LOCATION_COUNTRY, S.LOCATION_COUNTRY, 0, 1) = 1
               OR DECODE(D.LOCATION_ZIP, S.LOCATION_ZIP, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_COUNTRY, S.MAIL_COUNTRY, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_ORG_NAME, S.CONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET1, S.CONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.CONTACT_STREET2, S.CONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.CONTACT_CITY, S.CONTACT_CITY, 0, 1) = 1
               OR DECODE(D.CONTACT_STATE, S.CONTACT_STATE, 0, 1) = 1
               OR DECODE(D.CONTACT_COUNTRY, S.CONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.CONTACT_ZIP, S.CONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.PCONTACT_FIRST_NAME, S.PCONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_MIDDLE_NAME, S.PCONTACT_MIDDLE_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_LAST_NAME, S.PCONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_ORG_NAME, S.PCONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.PCONTACT_TITLE, S.PCONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.PCONTACT_EMAIL_ADDRESS, S.PCONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.PCONTACT_PHONE, S.PCONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.PCONTACT_PHONE_EXT, S.PCONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.PCONTACT_FAX, S.PCONTACT_FAX, 0, 1) = 1
               OR DECODE(D.PCONTACT_STREET1, S.PCONTACT_STREET1, 0, 1) = 1
               OR DECODE(D.PCONTACT_STREET2, S.PCONTACT_STREET2, 0, 1) = 1
               OR DECODE(D.PCONTACT_CITY, S.PCONTACT_CITY, 0, 1) = 1
               OR DECODE(D.PCONTACT_STATE, S.PCONTACT_STATE, 0, 1) = 1
               OR DECODE(D.PCONTACT_COUNTRY, S.PCONTACT_COUNTRY, 0, 1) = 1
               OR DECODE(D.PCONTACT_ZIP, S.PCONTACT_ZIP, 0, 1) = 1
               OR DECODE(D.USED_OIL_BURNER, S.USED_OIL_BURNER, 0, 1) = 1
               OR DECODE(D.USED_OIL_PROCESSOR, S.USED_OIL_PROCESSOR, 0, 1) = 1
               OR DECODE(D.USED_OIL_REFINER, S.USED_OIL_REFINER, 0, 1) = 1
               OR DECODE(D.USED_OIL_MARKET_BURNER, S.USED_OIL_MARKET_BURNER, 0, 1) = 1
               OR DECODE(D.USED_OIL_SPEC_MARKETER, S.USED_OIL_SPEC_MARKETER, 0, 1) = 1
               OR DECODE(D.USED_OIL_TRANSFER_FACILITY, S.USED_OIL_TRANSFER_FACILITY, 0, 1) = 1
               OR DECODE(D.USED_OIL_TRANSPORTER, S.USED_OIL_TRANSPORTER, 0, 1) = 1
               OR DECODE(D.LAND_TYPE, S.LAND_TYPE, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_OWNER, S.STATE_DISTRICT_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT, S.STATE_DISTRICT, 0, 1) = 1
               OR DECODE(D.IMPORTER_ACTIVITY, S.IMPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.MIXED_WASTE_GENERATOR, S.MIXED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.RECYCLER_ACTIVITY, S.RECYCLER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TRANSPORTER_ACTIVITY, S.TRANSPORTER_ACTIVITY, 0, 1) = 1
               OR DECODE(D.TSD_ACTIVITY, S.TSD_ACTIVITY, 0, 1) = 1
               OR DECODE(D.UNDERGROUND_INJECTION_ACTIVITY, S.UNDERGROUND_INJECTION_ACTIVITY, 0, 1) = 1
               OR DECODE(D.ONSITE_BURNER_EXEMPTION, S.ONSITE_BURNER_EXEMPTION, 0, 1) = 1
               OR DECODE(D.FURNACE_EXEMPTION, S.FURNACE_EXEMPTION, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_GEN_IND, S.SHORT_TERM_GEN_IND, 0, 1) = 1
               OR DECODE(D.TRANSFER_FACILITY_IND, S.TRANSFER_FACILITY_IND, 0, 1) = 1
               OR DECODE(D.COLLEGE_IND, S.COLLEGE_IND, 0, 1) = 1
               OR DECODE(D.HOSPITAL_IND, S.HOSPITAL_IND, 0, 1) = 1
               OR DECODE(D.NON_PROFIT_IND, S.NON_PROFIT_IND, 0, 1) = 1
               OR DECODE(D.WITHDRAWAL_IND, S.WITHDRAWAL_IND, 0, 1) = 1
               OR DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.NOTIFICATION_RSN_CODE, S.NOTIFICATION_RSN_CODE, 0, 1) = 1
               OR DECODE(D.EFFC_DATE, S.EFFC_DATE, 0, 1) = 1
               OR DECODE(D.FINANCIAL_ASSURANCE_IND, S.FINANCIAL_ASSURANCE_IND, 0, 1) = 1
               OR DECODE(D.RECYCLING_IND, S.RECYCLING_IND, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.LOCATION_STREET_NUMBER, S.LOCATION_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.NON_NOTIFIER_TEXT, S.NON_NOTIFIER_TEXT, 0, 1) = 1
               OR DECODE(D.ACCESSIBILITY_TEXT, S.ACCESSIBILITY_TEXT, 0, 1) = 1
               OR DECODE(D.STATE_DISTRICT_TEXT, S.STATE_DISTRICT_TEXT, 0, 1) = 1
               OR DECODE(D.INTRNL_NOTES, S.STATE_DISTRICT_TEXT, 0, 1) = 1
               OR DECODE(D.SHORT_TERM_INTRNL_NOTES, S.SHORT_TERM_INTRNL_NOTES, 0, 1) = 1
               OR DECODE(D.NATURE_OF_BUSINESS_TEXT, S.NATURE_OF_BUSINESS_TEXT, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_EXPORTER_IND, S.RECOGNIZED_TRADER_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.RECOGNIZED_TRADER_IMPORTER_IND, S.RECOGNIZED_TRADER_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_EXPORTER_IND, S.SLAB_EXPORTER_IND, 0, 1) = 1
               OR DECODE(D.SLAB_IMPORTER_IND, S.SLAB_IMPORTER_IND, 0, 1) = 1
               OR DECODE(D.TSD_DATE, S.TSD_DATE, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_DEST_FACILITY, S.UNIVERSAL_WASTE_DEST_FACILITY, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR_OWNER, S.STATE_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_WASTE_GENERATOR, S.STATE_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR_OWNER, S.FED_WASTE_GENERATOR_OWNER, 0, 1) = 1
               OR DECODE(D.FED_WASTE_GENERATOR, S.FED_WASTE_GENERATOR, 0, 1) = 1
               OR DECODE(D.ACKNOWLEDGE_FLAG_IND, S.ACKNOWLEDGE_FLAG_IND, 0, 1) = 1
               OR DECODE(D.INCLUDE_IN_NATIONAL_REPORT_IND, S.INCLUDE_IN_NATIONAL_REPORT_IND, 0, 1) = 1
               OR DECODE(D.LQHUW_IND, S.LQHUW_IND, 0, 1) = 1
               OR DECODE(D.HD_REPORT_CYCLE_YEAR, S.HD_REPORT_CYCLE_YEAR, 0, 1) = 1
               OR DECODE(D.HEALTHCARE_FAC, S.HEALTHCARE_FAC, 0, 1) = 1
               OR DECODE(D.REVERSE_DISTRIBUTOR, S.REVERSE_DISTRIBUTOR, 0, 1) = 1
               OR DECODE(D.SUBPART_P_WITHDRAWAL, S.SUBPART_P_WITHDRAWAL, 0, 1) = 1
               OR DECODE(D.RECYCLER_IND, S.RECYCLER_IND, 0, 1) = 1
               OR DECODE(D.CURRENT_RECORD, S.CURRENT_RECORD, 0, 1) = 1
               OR DECODE(D.CREATED_BY_USERID, S.CREATED_BY_USERID, 0, 1) = 1
               OR DECODE(D.H_CREATED_DATE, S.H_CREATED_DATE, 0, 1) = 1
               OR DECODE(D.DATA_ORIG, S.DATA_ORIG, 0, 1) = 1
               OR DECODE(D.LOCATION_LATITUDE, S.LOCATION_LATITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_LONGITUDE, S.LOCATION_LONGITUDE, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_PRIM, S.LOCATION_GIS_PRIM, 0, 1) = 1
               OR DECODE(D.LOCATION_GIS_ORIG, S.LOCATION_GIS_ORIG, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_BY, S.LAST_UPDT_BY, 0, 1) = 1
               OR DECODE(D.LAST_UPDT_DATE, S.LAST_UPDT_DATE, 0, 1) = 1
               OR DECODE(D.BR_EXEMPT_IND, S.BR_EXEMPT_IND, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT
            (HD_HANDLER_ID,
             HD_HBASIC_ID,
             TRANSACTION_CODE,
             ACTIVITY_LOCATION,
             SEQ_NUMBER,
             SOURCE_TYPE,
             RECEIVE_DATE,
             HANDLER_NAME,
             ACKNOWLEDGE_DATE,
             NON_NOTIFIER,
             OFF_SITE_RECEIPT,
             ACCESSIBILITY,
             COUNTY_CODE_OWNER,
             COUNTY_CODE,
             NOTES,
             ACKNOWLEDGE_FLAG,
             LOCATION_STREET1,
             LOCATION_STREET2,
             LOCATION_CITY,
             LOCATION_STATE,
             LOCATION_COUNTRY,
             LOCATION_ZIP,
             MAIL_STREET1,
             MAIL_STREET2,
             MAIL_CITY,
             MAIL_STATE,
             MAIL_COUNTRY,
             MAIL_ZIP,
             CONTACT_FIRST_NAME,
             CONTACT_MIDDLE_INITIAL,
             CONTACT_LAST_NAME,
             CONTACT_ORG_NAME,
             CONTACT_TITLE,
             CONTACT_EMAIL_ADDRESS,
             CONTACT_PHONE,
             CONTACT_PHONE_EXT,
             CONTACT_FAX,
             CONTACT_STREET1,
             CONTACT_STREET2,
             CONTACT_CITY,
             CONTACT_STATE,
             CONTACT_COUNTRY,
             CONTACT_ZIP,
             PCONTACT_FIRST_NAME,
             PCONTACT_MIDDLE_NAME,
             PCONTACT_LAST_NAME,
             PCONTACT_ORG_NAME,
             PCONTACT_TITLE,
             PCONTACT_EMAIL_ADDRESS,
             PCONTACT_PHONE,
             PCONTACT_PHONE_EXT,
             PCONTACT_FAX,
             PCONTACT_STREET1,
             PCONTACT_STREET2,
             PCONTACT_CITY,
             PCONTACT_STATE,
             PCONTACT_COUNTRY,
             PCONTACT_ZIP,
             USED_OIL_BURNER,
             USED_OIL_PROCESSOR,
             USED_OIL_REFINER,
             USED_OIL_MARKET_BURNER,
             USED_OIL_SPEC_MARKETER,
             USED_OIL_TRANSFER_FACILITY,
             USED_OIL_TRANSPORTER,
             LAND_TYPE,
             STATE_DISTRICT_OWNER,
             STATE_DISTRICT,
             IMPORTER_ACTIVITY,
             MIXED_WASTE_GENERATOR,
             RECYCLER_ACTIVITY,
             TRANSPORTER_ACTIVITY,
             TSD_ACTIVITY,
             UNDERGROUND_INJECTION_ACTIVITY,
             ONSITE_BURNER_EXEMPTION,
             FURNACE_EXEMPTION,
             SHORT_TERM_GEN_IND,
             TRANSFER_FACILITY_IND,
             COLLEGE_IND,
             HOSPITAL_IND,
             NON_PROFIT_IND,
             WITHDRAWAL_IND,
             TRANS_CODE,
             NOTIFICATION_RSN_CODE,
             EFFC_DATE,
             FINANCIAL_ASSURANCE_IND,
             RECYCLING_IND,
             MAIL_STREET_NUMBER,
             LOCATION_STREET_NUMBER,
             NON_NOTIFIER_TEXT,
             ACCESSIBILITY_TEXT,
             STATE_DISTRICT_TEXT,
             INTRNL_NOTES,
             SHORT_TERM_INTRNL_NOTES,
             NATURE_OF_BUSINESS_TEXT,
             RECOGNIZED_TRADER_EXPORTER_IND,
             RECOGNIZED_TRADER_IMPORTER_IND,
             SLAB_EXPORTER_IND,
             SLAB_IMPORTER_IND,
             TSD_DATE,
             UNIVERSAL_WASTE_DEST_FACILITY,
             STATE_WASTE_GENERATOR_OWNER,
             STATE_WASTE_GENERATOR,
             FED_WASTE_GENERATOR_OWNER,
             FED_WASTE_GENERATOR,
             ACKNOWLEDGE_FLAG_IND,
             INCLUDE_IN_NATIONAL_REPORT_IND,
             LQHUW_IND,
             HD_REPORT_CYCLE_YEAR,
             HEALTHCARE_FAC,
             REVERSE_DISTRIBUTOR,
             SUBPART_P_WITHDRAWAL,
             RECYCLER_IND,
             CURRENT_RECORD,
             CREATED_BY_USERID,
             H_CREATED_DATE,
             DATA_ORIG,
             LOCATION_LATITUDE,
             LOCATION_LONGITUDE,
             LOCATION_GIS_PRIM,
             LOCATION_GIS_ORIG,
             LAST_UPDT_BY,
             LAST_UPDT_DATE,
             BR_EXEMPT_IND)
            VALUES (SEQ_RCRA_HD_HANDLER.NEXTVAL,
                    S.WH_HD_HBASIC_ID,
                    S.TRANSACTION_CODE,
                    S.ACTIVITY_LOCATION,
                    S.SEQ_NUMBER,
                    S.SOURCE_TYPE,
                    S.RECEIVE_DATE,
                    S.HANDLER_NAME,
                    S.ACKNOWLEDGE_DATE,
                    S.NON_NOTIFIER,
                    S.OFF_SITE_RECEIPT,
                    S.ACCESSIBILITY,
                    S.COUNTY_CODE_OWNER,
                    S.COUNTY_CODE,
                    S.NOTES,
                    S.ACKNOWLEDGE_FLAG,
                    s.LOCATION_STREET1,
                    S.LOCATION_STREET2,
                    S.LOCATION_CITY,
                    S.LOCATION_STATE,
                    S.LOCATION_COUNTRY,
                    S.LOCATION_ZIP,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_ORG_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX,
                    S.CONTACT_STREET1,
                    S.CONTACT_STREET2,
                    S.CONTACT_CITY,
                    S.CONTACT_STATE,
                    S.CONTACT_COUNTRY,
                    S.CONTACT_ZIP,
                    S.PCONTACT_FIRST_NAME,
                    S.PCONTACT_MIDDLE_NAME,
                    S.PCONTACT_LAST_NAME,
                    S.PCONTACT_ORG_NAME,
                    S.PCONTACT_TITLE,
                    S.PCONTACT_EMAIL_ADDRESS,
                    S.PCONTACT_PHONE,
                    S.PCONTACT_PHONE_EXT,
                    S.PCONTACT_FAX,
                    S.PCONTACT_STREET1,
                    S.PCONTACT_STREET2,
                    S.PCONTACT_CITY,
                    S.PCONTACT_STATE,
                    S.PCONTACT_COUNTRY,
                    S.PCONTACT_ZIP,
                    S.USED_OIL_BURNER,
                    S.USED_OIL_PROCESSOR,
                    S.USED_OIL_REFINER,
                    S.USED_OIL_MARKET_BURNER,
                    S.USED_OIL_SPEC_MARKETER,
                    S.USED_OIL_TRANSFER_FACILITY,
                    S.USED_OIL_TRANSPORTER,
                    S.LAND_TYPE,
                    S.STATE_DISTRICT_OWNER,
                    S.STATE_DISTRICT,
                    S.IMPORTER_ACTIVITY,
                    S.MIXED_WASTE_GENERATOR,
                    S.RECYCLER_ACTIVITY,
                    S.TRANSPORTER_ACTIVITY,
                    S.TSD_ACTIVITY,
                    S.UNDERGROUND_INJECTION_ACTIVITY,
                    S.ONSITE_BURNER_EXEMPTION,
                    S.FURNACE_EXEMPTION,
                    S.SHORT_TERM_GEN_IND,
                    S.TRANSFER_FACILITY_IND,
                    S.COLLEGE_IND,
                    S.HOSPITAL_IND,
                    S.NON_PROFIT_IND,
                    S.WITHDRAWAL_IND,
                    S.TRANS_CODE,
                    S.NOTIFICATION_RSN_CODE,
                    S.EFFC_DATE,
                    S.FINANCIAL_ASSURANCE_IND,
                    S.RECYCLING_IND,
                    S.MAIL_STREET_NUMBER,
                    S.LOCATION_STREET_NUMBER,
                    S.NON_NOTIFIER_TEXT,
                    S.ACCESSIBILITY_TEXT,
                    S.STATE_DISTRICT_TEXT,
                    S.INTRNL_NOTES,
                    S.SHORT_TERM_INTRNL_NOTES,
                    S.NATURE_OF_BUSINESS_TEXT,
                    S.RECOGNIZED_TRADER_EXPORTER_IND,
                    S.RECOGNIZED_TRADER_IMPORTER_IND,
                    S.SLAB_EXPORTER_IND,
                    S.SLAB_IMPORTER_IND,
                    S.TSD_DATE,
                    S.UNIVERSAL_WASTE_DEST_FACILITY,
                    S.STATE_WASTE_GENERATOR_OWNER,
                    S.STATE_WASTE_GENERATOR,
                    S.FED_WASTE_GENERATOR_OWNER,
                    S.FED_WASTE_GENERATOR,
                    S.ACKNOWLEDGE_FLAG_IND,
                    S.INCLUDE_IN_NATIONAL_REPORT_IND,
                    S.LQHUW_IND,
                    S.HD_REPORT_CYCLE_YEAR,
                    S.HEALTHCARE_FAC,
                    S.REVERSE_DISTRIBUTOR,
                    S.SUBPART_P_WITHDRAWAL,
                    S.RECYCLER_IND,
                    S.CURRENT_RECORD,
                    S.CREATED_BY_USERID,
                    S.H_CREATED_DATE,
                    S.DATA_ORIG,
                    S.LOCATION_LATITUDE,
                    S.LOCATION_LONGITUDE,
                    S.LOCATION_GIS_PRIM,
                    S.LOCATION_GIS_ORIG,
                    S.LAST_UPDT_BY,
                    S.LAST_UPDT_DATE,
                    S.BR_EXEMPT_IND);
    END;

    PROCEDURE HD_MERGE_OTHER_ID AS
    BEGIN
        MERGE INTO RCRA_HD_OTHER_ID D
        USING (SELECT *
               FROM ETL_HD_OTHER_ID_VW) S
        ON (D.HD_OTHER_ID_ID = S.WH_HD_OTHER_ID_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE   = S.TRANSACTION_CODE,
                D.RELATIONSHIP_OWNER = S.RELATIONSHIP_OWNER,
                D.RELATIONSHIP_TYPE  = S.RELATIONSHIP_TYPE,
                D.SAME_FACILITY      = S.SAME_FACILITY,
                D.NOTES              = S.NOTES
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.RELATIONSHIP_OWNER, S.RELATIONSHIP_OWNER, 0, 1) = 1
               OR DECODE(D.RELATIONSHIP_TYPE, S.RELATIONSHIP_TYPE, 0, 1) = 1
               OR DECODE(D.SAME_FACILITY, S.SAME_FACILITY, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_OTHER_ID_ID,
                    HD_HBASIC_ID,
                    TRANSACTION_CODE,
                    OTHER_ID,
                    RELATIONSHIP_OWNER,
                    RELATIONSHIP_TYPE,
                    SAME_FACILITY,
                    NOTES)
            VALUES (SEQ_RCRA_HD_OTHER_ID.NEXTVAL,
                    S.WH_HD_HBASIC_ID,
                    S.TRANSACTION_CODE,
                    S.OTHER_ID,
                    S.RELATIONSHIP_OWNER,
                    S.RELATIONSHIP_TYPE,
                    S.SAME_FACILITY,
                    S.NOTES);
    END;

    PROCEDURE HD_MERGE_LQG_CLOSURE AS
    BEGIN
        MERGE INTO RCRA_HD_LQG_CLOSURE D
        USING (SELECT *
               FROM ETL_HD_LQG_CLOSURE) S
        ON (D.HD_LQG_CLOSURE_ID = S.WH_HD_LQG_CLOSURE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE      = S.TRANSACTION_CODE,
                D.CLOSURE_TYPE          = S.CLOSURE_TYPE,
                D.EXPECTED_CLOSURE_DATE = S.EXPECTED_CLOSURE_DATE,
                D.NEW_CLOSURE_DATE      = S.NEW_CLOSURE_DATE,
                D.DATE_CLOSED           = S.DATE_CLOSED,
                D.IN_COMPLIANCE_IND     = s.IN_COMPLIANCE_IND
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.CLOSURE_TYPE, S.CLOSURE_TYPE, 0, 1) = 1
               OR DECODE(D.EXPECTED_CLOSURE_DATE, S.EXPECTED_CLOSURE_DATE, 0, 1) = 1

               OR DECODE(D.NEW_CLOSURE_DATE, S.NEW_CLOSURE_DATE, 0, 1) = 1
               OR DECODE(D.DATE_CLOSED, S.DATE_CLOSED, 0, 1) = 1
               OR DECODE(D.IN_COMPLIANCE_IND, S.IN_COMPLIANCE_IND, 0, 1) = 1

        WHEN NOT MATCHED THEN
            INSERT (HD_LQG_CLOSURE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    CLOSURE_TYPE,
                    EXPECTED_CLOSURE_DATE,
                    NEW_CLOSURE_DATE,
                    DATE_CLOSED,
                    IN_COMPLIANCE_IND)
            VALUES (SEQ_RCRA_HD_LQG_CLOSURE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.CLOSURE_TYPE,
                    S.EXPECTED_CLOSURE_DATE,
                    S.NEW_CLOSURE_DATE,
                    S.DATE_CLOSED,
                    S.IN_COMPLIANCE_IND);
    END;

    PROCEDURE HD_MERGE_LQG_CONSOLIDATION AS
    BEGIN
        MERGE INTO RCRA_HD_LQG_CONSOLIDATION D
        USING (SELECT *
               FROM ETL_HD_LQG_CONSOLIDATION_VW) S
        ON (D.HD_LQG_CONSOLIDATION_ID = S.WH_HD_LQG_CONSOLIDATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE       = S.TRANSACTION_CODE,
                D.SEQ_NUMBER             = S.SEQ_NUMBER,
                D.HANDLER_ID             = S.HANDLER_ID,
                D.HANDLER_NAME           = S.HANDLER_NAME,
                D.MAIL_STREET_NUMBER     = S.MAIL_STREET_NUMBER,
                D.MAIL_STREET1           = S.MAIL_STREET1,
                D.MAIL_STREET2           = S.MAIL_STREET2,
                D.MAIL_CITY              = S.MAIL_CITY,
                D.MAIL_STATE             = S.MAIL_STATE,
                D.MAIL_COUNTRY           = S.MAIL_COUNTRY,
                D.MAIL_ZIP               = S.MAIL_ZIP,
                D.CONTACT_TITLE          = S.CONTACT_TITLE,
                D.CONTACT_FIRST_NAME     = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME      = S.CONTACT_LAST_NAME,
                D.CONTACT_EMAIL_ADDRESS  = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE          = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT      = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX            = S.CONTACT_FAX
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.HANDLER_ID, S.HANDLER_ID, 0, 1) = 1
               OR DECODE(D.HANDLER_NAME, S.HANDLER_NAME, 0, 1) = 1
               OR DECODE(D.MAIL_STREET_NUMBER, S.MAIL_STREET_NUMBER, 0, 1) = 1
               OR DECODE(D.MAIL_STREET1, S.MAIL_STREET1, 0, 1) = 1
               OR DECODE(D.MAIL_STREET2, S.MAIL_STREET2, 0, 1) = 1
               OR DECODE(D.MAIL_CITY, S.MAIL_CITY, 0, 1) = 1
               OR DECODE(D.MAIL_STATE, S.MAIL_STATE, 0, 1) = 1
               OR DECODE(D.MAIL_ZIP, S.MAIL_ZIP, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_LQG_CONSOLIDATION_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    SEQ_NUMBER,
                    HANDLER_ID,
                    HANDLER_NAME,
                    MAIL_STREET_NUMBER,
                    MAIL_STREET1,
                    MAIL_STREET2,
                    MAIL_CITY,
                    MAIL_STATE,
                    MAIL_COUNTRY,
                    MAIL_ZIP,
                    CONTACT_FIRST_NAME,
                    CONTACT_MIDDLE_INITIAL,
                    CONTACT_LAST_NAME,
                    CONTACT_TITLE,
                    CONTACT_EMAIL_ADDRESS,
                    CONTACT_PHONE,
                    CONTACT_PHONE_EXT,
                    CONTACT_FAX)
            VALUES (SEQ_RCRA_HD_LQG_CONSOLIDATION.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.SEQ_NUMBER,
                    S.HANDLER_ID,
                    S.HANDLER_NAME,
                    S.MAIL_STREET_NUMBER,
                    S.MAIL_STREET1,
                    S.MAIL_STREET2,
                    S.MAIL_CITY,
                    S.MAIL_STATE,
                    S.MAIL_COUNTRY,
                    S.MAIL_ZIP,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX);
    END;

    PROCEDURE HD_MERGE_EPISODIC_EVENT AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_EVENT D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_EVENT) S
        ON (D.HD_EPISODIC_EVENT_ID = S.WH_HD_EPISODIC_EVENT_ID)
        WHEN MATCHED
            THEN
            UPDATE
            SET D.TRANSACTION_CODE       = S.TRANSACTION_CODE,
                D.EVENT_OWNER            = S.EVENT_OWNER,
                D.EVENT_TYPE             = S.EVENT_TYPE,
                D.CONTACT_FIRST_NAME     = S.CONTACT_FIRST_NAME,
                D.CONTACT_MIDDLE_INITIAL = S.CONTACT_MIDDLE_INITIAL,
                D.CONTACT_LAST_NAME      = S.CONTACT_LAST_NAME,
                D.CONTACT_ORG_NAME       = S.CONTACT_ORG_NAME,
                D.CONTACT_TITLE          = S.CONTACT_TITLE,
                D.CONTACT_EMAIL_ADDRESS  = S.CONTACT_EMAIL_ADDRESS,
                D.CONTACT_PHONE          = S.CONTACT_PHONE,
                D.CONTACT_PHONE_EXT      = S.CONTACT_PHONE_EXT,
                D.CONTACT_FAX            = S.CONTACT_FAX,
                D.START_DATE             = S.START_DATE,
                D.END_DATE               = S.END_DATE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.EVENT_OWNER, S.EVENT_OWNER, 0, 1) = 1
               OR DECODE(D.EVENT_TYPE, S.EVENT_TYPE, 0, 1) = 1
               OR DECODE(D.CONTACT_FIRST_NAME, S.CONTACT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_MIDDLE_INITIAL, S.CONTACT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CONTACT_LAST_NAME, S.CONTACT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_ORG_NAME, S.CONTACT_ORG_NAME, 0, 1) = 1
               OR DECODE(D.CONTACT_TITLE, S.CONTACT_TITLE, 0, 1) = 1
               OR DECODE(D.CONTACT_EMAIL_ADDRESS, S.CONTACT_EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE, S.CONTACT_PHONE, 0, 1) = 1
               OR DECODE(D.CONTACT_PHONE_EXT, S.CONTACT_PHONE_EXT, 0, 1) = 1
               OR DECODE(D.CONTACT_FAX, S.CONTACT_FAX, 0, 1) = 1
               OR DECODE(D.START_DATE, S.START_DATE, 0, 1) = 1
               OR DECODE(D.END_DATE, S.END_DATE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_EVENT_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    EVENT_OWNER,
                    EVENT_TYPE,
                    CONTACT_FIRST_NAME,
                    CONTACT_MIDDLE_INITIAL,
                    CONTACT_LAST_NAME,
                    CONTACT_ORG_NAME,
                    CONTACT_TITLE,
                    CONTACT_EMAIL_ADDRESS,
                    CONTACT_PHONE,
                    CONTACT_PHONE_EXT,
                    CONTACT_FAX,
                    START_DATE,
                    END_DATE)
            VALUES (SEQ_RCRA_HD_EPISODIC_EVENT.nextval,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.EVENT_OWNER,
                    S.EVENT_TYPE,
                    S.CONTACT_FIRST_NAME,
                    S.CONTACT_MIDDLE_INITIAL,
                    S.CONTACT_LAST_NAME,
                    S.CONTACT_ORG_NAME,
                    S.CONTACT_TITLE,
                    S.CONTACT_EMAIL_ADDRESS,
                    S.CONTACT_PHONE,
                    S.CONTACT_PHONE_EXT,
                    S.CONTACT_FAX,
                    S.START_DATE,
                    S.END_DATE);
    END;

    PROCEDURE HD_MERGE_EPISODIC_WASTE AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_WASTE D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_WASTE) S
        ON (D.HD_EPISODIC_WASTE_ID = S.WH_HD_EPISODIC_WASTE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.SEQ_NUMBER       = S.SEQ_NUMBER,
                D.WASTE_DESC       = S.WASTE_DESC,
                D.EST_QNTY         = S.EST_QNTY
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.SEQ_NUMBER, S.SEQ_NUMBER, 0, 1) = 1
               OR DECODE(D.WASTE_DESC, S.WASTE_DESC, 0, 1) = 1
               OR DECODE(D.EST_QNTY, S.EST_QNTY, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_WASTE_ID,
                    HD_EPISODIC_EVENT_ID,
                    TRANSACTION_CODE,
                    SEQ_NUMBER,
                    WASTE_DESC,
                    EST_QNTY)
            VALUES (SEQ_RCRA_HD_EPISODIC_WASTE.nextval,
                    S.WH_HD_EPISODIC_EVENT_ID,
                    S.TRANSACTION_CODE,
                    S.SEQ_NUMBER,
                    S.WASTE_DESC,
                    S.EST_QNTY);
    END;

    PROCEDURE HD_MERGE_EPISODIC_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_WASTE_CODE) S
        ON (D.HD_EPISODIC_WASTE_CODE_ID = S.WH_HD_EPISODIC_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE       = S.WASTE_CODE,
                D.WASTE_CODE_TEXT  = S.WASTE_CODE_TEXT
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE, S.WASTE_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TEXT, S.WASTE_CODE_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_WASTE_CODE_ID,
                    HD_EPISODIC_WASTE_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE,
                    WASTE_CODE_TEXT)
            VALUES (SEQ_RCRA_HD_EPISODIC_WASTE_CD.nextval,
                    S.WH_HD_EPISODIC_WASTE_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE,
                    S.WASTE_CODE_TEXT);
    END;

    PROCEDURE HD_MERGE_SEC_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_SEC_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_SEC_WASTE_CD_VW) S
        ON (D.HD_SEC_WASTE_CODE_ID = S.WH_HD_SEC_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_SEC_WASTE_CODE_ID,
                    HD_SEC_MATERIAL_ACTIVITY_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_OWNER,
                    WASTE_CODE_TYPE)
            VALUES (SEQ_RCRA_HD_SEC_WASTE_CODE.NEXTVAL,
                    S.WH_HD_SEC_MATERIAL_ACTIVITY_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_OWNER,
                    S.WASTE_CODE_TYPE);
    END;

    PROCEDURE HD_MERGE_SEC_MATERIAL_ACTIVITY AS
    BEGIN
        MERGE INTO RCRA_HD_SEC_MATERIAL_ACTIVITY D
        USING (SELECT *
               FROM ETL_HD_SEC_MAT_ACT_VW) S
        ON (D.HD_SEC_MATERIAL_ACTIVITY_ID = S.WH_HD_SEC_MATERIAL_ACTIVITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANS_CODE                = S.TRANS_CODE,
                D.HSM_SEQ_NUM               = S.HSM_SEQ_NUM,
                D.FAC_CODE_OWNER_NAME       = S.FAC_CODE_OWNER_NAME,
                D.FAC_TYPE_CODE             = S.FAC_TYPE_CODE,
                D.ESTIMATED_SHORT_TONS_QNTY = S.ESTIMATED_SHORT_TONS_QNTY,
                D.ACTL_SHORT_TONS_QNTY      = S.ACTL_SHORT_TONS_QNTY,
                D.LAND_BASED_UNIT_IND       = S.LAND_BASED_UNIT_IND,
                D.LAND_BASED_UNIT_IND_TEXT  = S.LAND_BASED_UNIT_IND_TEXT
            WHERE DECODE(D.TRANS_CODE, S.TRANS_CODE, 0, 1) = 1
               OR DECODE(D.HSM_SEQ_NUM, S.HSM_SEQ_NUM, 0, 1) = 1
               OR DECODE(D.FAC_CODE_OWNER_NAME, S.FAC_CODE_OWNER_NAME, 0, 1) = 1
               OR DECODE(D.FAC_TYPE_CODE, S.FAC_TYPE_CODE, 0, 1) = 1
               OR DECODE(D.ESTIMATED_SHORT_TONS_QNTY, S.ESTIMATED_SHORT_TONS_QNTY, 0, 1) = 1
               OR DECODE(D.ACTL_SHORT_TONS_QNTY, S.ACTL_SHORT_TONS_QNTY, 0, 1) = 1
               OR DECODE(D.LAND_BASED_UNIT_IND, S.LAND_BASED_UNIT_IND, 0, 1) = 1
               OR DECODE(D.LAND_BASED_UNIT_IND_TEXT, S.LAND_BASED_UNIT_IND_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_SEC_MATERIAL_ACTIVITY_ID,
                    HD_HANDLER_ID,
                    TRANS_CODE,
                    HSM_SEQ_NUM,
                    FAC_CODE_OWNER_NAME,
                    FAC_TYPE_CODE,
                    ESTIMATED_SHORT_TONS_QNTY,
                    ACTL_SHORT_TONS_QNTY,
                    LAND_BASED_UNIT_IND,
                    LAND_BASED_UNIT_IND_TEXT)
            VALUES (SEQ_RCRA_HD_SEC_MATERIAL_ACT.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANS_CODE,
                    S.HSM_SEQ_NUM,
                    S.FAC_CODE_OWNER_NAME,
                    S.FAC_TYPE_CODE,
                    S.ESTIMATED_SHORT_TONS_QNTY,
                    S.ACTL_SHORT_TONS_QNTY,
                    S.LAND_BASED_UNIT_IND,
                    S.LAND_BASED_UNIT_IND_TEXT);
    END;

    PROCEDURE HD_MERGE_OWNEROP AS
    BEGIN
        MERGE INTO RCRA_HD_OWNEROP D
        USING (SELECT *
               FROM ETL_HD_OWNEROP_VW) S
        ON (D.HD_OWNEROP_ID = S.WH_HD_OWNEROP_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE    = S.TRANSACTION_CODE,
                D.OWNER_OP_IND        = S.OWNER_OP_IND,
                D.OWNER_OP_TYPE       = S.OWNER_OP_TYPE,
                D.DATE_BECAME_CURRENT = S.DATE_BECAME_CURRENT,
                D.DATE_ENDED_CURRENT  = S.DATE_ENDED_CURRENT,
                D.NOTES               = S.NOTES,
                D.FIRST_NAME          = S.FIRST_NAME,
                D.MIDDLE_INITIAL      = S.MIDDLE_INITIAL,
                D.LAST_NAME           = S.LAST_NAME,
                D.ORG_NAME            = S.ORG_NAME,
                D.TITLE               = S.TITLE,
                D.EMAIL_ADDRESS       = S.EMAIL_ADDRESS,
                D.PHONE               = S.PHONE,
                D.PHONE_EXT           = S.PHONE_EXT,
                D.FAX                 = S.FAX,
                D.MAIL_ADDR_NUM_TXT   = S.MAIL_ADDR_NUM_TXT,
                D.STREET1             = S.STREET1,
                D.STREET2             = S.STREET2,
                D.CITY                = S.CITY,
                D.STATE               = S.STATE,
                D.COUNTRY             = S.COUNTRY,
                D.ZIP                 = S.ZIP
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.OWNER_OP_SEQ, S.OWNER_OP_SEQ, 0, 1) = 1
               OR DECODE(D.OWNER_OP_IND, S.OWNER_OP_IND, 0, 1) = 1
               OR DECODE(D.OWNER_OP_TYPE, S.OWNER_OP_TYPE, 0, 1) = 1
               OR DECODE(D.DATE_BECAME_CURRENT, S.DATE_BECAME_CURRENT, 0, 1) = 1
               OR DECODE(D.DATE_ENDED_CURRENT, S.DATE_ENDED_CURRENT, 0, 1) = 1
               OR DECODE(D.NOTES, S.NOTES, 0, 1) = 1
               OR DECODE(D.FIRST_NAME, S.FIRST_NAME, 0, 1) = 1
               OR DECODE(D.MIDDLE_INITIAL, S.MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.LAST_NAME, S.LAST_NAME, 0, 1) = 1
               OR DECODE(D.ORG_NAME, S.ORG_NAME, 0, 1) = 1
               OR DECODE(D.TITLE, S.TITLE, 0, 1) = 1
               OR DECODE(D.EMAIL_ADDRESS, S.EMAIL_ADDRESS, 0, 1) = 1
               OR DECODE(D.PHONE, S.PHONE, 0, 1) = 1
               OR DECODE(D.PHONE_EXT, S.PHONE_EXT, 0, 1) = 1
               OR DECODE(D.FAX, S.FAX, 0, 1) = 1
               OR DECODE(D.MAIL_ADDR_NUM_TXT, S.MAIL_ADDR_NUM_TXT, 0, 1) = 1
               OR DECODE(D.STREET1, S.STREET1, 0, 1) = 1
               OR DECODE(D.STREET2, S.STREET2, 0, 1) = 1
               OR DECODE(D.CITY, S.CITY, 0, 1) = 1
               OR DECODE(D.STATE, S.STATE, 0, 1) = 1
               OR DECODE(D.COUNTRY, S.COUNTRY, 0, 1) = 1
               OR DECODE(D.ZIP, S.ZIP, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_OWNEROP_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    OWNER_OP_SEQ,
                    OWNER_OP_IND,
                    OWNER_OP_TYPE,
                    DATE_BECAME_CURRENT,
                    DATE_ENDED_CURRENT,
                    NOTES,
                    FIRST_NAME,
                    MIDDLE_INITIAL,
                    LAST_NAME,
                    ORG_NAME,
                    TITLE,
                    EMAIL_ADDRESS,
                    PHONE,
                    PHONE_EXT,
                    FAX,
                    MAIL_ADDR_NUM_TXT,
                    STREET1,
                    STREET2,
                    CITY,
                    STATE,
                    COUNTRY,
                    ZIP)
            VALUES (SEQ_RCRA_HD_OWNEROP.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.OWNER_OP_SEQ,
                    S.OWNER_OP_IND,
                    S.OWNER_OP_TYPE,
                    S.DATE_BECAME_CURRENT,
                    S.DATE_ENDED_CURRENT,
                    S.NOTES,
                    S.FIRST_NAME,
                    S.MIDDLE_INITIAL,
                    S.LAST_NAME,
                    S.ORG_NAME,
                    S.TITLE,
                    S.EMAIL_ADDRESS,
                    S.PHONE,
                    S.PHONE_EXT,
                    S.FAX,
                    S.MAIL_ADDR_NUM_TXT,
                    S.STREET1,
                    S.STREET2,
                    S.CITY,
                    S.STATE,
                    S.COUNTRY,
                    S.ZIP);
    END;

    PROCEDURE HD_MERGE_STATE_ACTIVITY AS
    BEGIN
        MERGE INTO RCRA_HD_STATE_ACTIVITY D
        USING (SELECT *
               FROM ETL_HD_STATE_ACT_VW) S
        ON (D.HD_STATE_ACTIVITY_ID = S.WH_HD_STATE_ACTIVITY_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE     = S.TRANSACTION_CODE,
                D.STATE_ACTIVITY_OWNER = S.STATE_ACTIVITY_OWNER,
                D.STATE_ACTIVITY_TYPE  = S.STATE_ACTIVITY_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.STATE_ACTIVITY_OWNER, S.STATE_ACTIVITY_OWNER, 0, 1) = 1
               OR DECODE(D.STATE_ACTIVITY_TYPE, S.STATE_ACTIVITY_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_STATE_ACTIVITY_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    STATE_ACTIVITY_OWNER,
                    STATE_ACTIVITY_TYPE)
            VALUES (SEQ_RCRA_HD_STATE_ACTIVITY.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.STATE_ACTIVITY_OWNER,
                    S.STATE_ACTIVITY_TYPE);
    END;

    PROCEDURE HD_MERGE_UNIVERSAL_WASTE AS
    BEGIN
        MERGE INTO RCRA_HD_UNIVERSAL_WASTE D
        USING (SELECT *
               FROM ETL_HD_UNIV_WASTE_VW) S
        ON (D.HD_UNIVERSAL_WASTE_ID = S.WH_HD_UNIVERSAL_WASTE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE      = S.TRANSACTION_CODE,
                D.UNIVERSAL_WASTE_OWNER = S.UNIVERSAL_WASTE_OWNER,
                D.UNIVERSAL_WASTE_TYPE  = S.UNIVERSAL_WASTE_TYPE,
                D.ACCUMULATED           = S.ACCUMULATED,
                D.GENERATED             = S.GENERATED
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_OWNER, S.UNIVERSAL_WASTE_OWNER, 0, 1) = 1
               OR DECODE(D.UNIVERSAL_WASTE_TYPE, S.UNIVERSAL_WASTE_TYPE, 0, 1) = 1
               OR DECODE(D.ACCUMULATED, S.ACCUMULATED, 0, 1) = 1
               OR DECODE(D.GENERATED, S.GENERATED, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_UNIVERSAL_WASTE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    UNIVERSAL_WASTE_OWNER,
                    UNIVERSAL_WASTE_TYPE,
                    ACCUMULATED,
                    GENERATED)
            VALUES (SEQ_RCRA_HD_UNIVERSAL_WASTE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.UNIVERSAL_WASTE_OWNER,
                    S.UNIVERSAL_WASTE_TYPE,
                    S.ACCUMULATED,
                    S.GENERATED);
    END;

    PROCEDURE HD_MERGE_WASTE_CODE AS
    BEGIN
        MERGE INTO RCRA_HD_WASTE_CODE D
        USING (SELECT *
               FROM ETL_HD_WASTE_CODE_VW) S
        ON (D.HD_WASTE_CODE_ID = S.WH_HD_WASTE_CODE_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.WASTE_CODE_OWNER = S.WASTE_CODE_OWNER,
                D.WASTE_CODE_TYPE  = S.WASTE_CODE_TYPE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_OWNER, S.WASTE_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.WASTE_CODE_TYPE, S.WASTE_CODE_TYPE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_WASTE_CODE_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    WASTE_CODE_TYPE,
                    WASTE_CODE_OWNER)
            VALUES (SEQ_RCRA_HD_WASTE_CODE.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.WASTE_CODE_TYPE,
                    S.WASTE_CODE_OWNER);
    END;

    PROCEDURE HD_MERGE_ENV_PERMIT AS
    BEGIN
        MERGE INTO RCRA_HD_ENV_PERMIT D
        USING (SELECT *
               FROM ETL_HD_ENV_PERMIT_VW) S
        ON (D.HD_ENV_PERMIT_ID = S.WH_HD_ENV_PERMIT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE  = S.TRANSACTION_CODE,
                D.ENV_PERMIT_NUMBER = S.ENV_PERMIT_NUMBER,
                D.ENV_PERMIT_OWNER  = S.ENV_PERMIT_OWNER,
                D.ENV_PERMIT_TYPE   = S.ENV_PERMIT_TYPE,
                D.ENV_PERMIT_DESC   = S.ENV_PERMIT_DESC
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_NUMBER, S.ENV_PERMIT_NUMBER, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_OWNER, S.ENV_PERMIT_OWNER, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_TYPE, S.ENV_PERMIT_TYPE, 0, 1) = 1
               OR DECODE(D.ENV_PERMIT_DESC, S.ENV_PERMIT_DESC, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_ENV_PERMIT_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    ENV_PERMIT_NUMBER,
                    ENV_PERMIT_OWNER,
                    ENV_PERMIT_TYPE,
                    ENV_PERMIT_DESC)
            VALUES (SEQ_RCRA_HD_ENV_PERMIT.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.ENV_PERMIT_NUMBER,
                    S.ENV_PERMIT_OWNER,
                    S.ENV_PERMIT_TYPE,
                    S.ENV_PERMIT_DESC);
    END;

    PROCEDURE HD_MERGE_CERTIFICATION AS
    BEGIN
        MERGE INTO RCRA_HD_CERTIFICATION D
        USING (SELECT *
               FROM ETL_HD_CERT_VW) S
        ON (D.HD_CERTIFICATION_ID = S.WH_HD_CERTIFICATION_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE    = S.TRANSACTION_CODE,
                D.CERT_SIGNED_DATE    = S.CERT_SIGNED_DATE,
                D.CERT_TITLE          = S.CERT_TITLE,
                D.CERT_FIRST_NAME     = S.CERT_FIRST_NAME,
                D.CERT_MIDDLE_INITIAL = S.CERT_MIDDLE_INITIAL,
                D.CERT_LAST_NAME      = S.CERT_LAST_NAME,
                D.CERT_EMAIL_TEXT     = S.CERT_EMAIL_TEXT
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.CERT_SIGNED_DATE, S.CERT_SIGNED_DATE, 0, 1) = 1
               OR DECODE(D.CERT_TITLE, S.CERT_TITLE, 0, 1) = 1
               OR DECODE(D.CERT_FIRST_NAME, S.CERT_FIRST_NAME, 0, 1) = 1
               OR DECODE(D.CERT_MIDDLE_INITIAL, S.CERT_MIDDLE_INITIAL, 0, 1) = 1
               OR DECODE(D.CERT_LAST_NAME, S.CERT_LAST_NAME, 0, 1) = 1
               OR DECODE(D.CERT_EMAIL_TEXT, S.CERT_EMAIL_TEXT, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_CERTIFICATION_ID,
                    CERT_SEQ,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    CERT_SIGNED_DATE,
                    CERT_TITLE,
                    CERT_FIRST_NAME,
                    CERT_MIDDLE_INITIAL,
                    CERT_LAST_NAME,
                    CERT_EMAIL_TEXT)
            VALUES (SEQ_RCRA_HD_CERTIFICATION.NEXTVAL,
                    S.CERT_SEQ,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.CERT_SIGNED_DATE,
                    S.CERT_TITLE,
                    S.CERT_FIRST_NAME,
                    S.CERT_MIDDLE_INITIAL,
                    S.CERT_LAST_NAME,
                    S.CERT_EMAIL_TEXT);
    END;

    PROCEDURE HD_MERGE_NAICS AS
    BEGIN
        MERGE INTO RCRA_HD_NAICS D
        USING (SELECT *
               FROM ETL_HD_NAICS_VW) S
        ON (D.HD_NAICS_ID = S.WH_HD_NAICS_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.NAICS_OWNER      = S.NAICS_OWNER,
                D.NAICS_CODE       = S.NAICS_CODE
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.NAICS_OWNER, S.NAICS_OWNER, 0, 1) = 1
               OR DECODE(D.NAICS_CODE, S.NAICS_CODE, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_NAICS_ID,
                    HD_HANDLER_ID,
                    TRANSACTION_CODE,
                    NAICS_SEQ,
                    NAICS_OWNER,
                    NAICS_CODE)
            VALUES (SEQ_RCRA_HD_NAICS.NEXTVAL,
                    S.WH_HD_HANDLER_ID,
                    S.TRANSACTION_CODE,
                    S.NAICS_SEQ,
                    S.NAICS_OWNER,
                    S.NAICS_CODE);
    END;

    PROCEDURE HD_MERGE_EPISODIC_PRJT AS
    BEGIN
        MERGE INTO RCRA_HD_EPISODIC_PRJT D
        USING (SELECT *
               FROM ETL_HD_EPISODIC_PRJT) S
        ON (D.HD_EPISODIC_PRJT_ID = S.WH_HD_EPISODIC_PRJT_ID)
        WHEN MATCHED THEN
            UPDATE
            SET D.TRANSACTION_CODE = S.TRANSACTION_CODE,
                D.PRJT_CODE_OWNER  = S.PRJT_CODE_OWNER,
                D.PRJT_CODE        = S.PRJT_CODE,
                D.OTHER_PRJT_DESC  = S.OTHER_PRJT_DESC
            WHERE DECODE(D.TRANSACTION_CODE, S.TRANSACTION_CODE, 0, 1) = 1
               OR DECODE(D.PRJT_CODE_OWNER, S.PRJT_CODE_OWNER, 0, 1) = 1
               OR DECODE(D.PRJT_CODE, S.PRJT_CODE, 0, 1) = 1
               OR DECODE(D.OTHER_PRJT_DESC, S.OTHER_PRJT_DESC, 0, 1) = 1
        WHEN NOT MATCHED THEN
            INSERT (HD_EPISODIC_PRJT_ID,
                    HD_EPISODIC_EVENT_ID,
                    TRANSACTION_CODE,
                    PRJT_CODE_OWNER,
                    PRJT_CODE,
                    OTHER_PRJT_DESC)
            VALUES (SEQ_RCRA_HD_EPISODIC_PRJT.NEXTVAL,
                    S.WH_HD_EPISODIC_EVENT_ID,
                    S.TRANSACTION_CODE,
                    S.PRJT_CODE_OWNER,
                    S.PRJT_CODE,
                    S.OTHER_PRJT_DESC);
    END;

    PROCEDURE HD_MERGE_DATA AS
    BEGIN
        HD_LOG_HANDLERS;
        HD_MERGE_HBASIC;
        HD_MERGE_HANDLER;
        HD_MERGE_NAICS;
        HD_MERGE_CERTIFICATION;
        HD_MERGE_ENV_PERMIT;
        HD_MERGE_WASTE_CODE;
        HD_MERGE_UNIVERSAL_WASTE;
        HD_MERGE_STATE_ACTIVITY;
        HD_MERGE_OWNEROP;
        HD_MERGE_SEC_MATERIAL_ACTIVITY;
        HD_MERGE_SEC_WASTE_CODE;
        HD_MERGE_OTHER_ID;
        HD_MERGE_LQG_CLOSURE;
        HD_MERGE_LQG_CONSOLIDATION;
        HD_MERGE_EPISODIC_EVENT;
        HD_MERGE_EPISODIC_WASTE;
        HD_MERGE_EPISODIC_WASTE_CODE;
        HD_MERGE_EPISODIC_WASTE_CODE;
        HD_MERGE_EPISODIC_PRJT;
    END;

    PROCEDURE PRM_MERGE_DATA AS
    BEGIN
        PRM_LOG_HANDLERS;
        PRM_MERGE_FAC_SUBM;
        PRM_MERGE_SERIES;
        PRM_MERGE_UNIT;
        PRM_MERGE_UNIT_DETAIL;
        PRM_MERGE_WASTE_CODE;
        PRM_MERGE_EVENT;
        PRM_MERGE_EVENT_COMMITMENT;
        PRM_MERGE_RELATED_EVENT;
        PRM_MERGE_MOD_EVENT;
    END;

    PROCEDURE FA_MERGE_DATA AS
    BEGIN
        FA_LOG_HANDLERS;
        FA_MERGE_FAC_SUBM;
        FA_MERGE_MECHANISM;
        FA_MERGE_MECHANISM_DETAIL;
        FA_MERGE_COST_EST;
        FA_MERGE_COST_EST_REL_MECH;
    END;

    PROCEDURE CA_MERGE_DATA AS
    BEGIN
        CA_LOG_HANDLERS;
        CA_MERGE_FAC_SUBM;
        CA_MERGE_EVENT;
        CA_MERGE_EVENT_COMMITMENT;
        CA_MERGE_AREA;
        CA_MERGE_AREA_REL_EVENT;
        CA_MERGE_REL_PERMIT_UNIT;
        CA_MERGE_AUTHORITY;
        CA_MERGE_AUTH_REL_EVENT;
        CA_MERGE_STATUTORY_CITATION;
    END;

    PROCEDURE CME_DELETE_DATA AS
    BEGIN
        CME_DELETE_VIOL;
        CME_DELETE_ENFRC_ACT;
        CME_DELETE_EVAL;
    END;

    PROCEDURE CME_MERGE_DATA AS
    BEGIN
        CME_LOG_HANDLERS;
        CME_MERGE_FAC_SUBM;
        CME_MERGE_VIOL;
        CME_MERGE_CITATION;
        CME_MERGE_EVAL;
        CME_MERGE_EVAL_COMMIT;
        CME_MERGE_EVAL_VIOL;
        CME_MERGE_RQST;
        CME_MERGE_ENFRC_ACT;
        CME_MERGE_CSNY_DATE;
        CME_MERGE_MEDIA;
        CME_MERGE_MILESTONE;
        CME_MERGE_SUPP_ENVR_PRJT;
        CME_MERGE_VIOL_ENFRC;
        CME_MERGE_PNLTY;
        CME_MERGE_PYMT;
    END;

    PROCEDURE GIS_MERGE_DATA AS
    BEGIN
        GIS_LOG_HANDLERS;
        GIS_MERGE_FAC_SUBM;
        GIS_MERGE_RCRA_GIS_GEO_INFO;
    END;

    PROCEDURE CH_MERGE_DATA AS
    BEGIN
        CH_LOG_HANDLER;
        CH_MERGE_REPORT_UNIV;
    END;

    PROCEDURE EM_MERGE_DATA AS
    BEGIN
        EM_LOG_HANDLER;
        EM_MERGE_EMANIFEST;
        EM_MERGE_EMANIFEST_COMMENT;
        EM_MERGE_WASTE;
        EM_MERGE_STATE_WASTE_CODE_DESC;
        EM_MERGE_FED_WASTE_CODE_DESC;
        EM_MERGE_WASTE_COMMENT;
        EM_MERGE_TRANSPORTER;
        EM_MERGE_WASTE_CD_TRANS;
        EM_MERGE_WASTE_PCB; --- HERE
    END;

    PROCEDURE MERGE_DATA(TRANS_TYPE varchar) AS
    BEGIN
        CASE TRANS_TYPE
            WHEN 'CA'
                THEN CA_MERGE_DATA;
            WHEN 'CE'
                THEN CME_MERGE_DATA;
            WHEN 'FA'
                THEN FA_MERGE_DATA;
            WHEN 'GS'
                THEN GIS_MERGE_DATA;
            WHEN 'HD'
                THEN HD_MERGE_DATA;
            WHEN 'PM'
                THEN PRM_MERGE_DATA;
            WHEN 'CH'
                THEN CH_MERGE_DATA;
            WHEN 'EM'
                THEN EM_MERGE_DATA;
            WHEN 'CD'
                THEN CME_DELETE_DATA;
            ELSE DBMS_OUTPUT.PUT_LINE('No handler for transaction type: ' || TRANS_TYPE);
            END CASE;
    END;

END RCRAINFO_ETL;
/

drop procedure handle_db_action
/
