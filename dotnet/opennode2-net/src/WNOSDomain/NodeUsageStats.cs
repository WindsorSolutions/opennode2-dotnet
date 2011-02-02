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
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Windsor.Node2008.WNOSDomain
{
    /// <summary>
    /// Domain object representing node usage statistics.
    /// </summary>
    [Serializable]
    public class NodeUsageStats
    {
        private const string FIELD_DELIMETER = ";;";
        private const string PASSWORD = "89F43FE2-7583-42c1-B9E5-B88303131695-E20AB389-A2D5-4c65-A9B3-C509CC22B061";
        public NodeUsageStats() { }
        public string GetEncryptedString()
        {
            return Crypt(CreateStatString(), PASSWORD, true);
        }
        public static NodeUsageStats DecryptFromString(string encryptedString)
        {
            string decryptedString = Crypt(encryptedString, PASSWORD, false);
            if (decryptedString == null)
            {
                return null;
            }
            NodeUsageStats stats = new NodeUsageStats();
            stats.AssignFromStatString(decryptedString);
            return stats;
        }

        private string _orgId = string.Empty;
        public string OrgId
        {
            get { return _orgId; }
            set { _orgId = value; }
        }
        private string _orgName = string.Empty;
        public string OrgName
        {
            get { return _orgName; }
            set { _orgName = value; }
        }
        private string _nodePlatform = "DotNet";
        public string NodePlatform
        {
            get { return _nodePlatform; }
            set { _nodePlatform = value; }
        }
        private string _nodeVersion = string.Empty;
        public string NodeVersion
        {
            get { return _nodeVersion; }
            set { _nodeVersion = value; }
        }
        private string CreateStatString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((_orgId ?? string.Empty) + FIELD_DELIMETER);
            sb.Append((_orgName ?? string.Empty) + FIELD_DELIMETER);
            sb.Append((_nodePlatform ?? string.Empty) + FIELD_DELIMETER);
            sb.Append((_nodeVersion ?? string.Empty) + FIELD_DELIMETER);
            return sb.ToString();
        }
        private void AssignFromStatString(string statString)
        {
            if (string.IsNullOrEmpty(statString))
            {
                return;
            }
            string[] args = statString.Split(new string[] { FIELD_DELIMETER }, StringSplitOptions.None);
            int index = 0;
            _orgId = (args.Length > index++) ? args[index - 1] : string.Empty;
            _orgName = (args.Length > index++) ? args[index - 1] : string.Empty;
            _nodePlatform = (args.Length > index++) ? args[index - 1] : string.Empty;
            _nodeVersion = (args.Length > index++) ? args[index - 1] : string.Empty;
        }
        private static string Crypt(string s_Data, string s_Password, bool b_Encrypt)
        {
            byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };

            PasswordDeriveBytes i_Pass = new PasswordDeriveBytes(s_Password, u8_Salt);

            Rijndael i_Alg = Rijndael.Create();
            i_Alg.Key = i_Pass.GetBytes(32);
            i_Alg.IV = i_Pass.GetBytes(16);

            using (ICryptoTransform i_Trans = b_Encrypt ? i_Alg.CreateEncryptor() : i_Alg.CreateDecryptor())
            {
                MemoryStream i_Mem = new MemoryStream();
                using (CryptoStream i_Crypt = new CryptoStream(i_Mem, i_Trans, CryptoStreamMode.Write))
                {
                    byte[] u8_Data = b_Encrypt ? Encoding.UTF8.GetBytes(s_Data) : Convert.FromBase64String(s_Data);
                    try
                    {
                        i_Crypt.Write(u8_Data, 0, u8_Data.Length);
                        i_Crypt.FlushFinalBlock();
                        return b_Encrypt ? Convert.ToBase64String(i_Mem.ToArray()) : Encoding.UTF8.GetString(i_Mem.ToArray());
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}
