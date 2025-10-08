using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak_2.Models
{
    public class CarFinancial
    {
        public decimal Analyze(Func<Car, decimal> operation, Car[] cars)
        {
            decimal sum = 0;
            foreach (Car car in cars)
            {
                sum += operation(car);
            }
            return sum;
        }
    }
}
