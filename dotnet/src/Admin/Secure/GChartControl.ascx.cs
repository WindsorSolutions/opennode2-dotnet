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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Windsor.Node2008.Admin.Code;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class GChartControl : System.Web.UI.UserControl
    {

        public void Display(ChartConfig config)
        {
            if (config == null)
            {
                throw new ArgumentException("Null Config");
            }

            chartTitle.Text = config.SectionTitle;

            //Size
            chartImage.Width = config.Size.Width;
            chartImage.Height = config.Size.Height;
            chartImage.AlternateText = "Chart: " + config.SectionTitle;
            chartImage.BorderWidth = 0;

            Dictionary<string, string> chartData = config.DataProvider.GetLookupData();

            List<string> dataArray = new List<string>();
            List<string> labelArray = new List<string>();

            dataArray.AddRange(chartData.Values);
            labelArray.AddRange(chartData.Keys);

            StringBuilder sb = new StringBuilder();
            sb.Append(config.BaseUrl);

            sb.AppendFormat("cht={0}", config.Type);
            sb.AppendFormat("&chs={0}x{1}", config.Size.Width, config.Size.Height);
            sb.AppendFormat("&chd=t:{0}", string.Join(",", dataArray.ToArray()));
            sb.AppendFormat("&chl={0}", string.Join("|", labelArray.ToArray()));

            if (!string.IsNullOrEmpty(config.Color))
            {
                sb.AppendFormat("&chco={0}", config.Color);
            }

            chartImage.ImageUrl = sb.ToString();


        }


        //http://chart.apis.google.com/chart?
        //chs=250x100
        //&chd=t:60,40
        //&cht=p3
        //&chl=Hello|World

        //Where:

        //http://chart.apis.google.com/chart? is the Chart API's location. 
        //& separates parameters. 
        //chs=250x100 is the chart's size in pixels. 
        //chd=t:60,40 is the chart's data. 
        //cht=p3 is the chart's type. 
        //chl=Hello|World is the chart's label. 

        //<img src="http://chart.apis.google.com/chart?
        //chs=250x100
        //&amp;chd=t:60,40
        //&amp;cht=p3
        //&amp;chl=Hello|World" 
        //alt="Sample chart" />



    }
}