using System;

namespace Centvrio.Emoji
{
    public struct UnicodeString : IEquatable<UnicodeString>, IEquatable<int>, IEquatable<string>, IComparable, IComparable<UnicodeString>, IComparable<int>, IComparable<string>
    {
        /// <summary>
        /// Emoji code (UTF32)
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Convert UTF32 to UTF16 character array
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Code is not a valid Unicode code point ranging from U+0 through U+10FFFF, excluding the surrogate pair range from U+D800 through U+DFFF.
        /// </exception>
        /// <returns>UTF16 character array</returns>
        public char[] ToCharArray()
        {
            if (Code.IsInvalid())
            {
                throw new InvalidOperationException("Code is not a valid Unicode code point ranging from U+0 through U+10FFFF, excluding the surrogate pair range from U+D800 through U+DFFF.");
            }
            if (Code.IsSingle())
            {
                return new char[1] { (char)Code };
            }
            char[] pair = new char[2];
            int code = Code - 0x10000;
            int high = (code >> 10) + 0xD800;
            int low = (code & 0x3ff) + 0xDC00;
            pair[0] = (char)high;
            pair[1] = (char)low;
            return pair;
        }

        public int CompareTo(UnicodeString other) => Code.CompareTo(other.Code);

        public int CompareTo(int other) => Code.CompareTo(other);

        public int CompareTo(string other) => ToString().CompareTo(other);

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case UnicodeString ustring:
                    return CompareTo(ustring);
                case int number:
                    return CompareTo(number);
                case string str when !string.IsNullOrEmpty(str):
                    return CompareTo(str);
                case null:
                    return 1;
            }
            throw new ArgumentException("Argument must be UnicodeString, Int32 or String");
        }

        public bool Equals(UnicodeString other) => Code == other.Code;

        public bool Equals(int other) => Code == other;

        public bool Equals(string other) => ToString() == other;

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case UnicodeString ustring:
                    return Equals(ustring);
                case int number:
                    return Equals(number);
                case string str when !string.IsNullOrEmpty(str):
                    return Equals(str);
            }
            return false;
        }

        public override int GetHashCode() => Code;

        /// <summary>
        /// Convert the UTF32 emoji representation to its equivalent UTF16 string.
        /// </summary>
        /// <returns>The UTF16 string.</returns>
        public override string ToString()
        {
            if (Code.IsSingle())
            {
                return new string((char)Code, 1);
            }
            return char.ConvertFromUtf32(Code);
        }

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
