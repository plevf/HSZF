using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak_2.Models
{
    public class CountByBrandEventArgs : EventArgs
    {
        public string Brand { get; }
        public int Count { get; }

        public CountByBrandEventArgs(List<Car> cars,string brand)
        {
            Brand = brand;
            Count = cars.Count(p => p.Brand == brand);
        }
    }
}
