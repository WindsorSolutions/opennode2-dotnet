package com.windsor.node.web.content.partner;

import com.windsor.node.domain.entity.Partner;
import com.windsor.node.domain.entity.PartnerVersion;
import com.windsor.node.domain.search.PartnerSearchCriteria;
import com.windsor.node.domain.search.PartnerSorts;
import com.windsor.node.service.PartnerService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.button.TestButton;
import com.windsor.node.web.component.select2.PartnerVersionChoiceProvider;
import com.windsor.node.web.model.lazy.PartnerModels;
import com.windsor.node.web.model.lazy.PartnerSearchCriteriaModels;
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
 * Provides a data table of Partner instances.
 */
public class PartnerDataTable extends AbstractBasePanel<PartnerSearchCriteria> {

    @SpringBean
    private PartnerService service;

    private WindsorModalWindowPanel modalPanel;

    public PartnerDataTable(String cid, IModel<PartnerSearchCriteria> model) {
        super(cid, model);

        modalPanel = new NodeModalWindowPanel("modal");
        add(modalPanel);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service, model, PartnerSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true)));
    }

    private List<IColumn<Partner, PartnerSorts>> newColumns() {
        return Arrays.asList(
                new TextFilteredLazyColumn<Partner, PartnerSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        PartnerModels.NAME,
                        PartnerSorts.NAME,
                        PartnerSearchCriteriaModels.NAME),
                new TextFilteredLazyColumn<Partner, PartnerSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_URL),
                        PartnerModels.URL,
                        PartnerSorts.URL,
                        PartnerSearchCriteriaModels.URL),
                new Select2SingleChoiceFilteredLazyColumn<Partner, PartnerSorts, String, PartnerVersion>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_VERSION),
                        PartnerSorts.VERSION,
                        PartnerModels.VERSION,
                        new PartnerVersionChoiceProvider(),
                        (d -> Model.of(d.getObject().getVersion().getDescription()))),
                new ButtonsColumn<Partner, PartnerSorts>((id, m) -> Stream.of(new TestButton(id), new EditButton(id),
                        new ConfirmationButton(id, modalPanel, Icons.ICON_DELETE, GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_PARTNER),
                                bid -> new DeleteButton(bid, Model.of("Yes"), Icons.ICON_SELECT,
                                        f -> m.getObject()).setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS))
        );
    }

}
