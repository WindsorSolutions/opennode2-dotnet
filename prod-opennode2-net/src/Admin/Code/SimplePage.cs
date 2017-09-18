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

using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin
{
    public class SimplePageSessionModelPersistenceMedium : Spring.Web.UI.SessionModelPersistenceMedium
    {
        protected override string GetKey(Control context)
        {
            SimplePage page = context as SimplePage;
            if ((page != null) && !string.IsNullOrEmpty(page.UniqueDataModelKey))
            {
                return context.Page.Request.CurrentExecutionFilePath + page.UniqueDataModelKey + ".Model";
            }
            else
            {
                return base.GetKey(context);
            }
        }
    }
    public class SimplePage : Spring.Web.UI.Page
    {
        private string _sectionHeadline;
        private string _sectionHeadlineEdit;
        private string[] _introParagraphs;
        private string[] _introParagraphsEdit;
        private readonly string refreshName;
        protected Control _postbackControl;

        protected const string NOT_SELECTED_TEXT = "[Not Selected]";

        public SimplePage()
        {
            refreshName = this.GetType().Name + "__ISREFRESH";
            ModelPersistenceMedium = new SimplePageSessionModelPersistenceMedium();
        }
        protected override void OnLoad(EventArgs e)
        {
            if (IsPostBack)
            {
                _postbackControl = AspNetUtils.GetPostBackControl(this);
            }
            base.OnLoad(e);
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            base.OnInitializeControls(e);
        }
        public virtual string UniqueDataModelKey
        {
            get { return this.UniqueID; }
        }
        public virtual bool IsEditPage
        {
            get
            {
                return (Request.QueryString.Count > 0) && (Request.QueryString["id"] != null);
            }
        }
        public virtual string GetSectionHeadline()
        {
            if (IsEditPage && !string.IsNullOrEmpty(SectionHeadlineEdit))
            {
                return SectionHeadlineEdit;
            }
            return SectionHeadline;
        }
        public virtual string[] GetIntroParagraphs()
        {
            if (IsEditPage && !CollectionUtils.IsNullOrEmpty(IntroParagraphsEdit))
            {
                return IntroParagraphsEdit;
            }
            return IntroParagraphs;
        }
        public string SectionHeadline
        {
            get
            {
                return _sectionHeadline;
            }
            set
            {
                _sectionHeadline = value;
            }
        }
        public string SectionHeadlineEdit
        {
            get { return _sectionHeadlineEdit; }
            set { _sectionHeadlineEdit = value; }
        }
        public string[] IntroParagraphs
        {
            get { return _introParagraphs; }
            set { _introParagraphs = value; }
        }
        public string[] IntroParagraphsEdit
        {
            get { return _introParagraphsEdit; }
            set { _introParagraphsEdit = value; }
        }
        public static void ResponseRedirect(string url)
        {
            HttpContext.Current.Response.Redirect(url, false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        public static string UriEscapeDataString(object dataStr)
        {
            return UIUtility.UriEscapeDataString(dataStr);
        }
        protected void ServerValidateRequiredIfVisible(Object source, ServerValidateEventArgs e)
        {
            CustomValidator validator = (CustomValidator)source;
            Control control = AspNetUtils.FindDeepControl(this, validator.ControlToValidate);
            e.IsValid = true;
            if (control != null)
            {
                if (control.Visible)
                {
                    TextBox textBox = control as TextBox;
                    if (textBox != null)
                    {
                        string text = textBox.Text.Trim();
                        e.IsValid = (text.Length > 0);
                    }
                }
            }
        }
        protected void ServerValidateNotSelectedControl(Object source, ServerValidateEventArgs e)
        {
            CustomValidator validator = (CustomValidator)source;
            Control control = AspNetUtils.FindDeepControl(this, validator.ControlToValidate);
            e.IsValid = true;
            if (control != null)
            {
                DropDownList dropDownList = control as DropDownList;
                if (dropDownList != null)
                {
                    string text = dropDownList.SelectedItem.Text;
                    e.IsValid = (text != NOT_SELECTED_TEXT);
                }
            }
        }
        protected static void AppendSortOrderImageToGridHeader(GridViewRow row, string sortProperty, bool sortAscending)
        {
            GridView gridView = row.NamingContainer as GridView;
            if (gridView == null)
            {
                return;
            }

            int foundColumnIndex = -1;

            for (int i = 0; i < gridView.Columns.Count; ++i)
            {
                if (sortProperty == gridView.Columns[i].SortExpression)
                {
                    foundColumnIndex = i;
                }
            }

            if (foundColumnIndex > -1)
            {
                Image sortImage = new Image();
                if (sortAscending)
                {
                    sortImage.ImageUrl = "~/Images/UI/sortascending.gif";
                    sortImage.AlternateText = "Ascending";
                }
                else
                {
                    sortImage.ImageUrl = "~/Images/UI/sortdescending.gif";
                    sortImage.AlternateText = "Descending";
                }
                sortImage.ImageAlign = ImageAlign.Top;

                // Add the image to the appropriate header cell.
                row.Cells[foundColumnIndex].Controls.Add(sortImage);
            }
        }
        protected virtual void DoDownloadResponse(byte[] content, string documentName, CommonContentType contentType)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition",
                string.Format("attachment;filename=\"{0}\"", documentName));
            Response.AddHeader("Content-Length", content.Length.ToString());
            Response.ContentType = CommonContentAndFormatProvider.ConvertToMimeType(contentType);
            Response.BinaryWrite(content);
            Response.End();
        }
    }
}
