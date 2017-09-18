using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Windsor.Commons.WinForms
{
    public class MultiView : TabControl
    {
        public MultiView()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                //cp.ExStyle |= 0x02000000 | 0x00000020;
                return cp;
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            SetupRegion();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            SetupRegion();
        }
        protected void SetupRegion()
        {
            try
            {
                Rectangle displayRectangle = this.DisplayRectangle;
                if ((displayRectangle.Width >= 0) && (displayRectangle.Height >= 0))
                {
                    this.Region = new Region(new Rectangle(displayRectangle.Left, displayRectangle.Top,
                                                           displayRectangle.Width, displayRectangle.Height));
                }
                else
                {
                    this.Region = new Region(new Rectangle(displayRectangle.Left, displayRectangle.Top, 0, 0));
                }
            }
            catch (Exception)
            {
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0x000F;
            const int WM_ERASEBKGND = 0x0014;

            switch (m.Msg)
            {
                case WM_PAINT:
                    Win32.PAINTSTRUCT ps;
                    IntPtr hdc = Win32.BeginPaint(this.Handle, out ps);
                    Win32.EndPaint(this.Handle, ref ps);
                    return;
                case WM_ERASEBKGND:
                    return;
            }
            base.WndProc(ref m);
        }
    }
}
