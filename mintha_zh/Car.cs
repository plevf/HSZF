using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class Car
    {
        string brand;
        string type;
        int year;
        int price;

        public string Brand => brand;

        public Car(string brand, string type, int year, int price)
        {
            this.brand = brand;
            this.type = type;
            this.year = year;
            this.price = price;
        }
    }
}
