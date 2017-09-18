namespace Windsor.Commons.DeveloperExpress
{
    using DevExpress.LookAndFeel;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;

    public static class XtraMessageBoxEx
    {
        private static bool _AllowCustomLookAndFeel;
        private const MessageBoxButtons DefaultButtons = MessageBoxButtons.OK;
        private const string DefaultCaption = "";
        private const MessageBoxDefaultButton DefaultDefButton = MessageBoxDefaultButton.Button1;
        private const MessageBoxIcon DefaultIcon = MessageBoxIcon.None;
        private const IWin32Window DefaultOwner = null;
        private static Icon s_ErrorIcon = null;
        private static Icon s_QuestionIcon = null;
        private static Icon s_ExclamationIcon = null;
        private static Icon s_InformationIcon = null;

        static XtraMessageBoxEx()
        {
            s_ErrorIcon = SystemIcons.Error;
            s_QuestionIcon = SystemIcons.Question;
            s_ExclamationIcon = SystemIcons.Exclamation;
            s_InformationIcon = SystemIcons.Information;
        }

        [DllImport("user32.dll")]
        private static extern bool MessageBeep(int uType);
        private static DialogResult[] MessageBoxButtonsToDialogResults(MessageBoxButtons buttons)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons))
            {
                throw new InvalidEnumArgumentException("buttons", (int)buttons, typeof(DialogResult));
            }
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    return new DialogResult[] { DialogResult.OK };

                case MessageBoxButtons.OKCancel:
                    return new DialogResult[] { DialogResult.OK, DialogResult.Cancel };

                case MessageBoxButtons.AbortRetryIgnore:
                    return new DialogResult[] { DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore };

                case MessageBoxButtons.YesNoCancel:
                    return new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel };

                case MessageBoxButtons.YesNo:
                    return new DialogResult[] { DialogResult.Yes, DialogResult.No };

                case MessageBoxButtons.RetryCancel:
                    return new DialogResult[] { DialogResult.Retry, DialogResult.Cancel };
            }
            throw new ArgumentException("buttons");
        }

        private static int MessageBoxDefaultButtonToInt(MessageBoxDefaultButton defButton)
        {
            if (!Enum.IsDefined(typeof(MessageBoxDefaultButton), defButton))
            {
                throw new InvalidEnumArgumentException("defaultButton", (int)defButton, typeof(DialogResult));
            }
            MessageBoxDefaultButton button = defButton;
            if (button != MessageBoxDefaultButton.Button1)
            {
                if (button == MessageBoxDefaultButton.Button2)
                {
                    return 1;
                }
                if (button != MessageBoxDefaultButton.Button3)
                {
                    throw new ArgumentException("defaultButton");
                }
                return 2;
            }
            return 0;
        }

        private static Icon MessageBoxIconToIcon(MessageBoxIcon icon)
        {
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon))
            {
                throw new InvalidEnumArgumentException("icon", (int)icon, typeof(DialogResult));
            }
            switch (icon)
            {
                case MessageBoxIcon.None:
                    return null;

                case MessageBoxIcon.Hand:
                    return s_ErrorIcon;

                case MessageBoxIcon.Question:
                    return s_QuestionIcon;

                case MessageBoxIcon.Exclamation:
                    return s_ExclamationIcon;

                case MessageBoxIcon.Asterisk:
                    return s_InformationIcon;
            }
            throw new ArgumentException("icon");
        }

        public static void SetDefaultIcons(Icon errorIcon, Icon questionIcon, Icon exclamationIcon, Icon informationIcon)
        {
            s_ErrorIcon = errorIcon ?? SystemIcons.Error;
            s_QuestionIcon = questionIcon ?? SystemIcons.Question;
            s_ExclamationIcon = exclamationIcon ?? SystemIcons.Exclamation;
            s_InformationIcon = informationIcon ?? SystemIcons.Information;
        }
        public static DialogResult Show(string text)
        {
            return Show((IWin32Window)null, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, string text)
        {
            return Show(lookAndFeel, null, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption)
        {
            return Show((IWin32Window)null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption)
        {
            return Show(lookAndFeel, null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text)
        {
            return Show(lookAndFeel, owner, text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show((IWin32Window)null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(lookAndFeel, null, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption)
        {
            return Show(lookAndFeel, owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show((IWin32Window)null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(lookAndFeel, null, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(lookAndFeel, owner, text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show((IWin32Window)null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon,
                                        string dontShowAgainText, ref bool dontShowAgainChecked)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, dontShowAgainText, ref dontShowAgainChecked);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, Exception ex)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, ex);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(lookAndFeel, null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(lookAndFeel, owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                        Exception ex)
        {
            return Show(owner, text, caption, MessageBoxButtonsToDialogResults(buttons), MessageBoxIconToIcon(icon), MessageBoxDefaultButtonToInt(defaultButton), icon, ex);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(owner, text, caption, MessageBoxButtonsToDialogResults(buttons), MessageBoxIconToIcon(icon), MessageBoxDefaultButtonToInt(defaultButton), icon);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton,
                                        string dontShowAgainText, ref bool dontShowAgainChecked)
        {
            return Show(owner, text, caption, MessageBoxButtonsToDialogResults(buttons), MessageBoxIconToIcon(icon), MessageBoxDefaultButtonToInt(defaultButton), icon,
                        dontShowAgainText, ref dontShowAgainChecked);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(lookAndFeel, owner, text, caption, MessageBoxButtonsToDialogResults(buttons), MessageBoxIconToIcon(icon), MessageBoxDefaultButtonToInt(defaultButton), icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound,
                                        Exception ex)
        {
            return Show(null, owner, text, caption, buttons, icon, defaultButton, messageBeepSound, ex);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound)
        {
            return Show(null, owner, text, caption, buttons, icon, defaultButton, messageBeepSound);
        }
        public static DialogResult Show(IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound,
                                        string dontShowAgainText, ref bool dontShowAgainChecked)
        {
            return Show(null, owner, text, caption, buttons, icon, defaultButton, messageBeepSound, dontShowAgainText, ref dontShowAgainChecked);
        }

        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton,
                                        MessageBoxIcon messageBeepSound, Exception ex)
        {
            MessageBeep((int)messageBeepSound);
            XtraMessageBoxFormEx form = new XtraMessageBoxFormEx();
            return form.ShowMessageBoxDialog(new XtraMessageBoxArgsEx(lookAndFeel, owner, text, caption, buttons, icon, defaultButton, null, false, ex));
        }
        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound)
        {
            MessageBeep((int)messageBeepSound);
            XtraMessageBoxFormEx form = new XtraMessageBoxFormEx();
            return form.ShowMessageBoxDialog(new XtraMessageBoxArgsEx(lookAndFeel, owner, text, caption, buttons, icon, defaultButton, null, false));
        }
        public static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton, MessageBoxIcon messageBeepSound,
                                        string dontShowAgainText, ref bool dontShowAgainChecked)
        {
            MessageBeep((int)messageBeepSound);
            XtraMessageBoxFormEx form = new XtraMessageBoxFormEx();
            XtraMessageBoxArgsEx args = new XtraMessageBoxArgsEx(lookAndFeel, owner, text, caption, buttons, icon, defaultButton,
                                                                 dontShowAgainText, dontShowAgainChecked);
            DialogResult result = form.ShowMessageBoxDialog(args);
            dontShowAgainChecked = args.DontShowAgainChecked;
            return result;
        }

        public static bool AllowCustomLookAndFeel
        {
            get
            {
                return _AllowCustomLookAndFeel;
            }
            set
            {
                _AllowCustomLookAndFeel = value;
            }
        }
    }
}
