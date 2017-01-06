package com.windsor.node.web.content.exchange;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.YesNoModel;
import com.windsor.node.web.model.lazy.ExchangeModels;
import com.windsor.node.web.model.lazy.ExchangeSearchCriteriaModels;
import com.windsor.stack.web.wicket.app.Icons;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ButtonsColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.Select2SingleChoiceFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ConfirmationButton;
import com.windsor.stack.web.wicket.markup.html.form.button.DeleteButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.markup.html.form.select2.YesNoChoiceProvider;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a data table of Exchange instances.
 */
public class ExchangeDataTable extends AbstractBasePanel<ExchangeSearchCriteria> {

    @SpringBean
    private ExchangeService service;

    private WindsorModalWindowPanel modalPanel;

    public ExchangeDataTable(String cid, IModel<ExchangeSearchCriteria> model) {
        super(cid, model);

        modalPanel = new WindsorModalWindowPanel("modal");
        add(modalPanel);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service, model, ExchangeSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true)));
    }

    private List<IColumn<Exchange, ExchangeSorts>> newColumns() {
        return Arrays.asList(
                new TextFilteredLazyColumn<Exchange, ExchangeSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        ExchangeModels.NAME,
                        ExchangeSorts.NAME,
                        ExchangeSearchCriteriaModels.NAME),
                new TextFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONTACT),
                        ExchangeModels.NAAS_ACCOUNT,
                        ExchangeSorts.CONTACT_NAME,
                        ExchangeSearchCriteriaModels.CONTACT_NAME),
                new Select2SingleChoiceFilteredLazyColumn<Exchange, ExchangeSorts, String, Boolean>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SECURE),
                        ExchangeSorts.SECURE,
                        ExchangeSearchCriteriaModels.SECURE,
                        new YesNoChoiceProvider())
                        .setDataModelFunction(a -> new YesNoModel(ExchangeModels.bindSecure(a))),
                new TextFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DESCRIPTION),
                        ExchangeModels.DESCRIPTION,
                        ExchangeSorts.DESCRIPTION,
                        ExchangeSearchCriteriaModels.DESCRIPTION),
                new TextFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_URL),
                        ExchangeModels.URL,
                        ExchangeSorts.URL,
                        ExchangeSearchCriteriaModels.URL),
                new ButtonsColumn<Exchange, ExchangeSorts>((id, m) -> Stream.of(new EditButton(id),
                        new ConfirmationButton(id, modalPanel, Icons.ICON_DELETE, GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_EXCHANGE),
                                bid -> new DeleteButton(bid, Model.of("Yes"), Icons.ICON_SELECT,
                                        f -> m.getObject()).setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));
    }
    
}
