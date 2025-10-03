using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarCounterByBrandEventArgs : AllCars
    {
        public string FileName { get; private set; }
        public string Brand { get; private set; }
        public int Count { get; private set; }
        public CarCounterByBrandEventArgs(string fileName, string brand) : base(fileName)
        {
            FileName = fileName;
            Count = Cars.Count(p => p.Brand == brand);
            Brand = brand;
        }
    }
}
