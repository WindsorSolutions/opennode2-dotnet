using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public class UseWaitCursor : DisposableBase
    {
        public UseWaitCursor()
        {
            foreach (Form form in Application.OpenForms)
            {
                form.UseWaitCursor = true;
                form.Cursor = Cursors.WaitCursor;
            }
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.UseWaitCursor = false;
                    form.Cursor = Cursors.Arrow;
                }
            }
        }
    }
}
