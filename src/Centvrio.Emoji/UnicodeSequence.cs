using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Centvrio.Emoji
{
    public class UnicodeSequence : IEnumerable<UnicodeString>
    {
        private readonly IList<UnicodeString> unicodeStrings;

        public UnicodeSequence(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capacity is less than 0");
            }
            Capacity = capacity;
            unicodeStrings = new List<UnicodeString>(capacity);
        }

        public int Capacity { get; private set; }

        public UnicodeSequence Add(UnicodeString unicodeString)
        {
            unicodeStrings.Add(unicodeString);
            return this;
        }

        public IEnumerator<UnicodeString> GetEnumerator()
        {
            foreach (UnicodeString unicodeString in unicodeStrings)
            {
                yield return unicodeString;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            var sb = new StringBuilder(unicodeStrings.Count * 2);
            foreach (UnicodeString unicodeString in unicodeStrings)
            {
                sb.Append(unicodeString.ToCharArray());
            }
            return sb.ToString();
        }

        public static UnicodeSequence operator +(UnicodeSequence left, UnicodeString right)
        {
            if (left == null)
            {
                return null;
            }
            left.Capacity++;
            return left.Add(right);
        }
    }
}
