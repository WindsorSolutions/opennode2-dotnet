alter table NTransaction modify (NetworkId varchar2(255) null);
update NPartner set Version = 'EN2.1' where Version = 'EN2.0';
update NPartner set Version = 'EN2.1' where Version = 'Undefined';
update NTransaction set EndpointVersion = 'EN2.1' where EndpointVersion = 'EN2.0';
update NTransaction set NetworkEndpointVersion = 'EN2.1' where NetworkEndpointVersion = 'EN2.0';
