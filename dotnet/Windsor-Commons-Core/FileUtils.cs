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
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with files.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Change the physical file extension of the input file on disk, and return the new file path.
        /// </summary>
        public static string ChangeFileExtension(string filePath, string extension)
        {
            string curExt = Path.GetExtension(filePath);
            if (string.Equals(curExt, extension, StringComparison.InvariantCultureIgnoreCase))
            {
                return filePath;
            }
            string newPath = Path.ChangeExtension(filePath, extension);
            File.Move(filePath, newPath);
            return newPath;
        }
        /// <summary>
        /// Return a full path given an input path relative to the currently executing assembly.
        /// </summary>
        public static string PathFromExecutingAssemblyRelativePath(string relativePath)
        {
            return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                 relativePath));
        }
        /// <summary>
        /// Move the input file to a new folder, keeping the same file name within the new folder.
        /// </summary>
        public static string MoveFileToFolder(string originalFilePath, string moveToFolderPath)
        {
            string newFilePath = Path.Combine(moveToFolderPath, Path.GetFileName(originalFilePath));
            try
            {
                File.Move(originalFilePath, newFilePath);
            }
            catch (Exception ex)
            {
                throw new IOException(string.Format("An error occurred attempting to move the file \"{0}\" to \"{1}\"", 
                                                    originalFilePath, newFilePath), ex);
            }
            return newFilePath;
        }
        /// <summary>
        /// Same as MoveFileToFolder(), but appends the current datetime ticks to the file name.
        /// </summary>
        public static string MoveFileToFolderAppendDateTimeTicksToName(string originalFilePath, string moveToFolderPath)
        {
            string newFileName = Path.ChangeExtension(Path.GetFileNameWithoutExtension(originalFilePath) + "_" + DateTime.Now.Ticks.ToString(),
                                                      Path.GetExtension(originalFilePath));
            string newFilePath = Path.Combine(moveToFolderPath, newFileName);
            try
            {
                File.Move(originalFilePath, newFilePath);
            }
            catch (Exception ex)
            {
                throw new IOException(string.Format("An error occurred attempting to move the file \"{0}\" to \"{1}\"",
                                                    originalFilePath, newFilePath), ex);
            }
            return newFilePath;
        }
        /// <summary>
        /// Compare two input file versions.
        /// </summary>
        public static int CompareFileVersions(FileVersionInfo version1, FileVersionInfo version2)
        {
            int rtnVal = version1.FileMajorPart - version2.FileMajorPart;
            if (rtnVal != 0)
            {
                return rtnVal;
            }
            rtnVal = version1.FileMinorPart - version2.FileMinorPart;
            if (rtnVal != 0)
            {
                return rtnVal;
            }
            rtnVal = version1.FileBuildPart - version2.FileBuildPart;
            if (rtnVal != 0)
            {
                return rtnVal;
            }
            return 0;
        }
        /// <summary>
        /// Return a "cleansed" version of fileName that has any invalid file characters
        /// replaced by replacementChar.
        /// </summary>
        public static string ReplaceInvalidFilenameChars(string fileName, char replacementChar)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            int index = fileName.IndexOfAny(invalidChars);
            if (index < 0)
            {
                return fileName;    // No invalid characters
            }
            StringBuilder sb = new StringBuilder(fileName);
            do
            {
                sb[index] = replacementChar;
                if (index == (fileName.Length - 1))
                {
                    break;
                }
                index = fileName.IndexOfAny(invalidChars, index + 1);
            } while (index > 0);
            return sb.ToString();
        }
        /// <summary>
        /// Write all bytes of the input stream to the file given by dstFilePath.  dstFilePath is 
        /// overwritten.
        /// </summary>
        public static void WriteAllBytes(Stream srcStream, string dstFilePath)
        {
            const int MAX_BUFFER_SIZE = 16384;
            bool didCreateDstFile = false;
            try
            {
                using (FileStream dstStream = File.OpenWrite(dstFilePath))
                {
                    didCreateDstFile = true;
                    long srcLength = srcStream.Length;
                    if (srcLength > 0)
                    {
                        long saveSrcPos = srcStream.Position;
                        srcStream.Position = 0;
                        try
                        {
                            byte[] buffer = new byte[Math.Min(srcLength, MAX_BUFFER_SIZE)];
                            long bytesLeft = srcLength;
                            do
                            {
                                int processBytes = (int)Math.Min(bytesLeft, buffer.Length);
                                srcStream.Read(buffer, 0, processBytes);
                                dstStream.Write(buffer, 0, processBytes);
                                bytesLeft -= processBytes;
                            } while (bytesLeft > 0);
                        }
                        finally
                        {
                            srcStream.Position = saveSrcPos;
                        }
                    }

                }
            }
            catch (Exception)
            {
                if (didCreateDstFile)
                {
                    FileUtils.SafeDeleteFile(dstFilePath);
                }
                throw;
            }
        }
        /// <summary>
        /// Attempt to delete a file without throwing an exception.  Return true if the file was deleted or
        /// does not exist.
        /// </summary>
        public static bool SafeDeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception)
            {
            }
            return !File.Exists(filePath);
        }
        /// <summary>
        /// Attempt to delete a directory (and all contents) without throwing an exception.  Return true 
        /// if the directory was deleted or does not exist.
        /// </summary>
        public static bool SafeDeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath, true);
            }
            catch (Exception)
            {
            }
            return !Directory.Exists(directoryPath);
        }
        /// <summary>
        /// Return true if the input directory is empty.
        /// </summary>
        public static bool IsDirectoryEmpty(string directoryPath)
        {
            bool isEmpty = true;
            using (FileSystemEnumerator enumerator = new FileSystemEnumerator(directoryPath, "*", false,
                                                                              FileSystemEnumerator.EReturnTypes.eReturnAll))
            {
                foreach (string dirPath in enumerator)
                {
                    isEmpty = false;
                    break;
                }
            }
            return isEmpty;
        }
        /// <summary>
        /// Delete all files within directoryPath that are older than deleteFilesOlderThanDate.  Return the 
        /// number of files deleted.
        /// </summary>
        public static int DeleteAllFilesOlderThan(string directoryPath, DateTime deleteFilesOlderThanDate,
                                                  bool includeSubdirectories, bool throwAccessExceptions)
        {
            int deleteFileCount = 0;
            using (FileSystemEnumerator enumerator = new FileSystemEnumerator(directoryPath, "*", includeSubdirectories,
                                                                              FileSystemEnumerator.EReturnTypes.eReturnFiles))
            {
                foreach (string filePath in enumerator)
                {
                    try
                    {
                        DateTime lastWriteTime = File.GetLastWriteTime(filePath);
                        if (lastWriteTime < deleteFilesOlderThanDate)
                        {
                            File.Delete(filePath);
                            ++deleteFileCount;
                        }
                    }
                    catch (Exception)
                    {
                        if (throwAccessExceptions)
                        {
                            throw;
                        }
                    }
                }
            }
            return deleteFileCount;
        }
        /// <summary>
        /// Delete all empty folders within directoryPath that are older than deleteFoldersOlderThanDate.  Return the 
        /// number of folders deleted.
        /// </summary>
        public static int DeleteAllEmptyFoldersOlderThan(string directoryPath, DateTime deleteFoldersOlderThanDate,
                                                         bool throwAccessExceptions)
        {
            int deleteFolderCount = 0;
            using (FileSystemEnumerator enumerator = new FileSystemEnumerator(directoryPath, "*", true,
                                                                              FileSystemEnumerator.EReturnTypes.eReturnDirectories))
            {
                foreach (string dirPath in enumerator)
                {
                    try
                    {
                        DateTime lastWriteTime = Directory.GetLastWriteTime(dirPath);
                        if (lastWriteTime < deleteFoldersOlderThanDate)
                        {
                            if (FileUtils.IsDirectoryEmpty(dirPath))
                            {
                                Directory.Delete(dirPath, true);
                                ++deleteFolderCount;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (throwAccessExceptions)
                        {
                            throw;
                        }
                    }
                }
            }
            return deleteFolderCount;
        }
        /// <summary>
        /// Return true if the directory directoryPath is writeable.
        /// </summary>
        public static bool IsWritableDirectory(string directoryPath)
        {
            string testFilePath = Path.Combine(directoryPath, Guid.NewGuid().ToString());
            try
            {
                using (FileStream stream = new FileStream(testFilePath, FileMode.CreateNew, 
                                                          FileAccess.Write, FileShare.None))
                {
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                SafeDeleteFile(testFilePath);
            }
        }
        /// <summary>
        /// Make a unique file name within the directory directoryPath using fileName as a base name for
        /// the file.
        /// </summary>
        public static string MakeUniqueIncrementalFilePath(string directoryPath, string fileName)
        {
            string path = Path.Combine(directoryPath, fileName);
            if (!File.Exists(path))
            {
                return path;
            }
            string fileNameMinusExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            for (int i = 1; ; ++i)
            {
                path = Path.Combine(directoryPath, Path.ChangeExtension(fileNameMinusExtension + '_' + i.ToString(),
                                                                        extension));
                if (!File.Exists(path))
                {
                    return path;
                }
            }
        }
        /// <summary>
        /// Make a unique file name within the directory directoryPath using fileName as a base name for
        /// the file.
        /// </summary>
        public static string GetOldestFile(string directoryPath, string fileTypesToMatch, bool includeSubDirs)
        {
            string filePath = null;
            DateTime fileTime = DateTime.MaxValue;
            using (FileSystemEnumerator enumerator = new FileSystemEnumerator(directoryPath, fileTypesToMatch, includeSubDirs,
                                                                              FileSystemEnumerator.EReturnTypes.eReturnFiles))
            {
                foreach (string curFilePath in enumerator)
                {
                    DateTime curWriteTime = File.GetLastWriteTime(curFilePath);
                    if ((filePath == null) || (fileTime > curWriteTime))
                    {
                        filePath = curFilePath;
                        fileTime = curWriteTime;
                    }
                }
            }
            return filePath;
        }
        /// <summary>
        /// Return a friendly, Windows-Explorer-formatted string representing the size of a file.
        /// </summary>
        public static string GetDisplayFileSize(long fileSize)
        {
            StringBuilder sbBuffer = new StringBuilder(32);
            StrFormatByteSize(fileSize, sbBuffer, sbBuffer.Capacity);
            return sbBuffer.ToString();
        }

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        private static extern long StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
                                                     int bufferSize);
    }
    /// <summary>
    /// Same as StreamWriter, but doesn't close the underlying stream when the writer closes
    /// </summary>
    public class NoCloseStreamWriter : StreamWriter
    {
        public NoCloseStreamWriter(Stream stream) : base(stream) { }
        public NoCloseStreamWriter(string path) : base(path) { }
        public NoCloseStreamWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public NoCloseStreamWriter(string path, bool append) : base(path, append) { }
        public NoCloseStreamWriter(Stream stream, Encoding encoding, int bufferSize) : base(stream, encoding, bufferSize) { }
        public NoCloseStreamWriter(string path, bool append, Encoding encoding) : base(path, append, encoding) { }
        public NoCloseStreamWriter(string path, bool append, Encoding encoding, int bufferSize) : base(path, append, encoding, bufferSize) { }
        protected override void Dispose(bool disposing)
        {
            ReflectionUtils.SetFieldValue(this, "stream", null);
            base.Dispose(disposing);
        }
    }
    /// <summary>
    /// Same as StreamReader, but doesn't close the underlying stream when the reader closes
    /// </summary>
    public class NoCloseStreamReader : StreamReader
    {
        public NoCloseStreamReader(Stream stream) : base(stream) { }
        public NoCloseStreamReader(string path) : base(path) { }
        public NoCloseStreamReader(Stream stream, bool detectEncodingFromByteOrderMarks) : base(stream, detectEncodingFromByteOrderMarks) { }
        public NoCloseStreamReader(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public NoCloseStreamReader(string path, bool detectEncodingFromByteOrderMarks) : base(path, detectEncodingFromByteOrderMarks) { }
        public NoCloseStreamReader(string path, Encoding encoding) : base(path, encoding) { }
        public NoCloseStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(stream, encoding, detectEncodingFromByteOrderMarks) { }
        public NoCloseStreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(path, encoding, detectEncodingFromByteOrderMarks) { }
        public NoCloseStreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize) { }
        public NoCloseStreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(path, encoding, detectEncodingFromByteOrderMarks, bufferSize) { }
        protected override void Dispose(bool disposing)
        {
            ReflectionUtils.SetFieldValue(this, "stream", null);
            base.Dispose(disposing);
        }
    }
}
