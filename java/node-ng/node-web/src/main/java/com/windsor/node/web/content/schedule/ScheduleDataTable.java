package com.windsor.node.web.content.schedule;

import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.ScheduleExecuteStatus;
import com.windsor.node.domain.search.ScheduleSearchCriteria;
import com.windsor.node.domain.search.ScheduleSorts;
import com.windsor.node.service.ActivityService;
import com.windsor.node.service.ScheduleService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.NodeModalWindowPanel;
import com.windsor.node.web.component.StyledIcon;
import com.windsor.node.web.component.button.RunButton;
import com.windsor.node.web.component.column.IconInfoColumn;
import com.windsor.node.web.event.RunEvent;
import com.windsor.node.web.model.lazy.ScheduleModels;
import com.windsor.node.web.model.lazy.ScheduleSearchCrtieriaModels;
import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.app.Icons;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ButtonsColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.LocalDateTimeRangeFilterColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.modal.WindsorModalWindowPanel;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ConfirmationButton;
import com.windsor.stack.web.wicket.markup.html.form.button.DeleteButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.GenericModels;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.GlyphIconType;
import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.AjaxSelfUpdatingTimerBehavior;
import org.apache.wicket.behavior.AttributeAppender;
import org.apache.wicket.behavior.Behavior;
import org.apache.wicket.extensions.markup.html.repeater.data.grid.ICellPopulator;
import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.repeater.Item;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.util.time.Duration;
import org.wicketstuff.event.annotation.OnEvent;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

/**
 * Provides a data table of Schedule instances for the given Exchange.
 */
public class ScheduleDataTable extends AbstractBasePanel<Exchange> {

    @SpringBean
    private ScheduleService service;

    @SpringBean
    private ActivityService activityService;

    private WindsorModalWindowPanel modalPanel;
    private Component dataTable;

    public ScheduleDataTable(String cid, IModel<Exchange> model) {
        super(cid, model);
        add(modalPanel = new NodeModalWindowPanel("modal"));
        add(dataTable = new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service,
                        new LDModel<>(() -> new ScheduleSearchCriteria().exchange(model.getObject())),
                        ScheduleSorts.NAME),
                25L,
                new WindsorDataTableConfiguration()
                        .filteringToolbarVisible(false)
                        .bottomToolbarVisibleOnlyIfNecessary(true)));
        dataTable.setOutputMarkupId(true);
    }

    private List<IColumn<Schedule, ScheduleSorts>> newColumns() {
        return Arrays.asList(
                new IconInfoColumn<Schedule, ScheduleSorts, Schedule>(
                        Model.of(""),
                        null,
                        new ScheduleExecuteStatusIconFunction()) {
                    @Override
                    public void populateItem(Item<ICellPopulator<Schedule>> item, String componentId, IModel<Schedule> rowModel) {
                        item.add(new StyledIcon(componentId,
                                new LDModel<>(() ->
                                        new ScheduleExecuteStatusIconFunction().apply(rowModel.getObject()))));
                        item.add(new AttributeAppender("class",
                                Model.of(new ScheduleExecuteStatusCssFunction().apply(rowModel.getObject())), ""));

                        item.add(new Behavior() {
                            @Override
                            public void onConfigure(Component component) {
                                super.onConfigure(component);

                                if(rowModel.getObject().getRunNow() ||
                                        rowModel.getObject().getScheduleExecuteStatus() == ScheduleExecuteStatus.Running) {
                                    item.setOutputMarkupId(true);
                                    item.add(new AjaxSelfUpdatingTimerBehavior(Duration.seconds(30)) {
                                        @Override
                                        protected void onPostProcessTarget(AjaxRequestTarget target) {
                                            target.add(item);
                                            target.add(dataTable);
                                        }
                                    });
                                }
                            }
                        });
                    }
                },
                new TextFilteredLazyColumn<Schedule, ScheduleSorts, String, String>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SERVICE),
                        ScheduleModels.NAME,
                        ScheduleSorts.NAME,
                        ScheduleSearchCrtieriaModels.NAME) {
                    @Override
                    public void populateItem(Item<ICellPopulator<Schedule>> item, String componentId, IModel<Schedule> rowModel) {
                        Component label = new Label(componentId, ScheduleModels.bindName(rowModel));
                        label.add(new AttributeAppender("style", "width: 200px;"));
                        item.add(label);
                    }
                },
                new LocalDateTimeRangeFilterColumn<Schedule, ScheduleSorts>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_LAST_EXECUTION),
                        ScheduleModels.LAST_EXECUTION,
                        ScheduleSorts.LAST_EXECUTION,
                        null) {

                    @Override
                    public String getCssClass() {
                        return "nobreak";
                    }

                    @Override
                    public void populateItem(Item<ICellPopulator<Schedule>> item, String componentId, IModel<Schedule> rowModel) {
                        item.add(new ScheduleRunPanel(componentId, rowModel));
                    }
                },
                new LocalDateTimeRangeFilterColumn<Schedule, ScheduleSorts>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SCHEDULE_NEXT_EXECUTION),
                        ScheduleModels.NEXT_START,
                        ScheduleSorts.NEXT_START,
                        null) {
                    @Override
                    public String getCssClass() {
                        return "nobreak";
                    }
                },
                new ButtonsColumn<Schedule, ScheduleSorts>((id, m) -> Stream.of(
                        new RunButton(id),
                        new EditButton(id),
                        new ConfirmationButton(id,
                                modalPanel,
                                Icons.ICON_DELETE,
                                GenericModels.MODEL_EMPTY,
                                new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONFIRM_DELETE_SCHEDULE),
                                bid -> new DeleteButton(bid,
                                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_YES),
                                        Icons.ICON_SELECT,
                                        f -> m.getObject())
                                    .setDefaultFormProcessing(false))))
                        .setAtLabelModel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ACTIONS)));
    }

    @OnEvent(types = Schedule.class)
    public void handleRunEvent(final RunEvent<Schedule> event) {
        event.getTarget().add(this);
    }

    private static final class ScheduleExecuteStatusIconFunction implements ISerializableFunction<Schedule, IconInfo> {

        @Override
        public IconInfo apply(Schedule schedule) {

            if(schedule.getRunNow()) {
                return new IconInfo(GlyphIconType.cog, IconInfo.IconStyle.INFO);
            }

            IconInfo info = null;
            switch (schedule.getScheduleExecuteStatus()) {

                case Running:
                    info = new IconInfo(GlyphIconType.cog, IconInfo.IconStyle.INFO);
                    break;
                case Success:
                    info = new IconInfo(GlyphIconType.cog, IconInfo.IconStyle.SUCCESS);
                    break;
                case Failure:
                    info = new IconInfo(GlyphIconType.exclamationsign, IconInfo.IconStyle.WARNING);
                    break;
                default:
                    break;
            }
            return info;
        }
    }

    private static final class ScheduleExecuteStatusCssFunction implements ISerializableFunction<Schedule, String> {

        @Override
        public String apply(Schedule schedule) {
            if(schedule.getRunNow()) {
                return "glyphicon-spin";
            }

            String cssClass = "";

            switch (schedule.getScheduleExecuteStatus()) {
                case Running:
                    cssClass = "glyphicon-spin ";
                    break;
                case Success:
                    break;
                case Failure:
                    break;
                default:
                    break;
            }
            return cssClass;
        }
    }

}
