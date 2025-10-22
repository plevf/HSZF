

namespace _7.het_lab_3
{

    // reflection

    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Reflection_Basics();
            BuiltInAttributes();
        }

        private static void BuiltInAttributes()
        {

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
