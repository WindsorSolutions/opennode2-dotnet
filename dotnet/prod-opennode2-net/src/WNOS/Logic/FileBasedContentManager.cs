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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Common.Logging;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOS.Logic
{
	public class FileBasedContentManager : IDocumentContentManager
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        private string _repositoryDirectoryPath;
        private string _documentExtension = "windsor";

        public void Init()
        {
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _repositoryDirectoryPath);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _documentExtension);

            if (!Directory.Exists(_repositoryDirectoryPath))
            {
                throw new DirectoryNotFoundException(string.Format("Repository directory does not exist: \"{0}\"",
                                                                   _repositoryDirectoryPath));
            }

            string testFilePath = Path.Combine(_repositoryDirectoryPath, Guid.NewGuid().ToString());
            try
            {
                LOG.Debug("Configuring DocumentContentManager with: " + _repositoryDirectoryPath);

                LOG.Debug("Writing test file to assure the provider has necessary rights: " + testFilePath);
                File.WriteAllText(testFilePath, DateTime.Now.ToString());

                LOG.Debug("Deleting test file to ensure the provider has necessary rights: " + testFilePath);
                File.Delete(testFilePath);

                LOG.Debug("OK");
            }
            catch (Exception ex)
            {
                FileUtils.SafeDeleteFile(testFilePath);
                throw new UnauthorizedAccessException(string.Format("Repository directory is not writable: \"{0}\"",
                                                                    _repositoryDirectoryPath), ex);
            }
        }

		#region IDocumentContentManager Members

		public byte[] GetDocumentContent(string transactionId, string id)
        {
            LOG.Debug(string.Format("GetContent({0}, {1})", transactionId, id));

            string filePath = GetFilePath(transactionId, id, true);
            LOG.Debug("   file path: " + filePath);

            return File.ReadAllBytes(filePath);

        }
        public int GetDocumentContentSize(string transactionId, string id)
        {
            string filePath = GetFilePath(transactionId, id, true);
            return (int) (new FileInfo(filePath).Length);
        }

        public void SaveDocumentContent(string transactionId, string id, byte[] content,
										bool overwriteExisting)
        {
            LOG.Debug(string.Format("Save({0}, {1}, byte[])", transactionId, id));

            string filePath = GetFilePath(transactionId, id, false);
            LOG.Debug("   file path: " + filePath);
            
            if ( !overwriteExisting && File.Exists(filePath) ) {
				throw new UnauthorizedAccessException("The file already exists.");
            }

            File.WriteAllBytes(filePath, content);
        }
       
        public void DeleteAllDocuments(string transactionId)
        {
            LOG.Debug(string.Format("Delete({0})", transactionId));

            string dirPath = GetDirPath(transactionId);
            LOG.Debug("   dir path: " + dirPath);

            Directory.Delete(dirPath, true);
        }
        public void DeleteDocument(string transactionId, string id)
        {
            LOG.Debug(string.Format("DeleteDocument({0}, {1})", transactionId, id));

            string filePath = GetFilePath(transactionId, id, false);
            LOG.Debug("   filePath: " + filePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        #endregion


        #region Private Methods

        /// <summary>
        /// GetDirPath
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        private string GetDirPath(string transactionId)
        {
            LOG.Debug(string.Format("GetDirPath({0})", transactionId));
            string dirPath = Path.Combine(_repositoryDirectoryPath, transactionId);

            LOG.Debug("   dir path: " + dirPath);
            if (!Directory.Exists(dirPath))
            {
                LOG.Debug("   does not exist");
                LOG.Debug("   creatin: " + dirPath);
                Directory.CreateDirectory(dirPath);
            }

            return dirPath;

        }

        /// <summary>
        /// GetFilePath
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="id"></param>
        /// <param name="mustExist"></param>
        /// <returns></returns>
        private string GetFilePath(string transactionId, string id, bool mustExist)
        {
            LOG.Debug(string.Format("GetFilePath({0},{1},{2})", transactionId, id, mustExist));
            string dirPath = GetDirPath(transactionId);
            LOG.Debug("   dir path: " + dirPath);

            string fileName = string.Format("{0}.{1}", id, _documentExtension);
            LOG.Debug("   file name: " + fileName);

            string filePath = Path.Combine(dirPath, fileName);
            LOG.Debug("   file path: " + filePath);

            if (!File.Exists(filePath))
            {
                LOG.Debug("   does not exist");

                if (mustExist)
                {
                    throw new FileNotFoundException("File does not exist: " + filePath, filePath);
                }
            }

            return filePath;

        }
        #endregion


        public string RepositoryDirectoryPath
        {
            get { return _repositoryDirectoryPath; }
            set { _repositoryDirectoryPath = value; }
        }

        public string DocumentExtension
        {
            get { return _documentExtension; }
            set { _documentExtension = value; }
        }

    }
}
