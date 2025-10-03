using System.Threading.Channels;

namespace minta_zh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHandler<CarCounterByBrandEventArgs> handler = (sender, args) => Console.WriteLine($"There are {args.Count} {args.Brand}-s in your file ({args.FileName}) - Sender: {sender}");
            EventHandler<CarCounterByBrandEventArgs> handler2 = (sender, args) => Console.WriteLine($"For short: {args.Count} {args.Brand}(s)");
            var allCars = new AllCars("autok.txt"); // car objektum lista letrejon
            allCars.CarCountByBrand += handler;
            allCars.CarCountByBrand += handler2;
            allCars.Counter("autok.txt", "BMW"); // esemeny kivaltasa
            Console.WriteLine();
            allCars.Counter("autok.txt", "Tesla");
        }
        
    }
}
