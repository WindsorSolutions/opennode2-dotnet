package com.windsor.node.web.content.home;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.link.ExternalLink;
import org.apache.wicket.markup.html.list.ListItem;
import org.apache.wicket.markup.html.list.ListView;
import org.apache.wicket.markup.html.panel.Panel;
import org.apache.wicket.model.IModel;
import org.apache.wicket.model.Model;
import org.apache.wicket.spring.injection.annot.SpringBean;

import com.windsor.node.domain.NodeNews;
import com.windsor.node.service.NodeNewsService;
import com.windsor.node.web.app.Icons;
import com.windsor.node.web.model.FormattedTemporalAccessorModel;
import com.windsor.node.web.model.lazy.NodeNewsModels;
import com.windsor.stack.web.wicket.model.LDModel;

import de.agilecoders.wicket.core.markup.html.bootstrap.image.Icon;

public class NodeNewsPanel extends Panel {

	@SpringBean
	private NodeNewsService service;
	
	public NodeNewsPanel(String id) {
		super(id);
		add(new ListView<NodeNews>("item", new LDModel<>(() -> service.getLatestNews())) {

			@Override
			protected void populateItem(ListItem<NodeNews> item) {
				IModel<NodeNews> model = item.getModel();
				item.add(new Icon("icon", Model.of(Icons.ICON_RSS)));
				item.add(new Label("published", new FormattedTemporalAccessorModel(NodeNewsModels.bindPublished(model), "EEE, MMM d yyyy")));
				ExternalLink link = new ExternalLink("url", NodeNewsModels.bindUrl(model));
				item.add(link);
				link.add(new Label("title", NodeNewsModels.bindTitle(model)));
				item.add(new Label("body", NodeNewsModels.bindBody(model)));
			}
			
		});
	}

}
