using System.Xml.Linq;

namespace _2.zh_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // XML beolvasas

            var categories = new List<Category>();

            var xdoc = XDocument.Load("termekek.xml");
            foreach (var category in xdoc.Descendants("Category"))
            {
                var productsXML = category.Element("Products").Elements("Product"); // ElementS!!!! mivel adott kategorian belul egy products van de tobb product
                var products = new List<Product>();

                foreach (var product in productsXML)
                {
                    products.Add(new Product
                    {
                        Sku = product.Element("Sku").Value,
                        Name = product.Element("Name").Value,
                        Price = int.Parse(product.Element("Price").Value)
                    });
                }
                categories.Add(new Category
                {
                    Name = category.Element("Name").Value,
                    Products = products
                });
            }

            // JSON beolvasas
            var categoriesJSON = new List<CategoryJ>();

            XDocument xdocJ = XDocument.Load("Products.json");
            foreach (var category in xdocJ.Descendants("Category"))
            {
                var productsJSON = category.Element("Products").Elements("Product");
                var productsJ = new List<ProductJ>();

                foreach (var product in productsJSON)
                {
                    productsJ.Add(new ProductJ
                    {
                        SkuJ = product.Element("Sku").Value,
                        NameJ = product.Element("Name").Value,
                        PriceJ = int.Parse(product.Element("Price").Value)
                    });
                }

                categoriesJSON.Add(new CategoryJ
                {
                    NameJ = category.Element("Name").Value,
                    ProductsJ = productsJ
                });
            }
            ;
        }
    }
}
