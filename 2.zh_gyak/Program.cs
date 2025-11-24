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
                    .Where(p => p.Price > 10000 && Validator.Isvalid(p))
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
            Console.WriteLine();
            // ------------------------------

            // Bónusz2: JSON
            


            // Adatbazis kiiratasa ----------
            Console.WriteLine("\nJSON\n");


            // Bonusz 3 kiiratasa

            foreach (var cat in categories)
            {
                foreach (var prod in cat.Products)
                {
                    if (!Validator.IsWithinPriceRange(prod))
                    {
                        Console.WriteLine($"{prod.Name}'s price value is invalid! ({prod.Price})");
                    }
                }
            }

            // Eloadas zh tesztelgetes

            var dbRes = context.Categories.Where(c => c.Name.StartsWith("E"));
            var listRes = categories.Where(c => c.Name.StartsWith("E"));

            Console.WriteLine(categories[3].GetType()); // peldanyon hivom meg, forditasi idoben adja meg a tipust
            Console.WriteLine(typeof(Category)); // objektumon hivom meg, futasi idoben adja meg a tipust

            /*
            Az event egy multicast delegate-et használ.
            Ez azt jelenti, hogy EGY eseményhez több metódus is feliratkozhat, és amikor az esemény bekövetkezik, minden feliratkozott metódus lefut, egymás után.
             */

            categories.Exists(c => c.Name == "Electronics");
            categories.Except(savedCategories);
            categories.Distinct();
            string s = "";
            Console.WriteLine(s.Length);
            IEnumerable<string> strings = new List<string> { "apple", "banana", "kiwi" };
            var lengths = strings.Lengths(); // nem adunk neki parametert, extension és itt még nem fut le
            foreach (var length in lengths)
            {
                Console.WriteLine(length);
            }
            Console.WriteLine("-------------------------");
            var c = new Category();
            var type1 = c.GetType();
            var type2 = typeof(Category);
            var props = type2.GetProperties();
            Console.WriteLine(c);
            Console.WriteLine(type1);
            Console.WriteLine(type2);
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
            }
            var lengths2 = strings // valoban nem fut le a select, amig nem iteralunk rajta
                .Select(s =>
                {
                    Console.WriteLine("Select fut: " + s);
                    return s.Length;
                });
            foreach (var length in lengths2) // itt fut le a select
            {
                Console.WriteLine("Length: " + length);
            }
        }
    }
    public static class StringExtensions
    {
        public static IEnumerable<int> Lengths(this IEnumerable<string> source) // a this miatt extension method!!
        {
            return source.Select(s => s.Length);
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
