using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak_2.Models
{
    public class Car
    {
        public string Brand { get; }
        public string Type { get; }
        public int Year { get; }
        public int Price { get; }

        public Car(string brand, string type, int year, int price)
        {
            Brand = brand;
            Type = type;
            Year = year;
            Price = price;
        }
    }
}
