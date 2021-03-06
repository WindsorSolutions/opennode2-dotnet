CREATE DATABASE TRIDEX
GO
USE TRIDEX
GO

/****** Object:  User [triviewer]    Script Date: 12/02/2010 14:15:34 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'triviewer')
CREATE USER [triviewer] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  View [dbo].[V_EXT_DIOXIN]    Script Date: 12/02/2010 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DIOXIN]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EXT_DIOXIN]

AS

SELECT

	CAST (NULL AS varchar(36)) AS [PK_GUID_SUB]
,	CAST (NULL AS varchar(36)) AS [PK_GUID_REP]
,	CAST (NULL AS varchar(100)) AS [FSID]
,	CAST (NULL AS varchar(100)) AS [EPA ID]
,	CAST (NULL AS varchar(100)) AS [TRIFID]
,	CAST (NULL AS varchar(100)) AS [Year]
,	CAST (NULL AS varchar(100)) AS [Revision]
,	CAST (NULL AS varchar(100)) AS [Partial Sub]
,	CAST (NULL AS varchar(1)) AS [Form]
,	CAST (NULL AS varchar(100)) AS [Facility Name]
,	CAST (NULL AS varchar(100)) AS [AKA]
,	CAST (NULL AS varchar(100)) AS [Address 1]
,	CAST (NULL AS varchar(100)) AS [Address 2]
,	CAST (NULL AS varchar(100)) AS [City]
,	CAST (NULL AS varchar(100)) AS [County]
,	CAST (NULL AS varchar(50)) AS [Zip]
,	CAST (NULL AS varchar(100)) AS [Chemical]
,	CAST (NULL AS varchar(100)) AS [CAS #]
,	CAST (NULL AS char(1)) AS [51 Fugitive Air - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [51 Fugitive Air - TEQ_17]
,	CAST (NULL AS char(1)) AS [52 Stack Air - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [52 Stack Air - TEQ_17]
,	CAST (NULL AS char(1)) AS [531 Water - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [531 Water - TEQ_17]
,	CAST (NULL AS char(1)) AS [532 Water - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [532 Water - TEQ_17]
,	CAST (NULL AS char(1)) AS [533 Water - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [533 Water - TEQ_17]
,	CAST (NULL AS char(1)) AS [541 UG INJ Class I - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [541 UG INJ Class I - TEQ_17]
,	CAST (NULL AS char(1)) AS [542 UG INJ Class II-V - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [542 UG INJ Class II-V - TEQ_17]
,	CAST (NULL AS char(1)) AS [551A RCRA C Landfill - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [551A RCRA C Landfill - TEQ_17]
,	CAST (NULL AS char(1)) AS [551B Other Landfill - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [551B Other Landfill - TEQ_17]
,	CAST (NULL AS char(1)) AS [552 Land Treatment - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [552 Land Treatment - TEQ_17]
,	CAST (NULL AS char(1)) AS [553A RCRA C SI - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [553A RCRA C SI - TEQ_17]
,	CAST (NULL AS char(1)) AS [553B Other SI - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [553B Other SI - TEQ_17]
,	CAST (NULL AS char(1)) AS [554 Other Disposal - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [554 Other Disposal - TEQ_17]
,	CAST (NULL AS char(1)) AS [POTW Waste Quantity - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [POTW Waste Quantity - TEQ_17]
,	CAST (NULL AS char(1)) AS [81A Ons Disp UG INJ C1 - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [81A Ons Disp UG INJ C1 - TEQ_17]
,	CAST (NULL AS char(1)) AS [81B Ons Disp Other - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [81B Ons Disp Other - TEQ_17]
,	CAST (NULL AS char(1)) AS [81C Off Disp UG INJ C1 - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [81C Off Disp UG INJ C1 - TEQ_17]
,	CAST (NULL AS char(1)) AS [81D Off Disp Other - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [81D Off Disp Other - TEQ_17]
,	CAST (NULL AS char(1)) AS [82 Ons Eng Rec - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [82 Ons Eng Rec - TEQ_17]
,	CAST (NULL AS char(1)) AS [83 Off Eng Rec - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [83 Off Eng Rec - TEQ_17]
,	CAST (NULL AS char(1)) AS [84 Ons Recycle - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [84 Ons Recycle - TEQ_17]
,	CAST (NULL AS char(1)) AS [85 Off Recycle - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [85 Off Recycle - TEQ_17]
,	CAST (NULL AS char(1)) AS [86 Ons Treated - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [86 Ons Treated - TEQ_17]
,	CAST (NULL AS char(1)) AS [87 Off Treated - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [87 Off Treated - TEQ_17]
,	CAST (NULL AS char(1)) AS [88 Remed One-Time - TEQ_NAInd]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_01]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_02]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_03]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_04]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_05]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_06]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_07]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_08]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_09]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_10]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_11]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_12]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_13]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_14]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_15]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_16]
,	CAST (NULL AS varchar(100)) AS [88 Remed One-Time - TEQ_17]
,	CAST (NULL AS varchar(100)) AS [SUBMISSION_REPORTING_YEAR]
,	CAST (NULL AS nvarchar(255)) AS [ECOLOGY_REGION]
,	CAST (NULL AS varchar(100)) AS [FS_ID]
,	CAST (NULL AS varchar(100)) AS [EPA_ID]
,	CAST (NULL AS varchar(100)) AS [COUNTY_NM]
,	CAST (NULL AS varchar(100)) AS [FAC_NAME]
,	CAST (NULL AS varchar(100)) AS [AgencyName]
,	CAST (NULL AS varchar(100)) AS [CHEMICAL_NAME_TEXT]

'
GO
/****** Object:  Table [dbo].[TRI_SUB]    Script Date: 12/02/2010 14:15:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SUB]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_SUB](
	[PK_GUID] [varchar](36) NOT NULL,
	[TRI_SUB_ID] [varchar](255) NOT NULL,
	[INSERTED_DATE] [datetime] NOT NULL,
	[TRANSACTION_ID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TRI_SUB] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [IX_TRI_SUB] UNIQUE NONCLUSTERED 
(
	[TRI_SUB_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[TRI_Update_TRI_REPORT_Defaults]    Script Date: 12/02/2010 14:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Update_TRI_REPORT_Defaults]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-06
-- Description:	Loads defaults for values in TRI_REPORT not supplied by TRI submission from EPA
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Update_TRI_REPORT_Defaults]
	-- Add the parameters for the stored procedure here
	@SUB_ID varchar(36)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @Err	INT
SET @Err = 0

    -- Update REPORT_EPA_PROCESSING_STATUS_C

-- 8/22/2008: All defaults have been removed.


--BEGIN TRAN
--UPDATE R
--
--SET R.REPORT_EPA_PROCESSING_STATUS_C = ''1''
--
--FROM TRI_REPORT R
--JOIN TRI_SUB S ON S.PK_GUID = R.FK_GUID
--WHERE
--ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '''') = ''''
--
--SET @Err = @@ERROR
--IF @Err <> 0
--	BEGIN
--		ROLLBACK TRAN
--		RAISERROR(''An error occurred while attempting to insert a new TRIFID into App_FI_TRIFID table.'', 16, 1)
--		RETURN @Err
--	END
--
--    -- Update REPORT_SUB_METH_CODE
--
--UPDATE R
--
--SET R.REPORT_SUB_METH_CODE = ''TRIME_WEB''
--
--FROM TRI_REPORT R
--JOIN TRI_SUB S ON S.PK_GUID = R.FK_GUID
--WHERE
--ISNULL(R.REPORT_SUB_METH_CODE, '''') = ''''
--
--SET @Err = @@ERROR
--IF @Err <> 0
--	BEGIN
--		ROLLBACK TRAN
--		RAISERROR(''An error occurred while attempting to insert a new TRIFID into App_FI_TRIFID table.'', 16, 1)
--		RETURN @Err
--	END
--	ELSE
--		COMMIT TRAN


END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_CalculateSubmissionStatus]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CalculateSubmissionStatus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2010-01-20
-- Description:	Calculates the submission status based upon the revision and withdrawal codes
-- =============================================
CREATE FUNCTION [dbo].[TRI_CalculateSubmissionStatus] 
(
	-- Add the parameters for the function here
	@CHEM_RPT_REV_CD_1	varchar(255)
,	@CHEM_RPT_REV_CD_2	varchar(255)
,	@CHEM_RPT_WD_CD_1	varchar(255)
,	@CHEM_RPT_WD_CD_2	varchar(255)
)
RETURNS varchar(255)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(255)

	-- Add the T-SQL statements to compute the return value here

	IF ISNULL(@CHEM_RPT_REV_CD_1, '''') <> ''''
		BEGIN
		SET @Result = CASE @CHEM_RPT_REV_CD_1
			WHEN ''RR1'' THEN ''Revision: New Monitoring Data''
			WHEN ''RR2'' THEN ''Revision: New Emission Factor(s)''
			WHEN ''RR3'' THEN ''Revision: New Chemical Concentration Data''
			WHEN ''RR4'' THEN ''Revision: Recalculation(s)''
			WHEN ''RR5'' THEN ''Revision: Other Reason(s)''
		ELSE ''Revision: Undetermined'' END
		END
	
	IF ISNULL(@CHEM_RPT_REV_CD_2, '''') <> ''''
		BEGIN
		SET @Result = @Result + '' / ''

		SET @Result = @Result + CASE @CHEM_RPT_REV_CD_2
			WHEN ''RR1'' THEN ''Revision (2): New Monitoring Data''
			WHEN ''RR2'' THEN ''Revision (2): New Emission Factor(s)''
			WHEN ''RR3'' THEN ''Revision (2): New Chemical Concentration Data''
			WHEN ''RR4'' THEN ''Revision (2): Recalculation(s)''
			WHEN ''RR5'' THEN ''Revision (2): Other Reason(s)''
		ELSE ''Revision (2): Undetermined'' END
		END
	
	IF ISNULL(@CHEM_RPT_WD_CD_1, '''') <> ''''
		BEGIN
		SET @Result = CASE @CHEM_RPT_WD_CD_1
			WHEN ''WT1'' THEN ''Withdrawal: Did not meet the reporting threshold for manufacturing, processing, or otherwise use''
			WHEN ''WT2'' THEN ''Withdrawal: Did not meet the reporting threshold for number of employees''
			WHEN ''WT3'' THEN ''Withdrawal: Not in a covered NAICS Code''
			WHEN ''WO1'' THEN ''Withdrawal: Other Reason(s)''
		ELSE ''Withdrawal: Undetermined'' END
		END

	IF ISNULL(@CHEM_RPT_WD_CD_2, '''') <> ''''
		BEGIN
		SET @Result = @Result + '' / ''
		SET @Result = @Result + CASE @CHEM_RPT_WD_CD_2
			WHEN ''WT1'' THEN ''Withdrawal (2): Did not meet the reporting threshold for manufacturing, processing, or otherwise use''
			WHEN ''WT2'' THEN ''Withdrawal (2): Did not meet the reporting threshold for number of employees''
			WHEN ''WT3'' THEN ''Withdrawal (2): Not in a covered NAICS Code''
			WHEN ''WO1'' THEN ''Withdrawal (2): Other Reason(s)''
		ELSE ''Withdrawal (2): Undetermined'' END
		END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_CalculateSubmissionMethod]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CalculateSubmissionMethod]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2010-01-19
-- Description:	Calculate the submission method based upon the TRI filename
-- =============================================
CREATE FUNCTION [dbo].[TRI_CalculateSubmissionMethod] 
(
	-- Add the parameters for the function here
	@TRI_SUB_ID varchar(255)
)
RETURNS varchar(25)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(25)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN @TRI_SUB_ID LIKE ''TRIDPC%'' THEN ''PAPER''
		WHEN @TRI_SUB_ID LIKE ''DISK_%'' THEN ''DISK''
		WHEN @TRI_SUB_ID LIKE ''TRI0001%'' THEN ''CDX''
		WHEN @TRI_SUB_ID LIKE ''TRI0002%'' THEN ''TRIME-WEB''
	ELSE ''UNDETERMINED'' END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GET_AUTHORIZATION_ROLES]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GET_AUTHORIZATION_ROLES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[TRI_GET_AUTHORIZATION_ROLES]
(
  @V_USERNAME VARCHAR(200)
, @V_PASSWORD VARCHAR(200)
, @V_ROLE VARCHAR(200) OUT
) AS 
BEGIN

  IF (@V_USERNAME = ''username1'' OR @V_USERNAME = ''username2'') AND @V_PASSWORD <> ''password''
	  BEGIN
	  RAISERROR(''Password entered is invalid.'', 16, 1)
	  RETURN
	  END

  IF NOT (@V_USERNAME = ''username1'' OR @V_USERNAME = ''username2'')
	  BEGIN
	  RAISERROR(''Username not found.'', 16, 1)
	  RETURN
	  END

  IF @V_USERNAME IS NULL
	  BEGIN
	  RAISERROR(''Username cannot be blank.'', 16, 1)
	  RETURN
	  END

  IF @V_PASSWORD IS NULL
	  BEGIN
	  RAISERROR(''Password cannot be blank.'', 16, 1)
	  RETURN
	  END

  SET @V_ROLE = CASE
  WHEN @V_USERNAME = ''username1'' AND @V_PASSWORD = ''password'' THEN ''ADMIN''
  WHEN @V_USERNAME = ''username2'' AND @V_PASSWORD = ''password'' THEN ''USER''
  ELSE null
  END

END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_RangeCodeConversion]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_RangeCodeConversion]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-05-02
-- Description:	Returns the correct waste quantity measure value based on receiving
--              the actual value and the range code.
--              If the actual value is blank, convert the range code value to a measurement.
-- =============================================
CREATE FUNCTION [dbo].[TRI_RangeCodeConversion] 
(
	-- Add the parameters for the function here
	@WasteQME varchar(100)
	,@WasteQRangeCode varchar(100)
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(100)

	-- Add the T-SQL statements to compute the return value here
IF ISNULL(@WasteQME, '''') = ''''
	BEGIN
	IF ISNULL(@WasteQRangeCode, '''') = ''''
		SELECT @Result = NULL
	ELSE
		SELECT @Result = CASE
			WHEN @WasteQRangeCode = ''A'' THEN ''5''
			WHEN @WasteQRangeCode = ''B'' THEN ''250''
			WHEN @WasteQRangeCode = ''C'' THEN ''750''
		END
	END
ELSE
	SELECT @Result = @WasteQME

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetFacilityManagerData]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetFacilityManagerData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetFacilityManagerData] 
	@sort char(2) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

/*
	Lame workaround for SQL incapability to take field and direction of srot in a case statment
	field by itself works but the direction not so much
*/

DECLARE @SQL VARCHAR(500);
DECLARE @WHERE VARCHAR(500);

	SET @SQL = ''SELECT TRIFID, Deleted, FacilityName, Address, EPA_ID, FS_ID ''
	SET @SQL = @SQL + '' FROM V_MNG_FAC_LIST ''
	SET @SQL = @SQL + '' ORDER BY '';

	SET @WHERE = CASE 
			WHEN @sort = ''TA'' THEN ''TRIFID ''
			WHEN @sort = ''TD'' THEN ''TRIFID DESC ''
			WHEN @sort = ''FA'' THEN ''FacilityName ''
			WHEN @sort = ''FD'' THEN ''FacilityName DESC ''
			WHEN @sort = ''EA'' THEN ''EPA_ID ''
			WHEN @sort = ''ED'' THEN ''EPA_ID DESC ''
			WHEN @sort = ''SA'' THEN ''FS_ID ''
			WHEN @sort = ''SD'' THEN ''FS_ID DESC ''
			ELSE ''TRIFID ''
	  END;


	SET @SQL = @SQL + @WHERE;

	EXEC(@SQL);
	

END


' 
END
GO
/****** Object:  Table [dbo].[APP_TRIDEX_RPT_NAMES]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[APP_TRIDEX_RPT_NAMES]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[APP_TRIDEX_RPT_NAMES](
	[REPORT_NAME] [varchar](255) NOT NULL,
	[REPORT_DESC] [varchar](4000) NOT NULL,
	[REPORT_VIEW] [varchar](255) NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_SUB_ID_Check]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SUB_ID_Check]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2007-12-20
-- Description:	Checks to see if a submission ID is already in the App_TRI_SUB_PreProcessed table
-- =============================================
CREATE FUNCTION [dbo].[TRI_SUB_ID_Check] 
(
	-- Add the parameters for the function here
	@TRI_SUB_ID VARCHAR(255)
)
RETURNS BIT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result BIT

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN EXISTS (SELECT * FROM dbo.App_TRI_SUB_PreProcessed WHERE TRI_SUB_ID = @TRI_SUB_ID)
		THEN 1 ELSE 0 END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  Table [dbo].[App_ReceivedLog]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_ReceivedLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_ReceivedLog](
	[ReceivedLogTxt] [varchar](4000) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[App_Coordinator]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Coordinator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_Coordinator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TRICoordinator_NM] [varchar](255) NULL,
	[TRICoordinator_Title] [varchar](255) NULL,
	[TRICoordinator_Address_Ln1_DS] [varchar](255) NULL,
	[TRICoordinator_Address_Ln2_DS] [varchar](255) NULL,
	[TRICoordinator_Address_City_NM] [varchar](255) NULL,
	[TRICoordinator_Address_State_C] [varchar](2) NULL,
	[TRICoordinator_Address_ZIP_CD] [varchar](10) NULL,
	[TRICoordinator_Phone_NR] [varchar](20) NULL,
	[TRICoordinator_Email] [varchar](255) NULL,
 CONSTRAINT [PK_App_EmailText] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_Convert_Lbs_Grams]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Convert_Lbs_Grams]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- ALTER  date: 2007-07-03
-- Description:	Converts pounds to grams
-- Update 2007-07-12: This routine now just returns
-- the same value as passed in, as it is assumed now
-- that the values are stored in grams already.
-- Leaving this function in place in case this turns
-- out not to be the case.
-- =============================================
CREATE FUNCTION [dbo].[TRI_Convert_Lbs_Grams]
(
	-- Add the parameters for the function here
	@pounds varchar(255)
)
RETURNS varchar(255)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(255)

	-- Add the T-SQL statements to compute the return value here
	IF @pounds IS NULL
		SET @Result = NULL
	ELSE
		SET @Result = @pounds
--		SET @Result = CONVERT(VARCHAR, CONVERT(FLOAT, @pounds) * 453.59237) -- constant from Google search

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_Convert_EPA_ProcessStatusCd_Desc]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Convert_EPA_ProcessStatusCd_Desc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-06
-- Description:	Returns the correct value for TRI_REPORT.REPORT_EPA_PROCESSING_STATUS_C
--              based upon the TRI 2.0 schema documentation:
--
--				-1 = Unknown
--				0 = Inactive Submission
--				1 = Active Submission
--				2 = Submission Needs Manual Review
--				3 = Hold Active 
--				4 = Hold Inactive 
--				5 = Withdrawn Submission
--				6 = Withdrawal Request Pending
--
--              If the actual value is blank, NULL, or not covered by the table, return ''Undetermined''.
-- =============================================
CREATE FUNCTION [dbo].[TRI_Convert_EPA_ProcessStatusCd_Desc] 
(
	-- Add the parameters for the function here
	@REPORT_EPA_PROCESSING_STATUS_C varchar(100)
)
RETURNS varchar(100)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result varchar(100)

	-- Add the T-SQL statements to compute the return value here
IF ISNULL(@REPORT_EPA_PROCESSING_STATUS_C, '''') = ''''
	SELECT @Result = ''Undetermined''
ELSE
	BEGIN
	SELECT @Result = CASE @REPORT_EPA_PROCESSING_STATUS_C
		WHEN ''-1'' THEN ''Unknown''
		WHEN ''0'' THEN ''Inactive Submission''
		WHEN ''1'' THEN ''Active Submission''
		WHEN ''2'' THEN ''Submission Needs Manual Review''
		WHEN ''3'' THEN ''Hold Active''
		WHEN ''4'' THEN ''Hold Inactive''
		WHEN ''5'' THEN ''Withdrawn Submission''
		WHEN ''6'' THEN ''Withdrawal Request Pending''
	ELSE ''Undetermined''
		END
	END

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  Table [dbo].[App_FI_TRIFID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_FI_TRIFID](
	[TRIFID_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRIFID] [varchar](100) NOT NULL,
	[AgencyID] [varchar](100) NULL,
	[EPAID] [varchar](100) NULL,
	[AgencyName] [varchar](100) NULL,
	[Inactive_DT] [datetime] NULL,
	[Last_Updated_User_ID] [varchar](255) NOT NULL,
	[Last_Updated_DT] [datetime] NOT NULL,
 CONSTRAINT [PK_App_TRIFID] PRIMARY KEY CLUSTERED 
(
	[TRIFID_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID]') AND name = N'IX_APP_FI_TRIFID_TID')
CREATE NONCLUSTERED INDEX [IX_APP_FI_TRIFID_TID] ON [dbo].[App_FI_TRIFID] 
(
	[TRIFID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TRI_SetFacilityAltId]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SetFacilityAltId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-05-04
-- Description:	Inserts new association into App_FI_LinkTRIFID_Agency
-- =============================================
CREATE PROCEDURE [dbo].[TRI_SetFacilityAltId] 
	@triPk int,
	@agencyTypePk int,
	@agencyId varchar(100), 
	@userId varchar(25)
AS
BEGIN

	SET NOCOUNT ON;

-- TKC 6/12/2007: Need to check first to make sure a link doesn''t already exist

	IF EXISTS
		(
		SELECT * FROM App_FI_LinkTRIFID_Agency
		WHERE TRIFID_ID_FK = @triPk
		AND Agency_Type_FK = @agencyTypePk
		)

		UPDATE App_FI_LinkTRIFID_Agency
		SET
			Agency_ID = @agencyId
			,Last_Updated_User_ID = @userId
			,Last_Updated_DT = GetDate()
		WHERE
			TRIFID_ID_FK = @triPk
			AND
			Agency_Type_FK = @agencyTypePk

	ELSE

		INSERT INTO App_FI_LinkTRIFID_Agency
				   (TRIFID_ID_FK
				   ,Agency_ID
				   ,Agency_Type_FK
				   ,Last_Updated_User_ID
				   ,Last_Updated_DT)
		VALUES (
					@triPk,
					@agencyId,
					@agencyTypePk,
					@userId,
					GetDate()
		);



END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_DeleteFacilityAltId]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_DeleteFacilityAltId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-05-04
-- Description:	Inserts new association into App_FI_LinkTRIFID_Agency
-- =============================================
CREATE PROCEDURE [dbo].[TRI_DeleteFacilityAltId] 
	@triPk int
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM App_FI_LinkTRIFID_Agency
	WHERE TRIFID_ID_FK = @triPk;

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetManagerIdTypes]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetManagerIdTypes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetManagerIdTypes]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Agency_Type_DS, Agency_Type_ID
	  FROM App_FI_AgencyType
	ORDER BY 1;
END

' 
END
GO
/****** Object:  Table [dbo].[App_Lookup_Cty_Reg]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Lookup_Cty_Reg]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_Lookup_Cty_Reg](
	[ID] [float] NOT NULL,
	[County] [nvarchar](255) NOT NULL,
	[EcologyRegion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_App_Lookup_Cty_Reg] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[App_Link_TRI_SUB_Filename]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_Link_TRI_SUB_Filename]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_Link_TRI_SUB_Filename](
	[FileNameTxt] [varchar](255) NULL,
	[TRI_SUB_ID] [varchar](255) NULL
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[App_FI_TRIFID_Delete]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Delete]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_FI_TRIFID_Delete](
	[TRIFID_DELETE_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRIFID_ID_FK] [int] NOT NULL,
	[TRI_SUB_ID] [varchar](255) NOT NULL,
	[Last_Updated_User_ID] [varchar](255) NOT NULL,
	[Last_Updated_DT] [datetime] NOT NULL,
 CONSTRAINT [PK_App_FI_TRIFID_Delete] PRIMARY KEY CLUSTERED 
(
	[TRIFID_DELETE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[App_FI_TRIFID_Comment]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Comment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_FI_TRIFID_Comment](
	[TRIFID_Comment_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRIFID_ID_FK] [int] NOT NULL,
	[Comment_DS] [varchar](4000) NOT NULL,
	[Last_Updated_User_ID] [varchar](255) NOT NULL,
	[Last_Updated_DT] [datetime] NOT NULL,
 CONSTRAINT [PK_App_TRIFID_Comment] PRIMARY KEY CLUSTERED 
(
	[TRIFID_Comment_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[App_EmailLog]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_EmailLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_EmailLog](
	[Email_Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRI_SUB_ID] [varchar](36) NOT NULL,
	[Sent_DT] [datetime] NOT NULL,
	[Contact_Email_DS] [varchar](50) NOT NULL,
	[Last_Updated_User_ID] [varchar](255) NOT NULL,
	[Last_Updated_DT] [datetime] NOT NULL,
 CONSTRAINT [PK_EmailLog] PRIMARY KEY CLUSTERED 
(
	[Email_Log_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRI_FAC]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_FAC](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[FAC_ID] [varchar](100) NULL,
	[FAC_SITE] [varchar](100) NULL,
	[LOC_ADD_TXT] [varchar](100) NULL,
	[SUPP_LOC_TXT] [varchar](100) NULL,
	[LOCALITY] [varchar](100) NULL,
	[STATE_CL_ID] [varchar](100) NULL,
	[STATE_CODE] [varchar](10) NULL,
	[STATE] [varchar](50) NULL,
	[ADD_POSTAL_CODE] [varchar](50) NULL,
	[COUNTRY_CL_ID] [varchar](100) NULL,
	[COUNTRY_CODE] [varchar](10) NULL,
	[COUNTRY] [varchar](50) NULL,
	[COUNTY_CL_ID] [varchar](100) NULL,
	[COUNTY_CODE] [varchar](100) NULL,
	[COUNTY] [varchar](100) NULL,
	[TRIBAL_CL_ID] [varchar](100) NULL,
	[TRIBAL_CODE] [varchar](100) NULL,
	[TRIBAL] [varchar](100) NULL,
	[TRIBAL_LAND] [varchar](100) NULL,
	[TRIBAL_LAND_IND] [varchar](100) NULL,
	[LOC_DESCN_TXT] [varchar](100) NULL,
	[MAIL_FAC_SITE] [varchar](100) NULL,
	[MAIL_ADD_TXT] [varchar](100) NULL,
	[SUPP_MAIL_ADD] [varchar](100) NULL,
	[MAIL_ADD_CITY] [varchar](100) NULL,
	[MAIL_ADD_POSTAL_CODE] [varchar](100) NULL,
	[PROVINCE_TXT] [varchar](100) NULL,
	[MAIL_ADD_STATE_CDLST] [varchar](100) NULL,
	[MAIL_ADD_STATE_CODE] [varchar](10) NULL,
	[MAIL_ADD_STATE] [varchar](100) NULL,
	[MAIL_ADD_COUNTRY_CDLST] [varchar](100) NULL,
	[MAIL_ADD_COUNTRY_CODE] [varchar](10) NULL,
	[MAIL_ADD_COUNTRY] [varchar](100) NULL,
	[LAT_ME] [varchar](20) NULL,
	[LON_ME] [varchar](20) NULL,
	[SRC_MAP_SCALE_CLBER] [varchar](100) NULL,
	[HOR_ME_VALUE] [varchar](100) NULL,
	[HOR_ME_UNIT_CODE] [varchar](100) NULL,
	[HOR_ME_UNIT] [varchar](100) NULL,
	[HOR_ME_PREC_TXT] [varchar](100) NULL,
	[HOR_RESULT_QFR_CODE] [varchar](100) NULL,
	[HOR_RESULT_QFR] [varchar](100) NULL,
	[HOR_METH_ID_CODE] [varchar](100) NULL,
	[HOR_METH] [varchar](100) NULL,
	[HOR_METH_DESCN_TXT] [varchar](100) NULL,
	[HOR_METH_DEV_TXT] [varchar](100) NULL,
	[GEO_REF_POINT_CD] [varchar](100) NULL,
	[GEO_REF_POINT_NM] [varchar](100) NULL,
	[HOR_REF_DATUM_CD] [varchar](100) NULL,
	[HOR_REF_DATUM_NM] [varchar](100) NULL,
	[DATA_COLLECTION_DATE] [varchar](100) NULL,
	[LOC_COMS_TXT] [varchar](100) NULL,
	[VER_ME_VALUE] [varchar](100) NULL,
	[VER_ME_UNIT_CODE] [varchar](100) NULL,
	[VER_ME_UNIT] [varchar](100) NULL,
	[VER_ME_PREC_TXT] [varchar](100) NULL,
	[VER_RESULT_QFR_CODE] [varchar](100) NULL,
	[VER_RESULT_QFR] [varchar](100) NULL,
	[VER_METH_ID_CODE] [varchar](100) NULL,
	[VER_METH] [varchar](100) NULL,
	[VER_METH_DESCN_TXT] [varchar](100) NULL,
	[VER_METH_DEV_TXT] [varchar](100) NULL,
	[GEO_REF_DATUM_CD] [varchar](100) NULL,
	[GEO_REF_DATUM_NM] [varchar](100) NULL,
	[VERIF_METH_ID] [varchar](100) NULL,
	[VERIF_METH] [varchar](100) NULL,
	[VERIF_METH_DESC] [varchar](100) NULL,
	[VERIF_METH_DEV] [varchar](100) NULL,
	[COORD_DATA_SRC_CODE] [varchar](100) NULL,
	[COORD_DATA_SRC] [varchar](100) NULL,
	[GEOMETRIC_TYPE_CODE] [varchar](100) NULL,
	[GEOMETRIC_TYPE] [varchar](100) NULL,
	[LAT_DEGREE_ME] [varchar](100) NULL,
	[LAT_MINUTE_ME] [varchar](100) NULL,
	[LAT_SECOND_ME] [varchar](100) NULL,
	[LON_DEGREE_ME] [varchar](100) NULL,
	[LON_MINUTE_ME] [varchar](100) NULL,
	[LON_SECOND_ME] [varchar](100) NULL,
	[PARENT_COMPANY_TXT] [varchar](100) NULL,
	[PARENT_DUN_CODE] [varchar](100) NULL,
	[FACILITY_ACCESS_CODE] [varchar](100) NULL,
	[PRI_YR_TECH_CONTACT_NAME] [varchar](100) NULL,
	[PRI_YR_TECH_CONTACT_PHONE] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_FAC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC]') AND name = N'IX_TRI_FAC_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_FAC_FK] ON [dbo].[TRI_FAC] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC]') AND name = N'IX_TRI_FAC_TID')
CREATE NONCLUSTERED INDEX [IX_TRI_FAC_TID] ON [dbo].[TRI_FAC] 
(
	[FAC_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency_DELETE]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-05-04
-- Description:	Inserts new association into App_FI_LinkTRIFID_Agency
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency_DELETE] 
	-- Add the parameters for the stored procedure here
	@TRIFID VARCHAR(100), 
	@AgencyType VARCHAR(100),
	@AgencyID VARCHAR(100), 
	@LastUpdatedUserID VARCHAR(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

INSERT INTO [App_FI_LinkTRIFID_Agency]
           ([TRIFID_ID_FK]
           ,[Agency_ID]
           ,[Agency_Type_FK]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
SELECT
T.TRIFID_ID -- (<TRIFID_ID_FK, int,>
,@AgencyID -- <Agency_ID, varchar(100),>
,AT.Agency_Type_ID -- <Agency_Type_FK, int,>
,@LastUpdatedUserID -- <Last_Updated_User_ID, varchar(25),>
,GETDATE() -- <Last_Updated_DT, datetime,>)

FROM
App_FI_TRIFID T
,App_FI_AgencyType AT

WHERE
T.TRIFID = @TRIFID
AND
AT.Agency_Type_DS = @AgencyType

END

' 
END
GO
/****** Object:  Table [dbo].[App_ManualSubmissionLog]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[App_ManualSubmissionLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[App_ManualSubmissionLog](
	[Manual_Submission_Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[TRIFID_ID_FK] [int] NOT NULL,
	[Reporting_Year_NR] [varchar](100) NOT NULL,
	[State_Received_DT] [datetime] NOT NULL,
	[Submission_Method_DS] [varchar](10) NOT NULL,
	[Last_Updated_User_ID] [varchar](255) NOT NULL,
	[Last_Updated_DT] [datetime] NOT NULL,
 CONSTRAINT [PK_App_ManualSubmissionLog] PRIMARY KEY CLUSTERED 
(
	[Manual_Submission_Log_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[TRI_DeleteFacility]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_DeleteFacility]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_DeleteFacility] 
	@triPk int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM App_FI_TRIFID
      WHERE TRIFID_ID = @triPk;
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Update_FSID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Update_FSID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE  PROCEDURE [dbo].[TRI_Update_FSID]
(
	@PK INT
,	@FSID	INT
)

AS

BEGIN

UPDATE dbo.App_FI_TRIFID
SET
	AgencyID = CONVERT(VARCHAR, @FSID)
,	Last_Updated_DT = GETDATE()

WHERE TRIFID_ID = @PK

END

' 
END
GO
/****** Object:  Table [dbo].[TRI_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_REPORT](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[REPORT_ID] [varchar](100) NULL,
	[REPORT_POST_DATE] [varchar](50) NULL,
	[REPORT_REC_DATE] [varchar](50) NULL,
	[REPORT_ORIG_POST_DATE] [varchar](50) NULL,
	[REPORT_ORIG_REC_DATE] [varchar](50) NULL,
	[REPORT_SUB_METH_CODE] [varchar](100) NULL,
	[REPORT_EPA_PASSED_VALID_IND] [char](1) NULL,
	[REPORT_EPA_PROCESSING_STATUS_C] [varchar](100) NULL,
	[UNALTERED_REPORT_IND] [varchar](100) NULL,
	[REPORT_TYPE_CODE] [varchar](100) NULL,
	[SUB_REP_YEAR] [varchar](100) NULL,
	[REPORT_DUE_DATE] [varchar](50) NULL,
	[REVISION_IND] [varchar](100) NULL,
	[CHEM_TRADE_SECRET_IND] [varchar](100) NULL,
	[SUB_SANITIZED_IND] [varchar](100) NULL,
	[CERTIFIER] [varchar](100) NULL,
	[CERTIFIER_TIT_TXT] [varchar](100) NULL,
	[CERT_SIGNED_DATE] [varchar](100) NULL,
	[SUB_ENTIRE_FAC_IND] [varchar](100) NULL,
	[SUB_PARTIAL_FAC_ID] [varchar](100) NULL,
	[SUB_FEDERAL_FAC_ID] [varchar](100) NULL,
	[SUB_CO_FAC_INDIC] [varchar](100) NULL,
	[TECH_CONT] [varchar](100) NULL,
	[TECH_CONT_PHONE_TXT] [varchar](100) NULL,
	[TECH_CONT_EMAIL_ADDRES] [varchar](100) NULL,
	[PUB_CONT_ID] [varchar](100) NULL,
	[PUB_CONT_TIT_TXT] [varchar](100) NULL,
	[PUB_CONT] [varchar](100) NULL,
	[PUB_CONT_PHONE_TXT] [varchar](50) NULL,
	[CHEM_ANC_USAGE_IND] [varchar](100) NULL,
	[CHEM_ARTICLE_COMP_ID] [varchar](100) NULL,
	[CHEM_BYPRODUCT_IND] [varchar](100) NULL,
	[CHEM_FORMULATION_COMP] [varchar](100) NULL,
	[CHEM_IMPORTED_IND] [varchar](100) NULL,
	[CHEM_MANUFACTURE_AID_ID] [varchar](100) NULL,
	[CHEM_MANUFACTURE_IMPURITY] [varchar](100) NULL,
	[CHEM_PROC_IMPURITY_ID] [varchar](100) NULL,
	[CHEM_PROCING_AID_ID] [varchar](100) NULL,
	[CHEM_PRODUCED_IND] [varchar](100) NULL,
	[CHEM_REACTANT_IND] [varchar](100) NULL,
	[CHEM_REP_IND] [varchar](100) NULL,
	[CHEM_SALES_DIST_ID] [varchar](100) NULL,
	[CHEM_USED_PROCED_ID] [varchar](100) NULL,
	[MAX_CHEM_AMOUNT_CODE] [varchar](100) NULL,
	[WASTE_Q_ME] [varchar](100) NULL,
	[WASTE_Q_ME_NA_IND] [char](1) NULL,
	[WASTE_Q_RANGE_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_NA_IND] [char](1) NULL,
	[ONE_TIME_RELEASE_Q] [varchar](100) NULL,
	[ONE_TIME_NA_IND] [char](1) NULL,
	[PRODUCTION_RATIO_ME] [varchar](100) NULL,
	[PRODUCTION_RATIO_NA_IND] [char](1) NULL,
	[SUB_ADDITIONAL_DATA_ID] [varchar](100) NULL,
	[OPT_INF_TXT] [varchar](4000) NULL,
	[PUB_CONT_EMAIL_ADDRES] [varchar](100) NULL,
	[CHEM_RPT_REV_CD_1] [varchar](100) NULL,
	[CHEM_RPT_REV_CD_2] [varchar](100) NULL,
	[CHEM_RPT_WD_CD_1] [varchar](100) NULL,
	[CHEM_RPT_WD_CD_2] [varchar](100) NULL,
	[TOX_EQ_VAL1_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL2_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL3_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL4_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL5_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL6_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL7_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL8_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL9_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL10_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL11_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL12_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL13_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL14_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL15_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL16_POTW] [varchar](100) NULL,
	[TOX_EQ_VAL17_POTW] [varchar](100) NULL,
	[TOX_EQ_NA_IND_POTW] [char](1) NULL,
	[WASTE_Q_CATASTROPHIC_MEASURE] [varchar](100) NULL,
	[WASTE_Q_RANGE_NUM_BASIS_VALUE] [varchar](100) NULL,
	[Q_DISP_LANDFILL_PERCENT_VALUE] [varchar](100) NULL,
	[Q_DISP_OTHER_PERCENT_VALUE] [varchar](100) NULL,
	[Q_TREATED_PERCENT_VALUE] [varchar](100) NULL,
	[TOX_EQ_VAL1_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL2_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL3_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL4_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL5_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL6_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL7_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL8_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL9_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL10_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL11_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL12_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL13_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL14_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL15_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL16_ONETIME] [varchar](100) NULL,
	[TOX_EQ_VAL17_ONETIME] [varchar](100) NULL,
	[TOX_EQ_NA_IND_ONETIME] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_REPORT] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]') AND name = N'_dta_index_TRI_REPORT_23_53575229__K1')
CREATE NONCLUSTERED INDEX [_dta_index_TRI_REPORT_23_53575229__K1] ON [dbo].[TRI_REPORT] 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]') AND name = N'IX_TRI_REPORT_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_REPORT_FK] ON [dbo].[TRI_REPORT] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]') AND name = N'IX_TRI_REPORT_SUB_YEAR')
CREATE NONCLUSTERED INDEX [IX_TRI_REPORT_SUB_YEAR] ON [dbo].[TRI_REPORT] 
(
	[SUB_REP_YEAR] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_DUP_MERGE]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_DUP_MERGE]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_DUP_MERGE]

AS

SELECT
T.TRIFID_ID AS PK
,CONVERT(INT, T.AgencyID) AS FSID

FROM dbo.App_FI_TRIFID T
WHERE
	ISNULL(T.AgencyId, '''') <> ''''
AND
	ISNUMERIC(T.AgencyId) = 1

'
GO
/****** Object:  StoredProcedure [dbo].[TRI_SetFacilityManagerDetail]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SetFacilityManagerDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_SetFacilityManagerDetail] 
	@triIdOriginal varchar(100) = NULL,
	@triIdNew varchar(100),
	@epaId varchar(100),
	@agencyId varchar(100),
	@comment varchar(4000) = NULL,
	@userId varchar(25)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


BEGIN TRANSACTION    

	-- ********************************************************
	-- 1. Get the TRI Id
	-- ********************************************************

	-- Holds the PK to the main TRI Id row
	DECLARE @trifId int;

	-- Check if this is an Add or an Update based on 
	-- presense of the otriOriginal Id
	IF (@triIdOriginal IS NULL)

		BEGIN

			-- Check that the new Id does not already 
			-- exists in the tri table
			IF EXISTS(SELECT 1 
					  FROM App_FI_TRIFID
					  WHERE TRIFID = @triIdNew)
				RAISERROR (''TRIFID Already Exists.'', 11,1);

			-- Insert new tri id to the master tri table
			INSERT INTO App_FI_TRIFID
			   (TRIFID
			   ,AgencyID
			   ,EPAID
			   ,Inactive_DT
			   ,Last_Updated_User_ID
			   ,Last_Updated_DT)
			 VALUES
				   (@triIdNew
				   ,@agencyId
				   ,@epaId
				   ,NULL
				   ,@userId
				   ,GetDate());

			-- Assign the resulting Id as PK
			SELECT @trifId = SCOPE_IDENTITY();

		END;

	ELSE 
	
		-- Id already exists, must be an update
		-- Assign the PK from the existent record
		SELECT @trifId = TRIFID_ID 
		FROM App_FI_TRIFID 
		WHERE TRIFID = @triIdOriginal;

		-- If the PK is still null after the update throw an exception
		IF (@trifId IS NULL)
		RAISERROR (''Unable to find a record with this TRIFID'', 11,1);

	END;

	-- ********************************************************
	-- 2. Get the TRI Id
	-- ********************************************************

/*
	IF (@comment IS NOT NULL)
	
	BEGIN

		

	END;

	-- Update
	UPDATE App_FI_TRIFID SET TRIFID = @triIdNew WHERE TRIFID_ID = @trifId;

	-- Insert
	INSERT INTO App_FI_LinkTRIFID_Agency
			   (TRIFID_ID_FK
			   ,Agency_ID
			   ,Agency_Type_FK
			   ,Last_Updated_User_ID
			   ,Last_Updated_DT)
		 VALUES
			   (@trifId
			   ,<Agency_ID, varchar(100),>
			   ,<Agency_Type_FK, int,>
			   ,<Last_Updated_User_ID, varchar(25),>
			   ,<Last_Updated_DT, datetime,>)
*/

IF @@ERROR <> 0
  ROLLBACK
ELSE
  COMMIT

' 
END
GO
/****** Object:  View [dbo].[V_MNG_FAC_LIST]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MNG_FAC_LIST]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_TRI_MANAGE_FACILITIES_LIST
 Condensed Name:	V_MNG_FAC_LIST
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Fills the fields on the top portion of the TRI Manage Facilities page*/
CREATE VIEW [dbo].[V_MNG_FAC_LIST]
AS
SELECT DISTINCT
	FI.TRIFID
,	CASE
		WHEN D .TRIFID_DELETE_ID IS NULL
		THEN ''''
		ELSE ''(deleted)''
	END AS Deleted
,	CASE
		WHEN
			(
			FI.AgencyName = ''''
			OR
			FI.AgencyName IS NULL
			)
		THEN COALESCE (F.FAC_SITE, ''*NEW FACILITY* '' + ISNULL(FIC.Comment_DS, ''''))
		ELSE FI.AgencyName
	END AS FacilityName
,	COALESCE (F.LOC_ADD_TXT + '', '', '''')
	+ COALESCE (F.SUPP_LOC_TXT + '', '', '''')
	+ COALESCE (F.LOCALITY + '', '', '''')
	+ F.STATE AS Address
,	COALESCE (F.LOC_ADD_TXT + '', '', '''')
	+ COALESCE (F.SUPP_LOC_TXT + '', '', '''')
	+ COALESCE (F.LOCALITY + '', '', '''')
	+ F.STATE AS EPA_ID
,	F.COUNTY AS FS_ID

FROM dbo.App_FI_TRIFID AS FI
LEFT JOIN dbo.App_FI_TRIFID_Comment FIC ON FIC.TRIFID_ID_FK = FI.TRIFID_ID
LEFT JOIN dbo.App_FI_TRIFID_Delete AS D ON FI.TRIFID_ID = D.TRIFID_ID_FK
LEFT JOIN dbo.TRI_FAC AS F ON UPPER(F.FAC_ID) = UPPER(FI.TRIFID)

'
GO
/****** Object:  View [dbo].[V_MNG_FAC_DTL]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MNG_FAC_DTL]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_MNG_FAC_DTL]

-- =============================================
-- Full Name:		V_TRI_MANAGE_FACILITIES_SUB_DETAIL
-- Condensed Name:	V_MNG_FAC_DTL
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the fields for submissions received from EPA within the detail of the TRI Manage Facilities page
-- Change History:
-- 6/16/2008: Added "SubmittedFacilityName" (FAC_SITE) to the view.
-- =============================================

AS
SELECT

UPPER (F.FAC_ID) TRIFID
,R.SUB_REP_YEAR AS ReportingYear
,F.FAC_SITE AS SubmittedFacilityName
,COALESCE(R.REPORT_REC_DATE, S.INSERTED_DATE) AS EPAReceivedDate
,dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) AS SubmissionMethod
-- ,R.REPORT_SUB_METH_CODE AS SubmissionMethod
--,dbo.TRI_CalculateSubmissionStatus(R.CHEM_RPT_REV_CD_1, R.CHEM_RPT_REV_CD_2, CHEM_RPT_WD_CD_1, CHEM_RPT_WD_CD_2) AS Status
,dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C) AS Status
,S.TRI_SUB_ID AS TRI_SUB_ID

FROM TRI_REPORT R
INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID

'
GO
/****** Object:  View [dbo].[V_MAN_SUB_DTL]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MAN_SUB_DTL]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_MAN_SUB_DTL]

-- =============================================
-- Full Name:		V_TRI_MANAGE_FACILITIES_MANUAL_SUBMISSION_DETAIL
-- Condensed Name:	V_MAN_SUB_DTL
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the fields for manual submissions within the detail of the TRI Manage Facilities page
-- =============================================

AS
SELECT
T.TRIFID AS TRIFID
,manual.Reporting_Year_NR AS ReportingYear
,manual.State_Received_DT AS StateReceivedDate
,manual.Submission_Method_DS AS SubmissionMethod

FROM App_ManualSubmissionLog manual
JOIN App_FI_TRIFID T ON manual.TRIFID_ID_FK = T.TRIFID_ID

'
GO
/****** Object:  View [dbo].[V_FAC_IDENT]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FAC_IDENT]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FAC_IDENT]

-- =============================================
-- Full Name:		V_FacilityIdentification
-- Condensed Name:	V_FAC_IDENT
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Presents the linkage between TRIFIDs, F/S IDs, and EPA IDs in a flattened view structure to be used by other views and processes.
-- =============================================

AS
SELECT

T.TRIFID AS TRIFID
,T.AgencyID AS FS_ID
,T.EPAID AS EPA_ID
/*
,MAX(CASE WHEN AT.Agency_Type_CD = ''FS'' THEN LTA.Agency_ID ELSE '''' END) AS FS_ID
,MAX(CASE WHEN AT.Agency_Type_CD = ''EPA'' THEN LTA.Agency_ID ELSE '''' END) AS EPA_ID
*/
,TC.Comment_DS
,T.Inactive_DT

FROM App_FI_TRIFID T
LEFT JOIN App_FI_TRIFID_Comment TC ON T.TRIFID_ID = TC.TRIFID_ID_FK
/*
LEFT JOIN App_FI_LinkTRIFID_Agency LTA ON T.TRIFID_ID = LTA.TRIFID_ID_FK
LEFT JOIN App_FI_AgencyType AT ON AT.Agency_Type_ID = LTA.Agency_Type_FK
*/
/*
LEFT JOIN App_FI_LinkTRIFID_AltAgency LTALT
	JOIN App_FI_AgencyType ATALT ON ATALT.Agency_Type_ID = LTALT.Agency_Type_FK
ON LTA.Link_TRIFID_Agency_ID = LTALT.Link_TRIFID_Agency_FK
*/
/*
GROUP BY
T.TRIFID
,TC.Comment_DS
,T.Inactive_DT
*/

'
GO
/****** Object:  View [dbo].[V_FAC_FACILITY_DATA]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FAC_FACILITY_DATA]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[V_FAC_FACILITY_DATA]
AS

SELECT
			UPPER(F.FAC_ID) AS TRIFID
		,	UPPER(COALESCE(CASE WHEN (T .AgencyName = '''' OR T .AgencyName IS NULL) THEN F.FAC_SITE ELSE T .AgencyName END, '''')) AS FAC_NAME
		,	REPLACE(UPPER(COALESCE (F.LOC_ADD_TXT, '''')) + '', '' + UPPER(COALESCE (F.SUPP_LOC_TXT, ''''))
			+ '', '' + UPPER(COALESCE (F.LOCALITY, '''')) + '', '' + UPPER(COALESCE (F.STATE, '''')) + '' ''
			+ UPPER(COALESCE (F.ADD_POSTAL_CODE, '''')), '', , '', '', '') AS ADDRESS1
		,	UPPER(COALESCE (F.COUNTY, '''')) AS ADDRESS2
		,	UPPER(COALESCE (F.LOCALITY, '''')) AS CITY
		,	UPPER(COALESCE (F.STATE, '''')) AS USPS
		,	UPPER(COALESCE (F.ADD_POSTAL_CODE, '''')) AS ZIP
		,	CONVERT(VARCHAR, S.INSERTED_DATE, 101) AS INSERTED_DATE

FROM         dbo.TRI_FAC AS F INNER JOIN
                      dbo.TRI_SUB AS S ON S.PK_GUID = F.FK_GUID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID
WHERE     (D.TRIFID_DELETE_ID IS NULL) AND (T.Inactive_DT IS NULL)


'
GO
/****** Object:  Table [dbo].[TRI_SRC_RED_ACT]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_ACT]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_SRC_RED_ACT](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[SRC_RED_SEQ_CL] [varchar](100) NULL,
	[SRC_RED_ACT_CODE] [varchar](100) NULL,
	[SRC_RED_NA_IND] [char](1) NULL,
 CONSTRAINT [PK_TRI_SRC_RED_ACT] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_ACT]') AND name = N'_dta_index_TRI_SRC_RED_ACT_23_1157579162__K2_K1_K3_4')
CREATE NONCLUSTERED INDEX [_dta_index_TRI_SRC_RED_ACT_23_1157579162__K2_K1_K3_4] ON [dbo].[TRI_SRC_RED_ACT] 
(
	[FK_GUID] ASC,
	[PK_GUID] ASC,
	[SRC_RED_SEQ_CL] ASC
)
INCLUDE ( [SRC_RED_ACT_CODE]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_ACT]') AND name = N'IX_TRI_SRC_RED_ACT_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_SRC_RED_ACT_FK] ON [dbo].[TRI_SRC_RED_ACT] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TRI_SetReceipt]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SetReceipt]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-04-30
-- Description:	Inserts a manual submission log entry
-- =============================================
CREATE PROCEDURE [dbo].[TRI_SetReceipt]
(
	 @triId varchar(100)
	,@repYearOrig varchar(100) = NULL
	,@repYear varchar(100)
	,@stateRecDate datetime
	,@subIsPaper bit
	,@userId varchar(25)
)

AS
SET NOCOUNT ON

DECLARE @subMethod varchar(10);

IF (@subIsPaper = 1)
	SET @subMethod = ''Paper'';
ELSE
	SET @subMethod = ''Diskette''

-- Lookup the FK to dbo.App_FI_TRIFID based upon the passed-in @triId

DECLARE @TRIFID_ID INT
SELECT @TRIFID_ID = TRIFID_ID FROM App_FI_TRIFID WHERE TRIFID = @triId

IF EXISTS (SELECT 1 
		   FROM App_ManualSubmissionLog 
		   WHERE TRIFID_ID_FK = @TRIFID_ID AND Reporting_Year_NR = @repYearOrig)
	BEGIN
	IF EXISTS (SELECT 1 
			   FROM App_ManualSubmissionLog 
			   WHERE TRIFID_ID_FK = @TRIFID_ID AND Reporting_Year_NR = @repYear)
	AND @repYearOrig <> @repYear
		BEGIN
		RAISERROR (''A submission for that reporting year already exists. Please enter a new reporting year or go back to the previous screen to edit an existing year.'', -- Message text.
				   16, -- Severity.
				   1 -- State.
				   )
		RETURN
		END
	ELSE

		UPDATE App_ManualSubmissionLog
		   SET 
			  [Reporting_Year_NR] = @repYear
			  ,[State_Received_DT] = @stateRecDate
			  ,[Submission_Method_DS] = @subMethod
			  ,[Last_Updated_User_ID] = @userId
			  ,[Last_Updated_DT] = GetDate()
		 WHERE TRIFID_ID_FK = @TRIFID_ID AND Reporting_Year_NR = @repYearOrig;
	END

ELSE

	INSERT INTO App_ManualSubmissionLog
			   ([TRIFID_ID_FK]
			   ,[Reporting_Year_NR]
			   ,[State_Received_DT]
			   ,[Submission_Method_DS]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
		 VALUES
			   (@TRIFID_ID
			   ,@repYear
			   ,@stateRecDate
			   ,@subMethod
			   ,@userId
			   ,GetDate());

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_SetNewFacility]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SetNewFacility]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-04-30
-- Description:	Inserts a record into the App_FI_TRIFID table
-- =============================================
CREATE PROCEDURE [dbo].[TRI_SetNewFacility]
	 @triId varchar(100)
	,@agencyId varchar(100)
	,@epaId varchar(100)
	,@comment varchar(4000)
	,@userID varchar(25)
	,@agencyName varchar(100)
    ,@inactiveDate datetime = NULL
	,@triPk int OUT

AS
BEGIN

SET NOCOUNT ON


-- check to see whether a record already exists

IF EXISTS (SELECT 1 FROM App_FI_TRIFID WHERE TRIFID = @triId)
BEGIN
    RAISERROR (''TRIFID already exists. Please choose ''''Update'''' instead.'', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

BEGIN TRAN

	INSERT INTO [App_FI_TRIFID]
			   ([TRIFID]
			   ,[AgencyID]
			   ,[EPAID]
			   ,[AgencyName]
			   ,[Inactive_DT]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
		 VALUES
			   (@triId
			   ,@agencyId
			   ,@epaId
			   ,@agencyName
			   ,@inactiveDate
			   ,@userId
			   ,GetDate());

	SET @triPk = SCOPE_IDENTITY();

	INSERT INTO [App_FI_TRIFID_Comment]
			   ([TRIFID_ID_FK]
			   ,[Comment_DS]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
		 VALUES
			   (@triPk
			   ,@comment
			   ,@userID
			   ,GetDate()
			   );

-- TKC 6/12/2007: Need to make sure we insert placeholder records in the linker table for a brand-new facility
-- TKC 7/9/2007:	No longer need to insert into this table

/*
	INSERT INTO App_FI_LinkTRIFID_Agency
			   ([TRIFID_ID_FK]
			   ,[Agency_ID]
			   ,[Agency_Type_FK]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
	SELECT
				@triPk
			   ,''''
			   ,AT.Agency_Type_ID
			   ,@userID
			   ,GetDate()

	FROM App_FI_AgencyType AT
*/

IF @@ERROR <> 0
  ROLLBACK
ELSE
  COMMIT

END;


' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_SetFacility]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SetFacility]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-04-30
-- Description:	Inserts a record into the App_FI_TRIFID table
-- =============================================
CREATE PROCEDURE [dbo].[TRI_SetFacility]
	 @triPk int
	,@triId varchar(100)
	,@agencyId varchar(100)
	,@epaId varchar(100)
	,@agencyName varchar(100)
	,@comment varchar(4000) = NULL
	,@userId varchar(25)
    ,@inactiveDate datetime = NULL

AS
BEGIN

SET NOCOUNT ON


	-- check to see whether record exists
	IF NOT EXISTS (SELECT 1 FROM App_FI_TRIFID WHERE TRIFID_ID = @triPk)
	BEGIN
		RAISERROR (''Unable to find record with that PK'', 16, 1);
		RETURN
	END


	BEGIN TRAN

	-- Update the Id
	UPDATE	App_FI_TRIFID 
	SET		TRIFID = @triId,
			AgencyID = @agencyId,
			EPAID = @epaId,
			AgencyName = @agencyName,
			Last_Updated_User_ID = @userId,
			Last_Updated_DT = GetDate(),
            Inactive_DT = @inactiveDate
	WHERE	TRIFID_ID = @triPk;


	IF (@comment IS NULL)
	
		DELETE FROM App_FI_TRIFID_Comment
		WHERE TRIFID_ID_FK = @triPk;

	ELSE

		IF EXISTS (SELECT 1 FROM App_FI_TRIFID_Comment WHERE TRIFID_ID_FK = @triPk)

			UPDATE	App_FI_TRIFID_Comment
			SET		Comment_DS = @comment,
					Last_Updated_User_ID = @userId,
					Last_Updated_DT = GetDate()
			WHERE   TRIFID_ID_FK = @triPk;

		ELSE

			INSERT INTO App_FI_TRIFID_Comment
					   (TRIFID_ID_FK
					   ,Comment_DS
					   ,Last_Updated_User_ID
					   ,Last_Updated_DT)
				 VALUES
					   (@triPk
					   ,@comment
					   ,@userId
					   ,GetDate());


	IF @@ERROR <> 0
	  ROLLBACK;
	ELSE
	  COMMIT;

END;


' 
END
GO
/****** Object:  Table [dbo].[TRI_REPORT_VALIDATION]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT_VALIDATION]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_REPORT_VALIDATION](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[VALIDATION_ENTITY_NAME_TEXT] [varchar](100) NULL,
	[VALIDATION_MESSAGE_CODE] [varchar](100) NULL,
	[VALIDATION_MESSAGE_TEXT] [varchar](100) NULL,
	[EPA_ERROR_SEVERITY_CODE] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_REPORT_VALIDATION] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPORT_VALIDATION]') AND name = N'IX_TRI_REPORT_VALIDATION_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_REPORT_VALIDATION_FK] ON [dbo].[TRI_REPORT_VALIDATION] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_BRS_RSLT_SUM]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BRS_RSLT_SUM]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[V_BRS_RSLT_SUM]
AS
SELECT     F.PK_GUID AS FACILITY_PK_GUID, UPPER(F.FAC_ID) AS TRIFID, CASE WHEN (T .AgencyName = '''' OR
                      T .AgencyName IS NULL) THEN F.FAC_SITE ELSE T .AgencyName END AS FacilityName, F.LOC_ADD_TXT AS Addr1, F.SUPP_LOC_TXT AS Addr2, F.LOCALITY AS City, 
                      F.STATE AS State_USPS, F.ADD_POSTAL_CODE AS ZIPCode, F.COUNTY, 
                      S.INSERTED_DATE
FROM         dbo.TRI_FAC AS F INNER JOIN
                      dbo.TRI_SUB AS S ON S.PK_GUID = F.FK_GUID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID
WHERE     (D.TRIFID_DELETE_ID IS NULL) AND (T.Inactive_DT IS NULL)
AND
	S.INSERTED_DATE =
		(
		SELECT MAX(S2.INSERTED_DATE)
		FROM dbo.TRI_SUB S2
		JOIN dbo.TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE F2.FAC_ID = F.FAC_ID
		)
'
GO
/****** Object:  Table [dbo].[TRI_WASTE_TREAT_DTL]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_DTL]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_WASTE_TREAT_DTL](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[WASTE_STREAM_SEQ_CLBER] [varchar](100) NULL,
	[WASTE_STREAM_TYPE_CODE] [varchar](100) NULL,
	[INFLUENT_CONC_RANGE_C] [varchar](100) NULL,
	[TREAT_EFF_EST_PCT] [varchar](100) NULL,
	[TREAT_EFF_RANGE_CD] [varchar](100) NULL,
	[TREAT_EFF_NA_IND] [char](1) NULL,
	[OPERATING_DATA_IND] [varchar](100) NULL,
	[WASTE_TREAT_NA_IND] [char](1) NULL,
 CONSTRAINT [PK_TRI_WASTE_TREAT_DTL] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_DTL]') AND name = N'IX_TRI_WASTE_TREAT_DTL_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_WASTE_TREAT_DTL_FK] ON [dbo].[TRI_WASTE_TREAT_DTL] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_EPA_SUB]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EPA_SUB]'))
EXEC dbo.sp_executesql @statement = N'CREATE   VIEW [dbo].[V_EPA_SUB]
AS
SELECT DISTINCT 
                      S.TRI_SUB_ID AS SUB_ID, F.FAC_SITE AS FAC_NAME, F.FAC_ID AS TRIFID, R.TECH_CONT, 
                      R.TECH_CONT_EMAIL_ADDRES AS TECH_CONT_EMAIL_ADDRESS
FROM         dbo.TRI_SUB AS S INNER JOIN
                      dbo.TRI_FAC AS F ON S.PK_GUID = F.FK_GUID INNER JOIN
                      dbo.TRI_REPORT AS R ON S.PK_GUID = R.FK_GUID

WHERE NOT EXISTS
(
SELECT * FROM dbo.App_EmailLog E
WHERE E.TRI_SUB_ID = S.PK_GUID
)
AND CHARINDEX(''@'', ISNULL(R.TECH_CONT_EMAIL_ADDRES, '''')) > 0

'
GO
/****** Object:  View [dbo].[V_EPA_MAN_SUB]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EPA_MAN_SUB]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- View Name:		V_EPA_MAN_SUB
-- Author:			TK Conrad (Windsor Solutions, Inc.)
-- Create date:		2007-07-31
-- Description:		Links manually-received submissions with any received from the EPA for each reporting year
-- =============================================
CREATE VIEW [dbo].[V_EPA_MAN_SUB]

AS

SELECT
	T.TRIFID AS TRIFID
,	T.AgencyID AS FS_ID 
,	T.EPAID AS EPA_ID
,	M.Reporting_Year_NR
,	CONVERT(VARCHAR, M.State_Received_DT, 101) AS State_Received_DT
,	M.Submission_Method_DS AS Submission_Method_DS
,	COALESCE(CONVERT(VARCHAR, S.INSERTED_DATE, 101), ''Not Received'') AS EPASubRecdDate
,	dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C) AS EPAStatusCode
,	CASE WHEN S.INSERTED_DATE IS NULL THEN NULL ELSE COUNT(*) END AS NumberOfChemicals

FROM
dbo.App_FI_TRIFID T
JOIN dbo.App_ManualSubmissionLog M ON T.TRIFID_ID = M.TRIFID_ID_FK
LEFT JOIN dbo.TRI_FAC F 
	JOIN dbo.TRI_SUB S ON S.PK_GUID = F.FK_GUID
	JOIN dbo.TRI_REPORT R ON S.PK_GUID = R.FK_GUID
ON
		T.TRIFID = F.FAC_ID
AND		M.Reporting_Year_NR = R.SUB_REP_YEAR

GROUP BY
	T.TRIFID
,	T.AgencyID
,	T.EPAID
,	M.Reporting_Year_NR
,	CONVERT(VARCHAR, M.State_Received_DT, 101)
,	M.Submission_Method_DS
,	COALESCE(CONVERT(VARCHAR, S.INSERTED_DATE, 101), ''Not Received'')
,	dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C)
,	S.INSERTED_DATE

'
GO
/****** Object:  Table [dbo].[TRI_REPLACED_REPORT_ID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPLACED_REPORT_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_REPLACED_REPORT_ID](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[REPLACED_REPORT_ID] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_REPLACED_REPORT_ID] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_REPLACED_REPORT_ID]') AND name = N'IX_TRI_REPLACED_REPORT_ID_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_REPLACED_REPORT_ID_FK] ON [dbo].[TRI_REPLACED_REPORT_ID] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_RCRA_ID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_RCRA_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_RCRA_ID](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[RCRA_ID_CLBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_RCRA_ID] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_RCRA_ID]') AND name = N'IX_TRI_RCRA_ID_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_RCRA_ID_FK] ON [dbo].[TRI_RCRA_ID] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_TRANSFER_LOC]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_LOC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_TRANSFER_LOC](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[TRANSFER_LOC_SEQ_CL] [varchar](100) NULL,
	[POTW_IND] [varchar](100) NULL,
	[FAC_SITE] [varchar](100) NULL,
	[LOC_ADD_TXT] [varchar](100) NULL,
	[SUPP_LOC_TXT] [varchar](100) NULL,
	[LOCALITY] [varchar](100) NULL,
	[STATE] [varchar](100) NULL,
	[ADD_POSTAL_CODE] [varchar](100) NULL,
	[COUNTY] [varchar](100) NULL,
	[CONTROLLED_LOC_IND] [varchar](100) NULL,
	[RCRA_ID_CLBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_TRANSFER_LOC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_LOC]') AND name = N'IX_TRI_TRANSFER_LOC_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_TRANSFER_LOC_FK] ON [dbo].[TRI_TRANSFER_LOC] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_UIC_ID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_UIC_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_UIC_ID](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[UIC_ID_CLBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_UIC_ID] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_UIC_ID]') AND name = N'IX_TRI_UIC_ID_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_UIC_ID_FK] ON [dbo].[TRI_UIC_ID] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_UIC_DISP_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_UIC_DISP_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_UIC_DISP_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_UIC_DISP_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_UIC_DISP_QTY]') AND name = N'IX_TRI_ONSITE_UIC_DISP_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_UIC_DISP_QTY_FK] ON [dbo].[TRI_ONSITE_UIC_DISP_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_TREATED_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_TREATED_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_TREATED_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_TREATED_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_TREATED_Q]') AND name = N'IX_TRI_ONSITE_TREATED_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_TREATED_Q_FK] ON [dbo].[TRI_ONSITE_TREATED_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_RELEASE_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RELEASE_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_RELEASE_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[EI_MEDIUM_CODE] [varchar](100) NULL,
	[WASTE_Q_ME] [varchar](100) NULL,
	[WASTE_Q_NA_IND] [char](1) NULL,
	[WASTE_Q_RANGE_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_CD] [varchar](100) NULL,
	[Q_BASIS_NA_IND] [char](1) NULL,
	[WATER_SEQ_CLBER] [varchar](100) NULL,
	[STREAM] [varchar](100) NULL,
	[RELEASE_STORM_WATER] [varchar](100) NULL,
	[RELEASE_STORM_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[WASTE_Q_CATASTROPHIC_MEASURE] [varchar](100) NULL,
	[WASTE_Q_RANGE_NUM_BASIS_VALUE] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_RELEASE_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RELEASE_Q]') AND name = N'IX_TRI_ONSITE_RELEASE_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_RELEASE_Q_FK] ON [dbo].[TRI_ONSITE_RELEASE_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_RECYCLED_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCLED_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_RECYCLED_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_RECYCLED_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCLED_Q]') AND name = N'IX_TRI_ONSITE_RECYCLED_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_RECYCLED_Q_FK] ON [dbo].[TRI_ONSITE_RECYCLED_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_RECYCG_PROC]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCG_PROC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_RECYCG_PROC](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[ONSITE_RECYCG_METH_CODE] [varchar](100) NULL,
	[ONSITE_RECYCG_NA_IND] [char](1) NULL,
 CONSTRAINT [PK_TRI_ONSITE_RECYCG_PROC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCG_PROC]') AND name = N'IX_TRI_ONSITE_RECYCG_PROC_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_RECYCG_PROC_FK] ON [dbo].[TRI_ONSITE_RECYCG_PROC] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_RCV_PROC]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RCV_PROC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_RCV_PROC](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[ENERGY_RCV_METH_CODE] [varchar](100) NULL,
	[ENERGY_RCV_NA_IND] [char](1) NULL,
 CONSTRAINT [PK_TRI_ONSITE_RCV_PROC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RCV_PROC]') AND name = N'IX_TRI_ONSITE_RCV_PROC_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_RCV_PROC_FK] ON [dbo].[TRI_ONSITE_RCV_PROC] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_ENERGY_RCV_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_ENERGY_RCV_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_ENERGY_RCV_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_ENERGY_RCV_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_ENERGY_RCV_QTY]') AND name = N'IX_TRI_ONSITE_ENERGY_RCV_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_ENERGY_RCV_QTY_FK] ON [dbo].[TRI_ONSITE_ENERGY_RCV_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_ONSITE_DISP_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_DISP_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_ONSITE_DISP_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_ONSITE_DISP_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_DISP_QTY]') AND name = N'IX_TRI_ONSITE_DISP_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_ONSITE_DISP_QTY_FK] ON [dbo].[TRI_ONSITE_DISP_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_OFFSITE_UIC_DISP_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_UIC_DISP_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_OFFSITE_UIC_DISP_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_OFFSITE_UIC_DISP_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_UIC_DISP_QTY]') AND name = N'IX_TRI_OFFSITE_UIC_DISP_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_OFFSITE_UIC_DISP_QTY_FK] ON [dbo].[TRI_OFFSITE_UIC_DISP_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_OFFSITE_TREATED_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_TREATED_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_OFFSITE_TREATED_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_OFFSITE_TREATED_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_TREATED_Q]') AND name = N'IX_TRI_OFFSITE_TREATED_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_OFFSITE_TREATED_Q_FK] ON [dbo].[TRI_OFFSITE_TREATED_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_OFFSITE_RECYCLED_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_RECYCLED_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_OFFSITE_RECYCLED_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_OFFSITE_RECYCLED_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_RECYCLED_Q]') AND name = N'IX_TRI_OFFSITE_RECYCLED_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_OFFSITE_RECYCLED_Q_FK] ON [dbo].[TRI_OFFSITE_RECYCLED_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_OFFSITE_ENERGY_REC_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_ENERGY_REC_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_OFFSITE_ENERGY_REC_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_OFFSITE_ENERGY_REC_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_ENERGY_REC_QTY]') AND name = N'IX_TRI_OFFSITE_ENERGY_REC_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_OFFSITE_ENERGY_REC_QTY_FK] ON [dbo].[TRI_OFFSITE_ENERGY_REC_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_OFFSITE_DISP_QTY]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_DISP_QTY]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_OFFSITE_DISP_QTY](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[YEAR_OFFSET_ME] [varchar](100) NULL,
	[TOTAL_Q] [varchar](100) NULL,
	[TOTAL_Q_NA_IND] [char](1) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[CALC_ROUNDING_HINT_NUMBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_OFFSITE_DISP_QTY] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_DISP_QTY]') AND name = N'IX_TRI_OFFSITE_DISP_QTY_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_OFFSITE_DISP_QTY_FK] ON [dbo].[TRI_OFFSITE_DISP_QTY] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_NPDES_ID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_NPDES_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_NPDES_ID](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[NPDES_ID_CLBER] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_NPDES_ID] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_NPDES_ID]') AND name = N'IX_TRI_NPDES_ID_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_NPDES_ID_FK] ON [dbo].[TRI_NPDES_ID] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_EmailLog]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_EmailLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- ALTER  date: 2007-04-30
-- Description:	Inserts a new record in the email log table indicating that an email has
--              been sent to the technical contact indicating that the EPA submission was
--              received by Washington Ecology. Gets fired off immediately after emails
--              have been sent out.
-- =============================================
CREATE  PROCEDURE [dbo].[TRI_Insert_EmailLog]
	 @SUB_ID varchar(255)
	,@UserID varchar(255)

AS
BEGIN

SET NOCOUNT ON;

DECLARE @Err	INT
SET @Err = 0

IF @UserID IS NULL SET @UserID = ''TRI_Loader''

BEGIN TRAN

INSERT INTO [App_EmailLog]
           ([TRI_SUB_ID]
           ,[Sent_DT]
           ,[Contact_Email_DS]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
SELECT DISTINCT
	s.PK_GUID -- <PK_GUID, varchar(36)>
	,GETDATE() -- GetDate()
	,LOWER(r.TECH_CONT_EMAIL_ADDRES) -- R.
	,@UserID -- ''TRI Update 20080206''
	,GETDATE() -- GetDate()

FROM TRI_SUB s
JOIN TRI_REPORT r ON r.FK_GUID = s.PK_GUID

WHERE
s.TRI_SUB_ID = @SUB_ID

AND NOT EXISTS
	(
	SELECT * FROM [App_EmailLog] e2
	WHERE e2.TRI_SUB_ID = @SUB_ID
	)
AND CHARINDEX(''@'', ISNULL(r.TECH_CONT_EMAIL_ADDRES, '''')) > 0


SET @Err = @@ERROR
IF @Err <> 0
	BEGIN
	ROLLBACK TRAN
	RAISERROR(''An error occurred during insert'', 16, 1)
	RETURN @Err
	END
ELSE
	COMMIT TRAN

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_App_FI_TRIFID_DELETE]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_App_FI_TRIFID_DELETE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-04-30
-- Description:	Inserts a record into the App_FI_TRIFID table
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Insert_App_FI_TRIFID_DELETE]
	@TRIFID varchar(100)
	,@Comment varchar(4000)
	,@UserID varchar(25)

AS
BEGIN

SET NOCOUNT ON

DECLARE @TRIFID_ID INT

-- check to see whether a record already exists

IF EXISTS
(
SELECT * FROM App_FI_TRIFID
WHERE TRIFID = @TRIFID
)
BEGIN
    RAISERROR (''TRIFID already exists. Please choose ''''Update'''' instead.'', -- Message text.
               16, -- Severity.
               1 -- State.
               );
	RETURN
END

INSERT INTO [App_FI_TRIFID]
           ([TRIFID]
           ,[Inactive_DT]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
     VALUES
           (@TRIFID
           ,NULL
           ,@UserId
           ,GETDATE())

SET @TRIFID_ID = SCOPE_IDENTITY()

INSERT INTO [App_FI_TRIFID_Comment]
           ([TRIFID_ID_FK]
           ,[Comment_DS]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
     VALUES
           (@TRIFID_ID -- 
           ,@Comment -- 
           ,@UserID -- @UserId
           ,GETDATE() -- GETDATE())
           )

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_App_FI_TRIFID_bulk]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_App_FI_TRIFID_bulk]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- ALTER  date: 2007-04-30
-- Description:	Loads the App_FI_TRIFID table as a bulk operation
-- =============================================
CREATE  PROCEDURE [dbo].[TRI_Insert_App_FI_TRIFID_bulk]
	 @SUB_ID varchar(36)
	,@UserID varchar(255)

AS
BEGIN

SET NOCOUNT ON

DECLARE @Err	INT
SET @Err = 0

BEGIN TRAN

INSERT INTO [dbo].[App_FI_TRIFID]
           ([TRIFID]
           ,[AgencyID]
           ,[EPAID]
           ,[Inactive_DT]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
SELECT
            F.FAC_ID
           ,NULL
           ,NULL
           ,NULL
           ,@UserID
           ,GetDate()

FROM TRI_FAC F
JOIN TRI_SUB S ON S.PK_GUID = F.FK_GUID

WHERE NOT EXISTS
	(
	SELECT * FROM dbo.App_FI_TRIFID FI2
	WHERE FI2.TRIFID = F.FAC_ID
	)
GROUP BY F.FAC_ID

SET @Err = @@ERROR
IF @Err <> 0
	BEGIN
		ROLLBACK TRAN
		RAISERROR(''An error occurred while attempting to insert a new TRIFID into App_FI_TRIFID table.'', 16, 1)
		RETURN @Err
	END

COMMIT TRAN


END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_App_FI_TRIFID]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_App_FI_TRIFID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- CREATE date: 2008-05-02
-- Description:	Loads the App_FI_TRIFID table as a bulk operation
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Insert_App_FI_TRIFID]

AS
BEGIN

SET NOCOUNT ON

DECLARE @Err	INT
SET @Err = 0

DECLARE @UserID	varchar(25)
SET @UserID = ''System''

BEGIN TRAN

INSERT INTO [dbo].[App_FI_TRIFID]
           ([TRIFID]
           ,[AgencyID]
           ,[EPAID]
           ,[Inactive_DT]
           ,[Last_Updated_User_ID]
           ,[Last_Updated_DT])
SELECT
            F.FAC_ID
           ,NULL
           ,NULL
           ,NULL
           ,@UserID
           ,GetDate()

FROM TRI_FAC F
JOIN TRI_SUB S ON S.PK_GUID = F.FK_GUID

WHERE NOT EXISTS
	(
	SELECT * FROM dbo.App_FI_TRIFID FI2
	WHERE FI2.TRIFID = F.FAC_ID
	)
GROUP BY F.FAC_ID

SET @Err = @@ERROR
IF @Err <> 0
	BEGIN
		ROLLBACK TRAN
		RAISERROR(''An error occurred while attempting to insert a new TRIFID into App_FI_TRIFID table.'', 16, 1)
		RETURN @Err
	END

COMMIT TRAN

END
' 
END
GO
/****** Object:  Table [dbo].[TRI_FAC_SIC]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_SIC]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_FAC_SIC](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[FAC_SIC] [varchar](100) NULL,
	[SIC_PRIMARY_IND] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_FAC_SIC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_SIC]') AND name = N'IX_TRI_FAC_SIC_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_FAC_SIC_FK] ON [dbo].[TRI_FAC_SIC] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_FAC_NAICS]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_NAICS]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_FAC_NAICS](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[FAC_NAICS] [varchar](100) NULL,
	[NAICS_PRIMARY_IND] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_NAICS_SIC] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_NAICS]') AND name = N'IX_TRI_FAC_NAICS_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_FAC_NAICS_FK] ON [dbo].[TRI_FAC_NAICS] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_FAC_DUN]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_DUN]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_FAC_DUN](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[FAC_DUN_CODE] [varchar](9) NULL,
 CONSTRAINT [PK_TRI_FAC_DUN] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_FAC_DUN]') AND name = N'IX_TRI_FAC_DUN_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_FAC_DUN_FK] ON [dbo].[TRI_FAC_DUN] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_CalculateRevisionIndicator]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CalculateRevisionIndicator]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- ==========================================================================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2010-01-19
-- Description:	Calculates whether a submission is a revision based upon either the revision
--				and withdrawal codes (if report year is after YEAR) or the revision indicator
--				(if before YEAR).
-- ==========================================================================================
CREATE FUNCTION [dbo].[TRI_CalculateRevisionIndicator] 
(
	-- Add the parameters for the function here
	@PK_GUID_REP varchar(36)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result bit

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result = CASE
		WHEN COALESCE(CHEM_RPT_REV_CD_1, CHEM_RPT_REV_CD_2, CHEM_RPT_WD_CD_1, CHEM_RPT_WD_CD_2) IS NOT NULL THEN 1
		ELSE CASE
			WHEN REVISION_IND = ''Y'' THEN 1
		ELSE 0
		END
	END
	
	FROM TRI_REPORT
	WHERE PK_GUID = @PK_GUID_REP

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Del_TRIFID_Delete]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Del_TRIFID_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2007-08-27
-- Description:	Deletes record from App_FI_TRIFID_Delete table
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Del_TRIFID_Delete] 
	@RecordId		int
AS
BEGIN

	SET NOCOUNT ON;

	DELETE FROM App_FI_TRIFID_Delete 
	WHERE TRIFID_DELETE_ID = @RecordId;

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-08
-- Description:	insert new records into App_FI_LinkTRIFID_Agency for any new TRIFIDs
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Insert_App_FI_LinkTRIFID_Agency] 
	-- Add the parameters for the stored procedure here
	@SUB_ID varchar(36), 
	@UserId varchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Set constants and defaults

	DECLARE @FSID	INT
	DECLARE @EPAID	INT

	SELECT @FSID = Agency_Type_ID FROM dbo.App_FI_AgencyType WHERE Agency_Type_CD = ''FS''
	SELECT @EPAID = Agency_Type_ID FROM dbo.App_FI_AgencyType WHERE Agency_Type_CD = ''EPA''

	-- Add F/S ID links

	INSERT INTO [App_FI_LinkTRIFID_Agency]
			   ([TRIFID_ID_FK]
			   ,[Agency_ID]
			   ,[Agency_Type_FK]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
	SELECT DISTINCT
	T.TRIFID_ID
	,''''
	,@FSID
	,@UserId
	,GETDATE()

	FROM dbo.App_FI_TRIFID T
	JOIN dbo.TRI_FAC F ON T.TRIFID = F.FAC_ID
	JOIN dbo.TRI_SUB S ON S.PK_GUID = F.FK_GUID
	
	WHERE S.PK_GUID = @SUB_ID
	AND NOT EXISTS
	(
	SELECT * FROM [App_FI_LinkTRIFID_Agency] LA
	WHERE LA.[TRIFID_ID_FK] = T.TRIFID_ID
	AND [Agency_Type_FK] = @FSID
	)

	INSERT INTO [App_FI_LinkTRIFID_Agency]
			   ([TRIFID_ID_FK]
			   ,[Agency_ID]
			   ,[Agency_Type_FK]
			   ,[Last_Updated_User_ID]
			   ,[Last_Updated_DT])
	SELECT DISTINCT
	T.TRIFID_ID
	,''''
	,@EPAID
	,@UserId
	,GETDATE()

	FROM dbo.App_FI_TRIFID T
	JOIN dbo.TRI_FAC F ON T.TRIFID = F.FAC_ID
	JOIN dbo.TRI_SUB S ON S.PK_GUID = F.FK_GUID
	
	WHERE S.PK_GUID = @SUB_ID
	AND NOT EXISTS
	(
	SELECT * FROM [App_FI_LinkTRIFID_Agency] LA
	WHERE LA.[TRIFID_ID_FK] = T.TRIFID_ID
	AND [Agency_Type_FK] = @EPAID
	)

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_Ins_TRIFID_Delete]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_Ins_TRIFID_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2007-08-27
-- Description:	Adds new record to App_FI_TRIFID_Delete
-- =============================================
CREATE PROCEDURE [dbo].[TRI_Ins_TRIFID_Delete]
	@TRIFID			VARCHAR(100) 
,	@REPORT_YEAR	VARCHAR(100)
,	@REC_DATE		DateTime
,	@UserId			VARCHAR(255)

AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO App_FI_TRIFID_Delete
			   (TRIFID_ID_FK
			   ,TRI_SUB_ID
			   ,Last_Updated_User_ID
			   ,Last_Updated_DT)

	SELECT DISTINCT		T.TRIFID_ID
					,	S.TRI_SUB_ID
					,	@UserId
					,	GetDate()
	FROM		App_FI_TRIFID AS T 
	INNER JOIN  TRI_FAC F ON T.TRIFID = F.FAC_ID
	INNER JOIN  TRI_SUB S ON S.PK_GUID = F.FK_GUID  
	INNER JOIN  TRI_REPORT AS R ON S.PK_GUID = R.FK_GUID
	WHERE		F.FAC_ID = @TRIFID 
	AND			R.SUB_REP_YEAR = @REPORT_YEAR
	AND			DATEDIFF(minute, COALESCE(R.REPORT_REC_DATE, S.INSERTED_DATE), @REC_DATE) = 0;
	
	IF SCOPE_IDENTITY() = 0
		BEGIN
			RAISERROR(''No record found'', 16, 1);
			RETURN;
		END

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetTRIFID_Delete]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetTRIFID_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2007-08-27
-- Description:	Deletes record from App_FI_TRIFID_Delete table
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetTRIFID_Delete] 
	@TRIFID			VARCHAR(100) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT		F.FAC_ID AS TRIFID, 
				F.FAC_SITE AS FACNAME, 
				S.INSERTED_DATE AS ReceivedOn, 
				D.Last_Updated_DT AS DeletedOn, 
				D.TRIFID_DELETE_ID AS RecordId
	FROM        TRI_FAC F
	INNER JOIN  TRI_SUB S ON F.FK_GUID = S.PK_GUID 
	INNER JOIN  App_FI_TRIFID_Delete D ON S.TRI_SUB_ID = D.TRI_SUB_ID
	WHERE		F.FAC_ID = @TRIFID
	ORDER BY	D.Last_Updated_DT DESC

END

' 
END
GO
/****** Object:  Table [dbo].[TRI_CHEM]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CHEM]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_CHEM](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[CAS_CLBER] [varchar](100) NULL,
	[CHEM_TXT] [varchar](100) NULL,
	[CHEM_MIXTURE_TXT] [varchar](100) NULL,
	[CHEM_ID] [varchar](100) NULL,
	[CHEM_REGISTRY] [varchar](100) NULL,
	[CHEM_REGISTRY_CTX] [varchar](100) NULL,
	[DIOXIN_DIST1] [varchar](100) NULL,
	[DIOXIN_DIST2] [varchar](100) NULL,
	[DIOXIN_DIST3] [varchar](100) NULL,
	[DIOXIN_DIST4] [varchar](100) NULL,
	[DIOXIN_DIST5] [varchar](100) NULL,
	[DIOXIN_DIST6] [varchar](100) NULL,
	[DIOXIN_DIST7] [varchar](100) NULL,
	[DIOXIN_DIST8] [varchar](100) NULL,
	[DIOXIN_DIST9] [varchar](100) NULL,
	[DIOXIN_DIST10] [varchar](100) NULL,
	[DIOXIN_DIST11] [varchar](100) NULL,
	[DIOXIN_DIST12] [varchar](100) NULL,
	[DIOXIN_DIST13] [varchar](100) NULL,
	[DIOXIN_DIST14] [varchar](100) NULL,
	[DIOXIN_DIST15] [varchar](100) NULL,
	[DIOXIN_DIST16] [varchar](100) NULL,
	[DIOXIN_DIST17] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_CHEM] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CHEM]') AND name = N'IX_TRI_CHEM_CHEM_TXT')
CREATE NONCLUSTERED INDEX [IX_TRI_CHEM_CHEM_TXT] ON [dbo].[TRI_CHEM] 
(
	[CHEM_TXT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CHEM]') AND name = N'IX_TRI_CHEM_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_CHEM_FK] ON [dbo].[TRI_CHEM] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[TRI_DisplayChemicals]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_DisplayChemicals]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- ==========================================================================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2010-06-15
-- Description:	Displays all chemicals matching entered criteria:
--				TRIFID, CAS, Report type, Report year, and  MAX(CERT_SIGNED_DATE)
-- ==========================================================================================
CREATE PROCEDURE [dbo].[TRI_DisplayChemicals] 
	-- Add the parameters for the stored procedure here
	@TRIFID varchar(100) = NULL
,	@CASNO	varchar(100) = NULL
,	@ReportType	varchar(100) = NULL
,	@ReportYear	varchar(100) = NULL
,	@CertSignedDate datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		F.FAC_ID TRIFID
	,	F.FAC_SITE FACILITY_NAME
	,	R.SUB_REP_YEAR REPORTING_YEAR
	,	RIGHT(R.REPORT_TYPE_CODE, 1) REPORT_TYPE
	,	R.CERT_SIGNED_DATE
	,	C.CAS_CLBER CASNO
	,	C.CHEM_TXT CHEMICAL_NAME
	,	S.INSERTED_DATE DATE_RECEIVED_BY_OHEPA
	
	FROM TRI_SUB S
	JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
	JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
	JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
	
	WHERE
	F.FAC_ID = ISNULL(@TRIFID, F.FAC_ID)
	AND
	C.CAS_CLBER = ISNULL(@CASNO, C.CAS_CLBER)
	AND
	RIGHT(R.REPORT_TYPE_CODE, 1) = ISNULL(@ReportType, RIGHT(R.REPORT_TYPE_CODE, 1))
	AND
	R.SUB_REP_YEAR = ISNULL(@ReportYear, R.SUB_REP_YEAR)
	AND
	DATEDIFF(DD, R.CERT_SIGNED_DATE, ISNULL(@CertSignedDate, R.CERT_SIGNED_DATE)) = 0
	
	ORDER BY
	
		F.FAC_SITE
	,	R.SUB_REP_YEAR DESC
	,	R.REPORT_TYPE_CODE
	,	R.CERT_SIGNED_DATE DESC
	,	C.CHEM_TXT


END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_ProcessPost_TRI_Loader]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_ProcessPost_TRI_Loader]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		TK Conrad
-- Create date: 2007-06-06
-- Description:	Calls all update procedures to be run immediately after loading TRI data.
-- =============================================
CREATE PROCEDURE [dbo].[TRI_ProcessPost_TRI_Loader]
	-- Add the parameters for the stored procedure here
@SUBID	varchar(255) = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Local variables

	DECLARE @RC	INT

	EXEC @RC = dbo.TRI_Insert_App_FI_TRIFID

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetManualSubmissionData]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetManualSubmissionData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Summary Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetManualSubmissionData] (
	@tid varchar(100),
	@year varchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [TRIFID]
      ,[ReportingYear]
      ,[StateReceivedDate]
      ,[SubmissionMethod]
  FROM [V_MAN_SUB_DTL]
WHERE [TRIFID] = @tid
      AND [ReportingYear] = @year;
	

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetFacilityManagerDetailData]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetFacilityManagerDetailData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetFacilityManagerDetailData] 
	@tid varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	  --ORDER BY TRIFID, ReportingYear DESC

	SELECT DISTINCT G.TRIFID
		  ,G.ReportingYear
		  ,G.SubmittedFacilityName
		  ,G.EPAReceivedDate
		  ,CONVERT(VARCHAR, G.EPAReceivedDate, 101) as EPAReceivedDateDisplay
		  ,G.SubmissionMethod
		  ,G.Status
	FROM V_MNG_FAC_DTL G
	WHERE  TRIFID = @tid
	AND NOT EXISTS
	(

		SELECT *
		FROM		dbo.App_FI_TRIFID_Delete D
		JOIN		dbo.App_FI_TRIFID T ON T.TRIFID_ID = D.TRIFID_ID_FK
		WHERE		T.TRIFID = G.TRIFID
			AND		D.TRI_SUB_ID = G.TRI_SUB_ID

	);




	SELECT DISTINCT TRIFID
		  ,ReportingYear
		  ,StateReceivedDate
		  ,SubmissionMethod
	  FROM V_MAN_SUB_DTL 
	WHERE  TRIFID = @tid
	ORDER BY TRIFID, ReportingYear DESC;

END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetFacilityManagerDetail]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetFacilityManagerDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Manager Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetFacilityManagerDetail] 
	@triId varchar(100),
	@agencyId varchar(100) OUT,
	@epaId varchar(100) OUT,
	@comment varchar(4000) OUT,
	@isUpdatatable bit OUT,
	@triPk int OUT,
    @inactiveDate datetime OUT,
	@agencyName varchar(100) OUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Assign the PK from the existent record
	SELECT @triPk = TRIFID_ID, 
           @agencyId = [AgencyID],
		   @epaId = [EPAID],
           @inactiveDate = Inactive_DT,
		   @agencyName = AgencyName
	FROM App_FI_TRIFID 
	WHERE TRIFID = @triId;

	-- If there is no record Pk the rest does not matter
	IF (@triPk IS NULL)

	BEGIN
		RAISERROR (''Unable to find TRIFID'', 16, 1);
		RETURN
	END


	SELECT
		@comment = Comment_DS
	FROM V_FAC_IDENT
	WHERE TRIFID = @triId;

	IF EXISTS (SELECT 1 FROM V_MNG_FAC_DTL WHERE TRIFID = @triId)
		SELECT @isUpdatatable = 0;
	ELSE
		SELECT @isUpdatatable = 1;

END


' 
END
GO
/****** Object:  Table [dbo].[TRI_TRANSFER_Q]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_Q]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_TRANSFER_Q](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[TRANSFER_SEQ_CLBER] [varchar](100) NULL,
	[WASTE_Q_ME] [varchar](100) NULL,
	[WASTE_Q_RANGE_CODE] [varchar](100) NULL,
	[WASTE_Q_NA_IND] [char](1) NULL,
	[Q_BASIS_EST_CODE] [varchar](100) NULL,
	[Q_BASIS_EST_NA_IND] [char](1) NULL,
	[WASTE_MANAGEMENT_CODE] [varchar](100) NULL,
	[TOX_EQ_VAL1] [varchar](100) NULL,
	[TOX_EQ_VAL2] [varchar](100) NULL,
	[TOX_EQ_VAL3] [varchar](100) NULL,
	[TOX_EQ_VAL4] [varchar](100) NULL,
	[TOX_EQ_VAL5] [varchar](100) NULL,
	[TOX_EQ_VAL6] [varchar](100) NULL,
	[TOX_EQ_VAL7] [varchar](100) NULL,
	[TOX_EQ_VAL8] [varchar](100) NULL,
	[TOX_EQ_VAL9] [varchar](100) NULL,
	[TOX_EQ_VAL10] [varchar](100) NULL,
	[TOX_EQ_VAL11] [varchar](100) NULL,
	[TOX_EQ_VAL12] [varchar](100) NULL,
	[TOX_EQ_VAL13] [varchar](100) NULL,
	[TOX_EQ_VAL14] [varchar](100) NULL,
	[TOX_EQ_VAL15] [varchar](100) NULL,
	[TOX_EQ_VAL16] [varchar](100) NULL,
	[TOX_EQ_VAL17] [varchar](100) NULL,
	[TOX_EQ_NA_IND] [char](1) NULL,
	[WASTE_Q_CATASTROPHIC_MEASURE] [varchar](100) NULL,
	[WASTE_Q_RANGE_NUM_BASIS_VALUE] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_TRANSFER_Q] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_Q]') AND name = N'IX_TRI_TRANSFER_Q_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_TRANSFER_Q_FK] ON [dbo].[TRI_TRANSFER_Q] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRI_SRC_RED_METH_CD]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_METH_CD]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_SRC_RED_METH_CD](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[SRC_RED_METH_CODE] [varchar](100) NULL,
	[SRC_RED_NA_IND] [char](1) NULL,
 CONSTRAINT [PK_TRI_SRC_RED_METH_CD] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_METH_CD]') AND name = N'_dta_index_TRI_SRC_RED_METH_CD_23_1301579675__K2_3')
CREATE NONCLUSTERED INDEX [_dta_index_TRI_SRC_RED_METH_CD_23_1301579675__K2_3] ON [dbo].[TRI_SRC_RED_METH_CD] 
(
	[FK_GUID] ASC
)
INCLUDE ( [SRC_RED_METH_CODE]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_METH_CD]') AND name = N'IX_TRI_SRC_RED_METH_CD_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_SRC_RED_METH_CD_FK] ON [dbo].[TRI_SRC_RED_METH_CD] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_EPA_DATASET]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EPA_DATASET]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EPA_DATASET]
AS
SELECT

S.TRI_SUB_ID AS SUB_ID
,F.FAC_SITE AS FAC_NAME
,F.FAC_ID AS TRIFID
,R.TECH_CONT AS TECH_CONT
,R.TECH_CONT_EMAIL_ADDRES AS TECH_CONT_EMAIL_ADDRESS
,''Form '' + RIGHT(R.REPORT_TYPE_CODE, 1) AS REPORT_TYPE_CODE
,R.SUB_REP_YEAR AS SUB_REP_YEAR
,C.CHEM_TXT AS CHEM_TXT

FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON S.PK_GUID = F.FK_GUID
JOIN dbo.TRI_REPORT R ON S.PK_GUID = R.FK_GUID
JOIN dbo.TRI_CHEM C ON R.PK_GUID = C.FK_GUID

'
GO
/****** Object:  View [dbo].[V_CUSTOM_QUERY_STREAM]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_CUSTOM_QUERY_STREAM]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_CUSTOM_QUERY_STREAM]

AS
SELECT

	FK_GUID
,	SUM(CAST(dbo.TRI_RangeCodeConversion(WASTE_Q_ME, WASTE_Q_RANGE_CODE) AS DECIMAL(18,10))) ONREL_53_WATER
,	SUM(CAST(RELEASE_STORM_WATER AS DECIMAL(18,10))) RELEASE_STORM_WATER

FROM TRI_ONSITE_RELEASE_Q
WHERE EI_MEDIUM_CODE = ''WATER''

GROUP BY FK_GUID



'
GO
/****** Object:  View [dbo].[V_EXT_CONTACT_D]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_CONTACT_D]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EXT_CONTACT_D]
AS
SELECT     FI.FS_ID AS FSID, FI.EPA_ID AS [ECY ID], UPPER(F.FAC_ID) AS TRIFID, F.FAC_SITE AS [Facility Name], T.AgencyName AS AKA, 
                      F.LOC_ADD_TXT AS [Address 1], F.SUPP_LOC_TXT AS [Address 2], F.LOCALITY AS City, F.COUNTY, F.ADD_POSTAL_CODE AS Zip, 
                      F.MAIL_FAC_SITE AS [Mail Name], F.MAIL_ADD_TXT AS [Mail Add 1], F.SUPP_MAIL_ADD AS [Mail Add 2], F.MAIL_ADD_CITY AS [Mail City], 
                      F.MAIL_ADD_STATE AS [Mail State], F.MAIL_ADD_POSTAL_CODE AS [Mail Zip], F.PROVINCE_TXT AS [Mail Province], 
                      F.MAIL_ADD_COUNTRY AS [Mail Country], F.MAIL_ADD_COUNTRY_CODE AS [Mail Country Code], R.PUB_CONT AS [Pub Contact], 
                      R.PUB_CONT_PHONE_TXT AS [Pub Phone], LOWER(R.PUB_CONT_EMAIL_ADDRES) AS [Pub Email], R.TECH_CONT AS [Tech Contact], 
                      R.TECH_CONT_PHONE_TXT AS [Tech Phone], LOWER(R.TECH_CONT_EMAIL_ADDRES) AS [Tech Email], CTYREG.EcologyRegion AS [ECY Region], 
                      MAX(R.SUB_REP_YEAR) AS Year, CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS Received, F.PK_GUID AS PK_GUID_FAC, 
                      F.FK_GUID AS FK_GUID_FAC, MAX(R.SUB_REP_YEAR) AS SUBMISSION_REPORTING_YEAR, CAST(NULL AS VARCHAR(255)) AS CHEMICAL_NAME_TEXT
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID
WHERE     (C.CAS_CLBER = ''N150'')
GROUP BY F.PK_GUID, F.FK_GUID, UPPER(F.FAC_ID), FI.EPA_ID, FI.FS_ID, T.AgencyName, F.FAC_SITE, F.LOC_ADD_TXT, F.SUPP_LOC_TXT, F.LOCALITY, 
                      F.COUNTY, F.ADD_POSTAL_CODE, F.PROVINCE_TXT, F.MAIL_ADD_COUNTRY, F.MAIL_ADD_COUNTRY_CODE, F.MAIL_ADD_TXT, F.SUPP_MAIL_ADD, 
                      F.MAIL_ADD_CITY, F.MAIL_ADD_POSTAL_CODE, F.MAIL_ADD_STATE, R.PUB_CONT, R.PUB_CONT_PHONE_TXT, 
                      LOWER(R.PUB_CONT_EMAIL_ADDRES), R.TECH_CONT, R.TECH_CONT_PHONE_TXT, LOWER(R.TECH_CONT_EMAIL_ADDRES), F.MAIL_FAC_SITE, 
                      CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101), CTYREG.EcologyRegion

'
GO
/****** Object:  View [dbo].[V_EXT_CONTACT]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_CONTACT]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EXT_CONTACT]
AS
SELECT     FI.FS_ID AS FSID, FI.EPA_ID AS [ECY ID], UPPER(F.FAC_ID) AS TRIFID, F.FAC_SITE AS [Facility Name], T.AgencyName AS AKA, 
                      F.LOC_ADD_TXT AS [Address 1], F.SUPP_LOC_TXT AS [Address 2], F.LOCALITY AS City, F.COUNTY, F.ADD_POSTAL_CODE AS Zip, 
                      F.MAIL_FAC_SITE AS [Mail Name], F.MAIL_ADD_TXT AS [Mail Add 1], F.SUPP_MAIL_ADD AS [Mail Add 2], F.MAIL_ADD_CITY AS [Mail City], 
                      F.MAIL_ADD_STATE AS [Mail State], F.MAIL_ADD_POSTAL_CODE AS [Mail Zip], F.PROVINCE_TXT AS [Mail Province], 
                      F.MAIL_ADD_COUNTRY AS [Mail Country], F.MAIL_ADD_COUNTRY_CODE AS [Mail Country Code], R.PUB_CONT AS [Pub Contact], 
                      R.PUB_CONT_PHONE_TXT AS [Pub Phone], LOWER(R.PUB_CONT_EMAIL_ADDRES) AS [Pub Email], R.TECH_CONT AS [Tech Contact], 
                      R.TECH_CONT_PHONE_TXT AS [Tech Phone], LOWER(R.TECH_CONT_EMAIL_ADDRES) AS [Tech Email], CTYREG.EcologyRegion AS [ECY Region], 
                      MAX(R.SUB_REP_YEAR) AS Year, CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS Received, F.PK_GUID AS PK_GUID_FAC, 
                      F.FK_GUID AS FK_GUID_FAC, MAX(R.SUB_REP_YEAR) AS SUBMISSION_REPORTING_YEAR,  CAST(NULL AS VARCHAR(255)) AS CHEMICAL_NAME_TEXT
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID
WHERE     (C.CAS_CLBER <> ''N150'')
GROUP BY F.PK_GUID, F.FK_GUID, UPPER(F.FAC_ID), FI.EPA_ID, FI.FS_ID, T.AgencyName, F.FAC_SITE, F.LOC_ADD_TXT, F.SUPP_LOC_TXT, F.LOCALITY, 
                      F.COUNTY, F.ADD_POSTAL_CODE, F.PROVINCE_TXT, F.MAIL_ADD_COUNTRY, F.MAIL_ADD_COUNTRY_CODE, F.MAIL_ADD_TXT, F.SUPP_MAIL_ADD, 
                      F.MAIL_ADD_CITY, F.MAIL_ADD_POSTAL_CODE, F.MAIL_ADD_STATE, R.PUB_CONT, R.PUB_CONT_PHONE_TXT, 
                      LOWER(R.PUB_CONT_EMAIL_ADDRES), R.TECH_CONT, R.TECH_CONT_PHONE_TXT, LOWER(R.TECH_CONT_EMAIL_ADDRES), F.MAIL_FAC_SITE, 
                      CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101), CTYREG.EcologyRegion

'
GO
/****** Object:  View [dbo].[V_EPA_SUB_CHEM]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EPA_SUB_CHEM]'))
EXEC dbo.sp_executesql @statement = N'CREATE   VIEW [dbo].[V_EPA_SUB_CHEM]
AS
SELECT DISTINCT S.TRI_SUB_ID AS SUB_ID, ''Form '' + RIGHT(R.REPORT_TYPE_CODE, 1) AS REPORT_TYPE_CODE, R.SUB_REP_YEAR, C.CHEM_TXT
FROM         dbo.TRI_SUB AS S INNER JOIN
                      dbo.TRI_FAC AS F ON S.PK_GUID = F.FK_GUID INNER JOIN
                      dbo.TRI_REPORT AS R ON S.PK_GUID = R.FK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON R.PK_GUID = C.FK_GUID

WHERE NOT EXISTS
(
SELECT * FROM dbo.App_EmailLog E
WHERE E.TRI_SUB_ID = S.PK_GUID
)

AND CHARINDEX(''@'', ISNULL(R.TECH_CONT_EMAIL_ADDRES, '''')) > 0

'
GO
/****** Object:  View [dbo].[V_BRS_SEARCH]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BRS_SEARCH]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_TRI_BROWSE_TRI_SUBMISSIONS_SEARCH
 Condensed Name:	V_BRS_SEARCH
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Fills the fields on the search results page of TRI Browse Submissions

 Change Log:
3/29/2009	TKC	Limit facility summary results to the most recently-received submission.
4/14/2010	TKC	Removed chemicals from the search results
*/

CREATE VIEW [dbo].[V_BRS_SEARCH]
AS

SELECT
	CONVERT(int, RTRIM(R.SUB_REP_YEAR)) AS REPORT_YEAR
,	CASE
		WHEN (T .AgencyName = '''' OR T .AgencyName IS NULL)
		THEN F.FAC_SITE
		ELSE T .AgencyName
	END AS DISPLAY_NAME
,	UPPER(F.FAC_ID) AS TRIF_ID
,	F.FAC_SITE AS FAC_NAME
,	T.AgencyName AS AGENCY_NAME
,	COALESCE (F.LOC_ADD_TXT + '', '', '''') +
	COALESCE (F.LOCALITY + '', '', '''') +
	COALESCE (F.STATE + '', '', '''') +
	COALESCE (F.ADD_POSTAL_CODE, '''') AS ADDRESS
,	F.ADD_POSTAL_CODE AS ZIP
,	F.COUNTY
,	F.LOCALITY AS CITY
,	FI.FS_ID
,	FI.EPA_ID
,	(
		SELECT MAX(S2.INSERTED_DATE)
		FROM TRI_SUB S2
		JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE F2.FAC_ID = F.FAC_ID
	) AS RECEIVED_DATE
,	UPPER(C.CHEM_TXT) AS CHEMS

FROM dbo.TRI_REPORT AS R
JOIN dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID
LEFT JOIN dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID
LEFT JOIN dbo.V_FAC_IDENT AS FI ON F.FAC_ID = FI.TRIFID
LEFT JOIN dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID
LEFT JOIN dbo.App_FI_TRIFID_Delete AS D ON
	D.TRIFID_ID_FK = T.TRIFID_ID
AND
	D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
	D.TRIFID_DELETE_ID IS NULL
AND
	T.Inactive_DT IS NULL
/*
AND
	S.INSERTED_DATE =
		(
		SELECT MAX(S2.INSERTED_DATE)
		FROM TRI_SUB S2
		JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
		JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		WHERE
			F2.FAC_ID = F.FAC_ID
		AND
			R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
			C2.CHEM_TXT = C.CHEM_TXT
		)
*/
'
GO
/****** Object:  View [dbo].[V_Del_TRI_Reports]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_Del_TRI_Reports]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_Del_TRI_Reports]
AS
SELECT     dbo.App_FI_TRIFID_Delete.TRIFID_ID_FK, dbo.App_FI_TRIFID.TRIFID, dbo.TRI_FAC.FAC_ID, dbo.TRI_SUB.TRI_SUB_ID, 
                      dbo.TRI_REPORT.SUB_REP_YEAR, dbo.TRI_REPORT.REPORT_TYPE_CODE, dbo.TRI_REPORT.REVISION_IND, dbo.TRI_CHEM.CAS_CLBER, 
                      dbo.TRI_REPORT.CERT_SIGNED_DATE AS ''Certification Date'', dbo.TRI_SUB.INSERTED_DATE AS ''Date Process into TRIDEX'', 
                      dbo.App_FI_TRIFID_Delete.Last_Updated_User_ID AS ''Deleted by'', dbo.App_FI_TRIFID_Delete.Last_Updated_DT AS ''Deletion Date'', 
                      dbo.App_Link_TRI_SUB_Filename.FileNameTxt
FROM         dbo.App_FI_TRIFID_Delete INNER JOIN
                      dbo.App_FI_TRIFID ON dbo.App_FI_TRIFID_Delete.TRIFID_ID_FK = dbo.App_FI_TRIFID.TRIFID_ID INNER JOIN
                      dbo.TRI_FAC ON dbo.App_FI_TRIFID.TRIFID = dbo.TRI_FAC.FAC_ID INNER JOIN
                      dbo.TRI_REPORT ON dbo.TRI_FAC.FK_GUID = dbo.TRI_REPORT.FK_GUID INNER JOIN
                      dbo.TRI_CHEM ON dbo.TRI_REPORT.PK_GUID = dbo.TRI_CHEM.FK_GUID INNER JOIN
                      dbo.TRI_SUB ON dbo.TRI_FAC.FK_GUID = dbo.TRI_SUB.PK_GUID AND dbo.TRI_REPORT.FK_GUID = dbo.TRI_SUB.PK_GUID INNER JOIN
                      dbo.App_Link_TRI_SUB_Filename ON dbo.TRI_SUB.TRI_SUB_ID = dbo.App_Link_TRI_SUB_Filename.TRI_SUB_ID
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'V_Del_TRI_Reports', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "App_FI_TRIFID_Delete"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "App_FI_TRIFID"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 114
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TRI_FAC"
            Begin Extent = 
               Top = 6
               Left = 498
               Bottom = 114
               Right = 740
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TRI_REPORT"
            Begin Extent = 
               Top = 6
               Left = 778
               Bottom = 114
               Right = 1050
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TRI_CHEM"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 226
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TRI_SUB"
            Begin Extent = 
               Top = 114
               Left = 264
               Bottom = 222
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "App_Link_TRI_SUB_Filename"
            Begin Extent = 
               Top = 114
               Left = 471
               Bottom = 192
               Right = 622
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Del_TRI_Reports'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'V_Del_TRI_Reports', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Del_TRI_Reports'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'V_Del_TRI_Reports', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Del_TRI_Reports'
GO
/****** Object:  View [dbo].[V_BRS_RSLT_DTL]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BRS_RSLT_DTL]'))
EXEC dbo.sp_executesql @statement = N'CREATE   VIEW [dbo].[V_BRS_RSLT_DTL]
(TRIFID, SUB_REP_YEAR, REPORT_SUB_METH_CODE, REPORT_EPA_PROCESSING_STATUS_C, REPORT_TYPE_CODE, SUB_PK_GUID, NUM_OF_CHEMS_PER_SUBMISSION, INSERTED_DATE)

-- =============================================
-- Full Name:		V_TRI_BROWSE_TRI_SUBMISSIONS_RESULTS_DETAIL
-- Condensed Name:	V_BRS_RSLT_DTL
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the detail fields on the search results page of TRI Browse Submissions for each report
-- =============================================

AS
SELECT DISTINCT
 UPPER (F.FAC_ID) TRIFID, R.SUB_REP_YEAR, R.REPORT_SUB_METH_CODE, dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C) REPORT_EPA_PROCESSING_STATUS_C, NULL AS REPORT_TYPE_CODE, S.PK_GUID AS SUB_PK_GUID
,(
SELECT COUNT (*)
FROM TRI_SUB S2
JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
WHERE
S2.PK_GUID = S.PK_GUID
) AS NUM_OF_CHEMS_PER_SUBMISSION
,S.INSERTED_DATE

       FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
            INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
            INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
-- TKC 8/27/2007	JOIN on the App_FI_TRIFID_Delete table to exclude "deleted" facilities
            LEFT JOIN dbo.App_FI_TRIFID T ON F.FAC_ID = T.TRIFID
            LEFT JOIN dbo.App_FI_TRIFID_Delete D ON
                          D.TRIFID_ID_FK = T.TRIFID_ID
                AND       D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
/*
S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM TRI_SUB S2
	JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
	JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
	JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
	WHERE
		F2.FAC_ID = F.FAC_ID
		AND
		R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
		C2.CHEM_TXT = C.CHEM_TXT
	)
*/
-- TKC 8/27/2007	exclude "deleted" facilities

D.TRIFID_DELETE_ID IS NULL

-- TKC 1/31/2008	exclude "inactive" facilities
AND T.Inactive_DT IS NULL

'
GO
/****** Object:  View [dbo].[V_BRS_RSLT_CHM]    Script Date: 12/02/2010 14:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BRS_RSLT_CHM]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_BRS_RSLT_CHM]
(SUB_PK_GUID, REPORT_TYPE_CODE, REVISION_IND, SUB_PARTIAL_FAC_ID, INSERTED_DATE, CHEMICAL, 
 REP_PK_GUID, TRIFID, SUB_REP_YEAR)

-- =============================================
-- Full Name:		V_TRI_BROWSE_TRI_SUBMISSIONS_RESULTS_DETAIL_CHEMICAL
-- Condensed Name:	V_BRS_RSLT_CHM
-- Author:			TK Conrad
-- Create date:		2007-05-29
-- Description:		Displays the list of chemicals per report for the TRI browse screen
-- =============================================

AS
SELECT
 S.PK_GUID SUB_PK_GUID,
            RIGHT(R.REPORT_TYPE_CODE, 1) REPORT_TYPE_CODE,
            R.REVISION_IND, SUB_PARTIAL_FAC_ID,
            S.INSERTED_DATE, C.CHEM_TXT CHEMICAL, R.PK_GUID REP_PK_GUID, UPPER(F.FAC_ID) AS TRIFID, R.SUB_REP_YEAR
       FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
            INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
            INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
-- TKC 8/27/2007	JOIN on the App_FI_TRIFID_Delete table to exclude "deleted" facilities
            LEFT JOIN dbo.App_FI_TRIFID T ON F.FAC_ID = T.TRIFID
            LEFT JOIN dbo.App_FI_TRIFID_Delete D ON
                          D.TRIFID_ID_FK = T.TRIFID_ID
                AND       D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE 

-- TKC 8/27/2007	exclude "deleted" facilities

D.TRIFID_DELETE_ID IS NULL
/*
AND S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM TRI_SUB S2
	JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
	JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
	JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
	WHERE
		F2.FAC_ID = F.FAC_ID
		AND
		R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
		C2.CHEM_TXT = C.CHEM_TXT
	)
*/

AND T.Inactive_DT IS NULL

'
GO
/****** Object:  View [dbo].[V_BRS_CHEM_DDL]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BRS_CHEM_DDL]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_BRS_CHEM_DDL]

-- =============================================
-- Full Name:		V_TRI_BROWSE_TRI_SUBMISSIONS_CHEMICALS_DDL
-- Condensed Name:	V_BRS_CHEM_DDL
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the drop-down-list on the Browse TRI Submissions page.
-- =============================================

AS
SELECT DISTINCT C.CHEM_TXT

FROM TRI_CHEM C

'
GO
/****** Object:  Table [dbo].[TRI_WASTE_TREAT_METH]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_METH]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TRI_WASTE_TREAT_METH](
	[PK_GUID] [varchar](36) NOT NULL,
	[FK_GUID] [varchar](36) NOT NULL,
	[WASTE_TREAT_SEQ_CL] [varchar](100) NULL,
	[WASTE_TREAT_METH_CODE] [varchar](100) NULL,
 CONSTRAINT [PK_TRI_WASTE_TREAT_METH] PRIMARY KEY CLUSTERED 
(
	[PK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_METH]') AND name = N'IX_TRI_WASTE_TREAT_METH_FK')
CREATE NONCLUSTERED INDEX [IX_TRI_WASTE_TREAT_METH_FK] ON [dbo].[TRI_WASTE_TREAT_METH] 
(
	[FK_GUID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_FAC_CHEMICAL_DATA]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FAC_CHEMICAL_DATA]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[V_FAC_CHEMICAL_DATA]
AS
SELECT

	UPPER(F.FAC_ID) AS TRIFID
,	R.SUB_REP_YEAR
,	S.PK_GUID AS SUB_ID
,	UPPER(COALESCE (RIGHT(R.REPORT_TYPE_CODE, 1), '''')) AS REPORT_TYPE_CODE
,	dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) AS IS_REVISION
,	CONVERT(bit, CASE WHEN R.SUB_PARTIAL_FAC_ID = ''Y'' THEN 1 ELSE 0 END) AS IS_PARTIAL
,	S.INSERTED_DATE AS RECEIVED_DATE
,	UPPER(C.CHEM_TXT) AS CHEMICAL_NAME
,	UPPER(C.CAS_CLBER) AS CHEMICAL_CAS_NO
,	LSF.FileNameTxt AS TRI_FILENAME
--,	CAST(''1234.xml'' AS VARCHAR(255)) AS TRI_FILENAME
,	R.PK_GUID AS CHEM_ID
,	S.INSERTED_DATE

FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
LEFT JOIN dbo.App_FI_TRIFID T ON F.FAC_ID = T.TRIFID
LEFT JOIN dbo.App_FI_TRIFID_Delete D ON
              D.TRIFID_ID_FK = T.TRIFID_ID
    AND       D.TRI_SUB_ID = S.TRI_SUB_ID
LEFT JOIN dbo.App_Link_TRI_SUB_Filename LSF ON LSF.TRI_SUB_ID = S.TRI_SUB_ID

WHERE 

D.TRIFID_DELETE_ID IS NULL
AND
T.Inactive_DT IS NULL

/*
AND
S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM dbo.TRI_SUB S2
	JOIN dbo.TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
	JOIN dbo.TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
	JOIN dbo.TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
	WHERE
		F2.FAC_ID = F.FAC_ID
		AND
		R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
		C2.CHEM_TXT = C.CHEM_TXT
	)
*/



'
GO
/****** Object:  View [dbo].[V_FORM_A_PG_2]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_A_PG_2]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_A_PG_2]

-- =============================================
-- Full Name:		V_TRI_FORM_A_PAGE_2
-- Condensed Name:	V_FORM_A_PG_2
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the fields on Form "A", Pages 2..n
-- =============================================

AS
SELECT
S.PK_GUID AS PK_GUID_SUB
,R.PK_GUID AS PK_GUID_REP
,UPPER(FAC_ID) FAC_ID
,C.CAS_CLBER A11
,C.CHEM_TXT A12
,C.CHEM_REGISTRY A13
,C.CHEM_MIXTURE_TXT A21
,R.PK_GUID AS CHEM_ID

FROM TRI_REPORT R
JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG2]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG2]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG2]

AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       F.FAC_ID,
       C.CHEM_TXT,

       S1541.TOX_EQ_NA_IND S1541NA,
       S1541.TOX_EQ_VAL1 S1541T1,
       S1541.TOX_EQ_VAL2 S1541T2,
       S1541.TOX_EQ_VAL3 S1541T3,
       S1541.TOX_EQ_VAL4 S1541T4,
       S1541.TOX_EQ_VAL5 S1541T5,
       S1541.TOX_EQ_VAL6 S1541T6,
       S1541.TOX_EQ_VAL7 S1541T7,
       S1541.TOX_EQ_VAL8 S1541T8,
       S1541.TOX_EQ_VAL9 S1541T9,
       S1541.TOX_EQ_VAL10 S1541T10,
       S1541.TOX_EQ_VAL11 S1541T11,
       S1541.TOX_EQ_VAL12 S1541T12,
       S1541.TOX_EQ_VAL13 S1541T13,
       S1541.TOX_EQ_VAL14 S1541T14,
       S1541.TOX_EQ_VAL15 S1541T15,
       S1541.TOX_EQ_VAL16 S1541T16,
       S1541.TOX_EQ_VAL17 S1541T17,

       S1542.TOX_EQ_NA_IND S1542NA,
       S1542.TOX_EQ_VAL1 S1542T1,
       S1542.TOX_EQ_VAL2 S1542T2,
       S1542.TOX_EQ_VAL3 S1542T3,
       S1542.TOX_EQ_VAL4 S1542T4,
       S1542.TOX_EQ_VAL5 S1542T5,
       S1542.TOX_EQ_VAL6 S1542T6,
       S1542.TOX_EQ_VAL7 S1542T7,
       S1542.TOX_EQ_VAL8 S1542T8,
       S1542.TOX_EQ_VAL9 S1542T9,
       S1542.TOX_EQ_VAL10 S1542T10,
       S1542.TOX_EQ_VAL11 S1542T11,
       S1542.TOX_EQ_VAL12 S1542T12,
       S1542.TOX_EQ_VAL13 S1542T13,
       S1542.TOX_EQ_VAL14 S1542T14,
       S1542.TOX_EQ_VAL15 S1542T15,
       S1542.TOX_EQ_VAL16 S1542T16,
       S1542.TOX_EQ_VAL17 S1542T17,

       S1551A.TOX_EQ_NA_IND S1551ANA,
       S1551A.TOX_EQ_VAL1 S1551AT1,
       S1551A.TOX_EQ_VAL2 S1551AT2,
       S1551A.TOX_EQ_VAL3 S1551AT3,
       S1551A.TOX_EQ_VAL4 S1551AT4,
       S1551A.TOX_EQ_VAL5 S1551AT5,
       S1551A.TOX_EQ_VAL6 S1551AT6,
       S1551A.TOX_EQ_VAL7 S1551AT7,
       S1551A.TOX_EQ_VAL8 S1551AT8,
       S1551A.TOX_EQ_VAL9 S1551AT9,
       S1551A.TOX_EQ_VAL10 S1551AT10,
       S1551A.TOX_EQ_VAL11 S1551AT11,
       S1551A.TOX_EQ_VAL12 S1551AT12,
       S1551A.TOX_EQ_VAL13 S1551AT13,
       S1551A.TOX_EQ_VAL14 S1551AT14,
       S1551A.TOX_EQ_VAL15 S1551AT15,
       S1551A.TOX_EQ_VAL16 S1551AT16,
       S1551A.TOX_EQ_VAL17 S1551AT17,

       S1551B.TOX_EQ_NA_IND S1551BNA,
       S1551B.TOX_EQ_VAL1 S1551BT1,
       S1551B.TOX_EQ_VAL2 S1551BT2,
       S1551B.TOX_EQ_VAL3 S1551BT3,
       S1551B.TOX_EQ_VAL4 S1551BT4,
       S1551B.TOX_EQ_VAL5 S1551BT5,
       S1551B.TOX_EQ_VAL6 S1551BT6,
       S1551B.TOX_EQ_VAL7 S1551BT7,
       S1551B.TOX_EQ_VAL8 S1551BT8,
       S1551B.TOX_EQ_VAL9 S1551BT9,
       S1551B.TOX_EQ_VAL10 S1551BT10,
       S1551B.TOX_EQ_VAL11 S1551BT11,
       S1551B.TOX_EQ_VAL12 S1551BT12,
       S1551B.TOX_EQ_VAL13 S1551BT13,
       S1551B.TOX_EQ_VAL14 S1551BT14,
       S1551B.TOX_EQ_VAL15 S1551BT15,
       S1551B.TOX_EQ_VAL16 S1551BT16,
       S1551B.TOX_EQ_VAL17 S1551BT17,

       S1552.TOX_EQ_NA_IND S1552NA,
       S1552.TOX_EQ_VAL1 S1552T1,
       S1552.TOX_EQ_VAL2 S1552T2,
       S1552.TOX_EQ_VAL3 S1552T3,
       S1552.TOX_EQ_VAL4 S1552T4,
       S1552.TOX_EQ_VAL5 S1552T5,
       S1552.TOX_EQ_VAL6 S1552T6,
       S1552.TOX_EQ_VAL7 S1552T7,
       S1552.TOX_EQ_VAL8 S1552T8,
       S1552.TOX_EQ_VAL9 S1552T9,
       S1552.TOX_EQ_VAL10 S1552T10,
       S1552.TOX_EQ_VAL11 S1552T11,
       S1552.TOX_EQ_VAL12 S1552T12,
       S1552.TOX_EQ_VAL13 S1552T13,
       S1552.TOX_EQ_VAL14 S1552T14,
       S1552.TOX_EQ_VAL15 S1552T15,
       S1552.TOX_EQ_VAL16 S1552T16,
       S1552.TOX_EQ_VAL17 S1552T17,

       S1553A.TOX_EQ_NA_IND S1553ANA,
       S1553A.TOX_EQ_VAL1 S1553AT1,
       S1553A.TOX_EQ_VAL2 S1553AT2,
       S1553A.TOX_EQ_VAL3 S1553AT3,
       S1553A.TOX_EQ_VAL4 S1553AT4,
       S1553A.TOX_EQ_VAL5 S1553AT5,
       S1553A.TOX_EQ_VAL6 S1553AT6,
       S1553A.TOX_EQ_VAL7 S1553AT7,
       S1553A.TOX_EQ_VAL8 S1553AT8,
       S1553A.TOX_EQ_VAL9 S1553AT9,
       S1553A.TOX_EQ_VAL10 S1553AT10,
       S1553A.TOX_EQ_VAL11 S1553AT11,
       S1553A.TOX_EQ_VAL12 S1553AT12,
       S1553A.TOX_EQ_VAL13 S1553AT13,
       S1553A.TOX_EQ_VAL14 S1553AT14,
       S1553A.TOX_EQ_VAL15 S1553AT15,
       S1553A.TOX_EQ_VAL16 S1553AT16,
       S1553A.TOX_EQ_VAL17 S1553AT17,

       S1553B.TOX_EQ_NA_IND S1553BNA,
       S1553B.TOX_EQ_VAL1 S1553BT1,
       S1553B.TOX_EQ_VAL2 S1553BT2,
       S1553B.TOX_EQ_VAL3 S1553BT3,
       S1553B.TOX_EQ_VAL4 S1553BT4,
       S1553B.TOX_EQ_VAL5 S1553BT5,
       S1553B.TOX_EQ_VAL6 S1553BT6,
       S1553B.TOX_EQ_VAL7 S1553BT7,
       S1553B.TOX_EQ_VAL8 S1553BT8,
       S1553B.TOX_EQ_VAL9 S1553BT9,
       S1553B.TOX_EQ_VAL10 S1553BT10,
       S1553B.TOX_EQ_VAL11 S1553BT11,
       S1553B.TOX_EQ_VAL12 S1553BT12,
       S1553B.TOX_EQ_VAL13 S1553BT13,
       S1553B.TOX_EQ_VAL14 S1553BT14,
       S1553B.TOX_EQ_VAL15 S1553BT15,
       S1553B.TOX_EQ_VAL16 S1553BT16,
       S1553B.TOX_EQ_VAL17 S1553BT17,

       S1554.TOX_EQ_NA_IND S1554NA,
       S1554.TOX_EQ_VAL1 S1554T1,
       S1554.TOX_EQ_VAL2 S1554T2,
       S1554.TOX_EQ_VAL3 S1554T3,
       S1554.TOX_EQ_VAL4 S1554T4,
       S1554.TOX_EQ_VAL5 S1554T5,
       S1554.TOX_EQ_VAL6 S1554T6,
       S1554.TOX_EQ_VAL7 S1554T7,
       S1554.TOX_EQ_VAL8 S1554T8,
       S1554.TOX_EQ_VAL9 S1554T9,
       S1554.TOX_EQ_VAL10 S1554T10,
       S1554.TOX_EQ_VAL11 S1554T11,
       S1554.TOX_EQ_VAL12 S1554T12,
       S1554.TOX_EQ_VAL13 S1554T13,
       S1554.TOX_EQ_VAL14 S1554T14,
       S1554.TOX_EQ_VAL15 S1554T15,
       S1554.TOX_EQ_VAL16 S1554T16,
       S1554.TOX_EQ_VAL17 S1554T17

  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1541 ON S1541.FK_GUID = R.PK_GUID
                                               AND S1541.EI_MEDIUM_CODE = ''UNINJ I''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1542 ON S1542.FK_GUID = R.PK_GUID
                                               AND S1542.EI_MEDIUM_CODE = ''UNINJ IIV''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1551A ON S1551A.FK_GUID = R.PK_GUID
                                               AND S1551A.EI_MEDIUM_CODE = ''RCRA C''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1551B ON S1551B.FK_GUID = R.PK_GUID
                                               AND S1551B.EI_MEDIUM_CODE = ''OTH LANDF''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1552 ON S1552.FK_GUID = R.PK_GUID
                                               AND S1552.EI_MEDIUM_CODE = ''LAND TREA''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1553A ON S1553A.FK_GUID = R.PK_GUID
                                               AND S1553A.EI_MEDIUM_CODE = ''SI 5.5.3A''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1553B ON S1553B.FK_GUID = R.PK_GUID
                                               AND S1553B.EI_MEDIUM_CODE = ''SI 5.5.3B''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q S1554 ON S1554.FK_GUID = R.PK_GUID
                                               AND S1554.EI_MEDIUM_CODE = ''OTH DISP''

'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG1_53]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG1_53]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG1_53]

AS
SELECT   FK_GUID,
		TOX_EQ_VAL1,
		TOX_EQ_VAL2,
		TOX_EQ_VAL3,
		TOX_EQ_VAL4,
		TOX_EQ_VAL5,
		TOX_EQ_VAL6,
		TOX_EQ_VAL7,
		TOX_EQ_VAL8,
		TOX_EQ_VAL9,
		TOX_EQ_VAL10,
		TOX_EQ_VAL11,
		TOX_EQ_VAL12,
		TOX_EQ_VAL13,
		TOX_EQ_VAL14,
		TOX_EQ_VAL15,
		TOX_EQ_VAL16,
		TOX_EQ_VAL17,
		TOX_EQ_NA_IND,
         (SELECT COUNT (*)
            FROM TRI_ONSITE_RELEASE_Q REL2
           WHERE REL2.EI_MEDIUM_CODE = ''WATER''
             AND REL2.FK_GUID = REL.FK_GUID
             AND REL2.PK_GUID <= REL.PK_GUID) NUM
    FROM TRI_ONSITE_RELEASE_Q REL
   WHERE EI_MEDIUM_CODE = ''WATER''

'
GO
/****** Object:  View [dbo].[V_TRI_PG5_7C]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG5_7C]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG5_7C]
(PK_GUID, ONSITE_RECYCG_METH_CODE, NUM)
AS
SELECT FK_GUID PK_GUID,
          E.ONSITE_RECYCG_METH_CODE,
          (SELECT COUNT (*)
             FROM TRI_ONSITE_RECYCG_PROC E2
            WHERE E2.FK_GUID = E.FK_GUID
              AND E2.PK_GUID <= E.PK_GUID) NUM
     FROM TRI_ONSITE_RECYCG_PROC E

'
GO
/****** Object:  View [dbo].[V_TRI_PG5_7B]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG5_7B]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG5_7B]
(PK_GUID, ENERGY_RCV_METH_CODE, NUM)
AS
SELECT FK_GUID PK_GUID,
          E.ENERGY_RCV_METH_CODE,
          (SELECT COUNT (*)
             FROM TRI_ONSITE_RCV_PROC E2
            WHERE E2.FK_GUID = E.FK_GUID
              AND E2.PK_GUID <= E.PK_GUID) NUM
     FROM TRI_ONSITE_RCV_PROC E

'
GO
/****** Object:  View [dbo].[V_RPT_NEW_SUBMISSIONS]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_NEW_SUBMISSIONS]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[V_RPT_NEW_SUBMISSIONS]

AS

SELECT

	F.FAC_ID														AS ''TRIFID''
,	F.FAC_SITE														AS ''Facility Name''
,	F.LOC_ADD_TXT + '', '' + F.LOCALITY + '', '' + F.ADD_POSTAL_CODE	AS ''Address''
,	F.COUNTY														AS ''County''
,	R.SUB_REP_YEAR													AS ''Reporting Year''
,	CONVERT(VARCHAR, S.INSERTED_DATE, 101)							AS ''Received Date''
,	COUNT(DISTINCT C.CHEM_TXT)										AS ''Number of Chems''

FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

WHERE DATEDIFF(DD, S.INSERTED_DATE, GETDATE()) BETWEEN 0 AND 3

GROUP BY
	F.FAC_ID
,	F.FAC_SITE
,	F.LOC_ADD_TXT
,	F.LOCALITY
,	F.ADD_POSTAL_CODE
,	F.COUNTY
,	CONVERT(VARCHAR, S.INSERTED_DATE, 101)
,	R.SUB_REP_YEAR

'
GO
/****** Object:  View [dbo].[V_RPT_INCOMPL_FACILITIES]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_INCOMPL_FACILITIES]'))
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW [dbo].[V_RPT_INCOMPL_FACILITIES]

AS

SELECT

	F.FAC_ID			AS ''TRIFID''
,	F.FAC_SITE		AS ''Facility Name''
,	CAST(R.SUB_REP_YEAR	AS INT) + 1 AS ''Reporting Year''
,	COUNT(*)			AS ''Number of Chems Missing''

FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

WHERE CAST(R.SUB_REP_YEAR AS INT) = (SELECT MAX(CAST(SUB_REP_YEAR AS INT)) - 1 FROM TRI_REPORT)

AND EXISTS
(
SELECT *
FROM TRI_SUB S3
JOIN TRI_FAC F3 ON F3.FK_GUID = S3.PK_GUID
JOIN TRI_REPORT R3 ON R3.FK_GUID = S3.PK_GUID
WHERE
F3.FAC_ID = F.FAC_ID
AND
CAST(R3.SUB_REP_YEAR AS INT) = (SELECT MAX(CAST(SUB_REP_YEAR AS INT)) FROM TRI_REPORT)
)

AND C.CHEM_TXT NOT IN
(
SELECT C2.CHEM_TXT

FROM TRI_SUB S2
JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
WHERE
F2.FAC_ID = F.FAC_ID
AND
CAST(R2.SUB_REP_YEAR AS INT) = (SELECT MAX(CAST(SUB_REP_YEAR AS INT)) FROM TRI_REPORT)
)

GROUP BY
	F.FAC_ID
,	R.SUB_REP_YEAR
,	F.FAC_SITE


'
GO
/****** Object:  View [dbo].[V_RPT_FED_FORM_WITHDRAWN]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_FED_FORM_WITHDRAWN]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_RPT_FED_FORM_WITHDRAWN]
AS
  SELECT tri_fac.fac_id                                           AS "TRIFID" ,
    tri_chem.cas_clber                                            AS "CAS Number" ,
    tri_report.sub_rep_year                                       AS "Report Year" ,
    tri_report.cert_signed_date                                   AS "Signed Date" ,
    tri_fac.fac_site                                              AS "Name" ,
    COUNT(1)                                                      AS number_of_withdrawls
  FROM tri_fac
  INNER JOIN tri_sub
  ON (tri_fac.fk_guid = tri_sub.pk_guid)
  INNER JOIN tri_report
  ON (tri_report.fk_guid = tri_sub.pk_guid)
  INNER JOIN tri_chem
  ON (tri_chem.fk_guid = tri_report.pk_guid)
  WHERE tri_report.chem_rpt_wd_cd_1            IS NOT NULL
  OR tri_report.chem_rpt_wd_cd_2               IS NOT NULL
  GROUP BY tri_fac.fac_id ,
    tri_chem.cas_clber ,
    tri_report.sub_rep_year ,
    tri_report.cert_signed_date ,
    tri_fac.fac_site'
GO
/****** Object:  View [dbo].[V_RPT_DUPLICATE_CHEMS]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_DUPLICATE_CHEMS]'))
EXEC dbo.sp_executesql @statement = N'



CREATE VIEW [dbo].[V_RPT_DUPLICATE_CHEMS]

AS

SELECT

	FAC_ID			AS ''TRIFID''
,	SUB_REP_YEAR		AS ''Reporting Year''
,	FAC_SITE			AS ''Facility Name''
,	COUNT(*)			AS ''Count of Dup Chemical''

FROM

	(
	SELECT
		F.FAC_ID
	,	R.SUB_REP_YEAR
	,	COALESCE(T.AgencyName, F.FAC_SITE) FAC_SITE
	,	C.CHEM_TXT

	FROM TRI_SUB S
	JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
	JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
	JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
	JOIN App_FI_TRIFID T ON T.TRIFID = F.FAC_ID

	WHERE
	R.REVISION_IND = ''N''
	AND
	COALESCE(R.CHEM_RPT_REV_CD_1, R.CHEM_RPT_REV_CD_2) IS NULL

	GROUP BY

		F.FAC_ID
	,	R.SUB_REP_YEAR
	,	COALESCE(T.AgencyName, F.FAC_SITE)
	,	C.CHEM_TXT

	HAVING COUNT(*) > 1
	) SUBQ

GROUP BY

	FAC_ID
,	SUB_REP_YEAR
,	FAC_SITE



'
GO
/****** Object:  View [dbo].[V_FAC_REPORT_DATA]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FAC_REPORT_DATA]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FAC_REPORT_DATA]
AS
SELECT TOP 100 PERCENT
	F.FAC_ID AS TRIFID
,	R.SUB_REP_YEAR
,	'''' AS INSERTED_DATE
,	COALESCE (R.SUB_REP_YEAR, '''') AS REPORT_YEAR
,	dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) AS REPORT_SUB_METH
--,	UPPER(COALESCE (R.REPORT_SUB_METH_CODE, '''')) AS REPORT_SUB_METH
,	UPPER(COALESCE (dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C), '''')) AS REPORT_EPA_STATUS
,	S.PK_GUID AS SUB_ID
,	COUNT(DISTINCT C.CHEM_TXT) AS REPORT_CHEM_NUM
,	'''' AS REPORT_TYPE_CODE

FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
LEFT JOIN dbo.App_FI_TRIFID T ON F.FAC_ID = T.TRIFID
LEFT JOIN dbo.App_FI_TRIFID_Delete D ON
              D.TRIFID_ID_FK = T.TRIFID_ID
    AND       D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE D.TRIFID_DELETE_ID IS NULL

GROUP BY
	F.FAC_ID
,	R.SUB_REP_YEAR
--,	R.REPORT_SUB_METH_CODE
,	R.REPORT_EPA_PROCESSING_STATUS_C
,	S.PK_GUID
,	S.TRI_SUB_ID

ORDER BY R.SUB_REP_YEAR DESC

'
GO
/****** Object:  View [dbo].[V_MAN_SUB_CHEM]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MAN_SUB_CHEM]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_MAN_SUB_CHEM]
AS
SELECT     C.CHEM_TXT AS CHEMICAL, RIGHT(R.REPORT_TYPE_CODE, 1) AS REPORT_TYPE_CODE, R.SUB_REP_YEAR, UPPER(F.FAC_ID) AS TRIFID
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG4]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG4]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG4]

AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       F.FAC_ID,
       C.CHEM_TXT,

       S181A.TOX_EQ_NA_IND S181ANA,
       S181A.TOX_EQ_VAL1 S181AT1,
       S181A.TOX_EQ_VAL2 S181AT2,
       S181A.TOX_EQ_VAL3 S181AT3,
       S181A.TOX_EQ_VAL4 S181AT4,
       S181A.TOX_EQ_VAL5 S181AT5,
       S181A.TOX_EQ_VAL6 S181AT6,
       S181A.TOX_EQ_VAL7 S181AT7,
       S181A.TOX_EQ_VAL8 S181AT8,
       S181A.TOX_EQ_VAL9 S181AT9,
       S181A.TOX_EQ_VAL10 S181AT10,
       S181A.TOX_EQ_VAL11 S181AT11,
       S181A.TOX_EQ_VAL12 S181AT12,
       S181A.TOX_EQ_VAL13 S181AT13,
       S181A.TOX_EQ_VAL14 S181AT14,
       S181A.TOX_EQ_VAL15 S181AT15,
       S181A.TOX_EQ_VAL16 S181AT16,
       S181A.TOX_EQ_VAL17 S181AT17,

       S181B.TOX_EQ_NA_IND S181BNA,
       S181B.TOX_EQ_VAL1 S181BT1,
       S181B.TOX_EQ_VAL2 S181BT2,
       S181B.TOX_EQ_VAL3 S181BT3,
       S181B.TOX_EQ_VAL4 S181BT4,
       S181B.TOX_EQ_VAL5 S181BT5,
       S181B.TOX_EQ_VAL6 S181BT6,
       S181B.TOX_EQ_VAL7 S181BT7,
       S181B.TOX_EQ_VAL8 S181BT8,
       S181B.TOX_EQ_VAL9 S181BT9,
       S181B.TOX_EQ_VAL10 S181BT10,
       S181B.TOX_EQ_VAL11 S181BT11,
       S181B.TOX_EQ_VAL12 S181BT12,
       S181B.TOX_EQ_VAL13 S181BT13,
       S181B.TOX_EQ_VAL14 S181BT14,
       S181B.TOX_EQ_VAL15 S181BT15,
       S181B.TOX_EQ_VAL16 S181BT16,
       S181B.TOX_EQ_VAL17 S181BT17,

       S181C.TOX_EQ_NA_IND S181CNA,
       S181C.TOX_EQ_VAL1 S181CT1,
       S181C.TOX_EQ_VAL2 S181CT2,
       S181C.TOX_EQ_VAL3 S181CT3,
       S181C.TOX_EQ_VAL4 S181CT4,
       S181C.TOX_EQ_VAL5 S181CT5,
       S181C.TOX_EQ_VAL6 S181CT6,
       S181C.TOX_EQ_VAL7 S181CT7,
       S181C.TOX_EQ_VAL8 S181CT8,
       S181C.TOX_EQ_VAL9 S181CT9,
       S181C.TOX_EQ_VAL10 S181CT10,
       S181C.TOX_EQ_VAL11 S181CT11,
       S181C.TOX_EQ_VAL12 S181CT12,
       S181C.TOX_EQ_VAL13 S181CT13,
       S181C.TOX_EQ_VAL14 S181CT14,
       S181C.TOX_EQ_VAL15 S181CT15,
       S181C.TOX_EQ_VAL16 S181CT16,
       S181C.TOX_EQ_VAL17 S181CT17,

       S181D.TOX_EQ_NA_IND S181DNA,
       S181D.TOX_EQ_VAL1 S181DT1,
       S181D.TOX_EQ_VAL2 S181DT2,
       S181D.TOX_EQ_VAL3 S181DT3,
       S181D.TOX_EQ_VAL4 S181DT4,
       S181D.TOX_EQ_VAL5 S181DT5,
       S181D.TOX_EQ_VAL6 S181DT6,
       S181D.TOX_EQ_VAL7 S181DT7,
       S181D.TOX_EQ_VAL8 S181DT8,
       S181D.TOX_EQ_VAL9 S181DT9,
       S181D.TOX_EQ_VAL10 S181DT10,
       S181D.TOX_EQ_VAL11 S181DT11,
       S181D.TOX_EQ_VAL12 S181DT12,
       S181D.TOX_EQ_VAL13 S181DT13,
       S181D.TOX_EQ_VAL14 S181DT14,
       S181D.TOX_EQ_VAL15 S181DT15,
       S181D.TOX_EQ_VAL16 S181DT16,
       S181D.TOX_EQ_VAL17 S181DT17,

       S182.TOX_EQ_NA_IND S182NA,
       S182.TOX_EQ_VAL1 S182T1,
       S182.TOX_EQ_VAL2 S182T2,
       S182.TOX_EQ_VAL3 S182T3,
       S182.TOX_EQ_VAL4 S182T4,
       S182.TOX_EQ_VAL5 S182T5,
       S182.TOX_EQ_VAL6 S182T6,
       S182.TOX_EQ_VAL7 S182T7,
       S182.TOX_EQ_VAL8 S182T8,
       S182.TOX_EQ_VAL9 S182T9,
       S182.TOX_EQ_VAL10 S182T10,
       S182.TOX_EQ_VAL11 S182T11,
       S182.TOX_EQ_VAL12 S182T12,
       S182.TOX_EQ_VAL13 S182T13,
       S182.TOX_EQ_VAL14 S182T14,
       S182.TOX_EQ_VAL15 S182T15,
       S182.TOX_EQ_VAL16 S182T16,
       S182.TOX_EQ_VAL17 S182T17,

       S183.TOX_EQ_NA_IND S183NA,
       S183.TOX_EQ_VAL1 S183T1,
       S183.TOX_EQ_VAL2 S183T2,
       S183.TOX_EQ_VAL3 S183T3,
       S183.TOX_EQ_VAL4 S183T4,
       S183.TOX_EQ_VAL5 S183T5,
       S183.TOX_EQ_VAL6 S183T6,
       S183.TOX_EQ_VAL7 S183T7,
       S183.TOX_EQ_VAL8 S183T8,
       S183.TOX_EQ_VAL9 S183T9,
       S183.TOX_EQ_VAL10 S183T10,
       S183.TOX_EQ_VAL11 S183T11,
       S183.TOX_EQ_VAL12 S183T12,
       S183.TOX_EQ_VAL13 S183T13,
       S183.TOX_EQ_VAL14 S183T14,
       S183.TOX_EQ_VAL15 S183T15,
       S183.TOX_EQ_VAL16 S183T16,
       S183.TOX_EQ_VAL17 S183T17,

       S184.TOX_EQ_NA_IND S184NA,
       S184.TOX_EQ_VAL1 S184T1,
       S184.TOX_EQ_VAL2 S184T2,
       S184.TOX_EQ_VAL3 S184T3,
       S184.TOX_EQ_VAL4 S184T4,
       S184.TOX_EQ_VAL5 S184T5,
       S184.TOX_EQ_VAL6 S184T6,
       S184.TOX_EQ_VAL7 S184T7,
       S184.TOX_EQ_VAL8 S184T8,
       S184.TOX_EQ_VAL9 S184T9,
       S184.TOX_EQ_VAL10 S184T10,
       S184.TOX_EQ_VAL11 S184T11,
       S184.TOX_EQ_VAL12 S184T12,
       S184.TOX_EQ_VAL13 S184T13,
       S184.TOX_EQ_VAL14 S184T14,
       S184.TOX_EQ_VAL15 S184T15,
       S184.TOX_EQ_VAL16 S184T16,
       S184.TOX_EQ_VAL17 S184T17,

       S185.TOX_EQ_NA_IND S185NA,
       S185.TOX_EQ_VAL1 S185T1,
       S185.TOX_EQ_VAL2 S185T2,
       S185.TOX_EQ_VAL3 S185T3,
       S185.TOX_EQ_VAL4 S185T4,
       S185.TOX_EQ_VAL5 S185T5,
       S185.TOX_EQ_VAL6 S185T6,
       S185.TOX_EQ_VAL7 S185T7,
       S185.TOX_EQ_VAL8 S185T8,
       S185.TOX_EQ_VAL9 S185T9,
       S185.TOX_EQ_VAL10 S185T10,
       S185.TOX_EQ_VAL11 S185T11,
       S185.TOX_EQ_VAL12 S185T12,
       S185.TOX_EQ_VAL13 S185T13,
       S185.TOX_EQ_VAL14 S185T14,
       S185.TOX_EQ_VAL15 S185T15,
       S185.TOX_EQ_VAL16 S185T16,
       S185.TOX_EQ_VAL17 S185T17,

       S186.TOX_EQ_NA_IND S186NA,
       S186.TOX_EQ_VAL1 S186T1,
       S186.TOX_EQ_VAL2 S186T2,
       S186.TOX_EQ_VAL3 S186T3,
       S186.TOX_EQ_VAL4 S186T4,
       S186.TOX_EQ_VAL5 S186T5,
       S186.TOX_EQ_VAL6 S186T6,
       S186.TOX_EQ_VAL7 S186T7,
       S186.TOX_EQ_VAL8 S186T8,
       S186.TOX_EQ_VAL9 S186T9,
       S186.TOX_EQ_VAL10 S186T10,
       S186.TOX_EQ_VAL11 S186T11,
       S186.TOX_EQ_VAL12 S186T12,
       S186.TOX_EQ_VAL13 S186T13,
       S186.TOX_EQ_VAL14 S186T14,
       S186.TOX_EQ_VAL15 S186T15,
       S186.TOX_EQ_VAL16 S186T16,
       S186.TOX_EQ_VAL17 S186T17,

       S187.TOX_EQ_NA_IND S187NA,
       S187.TOX_EQ_VAL1 S187T1,
       S187.TOX_EQ_VAL2 S187T2,
       S187.TOX_EQ_VAL3 S187T3,
       S187.TOX_EQ_VAL4 S187T4,
       S187.TOX_EQ_VAL5 S187T5,
       S187.TOX_EQ_VAL6 S187T6,
       S187.TOX_EQ_VAL7 S187T7,
       S187.TOX_EQ_VAL8 S187T8,
       S187.TOX_EQ_VAL9 S187T9,
       S187.TOX_EQ_VAL10 S187T10,
       S187.TOX_EQ_VAL11 S187T11,
       S187.TOX_EQ_VAL12 S187T12,
       S187.TOX_EQ_VAL13 S187T13,
       S187.TOX_EQ_VAL14 S187T14,
       S187.TOX_EQ_VAL15 S187T15,
       S187.TOX_EQ_VAL16 S187T16,
       S187.TOX_EQ_VAL17 S187T17,

       R.TOX_EQ_NA_IND_ONETIME S188NA,
       R.TOX_EQ_VAL1_ONETIME S188T1,
       R.TOX_EQ_VAL2_ONETIME S188T2,
       R.TOX_EQ_VAL3_ONETIME S188T3,
       R.TOX_EQ_VAL4_ONETIME S188T4,
       R.TOX_EQ_VAL5_ONETIME S188T5,
       R.TOX_EQ_VAL6_ONETIME S188T6,
       R.TOX_EQ_VAL7_ONETIME S188T7,
       R.TOX_EQ_VAL8_ONETIME S188T8,
       R.TOX_EQ_VAL9_ONETIME S188T9,
       R.TOX_EQ_VAL10_ONETIME S188T10,
       R.TOX_EQ_VAL11_ONETIME S188T11,
       R.TOX_EQ_VAL12_ONETIME S188T12,
       R.TOX_EQ_VAL13_ONETIME S188T13,
       R.TOX_EQ_VAL14_ONETIME S188T14,
       R.TOX_EQ_VAL15_ONETIME S188T15,
       R.TOX_EQ_VAL16_ONETIME S188T16,
       R.TOX_EQ_VAL17_ONETIME S188T17

  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

       LEFT OUTER JOIN dbo.TRI_ONSITE_UIC_DISP_QTY S181A ON
                S181A.FK_GUID = R.PK_GUID
            AND S181A.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_ONSITE_DISP_QTY S181B ON
                S181B.FK_GUID = R.PK_GUID
            AND S181B.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_OFFSITE_UIC_DISP_QTY S181C ON
                S181C.FK_GUID = R.PK_GUID
            AND S181C.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_OFFSITE_DISP_QTY S181D ON
                S181D.FK_GUID = R.PK_GUID
            AND S181D.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_ONSITE_ENERGY_RCV_QTY S182 ON
                S182.FK_GUID = R.PK_GUID
            AND S182.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_OFFSITE_ENERGY_REC_QTY S183 ON
                S183.FK_GUID = R.PK_GUID
            AND S183.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_ONSITE_RECYCLED_Q S184 ON
                S184.FK_GUID = R.PK_GUID
            AND S184.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_OFFSITE_RECYCLED_Q S185 ON
                S185.FK_GUID = R.PK_GUID
            AND S185.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_ONSITE_TREATED_Q S186 ON
                S186.FK_GUID = R.PK_GUID
            AND S186.YEAR_OFFSET_ME = 0

       LEFT OUTER JOIN dbo.TRI_OFFSITE_TREATED_Q S187 ON
                S187.FK_GUID = R.PK_GUID
            AND S187.YEAR_OFFSET_ME = 0
'
GO
/****** Object:  View [dbo].[V_TRI_PG2_53]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG2_53]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG2_53]
(FK_GUID, STREAM, A, B, C, 
 NUM)
AS
SELECT   FK_GUID,
         STREAM,
         COALESCE (WASTE_Q_RANGE_CODE, WASTE_Q_ME) A,
         Q_BASIS_EST_CD B,
         RELEASE_STORM_WATER C,
         (SELECT COUNT (*)
            FROM TRI_ONSITE_RELEASE_Q REL2
           WHERE REL2.EI_MEDIUM_CODE = ''WATER''
             AND REL2.FK_GUID = REL.FK_GUID
             AND REL2.PK_GUID <= REL.PK_GUID) NUM
    FROM TRI_ONSITE_RELEASE_Q REL
   WHERE EI_MEDIUM_CODE = ''WATER''

'
GO
/****** Object:  View [dbo].[V_TRI_PG1_49]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG1_49]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG1_49]
(PK_GUID, R49, NUM)
AS
SELECT R.PK_GUID, NPDES_ID_CLBER R49,
	   (SELECT COUNT (*)
             FROM TRI_NPDES_ID FD2
            WHERE FD2.FK_GUID = FD.FK_GUID
              AND FD2.PK_GUID <= FD.PK_GUID) NUM
     FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
          INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
          INNER JOIN TRI_NPDES_ID FD ON FD.FK_GUID = F.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PG1_48]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG1_48]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG1_48]
(PK_GUID, R48, NUM)
AS
SELECT R.PK_GUID, RCRA_ID_CLBER R48,
	   (SELECT COUNT (*)
             FROM TRI_RCRA_ID FR2
            WHERE FR2.FK_GUID = FR.FK_GUID
              AND FR2.PK_GUID <= FR.PK_GUID) NUM
     FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
          INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
          INNER JOIN TRI_RCRA_ID FR ON FR.FK_GUID = F.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PG1_47]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG1_47]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG1_47]
(PK_GUID, R47, NUM)
AS
SELECT R.PK_GUID, FAC_DUN_CODE R47,
	   (SELECT COUNT (*)
             FROM TRI_FAC_DUN FD2
            WHERE FD2.FK_GUID = FD.FK_GUID
              AND FD2.PK_GUID <= FD.PK_GUID) NUM
     FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
          INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
          INNER JOIN TRI_FAC_DUN FD ON FD.FK_GUID = F.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PG1_410]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG1_410]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG1_410]
(PK_GUID, R410, NUM)
AS
SELECT R.PK_GUID, UIC_ID_CLBER R410,
	   (SELECT COUNT (*)
             FROM TRI_UIC_ID FD2
            WHERE FD2.FK_GUID = FD.FK_GUID
              AND FD2.PK_GUID <= FD.PK_GUID) NUM
     FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
          INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
          INNER JOIN TRI_UIC_ID FD ON FD.FK_GUID = F.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PAGE2]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE2]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE2]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R11, R12, R13, DIOXIN_DIST1, 
 DIOXIN_DIST2, DIOXIN_DIST3, DIOXIN_DIST4, DIOXIN_DIST5, DIOXIN_DIST6, 
 DIOXIN_DIST7, DIOXIN_DIST8, DIOXIN_DIST9, DIOXIN_DIST10, DIOXIN_DIST11, 
 DIOXIN_DIST12, DIOXIN_DIST13, DIOXIN_DIST14, DIOXIN_DIST15, DIOXIN_DIST16, 
 DIOXIN_DIST17, R31A, R31B, R31C, R31D, 
 R31E, R31F, R32A, R32B, R32C, 
 R32D, R32E, R33A, R33B, R33C, 
 R41, R51A, R51B, R51C, R52A, 
 R52B, R52C, R531STREAM, R531A, R531B, 
 R531C, R532STREAM, R532A, R532B, R532C, 
 R533STREAM, R533A, R533B, R533C)
AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       FAC_ID,
       CHEM_TXT,
       CAS_CLBER R11,
       CHEM_TXT R12,
       CHEM_MIXTURE_TXT R13,
       DIOXIN_DIST1,
       DIOXIN_DIST2,
       DIOXIN_DIST3,
       DIOXIN_DIST4,
       DIOXIN_DIST5,
       DIOXIN_DIST6,
       DIOXIN_DIST7,
       DIOXIN_DIST8,
       DIOXIN_DIST9,
       DIOXIN_DIST10,
       DIOXIN_DIST11,
       DIOXIN_DIST12,
       DIOXIN_DIST13,
       DIOXIN_DIST14,
       DIOXIN_DIST15,
       DIOXIN_DIST16,
       DIOXIN_DIST17,
       CHEM_PRODUCED_IND R31A,
       CHEM_IMPORTED_IND R31B,
       CHEM_USED_PROCED_ID R31C,
       CHEM_SALES_DIST_ID R31D,
       CHEM_BYPRODUCT_IND R31E,
       CHEM_MANUFACTURE_IMPURITY R31F,
       CHEM_REACTANT_IND R32A,
       CHEM_FORMULATION_COMP R32B,
       CHEM_ARTICLE_COMP_ID R32C,
       CHEM_REP_IND R32D,
       CHEM_PROC_IMPURITY_ID R32E,
       CHEM_PROCING_AID_ID R33A,
       CHEM_MANUFACTURE_AID_ID R33B,
       CHEM_ANC_USAGE_IND R33C,
       MAX_CHEM_AMOUNT_CODE R41,
       COALESCE (REL.WASTE_Q_RANGE_CODE, REL.WASTE_Q_ME) R51A,
       REL.Q_BASIS_EST_CD R51B,
       REL.RELEASE_STORM_WATER R51C,
       COALESCE (REL2.WASTE_Q_RANGE_CODE, REL2.WASTE_Q_ME) R52A,
       REL2.Q_BASIS_EST_CD R52B,
       REL2.RELEASE_STORM_WATER R52C,
	   R531.STREAM R531STREAM,
	   R531.A R531A,
	   R531.B R531B,
	   R531.C R531C,
   	   R532.STREAM R532STREAM,
	   R532.A R532A,
	   R532.B R532B,
	   R532.C R532C,
   	   R533.STREAM R533STREAM,
	   R533.A R533A,
	   R533.B R533B,
	   R533.C R533C
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL ON REL.FK_GUID = R.PK_GUID
                                              AND REL.EI_MEDIUM_CODE = ''AIR FUG''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL2 ON REL2.FK_GUID = R.PK_GUID
                                               AND REL2.EI_MEDIUM_CODE = ''AIR STACK''
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C FROM V_TRI_PG2_53 WHERE NUM = 1) R531 ON R531.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C FROM V_TRI_PG2_53 WHERE NUM = 2) R532 ON R532.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID, STREAM, A, B, C FROM V_TRI_PG2_53 WHERE NUM = 3) R533 ON R533.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PAGE1]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE1]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE1]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R0REVCD1, R0REVCD2, R0WITHDCD1, R0WITHDCD2, R1, R21, 
 R22, R31, R33, R41TRI_ID, R41NAME, 
 R41STREET, R41_CITYSTATE, R41MAIL_NAME, R41MAIL_STREET, R41MAILCITYSTATE, R41MAILCOUNTRY, 
 R42A, R42B, R42C, R42D, R43NAME, 
 R43EMAIL, R43TEL, R44NAME, R44TEL, R44EMAIL, R45A, 
 R45B, R45C, R45D, R45E, R45F, 
-- R46LATDEG, R46LATMIN, R46LATSEC, R46LONGDEG, R46LONGMIN, 
-- R46LONGSEC, 
R471, R472, 
-- R481, R482, 
-- R491, R492, R4101, R4102, 
R51, R52)

-- =================================================================================
-- Name:			V_TRI_PAGE1
-- Author:			Mark Chmarny
-- Create date:		??
-- Description:		Fills the fields on Form "R", Page 1
-- Change History:
-- TKC 6/10/2008:	Changed the logic for display of R22 so that it is conditional
--					on whether or not CHEM_TRADE_SECRET_IND = ''Y''
-- =================================================================================

AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       FAC_ID,
       CHEM_TXT,
       R.CHEM_RPT_REV_CD_1 R0REVCD1,
       R.CHEM_RPT_REV_CD_2 R0REVCD2,
       R.CHEM_RPT_WD_CD_1 R0WITHDCD1,
       R.CHEM_RPT_WD_CD_2 R0WITHDCD2,
       SUB_REP_YEAR R1,
       CHEM_TRADE_SECRET_IND R21,
       CASE CHEM_TRADE_SECRET_IND
           WHEN ''Y'' THEN SUB_SANITIZED_IND
           ELSE NULL
       END R22,
       ISNULL(CERTIFIER,'''') + '' '' + ISNULL(CERTIFIER_TIT_TXT,'''') AS R31,
       CERT_SIGNED_DATE R33,
       FAC_ID R41TRI_ID,
       FAC_SITE R41NAME,
       ISNULL(F.LOC_ADD_TXT,'''') + '' '' + ISNULL(F.SUPP_LOC_TXT,'''') R41STREET,
       ISNULL(F.LOCALITY,'''') + ''/'' + ISNULL(F.COUNTY,'''') + ''/'' + ISNULL(F.STATE,'''') + ''/'' + ISNULL(F.ADD_POSTAL_CODE,'''') R41_CITYSTATE,
       F.MAIL_FAC_SITE R41MAIL_NAME,
       ISNULL(F.MAIL_ADD_TXT,'''') + '' '' + ISNULL(F.SUPP_MAIL_ADD,'''') R41MAIL_STREET,
       ISNULL(F.MAIL_ADD_CITY,'''') + ''/'' + ISNULL(F.MAIL_ADD_STATE,'''') + ''/'' + ISNULL(F.MAIL_ADD_POSTAL_CODE,'''') R41MAILCITYSTATE,
       MAIL_ADD_COUNTRY R41MAILCOUNTRY,
       CASE SUB_PARTIAL_FAC_ID WHEN ''N'' THEN ''Y'' ELSE ''N'' END R42A,
       SUB_PARTIAL_FAC_ID R42B,
       SUB_FEDERAL_FAC_ID R42C,
       SUB_CO_FAC_INDIC R42D,
       TECH_CONT R43NAME,
       TECH_CONT_EMAIL_ADDRES R43EMAIL,
       TECH_CONT_PHONE_TXT R43TEL,
       PUB_CONT R44NAME,
       PUB_CONT_PHONE_TXT R44TEL,
       PUB_CONT_EMAIL_ADDRES R44EMAIL,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND = ''Primary''
           AND FK_GUID = F.PK_GUID) R45A,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> ''Primary'') = 1) R45B,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> ''Primary'') = 2) R45C,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> ''Primary'') = 3) R45D,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> ''Primary'') = 4) R45E,
       (SELECT FAC_NAICS
          FROM TRI_FAC_NAICS S
         WHERE NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS S2
                 WHERE S.FK_GUID = S2.FK_GUID
                   AND S2.PK_GUID <= S.PK_GUID
                   AND S2.NAICS_PRIMARY_IND <> ''Primary'') = 5) R45F,
--       LAT_DEGREE_ME R46LATDEG,
--       LAT_MINUTE_ME R46LATMIN,
--       LAT_SECOND_ME R46LATSEC,
--       LON_DEGREE_ME R46LONGDEG,
--       LON_MINUTE_ME R46LONGMIN,
--       LON_SECOND_ME R46LONGSEC,

	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R471,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R472,

--	   (SELECT R48 FROM V_TRI_PG1_48 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R481,
--	   (SELECT R48 FROM V_TRI_PG1_48 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R482,


--	   (SELECT R49 FROM V_TRI_PG1_49 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R491,
--	   (SELECT R49 FROM V_TRI_PG1_49 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R492,

--	   (SELECT R410 FROM V_TRI_PG1_410 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R4101,
--	   (SELECT R410 FROM V_TRI_PG1_410 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R4102,

       PARENT_COMPANY_TXT R51,
       PARENT_DUN_CODE R52
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_FORM_R_SHORT_XFR]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_FORM_R_SHORT_XFR]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_FORM_R_SHORT_XFR]

AS

SELECT

	TL.FK_GUID
,	COALESCE(TQ.WASTE_Q_RANGE_CODE, TQ.WASTE_Q_ME) AMT_LBS
,	TQ.WASTE_MANAGEMENT_CODE
,
	(
	SELECT COUNT(*)
	FROM
		TRI_TRANSFER_LOC TL2
		JOIN TRI_TRANSFER_Q TQ2 ON TQ2.FK_GUID = TL2.PK_GUID
	WHERE
		TL2.FK_GUID = TL.FK_GUID
		AND
		TQ2.PK_GUID >= TQ.PK_GUID
	) NUM

FROM TRI_TRANSFER_LOC TL
JOIN TRI_TRANSFER_Q TQ ON TQ.FK_GUID = TL.PK_GUID
WHERE TL.POTW_IND = ''N''
AND
	(
	TQ.WASTE_Q_RANGE_CODE IS NOT NULL
	OR
	TQ.WASTE_Q_ME IS NOT NULL
	)
'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG3_62]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG3_62]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG3_62]

AS
SELECT
       R.[PK_GUID]
      ,
		(
		SELECT COUNT(*)
		FROM TRI_TRANSFER_LOC T2
		WHERE T2.FK_GUID = T.FK_GUID
		AND T2.POTW_IND = ''N''
		AND T2.TRANSFER_LOC_SEQ_CL <= T.TRANSFER_LOC_SEQ_CL
		) LOC_NUM
      ,T.[TRANSFER_LOC_SEQ_CL]
      ,[TOX_EQ_VAL1]
      ,[TOX_EQ_VAL2]
      ,[TOX_EQ_VAL3]
      ,[TOX_EQ_VAL4]
      ,[TOX_EQ_VAL5]
      ,[TOX_EQ_VAL6]
      ,[TOX_EQ_VAL7]
      ,[TOX_EQ_VAL8]
      ,[TOX_EQ_VAL9]
      ,[TOX_EQ_VAL10]
      ,[TOX_EQ_VAL11]
      ,[TOX_EQ_VAL12]
      ,[TOX_EQ_VAL13]
      ,[TOX_EQ_VAL14]
      ,[TOX_EQ_VAL15]
      ,[TOX_EQ_VAL16]
      ,[TOX_EQ_VAL17]
      ,[TOX_EQ_NA_IND]
,
       (SELECT COUNT (*)
          FROM TRI_TRANSFER_Q TQ2
         WHERE TQ2.FK_GUID = TQ.FK_GUID
           AND TQ2.PK_GUID <= TQ.PK_GUID) NUM
FROM TRI_REPORT R 
LEFT OUTER JOIN TRI_TRANSFER_LOC T ON T.FK_GUID = R.PK_GUID
LEFT OUTER JOIN TRI_TRANSFER_Q TQ ON TQ.FK_GUID = T.PK_GUID
WHERE POTW_IND = ''N''

'
GO
/****** Object:  View [dbo].[V_TRI_PG4_7A]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG4_7A]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG4_7A]
(FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, 
 R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, 
 R7AC, R7AD, R7AE, NUM)
AS
SELECT

	FK_GUID
,	R7AA
,	CASE WHEN R7AB0 IS NULL THEN R7AB1 ELSE R7AB0 END AS R7AB1
,	CASE WHEN R7AB0 IS NULL THEN R7AB2 ELSE R7AB1 END AS R7AB2
,	CASE WHEN R7AB0 IS NULL THEN R7AB3 ELSE R7AB2 END AS R7AB3
,	CASE WHEN R7AB0 IS NULL THEN R7AB4 ELSE R7AB3 END AS R7AB4
,	CASE WHEN R7AB0 IS NULL THEN R7AB5 ELSE R7AB4 END AS R7AB5
,	CASE WHEN R7AB0 IS NULL THEN R7AB6 ELSE R7AB5 END AS R7AB6
,	CASE WHEN R7AB0 IS NULL THEN R7AB7 ELSE R7AB6 END AS R7AB7
,	CASE WHEN R7AB0 IS NULL THEN R7AB8 ELSE R7AB7 END AS R7AB8
,	R7AC
,	R7AD
,	R7AE
,	NUM

FROM
(
SELECT W.FK_GUID,
       WASTE_STREAM_TYPE_CODE R7AA,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 0) R7AB0,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 1) R7AB1,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 2) R7AB2,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 3) R7AB3,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 4) R7AB4,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 5) R7AB5,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 6) R7AB6,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 7) R7AB7,
	   (SELECT WASTE_TREAT_METH_CODE  FROM TRI_WASTE_TREAT_METH WM WHERE WM.FK_GUID = W.PK_GUID AND WASTE_TREAT_SEQ_CL = 8) R7AB8,
       INFLUENT_CONC_RANGE_C R7AC,
--       TREAT_EFF_EST_PCT R7AD,
       TREAT_EFF_RANGE_CD R7AD,
       OPERATING_DATA_IND R7AE,
	   (SELECT COUNT(*) FROM TRI_WASTE_TREAT_DTL W2 WHERE W2.FK_GUID = W.FK_GUID AND W2.PK_GUID <= W.PK_GUID) NUM
  FROM TRI_REPORT R
       INNER JOIN TRI_WASTE_TREAT_DTL W ON W.FK_GUID = R.PK_GUID
) AS G1

'
GO
/****** Object:  View [dbo].[V_TRI_PG4_62L]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG4_62L]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG4_62L]
(FK_GUID, R62A, R62B, R62C, NUM)
AS
SELECT TQ.FK_GUID,
       COALESCE (TQ.WASTE_Q_ME, TQ.WASTE_Q_RANGE_CODE) R62A,
       TQ.Q_BASIS_EST_CODE R62B,
       TQ.WASTE_MANAGEMENT_CODE R62C,
       (SELECT COUNT (*)
          FROM TRI_TRANSFER_Q TQ2
         WHERE TQ2.FK_GUID = TQ.FK_GUID
           AND TQ2.PK_GUID <= TQ.PK_GUID) NUM
FROM TRI_REPORT R 
LEFT OUTER JOIN TRI_TRANSFER_LOC T ON T.FK_GUID = R.PK_GUID
LEFT OUTER JOIN TRI_TRANSFER_Q TQ ON TQ.FK_GUID = T.PK_GUID
WHERE POTW_IND = ''N''

'
GO
/****** Object:  View [dbo].[V_TRI_PAGE3_XFR]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE3_XFR]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE3_XFR]

AS

SELECT TOP 100 PERCENT
	S.PK_GUID AS PK_GUID_SUB
,	R.PK_GUID AS PK_GUID_REP
--,	F.FAC_ID
--,	C.CHEM_TXT
--,	TL.TRANSFER_LOC_SEQ_CL
,	TL.RCRA_ID_CLBER as R62RCRAID
,	TL.FAC_SITE as R62NAME
,	TL.LOC_ADD_TXT as R62ADDRESS
,	TL.LOCALITY as R62CITY
,	TL.STATE as R62STATE
,	TL.COUNTY as R62COUNTY
,	TL.ADD_POSTAL_CODE as R62ZIP
,	TL.CONTROLLED_LOC_IND as R62LOCATIONCONTROL
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62A ELSE '''' END) AS R62A1
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62B ELSE '''' END) AS R62B1
,	MAX(CASE WHEN XFR.NUM = 1 THEN XFR.R62C ELSE '''' END) AS R62C1
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62A ELSE '''' END) AS R62A2
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62B ELSE '''' END) AS R62B2
,	MAX(CASE WHEN XFR.NUM = 2 THEN XFR.R62C ELSE '''' END) AS R62C2
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62A ELSE '''' END) AS R62A3
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62B ELSE '''' END) AS R62B3
,	MAX(CASE WHEN XFR.NUM = 3 THEN XFR.R62C ELSE '''' END) AS R62C3
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62A ELSE '''' END) AS R62A4
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62B ELSE '''' END) AS R62B4
,	MAX(CASE WHEN XFR.NUM = 4 THEN XFR.R62C ELSE '''' END) AS R62C4

FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN dbo.TRI_TRANSFER_LOC TL ON TL.FK_GUID = R.PK_GUID
LEFT JOIN
	(
	SELECT
		TQ.FK_GUID
	,	TQ.TRANSFER_SEQ_CLBER
	,	COALESCE(TQ.WASTE_Q_ME, TQ.WASTE_Q_RANGE_CODE) R62A
	,	TQ.Q_BASIS_EST_CODE R62B
	,	TQ.WASTE_MANAGEMENT_CODE R62C
	,	(
		SELECT COUNT(*)
		FROM dbo.TRI_TRANSFER_Q TQ2
		WHERE
			TQ2.FK_GUID = TQ.FK_GUID
		AND
			TQ2.PK_GUID <= TQ.PK_GUID
		) AS NUM
	FROM dbo.TRI_TRANSFER_Q TQ
	) AS XFR

ON XFR.FK_GUID = TL.PK_GUID

WHERE TL.POTW_IND = ''N''

GROUP BY
	S.PK_GUID
,	R.PK_GUID
--,	F.FAC_ID
--,	C.CHEM_TXT
,	CAST(TL.TRANSFER_LOC_SEQ_CL AS INT)
,	TL.RCRA_ID_CLBER
,	TL.FAC_SITE
,	TL.LOC_ADD_TXT
,	TL.LOCALITY
,	TL.STATE
,	TL.COUNTY
,	TL.ADD_POSTAL_CODE
,	TL.CONTROLLED_LOC_IND

ORDER BY CAST(TL.TRANSFER_LOC_SEQ_CL AS INT)

'
GO
/****** Object:  View [dbo].[V_TRI_PG5_810A]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG5_810A]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG5_810A]
AS
SELECT FK_GUID, SRC_RED_METH_CODE, 
	(SELECT COUNT(*) NUM FROM TRI_SRC_RED_METH_CD M2 WHERE M2.FK_GUID = M.FK_GUID AND M.SRC_RED_METH_CODE < M2.SRC_RED_METH_CODE) + 1 NUM
FROM TRI_SRC_RED_METH_CD M

'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG1]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG1]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG1]

AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       FAC_ID,
       CHEM_TXT,

       REL.TOX_EQ_NA_IND S151NA,
       REL.TOX_EQ_VAL1 S151T1,
       REL.TOX_EQ_VAL2 S151T2,
       REL.TOX_EQ_VAL3 S151T3,
       REL.TOX_EQ_VAL4 S151T4,
       REL.TOX_EQ_VAL5 S151T5,
       REL.TOX_EQ_VAL6 S151T6,
       REL.TOX_EQ_VAL7 S151T7,
       REL.TOX_EQ_VAL8 S151T8,
       REL.TOX_EQ_VAL9 S151T9,
       REL.TOX_EQ_VAL10 S151T10,
       REL.TOX_EQ_VAL11 S151T11,
       REL.TOX_EQ_VAL12 S151T12,
       REL.TOX_EQ_VAL13 S151T13,
       REL.TOX_EQ_VAL14 S151T14,
       REL.TOX_EQ_VAL15 S151T15,
       REL.TOX_EQ_VAL16 S151T16,
       REL.TOX_EQ_VAL17 S151T17,

       REL2.TOX_EQ_NA_IND S152NA,
       REL2.TOX_EQ_VAL1 S152T1,
       REL2.TOX_EQ_VAL2 S152T2,
       REL2.TOX_EQ_VAL3 S152T3,
       REL2.TOX_EQ_VAL4 S152T4,
       REL2.TOX_EQ_VAL5 S152T5,
       REL2.TOX_EQ_VAL6 S152T6,
       REL2.TOX_EQ_VAL7 S152T7,
       REL2.TOX_EQ_VAL8 S152T8,
       REL2.TOX_EQ_VAL9 S152T9,
       REL2.TOX_EQ_VAL10 S152T10,
       REL2.TOX_EQ_VAL11 S152T11,
       REL2.TOX_EQ_VAL12 S152T12,
       REL2.TOX_EQ_VAL13 S152T13,
       REL2.TOX_EQ_VAL14 S152T14,
       REL2.TOX_EQ_VAL15 S152T15,
       REL2.TOX_EQ_VAL16 S152T16,
       REL2.TOX_EQ_VAL17 S152T17,

       S1531.TOX_EQ_NA_IND S1531NA,
       S1531.TOX_EQ_VAL1 S1531T1,
       S1531.TOX_EQ_VAL2 S1531T2,
       S1531.TOX_EQ_VAL3 S1531T3,
       S1531.TOX_EQ_VAL4 S1531T4,
       S1531.TOX_EQ_VAL5 S1531T5,
       S1531.TOX_EQ_VAL6 S1531T6,
       S1531.TOX_EQ_VAL7 S1531T7,
       S1531.TOX_EQ_VAL8 S1531T8,
       S1531.TOX_EQ_VAL9 S1531T9,
       S1531.TOX_EQ_VAL10 S1531T10,
       S1531.TOX_EQ_VAL11 S1531T11,
       S1531.TOX_EQ_VAL12 S1531T12,
       S1531.TOX_EQ_VAL13 S1531T13,
       S1531.TOX_EQ_VAL14 S1531T14,
       S1531.TOX_EQ_VAL15 S1531T15,
       S1531.TOX_EQ_VAL16 S1531T16,
       S1531.TOX_EQ_VAL17 S1531T17,

       S1532.TOX_EQ_NA_IND S1532NA,
       S1532.TOX_EQ_VAL1 S1532T1,
       S1532.TOX_EQ_VAL2 S1532T2,
       S1532.TOX_EQ_VAL3 S1532T3,
       S1532.TOX_EQ_VAL4 S1532T4,
       S1532.TOX_EQ_VAL5 S1532T5,
       S1532.TOX_EQ_VAL6 S1532T6,
       S1532.TOX_EQ_VAL7 S1532T7,
       S1532.TOX_EQ_VAL8 S1532T8,
       S1532.TOX_EQ_VAL9 S1532T9,
       S1532.TOX_EQ_VAL10 S1532T10,
       S1532.TOX_EQ_VAL11 S1532T11,
       S1532.TOX_EQ_VAL12 S1532T12,
       S1532.TOX_EQ_VAL13 S1532T13,
       S1532.TOX_EQ_VAL14 S1532T14,
       S1532.TOX_EQ_VAL15 S1532T15,
       S1532.TOX_EQ_VAL16 S1532T16,
       S1532.TOX_EQ_VAL17 S1532T17,

       S1533.TOX_EQ_NA_IND S1533NA,
       S1533.TOX_EQ_VAL1 S1533T1,
       S1533.TOX_EQ_VAL2 S1533T2,
       S1533.TOX_EQ_VAL3 S1533T3,
       S1533.TOX_EQ_VAL4 S1533T4,
       S1533.TOX_EQ_VAL5 S1533T5,
       S1533.TOX_EQ_VAL6 S1533T6,
       S1533.TOX_EQ_VAL7 S1533T7,
       S1533.TOX_EQ_VAL8 S1533T8,
       S1533.TOX_EQ_VAL9 S1533T9,
       S1533.TOX_EQ_VAL10 S1533T10,
       S1533.TOX_EQ_VAL11 S1533T11,
       S1533.TOX_EQ_VAL12 S1533T12,
       S1533.TOX_EQ_VAL13 S1533T13,
       S1533.TOX_EQ_VAL14 S1533T14,
       S1533.TOX_EQ_VAL15 S1533T15,
       S1533.TOX_EQ_VAL16 S1533T16,
       S1533.TOX_EQ_VAL17 S1533T17

  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL ON REL.FK_GUID = R.PK_GUID
                                              AND REL.EI_MEDIUM_CODE = ''AIR FUG''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL2 ON REL2.FK_GUID = R.PK_GUID
                                               AND REL2.EI_MEDIUM_CODE = ''AIR STACK''
       LEFT OUTER JOIN (
						SELECT [FK_GUID]
							  ,[TOX_EQ_VAL1]
							  ,[TOX_EQ_VAL2]
							  ,[TOX_EQ_VAL3]
							  ,[TOX_EQ_VAL4]
							  ,[TOX_EQ_VAL5]
							  ,[TOX_EQ_VAL6]
							  ,[TOX_EQ_VAL7]
							  ,[TOX_EQ_VAL8]
							  ,[TOX_EQ_VAL9]
							  ,[TOX_EQ_VAL10]
							  ,[TOX_EQ_VAL11]
							  ,[TOX_EQ_VAL12]
							  ,[TOX_EQ_VAL13]
							  ,[TOX_EQ_VAL14]
							  ,[TOX_EQ_VAL15]
							  ,[TOX_EQ_VAL16]
							  ,[TOX_EQ_VAL17]
							  ,[TOX_EQ_NA_IND]
							  ,[NUM]
						  FROM [dbo].[V_FORM_S1_PG1_53]
						WHERE NUM = 1) S1531 ON S1531.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (
						SELECT [FK_GUID]
							  ,[TOX_EQ_VAL1]
							  ,[TOX_EQ_VAL2]
							  ,[TOX_EQ_VAL3]
							  ,[TOX_EQ_VAL4]
							  ,[TOX_EQ_VAL5]
							  ,[TOX_EQ_VAL6]
							  ,[TOX_EQ_VAL7]
							  ,[TOX_EQ_VAL8]
							  ,[TOX_EQ_VAL9]
							  ,[TOX_EQ_VAL10]
							  ,[TOX_EQ_VAL11]
							  ,[TOX_EQ_VAL12]
							  ,[TOX_EQ_VAL13]
							  ,[TOX_EQ_VAL14]
							  ,[TOX_EQ_VAL15]
							  ,[TOX_EQ_VAL16]
							  ,[TOX_EQ_VAL17]
							  ,[TOX_EQ_NA_IND]
							  ,[NUM]
						  FROM [dbo].[V_FORM_S1_PG1_53]
						WHERE NUM = 2) S1532 ON S1532.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (
						SELECT [FK_GUID]
							  ,[TOX_EQ_VAL1]
							  ,[TOX_EQ_VAL2]
							  ,[TOX_EQ_VAL3]
							  ,[TOX_EQ_VAL4]
							  ,[TOX_EQ_VAL5]
							  ,[TOX_EQ_VAL6]
							  ,[TOX_EQ_VAL7]
							  ,[TOX_EQ_VAL8]
							  ,[TOX_EQ_VAL9]
							  ,[TOX_EQ_VAL10]
							  ,[TOX_EQ_VAL11]
							  ,[TOX_EQ_VAL12]
							  ,[TOX_EQ_VAL13]
							  ,[TOX_EQ_VAL14]
							  ,[TOX_EQ_VAL15]
							  ,[TOX_EQ_VAL16]
							  ,[TOX_EQ_VAL17]
							  ,[TOX_EQ_NA_IND]
							  ,[NUM]
						  FROM [dbo].[V_FORM_S1_PG1_53]
						WHERE NUM = 3) S1533 ON S1533.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_FORM_A_PG_1]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_A_PG_1]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_A_PG_1]

-- =================================================================================
-- Full Name:		V_TRI_FORM_A_PAGE_1
-- Condensed Name:	V_FORM_A_PG_1
-- Author:			TK Conrad
-- Create date:		2007-05-18
-- Description:		Fills the fields on Form "A", Page 1
-- Change History:
-- TKC 6/10/2008:	Changed the logic for display of A22 so that it is conditional
--					on whether or not CHEM_TRADE_SECRET_IND = ''Y''
-- =================================================================================

AS
SELECT DISTINCT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       UPPER(F.FAC_ID) FAC_ID,
       R.REVISION_IND A0,
       R.CHEM_RPT_REV_CD_1 A0REVCD1,
       R.CHEM_RPT_REV_CD_2 A0REVCD2,
       R.CHEM_RPT_WD_CD_1 A0WITHDCD1,
       R.CHEM_RPT_WD_CD_2 A0WITHDCD2,
       R.SUB_REP_YEAR A1,
       R.CHEM_TRADE_SECRET_IND A21,
       CASE R.CHEM_TRADE_SECRET_IND
            WHEN ''Y'' THEN R.SUB_SANITIZED_IND
            ELSE NULL
       END A22,
       R.CERTIFIER + '' '' + R.CERTIFIER_TIT_TXT AS A31,
       R.CERT_SIGNED_DATE A33,
       UPPER(F.FAC_ID) A41TRI_ID,
       F.FAC_SITE A41NAME,
       ISNULL(F.LOC_ADD_TXT,'''') + '' '' + ISNULL(F.SUPP_LOC_TXT,'''') A41STREET,
       ISNULL(F.LOCALITY,'''') + ''/'' + ISNULL(F.COUNTY,'''') + ''/'' + ISNULL(F.STATE,'''') + ''/'' + ISNULL(F.ADD_POSTAL_CODE,'''') A41_CITYSTATE,
       F.MAIL_FAC_SITE A41MAIL_NAME,
       ISNULL(F.MAIL_ADD_TXT,'''') + '' '' + ISNULL(F.SUPP_MAIL_ADD,'''') A41MAIL_STREET,
       ISNULL(F.MAIL_ADD_CITY,'''') + ''/'' + ISNULL(F.MAIL_ADD_STATE,'''') + ''/'' + ISNULL(F.MAIL_ADD_POSTAL_CODE,'''') A41MAILCITYSTATE,
       F.MAIL_ADD_COUNTRY A41MAILCOUNTRY,
--       SUB_ENTIRE_FAC_IND R42A,
--       SUB_PARTIAL_FAC_ID R42B,
       R.SUB_FEDERAL_FAC_ID A42C,
       R.SUB_CO_FAC_INDIC A42D,
       R.TECH_CONT A43NAME,
       CASE WHEN R.TECH_CONT_EMAIL_ADDRES = ''NA'' THEN ''NA'' ELSE LOWER(R.TECH_CONT_EMAIL_ADDRES) END A43EMAIL,
       R.TECH_CONT_PHONE_TXT A43TEL,
       PUB_CONT A44NAME,
       PUB_CONT_PHONE_TXT A44TEL,
       R.PUB_CONT_EMAIL_ADDRES A44EMAIL,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND = ''Primary''
           AND N.FK_GUID = F.PK_GUID) A45A,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> ''Primary'') = 1) A45B,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> ''Primary'') = 2) A45C,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> ''Primary'') = 3) A45D,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> ''Primary'') = 4) A45E,
       (SELECT N.FAC_NAICS
          FROM TRI_FAC_NAICS N
         WHERE N.NAICS_PRIMARY_IND <> ''Primary''
           AND FK_GUID = F.PK_GUID
           AND (SELECT COUNT (*)
                  FROM TRI_FAC_NAICS N2
                 WHERE N.FK_GUID = N2.FK_GUID
                   AND N2.PK_GUID <= N.PK_GUID
                   AND N2.NAICS_PRIMARY_IND <> ''Primary'') = 5) A45F,
--       LAT_DEGREE_ME R46LATDEG,
--       LAT_MINUTE_ME R46LATMIN,
--       LAT_SECOND_ME R46LATSEC,
--       LON_DEGREE_ME R46LONGDEG,
--       LON_MINUTE_ME R46LONGMIN,
--       LON_SECOND_ME R46LONGSEC,

	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) A47A,
	   (SELECT R47 FROM V_TRI_PG1_47 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) A47B,

--	   (SELECT R48 FROM V_TRI_PG1_48 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R481,
--	   (SELECT R48 FROM V_TRI_PG1_48 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R482,


--	   (SELECT R49 FROM V_TRI_PG1_49 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R491,
--	   (SELECT R49 FROM V_TRI_PG1_49 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R492,

--	   (SELECT R410 FROM V_TRI_PG1_410 M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R4101,
--	   (SELECT R410 FROM V_TRI_PG1_410 M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R4102,

       F.PARENT_COMPANY_TXT A51,
       F.PARENT_DUN_CODE A52
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_EXT_MASTER_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_MASTER_D]'))
EXEC dbo.sp_executesql @statement = N'
/* =============================================
 Full Name:		V_EXTRACT_TRI_MASTER
 Condensed Name:	V_EXT_MASTER_D
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Provides source information for other extacts. Results in pounds.*/
CREATE VIEW [dbo].[V_EXT_MASTER_D]
AS
SELECT     C.CAS_CLBER AS CAS_NUMBER, C.CHEM_TXT AS CHEMICAL_NAME_TEXT, F.PK_GUID AS PK_GUID_FAC, C.PK_GUID AS PK_GUID_CHEM, 
                      F.FK_GUID AS FK_GUID_FAC, R.SUB_PARTIAL_FAC_ID AS SUBMISSION_PARTIAL_FACILITY_ID, R.PK_GUID AS PK_GUID_REPORT, 
                      R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR, 
                      CASE dbo.TRI_CalculateRevisionIndicator(R.PK_GUID)
							WHEN 1 THEN ''Y''
							ELSE ''N''
						END AS REVISION_INDICATOR, R.REPORT_TYPE_CODE AS REPORT_TYPE, 
                      UPPER(F.FAC_ID) AS TRIFID, FI.EPA_ID, FI.FS_ID, FI.Comment_DS AS FACILITY_IDENTIFICATION_COMMENT, FI.Inactive_DT AS INACTIVE_DATE, 
                      T.AgencyName, F.FAC_SITE AS FAC_NAME, F.LOC_ADD_TXT AS LOC_ADD_LINE_1_DS, F.SUPP_LOC_TXT AS LOC_ADD_LINE_2_DS, 
                      F.LOCALITY AS CITY_NM, F.COUNTY AS COUNTY_NM, F.ADD_POSTAL_CODE AS ZIP_CD,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air stack'')) AS AIR_POINT,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air fug'')) AS AIR_NON_POINT,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''land trea'')) AS LAND_TREA,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth disp'')) AS LAND_OTH_DISP,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''rcra c'')) AS LAND_RCRA_C,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3a'')) AS LAND_SI_5_5_3_A,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth landf'')) AS LAND_OTH_LANDF,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3b'')) AS LAND_SI_5_5_3_B,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj i'')) AS UNINJ_I,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj iiv'')) AS UNINJ_IIV,
                          (SELECT     CONVERT(VARCHAR(100), SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END))) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''water'')) AS WATER,
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID)) AS TOTAL, dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) 
                      AS POTW_WASTE_QUANTITY_MEASURE,
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN OFSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(OFSR.WASTE_Q_ME, OFSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_TRANSFER_Q AS OFSR INNER JOIN
                                                   dbo.TRI_TRANSFER_LOC AS TL ON OFSR.FK_GUID = TL.PK_GUID
                            WHERE      (TL.FK_GUID = R.PK_GUID)) AS TOTAL_OFFSITE_WASTE_QUANTITY, R.ONE_TIME_RELEASE_Q AS ONE_TIME_RELEASE_QUANTITY, 
                      R.PRODUCTION_RATIO_ME AS PRODUCTION_RATIO_MEASURE, F.PROVINCE_TXT AS MAIL_PROVINCE_NM, 
                      F.MAIL_ADD_COUNTRY AS MAIL_COUNTRY_NM, F.MAIL_ADD_COUNTRY_CODE AS MAIL_COUNTRY_CD, 
                      F.MAIL_ADD_TXT AS MAIL_ADD_LINE_1_DS, F.SUPP_MAIL_ADD AS MAIL_ADD_LINE_2_DS, F.MAIL_ADD_CITY AS MAIL_CITY_NM, 
                      F.MAIL_ADD_POSTAL_CODE AS MAIL_ZIP_CD, F.MAIL_ADD_STATE AS MAIL_STATE_CD, R.PUB_CONT AS PUBLIC_CONTACT_NM, 
                      R.PUB_CONT_PHONE_TXT AS PUBLIC_PHONE_NR, LOWER(R.PUB_CONT_EMAIL_ADDRES) AS PUBLIC_EMAIL, 
                      R.TECH_CONT AS TECH_CONTACT_NM, R.TECH_CONT_PHONE_TXT AS TECH_PHONE_NR, LOWER(R.TECH_CONT_EMAIL_ADDRES) AS TECH_EMAIL,
                       N.FAC_NAICS AS FAC_NAICS_PRIMARY, F.MAIL_FAC_SITE AS MAIL_NAME, R.PK_GUID AS FK_GUID_REPORT, C.FK_GUID AS FK_GUID_CHEM, 
                      CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS SIGNED_DT, R.FK_GUID AS REPORT_FK, C.FK_GUID AS CHEM_FK, 
                      dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C) AS REPORT_EPA_PROCESSING_STATUS_CD, 
                      CTYREG.EcologyRegion AS ECOLOGY_REGION, R.CHEM_RPT_REV_CD_1, R.CHEM_RPT_REV_CD_2, R.CHEM_RPT_WD_CD_1, 
                      R.CHEM_RPT_WD_CD_2
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '''') <> ''5''
AND
C.CAS_CLBER = ''N150''
AND 
D.TRIFID_DELETE_ID IS NULL
AND T.Inactive_DT IS NULL
AND
(
R.SUB_PARTIAL_FAC_ID = ''Y''
OR
	(
	R.SUB_PARTIAL_FAC_ID = ''N''
	AND
	S.INSERTED_DATE =
							  (SELECT     MAX(S2.INSERTED_DATE)
								FROM          dbo.TRI_SUB AS S2 INNER JOIN
													   dbo.TRI_FAC AS F2 ON F2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_REPORT AS R2 ON R2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_CHEM AS C2 ON C2.FK_GUID = R2.PK_GUID
								WHERE      (F2.FAC_ID = F.FAC_ID) AND (R2.SUB_REP_YEAR = R.SUB_REP_YEAR) AND (C2.CAS_CLBER = C.CAS_CLBER) AND 
													   (C2.CHEM_TXT = C.CHEM_TXT)
							   )
	AND
			(
			dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 1
			OR
				(
				dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 0
				AND NOT EXISTS
					(
					SELECT * FROM TRI_REPORT R3
					JOIN TRI_CHEM C3 ON C3.FK_GUID = R3.PK_GUID
					WHERE
					C3.CHEM_TXT = C.CHEM_TXT
					AND
					R3.FK_GUID = R.FK_GUID
					AND
					dbo.TRI_CalculateRevisionIndicator(R3.PK_GUID) = 1
					)
				)
			)
	)
)

'
GO
/****** Object:  View [dbo].[V_EXT_MASTER]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_MASTER]'))
EXEC dbo.sp_executesql @statement = N'
/* =============================================
 Full Name:		V_EXTRACT_TRI_MASTER
 Condensed Name:	V_EXT_MASTER
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Provides source information for other extacts. Results in pounds.*/
CREATE VIEW [dbo].[V_EXT_MASTER]
AS
SELECT     C.CAS_CLBER AS CAS_NUMBER, C.CHEM_TXT AS CHEMICAL_NAME_TEXT, F.PK_GUID AS PK_GUID_FAC, C.PK_GUID AS PK_GUID_CHEM, 
                      F.FK_GUID AS FK_GUID_FAC, R.SUB_PARTIAL_FAC_ID AS SUBMISSION_PARTIAL_FACILITY_ID, R.PK_GUID AS PK_GUID_REPORT, 
                      R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR, 
                      CASE dbo.TRI_CalculateRevisionIndicator(R.PK_GUID)
							WHEN 1 THEN ''Y''
							ELSE ''N''
						END AS REVISION_INDICATOR, R.REPORT_TYPE_CODE AS REPORT_TYPE, 
                      UPPER(F.FAC_ID) AS TRIFID, FI.EPA_ID, FI.FS_ID, FI.Comment_DS AS FACILITY_IDENTIFICATION_COMMENT, FI.Inactive_DT AS INACTIVE_DATE, 
                      T.AgencyName, F.FAC_SITE AS FAC_NAME, F.LOC_ADD_TXT AS LOC_ADD_LINE_1_DS, F.SUPP_LOC_TXT AS LOC_ADD_LINE_2_DS, 
                      F.LOCALITY AS CITY_NM, F.COUNTY AS COUNTY_NM, F.ADD_POSTAL_CODE AS ZIP_CD,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air stack'')) AS AIR_POINT,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air fug'')) AS AIR_NON_POINT,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''land trea'')) AS LAND_TREA,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth disp'')) AS LAND_OTH_DISP,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''rcra c'')) AS LAND_RCRA_C,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3a'')) AS LAND_SI_5_5_3_A,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth landf'')) AS LAND_OTH_LANDF,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3b'')) AS LAND_SI_5_5_3_B,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj i'')) AS UNINJ_I,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj iiv'')) AS UNINJ_IIV,
                          (SELECT     CONVERT(VARCHAR(100), SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END))) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''water'')) AS WATER,
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID)) AS TOTAL, dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) 
                      AS POTW_WASTE_QUANTITY_MEASURE,
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN OFSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(OFSR.WASTE_Q_ME, OFSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_TRANSFER_Q AS OFSR INNER JOIN
                                                   dbo.TRI_TRANSFER_LOC AS TL ON OFSR.FK_GUID = TL.PK_GUID
                            WHERE      (TL.FK_GUID = R.PK_GUID)) AS TOTAL_OFFSITE_WASTE_QUANTITY, R.ONE_TIME_RELEASE_Q AS ONE_TIME_RELEASE_QUANTITY, 
                      R.PRODUCTION_RATIO_ME AS PRODUCTION_RATIO_MEASURE, F.PROVINCE_TXT AS MAIL_PROVINCE_NM, 
                      F.MAIL_ADD_COUNTRY AS MAIL_COUNTRY_NM, F.MAIL_ADD_COUNTRY_CODE AS MAIL_COUNTRY_CD, 
                      F.MAIL_ADD_TXT AS MAIL_ADD_LINE_1_DS, F.SUPP_MAIL_ADD AS MAIL_ADD_LINE_2_DS, F.MAIL_ADD_CITY AS MAIL_CITY_NM, 
                      F.MAIL_ADD_POSTAL_CODE AS MAIL_ZIP_CD, F.MAIL_ADD_STATE AS MAIL_STATE_CD, R.PUB_CONT AS PUBLIC_CONTACT_NM, 
                      R.PUB_CONT_PHONE_TXT AS PUBLIC_PHONE_NR, LOWER(R.PUB_CONT_EMAIL_ADDRES) AS PUBLIC_EMAIL, 
                      R.TECH_CONT AS TECH_CONTACT_NM, R.TECH_CONT_PHONE_TXT AS TECH_PHONE_NR, LOWER(R.TECH_CONT_EMAIL_ADDRES) AS TECH_EMAIL,
                       N.FAC_NAICS AS FAC_NAICS_PRIMARY, F.MAIL_FAC_SITE AS MAIL_NAME, R.PK_GUID AS FK_GUID_REPORT, C.FK_GUID AS FK_GUID_CHEM, 
                      CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS SIGNED_DT, R.FK_GUID AS REPORT_FK, C.FK_GUID AS CHEM_FK, 
                      dbo.TRI_Convert_EPA_ProcessStatusCd_Desc(R.REPORT_EPA_PROCESSING_STATUS_C) AS REPORT_EPA_PROCESSING_STATUS_CD, 
                      CTYREG.EcologyRegion AS ECOLOGY_REGION, R.CHEM_RPT_REV_CD_1, R.CHEM_RPT_REV_CD_2, R.CHEM_RPT_WD_CD_1, 
                      R.CHEM_RPT_WD_CD_2
FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '''') <> ''5''
AND
C.CAS_CLBER <> ''N150''
AND 
D.TRIFID_DELETE_ID IS NULL
AND T.Inactive_DT IS NULL
AND
(
R.SUB_PARTIAL_FAC_ID = ''Y''
OR
	(
	R.SUB_PARTIAL_FAC_ID = ''N''
	AND
	S.INSERTED_DATE =
							  (SELECT     MAX(S2.INSERTED_DATE)
								FROM          dbo.TRI_SUB AS S2 INNER JOIN
													   dbo.TRI_FAC AS F2 ON F2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_REPORT AS R2 ON R2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_CHEM AS C2 ON C2.FK_GUID = R2.PK_GUID
								WHERE      (F2.FAC_ID = F.FAC_ID) AND (R2.SUB_REP_YEAR = R.SUB_REP_YEAR) AND (C2.CAS_CLBER = C.CAS_CLBER) AND 
													   (C2.CHEM_TXT = C.CHEM_TXT)
							   )
	AND
			(
			dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 1
			OR
				(
				dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 0
				AND NOT EXISTS
					(
					SELECT * FROM TRI_REPORT R3
					JOIN TRI_CHEM C3 ON C3.FK_GUID = R3.PK_GUID
					WHERE
					C3.CHEM_TXT = C.CHEM_TXT
					AND
					R3.FK_GUID = R.FK_GUID
					AND
					dbo.TRI_CalculateRevisionIndicator(R3.PK_GUID) = 1
					)
				)
			)
	)
)

'
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetSearchLookups]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetSearchLookups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets search lookups
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetSearchLookups]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT     UPPER(CHEMS) AS CHEM
	FROM       V_BRS_SEARCH
	WHERE	   CHEMS IS NOT NULL AND LEN(CHEMS) > 0
	GROUP BY   CHEMS
	ORDER BY   CHEMS

	SELECT     CONVERT(char(4), REPORT_YEAR) AS REPYEAR
	FROM       V_BRS_SEARCH
	WHERE	   REPORT_YEAR IS NOT NULL AND LEN(REPORT_YEAR) > 0
	GROUP BY   REPORT_YEAR
	ORDER BY   REPORT_YEAR DESC

     SELECT    DISTINCT UPPER(EcologyRegion) AS ECOLOGY_REGION
     FROM      App_Lookup_Cty_Reg
	 ORDER BY  UPPER(EcologyRegion)

     SELECT    DISTINCT UPPER(County) AS COUNTY
     FROM      App_Lookup_Cty_Reg
	 ORDER BY  UPPER(County)

END

' 
END
GO
/****** Object:  View [dbo].[V_CUSTOM_QUERY_XFR]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_CUSTOM_QUERY_XFR]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_CUSTOM_QUERY_XFR]

AS
SELECT

	TL.FK_GUID
,	SUM(CAST(dbo.TRI_RangeCodeConversion(TQ.WASTE_Q_ME, TQ.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10))) TOTAL_OFFSITE_XFR_62

FROM TRI_TRANSFER_LOC TL
JOIN TRI_TRANSFER_Q TQ ON TQ.FK_GUID = TL.PK_GUID

GROUP BY TL.FK_GUID



'
GO
/****** Object:  View [dbo].[V_EXT_DETAIL_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DETAIL_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_TRI_DETAIL
 Condensed Name:	V_EXT_DETAIL_D
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the TRI Detail extract in the TRI Application as well as provides source information for other extacts. Results in grams.
   =============================================*/

CREATE VIEW [dbo].[V_EXT_DETAIL_D]
AS
SELECT
	FI.FS_ID AS FSID
,	FI.EPA_ID AS [ECY ID]
,	UPPER(F.FAC_ID) AS TRIFID
,	R.SUB_REP_YEAR AS Year
,	CASE dbo.TRI_CalculateRevisionIndicator(R.PK_GUID)
		WHEN 1 THEN ''Y''
		ELSE ''N''
	END AS Revision
,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
,	F.FAC_SITE AS [Facility Name]
,	T.AgencyName AS AKA
,	F.LOC_ADD_TXT AS [Address 1]
,	F.SUPP_LOC_TXT AS [Address 2]
,	F.LOCALITY AS City
,	F.COUNTY AS County
,	F.ADD_POSTAL_CODE AS Zip
,	N.FAC_NAICS AS NAICS
,	C.CHEM_TXT AS Chemical
,	C.CAS_CLBER AS [CAS #]
,	F.PK_GUID AS PK_GUID_FAC
,	C.PK_GUID AS PK_GUID_CHEM
,	F.FK_GUID AS FK_GUID_FAC
,	R.PK_GUID AS PK_GUID_REPORT
,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air fug'')) AS [51 Fugitive Air],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air stack'')) AS [52 Stack Air],
                          (SELECT     CONVERT(VARCHAR(100), SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END))) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''water'')) AS [53 Water],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj i'')) AS [541 UG INJ Class I],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj iiv'')) AS [542 UG INJ Class II-V],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''rcra c'')) AS [551A RCRA C Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth landf'')) AS [551B Other Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''land trea'')) AS [552 Land Treatment],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3a'')) AS [553A RCRA C SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3b'')) AS [553B Other SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth disp'')) AS [554 Other Disposal],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID)) AS [Onsite Release Total], dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) 
                      AS [POTW Waste Quantity],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN OFSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(OFSR.WASTE_Q_ME, OFSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_TRANSFER_Q AS OFSR INNER JOIN
                                                   dbo.TRI_TRANSFER_LOC AS TL ON OFSR.FK_GUID = TL.PK_GUID
                            WHERE      (TL.FK_GUID = R.PK_GUID)) AS [Total Offsite Waste Quantity]
,	R.ONE_TIME_RELEASE_Q AS [One Time Release]
,	R.PRODUCTION_RATIO_ME AS [Production Ratio]
,	R.PK_GUID AS FK_GUID_REPORT
,	C.FK_GUID AS FK_GUID_CHEM
,	CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS Signed
,	S.INSERTED_DATE AS Received
,	R.FK_GUID AS REPORT_FK
,	C.FK_GUID AS CHEM_FK
,	CTYREG.EcologyRegion AS [ECY Region]
,	R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,	CTYREG.EcologyRegion AS ECOLOGY_REGION
,	FI.FS_ID
,	FI.EPA_ID
,	F.COUNTY AS COUNTY_NM
,	F.FAC_SITE AS FAC_NAME
,	T.AgencyName
,	C.CHEM_TXT AS CHEMICAL_NAME_TEXT

FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '''') <> ''5''
AND
C.CAS_CLBER = ''N150''
AND 
D.TRIFID_DELETE_ID IS NULL
AND T.Inactive_DT IS NULL
AND
(
R.SUB_PARTIAL_FAC_ID = ''Y''
OR
	(
	R.SUB_PARTIAL_FAC_ID = ''N''
	AND
	S.INSERTED_DATE =
							  (SELECT     MAX(S2.INSERTED_DATE)
								FROM          dbo.TRI_SUB AS S2 INNER JOIN
													   dbo.TRI_FAC AS F2 ON F2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_REPORT AS R2 ON R2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_CHEM AS C2 ON C2.FK_GUID = R2.PK_GUID
								WHERE      (F2.FAC_ID = F.FAC_ID) AND (R2.SUB_REP_YEAR = R.SUB_REP_YEAR) AND (C2.CAS_CLBER = C.CAS_CLBER) AND 
													   (C2.CHEM_TXT = C.CHEM_TXT)
							   )
	AND
			(
			dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 1
			OR
				(
				dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 0
				AND NOT EXISTS
					(
					SELECT * FROM TRI_REPORT R3
					JOIN TRI_CHEM C3 ON C3.FK_GUID = R3.PK_GUID
					WHERE
					C3.CHEM_TXT = C.CHEM_TXT
					AND
					R3.FK_GUID = R.FK_GUID
					AND
					dbo.TRI_CalculateRevisionIndicator(R3.PK_GUID) = 1
					)
				)
			)
	)
)

'
GO
/****** Object:  View [dbo].[V_EXT_DETAIL]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DETAIL]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_TRI_DETAIL
 Condensed Name:	V_EXT_DETAIL
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the TRI Detail extract in the TRI Application as well as provides source information for other extacts. Results in pounds.*/
CREATE VIEW [dbo].[V_EXT_DETAIL]
AS
SELECT
	FI.FS_ID AS FSID
,	FI.EPA_ID AS [ECY ID]
,	UPPER(F.FAC_ID) AS TRIFID
,	R.SUB_REP_YEAR AS Year
,	CASE dbo.TRI_CalculateRevisionIndicator(R.PK_GUID)
		WHEN 1 THEN ''Y''
		ELSE ''N''
	END AS Revision
,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
,	F.FAC_SITE AS [Facility Name]
,	T.AgencyName AS AKA
,	F.LOC_ADD_TXT AS [Address 1]
,	F.SUPP_LOC_TXT AS [Address 2]
,	F.LOCALITY AS City
,	F.COUNTY AS County
,	F.ADD_POSTAL_CODE AS Zip
,	N.FAC_NAICS AS NAICS
,	C.CHEM_TXT AS Chemical
,	C.CAS_CLBER AS [CAS #]
,	F.PK_GUID AS PK_GUID_FAC
,	C.PK_GUID AS PK_GUID_CHEM
,	F.FK_GUID AS FK_GUID_FAC
,	R.PK_GUID AS PK_GUID_REPORT
,
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air fug'')) AS [51 Fugitive Air],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''air stack'')) AS [52 Stack Air],
                          (SELECT     CONVERT(VARCHAR(100), SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END))) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''water'')) AS [53 Water],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj i'')) AS [541 UG INJ Class I],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''uninj iiv'')) AS [542 UG INJ Class II-V],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''rcra c'')) AS [551A RCRA C Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth landf'')) AS [551B Other Landfill],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''land trea'')) AS [552 Land Treatment],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3a'')) AS [553A RCRA C SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''si 5.5.3b'')) AS [553B Other SI],
                          (SELECT     CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                                                   ONSR.WASTE_Q_RANGE_CODE) END AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID) AND (EI_MEDIUM_CODE = ''oth disp'')) AS [554 Other Disposal],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_ONSITE_RELEASE_Q AS ONSR
                            WHERE      (FK_GUID = R.PK_GUID)) AS [Onsite Release Total], dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) 
                      AS [POTW Waste Quantity],
                          (SELECT     SUM(CONVERT(FLOAT, CASE WHEN OFSR.WASTE_Q_NA_IND = ''Y'' THEN CONVERT(FLOAT, 0) 
                                                   ELSE dbo.TRI_RangeCodeConversion(OFSR.WASTE_Q_ME, OFSR.WASTE_Q_RANGE_CODE) END)) AS Expr1
                            FROM          dbo.TRI_TRANSFER_Q AS OFSR INNER JOIN
                                                   dbo.TRI_TRANSFER_LOC AS TL ON OFSR.FK_GUID = TL.PK_GUID
                            WHERE      (TL.FK_GUID = R.PK_GUID)) AS [Total Offsite Waste Quantity]
,	R.ONE_TIME_RELEASE_Q AS [One Time Release]
,	R.PRODUCTION_RATIO_ME AS [Production Ratio]
,	R.PK_GUID AS FK_GUID_REPORT
,	C.FK_GUID AS FK_GUID_CHEM
,	CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS Signed
,	S.INSERTED_DATE AS Received
,	R.FK_GUID AS REPORT_FK
,	C.FK_GUID AS CHEM_FK
,	CTYREG.EcologyRegion AS [ECY Region]
,	R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,	CTYREG.EcologyRegion AS ECOLOGY_REGION
,	FI.FS_ID
,	FI.EPA_ID
,	F.COUNTY AS COUNTY_NM
,	F.FAC_SITE AS FAC_NAME
,	T.AgencyName
,	C.CHEM_TXT AS CHEMICAL_NAME_TEXT

FROM         dbo.TRI_REPORT AS R INNER JOIN
                      dbo.TRI_SUB AS S ON R.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_FAC AS F ON F.FK_GUID = S.PK_GUID INNER JOIN
                      dbo.TRI_CHEM AS C ON C.FK_GUID = R.PK_GUID LEFT OUTER JOIN
                      dbo.V_FAC_IDENT AS FI ON UPPER(F.FAC_ID) = FI.TRIFID LEFT OUTER JOIN
                      dbo.TRI_FAC_NAICS AS N ON F.PK_GUID = N.FK_GUID AND N.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      dbo.App_Lookup_Cty_Reg AS CTYREG ON CTYREG.County = F.COUNTY LEFT OUTER JOIN
                      dbo.App_FI_TRIFID AS T ON F.FAC_ID = T.TRIFID LEFT OUTER JOIN
                      dbo.App_FI_TRIFID_Delete AS D ON D.TRIFID_ID_FK = T.TRIFID_ID AND D.TRI_SUB_ID = S.TRI_SUB_ID

WHERE
ISNULL(R.REPORT_EPA_PROCESSING_STATUS_C, '''') <> ''5''
AND
C.CAS_CLBER <> ''N150''
AND 
D.TRIFID_DELETE_ID IS NULL
AND T.Inactive_DT IS NULL
AND
(
R.SUB_PARTIAL_FAC_ID = ''Y''
OR
	(
	R.SUB_PARTIAL_FAC_ID = ''N''
	AND
	S.INSERTED_DATE =
							  (SELECT     MAX(S2.INSERTED_DATE)
								FROM          dbo.TRI_SUB AS S2 INNER JOIN
													   dbo.TRI_FAC AS F2 ON F2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_REPORT AS R2 ON R2.FK_GUID = S2.PK_GUID INNER JOIN
													   dbo.TRI_CHEM AS C2 ON C2.FK_GUID = R2.PK_GUID
								WHERE      (F2.FAC_ID = F.FAC_ID) AND (R2.SUB_REP_YEAR = R.SUB_REP_YEAR) AND (C2.CAS_CLBER = C.CAS_CLBER) AND 
													   (C2.CHEM_TXT = C.CHEM_TXT)
							   )
	AND
			(
			dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 1
			OR
				(
				dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) = 0
				AND NOT EXISTS
					(
					SELECT * FROM TRI_REPORT R3
					JOIN TRI_CHEM C3 ON C3.FK_GUID = R3.PK_GUID
					WHERE
					C3.CHEM_TXT = C.CHEM_TXT
					AND
					R3.FK_GUID = R.FK_GUID
					AND
					dbo.TRI_CalculateRevisionIndicator(R3.PK_GUID) = 1
					)
				)
			)
	)
)

'
GO
/****** Object:  UserDefinedFunction [dbo].[TRI_CalcLbsPerFacYr]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_CalcLbsPerFacYr]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		TK Conrad (Windsor Solutions, Inc.)
-- Create date: 2010-04-07
-- Description:	Calculate the total pounds per facility per reporting year.
-- =============================================
CREATE FUNCTION [dbo].[TRI_CalcLbsPerFacYr] 
(
	-- Add the parameters for the function here
	@TRIFID varchar(100)
,	@RY	char(4)
)
RETURNS DECIMAL(18,3)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result DECIMAL(18,3)

	-- Add the T-SQL statements to compute the return value here
	SELECT @Result =
	ISNULL(SUM(CAST(dbo.TRI_RangeCodeConversion(ONREL.WASTE_Q_ME, ONREL.WASTE_Q_RANGE_CODE) AS DECIMAL(18,3))), 0)
	+ ISNULL(CAST(dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) AS DECIMAL(18,3)), 0)
	+ ISNULL(SUM(CAST(dbo.TRI_RangeCodeConversion(TQ.WASTE_Q_ME, TQ.WASTE_Q_RANGE_CODE) AS DECIMAL(18,3))), 0)
	+ ISNULL(CAST(R.ONE_TIME_RELEASE_Q AS DECIMAL(18,3)), 0)

FROM TRI_SUB S
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL ON ONREL.FK_GUID = R.PK_GUID
LEFT JOIN TRI_TRANSFER_LOC TL
	JOIN TRI_TRANSFER_Q TQ ON TQ.FK_GUID = TL.PK_GUID
ON TL.FK_GUID = R.PK_GUID

WHERE
F.FAC_ID = @TRIFID
AND
R.SUB_REP_YEAR = @RY
AND
S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM TRI_REPORT R2
		JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE
			F2.FAC_ID = F.FAC_ID
		AND
			R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
			C2.CHEM_TXT = C.CHEM_TXT
	)

AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL

GROUP BY
	R.WASTE_Q_ME
,	R.WASTE_Q_RANGE_CODE
,	R.ONE_TIME_RELEASE_Q
,	F.FAC_ID
,	R.SUB_REP_YEAR
,	C.CHEM_TXT
,	R.CERT_SIGNED_DATE

	-- Return the result of the function
	RETURN @Result

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetFacilityData]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetFacilityData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets Summary Data by TRIFID
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetFacilityData] (
	@tid varchar(100),
	@year varchar(100) = NULL
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT TRIFID
		  ,UPPER(COALESCE(FacilityName,'''')) AS FAC_NAME
		  ,REPLACE(UPPER(COALESCE(Addr1, '''')) + '', '' + 
			UPPER(COALESCE(Addr2, '''')) + '', '' +
			UPPER(COALESCE(City,'''')) + '', '' +
			UPPER(COALESCE(State_USPS,'''')) + '' '' +
			UPPER(COALESCE(ZIPCode, '''')), '', , '', '', '') AS ADDRESS1
		  ,UPPER(COALESCE(County, '''')) AS ADDRESS2
		  ,UPPER(COALESCE(City,'''')) as CITY
		  ,UPPER(COALESCE(State_USPS,'''')) AS USPS
		  ,UPPER(COALESCE(ZIPCode, '''')) AS ZIP
	  FROM V_BRS_RSLT_SUM
	  WHERE TRIFID = @tid;

	SELECT TRIFID
		  ,COALESCE(SUB_REP_YEAR, '''') AS REPORT_YEAR
		  ,UPPER(COALESCE(REPORT_SUB_METH_CODE, '''')) AS REPORT_SUB_METH
		  ,UPPER(COALESCE(REPORT_EPA_PROCESSING_STATUS_C, '''')) AS REPORT_EPA_STATUS
		  ,SUB_PK_GUID AS SUB_ID
		  ,NUM_OF_CHEMS_PER_SUBMISSION AS REPORT_CHEM_NUM
		  ,UPPER(COALESCE(REPORT_TYPE_CODE, '''')) AS REPORT_TYPE_CODE
	FROM V_BRS_RSLT_DTL
	WHERE TRIFID = @tid AND SUB_REP_YEAR = COALESCE(@year, SUB_REP_YEAR)
	ORDER BY INSERTED_DATE DESC;

	SELECT C.SUB_PK_GUID AS SUB_ID
		  ,UPPER(COALESCE(C.REPORT_TYPE_CODE, '''')) AS REPORT_TYPE_CODE
		  ,CONVERT(bit, CASE WHEN C.REVISION_IND = ''Y'' THEN 1 ELSE 0 END) AS IS_REVISION
		  ,CONVERT(bit, CASE WHEN C.SUB_PARTIAL_FAC_ID = ''Y'' THEN 1 ELSE 0 END) AS IS_PARTIAL
		  ,C.INSERTED_DATE AS RECEIVED_DATE
		  ,UPPER(C.CHEMICAL) AS CHEMICAL_NAME
		  ,C.REP_PK_GUID AS CHEM_ID
	  FROM V_BRS_RSLT_CHM C
	JOIN V_BRS_RSLT_DTL D ON C.TRIFID = D.TRIFID
	  WHERE C.TRIFID = @tid AND D.SUB_REP_YEAR = COALESCE(@year, D.SUB_REP_YEAR);


END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetASubmissionData]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetASubmissionData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets submission Data by Submission id
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetASubmissionData] (
	@subid varchar(36),
    @chemId varchar(36)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT * FROM V_FORM_A_PG_1 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_FORM_A_PG_2 WHERE PK_GUID_SUB = @subid AND CHEM_ID = @chemId;
	

END

' 
END
GO
/****** Object:  View [dbo].[V_CUSTOM_QUERY]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_CUSTOM_QUERY]'))
EXEC dbo.sp_executesql @statement = N'


CREATE VIEW [dbo].[V_CUSTOM_QUERY]

AS
SELECT

	S.TRI_SUB_ID
,	F.FAC_ID					TRIFID
,	F.FAC_SITE					FACILITY_NAME
,	F.LOC_ADD_TXT				STREET_ADDRESS_1
,	F.SUPP_LOC_TXT				STREET_ADDRESS_2
,	F.LOCALITY					CITY
,	F.[STATE]					STATE_CODE
,	F.ADD_POSTAL_CODE			ZIP_CODE
,	F.COUNTY
,	R.PUB_CONT
,	F.FAC_SITE
	+ '', '' + F.LOC_ADD_TXT
	+ CASE WHEN F.SUPP_LOC_TXT IS NULL THEN '''' ELSE '', '' + F.SUPP_LOC_TXT END
	+ '', '' + F.LOCALITY
	+ '', '' + F.[STATE]
	+ ''  '' + F.ADD_POSTAL_CODE
	+ ''  '' + F.COUNTY
	+ ''  '' + R.PUB_CONT AS FORMATTED_ADDRESS
,	R.REPORT_ID
,	RIGHT(R.REPORT_TYPE_CODE, 1) REPORT_TYPE_CODE
,	R.SUB_REP_YEAR
,	dbo.TRI_CalculateRevisionIndicator(R.PK_GUID) AS REV_INDICATOR
,	dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) AS SUBMISSION_METHOD
,	C.CAS_CLBER					CHEMICAL_CAS_NUMBER
,	C.CHEM_TXT					CHEMICAL_NAME
,	R.MAX_CHEM_AMOUNT_CODE
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_51.WASTE_Q_ME, ONREL_51.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_51_AIR_FUG
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_52.WASTE_Q_ME, ONREL_52.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_52_AIR_STACK
,	ISNULL(CAST(dbo.TRI_RangeCodeConversion(ONREL_51.WASTE_Q_ME, ONREL_51.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)), 0)
	+ ISNULL(CAST(dbo.TRI_RangeCodeConversion(ONREL_52.WASTE_Q_ME, ONREL_52.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)), 0) ONREL_AIR_EMISSIONS
,	ONREL_53.ONREL_53_WATER
,	ONREL_53.RELEASE_STORM_WATER
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_541.WASTE_Q_ME, ONREL_541.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_541_UNINJ_I
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_542.WASTE_Q_ME, ONREL_542.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_542_UNINJ_IIV
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_551A.WASTE_Q_ME, ONREL_551A.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_551A_RCRA_C
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_551B.WASTE_Q_ME, ONREL_551B.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_551B_OTH_LANDF
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_552.WASTE_Q_ME, ONREL_552.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_552_LAND_TREA
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_553A.WASTE_Q_ME, ONREL_553A.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_553A_SI_553A
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_553B.WASTE_Q_ME, ONREL_553B.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_553B__SI_553B
,	CAST(dbo.TRI_RangeCodeConversion(ONREL_554.WASTE_Q_ME, ONREL_554.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) ONREL_554_OTH_DISP
,	(
	SELECT SUM(CAST(dbo.TRI_RangeCodeConversion(ONREL_TOTAL.WASTE_Q_ME, ONREL_TOTAL.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)))
	FROM TRI_ONSITE_RELEASE_Q ONREL_TOTAL
	WHERE ONREL_TOTAL.FK_GUID = R.PK_GUID
	) ONREL_TOTAL
,	CAST(dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)) TOTAL_POTW_61
,	XFR.TOTAL_OFFSITE_XFR_62
,	CAST(ONUIC.TOTAL_Q AS DECIMAL(18,10)) SRED_81A_ONS_UIC_RCRA
,	CAST(ONDQ.TOTAL_Q AS DECIMAL(18,10)) SRED_81B_OTH_ONSITE
,	CAST(OFFUIC.TOTAL_Q AS DECIMAL(18,10)) SRED_81C_OFF_UIC_RCRA
,	CAST(OFFDQ.TOTAL_Q AS DECIMAL(18,10)) SRED_81D_OTH_OFFSITE
,	CAST(ONEREC.TOTAL_Q AS DECIMAL(18,10)) SRED_82_ONS_ENERGY
,	CAST(OFFEREC.TOTAL_Q AS DECIMAL(18,10)) SRED_83_OFF_ENERGY
,	CAST(ONREC.TOTAL_Q AS DECIMAL(18,10)) SRED_84_ONS_RECYCLE
,	CAST(OFFREC.TOTAL_Q AS DECIMAL(18,10)) SRED_85_OFF_RECYCLE
,	CAST(ONTRE.TOTAL_Q AS DECIMAL(18,10)) SRED_86_ONS_TREAT
,	CAST(OFFTRE.TOTAL_Q AS DECIMAL(18,10)) SRED_87_OFF_TREAT
,	CAST(R.ONE_TIME_RELEASE_Q AS DECIMAL(18,10)) ONE_TIME_88
,	CAST(R.PRODUCTION_RATIO_ME AS DECIMAL(18,10)) PROD_RATIO_89
,	(
	SELECT SUM(CAST(dbo.TRI_RangeCodeConversion(ONREL_TOTAL.WASTE_Q_ME, ONREL_TOTAL.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)))
	FROM TRI_ONSITE_RELEASE_Q ONREL_TOTAL
	WHERE ONREL_TOTAL.FK_GUID = R.PK_GUID
	)
	+ ISNULL(CAST(dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) AS DECIMAL(18,10)), 0)
	+ ISNULL(XFR.TOTAL_OFFSITE_XFR_62, 0)
	+ ISNULL(R.ONE_TIME_RELEASE_Q, 0) TOTAL_REL_AND_XFR
,	CAST(1 AS INT) COUNT_CHEMICAL

FROM TRI_SUB S
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_51 ON ONREL_51.FK_GUID = R.PK_GUID AND ONREL_51.EI_MEDIUM_CODE = ''AIR FUG''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_52 ON ONREL_52.FK_GUID = R.PK_GUID AND ONREL_52.EI_MEDIUM_CODE = ''AIR STACK''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_541 ON ONREL_541.FK_GUID = R.PK_GUID AND ONREL_541.EI_MEDIUM_CODE = ''UNINJ I''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_542 ON ONREL_542.FK_GUID = R.PK_GUID AND ONREL_542.EI_MEDIUM_CODE = ''UNINJ IIV''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_551A ON ONREL_551A.FK_GUID = R.PK_GUID AND ONREL_551A.EI_MEDIUM_CODE = ''RCRA C''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_551B ON ONREL_551B.FK_GUID = R.PK_GUID AND ONREL_551B.EI_MEDIUM_CODE = ''OTH LANDF''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_552 ON ONREL_552.FK_GUID = R.PK_GUID AND ONREL_552.EI_MEDIUM_CODE = ''LAND TREA''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_553A ON ONREL_553A.FK_GUID = R.PK_GUID AND ONREL_553A.EI_MEDIUM_CODE = ''SI 5.5.3A''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_553B ON ONREL_553B.FK_GUID = R.PK_GUID AND ONREL_553B.EI_MEDIUM_CODE = ''SI 5.5.3B''
LEFT JOIN TRI_ONSITE_RELEASE_Q ONREL_554 ON ONREL_554.FK_GUID = R.PK_GUID AND ONREL_554.EI_MEDIUM_CODE = ''OTH DISP''
LEFT JOIN V_CUSTOM_QUERY_STREAM ONREL_53 ON ONREL_53.FK_GUID = R.PK_GUID
LEFT JOIN V_CUSTOM_QUERY_XFR XFR ON XFR.FK_GUID = R.PK_GUID

LEFT JOIN TRI_OFFSITE_DISP_QTY OFFDQ ON OFFDQ.FK_GUID = R.PK_GUID AND OFFDQ.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_OFFSITE_ENERGY_REC_QTY OFFEREC ON OFFEREC.FK_GUID = R.PK_GUID AND OFFEREC.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_OFFSITE_RECYCLED_Q OFFREC ON OFFREC.FK_GUID = R.PK_GUID AND OFFREC.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_OFFSITE_TREATED_Q OFFTRE ON OFFTRE.FK_GUID = R.PK_GUID AND OFFTRE.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_OFFSITE_UIC_DISP_QTY OFFUIC ON OFFUIC.FK_GUID = R.PK_GUID AND OFFUIC.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_ONSITE_DISP_QTY ONDQ ON ONDQ.FK_GUID = R.PK_GUID AND ONDQ.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_ONSITE_ENERGY_RCV_QTY ONEREC ON ONEREC.FK_GUID = R.PK_GUID AND ONEREC.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_ONSITE_RECYCLED_Q ONREC ON ONREC.FK_GUID = R.PK_GUID AND ONREC.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_ONSITE_TREATED_Q ONTRE ON ONTRE.FK_GUID = R.PK_GUID AND ONTRE.YEAR_OFFSET_ME = ''0''
LEFT JOIN TRI_ONSITE_UIC_DISP_QTY ONUIC ON ONUIC.FK_GUID = R.PK_GUID AND ONUIC.YEAR_OFFSET_ME = ''0''

WHERE

S.INSERTED_DATE =
	(
	SELECT MAX(S2.INSERTED_DATE)
	FROM TRI_REPORT R2
		JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
		JOIN TRI_SUB S2 ON S2.PK_GUID = R2.FK_GUID
		JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
		WHERE
			F2.FAC_ID = F.FAC_ID
		AND
			R2.SUB_REP_YEAR = R.SUB_REP_YEAR
		AND
			C2.CHEM_TXT = C.CHEM_TXT
	)

AND COALESCE(R.CHEM_RPT_WD_CD_1, R.CHEM_RPT_WD_CD_2) IS NULL


'
GO
/****** Object:  View [dbo].[V_EXT_W_MGMT_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_W_MGMT_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_WASTE_MANAGEMENT
 Condensed Name:	V_EXT_W_MGMT
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Waste Management extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_W_MGMT_D]
AS
SELECT     PK_GUID_REPORT, FS_ID AS FSID, EPA_ID AS [ECY ID], TRIFID, SUBMISSION_REPORTING_YEAR AS Year, REVISION_INDICATOR AS Revision, 
                      SUBMISSION_PARTIAL_FACILITY_ID AS [Partial Sub], FAC_NAME AS [Facility Name], AgencyName AS AKA, CHEMICAL_NAME_TEXT AS Chemical, 
                      CAS_NUMBER AS [Cas #], PRODUCTION_RATIO_MEASURE AS [Prod Ratio], ONE_TIME_RELEASE_QUANTITY AS [One Time Release],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Disp UG INJ Landfills PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Disp UG INJ Landfills CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Disp UG INJ Landfills FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Disp UG INJ Landfills 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Disp UG INJ Landfills PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Disp UG INJ Landfills CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Disp UG INJ Landfills FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Disp UG INJ Landfills 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Disp Other PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Disp Other CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Disp Other FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Disp Other 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Disp Other PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Disp Other CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Disp Other FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Disp Other 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Energy Recovery PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Energy Recovery CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Energy Recovery FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Energy Recovery 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Energy Recovery PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Energy Recovery CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Energy Recovery FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Energy Recovery 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Recycled PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Recycled CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Recycled FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Recycled 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Recycled PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Recycled CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Recycled FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Recycled 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Treated PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Treated CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Treated FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Treated 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Treated PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Treated CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Treated FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Treated 2ND FWL YR], ECOLOGY_REGION AS [ECY Region], 
                      SUBMISSION_REPORTING_YEAR, ECOLOGY_REGION, FS_ID, EPA_ID, COUNTY_NM, FAC_NAME, AgencyName, CHEMICAL_NAME_TEXT
FROM         dbo.V_EXT_MASTER_D AS TD
WHERE     (REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_W_MGMT]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_W_MGMT]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_WASTE_MANAGEMENT
 Condensed Name:	V_EXT_W_MGMT
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Waste Management extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_W_MGMT]
AS
SELECT     PK_GUID_REPORT, FS_ID AS FSID, EPA_ID AS [ECY ID], TRIFID, SUBMISSION_REPORTING_YEAR AS Year, REVISION_INDICATOR AS Revision, 
                      SUBMISSION_PARTIAL_FACILITY_ID AS [Partial Sub], FAC_NAME AS [Facility Name], AgencyName AS AKA, CHEMICAL_NAME_TEXT AS Chemical, 
                      CAS_NUMBER AS [Cas #], PRODUCTION_RATIO_MEASURE AS [Prod Ratio], ONE_TIME_RELEASE_QUANTITY AS [One Time Release],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Disp UG INJ Landfills PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Disp UG INJ Landfills CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Disp UG INJ Landfills FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_UIC_DISP_QTY AS TRI_ONSITE_UIC_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Disp UG INJ Landfills 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Disp UG INJ Landfills PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Disp UG INJ Landfills CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Disp UG INJ Landfills FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_UIC_DISP_QTY AS TRI_OFFSITE_UIC_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Disp UG INJ Landfills 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Disp Other PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Disp Other CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Disp Other FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_DISP_QTY AS TRI_ONSITE_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Disp Other 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Disp Other PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Disp Other CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Disp Other FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_DISP_QTY AS TRI_OFFSITE_DISP_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Disp Other 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Energy Recovery PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Energy Recovery CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Energy Recovery FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_ENERGY_RCV_QTY AS TRI_ONSITE_ENERGY_RCV_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Energy Recovery 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Energy Recovery PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Energy Recovery CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Energy Recovery FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_ENERGY_REC_QTY AS TRI_OFFSITE_ENERGY_REC_QTY_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Energy Recovery 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Recycled PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Recycled CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Recycled FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_RECYCLED_Q AS TRI_ONSITE_RECYCLED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Recycled 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Recycled PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Recycled CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Recycled FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_RECYCLED_Q AS TRI_OFFSITE_RECYCLED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Recycled 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [On Treated PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [On Treated CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [On Treated FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_ONSITE_TREATED_Q AS TRI_ONSITE_TREATED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [On Treated 2ND FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''-1'')) AS [Off Treated PRI YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_3
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''0'')) AS [Off Treated CURR YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_2
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''1'')) AS [Off Treated FWL YR],
                          (SELECT     CASE WHEN TOTAL_Q_NA_IND = ''Y'' THEN NULL ELSE TOTAL_Q END AS Expr1
                            FROM          dbo.TRI_OFFSITE_TREATED_Q AS TRI_OFFSITE_TREATED_Q_1
                            WHERE      (FK_GUID = TD.PK_GUID_REPORT) AND (YEAR_OFFSET_ME = ''2'')) AS [Off Treated 2ND FWL YR], ECOLOGY_REGION AS [ECY Region], 
                      SUBMISSION_REPORTING_YEAR, ECOLOGY_REGION, FS_ID, EPA_ID, COUNTY_NM, FAC_NAME, AgencyName, CHEMICAL_NAME_TEXT
FROM         dbo.V_EXT_MASTER AS TD
WHERE     (REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_STR_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_STR_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_STREAMS
 Condensed Name:	V_EXT_STR
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Streams extract in the TRI Application. Excludes dioxins, results in pounds.
 RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_STR_D]
AS
SELECT     TD.FS_ID AS FSID, TD.EPA_ID AS [ECY ID], TD.TRIFID, TD.SUBMISSION_REPORTING_YEAR AS Year, TD.FAC_NAME AS [Facility Name], 
                      TD.AgencyName AS AKA, TD.LOC_ADD_LINE_1_DS AS [Address 1], TD.LOC_ADD_LINE_2_DS AS [Address 2], TD.CITY_NM AS City, 
                      TD.COUNTY_NM AS County, TD.ZIP_CD AS Zip, TD.CHEMICAL_NAME_TEXT AS Chemical, TD.CAS_NUMBER AS [CAS #], ONSR.PK_GUID, 
                      ONSR.FK_GUID, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN ''0'' ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                      ONSR.WASTE_Q_RANGE_CODE) END AS [Release Total], ONSR.WASTE_Q_RANGE_CODE AS [Release Range Code], 
                      ONSR.Q_BASIS_EST_CD AS [Basis of Estimate Code], ONSR.WATER_SEQ_CLBER AS [Water Body Sequence #], 
                      ONSR.STREAM AS [Water Body Name], ONSR.RELEASE_STORM_WATER AS [Release % from Stormwater], TD.ECOLOGY_REGION AS [ECY Region], 
                      TD.SUBMISSION_REPORTING_YEAR, TD.ECOLOGY_REGION, TD.FS_ID, TD.EPA_ID, TD.COUNTY_NM, TD.FAC_NAME, TD.AgencyName, 
                      TD.CHEMICAL_NAME_TEXT
FROM         dbo.V_EXT_MASTER_D AS TD INNER JOIN
                      dbo.TRI_ONSITE_RELEASE_Q AS ONSR ON TD.PK_GUID_REPORT = ONSR.FK_GUID
WHERE     (CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN ''0'' ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) 
                      END <> ''0'') AND (ISNULL(ONSR.STREAM, ''NA'') <> ''NA'') AND (TD.REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_STR]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_STR]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_STREAMS
 Condensed Name:	V_EXT_STR
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Streams extract in the TRI Application. Excludes dioxins, results in pounds.
 RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_STR]
AS
SELECT     TD.FS_ID AS FSID, TD.EPA_ID AS [ECY ID], TD.TRIFID, TD.SUBMISSION_REPORTING_YEAR AS Year, TD.FAC_NAME AS [Facility Name], 
                      TD.AgencyName AS AKA, TD.LOC_ADD_LINE_1_DS AS [Address 1], TD.LOC_ADD_LINE_2_DS AS [Address 2], TD.CITY_NM AS City, 
                      TD.COUNTY_NM AS County, TD.ZIP_CD AS Zip, TD.CHEMICAL_NAME_TEXT AS Chemical, TD.CAS_NUMBER AS [CAS #], ONSR.PK_GUID, 
                      ONSR.FK_GUID, CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN ''0'' ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, 
                      ONSR.WASTE_Q_RANGE_CODE) END AS [Release Total], ONSR.WASTE_Q_RANGE_CODE AS [Release Range Code], 
                      ONSR.Q_BASIS_EST_CD AS [Basis of Estimate Code], ONSR.WATER_SEQ_CLBER AS [Water Body Sequence #], 
                      ONSR.STREAM AS [Water Body Name], ONSR.RELEASE_STORM_WATER AS [Release % from Stormwater], TD.ECOLOGY_REGION AS [ECY Region], 
                      TD.SUBMISSION_REPORTING_YEAR, TD.ECOLOGY_REGION, TD.FS_ID, TD.EPA_ID, TD.COUNTY_NM, TD.FAC_NAME, TD.AgencyName, 
                      TD.CHEMICAL_NAME_TEXT
FROM         dbo.V_EXT_MASTER AS TD INNER JOIN
                      dbo.TRI_ONSITE_RELEASE_Q AS ONSR ON TD.PK_GUID_REPORT = ONSR.FK_GUID
WHERE     (CASE WHEN ONSR.WASTE_Q_NA_IND = ''Y'' THEN ''0'' ELSE dbo.TRI_RangeCodeConversion(ONSR.WASTE_Q_ME, ONSR.WASTE_Q_RANGE_CODE) 
                      END <> ''0'') AND (ISNULL(ONSR.STREAM, ''NA'') <> ''NA'') AND (TD.REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_P2_FEE_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_P2_FEE_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_P2_FEES
 Condensed Name:	V_EXT_P2_FEE
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Pollution Prevention extract in the TRI Application. Includes dioxins, results in pounds.
 =============================================*/
CREATE VIEW [dbo].[V_EXT_P2_FEE_D]
AS
SELECT     FS_ID AS FSID, EPA_ID AS [ECY ID], TRIFID, FAC_NAME AS [Facility Name], AgencyName AS AKA, LOC_ADD_LINE_1_DS AS [Address 1], 
                      LOC_ADD_LINE_2_DS AS [Address 2], CITY_NM AS City, ZIP_CD AS Zip, COUNTY_NM AS County, MAIL_ADD_LINE_1_DS AS [Mail Address 1], 
                      MAIL_ADD_LINE_2_DS AS [Mail Address 2], MAIL_CITY_NM AS [Mail City], MAIL_STATE_CD AS [Mail State], MAIL_PROVINCE_NM AS [Mail Province], 
                      MAIL_ZIP_CD AS [Mail Zip], MAIL_COUNTRY_CD AS [Mail Country], FAC_NAICS_PRIMARY AS [NAICS], TECH_CONTACT_NM AS [Tech Contact], TECH_PHONE_NR AS [Tech Phone], 
                      SUBMISSION_REPORTING_YEAR AS Year, SUM(TOTAL) AS [Sum of TRI], ECOLOGY_REGION AS [ECY Region], SUBMISSION_REPORTING_YEAR, 
                      ECOLOGY_REGION, FS_ID, EPA_ID, COUNTY_NM, FAC_NAME, AgencyName,

						(
						SELECT COUNT(*) FROM dbo.V_EXT_MASTER_D AS TD2
						WHERE
							TD2.TRIFID = TD.TRIFID
						AND
							TD2.SUBMISSION_REPORTING_YEAR = TD.SUBMISSION_REPORTING_YEAR
						AND
							TD2.REPORT_TYPE = ''TRI_FORM_R''
						) AS CountFormR,
						(
						SELECT COUNT(*) FROM dbo.V_EXT_MASTER_D AS TD2
						WHERE
							TD2.TRIFID = TD.TRIFID
						AND
							TD2.SUBMISSION_REPORTING_YEAR = TD.SUBMISSION_REPORTING_YEAR
						AND
							TD2.REPORT_TYPE = ''TRI_FORM_A''
						) AS CountFormA

FROM         dbo.V_EXT_MASTER_D AS TD

GROUP BY FS_ID, EPA_ID, AgencyName, FAC_NAME, LOC_ADD_LINE_1_DS, LOC_ADD_LINE_2_DS, CITY_NM, COUNTY_NM, ZIP_CD, MAIL_PROVINCE_NM, 
                      MAIL_COUNTRY_CD, MAIL_ADD_LINE_1_DS, MAIL_ADD_LINE_2_DS, MAIL_CITY_NM, MAIL_ZIP_CD, MAIL_STATE_CD, TECH_CONTACT_NM, 
                      TECH_PHONE_NR, TRIFID, SUBMISSION_REPORTING_YEAR, ECOLOGY_REGION, FAC_NAICS_PRIMARY

'
GO
/****** Object:  View [dbo].[V_EXT_P2_FEE]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_P2_FEE]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_P2_FEES
 Condensed Name:	V_EXT_P2_FEE
 Author:			TK Conrad
 Create date:		2007-05-18
 Description:		Supports the Pollution Prevention extract in the TRI Application. Includes dioxins, results in pounds.
 =============================================*/
CREATE VIEW [dbo].[V_EXT_P2_FEE]
AS
SELECT     FS_ID AS FSID, EPA_ID AS [ECY ID], TRIFID, FAC_NAME AS [Facility Name], AgencyName AS AKA, LOC_ADD_LINE_1_DS AS [Address 1], 
                      LOC_ADD_LINE_2_DS AS [Address 2], CITY_NM AS City, ZIP_CD AS Zip, COUNTY_NM AS County, MAIL_ADD_LINE_1_DS AS [Mail Address 1], 
                      MAIL_ADD_LINE_2_DS AS [Mail Address 2], MAIL_CITY_NM AS [Mail City], MAIL_STATE_CD AS [Mail State], MAIL_PROVINCE_NM AS [Mail Province], 
                      MAIL_ZIP_CD AS [Mail Zip], MAIL_COUNTRY_CD AS [Mail Country], FAC_NAICS_PRIMARY AS [NAICS], TECH_CONTACT_NM AS [Tech Contact], TECH_PHONE_NR AS [Tech Phone], 
                      SUBMISSION_REPORTING_YEAR AS Year, SUM(TOTAL) AS [Sum of TRI], ECOLOGY_REGION AS [ECY Region], SUBMISSION_REPORTING_YEAR, 
                      ECOLOGY_REGION, FS_ID, EPA_ID, COUNTY_NM, FAC_NAME, AgencyName,

						(
						SELECT COUNT(*) FROM dbo.V_EXT_MASTER AS TD2
						WHERE
							TD2.TRIFID = TD.TRIFID
						AND
							TD2.SUBMISSION_REPORTING_YEAR = TD.SUBMISSION_REPORTING_YEAR
						AND
							TD2.REPORT_TYPE = ''TRI_FORM_R''
						) AS CountFormR,
						(
						SELECT COUNT(*) FROM dbo.V_EXT_MASTER AS TD2
						WHERE
							TD2.TRIFID = TD.TRIFID
						AND
							TD2.SUBMISSION_REPORTING_YEAR = TD.SUBMISSION_REPORTING_YEAR
						AND
							TD2.REPORT_TYPE = ''TRI_FORM_A''
						) AS CountFormA

FROM         dbo.V_EXT_MASTER AS TD

GROUP BY FS_ID, EPA_ID, AgencyName, FAC_NAME, LOC_ADD_LINE_1_DS, LOC_ADD_LINE_2_DS, CITY_NM, COUNTY_NM, ZIP_CD, MAIL_PROVINCE_NM, 
                      MAIL_COUNTRY_CD, MAIL_ADD_LINE_1_DS, MAIL_ADD_LINE_2_DS, MAIL_CITY_NM, MAIL_ZIP_CD, MAIL_STATE_CD, TECH_CONTACT_NM, 
                      TECH_PHONE_NR, TRIFID, SUBMISSION_REPORTING_YEAR, ECOLOGY_REGION, FAC_NAICS_PRIMARY

'
GO
/****** Object:  View [dbo].[V_EXT_OFF_WT_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_OFF_WT_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the Waste Transfers extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_OFF_WT_D]
AS
SELECT     TL.PK_GUID, TL.FK_GUID, TD.FS_ID AS FSID, TD.EPA_ID AS [ECY ID], TD.TRIFID, TD.SUBMISSION_REPORTING_YEAR AS Year, 
                      TD.FAC_NAME AS [Facility Name], TD.AgencyName AS AKA, TD.LOC_ADD_LINE_1_DS AS [Address 1], TD.LOC_ADD_LINE_2_DS AS [Address 2], 
                      TD.CITY_NM AS City, TD.COUNTY_NM AS County, TD.ZIP_CD AS Zip, TD.CHEMICAL_NAME_TEXT AS Chemical, 
                      TL.RCRA_ID_CLBER AS [Trans RCRA ID], TL.FAC_SITE AS [Trans Facility Name], TL.LOC_ADD_TXT AS [Trans Address], TL.LOCALITY AS [Trans City], 
                      TL.STATE AS [Trans State], CASE WHEN TLQ.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, 
                      TLQ.WASTE_Q_RANGE_CODE) END AS [Trans Waste Total], TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code], 
                      TD.ECOLOGY_REGION AS [ECY Region], TD.SUBMISSION_REPORTING_YEAR, TD.ECOLOGY_REGION, TD.FS_ID, TD.EPA_ID, TD.COUNTY_NM, 
                      TD.FAC_NAME, TD.AgencyName, TD.CHEMICAL_NAME_TEXT
FROM         dbo.TRI_TRANSFER_LOC AS TL INNER JOIN
                      dbo.V_EXT_MASTER_D AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT INNER JOIN
                      dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
WHERE     (TD.REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_OFF_WT]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_OFF_WT]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2007-05-18
 Description:		Supports the Waste Transfers extract in the TRI Application. Excludes dioxins, results in pounds.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_OFF_WT]
AS
SELECT     TL.PK_GUID, TL.FK_GUID, TD.FS_ID AS FSID, TD.EPA_ID AS [ECY ID], TD.TRIFID, TD.SUBMISSION_REPORTING_YEAR AS Year, 
                      TD.FAC_NAME AS [Facility Name], TD.AgencyName AS AKA, TD.LOC_ADD_LINE_1_DS AS [Address 1], TD.LOC_ADD_LINE_2_DS AS [Address 2], 
                      TD.CITY_NM AS City, TD.COUNTY_NM AS County, TD.ZIP_CD AS Zip, TD.CHEMICAL_NAME_TEXT AS Chemical, 
                      TL.RCRA_ID_CLBER AS [Trans RCRA ID], TL.FAC_SITE AS [Trans Facility Name], TL.LOC_ADD_TXT AS [Trans Address], TL.LOCALITY AS [Trans City], 
                      TL.STATE AS [Trans State], CASE WHEN TLQ.WASTE_Q_NA_IND = ''Y'' THEN NULL ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, 
                      TLQ.WASTE_Q_RANGE_CODE) END AS [Trans Waste Total], TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code], 
                      TD.ECOLOGY_REGION AS [ECY Region], TD.SUBMISSION_REPORTING_YEAR, TD.ECOLOGY_REGION, TD.FS_ID, TD.EPA_ID, TD.COUNTY_NM, 
                      TD.FAC_NAME, TD.AgencyName, TD.CHEMICAL_NAME_TEXT
FROM         dbo.TRI_TRANSFER_LOC AS TL INNER JOIN
                      dbo.V_EXT_MASTER AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT INNER JOIN
                      dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
WHERE     (TD.REPORT_TYPE = ''TRI_FORM_R'')

'
GO
/****** Object:  View [dbo].[V_EXT_DIOXIN_OFF_WT_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DIOXIN_OFF_WT_D]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_DIOXIN_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2009-02-22
 Description:		Supports the Dioxin Waste Transfers extract in the TRI Application.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_DIOXIN_OFF_WT_D]
AS
SELECT
	TL.PK_GUID
,	TL.FK_GUID
,	TD.FS_ID AS FSID
,	TD.EPA_ID AS [ECY ID]
,	TD.TRIFID
,	TD.SUBMISSION_REPORTING_YEAR AS Year
,	TD.FAC_NAME AS [Facility Name]
,	TD.AgencyName AS AKA
,	TD.LOC_ADD_LINE_1_DS AS [Address 1]
,	TD.LOC_ADD_LINE_2_DS AS [Address 2]
,	TD.CITY_NM AS City
,	TD.COUNTY_NM AS County
,	TD.ZIP_CD AS Zip
,	TD.CHEMICAL_NAME_TEXT AS Chemical
,	TL.RCRA_ID_CLBER AS [Trans RCRA ID]
,	TL.FAC_SITE AS [Trans Facility Name]
,	TL.LOC_ADD_TXT AS [Trans Address]
,	TL.LOCALITY AS [Trans City]
,	TL.STATE AS [Trans State]
,	CASE
		WHEN TLQ.WASTE_Q_NA_IND = ''Y'' THEN NULL
		ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, TLQ.WASTE_Q_RANGE_CODE)
	END AS [Trans Waste Total]
,	TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code]
,	TLQ.TOX_EQ_VAL1 AS [TEQ_01]
,	TLQ.TOX_EQ_VAL2 AS [TEQ_02]
,	TLQ.TOX_EQ_VAL3 AS [TEQ_03]
,	TLQ.TOX_EQ_VAL4 AS [TEQ_04]
,	TLQ.TOX_EQ_VAL5 AS [TEQ_05]
,	TLQ.TOX_EQ_VAL6 AS [TEQ_06]
,	TLQ.TOX_EQ_VAL7 AS [TEQ_07]
,	TLQ.TOX_EQ_VAL8 AS [TEQ_08]
,	TLQ.TOX_EQ_VAL9 AS [TEQ_09]
,	TLQ.TOX_EQ_VAL10 AS [TEQ_10]
,	TLQ.TOX_EQ_VAL11 AS [TEQ_11]
,	TLQ.TOX_EQ_VAL12 AS [TEQ_12]
,	TLQ.TOX_EQ_VAL13 AS [TEQ_13]
,	TLQ.TOX_EQ_VAL14 AS [TEQ_14]
,	TLQ.TOX_EQ_VAL15 AS [TEQ_15]
,	TLQ.TOX_EQ_VAL16 AS [TEQ_16]
,	TLQ.TOX_EQ_VAL17 AS [TEQ_17]
,	TLQ.TOX_EQ_NA_IND AS [TEQ_NA]
,	TD.ECOLOGY_REGION AS [ECY Region]
,	TD.SUBMISSION_REPORTING_YEAR
,	TD.ECOLOGY_REGION
,	TD.FS_ID
,	TD.EPA_ID
,	TD.COUNTY_NM
,	TD.FAC_NAME
,	TD.AgencyName
,	TD.CHEMICAL_NAME_TEXT

FROM dbo.TRI_TRANSFER_LOC AS TL
JOIN dbo.V_EXT_MASTER_D AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT
JOIN dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
WHERE
TD.REPORT_TYPE = ''TRI_FORM_R''
AND
TD.CAS_NUMBER = ''N150''
'
GO
/****** Object:  View [dbo].[V_EXT_DIOXIN_OFF_WT]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DIOXIN_OFF_WT]'))
EXEC dbo.sp_executesql @statement = N'/* =============================================
 Full Name:		V_EXTRACT_DIOXIN_OFFSITE_WASTE_TRANSFERS
 Condensed Name:	V_EXT_OFF_WT
 Author:			TK Conrad
 ALTER  date:		2009-02-22
 Description:		Supports the Dioxin Waste Transfers extract in the TRI Application.
 WHERE RIGHT(TD.REPORT_TYPE, 1) <> ''A''*/
CREATE VIEW [dbo].[V_EXT_DIOXIN_OFF_WT]
AS
SELECT
	TL.PK_GUID
,	TL.FK_GUID
,	TD.FS_ID AS FSID
,	TD.EPA_ID AS [ECY ID]
,	TD.TRIFID
,	TD.SUBMISSION_REPORTING_YEAR AS Year
,	TD.FAC_NAME AS [Facility Name]
,	TD.AgencyName AS AKA
,	TD.LOC_ADD_LINE_1_DS AS [Address 1]
,	TD.LOC_ADD_LINE_2_DS AS [Address 2]
,	TD.CITY_NM AS City
,	TD.COUNTY_NM AS County
,	TD.ZIP_CD AS Zip
,	TD.CHEMICAL_NAME_TEXT AS Chemical
,	TL.RCRA_ID_CLBER AS [Trans RCRA ID]
,	TL.FAC_SITE AS [Trans Facility Name]
,	TL.LOC_ADD_TXT AS [Trans Address]
,	TL.LOCALITY AS [Trans City]
,	TL.STATE AS [Trans State]
,	CASE
		WHEN TLQ.WASTE_Q_NA_IND = ''Y'' THEN NULL
		ELSE dbo.TRI_RangeCodeConversion(TLQ.WASTE_Q_ME, TLQ.WASTE_Q_RANGE_CODE)
	END AS [Trans Waste Total]
,	TLQ.WASTE_MANAGEMENT_CODE AS [Waste Mgmt Code]
,	TLQ.TOX_EQ_VAL1 AS [TEQ_01]
,	TLQ.TOX_EQ_VAL2 AS [TEQ_02]
,	TLQ.TOX_EQ_VAL3 AS [TEQ_03]
,	TLQ.TOX_EQ_VAL4 AS [TEQ_04]
,	TLQ.TOX_EQ_VAL5 AS [TEQ_05]
,	TLQ.TOX_EQ_VAL6 AS [TEQ_06]
,	TLQ.TOX_EQ_VAL7 AS [TEQ_07]
,	TLQ.TOX_EQ_VAL8 AS [TEQ_08]
,	TLQ.TOX_EQ_VAL9 AS [TEQ_09]
,	TLQ.TOX_EQ_VAL10 AS [TEQ_10]
,	TLQ.TOX_EQ_VAL11 AS [TEQ_11]
,	TLQ.TOX_EQ_VAL12 AS [TEQ_12]
,	TLQ.TOX_EQ_VAL13 AS [TEQ_13]
,	TLQ.TOX_EQ_VAL14 AS [TEQ_14]
,	TLQ.TOX_EQ_VAL15 AS [TEQ_15]
,	TLQ.TOX_EQ_VAL16 AS [TEQ_16]
,	TLQ.TOX_EQ_VAL17 AS [TEQ_17]
,	TLQ.TOX_EQ_NA_IND AS [TEQ_NA]
,	TD.ECOLOGY_REGION AS [ECY Region]
,	TD.SUBMISSION_REPORTING_YEAR
,	TD.ECOLOGY_REGION
,	TD.FS_ID
,	TD.EPA_ID
,	TD.COUNTY_NM
,	TD.FAC_NAME
,	TD.AgencyName
,	TD.CHEMICAL_NAME_TEXT

FROM dbo.TRI_TRANSFER_LOC AS TL
JOIN dbo.V_EXT_MASTER_D AS TD ON TL.FK_GUID = TD.PK_GUID_REPORT
JOIN dbo.TRI_TRANSFER_Q AS TLQ ON TLQ.FK_GUID = TL.PK_GUID
WHERE
TD.REPORT_TYPE = ''TRI_FORM_R''
AND
TD.CAS_NUMBER <> ''N150''
'
GO
/****** Object:  View [dbo].[V_TRI_PAGE4]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE4]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE4]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R7A1A, R7A1B1, R7A1B2, R7A1B3, 
 R7A1B4, R7A1B5, R7A1B6, R7A1B7, R7A1B8, 
 R7A1C, R7A1D, R7A1E, R7A2A, R7A2B1, 
 R7A2B2, R7A2B3, R7A2B4, R7A2B5, R7A2B6, 
 R7A2B7, R7A2B8, R7A2C, R7A2D, R7A2E, 
 R7A3A, R7A3B1, R7A3B2, R7A3B3, R7A3B4, 
 R7A3B5, R7A3B6, R7A3B7, R7A3B8, R7A3C, 
 R7A3D, R7A3E, R7A4A, R7A4B1, R7A4B2, 
 R7A4B3, R7A4B4, R7A4B5, R7A4B6, R7A4B7, 
 R7A4B8, R7A4C, R7A4D, R7A4E, R7A5A, 
 R7A5B1, R7A5B2, R7A5B3, R7A5B4, R7A5B5, 
 R7A5B6, R7A5B7, R7A5B8, R7A5C, R7A5D, 
 R7A5E)
AS
SELECT
S.PK_GUID AS PK_GUID_SUB,
R7A1.FK_GUID AS PK_GUID_REP,
F.FAC_ID,
C.CHEM_TXT,
R7A1.R7AA R7A1A,
R7A1.R7AB1 R7A1B1,
R7A1.R7AB2 R7A1B2,
R7A1.R7AB3 R7A1B3,
R7A1.R7AB4 R7A1B4,
R7A1.R7AB5 R7A1B5,
R7A1.R7AB6 R7A1B6,
R7A1.R7AB7 R7A1B7,
R7A1.R7AB8 R7A1B8,
R7A1.R7AC R7A1C,
R7A1.R7AD R7A1D,
R7A1.R7AE R7A1E,
R7A2.R7AA R7A2A,
R7A2.R7AB1 R7A2B1,
R7A2.R7AB2 R7A2B2,
R7A2.R7AB3 R7A2B3,
R7A2.R7AB4 R7A2B4,
R7A2.R7AB5 R7A2B5,
R7A2.R7AB6 R7A2B6,
R7A2.R7AB7 R7A2B7,
R7A2.R7AB8 R7A2B8,
R7A2.R7AC R7A2C,
R7A2.R7AD R7A2D,
R7A2.R7AE R7A2E,
R7A3.R7AA R7A3A,
R7A3.R7AB1 R7A3B1,
R7A3.R7AB2 R7A3B2,
R7A3.R7AB3 R7A3B3,
R7A3.R7AB4 R7A3B4,
R7A3.R7AB5 R7A3B5,
R7A3.R7AB6 R7A3B6,
R7A3.R7AB7 R7A3B7,
R7A3.R7AB8 R7A3B8,
R7A3.R7AC R7A3C,
R7A3.R7AD R7A3D,
R7A3.R7AE R7A3E,
R7A4.R7AA R7A4A,
R7A4.R7AB1 R7A4B1,
R7A4.R7AB2 R7A4B2,
R7A4.R7AB3 R7A4B3,
R7A4.R7AB4 R7A4B4,
R7A4.R7AB5 R7A4B5,
R7A4.R7AB6 R7A4B6,
R7A4.R7AB7 R7A4B7,
R7A4.R7AB8 R7A4B8,
R7A4.R7AC R7A4C,
R7A4.R7AD R7A4D,
R7A4.R7AE R7A4E,
R7A5.R7AA R7A5A,
R7A5.R7AB1 R7A5B1,
R7A5.R7AB2 R7A5B2,
R7A5.R7AB3 R7A5B3,
R7A5.R7AB4 R7A5B4,
R7A5.R7AB5 R7A5B5,
R7A5.R7AB6 R7A5B6,
R7A5.R7AB7 R7A5B7,
R7A5.R7AB8 R7A5B8,
R7A5.R7AC R7A5C,
R7A5.R7AD R7A5D,
R7A5.R7AE R7A5E
FROM
(SELECT FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, R7AC, R7AD, R7AE
		FROM V_TRI_PG4_7A WHERE NUM = 1) R7A1
LEFT OUTER JOIN
(SELECT FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, R7AC, R7AD, R7AE
		FROM V_TRI_PG4_7A WHERE NUM = 2) R7A2
		ON R7A1.FK_GUID = R7A2.FK_GUID
LEFT OUTER JOIN
(SELECT FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, R7AC, R7AD, R7AE
		FROM V_TRI_PG4_7A WHERE NUM = 3) R7A3
		ON R7A1.FK_GUID = R7A3.FK_GUID
LEFT OUTER JOIN
(SELECT FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, R7AC, R7AD, R7AE
		FROM V_TRI_PG4_7A WHERE NUM = 4) R7A4
		ON R7A1.FK_GUID = R7A4.FK_GUID
LEFT OUTER JOIN
(SELECT FK_GUID, R7AA, R7AB1, R7AB2, R7AB3, R7AB4, R7AB5, R7AB6, R7AB7, R7AB8, R7AC, R7AD, R7AE
		FROM V_TRI_PG4_7A WHERE NUM = 5) R7A5
		ON R7A1.FK_GUID = R7A5.FK_GUID
LEFT JOIN TRI_REPORT R
	JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
	JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
	JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
ON R7A1.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_PG5_810]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PG5_810]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PG5_810]
(PK_GUID, R810VALUE, R810A, R810B, R810C, NUM)
AS
SELECT TOP 99999999 R.PK_GUID,
       SRC_RED_ACT_CODE R810VALUE,
		(SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 1)  R810A,
		(SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 2)  R810B,
		(SELECT SRC_RED_METH_CODE FROM V_TRI_PG5_810A M WHERE M.FK_GUID = S.PK_GUID AND NUM = 3) R810C,
	   (SELECT COUNT (*)
             FROM TRI_SRC_RED_ACT S2
            WHERE S2.FK_GUID = S.FK_GUID
              AND S2.PK_GUID <= S.PK_GUID) NUM
  FROM TRI_REPORT R INNER JOIN TRI_SRC_RED_ACT S ON S.FK_GUID = R.PK_GUID
  ORDER BY SRC_RED_SEQ_CL

'
GO
/****** Object:  View [dbo].[V_TRI_PAGE3]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE3]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE3]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R541A, R541B, R542A, R542B, 
 R551AA, R551AB, R551BA, R551BB, R552AA, 
 R552AB, R5553AA, R5553AB, R553BA, R553BB, 
 R554A, R554B, R61A1, R61A2, R61B1NAME, 
 R61B1ADDRESS, R61B1CITY, R61B1STATE, R61B1COUNTY, R61B1ZIP, 
 R61B2NAME, R61B2ADDRESS, R61B2CITY, R61B2STATE, R61B2COUNTY, 
 R61B2ZIP, R621RCRAID, R621NAME, R621ADDRESS, R621CITY, 
 R621STATE, R621COUNTY, R621ZIP, R621LOCATIONCONTROL, R621A1, 
 R621B1, R621C1, R621A2, R621B2, R621C2, 
 R621A3, R621B3, R621C3, R621A4, R621B4, 
 R621C4, R622RCRAID, R622NAME, R622ADDRESS, R622CITY, 
 R622STATE, R622COUNTY, R622ZIP, R622LOCATIONCONTROL, R622A1, 
 R622B1, R622C1, R622A2, R622B2, R622C2, 
 R622A3, R622B3, R622C3, R622A4, R622B4, 
 R622C4)
AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       F.FAC_ID,
       C.CHEM_TXT,
       COALESCE (REL1.WASTE_Q_RANGE_CODE, REL1.WASTE_Q_ME) R541A,
       REL1.Q_BASIS_EST_CD R541B,
       COALESCE (REL2.WASTE_Q_RANGE_CODE, REL2.WASTE_Q_ME) R542A,
       REL2.Q_BASIS_EST_CD R542B,
       COALESCE (REL3.WASTE_Q_RANGE_CODE, REL3.WASTE_Q_ME) R551AA,
       REL3.Q_BASIS_EST_CD R551AB,
       COALESCE (REL4.WASTE_Q_RANGE_CODE, REL4.WASTE_Q_ME) R551BA,
       REL4.Q_BASIS_EST_CD R551BB,
       COALESCE (REL5.WASTE_Q_RANGE_CODE, REL5.WASTE_Q_ME) R552AA,
       REL5.Q_BASIS_EST_CD R552AB,
       COALESCE (REL6.WASTE_Q_RANGE_CODE, REL6.WASTE_Q_ME) R5553AA,
       REL6.Q_BASIS_EST_CD R5553AB,
       COALESCE (REL7.WASTE_Q_RANGE_CODE, REL7.WASTE_Q_ME) R553BA,
       REL7.Q_BASIS_EST_CD R553BB,
       COALESCE (REL8.WASTE_Q_RANGE_CODE, REL8.WASTE_Q_ME) R554A,
       REL8.Q_BASIS_EST_CD R554B,
       COALESCE (R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) R61A1,
       R.Q_BASIS_EST_CODE R61A2,
       POTW1.FAC_SITE R61B1NAME,
       POTW1.LOC_ADD_TXT R61B1ADDRESS,
       POTW1.LOCALITY R61B1CITY,
       POTW1.STATE R61B1STATE,
       POTW1.COUNTY R61B1COUNTY,
       POTW1.ADD_POSTAL_CODE R61B1ZIP,
       POTW2.FAC_SITE R61B2NAME,
       POTW2.LOC_ADD_TXT R61B2ADDRESS,
       POTW2.LOCALITY R61B2CITY,
       POTW2.STATE R61B2STATE,
       POTW2.COUNTY R61B2COUNTY,
       POTW2.ADD_POSTAL_CODE R61B2ZIP,
       SITE1.RCRA_ID_CLBER R621RCRAID,
       SITE1.FAC_SITE R621NAME,
       SITE1.LOC_ADD_TXT R621ADDRESS,
       SITE1.LOCALITY R621CITY,
       SITE1.STATE R621STATE,
       SITE1.COUNTY R621COUNTY,
       SITE1.ADD_POSTAL_CODE R621ZIP,
       SITE1.CONTROLLED_LOC_IND R621LOCATIONCONTROL,
       R621A1,
       R621B1,
       R621C1,
       R621A2,
       R621B2,
       R621C2,
       R621A3,
       R621B3,
       R621C3,
       R621A4,
       R621B4,
       R621C4,
       SITE2.RCRA_ID_CLBER R622RCRAID,
       SITE2.FAC_SITE R622NAME,
       SITE2.LOC_ADD_TXT R622ADDRESS,
       SITE2.LOCALITY R622CITY,
       SITE2.STATE R622STATE,
       SITE2.COUNTY R622COUNTY,
       SITE2.ADD_POSTAL_CODE R622ZIP,
       SITE2.CONTROLLED_LOC_IND R622LOCATIONCONTROL,
       R622A1,
       R622B1,
       R622C1,
       R622A2,
       R622B2,
       R622C2,
       R622A3,
       R622B3,
       R622C3,
       R622A4,
       R622B4,
       R622C4
  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = ''Y''
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = ''Y''
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 1) POTW1 ON POTW1.FK_GUID = R.PK_GUID
--                                 AND T2.FAC_SITE + T2.LOC_ADD_TXT <= T.FAC_SITE + T.LOC_ADD_TXT) = 1) POTW1 ON POTW1.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = ''Y''
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = ''Y''
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 2) POTW2 ON POTW2.FK_GUID = R.PK_GUID
--                                 AND T2.FAC_SITE + T2.LOC_ADD_TXT <= T.FAC_SITE + T.LOC_ADD_TXT) = 1) POTW1 ON POTW1.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               RCRA_ID_CLBER,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE,
                               CONTROLLED_LOC_IND,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621A1,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621B1,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R621C1,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621A2,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621B2,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R621C2,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621A3,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621B3,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R621C3,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621A4,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621B4,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R621C4
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = ''N''
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = ''N''
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 1) SITE1 ON SITE1.FK_GUID = R.PK_GUID
--                                 AND T2.FAC_SITE + T2.LOC_ADD_TXT <= T.FAC_SITE + T.LOC_ADD_TXT) = 1) POTW1 ON POTW1.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN (SELECT FK_GUID,
                               RCRA_ID_CLBER,
                               FAC_SITE,
                               LOC_ADD_TXT,
                               LOCALITY,
                               STATE,
                               COUNTY,
                               ADD_POSTAL_CODE,
                               CONTROLLED_LOC_IND,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622A1,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622B1,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 1) R622C1,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622A2,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622B2,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 2) R622C2,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622A3,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622B3,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 3) R622C3,
                               (SELECT R62A
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622A4,
                               (SELECT R62B
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622B4,
                               (SELECT R62C
                                  FROM V_TRI_PG4_62L TQ
                                 WHERE TQ.FK_GUID = T.PK_GUID
                                   AND NUM = 4) R622C4
                          FROM TRI_TRANSFER_LOC T
                         WHERE POTW_IND = ''N''
                           AND (SELECT COUNT (*)
                                  FROM TRI_TRANSFER_LOC T2
                                 WHERE T.FK_GUID = T2.FK_GUID
                                   AND T2.POTW_IND = ''N''
                                   AND CAST(T2.TRANSFER_LOC_SEQ_CL AS INT) <= CAST(T.TRANSFER_LOC_SEQ_CL AS INT)) = 2) SITE2 ON SITE2.FK_GUID = R.PK_GUID
--                                 AND T2.FAC_SITE + T2.LOC_ADD_TXT <= T.FAC_SITE + T.LOC_ADD_TXT) = 2) SITE2 ON SITE2.FK_GUID = R.PK_GUID
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL1 ON REL1.FK_GUID = R.PK_GUID
                                               AND REL1.EI_MEDIUM_CODE = ''UNINJ I''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL2 ON REL2.FK_GUID = R.PK_GUID
                                               AND REL2.EI_MEDIUM_CODE = ''UNINJ IIV''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL3 ON REL3.FK_GUID = R.PK_GUID
                                               AND REL3.EI_MEDIUM_CODE = ''RCRA C''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL4 ON REL4.FK_GUID = R.PK_GUID
                                               AND REL4.EI_MEDIUM_CODE = ''OTH LANDF''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL5 ON REL5.FK_GUID = R.PK_GUID
                                               AND REL5.EI_MEDIUM_CODE = ''LAND TREA''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL6 ON REL6.FK_GUID = R.PK_GUID
                                               AND REL6.EI_MEDIUM_CODE = ''SI 5.5.3A''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL7 ON REL7.FK_GUID = R.PK_GUID
                                               AND REL7.EI_MEDIUM_CODE = ''SI 5.5.3B''
       LEFT OUTER JOIN TRI_ONSITE_RELEASE_Q REL8 ON REL8.FK_GUID = R.PK_GUID
                                               AND REL8.EI_MEDIUM_CODE = ''OTH DISP''

'
GO
/****** Object:  View [dbo].[V_RPT_TOP_TEN_FACILITIES]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_TOP_TEN_FACILITIES]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_RPT_TOP_TEN_FACILITIES]

AS

SELECT TOP 10

	SUBQ.FAC_ID			AS ''TRIFID''
,	SUBQ.SUB_REP_YEAR	AS ''Reporting Year''
,	SUBQ.FAC_SITE		AS ''Facility Name''
,	SUBQ.LBS			AS ''Total Pounds''

FROM
	(
	SELECT
		F.FAC_ID
	,	R.SUB_REP_YEAR
	,	F.FAC_SITE
	,	dbo.TRI_CalcLbsPerFacYr(F.FAC_ID, R.SUB_REP_YEAR) LBS

	FROM TRI_SUB S
	JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
	JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
	JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

	WHERE R.REPORT_TYPE_CODE = ''TRI_FORM_R''
	AND C.CAS_CLBER <> ''N150''
	AND R.SUB_REP_YEAR =
	(
	SELECT MAX(SUB_REP_YEAR) FROM TRI_REPORT
	)
	
	GROUP BY
		F.FAC_ID
	,	F.FAC_SITE
	,	R.SUB_REP_YEAR
	) SUBQ

ORDER BY SUBQ.LBS DESC

'
GO
/****** Object:  View [dbo].[V_RPT_TOP_TEN_DIFFERENCES]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_RPT_TOP_TEN_DIFFERENCES]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_RPT_TOP_TEN_DIFFERENCES]

AS

SELECT TOP 10

	SUBQ.FAC_ID														AS ''TRIFID''
,	SUBQ.SUB_REP_YEAR												AS ''Reporting Year''
,	SUBQ.FAC_SITE													AS ''Facility Name''
,	SUBQ.ALLRECD													AS ''All Chemicals Recd''
,	SUBQ.NEWSUB														AS ''New Submission''
,	SUBQ.DIFF														AS ''Total Lbs Difference''

FROM
(
SELECT DISTINCT
	F.FAC_ID
,	R.SUB_REP_YEAR
,	F.FAC_SITE
,	CASE
		WHEN NOT EXISTS
			(
			SELECT *
			FROM TRI_SUB S2
			JOIN TRI_FAC F2 ON F2.FK_GUID = S2.PK_GUID
			JOIN TRI_REPORT R2 ON R2.FK_GUID = S2.PK_GUID
			JOIN TRI_CHEM C2 ON C2.FK_GUID = R2.PK_GUID
			WHERE
				F2.FAC_ID = F.FAC_ID
				AND
				C2.CHEM_TXT = C.CHEM_TXT
				AND
				CAST(R2.SUB_REP_YEAR AS INT) = CAST(R.SUB_REP_YEAR AS INT) - 1
			)
		AND EXISTS
			(
			SELECT *
			FROM TRI_SUB S3
			JOIN TRI_FAC F3 ON F3.FK_GUID = S3.PK_GUID
			JOIN TRI_REPORT R3 ON R3.FK_GUID = S3.PK_GUID
			WHERE
				F3.FAC_ID = F.FAC_ID
				AND
				CAST(R3.SUB_REP_YEAR AS INT) = CAST(R.SUB_REP_YEAR AS INT) - 1
			)
		THEN ''N''
		ELSE ''Y''
	END AS ALLRECD
,	CASE
		WHEN NOT EXISTS
			(
			SELECT *
			FROM TRI_SUB S4
			JOIN TRI_FAC F4 ON F4.FK_GUID = S4.PK_GUID
			JOIN TRI_REPORT R4 ON R4.FK_GUID = S4.PK_GUID
			WHERE
				F4.FAC_ID = F.FAC_ID
				AND
				CAST(R4.SUB_REP_YEAR AS INT) = CAST(R.SUB_REP_YEAR AS INT) - 1
			)
		THEN ''Y''
		ELSE ''N''
	END AS NEWSUB
,	dbo.TRI_CalcLbsPerFacYr(F.FAC_ID, R.SUB_REP_YEAR)
	-
	dbo.TRI_CalcLbsPerFacYr(F.FAC_ID, (R.SUB_REP_YEAR - 1))			AS DIFF

	FROM TRI_SUB S
	JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
	JOIN TRI_REPORT R ON R.FK_GUID = S.PK_GUID
	JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

	WHERE R.REPORT_TYPE_CODE = ''TRI_FORM_R''
	AND C.CAS_CLBER <> ''N150''
	AND R.SUB_REP_YEAR =
	(
	SELECT MAX(SUB_REP_YEAR) FROM TRI_REPORT
	)
) SUBQ

ORDER BY ABS(SUBQ.DIFF) DESC

'
GO
/****** Object:  View [dbo].[V_FORM_S1_PG3]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_FORM_S1_PG3]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_FORM_S1_PG3]

AS
SELECT
       S.PK_GUID AS PK_GUID_SUB,
       R.PK_GUID AS PK_GUID_REP,
       F.FAC_ID,
       C.CHEM_TXT,

       R.TOX_EQ_NA_IND_POTW S161A3NA,
       R.TOX_EQ_VAL1_POTW S161A3T1,
       R.TOX_EQ_VAL2_POTW S161A3T2,
       R.TOX_EQ_VAL3_POTW S161A3T3,
       R.TOX_EQ_VAL4_POTW S161A3T4,
       R.TOX_EQ_VAL5_POTW S161A3T5,
       R.TOX_EQ_VAL6_POTW S161A3T6,
       R.TOX_EQ_VAL7_POTW S161A3T7,
       R.TOX_EQ_VAL8_POTW S161A3T8,
       R.TOX_EQ_VAL9_POTW S161A3T9,
       R.TOX_EQ_VAL10_POTW S161A3T10,
       R.TOX_EQ_VAL11_POTW S161A3T11,
       R.TOX_EQ_VAL12_POTW S161A3T12,
       R.TOX_EQ_VAL13_POTW S161A3T13,
       R.TOX_EQ_VAL14_POTW S161A3T14,
       R.TOX_EQ_VAL15_POTW S161A3T15,
       R.TOX_EQ_VAL16_POTW S161A3T16,
       R.TOX_EQ_VAL17_POTW S161A3T17,

       S1621N1.TRANSFER_LOC_SEQ_CL S1621_TRANS_LOC_SEQ,

       S1621N1.TOX_EQ_NA_IND S1621N1NA,
       S1621N1.TOX_EQ_VAL1 S1621N1T1,
       S1621N1.TOX_EQ_VAL2 S1621N1T2,
       S1621N1.TOX_EQ_VAL3 S1621N1T3,
       S1621N1.TOX_EQ_VAL4 S1621N1T4,
       S1621N1.TOX_EQ_VAL5 S1621N1T5,
       S1621N1.TOX_EQ_VAL6 S1621N1T6,
       S1621N1.TOX_EQ_VAL7 S1621N1T7,
       S1621N1.TOX_EQ_VAL8 S1621N1T8,
       S1621N1.TOX_EQ_VAL9 S1621N1T9,
       S1621N1.TOX_EQ_VAL10 S1621N1T10,
       S1621N1.TOX_EQ_VAL11 S1621N1T11,
       S1621N1.TOX_EQ_VAL12 S1621N1T12,
       S1621N1.TOX_EQ_VAL13 S1621N1T13,
       S1621N1.TOX_EQ_VAL14 S1621N1T14,
       S1621N1.TOX_EQ_VAL15 S1621N1T15,
       S1621N1.TOX_EQ_VAL16 S1621N1T16,
       S1621N1.TOX_EQ_VAL17 S1621N1T17,

       S1621N2.TOX_EQ_NA_IND S1621N2NA,
       S1621N2.TOX_EQ_VAL1 S1621N2T1,
       S1621N2.TOX_EQ_VAL2 S1621N2T2,
       S1621N2.TOX_EQ_VAL3 S1621N2T3,
       S1621N2.TOX_EQ_VAL4 S1621N2T4,
       S1621N2.TOX_EQ_VAL5 S1621N2T5,
       S1621N2.TOX_EQ_VAL6 S1621N2T6,
       S1621N2.TOX_EQ_VAL7 S1621N2T7,
       S1621N2.TOX_EQ_VAL8 S1621N2T8,
       S1621N2.TOX_EQ_VAL9 S1621N2T9,
       S1621N2.TOX_EQ_VAL10 S1621N2T10,
       S1621N2.TOX_EQ_VAL11 S1621N2T11,
       S1621N2.TOX_EQ_VAL12 S1621N2T12,
       S1621N2.TOX_EQ_VAL13 S1621N2T13,
       S1621N2.TOX_EQ_VAL14 S1621N2T14,
       S1621N2.TOX_EQ_VAL15 S1621N2T15,
       S1621N2.TOX_EQ_VAL16 S1621N2T16,
       S1621N2.TOX_EQ_VAL17 S1621N2T17,

       S1621N3.TOX_EQ_NA_IND S1621N3NA,
       S1621N3.TOX_EQ_VAL1 S1621N3T1,
       S1621N3.TOX_EQ_VAL2 S1621N3T2,
       S1621N3.TOX_EQ_VAL3 S1621N3T3,
       S1621N3.TOX_EQ_VAL4 S1621N3T4,
       S1621N3.TOX_EQ_VAL5 S1621N3T5,
       S1621N3.TOX_EQ_VAL6 S1621N3T6,
       S1621N3.TOX_EQ_VAL7 S1621N3T7,
       S1621N3.TOX_EQ_VAL8 S1621N3T8,
       S1621N3.TOX_EQ_VAL9 S1621N3T9,
       S1621N3.TOX_EQ_VAL10 S1621N3T10,
       S1621N3.TOX_EQ_VAL11 S1621N3T11,
       S1621N3.TOX_EQ_VAL12 S1621N3T12,
       S1621N3.TOX_EQ_VAL13 S1621N3T13,
       S1621N3.TOX_EQ_VAL14 S1621N3T14,
       S1621N3.TOX_EQ_VAL15 S1621N3T15,
       S1621N3.TOX_EQ_VAL16 S1621N3T16,
       S1621N3.TOX_EQ_VAL17 S1621N3T17,

       S1621N4.TOX_EQ_NA_IND S1621N4NA,
       S1621N4.TOX_EQ_VAL1 S1621N4T1,
       S1621N4.TOX_EQ_VAL2 S1621N4T2,
       S1621N4.TOX_EQ_VAL3 S1621N4T3,
       S1621N4.TOX_EQ_VAL4 S1621N4T4,
       S1621N4.TOX_EQ_VAL5 S1621N4T5,
       S1621N4.TOX_EQ_VAL6 S1621N4T6,
       S1621N4.TOX_EQ_VAL7 S1621N4T7,
       S1621N4.TOX_EQ_VAL8 S1621N4T8,
       S1621N4.TOX_EQ_VAL9 S1621N4T9,
       S1621N4.TOX_EQ_VAL10 S1621N4T10,
       S1621N4.TOX_EQ_VAL11 S1621N4T11,
       S1621N4.TOX_EQ_VAL12 S1621N4T12,
       S1621N4.TOX_EQ_VAL13 S1621N4T13,
       S1621N4.TOX_EQ_VAL14 S1621N4T14,
       S1621N4.TOX_EQ_VAL15 S1621N4T15,
       S1621N4.TOX_EQ_VAL16 S1621N4T16,
       S1621N4.TOX_EQ_VAL17 S1621N4T17,

       S1622N1.TRANSFER_LOC_SEQ_CL S1622_TRANS_LOC_SEQ,

       S1622N1.TOX_EQ_NA_IND S1622N1NA,
       S1622N1.TOX_EQ_VAL1 S1622N1T1,
       S1622N1.TOX_EQ_VAL2 S1622N1T2,
       S1622N1.TOX_EQ_VAL3 S1622N1T3,
       S1622N1.TOX_EQ_VAL4 S1622N1T4,
       S1622N1.TOX_EQ_VAL5 S1622N1T5,
       S1622N1.TOX_EQ_VAL6 S1622N1T6,
       S1622N1.TOX_EQ_VAL7 S1622N1T7,
       S1622N1.TOX_EQ_VAL8 S1622N1T8,
       S1622N1.TOX_EQ_VAL9 S1622N1T9,
       S1622N1.TOX_EQ_VAL10 S1622N1T10,
       S1622N1.TOX_EQ_VAL11 S1622N1T11,
       S1622N1.TOX_EQ_VAL12 S1622N1T12,
       S1622N1.TOX_EQ_VAL13 S1622N1T13,
       S1622N1.TOX_EQ_VAL14 S1622N1T14,
       S1622N1.TOX_EQ_VAL15 S1622N1T15,
       S1622N1.TOX_EQ_VAL16 S1622N1T16,
       S1622N1.TOX_EQ_VAL17 S1622N1T17,

       S1622N2.TOX_EQ_NA_IND S1622N2NA,
       S1622N2.TOX_EQ_VAL1 S1622N2T1,
       S1622N2.TOX_EQ_VAL2 S1622N2T2,
       S1622N2.TOX_EQ_VAL3 S1622N2T3,
       S1622N2.TOX_EQ_VAL4 S1622N2T4,
       S1622N2.TOX_EQ_VAL5 S1622N2T5,
       S1622N2.TOX_EQ_VAL6 S1622N2T6,
       S1622N2.TOX_EQ_VAL7 S1622N2T7,
       S1622N2.TOX_EQ_VAL8 S1622N2T8,
       S1622N2.TOX_EQ_VAL9 S1622N2T9,
       S1622N2.TOX_EQ_VAL10 S1622N2T10,
       S1622N2.TOX_EQ_VAL11 S1622N2T11,
       S1622N2.TOX_EQ_VAL12 S1622N2T12,
       S1622N2.TOX_EQ_VAL13 S1622N2T13,
       S1622N2.TOX_EQ_VAL14 S1622N2T14,
       S1622N2.TOX_EQ_VAL15 S1622N2T15,
       S1622N2.TOX_EQ_VAL16 S1622N2T16,
       S1622N2.TOX_EQ_VAL17 S1622N2T17,

       S1622N3.TOX_EQ_NA_IND S1622N3NA,
       S1622N3.TOX_EQ_VAL1 S1622N3T1,
       S1622N3.TOX_EQ_VAL2 S1622N3T2,
       S1622N3.TOX_EQ_VAL3 S1622N3T3,
       S1622N3.TOX_EQ_VAL4 S1622N3T4,
       S1622N3.TOX_EQ_VAL5 S1622N3T5,
       S1622N3.TOX_EQ_VAL6 S1622N3T6,
       S1622N3.TOX_EQ_VAL7 S1622N3T7,
       S1622N3.TOX_EQ_VAL8 S1622N3T8,
       S1622N3.TOX_EQ_VAL9 S1622N3T9,
       S1622N3.TOX_EQ_VAL10 S1622N3T10,
       S1622N3.TOX_EQ_VAL11 S1622N3T11,
       S1622N3.TOX_EQ_VAL12 S1622N3T12,
       S1622N3.TOX_EQ_VAL13 S1622N3T13,
       S1622N3.TOX_EQ_VAL14 S1622N3T14,
       S1622N3.TOX_EQ_VAL15 S1622N3T15,
       S1622N3.TOX_EQ_VAL16 S1622N3T16,
       S1622N3.TOX_EQ_VAL17 S1622N3T17,

       S1622N4.TOX_EQ_NA_IND S1622N4NA,
       S1622N4.TOX_EQ_VAL1 S1622N4T1,
       S1622N4.TOX_EQ_VAL2 S1622N4T2,
       S1622N4.TOX_EQ_VAL3 S1622N4T3,
       S1622N4.TOX_EQ_VAL4 S1622N4T4,
       S1622N4.TOX_EQ_VAL5 S1622N4T5,
       S1622N4.TOX_EQ_VAL6 S1622N4T6,
       S1622N4.TOX_EQ_VAL7 S1622N4T7,
       S1622N4.TOX_EQ_VAL8 S1622N4T8,
       S1622N4.TOX_EQ_VAL9 S1622N4T9,
       S1622N4.TOX_EQ_VAL10 S1622N4T10,
       S1622N4.TOX_EQ_VAL11 S1622N4T11,
       S1622N4.TOX_EQ_VAL12 S1622N4T12,
       S1622N4.TOX_EQ_VAL13 S1622N4T13,
       S1622N4.TOX_EQ_VAL14 S1622N4T14,
       S1622N4.TOX_EQ_VAL15 S1622N4T15,
       S1622N4.TOX_EQ_VAL16 S1622N4T16,
       S1622N4.TOX_EQ_VAL17 S1622N4T17

  FROM TRI_REPORT R INNER JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
       INNER JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
       INNER JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1621N1 ON
                S1621N1.PK_GUID = R.PK_GUID
           AND  S1621N1.LOC_NUM = 1
           AND  S1621N1.NUM = 1

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1621N2 ON
                S1621N2.PK_GUID = R.PK_GUID
           AND  S1621N2.LOC_NUM = 1
           AND  S1621N2.NUM = 2

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1621N3 ON
                S1621N3.PK_GUID = R.PK_GUID
           AND  S1621N3.LOC_NUM = 1
           AND  S1621N3.NUM = 3

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1621N4 ON
                S1621N4.PK_GUID = R.PK_GUID
           AND  S1621N4.LOC_NUM = 1
           AND  S1621N4.NUM = 4

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1622N1 ON
                S1622N1.PK_GUID = R.PK_GUID
           AND  S1622N1.LOC_NUM = 2
           AND  S1622N1.NUM = 1

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1622N2 ON
                S1622N2.PK_GUID = R.PK_GUID
           AND  S1622N2.LOC_NUM = 2
           AND  S1622N2.NUM = 2

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1622N3 ON
                S1622N3.PK_GUID = R.PK_GUID
           AND  S1622N3.LOC_NUM = 2
           AND  S1622N3.NUM = 3

       LEFT OUTER JOIN dbo.V_FORM_S1_PG3_62 S1622N4 ON
                S1622N4.PK_GUID = R.PK_GUID
           AND  S1622N4.LOC_NUM = 2
           AND  S1622N4.NUM = 4

'
GO
/****** Object:  View [dbo].[V_TRI_PAGE5]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_PAGE5]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_TRI_PAGE5]
(PK_GUID_SUB, PK_GUID_REP, FAC_ID, CHEM_TXT, R7B1, R7B2, R7B3, R7C1, 
 R7C2, R7C3, R7C4, R7C5, R7C6, 
 R7C7, R7C8, R7C9, R7C10, R81AA, 
 R81AB, R81AC, R81AD, R81BA, R81BB, 
 R81BC, R81BD, R81CBA, R81CB, R81CC, 
 R81CD, R81DA, R81DB, R81DC, R81DD, 
 R82A, R82B, R82C, R82D, R83A, 
 R83B, R83C, R83D, R84A, R84B, 
 R84C, R84D, R85A, R85B, R85C, 
 R85D, R86A, R86B, R86C, R86D, 
 R87A, R87B, R87C, R87D, R88, 
 R89, R8101SOURCE, R8101A, R8101B, R8101C, 
 R8102SOURCE, R8102A, R8102B, R8102C, R8103SOURCE, 
 R8103A, R8103B, R8103C, R8104SOURCE, R8104A, 
 R8104B, R8104C, R811, R811_TEXT)
AS
SELECT
S.PK_GUID AS PK_GUID_SUB,
R.PK_GUID AS PK_GUID_REP,
F.FAC_ID,
C.CHEM_TXT,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R7B1,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R7B2,
(SELECT ENERGY_RCV_METH_CODE FROM V_TRI_PG5_7B M WHERE NUM = 3 AND M.PK_GUID = R.PK_GUID) R7B3,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 1 AND M.PK_GUID = R.PK_GUID) R7C1,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 2 AND M.PK_GUID = R.PK_GUID) R7C2,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 3 AND M.PK_GUID = R.PK_GUID) R7C3,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 4 AND M.PK_GUID = R.PK_GUID) R7C4,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 5 AND M.PK_GUID = R.PK_GUID) R7C5,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 6 AND M.PK_GUID = R.PK_GUID) R7C6,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 7 AND M.PK_GUID = R.PK_GUID) R7C7,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 8 AND M.PK_GUID = R.PK_GUID) R7C8,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 9 AND M.PK_GUID = R.PK_GUID) R7C9,
(SELECT ONSITE_RECYCG_METH_CODE FROM V_TRI_PG5_7C M WHERE NUM = 10 AND M.PK_GUID = R.PK_GUID) R7C10,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81AA,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81AB,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81AC,
(SELECT TOTAL_Q FROM TRI_ONSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81AD,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81BA,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81BB,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81BC,
(SELECT TOTAL_Q FROM TRI_ONSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81BD,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81CBA,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81CB,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81CC,
(SELECT TOTAL_Q FROM TRI_OFFSITE_UIC_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81CD,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R81DA,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R81DB,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R81DC,
(SELECT TOTAL_Q FROM TRI_OFFSITE_DISP_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R81DD,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R82A,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R82B,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R82C,
(SELECT TOTAL_Q FROM TRI_ONSITE_ENERGY_RCV_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R82D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R83A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R83B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R83C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_ENERGY_REC_QTY X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R83D,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R84A,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R84B,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R84C,
(SELECT TOTAL_Q FROM TRI_ONSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R84D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R85A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R85B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R85C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_RECYCLED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R85D,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R86A,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R86B,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R86C,
(SELECT TOTAL_Q FROM TRI_ONSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R86D,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = -1) R87A,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 0) R87B,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 1) R87C,
(SELECT TOTAL_Q FROM TRI_OFFSITE_TREATED_Q X WHERE X.FK_GUID = R.PK_GUID AND YEAR_OFFSET_ME = 2) R87D,
ONE_TIME_RELEASE_Q R88,
PRODUCTION_RATIO_ME R89,
R8101.R810VALUE R8101SOURCE,
R8101.R810A R8101A,
R8101.R810B R8101B,
R8101.R810C R8101C,
R8102.R810VALUE R8102SOURCE,
R8102.R810A R8102A,
R8102.R810B R8102B,
R8102.R810C R8102C,
R8103.R810VALUE R8103SOURCE,
R8103.R810A R8103A,
R8103.R810B R8103B,
R8103.R810C R8103C,
R8104.R810VALUE R8104SOURCE,
R8104.R810A R8104A,
R8104.R810B R8104B,
R8104.R810C R8104C,
SUB_ADDITIONAL_DATA_ID R811,
OPT_INF_TXT R811_TEXT
FROM TRI_REPORT R
LEFT OUTER JOIN
(SELECT PK_GUID, R810VALUE, R810A, R810B, R810C FROM V_TRI_PG5_810 WHERE NUM = 1) R8101
ON R8101.PK_GUID = R.PK_GUID
LEFT OUTER JOIN
(SELECT PK_GUID, R810VALUE, R810A, R810B, R810C FROM V_TRI_PG5_810 WHERE NUM = 2) R8102
ON R8102.PK_GUID = R.PK_GUID
LEFT OUTER JOIN
(SELECT PK_GUID, R810VALUE, R810A, R810B, R810C FROM V_TRI_PG5_810 WHERE NUM = 3) R8103
ON R8103.PK_GUID = R.PK_GUID
LEFT OUTER JOIN
(SELECT PK_GUID, R810VALUE, R810A, R810B, R810C FROM V_TRI_PG5_810 WHERE NUM = 4) R8104
ON R8104.PK_GUID = R.PK_GUID
JOIN TRI_SUB S ON R.FK_GUID = S.PK_GUID
JOIN TRI_FAC F ON F.FK_GUID = S.PK_GUID
JOIN TRI_CHEM C ON C.FK_GUID = R.PK_GUID

'
GO
/****** Object:  View [dbo].[V_TRI_FORM_R_SHORT]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TRI_FORM_R_SHORT]'))
EXEC dbo.sp_executesql @statement = N'




CREATE VIEW [dbo].[V_TRI_FORM_R_SHORT]

AS

SELECT DISTINCT    R.PK_GUID AS REPORT_ID, R.REPORT_ID TRI_REPORT_NUMBER, R.SUB_REP_YEAR, C.CHEM_TXT AS CHEM_NAME, C.CAS_CLBER AS CAS_NUMBER, R.SUB_PARTIAL_FAC_ID, 
                      R.SUB_FEDERAL_FAC_ID, CASE WHEN dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) IN (''CDX'', ''TRIME-WEB'') THEN ''Y'' ELSE ''N'' END AS CDX_YN, 
                      CASE WHEN dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) = ''PAPER'' THEN ''Y'' ELSE ''N'' END AS HARD_COPY_YN, 
                      CASE WHEN dbo.TRI_CalculateSubmissionMethod(S.TRI_SUB_ID) = ''DISK'' THEN ''Y'' ELSE ''N'' END AS DISKETTE_YN, F.FAC_ID AS TRIFID, F.FAC_SITE AS FACILITY, 
                      F.LOC_ADD_TXT AS STREET_ADDRESS_1, F.SUPP_LOC_TXT AS STREET_ADDRESS_2, F.LOCALITY AS CITY, F.ADD_POSTAL_CODE AS ZIP_CODE, F.COUNTY, 
                      F.MAIL_FAC_SITE AS FACILITY_NAME_MAILING, F.MAIL_ADD_TXT AS MAILING_ADDRESS_1, F.SUPP_MAIL_ADD AS MAILING_ADDRESS_2, 
                      F.MAIL_ADD_CITY AS MAILING_CITY, F.MAIL_ADD_STATE_CODE AS MAILING_STATE, F.MAIL_ADD_POSTAL_CODE AS MAILING_ZIP, FN.FAC_NAICS AS NAICS_CODE, 
                      R.TECH_CONT AS TECHNICAL_CONTACT, R.TECH_CONT_PHONE_TXT AS TECHNICAL_CONTACT_PHONE, F.PARENT_COMPANY_TXT AS PARENT_COMPANY, 
                      dbo.TRI_RangeCodeConversion(AIR_FUG.WASTE_Q_ME, AIR_FUG.WASTE_Q_RANGE_CODE) AS AIR_FUG_51, 
                      dbo.TRI_RangeCodeConversion(AIR_STACK.WASTE_Q_ME, AIR_STACK.WASTE_Q_RANGE_CODE) AS AIR_STACK_52, WATER_1.A AS WATER_531, 
                      WATER_2.A AS WATER_532, WATER_1.STREAM AS STREAM_531, WATER_2.STREAM AS STREAM_532, dbo.TRI_RangeCodeConversion(UNINJ_I.WASTE_Q_ME, 
                      UNINJ_I.WASTE_Q_RANGE_CODE) AS UNINJ_I_541, dbo.TRI_RangeCodeConversion(UNINJ_IIV.WASTE_Q_ME, UNINJ_IIV.WASTE_Q_RANGE_CODE) 
                      AS UNINJ_IIV_542, dbo.TRI_RangeCodeConversion(RCRA_C.WASTE_Q_ME, RCRA_C.WASTE_Q_RANGE_CODE) AS RCRA_C_551A, 
                      dbo.TRI_RangeCodeConversion(OTH_LANDF.WASTE_Q_ME, OTH_LANDF.WASTE_Q_RANGE_CODE) AS OTH_LANDF_551B, 
                      dbo.TRI_RangeCodeConversion(LAND_TREA.WASTE_Q_ME, LAND_TREA.WASTE_Q_RANGE_CODE) AS LAND_TREA_552, 
                      dbo.TRI_RangeCodeConversion(SI_5_5_3_A.WASTE_Q_ME, SI_5_5_3_A.WASTE_Q_RANGE_CODE) AS SI_5_5_3_A, 
                      dbo.TRI_RangeCodeConversion(SI_5_5_3_B.WASTE_Q_ME, SI_5_5_3_B.WASTE_Q_RANGE_CODE) AS SI_5_5_3_B, 
                      dbo.TRI_RangeCodeConversion(OTH_DISP.WASTE_Q_ME, OTH_DISP.WASTE_Q_RANGE_CODE) AS OTH_DISP, 
                      dbo.TRI_RangeCodeConversion(R.WASTE_Q_ME, R.WASTE_Q_RANGE_CODE) AS POTW_61A1, TL_POTW.FAC_SITE AS POTW_NAME_61B, TRANS_6201.AMT_LBS AS AMT_6201, 
                      TRANS_6201.WASTE_MANAGEMENT_CODE AS WC_6201, TRANS_6202.AMT_LBS AS AMT_6202, TRANS_6202.WASTE_MANAGEMENT_CODE AS WC_6202, 
                      TRANS_6203.AMT_LBS AS AMT_6203, TRANS_6203.WASTE_MANAGEMENT_CODE AS WC_6203, TRANS_6204.AMT_LBS AS AMT_6204, 
                      TRANS_6204.WASTE_MANAGEMENT_CODE AS WC_6204, TRANS_6205.AMT_LBS AS AMT_6205, TRANS_6205.WASTE_MANAGEMENT_CODE AS WC_6205, 
                      TRANS_6206.AMT_LBS AS AMT_6206, TRANS_6206.WASTE_MANAGEMENT_CODE AS WC_6206, TRANS_6207.AMT_LBS AS AMT_6207, 
                      TRANS_6207.WASTE_MANAGEMENT_CODE AS WC_6207, TRANS_6208.AMT_LBS AS AMT_6208, TRANS_6208.WASTE_MANAGEMENT_CODE AS WC_6208, 
                      TRANS_6209.AMT_LBS AS AMT_6209, TRANS_6209.WASTE_MANAGEMENT_CODE AS WC_6209, TRANS_6210.AMT_LBS AS AMT_6210, 
                      TRANS_6210.WASTE_MANAGEMENT_CODE AS WC_6210, TRANS_6211.AMT_LBS AS AMT_6211, TRANS_6211.WASTE_MANAGEMENT_CODE AS WC_6211, 
                      TRANS_6212.AMT_LBS AS AMT_6212, TRANS_6212.WASTE_MANAGEMENT_CODE AS WC_6212, TRANS_6213.AMT_LBS AS AMT_6213, 
                      TRANS_6213.WASTE_MANAGEMENT_CODE AS WC_6213, TRANS_6214.AMT_LBS AS AMT_6214, TRANS_6214.WASTE_MANAGEMENT_CODE AS WC_6214, 
                      TRANS_6215.AMT_LBS AS AMT_6215, TRANS_6215.WASTE_MANAGEMENT_CODE AS WC_6215, TRANS_6216.AMT_LBS AS AMT_6216, 
                      TRANS_6216.WASTE_MANAGEMENT_CODE AS WC_6216, TRANS_6217.AMT_LBS AS AMT_6217, TRANS_6217.WASTE_MANAGEMENT_CODE AS WC_6217, 
                      TRANS_6218.AMT_LBS AS AMT_6218, TRANS_6218.WASTE_MANAGEMENT_CODE AS WC_6218, TRANS_6219.AMT_LBS AS AMT_6219, 
                      TRANS_6219.WASTE_MANAGEMENT_CODE AS WC_6219, TRANS_6220.AMT_LBS AS AMT_6220, TRANS_6220.WASTE_MANAGEMENT_CODE AS WC_6220, 
                      TRANS_6221.AMT_LBS AS AMT_6221, TRANS_6221.WASTE_MANAGEMENT_CODE AS WC_6221, TRANS_6222.AMT_LBS AS AMT_6222, 
                      TRANS_6222.WASTE_MANAGEMENT_CODE AS WC_6222, TRANS_6223.AMT_LBS AS AMT_6223, TRANS_6223.WASTE_MANAGEMENT_CODE AS WC_6223, 
                      TRANS_6224.AMT_LBS AS AMT_6224, TRANS_6224.WASTE_MANAGEMENT_CODE AS WC_6224, ENERGY_RCV_7B1.ENERGY_RCV_METH_CODE AS ER_7B1, 
                      ENERGY_RCV_7B2.ENERGY_RCV_METH_CODE AS ER_7B2, ONSITE_RCY_7C1.ONSITE_RECYCG_METH_CODE AS OR_7C1, 
                      ONSITE_RCY_7C2.ONSITE_RECYCG_METH_CODE AS OR_7C2, ONS_UIC_1.TOTAL_Q AS SR_81A1, ONS_UIC_2.TOTAL_Q AS SR_81A2, 
                      ONS_UIC_3.TOTAL_Q AS SR_81A3, ONS_UIC_4.TOTAL_Q AS SR_81A4, ONS_DISP_1.TOTAL_Q AS SR_81B1, ONS_DISP_2.TOTAL_Q AS SR_81B2, 
                      ONS_DISP_3.TOTAL_Q AS SR_81B3, ONS_DISP_4.TOTAL_Q AS SR_81B4, OFF_UIC_1.TOTAL_Q AS SR_81C1, OFF_UIC_2.TOTAL_Q AS SR_81C2, 
                      OFF_UIC_3.TOTAL_Q AS SR_81C3, OFF_UIC_4.TOTAL_Q AS SR_81C4, OFF_DISP_1.TOTAL_Q AS SR_81D1, OFF_DISP_2.TOTAL_Q AS SR_81D2, 
                      OFF_DISP_3.TOTAL_Q AS SR_81D3, OFF_DISP_4.TOTAL_Q AS SR_81D4, ISNULL(CAST(ONS_UIC_1.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(ONS_DISP_1.TOTAL_Q AS DECIMAL(18, 2)), 0) + ISNULL(CAST(OFF_UIC_1.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(OFF_DISP_1.TOTAL_Q AS DECIMAL(18, 2)), 0) AS SR_OFFTOTAL_1, ISNULL(CAST(ONS_UIC_2.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(ONS_DISP_2.TOTAL_Q AS DECIMAL(18, 2)), 0) + ISNULL(CAST(OFF_UIC_2.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(OFF_DISP_2.TOTAL_Q AS DECIMAL(18, 2)), 0) AS SR_OFFTOTAL_2, ISNULL(CAST(ONS_UIC_3.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(ONS_DISP_3.TOTAL_Q AS DECIMAL(18, 2)), 0) + ISNULL(CAST(OFF_UIC_3.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(OFF_DISP_3.TOTAL_Q AS DECIMAL(18, 2)), 0) AS SR_OFFTOTAL_3, ISNULL(CAST(ONS_UIC_4.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(ONS_DISP_4.TOTAL_Q AS DECIMAL(18, 2)), 0) + ISNULL(CAST(OFF_UIC_4.TOTAL_Q AS DECIMAL(18, 2)), 0) 
                      + ISNULL(CAST(OFF_DISP_4.TOTAL_Q AS DECIMAL(18, 2)), 0) AS SR_OFFTOTAL_4, ONS_ERCV_1.TOTAL_Q AS SR_821, ONS_ERCV_2.TOTAL_Q AS SR_822, 
                      ONS_ERCV_3.TOTAL_Q AS SR_823, ONS_ERCV_4.TOTAL_Q AS SR_824, OFF_ERCV_1.TOTAL_Q AS SR_831, OFF_ERCV_2.TOTAL_Q AS SR_832, 
                      OFF_ERCV_3.TOTAL_Q AS SR_833, OFF_ERCV_4.TOTAL_Q AS SR_834, ONS_RECY_1.TOTAL_Q AS SR_841, ONS_RECY_2.TOTAL_Q AS SR_842, 
                      ONS_RECY_3.TOTAL_Q AS SR_843, ONS_RECY_4.TOTAL_Q AS SR_844, OFF_RECY_1.TOTAL_Q AS SR_851, OFF_RECY_2.TOTAL_Q AS SR_852, 
                      OFF_RECY_3.TOTAL_Q AS SR_853, OFF_RECY_4.TOTAL_Q AS SR_854, ONS_TRE_1.TOTAL_Q AS SR_861, ONS_TRE_2.TOTAL_Q AS SR_862, 
                      ONS_TRE_3.TOTAL_Q AS SR_863, ONS_TRE_4.TOTAL_Q AS SR_864, OFF_TRE_1.TOTAL_Q AS SR_871, OFF_TRE_2.TOTAL_Q AS SR_872, 
                      OFF_TRE_3.TOTAL_Q AS SR_873, OFF_TRE_4.TOTAL_Q AS SR_874, R.ONE_TIME_RELEASE_Q AS SR88, R.PRODUCTION_RATIO_ME AS SR89, 
                      SRA_1.R810VALUE AS R8101, SRA_1.R810A AS R8101A, SRA_1.R810B AS R8101B, SRA_1.R810C AS R8101C, SRA_2.R810VALUE AS R8102, 
                      SRA_2.R810A AS R8102A, SRA_2.R810B AS R8102B, SRA_2.R810C AS R8102C, SRA_3.R810VALUE AS R8103, SRA_3.R810A AS R8103A, SRA_3.R810B AS R8103B, 
                      SRA_3.R810C AS R8103C, SRA_4.R810VALUE AS R8104, SRA_4.R810A AS R8104A, SRA_4.R810B AS R8104B, SRA_4.R810C AS R8104C, 
                      R.SUB_ADDITIONAL_DATA_ID AS R811, CONVERT(VARCHAR, CAST(R.CERT_SIGNED_DATE AS DATETIME), 101) AS CERT_SIGNED_DATE, CONVERT(VARCHAR, S.INSERTED_DATE, 101) AS DATE_RECEIVED, R.REVISION_IND
FROM         TRI_SUB AS S INNER JOIN
                      TRI_FAC AS F ON S.PK_GUID = F.FK_GUID INNER JOIN
                      TRI_REPORT AS R ON S.PK_GUID = R.FK_GUID INNER JOIN
                      TRI_CHEM AS C ON R.PK_GUID = C.FK_GUID LEFT OUTER JOIN
                      V_TRI_PG5_810 AS SRA_1 ON R.PK_GUID = SRA_1.PK_GUID AND SRA_1.NUM = 1 LEFT OUTER JOIN
                      V_TRI_PG5_810 AS SRA_2 ON R.PK_GUID = SRA_2.PK_GUID AND SRA_2.NUM = 2 LEFT OUTER JOIN
                      V_TRI_PG5_810 AS SRA_3 ON R.PK_GUID = SRA_3.PK_GUID AND SRA_3.NUM = 3 LEFT OUTER JOIN
                      V_TRI_PG5_810 AS SRA_4 ON R.PK_GUID = SRA_4.PK_GUID AND SRA_4.NUM = 4 LEFT OUTER JOIN
                      TRI_ONSITE_UIC_DISP_QTY AS ONS_UIC_1 ON R.PK_GUID = ONS_UIC_1.FK_GUID AND ONS_UIC_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_ONSITE_UIC_DISP_QTY AS ONS_UIC_2 ON R.PK_GUID = ONS_UIC_2.FK_GUID AND ONS_UIC_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_ONSITE_UIC_DISP_QTY AS ONS_UIC_3 ON R.PK_GUID = ONS_UIC_3.FK_GUID AND ONS_UIC_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_ONSITE_UIC_DISP_QTY AS ONS_UIC_4 ON R.PK_GUID = ONS_UIC_4.FK_GUID AND ONS_UIC_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_ONSITE_DISP_QTY AS ONS_DISP_1 ON R.PK_GUID = ONS_DISP_1.FK_GUID AND ONS_DISP_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_ONSITE_DISP_QTY AS ONS_DISP_2 ON R.PK_GUID = ONS_DISP_2.FK_GUID AND ONS_DISP_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_ONSITE_DISP_QTY AS ONS_DISP_3 ON R.PK_GUID = ONS_DISP_3.FK_GUID AND ONS_DISP_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_ONSITE_DISP_QTY AS ONS_DISP_4 ON R.PK_GUID = ONS_DISP_4.FK_GUID AND ONS_DISP_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_OFFSITE_UIC_DISP_QTY AS OFF_UIC_1 ON R.PK_GUID = OFF_UIC_1.FK_GUID AND OFF_UIC_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_OFFSITE_UIC_DISP_QTY AS OFF_UIC_2 ON R.PK_GUID = OFF_UIC_2.FK_GUID AND OFF_UIC_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_OFFSITE_UIC_DISP_QTY AS OFF_UIC_3 ON R.PK_GUID = OFF_UIC_3.FK_GUID AND OFF_UIC_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_OFFSITE_UIC_DISP_QTY AS OFF_UIC_4 ON R.PK_GUID = OFF_UIC_4.FK_GUID AND OFF_UIC_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_OFFSITE_DISP_QTY AS OFF_DISP_1 ON R.PK_GUID = OFF_DISP_1.FK_GUID AND OFF_DISP_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_OFFSITE_DISP_QTY AS OFF_DISP_2 ON R.PK_GUID = OFF_DISP_2.FK_GUID AND OFF_DISP_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_OFFSITE_DISP_QTY AS OFF_DISP_3 ON R.PK_GUID = OFF_DISP_3.FK_GUID AND OFF_DISP_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_OFFSITE_DISP_QTY AS OFF_DISP_4 ON R.PK_GUID = OFF_DISP_4.FK_GUID AND OFF_DISP_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_ONSITE_ENERGY_RCV_QTY AS ONS_ERCV_1 ON R.PK_GUID = ONS_ERCV_1.FK_GUID AND ONS_ERCV_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_ONSITE_ENERGY_RCV_QTY AS ONS_ERCV_2 ON R.PK_GUID = ONS_ERCV_2.FK_GUID AND ONS_ERCV_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_ONSITE_ENERGY_RCV_QTY AS ONS_ERCV_3 ON R.PK_GUID = ONS_ERCV_3.FK_GUID AND ONS_ERCV_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_ONSITE_ENERGY_RCV_QTY AS ONS_ERCV_4 ON R.PK_GUID = ONS_ERCV_4.FK_GUID AND ONS_ERCV_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_OFFSITE_ENERGY_REC_QTY AS OFF_ERCV_1 ON R.PK_GUID = OFF_ERCV_1.FK_GUID AND OFF_ERCV_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_OFFSITE_ENERGY_REC_QTY AS OFF_ERCV_2 ON R.PK_GUID = OFF_ERCV_2.FK_GUID AND OFF_ERCV_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_OFFSITE_ENERGY_REC_QTY AS OFF_ERCV_3 ON R.PK_GUID = OFF_ERCV_3.FK_GUID AND OFF_ERCV_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_OFFSITE_ENERGY_REC_QTY AS OFF_ERCV_4 ON R.PK_GUID = OFF_ERCV_4.FK_GUID AND OFF_ERCV_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_ONSITE_RECYCLED_Q AS ONS_RECY_1 ON R.PK_GUID = ONS_RECY_1.FK_GUID AND ONS_RECY_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_ONSITE_RECYCLED_Q AS ONS_RECY_2 ON R.PK_GUID = ONS_RECY_2.FK_GUID AND ONS_RECY_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_ONSITE_RECYCLED_Q AS ONS_RECY_3 ON R.PK_GUID = ONS_RECY_3.FK_GUID AND ONS_RECY_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_ONSITE_RECYCLED_Q AS ONS_RECY_4 ON R.PK_GUID = ONS_RECY_4.FK_GUID AND ONS_RECY_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_OFFSITE_RECYCLED_Q AS OFF_RECY_1 ON R.PK_GUID = OFF_RECY_1.FK_GUID AND OFF_RECY_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_OFFSITE_RECYCLED_Q AS OFF_RECY_2 ON R.PK_GUID = OFF_RECY_2.FK_GUID AND OFF_RECY_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_OFFSITE_RECYCLED_Q AS OFF_RECY_3 ON R.PK_GUID = OFF_RECY_3.FK_GUID AND OFF_RECY_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_OFFSITE_RECYCLED_Q AS OFF_RECY_4 ON R.PK_GUID = OFF_RECY_4.FK_GUID AND OFF_RECY_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_ONSITE_TREATED_Q AS ONS_TRE_1 ON R.PK_GUID = ONS_TRE_1.FK_GUID AND ONS_TRE_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_ONSITE_TREATED_Q AS ONS_TRE_2 ON R.PK_GUID = ONS_TRE_2.FK_GUID AND ONS_TRE_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_ONSITE_TREATED_Q AS ONS_TRE_3 ON R.PK_GUID = ONS_TRE_3.FK_GUID AND ONS_TRE_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_ONSITE_TREATED_Q AS ONS_TRE_4 ON R.PK_GUID = ONS_TRE_4.FK_GUID AND ONS_TRE_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      TRI_OFFSITE_TREATED_Q AS OFF_TRE_1 ON R.PK_GUID = OFF_TRE_1.FK_GUID AND OFF_TRE_1.YEAR_OFFSET_ME = - 1 LEFT OUTER JOIN
                      TRI_OFFSITE_TREATED_Q AS OFF_TRE_2 ON R.PK_GUID = OFF_TRE_2.FK_GUID AND OFF_TRE_2.YEAR_OFFSET_ME = 0 LEFT OUTER JOIN
                      TRI_OFFSITE_TREATED_Q AS OFF_TRE_3 ON R.PK_GUID = OFF_TRE_3.FK_GUID AND OFF_TRE_3.YEAR_OFFSET_ME = 1 LEFT OUTER JOIN
                      TRI_OFFSITE_TREATED_Q AS OFF_TRE_4 ON R.PK_GUID = OFF_TRE_4.FK_GUID AND OFF_TRE_4.YEAR_OFFSET_ME = 2 LEFT OUTER JOIN
                      V_TRI_PG5_7B AS ENERGY_RCV_7B1 ON R.PK_GUID = ENERGY_RCV_7B1.PK_GUID AND ENERGY_RCV_7B1.NUM = 1 LEFT OUTER JOIN
                      V_TRI_PG5_7B AS ENERGY_RCV_7B2 ON R.PK_GUID = ENERGY_RCV_7B2.PK_GUID AND ENERGY_RCV_7B1.NUM = 2 LEFT OUTER JOIN
                      V_TRI_PG5_7C AS ONSITE_RCY_7C1 ON R.PK_GUID = ONSITE_RCY_7C1.PK_GUID AND ONSITE_RCY_7C1.NUM = 1 LEFT OUTER JOIN
                      V_TRI_PG5_7C AS ONSITE_RCY_7C2 ON R.PK_GUID = ONSITE_RCY_7C2.PK_GUID AND ONSITE_RCY_7C1.NUM = 2 LEFT OUTER JOIN
                      TRI_TRANSFER_LOC AS TL_POTW ON R.PK_GUID = TL_POTW.FK_GUID AND TL_POTW.POTW_IND = ''Y'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS AIR_FUG ON R.PK_GUID = AIR_FUG.FK_GUID AND AIR_FUG.EI_MEDIUM_CODE = ''AIR FUG'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS AIR_STACK ON R.PK_GUID = AIR_STACK.FK_GUID AND AIR_STACK.EI_MEDIUM_CODE = ''AIR STACK'' LEFT OUTER JOIN
                      V_TRI_PG2_53 AS WATER_1 ON WATER_1.FK_GUID = R.PK_GUID AND WATER_1.NUM = 1 LEFT OUTER JOIN
                      V_TRI_PG2_53 AS WATER_2 ON WATER_2.FK_GUID = R.PK_GUID AND WATER_2.NUM = 1 LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS UNINJ_I ON R.PK_GUID = UNINJ_I.FK_GUID AND UNINJ_I.EI_MEDIUM_CODE = ''UNINJ I'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS UNINJ_IIV ON R.PK_GUID = UNINJ_IIV.FK_GUID AND UNINJ_I.EI_MEDIUM_CODE = ''UNINJ IIV'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS RCRA_C ON R.PK_GUID = RCRA_C.FK_GUID AND RCRA_C.EI_MEDIUM_CODE = ''RCRA C'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS OTH_LANDF ON R.PK_GUID = OTH_LANDF.FK_GUID AND OTH_LANDF.EI_MEDIUM_CODE = ''OTH LANDF'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS LAND_TREA ON R.PK_GUID = LAND_TREA.FK_GUID AND LAND_TREA.EI_MEDIUM_CODE = ''LAND TREA'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS SI_5_5_3_A ON R.PK_GUID = SI_5_5_3_A.FK_GUID AND SI_5_5_3_A.EI_MEDIUM_CODE = ''SI 5.5.3A'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS SI_5_5_3_B ON R.PK_GUID = SI_5_5_3_B.FK_GUID AND SI_5_5_3_B.EI_MEDIUM_CODE = ''SI 5.5.3B'' LEFT OUTER JOIN
                      TRI_ONSITE_RELEASE_Q AS OTH_DISP ON R.PK_GUID = OTH_DISP.FK_GUID AND OTH_DISP.EI_MEDIUM_CODE = ''OTH DISP'' LEFT OUTER JOIN
                      TRI_FAC_NAICS AS FN ON F.PK_GUID = FN.FK_GUID AND FN.NAICS_PRIMARY_IND = ''Primary'' LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6201 ON TRANS_6201.FK_GUID = R.PK_GUID AND TRANS_6201.NUM = 1 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6202 ON TRANS_6202.FK_GUID = R.PK_GUID AND TRANS_6202.NUM = 2 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6203 ON TRANS_6203.FK_GUID = R.PK_GUID AND TRANS_6203.NUM = 3 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6204 ON TRANS_6204.FK_GUID = R.PK_GUID AND TRANS_6204.NUM = 4 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6205 ON TRANS_6205.FK_GUID = R.PK_GUID AND TRANS_6205.NUM = 5 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6206 ON TRANS_6206.FK_GUID = R.PK_GUID AND TRANS_6206.NUM = 6 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6207 ON TRANS_6207.FK_GUID = R.PK_GUID AND TRANS_6207.NUM = 7 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6208 ON TRANS_6208.FK_GUID = R.PK_GUID AND TRANS_6208.NUM = 8 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6209 ON TRANS_6209.FK_GUID = R.PK_GUID AND TRANS_6209.NUM = 9 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6210 ON TRANS_6210.FK_GUID = R.PK_GUID AND TRANS_6210.NUM = 10 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6211 ON TRANS_6211.FK_GUID = R.PK_GUID AND TRANS_6211.NUM = 11 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6212 ON TRANS_6212.FK_GUID = R.PK_GUID AND TRANS_6212.NUM = 12 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6213 ON TRANS_6213.FK_GUID = R.PK_GUID AND TRANS_6213.NUM = 13 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6214 ON TRANS_6214.FK_GUID = R.PK_GUID AND TRANS_6214.NUM = 14 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6215 ON TRANS_6215.FK_GUID = R.PK_GUID AND TRANS_6215.NUM = 15 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6216 ON TRANS_6216.FK_GUID = R.PK_GUID AND TRANS_6216.NUM = 16 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6217 ON TRANS_6217.FK_GUID = R.PK_GUID AND TRANS_6217.NUM = 17 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6218 ON TRANS_6218.FK_GUID = R.PK_GUID AND TRANS_6218.NUM = 18 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6219 ON TRANS_6219.FK_GUID = R.PK_GUID AND TRANS_6219.NUM = 19 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6220 ON TRANS_6220.FK_GUID = R.PK_GUID AND TRANS_6220.NUM = 20 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6221 ON TRANS_6221.FK_GUID = R.PK_GUID AND TRANS_6221.NUM = 21 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6222 ON TRANS_6222.FK_GUID = R.PK_GUID AND TRANS_6222.NUM = 22 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6223 ON TRANS_6223.FK_GUID = R.PK_GUID AND TRANS_6223.NUM = 23 LEFT OUTER JOIN
                      V_TRI_FORM_R_SHORT_XFR AS TRANS_6224 ON TRANS_6224.FK_GUID = R.PK_GUID AND TRANS_6224.NUM = 24




'
GO
/****** Object:  View [dbo].[V_EXT_DIOXIN_D]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EXT_DIOXIN_D]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EXT_DIOXIN_D]

AS

SELECT

      V_FORM_S1_PG1.PK_GUID_SUB
,     V_FORM_S1_PG1.PK_GUID_REP

,	T.AgencyID AS FSID
,	T.EPAID AS [EPA ID]
,	UPPER(F.FAC_ID) AS TRIFID
,	R.SUB_REP_YEAR AS Year
,	R.REVISION_IND AS Revision
,	R.SUB_PARTIAL_FAC_ID AS [Partial Sub]
,	RIGHT(R.REPORT_TYPE_CODE, 1) AS Form
,	F.FAC_SITE AS [Facility Name]
,	T.AgencyName AS AKA
,	F.LOC_ADD_TXT AS [Address 1]
,	F.SUPP_LOC_TXT AS [Address 2]
,	F.LOCALITY AS City
,	F.COUNTY AS County
,	F.ADD_POSTAL_CODE AS Zip
,	C.CHEM_TXT AS Chemical
,	C.CAS_CLBER AS [CAS #]

,     V_FORM_S1_PG1.S151NA AS [51 Fugitive Air - TEQ_NAInd]
,     V_FORM_S1_PG1.S151T1 AS [51 Fugitive Air - TEQ_01]
,     V_FORM_S1_PG1.S151T2 AS [51 Fugitive Air - TEQ_02]
,     V_FORM_S1_PG1.S151T3 AS [51 Fugitive Air - TEQ_03]
,     V_FORM_S1_PG1.S151T4 AS [51 Fugitive Air - TEQ_04]
,     V_FORM_S1_PG1.S151T5 AS [51 Fugitive Air - TEQ_05]
,     V_FORM_S1_PG1.S151T6 AS [51 Fugitive Air - TEQ_06]
,     V_FORM_S1_PG1.S151T7 AS [51 Fugitive Air - TEQ_07]
,     V_FORM_S1_PG1.S151T8 AS [51 Fugitive Air - TEQ_08]
,     V_FORM_S1_PG1.S151T9 AS [51 Fugitive Air - TEQ_09]
,     V_FORM_S1_PG1.S151T10 AS [51 Fugitive Air - TEQ_10]
,     V_FORM_S1_PG1.S151T11 AS [51 Fugitive Air - TEQ_11]
,     V_FORM_S1_PG1.S151T12 AS [51 Fugitive Air - TEQ_12]
,     V_FORM_S1_PG1.S151T13 AS [51 Fugitive Air - TEQ_13]
,     V_FORM_S1_PG1.S151T14 AS [51 Fugitive Air - TEQ_14]
,     V_FORM_S1_PG1.S151T15 AS [51 Fugitive Air - TEQ_15]
,     V_FORM_S1_PG1.S151T16 AS [51 Fugitive Air - TEQ_16]
,     V_FORM_S1_PG1.S151T17 AS [51 Fugitive Air - TEQ_17]
,     V_FORM_S1_PG1.S152NA AS [52 Stack Air - TEQ_NAInd]
,     V_FORM_S1_PG1.S152T1 AS [52 Stack Air - TEQ_01]
,     V_FORM_S1_PG1.S152T2 AS [52 Stack Air - TEQ_02]
,     V_FORM_S1_PG1.S152T3 AS [52 Stack Air - TEQ_03]
,     V_FORM_S1_PG1.S152T4 AS [52 Stack Air - TEQ_04]
,     V_FORM_S1_PG1.S152T5 AS [52 Stack Air - TEQ_05]
,     V_FORM_S1_PG1.S152T6 AS [52 Stack Air - TEQ_06]
,     V_FORM_S1_PG1.S152T7 AS [52 Stack Air - TEQ_07]
,     V_FORM_S1_PG1.S152T8 AS [52 Stack Air - TEQ_08]
,     V_FORM_S1_PG1.S152T9 AS [52 Stack Air - TEQ_09]
,     V_FORM_S1_PG1.S152T10 AS [52 Stack Air - TEQ_10]
,     V_FORM_S1_PG1.S152T11 AS [52 Stack Air - TEQ_11]
,     V_FORM_S1_PG1.S152T12 AS [52 Stack Air - TEQ_12]
,     V_FORM_S1_PG1.S152T13 AS [52 Stack Air - TEQ_13]
,     V_FORM_S1_PG1.S152T14 AS [52 Stack Air - TEQ_14]
,     V_FORM_S1_PG1.S152T15 AS [52 Stack Air - TEQ_15]
,     V_FORM_S1_PG1.S152T16 AS [52 Stack Air - TEQ_16]
,     V_FORM_S1_PG1.S152T17 AS [52 Stack Air - TEQ_17]
,     V_FORM_S1_PG1.S1531NA AS [531 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1531T1 AS [531 Water - TEQ_01]
,     V_FORM_S1_PG1.S1531T2 AS [531 Water - TEQ_02]
,     V_FORM_S1_PG1.S1531T3 AS [531 Water - TEQ_03]
,     V_FORM_S1_PG1.S1531T4 AS [531 Water - TEQ_04]
,     V_FORM_S1_PG1.S1531T5 AS [531 Water - TEQ_05]
,     V_FORM_S1_PG1.S1531T6 AS [531 Water - TEQ_06]
,     V_FORM_S1_PG1.S1531T7 AS [531 Water - TEQ_07]
,     V_FORM_S1_PG1.S1531T8 AS [531 Water - TEQ_08]
,     V_FORM_S1_PG1.S1531T9 AS [531 Water - TEQ_09]
,     V_FORM_S1_PG1.S1531T10 AS [531 Water - TEQ_10]
,     V_FORM_S1_PG1.S1531T11 AS [531 Water - TEQ_11]
,     V_FORM_S1_PG1.S1531T12 AS [531 Water - TEQ_12]
,     V_FORM_S1_PG1.S1531T13 AS [531 Water - TEQ_13]
,     V_FORM_S1_PG1.S1531T14 AS [531 Water - TEQ_14]
,     V_FORM_S1_PG1.S1531T15 AS [531 Water - TEQ_15]
,     V_FORM_S1_PG1.S1531T16 AS [531 Water - TEQ_16]
,     V_FORM_S1_PG1.S1531T17 AS [531 Water - TEQ_17]
,     V_FORM_S1_PG1.S1532NA AS [532 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1532T1 AS [532 Water - TEQ_01]
,     V_FORM_S1_PG1.S1532T2 AS [532 Water - TEQ_02]
,     V_FORM_S1_PG1.S1532T3 AS [532 Water - TEQ_03]
,     V_FORM_S1_PG1.S1532T4 AS [532 Water - TEQ_04]
,     V_FORM_S1_PG1.S1532T5 AS [532 Water - TEQ_05]
,     V_FORM_S1_PG1.S1532T6 AS [532 Water - TEQ_06]
,     V_FORM_S1_PG1.S1532T7 AS [532 Water - TEQ_07]
,     V_FORM_S1_PG1.S1532T8 AS [532 Water - TEQ_08]
,     V_FORM_S1_PG1.S1532T9 AS [532 Water - TEQ_09]
,     V_FORM_S1_PG1.S1532T10 AS [532 Water - TEQ_10]
,     V_FORM_S1_PG1.S1532T11 AS [532 Water - TEQ_11]
,     V_FORM_S1_PG1.S1532T12 AS [532 Water - TEQ_12]
,     V_FORM_S1_PG1.S1532T13 AS [532 Water - TEQ_13]
,     V_FORM_S1_PG1.S1532T14 AS [532 Water - TEQ_14]
,     V_FORM_S1_PG1.S1532T15 AS [532 Water - TEQ_15]
,     V_FORM_S1_PG1.S1532T16 AS [532 Water - TEQ_16]
,     V_FORM_S1_PG1.S1532T17 AS [532 Water - TEQ_17]
,     V_FORM_S1_PG1.S1533NA AS [533 Water - TEQ_NAInd]
,     V_FORM_S1_PG1.S1533T1 AS [533 Water - TEQ_01]
,     V_FORM_S1_PG1.S1533T2 AS [533 Water - TEQ_02]
,     V_FORM_S1_PG1.S1533T3 AS [533 Water - TEQ_03]
,     V_FORM_S1_PG1.S1533T4 AS [533 Water - TEQ_04]
,     V_FORM_S1_PG1.S1533T5 AS [533 Water - TEQ_05]
,     V_FORM_S1_PG1.S1533T6 AS [533 Water - TEQ_06]
,     V_FORM_S1_PG1.S1533T7 AS [533 Water - TEQ_07]
,     V_FORM_S1_PG1.S1533T8 AS [533 Water - TEQ_08]
,     V_FORM_S1_PG1.S1533T9 AS [533 Water - TEQ_09]
,     V_FORM_S1_PG1.S1533T10 AS [533 Water - TEQ_10]
,     V_FORM_S1_PG1.S1533T11 AS [533 Water - TEQ_11]
,     V_FORM_S1_PG1.S1533T12 AS [533 Water - TEQ_12]
,     V_FORM_S1_PG1.S1533T13 AS [533 Water - TEQ_13]
,     V_FORM_S1_PG1.S1533T14 AS [533 Water - TEQ_14]
,     V_FORM_S1_PG1.S1533T15 AS [533 Water - TEQ_15]
,     V_FORM_S1_PG1.S1533T16 AS [533 Water - TEQ_16]
,     V_FORM_S1_PG1.S1533T17 AS [533 Water - TEQ_17]
,     V_FORM_S1_PG2.S1541NA AS [541 UG INJ Class I - TEQ_NAInd]
,     V_FORM_S1_PG2.S1541T1 AS [541 UG INJ Class I - TEQ_01]
,     V_FORM_S1_PG2.S1541T2 AS [541 UG INJ Class I - TEQ_02]
,     V_FORM_S1_PG2.S1541T3 AS [541 UG INJ Class I - TEQ_03]
,     V_FORM_S1_PG2.S1541T4 AS [541 UG INJ Class I - TEQ_04]
,     V_FORM_S1_PG2.S1541T5 AS [541 UG INJ Class I - TEQ_05]
,     V_FORM_S1_PG2.S1541T6 AS [541 UG INJ Class I - TEQ_06]
,     V_FORM_S1_PG2.S1541T7 AS [541 UG INJ Class I - TEQ_07]
,     V_FORM_S1_PG2.S1541T8 AS [541 UG INJ Class I - TEQ_08]
,     V_FORM_S1_PG2.S1541T9 AS [541 UG INJ Class I - TEQ_09]
,     V_FORM_S1_PG2.S1541T10 AS [541 UG INJ Class I - TEQ_10]
,     V_FORM_S1_PG2.S1541T11 AS [541 UG INJ Class I - TEQ_11]
,     V_FORM_S1_PG2.S1541T12 AS [541 UG INJ Class I - TEQ_12]
,     V_FORM_S1_PG2.S1541T13 AS [541 UG INJ Class I - TEQ_13]
,     V_FORM_S1_PG2.S1541T14 AS [541 UG INJ Class I - TEQ_14]
,     V_FORM_S1_PG2.S1541T15 AS [541 UG INJ Class I - TEQ_15]
,     V_FORM_S1_PG2.S1541T16 AS [541 UG INJ Class I - TEQ_16]
,     V_FORM_S1_PG2.S1541T17 AS [541 UG INJ Class I - TEQ_17]
,     V_FORM_S1_PG2.S1542NA AS [542 UG INJ Class II-V - TEQ_NAInd]
,     V_FORM_S1_PG2.S1542T1 AS [542 UG INJ Class II-V - TEQ_01]
,     V_FORM_S1_PG2.S1542T2 AS [542 UG INJ Class II-V - TEQ_02]
,     V_FORM_S1_PG2.S1542T3 AS [542 UG INJ Class II-V - TEQ_03]
,     V_FORM_S1_PG2.S1542T4 AS [542 UG INJ Class II-V - TEQ_04]
,     V_FORM_S1_PG2.S1542T5 AS [542 UG INJ Class II-V - TEQ_05]
,     V_FORM_S1_PG2.S1542T6 AS [542 UG INJ Class II-V - TEQ_06]
,     V_FORM_S1_PG2.S1542T7 AS [542 UG INJ Class II-V - TEQ_07]
,     V_FORM_S1_PG2.S1542T8 AS [542 UG INJ Class II-V - TEQ_08]
,     V_FORM_S1_PG2.S1542T9 AS [542 UG INJ Class II-V - TEQ_09]
,     V_FORM_S1_PG2.S1542T10 AS [542 UG INJ Class II-V - TEQ_10]
,     V_FORM_S1_PG2.S1542T11 AS [542 UG INJ Class II-V - TEQ_11]
,     V_FORM_S1_PG2.S1542T12 AS [542 UG INJ Class II-V - TEQ_12]
,     V_FORM_S1_PG2.S1542T13 AS [542 UG INJ Class II-V - TEQ_13]
,     V_FORM_S1_PG2.S1542T14 AS [542 UG INJ Class II-V - TEQ_14]
,     V_FORM_S1_PG2.S1542T15 AS [542 UG INJ Class II-V - TEQ_15]
,     V_FORM_S1_PG2.S1542T16 AS [542 UG INJ Class II-V - TEQ_16]
,     V_FORM_S1_PG2.S1542T17 AS [542 UG INJ Class II-V - TEQ_17]
,     V_FORM_S1_PG2.S1551ANA AS [551A RCRA C Landfill - TEQ_NAInd]
,     V_FORM_S1_PG2.S1551AT1 AS [551A RCRA C Landfill - TEQ_01]
,     V_FORM_S1_PG2.S1551AT2 AS [551A RCRA C Landfill - TEQ_02]
,     V_FORM_S1_PG2.S1551AT3 AS [551A RCRA C Landfill - TEQ_03]
,     V_FORM_S1_PG2.S1551AT4 AS [551A RCRA C Landfill - TEQ_04]
,     V_FORM_S1_PG2.S1551AT5 AS [551A RCRA C Landfill - TEQ_05]
,     V_FORM_S1_PG2.S1551AT6 AS [551A RCRA C Landfill - TEQ_06]
,     V_FORM_S1_PG2.S1551AT7 AS [551A RCRA C Landfill - TEQ_07]
,     V_FORM_S1_PG2.S1551AT8 AS [551A RCRA C Landfill - TEQ_08]
,     V_FORM_S1_PG2.S1551AT9 AS [551A RCRA C Landfill - TEQ_09]
,     V_FORM_S1_PG2.S1551AT10 AS [551A RCRA C Landfill - TEQ_10]
,     V_FORM_S1_PG2.S1551AT11 AS [551A RCRA C Landfill - TEQ_11]
,     V_FORM_S1_PG2.S1551AT12 AS [551A RCRA C Landfill - TEQ_12]
,     V_FORM_S1_PG2.S1551AT13 AS [551A RCRA C Landfill - TEQ_13]
,     V_FORM_S1_PG2.S1551AT14 AS [551A RCRA C Landfill - TEQ_14]
,     V_FORM_S1_PG2.S1551AT15 AS [551A RCRA C Landfill - TEQ_15]
,     V_FORM_S1_PG2.S1551AT16 AS [551A RCRA C Landfill - TEQ_16]
,     V_FORM_S1_PG2.S1551AT17 AS [551A RCRA C Landfill - TEQ_17]
,     V_FORM_S1_PG2.S1551BNA AS [551B Other Landfill - TEQ_NAInd]
,     V_FORM_S1_PG2.S1551BT1 AS [551B Other Landfill - TEQ_01]
,     V_FORM_S1_PG2.S1551BT2 AS [551B Other Landfill - TEQ_02]
,     V_FORM_S1_PG2.S1551BT3 AS [551B Other Landfill - TEQ_03]
,     V_FORM_S1_PG2.S1551BT4 AS [551B Other Landfill - TEQ_04]
,     V_FORM_S1_PG2.S1551BT5 AS [551B Other Landfill - TEQ_05]
,     V_FORM_S1_PG2.S1551BT6 AS [551B Other Landfill - TEQ_06]
,     V_FORM_S1_PG2.S1551BT7 AS [551B Other Landfill - TEQ_07]
,     V_FORM_S1_PG2.S1551BT8 AS [551B Other Landfill - TEQ_08]
,     V_FORM_S1_PG2.S1551BT9 AS [551B Other Landfill - TEQ_09]
,     V_FORM_S1_PG2.S1551BT10 AS [551B Other Landfill - TEQ_10]
,     V_FORM_S1_PG2.S1551BT11 AS [551B Other Landfill - TEQ_11]
,     V_FORM_S1_PG2.S1551BT12 AS [551B Other Landfill - TEQ_12]
,     V_FORM_S1_PG2.S1551BT13 AS [551B Other Landfill - TEQ_13]
,     V_FORM_S1_PG2.S1551BT14 AS [551B Other Landfill - TEQ_14]
,     V_FORM_S1_PG2.S1551BT15 AS [551B Other Landfill - TEQ_15]
,     V_FORM_S1_PG2.S1551BT16 AS [551B Other Landfill - TEQ_16]
,     V_FORM_S1_PG2.S1551BT17 AS [551B Other Landfill - TEQ_17]
,     V_FORM_S1_PG2.S1552NA AS [552 Land Treatment - TEQ_NAInd]
,     V_FORM_S1_PG2.S1552T1 AS [552 Land Treatment - TEQ_01]
,     V_FORM_S1_PG2.S1552T2 AS [552 Land Treatment - TEQ_02]
,     V_FORM_S1_PG2.S1552T3 AS [552 Land Treatment - TEQ_03]
,     V_FORM_S1_PG2.S1552T4 AS [552 Land Treatment - TEQ_04]
,     V_FORM_S1_PG2.S1552T5 AS [552 Land Treatment - TEQ_05]
,     V_FORM_S1_PG2.S1552T6 AS [552 Land Treatment - TEQ_06]
,     V_FORM_S1_PG2.S1552T7 AS [552 Land Treatment - TEQ_07]
,     V_FORM_S1_PG2.S1552T8 AS [552 Land Treatment - TEQ_08]
,     V_FORM_S1_PG2.S1552T9 AS [552 Land Treatment - TEQ_09]
,     V_FORM_S1_PG2.S1552T10 AS [552 Land Treatment - TEQ_10]
,     V_FORM_S1_PG2.S1552T11 AS [552 Land Treatment - TEQ_11]
,     V_FORM_S1_PG2.S1552T12 AS [552 Land Treatment - TEQ_12]
,     V_FORM_S1_PG2.S1552T13 AS [552 Land Treatment - TEQ_13]
,     V_FORM_S1_PG2.S1552T14 AS [552 Land Treatment - TEQ_14]
,     V_FORM_S1_PG2.S1552T15 AS [552 Land Treatment - TEQ_15]
,     V_FORM_S1_PG2.S1552T16 AS [552 Land Treatment - TEQ_16]
,     V_FORM_S1_PG2.S1552T17 AS [552 Land Treatment - TEQ_17]
,     V_FORM_S1_PG2.S1553ANA AS [553A RCRA C SI - TEQ_NAInd]
,     V_FORM_S1_PG2.S1553AT1 AS [553A RCRA C SI - TEQ_01]
,     V_FORM_S1_PG2.S1553AT2 AS [553A RCRA C SI - TEQ_02]
,     V_FORM_S1_PG2.S1553AT3 AS [553A RCRA C SI - TEQ_03]
,     V_FORM_S1_PG2.S1553AT4 AS [553A RCRA C SI - TEQ_04]
,     V_FORM_S1_PG2.S1553AT5 AS [553A RCRA C SI - TEQ_05]
,     V_FORM_S1_PG2.S1553AT6 AS [553A RCRA C SI - TEQ_06]
,     V_FORM_S1_PG2.S1553AT7 AS [553A RCRA C SI - TEQ_07]
,     V_FORM_S1_PG2.S1553AT8 AS [553A RCRA C SI - TEQ_08]
,     V_FORM_S1_PG2.S1553AT9 AS [553A RCRA C SI - TEQ_09]
,     V_FORM_S1_PG2.S1553AT10 AS [553A RCRA C SI - TEQ_10]
,     V_FORM_S1_PG2.S1553AT11 AS [553A RCRA C SI - TEQ_11]
,     V_FORM_S1_PG2.S1553AT12 AS [553A RCRA C SI - TEQ_12]
,     V_FORM_S1_PG2.S1553AT13 AS [553A RCRA C SI - TEQ_13]
,     V_FORM_S1_PG2.S1553AT14 AS [553A RCRA C SI - TEQ_14]
,     V_FORM_S1_PG2.S1553AT15 AS [553A RCRA C SI - TEQ_15]
,     V_FORM_S1_PG2.S1553AT16 AS [553A RCRA C SI - TEQ_16]
,     V_FORM_S1_PG2.S1553AT17 AS [553A RCRA C SI - TEQ_17]
,     V_FORM_S1_PG2.S1553BNA AS [553B Other SI - TEQ_NAInd]
,     V_FORM_S1_PG2.S1553BT1 AS [553B Other SI - TEQ_01]
,     V_FORM_S1_PG2.S1553BT2 AS [553B Other SI - TEQ_02]
,     V_FORM_S1_PG2.S1553BT3 AS [553B Other SI - TEQ_03]
,     V_FORM_S1_PG2.S1553BT4 AS [553B Other SI - TEQ_04]
,     V_FORM_S1_PG2.S1553BT5 AS [553B Other SI - TEQ_05]
,     V_FORM_S1_PG2.S1553BT6 AS [553B Other SI - TEQ_06]
,     V_FORM_S1_PG2.S1553BT7 AS [553B Other SI - TEQ_07]
,     V_FORM_S1_PG2.S1553BT8 AS [553B Other SI - TEQ_08]
,     V_FORM_S1_PG2.S1553BT9 AS [553B Other SI - TEQ_09]
,     V_FORM_S1_PG2.S1553BT10 AS [553B Other SI - TEQ_10]
,     V_FORM_S1_PG2.S1553BT11 AS [553B Other SI - TEQ_11]
,     V_FORM_S1_PG2.S1553BT12 AS [553B Other SI - TEQ_12]
,     V_FORM_S1_PG2.S1553BT13 AS [553B Other SI - TEQ_13]
,     V_FORM_S1_PG2.S1553BT14 AS [553B Other SI - TEQ_14]
,     V_FORM_S1_PG2.S1553BT15 AS [553B Other SI - TEQ_15]
,     V_FORM_S1_PG2.S1553BT16 AS [553B Other SI - TEQ_16]
,     V_FORM_S1_PG2.S1553BT17 AS [553B Other SI - TEQ_17]
,     V_FORM_S1_PG2.S1554NA AS [554 Other Disposal - TEQ_NAInd]
,     V_FORM_S1_PG2.S1554T1 AS [554 Other Disposal - TEQ_01]
,     V_FORM_S1_PG2.S1554T2 AS [554 Other Disposal - TEQ_02]
,     V_FORM_S1_PG2.S1554T3 AS [554 Other Disposal - TEQ_03]
,     V_FORM_S1_PG2.S1554T4 AS [554 Other Disposal - TEQ_04]
,     V_FORM_S1_PG2.S1554T5 AS [554 Other Disposal - TEQ_05]
,     V_FORM_S1_PG2.S1554T6 AS [554 Other Disposal - TEQ_06]
,     V_FORM_S1_PG2.S1554T7 AS [554 Other Disposal - TEQ_07]
,     V_FORM_S1_PG2.S1554T8 AS [554 Other Disposal - TEQ_08]
,     V_FORM_S1_PG2.S1554T9 AS [554 Other Disposal - TEQ_09]
,     V_FORM_S1_PG2.S1554T10 AS [554 Other Disposal - TEQ_10]
,     V_FORM_S1_PG2.S1554T11 AS [554 Other Disposal - TEQ_11]
,     V_FORM_S1_PG2.S1554T12 AS [554 Other Disposal - TEQ_12]
,     V_FORM_S1_PG2.S1554T13 AS [554 Other Disposal - TEQ_13]
,     V_FORM_S1_PG2.S1554T14 AS [554 Other Disposal - TEQ_14]
,     V_FORM_S1_PG2.S1554T15 AS [554 Other Disposal - TEQ_15]
,     V_FORM_S1_PG2.S1554T16 AS [554 Other Disposal - TEQ_16]
,     V_FORM_S1_PG2.S1554T17 AS [554 Other Disposal - TEQ_17]
,     V_FORM_S1_PG3.S161A3NA AS [POTW Waste Quantity - TEQ_NAInd]
,     V_FORM_S1_PG3.S161A3T1 AS [POTW Waste Quantity - TEQ_01]
,     V_FORM_S1_PG3.S161A3T2 AS [POTW Waste Quantity - TEQ_02]
,     V_FORM_S1_PG3.S161A3T3 AS [POTW Waste Quantity - TEQ_03]
,     V_FORM_S1_PG3.S161A3T4 AS [POTW Waste Quantity - TEQ_04]
,     V_FORM_S1_PG3.S161A3T5 AS [POTW Waste Quantity - TEQ_05]
,     V_FORM_S1_PG3.S161A3T6 AS [POTW Waste Quantity - TEQ_06]
,     V_FORM_S1_PG3.S161A3T7 AS [POTW Waste Quantity - TEQ_07]
,     V_FORM_S1_PG3.S161A3T8 AS [POTW Waste Quantity - TEQ_08]
,     V_FORM_S1_PG3.S161A3T9 AS [POTW Waste Quantity - TEQ_09]
,     V_FORM_S1_PG3.S161A3T10 AS [POTW Waste Quantity - TEQ_10]
,     V_FORM_S1_PG3.S161A3T11 AS [POTW Waste Quantity - TEQ_11]
,     V_FORM_S1_PG3.S161A3T12 AS [POTW Waste Quantity - TEQ_12]
,     V_FORM_S1_PG3.S161A3T13 AS [POTW Waste Quantity - TEQ_13]
,     V_FORM_S1_PG3.S161A3T14 AS [POTW Waste Quantity - TEQ_14]
,     V_FORM_S1_PG3.S161A3T15 AS [POTW Waste Quantity - TEQ_15]
,     V_FORM_S1_PG3.S161A3T16 AS [POTW Waste Quantity - TEQ_16]
,     V_FORM_S1_PG3.S161A3T17 AS [POTW Waste Quantity - TEQ_17]
,     V_FORM_S1_PG4.S181ANA AS [81A Ons Disp UG INJ C1 - TEQ_NAInd]
,     V_FORM_S1_PG4.S181AT1 AS [81A Ons Disp UG INJ C1 - TEQ_01]
,     V_FORM_S1_PG4.S181AT2 AS [81A Ons Disp UG INJ C1 - TEQ_02]
,     V_FORM_S1_PG4.S181AT3 AS [81A Ons Disp UG INJ C1 - TEQ_03]
,     V_FORM_S1_PG4.S181AT4 AS [81A Ons Disp UG INJ C1 - TEQ_04]
,     V_FORM_S1_PG4.S181AT5 AS [81A Ons Disp UG INJ C1 - TEQ_05]
,     V_FORM_S1_PG4.S181AT6 AS [81A Ons Disp UG INJ C1 - TEQ_06]
,     V_FORM_S1_PG4.S181AT7 AS [81A Ons Disp UG INJ C1 - TEQ_07]
,     V_FORM_S1_PG4.S181AT8 AS [81A Ons Disp UG INJ C1 - TEQ_08]
,     V_FORM_S1_PG4.S181AT9 AS [81A Ons Disp UG INJ C1 - TEQ_09]
,     V_FORM_S1_PG4.S181AT10 AS [81A Ons Disp UG INJ C1 - TEQ_10]
,     V_FORM_S1_PG4.S181AT11 AS [81A Ons Disp UG INJ C1 - TEQ_11]
,     V_FORM_S1_PG4.S181AT12 AS [81A Ons Disp UG INJ C1 - TEQ_12]
,     V_FORM_S1_PG4.S181AT13 AS [81A Ons Disp UG INJ C1 - TEQ_13]
,     V_FORM_S1_PG4.S181AT14 AS [81A Ons Disp UG INJ C1 - TEQ_14]
,     V_FORM_S1_PG4.S181AT15 AS [81A Ons Disp UG INJ C1 - TEQ_15]
,     V_FORM_S1_PG4.S181AT16 AS [81A Ons Disp UG INJ C1 - TEQ_16]
,     V_FORM_S1_PG4.S181AT17 AS [81A Ons Disp UG INJ C1 - TEQ_17]
,     V_FORM_S1_PG4.S181BNA AS [81B Ons Disp Other - TEQ_NAInd]
,     V_FORM_S1_PG4.S181BT1 AS [81B Ons Disp Other - TEQ_01]
,     V_FORM_S1_PG4.S181BT2 AS [81B Ons Disp Other - TEQ_02]
,     V_FORM_S1_PG4.S181BT3 AS [81B Ons Disp Other - TEQ_03]
,     V_FORM_S1_PG4.S181BT4 AS [81B Ons Disp Other - TEQ_04]
,     V_FORM_S1_PG4.S181BT5 AS [81B Ons Disp Other - TEQ_05]
,     V_FORM_S1_PG4.S181BT6 AS [81B Ons Disp Other - TEQ_06]
,     V_FORM_S1_PG4.S181BT7 AS [81B Ons Disp Other - TEQ_07]
,     V_FORM_S1_PG4.S181BT8 AS [81B Ons Disp Other - TEQ_08]
,     V_FORM_S1_PG4.S181BT9 AS [81B Ons Disp Other - TEQ_09]
,     V_FORM_S1_PG4.S181BT10 AS [81B Ons Disp Other - TEQ_10]
,     V_FORM_S1_PG4.S181BT11 AS [81B Ons Disp Other - TEQ_11]
,     V_FORM_S1_PG4.S181BT12 AS [81B Ons Disp Other - TEQ_12]
,     V_FORM_S1_PG4.S181BT13 AS [81B Ons Disp Other - TEQ_13]
,     V_FORM_S1_PG4.S181BT14 AS [81B Ons Disp Other - TEQ_14]
,     V_FORM_S1_PG4.S181BT15 AS [81B Ons Disp Other - TEQ_15]
,     V_FORM_S1_PG4.S181BT16 AS [81B Ons Disp Other - TEQ_16]
,     V_FORM_S1_PG4.S181BT17 AS [81B Ons Disp Other - TEQ_17]
,     V_FORM_S1_PG4.S181CNA AS [81C Off Disp UG INJ C1 - TEQ_NAInd]
,     V_FORM_S1_PG4.S181CT1 AS [81C Off Disp UG INJ C1 - TEQ_01]
,     V_FORM_S1_PG4.S181CT2 AS [81C Off Disp UG INJ C1 - TEQ_02]
,     V_FORM_S1_PG4.S181CT3 AS [81C Off Disp UG INJ C1 - TEQ_03]
,     V_FORM_S1_PG4.S181CT4 AS [81C Off Disp UG INJ C1 - TEQ_04]
,     V_FORM_S1_PG4.S181CT5 AS [81C Off Disp UG INJ C1 - TEQ_05]
,     V_FORM_S1_PG4.S181CT6 AS [81C Off Disp UG INJ C1 - TEQ_06]
,     V_FORM_S1_PG4.S181CT7 AS [81C Off Disp UG INJ C1 - TEQ_07]
,     V_FORM_S1_PG4.S181CT8 AS [81C Off Disp UG INJ C1 - TEQ_08]
,     V_FORM_S1_PG4.S181CT9 AS [81C Off Disp UG INJ C1 - TEQ_09]
,     V_FORM_S1_PG4.S181CT10 AS [81C Off Disp UG INJ C1 - TEQ_10]
,     V_FORM_S1_PG4.S181CT11 AS [81C Off Disp UG INJ C1 - TEQ_11]
,     V_FORM_S1_PG4.S181CT12 AS [81C Off Disp UG INJ C1 - TEQ_12]
,     V_FORM_S1_PG4.S181CT13 AS [81C Off Disp UG INJ C1 - TEQ_13]
,     V_FORM_S1_PG4.S181CT14 AS [81C Off Disp UG INJ C1 - TEQ_14]
,     V_FORM_S1_PG4.S181CT15 AS [81C Off Disp UG INJ C1 - TEQ_15]
,     V_FORM_S1_PG4.S181CT16 AS [81C Off Disp UG INJ C1 - TEQ_16]
,     V_FORM_S1_PG4.S181CT17 AS [81C Off Disp UG INJ C1 - TEQ_17]
,     V_FORM_S1_PG4.S181DNA AS [81D Off Disp Other - TEQ_NAInd]
,     V_FORM_S1_PG4.S181DT1 AS [81D Off Disp Other - TEQ_01]
,     V_FORM_S1_PG4.S181DT2 AS [81D Off Disp Other - TEQ_02]
,     V_FORM_S1_PG4.S181DT3 AS [81D Off Disp Other - TEQ_03]
,     V_FORM_S1_PG4.S181DT4 AS [81D Off Disp Other - TEQ_04]
,     V_FORM_S1_PG4.S181DT5 AS [81D Off Disp Other - TEQ_05]
,     V_FORM_S1_PG4.S181DT6 AS [81D Off Disp Other - TEQ_06]
,     V_FORM_S1_PG4.S181DT7 AS [81D Off Disp Other - TEQ_07]
,     V_FORM_S1_PG4.S181DT8 AS [81D Off Disp Other - TEQ_08]
,     V_FORM_S1_PG4.S181DT9 AS [81D Off Disp Other - TEQ_09]
,     V_FORM_S1_PG4.S181DT10 AS [81D Off Disp Other - TEQ_10]
,     V_FORM_S1_PG4.S181DT11 AS [81D Off Disp Other - TEQ_11]
,     V_FORM_S1_PG4.S181DT12 AS [81D Off Disp Other - TEQ_12]
,     V_FORM_S1_PG4.S181DT13 AS [81D Off Disp Other - TEQ_13]
,     V_FORM_S1_PG4.S181DT14 AS [81D Off Disp Other - TEQ_14]
,     V_FORM_S1_PG4.S181DT15 AS [81D Off Disp Other - TEQ_15]
,     V_FORM_S1_PG4.S181DT16 AS [81D Off Disp Other - TEQ_16]
,     V_FORM_S1_PG4.S181DT17 AS [81D Off Disp Other - TEQ_17]
,     V_FORM_S1_PG4.S182NA AS [82 Ons Eng Rec - TEQ_NAInd]
,     V_FORM_S1_PG4.S182T1 AS [82 Ons Eng Rec - TEQ_01]
,     V_FORM_S1_PG4.S182T2 AS [82 Ons Eng Rec - TEQ_02]
,     V_FORM_S1_PG4.S182T3 AS [82 Ons Eng Rec - TEQ_03]
,     V_FORM_S1_PG4.S182T4 AS [82 Ons Eng Rec - TEQ_04]
,     V_FORM_S1_PG4.S182T5 AS [82 Ons Eng Rec - TEQ_05]
,     V_FORM_S1_PG4.S182T6 AS [82 Ons Eng Rec - TEQ_06]
,     V_FORM_S1_PG4.S182T7 AS [82 Ons Eng Rec - TEQ_07]
,     V_FORM_S1_PG4.S182T8 AS [82 Ons Eng Rec - TEQ_08]
,     V_FORM_S1_PG4.S182T9 AS [82 Ons Eng Rec - TEQ_09]
,     V_FORM_S1_PG4.S182T10 AS [82 Ons Eng Rec - TEQ_10]
,     V_FORM_S1_PG4.S182T11 AS [82 Ons Eng Rec - TEQ_11]
,     V_FORM_S1_PG4.S182T12 AS [82 Ons Eng Rec - TEQ_12]
,     V_FORM_S1_PG4.S182T13 AS [82 Ons Eng Rec - TEQ_13]
,     V_FORM_S1_PG4.S182T14 AS [82 Ons Eng Rec - TEQ_14]
,     V_FORM_S1_PG4.S182T15 AS [82 Ons Eng Rec - TEQ_15]
,     V_FORM_S1_PG4.S182T16 AS [82 Ons Eng Rec - TEQ_16]
,     V_FORM_S1_PG4.S182T17 AS [82 Ons Eng Rec - TEQ_17]
,     V_FORM_S1_PG4.S183NA AS [83 Off Eng Rec - TEQ_NAInd]
,     V_FORM_S1_PG4.S183T1 AS [83 Off Eng Rec - TEQ_01]
,     V_FORM_S1_PG4.S183T2 AS [83 Off Eng Rec - TEQ_02]
,     V_FORM_S1_PG4.S183T3 AS [83 Off Eng Rec - TEQ_03]
,     V_FORM_S1_PG4.S183T4 AS [83 Off Eng Rec - TEQ_04]
,     V_FORM_S1_PG4.S183T5 AS [83 Off Eng Rec - TEQ_05]
,     V_FORM_S1_PG4.S183T6 AS [83 Off Eng Rec - TEQ_06]
,     V_FORM_S1_PG4.S183T7 AS [83 Off Eng Rec - TEQ_07]
,     V_FORM_S1_PG4.S183T8 AS [83 Off Eng Rec - TEQ_08]
,     V_FORM_S1_PG4.S183T9 AS [83 Off Eng Rec - TEQ_09]
,     V_FORM_S1_PG4.S183T10 AS [83 Off Eng Rec - TEQ_10]
,     V_FORM_S1_PG4.S183T11 AS [83 Off Eng Rec - TEQ_11]
,     V_FORM_S1_PG4.S183T12 AS [83 Off Eng Rec - TEQ_12]
,     V_FORM_S1_PG4.S183T13 AS [83 Off Eng Rec - TEQ_13]
,     V_FORM_S1_PG4.S183T14 AS [83 Off Eng Rec - TEQ_14]
,     V_FORM_S1_PG4.S183T15 AS [83 Off Eng Rec - TEQ_15]
,     V_FORM_S1_PG4.S183T16 AS [83 Off Eng Rec - TEQ_16]
,     V_FORM_S1_PG4.S183T17 AS [83 Off Eng Rec - TEQ_17]
,     V_FORM_S1_PG4.S184NA AS [84 Ons Recycle - TEQ_NAInd]
,     V_FORM_S1_PG4.S184T1 AS [84 Ons Recycle - TEQ_01]
,     V_FORM_S1_PG4.S184T2 AS [84 Ons Recycle - TEQ_02]
,     V_FORM_S1_PG4.S184T3 AS [84 Ons Recycle - TEQ_03]
,     V_FORM_S1_PG4.S184T4 AS [84 Ons Recycle - TEQ_04]
,     V_FORM_S1_PG4.S184T5 AS [84 Ons Recycle - TEQ_05]
,     V_FORM_S1_PG4.S184T6 AS [84 Ons Recycle - TEQ_06]
,     V_FORM_S1_PG4.S184T7 AS [84 Ons Recycle - TEQ_07]
,     V_FORM_S1_PG4.S184T8 AS [84 Ons Recycle - TEQ_08]
,     V_FORM_S1_PG4.S184T9 AS [84 Ons Recycle - TEQ_09]
,     V_FORM_S1_PG4.S184T10 AS [84 Ons Recycle - TEQ_10]
,     V_FORM_S1_PG4.S184T11 AS [84 Ons Recycle - TEQ_11]
,     V_FORM_S1_PG4.S184T12 AS [84 Ons Recycle - TEQ_12]
,     V_FORM_S1_PG4.S184T13 AS [84 Ons Recycle - TEQ_13]
,     V_FORM_S1_PG4.S184T14 AS [84 Ons Recycle - TEQ_14]
,     V_FORM_S1_PG4.S184T15 AS [84 Ons Recycle - TEQ_15]
,     V_FORM_S1_PG4.S184T16 AS [84 Ons Recycle - TEQ_16]
,     V_FORM_S1_PG4.S184T17 AS [84 Ons Recycle - TEQ_17]
,     V_FORM_S1_PG4.S185NA AS [85 Off Recycle - TEQ_NAInd]
,     V_FORM_S1_PG4.S185T1 AS [85 Off Recycle - TEQ_01]
,     V_FORM_S1_PG4.S185T2 AS [85 Off Recycle - TEQ_02]
,     V_FORM_S1_PG4.S185T3 AS [85 Off Recycle - TEQ_03]
,     V_FORM_S1_PG4.S185T4 AS [85 Off Recycle - TEQ_04]
,     V_FORM_S1_PG4.S185T5 AS [85 Off Recycle - TEQ_05]
,     V_FORM_S1_PG4.S185T6 AS [85 Off Recycle - TEQ_06]
,     V_FORM_S1_PG4.S185T7 AS [85 Off Recycle - TEQ_07]
,     V_FORM_S1_PG4.S185T8 AS [85 Off Recycle - TEQ_08]
,     V_FORM_S1_PG4.S185T9 AS [85 Off Recycle - TEQ_09]
,     V_FORM_S1_PG4.S185T10 AS [85 Off Recycle - TEQ_10]
,     V_FORM_S1_PG4.S185T11 AS [85 Off Recycle - TEQ_11]
,     V_FORM_S1_PG4.S185T12 AS [85 Off Recycle - TEQ_12]
,     V_FORM_S1_PG4.S185T13 AS [85 Off Recycle - TEQ_13]
,     V_FORM_S1_PG4.S185T14 AS [85 Off Recycle - TEQ_14]
,     V_FORM_S1_PG4.S185T15 AS [85 Off Recycle - TEQ_15]
,     V_FORM_S1_PG4.S185T16 AS [85 Off Recycle - TEQ_16]
,     V_FORM_S1_PG4.S185T17 AS [85 Off Recycle - TEQ_17]
,     V_FORM_S1_PG4.S186NA AS [86 Ons Treated - TEQ_NAInd]
,     V_FORM_S1_PG4.S186T1 AS [86 Ons Treated - TEQ_01]
,     V_FORM_S1_PG4.S186T2 AS [86 Ons Treated - TEQ_02]
,     V_FORM_S1_PG4.S186T3 AS [86 Ons Treated - TEQ_03]
,     V_FORM_S1_PG4.S186T4 AS [86 Ons Treated - TEQ_04]
,     V_FORM_S1_PG4.S186T5 AS [86 Ons Treated - TEQ_05]
,     V_FORM_S1_PG4.S186T6 AS [86 Ons Treated - TEQ_06]
,     V_FORM_S1_PG4.S186T7 AS [86 Ons Treated - TEQ_07]
,     V_FORM_S1_PG4.S186T8 AS [86 Ons Treated - TEQ_08]
,     V_FORM_S1_PG4.S186T9 AS [86 Ons Treated - TEQ_09]
,     V_FORM_S1_PG4.S186T10 AS [86 Ons Treated - TEQ_10]
,     V_FORM_S1_PG4.S186T11 AS [86 Ons Treated - TEQ_11]
,     V_FORM_S1_PG4.S186T12 AS [86 Ons Treated - TEQ_12]
,     V_FORM_S1_PG4.S186T13 AS [86 Ons Treated - TEQ_13]
,     V_FORM_S1_PG4.S186T14 AS [86 Ons Treated - TEQ_14]
,     V_FORM_S1_PG4.S186T15 AS [86 Ons Treated - TEQ_15]
,     V_FORM_S1_PG4.S186T16 AS [86 Ons Treated - TEQ_16]
,     V_FORM_S1_PG4.S186T17 AS [86 Ons Treated - TEQ_17]
,     V_FORM_S1_PG4.S187NA AS [87 Off Treated - TEQ_NAInd]
,     V_FORM_S1_PG4.S187T1 AS [87 Off Treated - TEQ_01]
,     V_FORM_S1_PG4.S187T2 AS [87 Off Treated - TEQ_02]
,     V_FORM_S1_PG4.S187T3 AS [87 Off Treated - TEQ_03]
,     V_FORM_S1_PG4.S187T4 AS [87 Off Treated - TEQ_04]
,     V_FORM_S1_PG4.S187T5 AS [87 Off Treated - TEQ_05]
,     V_FORM_S1_PG4.S187T6 AS [87 Off Treated - TEQ_06]
,     V_FORM_S1_PG4.S187T7 AS [87 Off Treated - TEQ_07]
,     V_FORM_S1_PG4.S187T8 AS [87 Off Treated - TEQ_08]
,     V_FORM_S1_PG4.S187T9 AS [87 Off Treated - TEQ_09]
,     V_FORM_S1_PG4.S187T10 AS [87 Off Treated - TEQ_10]
,     V_FORM_S1_PG4.S187T11 AS [87 Off Treated - TEQ_11]
,     V_FORM_S1_PG4.S187T12 AS [87 Off Treated - TEQ_12]
,     V_FORM_S1_PG4.S187T13 AS [87 Off Treated - TEQ_13]
,     V_FORM_S1_PG4.S187T14 AS [87 Off Treated - TEQ_14]
,     V_FORM_S1_PG4.S187T15 AS [87 Off Treated - TEQ_15]
,     V_FORM_S1_PG4.S187T16 AS [87 Off Treated - TEQ_16]
,     V_FORM_S1_PG4.S187T17 AS [87 Off Treated - TEQ_17]
,     V_FORM_S1_PG4.S188NA AS [88 Remed One-Time - TEQ_NAInd]
,     V_FORM_S1_PG4.S188T1 AS [88 Remed One-Time - TEQ_01]
,     V_FORM_S1_PG4.S188T2 AS [88 Remed One-Time - TEQ_02]
,     V_FORM_S1_PG4.S188T3 AS [88 Remed One-Time - TEQ_03]
,     V_FORM_S1_PG4.S188T4 AS [88 Remed One-Time - TEQ_04]
,     V_FORM_S1_PG4.S188T5 AS [88 Remed One-Time - TEQ_05]
,     V_FORM_S1_PG4.S188T6 AS [88 Remed One-Time - TEQ_06]
,     V_FORM_S1_PG4.S188T7 AS [88 Remed One-Time - TEQ_07]
,     V_FORM_S1_PG4.S188T8 AS [88 Remed One-Time - TEQ_08]
,     V_FORM_S1_PG4.S188T9 AS [88 Remed One-Time - TEQ_09]
,     V_FORM_S1_PG4.S188T10 AS [88 Remed One-Time - TEQ_10]
,     V_FORM_S1_PG4.S188T11 AS [88 Remed One-Time - TEQ_11]
,     V_FORM_S1_PG4.S188T12 AS [88 Remed One-Time - TEQ_12]
,     V_FORM_S1_PG4.S188T13 AS [88 Remed One-Time - TEQ_13]
,     V_FORM_S1_PG4.S188T14 AS [88 Remed One-Time - TEQ_14]
,     V_FORM_S1_PG4.S188T15 AS [88 Remed One-Time - TEQ_15]
,     V_FORM_S1_PG4.S188T16 AS [88 Remed One-Time - TEQ_16]
,     V_FORM_S1_PG4.S188T17 AS [88 Remed One-Time - TEQ_17]

,     R.SUB_REP_YEAR AS SUBMISSION_REPORTING_YEAR
,     CTYREG.EcologyRegion AS ECOLOGY_REGION
,     T.AgencyID AS FS_ID
,     T.EPAID AS EPA_ID
,     F.COUNTY AS COUNTY_NM
,     F.FAC_SITE AS FAC_NAME
,     T.AgencyName
,     C.CHEM_TXT AS CHEMICAL_NAME_TEXT

FROM dbo.TRI_SUB S
JOIN dbo.TRI_FAC F ON F.FK_GUID = S.PK_GUID
LEFT JOIN dbo.App_Lookup_Cty_Reg CTYREG ON CTYREG.County = F.COUNTY
JOIN dbo.TRI_REPORT R ON R.FK_GUID = S.PK_GUID
JOIN dbo.TRI_CHEM C ON C.FK_GUID = R.PK_GUID
JOIN dbo.App_FI_TRIFID T ON T.TRIFID = F.FAC_ID
JOIN [dbo].[V_FORM_S1_PG1] ON [dbo].[V_FORM_S1_PG1].PK_GUID_REP = R.PK_GUID
JOIN [dbo].[V_FORM_S1_PG2] ON [dbo].[V_FORM_S1_PG2].PK_GUID_REP = R.PK_GUID
JOIN [dbo].[V_FORM_S1_PG3] ON [dbo].[V_FORM_S1_PG3].PK_GUID_REP = R.PK_GUID
JOIN [dbo].[V_FORM_S1_PG4] ON [dbo].[V_FORM_S1_PG4].PK_GUID_REP = R.PK_GUID

WHERE C.CAS_CLBER = ''N150''

'
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetRSubmissionData]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetRSubmissionData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets submission Data by Submission id
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetRSubmissionData] (
	@subId varchar(36) = NULL,
	@repId varchar(36) = NULL
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF (@subId IS NULL AND @repId IS NULL)
		RAISERROR (''Both arguments Submission Id and Report Id cannot be NULL'', 11,1)

	SELECT * FROM V_TRI_PAGE1 
	WHERE PK_GUID_SUB = COALESCE(@subId, PK_GUID_SUB) AND PK_GUID_REP = COALESCE(@repId, PK_GUID_REP);

	SELECT * FROM V_TRI_PAGE2 
	WHERE PK_GUID_SUB = COALESCE(@subId, PK_GUID_SUB) AND PK_GUID_REP = COALESCE(@repId, PK_GUID_REP);

	SELECT * FROM V_TRI_PAGE3 
	WHERE PK_GUID_SUB = COALESCE(@subId, PK_GUID_SUB) AND PK_GUID_REP = COALESCE(@repId, PK_GUID_REP);

	SELECT * FROM V_TRI_PAGE4 
	WHERE PK_GUID_SUB = COALESCE(@subId, PK_GUID_SUB) AND PK_GUID_REP = COALESCE(@repId, PK_GUID_REP);

	SELECT * FROM V_TRI_PAGE5 
	WHERE PK_GUID_SUB = COALESCE(@subId, PK_GUID_SUB) AND PK_GUID_REP = COALESCE(@repId, PK_GUID_REP);
	

END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[TRI_GetSubmissionData]    Script Date: 12/02/2010 14:15:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TRI_GetSubmissionData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Mark Chmarny
-- Create date: 2007-05-23
-- Description:	Gets submission Data by Submission id
-- =============================================
CREATE PROCEDURE [dbo].[TRI_GetSubmissionData] (
	@subid varchar(36)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM V_TRI_PAGE1 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_TRI_PAGE2 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_TRI_PAGE3 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_TRI_PAGE4 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_TRI_PAGE5 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_FORM_A_PG_1 WHERE PK_GUID_SUB = @subid;
	SELECT * FROM V_FORM_A_PG_2 WHERE PK_GUID_SUB = @subid;
	

END

' 
END
GO
/****** Object:  ForeignKey [FK_App_FI_TRIFID_Delete_App_FI_TRIFID]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_FI_TRIFID_Delete_App_FI_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Delete]'))
ALTER TABLE [dbo].[App_FI_TRIFID_Delete]  WITH CHECK ADD  CONSTRAINT [FK_App_FI_TRIFID_Delete_App_FI_TRIFID] FOREIGN KEY([TRIFID_ID_FK])
REFERENCES [dbo].[App_FI_TRIFID] ([TRIFID_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_FI_TRIFID_Delete_App_FI_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Delete]'))
ALTER TABLE [dbo].[App_FI_TRIFID_Delete] CHECK CONSTRAINT [FK_App_FI_TRIFID_Delete_App_FI_TRIFID]
GO
/****** Object:  ForeignKey [FK_App_TRIFID_Comment_App_TRIFID]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_TRIFID_Comment_App_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Comment]'))
ALTER TABLE [dbo].[App_FI_TRIFID_Comment]  WITH NOCHECK ADD  CONSTRAINT [FK_App_TRIFID_Comment_App_TRIFID] FOREIGN KEY([TRIFID_ID_FK])
REFERENCES [dbo].[App_FI_TRIFID] ([TRIFID_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_TRIFID_Comment_App_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_FI_TRIFID_Comment]'))
ALTER TABLE [dbo].[App_FI_TRIFID_Comment] CHECK CONSTRAINT [FK_App_TRIFID_Comment_App_TRIFID]
GO
/****** Object:  ForeignKey [FK_App_EmailLog_TRI_SUB]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_EmailLog_TRI_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_EmailLog]'))
ALTER TABLE [dbo].[App_EmailLog]  WITH CHECK ADD  CONSTRAINT [FK_App_EmailLog_TRI_SUB] FOREIGN KEY([TRI_SUB_ID])
REFERENCES [dbo].[TRI_SUB] ([PK_GUID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_EmailLog_TRI_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_EmailLog]'))
ALTER TABLE [dbo].[App_EmailLog] CHECK CONSTRAINT [FK_App_EmailLog_TRI_SUB]
GO
/****** Object:  ForeignKey [FK_FAC_SUB]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC]'))
ALTER TABLE [dbo].[TRI_FAC]  WITH CHECK ADD  CONSTRAINT [FK_FAC_SUB] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_SUB] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FAC_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC]'))
ALTER TABLE [dbo].[TRI_FAC] CHECK CONSTRAINT [FK_FAC_SUB]
GO
/****** Object:  ForeignKey [FK_App_ManualSubmissionLog_App_FI_TRIFID]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_ManualSubmissionLog_App_FI_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_ManualSubmissionLog]'))
ALTER TABLE [dbo].[App_ManualSubmissionLog]  WITH NOCHECK ADD  CONSTRAINT [FK_App_ManualSubmissionLog_App_FI_TRIFID] FOREIGN KEY([TRIFID_ID_FK])
REFERENCES [dbo].[App_FI_TRIFID] ([TRIFID_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_App_ManualSubmissionLog_App_FI_TRIFID]') AND parent_object_id = OBJECT_ID(N'[dbo].[App_ManualSubmissionLog]'))
ALTER TABLE [dbo].[App_ManualSubmissionLog] CHECK CONSTRAINT [FK_App_ManualSubmissionLog_App_FI_TRIFID]
GO
/****** Object:  ForeignKey [FK_REPORT_SUB]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_REPORT_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]'))
ALTER TABLE [dbo].[TRI_REPORT]  WITH NOCHECK ADD  CONSTRAINT [FK_REPORT_SUB] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_SUB] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_REPORT_SUB]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPORT]'))
ALTER TABLE [dbo].[TRI_REPORT] CHECK CONSTRAINT [FK_REPORT_SUB]
GO
/****** Object:  ForeignKey [FK_SRCREDACT_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SRCREDACT_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_ACT]'))
ALTER TABLE [dbo].[TRI_SRC_RED_ACT]  WITH NOCHECK ADD  CONSTRAINT [FK_SRCREDACT_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SRCREDACT_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_ACT]'))
ALTER TABLE [dbo].[TRI_SRC_RED_ACT] CHECK CONSTRAINT [FK_SRCREDACT_REPORT]
GO
/****** Object:  ForeignKey [FK_TRI_REPORT_VALIDATION_TRI_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRI_REPORT_VALIDATION_TRI_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPORT_VALIDATION]'))
ALTER TABLE [dbo].[TRI_REPORT_VALIDATION]  WITH NOCHECK ADD  CONSTRAINT [FK_TRI_REPORT_VALIDATION_TRI_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRI_REPORT_VALIDATION_TRI_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPORT_VALIDATION]'))
ALTER TABLE [dbo].[TRI_REPORT_VALIDATION] CHECK CONSTRAINT [FK_TRI_REPORT_VALIDATION_TRI_REPORT]
GO
/****** Object:  ForeignKey [FK_WASTETREATDTL_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WASTETREATDTL_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_DTL]'))
ALTER TABLE [dbo].[TRI_WASTE_TREAT_DTL]  WITH NOCHECK ADD  CONSTRAINT [FK_WASTETREATDTL_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WASTETREATDTL_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_DTL]'))
ALTER TABLE [dbo].[TRI_WASTE_TREAT_DTL] CHECK CONSTRAINT [FK_WASTETREATDTL_REPORT]
GO
/****** Object:  ForeignKey [FK_REPLACEDREPORTID_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_REPLACEDREPORTID_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPLACED_REPORT_ID]'))
ALTER TABLE [dbo].[TRI_REPLACED_REPORT_ID]  WITH NOCHECK ADD  CONSTRAINT [FK_REPLACEDREPORTID_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_REPLACEDREPORTID_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_REPLACED_REPORT_ID]'))
ALTER TABLE [dbo].[TRI_REPLACED_REPORT_ID] CHECK CONSTRAINT [FK_REPLACEDREPORTID_REPORT]
GO
/****** Object:  ForeignKey [FK_RCRAID_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RCRAID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_RCRA_ID]'))
ALTER TABLE [dbo].[TRI_RCRA_ID]  WITH CHECK ADD  CONSTRAINT [FK_RCRAID_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RCRAID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_RCRA_ID]'))
ALTER TABLE [dbo].[TRI_RCRA_ID] CHECK CONSTRAINT [FK_RCRAID_FAC]
GO
/****** Object:  ForeignKey [FK_TRANSFERLOC_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRANSFERLOC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_LOC]'))
ALTER TABLE [dbo].[TRI_TRANSFER_LOC]  WITH NOCHECK ADD  CONSTRAINT [FK_TRANSFERLOC_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRANSFERLOC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_LOC]'))
ALTER TABLE [dbo].[TRI_TRANSFER_LOC] CHECK CONSTRAINT [FK_TRANSFERLOC_REPORT]
GO
/****** Object:  ForeignKey [FK_UICID_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UICID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_UIC_ID]'))
ALTER TABLE [dbo].[TRI_UIC_ID]  WITH CHECK ADD  CONSTRAINT [FK_UICID_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UICID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_UIC_ID]'))
ALTER TABLE [dbo].[TRI_UIC_ID] CHECK CONSTRAINT [FK_UICID_FAC]
GO
/****** Object:  ForeignKey [FK_ONSITEUICDISPQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEUICDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_UIC_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_UIC_DISP_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITEUICDISPQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEUICDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_UIC_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_UIC_DISP_QTY] CHECK CONSTRAINT [FK_ONSITEUICDISPQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITETREATEDQ_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITETREATEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_TREATED_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_TREATED_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITETREATEDQ_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITETREATEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_TREATED_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_TREATED_Q] CHECK CONSTRAINT [FK_ONSITETREATEDQ_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITERELEASEQ_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERELEASEQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RELEASE_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_RELEASE_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITERELEASEQ_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERELEASEQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RELEASE_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_RELEASE_Q] CHECK CONSTRAINT [FK_ONSITERELEASEQ_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITERECYCLEDQ_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERECYCLEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCLED_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_RECYCLED_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITERECYCLEDQ_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERECYCLEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCLED_Q]'))
ALTER TABLE [dbo].[TRI_ONSITE_RECYCLED_Q] CHECK CONSTRAINT [FK_ONSITERECYCLEDQ_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITERECYCGPROC_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERECYCGPROC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCG_PROC]'))
ALTER TABLE [dbo].[TRI_ONSITE_RECYCG_PROC]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITERECYCGPROC_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERECYCGPROC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RECYCG_PROC]'))
ALTER TABLE [dbo].[TRI_ONSITE_RECYCG_PROC] CHECK CONSTRAINT [FK_ONSITERECYCGPROC_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITERCVPROC_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERCVPROC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RCV_PROC]'))
ALTER TABLE [dbo].[TRI_ONSITE_RCV_PROC]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITERCVPROC_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITERCVPROC_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_RCV_PROC]'))
ALTER TABLE [dbo].[TRI_ONSITE_RCV_PROC] CHECK CONSTRAINT [FK_ONSITERCVPROC_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITEENERGYRCVQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEENERGYRCVQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_ENERGY_RCV_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_ENERGY_RCV_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITEENERGYRCVQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEENERGYRCVQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_ENERGY_RCV_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_ENERGY_RCV_QTY] CHECK CONSTRAINT [FK_ONSITEENERGYRCVQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_ONSITEDISPQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_DISP_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_ONSITEDISPQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ONSITEDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_ONSITE_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_ONSITE_DISP_QTY] CHECK CONSTRAINT [FK_ONSITEDISPQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_OFFSITEUICDISPQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEUICDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_UIC_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_UIC_DISP_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_OFFSITEUICDISPQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEUICDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_UIC_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_UIC_DISP_QTY] CHECK CONSTRAINT [FK_OFFSITEUICDISPQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_OFFSITETREATEDQ_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITETREATEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_TREATED_Q]'))
ALTER TABLE [dbo].[TRI_OFFSITE_TREATED_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_OFFSITETREATEDQ_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITETREATEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_TREATED_Q]'))
ALTER TABLE [dbo].[TRI_OFFSITE_TREATED_Q] CHECK CONSTRAINT [FK_OFFSITETREATEDQ_REPORT]
GO
/****** Object:  ForeignKey [FK_OFFSITERECYCLEDQ_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITERECYCLEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_RECYCLED_Q]'))
ALTER TABLE [dbo].[TRI_OFFSITE_RECYCLED_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_OFFSITERECYCLEDQ_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITERECYCLEDQ_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_RECYCLED_Q]'))
ALTER TABLE [dbo].[TRI_OFFSITE_RECYCLED_Q] CHECK CONSTRAINT [FK_OFFSITERECYCLEDQ_REPORT]
GO
/****** Object:  ForeignKey [FK_OFFSITEENERGYRECQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEENERGYRECQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_ENERGY_REC_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_ENERGY_REC_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_OFFSITEENERGYRECQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEENERGYRECQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_ENERGY_REC_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_ENERGY_REC_QTY] CHECK CONSTRAINT [FK_OFFSITEENERGYRECQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_OFFSITEDISPQTY_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_DISP_QTY]  WITH NOCHECK ADD  CONSTRAINT [FK_OFFSITEDISPQTY_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OFFSITEDISPQTY_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_OFFSITE_DISP_QTY]'))
ALTER TABLE [dbo].[TRI_OFFSITE_DISP_QTY] CHECK CONSTRAINT [FK_OFFSITEDISPQTY_REPORT]
GO
/****** Object:  ForeignKey [FK_NPDESID_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NPDESID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_NPDES_ID]'))
ALTER TABLE [dbo].[TRI_NPDES_ID]  WITH CHECK ADD  CONSTRAINT [FK_NPDESID_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_NPDESID_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_NPDES_ID]'))
ALTER TABLE [dbo].[TRI_NPDES_ID] CHECK CONSTRAINT [FK_NPDESID_FAC]
GO
/****** Object:  ForeignKey [FK_FACSIC_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACSIC_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_SIC]'))
ALTER TABLE [dbo].[TRI_FAC_SIC]  WITH CHECK ADD  CONSTRAINT [FK_FACSIC_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACSIC_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_SIC]'))
ALTER TABLE [dbo].[TRI_FAC_SIC] CHECK CONSTRAINT [FK_FACSIC_FAC]
GO
/****** Object:  ForeignKey [FK_FACNAICS_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACNAICS_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_NAICS]'))
ALTER TABLE [dbo].[TRI_FAC_NAICS]  WITH CHECK ADD  CONSTRAINT [FK_FACNAICS_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACNAICS_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_NAICS]'))
ALTER TABLE [dbo].[TRI_FAC_NAICS] CHECK CONSTRAINT [FK_FACNAICS_FAC]
GO
/****** Object:  ForeignKey [FK_FACDUN_FAC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACDUN_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_DUN]'))
ALTER TABLE [dbo].[TRI_FAC_DUN]  WITH CHECK ADD  CONSTRAINT [FK_FACDUN_FAC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_FAC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FACDUN_FAC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_FAC_DUN]'))
ALTER TABLE [dbo].[TRI_FAC_DUN] CHECK CONSTRAINT [FK_FACDUN_FAC]
GO
/****** Object:  ForeignKey [FK_CHEM_REPORT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CHEM_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_CHEM]'))
ALTER TABLE [dbo].[TRI_CHEM]  WITH NOCHECK ADD  CONSTRAINT [FK_CHEM_REPORT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_REPORT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CHEM_REPORT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_CHEM]'))
ALTER TABLE [dbo].[TRI_CHEM] CHECK CONSTRAINT [FK_CHEM_REPORT]
GO
/****** Object:  ForeignKey [FK_TRANSFERQ_TRANSFERLOC]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRANSFERQ_TRANSFERLOC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_Q]'))
ALTER TABLE [dbo].[TRI_TRANSFER_Q]  WITH NOCHECK ADD  CONSTRAINT [FK_TRANSFERQ_TRANSFERLOC] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_TRANSFER_LOC] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TRANSFERQ_TRANSFERLOC]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_TRANSFER_Q]'))
ALTER TABLE [dbo].[TRI_TRANSFER_Q] CHECK CONSTRAINT [FK_TRANSFERQ_TRANSFERLOC]
GO
/****** Object:  ForeignKey [FK_SRCREDMETHCD_SRCREDACT]    Script Date: 12/02/2010 14:15:42 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SRCREDMETHCD_SRCREDACT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_METH_CD]'))
ALTER TABLE [dbo].[TRI_SRC_RED_METH_CD]  WITH CHECK ADD  CONSTRAINT [FK_SRCREDMETHCD_SRCREDACT] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_SRC_RED_ACT] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SRCREDMETHCD_SRCREDACT]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_SRC_RED_METH_CD]'))
ALTER TABLE [dbo].[TRI_SRC_RED_METH_CD] CHECK CONSTRAINT [FK_SRCREDMETHCD_SRCREDACT]
GO
/****** Object:  ForeignKey [FK_WASTETREATMETH_WTDTL]    Script Date: 12/02/2010 14:15:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WASTETREATMETH_WTDTL]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_METH]'))
ALTER TABLE [dbo].[TRI_WASTE_TREAT_METH]  WITH NOCHECK ADD  CONSTRAINT [FK_WASTETREATMETH_WTDTL] FOREIGN KEY([FK_GUID])
REFERENCES [dbo].[TRI_WASTE_TREAT_DTL] ([PK_GUID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WASTETREATMETH_WTDTL]') AND parent_object_id = OBJECT_ID(N'[dbo].[TRI_WASTE_TREAT_METH]'))
ALTER TABLE [dbo].[TRI_WASTE_TREAT_METH] CHECK CONSTRAINT [FK_WASTETREATMETH_WTDTL]
GO

/********************************************************
***             INSERT ARIZONA COUNTIES               ***
********************************************************/

INSERT INTO App_Lookup_Cty_Reg VALUES (1,'Apache','')
INSERT INTO App_Lookup_Cty_Reg VALUES (2,'Cochise','')
INSERT INTO App_Lookup_Cty_Reg VALUES (3,'Coconino','')
INSERT INTO App_Lookup_Cty_Reg VALUES (4,'Gila','')
INSERT INTO App_Lookup_Cty_Reg VALUES (5,'Graham','')
INSERT INTO App_Lookup_Cty_Reg VALUES (6,'Greenlee','')
INSERT INTO App_Lookup_Cty_Reg VALUES (7,'La Paz','')
INSERT INTO App_Lookup_Cty_Reg VALUES (8,'Maricopa','')
INSERT INTO App_Lookup_Cty_Reg VALUES (9,'Mohave','')
INSERT INTO App_Lookup_Cty_Reg VALUES (10,'Navajo','')
INSERT INTO App_Lookup_Cty_Reg VALUES (11,'Pima','')
INSERT INTO App_Lookup_Cty_Reg VALUES (12,'Pinal','')
INSERT INTO App_Lookup_Cty_Reg VALUES (13,'Santa Cruz','')
INSERT INTO App_Lookup_Cty_Reg VALUES (14,'Yavapai','')
INSERT INTO App_Lookup_Cty_Reg VALUES (15,'Yuma','')
