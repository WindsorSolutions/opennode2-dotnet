DROP SEQUENCE THROW_AWAY.RCRA_HD_CERTIFICATION_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_ENV_PERMIT_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_HANDLER_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_HBASIC_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_NAICS_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_OTHER_ID_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_OWNEROP_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_STATE_ACTIVITY_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE_S
/
DROP SEQUENCE THROW_AWAY.RCRA_HD_WASTE_CODE_S
/


DROP TABLE THROW_AWAY.RCRA_HD_WASTE_CODE
/
DROP TABLE THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE
/
DROP TABLE THROW_AWAY.RCRA_HD_STATE_ACTIVITY
/
DROP TABLE THROW_AWAY.RCRA_HD_OWNEROP
/
DROP TABLE THROW_AWAY.RCRA_HD_OTHER_ID
/
DROP TABLE THROW_AWAY.RCRA_HD_NAICS
/
DROP TABLE THROW_AWAY.RCRA_HD_HANDLER
/
DROP TABLE THROW_AWAY.RCRA_HD_ENV_PERMIT
/
DROP TABLE THROW_AWAY.RCRA_HD_CERTIFICATION
/
DROP TABLE THROW_AWAY.RCRA_HD_HBASIC
/


CREATE TABLE THROW_AWAY.RCRA_HD_CERTIFICATION ( 
	PK_GUID            	NUMBER(20,0) NOT NULL,
	FK_GUID            	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE   	CHARACTER(1) NOT NULL,
	CERT_SEQ           	INTEGER NOT NULL,
	CERT_SIGNED_DATE   	VARCHAR(10),
	CERT_TITLE         	VARCHAR(45),
	CERT_FIRST_NAME    	VARCHAR(15),
	CERT_MIDDLE_INITIAL	CHARACTER(1),
	CERT_LAST_NAME     	VARCHAR(15),
	NOTES              	VARCHAR(245) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_ENV_PERMIT ( 
	PK_GUID          	NUMBER(20,0) NOT NULL,
	FK_GUID          	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE 	CHARACTER(1) NOT NULL,
	ENV_PERMIT_NUMBER	VARCHAR(13) NOT NULL,
	ENV_PERMIT_OWNER 	CHARACTER(2),
	ENV_PERMIT_TYPE  	CHARACTER(1),
	ENV_PERMIT_DESC  	VARCHAR(20),
	NOTES            	VARCHAR(240) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_HANDLER ( 
	PK_GUID                       	NUMBER(20,0) NOT NULL,
	FK_GUID                       	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE              	CHARACTER(1) NOT NULL,
	ACTIVITY_LOCATION             	CHARACTER(2) NOT NULL,
	SOURCE_TYPE                   	CHARACTER(1) NOT NULL,
	SEQ_NUMBER                    	INTEGER NOT NULL,
	RECEIVE_DATE                  	VARCHAR(10),
	NON_NOTIFIER                  	CHARACTER(1),
	NUMBER_OF_EMPLOYEES           	INTEGER,
	LOCATION_STREET1              	VARCHAR(30),
	LOCATION_STREET2              	VARCHAR(30),
	LOCATION_CITY                 	VARCHAR(25),
	LOCATION_STATE                	CHARACTER(2),
	LOCATION_ZIP                  	VARCHAR(14),
	LOCATION_COUNTRY              	CHARACTER(2),
	MAIL_STREET1                  	VARCHAR(30),
	MAIL_STREET2                  	VARCHAR(30),
	MAIL_CITY                     	VARCHAR(25),
	MAIL_STATE                    	CHARACTER(2),
	MAIL_ZIP                      	VARCHAR(14),
	MAIL_COUNTRY                  	CHARACTER(2),
	CONTACT_FIRST_NAME            	VARCHAR(15),
	CONTACT_MIDDLE_INITIAL        	CHARACTER(1),
	CONTACT_LAST_NAME             	VARCHAR(15),
	CONTACT_ORG_NAME              	VARCHAR(80),
	CONTACT_STREET1               	VARCHAR(30),
	CONTACT_STREET2               	VARCHAR(30),
	CONTACT_CITY                  	VARCHAR(25),
	CONTACT_STATE                 	CHARACTER(2),
	CONTACT_ZIP                   	VARCHAR(14),
	CONTACT_COUNTRY               	CHARACTER(2),
	CONTACT_PHONE                 	VARCHAR(15),
	CONTACT_PHONE_EXT             	VARCHAR(6),
	CONTACT_EMAIL_ADDRESS         	VARCHAR(240),
	PCONTACT_FIRST_NAME           	VARCHAR(15),
	PCONTACT_MIDDLE_NAME          	CHARACTER(1),
	PCONTACT_LAST_NAME            	VARCHAR(15),
	PCONTACT_ORG_NAME             	VARCHAR(80),
	PCONTACT_STREET1              	VARCHAR(30),
	PCONTACT_STREET2              	VARCHAR(30),
	PCONTACT_CITY                 	VARCHAR(25),
	PCONTACT_STATE                	CHARACTER(2),
	PCONTACT_ZIP                  	VARCHAR(14),
	PCONTACT_COUNTRY              	CHARACTER(1),
	PCONTACT_PHONE                	VARCHAR(15),
	PCONTACT_PHONE_EXT            	VARCHAR(6),
	PCONTACT_EMAIL_ADDRESS        	VARCHAR(240),
	ACKNOWLEDGE_DATE              	VARCHAR(10),
	ACKNOWLEDGE_FLAG              	CHARACTER(1),
	SITE_NAME                     	VARCHAR(80),
	IMPORTER_ACTIVITY             	CHARACTER(1),
	MIXED_WASTE_GENERATOR         	CHARACTER(1),
	RECYCLER_ACTIVITY             	CHARACTER(1),
	TRANSPORTER_ACTIVITY          	CHARACTER(1),
	TSD_ACTIVITY                  	CHARACTER(1),
	UNDERGROUND_INJECTION_ACTIVITY	CHARACTER(1),
	UNIVERSAL_WASTE_DEST_FACILITY 	CHARACTER(1),
	ONSITE_BURNER_EXEMPTION       	CHARACTER(1),
	FURNACE_EXEMPTION             	CHARACTER(1),
	LAND_TYPE                     	CHARACTER(1),
	STATE_DISTRICT                	VARCHAR(10),
	USED_OIL_BURNER               	CHARACTER(1),
	USED_OIL_PROCESSOR            	CHARACTER(1),
	USED_OIL_REFINER              	CHARACTER(1),
	USED_OIL_MARKET_BURNER        	CHARACTER(1),
	USED_OIL_SPEC_MARKETER        	CHARACTER(1),
	USED_OIL_TRANSFER_FACILITY    	CHARACTER(1),
	USED_OIL_TRANSPORTER          	CHARACTER(1),
	TSD_DATE                      	VARCHAR(10),
	OFF_SITE_RECEIPT              	CHARACTER(1),
	ACCESSIBILITY                 	CHARACTER(1),
	COUNTY_CODE                   	VARCHAR(5),
	COUNTY_CODE_OWNER             	CHARACTER(2),
	FED_WASTE_GENERATOR_OWNER     	CHARACTER(2),
	FED_WASTE_GENERATOR           	CHARACTER(1),
	STATE_WASTE_GENERATOR_OWNER   	CHARACTER(2),
	STATE_WASTE_GENERATOR         	CHARACTER(1),
	NOTES                         	VARCHAR(2000) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_HBASIC ( 
	PK_GUID            	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE   	CHARACTER(1),
	HANDLER_ID         	VARCHAR(12),
	EXTRACT_FLAG       	CHARACTER(1),
	FACILITY_IDENTIFIER	VARCHAR(12),
	NOTES              	VARCHAR(240),
	LAST_UPDATE_DATE   	TIMESTAMP NOT NULL 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_NAICS ( 
	PK_GUID         	NUMBER(20,0)  NOT NULL,
	FK_GUID         	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE	CHARACTER(1) NOT NULL,
	NAICS_SEQ       	INTEGER NOT NULL,
	NAICS_OWNER     	CHARACTER(2),
	NAICS_CODE      	VARCHAR(6),
	NOTES           	VARCHAR(240) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_OTHER_ID ( 
	PK_GUID           	NUMBER(20,0) NOT NULL,
	FK_GUID           	NUMBER(20,0) NOT NULL,
	OTHER_ID          	VARCHAR(12),
	RELATIONSHIP_OWNER	CHARACTER(2),
	RELATIONSHIP_TYPE 	CHARACTER(1),
	SAME_FACILITY     	CHARACTER(1),
	NOTES             	VARCHAR(2000) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_OWNEROP ( 
	PK_GUID            	NUMBER(20,0)  NOT NULL,
	FK_GUID            	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE   	CHARACTER(1),
	OWNER_OP_SEQ       	INTEGER NOT NULL,
	OWNER_OP_IND       	CHARACTER(2),
	FIRST_NAME         	VARCHAR(15),
	MIDDLE_INITIAL     	VARCHAR(1),
	LAST_NAME          	VARCHAR(15),
	ORG_NAME           	VARCHAR(80),
	OWNER_OP_TYPE      	CHARACTER(1),
	DATE_BECAME_CURRENT	VARCHAR(10),
	DATE_ENDED_CURRENT 	VARCHAR(10),
	STREET1            	VARCHAR(30),
	STREET2            	VARCHAR(30),
	CITY               	VARCHAR(25),
	STATE              	CHARACTER(2),
	COUNTRY            	CHARACTER(2),
	ZIP                	VARCHAR(14),
	PHONE              	VARCHAR(15),
	PHONE_EXT          	VARCHAR(6),
	EMAIL_ADDRESS      	VARCHAR(240),
	DUNN_BRADSTREET_NUM	VARCHAR(10),
	NOTES              	VARCHAR(240) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_STATE_ACTIVITY ( 
	PK_GUID             	NUMBER(20,0) NOT NULL,
	FK_GUID             	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE    	CHARACTER(1) NOT NULL,
	STATE_ACTIVITY_OWNER	CHARACTER(2) NOT NULL,
	STATE_ACTIVITY_TYPE 	VARCHAR(5) NOT NULL,
	NOTES               	VARCHAR(2000) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE ( 
	PK_GUID              	NUMBER(20,0)  NOT NULL,
	FK_GUID              	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE     	CHARACTER(1) NOT NULL,
	UNIVERSAL_WASTE_OWNER	CHARACTER(2),
	UNIVERSAL_WASTE_TYPE 	CHARACTER(1),
	ACCUMULATED          	CHARACTER(1),
	GENERATED            	CHARACTER(1),
	NOTES                	VARCHAR(240) 
	)
/

CREATE TABLE THROW_AWAY.RCRA_HD_WASTE_CODE ( 
	PK_GUID         	NUMBER(20,0) NOT NULL,
	FK_GUID         	NUMBER(20,0) NOT NULL,
	TRANSACTION_CODE	CHARACTER(1) NOT NULL,
	WASTE_CODE_OWNER	CHARACTER(2),
	WASTE_CODE_TYPE 	VARCHAR(6) 
	)
/


CREATE INDEX IDX_CERT
	ON THROW_AWAY.RCRA_HD_CERTIFICATION(FK_GUID)
/

CREATE INDEX IDX_ENVPERMIT
	ON THROW_AWAY.RCRA_HD_ENV_PERMIT(FK_GUID)
/

CREATE INDEX IDX_HANDLER
	ON THROW_AWAY.RCRA_HD_HANDLER(FK_GUID)
/

CREATE INDEX IDX_HANDLER_ID
	ON THROW_AWAY.RCRA_HD_HBASIC(HANDLER_ID)
/

CREATE INDEX IDX_NAICS
	ON THROW_AWAY.RCRA_HD_NAICS(FK_GUID)
/

CREATE INDEX IDX_OTHERID
	ON THROW_AWAY.RCRA_HD_OTHER_ID(FK_GUID)
/

CREATE INDEX IDX_OWNEROP
	ON THROW_AWAY.RCRA_HD_OWNEROP(FK_GUID)
/

CREATE INDEX IDX_STATEACT
	ON THROW_AWAY.RCRA_HD_STATE_ACTIVITY(FK_GUID)
/

CREATE INDEX IDX_UNIV
	ON THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE(FK_GUID)
/

CREATE INDEX IDX_WASTE
	ON THROW_AWAY.RCRA_HD_WASTE_CODE(FK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_CERTIFICATION
	ADD CONSTRAINT SQL080522162120440
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_ENV_PERMIT
	ADD CONSTRAINT SQL090420141704110
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_HANDLER
	ADD CONSTRAINT SQL090422120358410
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_HBASIC
	ADD CONSTRAINT SQL090420143700820
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_NAICS
	ADD CONSTRAINT SQL080522161304650
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_OTHER_ID
	ADD CONSTRAINT SQL090420153601240
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_OWNEROP
	ADD CONSTRAINT SQL090420140542950
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_STATE_ACTIVITY
	ADD CONSTRAINT SQL090420141726010
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE
	ADD CONSTRAINT SQL080522161229230
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_WASTE_CODE
	ADD CONSTRAINT SQL080522161249810
	PRIMARY KEY (PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_HANDLER
	ADD CONSTRAINT FK_HBASIC_HANDLER
	FOREIGN KEY(FK_GUID)
	REFERENCES THROW_AWAY.RCRA_HD_HBASIC(PK_GUID)
/

ALTER TABLE THROW_AWAY.RCRA_HD_OTHER_ID
	ADD CONSTRAINT FK_HBASIC_OTHERID
	FOREIGN KEY(FK_GUID)
	REFERENCES THROW_AWAY.RCRA_HD_HBASIC(PK_GUID)
/


-- Oracle Sequences:

CREATE SEQUENCE THROW_AWAY.RCRA_HD_CERTIFICATION_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_ENV_PERMIT_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_HANDLER_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_HBASIC_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_NAICS_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_OTHER_ID_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_OWNEROP_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_STATE_ACTIVITY_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_UNIVERSAL_WASTE_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/
CREATE SEQUENCE THROW_AWAY.RCRA_HD_WASTE_CODE_S INCREMENT BY 1 START WITH 1 NOMAXVALUE MINVALUE 0 NOCYCLE CACHE 20 ORDER
/

-- Oracle Triggers:

CREATE OR REPLACE TRIGGER RCRA_HD_CERTIFICATION_TBI BEFORE INSERT ON RCRA_HD_CERTIFICATION FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_CERTIFICATION_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_ENV_PERMIT_TBI BEFORE INSERT ON RCRA_HD_ENV_PERMIT FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_ENV_PERMIT_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_HANDLER_TBI BEFORE INSERT ON RCRA_HD_HANDLER FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_HANDLER_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_HBASIC_TBI BEFORE INSERT ON RCRA_HD_HBASIC FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_HBASIC_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_NAICS_TBI BEFORE INSERT ON RCRA_HD_NAICS FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_NAICS_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_OTHER_ID_TBI BEFORE INSERT ON RCRA_HD_OTHER_ID FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_OTHER_ID_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_OWNEROP_TBI BEFORE INSERT ON RCRA_HD_OWNEROP FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_OWNEROP_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_STATE_ACTIVITY_TBI BEFORE INSERT ON RCRA_HD_STATE_ACTIVITY FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_STATE_ACTIVITY_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_UNIVERSAL_WASTE_TBI BEFORE INSERT ON RCRA_HD_UNIVERSAL_WASTE FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_UNIVERSAL_WASTE_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/
CREATE OR REPLACE TRIGGER RCRA_HD_WASTE_CODE_TBI BEFORE INSERT ON RCRA_HD_WASTE_CODE FOR EACH ROW BEGIN IF INSERTING THEN IF :NEW.PK_GUID IS NULL THEN SELECT RCRA_HD_WASTE_CODE_S.NEXTVAL INTO :NEW.PK_GUID FROM dual; END IF; END IF; END;
/



