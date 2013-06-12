/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
 */

/**
 * 
 */
package com.windsor.node.admin.rss;

import java.net.URL;
import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;

import com.sun.syndication.feed.synd.SyndEntry;
import com.sun.syndication.feed.synd.SyndFeed;
import com.sun.syndication.io.SyndFeedInput;
import com.sun.syndication.io.XmlReader;

/**
 * A RSS feed reader that uses the ROME implementation. Requires the feed
 * location upon initialization.
 * 
 * @author Eric Chan
 * 
 */
public class RemoteRssFeedReader implements FeedReader, InitializingBean {

    protected Logger logger = LoggerFactory.getLogger(RemoteRssFeedReader.class);
    private String uri;
    private Integer maxItems;

    public RemoteRssFeedReader() {
        setMaxItems(new Integer(-1));
    }

    public FeedResult read(Object criteria) {

        logger.debug("Attempting to read from " + getUri());

        FeedResult result = new FeedResult();

        try {
            URL feedUrl = new URL(getUri());
            SyndFeedInput input = new SyndFeedInput();
            SyndFeed feed = input.build(new XmlReader(feedUrl));

            logger.trace("Feed: " + feed);

            logger.debug("Feed title: " + feed.getTitle());
            result.setTitle(feed.getTitle());

            logger.debug("Feed description: " + feed.getDescription());
            result.setDescription(feed.getDescription());

            // convert the feed to a Feed Result Item so we can use data
            // from different sources if we need to, and not tied to the
            // ROME RSS reader implementation.

            List entries = feed.getEntries();
            logger.debug("Feed contains " + entries.size() + " entries");

            for (Iterator iter = entries.iterator(); iter.hasNext();) {
                if (getMaxItems().intValue() > 0
                        && getMaxItems().intValue() <= result.getItems().size()) {
                    logger
                            .debug("No more entries or maxItems reached - breaking");
                    break;
                }

                SyndEntry entry = (SyndEntry) iter.next();
                logger.trace("processing SyndEntry:" + entry.toString());

                FeedResultItem item = new FeedResultItem();

                logger.debug("entry.getTitle(): " + entry.getTitle());
                item.setTitle(entry.getTitle());

                if (null == entry.getDescription()) {

                    logger.debug("Null description");
                    item.setBody("No description available");

                } else {

                    logger.trace("entry.getDescription().getValue(): "
                            + entry.getDescription().getValue());
                    item.setBody(entry.getDescription().getValue());
                }

                if (null == entry.getPublishedDate()) {

                    logger.debug("Null publication date");

                } else {

                    logger.debug("entry.getPublishedDate(): "
                            + entry.getPublishedDate());
                    item.setDate(entry.getPublishedDate());
                }

                if (null == entry.getLink()) {

                    logger.debug("Null link");

                } else {

                    logger.debug("entry.getLink(): "
                            + entry.getLink());
                    item.setUrl(entry.getLink());
                }
                
                result.getItems().add(item);
            }

        } catch (Exception e) {
            logger.error("Feed reader for " + getUri() + " failed. " + e);
            // swallow error and return empty result
            result = new FeedResult();
        }

        return result;
    }

    public String getUri() {
        return uri;
    }

    public void setUri(String uri) {
        this.uri = uri;
    }

    public Integer getMaxItems() {
        return maxItems;
    }

    public void setMaxItems(Integer maxItems) {
        this.maxItems = maxItems;
    }

    public void afterPropertiesSet() throws Exception {
        if (StringUtils.isBlank(getUri())) {
            throw new IllegalStateException(
                    "Uri property is not set for feed reader");
        }
    }

}
