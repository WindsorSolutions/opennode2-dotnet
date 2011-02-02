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
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Windsor.Commons.Core
{
    [Serializable]
    public class SortableCollection<T> : List<T>
    {
        private string _propertyName;
        private bool _ascending;

        public SortableCollection() { }

        public SortableCollection(IEnumerable<T> collection) : base(collection) { }

        public SortableCollection(int capacity) : base(capacity) { }

        /// <summary>
        /// Sorts implemented type by specified property
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="ascending"></param>
        public void Sort(string propertyName, bool ascending)
        {
            //Flip the properties if the parameters are the same
            if (_propertyName == propertyName && _ascending == ascending)
            {
                _ascending = !ascending;
                
            }
            else //Else, new properties are set with the new values
            {
                _propertyName = propertyName;
                _ascending = ascending;
            }

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor propertyDesc = properties.Find(propertyName, true);

            // Apply and set the sort, if items to sort
            PropertyComparerHelper<T> pc = 
                new PropertyComparerHelper<T>(propertyDesc, 
                (_ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending);

            Sort(pc);
        }

    }
}
