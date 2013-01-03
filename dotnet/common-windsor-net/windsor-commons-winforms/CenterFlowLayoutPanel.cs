using System;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public class CenterFlowLayoutPanel : FlowLayoutPanel
    {
        protected bool _centerVertically;
        protected bool _centerHorizontally;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            CenterControls();
        }
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            CenterControls();
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            CenterControls();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                CenterControls();
            }
        }
        [Description("Gets or sets whether or not the control will center all of its controls vertically.")]
        [DefaultValue(false)]
        [Category("Extra")]
        public bool CenterVertically
        {
            get
            {
                return _centerVertically;
            }
            set
            {
                if (_centerVertically != value)
                {
                    _centerVertically = value;
                    CenterControls();
                }
            }
        }
        [Description("Gets or sets whether or not the control will center all of its controls horizontally.")]
        [DefaultValue(false)]
        [Category("Extra")]
        public bool CenterHorizontally
        {
            get
            {
                return _centerHorizontally;
            }
            set
            {
                if (_centerHorizontally != value)
                {
                    _centerHorizontally = value;
                    CenterControls();
                }
            }
        }

        public virtual void CenterControls()
        {
            int paddingTop = 0, paddingLeft = 0;
            if (_centerHorizontally || _centerVertically)
            {
                Rectangle childrenBox = ControlUtils.GetChildControlsBoundingBox(this);
                if (!childrenBox.IsEmpty)
                {
                    childrenBox.Offset(-Padding.Left, -Padding.Top);
                    Rectangle clientBox = this.ClientRectangle;
                    clientBox = new Rectangle(clientBox.Left - Padding.Left, clientBox.Top - Padding.Top, 
                                              clientBox.Width + Padding.Left, clientBox.Height + Padding.Top);
                    if (_centerHorizontally)
                    {
                        paddingLeft = (clientBox.Width - childrenBox.Width + 1) / 2;
                        if (paddingLeft < 0)
                        {
                            paddingLeft = 0;
                        }
                    }
                    if (_centerVertically)
                    {
                        paddingTop = (clientBox.Height - childrenBox.Height + 1) / 2;
                        if (paddingTop < 0)
                        {
                            paddingTop = 0;
                        }
                    }
                }
            }
            this.Padding = new Padding(paddingLeft, paddingTop, 0, 0);
        }
    }
}
