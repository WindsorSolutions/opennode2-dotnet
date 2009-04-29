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

namespace Windsor.Node.Proxy11
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    internal class Util
    {
        internal static string ConvertSize(object b)
        {
            try
            {
                decimal num = Convert.ToDecimal(0x400);
                decimal num3 = Convert.ToDecimal(b) / num;
                decimal d = num3 / num;
                return string.Format("{0}MB", decimal.Round(d, 2));
            }
            catch
            {
                return "0.0MB";
            }
        }

        internal static void DeleteFile(string path)
        {
            if ((path != null) && File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch
                {
                }
            }
        }

        internal static byte[] GetBytes(string path)
        {
            FileStream fileStream = null;
            byte[] buffer2;
            try
            {
                fileStream = GetFileStream(path);
                int length = (int) fileStream.Length;
                byte[] buffer = new byte[length];
                fileStream.Read(buffer, 0, length);
                fileStream.Close();
                fileStream = null;
                buffer2 = buffer;
            }
            catch (Exception exception)
            {
                if (fileStream != null)
                {
                    try
                    {
                        fileStream.Close();
                    }
                    catch
                    {
                    }
                }
                throw exception;
            }
            return buffer2;
        }

        internal static string GetFileExtentsion(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (extension == null)
            {
                return string.Empty;
            }
            return extension.Trim().Replace(".", "").ToUpper();
        }

        internal static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        internal static FileStream GetFileStream(string path)
        {
            return new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        internal static string GetNewID()
        {
            return Guid.NewGuid().ToString();
        }

        internal static string GetTimeStamp()
        {
            DateTime now = DateTime.Now;
            return string.Format("{0}{1}{2}{3}{4}{5}", new object[] { now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second });
        }

        internal static bool IsNowBetweenDateTimes(int min, int max)
        {
            int hour = DateTime.Now.Hour;
            if (max > min)
            {
                return ((hour <= max) && (hour >= min));
            }
            if (hour > max)
            {
                return (hour >= min);
            }
            return true;
        }

        internal static string ObjectToStr(object field)
        {
            if ((field != DBNull.Value) && (field != null))
            {
                return field.ToString();
            }
            return "";
        }

        public static byte[] ToBytes(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        internal static string ToStr(ArrayList list, string delim)
        {
            return string.Join(delim, (string[]) list.ToArray(typeof(string)));
        }

        internal static string ToStr(string[] list, string delim)
        {
            if (list == null)
            {
                return "";
            }
            return string.Join(delim, list);
        }

        internal static void WriteFile(string filePath, string content)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
                writer.Write(content);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        internal static void WriteFile(string fileName, byte[] content)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(content, 0, content.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}

