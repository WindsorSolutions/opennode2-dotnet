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
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;

namespace Windsor.Node2008.Admin
{

    public static class UIUtility
    {


        public static string ParseException(Exception ex)
        {

            StringBuilder sb = new StringBuilder();

            while (ex != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" --> ");
                }
                sb.Append(ex.Message);
                //sb.AppendFormat("{0} ", ex.Message);
                ex = ex.InnerException;
            }

            return sb.ToString();

        }

        public static void SetConfirmMessage(Button button, string message)
        {
            button.Attributes.Add("onclick", string.Format("return confirm('{0}');", message));
        }

        public static IList<KeyValuePair<K, V>>
            GetSortedList<K, V>(IDictionary<K, V> dictionary) where V : IComparable<V>
        {
            if (dictionary == null)
            {
                return null;
            }
            List<KeyValuePair<K, V>> sortedList =
                new List<KeyValuePair<K, V>>(dictionary);
            sortedList.Sort(
                delegate(KeyValuePair<K, V> first,
                         KeyValuePair<K, V> second)
                {
                    return first.Value.CompareTo(second.Value);
                }
            );
            return sortedList;
        }
        public static IList<KeyValuePair<K, V>>
            GetSortedList<K, V>(IDictionary<K, V> dictionary, Comparison<KeyValuePair<K, V>> comparison)
        {
            if (dictionary == null)
            {
                return null;
            }
            List<KeyValuePair<K, V>> sortedList =
                new List<KeyValuePair<K, V>>(dictionary);
            sortedList.Sort(comparison);
            return sortedList;
        }
        public static string UriEscapeDataString(object dataStr)
        {
            return (dataStr == null) ? string.Empty : Uri.EscapeDataString(dataStr.ToString());
        }
        public static string HtmlEscapeDataString(object dataStr)
        {
            return (dataStr == null) ? string.Empty : HttpUtility.HtmlEncode(dataStr.ToString());
        }
        public static string GetImageUrlForActivityType(Activity activity)
        {
            if ((activity.Method == NodeMethod.Authenticate) || (activity.Method == NodeMethod.AdminLogin))
            {
                return (activity.Type == ActivityType.Error) ?
                    "../Images/UI/key_delete.png" : "../Images/UI/key_go.png";
            }
            else if (activity.Method == NodeMethod.Schedule)
            {
                return (activity.Type == ActivityType.Error) ?
                    "../Images/UI/exclamation.png" : "../Images/UI/accept.png";
            }
            else if (EnumUtils.IsBetween(activity.Method, NodeMethod.Submit, NodeMethod.GetServices))
            {
                if (activity.Type == ActivityType.Error)
                {
                    return "../Images/UI/exclamation.png";
                }
                else
                {
                    return (activity.Type == ActivityType.Audit) ?
                        "../Images/UI/connect.png" : "../Images/UI/server_connect.png";
                        //"../Images/UI/plug-connect.png" : "../Images/UI/server_connect.png";
                }
            }
            switch (activity.Type)
            {
                case ActivityType.Info: return "../Images/UI/information.png";
                case ActivityType.Error: return "../Images/UI/exclamation.png";
                case ActivityType.Audit: return "../Images/UI/information.png";
                default: return "../Images/UI/information.png";
            }
        }
        public static string GetActivityTypeDescription(Activity activity)
        {
            return EnumUtils.ToDescription(activity.Type);
        }
    }

}
