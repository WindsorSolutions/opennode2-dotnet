USE opennode2;

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Table `naccount`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `naccount` (
  `Id` VARCHAR(50) NOT NULL ,
  `NAASAccount` VARCHAR(500) NOT NULL ,
  `IsActive` CHAR(1) NOT NULL ,
  `SystemRole` VARCHAR(50) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `IsDeleted` CHAR(1) NULL DEFAULT NULL ,
  `IsDemoUser` CHAR(1) NULL DEFAULT NULL ,
  `PasswordHash` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Account_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Account_NAASAccount` ON `naccount` (`NAASAccount`(255) ASC) ;

CREATE INDEX `IDX_NAccount_NAASAccount` ON `naccount` (`NAASAccount`(255) ASC) ;

CREATE INDEX `IDX_NAccount_IsActive` ON `naccount` (`IsActive` ASC) ;

CREATE INDEX `IDX_NAccount_SystemRole` ON `naccount` (`SystemRole` ASC) ;

CREATE INDEX `IDX_NAccount_ModifiedBy` ON `naccount` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NAccount_ModifiedOn` ON `naccount` (`ModifiedOn` ASC) ;


-- -----------------------------------------------------
-- Table `nflow`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nflow` (
  `Id` VARCHAR(50) NOT NULL ,
  `InfoUrl` VARCHAR(500) NULL DEFAULT NULL ,
  `Contact` VARCHAR(255) NOT NULL ,
  `IsProtected` CHAR(1) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `Code` VARCHAR(255) NOT NULL ,
  `Description` VARCHAR(500) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Flow_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Flow_Code` ON `nflow` (`Code` ASC) ;

CREATE INDEX `IDX_NFlow_IsProtected` ON `nflow` (`IsProtected` ASC) ;

CREATE INDEX `IDX_NFlow_ModifiedBy` ON `nflow` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NFlow_ModifiedOn` ON `nflow` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NFlow_Code` ON `nflow` (`Code` ASC) ;


-- -----------------------------------------------------
-- Table `ntransaction`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ntransaction` (
  `Id` VARCHAR(50) NOT NULL ,
  `FlowId` VARCHAR(50) NOT NULL ,
  `NetworkId` VARCHAR(255) NOT NULL ,
  `Status` VARCHAR(50) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `StatusDetail` VARCHAR(4000) NULL DEFAULT NULL ,
  `Operation` VARCHAR(255) NULL DEFAULT NULL ,
  `WebMethod` VARCHAR(50) NOT NULL ,
  `EndpointVersion` VARCHAR(50) NULL DEFAULT NULL ,
  `NetworkEndpointVersion` VARCHAR(50) NULL DEFAULT NULL ,
  `NetworkEndpointUrl` VARCHAR(500) NULL DEFAULT NULL ,
  `NetworkEndpointStatus` VARCHAR(50) NULL DEFAULT NULL ,
  `NetworkEndpointStatusDetail` VARCHAR(4000) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ModifiedBy_Transaction_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Transaction_Flow`
    FOREIGN KEY (`FlowId` )
    REFERENCES `nflow` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NTransaction_FlowId` ON `ntransaction` (`FlowId` ASC) ;

CREATE INDEX `IDX_NTransaction_NetworkId` ON `ntransaction` (`NetworkId` ASC) ;

CREATE INDEX `IDX_NTransaction_Status` ON `ntransaction` (`Status` ASC) ;

CREATE INDEX `IDX_NTransaction_ModifiedBy` ON `ntransaction` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NTransaction_ModifiedOn` ON `ntransaction` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NTransaction_Operation` ON `ntransaction` (`Operation` ASC) ;

CREATE INDEX `IDX_NTransaction_WebMethod` ON `ntransaction` (`WebMethod` ASC) ;

CREATE INDEX `IDX_NTransaction_EndpointVersion` ON `ntransaction` (`EndpointVersion` ASC) ;

CREATE INDEX `IDX_NTransaction_NetworkEndpointVersion` ON `ntransaction` (`NetworkEndpointVersion` ASC) ;

CREATE INDEX `IDX_NTransaction_NetworkEndpointUrl` ON `ntransaction` (`NetworkEndpointUrl`(255) ASC) ;

CREATE INDEX `IDX_NTransaction_NetworkEndpointStatus` ON `ntransaction` (`NetworkEndpointStatus` ASC) ;

CREATE INDEX `IDX_NTransaction_NetworkEndpointStatusDetail` ON `ntransaction` (`NetworkEndpointStatusDetail`(255) ASC) ;


-- -----------------------------------------------------
-- Table `naccountauthrequest`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `naccountauthrequest` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `RequestGeneratedOn` DATETIME NOT NULL ,
  `RequestType` VARCHAR(255) NOT NULL ,
  `NAASAccount` VARCHAR(500) NOT NULL ,
  `FullName` VARCHAR(500) NOT NULL ,
  `OrganizationAffiliation` VARCHAR(500) NOT NULL ,
  `TelephoneNumber` VARCHAR(25) NOT NULL ,
  `EmailAddress` VARCHAR(500) NOT NULL ,
  `AffiliatedNodeId` VARCHAR(50) NOT NULL ,
  `AffiliatedCounty` VARCHAR(255) NULL DEFAULT NULL ,
  `PurposeDescription` VARCHAR(4000) NULL DEFAULT NULL ,
  `RequestedNodeIds` VARCHAR(1000) NOT NULL ,
  `AuthorizationAccountId` VARCHAR(50) NULL DEFAULT NULL ,
  `AuthorizationComments` VARCHAR(4000) NULL DEFAULT NULL ,
  `AuthorizationGeneratedOn` DATETIME NULL DEFAULT NULL ,
  `DidCreateInNaas` VARCHAR(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_AccountAuthenticationRequest_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_AccountAuthRequest_Account`
    FOREIGN KEY (`AuthorizationAccountId` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NAccountAuthRequest_TransactionId` ON `naccountauthrequest` (`TransactionId` ASC) ;

CREATE INDEX `IDX_NAccountAuthRequest_AuthorizationAccountId` ON `naccountauthrequest` (`AuthorizationAccountId` ASC) ;


-- -----------------------------------------------------
-- Table `naccountauthrequestflow`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `naccountauthrequestflow` (
  `Id` VARCHAR(50) NOT NULL ,
  `AccountAuthRequestId` VARCHAR(50) NOT NULL ,
  `FlowName` VARCHAR(255) NOT NULL ,
  `AccessGranted` VARCHAR(1) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_AccountAuthRequestFlow_AccountAuthRequest`
    FOREIGN KEY (`AccountAuthRequestId` )
    REFERENCES `naccountauthrequest` (`Id` )
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NAccountAuthRequestFlow_AccountAuthRequestId` ON `naccountauthrequestflow` (`AccountAuthRequestId` ASC) ;


-- -----------------------------------------------------
-- Table `naccountpolicy`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `naccountpolicy` (
  `Id` VARCHAR(50) NOT NULL ,
  `AccountId` VARCHAR(50) NOT NULL ,
  `Type` VARCHAR(50) NOT NULL ,
  `Qualifier` VARCHAR(500) NOT NULL ,
  `IsAllowed` CHAR(1) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_AccountIdPolicy_Account`
    FOREIGN KEY (`AccountId` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_AccountPolicy_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NAccountPolicy_AccountId` ON `naccountpolicy` (`AccountId` ASC) ;

CREATE INDEX `IDX_NAccountPolicy_ModifiedBy` ON `naccountpolicy` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nactivity`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nactivity` (
  `Id` VARCHAR(50) NOT NULL ,
  `Type` VARCHAR(128) NOT NULL ,
  `TransactionId` VARCHAR(50) NULL DEFAULT NULL ,
  `IP` VARCHAR(64) NULL DEFAULT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `WebMethod` VARCHAR(50) NULL DEFAULT NULL ,
  `FlowName` VARCHAR(255) NULL DEFAULT NULL ,
  `Operation` VARCHAR(255) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Activity_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_Activity_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NActivity_Type` ON `nactivity` (`Type` ASC) ;

CREATE INDEX `IDX_NActivity_TransactionId` ON `nactivity` (`TransactionId` ASC) ;

CREATE INDEX `IDX_NActivity_IP` ON `nactivity` (`IP` ASC) ;

CREATE INDEX `IDX_NActivity_ModifiedBy` ON `nactivity` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NActivity_ModifiedOn` ON `nactivity` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NActivity_WebMethod` ON `nactivity` (`WebMethod` ASC) ;

CREATE INDEX `IDX_NActivity_FlowName` ON `nactivity` (`FlowName` ASC) ;

CREATE INDEX `IDX_NActivity_Operation` ON `nactivity` (`Operation` ASC) ;

CREATE INDEX `IDX_NActivityDetail_ModifiedOn` ON `nactivity` (`ModifiedOn` ASC) ;


-- -----------------------------------------------------
-- Table `nactivitydetail`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nactivitydetail` (
  `Id` VARCHAR(50) NOT NULL ,
  `ActivityId` VARCHAR(50) NOT NULL ,
  `Detail` VARCHAR(8000) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `OrderIndex` INT(11) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ActivityDetail_Activity`
    FOREIGN KEY (`ActivityId` )
    REFERENCES `nactivity` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NActivityDetail_ActivityId` ON `nactivitydetail` (`ActivityId` ASC) ;

CREATE INDEX `IDX_NActivityDetail_ModifiedOn` ON `nactivitydetail` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NActivityDetail_OrderIndex` ON `nactivitydetail` (`OrderIndex` ASC) ;


-- -----------------------------------------------------
-- Table `nconfig`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nconfig` (
  `Id` VARCHAR(255) NOT NULL ,
  `Value` VARCHAR(4000) NOT NULL ,
  `Description` VARCHAR(500) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `IsEditable` CHAR(1) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Config_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NConfig_ModifiedBy` ON `nconfig` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nconnection`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nconnection` (
  `Id` VARCHAR(50) NOT NULL ,
  `Code` VARCHAR(255) NOT NULL ,
  `Provider` VARCHAR(500) NOT NULL ,
  `ConnectionString` VARCHAR(500) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Connection_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Connection_Code` ON `nconnection` (`Code` ASC) ;

CREATE INDEX `IDX_NConnection_ModifiedBy` ON `nconnection` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `ndocument`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ndocument` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `DocumentName` VARCHAR(255) NOT NULL ,
  `Type` VARCHAR(255) NOT NULL ,
  `DocumentId` VARCHAR(255) NOT NULL ,
  `Status` VARCHAR(50) NOT NULL ,
  `StatusDetail` VARCHAR(4000) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Document_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Document_TransactionIdDocumentName` ON `ndocument` (`TransactionId` ASC, `DocumentName` ASC) ;

CREATE INDEX `IDX_NDocument_TransactionId` ON `ndocument` (`TransactionId` ASC) ;

CREATE INDEX `IDX_NDocument_DocumentName` ON `ndocument` (`DocumentName` ASC) ;

CREATE INDEX `IDX_NDocument_Type` ON `ndocument` (`Type` ASC) ;

CREATE INDEX `IDX_NDocument_DocumentId` ON `ndocument` (`DocumentId` ASC) ;

CREATE INDEX `IDX_NDocument_Status` ON `ndocument` (`Status` ASC) ;


-- -----------------------------------------------------
-- Table `ndocumentcontent`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ndocumentcontent` (
  `DocumentId` VARCHAR(50) NOT NULL ,
  `Data` LONGBLOB NOT NULL ,
  PRIMARY KEY (`DocumentId`) ,
  CONSTRAINT `FK_DocumentContent_Document`
    FOREIGN KEY (`DocumentId` )
    REFERENCES `ndocument` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `nnodenotification`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nnodenotification` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `NotifyData` VARCHAR(8000) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_NodeNotification_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NodeNotification_Transaction` ON `nnodenotification` (`TransactionId` ASC) ;


-- -----------------------------------------------------
-- Table `nnotification`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nnotification` (
  `Id` VARCHAR(50) NOT NULL ,
  `FlowId` VARCHAR(50) NOT NULL ,
  `AccountId` VARCHAR(50) NOT NULL ,
  `OnSolicit` CHAR(1) NOT NULL ,
  `OnQuery` CHAR(1) NOT NULL ,
  `OnSubmit` CHAR(1) NOT NULL ,
  `OnNotify` CHAR(1) NOT NULL ,
  `OnSchedule` CHAR(1) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `OnDownload` CHAR(1) NOT NULL ,
  `OnExecute` CHAR(1) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ModifiedBy_Notification_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Notification_Account`
    FOREIGN KEY (`AccountId` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Notification_Flow`
    FOREIGN KEY (`FlowId` )
    REFERENCES `nflow` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Notification_FlowIdAccountId` ON `nnotification` (`FlowId` ASC, `AccountId` ASC) ;

CREATE INDEX `IDX_NNotification_FlowId` ON `nnotification` (`FlowId` ASC) ;

CREATE INDEX `IDX_NNotification_AccountId` ON `nnotification` (`AccountId` ASC) ;

CREATE INDEX `IDX_NNotification_ModifiedBy` ON `nnotification` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nobjectcache`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nobjectcache` (
  `Name` VARCHAR(255) NOT NULL ,
  `Data` LONGBLOB NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `Expiration` DATETIME NOT NULL ,
  PRIMARY KEY (`Name`) )
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NObjectCache_ModifiedOn` ON `nobjectcache` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NObjectCache_Expiration` ON `nobjectcache` (`Expiration` ASC) ;

CREATE INDEX `IDX_NPartner_Name` ON `nobjectcache` (`Name` ASC) ;


-- -----------------------------------------------------
-- Table `npartner`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `npartner` (
  `Id` VARCHAR(50) NOT NULL ,
  `Name` VARCHAR(50) NOT NULL ,
  `Url` VARCHAR(500) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `Version` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Partner_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Partner_Name` ON `npartner` (`Name` ASC) ;

CREATE UNIQUE INDEX `IX_NPartner` ON `npartner` (`Name` ASC) ;

CREATE INDEX `IDX_NPartner_Name` ON `npartner` (`Name` ASC) ;

CREATE INDEX `IDX_NPartner_ModifiedBy` ON `npartner` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nplugin`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nplugin` (
  `Id` VARCHAR(50) NOT NULL ,
  `FlowId` VARCHAR(50) NOT NULL ,
  `BinaryVersion` VARCHAR(40) NOT NULL ,
  `ZippedBinary` LONGBLOB NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Plugin_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Plugin_Flow`
    FOREIGN KEY (`FlowId` )
    REFERENCES `nflow` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Plugin_BinaryVersionFlowId` ON `nplugin` (`BinaryVersion` ASC, `FlowId` ASC) ;

CREATE INDEX `IDX_NPlugin_FlowId` ON `nplugin` (`FlowId` ASC) ;

CREATE INDEX `IDX_NPlugin_ModifiedBy` ON `nplugin` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nservice`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nservice` (
  `Id` VARCHAR(50) NOT NULL ,
  `Name` VARCHAR(255) NOT NULL ,
  `FlowId` VARCHAR(50) NOT NULL ,
  `IsActive` CHAR(1) NOT NULL ,
  `ServiceType` VARCHAR(128) NOT NULL ,
  `Implementor` VARCHAR(500) NOT NULL ,
  `AuthLevel` VARCHAR(50) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `PublishFlags` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Service_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Service_Flow`
    FOREIGN KEY (`FlowId` )
    REFERENCES `nflow` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NService_ScheduleId` ON `nservice` (`Name` ASC) ;

CREATE INDEX `IDX_NService_FlowId` ON `nservice` (`FlowId` ASC) ;

CREATE INDEX `IDX_NService_IsActive` ON `nservice` (`IsActive` ASC) ;

CREATE INDEX `IDX_NService_ServiceType` ON `nservice` (`ServiceType` ASC) ;

CREATE INDEX `IDX_NService_AuthLevel` ON `nservice` (`AuthLevel` ASC) ;

CREATE INDEX `IDX_NService_ModifiedBy` ON `nservice` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NService_PublishFlags` ON `nservice` (`PublishFlags` ASC) ;


-- -----------------------------------------------------
-- Table `nrequest`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nrequest` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NULL DEFAULT NULL ,
  `ServiceId` VARCHAR(50) NOT NULL ,
  `RowIndex` INT(11) NOT NULL ,
  `MaxRowCount` INT(11) NOT NULL ,
  `RequestType` VARCHAR(50) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `ParamsByName` CHAR(1) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ModifiedBy_Request_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Request_Service`
    FOREIGN KEY (`ServiceId` )
    REFERENCES `nservice` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_Request_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NRequest_TransactionId` ON `nrequest` (`TransactionId` ASC) ;

CREATE INDEX `IDX_NRequest_ServiceId` ON `nrequest` (`ServiceId` ASC) ;

CREATE INDEX `IDX_NRequest_RequestType` ON `nrequest` (`RequestType` ASC) ;

CREATE INDEX `IDX_NRequest_ModifiedBy` ON `nrequest` (`ModifiedBy` ASC) ;


-- -----------------------------------------------------
-- Table `nrequestarg`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nrequestarg` (
  `Id` VARCHAR(50) NOT NULL ,
  `RequestId` VARCHAR(50) NOT NULL ,
  `ArgName` VARCHAR(255) NOT NULL ,
  `ArgValue` VARCHAR(4000) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_RequestArg_Request`
    FOREIGN KEY (`RequestId` )
    REFERENCES `nrequest` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NRequestArg_RequestId` ON `nrequestarg` (`RequestId` ASC) ;


-- -----------------------------------------------------
-- Table `nschedule`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nschedule` (
  `Id` VARCHAR(50) NOT NULL ,
  `Name` VARCHAR(255) NOT NULL ,
  `FlowId` VARCHAR(50) NULL DEFAULT NULL ,
  `StartOn` DATETIME NOT NULL ,
  `EndOn` DATETIME NOT NULL ,
  `SourceType` VARCHAR(50) NOT NULL ,
  `SourceId` VARCHAR(255) NOT NULL ,
  `SourceFlow` VARCHAR(255) NULL DEFAULT NULL ,
  `SourceOperation` VARCHAR(255) NULL DEFAULT NULL ,
  `TargetType` VARCHAR(50) NULL DEFAULT NULL ,
  `TargetId` VARCHAR(255) NULL DEFAULT NULL ,
  `TargetFlow` VARCHAR(255) NULL DEFAULT NULL ,
  `TargetOperation` VARCHAR(255) NULL DEFAULT NULL ,
  `LastExecutedOn` DATETIME NULL DEFAULT NULL ,
  `NextRun` DATETIME NOT NULL ,
  `FrequencyType` VARCHAR(50) NOT NULL ,
  `Frequency` INT(11) NOT NULL ,
  `ModifiedBy` VARCHAR(50) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `IsActive` VARCHAR(1) NOT NULL ,
  `IsRunNow` VARCHAR(1) NOT NULL ,
  `ExecuteStatus` VARCHAR(50) NOT NULL ,
  `LastExecuteActivityId` VARCHAR(50) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_Schedule_Account`
    FOREIGN KEY (`ModifiedBy` )
    REFERENCES `naccount` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_Schedule_Activity`
    FOREIGN KEY (`LastExecuteActivityId` )
    REFERENCES `nactivity` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Schedule_Flow`
    FOREIGN KEY (`FlowId` )
    REFERENCES `nflow` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Schedule_Name` ON `nschedule` (`Name` ASC) ;

CREATE INDEX `IDX_NSchedule_Name` ON `nschedule` (`Name` ASC) ;

CREATE INDEX `IDX_NSchedule_FlowId` ON `nschedule` (`FlowId` ASC) ;

CREATE INDEX `IDX_NSchedule_StartOn` ON `nschedule` (`StartOn` ASC) ;

CREATE INDEX `IDX_NSchedule_EndOn` ON `nschedule` (`EndOn` ASC) ;

CREATE INDEX `IDX_NSchedule_LastExecutedOn` ON `nschedule` (`LastExecutedOn` ASC) ;

CREATE INDEX `IDX_NSchedule_NextRun` ON `nschedule` (`NextRun` ASC) ;

CREATE INDEX `IDX_NSchedule_FrequencyType` ON `nschedule` (`FrequencyType` ASC) ;

CREATE INDEX `IDX_NSchedule_Frequency` ON `nschedule` (`Frequency` ASC) ;

CREATE INDEX `IDX_NSchedule_ModifiedBy` ON `nschedule` (`ModifiedBy` ASC) ;

CREATE INDEX `IDX_NSchedule_ModifiedOn` ON `nschedule` (`ModifiedOn` ASC) ;

CREATE INDEX `IDX_NSchedule_IsActive` ON `nschedule` (`IsActive` ASC) ;

CREATE INDEX `IDX_NSchedule_IsRunNow` ON `nschedule` (`IsRunNow` ASC) ;

CREATE INDEX `IDX_NSchedule_LastExecuteActivityId` ON `nschedule` (`LastExecuteActivityId` ASC) ;


-- -----------------------------------------------------
-- Table `nschedulesourcearg`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nschedulesourcearg` (
  `Id` VARCHAR(50) NOT NULL ,
  `ScheduleId` VARCHAR(50) NOT NULL ,
  `Name` VARCHAR(255) NOT NULL ,
  `Value` VARCHAR(8000) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ScheduleSourceArg_Schedule`
    FOREIGN KEY (`ScheduleId` )
    REFERENCES `nschedule` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_ScheduleSourceArg_ScheduleIdName` ON `nschedulesourcearg` (`ScheduleId` ASC, `Name` ASC) ;

CREATE INDEX `IDX_NScheduleSourceArg_ScheduleId` ON `nschedulesourcearg` (`ScheduleId` ASC) ;

CREATE INDEX `IDX_NScheduleSourceArg_Name` ON `nschedulesourcearg` (`Name` ASC) ;


-- -----------------------------------------------------
-- Table `nservicearg`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nservicearg` (
  `Id` VARCHAR(50) NOT NULL ,
  `ServiceId` VARCHAR(50) NOT NULL ,
  `ArgCode` VARCHAR(255) NOT NULL ,
  `Value` VARCHAR(4000) NULL DEFAULT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ServiceArg_Service`
    FOREIGN KEY (`ServiceId` )
    REFERENCES `nservice` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_NServiceArg_ServiceId` ON `nservicearg` (`ServiceId` ASC) ;


-- -----------------------------------------------------
-- Table `nserviceconn`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `nserviceconn` (
  `Id` VARCHAR(50) NOT NULL ,
  `ServiceId` VARCHAR(50) NOT NULL ,
  `ConnectionId` VARCHAR(50) NOT NULL ,
  `KeyName` VARCHAR(255) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_ServiceConn_Connection`
    FOREIGN KEY (`ConnectionId` )
    REFERENCES `nconnection` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `FK_ServiceConn_Service`
    FOREIGN KEY (`ServiceId` )
    REFERENCES `nservice` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE UNIQUE INDEX `UNQ_Service_ServiceIdKeyName` ON `nserviceconn` (`ServiceId` ASC, `KeyName` ASC) ;

CREATE INDEX `IDX_NServiceConn_ServiceId` ON `nserviceconn` (`ServiceId` ASC) ;

CREATE INDEX `IDX_NServiceConn_ConnectionId` ON `nserviceconn` (`ConnectionId` ASC) ;

CREATE INDEX `IDX_NServiceConn_KeyName` ON `nserviceconn` (`KeyName` ASC) ;


-- -----------------------------------------------------
-- Table `ntransactionnotification`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ntransactionnotification` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `Uri` VARCHAR(500) NOT NULL ,
  `Type` VARCHAR(50) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_TransactionNotification_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_TransactionNotification_Transaction` ON `ntransactionnotification` (`TransactionId` ASC) ;


-- -----------------------------------------------------
-- Table `ntransactionrealtimedetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ntransactionrealtimedetails` (
  `Id` VARCHAR(50) NOT NULL ,
  `StatusType` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `Detail` VARCHAR(4000) NOT NULL ,
  `ModifiedOn` DATETIME NOT NULL ,
  `OrderIndex` INT(11) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_TransactionRealtimeActivityDetail_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_TransactionRealtimeActivityDetail_Transaction` ON `ntransactionrealtimedetails` (`TransactionId` ASC) ;


-- -----------------------------------------------------
-- Table `ntransactionrecipient`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ntransactionrecipient` (
  `Id` VARCHAR(50) NOT NULL ,
  `TransactionId` VARCHAR(50) NOT NULL ,
  `Uri` VARCHAR(500) NOT NULL ,
  PRIMARY KEY (`Id`) ,
  CONSTRAINT `FK_TransactionRecipient_Transaction`
    FOREIGN KEY (`TransactionId` )
    REFERENCES `ntransaction` (`Id` )
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE INDEX `IDX_TransactionRecipient_Transaction` ON `ntransactionrecipient` (`TransactionId` ASC) ;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
