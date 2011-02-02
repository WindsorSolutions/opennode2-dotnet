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

using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// File system enumerator.  This class provides an easy to use, efficient mechanism for searching a list of
    /// directories for files matching a list of file specifications.  The search is done incrementally as matches
    /// are consumed, so the overhead before processing the first match is always kept to a minimum.
    /// </summary>
    public class FileSystemEnumerator : DisposableBase, IEnumerable<string>
    {

        [Flags]
        public enum EReturnTypes
        {
            eReturnFiles = 0x0001,
            eReturnDirectories = 0x0002,
            eReturnAll = (eReturnFiles | eReturnDirectories)
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathsToSearch">Semicolon- or comma-delimitted list of paths to search.</param>
        /// <param name="fileTypesToMatch">Semicolon- or comma-delimitted list of wildcard filespecs to match.</param>
        /// <param name="includeSubDirs">If true, subdirectories are searched.</param>
        public FileSystemEnumerator(string pathsToSearch, string fileTypesToMatch, bool includeSubDirs,
                                    EReturnTypes inReturnTypes)
        {
            _scopes = new Stack<SearchInfo>();
            _returnFiles = (inReturnTypes & EReturnTypes.eReturnFiles) == EReturnTypes.eReturnFiles;
            _returnDirectories = (inReturnTypes & EReturnTypes.eReturnDirectories) == EReturnTypes.eReturnDirectories;

            // check for nulls
            if (string.IsNullOrEmpty(pathsToSearch))
                throw new ArgumentNullException("pathsToSearch");
            if (string.IsNullOrEmpty(fileTypesToMatch))
                throw new ArgumentNullException("fileTypesToMatch");

            // make sure spec doesn't contain invalid characters
            if (fileTypesToMatch.IndexOfAny(new char[] { ':', '<', '>', '/', '\\' }) >= 0)
                throw new ArgumentException("invalid cahracters in wildcard pattern", "fileTypesToMatch");

            _includeSubDirs = includeSubDirs;
            _paths = pathsToSearch.Split(new char[] { ';', ',' });

            string[] specs = fileTypesToMatch.Split(new char[] { ';', ',' });
            _fileSpecs = new List<Regex>(specs.Length);
            foreach (string spec in specs)
            {

                // trim whitespace off file spec and convert Win32 wildcards to regular expressions
                string pattern = spec
                  .Trim()
                  .Replace(".", @"\.")
                  .Replace("*", @".*")
                  .Replace("?", @".?")
                  ;
                _fileSpecs.Add(
                  new Regex("^" + pattern + "$", RegexOptions.IgnoreCase)
                  );
            }
        }

        /// <summary>
        /// Information that's kept in our stack for simulated recursion
        /// </summary>
        private struct SearchInfo
        {
            /// <summary>
            /// Find handle returned by FindFirstFile
            /// </summary>
            public SafeFindHandle Handle;

            /// <summary>
            /// Path that was searched to yield the find handle.
            /// </summary>
            public string Path;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="h">Find handle returned by FindFirstFile.</param>
            /// <param name="p">Path corresponding to find handle.</param>
            public SearchInfo(SafeFindHandle h, string p)
            {
                Handle = h;
                Path = p;
            }
        }

        /// <summary>
        /// Stack of open scopes.  This is a member (instead of a local variable)
        /// to allow Dispose to close any open find handles if the object is disposed
        /// before the enumeration is completed.
        /// </summary>
        private Stack<SearchInfo> _scopes;

        /// <summary>
        /// Array of paths to be searched.
        /// </summary>
        private string[] _paths;

        /// <summary>
        /// Array of regular expressions that will detect matching files.
        /// </summary>
        private List<Regex> _fileSpecs;

        private bool _returnFiles;
        private bool _returnDirectories;

        /// <summary>
        /// If true, sub-directories are searched.
        /// </summary>
        private bool _includeSubDirs;

        #region IDisposable implementation
        protected override void OnDispose(bool inIsDisposing)
        {

            if (inIsDisposing)
            {
                while (_scopes.Count > 0)
                {
                    SearchInfo si = _scopes.Pop();
                    si.Handle.Close();
                }
            }
        }
        #endregion

        /// <summary>
        /// Get an enumerator that returns all of the files that match the wildcards that
        /// are in any of the directories to be searched.
        /// </summary>
        /// <returns>An IEnumerable that returns all matching files one by one.</returns>
        /// <remarks>The enumerator that is returned finds files using a lazy algorithm that
        /// searches directories incrementally as matches are consumed.</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Matches();
        }
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return Matches();
        }
        private IEnumerator<string> Matches()
        {
            Stack<string> pathsToSearch = new Stack<string>(_paths);
            FindData findData = new FindData();
            string path, fileName;

            while (0 != pathsToSearch.Count)
            {
                path = pathsToSearch.Pop().Trim();
                using (SafeFindHandle handle = FindFirstFile(
                    Path.Combine(path, "*"), findData))
                {
                    if (!handle.IsInvalid)
                    {
                        do
                        {
                            fileName = findData.fileName;
                            if (string.IsNullOrEmpty(fileName)) continue;
                            if (string.Equals(fileName, ".", StringComparison.Ordinal)) continue;
                            if (string.Equals(fileName, "..", StringComparison.Ordinal)) continue;

                            if (0 != ((int)FileAttributes.Directory & findData.fileAttributes))
                            {
                                if (_returnDirectories)
                                {
                                    foreach (Regex fileSpec in _fileSpecs)
                                    {
                                        if (fileSpec.IsMatch(fileName))
                                        {
                                            yield return Path.Combine(path, fileName);
                                            break;
                                        }
                                    }
                                }
                                if (_includeSubDirs)
                                {
                                    pathsToSearch.Push(Path.Combine(path, fileName));
                                }
                            }
                            else
                            {
                                if (_returnFiles)
                                {
                                    foreach (Regex fileSpec in _fileSpecs)
                                    {
                                        if (fileSpec.IsMatch(fileName))
                                        {
                                            yield return Path.Combine(path, fileName);
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                        while (FindNextFile(handle, findData));
                    }
                }
            }
        }
        /// <summary>
        /// Structure that maps to WIN32_FIND_DATA
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible"), StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
        private sealed class FindData
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int fileAttributes;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int creationTime_lowDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int creationTime_highDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int lastAccessTime_lowDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int lastAccessTime_highDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int lastWriteTime_lowDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int lastWriteTime_highDateTime;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int nFileSizeHigh;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int nFileSizeLow;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int dwReserved0;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            public int dwReserved1;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public String fileName;
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public String alternateFileName;
        }
        /// <summary>
        /// SafeHandle class for holding find handles
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        private sealed class SafeFindHandle : Microsoft.Win32.SafeHandles.SafeHandleMinusOneIsInvalid
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public SafeFindHandle()
                : base(true)
            {
            }

            /// <summary>
            /// Release the find handle
            /// </summary>
            /// <returns>true if the handle was released</returns>
            protected override bool ReleaseHandle()
            {
                return FindClose(handle);
            }
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        [SuppressMessage("Microsoft.Interoperability", "CA1401")]
        private static extern SafeFindHandle FindFirstFile(String fileName, [In, Out] FindData findFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [SuppressMessage("Microsoft.Interoperability", "CA1401")]
        private static extern bool FindNextFile(SafeFindHandle hFindFile, [In, Out] FindData lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [SuppressMessage("Microsoft.Interoperability", "CA1401")]
        private static extern bool FindClose(IntPtr hFindFile);
    }
}


