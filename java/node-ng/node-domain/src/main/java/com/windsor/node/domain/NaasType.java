package com.windsor.node.domain;

import static java.util.function.Function.identity;
import static java.util.stream.Collectors.toMap;
import static java.util.stream.Stream.of;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.Map;
import java.util.Optional;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public enum NaasType {
	
	PROD("production", "cdxnodenaas.epa.gov"),
	TEST("test", "naas.epacdxnode.net");
	
	private static final Logger LOGGER = LoggerFactory.getLogger(NaasType.class);
	private static final Map<String, NaasType> MAP = of(values()).collect(toMap(NaasType::getHost, identity()));
	
	private String name;
	private String host;
	
	NaasType(String name, String host) {
		this.name = name;
		this.host = host;
	}

	public String getName() {
		return name;
	}

	public String getHost() {
		return host;
	}
	
	public static Optional<NaasType> getNaasType(String url) {
		NaasType type = null;
		try {
			type = MAP.get(new URL(url).getHost());
		} catch (MalformedURLException e) {
			LOGGER.error("Error determining the the NAAS type from the URL " + url, e);
		}
		return Optional.ofNullable(type);
	}
	
}
