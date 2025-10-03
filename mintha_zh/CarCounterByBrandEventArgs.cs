using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarCounterByBrandEventArgs : EventArgs
    {
        public string Brand { get; private set; }
        public int Count { get; private set; }
        public CarCounterByBrandEventArgs(List<Car> cars, string brand)
        {
            Count = cars.Count(p => p.Brand == brand);
            Brand = brand;
        }
    }
}
