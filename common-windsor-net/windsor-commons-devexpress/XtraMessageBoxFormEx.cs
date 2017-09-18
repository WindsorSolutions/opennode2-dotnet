namespace Windsor.Commons.DeveloperExpress
{
    using DevExpress.Accessibility;
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.Utils.Drawing;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    using Windsor.Commons.Core;

    public class XtraMessageBoxFormEx : BaseScalableForm
    {
        private SimpleButton[] buttons;
        private CheckEdit dontShowAgainCheckEdit;
        //private BaseAccessible dxAccessible;
        private Rectangle iconRectangle;
        private XtraMessageBoxArgsEx message;
        private Rectangle messageRectangle;
        private const int Spacing = 18;

        public XtraMessageBoxFormEx()
        {
            base.KeyPreview = true;
            this.message = new XtraMessageBoxArgsEx();
        }

        private void CalcFinalSizes()
        {
            int num = 0;
            foreach (SimpleButton button in this.buttons)
            {
                if (num != 0)
                {
                    num += Spacing;
                }
                num += button.Width;
            }
            int y = this.messageRectangle.Bottom + Spacing;
            if ((this.Message.Icon != null) && ((this.iconRectangle.Bottom + Spacing) > y))
            {
                y = this.iconRectangle.Bottom + Spacing;
            }
            int width = this.MinimumSize.Width;
            if (width == 0)
            {
                width = SystemInformation.MinimumWindowSize.Width;
            }
            if (width < (this.messageRectangle.Right + Spacing))
            {
                width = this.messageRectangle.Right + Spacing;
            }
            if (width < ((num + Spacing) + Spacing))
            {
                width = (num + Spacing) + Spacing;
            }
            GraphicsInfo info = new GraphicsInfo();
            info.AddGraphics(null);
            try
            {
                using (StringFormat format = TextOptions.DefaultStringFormat.Clone() as StringFormat)
                {
                    format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                    using (Font font = ControlUtils.GetCaptionFont())
                    {
                        int num4 = (SystemInformation.WorkingArea.Width / 3) * 2;
                        int num5 = 5 + ((int) info.Cache.CalcTextSize(this.Text, font, format, 0).Width);
                        int num6 = num5 + ((SystemInformation.CaptionButtonSize.Width * 5) / 4);
                        int num7 = Math.Min(num4, num6);
                        if (width < num7)
                        {
                            width = num7;
                        }
                    }
                }
            }
            finally
            {
                info.ReleaseGraphics();
            }
            base.Width = width + (2 * SystemInformation.FixedFrameBorderSize.Width);
            base.Height = (((y + this.buttons[0].Height) + Spacing) + (2 * SystemInformation.FixedFrameBorderSize.Height)) + SystemInformation.CaptionHeight;
            int x = (width - num) / 2;
            for (int i = 0; i < this.buttons.Length; i++)
            {
                this.buttons[i].Location = new Point(x, y);
                x += this.buttons[i].Width + Spacing;
            }
            if (this.Message.Icon == null)
            {
                this.messageRectangle.Offset((width - (this.messageRectangle.Right + Spacing)) / 2, 0);
            }
            if ((this.Message.Icon != null) && (this.messageRectangle.Height < this.iconRectangle.Height))
            {
                this.messageRectangle.Offset(0, (this.iconRectangle.Height - this.messageRectangle.Height) / 2);
            }
        }

        private void CalcIconBounds()
        {
            if (this.Message.Icon != null)
            {
                this.iconRectangle = new Rectangle(Spacing, Spacing, this.Message.Icon.Width, this.Message.Icon.Height);
            }
            else
            {
                this.iconRectangle = new Rectangle(Spacing, Spacing, 0, 0);
            }
        }

        private void CalcMessageBounds()
        {
            int y = Spacing;
            int x = (this.Message.Icon == null) ? Spacing : ((this.iconRectangle.Left + this.iconRectangle.Width) + Spacing);
            int width = this.MaximumSize.Width;
            if (width <= 0)
            {
                //width = SystemInformation.WorkingArea.Width;
                width = SystemInformation.WorkingArea.Width / 2;
            }
            int num6 = (width - Spacing) - x;
            if (num6 < 10)
            {
                num6 = 10;
            }
            GraphicsInfo info = new GraphicsInfo();
            info.AddGraphics(null);
            SizeF ef = this.GetPaintAppearance().CalcTextSize(info.Graphics, this.Message.Text, num6);
            info.ReleaseGraphics();
            int num3 = (int) Math.Ceiling((double) ef.Width);
            int height = this.MaximumSize.Height;
            if (height <= 0)
            {
                height = SystemInformation.WorkingArea.Height;
            }
            int num8 = ((((height - Spacing) - this.buttons[0].Height) - Spacing) - y) - SystemInformation.CaptionHeight;
            if (num8 < 10)
            {
                num8 = 10;
            }
            int num4 = (int) Math.Ceiling((double) ef.Height);
            if (num4 > num8)
            {
                num4 = num8;
            }
            this.messageRectangle = new Rectangle(x, y, num3, num4);
        }

        //protected override AccessibleObject CreateAccessibilityInstance()
        //{
        //    if (this.DXAccessible == null)
        //    {
        //        return base.CreateAccessibilityInstance();
        //    }
        //    return this.DXAccessible.Accessible;
        //}

        private void CreateButtons()
        {
            if ((this.Message.Buttons == null) || (this.Message.Buttons.Length <= 0))
            {
                throw new ArgumentException("At least one button must be specified", "buttons");
            }
            this.buttons = new SimpleButton[this.Message.Buttons.Length];
            for (int i = 0; i < this.Message.Buttons.Length; i++)
            {
                SimpleButton button = new SimpleButton();
                button.LookAndFeel.Assign(base.LookAndFeel);
                this.buttons[i] = button;
                button.DialogResult = this.Message.Buttons[i];
                if (button.DialogResult == DialogResult.None)
                {
                    throw new ArgumentException("The 'DialogResult.None' button cannot be specified", "buttons");
                }
                if (button.DialogResult == DialogResult.Cancel)
                {
                    base.CancelButton = button;
                }
                button.Text = this.GetButtonText(button.DialogResult);
                int width = button.CalcBestSize().Width;
                if (width > button.Width)
                {
                    button.Width = width;
                }
                base.Controls.Add(button);
            }
            if (this.buttons.Length == 1)
            {
                base.CancelButton = this.buttons[0];
            }
            if (this.Message.DefaultButtonIndex >= this.buttons.Length)
            {
                this.Message.DefaultButtonIndex = 0;
            }
            this.buttons[this.Message.DefaultButtonIndex].Select();
        }

        private void DisableCloseButtonIfNeeded()
        {
            if (base.CancelButton == null)
            {
                base.ControlBox = false;
            }
        }

        protected virtual DialogResult DoShowDialog(IWin32Window owner)
        {
            DialogResult result = base.ShowDialog(owner);
            if (dontShowAgainCheckEdit != null)
            {
                message.DontShowAgainChecked = dontShowAgainCheckEdit.Checked;
            }
            base.Dispose();
            if (Array.IndexOf<DialogResult>(this.Message.Buttons, result) != -1)
            {
                return result;
            }
            return this.Message.Buttons[0];
        }

        protected virtual string GetButtonText(DialogResult target)
        {
            switch (target)
            {
                case DialogResult.OK:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxOkButtonText);

                case DialogResult.Cancel:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxCancelButtonText);

                case DialogResult.Abort:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxAbortButtonText);

                case DialogResult.Retry:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxRetryButtonText);

                case DialogResult.Ignore:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxIgnoreButtonText);

                case DialogResult.Yes:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxYesButtonText);

                case DialogResult.No:
                    return Localizer.Active.GetLocalizedString(StringId.XtraMessageBoxNoButtonText);
            }
            return ('&' + target.ToString());
        }

        private AppearanceObject GetPaintAppearance()
        {
            AppearanceObject obj2 = new AppearanceObject(base.Appearance, base.DefaultAppearance);
            obj2.TextOptions.WordWrap = WordWrap.Wrap;
            obj2.TextOptions.VAlignment = VertAlignment.Top;
            obj2.TextOptions.Trimming = Trimming.EllipsisCharacter;
            return obj2;
        }

        //protected internal AccessibleObject GetParentAccessible()
        //{
        //    return base.CreateAccessibilityInstance().Parent;
        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            if ((base.CancelButton == null) && (base.DialogResult == DialogResult.Cancel))
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (this.Message.exception != null)
            {
                string message = ExceptionUtils.ToLongString(this.Message.exception);
                XtraMessageBoxEx.Show(message, Application.ProductName + " Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x0003')
            {
                e.Handled = true;
                Clipboard.SetDataObject(this.message.Caption + Environment.NewLine + Environment.NewLine + this.message.Text, true);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsCache cache = new GraphicsCache(e))
            {
                if (this.Message.Icon != null)
                {
                    cache.Graphics.DrawIcon(this.Message.Icon, this.iconRectangle);
                }
                this.GetPaintAppearance().DrawString(cache, this.Message.Text, this.messageRectangle);
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (base.Visible && !base.ContainsFocus)
            {
                base.Activate();
            }
        }

        private DialogResult ShowMessageBoxDialog()
        {
            if (this.Message.GetLookAndFeel() != null)
            {
                base.LookAndFeel.Assign(this.Message.GetLookAndFeel());
            }
            if (!this.AllowCustomLookAndFeel && (base.LookAndFeel.ActiveStyle != ActiveLookAndFeelStyle.Skin))
            {
                if (UserLookAndFeel.Default.ActiveStyle == ActiveLookAndFeelStyle.Office2003)
                {
                    base.LookAndFeel.SetStyle(LookAndFeelStyle.Office2003, true, false, "");
                }
                else
                {
                    base.LookAndFeel.SetDefaultStyle();
                }
            }
            this.Text = this.Message.Caption;
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MinimizeBox = false;
            base.MaximizeBox = false;
            IWin32Window owner = this.Message.Owner;
            if (owner == null)
            {
                Form activeForm = Form.ActiveForm;
                if ((activeForm != null) && !activeForm.InvokeRequired)
                {
                    owner = activeForm;
                }
            }
            if (owner != null)
            {
                Control control = owner as Control;
                if (control != null)
                {
                    if (!control.Visible)
                    {
                        owner = null;
                    }
                    else
                    {
                        Form form2 = control.FindForm();
                        if ((form2 != null) && ((!form2.Visible || (form2.WindowState == FormWindowState.Minimized)) || ((form2.Right <= 0) || (form2.Bottom <= 0))))
                        {
                            owner = null;
                        }
                    }
                }
            }
            if (owner == null)
            {
                base.ShowInTaskbar = true;
                base.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                base.ShowInTaskbar = false;
                base.StartPosition = FormStartPosition.CenterParent;
            }
            this.CreateButtons();
            this.CalcIconBounds();
            this.CalcMessageBounds();
            this.CalcFinalSizes();
            this.DisableCloseButtonIfNeeded();
            this.AdjustForDontShowAgainCheckBox();
            Form form3 = owner as Form;
            if ((form3 != null) && form3.TopMost)
            {
                base.TopMost = true;
            }
            return this.DoShowDialog(owner);
        }

        public DialogResult ShowMessageBoxDialog(XtraMessageBoxArgsEx message)
        {
            this.message = message;
            return this.ShowMessageBoxDialog();
        }

        protected virtual void AdjustForDontShowAgainCheckBox()
        {
            if (string.IsNullOrEmpty(message.DontShowAgainText))
            {
                return;
            }
            dontShowAgainCheckEdit = new CheckEdit();
            dontShowAgainCheckEdit.LookAndFeel.Assign(base.LookAndFeel);
            dontShowAgainCheckEdit.Text = message.DontShowAgainText;
            dontShowAgainCheckEdit.Checked = message.DontShowAgainChecked;
            dontShowAgainCheckEdit.Location = new Point(messageRectangle.Left, messageRectangle.Bottom + Spacing);
            dontShowAgainCheckEdit.Properties.AutoHeight = true;
            dontShowAgainCheckEdit.Properties.AutoWidth = true;
            base.Controls.Add(dontShowAgainCheckEdit);
            int delta = dontShowAgainCheckEdit.Bottom - messageRectangle.Bottom;
            this.Height = this.Height + delta;
            foreach (SimpleButton button in buttons)
            {
                button.Top = button.Top + delta;
            }
        }

        protected virtual bool AllowCustomLookAndFeel
        {
            get
            {
                return XtraMessageBox.AllowCustomLookAndFeel;
            }
        }

        protected override bool AllowSkinForEmptyText
        {
            get
            {
                return true;
            }
        }

        //protected internal virtual BaseAccessible DXAccessible
        //{
        //    get
        //    {
        //        if (this.dxAccessible == null)
        //        {
        //            this.dxAccessible = new MessageBoxAccessible(this);
        //        }
        //        return this.dxAccessible;
        //    }
        //}

        public Rectangle IconRectangle
        {
            get
            {
                return this.iconRectangle;
            }
        }

        protected internal XtraMessageBoxArgsEx Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public Rectangle MessageRectangle
        {
            get
            {
                return this.messageRectangle;
            }
        }
    }
}
