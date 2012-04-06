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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Windsor.Node2008.WNOSConnector.Admin;
using System.Drawing;

namespace Windsor.Node2008.Admin.Code
{
    public class ChartConfig
    {

        private readonly string _baseUrl;
        private readonly Size _size;
        private readonly string _type;
        private readonly ISimpleLookupDataService _dataProvider;
        private string _sectionTitle;
        private string _color;

        public ChartConfig(string baseUrl, Size size, string type, ISimpleLookupDataService dataProvider)
        {

            if (dataProvider == null)
            {
                throw new ArgumentException("Null DataProvider");
            }

            if (size == null)
            {
                throw new ArgumentException("Null Size");
            }

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException("Null BaseUrl");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Null Type");
            }

            _baseUrl = baseUrl;
            _size = size;
            _type = type;
            _dataProvider = dataProvider;
        }



        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string SectionTitle
        {
            get { return _sectionTitle; }
            set { _sectionTitle = value; }
        }

        public ISimpleLookupDataService DataProvider
        {
            get { return _dataProvider; }
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
        }

        public Size Size
        {
            get { return _size; }
        }

        public string Type
        {
            get { return _type; }
        }
    }
}
