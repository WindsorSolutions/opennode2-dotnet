# Database Changes

## NCONFIG

Added a new varchar2(255) column called "name" to hold the name


----

alter table opennode2_dev.nconfig add (name varchar2(255) null);
update opennode2_dev.nconfig set name = id;