package com.windsor.node.plugin.icisair.domain.adapters;

import javax.xml.bind.annotation.adapters.XmlAdapter;

import org.apache.commons.lang3.StringUtils;

import com.windsor.node.plugin.icisair.domain.generated.PortableSourceData;

/**
 * {@link XmlAdapter} for pruning empty {@link PortableSourceDataAdapter} objects.
 * 
 */
public class PortableSourceDataAdapter extends XmlAdapter<PortableSourceData, PortableSourceData>
{

    @Override
    public PortableSourceData unmarshal(final PortableSourceData portableSourceData) throws Exception
    {
        return portableSourceData;
    }

    @Override
    public PortableSourceData marshal(final PortableSourceData portableSourceData) throws Exception
    {
        if((portableSourceData.getPortableSource() == null || portableSourceData.getPortableSource().size() == 0) 
                        && (portableSourceData.getPortableSourceIndicator() == null || StringUtils.isBlank(portableSourceData.getPortableSourceIndicator().value())))
        {
            return null;
        }
        return portableSourceData;
    }

}
