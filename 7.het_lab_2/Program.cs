
using System.Text.Json;

namespace _7.het_lab_2
{

    // JSON

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

            string jsonPath = "people.json";

            SaveAsJson(people, jsonPath);

            var loaded = LoadFromJson<People>(jsonPath);
        }

        private static T LoadFromJson<T>(string jsonPath)
        {
            var text = File.ReadAllText(jsonPath);

            //be lehet allitani barmit kb: (pl kisbetuvel irjon mindent)

            var options = new JsonSerializerOptions
            {
                WriteIndented = true //szepen be legyen tagolva
            };

            return JsonSerializer.Deserialize<T>(text)!;
        }

        private static void SaveAsJson<T>(T value, string jsonPath)
        {
            var text = JsonSerializer.Serialize(value);
            File.WriteAllText(jsonPath, text);
        }
    }
}
