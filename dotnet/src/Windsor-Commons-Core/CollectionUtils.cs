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
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with collections.
    /// </summary>
    public static class CollectionUtils
    {
        public static Dictionary<T, T> CreateDictionaryFromPairs<T>(params T[] pairs)
        {
            if (MathUtils.IsOdd(pairs.Length))
            {
                throw new ArgumentException("pairs.Length is odd");
            }
            Dictionary<T, T> dictionary = new Dictionary<T, T>();
            for (int i = 0; i < pairs.Length; i += 2)
            {
                dictionary.Add(pairs[i], pairs[i + 1]);
            }
            return dictionary;
        }
        public static bool IsNullOrEmpty(IEnumerable inArray)
        {

            if (inArray == null)
            {
                return true;
            }
            ICollection collection = inArray as ICollection;
            if (collection != null)
            {
                return (collection.Count == 0);
            }
            else
            {
                foreach (object item in inArray)
                {
                    return false;
                }
                return true;
            }
        }
        public static bool IndexInRange(IEnumerable inArray, int inIndex)
        {

            if (inArray == null)
            {
                return false;
            }
            if (inIndex < 0)
            {
                return false;
            }
            ICollection collection = inArray as ICollection;
            if (collection != null)
            {
                return (inIndex < collection.Count);
            }
            else
            {
                int count = 0;
                foreach (object item in inArray)
                {
                    ++count;
                }
                return (inIndex < count);
            }
        }
        public static T[] ToArray<T>(IEnumerable<T> inArray)
        {
            if (inArray != null)
            {
                ICollection collection = inArray as ICollection;
                if (collection != null)
                {
                    T[] rtnArray = new T[collection.Count];
                    int i = 0;
                    foreach (T item in inArray)
                    {
                        rtnArray[i++] = item;
                    }
                    return rtnArray;
                }
                else
                {
                    List<T> rtnArray = new List<T>();
                    foreach (T item in inArray)
                    {
                        rtnArray.Add(item);
                    }
                    return rtnArray.ToArray();
                }
            }
            else
            {
                return new T[0];
            }
        }
        public static List<T> ToList<T, K>(IEnumerable<K> inArray) where T : K
        {
            if (inArray != null)
            {
                List<T> rtnList;
                ICollection collection = inArray as ICollection;
                if (collection != null)
                {
                    rtnList = new List<T>(collection.Count);
                }
                else
                {
                    rtnList = new List<T>();
                }
                foreach (K item in inArray)
                {
                    rtnList.Add((T)item);
                }
                return rtnList;
            }
            else
            {
                return new List<T>();
            }
        }
        public static bool InsertIntoSortedList<T>(List<T> inList, T inElement)
        {
            int index = inList.BinarySearch(inElement);
            if (index < 0)
            {
                inList.Insert(~index, inElement);
                return true;
            }
            return false;
        }
        public static bool InsertIntoSortedList<T>(List<T> inList, T inElement, IComparer<T> comparer)
        {
            int index = inList.BinarySearch(inElement, comparer);
            if (index < 0)
            {
                inList.Insert(~index, inElement);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Perform a binary search on the input list attempting to locate an object represented by 
        /// inCompareParam.  Return values are the same as List.BinarySearch().
        /// </summary>
        public static bool SortedListContains<T>(List<T> inList, T inValue)
        {

            return (inList.BinarySearch(inValue) >= 0);
        }
        public static bool SortedListContains<T>(List<T> inList, T inValue, IComparer<T> comparer)
        {

            return (inList.BinarySearch(inValue, comparer) >= 0);
        }

        public static T FirstItem<T>(IEnumerable<T> inArray)
        {
            return NthItem<T>(inArray, 0);
        }
        public static object FirstItem(IEnumerable inArray)
        {
            return NthItem(inArray, 0);
        }
        public static T NthItem<T>(IEnumerable<T> inArray, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException(string.Format("index \"{0}\" is negative",
                                                                 index.ToString()));
            }
            using (IEnumerator<T> enumerator = inArray.GetEnumerator())
            {
                int curIndex = 0;
                while (enumerator.MoveNext())
                {
                    if (curIndex++ == index)
                    {
                        return enumerator.Current;
                    }
                }
                throw new IndexOutOfRangeException(string.Format("index \"{0}\" is out of range for the array length \"{1}\"",
                                                                 index.ToString(), curIndex.ToString()));
            }
        }
        public static object NthItem(IEnumerable inArray, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException(string.Format("index \"{0}\" is negative",
                                                                 index.ToString()));
            }
            IEnumerator enumerator = inArray.GetEnumerator();
            int curIndex = 0;
            while (enumerator.MoveNext())
            {
                if (curIndex++ == index)
                {
                    return enumerator.Current;
                }
            }
            throw new IndexOutOfRangeException(string.Format("index \"{0}\" is out of range for the array length \"{1}\"",
                                                             index.ToString(), curIndex.ToString()));
        }
        public static bool KeysMatch<K, V1, V2>(IDictionary<K, V1> dictA, IDictionary<K, V2> dictB)
        {
            if (IsNullOrEmpty(dictA) && IsNullOrEmpty(dictB))
            {
                return true;
            }
            if ((dictA == null) || (dictB == null) || (dictA.Count != dictB.Count))
            {
                return false;
            }
            foreach (KeyValuePair<K, V1> pair in dictA)
            {
                if (!dictB.ContainsKey(pair.Key))
                {
                    return false;
                }
            }
            return true;
        }
        public static T[] RemoveNullElements<T>(T[] inArray) where T : class
        {
            if (inArray == null)
            {
                return null;
            }
            bool hasNulls = false;
            foreach (T element in inArray)
            {
                if (element == null)
                {
                    hasNulls = true;
                    break;
                }
            }
            if (hasNulls)
            {
                List<T> rtnList = new List<T>(inArray.Length);
                foreach (T element in inArray)
                {
                    if (element != null)
                    {
                        rtnList.Add(element);
                    }
                }
                return rtnList.ToArray();
            }
            else
            {
                return inArray;
            }
        }
        public static Type GetCollectionElementType(ICollection collection)
        {
            return GetCollectionElementType(collection.GetType());
        }
        /// <summary>
        /// If the input type implements ICollection, return the type of elements that are stored
        /// in the collection; otherwise, return null.
        /// </summary>
        public static Type GetCollectionElementType(Type collectionType)
        {
            if (typeof(ICollection).IsAssignableFrom(collectionType))
            {
                if (collectionType.IsArray)
                {
                    if (collectionType.HasElementType)
                    {
                        return collectionType.GetElementType();
                    }
                }
                else if (collectionType.IsGenericType)
                {
                    Type[] args = collectionType.GetGenericArguments();
                    if ((args.Length == 1) &&
                        typeof(ICollection<>).MakeGenericType(args).IsAssignableFrom(collectionType))
                    {
                        return args[0];
                    }
                }
            }
            return null;
        }
        public static List<string> CreateStringList(StringCollection collection)
        {
            List<string> list = new List<string>();
            if (!CollectionUtils.IsNullOrEmpty(collection))
            {
                list.Capacity = collection.Count;
                foreach (string value in collection)
                {
                    list.Add(value);
                }
            }
            return list;
        }
        public static StringCollection CreateStringCollection(IEnumerable<string> list)
        {
            StringCollection collection = new StringCollection();
            if (list != null)
            {
                foreach (string value in list)
                {
                    collection.Add(value);
                }
            }
            return collection;
        }
        public static void Add<T>(T obj, ref List<T> list)
        {
            if (list == null)
            {
                list = new List<T>();
            }
            list.Add(obj);
        }
        public static void Add<K,V>(K key, V value, ref Dictionary<K,V> dictionary)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<K, V>();
            }
            dictionary.Add(key, value);
        }
        /// <summary>
        /// Create and return a collection of the type specified by collectionType, and copy any elements from elementsToCopy 
        /// to the new array.
        /// </summary>
        public static ICollection CreateCollectionFromCollection(Type collectionType, ICollection elementsToCopy)
        {
            Type memberElementType = CollectionUtils.GetCollectionElementType(collectionType);
            if ( memberElementType == null ) {
                throw new ArgumentException(string.Format("The input collection type, \"{0},\" does not implement ICollection or the type of collection elements cannot be determined",
                                                          collectionType.FullName));
            }
            int collectionSize = 0;
            if (elementsToCopy != null)
            {
                // Value and member types are ICollections, do collection conversion here:
                Type elementsToCopyElementType = CollectionUtils.GetCollectionElementType(elementsToCopy);
                if (elementsToCopyElementType == null)
                {
                    throw new ArgumentException(string.Format("The type of collection elements for elementsToCopy, \"{0},\" cannot be determined",
                                                              elementsToCopy.GetType().FullName));
                }
                if (elementsToCopyElementType != memberElementType)
                {
                    throw new ArgumentException(string.Format("ICollection element types do not match: \"{0}\" vs. \"{1}\"",
                                                              elementsToCopyElementType.ToString(), memberElementType.ToString()));
                }
                collectionSize = elementsToCopy.Count;
            }
            if (collectionType.IsArray)
            {
                Array newArray = Array.CreateInstance(memberElementType, collectionSize);
                if (collectionSize > 0)
                {
                    elementsToCopy.CopyTo(newArray, 0);
                }
                return newArray;
            }
            else
            {
                if (typeof(IList).IsAssignableFrom(collectionType))
                {
                    IList newCollection = (IList)Activator.CreateInstance(collectionType, collectionSize);
                    if (collectionSize > 0)
                    {
                        foreach (object element in elementsToCopy)
                        {
                            newCollection.Add(element);
                        }
                    }
                    return newCollection;
                }
                else
                {
                    throw new NotSupportedException(string.Format("The ICollection type \"{0}\" is not supported yet",
                                                                  collectionType.FullName));
                }
            }
        }
        public static bool HaveSameLengths<T>(params ICollection<T>[] collections)
        {
            if ( CollectionUtils.IsNullOrEmpty(collections) ) {
                return true;
            }
            int length = -1;
            foreach (ICollection<T> collection in collections)
            {
                if (collection == null)
                {
                    if (length == -1)
                    {
                        length = 0;
                    }
                    else if (length != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (length == -1)
                    {
                        length = collection.Count;
                    }
                    else if (length != collection.Count)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public delegate void ForEachDelegate<T>(T obj);

        public static void ForEach<T>(IEnumerable<T> list, ForEachDelegate<T> forEachProc)
        {
            if (!CollectionUtils.IsNullOrEmpty(list))
            {
                foreach (T obj in list)
                {
                    forEachProc(obj);
                }
            }
        }
        public static string[] PrependItemToArray(ICollection<string> array, string itemToAdd)
        {
            List<string> rtnList = new List<string>((array == null) ? 1 : array.Count + 1);
            rtnList.Add(itemToAdd);
            if (!CollectionUtils.IsNullOrEmpty(array))
            {
                foreach (string item in array)
                {
                    if (!string.Equals(item, itemToAdd, StringComparison.InvariantCultureIgnoreCase))
                    {
                        rtnList.Add(item);
                    }
                }
            }
            return rtnList.ToArray();
        }
        public static List<string> CreateList(ICollection<string> list)
        {
            List<string> rtnList;
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                rtnList = new List<string>(1);
            }
            else
            {
                rtnList = new List<string>(list.Count + 1);
                rtnList.AddRange(list);
            }
            return rtnList;
        }
    }
}
