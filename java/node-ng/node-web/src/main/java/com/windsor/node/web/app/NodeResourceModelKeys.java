package com.windsor.node.web.app;

import com.windsor.stack.domain.IIdentifiable;

/**
 * Provides resource model keys for the application.
 */
public enum NodeResourceModelKeys implements IIdentifiable<String> {

    APP_NAME_LABEL("application.name"),

    LABEL_ACCOUNT("label.account"),
    LABEL_ACTIONS("label.actions"),
    LABEL_ACTIVE("label.active"),
    LABEL_ACTIVITY("label.activity"),
    LABEL_ADVANCED_SEARCH("label.advanced_search"),
    LABEL_AFFILIATION("label.affiliation"),
    LABEL_ASSOCIATE_EXISTING_NAAS_USER("label.associate_existing_naas_user"),
    LABEL_CHANGE_PASSWORD("label.change_password"),
    LABEL_CONFIRM("label.confirm"),
    LABEL_CONNECTION("label.connection"),
    LABEL_CONTACT("label.contact"),
    LABEL_CONTENT("label.content"),
    LABEL_DATA_SOURCE("label.dataSource"),
    LABEL_DATE("label.date"),
    LABEL_DESCRIPTION("label.description"),
    LABEL_DETAILS("label.details"),
    LABEL_DOWNLOAD("label.download"),
    LABEL_DOWNLOAD_DOCUMENTS("label.download_documents"),
    LABEL_EDIT("label.edit"),
    LABEL_EDIT_NOTIFICATIONS("label.edit_notifications"),
    LABEL_EDITABLE("label.editable"),
    LABEL_EMAIL("label.email"),
    LABEL_ENABLED("label.enabled"),
    LABEL_ERROR("label.error"),
    LABEL_EXCHANGE("label.exchange"),
    LABEL_EXECUTE("label.execute"),
    LABEL_HELP("label.help"),
    LABEL_HOME("label.home"),
    LABEL_IMPLEMENTOR("label.implementor"),
    LABEL_IP_ADDRESS("label.ip_address"),
    LABEL_NAME("label.name"),
    LABEL_NEW_ACCOUNT("label.new_account"),
    LABEL_NEW_PASSWORD("label.new_password"),
    LABEL_NEW_USER("label.new_user"),
    LABEL_NO("label.no"),
    LABEL_NOTIFICATIONS("label.notifications"),
    LABEL_NOTIFY("label.notify"),
    LABEL_OLD_PASSWORD("label.old_password"),
    LABEL_OPERATION("label.operation"),
    LABEL_PASSWORD("label.password"),
    LABEL_PROTECTED("label.protected"),
    LABEL_PROVIDER("label.provider"),
    LABEL_QUERY("label.query"),
    LABEL_REFRESH_STATUS("label.refresh_status"),
    LABEL_REMOVE_USER("label.remove_user"),
    LABEL_ROLE("label.role"),
    LABEL_SCHEDULE("label.schedule"),
    LABEL_SEARCH("label.search"),
    LABEL_SECURE("label.secure"),
    LABEL_SERVICE("label.service"),
    LABEL_SIGNIN("label.signin"),
    LABEL_SIGNOUT("label.signout"),
    LABEL_SOLICIT("label.solicit"),
    LABEL_SUBMIT("label.submit"),
    LABEL_SUPPORT("label.support"),
    LABEL_TARGET_EXCHANGE_NAME("label.targetExchangeName"),
    LABEL_TEST("label.test"),
    LABEL_TRANSACTION("label.transaction"),
    LABEL_TYPE("label.type"),
    LABEL_VALUE("label.value"),
    LABEL_VIEW_ACTIVITY_ENTRY("label.view_activity_entry"),
    LABEL_VERSION("label.version"),
    LABEL_WELCOME("label.welcome"),
    LABEL_URL("label.url"),
    LABEL_YES("label.yes"),

    LABEL_ACCOUNT_HOME_PAGE("label.account.home"),
    LABEL_PROTECTED_TEXT("label.protected.text"),

    LABEL_PLUGIN_NAME("label.plugin.name"),
    LABEL_PLUGIN_DESCRIPTION("label.plugin.description"),
    LABEL_PLUGIN_FULL_NAME("label.plugin.fullName"),
    LABEL_PLUGIN_VERSION("label.plugin.version"),
    LABEL_PLUGIN_HELP("label.plugin.help"),
    LABEL_PLUGIN_INFORMATION("label.plugin.information"),
    LABEL_PLUGIN_UPLOAD("label.plugin.upload"),

    LABEL_SERVICE_SECURE("label.service.secure"),
    LABEL_SERVUCE_ACTIVE("label.service.active"),
    LABEL_SERVICE_USE_GLOBAL("label.service.useGlobal"),

    LABEL_SCHEDULE_LAST_EXECUTION("label.schedule.lastExecution"),
    LABEL_SCHEDULE_NEXT_EXECUTION("label.schedule.nextExecution"),
    LABEL_SCHEDULE_SERVICE_SOURCE("label.schedule.serviceSource"),
    LABEL_SCHEDULE_START("label.schedule.start"),
    LABEL_SCHEDULE_END("label.schedule.end"),
    LABEL_SCHEDULE_FREQUENCY("label.schedule.frequence"),
    LABEL_SCHEDULE_INTERVAL("label.schedule.interval"),
    LABEL_SCHEDULE_DATA_SOURCE("label.schedule.dataSource"),
    LABEL_SCHEDULE_SOURCE_PATH("label.schedule.source.path"),
    LABEL_SCHEDULE_TARGET("label.schedule.target"),

