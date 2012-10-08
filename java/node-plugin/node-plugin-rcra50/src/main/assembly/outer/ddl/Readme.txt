*********************************************************************
Date:    03/05/2010
Author:  SSIKHARAM
Company: Windsor Solutions, Inc.

Subject: This file identifies the differences between the Oracle DDL 
         and the DB2 DDL's used for installing RCRA 5.0 flow objects.

*********************************************************************

RCRA_5.0-ORA-DDL.SQL  -->  This DDL contains additional objects 
			   pertaining to RCRA 5.0 XML elements
RCRA_5.0-DB2-DDL.SQL  -->  This DDL contains RCRA 4.0 objects that 
			   are upgraded to RCRA 5.0 by modifying the 
                           existing objects, etc.  It does not contain
                           the additional elements for RCRA 5.0.
			   (This DDL is used for Missouri where the
                           additional elements were not implemented)