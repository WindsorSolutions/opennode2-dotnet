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

namespace Ionic.Zip
{
  static class ZipConstants
  {      
    public const UInt32 PackedToRemovableMedia = 0x30304b50;
    public const UInt32 Zip64EndOfCentralDirectoryRecordSignature = 0x06064b50;
    public const UInt32 Zip64EndOfCentralDirectoryLocatorSignature = 0x07064b50;
    public const UInt32 EndOfCentralDirectorySignature = 0x06054b50;
    public const int ZipEntrySignature                 = 0x04034b50;
    public const int ZipEntryDataDescriptorSignature   = 0x08074b50;
    public const int ZipDirEntrySignature              = 0x02014b50;

      
    // These are dictated by the Zip Spec.See APPNOTE.txt
    public const int AesKeySize = 192;  // 128, 192, 256
    public const int AesBlockSize = 128;  // ???

    public const UInt16 AesAlgId128 = 0x660E; 
    public const UInt16 AesAlgId192 = 0x660F; 
    public const UInt16 AesAlgId256 = 0x6610; 

  }
}
