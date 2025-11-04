using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            //List<CategoryJ> catergoryJs = JsonConvert.DeserializeObject<List<CategoryJ>>(File.ReadAllText("Products.json"));

            // A beolvasott objektumotkat szűrd le, hogy csak a 10000-nél drágább termékeket szeretnénk ismerni és mentsd el őket az újonnan létrejövő adatbázisba.

            var context = new PackageDbContext();

            foreach (var category in categories)
            {
                category.Products = category.Products
                    .Where(p => p.Price > 10000)
                    .ToList();
            }
            
            context.Categories.AddRange(categories); // itt kerul bele az adatbazisba
            context.SaveChanges();

            // Adatbazis kiiratasa ----------

            var savedCategories = context.Categories
                .Include(c => c.Products)
                .ToList();

            foreach (var cat in savedCategories)
            {
                Console.WriteLine($"\nKategória: {cat.Name}");
                foreach (var prod in cat.Products)
                {
                    Console.WriteLine($"\tTermék: {prod.Name} (Ár: {prod.Price})");
                }
            }
            // ------------------------------
        }
    }
}
