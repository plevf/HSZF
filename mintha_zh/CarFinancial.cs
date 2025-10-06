using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    public class CarFinancial
    {
        public decimal Analyze(Func<Car, decimal> operation, Car[] cars)
        {
            decimal sum = 0;

            foreach (var car in cars)
            {
                sum += operation(car); // itt kerul bele a fv-be a car objektum
            }
            return sum;
        }
    }
}
