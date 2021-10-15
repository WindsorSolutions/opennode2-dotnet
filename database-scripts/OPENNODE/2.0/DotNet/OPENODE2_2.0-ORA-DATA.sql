INSERT INTO NAccount
           (Id
           ,NAASAccount
           ,IsActive
           ,SystemRole
           ,ModifiedBy
           ,ModifiedOn
           ,IsDeleted
           ,IsDemoUser)
     VALUES
           ('0000-0000-0000-0000-0000'
           ,'admin@agency.gov'
           ,'Y'
           ,'Admin'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'N'
           ,'N');


INSERT INTO NAccount
           (Id
           ,NAASAccount
           ,IsActive
           ,SystemRole
           ,ModifiedBy
           ,ModifiedOn
           ,IsDeleted
           ,IsDemoUser)
     VALUES
           ('1111-1111-1111-1111-1111'
           ,'runtime@agency.gov'
           ,'Y'
           ,'Authed'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'N'
           ,'N');
           
INSERT INTO NFlow
           (Id
           ,InfoUrl
           ,Contact
           ,IsProtected
           ,ModifiedBy
           ,ModifiedOn
           ,Code
           ,Description)
     VALUES
           ('08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'http://www.exchangenetwork.net/exchanges/cross/nct.htm'
           ,'0000-0000-0000-0000-0000'
           ,'N'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'NCT'
           ,'NCT Description');

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('10121810-7829-42ac-8FDE-D0C28A282826'
           ,'Submit_v1.0'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Submit'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('C33BD829-AD64-4f59-821B-E9F66A198A20'
           ,'*'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Submit'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);
           
INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('45E5E261-1525-4efb-85EF-0BB30560CFB0'
           ,'Query_v1.0'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Query'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('8C2DB95B-22C4-4d1c-8219-AE2CB4CCD661'
           ,'Solicit_v1.0'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Solicit'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('B8145229-D9FE-437c-92AB-3FD3BDCCDA26'
           ,'Notify_v1.0'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Notify'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('412AB6BC-9FF3-4894-A260-4C862A59D2CB'
           ,'Execute_v1.0'
           ,'08221DEA-7545-4b4a-A55E-BEDDFDF8E51B'
           ,'Y'
           ,'Execute'
           ,'Windsor.Node2008.WNOSPlugin.NCT.NCTPlugin, Windsor.Node2008.WNOSPlugin.NCT.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NFlow
           (Id
           ,InfoUrl
           ,Contact
           ,IsProtected
           ,ModifiedBy
           ,ModifiedOn
           ,Code
           ,Description)
     VALUES
           ('6E1FD9A4-4C02-4208-9D3C-BE743BF720AF'
           ,'http://www.windsorsolutions.com'
           ,'0000-0000-0000-0000-0000'
           ,'Y'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'Windsor'
           ,'Windsor node-specific tasks');


INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('3E8D160F-D73D-4bad-AACB-A8ABFE815E63'
           ,'Clean temporary folder'
           ,'6E1FD9A4-4C02-4208-9D3C-BE743BF720AF'
           ,'Y'
           ,'Task'
           ,'Windsor.Node2008.WNOSPlugin.Windsor.CleanTemporaryFolder, Windsor.Node2008.WNOSPlugin.Windsor.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);


INSERT INTO NServiceArg
           (Id
           ,ServiceId
           ,ArgCode
           ,Value)
     VALUES
	   ('5C78FE55-CF5E-4738-B67D-19428840A9AB'
           ,'3E8D160F-D73D-4bad-AACB-A8ABFE815E63'
           ,'Delete files older than days'
           ,'7');

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('98307B49-952E-450b-BE55-512CEACA4B8E'
           ,'Refresh NAAS Users'
           ,'6E1FD9A4-4C02-4208-9D3C-BE743BF720AF'
           ,'Y'
           ,'Task'
           ,'Windsor.Node2008.WNOSPlugin.Windsor.RefreshNAASUsers, Windsor.Node2008.WNOSPlugin.Windsor.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NFlow
           (Id
           ,InfoUrl
           ,Contact
           ,IsProtected
           ,ModifiedBy
           ,ModifiedOn
           ,Code
           ,Description)
     VALUES
           ('FBCBCAFD-A98C-4d6a-94C9-5F2FAF728B4E'
           ,'http://www.windsorsolutions.com'
           ,'0000-0000-0000-0000-0000'
           ,'Y'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'Flow-Security'
           ,'Security node-specific tasks');

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('9F4FEC36-4F01-49f6-BF2E-212EDCB1C5D8'
           ,'Bulk Add Users'
           ,'FBCBCAFD-A98C-4d6a-94C9-5F2FAF728B4E'
           ,'Y'
           ,'Task'
           ,'Windsor.Node2008.WNOSPlugin.Security.BulkAddUsers, Windsor.Node2008.WNOSPlugin.Security.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NFlow
           (Id
           ,InfoUrl
           ,Contact
           ,IsProtected
           ,ModifiedBy
           ,ModifiedOn
           ,Code
           ,Description)
     VALUES
           ('25C2084B-1798-4e26-A2C2-DB90AF1CA42E'
           ,'http://www.exchangenetwork.net/node/ends.htm'
           ,'0000-0000-0000-0000-0000'
           ,'N'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'ENDS_v20'
           ,'Exchange Network Discovery Services (ENDS)');

INSERT INTO NService
           (Id
           ,Name
           ,FlowId
           ,IsActive
           ,ServiceType
           ,Implementor
           ,AuthLevel
           ,ModifiedBy
           ,ModifiedOn)
     VALUES
           ('86AFE535-B0CD-4361-B8A0-5E8E23DB6F6B'
           ,'GetServices'
           ,'25C2084B-1798-4e26-A2C2-DB90AF1CA42E'
           ,'Y'
           ,'Query'
           ,'Windsor.Node2008.WNOSPlugin.ENDS_2.GetServices, Windsor.Node2008.WNOSPlugin.ENDS_2.dll'
           ,'Basic'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE);

INSERT INTO NSchedule
           (Id
           ,Name
           ,FlowId
           ,StartOn
           ,EndOn
           ,SourceType
           ,SourceId
           ,SourceFlow
           ,SourceOperation
           ,TargetType
           ,TargetId
           ,TargetFlow
           ,TargetOperation
           ,LastExecutedOn
           ,NextRun
           ,FrequencyType
           ,Frequency
           ,ModifiedBy
           ,ModifiedOn
           ,IsActive
           ,IsRunNow
           ,ExecuteStatus)
     VALUES
           ('BDAE9CC8-FB11-4230-BA33-4DF46FFEC286'
           ,'Clean temporary folder'
           ,'6E1FD9A4-4C02-4208-9D3C-BE743BF720AF'
           ,SYSDATE
           ,SYSDATE + numtoyminterval(10, 'YEAR')
           ,'LocalService'
           ,'3E8D160F-D73D-4bad-AACB-A8ABFE815E63'
           ,''
           ,''
           ,'None'
           ,''
           ,''
           ,''
           ,NULL
           ,SYSDATE
           ,'Day'
           ,'1'
           ,'0000-0000-0000-0000-0000'
           ,SYSDATE
           ,'Y'
           ,'N'
           ,'None');


     
--Add EPA Endpoints to NParnter
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_18195f91-7841-43ba-9ea4-b6d4ff3c32c2','EPA v1.1 (Prod)','https://cdxnode.epa.gov/cdx/services/NetworkNodePortType_V10','0000-0000-0000-0000-0000', SYSDATE, 'EN11');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_20eab800-9a68-4cb5-885b-7355424d277b','EPA NGN v1.1 (Prod)','https://cdxnodengn.epa.gov/cdx-enws10/services/NetworkNodePortType_V10','0000-0000-0000-0000-0000', SYSDATE, 'EN11');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_34554579-cb76-44ce-8302-c1c834c4b63c','EPA v2.0 (Test)','https://test.epacdxnode.net/cdx-enws20/services/NetworkNode2','0000-0000-0000-0000-0000', SYSDATE, 'EN20');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_397b7cff-cf13-48a5-8e7b-cf3bec89dd81','EPA NGN v1.1 (Test)','https://testngn.epacdxnode.net/cdx-enws10/services/NetworkNodePortType_V10','0000-0000-0000-0000-0000', SYSDATE, 'EN11');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_6cbbaa52-2b78-4a26-9c03-c1098afc5ffd','EPA v1.1 (Test)','https://test.epacdxnode.net/cdx/services/NetworkNodePortType_V10','0000-0000-0000-0000-0000', SYSDATE, 'EN11');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_778e3dc9-1259-4c86-b41d-086aaa01bb9d','EPA .NET Node v2.0 (Prod)','https://node2.epa.gov/Node2WS.svc','0000-0000-0000-0000-0000', SYSDATE, 'EN20');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_b8c859d1-0c62-48ff-8c49-9fe25cdf4333','EPA NGN v2.0 (Prod)','https://cdxnodengn.epa.gov/ngn-enws20/services/NetworkNode2Service','0000-0000-0000-0000-0000', SYSDATE, 'EN20');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_e6aa4fb4-97f3-46f8-b0b6-8dfcd79dff9e','EPA v2.0 (Prod)','https://cdxnode.epa.gov/cdx-enws20/services/NetworkNode2','0000-0000-0000-0000-0000', SYSDATE, 'EN20');
INSERT INTO NPartner (Id,Name,Url,ModifiedBy,ModifiedOn,Version) VALUES ('_ef1a8c6b-1738-41e6-b534-1356d4361829','EPA NGN v2.0 (Test)','https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2Service','0000-0000-0000-0000-0000', SYSDATE, 'EN20');
     
commit;

