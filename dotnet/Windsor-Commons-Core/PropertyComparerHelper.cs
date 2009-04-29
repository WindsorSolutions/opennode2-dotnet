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
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// The following code contains code implemented by Rockford Lhotka:
    //  http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyComparerHelper<T> : IComparer<T>
    {

        private PropertyDescriptor _property;
        private ListSortDirection _direction;

        public PropertyComparerHelper(PropertyDescriptor property, ListSortDirection direction)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }
            _property = property;
            _direction = direction;
        }

        #region IComparer<T>

        public int Compare(T x, T y)
        {
            // Get property values
            object xValue = _property.GetValue(x);
            object yValue = _property.GetValue(y);

            // Determine sort order
            if (_direction == ListSortDirection.Ascending)
            {
                return CompareAscending(xValue, yValue);
            }
            else
            {
                return CompareDescending(xValue, yValue);
            }
        }

        public bool Equals(T x, T y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion

        // Compare two property values of any type
        private int CompareAscending(object x, object y)
        {
            int result;

            if ((x == null) && (y == null))
            {
                return 0;
            }
            if (x == null)
            {
                return -1;
            }
            if (y == null)
            {
                return 1;
            }

            // If values implement IComparer
            if (y is IComparable)
            {
                result = ((IComparable)x).CompareTo(y);
            }
            // If values don't implement IComparer but are equivalent
            else if (x.Equals(y))
            {
                result = 0;
            }
            // Values don't implement IComparer and are not equivalent, so compare as string values
            else
            {
                result = x.ToString().CompareTo(y.ToString());
            }

            // Return result
            return result;
        }

        /// <summary>
        /// Return result adjusted for ascending or descending sort order ie
        /// multiplied by 1 for ascending or -1 for descending
        /// </summary>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
        /// <returns></returns>
        private int CompareDescending(object xValue, object yValue)
        {
            return -CompareAscending(xValue, yValue);
        }
    }
}
