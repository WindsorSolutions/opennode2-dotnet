/*
Copyright (c) 2016, The Environmental Council of the States (ECOS)
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

/*****************************************************************************************************************************
 *
 *  Script Name:  RCRA_5.11_to_5.12-upgrade_SQL-DDL.sql
 *
 *  Company:  Windsor Solutions, Inc.
 *
 *  Purpose:  This DDL script will alter the SQL database objects supporting the RCRA v5.11 data flow to conform with
 *            the RCRA v5.12 schema.
 *
 *  Maintenance:
 *
 *    Analyst         Date            Comment
 *    ----------      ----------      ------------------------------------------------------------------------------
 *    Windsor         01/03/2022      Created
 *
 ****************************************************************************************************************************
 */
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL Serializable
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping extended properties'
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ADD_INFO_CONSENT_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ADD_INFO_HAND_INSTR'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ADD_INFO_NEW_MAN_DEST'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CERT_BY_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CERT_BY_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CERT_BY_USER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CONT_PREV_REJ_RES_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ACTIVE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_EPA_SITE_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_CROMERR_ACT_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_CROMERR_DOC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_DOC_MIME_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_DOC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_DOC_SIZE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_SIGN_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_SIGNER_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_SIGNER_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_ES_SIGNER_USER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'CORR_VERSION_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DISCREPANCY_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FORM_DOC_MIME_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FORM_DOC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FORM_DOC_SIZE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_ADDRESS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_CNTRY_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_CNTRY_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_POSTAL_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_GEN_PROVINCE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_PORT_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_PORT_STATE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMP_PORT_STATE_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PRINTED_DOC_MIME_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PRINTED_DOC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PRINTED_DOC_SIZE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PUBLIC_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_ALT_DES_FAC_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_COMMENTS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_CROMERR_ACT_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_CROMERR_DOC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_DOC_MIME_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_DOC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_DOC_SIZE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_SIGN_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_SIGNER_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_SIGNER_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_ES_SIGNER_USER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_PS_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_GEN_PS_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_TRANS_ON_SITE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJ_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'RESIDUE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'SIGN_STATUS_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'COMMENT_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'COMMENT_LABEL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'HANDLER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'ADD_INFO_CONSENT_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'ADD_INFO_HAND_INSTR'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'ADD_INFO_NEW_MAN_DEST'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_FORM_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_SRC_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_WM_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_WM_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISC_COMMENTS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISC_RESIDUE_COMMENTS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISC_RESIDUE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISC_WASTE_QTY_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISC_WASTE_TYPE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DOT_HAZ_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DOT_ID_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'EPA_WASTE_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'MGMT_METHOD_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'MGMT_METHOD_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'PCB_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_CONT_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_CONT_TYPE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_CONT_TYPE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_UOM_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_UOM_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNT_VAL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'WASTES_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'COMMENT_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'COMMENT_LABEL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_dropextendedproperty N'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'HANDLER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_HANDLER]'
GO
ALTER TABLE [dbo].[RCRA_EM_HANDLER] DROP CONSTRAINT [FK_EM_HANDLER_EM_EMANIFEST]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_TR_NUM_ORIG]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_ORIG] DROP CONSTRAINT [FK_EM_TR_NUM_ORIG_EM_EMANIFEST]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_TR_NUM_REJ]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_REJ] DROP CONSTRAINT [FK_EM_TR_NUM_REJ_EM_EMANIFEST]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW] DROP CONSTRAINT [FK_EM_TR_NM_RSDUE_NW_EM_EMNFST]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_TR_NUM_WASTE]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_WASTE] DROP CONSTRAINT [FK_EM_TR_NUM_WASTE_EM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_WASTE_CD_FED]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_FED] DROP CONSTRAINT [FK_EM_WASTE_CD_FED_EM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_WASTE_CD_GEN]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_GEN] DROP CONSTRAINT [FK_EM_WASTE_CD_GEN_EM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping foreign keys from [dbo].[RCRA_EM_WASTE_CD_TSDF]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_TSDF] DROP CONSTRAINT [FK_EM_WASTE_CD_TSDF_EM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_HANDLER]'
GO
ALTER TABLE [dbo].[RCRA_EM_HANDLER] DROP CONSTRAINT [PK_EM_HANDLER]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_TR_NUM_ORIG]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_ORIG] DROP CONSTRAINT [PK_EM_TR_NUM_ORIG]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_TR_NUM_REJ]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_REJ] DROP CONSTRAINT [PK_EM_TR_NUM_REJ]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW] DROP CONSTRAINT [PK_EM_TR_NUM_RESIDUE_NEW]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_TR_NUM_WASTE]'
GO
ALTER TABLE [dbo].[RCRA_EM_TR_NUM_WASTE] DROP CONSTRAINT [PK_EM_TR_NUM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_WASTE_CD_FED]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_FED] DROP CONSTRAINT [PK_EM_WASTE_CD_FED]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_WASTE_CD_GEN]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_GEN] DROP CONSTRAINT [PK_EM_WASTE_CD_GEN]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping constraints from [dbo].[RCRA_EM_WASTE_CD_TSDF]'
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_CD_TSDF] DROP CONSTRAINT [PK_EM_WASTE_CD_TSDF]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_HANDLER_EM_EMANIFEST_ID] from [dbo].[RCRA_EM_HANDLER]'
GO
DROP INDEX [IX_EM_HANDLER_EM_EMANIFEST_ID] ON [dbo].[RCRA_EM_HANDLER]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_TR_NM_ORG_EM_EMNIFEST_ID] from [dbo].[RCRA_EM_TR_NUM_ORIG]'
GO
DROP INDEX [IX_EM_TR_NM_ORG_EM_EMNIFEST_ID] ON [dbo].[RCRA_EM_TR_NUM_ORIG]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_TR_NUM_RJ_EM_EMNIFEST_ID] from [dbo].[RCRA_EM_TR_NUM_REJ]'
GO
DROP INDEX [IX_EM_TR_NUM_RJ_EM_EMNIFEST_ID] ON [dbo].[RCRA_EM_TR_NUM_REJ]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_TR_NM_RSDE_NW_EM_EMNF_ID] from [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]'
GO
DROP INDEX [IX_EM_TR_NM_RSDE_NW_EM_EMNF_ID] ON [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_TR_NUM_WASTE_EM_WASTE_ID] from [dbo].[RCRA_EM_TR_NUM_WASTE]'
GO
DROP INDEX [IX_EM_TR_NUM_WASTE_EM_WASTE_ID] ON [dbo].[RCRA_EM_TR_NUM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_WASTE_CD_FED_EM_WASTE_ID] from [dbo].[RCRA_EM_WASTE_CD_FED]'
GO
DROP INDEX [IX_EM_WASTE_CD_FED_EM_WASTE_ID] ON [dbo].[RCRA_EM_WASTE_CD_FED]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_WASTE_CD_GEN_EM_WASTE_ID] from [dbo].[RCRA_EM_WASTE_CD_GEN]'
GO
DROP INDEX [IX_EM_WASTE_CD_GEN_EM_WASTE_ID] ON [dbo].[RCRA_EM_WASTE_CD_GEN]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping index [IX_EM_WASTE_CD_TSDF_EM_WSTE_ID] from [dbo].[RCRA_EM_WASTE_CD_TSDF]'
GO
DROP INDEX [IX_EM_WASTE_CD_TSDF_EM_WSTE_ID] ON [dbo].[RCRA_EM_WASTE_CD_TSDF]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_WASTE_CD_TSDF]'
GO
DROP TABLE [dbo].[RCRA_EM_WASTE_CD_TSDF]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_WASTE_CD_GEN]'
GO
DROP TABLE [dbo].[RCRA_EM_WASTE_CD_GEN]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_WASTE_CD_FED]'
GO
DROP TABLE [dbo].[RCRA_EM_WASTE_CD_FED]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_TR_NUM_WASTE]'
GO
DROP TABLE [dbo].[RCRA_EM_TR_NUM_WASTE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_TR_NUM_REJ]'
GO
DROP TABLE [dbo].[RCRA_EM_TR_NUM_REJ]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_TR_NUM_ORIG]'
GO
DROP TABLE [dbo].[RCRA_EM_TR_NUM_ORIG]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]'
GO
DROP TABLE [dbo].[RCRA_EM_TR_NUM_RESIDUE_NEW]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Dropping [dbo].[RCRA_EM_HANDLER]'
GO
DROP TABLE [dbo].[RCRA_EM_HANDLER]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [dbo].[RCRA_EM_EMANIFEST]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_EMANIFEST] ADD
[GENERATOR_MAIL_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_MAIL_CITY] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_LOC_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_LOC_CITY] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_LOC_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_LOC_ZIP] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_CONTACT_PHONE_NUM] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_CONTACT_PHONE_EXT] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_CONTACT_COMPANY_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EMERGENCY_PHONE_NUM] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[EMERGENCY_PHONE_EXT] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[GENERATOR_PRINTED_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_ID] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_MAIL_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_MAIL_CITY] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_MAIL_CTRY] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_MAIL_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_MAIL_ZIP] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_LOC_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_LOC_CITY] [varchar] (35) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_LOC_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_LOC_ZIP] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_CONTACT_PHONE_NUM] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_CONTACT_PHONE_EXT] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_CONTACT_EMAIL] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_CONTACT_COMPANY_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_PRINTED_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_ESIG_FIRST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_ESIG_LAST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DES_FAC_ESIG_SIGNATURE_DATE] [datetime] NULL,
[ORIG_SUBM_TYPE] [varchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[BROKER_ID] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LAST_EM_UPDT_DATE] [datetime] NULL,
[ALT_FAC_PRINTED_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_SIGNATURE_DATE] [datetime] NULL,
[ALT_FAC_ESIG_FIRST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_ESIG_LAST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_ESIG_SIGNATURE_DATE] [datetime] NULL,
[ALT_FAC_ID] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_MAIL_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_MAIL_CITY] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_MAIL_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_MAIL_ZIP] [varchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_STREET_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_STREET_1] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_STREET_2] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_CITY] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_LOC_ZIP] [varchar] (14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_FIRST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_LAST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_PHONE_NO] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_PHONE_EXT] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_EMAIL] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_CONTACT_COMPANY_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_REGISTERED] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[ALT_FAC_MODIFIED] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_STREET] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_CITY] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_CTRY_CODE] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_POST_CODE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FOREIGN_GENERATOR_PROVINCE] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[PORT_OF_ENTRY_STA] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_EMANIFEST] DROP
COLUMN [CERT_BY_USER_ID],
COLUMN [REJ_COMMENTS],
COLUMN [REJ_GEN_ES_SIGNER_USER_ID],
COLUMN [REJ_GEN_ES_DOC_NAME],
COLUMN [REJ_GEN_ES_DOC_SIZE],
COLUMN [IMP_PORT_CITY],
COLUMN [IMP_PORT_STATE_NAME],
COLUMN [PRINTED_DOC_NAME],
COLUMN [PRINTED_DOC_SIZE],
COLUMN [FORM_DOC_NAME],
COLUMN [FORM_DOC_SIZE],
COLUMN [ADD_INFO_NEW_MAN_DEST],
COLUMN [ADD_INFO_CONSENT_NUM],
COLUMN [CORR_VERSION_NUM],
COLUMN [CORR_ES_SIGNER_USER_ID],
COLUMN [CORR_ES_DOC_NAME],
COLUMN [CORR_ES_DOC_SIZE]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_EPA_SITE_ID]', N'GENERATOR_ID', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_PS_NAME]', N'GENERATOR_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[PRINTED_DOC_MIME_TYPE]', N'GENERATOR_MAIL_STREET_1', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[FORM_DOC_MIME_TYPE]', N'GENERATOR_MAIL_STREET_2', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_PORT_STATE_CODE]', N'GENERATOR_MAIL_CTRY', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_CNTRY_CODE]', N'GENERATOR_MAIL_STA', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_POSTAL_CODE]', N'GENERATOR_MAIL_ZIP', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_DOC_MIME_TYPE]', N'GENERATOR_LOC_STREET_1', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_DOC_MIME_TYPE]', N'GENERATOR_LOC_STREET_2', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CERT_BY_FIRST_NAME]', N'GENERATOR_CONTACT_FIRST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CERT_BY_LAST_NAME]', N'GENERATOR_CONTACT_LAST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_NAME]', N'GENERATOR_CONTACT_EMAIL', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_SIGN_DATE]', N'GENERATOR_SIGNATURE_DATE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_SIGNER_FIRST_NAME]', N'GENERATOR_ESIG_FIRST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_SIGNER_LAST_NAME]', N'GENERATOR_ESIG_LAST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_SIGN_DATE]', N'GENERATOR_ESIG_SIGNATURE_DATE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_TRANS_ON_SITE_IND]', N'GENERATOR_REGISTERED', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[SIGN_STATUS_IND]', N'GENERATOR_MODIFIED', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_ADDRESS]', N'DES_FAC_MAIL_STREET_1', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_PROVINCE]', N'DES_FAC_MAIL_STREET_2', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_CROMERR_ACT_ID]', N'DES_FAC_LOC_STREET_1', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_CROMERR_ACT_ID]', N'DES_FAC_LOC_STREET_2', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_SIGNER_FIRST_NAME]', N'DES_FAC_CONTACT_FIRST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_SIGNER_LAST_NAME]', N'DES_FAC_CONTACT_LAST_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_PS_DATE]', N'DES_FAC_SIGNATURE_DATE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[DISCREPANCY_IND]', N'DES_FAC_REGISTERED', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[RESIDUE_IND]', N'DES_FAC_MODIFIED', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_IND]', N'RESIDUE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[PUBLIC_IND]', N'IMPORT', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[ADD_INFO_HAND_INSTR]', N'MANIFEST_HANDLING_INSTR', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ACTIVE_IND]', N'COI_ONLY', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CONT_PREV_REJ_RES_IND]', N'TRANSPORTER_ON_SITE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_TYPE]', N'REJECTION_TYPE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_ALT_DES_FAC_TYPE]', N'ALTERNATE_DESIGNATED_FAC_TYPE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[CORR_ES_CROMERR_DOC_ID]', N'ALT_FAC_MAIL_STREET_1', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[REJ_GEN_ES_CROMERR_DOC_ID]', N'ALT_FAC_MAIL_STREET_2', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_CNTRY_NAME]', N'FOREIGN_GENERATOR_CTRY_NAME', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST].[IMP_GEN_CITY]', N'PORT_OF_ENTRY_CITY', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [dbo].[RCRA_EM_EMANIFEST_COMMENT]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_EMANIFEST_COMMENT] ADD
[CMNT_DESC] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_EMANIFEST_COMMENT] DROP
COLUMN [COMMENT_DESC],
COLUMN [HANDLER_ID]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_EMANIFEST_COMMENT].[COMMENT_LABEL]', N'CMNT_LABEL', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [dbo].[RCRA_EM_WASTE]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE] ADD
[DOT_ID_NUM_DESC] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CONTAINER_TYPE_CODE] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CONTAINER_TYPE_DESC] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DISCREPANCY_COMM] [varchar] (257) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[CNST_NUM] [varchar] (12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[COI_ONLY] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[QNTY_ACUTE_KG] [decimal] (14, 6) NULL,
[QNTY_ACUTE_TONS] [decimal] (14, 6) NULL,
[QNTY_KG] [decimal] (14, 6) NULL,
[QNTY_NON_ACUTE_KG] [decimal] (14, 6) NULL,
[QNTY_NON_ACUTE_TONS] [decimal] (14, 6) NULL,
[QNTY_TONS] [decimal] (14, 6) NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE] DROP
COLUMN [DOT_ID_NUM],
COLUMN [QNT_CONT_TYPE_CODE],
COLUMN [QNT_CONT_TYPE_DESC],
COLUMN [DISC_RESIDUE_COMMENTS],
COLUMN [ADD_INFO_NEW_MAN_DEST],
COLUMN [ADD_INFO_CONSENT_NUM]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[DOT_HAZ_IND]', N'DOT_HAZRD', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[WASTES_DESC]', N'NON_HAZ_WASTE_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[QNT_CONT_NUM]', N'CONTAINER_NUM', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[QNT_VAL]', N'QNTY_VAL', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[QNT_UOM_CODE]', N'QTY_UNIT_OF_MEAS_CODE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[QNT_UOM_DESC]', N'QTY_UNIT_OF_MEAS_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[BR_FORM_DESC]', N'BR_FORM_CODE_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[BR_SRC_DESC]', N'BR_SRC_CODE_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[BR_WM_CODE]', N'BR_WASTE_MIN_CODE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[BR_WM_DESC]', N'BR_WASTE_MIN_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[EPA_WASTE_IND]', N'BR_MIXED_RADIOACTIVE_WASTE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[PCB_IND]', N'PCB', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[BR_IND]', N'QNTY_DISCREPANCY', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[DISC_WASTE_TYPE_IND]', N'WASTE_TYPE_DISCREPANCY', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[DISC_RESIDUE_IND]', N'WASTE_RESIDUE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[DISC_COMMENTS]', N'WASTE_RESIDUE_COMM', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[MGMT_METHOD_CODE]', N'MANAGEMENT_METH_CODE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[MGMT_METHOD_DESC]', N'MANAGEMENT_METH_DESC', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[ADD_INFO_HAND_INSTR]', N'HANDLING_INSTRUCTIONS', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE].[DISC_WASTE_QTY_IND]', N'EPA_WASTE', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[RCRA_EM_FED_WASTE_CODE_DESC]'
GO
CREATE TABLE [dbo].[RCRA_EM_FED_WASTE_CODE_DESC]
(
[EM_FED_WASTE_CODE_DESC_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EM_WASTE_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[FED_MANIFEST_WASTE_CODE] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MANIFEST_WASTE_DESC] [varchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[COI_IND] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_EM_FED_WASTE_CODE_DESC] on [dbo].[RCRA_EM_FED_WASTE_CODE_DESC]'
GO
ALTER TABLE [dbo].[RCRA_EM_FED_WASTE_CODE_DESC] ADD CONSTRAINT [PK_EM_FED_WASTE_CODE_DESC] PRIMARY KEY CLUSTERED ([EM_FED_WASTE_CODE_DESC_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_EM_FD_WST_CDE_DSC_EM_WST_ID] on [dbo].[RCRA_EM_FED_WASTE_CODE_DESC]'
GO
CREATE NONCLUSTERED INDEX [IX_EM_FD_WST_CDE_DSC_EM_WST_ID] ON [dbo].[RCRA_EM_FED_WASTE_CODE_DESC] ([EM_WASTE_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC]'
GO
CREATE TABLE [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC]
(
[EM_STATE_WASTE_CODE_DESC_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EM_WASTE_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[STA_MANIFEST_WASTE_CODE] [varchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[MANIFEST_WASTE_DESC] [varchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_EM_STATE_WASTE_CODE_DESC] on [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC]'
GO
ALTER TABLE [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC] ADD CONSTRAINT [PK_EM_STATE_WASTE_CODE_DESC] PRIMARY KEY CLUSTERED ([EM_STATE_WASTE_CODE_DESC_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_EM_STT_WST_CDE_DSC_EM_WS_ID] on [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC]'
GO
CREATE NONCLUSTERED INDEX [IX_EM_STT_WST_CDE_DSC_EM_WS_ID] ON [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC] ([EM_WASTE_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[RCRA_EM_TRANSPORTER]'
GO
CREATE TABLE [dbo].[RCRA_EM_TRANSPORTER]
(
[EM_TRANSPORTER_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[EM_EMANIFEST_ID] [varchar] (40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[TRANSPORTER_ID] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANSPORTER_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANSPORTER_PRINTED_NAME] [varchar] (80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANSPORTER_SIGNATURE_DATE] [datetime] NULL,
[TRANSPORTER_ESIG_FIRST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANSPORTER_ESIG_LAST_NAME] [varchar] (38) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANS_ESIG_SIGNATURE_DATE] [datetime] NULL,
[TRANSPORTER_LINE_NUM] [varchar] (19) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[TRANSPORTER_REGISTERED] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_EM_TRANSPORTER] on [dbo].[RCRA_EM_TRANSPORTER]'
GO
ALTER TABLE [dbo].[RCRA_EM_TRANSPORTER] ADD CONSTRAINT [PK_EM_TRANSPORTER] PRIMARY KEY CLUSTERED ([EM_TRANSPORTER_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_EM_TRNSPORTER_EM_EMNIFST_ID] on [dbo].[RCRA_EM_TRANSPORTER]'
GO
CREATE NONCLUSTERED INDEX [IX_EM_TRNSPORTER_EM_EMNIFST_ID] ON [dbo].[RCRA_EM_TRANSPORTER] ([EM_EMANIFEST_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [dbo].[RCRA_EM_WASTE_COMMENT]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_COMMENT] ADD
[CMNT_DESC] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_COMMENT] DROP
COLUMN [COMMENT_DESC],
COLUMN [HANDLER_ID]
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
EXEC sp_rename N'[dbo].[RCRA_EM_WASTE_COMMENT].[COMMENT_LABEL]', N'CMNT_LABEL', N'COLUMN'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering [dbo].[RCRA_EM_WASTE_PCB]'
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_PCB] ADD
[LOAD_TYPE_DESC] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_PCB] ALTER COLUMN [PCB_LOAD_TYPE_CODE] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
ALTER TABLE [dbo].[RCRA_EM_WASTE_PCB] ALTER COLUMN [PCB_WASTE_TYPE] [varchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[RCRA_EM_FED_WASTE_CODE_DESC]'
GO
ALTER TABLE [dbo].[RCRA_EM_FED_WASTE_CODE_DESC] ADD CONSTRAINT [FK_EM_FED_WSTE_CDE_DSC_EM_WSTE] FOREIGN KEY ([EM_WASTE_ID]) REFERENCES [dbo].[RCRA_EM_WASTE] ([EM_WASTE_ID]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC]'
GO
ALTER TABLE [dbo].[RCRA_EM_STATE_WASTE_CODE_DESC] ADD CONSTRAINT [FK_EM_STTE_WSTE_CDE_DSC_EM_WST] FOREIGN KEY ([EM_WASTE_ID]) REFERENCES [dbo].[RCRA_EM_WASTE] ([EM_WASTE_ID]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[RCRA_EM_TRANSPORTER]'
GO
ALTER TABLE [dbo].[RCRA_EM_TRANSPORTER] ADD CONSTRAINT [FK_EM_TRANSPORTER_EM_EMANIFEST] FOREIGN KEY ([EM_EMANIFEST_ID]) REFERENCES [dbo].[RCRA_EM_EMANIFEST] ([EM_EMANIFEST_ID]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Altering extended properties'
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'Schema element: ManifestWaste', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'BR density information (BrDensity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_DENSITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'BR density unit of measurement code (BrDensityUOMCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_DENSITY_UOM_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'BR density unit of measurement description (BrDensityUOMDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_DENSITY_UOM_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'BR form code information (BrFormCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_FORM_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'BR source code information (BrSourceCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_SRC_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'Printed DOT information (DotPrintedInformation)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DOT_PRINTED_INFO'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'Parent: Additional omment (_PK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'EM_WASTE_COMMENT_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'Parent: Additional omment (_FK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'EM_WASTE_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_updateextendedproperty N'MS_Description', N'Load type information (LoadTypeCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_PCB', 'COLUMN', N'PCB_LOAD_TYPE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
PRINT N'Creating extended properties'
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact Company Name (AltFacContactCompanyName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_COMPANY_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact email (AltFacContactEmail)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_EMAIL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact first name (AltFacContactFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact last name (AltFacContactLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact phone ext (AltFacContactPhoneExt)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_PHONE_EXT'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Contact phone number (AltFacContactPhoneNo)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_CONTACT_PHONE_NO'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Esig first name (AltFacEsigFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_ESIG_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Esig last name (AltFacEsigLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_ESIG_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Esiog signature date (AltFacEsigSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_ESIG_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac id (AltFacilityId)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location city (AltFacLocationCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location state (AltFacLocationState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location street 1 (AltFacLocationStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location street 2 (AltFacLocationStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location street no (AltFacLocationStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Location zip (AltFacLocationZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_LOC_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail city (AltFacMailCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail state (AltFacMailState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail street 1 (AltFacMailStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail street 2 (AltFacMailStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail street no (AltFacMailStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac mail zip (AltFacMailZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MAIL_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Modified indicator (AltFacModified)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_MODIFIED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac name (AltFacilityName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac printed name (AltFacPrintedName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_PRINTED_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac Registered indicator (AltFacRegistered)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_REGISTERED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alt Fac signature date (AltFacSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALT_FAC_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Alternate designated facility type (AlternateDesignatedFacilityType)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ALTERNATE_DESIGNATED_FAC_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Broker id (BrokerId)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'BROKER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Is public indicator (COIOnly)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'COI_ONLY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact company name (DesFacContactCompanyName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_COMPANY_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact email (DesFacContactEmail)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_EMAIL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact first name (DesFacContactFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact last name (DesFacContactLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact phone extension (DesFacContactPhoneExt)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_PHONE_EXT'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac contact phone number (DesFacContactPhoneNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_CONTACT_PHONE_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac esig first name (DesFacEsigFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_ESIG_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac esig last name (DesFacEsigLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_ESIG_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac esig signature date (DesFacEsigSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_ESIG_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Des facility Id (DesFacilityId)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location city (DesFacLocationCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location state (DesFacLocationState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location street 1 (DesFacLocationStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location street 2 (DesFacLocationStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location street number (DesFacLocationStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac location zip code (DesFacLocationZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_LOC_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail city (DesFacMailCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail country (DesFacMailCountry)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_CTRY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail state (DesFacMailState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail street 1 (DesFacMailStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail street 2 (DesFacMailStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail street number (DesFacMailStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac mail zip code (DesFacMailZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MAIL_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac modified (DesFacModified)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_MODIFIED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Des facility name (DesFacilityName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac printed name (DesFacPrintedName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_PRINTED_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac registered (DesFacRegistered)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_REGISTERED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'DesFac signature date (DesFacSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'DES_FAC_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Emergency phone extension (EmergencyPhoneExt)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'EMERGENCY_PHONE_EXT'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Emergency phone number (EmergencyPhoneNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'EMERGENCY_PHONE_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator city (ForeignGeneratorCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator country code (ForeignGeneratorCountryCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_CTRY_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator country name (ForeignGeneratorCountryName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_CTRY_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator name (ForeignGeneratorName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator postal code (ForeignGeneratorPostalCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_POST_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator province (ForeignGeneratorProvince)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_PROVINCE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Foreign generator street (ForeignGeneratorStreet)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'FOREIGN_GENERATOR_STREET'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact company name (GeneratorContactCompanyName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_COMPANY_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact email (GeneratorContactEmail)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_EMAIL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact first name (GeneratorContactFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact last name (GeneratorContactLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact phone extension (GeneratorContactPhoneExt)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_PHONE_EXT'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator contact phone number (GeneratorContactPhoneNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_CONTACT_PHONE_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator esig first name (GeneratorEsigFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_ESIG_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator esig last name (GeneratorEsigLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_ESIG_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator esig signature date (GeneratorEsigSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_ESIG_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator Id (GeneratorId)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location city (GeneratorLocationCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location state (GeneratorLocationState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location street 1 (GeneratorLocationStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location street 2 (GeneratorLocationStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location street number (GeneratorLocationStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator location zip code (GeneratorLocationZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_LOC_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail city (GeneratorMailCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail country (GeneratorMailCountry)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_CTRY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail state (GeneratorMailState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail street 1 (GeneratorMailStreet1)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_STREET_1'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail street 2 (GeneratorMailStreet2)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_STREET_2'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail street number (GeneratorMailStreetNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_STREET_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator mail zip code (GeneratorMailZip)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MAIL_ZIP'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator modified (GeneratorModified)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_MODIFIED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator name (GeneratorName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator printed name (GeneratorPrintedName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_PRINTED_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator registered (GeneratorRegistered)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_REGISTERED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Generator signature date (GeneratorSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'GENERATOR_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Import indicator (Import)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'IMPORT'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Last EM record cahnged date (LastEMUpdatedDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'LAST_EM_UPDT_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Manifest handling instruction (ManifestHandlingInstr)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'MANIFEST_HANDLING_INSTR'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Orig submission type (OrigSubmissionType)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'ORIG_SUBM_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Port of entry city (PortOfEntryCity)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PORT_OF_ENTRY_CITY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Port of entry state (PortOfEntryState)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'PORT_OF_ENTRY_STA'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Rejection type (RejectionType)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'REJECTION_TYPE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicate residue information (Residue)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'RESIDUE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicates if transporter is on site (TransporterOnSite)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST', 'COLUMN', N'TRANSPORTER_ON_SITE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Comment description (CommentDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'CMNT_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Comment label (CommentLabel)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'CMNT_LABEL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Additional omment (_PK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'EM_EMANIFEST_COMMENT_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Additional omment (_FK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_EMANIFEST_COMMENT', 'COLUMN', N'EM_EMANIFEST_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Schema element: FedManifestWasteCodeDescription', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'COI indicator. (COIIndicator)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', 'COLUMN', N'COI_IND'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Wastes information (_PK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', 'COLUMN', N'EM_FED_WASTE_CODE_DESC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Wastes information (_FK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', 'COLUMN', N'EM_WASTE_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Fed manifest waste code information (FedManifestWasteCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', 'COLUMN', N'FED_MANIFEST_WASTE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Manifest waste description information (ManifestWasteDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_FED_WASTE_CODE_DESC', 'COLUMN', N'MANIFEST_WASTE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Schema element: StateManifestWasteCodeDescription', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_STATE_WASTE_CODE_DESC', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Wastes information (_PK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_STATE_WASTE_CODE_DESC', 'COLUMN', N'EM_STATE_WASTE_CODE_DESC_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Wastes information (_FK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_STATE_WASTE_CODE_DESC', 'COLUMN', N'EM_WASTE_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Manifest waste description information (ManifestWasteDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_STATE_WASTE_CODE_DESC', 'COLUMN', N'MANIFEST_WASTE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'State manifest waste code information (StateManifestWasteCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_STATE_WASTE_CODE_DESC', 'COLUMN', N'STA_MANIFEST_WASTE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Schema element: ManifestTransporter', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', NULL, NULL
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Transporter list (_FK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'EM_EMANIFEST_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Parent: Transporter list (_PK)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'EM_TRANSPORTER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Esig Signature Date. (TransEsigSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANS_ESIG_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Esig First Name. (TransporterEsigFirstName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_ESIG_FIRST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Esig Last Name. (TransporterEsigLastName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_ESIG_LAST_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Id. (TransporterId)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_ID'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Line Number. (TransporterLineNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_LINE_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Name. (TransporterName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Printed Name. (TransporterPrintedName)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_PRINTED_NAME'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Registered indicator. (TransporterRegistered)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_REGISTERED'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Transporter Signature Date. (TransporterSignatureDate)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_TRANSPORTER', 'COLUMN', N'TRANSPORTER_SIGNATURE_DATE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'BR form code description (BrFormCodeDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_FORM_CODE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Waste minimization description information (BrMixedRadioactiveWaste)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_MIXED_RADIOACTIVE_WASTE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'BR source code information (BrSourceCodeDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_SRC_CODE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Waste minimization code information (BrWasteMinCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_WASTE_MIN_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Waste minimization description information (BrWasteMinDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'BR_WASTE_MIN_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Identifies a consent number (ConsentNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'CNST_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Is public indicator (COIOnly)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'COI_ONLY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Container number information (ContainerNumber)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'CONTAINER_NUM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Container type code. (ContainerTypeCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'CONTAINER_TYPE_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Container type description information. (ContainerTypeDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'CONTAINER_TYPE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Discrepancy comments information (DiscrepancyComments)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DISCREPANCY_COMM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Hazardous indicator. (DotHazardous)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DOT_HAZRD'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Id number information (DotIdNumberDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'DOT_ID_NUM_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicate if it''s a waste (EpaWaste)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'EPA_WASTE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Identifies a handling instructions (HandlingInstructions)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'HANDLING_INSTRUCTIONS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Management method code information (ManagementMethodCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'MANAGEMENT_METH_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Management method description information (ManagementMethodDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'MANAGEMENT_METH_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Waste description. (NonHazWasteDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'NON_HAZ_WASTE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'PCB indicator. (Pcb)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'PCB'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity acute kg information (QuantityAcuteKg)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_ACUTE_KG'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity acute tons information (QuantityAcuteTons)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_ACUTE_TONS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicate waste quantity (QuantityDiscrepancy)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_DISCREPANCY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity kg information (QuantityKg)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_KG'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity non acute kg information (QuantityNonAcuteKg)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_NON_ACUTE_KG'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity non acute tons information (QuantityNonAcuteTons)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_NON_ACUTE_TONS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity tons information (QuantityTons)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_TONS'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Quantity Valure information (QuantityVal)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QNTY_VAL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Qty unit of measure code. (QtyUnitOfMeasureCode)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QTY_UNIT_OF_MEAS_CODE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Qty unit of measure description information. (QtyUnitOfMeasureDesc)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'QTY_UNIT_OF_MEAS_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicate residue information (WasteResidue)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'WASTE_RESIDUE'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Residue comments information (WasteResidueComments)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'WASTE_RESIDUE_COMM'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Indicate waste type (WasteTypeDiscrepancy)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE', 'COLUMN', N'WASTE_TYPE_DISCREPANCY'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Comment description (CommentDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'CMNT_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Comment label (CommentLabel)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_COMMENT', 'COLUMN', N'CMNT_LABEL'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
BEGIN TRY
	EXEC sp_addextendedproperty N'MS_Description', N'Load type description (LoadTypeDescription)', 'SCHEMA', N'dbo', 'TABLE', N'RCRA_EM_WASTE_PCB', 'COLUMN', N'LOAD_TYPE_DESC'
END TRY
BEGIN CATCH
	DECLARE @msg nvarchar(max);
	DECLARE @severity int;
	DECLARE @state int;
	SELECT @msg = ERROR_MESSAGE(), @severity = ERROR_SEVERITY(), @state = ERROR_STATE();
	RAISERROR(@msg, @severity, @state);

	SET NOEXEC ON
END CATCH
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
-- This statement writes to the SQL Server Log so SQL Monitor can show this deployment.
IF HAS_PERMS_BY_NAME(N'sys.xp_logevent', N'OBJECT', N'EXECUTE') = 1
BEGIN
    DECLARE @databaseName AS nvarchar(2048), @eventMessage AS nvarchar(2048)
    SET @databaseName = REPLACE(REPLACE(DB_NAME(), N'\', N'\\'), N'"', N'\"')
    SET @eventMessage = N'Redgate SQL Compare: { "deployment": { "description": "Redgate SQL Compare deployed to ' + @databaseName + N'", "database": "' + @databaseName + N'" }}'
    EXECUTE sys.xp_logevent 55000, @eventMessage
END
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
