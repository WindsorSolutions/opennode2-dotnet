package com.windsor.node.plugin.facid3.domain;

import javax.xml.bind.annotation.adapters.XmlAdapter;

public class StringAdapter extends XmlAdapter<String, String>
{
    @Override
    public String unmarshal(String v) throws Exception
    {
        return v;
    }

    @Override
    public String marshal(String v) throws Exception
    {
        if("".equals(v))
        {
            return null;
        }
        return v;
    }
}
