package com.windsor.node.plugin.icisair.domain.adapters;

import javax.xml.bind.annotation.adapters.XmlAdapter;

import com.windsor.node.plugin.icisair.domain.generated.FacilityAddress;

/**
 * {@link XmlAdapter} for pruning empty {@link FacilityAddressAdapter} objects.
 * 
 */
public class FacilityAddressAdapter extends XmlAdapter<FacilityAddress, FacilityAddress>
{

    @Override
    public FacilityAddress unmarshal(final FacilityAddress facilityAddress) throws Exception
    {
        return facilityAddress;
    }

    @Override
    public FacilityAddress marshal(final FacilityAddress facilityAddress) throws Exception
    {
        if(facilityAddress.getAddress() == null || facilityAddress.getAddress().size() == 0)
        {
            return null;
        }
        return facilityAddress;
    }

}
