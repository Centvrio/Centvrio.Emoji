using System;

namespace Centvrio.Emoji
{
    public struct UnicodeString : IEquatable<UnicodeString>, IComparable, IComparable<UnicodeString>
    {
        /// <summary>
        /// Emoji code (UTF32)
        /// </summary>
        public int Code { get; set; }

        public bool Equals(UnicodeString other) => Code == other.Code;

        public int CompareTo(UnicodeString other) => Code.CompareTo(other.Code);

        public int CompareTo(object obj) => Code.CompareTo(obj);

        public override bool Equals(object obj)
        {
            if (!(obj is UnicodeString))
            {
                return false;
            }
            var other = (UnicodeString)obj;
            return Code == other.Code;
        }

        public override int GetHashCode() => Code;

        /// <summary>
        /// Convert the UTF32 emoji representation to its equivalent UTF16 string.
        /// </summary>
        /// <returns>The UTF16 string.</returns>
        public override string ToString() => char.ConvertFromUtf32(Code);

        public static implicit operator UnicodeString(int code) => new UnicodeString { Code = code };

        public static explicit operator int(UnicodeString emojiString) => emojiString.Code;

        public static bool operator ==(UnicodeString left, UnicodeString right) => left.Code == right.Code;

        public static bool operator !=(UnicodeString left, UnicodeString right) => left.Code != right.Code;

        public static bool operator >(UnicodeString left, UnicodeString right) => left.Code > right.Code;

        public static bool operator <(UnicodeString left, UnicodeString right) => left.Code < right.Code;

        public static bool operator >=(UnicodeString left, UnicodeString right) => left.Code >= right.Code;

        public static bool operator <=(UnicodeString left, UnicodeString right) => left.Code <= right.Code;
    }
}
