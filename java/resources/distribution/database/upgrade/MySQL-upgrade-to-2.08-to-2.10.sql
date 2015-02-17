alter table NService add PublishFlags varchar(50) null;
alter table NService add AuthRequired varchar(1) null;

alter table NFlow add TargetExchangeName varchar(255) null;

update NService set AuthRequired = 'Y';

INSERT
INTO
    NAccount 
    (
        Id ,
        NAASAccount ,
        IsActive ,
        SystemRole ,
        Affiliation ,
        ModifiedBy ,
        ModifiedOn
    )
VALUES
    (
        '00000000-0000-0000-0000-999999999999',
        'Anonymous',
        'Y',
        'Anonymous',
        (SELECT SystemRole from NAccount where Id = '00000000-0000-0000-0000-000000000000'),
        '00000000-0000-0000-0000-000000000000',
        current_timestamp
    )
;