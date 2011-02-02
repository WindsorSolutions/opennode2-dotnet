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
using Ionic.Zip;

namespace Windsor.Commons.Compression
{
	public class DotNetZipHelper {
		#region ICompressionHelper Members

		public void UncompressDirectory(string sourceFilePath, string targetDirPath) {

            UncompressDirectory(sourceFilePath, targetDirPath, null);
		}

        public void UncompressDirectory(string sourceFilePath, string targetDirPath,
                                        string password)
        {

            if (targetDirPath == null)
            {
                throw new ApplicationException("Invalid input parameter. Source directory does not exist.");
            }

            if (!Directory.Exists(targetDirPath))
            {
                Directory.CreateDirectory(targetDirPath);
            }

            using (ZipFile zip = ZipFile.Read(sourceFilePath))
            {
                if (password != null)
                {
                    zip.Password = password;
                }
                zip.ExtractAll(targetDirPath);
            }
        }

        public void UncompressDirectory(Stream sourceStream, string targetDirPath)
        {
            UncompressDirectory(sourceStream, targetDirPath, null);
        }

        public void UncompressDirectory(Stream sourceStream, string targetDirPath,
                                        string password)
        {

            if (targetDirPath == null)
            {
                throw new ApplicationException("Invalid input parameter. Source directory does not exist.");
            }

            if (!Directory.Exists(targetDirPath))
            {
                Directory.CreateDirectory(targetDirPath);
            }

            using (ZipFile zip = ZipFile.Read(sourceStream))
            {
                if (password != null)
                {
                    zip.Password = password;
                }
                zip.ExtractAll(targetDirPath);
            }
        }

