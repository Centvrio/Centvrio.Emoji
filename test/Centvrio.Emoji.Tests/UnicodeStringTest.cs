using Xunit;

namespace Centvrio.Emoji.Tests
{
    public class UnicodeStringTest
    {
        [Fact]
        public void ToCharArray_method()
        {
            UnicodeString smile = 0x1F600;
            char[] pair = smile.ToCharArray();
            Assert.True(char.IsHighSurrogate(pair[0]) && char.IsLowSurrogate(pair[1]));
        }

        [Fact]
        public void Add_op()
        {
            UnicodeSequence sequence = (UnicodeString)0x1F9D2 + 0x1F3FB;
            string expected = sequence.ToString();
            string actual = "🧒🏻";
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(0x1F600, "😀")]
        public void Equals_implementation(int code, string smile)
        {
            UnicodeString unicode = FacePositive.Grinning;
            Assert.True(unicode.Equals(code));
            Assert.True(unicode.Equals(smile));
        }
    }
}
