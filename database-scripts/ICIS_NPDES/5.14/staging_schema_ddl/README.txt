RELEASE DATE: 2025-07-20

This folder contains DB objects for ICIS-NPDES 5.14 

Objects are provided for 3 database installation types:

- ICS_5.14_Oracle.zip: Oracle, with schemas (users) named ICS_FLOW_LOCAL and ICS_FLOW_ICIS
- ICS_5.14_SQL.zip: SQL Server, with a separate database each for ICS_FLOW_LOCAL and ICS_FLOW_ICIS. This requires exact names for each database (Original configuration used for some older installations)
- ICS_5.14_SQLES: SQL Server Explicit Schema, where objects are installed in two separate schemas (ICS_FLOW_LOCAL and ICS_FLOW_ICIS) within a database that can have any name. Note that the user accessing this schema from the node must default to the ICS_FLOW_LOCAL schema by default when using this method. (Preferred method for new SQL Server installs)

MySQL support has been discontinued.  

