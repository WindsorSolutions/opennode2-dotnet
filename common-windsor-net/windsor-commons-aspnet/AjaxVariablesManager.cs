using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Windsor.Commons.Core;
using System.Text;
using System.Web.Script.Serialization;

namespace Windsor.Commons.AspNet
{
    public abstract class AjaxVariables
    {
        // Construct this class in the Page.OnInit() event
        public AjaxVariables(Page page, HiddenField hiddenField)
        {
            m_HiddenField = hiddenField;
            m_Page = page;
            m_JavaScriptSerializer = new JavaScriptSerializer();
            m_Page.PreLoad += new EventHandler(OnPagePreLoad);
            m_Page.PreRender += new EventHandler(OnPagePreRender);
        }

        protected virtual void OnPagePreLoad(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_HiddenField.Value))
            {
                Dictionary<string, object> values = (Dictionary<string, object>) 
                    m_JavaScriptSerializer.DeserializeObject(m_HiddenField.Value);
                values.CopyValuePropertiesTo(this);
            }
        }
        protected virtual void OnPagePreRender(object sender, EventArgs e)
        {
            m_HiddenField.Value = m_JavaScriptSerializer.Serialize(this);
        }

        protected HiddenField m_HiddenField;
        protected Page m_Page;
        protected JavaScriptSerializer m_JavaScriptSerializer;
    }
}