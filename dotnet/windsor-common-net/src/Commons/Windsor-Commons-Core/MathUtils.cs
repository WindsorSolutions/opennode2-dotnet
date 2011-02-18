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
using System.Runtime.InteropServices;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with files.
    /// </summary>
    public static class MathUtils
    {
        public static bool IsOdd(int value)
        {
            return ((value & 1) == 1);
        }
        public static bool IsEven(int value)
        {
            return !IsOdd(value);
        }
        public static bool IsOdd(long value)
        {
            return ((value & 1) == 1);
        }
        public static bool IsEven(long value)
        {
            return !IsOdd(value);
        }
        public static bool IsBetween(int value, int min, int max)
        {
            return ((value >= min) && (value <= max));
        }
        public static bool IsBetween(float value, float min, float max)
        {
            return ((value >= min) && (value <= max));
        }
        public static bool IsBetween(double value, double min, double max)
        {
            return ((value >= min) && (value <= max));
        }
        public static double DegreesToRadians(double degrees)
        {
            return (Math.PI * degrees) / 180.0;
        }
        public static double RadiansToDegrees(double radians)
        {
            return (radians * 180.0) / Math.PI;
        }
        public static double Sin(double degrees)
        {
            return Math.Sin(DegreesToRadians(degrees));
        }
        public static double Cos(double degrees)
        {
            return Math.Cos(DegreesToRadians(degrees));
        }
        public static float PinToMinMax(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }
        public static bool GetMinMax(IList<double> list, int startIndex, int length,
                                     out double min, out double max)
        {
            min = double.MaxValue;
            max = double.MinValue;
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                return false;
            }
            min = max = list[startIndex];
            for (int i = startIndex + 1; i < startIndex + length; ++i)
            {
                double value = list[i];
                if (value < min)
                {
                    min = value;
                }
                else if (value > max)
                {
                    max = value;
                }
            }
            return true;
        }
        public static bool GetMinMax(IList<float> list, int startIndex, int length,
                                     out float min, out float max)
        {
            min = float.MaxValue;
            max = float.MinValue;
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                return false;
            }
            min = max = list[startIndex];
            for (int i = startIndex + 1; i < startIndex + length; ++i)
            {
                float value = list[i];
                if (value < min)
                {
                    min = value;
                }
                else if (value > max)
                {
                    max = value;
                }
            }
            return true;
        }
        public static double Max(params double[] values)
        {
            if (CollectionUtils.IsNullOrEmpty(values))
            {
                throw new ArgumentException("values cannot be empty");
            }
            double max = values[0];
            foreach (double value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }
            return max;
        }
        public static float Median(IList<float> list, int startOffset, int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("length must be greater than 0");
            }
            if (length == 1)
            {
                return list[startOffset];
            }
            float[] array = new float[length];
            for (int i = startOffset, j = 0; j < length; ++i, ++j)
            {
                array[j] = list[i];
            }
            Array.Sort(array);
            if (MathUtils.IsOdd(length))
            {
                return array[length / 2];
            }
            else
            {
                int index = (length - 1) / 2;
                return array[index] + ((array[index + 1] - array[index]) / 2);
            }
        }
        public static int SortedIndex(IList<float> list, int startOffset, int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("length must be greater than 0");
            }
            if (length == 1)
            {
                return 0;
            }
            float[] array = new float[length];
            for (int i = startOffset, j = 0; j < length; ++i, ++j)
            {
                array[j] = list[i];
            }
            Array.Sort(array);
            float checkValue = list[startOffset + length - 1];
            for (int j = 0; j < length - 1; ++j)
            {
                if (checkValue == array[j])
                {
                    return j;
                }
            }
            return (length - 1);
        }
        public static double Median(IList<double> list, int startOffset,
                                    int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("length must be greater than 0");
            }
            if (length == 1)
            {
                return list[startOffset];
            }
            double[] array = new double[length];
            for (int i = startOffset, j = 0; j < length; ++i, ++j)
            {
                array[j] = list[i];
            }
            Array.Sort(array);
            if (MathUtils.IsOdd(length))
            {
                return array[length / 2];
            }
            else
            {
                int index = (length - 1) / 2;
                return array[index] + ((array[index + 1] - array[index]) / 2);
            }
        }
        public static double SimpleAverage(IList<double> list, int startOffset,
                                           int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("length must be greater than 0");
            }
            if (length == 1)
            {
                return list[0];
            }
            double sum = 0;
            for (int i = startOffset; i < startOffset + length; ++i)
            {
                sum += list[i];
            }
            return sum / length;
        }
        public static double ExponentialAverage(IList<double> list, int startOffset,
                                                int length)
        {
            if (length < 1)
            {
                throw new ArgumentException("length must be greater than 0");
            }
            if (length == 1)
            {
                return list[0];
            }
            double periodFloat = length;
            double smoothingFactor = 2.0 / (periodFloat + 1.0);
            double currentEma = list[startOffset];
            for (int i = startOffset + 1; i < startOffset + length; ++i)
            {
                currentEma += smoothingFactor * (list[i] - currentEma);
            }
            return currentEma;
        }
        public static double AngleBetweenLines(double x11, double y11, double x12, double y12,
                                               double x21, double y21, double x22, double y22)
        {
            double pt1 = x12 - x11;
            double pt2 = y12 - y11;
            double pt3 = x22 - x21;
            double pt4 = y22 - y21;

            double angle = ((pt1 * pt3) + (pt2 * pt4))/((Math.Sqrt(pt1*pt1 + pt2*pt2)) * (Math.Sqrt(pt3*pt3 + pt4*pt4)));
            double result = Math.Acos(angle) * 180 / Math.PI;
            return result;
        }
    }
}
