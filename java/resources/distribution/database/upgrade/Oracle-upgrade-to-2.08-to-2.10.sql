alter table NService add (AuthRequired varchar2(1) null);
alter table NFlow add (TargetExchangeName varchar2(255) null);

update NService set AuthRequired = 'Y';