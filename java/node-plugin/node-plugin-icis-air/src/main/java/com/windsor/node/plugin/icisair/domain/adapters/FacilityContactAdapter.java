package com.windsor.node.plugin.icisair.domain.adapters;

import javax.xml.bind.annotation.adapters.XmlAdapter;

import com.windsor.node.plugin.icisair.domain.generated.FacilityContact;

/**
 * {@link XmlAdapter} for pruning empty {@link FacilityContactAdapter} objects.
 * 
 */
public class FacilityContactAdapter extends XmlAdapter<FacilityContact, FacilityContact>
{

    @Override
    public FacilityContact unmarshal(final FacilityContact facilityContact) throws Exception
    {
        return facilityContact;
    }

    @Override
    public FacilityContact marshal(final FacilityContact facilityContact) throws Exception
    {
        if(facilityContact.getContact() == null || facilityContact.getContact().size() == 0)
        {
            return null;
        }
        return facilityContact;
    }

}
