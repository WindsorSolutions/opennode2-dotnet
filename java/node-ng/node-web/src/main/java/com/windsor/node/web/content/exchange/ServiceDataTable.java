package com.windsor.node.web.content.exchange;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.ExchangeService;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.node.domain.search.ExchangeServiceSearchCriteria;
import com.windsor.node.domain.search.ExchangeServiceSorts;
import com.windsor.node.service.ExchangeServiceService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.select2.ServiceTypeChoiceProvider;
import com.windsor.node.web.model.YesNoModel;
import com.windsor.node.web.model.lazy.ExchangeServiceModels;
import com.windsor.node.web.model.lazy.ExchangeServiceSearchCriteriaModels;
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
import org.apache.wicket.Component;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.extensions.markup.html.repeater.data.grid.ICellPopulator;
import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.repeater.Item;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides a data table of ExchangeService instances for the given Exchange.
 */
public class ServiceDataTable extends AbstractBasePanel<Exchange> {

    @SpringBean
    private ExchangeServiceService exchangeServiceService;

    private WindsorModalWindowPanel modalPanel;

    public ServiceDataTable(String cid, IModel<Exchange> model) {
        super(cid, model);

        modalPanel = new NodeModalWindowPanel("modal");
        add(modalPanel);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(exchangeServiceService,
                        Model.of(new ExchangeServiceSearchCriteria().exchange(getPanelModelObject())),
                        ExchangeServiceSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(false)
                        .bottomToolbarVisibleOnlyIfNecessary(true)));
    }

    private List<IColumn<ExchangeService, ExchangeServiceSorts>> newColumns() {
        return Arrays.asList(
                new TextFilteredLazyColumn<ExchangeService, ExchangeServiceSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        ExchangeServiceModels.NAME,
                        ExchangeServiceSorts.NAME,
                        ExchangeServiceSearchCriteriaModels.NAME){

                    @Override
                    public void populateItem(Item<ICellPopulator<ExchangeService>> item, String componentId,
                                    IModel<ExchangeService> rowModel) {
                        Component label = new Label(componentId, ExchangeServiceModels.bindName(rowModel));
                        label.add(new AttributeAppender("style", "width: 200px;"));
                        item.add(label);
                    }

                },
                new Select2SingleChoiceFilteredLazyColumn<ExchangeService, ExchangeServiceSorts, String, ServiceType>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_TYPE),
                        ExchangeServiceSorts.TYPE,
                        ExchangeServiceModels.TYPE,
                        new ServiceTypeChoiceProvider(),
                        (d -> Model.of(d.getObject().getType().toString()))),
                new Select2SingleChoiceFilteredLazyColumn<ExchangeService, ExchangeServiceSorts, String, Boolean>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIVE),
                        ExchangeServiceSorts.ACTIVE,
                        ExchangeServiceModels.ACTIVE,
                        new YesNoChoiceProvider())
                        .setDataModelFunction(a -> new YesNoModel(ExchangeServiceModels.bindActive(a))),
                new ButtonsColumn<ExchangeService, ExchangeServiceSorts>((id, m) -> Stream.of(new EditButton(id),
                        new ConfirmationButton(id, modalPanel, Icons.ICON_DELETE, GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_SERVICE),
                                bid -> new DeleteButton(bid, Model.of("Yes"), Icons.ICON_SELECT,
                                        f -> m.getObject()).setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));
    }

}
