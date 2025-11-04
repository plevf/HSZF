using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.zh_gyak
{

    //public class RootobjectJ
    //{
    //    public ProductpackageJ ProductPackageJ { get; set; }
    //}

    //public class ProductpackageJ
    //{
    //    public CategoriesJ CategoriesJ { get; set; }
    //}

    //public class CategoriesJ
    //{
    //    public Category[] CategoryJ { get; set; }
    //}

    public class CategoryJ
    {
        public int Id { get; set; }
        public string NameJ { get; set; } = string.Empty;
        public List<ProductJ> ProductsJ { get; set; } = new List<ProductJ>();
    }

    //public class ProductsJ
    //{
    //    public Product[] ProductJ { get; set; }
    //}

    public class ProductJ
    {
        public int Id { get; set; }
        [RequiredNonEmpty]
        public string? SkuJ { get; set; }
        public string NameJ { get; set; }
        public int PriceJ { get; set; }
    }

}
