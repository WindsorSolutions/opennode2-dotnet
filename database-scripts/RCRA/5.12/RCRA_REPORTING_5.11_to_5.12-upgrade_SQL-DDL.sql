set nocount,
    xact_abort,
    quoted_identifier,
    ansi_nulls,
    ansi_padding,
    ansi_warnings,
    arithabort,
    concat_null_yields_null on;
set numeric_roundabort off;

/*
 * Create a temporary SP to update DB objects
 */
if object_id('tempdb..#handle_db_action') is null
    exec ('create procedure #handle_db_action as return 0;')
go

alter procedure #handle_db_action @type_code char(2),
                                  @obj_name varchar(200),
                                  @obj_def varchar(max),
                                  @target_name varchar(200),
                                  @log_level int = 0 as
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;
    declare @sql nvarchar(max);
    declare @execute_ind bit;

    if @log_level > 0
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'type_code = ' + coalesce(@type_code, '<None>') + ', '
            + 'obj_name = ' + coalesce(@obj_name, '<None>') + ', '
            + 'obj_def = ' + coalesce(@obj_def, '<None>') + ', '
            + 'target_name = ' + coalesce(@target_name, '<None>')

    select @execute_ind =
           case @type_code
               when 'DT' then iif(object_id(@obj_name) is not null, 1, 0)
               when 'DS' then iif(exists(select 1 from sys.synonyms s where s.name = @obj_name), 1, 0)
               when 'CT' then iif(object_id(@obj_name) is null, 1, 0)
               when 'CI' then iif(exists(select 1
                                         from sys.indexes
                                         where object_id = object_id(@target_name)
                                           and name = @obj_name), 0, 1)
               when 'CS' then iif(exists(select 1 from sys.synonyms s where s.name = @obj_name), 0, 1)
               when 'AC' then iif(exists(select 1
                                         from sys.columns
                                         where name = @obj_name
                                           and object_id = object_id(@target_name)), 0, 1)
               when 'DC' then iif(exists(select 1
                                         from sys.columns
                                         where name = @obj_name
                                           and object_id = object_id(@target_name)), 1, 0)
               when 'RC' then iif(exists(select 1
                                         from sys.columns
                                         where name = @obj_name
                                           and object_id = object_id(@target_name))
                                      and not exists(select 1
                                                     from sys.columns
                                                     where name = @obj_def
                                                       and object_id = object_id(@target_name)),
                                  1, 0)
               when 'MC' then iif(exists(select 1
                                         from sys.columns
                                         where name = @obj_name
                                           and object_id = object_id(@target_name)), 1, 0)
               when 'DV' then iif(object_id(@obj_name) is not null, 1, 0)
               when 'CV' then 1
               when 'DP' then iif(object_id(@obj_name) is not null, 1, 0)
               end

    select @sql =
           case @type_code
               when 'DT' then 'drop table ' + @obj_name
               when 'DS' then 'drop synonym ' + @obj_name
               when 'CT' then 'create table ' + @obj_name + '(' + @obj_def + ')'
               when 'CI' then 'create index ' + @obj_name + ' on ' + @target_name + '(' + @obj_def + ')'
               when 'CS' then 'create synonym dbo.' + @obj_name + ' for ' + @target_name
               when 'AC' then 'alter table ' + @target_name + ' add ' + @obj_name + ' ' + @obj_def
               when 'DC' then 'alter table ' + @target_name + ' drop column ' + @obj_name
               when 'RC' then 'sp_rename N''' + @target_name + '.' + @obj_name + ''', N''' + @obj_def +
                              ''', N''COLUMN'''
               when 'MC' then 'alter table ' + @target_name + ' alter column ' + @obj_name + ' ' + @obj_def
               when 'DV' then 'drop view ' + @obj_name
               when 'CV' then iif(object_id(@obj_name) is null,
                                  'create view ' + @obj_name + ' as ' + @obj_def,
                                  'alter view ' + @obj_name + ' as ' + @obj_def)
               when 'DP' then 'drop procedure ' + @obj_name
               end

    if @log_level > 0
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'execute_ind = ' + coalesce(cast(@execute_ind as varchar(10)), '<None>') + ', '
            + 'sql = ' + coalesce(@sql, '<None>')

    if @execute_ind = 1
        begin
            print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
                + 'Executing SQL: ' + coalesce(@sql, '<None>')
            exec (@sql)
        end
    else
        begin
            print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
                + 'Skipping execution of "' + coalesce(@sql, '<None>')
                + '" because the conditions to execute it are not met'
        end

end
go

declare @target_db varchar(100) = '[NODE_FLOW_RCRA]'

