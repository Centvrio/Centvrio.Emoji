using System;

namespace Centvrio.Emoji
{
    public struct EmojiString : IEquatable<EmojiString>, IComparable, IComparable<EmojiString>
    {
        /// <summary>
        /// Emoji code (UTF32)
        /// </summary>
        public int Code { get; set; }

        public bool Equals(EmojiString other) => Code == other.Code;

        public int CompareTo(EmojiString other) => Code.CompareTo(other.Code);

        public int CompareTo(object obj) => Code.CompareTo(obj);

        public override bool Equals(object obj)
        {
            if (!(obj is EmojiString))
            {
                return false;
            }
            var other = (EmojiString)obj;
            return Code == other.Code;
        }

        public override int GetHashCode() => Code;

        /// <summary>
        /// Convert the UTF32 emoji representation to its equivalent UTF16 string.
        /// </summary>
        /// <returns>The UTF16 string.</returns>
        public override string ToString() => char.ConvertFromUtf32(Code);

        public static implicit operator EmojiString(int code) => new EmojiString { Code = code };

        public static explicit operator int(EmojiString emojiString) => emojiString.Code;

        public static bool operator ==(EmojiString left, EmojiString right) => left.Code == right.Code;

        public static bool operator !=(EmojiString left, EmojiString right) => left.Code != right.Code;

        public static bool operator >(EmojiString left, EmojiString right) => left.Code > right.Code;

        public static bool operator <(EmojiString left, EmojiString right) => left.Code < right.Code;

        public static bool operator >=(EmojiString left, EmojiString right) => left.Code >= right.Code;

        public static bool operator <=(EmojiString left, EmojiString right) => left.Code <= right.Code;
    }
}
