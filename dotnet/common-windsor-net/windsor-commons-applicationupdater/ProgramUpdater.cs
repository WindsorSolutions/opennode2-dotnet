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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

using Windsor.Commons.Logging;
using Windsor.Commons.Core;
using Windsor.Commons.Compression;

using DbException = System.Data.SqlClient.SqlException;

namespace Windsor.Commons.ApplicationUpdater
{
    /// <summary>Utilities to help with database update tasks</summary>
    public class ProgramUpdater : BaseApplicationUpdater
    {
        public ProgramUpdater() { }

        public ProgramUpdater(string programExeFilePath, string manifestDownloadUrl,
                              string downloadedContentPassword) :
                              base(manifestDownloadUrl, downloadedContentPassword)
        {
            _programExeFilePath = programExeFilePath;
        }
        public string ProgramExeFilePath
        {
            get { return _programExeFilePath; }
            set { _programExeFilePath = value; }
        }
        public override void DoUpdatesAsync()
        {
            ExceptionUtils.ThrowIfFileNotFound(_programExeFilePath);
            if (Path.GetExtension(_programExeFilePath).ToUpper() != ".EXE")
            {
                throw new ArgumentException("ProgramExeFilePath requires a .exe extension: " + _programExeFilePath);
            }

            base.DoUpdatesAsync();
        }

        private Version VersionFromFile(string filePath)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(_programExeFilePath);
            return new Version(versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart, 0);
        }
        protected override UpdateAction GetUpdateAction(UpdateApplicationManifest appManifest,
                                                        out Version existingVersion)
        {
            existingVersion = null;
            //appManifest.CurrentApplicationVersion = new Version("1.0.18");
            if (appManifest.CurrentApplicationVersion != null)
            {
                Version exeVersion = VersionFromFile(_programExeFilePath);

                if (exeVersion < appManifest.CurrentApplicationVersion)
                {
                    return UpdateAction.FullRefresh;
                }
            }

            return UpdateAction.None;
        }
        protected override Version DoFullRefresh(UpdateApplicationManifest appManifest,
                                                 out bool applicationCloseRequired)
        {
            string programParentPath = Path.GetDirectoryName(_programExeFilePath);
            if (!FileUtils.IsWritableDirectory(programParentPath))
            {
                LOG.Debug("DoFullRefresh: Cannot write to folder: {0}", programParentPath);
                throw new UnauthorizedAccessException(string.Format("Cannot write to directory \"{0}\"",
                                                                    programParentPath));
            }

            LOG.Debug("DoFullRefresh: Attempting to download updater file");
            string tempUpdaterFilePath = MakeTempFilePath();

            string statusString = string.Format("Downloading updater content for version {0}.{1}.{2} ...",
                                                appManifest.CurrentApplicationVersion.Major.ToString(),
                                                appManifest.CurrentApplicationVersion.Minor.ToString(),
                                                appManifest.CurrentApplicationVersion.Build.ToString());

            DoStatusCallback(0, statusString);

            DownloadFile(appManifest.ApplicationDownloadUrl, tempUpdaterFilePath,
                         delegate(int percentComplete, object callbackParam)
                         {
                             DoStatusCallback(percentComplete, callbackParam.ToString());
                             return !_cancelUpdate;
                         },
                         statusString);

            try
            {
                CheckToCancel();

                DoStatusCallback(-1, "Launching updater application ...");

                tempUpdaterFilePath = FileUtils.ChangeFileExtension(tempUpdaterFilePath, ".exe");

                CheckToCancel();

                ProcessStartInfo info = new ProcessStartInfo(tempUpdaterFilePath);
                info.UseShellExecute = true;
                using (Process process = Process.Start(info))
                {
                }
                applicationCloseRequired = true;
            }
            catch(Exception)
            {
                FileUtils.SafeDeleteFile(tempUpdaterFilePath);
                throw;
            }
            return appManifest.CurrentApplicationVersion;
        }
        protected override Version DoVersionUpdate(UpdateApplicationManifest appManifest, Version existingVersion,
                                                   out bool applicationCloseRequired)
        {
            throw new NotImplementedException("DoVersionUpdate");
        }
        private string _programExeFilePath;
    }
}
