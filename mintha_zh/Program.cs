using System.Diagnostics.Metrics;
using System.Threading.Channels;

namespace minta_zh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandler<CarCounterByBrandEventArgs> handler = (sender, args) => Console.WriteLine($"There are {args.Count} {args.Brand}-s in your file - Sender: {sender}");

            List<Car> cars = ReadFile("autok.txt");

            var carCounter = new CarCounter();

            carCounter.CarCountByBrand += handler; // feliratkozas

            carCounter.Counter(cars, "BMW"); // event kivaltasa
        }

        public static List<Car> ReadFile(string fileName)
        {
            List<Car> cars = new List<Car>();
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string[] car = sr.ReadLine().Split(';');
                    cars.Add(new Car(car[0], car[1], int.Parse(car[2]), int.Parse(car[3])));
                }
            }
            return cars;
        }
    }
}
