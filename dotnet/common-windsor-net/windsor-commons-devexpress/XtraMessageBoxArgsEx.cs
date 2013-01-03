namespace Windsor.Commons.DeveloperExpress
{
    using DevExpress.LookAndFeel;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;

    public class XtraMessageBoxArgsEx
    {
        private DialogResult[] buttons;
        private string caption;
        private int defaultButtonIndex;
        private System.Drawing.Icon icon;
        private UserLookAndFeel lookAndFeel;
        private IWin32Window owner;
        private string text;
        private string dontShowAgainText = "Don't show again";
        private bool dontShowAgainChecked;
        internal Exception exception;

        public XtraMessageBoxArgsEx() : this(null, string.Empty, string.Empty, new DialogResult[0], null, 0)
        {
        }

        public XtraMessageBoxArgsEx(IWin32Window owner, string text, string caption, DialogResult[] buttons, System.Drawing.Icon icon, int defaultButtonIndex) : 
            this(null, owner, text, caption, buttons, icon, defaultButtonIndex, null, false)
        {
        }

        public XtraMessageBoxArgsEx(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, System.Drawing.Icon icon, int defaultButtonIndex,
                                    string dontShowAgainText, bool dontShowAgainChecked) :
            this(lookAndFeel, owner, text, caption, buttons, icon, defaultButtonIndex, dontShowAgainText, dontShowAgainChecked, (Exception) null)
        {
        }
        public XtraMessageBoxArgsEx(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, System.Drawing.Icon icon, int defaultButtonIndex,
                                    string dontShowAgainText, bool dontShowAgainChecked, Exception ex)
        {
            this.lookAndFeel = lookAndFeel;
            this.owner = owner;
            this.text = text;
            this.caption = caption;
            this.buttons = buttons;
            this.icon = icon;
            this.defaultButtonIndex = defaultButtonIndex;
            this.dontShowAgainText = dontShowAgainText;
            this.dontShowAgainChecked = dontShowAgainChecked;
            this.exception = ex;
        }

        public UserLookAndFeel GetLookAndFeel()
        {
            if (this.lookAndFeel != null)
            {
                return this.lookAndFeel;
            }
            BaseScalableForm owner = this.Owner as BaseScalableForm;
            if (owner != null)
            {
                return owner.LookAndFeel;
            }
            return null;
        }

        public DialogResult[] Buttons
        {
            get
            {
                return this.buttons;
            }
            set
            {
                this.buttons = value;
            }
        }

        public string Caption
        {
            get
            {
                return this.caption;
            }
            set
            {
                this.caption = value;
            }
        }

        public int DefaultButtonIndex
        {
            get
            {
                return this.defaultButtonIndex;
            }
            set
            {
                this.defaultButtonIndex = value;
            }
        }

        public System.Drawing.Icon Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
            }
        }

        public UserLookAndFeel LookAndFeel
        {
            get
            {
                return this.lookAndFeel;
            }
            set
            {
                this.lookAndFeel = value;
            }
        }

        public IWin32Window Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }
        public string DontShowAgainText
        {
            get { return dontShowAgainText; }
            set { dontShowAgainText = value; }
        }
        public bool DontShowAgainChecked
        {
            get { return dontShowAgainChecked; }
            set { dontShowAgainChecked = value; }
        }
    }
}
