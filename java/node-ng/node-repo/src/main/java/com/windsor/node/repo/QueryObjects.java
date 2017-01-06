package com.windsor.node.repo;

import com.windsor.node.domain.entity.QAccount;
import com.windsor.node.domain.entity.QAccountPolicy;
import com.windsor.node.domain.entity.QActivity;
import com.windsor.node.domain.entity.QActivityDetail;
import com.windsor.node.domain.entity.QArgument;
import com.windsor.node.domain.entity.QDataSource;
import com.windsor.node.domain.entity.QDocument;
import com.windsor.node.domain.entity.QExchange;
import com.windsor.node.domain.entity.QExchangeService;
import com.windsor.node.domain.entity.QPartner;
import com.windsor.node.domain.entity.QPlugin;
import com.windsor.node.domain.entity.QSchedule;
import com.windsor.node.domain.entity.QScheduleArgument;
import com.windsor.node.domain.entity.QServiceArgument;
import com.windsor.node.domain.entity.QServiceConnection;
import com.windsor.node.domain.entity.QTransaction;

/**
 * Provides aliases to the QueryDSL query objects.
 */
public class QueryObjects {

    public static final QAccount ACCOUNT = QAccount.account;
    public static final QAccountPolicy ACCOUNT_POLICY = QAccountPolicy.accountPolicy;
    public static final QActivity ACTIVITY = QActivity.activity;
    public static final QActivityDetail ACTIVITY_DETAIL = QActivityDetail.activityDetail;
    public static final QArgument ARGUMENT = QArgument.argument;
    public static final QDataSource DATA_SOURCE = QDataSource.dataSource;
    public static final QDocument DOCUMENT = QDocument.document;
    public static final QExchange EXCHANGE = QExchange.exchange;
    public static final QExchangeService EXCHANGE_SERVICE = QExchangeService.exchangeService;
    public static final QPartner PARTNER = QPartner.partner;
    public static final QPlugin PLUGIN = QPlugin.plugin;
    public static final QTransaction TRANSACTION = QTransaction.transaction;
    public static final QServiceArgument SERVICE_ARGUMENT = QServiceArgument.serviceArgument;
    public static final QSchedule SCHEDULE = QSchedule.schedule;
    public static final QScheduleArgument SCHEDULE_ARGUMENT = QScheduleArgument.scheduleArgument;
    public static final QServiceConnection SERVICE_CONNECTION = QServiceConnection.serviceConnection;

}
