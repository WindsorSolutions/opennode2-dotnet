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
using System.Reflection;
using System.IO;
using Windsor.Commons.Core;

namespace Windsor.Commons.NodeDomain
{
    public static class FileTypeIdentifier
    {
        static FileTypeIdentifier()
        {
            s_MappingList.Add(
                new KeyValuePair<CommonContentType, byte[][]>(
                    CommonContentType.XML, new byte[][] { 
                                           new byte[] { 0x3C, 0x3F, 0x78, 0x6D, 0x6C } // Normal utf-8 xml
                                         , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x3F, 0x78, 0x6D, 0x6C } // Normal utf-8 xml with BOM
                                         , new byte[] { 0x3C, 0x00, 0x3F, 0x00, 0x78, 0x00, 0x6D, 0x00, 0x6C, 0x00 } // Normal unicode xml
                                         , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x3F, 0x00, 0x78, 0x00, 0x6D, 0x00, 0x6C, 0x00 } // Normal unicode xml with BOM
                                                        })
                             );
            s_MappingList.Add(
                new KeyValuePair<CommonContentType, byte[][]>(
                    CommonContentType.ZIP, new byte[][] { 
                                           new byte[] { 0x50, 0x4B, 0x03, 0x04 }
                                                        })
                             );
            s_MappingList.Add(
                new KeyValuePair<CommonContentType, byte[][]>(
                    CommonContentType.HTML, new byte[][] { 
                                            new byte[] { 0x3C, 0x21, 0x44, 0x4F, 0x43, 0x54, 0x59, 0x50, 0x45, 0x20, 0x68, 0x74, 0x6D, 0x6C } // Normal !DOCTYPE html
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x21, 0x44, 0x4F, 0x43, 0x54, 0x59, 0x50, 0x45, 0x20, 0x68, 0x74, 0x6D, 0x6C } // Normal !DOCTYPE html with BOM
                                          , new byte[] { 0x3C, 0x00, 0x21, 0x00, 0x44, 0x00, 0x4F, 0x00, 0x43, 0x00, 0x54, 0x00, 0x59, 0x00, 0x50, 0x00, 0x45, 0x00, 0x20, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00 } // Normal unicode !DOCTYPE html
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x21, 0x00, 0x44, 0x00, 0x4F, 0x00, 0x43, 0x00, 0x54, 0x00, 0x59, 0x00, 0x50, 0x00, 0x45, 0x00, 0x20, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00 } // Normal unicode !DOCTYPE html with BOM

                                          , new byte[] { 0x3C, 0x21, 0x44, 0x4F, 0x43, 0x54, 0x59, 0x50, 0x45, 0x20, 0x48, 0x54, 0x4D, 0x4C } // Normal !DOCTYPE HTML
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x21, 0x44, 0x4F, 0x43, 0x54, 0x59, 0x50, 0x45, 0x20, 0x48, 0x54, 0x4D, 0x4C } // Normal !DOCTYPE HTML with BOM
                                          , new byte[] { 0x3C, 0x00, 0x21, 0x00, 0x44, 0x00, 0x4F, 0x00, 0x43, 0x00, 0x54, 0x00, 0x59, 0x00, 0x50, 0x00, 0x45, 0x00, 0x20, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00 } // Normal unicode !DOCTYPE HTML
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x21, 0x00, 0x44, 0x00, 0x4F, 0x00, 0x43, 0x00, 0x54, 0x00, 0x59, 0x00, 0x50, 0x00, 0x45, 0x00, 0x20, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00 } // Normal unicode !DOCTYPE HTML with BOM

                                          , new byte[] { 0x3C, 0x68, 0x74, 0x6D, 0x6C, 0x3E } // Normal html
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x68, 0x74, 0x6D, 0x6C, 0x3E } // Normal html with BOM
                                          , new byte[] { 0x3C, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00, 0x3E, 0x00 } // Normal unicode html
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00, 0x3E, 0x00 } // Normal unicode html with BOM
                    
                                          , new byte[] { 0x3C, 0x48, 0x54, 0x4D, 0x4C, 0x3E } // Normal HTML
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x48, 0x54, 0x4D, 0x4C, 0x3E } // Normal HTML with BOM
                                          , new byte[] { 0x3C, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00, 0x3E, 0x00 } // Normal unicode HTML
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00, 0x3E, 0x00 } // Normal unicode HTML with BOM

                                          , new byte[] { 0x3C, 0x68, 0x74, 0x6D, 0x6C, 0x20 } // Normal html
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x68, 0x74, 0x6D, 0x6C, 0x20 } // Normal html with BOM
                                          , new byte[] { 0x3C, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00, 0x20, 0x00 } // Normal unicode html
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x68, 0x00, 0x74, 0x00, 0x6D, 0x00, 0x6C, 0x00, 0x20, 0x00 } // Normal unicode html with BOM
                    
                                          , new byte[] { 0x3C, 0x48, 0x54, 0x4D, 0x4C, 0x20 } // Normal HTML
                                          , new byte[] { 0xEF, 0xBB, 0xBF, 0x3C, 0x48, 0x54, 0x4D, 0x4C, 0x20 } // Normal HTML with BOM
                                          , new byte[] { 0x3C, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00, 0x20, 0x00 } // Normal unicode HTML
                                          , new byte[] { 0xFF, 0xFE, 0x3C, 0x00, 0x48, 0x00, 0x54, 0x00, 0x4D, 0x00, 0x4C, 0x00, 0x20, 0x00 } // Normal unicode HTML with BOM
})
                             );
            s_MappingList.Add(
                new KeyValuePair<CommonContentType, byte[][]>(
                    CommonContentType.PDF, new byte[][] { 
                                           new byte[] { 0x25, 0x50, 0x44, 0x46 }
                                                        })
                             );

            int maxReadBytes = 0;
            foreach (var pair in s_MappingList)
            {
                foreach (var byteArray in pair.Value)
                {
                    if (byteArray.Length > maxReadBytes)
                    {
                        maxReadBytes = byteArray.Length;
                    }
                }
            }
            s_MaxReadBytes = maxReadBytes;
        }
        public static void Test()
        {
            string baseFolder = @"D:\PROJECTS\OpenNode2-google\TestFiles\";
            CommonContentType? type = GetFileTypeFromContent(baseFolder + "ResultsXml.dat");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.XML);
            type = GetFileTypeFromContent(baseFolder + "ResultsXmlUnicode.dat");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.XML);
            type = GetFileTypeFromContent(baseFolder + "ResultsXmlUTF8.dat");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.XML);
            type = GetFileTypeFromContent(baseFolder + "ResultsXml.zip");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.ZIP);
            type = GetFileTypeFromContent(baseFolder + "UpgradeLog.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
            type = GetFileTypeFromContent(baseFolder + "UpgradeLogUnicode.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
            type = GetFileTypeFromContent(baseFolder + "UpgradeLogUTF8.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
            type = GetFileTypeFromContent(baseFolder + "Migration Report.pdf");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.PDF);

            type = GetFileTypeFromContent(baseFolder + "Bears.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
            type = GetFileTypeFromContent(baseFolder + "BearsUnicode.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
            type = GetFileTypeFromContent(baseFolder + "BearsUTF8.htm");
            DebugUtils.AssertDebuggerBreak(type.HasValue && type.Value == CommonContentType.HTML);
        }
        public static CommonContentType? GetFileTypeFromContent(byte[] fileContent)
        {
            if (CollectionUtils.Count(fileContent) < s_MaxReadBytes)
            {
                return null;
            }
            foreach (var pair in s_MappingList)
            {
                foreach (var byteArray in pair.Value)
                {
                    if (byteArray.Length <= fileContent.Length)
                    {
                        bool isMatch = true;
                        for (int i = 0; i < byteArray.Length; ++i)
                        {
                            if (byteArray[i] != fileContent[i])
                            {
                                isMatch = false;
                                break;
                            }
                        }
                        if (isMatch)
                        {
                            return pair.Key;
                        }
                    }
                }
            }
            return null;
        }
        public static CommonContentType? GetFileTypeFromContent(string filePath)
        {
            try
            {
                byte[] firstBytes = FileUtils.ReadMaxBytes(filePath, s_MaxReadBytes);
                return GetFileTypeFromContent(firstBytes);
            }
            catch (Exception)
            {
            }
            return null;
        }
        private static readonly List<KeyValuePair<CommonContentType, byte[][]>> s_MappingList = new List<KeyValuePair<CommonContentType, byte[][]>>(20);
        private static readonly int s_MaxReadBytes;
    }
}
