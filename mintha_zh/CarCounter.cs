using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarCounter // ez invokeolja 
    {
        public event EventHandler<CarCounterByBrandEventArgs>? CarCountByBrand;
        public void Counter(List<Car> cars, string brand)
        {
            CarCountByBrand?.Invoke(this, new CarCounterByBrandEventArgs(cars, brand));
        }
    }
}
