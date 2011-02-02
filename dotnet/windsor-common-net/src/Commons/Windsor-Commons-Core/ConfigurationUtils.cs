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
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Configuration;
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
	/// <summary>
	/// Basic helper functions for dealing with config settings.
	/// </summary>
    public static class ConfigurationUtils
    {
        static ConfigurationUtils()
        {
        }
        public static T LoadSettings<T>(string exePath) where T : ApplicationSettingsBase
        {
            T settingsObj = Activator.CreateInstance<T>();

            ICollection<ConfigSetting> configSettings = LoadConfigSettings(exePath, typeof(T));

            if (!CollectionUtils.IsNullOrEmpty(configSettings))
            {
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                if (!CollectionUtils.IsNullOrEmpty(properties))
                {
                    foreach (ConfigSetting setting in configSettings)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.Name == setting.Name)
                            {
                                object value = Convert.ChangeType(setting.Value, property.PropertyType);
                                settingsObj[setting.Name] = value;
                                break;
                            }
                        }
                    }
                }
            }

            return settingsObj;
        }
        public static ICollection<ConfigSetting> LoadConfigSettings(string exePath, Type type)
        {
            string sectionName = type.FullName;
            Configuration config = ConfigurationManager.OpenExeConfiguration(exePath);

            List<ConfigSetting> list = new List<ConfigSetting>();

            foreach (ConfigurationSectionGroup group in config.SectionGroups)
            {
                if (!group.IsDeclared)
                {
                    continue;
                }
                bool isAppGroup = group.Name == "applicationSettings";
                bool isUserGroup = group.Name == "userSettings";
                if (!isAppGroup && !isUserGroup)
                {
                    continue;
                }
                foreach (ConfigurationSection section in group.Sections)
                {
                    ClientSettingsSection clientSection = section as ClientSettingsSection;

                    if ((clientSection == null) || (clientSection.ElementInformation == null))
                    {
                        continue;
                    }
                    if (clientSection.SectionInformation.Name != sectionName)
                    {
                        continue;
                    }

                    foreach (SettingElement set in clientSection.Settings)
                    {
                        list.Add(new ConfigSetting(isAppGroup, set));
                    }
                }
            }
            return list;
        }
        public class ConfigSetting
        {
            private bool _isAppSetting;
            private SettingElement _setting;

            internal ConfigSetting(bool isAppSetting, SettingElement setting)
            {
                _isAppSetting = isAppSetting;
                _setting = setting;
            }
            public bool IsAppSetting
            {
                get { return _isAppSetting; }
            }
            public string Name
            {
                get { return _setting.Name; }
            }
            public string Value
            {
                get { return ((SettingValueElement)_setting.Value).ValueXml.InnerText; }
            }
        }
    }
}
