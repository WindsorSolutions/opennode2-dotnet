alter table NService add PublishFlags varchar(50) null;
alter table NService add AuthRequired varchar(1) null;

update NService set AuthRequired = 'Y';