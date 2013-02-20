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
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace Windsor.Commons.AspNet
{
    public static class ThemeUtils
    {
        private const string THEME_NAMES = "ThemeUtils_THEME_NAMES";
        private const string CURRENT_THEME_NAME = "ThemeUtils_CURRENT_THEME_NAME";

        public static IEnumerable<string> ThemeNames
        {
            get { return LoadAppThemesList(); }
        }
        public static string CurrentThemeName
        {
            get { return SessionStateUtils.Get<string>(CURRENT_THEME_NAME); }
            set { SessionStateUtils.Set(CURRENT_THEME_NAME, value); }
        }
        private static List<string> LoadAppThemesList()
        {
            List<string> themesList = Windsor.Commons.Core.ObjectCacheUtils.Get<List<string>>(THEME_NAMES);

            if (themesList == null)
            {
                themesList = new List<string>();
                string themesPath = GlobalUtils.ThemesPhysicalApplicationPath;
                try
                {
                    if (Directory.Exists(themesPath))
                    {
                        string[] names = Directory.GetDirectories(themesPath);
                        themesList.Capacity = names.Length;
                        foreach (string name in names)
                        {
                            string themeName = Path.GetFileName(name);
                            if (themeName[0] != '.')
                            {
                                themesList.Add(themeName);
                            }
                        }
                    }
                    Windsor.Commons.Core.ObjectCacheUtils.Add(THEME_NAMES, themesList, themesPath);
                }
                catch (Exception)
                {
                }
            }
            return themesList;
        }
    }
}
