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
using System.Diagnostics;

using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class VersionInfo : IComparable<VersionInfo>
    {
        public VersionInfo()
        {
        }
        public VersionInfo(int majorPart, int minorPart, int buildPart, int privatePart)
        {
            _majorPart = majorPart;
            _minorPart = minorPart;
            _buildPart = buildPart;
            _privatePart = privatePart;
        }
        public VersionInfo(FileVersionInfo info)
            : this(info.FileMajorPart, info.FileMinorPart,
                   info.FileBuildPart, info.FilePrivatePart)
        {
        }
        private int _majorPart;
        private static readonly char[] s_TryParseChars = new char[] { '.' };

        public int MajorPart
        {
            get { return _majorPart; }
            set { _majorPart = value; }
        }
        private int _minorPart;

        public int MinorPart
        {
            get { return _minorPart; }
            set { _minorPart = value; }
        }
        private int _buildPart;

        public int BuildPart
        {
            get { return _buildPart; }
            set { _buildPart = value; }
        }
        private int _privatePart;

        public int PrivatePart
        {
            get { return _privatePart; }
            set { _privatePart = value; }
        }
        public string ToSortableString()
        {
            return ToSortableString(_majorPart, _minorPart, _buildPart, _privatePart);
        }
        public static string ToSortableString(int major, int minor, int build, int privatePart)
        {
            return string.Format("{0}.{1}.{2}.{3}", major.ToString("D5"), minor.ToString("D5"), 
                                 build.ToString("D5"), privatePart.ToString("D5"));
        }
        public static VersionInfo FromSortableString(string versionString)
        {
            VersionInfo versionInfo;
            if (!TryParse(versionString, out versionInfo))
            {
                throw new ArgumentException(string.Format("The version string \"{0}\" cannot be parsed", versionString));
            }
            return versionInfo;
        }

        public static bool TryParse(string versionString, out VersionInfo versionInfo)
        {
            versionInfo = null;
            string[] values = versionString.Split(s_TryParseChars, StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != 4)
            {
                return false;
            }
            int majorPart, minorPart, buildPart, privatePart;
            if (!int.TryParse(values[0], out majorPart) || !int.TryParse(values[1], out minorPart) ||
                 !int.TryParse(values[2], out buildPart) || !int.TryParse(values[3], out privatePart))
            {
                return false;
            }
            versionInfo = new VersionInfo(majorPart, minorPart, buildPart, privatePart);
            return true;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}", _majorPart, _minorPart, _buildPart, _privatePart);
        }
        public int CompareTo(VersionInfo obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 1;
            if (_majorPart < obj.MajorPart) return -1;
            else if (_majorPart > obj.MajorPart) return 1;

            if (_minorPart < obj.MinorPart) return -1;
            else if (_minorPart > obj.MinorPart) return 1;

            if (_buildPart < obj.BuildPart) return -1;
            else if (_buildPart > obj.BuildPart) return 1;

            if (_privatePart < obj.PrivatePart) return -1;
            else if (_privatePart > obj.PrivatePart) return 1;

            return 0;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as VersionInfo);
        }
        public bool Equals(VersionInfo obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;

            return (this.CompareTo(obj) == 0);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator ==(VersionInfo a, VersionInfo b)
        {
            if (Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null)) return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null)) return false;
            return a.Equals(b);
        }
        public static bool operator !=(VersionInfo a, VersionInfo b)
        {
            return !(a == b);
        }
        public static bool operator >(VersionInfo a, VersionInfo b)
        {
            if (Object.ReferenceEquals(a, null)) return false;
            return (a.CompareTo(b) > 0);
        }
        public static bool operator <(VersionInfo a, VersionInfo b)
        {
            if (Object.ReferenceEquals(a, null)) return (!Object.ReferenceEquals(b, null));
            return (a.CompareTo(b) < 0);
        }
        public static bool operator >=(VersionInfo a, VersionInfo b)
        {
            if (Object.ReferenceEquals(a, null)) return (Object.ReferenceEquals(b, null));
            return (a.CompareTo(b) >= 0);
        }
        public static bool operator <=(VersionInfo a, VersionInfo b)
        {
            if (Object.ReferenceEquals(a, null)) return true;
            return (a.CompareTo(b) <= 0);
        }
    }
}
