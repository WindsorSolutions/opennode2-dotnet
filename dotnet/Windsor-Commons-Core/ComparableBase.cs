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

﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Windsor.Commons.Core
{
    public abstract class ComparableBase<T> : IComparable<T> where T : class
    {
        public abstract int CompareTo(T other);

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public T This
        {
            get { return this as T; }
        }
        public override bool Equals(object obj)
        {
            T compareObject = obj as T;
            if (compareObject != null)
            {
                return Equals(compareObject);
            }
            else
            {
                return false;
            }
        }
        public virtual bool Equals(T obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;

            return (this.CompareTo(obj) == 0);
        }
        public static bool operator ==(ComparableBase<T> a, ComparableBase<T> b)
        {
            if (Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null)) return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null)) return false;
            return a.Equals(b.This);
        }
        public static bool operator !=(ComparableBase<T> a, ComparableBase<T> b)
        {
            return !(a == b);
        }
        public static bool operator >(ComparableBase<T> a, ComparableBase<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return false;
            return (a.CompareTo(b.This) > 0);
        }
        public static bool operator <(ComparableBase<T> a, ComparableBase<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return (!Object.ReferenceEquals(b, null));
            return (a.CompareTo(b.This) < 0);
        }
        public static bool operator >=(ComparableBase<T> a, ComparableBase<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return (Object.ReferenceEquals(b, null));
            return (a.CompareTo(b.This) >= 0);
        }
        public static bool operator <=(ComparableBase<T> a, ComparableBase<T> b)
        {
            if (Object.ReferenceEquals(a, null)) return true;
            return (a.CompareTo(b.This) <= 0);
        }
    }
}