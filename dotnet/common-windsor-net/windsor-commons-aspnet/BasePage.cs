using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Windsor.Commons.Core;
using System.Text;

namespace Windsor.Commons.AspNet
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            RegisteredScriptBlocks = new StringBuilder();
            ClientIdsToPublish = new Dictionary<string, string>();
            UniqueIdsToPublish = new Dictionary<string, string>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public virtual void RegisterScriptBlock(string clientScript)
        {
            lock (RegisteredScriptBlocks)
            {
                RegisteredScriptBlocks.Append(clientScript);
            }
        }

        public void PublishClientId(Control control)
        {
            DebugUtils.AssertDebuggerBreak(!string.IsNullOrEmpty(control.ID));
            DebugUtils.AssertDebuggerBreak(!string.IsNullOrEmpty(control.ClientID));
            ClientIdsToPublish[control.ID] = control.ClientID;
        }

        public void PublishUniqueId(Control control)
        {
            DebugUtils.AssertDebuggerBreak(!string.IsNullOrEmpty(control.ID));
            DebugUtils.AssertDebuggerBreak(!string.IsNullOrEmpty(control.UniqueID));
            UniqueIdsToPublish[control.ID] = control.UniqueID;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            PublishIds(ClientIdsToPublish, "g_ClientIds");
            PublishIds(UniqueIdsToPublish, "g_UniqueIds");

            if (RegisteredScriptBlocks.Length > 0)
            {
                string scriptBlocks = RegisteredScriptBlocks.ToString();
                AspNetUtils.RegisterScriptBlock(this, scriptBlocks);
            }
        }
        protected virtual void PublishIds(Dictionary<string, string> ids, string javascriptVarName)
        {
            if (!CollectionUtils.IsNullOrEmpty(ids))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("var {0} = {{ ", javascriptVarName);
                bool addedFirst = false;
                foreach (var pair in ClientIdsToPublish)
                {
                    if (addedFirst)
                    {
                        sb.Append(", ");
                    }
                    sb.AppendFormat("{0}: \"{1}\"", pair.Key, pair.Value);
                    addedFirst = true;
                }
                sb.Append(" };");

                RegisterScriptBlock(sb.ToString());
            }
        }
        
        protected virtual StringBuilder RegisteredScriptBlocks
        {
            get;
            set;
        }
        protected virtual Dictionary<string, string> ClientIdsToPublish
        {
            get;
            set;
        }
        protected virtual Dictionary<string, string> UniqueIdsToPublish
        {
            get;
            set;
        }
    }
}