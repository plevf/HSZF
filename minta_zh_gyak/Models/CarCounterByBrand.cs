using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh_gyak.Models
{
    public class CarCounterByBrand
    {
        public event EventHandler<CarCounterByBrandEventArgs>? carCounterByBrandEvent;

        public void Counter(List<Car> cars, string brand)
        {
            carCounterByBrandEvent?.Invoke(this, new CarCounterByBrandEventArgs(cars, brand));
        }
    }
}
