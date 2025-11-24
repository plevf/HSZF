using _1.het_delegaltak.Models;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace _1.het_delegaltak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. rész
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
            var t = del.GetInvocationList(); // Delegate[]

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
            #endregion
            #region 2. rész
            /*
             Készíts el egy generikus tároló osztályt, ami a háttérben egy tömbbe menti a T típusú elemeket! Készíts el egy bejárást indító függvényt, amely végiglépked az elemeken és egy külső függvényt meghív delegáltton keresztül! Legyen lehetőség transzformációs függvények hozzáadására is, amelyeket a bejáráskor meghív egymás után az osztály, de az eredeti elemet nem módosítja
            */

            void WriteOut(string item) //felesleges
            {
                Console.WriteLine(item);
            }

            string Upper(string item) //felesleges
            {
                return item.ToUpper();
            }

            string Format(string item) //felesleges
            {
                return $"*** {item} ***";
            }
            List<int> list = new List<int>() { 1, 2, 3, 4 };
            list.FindAll(p => p > 1); // nem linq

            Storage<string> stringStorage = new Storage<string>(2);
            stringStorage.Add("Hello");
            stringStorage.Add("World");
            stringStorage.AddTransformer(t => t.ToUpper());
            stringStorage.AddTransformer(Format);
            stringStorage.Traverse(t => Console.WriteLine(t));
            #endregion
            #region Func
            Func<int, int, double> func;

            double Divide(int a, int b)
            {
                return (double)a / b;
            }
            func = Divide;
            Console.WriteLine(func?.Invoke(10, 3));

            string Lower(string item)
            {
                return item.ToLower();
            }
            Func<string, string> func2 = Lower;
            string res = "TEST";
            res = func2?.Invoke(res);
            //res = func2(res);
            Console.WriteLine(res);
            #endregion
            #region 3. rész
            List<Person> people = new List<Person>
        {
            new Person("Alice", 30, "Engineer"),
            new Person("Bob", 25, "Designer"),
            new Person("Charlie", 35, "Teacher")
        };

            bool YoungerThan30(Person p) => p.Age < 30;

            List<Person> youngPeople = people.FindAll(YoungerThan30);
            foreach (var person in youngPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.Job}");
            }

            int cmp = people[0].CompareTo(people[1]);
            Console.WriteLine(cmp);

            DateTime[] dates =
            {
                DateTime.Parse("2022.10.23 12:34:23"),
                DateTime.Parse("2021.02.11 08:10:53"),
                DateTime.Parse("2023.05.27 22:31:37"),
                DateTime.Parse("2020.01.02 10:00:01"),
                DateTime.Parse("2021.12.24 18:20:30")

            };
            Array.Sort(dates, DateComparer);

            int DateComparer(DateTime x, DateTime y)
            {
                return x.Second.CompareTo(y.Second);
            }
            foreach (var date in dates)
            {
                Console.WriteLine(date);
            }
            #endregion
            #region 4. rész
            List<Person> youngWorkers = people.FindAll(delegate (Person p)
            {
                return p.Age < 30;
            });
            //ua.:
            List<Person> youngWorkersLambda = people.FindAll(p => p.Age < 30);
            Person[] people2 = new Person[]
            {
                new Person("Béla", 32, "Lawyer"),
                new Person("Cecil", 24, "Artist")
            };
            //--------------------
            Array.Sort(people2, (a, b) => a.Age.CompareTo(b.Age));
            //ua.:
            Array.Sort(people2, delegate (Person a, Person b)
            {
                if (a.Age * a.Name.Length < b.Age * b.Name.Length)
                {
                    return -1;
                }
                else if (a.Age * a.Name.Length > b.Age * b.Name.Length)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            //A 3 kozul ez tunik a legolvashatobbnak
            Array.Sort(people2, (a, b) =>
            {
                if (a.Age * a.Name.Length < b.Age * b.Name.Length)
                {
                    return -1;
                }
                else if (a.Age * a.Name.Length > b.Age * b.Name.Length)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            Action numWriter = null; // ez nem jo, mert eloszor lefut a ciklus, es csak utana hivodik meg a delegalt, igy mindenhol 10-et ir ki
            for (int i = 0; i < 10; i++)
            {
                numWriter += () => { Console.WriteLine(i); };
            }
            numWriter();

            //ez mar jo, mert minden iteracioban elmenti az aktuális i értéket egy k változóba, és azt használja a lambda kifejezésben
            Action szamkiiro = null;
            for (int i = 0; i < 10; i++)
            {
                int k = i;
                szamkiiro += () => { Console.WriteLine(k); };
            }
            szamkiiro();

            #endregion
        }

        delegate void Greeter(string name);

        delegate double MathDelegate(double a, double b);
    }
}
