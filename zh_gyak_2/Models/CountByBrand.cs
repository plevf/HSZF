using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak_2.Models
{
    public class CountByBrand
    {
        public event EventHandler<CountByBrandEventArgs>? CountByBrandEvent;
        public void Counter(List<Car> cars, string brand)
        {
            CountByBrandEvent?.Invoke(this, new CountByBrandEventArgs(cars, brand));
        }
    }
}
