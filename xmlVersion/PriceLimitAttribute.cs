
namespace xmlVersion
{
    public class PriceLimitAttribute : Attribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public PriceLimitAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}