package com.windsor.node.plugin.facid3.dao;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.apache.commons.lang3.StringUtils;
import org.springframework.jdbc.core.RowMapper;
import com.windsor.node.plugin.facid3.domain.AddressPostalCodeDataType;
import com.windsor.node.plugin.facid3.domain.AffiliateDataType;
import com.windsor.node.plugin.facid3.domain.CountryCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.CountryIdentityDataType;
import com.windsor.node.plugin.facid3.domain.IndividualIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.IndividualIdentityDataType;
import com.windsor.node.plugin.facid3.domain.MailingAddressDataType;
import com.windsor.node.plugin.facid3.domain.ObjectFactory;
import com.windsor.node.plugin.facid3.domain.OrganizationIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.OrganizationIdentityDataType;
import com.windsor.node.plugin.facid3.domain.StateCodeListIdentifierDataType;
import com.windsor.node.plugin.facid3.domain.StateIdentityDataType;

public class AffiliateDataTypeRowMapper implements RowMapper
{
    private AffiliateDataTypeDao affiliateDataTypeDao;
    public AffiliateDataTypeRowMapper(AffiliateDataTypeDao affiliateDataTypeDao)
    {
        setAffiliateDataTypeDao(affiliateDataTypeDao);
    }

    public Object mapRow(ResultSet rs, int rowNum) throws SQLException
    {
        ObjectFactory fact = new ObjectFactory();
        AffiliateDataType affiliateDataType = fact.createAffiliateDataType();

        affiliateDataType.setAffiliateIdentifier(rs.getString("AFFL_IDEN"));

        // BEGIN SC:Electronic Address
        affiliateDataType.setElectronicAddressList(getAffiliateDataTypeDao().loadElectronicAddressesById(rs.getString("AFFL_ID")));
        // END SC:Electronic Address

        // BEGIN SC:Individual Identity
        IndividualIdentityDataType individualIdentity = fact.createIndividualIdentityDataType();
        affiliateDataType.setIndividualIdentity(individualIdentity);
        individualIdentity.setFirstName(rs.getString("FIRST_NAME"));
        individualIdentity.setIndividualFullName(rs.getString("INDV_FULL_NAME"));
        individualIdentity.setIndividualTitleText(rs.getString("INDV_TITLE_TEXT"));
        individualIdentity.setLastName(rs.getString("LAST_NAME"));
        individualIdentity.setMiddleName(rs.getString("MIDDLE_NAME"));
        individualIdentity.setNamePrefixText(rs.getString("NAME_PREFIX_TEXT"));
        individualIdentity.setNameSuffixText(rs.getString("NAME_SUFFIX_TEXT"));

        IndividualIdentifierDataType individualIdentifier = fact.createIndividualIdentifierDataType();
        individualIdentity.setIndividualIdentifier(individualIdentifier);
        individualIdentifier.setIndividualIdentifierContext(rs.getString("INDV_IDEN_CONT"));
        individualIdentifier.setValue(rs.getString("INDV_IDEN_VAL"));
        // END SC:Individual Identity

        // BEGIN SC:Mailing Address
        MailingAddressDataType mailingAddress = fact.createMailingAddressDataType();
        affiliateDataType.setMailingAddress(mailingAddress);
        mailingAddress.setMailingAddressCityName(rs.getString("MAIL_ADDR_CITY_NAME"));
        mailingAddress.setMailingAddressText(rs.getString("MAIL_ADDR_TEXT"));
        mailingAddress.setSupplementalAddressText(rs.getString("SUPP_ADDR_TEXT"));

        AddressPostalCodeDataType mailingAddressPostalCode = fact.createAddressPostalCodeDataType();
        mailingAddress.setAddressPostalCode(mailingAddressPostalCode);
        mailingAddressPostalCode.setValue(rs.getString("ADDR_POST_CODE_VAL"));
        mailingAddressPostalCode.setAddressPostalCodeContext(rs.getString("ADDR_POST_CODE_CONT"));

        CountryIdentityDataType mailingCountryIdentity = fact.createCountryIdentityDataType();
        mailingAddress.setCountryIdentity(mailingCountryIdentity);
        mailingCountryIdentity.setCountryCode(rs.getString("CTRY_CODE"));
        mailingCountryIdentity.setCountryName(rs.getString("CTRY_NAME"));

        CountryCodeListIdentifierDataType mailingCountryCodeListIdentifier = fact.createCountryCodeListIdentifierDataType();
        mailingCountryIdentity.setCountryCodeListIdentifier(mailingCountryCodeListIdentifier);
        mailingCountryCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("CTRY_IDEN_CODE_LIS_VER_AGN_IDE"));
        mailingCountryCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CTRY_IDEN_CODE_LIST_VERS_IDEN"));
        mailingCountryCodeListIdentifier.setValue(rs.getString("CTRY_IDEN_CODE_LST_VER_VAL"));

        StateIdentityDataType mailingStateIdentity = fact.createStateIdentityDataType();
        mailingAddress.setStateIdentity(mailingStateIdentity);
        mailingStateIdentity.setStateCode(rs.getString("STA_CODE"));
        mailingStateIdentity.setStateName(rs.getString("STA_NAME"));

        StateCodeListIdentifierDataType mailingStateCodeListIdentifier = fact.createStateCodeListIdentifierDataType();
        mailingStateIdentity.setStateCodeListIdentifier(mailingStateCodeListIdentifier);
        mailingStateCodeListIdentifier.setCodeListVersionAgencyIdentifier(rs.getString("CODE_LIST_VERS_AGN_IDEN"));
        mailingStateCodeListIdentifier.setCodeListVersionIdentifier(rs.getString("CODE_LIST_VERS_IDEN"));
        mailingStateCodeListIdentifier.setValue(rs.getString("CODE_LST_VER_VAL"));
        // END SC:Mailing Address

        // BEGIN SC:Organization Identity
        if(StringUtils.isNotBlank(rs.getString("ORG_FORMAL_NAME")) && StringUtils.isNotBlank(rs.getString("ORG_IDEN_CONT"))
                        && StringUtils.isNotBlank(rs.getString("ORG_IDEN_VAL")))
        {
            OrganizationIdentityDataType organizationIdentity = fact.createOrganizationIdentityDataType();
            affiliateDataType.setOrganizationIdentity(organizationIdentity);
            organizationIdentity.setOrganizationFormalName(rs.getString("ORG_FORMAL_NAME"));

            if(StringUtils.isNotBlank(rs.getString("ORG_IDEN_CONT")) && StringUtils.isNotBlank(rs.getString("ORG_IDEN_VAL")))
            {
                OrganizationIdentifierDataType organizationIdentifier = fact.createOrganizationIdentifierDataType();
                organizationIdentity.setOrganizationIdentifier(organizationIdentifier);
                organizationIdentifier.setOrganizationIdentifierContext(rs.getString("ORG_IDEN_CONT"));
                organizationIdentifier.setValue(rs.getString("ORG_IDEN_VAL"));
            }
        }
        // END SC:Organization Identity

        // BEGIN SC:Telephonic
        affiliateDataType.setTelephonicList(getAffiliateDataTypeDao().loadTelephonicById(rs.getString("AFFL_ID")));
        // END SC:Telephonic
        return affiliateDataType;
    }

    public AffiliateDataTypeDao getAffiliateDataTypeDao()
    {
        return affiliateDataTypeDao;
    }

    public void setAffiliateDataTypeDao(AffiliateDataTypeDao affiliateDataTypeDao)
    {
        this.affiliateDataTypeDao = affiliateDataTypeDao;
    }
}
