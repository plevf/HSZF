using minta_zh_gyak.Exceptions;
using minta_zh_gyak.Models;
using System.Reflection.Metadata.Ecma335;

namespace minta_zh_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandler<CarCounterByBrandEventArgs> handler = (sender, e) => Console.WriteLine($"There are {e.Count} {e.Brand}(-s) in the database. Sender: {sender}");

            var service = new CarService();
            var carCounter = new CarCounterByBrand();

            string fileName = "autok.txt";

            try
            {
                var cars = service.ReadFile(fileName);
                carCounter.carCounterByBrandEvent += handler;
                carCounter.Counter(cars, "BMW");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("FileNotFoundException caught: " + ex.Message);
            }
            catch (EmptyFileException ex)
            {
                Console.WriteLine("EmptyFileException caught: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " caught");
            }

            // LINQ

            var carsForLinq = service.ReadFile(fileName);

            // 1.
            var orderedByPriceDesc = carsForLinq.OrderByDescending(p => p.Price);
            foreach (var car in orderedByPriceDesc)
            {
                Console.WriteLine($"{car.Brand} - {car.Type} - {car.Year} {car.Price} Ft");
            }

            Console.WriteLine();

            // 2.

            var cheapestCar = carsForLinq.Min(p => p.Price);

            foreach(var car in carsForLinq)
            {
                if(cheapestCar == car.Price)
                {
                    Console.WriteLine($"{car.Brand} - {car.Type} - {car.Year} {car.Price} Ft");
                }
            }
            Console.WriteLine();

            var mostExpCar = carsForLinq.Max(p => p.Price);

            foreach (var car in carsForLinq)
            {
                if (mostExpCar == car.Price)
                {
                    Console.WriteLine($"{car.Brand} - {car.Type} - {car.Year} {car.Price} Ft");
                }
            }

            // 3.

            var anonymObject = carsForLinq.Select(t => new
            {
                Name = t.Brand + " - " + t.Type,
                Year = t.Year,
                Age = DateTime.Now.Year - t.Year
            });

            // 4.

            var groupByBrandOrderByAvgPrice = carsForLinq
                .GroupBy(p => p.Brand)
                .Select(p => new
                {
                    Name = p.Key,
                    Count = p.Count(),
                    AvgPrice = p.Average(p => p.Price)
                })
                .OrderByDescending(p => p.AvgPrice);

            // Analyze

            int selectedYear = 2019;
            var carFin = new CarFinancial();
            Car[] carsArr = carsForLinq.ToArray();

            decimal result = carFin.Analyze(p => p.Year == selectedYear ? p.Price : 0, carsArr);

            // Exporting result

            string selectedYearString = selectedYear.ToString();
            if (!Directory.Exists(selectedYearString))
            {
                Directory.CreateDirectory(selectedYearString);
            }
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

            string path = Path.Combine(selectedYearString, currentDate + ".txt");
            File.WriteAllText(path, $"Result of Analyze: {result} Ft");
        }
    }
}
