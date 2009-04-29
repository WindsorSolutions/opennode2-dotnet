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
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Caching;
using System.ComponentModel;
using Spring.Context;
using Spring.Context.Support;
using System.IO;
using System.Web.Configuration;
using System.Text;
using System.Xml;
using System.Reflection;
using Common.Logging;
using Spring.Objects.Factory;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSUtility;
using System.Drawing;
using Windsor.Node2008.WNOSConnector.Admin;

namespace Windsor.Node2008.Admin.Secure
{

    public class ImageRequestHandler : IHttpHandler
    {

        public T Get<T>(string id)
        {

            T item;
            object test = HttpContext.Current.Cache[id];

            if (test == null)
            {
                IApplicationContext ctx = ContextRegistry.GetContext();
                item = (T)ctx.GetObject(id);
            }
            else
            {
                item = (T)test;
            }

            return item;

        }

        public void ProcessRequest(HttpContext context)
        {

            Size size = Get<Size>("chartSize");
            IImageSourceService dataProvider = Get<IImageSourceService>("activityManagerService");

            byte[] bytImage = dataProvider.GetImage(size);
            context.Response.ContentType = "image/png";
            context.Response.Expires = 0;
            context.Response.Buffer = true;
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Clear();
            context.Response.BinaryWrite(bytImage);
            context.Response.End();
        }


        public bool IsReusable
        {
            get { return true; }
        }
    }
}
