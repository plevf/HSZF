using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.het_delegaltak.Models
{
    class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public Person(string name, int age, string job)
        {
            Name = name;
            Age = age;
            Job = job;
        }

        public int CompareTo(Person? other)
        {
            return this.Age.CompareTo(other?.Age);
        }
    }
}