        public void UncompressDirectory(byte[] content, string targetDirPath)
        {
			if (targetDirPath == null) {
				throw new ApplicationException("Invalid input parameter. Source directory does not exist.");
			}

			if (!Directory.Exists(targetDirPath)) {
				Directory.CreateDirectory(targetDirPath);
			}

            using (ZipFile zip = ZipFile.Read(content))
            {
				zip.ExtractAll(targetDirPath);
			}
		}
        public bool IsCompressed(string filePath)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(filePath))
                {
                }
                return true;
            }
            catch (Ionic.Zip.ZipException)
            {
                return false;
            }
        }
        public bool IsCompressed(byte[] content)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(content))
                {
                }
                return true;
            }
            catch (Ionic.Zip.ZipException)
            {
                return false;
            }
        }
        public byte[] UncompressDeep(byte[] content)
        {
            return UncompressDeepWithPassword(content, null);
        }
        public byte[] UncompressDeepWithPassword(byte[] content, string password)
        {
            byte[] rtnBytes = UncompressWithPassword(content, password);
            for (; ; )
            {
                try
                {
                    byte[] nextBytes = UncompressWithPassword(rtnBytes, password);
                    rtnBytes = nextBytes;
                }
                catch (Ionic.Zip.ZipException)
                {
                    return rtnBytes;
                }
            }
        }
        public byte[] Uncompress(byte[] content)
        {
            return UncompressWithPassword(content, null);
        }
        public byte[] UncompressWithPassword(byte[] content, string password)
        {
			using (ZipFile zip = ZipFile.Read(content)) {
				foreach (ZipEntry e in zip) {
					using (MemoryStream memStreamOut = new MemoryStream()) {
                        if (password == null)
                        {
                            e.Extract(memStreamOut);
                        }
                        else
                        {
                            ValidateIsPasswordProtected(e);
                            e.ExtractWithPassword(memStreamOut, password);
                        }
						memStreamOut.Flush();
						memStreamOut.Close();
						return memStreamOut.ToArray();	// Only return the first file
					}
				}
				throw new ArgumentException("Input zip file does not contain any files.");
			}
		}
        private void ValidateIsPasswordProtected(ZipEntry e)
        {
            if (!e.UsesEncryption)
            {
                throw new InvalidDataException("Input zip stream is not encrypted");
            }
        }
		public void Uncompress(byte[] content, string targetFilePath) {
            UncompressWithPassword(content, targetFilePath, null);
		}
        public void Uncompress(string zipFilePath, string contentFilePath)
        {
            UncompressWithPassword(zipFilePath, contentFilePath, null);
        }
        public void UncompressWithPassword(string zipFilePath, string contentFilePath, string password)
        {
            using (ZipFile zip = ZipFile.Read(zipFilePath))
            {
                foreach (ZipEntry e in zip)
                {
                    using (FileStream streamOut = File.OpenWrite(contentFilePath))
                    {
                        if (password == null)
                        {
                            e.Extract(streamOut);
                        }
                        else
                        {
                            ValidateIsPasswordProtected(e);
                            e.ExtractWithPassword(streamOut, password);
                        }
                        return;	// Only return the first file
                    }
                }
                throw new ArgumentException("Input zip file does not contain any files.");
            }
        }
        public void UncompressWithPassword(byte[] content, string targetFilePath, string password)
        {
            using (ZipFile zip = ZipFile.Read(content))
            {
                foreach (ZipEntry e in zip)
                {
                    using (Stream streamOut = File.OpenWrite(targetFilePath))
                    {
                        if (password == null)
                        {
                            e.Extract(streamOut);
                        }
                        else
                        {
                            ValidateIsPasswordProtected(e);
                            e.ExtractWithPassword(streamOut, password);
                        }
                        streamOut.Flush();
                        streamOut.Close();
                        return;	// Only return the first file
                    }
                }
                throw new ArgumentException("Input zip file does not contain any files.");
            }
        }

        public void UncompressDeep(byte[] content, string targetFilePath)
        {
            UncompressDeepWithPassword(content, targetFilePath, null);
        }
        public void UncompressDeepWithPassword(byte[] content, string targetFilePath, string password)
        {
            content = UncompressDeepWithPassword(content, password);
            File.WriteAllBytes(targetFilePath, content);
        }

        public void CompressFile(string sourceFilePath, string sourceFileNameInZip, string targetFilePath)
        {
            using (ZipFile zip = new ZipFile(targetFilePath))
            {
                using (FileStream fileStream = File.OpenRead(sourceFilePath))
                {
                    zip.AddFileStream(sourceFileNameInZip, string.Empty, fileStream);
                    zip.Save();
                }
            }
        }
        public void CompressFile(string sourceFilePath, string targetFilePath)
        {
            CompressFiles(targetFilePath, new string[] { sourceFilePath });
        }
        public string CompressFile(string sourceFilePath)
        {
            string targetFilePath = sourceFilePath + ".zip";
            CompressFile(sourceFilePath, targetFilePath);
            return targetFilePath;
        }

        public void CompressFiles(string targetFilePath, IEnumerable<string> filenames)
        {

            using (ZipFile zip = new ZipFile(targetFilePath))
            {
                foreach (string filePath in filenames)
                {
                    zip.AddFile(filePath, string.Empty);
                }
                zip.Save();
            }
        }
        public void CompressDirectory(string targetFilePath, string sourceDirPath)
        {
            CompressDirectory(targetFilePath, sourceDirPath, string.Empty);
		}
        public void CompressDirectory(string targetFilePath, string sourceDirPath, string directoryPathInArchive)
        {
            using (ZipFile zip = new ZipFile(targetFilePath))
            {
                zip.AddDirectory(sourceDirPath, directoryPathInArchive);
                zip.Save();
            }
        }

		public byte[] Compress(string nameOfFile, byte[] content) {
			using (MemoryStream memStreamOut = new MemoryStream()) {
				using (MemoryStream memStreamIn = new MemoryStream(content, false)) {
					using (ZipFile zip = new ZipFile(memStreamOut)) {
						zip.AddFileStream(nameOfFile, string.Empty, memStreamIn);
						zip.Save();
					}
				}
				memStreamOut.Flush();
				return memStreamOut.ToArray();	// Only return the first file
			}
		}
		public void Compress(string nameOfFile, byte[] content, string targetFilePath) {
			using (MemoryStream memStreamIn = new MemoryStream(content, false)) {
				using (ZipFile zip = new ZipFile(targetFilePath)) {
					zip.AddFileStream(nameOfFile, string.Empty, memStreamIn);
					zip.Save();
				}
			}
		}

		#endregion
	}
}
