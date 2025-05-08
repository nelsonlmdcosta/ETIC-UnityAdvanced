
using UnityEngine;

namespace ProjectUtils
{

    [System.Serializable]
    public class HashedName
    {
        [field: SerializeField] public string StringValue { get; set; }
        [field: SerializeField] public int HashValue { get; set;  }

        public HashedName(string name)
        {
            StringValue = name;
            HashValue = name.GetHashCode();
        }

        // TODO: Check For Null Objects
        // Hash To Hash
        public static bool operator ==(HashedName left, HashedName right)
        {
            return left.HashValue == right.HashValue;
        }

        public static bool operator !=(HashedName left, HashedName right)
        {
            return left.HashValue != right.HashValue;
        }

        // Has To String
        public static bool operator ==(HashedName left, string right)
        {
            return left.HashValue == new HashedName(right).HashValue;
        }

        public static bool operator !=(HashedName left, string right)
        {
            return left.HashValue != new HashedName(right).HashValue;
        }

        public static bool operator ==(string left, HashedName right)
        {
            return new HashedName(left).HashValue == right.HashValue;
        }

        public static bool operator !=(string left, HashedName right)
        {
            return new HashedName(left).HashValue != right.HashValue;
        }
    }
}