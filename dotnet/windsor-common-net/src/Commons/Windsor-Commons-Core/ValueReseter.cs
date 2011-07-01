using System;
using System.Collections.Generic;
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
    public static class ValueReseter
    {
        public delegate void MethodDelegate();

        public static void CallMethod<T>(ref T valueToModify, T newValueToSet, MethodDelegate del)
        {
            T saveValue = valueToModify;
            valueToModify = newValueToSet;
            try
            {
                del();
            }
            finally
            {
                valueToModify = saveValue;
            }
        }
    }
}
