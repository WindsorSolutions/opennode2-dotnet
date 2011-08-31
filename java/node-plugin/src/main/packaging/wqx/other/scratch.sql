select * from WQX_ORGANIZATION
select * from WQX_ELECTRONICADDRESS
select * from WQX_TELEPHONIC
select * from WQX_ORGADDRESS
select * from WQX_PROJECT
select * from WQX_PROJATTACHEDBINARYOBJECT -- empty
select * from WQX_PROJECTMONLOC -- empty
select * from WQX_MONITORINGLOCATION where parentid='1'
select * from WQX_ALTMONLOC -- empty
select * from WQX_MONLOCATTACHEDBINARYOBJECT -- empty
select * from WQX_BIOLOGICALHABITATINDEX -- empty
select * from WQX_ACTIVITY
select * from WQX_ACTIVITYGROUP
select * from WQX_PROJECTACTIVITY
select * from WQX_ACTIVITYCONDUCTINGORG
select * from WQX_ACTIVITYMETRIC
select * from WQX_ACTATTACHEDBINARYOBJECT
select * from WQX_RESULT
select * from WQX_RESULTATTACHEDBINARYOBJECT
select * from WQX_RESULTDETECTQUANTLIMIT
select * from WQX_LABSAMPLEPREP

select * from WQX_SUBMISSIONHISTORY where LOCALTRANSACTIONID = '_8892A377-F39F-4FE3-BA54-869243A52D0D'

select * from WQX_SUBMISSIONHISTORY where ((CDXPROCESSINGSTATUS = 'Pending') or  (CDXPROCESSINGSTATUS = 'Processing'))

update WQX_SUBMISSIONHISTORY  set CDXPROCESSINGSTATUS = 'Pending' where LOCALTRANSACTIONID = '_AE14C429-7B15-4316-AA1F-13F506FB65FF'

select * from WQX_ACTIVITYGROUP

select * from WQX_SUBMISSIONHISTORY

delete from WQX_SUBMISSIONHISTORY

select MAX(WQXUPDATEDATE) from WQX_SUBMISSIONHISTORY where CDXPROCESSINGSTATUS = 'Pending' 


SELECT projectid FROM WQX_PROJECT WHERE WQX_PROJECT.RECORDID IN (SELECT projectparentid FROM WQX_PROJECTACTIVITY WHERE WQX_PROJECTACTIVITY.ACTIVITYPARENTID = ?)

SELECT activityconductingorg FROM WQX_ACTIVITYCONDUCTINGORG WHERE PARENTID = ? AND ACTIVITYID = ?

SELECT * FROM WQX_BIOLOGICALHABITATINDEX WHERE PARENTID = '1' AND WQXUPDATEDATE >= '1900-01-01 01:00:0'

update WQX_SUBMISSIONHISTORY set CDXPROCESSINGSTATUS = 'Pending' where CDXPROCESSINGSTATUS = 'Received' 

insert into WQX_ORGANIZATION (RECORDID, ORGID, ORGFORMALNAME) values('_656600CD-1458-46B4-B603-B3D8C0E3441E', 'my bogus org', 'Windsor Solutions, Inc.')
delete from WQX_ORGANIZATION where RECORDID='_81D5C4EF-4910-4A1D-A357-EF121E60F10A'

delete from WQX_ORGANIZATION where ORGID = 'my bogus org'

SELECT * FROM WQX_PROJECT WHERE PARENTID = '1' AND WQXUPDATEDATE >= '1899-01-01 01:00:00'

select * from WQX_MONITORINGLOCATION where parentid='1' AND WQXUPDATEDATE >= '1899-01-01 01:00:00'

select * from WQX_ACTIVITY where parentid='1' AND WQXUPDATEDATE >= '1899-01-01 01:00:00'

select * from WQX_ACTIVITYGROUP where parentid='1' AND WQXUPDATEDATE >= '1899-01-01 01:00:00'
