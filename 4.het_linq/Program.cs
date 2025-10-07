using System.Collections;
using System.Drawing;

namespace _4.het_linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var res = Console.ReadLine(); //úgyis string lesz

            var list = new List<string>(); //úgyis string lesz

            // DE var nem egy dinamikus változótípus! ezzel csak rövidíthetjük a kódot

            var peter = "Peter";
            //peter = 12;
            //var anna;
            // fv visszateres sem lehet

            var walter = new //névtelen osztály, típusa anonymus
            {
                RealName = "Walter White",
                FakeName = "Heisenberg"
            };

            int[] numbers =
            {
                3,8,5,78,91,24,56,78,13,24
            };

            Console.WriteLine(numbers.Median());

            Stack<DateTime> dates = new Stack<DateTime>();
            dates.Push(DateTime.Parse("2010.10.23"));
            dates.Push(DateTime.Parse("2008.02.10"));
            dates.Push(DateTime.Parse("2023.11.01"));

            Console.WriteLine(dates.Median());

            //linq

            //osszefuzes

            List<string> heroes = new List<string>()
            {

                "Superman", "Batman", "Flash"

            };



            string[] villains =
            {

                "Joker", "Lex Luthor", "Deathstroke"

            };

            var all = heroes.Concat(villains); // ezaltal nem lesz egy uj tombunk, hanem logikat ad vissza csak

            //all: Superman, Batman, Flash, Joker, Lex Luthor, Deathstroke

            bool hasSuperman = heroes.Contains("Superman");

            int[] nums = { 2, 3, 3, 4, 4, 4, 5, 5, 5, 5 };
            var uniques = nums.Distinct(); //2,3,4,5

            Point[] points =

            {

                new Point(10,20),

                new Point(3,2),

                new Point(15,2),

                new Point(6,6)

            };



            var points2 = points.OrderBy(t => t.X); // gets the X coordinate
            var points3 = points.OrderBy(t => Math.Sqrt(Math.Pow(t.X, 2) + Math.Pow(t.Y, 2))); //pitagorasz

            var filtered = points.Where(t => t.X < 10);

            var people = new[]
            {
                new { Name = "Anna", Age = 25 },
                new { Name = "Béla", Age = 30 }
            };

            // Csak a neveket szedi ki
            var names = people.Select(p => p.Name); // { "Anna", "Béla" }
            IEnumerable<string> result = people.Select(t => t.Name);

            //Method syntax
            var res1 = points
                .Where(t => t.X < 15)
                .Reverse()
                .Select(t => t.Y);
            //Query syntax
            var res2 = from t in points
                       where t.X < 15
                       orderby t.Y descending
                       select t.Y; // itt kotelezo a select

            List<SubjectInRoom> list1 = new List<SubjectInRoom>();
            //var result = rooms.SelectMany(t => t.Subjects, (room, subject) => new SubjectInRoom(room.Name, subject.Name)); ???

            List<Person> people1 = new List<Person>()

            {

                new Person ("Peter", 30, "developer", "senior"),

                new Person ("Paul", 32, "ceo", "senior"),

                new Person ("Kate", 23, "ux designer", "junior"),

                new Person ("Jack", 20, "developer", "junior"),

                new Person ("Michael", 40, "a/b tester", "senior"),

                new Person ("Susan", 27, "developer", "medior")

            };



            //var groups = people.GroupBy(t => t.Level); ?????????????

            //var groups = people.GroupBy(p => p.Level) //itt a level a key

            var rooms = new Room[]
            {

                new Room("BA.213", new Subject[]
                {

                    new Subject("elektro"),

                    new Subject("digit")

                }),

                new Room("BA.210", new Subject[]
                {

                    new Subject("hft"),

                    new Subject("sztgui")

                }),

                new Room("BA.119", new Subject[]
                {

                    new Subject("iba")

                }),

            };

            var r = rooms.SelectMany(t => t.Subjects, (room, subject) => new

            {

                RoomName = room.name,

                SubjectName = subject.name

            });
            //Console.WriteLine("SelectMany eredménye:\n");
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.RoomName} - {item.SubjectName}");
            //}

        }
    }

    public class Room
    {
        public string name;
        public Subject[] Subjects;

        public Room(string name, Subject[] sub)
        {
            this.name = name;
            this.Subjects = sub;
        }
    }
    public class Subject
    {
        public string name;

        public Subject(string name)
        {
            this.name = name;
        }
    }

    // így nem csak tömbök mediánját tudjuk meghatározni
    public static class Enumerable // ez az egesz egy extension --> a linq is az enumerable-hez fuz mindenfele extenisont
    {
        public static T Median<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            T[] items = source.ToArray();

            Array.Sort(items);

            return items[items.Length / 2];
        }
    }
    public class SubjectInRoom

    {

        public string Subject { get; set; }

        public string Room { get; set; }



        public SubjectInRoom(string subject, string room)

        {

            Subject = subject;

            Room = room;

        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Level { get; set; }
        public string Exp { get; set; }

        public Person(string name, int age, string level, string exp)
        {
            Name = name;
            Age = age;
            Level = level;
            Exp = exp;
        }

    }

}
