#region License
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
#endregion

﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Rss;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class NewsBar : System.Web.UI.UserControl
    {

        private const string RSS_CACHE_NAME = "NEWS_FEEDS";

        public void Display(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Null RssFeedUrl");
            }

            RssFeed feed = null;

            if (HttpContext.Current.Cache.Get(RSS_CACHE_NAME) == null)
            {
                feed = RssFeed.Read(url);
                HttpContext.Current.Cache.Add(RSS_CACHE_NAME, feed, null, DateTime.Now.AddDays(1),
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }
            else
            {
                feed = HttpContext.Current.Cache.Get(RSS_CACHE_NAME) as RssFeed;
            }

            // Limit feed to the first 4 elements:
            if ((feed.Channels != null) && (feed.Channels.Count > 0))
            {
                for (int i = feed.Channels.Count - 1; i > 3; --i)
                {
                    feed.Channels.RemoveAt(i);
                }
                RssItemCollection items = feed.Channels[0].Items;
                if ((items != null) && (items.Count > 0))
                {
                    for (int i = items.Count - 1; i > 3; --i)
                    {
                        RssElement element = items[i];
                        items.RemoveAt(i);
                    }
                }
            }
            listChannels.DataSource = feed.Channels;
            listChannels.DataBind();
        }

        protected void listChannels_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

    }
}