    LABEL_BUTTON_ADD_ARGUMENT("label.button.add.argument"),
    LABEL_BUTTON_ADD_DATA_SOURCE("label.button.add.data_source"),
    LABEL_BUTTON_ADD_PARTNER("label.button.add.partner"),
    LABEL_BUTTON_ADD_EXCHANGE("label.button.add.exchange"),
    LABEL_BUTTON_ADD_SCHEDULE("label.button.add.schedule"),
    LABEL_BUTTON_RUN("label.button.run"),
    LABEL_BUTTON_STOP("label.button.stop"),

    LABEL_CONFIRM_DELETE_ACCOUNT("label.confirm.delete.account"),
    LABEL_CONFIRM_DELETE_ARGUMENT("label.confirm.delete.argument"),
    LABEL_CONFIRM_DELETE_DATA_SOURCE("label.confirm.delete.dataSource"),
    LABEL_CONFIRM_DELETE_PARTNER("label.confirm.delete.partner"),
    LABEL_CONFIRM_DELETE_EXCHANGE("label.confirm.delete.exchange"),
    LABEL_CONFIRM_DELETE_SERVICE("label.confirm.delete.service"),
    LABEL_CONFIRM_DELETE_SCHEDULE("label.confirm.delete.schedule"),
    LABEL_CONFIRM_STOP_SCHEDULE("label.confirm.stop.schedule"),
    LABEL_CONFIRM_RUN_SERVICE("label.confirm.run.service"),

    TITLE_ADD_ACCOUNT("title.add.account"),
    TITLE_EDIT_ACCOUNT("title.edit.account"),
    TITLE_EDIT_ACCOUNT_NOTIFICATIONS("title.edit.account_notifications"),

    TITLE_ADD_ARGUMENT("title.add.argument"),
    TITLE_EDIT_ARGUMENT("title.edit.argument"),

    TITLE_ADD_DATA_SOURCE("title.add.dataSource"),
    TITLE_EDIT_DATA_SOURCE("title.edit.dataSource"),

    TITLE_ADD_EXCHANGE("title.add.exchange"),
    TITLE_EDIT_EXCHANGE("title.edit.exchange"),

    TITLE_ADD_PARTNER("title.add.partner"),
    TITLE_EDIT_PARTNER("title.edit.partner"),

    TITLE_ADD_SERVICE("title.add.service"),
    TITLE_EDIT_SERVICE("title.edit.service"),

    TITLE_ADD_SCHEDULE("title.add.schedule"),
    TITLE_EDIT_SCHEDULE("title.edit.schedule"),
    TITLE_EDIT_SCHEDUEL_DATA_SOURCE("title.edit.schedule.dataSource"),

    TITLE_PAGE_SUBHEAD("title.page.subhead"),
    TITLE_PAGE_SUBHEAD_NO_SEARCH("title.page.subheadNoSearch"),
    TITLE_PAGE_SUBHEAD_HOME("title.page.subhead.home"),
    TITLE_PAGE_ACCOUNTS("title.page.accounts"),
    TITLE_PAGE_ACTIVITY("title.page.activity"),
    TITLE_PAGE_ARGUMENT("title.page.argument"),
    TITLE_PAGE_DATA_SOURCE("title.page.dataSource"),
    TITLE_PAGE_EXCHANGES("title.page.exchanges"),
    TITLE_PAGE_PARTNER("title.page.partner"),
    TITLE_PAGE_SCHEDULE("title.page.schedule"),
    TITLE_PAGE_HOME("title.page.home"),
    TITLE_PAGE_PROFILE("title.page.profile"),

    LABEL_PAGE_CONFIGURATION("label.page.configuration"),
    LABEL_PAGE_SECURITY("label.page.security"),
    LABEL_PAGE_EXCHANGE("label.page.exchange"),
    LABEL_PAGE_SCHEDULE("label.page.schedule"),
    LABEL_PAGE_ACTIVITY("label.page.activity"),
    LABEL_PAGE_PROFILE("label.page.profile"),
    LABEL_PAGE_CONFIGURATION_ARGUMENTS("label.page.configuration.arguments"),
    LABEL_PAGE_CONFIGURATION_SOURCES("label.page.configuration.sources"),
    LABEL_PAGE_CONFIGURATION_PARTNERS("label.page.configuration.partners"),
    LABEL_PAGE_SECURITY_ACCOUNTS("label.page.security.accounts"),
    LABEL_PAGE_SECURITY_POLICIES("label.page.security.policies"),
    LABEL_PAGE_SECURITY_REQUESTS("label.page.security.requests"),

    HELP_ACCOUNT("help.account"),
    HELP_ACTIVITY("help.activity"),
    HELP_ARGUMENT("help.argument"),
    HELP_DATA_SOURCE("help.dataSource"),
    HELP_EXCHANGE("help.exchange"),
    HELP_HOME("help.home"),
    HELP_PARTNER("help.partner"),
    HELP_PROFILE("help.profile"),
    HELP_SCHEDULE("help.schedule");

    private String id;

    NodeResourceModelKeys(String id) {
        this.id = id;
    }

    @Override
    public String getId() {
        return id;
    }
}
