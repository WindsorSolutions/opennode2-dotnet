package com.windsor.node.domain.search;

import java.io.Serializable;
import java.util.Arrays;
import java.util.Collection;

import com.windsor.node.domain.TrueCriteria;
import com.windsor.node.domain.entity.SystemRoleType;
import com.windsor.stack.domain.search.BooleanCriteriaField;
import com.windsor.stack.domain.search.Criteria;
import com.windsor.stack.domain.search.CriteriaOperator;
import com.windsor.stack.domain.util.ISerializableConsumer;

/**
 * Provides a data object encapsulating Account related search criteria.
 */
public class AccountSearchCriteria implements Serializable {

    public static final String NAME = "name";
    public static final String ACTIVE = "active";
    public static final String DELETED = "deleted";
    public static final String DEMO_USER = "demoUser";
    public static final String SYSTEM_ROLE_TYPES = "systemRoleTypes";
    public static final String AFFILIATION = "affiliation";
    public static final String LOCAL_ONLY = "localOnly";
    public static final String NON_DELETED = "nonDeleted";

    public static final ISerializableConsumer<AccountSearchCriteria> ACTIVE_LOCAL_ACCOUNT_CRITERIA =
            criteria -> criteria
                .localAccountsOnly()
                .nonDeletedOnly()
                .active(true);


    @Criteria(name = NAME, operator = CriteriaOperator.CONTAINS_CI)
    private String name;

    @Criteria(name = ACTIVE)
    private BooleanCriteriaField active = new BooleanCriteriaField();

    @Criteria(name = DELETED)
    private BooleanCriteriaField deleted = new BooleanCriteriaField();

    @Criteria(name = DEMO_USER)
    private BooleanCriteriaField demoUser = new BooleanCriteriaField();

    @Criteria(name = SYSTEM_ROLE_TYPES, operator = CriteriaOperator.IN)
    private Collection<SystemRoleType> systemRoleTypes;

    @Criteria(name = AFFILIATION, operator = CriteriaOperator.CONTAINS_CI)
    private String affiliation;

    @Criteria(name = LOCAL_ONLY)
    private TrueCriteria localAccountsOnly;

    @Criteria(name = LOCAL_ONLY)
    private TrueCriteria nonDeletedOnly;

    private ISerializableConsumer<AccountSearchCriteria> resetConsumer;

    public AccountSearchCriteria() {
        this(null);
    }

    public AccountSearchCriteria(ISerializableConsumer<AccountSearchCriteria> resetConsumer) {
        super();
        this.resetConsumer = resetConsumer;
        reset();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public AccountSearchCriteria name(String name) {
        setName(name);
        return this;
    }

    public BooleanCriteriaField getActive() {
        return active;
    }

    public void setActive(BooleanCriteriaField active) {
        this.active = active;
    }

    public AccountSearchCriteria active(boolean active) {
        this.active.setValue(active);
        return this;
    }

    public BooleanCriteriaField getDeleted() {
        return deleted;
    }

    public void setDeleted(BooleanCriteriaField deleted) {
        this.deleted = deleted;
    }

    public BooleanCriteriaField getDemoUser() {
        return demoUser;
    }

    public void setDemoUser(BooleanCriteriaField demoUser) {
        this.demoUser = demoUser;
    }

    public Collection<SystemRoleType> getSystemRoleTypes() {
        return systemRoleTypes;
    }

    public void setSystemRoleTypes(Collection<SystemRoleType> systemRoleTypes) {
        this.systemRoleTypes = systemRoleTypes;
    }

    public AccountSearchCriteria systemRoleTypes(Collection<SystemRoleType> systemRoleTypes) {
        setSystemRoleTypes(systemRoleTypes);
        return this;
    }

    public String getAffiliation() {
        return affiliation;
    }

    public void setAffiliation(String affiliation) {
        this.affiliation = affiliation;
    }

    public SystemRoleType getSystemRoleType() {
        return systemRoleTypes == null || systemRoleTypes.isEmpty() ? null : systemRoleTypes.iterator().next();
    }

    public void setSystemRoleType(SystemRoleType type) {
        this.systemRoleTypes = type == null ? null : Arrays.asList(type);
    }

    public AccountSearchCriteria withExchangeRoles() {
        this.systemRoleTypes = Arrays.asList(SystemRoleType.Admin, SystemRoleType.Program, SystemRoleType.Anonymous);
        return this;
    }

    public TrueCriteria getLocalAccountsOnly() {
        return localAccountsOnly;
    }

    public void setLocalAccountsOnly(TrueCriteria localAccountsOnly) {
        this.localAccountsOnly = localAccountsOnly;
    }

    public AccountSearchCriteria localAccountsOnly() {
        this.localAccountsOnly.setValue(true);
        return this;
    }

    public TrueCriteria getNonDeletedOnly() {
        return nonDeletedOnly;
    }

    public void setNonDeletedOnly(TrueCriteria nonDeletedOnly) {
        this.nonDeletedOnly = nonDeletedOnly;
    }

    public AccountSearchCriteria nonDeletedOnly() {
        this.nonDeletedOnly.setValue(true);
        return this;
    }

    public void reset() {
        setName(null);
        setActive(new BooleanCriteriaField());
        setDeleted(new BooleanCriteriaField());
        setDemoUser(new BooleanCriteriaField());
        setSystemRoleTypes(null);
        setAffiliation(null);
        setLocalAccountsOnly(new TrueCriteria());
        setNonDeletedOnly(new TrueCriteria());
        if (resetConsumer != null) {
            resetConsumer.accept(this);
        }
    }

}
