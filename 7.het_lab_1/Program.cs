using System.Net.Sockets;
using System.Xml.Serialization;

namespace _7.het_lab_1
{

    // XML

    public class People
    {
        public List<Person> Items { get; set; } = new(); // new() : ne lehessen null (ures listat hoz letre)
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = ""; // "" : ne lehessen null (ures stringet hoz letre)
        public int Age { get; set; }
        public Address Address { get; set; } = new();
    }
    public class Address
    {
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string Zip { get; set; } = "";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var people = new People
            {
                Items =
                {
                    new Person{Id=1, Name="John Doe", Age=30,
                        Address=new Address{ City="New York", Street="5th Avenue", Zip="10001" } },
                    new Person{Id=2, Name="Jane Smith", Age=25,
                        Address=new Address{ City="Los Angeles", Street="Sunset Boulevard", Zip="900" } },
                    new Person{Id=3, Name="Mike Johnson", Age=40,
                        Address=new Address{ City="Chicago", Street="Michigan Avenue", Zip="60601" } }
                }
            };

            string xmlPath = "people.xml";
            SaveAsXml(people, xmlPath);

            var loaded = LoadFromXml<People>(xmlPath);
            Console.WriteLine("Names: " + string.Join(", ", loaded.Items.Select(p => p.Name))); // kiirja a neveket
        }

        private static T LoadFromXml<T>(string xmlPath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var fs = File.OpenRead(xmlPath); // file beolvasas
            return (T)serializer.Deserialize(fs)!;
        }

        private static void SaveAsXml<T>(T value, string xmlPath)
        {
            var serializer = new XmlSerializer(typeof(T)); // csomagba allitja amit el kell kuldeni pl.: egy intet (4 biteot) el akarunk kuldeni. De melyiket kuldjuk eloszor? Ezert kell a serializer (itt xml-re allitjuk elo)
            using var fs = File.Create(xmlPath);
            serializer.Serialize(fs, value);
        }
    }
}
