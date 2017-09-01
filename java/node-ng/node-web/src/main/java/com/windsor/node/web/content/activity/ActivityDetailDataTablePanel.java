package com.windsor.node.web.content.activity;

import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;

import org.apache.wicket.extensions.markup.html.repeater.data.table.IColumn;
import org.apache.wicket.extensions.markup.html.repeater.util.SortParam;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.ActivityDetail;
import com.windsor.node.domain.search.ActivityDetailSearchCriteria;
import com.windsor.node.domain.search.ActivityDetailSorts;
import com.windsor.node.service.ActivityDetailService;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.ActivityDetailModels;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTableConfiguration;
import com.windsor.stack.web.wicket.component.datatable.WindsorDataTablePanel;
import com.windsor.stack.web.wicket.component.datatable.column.lazy.ExportableLazyColumn;
import com.windsor.stack.web.wicket.markup.html.repeater.util.FinderDataProvider;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

public class ActivityDetailDataTablePanel extends Panel {

    @SpringBean
    private ActivityDetailService service;

    public ActivityDetailDataTablePanel(String id, IModel<Activity> model) {
        super(id, model);
        add(new WindsorDataTablePanel<>("table", newColumns(),
                new FinderDataProvider<>(service,
                        new LDModel<>(() -> new ActivityDetailSearchCriteria().activityId(model.getObject().getId())),
                        new SortParam<>(ActivityDetailSorts.CREATE_DATE, true)), 1000L,
                new WindsorDataTableConfiguration()
                    .filteringToolbarVisible(false)
                    .bottomToolbarVisibleOnlyIfNecessary(true)));
    }

    private List<IColumn<ActivityDetail, ActivityDetailSorts>> newColumns() {
        return Arrays.asList(
                new ExportableLazyColumn<ActivityDetail, ActivityDetailSorts, LocalDateTime>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DATE),
                        ActivityDetailModels.CREATE_DATE,
                        ActivityDetailSorts.CREATE_DATE) {

                            @Override
                            public String getCssClass() {
                                return "width-180-px";
                            }



                },
                new ExportableLazyColumn<>(
                        new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DESCRIPTION),
                        ActivityDetailModels.DETAIL,
                        ActivityDetailSorts.DETAIL));
    }

}
