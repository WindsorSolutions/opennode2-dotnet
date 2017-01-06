package com.windsor.node.domain;

import java.io.Serializable;
import java.time.LocalDate;

public class NodeNews implements Serializable {

	private String title;
	private String description;
	private String url;
	private LocalDate publishDate;
	
	public NodeNews(String title, String description, String url, LocalDate publishDate) {
		super();
		this.title = title;
		this.description = description;
		this.url = url;
		this.publishDate = publishDate;
	}

	public String getTitle() {
		return title;
	}

	public String getDescription() {
		return description;
	}

	public String getUrl() {
		return url;
	}

	public LocalDate getPublishDate() {
		return publishDate;
	}
	
}
