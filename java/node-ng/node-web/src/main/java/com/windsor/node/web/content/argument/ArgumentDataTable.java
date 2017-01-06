package com.windsor.node.web.content.argument;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Argument;
import com.windsor.node.domain.search.ArgumentSearchCriteria;
import com.windsor.node.domain.search.ArgumentSorts;
import com.windsor.node.service.ArgumentService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.ArgumentModels;
import com.windsor.node.web.model.lazy.ArgumentSearchCriteriaModels;
import com.windsor.stack.web.wicket.app.Icons;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ButtonsColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredMultilineLazyColumn;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ConfirmationButton;
import com.windsor.stack.web.wicket.markup.html.form.button.DeleteButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a data table of Argument instances.
 */
public class ArgumentDataTable extends AbstractBasePanel<ArgumentSearchCriteria> {

    @SpringBean
    private ArgumentService service;

    private WindsorModalWindowPanel modalPanel;

    public ArgumentDataTable(String cid, IModel<ArgumentSearchCriteria> model) {
        super(cid, model);

        modalPanel = new WindsorModalWindowPanel("modal");
        add(modalPanel);

        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service, model, ArgumentSorts.NAME), 25L,
                new WindsorDataTableConfiguration().filteringToolbarVisible(true)));
    }

    private List<IColumn<Argument, ArgumentSorts>> newColumns() {
        return Arrays.asList(
                new TextFilteredLazyColumn<Argument, ArgumentSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        ArgumentModels.NAME,
                        ArgumentSorts.NAME,
                        ArgumentSearchCriteriaModels.NAME),
                new TextFilteredLazyColumn<Argument, ArgumentSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_VALUE),
                        ArgumentModels.VALUE,
                        ArgumentSorts.VALUE,
                        ArgumentSearchCriteriaModels.VALUE),
                new TextFilteredMultilineLazyColumn<Argument, ArgumentSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DESCRIPTION),
                        ArgumentModels.DESCRIPTION,
                        ArgumentSorts.DESCRIPTION,
                        ArgumentSearchCriteriaModels.DESCRIPTION),
                new ButtonsColumn<Argument, ArgumentSorts>((id, m) -> Stream.of(new EditButton(id),
                        new ConfirmationButton(id, modalPanel, Icons.ICON_DELETE, GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_ARGUMENT),
                                bid -> new DeleteButton(bid, Model.of("Yes"), Icons.ICON_SELECT,
                                        f -> m.getObject()).setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));
    }

}
