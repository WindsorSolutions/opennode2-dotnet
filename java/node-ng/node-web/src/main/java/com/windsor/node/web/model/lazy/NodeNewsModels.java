package com.windsor.node.web.model.lazy;

import static org.wicketstuff.lazymodel.LazyModel.from;
import static org.wicketstuff.lazymodel.LazyModel.model;

import java.time.LocalDate;

import org.apache.wicket.model.IModel;
import org.wicketstuff.lazymodel.LazyModel;

import com.windsor.node.domain.NodeNews;

public class NodeNewsModels {

	public static final LazyModel<String> TITLE = model(from(NodeNews.class).getTitle());
	public static final LazyModel<String> BODY = model(from(NodeNews.class).getDescription());
	public static final LazyModel<String> URL = model(from(NodeNews.class).getUrl());
	public static final LazyModel<LocalDate> PUBLISHED = model(from(NodeNews.class).getPublishDate());
	
	private NodeNewsModels() {
		super();
	}
	
	public static IModel<String> bindTitle(IModel<NodeNews> model) {
		return TITLE.bind(model);
	}
	
	public static IModel<String> bindBody(IModel<NodeNews> model) {
		return BODY.bind(model);
	}
	
	public static IModel<String> bindUrl(IModel<NodeNews> model) {
		return URL.bind(model);
	}
	
	public static IModel<LocalDate> bindPublished(IModel<NodeNews> model) {
		return PUBLISHED.bind(model);
	}
	
}
