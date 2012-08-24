package com.windsor.node.plugin.icisnpdes40.adapter;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

import com.windsor.node.plugin.icisnpdes40.generated.LimitSetData;


public class Test {

	public static void main(final String[] args) {
		final EntityManagerFactory emf = Persistence.createEntityManagerFactory("pu");
		final EntityManager em = emf.createEntityManager();
		//final List<LimitSetData> list = em.createQuery("select ls from LimitSetData ls").getResultList();
		
		
		final List<com.windsor.node.plugin.icisnpdes40.generated.LimitSet> list = em.createQuery("select ls from LimitSet ls").getResultList();
		
		
		System.out.println("size=" + list.size());
	}

}
