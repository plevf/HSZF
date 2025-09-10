using System.Security.Cryptography.X509Certificates;

namespace _1.het_delegaltak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            void HungarianGreeter(string name)
            {
                Console.WriteLine($"Jó reggelt, {name}!");
            }

            Greeter greeterFunction = new Greeter(HungarianGreeter);

            HungarianGreeter("Péter");
            greeterFunction("Pál");
            HungarianGreeter("József");

            Console.WriteLine("---------------");

            void EnglishGreeter(string name)
            {
                Console.WriteLine($"Good morning, {name}!");
            }

            greeterFunction += EnglishGreeter;
            greeterFunction("Pál");
            greeterFunction("Anna");

            if (greeterFunction != null)
            {
                greeterFunction("Pál");
            }

            //ua. mint az alábbi:

            greeterFunction?.Invoke("Pál");

            // tehat

            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine();

            void FrenchGreeter(string name)
            {
                Console.WriteLine($"Bonjour, {name}!");
            }

            Greeter greeterFunction2 = FrenchGreeter;
            greeterFunction2 += HungarianGreeter;
            greeterFunction2("Pierre");


            Console.WriteLine();

            double Add(double a, double b)
            {
                return a + b;
            }
            double Mul(double a, double b)
            {
                return a * b;
            }

            MathDelegate del = Add;
            del += Mul;

            Console.WriteLine(del(10, 20));

            List<double> results = new List<double>();

            foreach (var item in del.GetInvocationList())
            {
                double? result = (item as MathDelegate)?.Invoke(10, 20); // A GetInvocationList() mindig Delegate[]-et ad vissza, nem pedig MathDelegate[]-et.--> ezert kell castolni

                if (result != null)
                {
                    results.Add((double)result);
                }
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

        }

        delegate void Greeter(string name);

        delegate double MathDelegate(double a, double b);
    }
}
