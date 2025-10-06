using minta_zh.Exceptions;
using System.Diagnostics.Metrics;
using System.Threading.Channels;

namespace minta_zh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandler<CarCounterByBrandEventArgs> handler = (sender, args) => Console.WriteLine($"There are {args.Count} {args.Brand}-s in your file - Sender: {sender}");

            var service = new CarService(); // file betoltes ebben az osztalyban

            
            string fileName = "autok.txt";
            var fi = new FileInfo(fileName);
            try
            {
                List<Car> cars = service.ReadFile(fileName);

                var carCounter = new CarCounter();
                carCounter.CarCountByBrand += handler; // feliratkozas
                carCounter.Counter(cars, "BMW"); // event kivaltasa
            }
            catch (EmptyFileException)
            {
                Console.WriteLine("EmptyFileException catched");
            }
            catch (NoExistingFileException)
            {
                Console.WriteLine("NoExistingFileException catched");
            }
            catch (ReadingFailedException)
            {
                Console.WriteLine("ReadingFailedException catched");
            }

            //LINQ ----------------------------------------------------------------

            List<Car> carsForLinq = service.ReadFile(fileName);

            // áruk szerint csökkenő sorrend
            var desc = carsForLinq.OrderByDescending(p => p.Price);
            Console.WriteLine("\nPrices descending:\n");
            foreach (var item in desc)
            {
                Console.WriteLine($"{item.Type} - {item.Price} Ft");
            }

            Console.WriteLine("\nCheapest car(s):\n");
            // legolcsobb
            var min = carsForLinq.Min(p => p.Price);
            foreach (var item in carsForLinq)
            {
                if(item.Price == min)
                {
                    Console.WriteLine($"{item.Type} - {item.Price} Ft");
                }
            }

            Console.WriteLine("\nMost expensive car(s):\n");
            // legdragabb
            var max = carsForLinq.Max(p => p.Price);
            foreach (var item in carsForLinq)
            {
                if (item.Price == max)
                {
                    Console.WriteLine($"{item.Type} - {item.Price} Ft");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Anonym object:");
            Console.WriteLine();

            // Add vissza egy anonym objektumba az autók teljes nevét (Brand – Model), az évjáratát, és az életkorát.

            var anonymobject = carsForLinq.
                Select(t => new
                {
                    Name = t.Brand + " - " + t.Type,
                    Age = DateTime.Now.Year - t.Year
                });
            foreach (var t in anonymobject)
            {
                Console.WriteLine(t.Name + ": " + t.Age + "year(s) old");
            }

            Console.WriteLine();
            Console.WriteLine("Márkánként darabszám, ár-átlag szerint csökkenő:");
            Console.WriteLine();
            // Add vissza az autókat márkánként darabszám, ár-átlag szerint csökkenő.

            var brandsOrderedByAvgPrice = carsForLinq
                .GroupBy(p => p.Brand)
                .Select(t => new
                {
                    Brand = t.Key,
                    AvgPrice = t.Average(p => p.Price),
                    Count = t.Count(),
                    Cars = t.ToList() // csak a kiiras kedveert (minden markahoz keszul egy lista)
                })
                .OrderByDescending(t => t.AvgPrice);

            foreach (var item in brandsOrderedByAvgPrice)
            {
                Console.WriteLine($"\n{item.Brand} - (Average price: {item.AvgPrice})\n");
                foreach (var p in item.Cars)
                {
                    Console.WriteLine($"{p.Type}: {p.Price} Ft");
                }
            }

            //var brandsOrderedByAvgPriceGroupBy = carsForLinq
            //    .GroupBy(p => p.Brand);

            //foreach (var brand in brandsOrderedByAvgPriceGroupBy) // sima group by esetén kiírás
            //{
            //    Console.WriteLine($"\n{brand.Key}:\n");
            //    foreach (var car in brand)
            //    {
            //        Console.WriteLine($"{car.Type}: {car.Price} Ft");
            //    }
            //}
        }
    }
}
