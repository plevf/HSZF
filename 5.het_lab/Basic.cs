using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.het_lab
{
    internal class Basic
    {
        public delegate int DiscountCalculator(int price); // ez még nem delegált (nincs letrehozva)
        // a delegalt egy fv eket tarolo lista

        int StudentDiscount(int price)
        {
            return (int)(price * 0.8);
        }
        int SeniorDiscount(int p) => (int)(p * 0.7);

        public Basic()
        {
            int OriginalPrice = 1000;

            DiscountCalculator calc = StudentDiscount;
            calc -= StudentDiscount;
            calc += StudentDiscount;
            calc += SeniorDiscount;

            //Console.WriteLine(calc?.Invoke(OriginalPrice));

            //foreach (DiscountCalculator func in calc.GetInvocationList())
            //{
            //    Console.WriteLine(func?.Invoke(OriginalPrice));
            //}

            PricePrinter(OriginalPrice, calc);
        }

        void PricePrinter(int price, DiscountCalculator calc)
        {
            Console.WriteLine($"New Price: {calc(price)}");
        }
    }
}
