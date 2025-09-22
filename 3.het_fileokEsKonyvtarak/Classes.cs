using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.het_fileokEsKonyvtarak
{
    public class Location
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public Location()
        {
            Departments = new List<Department>();
        }
    }
    public class Department
    {
        public string Name { get; set; }
        public List<Person> People {get; set;}
        public Department()
        {
            People = new List<Person>();
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
}
