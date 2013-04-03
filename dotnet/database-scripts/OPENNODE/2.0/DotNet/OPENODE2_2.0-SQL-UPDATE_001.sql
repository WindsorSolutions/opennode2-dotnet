ALTER TABLE NAccount
    ALTER COLUMN PasswordHash VARCHAR(500) NULL
GO
ALTER TABLE NAccount
    ADD IsEndpointUser CHAR(1) NULL
GO
ALTER TABLE NTransaction
    ADD NetworkEndpointUser VARCHAR(50) NULL
GO
ALTER TABLE NTransaction WITH CHECK ADD
	CONSTRAINT FK_NetworkEndpointUser_Transaction_Account FOREIGN KEY (NetworkEndpointUser) 
	REFERENCES NAccount (Id)
GO
ALTER TABLE NSchedule
    ADD SourceEndpointUser VARCHAR(50) NULL
GO
ALTER TABLE NSchedule WITH CHECK ADD
	CONSTRAINT FK_SourceEndpointUser_Schedule_Account FOREIGN KEY (SourceEndpointUser) 
	REFERENCES NAccount (Id)
GO
ALTER TABLE NSchedule
    ADD TargetEndpointUser VARCHAR(50) NULL
GO
ALTER TABLE NSchedule WITH CHECK ADD
	CONSTRAINT FK_TargetEndpointUser_Schedule_Account FOREIGN KEY (TargetEndpointUser) 
	REFERENCES NAccount (Id)
GO
