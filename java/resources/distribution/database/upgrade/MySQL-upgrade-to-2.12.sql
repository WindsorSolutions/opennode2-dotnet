alter table NConfig add (name varchar2(255) null);
update NConfig set name = id;