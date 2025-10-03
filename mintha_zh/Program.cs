using System.Threading.Channels;

namespace minta_zh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandler<CarCounterByBrandEventArgs> handler = (sender, args) => Console.WriteLine($"There are {args.Count} {args.Brand}-s in your file ({args.FileName}) - Sender: {sender}");

            var allCars = new AllCars("autok.txt"); // car objektum lista letrejon
            List<Car> cars = allCars.Cars;
            allCars.CarCountByBrand += handler;

            allCars.Counter("autok.txt", "BMW"); // esemeny kivaltasa
            Console.WriteLine();
            allCars.Counter("autok.txt", "Tesla");
        }
        
    }
}
