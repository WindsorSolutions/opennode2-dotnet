package com.windsor.node.web.content.activity;

import java.io.File;
import java.io.IOException;
import java.net.MalformedURLException;
import java.util.List;
import java.util.stream.Collectors;

import org.apache.wicket.Component;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.ajax.markup.html.AjaxLink;
import org.apache.wicket.event.Broadcast;
import org.apache.wicket.markup.html.WebMarkupContainer;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.wicketstuff.event.annotation.OnEvent;

import com.windsor.node.domain.entity.Document;
import com.windsor.node.domain.entity.Transaction;
import com.windsor.node.domain.search.DocumentSearchCriteria;
import com.windsor.node.domain.search.DocumentSorts;
import com.windsor.node.service.DocumentService;
import com.windsor.node.service.TransactionService;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.behavior.DownloadDocumentBehavior;
import com.windsor.node.web.behavior.DownloadTempFileBehavior;
import com.windsor.node.web.model.lazy.DocumentModels;
import com.windsor.node.web.model.lazy.TransactionModels;
import com.windsor.stack.web.wicket.behavior.VisibleModelBehavior;
import com.windsor.stack.web.wicket.event.DownloadEvent;
import com.windsor.stack.web.wicket.event.EditEvent;
import com.windsor.stack.web.wicket.markup.html.form.button.DownloadButton;
import com.windsor.stack.web.wicket.markup.html.form.button.EditButton;
import com.windsor.stack.web.wicket.model.EntityModel;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.image.GlyphIconType;
import de.agilecoders.wicket.core.markup.html.bootstrap.image.Icon;

public class TransactionDetailPanel extends Panel {

    @SpringBean
    private DocumentService documentService;

    @SpringBean
    private TransactionService transactionService;

    private DownloadDocumentBehavior documentDownload;
    private DownloadTempFileBehavior zipDownload;
    private Component statusComponent;

    public TransactionDetailPanel(String id, IModel<Transaction> model) {
        super(id, model);

        documentDownload = new DownloadDocumentBehavior();
        add(documentDownload);

        zipDownload = new DownloadTempFileBehavior();
        add(zipDownload);

        statusComponent = new Label("status", TransactionModels.bindStatus(model))
            .setOutputMarkupId(true);
        add(statusComponent);

        add(new Label("id", TransactionModels.bindId(model)));
        add(new Label("statusDetails", TransactionModels.bindDetails(model)));
        add(new Label("serviceType", TransactionModels.bindMethod(model)));
        add(new Label("exchange", TransactionModels.bindExchange(model)));
        add(new Label("dataOperation", TransactionModels.bindOperation(model)));
        add(new Label("modifiedBy", TransactionModels.bindModifiedBy(model)));
        add(new Label("modifiedOn", TransactionModels.bindModifiedOn(model)));

        WebMarkupContainer endpointContainer = new WebMarkupContainer("remoteContainer");
        endpointContainer.add(new VisibleModelBehavior(TransactionModels.bindHasRemoteTransaction(model)));
        add(endpointContainer);
        endpointContainer.add(new Label("remoteTransactionId", TransactionModels.bindRemoteTransactionid(model)));
        endpointContainer.add(new Label("remoteUrl", TransactionModels.bindRemoteUrl(model)));
        endpointContainer.add(new Label("remoteVersion", TransactionModels.bindRemoteVersion(model)));

        IModel<List<Document>> documentsModel = new LDModel<>(() -> documentService.find(new DocumentSearchCriteria().transactionId(model.getObject().getId()), DocumentSorts.NAME).collect(Collectors.toList()));
        add(new ListView<Document>("documents", documentsModel) {

            @Override
            protected void populateItem(ListItem<Document> item) {
                IModel<Document> docModel = item.getModel();
                item.add(new Icon("icon", GlyphIconType.paperclip));
                AjaxLink<?> link = new AjaxLink<Document>("link", docModel) {

                    @Override
                    public void onClick(AjaxRequestTarget target) {
                        send(this, Broadcast.BUBBLE, new DownloadEvent<>(target, item.getModelObject()));
                    }

                };
                item.add(link);
                link.add(new Label("name", DocumentModels.bindName(docModel)));
                link.add(new Label("type", DocumentModels.bindType(docModel)));
            }
        });

        WebMarkupContainer buttonContainer = new WebMarkupContainer("buttonContainer");
        buttonContainer.add(new VisibleModelBehavior(TransactionModels.bindHasRemoteTransaction(model)));
        add(buttonContainer);
        Form<Transaction> form = new Form<>("form", model);
        form.add(new VisibleModelBehavior(TransactionModels.bindHasQueryableRemoteTransaction(model)));
        buttonContainer.add(form);
        form.add(new EditButton("refreshStatus", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_REFRESH_STATUS))
                .setIconType(Icons.ICON_REFRESH));
        form.add(new DownloadButton("downloadDocuments", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_DOWNLOAD_DOCUMENTS))
                .add(new VisibleModelBehavior(TransactionModels.bindHasTargetExchange(model))));

    }

    @OnEvent(types = Document.class)
    public void handleDownloadEvent(DownloadEvent<Document> event) {
        documentDownload.initiate(event.getTarget(), new EntityModel<>(documentService, event.getPayload().getId()));
    }

    @OnEvent(types = Transaction.class)
    public void handleRefreshStatus(EditEvent<Transaction> event) throws MalformedURLException {
        transactionService.updateStatus(event.getPayload());
        event.getTarget().add(statusComponent);
    }

    @OnEvent(types = Transaction.class)
    public void handleDownloadRemoteDocuments(DownloadEvent<Transaction> event) throws IOException {
        File zipFile = transactionService.downloadFiles(event.getPayload());
        zipDownload.initiate(event.getTarget(), Model.of(zipFile));
    }

}
