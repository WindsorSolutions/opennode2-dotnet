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
using System.ComponentModel;

namespace Windsor.Commons.Core
{
	/// <summary>
	/// Basic helper functions for dealing with enums.
	/// </summary>
    public static class EnumUtils
    {
        public static IList<T> GetEnumFlagsArray<T>(T inValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " is not an Enum");
            }
            T[] possibleValues = (T[])Enum.GetValues(typeof(T));
            List<T> list = new List<T>();
            long testValue = Convert.ToInt64(inValue);
            foreach (T possibleValue in possibleValues)
            {
                long possibleTestValue = Convert.ToInt64(possibleValue);
                if (possibleTestValue != 0)
                {
                    if ((possibleTestValue & testValue) != 0)
                    {
                        list.Add(possibleValue);
                    }
                }
                else if (testValue == 0)
                {
                    // This is the case where we have an "UNDEFINED" value that equals 0 (i.e., no flags set)
                    list.Add(possibleValue);
                    break;
                }
            }
            return list;
        }
        public static IList<T> GetAllEnumValues<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " is not an Enum");
            }
            return (T[])Enum.GetValues(typeof(T));
        }
        public static T ParseEnum<T>(string value) where T : struct, IConvertible
        {
            return ParseEnum<T>(value, true);
        }
        public static T ParseEnum<T>(string value, bool ignoreCase) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(typeof(T).ToString() + " is not an Enum.", "T", null);
            }

            T result;

            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    result = (T)Enum.Parse(typeof(T), value, ignoreCase);
                }
                catch (Exception)
                {
                    result = default(T);
                }
            }
            else
            {
                result = default(T);
            }

            return result;
        }
        /// <summary>
        /// Return the [Description] attribute value for an enum value, if specified.
        /// </summary>
        public static string ToDescription<T>(T enumValue) where T : struct, IConvertible
        {
            if (!enumValue.GetType().IsEnum)
            {
                throw new ArgumentException("enumValue must be an enum");
            }
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            DescriptionAttribute[] da = (DescriptionAttribute[])
                (typeof(T).GetField(enumValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false));
            return ((da.Length > 0) ? da[0].Description : enumValue.ToString());
        }
        /// <summary>
        /// Return the enum value from a [Description] attribute.
        /// </summary>
        public static T FromDescription<T>(string enumDescription) where T : struct, IConvertible
        {
            T value;
            FromDescription<T>(enumDescription, out value);
            return value;
        }
        /// <summary>
        /// Return the enum value from a [Description] attribute.
        /// </summary>
        public static bool FromDescription<T>(string enumDescription, out T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                DescriptionAttribute[] da = (DescriptionAttribute[])
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if ((da.Length > 0) && string.Equals(da[0].Description, enumDescription, StringComparison.InvariantCultureIgnoreCase))
                {
                    value = (T)fieldInfo.GetValue(null);
                    return true;
                }
            }
            value = default(T);
            return false;
        }
        /// <summary>
        /// Return the enum value from a [Description] attribute.
        /// </summary>
        public static T FlagsFromDescriptions<T>(string enumDescription, char separatorChar) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            T rtnValue = default(T);
            if (!string.IsNullOrEmpty(enumDescription))
            {
                string[] values = enumDescription.Split(separatorChar);
                foreach (string value in values)
                {
                    string enumValueStr = value.Trim();
                    if ( !string.IsNullOrEmpty(enumValueStr) )
                    {
                        T enumValue = FromDescription<T>(enumValueStr);
                        rtnValue = SetFlag<T>(rtnValue, enumValue);
                    }
                }
            }
            return rtnValue;
        }
        /// <summary>
        /// Return a collection of descriptions for all enum values that have a
        /// [Description] attribute specified.
        /// </summary>
        public static ICollection<string> GetAllDescriptions<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            List<string> list = new List<string>();
            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                DescriptionAttribute[] da = (DescriptionAttribute[])
                    fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (da.Length > 0)
                {
                    list.Add(da[0].Description);
                }
            }
            return list;
        }
        /// <summary>
        /// Return a collection of descriptions for all enum values that have a
        /// [Description] attribute specified.
        /// </summary>
        public static ICollection<string> GetAllDescriptions<T>(T enumValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            bool isFlags = typeof(T).IsDefined(typeof(FlagsAttribute), true);
            List<string> list = new List<string>();
            long flagValue = 0;
            if (isFlags)
            {
                flagValue = (long)Convert.ChangeType(enumValue, typeof(long));
            }
            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                try
                {
                    DescriptionAttribute[] da = (DescriptionAttribute[])
                        fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (da.Length > 0)
                    {
                        T fieldValue = (T) fieldInfo.GetValue(null);
                        if (isFlags)
                        {
                            long fieldFlagValue = (long) Convert.ChangeType(fieldValue, typeof(long));
                            if ( (fieldFlagValue & flagValue) == fieldFlagValue ) {
                                list.Add(da[0].Description);
                            }
                        }
                        else if (fieldValue.Equals(enumValue))
                        {
                            list.Add(da[0].Description);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            return list;
        }
        /// <summary>
        /// T should be a flags enum.  This method sets the flag flagToSet on currentFlags and returns
        /// the result.
        /// </summary>
        public static T SetFlag<T>(T currentFlags, T flagToSet) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            return (T)Enum.ToObject(typeof(T), ((IConvertible)currentFlags).ToInt32(null) | ((IConvertible)flagToSet).ToInt32(null));
        }
        public static T ClearFlag<T>(T currentFlags, T flagToClear) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            return (T)Enum.ToObject(typeof(T), ((IConvertible)currentFlags).ToInt32(null) & (~((IConvertible)flagToClear).ToInt32(null)));
        }
        public static T AssignFlag<T>(T currentFlags, T flagToAssign, bool doSet) where T : struct, IConvertible
        {
            if (doSet)
            {
                return SetFlag<T>(currentFlags, flagToAssign);
            }
            else
            {
                return ClearFlag<T>(currentFlags, flagToAssign);
            }
        }
        public static bool IsFlagSet<T>(T currentFlags, T flagToCheck) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("T must be an enum");
            }
            return ((((IConvertible)currentFlags).ToInt32(null) & ((IConvertible)flagToCheck).ToInt32(null)) != 0);
        }
        public static int GetLargestEnumStringSize(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException("enumType must be an enum");
            }
            string[] names = Enum.GetNames(enumType);
            int maxSize = 0;
            foreach (string name in names)
            {
                if (maxSize < name.Length)
                {
                    maxSize = name.Length;
                }
            }
            return maxSize;
        }
    }
}
