using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public static class AppUtils
    {
        public static string ChooseFolder(string startFolderPath, bool showNewFolderBtn,
                                          string description, IWin32Window owner)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(startFolderPath))
            {
                if (Directory.Exists(startFolderPath))
                {
                    folderBrowserDialog.SelectedPath = startFolderPath;
                }
            }
            folderBrowserDialog.Description = description;
            folderBrowserDialog.ShowNewFolderButton = showNewFolderBtn;
            if (folderBrowserDialog.ShowDialog(owner) == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            return null;
        }
        public static string ChooseFileToOpen(string startFolderPath, string title, string fileExtFilter,
                                              IWin32Window owner)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DereferenceLinks = true;
            openFileDialog.Filter = fileExtFilter;
            openFileDialog.Title = string.IsNullOrEmpty(title) ? "Choose File To Open" : title;
            if (!string.IsNullOrEmpty(startFolderPath))
            {
                if (Directory.Exists(startFolderPath))
                {
                    openFileDialog.InitialDirectory = startFolderPath;
                }
            }
            if (openFileDialog.ShowDialog(owner) == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return null;
        }
        public static string ConstructFileFilter(string suggestedFileName)
        {
            string extension = Path.GetExtension(suggestedFileName);
            if (!string.IsNullOrEmpty(extension) && (extension.Length > 1))
            {
                StringBuilder docName = new StringBuilder(extension.Substring(1, extension.Length - 1));
                docName[0] = char.ToUpper(docName[0]);
                return string.Format("{0} Documents (*{1})|*{1}|All Files (*.*)|*.*", docName, extension);
            }
            return null;
        }
        public static string ChooseFileToSave(string startFolderPath, string suggestedFileName,
                                              string title, string fileExtFilter,
                                              IWin32Window owner)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = fileExtFilter;
            saveFileDialog.Title = string.IsNullOrEmpty(title) ? "Save File As" : title;
            if (!string.IsNullOrEmpty(suggestedFileName))
            {
                saveFileDialog.DefaultExt = Path.GetExtension(suggestedFileName);
                saveFileDialog.FileName = suggestedFileName;
                if (string.IsNullOrEmpty(fileExtFilter))
                {
                    saveFileDialog.Filter = ConstructFileFilter(suggestedFileName);
                }
                else
                {
                    string extension = Path.GetExtension(suggestedFileName);
                    if (!string.IsNullOrEmpty(extension))
                    {
                        string[] extensions = fileExtFilter.Split('|');
                        int index = -1;
                        for (int i = 1; i < extensions.Length; i += 2)
                        {
                            if (string.Equals(Path.GetExtension(extensions[i]), extension,
                                               StringComparison.InvariantCultureIgnoreCase))
                            {
                                index = i / 2;
                                break;
                            }
                        }
                        if (index != -1)
                        {
                            saveFileDialog.FilterIndex = index + 1;
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(startFolderPath))
            {
                if (Directory.Exists(startFolderPath))
                {
                    saveFileDialog.InitialDirectory = startFolderPath;
                }
            }
            if (saveFileDialog.ShowDialog(owner) == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }
        public static void InformationMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            MessageBox.Show(owner, messageFormat, Application.ProductName + " Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ErrorMessageBox(IWin32Window owner, Exception exception, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            if (exception != null)
            {
                messageFormat += Environment.NewLine + Environment.NewLine + ExceptionUtils.GetDeepExceptionMessageOnly(exception);
            }
            MessageBox.Show(owner, messageFormat, Application.ProductName + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ErrorMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            ErrorMessageBox(owner, null, messageFormat, args);
        }
        public static bool QuestionMessageBox(IWin32Window owner, string messageFormat, params object[] args)
        {
            if (!CollectionUtils.IsNullOrEmpty(args))
            {
                messageFormat = string.Format(messageFormat, args);
            }
            messageFormat += Environment.NewLine + " ";
            return (MessageBox.Show(owner, messageFormat, Application.ProductName + " Question",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }
        public static bool LaunchUrl(string url)
        {
            using (UseWaitCursor waitCursor = new UseWaitCursor())
            {
                try
                {
                    using (Process.Start(url))
                    {
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static bool OpenFileWithDefaultProgram(string filePath)
        {
            using (UseWaitCursor waitCursor = new UseWaitCursor())
            {
                try
                {
                    using (Process.Start(filePath))
                    {
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public static bool IsModalDialogShowing()
        {
            //Form activeForm = Form.ActiveForm;
            //if (activeForm != null)
            //{
            //    return activeForm.Modal;
            //}
            //else
            //{
            //    return (Application.OpenForms.Count > 0);
            //}

            // Not perfect, but pretty good:
            IntPtr forgroundWindow = Win32.GetActiveWindow();
            if (forgroundWindow != IntPtr.Zero)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Handle == forgroundWindow)
                    {
                        return form.Modal;
                    }
                }
                return true;
            }
            return false;
        }
        // Should be called from the Form's Shown event
        public static void ForceFormToForeground(Form form)
        {
            bool wasTopMost = form.TopMost;
            form.TopMost = true;
            form.BringToFront();
            form.Activate();
            form.TopMost = wasTopMost;
        }
    }
    public static class Extensions
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;

        public static void Restore(this Form form)
        {
            ShowWindow(form.Handle, SW_RESTORE);
        }
    }
}
