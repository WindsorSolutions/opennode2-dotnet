using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Windsor.Commons.Core;
using Windsor.Commons.WinForms;
using XTRA_MSG_BOX = Windsor.Commons.DeveloperExpress.XtraMessageBoxEx;

namespace Windsor.Commons.DeveloperExpress
{
    public static class GuiUtils
    {
        static GuiUtils()
        {
            DefaultDontShowMessageBoxAgainText = "Don't show this message again";
        }
        public static bool ShowDetailedErrorMessages = false;

        public static void SelectSkin(string skinName)
        {
            string selectedSkinName = SkinManager.Default.GetValidSkinName(skinName);
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            if (UserLookAndFeel.Default.SkinName != selectedSkinName)
            {
                UserLookAndFeel.Default.SkinName = selectedSkinName;
            }
        }
        private static string WrapMessage(string message)
        {
            return message;
        }
        public static string DefaultDontShowMessageBoxAgainText
        {
            get;
            set;
        }
        public static void InformationMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void InformationMessageBox(IWin32Window owner, ref bool dontShowAgainChecked,
                                                 string messageFormat, params object[] args)
        {
            InformationMessageBox(owner, null, ref dontShowAgainChecked, messageFormat, args);
        }
        public static void InformationMessageBox(IWin32Window owner, string dontShowAgainText, ref bool dontShowAgainChecked,
                                                 string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            if (string.IsNullOrEmpty(dontShowAgainText))
            {
                dontShowAgainText = DefaultDontShowMessageBoxAgainText;
            }
            XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information, dontShowAgainText,
                                ref dontShowAgainChecked);
        }
        public static bool InformationMessageBoxRetryCancel(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            DialogResult result =
                XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Information",
                                  MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
            return (result == DialogResult.Retry);
        }
        public static bool InformationMessageBoxOkCancel(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            DialogResult result =
                XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Information",
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            return (result == DialogResult.OK);
        }
        public static bool InformationMessageBoxOkCancel(IWin32Window owner, ref bool dontShowAgainChecked,
                                                 string messageFormat, params object[] args)
        {
            return InformationMessageBoxOkCancel(owner, null, ref dontShowAgainChecked, messageFormat, args);
        }
        public static bool InformationMessageBoxOkCancel(IWin32Window owner, string dontShowAgainText, ref bool dontShowAgainChecked,
                                                         string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            if (string.IsNullOrEmpty(dontShowAgainText))
            {
                dontShowAgainText = DefaultDontShowMessageBoxAgainText;
            }
            DialogResult result =
                XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Information",
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Information, dontShowAgainText,
                                  ref dontShowAgainChecked);
            return (result == DialogResult.OK);
        }
        public static void ErrorMessageBox(IWin32Window owner, Exception exception, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            if (exception != null)
            {
                if (!messageFormat.EndsWith(":") && !messageFormat.EndsWith("."))
                {
                    messageFormat += ":";
                }

                messageFormat += Environment.NewLine + Environment.NewLine;

                if (ShowDetailedErrorMessages)
                {
                    messageFormat += ExceptionUtils.ToLongString(exception);
                }
                else
                {
                    messageFormat += ExceptionUtils.GetDeepExceptionMessage(exception);
                    messageFormat = messageFormat.Replace(", Message:", Environment.NewLine + Environment.NewLine + "Message:");
                }
            }
            XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error, exception);
        }
        public static void ErrorMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            ErrorMessageBox(owner, null, messageFormat, args);
        }
        public static bool QuestionMessageBox(IWin32Window owner, ref bool dontShowAgainChecked,
                                              string messageFormat, params object[] args)
        {
            return QuestionMessageBox(owner, null, ref dontShowAgainChecked, messageFormat, args);
        }
        public static bool QuestionMessageBox(IWin32Window owner, string dontShowAgainText, ref bool dontShowAgainChecked,
                                              string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            messageFormat += Environment.NewLine + " ";
            if (string.IsNullOrEmpty(dontShowAgainText))
            {
                dontShowAgainText = DefaultDontShowMessageBoxAgainText;
            }
            return (XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Question",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        dontShowAgainText, ref dontShowAgainChecked) == DialogResult.Yes);
        }
        public static bool QuestionMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            messageFormat += Environment.NewLine + " ";
            return (XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Question",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }
        public static DialogResult YesNoCancelMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            messageFormat += Environment.NewLine + " ";
            return XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Question",
                                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        public static bool WarningYesNoMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            messageFormat += Environment.NewLine + " ";
            return (XTRA_MSG_BOX.Show(owner, WrapMessage(messageFormat), Application.ProductName + " Warning",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes);
        }
        public static void DataBind(ComboBoxItemCollection collection, IEnumerable dataSource,
                                    string valueMemberName, string tagMemberName)
        {
            if (CollectionUtils.IsNullOrEmpty(dataSource))
            {
                collection.Clear();
                return;
            }
            MemberInfo valueMember = ReflectionUtils.GetInstanceMember<object>(valueMemberName);
            MemberInfo tagMember = null;
            if (!string.IsNullOrEmpty(tagMemberName))
            {
                tagMember = ReflectionUtils.GetInstanceMember<object>(tagMemberName);
            }
            collection.BeginUpdate();
            try
            {
                throw new NotImplementedException();
            }
            finally
            {
                collection.EndUpdate();
            }
        }
        public delegate bool IsValidDataItemDelegate(object dataItem);

        public static void DataBind(ComboBoxEdit comboBox, IEnumerable dataSource,
                                    object selectedItemString)
        {
            DataBind(comboBox, dataSource, selectedItemString, null);
        }
        public static void DataBind(ComboBoxEdit comboBox, IEnumerable dataSource,
                                    object selectedItemString, IsValidDataItemDelegate isValidCallback)
        {
            if (CollectionUtils.IsNullOrEmpty(dataSource))
            {
                comboBox.Properties.Items.Clear();
                comboBox.EditValue = null;
                return;
            }
            object selectedItem = null;
            comboBox.Properties.Items.BeginUpdate();
            comboBox.Properties.Items.Clear();
            try
            {
                string testString = (selectedItemString != null) ? selectedItemString.ToString() : null;
                foreach (object item in dataSource)
                {
                    bool isValidItem = (isValidCallback != null) ? isValidCallback(item) : true;
                    if (isValidItem)
                    {
                        comboBox.Properties.Items.Add(item);
                        if ((testString != null) &&
                             string.Equals(testString, item.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            selectedItem = item;
                        }
                    }
                }
            }
            finally
            {
                comboBox.Properties.Items.EndUpdate();
            }
            comboBox.EditValue = selectedItem;
        }
        public static void DataBind(CheckedComboBoxEdit comboBox, IEnumerable dataSource,
                                    object selectedItemString)
        {
            DataBind(comboBox, dataSource, selectedItemString, null);
        }
        public static void DataBind(CheckedComboBoxEdit comboBox, IEnumerable dataSource,
                                    object selectedItemString, IsValidDataItemDelegate isValidCallback)
        {
            if (CollectionUtils.IsNullOrEmpty(dataSource))
            {
                comboBox.Properties.Items.Clear();
                return;
            }
            object selectedItem = null;
            comboBox.Properties.Items.BeginUpdate();
            comboBox.Properties.Items.Clear();
            try
            {
                string testString = (selectedItemString != null) ? selectedItemString.ToString() : null;
                foreach (object item in dataSource)
                {
                    bool isValidItem = (isValidCallback != null) ? isValidCallback(item) : true;
                    if (isValidItem)
                    {
                        comboBox.Properties.Items.Add(item);
                        if ((testString != null) &&
                             string.Equals(testString, item.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            selectedItem = item;
                        }
                    }
                }
            }
            finally
            {
                comboBox.Properties.Items.EndUpdate();
            }
            comboBox.EditValue = selectedItem;
        }
        public static void DataBind(CheckedListBoxControl listBox, IEnumerable dataSource,
                                    object selectedItemString)
        {
            DataBind(listBox, dataSource, selectedItemString, null);
        }
        public static void DataBind(CheckedListBoxControl listBox, IEnumerable dataSource,
                                    object selectedItemString, IsValidDataItemDelegate isValidCallback)
        {
            if (CollectionUtils.IsNullOrEmpty(dataSource))
            {
                listBox.Items.Clear();
                return;
            }
            int selectedIndex = -1;
            listBox.Items.BeginUpdate();
            listBox.Items.Clear();
            try
            {
                string testString = (selectedItemString != null) ? selectedItemString.ToString() : null;
                foreach (object item in dataSource)
                {
                    bool isValidItem = (isValidCallback != null) ? isValidCallback(item) : true;
                    if (isValidItem)
                    {
                        int index = listBox.Items.Add(item);
                        if ((testString != null) &&
                             string.Equals(testString, item.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            selectedIndex = index;
                        }
                    }
                }
            }
            finally
            {
                listBox.Items.EndUpdate();
            }
            listBox.SelectedIndex = selectedIndex;
        }
        public static void SetSelectedItem(CheckedListBoxControl listBox, object selectedItem)
        {
            int selectedIndex = -1;
            if (selectedItem != null)
            {
                int i = 0;
                foreach (CheckedListBoxItem item in listBox.Items)
                {
                    if (item.Value == selectedItem)
                    {
                        selectedIndex = i;
                        break;
                    }
                    ++i;
                }
            }
            listBox.SelectedIndex = selectedIndex;
        }
        public static StringCollection GetCheckedItems(CheckedListBoxControl listBox)
        {
            StringCollection collection = null;
            foreach (int checkedIndex in listBox.CheckedIndices)
            {
                if (collection == null)
                {
                    collection = new StringCollection();
                }
                object item = listBox.Items[checkedIndex];
                collection.Add(item.ToString());
            }
            return collection;
        }
        public static void SetCheckedItems(CheckedListBoxControl listBox, StringCollection checkedNames)
        {
            for (int i = 0; i < listBox.Items.Count; ++i)
            {
                object item = listBox.Items[i];
                if ((checkedNames == null) || !checkedNames.Contains(item.ToString()))
                {
                    if (listBox.GetItemChecked(i))
                    {
                        listBox.SetItemChecked(i, false);
                    }
                }
                else
                {
                    if (!listBox.GetItemChecked(i))
                    {
                        listBox.SetItemChecked(i, true);
                    }
                }
            }
        }
        public static StringCollection GetCheckedItems(CheckedComboBoxEdit comboBox)
        {
            StringCollection collection = null;
            for (int i = 0; i < comboBox.Properties.Items.Count; ++i)
            {
                CheckedListBoxItem item = comboBox.Properties.Items[i];
                if (item.CheckState == CheckState.Checked)
                {
                    if (collection == null)
                    {
                        collection = new StringCollection();
                    }
                    collection.Add(item.Value.ToString());
                }
            }
            return collection;
        }
        public static void SetCheckedItems(CheckedComboBoxEdit comboBox, StringCollection checkedNames)
        {
            for (int i = 0; i < comboBox.Properties.Items.Count; ++i)
            {
                CheckedListBoxItem item = comboBox.Properties.Items[i];
                if ((checkedNames == null) || !checkedNames.Contains(item.Value.ToString()))
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        item.CheckState = CheckState.Unchecked;
                    }
                }
                else
                {
                    if (item.CheckState != CheckState.Checked)
                    {
                        item.CheckState = CheckState.Checked;
                    }
                }
            }
        }
        public static bool SelectItem(ComboBoxEdit comboBox, object selectedItemString)
        {
            string testString = (selectedItemString != null) ? selectedItemString.ToString() : null;
            object selectedItem = null;
            if (testString != null)
            {
                foreach (object item in comboBox.Properties.Items)
                {
                    if ((testString != null) &&
                         string.Equals(testString, item.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedItem = item;
                        break;
                    }
                }
            }
            comboBox.EditValue = selectedItem;
            return (comboBox.EditValue == selectedItem);
        }
        public static void DataBind<T>(CheckedComboBoxEdit comboBox, T enumFlags) where T : struct, IConvertible
        {
            comboBox.Properties.Items.BeginUpdate();
            comboBox.Properties.Items.Clear();
            try
            {
                foreach (string enumStr in EnumUtils.GetAllDescriptions<T>())
                {
                    T enumValue = EnumUtils.FromDescription<T>(enumStr);
                    bool isChecked = EnumUtils.IsFlagSet(enumFlags, enumValue);
                    comboBox.Properties.Items.Add(enumStr, isChecked);
                }
            }
            finally
            {
                comboBox.Properties.Items.EndUpdate();
            }
        }
        public static void DataBindExistingFolders(ComboBoxEdit comboBox, IEnumerable dataSource,
                                                   object selectedItemString)
        {
            DataBind(comboBox, dataSource, selectedItemString,
                     delegate(object dataItem)
                     {
                         return Directory.Exists(dataItem.ToString());
                     });
        }
        public static void DataBindValidPossibleFilePaths(ComboBoxEdit comboBox, IEnumerable dataSource,
                                                          object selectedItemString)
        {
            DataBind(comboBox, dataSource, selectedItemString,
                     delegate(object dataItem)
                     {
                         return FileUtils.IsValidPossibleFilePath(dataItem.ToString());
                     });
        }
        public static void MakeSkinComboBox(ComboBoxEdit comboBox)
        {
            comboBox.Properties.Items.Clear();
            comboBox.Properties.Items.BeginUpdate();
            foreach (SkinContainer skinContainer in SkinManager.Default.Skins)
            {
                comboBox.Properties.Items.Add(skinContainer.SkinName);
            }
            comboBox.Properties.Items.EndUpdate();
            comboBox.EditValue = UserLookAndFeel.Default.SkinName;
            comboBox.EditValueChanged += SelectedComboBoxEditSkinIndexChanged;
        }
        private static void SelectedComboBoxEditSkinIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = (ComboBoxEdit)sender;
            GuiUtils.SelectSkin(comboBox.SelectedItem.ToString());
        }
        public static string HandleChooseFolderComboBox(ComboBoxEdit comboBox, ButtonPressedEventArgs args,
                                                        bool showNewFolderBtn, string description,
                                                        IWin32Window owner)
        {
            if (args.Button.Kind == ButtonPredefines.Ellipsis)
            {
                string startFolderPath = null;
                if (!string.IsNullOrEmpty(comboBox.Text))
                {
                    if (Directory.Exists(comboBox.Text))
                    {
                        startFolderPath = comboBox.Text;
                    }
                }
                string folderPath =
                    AppUtils.ChooseFolder(startFolderPath, showNewFolderBtn, description, owner);
                if (folderPath != null)
                {
                    comboBox.Text = folderPath;
                    return folderPath;
                }
            }
            return null;
        }
        public static string ValidateFolderComboBox(ComboBoxEdit comboBox, DXErrorProvider errorProvider)
        {
            string folderPath = comboBox.Text;
            if (string.IsNullOrEmpty(folderPath))
            {
                errorProvider.SetError(comboBox, "Please enter a valid folder");
                return null;
            }
            if (!Directory.Exists(folderPath))
            {
                errorProvider.SetError(comboBox, "The specified folder does not exist");
                return null;
            }
            return folderPath;
        }
        public static Skin GetCurrentCommonSkin()
        {
            return CommonSkins.GetSkin(GetCurrentUserLookAndFeel);
        }
        public static Skin GetCurrentGridSkin()
        {
            return GridSkins.GetSkin(GetCurrentUserLookAndFeel);
        }
        public static UserLookAndFeel GetCurrentUserLookAndFeel
        {
            get
            {
                return DevExpress.LookAndFeel.UserLookAndFeel.Default;
            }
        }
        public static string CurrentSkinName
        {
            get
            {
                return DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
            }
        }
        public static Color GetCurrentBorderColor()
        {
            BaseLookAndFeelPainters painter = UserLookAndFeel.Default.Painter;
            return painter.GroupPanel.DefaultAppearance.BorderColor;
        }
        public static Color GetCurrentSkinControlColor()
        {
            Skin skin = GetCurrentCommonSkin();
            return skin.Colors["Control"];
        }
        public static Color GetCurrentSkinControlTextColor()
        {
            Skin skin = GetCurrentCommonSkin();
            return skin.Colors["ControlText"];
        }
    }
}