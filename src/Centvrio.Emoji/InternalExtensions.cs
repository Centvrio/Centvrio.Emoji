namespace Centvrio.Emoji
{
    internal static class InternalExtensions
    {
        internal static bool IsInvalid(this int value)
        {
            return (value >= 0xD800 && value <= 0xDFFF) || (value < 0 || value > 0x10FFFF);
        }

        internal static bool IsSingle(this int value)
        {
            return value <= 0xFFFF;
        }
    }
}
