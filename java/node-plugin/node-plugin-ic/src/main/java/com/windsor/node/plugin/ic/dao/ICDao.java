package com.windsor.node.plugin.ic.dao;

import java.util.List;
import java.util.Map;

public interface ICDao
{
    List<String> findIntrumentIdsByCriteria(Map<String, Object> params);
    List<String> findAffiliateIdsByCriteria(Map<String, Object> params);
    List<String> findLocationIdsByCriteria(Map<String, Object> params);
}
