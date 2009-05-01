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

namespace Windsor.Node2008.WNOSProviders
{
    public interface ICompressionHelper
    {
        /// <summary>
        /// Uncompress a zip file to the specified target directory.
        /// </summary>
        void UncompressDirectory(string sourceFilePath, string targetDirPath);

        /// <summary>
        /// Uncompress a zip file to the specified target directory.
        /// </summary>
        void UncompressDirectory(byte[] content, string targetDirPath);

        /// <summary>
        /// Return true if the input bytes appear to be compressed.
        /// </summary>
        bool IsCompressed(byte[] content);

        /// <summary>
        /// Uncompress simple byte content returned from Compress().
        /// </summary>
        byte[] Uncompress(byte[] content);

        /// <summary>
        /// Same as Uncompress(), but continues to uncompress until a non zip
        /// entry is reached (zip within zip).
        /// </summary>
        byte[] UncompressDeep(byte[] content);

        /// <summary>
        /// Uncompress simple byte content returned from Compress() to a file.
        /// </summary>
        void Uncompress(byte[] content, string targetFilePath);

        /// <summary>
        /// Same as Uncompress(), but continues to uncompress until a non zip
        /// entry is reached (zip within zip).
        /// </summary>
        void UncompressDeep(byte[] content, string targetFilePath);

        /// <summary>
        /// Compress (recursively) all the contents of a directory to a zip file.
        /// </summary>
        void CompressDirectory(string targetFilePath, string sourceDirPath);

        /// <summary>
        /// Compress the specified files to a zip file.
        /// </summary>
        void CompressFiles(string targetFilePath, IEnumerable<string> filenames);

        /// <summary>
        /// Compress the specified file in the same directory.
        /// </summary>
        /// <param name="sourceFilePath">Source file path</param>
        /// <returns>Compressed file path</returns>
        void CompressFile(string sourceFilePath, string targetFilePath);

        /// <summary>
        /// Compress the specified file in the same directory.
        /// </summary>
        /// <param name="sourceFilePath">Source file path</param>
        /// <returns>Compressed file path</returns>
        string CompressFile(string sourceFilePath);

        /// <summary>
        /// Compress the input content to a zip file, with the given file name within the zip file.
        /// </summary>
        byte[] Compress(string nameOfFile, byte[] content);

        /// <summary>
        /// Compress the input content to a zip file, with the given file name within the zip file,
        /// and save the zip file to targetFilePath.
        /// </summary>
        void Compress(string nameOfFile, byte[] content, string targetFilePath);
    }
}
