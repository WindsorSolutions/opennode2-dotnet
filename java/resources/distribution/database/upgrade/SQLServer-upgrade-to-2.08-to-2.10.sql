alter table NService add AuthRequired varchar(1) null;
alter table NFlow add TargetExchangeName varchar(255) null;

update NService set AuthRequired = 'Y';