declare x cursor for
    select t.type_code, t.obj_name, t.obj_def, t.target_name
    from (values
              -- create tables
              (1, 'CT', 'dbo.RCRA_EM_FED_WASTE_CODE_DESC',
               'EM_FED_WASTE_CODE_DESC_ID int identity
                  constraint PK_EM_FED_WASTE_CODE_DESC primary key,
              EM_WASTE_ID int NOT NULL
                  constraint FK_RCRA_EM_FED_WASTE_CODE_DESC_EM_WASTE_ID references RCRA_EM_WASTE on delete cascade,
              FED_MANIFEST_WASTE_CODE varchar(6) NOT NULL,
              MANIFEST_WASTE_DESC varchar(2000) NULL,
              COI_IND char(1) NULL', null),
              (2, 'CT', 'dbo.RCRA_EM_STATE_WASTE_CODE_DESC',
               'EM_STATE_WASTE_CODE_DESC_ID int identity
                   constraint PK_EM_STATE_WASTE_CODE_DESC primary key,
               EM_WASTE_ID int NOT NULL
                   constraint FK_EM_STATE_WASTE_CODE_DESC_EM_WASTE_ID references RCRA_EM_WASTE on delete cascade,
               STA_MANIFEST_WASTE_CODE varchar(8) NOT NULL,
               MANIFEST_WASTE_DESC varchar(2000) NULL', null),
              (3, 'CT', 'dbo.RCRA_EM_TRANSPORTER',
               'EM_TRANSPORTER_ID int identity
                   constraint PK_EM_TRANSPORTER primary key,
               EM_EMANIFEST_ID int NOT NULL
                   constraint FK_RCRA_EM_TRANSPORTER_EM_EMANIFEST_ID references RCRA_EM_EMANIFEST on delete cascade,
               TRANSPORTER_ID varchar(15) NULL,
               TRANSPORTER_NAME varchar(80) NULL,
               TRANSPORTER_PRINTED_NAME varchar(80) NULL,
               TRANSPORTER_SIGNATURE_DATE datetime null,
               TRANSPORTER_ESIG_FIRST_NAME varchar(38) NULL,
               TRANSPORTER_ESIG_LAST_NAME varchar(38) NULL,
               TRANS_ESIG_SIGNATURE_DATE datetime null,
               TRANSPORTER_LINE_NUM varchar(19) NULL,
               TRANSPORTER_REGISTERED char(1) NULL', null),
              -- create indexes
              (4, 'CI', 'IX_EM_FD_WST_CDE_DSC_EM_WST_ID', 'EM_WASTE_ID', 'dbo.RCRA_EM_FED_WASTE_CODE_DESC'),
              (5, 'CI', 'IX_EM_STT_WST_CDE_DSC_EM_WS_ID', 'EM_WASTE_ID', 'dbo.RCRA_EM_STATE_WASTE_CODE_DESC'),
              (6, 'CI', 'IX_EM_TRNSPORTER_EM_EMNIFST_ID', 'EM_EMANIFEST_ID', 'dbo.RCRA_EM_TRANSPORTER'),
              -- drop synonyms
              (7, 'DS', 'NODE_RCRA_EM_WASTE_CD_TSDF', null, null),
              (8, 'DS', 'NODE_RCRA_EM_WASTE_CD_GEN', null, null),
              (9, 'DS', 'NODE_RCRA_EM_WASTE_CD_FED', null, null),
              (10, 'DS', 'NODE_RCRA_EM_TR_NUM_WASTE', null, null),
              (11, 'DS', 'NODE_RCRA_EM_TR_NUM_REJ', null, null),
              (12, 'DS', 'NODE_RCRA_EM_TR_NUM_ORIG', null, null),
              (13, 'DS', 'NODE_RCRA_EM_TR_NUM_RESIDUE_NEW', null, null),
              (14, 'DS', 'NODE_RCRA_EM_HANDLER', null, null),
              (15, 'DS', 'NODE_RCRA_EM_EMANIFEST', null, null),
              (16, 'DS', 'NODE_RCRA_EM_EMANIFEST_COMMENT', null, null),
              (17, 'DS', 'NODE_RCRA_EM_WASTE', null, null),
              (18, 'DS', 'NODE_RCRA_EM_WASTE_COMMENT', null, null),
              (19, 'DS', 'NODE_RCRA_EM_WASTE_PCB', null, null),
              -- create synonyms
              (20, 'CS', 'NODE_RCRA_EM_FED_WASTE_CODE_DESC', null, @target_db + '.dbo.RCRA_EM_FED_WASTE_CODE_DESC'),
              (21, 'CS', 'NODE_RCRA_EM_STATE_WASTE_CODE_DESC', null, @target_db + '.dbo.RCRA_EM_STATE_WASTE_CODE_DESC'),
              (22, 'CS', 'NODE_RCRA_EM_TRANSPORTER', null, @target_db + '.dbo.RCRA_EM_TRANSPORTER'),
              (23, 'CS', 'NODE_RCRA_EM_EMANIFEST', null, @target_db + '.dbo.RCRA_EM_EMANIFEST'),
              (24, 'CS', 'NODE_RCRA_EM_EMANIFEST_COMMENT', null, @target_db + '.dbo.RCRA_EM_EMANIFEST_COMMENT'),
              (25, 'CS', 'NODE_RCRA_EM_WASTE', null, @target_db + '.dbo.RCRA_EM_WASTE'),
              (26, 'CS', 'NODE_RCRA_EM_WASTE_COMMENT', null, @target_db + '.dbo.RCRA_EM_WASTE_COMMENT'),
              (27, 'CS', 'NODE_RCRA_EM_WASTE_PCB', null, @target_db + '.dbo.RCRA_EM_WASTE_PCB'),
              -- add column
              (28, 'AC', 'GENERATOR_ID', 'varchar(15)', 'dbo.RCRA_EM_EMANIFEST'),
              (29, 'AC', 'GENERATOR_NAME', 'varchar(80)', 'dbo.RCRA_EM_EMANIFEST'),
              (30, 'AC', 'GENERATOR_MAIL_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (31, 'AC', 'GENERATOR_MAIL_STREET_1', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (32, 'AC', 'GENERATOR_MAIL_STREET_2', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (33, 'AC', 'GENERATOR_MAIL_CITY', 'varchar(35) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (34, 'AC', 'GENERATOR_MAIL_CTRY', 'char(2)', 'dbo.RCRA_EM_EMANIFEST'),
              (35, 'AC', 'GENERATOR_MAIL_STA', 'char(2)', 'dbo.RCRA_EM_EMANIFEST'),
              (36, 'AC', 'GENERATOR_MAIL_ZIP', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (37, 'AC', 'GENERATOR_LOC_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (38, 'AC', 'GENERATOR_LOC_STREET_1', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (39, 'AC', 'GENERATOR_LOC_STREET_2', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (40, 'AC', 'GENERATOR_LOC_CITY', 'varchar(35) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (41, 'AC', 'GENERATOR_LOC_STA', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (42, 'AC', 'GENERATOR_LOC_ZIP', 'varchar(25) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (43, 'AC', 'GENERATOR_CONTACT_FIRST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (44, 'AC', 'GENERATOR_CONTACT_LAST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (45, 'AC', 'GENERATOR_CONTACT_COMPANY_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (46, 'AC', 'GENERATOR_CONTACT_EMAIL', 'varchar(80)', 'dbo.RCRA_EM_EMANIFEST'),
              (47, 'AC', 'GENERATOR_CONTACT_PHONE_NUM', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (48, 'AC', 'GENERATOR_CONTACT_PHONE_EXT', 'varchar(6) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (49, 'AC', 'GENERATOR_PRINTED_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (50, 'AC', 'GENERATOR_SIGNATURE_DATE', 'datetime', 'dbo.RCRA_EM_EMANIFEST'),
              (51, 'AC', 'GENERATOR_ESIG_FIRST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (52, 'AC', 'GENERATOR_ESIG_LAST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (53, 'AC', 'GENERATOR_ESIG_SIGNATURE_DATE', 'datetime', 'dbo.RCRA_EM_EMANIFEST'),
              (54, 'AC', 'GENERATOR_REGISTERED', 'char(1)', 'dbo.RCRA_EM_EMANIFEST'),
              (55, 'AC', 'GENERATOR_MODIFIED', 'char(1)', 'dbo.RCRA_EM_EMANIFEST'),
              (56, 'AC', 'DES_FAC_ID', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (57, 'AC', 'DES_FAC_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (58, 'AC', 'DES_FAC_MAIL_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (59, 'AC', 'DES_FAC_MAIL_STREET_1', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (60, 'AC', 'DES_FAC_MAIL_STREET_2', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (61, 'AC', 'DES_FAC_MAIL_CITY', 'varchar(35) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (62, 'AC', 'DES_FAC_MAIL_CTRY', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (63, 'AC', 'DES_FAC_MAIL_STA', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (64, 'AC', 'DES_FAC_MAIL_ZIP', 'varchar(25) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (65, 'AC', 'DES_FAC_LOC_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (66, 'AC', 'DES_FAC_LOC_STREET_1', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (67, 'AC', 'DES_FAC_LOC_STREET_2', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (68, 'AC', 'DES_FAC_LOC_CITY', 'varchar(35) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (69, 'AC', 'DES_FAC_LOC_STA', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (70, 'AC', 'DES_FAC_LOC_ZIP', 'varchar(25) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (71, 'AC', 'DES_FAC_CONTACT_FIRST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (72, 'AC', 'DES_FAC_CONTACT_LAST_NAME', 'varchar(38)', 'dbo.RCRA_EM_EMANIFEST'),
              (73, 'AC', 'DES_FAC_CONTACT_COMPANY_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (74, 'AC', 'DES_FAC_CONTACT_PHONE_NUM', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (75, 'AC', 'DES_FAC_CONTACT_PHONE_EXT', 'varchar(6) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (76, 'AC', 'DES_FAC_CONTACT_EMAIL', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (77, 'AC', 'DES_FAC_PRINTED_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (78, 'AC', 'DES_FAC_SIGNATURE_DATE', 'datetime', 'dbo.RCRA_EM_EMANIFEST'),
              (79, 'AC', 'DES_FAC_ESIG_FIRST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (80, 'AC', 'DES_FAC_ESIG_LAST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (81, 'AC', 'DES_FAC_ESIG_SIGNATURE_DATE', 'datetime null', 'dbo.RCRA_EM_EMANIFEST'),
              (82, 'AC', 'DES_FAC_REGISTERED', 'char(1)', 'dbo.RCRA_EM_EMANIFEST'),
              (83, 'AC', 'DES_FAC_MODIFIED', 'char(1)', 'dbo.RCRA_EM_EMANIFEST'),
              (84, 'AC', 'ALT_FAC_ID', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (85, 'AC', 'ALT_FAC_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (86, 'AC', 'ALT_FAC_MAIL_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (87, 'AC', 'ALT_FAC_MAIL_STREET_1', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (88, 'AC', 'ALT_FAC_MAIL_STREET_2', 'varchar(50)', 'dbo.RCRA_EM_EMANIFEST'),
              (89, 'AC', 'ALT_FAC_MAIL_CITY', 'varchar(25) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (90, 'AC', 'ALT_FAC_MAIL_STA', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (91, 'AC', 'ALT_FAC_MAIL_ZIP', 'varchar(14) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (92, 'AC', 'ALT_FAC_LOC_STREET_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (93, 'AC', 'ALT_FAC_LOC_STREET_1', 'varchar(50) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (94, 'AC', 'ALT_FAC_LOC_STREET_2', 'varchar(50) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (95, 'AC', 'ALT_FAC_LOC_CITY', 'varchar(25) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (96, 'AC', 'ALT_FAC_LOC_STA', 'char(2) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (97, 'AC', 'ALT_FAC_LOC_ZIP', 'varchar(14) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (98, 'AC', 'ALT_FAC_CONTACT_FIRST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (99, 'AC', 'ALT_FAC_CONTACT_LAST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (100, 'AC', 'ALT_FAC_CONTACT_COMPANY_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (101, 'AC', 'ALT_FAC_CONTACT_PHONE_NO', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (102, 'AC', 'ALT_FAC_CONTACT_PHONE_EXT', 'varchar(6) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (103, 'AC', 'ALT_FAC_CONTACT_EMAIL', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (104, 'AC', 'ALT_FAC_PRINTED_NAME', 'varchar(80) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (105, 'AC', 'ALT_FAC_SIGNATURE_DATE', 'datetime null', 'dbo.RCRA_EM_EMANIFEST'),
              (106, 'AC', 'ALT_FAC_ESIG_FIRST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (107, 'AC', 'ALT_FAC_ESIG_LAST_NAME', 'varchar(38) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (108, 'AC', 'ALT_FAC_ESIG_SIGNATURE_DATE', 'datetime null', 'dbo.RCRA_EM_EMANIFEST'),
              (109, 'AC', 'ALT_FAC_REGISTERED', 'char(1) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (110, 'AC', 'ALT_FAC_MODIFIED', 'char(1) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (111, 'AC', 'EMERGENCY_PHONE_NUM', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (112, 'AC', 'EMERGENCY_PHONE_EXT', 'varchar(6) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (113, 'AC', 'ORIG_SUBM_TYPE', 'varchar(14) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (114, 'AC', 'COI_ONLY', 'char(1) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (115, 'AC', 'BROKER_ID', 'varchar(15) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (116, 'AC', 'LAST_EM_UPDT_DATE', 'datetime null', 'dbo.RCRA_EM_EMANIFEST'),
              (117, 'AC', 'COI_ONLY', 'char(1) NULL', 'dbo.RCRA_EM_WASTE'),
              (118, 'AC', 'QNTY_ACUTE_KG', 'decimal(14, 6) NULL', 'dbo.RCRA_EM_WASTE'),
              (119, 'AC', 'QNTY_ACUTE_TONS', 'decimal(14, 6) NULL', 'dbo.RCRA_EM_WASTE'),
              (120, 'AC', 'QNTY_NON_ACUTE_KG', 'decimal(14, 6) NULL', 'dbo.RCRA_EM_WASTE'),
              (121, 'AC', 'QNTY_NON_ACUTE_TONS', 'decimal(14, 6) NULL', 'dbo.RCRA_EM_WASTE'),
              (122, 'AC', 'QNTY_TONS', 'decimal(14, 6) NULL', 'dbo.RCRA_EM_WASTE'),
              (124, 'AC', 'LOAD_TYPE_DESC', 'varchar(25) NULL', 'dbo.RCRA_EM_WASTE_PCB'),
              (125, 'AC', 'BR_MIXED_RADIOACTIVE_WASTE', 'char(1)', 'dbo.RCRA_EM_WASTE'),
              (126, 'AC', 'QNTY_KG', 'decimal(14,6)', 'dbo.RCRA_EM_WASTE'),

              -- rename columns
              (127, 'RC', 'ADD_INFO_CONSENT_NUM', 'CNST_NUM', 'dbo.RCRA_EM_WASTE'),                                                                     --
              (128, 'RC', 'EPA_WASTE_IND', 'EPA_WASTE', 'dbo.RCRA_EM_WASTE'),
              (129, 'RC', 'DISC_COMMENTS', 'DISCREPANCY_COMM', 'dbo.RCRA_EM_WASTE'),
              (130, 'RC', 'QNT_CONT_TYPE_CODE', 'CONTAINER_TYPE_CODE', 'dbo.RCRA_EM_WASTE'),
              (131, 'RC', 'QNT_CONT_TYPE_DESC', 'CONTAINER_TYPE_DESC', 'dbo.RCRA_EM_WASTE'),
              (132, 'RC', 'DOT_ID_NUM', 'DOT_ID_NUM_DESC', 'dbo.RCRA_EM_WASTE'),
              (133, 'RC', 'WASTES_DESC', 'NON_HAZ_WASTE_DESC', 'dbo.RCRA_EM_WASTE'),
              (134, 'RC', 'QNT_CONT_NUM', 'CONTAINER_NUM', 'dbo.RCRA_EM_WASTE'),
              (135, 'RC', 'QNT_VAL', 'QNTY_VAL', 'dbo.RCRA_EM_WASTE'),
              (136, 'RC', 'QNT_UOM_CODE', 'QTY_UNIT_OF_MEAS_CODE', 'dbo.RCRA_EM_WASTE'),
              (137, 'RC', 'QNT_UOM_DESC', 'QTY_UNIT_OF_MEAS_DESC', 'dbo.RCRA_EM_WASTE'),
              (138, 'RC', 'BR_FORM_DESC', 'BR_FORM_CODE_DESC', 'dbo.RCRA_EM_WASTE'),
              (139, 'RC', 'BR_SRC_DESC', 'BR_SRC_CODE_DESC', 'dbo.RCRA_EM_WASTE'),
              (140, 'RC', 'BR_WM_CODE', 'BR_WASTE_MIN_CODE', 'dbo.RCRA_EM_WASTE'),
              (141, 'RC', 'BR_WM_DESC', 'BR_WASTE_MIN_DESC', 'dbo.RCRA_EM_WASTE'),
              (142, 'RC', 'PCB_IND', 'PCB', 'dbo.RCRA_EM_WASTE'),
              (143, 'RC', 'DISC_RESIDUE_COMMENTS', 'WASTE_RESIDUE_COMM', 'dbo.RCRA_EM_WASTE'),
              (144, 'RC', 'DISC_WASTE_QTY_IND', 'QNTY_DISCREPANCY', 'dbo.RCRA_EM_WASTE'),
              (145, 'RC', 'DISC_WASTE_TYPE_IND', 'WASTE_TYPE_DISCREPANCY', 'dbo.RCRA_EM_WASTE'),
              (146, 'RC', 'MGMT_METHOD_CODE', 'MANAGEMENT_METH_CODE', 'dbo.RCRA_EM_WASTE'),
              (147, 'RC', 'MGMT_METHOD_DESC', 'MANAGEMENT_METH_DESC', 'dbo.RCRA_EM_WASTE'),
              (148, 'RC', 'ADD_INFO_HAND_INSTR', 'HANDLING_INSTRUCTIONS', 'dbo.RCRA_EM_WASTE'),
              (149, 'RC', 'COMMENT_LABEL', 'CMNT_LABEL', 'dbo.RCRA_EM_WASTE_COMMENT'),
              (150, 'RC', 'REJ_TRANS_ON_SITE_IND', 'TRANSPORTER_ON_SITE', 'dbo.RCRA_EM_EMANIFEST'),
              (151, 'RC', 'IMP_GEN_NAME', 'FOREIGN_GENERATOR_NAME', 'dbo.RCRA_EM_EMANIFEST'),
              (152, 'RC', 'IMP_GEN_ADDRESS', 'FOREIGN_GENERATOR_STREET', 'dbo.RCRA_EM_EMANIFEST'),
              (153, 'RC', 'IMP_GEN_CITY', 'FOREIGN_GENERATOR_CITY', 'dbo.RCRA_EM_EMANIFEST'),
              (154, 'RC', 'IMP_GEN_CNTRY_CODE', 'FOREIGN_GENERATOR_CTRY_CODE', 'dbo.RCRA_EM_EMANIFEST'),
              (155, 'RC', 'IMP_GEN_POSTAL_CODE', 'FOREIGN_GENERATOR_POST_CODE', 'dbo.RCRA_EM_EMANIFEST'),
              (156, 'RC', 'IMP_GEN_PROVINCE', 'FOREIGN_GENERATOR_PROVINCE', 'dbo.RCRA_EM_EMANIFEST'),
              (157, 'RC', 'IMP_PORT_STATE_CODE', 'PORT_OF_ENTRY_STA', 'dbo.RCRA_EM_EMANIFEST'),
              (158, 'RC', 'RESIDUE_IND', 'RESIDUE', 'dbo.RCRA_EM_EMANIFEST'),
              (159, 'RC', 'IMP_IND', 'IMPORT', 'dbo.RCRA_EM_EMANIFEST'),
              (160, 'RC', 'COMMENT_DESC', 'CMNT_DESC', 'dbo.RCRA_EM_EMANIFEST_COMMENT'),
              (161, 'RC', 'REJ_ALT_DES_FAC_TYPE', 'ALTERNATE_DESIGNATED_FAC_TYPE', 'dbo.RCRA_EM_EMANIFEST'),
              (162, 'RC', 'DOT_HAZ_IND', 'DOT_HAZRD', 'dbo.RCRA_EM_WASTE'),
              (163, 'RC', 'ADD_INFO_HAND_INSTR', 'MANIFEST_HANDLING_INSTR', 'dbo.RCRA_EM_EMANIFEST'),
              (164, 'RC', 'REJ_TYPE', 'REJECTION_TYPE', 'dbo.RCRA_EM_EMANIFEST'),
              (165, 'RC', 'IMP_GEN_CNTRY_NAME', 'FOREIGN_GENERATOR_CTRY_NAME', 'dbo.RCRA_EM_EMANIFEST'),
              (166, 'RC', 'IMP_PORT_CITY', 'PORT_OF_ENTRY_CITY', 'dbo.RCRA_EM_EMANIFEST'),
              (167, 'RC', 'COMMENT_LABEL', 'CMNT_LABEL', 'dbo.RCRA_EM_EMANIFEST_COMMENT'),
              (168, 'RC', 'DISC_RESIDUE_IND', 'WASTE_RESIDUE', 'dbo.RCRA_EM_WASTE'),
              -- modify/alter columns
              (169, 'MC', 'CREATED_DATE', 'datetime NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (170, 'MC', 'MAN_TRACKING_NUM', 'varchar(12) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (171, 'MC', 'STATUS', 'varchar(17) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (172, 'MC', 'ORIGIN_TYPE', 'varchar(7) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (173, 'MC', 'REJ_IND', 'char(1) NULL', 'dbo.RCRA_EM_EMANIFEST'),
              (174, 'MC', 'LINE_NUM', 'decimal(10, 0) NULL', 'dbo.RCRA_EM_WASTE'),
              (175, 'MC', 'PCB_LOAD_TYPE_CODE', 'varchar(25)', 'dbo.RCRA_EM_WASTE_PCB'),
              (176, 'MC', 'PCB_WASTE_TYPE', 'varchar(150)', 'dbo.RCRA_EM_WASTE_PCB'),
              (177, 'MC', 'DOT_ID_NUM_DESC', 'varchar(6)', 'dbo.RCRA_EM_WASTE'),
              (178, 'MC', 'CONTAINER_TYPE_CODE', 'char(2) NULL', 'dbo.RCRA_EM_WASTE'),
              (179, 'MC', 'CONTAINER_TYPE_DESC', 'varchar(50) NULL', 'dbo.RCRA_EM_WASTE'),
              (180, 'MC', 'WASTE_RESIDUE_COMM', 'varchar(257)', 'dbo.RCRA_EM_WASTE'),
              (181, 'MC', 'DISCREPANCY_COMM', 'varchar(257)', 'dbo.RCRA_EM_WASTE'),
              (182, 'MC', 'WASTE_CODE_TEXT', 'varchar(4000)', 'dbo.RCRA_HD_EPISODIC_WASTE_CODE'),
              -- (re)create views
              (183, 'CV', 'dbo.ETL_EM_EMANIFEST_VW',
               'select WH.EM_EMANIFEST_ID WH_EM_EMANIFEST_ID,
                       NODE.*
                from NODE_RCRA_EM_EMANIFEST NODE
                left join RCRA_EM_EMANIFEST WH on WH.MAN_TRACKING_NUM = NODE.MAN_TRACKING_NUM', null),
              (184, 'CV', 'dbo.ETL_EM_WASTE_VW',
               'select WH.EM_WASTE_ID WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_WASTE NODE
                join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID
                left join RCRA_EM_WASTE WH
                    on WH.EM_EMANIFEST_ID = ETL.WH_EM_EMANIFEST_ID
                        and WH.LINE_NUM = NODE.LINE_NUM', null),
              (185, 'CV', 'dbo.ETL_EM_WASTE_COMMENT_VW',
               'select ETL.WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_WASTE_COMMENT NODE
                join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID', null),
              (186, 'CV', 'dbo.ETL_EM_WASTE_PCB_VW',
               'select ETL.WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_WASTE_PCB NODE
                join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID', null),
              (187, 'CV', 'dbo.ETL_EM_EMANIFEST_COMMENT_VW',
               'select ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_EMANIFEST_COMMENT NODE
                join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID', null),
              (188, 'CV', 'dbo.ETL_EM_TRANSPORTER_VW',
               'select ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_TRANSPORTER NODE
                join ETL_EM_EMANIFEST_VW ETL on ETL.EM_EMANIFEST_ID = NODE.EM_EMANIFEST_ID', null),
              (189, 'CV', 'dbo.ETL_EM_WASTE_CD_TRANS_VW',
               'select ETL.WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_WASTE_CD_TRANS NODE
                join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID', null),
              (190, 'CV', 'dbo.ETL_EM_FED_WASTE_CODE_DESC_VW',
               'select ETL.WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_FED_WASTE_CODE_DESC NODE
                join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID', null),
              (191, 'CV', 'dbo.ETL_EM_STATE_WASTE_CODE_DESC_VW',
               'select ETL.WH_EM_WASTE_ID,
                       ETL.WH_EM_EMANIFEST_ID,
                       ETL.EM_SUBM_ID,
                       NODE.*
                from NODE_RCRA_EM_STATE_WASTE_CODE_DESC NODE
                join ETL_EM_WASTE_VW ETL on ETL.EM_WASTE_ID = NODE.EM_WASTE_ID', null),
              -- drop views
              (192, 'DV', 'dbo.ETL_EM_TR_NUM_ORIG_VW', null, null),
              (193, 'DV', 'dbo.ETL_EM_TR_NUM_RESIDUE_NEW_VW', null, null),
              (194, 'DV', 'dbo.ETL_EM_TR_NUM_REJ_VW', null, null),
              (195, 'DV', 'dbo.ETL_EM_TR_NUM_WASTE_VW', null, null),
              (196, 'DV', 'dbo.ETL_EM_WASTE_CD_FED_VW', null, null),
              (197, 'DV', 'dbo.ETL_EM_WASTE_CD_GEN_VW', null, null),
              (198, 'DV', 'dbo.ETL_EM_WASTE_CD_TSDF_VW', null, null),
              (199, 'DV', 'dbo.ETL_EM_HANDLER_VW', null, null),
              -- drop procedures
              (200, 'DP', 'dbo.EM_MERGE_HANDLER', null, null),
              (201, 'DP', 'dbo.EM_MERGE_TR_NUM_ORIG', null, null),
              (202, 'DP', 'dbo.EM_MERGE_TR_NUM_REJ', null, null),
              (203, 'DP', 'dbo.EM_MERGE_TR_NUM_RESIDUE_NEW', null, null),
              (204, 'DP', 'dbo.EM_MERGE_WASTE_CD_FED', null, null),
              (205, 'DP', 'dbo.EM_MERGE_WASTE_CD_GEN', null, null),
              (206, 'DP', 'dbo.EM_MERGE_WASTE_CD_TRANS', null, null),
              (207, 'DP', 'dbo.EM_MERGE_WASTE_CD_TSDF', null, null),
              (208, 'DP', 'dbo.EM_MERGE_EMANIFEST', null, null),
              (209, 'RC', 'COMMENT_DESC', 'CMNT_DESC', 'dbo.RCRA_EM_WASTE_COMMENT')
             --
         ) as t(sort_order, type_code, obj_name, obj_def, target_name)
    order by t.sort_order;
open x;
declare @type_code varchar(100);
declare @obj_name varchar(200);
declare @target_name varchar(max);
declare @obj_def varchar(max);
fetch x into @type_code, @obj_name, @obj_def, @target_name;
while @@fetch_status = 0
    begin
        exec #handle_db_action @type_code = @type_code,
             @obj_name = @obj_name,
             @obj_def = @obj_def,
             @target_name = @target_name
        fetch x into @type_code, @obj_name, @obj_def, @target_name;
    end
close x;
deallocate x;

if object_id('dbo.EM_MERGE_EMANIFEST') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_EMANIFEST'
        exec ('create procedure dbo.EM_MERGE_EMANIFEST as return 0;')
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping create procedure dbo.EM_MERGE_EMANIFEST since it already exists'
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_EMANIFEST'
go
alter procedure dbo.EM_MERGE_EMANIFEST @EM_SUBM_ID varchar(40) AS
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;

    declare @localTran bit
    if @@trancount = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        merge into RCRA_EM_EMANIFEST D
        using (select *
               from ETL_EM_EMANIFEST_VW
               where EM_SUBM_ID = @EM_SUBM_ID) S
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
            insert (CREATED_DATE,
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
            values (S.CREATED_DATE,
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
        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran

    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_EMANIFEST_COMMENT') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_EMANIFEST_COMMENT'
        exec ('create procedure dbo.EM_MERGE_EMANIFEST_COMMENT as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_EMANIFEST_COMMENT'
go
alter procedure dbo.EM_MERGE_EMANIFEST_COMMENT @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_EMANIFEST_COMMENT
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_EMANIFEST_ID is not null --
        )

        insert into RCRA_EM_EMANIFEST_COMMENT (EM_EMANIFEST_ID, CMNT_LABEL, CMNT_DESC)
        select WH_EM_EMANIFEST_ID,
               CMNT_LABEL,
               CMNT_DESC
        from ETL_EM_EMANIFEST_COMMENT_VW y
        where y.EM_EMANIFEST_ID IN ( --
            select s.EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.EM_EMANIFEST_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_FED_WASTE_CODE_DESC') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_FED_WASTE_CODE_DESC'
        exec ('create procedure dbo.EM_MERGE_FED_WASTE_CODE_DESC as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_FED_WASTE_CODE_DESC'
go
alter procedure dbo.EM_MERGE_FED_WASTE_CODE_DESC @EM_SUBM_ID varchar(40) AS
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_FED_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where EM_SUBM_ID = @EM_SUBM_ID
              and WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_FED_WASTE_CODE_DESC (EM_WASTE_ID, FED_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC, COI_IND)
        select WH_EM_WASTE_ID,
               FED_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC,
               COI_IND
        from ETL_EM_FED_WASTE_CODE_DESC_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where EM_SUBM_ID = @EM_SUBM_ID
              and EM_WASTE_ID is not null --
        );

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_STATE_WASTE_CODE_DESC') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_STATE_WASTE_CODE_DESC'
        exec ('create procedure dbo.EM_MERGE_STATE_WASTE_CODE_DESC as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_STATE_WASTE_CODE_DESC'
go
alter procedure dbo.EM_MERGE_STATE_WASTE_CODE_DESC @EM_SUBM_ID varchar(40) AS
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_STATE_WASTE_CODE_DESC
        where EM_WASTE_ID in ( --
            select WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW
            where EM_SUBM_ID = @EM_SUBM_ID
              and WH_EM_WASTE_ID is not null --
        );

        insert into RCRA_EM_STATE_WASTE_CODE_DESC (EM_WASTE_ID, STA_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC)
        select WH_EM_WASTE_ID,
               STA_MANIFEST_WASTE_CODE,
               MANIFEST_WASTE_DESC
        from ETL_EM_STATE_WASTE_CODE_DESC_VW y
        where y.EM_WASTE_ID IN ( --
            select x.EM_WASTE_ID
            from ETL_EM_WASTE_VW x
            where EM_SUBM_ID = @EM_SUBM_ID
              and x.EM_WASTE_ID is not null --
        );

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_TRANSPORTER') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_TRANSPORTER'
        exec ('create procedure dbo.EM_MERGE_TRANSPORTER as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_TRANSPORTER'
go
alter procedure dbo.EM_MERGE_TRANSPORTER @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_TRANSPORTER
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_EMANIFEST_ID is not null --
        )

        insert into RCRA_EM_TRANSPORTER (EM_EMANIFEST_ID, TRANSPORTER_ID, TRANSPORTER_NAME, TRANSPORTER_PRINTED_NAME,
                                         TRANSPORTER_SIGNATURE_DATE, TRANSPORTER_ESIG_FIRST_NAME,
                                         TRANSPORTER_ESIG_LAST_NAME, TRANS_ESIG_SIGNATURE_DATE, TRANSPORTER_LINE_NUM,
                                         TRANSPORTER_REGISTERED)
        select WH_EM_EMANIFEST_ID,
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
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.EM_EMANIFEST_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_WASTE_CD_TRANS') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_WASTE_CD_TRANS'
        exec ('create procedure dbo.EM_MERGE_WASTE_CD_TRANS as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_WASTE_CD_TRANS'
go
alter procedure dbo.EM_MERGE_WASTE_CD_TRANS @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_WASTE_CD_TRANS
        where EM_WASTE_ID in ( --
            select s.WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_WASTE_ID is not null --
        )

        insert into RCRA_EM_WASTE_CD_TRANS (EM_WASTE_ID, WASTE_CODE)
        select WH_EM_WASTE_ID,
               WASTE_CODE
        from ETL_EM_WASTE_CD_TRANS_VW y
        where y.EM_WASTE_ID IN ( --
            select s.EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.EM_WASTE_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_WASTE_COMMENT') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_WASTE_COMMENT'
        exec ('create procedure dbo.EM_MERGE_WASTE_COMMENT as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_WASTE_COMMENT'
go
alter procedure dbo.EM_MERGE_WASTE_COMMENT @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_WASTE_COMMENT
        where EM_WASTE_ID in ( --
            select s.WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_WASTE_ID is not null --
        )
        insert into RCRA_EM_WASTE_COMMENT (EM_WASTE_ID, CMNT_LABEL, CMNT_DESC)
        select WH_EM_WASTE_ID,
               CMNT_LABEL,
               CMNT_DESC
        from ETL_EM_WASTE_COMMENT_VW y
        where y.EM_WASTE_ID IN ( --
            select s.EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_WASTE_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_WASTE_PCB') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_WASTE_PCB'
        exec ('create procedure dbo.EM_MERGE_WASTE_PCB as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_WASTE_PCB'
go
alter procedure dbo.EM_MERGE_WASTE_PCB @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_WASTE_PCB
        where EM_WASTE_ID in ( --
            select s.WH_EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_WASTE_ID is not null --
        )

        insert into RCRA_EM_WASTE_PCB (EM_WASTE_ID, PCB_LOAD_TYPE_CODE, PCB_ARTICLE_CONT_ID, PCB_REMOVAL_DATE,
                                       PCB_WEIGHT, PCB_WASTE_TYPE, PCB_BULK_IDENTITY, LOAD_TYPE_DESC)
        select WH_EM_WASTE_ID,
               PCB_LOAD_TYPE_CODE,
               PCB_ARTICLE_CONT_ID,
               PCB_REMOVAL_DATE,
               PCB_WEIGHT,
               PCB_WASTE_TYPE,
               PCB_BULK_IDENTITY,
               LOAD_TYPE_DESC
        from ETL_EM_WASTE_PCB_VW y
        where y.EM_WASTE_ID IN ( --
            select s.EM_WASTE_ID
            from ETL_EM_WASTE_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.EM_WASTE_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_MERGE_WASTE') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_WASTE'
        exec ('create procedure dbo.EM_MERGE_WASTE as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_WASTE'
go
alter procedure dbo.EM_MERGE_WASTE @EM_SUBM_ID varchar(40) AS
begin
    set nocount on
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on
    set numeric_roundabort off

    declare @localTran bit
    if @@TRANCOUNT = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        delete
        from RCRA_EM_WASTE
        where EM_EMANIFEST_ID in ( --
            select s.WH_EM_EMANIFEST_ID
            from ETL_EM_EMANIFEST_VW s
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.WH_EM_EMANIFEST_ID is not null --
        )

        insert into RCRA_EM_WASTE (EM_EMANIFEST_ID, NON_HAZ_WASTE_DESC, DOT_HAZRD, LINE_NUM,
                                   BR_MIXED_RADIOACTIVE_WASTE, DOT_PRINTED_INFO, CONTAINER_NUM, QNTY_VAL,
                                   QTY_UNIT_OF_MEAS_CODE, QTY_UNIT_OF_MEAS_DESC, BR_DENSITY, BR_DENSITY_UOM_CODE,
                                   BR_DENSITY_UOM_DESC, BR_FORM_CODE, BR_FORM_CODE_DESC, BR_SRC_CODE,
                                   BR_SRC_CODE_DESC, BR_WASTE_MIN_CODE, BR_WASTE_MIN_DESC, QNTY_DISCREPANCY,
                                   WASTE_TYPE_DISCREPANCY, WASTE_RESIDUE_COMM, PCB, MANAGEMENT_METH_CODE,
                                   MANAGEMENT_METH_DESC, HANDLING_INSTRUCTIONS, DOT_ID_NUM_DESC, CONTAINER_TYPE_CODE,
                                   CONTAINER_TYPE_DESC, DISCREPANCY_COMM, WASTE_RESIDUE, CNST_NUM, EPA_WASTE,
                                   COI_ONLY, QNTY_ACUTE_KG, QNTY_ACUTE_TONS, QNTY_KG, QNTY_NON_ACUTE_KG,
                                   QNTY_NON_ACUTE_TONS, QNTY_TONS)
        select WH_EM_EMANIFEST_ID,
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
            where s.EM_SUBM_ID = @EM_SUBM_ID
              and s.EM_EMANIFEST_ID is not null --
        )

        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

if object_id('dbo.EM_LOG_HANDLERS') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_LOG_HANDLERS'
        exec ('create procedure dbo.EM_LOG_HANDLERS as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_LOG_HANDLERS'
go
alter procedure dbo.EM_LOG_HANDLERS @EM_SUBM_ID varchar(40) AS
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;

    declare @localTran bit
    if @@trancount = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        insert into ETL_RUN (RUN_DATE, ETL_TYPE, SUBM_ID)
        values (CURRENT_TIMESTAMP, 'EM', @EM_SUBM_ID);
        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran
    end try
    begin catch
        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)
    end catch
end
go

if object_id('dbo.EM_MERGE_DATA') is null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Creating stored procedure dbo.EM_MERGE_DATA'
        exec ('create procedure dbo.EM_MERGE_DATA as return 0;')
    end
go

print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Altering create procedure dbo.EM_MERGE_DATA'
go
alter procedure dbo.EM_MERGE_DATA @DeleteStaging bit = 1 AS
declare
    @EM_SUBM_ID varchar(40);
declare @getSubmId cursor;
begin
    set nocount on;
    set xact_abort,
        quoted_identifier,
        ansi_nulls,
        ansi_padding,
        ansi_warnings,
        arithabort,
        concat_null_yields_null on;
    set numeric_roundabort off;

    declare @localTran bit
    if @@trancount = 0
        begin
            set @localTran = 1
            begin transaction LocalTran
        end

    begin try
        set @getSubmId = cursor for
            select EM_SUBM_ID
            from NODE_RCRA_EM_SUBM
            where EM_SUBM_ID not in ( --
                select SUBM_ID
                from ETL_RUN
                where SUBM_ID is not null
                  and ETL_TYPE = 'EM' --
            );
        open @getSubmId;
        fetch next from @getSubmId into @EM_SUBM_ID;
        while @@FETCH_STATUS = 0
            begin
                exec EM_LOG_HANDLERS @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_EMANIFEST @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_EMANIFEST_COMMENT @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_TRANSPORTER @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_WASTE @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_FED_WASTE_CODE_DESC @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_STATE_WASTE_CODE_DESC @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_WASTE_CD_TRANS @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_WASTE_COMMENT @EM_SUBM_ID = @EM_SUBM_ID;
                exec EM_MERGE_WASTE_PCB @EM_SUBM_ID = @EM_SUBM_ID;
                if @DeleteStaging = 1
                    begin
                        delete
                        from NODE_RCRA_EM_SUBM
                        where current of @getSubmId;
                    end;
                fetch next from @getSubmId into @EM_SUBM_ID;
            end;
        close @getSubmId;
        deallocate @getSubmId;
        if @localTran = 1 and xact_state() = 1
            commit tran LocalTran

    end try
    begin catch

        declare @ErrorMessage nvarchar(4000)
        declare @ErrorSeverity int
        declare @ErrorState int

        select @ErrorMessage = error_message(),
               @ErrorSeverity = error_severity(),
               @ErrorState = error_state()

        if @localTran = 1 and xact_state() <> 0
            rollback tran

        raiserror (@ErrorMessage, @ErrorSeverity, @ErrorState)

    end catch
end
go

/*
 * Map the data from the old DB structures to the new DB structures
 */
print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Deleting manifests with no tracking numbers'
delete
from dbo.RCRA_EM_EMANIFEST
where MAN_TRACKING_NUM is null;
print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
    + 'Count of manifests with no tracking numbers deleted: ' + cast(@@rowcount as varchar(10))

if exists(select 1
          from sys.columns
          where name = 'CORR_VERSION_NUM'
            and object_id = object_id('dbo.RCRA_EM_EMANIFEST'))
    begin
        declare @sql nvarchar(max)
        declare @NumRowsChanged int
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Deleting RCRA_EM_EMANIFEST records with duplicate tracking numbers';
        set @sql = 'with t as (select m.EM_EMANIFEST_ID,
                          row_number() over (partition by m.MAN_TRACKING_NUM order by m.CORR_VERSION_NUM desc) as RN
                   from dbo.RCRA_EM_EMANIFEST m)
        delete
        from dbo.RCRA_EM_EMANIFEST
        where EM_EMANIFEST_ID in (select t.EM_EMANIFEST_ID
                                  from t
                                  where t.RN > 1);
                   select @NumRowsChanged = @@rowcount'
        exec sp_executesql @sql, N'@NumRowsChanged int output', @NumRowsChanged=@NumRowsChanged output
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Count of deleted RCRA_EM_EMANIFEST records with duplicate tracking numbers: '
            + cast(@NumRowsChanged as varchar(10))
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping deleting RCRA_EM_EMANIFEST records with duplicate tracking numbers '
        + 'since the RCRA_EM_EMANIFEST.CORR_VERSION_NUM column does not exist'

if object_id('dbo.RCRA_EM_HANDLER') is not null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Updating RCRA_EM_EMANIFEST records with generator, destination and alt dest handler info'
        update m
        set -- generator
            m.GENERATOR_ID                   = gen.EPA_SITE_ID,
            m.GENERATOR_NAME                 = gen.MANIFEST_NAME,
            m.GENERATOR_REGISTERED           = gen.REG_IND,
            m.GENERATOR_MODIFIED             = gen.MOD_IND,
            m.GENERATOR_MAIL_STREET_NUM      = gen.MAIL_STREET_NUM,
            m.GENERATOR_MAIL_STREET_1        = gen.MAIL_STREET1,
            m.GENERATOR_MAIL_STREET_2        = gen.MAIL_STREET2,
            m.GENERATOR_MAIL_CITY            = gen.MAIL_CITY,
            m.GENERATOR_MAIL_ZIP             = gen.MAIL_ZIP,
            m.GENERATOR_MAIL_STA             = gen.MAIL_STATE_CODE,
            m.GENERATOR_LOC_STREET_NUM       = gen.SITE_STREET_NUM,
            m.GENERATOR_LOC_STREET_1         = gen.SITE_STREET1,
            m.GENERATOR_LOC_STREET_2         = gen.SITE_STREET2,
            m.GENERATOR_LOC_CITY             = gen.SITE_CITY,
            m.GENERATOR_LOC_STA              = gen.SITE_STATE_CODE,
            m.GENERATOR_LOC_ZIP              = gen.SITE_ZIP,
            m.GENERATOR_CONTACT_FIRST_NAME   = gen.CONTACT_FIRST_NAME,
            m.GENERATOR_CONTACT_LAST_NAME    = gen.CONTACT_LAST_NAME,
            m.GENERATOR_CONTACT_EMAIL        = gen.CONTACT_EMAIL,
            m.GENERATOR_CONTACT_COMPANY_NAME = gen.CONTACT_COMPANY_NAME,
            m.GENERATOR_CONTACT_PHONE_NUM    = gen.CONTACT_PHONE_NUM,
            m.GENERATOR_CONTACT_PHONE_EXT    = gen.CONTACT_PHONE_EXT,
            m.GENERATOR_PRINTED_NAME         = gen.PS_NAME,
            m.GENERATOR_SIGNATURE_DATE       = gen.PS_DATE,
            m.GENERATOR_ESIG_SIGNATURE_DATE  = gen.ES_SIGN_DATE,
            m.GENERATOR_ESIG_FIRST_NAME      = gen.ES_SIGNER_FIRST_NAME,
            m.GENERATOR_ESIG_LAST_NAME       = gen.ES_SIGNER_LAST_NAME,
            --- TSDF
            m.DES_FAC_ID                     = tsdf.EPA_SITE_ID,
            m.DES_FAC_NAME                   = tsdf.MANIFEST_NAME,
            m.DES_FAC_REGISTERED             = tsdf.REG_IND,
            m.DES_FAC_MODIFIED               = tsdf.MOD_IND,
            m.DES_FAC_MAIL_STREET_NUM        = tsdf.MAIL_STREET_NUM,
            m.DES_FAC_MAIL_STREET_1          = tsdf.MAIL_STREET1,
            m.DES_FAC_MAIL_STREET_2          = tsdf.MAIL_STREET2,
            m.DES_FAC_MAIL_CITY              = tsdf.MAIL_CITY,
            m.DES_FAC_MAIL_ZIP               = tsdf.MAIL_ZIP,
            m.DES_FAC_MAIL_STA               = tsdf.MAIL_STATE_CODE,
            m.DES_FAC_LOC_STREET_NUM         = tsdf.SITE_STREET_NUM,
            m.DES_FAC_LOC_STREET_1           = tsdf.SITE_STREET1,
            m.DES_FAC_LOC_STREET_2           = tsdf.SITE_STREET2,
            m.DES_FAC_LOC_CITY               = tsdf.SITE_CITY,
            m.DES_FAC_LOC_STA                = tsdf.SITE_STATE_CODE,
            m.DES_FAC_LOC_ZIP                = tsdf.SITE_ZIP,
            m.DES_FAC_CONTACT_FIRST_NAME     = tsdf.CONTACT_FIRST_NAME,
            m.DES_FAC_CONTACT_LAST_NAME      = tsdf.CONTACT_LAST_NAME,
            m.DES_FAC_CONTACT_EMAIL          = tsdf.CONTACT_EMAIL,
            m.DES_FAC_CONTACT_COMPANY_NAME   = tsdf.CONTACT_COMPANY_NAME,
            m.DES_FAC_CONTACT_PHONE_NUM      = tsdf.CONTACT_PHONE_NUM,
            m.DES_FAC_CONTACT_PHONE_EXT      = tsdf.CONTACT_PHONE_EXT,
            m.DES_FAC_PRINTED_NAME           = tsdf.PS_NAME,
            m.DES_FAC_SIGNATURE_DATE         = tsdf.PS_DATE,
            m.DES_FAC_ESIG_SIGNATURE_DATE    = tsdf.ES_SIGN_DATE,
            m.DES_FAC_ESIG_FIRST_NAME        = tsdf.ES_SIGNER_FIRST_NAME,
            m.DES_FAC_ESIG_LAST_NAME         = tsdf.ES_SIGNER_LAST_NAME,
            --- alt TSDF
            m.ALT_FAC_ID                     = alt.EPA_SITE_ID,
            m.ALT_FAC_NAME                   = alt.MANIFEST_NAME,
            m.ALT_FAC_REGISTERED             = alt.REG_IND,
            m.ALT_FAC_MODIFIED               = alt.MOD_IND,
            m.ALT_FAC_MAIL_STREET_NUM        = alt.MAIL_STREET_NUM,
            m.ALT_FAC_MAIL_STREET_1          = alt.MAIL_STREET1,
            m.ALT_FAC_MAIL_STREET_2          = alt.MAIL_STREET2,
            m.ALT_FAC_MAIL_CITY              = alt.MAIL_CITY,
            m.ALT_FAC_MAIL_ZIP               = alt.MAIL_ZIP,
            m.ALT_FAC_MAIL_STA               = alt.MAIL_STATE_CODE,
            m.ALT_FAC_LOC_STREET_NUM         = alt.SITE_STREET_NUM,
            m.ALT_FAC_LOC_STREET_1           = alt.SITE_STREET1,
            m.ALT_FAC_LOC_STREET_2           = alt.SITE_STREET2,
            m.ALT_FAC_LOC_CITY               = alt.SITE_CITY,
            m.ALT_FAC_LOC_STA                = alt.SITE_STATE_CODE,
            m.ALT_FAC_LOC_ZIP                = alt.SITE_ZIP,
            m.ALT_FAC_CONTACT_FIRST_NAME     = alt.CONTACT_FIRST_NAME,
            m.ALT_FAC_CONTACT_LAST_NAME      = alt.CONTACT_LAST_NAME,
            m.ALT_FAC_CONTACT_EMAIL          = alt.CONTACT_EMAIL,
            m.ALT_FAC_CONTACT_COMPANY_NAME   = alt.CONTACT_COMPANY_NAME,
            m.ALT_FAC_CONTACT_PHONE_NO       = alt.CONTACT_PHONE_NUM,
            m.ALT_FAC_CONTACT_PHONE_EXT      = alt.CONTACT_PHONE_EXT,
            m.ALT_FAC_PRINTED_NAME           = alt.PS_NAME,
            m.ALT_FAC_SIGNATURE_DATE         = alt.PS_DATE,
            m.ALT_FAC_ESIG_SIGNATURE_DATE    = alt.ES_SIGN_DATE,
            m.ALT_FAC_ESIG_FIRST_NAME        = alt.ES_SIGNER_FIRST_NAME,
            m.ALT_FAC_ESIG_LAST_NAME         = alt.ES_SIGNER_LAST_NAME,
            m.EMERGENCY_PHONE_NUM            = coalesce(alt.EMERG_PHONE_NUM, tsdf.EMERG_PHONE_NUM, gen.EMERG_PHONE_NUM),
            m.EMERGENCY_PHONE_EXT            = coalesce(alt.EMERG_PHONE_EXT, tsdf.EMERG_PHONE_EXT, gen.EMERG_PHONE_EXT)
        from dbo.RCRA_EM_EMANIFEST m
                 left join dbo.RCRA_EM_HANDLER gen
                           on m.EM_EMANIFEST_ID = gen.EM_EMANIFEST_ID and gen.MANIFEST_HANDLER_TYPE = 'Generator'
                 left join dbo.RCRA_EM_HANDLER tsdf
                           on m.EM_EMANIFEST_ID = tsdf.EM_EMANIFEST_ID and
                              tsdf.MANIFEST_HANDLER_TYPE = 'DesignatedFacility'
                 left join dbo.RCRA_EM_HANDLER alt on m.EM_EMANIFEST_ID = alt.EM_EMANIFEST_ID and
                                                      alt.MANIFEST_HANDLER_TYPE in ('AlternateDesignateFacility', 'AlternateDesignatedFacility')
        where 1 = 1
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Count of updated RCRA_EM_EMANIFEST records with generator, destination and alt dest handler info: '
            + cast(@@rowcount as varchar(10))
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping updating RCRA_EM_EMANIFEST records with generator, destination and alt destination handler info '
        + 'since the dbo.RCRA_EM_HANDLER table does not exist'

if object_id('dbo.RCRA_EM_HANDLER') is not null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Inserting RCRA_EM_TRANSPORTER records from the RCRA_EM_HANDLER table'
        insert into dbo.RCRA_EM_TRANSPORTER (EM_EMANIFEST_ID, TRANSPORTER_ID, TRANSPORTER_NAME,
                                             TRANSPORTER_PRINTED_NAME,
                                             TRANSPORTER_SIGNATURE_DATE, TRANSPORTER_ESIG_FIRST_NAME,
                                             TRANSPORTER_ESIG_LAST_NAME, TRANS_ESIG_SIGNATURE_DATE,
                                             TRANSPORTER_LINE_NUM,
                                             TRANSPORTER_REGISTERED)
        select h.EM_EMANIFEST_ID,
               h.EPA_SITE_ID,
               h.MANIFEST_NAME,
               h.PS_NAME,
               h.PS_DATE,
               h.ES_SIGNER_FIRST_NAME,
               h.ES_SIGNER_LAST_NAME,
               h.ES_SIGN_DATE,
               h.ORDER_NUM,
               h.REG_IND
        from dbo.RCRA_EM_HANDLER h
        where h.MANIFEST_HANDLER_TYPE = 'Transporter'
          and not exists(
                select 1
                from dbo.RCRA_EM_TRANSPORTER t
                where t.EM_EMANIFEST_ID = h.EM_EMANIFEST_ID
                  and t.TRANSPORTER_LINE_NUM = h.ORDER_NUM
            )
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Count of inserted RCRA_EM_TRANSPORTER records: '
            + cast(@@rowcount as varchar(10))
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping inserting RCRA_EM_TRANSPORTER records '
        + 'since the dbo.RCRA_EM_HANDLER table does not exist'

/*
 * Map rows from RCRA_EM_WASTE_CD_FED to RCRA_EM_FED_WASTE_CODE_DESC
 */
if object_id('dbo.RCRA_EM_WASTE_CD_FED') is not null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Inserting RCRA_EM_FED_WASTE_CODE_DESC records from the RCRA_EM_WASTE_CD_FED table'
        insert into dbo.RCRA_EM_FED_WASTE_CODE_DESC (EM_WASTE_ID, FED_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC, COI_IND)
        select f.EM_WASTE_ID, f.WASTE_CODE, f.WASTE_DESC, null
        from dbo.RCRA_EM_WASTE_CD_FED f
        where not exists(
                select 1
                from dbo.RCRA_EM_FED_WASTE_CODE_DESC fw
                where fw.EM_WASTE_ID = f.EM_WASTE_ID
                  and fw.FED_MANIFEST_WASTE_CODE = f.WASTE_CODE
            )
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Count of RCRA_EM_FED_WASTE_CODE_DESC records inserted from the RCRA_EM_WASTE_CD_FED table: '
            + cast(@@rowcount as varchar(10))
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping inserting RCRA_EM_FED_WASTE_CODE_DESC records '
        + 'since the dbo.RCRA_EM_WASTE_CD_FED table does not exist';

/*
 * Map rows from the RCRA_EM_WASTE_CD_TSDF and RCRA_EM_WASTE_CD_GEN tables to the RCRA_EM_STATE_WASTE_CODE_DESC table
 */
if object_id('dbo.RCRA_EM_WASTE_CD_TSDF') is not null and object_id('dbo.RCRA_EM_WASTE_CD_GEN') is not null
    begin
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Inserting RCRA_EM_STATE_WASTE_CODE_DESC records from the RCRA_EM_WASTE_CD_TSDF and RCRA_EM_WASTE_CD_GEN tables';
        with x(WASTE_ID, WASTE_CODE, WASTE_DESC) as (select t.EM_WASTE_ID, t.WASTE_CODE, t.WASTE_DESC
                                                     from dbo.RCRA_EM_WASTE_CD_TSDF t
                                                     union all
                                                     select g.EM_WASTE_ID, g.WASTE_CODE, g.WASTE_DESC
                                                     from dbo.RCRA_EM_WASTE_CD_GEN g)
        insert
        into dbo.RCRA_EM_STATE_WASTE_CODE_DESC (EM_WASTE_ID, STA_MANIFEST_WASTE_CODE, MANIFEST_WASTE_DESC)
        select WASTE_ID, WASTE_CODE, WASTE_DESC
        from x
        where not exists(
                select 1
                from dbo.RCRA_EM_STATE_WASTE_CODE_DESC sw
                where sw.EM_WASTE_ID = x.WASTE_ID
                  and sw.STA_MANIFEST_WASTE_CODE = x.WASTE_CODE
            );
        print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
            + 'Count of RCRA_EM_STATE_WASTE_CODE_DESC records inserted from the RCRA_EM_WASTE_CD_TSDF '
            +  'and RCRA_EM_WASTE_CD_GEN tables: ' + cast(@@rowcount as varchar(10))
    end
else
    print format(getdate(), 'yyyy-MM-dd HH:mm:ss.fff') + ': '
        + 'Skipping inserting RCRA_EM_STATE_WASTE_CODE_DESC records '
        + 'since the dbo.RCRA_EM_WASTE_CD_TSDF or dbo.RCRA_EM_WASTE_CD_GEN tables do not exist';
/*
 * Remove the old DB structures
 */
declare x cursor for
    select t.type_code, t.obj_name, t.obj_def, t.target_name
    from (values
              -- drop tables
              (1, 'DT', 'dbo.RCRA_EM_WASTE_CD_TSDF', null, null),
              (2, 'DT', 'dbo.RCRA_EM_WASTE_CD_GEN', null, null),
              (3, 'DT', 'dbo.RCRA_EM_WASTE_CD_FED', null, null),
              (4, 'DT', 'dbo.RCRA_EM_TR_NUM_WASTE', null, null),
              (5, 'DT', 'dbo.RCRA_EM_TR_NUM_REJ', null, null),
              (6, 'DT', 'dbo.RCRA_EM_TR_NUM_ORIG', null, null),
              (7, 'DT', 'dbo.RCRA_EM_TR_NUM_RESIDUE_NEW', null, null),
              (8, 'DT', 'dbo.RCRA_EM_HANDLER', null, null),
              -- drop columns
              (9, 'DC', 'BR_IND', null, 'dbo.RCRA_EM_WASTE'),
              (10, 'DC', 'DISCREPANCY_IND', null, 'dbo.RCRA_EM_EMANIFEST'),
              (11, 'DC', 'CERT_BY_USER_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (12, 'DC', 'REJ_COMMENTS', null, 'dbo.RCRA_EM_EMANIFEST'),
              (13, 'DC', 'REJ_GEN_ES_SIGNER_USER_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (14, 'DC', 'REJ_GEN_ES_DOC_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (15, 'DC', 'REJ_GEN_ES_DOC_SIZE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (16, 'DC', 'IMP_PORT_STATE_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (17, 'DC', 'PRINTED_DOC_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (18, 'DC', 'PRINTED_DOC_SIZE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (19, 'DC', 'FORM_DOC_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (20, 'DC', 'FORM_DOC_SIZE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (21, 'DC', 'ADD_INFO_NEW_MAN_DEST', null, 'dbo.RCRA_EM_EMANIFEST'),
              (22, 'DC', 'CORR_VERSION_NUM', null, 'dbo.RCRA_EM_EMANIFEST'),
              (23, 'DC', 'CORR_ES_SIGNER_USER_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (24, 'DC', 'CORR_ES_DOC_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (25, 'DC', 'CORR_ES_DOC_SIZE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (26, 'DC', 'HANDLER_ID', null, 'dbo.RCRA_EM_EMANIFEST_COMMENT'),
              (27, 'DC', 'ADD_INFO_NEW_MAN_DEST', null, 'dbo.RCRA_EM_WASTE'),
              (28, 'DC', 'HANDLER_ID', null, 'dbo.RCRA_EM_WASTE_COMMENT'),
              (29, 'DC', 'ADD_INFO_CONSENT_NUM', null, 'dbo.RCRA_EM_EMANIFEST'),
              (30, 'DC', 'CERT_BY_FIRST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (31, 'DC', 'CERT_BY_LAST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (32, 'DC', 'CONT_PREV_REJ_RES_IND', null, 'dbo.RCRA_EM_EMANIFEST'),
              (33, 'DC', 'CORR_ACTIVE_IND', null, 'dbo.RCRA_EM_EMANIFEST'),
              (34, 'DC', 'CORR_EPA_SITE_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (35, 'DC', 'CORR_ES_CROMERR_ACT_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (36, 'DC', 'CORR_ES_CROMERR_DOC_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (37, 'DC', 'CORR_ES_DOC_MIME_TYPE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (38, 'DC', 'CORR_ES_SIGN_DATE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (39, 'DC', 'CORR_ES_SIGNER_FIRST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (40, 'DC', 'CORR_ES_SIGNER_LAST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (41, 'DC', 'FORM_DOC_MIME_TYPE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (42, 'DC', 'PRINTED_DOC_MIME_TYPE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (43, 'DC', 'PUBLIC_IND', null, 'dbo.RCRA_EM_EMANIFEST'),
              (44, 'DC', 'REJ_GEN_ES_CROMERR_ACT_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (45, 'DC', 'REJ_GEN_ES_CROMERR_DOC_ID', null, 'dbo.RCRA_EM_EMANIFEST'),
              (46, 'DC', 'REJ_GEN_ES_DOC_MIME_TYPE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (47, 'DC', 'REJ_GEN_ES_SIGN_DATE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (48, 'DC', 'REJ_GEN_ES_SIGNER_FIRST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (49, 'DC', 'REJ_GEN_ES_SIGNER_LAST_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (50, 'DC', 'REJ_GEN_PS_DATE', null, 'dbo.RCRA_EM_EMANIFEST'),
              (51, 'DC', 'REJ_GEN_PS_NAME', null, 'dbo.RCRA_EM_EMANIFEST'),
              (52, 'DC', 'SIGN_STATUS_IND', null, 'dbo.RCRA_EM_EMANIFEST')
             --
         ) as t(sort_order, type_code, obj_name, obj_def, target_name)
    order by t.sort_order;
open x;
declare @type_code varchar(100);
declare @obj_name varchar(200);
declare @target_name varchar(max);
declare @obj_def varchar(max);
fetch x into @type_code, @obj_name, @obj_def, @target_name;
while @@fetch_status = 0
    begin
        exec #handle_db_action @type_code = @type_code,
             @obj_name = @obj_name,
             @obj_def = @obj_def,
             @target_name = @target_name
        fetch x into @type_code, @obj_name, @obj_def, @target_name;
    end
close x;
deallocate x;
