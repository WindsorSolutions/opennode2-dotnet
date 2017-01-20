using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Security.Permissions;

namespace Hyper.ComponentModel
{
    public sealed class HyperTypeDescriptionProvider : TypeDescriptionProvider
    {
        private static Dictionary<Type, HyperTypeDescriptionProvider> _addedProviders = new Dictionary<Type, HyperTypeDescriptionProvider>();
        public static void Add(Type type)
        {
            lock (_addedProviders)
            {
                if (!_addedProviders.ContainsKey(type))
                {
                    TypeDescriptionProvider parent = TypeDescriptor.GetProvider(type);
                    HyperTypeDescriptionProvider provider = new HyperTypeDescriptionProvider(parent);
                    TypeDescriptor.AddProvider(provider, type);
                    _addedProviders[type] = provider;
                }
            }
        }
        public HyperTypeDescriptionProvider()
            : this(typeof(object))
        {
        }
        public HyperTypeDescriptionProvider(Type type)
            : this(TypeDescriptor.GetProvider(type))
        {
        }
        public HyperTypeDescriptionProvider(TypeDescriptionProvider parent)
            : base(parent)
        {
        }
        public static void Clear(Type type)
        {
            lock (descriptors)
            {
                descriptors.Remove(type);
            }
        }
        public static void Clear()
        {
            lock (descriptors)
            {
                descriptors.Clear();
            }
        }
        private static readonly Dictionary<Type, ICustomTypeDescriptor> descriptors = new Dictionary<Type, ICustomTypeDescriptor>();
        public sealed override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor descriptor;
            lock (descriptors)
            {
                if (!descriptors.TryGetValue(objectType, out descriptor))
                {
                    try
                    {
                        descriptor = BuildDescriptor(objectType);
                    }
                    catch
                    {
                        return base.GetTypeDescriptor(objectType, instance);
                    }
                }
                return descriptor;
            }
        }
        //[ReflectionPermission(SecurityAction.Assert, Flags = ReflectionPermissionFlag.AllFlags)]
        private ICustomTypeDescriptor BuildDescriptor(Type objectType)
        {
            // NOTE: "descriptors" already locked here

            // get the parent descriptor and add to the dictionary so that
            // building the new descriptor will use the base rather than recursing
            ICustomTypeDescriptor descriptor = base.GetTypeDescriptor(objectType, null);
            descriptors.Add(objectType, descriptor);
            try
            {
                // build a new descriptor from this, and replace the lookup
                descriptor = new HyperTypeDescriptor(descriptor);
                descriptors[objectType] = descriptor;
                return descriptor;
            }
            catch
            {   // rollback and throw
                // (perhaps because the specific caller lacked permissions;
                // another caller may be successful)
                descriptors.Remove(objectType);
                throw;
            }
        }
    }
}
