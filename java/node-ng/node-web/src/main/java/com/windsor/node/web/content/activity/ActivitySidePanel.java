package com.windsor.node.web.content.activity;

import com.altova.io.FileInput;
import com.windsor.node.domain.NodePermission;
import com.windsor.node.service.props.NosProperties;
import com.windsor.node.web.behavior.OnlyVisibleForPermissionsBehavior;
import com.windsor.stack.web.wicket.behavior.AjaxDownload;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.BootstrapAjaxLink;
import de.agilecoders.wicket.core.markup.html.bootstrap.button.Buttons;
import org.apache.commons.io.IOUtils;
import org.apache.wicket.ajax.AjaxRequestTarget;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.basic.MultiLineLabel;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.model.IModel;

import com.windsor.node.domain.search.ActivitySearchCriteria;
import com.windsor.node.web.app.NodeResourceModelKeys;
import com.windsor.node.web.model.lazy.ActivitySearchCriteriaModels;
import com.windsor.stack.web.wicket.component.panel.AbstractBasePanel;
import com.windsor.stack.web.wicket.markup.html.form.button.ResetButton;
import com.windsor.stack.web.wicket.markup.html.form.button.SearchButton;
import com.windsor.stack.web.wicket.model.IdentifiableResourceModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.form.FormGroup;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;
import org.apache.wicket.util.resource.AbstractResourceStream;
import org.apache.wicket.util.resource.IResourceStream;
import org.apache.wicket.util.resource.ResourceStreamNotFoundException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.stream.Stream;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

/**
 * Provides a side panel.
 */
public class ActivitySidePanel extends AbstractBasePanel<ActivitySearchCriteria> {

    private static final Logger LOGGER = LoggerFactory.getLogger(ActivitySidePanel.class);

    @SpringBean
    private NosProperties nosProps;

    private AjaxDownload download;

    public ActivitySidePanel(String id, IModel<ActivitySearchCriteria> model, IModel<String> contentModel) {
        super(id, model);

        add(new Label("advancedSearch", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_ADVANCED_SEARCH)));

        Form<ActivitySearchCriteria> form = new Form<>("form", model);
        add(form);

        download = new AjaxDownload() {
            @Override
            protected IResourceStream getResourceStream() {
                return new AbstractResourceStream() {

                    private File logZip;

                    @Override
                    public InputStream getInputStream() throws ResourceStreamNotFoundException {
                        try {
                            logZip = File.createTempFile("logs", ".zip");
                            FileOutputStream fos = new FileOutputStream(logZip);
                            ZipOutputStream zos = new ZipOutputStream(fos);
                            File logDir = new File(nosProps.getLogDirectory());
                            for (File f: logDir.listFiles()) {
                                ZipEntry ze = new ZipEntry(f.getName());
                                zos.putNextEntry(ze);
                                FileInputStream in = new FileInputStream(f);
                                IOUtils.copy(in, zos);
                                IOUtils.closeQuietly(in);
                            }
                            zos.closeEntry();
                            zos.close();
                            return new FileInputStream(logZip);
                        } catch (Exception e) {
                            throw new RuntimeException(e);
                        }
                    }

                    @Override
                    public void close() throws IOException {
                        try {
                            logZip.delete();
                        } catch (Exception e) {
                            LOGGER.warn("Error deleting temp log zip file", e);
                        }
                    }


                };
            }

            @Override
            protected String getFileName() {
                return "opennode2_logs.zip";
            }
        };
        add(download);

        form.add(new FormGroup("detailGroup")
                .add(new TextField<>("field", ActivitySearchCriteriaModels.bindDetails(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_CONTENT))));

        form.add(new FormGroup("ipGroup")
                .add(new TextField<>("field", ActivitySearchCriteriaModels.bindIpAddress(model))
                        .setLabel(new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_IP_ADDRESS))));

        form.add(new SearchButton("search", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_SEARCH)));
        form.add(new ResetButton("reset"));

        add(new Label("title", new IdentifiableResourceModel(NodeResourceModelKeys.LABEL_HELP)));
        add(new MultiLineLabel("content", contentModel)
                .setEscapeModelStrings(false)
                .setOutputMarkupId(true));

        add(new Label("logs-title", Model.of("Server Logs")));
        add(new BootstrapAjaxLink<String>("logs", Buttons.Type.Primary) {

            @Override
            public void onClick(AjaxRequestTarget target) {
                download.initiate(target);
            }

        }.setLabel(Model.of("Download"))
                .add(new OnlyVisibleForPermissionsBehavior(NodePermission.ADMIN_USER)));

    }

}