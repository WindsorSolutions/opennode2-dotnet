    drop table RCRA_SOLICITHISTORY cascade constraints;

    drop table RCRA_ABSFEATUREPROPTYPE cascade constraints;

    drop table RCRA_AREAACREAGE cascade constraints;

    drop table RCRA_CERT cascade constraints;

    drop table RCRA_CITN cascade constraints;

    drop table RCRA_CMEFACSUB cascade constraints;

    drop table RCRA_CONTACT cascade constraints;

    drop table RCRA_CONTACTADDRESS cascade constraints;

    drop table RCRA_CORRACTAREA cascade constraints;

    drop table RCRA_CORRACTAUTH cascade constraints;

    drop table RCRA_CORRACTEVENT cascade constraints;

    drop table RCRA_CORRACTFACSUB cascade constraints;

    drop table RCRA_CORRACTRELEVENT cascade constraints;

    drop table RCRA_CORRACTRELPERMITUNIT cascade constraints;

    drop table RCRA_CORRACTSTATCITN cascade constraints;

    drop table RCRA_COSTEST cascade constraints;

    drop table RCRA_COSTESTRELMECH cascade constraints;

    drop table RCRA_CSNYDATE cascade constraints;

    drop table RCRA_ENFRCACT cascade constraints;

    drop table RCRA_ENVPERMIT cascade constraints;

    drop table RCRA_EVAL cascade constraints;

    drop table RCRA_EVALCOMMIT cascade constraints;

    drop table RCRA_EVALVIO cascade constraints;

    drop table RCRA_EVENTCOMMIT cascade constraints;

    drop table RCRA_FACOWNROPER cascade constraints;

    drop table RCRA_FACSUB cascade constraints;

    drop table RCRA_FINASSURFACSUB cascade constraints;

    drop table RCRA_FINASSURSUB cascade constraints;

    drop table RCRA_GEOGINF cascade constraints;

    drop table RCRA_GEOGINFSUB cascade constraints;

    drop table RCRA_GEOGMETA cascade constraints;

    drop table RCRA_GISFACSUB cascade constraints;

    drop table RCRA_HANDLER cascade constraints;

    drop table RCRA_HANDLERWASTECODE cascade constraints;

    drop table RCRA_HZRDSECONDARYMTRL cascade constraints;

    drop table RCRA_HZRDSECONDARYMTRLACT cascade constraints;

    drop table RCRA_HZRDWASTECMESUB cascade constraints;

    drop table RCRA_HZRDWASTECORRACT cascade constraints;

    drop table RCRA_HZRDWASTEHANDLERSUB cascade constraints;

    drop table RCRA_HZRDWASTEPERMIT cascade constraints;

    drop table RCRA_LABHZRDWASTE cascade constraints;

    drop table RCRA_LOCADDRESS cascade constraints;

    drop table RCRA_MAILINGADDRESS cascade constraints;

    drop table RCRA_MECH cascade constraints;

    drop table RCRA_MECHDETAIL cascade constraints;

    drop table RCRA_MEDIA cascade constraints;

    drop table RCRA_MLSTN cascade constraints;

    drop table RCRA_NAICS cascade constraints;

    drop table RCRA_OTHERID cascade constraints;

    drop table RCRA_PAYMNT cascade constraints;

    drop table RCRA_PENALTY cascade constraints;

    drop table RCRA_PERMITEVENT cascade constraints;

    drop table RCRA_PERMITFACSUB cascade constraints;

    drop table RCRA_PERMITRELEVENT cascade constraints;

    drop table RCRA_PERMITSERIES cascade constraints;

    drop table RCRA_PERMITUNIT cascade constraints;

    drop table RCRA_PERMITUNITDETAIL cascade constraints;

    drop table RCRA_REQUEST cascade constraints;

    drop table RCRA_SITEWASTEACT cascade constraints;

    drop table RCRA_STATEACT cascade constraints;

    drop table RCRA_SUPPENVPROJ cascade constraints;

    drop table RCRA_UNVWASTEACT cascade constraints;

    drop table RCRA_USEDOIL cascade constraints;

    drop table RCRA_VIO cascade constraints;

    drop table RCRA_VIOENFRC cascade constraints;

    drop table RCRA_WASTEGENRTR cascade constraints;

    drop table RCRA_WHERETYPE cascade constraints;

    drop sequence COLUMN_ID_SEQUENCE;

    CREATE TABLE RCRA_SOLICITHISTORY (
        ID VARCHAR2(40),
        SCHEDULERUNDATE DATE,
        TRANSACTIONID VARCHAR2(50),
        PROCESSINGSTATUS VARCHAR2(50),
        SOLICITTYPE VARCHAR2(50)
    );

    create table RCRA_ABSFEATUREPROPTYPE (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_AREAACREAGE (
        ID number(19,0) not null,
        AREAACREAGEMSR number(13,2),
        AREAMSRDATEITEM date,
        AREAMSRSOURCECODE varchar2(4 char),
        AREAMSRSOURCEDATOWNRCODE varchar2(2 char),
        AREAMSRSOURCETXT varchar2(4000 char),
        primary key (ID)
    );

    create table RCRA_CERT (
        ID number(19,0) not null,
        CERTSEQNUMBER number(8,0),
        FIRSTNAME varchar2(15 char),
        INDIVIDUALTITLETXT varchar2(45 char),
        LASTNAME varchar2(15 char),
        MIDDLEINITIAL varchar2(1 char),
        SIGNEDDATEITEM date,
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        CERTEMAILTXT varchar2(80),
        primary key (ID)
    );

    create table RCRA_CITN (
        ID number(19,0) not null,
        CITNDESC varchar2(255 char),
        CITNNAME varchar2(35 char),
        CITNNAMEOWNR varchar2(2 char),
        CITNNAMESEQNUMBER number(6,0),
        CITNNAMETYPE varchar2(2 char),
        NOTES varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        VIOID number(19,0),
        primary key (ID)
    );

    create table RCRA_CMEFACSUB (
        ID number(19,0) not null,
        EPAHANDLERID varchar2(12 char),
        FKID number(19,0),
        HZRDWASTECMESUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_CONTACT (
        ID number(19,0) not null,
        EMAILADDRESSTXT varchar2(240 char),
        FAX varchar2(15 char),
        FIRSTNAME varchar2(38 char),
        INDIVIDUALTITLETXT varchar2(45 char),
        LASTNAME varchar2(38 char),
        MIDDLEINITIAL varchar2(1 char),
        ORGFORMALNAME varchar2(80 char),
        PHONEEXTTXT varchar2(6 char),
        TELEPHONE varchar2(15 char),
        CONTACTADDRESSID number(19,0),
        primary key (ID)
    );

    create table RCRA_CONTACTADDRESS (
        ID number(19,0) not null,
        FKID number(19,0),
        CONTACTADDRESSID number(19,0),
        MAILCONTACTADDRESSID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTAREA (
        ID number(19,0) not null,
        EPARSPPERSONDATOWNRCODE varchar2(255 char),
        EPARSPPERSONID varchar2(255 char),
        AIRRELEASEIND varchar2(1 char),
        AREANAME varchar2(40 char),
        AREASEQNUMBER number(4,0),
        FACWIDEIND varchar2(1 char),
        GROUNDWATERRELEASEIND varchar2(1 char),
        REGULATEDUNITIND varchar2(1 char),
        SOILRELEASEIND varchar2(1 char),
        STATERSPPERSONDATOWNRCODE varchar2(255 char),
        STATERSPPERSONID varchar2(255 char),
        SUPPINFTXT varchar2(2000 char),
        SURFACEWATERRELEASEIND varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTAUTH (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        AGENCYTXT varchar2(4000 char),
        AUTHAGENCYCODE varchar2(1 char),
        AUTHDATOWNRCODE varchar2(2 char),
        AUTHEFFECTIVEDATEITEM date,
        AUTHSUBORGCODE varchar2(10 char),
        AUTHSUBORGDATOWNRCODE varchar2(2 char),
        AUTHTYPECODE varchar2(1 char),
        AUTHTYPETXT varchar2(4000 char),
        ENDDATEITEM date,
        ESTABLISHEDREPOSITORYCODE varchar2(1 char),
        ESTABLISHEDREPOSITORYTXT varchar2(4000 char),
        ISSUEDATEITEM date,
        RSPLEADPROGRAMID varchar2(1 char),
        RSPLEADPROGRAMTXT varchar2(4000 char),
        RSPPERSONDATOWNRCODE varchar2(2 char),
        RSPPERSONID varchar2(5 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTEVENT (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        ACTUALDATEITEM date,
        AGENCYTXT varchar2(4000 char),
        CORRACTEVENTCODE varchar2(7 char),
        CORRACTEVENTDATOWNRCODE varchar2(2 char),
        CORRACTEVENTTXT varchar2(4000 char),
        EVENTAGENCYCODE varchar2(1 char),
        EVENTSEQNUMBER number(3,0),
        EVENTSUBORGCODE varchar2(10 char),
        EVENTSUBORGDATOWNRCODE varchar2(2 char),
        NEWSCHEDDATEITEM date,
        ORIGSCHEDDATEITEM date,
        RSPPERSONDATOWNRCODE varchar2(2 char),
        RSPPERSONID varchar2(5 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTFACSUB (
        ID number(19,0) not null,
        HANDLERID varchar2(12 char),
        FKID number(19,0),
        HZRDWASTECORRACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTRELEVENT (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        AGENCYTXT varchar2(4000 char),
        CORRACTEVENTCODE varchar2(7 char),
        CORRACTEVENTDATOWNRCODE varchar2(2 char),
        CORRACTEVENTTXT varchar2(4000 char),
        EVENTAGENCYCODE varchar2(1 char),
        EVENTSEQNUMBER number(3,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTAREAID number(19,0),
        CORRACTAUTHID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTRELPERMITUNIT (
        ID number(19,0) not null,
        PERMITUNITSEQNUMBER number(4,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTAREAID number(19,0),
        primary key (ID)
    );

    create table RCRA_CORRACTSTATCITN (
        ID number(19,0) not null,
        STATCITNDATOWNRCODE varchar2(2 char),
        STATCITNDESC varchar2(255 char),
        STATCITNID varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTAUTHID number(19,0),
        primary key (ID)
    );

    create table RCRA_COSTEST (
      ID                   number(19,0) not null,
      ACTLOCCODE           varchar2(255 char),
      AGENCYTXT            varchar2(4000 char),
      AREAUNITNOTESTXT     varchar2(240 char),
      COSTESTAGENCYCODE    varchar2(1 char),
      COSTESTAMT           number(13,2),
      COSTESTDATEITEM      date,
      COSTESTREASONCODE    varchar2(1 char),
      COSTESTREASONTXT     varchar2(4000 char),
      COSTESTSEQNUMBER     NUMBER(4, 0),
      COSTESTTYPECODE      varchar2(1 char),
      COSTESTTYPETXT       varchar2(4000 char),
      RSPPERSONDATOWNRCODE varchar2(2 char),
      RSPPERSONID          varchar2(5 char),
      SUPPINFTXT           varchar2(2000 char),
      TRANSACTIONCODE      varchar2(1 char),
      FKID                 number(19,0),
      FINASSURFACSUBID     number(19,0),
        primary key (ID)
    );

    create table RCRA_COSTESTRELMECH (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        AGENCYTXT varchar2(4000 char),
        MECHAGENCYCODE varchar2(1 char),
        MECHDETAILSEQNUMBER number(4,0),
        MECHSEQNUMBER number(4,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        COSTESTID number(19,0),
        primary key (ID)
    );

    create table RCRA_CSNYDATE (
        ID number(19,0) not null,
        SNYDATEITEM date,
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_ENFRCACT (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        APPEALINITIATEDDATEITEM date,
        APPEALRESOLUTIONDATEITEM date,
        CNSNTAGREEFINORDERSEQNUMBER number(6,0),
        CORRACTCOMPONENT varchar2(1 char),
        DISPOSSTATUS varchar2(2 char),
        DISPOSSTATUSDATEITEM date,
        DISPOSSTATUSOWNR varchar2(2 char),
        DISPOSSTATUSTXT varchar2(4000 char),
        ENFRCACTDATEITEM date,
        ENFRCACTID varchar2(3 char),
        ENFRCAGENCYLOCNAME varchar2(2 char),
        ENFRCAGENCYNAME varchar2(1 char),
        ENFRCATTORNEY varchar2(5 char),
        ENFRCDOCKETNUMBER varchar2(15 char),
        ENFRCOWNR varchar2(2 char),
        ENFRCRSPPERSONID varchar2(5 char),
        ENFRCRSPPERSONOWNR varchar2(2 char),
        ENFRCRSPSUBORG varchar2(10 char),
        ENFRCRSPSUBORGOWNR varchar2(2 char),
        ENFRCTYPE varchar2(3 char),
        ENFRCTYPETXT varchar2(4000 char),
        NOTES varchar2(2000 char),
        RESPONDENTNAME varchar2(255 char),
        TRANSACTIONCODE varchar2(1 char),
        CMEFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_ENVPERMIT (
        ID number(19,0) not null,
        ENVPERMITDESC varchar2(80 char),
        ENVPERMITID varchar2(13 char),
        ENVPERMITOWNRNAME varchar2(2 char),
        ENVPERMITTYPECODE varchar2(1 char),
        ENVPERMITTYPETXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        primary key (ID)
    );

    create table RCRA_EVAL (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        CTZNCOMPLAINTIND varchar2(1 char),
        DAYZEROITEM date,
        EVALACTLOC varchar2(2 char),
        EVALID varchar2(3 char),
        EVALRSPAGENCY varchar2(1 char),
        EVALRSPPERSONID varchar2(5 char),
        EVALRSPPERSONIDOWNR varchar2(2 char),
        EVALRSPSUBORG varchar2(10 char),
        EVALRSPSUBORGOWNR varchar2(2 char),
        EVALSTARTDATEITEM date,
        EVALTYPE varchar2(3 char),
        EVALTYPEOWNR varchar2(2 char),
        EVALTYPETXT varchar2(4000 char),
        FOCUSAREA varchar2(3 char),
        FOCUSAREAOWNR varchar2(2 char),
        FOCUSAREATXT varchar2(4000 char),
        FOUNDVIO varchar2(1 char),
        MEDIAIND varchar2(1 char),
        NOTSUBTITLECIND varchar2(1 char),
        NOTES varchar2(2000 char),
        SAMPLINGIND varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        CMEFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_EVALCOMMIT (
        ID number(19,0) not null,
        COMMITLEAD varchar2(2 char),
        COMMITSEQNUMBER number(6,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        EVALID number(19,0),
        primary key (ID)
    );

    create table RCRA_EVALVIO (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        AGENCYDETERMVIO varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        VIOACTLOC varchar2(2 char),
        VIOSEQNUMBER number(4,0),
        FKID number(19,0),
        EVALID number(19,0),
        primary key (ID)
    );

    create table RCRA_EVENTCOMMIT (
        ID number(19,0) not null,
        COMMITLEAD varchar2(2 char),
        COMMITSEQNUMBER number(6,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        CORRACTEVENTID number(19,0),
        PERMITEVENTID number(19,0),
        primary key (ID)
    );

    create table RCRA_FACOWNROPER (
        ID number(19,0) not null,
        CURRENTENDDATEITEM date,
        CURRENTSTARTDATEITEM date,
        OWNROPERIND varchar2(2 char),
        OWNROPERSEQNUMBER number(4,0),
        OWNROPERSUPPINFTXT varchar2(4000 char),
        OWNROPERTXT varchar2(4000 char),
        OWNROPERTYPECODE varchar2(1 char),
        OWNROPERTYPETXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        FACOWNROPERID number(19,0),
        primary key (ID)
    );

    create table RCRA_FACSUB (
        ID number(19,0) not null,
        DATACCESSTXT varchar2(4000 char),
        FACREGISTRYID varchar2(12 char),
        HANDLERID varchar2(12 char),
        PUBUSEEXTRACTIND varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HZRDWASTEHANDLERSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_FINASSURFACSUB (
        ID number(19,0) not null,
        HANDLERID varchar2(12 char),
        FKID number(19,0),
        FINASSURSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_FINASSURSUB (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_GEOGINF (
        ID number(19,0) not null,
        AREASEQNUMBER number(4,0),
        GEOGINFOWNR varchar2(2 char),
        GEOGINFSEQNUMBER number(4,0),
        LOCCOMMENTSTXT varchar2(2000 char),
        PERMITUNITSEQNUMBER number(4,0),
        TRANSACTIONCODE varchar2(1 char),
        AREAACREAGEID number(19,0),
        GEOGMETAID number(19,0),
        WHEREID number(19,0),
        GISFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_GEOGINFSUB (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_GEOGMETA (
        ID number(19,0) not null,
        COORDDATSOURCECODE varchar2(3 char),
        COORDDATSOURCEDATOWNRCODE varchar2(2 char),
        COORDDATSOURCENAME varchar2(255 char),
        DATCOLLDATEITEM date,
        GEOGREFPOINTCODE varchar2(3 char),
        GEOGREFPOINTDATOWNRCODE varchar2(2 char),
        GEOGREFPOINTNAME varchar2(255 char),
        GEOMTYPECODE varchar2(3 char),
        GEOMTYPEDATOWNRCODE varchar2(2 char),
        GEOMTYPENAME varchar2(255 char),
        HORIZACCURACYMSR number(6,0),
        HORIZCOLLMETHODCODE varchar2(3 char),
        HORIZCOLLMETHODDATOWNRCODE varchar2(2 char),
        HORIZCOLLMETHODNAME varchar2(255 char),
        HORIZCOORDREFSYSDATCODE varchar2(3 char),
        HORIZCOORDREFSYSDATDATOWNRCODE varchar2(2 char),
        HORIZCOORDREFSYSDATUM varchar2(255 char),
        SOURCEMAPSCALE number(10,10),
        VERMETHODCODE varchar2(3 char),
        VERMETHODDATOWNRCODE varchar2(2 char),
        VERMETHODNAME varchar2(255 char),
        primary key (ID)
    );

    create table RCRA_GISFACSUB (
        ID number(19,0) not null,
        HANDLERID varchar2(12 char),
        FKID number(19,0),
        GEOINFSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_HANDLER (
        ID number(19,0) not null,
        ACCESSIBILITYCODE varchar2(1 char),
        ACCESSIBILITYCODETXT varchar2(4000 char),
        ACKRECEIPTDATEITEM date,
        ACTLOCCODE varchar2(255 char),
        COUNTYCODE varchar2(5 char),
        COUNTYCODEOWNR varchar2(2 char),
        COUNTYNAME varchar2(255 char),
        HANDLERNAME varchar2(80 char),
        HANDLERSUPPINFTXT varchar2(4000 char),
        NONNOTIFIERIND varchar2(1 char),
        NONNOTIFIERINDTXT varchar2(4000 char),
        OFFSITEWASTERECEIPTCODE varchar2(1 char),
        RECEIVEDATEITEM date,
        SOURCERECSEQNUMBER number(6,0),
        SOURCETYPECODE varchar2(1 char),
        SOURCETYPETXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        TRTMNTSTORAGEDISPDATEITEM date,
        FKID number(19,0),
        FACSUBID number(19,0),
        CONTACTADDRESSID number(19,0),
        WASTEGENRTRID number(19,0),
        HZRDSECONDARYMTRLID number(19,0),
        LABHZRDWASTEID number(19,0),
        LOCADDRESSID number(19,0),
        MAILINGADDRESSID number(19,0),
        PERMITCONTACTADDRESSID number(19,0),
        STATEWASTEGENRTRID number(19,0),
        USEDOILID number(19,0),
        SITEWASTEACTID number(19,0),
        HANDLERINTERNALSUPPINFTXT varchar2(4000),
        SHORTTERMSUPPINFTXT varchar2(4000),
        NATUREOFBUSINESSTXT varchar2(4000),
        primary key (ID)
    );

    create table RCRA_HANDLERWASTECODE (
        ID number(19,0) not null,
        TRANSACTIONCODE varchar2(1 char),
        WASTECODE varchar2(6 char),
        WASTECODEOWNRNAME varchar2(2 char),
        WASTECODETXT varchar2(4000 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        HZRDSECONDARYMTRLACTID number(19,0),
        PERMITUNITDETAILID number(19,0),
        primary key (ID)
    );

    create table RCRA_HZRDSECONDARYMTRL (
        ID number(19,0) not null,
        EFFECTIVEDATEITEM date,
        FINASSURIND varchar2(1 char),
        NOTIFICATIONREASONCODE varchar2(1 char),
        NOTIFICATIONREASONTXT varchar2(4000 char),
        RECYCLINGIND varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        primary key (ID)
    );

    create table RCRA_HZRDSECONDARYMTRLACT (
        ID number(19,0) not null,
        HSMSEQNUMBER varchar2(4 char),
        ACTUALSHORTTONSQUANT number(20,10),
        ESTIMATEDSHORTTONSQUANT number(20,10),
        FACCODEOWNRNAME varchar2(2 char),
        FACTYPECODE varchar2(2 char),
        FACTYPETXT varchar2(4000 char),
        LANDBASEDUNITIND varchar2(2 char),
        LANDBASEDUNITINDTXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HZRDSECONDARYMTRLID number(19,0),
        primary key (ID)
    );

    create table RCRA_HZRDWASTECMESUB (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_HZRDWASTECORRACT (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_HZRDWASTEHANDLERSUB (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_HZRDWASTEPERMIT (
        ID number(19,0) not null,
        primary key (ID)
    );

    create table RCRA_LABHZRDWASTE (
        ID number(19,0) not null,
        COLLEGEIND varchar2(1 char),
        HOSPITALIND varchar2(1 char),
        NONPROFITIND varchar2(1 char),
        WITHDRAWALIND varchar2(1 char),
        primary key (ID)
    );

    create table RCRA_LOCADDRESS (
        ID number(19,0) not null,
        COUNTRYNAME varchar2(2 char),
        LOCALITYNAME varchar2(25 char),
        LOCADDRESS varchar2(12 char),
        LOCADDRESSTXT varchar2(50 char),
        LOCZIPCODE varchar2(14 char),
        STATEUSPSCODE varchar2(2 char),
        SUPPLOCTXT varchar2(50 char),
        primary key (ID)
    );

    create table RCRA_MAILINGADDRESS (
        ID number(19,0) not null,
        MAILINGADDRESSCITYNAME varchar2(25 char),
        MAILINGADDRESSCOUNTRYNAME varchar2(2 char),
        MAILINGADDRESS varchar2(12 char),
        MAILINGADDRESSSTATEUSPSCODE varchar2(2 char),
        MAILINGADDRESSTXT varchar2(50 char),
        MAILINGADDRESSZIPCODE varchar2(14 char),
        SUPPADDRESSTXT varchar2(50 char),
        CONTACTADDRESSID number(19,0),
        primary key (ID)
    );

    create table RCRA_MECH (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        AGENCYTXT varchar2(4000 char),
        MECHAGENCYCODE varchar2(1 char),
        MECHSEQNUMBER number(4,0),
        MECHTYPECODE varchar2(1 char),
        MECHTYPEDATOWNRCODE varchar2(2 char),
        MECHTYPETXT varchar2(4000 char),
        PROVIDERFULLCONTACTNAME varchar2(33 char),
        PROVIDERTXT varchar2(80 char),
        SUPPINFTXT varchar2(2000 char),
        TELEPHONE varchar2(15 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        FINASSURFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_MECHDETAIL (
        ID number(19,0) not null,
        EFFECTIVEDATEITEM date,
        EXPIRATIONDATEITEM date,
        FACEVALAMT number(13,2),
        MECHDETAILSEQNUMBER number(4,0),
        MECHIDENTIFICATIONTXT varchar2(40 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        MECHID number(19,0),
        primary key (ID)
    );

    create table RCRA_MEDIA (
        ID number(19,0) not null,
        MEDIACODE varchar2(3 char),
        MEDIACODEOWNR varchar2(2 char),
        NOTES varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_MLSTN (
        ID number(19,0) not null,
        MLSTNACTUALCMPLTDATEITEM date,
        MLSTNDEFAULTEDDATEITEM date,
        MLSTNSCHEDCMPLTDATEITEM date,
        MLSTNSEQNUMBER number(6,0),
        NOTES varchar2(2000 char),
        TECHREQDESC varchar2(200 char),
        TECHREQID varchar2(50 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_NAICS (
        ID number(19,0) not null,
        NAICSCODE varchar2(6 char),
        NAICSOWNRCODE varchar2(2 char),
        NAICSSEQNUMBER varchar2(4 char),
        NAICSTXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        primary key (ID)
    );

    create table RCRA_OTHERID (
        ID number(19,0) not null,
        OTHERHANDLERID varchar2(12 char),
        OTHERIDSUPPINFTXT varchar2(4000 char),
        RELOWNRNAME varchar2(2 char),
        RELTYPECODE varchar2(1 char),
        RELTYPETXT varchar2(4000 char),
        SAMEFACIND varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        FACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_PAYMNT (
        ID number(19,0) not null,
        ACTUALPAIDAMT number(13,2),
        ACTUALPAYMNTDATEITEM date,
        NOTES varchar2(2000 char),
        PAYMNTDEFAULTEDDATEITEM date,
        PAYMNTSEQNUMBER number(2,0),
        SCHEDPAYMNTAMT number(13,2),
        SCHEDPAYMNTDATEITEM date,
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PENALTYID number(19,0),
        primary key (ID)
    );

    create table RCRA_PENALTY (
        ID number(19,0) not null,
        CASHCIVILPENALTYSOUGHTAMT number(13,2),
        NOTES varchar2(2000 char),
        PENALTYTYPE varchar2(3 char),
        PENALTYTYPEOWNR varchar2(2 char),
        PENALTYTYPETXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITEVENT (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        ACTUALDATEITEM date,
        AGENCYTXT varchar2(4000 char),
        EVENTAGENCYCODE varchar2(1 char),
        EVENTSEQNUMBER number(3,0),
        EVENTSUBORGCODE varchar2(10 char),
        EVENTSUBORGDATOWNRCODE varchar2(2 char),
        NEWSCHEDDATEITEM date,
        ORIGSCHEDDATEITEM date,
        PERMITEVENTCODE varchar2(7 char),
        PERMITEVENTDATOWNRCODE varchar2(2 char),
        PERMITEVENTTXT varchar2(4000 char),
        RSPPERSONDATOWNRCODE varchar2(2 char),
        RSPPERSONID varchar2(5 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PERMITSERIESID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITFACSUB (
        ID number(19,0) not null,
        HANDLERID varchar2(12 char),
        FKID number(19,0),
        HZRDWASTEPERMITID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITRELEVENT (
        ID number(19,0) not null,
        ACTLOCCODE varchar2(255 char),
        AGENCYTXT varchar2(4000 char),
        EVENTAGENCYCODE varchar2(1 char),
        EVENTSEQNUMBER number(3,0),
        PERMITEVENTCODE varchar2(7 char),
        PERMITEVENTDATOWNRCODE varchar2(2 char),
        PERMITEVENTTXT varchar2(4000 char),
        PERMITSERIESSEQNUMBER number(4,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PERMITUNITDETAILID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITSERIES (
        ID number(19,0) not null,
        PERMITSERIESNAME varchar2(40 char),
        PERMITSERIESSEQNUMBER number(4,0),
        RSPPERSONDATOWNRCODE varchar2(2 char),
        RSPPERSONID varchar2(5 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PERMITFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITUNIT (
        ID number(19,0) not null,
        PERMITUNITNAME varchar2(40 char),
        PERMITUNITSEQNUMBER number(4,0),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PERMITFACSUBID number(19,0),
        primary key (ID)
    );

    create table RCRA_PERMITUNITDETAIL (
        ID number(19,0) not null,
        CAPTYPECODE varchar2(1 char),
        CAPTYPETXT varchar2(4000 char),
        COMMERCIALSTATUSCODE varchar2(1 char),
        COMMERCIALSTATUSTXT varchar2(4000 char),
        LEGALOPERSTATUSCODE varchar2(4 char),
        LEGALOPERSTATUSDATOWNRCODE varchar2(2 char),
        LEGALOPERSTATUSTXT varchar2(4000 char),
        MSRUNITCODE varchar2(1 char),
        MSRUNITDATOWNRCODE varchar2(2 char),
        MSRUNITTXT varchar2(4000 char),
        NUMBEROFUNITSCOUNT number(7,0),
        PERMITSTATUSEFFECTIVEDATEITEM date,
        PERMITUNITCAPQUANT number(14,3),
        PERMITUNITDETAILSEQNUMBER number(3,0),
        PROCESSUNITCODE varchar2(3 char),
        PROCESSUNITDATOWNRCODE varchar2(2 char),
        PROCESSUNITTXT varchar2(4000 char),
        STANDARDPERMITIND varchar2(1 char),
        SUPPINFTXT varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        PERMITUNITID number(19,0),
        primary key (ID)
    );

    create table RCRA_REQUEST (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        DATEOFREQUESTITEM date,
        DATERESPRECITEM date,
        NOTES varchar2(2000 char),
        REQUESTAGENCY varchar2(1 char),
        REQUESTSEQNUMBER number(6,0),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        EVALID number(19,0),
        primary key (ID)
    );

    create table RCRA_SITEWASTEACT (
        ID number(19,0) not null,
        FURNACEEXEMPTIONCODE varchar2(1 char),
        IMPORTERACTCODE varchar2(1 char),
        LANDTYPECODE varchar2(1 char),
        LANDTYPETXT varchar2(4000 char),
        MIXEDWASTEGENRTRCODE varchar2(1 char),
      ONSITEBURNEREXEMPTIONCODE   varchar2(1 char),
      RECYCLERACTCODE             varchar2(1 char),
      SHORTTERMGENRTRIND          varchar2(1 char),
      STATEDISTRICTCODE           varchar2(10 char),
      STATEDISTRICTCODETXT        varchar2(4000 char),
      STATEDISTRICTOWNRNAME       varchar2(2 char),
      TRANSFERFACIND              varchar2(1 char),
      TRNSPRTRACTCODE             varchar2(1 char),
      TRTMNTSTORAGEDISPACTCODE    varchar2(1 char),
      UNDRGRNDINJECTIONACTCODE    varchar2(1 char),
      UNVWASTEDESTINATIONFACIND   varchar2(1 char),
      SLABEXPORTERIND             VARCHAR2(1 CHAR),
      SLABIMPORTERIND             VARCHAR2(1 CHAR),
      RECOGNIZEDTRADEREXPORTERIND VARCHAR2(1 CHAR),
      RECOGNIZEDTRADERIMPORTERIND VARCHAR2(1 CHAR),
        primary key (ID)
    );

    create table RCRA_STATEACT (
        ID number(19,0) not null,
        STATEACTOWNRNAME varchar2(2 char),
        STATEACTTYPECODE varchar2(5 char),
        STATEACTTYPETXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        primary key (ID)
    );

    create table RCRA_SUPPENVPROJ (
        ID number(19,0) not null,
        SEPACTUALDATEITEM date,
        SEPCODEOWNR varchar2(2 char),
        SEPDEFAULTEDDATEITEM date,
        SEPDESCTXT varchar2(3 char),
        SEPEXPENDITUREAMT number(13,2),
        SEPLONGDESCTXT varchar2(4000 char),
        SEPSCHEDCMPLTDATEITEM date,
        SEPSEQNUMBER number(2,0),
        NOTES varchar2(2000 char),
        TRANSACTIONCODE varchar2(1 char),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_UNVWASTEACT (
        ID number(19,0) not null,
        ACCUMULATEDWASTECODE varchar2(1 char),
        GENERATEDHANDLERCODE varchar2(1 char),
        TRANSACTIONCODE varchar2(1 char),
        UNVWASTEOWNRNAME varchar2(2 char),
        UNVWASTETYPECODE varchar2(1 char),
        UNVWASTETYPETXT varchar2(4000 char),
        FKID number(19,0),
        HANDLERID number(19,0),
        primary key (ID)
    );

    create table RCRA_USEDOIL (
        ID number(19,0) not null,
        FUELBURNERCODE varchar2(1 char),
        MARKETBURNERCODE varchar2(1 char),
        PROCESSORCODE varchar2(1 char),
        REFINERCODE varchar2(1 char),
        SPECIFICATIONMARKETERCODE varchar2(1 char),
        TRANSFERFACCODE varchar2(1 char),
        TRNSPRTRCODE varchar2(1 char),
        primary key (ID)
    );

    create table RCRA_VIO (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        AGENCYDETERMVIO varchar2(1 char),
        FORMERCITNNAME varchar2(35 char),
        NOTES varchar2(2000 char),
        RETCOMPACTUALDATEITEM date,
        RETTOCOMPQUALIFIER varchar2(1 char),
        RETTOCOMPQUALIFIERTXT varchar2(4000 char),
        TRANSACTIONCODE varchar2(1 char),
        VIOACTLOC varchar2(2 char),
        VIODETERMDATEITEM date,
        VIORSPAGENCY varchar2(1 char),
        VIORSPAGENCYTXT varchar2(4000 char),
        VIOSEQNUMBER number(4,0),
        VIOTYPE varchar2(10 char),
        VIOTYPEOWNR varchar2(2 char),
        VIOTYPETXT varchar2(4000 char),
        CMEFACSUBID varchar2(255 char),
        FKID number(19,0),
        primary key (ID)
    );

    create table RCRA_VIOENFRC (
        ID number(19,0) not null,
        AGENCYTXT varchar2(4000 char),
        AGENCYDETERMVIO varchar2(1 char),
        RETCOMPSCHEDDATEITEM date,
        TRANSACTIONCODE varchar2(1 char),
        VIOSEQNUMBER number(4,0),
        FKID number(19,0),
        ENFRCACTID number(19,0),
        primary key (ID)
    );

    create table RCRA_WASTEGENRTR (
        ID number(19,0) not null,
        WASTEGENRTROWNRNAME varchar2(2 char),
        WASTEGENRTRSTATUSCODE varchar2(1 char),
        WASTEGENRTRSTATUSTXT varchar2(4000 char),
        primary key (ID)
    );

    create table RCRA_WHERETYPE (
        SRS_DIM number(19,2),
        SRS_NAME varchar2(255 char),
        SRSDIMENSION number(20,0),
        SRSNAME varchar2(255 char),
        ID number(19,0) not null,
        primary key (ID)
    );

    create sequence COLUMN_ID_SEQUENCE;

