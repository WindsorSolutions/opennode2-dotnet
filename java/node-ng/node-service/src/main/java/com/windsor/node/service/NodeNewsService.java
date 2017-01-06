package com.windsor.node.service;

import java.util.List;

import com.windsor.node.domain.NodeNews;

public interface NodeNewsService {

	List<NodeNews> getLatestNews();
	
}
