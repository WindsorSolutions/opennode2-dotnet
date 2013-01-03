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
using System.Collections;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with collections.
    /// </summary>
    public class VirtualSortableBindingList<T> : IBindingList where T : new()
    {
        protected IList<T> m_List;
        protected PropertyDescriptor m_SortProperty;
        protected ListSortDirection m_SortDirection;

        public event EventHandler SortStarted;
        public event EventHandler SortFinished;

        public VirtualSortableBindingList(IList<T> list)
        {
            ExceptionUtils.ThrowIfNull(list, "list");
            if (!(list is ICollection))
            {
                throw new ArgumentException("list must implement ICollection");
            }
            m_List = list;
            if (ListChanged != null) { }    // Get rid of not-used warning
        }
        // Summary:
        //     Gets whether you can update items in the list.
        //
        // Returns:
        //     true if you can update the items in the list; otherwise, false.
        public virtual bool AllowEdit { get { return !m_List.IsReadOnly; } }
        //
        // Summary:
        //     Gets whether you can add items to the list using System.ComponentModel.IBindingList.AddNew().
        //
        // Returns:
        //     true if you can add items to the list using System.ComponentModel.IBindingList.AddNew();
        //     otherwise, false.
        public virtual bool AllowNew { get { return !m_List.IsReadOnly; } }
        //
        // Summary:
        //     Gets whether you can remove items from the list, using System.Collections.IList.Remove(System.Object)
        //     or System.Collections.IList.RemoveAt(System.Int32).
        //
        // Returns:
        //     true if you can remove items from the list; otherwise, false.
        public virtual bool AllowRemove { get { return !m_List.IsReadOnly; } }
        //
        // Summary:
        //     Gets whether the items in the list are sorted.
        //
        // Returns:
        //     true if System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)
        //     has been called and System.ComponentModel.IBindingList.RemoveSort() has not
        //     been called; otherwise, false.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSorting is false.
        public virtual bool IsSorted { get { return (m_SortProperty != null); } }
        //
        // Summary:
        //     Gets the direction of the sort.
        //
        // Returns:
        //     One of the System.ComponentModel.ListSortDirection values.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSorting is false.
        public virtual ListSortDirection SortDirection { get { return m_SortDirection; } }
        //
        // Summary:
        //     Gets the System.ComponentModel.PropertyDescriptor that is being used for
        //     sorting.
        //
        // Returns:
        //     The System.ComponentModel.PropertyDescriptor that is being used for sorting.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSorting is false.
        public virtual PropertyDescriptor SortProperty { get { return m_SortProperty; } }
        //
        // Summary:
        //     Gets whether a System.ComponentModel.IBindingList.ListChanged event is raised
        //     when the list changes or an item in the list changes.
        //
        // Returns:
        //     true if a System.ComponentModel.IBindingList.ListChanged event is raised
        //     when the list changes or when an item changes; otherwise, false.
        public virtual bool SupportsChangeNotification { get { return false; } }
        //
        // Summary:
        //     Gets whether the list supports searching using the System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)
        //     method.
        //
        // Returns:
        //     true if the list supports searching using the System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)
        //     method; otherwise, false.
        public virtual bool SupportsSearching { get { return false; } }
        //
        // Summary:
        //     Gets whether the list supports sorting.
        //
        // Returns:
        //     true if the list supports sorting; otherwise, false.
        public virtual bool SupportsSorting { get { return true; } }

        // Summary:
        //     Occurs when the list changes or an item in the list changes.
        public event ListChangedEventHandler ListChanged;

        // Summary:
        //     Adds the System.ComponentModel.PropertyDescriptor to the indexes used for
        //     searching.
        //
        // Parameters:
        //   property:
        //     The System.ComponentModel.PropertyDescriptor to add to the indexes used for
        //     searching.
        public virtual void AddIndex(PropertyDescriptor property) { }
        //
        // Summary:
        //     Adds a new item to the list.
        //
        // Returns:
        //     The item added to the list.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.AllowNew is false.
        public virtual object AddNew()
        {
            T obj = new T();
            m_List.Add(obj);
            return obj;
        }
        //
        // Summary:
        //     Sorts the list based on a System.ComponentModel.PropertyDescriptor and a
        //     System.ComponentModel.ListSortDirection.
        //
        // Parameters:
        //   property:
        //     The System.ComponentModel.PropertyDescriptor to sort by.
        //
        //   direction:
        //     One of the System.ComponentModel.ListSortDirection values.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSorting is false.
        public virtual void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            //Flip the properties if the parameters are the same
            if ((m_SortProperty == property) && (m_SortDirection == direction))
            {
                direction = (direction == ListSortDirection.Ascending) ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;

            }

            // Apply and set the sort, if items to sort
            PropertyComparerHelper<T> pc = new PropertyComparerHelper<T>(property, direction);

            if (SortStarted != null)
            {
                SortStarted(this, null);
            }
            try
            {
                Sort(pc);

                m_SortProperty = property;
                m_SortDirection = direction;
            }
            finally
            {
                if (SortFinished != null)
                {
                    SortFinished(this, null);
                }
            }
        }

        public virtual void Sort(IComparer<T> comparer)
        {
            List<T> genericList = m_List as List<T>;
            if (genericList != null)
            {
                genericList.Sort(comparer);
                return;
            }

            Wintellect.PowerCollections.Algorithms.SortInPlace<T>(m_List, comparer);
        }
        //
        // Summary:
        //     Returns the index of the row that has the given System.ComponentModel.PropertyDescriptor.
        //
        // Parameters:
        //   property:
        //     The System.ComponentModel.PropertyDescriptor to search on.
        //
        //   key:
        //     The value of the property parameter to search for.
        //
        // Returns:
        //     The index of the row that has the given System.ComponentModel.PropertyDescriptor.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSearching is false.
        public virtual int Find(PropertyDescriptor property, object key) { return -1; }
        //
        // Summary:
        //     Removes the System.ComponentModel.PropertyDescriptor from the indexes used
        //     for searching.
        //
        // Parameters:
        //   property:
        //     The System.ComponentModel.PropertyDescriptor to remove from the indexes used
        //     for searching.
        public virtual void RemoveIndex(PropertyDescriptor property) { }
        //
        // Summary:
        //     Removes any sort applied using System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection).
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     System.ComponentModel.IBindingList.SupportsSorting is false.
        public virtual void RemoveSort()
        {
            m_SortProperty = null;
        }








        // Summary:
        //     Gets a value indicating whether the System.Collections.IList has a fixed
        //     size.
        //
        // Returns:
        //     true if the System.Collections.IList has a fixed size; otherwise, false.
        public virtual bool IsFixedSize { get { return m_List.IsReadOnly; } }
        //
        // Summary:
        //     Gets a value indicating whether the System.Collections.IList is read-only.
        //
        // Returns:
        //     true if the System.Collections.IList is read-only; otherwise, false.
        public virtual bool IsReadOnly { get { return m_List.IsReadOnly; } }

        // Summary:
        //     Gets or sets the element at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the element to get or set.
        //
        // Returns:
        //     The element at the specified index.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.IList.
        //
        //   System.NotSupportedException:
        //     The property is set and the System.Collections.IList is read-only.
        public virtual object this[int index]
        {
            get
            {
                return m_List[index];
            }
            set
            {
                m_List[index] = (T) value;
            }
        }

        // Summary:
        //     Adds an item to the System.Collections.IList.
        //
        // Parameters:
        //   value:
        //     The System.Object to add to the System.Collections.IList.
        //
        // Returns:
        //     The position into which the new element was inserted.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     The System.Collections.IList is read-only.  -or- The System.Collections.IList
        //     has a fixed size.
        public virtual int Add(object value)
        {
            m_List.Add((T) value);
            return m_List.Count - 1;
        }
        //
        // Summary:
        //     Removes all items from the System.Collections.IList.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     The System.Collections.IList is read-only.
        public virtual void Clear()
        {
            m_List.Clear();
        }
        //
        // Summary:
        //     Determines whether the System.Collections.IList contains a specific value.
        //
        // Parameters:
        //   value:
        //     The System.Object to locate in the System.Collections.IList.
        //
        // Returns:
        //     true if the System.Object is found in the System.Collections.IList; otherwise,
        //     false.
        public virtual bool Contains(object value)
        {
            return m_List.Contains((T)value);
        }
        //
        // Summary:
        //     Determines the index of a specific item in the System.Collections.IList.
        //
        // Parameters:
        //   value:
        //     The System.Object to locate in the System.Collections.IList.
        //
        // Returns:
        //     The index of value if found in the list; otherwise, -1.
        public virtual int IndexOf(object value)
        {
            return m_List.IndexOf((T)value);
        }
        //
        // Summary:
        //     Inserts an item to the System.Collections.IList at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index at which value should be inserted.
        //
        //   value:
        //     The System.Object to insert into the System.Collections.IList.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.IList.
        //
        //   System.NotSupportedException:
        //     The System.Collections.IList is read-only.  -or- The System.Collections.IList
        //     has a fixed size.
        //
        //   System.NullReferenceException:
        //     value is null reference in the System.Collections.IList.
        public virtual void Insert(int index, object value)
        {
            m_List.Insert(index, (T)value);
        }
        //
        // Summary:
        //     Removes the first occurrence of a specific object from the System.Collections.IList.
        //
        // Parameters:
        //   value:
        //     The System.Object to remove from the System.Collections.IList.
        //
        // Exceptions:
        //   System.NotSupportedException:
        //     The System.Collections.IList is read-only.  -or- The System.Collections.IList
        //     has a fixed size.
        public virtual void Remove(object value)
        {
            m_List.Remove((T)value);
        }
        //
        // Summary:
        //     Removes the System.Collections.IList item at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the item to remove.
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     index is not a valid index in the System.Collections.IList.
        //
        //   System.NotSupportedException:
        //     The System.Collections.IList is read-only.  -or- The System.Collections.IList
        //     has a fixed size.
        public virtual void RemoveAt(int index)
        {
            m_List.RemoveAt(index);
        }




        // Summary:
        //     Gets the number of elements contained in the System.Collections.ICollection.
        //
        // Returns:
        //     The number of elements contained in the System.Collections.ICollection.
        public virtual int Count
        {
            get { return m_List.Count; }
        }
        //
        // Summary:
        //     Gets a value indicating whether access to the System.Collections.ICollection
        //     is synchronized (thread safe).
        //
        // Returns:
        //     true if access to the System.Collections.ICollection is synchronized (thread
        //     safe); otherwise, false.
        public virtual bool IsSynchronized
        {
            get { return ((ICollection) m_List).IsSynchronized; }
        }
        //
        // Summary:
        //     Gets an object that can be used to synchronize access to the System.Collections.ICollection.
        //
        // Returns:
        //     An object that can be used to synchronize access to the System.Collections.ICollection.
        public virtual object SyncRoot
        {
            get { return ((ICollection) m_List).SyncRoot; }
        }

        // Summary:
        //     Copies the elements of the System.Collections.ICollection to an System.Array,
        //     starting at a particular System.Array index.
        //
        // Parameters:
        //   array:
        //     The one-dimensional System.Array that is the destination of the elements
        //     copied from System.Collections.ICollection. The System.Array must have zero-based
        //     indexing.
        //
        //   index:
        //     The zero-based index in array at which copying begins.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     array is null.
        //
        //   System.ArgumentOutOfRangeException:
        //     index is less than zero.
        //
        //   System.ArgumentException:
        //     array is multidimensional.  -or- index is equal to or greater than the length
        //     of array.  -or- The number of elements in the source System.Collections.ICollection
        //     is greater than the available space from index to the end of the destination
        //     array.
        //
        //   System.ArgumentException:
        //     The type of the source System.Collections.ICollection cannot be cast automatically
        //     to the type of the destination array.
        public virtual void CopyTo(Array array, int index)
        {
            ((ICollection) m_List).CopyTo(array, index);
        }

        // Summary:
        //     Returns an enumerator that iterates through a collection.
        //
        // Returns:
        //     An System.Collections.IEnumerator object that can be used to iterate through
        //     the collection.
        public virtual IEnumerator GetEnumerator()
        {
            return m_List.GetEnumerator();
        }

    }
}
