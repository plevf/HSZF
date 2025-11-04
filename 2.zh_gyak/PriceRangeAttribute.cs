
namespace _2.zh_gyak
{
    public class PriceRangeAttribute : Attribute
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public PriceRangeAttribute(int minPrice, int maxPrice)
        {
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}