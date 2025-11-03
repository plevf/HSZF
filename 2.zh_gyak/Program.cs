using System.Xml.Linq;

namespace _2.zh_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var categories = new List<Category>();

            XDocument xdoc = new XDocument("termekek.xml");
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
                    Id = int.Parse(category.Element("Id").Value),
                    Name = category.Element("Name").Value,
                    Products = products
                });
            }
        }
    }
}
