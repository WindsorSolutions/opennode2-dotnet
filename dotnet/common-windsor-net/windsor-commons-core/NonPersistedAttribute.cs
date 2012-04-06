using System;
using System.Collections.Generic;
using System.Text;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Marks a class or property as an entity that should not be persisted in any way
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Property)]
    public class NonPersistedAttribute : System.Attribute
    {
        public NonPersistedAttribute() { }
    }
}
