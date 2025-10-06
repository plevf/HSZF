using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh_gyak.Models
{
    public class Car
    {
        public string Brand { get; private set; }
        public string Type { get; private set; }
        public int Year { get; private set; }
        public int Price { get; private set; }

        public Car(string brand, string type, int year, int price)
        {
            Brand = brand;
            Type = type;
            Year = year;
            Price = price;
        }
    }
}
