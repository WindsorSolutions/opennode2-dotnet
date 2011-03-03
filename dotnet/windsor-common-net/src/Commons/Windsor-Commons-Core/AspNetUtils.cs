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
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Windsor.Commons.Core
{
    public static class AspNetUtils
    {
        public static T FindControl<T>(Control parent) where T : class
        {
            foreach (Control control in parent.Controls)
            {
                if (control is T)
                {
                    return control as T;
                }
            }
            return null;
        }
        public static T FindDeepControl<T>(Control parent) where T : class
        {
            foreach (Control control in parent.Controls)
            {
                if (control is T)
                {
                    return control as T;
                }
                T foundControl = FindDeepControl<T>(control);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }
            return null;
        }
        public static T FindDeepControl<T>(Control parent, string id) where T : class
        {
            return FindDeepControl(parent, id) as T;
        }
        public static Control FindDeepControl(Control parent, string id)
        {
            foreach (Control control in parent.Controls)
            {
                if ((control.ID == id) || (control.ClientID == id) || (control.UniqueID == id))
                {
                    return control;
                }
                Control foundControl = FindDeepControl(control, id);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }
            return null;
        }
        public static IList<T> FindDeepControls<T>(Control parent, string id) where T : Control
        {
            List<T> list = null;
            FindDeepControls(parent, id, ref list);
            return list;
        }
        public static Control GetPostBackControl(Page page)
        {
            Control postbackControlInstance = null;

            string postbackControlName = page.Request.Params.Get("__EVENTTARGET");
            if (!string.IsNullOrEmpty(postbackControlName))
            {
                postbackControlInstance = FindDeepControl(page, postbackControlName);
            }
            else
            {
                // handle the Button control postbacks
                for (int i = page.Request.Form.Keys.Count - 1; i >= 0; --i)
                {
                    string key = page.Request.Form.Keys[i];
                    if (!string.IsNullOrEmpty(key))
                    {
                        postbackControlInstance = FindDeepControl(page, key);
                        if (postbackControlInstance is System.Web.UI.WebControls.Button)
                        {
                            return postbackControlInstance;
                        }
                    }
                }
            }
            // handle the ImageButton postbacks
            if (postbackControlInstance == null)
            {
                for (int i = page.Request.Form.Keys.Count - 1; i >= 0; --i)
                {
                    string key = page.Request.Form.Keys[i];
                    if (!string.IsNullOrEmpty(key))
                    {
                        if ((key.EndsWith(".x")) || (key.EndsWith(".y")))
                        {
                            string controlId = key.Substring(0, page.Request.Form.Keys[i].Length - 2);
                            postbackControlInstance = FindDeepControl(page, controlId);
                            if (postbackControlInstance is System.Web.UI.WebControls.ImageButton)
                            {
                                return postbackControlInstance;
                            }
                        }
                    }
                }
            }
            return postbackControlInstance;
        }
        public static void SetFocus(System.Web.UI.Page page, Control control, bool selectAll)
        {
            if (page.ClientScript.IsClientScriptBlockRegistered("SetMainControlFocus"))
            {
                return;
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("\r\n<script language='JavaScript'>\r\n");
            sb.Append("<!--\r\n");
            sb.Append("function SetMainControlFocus()\r\n");
            sb.Append("{\r\n");

            Control p = control.Parent;
            while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent;

            sb.Append("\tdocument.");
            sb.Append(p.ClientID);
            sb.Append("['");
            sb.Append(control.UniqueID);
            sb.Append("'].focus();\r\n");
            if (selectAll && (control is TextBox))
            {
                sb.Append("\tdocument.");
                sb.Append(p.ClientID);
                sb.Append("['");
                sb.Append(control.UniqueID);
                sb.Append("'].select();\r\n");
            }
            sb.Append("}\r\n");
            sb.Append("window.onload = SetMainControlFocus;\r\n");
            sb.Append("// -->\r\n");
            sb.Append("</script>");

            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "SetMainControlFocus", sb.ToString());
        }
        private static void FindDeepControls<T>(Control parent, string id,
                                                ref List<T> list) where T : Control
        {
            foreach (Control control in parent.Controls)
            {
                if (control.ID == id)
                {
                    T value = control as T;
                    if (value != null)
                    {
                        if (list == null)
                        {
                            list = new List<T>();
                        }
                        list.Add(value);
                    }
                }
                FindDeepControls(control, id, ref list);
            }
        }
        public static void RegisterCssFile(Control control, string cssFilePageRelativePath)
        {
            HtmlLink css = new HtmlLink();
            css.Href = cssFilePageRelativePath;
            css.Attributes["rel"] = "stylesheet";
            css.Attributes["type"] = "text/css";
            control.Page.Header.Controls.Add(css);
        }

        public static void RegisterScriptFile(Control control, string scriptFilePageRelativePath)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "text/javascript");
            script.Attributes.Add("src", scriptFilePageRelativePath);
            control.Page.Header.Controls.Add(script);
        }
        public static void RegisterScriptBlock(Control control, string clientScript)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "text/javascript");
            script.Attributes.Add("language", "javascript");
            script.InnerHtml = clientScript;
            control.Page.Header.Controls.Add(script);
        }
        public static List<string> GetSelectedValues(ListBox listBox)
        {
            List<string> selectedValues = null;
            foreach (ListItem item in listBox.Items)
            {
                if (item.Selected)
                {
                    CollectionUtils.Add(item.Value, ref selectedValues);
                }
            }
            return selectedValues;
        }
        public static void SetSelectedValues(ListBox listBox, ICollection<string> selectedValues)
        {
            listBox.SelectedIndex = -1;
            if (CollectionUtils.IsNullOrEmpty(selectedValues))
            {
                return;
            }
            foreach (ListItem item in listBox.Items)
            {
                if (selectedValues.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
        }
    }
}