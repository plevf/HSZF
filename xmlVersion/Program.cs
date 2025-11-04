using System.Xml.Linq;

namespace xmlVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var categories = new List<Category>();

            XDocument xdox = XDocument.Load("termekek.xml");
            foreach (var category in xdox.Descendants("Category"))
            {
                var prodXML = category.Element("Products").Elements("Product");
                var products = new List<Product>();

                foreach (var prod in prodXML)
                {
                    products.Add(new Product
                    {
                        Sku = prod.Element("Sku").Value,
                        Name = prod.Element("Name").Value,
                        Price = int.Parse(prod.Element("Price").Value)
                    });
                }
                categories.Add(new Category
                {
                    Name = category.Element("Name").Value,
                    Products = products
                });
            }

            PackageDbContext db = new PackageDbContext();

            foreach (var category in categories)
            {
                category.Products = category.Products
                    .Where(p => p.Price > 10000 && Validator.IsValid(p))
                    .GroupBy(p => p.Sku)
                    .Select(p => p.First())
                    .ToList();
            }

            db.Categories.AddRange(categories);
            db.SaveChanges();
        }
    }
}
