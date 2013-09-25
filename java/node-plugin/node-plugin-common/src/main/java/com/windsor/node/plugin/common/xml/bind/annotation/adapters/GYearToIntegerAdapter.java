package com.windsor.node.plugin.common.xml.bind.annotation.adapters;

import javax.xml.bind.annotation.adapters.XmlAdapter;
import org.apache.commons.lang3.StringUtils;

public class GYearToIntegerAdapter extends XmlAdapter<String, Integer>
{

    @Override
    public Integer unmarshal(String v) throws Exception
    {
        if(StringUtils.isBlank(v) || !StringUtils.isNumeric(v))
        {
            return null;
        }
        return new Integer(v);
    }

    @Override
    public String marshal(Integer v) throws Exception
    {
        if(v == null)
        {
            return "";
        }
        return v.toString();
    }

}
