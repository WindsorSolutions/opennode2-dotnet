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
        public static bool MoreThanOne(IEnumerable inArray)
        {

            if (inArray == null)
            {
                return false;
            }
            ICollection collection = inArray as ICollection;
            if (collection != null)
            {
                return (collection.Count > 1);
            }
            else
            {
                int count = 0;
                foreach (object item in inArray)
                {
                    if (++count > 1)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static bool ContainsOne(IEnumerable inArray)
        {
            if (inArray == null)
            {
                return false;
            }
            ICollection collection = inArray as ICollection;
            if (collection != null)
            {
                return (collection.Count == 1);
            }
            else
            {
                int count = 0;
                foreach (object item in inArray)
                {
                    if (++count > 1)
                    {
                        return false;
                    }
                }
                return (count == 1);
            }
        }
        public static bool IndexInRange(IEnumerable inArray, int inIndex)
        {

            return (inIndex > -1) && (inIndex < Count(inArray));
        }
        public static int Count(IEnumerable inArray)
        {

            if (inArray == null)
            {
                return 0;
            }
            ICollection collection = inArray as ICollection;
            if (collection != null)
            {
                return collection.Count;
            }
            else
            {
                int count = 0;
                foreach (object item in inArray)
                {
                    ++count;
                }
                return count;
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
        public static List<T> ToList<T>(IEnumerable inArray)
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
                foreach (object item in inArray)
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
        public static T[] ToArray<T, K>(IEnumerable<K> inArray) where T : K
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
                return rtnList.ToArray();
            }
            else
            {
                return new T[0];
            }
        }
        public static T BinarySearch<T>(List<T> inList, T inElement, IComparer<T> comparer) where T : class
        {
            int index = inList.BinarySearch(inElement, comparer);
            if (index < 0)
            {
                return null;
            }
            return inList[index];
        }
        public static bool BinarySearch<T>(List<T> inList, T inElement, IComparer<T> comparer, ref T value)
        {
            int index = inList.BinarySearch(inElement, comparer);
            if (index < 0)
            {
                return false;
            }
            value = inList[index];
            return true;
        }
        public static void InsertIntoSortedListAllowDuplicates<T>(List<T> inList, T inElement)
        {
            int index = inList.BinarySearch(inElement);
            if (index < 0)
            {
                index = ~index;
            }
            inList.Insert(index, inElement);
        }
        public static void InsertIntoSortedListAllowDuplicates<T>(List<T> inList, T inElement, IComparer<T> comparer)
        {
            int index = inList.BinarySearch(inElement, comparer);
            if (index < 0)
            {
                index = ~index;
            }
            inList.Insert(index, inElement);
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
        public static List<T> InsertIntoSortedList<T>(List<T> inList, IEnumerable<T> inElements)
        {
            if (CollectionUtils.IsNullOrEmpty(inElements))
            {
                return inList;
            }
            foreach (T element in inElements)
            {
                InsertIntoSortedList(inList, element);
            }
            return inList;
        }
        public static List<T> InsertIntoSortedListAllowDuplicates<T>(List<T> inList, IEnumerable<T> inElements)
        {
            if (CollectionUtils.IsNullOrEmpty(inElements))
            {
                return inList;
            }
            foreach (T element in inElements)
            {
                InsertIntoSortedListAllowDuplicates(inList, element);
            }
            return inList;
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
        public static void TrimToMaxSize<T>(List<T> inList, int maxSize)
        {
            if (inList.Count > maxSize)
            {
                inList.RemoveRange(maxSize, inList.Count - maxSize);
            }
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
        public static void RemoveKeys<T, V>(IDictionary<T, V> dict, IEnumerable<T> keys)
        {
            ForEach(keys, delegate(T key)
            {
                dict.Remove(key);
            });
        }
        public static void Reverse<T>(IList<T> list)
        {
            for (int low = 0, high = list.Count - 1; low < high; ++low, --high)
            {
                T temp = list[low];
                list[low] = list[high];
                list[high] = temp;
            }
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
        public static void AddRange<T>(IEnumerable<T> collection, ref List<T> list)
        {
            if (list == null)
            {
                list = new List<T>();
            }
            list.AddRange(collection);
        }
        public static T[] Add<T>(T obj, T[] list)
        {
            T[] rtnArray = new T[CollectionUtils.Count(list) + 1];
            if (list != null)
            {
                list.CopyTo(rtnArray, 0);
            }
            rtnArray[rtnArray.Length - 1] = obj;
            return rtnArray;
        }
        public static void Add<T>(IEnumerable<T> objectsToAdd, ref List<T> list)
        {
            if (IsNullOrEmpty(objectsToAdd))
            {
                return;
            }
            if (list == null)
            {
                list = new List<T>();
            }
            list.AddRange(objectsToAdd);
        }
        public static void Add<K, V>(K key, V value, ref Dictionary<K, V> dictionary)
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
            if (memberElementType == null)
            {
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
            if (CollectionUtils.IsNullOrEmpty(collections))
            {
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
        public delegate bool ForEachBreakDelegate<T>(T obj);

        public static void ForEachBreak<T>(IEnumerable<T> list, ForEachBreakDelegate<T> forEachProc)
        {
            if (!CollectionUtils.IsNullOrEmpty(list))
            {
                foreach (T obj in list)
                {
                    if (!forEachProc(obj))
                    {
                        break;
                    }
                }
            }
        }
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
        public static void ForEach(IEnumerable list, ForEachDelegate<object> forEachProc)
        {
            if (!CollectionUtils.IsNullOrEmpty(list))
            {
                foreach (object obj in list)
                {
                    forEachProc(obj);
                }
            }
        }
        public static string[] PrependItemToArray(ICollection<string> array, string itemToAdd)
        {
            return PrependItemToArray(array, itemToAdd, int.MaxValue);
        }
        public static string[] PrependItemToArray(ICollection<string> array, string itemToAdd, int maxLength)
        {
            int newLength = (array == null) ? 1 : array.Count + 1;
            if (newLength > maxLength)
            {
                newLength = maxLength;
            }
            if (newLength == 0)
            {
                return new string[0];
            }
            List<string> rtnList = new List<string>(newLength);
            rtnList.Add(itemToAdd);
            if ((newLength > 1) && !CollectionUtils.IsNullOrEmpty(array))
            {
                int count = 1;
                foreach (string item in array)
                {
                    if (!string.Equals(item, itemToAdd, StringComparison.InvariantCultureIgnoreCase))
                    {
                        rtnList.Add(item);
                        if (++count == newLength)
                        {
                            break;
                        }
                    }
                }
            }
            return rtnList.ToArray();
        }
        public static StringCollection PrependItemToStringCollection(StringCollection collection, string itemToAdd)
        {
            if (collection == null)
            {
                collection = new StringCollection();
            }
            else
            {
                for (int i = collection.Count - 1; i >= 0; --i)
                {
                    string value = collection[i];
                    if (string.Equals(value, itemToAdd, StringComparison.InvariantCultureIgnoreCase))
                    {
                        collection.RemoveAt(i);
                    }
                }
            }
            collection.Insert(0, itemToAdd);
            return collection;
        }
        public static List<string> CloneList(ICollection<string> list)
        {
            if (list == null)
            {
                return null;
            }
            return new List<string>(list);
        }
        public static List<T> Intersect<T>(ICollection<T> list1, ICollection<T> list2)
        {
            if ( CollectionUtils.IsNullOrEmpty(list1) || CollectionUtils.IsNullOrEmpty(list2) ) {
                return null;
            }
            if (list1 == list2)
            {
                return new List<T>(list1);
            }
            Dictionary<T, T> rtnList = new Dictionary<T, T>(Math.Min(list1.Count, list2.Count));
            if (list1.Count > list2.Count)
            { 
                ICollection<T> temp = list2;
                list2 = list1;
                list1 = temp;
            }
            foreach (T value in list1)
            {
                if (!rtnList.ContainsKey(value) && list2.Contains(value))
                {
                    rtnList[value] = value;
                }
            }
            return (rtnList.Count > 0) ? new List<T>(rtnList.Keys) : null;
        }
        public static List<T> Intersect<T>(ICollection<T> list1, ICollection<T> list2, IEqualityComparer<T> comparer)
        {
            if (CollectionUtils.IsNullOrEmpty(list1) || CollectionUtils.IsNullOrEmpty(list2))
            {
                return null;
            }
            if (list1 == list2)
            {
                return new List<T>(list1);
            }
            Dictionary<int, T> dict1 = new Dictionary<int, T>(list1.Count);
            Dictionary<int, T> dict2 = new Dictionary<int, T>(list2.Count);
            foreach (T value in list1)
            {
                int hashCode = comparer.GetHashCode(value);
                if (!dict1.ContainsKey(hashCode))
                {
                    dict1[hashCode] = value;
                }
            }
            foreach (T value in list2)
            {
                int hashCode = comparer.GetHashCode(value);
                if (!dict2.ContainsKey(hashCode))
                {
                    dict2[hashCode] = value;
                }
            }
            Dictionary<int, T> rtnList = new Dictionary<int, T>(Math.Min(dict1.Count, dict2.Count));
            if (dict1.Count > dict2.Count)
            {
                Dictionary<int, T> temp = dict2;
                dict2 = dict1;
                dict1 = temp;
            }
            foreach (KeyValuePair<int, T> pair in dict1)
            {
                if (dict2.ContainsKey(pair.Key))
                {
                    rtnList[pair.Key] = pair.Value;
                }
            }
            return (rtnList.Count > 0) ? new List<T>(rtnList.Values) : null;
        }
        public static bool Contains<T>(IEnumerable<T> list, T element, IEqualityComparer<T> comparer)
        {
            return (IndexOf(list, element, comparer) >= 0);
        }
        public static int IndexOf<T>(IEnumerable<T> list, T element, IEqualityComparer<T> comparer)
        {
            int index = 0, rtnIndex = -1;
            CollectionUtils.ForEachBreak(list, delegate(T checkElement)
            {
                if (comparer.Equals(element, checkElement))
                {
                    rtnIndex = index;
                    return false;
                }
                ++index;
                return true;
            });
            return rtnIndex;
        }
        public static bool Contains(IEnumerable<string> list, string element, StringComparison comparison)
        {
            return (IndexOf(list, element, comparison) >= 0);
        }
        public static int IndexOf(IEnumerable<string> list, string element, StringComparison comparison)
        {
            int index = 0, rtnIndex = -1;
            CollectionUtils.ForEachBreak(list, delegate(string checkElement)
            {
                if ( string.Equals(element, checkElement, comparison) )
                {
                    rtnIndex = index;
                    return false;
                }
                ++index;
                return true;
            });
            return rtnIndex;
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
        public static List<T> CreateList<T>(params T[] items)
        {
            return new List<T>(items);
        }
        public static T[] TrimArray<T>(T[] array, int maxLength)
        {
            if ((array != null) && (array.Length > maxLength))
            {
                Array.Resize(ref array, maxLength);
            }
            return array;
        }
        public static List<string> MergeLists(ICollection<string> list1, ICollection<string> list2)
        {
            if (CollectionUtils.IsNullOrEmpty(list1))
            {
                return new List<string>(list2);
            }
            else if (CollectionUtils.IsNullOrEmpty(list2))
            {
                return new List<string>(list1);
            }
            List<string> newList = new List<string>(list1.Count + list2.Count);
            InsertIntoSortedList(newList, list1);
            InsertIntoSortedList(newList, list2);
            return newList;
        }
        public static bool ContainsElementOfType<T>(IEnumerable<T> list, Type type)
        {
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                return false;
            }
            if (!typeof(T).IsAssignableFrom(type))
            {
                return false;
            }
            foreach (T element in list)
            {
                if ((element != null) && (element.GetType() == type))
                {
                    return true;
                }
            }
            return false;
        }
        public static List<KeyValuePair<TKey, TValue>> GetSortedByValue<TKey, TValue>(Dictionary<TKey, TValue> dict) where TValue : IComparable
        {
            List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(dict);
            list.Sort(delegate(KeyValuePair<TKey, TValue> pairA, KeyValuePair<TKey, TValue> pairB)
            {
                return pairA.Value.CompareTo(pairB.Value);
            });
            return list;
        }
        public static bool StringCollectionsAreEqual(IEnumerable<string> c1, IEnumerable<string> c2, StringComparison comparison)
        {
            if (Object.ReferenceEquals(c1, c2))
            {
                return true;
            }
            if (((object)c1 == null) || ((object)c2 == null))
            {
                return false;
            }
            IEnumerator<string> e1 = c1.GetEnumerator();
            IEnumerator<string> e2 = c2.GetEnumerator();
            for(;;)
            {
                bool moved1 = e1.MoveNext();
                bool moved2 = e2.MoveNext();
                if (moved1 != moved2)
                {
                    return false;
                }
                if (!moved1)
                {
                    return true;
                }
                if (!string.Equals(e1.Current, e2.Current, comparison))
                {
                    return false;
                }
            }
        }
        public static Dictionary<string, string> CreateStringLookup(ICollection<string> list, bool uppercaseStrings)
        {
            Dictionary<string, string> lookup = null;
            if (!CollectionUtils.IsNullOrEmpty(list))
            {
                lookup = new Dictionary<string, string>(list.Count);
                foreach (string value in list)
                {
                    string key = uppercaseStrings ? value.ToUpper() : value;
                    if (!lookup.ContainsKey(key))
                    {
                        lookup.Add(key, value);
                    }
                }
            }
            return lookup;
        }
    }
}
