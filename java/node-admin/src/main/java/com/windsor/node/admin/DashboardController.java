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

package com.windsor.node.admin;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

import com.windsor.node.admin.rss.FeedReader;
import com.windsor.node.admin.rss.FeedResult;
import com.windsor.node.admin.util.AdminConstants;
import com.windsor.node.admin.util.VisitUtils;
import com.windsor.node.common.domain.ChartItem;
import com.windsor.node.common.domain.DashboardContent;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.service.admin.ActivityService;

public class DashboardController extends AbstractController implements
        InitializingBean {

    private static final int MAX_TRAN_LABEL_LENGTH_DEFAULT = 15;
    private static final int MAX_ACTIVITY_LABEL_LENGTH_DEFAULT = 10;
    private static final int MAX_TRAN_ITEMS = 5;
    private static final int MAX_ACTIVITY_ITEMS = 5;
    private static final int MAX_NUMBER_DEFAULT = 100;

    protected Logger logger = LoggerFactory.getLogger(DashboardController.class);

    // the key used in this map will be used as the key for the contents of the
    // feed in the model and view.
    private Map feedReaders;
    private String feedKey;
    private ActivityService activityService;

    private int maxTransactionChartLabelLength;
    private int maxActivityChartLabelLength;

    private int maxTransactionChartItems;
    private int maxActivityChartItems;

    public DashboardController() {
        // set defaults
        maxTransactionChartLabelLength = MAX_TRAN_LABEL_LENGTH_DEFAULT;
        maxActivityChartLabelLength = MAX_ACTIVITY_LABEL_LENGTH_DEFAULT;
        maxTransactionChartItems = MAX_TRAN_ITEMS;
        maxActivityChartItems = MAX_ACTIVITY_ITEMS;
        setFeedKey("feeds");
        setFeedReaders(new HashMap());
    }

    public void afterPropertiesSet() throws Exception {

        if (activityService == null) {
            throw new Exception("DashboardController: activityService not set");
        }

    }

    protected ModelAndView handleRequestInternal(HttpServletRequest request,
            HttpServletResponse response) throws Exception {

        NodeVisit visit = VisitUtils.getVisit(request);

        if (visit == null) {
            logger.debug(AdminConstants.UNAUTHED + " dashboard "
                    + AdminConstants.ACCESS_REQUEST);
            return VisitUtils.getUnauthedView(request);
        }

        Map model = new HashMap();
        model.put(AdminConstants.VISIT_KEY, visit);
        addFeeds(model, getFeedReaders());

        DashboardContent content = activityService.getDashboardContent(visit);
        logger.debug("DashboardContent: " + content);

        /* data for the Transaction Type pie chart */
        logger.debug("Getting transactionChartData...");
        String transactionChartData = getCountData(content
                .getTransactionItems(), AdminConstants.COMMA,
                maxTransactionChartItems);
        logger.debug("transactionChartData: " + transactionChartData);
        model.put("transactionChartData", transactionChartData);

        logger.debug("Getting transactionChartLabel...");
        String transactionChartLabel = getLabelData(content
                .getTransactionItems(), AdminConstants.PIPE,
                maxTransactionChartLabelLength, true, maxTransactionChartItems);
        logger.debug("transactionChartLabel: " + transactionChartLabel);
        model.put("transactionChartLabel", transactionChartLabel);

        /* data for the User Activity bar chart */
        logger.debug("Getting activeUserChartYaxisLabel...");
        String item0 = AdminConstants.PIPE
                + getMinMidMax(content.getActivityItems(), AdminConstants.PIPE,
                        maxActivityChartItems) + AdminConstants.PIPE;
        model.put("activeUserChartYaxisLabel", item0);
        logger.debug("activeUserChartYaxisLabel: " + item0);

        logger.debug("Getting activeUserChartXaxisLabel...");
        String item1 = AdminConstants.PIPE
                + getLabelData(content.getActivityItems(), AdminConstants.PIPE,
                        maxActivityChartLabelLength, false,
                        maxActivityChartItems) + AdminConstants.PIPE;
        model.put("activeUserChartXaxisLabel", item1);
        logger.debug("activeUserChartXaxisLabel: " + item1);

        logger.debug("Getting activeUserChartData...");
        String itemT = getCountData(content.getActivityItems(),
                AdminConstants.COMMA, maxActivityChartItems);
        model.put("activeUserChartData", itemT);
        logger.debug("activeUserChartData: " + itemT);

        model.put("activeUserChartMaxNumber", getMaxNumber(content
                .getActivityItems(), maxActivityChartItems));

        request.setAttribute("result", content.getResult());

        return new ModelAndView("dashboard", AdminConstants.MODEL_KEY, model);

    }

    private Integer getMaxNumber(List data, int maxItems) {

        if (data == null) {
            return new Integer(MAX_NUMBER_DEFAULT);
        }

        int max = 0;

        for (int i = 0; i < data.size(); i++) {

            ChartItem item = (ChartItem) data.get(i);

            if (item.getCount() > max) {
                max = item.getCount();
            }

            if (i >= maxItems) {
                break;
            }

        }

        logger.debug("getMaxNumber: " + max);
        return new Integer(max);

    }

    private String getMinMidMax(List data, String deliminator, int maxItems) {

        if (data == null) {
            return "";
        }

        int max = 0;

        for (int i = 0; i < data.size(); i++) {

            ChartItem item = (ChartItem) data.get(i);

            if (item.getCount() > max) {
                max = item.getCount();
            }

            if (i >= maxItems) {
                break;
            }

        }

        int mid = max / 2;

        String result = "0" + deliminator + mid + deliminator + max;

        logger.debug("getMinMidMax: " + result);
        return result;

    }

    /**
     * getLabelData
     * 
     * @param data
     * @param deliminator
     * @param maxLen
     * @param appendCount
     * @return
     */
    private String getLabelData(List data, String deliminator, int maxLen,
            boolean appendCount, int maxItems) {

        if (data == null) {
            return "";
        }

        StringBuffer buf = new StringBuffer();

        for (int i = 0; i < data.size(); i++) {

            ChartItem item = (ChartItem) data.get(i);

            String label = item.getLabel();
            if (label.length() > maxLen) {
                label = label.substring(0, maxLen - 1);
            }

            if (appendCount) {
                buf.append(label + "-" + item.getCount());
            } else {
                buf.append(label);
            }

            if (i >= maxItems) {
                break;
            }

            if (i < (data.size() - 1)) {
                buf.append(deliminator);
            }

        }

        String keyData = buf.toString();

        logger.debug("getLabelData: " + keyData);
        return keyData;

    }

    private String getCountData(List data, String deliminator, int maxItems) {

        if (data == null) {
            return "";
        }

        StringBuffer buf = new StringBuffer();

        for (int i = 0; i < data.size(); i++) {

            ChartItem item = (ChartItem) data.get(i);

            buf.append(item.getCount());

            if (i >= maxItems) {
                break;
            }

            if (i < (data.size() - 1)) {
                buf.append(deliminator);
            }

        }

        String keyData = buf.toString();

        logger.debug("getCountData: " + keyData);
        return keyData;

    }

    /**
     * Adds the feed content of each feedreader into the model by key.
     * 
     * @param model
     * @param feedReaders2
     */
    private void addFeeds(Map model, Map feedReaders) {

        if (model == null) {
            logger.debug("addFeeds(): null model");
        }

        else if (feedReaders == null) {
            logger.debug("addFeeds(): null feedreaders");
        }

        else {
            Set keys = feedReaders.keySet();
            logger.debug("addFeeds(): found " + keys.size() + " FeedReader(s)");
            
            List feeds = new ArrayList();
            for (Iterator iter = keys.iterator(); iter.hasNext();) {
                String key = (String) iter.next();
                // the read parameter is not needed because we know these feeds
                // don't have any.
                FeedResult feed = ((FeedReader) feedReaders.get(key))
                        .read("no criteria needed");
                feeds.add(feed);
                logger.debug("addFeeds(): added feed titled \"" + feed.getTitle() + "\"");
            }
            model.put(getFeedKey(), feeds);
        }
    }

    public Map getFeedReaders() {
        return feedReaders;
    }

    public void setFeedReaders(Map feedReaders) {
        this.feedReaders = feedReaders;
    }

    public String getFeedKey() {
        return feedKey;
    }

    public void setFeedKey(String feedKey) {
        this.feedKey = feedKey;
    }

    public void setActivityService(ActivityService activityService) {
        this.activityService = activityService;
    }

    public void setMaxTransactionChartLabelLength(
            int maxTransactionChartLabelLength) {
        this.maxTransactionChartLabelLength = maxTransactionChartLabelLength;
    }

    public void setMaxActivityChartLabelLength(int maxActivityChartLabelLength) {
        this.maxActivityChartLabelLength = maxActivityChartLabelLength;
    }

    public void setMaxTransactionChartItems(int maxTransactionChartItems) {
        this.maxTransactionChartItems = maxTransactionChartItems;
    }

    public void setMaxActivityChartItems(int maxActivityChartItems) {
        this.maxActivityChartItems = maxActivityChartItems;
    }

}
