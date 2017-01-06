package com.windsor.node.service;

import java.io.IOException;
import java.net.URL;
import java.time.LocalDate;
import java.time.ZoneId;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.rometools.rome.feed.synd.SyndContent;
import com.rometools.rome.feed.synd.SyndEntry;
import com.rometools.rome.feed.synd.SyndFeed;
import com.rometools.rome.io.FeedException;
import com.rometools.rome.io.SyndFeedInput;
import com.rometools.rome.io.XmlReader;
import com.windsor.node.domain.NodeNews;
import com.windsor.node.service.props.NosProperties;

/**
 * Provides an implementation of the node news service.
 */
@Service
public class NodeNewsServiceImpl implements NodeNewsService {

	private static final Logger LOGGER = LoggerFactory.getLogger(NodeNewsServiceImpl.class);
	
	@Autowired
	private NosProperties nosProperties;

	@Override
	public List<NodeNews> getLatestNews() {
		List<NodeNews> list = Collections.emptyList();
		try {
			SyndFeed feed = new SyndFeedInput().build(new XmlReader(new URL(nosProperties.getNodeNewsUrl())));
			List<SyndEntry> links = feed.getEntries();
			Stream<SyndEntry> stream = links == null ? Stream.empty() : links.stream();
			list = stream.map(x -> 
					new NodeNews(
							x.getTitle(), 
							toBody(x.getDescription()), 
							x.getUri(), 
							toPublishDate(x.getPublishedDate())))
					.limit(nosProperties.getMaxNewsItems())
					.collect(Collectors.toList());
		} catch (IllegalArgumentException | FeedException | IOException e) {
			LOGGER.warn("Error getting news feeds", e);
		}
		return list;
	}
	
	private String toBody(SyndContent content) {
		return content == null ? null : content.getValue();
	}
	
	private LocalDate toPublishDate(Date publishDate) {
		return publishDate == null ? null : publishDate.toInstant().atZone(ZoneId.systemDefault()).toLocalDate();
	}
	
}
