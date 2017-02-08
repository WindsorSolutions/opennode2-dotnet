package com.windsor.node.web.content.datasource;

import com.windsor.node.domain.entity.DataSource;
import com.windsor.node.domain.entity.DataSourceProvider;
import com.windsor.node.domain.search.DataSourceSearchCriteria;
import com.windsor.node.domain.search.DataSourceSorts;
import com.windsor.node.service.DataSourceService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.button.TestButton;
import com.windsor.node.web.component.column.HardBreakingTextFilteredMultilineLazyColumn;
import com.windsor.node.web.component.select2.DataSourceProviderChoiceProvider;
import com.windsor.node.web.model.lazy.DataSourceModels;
import com.windsor.node.web.model.lazy.DataSourceSearchCriteriaModels;
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
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides a data table of DataSource instances.
 */
public class DataSourceDataTable extends AbstractBasePanel<DataSourceSearchCriteria> {

    @SpringBean
    private DataSourceService service;

    private WindsorModalWindowPanel modalPanel;

    public DataSourceDataTable(String cid, IModel<DataSourceSearchCriteria> model) {
        super(cid, model);

        modalPanel = new NodeModalWindowPanel("modal");
        add(modalPanel);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service, model, DataSourceSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true)));
    }

    private List<IColumn<DataSource, DataSourceSorts>> newColumns() {
        return Arrays.asList(
                new TextFilteredLazyColumn<DataSource, DataSourceSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        DataSourceModels.NAME,
                        DataSourceSorts.NAME,
                        DataSourceSearchCriteriaModels.NAME),
                new Select2SingleChoiceFilteredLazyColumn<DataSource, DataSourceSorts, String, DataSourceProvider>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_PROVIDER),
                        DataSourceSorts.PROVIDER,
                        DataSourceModels.PROVIDER,
                        new DataSourceProviderChoiceProvider(),
                        (d -> Model.of(d.getObject().getProvider().getDescription()))),
                new HardBreakingTextFilteredMultilineLazyColumn<DataSource, DataSourceSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONNECTION),
                        DataSourceModels.CONNECTION,
                        DataSourceSorts.CONNECTION,
                        DataSourceSearchCriteriaModels.CONNECTION),
                new ButtonsColumn<DataSource, DataSourceSorts>((id, m) -> Stream.of(new TestButton(id), new EditButton(id),
                        new ConfirmationButton(id, modalPanel, Icons.ICON_DELETE, GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_DATA_SOURCE),
                                bid -> new DeleteButton(bid, Model.of("Yes"), Icons.ICON_SELECT,
                                        f -> m.getObject()).setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS))
        );
    }

}
