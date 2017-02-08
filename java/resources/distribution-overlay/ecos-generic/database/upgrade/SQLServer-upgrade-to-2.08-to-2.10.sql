alter table NService add AuthRequired varchar(1) null;
alter table NFlow add TargetExchangeName varchar(255) null;

update NService set AuthRequired = 'Y';

insert into NAccount
(
    Id ,
    NAASAccount ,
    IsActive ,
    SystemRole ,
    Affiliation ,
    ModifiedBy ,
    ModifiedOn
)
values('0000-0000-0000-0000-9999', 
    'Anonymous',
    'Y',
    'Anonymous',
    (SELECT SystemRole from NAccount where Id = '0000-0000-0000-0000-0000'),
    '0000-0000-0000-0000-0000',
    getdate());