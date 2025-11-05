using Newtonsoft.Json;
using System.Text.Json;
using xmlVersion;

namespace jsonVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string jsonString = File.ReadAllText("termekek.json");

            // A deszerializálás itt 'JsonConvert.DeserializeObject'
            Rootobject? data = JsonConvert.DeserializeObject<Rootobject>(jsonString);

            //// Az adatok feldolgozása ugyanaz, mint a fenti példában...
            //if (data != null && data.ProductPackage != null)
            //{
            //    Console.WriteLine("Beolvasva Newtonsoft.Json segítségével:");
            //    foreach (var category in data.ProductPackage.Categories)
            //    {
            //        Console.WriteLine($"Kategória: {category.Name}");
            //        foreach (var prod in category.Products)
            //        {
            //            Console.WriteLine($"Name: {prod.Name}");
            //        }
            //    }
            //}

            foreach (var categ in data.ProductPackage.Categories)
            {
                categ.Products = categ.Products
                    .Where(p => p.Price > 10000)
                    .ToList();
            }
            

            PackageDbContext db = new PackageDbContext();
            db.Categories.AddRange(data.ProductPackage.Categories);
            db.SaveChanges();
        }
    }


}
