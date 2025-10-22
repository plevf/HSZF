

using System.Reflection;
using System.Text.Json.Serialization;

namespace _7.het_lab_3
{

    // reflection

    public class Person
    {
        [Required] // custom attribute
        public int Id { get; set; }
        [JsonPropertyName("last_name")] // python-ban ez a konvencio
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        [Label("Kor")] // itt mar eleg csak Label-t irni (mindig a prop felé kell irni?)
        public int Age { get; set; }
    }

    public class LabelAttribute : Attribute
    {
        public string MyText { get; }
        public LabelAttribute(string text)
        {
            MyText = text;
        }
    }

    public class RequiredAttribute : Attribute // attributumot lehet letrehozni
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Reflection_Basics();
            BuiltInAttributes();
            CustomAttribute();
        }

        private static void CustomAttribute()
        {
            var p = new Person
            {
                Id = 1,
                LastName = "Doe",
                FirstName = "John",
                Age = 30
            };

            var t = typeof(Person);
            var ageProp = t.GetProperty("LastName");
            var jsonAttr = ageProp?.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonAttr != null)
            {
                Console.WriteLine("Json property name for LastName: " + jsonAttr.Name); // ??
            }
            else
            {
                Console.WriteLine("JsonPropertyNameAttribute not found on LastName property.");
            }

        }

        private static void BuiltInAttributes() // itt még privat tagokat is le lehet kerni
        {
            var t = typeof(Person);
            var lastNameProp = t.GetProperty("LastName");
            var jsonAttr = lastNameProp?.GetCustomAttribute<JsonPropertyNameAttribute>();
            if (jsonAttr != null)
            {
                Console.WriteLine("Json property name for LastName: " + jsonAttr.Name);
            }
            else
            {
                Console.WriteLine("JsonPropertyNameAttribute not found on LastName property.");
            }
        }

        private static void Reflection_Basics()
        {
            var p = new Person
            {
                Id = 1,
                LastName = "Doe",
                FirstName = "John",
                Age = 30
            };

            var t = typeof(Person);

            Console.WriteLine("tpye: " + t.FullName);

            foreach (var prop in t.GetProperties())
            {
                Console.WriteLine(" - " + prop.Name + " : " + prop.PropertyType.Name); // property neve plusz a tipusa
            }

            var lastNameProp = t.GetProperty("LastName");
            if(lastNameProp != null)
            {
                Console.WriteLine("original: " + lastNameProp.GetValue(p));
                lastNameProp.SetValue(p, "Smith");
                Console.WriteLine("modified: " + lastNameProp.GetValue(p));
            }
        }
    }
}
