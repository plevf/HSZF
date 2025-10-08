using zh_gyak_2.Exceptions;
using zh_gyak_2.Models;

namespace zh_gyak_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService service = new CarService();
            CountByBrand countBy = new CountByBrand();
            string fileName = "autok.txt";
            List<Car> cars = new List<Car>();

            try
            {
                cars = service.ReadFile(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FileNotFoundException");
            }
            catch (EmptyFileException)
            {
                Console.WriteLine("EmptyFileException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reading failed: " + ex.Message);
            }

            countBy.CountByBrandEvent += (sender, e) => Console.WriteLine($"There are {e.Count} {e.Brand}(-s) in the database. - Sender: {sender}");
            countBy.Counter(cars, "BMW");

            //linq

            var descPrice = cars.OrderByDescending(p => p.Price);

            foreach (var item in descPrice)
            {
                Console.WriteLine($"{item.Brand} - {item.Type} ({item.Year}): {item.Price} Ft");
            }

            var cheapestCar = cars.Min(p => p.Price);
            var mostExpCar = cars.Max(p => p.Price);

            //foreach (var item in cars)
            //{
            //    if(item.Price == cheapestCar)
            //    {
            //        Console.WriteLine($"{item.Brand} - {item.Type} ({item.Year}): {item.Price} Ft");
            //    }
            //}

            var anonymObj = cars.Select(a => new
            {
                Name = a.Brand + " - " + a.Type,
                Year = a.Year,
                Age = DateTime.Now.Year - a.Year
            });

            var groupByBrandDescAvgPrice = cars
                .GroupBy(p => p.Brand)
                .Select(p => new
                {
                    Brand = p.Key,
                    Count = p.Count(),
                    AvgPrice = p.Average(p => p.Price)
                })
                .OrderByDescending(p => p.AvgPrice);
        }
    }
}
