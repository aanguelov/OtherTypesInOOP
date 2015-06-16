using System;

namespace _03_GenericList
{
    [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Interface|AttributeTargets.Enum
                    |AttributeTargets.Method|AttributeTargets.Class)]
    class VersionAttribute : System.Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public override string ToString()
        {
            return string.Format("Version {0}.{1}", this.Major, this.Minor);
        }
    }
}
