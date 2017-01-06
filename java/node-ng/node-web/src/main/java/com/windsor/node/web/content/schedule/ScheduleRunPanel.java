package com.windsor.node.web.content.schedule;

import java.time.LocalDateTime;

import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.entity.Activity;
import com.windsor.node.domain.entity.Schedule;
import com.windsor.node.domain.entity.Transaction;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.component.IconInfo;
import com.windsor.node.web.component.IconInfo.IconStyle;
import com.windsor.node.web.component.StyledIcon;
import com.windsor.node.web.model.lazy.ScheduleModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.event.ViewEvent;
import com.windsor.stack.web.wicket.markup.html.link.WindsorAjaxLabelLinkPanel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LoadableDetachableWrappedModel;

public class ScheduleRunPanel extends Panel {

    public ScheduleRunPanel(String id, IModel<Schedule> model) {
        super(id, model);

        add(new StyledIcon("icon", new TransactionStatusIconInfoModel(model))
                .add(new VisibleModelBehavior(ScheduleModels.bindIsTransactionAssociated(model))));

        add(new WindsorAjaxLabelLinkPanel<LocalDateTime>("link", ScheduleModels.bindLastExecution(model),
        		new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_VIEW_ACTIVITY_ENTRY)) {

            @Override
            public void onClick(AjaxRequestTarget ajaxRequestTarget) {
                send(this, Broadcast.BUBBLE, new ViewEvent<>(ajaxRequestTarget, model.getObject()));
            }

        });
    }

    private static class TransactionStatusIconInfoModel extends LoadableDetachableWrappedModel<IconInfo, Schedule> {

        public TransactionStatusIconInfoModel(IModel<Schedule> wrappedModel) {
            super(wrappedModel);
        }

        @Override
        protected IconInfo load() {
            IconInfo iconInfo = null;
            Schedule schedule = getWrappedModel().getObject();
            Activity activity = schedule.getActivity();
            if (activity != null) {
                Transaction transaction = activity.getTransaction();
                if (transaction != null) {
                    switch (transaction.getStatus()) {
                    case Approved:
                        iconInfo = new IconInfo(Icons.ICON_APPROVED, IconStyle.SUCCESS);
                        break;
                    case Cancelled:
                        iconInfo = new IconInfo(Icons.ICON_CANCEL, IconStyle.INFO);
                        break;
                    case Completed:
                        iconInfo = new IconInfo(Icons.ICON_OK, IconStyle.SUCCESS);
                        break;
                    case Failed:
                        iconInfo = new IconInfo(Icons.ICON_INVALID, IconStyle.WARNING);
                        break;
                    case Pending:
                        iconInfo = new IconInfo(Icons.ICON_PENDING, IconStyle.INFO);
                        break;
                    case Processed:
                        iconInfo = new IconInfo(Icons.ICON_VALID, IconStyle.INFO);
                        break;
                    case Processing:
                        iconInfo = new IconInfo(Icons.ICON_RUN, IconStyle.INFO);
                        break;
                    case Received:
                        iconInfo = new IconInfo(Icons.ICON_RECEIVED, IconStyle.INFO);
                        break;
                    case Unknown:
                        iconInfo = new IconInfo(Icons.ICON_UNKNOWN, IconStyle.INFO);
                        break;
                    }
                }
            }
            return iconInfo;
        }

    }

}
