using _2.het_esemenykezeles.Models;

namespace _2.het_esemenykezeles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<string> items = new Storage<string>(5);
            items.storageFull += () => Console.WriteLine("A tároló megtelt!");
            Console.ReadKey();
        }
    }
}
