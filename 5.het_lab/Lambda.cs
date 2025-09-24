using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab
{
    internal class Lambda
    {
        public Lambda()
        {
            PricePrinter(1000, p => (int)(p * 0.6));
            // parameter nelkuli lambdas fv.: () => 3
            MassPricePrinter(100, 89, 40, (x, y, z) => x*4+y*8+z*9);
        }

        void PricePrinter(int price, Func<int, int> calc)
        {
            Console.WriteLine($"New Price: {calc?.Invoke(price)}"); //delegaltat MINDIG invoke-kal hivjuk
        }
        void MassPricePrinter(int price, int p2, int p3, Func<int, int, int, int> calc)
        {
            Console.WriteLine($"New Price: {calc?.Invoke(price, p2, p3)}");
        }
    }
}
