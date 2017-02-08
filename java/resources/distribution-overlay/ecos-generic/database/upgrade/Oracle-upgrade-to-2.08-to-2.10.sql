alter table NService add (AuthRequired varchar2(1) null);
alter table NFlow add (TargetExchangeName varchar2(255) null);

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
        sysdate
    )
;