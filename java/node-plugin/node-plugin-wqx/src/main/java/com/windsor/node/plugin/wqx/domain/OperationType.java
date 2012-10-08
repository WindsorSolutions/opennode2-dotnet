package com.windsor.node.plugin.wqx.domain;

public enum OperationType {

    UpdateInsert("Update-Insert"), Delete("Delete");

    private final String operation;

    OperationType(String operation) {
        this.operation = operation;
    }

    public String operation() {
        return this.operation;
    }

    @Override
    public String toString() {
        return operation();
    }
}
