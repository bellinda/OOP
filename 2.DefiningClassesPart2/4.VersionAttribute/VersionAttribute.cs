using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface |
        AttributeTargets.Method | AttributeTargets.Struct, AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        public string Version { get; private set; }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}