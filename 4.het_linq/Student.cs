using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.het_linq
{
    public class Student
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Mark {  get; set; }

        public Student(string name, int height, int mark)
        {
            Name = name;
            Height = height;
            Mark = mark;
        }
    }
}
