using System;
using System.Collections.Generic;
using System.Text;

namespace IKW.GraphEngine.TripleStore.MemoryCloudService
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal class UseExtensionAttribute : Attribute
    {
        public UseExtensionAttribute(Type _) { }
    }
}
