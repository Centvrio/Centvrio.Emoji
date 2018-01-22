using Xunit;

namespace Centvrio.Emoji.Tests
{
    public class UnicodeSequenceTest
    {
        [Fact]
        public void Add_op()
        {
            UnicodeSequence sequence = (UnicodeString)0x0030 + 0xFE0F + 0x20E3;
            int expected = sequence.Capacity;
            int actual = 3;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_op_null()
        {
            UnicodeSequence sequence = null;
            UnicodeSequence expected = sequence + 0xFE0F;
            Assert.Null(expected);
        }

        [Fact]
        public void Unicode_string_equals()
        {
            UnicodeSequence sequence = new UnicodeSequence(3)
                .Add(0x1F468)
                .Add(0x200D)
                .Add(0x1F466);
            string expected = sequence.ToString();
            string actual = "👨‍👦";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Create_country_flag()
        {
            UnicodeSequence expected = RegionalIndicator.U + RegionalIndicator.A;
            string actual = "🇺🇦";
            Assert.Equal(expected.ToString(), actual);
        }
    }
}
