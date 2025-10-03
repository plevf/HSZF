using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarCounterByBrandEventArgs : AllCars
    {
        List<Car> cars;
        public string FileName { get; private set; }
        public string Brand { get; private set; }
        public int Count { get; private set; }
        public CarCounterByBrandEventArgs(string fileName, string brand) : base(fileName)
        {
            FileName = fileName;
            cars = ReadFile(fileName);
            Count = cars.Count(p => p.Brand == brand);
            Brand = brand;
        }

        public event EventHandler<CarCounterByBrandEventArgs>? CarCountByBrand;

        public void Counter(string fileName, string brand)
        {
            CarCountByBrand?.Invoke(this, new CarCounterByBrandEventArgs(fileName, brand));
        }
    }
}
