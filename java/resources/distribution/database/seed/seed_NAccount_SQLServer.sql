-- prime the db with accounts so unit tests can run
-- the first id is hard-wired into the tests
-- the first name is the name set in WNOS_Service...naas.properties 

insert into NAccount
(
    Id ,
    NAASAccount ,
    IsActive ,
    SystemRole ,
    Affiliation,
    ModifiedBy ,
    ModifiedOn
)
values('0000-0000-0000-0000-0000', 
    'node@myagency.gov',
    'Y',
    'Admin',
    'MY_AGENCY',
    '0000-0000-0000-0000-0000',
    getdate());