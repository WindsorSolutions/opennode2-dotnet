INSERT
INTO
	NAccount 
	(
		Id ,
		NAASAccount ,
		IsActive ,
		SystemRole ,
		Affiliation,
		ModifiedBy ,
		ModifiedOn
	)
VALUES
	(
		'00000000-0000-0000-0000-000000000000',
        'node@myagency.gov',
        'Y',
        'Admin',
        'MY_AGENCY',
		'00000000-0000-0000-0000-000000000000',
		sysdate
	)
;
INSERT
INTO
    NAccount 
    (
        Id ,
        NAASAccount ,
        IsActive ,
        SystemRole ,
        Affiliation,
        ModifiedBy ,
        ModifiedOn
    )
VALUES
    (
        '00000000-0000-0000-0000-000000000001',
        'Anonymous',
        'Y',
        'Anonymous',
        'MY_AGENCY',
        '00000000-0000-0000-0000-000000000000',
        sysdate
    )
;
COMMIT
;
