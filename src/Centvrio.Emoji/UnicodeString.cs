using System;
using System.Collections.Generic;

namespace Centvrio.Emoji
{
    public struct UnicodeString : IEquatable<UnicodeString>, IComparable, IComparable<UnicodeString>
    {
        /// <summary>
        /// Emoji code (UTF32)
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Convert UTF32 to UTF16 character array
        /// </summary>
        /// <exception cref="InvalidOperationException"/>
        /// <returns>UTF16 character array</returns>
        public char[] ToCharArray()
        {
            if ((Code >= 0xD800 && Code <= 0xDFFF) || (Code < 0 || Code > 0x10FFFF))
            {
                throw new InvalidOperationException();
            }
            if (Code <= 0xFFFF)
            {
                return new char[1] { (char)Code};
            }
            char[] pair = new char[2];
            int code = Code - 0x10000;
            int high = (code >> 10) + 0xD800;
            int low = (code & 0x3ff) + 0xDC00;
            pair[0] = (char)high;
            pair[1] = (char)low;
            return pair;
        }

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

        public static UnicodeSequence operator +(UnicodeString left, UnicodeString right) 
            => new UnicodeSequence(2)
                .Add(left)
                .Add(right);

        public static bool operator ==(UnicodeString left, UnicodeString right) => left.Code == right.Code;

        public static bool operator !=(UnicodeString left, UnicodeString right) => left.Code != right.Code;

        public static bool operator >(UnicodeString left, UnicodeString right) => left.Code > right.Code;

        public static bool operator <(UnicodeString left, UnicodeString right) => left.Code < right.Code;

        public static bool operator >=(UnicodeString left, UnicodeString right) => left.Code >= right.Code;

        public static bool operator <=(UnicodeString left, UnicodeString right) => left.Code <= right.Code;
    }
}
