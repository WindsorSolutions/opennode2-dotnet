using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Windsor.Commons.WinForms;
using Windsor.Commons.Core;

namespace Windsor.Commons.DeveloperExpress
{
    public partial class BaseScalableForm : DevExpress.XtraEditors.XtraForm
    {
        protected BaseScalableForm()
        {
            if (!this.DesignMode && FormScaler.NeedsToScale)
            {
                this.Font = FormScaler.ScaleFont(this.Font);
            }
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();

            FormScaler.ScaleFonts(this);
        }
    }
}