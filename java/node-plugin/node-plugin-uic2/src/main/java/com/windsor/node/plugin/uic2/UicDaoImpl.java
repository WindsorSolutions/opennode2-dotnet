package com.windsor.node.plugin.uic2;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.uic2.domain.UICDataType;

public class UicDaoImpl implements UicDao {

    private EntityManager entityManager;

    public UicDaoImpl(EntityManager entityManger) {
        this.entityManager = entityManger;
    }

    @Override
    public UICDataType findByOrgId(String orgId) {
        return entityManager
                .createQuery("select org from com.windsor.node.plugin.uic2.domain.UICDataType org where org.id = :orgId", UICDataType.class)
                .setParameter("orgId", orgId)
                .getSingleResult();
    }

}
