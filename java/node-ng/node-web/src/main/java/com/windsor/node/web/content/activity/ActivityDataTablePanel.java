package com.windsor.node.web.content.activity;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.windsor.node.web.component.StyledIcon;
import com.windsor.stack.web.wicket.markup.html.form.select2.YesNoChoiceProvider;
import com.windsor.stack.web.wicket.model.LDModel;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.GlyphIconType;
import org.apache.commons.lang3.StringUtils;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.extensions.markup.html.repeater.data.grid.ICellPopulator;
import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.extensions.markup.html.repeater.util.SortParam;
import org.apache.wicket.markup.repeater.Item;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.ActivityType;
import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.domain.search.ActivitySorts;
import com.windsor.node.domain.search.ExchangeSearchCriteria;
import com.windsor.node.domain.search.ExchangeSorts;
import com.windsor.node.service.ActivityService;
import com.windsor.node.service.ExchangeService;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.app.NodeWebConstants;
import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.IconInfo.IconStyle;
import com.windsor.node.web.component.column.IconInfoColumn;
import com.windsor.node.web.component.column.Select2SingleChoiceFilteredLazyColumn;
import com.windsor.node.web.component.select2.ActivityTypeProviderChoiceProvider;
import com.windsor.node.web.component.select2.ExchangeChoiceProvider;
import com.windsor.node.web.model.lazy.ActivityModels;
import com.windsor.node.web.model.lazy.ActivitySearchCriteriaModels;
import com.windsor.stack.domain.util.ISerializableFunction;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.LocalDateTimeRangeFilterColumn;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.TextFilteredLazyColumn;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.event.ViewEvent;
import com.windsor.stack.web.wicket.markup.html.link.WindsorAjaxLabelLinkPanel;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

/**
 * Provides a data table of Account instances.
 */
public class ActivityDataTablePanel extends AbstractBasePanel<ActivitySearchCriteria> {

    @SpringBean
    private ActivityService service;

    @SpringBean
    private ExchangeService exchangeService;

    public ActivityDataTablePanel(String cid, IModel<ActivitySearchCriteria> model, long rowsPerPage,
    		boolean includeTypeColumn, WindsorDataTableConfiguration tableConfig) {
        super(cid, model);
        add(new WindsorDataTablePanel<>("table", newColumns(includeTypeColumn),
                new FinderDataProvider<>(service, model, new SortParam<>(ActivitySorts.CREATE_DATE, false)),
                rowsPerPage, tableConfig));
    }

    private List<IColumn<Activity, ActivitySorts>> newColumns(boolean includeTypeColumn) {
        List<IColumn<Activity, ActivitySorts>> columns = Arrays.asList(
                new IconInfoColumn<>(
                        Model.of(""),
                        ActivityModels.TYPE,
                        new ActivityTypeIconFunction()),
                new LocalDateTimeRangeFilterColumn<Activity, ActivitySorts>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DATE),
                        ActivityModels.CREATED_DATE,
                        ActivitySorts.CREATE_DATE,
                        ActivitySearchCriteriaModels.CREATED_RANGE,
                        NodeWebConstants.DATERANGE_DEFAULT_SETTINGS)
                {

                        @Override
                        public String getCssClass() {
                            return "width-180-px";
                        }

						@Override
						public void populateItem(Item<ICellPopulator<Activity>> item, String componentId, IModel<Activity> rowModel) {
							item.add(new WindsorAjaxLabelLinkPanel<LocalDateTime>(componentId, getDataModel(rowModel),
					        		new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_VIEW_ACTIVITY_ENTRY)) {

					            @Override
					            public void onClick(AjaxRequestTarget target) {
					                send(this, Broadcast.BUBBLE, new ViewEvent<>(target, rowModel.getObject()));
					            }

					        });
						}

                },
                new Select2SingleChoiceFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_EXCHANGE),
                        ActivitySorts.EXCHANGE,
                        ActivityModels.EXCHANGE,
                        ActivitySearchCriteriaModels.EXCHANGE,
                        new ExchangeChoiceProvider(exchangeService,
                                (term, pageNum) -> exchangeService.find(
                                        new ExchangeSearchCriteria()
                                            .name(StringUtils.isBlank(term) ? null : term),
                                        ExchangeSorts.NAME)),
                        "width-240-px"),
                new TextFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_OPERATION),
                        ActivityModels.OPERATION,
                        ActivitySorts.OPERATION,
                        ActivitySearchCriteriaModels.OPERATION),
                new TextFilteredLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_NAME),
                        ActivityModels.ACCOUNT_EMAIL,
                        ActivitySorts.ACCOUNT_EMAIL,
                        ActivitySearchCriteriaModels.ACCOUNT_EMAIL),
                new Select2SingleChoiceFilteredLazyColumn<Activity, ActivitySorts, Boolean, Boolean>(
                        Model.of("Attachments"),
                        null,
                        ActivityModels.HAS_DOCS,
                        ActivitySearchCriteriaModels.HAS_DOCS,
                        new YesNoChoiceProvider()) {

                    @Override
                    public void populateItem(Item<ICellPopulator<Activity>> item, String componentId, IModel<Activity> rowModel) {
                        item.add(new StyledIcon(componentId, new LDModel(() -> rowModel.getObject().hasDocuments() ? new IconInfo(GlyphIconType.paperclip, IconStyle.INFO) : null)));
                    }

                });
        if (includeTypeColumn) {
        	columns = new ArrayList<>(columns);
        	columns.add(new Select2SingleChoiceFilteredLazyColumn<Activity, ActivitySorts, ActivityType, ActivityType>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_TYPE),
                        ActivitySorts.TYPE,
                        ActivityModels.TYPE,
                        ActivitySearchCriteriaModels.TYPE,
                        new ActivityTypeProviderChoiceProvider(),
                        "width-240-px"));
        }
        return columns;
    }

    private static final class ActivityTypeIconFunction implements ISerializableFunction<ActivityType, IconInfo> {

        @Override
        public IconInfo apply(ActivityType type) {
            IconInfo info = null;
            switch (type) {
            case AdminAuth:
                info = new IconInfo(Icons.ICON_LOCK, IconStyle.INFO);
                break;
            case Audit:
                info = new IconInfo(Icons.ICON_AUDIT, IconStyle.INFO);
                break;
            case Error:
                info = new IconInfo(Icons.ICON_ERROR, IconStyle.WARNING);
                break;
            case Info:
                info = new IconInfo(Icons.ICON_INFO, IconStyle.SUCCESS);
                break;
            case ServiceAuth:
                info = new IconInfo(Icons.ICON_SERVICE_AUTH, IconStyle.INFO);
                break;
            default:
                break;
            }
            return info;
        }
    }

}
