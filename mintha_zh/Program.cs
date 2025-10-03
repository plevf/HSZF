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

            List<Car> cars;
            string fileName = "autok.txt";
            var fi = new FileInfo(fileName);
            //try
            //{
            //    cars = service.ReadFile(fileName);
            //}
            //catch(f)
            //{

            //}
            //finally
            //{
            //    cars = service.ReadFile(fileName);
            //}

                var carCounter = new CarCounter();

            carCounter.CarCountByBrand += handler; // feliratkozas

            carCounter.Counter(cars, "BMW"); // event kivaltasa
        }
    }
}
