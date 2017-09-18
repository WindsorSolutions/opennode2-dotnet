#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Common.Logging;
using Windsor.Node2008.WNOSConnector.Admin;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.Admin.Controls;
using Windsor.Node2008.WNOSUtility;
using Spring.DataBinding;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using System.ComponentModel;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.Admin.Secure
{
    public partial class ConfigImportExportSettings : SecureConfigSectionPage
    {
        public enum ImportExpertSettingsType
        {
            None = 0x00000000,
            [Description("All")]
            All,
            [Description("Selected")]
            Selected,
        }
        #region Members

        public class DataModel
        {
        }
        private DataModel _dataModel;
        private IImportExportSettingsManager _importExportSettingsService;

        #endregion
        #region Spring Biding Stuff

        protected override void InitializeModel()
        {
            base.InitializeModel();

            if (_importExportSettingsService == null)
            {
                throw new ArgumentNullException("ImportExportSettingsService");
            }
            _dataModel = new DataModel();
        }
        protected override void OnInitializeControls(EventArgs e)
        {
            if (Response.IsRequestBeingRedirected)
            {
                return;
            }

            base.OnInitializeControls(e);

            if (!IsPostBack)
            {
                introParagraphs.DataSource = IntroParagraphs;
                introParagraphs.DataBind();

                importSettingsCheckBoxList.DataSource = EnumUtils.GetAllDescriptions<ImportExportSettings>();
                importSettingsCheckBoxList.DataBind();

                importSettingsTypeDropDown.DataSource = EnumUtils.GetAllDescriptions<ImportExpertSettingsType>();
                importSettingsTypeDropDown.DataBind();
                importSettingsTypeDropDown.SelectedIndex = 0;
                importSettingsCheckBoxList.Enabled = false;

                importActionDropDown.DataSource = EnumUtils.GetAllDescriptions<ImportSettingsAction>();
                importActionDropDown.DataBind();
                importActionDropDown.SelectedIndex = 0;

                exportSettingsCheckBoxList.DataSource = EnumUtils.GetAllDescriptions<ImportExportSettings>();
                exportSettingsCheckBoxList.DataBind();

                exportSettingsTypeDropDown.DataSource = EnumUtils.GetAllDescriptions<ImportExpertSettingsType>();
                exportSettingsTypeDropDown.DataBind();
                exportSettingsTypeDropDown.SelectedIndex = 0;
                exportSettingsCheckBoxList.Enabled = false;

                AspNetUtils.SetFocus(this, fileUpload, false);
            }
        }
        protected override void LoadModel(object savedModel)
        {
            _dataModel = (DataModel)savedModel;
        }

        protected override object SaveModel()
        {
            return _dataModel;
        }
        protected void OnImport(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                ImportExportSettings settingsToImport = GetImportSettings();
                ImportSettingsAction importSettingsAction = GetImportSettingsAction();

                string errorText =
                    _importExportSettingsService.ImportSettings(fileUpload.FileBytes, settingsToImport,
                                                                importSettingsAction, VisitHelper.GetVisit());
                divPageNote.Visible = true;
                if (string.IsNullOrEmpty(errorText))
                {
                    divPageNote.InnerText = "The settings were successfully imported!";
                }
                else
                {
                    divPageNote.InnerText = "Some settings were successfully imported!";
                    SetDivPageErrorFormat(errorText);
                }
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        protected void OnExport(object sender, EventArgs e)
        {
            if (divPageError.Visible || !Page.IsValid)
            {
                // Error on page, get out of here
                return;
            }
            try
            {
                ImportExportSettings settingsToExport = GetExportSettings();

                byte[] exportSettingsZipFileBytes =
                    _importExportSettingsService.ExportSettingsAsZippedBytes(settingsToExport, VisitHelper.GetVisit());

                DoDownloadResponse(exportSettingsZipFileBytes, "Settings.zip", CommonContentType.ZIP);
            }
            catch (Exception ex)
            {
                SetDivPageError(ex);
            }
        }
        protected void ServerValidateImportFileUpload(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            if (_postbackControl != (Control)importBtn)
            {
                return;
            }
            if (!fileUpload.HasFile)
            {
                AppendDivPageError("Please choose a file that contains the settings to import.");
                e.IsValid = false;
            }
        }
        protected void ServerValidateImportSettings(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            if (_postbackControl != (Control)importBtn)
            {
                return;
            }
            if (!IsImportSettingsTypeAll())
            {
                if (importSettingsCheckBoxList.SelectedIndex < 0)
                {
                    AppendDivPageError("Please select the settings to import.");
                    e.IsValid = false;
                }
            }
        }
        protected void ServerValidateExportSettings(Object source, ServerValidateEventArgs e)
        {
            e.IsValid = true;
            if (_postbackControl != (Control)exportBtn)
            {
                return;
            }
            if (!IsExportSettingsTypeAll())
            {
                if (exportSettingsCheckBoxList.SelectedIndex < 0)
                {
                    AppendDivPageError("Please select the settings to export.");
                    e.IsValid = false;
                }
            }
        }
        protected ImportExportSettings GetExportSettings()
        {
            if (IsExportSettingsTypeAll())
            {
                return ImportExportSettings.All;
            }
            return GetImportExportSettings(exportSettingsCheckBoxList);
        }
        protected ImportSettingsAction GetImportSettingsAction()
        {
            return EnumUtils.FromDescription<ImportSettingsAction>(importActionDropDown.SelectedValue);
        }
        protected ImportExportSettings GetImportSettings()
        {
            if (IsImportSettingsTypeAll())
            {
                return ImportExportSettings.All;
            }
            return GetImportExportSettings(importSettingsCheckBoxList);
        }
        protected static ImportExportSettings GetImportExportSettings(CheckBoxList boxList)
        {
            if (boxList.SelectedIndex < 0)
            {
                return ImportExportSettings.None;
            }
            ImportExportSettings settings = ImportExportSettings.None;
            foreach (ListItem listItem in boxList.Items)
            {
                if (listItem.Selected)
                {
                    settings = EnumUtils.SetFlag(settings, EnumUtils.FromDescription<ImportExportSettings>(listItem.Text));
                }
            }
            return settings;
        }

        #endregion

        #region Properties

        public IImportExportSettingsManager ImportExportSettingsService
        {
            get
            {
                return _importExportSettingsService;
            }
            set
            {
                _importExportSettingsService = value;
            }
        }
        public DataModel Model
        {
            get
            {
                return _dataModel;
            }
            set
            {
                _dataModel = value;
            }
        }
        #endregion

        protected bool IsImportSettingsTypeAll()
        {
            return (importSettingsTypeDropDown.SelectedValue == EnumUtils.ToDescription(ImportExpertSettingsType.All));
        }
        protected void importSettingsTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            importSettingsCheckBoxList.Enabled = !IsImportSettingsTypeAll();
        }
        protected bool IsExportSettingsTypeAll()
        {
            return (exportSettingsTypeDropDown.SelectedValue == EnumUtils.ToDescription(ImportExpertSettingsType.All));
        }
        protected void exportSettingsTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            exportSettingsCheckBoxList.Enabled = !IsExportSettingsTypeAll();
        }
    }
}
