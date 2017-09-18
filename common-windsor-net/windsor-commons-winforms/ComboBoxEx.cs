using System;
using System.Text;
using System.Windows.Forms;

namespace Windsor.Commons.WinForms
{
    public class ComboBoxEx : ComboBox
    {
        const int WM_SIZE = 5;

        protected void SetRedraw(bool allowRedraw)
        {
            Message m = new Message();
            m.HWnd = this.Handle; //top level
            m.WParam = (IntPtr)(allowRedraw ? 1 : 0); //disable redraw
            m.LParam = (IntPtr)0; //unused
            m.Msg = 11; //wm_setredraw
            WndProc(ref m);
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SIZE:
                    // Get rid of "select all" behaviour when resized
                    int saveSelectionStart = this.SelectionStart;
                    int saveSelectionLength = this.SelectionLength;
                    SetRedraw(false);
                    base.WndProc(ref m);
                    SetRedraw(true);
                    this.SelectionStart = saveSelectionStart;
                    this.SelectionLength = saveSelectionLength;
                    this.Refresh();
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
